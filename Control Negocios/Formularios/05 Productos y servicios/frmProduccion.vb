Public Class frmProduccion

    Private Sub cbocodigo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbocodigo.DropDown
        cbocodigo.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct CodigoP from MiProd"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbocodigo.Items.Add(
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

    Private Sub cbocodigo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbocodigo.SelectedValueChanged
        grdcaptura.Rows.Clear()
        txtcostod.Text = "0.00"
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim unidad As String = ""
        Dim cantidad As Double = 0
        Dim precio_com As Double = 0
        Dim existencia As Double = 0
        Dim multiplo As Double = 0

        Dim MyTotal As Double = 0

        Try
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn1.Open()
            cnn2.Open()
            cnn3.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from MiProd where CodigoP='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbonombre.Text = rd1("DescripP").ToString
                    txtunidad.Text = rd1("UVentaP").ToString
                End If
            End If
            rd1.Close()

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select * from Productos where Codigo='" & rd1("Codigo").ToString & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        precio_com = rd3("PrecioCompra").ToString
                    End If
                End If
                rd3.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(rd1("Codigo").ToString, 6) & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        codigo = rd1("Codigo").ToString
                        nombre = rd1("Descrip").ToString
                        unidad = rd1("UVenta").ToString
                        cantidad = rd1("Cantidad").ToString
                        existencia = rd2("Existencia").ToString
                        multiplo = rd2("Multiplo").ToString

                        MyTotal = CDec(rd2("PrecioCompra").ToString) * cantidad

                        If rd1("Grupo").ToString <> "SERVICIOS" Then
                            grdcaptura.Rows.Add(
                                codigo,
                                nombre,
                                unidad,
                                FormatNumber(cantidad, 6),
                                FormatNumber(precio_com, 4),
                                FormatNumber(cantidad * precio_com, 2),
                                FormatNumber(existencia / multiplo, 2),
                                FormatNumber((existencia / multiplo) / cantidad, 2)
                                )
                        Else
                            grdcaptura.Rows.Add(
                                codigo,
                                nombre,
                                unidad,
                                FormatNumber(cantidad, 6),
                                FormatNumber(precio_com, 4),
                                FormatNumber(cantidad * precio_com, 2),
                                "",
                                ""
                                )
                        End If
                    End If
                End If
                rd2.Close()
                txtcostod.Text = CDec(txtcostod.Text) + MyTotal
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            txtcostod.Text = FormatNumber(txtcostod.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try
    End Sub

    Private Sub cbocodigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cbocodigo_SelectedValueChanged(cbocodigo, New EventArgs())
            txtcantidad.Focus().Equals(True)
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
        Dim MyTotal As Double = 0
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
                MyTotal += total
            Next
            txtcostod.Text = FormatNumber(MyTotal, 2)
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct DescripP from MiProd"
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
            Call cbonombre_SelectedValueChanged(cbonombre, New EventArgs())
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        grdcaptura.Rows.Clear()
        txtcostod.Text = "0.00"
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim unidad As String = ""
        Dim cantidad As Double = 0
        Dim precio_com As Double = 0
        Dim existencia As Double = 0
        Dim multiplo As Double = 0

        Dim MyTotal As Double = 0

        Try
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn1.Open()
            cnn2.Open()
            cnn3.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from MiProd where DescripP='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbocodigo.Text = rd1("CodigoP").ToString
                    txtunidad.Text = rd1("UVentaP").ToString
                End If
            End If
            rd1.Close()

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select * from Productos where Codigo='" & rd1("Codigo").ToString & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        precio_com = rd3("PrecioCompra").ToString
                    End If
                End If
                rd3.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(rd1("Codigo").ToString, 6) & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        codigo = rd1("Codigo").ToString
                        nombre = rd1("Descrip").ToString
                        unidad = rd1("UVenta").ToString
                        cantidad = rd1("Cantidad").ToString
                        existencia = rd2("Existencia").ToString
                        multiplo = rd2("Multiplo").ToString

                        MyTotal = CDec(rd2("PrecioCompra").ToString) * cantidad

                        If rd1("Grupo").ToString <> "SERVICIOS" Then
                            grdcaptura.Rows.Add(
                                codigo,
                                nombre,
                                unidad,
                                FormatNumber(cantidad, 6),
                                FormatNumber(precio_com, 4),
                                FormatNumber(cantidad * precio_com, 2),
                                FormatNumber(existencia / multiplo, 2),
                                FormatNumber((existencia / multiplo) / cantidad, 2)
                                )
                        Else
                            grdcaptura.Rows.Add(
                                codigo,
                                nombre,
                                unidad,
                                FormatNumber(cantidad, 6),
                                FormatNumber(precio_com, 4),
                                FormatNumber(cantidad * precio_com, 2),
                                "",
                                ""
                                )
                        End If
                    End If
                End If
                rd2.Close()
                txtcostod.Text = CDec(txtcostod.Text) + MyTotal
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            txtcostod.Text = FormatNumber(txtcostod.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try
    End Sub

    Private Sub btncostod_Click(sender As System.Object, e As System.EventArgs) Handles btncostod.Click
        If cbocodigo.Text = "" Or cbonombre.Text = "" Then MsgBox("Selecciona un producto para guadar su costo de produccción.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
        If grdcaptura.Rows.Count = 0 Then MsgBox("Procedimiento erróneo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
        Dim precio As Double = txtcostod.Text
        If MsgBox("¿Deseas guardar éste costo de producción para el producto?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Productos set Cargado=0, PrecioCompra=" & precio & " where Codigo='" & cbocodigo.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Costo directo de producción actualizado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        If txtcantidad.Text = "" Or txtcantidad.Text = "." Or Not IsNumeric(txtcantidad.Text) Or CDec(txtcantidad.Text) = 0 Then
            MsgBox("La cantidad debe de ser como mínimo '1' para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.Focus().Equals(True) : Exit Sub
        End If
        Try
            cnn1.Close()
            cnn1.Open()

            If txtcontraseña.Text <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'lblusuario.Text = rd1("Alias").ToString
                    End If
                Else
                    MsgBox("La contraseña es incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    txtcontraseña.SelectionStart = 0
                    txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
                    txtcontraseña.Focus().Equals(True)
                    Exit Sub
                End If
                rd1.Close()
            Else
                MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close()
                txtcontraseña.Focus().Equals(True)
                Exit Sub
            End If

            Dim existencia As Double = 0
            Dim cantidad As Double = txtcantidad.Text
            Dim multiplo As Double = 0
            Dim nueva_exis As Double = 0
            Dim precio_p As Double = 0

            If MsgBox("¿Deseas generar la producción de este producto?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existencia = rd1("Existencia").ToString
                        multiplo = rd1("Multiplo").ToString
                    End If

                    cantidad = CDec(txtcantidad.Text) * multiplo
                    nueva_exis = existencia + cantidad
                    precio_p = cantidad * CDbl(txtcostod.Text)
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Productos set Existencia=" & nueva_exis & ", PrecioCompra=" & precio_p & " where Codigo='" & cbocodigo.Text & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & cbocodigo.Text & "','" & cbonombre.Text & "','Producción'," & existencia & "," & cantidad & "," & nueva_exis & "," & precio_p & ",'" & Format(Date.Now, "yyyy- MM-dd HH:mm:ss") & "','','','','','','','')"
                cmd1.ExecuteNonQuery()

                For q As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codi As String = grdcaptura.Rows(q).Cells(0).Value.ToString
                    Dim nomb As String = grdcaptura.Rows(q).Cells(1).Value.ToString
                    Dim unid As String = grdcaptura.Rows(q).Cells(2).Value.ToString
                    Dim cant As Double = grdcaptura.Rows(q).Cells(3).Value.ToString
                    Dim prec As Double = grdcaptura.Rows(q).Cells(4).Value.ToString

                    Dim exis As Double = 0
                    Dim nueva_ex As Double = 0
                    Dim multi As Double = 0
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & codi & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            exis = rd1("Existencia").ToString
                            multi = rd1("Multiplo").ToString
                            nueva_ex = exis - (cant * multi)
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Productos set Cargado=0, CargadoInv=0, Existencia=" & nueva_ex & " where Codigo='" & codi & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codi & "','" & nomb & "','Descuento por producción'," & exis & "," & cant & "," & nueva_ex & "," & prec & ",'" & Format(Date.Now, "yyyy- MM-dd HH:mm:ss") & "','','','','','','','')"
                    cmd1.ExecuteNonQuery()
                Next

                'cmd1 = cnn1.CreateCommand
                'cmd1.CommandText =
                '    "insert into ComprasDetalle() values()"
                'cmd1.ExecuteNonQuery()

                cbocodigo.Items.Clear()
                cbocodigo.Text = ""
                cbonombre.Items.Clear()
                cbonombre.Text = ""
                txtunidad.Text = ""
                txtcantidad.Text = ""
                txtcostod.Text = "0.00"
                grdcaptura.Rows.Clear()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString) : cnn1.Close()
        End Try
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'lblusuario.Text = rd1("Alias").ToString
                        btnguardar.Focus().Equals(True)
                    End If
                Else
                    MsgBox("La contraseña es incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    txtcontraseña.SelectionStart = 0
                    txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
                    txtcontraseña.Focus().Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString) : cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        cbocodigo.Items.Clear()
        cbocodigo.Text = ""
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtunidad.Text = ""
        txtcantidad.Text = ""
        txtcostod.Text = "0.00"
        txtcontraseña.Text = ""
        grdcaptura.Rows.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class