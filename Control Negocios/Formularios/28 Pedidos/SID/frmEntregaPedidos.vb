Public Class frmEntregaPedidos

    Dim id_cliente As Integer = 0
    Dim unidadsel As String = ""
    Private Sub frmEntregaPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboProveedor_DropDown(sender As Object, e As EventArgs) Handles cboProveedor.DropDown
        Try
            cboProveedor.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Proveedor FROM pedidos WHERE Proveedor<>'' ORDER BY Proveedor"
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

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboFolio_DropDown(sender As Object, e As EventArgs) Handles cboFolio.DropDown
        Try
            cboFolio.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If cboProveedor.Text = "" Then
                cmd5.CommandText = "SELECT DISTINCT Num FROM pedidos WHERE Num<>'' ORDER BY Num"
            Else
                cmd5.CommandText = "SELECT DISTINCT Num FROM pedidos WHERE Proveedor='" & cboProveedor.Text & "' AND Num<>'' ORDER BY Num"
            End If


            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboFolio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cboProveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboFolio.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboFolio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            grdCaptura.Rows.Clear()
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Proveedor,Codigo,Nombre,Unidad,Precio,Cantidad FROM pedidosdet WHERE NumPed='" & cboFolio.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    If cboProveedor.Text = "" Then
                        cboProveedor.Text = rd1("proveedor").ToString
                    End If

                    Dim importe As Double = 0
                    importe = CDec(rd1("Cantidad").ToString) * CDec(rd1("Precio").ToString)

                    grdCaptura.Rows.Add(rd1("Codigo").ToString,
                                        rd1("Nombre").ToString,
                                        rd1("Unidad").ToString,
                                       FormatNumber(rd1("Cantidad").ToString, 2),
                                        FormatNumber(rd1("Precio").ToString, 2),
                                        FormatNumber(importe, 2)
)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

            cboCliente.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

        End If
    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFolio.SelectedValueChanged
        cboFolio_KeyPress(cboFolio, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub cboCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id,Calle,NInterior,NExterior,Colonia,Delegacion,Entidad,Pais,CP FROM CLientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_cliente = rd1("Id").ToString

                    Dim dire(9) As String
                    Dim direccion As String = ""

                    dire(0) = rd1("Calle").ToString()       'Calle
                    dire(1) = rd1("NInterior").ToString()   'Numero Int
                    dire(2) = rd1("NExterior").ToString()   'Numero Ext
                    dire(3) = rd1("Colonia").ToString()     'Colonia
                    dire(4) = rd1("Delegacion").ToString()  'Delegacion
                    dire(5) = rd1("Entidad").ToString()     'Entidad
                    dire(6) = rd1("Pais").ToString()        'Pais
                    dire(7) = rd1("CP").ToString()          'CP


                    'Calle
                    If Trim(dire(0)) <> "" Then
                        direccion = direccion & dire(0) & " "
                    End If
                    'Numero Int
                    If Trim(dire(1)) <> "" Then
                        direccion = direccion & dire(1) & " "
                    End If
                    'Numero Ext
                    If Trim(dire(2)) <> "" Then
                        direccion = direccion & dire(2) & " "
                    End If
                    'Colonia
                    If Trim(dire(3)) <> "" Then
                        direccion = direccion & dire(3) & " "
                    End If
                    'Delegacion
                    If Trim(dire(4)) <> "" Then
                        direccion = direccion & dire(4) & " "
                    End If
                    'Entidad
                    If Trim(dire(5)) <> "" Then
                        direccion = direccion & dire(5) & " "
                    End If
                    'Pais
                    If Trim(dire(6)) <> "" Then
                        direccion = direccion & dire(6) & " "
                    End If
                    'CP
                    If Trim(dire(7)) <> "" Then
                        direccion = direccion & "CP " & dire(7) & " "
                    End If

                    txtdireccion.Text = ""
                    txtdireccion.Text = direccion

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        Try
            Dim subtotal As Double = 0
            Dim iva As Double = 0
            Dim preciosiniva As Double = 0
            Dim totaliva As Double = 0

            Dim depto As String = ""
            Dim grupo As String = ""

            Dim total As Double = txtTotal.Text

            If MsgBox("Se guardara la información, favor de revisar", vbInformation + vbYesNo) = vbYes Then

                If grdPedido.Rows.Count < 1 Then cboCliente.Focused.Equals(True) : Exit Sub
                If lblUsuario.Text = "" Then MsgBox("Ingrese la contraseña", vbInformation + vbOKOnly) : txtcontraseña.Focus.Equals(True) : Exit Sub

                cnn3.Close() : cnn3.Open()
                For luffy As Integer = 0 To grdPedido.Rows.Count - 1

                    Dim cod As String = grdPedido.Rows(luffy).Cells(0).Value.ToString

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT Iva,Departamento,Grupo FROM productos WHERE Codigo='" & cod & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            iva = rd3("IVA").ToString
                            depto = rd3("Departamento").ToString
                            grupo = rd3("Grupo").ToString

                        End If
                    End If
                    rd3.Close()

                Next
                cnn3.Close()


                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT NumPedido FROM pedidosVen WHERE NumPedido='" & cboFolio.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO pedidosven(NumPedido,IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,Fecha) AVLUES('" & cboFolio.Text & "'," & id_cliente & ",'" & cboCliente.Text & "','" & txtdireccion.Text & "'," & total & ",0," & total & ",0," & total & ",'" & lblUsuario.Text & "','" & Format(Date.Now,) & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()


                End If
                rd1.Close()
                cnn1.Close()


            End If













        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim fila As Integer = grdCaptura.CurrentRow.Index

        If celda.ColumnIndex = 3 Then
            boxcantidad.Visible = True
            txtcantidad.Focus().Equals(True)
            txtcantidad.Tag = grdCaptura.CurrentRow.Cells(3).Value.ToString
            txtcodigo.Text = grdCaptura.CurrentRow.Cells(0).Value.ToString
            txtcodigo.Tag = fila
            txtnombre.Text = grdCaptura.CurrentRow.Cells(1).Value.ToString
            unidadsel = grdCaptura.CurrentRow.Cells(2).Value.ToString
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If txtcantidad.Text = "" Then
                boxcantidad.Visible = False
                Exit Sub
            End If

            Dim inicial As Double = txtcantidad.Tag
            Dim final As Double = 0
            Dim actual As Double = 0
            Dim tot As Double = 0

            Dim precio As Double = grdCaptura.Rows(txtcodigo.Tag).Cells(4).Value.ToString()
            Dim total As Double = CDbl(grdCaptura.Rows(txtcodigo.Tag).Cells(4).Value.ToString()) * CDbl(txtcantidad.Text)

            actual = txtcantidad.Text

            If actual > inicial Then MsgBox("No puedes entregar una cantidad mayor a la que está pendiente.", vbInformation + vbOKOnly, titulocentral) : txtcantidad.SelectAll() : Exit Sub
            final = inicial - actual

            grdPedido.Rows.Add(txtcodigo.Text, txtnombre.Text, unidadsel, actual, FormatNumber(precio, 2), FormatNumber(total, 2))
            My.Application.DoEvents()

            grdCaptura.Rows(txtcodigo.Tag).Cells(3).Value = final
            tot = CDec(grdCaptura.Rows(txtcodigo.Tag).Cells(3).Value * grdCaptura.Rows(txtcodigo.Tag).Cells(4).Value)
            grdCaptura.Rows(txtcodigo.Tag).Cells(5).Value = tot

            txtcantidad.Text = ""
            txtcantidad.Tag = ""
            txtcodigo.Text = ""
            txtcodigo.Tag = ""
            txtnombre.Text = ""
            unidadsel = ""
            boxcantidad.Visible = False

            Dim totas As Double = 0
            For ty As Integer = 0 To grdPedido.Rows.Count - 1
                totas = totas + CDbl(grdPedido.Rows(ty).Cells(5).Value.ToString())
            Next
            txtTotal.Text = FormatNumber(txtTotal.Text, 2)

        End If
    End Sub

    Private Sub grdPedido_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPedido.CellDoubleClick

        Dim fila As Integer = grdPedido.CurrentRow.Index

        Dim cod As String = grdPedido.Rows(fila).Cells(0).Value.ToString

        For deku As Integer = 0 To grdCaptura.Rows.Count - 1

            If cod = grdCaptura.Rows(deku).Cells(0).Value.ToString Then

                Dim cantidad As Double = grdPedido.CurrentRow.Cells(3).Value.ToString
                Dim total As Double = grdPedido.CurrentRow.Cells(5).Value.ToString

                grdCaptura.Rows(deku).Cells(3).Value = grdCaptura.Rows(deku).Cells(3).Value + cantidad
                grdCaptura.Rows(deku).Cells(3).Value = FormatNumber(grdCaptura.Rows(deku).Cells(3).Value, 2)

                grdCaptura.Rows(deku).Cells(5).Value = grdCaptura.Rows(deku).Cells(5).Value + total
                grdCaptura.Rows(deku).Cells(5).Value = FormatNumber(grdCaptura.Rows(deku).Cells(5).Value, 2)
            End If

        Next
        grdPedido.Rows.Remove(grdPedido.Rows(fila))
    End Sub
End Class