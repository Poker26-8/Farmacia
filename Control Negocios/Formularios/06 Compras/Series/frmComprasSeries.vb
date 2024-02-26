Public Class frmComprasSeries

    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim pagina As Integer = 0
    Dim tipo_cancelacion As String = ""
    Dim alias_compras As String = ""
    Private Sub frmComprasSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfecha.Value = Now
        dtpfpago.Value = Now
        txtcodigo.Text = ""

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
                            txtusuario.Text = rd2(0).ToString
                            lblusuario.Text = rd2(1).ToString
                            txtusuario.PasswordChar = "*"
                            txtusuario.ForeColor = Color.Black
                        End If
                    End If
                    rd2.Close()
                End If

            End If
        End If
        rd1.Close()
        cnn1.Close()
        cnn2.Close()

        panpago_compra.Visible = False
        txtpc_apagar.Text = "0.00"
        txtpc_anticipo.Text = "0.00"
        txtpc_efectivo.Text = "0.00"
        txtpc_tarjeta.Text = "0.00"
        txtpc_transfe.Text = "0.00"
        txtpc_otro.Text = "0.00"
        txtpc_resta.Text = "0.00"

        Pagos.pc_porpagar = 0
        Pagos.pc_anticipo = 0
        Pagos.pc_efectivo = 0
        Pagos.pc_tarjeta = 0
        Pagos.pc_transfe = 0
        Pagos.pc_otros = 0
        Pagos.pc_resta = 0

        grdcaptura.Rows.Clear()
        grdcaptura.DefaultCellStyle.ForeColor = Color.Black
        PrintLine = 0
        Contador = 0
        pagina = 0
        VieneDe_Compras = ""

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT * FROM tb_moneda WHERE nombre_moneda='PESO' or nombre_moneda='PESOS'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                txtvalor.Text = FormatNumber(rd1("tipo_cambio").ToString, 4)
                cbomoneda.Tag = rd1("id").ToString
                cbomoneda.Items.Add(rd1("nombre_moneda").ToString)
                cbomoneda.SelectedIndex = 0
            End If
        Else
            cbomoneda.Tag = "0"
        End If
        rd1.Close()
        If cnn1.State = 0 Then cnn1.Open()

        'Variables de cálculo
        Dim varTotal As Double = 0
        Dim varTotalIVA As Double = 0
        Dim varTotalIEPS As Double = 0
        Dim varConteo As Double = 0

        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from AuxCompras order by Id"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then
                cboremision.Text = rd1("Rem").ToString
                cbofactura.Text = rd1("Fac").ToString
                cbopedido.Text = rd1("Ped").ToString
                cboproveedor.Text = rd1("Proveedor").ToString

                Dim codigo As String = rd1("Codigo").ToString
                Dim nombre As String = rd1("Nombre").ToString
                Dim unidad As String = rd1("Unidad").ToString
                Dim cantidad As Double = rd1("Cantidad").ToString
                Dim precio As Double = rd1("Precio").ToString
                Dim total As Double = cantidad * precio
                Dim serie As String = rd1("Serie").ToString
                Dim cp As Boolean = rd1("CP").ToString
                Dim existencia As Double = 0
                Dim IVA As Double = 0

                varTotalIEPS = varTotalIEPS + CDbl(total * ProdsIEPS(codigo))

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where Codigo='" & codigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        existencia = rd2("Existencia").ToString
                        IVA = rd2("IVA").ToString
                        If IVA > 0 Then
                            If rd1("Fac").ToString <> "" Then
                                varTotalIVA = varTotalIVA + CDbl(0.16 * ((total) + (total * ProdsIEPS(codigo))))
                            End If
                        End If
                    End If
                End If
                rd2.Close()

                grdcaptura.Rows.Add(
                    codigo,
                    nombre,
                    unidad,
                    cantidad,
                    FormatNumber(precio, 4),
                    FormatNumber(total, 2),
                    existencia,
                    serie,
                    cp
                    )

                varConteo = varConteo + cantidad
                varTotal = varTotal + total
            End If
        Loop
        rd1.Close()
        cnn1.Close()
        cnn2.Close()

        Call cboproveedor_SelectedValueChanged(cboproveedor, New EventArgs())

        If cboremision.Text <> "" And cbofactura.Text <> "" Then
            txtieps.Text = FormatNumber("0", 2)
            txtsub1.Text = FormatNumber(varTotal, 2)
            txtsub2.Text = FormatNumber(varTotal, 2)
            txtiva.Text = FormatNumber(varTotalIVA, 2)
            txtTotalC.Text = FormatNumber(varTotal + varTotalIVA, 2)
            txtapagar.Text = FormatNumber(varTotal + varTotalIVA, 2)
            txtresta.Text = FormatNumber(varTotal + varTotalIVA, 2)
        Else
            txtieps.Text = FormatNumber(varTotalIEPS, 2)
            txtsub1.Text = FormatNumber(varTotal + varTotalIEPS, 2)
            txtsub2.Text = FormatNumber(varTotal + varTotalIEPS, 2)
            txtiva.Text = FormatNumber(varTotalIVA, 2)
            txtTotalC.Text = FormatNumber(varTotal + varTotalIVA + varTotalIEPS, 2)
            txtapagar.Text = FormatNumber(varTotal + varTotalIVA + varTotalIEPS, 2)
            txtresta.Text = FormatNumber(varTotal + varTotalIVA + varTotalIEPS, 2)
        End If

        cbonombre.Focus().Equals(True)
    End Sub

    Public Structure Pagos
        Shared pc_porpagar As Double = 0
        Shared pc_anticipo As Double = 0
        Shared pc_efectivo As Double = 0
        Shared pc_tarjeta As Double = 0
        Shared pc_transfe As Double = 0
        Shared pc_otros As Double = 0
        Shared pc_resta As Double = 0
    End Structure

    Private Sub cboproveedor_DropDown(sender As Object, e As EventArgs) Handles cboproveedor.DropDown

        cboproveedor.Items.Clear()
        btnnuevo.PerformClick()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Compania FROM Proveedores WHERE Compania<>'' order by Compania"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboproveedor.Items.Add(
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

    Private Sub cboproveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboproveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboremision.Focus.Equals(True)
        End If
    End Sub
    Private Sub cboproveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboproveedor.SelectedValueChanged

        If cboproveedor.Text <> "" Then
            txtsaldo.Text = "0.00"
            Dim dias As Integer = 0

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Proveedores WHERE Compania='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        dias = rd1("DiasCred").ToString
                        dtpfpago.Value = DateAdd(DateInterval.Day, dias, Date.Now)
                    End If
                End If
                rd1.Close()

                Dim MySaldo As Double = 0
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoE where Id=(select MAX(Id) from AbonoE where Proveedor='" & cboproveedor.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = FormatNumber(CDbl(IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())), 2)
                        Button1.Enabled = True
                        txtpAnticipo.Enabled = True
                        lblpAnticipo.Enabled = True
                    Else
                        txtsaldo.Text = "0.00"
                        Button1.Enabled = False
                        txtpAnticipo.Enabled = False
                        lblpAnticipo.Enabled = False
                    End If
                Else
                    txtsaldo.Text = "0.00"
                    Button1.Enabled = False
                    txtpAnticipo.Enabled = False
                    lblpAnticipo.Enabled = False
                End If
                rd1.Close() : cnn1.Close()

                If MySaldo < 0 Then
                    txtsaldo.Text = FormatNumber(Math.Abs(MySaldo), 2)
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub cbomoneda_DropDown(sender As Object, e As EventArgs) Handles cbomoneda.DropDown
        cbomoneda.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select nombre_moneda from tb_moneda"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbomoneda.Items.Add(
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

    Private Sub cbomoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbomoneda.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from tb_moneda where nombre_moneda='" & cbomoneda.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtvalor.Text = FormatNumber(rd1("tipo_cambio").ToString, 2)
                    cbomoneda.Tag = rd1("Id").ToString
                End If
            Else
                txtvalor.Text = "0.00"
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Function CodBarra() As Boolean
        Dim Bool As Boolean = False
        If cbonombre.Text = "" And txtcodigo.Text = "" Then CodBarra = False : Exit Function
        'Descripción
        If txtcodigo.Text = "" Then
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Productos WHERE CodBarra='" & cbonombre.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If cbonombre.Text = "" Then cnn2.Close() : rd2.Close() : Return False : Exit Function
                    txtcodigo.Text = rd2("Codigo").ToString
                    cbonombre.Text = rd2("Nombre").ToString
                    txtunidad.Text = rd2("UCompra").ToString
                    txtprecio.Text = FormatNumber(rd2("PrecioCompra").ToString, 4)
                    txtexiste.Text = rd2("Existencia").ToString
                    lblvalor.Text = FormatNumber(rd2("PrecioCompra").ToString(), 4)

                    cnn3.Close() : cnn3.Open() : cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select tipo_cambio,nombre_moneda from tb_moneda,Productos where Codigo='" & txtcodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            lblmoneda.Text = rd3("nombre_moneda").ToString
                            If lblvalor.Text = "" Then lblvalor.Text = "1.0000"
                        End If
                    Else
                        lblvalor.Text = "1.0000"
                    End If
                    rd3.Close() : cnn3.Close()

                    txtcantidad.Focus().Equals(True)
                    Bool = True
                End If
            Else
                cbonombre.Text = ""
                cbonombre.Focus().Equals(True)
            End If
            rd2.Close()
            cnn2.Close()

        End If
        Return Bool
    End Function

    Private Sub cbonombre_DropDown(sender As Object, e As EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT distinct Nombre FROM Productos WHERE Length(Codigo)<7 AND Departamento <> 'SERVICIOS' AND ProvRes<>1 order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
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

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = Strings.Left(rd1("Codigo").ToString, 6)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If cboremision.Text = "" And cbofactura.Text = "" And cbopedido.Text = "" Then MsgBox("Necesitas escribir un número de remisión para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboremision.Focus().Equals(True) : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If (CodBarra()) Then
                txtcantidad.Focus().Equals(True)
            Else
                txtcodigo.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtvalor_Click(sender As Object, e As EventArgs) Handles txtvalor.Click
        txtvalor.SelectionStart = 0
        txtvalor.SelectionLength = Len(-txtvalor.Text)
    End Sub

    Private Sub txtvalor_GotFocus(sender As Object, e As EventArgs) Handles txtvalor.GotFocus
        txtvalor.SelectionStart = 0
        txtvalor.SelectionLength = Len(-txtvalor.Text)
    End Sub

    Private Sub txtvalor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvalor.KeyPress
        If Not IsNumeric(txtvalor.Text) Then txtvalor.Text = "0.00"
        If AscW(e.KeyChar) = Keys.Enter Then
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcodigo_Click(sender As Object, e As EventArgs) Handles txtcodigo.Click
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_GotFocus(sender As Object, e As EventArgs) Handles txtcodigo.GotFocus
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigo.KeyPress
        Dim MoneValor As Double = 0
        Dim Multiplo As Double = 0

        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcodigo.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select tipo_cambio,nombre_moneda from tb_moneda,Productos where Codigo='" & txtcodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblmoneda.Text = rd1("nombre_moneda").ToString
                            lblvalor.Text = rd1("tipo_cambio").ToString
                            MoneValor = rd1("tipo_cambio").ToString
                            If lblvalor.Text = "" Then lblvalor.Text = "1.0000"
                        Else
                            lblvalor.Text = "1.0000"
                        End If
                    Else
                        lblvalor.Text = "1.0000"
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & txtcodigo.Text & "' and Departamento<>'SERVICIOS'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtcodigo.Text = rd1("Codigo").ToString

                            If Trim(lblmoneda.Text) <> Trim(cbomoneda.Text) Then
                                MsgBox("No se puede continuar porque el tipo de moneda del pedido no coincide con el tipo de moneda del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                rd1.Close()
                                cnn1.Close()
                                Exit Sub
                            End If
                            If txtvalor.Text = "" Then
                                MsgBox("Ingresa el valor de la moneda.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                If txtvalor.Enabled = True Then
                                    txtvalor.Focus().Equals(True)
                                End If
                                cnn1.Close()
                                Exit Sub
                            End If

                            txtunidad.Text = rd1("UCompra").ToString
                            cbonombre.Text = rd1("Nombre").ToString
                            lblvalor.Text = FormatNumber(rd1("PrecioCompra").ToString, 4)
                            txtprecio.Text = FormatNumber(rd1("PrecioCompra".ToString), 4)
                            Multiplo = rd1("Multiplo").ToString
                        End If
                    Else
                        MsgBox("No existe un producto registrado con este código.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        txtcodigo.Text = ""
                        Exit Sub
                    End If
                    rd1.Close()

                    Dim existe As Double = 0
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Existencia FROM Productos WHERE Codigo='" & Strings.Left(txtcodigo.Text, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If Multiplo > 0 Then existe = IIf(rd1(0).ToString = "", 0, rd1(0).ToString) / Multiplo
                            txtexiste.Text = FormatNumber(existe, 2)
                            If txtexiste.Text = "" Then txtexiste.Text = "0"
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
        If AscW(e.KeyChar) = Keys.Enter And txtcodigo.Text <> "" Then txtcantidad.Focus().Equals(True)
        If AscW(e.KeyChar) = Keys.Enter And txtcodigo.Text = "" Then btnPagar.Focus().Equals(True)
    End Sub

    Private Sub cboremision_Click(sender As Object, e As EventArgs) Handles cboremision.Click
        cboremision.SelectionStart = 0
        cboremision.SelectionLength = Len(cboremision.Text)
    End Sub

    Private Sub cboremision_DropDown(sender As Object, e As EventArgs) Handles cboremision.DropDown
        cboremision.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT distinct NumRemision FROM Compras WHERE Proveedor='" & cboproveedor.Text & "' and NumRemision<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboremision.Items.Add(
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

    Private Sub cboremision_GotFocus(sender As Object, e As EventArgs) Handles cboremision.GotFocus
        cboremision.SelectionStart = 0
        cboremision.SelectionLength = Len(cboremision.Text)
    End Sub

    Private Sub cboremision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboremision.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboproveedor.Text <> "" And cboremision.Text = "" Then MsgBox("El número de remisión no puede permanecer vacío.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            Dim Pedido As Integer = 0
            Dim conteo As Double = 0
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT NumRemision, NumFactura, NumPedido, FechaC FROM Compras WHERE NumRemision='" & cboremision.Text & "' AND Proveedor='" & cboproveedor.Text & "' AND Status<>'CANCELADA'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("Este número de remisión ya existe en una compra previa.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        Pedido = 0
                        cbofactura.Text = rd1(1).ToString
                        cbopedido.Text = rd1(2).ToString
                        dtpfecha.Value = rd1(3).ToString
                        btnguardar.Enabled = False
                        btnPagar.Enabled = False
                        btncancela.Enabled = True
                        btnactualiza.Enabled = True
                        txtsaldo.Enabled = False
                        Button1.Enabled = False
                        txtpAnticipo.Enabled = False
                        lblpAnticipo.Enabled = False
                        grdcaptura.DefaultCellStyle.ForeColor = Color.DarkGoldenrod
                    End If
                Else
                    btnactualiza.Enabled = False
                    btncancela.Enabled = False
                    btnguardar.Enabled = True
                    txtsaldo.Enabled = True
                    grdcaptura.DefaultCellStyle.ForeColor = Color.Black
                    cbofactura.Focus().Equals(True)
                End If
                rd1.Close()

                If Pedido = 0 Then
                    txtsub1.Text = "0.00"
                    txtdesc1.Text = "0.00"
                    txtsub2.Text = "0.00"
                    txtiva.Text = "0.00"
                    txtTotalC.Text = "0.00"
                    txtdesc2.Text = "0.00"
                    txtieps.Text = "0.00"
                    txtapagar.Text = "0.00"
                    txtanticipo.Text = "0.00"
                    txtefectivo.Text = "0.00"
                    txtpagos.Text = "0.00"
                    txtresta.Text = "0.00"
                End If

                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM ComprasDet WHERE NumRemision='" & cboremision.Text & "' AND Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1("Codigo").ToString
                        Dim nombre As String = ""
                        Dim unidad As String = ""
                        Dim multiplo As Double = 0
                        Dim existencia As Double = 0
                        cmd2 = cnn2.CreateCommand : cmd2.CommandText =
                            "select * from Productos where Codigo='" & codigo & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                nombre = rd2("Nombre").ToString
                                unidad = rd2("UCompra").ToString
                                multiplo = rd2("Multiplo").ToString
                                existencia = rd2("Existencia").ToString
                                existencia = existencia / multiplo
                            End If
                        End If
                        rd2.Close()
                        Dim precio As Double = rd1("Precio").ToString
                        Dim cantidad As Double = rd1("Cantidad").ToString
                        Dim total As Double = precio * cantidad
                        Dim cad As String = rd1("Caducidad").ToString
                        Dim lote As String = rd1("Lote").ToString
                        grdcaptura.Rows.Add(
                            codigo,
                            nombre,
                            unidad,
                            cantidad,
                            FormatNumber(precio, 4),
                            FormatNumber(total, 2),
                            existencia,
                            cad,
                            lote,
                            ""
                            )
                        conteo = conteo + cantidad
                    End If
                Loop
                rd1.Close()
                cnn2.Close()

                txtprods.Text = conteo

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Compras WHERE NumRemision='" & cboremision.Text & "' AND NumFactura='" & cbofactura.Text & "' AND Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtsub1.Text = FormatNumber(rd1("Sub1").ToString, 2)
                        txtdesc1.Text = FormatNumber(rd1("Desc1").ToString, 2)
                        txtsub2.Text = FormatNumber(rd1("Sub2").ToString, 2)
                        txtiva.Text = FormatNumber(rd1("IVA").ToString, 2)
                        txtTotalC.Text = FormatNumber(rd1("Total")).ToString
                        txtdesc2.Text = FormatNumber(rd1("Desc2".ToString), 2)
                        txtieps.Text = FormatNumber(rd1("IEPS").ToString, 2)
                        txtapagar.Text = FormatNumber(rd1("Pagar").ToString, 2)
                        txtresta.Text = FormatNumber(rd1("Resta").ToString, 2)
                        dtpfecha.Value = rd1("FechaC").ToString
                        dtpfpago.Value = rd1("FechaP").ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cbofactura.Focus().Equals(True)
        End If
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
        If AscW(e.KeyChar) = Keys.Enter Then
            txtprecio.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_LostFocus(sender As Object, e As EventArgs) Handles txtcantidad.LostFocus
        If grdcaptura.DefaultCellStyle.ForeColor = Color.LightCoral Then
            txtcodigo.Text = ""
            cbonombre.Text = ""
            txtunidad.Text = ""
            txtprecio.Text = "0.0000"
            dtpfecha.Value = Now
            txtcantidad.Text = ""
            txttotal.Text = ""
            txtexiste.Text = ""
            cbonombre.Focus().Equals(True)
            If MsgBox("Ya existe una compra bajo el número de remisión o factura. ¿Deseas realizar una nueva compra?", vbInformation + vbOKCancel, titulocentral) = vbOK Then btnnuevo.PerformClick()
        End If
    End Sub

    Private Sub cboremision_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboremision.SelectedValueChanged
        If cboremision.Text <> "" Then
            Call cboremision_KeyPress(cboremision, New KeyPressEventArgs(ChrW(Keys.Enter)))
        End If
    End Sub

    Private Sub cbofactura_DropDown(sender As Object, e As EventArgs) Handles cbofactura.DropDown
        cbofactura.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct NumFactura from Compras where Proveedor='" & cboproveedor.Text & "' and NumFactura<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbofactura.Items.Add(
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

    Private Sub cbofactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofactura.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbofactura.Text = "" Then cbopedido.Focus().Equals(True) : Exit Sub
            Dim Pedido As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumRemision, NumFactura, NumPedido, FechaC from Compras where NumFactura='" & cbofactura.Text & "' and Proveedor='" & cboproveedor.Text & "' and Status<>'CANCELADA'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("Este número de factura ya existe en una compra previa.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        Pedido = 0
                        cboremision.Text = rd1(0).ToString
                        cbopedido.Text = rd1(2).ToString
                        dtpfecha.Value = rd1(3).ToString
                        btnguardar.Enabled = False
                        btnPagar.Enabled = False
                        btncancela.Enabled = True
                        btnactualiza.Enabled = True
                        txtsaldo.Enabled = False
                        Button1.Enabled = False
                        txtpAnticipo.Enabled = False
                        lblpAnticipo.Enabled = False
                        grdcaptura.DefaultCellStyle.ForeColor = Color.DarkGoldenrod
                    End If
                Else
                    btnactualiza.Enabled = False
                    btncancela.Enabled = False
                    btnguardar.Enabled = True
                    txtsaldo.Enabled = True
                    grdcaptura.DefaultCellStyle.ForeColor = Color.Black
                    cbofactura.Focus().Equals(True)
                End If
                rd1.Close()

                If Pedido = 0 Then
                    txtsub1.Text = "0.00"
                    txtdesc1.Text = "0.00"
                    txtsub2.Text = "0.00"
                    txtiva.Text = "0.00"
                    txtTotalC.Text = "0.00"
                    txtdesc2.Text = "0.00"
                    txtieps.Text = "0.00"
                    txtapagar.Text = "0.00"
                    txtanticipo.Text = "0.00"
                    txtefectivo.Text = "0.00"
                    txtpagos.Text = "0.00"
                    txtresta.Text = "0.00"
                End If

                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from ComprasDet where NumFactura='" & cbofactura.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1("Codigo").ToString
                        Dim nombre As String = ""
                        Dim unidad As String = ""
                        Dim multiplo As Double = 0
                        Dim existencia As Double = 0
                        cmd2 = cnn2.CreateCommand : cmd2.CommandText =
                            "select * from Productos where Codigo='" & codigo & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                nombre = rd2("Nombre").ToString
                                unidad = rd2("UCompra").ToString
                                multiplo = rd2("Multiplo").ToString
                                existencia = rd2("Existencia").ToString
                                existencia = existencia / multiplo
                            End If
                        End If
                        rd2.Close()
                        Dim precio As Double = rd1("Precio").ToString
                        Dim cantidad As Double = rd1("Cantidad").ToString
                        Dim total As Double = precio * cantidad
                        Dim cad As String = rd1("Caducidad").ToString
                        Dim lote As String = rd1("Lote").ToString
                        grdcaptura.Rows.Add(
                            codigo,
                            nombre,
                            unidad,
                            cantidad,
                            FormatNumber(precio, 4),
                            FormatNumber(total, 2),
                            existencia,
                            cad,
                            lote,
                            ""
                            )
                    End If
                Loop
                rd1.Close()
                cnn2.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Compras where NumRemision='" & cboremision.Text & "' and NumFactura='" & cbofactura.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtsub1.Text = FormatNumber(rd1("Sub1").ToString, 2)
                        txtdesc1.Text = FormatNumber(rd1("Desc1").ToString, 2)
                        txtsub2.Text = FormatNumber(rd1("Sub2").ToString, 2)
                        txtiva.Text = FormatNumber(rd1("IVA").ToString, 2)
                        txtTotalC.Text = FormatNumber(rd1("Total")).ToString
                        txtdesc2.Text = FormatNumber(rd1("Desc2".ToString), 2)
                        txtieps.Text = FormatNumber(rd1("IEPS").ToString, 2)
                        txtapagar.Text = FormatNumber(rd1("Pagar").ToString, 2)
                        txtresta.Text = FormatNumber(rd1("Resta").ToString, 2)
                        dtpfecha.Value = rd1("FechaC").ToString
                        dtpfpago.Value = rd1("FechaP").ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cbopedido.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofactura_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofactura.SelectedValueChanged
        If cbofactura.Text <> "" Then
            Call cbofactura_KeyPress(cbofactura, New KeyPressEventArgs(ChrW(Keys.Enter)))
        End If
    End Sub

    Private Sub cbofactura_Click(sender As Object, e As EventArgs) Handles cbofactura.Click
        cbofactura.SelectionStart = 0
        cbofactura.SelectionLength = Len(cbofactura.Text)
    End Sub

    Private Sub cbofactura_GotFocus(sender As Object, e As EventArgs) Handles cbofactura.GotFocus
        cbofactura.SelectionStart = 0
        cbofactura.SelectionLength = Len(cbofactura.Text)
    End Sub

    Private Sub cbopedido_Click(sender As Object, e As EventArgs) Handles cbopedido.Click
        cbopedido.SelectionStart = 0
        cbopedido.SelectionLength = Len(cbopedido.Text)
    End Sub

    Private Sub cbopedido_DropDown(sender As Object, e As EventArgs) Handles cbopedido.DropDown
        cbopedido.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Num from Pedidos where Proveedor='" & cboproveedor.Text & "' and Status=0"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbopedido.Items.Add(
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

    Private Sub cbopedido_GotFocus(sender As Object, e As EventArgs) Handles cbopedido.GotFocus
        cbopedido.SelectionStart = 0
        cbopedido.SelectionLength = Len(cbopedido.Text)
    End Sub

    Private Sub cbopedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbopedido.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Pedidos where Num='" & cbopedido.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("Ya hay un registro inicial de un pedido con este folio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtanticipo.Text = FormatNumber(rd1("Anticipo").ToString, 2)
                        btnguardar.Enabled = True
                        btncancela.Enabled = False
                        btnactualiza.Enabled = False
                        txtsaldo.Enabled = False
                        Button1.Enabled = False
                        txtpAnticipo.Enabled = False
                        lblpAnticipo.Enabled = False
                        grdcaptura.DefaultCellStyle.ForeColor = Color.Black
                    End If
                Else
                    btnactualiza.Enabled = False
                    btncancela.Enabled = False
                    btnguardar.Enabled = True
                    txtsaldo.Enabled = True
                    grdcaptura.DefaultCellStyle.ForeColor = Color.Black
                End If
                rd1.Close()

                cnn2.Close() : cnn2.Open()

                Dim tot_pedido As Double = 0
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from PedidosDet where NumPed='" & cbopedido.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1("Codigo").ToString
                        Dim nombre As String = ""
                        Dim unidad As String = ""
                        Dim multiplo As Double = 0
                        Dim existencia As Double = 0
                        cmd2 = cnn2.CreateCommand : cmd2.CommandText =
                            "select * from Productos where Codigo='" & codigo & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                nombre = rd2("Nombre").ToString
                                unidad = rd2("UCompra").ToString
                                multiplo = rd2("Multiplo").ToString
                                existencia = rd2("Existencia").ToString
                                existencia = existencia / multiplo
                            End If
                        End If
                        rd2.Close()
                        Dim precio As Double = rd1("Precio").ToString
                        Dim cantidad As Double = rd1("Cantidad").ToString
                        Dim total As Double = precio * cantidad
                        Dim cad As String = ""
                        Dim lote As String = ""

                        grdcaptura.Rows.Add(codigo, nombre, unidad, cantidad, FormatNumber(precio, 4), FormatNumber(total, 2), existencia, cad, lote, "0")
                        tot_pedido = tot_pedido + total
                    End If
                Loop
                rd1.Close()
                cnn2.Close()
                cnn1.Close()

                txtsub1.Text = FormatNumber(tot_pedido, 2)
                If cbofactura.Text <> "" Then
                    txtiva.Tag = "0"
                    Call IVA()
                    txtTotalC.Text = CDbl(txtiva.Text) + CDbl(txtsub2.Text)
                    txtiva.Text = FormatNumber(txtiva.Text, 2)
                    txtTotalC.Text = FormatNumber(txtTotalC.Text, 2)
                Else
                    txtTotalC.Text = FormatNumber(txtsub2.Text, 2)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            dtpfecha.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpfecha.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click

        grdcaptura.DefaultCellStyle.ForeColor = Color.Black
        dtpfpago.Value = Date.Now
        dtpfecha.Value = Date.Now

        printLine = 0
        Contador = 0
        pagina = 0
        txtusuario.Text = ""

        txtcodigo.Text = ""
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtunidad.Text = ""
        txtcantidad.Text = ""
        txtprecio.Text = "0.00"
        txttotal.Text = "0.00"
        txtexiste.Text = ""
        txtserie.Text = ""
        cboremision.Items.Clear()
        cboremision.Text = ""
        cbofactura.Items.Clear()
        cbofactura.Text = ""
        cbopedido.Items.Clear()
        cbopedido.Text = ""

        cboproveedor.Items.Clear()
        cboproveedor.Text = ""
        txtsaldo.Text = "0.00"
        txtpAnticipo.Text = "0.00"
        cbomoneda.Text = "PESO"
        cbomoneda.Tag = "0"
        txtvalor.Text = "1.00"
        lblmoneda.Text = ""
        lblvalor.Text = ""
        grdcaptura.Rows.Clear()

        txtsub1.Text = "0.00"
        txtdesc1.Text = "0.00"
        txtsub2.Text = "0.00"
        txtiva.Text = "0.00"
        txtTotalC.Text = "0.00"
        txtdesc2.Text = "0.00"
        txtieps.Text = "0.00"
        txtapagar.Text = "0.00"
        txtanticipo.Text = "0.00"
        txtpagos.Text = "0.00"
        txtefectivo.Text = "0.00"
        txtresta.Text = "0.00"
        txtprods.Text = "0"


        btncancela.Enabled = False
        btnactualiza.Enabled = False
        btnguardar.Enabled = True
        btncopia.Enabled = True
        Button1.Enabled = False
        btnPagar.Enabled = True
        txtpAnticipo.Enabled = False
        lblpAnticipo.Enabled = False

        panpago_compra.Visible = False
        txtpc_apagar.Text = "0.00"
        txtpc_anticipo.Text = "0.00"
        txtpc_efectivo.Text = "0.00"
        txtpc_tarjeta.Text = "0.00"
        txtpc_transfe.Text = "0.00"
        txtpc_otro.Text = "0.00"
        txtpc_resta.Text = "0.00"

        Pagos.pc_porpagar = 0
        Pagos.pc_anticipo = 0
        Pagos.pc_efectivo = 0
        Pagos.pc_tarjeta = 0
        Pagos.pc_transfe = 0
        Pagos.pc_otros = 0
        Pagos.pc_resta = 0

        ' Panel1.Visible = False
        tipo_cancelacion = ""

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "delete from AuxCompras"
        cmd1.ExecuteNonQuery() : cnn1.Close()

        cboproveedor.Focus().Equals(True)

    End Sub

    Public Sub IVA()
        Dim tasaIVA As Double = 0
        Dim opeIEPS As Double = 0

        If txtiva.Text = "" Then txtiva.Text = "0.00"
        txtiva.Tag = "0"

        cnn4.Close() : cnn4.Open()
        cmd4 = cnn4.CreateCommand
        cmd4.CommandText = "SELECT IVA, IIEPS FROM Productos WHERE Codigo='" & txtcodigo.Text & "'"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                If cbofactura.Text <> "" Then
                    If CDbl(rd4(1).ToString) > 0 Then
                        opeIEPS = CDbl(txttotal.Text) * ProdsIEPS(txtcodigo.Text)
                    Else
                        opeIEPS = 0
                    End If
                    tasaIVA = rd4(0).ToString
                    txtiva.Tag = FormatNumber(tasaIVA * (CDbl(txttotal.Text) + opeIEPS), 8)
                    txtiva.Text = FormatNumber(((CDbl(txttotal.Text) + opeIEPS) * tasaIVA) + CDbl(txtiva.Text), 2)
                End If
            End If
        End If
        rd4.Close()
        cnn4.Close()
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
        If Not IsNumeric(txtprecio.Text) Then txtprecio.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Then txtcantidad.Focus().Equals(True) : Exit Sub
            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
            txttotal.Text = FormatNumber(txttotal.Text, 2)
            txtserie.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtserie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtserie.KeyPress
        If cbonombre.Text = "" Then cbonombre.Focus().Equals(True)
        If Trim(lblmoneda.Text) <> Trim(cbomoneda.Text) Then
            MsgBox("No se puede continuar porque el tipo de moneda del pedido no coincide con el tipo de moneda del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        On Error GoTo kaka

        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM MiProd WHERE CodigoP='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If MsgBox("Este producto forma parte de una producción, ¿deseas continuar con la compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                        txtcodigo.Text = ""
                        cbonombre.Items.Clear()
                        cbonombre.Text = ""
                        txtunidad.Text = ""
                        txtcantidad.Text = ""
                        txtprecio.Text = "0.00"
                        txttotal.Text = "0.00"
                        txtexiste.Text = ""
                        txtserie.Text = ""
                        txtcodigo.Focus().Equals(True)
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

            Dim CP As Integer = 0

            If txtprecio.Text = "" Then txtprecio.Focus().Equals(True) : Exit Sub
            If txtcantidad.Text = "" Then txtcantidad.Focus().Equals(True) : Exit Sub
            If (CDbl(txtprecio.Text) / CDbl(txtvalor.Text)) <> CDbl(lblvalor.Text) Then
                If MsgBox("El precio de compra va a cambiar en la base de datos." & vbNewLine & "¿Desea que los porcentajes y precios de venta se modifiquen también?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    CP = 1
                Else
                    CP = 0
                End If

                If txtcantidad.Text = "" Then txtcantidad.Text = "0"
                If txtcantidad.Text = "0" And cbonombre.Text <> "" Then txtcantidad.Focus().Equals(True) : Exit Sub
                txttotal.Text = FormatNumber(CDbl(txtcantidad.Text) * CDbl(txtprecio.Text), 2)
                txtsub1.Text = CDbl(txttotal.Text) + CDbl(txtsub1.Text)
                txtsub1.Text = FormatNumber(txtsub1.Text, 2)
                If cbofactura.Text <> "" Then
                    txtiva.Tag = "0"
                    Call IVA()
                    txtTotalC.Text = CDbl(txtiva.Text) + CDbl(txtsub2.Text)
                    txtiva.Text = FormatNumber(txtiva.Text, 2)
                    txtTotalC.Text = FormatNumber(txtTotalC.Text, 2)
                Else
                    txtTotalC.Text = FormatNumber(txtsub2.Text, 2)
                End If

                If (cbonombre.Text <> "" And txtprecio.Text <> "") Then
                    Call UpGrid(CP)

                    txtsub1.Text = FormatNumber(CDbl(txtsub1.Text) + CDbl(txtieps.Text), 2)

                    txtcodigo.Text = ""
                    cbonombre.Text = ""
                    txtunidad.Text = ""
                    txtcantidad.Text = ""
                    txtprecio.Text = "0.00"
                    txttotal.Text = "0.00"
                    txtexiste.Text = ""
                    txtserie.Text = ""
                    cbonombre.Focus().Equals(True)

                    lblmoneda.Text = ""
                    lblvalor.Text = "0.00"

                    If cbofactura.Text = "" Then Exit Sub
                    txtiva.Text = FormatNumber(txtiva.Text, 2)
                    txtTotalC.Text = FormatNumber(CDbl(txtiva.Text) + CDbl(txtsub2.Text), 2)

                    cbomoneda.Enabled = False
                    txtvalor.Enabled = False
                    cbonombre.Focus().Equals(True)
                End If
                Exit Sub

            Else
                If txtcantidad.Text = "" Then txtcantidad.Text = "0"
                If txtcantidad.Text = "0" And cbonombre.Text <> "" Then txtcantidad.Focus().Equals(True) : Exit Sub
                txttotal.Text = FormatNumber(CDbl(txtcantidad.Text) * CDbl(txtprecio.Text), 2)
                txtsub1.Text = CDbl(txttotal.Text) + CDbl(txtsub1.Text)
                txtsub1.Text = FormatNumber(txtsub1.Text, 2)
                If cbofactura.Text <> "" Then
                    txtiva.Tag = "0"
                    Call IVA()
                    txtTotalC.Text = CDbl(txtiva.Text) + CDbl(txtsub2.Text)
                    txtiva.Text = FormatNumber(txtiva.Text, 2)
                    txtTotalC.Text = FormatNumber(txtTotalC.Text, 2)
                Else
                    txtTotalC.Text = FormatNumber(txtsub2.Text, 2)
                End If

                If (cbonombre.Text <> "" And txtprecio.Text <> "") Then
                    Call UpGrid(CP)

                    txtsub1.Text = FormatNumber(CDbl(txtsub1.Text) + CDbl(txtieps.Text), 2)

                    txtcodigo.Text = ""
                    cbonombre.Text = ""
                    txtunidad.Text = ""
                    txtcantidad.Text = ""
                    txtprecio.Text = "0.00"
                    txttotal.Text = "0.00"
                    txtexiste.Text = ""
                    txtserie.Text = ""
                    cbonombre.Focus().Equals(True)

                    lblmoneda.Text = ""
                    lblvalor.Text = "0.00"

                    If cbofactura.Text = "" Then Exit Sub
                    txtiva.Text = FormatNumber(txtiva.Text, 2)
                    txtTotalC.Text = FormatNumber(CDbl(txtiva.Text) + CDbl(txtsub2.Text), 2)

                    cbomoneda.Enabled = False
                    txtvalor.Enabled = False
                    cbonombre.Focus().Equals(True)
                End If
                Exit Sub
            End If
        End If
        Exit Sub
kaka:
        MsgBox(Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub

    End Sub

    Public Sub UpGrid(ByVal CP As Integer)
        Dim PrecioU As Double = 0
        Dim PrecioC As Double = 0
        Dim ProductoIEPS As Double = 0
        Dim Conteo As Double = 0
        Dim CantidadP As Double = 0
        Dim TotalP As Double = 0

        Dim Pi As Double = 0
        Dim Pil As Double = 0

        If Trim(txtserie.Text) <> "" Then
            grdcaptura.Rows.Add(
                txtcodigo.Text,
                cbonombre.Text,
                txtunidad.Text,
                txtcantidad.Text,
                FormatNumber(txtprecio.Text, 4),
                FormatNumber(txttotal.Text, 2),
                txtexiste.Text,
                txtserie.Text,
                CP
                )
        Else
            grdcaptura.Rows.Add(
                txtcodigo.Text,
                cbonombre.Text,
                txtunidad.Text,
                txtcantidad.Text,
                FormatNumber(txtprecio.Text, 4),
                FormatNumber(txttotal.Text, 2),
                txtexiste.Text,
                "",
                "",
                CP
                )
        End If


        Dim varOperacion As Double = 0

        For i As Integer = 0 To grdcaptura.Rows.Count - 1
            varOperacion = varOperacion + CDbl(grdcaptura.Rows(i).Cells(5).Value.ToString)
            Conteo = Conteo + CDbl(grdcaptura.Rows(i).Cells(3).Value.ToString)
        Next

        txtsub1.Text = FormatNumber(varOperacion, 2)

        CantidadP = txtcantidad.Text
        PrecioU = txtprecio.Text
        TotalP = PrecioU * CantidadP
        PrecioC = txtprecio.Text
        Pi = ProdsIEPS(txtcodigo.Text)
        Pil = FormatNumber(PrecioU * Pi, 4)
        ProductoIEPS = CDbl(txtcantidad.Text) * Pil
        If cboremision.Text <> "" And cbofactura.Text = "" Then
            txtieps.Text = "0.00"
        Else
            txtieps.Text = FormatNumber(CDbl(txtieps.Text) + ProductoIEPS, 2)
        End If
        txtprods.Text = Conteo

        If txtserie.Text <> "" Then
            cnn1.Close() : cnn1.Open() : cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into AuxCompras(Rem,Fac,Ped,Proveedor,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Serie,CP) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "','" & cboproveedor.Text & "','" & txtcodigo.Text & "','" & cbonombre.Text & "','" & txtunidad.Text & "'," & CantidadP & "," & PrecioU & "," & TotalP & ",'" & txtserie.Text & "'," & CP & ")"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        Else
            cnn1.Close() : cnn1.Open() : cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into AuxCompras(Rem,Fac,Ped,Proveedor,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Serie,CP) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "','" & cboproveedor.Text & "','" & txtcodigo.Text & "','" & cbonombre.Text & "','" & txtunidad.Text & "'," & CantidadP & "," & PrecioU & "," & TotalP & ",'',''," & CP & ")"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        End If

    End Sub

    Public Sub IVA2()
        Dim Zi As Integer = 0
        Dim codigo As String = ""
        Dim ImpIVA As Double = 0
        Dim ImIVA As Double = 0

        If cbofactura.Text <> "" Then
            If grdcaptura.Rows.Count > 0 Then
                cnn1.Close() : cnn1.Open()
                Do While grdcaptura.Rows.Count <> Zi
                    codigo = grdcaptura.Rows(Zi).Cells(0).Value.ToString

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            ImpIVA = CDbl(rd1("IVA").ToString) * CDbl(grdcaptura.Rows(Zi).Cells(5).Value.ToString)
                            ImIVA = ImIVA + ImpIVA
                        End If
                    End If
                    rd1.Close()
                    Zi += 1
                Loop
                cnn1.Close()
            End If
        End If
        txtiva.Text = FormatNumber(ImIVA, 2)
    End Sub

    Private Sub txtsub1_TextChanged(sender As Object, e As EventArgs) Handles txtsub1.TextChanged
        txtsub2.Text = FormatNumber(txtsub1.Text)
    End Sub

    Private Sub txtdesc1_Click(sender As Object, e As EventArgs) Handles txtdesc1.Click
        txtdesc1.SelectionStart = 0
        txtdesc1.SelectionLength = Len(txtdesc1.Text)
    End Sub

    Private Sub txtdesc1_GotFocus(sender As Object, e As EventArgs) Handles txtdesc1.GotFocus
        txtdesc1.SelectionStart = 0
        txtdesc1.SelectionLength = Len(txtdesc1.Text)
    End Sub

    Private Sub txtdesc1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdesc1.KeyPress
        If Not IsNumeric(txtdesc1.Text) Then txtdesc1.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdesc2.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdesc1_LostFocus(sender As Object, e As EventArgs) Handles txtdesc1.LostFocus
        txtdesc1.Text = FormatNumber(txtdesc1.Text, 2)
    End Sub

    Private Sub txtdesc1_TextChanged(sender As Object, e As EventArgs) Handles txtdesc1.TextChanged
        If Strings.Left(txtdesc1.Text, 1) = "," Then Exit Sub
        If txtdesc1.Text = "" Then txtdesc1.Text = "0.00"
        If txtsub1.Text = "" Then txtsub1.Text = "0.00"
        If CDbl(txtdesc1.Text) > CDec(txtsub1.Text) Then
            MsgBox("Descuento no permitido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtdesc1.Text = Strings.Left(txtdesc1.Text, Len(txtdesc1.Text) - 1)
            txtdesc1.SelectionStart = 0
            txtdesc1.SelectionLength = Len(txtdesc1.Text)
        End If

        txtsub2.Text = CDbl(IIf(txtsub1.Text = "", 0, txtsub1.Text)) - CDbl(IIf(txtdesc1.Text = "", 0, txtdesc1.Text))
        txtsub2.Text = FormatNumber(txtsub2.Text, 2)

        txtiva.Text = FormatNumber(txtiva.Text, 2)
        txtTotalC.Text = FormatNumber(CDbl(txtsub2.Text) + CDbl(txtiva.Text), 2)
    End Sub

    Private Sub txtsub2_Click(sender As Object, e As EventArgs) Handles txtsub2.Click
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtsub2_GotFocus(sender As Object, e As EventArgs) Handles txtsub2.GotFocus
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtsub2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsub2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtsub2_LostFocus(sender As Object, e As EventArgs) Handles txtsub2.LostFocus
        txtdesc2.Text = FormatNumber(txtdesc2.Text, 2)
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        Dim id_usu As Integer = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_usu = rd1("IdEmpleado").ToString()
                        alias_compras = rd1("Alias").ToString()
                        lblusuario.Text = rd1("Alias").ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Permisos where IdEmpleado=" & id_usu
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Comp_Com").ToString() = True Then
                            If btnguardar.Enabled = False Then
                                btncancela.Focus().Equals(True)
                            Else
                                btnguardar.Focus().Equals(True)
                            End If
                            rd1.Close() : cnn1.Close() : Exit Sub
                        Else
                            MsgBox("No cuentas con permisos suficientes para interactuar con este formulario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd1.Close() : cnn1.Close() : Exit Sub
                        End If
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtapagar_TextChanged(sender As Object, e As EventArgs) Handles txtapagar.TextChanged
        cnn3.Close() : cnn3.Open()
        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "SELECT Resta FROM Compras WHERE NumRemision='" & cboremision.Text & "' AND Proveedor='" & cboproveedor.Text & "'"
        rd3 = cmd3.ExecuteReader
        If rd3.HasRows Then
            If rd3.Read Then
                txtresta.Text = rd3(0).ToString
                txtresta.Text = FormatNumber(txtresta.Text, 2)
            End If
        Else
            txtresta.Text = CDbl(IIf(txtapagar.Text = "", 0, txtapagar.Text)) - (CDbl(IIf(txtanticipo.Text = "", 0, txtanticipo.Text)) + CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0, txtpagos.Text)))
            txtresta.Text = FormatNumber(txtresta.Text, 2)
        End If
        rd3.Close()
        cnn3.Close()
    End Sub

    Private Sub txtiva_TextChanged(sender As Object, e As EventArgs) Handles txtiva.TextChanged
        If txtiva.Text = "" Then txtiva.Text = "0.00"
        If txtsub2.Text = "" Then txtsub2.Text = "0.00"
        txtTotalC.Text = FormatNumber(CDbl(txtsub2.Text) + CDbl(txtiva.Text), 2)
    End Sub

    Private Sub txtTotalC_TextChanged(sender As Object, e As EventArgs) Handles txtTotalC.TextChanged
        txtapagar.Text = CDbl(txtTotalC.Text) - CDbl(txtdesc2.Text)
        txtapagar.Text = FormatNumber(txtapagar.Text, 2)
    End Sub

    Private Sub txtanticipo_TextChanged(sender As Object, e As EventArgs) Handles txtanticipo.TextChanged
        txtresta.Text = CDbl(IIf(txtapagar.Text = "", 0, txtapagar.Text)) - (CDbl(IIf(txtanticipo.Text = "", 0, txtanticipo.Text)) + CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0, txtpagos.Text)))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtpagos_TextChanged(sender As Object, e As EventArgs) Handles txtpagos.TextChanged
        txtresta.Text = CDbl(IIf(txtapagar.Text = "", 0, txtapagar.Text)) - (CDbl(IIf(txtanticipo.Text = "", 0, txtanticipo.Text)) + CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0, txtpagos.Text)))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtefectivo_Click(sender As Object, e As EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_GotFocus(sender As Object, e As EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As EventArgs) Handles txtefectivo.TextChanged
        If Strings.Left(txtefectivo.Text, 1) = "," Then Exit Sub
        txtresta.Text = CDbl(IIf(txtapagar.Text = "", 0, txtapagar.Text)) - (CDbl(IIf(txtanticipo.Text = "", 0, txtanticipo.Text)) + CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0, txtpagos.Text)))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtefectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtefectivo.KeyPress
        If Not IsNumeric(txtefectivo.Text) Then txtefectivo.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtefectivo_LostFocus(sender As Object, e As EventArgs) Handles txtefectivo.LostFocus
        txtefectivo.Text = FormatNumber(txtefectivo.Text, 2)
    End Sub

    Private Sub grdcaptura_KeyDown(sender As Object, e As KeyEventArgs) Handles grdcaptura.KeyDown
        Dim index As Integer = grdcaptura.CurrentRow.Index
        Dim codigo As String = grdcaptura.CurrentRow.Cells(0).Value.ToString
        Dim cantidad As Double = grdcaptura.CurrentRow.Cells(3).Value.ToString
        Dim valTotal As Double = 0
        Dim cant As Double = 0
        If e.KeyCode = Keys.Delete Then
            If grdcaptura.Rows.Count = 0 Then Exit Sub
            valTotal = grdcaptura.Rows(index).Cells(5).Value.ToString
            txtsub1.Text = CDbl(txtsub1.Text) - valTotal
            txtsub1.Text = FormatNumber(txtsub1.Text, 2)

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from AuxCompras where Codigo='" & codigo & "' and Cantidad=" & cantidad
            cmd1.ExecuteNonQuery()

            If grdcaptura.Rows.Count = 1 Then
                grdcaptura.Rows.Clear()
                txtsub1.Text = "0.00"
                txtdesc1.Text = "0.00"
                txtsub2.Text = "0.00"
                txtdesc2.Text = "0.00"
                txtTotalC.Text = "0.00"
                txtiva.Text = "0.00"
                txtprods.Text = "0"
            Else
                If txtiva.Text = "" Then txtiva.Text = "0.00"
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & codigo & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If cbofactura.Text <> "" Then
                            txtiva.Text = CDbl(txtiva.Text) - (valTotal * CDbl(rd1(0).ToString))
                            txtiva.Text = FormatNumber(txtiva.Text, 2)
                        End If
                    End If
                End If
                rd1.Close()
                cant = CDbl(txtprods.Text) - cantidad
                txtprods.Text = cant
                grdcaptura.Rows.Remove(grdcaptura.Rows(index))
            End If
            If txtsub1.Text = "0.00" Then cbonombre.Focus().Equals(True)
            cnn1.Close()
        End If
    End Sub
    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick

        Dim PrecioU As Double = 0
        Dim PrecioC As Double = 0
        Dim ProductoIEPS As Double = 0
        Dim Conteo As Double = 0
        Dim CantidadP As Double = 0
        Dim TotalP As Double = 0

        Dim Pi As Double = 0
        Dim Pil As Double = 0

        Dim index As Integer = grdcaptura.CurrentRow.Index
        If grdcaptura.Rows.Count > 0 Then
            If grdcaptura.DefaultCellStyle.ForeColor = Color.DarkGoldenrod Then Exit Sub
            txtcodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
            cbonombre.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
            txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
            txtcantidad.Text = grdcaptura.Rows(index).Cells(3).Value.ToString
            txtprecio.Text = FormatNumber(grdcaptura.Rows(index).Cells(4).Value.ToString, 4)
            txttotal.Text = FormatNumber(grdcaptura.Rows(index).Cells(5).Value.ToString, 2)

            If CStr(grdcaptura.Rows(index).Cells(0).Value.ToString) = "" Then
            Else
                cnn1.Close() : cnn1.Open() : cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from AuxCompras where Codigo='" & txtcodigo.Text & "' and Cantidad=" & txtcantidad.Text
                cmd1.ExecuteNonQuery() : cnn1.Close()
            End If

            If grdcaptura.Rows.Count = 1 Then
                grdcaptura.Rows.Clear()
                txtprods.Text = ""
            Else
                grdcaptura.Rows.Remove(grdcaptura.Rows(index))
                txtprods.Text = CDbl(txtprods.Text) - CDbl(txtcantidad.Text)
            End If

            Dim varOperacion As Double = 0

            For i As Integer = 0 To grdcaptura.Rows.Count - 1
                varOperacion = varOperacion + CDbl(grdcaptura.Rows(i).Cells(5).Value.ToString)
            Next

            txtsub1.Text = FormatNumber(varOperacion, 2)
            PrecioU = txtprecio.Text
            PrecioC = txtprecio.Text
            Pi = ProdsIEPS(txtcodigo.Text)
            Pil = CDbl(txtprecio.Text) * Pi
            ProductoIEPS = CDbl(txtcantidad.Text) * Pil
            txtieps.Text = FormatNumber(CDbl(txtieps.Text) + ProductoIEPS, 2)
            txtsub1.Text = FormatNumber(CDbl(txtsub1.Text) + CDbl(txtieps.Text), 2)

            If txtsub1.Text = "0.00" Then cbonombre.Focus().Equals(True)
            If cbofactura.Text <> "" Then
                txtiva.Tag = "0"
                Call IVA2()
            End If
            txtcodigo.Focus().Equals(True)
            txtTotalC.Text = FormatNumber(CDbl(txtsub1.Text) + CDbl(txtiva.Text), 2)
            txtapagar.Text = FormatNumber(CDbl(txtsub1.Text) + CDbl(txtiva.Text), 2)
            lblvalor.Text = FormatNumber(txtprecio.Text, 2)
        End If
    End Sub
    Private Sub txtdesc2_Click(sender As Object, e As EventArgs) Handles txtdesc2.Click
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtdesc2_GotFocus(sender As Object, e As EventArgs) Handles txtdesc2.GotFocus
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtdesc2_TextChanged(sender As Object, e As EventArgs) Handles txtdesc2.TextChanged
        If Strings.Left(txtdesc2.Text, 1) = "," Then Exit Sub
        If txtdesc2.Text = "" Then Exit Sub
        txtapagar.Text = CDbl(IIf(txtTotalC.Text = "", 0, txtTotalC.Text)) - CDbl(IIf(txtdesc2.Text = "", 0, txtdesc2.Text))
        txtapagar.Text = FormatNumber(txtapagar.Text, 2)
    End Sub

    Private Sub txtdesc2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdesc2.KeyPress
        If Not IsNumeric(txtdesc2.Text) Then txtdesc2.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdesc2_LostFocus(sender As Object, e As EventArgs) Handles txtdesc2.LostFocus
        txtdesc2.Text = FormatNumber(txtdesc2.Text, 2)
    End Sub
End Class