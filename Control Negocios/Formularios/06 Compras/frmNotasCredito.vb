Public Class frmNotasCredito
    Dim CantidadProd As Double = 0

    Private Sub TextBox12_Click(sender As Object, e As System.EventArgs) Handles TextBox12.Click
        If TextBox12.Text = "CONTRASEÑA" Then
            TextBox12.ForeColor = Color.Black
            TextBox12.PasswordChar = "*"
            TextBox12.Text = ""
        Else
            TextBox12.SelectionStart = 0
            TextBox12.SelectionLength = Len(TextBox12.Text)
        End If
    End Sub

    Private Sub TextBox12_GotFocus(sender As Object, e As System.EventArgs) Handles TextBox12.GotFocus
        If TextBox12.Text = "CONTRASEÑA" Then
            TextBox12.ForeColor = Color.Black
            TextBox12.PasswordChar = "*"
            TextBox12.Text = ""
        Else
            TextBox12.SelectionStart = 0
            TextBox12.SelectionLength = Len(TextBox12.Text)
        End If
    End Sub

    Private Sub TextBox12_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox12.LostFocus
        If TextBox12.Text = "" Then
            TextBox12.ForeColor = Color.Gray
            TextBox12.PasswordChar = ""
            TextBox12.Text = "CONTRASEÑA"
        End If
    End Sub

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        If cbofactura.Text = "" And cboproveedor.Text = "" Then Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras INNER JOIN ComprasDet ON Compras.Id=ComprasDet.Id_Compra where Compras.Proveedor='" & cboproveedor.Text & "'  and Compras.NumFactura='" & cbofactura.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
                    rd1("Nombre").ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            CantidadProd = 0
            If cboproveedor.Text = "" Or cbofactura.Text = "" Or cbonombre.Text = "" And grdcaptura.Rows.Count = 0 Then Exit Sub
            If cboproveedor.Text = "" Or cbofactura.Text = "" Or cbonombre.Text = "" And grdcaptura.Rows.Count > 0 Then Exit Sub

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Compras INNER JOIN ComprasDet ON Compras.Id=ComprasDet.Id_Compra where Compras.Proveedor='" & cboproveedor.Text & "' and Compras.NumFactura='" & cbofactura.Text & "' and Nombre='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtcodigo.Text = rd1("Codigo").ToString
                        txtunidad.Text = rd1("UCompra").ToString
                        CantidadProd = rd1("Cantidad").ToString
                        txtcantidad.Text = rd1("Cantidad").ToString
                        txtprecio.Text = FormatNumber(rd1("Precio").ToString, 2)
                        txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
                        txttotal.Text = FormatNumber(txttotal.Text, 2)
                        Call EXIST(txtcodigo.Text)
                    End If
                Else
                    Call CODB(cbonombre.Text)
                    Call EXIST(txtcodigo.Text)
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Public Sub EXIST(ByVal cod As String)
        On Error GoTo errs
        If cod = "" Then Exit Sub

        cnn2.Close() : cnn2.Open()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select Existencia from Productos where Codigo='" & cod & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                txtexistencia.Text = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString), 2)
                txtexis_f.Text = CDbl(txtexistencia.Text) - CDec(txtcantidad.Text)
                txtexis_f.Text = FormatNumber(txtexis_f.Text, 2)
            End If
        Else
            txtexistencia.Text = "0.00"
            txtexis_f.Text = FormatNumber(-1 * CDbl(txtcantidad.Text), 2)
        End If
        rd2.Close()
        cnn2.Close()
