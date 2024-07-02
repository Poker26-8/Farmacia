Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmProducirQ
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

            Dim REAL As String = ""
            Dim TEORICO As Double = 0

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
                            REAL = rd1("RealT").ToString
                            TEORICO = rd1("Teorico").ToString

                            If rd1("Grupo").ToString <> "SERVICIOS" Then
                                grdcaptura.Rows.Add(codigo,
                                                    nombre,
                                                    unidad,
                                                    FormatNumber(cantidad, 2),
                                                    FormatNumber(precio_com, 2),
                                                    FormatNumber(cantidad * precio_com, 2),
                                                    FormatNumber(existencia / multiplo, 2),
                                                    FormatNumber(TEORICO, 2),  'teorico
                                                    REAL, 'real
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
                                                    FormatNumber(TEORICO, 2), "", "",
                                                    REAL, "", "",'teorico
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
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cbonombre_SelectedValueChanged(cbonombre, New EventArgs())
            cbocodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcantidad.Focus.Equals(True)
        End If
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
            cboLote.Focus.Equals(True)

        End If
    End Sub

    Private Sub cboLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboLote.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_Click(sender As Object, e As EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_TabStopChanged(sender As Object, e As EventArgs) Handles txtcantidad.TabStopChanged
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
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

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index

        If grdcaptura.Rows.Count > 0 Then

            'If grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
            '    renglon = grdcaptura.CurrentRow.Index
            '    rtComentario.Visible = True
            '    rtComentario.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
            '    rtComentario.Focus().Equals(True)
            '    Exit Sub
            'End If

            cboCodigoI.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
            cboDescripcion.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
            txtUnidadI.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
            txtCantidadI.Text = grdcaptura.Rows(index).Cells(3).Value.ToString
            txtPrecioI.Text = grdcaptura.Rows(index).Cells(4).Value.ToString
            txtTotalI.Text = grdcaptura.Rows(index).Cells(5).Value.ToString
            txtExistencia.Text = grdcaptura.Rows(index).Cells(6).Value.ToString
            txtTeorico.Text = grdcaptura.Rows(index).Cells(7).Value.ToString
            txtReal.Text = grdcaptura.Rows(index).Cells(8).Value.ToString
            cboLoteS.Text = grdcaptura.Rows(index).Cells(9).Value.ToString
            dtpFechaLoteS.Value = grdcaptura.Rows(index).Cells(10).Value.ToString
            txtFase.Text = grdcaptura.Rows(index).Cells(11).Value
            txtComentario.Text = grdcaptura.Rows(index).Cells(12).Value

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
            txtCantidadI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCantidadI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim cantidad As Double = txtcantidad.Text
            Dim cantidadpro As Double = txtCantidadI.Text
            Dim teo As Double = 0

            teo = CDec(cantidad * 1000) * (cantidadpro / 100)
            txtTotalI.Text = CDbl(cantidadpro) * CDec(txtPrecioI.Text)
            txtTeorico.Text = FormatNumber(teo, 2)
            txtPrecioI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecioI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTotalI.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTotalI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalI.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTeorico.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTeorico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTeorico.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtReal.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtReal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboLoteS.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboLoteS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboLoteS.KeyPress
        e.KeyChar = UCase(e.KeyChar)
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
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboDescripcion.Text = "" Then Exit Sub
            If cboCodigoI.Text = "" Then Exit Sub

            grdcaptura.Rows.Add(cboCodigoI.Text,
                                cboDescripcion.Text,
                                txtunidad.Text,
                                FormatNumber(txtCantidadI.Text, 2),
                                FormatNumber(txtPrecioI.Text, 2),
                                FormatNumber(txtTotalI.Text, 2),
                                FormatNumber(txtExistencia.Text, 2),
                                FormatNumber(txtTeorico.Text, 2),
                                txtReal.Text,
                                cboLoteS.Text,
                                Format(dtpFechaLoteS.Value, "yyyy-MM-dd"),
                                txtFase.Text,
                                txtComentario.Text)

            cboCodigoI.Text = ""
            cboDescripcion.Text = ""
            txtUnidadI.Text = ""
            txtCantidadI.Text = "0.00"
            txtPrecioI.Text = "0.00"
            txtTotalI.Text = "0.00"
            txtExistencia.Text = "0.00"
            txtTeorico.Text = "0.00"
            txtReal.Text = ""
            cboLoteS.Text = ""
            dtpFechaLoteS.Value = Date.Now
            txtFase.Text = ""
            txtComentario.Text = ""
        End If

    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        Try
            cboDescripcion.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY nombre"
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

    Private Sub cboCodigoI_DropDown(sender As Object, e As EventArgs) Handles cboCodigoI.DropDown
        Try
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
        txtExistencia.Text = ""
        txtTeorico.Text = "0.00"
        txtReal.Text = ""
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
                Else
                    If cboLote.Text <> "" Then
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "INSERT INTO lotecaducidad(Codigo,Lote,Caducidad,Cantidad) VALUES('" & cbocodigo.Text & "','" & cboLote.Text & "','" & Format(dtpFechaLote.Value, "yyyy-MM-dd") & "'," & txtcantidad.Text & ")"
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
                    Dim teorico As Double = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                    Dim real As String = grdcaptura.Rows(luffy).Cells(8).Value
                    Dim loteinsumo As String = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                    Dim fechaloteinsumo As String = grdcaptura.Rows(luffy).Cells(10).Value.ToString
                    Dim fase As String = grdcaptura.Rows(luffy).Cells(11).Value
                    Dim comentario As String = grdcaptura.Rows(luffy).Cells(12).Value

                    'se busca el detalle de la produccion y se actualizara la existencia si fue modificada a la original
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM miprod WHERE Codigo='" & codinsumo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                            'se actualiza la existencia del insumo si fue modificado
                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "UPDATE miprod SET Cantidad=" & cantidadinsumo & ",Lote='" & loteinsumo & "',Fase='" & fase & "',Comentario='" & comentario & "',Teorico=" & teorico & ",RealT='" & real & "' WHERE Codigo='" & codinsumo & "'"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If
                    End If
                    rd2.Close()

                    Dim cantidadlotes As Double = 0
                    Dim nuevacoantidadlotes As Double = 0

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM lotecaducidad WHERE Codigo='" & codinsumo & "' AND Lote='" & loteinsumo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then


                            cantidadlotes = rd2("Cantidad").ToString
                            nuevacoantidadlotes = CDec(cantidadlotes) - CDec(cantidadinsumo)

                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "UPDATE lotecaducidad SET Cantidad=" & nuevacoantidadlotes & " WHERE Codigo='" & codinsumo & "' AND lote='" & loteinsumo & "'"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()

                        End If
                    Else
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "INSERT INTO lotecaducidad(Codigo,Lote,Caducidad,Cantidad) VALUES('" & codinsumo & "','" & loteinsumo & "','" & fechaloteinsumo & "'," & cantidadinsumo & ")"
                        cmd3.ExecuteNonQuery()

                        nuevacoantidadlotes = CDec(cantidadinsumo) - cantidadinsumo

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "UPDATE lotecaducidad SET Cantidad=" & nuevacoantidadlotes & " WHERE Codigo='" & codinsumo & "' AND lote='" & loteinsumo & "'"
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()

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

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM miprod WHERE CodigoP='" & cbocodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE miprod SET Comentario='" & rtComentario.Text & "' WHERE CodigoP='" & cbocodigo.Text & "'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                End If
                rd1.Close()
                cnn1.Close()



                Dim tamticket As Integer = 0
                Dim impresoratickett As String = ""

                tamticket = TamImpre()
                impresoratickett = ImpresoraImprimir()

                If cboImprimir.Text = "PDF" Then
                    Inserta_miprod()
                    PDF_MIPROD()
                End If

                If cboImprimir.Text = "TICKET" Then
                    If tamticket = "80" Then
                        pDocumento80.DefaultPageSettings.PrinterSettings.PrinterName = impresoratickett
                        pDocumento80.Print()
                    End If

                    If tamticket = "58" Then
                        pDocumento58.DefaultPageSettings.PrinterSettings.PrinterName = impresoratickett
                        pDocumento58.Print()
                    End If
                End If



                rtComentario.Text = ""
                rtComentario.Visible = False
                grdcaptura.Rows.Clear()
                txtnumcliente.Text = ""
                cboCliente.Text = ""
                txtCodigo.Text = ""
                txtSKU.Text = ""
                txtRevision.Text = ""
                dtpAprobación.Value = Date.Now
                dtpFechaRecepcion.Value = Date.Now

                cbocodigo.Text = ""
                cbonombre.Text = ""
                txtunidad.Text = ""
                txtcantidad.Text = ""
                txtcostod.Text = "0.00"
                cboLote.Text = ""
                dtpFechaLote.Value = Date.Now

                rtObservaciones.Text = ""
                txtPh.Text = ""
                txtOlor.Text = ""
                txtColor.Text = ""
                txtAspecto.Text = ""
            End If



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
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
                btnguardar.Focus.Equals(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnProceso_Click(sender As Object, e As EventArgs) Handles btnProceso.Click

        If cbocodigo.Text <> "" Then
            rtComentario.Visible = True
        End If

    End Sub

    Private Sub rtComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtComentario.KeyPress
        If AscW(e.KeyChar) = 0 Then
            rtComentario.Text = ""
            rtComentario.Visible = False
            Exit Sub
        End If

        If AscW(e.KeyChar) = Keys.Enter Then
            rtComentario.Visible = False
            btnguardar.Focus.Equals(True)
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
            e.Graphics.DrawString("Cantidad: " & txtcantidad.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Lote: " & cboLote.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Codigo: " & txtCodigo.Text, fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Revision: " & txtRevision.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Aprobación: " & Format(dtpAprobación.Value, "yyyy-MM-dd"), fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("N° Cliente: " & txtnumcliente.Text, fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("SKU: " & txtSKU.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Cliente: " & cboCliente.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Recepción: " & Format(dtpFechaRecepcion.Value, "yyyy-MM-dd"), fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("MATERIALES  Y  EQUIPOS", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            e.Graphics.DrawString("REACTIVO", fuente_b, Brushes.Black, 140, Y, sc)
            Y += 15
            e.Graphics.DrawString("FASE", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("LOTE", fuente_b, Brushes.Black, 34, Y)
            e.Graphics.DrawString("%(P/P)", fuente_b, Brushes.Black, 69, Y)
            e.Graphics.DrawString("P.teórico(g)", fuente_b, Brushes.Black, 119, Y)
            e.Graphics.DrawString("P.real(g)", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            For luffy As Integer = 0 To grdcaptura.Rows.Count - 1

                Dim reactivo As String = grdcaptura.Rows(luffy).Cells(1).Value.ToString
                Dim fase As String = grdcaptura.Rows(luffy).Cells(11).Value.ToString
                Dim lote As String = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                Dim cantidad As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                Dim teorico As Double = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                Dim real As String = grdcaptura.Rows(luffy).Cells(8).Value

                e.Graphics.DrawString(reactivo, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 70, Y)
                Y += 15
                e.Graphics.DrawString(fase, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                e.Graphics.DrawString(lote, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 35, Y)
                e.Graphics.DrawString(cantidad, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 95, Y)
                e.Graphics.DrawString(teorico, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 150, Y)
                e.Graphics.DrawString(real, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 270, Y, derecha)
                Y += 20
            Next
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("P R O C E D E M I E N T O", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11


            Dim caracteresPorLinea As Integer = 45
            Dim texto As String = rtComentario.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("O B S E R V A C I O N E S", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            Dim caracteresPorLinea1 As Integer = 45
            Dim texto1 As String = rtObservaciones.Text
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio1 += caracteresPorLinea1
            End While
            Y += 3
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("PROPIEDADES FISICAS Y QUIMICAS", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("PH: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtPh.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20
            e.Graphics.DrawString("OLOR: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtOlor.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20
            e.Graphics.DrawString("COLOR: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtColor.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20
            e.Graphics.DrawString("ASPECTO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtAspecto.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("REALIZO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(lblUsuario.Text, fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            e.Graphics.DrawString("FIRMA: ", fuente_b, Brushes.Black, 140, Y, sc)
            Y += 35
            e.Graphics.DrawString("____________________________________", fuente_b, Brushes.Black, 140, Y, sc)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
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

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumcliente.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtnumcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumcliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            txtCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSKU.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtSKU_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSKU.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtRevision.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtRevision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRevision.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpFechaRecepcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPh.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtOlor.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtOlor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOlor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtColor.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtColor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtAspecto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtAspecto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAspecto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            rtObservaciones.Focus.Equals(True)
        End If
    End Sub

    Private Sub rtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtObservaciones.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub pDocumento58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pDocumento58.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 9, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_a As New Font("Lucida Sans Typewriter", 10, FontStyle.Bold)

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
                    e.Graphics.DrawImage(Logotipo, 60, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 110, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("P R O C E D I M I E N T O", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString(cbonombre.Text, fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Cantidad: " & txtcantidad.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Lote: " & cboLote.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 11

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Codigo: " & txtCodigo.Text, fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Revision: " & txtRevision.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Aprobación: " & Format(dtpAprobación.Value, "yyyy-MM-dd"), fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("N° Cliente: " & txtnumcliente.Text, fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("SKU: " & txtSKU.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
            e.Graphics.DrawString("Cliente: " & cboCliente.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Recepción: " & Format(dtpFechaRecepcion.Value, "yyyy-MM-dd"), fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("MATERIALES  Y  EQUIPOS", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            e.Graphics.DrawString("REACTIVO", fuente_b, Brushes.Black, 140, Y, sc)
            Y += 15
            e.Graphics.DrawString("FASE", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("LOTE", fuente_b, Brushes.Black, 34, Y)
            e.Graphics.DrawString("%(P/P)", fuente_b, Brushes.Black, 69, Y)
            e.Graphics.DrawString("P.teórico(g)", fuente_b, Brushes.Black, 119, Y)
            e.Graphics.DrawString("P.real(g)", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            For luffy As Integer = 0 To grdcaptura.Rows.Count - 1

                Dim reactivo As String = grdcaptura.Rows(luffy).Cells(1).Value.ToString
                Dim fase As String = grdcaptura.Rows(luffy).Cells(11).Value.ToString
                Dim lote As String = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                Dim cantidad As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                Dim teorico As Double = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                Dim real As String = grdcaptura.Rows(luffy).Cells(8).Value

                e.Graphics.DrawString(reactivo, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 70, Y)
                Y += 15
                e.Graphics.DrawString(fase, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                e.Graphics.DrawString(lote, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 30, Y)
                e.Graphics.DrawString(cantidad, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 90, Y)
                e.Graphics.DrawString(teorico, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 140, Y)
                e.Graphics.DrawString(real, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 180, Y, derecha)
                Y += 20
            Next
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("P R O C E D E M I E N T O", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11


            Dim caracteresPorLinea As Integer = 45
            Dim texto As String = rtComentario.Text
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio += caracteresPorLinea
            End While
            Y += 3
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("O B S E R V A C I O N E S", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            Dim caracteresPorLinea1 As Integer = 45
            Dim texto1 As String = rtObservaciones.Text
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio1 += caracteresPorLinea1
            End While
            Y += 3
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("PROPIEDADES FISICAS Y QUIMICAS", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("PH: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtPh.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20
            e.Graphics.DrawString("OLOR: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtOlor.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20
            e.Graphics.DrawString("COLOR: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtColor.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20
            e.Graphics.DrawString("ASPECTO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtAspecto.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("REALIZO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(lblUsuario.Text, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("FIRMA: ", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 35
            e.Graphics.DrawString("____________________________________", fuente_b, Brushes.Black, 90, Y, sc)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnRegistro_Click(sender As Object, e As EventArgs) Handles btnRegistro.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM miprod WHERE CodigoP='" & cbocodigo.Text & "' AND DescripP='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    For luffy As Integer = 0 To grdcaptura.Rows.Count - 1

                        Dim codigo As String = grdcaptura.Rows(luffy).Cells(0).Value.ToString
                        Dim descripcion As String = grdcaptura.Rows(luffy).Cells(1).Value.ToString
                        Dim unidad As String = grdcaptura.Rows(luffy).Cells(2).Value.ToString
                        Dim cantidad As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                        Dim precio As Double = grdcaptura.Rows(luffy).Cells(4).Value.ToString
                        Dim total As Double = grdcaptura.Rows(luffy).Cells(5).Value.ToString
                        Dim EXISTENCIA As Double = 0
                        Dim teorico As Double = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                        Dim real As String = grdcaptura.Rows(luffy).Cells(8).Value
                        Dim lote As String = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                        Dim fechalote As String = ""
                        Dim fase As String = grdcaptura.Rows(luffy).Cells(11).Value.ToString



                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE miprod SET UVentaP='" & txtunidad.Text & "',CantidadP=" & txtcantidad.Text & ",UVenta='" & unidad & "',Cantidad=" & cantidad & ",Lote='" & lote & "',Precio=" & precio & ",Fase='" & fase & "',Teorico=" & teorico & ",RealT='" & real & "' WHERE CodigoP='" & cbocodigo.Text & "' AND DescripP='" & cbonombre.Text & "' AND Codigo='" & codigo & "' AND Descrip='" & descripcion & "'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    Next

                End If
            Else
                For luffy As Integer = 0 To grdcaptura.Rows.Count - 1

                    Dim codigo As String = grdcaptura.Rows(luffy).Cells(0).Value.ToString
                    Dim descripcion As String = grdcaptura.Rows(luffy).Cells(1).Value.ToString
                    Dim unidad As String = grdcaptura.Rows(luffy).Cells(2).Value.ToString
                    Dim cantidad As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                    Dim precio As Double = grdcaptura.Rows(luffy).Cells(4).Value.ToString
                    Dim total As Double = grdcaptura.Rows(luffy).Cells(5).Value.ToString
                    Dim EXISTENCIA As Double = 0
                    Dim teorico As Double = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                    Dim real As String = grdcaptura.Rows(luffy).Cells(8).Value
                    Dim lote As String = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                    Dim fechalote As String = ""
                    Dim fase As String = grdcaptura.Rows(luffy).Cells(11).Value.ToString



                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO miprod(CodigoP,DescripP,UVentaP,CantidadP,Codigo,Descrip,UVenta,Cantidad,Grupo,Lote,Precio,PrecioIVA,Fase,Teorico,RealT) VALUES('" & cbocodigo.Text & "','" & cbonombre.Text & "','" & txtunidad.Text & "'," & txtcantidad.Text & ",'" & codigo & "','" & descripcion & "','" & unidad & "'," & cantidad & ",'','" & lote & "'," & precio & ",0,'" & fase & "'," & teorico & ",'" & real & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                Next
            End If
            rd1.Close()
            cnn1.Close()


            Dim tamticket As Integer = 0
            Dim impresoratickett As String = ""

            tamticket = TamImpre()
            impresoratickett = ImpresoraImprimir()

            If tamticket = "80" Then
                pDocumento80.DefaultPageSettings.PrinterSettings.PrinterName = impresoratickett
                pDocumento80.Print()
            End If

            If tamticket = "58" Then
                pDocumento58.DefaultPageSettings.PrinterSettings.PrinterName = impresoratickett
                pDocumento58.Print()
            End If

            rtComentario.Text = ""
            grdcaptura.Rows.Clear()
            txtnumcliente.Text = ""
            cboCliente.Text = ""
            txtCodigo.Text = ""
            txtSKU.Text = ""
            txtRevision.Text = ""
            dtpAprobación.Value = Date.Now
            dtpFechaRecepcion.Value = Date.Now

            cbocodigo.Text = ""
            cbonombre.Text = ""
            txtunidad.Text = ""
            txtcantidad.Text = ""
            txtcostod.Text = "0.00"
            cboLote.Text = ""
            dtpFechaLote.Value = Date.Now

            rtObservaciones.Text = ""
            txtPh.Text = ""
            txtOlor.Text = ""
            txtColor.Text = ""
            txtAspecto.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dtpFechaRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFechaRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim fecha As String = Format(dtpFechaRecepcion.Value, "dd-MM-yyyy")
            Dim nuvf As String = ""

            nuvf = fecha.Replace("-", "")
            cboLote.Text = ""
            cboLote.Text = cboLote.Text & txtnumcliente.Text & nuvf & txtSKU.Text

            cbonombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub PDF_MIPROD()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New Produccion
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\")
        root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf"

        If File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf") Then
            File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = "C:\ControlNegociosPro\DL1.mdb"
            .DatabaseName = "C:\ControlNegociosPro\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        Try

            Dim procedimiento As String = ""
            procedimiento = rtComentario.Text.TrimEnd(vbCrLf.ToCharArray)

            Dim observaciones As String = ""
            observaciones = rtObservaciones.Text.TrimEnd(vbCrLf.ToCharArray)

            Dim nLogo As String = DatosRecarga("LogoG")
            Dim imagenURL As String = Convert.ToString(nLogo)
            Dim imagenBMP As iTextSharp.text.Image
            imagenBMP = iTextSharp.text.Image.GetInstance(imagenURL)
            imagenBMP.ScaleToFit(150.0F, 90.0F)
            imagenBMP.SpacingBefore = 20.0F
            imagenBMP.SpacingAfter = 10.0F
            imagenBMP.SetAbsolutePosition(410, 754)
            ' pdfDoc.Add(imagenBMP)

            'Los totales los va a mandar directos
            FileNta.SetDatabaseLogon("", "jipl22")
            FileNta.DataDefinition.FormulaFields("cliente").Text = "'" & cboCliente.Text & "'"
            FileNta.DataDefinition.FormulaFields("ncliente").Text = "'" & txtnumcliente.Text & "'"
            FileNta.DataDefinition.FormulaFields("codigo").Text = "'" & txtCodigo.Text & "'"
            FileNta.DataDefinition.FormulaFields("sku").Text = "'" & txtSKU.Text & "'"
            FileNta.DataDefinition.FormulaFields("lote").Text = "'" & cboLote.Text & "'"
            FileNta.DataDefinition.FormulaFields("revision").Text = "'" & txtRevision.Text & "'"
            FileNta.DataDefinition.FormulaFields("aprobacion").Text = "'" & Format(dtpAprobación.Value, "dd/MM/yyyy") & "'"
            FileNta.DataDefinition.FormulaFields("recepcion").Text = "'" & Format(dtpFechaRecepcion.Value, "dd/MM/yyyy") & "'"
            FileNta.DataDefinition.FormulaFields("ph").Text = "'" & txtPh.Text & "'"
            FileNta.DataDefinition.FormulaFields("olor").Text = "'" & txtOlor.Text & "'"
            FileNta.DataDefinition.FormulaFields("color").Text = "'" & txtColor.Text & "'"
            FileNta.DataDefinition.FormulaFields("aspecto").Text = "'" & txtAspecto.Text & "'"
            FileNta.DataDefinition.FormulaFields("procedimiento").Text = "'" & procedimiento & "'"
            FileNta.DataDefinition.FormulaFields("observacion").Text = "'" & observaciones & "'"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then

            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf")
            End If

            System.IO.File.Copy("C:\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\PRODUCCION\Produccion_" & txtCodigo.Text & ".pdf")
        End If
    End Sub
    Private Sub Inserta_miprod()

        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
                .runSp(a_cnn, "delete from miprod", sinfo)
                sinfo = ""


                For luffy As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(luffy).Cells(0).Value.ToString()
                    If codigo = "" Then GoTo doorcita

                    Dim descripcion As String = grdcaptura.Rows(luffy).Cells(1).Value.ToString
                    Dim unidad As String = grdcaptura.Rows(luffy).Cells(2).Value.ToString
                    Dim cantidad As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                    Dim precio As Double = grdcaptura.Rows(luffy).Cells(4).Value.ToString
                    Dim teorico As Double = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                    Dim real As String = grdcaptura.Rows(luffy).Cells(8).Value.ToString
                    Dim lote As String = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                    Dim fase As String = grdcaptura.Rows(luffy).Cells(11).Value.ToString

                    'Inserta en la tabla de miprod
                    If .runSp(a_cnn, "INSERT INTO miprod(CodigoP,DescripP,UVentaP,CantidadP,Codigo,Descrip,UVenta,Cantidad,Precio,Lote,Fase,Teorico,RealT) VALUES('" & cbocodigo.Text & "','" & cbonombre.Text & "','" & txtunidad.Text & "'," & txtcantidad.Text & ",'" & codigo & "','" & descripcion & "','" & unidad & "'," & cantidad & "," & precio & ",'" & lote & "','" & fase & "'," & teorico & ",'" & real & "')", sinfo) Then
                        sinfo = ""
                    Else
                        MsgBox(sinfo)
                    End If
                    Continue For
doorcita:
                Next

                a_cnn.Close()

            End If
        End With

    End Sub

    Private Sub frmProducirQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboImprimir.Text = "PDF"
    End Sub
End Class