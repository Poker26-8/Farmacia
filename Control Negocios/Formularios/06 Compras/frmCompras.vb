Imports System.IO
Imports System.Xml
Imports System.Data.OleDb

Public Class frmCompras
    Dim DondeVoy As String = ""
    Dim tipo_impre As String = ""
    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim pagina As Integer = 0
    Dim alias_compras As String = ""
    Dim tipo_cancelacion As String = ""

    Public Structure Pagos
        Shared pc_porpagar As Double = 0
        Shared pc_anticipo As Double = 0
        Shared pc_efectivo As Double = 0
        Shared pc_tarjeta As Double = 0
        Shared pc_transfe As Double = 0
        Shared pc_otros As Double = 0
        Shared pc_resta As Double = 0
    End Structure

    Private Sub cbonombre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbonombre.KeyDown
        If e.KeyCode = Keys.F3 Then
            VieneDe_Compras = "ComprasN"
            frmBuscaCompras.Show()
        End If
    End Sub

    Private Sub cboproveedor_DropDown(sender As System.Object, e As System.EventArgs) Handles cboproveedor.DropDown
        cboproveedor.Items.Clear()
        btnnuevo.PerformClick()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Compania from Proveedores where Compania<>'' order by Compania"
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

    Private Sub cboproveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboproveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboremision.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboproveedor_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboproveedor.SelectedValueChanged
        If cboproveedor.Text <> "" Then
            txtsaldo.Text = "0.00"
            Dim dias As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
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

    Private Sub cbomoneda_DropDown(sender As System.Object, e As System.EventArgs) Handles cbomoneda.DropDown
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

    Private Sub cbomoneda_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbomoneda.SelectedValueChanged
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
            cmd2.CommandText =
                "select * from Productos where CodBarra='" & cbonombre.Text & "'"
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

            cnn2.Close()
        End If

        Return Bool
    End Function

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select distinct Nombre from Productos where Length(Codigo)<7 and Departamento <> 'SERVICIOS' and ProvRes<>1 order by Nombre"
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

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
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

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
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

    Private Sub txtvalor_Click(sender As System.Object, e As System.EventArgs) Handles txtvalor.Click
        txtvalor.SelectionStart = 0
        txtvalor.SelectionLength = Len(-txtvalor.Text)
    End Sub

    Private Sub txtvalor_GotFocus(sender As Object, e As System.EventArgs) Handles txtvalor.GotFocus
        txtvalor.SelectionStart = 0
        txtvalor.SelectionLength = Len(-txtvalor.Text)
    End Sub

    Private Sub txtvalor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalor.KeyPress
        If Not IsNumeric(txtvalor.Text) Then txtvalor.Text = "0.00"
        If AscW(e.KeyChar) = Keys.Enter Then
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbobanco_DropDown(sender As System.Object, e As System.EventArgs) Handles cbobanco.DropDown
        cbobanco.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Banco from Bancos"
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

    Private Sub cbotpago_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbotpago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbobanco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtrefe.Focus().Equals(True)
        End If
    End Sub

    Private Sub frmCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpfecha.Value = Now
        dtpfpago.Value = Now
        dtpcaducidad.Value = Now
        dtppago.Value = Now
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
        printLine = 0
        Contador = 0
        pagina = 0
        VieneDe_Compras = ""

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from tb_moneda where nombre_moneda='PESO' or nombre_moneda='PESOS'"
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
                Dim caducidad As String = rd1("Caducidad").ToString
                Dim lote As String = rd1("Lote").ToString
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
                    caducidad,
                    lote,
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

    Private Sub txtcodigo_Click(sender As System.Object, e As System.EventArgs) Handles txtcodigo.Click
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_GotFocus(sender As Object, e As System.EventArgs) Handles txtcodigo.GotFocus
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
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
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & txtcodigo.Text & "' and Departamento<>'SERVICIOS'"
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
                    cmd1.CommandText =
                        "select Existencia from Productos where Codigo='" & Strings.Left(txtcodigo.Text, 6) & "'"
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

    Private Sub cboremision_Click(sender As System.Object, e As System.EventArgs) Handles cboremision.Click
        cboremision.SelectionStart = 0
        cboremision.SelectionLength = Len(cboremision.Text)
    End Sub

    Private Sub cboremision_DropDown(sender As Object, e As System.EventArgs) Handles cboremision.DropDown
        cboremision.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct NumRemision from Compras where Proveedor='" & cboproveedor.Text & "' and NumRemision<>''"
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

    Private Sub cboremision_GotFocus(sender As Object, e As System.EventArgs) Handles cboremision.GotFocus
        cboremision.SelectionStart = 0
        cboremision.SelectionLength = Len(cboremision.Text)
    End Sub

    Private Sub cboremision_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboremision.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboproveedor.Text <> "" And cboremision.Text = "" Then MsgBox("El número de remisión no puede permanecer vacío.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            Dim Pedido As Integer = 0
            Dim conteo As Double = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumRemision, NumFactura, NumPedido, FechaC from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "' and Status<>'CANCELADA'"
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
                cmd1.CommandText =
                    "select * from ComprasDet where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
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
            cbofactura.Focus().Equals(True)
        End If
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
        If AscW(e.KeyChar) = Keys.Enter Then
            txtprecio.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_LostFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.LostFocus
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
            If MsgBox("Ya existe una compra bajo el número de remisión o factura. ¿Deseas realizar una nueva compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then btnnuevo.PerformClick()
        End If
    End Sub

    Private Sub cboremision_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboremision.SelectedValueChanged
        If cboremision.Text <> "" Then
            Call cboremision_KeyPress(cboremision, New KeyPressEventArgs(ChrW(Keys.Enter)))
        End If
    End Sub

    Private Sub cbofactura_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofactura.DropDown
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

    Private Sub cbofactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbofactura.KeyPress
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

    Private Sub cbofactura_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbofactura.SelectedValueChanged
        If cbofactura.Text <> "" Then
            Call cbofactura_KeyPress(cbofactura, New KeyPressEventArgs(ChrW(Keys.Enter)))
        End If
    End Sub

    Private Sub cbofactura_Click(sender As System.Object, e As System.EventArgs) Handles cbofactura.Click
        cbofactura.SelectionStart = 0
        cbofactura.SelectionLength = Len(cbofactura.Text)
    End Sub

    Private Sub cbofactura_GotFocus(sender As Object, e As System.EventArgs) Handles cbofactura.GotFocus
        cbofactura.SelectionStart = 0
        cbofactura.SelectionLength = Len(cbofactura.Text)
    End Sub

    Private Sub cbopedido_Click(sender As System.Object, e As System.EventArgs) Handles cbopedido.Click
        cbopedido.SelectionStart = 0
        cbopedido.SelectionLength = Len(cbopedido.Text)
    End Sub

    Private Sub cbopedido_DropDown(sender As Object, e As System.EventArgs) Handles cbopedido.DropDown
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

    Private Sub cbopedido_GotFocus(sender As Object, e As System.EventArgs) Handles cbopedido.GotFocus
        cbopedido.SelectionStart = 0
        cbopedido.SelectionLength = Len(cbopedido.Text)
    End Sub

    Private Sub cbopedido_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbopedido.KeyPress
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

    Private Sub dtpfecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpfecha.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        grdcaptura.DefaultCellStyle.ForeColor = Color.Black
        dtpfpago.Value = Date.Now
        dtpcaducidad.Value = Date.Now
        dtpfecha.Value = Date.Now
        dtppago.Value = Date.Now

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
        txtlote.Text = ""
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

        cbotpago.Items.Clear()
        cbotpago.Text = ""
        cbobanco.Items.Clear()
        cbobanco.Text = ""
        txtrefe.Text = ""
        txtmonto.Text = "0.00"
        grdPagos.Rows.Clear()
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

        Panel1.Visible = False
        tipo_cancelacion = ""

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "delete from AuxCompras"
        cmd1.ExecuteNonQuery() : cnn1.Close()

        cboproveedor.Focus().Equals(True)
    End Sub

    Private Sub txtprecio_Click(sender As System.Object, e As System.EventArgs) Handles txtprecio.Click
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_GotFocus(sender As Object, e As System.EventArgs) Handles txtprecio.GotFocus
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        If Not IsNumeric(txtprecio.Text) Then txtprecio.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Then txtcantidad.Focus().Equals(True) : Exit Sub
            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
            txttotal.Text = FormatNumber(txttotal.Text, 2)
            dtpcaducidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpcaducidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpcaducidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtlote.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtlote_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtlote.KeyPress
        If cbonombre.Text = "" Then cbonombre.Focus().Equals(True)
        If Trim(lblmoneda.Text) <> Trim(cbomoneda.Text) Then
            MsgBox("No se puede continuar porque el tipo de moneda del pedido no coincide con el tipo de moneda del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        On Error GoTo kaka

        If AscW(e.KeyChar) = Keys.Enter Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from MiProd where CodigoP='" & txtcodigo.Text & "'"
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
                        dtpcaducidad.Value = Date.Now
                        txtlote.Text = ""
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
                    dtpcaducidad.Value = Date.Now
                    txtlote.Text = ""
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
                    dtpcaducidad.Value = Date.Now
                    txtlote.Text = ""
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

        If Trim(txtlote.Text) <> "" Then
            grdcaptura.Rows.Add(
                txtcodigo.Text,
                cbonombre.Text,
                txtunidad.Text,
                txtcantidad.Text,
                FormatNumber(txtprecio.Text, 4),
                FormatNumber(txttotal.Text, 2),
                txtexiste.Text,
                FormatDateTime(dtpcaducidad.Value, DateFormat.ShortDate),
                txtlote.Text,
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

        If txtlote.Text <> "" Then
            cnn1.Close() : cnn1.Open() : cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into AuxCompras(Rem,Fac,Ped,Proveedor,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Caducidad,Lote,CP) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "','" & cboproveedor.Text & "','" & txtcodigo.Text & "','" & cbonombre.Text & "','" & txtunidad.Text & "'," & CantidadP & "," & PrecioU & "," & TotalP & ",'" & Format(dtpcaducidad.Value, "yyyy-MM-dd") & "','" & txtlote.Text & "'," & CP & ")"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        Else
            cnn1.Close() : cnn1.Open() : cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into AuxCompras(Rem,Fac,Ped,Proveedor,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Caducidad,Lote,CP) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "','" & cboproveedor.Text & "','" & txtcodigo.Text & "','" & cbonombre.Text & "','" & txtunidad.Text & "'," & CantidadP & "," & PrecioU & "," & TotalP & ",'',''," & CP & ")"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        End If
    End Sub

    Public Sub IVA()
        Dim tasaIVA As Double = 0
        Dim opeIEPS As Double = 0

        If txtiva.Text = "" Then txtiva.Text = "0.00"
        txtiva.Tag = "0"

        cnn4.Close() : cnn4.Open()
        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
            "select IVA, IIEPS from Productos where Codigo='" & txtcodigo.Text & "'"
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
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & codigo & "'"
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

    Private Sub txtsub1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtsub1.TextChanged
        txtsub2.Text = FormatNumber(txtsub1.Text)
    End Sub

    Private Sub txtdesc1_Click(sender As System.Object, e As System.EventArgs) Handles txtdesc1.Click
        txtdesc1.SelectionStart = 0
        txtdesc1.SelectionLength = Len(txtdesc1.Text)
    End Sub

    Private Sub txtdesc1_GotFocus(sender As Object, e As System.EventArgs) Handles txtdesc1.GotFocus
        txtdesc1.SelectionStart = 0
        txtdesc1.SelectionLength = Len(txtdesc1.Text)
    End Sub

    Private Sub txtdesc1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc1.KeyPress
        If Not IsNumeric(txtdesc1.Text) Then txtdesc1.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdesc2.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdesc1_LostFocus(sender As Object, e As System.EventArgs) Handles txtdesc1.LostFocus
        txtdesc1.Text = FormatNumber(txtdesc1.Text, 2)
    End Sub

    Private Sub txtdesc1_TextChanged(sender As Object, e As System.EventArgs) Handles txtdesc1.TextChanged
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

    Private Sub txtsub2_Click(sender As System.Object, e As System.EventArgs) Handles txtsub2.Click
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtsub2_GotFocus(sender As Object, e As System.EventArgs) Handles txtsub2.GotFocus
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtsub2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtsub2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtsub2_LostFocus(sender As Object, e As System.EventArgs) Handles txtsub2.LostFocus
        txtdesc2.Text = FormatNumber(txtdesc2.Text, 2)
    End Sub

    Private Sub txtusuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
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

    Private Sub txtapagar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtapagar.TextChanged
        cnn3.Close() : cnn3.Open()
        cmd3 = cnn3.CreateCommand
        cmd3.CommandText =
            "select Resta from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
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

    Private Sub txtrefe_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrefe.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtppago.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtppago_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtppago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmonto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbotpago.Text = "" Then cbotpago.Focus().Equals(True)
            If cbobanco.Text = "" Then cbobanco.Focus().Equals(True)
            If txtrefe.Text = "" Then txtrefe.Focus().Equals(True)
            If txtmonto.Text = "" Or CDec(txtmonto.Text) <= 0 Then txtmonto.SelectionStart = 0 : txtmonto.SelectionLength = Len(txtmonto.Text) : Exit Sub
            txtmonto.Text = FormatNumber(txtmonto.Text, 2)
            grdPagos.Rows.Add(
                cbotpago.Text,
                cbobanco.Text,
                txtrefe.Text,
                FormatDateTime(dtppago.Value, DateFormat.ShortDate),
                txtmonto.Text
                )
            grdPagos.Refresh()

            Dim varPagos As Double = 0

            For i As Integer = 0 To grdPagos.Rows.Count - 1
                varPagos = varPagos + CDbl(grdPagos.Rows(i).Cells(4).Value.ToString)
            Next

            txtpagos.Text = FormatNumber(varPagos, 2)
        End If
    End Sub

    Private Sub txtiva_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtiva.TextChanged
        If txtiva.Text = "" Then txtiva.Text = "0.00"
        If txtsub2.Text = "" Then txtsub2.Text = "0.00"
        txtTotalC.Text = FormatNumber(CDbl(txtsub2.Text) + CDbl(txtiva.Text), 2)
    End Sub

    Private Sub txtTotalC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalC.TextChanged
        txtapagar.Text = CDbl(txtTotalC.Text) - CDbl(txtdesc2.Text)
        txtapagar.Text = FormatNumber(txtapagar.Text, 2)
    End Sub

    Private Sub txtanticipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtanticipo.TextChanged
        txtresta.Text = CDbl(IIf(txtapagar.Text = "", 0, txtapagar.Text)) - (CDbl(IIf(txtanticipo.Text = "", 0, txtanticipo.Text)) + CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0, txtpagos.Text)))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtpagos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpagos.TextChanged
        txtresta.Text = CDbl(IIf(txtapagar.Text = "", 0, txtapagar.Text)) - (CDbl(IIf(txtanticipo.Text = "", 0, txtanticipo.Text)) + CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0, txtpagos.Text)))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtefectivo_Click(sender As System.Object, e As System.EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As System.EventArgs) Handles txtefectivo.TextChanged
        If Strings.Left(txtefectivo.Text, 1) = "," Then Exit Sub
        txtresta.Text = CDbl(IIf(txtapagar.Text = "", 0, txtapagar.Text)) - (CDbl(IIf(txtanticipo.Text = "", 0, txtanticipo.Text)) + CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0, txtpagos.Text)))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtefectivo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtefectivo.KeyPress
        If Not IsNumeric(txtefectivo.Text) Then txtefectivo.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtefectivo_LostFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.LostFocus
        txtefectivo.Text = FormatNumber(txtefectivo.Text, 2)
    End Sub

    Private Sub grdcaptura_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdcaptura.KeyDown
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
                cmd1.CommandText =
                    "select IVA from Productos where Codigo='" & codigo & "'"
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

    Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
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

    Private Sub txtdesc2_GotFocus(sender As Object, e As System.EventArgs) Handles txtdesc2.GotFocus
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtdesc2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdesc2.TextChanged
        If Strings.Left(txtdesc2.Text, 1) = "," Then Exit Sub
        If txtdesc2.Text = "" Then Exit Sub
        txtapagar.Text = CDbl(IIf(txtTotalC.Text = "", 0, txtTotalC.Text)) - CDbl(IIf(txtdesc2.Text = "", 0, txtdesc2.Text))
        txtapagar.Text = FormatNumber(txtapagar.Text, 2)
    End Sub

    Private Sub txtdesc2_Click(sender As System.Object, e As System.EventArgs) Handles txtdesc2.Click
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtdesc2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc2.KeyPress
        If Not IsNumeric(txtdesc2.Text) Then txtdesc2.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdesc2_LostFocus(sender As Object, e As System.EventArgs) Handles txtdesc2.LostFocus
        txtdesc2.Text = FormatNumber(txtdesc2.Text, 2)
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        Try
            Dim usuario As String = ""
            Dim MyID As Integer = 0
            Dim id_usuario As Integer = 0

            DondeVoy = "Guarda"
            If cboremision.Text = "" Then MsgBox("Escribe el número de remisión para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboremision.Focus().Equals(True) : Exit Sub
            If cboproveedor.Text = "" Then MsgBox("Selecciona un proveedor para continuar con la compra.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboproveedor.Focus().Equals(True) : Exit Sub
            If CDbl(txtresta.Text) < 0 Then MsgBox("El abono a la compra no puede ser mayor al total de la misma.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtefectivo.Focus().Equals(True) : Exit Sub
            If CDbl(txtsub1.Text) = 0 Then MsgBox("Falta algún precio o alguna cantidad.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcodigo.Focus().Equals(True) : Exit Sub
            If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Exit Sub

            If txtdesc1.Text = "" Then txtdesc1.Text = "0.00"
            If txtdesc2.Text = "" Then txtdesc2.Text = "0.00"
            If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"
            If txtanticipo.Text = "" Then txtanticipo.Text = "0.00"
            If txtpagos.Text = "" Then txtpagos.Text = "0.00"

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id from Proveedores where Compania='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MyID = rd1(0).ToString
                End If
            Else
                MsgBox("Este proveedor no se encuentra egistrado en el catálogo de proveedores." & vbNewLine & "Resgístralo para continuar con la compra.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close()
                cnn1.Close()
                cboproveedor.Focus().Equals(True)
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Usuarios where Clave='" & txtusuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    alias_compras = rd1("Alias").ToString()
                End If
            Else
                MsgBox("No se encuentra el usuario registrado en el sistema.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtusuario.SelectionStart = 0
                txtusuario.SelectionLength = Len(txtusuario.Text)
                txtusuario.Focus().Equals(True)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

            'Call txtefectivo_LostFocus(txtefectivo, New EventArgs())
            If MsgBox("¿Deseas guardar esta compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub

            For t As Integer = 0 To grdcaptura.Rows.Count - 1
                If CDbl(grdcaptura.Rows(t).Cells(3).Value.ToString) = 0 Then
                    MsgBox("Falta alguna cantidad.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
                If CDbl(grdcaptura.Rows(t).Cells(4).Value.ToString) = 0 Then
                    MsgBox("Falta algún precio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
            Next

            Dim MySaldo As Double = 0
            Dim Status As String = ""
            Dim MyACuenta As Double = 0
            Dim MySaldoF As Double = txtsaldo.Text
            Dim MyResta As Double = txtresta.Text

            Dim efectivo As Double = txtefectivo.Text
            Dim banco As String = ""
            Dim refer As String = ""
            Dim tarjeta As Double = 0
            Dim transfe As Double = 0
            Dim otro As Double = 0

            Dim pagadoc_saldo As Double = 0
            Dim sobra_saldo As Double = 0

            cnn1.Close() : cnn1.Open()

            If MySaldoF = 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) + CDbl(txtapagar.Text)
                    End If
                Else
                    MySaldo = CDbl(txtapagar.Text)
                End If
                rd1.Close()
                MySaldo = FormatNumber(MySaldo, 4)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','COMPRA','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & CDbl(txtapagar.Text) & ",0," & MySaldo & ",'','','" & alias_compras & "')"
                cmd1.ExecuteNonQuery()

                If CDbl(txtresta.Text) = 0 Then
                    Status = "PAGADO"
                Else
                    Status = "RESTA"
                End If

                MyACuenta = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

                If MyACuenta > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) - MyACuenta
                        End If
                    Else
                        MySaldo = MyACuenta
                    End If
                    rd1.Close()

                    tarjeta = txtpc_tarjeta.Text
                    transfe = txtpc_transfe.Text
                    otro = txtpc_otro.Text

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','ABONO','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MyACuenta & "," & MySaldo & "," & efectivo & "," & tarjeta & "," & transfe & "," & otro & ",'','','" & alias_compras & "',0,0,0)"
                    cmd1.ExecuteNonQuery()
                End If
            Else
                If CDbl(txtresta.Text) = 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) + CDbl(txtapagar.Text)
                        End If
                    Else
                        MySaldo = CDbl(txtapagar.Text)
                    End If
                    rd1.Close()
                    MySaldo = FormatNumber(MySaldo, 4)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','COMPRA','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & CDbl(txtapagar.Text) & ",0," & MySaldo & ",'','','" & alias_compras & "')"
                    cmd1.ExecuteNonQuery()

                    If CDbl(txtresta.Text) = 0 Then
                        Status = "PAGADO"
                    Else
                        Status = "RESTA"
                    End If

                    MyACuenta = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

                    If MyACuenta > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) - MyACuenta
                            End If
                        Else
                            MySaldo = MyACuenta
                        End If
                        rd1.Close()

                        tarjeta = txtpc_tarjeta.Text
                        transfe = txtpc_transfe.Text
                        otro = txtpc_otro.Text

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','ABONO','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MyACuenta & "," & MySaldo & "," & efectivo & "," & tarjeta & "," & transfe & "," & otro & ",'" & banco & "','" & refer & "','" & alias_compras & "',0,0,0)"
                        cmd1.ExecuteNonQuery()
                    End If
                Else
                    MyACuenta = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)
                    If MyACuenta > 0 Then
                        If MySaldoF > 0 Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString))
                                End If
                            Else
                                MySaldo = CDbl(txtapagar.Text)
                            End If
                            rd1.Close()
                            MySaldo = FormatNumber(MySaldo, 4)

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','COMPRA','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & CDbl(txtapagar.Text) & ",0," & MySaldo & ",'','','" & alias_compras & "')"
                            cmd1.ExecuteNonQuery()

                            Dim pagado As Double = 0
                            If MySaldoF > CDbl(txtresta.Text) Then
                                pagado = FormatNumber(MyACuenta + CDbl(txtresta.Text), 2)
                                sobra_saldo = MySaldoF - CDbl(txtresta.Text)
                            Else

                            End If

                            If pagado = CDbl(txtapagar.Text) Then
                                Status = "PAGADO"
                            Else
                                Status = "RESTA"
                            End If

                            If MyACuenta > 0 Then
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) + CDbl(txtresta.Text)
                                    End If
                                Else
                                    MySaldo = MyACuenta
                                End If
                                rd1.Close()

                                tarjeta = txtpc_tarjeta.Text
                                transfe = txtpc_transfe.Text
                                otro = txtpc_otro.Text

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','ABONO','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MyACuenta & "," & MySaldo & "," & efectivo & "," & tarjeta & "," & transfe & "," & otro & ",'" & banco & "','" & refer & "','" & alias_compras & "',0,0,0)"
                                cmd1.ExecuteNonQuery()
                            End If
                        Else

                        End If
                    Else
                        If MySaldoF > 0 Then

                        Else

                        End If
                    End If

                    If MySaldoF > CDbl(txtresta.Text) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString))
                            End If
                        Else
                            MySaldo = CDbl(txtapagar.Text)
                        End If
                        rd1.Close()
                        MySaldo = FormatNumber(MySaldo, 4)

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','COMPRA','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & CDbl(txtapagar.Text) & ",0," & MySaldo & ",'','','" & alias_compras & "')"
                        cmd1.ExecuteNonQuery()

                        Status = "PAGADO"
                        MyResta = 0

                        MyACuenta = CDbl(txtapagar.Text)

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & MyID & ")"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) + MyACuenta
                            End If
                        Else
                            MySaldo = MyACuenta
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & MyID & ",'" & cboproveedor.Text & "','ABONO','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MyACuenta & "," & MySaldo & "," & efectivo & "," & tarjeta & "," & transfe & "," & MyACuenta & ",'" & banco & "','" & refer & "','" & alias_compras & "',0,0,0)"
                        cmd1.ExecuteNonQuery()
                    ElseIf MySaldoF < CDbl(txtresta.Text) Then
                        If CDbl(txtresta.Text) = 0 Then
                            Status = "PAGADO"
                        Else
                            Status = "RESTA"
                        End If

                        MyACuenta = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)



                    End If
                End If
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into Compras(NumRemision,NumFactura,NumPedido,NotaCred,IdProv,Proveedor,Sub1,Desc1,Sub2,IVA,Total,Desc2,IEPS,Pagar,ACuenta,Resta,FechaC,FechaP,FechaNC,Status,FechaCancela,Usuario,Corte,CorteU,Cargado,Anticipo) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "',''," & MyID & ",'" & cboproveedor.Text & "'," & CDbl(txtsub1.Text) & "," & CDbl(txtdesc1.Text) & "," & CDbl(txtsub2.Text) & "," & CDbl(txtiva.Text) & "," & CDbl(txtTotalC.Text) & "," & CDbl(txtdesc2.Text) & "," & CDbl(txtieps.Text) & "," & CDbl(txtapagar.Text) & "," & MyACuenta & "," & MyResta & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & Format(dtpfpago.Value, "yyyy-MM-dd") & "','','" & Status & "','','" & alias_compras & "',0,0,0," & CDbl(txtanticipo.Text) & ")"
            cmd1.ExecuteNonQuery()

            Dim total_pagos As Double = tarjeta + transfe + otro

            If total_pagos > 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Fecha,Hora,Folio) values('Compra','" & banco & "','" & refer & "','COMPRA'," & total_pagos & "," & total_pagos & ",0,'" & Format(dtppago.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & cboremision.Text & "')"
                cmd1.ExecuteNonQuery()
            End If

            Dim IdCompra As Integer = 0

            Do Until IdCompra <> 0
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        IdCompra = rd1(0).ToString
                    End If
                End If
                rd1.Close()
            Loop

            Dim Zi As Integer = 0
            Do While grdcaptura.Rows.Count <> Zi
                Dim codigo As String = CStr(grdcaptura.Rows(Zi).Cells(0).Value.ToString())
                Dim nombre As String = CStr(grdcaptura.Rows(Zi).Cells(1).Value.ToString())
                Dim unidad As String = CStr(grdcaptura.Rows(Zi).Cells(2).Value.ToString())
                Dim cantid As Double = grdcaptura.Rows(Zi).Cells(3).Value.ToString()
                Dim precio As Double = FormatNumber(CDbl(grdcaptura.Rows(Zi).Cells(4).Value.ToString()), 4)
                Dim tottal As Double = FormatNumber(CDbl(grdcaptura.Rows(Zi).Cells(5).Value.ToString()), 2)
                Dim existe As Double = grdcaptura.Rows(Zi).Cells(6).Value.ToString()
                Dim caduc As String = grdcaptura.Rows(Zi).Cells(7).Value.ToString()
                Dim lote As String = grdcaptura.Rows(Zi).Cells(8).Value.ToString()
                Dim cp As Boolean = IIf(grdcaptura.Rows(Zi).Cells(9).Value.ToString() = "", 0, grdcaptura.Rows(Zi).Cells(9).Value.ToString())
                Dim dpto As String = "", grupo As String = ""
                Dim mymultiplo As Double = 0
                Dim iva_prod As Double = 0
                Dim pcompra As Double = 0, pventaiva As Double = 0, pminimo As Double = 0, pmayoreo As Double = 0, pespecial As Double = 0, pmedio As Double = 0
                Dim porventa As Double = 0, porminimo As Double = 0, pormayoreo As Double = 0, porespecial As Double = 0, pormedio As Double = 0

                Dim tipo_anti As String = ""

                pcompra = precio

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & codigo & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        iva_prod = CDbl(rd1("IVA").ToString) + 1
                        mymultiplo = rd1("Multiplo").ToString
                        porventa = rd1("Porcentaje").ToString
                        porminimo = rd1("PorcMin").ToString
                        pormayoreo = rd1("PorcMay")
                        pormedio = rd1("PorcMM").ToString
                        porespecial = rd1("PorcEsp").ToString
                        dpto = rd1("Departamento").ToString
                        grupo = rd1("Grupo").ToString
                        existe = rd1("Existencia").ToString
                    End If
                End If
                rd1.Close()

                If dpto = "ANTIBIOTICO" Then
                    tipo_anti = "ANTIBIOTICO"
                Else
                    tipo_anti = ""
                End If

                Dim nueva_exis As Double = existe + (cantid * mymultiplo)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into ComprasDet(Id_Compra,NumRemision,NumFactura,Proveedor,Codigo,Nombre,UCompra,Cantidad,Precio,Total,FechaC,Grupo,Depto,Caducidad,Lote,FolioRep,NotaCred) values(" & IdCompra & ",'" & cboremision.Text & "','" & cbofactura.Text & "','" & cboproveedor.Text & "','" & codigo & "','" & nombre & "','" & unidad & "'," & cantid & "," & precio & "," & tottal & ",'" & Format(dtpfecha.Value, "yyyy-MM-dd HH:mm:ss") & "','" & grupo & "','" & dpto & "','" & caduc & "','" & lote & "',0,'')"
                cmd1.ExecuteNonQuery()

                If cp = 1 Then
                    pventaiva = FormatNumber((pcompra * iva_prod) + ((pcompra * iva_prod) * (porventa / 100)), 2)
                    pminimo = FormatNumber((pcompra * iva_prod) + ((pcompra * iva_prod) * (porminimo / 100)), 2)
                    pmayoreo = FormatNumber((pcompra * iva_prod) + ((pcompra * iva_prod) * (pormayoreo / 100)), 2)
                    pmedio = FormatNumber((pcompra * iva_prod) + ((pcompra * iva_prod) * (pormedio / 100)))
                    pespecial = FormatNumber((pcompra * iva_prod) + ((pcompra * iva_prod) + (porespecial / 100)), 2)

                    If porventa > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PrecioVentaIVA=" & pventaiva & " where Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()
                    End If

                    If porminimo > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMin=" & pminimo & " where Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()
                    End If

                    If pormedio > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMM=" & pmedio & " where Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()
                    End If

                    If pormayoreo > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMay=" & pmayoreo & " where Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()
                    End If

                    If porespecial > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreEsp=" & pespecial & " where Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()
                    End If
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','COMPRA','" & cboremision.Text & "','" & codigo & "','" & nombre & "','" & unidad & "'," & (cantid * mymultiplo) & ",0," & (cantid * mymultiplo) & "," & pcompra & ",0,0,'" & alias_compras & "')"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Productos set Existencia=" & nueva_exis & ", PrecioCompra=" & pcompra & ", Cargado=0, Almacen3=" & pcompra & " where Codigo='" & codigo & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & nombre & "','Ingreso por compra'," & existe & "," & CDbl(cantid * mymultiplo) & "," & CDbl(existe + (cantid * mymultiplo)) & "," & pcompra & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & alias_compras & "','" & cboremision.Text & "','" & tipo_anti & "','','','','')"
                cmd1.ExecuteNonQuery()

                If lote <> "" Then
                    Dim id_lote As Integer = 0
                    Dim cantidad_lote As Double = 0
                    Dim existe_lote As Boolean = False

                    Call BorraLotes()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from LoteCaducidad where Lote='" & lote & "' and Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            id_lote = rd1("Id").ToString
                            cantidad_lote = rd1("Cantidad").ToString
                            existe_lote = True
                        End If
                    Else
                        existe_lote = False
                    End If
                    rd1.Close()

                    If (existe_lote) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update LoteCaducidad set Cantidad=" & CDbl(cantidad_lote + (cantid * mymultiplo)) & " where Lote='" & lote & "' and Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()
                    Else
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & codigo & "','" & lote & "','" & Format(CDate(caduc), "yyyy-MM-dd") & "'," & cantid & ")"
                        cmd1.ExecuteNonQuery()
                    End If
                End If
                Zi += 1
            Loop

            If cbopedido.Text <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Pedidos set Status=1 where Num='" & cbopedido.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                cmd1.ExecuteNonQuery()
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from AuxCompras"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            'Pregunta sí se quiere imprimir la compra
            If MsgBox("¿Deseas imprimir la compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Dim ImprimeEn As String = ""
                Dim Impresora As String = ""
                Dim tPapel As String = ""
                Dim tMilimetros As String = ""

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Formato from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Compras'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        tPapel = rd1(0).ToString
                    End If
                Else
                    MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de ventas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
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
                        tMilimetros = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & tPapel & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Impresora = rd1(0).ToString
                    End If
                Else
                    If tPapel = "MEDIA CARTA" Then
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
                            MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                        rd2.Close() : cnn2.Close()
                    End If
                    cnn1.Close()
                End If
                rd1.Close() : cnn1.Close()

                If tPapel = "TICKET" Then
                    If tMilimetros = "80" Then
                        pTicket80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pTicket80.Print()
                    End If
                    If tMilimetros = "58" Then
                        pTicket58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pTicket58.Print()
                    End If
                Else
                    If tPapel = "MEDIA CARTA" Then
                        pMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pMediaCarta.Print()
                    End If
                    If tPapel = "CARTA" Then
                        pCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pCarta.Print()
                    End If
                End If
                If tPapel = "PDF - CARTA" Then
                    'Genera PDF y lo guarda en la ruta

                End If
            End If

            btnnuevo.PerformClick()
            cboproveedor.Focus().Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtpAnticipo_Click(sender As System.Object, e As System.EventArgs) Handles txtpAnticipo.Click
        txtpAnticipo.SelectionStart = 0
        txtpAnticipo.SelectionLength = Len(txtpAnticipo.Text)
    End Sub

    Private Sub txtpAnticipo_GotFocus(sender As Object, e As System.EventArgs) Handles txtpAnticipo.GotFocus
        txtpAnticipo.SelectionStart = 0
        txtpAnticipo.SelectionLength = Len(txtpAnticipo.Text)
    End Sub

    Private Sub txtpAnticipo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpAnticipo.KeyPress
        If Not IsNumeric(txtpAnticipo.Text) Then txtpAnticipo.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            Button1.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpAnticipo_LostFocus(sender As Object, e As System.EventArgs) Handles txtpAnticipo.LostFocus
        txtpAnticipo.Text = FormatNumber(txtpAnticipo.Text, 2)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim ant_disponible As Double = 0
        Dim ant_pedidos As Double = 0
        Dim saldo_disponible As Double = 0

        If CDbl(txtpAnticipo.Text) > 0 Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT * FROM Pedidos WHERE Proveedor='" & cboproveedor.Text & "' AND Status=0"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        ant_pedidos = ant_pedidos + CDbl(rd1("Anticipo").ToString)
                    End If
                Loop
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoE where Id=(SELECT MAX(Id) FROM AbonoE WHERE Proveedor='" & cboproveedor.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        saldo_disponible = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString))
                        saldo_disponible = Math.Abs(saldo_disponible)
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

            ant_disponible = saldo_disponible - ant_pedidos
            If CDbl(txtpAnticipo.Text) > ant_disponible Then
                MsgBox("No cuentas con el saldo suficiente para aplicar este anticipo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtpAnticipo.Text = "0.00"
                txtpAnticipo.SelectionStart = 0
                txtpAnticipo.SelectionLength = Len(txtpAnticipo.Text)
                Exit Sub
            Else
                txtanticipo.Text = FormatNumber(txtpAnticipo.Text, 2)
            End If
        Else
            MsgBox("No has escrito un anticipo válido para aplicar a la compra.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If
    End Sub

    Private Sub pTicket80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pTicket80.PrintPage
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

        On Error GoTo kakita

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
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
                Pie = rd1("Pie2").ToString
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

        '[1]. Datos de la compra
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        If tipo_impre = "NORMAL" Then
            e.Graphics.DrawString("C O M P R A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
        End If
        If tipo_impre = "COPIA" Then
            e.Graphics.DrawString("C O P I A - C  O M P R A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
        End If
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("N° Remisión: " & cboremision.Text, fuente_datos, Brushes.Black, 1, Y)
        Y += 13.5
        If cbofactura.Text <> "" Then
            e.Graphics.DrawString("N° Factura: " & cbofactura.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 13.5
        End If
        If cbopedido.Text <> "" Then
            e.Graphics.DrawString("N° Pedido: " & cbopedido.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 13.5
        End If
        Y += 4
        e.Graphics.DrawString("Fecha: " & Date.Now, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 13.5
        e.Graphics.DrawString("Usuario: " & alias_compras, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 17

        '[2]. Datos del proveedor
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                If rd1("Compania").ToString <> "" Then
                    e.Graphics.DrawString("Nombre: " & Mid(rd1("Compania").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(rd1("Compania").ToString, 29, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Compania").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                If rd1("RFC").ToString <> "" Then
                    e.Graphics.DrawString("RFC: " & rd1("RFC").ToString, fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                If rd1("Correo").ToString <> "" Then
                    e.Graphics.DrawString("Correo: " & Mid(rd1("Correo").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(rd1("Correo").ToString, 29, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Correo").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If
        End If
        rd1.Close()

        Dim ACUENTA As Double = 0
        Dim RESTA As Double = 0

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                ACUENTA = rd1("ACuenta").ToString
                RESTA = rd1("Resta").ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 11
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
        e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
            Dim total As Double = FormatNumber(canti * precio, 2)
            Dim caducidad As String = grdcaptura.Rows(miku).Cells(7).Value.ToString
            Dim lote As String = grdcaptura.Rows(miku).Cells(8).Value.ToString

            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
            Y += 12.5
            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 21
            If lote <> "" Then
                Y -= 4
                e.Graphics.DrawString("Caducidad: " & caducidad, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
                e.Graphics.DrawString("Lote: " & lote, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y)
                Y += 4
            End If
        Next
        Y -= 3
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & txtprods.Text, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(txtsub1.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
        Y += 13.5

        If CDbl(txtdesc1.Text) > 0 Then
            e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtdesc1.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
            e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtsub2.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
        End If
        If cbofactura.Text <> "" And CDbl(txtiva.Text) > 0 Then
            e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtiva.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
        End If
        If CDbl(txtdesc2.Text) > 0 Then
            e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtTotalC.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
            e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtdesc2.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
        End If
        If cbofactura.Text <> "" And CDbl(txtieps.Text) > 0 Then
            e.Graphics.DrawString("IIEPS:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtieps.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
        End If
        Y += 3
        e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(txtapagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
        Y += 18
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim MyAcuenta As Double = CDbl(txtanticipo.Text) + CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

        If MyAcuenta > 0 Then
            If CDbl(txtanticipo.Text) > 0 Then
                e.Graphics.DrawString("Anticipo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtanticipo.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(txtanticipo.Text) > 0 Then
                e.Graphics.DrawString("Pagos:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtpagos.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
        End If

        If tipo_impre = "NORMAL" Then
            If MyAcuenta > 0 Then
                e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(MyAcuenta, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
        End If
        If tipo_impre = "COPIA" Then
            If ACUENTA > 0 Then
                e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(ACUENTA, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(RESTA) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(RESTA, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
        End If
        e.HasMorePages = False
        Exit Sub
kakita:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub Label11_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Label11.DoubleClick
        PrintDocument1.Print()
    End Sub

    Private Sub pTicket58_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pTicket58.PrintPage
        'Fuentes predefinidas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
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

        On Error GoTo kaota
        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 45, 0, 90, 90)
                Y += 100
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 8, 0, 170, 100)
                Y += 110
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
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
                    Y += 10.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
                    Y += 10.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 12
                End If
                Y += 6
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos del pedido
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 10
        If tipo_impre = "NORMAL" Then
            e.Graphics.DrawString("C O M P R A", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 94, Y, sc)
        End If
        If tipo_impre = "COPIA" Then
            e.Graphics.DrawString("C O P I A - C O M P R A", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 94, Y, sc)
        End If
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("N° Remisión: " & cboremision.Text, fuente_datos, Brushes.Black, 1, Y)
        Y += 11
        If cbofactura.Text <> "" Then
            e.Graphics.DrawString("N° Factura: " & cbofactura.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 11
        End If
        If cbopedido.Text <> "" Then
            e.Graphics.DrawString("N° Pedido: " & cbopedido.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 11
        End If
        Y += 4
        e.Graphics.DrawString("Fecha: " & Date.Now, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("Usuario: " & alias_compras, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 19

        '[2]. Datos del proveedor
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 9.5
                e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 94, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 11

                If rd1("Compania").ToString <> "" Then
                    e.Graphics.DrawString("Nombre: " & Mid(rd1("Compania").ToString, 1, 23), fuente_prods, Brushes.Black, 1, Y)
                    Y += 10
                    If Mid(rd1("Compania").ToString, 24, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Compania").ToString, 24, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 10
                    End If
                End If
                If rd1("RFC").ToString <> "" Then
                    e.Graphics.DrawString("RFC: " & rd1("RFC").ToString, fuente_prods, Brushes.Black, 1, Y)
                    Y += 10
                End If
                If rd1("Correo").ToString <> "" Then
                    e.Graphics.DrawString("Correo: " & Mid(rd1("Correo").ToString, 1, 23), fuente_prods, Brushes.Black, 1, Y)
                    Y += 10
                    If Mid(rd1("Correo").ToString, 24, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Correo").ToString, 24, 100), fuente_prods, Brushes.Black, 1, Y)
                    End If
                End If
                Y += 12
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 9.5
            End If
        End If
        rd1.Close()

        Dim ACUENTA As Double = 0
        Dim RESTA As Double = 0

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                ACUENTA = rd1("ACuenta").ToString
                RESTA = rd1("Resta").ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
        Y += 10
        e.Graphics.DrawString("Cant.", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("P.Unit", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 115, Y, sf)
        e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 187, Y, sf)
        Y += 5.5
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 16

        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
            Dim total As Double = FormatNumber(canti * precio, 2)
            Dim caducidad As String = grdcaptura.Rows(miku).Cells(7).Value.ToString()
            Dim lote As String = grdcaptura.Rows(miku).Cells(8).Value.ToString()

            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 24), fuente_prods, Brushes.Black, 42, Y)
            Y += 10
            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 28, Y, sf)
            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 31, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 115, Y, sf)
            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 188, Y, sf)
            Y += 20
            If lote <> "" Then
                Y += 2
                e.Graphics.DrawString("Cad.: " & FormatDateTime(caducidad, DateFormat.ShortDate), New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 1, Y)
                e.Graphics.DrawString("Lot.: " & lote, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 187, Y, sf)
                Y += 2
            End If
        Next

        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & txtprods.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 17

        e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(txtsub1.Text, 2), fuente_prods, Brushes.Beige, 187, Y, sf)
        Y += 12
        If CDbl(txtdesc1.Text) > 0 Then
            e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtdesc1.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
            Y += 12
            e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtsub2.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
            Y += 12
        End If
        If cbofactura.Text <> "" And CDbl(txtiva.Text) > 0 Then
            e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtiva.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
            Y += 12
        End If
        If CDbl(txtdesc2.Text) > 0 Then
            e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtTotalC.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
            Y += 12
            e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtdesc2.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
            Y += 12
        End If
        If cbofactura.Text <> "" And CDbl(txtieps.Text) > 0 Then
            e.Graphics.DrawString("IIEPS:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtieps.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
            Y += 12
        End If
        Y += 3
        e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(txtapagar.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim MyAcuenta As Double = CDbl(txtanticipo.Text) + CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

        If MyAcuenta > 0 Then
            If CDbl(txtanticipo.Text) > 0 Then
                e.Graphics.DrawString("Anticipo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtanticipo.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
                Y += 12
            End If
            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
                Y += 12
            End If
            If CDbl(txtanticipo.Text) > 0 Then
                e.Graphics.DrawString("Pagos:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtpagos.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
                Y += 12
            End If
            Y += 4
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
        End If

        If tipo_impre = "NORMAL" Then
            If MyAcuenta > 0 Then
                e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(MyAcuenta, 2), fuente_prods, Brushes.Black, 187, Y, sf)
                Y += 12
            End If
            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
                Y += 12
            End If
        End If
        If tipo_impre = "COPIA" Then
            If ACUENTA > 0 Then
                e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(ACUENTA, 2), fuente_prods, Brushes.Black, 187, Y, sf)
                Y += 12
            End If
            If CDbl(RESTA) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(RESTA, 2), fuente_prods, Brushes.Black, 187, Y, sf)
                Y += 12
            End If
        End If
        e.HasMorePages = False
        Exit Sub
kaota:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub pMediaCarta_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pMediaCarta.PrintPage
        'Fuentes predefinidas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 12, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")

        Dim ACUENTA As Double = 0
        Dim RESTA As Double = 0
        On Error GoTo caca

        If pagina = 0 Then
            '[1]. Datos del pedido
            If tipo_impre = "NORMAL" Then
                e.Graphics.DrawString("C O M P R A", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
                Y += 45
            End If
            If tipo_impre = "COPIA" Then
                e.Graphics.DrawString("C O P I A - C O M P R A", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
                Y += 45
            End If

            cnn1.Close() : cnn1.Open()

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 120, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 240, 110)
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'Razón social
                        If rd1("Cab0").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
                            Y += 14
                        End If
                        'RFC
                        If rd1("Cab1").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
                            Y += 14
                        End If
                        'Calle  N°.
                        If rd1("Cab2").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Colonia
                        If rd1("Cab3").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Delegación / Municipio - Entidad
                        If rd1("Cab4").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Teléfono
                        If rd1("Cab5").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Correo
                        If rd1("Cab6").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        Y += 17
                    End If
                End If
                rd1.Close()
            Else
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'Razón social
                        If rd1("Cab0").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
                            Y += 14
                        End If
                        'RFC
                        If rd1("Cab1").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
                            Y += 14
                        End If
                        'Calle  N°.
                        If rd1("Cab2").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Colonia
                        If rd1("Cab3").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Delegación / Municipio - Entidad
                        If rd1("Cab4").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Teléfono
                        If rd1("Cab5").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Correo
                        If rd1("Cab6").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        Y += 17
                    End If
                End If
                rd1.Close()
            End If

            Dim corta As Double = 0
            corta = 54
            '[2]. Datos del proveedor
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Y = 92
                    If rd1("Compania").ToString <> "" Then
                        e.Graphics.DrawString(rd1("Compania").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 537, Y)
                        Y += 13.5
                    Else
                        corta -= 13.5
                    End If
                    If rd1("RFC").ToString <> "" Then
                        e.Graphics.DrawString(rd1("RFC").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 537, Y)
                        Y += 13.5
                    Else
                        corta -= 13.5
                    End If
                    If rd1("Correo").ToString <> "" Then
                        e.Graphics.DrawString(rd1("Correo").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 537, Y)
                        Y += 13.5
                    Else
                        corta -= 13.5
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cbopedido.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    ACUENTA = rd1("ACuenta").ToString
                    RESTA = rd1("Resta").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            e.Graphics.DrawRectangle(pen, 535, 87, 285, CInt(corta))

            e.Graphics.DrawString("N. Remisión: " & cboremision.Text, New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 820, 44, sf)
            If cbofactura.Text <> "" Then
                e.Graphics.DrawString("N. Factura: " & cbofactura.Text, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 820, 68, sf)
            End If
            'Pedido
        End If

        If Contador = grdcaptura.Rows.Count Then
            Y += 20
        Else
            If pagina = 0 Then
                e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, 160)
                e.Graphics.DrawString("Unidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 430, 160, sf)
                e.Graphics.DrawString("Cantidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 550, 160, sf)
                e.Graphics.DrawString("Precio U", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, 160, sf)
                e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, 160, sf)
                Y = 180
            Else
                e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, 10)
                e.Graphics.DrawString("Unidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 430, 10, sf)
                e.Graphics.DrawString("Cantidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 550, 10, sf)
                e.Graphics.DrawString("Precio U", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, 10, sf)
                e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, 10, sf)
                Y = 30
            End If
            e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
            Y += 9

            Do While printLine < grdcaptura.Rows.Count
                If Y + 18 > 475 Then
                    e.HasMorePages = True
                    Exit Do
                End If
                Dim codigo As String = grdcaptura.Rows(printLine).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(printLine).Cells(1).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(printLine).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(printLine).Cells(4).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(printLine).Cells(2).Value.ToString
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(nombre, fuente_prods, Brushes.Black, 60, Y)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 405, Y, sc)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 545, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 19

                printLine += 1
                Contador += 1
            Loop
            Y += 5
            e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
            Y += 9
        End If
        pagina += 1

        Dim pasa1 As Integer = 0

        If Contador = grdcaptura.Rows.Count Then
            Dim campos As Integer = 0
            If CDbl(txtsub1.Text) > 0 Then campos += 1
            If CDbl(txtdesc1.Text) > 0 Then campos += 1
            If CDbl(txtsub1.Text) <> CDbl(txtsub2.Text) Then campos += 1
            If CDbl(txtiva.Text) > 0 Then campos += 1
            If CDbl(txtdesc2.Text) > 0 Then campos += 1
            If CDbl(txtieps.Text) > 0 Then campos += 1
            If CDbl(txtanticipo.Text) > 0 Then campos += 2
            If CDbl(txtpagos.Text) > 0 Then campos += 2
            If CDbl(txtefectivo.Text) > 0 Then campos += 2

            If campos <= 3 Then
                If Y + 13 > 475 Then
                    e.HasMorePages = True
                    e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 510, sf)
                    e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 510, sc)
                    Exit Sub
                End If
                e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtsub1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5
                If CDbl(txtdesc1.Text) > 0 Then
                    e.Graphics.DrawString("Descuento: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtsub2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtiva.Text) > 0 Then
                    e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtiva.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If CDbl(txtdesc2.Text) > 0 Then
                    e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtTotalC.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtieps.Text) > 0 Then
                    e.Graphics.DrawString("IIEPS:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtieps.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                Y += 3
                e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtapagar.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5

                Dim MyAcuenta As Double = CDbl(txtanticipo.Text) + CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

                If MyAcuenta > 0 Then
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Anticipo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtanticipo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtefectivo.Text) > 0 Then
                        e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Pagos:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtpagos.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If

                If tipo_impre = "NORMAL" Then
                    Y += 3
                    If MyAcuenta > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(MyAcuenta, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtresta.Text) > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
                If tipo_impre = "COPIA" Then
                    Y += 3
                    If ACUENTA > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(ACUENTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If RESTA > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(RESTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
            Else
                If Y + 13 > 430 Then
                    e.HasMorePages = True
                    e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 510, sf)
                    e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 510, sc)
                    Exit Sub
                End If
                e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtsub1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5
                If CDbl(txtdesc1.Text) > 0 Then
                    e.Graphics.DrawString("Descuento: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtsub2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtiva.Text) > 0 Then
                    e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtiva.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If CDbl(txtdesc2.Text) > 0 Then
                    e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtTotalC.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtieps.Text) > 0 Then
                    e.Graphics.DrawString("IIEPS:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtieps.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                Y += 3
                e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtapagar.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5

                Dim MyAcuenta As Double = CDbl(txtanticipo.Text) + CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

                If MyAcuenta > 0 Then
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Anticipo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtanticipo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtefectivo.Text) > 0 Then
                        e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Pagos:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtpagos.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If

                If tipo_impre = "NORMAL" Then
                    Y += 3
                    If MyAcuenta > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(MyAcuenta, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtresta.Text) > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
                If tipo_impre = "COPIA" Then
                    Y += 3
                    If ACUENTA > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(ACUENTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If RESTA > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(RESTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
            End If
        End If

        e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 510, sf)
        e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 510, sc)
        Exit Sub
caca:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub pCarta_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pCarta.PrintPage
        'Fuentes predefinidas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 12, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")

        Dim ACUENTA As Double = 0
        Dim RESTA As Double = 0

        On Error GoTo kaka

        If pagina = 0 Then
            '[1]. Datos del pedido
            If tipo_impre = "NORMAL" Then
                e.Graphics.DrawString("C O M P R A", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
                Y += 45
            End If
            If tipo_impre = "COPIA" Then
                e.Graphics.DrawString("C O P I A - C O M P R A", New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 410, Y, sc)
                Y += 45
            End If

            cnn1.Close() : cnn1.Open()

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 120, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, CInt(Y), 240, 110)
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'Razón social
                        If rd1("Cab0").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
                            Y += 14
                        End If
                        'RFC
                        If rd1("Cab1").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 245, Y)
                            Y += 14
                        End If
                        'Calle  N°.
                        If rd1("Cab2").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Colonia
                        If rd1("Cab3").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Delegación / Municipio - Entidad
                        If rd1("Cab4").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Teléfono
                        If rd1("Cab5").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        'Correo
                        If rd1("Cab6").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 245, Y)
                            Y += 13.5
                        End If
                        Y += 17
                    End If
                End If
                rd1.Close()
            Else
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'Razón social
                        If rd1("Cab0").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
                            Y += 14
                        End If
                        'RFC
                        If rd1("Cab1").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
                            Y += 14
                        End If
                        'Calle  N°.
                        If rd1("Cab2").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Colonia
                        If rd1("Cab3").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Delegación / Municipio - Entidad
                        If rd1("Cab4").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Teléfono
                        If rd1("Cab5").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        'Correo
                        If rd1("Cab6").ToString() <> "" Then
                            e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 11, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 13.5
                        End If
                        Y += 17
                    End If
                End If
                rd1.Close()
            End If

            Dim corta As Double = 0
            corta = 54
            '[2]. Datos del proveedor
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Y = 92
                    If rd1("Compania").ToString <> "" Then
                        e.Graphics.DrawString(rd1("Compania").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 537, Y)
                        Y += 13.5
                    Else
                        corta -= 13.5
                    End If
                    If rd1("RFC").ToString <> "" Then
                        e.Graphics.DrawString(rd1("RFC").ToString, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 537, Y)
                        Y += 13.5
                    Else
                        corta -= 13.5
                    End If
                    If rd1("Correo").ToString <> "" Then
                        e.Graphics.DrawString(rd1("Correo").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 537, Y)
                        Y += 13.5
                    Else
                        corta -= 13.5
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cbopedido.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    ACUENTA = rd1("ACuenta").ToString
                    RESTA = rd1("Resta").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            e.Graphics.DrawRectangle(pen, 535, 87, 285, CInt(corta))

            e.Graphics.DrawString("N. Remisión: " & cboremision.Text, New Drawing.Font(tipografia, 13, FontStyle.Bold), Brushes.Black, 820, 44, sf)
            If cbofactura.Text <> "" Then
                e.Graphics.DrawString("N. Factura: " & cbofactura.Text, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 820, 68, sf)
            End If
            'Pedido

        End If

        If Contador = grdcaptura.Rows.Count Then
            Y += 20
        Else
            If pagina = 0 Then
                e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, 160)
                e.Graphics.DrawString("Unidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 430, 160, sf)
                e.Graphics.DrawString("Cantidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 550, 160, sf)
                e.Graphics.DrawString("Precio U", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, 160, sf)
                e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, 160, sf)
                Y = 180
            Else
                e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, 10)
                e.Graphics.DrawString("Unidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 430, 10, sf)
                e.Graphics.DrawString("Cantidad", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 550, 10, sf)
                e.Graphics.DrawString("Precio U", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, 10, sf)
                e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, 10, sf)
                Y = 30
            End If
            e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
            Y += 9

            Do While printLine < grdcaptura.Rows.Count
                If Y + 18 > 1000 Then
                    e.HasMorePages = True
                    Exit Do
                End If
                Dim codigo As String = grdcaptura.Rows(printLine).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(printLine).Cells(1).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(printLine).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(printLine).Cells(4).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(printLine).Cells(2).Value.ToString
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(nombre, fuente_prods, Brushes.Black, 60, Y)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 405, Y, sc)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 545, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 19

                printLine += 1
                Contador += 1
            Loop
            Y += 5
            e.Graphics.DrawLine(pen, New Point(1, CInt(Y)), New Point(820, CInt(Y)))
            Y += 9
        End If
        pagina += 1

        If Contador = grdcaptura.Rows.Count Then
            Dim campos As Integer = 0
            If CDbl(txtsub1.Text) > 0 Then campos += 1
            If CDbl(txtdesc1.Text) > 0 Then campos += 1
            If CDbl(txtsub1.Text) <> CDbl(txtsub2.Text) Then campos += 1
            If CDbl(txtiva.Text) > 0 Then campos += 1
            If CDbl(txtdesc2.Text) > 0 Then campos += 1
            If CDbl(txtieps.Text) > 0 Then campos += 1
            If CDbl(txtanticipo.Text) > 0 Then campos += 2
            If CDbl(txtpagos.Text) > 0 Then campos += 2
            If CDbl(txtefectivo.Text) > 0 Then campos += 2

            If campos <= 3 Then
                If Y + 13 > 1000 Then
                    e.HasMorePages = True
                    e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 1050, sf)
                    e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 1050, sc)
                    Exit Sub
                End If
                e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtsub1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5
                If CDbl(txtdesc1.Text) > 0 Then
                    e.Graphics.DrawString("Descuento: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtsub2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtiva.Text) > 0 Then
                    e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtiva.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If CDbl(txtdesc2.Text) > 0 Then
                    e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtTotalC.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtieps.Text) > 0 Then
                    e.Graphics.DrawString("IIEPS:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtieps.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                Y += 3
                e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtapagar.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5

                Dim MyAcuenta As Double = CDbl(txtanticipo.Text) + CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

                If MyAcuenta > 0 Then
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Anticipo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtanticipo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtefectivo.Text) > 0 Then
                        e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Pagos:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtpagos.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If

                If tipo_impre = "NORMAL" Then
                    Y += 3
                    If MyAcuenta > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(MyAcuenta, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtresta.Text) > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
                If tipo_impre = "COPIA" Then
                    Y += 3
                    If ACUENTA > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(ACUENTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If RESTA > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(RESTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
            Else
                If Y + 13 > 950 Then
                    e.HasMorePages = True
                    e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 1050, sf)
                    e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 1050, sc)
                    Exit Sub
                End If
                e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtsub1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5
                If CDbl(txtdesc1.Text) > 0 Then
                    e.Graphics.DrawString("Descuento: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc1.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Subtotal: ", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtsub2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtiva.Text) > 0 Then
                    e.Graphics.DrawString("IVA:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtiva.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If CDbl(txtdesc2.Text) > 0 Then
                    e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtTotalC.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                    e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtdesc2.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                If cbofactura.Text <> "" And CDbl(txtieps.Text) > 0 Then
                    e.Graphics.DrawString("IIEPS:", fuente_prods, Brushes.Black, 550, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtieps.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                    Y += 12.5
                End If
                Y += 3
                e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 550, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtapagar.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                Y += 12.5

                Dim MyAcuenta As Double = CDbl(txtanticipo.Text) + CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

                If MyAcuenta > 0 Then
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Anticipo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtanticipo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtefectivo.Text) > 0 Then
                        e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtanticipo.Text) > 0 Then
                        e.Graphics.DrawString("Pagos:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtpagos.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If

                If tipo_impre = "NORMAL" Then
                    Y += 3
                    If MyAcuenta > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(MyAcuenta, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If CDbl(txtresta.Text) > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
                If tipo_impre = "COPIA" Then
                    Y += 3
                    If ACUENTA > 0 Then
                        e.Graphics.DrawString("A cuenta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(ACUENTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                    If RESTA > 0 Then
                        e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 550, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(RESTA, 2), fuente_prods, Brushes.Black, 820, Y, sf)
                        Y += 12.5
                    End If
                End If
            End If
        End If

        e.Graphics.DrawString("Página " & pagina, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 820, 1050, sf)
        e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 410, 1050, sc)
        Exit Sub
kaka:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub btnimportar_Click(sender As System.Object, e As System.EventArgs) Handles btnimportarxls.Click

        If cboproveedor.Text = "" Then MsgBox("Selcciona un proveedor para realizar la compra.", vbInformation + vbOKOnly, "Delsscom® Restaurant") : cboproveedor.Focus().Equals(True) : Exit Sub
        If cboremision.Text = "" Then MsgBox("Escribe el número de remisión de la compra.", vbInformation + vbOKOnly, "Delsscom® Restaurant") : cboremision.Focus().Equals(True) : Exit Sub
        Excel_Grid(DataGridView1)

    End Sub

    Private Sub Excel_Grid(ByVal tabla As DataGridView)

        Dim con As OleDb.OleDbConnection
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim file_dialog As New OpenFileDialog
        Dim ruta As String = ""
        Dim sheet As String = "Hoja1"

        'Instrucción para buscar y abrir el archivo xlsx
        With file_dialog
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx"
            .Title = "Selecciona el archivo a importar"
            .Multiselect = False
            .InitialDirectory = My.Application.Info.DirectoryPath
            .ShowDialog()
        End With

        If file_dialog.FileName.ToString <> "" Then
            ruta = file_dialog.FileName.ToString

            con = New OleDbConnection(
                   "Provider=Microsoft.ACE.OLEDB.12.0;" &
                   "data source=" & ruta & "; " &
                   "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                da = New OleDbDataAdapter("select * from [" & sheet & "$]", con)

                con.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                tabla.DataSource = ds
                tabla.DataMember = "MyData"
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                con.Close()
            End Try
            My.Application.DoEvents()
            'Busqueda de datos dentro del Excel

            If grdcaptura.Rows.Count > 0 Then
            Else

                My.Application.DoEvents()
                Grid_SQL()
            End If
        End If

    End Sub

    Private Sub Grid_SQL()

        Dim codigo As String = ""
        Dim barras As String = ""
        Dim descripcion As String = ""
        Dim cantidad As Double = 0
        Dim existencia As Double = 0
        Dim unidad As String = ""
        Dim IVA As Double = 0
        Dim precio_compra As Double = 0
        Dim total_compra As Double = 0
        Dim lote As String = ""
        Dim caducidad As String = ""

        Dim subtotal, iva_compra, total_final As Double

        If (grdcaptura.Rows.Count - 1) = 0 Then
            MsgBox("No se pudo completar la carga del archivo de excel.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
            Exit Sub
        End If

        barraExcel.Visible = True
        barraExcel.Value = 0
        barraExcel.Maximum = DataGridView1.Rows.Count

        cnn1.Close() : cnn1.Open()
        For lala As Integer = 0 To DataGridView1.Rows.Count - 1

            codigo = Convert.ToString(DataGridView1.Rows(lala).Cells(0).Value)
            barras = Convert.ToString(DataGridView1.Rows(lala).Cells(1).Value)
            If codigo = "" Then Exit For
            descripcion = Convert.ToString(DataGridView1.Rows(lala).Cells(2).Value)
            cantidad = Convert.ToDouble(DataGridView1.Rows(lala).Cells(3).Value)
            precio_compra = Convert.ToDouble(IIf(IsDBNull(DataGridView1.Rows(lala).Cells(4).Value), 0, DataGridView1.Rows(lala).Cells(4).Value))

            total_compra = precio_compra * cantidad

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & codigo & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    unidad = rd1("UCompra").ToString
                    IVA = rd1("IVA").ToString
                    existencia = rd1("Existencia").ToString
                End If
            Else
                MsgBox("No se encuentra el producto con código de barras: " & barras, vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close()
                barraExcel.Value += 1
                My.Application.DoEvents()
                Continue For
            End If
            rd1.Close()

            If cbofactura.Text <> "" Then
                iva_compra = iva_compra + ((total_compra * (1 + IVA)) - total_compra)
            Else
                iva_compra = 0
            End If

            subtotal = subtotal + total_compra
            total_final = subtotal + iva_compra

            grdcaptura.Rows.Add(
                codigo,
                descripcion,
                unidad,
                FormatNumber(cantidad, 2),
                FormatNumber(precio_compra, 2),
                FormatNumber(total_compra, 2),
                existencia,
                caducidad,
                lote,
                0,
                ""
                )
            barraExcel.Value += 1
            My.Application.DoEvents()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into auxcompras(Proveedor,Rem,Fac,Ped,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Caducidad,Lote,CP) values('" & cboproveedor.Text & "','" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "','" & codigo & "','" & descripcion & "','" & unidad & "','" & cantidad & "','" & precio_compra & "','" & total_compra & "','" & IIf(caducidad = "", Date.Now, caducidad) & "','" & lote & "','0')"
            cmd1.ExecuteNonQuery()
        Next
        cnn1.Close()
        txtsub1.Text = FormatNumber(subtotal, 2)
        txtiva.Text = FormatNumber(total_final - subtotal)
        txtTotalC.Text = FormatNumber(total_final, 2)
        barraExcel.Value = 0
        barraExcel.Visible = False

    End Sub

    Private Sub btncopia_Click(sender As System.Object, e As System.EventArgs) Handles btncopia.Click
        'Pregunta sí se quiere imprimir la compra
        If MsgBox("¿Deseas imprimir una copia de la compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim ImprimeEn As String = ""
            Dim Impresora As String = ""
            Dim tPapel As String = ""
            Dim tMilimetros As String = ""
            tipo_impre = "COPIA"
            printLine = 0
            Contador = 0
            pagina = 0

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='TPapelCP'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tPapel = rd1(0).ToString
                    If tPapel = "CARTA" Or tPapel = "MEDIA CARTA" Then
                        ImprimeEn = "ImpreC"
                    ElseIf tPapel = "TICKET" Then
                        ImprimeEn = "ImpreT"
                    Else
                        ImprimeEn = ""
                    End If
                End If
            Else
                MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de compras.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close()
                cnn1.Close()
                btnnuevo.PerformClick()
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tMilimetros = rd1(0).ToString
                End If
            End If
            rd1.Close()

            If ImprimeEn <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='" & ImprimeEn & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Impresora = rd1(0).ToString
                    End If
                End If
                rd1.Close()
            Else
                MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close()
                btnnuevo.PerformClick()
                Exit Sub
            End If
            cnn1.Close()

            If tPapel = "TICKET" Then
                If tMilimetros = "80" Then
                    pTicket80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pTicket80.Print()
                End If
                If tMilimetros = "58" Then
                    pTicket58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pTicket58.Print()
                End If
            End If
            If tPapel = "MEDIA CARTA" Then
                pMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                pMediaCarta.Print()
            End If
            If tPapel = "CARTA" Then
                pCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                pCarta.Print()
            End If
            If tPapel = "PDF - CARTA" Then
                'Genera PDF y lo guarda en la ruta
                If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSCN1\COMPRAS\" & cboproveedor.Text & "\Compra_" & cboremision.Text & ".pdf") Then
                    File.Open(My.Application.Info.DirectoryPath & "\ARCHIVOSCN1\COMPRAS\" & cboproveedor.Text & "\Compra_" & cboremision.Text & ".pdf", FileMode.Open)
                End If
            End If
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fuente As New Drawing.Font("Arial", 14, FontStyle.Regular)
        Dim y As Double = 0

        For t As Integer = 0 To 60
            e.Graphics.DrawString("JIJI", fuente, Brushes.Black, 1, y)
            y += 30
        Next
        e.Graphics.DrawString("Termina documento", fuente, Brushes.Black, 1, y)
    End Sub

    Private Sub frmCompras_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboproveedor.Focus().Equals(True)
    End Sub

    Private Sub btncancela_Click(sender As System.Object, e As System.EventArgs) Handles btncancela.Click
        Try
            If cboproveedor.Text = "" Then MsgBox("Necesitas seleccionar un proveedor para continuar con el proceso.", vbInformation + vbOKOnly, "Delsscom Contol Negocios Pro") : cboproveedor.Focus().Equals(True) : Exit Sub
            If cboremision.Text = "" Then MsgBox("Selecciona un número de remisión para continuar con el proceso.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboremision.Focus().Equals(True) : Exit Sub
            If cboremision.Text = "" And cbofactura.Text = "" Then MsgBox("Necesitas seleccionar al menos el número de remisión para continuar con el proceso.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboremision.Focus().Equals(True) : Exit Sub
            If grdcaptura.Rows.Count = 0 Then MsgBox("Proceso erróneo, inténtalo de nuevo más tarde." & vbNewLine & "Sí el problema persiste comunícate con tu proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : btnnuevo.PerformClick() : Exit Sub
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Status").ToString() = "CANCELADA" Then
                        MsgBox("Esta compra ya fue cancelada anteriormente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close() : cnn1.Close() : Exit Sub
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()

            Dim id_compra As Double = 0
            Dim acuenta As Double = 0
            Dim resta As Double = 0
            Dim status As String = ""
            Dim saldo As Double = 0

            Dim id_prov As Double = 0

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_compra = rd1("Id").ToString()
                        acuenta = rd1("ACuenta").ToString()
                        resta = rd1("Resta").ToString()
                        status = rd1("Status").ToString()
                    End If
                End If
                rd1.Close()

                If status = "CANCELADA" Then MsgBox("Esta compra ya fue cancelada anteriormente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cnn1.Close() : Exit Sub

                Dim peps As Boolean = True

                For rm As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(rm).Cells(0).Value.ToString()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Costeo where Referencia='" & cboremision.Text & "' and Concepto='COMPRA' and Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Dim entrada As Double = rd1("Entrada").ToString()
                            Dim saldo_c As Double = rd1("Saldo").ToString()

                            If saldo_c < entrada Then
                                peps = False
                            End If
                        End If
                    End If
                    rd1.Close()
                Next

                If peps = False Then MsgBox("No puedes cancelar esta compra ya que uno o varios productos de la misma ya tuvieron ventas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cnn1.Close() : Exit Sub

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

            If MsgBox("¿Deseas cancelar esta compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                If acuenta > 0 Then
                    Panel1.Visible = True
                    Exit Sub
                ElseIf acuenta <= 0 Then
                    Dim fecha_cancela As String = Format(Date.Now, "yyyy-MM-dd")

                    MsgBox("Al no abonar nada a la compra, no habrá movimientos de caja ni de saldos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    tipo_cancelacion = "CASO 1"

                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            id_prov = rd1("IdProv").ToString()
                            id_compra = rd1("Id").ToString()
                            acuenta = rd1("ACuenta").ToString()
                            resta = rd1("Resta").ToString()
                            status = rd1("Status").ToString()
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Compras set Status='CANCELADA', FechaCancela='" & fecha_cancela & "' where Id=" & id_compra
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & id_prov & " and NumRemision='" & cboremision.Text & "')"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            saldo = rd1(0).ToString()
                        End If
                    End If
                    rd1.Close()

                    saldo = saldo - resta

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & id_prov & ",'" & cboproveedor.Text & "','CANCELACION','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & resta & "," & saldo & ",'','','" & alias_compras & "')"
                    cmd1.ExecuteNonQuery()

                    For t As Integer = 0 To grdcaptura.Rows.Count - 1
                        Dim codigo As String = grdcaptura.Rows(t).Cells(0).Value.ToString()
                        Dim nombre As String = grdcaptura.Rows(t).Cells(1).Value.ToString()
                        Dim unidad As String = grdcaptura.Rows(t).Cells(2).Value.ToString()
                        Dim cantidad As Double = grdcaptura.Rows(t).Cells(3).Value.ToString()
                        Dim precio As Double = grdcaptura.Rows(t).Cells(4).Value.ToString()
                        Dim existencia As Double = 0

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                existencia = rd1("Existencia").ToString()
                            End If
                        End If
                        rd1.Close()

                        'Actualiza el cardex
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & nombre & "','Cancela compra'," & existencia & "," & cantidad & "," & (existencia - cantidad) & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & alias_compras & "','" & cboremision.Text & "','','','','','')"
                        cmd1.ExecuteNonQuery()

                        'Actualiza la tabla del PEPS
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Costeo set Saldo=0 where Referencia='" & cboremision.Text & "' and Concepto='COMPRA' and Codigo='" & Strings.Left(codigo, 6) & "'"
                        cmd1.ExecuteNonQuery()

                        'Actualiza la tabla de productos
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set Existencia=" & (existencia - cantidad) & " where Codigo='" & Strings.Left(codigo, 6) & "'"
                        cmd1.ExecuteNonQuery()
                    Next
                    cnn1.Close()

                    If MsgBox("¿Deseas imprimir un recibo de la cancelación?", vbInformation + vbYesNo, "Delsscom Control Negocios Pro") = vbYes Then
                        Dim ImprimeEn As String = ""
                        Dim Impresora As String = ""
                        Dim tPapel As String = ""
                        Dim tMilimetros As String = ""
                        printLine = 0
                        Contador = 0
                        pagina = 0

                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select NotasCred from Formatos where Facturas='TPapelCP'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                tPapel = rd1(0).ToString
                                If tPapel = "CARTA" Or tPapel = "MEDIA CARTA" Then
                                    ImprimeEn = "ImpreC"
                                ElseIf tPapel = "TICKET" Then
                                    ImprimeEn = "ImpreT"
                                Else
                                    ImprimeEn = ""
                                End If
                            End If
                        Else
                            MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de compras.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd1.Close()
                            cnn1.Close()
                            btnnuevo.PerformClick()
                            Exit Sub
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select NotasCred from Formatos where Facturas='TamImpre'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                tMilimetros = rd1(0).ToString
                            End If
                        End If
                        rd1.Close()

                        If ImprimeEn <> "" Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "select NotasCred from Formatos where Facturas='" & ImprimeEn & "'"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    Impresora = rd1(0).ToString
                                End If
                            End If
                            rd1.Close()
                        Else
                            MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            cnn1.Close()
                            btnnuevo.PerformClick()
                            Exit Sub
                        End If
                        cnn1.Close()

                        If tPapel = "TICKET" Then
                            If tMilimetros = "80" Then
                                pCancela80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                                pCancela80.Print()
                            End If
                            If tMilimetros = "58" Then
                                pCancela58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                                pCancela58.Print()
                            End If
                        End If
                        If tPapel = "MEDIA CARTA" Then
                            pCancelaMC.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            pCancelaMC.Print()
                        End If
                        If tPapel = "CARTA" Then
                            pCancelaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            pCancelaCarta.Print()
                        End If
                        If tPapel = "PDF - CARTA" Then
                            'Genera PDF y lo guarda en la ruta

                        End If
                    End If
                    MsgBox("Compra cancelada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnnuevo.PerformClick()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub btnactualiza_Click(sender As System.Object, e As System.EventArgs) Handles btnactualiza.Click

    End Sub

    Private Sub pCancela80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pCancela80.PrintPage
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
        Dim saldo_fav As Double = 0

        On Error GoTo caca

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
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
                Pie = rd1("Pie2").ToString
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

        '[1]. Datos de la compra
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("CANCELACIÓN", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString("DE COMPRA", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18


        e.Graphics.DrawString("N° Remisión: " & cboremision.Text, fuente_datos, Brushes.Black, 1, Y)
        Y += 13.5
        If cbofactura.Text <> "" Then
            e.Graphics.DrawString("N° Factura: " & cbofactura.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 13.5
        End If
        If cbopedido.Text <> "" Then
            e.Graphics.DrawString("N° Pedido: " & cbopedido.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 13.5
        End If
        Y += 4
        e.Graphics.DrawString("Fecha: " & Date.Now, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 13.5
        e.Graphics.DrawString("Usuario: " & alias_compras, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 17

        '[2]. Datos del proveedor
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                If rd1("Compania").ToString <> "" Then
                    e.Graphics.DrawString("Nombre: " & Mid(rd1("Compania").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(rd1("Compania").ToString, 29, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Compania").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                If rd1("RFC").ToString <> "" Then
                    e.Graphics.DrawString("RFC: " & rd1("RFC").ToString, fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                If rd1("Correo").ToString <> "" Then
                    e.Graphics.DrawString("Correo: " & Mid(rd1("Correo").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(rd1("Correo").ToString, 29, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Correo").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                If tipo_cancelacion = "CASO 2" Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & rd1("Id").ToString & ")"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            saldo_fav = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close() : cnn2.Close()
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If
        End If
        rd1.Close()

        Dim ACUENTA As Double = 0
        Dim RESTA As Double = 0
        Dim TOTALC As Double = 0

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                ACUENTA = rd1("ACuenta").ToString()
                RESTA = rd1("Resta").ToString()
                TOTALC = rd1("Pagar").ToString()
            End If
        End If
        rd1.Close()
        cnn1.Close()

        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 11
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
        e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
            Dim total As Double = FormatNumber(canti * precio, 2)
            Dim caducidad As String = grdcaptura.Rows(miku).Cells(7).Value.ToString
            Dim lote As String = grdcaptura.Rows(miku).Cells(8).Value.ToString

            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
            Y += 12.5
            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 21
            If lote <> "" Then
                Y -= 4
                e.Graphics.DrawString("Caducidad: " & caducidad, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
                e.Graphics.DrawString("Lote: " & lote, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y)
                Y += 4
            End If
        Next
        Y -= 3
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & txtprods.Text, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        If tipo_cancelacion = "CASO 1" Then
            Y += 3
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(TOTALC, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18
            e.Graphics.DrawString("---------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 22

            e.Graphics.DrawString("No genera movimientos", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("de caja ni de saldos", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 140, Y, sc)
        End If
        If tipo_cancelacion = "CASO 2" Then
            Y += 3
            e.Graphics.DrawString("Este movimiento genera un saldo", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("a favor con el proveedor", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 140, Y, sc)
            Y += 12
            If saldo_fav < 0 Then
                e.Graphics.DrawString("Saldo a favor: ", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(Math.Abs(saldo_fav), 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 18
                e.Graphics.DrawString("---------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 22
            End If
        End If
        If tipo_cancelacion = "CASO 3" Then

        End If
        e.HasMorePages = False
        Exit Sub
caca:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim id_compra As Double = 0
        Dim acuenta As Double = 0
        Dim resta As Double = 0
        Dim status As String = ""

        Dim id_prov As Double = 0

        On Error GoTo quepasowey
        If cnn1.State = 1 Then cnn1.Close()

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "' and Status<>'CANCELADA'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                id_compra = rd1("Id").ToString()
                id_prov = rd1("IdProv").ToString()
                acuenta = rd1("ACuenta").ToString()
                resta = rd1("Resta").ToString()
                status = rd1("Status").ToString()
            End If
        End If
        rd1.Close()

        Dim saldo As Double = 0
        Dim abono As Double = 0

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Abono from AbonoE where NumRemision='" & cboremision.Text & "' and Concepto='ABONO' and IdProv=" & id_prov & ""
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then
                abono = abono + CDbl(rd1(0).ToString())
            End If
        Loop
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & id_prov & ")"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                saldo = rd1(0).ToString
            End If
        End If
        rd1.Close()

        Dim mysaldo As Double = 0
        mysaldo = saldo - abono

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values('" & cboremision.Text & "','" & cbofactura.Text & "','" & cbopedido.Text & "'," & id_prov & ",'" & cboproveedor.Text & "','CANCELACION','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & abono & "," & mysaldo & ",'','','" & alias_compras & "')"
        cmd1.ExecuteNonQuery()

        Dim fecha_cancela As String = Format(Date.Now, "yyyy-MM-dd")

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "update Compras set Status='CANCELADA',FechaCancela='" & fecha_cancela & "' where Id=" & id_compra
        cmd1.ExecuteNonQuery()

        For t As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim codigo As String = grdcaptura.Rows(t).Cells(0).Value.ToString()
            Dim nombre As String = grdcaptura.Rows(t).Cells(1).Value.ToString()
            Dim unidad As String = grdcaptura.Rows(t).Cells(2).Value.ToString()
            Dim cantidad As Double = grdcaptura.Rows(t).Cells(3).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(t).Cells(4).Value.ToString()
            Dim existencia As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    existencia = rd1("Existencia").ToString()
                End If
            End If
            rd1.Close()

            'Actualiza el cardex
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & nombre & "','Cancela compra'," & existencia & "," & cantidad & "," & (existencia - cantidad) & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & alias_compras & "','" & cboremision.Text & "','','','','','')"
            cmd1.ExecuteNonQuery()

            'Actualiza la tabla del Costeo
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Costeo set Saldo=0 where Referencia='" & cboremision.Text & "' and Concepto='COMPRA' and Codigo='" & Strings.Left(codigo, 6) & "'"
            cmd1.ExecuteNonQuery()

            'Actualiza la tabla de productos
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Productos set Existencia=" & (existencia - cantidad) & " where Codigo='" & Strings.Left(codigo, 6) & "'"
            cmd1.ExecuteNonQuery()
        Next
        cnn1.Close()

        If MsgBox("¿Deseas imprimir un recibo de la cancelación?", vbInformation + vbYesNo, "Delsscom Control Negocios Pro") = vbYes Then
            Dim ImprimeEn As String = ""
            Dim Impresora As String = ""
            Dim tPapel As String = ""
            Dim tMilimetros As String = ""
            printLine = 0
            Contador = 0
            pagina = 0

            tipo_cancelacion = "CASO 2"

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='TPapelCP'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tPapel = rd1(0).ToString
                    If tPapel = "CARTA" Or tPapel = "MEDIA CARTA" Then
                        ImprimeEn = "ImpreC"
                    ElseIf tPapel = "TICKET" Then
                        ImprimeEn = "ImpreT"
                    Else
                        ImprimeEn = ""
                    End If
                End If
            Else
                MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de compras.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close()
                cnn1.Close()
                btnnuevo.PerformClick()
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tMilimetros = rd1(0).ToString
                End If
            End If
            rd1.Close()

            If ImprimeEn <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='" & ImprimeEn & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Impresora = rd1(0).ToString
                    End If
                End If
                rd1.Close()
            Else
                MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close()
                btnnuevo.PerformClick()
                Exit Sub
            End If
            cnn1.Close()

            If tPapel = "TICKET" Then
                If tMilimetros = "80" Then
                    pCancela80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pCancela80.Print()
                End If
                If tMilimetros = "58" Then
                    pCancela58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pCancela58.Print()
                End If
            End If
            If tPapel = "MEDIA CARTA" Then
                pCancelaMC.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                pCancelaMC.Print()
            End If
            If tPapel = "CARTA" Then
                pCancelaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                pCancelaCarta.Print()
            End If
            If tPapel = "PDF - CARTA" Then
                'Genera PDF y lo guarda en la ruta

            End If
        End If
        MsgBox("Compra cancelada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        btnnuevo.PerformClick()
        Exit Sub
quepasowey:
        MsgBox(Err.Description & " - " & Err.Number & vbNewLine & "No se pudo realizar la cancelación debido a un error inesperado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub cbotpago_DropDown(sender As Object, e As EventArgs) Handles cbotpago.DropDown
        cbotpago.Items.Clear()
        cbotpago.Items.Add("TARJETA")
        cbotpago.Items.Add("TRANSFERENCIA")
        cbotpago.Items.Add("DEPOSITO")
        cbotpago.Items.Add("OTRO")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub UnicoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnicoToolStripMenuItem.Click
        Dim index As Integer = grdcaptura.CurrentRow.Index

        If MsgBox("Asignar este producto como único lo va a dejar con existencia '1' y se eliminará del catálogo al momento de venderse. ¿Desea continuar?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            grdcaptura(10, index).Value = "1"
        End If
    End Sub

    Private Sub cbopedido_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbopedido.SelectedIndexChanged

    End Sub

    Private Sub dtpfecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpfecha.ValueChanged

    End Sub

    Private Sub Label14_Click(sender As System.Object, e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label31_Click(sender As System.Object, e As System.EventArgs) Handles Label31.Click

    End Sub

    Private Sub btnPagar_Click(sender As System.Object, e As System.EventArgs) Handles btnPagar.Click
        txtpc_apagar.Text = FormatNumber(txtapagar.Text, 2)
        txtpc_anticipo.Text = FormatNumber(txtanticipo.Text, 2)
        txtpc_resta.Text = FormatNumber(txtresta.Text, 2)

        panpago_compra.Visible = True
        txtpc_efectivo.Focus().Equals(True)
    End Sub

    Private Sub txtpc_efectivo_Click(sender As System.Object, e As System.EventArgs) Handles txtpc_efectivo.Click
        txtpc_efectivo.SelectionStart = 0
        txtpc_efectivo.SelectionLength = Len(txtpc_efectivo.Text)
    End Sub

    Private Sub txtpc_efectivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtpc_efectivo.GotFocus
        txtpc_efectivo.SelectionStart = 0
        txtpc_efectivo.SelectionLength = Len(txtpc_efectivo.Text)
    End Sub

    Private Sub txtpc_efectivo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpc_efectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtpc_efectivo.Text = "" Then txtpc_efectivo.Text = "0"
            txtpc_efectivo.Text = FormatNumber(txtpc_efectivo.Text, 2)
            txtpc_tarjeta.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpc_tarjeta_Click(sender As System.Object, e As System.EventArgs) Handles txtpc_tarjeta.Click
        txtpc_tarjeta.SelectionStart = 0
        txtpc_tarjeta.SelectionLength = Len(txtpc_tarjeta.Text)
    End Sub

    Private Sub txtpc_tarjeta_GotFocus(sender As Object, e As System.EventArgs) Handles txtpc_tarjeta.GotFocus
        txtpc_tarjeta.SelectionStart = 0
        txtpc_tarjeta.SelectionLength = Len(txtpc_tarjeta.Text)
    End Sub

    Private Sub txtpc_tarjeta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpc_tarjeta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtpc_tarjeta.Text = "" Then txtpc_tarjeta.Text = "0"
            txtpc_tarjeta.Text = FormatNumber(txtpc_tarjeta.Text, 2)
            txtpc_transfe.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpc_transfe_Click(sender As System.Object, e As System.EventArgs) Handles txtpc_transfe.Click
        txtpc_transfe.SelectionStart = 0
        txtpc_transfe.SelectionLength = Len(txtpc_transfe.Text)
    End Sub

    Private Sub txtpc_transfe_GotFocus(sender As Object, e As System.EventArgs) Handles txtpc_transfe.GotFocus
        txtpc_transfe.SelectionStart = 0
        txtpc_transfe.SelectionLength = Len(txtpc_transfe.Text)
    End Sub

    Private Sub txtpc_transfe_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpc_transfe.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtpc_transfe.Text = "" Then txtpc_transfe.Text = "0"
            txtpc_transfe.Text = FormatNumber(txtpc_transfe.Text, 2)
            txtpc_otro.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpc_otro_Click(sender As Object, e As System.EventArgs) Handles txtpc_otro.Click
        txtpc_otro.SelectionStart = 0
        txtpc_otro.SelectionLength = Len(txtpc_otro.Text)
    End Sub

    Private Sub txtpc_otro_GotFocus(sender As Object, e As System.EventArgs) Handles txtpc_otro.GotFocus
        txtpc_otro.SelectionStart = 0
        txtpc_otro.SelectionLength = Len(txtpc_otro.Text)
    End Sub

    Private Sub txtpc_otro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpc_otro.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtpc_otro.Text = "" Then txtpc_otro.Text = "0"
            txtpc_otro.Text = FormatNumber(txtpc_otro.Text, 2)
            btnpc_aceptar.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpc_efectivo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpc_efectivo.TextChanged
        If txtpc_apagar.Text = "" Then Exit Sub
        If txtpc_anticipo.Text = "" Then Exit Sub
        If txtpc_efectivo.Text = "" Then Exit Sub
        If txtpc_tarjeta.Text = "" Then Exit Sub
        If txtpc_transfe.Text = "" Then Exit Sub
        If txtpc_otro.Text = "" Then Exit Sub
        If txtpc_resta.Text = "" Then Exit Sub

        txtpc_resta.Text = CDbl(txtpc_apagar.Text) - (CDbl(txtpc_anticipo.Text) + CDbl(txtpc_efectivo.Text) + CDbl(txtpc_tarjeta.Text) + CDbl(txtpc_transfe.Text) + CDbl(txtpc_otro.Text))
        txtpc_resta.Text = FormatNumber(txtpc_resta.Text, 2)
    End Sub

    Private Sub txtpc_tarjeta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpc_tarjeta.TextChanged
        If txtpc_apagar.Text = "" Then Exit Sub
        If txtpc_anticipo.Text = "" Then Exit Sub
        If txtpc_efectivo.Text = "" Then Exit Sub
        If txtpc_tarjeta.Text = "" Then Exit Sub
        If txtpc_transfe.Text = "" Then Exit Sub
        If txtpc_otro.Text = "" Then Exit Sub
        If txtpc_resta.Text = "" Then Exit Sub

        txtpc_resta.Text = CDbl(txtpc_apagar.Text) - (CDbl(txtpc_anticipo.Text) + CDbl(txtpc_efectivo.Text) + CDbl(txtpc_tarjeta.Text) + CDbl(txtpc_transfe.Text) + CDbl(txtpc_otro.Text))
        txtpc_resta.Text = FormatNumber(txtpc_resta.Text, 2)
    End Sub

    Private Sub txtpc_transfe_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpc_transfe.TextChanged
        If txtpc_apagar.Text = "" Then Exit Sub
        If txtpc_anticipo.Text = "" Then Exit Sub
        If txtpc_efectivo.Text = "" Then Exit Sub
        If txtpc_tarjeta.Text = "" Then Exit Sub
        If txtpc_transfe.Text = "" Then Exit Sub
        If txtpc_otro.Text = "" Then Exit Sub
        If txtpc_resta.Text = "" Then Exit Sub

        txtpc_resta.Text = CDbl(txtpc_apagar.Text) - (CDbl(txtpc_anticipo.Text) + CDbl(txtpc_efectivo.Text) + CDbl(txtpc_tarjeta.Text) + CDbl(txtpc_transfe.Text) + CDbl(txtpc_otro.Text))
        txtpc_resta.Text = FormatNumber(txtpc_resta.Text, 2)
    End Sub

    Private Sub txtpc_otro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpc_otro.TextChanged
        If txtpc_apagar.Text = "" Then Exit Sub
        If txtpc_anticipo.Text = "" Then Exit Sub
        If txtpc_efectivo.Text = "" Then Exit Sub
        If txtpc_tarjeta.Text = "" Then Exit Sub
        If txtpc_transfe.Text = "" Then Exit Sub
        If txtpc_otro.Text = "" Then Exit Sub
        If txtpc_resta.Text = "" Then Exit Sub

        txtpc_resta.Text = CDbl(txtpc_apagar.Text) - (CDbl(txtpc_anticipo.Text) + CDbl(txtpc_efectivo.Text) + CDbl(txtpc_tarjeta.Text) + CDbl(txtpc_transfe.Text) + CDbl(txtpc_otro.Text))
        txtpc_resta.Text = FormatNumber(txtpc_resta.Text, 2)
    End Sub

    Private Sub btnpc_aceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnpc_aceptar.Click
        Pagos.pc_porpagar = txtpc_apagar.Text
        Pagos.pc_anticipo = txtpc_anticipo.Text
        Pagos.pc_efectivo = txtpc_efectivo.Text
        Pagos.pc_tarjeta = txtpc_tarjeta.Text
        Pagos.pc_transfe = txtpc_transfe.Text
        Pagos.pc_otros = txtpc_otro.Text
        Pagos.pc_resta = txtpc_resta.Text

        'Validaciones de datos
        '-- No puede abonarse más del total
        Dim suma_abono As Double = CDbl(txtpc_efectivo.Text) + CDbl(txtpc_tarjeta.Text) + CDbl(txtpc_anticipo.Text) + CDbl(txtpc_transfe.Text) + CDbl(txtpc_otro.Text)
        Dim tota_abono As Double = CDbl(txtpc_apagar.Text)
        If suma_abono > tota_abono Then
            MsgBox("No puedes realizar un abono mayor al total de la compra.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtpc_efectivo.Focus().Equals(True)
            Exit Sub
        End If

        If CDbl(txtpc_resta.Text) < 0 Then
            MsgBox("El restante total de la compra no puede ser negativo/menor a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtpc_efectivo.Focus().Equals(True)
            Exit Sub
        End If



        txtefectivo.Text = FormatNumber(txtpc_efectivo.Text, 2)
        txtpagos.Text = FormatNumber((CDbl(txtpc_tarjeta.Text) + CDbl(txtpc_transfe.Text) + CDbl(txtpc_otro.Text)), 2)
        txtresta.Text = FormatNumber(txtpc_resta.Text, 2)

        panpago_compra.Visible = False
        btnguardar.Focus().Equals(True)
    End Sub

    Private Sub btnimportarxml_Click(sender As Object, e As EventArgs) Handles btnimportarxml.Click


        ImportarXML()
    End Sub

    Public Sub ImportarXML()

        ' Especifica la ruta del archivo XML
        Dim rutaArchivoXML As String = "C:\ControlNegociosPro\Archivos de importación\Compras.xml"
        ' Crea una nueva instancia de XmlDocument
        Dim xmlDoc As New XmlDocument()
        ' Accede a los nodos y realiza la importación según tus necesidades
        Dim nodoslist As XmlNodeList
        Dim nodo As XmlNode

        Dim subtotal As Double = 0
        Dim total_final As Double = 0
        Dim iva_compra As Double = 0

        Try
            xmlDoc = New XmlDocument
            ' Carga el archivo XML
            xmlDoc.Load(rutaArchivoXML)
            nodoslist = xmlDoc.SelectNodes("/G/Imagen")

            For Each nodo In nodoslist
                ' Procesa cada nodo y realiza la importación
                Dim IdImagen = nodo.Attributes.GetNamedItem("id").Value
                Dim codigo = nodo.ChildNodes(0).InnerText
                Dim nombre = nodo.ChildNodes(1).InnerText
                Dim cantidad = nodo.ChildNodes(2).InnerText
                Dim precio = nodo.ChildNodes(3).InnerText

                Dim unidad As String = ""
                Dim existencia As Double = 0
                Dim caducidad As String = ""
                Dim lote As String = ""

                Dim total As Double = 0

                Dim iva As Double = 0

                ' Puedes realizar acciones adicionales con los valores obtenidos
                ' Por ejemplo, insertar en una base de datos, realizar cálculos, etc.

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT UCompra,Existencia,IVA FROM Productos WHERE Codigo='" & codigo & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        unidad = rd1(0).ToString
                        existencia = rd1(1).ToString
                        iva = rd1(2).ToString

                        total = CDbl(cantidad) * CDbl(precio)
                        iva_compra = iva_compra + ((total * (1 + iva)) - total)

                        grdcaptura.Rows.Add(codigo, nombre, unidad, cantidad, precio, total, existencia, caducidad, lote, 0, "")
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                subtotal = subtotal + total
                total_final = subtotal + iva_compra
            Next
            txtsub1.Text = FormatNumber(subtotal, 2)
            txtiva.Text = FormatNumber(total_final - subtotal)
            txtTotalC.Text = FormatNumber(total_final, 2)

            ' Mensaje de éxito
            MessageBox.Show("Importación completada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ' Manejo de errores
            MessageBox.Show("Error al importar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
