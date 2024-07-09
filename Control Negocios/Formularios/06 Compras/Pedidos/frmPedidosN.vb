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
            cbonombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

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
                    cbonombre.Text = rd1("Nombre").ToString
                    txtcodigo.Text = rd1("Codigo").ToString
                    txtunidad.Text = rd1("UCompra").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            txtcodigo.Focus.Equals(True)
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
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = ""
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub chk_mPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chk_mPrecio.CheckedChanged

        If (chk_mPrecio.Checked) Then
            lblProveedorMin.Visible = True
            txtProveedorMin.Visible = True
        Else
            lblProveedorMin.Visible = False
            txtProveedorMin.Visible = False
        End If
    End Sub
End Class