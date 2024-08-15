Imports System.IO
Public Class frmEntregaPedidos

    Dim id_cliente As Integer = 0
    Dim unidadsel As String = ""

    Dim totalxd As Double = 0
    Dim nLogo As String = ""
    Dim tLogo As String = ""
    Dim simbolo As String = ""
    Private Sub frmEntregaPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        nLogo = DatosRecarga("LogoG")
        tLogo = DatosRecarga("TipoLogo")
        simbolo = DatosRecarga("Simbolo")

        buscaFolio()
    End Sub
    Public Sub buscaFolio()
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Max(Folio) from Pedidosven"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = "" Then
                        lblFol.Text = 1
                    Else
                        lblFol.Text = rd1(0).ToString + CDec(1)
                    End If
                Else
                    lblFol.Text = 1
                End If
            Else
                lblFol.Text = 1
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboProveedor_DropDown(sender As Object, e As EventArgs) Handles cboProveedor.DropDown
        Try
            cboProveedor.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Proveedor FROM pedidos WHERE Proveedor<>'' ORDER BY Proveedor"
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

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboFolio_DropDown(sender As Object, e As EventArgs) Handles cboFolio.DropDown
        Try
            cboFolio.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If cboProveedor.Text = "" Then
                cmd5.CommandText = "SELECT DISTINCT Num FROM pedidos WHERE Num<>'' ORDER BY Num"
            Else
                cmd5.CommandText = "SELECT DISTINCT Num FROM pedidos WHERE Proveedor='" & cboProveedor.Text & "' AND Num<>'' ORDER BY Num"
            End If


            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboFolio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cboProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboFolio.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboFolio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            grdCaptura.Rows.Clear()
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Proveedor,Codigo,Nombre,Unidad,Precio,Cantidad,CantidadE FROM pedidosdet WHERE NumPed='" & cboFolio.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    If cboProveedor.Text = "" Then
                        cboProveedor.Text = rd1("proveedor").ToString
                    End If

                    Dim importe As Double = 0
                    importe = CDec(rd1("Cantidad").ToString) * CDec(rd1("Precio").ToString)

                    grdCaptura.Rows.Add(rd1("Codigo").ToString,
                                        rd1("Nombre").ToString,
                                        rd1("Unidad").ToString,
                                       FormatNumber(rd1("Cantidad").ToString, 2),
                                       FormatNumber(rd1("Cantidad").ToString, 2) - CDec(FormatNumber(rd1("CantidadE").ToString, 2)),
                                       FormatNumber(rd1("CantidadE").ToString, 2),
                                        FormatNumber(rd1("Precio").ToString, 2),
                                        FormatNumber(importe, 2)
)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

            cboCliente.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

        End If
    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFolio.SelectedValueChanged
        cboFolio_KeyPress(cboFolio, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub cboCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id,Calle,NInterior,NExterior,Colonia,Delegacion,Entidad,Pais,CP FROM CLientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_cliente = rd1("Id").ToString

                    Dim dire(9) As String
                    Dim direccion As String = ""

                    dire(0) = rd1("Calle").ToString()       'Calle
                    dire(1) = rd1("NInterior").ToString()   'Numero Int
                    dire(2) = rd1("NExterior").ToString()   'Numero Ext
                    dire(3) = rd1("Colonia").ToString()     'Colonia
                    dire(4) = rd1("Delegacion").ToString()  'Delegacion
                    dire(5) = rd1("Entidad").ToString()     'Entidad
                    dire(6) = rd1("Pais").ToString()        'Pais
                    dire(7) = rd1("CP").ToString()          'CP


                    'Calle
                    If Trim(dire(0)) <> "" Then
                        direccion = direccion & dire(0) & " "
                    End If
                    'Numero Int
                    If Trim(dire(1)) <> "" Then
                        direccion = direccion & dire(1) & " "
                    End If
                    'Numero Ext
                    If Trim(dire(2)) <> "" Then
                        direccion = direccion & dire(2) & " "
                    End If
                    'Colonia
                    If Trim(dire(3)) <> "" Then
                        direccion = direccion & dire(3) & " "
                    End If
                    'Delegacion
                    If Trim(dire(4)) <> "" Then
                        direccion = direccion & dire(4) & " "
                    End If
                    'Entidad
                    If Trim(dire(5)) <> "" Then
                        direccion = direccion & dire(5) & " "
                    End If
                    'Pais
                    If Trim(dire(6)) <> "" Then
                        direccion = direccion & dire(6) & " "
                    End If
                    'CP
                    If Trim(dire(7)) <> "" Then
                        direccion = direccion & "CP " & dire(7) & " "
                    End If

                    txtdireccion.Text = ""
                    txtdireccion.Text = direccion

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Public Sub recargaDatos()
        Try
            grdCaptura.Rows.Clear()
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Proveedor,Codigo,Nombre,Unidad,Precio,Cantidad,CantidadE FROM pedidosdet WHERE NumPed='" & cboFolio.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    If cboProveedor.Text = "" Then
                        cboProveedor.Text = rd1("proveedor").ToString
                    End If

                    Dim importe As Double = 0
                    importe = CDec(rd1("Cantidad").ToString) * CDec(rd1("Precio").ToString)

                    grdCaptura.Rows.Add(rd1("Codigo").ToString,
                                        rd1("Nombre").ToString,
                                        rd1("Unidad").ToString,
                                       FormatNumber(rd1("Cantidad").ToString, 2),
                                       FormatNumber(rd1("Cantidad").ToString, 2) - CDec(FormatNumber(rd1("CantidadE").ToString, 2)),
                                       FormatNumber(rd1("CantidadE").ToString, 2),
                                        FormatNumber(rd1("Precio").ToString, 2),
                                        FormatNumber(importe, 2)
)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

            cboCliente.Focus.Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        Try
            totalxd = txtTotal.Text
            Dim subtotal As Double = 0
            Dim iva As Double = 0
            Dim preciosiniva As Double = 0
            Dim totaliva As Double = 0

            Dim depto As String = ""
            Dim grupo As String = ""
            Dim MYIP As String = dameIP2()
            Dim fol As Integer = cboFolio.Text

            Dim total As Double = txtTotal.Text
            If grdPedido.Rows.Count < 1 Then cboCliente.Focused.Equals(True) : Exit Sub
            If lblUsuario.Text = "" Then MsgBox("Ingrese la contraseña", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus.Equals(True) : Exit Sub
            If cboCliente.Text = "" Then
                MsgBox("Selecciona un cliente para poder continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
                cboCliente.Focus.Equals(True)
            End If
            If MsgBox("Se guardara la información, favor de revisar", vbInformation + vbYesNo, "Delsscom Control Negocios Pro") = vbYes Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO pedidosven(NumPedido,IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,Fecha,Hora,Status,Tipo,Formato,FPago,IP) VALUES('" & cboFolio.Text & "'," & id_cliente & ",'" & cboCliente.Text & "','" & txtdireccion.Text & "'," & total & ",0," & total & ",0," & total & ",'" & lblUsuario.Text & "','" & Format(dtpAsignacion.Value, "yyyy-MM-dd") & "','" & Format(dtpinicio.Value, "HH:mm:ss") & "',0,'PEDIDO','TICKET','" & Format(Date.Now, "yyyy-MM-dd") & "','" & MYIP & "')"
                If cmd2.ExecuteNonQuery() Then
                    For juanita As Integer = 0 To grdPedido.Rows.Count - 1
                        Dim cod As String = grdPedido.Rows(juanita).Cells(0).Value.ToString
                        preciosiniva = grdPedido.Rows(juanita).Cells(4).Value
                        totaliva = grdPedido.Rows(juanita).Cells(5).Value
                        cnn2.Close()
                        cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "Select Departamento,Grupo from Productos where Codigo='" & cod & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.Read Then
                            depto = rd2("Departamento").ToString
                            grupo = rd2("Grupo").ToString
                        End If
                        rd2.Close()

                        Dim soymax As Integer = 0
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "Select Max(Folio) from Pedidosven"
                        rd2 = cmd2.ExecuteReader
                        If rd2.Read Then
                            soymax = rd2(0).ToString
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "Insert into pedidosvendet(Folio,Codigo,Nombre,Unidad,Cantidad,Precio,Total,PrecioSIVA,TotalSIVA,Fecha,Usuario,Depto,Grupo,Tipo) values(" & soymax & ",'" & grdPedido.Rows(juanita).Cells(0).Value.ToString & "','" & grdPedido.Rows(juanita).Cells(1).Value.ToString & "','" & grdPedido.Rows(juanita).Cells(2).Value.ToString & "'," & grdPedido.Rows(juanita).Cells(3).Value & "," & preciosiniva & "," & totaliva & "," & preciosiniva & "," & totaliva & ",'" & Format(dtpAsignacion.Value, "yyyy-MM-dd HH:mm:ss") & "','" & lblUsuario.Text & "','" & depto & "','" & grupo & "','PEDIDO')"
                        If cmd2.ExecuteNonQuery Then
                            Dim cantxd As Double = grdPedido.Rows(juanita).Cells(3).Value
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "Update pedidosdet set CantidadE=CantidadE+" & cantxd & " where NumPed='" & cboFolio.Text & "' and Codigo='" & cod & "' and Nombre='" & grdPedido.Rows(juanita).Cells(1).Value.ToString & "'"
                            If cmd2.ExecuteNonQuery Then
                                Dim MySaldo As Double = 0
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & cboCliente.Text & "')"
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    If rd2.Read Then
                                        MySaldo = CDbl(IIf(rd2(0).ToString = "", 0, rd2(0).ToString)) + CDbl(txtTotal.Text)
                                    End If
                                Else
                                    MySaldo = txtTotal.Text
                                End If
                                rd2.Close()

                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & soymax & "," & id_cliente & ",'" & IIf(cboCliente.Text = "", "PUBLICO EN GENERAL", cboCliente.Text) & "','PEDIDO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & total & ",0," & MySaldo & ",'','PEDIDO-" & cboFolio.Text & "','" & lblUsuario.Text & "',0,'')"
                                If cmd2.ExecuteNonQuery() Then
                                Else
                                End If
                            Else
                            End If
                        Else
                        End If
                        cnn2.Close()
                    Next
                    cnn1.Close()
                    MsgBox("Pedido realizado correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Else
                    cnn2.Close()
                    MsgBox("Error al guardar el pedido", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
                ' End If
                rd1.Close()
                cnn1.Close()
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

                    'If tamticket = 58 Then
                    '    pPedidos58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    '    pPedidos58.Print()
                    'End If
                End If
            End If
            My.Application.DoEvents()

            limpiaXD()
            recargaDatos()
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Public Sub limpiaXD()
        grdPedido.Rows.Clear()
        txtSubtotal.Text = "0.00"
        txtTotal.Text = "0.00"
        cboCliente.Text = ""
        txtdireccion.Text = ""
        buscaFolio()
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim fila As Integer = grdCaptura.CurrentRow.Index

        If celda.ColumnIndex = 4 Then
            If grdCaptura.CurrentRow.Cells(4).Value.ToString = "0" Then
                MsgBox("Ya se entrego completamente el producto seleccionado", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If
            boxcantidad.Visible = True
            txtcantidad.Focus().Equals(True)
            txtcantidad.Tag = grdCaptura.CurrentRow.Cells(4).Value.ToString
            txtcodigo.Text = grdCaptura.CurrentRow.Cells(0).Value.ToString
            txtcodigo.Tag = fila
            txtnombre.Text = grdCaptura.CurrentRow.Cells(1).Value.ToString
            unidadsel = grdCaptura.CurrentRow.Cells(2).Value.ToString
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If txtcantidad.Text = "" Or txtcantidad.Text = "0" Then
                boxcantidad.Visible = False
                Exit Sub
            End If

            Dim inicial As Double = txtcantidad.Tag
            Dim final As Double = 0
            Dim actual As Double = 0
            Dim tot As Double = 0

            Dim precio As Double = 0

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select PrecioVentaIVa from Productos where Codigo='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                precio = rd1(0).ToString
            End If
            rd1.Close()
            cnn1.Close()


            Dim total As Double = CDbl(precio) * CDbl(txtcantidad.Text)

            actual = txtcantidad.Text

            If actual > inicial Then MsgBox("No puedes entregar una cantidad mayor a la que está pendiente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.SelectAll() : Exit Sub
            final = inicial - actual

            grdPedido.Rows.Add(txtcodigo.Text, txtnombre.Text, unidadsel, actual, FormatNumber(precio, 2), FormatNumber(total, 2))
            My.Application.DoEvents()

            grdCaptura.Rows(txtcodigo.Tag).Cells(4).Value = final
            tot = CDec(txtcantidad.Text * grdCaptura.Rows(txtcodigo.Tag).Cells(6).Value)
            FormatNumber(grdCaptura.Rows(txtcodigo.Tag).Cells(7).Value = tot, 2)

            txtcantidad.Text = ""
            txtcantidad.Tag = ""
            txtcodigo.Text = ""
            txtcodigo.Tag = ""
            txtnombre.Text = ""
            unidadsel = ""
            boxcantidad.Visible = False

            Dim totas As Double = 0
            For ty As Integer = 0 To grdPedido.Rows.Count - 1
                totas = totas + CDbl(grdPedido.Rows(ty).Cells(5).Value.ToString())
            Next
            txtTotal.Text = totas
            txtTotal.Text = FormatNumber(txtTotal.Text, 2)
            txtSubtotal.Text = FormatNumber(txtTotal.Text, 2)

        End If
    End Sub

    Private Sub grdPedido_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPedido.CellDoubleClick

        If grdPedido.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim fila As Integer = grdPedido.CurrentRow.Index

        Dim cod As String = grdPedido.Rows(fila).Cells(0).Value.ToString

        For deku As Integer = 0 To grdCaptura.Rows.Count - 1

            If cod = grdCaptura.Rows(deku).Cells(0).Value.ToString Then

                Dim cantidad As Double = grdPedido.CurrentRow.Cells(3).Value.ToString
                Dim total As Double = grdPedido.CurrentRow.Cells(5).Value.ToString

                grdCaptura.Rows(deku).Cells(4).Value = grdCaptura.Rows(deku).Cells(4).Value + cantidad
                My.Application.DoEvents()
                grdCaptura.Rows(deku).Cells(4).Value = FormatNumber(grdCaptura.Rows(deku).Cells(4).Value, 2)

                'grdCaptura.Rows(deku).Cells(5).Value = grdCaptura.Rows(deku).Cells(5).Value + total
                'grdCaptura.Rows(deku).Cells(5).Value = FormatNumber(grdCaptura.Rows(deku).Cells(5).Value, 2)
            End If

        Next
        grdPedido.Rows.Remove(grdPedido.Rows(fila))
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    lblUsuario.Text = rd1(0).ToString
                Else
                    MsgBox("Contraseña Incorrecta, Revisa la información", vbExclamation + vbOKOnly, "Delsscom Control Negocios Pro")
                    lblUsuario.Text = ""
                    txtcontraseña.Text = ""
                    txtcontraseña.Focus.Equals(True)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        limpiaXD()
        grdCaptura.Rows.Clear()
        txtcontraseña.Text = ""
        lblUsuario.Text = ""
        cboProveedor.Text = ""
        cboFolio.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmDetalleEntregado.Show()
        frmDetalleEntregado.BringToFront()
        If cboFolio.Text = "" Then
            frmDetalleEntregado.lblProveedor.Text = "Todos los Proveedores"
            frmDetalleEntregado.lblFolio.Text = "Todos los Pedidos"
        Else
            frmDetalleEntregado.lblProveedor.Text = cboProveedor.Text
            frmDetalleEntregado.lblFolio.Text = cboFolio.Text
            frmDetalleEntregado.lblFecha.Text = FormatDateTime(dtpAsignacion.Value, DateFormat.ShortDate)
        End If
        Me.Enabled = False
        My.Application.DoEvents()
    End Sub

    Private Sub grdCaptura_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellEndEdit

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
        Dim Logotipo As Drawing.Image = Nothing


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
                "select Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
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

            e.Graphics.DrawString("Folio: " & lblFol.Text, fuente_datos, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 270, Y, sf)
            Y += 17

            If cboCliente.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboCliente.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
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

            For luffy As Integer = 0 To grdPedido.Rows.Count - 1
                Dim codigo As String = grdPedido.Rows(luffy).Cells(0).Value.ToString
                Dim descr As String = grdPedido.Rows(luffy).Cells(1).Value.ToString
                Dim unidad As String = grdPedido.Rows(luffy).Cells(2).Value.ToString
                Dim cant As Double = grdPedido.Rows(luffy).Cells(3).Value.ToString
                Dim precio As Double = grdPedido.Rows(luffy).Cells(4).Value.ToString
                Dim total As Double = grdPedido.Rows(luffy).Cells(5).Value.ToString

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
            e.Graphics.DrawString(simbolo & FormatNumber(totalxd, 2), fuente_prods, Brushes.Black, 280, Y, sf)
            Y += 18
            e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(totalxd, 2), fuente_prods, Brushes.Black, 280, Y, sf)
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblUsuario.Text, fuente_prods, Brushes.Black, 137, Y, sc)
            Y += 20

            cnn1.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class