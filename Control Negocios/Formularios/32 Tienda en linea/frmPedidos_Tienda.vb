Imports System.IO
Imports System.Net
Public Class frmPedidos_Tienda

    Public Viene_De As String = ""
    Private Sub frmPedidos_Tienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        txtresta.Text = "0.00"

        Try
            cnn2.Close() : cnn2.Open()

            'Obtiene datos base
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Pedidos_Tienda where Id_Orden=" & cbofolio.Text
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cbonombre.Text = rd2("Cliente").ToString()
                    txtdireccion.Text = rd2("Direccion").ToString()

                    id_cliente_t = rd2("Id_Cliente").ToString()

                    lblNumCliente.Text = get_id_cliente(id_cliente_t)

                    txt_referencia.Text = rd2("Referencia").ToString()
                    txt_metodo_pago.Text = rd2("Tipo_Pago").ToString()

                    tipo_envio = rd2("Tipo_Envio").ToString()

                    If tipo_envio = 9 Then
                        lbltipo_envio.Text = "Envío a domicilio"
                    ElseIf tipo_envio = 10 Then
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

            'Obtiene datos de los productos
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Det_Pedidos_Tienda where Id_Orden=" & cbofolio.Text
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
                        "select * from Productos where Codigo='" & cod_prod & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            nom_prod = rd3("Nombre").ToString()
                            uni_prod = rd3("UVenta").ToString()
                            exi_prod = rd3("Existencia").ToString()
                        End If
                    End If
                    rd3.Close()

                    tot_prod = can_prod * pre_prod

                    grdcaptura.Rows.Add(cod_prod, nom_prod, uni_prod, can_prod, FormatNumber(pre_prod, 4), FormatNumber(tot_prod, 4), exi_prod)
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

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Pedidos_Tienda where Id_Orden=" & cbofolio.Text
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    subtotal_ped = rd2("Subtotal").ToString()
                    envio_ped = rd2("Envio").ToString()
                    total_ped = rd2("Total").ToString()

                    If txt_metodo_pago.Text = "PAGO CONTRA ENTREGA (PCE)" Then
                        txtresta.Text = FormatNumber(total_ped, 2)
                    Else
                        txtacuenta.Text = FormatNumber(total_ped, 2)
                    End If
                End If
            End If
            rd2.Close()
            cnn2.Close()

            txt_subtotal.Text = FormatNumber(subtotal_ped, 2)
            txt_envio.Text = FormatNumber(envio_ped, 2)
            txt_total.Text = FormatNumber(total_ped, 2)
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
                "select * from Clientes where Id_Tienda=" & id_tienda
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
        cbonombre.Items.Clear()
        cbonombre.Text = ""
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
        txtresta.Text = "0.00"
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

        'Selecciona el tipo de pago desde la tabla de pago



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
                        "select * from Productos where Codigo='" & codigo_p & "'"
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
                    "select * from Usuarios where Clave='" & txtusuario.Text & "'"
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
            cmd2.CommandText = "select * from Ticket"
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
End Class