errs:
    End Sub

    Public Sub CODB(ByVal vemos As String)
        If vemos = "" Then Exit Sub
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Productos where CodBarra='" & vemos & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtcodigo.Text = rd2("Codigo").ToString
                    cbonombre.Text = rd2("Nombre").ToString
                    txtunidad.Text = rd2("UCompra").ToString
                    txtprecio.Text = FormatNumber(rd2("Precio").ToString, 2)
                End If
            Else
                MsgBox("El producto no existe.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd2.Close()
                cnn2.Close()
                Exit Sub
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Compras INNER JOIN ComprasDet ON Compras.Id=ComprasDet.Id_Compra where Compras.Proveedor='" & cboproveedor.Text & "' and Compras.NumFactura='" & cbofactura.Text & "' and Nombre='" & cbonombre.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtcodigo.Text = rd2("Codigo").ToString
                    txtunidad.Text = rd2("UCompra").ToString
                    CantidadProd = rd2("Cantidad").ToString
                    txtcantidad.Text = rd2("Cantidad").ToString
                    txtprecio.Text = FormatNumber(rd2("Precio").ToString, 2)
                    'Total de la compra

                End If
            Else
                cbonombre.Text = ""
                txtcodigo.Text = ""
                txtunidad.Text = ""
                txtprecio.Text = ""
                CantidadProd = 0
                txttotal.Text = ""
                cbonombre.Focus().Equals(True)
                rd2.Close()
                cnn2.Close()
                Exit Sub
            End If
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
        txtcantidad.Focus().Equals(True)
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
                    txtcodigo.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboremision_DropDown(sender As System.Object, e As System.EventArgs) Handles cboremision.DropDown
        cboremision.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct NumRemision from ComprasDet where Proveedor='" & cboproveedor.Text & "' and NumRemision<>''"
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

    Private Sub cboremision_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboremision.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cboremision_SelectedValueChanged(cboremision, New EventArgs())
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboremision_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboremision.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select max(NotaCred) from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cbonota_c.Text = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) + 1
                        End If
                    Else
                        cbonota_c.Text = "1"
                    End If
                    rd2.Close()

                    cbofactura.Text = rd1("NumFactura").ToString
                    txtsub1.Text = FormatNumber(rd1("Sub1").ToString, 2)
                    txtdesc1.Text = FormatNumber(rd1("Desc1").ToString, 2)
                    txtsub2.Text = FormatNumber(rd1("Sub2").ToString, 2)
                    txtiva.Text = FormatNumber(rd1("IVA").ToString, 2)
                    txttotal_c.Text = FormatNumber(rd1("Total").ToString, 2)
                    txtacuenta.Text = FormatNumber(rd1("ACuenta").ToString, 2)
                    txtresta.Text = FormatNumber(rd1("Resta").ToString, 2)
                    dtpfechac.Value = rd1("FechaC").ToString
                    cnn2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofactura_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofactura.DropDown
        cbofactura.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct NumFactura from ComprasDet where Proveedor='" & cboremision.Text & "' and NumRemision<>''"
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
            Call cbofactura_SelectedValueChanged(cbofactura, New EventArgs())
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofactura_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbofactura.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where NumFactura='" & cbofactura.Text & "' and Proveedor='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select max(NotaCred) from Compras where NumFactura='" & cbofactura.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cbonota_c.Text = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) + 1
                        End If
                    Else
                        cbonota_c.Text = "1"
                    End If
                    rd2.Close()

                    cboremision.Text = rd1("NumRemision").ToString
                    'Datos de la compra completa
                    txtsub1.Text = FormatNumber(rd1("Sub1").ToString, 2)
                    txtdesc1.Text = FormatNumber(rd1("Desc1").ToString, 2)
                    txtsub2.Text = FormatNumber(rd1("Sub2").ToString, 2)
                    txtiva.Text = FormatNumber(rd1("IVA").ToString, 2)
                    txttotal_c.Text = FormatNumber(rd1("Total").ToString, 2)
                    txtacuenta.Text = FormatNumber(rd1("ACuenta").ToString, 2)
                    txtresta.Text = FormatNumber(rd1("Resta").ToString, 2)
                    dtpfechac.Value = rd1("FechaC").ToString
                    cnn2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonota_c_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonota_c.DropDown
        cbonota_c.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct NotaCred from Compras where Proveedor='" & cboproveedor.Text & "' and NumFactura='" & cbofactura.Text & "' and NumRemision='" & cboremision.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonota_c.Items.Add(
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

    Private Sub cbonota_c_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonota_c.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonota_c_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonota_c.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where NotaCred='" & cbonota_c.Text & "' and Proveedor='" & cboproveedor.Text & "' and NumFactura='" & cbofactura.Text & "' and NumRemision='" & cboremision.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1.Read Then
                    txtsuma.Text = FormatNumber(rd1("Sub1").ToString, 2)
                    txtivanc.Text = FormatNumber(rd1("IVA").ToString, 2)
                    txttotalnc.Text = FormatNumber(CDbl(txtsuma.Text) + CDbl(txtivanc.Text), 2)
                    dtpfechac.Text = rd1("FechaNC").ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ComprasDet where NotaCred='" & cbonota_c.Text & "' and Proveedor='" & cboproveedor.Text & "' and NumFactura='" & cbofactura.Text & "' and NumRemision='" & cboremision.Text & "'"
            rd1 = cmd1.ExecuteReader

            cnn2.Close() : cnn2.Open()            
            Do While rd1.Read
                Dim codigo As String = rd1("Codigo").ToString
                Dim cantidad As Double = rd1("Cantidad").ToString
                Dim precio As Double = rd1("Precio").ToString
                Dim total As Double = rd1("Total").ToString
                Dim nombre As String = ""
                Dim unidad As String = ""
                Dim existe As Double = 0

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where Codigo='" & codigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        nombre = rd2("Nombre").ToString
                        unidad = rd2("UCompra").ToString
                        existe = rd2("Existencia").ToString
                    End If
                End If
                rd2.Close()

                grdcaptura.Rows.Add(
                    codigo,
                    nombre,
                    unidad,
                    cantidad,
                    FormatNumber(precio, 2),
                    FormatNumber(total, 2),
                    existe
                    )
            Loop
            rd1.Close()
            cnn2.Close()
            cnn1.Close()
            cbonombre.Focus().Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
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
        If AscW(e.KeyChar) = Keys.Enter And txtcodigo.Text <> "" Then
            If cbofactura.Text = "" And cboproveedor.Text = "" And cboremision.Text = "" Then Exit Sub
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Compra INNER JOIN ComprasDet ON Compras.Id=ComprasDet.Id_Compra where ComprasDet.Codigo='" & txtcodigo.Text & "' and Compras.Proveedor='" & cboproveedor.Text & "' and NumRemsion='" & cboremision.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbonombre.Items.Add(rd1("Nombre").ToString)
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtcantidad_Click(sender As Object, e As System.EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtprecio.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcantidad.TextChanged
        Dim Tmp As Single = 0
        If txtcantidad.Text = "" Or txtcantidad.Text = "." Then Exit Sub
        Tmp = CDbl(txtcantidad.Text)
        If Tmp > CantidadProd Then
            MsgBox("Cantidad no permitida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtcantidad.Text = CantidadProd
        Else
            If txtcantidad.Text = "" Or txtcantidad.Text = "." Or txtexistencia.Text = "" Then Exit Sub
            txtexis_f.Text = CDbl(txtexistencia.Text) - CDbl(txtcantidad.Text)
        End If
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
        If Not IsNumeric(txtprecio.Text) Then txtprecio.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Or txtcantidad.Text = "0" Then MsgBox("Cantidad no válida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

            txttotal.Text = CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text)) * CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text))
            txttotal.Text = FormatNumber(txttotal.Text, 2)
            cbonota_c.Enabled = False

            Call UpGrid()
            Call CalcSuma()
            Call CalcIVA()

            txttotalnc.Text = CDbl(IIf(txtivanc.Text = "", "0", txtivanc.Text)) + CDbl(IIf(txtsuma.Text = "", "0", txtsuma.Text))
            txtivanc.Text = FormatNumber(txtivanc.Text, 2)
            txttotalnc.Text = FormatNumber(txttotalnc.Text, 2)

            txttotal_final.Text = "0.00"
            txttotal_final.Text = CDbl(txtsub1.Text) + CDbl(txttotalnc.Text)
            txttotal_final.Text = FormatNumber(txttotal_final.Text, 2)

            txtcodigo.Text = ""
            cbonombre.Text = ""
            txtunidad.Text = ""
            txtcantidad.Text = ""
            txtprecio.Text = ""
            txttotal.Text = ""
            txtexistencia.Text = ""
            txtexis_f.Text = ""
            cbonombre.Focus().Equals(True)
        End If
    End Sub

    Public Sub UpGrid()
        Dim Conteo As Double = 0

        grdcaptura.Rows.Add(
            txtcodigo.Text,
            cbonombre.Text,
            txtunidad.Text,
            txtcantidad.Text,
            FormatNumber(txtprecio.Text, 2),
            FormatNumber(txttotal.Text, 2),
            txtexistencia.Text,
            FormatNumber(CDbl(txtexistencia.Text) - CDbl(txtcantidad.Text))
            )

        For t As Integer = 0 To grdcaptura.Rows.Count - 1
            Conteo = Conteo + CDbl(grdcaptura.Rows(t).Cells(3).Value.ToString)
        Next
        txtprods.Text = Conteo
    End Sub

    Public Sub CalcSuma()
        Dim sumas As Double = 0
        txtsuma.Text = "0.00"
        For n As Integer = 0 To grdcaptura.Rows.Count - 1
            sumas = sumas + CDbl(grdcaptura.Rows(n).Cells(5).Value.ToString)
        Next
        txtsuma.Text = FormatNumber(sumas, 2)
    End Sub

    Public Sub CalcIVA()
        Dim MyCalc As Double = 0
        txtivanc.Text = "0.00"

        cnn1.Close() : cnn1.Open()
        For n As Integer = 0 To grdcaptura.Rows.Count - 1
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(n).Cells(0).Value.ToString) & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MyCalc = rd1(0).ToString
                    If cbofactura.Text <> "" Then
                        txtivanc.Text = CDbl(txtivanc.Text) + (CDbl(grdcaptura.Rows(n).Cells(5).Value.ToString) * MyCalc)
                        txtivanc.Text = FormatNumber(txtivanc.Text, 2)
                    Else
                        txtivanc.Text = "0"
                        txtivanc.Text = FormatNumber(txtivanc.Text, 2)
                    End If
                End If
            End If
            rd1.Close()
        Next
        cnn1.Close()
    End Sub

    Private Sub TextBox12_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim id_usuario As Double = 0

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & TextBox12.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_usuario = rd1("IdEmpleado").ToString
                        lblusuario.Text = rd1("Alias").ToString
                    End If
                End If
                rd1.Close()

                If id_usuario <> 0 Then
                    'Permiso para realizar notas de crédito
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            btnguarda.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboproveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboproveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboremision.Focus().Equals(True)
            CantidadProd = 0
        End If
    End Sub

    Private Sub cboproveedor_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboproveedor.SelectedValueChanged
        cbonota_c.Items.Clear()
        cbofactura.Items.Clear()
        grdcaptura.Rows.Clear()
        If Trim(cboproveedor.Text) <> "" Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id from Proveedores where Compania='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cboproveedor.Tag = rd1(0).ToString
                    End If
                Else
                    cboproveedor.Tag = 0
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            CantidadProd = 0
        End If
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = 0

        If grdcaptura.Rows.Count > 0 Then
            txtcodigo.Text = CStr(grdcaptura.Rows(index).Cells(0).Value.ToString)
            cbonombre.Text = CStr(grdcaptura.Rows(index).Cells(1).Value.ToString)
            txtunidad.Text = CStr(grdcaptura.Rows(index).Cells(2).Value.ToString)
            txtcantidad.Text = grdcaptura.Rows(index).Cells(3).Value.ToString
            txtprecio.Text = grdcaptura.Rows(index).Cells(4).Value.ToString
            txttotal.Text = grdcaptura.Rows(index).Cells(5).Value.ToString
            txtexistencia.Text = grdcaptura.Rows(index).Cells(6).Value.ToString
            txtexis_f.Text = grdcaptura.Rows(index).Cells(7).Value.ToString
            If grdcaptura.Rows.Count = 1 Then
                grdcaptura.Rows.Clear()
            Else
                grdcaptura.Rows.Remove(grdcaptura.Rows(index))
            End If
            Call CalcSuma()
            Call CalcIVA()
            txtcodigo.Focus().Equals(True)
        End If        
    End Sub

    Private Sub btnguarda_Click(sender As System.Object, e As System.EventArgs) Handles btnguarda.Click
        If cboremision.Text = "" Then MsgBox("Selecciona un número de remisión para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboremision.Focus().Equals(True) : Exit Sub
        If cboproveedor.Text = "" Then MsgBox("Selecciona un proveedor para cotinuar con el proceso.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboproveedor.Focus().Equals(True) : Exit Sub
        If cbofactura.Text = "" Then MsgBox("Selecciona un número de factura para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofactura.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsccom Control Negocios Pro") : TextBox12.Focus().Equals(True) : Exit Sub
        If cbonota_c.Text = "" Then MsgBox("Indica el folio de la nota de crédito.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonota_c.Focus().Equals(True) : Exit Sub
        If grdcaptura.Rows.Count = 0 Then MsgBox("Debes asignar productos a la nota para guardarla.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar los datos de esta nota de crédito?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Compras(NumRemision,NumFactura,NumPedido,NotaCred,IdProv,Proveedor,Sub1,Desc1,Sub2,IVA,Total,Desc2,IEPS,Pagar,ACuenta,Resta,FechaC,FechaP,FechaNC,Status,FechaCancela,Usuario,Corte,CorteU,Cargado,Anticipo) values('" & cboremision.Text & "','" & cbofactura.Text & "','','" & cbonota_c.Text & "'," & cboproveedor.Tag & ",'" & cboproveedor.Text & "'," & CDbl(txtsuma.Text) & ",0," & CDbl(txtsuma.Text) & "," & CDbl(txtivanc.Text) & "," & CDbl(txttotalnc.Text) & ",0,0,0,0,0,'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-d") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','NOTA DE CREDITO','','" & lblusuario.Text & "',0,0,0,0)"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Compras set Resta=Resta-" & CDbl(txttotalnc.Text) & " where Proveedor='" & cboproveedor.Text & "' and NumFactura='" & cbofactura.Text & "'"
                cmd1.ExecuteNonQuery()

                Dim id_compra As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select max(Id) from Compras"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_compra = IIf(rd1(0).ToString = "", "1", rd1(0).ToString)
                    End If
                End If
                rd1.Close()

                Dim MySaldo As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where Proveedor='" & cboproveedor.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) - CDbl(txttotalnc.Text)
                    End If
                Else
                    MySaldo = -1 * CDbl(txttotalnc.Text)
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & cboremision.Text & "','" & cbofactura.Text & "',''," & cboproveedor.Tag & ",'" & cboproveedor.Text & "','NOTA CREDITO','" & Format(Date.Now, "yyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & CDbl(txttotalnc.Text) & "," & MySaldo & ",'','','" & lblusuario.Text & "',0,0,0)"
                cmd1.ExecuteNonQuery()

                cnn2.Close() : cnn2.Open()
                For cg As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(cg).Cells(0).Value.ToString
                    Dim nombre As String = grdcaptura.Rows(cg).Cells(1).Value.ToString
                    Dim unidad As String = grdcaptura.Rows(cg).Cells(2).Value.ToString
                    Dim cantid As Double = grdcaptura.Rows(cg).Cells(3).Value.ToString
                    Dim precio As Double = grdcaptura.Rows(cg).Cells(4).Value.ToString
                    Dim total_ As Double = grdcaptura.Rows(cg).Cells(5).Value.ToString
                    Dim exis1 As Double = grdcaptura.Rows(cg).Cells(6).Value.ToString
                    Dim exis2 As Double = grdcaptura.Rows(cg).Cells(7).Value.ToString
                    Dim depto As String = ""
                    Dim grupo As String = ""
                    Dim multi As Double = 0
                    Dim existencia As Double = 0

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from Productos where Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            depto = rd2("Departamento").ToString
                            grupo = rd2("Grupo").ToString
                            multi = rd2("Multiplo").ToString
                            existencia = rd2("Existencia").ToString
                        End If
                    End If
                    rd2.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into ComprasDet(Id_Compra,NumRemision,NumFactura,Proveedor,Codigo,Nombre,UCompra,Cantidad,Precio,Total,FechaC,Grupo,Depto,Caducidad,Lote,FolioRep,NotaCred) values(" & id_compra & ",'" & cboremision.Text & "','" & cbofactura.Text & "','" & cboproveedor.Text & "','" & codigo & "','" & nombre & "','" & unidad & "'," & cantid & "," & precio & "," & total_ & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & grupo & "','" & depto & "','','',0,'" & cbonota_c.Text & "')"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Productos set Existencia=" & (existencia - (cantid * multi)) & " where Codigo='" & codigo & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & nombre & "','Nota de credito'," & existencia & "," & cantid & "," & (existencia - (cantid * multi)) & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & cbonota_c.Text & "','','','','','')"
                    cmd1.ExecuteNonQuery()
                Next
                cnn2.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            btnnuevo.PerformClick()
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        CantidadProd = 0
        cboproveedor.Tag = 0
        cboproveedor.Text = ""
        cboremision.Items.Clear()
        cboremision.Text = ""
        cbofactura.Items.Clear()
        cbofactura.Text = ""
        cbonota_c.Items.Clear()
        cbonota_c.Text = ""
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtcodigo.Text = ""
        txtunidad.Text = ""
        txtcantidad.Text = ""
        txtprecio.Text = ""
        txttotal.Text = ""
        txtexistencia.Text = ""
        txtexis_f.Text = ""
        grdcaptura.Rows.Clear()
        txtsub1.Text = "0.00"
        txtdesc1.Text = "0.00"
        txtsub2.Text = "0.00"
        txtiva.Text = "0.00"
        txttotal_c.Text = "0.00"
        txtacuenta.Text = "0.00"
        txtresta.Text = "0.00"
        dtpfechac.Value = Date.Now
        txtsuma.Text = "0.00"
        txtivanc.Text = "0.00"
        txttotalnc.Text = "0.00"
        txtprods.Text = ""
        txttotal_final.Text = "0.00"
        dtpfechan.Value = Date.Now
        btnguarda.Enabled = True
        cbonota_c.Enabled = True
    End Sub

    Private Sub txtivanc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtivanc.TextChanged
        If txtsuma.Text = "" Then txtsuma.Text = "0.00"
        If txtivanc.Text = "" Then txtivanc.Text = "0.00"
        txttotalnc.Text = CDbl(txtivanc.Text) + CDbl(txtsuma.Text)
        txttotalnc.Text = FormatNumber(txttotalnc.Text, 2)
    End Sub

    Private Sub cboproveedor_DropDown(sender As System.Object, e As System.EventArgs) Handles cboproveedor.DropDown
        cboproveedor.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Proveedor from Compras where NumFactura<>'' and Status<>'CANCELADA' order by Proveedor"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboproveedor.Items.Add(
                        rd1(0).ToString
                        )
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class