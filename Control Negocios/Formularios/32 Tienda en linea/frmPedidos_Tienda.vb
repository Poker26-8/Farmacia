Public Class frmPedidos_Tienda
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
        cbofolio.Items.Clear()
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
End Class