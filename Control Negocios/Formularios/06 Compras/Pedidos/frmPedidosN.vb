Imports System.IO
Public Class frmPedidosN

    Private Sub frmPedidosN_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cboProveedor.Focus.Equals(True)
    End Sub

    Private Sub cboProveedor_DropDown(sender As Object, e As EventArgs) Handles cboProveedor.DropDown
        Try
            cboProveedor.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT NComercial FROM proveedores WHERE NComercial<>'' ORDER BY NComercial"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboProveedor.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbonombre_DropDown(sender As Object, e As EventArgs) Handles cbonombre.DropDown
        Try
            cbonombre.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Productos WHERE Nombre<>'' AND Length(Codigo)<7 AND Departamento<>'SERVICIOS' order by Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbonombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNumPed.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbonombre.Text <> "" Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,UCompra FROM productos WHERE Nombre='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtcodigo.Text = rd1("Codigo").ToString
                        txtunidad.Text = rd1("UCompra").ToString
                    End If
                End If
                rd1.Close()


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Nombre,Codigo,UCompra FROM productos WHERE CodBarra='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbonombre.Text = rd1(0).ToString
                        txtcodigo.Text = rd1(1).ToString
                        txtunidad.Text = rd1(2).ToString
                    End If
                End If
                rd1.Close()
                txtcodigo.Focus.Equals(True)
            Else
                btnCargar.Focus.Equals(True)
            End If
            cnn1.Close()
        End If
    End Sub

    Private Sub txtcodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcodigo.Text <> "" Then
                Dim valormoneda As Double = 0
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "select tipo_cambio,nombre_moneda from tb_moneda,Productos where Codigo='" & txtcodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblMoneda.Text = rd1("nombre_moneda").ToString()
                            lblValor.Text = rd1("tipo_cambio").ToString()
                            valormoneda = rd1("tipo_cambio").ToString
                            If lblValor.Text = "" Then lblValor.Text = "1"
                        End If
                    Else
                        lblValor.Text = "1.00"
                    End If
                    rd1.Close()

                    If Trim(lblMoneda.Text) <> Trim(cbomoneda.Text) Then
                        MsgBox("No se puede continuar porque el tipo de moneda del pedido no coincide con el tipo de moneda del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If

                    If txtmoneda.Text = "" Then
                        MsgBox("Ingresa el valor de la moneda.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        If txtmoneda.Enabled = True Then
                            txtmoneda.Focus().Equals(True)
                        End If
                        cnn1.Close()
                        Exit Sub
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Nombre,UCompra,PrecioCompra,Existencia FROM productos WHERE Codigo='" & txtcodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cbonombre.Text = rd1("Nombre").ToString
                            txtunidad.Text = rd1("UCompra").ToString
                            lblValor.Text = FormatNumber(CDec(rd1("PrecioCompra").ToString) / valormoneda, 4)
                            txtexistencia.Text = rd1("Existencia").ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                    txtcantidad.Focus.Equals(True)
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If CDbl(txtcantidad.Text) = 0 Then MsgBox("Ingrese una cantidad mayor a 0 para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.SelectAll() : Exit Sub
            If Not IsNumeric(txtcantidad.Text) Then MsgBox("Ingrese una cantidad válida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.SelectAll() : Exit Sub

            UpGrid1()
        End If
    End Sub

    Private Sub UpGrid1()
        Try

            Dim cod As String = ""
            Dim barras As String = ""
            Dim descripcion As String = ""
            Dim unidad As String = ""
            Dim precio As Double = 0
            Dim importe As Double = 0
            Dim iva As Double = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,CodBarra,Nombre,UCompra,PrecioCompra,IVA FROM productos WHERE Codigo='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cod = rd1("Codigo").ToString
                    barras = rd1("CodBarra").ToString
                    descripcion = rd1("Nombre").ToString
                    unidad = rd1("UCompra").ToString
                    iva = rd1("IVA").ToString

                    If (chk_mPrecio.Checked) Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT MIN(PrecioAnt) FROM precios WHERE Codigo='" & cod & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                precio = rd2(0).ToString
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()
                    Else
                        precio = rd1("PrecioCompra").ToString
                    End If


                End If
            End If
            rd1.Close()
            cnn1.Close()
            If iva = 0 Then
                precio = precio
            Else
                precio = precio * CDec(1.16)
            End If
            importe = CDec(txtcantidad.Text) * CDec(precio)

            grdCaptura.Rows.Add(cod,
                                barras,
                                descripcion,
                                unidad,
                                FormatNumber(txtexistencia.Text, 2),
                                FormatNumber(txtcantidad.Text, 2),
                                0,
                                FormatNumber(precio, 2),
                                FormatNumber(importe, 2)
                                )
            lblCantidad.Text = lblCantidad.Text + CDec(txtcantidad.Text)
            lblCantidad.Text = FormatNumber(lblCantidad.Text, 2)

            txtSubtotal.Text = txtSubtotal.Text + CDec(importe)
            txtSubtotal.Text = FormatNumber(txtSubtotal.Text, 2)
            Limpiar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub Limpiar()
        cbonombre.Text = ""
        txtcodigo.Text = ""
        txtunidad.Text = ""
        txtexistencia.Text = ""
        txtcantidad.Text = "1"
        cbonombre.Focus.Equals(True)
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(1).ToString = 1 Then
                            lblusuario.Text = rd1(0).ToString
                        Else
                            MsgBox("El usuario esta inactivo, consulte a su administrador", vbInformation + vbOKOnly, titulocentral)
                            lblusuario.Text = ""
                            txtusuario.Text = ""
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulocentral)
                    lblusuario.Text = ""
                    txtusuario.Text = ""
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

            btnCargar.Focus.Equals(True)
        End If

    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick

        Dim index As Integer = grdCaptura.CurrentRow.Index

        Dim codigo As String = grdCaptura.Rows(index).Cells(0).Value.ToString
        Dim descripciona As String = grdCaptura.Rows(index).Cells(2).Value.ToString
        Dim unidad As String = grdCaptura.Rows(index).Cells(3).Value.ToString
        Dim esxistencia As Double = grdCaptura.Rows(index).Cells(4).Value.ToString
        Dim cantidad As Double = grdCaptura.Rows(index).Cells(5).Value.ToString
        Dim importe As Double = grdCaptura.Rows(index).Cells(8).Value.ToString

        txtcodigo.Text = codigo
        cbonombre.Text = descripciona
        txtunidad.Text = unidad
        txtexistencia.Text = esxistencia
        txtcantidad.Text = cantidad

        lblCantidad.Text = lblCantidad.Text - cantidad
        lblCantidad.Text = FormatNumber(lblCantidad.Text, 2)

        txtSubtotal.Text = txtSubtotal.Text - CDec(importe)
        txtSubtotal.Text = FormatNumber(txtSubtotal.Text, 2)
        grdCaptura.Rows.Remove(grdCaptura.Rows(index))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtSubtotal.Text = "0.00"
        grdCaptura.Rows.Clear()
        txtcodigo.Text = ""
        cbonombre.Text = ""
        txtunidad.Text = ""
        txtexistencia.Text = ""
        txtcantidad.Text = "1"
        cboProveedor.Text = ""
        lblMoneda.Text = ""
        lblValor.Text = ""
        txtmoneda.Text = "0.00"
        chk_mPrecio.Checked = False
        txtNumPed.Text = ""
        dtpFpedido.Value = Date.Now
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        If lblusuario.Text = "" Then MsgBox("Favor de ingresar la contraseña", vbInformation + vbOKOnly, titulocentral) : txtusuario.Focus.Equals(True) : Exit Sub
        If grdCaptura.Rows.Count < 1 Then MsgBox("Necesita agregar información para el pedido", vbInformation + vbOKOnly, titulocentral) : Exit Sub
        If txtNumPed.Text = "" Then MsgBox("Favor de ingresar el número de pedido", vbInformation + vbOKOnly, titulocentral) : txtNumPed.Focus.Equals(True) : Exit Sub

        Dim SUBTOTAL As Double = 0

        If MsgBox("Desea guardar la información del pedido", vbInformation + vbYesNo) = vbYes Then

            If cboProveedor.Text <> "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Id FROM pedidos WHERE Id=" & lblFolio.Text
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    SUBTOTAL = txtSubtotal.Text
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO pedidos(Num,Proveedor,Total,Anticipo,Fecha,Hora,Status,Usuario,Cargado,TipoPago,Banco,Referencia) VALUES('" & txtNumPed.Text & "','" & cboProveedor.Text & "'," & SUBTOTAL & ",0,'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "',0,'" & lblusuario.Text & "',0,'','','')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()


                cnn2.Close() : cnn2.Open()

                For LUFFY As Integer = 0 To grdCaptura.Rows.Count - 1
                    Dim cod As String = grdCaptura.Rows(LUFFY).Cells(0).Value.ToString
                    Dim descripcion As String = grdCaptura.Rows(LUFFY).Cells(2).Value.ToString
                    Dim unidad As String = grdCaptura.Rows(LUFFY).Cells(3).Value.ToString
                    Dim cantidad As Double = grdCaptura.Rows(LUFFY).Cells(5).Value.ToString
                    Dim precio As Double = grdCaptura.Rows(LUFFY).Cells(7).Value.ToString
                    Dim total As Double = grdCaptura.Rows(LUFFY).Cells(8).Value.ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO pedidosdet(NumPed,Proveedor,Codigo,Nombre,Unidad,Precio,Cantidad,Cargado) VALUES('" & txtNumPed.Text & "','" & cboProveedor.Text & "','" & cod & "','" & descripcion & "','" & unidad & "'," & precio & "," & cantidad & ",0)"

                    cmd2.ExecuteNonQuery()
                Next
                MsgBox("Pedido cargado correctamente", vbInformation + vbOKOnly, titulocentral)
                cnn2.Close()

            End If

            Dim tamticket As Integer = 0
            Dim impresora As String = ""
            Dim preguntarimprimir As Integer = 0
            Dim formato As String = ""

            tamticket = TamImpre()
            impresora = ImpresoraImprimir()
            preguntarimprimir = PreguntaImprime()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Formato FROM rutasimpresion WHERE Equipo='" & ObtenerNombreEquipo() & "' AND Tipo='Venta'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    formato = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If preguntarimprimir = 1 Then
                If MsgBox("¿Desea imprimir el ticket?", vbInformation + vbYesNo) = vbYes Then

                End If
            Else
                If formato = "TICKET" Then
                    If tamticket = 80 Then
                        pPedidos80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        pPedidos80.Print()
                    End If

                    If tamticket = 58 Then
                        pPedidos58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        pPedidos58.Print()
                    End If
                End If
            End If
            My.Application.DoEvents()
            Button1.PerformClick()
        End If
    End Sub

    Private Sub frmPedidosN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFolio.Start()
    End Sub

    Public Sub Folio()
        TFolio.Stop()

        cnntimer.Close() : cnntimer.Open()
        cmdtimer = cnntimer.CreateCommand
        cmdtimer.CommandText = "SELECT MAX(Id) FROM pedidos"
        rdtimer = cmdtimer.ExecuteReader
        If rdtimer.HasRows Then
            If rdtimer.Read Then
                lblFolio.Text = IIf(rdtimer(0).ToString = "", 0, rdtimer(0).ToString) + 1
            Else
                lblFolio.Text = "1"
            End If
        Else
            lblFolio.Text = "1"
        End If
        rdtimer.Close()
        cnntimer.Close()

        TFolio.Start()
    End Sub

    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick
        Folio()
    End Sub

    Private Sub txtNumPed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumPed.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbonombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub pPedidos80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPedidos80.PrintPage

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

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 153
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 250, 150)
                        Y += 153
                    End If
                End If
            Else
                Y = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

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
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("P E D I D O", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & txtNumPed.Text, fuente_datos, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 270, Y, sf)
            Y += 17

            If cboProveedor.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("P R O V E E D O R", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboProveedor.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 15
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 195, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1
                Dim codigo As String = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                Dim descr As String = grdCaptura.Rows(luffy).Cells(2).Value.ToString
                Dim unidad As String = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                Dim cant As Double = grdCaptura.Rows(luffy).Cells(5).Value.ToString
                Dim precio As Double = grdCaptura.Rows(luffy).Cells(7).Value.ToString
                Dim total As Double = grdCaptura.Rows(luffy).Cells(8).Value.ToString

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(descr, 1, 48), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(cant, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 110, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 193, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 280, Y, sf)
                Y += 15

                total_prods = total_prods + cant
            Next

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSubtotal.Text, 2), fuente_prods, Brushes.Black, 280, Y, sf)
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 137, Y, sc)
            Y += 20

            cnn1.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub pPedidos58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pPedidos58.PrintPage
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

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 153
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 110, 110)
                        Y += 153
                    End If
                End If
            Else
                Y = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("P E D I D O", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & txtNumPed.Text, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 17

            If cboProveedor.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("P R O V E E D O R", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboProveedor.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 15
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 150, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1
                Dim codigo As String = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                Dim descr As String = grdCaptura.Rows(luffy).Cells(2).Value.ToString
                Dim unidad As String = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                Dim cant As Double = grdCaptura.Rows(luffy).Cells(5).Value.ToString
                Dim precio As Double = grdCaptura.Rows(luffy).Cells(7).Value.ToString
                Dim total As Double = grdCaptura.Rows(luffy).Cells(8).Value.ToString

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(descr, 1, 48), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(cant, fuente_prods, Brushes.Black, 45, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 50, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 90, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 133, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 15

                total_prods = total_prods + cant
            Next

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSubtotal.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)
            Y += 20

            cnn1.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class
