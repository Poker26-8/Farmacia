Public Class frmCtsPagar

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Proveedor from Compras where Status='RESTA'"
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

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboremision.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id from Proveedores where Compania='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtid_prov.Text = rd1("Id").ToString
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
            If (optfacturas.Checked) Then
                cmd1.CommandText =
                    "select NumRemision from Compras where Proveedor='" & cbonombre.Text & "' and NumFactura<>''"
            Else
                cmd1.CommandText =
                    "select NumRemision from Compras where Proveedor='" & cbonombre.Text & "' and NumFactura='' AND Resta<>0"
            End If
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

    Private Sub cbofactura_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofactura.DropDown
        cbofactura.Items.Clear()
        If (optfacturas.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumFactura from Compras where Proveedor='" & cbonombre.Text & "' and NumRemision='" & cboremision.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        cbofactura.Items.Add(
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
        End If
    End Sub

    Public Sub cboremision_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboremision.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        Dim id_compra As Integer = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboremision.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id,NumFactura,Sub1,Desc1,Sub2,IVA,Total,Desc2,Pagar,Anticipo,FechaC,Resta from Compras where Proveedor='" & cbonombre.Text & "' and NumRemision='" & cboremision.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            id_compra = rd1("Id").ToString
                            cbofactura.Text = rd1("NumFactura").ToString
                            txtsub1.Text = FormatNumber(rd1("Sub1").ToString, 2)
                            txtdesc1.Text = FormatNumber(rd1("Desc1").ToString, 2)
                            txtsub2.Text = FormatNumber(rd1("Sub2").ToString, 2)
                            txtiva.Text = FormatNumber(rd1("IVA").ToString, 2)
                            txttotal.Text = FormatNumber(rd1("Total").ToString, 2)
                            txtdesc2.Text = FormatNumber(rd1("Desc2").ToString, 2)
                            txtapagar.Text = FormatNumber(rd1("Pagar").ToString, 2)
                            txtanticipo.Text = FormatNumber(rd1("Anticipo").ToString, 2)
                            dtpfecha.Text = rd1("FechaC").ToString
                            txtresta.Text = rd1("Resta").ToString

                            btnabono.Enabled = True
                            If cbofactura.Text <> "" Then
                                btnasignar.Enabled = False
                            Else
                                btnasignar.Enabled = True
                            End If
                        End If
                    End If
                    rd1.Close()

                    Dim efec As Double = 0
                    Dim tarj As Double = 0
                    Dim trans As Double = 0
                    Dim otro As Double = 0

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Efectivo,Tarjeta,Transfe,Otro from AbonoE where Proveedor='" & cbonombre.Text & "' and NumRemision='" & cboremision.Text & "' and Concepto='ABONO'"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            efec = efec + CDbl(IIf(rd1("Efectivo").ToString = "", "0", rd1("Efectivo").ToString))
                            tarj = tarj + CDbl(IIf(rd1("Tarjeta").ToString = "", "0", rd1("Tarjeta").ToString))
                            trans = trans + CDbl(IIf(rd1("Transfe").ToString = "", "0", rd1("Transfe").ToString))
                            otro = otro + CDbl(IIf(rd1("Otro").ToString = "", "0", rd1("Otro").ToString))
                        End If
                    Loop
                    rd1.Close()
                    txtefectivo.Text = FormatNumber(efec, 2)
                    txtpagos.Text = tarj + trans + otro
                    txtpagos.Text = FormatNumber(txtpagos.Text, 2)

                    grdcaptura.Rows.Clear()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Codigo,Nombre,UCompra,Cantidad,Precio,Total from ComprasDet where Id_Compra=" & id_compra
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            Dim codigo As String = rd1("Codigo").ToString
                            Dim nombre As String = rd1("Nombre").ToString
                            Dim unidad As String = rd1("UCompra").ToString
                            Dim canida As Double = rd1("Cantidad").ToString
                            Dim precio As Double = rd1("Precio").ToString
                            Dim total As Double = rd1("Total").ToString

                            grdcaptura.Rows.Add(
                                codigo,
                                nombre,
                                unidad,
                                canida,
                                FormatNumber(precio, 4),
                                FormatNumber(total, 4)
                                )
                        End If
                    Loop
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                dtpfecha.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtdesc2_Click(sender As System.Object, e As System.EventArgs) Handles txtdesc2.Click
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtdesc2_GotFocus(sender As Object, e As System.EventArgs) Handles txtdesc2.GotFocus
        txtdesc2.SelectionStart = 0
        txtdesc2.SelectionLength = Len(txtdesc2.Text)
    End Sub

    Private Sub txtdesc2_TextChanged(sender As Object, e As System.EventArgs) Handles txtdesc2.TextChanged
        If txtdesc2.Text = "" Then txtdesc2.Text = "0.00"
        If txtapagar.Text = "" Then txtapagar.Text = "0.00"
        If txttotal.Text = "" Then txttotal.Text = "0.00"
        If txtresta.Text = "" Then txtresta.Text = "0.00"
        If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"
        If txtpagos.Text = "" Then txtpagos.Text = "0.00"
        If txtanticipo.Text = "" Then txtanticipo.Text = "0.00"

        txtapagar.Text = CDbl(txttotal.Text) - CDbl(txtdesc2.Text)
        txtapagar.Text = FormatNumber(txtapagar.Text, 2)
        Dim acuenta As Double = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text) + CDbl(txtanticipo.Text)
        txtresta.Text = CDbl(txtapagar.Text) - CDbl(acuenta)
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtdesc2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc2.KeyPress
        If Not IsNumeric(txtdesc2.Text) Then txtdesc2.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Compras set Desc2=" & CDbl(txtdesc2.Text) & ", Pagar=" & CDbl(txtapagar.Text) & ", Resta=" & CDbl(txtresta.Text) & " and NumRemision='" & cboremision.Text & "' and Proveedor='" & cbonombre.Text & "'"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        End If
    End Sub

    Private Sub cbofactura_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbofactura.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        Dim id_compra As Integer = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbofactura.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id,NumRemision,Sub1,Desc1,Sub2,IVA,Total,Desc2,Pagar,Anticipo,FechaC from Compras where Proveedor='" & cbonombre.Text & "' and NumFactura='" & cbofactura.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            id_compra = rd1("Id").ToString
                            cboremision.Text = rd1("NumRemision").ToString
                            txtsub1.Text = FormatNumber(rd1("Sub1").ToString, 2)
                            txtdesc1.Text = FormatNumber(rd1("Desc1").ToString, 2)
                            txtsub2.Text = FormatNumber(rd1("Sub2").ToString, 2)
                            txtiva.Text = FormatNumber(rd1("IVA").ToString, 2)
                            txttotal.Text = FormatNumber(rd1("Total").ToString, 2)
                            txtdesc2.Text = FormatNumber(rd1("Desc2").ToString, 2)
                            txtapagar.Text = FormatNumber(rd1("Pagar").ToString, 2)
                            txtanticipo.Text = FormatNumber(rd1("Anticipo").ToString, 2)
                            dtpfecha.Text = rd1("FechaC").ToString
                            btnabono.Enabled = True
                            If cbofactura.Text <> "" Then
                                btnasignar.Enabled = False
                            Else
                                btnasignar.Enabled = True
                            End If
                        End If
                    End If
                    rd1.Close()

                    Dim efec As Double = 0
                    Dim tarj As Double = 0
                    Dim trans As Double = 0
                    Dim otro As Double = 0

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Efectivo,Tarjeta,Transfe,Otro from AbonoE where Proveedor='" & cbonombre.Text & "' and NumFactura='" & cbofactura.Text & "' and Concepto='ABONO'"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            efec = efec + CDbl(IIf(rd1("Efectivo").ToString = "", "0", rd1("Efectivo").ToString))
                            tarj = tarj + CDbl(IIf(rd1("Tarjeta").ToString = "", "0", rd1("Tarjeta").ToString))
                            trans = trans + CDbl(IIf(rd1("Transfe").ToString = "", "0", rd1("Transfe").ToString))
                            otro = otro + CDbl(IIf(rd1("Otro").ToString = "", "0", rd1("Otro").ToString))
                        End If
                    Loop
                    rd1.Close()
                    txtefectivo.Text = FormatNumber(efec, 2)
                    txtpagos.Text = tarj + trans + otro
                    txtpagos.Text = FormatNumber(txtpagos.Text, 2)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Codigo,Nombre,UCompra,Cantidad,Precio,Total from ComprasDet where Id_Compra=" & id_compra
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            Dim codigo As String = rd1("Codigo").ToString
                            Dim nombre As String = rd1("Nombre").ToString
                            Dim unidad As String = rd1("UCompra").ToString
                            Dim canida As Double = rd1("Cantidad").ToString
                            Dim precio As Double = rd1("Precio").ToString
                            Dim total As Double = rd1("Total").ToString

                            grdcaptura.Rows.Add(
                                codigo,
                                nombre,
                                unidad,
                                canida,
                                FormatNumber(precio, 4),
                                FormatNumber(total, 4)
                                )
                        End If
                    Loop
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtid_prov.Text = ""
        cboremision.Items.Clear()
        cboremision.Text = ""
        cbofactura.Items.Clear()
        cbofactura.Text = ""
        optfacturas.Checked = False
        grdcaptura.Rows.Clear()
        txtsub1.Text = "0.00"
        txtdesc1.Text = "0.00"
        txtsub2.Text = "0.00"
        txtiva.Text = "0.00"
        txttotal.Text = "0.00"
        txtdesc2.Text = "0.00"
        txtapagar.Text = "0.00"
        dtpfecha.Value = Date.Now
        txtefectivo.Text = "0.00"
        txtpagos.Text = "0.00"
        txtanticipo.Text = "0.00"
        txtresta.Text = "0.00"
        btnabono.Enabled = False
        btnasignar.Enabled = False
    End Sub

    Private Sub btnabono_Click(sender As System.Object, e As System.EventArgs) Handles btnabono.Click
        If cboremision.Text = "" Then
            MsgBox("Selecciona el número de remisión de la compra.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cboremision.Focus().Equals(True)
            Exit Sub
        Else
            btnabono.Enabled = False
            frmAbonoCompras.cboproveedor.Text = cbonombre.Text
            frmAbonoCompras.txtremision.Text = cboremision.Text
            frmAbonoCompras.Show()
            frmAbonoCompras.txtremision.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnasignar_Click(sender As System.Object, e As System.EventArgs) Handles btnasignar.Click
        Dim factura As String = ""

        If cbofactura.Text <> "" Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumFactura from Compras where NumRemision='" & cboremision.Text & "' and Proveedor='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        factura = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                If factura <> "" Then
                    If cbofactura.Text <> factura Then
                        If MsgBox("La compra ya cuenta con un número de factura, ¿deseas reemplazarlo por uno nuevo?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "update Compras set NumFactura='" & cbofactura.Text & "' where NumRemision='" & cboremision.Text & "' and Proveedor='" & cbonombre.Text & "'"
                            If cmd1.ExecuteNonQuery Then
                                MsgBox("Número de factura actualziado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            End If
                        End If
                    Else
                        MsgBox("El número de factura es el mismo que existe en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        cbofactura.SelectAll()
                    End If
                Else
                    If MsgBox("¿Deseas asignar este número de factura a la compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Compras set NumFactura='" & cbofactura.Text & "' where NumRemision='" & cboremision.Text & "' and Proveedor='" & cbonombre.Text & "'"
                        If cmd1.ExecuteNonQuery Then
                            MsgBox("Número de factura actualziado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                    End If
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub frmCtsPagar_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        cbonombre.Focus().Equals(True)
    End Sub

    Private Sub frmCtsPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class