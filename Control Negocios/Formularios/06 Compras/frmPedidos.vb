Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPedidos
    Dim alias_pedidos As String = ""
    Dim tipo_impre As String = ""

    '    Private Sub cbonombre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbonombre.KeyDown
    '        If e.KeyCode = Keys.F3 Then
    '            frmBuscaPedidos.Show()
    '        End If
    '    End Sub

    '    Private Sub cboprov_DropDown(sender As System.Object, e As System.EventArgs)
    '        cboprov.Items.Clear()
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select Compania from Proveedores order by Compania"
    '            rd1 = cmd1.ExecuteReader
    '            Do While rd1.Read
    '                If rd1.HasRows Then cboprov.Items.Add(
    '                    rd1(0).ToString
    '                    )
    '            Loop
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cboprov_SelectedValueChanged(sender As System.Object, e As System.EventArgs)
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Proveedores where Compania='" & cboprov.Text & "'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    txtid_prov.Text = rd1("Id").ToString
    '                    txtcorreo.Text = rd1("Correo").ToString
    '                    If txtcorreo.Text = "" Then
    '                        MsgBox("El pedido no se enviará por correo electrónico al proveedor ya que no se encontró una cuenta de correo asosiada a este proveedor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                    End If
    '                End If
    '            Else
    '                MsgBox("Proveedor no registrado, revisa la información o regístralo en el catálogo de proveedores.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '            End If
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cboprov_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
    '        e.KeyChar = UCase(e.KeyChar)
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            Try
    '                cnn1.Close() : cnn1.Open()

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select * from Proveedores where Compania='" & cboprov.Text & "'"
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        txtid_prov.Text = rd1("Id").ToString
    '                        txtcorreo.Text = rd1("Correo").ToString
    '                        If txtcorreo.Text = "" Then
    '                            MsgBox("El pedido no se enviará por correo electrónico al proveedor ya que no se encontró una cuenta de correo asosiada a este proveedor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                        End If
    '                    End If
    '                Else
    '                    MsgBox("Proveedor no registrado, revisa la información o regístralo en el catálogo de proveedores.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                End If
    '                rd1.Close()
    '                cnn1.Close()
    '            Catch ex As Exception
    '                MessageBox.Show(ex.ToString)
    '                cnn1.Close()
    '            End Try
    '            cbopedido.Focus().Equals(True)
    '        End If
    '    End Sub

    '    Private Sub cbopedido_DropDown(sender As System.Object, e As System.EventArgs)
    '        cbopedido.Items.Clear()
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select Num from Pedidos where Proveedor='" & cboprov.Text & "'"
    '            rd1 = cmd1.ExecuteReader
    '            Do While rd1.Read
    '                If rd1.HasRows Then cbopedido.Items.Add(
    '                    rd1(0).ToString
    '                    )
    '            Loop
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cbopedido_SelectedValueChanged(sender As System.Object, e As System.EventArgs)
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Pedidos where Proveedor='" & cboprov.Text & "' and Num='" & cbopedido.Text & "'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    MsgBox("Ya capuraste un pedido bajo este número.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                    grdcaptura.Rows.Clear()
    '                    Dim cuenta As Double = 0

    '                    cbonombre.Enabled = False
    '                    txtcodigo.Enabled = False

    '                    cbopedido.Text = rd1("Num").ToString
    '                    txtTotal.Text = FormatNumber(rd1("Total").ToString, 2)
    '                    txtmonto.Text = FormatNumber(rd1("Anticipo").ToString, 2)
    '                    cboTpago.Text = rd1("TipoPago").ToString
    '                    cboBanco.Text = rd1("Banco").ToString
    '                    txtref.Text = rd1("Referencia").ToString

    '                    'Llena los datos del pedido
    '                    cnn2.Close() : cnn2.Open()
    '                    cmd2 = cnn2.CreateCommand
    '                    cmd2.CommandText =
    '                        "select * from PedidosDet where NumPed='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '                    rd2 = cmd2.ExecuteReader
    '                    Do While rd2.Read
    '                        If rd2.HasRows Then
    '                            grdcaptura.Rows.Add(
    '                                rd2("Codigo").ToString,
    '                                rd2("Nombre").ToString,
    '                                rd2("Unidad").ToString,
    '                                rd2("Cantidad").ToString,
    '                                FormatNumber(rd2("Precio").ToString, 2),
    '                                "",
    '                                ""
    '                                )
    '                            cuenta += CDbl(rd2("Cantidad").ToString)
    '                        End If
    '                    Loop
    '                    rd2.Close()
    '                    cnn2.Close()

    '                    txtProds.Text = cuenta

    '                    btncopia.Enabled = True
    '                    btnguarda.Enabled = False
    '                    btncancela.Enabled = True
    '                End If
    '            End If
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cbopedido_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
    '        e.KeyChar = UCase(e.KeyChar)
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            If cbopedido.Text <> "" Then
    '                Try
    '                    cnn1.Close() : cnn1.Open()

    '                    cmd1 = cnn1.CreateCommand
    '                    cmd1.CommandText =
    '                        "select * from Pedidos where Proveedor='" & cboprov.Text & "' and Num='" & cbopedido.Text & "'"
    '                    rd1 = cmd1.ExecuteReader
    '                    If rd1.HasRows Then
    '                        If rd1.Read Then
    '                            'Llena los datos del pedido
    '                            grdcaptura.Rows.Clear()
    '                            Dim cuenta As Double = 0

    '                            cbonombre.Enabled = False
    '                            txtcodigo.Enabled = False

    '                            cbopedido.Text = rd1("Num").ToString
    '                            txtTotal.Text = FormatNumber(rd1("Total").ToString, 2)
    '                            txtmonto.Text = FormatNumber(rd1("Anticipo").ToString, 2)
    '                            cboTpago.Text = rd1("TipoPago").ToString
    '                            cboBanco.Text = rd1("Banco").ToString
    '                            txtref.Text = rd1("Referencia").ToString

    '                            'Llena los datos del pedido
    '                            cnn2.Close() : cnn2.Open()
    '                            cmd2 = cnn2.CreateCommand
    '                            cmd2.CommandText =
    '                                "select * from PedidosDet where NumPed='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '                            rd2 = cmd2.ExecuteReader
    '                            Do While rd2.Read
    '                                If rd2.HasRows Then
    '                                    grdcaptura.Rows.Add(
    '                                        rd2("Codigo").ToString,
    '                                        rd2("Nombre").ToString,
    '                                        rd2("Unidad").ToString,
    '                                        rd2("Cantidad").ToString,
    '                                        FormatNumber(rd2("Precio").ToString, 2),
    '                                        "",
    '                                        ""
    '                                        )
    '                                    cuenta += CDbl(rd2("Cantidad").ToString)
    '                                End If
    '                            Loop
    '                            rd2.Close()
    '                            cnn2.Close()

    '                            txtProds.Text = cuenta

    '                            btncopia.Enabled = True
    '                            btnguarda.Enabled = False
    '                            btncancela.Enabled = True
    '                            btncopia.Focus().Equals(True)
    '                        End If
    '                    Else
    '                        cbonombre.Focus().Equals(True)
    '                    End If
    '                    rd1.Close()
    '                    cnn1.Close()
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString)
    '                    cnn1.Close()
    '                End Try
    '            End If
    '        End If
    '    End Sub

    '    Private Sub frmPedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '        Dim varTot As Double = 0
    '        Dim conteo As Double = 0

    '        grdcaptura.Rows.Clear()
    '        cboprov.Focus().Equals(True)
    '        btncopia.Enabled = False
    '        btncancela.Enabled = False
    '        tipo_impre = ""

    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from tb_moneda where nombre_moneda='PESO' or nombre_moneda='PESOS'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    txtmoneda.Text = FormatNumber(rd1("tipo_cambio").ToString, 2)
    '                    cbomoneda.Tag = rd1("id").ToString
    '                    cbomoneda.Items.Add(rd1("nombre_moneda").ToString)
    '                    cbomoneda.SelectedIndex = 0
    '                End If
    '            Else
    '                cbomoneda.Tag = ""
    '            End If
    '            rd1.Close()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from AuxPedidos"
    '            rd1 = cmd1.ExecuteReader
    '            Do While rd1.Read
    '                If rd1.HasRows Then
    '                    grdcaptura.Rows.Add(
    '                        rd1("Codigo").ToString,
    '                        rd1("Nombre").ToString,
    '                        rd1("Unidad").ToString,
    '                        rd1("Cantidad").ToString,
    '                        FormatNumber(rd1("Precio").ToString, 2),
    '                        rd1("Existencia").ToString,
    '                        rd1("Minimo").ToString
    '                        )
    '                    varTot = varTot + (CDec(rd1("Cantidad").ToString) * CDec(rd1("Precio").ToString))
    '                    conteo = conteo + CDec(rd1("Cantidad").ToString)
    '                End If
    '            Loop
    '            rd1.Close()

    '            Dim total As Double = 0

    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    cboprov.Text = rd1("Proveedor").ToString
    '                    cbopedido.Text = rd1("Num").ToString
    '                    total = rd1("Total").ToString
    '                End If
    '            End If
    '            rd1.Close()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Proveedores where Compania='" & cboprov.Text & "'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    txtid_prov.Text = rd1("Id").ToString
    '                End If
    '            End If
    '            cnn1.Close()

    '            txtTotal.Text = FormatNumber(varTot, 2)
    '            txtProds.Text = conteo
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try

    '    End Sub

    '    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
    '        cbonombre.Items.Clear()
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select distinct Nombre from Productos where Length(Codigo)<7 and Departamento <> 'SERVICIOS' order by Nombre"
    '            rd1 = cmd1.ExecuteReader
    '            Do While rd1.Read
    '                If rd1.HasRows Then cbonombre.Items.Add(
    '                    rd1(0).ToString
    '                    )
    '            Loop
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cbonombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Productos where Nombre='" & cbonombre.Text & "' and Length(Codigo)<7 and Departamento<>'SERVICIOS'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    txtcodigo.Text = rd1("Codigo").ToString
    '                    txtunidad.Text = rd1("UCompra").ToString
    '                End If
    '            End If
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
    '        e.KeyChar = UCase(e.KeyChar)
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            If cbonombre.Text = "" Then txtcodigo.Focus().Equals(True) : Exit Sub
    '            Try
    '                cnn1.Close() : cnn1.Open()

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select * from Productos where Nombre='" & cbonombre.Text & "' and Length(Codigo)<7 and Departamento<>'SERVICIOS'"
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        txtcodigo.Text = rd1("Codigo").ToString
    '                        txtunidad.Text = rd1("UCompra").ToString
    '                    End If
    '                End If
    '                rd1.Close()

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select * from Productos where CodBarra='" & cbonombre.Text & "'"
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        cbonombre.Text = rd1("Nombre").ToString
    '                        txtcodigo.Text = rd1("Codigo").ToString
    '                        txtunidad.Text = rd1("UCompra").ToString
    '                    End If
    '                End If
    '                rd1.Close()
    '                cnn1.Close()
    '            Catch ex As Exception
    '                MessageBox.Show(ex.ToString)
    '                cnn1.Close()
    '            End Try
    '            txtcodigo.Focus().Equals(True)
    '        End If
    '    End Sub

    '    Private Sub txtcodigo_Click(sender As System.Object, e As System.EventArgs) Handles txtcodigo.Click
    '        txtcodigo.SelectionStart = 0
    '        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    '    End Sub

    '    Private Sub txtcodigo_GotFocus(sender As Object, e As System.EventArgs) Handles txtcodigo.GotFocus
    '        txtcodigo.SelectionStart = 0
    '        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    '    End Sub

    '    Private Sub txtcodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            If txtcodigo.Text <> "" Then
    '                Dim MoneValor As Double = 0

    '                Try
    '                    cnn1.Close() : cnn1.Open()

    '                    cmd1 = cnn1.CreateCommand
    '                    cmd1.CommandText =
    '                        "select tipo_cambio,nombre_moneda from tb_moneda,Productos where Codigo='" & txtcodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
    '                    rd1 = cmd1.ExecuteReader
    '                    If rd1.HasRows Then
    '                        If rd1.Read Then
    '                            lblMoneda.Text = rd1("nombre_moneda").ToString
    '                            lblValor.Text = rd1("tipo_cambio").ToString
    '                            MoneValor = rd1("tipo_cambio").ToString
    '                            If lblValor.Text = "" Then lblValor.Text = "1"
    '                        End If
    '                    Else
    '                        lblValor.Text = "1.00"
    '                    End If
    '                    rd1.Close()

    '                    If Trim(lblMoneda.Text) <> Trim(cbomoneda.Text) Then
    '                        MsgBox("No se puede continuar porque el tipo de moneda del pedido no coincide con el tipo de moneda del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                        rd1.Close()
    '                        cnn1.Close()
    '                        Exit Sub
    '                    End If

    '                    If txtmoneda.Text = "" Then
    '                        MsgBox("Ingresa el valor de la moneda.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                        If txtmoneda.Enabled = True Then
    '                            txtmoneda.Focus().Equals(True)
    '                        End If
    '                        cnn1.Close()
    '                        Exit Sub
    '                    End If

    '                    cmd1 = cnn1.CreateCommand
    '                    cmd1.CommandText =
    '                        "select * from Productos where Codigo='" & txtcodigo.Text & "'"
    '                    rd1 = cmd1.ExecuteReader
    '                    If rd1.HasRows Then
    '                        If rd1.Read Then
    '                            cbonombre.Text = rd1("Nombre").ToString
    '                            txtunidad.Text = rd1("UCompra").ToString
    '                            lblValor.Text = FormatNumber(CDec(rd1("PrecioCompra").ToString) / MoneValor, 4)
    '                            txtprecio.Text = FormatNumber(rd1("PrecioCompra").ToString, 4)
    '                            txtexistencia.Text = rd1("Existencia").ToString
    '                            txtminimo.Text = rd1("Min").ToString
    '                            txtcantidad.Focus().Equals(True)
    '                        End If
    '                    End If
    '                    rd1.Close()
    '                    cnn1.Close()
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString)
    '                    cnn1.Close()
    '                End Try
    '            Else
    '                cboTpago.Focus().Equals(True)
    '            End If
    '        End If
    '    End Sub

    '    Private Sub txtcantidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
    '        If Not IsNumeric(txtcantidad.Text) Then txtcantidad.Text = ""
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            On Error GoTo jiji
    '            If cboprov.Text = "" Then MsgBox("Selecciona un proveedor para continuar con el pedido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboprov.Focus().Equals(True) : Exit Sub
    '            If cbopedido.Text = "" Then MsgBox("Escribe el número de pedido para continuar con la captura.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbopedido.Focus().Equals(True) : Exit Sub
    '            If cbonombre.Text = "" Then cbonombre.Focus().Equals(True)
    '            If Trim(lblMoneda.Text) <> Trim(cbomoneda.Text) Then
    '                MsgBox("No se puede continuar porque el tipo de moneda del pedido no coincide con el tipo de moneda del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                Exit Sub
    '            End If
    '            If txtunidad.Text = "" Then txtcodigo.Focus().Equals(True) : Exit Sub
    '            If txtcantidad.Text = "" Then txtcantidad.Focus().Equals(True) : Exit Sub
    '            If txtprecio.Text = "" Then txtcodigo.Focus().Equals(True) : Exit Sub

    '            Dim suma As Double = 0
    '            Dim conteo As Double = 0
    '            Dim precio As Double = FormatNumber(txtprecio.Text, 4)

    '            grdcaptura.Rows.Add(
    '                txtcodigo.Text,
    '                cbonombre.Text,
    '                txtunidad.Text,
    '                txtcantidad.Text,
    '                FormatNumber(txtprecio.Text, 4),
    '                txtexistencia.Text,
    '                txtminimo.Text
    '                )
    '            grdcaptura.Refresh()

    '            For t As Integer = 0 To grdcaptura.Rows.Count - 1
    '                Dim cantidad As Double = grdcaptura.Rows(t).Cells(3).Value.ToString
    '                Dim precio_g As Double = grdcaptura.Rows(t).Cells(4).Value.ToString

    '                Dim total As Double = cantidad * precio_g
    '                suma = suma + total
    '                conteo = conteo + cantidad
    '            Next
    '            suma = FormatNumber(suma, 2)
    '            txtTotal.Text = FormatNumber(suma, 2)
    '            txtProds.Text = conteo

    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "insert into AuxPedidos(Num,Proveedor,Total,Codigo,Nombre,Unidad,Precio,Cantidad,Existencia,Minimo) values('" & cbopedido.Text & "','" & cboprov.Text & "'," & suma & ",'" & txtcodigo.Text & "','" & cbonombre.Text & "','" & txtunidad.Text & "'," & precio & "," & txtcantidad.Text & "," & txtexistencia.Text & "," & txtminimo.Text & ")"
    '            If cmd1.ExecuteNonQuery() Then
    '            Else
    '                MsgBox("Error inesperado, puede ser causado por un error en la estructura del nombre de algún producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '            End If

    '            cnn1.Close()
    'jiji:
    '            'MsgBox(Err.Description)
    '            txtcodigo.Text = ""
    '            cbonombre.Text = ""
    '            txtunidad.Text = ""
    '            txtcantidad.Text = ""
    '            txtprecio.Text = "0.00"
    '            txtexistencia.Text = ""
    '            txtminimo.Text = ""

    '            lblMoneda.Text = ""
    '            lblValor.Text = "0.00"

    '            txtTotal.Text = FormatNumber(txtTotal.Text, 2)
    '            cbomoneda.Enabled = False
    '            txtmoneda.Enabled = False
    '            cbonombre.Focus().Equals(True)

    '        End If
    '    End Sub

    '    Private Sub btnlimpia_Click(sender As System.Object, e As System.EventArgs) Handles btnlimpia.Click
    '        lblMoneda.Text = ""
    '        lblValor.Text = ""
    '        cbomoneda.Enabled = True
    '        txtmoneda.Text = "1.00"
    '        txtusuario.Text = ""
    '        cboprov.Items.Clear()
    '        cboprov.Text = ""
    '        cbopedido.Items.Clear()
    '        cbopedido.Text = ""
    '        txtcorreo.Text = ""
    '        txtid_prov.Text = ""
    '        txtcodigo.Text = ""
    '        cbonombre.Items.Clear()
    '        cbonombre.Text = ""
    '        txtunidad.Text = ""
    '        txtcantidad.Text = ""
    '        txtprecio.Text = "0.00"
    '        txtexistencia.Text = ""
    '        txtminimo.Text = ""
    '        grdcaptura.Rows.Clear()
    '        txtTotal.Text = "0.00"
    '        txtProds.Text = "0"
    '        cboTpago.Items.Clear()
    '        cboTpago.Text = ""
    '        cboBanco.Items.Clear()
    '        cboBanco.Text = ""
    '        txtref.Text = ""
    '        txtmonto.Text = "0.00"
    '        btncopia.Enabled = False
    '        btncancela.Enabled = False
    '        btnguarda.Enabled = True
    '        cboBanco.Enabled = True
    '        txtref.Enabled = True
    '        cbonombre.Enabled = True
    '        txtcodigo.Enabled = True

    '        cnn1.Close() : cnn1.Open()
    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "delete from AuxPedidos"
    '        cmd1.ExecuteNonQuery()
    '        cnn1.Close()
    '    End Sub

    '    Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
    '        If grdcaptura.Rows.Count > 0 Then
    '            cnn1.Close() : cnn1.Open()
    '            Dim suma As Double = 0, conteo As Double = 0
    '            Dim g As Integer = grdcaptura.CurrentRow.Index

    '            txtcodigo.Text = grdcaptura.Rows(g).Cells(0).Value.ToString
    '            cbonombre.Text = grdcaptura.Rows(g).Cells(1).Value.ToString
    '            txtunidad.Text = grdcaptura.Rows(g).Cells(2).Value.ToString
    '            txtcantidad.Text = grdcaptura.Rows(g).Cells(3).Value.ToString
    '            txtprecio.Text = FormatNumber(grdcaptura.Rows(g).Cells(4).Value.ToString)
    '            txtexistencia.Text = grdcaptura.Rows(g).Cells(5).Value.ToString
    '            txtminimo.Text = grdcaptura.Rows(g).Cells(6).Value.ToString

    '            grdcaptura.Rows.Remove(grdcaptura.Rows(g))

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "delete from AuxPedidos where Codigo='" & txtcodigo.Text & "' and Cantidad=" & txtcantidad.Text & ""
    '            cmd1.ExecuteNonQuery()
    '            cnn1.Close()

    '            For soraka As Integer = 0 To grdcaptura.Rows.Count - 1
    '                Dim cantid As Double = grdcaptura.Rows(soraka).Cells(3).Value.ToString
    '                Dim precio As Double = grdcaptura.Rows(soraka).Cells(4).Value.ToString
    '                Dim total As Double = cantid * precio

    '                suma = suma + total
    '                conteo = conteo + cantid
    '            Next

    '            txtTotal.Text = FormatNumber(suma, 2)
    '            txtProds.Text = conteo
    '            txtcantidad.Focus().Equals(True)
    '        End If
    '    End Sub

    '    Private Sub btnguarda_Click(sender As System.Object, e As System.EventArgs) Handles btnguarda.Click
    '        If cboprov.Text = "" Then MsgBox("Selecciona un proveedor para realizar el pedido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboprov.Focus().Equals(True) : Exit Sub
    '        If cbopedido.Text = "" Then MsgBox("Escribe el número de pedido para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbopedido.Focus().Equals(True) : Exit Sub
    '        If lblusuario.Text = "" Then MsgBox("Ingresa tu conraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Exit Sub

    '        'Variables de pago
    '        Dim tipo_pago As String = ""
    '        Dim campo_pago As String = ""
    '        Dim banco As String = ""
    '        Dim refe As String = ""
    '        Dim monto As Double = 0

    '        Dim fecha As String = Date.Now.ToString("yyyy-MM-dd")
    '        Dim hora As String = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")

    '        Dim id_prov As Integer = 0


    '        cnn1.Close() : cnn1.Open()

    '        '[°]. Valida sí ya existe o no un pedido
    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select * FROM Pedidos where Num='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                MsgBox("Ya hay un pedido para este proveedor registrado bajo ese número.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                rd1.Close()
    '                cnn1.Open()
    '                cbopedido.Focus().Equals(True)
    '                Exit Sub
    '            End If
    '        End If
    '        rd1.Close()

    '        '[°]. Validaciones del proveedor
    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select Id from Proveedores where Compania='" & cboprov.Text & "'"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                id_prov = rd1(0).ToString
    '            End If
    '        Else
    '            MsgBox("El proveedor no existe en el catálogo, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '            rd1.Close()
    '            cnn1.Close()
    '            cboprov.Focus().Equals(True)
    '            Exit Sub
    '        End If
    '        rd1.Close()
    '        cnn1.Close()
    '        '[°]. Validación de productos en el grid
    '        If grdcaptura.Rows.Count <= 0 Then MsgBox("Agrega productos al pedido para continuar con el proceso.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : cnn1.Close() : Exit Sub

    '        If MsgBox("¿Deseas guardar este pedido?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
    '            For hd As Integer = 0 To grdcaptura.Rows.Count - 1
    '                If grdcaptura.Rows(hd).Cells(3).Value.ToString = "" Then
    '                    MsgBox("Falta una cantidad para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                    grdcaptura.Rows(hd).Cells(3).Selected = True
    '                    cnn1.Close()
    '                    Exit Sub
    '                End If

    '                If grdcaptura.Rows(hd).Cells(4).Value.ToString = "" Then
    '                    MsgBox("Falta un precio para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                    grdcaptura.Rows(hd).Cells(4).Selected = True
    '                    cnn1.Close()
    '                    Exit Sub
    '                End If
    '            Next

    '            '[°]. Valida el pago/anticipo y sus componentes
    '            If cboTpago.Text <> "" Then
    '                If cboTpago.Text = "EFECTIVO" Or cboTpago.Text = "TARJETA" Or cboTpago.Text = "TRANSFERENCIA" Or cboTpago.Text = "OTRO" Then
    '                    Select Case cboTpago.Text
    '                        Case Is = "EFECTIVO"
    '                            tipo_pago = "EFECTIVO"
    '                            campo_pago = "Efectivo"
    '                            banco = ""
    '                            refe = ""
    '                            monto = txtmonto.Text
    '                        Case Is = "TARJETA"
    '                            tipo_pago = "TARJETA"
    '                            campo_pago = "Tarjeta"
    '                            banco = cboBanco.Text
    '                            refe = txtref.Text
    '                            monto = txtmonto.Text
    '                        Case Is = "TRANSFERENCIA"
    '                            tipo_pago = "TRANSFERENCIA"
    '                            campo_pago = "Transfe"
    '                            banco = cboBanco.Text
    '                            refe = txtref.Text
    '                            monto = txtmonto.Text
    '                        Case Is = "OTRO"
    '                            tipo_pago = "OTRO"
    '                            campo_pago = "Otro"
    '                            banco = cboBanco.Text
    '                            refe = txtref.Text
    '                            monto = txtmonto.Text
    '                    End Select
    '                Else
    '                    MsgBox("Forma de pago no válida, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                    cboTpago.Focus().Equals(True)
    '                    cnn1.Close()
    '                    Exit Sub
    '                End If
    '            Else
    '                tipo_pago = ""
    '                banco = ""
    '                refe = ""
    '                monto = 0
    '            End If

    '            Dim total As Double = FormatNumber(txtTotal.Text, 2)
    '            monto = FormatNumber(monto, 2)

    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "insert into Pedidos(Num,Proveedor,Total,Anticipo,Fecha,Hora,Status,Usuario,Cargado,TipoPago,Banco,Referencia) values('" & cbopedido.Text & "','" & cboprov.Text & "'," & total & "," & monto & ",'" & fecha & "','" & hora & "',0,'" & alias_pedidos & "',0,'" & tipo_pago & "','" & banco & "','" & refe & "')"
    '            If cmd1.ExecuteNonQuery Then
    '            Else
    '                MsgBox("No se pudo completar un proceso, inténtalo de nuevo más tarde." & vbNewLine & "Sí el problema persiste contacta a tu proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                rd1.Close()
    '                cnn1.Close()
    '                Exit Sub
    '            End If

    '            If monto > 0 Then
    '                Dim MySaldo As Double = 0

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select Saldo from AbonoE where Id=(select MAX(Id) from AbonoE where IdProv=" & id_prov & ")"
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        MySaldo = IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - monto
    '                    Else
    '                        MySaldo = -monto
    '                    End If
    '                Else
    '                    MySaldo = -monto
    '                End If
    '                rd1.Close()

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Abono,Saldo," & campo_pago & ",Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('','','" & cbopedido.Text & "'," & txtid_prov.Text & ",'" & cboprov.Text & "','ANTICIPO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Now, "HH:mm:ss") & "'," & monto & "," & MySaldo & "," & monto & ",'" & banco & "','" & refe & "','" & lblusuario.Text & "',0,0,0)"
    '                cmd1.ExecuteNonQuery()
    '            End If

    '            For sd As Integer = 0 To grdcaptura.Rows.Count - 1
    '                Dim codigo As String = grdcaptura.Rows(sd).Cells(0).Value.ToString
    '                Dim nombre As String = grdcaptura.Rows(sd).Cells(1).Value.ToString
    '                Dim unidad As String = grdcaptura.Rows(sd).Cells(2).Value.ToString
    '                Dim cantid As Double = grdcaptura.Rows(sd).Cells(3).Value.ToString
    '                Dim precio As Double = FormatNumber(grdcaptura.Rows(sd).Cells(4).Value.ToString, 4)
    '                Dim existencia As Double = grdcaptura.Rows(sd).Cells(5).Value.ToString
    '                Dim minimo As Double = grdcaptura.Rows(sd).Cells(6).Value.ToString

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "insert into PedidosDet(NumPed,Proveedor,Codigo,Nombre,Unidad,Precio,Cantidad,Cargado) values('" & cbopedido.Text & "','" & cboprov.Text & "','" & codigo & "','" & nombre & "','" & unidad & "'," & precio & "," & cantid & ",0)"
    '                If cmd1.ExecuteNonQuery Then
    '                Else
    '                    MsgBox("No se pudo completar un proceso, inténtalo de nuevo más tarde." & vbNewLine & "Sí el problema persiste contacta a tu proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                    rd1.Close()
    '                    cnn1.Close()

    '                    cnn2.Close() : cnn2.Open()
    '                    cmd2 = cnn2.CreateCommand
    '                    cmd2.CommandText =
    '                        "delete from Pedidos where Num='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '                    cmd2.ExecuteNonQuery()

    '                    cmd2 = cnn2.CreateCommand
    '                    cmd2.CommandText =
    '                        "delete from AbonoE where NumPedido='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '                    cmd2.ExecuteNonQuery()

    '                    cmd2 = cnn2.CreateCommand
    '                    cmd2.CommandText =
    '                        "delete from PedidosDet where NumPed='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '                    cmd2.ExecuteNonQuery()
    '                    cnn2.Close()
    '                    Exit Sub
    '                End If
    '            Next
    '        Else
    '            rd1.Close()
    '            cnn1.Close()
    '            Exit Sub
    '        End If

    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "delete from AuxPedidos"
    '        cmd1.ExecuteNonQuery()

    '        Dim env_pedi As String = ""

    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select NotasCred from Formatos where Facturas='EnvPedidos'"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                env_pedi = rd1(0).ToString
    '            End If
    '        End If
    '        rd1.Close()

    '        If MsgBox("¿Deseas imprimir el pedido?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
    '            Dim ImprimeEn As String = ""
    '            Dim Impresora As String = ""
    '            Dim tPapel As String = ""
    '            Dim tMilimetros As String = ""
    '            tipo_impre = "NORMAL"

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select NotasCred from Formatos where Facturas='TPapelCP'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    tPapel = rd1(0).ToString
    '                    If tPapel = "CARTA" Or tPapel = "MEDIA CARTA" Then
    '                        ImprimeEn = "ImpreC"
    '                    ElseIf tPapel = "TICKET" Then
    '                        ImprimeEn = "ImpreT"
    '                    Else
    '                        ImprimeEn = ""
    '                    End If
    '                End If
    '            Else
    '                MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de pedidos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                rd1.Close()
    '                cnn1.Close()
    '                btnlimpia.PerformClick()
    '                Exit Sub
    '            End If
    '            rd1.Close()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select NotasCred from Formatos where Facturas='TamImpre'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    tMilimetros = rd1(0).ToString
    '                End If
    '            End If
    '            rd1.Close()

    '            If ImprimeEn <> "" Then
    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select NotasCred from Formatos where Facturas='" & ImprimeEn & "'"
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        Impresora = rd1(0).ToString
    '                    End If
    '                End If
    '                rd1.Close()
    '            Else
    '                MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                cnn1.Close()
    '                btnlimpia.PerformClick()
    '                Exit Sub
    '            End If

    '            If tPapel = "TICKET" Then
    '                If tMilimetros = "80" Then
    '                    pTicket80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                    pTicket80.Print()
    '                End If
    '                If tMilimetros = "58" Then
    '                    pTicket58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                    pTicket58.Print()
    '                End If
    '            End If
    '            If tPapel = "MEDIA CARTA" Then
    '                pMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                pMediaCarta.Print()
    '            End If
    '            If tPapel = "CARTA" Then
    '                pCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                pCarta.Print()
    '            End If
    '            If tPapel = "PDF - CARTA" Then
    '                'Genera PDF y lo guarda en la ruta

    '            End If
    '        End If

    '        If env_pedi = "1" Then
    '            If MsgBox("¿Deseas enviar por correo el pedido a tu proveedor?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
    '                If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\PEDIDOS\" & cboprov.Text & "\Pedido_" & cbopedido.Text & ".pdf") Then
    '                Else
    '                    'Crea el PDF del pedido y lo guarda en la ruta

    '                End If
    '                pCorreo.Visible = True
    '                txtDestino.Focus().Equals(True)
    '                Exit Sub
    '            End If
    '        End If

    '        Insert_Pedido()

    '        cnn1.Close()
    '        tipo_impre = ""
    '        btnlimpia.PerformClick()

    '    End Sub

    '    Private Sub Insert_Pedido()
    '        Dim oData As New ToolKitSQL.oledbdata
    '        Dim sSql As String = ""
    '        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
    '        Dim sinfo As String = ""
    '        Dim dr As DataRow = Nothing
    '        Dim dt As New DataTable

    '        Dim tipo_pago As String = ""
    '        Dim campo_pago As String = ""
    '        Dim banco As String = ""
    '        Dim refe As String = ""
    '        Dim monto As Double = 0

    '        Dim fecha As String = Date.Now.ToString("yyyy-MM-dd")
    '        Dim hora As String = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")

    '        With oData
    '            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
    '                .runSp(a_cnn, "delete from pedidos", sinfo)
    '                .runSp(a_cnn, "delete from pedidosdet", sinfo)
    '                sinfo = ""

    '                '[°]. Valida el pago/anticipo y sus componentes
    '                If cboTpago.Text <> "" Then
    '                    If cboTpago.Text = "EFECTIVO" Or cboTpago.Text = "TARJETA" Or cboTpago.Text = "TRANSFERENCIA" Or cboTpago.Text = "OTRO" Then
    '                        Select Case cboTpago.Text
    '                            Case Is = "EFECTIVO"
    '                                tipo_pago = "EFECTIVO"
    '                                campo_pago = "Efectivo"
    '                                banco = ""
    '                                refe = ""
    '                                monto = txtmonto.Text
    '                            Case Is = "TARJETA"
    '                                tipo_pago = "TARJETA"
    '                                campo_pago = "Tarjeta"
    '                                banco = cboBanco.Text
    '                                refe = txtref.Text
    '                                monto = txtmonto.Text
    '                            Case Is = "TRANSFERENCIA"
    '                                tipo_pago = "TRANSFERENCIA"
    '                                campo_pago = "Transfe"
    '                                banco = cboBanco.Text
    '                                refe = txtref.Text
    '                                monto = txtmonto.Text
    '                            Case Is = "OTRO"
    '                                tipo_pago = "OTRO"
    '                                campo_pago = "Otro"
    '                                banco = cboBanco.Text
    '                                refe = txtref.Text
    '                                monto = txtmonto.Text
    '                        End Select
    '                    Else
    '                        MsgBox("Forma de pago no válida, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                        cboTpago.Focus().Equals(True)
    '                        cnn1.Close()
    '                        Exit Sub
    '                    End If
    '                Else
    '                    tipo_pago = ""
    '                    banco = ""
    '                    refe = ""
    '                    monto = 0
    '                End If

    '                Dim total As Double = FormatNumber(txtTotal.Text, 2)
    '                monto = FormatNumber(monto, 2)

    '                If .runSp(a_cnn, "insert into Pedidos(Num,Proveedor,Total,Anticipo,Fecha,Hora,Status,Usuario,TipoPago,Banco,Referencia) values('" & cbopedido.Text & "','" & cboprov.Text & "'," & total & "," & monto & ",'" & fecha & "','" & hora & "',0,'" & alias_pedidos & "','" & tipo_pago & "','" & banco & "','" & refe & "')") Then

    '                    sinfo = ""
    '                Else
    '                    MsgBox(sinfo)
    '                End If

    '                For sd As Integer = 0 To grdcaptura.Rows.Count - 1

    '                    Dim codigo As String = grdcaptura.Rows(sd).Cells(0).Value.ToString
    '                    Dim nombre As String = grdcaptura.Rows(sd).Cells(1).Value.ToString
    '                    Dim unidad As String = grdcaptura.Rows(sd).Cells(2).Value.ToString
    '                    Dim cantid As Double = grdcaptura.Rows(sd).Cells(3).Value.ToString
    '                    Dim precio As Double = FormatNumber(grdcaptura.Rows(sd).Cells(4).Value.ToString, 4)
    '                    Dim existencia As Double = grdcaptura.Rows(sd).Cells(5).Value.ToString
    '                    Dim minimo As Double = grdcaptura.Rows(sd).Cells(6).Value.ToString

    '                    If .runSp(a_cnn, "insert into PedidosDet(NumPed,Proveedor,Codigo,Nombre,Unidad,Precio,Cantidad) values('" & cbopedido.Text & "','" & cboprov.Text & "','" & codigo & "','" & nombre & "','" & unidad & "'," & precio & "," & cantid & ")") Then
    '                        sinfo = ""
    '                    Else
    '                        MsgBox(sinfo)
    '                    End If

    '                Next
    '                a_cnn.Close()

    '            End If
    '        End With
    '    End Sub

    '    Private Sub PDF_Pedido()
    '        Dim root_name_recibo As String = ""
    '        Dim FileOpen As New ProcessStartInfo
    '        Dim FileNta As New Venta
    '        Dim strServerName As String = Application.StartupPath
    '        Dim crtableLogoninfos As New TableLogOnInfos
    '        Dim crtableLogoninfo As New TableLogOnInfo
    '        Dim crConnectionInfo As New ConnectionInfo
    '        Dim CrTables As Tables
    '        Dim CrTable As Table

    '        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\PEDIDOS\")
    '        root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\PEDIDOS\" & cboprov.Text & "\Pedido_" & MyFolio & ".pdf"
    '    End Sub

    '    Private Sub pTicket80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pTicket80.PrintPage
    '        'Fuentes predefinidas
    '        Dim tipografia As String = "Lucida Sans Typewriter"
    '        'Dim fuente_titulos As New Drawing.Font(tipografia, 12, FontStyle.Bold)
    '        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
    '        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
    '        'Variables
    '        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
    '        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
    '        Dim pen As New Pen(Brushes.Black, 1)
    '        Dim Y As Double = 0
    '        Dim nLogo As String = DatosRecarga("LogoG")
    '        Dim Logotipo As Drawing.Image = Nothing
    '        Dim tLogo As String = DatosRecarga("TipoLogo")
    '        Dim simbolo As String = DatosRecarga("Simbolo")
    '        Dim Pie As String = ""

    '        On Error GoTo kakita

    '        '[°]. Logotipo
    '        If tLogo <> "SIN" Then
    '            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
    '                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
    '            End If
    '            If tLogo = "CUAD" Then
    '                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
    '                Y += 130
    '            End If
    '            If tLogo = "RECT" Then
    '                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
    '                Y += 120
    '            End If
    '        Else
    '            Y = 0
    '        End If

    '        '[°]. Datos del negocio
    '        cnn1.Close() : cnn1.Open()

    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select * from Ticket"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                Pie = rd1("Pie2").ToString
    '                'Razón social
    '                If rd1("Cab0").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
    '                    Y += 12.5
    '                End If
    '                'RFC
    '                If rd1("Cab1").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
    '                    Y += 12.5
    '                End If
    '                'Calle  N°.
    '                If rd1("Cab2").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
    '                    Y += 12
    '                End If
    '                'Colonia
    '                If rd1("Cab3").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
    '                    Y += 12
    '                End If
    '                'Delegación / Municipio - Entidad
    '                If rd1("Cab4").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
    '                    Y += 12
    '                End If
    '                'Teléfono
    '                If rd1("Cab5").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
    '                    Y += 12
    '                End If
    '                'Correo
    '                If rd1("Cab6").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
    '                    Y += 12
    '                End If
    '                Y += 17
    '            End If
    '        Else
    '            Y += 0
    '        End If
    '        rd1.Close()

    '        '[1]. Datos del pedido
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 15
    '        If tipo_impre = "NORMAL" Then
    '            e.Graphics.DrawString("P E D I D O", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
    '            Y += 12
    '        End If
    '        If tipo_impre = "COPIA" Then
    '            e.Graphics.DrawString("C O P I A - P E D I D O", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
    '            Y += 12
    '        End If
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 35

    '        e.Graphics.DrawString("N° Pedido: " & cbopedido.Text, fuente_datos, Brushes.Black, 1, Y)
    '        Y += 13.5
    '        e.Graphics.DrawString("Fecha: " & Date.Now, fuente_datos, Brushes.Black, 1, Y)
    '        Y += 13.5
    '        e.Graphics.DrawString("Usuario: " & alias_pedidos, fuente_datos, Brushes.Black, 1, Y)
    '        Y += 28

    '        '[2]. Datos del proveedor
    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select * from Proveedores where Compania='" & cboprov.Text & "'"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '                Y += 12
    '                e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
    '                Y += 7.5
    '                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '                Y += 15

    '                If rd1("Compania").ToString <> "" Then
    '                    e.Graphics.DrawString("Nombre: " & Mid(rd1("Compania").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
    '                    Y += 13.5
    '                    If Mid(rd1("Compania").ToString, 29, 100) <> "" Then
    '                        e.Graphics.DrawString(Mid(rd1("Compania").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                End If
    '                If rd1("RFC").ToString <> "" Then
    '                    e.Graphics.DrawString("RFC: " & rd1("RFC").ToString, fuente_prods, Brushes.Black, 1, Y)
    '                    Y += 13.5
    '                End If
    '                If rd1("Correo").ToString <> "" Then
    '                    e.Graphics.DrawString("Correo: " & Mid(rd1("Correo").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
    '                    Y += 13.5
    '                    If Mid(rd1("Correo").ToString, 29, 100) <> "" Then
    '                        e.Graphics.DrawString(Mid(rd1("Correo").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                End If
    '                Y += 8
    '                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '                Y += 13
    '            End If
    '        End If
    '        rd1.Close()
    '        cnn1.Close()

    '        e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
    '        e.Graphics.DrawString("Cant.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 75, Y)
    '        e.Graphics.DrawString("P.Unit", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 195, Y, sf)
    '        e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
    '        Y += 7
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 20

    '        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
    '            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
    '            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
    '            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
    '            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
    '            Dim total As Double = FormatNumber(canti * precio, 2)

    '            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
    '            e.Graphics.DrawString(nombre, fuente_prods, Brushes.Black, 60, Y)
    '            Y += 13.5
    '            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 93, Y, sf)
    '            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 97, Y)
    '            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 195, Y, sf)
    '            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
    '            Y += 18
    '        Next

    '        Y += 20
    '        e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
    '        e.Graphics.DrawString(simbolo & FormatNumber(txtTotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
    '        Y += 13
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 15
    '        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & txtProds.Text, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 140, Y, sc)
    '        Y += 7
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 28
    '        If Pie <> "" Then
    '            If Mid(Pie, 1, 36) <> "" Then
    '                e.Graphics.DrawString(Mid(Pie, 1, 36), fuente_prods, Brushes.Black, 1, Y)
    '                Y += 13.5
    '            End If
    '            If Mid(Pie, 37, 72) <> "" Then
    '                e.Graphics.DrawString(Mid(Pie, 37, 72), fuente_prods, Brushes.Black, 1, Y)
    '                Y += 13.5
    '            End If
    '            If Mid(Pie, 73, 107) <> "" Then
    '                e.Graphics.DrawString(Mid(Pie, 73, 107), fuente_prods, Brushes.Black, 1, Y)
    '                Y += 13.5
    '            End If
    '            If Mid(Pie, 108, 144) <> "" Then
    '                e.Graphics.DrawString(Mid(Pie, 108, 144), fuente_prods, Brushes.Black, 1, Y)
    '                Y += 13.5
    '            End If
    '        End If

    '        e.HasMorePages = False
    '        Exit Sub
    'kakita:
    '        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
    '        cnn1.Close()
    '        Exit Sub
    '    End Sub

    '    Private Sub Label11_DoubleClick(sender As System.Object, e As System.EventArgs)
    '        printLine = 0
    '        Contador = 0
    '        pagina = 0
    '        pCarta.Print()
    '    End Sub

    '    Private Sub txtusuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
    '        Dim id_usu As Integer
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            Try
    '                cnn1.Close() : cnn1.Open()

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select * from Usuarios where Clave='" & txtusuario.Text & "'"
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        id_usu = rd1("IdEmpleado").ToString()
    '                        alias_pedidos = rd1("Alias").ToString()
    '                        lblusuario.Text = rd1("Alias").ToString()
    '                    End If
    '                End If
    '                rd1.Close()

    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select * from Permisos where IdEmpleado=" & id_usu
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        If rd1("Comp_Ped").ToString() = True Then
    '                            btnguarda.Focus().Equals(True)
    '                        Else
    '                            MsgBox("No cuentas con permisos suficientes para interactuar con este formulario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                            rd1.Close() : cnn1.Close() : Exit Sub
    '                        End If
    '                    End If
    '                End If
    '                rd1.Close() : cnn1.Close()
    '            Catch ex As Exception
    '                MessageBox.Show(ex.ToString)
    '                cnn1.Close()
    '            End Try
    '            btnguarda.Focus().Equals(True)
    '        End If
    '    End Sub

    '    Private Sub pTicket58_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pTicket58.PrintPage
    '        'Fuentes predefinidas
    '        Dim tipografia As String = "Lucida Sans Typewriter"
    '        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
    '        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
    '        'Variables
    '        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
    '        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
    '        Dim pen As New Pen(Brushes.Black, 1)
    '        Dim Y As Double = 0
    '        Dim nLogo As String = DatosRecarga("LogoG")
    '        Dim Logotipo As Drawing.Image = Nothing
    '        Dim tLogo As String = DatosRecarga("TipoLogo")
    '        Dim simbolo As String = DatosRecarga("Simbolo")
    '        Dim Pie As String = ""

    '        On Error GoTo kakota

    '        '[°]. Logotipo
    '        If tLogo <> "SIN" Then
    '            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
    '                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
    '            End If
    '            If tLogo = "CUAD" Then
    '                e.Graphics.DrawImage(Logotipo, 45, 0, 90, 90)
    '                Y += 100
    '            End If
    '            If tLogo = "RECT" Then
    '                e.Graphics.DrawImage(Logotipo, 8, 0, 170, 100)
    '                Y += 110
    '            End If
    '        Else
    '            Y = 0
    '        End If

    '        '[°]. Datos del negocio
    '        cnn1.Close() : cnn1.Open()

    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select * from Ticket"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                Pie = rd1("Pie2").ToString
    '                'Razón social
    '                If rd1("Cab0").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
    '                    Y += 10.5
    '                End If
    '                'RFC
    '                If rd1("Cab1").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
    '                    Y += 10.5
    '                End If
    '                'Calle  N°.
    '                If rd1("Cab2").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
    '                    Y += 10
    '                End If
    '                'Colonia
    '                If rd1("Cab3").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
    '                    Y += 10
    '                End If
    '                'Delegación / Municipio - Entidad
    '                If rd1("Cab4").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
    '                    Y += 10
    '                End If
    '                'Teléfono
    '                If rd1("Cab5").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
    '                    Y += 10
    '                End If
    '                'Correo
    '                If rd1("Cab6").ToString() <> "" Then
    '                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
    '                    Y += 12
    '                End If
    '                Y += 6
    '            End If
    '        Else
    '            Y += 0
    '        End If
    '        rd1.Close()

    '        '[1]. Datos del pedido
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 10
    '        If tipo_impre = "NORMAL" Then
    '            e.Graphics.DrawString("P E D I D O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 94, Y, sc)
    '            Y += 12
    '        End If
    '        If tipo_impre = "COPIA" Then
    '            e.Graphics.DrawString("C O P I A - P E D I D O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 94, Y, sc)
    '            Y += 12
    '        End If
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 24

    '        e.Graphics.DrawString("N° Pedido: " & cbopedido.Text, fuente_datos, Brushes.Black, 1, Y)
    '        Y += 11
    '        e.Graphics.DrawString("Fecha: " & Date.Now, fuente_datos, Brushes.Black, 1, Y)
    '        Y += 11
    '        e.Graphics.DrawString("Usuario: " & alias_pedidos, fuente_datos, Brushes.Black, 1, Y)
    '        Y += 21

    '        '[2]. Datos del proveedor
    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select * from Proveedores where Compania='" & cboprov.Text & "'"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '                Y += 10
    '                e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 94, Y, sc)
    '                Y += 7.5
    '                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '                Y += 11

    '                If rd1("Compania").ToString <> "" Then
    '                    e.Graphics.DrawString("Nombre: " & Mid(rd1("Compania").ToString, 1, 23), fuente_prods, Brushes.Black, 1, Y)
    '                    Y += 10
    '                    If Mid(rd1("Compania").ToString, 24, 100) <> "" Then
    '                        e.Graphics.DrawString(Mid(rd1("Compania").ToString, 24, 100), fuente_prods, Brushes.Black, 1, Y)
    '                        Y += 10
    '                    End If
    '                End If
    '                If rd1("RFC").ToString <> "" Then
    '                    e.Graphics.DrawString("RFC: " & rd1("RFC").ToString, fuente_prods, Brushes.Black, 1, Y)
    '                    Y += 10
    '                End If
    '                If rd1("Correo").ToString <> "" Then
    '                    e.Graphics.DrawString("Correo: " & Mid(rd1("Correo").ToString, 1, 23), fuente_prods, Brushes.Black, 1, Y)
    '                    Y += 10
    '                    If Mid(rd1("Correo").ToString, 24, 100) <> "" Then
    '                        e.Graphics.DrawString(Mid(rd1("Correo").ToString, 24, 100), fuente_prods, Brushes.Black, 1, Y)
    '                    End If
    '                End If
    '                Y += 12
    '                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '                Y += 10
    '            End If
    '        End If
    '        rd1.Close()
    '        cnn1.Close()

    '        e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
    '        Y += 10
    '        e.Graphics.DrawString("Cant.", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
    '        e.Graphics.DrawString("P.Unit", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 115, Y, sf)
    '        e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 187, Y, sf)
    '        Y += 5.5
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 16

    '        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
    '            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
    '            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
    '            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
    '            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
    '            Dim total As Double = FormatNumber(canti * precio, 2)

    '            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
    '            e.Graphics.DrawString(nombre, fuente_prods, Brushes.Black, 51, Y)
    '            Y += 10
    '            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 25, Y, sf)
    '            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 31, Y)
    '            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 115, Y, sf)
    '            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 188, Y, sf)
    '            Y += 15
    '        Next

    '        Y += 20
    '        e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
    '        e.Graphics.DrawString(simbolo & FormatNumber(txtTotal.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
    '        Y += 11
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 11
    '        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & txtProds.Text, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 94, Y, sc)
    '        Y += 7
    '        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
    '        Y += 28

    '        e.HasMorePages = False
    '        Exit Sub
    'kakota:
    '        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
    '        cnn1.Close()
    '        Exit Sub
    '    End Sub

    '    Dim printLine As Integer = 0
    '    Dim Contador As Integer = 0
    '    Dim pagina As Integer = 0

    '    Private Sub pCarta_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pCarta.PrintPage
    '        'Fuentes predefinidas
    '        Dim tipografia As String = "Lucida Sans Typewriter"
    '        Dim fuente_datos As New Drawing.Font(tipografia, 12, FontStyle.Regular)
    '        Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
    '        'Variables
    '        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
    '        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
    '        Dim pen As New Pen(Brushes.Black, 1)
    '        Dim Y As Double = 0
    '        Dim nLogo As String = DatosRecarga("LogoG")
    '        Dim Logotipo As Drawing.Image = Nothing
    '        Dim tLogo As String = DatosRecarga("TipoLogo")
    '        Dim simbolo As String = DatosRecarga("Simbolo")

    '        On Error GoTo kaka

    '        '[1]. Datos del pedido
    '        If tipo_impre = "NORMAL" Then
    '            e.Graphics.DrawString("P E D I D O", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
    '            Y += 45
    '        End If
    '        If tipo_impre = "COPIA" Then
    '            e.Graphics.DrawString("C O P I A - P E D I D O", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
    '            Y += 45
    '        End If

    '        cnn1.Close() : cnn1.Open()

    '        '[°]. Logotipo
    '        If tLogo <> "SIN" Then
    '            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
    '                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
    '            End If
    '            If tLogo = "CUAD" Then
    '                e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 120, 120)
    '            End If
    '            If tLogo = "RECT" Then
    '                e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 240, 110)
    '            End If

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Ticket"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    'Razón social
    '                    If rd1("Cab0").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
    '                        Y += 14
    '                    End If
    '                    'RFC
    '                    If rd1("Cab1").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
    '                        Y += 14
    '                    End If
    '                    'Calle  N°.
    '                    If rd1("Cab2").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Colonia
    '                    If rd1("Cab3").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Delegación / Municipio - Entidad
    '                    If rd1("Cab4").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Teléfono
    '                    If rd1("Cab5").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Correo
    '                    If rd1("Cab6").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    Y += 17
    '                End If
    '            End If
    '            rd1.Close()
    '        Else
    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Ticket"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    'Razón social
    '                    If rd1("Cab0").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
    '                        Y += 14
    '                    End If
    '                    'RFC
    '                    If rd1("Cab1").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
    '                        Y += 14
    '                    End If
    '                    'Calle  N°.
    '                    If rd1("Cab2").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Colonia
    '                    If rd1("Cab3").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Delegación / Municipio - Entidad
    '                    If rd1("Cab4").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Teléfono
    '                    If rd1("Cab5").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Correo
    '                    If rd1("Cab6").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    Y += 17
    '                End If
    '            End If
    '            rd1.Close()
    '        End If

    '        e.Graphics.DrawRectangle(pen, 535, 87, 285, 54)

    '        '[2]. Datos del proveedor
    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select * from Proveedores where Compania='" & cboprov.Text & "'"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                If rd1("Compania").ToString <> "" Then
    '                    e.Graphics.DrawString(rd1("Compania").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 536, 92)
    '                End If
    '                If rd1("RFC").ToString <> "" Then
    '                    e.Graphics.DrawString(rd1("RFC").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 536, 105.5)
    '                End If
    '                If rd1("Correo").ToString <> "" Then
    '                    e.Graphics.DrawString(rd1("Correo").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 536, 119)
    '                End If
    '            End If
    '        End If
    '        rd1.Close()
    '        cnn1.Close()

    '        e.Graphics.DrawString("N° Pedido", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 820, 30, sf)
    '        e.Graphics.DrawString(cbopedido.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, 820, 48, sf)

    '        e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, 160)
    '        e.Graphics.DrawString("Existencia", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 370, 160)
    '        e.Graphics.DrawString("Cantidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 550, 160, sf)
    '        e.Graphics.DrawString("Precio U", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 700, 160, sf)
    '        e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, 160, sf)
    '        Y += 20
    '        e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
    '        Y += 10

    '        Do While printLine < grdcaptura.Rows.Count
    '            If Y + 18 > 1000 Then
    '                e.HasMorePages = True
    '                Exit Do
    '            End If
    '            Dim codigo As String = grdcaptura.Rows(printLine).Cells(0).Value.ToString()
    '            Dim nombre As String = grdcaptura.Rows(printLine).Cells(1).Value.ToString()
    '            Dim canti As Double = grdcaptura.Rows(printLine).Cells(3).Value.ToString()
    '            Dim precio As Double = grdcaptura.Rows(printLine).Cells(4).Value.ToString()
    '            Dim existe As Double = grdcaptura.Rows(printLine).Cells(5).Value.ToString
    '            Dim total As Double = FormatNumber(canti * precio, 2)

    '            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
    '            e.Graphics.DrawString(Mid(nombre, 1, 35), fuente_prods, Brushes.Black, 60, Y)
    '            e.Graphics.DrawString(existe, fuente_prods, Brushes.Black, 440, Y, sf)
    '            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 550, Y, sf)
    '            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 580, Y)
    '            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 700, Y, sf)
    '            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 820, Y, sf)
    '            Y += 18

    '            printLine += 1
    '            Contador += 1
    '        Loop
    '        pagina += 1
    '        Y += 5
    '        e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
    '        Y += 12

    '        If Contador = grdcaptura.Rows.Count Then
    '            e.Graphics.DrawString("Total: ", fuente_prods, Brushes.Black, 550, Y)
    '            e.Graphics.DrawString(simbolo & FormatNumber(txtTotal.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
    '        End If

    '        e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 1050, sf)
    '        e.Graphics.DrawString("Docuento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 1050, sc)
    '        Exit Sub
    'kaka:
    '        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
    '        cnn1.Close()
    '        Exit Sub
    '    End Sub

    '    Private Sub pMediaCarta_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pMediaCarta.PrintPage
    '        'Fuentes predefinidas
    '        Dim tipografia As String = "Lucida Sans Typewriter"
    '        Dim fuente_datos As New Drawing.Font(tipografia, 12, FontStyle.Regular)
    '        Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
    '        'Variables
    '        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
    '        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
    '        Dim pen As New Pen(Brushes.Black, 1)
    '        Dim Y As Double = 0
    '        Dim nLogo As String = DatosRecarga("LogoG")
    '        Dim Logotipo As Drawing.Image = Nothing
    '        Dim tLogo As String = DatosRecarga("TipoLogo")
    '        Dim simbolo As String = DatosRecarga("Simbolo")

    '        On Error GoTo caca

    '        '[1]. Datos del pedido
    '        If tipo_impre = "NORMAL" Then
    '            e.Graphics.DrawString("P E D I D O", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
    '            Y += 45
    '        End If
    '        If tipo_impre = "COPIA" Then
    '            e.Graphics.DrawString("C O P I A - P E D I D O", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
    '            Y += 45
    '        End If

    '        cnn1.Close() : cnn1.Open()

    '        '[°]. Logotipo
    '        If tLogo <> "SIN" Then
    '            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
    '                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
    '            End If
    '            If tLogo = "CUAD" Then
    '                e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 120, 120)
    '            End If
    '            If tLogo = "RECT" Then
    '                e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 240, 110)
    '            End If

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Ticket"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    'Razón social
    '                    If rd1("Cab0").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
    '                        Y += 14
    '                    End If
    '                    'RFC
    '                    If rd1("Cab1").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
    '                        Y += 14
    '                    End If
    '                    'Calle  N°.
    '                    If rd1("Cab2").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Colonia
    '                    If rd1("Cab3").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Delegación / Municipio - Entidad
    '                    If rd1("Cab4").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Teléfono
    '                    If rd1("Cab5").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Correo
    '                    If rd1("Cab6").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
    '                        Y += 13.5
    '                    End If
    '                    Y += 17
    '                End If
    '            End If
    '            rd1.Close()
    '        Else
    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Ticket"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    'Razón social
    '                    If rd1("Cab0").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
    '                        Y += 14
    '                    End If
    '                    'RFC
    '                    If rd1("Cab1").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
    '                        Y += 14
    '                    End If
    '                    'Calle  N°.
    '                    If rd1("Cab2").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Colonia
    '                    If rd1("Cab3").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Delegación / Municipio - Entidad
    '                    If rd1("Cab4").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Teléfono
    '                    If rd1("Cab5").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    'Correo
    '                    If rd1("Cab6").ToString() <> "" Then
    '                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
    '                        Y += 13.5
    '                    End If
    '                    Y += 17
    '                End If
    '            End If
    '            rd1.Close()
    '        End If

    '        e.Graphics.DrawRectangle(pen, 535, 87, 285, 54)

    '        '[2]. Datos del proveedor
    '        cmd1 = cnn1.CreateCommand
    '        cmd1.CommandText =
    '            "select * from Proveedores where Compania='" & cboprov.Text & "'"
    '        rd1 = cmd1.ExecuteReader
    '        If rd1.HasRows Then
    '            If rd1.Read Then
    '                If rd1("Compania").ToString <> "" Then
    '                    e.Graphics.DrawString(rd1("Compania").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 536, 92)
    '                End If
    '                If rd1("RFC").ToString <> "" Then
    '                    e.Graphics.DrawString(rd1("RFC").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 536, 105.5)
    '                End If
    '                If rd1("Correo").ToString <> "" Then
    '                    e.Graphics.DrawString(rd1("Correo").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 536, 119)
    '                End If
    '            End If
    '        End If
    '        rd1.Close()
    '        cnn1.Close()

    '        e.Graphics.DrawString("N° Pedido", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 820, 30, sf)
    '        e.Graphics.DrawString(cbopedido.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, 820, 48, sf)

    '        e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, 160)
    '        e.Graphics.DrawString("Existencia", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 370, 160)
    '        e.Graphics.DrawString("Cantidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 550, 160, sf)
    '        e.Graphics.DrawString("Precio U", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 700, 160, sf)
    '        e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, 160, sf)
    '        Y += 20
    '        e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
    '        Y += 10

    '        Do While printLine < grdcaptura.Rows.Count
    '            If Y + 18 > 475 Then
    '                e.HasMorePages = True
    '                Exit Do
    '            End If
    '            Dim codigo As String = grdcaptura.Rows(printLine).Cells(0).Value.ToString()
    '            Dim nombre As String = grdcaptura.Rows(printLine).Cells(1).Value.ToString()
    '            Dim canti As Double = grdcaptura.Rows(printLine).Cells(3).Value.ToString()
    '            Dim precio As Double = grdcaptura.Rows(printLine).Cells(4).Value.ToString()
    '            Dim existe As Double = grdcaptura.Rows(printLine).Cells(5).Value.ToString
    '            Dim total As Double = FormatNumber(canti * precio, 2)

    '            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
    '            e.Graphics.DrawString(nombre, fuente_prods, Brushes.Black, 60, Y)
    '            e.Graphics.DrawString(existe, fuente_prods, Brushes.Black, 440, Y, sf)
    '            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 550, Y, sf)
    '            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 580, Y)
    '            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 700, Y, sf)
    '            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 820, Y, sf)
    '            Y += 18

    '            printLine += 1
    '            Contador += 1
    '        Loop
    '        pagina += 1
    '        Y += 5
    '        e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
    '        Y += 12

    '        If Contador = grdcaptura.Rows.Count Then
    '            e.Graphics.DrawString("Total: ", fuente_prods, Brushes.Black, 550, Y)
    '            e.Graphics.DrawString(simbolo & FormatNumber(txtTotal.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
    '        End If

    '        e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 510, sf)
    '        e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 510, sc)
    '        Exit Sub
    'caca:
    '        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
    '        cnn1.Close()
    '        Exit Sub
    '    End Sub

    '    Private Sub cboBanco_DropDown(sender As System.Object, e As System.EventArgs)
    '        cboBanco.Items.Clear()
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select Banco from Bancos"
    '            rd1 = cmd1.ExecuteReader
    '            Do While rd1.Read
    '                If rd1.HasRows Then cboBanco.Items.Add(
    '                    rd1(0).ToString
    '                    )
    '            Loop
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cboTpago_SelectedValueChanged(sender As System.Object, e As System.EventArgs)
    '        If cboTpago.Text = "EFECTIVO" Then
    '            cboBanco.Enabled = False
    '            txtref.Enabled = False
    '        Else
    '            cboBanco.Enabled = True
    '            txtref.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub cboTpago_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            If cboTpago.Text = "EFECTIVO" Then
    '                txtmonto.Focus().Equals(True)
    '            Else
    '                cboBanco.Focus().Equals(True)
    '            End If
    '        End If
    '    End Sub

    '    Private Sub cboBanco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
    '        e.KeyChar = UCase(e.KeyChar)
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            If cboTpago.Text = "" Then
    '                MsgBox("Selecciona una forma de pago para elegir el banco.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                Exit Sub
    '            End If
    '            txtref.Focus().Equals(True)
    '        End If
    '    End Sub

    '    Private Sub txtref_Click(sender As System.Object, e As System.EventArgs)
    '        txtref.SelectionStart = 0
    '        txtref.SelectionLength = Len(txtref.Text)
    '    End Sub

    '    Private Sub txtref_GotFocus(sender As Object, e As System.EventArgs)
    '        txtref.SelectionStart = 0
    '        txtref.SelectionLength = Len(txtref.Text)
    '    End Sub

    '    Private Sub txtref_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            If cboTpago.Text = "" Then
    '                MsgBox("Selecciona una forma de pago para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                cboTpago.Focus().Equals(True)
    '                Exit Sub
    '            End If
    '            If cboBanco.Text = "" Then
    '                MsgBox("Selecciona el banco de precedencia del pago para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                cboBanco.Focus().Equals(True)
    '                Exit Sub
    '            End If
    '            txtmonto.Focus().Equals(True)
    '        End If
    '    End Sub

    '    Private Sub txtmonto_Click(sender As System.Object, e As System.EventArgs)
    '        txtmonto.SelectionStart = 0
    '        txtmonto.SelectionLength = Len(txtmonto.Text)
    '    End Sub

    '    Private Sub txtmonto_GotFocus(sender As Object, e As System.EventArgs)
    '        txtmonto.SelectionStart = 0
    '        txtmonto.SelectionLength = Len(txtmonto.Text)
    '    End Sub

    '    Private Sub txtmonto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
    '        If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = "" : Exit Sub
    '        If AscW(e.KeyChar) = Keys.Enter Then
    '            If cboTpago.Text <> "" Then
    '                If CDbl(txtmonto.Text) <= 0 Then MsgBox("Al selccionar una forma de pago, el monto no puede estar vacío.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
    '                txtmonto.Focus().Equals(True)
    '            End If
    '            txtmonto.Text = FormatNumber(txtmonto.Text, 2)
    '            btnguarda.Focus().Equals(True)
    '        End If
    '    End Sub

    '    Private Sub cboTpago_TextChanged(sender As System.Object, e As System.EventArgs)
    '        If cboTpago.Text = "EFECTIVO" Then
    '            cboBanco.Enabled = False
    '            txtref.Enabled = False
    '        Else
    '            cboBanco.Enabled = True
    '            txtref.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub btncopia_Click(sender As System.Object, e As System.EventArgs) Handles btncopia.Click
    '        If MsgBox("¿Deseas imprimir una copia el pedido?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
    '            Dim ImprimeEn As String = ""
    '            Dim Impresora As String = ""
    '            Dim tPapel As String = ""
    '            Dim tMilimetros As String = ""
    '            tipo_impre = "COPIA"

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select NotasCred from Formatos where Facturas='TPapelCP'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    tPapel = rd1(0).ToString
    '                    If tPapel = "CARTA" Or tPapel = "MEDIA CARTA" Then
    '                        ImprimeEn = "ImpreC"
    '                    ElseIf tPapel = "TICKET" Then
    '                        ImprimeEn = "ImpreT"
    '                    Else
    '                        ImprimeEn = ""
    '                    End If
    '                End If
    '            Else
    '                MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de pedidos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                rd1.Close()
    '                cnn1.Close()
    '                btnlimpia.PerformClick()
    '                Exit Sub
    '            End If
    '            rd1.Close()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select NotasCred from Formatos where Facturas='TamImpre'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    tMilimetros = rd1(0).ToString
    '                End If
    '            End If
    '            rd1.Close()

    '            If ImprimeEn <> "" Then
    '                cmd1 = cnn1.CreateCommand
    '                cmd1.CommandText =
    '                    "select NotasCred from Formatos where Facturas='" & ImprimeEn & "'"
    '                rd1 = cmd1.ExecuteReader
    '                If rd1.HasRows Then
    '                    If rd1.Read Then
    '                        Impresora = rd1(0).ToString
    '                    End If
    '                End If
    '                rd1.Close()
    '            Else
    '                MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                cnn1.Close()
    '                btnlimpia.PerformClick()
    '                Exit Sub
    '            End If

    '            If tPapel = "TICKET" Then
    '                If tMilimetros = "80" Then
    '                    pTicket80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                    pTicket80.Print()
    '                End If
    '                If tMilimetros = "58" Then
    '                    pTicket58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                    pTicket58.Print()
    '                End If
    '            End If
    '            If tPapel = "MEDIA CARTA" Then
    '                pMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                pMediaCarta.Print()
    '            End If
    '            If tPapel = "CARTA" Then
    '                pCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
    '                pCarta.Print()
    '            End If
    '            If tPapel = "PDF - CARTA" Then
    '                'Genera PDF y lo guarda en la ruta
    '                If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSCN1\PEDIDOS\" & cboprov.Text & "\Pedido_" & cbopedido.Text & ".pdf") Then
    '                    File.Open(My.Application.Info.DirectoryPath & "\ARCHIVOSCN1\PEDIDOS\" & cboprov.Text & "\Pedido_" & cbopedido.Text & ".pdf", FileMode.Open)
    '                End If
    '            End If

    '            tipo_impre = ""
    '        End If
    '    End Sub

    '    Private Sub btncancela_Click(sender As System.Object, e As System.EventArgs) Handles btncancela.Click
    '        If cboprov.Text = "" Then MsgBox("Selecciona un proveedor para cancelar el pedido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboprov.Focus().Equals(True) : Exit Sub
    '        If cbopedido.Text = "" Then MsgBox("Escribe el número de pedido para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbopedido.Focus().Equals(True) : Exit Sub
    '        Dim estado As Boolean = False
    '        Try
    '            cnn1.Close() : cnn1.Open()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "select * from Pedidos where Num='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.HasRows Then
    '                If rd1.Read Then
    '                    estado = rd1("Status").ToString
    '                End If
    '            Else
    '                MsgBox("No puedes cancelar un pedido que no ha sido registrado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                rd1.Close()
    '                cnn1.Close()
    '                Exit Sub
    '            End If
    '            rd1.Close()
    '            If (estado) Then
    '                MsgBox("El pedido ya fue capturado como una compra porque lo que no se puede cancelar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '                cnn1.Close()
    '                Exit Sub
    '            End If

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "delete from Pedidos where Num='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '            cmd1.ExecuteNonQuery()

    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText =
    '                "delete from PedidosDet where NumPed='" & cbopedido.Text & "' and Proveedor='" & cboprov.Text & "'"
    '            cmd1.ExecuteNonQuery()

    '            MsgBox("Pedido cancelado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    '            btnlimpia.PerformClick()

    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End Sub

    '    Private Sub cboTpago_DropDown(sender As Object, e As EventArgs)
    '        cboTpago.Items.Clear()
    '        cboTpago.Items.Add("EFECTIVO")
    '        cboTpago.Items.Add("TRANSFERENCIA")
    '        cboTpago.Items.Add("TARJETA")
    '        cboTpago.Items.Add("DEPOSITO")
    '        cboTpago.Items.Add("OTRO")
    '    End Sub

End Class