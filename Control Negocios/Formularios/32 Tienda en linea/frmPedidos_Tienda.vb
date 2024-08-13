Imports System.IO
Imports System.Net
Imports System.Web.Services
Imports Gma.QrCodeNet.Encoding.Windows.Forms
Public Class frmPedidos_Tienda

    Public Viene_De As String = ""
    Dim donde_va As String = ""
    Public cadenafact As String = ""
    Dim MYFOLIO As Integer = 0

    Private Sub frmPedidos_Tienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        donde_va = ""
        opt_pendientes.Checked = True
    End Sub

    Private Sub cbonombre_DropDown(sender As Object, e As EventArgs) Handles cbonombre.DropDown
        Limpiar_datos()
        cbonombre.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            If (opt_entregados.Checked) Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select distinct Cliente from Pedidos_Tienda where Status=1 order by Cliente"
            End If

            If (opt_pendientes.Checked) Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select distinct Cliente from Pedidos_Tienda where Status=0 order by Cliente"
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbonombre.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofolio_DropDown(sender As Object, e As EventArgs) Handles cbofolio.DropDown
        Limpiar_datos()
        cbofolio.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            If (opt_entregados.Checked) Then
                If cbonombre.Text = "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id_Orden from Pedidos_Tienda where Status=1 order by Id_Orden"
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id_Orden from Pedidos_Tienda where Cliente='" & cbonombre.Text & "' and Status=1 order by Id_Orden"
                End If
            End If

            If (opt_pendientes.Checked) Then
                If cbonombre.Text = "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id_Orden from Pedidos_Tienda where Status=0 order by Id_Orden"
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id_Orden from Pedidos_Tienda where Cliente='" & cbonombre.Text & "' and Status=0 order by Id_Orden"
                End If
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbofolio.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofolio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cbofolio_SelectedValueChanged(cbofolio, New EventArgs())
        End If
    End Sub

    Private Function Dame_Pago(ByVal id_estado As Integer) As String
        Dim pago As String = ""

        If id_estado = 1 Then
            pago = "Pago por cheque pendiente"
        End If
        If id_estado = 2 Then
            pago = "Pago aceptado"
        End If
        If id_estado = 3 Then
            pago = "Preparación en curso"
        End If
        If id_estado = 4 Then
            pago = "Enviado"
        End If
        If id_estado = 5 Then
            pago = "Entregado"
        End If
        If id_estado = 6 Then
            pago = "Cancelado"
        End If
        If id_estado = 7 Then
            pago = "Reembolso"
        End If
        If id_estado = 8 Then
            pago = "Error en pago"
        End If
        If id_estado = 9 Then
            pago = "Bajo pedido (pagado)"
        End If
        If id_estado = 10 Then
            pago = "En espera de pago por transferencia bancaria"
        End If
        If id_estado = 11 Then
            pago = "Pago remoto aceptado"
        End If
        If id_estado = 12 Then
            pago = "Bajo pedido (no pagado)"
        End If
        If id_estado = 13 Then
            pago = "En espera de validación por pago contra entrega"
        End If
        If id_estado = 14 Then
            pago = "Awaiting for PayPayl payment"
        End If
        If id_estado = 15 Then
            pago = "Transacción en Proceso"
        End If
        If id_estado = 16 Then
            pago = "Transacción Terminada"
        End If
        If id_estado = 17 Then
            pago = "Transacción Cancelada"
        End If
        If id_estado = 18 Then
            pago = "Transacción Rechazada"
        End If
        If id_estado = 19 Then
            pago = "Transacción Reembolsada"
        End If
        If id_estado = 20 Then
            pago = "Transacción Chargedback"
        End If
        If id_estado = 21 Then
            pago = "Transacción en la Mediación"
        End If
        If id_estado = 22 Then
            pago = "Transacción Pendiente"
        End If
        If id_estado = 23 Then
            pago = "Transacción Autorizada"
        End If
        If id_estado = 24 Then
            pago = "Transacción en Posible Fraude"
        End If
        If id_estado = 25 Then
            pago = "Waiting for payment"
        End If
        If id_estado = 26 Then
            pago = "Partial refund"
        End If
        If id_estado = 27 Then
            pago = "Partial payment"
        End If
        If id_estado = 28 Then
            pago = "Authorized. To be captured by merchant"
        End If

        Return pago
    End Function

    Private Sub cbofolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofolio.SelectedValueChanged
        Dim id_cliente_t As Integer = 0
        Dim tipo_envio As Integer = 0

        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtdireccion.Text = ""
        txt_referencia.Text = ""
        txt_metodo_pago.Text = ""
        lbltipo_envio.Text = ""
        lblNumCliente.Text = ""
        grdcaptura.Rows.Clear()
        txt_subtotal.Text = "0.00"
        txt_envio.Text = "0.00"
        txt_total.Text = "0.00"
        txtacuenta.Text = "0.00"
        txt_resta.Text = "0.00"

        Try
            cnn2.Close() : cnn2.Open()

            'Obtiene datos base
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Cliente,Direccion,Id_Cliente,Referencia,Tipo_Pago,Estado_Pago,Tipo_Envio,Status from Pedidos_Tienda where Id_Orden=" & cbofolio.Text
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cbonombre.Text = rd2("Cliente").ToString()
                    txtdireccion.Text = rd2("Direccion").ToString()

                    id_cliente_t = rd2("Id_Cliente").ToString()

                    lblNumCliente.Text = get_id_cliente(id_cliente_t)

                    txt_referencia.Text = rd2("Referencia").ToString()
                    txt_metodo_pago.Text = rd2("Tipo_Pago").ToString()
                    lblt_pago.Text = rd2("Estado_Pago").ToString()

                    tipo_envio = rd2("Tipo_Envio").ToString()

                    If tipo_envio = 9 Then
                        lbltipo_envio.Text = "Envío a domicilio"
                    ElseIf tipo_envio = 7 Then
                        lbltipo_envio.Text = "Recoge en tienda"
                    Else
                        lbltipo_envio.Text = ""
                        lbltipo_envio.Visible = False
                    End If

                    If rd2("Status").ToString() = 1 Then
                        btn_produccion.Visible = False
                        btn_entregado.Visible = False
                    End If
                End If
            End If
            rd2.Close()

            Dim cod_prod As String = ""
            Dim nom_prod As String = ""
            Dim can_prod As Double = 0
            Dim pre_prod As Double = 0
            Dim com_prod As String = ""

            Dim uni_prod As String = ""
            Dim tot_prod As Double = 0
            Dim exi_prod As Double = 0

            Dim nuevoprecio As Double = 0

            'Obtiene datos de los productos
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Codigo,Cantidad,Precio,Comentario from Det_Pedidos_Tienda where Id_Orden=" & cbofolio.Text
            rd2 = cmd2.ExecuteReader

            cnn3.Close() : cnn3.Open()

            Do While rd2.Read
                If rd2.HasRows Then
                    cod_prod = rd2("Codigo").ToString()
                    can_prod = rd2("Cantidad").ToString()
                    pre_prod = rd2("Precio").ToString()
                    com_prod = rd2("Comentario").ToString()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select Nombre,UVenta,Existencia from Productos where Codigo='" & cod_prod & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            nom_prod = rd3("Nombre").ToString()
                            uni_prod = rd3("UVenta").ToString()
                            exi_prod = rd3("Existencia").ToString()
                        End If
                    End If
                    rd3.Close()

                    nuevoprecio = CDec(pre_prod) * 1.16
                    'tot_prod = can_prod * pre_prod
                    tot_prod = can_prod * nuevoprecio

                    grdcaptura.Rows.Add(cod_prod, nom_prod, uni_prod, can_prod, FormatNumber(nuevoprecio, 4), FormatNumber(tot_prod, 4), exi_prod)
                    If com_prod <> "" Then
                        grdcaptura.Rows.Add("", com_prod, "", "", "", "")
                    End If
                End If
            Loop
            rd2.Close()
            cnn3.Close()

            Dim subtotal_ped As Double = 0
            Dim envio_ped As Double = 0
            Dim total_ped As Double = 0

            Dim acuenta_ped As Double = 0
            Dim resta_ped As Double = 0

            Dim nuevototalpedido As Double = 0

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select Subtotal,Envio,Total,Status from Pedidos_Tienda where Id_Orden=" & cbofolio.Text
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    subtotal_ped = rd2("Subtotal").ToString()
                    envio_ped = rd2("Envio").ToString()
                    total_ped = rd2("Total").ToString()

                    nuevototalpedido = CDec(total_ped) * 1.16

                    If rd2("Status").ToString() = 1 Then
                        txtacuenta.Text = FormatNumber(nuevototalpedido, 2)
                        txt_resta.Text = FormatNumber(0, 2)
                    Else
                        If txt_metodo_pago.Text = "PAGO CONTRA ENTREGA (PCE)" Then
                            txt_resta.Text = FormatNumber(nuevototalpedido, 2)
                        Else
                            txtacuenta.Text = FormatNumber(nuevototalpedido, 2)
                        End If
                    End If
                End If
            End If
            rd2.Close()
            cnn2.Close()

            txt_subtotal.Text = FormatNumber(subtotal_ped, 2)
            txt_envio.Text = FormatNumber(envio_ped, 2)
            '   txt_total.Text = FormatNumber(total_ped, 2)
            txt_total.Text = FormatNumber(nuevototalpedido, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Function get_id_cliente(ByVal id_tienda As Integer) As Integer
        Dim id_cliente As Integer = 0

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Id from Clientes where Id=" & id_tienda
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    id_cliente = rd3("Id").ToString()
                End If
            Else
                id_cliente = 0
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try

        Return id_cliente
    End Function

    Private Sub Limpiar_datos()

        txtdireccion.Text = ""
        cbofolio.Text = ""
        txt_referencia.Text = ""
        txt_metodo_pago.Text = ""
        lbltipo_envio.Text = ""
        lblNumCliente.Text = ""
        grdcaptura.Rows.Clear()
        txt_subtotal.Text = "0.00"
        txt_envio.Text = "0.00"
        txt_total.Text = "0.00"
        txtacuenta.Text = "0.00"
        txt_resta.Text = "0.00"

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

        donde_va = ""
        txtdescu.Text = "0.00"
        txtdescuento1.Text = "0"
        txtdescuento1.ReadOnly = False
        txtefectivo.Text = "0.00"
        txtefectivo.ReadOnly = False
        txtResta.Text = "0.00"
        txtResta.ReadOnly = True
        txtCambio.Text = "0.00"
        txtCambio.ReadOnly = True

        txtMontoP.Text = "0.00"
        txtSubTotal.Text = "0.00"
        txtdescuento2.Text = "0.00"
        txtPagar.Text = "0.00"

        MYFOLIO = 0
    End Sub

    Private Sub opt_pendientes_CheckedChanged(sender As Object, e As EventArgs) Handles opt_pendientes.CheckedChanged
        If (opt_pendientes.Checked) Then
            Limpiar_datos()
            cbofolio.Focus().Equals(True)
        End If
    End Sub

    Private Sub opt_entregados_CheckedChanged(sender As Object, e As EventArgs) Handles opt_entregados.CheckedChanged
        If (opt_entregados.Checked) Then
            Limpiar_datos()
            cbofolio.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_entregado.Click
        If cbofolio.Text = "" Then MsgBox("Selecciona un folio para poder terminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofolio.Focused.Equals(True) : Exit Sub
        If lbltipo_envio.Visible = False Then MsgBox("No hay un tipo de envío seleccionado.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : cbofolio.Focused().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Viene_De = "Entrega" : Exit Sub
        If opt_entregados.Checked = True Then MsgBox("No puedes terminar un pedido que ya fue entregado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Limpiar_datos() : Exit Sub

        If grdcaptura.Rows.Count < 1 Then
            Exit Sub
        End If

        txtSubTotal.Text = FormatNumber(txt_total.Text, 2)
        If CDbl(txtdescuento1.Text) > 0 Then
            txtSubTotal.Tag = 1
        End If

        If CDbl(txtdescuento1.Text) <= 0 Then
            txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
            txtPagar.Text = FormatNumber(txtPagar.Text, 2)
        End If

        Call txtdescuento1_TextChanged(txtdescuento1, New EventArgs())

        box_Pago.Visible = True
        txtefectivo.Focus.Equals(True)
        'Selecciona el tipo de pago desde la tabla de pago
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Tipo_Pago,Ref_Pago,Monto from Pagos_Tienda where Id_Orden=" & cbofolio.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbotpago.Text = rd1("Tipo_Pago").ToString()
                    txtnumref.Text = rd1("Ref_Pago").ToString()
                    txtmonto.Text = FormatNumber(rd1("Monto").ToString(), 2)
                    'Dim fecha_p As Date = rd1("Fecha_Pago").ToString()
                    'dtpFecha_P.Text = fecha_p
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If cbotpago.Text <> "" Then
            Button9.PerformClick()
        End If

        If lbltipo_envio.Text = "Envio a domicilio" Then
            TextBox1.Focus().Equals(True)
        End If

    End Sub

    Private Sub btn_produccion_Click(sender As Object, e As EventArgs) Handles btn_produccion.Click
        If cbofolio.Text = "" Then MsgBox("Selecciona un folio para poder enviar a producción.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofolio.Focused.Equals(True) : Exit Sub
        If lbltipo_envio.Visible = False Then MsgBox("No hay un tipo de envío seleccionado.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : cbofolio.Focused().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Viene_De = "Produccion" : Exit Sub
        If opt_entregados.Checked = True Then MsgBox("No puedes enviar a producción un pedido que ya fue entregado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Limpiar_datos() : Exit Sub

        If grdcaptura.Rows.Count < 1 Then
            Exit Sub
        End If

        If lbltipo_envio.Text = "Envío a domicilio" Then
            Envia_Produccion()
            'Imprime ticket para el repartidor
            Dim impresora As String = ""

            Try
                cnn3.Close() : cnn3.Open()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT Impresora from RutasImpresion where Tipo='TICKET' and Equipo='" & ObtenerNombreEquipo() & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        impresora = rd3(0).ToString
                    End If
                End If
                rd3.Close()
                cnn3.Close()

                p_envio.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                p_envio.Print()

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try

        End If

        If lbltipo_envio.Text = "Recoge en tienda" Then
            Envia_Produccion()

            Dim impresora As String = ""

            Try
                cnn3.Close() : cnn3.Open()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT Impresora from RutasImpresion where Tipo='TICKET' and Equipo='" & ObtenerNombreEquipo() & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        impresora = rd3(0).ToString
                    End If
                End If
                rd3.Close()
                cnn3.Close()

                p_recoge_t.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                p_recoge_t.Print()

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try
        End If
    End Sub

    Private Sub Envia_Produccion()
        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            Dim codigo_p As String = ""
            Dim descri_p As String = ""
            Dim unidad_p As String = ""
            Dim cantid_p As Double = 0
            Dim precio_p As Double = 0
            Dim total_pr As Double = 0

            Dim comentario As String = ""

            Dim g_print As String = ""
            Dim depto_p As String = ""
            Dim grupo_p As String = ""

            Dim id_comanda As Integer = 0

            For t As Integer = 0 To grdcaptura.Rows.Count - 1
                g_print = ""

                If grdcaptura.Rows(t).Cells(0).Value.ToString() <> "" Then
                    codigo_p = grdcaptura.Rows(t).Cells(0).Value.ToString()
                    descri_p = grdcaptura.Rows(t).Cells(1).Value.ToString()
                    unidad_p = grdcaptura.Rows(t).Cells(2).Value.ToString()
                    cantid_p = grdcaptura.Rows(t).Cells(3).Value.ToString()
                    precio_p = grdcaptura.Rows(t).Cells(4).Value.ToString()
                    total_pr = grdcaptura.Rows(t).Cells(5).Value.ToString()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Departamento,Grupo,GPrint from Productos where Codigo='" & codigo_p & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            depto_p = rd1("Departamento").ToString()
                            grupo_p = rd1("Grupo").ToString()
                            g_print = rd1("GPrint").ToString()
                        End If
                    End If
                    rd1.Close()

                    If g_print = "" Then
                        g_print = "PRED"
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Comandas_T(Pedido,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Depto,Grupo,Comentario,GPrint) values('" & cbofolio.Text & "','" & codigo_p & "','" & descri_p & "','" & unidad_p & "'," & cantid_p & "," & precio_p & "," & total_pr & ",'" & depto_p & "','" & grupo_p & "','','" & g_print & "')"
                    cmd1.ExecuteNonQuery()

                End If
                If grdcaptura.Rows(t).Cells(0).Value.ToString() = "" Then

                    comentario = grdcaptura.Rows(t).Cells(1).Value.ToString()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select MAX(Id) from Comandas_T"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            id_comanda = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Comandas_T set Comentario='" & comentario & "' where Id=" & id_comanda
                    cmd2.ExecuteNonQuery()
                End If
            Next
            cnn2.Close()
            cnn1.Close()

            Dim tamimpre As Integer = 0
            Dim impresoracomanda As String = ""

            cnn4.Close() : cnn4.Open()
            cnn3.Close() : cnn3.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    tamimpre = rd4(0).ToString
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT DISTINCT GPrint FROM Comandas_T WHERE Pedido='" & cbofolio.Text & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then
                    Grupo_Impresion_Tienda = rd4(0).ToString

                    If Grupo_Impresion_Tienda = "PRED" Then
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Impresora from RutasImpresion where Tipo='TICKET' and Equipo='" & ObtenerNombreEquipo() & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                impresoracomanda = rd3(0).ToString
                            End If
                        End If
                        rd3.Close()

                        If tamimpre = 80 Then
                            pComanda80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                            pComanda80.Print()
                        End If

                        If tamimpre = 58 Then
                            pComanda58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                            pComanda58.Print()
                        End If
                    Else
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Impresora from RutasImpresion where Tipo='" & Grupo_Impresion_Tienda & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                impresoracomanda = rd3(0).ToString
                            End If
                        End If
                        rd3.Close()

                        If tamimpre = 80 Then
                            pComanda80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                            pComanda80.Print()
                        End If

                        If tamimpre = 58 Then
                            pComanda58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                            pComanda58.Print()
                        End If
                    End If
                End If
            Loop
            rd4.Close()
            cnn4.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pComanda80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pComanda80.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)

        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)

        Dim Y As Double = 0

        Try
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("C O M A N D A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("N° Pedido: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15

            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 150, Y, sf)
            Y += 6
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim codigo As String = ""
            Dim nombre As String = ""
            Dim cantidad As Double = 0
            Dim comentario As String = ""

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select Codigo,Nombre,Cantidad,Comentario from Comandas_T WHERE GPrint='" & Grupo_Impresion_Tienda & "' AND Pedido='" & cbofolio.Text & "' group by Codigo,Nombre,Cantidad,Comentario order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    codigo = rd1("Codigo").ToString
                    nombre = rd1("Nombre").ToString
                    cantidad = rd1("Cantidad").ToString
                    comentario = rd1("Comentario").ToString

                    e.Graphics.DrawString(cantidad, fuente_datos, Brushes.Black, 1, Y)

                    Dim caracteresPorLinea As Integer = 30
                    Dim texto As String = nombre
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Lucida Sans Typewriter", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                        Y += 15
                        inicio += caracteresPorLinea
                    End While

                    If comentario <> "" Then
                        e.Graphics.DrawString("NOTA: " & comentario, fuente_datos, Brushes.Black, 1, Y)
                        Y += 15
                    End If

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Encargado: ", fuente_datos, Brushes.Black, 1, Y)
            Y += 3
            e.Graphics.DrawString(lblusuario.Text, fuente_prods, Brushes.Black, 285, Y, sf)

            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString()
                    End If
                Else
                    MsgBox("No se encuenra el usuario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.SelectAll() : Exit Sub
                    rd1.Close() : cnn1.Close()
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If Viene_De = "Produccion" Then
                btn_produccion.Focus().Equals(True)
            End If
            If Viene_De = "Entrega" Then
                btn_entregado.Focus().Equals(True)
            End If
        End If
    End Sub


    Private Sub p_envio_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles p_envio.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)

        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)

        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim Pie As String = ""

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

            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie = rd2("Pie1").ToString
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If

                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If

                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab6").ToString <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 4
                End If
            End If
            rd2.Close()

            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("TICKET DEL CLIENTE", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 280, Y, sf)
            Y += 12
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Pedido: " & cbofolio.Text, New Font("Lucida Sans Typewriter", 8, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("Referencia: " & txt_referencia.Text, New Font("Lucida Sans Typewriter", 8, FontStyle.Bold), Brushes.Black, 280, Y, sf)
            Y += 22
            e.Graphics.DrawString("CLIENTE", New Font("Lucida Sans Typewriter", 9, FontStyle.Bold), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString(cbonombre.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 20
            e.Graphics.DrawString("DIRECCIÓN DE ENTREGA", New Font("Lucida Sans Typewriter", 9, FontStyle.Bold), Brushes.Black, 1, Y)
            Y += 14
            Dim caracteresPorLinea As Integer = 35
            Dim texto As String = txtdireccion.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Lucida Sans Typewriter", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                inicio += caracteresPorLinea
            End While
            Y += 5

            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 10
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 190, Y, sf)
            e.Graphics.DrawString("IMPORTE", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 280, Y, sf)
            Y += 5
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 4)

                e.Graphics.DrawString(Mid(nombre, 1, 48), fuente_prods, Brushes.Black, 1, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 110, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 193, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 280, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 6
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0
            Dim IVAPRODUCTO As Double = 0
            Dim IVADELPRODUCTO As Double = 0
            Try
                cnn1.Close() : cnn1.Open()
                For N As Integer = 0 To grdcaptura.Rows.Count - 1
                    If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then

                                If rd1(0).ToString > 0 Then
                                    MySubtotal = grdcaptura.Rows(N).Cells(5).Value.ToString
                                    IVAPRODUCTO = MySubtotal / (1 + rd1(0).ToString)
                                    IVADELPRODUCTO = MySubtotal - IVAPRODUCTO
                                    TotalIVAPrint = TotalIVAPrint + IVADELPRODUCTO
                                End If
                            End If
                        End If
                        rd1.Close()
                    End If
                Next
                TotalIVAPrint = FormatNumber(TotalIVAPrint, 2)
                MySubtotal = FormatNumber(MySubtotal, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            Dim subtotal As Double = 0
            Dim IVA As Double = CDbl(txt_total.Text) - TotalIVAPrint
            subtotal = CDbl(txt_total.Text) - IVA

            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(subtotal, 2), fuente_prods, Brushes.Black, 280, Y, sf)
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(TotalIVAPrint, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                        Y += 4
                    End If
                End If
            Else
                e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txt_subtotal.Text, 2), fuente_prods, Brushes.Black, 280, Y, sf)
                Y += 4
            End If
            Y += 8

            e.Graphics.DrawString("Envío:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txt_envio.Text, 2), fuente_prods, Brushes.Black, 280, Y, sf)
            Y += 15
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txt_total.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 280, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txt_total.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If txt_metodo_pago.Text = "PAGO CONTRA ENTREGA (PCE)" Then
                Y += 5
                e.Graphics.DrawString("PAGO A CONTRA ENTREGA", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 20
            Else
                Y += 5
                e.Graphics.DrawString("PAGADO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 20
            End If

            'Imprime pie de página
            Dim cadena_pie As String = Pie

            e.Graphics.DrawString(Mid(Pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 13.5

            cadena_pie = Mid(Pie, 41, 500)

            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If
            If cadena_pie <> "" Then
                e.Graphics.DrawString(Mid(cadena_pie, 1, 40), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                cadena_pie = Mid(cadena_pie, 41, 500)
                Y += 13.5
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub p_recoge_t_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles p_recoge_t.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)

        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)

        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim Pie As String = ""

        Try
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("TICKET DEL ENTREGA", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 280, Y, sf)
            Y += 12
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Pedido: " & cbofolio.Text, New Font("Lucida Sans Typewriter", 8, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("Referencia: " & txt_referencia.Text, New Font("Lucida Sans Typewriter", 8, FontStyle.Bold), Brushes.Black, 280, Y, sf)
            Y += 22

            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 10
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 190, Y, sf)
            e.Graphics.DrawString("IMPORTE", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 280, Y, sf)
            Y += 5
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 4)

                e.Graphics.DrawString(Mid(nombre, 1, 48), fuente_prods, Brushes.Black, 1, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 110, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 193, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 280, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 6
            e.Graphics.DrawString("---------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18


            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txt_total.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 280, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txt_total.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If txt_metodo_pago.Text = "PAGO CONTRA ENTREGA (PCE)" Then
                Y += 5
                e.Graphics.DrawString("PAGO A CONTRA ENTREGA", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 20
            Else
                Y += 5
                e.Graphics.DrawString("PAGADO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 20
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try

    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Dim tpago As String = cbotpago.Text
        Dim banco As String = cbobanco.Text
        Dim refe As String = txtnumref.Text
        Dim monto As Double = 0
        If txtvalor.Text <> "0.00" Then
            monto = FormatNumber(txtmonto.Text * CDec(txtvalor.Text), 4)
        Else
            monto = FormatNumber(txtmonto.Text, 4)
        End If

        Dim fecha As String = Format(dtpFecha_P.Value, "dd/MM/yyyy")
        Dim comentario As String = txtComentarioPago.Text
        Dim cuentar As String = cboCuentaRecepcion.Text
        Dim bancorep As String = cboBancoRecepcion.Text

        grdpago.Rows.Add(tpago, banco, refe, monto, fecha, comentario, cuentar, bancorep, txtvalor.Text, txtequivale.Text, txtmonto.Text)
        grdpago.Refresh()

        Dim pagos As Double = 0
        For wy As Integer = 0 To grdpago.Rows.Count - 1
            pagos = pagos + CDbl(grdpago.Rows(wy).Cells(3).Value.ToString)
        Next

        txtMontoP.Text = FormatNumber(pagos, 4)
        cbotpago.Text = ""
        cbobanco.Text = ""
        txtnumref.Text = ""
        txtmonto.Text = "0.00"
        dtpFecha_P.Value = Date.Now
        cbotpago.Focus().Equals(True)

        txtComentarioPago.Text = ""
        cboCuentaRecepcion.Text = ""
        cboCuentaRecepcion.Text = ""
        cboBancoRecepcion.Text = ""
        txtvalor.Text = "0.00"
        txtequivale.Text = "0.00"

    End Sub

    Private Sub cbotpago_DropDown(sender As System.Object, e As System.EventArgs) Handles cbotpago.DropDown
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

    Private Sub dtpFecha_P_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha_P.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button9.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbotpago_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbotpago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbotpago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbotpago.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Valor from FormasPago where Valor<>'' and FormaPago='" & cbotpago.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtvalor.Text = rd1(0).ToString
                txtequivale.Text = FormatNumber(txtPagar.Text / CDec(txtvalor.Text), 2)

            Else
                txtvalor.Text = "0.00"
                txtequivale.Text = "0.00"

            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
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
            If cbotpago.Text = "TARJETA" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id from MovCuenta where Tipo='TARJETA' and Referencia='" & txtnumref.Text & "'"
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
                        "select Id from MovCuenta where Tipo='TRANSFERENCIA' and Referencia='" & txtnumref.Text & "'"
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
            txtComentarioPago.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtComentarioPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarioPago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuentaRecepcion.Focus().Equals(True)
        End If
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

    Private Sub grdpago_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpago.CellDoubleClick
        Dim indexito As Integer = grdpago.CurrentRow.Index

        cbotpago.Text = grdpago.Rows(indexito).Cells(0).Value.ToString()
        cbobanco.Text = grdpago.Rows(indexito).Cells(1).Value.ToString()
        txtnumref.Text = grdpago.Rows(indexito).Cells(2).Value.ToString()
        txtmonto.Text = grdpago.Rows(indexito).Cells(10).Value.ToString()
        dtpFecha_P.Value = grdpago.Rows(indexito).Cells(4).Value.ToString()
        txtvalor.Text = grdpago.Rows(indexito).Cells(8).Value.ToString()
        txtequivale.Text = grdpago.Rows(indexito).Cells(9).Value.ToString()

        grdpago.Rows.Remove(grdpago.Rows(indexito))

        Dim pagos As Double = 0
        For wy As Integer = 0 To grdpago.Rows.Count - 1
            pagos = pagos + CDbl(grdpago.Rows(wy).Cells(3).Value.ToString)
        Next

        txtMontoP.Text = FormatNumber(pagos, 4)
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

    Private Sub txtdescuento2_GotFocus(sender As Object, e As System.EventArgs) Handles txtdescuento2.GotFocus
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub
    Private Sub txtdescuento2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuento2.KeyPress
        If Not IsNumeric(txtdescuento2.Text) Then txtdescuento2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 4)
            txtPagar.Text = FormatNumber(CDbl(IIf(txtPagar.Text = "", "0", txtPagar.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 4)
            txtResta.Text = FormatNumber(CDbl(IIf(txtResta.Text = "", "0", txtResta.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 4)
            txtefectivo.Focus().Equals(True)
        End If
    End Sub
    Private Sub txtdescuento2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdescuento2.TextChanged
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub

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

    Private Sub txtefectivo_Click(sender As System.Object, e As System.EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub
    Private Sub txtefectivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
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
            Button1.Focus().Equals(True)
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

    Private Sub txtdescu_Click(sender As Object, e As EventArgs) Handles txtdescu.Click
        donde_va = "Descuento Moneda"
        txtdescu.SelectionStart = 0
        txtdescu.SelectionLength = Len(txtdescu.Text)
    End Sub

    Private Sub txtdescu_GotFocus(sender As Object, e As EventArgs) Handles txtdescu.GotFocus
        donde_va = "Descuento Moneda"
        txtdescu.SelectionStart = 0
        txtdescu.SelectionLength = Len(txtdescu.Text)
    End Sub

    Private Sub txtdescu_TextChanged(sender As Object, e As EventArgs) Handles txtdescu.TextChanged
        If donde_va = "Descuento Moneda" Then
            Dim resta As Double = 0

            If txtdescuento1.Enabled = True Then
                If txtdescu.Text = "" Then
                    txtdescu.Text = "0"
                    txtPagar.Text = txtSubTotal.Text
                    Exit Sub
                End If

                If CDbl(txtdescu.Text) > 0 Then
                    If grdpago.Rows.Count > 0 Then grdpago.Rows.Clear() : txtMontoP.Text = "0.00"
                End If

                Dim CampoDsct As Double = IIf(txtdescu.Text = "", "0", txtdescu.Text)
                Dim Desc As Double = 0

                Desc = (CampoDsct * 100) / CDbl(txtSubTotal.Text)
                txtdescuento1.Text = FormatNumber(Desc, 1)

                txtdescuento2.Text = (Desc / 100) * CDbl(txtSubTotal.Text)
                txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 4)
                txtPagar.Text = CDbl(txtSubTotal.Text) - ((Desc / 100) * CDbl(txtSubTotal.Text))
                txtPagar.Text = FormatNumber(txtPagar.Text, 2)
                txtResta.Text = CDbl(txtSubTotal.Text) - ((Desc / 100) * CDbl(txtSubTotal.Text))
                txtResta.Text = FormatNumber(txtResta.Text, 2)

                cnn5.Close() : cnn5.Open()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select NotasCred from Formatos where Facturas='Mdescuento'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        Desc = rd5(0).ToString
                        If CDbl(txtdescuento1.Text) = 0 Then
                            txtdescuento2.Text = "0.00"
                            txtResta.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtMontoP.Text) - (CDbl(txtefectivo.Text) - CDbl(txtCambio.Text)), 2)
                            CampoDsct = 0
                            txtPagar.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text), 2)
                            Exit Sub
                        End If
                        If CDbl(txtdescuento1.Text) > Desc Then
                            MsgBox("No puedes rebasar el descuento máximo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            CampoDsct = 0
                            txtdescu.Text = "0.00"
                            txtdescuento2.Text = "0.00"
                            txtResta.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtMontoP.Text), 2)
                            txtPagar.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text), 2)
                            txtdescu.SelectionStart = 0
                            txtdescu.SelectionLength = Len(txtdescu.Text)
                            Exit Sub
                        End If
                    End If
                Else
                    If CDbl(txtdescuento1.Text) <> 0 Then
                        MsgBox("Establece un máximo de descuento por venta para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        CampoDsct = 0
                        txtdescuento1.SelectionStart = 0
                        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
                        rd5.Close() : cnn5.Close()
                        Exit Sub
                    End If
                End If
                rd5.Close() : cnn5.Close()

            End If
        End If
    End Sub

    Private Sub txtdescu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescu.KeyPress
        If txtdescu.Text = "" And AscW(e.KeyChar) = 46 Then
            txtdescu.Text = "0.00"
            txtdescu.SelectionStart = 0
            txtdescu.SelectionLength = Len(txtdescu.Text)
            txtdescu.Focus().Equals(True)
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdescuento1_Click(sender As Object, e As System.EventArgs) Handles txtdescuento1.Click
        donde_va = "Descuento Porcentaje"
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub
    Private Sub txtdescuento1_GotFocus(sender As Object, e As System.EventArgs) Handles txtdescuento1.GotFocus
        donde_va = "Descuento Porcentaje"
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
            txtefectivo.Focus().Equals(True)
        End If
    End Sub
    Public Sub txtdescuento1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdescuento1.TextChanged
        If donde_va = "Descuento Porcentaje" Then
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
            txtdescu.Text = (CampoDsct / 100) * CDbl(txtSubTotal.Text)
            txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 4)
            txtdescu.Text = FormatNumber(txtdescu.Text, 2)
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
            txtResta.Text = FormatNumber(txtSubTotal.Text, 2)
        End If
    End Sub

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim VarUser As String = "", VarIdUsuario As Integer = 0, DsctoProd As Single = 0, PorcentDscto As Single = 0, DsctoProdTod As Single = 0
        Dim CveLte As Double = 0
        Dim IdCliente As Integer = 0
        Dim ConteoXD As Double = 0

        Dim TotalIEPSPrint As Double = 0
        Dim SubtotalPrint As Double = 0
        Dim MySubtotal As Double = 0
        Dim TotalIVAPrint As Double = 0

        If lbltipo_envio.Text = "Envío a domicilio" Then
            If TextBox1.Text = "" Then
                MsgBox("Escribe el nombre del repatidor para poder guardar el pedido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : TextBox1.Focus().Equals(True) : Exit Sub
            End If
        End If

        If grdcaptura.Rows.Count < 1 Then
            Exit Sub
        End If

        'Cálculo del subtotal
        Try
            For i As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(i).Cells(0).Value.ToString = "" Then
                Else
                    ConteoXD = ConteoXD + CDbl(grdcaptura.Rows(i).Cells(5).Value.ToString)
                End If
                txtSubTotal.Text = FormatNumber(ConteoXD, 2)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        'Cálculo de Subtotal e IVA
        Dim ivaporproducto As Double = 0
        Dim ivaporproda As Double = 0

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
                            If rd1(0).ToString > 0 Then

                                ivaporproducto = CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString) / (1 + rd1(0).ToString)
                                ivaporproducto = FormatNumber(ivaporproducto, 2)
                                ivaporproda = CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString) - CDbl(ivaporproducto)
                                ivaporproda = FormatNumber(ivaporproda, 2)

                                TotalIVAPrint = TotalIVAPrint + CDbl(ivaporproda)
                            End If

                        End If
                    End If
                    rd1.Close()
                End If
            Next
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 6)

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If grdcaptura.Rows.Count < 1 Then txtdescuento1.Focus().Equals(True) : cnn1.Close() : Exit Sub

        If (cbonombre.Text = "") And CDbl(IIf(txtResta.Text = "", "0", txtResta.Text)) <> 0 Then
            MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cbonombre.Focus().Equals(True)
            cnn1.Close() : Exit Sub
        End If

        Dim Cliente As String = ""
        Dim dias_credito As Double = 0
        Dim max_cred As Double = 0

        Dim fecha_pago As String = ""

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select Id,DiasCred from Clientes where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    IdCliente = rd1("Id").ToString()
                    Cliente = cbonombre.Text
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
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
        My.Application.DoEvents()

        Dim per_venta As Boolean = False
        If lblusuario.Text = "" Then
            MsgBox("Escribe/Revisa tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cnn1.Close()
            txtusuario.Focus().Equals(True) : Exit Sub
        Else
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Alias,IdEmpleado from Usuarios where Clave='" & txtusuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    VarUser = rd1("Alias").ToString
                    VarIdUsuario = rd1("IdEmpleado").ToString
                End If
            Else
                MsgBox("No se encuentra un usuario registrado bajo esta contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close()
                txtusuario.Focus().Equals(True) : Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select Vent_NVen from Permisos where IdEmpleado= " & VarIdUsuario
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
        End If

        'Comienza proceso de guardado de la venta
        If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub


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

        ope1 = Math.Cos(CDbl(cbofolio.Text))
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
            Numeros = Mid(cbofolio.Text, w, 4)
            Letras = Mid(letters, w, 4)
            lic = lic & Numeros & Letras & "-"
        Next
        lic = Strings.Left(lic, Len(lic) - 1)
        CodCadena = lic
        cadenafact = Trim(CodCadena)


        'Inserción en [Ventas]
        Try

            Efectivo = txtefectivo.Text
            MyMonto = Efectivo + CDbl(txtMontoP.Text)
            Resta = FormatNumber(txtResta.Text, 2)

            If TotalIVAPrint > 0 Then
                IVA_Vent = FormatNumber(TotalIVAPrint, 4)
            Else
                IVA_Vent = 0
            End If

            SubTotal = FormatNumber(CDbl(txtPagar.Text) - CDbl(IVA_Vent), 4)

            If MyMonto > CDbl(txtPagar.Text) Then
                ACUenta2 = FormatNumber(CDbl(txtPagar.Text), 2)
                Resta = 0
            Else
                ACUenta2 = FormatNumber(MyMonto, 4)
                Resta = FormatNumber(CDbl(txtPagar.Text) - MyMonto, 2)
            End If

            txtResta.Text = Resta

            If Resta = 0 Then
                MyStatus = "PAGADO"
            Else
                MyStatus = "RESTA"
            End If


            Total_Ve = FormatNumber(CDbl(txtPagar.Text), 4)
            Descuento = FormatNumber(txtdescuento2.Text, 4)
            MontoSDesc = FormatNumber(CDbl(txtPagar.Text) + Descuento, 4)

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Entrega,Comentario,StatusE,FolMonedero,CodFactura,IP,Formato,Franquicia,Pedido,Fecha) values(" & IdCliente & ",'" & cbonombre.Text & "','" & txtdireccion.Text & "'," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACUenta2 & "," & Resta & ",'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & fecha_pago & "','','" & MyStatus & "','',''," & MontoSDesc & ",'',0,'',0,'','" & CodCadena & "','" & dameIP2() & "','TICKET',0," & IIf(cbofolio.Text = "", 0, cbofolio.Text) & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        MYFOLIO = 0

        'Obtiene el folio que se acaba de insertar
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

        'Llenado de variables de pago (Tarjeta, Transferencia, Saldo, Efectivo y Otro)
        Dim EfectivoX As Double = (CDbl(txtefectivo.Text) - CDbl(txtCambio.Text))

        Dim FormaPago As String = ""
        Dim TotFormaPago As Double = 0
        Dim BancoFP As String = ""
        Dim ReferenciaFP As String = ""
        Dim CmentarioFP As String = ""
        Dim CuentaFP As String = ""
        Dim BancoRecp As String = ""

        Dim TotSaldo As Double = 0

        'Inserta en [AbonoI]
        Try
            cnn1.Close() : cnn1.Open()
            Dim MySaldo As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & cbonombre.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) + CDbl(txtPagar.Text)
                End If
            Else
                MySaldo = txtPagar.Text
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & MYFOLIO & "," & IdCliente & ",'" & cbonombre.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','" & lblusuario.Text & "',0,'')"
            cmd1.ExecuteNonQuery()


            ACuenta = FormatNumber((CDbl(txtefectivo.Text) - CDbl(txtCambio.Text)) + CDbl(txtMontoP.Text), 4)

            If ACuenta > 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & cbonombre.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString - ACuenta), 4)
                    End If
                Else
                    MySaldo = FormatNumber(txtPagar.Text, 4)
                End If
                rd1.Close()

                'Pago de efectivo
                If EfectivoX > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Comentario) values(" & MYFOLIO & "," & IdCliente & ",'" & cbonombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & EfectivoX & "," & (MySaldo) & ",'EFECTIVO'," & EfectivoX & ",'','','" & lblusuario.Text & "','')"
                    cmd1.ExecuteNonQuery()
                End If

                If grdpago.Rows.Count > 0 Then
                    For R As Integer = 0 To grdpago.Rows.Count - 1

                        FormaPago = grdpago.Rows(R).Cells(0).Value.ToString()
                        If CStr(grdpago.Rows(R).Cells(0).Value.ToString()) = FormaPago Then
                            TotFormaPago = CDbl(grdpago.Rows(R).Cells(3).Value.ToString())
                            BancoFP = BancoFP & "-" & CStr(grdpago.Rows(R).Cells(1).Value.ToString())
                            ReferenciaFP = grdpago.Rows(R).Cells(2).Value.ToString()
                            CmentarioFP = grdpago.Rows(R).Cells(5).Value.ToString()
                            CuentaFP = grdpago.Rows(R).Cells(6).Value.ToString()
                        End If

                        If TotFormaPago > 0 Then
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Comentario,CuentaC) values(" & MYFOLIO & "," & IdCliente & ",'" & cbonombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & TotFormaPago & "," & (MySaldo) & ",'" & FormaPago & "'," & TotFormaPago & ",'" & BancoFP & "','" & ReferenciaFP & "','" & lblusuario.Text & "','" & CmentarioFP & "','" & CuentaFP & "')"
                            cmd2.ExecuteNonQuery()

                            Dim es_p_t As Boolean = False

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select Id from Pagos_Tienda where Tipo_Pago='" & FormaPago & "' and Ref_Pago='" & ReferenciaFP & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    es_p_t = True
                                End If
                            Else
                                es_p_t = False
                            End If
                            rd2.Close()

                            If es_p_t = True Then
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "update Pagos_Tienda set Status=1 where Tipo_Pago='" & FormaPago & "' and Ref_Pago='" & ReferenciaFP & "'"
                                cmd2.ExecuteNonQuery()
                            End If
                            cnn2.Close()
                        End If
                    Next

                End If
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            For R As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(R).Cells(0).Value.ToString = "" Then GoTo Door

                DsctoProd = 0
                DsctoProdTod = 0
                PorcentDscto = IIf(txtdescuento1.Text = "", 0, txtdescuento1.Text)
                If PorcentDscto <> 0 Then
                    DsctoProd = CDbl(grdcaptura.Rows(R).Cells(4).Value.ToString) * (PorcentDscto / 100)
                    DsctoProdTod = CDbl(grdcaptura.Rows(R).Cells(5).Value.ToString) * (PorcentDscto / 100)
                End If

                Dim mycode As String = ""
                Dim mydesc As String = ""
                Dim myunid As String = ""
                Dim mycant As Double = grdcaptura.Rows(R).Cells(3).Value.ToString
                Dim myprecio As Double = grdcaptura.Rows(R).Cells(4).Value.ToString
                Dim mytotal As Double = FormatNumber(mycant * myprecio, 4)

                Dim ieps As Double = 0
                Dim tasaieps As Double = 0

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

                mycode = grdcaptura.Rows(R).Cells(0).Value.ToString
                mydesc = grdcaptura.Rows(R).Cells(1).Value.ToString
                myunid = grdcaptura.Rows(R).Cells(2).Value.ToString

                Dim gprint As String = ""

                TotalIEPSPrint = TotalIEPSPrint + CDbl(grdcaptura.Rows(R).Cells(5).Value.ToString)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select IVA, IIEPS from Productos where Codigo='" & mycode & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyIVA = rd1(0).ToString
                        tasaieps = rd1(1).ToString()
                    End If
                End If
                rd1.Close()

                myprecioS = FormatNumber(myprecio / (1 + MyIVA), 6)
                mytotalS = FormatNumber(mytotal / (1 + MyIVA), 6)


                myprecioS = FormatNumber(myprecioS, 6)
                mytotalS = FormatNumber(mytotalS, 6)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Departamento,Grupo,ProvRes,MCD,Multiplo,GPrint,Departamento from Productos where Codigo='" & mycode & "'"
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
                        gprint = rd1("GPrint").ToString
                        If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                            rd1.Close()
                            GoTo Door
                        End If
                    End If
                End If
                rd1.Close()
                Dim existe As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Existencia,Multiplo,Departamento,PrecioCompra from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existe = rd1("Existencia").ToString()
                        MyMultiplo = rd1("Multiplo").ToString()
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
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Promo_Monedero,Unico,Descuento,Gprint) values(" & MYFOLIO & ",'" & mycode & "','" & mydesc & "','" & myunid & "'," & mycant & "," & MyProm & "," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','','0','" & MyDepto & "','" & MyGrupo & "','0'," & Descuento & ",0," & ieps & "," & tasaieps & ",'','',0,0,0," & Descuento & ",'" & gprint & "')"
                    cmd1.ExecuteNonQuery()

                    Dim necesito As Double = mycant / MyMCD
                    Dim tengo As Double = 0
                    Dim cuanto_cuestan As Double = 0
                    Dim id_peps As Integer = 0
                    Dim utilidad As Double = 0

                    Dim quedan As Double = 0
                    Dim v_costo As Double = 0
                    Dim v_venta As Double = 0

                    If MyDepto <> "SERVICIOS" And Kit = False Then

                        Dim nueva_existe As Double = 0

                        If MyMulti2 > 1 And MyMCD = 1 Then
                            nueva_existe = FormatNumber(CDec(mycant) * CDec(MyMulti2), 0)
                        Else
                            nueva_existe = CDec(mycant) * CDec(MyMulti2)
                        End If

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set CargadoInv=0, Cargado=0, Actu=0, Existencia=Existencia - " & nueva_existe & " where Codigo='" & Strings.Left(mycode, 6) & "'"
                        cmd1.ExecuteNonQuery()

                        Dim MyExiste As Double = 0

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Existencia from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MyExiste = rd1(0).ToString()
                            End If
                        End If
                        rd1.Close()

                        If Len(mycode) = 6 Then

                            MyExiste = FormatNumber(MyExiste / MyMultiplo, 2)
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta en línea'," & Existencia & "," & mycant & "," & MyExiste & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MYFOLIO & "','','','','','')"
                            cmd1.ExecuteNonQuery()
                        Else
                            Existencia = FormatNumber((MyExiste + nueva_existe) / MyMulti2, 2)
                            MyExiste = MyExiste / MyMulti2

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta en línea'," & Existencia & "," & mycant & "," & MyExiste & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MYFOLIO & "','','','','','')"
                            cmd1.ExecuteNonQuery()
                        End If
                    End If

                    utilidad = 0
                    v_venta = 0
                    v_costo = 0
                    necesito = 0
                    tengo = 0

                End If

                If grdcaptura.Rows(R).Cells(0).Value.ToString = "" And grdcaptura.Rows(R).Cells(1).Value.ToString <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update VentasDetalle set CostVR='" & grdcaptura.Rows(R).Cells(1).Value.ToString & "' where Codigo='" & mycode & "' and Folio=" & MYFOLIO
                    cmd1.ExecuteNonQuery()
                End If
            Next
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close() : cnn2.Close()
        End Try

        Dim Imprime As Boolean = False
        Dim Copias As Integer = 0
        Dim TPrint As String = "TICKET"
        Dim Imprime_En As String = ""
        Dim Impresora As String = ""
        Dim Tamaño As String = ""
        Dim Pasa_Print As Boolean = False

        Dim pide As String = "", contra As String = txtusuario.Text, usu As String = lblusuario.Text


        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NoPrint,Copias from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Imprime = rd1("NoPrint").ToString
                Copias = rd1("Copias").ToString()
            End If
        End If
        rd1.Close() : cnn1.Close()


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
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
"select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Impresora = rd1(0).ToString
            End If
        Else
            Impresora = "PRED"
        End If
        rd1.Close() : cnn1.Close()

        If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error() : Exit Sub
        If Impresora = "PRED" Then
            If Tamaño = "80" Then
                For t As Integer = 1 To Copias
                    pVenta80.Print()
                Next
            End If
            If Tamaño = "58" Then
                For t As Integer = 1 To Copias
                    pVenta58.Print()
                Next
            End If
        Else
            If Tamaño = "80" Then
                For t As Integer = 1 To Copias
                    pVenta80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pVenta80.Print()
                Next
            End If
            If Tamaño = "58" Then
                For t As Integer = 1 To Copias
                    pVenta58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pVenta58.Print()
                Next
            End If
        End If
        My.Application.DoEvents()

        'Actualiza estados de pedido para la tienda
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "update Pedidos_Tienda set Status=1, Repartidor='" & TextBox1.Text & "', Id_Status=2, Estado_Pago='Pago aceptado',Sube=0 where Id_Orden=" & cbofolio.Text
            cmd3.ExecuteNonQuery()

            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try

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
        rd1.Close() : cnn1.Close()

        Limpiar_datos()
        box_Pago.Visible = False

        If pide = "1" Then
            lblusuario.Text = usu
            txtusuario.Text = contra
        End If

        cbofolio.Focus().Equals(True)
        MYFOLIO = 0
    End Sub

    Private Sub Termina_Error()
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "update Pedidos_Tienda set Status=1, Repartidor='" & TextBox1.Text & "', Id_Status=2, Estado_Pago='Pago aceptado',Sube=0 where Id_Orden=" & cbofolio.Text
            cmd3.ExecuteNonQuery()

            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try
        Limpiar_datos()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button1.Focus().Equals(True)
        End If
    End Sub

    Private Sub pVenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVenta80.PrintPage

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

        Dim ligaqr As String = ""
        Dim whats As String = DatosRecarga("Whatsapp")

        Dim autofact As String = DatosRecarga("LinkAuto")
        Dim siqr As String = DatosRecarga2("LinkAuto")

        Dim pie As String = ""
        Dim TOTALPRODUCTOS As Double = 0


        If whats <> "" Then
            ligaqr = "http://wa.me/" & whats
        End If

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
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 FROM Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString


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
            e.Graphics.DrawString("NOTA DE VENTA", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 280, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 270, Y, sf)
            Y += 13

            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5

                If txtdireccion.Text <> "" Then

                    Dim caracteresPorLinea As Integer = 35
                    Dim texto As String = txtdireccion.Text
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                        Y += 13
                        inicio += caracteresPorLinea
                    End While

                End If
                Y += 3
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If


            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 13
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 195, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            For LUFFY = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(LUFFY).Cells(0).Value.ToString <> "" And grdcaptura.Rows(LUFFY).Cells(1).Value.ToString = "" Then

                    Continue For
                End If

                Dim CODIGO As String = grdcaptura.Rows(LUFFY).Cells(0).Value.ToString
                Dim DESCRIPCION As String = grdcaptura.Rows(LUFFY).Cells(1).Value.ToString
                Dim UNIDAD As String = grdcaptura.Rows(LUFFY).Cells(2).Value.ToString
                Dim CANTIDAD As Double = grdcaptura.Rows(LUFFY).Cells(3).Value.ToString
                Dim PRECIO As Double = grdcaptura.Rows(LUFFY).Cells(4).Value.ToString
                Dim TOTAL As Double = grdcaptura.Rows(LUFFY).Cells(5).Value.ToString

                e.Graphics.DrawString(CODIGO, fuente_prods, Brushes.Black, 1, Y)

                Dim caracteresPorLinea1 As Integer = 30
                Dim texto1 As String = DESCRIPCION
                Dim inicio1 As Integer = 0
                Dim longitudTexto1 As Integer = texto1.Length

                While inicio1 < longitudTexto1
                    Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                    Dim bloque1 As String = texto1.Substring(inicio1, longitudBloque1)
                    e.Graphics.DrawString(bloque1, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 52, Y)
                    Y += 13
                    inicio1 += caracteresPorLinea1
                End While
                Y += 10
                e.Graphics.DrawString(CANTIDAD, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString(UNIDAD, fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 110, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(PRECIO, 2), fuente_prods, Brushes.Black, 193, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(TOTAL, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 18
                TOTALPRODUCTOS = TOTALPRODUCTOS + 1
            Next
            Y += 10
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & TOTALPRODUCTOS, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txt_subtotal.Text, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 18

            e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(CDec(txt_total.Text) - CDec(txt_subtotal.Text), 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 18

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 13.5
            End If

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txt_total.Text, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txt_total.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 20
            End If

            If CDbl(txtCambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtCambio.Text, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 20
            End If

            For gojo As Integer = 0 To grdpago.Rows.Count - 1
                Dim FORMAPAGO As String = grdpago.Rows(gojo).Cells(0).Value.ToString
                Dim montoforma As Double = grdpago.Rows(gojo).Cells(3).Value.ToString

                If montoforma > 0 Then
                    e.Graphics.DrawString("Pago con " & FORMAPAGO & "", fuente_prods, Brushes.Black, 1, Y)
                    If Len("Pago con " & FORMAPAGO & "") > 26 Then
                        Y += 13.5
                    End If
                    e.Graphics.DrawString(simbolo & FormatNumber(montoforma, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 13.5
                End If
            Next

            If CDbl(txtResta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtResta.Text, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 20
            End If
            Y += 10
            Dim caracteresPorLinea2 As Integer = 30
            Dim texto2 As String = pie
            Dim inicio2 As Integer = 0
            Dim longitudTexto2 As Integer = texto2.Length

            While inicio2 < longitudTexto2
                Dim longitudBloque2 As Integer = Math.Min(caracteresPorLinea2, longitudTexto2 - inicio2)
                Dim bloque2 As String = texto2.Substring(inicio2, longitudBloque2)
                e.Graphics.DrawString(bloque2, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio2 += caracteresPorLinea2
            End While

            Y += 7
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 137, Y, sc)
            Y += 20

            'para el qr

            Dim autofac As Integer = 0
            Dim linkauto As String = ""
            Dim siqrwhats As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='AutoFac'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    autofac = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='LinkAuto'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    linkauto = rd1(0).ToString
                    siqr = rd1(1).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='WhatsApp'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    siqrwhats = rd1(1).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If siqrwhats = 1 Then
                If ligaqr <> "" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = ligaqr
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Escríbenos por Whatsapp", fuente_datos, Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawImage(ima, 50, CInt(Y), 85, 85)
                    Y += 60

                    picQR.Image = Nothing
                End If
            End If
            Y += 35

            If autofac = 1 Then

                If siqr = "1" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = linkauto
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Codigo para facturar:", fuente_datos, Brushes.Black, 1, Y)
                    Y += 25
                    e.Graphics.DrawString(Trim(cadenafact), fuente_datos, Brushes.Black, 1, Y)
                    Y += 25
                    ' Usa Using para garantizar la liberación de recursos de la fuente
                    e.Graphics.DrawString("Realiza tu factura aqui", fuente_datos, Brushes.Black, 1, Y)
                    Y += 10
                    ' Dibuja la imagen en el contexto gráfico
                    e.Graphics.DrawImage(ima, 50, CInt(Y + 15), 85, 85)
                    Y += 20

                End If

            Else

            End If

            e.HasMorePages = False
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        box_Pago.Visible = False
    End Sub

    Private Sub pVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVenta58.PrintPage

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

        Dim ligaqr As String = ""
        Dim whats As String = DatosRecarga("Whatsapp")

        Dim autofact As String = DatosRecarga("LinkAuto")
        Dim siqr As String = DatosRecarga2("LinkAuto")

        Dim pie As String = ""
        Dim TOTALPRODUCTOS As Double = 0


        If whats <> "" Then
            ligaqr = "http://wa.me/" & whats
        End If

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
                        e.Graphics.DrawImage(Logotipo, 30, 0, 1100, 110)
                        Y += 153
                    End If
                End If
            Else
                Y = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    pie = rd1("Pie1").ToString


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
            e.Graphics.DrawString("NOTA DE VENTA", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 280, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 13

            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5

                If txtdireccion.Text <> "" Then

                    Dim caracteresPorLinea As Integer = 35
                    Dim texto As String = txtdireccion.Text
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                        Y += 13
                        inicio += caracteresPorLinea
                    End While

                End If
                Y += 3
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If


            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 13
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 133, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            For LUFFY = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(LUFFY).Cells(0).Value.ToString <> "" And grdcaptura.Rows(LUFFY).Cells(1).Value.ToString = "" Then

                    Continue For
                End If

                Dim CODIGO As String = grdcaptura.Rows(LUFFY).Cells(0).Value.ToString
                Dim DESCRIPCION As String = grdcaptura.Rows(LUFFY).Cells(1).Value.ToString
                Dim UNIDAD As String = grdcaptura.Rows(LUFFY).Cells(2).Value.ToString
                Dim CANTIDAD As Double = grdcaptura.Rows(LUFFY).Cells(3).Value.ToString
                Dim PRECIO As Double = grdcaptura.Rows(LUFFY).Cells(4).Value.ToString
                Dim TOTAL As Double = grdcaptura.Rows(LUFFY).Cells(5).Value.ToString

                e.Graphics.DrawString(CODIGO, fuente_prods, Brushes.Black, 1, Y)

                Dim caracteresPorLinea1 As Integer = 30
                Dim texto1 As String = DESCRIPCION
                Dim inicio1 As Integer = 0
                Dim longitudTexto1 As Integer = texto1.Length

                While inicio1 < longitudTexto1
                    Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                    Dim bloque1 As String = texto1.Substring(inicio1, longitudBloque1)
                    e.Graphics.DrawString(bloque1, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 52, Y)
                    Y += 13
                    inicio1 += caracteresPorLinea1
                End While
                Y += 10
                e.Graphics.DrawString(CANTIDAD, fuente_prods, Brushes.Black, 45, Y, sf)
                e.Graphics.DrawString(UNIDAD, fuente_prods, Brushes.Black, 50, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 100, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(PRECIO, 2), fuente_prods, Brushes.Black, 133, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(TOTAL, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 18
                TOTALPRODUCTOS = TOTALPRODUCTOS + 1
            Next
            Y += 10
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & TOTALPRODUCTOS, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txt_subtotal.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(CDec(txt_total.Text) - CDec(txt_subtotal.Text), 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13.5
            End If

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txt_total.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txt_total.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 20
            End If

            If CDbl(txtCambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtCambio.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 20
            End If

            For gojo As Integer = 0 To grdpago.Rows.Count - 1
                Dim FORMAPAGO As String = grdpago.Rows(gojo).Cells(0).Value.ToString
                Dim montoforma As Double = grdpago.Rows(gojo).Cells(3).Value.ToString

                If montoforma > 0 Then
                    e.Graphics.DrawString("Pago con " & FORMAPAGO & "", fuente_prods, Brushes.Black, 1, Y)
                    If Len("Pago con " & FORMAPAGO & "") > 26 Then
                        Y += 13.5
                    End If
                    e.Graphics.DrawString(simbolo & FormatNumber(montoforma, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 13.5
                End If
            Next

            If CDbl(txtResta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtResta.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 20
            End If
            Y += 10
            Dim caracteresPorLinea2 As Integer = 30
            Dim texto2 As String = pie
            Dim inicio2 As Integer = 0
            Dim longitudTexto2 As Integer = texto2.Length

            While inicio2 < longitudTexto2
                Dim longitudBloque2 As Integer = Math.Min(caracteresPorLinea2, longitudTexto2 - inicio2)
                Dim bloque2 As String = texto2.Substring(inicio2, longitudBloque2)
                e.Graphics.DrawString(bloque2, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio2 += caracteresPorLinea2
            End While

            Y += 7
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)
            Y += 20

            'para el qr

            Dim autofac As Integer = 0
            Dim linkauto As String = ""
            Dim siqrwhats As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='AutoFac'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    autofac = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='LinkAuto'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    linkauto = rd1(0).ToString
                    siqr = rd1(1).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='WhatsApp'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    siqrwhats = rd1(1).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If siqrwhats = 1 Then
                If ligaqr <> "" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = ligaqr
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Escríbenos por Whatsapp", fuente_datos, Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawImage(ima, 50, CInt(Y), 85, 85)
                    Y += 60

                    picQR.Image = Nothing
                End If
            End If
            Y += 35

            If autofac = 1 Then

                If siqr = "1" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = linkauto
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Codigo para facturar:", fuente_datos, Brushes.Black, 1, Y)
                    Y += 25
                    e.Graphics.DrawString(Trim(cadenafact), fuente_datos, Brushes.Black, 1, Y)
                    Y += 25
                    ' Usa Using para garantizar la liberación de recursos de la fuente
                    e.Graphics.DrawString("Realiza tu factura aqui", fuente_datos, Brushes.Black, 1, Y)
                    Y += 10
                    ' Dibuja la imagen en el contexto gráfico
                    e.Graphics.DrawImage(ima, 50, CInt(Y + 15), 85, 85)
                    Y += 20

                End If

            Else

            End If

            e.HasMorePages = False
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub
End Class