Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data

Public Class frmVentas1_Descuentos

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

    Private Sub frmVentas1_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        txtdia.Text = Weekday(Date.Now)
    End Sub
    Private Sub frmVentas1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

        If log <> "" Then
            PictureBox2.Image = System.Drawing.Image.FromFile("C:\ControlNegociosPro\" & log)
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
            PictureBox2.Dock = DockStyle.Fill
            Panel5.Controls.Add(PictureBox2)
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
                Button6.Visible = False
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
    Private Sub frmVentas1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cbodesc.Focus().Equals(True)
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Folio()
        Timer1.Start()
    End Sub


    Private Sub txtcontraseña_Click(sender As System.Object, e As System.EventArgs) Handles txtcontraseña.Click
        If txtcontraseña.Text = "CONTRASEÑA" Then
            txtcontraseña.Text = ""
            txtcontraseña.PasswordChar = "*"
            txtcontraseña.ForeColor = Color.Black
        Else
            txtcontraseña.SelectionStart = 0
            txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
        End If
    End Sub
    Private Sub txtcontraseña_GotFocus(sender As Object, e As System.EventArgs) Handles txtcontraseña.GotFocus
        If txtcontraseña.Text = "CONTRASEÑA" Then
            txtcontraseña.Text = ""
            txtcontraseña.PasswordChar = "*"
            txtcontraseña.ForeColor = Color.Black
        Else
            txtcontraseña.SelectionStart = 0
            txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
        End If
    End Sub
    Private Sub txtcontraseña_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
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
    Private Sub txtcontraseña_LostFocus(sender As Object, e As System.EventArgs) Handles txtcontraseña.LostFocus
        If txtcontraseña.Text = "" Then
            txtcontraseña.Text = "CONTRASEÑA"
            txtcontraseña.PasswordChar = ""
            txtcontraseña.ForeColor = Color.Gray
        End If
    End Sub



#Region "Funciones"
    Public Sub Folio()
        Try
            If cnn9.State = 1 Then cnn9.Close()
            cnn9.Open()

            cmd9 = cnn9.CreateCommand
            If Me.Text = "Ventas (1)" Then
                cmd9.CommandText =
                    "select MAX(Folio) from Ventas"
            End If
            If Me.Text = "Cotización (1)" Or Me.Text = "Pedidos (1)" Then
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

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='TPapelV'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TPapel = rd3(0).ToString
                End If
            End If
            rd3.Close()

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

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='Acumula'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Acumula = IIf(rd3(0).ToString() = "1", True, False)
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
            Dim descuento As Double = IIf(txtdescu.Text = "", 0, txtdescu.Text)

            Dim total As Double = txttotal.Text

            Dim existencia As Double = 0
            If unidad <> "N/A" Then
                existencia = txtexistencia.Text
            Else
                existencia = 0
            End If
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

            If Acumula = True Then
                If descuento = 0 Then
                    'Recorre el grid a ver qué pedo
                    If grdcaptura.Rows.Count <> 0 Then
                        For ter As Integer = 0 To grdcaptura.Rows.Count - 1
                            'El código corto es igual
                            If grdcaptura.Rows(ter).Cells(0).Value.ToString = "" Then Continue For
                            If grdcaptura.Rows(ter).Cells(0).Value.ToString = codigo Then
                                'El lote es igual
                                'Agrega en el mismo registro porque el código y el lote son iguales
                                Dim canti As Double = grdcaptura.Rows(ter).Cells(3).Value.ToString()
                                Dim nueva_cant As Double = canti + cantid
                                Dim preci As Double = grdcaptura.Rows(ter).Cells(4).Value.ToString()

                                Dim nuevo_precio As Double = 0
                                If cbotipo.Visible = True Then
                                    nuevo_precio = preci
                                Else
                                    nuevo_precio = ConsultaPrecio(codigo, nueva_cant)
                                End If

                                grdcaptura(3, ter).Value = nueva_cant
                                grdcaptura(5, ter).Value = FormatNumber((nueva_cant * nuevo_precio), 2)
                            Else
                                'Agrega normal uno nuevo
                                grdcaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), descuento, FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero, txtprecio.Tag)
                            End If
                        Next
                    Else
                        'Es el primer registro que agrega y lo pone normal
                        grdcaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), descuento, FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero, txtprecio.Tag)
                    End If
                Else
                    'Sólo agrega y ya
                    grdcaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), descuento, FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero, txtprecio.Tag)
                End If
            Else
                'Sólo agrega y ya
                grdcaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), descuento, FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero, txtprecio.Tag)
            End If

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
        If txtdescuento1.Enabled = False Then

        Else
            If txtSubTotal.Tag = 0 Then
                txtSubTotal.Text = txtSubTotal.Text
                txtSubTotal.Text = CDbl(IIf(txtSubTotal.Text = "", "0", txtSubTotal.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text))
                txtSubTotal.Text = FormatNumber(txtSubTotal.Text, 2)
            End If
            If txtSubTotal.Tag <> 0 Then
                txtSubTotal.Text = txtSubTotal.Text
            End If
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
                End If
            Else
                Pasa_Print = True
            End If

            If (Pasa_Print) Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='TPapelV'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        TPrint = rd1(0).ToString
                        If TPrint = "CARTA" Or TPrint = "MEDIA CARTA" Then
                            Imprime_En = "ImpreC"
                        ElseIf TPrint = "TICKET" Then
                            Imprime_En = "ImpreT"
                        Else
                            Imprime_En = ""
                        End If
                    End If
                Else
                    MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de compras.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                End If
                rd1.Close()

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

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='" & Imprime_En & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Impresora = rd1(0).ToString
                    End If
                Else
                    MsgBox("No tienes una impresora configurada para imprimir en formato " & TPrint & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                End If
                rd1.Close() : cnn1.Close()

                If TPrint = "TICKET" Then
                    If Tamaño = "80" Then
                        pVenta80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pVenta80.Print()
                    End If
                    If Tamaño = "58" Then
                        pVenta58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pVenta58.Print()
                    End If
                End If
                If TPrint = "CARTA" Then
                    pVentaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pVentaCarta.Print()
                End If
                If TPrint = "PDF - CARTA" Then
                    'Genera PDF y lo guarda en la ruta

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
                    "delete from CotPedDetalle where Folio=" & txtcotped.Text
                cmd1.ExecuteNonQuery()
            End If

            Dim pide As String = "", contra As String = txtcontraseña.Text, usu As String = lblusuario.Text

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
            If modo_caja = "CAJA" Then
            Else
                cboNombre.Text = "MOSTRADOR"
            End If
            cbodesc.Focus().Equals(True)
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

        Dim base As Double = 0

        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select PrecioVenta from Productos where Codigo='" & cbocodigo.Text & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    base = rd4(0).ToString()
                End If
            End If
            rd4.Close() : cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try

        Dim mini As Double = precio_minimo
        Dim descontado As Double = base - mini

        Dim ope1 As Double = descontado * 100
        descuento = FormatNumber(ope1 / base, 1)
        txtprecio.Tag = base
        Return descuento
    End Function
#End Region



    'Pantalla
    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
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
                    If rd1.HasRows Then cboNombre.Items.Add(
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
    Public Sub cboNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
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
                        txttel.Text = rd1("Telefono").ToString
                        If Trim(cbocomisionista.Text) <> "" Then
                            cbocomisionista.Enabled = True
                        Else
                            cbocomisionista.Enabled = False
                        End If

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
                    txtdescu.Text = "0"
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
                    "select Saldo from AbonoI where Id=(select max(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                        If MySaldo < 0 Then
                            txtadeuda.Text = "0.00"
                            txtafavor.Text = Math.Abs(MySaldo)
                            txtafavor.Text = FormatNumber(txtafavor.Text, 2)
                        Else
                            txtafavor.Text = "0.00"
                            txtadeuda.Text = Math.Abs(MySaldo)
                            txtadeuda.Text = FormatNumber(txtadeuda.Text, 2)
                        End If
                    End If
                Else
                    txtadeuda.Text = "0.00"
                    txtafavor.Text = "0.00"
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            txtdireccion.Focus().Equals(True)
        End If
    End Sub
    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        Dim MySaldo As Double = 0

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
                "select Saldo from AbonoI where Id=(select max(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                    If MySaldo < 0 Then
                        txtadeuda.Text = "0.00"
                        txtafavor.Text = Math.Abs(MySaldo)
                        txtafavor.Text = FormatNumber(txtafavor.Text, 2)
                    Else
                        txtafavor.Text = "0.00"
                        txtadeuda.Text = Math.Abs(MySaldo)
                        txtadeuda.Text = FormatNumber(txtadeuda.Text, 2)
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
                txtdescu.Text = "0"
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
    End Sub
    Private Sub cboNombre_TextChanged(sender As Object, e As System.EventArgs) Handles cboNombre.TextChanged
        If cboNombre.Text <> cbonombretag Then
            lblNumCliente.Text = "MOSTRADOR"
            MyIdCliente = 0
            txtcredito.Text = "0.00"
            txtafavor.Text = "0.00"
            txtadeuda.Text = "0.00"
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
            cbocomisionista.Text = ""
            cbocomisionista.Enabled = True
        End If
    End Sub
    Private Sub cbotipo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbotipo.DropDown
        cbotipo.Items.Clear()
        cbotipo.Items.Add("Lista")
        cbotipo.Items.Add("Mayoreo")
        cbotipo.Items.Add("Medio Mayoreo")
        cbotipo.Items.Add("Minimo")
        cbotipo.Items.Add("Especial")
    End Sub
    Private Sub cboDomi_DropDown_1(sender As System.Object, e As System.EventArgs) Handles cboDomi.DropDown
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
    Private Sub cboDomi_SelectedValueChanged1(sender As Object, e As System.EventArgs) Handles cboDomi.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Domicilio from Entregas where Contador=" & cboDomi.Text & " and IdCliente=" & lblNumCliente.Text
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
    Private Sub txtdireccion_KeyPress_2(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdireccion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txttel.Focus().Equals(True)
        End If
    End Sub
    Private Sub cbocomisionista_DropDown(sender As System.Object, e As System.EventArgs) Handles cbocomisionista.DropDown
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
    Private Sub cbocomisionista_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocomisionista.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnventa.Focus().Equals(True)
        End If
    End Sub
    Private Sub picProd_DoubleClick(sender As Object, e As System.EventArgs) Handles picProd.DoubleClick
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
    Private Sub cbonota_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonota.DropDown
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
    Private Sub cbonota_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonota.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodesc.Focus().Equals(True)
        End If
    End Sub
    Private Sub cbonota_LostFocus(sender As Object, e As System.EventArgs) Handles cbonota.LostFocus
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
    Private Sub cbonota_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonota.SelectedValueChanged
        cbodesc.Focus().Equals(True)
        Call cbonota_LostFocus(cbonota, New EventArgs())
    End Sub
    Private Sub txtMonedero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonedero.KeyPress
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



    'Productos
    Private Sub cbodesc_DropDown(sender As System.Object, e As System.EventArgs) Handles cbodesc.DropDown
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
    Private Sub cbodesc_GotFocus(sender As Object, e As System.EventArgs) Handles cbodesc.GotFocus
        T_Precio = DatosRecarga("TipoPrecio")
        H_Inicia = DatosRecarga("HoraInicia")
        H_Final = DatosRecarga("HoraTermina")
    End Sub
    Private Sub cbodesc_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbodesc.SelectedValueChanged
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
    Private Sub cbodesc_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbodesc.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F2
                If cbodesc.Text <> "" Then MsgBox("Primero baja el producto para asignar un comentario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbodesc.Focus().Equals(True) : Exit Sub
                If grdcaptura.Rows.Count = 0 Then MsgBox("No cuentas con productos para asignar comentarios.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
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
    Private Sub cbodesc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbodesc.KeyPress
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
                                txtdescu.Text = "0"
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
                                txtdescu.Text = "0"
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
                                        txtdescu.Text = "0"
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
                                    VarSumXD = VarSumXD + CDbl(grdcaptura.Rows(w).Cells(6).Value.ToString)
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
                            txtdescu.Text = "0"
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
    Private Sub cbocodigo_Click(sender As System.Object, e As System.EventArgs) Handles cbocodigo.Click
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub
    Private Sub cbocodigo_TextChanged(sender As Object, e As System.EventArgs) Handles cbocodigo.TextChanged
        Dim nombre As String = cbocodigo.Text
        If System.IO.File.Exists(ruta_servidor & "\ProductosImg\" & nombre & ".jpg") Then
            picProd.Image = System.Drawing.Image.FromFile(ruta_servidor & "\ProductosImg\" & nombre & ".jpg")
        End If
    End Sub
    Private Sub cbocodigo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbocodigo.DropDown
        If cbocodigo.Text = "" Then Exit Sub
        cbocodigo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Left(Codigo, 6)='" & Strings.Left(cbocodigo.Text, 6) & "' order by Codigo"
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
    Private Sub cbocodigo_GotFocus(sender As Object, e As System.EventArgs) Handles cbocodigo.GotFocus
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)

        T_Precio = DatosRecarga("TipoPrecio")
        H_Inicia = DatosRecarga("HoraInicia")
        H_Final = DatosRecarga("HoraTermina")
    End Sub
    Private Sub cbocodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocodigo.KeyPress
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

                            If File.Exists("C:\ControlNegociosPro\ProductosImg\" & cbocodigo.Text & ".jpg") Then
                                picProd.Image = System.Drawing.Image.FromFile("C:\ControlNegociosPro\ProductosImg\" & cbocodigo.Text & ".jpg")
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
    Private Sub txtcantidad_Click(sender As System.Object, e As System.EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub
    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub
    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
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
    Private Sub txtcantidad_TextChanged(sender As Object, e As System.EventArgs) Handles txtcantidad.TextChanged
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
    Private Sub txtprecio_Click(sender As System.Object, e As System.EventArgs) Handles txtprecio.Click
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub
    Private Sub txtprecio_GotFocus(sender As Object, e As System.EventArgs) Handles txtprecio.GotFocus
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub
    Private Sub txtprecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
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
                            txtprecio.Tag = txtprecio.Text
                            txtdescu.Focus().Equals(True)
                        End If
                    Else
                        If chec = True Then
                            Dim existencia As Double = rd1("Existencia").ToString
                            Dim TExiste As Double = existencia - CDbl(txtcantidad.Text)

                            If TExiste < 0 And btndevo.Text = "DEVOLUCIÓN" Then
                                If Me.Text = "Ventas (1)" Then
                                    MsgBox("No puedes vender sin existencia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                    txtcantidad.Focus().Equals(True)
                                    rd1.Close() : cnn1.Close()
                                    Exit Sub
                                Else
                                    If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                    If AscW(e.KeyChar) = Keys.Enter Then
                                        txtprecio.Tag = txtprecio.Text
                                        txtdescu.Focus().Equals(True)
                                    End If
                                End If
                            Else
                                If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                If AscW(e.KeyChar) = Keys.Enter Then
                                    txtprecio.Tag = txtprecio.Text
                                    txtdescu.Focus().Equals(True)
                                End If
                            End If
                        Else
                            If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                            If AscW(e.KeyChar) = Keys.Enter Then
                                txtprecio.Tag = txtprecio.Text
                                txtdescu.Focus().Equals(True)
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
    Private Sub txtprecio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtprecio.TextChanged
        txttotal.Text = CDbl(IIf(txtcantidad.Text = "" Or txtcantidad.Text = ".", "0", txtcantidad.Text)) * CDbl(IIf(txtprecio.Text = "" Or txtprecio.Text = ".", "0", txtprecio.Text))
        txttotal.Text = FormatNumber(txttotal.Text, 2)
    End Sub
    Private Sub txtdescu_Click(sender As Object, e As EventArgs) Handles txtdescu.Click
        txtdescu.SelectionStart = 0
        txtdescu.SelectionLength = Len(txtdescu.Text)
    End Sub
    Private Sub txtdescu_GotFocus(sender As Object, e As EventArgs) Handles txtdescu.GotFocus
        txtdescu.SelectionStart = 0
        txtdescu.SelectionLength = Len(txtdescu.Text)
    End Sub
    Private Sub txtdescu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescu.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        Dim chec As Boolean = False
        Dim renta As Boolean = False

        If AscW(e.KeyChar) = Keys.Enter Then

            If txtdescu.Text = "" Then txtprecio.Text = FormatNumber(txtprecio.Tag, 2) : Exit Sub
            If Not IsNumeric(txtdescu.Text) Then Exit Sub
            If txtprecio.Text = "" Then Exit Sub

            Dim precio As Double = txtprecio.Tag
            Dim por_descu As Double = txtdescu.Text

            Dim porciento As Double = por_descu / 100
            Dim total_descuento As Double = precio * porciento
            Dim nuevo_precio As Double = precio - total_descuento

            txtprecio.Text = FormatNumber(nuevo_precio, 2)


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

            Dim cant_lotes As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                    ElseIf CStr(rd1("Grupo").ToString) = "RENTAS" Then
                        renta = True
                    Else
                        If chec = True Then
                            If btndevo.Text <> "Guardar devolución" Then
                                Dim Existe As Double = rd1("Existencia").ToString
                                Dim TExiste As Double = Existe - CDbl(txtcantidad.Text)
                                If Me.Text = "Ventas (1)" Then
                                    If TExiste < 0 Then
                                        MsgBox("No está permitido vender sin existencias.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                        txtcantidad.Focus().Equals(True)
                                        rd1.Close() : cnn1.Close()
                                        Exit Sub
                                    End If
                                Else
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()

            If ValCantDev(13) = False Then
                cnn1.Close()
                Exit Sub
            End If

            If cbocodigo.Text = "" Then cbodesc.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text)) = 0 Or txtcantidad.Text = "" Then cbocodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text)) = 0 Or txtprecio.Text = "" Then cbocodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select PreMin from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If Promo = False Then
                        If CDbl(txtprecio.Text) < CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) Then
                            If btndevo.Text <> "GUARDAR DEVOLUCIÓN" Then
                                MsgBox("El precio de venta mínimo establecido es de " & FormatNumber(rd1(0).ToString, 2) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                txtprecio.Text = FormatNumber(rd1(0).ToString(), 2)
                                txtdescu.Text = Calcula_Descu(txtprecio.Tag, CDbl(rd1(0).ToString()))
                                My.Application.DoEvents()
                                MsgBox("Tu descuento mínimo para esta producto es de " & txtdescu.Text, vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                txtdescu.Focus().Equals(True)
                                txtdescu.SelectAll()
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()

            If CDbl(txtdescu.Text) > 0 Then
                txtdescuento1.Enabled = False
            End If

            txtefectivo.Text = "0.00"
            txtCambio.Text = "0.00"
            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
            txttotal.Text = FormatNumber(txttotal.Text, 2)
            Call UpGrid()

            Dim VarDesc As Double = 0

            txtdescuento2.Text = "0"
            Dim VarSumXD As Double = 0
            For w = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(w).Cells(6).Value.ToString = "" Then
                Else
                    VarSumXD = VarSumXD + (CDbl(grdcaptura.Rows(w).Cells(13).Value.ToString) * CDbl(grdcaptura.Rows(w).Cells(3).Value.ToString()))

                    txtdescuento2.Text = FormatNumber(CDbl(txtdescuento2.Text) + ((CDbl(grdcaptura.Rows(w).Cells(13).Value.ToString()) - CDbl(grdcaptura.Rows(w).Cells(4).Value.ToString())) * CDbl(grdcaptura.Rows(w).Cells(3).Value.ToString())), 2)
                    txtSubTotal.Text = FormatNumber(VarSumXD, 2)
                End If
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
            txtcantidad.Text = ""
            txtprecio.Text = "0.00"
            txtprecio.Tag = 0
            txttotal.Text = "0.00"
            txtexistencia.Text = ""
            txtfechacad.Text = ""
            txtdescu.Text = "0"
            txtubicacion.Text = ""
            picProd.Image = Nothing
            cnn1.Close()

            If CDbl(txtdescuento2.Text) > 0 Then
                txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
                txtPagar.Text = FormatNumber(txtPagar.Text, 2)
            End If

            Call txtdescuento1_TextChanged(txtdescuento1, New EventArgs())

            cbodesc.Focus().Equals(True)
        End If
    End Sub
    Private Sub txttotal_Click(sender As System.Object, e As System.EventArgs) Handles txttotal.Click
        txttotal.SelectionStart = 0
        txttotal.SelectionLength = Len(txttotal.Text)
    End Sub
    Private Sub txttotal_GotFocus(sender As Object, e As System.EventArgs) Handles txttotal.GotFocus
        txttotal.SelectionStart = 0
        txttotal.SelectionLength = Len(txttotal.Text)
    End Sub
    Private Sub txttotal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttotal.KeyPress
        Dim edita_pr As Boolean = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select EditaPrecios from Permisos where IdEmpleado=" & id_usu_log
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
    Private Sub txttotal_TextChanged(sender As Object, e As System.EventArgs) Handles txttotal.TextChanged
        Call Actualiza()
    End Sub
    Private Sub txtcoment_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoment.KeyPress
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
    Private Sub txtcomentario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomentario.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            boxcomentario.Visible = False
            btnventa.Focus().Equals(True)
        End If
    End Sub
    Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
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
            txtdescu.Text = "0" ' grdcaptura.Rows(index).Cells(5).Value.ToString()
            txttotal.Text = FormatNumber(grdcaptura.Rows(index).Cells(6).Value.ToString, 2)
            txtexistencia.Text = grdcaptura.Rows(index).Cells(7).Value.ToString

            If grdcaptura.Rows.Count = 1 Then
                CODx = grdcaptura.Rows(index).Cells(0).Value.ToString
                CantDX = grdcaptura.Rows(index).Cells(3).Value.ToString
                txtdescuento1.Enabled = True
                txtdescuento1.Text = "0"
                txtdescuento2.Text = "0.00"
                txtSubTotal.Text = "0.00"
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

            Dim tot_descuentos_partida As Double = 0

            For ter As Integer = 0 To grdcaptura.Rows.Count - 1
                tot_descuentos_partida = tot_descuentos_partida + CDbl(grdcaptura.Rows(ter).Cells(5).Value.ToString())
            Next
            If tot_descuentos_partida > 0 Then
                txtdescuento1.Enabled = False
                txtdescuento1.Text = "0"
            Else
                txtdescuento1.Enabled = True
                txtdescuento1.Text = "0"
            End If

            Dim SUBsinIVA As Double = 0
            Dim SinDesct As Double = 0

            If txtSubTotal.Text = "0.00" Or CDbl(txtSubTotal.Text) = 0 Then cbodesc.Focus().Equals(True)
            If txtdescuento1.Enabled = True Then
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

                                    SUBsinIVA = SUBsinIVA + (CDbl(grdcaptura.Rows(N).Cells(6).Value.ToString()) / (1 + CDbl(rd1(0).ToString)))
                                    SinDesct = SinDesct + CDbl(grdcaptura.Rows(N).Cells(6).Value.ToString())

                                    tmpIva = 1 + CDbl(rd1(0).ToString)
                                    tmpDsct = (CDbl(grdcaptura.Rows(N).Cells(6).Value.ToString) / (1 + CDbl(rd1(0).ToString))) * CDbl(txtdescuento1.Text) / 100
                                    Tpagar = Tpagar + ((CDbl(grdcaptura.Rows(N).Cells(6).Value.ToString()) / (1 + CDbl(rd1(0).ToString)) - tmpDsct) * tmpIva)
                                    tmpSub = tmpSub + ((CDec(grdcaptura.Rows(N).Cells(6).Value.ToString) - (CDec(grdcaptura.Rows(N).Cells(6).Value.ToString()) * (CDbl(txtdescuento1.Text) / 100)))) / (1 + (CDbl(rd1(0).ToString)))
                                End If
                            End If
                            rd1.Close()
                        End If
                    Next
                    cnn1.Close()

                    txtdescuento2.Text = FormatNumber(SUBsinIVA * CDbl(txtdescuento1.Text), 2)
                    Dim VarSunXD As Double = 0
                    For w As Integer = 0 To grdcaptura.Rows.Count - 1
                        VarSunXD = VarSunXD + CDbl(grdcaptura.Rows(w).Cells(6).Value.ToString)
                    Next
                    txtPagar.Text = FormatNumber(VarSunXD, 2)
                    txtSubTotal.Text = FormatNumber(Tpagar, 2)
                End If
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



    'Pagos
    Private Sub txtPagar_DoubleClick(sender As Object, e As System.EventArgs) Handles txtPagar.DoubleClick
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
    Private Sub txtdescuento1_Click(sender As Object, e As System.EventArgs) Handles txtdescuento1.Click
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub
    Private Sub txtdescuento1_GotFocus(sender As Object, e As System.EventArgs) Handles txtdescuento1.GotFocus
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub
    Private Sub txtdescuento1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuento1.KeyPress
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
    Public Sub txtdescuento1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdescuento1.TextChanged
        If txtdescuento1.Enabled = True Then
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
        Else
            txtResta.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text) - CDbl(txtMontoP.Text) - (CDbl(txtefectivo.Text) - CDbl(txtCambio.Text)), 2)
            txtPagar.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text), 2)
        End If
    End Sub
    Private Sub txtdescuento2_GotFocus(sender As Object, e As System.EventArgs) Handles txtdescuento2.GotFocus
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub
    Private Sub txtdescuento2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuento2.KeyPress
        If Not IsNumeric(txtdescuento2.Text) Then txtdescuento2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 2)
            txtPagar.Text = FormatNumber(CDbl(IIf(txtPagar.Text = "", "0", txtPagar.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 2)
            txtResta.Text = FormatNumber(CDbl(IIf(txtResta.Text = "", "0", txtResta.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 2)
            txtefectivo.Focus().Equals(True)
        End If
    End Sub
    Private Sub txtdescuento2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdescuento2.TextChanged
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub
    Private Sub txtefectivo_Click(sender As System.Object, e As System.EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub
    Private Sub txtefectivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub
    Private Sub txtefectivo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtefectivo.KeyDown
        If txtSubTotal.Text <> "" Then
            If modo_caja = "CAJA" Then
                txtefectivo.ReadOnly = False
            End If
        Else
            txtefectivo.ReadOnly = True
        End If
    End Sub
    Private Sub txtefectivo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtefectivo.KeyPress
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
    Private Sub txtefectivo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtefectivo.TextChanged
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
    Private Sub cbobanco_DropDown(sender As System.Object, e As System.EventArgs) Handles cbobanco.DropDown
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
    Private Sub cbobanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumref.Focus().Equals(True)
        End If
    End Sub
    Private Sub cbotpago_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbotpago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus().Equals(True)
        End If
    End Sub
    Private Sub txtnumref_Click(sender As Object, e As System.EventArgs) Handles txtnumref.Click
        txtnumref.SelectionStart = 0
        txtnumref.SelectionLength = Len(txtnumref.Text)
    End Sub
    Private Sub txtnumref_GotFocus(sender As Object, e As System.EventArgs) Handles txtnumref.GotFocus
        txtnumref.SelectionStart = 0
        txtnumref.SelectionLength = Len(txtnumref.Text)
    End Sub
    Private Sub txtnumref_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumref.KeyPress
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
    Private Sub txtmonto_Click(sender As System.Object, e As System.EventArgs) Handles txtmonto.Click
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub
    Private Sub txtmonto_GotFocus(sender As Object, e As System.EventArgs) Handles txtmonto.GotFocus
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub
    Private Sub txtmonto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
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
    Private Sub txtMontoP_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMontoP.TextChanged
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
    Private Sub cbotpago_DropDown(sender As System.Object, e As System.EventArgs) Handles cbotpago.DropDown
        'cbotpago.Items.Clear()
        'cbotpago.Items.Add("TARJETA")
        'cbotpago.Items.Add("TRANSFERENCIA")
        'cbotpago.Items.Add("MONEDERO")
        'cbotpago.Items.Add("DEPOSITO")
        'cbotpago.Items.Add("OTRO")

        Try
            cbotpago.Items.Clear()
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    cbotpago.Items.Add(rd2(0).ToString)
                End If
            Loop
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub
    Private Sub cbotpago_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbotpago.SelectedValueChanged
        If cbotpago.Text = "MONEDERO" Then
            lblsaldo_monedero.Visible = True
            txtsaldo_monedero.Visible = True
            cbobanco.Enabled = False
            txtnumref.Focus().Equals(True)
        Else
            lblsaldo_monedero.Visible = False
            txtsaldo_monedero.Visible = False
            cbobanco.Enabled = True
            cbobanco.Focus().Equals(True)
        End If
    End Sub
    Private Sub dtpFecha_P_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha_P.KeyPress
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
    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Dim tpago As String = cbotpago.Text
        Dim banco As String = cbobanco.Text
        Dim refe As String = txtnumref.Text
        Dim monto As Double = FormatNumber(txtmonto.Text, 2)
        Dim fecha As String = Format(dtpFecha_P.Value, "dd/MM/yyyy")
        Dim comentario As String = txtComentarioPago.Text
        Dim cuentar As String = cboCuentaRecepcion.Text
        Dim bancor As String = cboBancoRecepcion.Text

        grdpago.Rows.Add(tpago, banco, refe, monto, fecha, comentario, cuentar, bancor)
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
        cboBancoRecepcion.Text = ""

    End Sub



    'Botones
    Private Sub btncomentario_Click(sender As System.Object, e As System.EventArgs) Handles btncomentario.Click
        If grdcaptura.Rows.Count = 0 Then
            MsgBox("Agrega productos a la venta para asignar un comentario.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        boxcomentario.Visible = True
        txtcomentario.Focus().Equals(True)
    End Sub
    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        Timer1.Stop()
        Me.Text = "Ventas (1)"

        txttel.Text = ""
        cboNombre.Text = ""
        cboNombre.Items.Clear()
        cbonombretag = ""
        txtdireccion.Text = ""

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
        txtdescu.Text = "0"
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

        txtdescuento1.Enabled = True
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
        Button6.Text = "Programar entrega"

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
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        VieneDe_Folios = "frmVentas1_Descuentos"
        frmConsultaNotas.Show()
        frmConsultaNotas.BringToFront()
    End Sub
    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        frmModEntregas.Show()
        frmModEntregas.BringToFront()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        frmMonederos.Show()
        frmMonederos.BringToFront()
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        frmAbonoNotas.Show()
        frmAbonoNotas.BringToFront()
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        frmPasa_Corte.Show()
    End Sub
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs)
        If lblentrega.Visible = False Then
            lblentrega.Visible = True
            Entrega = True
            dtpFecha_E.Visible = True
            dtpFecha_E.Focus().Equals(True)
            Button6.Text = "Cancelar"
        Else
            lblentrega.Visible = False
            Entrega = False
            dtpFecha_E.Visible = False
            btnventa.Focus().Equals(True)
            Button6.Text = "Programar entrega"
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmVentas2_Descuentos.Show()
        frmVentas2_Descuentos.BringToFront()
    End Sub



    'Cotizaciones
    Public Sub Insert_Cotizacion()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sInfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim DsctoProd As Single = 0, PorcentDscto As Single = 0, DsctoProdTod As Single = 0
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

                If .runSp(a_cnn, "insert into CotPed(idCliente,Nombre,Direccion,Totales,Descuento,ACuenta,Resta,Usuario,FVenta,HVenta,Status,MontoSnDesc,Comentario,Telefono) values(0,'" & cboNombre.Text & "','" & EliminarSaltosLinea(txtdireccion.Text, " ") & "',0,0,0,0,'" & lblusuario.Text & "',#" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "#,#" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "#,'COTIZACION',0,'" & txtcomentario.Text & "','" & tel_cliente & "')", sInfo) Then
                    sInfo = ""
                Else
                    MsgBox(sInfo)
                End If

                If .getDr(a_cnn, dr, "select MAX(Folio) from CotPed", sInfo) Then
                    my_folio = dr(0).ToString()
                End If

                Dim cod_temp As String = ""

                For pipo As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(pipo).Cells(0).Value.ToString()
                    If codigo = "" Then GoTo doorcita

                    DsctoProd = 0
                    DsctoProdTod = 0
                    PorcentDscto = IIf(txtdescuento1.Text = "", 0, txtdescuento1.Text)
                    If txtdescuento1.Enabled = True Then
                        If PorcentDscto <> 0 Then
                            DsctoProd = CDbl(grdcaptura.Rows(pipo).Cells(4).Value.ToString) * (PorcentDscto / 100)
                        End If
                    Else
                        DsctoProd = CDbl(grdcaptura.Rows(pipo).Cells(13).Value.ToString()) - CDbl(grdcaptura.Rows(pipo).Cells(4).Value.ToString())
                    End If

                    Dim nombre As String = grdcaptura.Rows(pipo).Cells(1).Value.ToString()
                    Dim unidad As String = grdcaptura.Rows(pipo).Cells(2).Value.ToString()
                    Dim cantidad As Double = grdcaptura.Rows(pipo).Cells(3).Value.ToString()
                    Dim precio_original As Double = grdcaptura.Rows(pipo).Cells(13).Value.ToString()
                    Dim precio_descuento As Double = FormatNumber(CDbl(grdcaptura.Rows(pipo).Cells(13).Value.ToString()) - DsctoProd, 2)
                    Dim descuento As Double = DsctoProd
                    Dim total_original As Double = precio_original * cantidad
                    Dim total_descuento As Double = precio_descuento * cantidad

                    If codigo <> "" Then
                        cod_temp = codigo
                        .runSp(a_cnn, "insert into CotPedDetalle(Folio,Codigo,Nombre,Cantidad,UVenta,Precio_Original,Total_Original,Descuento_Unitario,Descuento_Total,Precio_Descuento,Total_Descuento,Comisionista,Comentario) values(" & my_folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "'," & precio_original & "," & total_original & "," & descuento & "," & descuento * cantidad & "," & precio_descuento & "," & total_descuento & ",'','')", sInfo)
                        sInfo = ""
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
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Text = "Cotización (1)"
        If Me.Text = "Ventas (1)" Or Me.Text = "Pedidos (1)" Then
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

            'If cboNombre.Text = "" Then
            '    cboNombre.Text = "PUBLICO EN GENERAL"
            'End If

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

                Dim monto_desc As Double = CDbl(txtPagar.Text) + CDbl(txtdescuento2.Text)

                IVA_Vent = CDbl(txtPagar.Text) - MySubtotal
                SubTotal = MySubtotal
                Total_Ve = txtPagar.Text
                MYFOLIO = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into CotPed(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,Fecha,Hora,Status,Tipo,Comentario,IP,MontoSinDesc,Descuento) values(" & IdCliente & ",'" & cboNombre.Text & "',''," & SubTotal & "," & IVA_Vent & "," & Total_Ve & ",0,0,'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','COTIZACION','" & cboimpresion.Text & "','" & dameIP2() & "'," & monto_desc & "," & CDbl(txtdescuento2.Text) & ")"
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
                    Dim descuento As Double = grdcaptura.Rows(T).Cells(5).Value.ToString()
                    Dim mytotal As Double = FormatNumber(mycant * myprecio, 2)

                    Dim ieps As Double = grdcaptura.Rows(T).Cells(8).Value.ToString
                    Dim tasaieps As Double = grdcaptura.Rows(T).Cells(9).Value.ToString

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
                        "insert into CotPedDet(Folio,Codigo,Nombre,Cantidad,Unidad,CostoV,Precio,Total,PrecioSIVA,TotalSIVA,Fecha,Usuario,Depto,Grupo,CostVR,Tipo,Descuento) values(" & MYFOLIO & ",'" & mycode & "','" & mydesc & "'," & mycant & ",'" & myunid & "'," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MyDepto & "','" & MyGrupo & "','','COTIZACION'," & descuento & ")"
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
                '-------------------------------------------------------------------------------------------------------------------------------------------------------

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
                    PDF_Cotizacion()
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
        Dim FileNta As New CotizacionDescuento

        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\")
        root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf"

        If File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf") Then
            File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
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

        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & MYFOLIO & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & lblusuario.Text & "'"
        FileNta.DataDefinition.FormulaFields("conLetra").Text = "'" & convLetras(txtPagar.Text) & "'"

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
            System.IO.File.Copy("C:\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
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



    'Ventas
    Private Sub Insert_Venta()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim DsctoProd As Single = 0, PorcentDscto As Single = 0, DsctoProdTod As Single = 0
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
                If .runSp(a_cnn, "insert into Ventas(Nombre,Direccion,Totales,Descuento,ACuenta,Resta,Usuario,FVenta,HVenta,Status,Comentario,FolMonedero,CodFactura,Entregas,Telefono) values('" & cboNombre.Text & "','" & EliminarSaltosLinea(txtdireccion.Text, " ") & "'," & CDbl(txtPagar.Text) & "," & CDbl(txtdescu.Text) & "," & ACuenta & "," & Resta & ",'" & lblusuario.Text & "',#" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "#,#" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "#,'" & MyStatus & "','','','',0,'" & tel_cliente & "')", sinfo) Then
                    sinfo = ""
                Else
                    MsgBox(sinfo)
                    Panel6.Visible = False
                End If

                If .getDr(a_cnn, dr, "select MAX(Folio) from Ventas", sinfo) Then
                    my_folio = dr(0).ToString()
                End If

                Dim cod_temp As String = ""

                For pipo As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(pipo).Cells(0).Value.ToString()
                    If codigo = "" Then GoTo doorcita

                    DsctoProd = 0
                    DsctoProdTod = 0
                    PorcentDscto = IIf(txtdescuento1.Text = "", 0, txtdescuento1.Text)
                    If txtdescuento1.Enabled = True Then
                        If PorcentDscto <> 0 Then
                            DsctoProd = CDbl(grdcaptura.Rows(pipo).Cells(4).Value.ToString) * (PorcentDscto / 100)
                        End If
                    Else
                        DsctoProd = CDbl(grdcaptura.Rows(pipo).Cells(13).Value.ToString()) - CDbl(grdcaptura.Rows(pipo).Cells(4).Value.ToString())
                    End If

                    Dim nombre As String = grdcaptura.Rows(pipo).Cells(1).Value.ToString()
                    Dim unidad As String = grdcaptura.Rows(pipo).Cells(2).Value.ToString()
                    Dim cantidad As Double = grdcaptura.Rows(pipo).Cells(3).Value.ToString()
                    Dim precio_original As Double = grdcaptura.Rows(pipo).Cells(13).Value.ToString()
                    Dim precio_descuento As Double = FormatNumber(CDbl(grdcaptura.Rows(pipo).Cells(13).Value.ToString()) - DsctoProd, 2)
                    Dim descuento As Double = DsctoProd
                    Dim total_original As Double = precio_original * cantidad
                    Dim total_descuento As Double = precio_descuento * cantidad

                    If codigo <> "" Then
                        cod_temp = codigo
                        .runSp(a_cnn, "insert into VentasDetalle(Folio,Codigo,Nombre,Cantidad,UVenta,Precio_Original,Total_Original,Dscto_Unitario,Dscto_Total,Precio_Descuento,Total_Descuento,Depto,Grupo,CostVR,FechaCad,LoteCad,NumParte) values(" & my_folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "'," & precio_original & "," & total_original & "," & descuento & "," & (descuento * cantidad) & "," & precio_descuento & "," & total_descuento & ",'','','','','','')", sinfo)
                        sinfo = ""
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
    Private Sub btnventa_Click(sender As System.Object, e As System.EventArgs) Handles btnventa.Click
        Dim VarUser As String = "", VarIdUsuario As Integer = 0
        Dim DsctoProd As Single = 0, PorcentDscto As Single = 0, DsctoProdTod As Single = 0
        Dim CveLte As Double = 0
        Dim IdCliente As Integer = 0
        Dim ConteoXD As Double = 0

        Dim TotalIEPSPrint As Double = 0
        Dim SubtotalPrint As Double = 0
        Dim MySubtotal As Double = 0
        Dim TotalIVAPrint As Double = 0
        'If cboNombre.Text = "" Then
        '    cboNombre.Text = "PUBLICO EN GENERAL"
        'End If

        Try
            For i As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(i).Cells(0).Value.ToString = "" Then
                Else
                    ConteoXD = ConteoXD + CDbl(grdcaptura.Rows(i).Cells(6).Value.ToString)
                End If
                txtSubTotal.Text = FormatNumber(ConteoXD, 2)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try
            If txtMonedero.Text <> "" Then
                Dim saldo As Double = 0
                If lblmonedero.BackColor = Color.White Then
                    Call txtMonedero_KeyPress(txtMonedero, New KeyPressEventArgs(ChrW(Keys.Enter)))
                End If
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Monedero where Barras='" & txtMonedero.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        saldo = rd1("Saldo").ToString
                    End If
                Else
                    MsgBox("No se encuentra un registro de el monedero ingresado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close() : cnn1.Close()
                    txtMonedero.Focus().Equals(True) : Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

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
                            If CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If modo_caja = "CAJA" Then
            If cboNombre.Text = "" And CDbl(IIf(txtResta.Text = "", "0", txtResta.Text)) <> 0 Then
                MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cboNombre.Focus().Equals(True)
                cnn1.Close() : Exit Sub
            End If
        End If

        If grdcaptura.Rows.Count < 1 Then txtdescuento1.Focus().Equals(True) : cnn1.Close() : Exit Sub
        If CDbl(IIf(txtResta.Text = "", "0", txtResta.Text)) <> 0 Then
            If modo_caja = "CAJA" Then
                If cboNombre.Text = "" Then
                    MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cboNombre.Focus().Equals(True)
                    cnn1.Close() : Exit Sub
                End If
            End If
        End If

        Dim TotTarjeta As Double = 0, TotTransfe As Double = 0, TotMonedero As Double = 0, TotOtros As Double = 0
        Dim BanTarjeta As String = "", BanTransfe As String = "", BanMonedero As String = "", BanOtros As String = ""
        Dim RefTarjeta As String = "", RefTransfe As String = "", RefMonedero As String = "", RefOtros As String = ""
        Dim comentariopago As String = ""

        If grdpago.Rows.Count > 0 Then
            For R As Integer = 0 To grdpago.Rows.Count - 1
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "TARJETA" Then
                    TotTarjeta = TotTarjeta + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                    BanTarjeta = BanTarjeta & "- " & CStr(grdpago.Rows(R).Cells(1).Value.ToString)
                    RefTarjeta = RefTarjeta & "- " & CStr(grdpago.Rows(R).Cells(2).Value.ToString)
                    comentariopago = grdpago.Rows(R).Cells(5).Value.ToString
                End If
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "TRANSFERENCIA" Then
                    TotTransfe = TotTransfe + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                    BanTransfe = BanTransfe & "- " & CStr(grdpago.Rows(R).Cells(1).Value.ToString)
                    RefTransfe = RefTransfe & "- " & CStr(grdpago.Rows(R).Cells(2).Value.ToString)
                    comentariopago = grdpago.Rows(R).Cells(5).Value.ToString
                End If
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "MONEDERO" Then
                    TotMonedero = TotMonedero + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                    BanMonedero = BanMonedero & "- " & CStr(grdpago.Rows(R).Cells(1).Value.ToString)
                    RefMonedero = RefMonedero & "- " & CStr(grdpago.Rows(R).Cells(2).Value.ToString)
                    comentariopago = grdpago.Rows(R).Cells(5).Value.ToString
                End If
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "OTRO" Then
                    TotOtros = TotOtros + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                    BanOtros = BanOtros & "- " & CStr(grdpago.Rows(R).Cells(1).Value.ToString)
                    RefOtros = RefOtros & "- " & CStr(grdpago.Rows(R).Cells(2).Value.ToString)
                    comentariopago = grdpago.Rows(R).Cells(5).Value.ToString
                End If
            Next
        End If

        Dim Cliente As String = ""
        Dim dias_credito As Double = 0
        Dim max_cred As Double = 0

        Dim fecha_pago As String = ""

        Try
            If cboNombre.Text = "" Then
                IdCliente = 0
                Cliente = ""
                dias_credito = 0
                fecha_pago = ""
            Else
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Clientes where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        IdCliente = rd1("Id").ToString
                        Cliente = cboNombre.Text
                        dias_credito = rd1("DiasCred").ToString()
                        fecha_pago = DateAdd(DateInterval.Day, dias_credito, Date.Now)
                    End If
                Else
                    IdCliente = 0
                    Cliente = ""
                    dias_credito = 0
                    fecha_pago = ""
                End If
                rd1.Close() : cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If lblusuario.Text = "" Then
            MsgBox("Escribe/Revisa tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cnn1.Close()
            DondeVoy = "Venta"
            txtcontraseña.Focus().Equals(True) : Exit Sub
        Else
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    VarUser = rd1("Alias").ToString
                    VarIdUsuario = rd1("IdEmpleado").ToString
                End If
            Else
                MsgBox("No se encuentra un usuario registrado bajo esta contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close()
                txtcontraseña.Focus().Equals(True) : Exit Sub
            End If
            rd1.Close() : cnn1.Close()
        End If

        Dim per_venta As Boolean = False
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Permisos where IdEmpleado= " & VarIdUsuario
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                per_venta = rd1("Vent_NVen").ToString
            End If
        End If
        rd1.Close() : cnn1.Close()

        If Not (per_venta) Then
            MsgBox("No cuentas con permiso para realizar notas de venta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub

        Dim credito_dispo As Double = (CDbl(txtcredito.Text) + CDbl(txtafavor.Text)) - ((CDbl(txtPagar.Text) + CDbl(txtadeuda.Text)) - (CDbl(txtMontoP.Text) + CDbl(txtefectivo.Text)))

        If CDbl(txtResta.Text) > 0 Then
            If lblNumCliente.Text <> "MOSTRADOR" And ((CDbl(txtPagar.Text) + CDbl(txtadeuda.Text)) - (CDbl(txtMontoP.Text) + CDbl(txtefectivo.Text))) > (CDbl(txtcredito.Text) + CDbl(txtafavor.Text)) Then
                MsgBox("No se puede completar la operación porque se rebasaría el crédito disponible." & vbNewLine & "Crédito disponible: " & FormatNumber(credito_dispo, 2) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close() : txtefectivo.Focus().Equals(True) : Exit Sub
            End If
        End If

        Dim MyStatus As String = ""
        Dim ACuenta As Double = 0
        Dim ACUenta2 As Double = 0
        Dim Resta As Double = 0
        Dim Efectivo As Double = 0
        Dim MyMonto As Double = 0

        Dim SubTotal As Double = 0
        Dim IVA_Vent As Double = 0
        Dim Total_Ve As Double = 0
        Dim Descuento As Double = 0
        Dim MontoSDesc As Double = 0

        Dim CodCadena As String = ""
        Dim cadena As String = ""
        Dim ope1 As Double = 0
        Dim Car As Integer = 0

        Dim letters As String = ""
        Dim Numeros As String = ""
        Dim Letras As String = ""
        Dim lic As String = ""

        ope1 = Math.Cos(CDbl(lblfolio.Text))
        If ope1 > 0 Then
            cadena = Strings.Left(Replace(CStr(ope1), ".", "9"), 10)
        Else
            cadena = Strings.Left(Replace(CStr(Math.Abs(ope1)), ".", "8"), 10)
        End If
        For i = 1 To 10
            Car = Mid(cadena, i, 1)
            Select Case Car
                Case Is = 0
                    letters = letters & "Y"
                Case Is = 1
                    letters = letters & "Z"
                Case Is = 2
                    letters = letters & "W"
                Case Is = 3
                    letters = letters & "H"
                Case Is = 4
                    letters = letters & "S"
                Case Is = 5
                    letters = letters & "B"
                Case Is = 6
                    letters = letters & "C"
                Case Is = 7
                    letters = letters & "P"
                Case Is = 8
                    letters = letters & "Q"
                Case Is = 9
                    letters = letters & "A"
                Case Else
                    letters = letters & Car
            End Select
        Next
        For w = 1 To 10 Step 2
            Numeros = Mid(lblfolio.Text, w, 2)
            Letras = Mid(letters, w, 2)
            lic = lic & Numeros & Letras & "-"
        Next
        lic = Strings.Left(lic, Len(lic) - 1)
        CodCadena = lic



        Try
            'Inserta en [Ventas]
            Select Case lblNumCliente.Text
                Case Is = "MOSTRADOR"
                    IdCliente = 0
                    Cliente = ""
                    Efectivo = txtefectivo.Text
                    ACuenta = FormatNumber((Efectivo - CDbl(txtCambio.Text)) + CDbl(txtMontoP.Text), 2)
                    Resta = FormatNumber(txtResta.Text, 2)
                    MySubtotal = FormatNumber(MySubtotal, 2)

                    If CDbl(txtResta.Text) = 0 Then
                        MyStatus = "PAGADO"
                    Else
                        MyStatus = "RESTA"
                    End If

                    If CDbl(txtdescuento1.Text) > 0 Then
                        Dim Zi As Integer = 0, TotalTemp As Double = 0, SumaTotales As Double = 0, TotalesIVATemp As Double = 0
                        Dim CodTemp As String = "", CantTemp As Double = 0, PreUni As Double = 0
                        Dim IvaTemp As Double = 0
                        For A As Integer = 0 To grdcaptura.Rows.Count - 1
                            If grdcaptura.Rows(A).Cells(0).Value.ToString <> "" Then
                                CodTemp = grdcaptura.Rows(A).Cells(0).Value.ToString
                                CantTemp = grdcaptura.Rows(A).Cells(3).Value.ToString
                                PreUni = CDbl(grdcaptura.Rows(A).Cells(4).Value.ToString) - (CDbl(grdcaptura.Rows(A).Cells(4).Value.ToString) * (CDbl(txtdescuento1.Text) / 100))
                                IvaTemp = IvaDSC(CodTemp)
                                TotalTemp = (PreUni * CantTemp) / (1 + IvaTemp)
                                TotalesIVATemp = (TotalTemp * (1 + IvaTemp)) - TotalTemp
                                SumaTotales = SumaTotales + TotalesIVATemp
                            End If
                        Next

                        SumaTotales = FormatNumber(SumaTotales, 2)

                        SubTotal = FormatNumber(CDbl(txtPagar.Text) - SumaTotales, 2)
                        IVA_Vent = FormatNumber(SumaTotales, 2)
                        Total_Ve = FormatNumber(CDbl(txtPagar.Text), 2)
                        Descuento = FormatNumber(txtdescuento2.Text, 2)
                        MontoSDesc = FormatNumber(CDbl(txtPagar.Text) + Descuento, 2)

                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Entrega,Comentario,StatusE,FolMonedero,CodFactura,IP,Formato) values(" & IdCliente & ",'" & cboNombre.Text & "','" & txtdireccion.Text & "'," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACuenta & "," & Resta & ",'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & fecha_pago & "','','" & MyStatus & "','" & cbocomisionista.Text & "',''," & MontoSDesc & ",'" & Format(dtpFecha_E.Value, "dd/MM/yyyy") & "'," & IIf(Entrega = True, 1, 0) & ",'',0,'" & txtMonedero.Text & "','" & CodCadena & "','" & dameIP2() & "','" & cboimpresion.Text & "')"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()
                    Else
                        IVA_Vent = FormatNumber(CDbl(txtPagar.Text) - CDbl(TotalIVAPrint), 2)
                        SubTotal = FormatNumber(TotalIVAPrint, 2)
                        Total_Ve = FormatNumber(CDbl(txtPagar.Text), 2)
                        Descuento = FormatNumber(txtdescuento2.Text, 2)
                        MontoSDesc = FormatNumber(CDbl(txtPagar.Text) + Descuento, 2)

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Entrega,Comentario,StatusE,FolMonedero,CodFactura,IP,Formato) values(" & IdCliente & ",'" & cboNombre.Text & "','" & txtdireccion.Text & "'," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACuenta & "," & Resta & ",'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & fecha_pago & "','','" & MyStatus & "','" & cbocomisionista.Text & "',''," & MontoSDesc & ",'" & Format(dtpFecha_E.Value, "dd/MM/yyyy") & "'," & IIf(Entrega = True, 1, 0) & ",'',0,'" & txtMonedero.Text & "','" & CodCadena & "','" & dameIP2() & "','" & cboimpresion.Text & "')"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()
                    End If
                Case Is <> "MOSTRADOR"
                    Efectivo = txtefectivo.Text
                    MyMonto = Efectivo + CDbl(txtMontoP.Text) + CDbl(txtafavor.Text)
                    Resta = FormatNumber(txtResta.Text, 2)
                    MySubtotal = FormatNumber(MySubtotal, 2)

                    If MyMonto > CDbl(txtPagar.Text) Then
                        ACUenta2 = FormatNumber(CDbl(txtPagar.Text), 2)
                        Resta = 0
                    Else
                        ACUenta2 = FormatNumber(MyMonto, 2)
                        Resta = FormatNumber(CDbl(txtPagar.Text) - MyMonto, 2)
                    End If

                    txtResta.Text = Resta

                    If Resta = 0 Then
                        MyStatus = "PAGADO"
                    Else
                        MyStatus = "RESTA"
                    End If

                    IVA_Vent = FormatNumber(CDbl(txtPagar.Text) - TotalIVAPrint, 2)
                    SubTotal = FormatNumber(TotalIVAPrint, 2)
                    Total_Ve = FormatNumber(CDbl(txtPagar.Text), 2)
                    Descuento = FormatNumber(txtdescuento2.Text, 2)
                    MontoSDesc = FormatNumber(CDbl(txtPagar.Text) + Descuento, 2)

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Entrega,Comentario,StatusE,FolMonedero,CodFactura,IP,Formato) values(" & IdCliente & ",'" & cboNombre.Text & "','" & txtdireccion.Text & "'," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACUenta2 & "," & Resta & ",'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & fecha_pago & "','','" & MyStatus & "','" & cbocomisionista.Text & "',''," & MontoSDesc & ",'" & Format(dtpFecha_E.Value, "dd/MM/yyyy") & "'," & IIf(Entrega = True, 1, 0) & ",'',0,'" & txtMonedero.Text & "','" & CodCadena & "','" & dameIP2() & "','" & cboimpresion.Text & "')"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        cnn2.Close() : cnn2.Open()
        Do Until MYFOLIO <> 0
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select MAX(Folio) from Ventas where IP='" & dameIP2() & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MYFOLIO = rd2(0).ToString()
                End If
            End If
            rd2.Close()
        Loop

        If txtMonedero.Text <> "" Then
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "update Ventas set FolMonedero='" & txtMonedero.Text & "' where Folio=" & MYFOLIO
            cmd2.ExecuteNonQuery()
        End If
        cnn2.Close()

        'Actualiza tablas de pago
        Try
            cnn1.Close() : cnn1.Open()
            If grdpago.Rows.Count > 0 Then
                For T As Integer = 0 To grdpago.Rows.Count - 1
                    Dim FormaP As String = grdpago.Rows(T).Cells(0).Value.ToString()
                    Dim BancoP As String = grdpago.Rows(T).Cells(1).Value.ToString()
                    Dim MontoP As Double = grdpago.Rows(T).Cells(3).Value.ToString()
                    Dim RefeP As String = grdpago.Rows(T).Cells(2).Value.ToString()
                    Dim FechaP As String = grdpago.Rows(T).Cells(4).Value.ToString()
                    Dim comentariop As String = grdpago.Rows(T).Cells(5).Value.ToString()

                    If FormaP = "MONEDERO" Then
                        Dim SaldoMone As Double = 0
                        Dim NuveoSald As Double = 0
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from MovMonedero where Id=(select MAX(Id) from MovMonedero where Monedero='" & RefeP & "')"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                SaldoMone = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                            End If
                        End If
                        rd1.Close()
                        NuveoSald = SaldoMone - MontoP

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) values('" & RefeP & "','Venta',0," & MontoP & "," & NuveoSald & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MYFOLIO & ")"
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Monedero set Saldo=" & NuveoSald & " where Barras='" & RefeP & "'"
                        cmd1.ExecuteNonQuery()
                    End If


                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                            "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Fecha,Hora,Folio,Comentario) values('" & FormaP & "','" & BancoP & "','" & RefeP & "','Venta'," & MontoP & ",0," & MontoP & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & MYFOLIO & "','" & comentariop & "')"
                    cmd1.ExecuteNonQuery()

                Next
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        'Actualiza [Monedero] / [MovMonedero]
        Try
            If txtMonedero.Text <> "" Then
                Dim sal_monedero As Double = 0
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from MovMonedero where Id=(select MAX(Id) from MovMonedero where Monedero='" & txtMonedero.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sal_monedero = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                    End If
                End If
                rd1.Close()

                Dim porc_mone As Double = 0
                Dim precio_prod As Double = 0
                Dim cantid_prod As Double = 0
                Dim nvo_saldo As Double = 0
                Dim porcentaje As Double = 0
                Dim ope As Double = 0

                For denji As Integer = 0 To grdcaptura.Rows.Count - 1
                    porc_mone = grdcaptura(14, denji).Value
                    precio_prod = grdcaptura(4, denji).Value
                    cantid_prod = grdcaptura(3, denji).Value

                    Dim total_bono As Double = (porc_mone * precio_prod) / 100
                    ope = ope + (total_bono * cantid_prod)
                Next
                nvo_saldo = ope + sal_monedero

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Monedero set Saldo=" & nvo_saldo & " where Barras='" & txtMonedero.Text & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) values('" & txtMonedero.Text & "','Venta'," & ope & ",0," & nvo_saldo & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MYFOLIO & ")"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try


        'Inserta en [AbonoI]
        Try
            cnn1.Close() : cnn1.Open()
            Dim MySaldo As Double = 0

            If lblNumCliente.Text <> "MOSTRADOR" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from Abono where Id=(select MAX(Id) from Abono where IdCliente=" & lblNumCliente.Text & ")"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + CDbl(txtPagar.Text), 2)
                    End If
                Else
                    MySaldo = FormatNumber(txtPagar.Text, 2)
                End If
                rd1.Close()

                Resta = FormatNumber(txtResta.Text, 2)

                If CDbl(txtResta.Text) > 0 And CDbl(txtafavor.Text) > 0 And CDbl(txtPagar.Text) = CDbl(txtResta.Text) Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & MYFOLIO & "," & IdCliente & ",'" & cboNombre.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','" & lblusuario.Text & "'," & Resta & ",'')"
                    cmd1.ExecuteNonQuery()
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & MYFOLIO & "," & IdCliente & ",'" & cboNombre.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','" & lblusuario.Text & "',0,'')"
                    cmd1.ExecuteNonQuery()
                End If
            End If

            ACuenta = FormatNumber(CDbl(txtefectivo.Text) - CDbl(txtCambio.Text) + CDbl(txtMontoP.Text), 2)

            If ACuenta > 0 Then
                Dim EfectivoX As Double = FormatNumber(CDbl(txtefectivo.Text) - CDbl(txtCambio.Text), 2)
                Dim Bancos As String = BanMonedero & BanOtros & BanTarjeta & BanTransfe
                Dim Refes As String = RefMonedero & RefOtros & RefTarjeta & RefTransfe

                If grdpago.Rows.Count > 0 Then
                    For T As Integer = 0 To grdpago.Rows.Count - 1

                        Dim FormaP As String = grdpago.Rows(T).Cells(0).Value.ToString()
                        Dim BancoP As String = grdpago.Rows(T).Cells(1).Value.ToString()
                        Dim MontoP As Double = grdpago.Rows(T).Cells(3).Value.ToString()
                        Dim RefeP As String = grdpago.Rows(T).Cells(2).Value.ToString()
                        Dim FechaP As String = grdpago.Rows(T).Cells(4).Value.ToString()
                        Dim comentario As String = grdpago.Rows(T).Cells(5).Value.ToString()
                        Dim cuentarep As String = grdpago.Rows(T).Cells(6).Value.ToString()
                        Dim bancorep As String = grdpago.Rows(T).Cells(7).Value.ToString()

                        Select Case lblNumCliente.Text
                            Case Is = "MOSTRADOR"
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,MontoSF,Comentario,CuentaC,BRecepcion) values(" & MYFOLIO & ",0,'" & cboNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MontoP & ",0,0,'" & FormaP & "'," & MontoP & ",'" & BancoP & "','" & RefeP & "','" & lblusuario.Text & "',0,'" & comentario & "','" & cuentarep & "','" & bancorep & "')"
                                cmd1.ExecuteNonQuery()

                            Case Is <> "MOSTRADOR"
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "select Saldo from Abono where Id=(select MAX(Id) from Abono where IdCliente=" & lblNumCliente.Text & ")"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - ACuenta, 2)
                                    End If
                                Else
                                    MySaldo = FormatNumber(txtPagar.Text, 2)
                                End If
                                rd1.Close()

                                Resta = FormatNumber(txtResta.Text, 2)

                                If CDbl(txtResta.Text) > 0 And CDbl(txtafavor.Text) > 0 Then
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,MontoSF,Comentario,CuentaC,BRecepcion) values(" & MYFOLIO & "," & IdCliente & ",'" & cboNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MontoP & "," & MySaldo & ",0,'" & FormaP & "'," & MontoP & ",'" & BancoP & "','" & RefeP & "','" & lblusuario.Text & "'," & Resta & ",'" & comentario & "','" & cuentarep & "','" & bancorep & "')"
                                    cmd1.ExecuteNonQuery()
                                Else
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,Comentario,CuentaC,BRecepcion) values(" & MYFOLIO & "," & IdCliente & ",'" & cboNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MontoP & "," & MySaldo & ",0,'" & FormaP & "','" & MontoP & "','" & bancorep & "','" & RefeP & "','" & lblusuario.Text & "','" & comentario & "','" & cuentarep & "','" & bancorep & "')"
                                    cmd1.ExecuteNonQuery()
                                End If
                        End Select
                    Next
                End If

                If EfectivoX > 0 Then
                    Select Case lblNumCliente.Text
                        Case Is = "MOSTRADOR"
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                            "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,MontoSF,Comentario,CuentaC,BRecepcion) values(" & MYFOLIO & ",0,'" & cboNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & EfectivoX & ",0," & EfectivoX & ",'',0,'','','" & lblusuario.Text & "',0,'','','')"
                            cmd1.ExecuteNonQuery()
                        Case Is <> "MOSTRADOR"
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                            "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - ACuenta, 2)
                                End If
                            Else
                                MySaldo = FormatNumber(txtPagar.Text, 2)
                            End If
                            rd1.Close()

                            Resta = FormatNumber(txtResta.Text, 2)

                            If CDbl(txtResta.Text) > 0 And CDbl(txtafavor.Text) > 0 Then
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,MontoSF,Comentario,CuentaC,BRecepcion) values(" & MYFOLIO & "," & IdCliente & ",'" & cboNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & EfectivoX & "," & MySaldo & "," & EfectivoX & ",'',0,'','','" & lblusuario.Text & "'," & Resta & ",'','','')"
                                cmd1.ExecuteNonQuery()
                            Else
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,Comentario,CuentaC,BRecepcion) values(" & MYFOLIO & "," & IdCliente & ",'" & cboNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & EfectivoX & "," & MySaldo & "," & EfectivoX & ",'',0,'','','" & lblusuario.Text & "','','','')"
                                cmd1.ExecuteNonQuery()
                            End If
                    End Select
                End If

            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try
            cnn1.Open()
            For R As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(R).Cells(0).Value.ToString = "" Then GoTo Door

                DsctoProd = 0
                DsctoProdTod = 0
                PorcentDscto = IIf(txtdescuento1.Text = "", 0, txtdescuento1.Text)
                If PorcentDscto <> 0 Then
                    DsctoProd = CDbl(grdcaptura.Rows(R).Cells(4).Value.ToString) * (PorcentDscto / 100)
                    DsctoProdTod = CDbl(grdcaptura.Rows(R).Cells(10).Value.ToString) * (PorcentDscto / 100)
                End If

                Dim mycode As String = grdcaptura.Rows(R).Cells(0).Value.ToString
                Dim mydesc As String = grdcaptura.Rows(R).Cells(1).Value.ToString
                Dim myunid As String = grdcaptura.Rows(R).Cells(2).Value.ToString
                Dim mycant As Double = grdcaptura.Rows(R).Cells(3).Value.ToString
                Dim myprecio As Double = grdcaptura.Rows(R).Cells(4).Value.ToString
                Dim descue As Double = grdcaptura.Rows(R).Cells(5).Value.ToString()
                Dim mytotal As Double = FormatNumber(mycant * myprecio, 2)

                Dim ieps As Double = grdcaptura.Rows(R).Cells(8).Value.ToString
                Dim tasaieps As Double = grdcaptura.Rows(R).Cells(9).Value.ToString
                Dim monedero As Double = grdcaptura(12, R).Value
                Dim Unico As Boolean = False

                Dim MyIVA As Double = 0

                Dim MyMCD As Double = 0
                Dim MyMulti2 As Double = 0
                Dim MyMultiplo As Double = 0
                Dim MyDepto As String = ""
                Dim MyGrupo As String = ""
                Dim Kit As Boolean = False
                Dim Existencia As Double = 0
                Dim Pre_Comp As Double = 0

                Dim MyCostVUE As Double = 0
                Dim MyProm As Double = 0

                Dim myprecioS As Double = 0
                Dim mytotalS As Double = 0

                TotalIEPSPrint = TotalIEPSPrint + CDbl(grdcaptura.Rows(R).Cells(8).Value.ToString)

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
                        MyDepto = rd1("Departamento").ToString()
                        MyGrupo = rd1("Grupo").ToString()
                        Kit = rd1("ProvRes").ToString()
                        MyMCD = rd1("MCD").ToString()
                        MyMulti2 = rd1("Multiplo").ToString()
                        Unico = rd1("Unico").ToString()
                        If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                            rd1.Close() : cnn1.Close()
                            GoTo Door
                        End If
                    End If
                End If
                rd1.Close()
                Dim existe As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existe = rd1("Existencia").ToString()
                        MyMultiplo = rd1("MCD").ToString()
                        Existencia = existe / MyMultiplo
                        If rd1("Departamento").ToString() <> "SERVICIOS" Then
                            Pre_Comp = rd1("PrecioCompra").ToString()
                            MyCostVUE = Pre_Comp * (mycant / MyMCD)
                        End If
                    End If
                End If
                rd1.Close()
Door:
                If grdcaptura.Rows(R).Cells(0).Value.ToString() <> "" Then

                    If txtdescuento1.Enabled = True Then 'Global
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Promo_Monedero,Unico,Descuento) values(" & MYFOLIO & ",'" & mycode & "','" & mydesc & "','" & myunid & "'," & mycant & "," & MyProm & "," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & cbocomisionista.Text & "','0','" & MyDepto & "','" & MyGrupo & "','0'," & DsctoProdTod & ",0," & ieps & "," & tasaieps & ",'','',0," & monedero & "," & IIf(Unico = False, 0, 1) & "," & DsctoProdTod & ")"
                        cmd1.ExecuteNonQuery()
                    Else                                 'Producto

                        Dim precito_ori As Double = grdcaptura.Rows(R).Cells(13).Value.ToString()
                        Dim total_ori As Double = CDbl(grdcaptura.Rows(R).Cells(13).Value.ToString()) * mycant

                        Dim precito As Double = grdcaptura.Rows(R).Cells(13).Value.ToString()
                        Dim totalito As Double = CDbl(grdcaptura.Rows(R).Cells(13).Value.ToString()) * mycant
                        Dim descuentito As Double = grdcaptura.Rows(R).Cells(5).Value.ToString()
                        Dim descuento_finalito As Double = 0

                        If MyIVA <> 0 Then
                            precito = FormatNumber(precito / 1.16, 6)
                            totalito = FormatNumber(totalito / (1.16), 6)
                        End If

                        descuento_finalito = totalito * (descuentito / 100)


                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Promo_Monedero,Unico,Descuento) values(" & MYFOLIO & ",'" & mycode & "','" & mydesc & "','" & myunid & "'," & mycant & "," & MyProm & "," & MyCostVUE & "," & precito_ori & "," & total_ori & "," & precito & "," & totalito & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & cbocomisionista.Text & "','0','" & MyDepto & "','" & MyGrupo & "','0'," & descuento_finalito & ",0," & ieps & "," & tasaieps & ",'','',0," & monedero & "," & IIf(Unico = False, 0, 1) & "," & descuento_finalito & ")"
                        cmd1.ExecuteNonQuery()
                    End If

                    'cmd1 = cnn1.CreateCommand
                    'cmd1.CommandText =
                    '    "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Promo_Monedero,Unico,Descuento) values(" & MYFOLIO & ",'" & mycode & "','" & mydesc & "','" & myunid & "'," & mycant & "," & MyProm & "," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & cbocomisionista.Text & "','0','" & MyDepto & "','" & MyGrupo & "',''," & (DsctoProd * mycant) & ",0," & ieps & "," & tasaieps & ",'','',0," & monedero & "," & IIf(Unico = False, 0, 1) & "," & (DsctoProd * mycant) & ")"
                    'cmd1.ExecuteNonQuery()

                    Dim necesito As Double = mycant / MyMCD
                    Dim tengo As Double = 0
                    Dim cuanto_cuestan As Double = 0
                    Dim id_peps As Integer = 0
                    Dim utilidad As Double = 0

                    Dim quedan As Double = 0
                    Dim v_costo As Double = 0
                    Dim v_venta As Double = 0

                    If MyDepto <> "SERVICIOS" And Kit = False Then
                        'Cálculos de PePs
                        Do While necesito > 0
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "select Id,Saldo,Costo from Costeo where Id=(select MIN(Id) from Costeo where (Concepto='COMPRA' or Concepto='ENTRADA') and Saldo>0 and Codigo='" & Strings.Left(mycode, 6) & "')"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    id_peps = rd1("Id").ToString()
                                    tengo = rd1("Saldo").ToString()
                                    cuanto_cuestan = rd1("Costo").ToString()
                                End If
                            Else
                                'Esto para evitar un bucle cuando no hay una compra previa
                                rd1.Close()
                                Exit Do
                            End If
                            rd1.Close()

                            'En todo va a hacer los cálculos de la utilidad
                            If tengo >= necesito Then
                                quedan = tengo - necesito
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "update Costeo set Saldo=" & quedan & " where Id=" & id_peps
                                cmd1.ExecuteNonQuery()

                                v_costo = necesito * cuanto_cuestan
                                v_venta = necesito * myprecio
                                utilidad = utilidad + (v_venta - v_costo)

                                Exit Do
                            ElseIf tengo < necesito Then
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "update Costeo set Saldo=0 where Id=" & id_peps
                                cmd1.ExecuteNonQuery()

                                v_costo = tengo * cuanto_cuestan
                                v_venta = tengo * myprecio
                                utilidad = (v_venta - v_costo)
                                necesito = necesito - tengo

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MYFOLIO & "','" & Strings.Left(mycode, 6) & "','" & mydesc & "','" & myunid & "',0," & (tengo * MyMultiplo) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblusuario.Text & "')"
                                cmd1.ExecuteNonQuery()
                                utilidad = 0
                            End If
                        Loop

                        'Sí alcanzan las que tengo en el primer registro, entonces guarda y avanza
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MYFOLIO & "','" & Strings.Left(mycode, 6) & "','" & mydesc & "','" & myunid & "',0," & (necesito * MyMultiplo) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblusuario.Text & "')"
                        cmd1.ExecuteNonQuery()

                        Dim nueva_existe As Double = 0
                        nueva_existe = Existencia - (mycant / MyMCD)

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set CargadoInv=0, Cargado=0, Existencia=" & nueva_existe & " where Codigo='" & Strings.Left(mycode, 6) & "'"
                        cmd1.ExecuteNonQuery()

                        If Len(mycode) = 6 Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & Existencia & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MYFOLIO & "','','','','','')"
                            cmd1.ExecuteNonQuery()
                        Else
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & existe & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MYFOLIO & "','','','','','')"
                            cmd1.ExecuteNonQuery()
                        End If
                    End If

                    utilidad = 0
                    v_venta = 0
                    v_costo = 0
                    necesito = 0
                    tengo = 0

                    If Kit = True Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Kits where Nombre='" & mydesc & "'"
                        rd1 = cmd1.ExecuteReader
                        cnn2.Close() : cnn2.Open()
                        Do While rd1.Read
                            If rd1.HasRows Then
                                Dim Cod As String = rd1("Codigo").ToString
                                Dim Nomb As String = rd1("Descrip").ToString
                                Dim Preci As Double = rd1("PPrecio").ToString
                                Dim Unid As String = rd1("UVenta").ToString()
                                Dim cant As Double = FormatNumber(CDbl(rd1("Cantidad").ToString) * mycant, 2)

                                Dim exi_hay As Double = 0
                                Dim exi_mas As Double = 0
                                necesito = cant * MyMultiplo
                                'Cálculos de PePs
                                Do While necesito > 0
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "select * from Costeo where Id=(select MIN(Id) from Costeo where (Concepto='COMPRA' or Concepto='ENTRADA') and Saldo>0 and Codigo='" & Strings.Left(Cod, 6) & "')"
                                    rd1 = cmd1.ExecuteReader
                                    If rd1.HasRows Then
                                        If rd1.Read Then
                                            id_peps = rd1("Id").ToString()
                                            tengo = rd1("Saldo").ToString()
                                            cuanto_cuestan = rd1("Costo").ToString()
                                        End If
                                    Else
                                        rd1.Close()
                                        Exit Do
                                    End If
                                    rd1.Close()
                                    'En todo va a hacer los cálculos de la utilidad
                                    If tengo >= necesito Then
                                        quedan = tengo - necesito
                                        cmd1 = cnn1.CreateCommand
                                        cmd1.CommandText =
                                            "update Costeo set Saldo=" & quedan & " where Id=" & id_peps
                                        cmd1.ExecuteNonQuery()

                                        v_costo = necesito * cuanto_cuestan
                                        v_venta = necesito * Preci
                                        utilidad = utilidad + (v_venta - v_costo)

                                        Exit Do
                                    ElseIf tengo < necesito Then
                                        cmd1 = cnn1.CreateCommand
                                        cmd1.CommandText =
                                            "update Costeo set Saldo=0 where Id=" & id_peps
                                        cmd1.ExecuteNonQuery()

                                        v_costo = tengo * cuanto_cuestan
                                        v_venta = tengo * Preci
                                        utilidad = (v_venta - v_costo)
                                        necesito = necesito - tengo
                                        utilidad = 0

                                        cmd1 = cnn1.CreateCommand
                                        cmd1.CommandText =
                                            "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MYFOLIO & "','" & Strings.Left(mycode, 6) & "','" & mydesc & "','" & myunid & "',0," & (tengo * MyMultiplo) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblusuario.Text & "')"
                                        cmd1.ExecuteNonQuery()
                                    End If
                                Loop

                                'Sí alcanzan las que tengo en el primer registro, entonces guarda y avanza
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MYFOLIO & "','" & Strings.Left(Cod, 6) & "','" & Nomb & "','" & Unid & "',0," & (necesito * MyMultiplo) & ",0," & cuanto_cuestan & "," & Preci & "," & utilidad & ",'" & lblusuario.Text & "')"
                                cmd1.ExecuteNonQuery()

                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "select * from Productos where Codigo='" & Strings.Left(Cod, 6) & "'"
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    If rd2.Read Then
                                        existe = rd2("Existencia").ToString()
                                        MyMultiplo = rd2("Multiplo").ToString()
                                        exi_hay = existe / MyMultiplo
                                    End If
                                End If
                                rd2.Close()

                                exi_mas = FormatNumber(exi_hay - (cant * MyMultiplo), 2)

                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "update Productos set Cargado=0, CargadoInv=0, Existencia=" & exi_mas & " where Codigo='" & Strings.Left(Cod, 6) & "'"
                                cmd2.ExecuteNonQuery()

                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & Cod & "','" & Nomb & "','Venta'," & exi_hay & "," & cant & "," & exi_mas & "," & Preci & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MYFOLIO & "','','','','','')"
                                cmd2.ExecuteNonQuery()
                            End If
                        Loop
                        cnn2.Close()
                        rd1.Close()
                    End If
                End If

                If grdcaptura.Rows(R).Cells(0).Value.ToString = "" And grdcaptura.Rows(R).Cells(1).Value.ToString <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update VentasDetalle set CostVR='" & grdcaptura.Rows(R).Cells(1).Value.ToString & "' where CostVR='' and Codigo='" & mycode & "' and Folio=" & MYFOLIO
                    cmd1.ExecuteNonQuery()
                End If
            Next
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close() : cnn2.Close()
        End Try

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
        '-------------------------------------------------------------------------------------------------------------------------------------------------------

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
    End Sub
    Private Sub PDF_Venta()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New VentaDescuento
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\")
        root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & MYFOLIO & ".pdf"

        If File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & MYFOLIO & ".pdf") Then
            File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & MYFOLIO & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & MYFOLIO & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & MYFOLIO & ".pdf")
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

        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & MYFOLIO & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & lblusuario.Text & "'"
        FileNta.DataDefinition.FormulaFields("conLetra").Text = "'" & convLetras(txtPagar.Text) & "'"

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
            System.IO.File.Copy("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & MYFOLIO & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & MYFOLIO & ".pdf")
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


    'Devolucines
    Private Sub btndevo_Click(sender As System.Object, e As System.EventArgs) Handles btndevo.Click
        Dim id_usu As Integer = 0
        Dim per_dev As Boolean = False
        Dim TotalCantidadProd As Single = 0
        Dim Totalx As Single = 0

        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : DondeVoy = "Devo" : txtcontraseña.Focus().Equals(True) : Exit Sub

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                id_usu = rd1("IdEmpleado").ToString
                lblusuario.Text = rd1("Alias").ToString
            End If
        Else
            MsgBox("Usuario inexistente, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtcontraseña.Focus().Equals(True)
            DondeVoy = "Devo"
            rd1.Close() : cnn1.Open()
            Exit Sub
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Permisos where IdEmpleado=" & id_usu
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                per_dev = rd1("Vent_Devo").ToString
            End If
        End If
        rd1.Close() : cnn1.Close()

        If Not (per_dev) Then MsgBox("No cuentas con permiso para realizar devoluciones de mercancía.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : DondeVoy = "Devo" : Exit Sub

        If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
            If grdcaptura.Rows.Count = 0 Then Exit Sub

            If lblusuario.Text = "" Then
                MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtcontraseña.Focus().Equals(True)
                Exit Sub
            End If

            If MsgBox("¿Deseas realizar este devolución?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

            btndevo.Text = "DEVOLUCIÓN"
            TotalCantidadProd = TCantProd(cbonota.Text)

            If TotalCantidadProd = 1 Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Cantidad from VentasDetalle where Folio=" & cbonota.Text
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Totalx = rd1(0).ToString
                            If Totalx = 1 Then
                                MsgBox("Para este único producto es necesario realizar la cancelación de la venta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                rd1.Close() : cnn1.Close()
                                btnnuevo.PerformClick()
                                Exit Sub
                            End If
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            Totalx = 0

            Dim Total_devo As Double = txtPagar.Text
            Dim Salee As Double = 0

            Dim Resta_ventas As Double = 0
            Dim Acuenta_venta As Double = 0
            Dim Devolucion As Double = 0

            Dim Nuevo_resta As Double = 0
            Dim Nuevo_acuenta As Double = 0
            Dim Nuevo_devo As Double = 0
            Dim MySaldo As Double = 0
            Dim Devuelve As Double = 0

            'Seleccionar acuenta y resta de la venta para ver sí afecta o no al efectivo de la caja
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Ventas where Folio=" & cbonota.Text
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Resta_ventas = rd1("Resta").ToString()
                        Acuenta_venta = rd1("ACuenta").ToString()
                        Devolucion = rd1("Devolucion").ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()

                If Resta_ventas > 0 Then
                    If Resta_ventas >= Total_devo Then
                        MsgBox("La devolución afectará al total restante de la venta, por lo tanto no habrá movimiento de efectivo en caja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        TipoDevolucion = 1
                        SalenDevos = 0
                        Nuevo_resta = Resta_ventas - Total_devo
                        Nuevo_devo = Total_devo + Devolucion

                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Ventas set Resta=" & Nuevo_resta & ", Devolucion=" & Nuevo_devo & " where Folio=" & cbonota.Text
                        cmd1.ExecuteNonQuery()

                        If lblNumCliente.Text <> "MOSTRADOR" Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) - Total_devo
                                End If
                            Else
                                MySaldo = 0
                            End If
                            rd1.Close()

                            If MySaldo < 0 Then
                                MySaldo = 0
                            End If

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & "," & lblNumCliente.Text & ",'" & cboNombre.Text & "','DEVOLUCION','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & Total_devo & "," & (MySaldo + Total_devo) & ",0,0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                            cmd1.ExecuteNonQuery()

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & "," & lblNumCliente.Text & ",'" & cboNombre.Text & "','CARGO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_devo & ",0," & MySaldo & ",0,0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                            cmd1.ExecuteNonQuery()
                        End If

                        If lblNumCliente.Text = "MOSTRADOR" Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & ",0,'" & cboNombre.Text & "','DEVOLUCION','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_devo & ",0," & Total_devo & ",0,0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                            cmd1.ExecuteNonQuery()
                        End If
                        cnn1.Close()
                    End If

                    If Resta_ventas < Total_devo Then
                        Devuelve = Total_devo - Resta_ventas
                        Nuevo_devo = Devolucion + Total_devo
                        Nuevo_resta = 0

                        MsgBox("Saldrán $" & FormatNumber(Devuelve, 2) & " de caja por concepto de devolución.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        TipoDevolucion = 2
                        SalenDevos = Devuelve

                        Nuevo_acuenta = Acuenta_venta - Devuelve

                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Ventas set Resta=" & Nuevo_resta & ", Devolucion=" & Nuevo_devo & ", ACuenta=" & Nuevo_acuenta & " where Folio= " & cbonota.Text
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Ventas set Status='PAGADO' where Folio=" & cbonota.Text
                        cmd1.ExecuteNonQuery()

                        If lblNumCliente.Text <> "MOSTRADOR" Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    MySaldo = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                                End If
                            Else
                                MySaldo = 0
                            End If
                            rd1.Close()

                            If MySaldo < 0 Then
                                MySaldo = 0
                            End If

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & "," & lblNumCliente.Text & ",'" & cboNombre.Text & "','DEVOLUCION','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & Total_devo & "," & MySaldo & "," & Devuelve & ",0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                            cmd1.ExecuteNonQuery()

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & "," & lblNumCliente.Text & ",'" & cboNombre.Text & "','CARGO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_devo & ",0," & (MySaldo - Resta_ventas) & ",0,0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                            cmd1.ExecuteNonQuery()
                        End If

                        If lblNumCliente.Text = "MOSTRADOR" And Devuelve > 0 Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & ",0,'" & cboNombre.Text & "','DEVOLUCION','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_devo & ",0," & (MySaldo - Resta_ventas) & "," & Devuelve & ",0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                            cmd1.ExecuteNonQuery()
                        End If
                        cnn1.Close()
                    End If
                End If

                If Resta_ventas <= 0 Then
                    Nuevo_devo = Devolucion + Total_devo
                    Devuelve = Total_devo - Resta_ventas

                    MsgBox("Saldrán $" & FormatNumber(Total_devo, 2) & " de caja por concepto de devolución.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    TipoDevolucion = 2
                    SalenDevos = Total_devo

                    Nuevo_acuenta = Acuenta_venta - Total_devo

                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Ventas set Devolucion=" & Nuevo_devo & ", ACuenta=" & Nuevo_acuenta & " where Folio=" & cbonota.Text
                    cmd1.ExecuteNonQuery()

                    If lblNumCliente.Text <> "MOSTRADOR" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MySaldo = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                            End If
                        Else
                            MySaldo = 0
                        End If
                        rd1.Close()

                        If MySaldo < 0 Then
                            MySaldo = 0
                        End If

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & "," & lblNumCliente.Text & ",'" & cboNombre.Text & "','DEVOLUCION','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & Total_devo & "," & MySaldo & "," & Total_devo & ",0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & "," & lblNumCliente.Text & ",'" & cboNombre.Text & "','CARGO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_devo & ",0," & MySaldo & ",0,0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                        cmd1.ExecuteNonQuery()
                    End If

                    If lblNumCliente.Text = "MOSTRADOR" And Devuelve > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF) values(" & cbonota.Text & ",0,'" & cboNombre.Text & "','DEVOLUCION','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_devo & ",0," & MySaldo & "," & Total_devo & ",0,0,0,0,'','','" & lblusuario.Text & "',0,0,0,0)"
                        cmd1.ExecuteNonQuery()
                    End If
                    cnn1.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                Exit Sub
            End Try

            'Cálculos con los productos de que se están devolviendo (For)
            Dim TotDes As Double = 0

            For mahina As Integer = 0 To grdcaptura.Rows.Count - 1
                Dim CODx As String = grdcaptura.Rows(mahina).Cells(0).Value.ToString()
                Dim CANTx As Double = grdcaptura.Rows(mahina).Cells(3).Value.ToString()
                Totalx = grdcaptura.Rows(mahina).Cells(6).Value.ToString()
                Dim DescuentoUni As Double = DESuni(cbonota.Text, CODx)
                Dim TotalCantBase As Double = TotCantBase(cbonota.Text, CODx)
                TotalCantidadProd = TCantProd(cbonota.Text)

                If TotalCantBase >= 1 And TotalCantidadProd >= 1 Then
                    If TotalCantBase <> CANTx Then
                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update VentasDetalle set Cantidad=Cantidad-" & CANTx & ", TotalSinIVA=TotalSinIVA-" & Totalx & ", Descto=Descto-" & (DescuentoUni * CANTx) & ", Total=Total-" & CDbl(grdcaptura.Rows(mahina).Cells(6).Value.ToString) & " where Codigo='" & CODx & "' and Folio=" & cbonota.Text
                        cmd1.ExecuteNonQuery() : cnn1.Close()
                    ElseIf TotalCantBase = CANTx Then
                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from VentasDetalle where Folio=" & cbonota.Text & " and Codigo='" & CODx & "' and Total=" & Totalx & ""
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "delete from VentasDetalle where Id=" & rd1("Id").ToString() & ""
                                cmd2.ExecuteNonQuery()
                                cnn2.Close()
                            End If
                        Else
                            Totalx = FormatNumber(Totalx, 2)
                            cnn2.Close() : cnn2.Open()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select * from VentasDetalle where Folio=" & cbonota.Text & " and Codigo='" & CODx & "' and Total=" & Totalx & ""
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    cnn3.Close() : cnn3.Open()
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText =
                                        "delete from VentasDetalle where Id=" & rd1("Id").ToString() & ""
                                    cmd3.ExecuteNonQuery()
                                    cnn3.Close()
                                End If
                            End If
                            rd2.Close() : cnn2.Close()
                        End If
                        rd1.Close() : cnn1.Close()
                    End If
                End If
                TotDes = TotDes + (DescuentoUni * CANTx)
            Next

            Dim PercentDsct As Double = 0
            Dim Dscto As Double = 0
            Dim TOtmp As Double = 0
            Dim Rtotal As Double = 0
            Dim IVA As Double = 0

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Subtotal, Descuento from Ventas where Folio=" & cbonota.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Dscto = rd1(1).ToString()
                    If Dscto > 0 Then
                        TOtmp = 0
                        PercentDsct = 0
                        Dscto = 0
                        TOtmp = CDbl(rd1("Subtotal").ToString()) + CDbl(rd1("Descuento").ToString())
                        PercentDsct = CDbl(rd1("Descuento").ToString()) / TOtmp
                    End If
                End If
            End If
            rd1.Close()

            Dim MyCostVUE As Double = 0
            Dim MyProm As Double = 0

            For beatriz_pinzon_solano As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(beatriz_pinzon_solano).Cells(0).Value.ToString() = "" Then
                    GoTo ecomoda
                End If
                Dim mycode As String = grdcaptura.Rows(beatriz_pinzon_solano).Cells(0).Value.ToString()
                Dim MyDesc As String = grdcaptura.Rows(beatriz_pinzon_solano).Cells(1).Value.ToString()
                Dim MyUVenta As String = grdcaptura.Rows(beatriz_pinzon_solano).Cells(2).Value.ToString()
                Dim Mycant As Double = grdcaptura.Rows(beatriz_pinzon_solano).Cells(3).Value.ToString()
                Dim Myprecio As Double = grdcaptura.Rows(beatriz_pinzon_solano).Cells(4).Value.ToString()
                Dim MyTotal As Double = Myprecio * Mycant
                Dim MyPrecioSin As Double = 0
                Dim MyTotalSin As Double = 0
                Dim MyIVA As Double = 0
                Dim MyMCD As Double = 0
                Dim MyMult2 As Double = 0
                Dim MyDepto As String = ""
                Dim MyGrupo As String = ""

                Dim MyExInv As Double = 0, MyMultiplo As Double = 0
                Dim MyPrecioCompra As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & mycode & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyIVA = rd1("IVA").ToString()
                        MyMCD = rd1("MCD").ToString()
                        MyMult2 = rd1("Multiplo").ToString()
                        MyDepto = rd1("Departamento").ToString()
                        MyGrupo = rd1("Grupo").ToString()
                    End If
                End If
                rd1.Close()

                MyPrecioSin = Myprecio / (1 + MyIVA)
                MyTotalSin = MyTotal / (1 + MyIVA)
                IVA = IVA + MyTotalSin * MyIVA
                Rtotal = Rtotal + MyTotalSin

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyExInv = rd1("Existencia").ToString()
                        MyMultiplo = rd1("Multiplo").ToString()
                        If rd1("Departamento").ToString() <> "SERVICIOS" Then
                            MyPrecioCompra = rd1("PrecioCompra").ToString()
                            MyCostVUE = MyPrecioCompra * (Mycant / MyMCD)
                        End If
                    End If
                End If
                rd1.Close()

ecomoda:
                If grdcaptura.Rows(beatriz_pinzon_solano).Cells(0).Value.ToString() <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Devoluciones(Folio,Codigo,Nombre,Cantidad,UVenta,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Facturado,Depto,Grupo,Cargado,FolioReporte) values(" & cbonota.Text & ",'" & mycode & "','" & MyDesc & "'," & Mycant & ",'" & MyUVenta & "'," & MyCostVUE & "," & Myprecio & "," & MyTotal & "," & MyPrecioSin & "," & MyTotalSin & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','DEVOLUCION','" & MyDepto & "','" & MyGrupo & "',0,0)"
                    cmd1.ExecuteNonQuery()

                    ''****** Configurable
                    'ActualizaPEPS(cbonota.Text, mycode, Mycant)
                End If
                Dim MyExiste As Double = 0
                If MyDepto <> "SERVICIOS" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Kits where Nombre='" & MyDesc & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        cnn2.Close() : cnn2.Open()
                        Do While rd1.Read
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select * from Productos where Codigo='" & Strings.Left(rd1("Codigo").ToString(), 6) & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    MyExInv = rd2("Existencia").ToString()

                                    cnn3.Close() : cnn3.Open()

                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText =
                                        "update Productos set Cargado=0, CargadoInv=0, Existencia=Existencia+" & (Mycant * MyMult2) & " where Codigo='" & Strings.Left(rd2("Codigo").ToString(), 6) & "'"
                                    cmd3.ExecuteNonQuery()

                                    '****** Configurable
                                    ActualizaPEPS(cbonota.Text, mycode, Mycant)

                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText =
                                        "select * from Productos where Codigo='" & Strings.Left(rd2("Codigo").ToString(), 6) & "'"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            MyExiste = rd3("Existencia").ToString()
                                        End If
                                    End If
                                    rd3.Close()

                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText =
                                        "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & rd2("Codigo").ToString() & "','" & rd2("Nombre").ToString() & "','Devolución'," & MyExInv & "," & Mycant & "," & MyExiste & "," & Myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & cbonota.Text & "','','','','','')"
                                    cmd3.ExecuteNonQuery()

                                    cnn3.Close()
                                End If
                            End If
                            rd2.Close()
                        Loop
                        cnn2.Close()
                    Else
                        cnn2.Close() : cnn2.Open()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from  Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                MyExInv = rd2("Existencia").ToString()

                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText =
                                    "update Productos set Cargado=0, CargadoInv=0,Existencia=Existencia+" & (Mycant * MyMult2) & " where Codigo='" & Strings.Left(rd2("Codigo").ToString(), 6) & "'"
                                cmd3.ExecuteNonQuery()

                                '****** Configurable
                                ActualizaPEPS(cbonota.Text, mycode, Mycant)

                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText =
                                    "select Existencia from Productos where Codigo='" & Strings.Left(rd2("Codigo").ToString(), 6) & "'"
                                rd3 = cmd3.ExecuteReader
                                If rd3.HasRows Then
                                    If rd3.Read Then
                                        MyExiste = rd3(0).ToString()
                                    End If
                                End If
                                rd3.Close()

                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText =
                                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & MyDesc & "','Devolución'," & MyExInv & "," & Mycant & "," & MyExiste & "," & Myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & cbonota.Text & "','','','','','')"
                                cmd3.ExecuteNonQuery()
                                cnn3.Close()
                            End If
                        End If
                        rd2.Close() : cnn2.Close()
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()

            Dim MySalen As Double = txtPagar.Text

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Ventas set Descuento=Descuento-" & TotDes & ", Subtotal=Subtotal-" & (MySalen - IVA) & ", IVA=IVA-" & IVA & ", Totales=Totales-" & MySalen & " where Folio=" & cbonota.Text
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            Dim Imprime As Boolean = False
            Dim TPrint As String = ""
            Dim Imprime_En As String = ""
            Dim Impresora As String = ""
            Dim Tamaño As String = ""
            Dim Pasa_Print As Boolean = False

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
                If MsgBox("¿Deseas imprimir la devolución?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Pasa_Print = True
                Else
                    Pasa_Print = False
                End If
            Else
                Pasa_Print = True
            End If

            If (Pasa_Print) Then
                cnn1.Close() : cnn1.Open()

                TPrint = cboimpresion.Text

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
                    MsgBox("No está disponible el formato de PDF para las devolciones.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : btnnuevo.PerformClick() : Exit Sub
                    pDevo80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pDevo80.Print()
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
                                rd1.Close()
                                cnn1.Close()
                                btnnuevo.PerformClick()
                                Exit Sub
                            End If
                            rd2.Close()
                        Else
                            btnnuevo.PerformClick()
                            Exit Sub
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                End If

                If TPrint = "TICKET" Then
                    If Tamaño = "80" Then
                        If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : btnnuevo.PerformClick() : Exit Sub
                        pDevo80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pDevo80.Print()
                    End If
                    If Tamaño = "58" Then
                        pDevo58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pDevo58.Print()
                    End If
                End If
                'If TPrint = "MEDIA CARTA" Then
                '    pDevoMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                '    pDevoMediaCarta.Print()
                'End If
                If TPrint = "CARTA" Then
                    If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : btnnuevo.PerformClick() : Exit Sub
                    pDevoCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pDevoCarta.Print()
                End If
            End If

            btnnuevo.PerformClick()
        Else
            lbldevo.Visible = True
            btndevo.Text = "GUARDAR DEVOLUCIÓN"
            cbonota.Items.Clear()
            cbonota.Visible = True
            cbonota.Focus().Equals(True)
            btnventa.Enabled = False
            Button3.Enabled = False

            txtprecio.ReadOnly = True
        End If
    End Sub



    'Impresión
    Private Sub pVenta80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pVenta80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("N O T A  D E  V E N T A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cboNombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)
                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 110, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                If descuento <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(txtCambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtCambio.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Dim formapago As String = ""
            Dim montopago As Double = 0

            If CDbl(txtMontoP.Text) > 0 Then
                For r As Integer = 0 To grdpago.Rows.Count - 1

                    formapago = grdpago.Rows(r).Cells(0).Value.ToString
                    montopago = grdpago.Rows(r).Cells(3).Value.ToString

                    If montopago > 0 Then
                        e.Graphics.DrawString("Pago con " & formapago & "", fuente_prods, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(montopago, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If

                Next
            End If

            If CDbl(txtResta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtResta.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA  16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If

            Y += 19

            e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            Y += 13.5
            If Mid(Pie, 36, 70) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If
            If Mid(Pie, 71, 105) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pCotiza80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pCotiza80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O T I Z A C I Ó N", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cboNombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descu As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                If descu <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descu, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If

            Y += 19

            'e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            'Y += 13.5
            'If Mid(Pie, 36, 70) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            'If Mid(Pie, 71, 105) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pPedido80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPedido80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_hora As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString(" P E D I D O", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_hora, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_hora, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cboNombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                If descuento <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(txtCambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtCambio.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Dim tarjeta As Double = 0
            Dim transfe As Double = 0
            Dim monedero As Double = 0
            Dim otro As Double = 0
            If CDbl(txtMontoP.Text) > 0 Then
                For r As Integer = 0 To grdpago.Rows.Count - 1
                    Select Case grdpago.Rows(r).Cells(0).Value.ToString
                        Case Is = "TARJETA"
                            tarjeta = tarjeta + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "TRANSFERENCIA"
                            transfe = transfe + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "MONEDERO"
                            monedero = monedero + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "OTRO"
                            otro = otro + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                    End Select
                Next

                If tarjeta > 0 Then
                    e.Graphics.DrawString("Pago con tarjeta(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(tarjeta, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
                If transfe > 0 Then
                    e.Graphics.DrawString("Pago con transfe.(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(transfe, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
                If monedero > 0 Then
                    e.Graphics.DrawString("Pago con monedero(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(monedero, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
                If otro > 0 Then
                    e.Graphics.DrawString("Otros pagos:", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(otro, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If
            If CDbl(txtResta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtResta.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If

            Y += 19

            e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            Y += 13.5
            If Mid(Pie, 36, 70) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If
            If Mid(Pie, 71, 105) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pDevo80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pDevo80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("D E V O L U C I Ó N", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbonota.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cboNombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                'If txtDireccion.Text <> "" Then
                '    e.Graphics.DrawString(Mid(txtDireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                '    Y += 13.5
                '    If Mid(txtDireccion.Text, 36, 70) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                '    If Mid(txtDireccion.Text, 71, 105) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                'End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(Letras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If

            Y += 19

            'e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            'Y += 13.5
            'If Mid(Pie, 36, 70) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            'If Mid(Pie, 71, 105) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pVentaCarta_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVentaCarta.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim Y As Double = 0
        Dim X As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim pagare As String = ""
        Dim clausu(10) As String

        Dim continua_en As String = ""

        Y = 35

        Try
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, 10, 200, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, 30, 220, 110)
                    'e.Graphics.DrawRectangle(pen, 0, 5, 220, 110)
                End If
                X = 230
            Else
                X = 0
            End If

            e.Graphics.DrawString("NOTA DE VENTA", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            e.Graphics.DrawString("FOLIO  " & MYFOLIO, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Red, 700, 0, sf)

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    pagare = rd1("Pagare").ToString()
                    clausu(0) = rd1("C1").ToString()
                    clausu(1) = rd1("C2").ToString()
                    clausu(2) = rd1("C3").ToString()
                    clausu(3) = rd1("C4").ToString()
                    clausu(4) = rd1("C5").ToString()
                    clausu(5) = rd1("C6").ToString()
                    clausu(6) = rd1("C7").ToString()
                    clausu(7) = rd1("C8").ToString()
                    clausu(8) = rd1("C9").ToString()
                    clausu(9) = rd1("C10").ToString()

                    Y += 10
                    e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Red, X, Y)
                    e.Graphics.DrawString("Lo atiende " & lblusuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            If tLogo <> "SIN" Then
                X = 520
            Else
                X = 300
            End If

            If cboNombre.Text <> "" Then
                Y = 35
                e.Graphics.DrawString(cboNombre.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                Y += 16

                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                End If

                If dtpFecha_E.Visible = True Then
                    Y += 20
                    e.Graphics.DrawString("Fecha de entrega:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, X, Y)
                    e.Graphics.DrawString(FormatDateTime(dtpFecha_E.Value, DateFormat.ShortDate), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, (X + 140), Y)
                End If
            End If

            e.Graphics.DrawLine(pen, 1, 160, 840, 160)
            Y = 164
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("UNIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 110, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 220, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 580, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 700, Y, sf)
            e.Graphics.DrawLine(pen, 1, 182, 840, 182)
            Y = 185

            Dim total_prods As Double = 0

            printLine = 0
            Do While printLine = grdcaptura.Rows.Count - 1
                If Y + 20 > 1050 Then
                    e.HasMorePages = True
                    termina = False
                    pagina += 1
                    Exit Do
                Else
                    termina = True
                End If

                If grdcaptura.Rows(printLine).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(printLine).Cells(0).Value.ToString = "" Then
                    Y -= 7
                    e.Graphics.DrawString(grdcaptura.Rows(printLine).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Gray, 220, Y)
                    Y += 21
                    printLine += 1
                    Continue Do
                End If
                Dim codigo As String = grdcaptura.Rows(printLine).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(printLine).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(printLine).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(printLine).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(printLine).Cells(4).Value.ToString()
                Dim descu As Double = grdcaptura.Rows(printLine).Cells(5).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 220, Y)
                Y += 12.5
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 220, Y)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 40, Y, sc)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 145, Y, sc)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 580, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 700, Y, sf)
                Y += 22
                If descu <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descu, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti

                printLine += 1
                Contador += 1
            Loop

            printLine = 0

            If termina = True Then
                Y -= 3
                e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
                Y += 5
                e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 450, Y, sf)
                e.Graphics.DrawString(Letras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 0, Y)

                Dim MySubtotal As Double = 0
                Dim TotalIVAPrint As Double = 0
                Dim TotalIEPS As Double = 0

                cnn1.Close() : cnn1.Open()
                For N As Integer = 0 To grdcaptura.Rows.Count - 1
                    If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                If CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                    MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                    TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                                End If
                                If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                    TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                                End If
                            End If
                        End If
                        rd1.Close()
                    End If
                Next
                cnn1.Close()
                TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
                MySubtotal = FormatNumber(MySubtotal, 4)

                e.Graphics.DrawString("Total:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtPagar.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)

                Y += 13
                Dim y_temp As Double = Y
                If txtcomentario.Text <> "" Then
                    Y += 6
                    e.Graphics.DrawString(Mid(txtcomentario.Text, 1, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                    e.Graphics.DrawString(Mid(txtcomentario.Text, 71, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                End If

                If Pie <> "" Then
                    Y += 7
                    e.Graphics.DrawString(Mid(Pie, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                    If Mid(Pie, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(Pie, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                        Y += 12
                    End If
                    If Mid(Pie, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(Pie, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                        Y += 12
                    End If
                End If

                Y = y_temp
                Y += 2.5
                If CDbl(txtdescuento2.Text) > 0 Then
                    e.Graphics.DrawString("Descuento:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(txtdescuento2.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                    Y += 15.5
                End If
                If CDbl(txtefectivo.Text) > 0 Then
                    e.Graphics.DrawString("Efectivo:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(txtefectivo.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                    Y += 15.5
                End If
                If CDbl(txtCambio.Text) > 0 Then
                    e.Graphics.DrawString("Cambio:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(txtCambio.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                    Y += 15.5
                End If

                Dim tarjeta As Double = 0
                Dim transfe As Double = 0
                Dim monedero As Double = 0
                Dim otro As Double = 0
                If CDbl(txtMontoP.Text) > 0 Then
                    For r As Integer = 0 To grdpago.Rows.Count - 1
                        Select Case grdpago.Rows(r).Cells(0).Value.ToString
                            Case Is = "TARJETA"
                                tarjeta = tarjeta + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                            Case Is = "TRANSFERENCIA"
                                transfe = transfe + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                            Case Is = "MONEDERO"
                                monedero = monedero + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                            Case Is = "OTRO"
                                otro = otro + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        End Select
                    Next

                    If tarjeta > 0 Then
                        e.Graphics.DrawString("Pago con tarjeta(s):", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                        e.Graphics.DrawString(FormatNumber(tarjeta, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                        Y += 15.5
                    End If
                    If transfe > 0 Then
                        e.Graphics.DrawString("Pago con transfe.(s):", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                        e.Graphics.DrawString(FormatNumber(transfe, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                        Y += 15.5
                    End If
                    If monedero > 0 Then
                        e.Graphics.DrawString("Pago con monedero(s):", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                        e.Graphics.DrawString(FormatNumber(monedero, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                        Y += 15.5
                    End If
                    If otro > 0 Then
                        e.Graphics.DrawString("Otros pagos:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                        e.Graphics.DrawString(FormatNumber(otro, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                        Y += 15.5
                    End If
                End If
                If CDbl(txtResta.Text) > 0 Then
                    e.Graphics.DrawString("Resta:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(txtResta.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 700, Y, sf)
                    Y += 15.5
                End If
                Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
                If DesglosaIVA = "1" Then
                    If TotalIVAPrint > 0 Then
                        If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                            Y += 12
                            e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                            e.Graphics.DrawString(FormatNumber(IVA, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                            Y += 15.5
                        End If
                    End If
                    If TotalIEPS > 0 Then
                        e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                        e.Graphics.DrawString(FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                        Y += 15.5
                    End If
                End If

                If pagare <> "" Then
                    Y += 25
                    Dim texto_pagare As String = EliminarSaltosLinea(pagare, " ")
                    e.Graphics.DrawString("PAGARÉ", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Red, 1, Y)
                    Y += 15
                    If Mid(texto_pagare, 1, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 325, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 325, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 433, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 433, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 541, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 541, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 649, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 649, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 757, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 757, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(texto_pagare, 865, 108) <> "" Then
                        e.Graphics.DrawString(Mid(texto_pagare, 865, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 1
                If clausu(0) <> "" Then
                    Y += 25
                    e.Graphics.DrawString("CLAUSULAS", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Red, 1, Y)
                    Y += 15
                    If Mid(clausu(0), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(0), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(0), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(0), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(0), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(0), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 2
                If clausu(1) <> "" Then
                    Y += 10
                    If Mid(clausu(1), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(1), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(1), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(1), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(1), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(1), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 3
                If clausu(2) <> "" Then
                    Y += 10
                    If Mid(clausu(2), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(2), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(2), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(2), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(2), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(2), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 4
                If clausu(3) <> "" Then
                    Y += 10
                    If Mid(clausu(3), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(3), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(3), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(3), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(3), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(3), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 5
                If clausu(4) <> "" Then
                    Y += 10
                    If Mid(clausu(4), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(4), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(4), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(4), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(4), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(4), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 6
                If clausu(5) <> "" Then
                    Y += 10
                    If Mid(clausu(5), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(5), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(5), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(5), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(5), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(5), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 7
                If clausu(6) <> "" Then
                    Y += 10
                    If Mid(clausu(6), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(6), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(6), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(6), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(6), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(6), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 8
                If clausu(7) <> "" Then
                    Y += 10
                    If Mid(clausu(7), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(7), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(7), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(7), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(7), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(7), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 9
                If clausu(8) <> "" Then
                    Y += 10
                    If Mid(clausu(8), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(8), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(8), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(8), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(8), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(8), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                'Clausula 10
                If clausu(9) <> "" Then
                    Y += 10
                    If Mid(clausu(9), 1, 108) <> "" Then
                        e.Graphics.DrawString("- " & Mid(clausu(9), 1, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(9), 109, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(9), 109, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                    If Mid(clausu(9), 217, 108) <> "" Then
                        e.Graphics.DrawString(Mid(clausu(9), 217, 108), fuente_prods, Brushes.Black, 1, Y)
                        Y += 14
                    End If
                End If

                pagina += 1
            Else
                Y -= 3
                e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
                Y += 5
            End If

            e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 417, 1080, sc)
            e.Graphics.DrawString(pagina, New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, 1080, sf)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pCotizaCarta_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCotizaCarta.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim Y As Double = 0
        Dim X As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Y = 35

        Try
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, 10, 200, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, 30, 220, 110)
                    'e.Graphics.DrawRectangle(pen, 0, 5, 220, 110)
                End If
                X = 230
            Else
                X = 0
            End If

            e.Graphics.DrawString("COTIZACION", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            e.Graphics.DrawString("FOLIO  " & lblfolio.Text, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Red, 840, 0, sf)

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    Y += 10
                    e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Red, X, Y)
                    e.Graphics.DrawString("Lo atiende " & lblusuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            'e.Graphics.DrawLine(pen, 510, 20, 510, 100)            

            If tLogo <> "SIN" Then
                X = 520
            Else
                X = 300
            End If

            If cboNombre.Text <> "" Then
                Y = 35
                e.Graphics.DrawString(cboNombre.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                Y += 16

                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                End If
            End If

            e.Graphics.DrawLine(pen, 1, 160, 840, 160)
            Y = 164
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("UNIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 110, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 220, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, Y, sf)
            e.Graphics.DrawLine(pen, 1, 182, 840, 182)
            Y = 185

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 7
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Gray, 220, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descue As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)
                Dim caducidad As String = grdcaptura.Rows(miku).Cells(9).Value.ToString

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 220, Y)
                Y += 12.5
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 220, Y)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 40, Y, sc)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 145, Y, sc)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 830, Y, sf)
                Y += 22
                If descue <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento %" & descue, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
            Y += 5
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 450, Y, sf)
            e.Graphics.DrawString(Letras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 0, Y)

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 580, Y)
            e.Graphics.DrawString(FormatNumber(txtPagar.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)

            Y += 13
            Dim y_temp As Double = Y
            If txtcomentario.Text <> "" Then
                Y += 6
                e.Graphics.DrawString(Mid(txtcomentario.Text, 1, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
                e.Graphics.DrawString(Mid(txtcomentario.Text, 71, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
            End If

            'If Pie <> "" Then
            '    Y += 7
            '    e.Graphics.DrawString(Mid(Pie, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
            '    Y += 12
            '    If Mid(Pie, 36, 70) <> "" Then
            '        e.Graphics.DrawString(Mid(Pie, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
            '        Y += 12
            '    End If
            '    If Mid(Pie, 71, 105) <> "" Then
            '        e.Graphics.DrawString(Mid(Pie, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
            '        Y += 12
            '    End If
            'End If

            Y = y_temp
            Y += 2.5
            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtdescuento2.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                        e.Graphics.DrawString(FormatNumber(IVA, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                        Y += 15.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 15.5
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        e.HasMorePages = False
    End Sub
    Private Sub pPedidoCarta_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPedidoCarta.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim Y As Double = 0
        Dim X As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Y = 35

        Try
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, 10, 200, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, 30, 220, 110)
                    'e.Graphics.DrawRectangle(pen, 0, 5, 220, 110)
                End If
                X = 230
            Else
                X = 0
            End If

            e.Graphics.DrawString("PEDIDO", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            e.Graphics.DrawString("FOLIO  " & lblfolio.Text, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Red, 840, 0, sf)

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    Y += 10
                    e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Red, X, Y)
                    e.Graphics.DrawString("Lo atiende " & lblusuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            'e.Graphics.DrawLine(pen, 510, 20, 510, 100)            

            If tLogo <> "SIN" Then
                X = 520
            Else
                X = 300
            End If

            If cboNombre.Text <> "" Then
                Y = 35
                e.Graphics.DrawString(cboNombre.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                Y += 16

                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                End If

                If dtpFecha_E.Visible = True Then
                    Y += 20
                    e.Graphics.DrawString("Fecha de entrega:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, X, Y)
                    e.Graphics.DrawString(FormatDateTime(dtpFecha_E.Value, DateFormat.ShortDate), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, (X + 140), Y)
                End If
            End If

            e.Graphics.DrawLine(pen, 1, 160, 840, 160)
            Y = 164
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("UNIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 110, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 220, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, Y, sf)
            e.Graphics.DrawLine(pen, 1, 182, 840, 182)
            Y = 185

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 7
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Gray, 220, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 220, Y)
                Y += 12.5
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 220, Y)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 40, Y, sc)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 145, Y, sc)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 830, Y, sf)
                Y += 22
                If descuento <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
            Y += 5
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 450, Y, sf)
            e.Graphics.DrawString(Letras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 0, Y)

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 580, Y)
            e.Graphics.DrawString(FormatNumber(txtPagar.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)

            Y += 13
            Dim y_temp As Double = Y
            If txtcomentario.Text <> "" Then
                Y += 6
                e.Graphics.DrawString(Mid(txtcomentario.Text, 1, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
                e.Graphics.DrawString(Mid(txtcomentario.Text, 71, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
            End If

            If Pie <> "" Then
                Y += 7
                e.Graphics.DrawString(Mid(Pie, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
                If Mid(Pie, 36, 70) <> "" Then
                    e.Graphics.DrawString(Mid(Pie, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                End If
                If Mid(Pie, 71, 105) <> "" Then
                    e.Graphics.DrawString(Mid(Pie, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                End If
            End If

            Y = y_temp
            Y += 2.5
            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtdescuento2.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If
            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtefectivo.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If
            If CDbl(txtCambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtCambio.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If

            Dim tarjeta As Double = 0
            Dim transfe As Double = 0
            Dim monedero As Double = 0
            Dim otro As Double = 0
            If CDbl(txtMontoP.Text) > 0 Then
                For r As Integer = 0 To grdpago.Rows.Count - 1
                    Select Case grdpago.Rows(r).Cells(0).Value.ToString
                        Case Is = "TARJETA"
                            tarjeta = tarjeta + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "TRANSFERENCIA"
                            transfe = transfe + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "MONEDERO"
                            monedero = monedero + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "OTRO"
                            otro = otro + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                    End Select
                Next

                If tarjeta > 0 Then
                    e.Graphics.DrawString("Pago con tarjeta(s):", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(tarjeta, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 15.5
                End If
                If transfe > 0 Then
                    e.Graphics.DrawString("Pago con transfe.(s):", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(transfe, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 15.5
                End If
                If monedero > 0 Then
                    e.Graphics.DrawString("Pago con monedero(s):", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(monedero, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 15.5
                End If
                If otro > 0 Then
                    e.Graphics.DrawString("Otros pagos:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(otro, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 15.5
                End If
            End If
            If CDbl(txtResta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtResta.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If
            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                        e.Graphics.DrawString(FormatNumber(IVA, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                        Y += 15.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 15.5
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        e.HasMorePages = False
    End Sub
    Private Sub pDevoCarta_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pDevoCarta.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim Y As Double = 0
        Dim X As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Y = 35

        Try
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, 10, 200, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, 30, 220, 110)
                    'e.Graphics.DrawRectangle(pen, 0, 5, 220, 110)
                End If
                X = 230
            Else
                X = 0
            End If

            e.Graphics.DrawString("DEVOLUCION", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            e.Graphics.DrawString("FOLIO  " & cbonota.Text, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Red, 840, 0, sf)

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    Y += 10
                    e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Red, X, Y)
                    e.Graphics.DrawString("Lo atiende " & lblusuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            'e.Graphics.DrawLine(pen, 510, 20, 510, 100)            

            If tLogo <> "SIN" Then
                X = 520
            Else
                X = 300
            End If

            If cboNombre.Text <> "" Then
                Y = 35
                e.Graphics.DrawString(cboNombre.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                Y += 16

                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                End If
            End If

            e.Graphics.DrawLine(pen, 1, 160, 840, 160)
            Y = 164
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("UNIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 110, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 220, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, Y, sf)
            e.Graphics.DrawLine(pen, 1, 182, 840, 182)
            Y = 185

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 7
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Gray, 220, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 220, Y)
                Y += 12.5
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 220, Y)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 40, Y, sc)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 145, Y, sc)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 830, Y, sf)
                Y += 22
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
            Y += 5
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 450, Y, sf)
            e.Graphics.DrawString(Letras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 0, Y)

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 580, Y)
            e.Graphics.DrawString(FormatNumber(txtPagar.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)

            Y += 13
            Dim y_temp As Double = Y
            If txtcomentario.Text <> "" Then
                Y += 6
                e.Graphics.DrawString(Mid(txtcomentario.Text, 1, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
                e.Graphics.DrawString(Mid(txtcomentario.Text, 71, 70), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
            End If

            'If Pie <> "" Then
            '    Y += 7
            '    e.Graphics.DrawString(Mid(Pie, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
            '    Y += 12
            '    If Mid(Pie, 36, 70) <> "" Then
            '        e.Graphics.DrawString(Mid(Pie, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
            '        Y += 12
            '    End If
            '    If Mid(Pie, 71, 105) <> "" Then
            '        e.Graphics.DrawString(Mid(Pie, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
            '        Y += 12
            '    End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        e.HasMorePages = False
    End Sub

    Private Sub txtComentarioPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarioPago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuentaRecepcion.Focus().Equals(True)

        End If
    End Sub

    Private Sub txttel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttel.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub pVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVenta58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 6, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("N O T A  D E  V E N T A", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 10

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If Mid(cboNombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)

                e.Graphics.DrawString(Mid(nombre, 1, 25), fuente_prods, Brushes.Black, 33, Y)
                Y += 12
                If Mid(nombre, 26, 50) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 26, 50), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                If Mid(nombre, 51, 76) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 51, 76), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                ' e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 9
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 50, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                If descuento <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 15

            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            If CDbl(txtCambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtCambio.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 10
            End If

            Dim formapagop As String = ""
            Dim montopagop As Double = 0

            If CDbl(txtMontoP.Text) > 0 Then
                For r As Integer = 0 To grdpago.Rows.Count - 1

                    formapagop = grdpago.Rows(r).Cells(0).Value.ToString
                    montopagop = grdpago.Rows(r).Cells(3).Value.ToString

                    If montopagop > 0 Then
                        e.Graphics.DrawString("Pago con " & formapagop & "", fuente_prods, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(montopagop, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                        Y += 12
                    End If

                Next
            End If



            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 10
                        e.Graphics.DrawString("*** IVA  16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                        Y += 12
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
            End If

            '  Y += 3

            e.Graphics.DrawString(Mid(Pie, 1, 24), fuente_prods, Brushes.Black, 90, Y, sc)
            Y += 12
            If Mid(Pie, 25, 48) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 25, 48), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 12
            End If
            If Mid(Pie, 49, 96) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 49, 96), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 12
            End If
            Y += 15
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pCotiza58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCotiza58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 6, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 1
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("C O T I Z A C I Ó N", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 12
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 8

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cboNombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                    If Mid(txtdireccion.Text, 29, 56) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 29, 86), fuente_prods, Brushes.Black, 1, Y)
                        Y += 11
                    End If
                    If Mid(txtdireccion.Text, 57, 84) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 57, 84), fuente_prods, Brushes.Black, 1, Y)
                        Y += 11
                    End If
                End If
                Y += 2
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descu As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 25), fuente_prods, Brushes.Black, 33, Y)
                Y += 12
                If Mid(nombre, 26, 50) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 26, 50), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                If Mid(nombre, 51, 76) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 51, 76), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                'e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 11.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 50, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                If descu <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descu, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 11
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 12

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 12

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 10
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 11
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 11
                End If
            End If

            Y += 8

            'e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            'Y += 13.5
            'If Mid(Pie, 36, 70) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            'If Mid(Pie, 71, 105) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pPedido58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPedido58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
        Dim fuente_hora As New Drawing.Font(tipografia, 6, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 0
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString(" P E D I D O", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 12
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_hora, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_hora, Brushes.Black, 285, Y, sf)
            Y += 10

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If Mid(cboNombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                    If Mid(txtdireccion.Text, 29, 56) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 29, 56), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                    If Mid(txtdireccion.Text, 57, 84) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 57, 84), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                End If
                Y += 5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)

                e.Graphics.DrawString(Mid(nombre, 1, 25), fuente_prods, Brushes.Black, 33, Y)
                Y += 12
                If Mid(nombre, 26, 50) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 26, 50), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                If Mid(nombre, 51, 76) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 51, 76), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                ' e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 50, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                If descuento <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 15

            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            If CDbl(txtCambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtCambio.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            Dim tarjeta As Double = 0
            Dim transfe As Double = 0
            Dim monedero As Double = 0
            Dim otro As Double = 0
            If CDbl(txtMontoP.Text) > 0 Then
                For r As Integer = 0 To grdpago.Rows.Count - 1
                    Select Case grdpago.Rows(r).Cells(0).Value.ToString
                        Case Is = "TARJETA"
                            tarjeta = tarjeta + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "TRANSFERENCIA"
                            transfe = transfe + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "MONEDERO"
                            monedero = monedero + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                        Case Is = "OTRO"
                            otro = otro + CDbl(grdpago.Rows(r).Cells(3).Value.ToString())
                    End Select
                Next

                If tarjeta > 0 Then
                    e.Graphics.DrawString("Pago con tarjeta(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(tarjeta, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                If transfe > 0 Then
                    e.Graphics.DrawString("Pago con transfe.(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(transfe, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                If monedero > 0 Then
                    e.Graphics.DrawString("Pago con monedero(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(monedero, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                If otro > 0 Then
                    e.Graphics.DrawString("Otros pagos:", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(otro, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
            End If
            If CDbl(txtResta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtResta.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                        Y += 12
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
            End If

            Y += 5

            e.Graphics.DrawString(Mid(Pie, 1, 28), fuente_prods, Brushes.Black, 90, Y, sc)
            Y += 12
            If Mid(Pie, 29, 56) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 29, 56), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 12
            End If
            If Mid(Pie, 57, 84) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 57, 84), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 12
            End If
            Y += 15
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pDevo58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pDevo58.PrintPage

        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists("C:\ControlNegociosPro\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile("C:\ControlNegociosPro\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("D E V O L U C I Ó N", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("Folio: " & cbonota.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 12
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 10

            '[2]. Datos del cliente
            If cboNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12

                e.Graphics.DrawString("Nombre: " & Mid(cboNombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13
                If Mid(cboNombre.Text, 28, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cboNombre.Text, 28, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13
                End If
                Y += 3
                'If txtDireccion.Text <> "" Then
                '    e.Graphics.DrawString(Mid(txtDireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                '    Y += 13.5
                '    If Mid(txtDireccion.Text, 36, 70) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                '    If Mid(txtDireccion.Text, 71, 105) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                'End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)

                e.Graphics.DrawString(Mid(nombre, 1, 25), fuente_prods, Brushes.Black, 33, Y)
                Y += 12
                If Mid(nombre, 26, 50) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 26, 50), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                If Mid(nombre, 51, 76) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 51, 76), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                'e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 11.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 50, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(10).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdcaptura.Rows(N).Cells(8).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString(Letras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 15

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                        Y += 12
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
            End If

            'e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            'Y += 13.5
            'If Mid(Pie, 36, 70) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            'If Mid(Pie, 71, 105) <> "" Then
            '    e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
            '    Y += 13.5
            'End If
            Y += 10
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If va_whatsapp = 1 Then
                'Dim numero As String = DatosRecarga("Whatsapp")
                'Dim liga As String = "http://wa.me/" & numero

                'Y += 15
                'Dim entrada As String = liga
                'Dim Gen As New QRCodeGenerator
                'Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                'Dim Code As New qrcode(data)

                'picQR.Image = Code.GetGraphic(200)
                'My.Application.DoEvents()
                'Y += 15
                'e.Graphics.DrawString("Escríbenos por Whatsapp", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                'Y += 15
                'e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 225, 225)
            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try

    End Sub

    Private Sub cboCuentaRecepcion_DropDown(sender As Object, e As EventArgs) Handles cboCuentaRecepcion.DropDown

        Try
            cboCuentaRecepcion.Items.Clear()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboCuentaRecepcion.Items.Add(rd1(0).ToString)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub cboCuentaRecepcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCuentaRecepcion.SelectedValueChanged
        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Banco FROM cuentasbancarias WHERE CuentaBan='" & cboCuentaRecepcion.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cboBancoRecepcion.Text = rd2(0).ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboCuentaRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuentaRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboBancoRecepcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboBancoRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBancoRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpFecha_P.Focus().Equals(True)
        End If
    End Sub
End Class