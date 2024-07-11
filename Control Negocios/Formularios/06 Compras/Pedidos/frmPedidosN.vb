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

            Dim cod As String = ""
            Dim barras As String = ""
            Dim descripcion As String = ""
            Dim unidad As String = ""
            Dim precio As Double = 0
            Dim importe As Double = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,CodBarra,Nombre,UCompra,PrecioCompra FROM productos WHERE Codigo='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cod = rd1("Codigo").ToString
                    barras = rd1("CodBarra").ToString
                    descripcion = rd1("Nombre").ToString
                    unidad = rd1("UCompra").ToString

                    If (chk_mPrecio.Checked) Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT MIN(PrecioAnt) FROM precios WHERE Codigo='" & cod & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                precio = rd2(0).ToString
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()
                    Else
                        precio = rd1("PrecioCompra").ToString
                    End If

                    importe = CDec(txtcantidad.Text) * CDec(precio)
                End If
            End If
            rd1.Close()
            cnn1.Close()

            grdCaptura.Rows.Add(cod,
                                barras,
                                descripcion,
                                unidad,
                                FormatNumber(txtexistencia.Text, 2),
                                FormatNumber(txtcantidad.Text, 2),
                                0,
                                FormatNumber(precio, 2),
                                FormatNumber(importe, 2)
                                )
            lblCantidad.Text = lblCantidad.Text + CDec(txtcantidad.Text)
            lblCantidad.Text = FormatNumber(lblCantidad.Text, 2)

            txtSubtotal.Text = txtSubtotal.Text + CDec(importe)
            txtSubtotal.Text = FormatNumber(txtSubtotal.Text, 2)
            Limpiar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub Limpiar()
        cbonombre.Text = ""
        txtcodigo.Text = ""
        txtunidad.Text = ""
        txtexistencia.Text = ""
        txtcantidad.Text = "1"
        cbonombre.Focus.Equals(True)
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(1).ToString = 1 Then
                            lblusuario.Text = rd1(0).ToString
                        Else
                            MsgBox("El usuario esta inactivo, consulte a su administrador", vbInformation + vbOKOnly, titulocentral)
                            lblusuario.Text = ""
                            txtusuario.Text = ""
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulocentral)
                    lblusuario.Text = ""
                    txtusuario.Text = ""
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

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick

        Dim index As Integer = grdCaptura.CurrentRow.Index

        Dim codigo As String = grdCaptura.Rows(index).Cells(0).Value.ToString
        Dim descripciona As String = grdCaptura.Rows(index).Cells(2).Value.ToString
        Dim unidad As String = grdCaptura.Rows(index).Cells(3).Value.ToString
        Dim esxistencia As Double = grdCaptura.Rows(index).Cells(4).Value.ToString
        Dim cantidad As Double = grdCaptura.Rows(index).Cells(5).Value.ToString
        Dim importe As Double = grdCaptura.Rows(index).Cells(8).Value.ToString

        txtcodigo.Text = codigo
        cbonombre.Text = descripciona
        txtunidad.Text = unidad
        txtexistencia.Text = esxistencia
        txtcantidad.Text = cantidad

        lblCantidad.Text = lblCantidad.Text - cantidad
        lblCantidad.Text = FormatNumber(lblCantidad.Text, 2)

        txtSubtotal.Text = txtSubtotal.Text - CDec(importe)
        txtSubtotal.Text = FormatNumber(txtSubtotal.Text, 2)
        grdCaptura.Rows.Remove(grdCaptura.Rows(index))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtSubtotal.Text = "0.00"
        grdCaptura.Rows.Clear()
        txtcodigo.Text = ""
        cbonombre.Text = ""
        txtunidad.Text = ""
        txtexistencia.Text = ""
        txtcantidad.Text = "1"
        cboProveedor.Text = ""
        lblMoneda.Text = ""
        lblValor.Text = ""
        txtmoneda.Text = "0.00"
        chk_mPrecio.Checked = False
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        If grdCaptura.Rows.Count < 1 Then MsgBox("Necesita agregar información para el pedido") : Exit Sub

        If MsgBox("Desea guardar la información del pedido", vbInformation + vbYesNo) = vbYes Then

            If cboProveedor.Text <> "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Id FROM pedidos WHERE Id=" & lblFolio.Text
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO pedidos(Num,Proveedor,Total,Anticipo,Fecha,Hora,Status,Usuario,Cargado,TipoPago,Banco,Referencia) VALUES('" & txtNumPed.Text & "','" & cboProveedor.Text & "'," & txtSubtotal.Text & ",0,'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','" & lblusuario.Text & "',0,'','','')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

                If grdCaptura.Rows.Count - 1 Then



                End If

            End If

        End If
    End Sub

    Private Sub frmPedidosN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFolio.Start()
    End Sub

    Public Sub Folio()
        TFolio.Stop()

        cnntimer.Close() : cnntimer.Open()
        cmdtimer = cnntimer.CreateCommand
        cmdtimer.CommandText = "SELECT MAX(Id) FROM pedidos"
        rdtimer = cmdtimer.ExecuteReader
        If rdtimer.HasRows Then
            If rdtimer.Read Then
                lblFolio.Text = IIf(rdtimer(0).ToString = "", 0, rdtimer(0).ToString) + 1
            Else
                lblFolio.Text = "1"
            End If
        Else
            lblFolio.Text = "1"
        End If
        rdtimer.Close()
        cnntimer.Close()

        TFolio.Start()
    End Sub

    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick
        Folio()
    End Sub
End Class
