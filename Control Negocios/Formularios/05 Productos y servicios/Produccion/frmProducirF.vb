Imports System.IO
Public Class frmProducirF

    Dim renglon As Integer = 0
    Dim codigoseleccionado As String = ""
    Private Sub frmProducirF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub cbonombre_DropDown(sender As Object, e As EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT DescripP FROM miprod WHERE DescripP<>'' ORDER BY DescripP"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbonombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        Try
            cboDescripcion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDescripcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbocodigo_DropDown(sender As Object, e As EventArgs) Handles cbocodigo.DropDown
        Try
            cbocodigo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CodigoP FROM miprod WHERE CodigoP<>'' ORDER BY CodigoP"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbocodigo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCodigoI_DropDown(sender As Object, e As EventArgs) Handles cboCodigoI.DropDown
        Try
            cboCodigoI.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM productos WHERE Codigo<>'' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodigoI.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboLote_DropDown(sender As Object, e As EventArgs) Handles cboLote.DropDown
        Try
            cboLote.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Lote FROM lotecaducidad WHERE Codigo='" & cbocodigo.Text & "' AND lote<>'' ORDER BY lote"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboLote.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboLoteS_DropDown(sender As Object, e As EventArgs) Handles cboLoteS.DropDown
        Try
            cboLoteS.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT lote FROM lotecaducidad WHERE Codigo='" & cboCodigoI.Text & "'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboLoteS.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            grdcaptura.Rows.Clear()
            txtcostod.Text = "0.00"
            Dim codigo As String = ""
            Dim nombre As String = ""
            Dim unidad As String = ""
            Dim cantidad As Double = 0
            Dim existencia As Double = 0
            Dim multiplo As Double = 0
            Dim precio_com As Double = 0
            Dim mytotal As Double = 0

            Dim lote As String = ""
            Dim caducidad As Date = Nothing
            Dim fcaducidad As String = ""

            Dim fase As String = ""
            Dim comfase As String = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM miprod WHERE DescripP='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1.HasRows Then
                    cbocodigo.Text = rd1("CodigoP").ToString
                    txtunidad.Text = rd1("UVentaP").ToString
                End If
            End If
            rd1.Close()

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "select * from Productos where Codigo='" & rd1("Codigo").ToString & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            precio_com = rd2("PrecioCompra").ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Lote,Caducidad FROM lotecaducidad WHERE Codigo='" & rd1("Codigo").ToString & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.Read Then
                        If rd2.HasRows Then
                            lote = rd2(0).ToString
                            caducidad = rd2(1).ToString
                            fcaducidad = Format(caducidad, "yyyy-MM-dd")
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & Strings.Left(rd1("Codigo").ToString, 6) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            codigo = rd1("Codigo").ToString
                            nombre = rd1("Descrip").ToString
                            unidad = rd1("UVenta").ToString
                            cantidad = rd1("Cantidad").ToString
                            existencia = rd2("Existencia").ToString
                            multiplo = rd2("Multiplo").ToString

                            mytotal = CDec(rd2("PrecioCompra").ToString) * cantidad

                            fase = rd1("Fase").ToString
                            comfase = rd1("Comentario").ToString

                            If rd1("Grupo").ToString <> "SERVICIOS" Then
                                grdcaptura.Rows.Add(codigo,
                                                    nombre,
                                                    unidad,
                                                    FormatNumber(cantidad, 2),
                                                    FormatNumber(precio_com, 2),
                                                    FormatNumber(cantidad * precio_com, 2),
                                                    FormatNumber(existencia / multiplo, 2),
                                                    FormatNumber((existencia / multiplo) / multiplo, 2),
                                                    lote,
                                                    fcaducidad,
                                                    fase,
                                                    comfase
                                                    )
                            Else
                                grdcaptura.Rows.Add(codigo,
                                                    nombre,
                                                    unidad,
                                                    FormatNumber(cantidad, 2),
                                                    FormatNumber(precio_com, 2),
                                                    FormatNumber(cantidad * precio_com, 2), "", "",
                                                    lote,
                                                    fcaducidad,
                                                    fase,
                                                    comfase
                                                                    )
                            End If

                        End If
                    End If
                    rd2.Close()
                    txtcostod.Text = CDec(txtcostod.Text) + mytotal
                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()

            txtcostod.Text = FormatNumber(txtcostod.Text, 2)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub cbocodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbocodigo.SelectedValueChanged

    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cbonombre_SelectedValueChanged(cbonombre, New EventArgs())
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cbocodigo_SelectedValueChanged(cbocodigo, New EventArgs())
            txtcantidad.Focus().Equals(True)
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
        Dim mytotal As Double = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Then Exit Sub
            If txtcantidad.Text = "." Then Exit Sub
            If Not IsNumeric(txtcantidad.Text) Then Exit Sub
            If CDec(txtcantidad.Text) = 0 Then Exit Sub

            Call cbonombre_SelectedValueChanged(cbonombre, New EventArgs())
            txtcostod.Text = "0.00"
            For d As Integer = 0 To grdcaptura.Rows.Count - 1
                Dim total As Double = 0
                Dim precio As Double = grdcaptura.Rows(d).Cells(4).Value.ToString
                Dim cantidad As Double = grdcaptura.Rows(d).Cells(3).Value.ToString

                grdcaptura.Rows(d).Cells(3).Value = FormatNumber(cantidad * CDec(txtcantidad.Text), 4)
                cantidad = grdcaptura.Rows(d).Cells(3).Value.ToString
                total = cantidad * precio
                grdcaptura.Rows(d).Cells(5).Value = FormatNumber(total, 2)
                mytotal += total
            Next
            txtcostod.Text = FormatNumber(mytotal, 2)
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        cbocodigo.Text = ""
        cbonombre.Text = ""
        txtunidad.Text = ""
        txtcantidad.Text = ""
        txtcostod.Text = "0.00"
        cboLote.Text = ""
        dtpFechaLote.Value = Date.Now

        cboCodigoI.Text = ""
        cboDescripcion.Text = ""
        txtUnidadI.Text = ""
        txtCantidadI.Text = ""
        txtPrecioI.Text = "0.00"
        txtTotalI.Text = "0.00"
        cboLoteS.Text = ""
        dtpFechaLoteS.Value = Date.Now
        txtFase.Text = ""

        cboCliente.Text = ""
        txtSKU.Text = ""
        dtpAprobación.Value = Date.Now
        dtpFechaRecepcion.Value = Date.Now
        txtnumcliente.Text = ""
        txtCodigo.Text = ""
        txtRevision.Text = ""

        grdcaptura.Rows.Clear()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try

            Dim existencia As Double = 0
            Dim multiplo As Double = 0
            Dim cantidad As Double = 0
            Dim nueva_existencia As Double = 0
            Dim precio As Double = 0

            If lblUsuario.Text = "" Then MsgBox("Ingrece la contraseña", vbInformation + vbOKOnly, titulocentral) : txtContraseña.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            If MsgBox("¿Deseas generar la producción de este producto?", vbInformation + vbOKCancel, titulocentral) = vbOK Then

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cbocodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existencia = rd1("Existencia").ToString
                        multiplo = rd1("Multiplo").ToString
                    End If
                    cantidad = CDec(txtcantidad.Text) * multiplo
                    nueva_existencia = existencia + cantidad
                    precio = cantidad * CDbl(txtcostod.Text)
                End If
                rd1.Close()

                'actualiza la existencia y el precio de compra del producto final
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE productos SET Cargado=0,CargadoInv=0,Existencia=" & nueva_existencia & ",PrecioCompra=" & precio & " WHERE Codigo='" & cbocodigo.Text & "'"
                cmd1.ExecuteNonQuery()

                'inserta el registro de cardex de la nueva existencia del producto final
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) VALUES('" & cbocodigo.Text & "','" & cbonombre.Text & "','Producción'," & existencia & "," & cantidad & "," & nueva_existencia & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblUsuario.Text & "','','','','','','')"
                cmd1.ExecuteNonQuery()

                'va actaulizar el lote del producto final
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM lotecaducidad WHERE Codigo='" & cbocodigo.Text & "' AND Lote='" & cboLote.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Dim cantlote As Double = 0
                        Dim newcantidad As Double = 0

                        cantlote = rd1("Cantidad").ToString
                        newcantidad = CDec(cantlote) + CDec(txtcantidad.Text)

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "UPDATE lotecaducidad SET Cantidad=" & newcantidad & " WHERE Codigo='" & cbocodigo.Text & "' AND Lote='" & cboLote.Text & "'"
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()

                    End If
                End If
                rd1.Close()
                'se crea el ciclo para recorrer todos los insumos y actualizar las existencias y agregar los cardex de cada uno

                For luffy As Integer = 0 To grdcaptura.Rows.Count - 1

                    Dim codinsumo As String = grdcaptura.Rows(luffy).Cells(0).Value.ToString
                    Dim nombreinsumo As String = grdcaptura.Rows(luffy).Cells(1).Value.ToString
                    Dim unidadinsumo As String = grdcaptura.Rows(luffy).Cells(2).Value.ToString
                    Dim cantidadinsumo As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                    Dim precioinsumo As Double = grdcaptura.Rows(luffy).Cells(4).Value.ToString
                    Dim totalinsumo As Double = grdcaptura.Rows(luffy).Cells(5).Value.ToString
                    Dim existenciainsumo As Double = grdcaptura.Rows(luffy).Cells(6).Value.ToString
                    Dim existenciapinsumo As Double = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                    Dim loteinsumo As String = grdcaptura.Rows(luffy).Cells(8).Value.ToString
                    Dim fechaloteinsumo As String = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                    Dim fase As String = grdcaptura.Rows(luffy).Cells(10).Value
                    Dim comentario As String = grdcaptura.Rows(luffy).Cells(11).Value

                    'se busca el detalle de la produccion y se actualizara la existencia si fue modificada a la original
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM miprod WHERE Codigo='" & codinsumo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                            'se actualiza la existencia del insumo si fue modificado
                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "UPDATE miprod SET Cantidad=" & cantidadinsumo & ",Lote='" & loteinsumo & "',Fase='" & fase & "',Comentario='" & comentario & "' WHERE Codigo='" & codinsumo & "'"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM lotecaducidad WHERE Codigo='" & codinsumo & "' AND Lote='" & loteinsumo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            Dim cantidadlotes As Double = 0
                            Dim nuevacoantidadlotes As Double = 0

                            cantidadlotes = rd2("Cantidad").ToString
                            nuevacoantidadlotes = CDec(cantidadlotes) - CDec(cantidadinsumo)

                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "UPDATE lotecaducidad SET Cantidad=" & nuevacoantidadlotes & " WHERE Codigo='" & codinsumo & "' AND lote='" & loteinsumo & "'"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If
                    End If
                    rd2.Close()

                    Dim exis As Double = 0
                    Dim new_exist As Double = 0
                    Dim multi As Double = 0

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & codinsumo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            exis = rd1("Existencia").ToString
                            multi = rd1("Multiplo").ToString
                            new_exist = exis - (cantidadinsumo * multi)
                        End If
                    End If
                    rd1.Close()

                    'actualiza la existencia de los insumos
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE productos SET Cargado=0,CargadoInv=0,Existencia=" & new_exist & " WHERE Codigo='" & codinsumo & "'"
                    cmd1.ExecuteNonQuery()

                    'inserta el cardex de los insumos
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) VALUES('" & codinsumo & "','" & nombreinsumo & "','Descuento por producción'," & exis & "," & cantidadinsumo & "," & new_exist & "," & precioinsumo & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & lblUsuario.Text & "','','','','','','')"
                    cmd1.ExecuteNonQuery()


                Next
                cnn1.Close()
                cnn2.Close()
            End If

            Dim tamticket As Integer = 0
            Dim impresoraticket As String = ""

            tamticket = TamImpre()
            impresoraticket = ImpresoraImprimir()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index

        If grdcaptura.Rows.Count > 0 Then

            If grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
                renglon = grdcaptura.CurrentRow.Index
                rtComentario.Visible = True
                rtComentario.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
                rtComentario.Focus().Equals(True)
                Exit Sub
            End If

            cboCodigoI.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
            cboDescripcion.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
            txtUnidadI.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
            txtCantidadI.Text = grdcaptura.Rows(index).Cells(3).Value.ToString
            txtPrecioI.Text = grdcaptura.Rows(index).Cells(4).Value.ToString
            txtTotalI.Text = grdcaptura.Rows(index).Cells(5).Value.ToString
            txtExistencia.Text = grdcaptura.Rows(index).Cells(6).Value.ToString
            txtExistenciaPro.Text = grdcaptura.Rows(index).Cells(7).Value.ToString
            cboLoteS.Text = grdcaptura.Rows(index).Cells(8).Value.ToString
            dtpFechaLoteS.Value = grdcaptura.Rows(index).Cells(9).Value.ToString
            txtFase.Text = grdcaptura.Rows(index).Cells(10).Value
            txtComentario.Text = grdcaptura.Rows(index).Cells(11).Value

            grdcaptura.Rows.Remove(grdcaptura.Rows(index))
            cboDescripcion.Focus.Equals(True)
        End If

    End Sub

    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCodigoI.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCodigoI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigoI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtUnidadI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtUnidadI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnidadI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCantidadI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCantidadI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadI.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtCantidadI.Text) Then
                txtPrecioI.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub txtPrecioI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioI.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecioI.Text) Then
                txtTotalI.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtTotalI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalI.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtTotalI.Text) Then
                txtExistencia.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtExistencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtExistenciaPro.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtExistenciaPro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistenciaPro.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboLoteS.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboLoteS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboLoteS.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpFechaLoteS.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpFechaLoteS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFechaLoteS.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtFase.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtFase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFase.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            grdcaptura.Rows.Add(cboCodigoI.Text,
                                cboDescripcion.Text,
                                txtUnidadI.Text,
                                FormatNumber(txtCantidadI.Text, 2),
                                FormatNumber(txtPrecioI.Text, 2),
                                FormatNumber(txtTotalI.Text, 2),
                                FormatNumber(txtExistencia.Text, 2),
                                FormatNumber(txtExistenciaPro.Text, 2),
                                cboLoteS.Text,
                                Format(dtpFechaLoteS.Value, "yyyy-MM-dd"),
                                txtFase.Text,
                                txtComentario.Text)

            cboCodigoI.Text = ""
            cboDescripcion.Text = ""
            txtUnidadI.Text = ""
            txtCantidadI.Text = ""
            txtPrecioI.Text = ""
            txtTotalI.Text = ""
            txtExistencia.Text = "0.00"
            txtExistenciaPro.Text = "0.00"
            cboLoteS.Text = ""
            dtpFechaLoteS.Value = Date.Now
            txtFase.Text = ""
            txtComentario.Text = ""
        End If
    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then


                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtContraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Status").ToString = 1 Then
                            lblUsuario.Text = rd1("Alias").ToString
                        Else
                            MsgBox("El usuario esta inactivo, Contacte a su administrador", vbInformation + vbOKOnly, titulocentral)
                            txtContraseña.Text = ""
                            lblUsuario.Text = ""
                            txtContraseña.Focus.Equals(True)
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("La contraseña es incorrecta", vbInformation + vbOKOnly, titulocentral)
                    txtContraseña.Text = ""
                    lblUsuario.Text = ""
                    txtContraseña.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub rtComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtComentario.KeyPress
        If AscW(e.KeyChar) = 0 Then
            rtComentario.Text = ""
            rtComentario.Visible = False
            Exit Sub
        End If

        If AscW(e.KeyChar) = Keys.Enter Then
            rtComentario.Visible = False

            For q As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(q).Cells(0).Value = codigoseleccionado Then
                    grdcaptura.Rows(q).Cells(11).Value = rtComentario.Text
                End If
            Next




            'If renglon = 0 Then
            '    grdcaptura.Rows.Add("", rtComentario.Text, "", "", "", "", "", "", "", "", "")
            'Else
            '    grdcaptura.Rows(renglon).Cells(1).Value = rtComentario.Text
            'End If

            'For t As Integer = 0 To grdcaptura.Rows.Count - 1
            '    If CStr(grdcaptura.Rows(t).Cells(0).Value.ToString) = "" Then
            '        grdcaptura.Rows(t).DefaultCellStyle.ForeColor = Color.DarkOrange
            '        grdcaptura.Rows(t).DefaultCellStyle.SelectionBackColor = Color.Pink
            '        grdcaptura.Rows(t).DefaultCellStyle.SelectionForeColor = Color.Black
            '    End If
            'Next
            rtComentario.Text = ""
            renglon = 0
            btnguardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub grdcaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim index As Integer = grdcaptura.CurrentRow.Index

        If celda.ColumnIndex = 10 Then
            codigoseleccionado = grdcaptura.Rows(index).Cells(0).Value.ToString
            rtComentario.Visible = True
            rtComentario.Text = grdcaptura.Rows(index).Cells(11).Value
            rtComentario.Focus.Equals(True)
        End If
    End Sub

    Private Sub pDocumento80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pDocumento80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 10, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_a As New Font("Lucida Sans Typewriter", 12, FontStyle.Bold)

        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim Logotipo As Drawing.Image = Nothing
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim tLogo As String = DatosRecarga("TipoLogo")

        Try
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

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("P R O C E D I M I E N T O", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString(cbonombre.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Lote" & cboLote.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Cantidad" & txtcantidad.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Codigo: " & txtCodigo.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Revision: " & txtRevision.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Aprobación: " & Format(dtpAprobación.Value, "yyyy-MM-dd"), fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("N° Cliente: " & txtnumcliente.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Cliente: " & cboCliente.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("SKU: " & txtSKU.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Recepción: " & Format(dtpFechaRecepcion.Value, "yyyy-MM-dd"), fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
        Catch ex As Exception

        End Try
    End Sub
End Class