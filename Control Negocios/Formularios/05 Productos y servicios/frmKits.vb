Public Class frmKits

      Private Sub CodBar()
            If cbodescripcion.Text = "" And cbocodigo.Text = "" Then Exit Sub
            If cbodescripcion.Text = "" Then
                  Try
                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Productos where CodBarra='" & cbocodigo.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                              If rd1.Read Then
                                    cbocodigo.Text = rd1("Codigo").ToString()
                                    cbodescripcion.Text = rd1("Nombre").ToString()
                                    txtcantidad.Focus().Equals(True)
                              End If
                        End If
                        rd1.Close() : cnn1.Close()
                  Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                  End Try
                  Exit Sub
            End If
            If cbocodigo.Text = "" Then
                  Try
                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Productos where CodBarra='" & cbodescripcion.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                              If rd1.Read Then
                                    cbocodigo.Text = rd1("Codigo").ToString()
                                    cbodescripcion.Text = rd1("Nombre").ToString()
                                    txtcantidad.Focus().Equals(True)
                              End If
                        End If
                        rd1.Close() : cnn1.Close()
                  Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                  End Try
            End If
      End Sub

      Private Sub cbocodigo_Click(sender As Object, e As System.EventArgs) Handles cbocodigo.Click
            cbocodigo.SelectionStart = 0
            cbocodigo.SelectionLength = Len(cbocodigo.Text)
      End Sub

      Private Sub cbocodigo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbocodigo.DropDown
            Dim codigo As String = ""
            Dim grupo As String = ""
            Try
                  cnn1.Close() : cnn1.Open()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select Codigo,Grupo from Productos where Nombre='" & cbodescripcion.Text & "'"
                  rd1 = cmd1.ExecuteReader
                  If rd1.HasRows Then
                        If rd1.Read Then
                              codigo = rd1(0).ToString()
                              grupo = rd1(1).ToString()
                        End If
                  End If
                  rd1.Close()
                  cbocodigo.Items.Clear()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select Codigo from Productos where Left(Codigo, 6)='" & codigo & "' and ProvRes=0"
                  rd1 = cmd1.ExecuteReader
                  Do While rd1.Read
                        If rd1.HasRows Then cbocodigo.Items.Add(
                            rd1(0).ToString()
                            )
                  Loop
                  rd1.Close()
                  cnn1.Close()
            Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                  cnn1.Close()
            End Try
      End Sub

      Private Sub cbocodigo_GotFocus(sender As Object, e As System.EventArgs) Handles cbocodigo.GotFocus
            cbocodigo.SelectionStart = 0
            cbocodigo.SelectionLength = Len(cbocodigo.Text)
      End Sub

      Private Sub cbocodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocodigo.KeyPress
            e.KeyChar = UCase(e.KeyChar)
            If AscW(e.KeyChar) = Keys.Enter Then
                  Try
                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Productos where Codigo='" & cbocodigo.Text & "' and ProvRes=0"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                              If rd1.Read Then
                                    cbodescripcion.Text = rd1("Nombre").ToString()
                                    txtunidad.Text = rd1("UVenta").ToString()
                              End If
                        End If
                        rd1.Close() : cnn1.Close()
                        If cbocodigo.Text <> "" Then txtcantidad.Focus().Equals(True) Else btnguardar.Focus().Equals(True)
                  Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                  End Try
                  CodBar()
            End If
      End Sub

      Private Sub cbodescripcion_DropDown(sender As System.Object, e As System.EventArgs) Handles cbodescripcion.DropDown
            cbodescripcion.Items.Clear()
            Try
                  cnn1.Close() : cnn1.Open()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select distinct Nombre from Productos where ProvRes=0"
                  rd1 = cmd1.ExecuteReader
                  Do While rd1.Read
                        If rd1.HasRows Then cbodescripcion.Items.Add(
                            rd1(0).ToString()
                            )
                  Loop
                  rd1.Close()
                  cnn1.Close()
            Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                  cnn1.Close()
            End Try
      End Sub

      Private Sub cbodescripcion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbodescripcion.KeyPress
            e.KeyChar = UCase(e.KeyChar)
            If AscW(e.KeyChar) = Keys.Enter Then
                  Try
                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Productos where Nombre='" & cbodescripcion.Text & "' and Provres=0"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                              If rd1.Read Then
                                    cbocodigo.Text = rd1("Codigo").ToString()
                                    cbocodigo.Tag = rd1("Grupo").ToString()
                                    txtunidad.Text = rd1("UVenta").ToString()
                                    txtprecio.Text = FormatNumber(rd1("PreEsp").ToString(), 2)

                                    cbocodigo.Focus().Equals(True)
                                    Exit Sub
                              End If
                        End If
                        rd1.Close() : cnn1.Close()
                  Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                  End Try
                  cbocodigo.Focus().Equals(True)
                  CodBar()
            End If
      End Sub

      Private Sub cbodescripcion_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbodescripcion.SelectedValueChanged
            Dim codigo As String = ""
            Dim grupo As String = ""
            Try
                  cnn1.Close() : cnn1.Open()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select Codigo,Grupo from Productos where Nombre='" & cbodescripcion.Text & "'"
                  rd1 = cmd1.ExecuteReader
                  If rd1.HasRows Then
                        If rd1.Read Then
                              codigo = rd1(0).ToString()
                              grupo = rd1(1).ToString()
                        End If
                  End If
                  rd1.Close()
                  cbocodigo.Items.Clear()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select Codigo from Productos where Left(Codigo, 6)='" & codigo & "' and ProvRes=0"
                  rd1 = cmd1.ExecuteReader
                  Do While rd1.Read
                        If rd1.HasRows Then cbocodigo.Items.Add(
                            rd1(0).ToString()
                            )
                  Loop
                  rd1.Close() : cnn1.Close()
            Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                  cnn1.Close()
            End Try
      End Sub

      Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
            cbonombre.Items.Clear() : grdcaptura.Rows.Clear()
            Try
                  cnn1.Close() : cnn1.Open()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select Nombre from Productos where ProvRes=1 and Departamento<>'SERVICIOS' order by Nombre"
                  rd1 = cmd1.ExecuteReader
                  Do While rd1.Read
                        If rd1.HasRows Then cbonombre.Items.Add(
                            rd1(0).ToString
                            )
                  Loop
                  rd1.Close() : cnn1.Close()
            Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                  cnn1.Close()
            End Try
      End Sub

      Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
            Dim codigo As String = ""
            Dim nombre As String = ""
            Dim unidad As String = ""
            Dim cantidad As Double = 0
            Dim precio As Double = 0
            Dim total As Double = 0

            e.KeyChar = UCase(e.KeyChar)
            If AscW(e.KeyChar) = Keys.Enter Then
                  If cbonombre.Text = "" Then btnnuevo.Focus().Equals(True) : Exit Sub
                  grdcaptura.Rows.Clear()
                  Try
                        cnn1.Close()
                        cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select * from Kits where Nombre='" & cbonombre.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                              codigo = rd1("Codigo").ToString
                              nombre = rd1("Descrip").ToString
                              unidad = rd1("UVenta").ToString
                              cantidad = rd1("Cantidad").ToString
                              precio = rd1("PPrecio").ToString
                              total = rd1("CTotal").ToString

                              grdcaptura.Rows.Add(
                                  codigo,
                                  nombre,
                                  unidad,
                                  cantidad,
                                  FormatNumber(precio, 2),
                                  FormatNumber(total, 2)
                                  )
                        Loop
                        rd1.Close()

                        If cbonombre.Text <> "" Then
                              cmd1 = cnn1.CreateCommand
                              cmd1.CommandText =
                                  "select PrecioVentaIVA,Codigo from Productos where Nombre='" & cbonombre.Text & "'"
                              rd1 = cmd1.ExecuteReader
                              If rd1.HasRows Then
                                    If rd1.Read Then
                                          txtpkit.Text = FormatNumber(rd1(0).ToString(), 2)
                                          txtcod.Text = rd1(1).ToString()
                                    End If
                              End If
                              rd1.Close()
                        End If
                        cnn1.Close()
                  Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                  End Try

                  If cbonombre.Text <> "" Then cbodescripcion.Focus().Equals(True) Else btnguardar.Focus().Equals(True)
            End If
      End Sub

      Private Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
            Dim codigo As String = ""
            Dim nombre As String = ""
            Dim unidad As String = ""
            Dim cantidad As Double = 0
            Dim precio As Double = 0
            Dim total As Double = 0
            grdcaptura.Rows.Clear()
            Try
                  cnn1.Close()
                  cnn1.Open()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select * from Kits where Nombre='" & cbonombre.Text & "'"
                  rd1 = cmd1.ExecuteReader
                  Do While rd1.Read
                        codigo = rd1("Codigo").ToString()
                        nombre = rd1("Descrip").ToString()
                        unidad = rd1("UVenta").ToString()
                        cantidad = rd1("Cantidad").ToString()
                        precio = rd1("PPrecio").ToString()
                        total = rd1("CTotal").ToString()

                        grdcaptura.Rows.Add(
                            codigo,
                            nombre,
                            unidad,
                            cantidad,
                            FormatNumber(precio, 2),
                            FormatNumber(total, 2)
                            )
                  Loop
                  rd1.Close()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select Codigo,PrecioVentaIVA from Productos where Nombre='" & cbonombre.Text & "'"
                  rd1 = cmd1.ExecuteReader
                  If rd1.HasRows Then
                        If rd1.Read Then
                              txtcod.Text = rd1(0).ToString()
                              txtpkit.Text = FormatNumber(rd1(1).ToString(), 2)
                        End If
                  End If
                  rd1.Close()
                  cnn1.Close()
            Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                  cnn1.Close()
            End Try
      End Sub

      Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
            txtcod.Text = ""
            cbonombre.Items.Clear()
            cbonombre.Text = ""
            cbodescripcion.Items.Clear()
            cbodescripcion.Text = ""
            cbocodigo.Items.Clear()
            cbocodigo.Text = ""
            txtunidad.Text = ""
            txtcantidad.Text = "0"
            txtprecio.Text = "0.00"
            txttotal.Text = "0.00"
            grdcaptura.Rows.Clear()
            txtpkit.Text = "0.00"
            cbonombre.Focus().Equals(True)
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
            Dim TotalesKit As Double = 0
            Dim PrecioProd As Double = 0
            If AscW(e.KeyChar) = Keys.Enter Then
                  PrecioProd = txtprecio.Text
                  If cbocodigo.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub
                  If cbodescripcion.Text = "" Then cbodescripcion.Focus().Equals(True) : Exit Sub
                  If txtcantidad.Text = "" Or CDec(txtcantidad.Text) = 0 Then txtcantidad.Text = "1"
                  If PrecioProd = 0 Then
                        MsgBox("El precio no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtprecio.Focus().Equals(True)
                        Exit Sub
                  End If

                  grdcaptura.Rows.Add(
                      cbocodigo.Text,
                      cbodescripcion.Text,
                      txtunidad.Text,
                      txtcantidad.Text,
                      FormatNumber(txtprecio.Text, 2),
                      FormatNumber(CDec(txtprecio.Text) * CDec(txtcantidad.Text), 2)
                      )
                  My.Application.DoEvents()

                  cbodescripcion.Text = ""
                  cbodescripcion.Items.Clear()
                  cbocodigo.Text = ""
                  txtunidad.Text = ""
                  txtcantidad.Text = "0"
                  txtprecio.Text = "0.00"
                  txttotal.Text = "0.00"
                  cbodescripcion.Focus().Equals(True)
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

      Private Sub txtpkit_Click(sender As Object, e As System.EventArgs) Handles txtpkit.Click
            txtpkit.SelectionStart = 0
            txtpkit.SelectionLength = Len(txtpkit.Text)
      End Sub

      Private Sub txtpkit_GotFocus(sender As Object, e As System.EventArgs) Handles txtpkit.GotFocus
            txtpkit.SelectionStart = 0
            txtpkit.SelectionLength = Len(txtpkit.Text)
      End Sub

      Private Sub txtpkit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpkit.KeyPress
            If AscW(e.KeyChar) = Keys.Enter Then
                  btnguardar.Focus().Equals(True)
            End If
      End Sub

    Private Sub txtprecio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim PrecioProd As Double = txtprecio.Text
            If cbocodigo.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub
            If cbodescripcion.Text = "" Then cbodescripcion.Focus().Equals(True) : Exit Sub
            If txtcantidad.Text = "" Or CDec(txtcantidad.Text) = 0 Then txtcantidad.Text = "1"
            If PrecioProd = 0 Then
                MsgBox("El precio no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtprecio.Focus().Equals(True)
                Exit Sub
            Else
                Call txtcantidad_KeyPress(txtcantidad, New KeyPressEventArgs(ChrW(Keys.Enter)))
            End If
        End If
    End Sub

    Private Sub btneliminar_Click(sender As System.Object, e As System.EventArgs) Handles btneliminar.Click
            If cbonombre.Text = "" Then MsgBox("Selecciona un kit para poder elimnarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

            If MsgBox("¿Deseas eliminar este kit de la base de datos?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                  Try
                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "delete from Kits where Cod='" & txtcod.Text & "'"
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set Cargado=0, PrecioVentaIVA=0 where Codigo='" & txtcod.Text & "'"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()
                  Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                  End Try
                  btnnuevo.PerformClick()
            End If
      End Sub

      Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
            If cbonombre.Text = "" Then MsgBox("Selecciona un kit para poder conformarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
            Try
                  cnn1.Close() : cnn1.Open()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select * from Productos where Codigo='" & txtcod.Text & "' and ProvRes=1 and Departamento<>'SERVICIOS'"
                  rd1 = cmd1.ExecuteReader
                  If Not rd1.HasRows Then
                        MsgBox("El kit no existe en la base de datos, selecciona uno del campo o regístralo en el catálogo de productos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        Exit Sub
                  Else
                        If rd1.Read Then
                              Dim precio_kit As Double = txtpkit.Text

                              If MsgBox("¿Deseas guardar los datos de este kit?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

                                    cnn2.Close() : cnn2.Open()

                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                        "update Productos set Cargado=0, PrecioVentaIVA=" & precio_kit & " where Codigo='" & txtcod.Text & "'"
                                    cmd2.ExecuteNonQuery()

                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                        "select * from Kits where Cod='" & txtcod.Text & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                          If rd2.Read Then
                                                cnn3.Close() : cnn3.Open()

                                                cmd3 = cnn3.CreateCommand
                                                cmd3.CommandText =
                                                    "delete from Kits where Cod='" & txtcod.Text & "'"
                                                cmd3.ExecuteNonQuery()
                                                cnn3.Close()
                                          End If
                                    End If
                                    rd2.Close()

                                    For i As Integer = 0 To grdcaptura.Rows.Count - 1
                                          Dim codigo As String = grdcaptura.Rows(i).Cells(0).Value.ToString
                                          Dim nombre As String = grdcaptura.Rows(i).Cells(1).Value.ToString
                                          Dim unidad As String = grdcaptura.Rows(i).Cells(2).Value.ToString
                                          Dim cantidad As Double = grdcaptura.Rows(i).Cells(3).Value.ToString
                                          Dim precio As Double = grdcaptura.Rows(i).Cells(4).Value.ToString
                                          Dim total As Double = grdcaptura.Rows(i).Cells(5).Value.ToString

                                          cmd2 = cnn2.CreateCommand
                                          cmd2.CommandText =
                                              "insert into Kits(Cod,Nombre,Codigo,Descrip,UVenta,Grupo,Cantidad,PPrecio,CTotal) values('" & txtcod.Text & "','" & cbonombre.Text & "','" & codigo & "','" & nombre & "','" & unidad & "',''," & cantidad & "," & precio & "," & total & ")"
                                          cmd2.ExecuteNonQuery()
                                    Next

                                    For a As Integer = 0 To grdcaptura.Rows.Count - 1
                                          Dim codigo As String = grdcaptura.Rows(a).Cells(0).Value.ToString
                                          Dim precio As Double = grdcaptura.Rows(a).Cells(4).Value.ToString
                                          cmd2 = cnn2.CreateCommand
                                          cmd2.CommandText =
                                              "update Productos set Cargado=0, PreEsp=" & precio & " where Codigo='" & codigo & "'"
                                          cmd2.ExecuteNonQuery()
                                    Next

                                    cnn2.Close()
                                    MsgBox("Kit registrado correctamente, recuerde que para venderlo deberá presionar la tecla F5 en su pantalla de ventas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                    btnnuevo.PerformClick()
                              End If
                        End If
                  End If
                  rd1.Close() : cnn1.Close()
            Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                  cnn1.Close()
            End Try
      End Sub

      Private Sub txtcantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcantidad.TextChanged
            If txtcantidad.Text = "" Or txtcantidad.Text = "." Then Exit Sub
            Dim temp As Double = 0
            Dim ATemp1, ATemp2, ATemp3, ATemp4, ATemp5 As Double
            Try
                  cnn1.Close()
                  cnn1.Open()

                  cmd1 = cnn1.CreateCommand
                  cmd1.CommandText =
                      "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                  rd1 = cmd1.ExecuteReader
                  If rd1.HasRows Then
                        If rd1.Read Then
                              If Not IsDBNull(rd1("CantLst1").ToString) And Not IsDBNull(rd1("CantLst2").ToString) Then
                                    If (CDec(txtcantidad.Text) >= CDec(rd1("CantLst1").ToString)) And (CDec(txtcantidad.Text) <= CDec(rd1("CantLst2").ToString)) Then
                                          txtprecio.Text = FormatNumber(rd1("PrecioVentaIVA").ToString, 2)
                                          temp = 1
                                    End If
                              End If
                              If Not IsDBNull(rd1("CantEsp1").ToString) And Not IsDBNull(rd1("CantEsp2").ToString) Then
                                    ATemp1 = rd1("CantEsp1").ToString
                                    If (CDec(txtcantidad.Text) >= CDec(rd1("CantEsp1").ToString)) And (CDec(txtcantidad.Text) <= CDec(rd1("CantEsp2").ToString)) Then
                                          txtprecio.Text = FormatNumber(rd1("PreEsp").ToString, 2)
                                          temp = 1
                                    End If
                              End If
                              If Not IsDBNull(rd1("CantMM1").ToString) And Not IsDBNull(rd1("CantMM2").ToString) Then
                                    ATemp2 = rd1("CantMM1").ToString
                                    If (CDec(txtcantidad.Text) >= CDec(rd1("CantMM1").ToString)) And (CDec(txtcantidad.Text) <= CDec(rd1("CantMM2").ToString)) Then
                                          txtprecio.Text = FormatNumber(rd1("PreMM").ToString, 2)
                                          temp = 1
                                    End If
                              End If
                              If Not IsDBNull(rd1("CantMay1").ToString) And Not IsDBNull(rd1("CantMay2").ToString) Then
                                    ATemp3 = rd1("CantMay1").ToString
                                    If (CDec(txtcantidad.Text) >= CDec(rd1("CantMay1").ToString)) And (CDec(txtcantidad.Text) <= CDec(rd1("CantMay2").ToString)) Then
                                          txtprecio.Text = FormatNumber(rd1("PreMay").ToString, 2)
                                          temp = 1
                                    End If
                              End If
                              If Not IsDBNull(rd1("CantMin1").ToString) And Not IsDBNull(rd1("CantMin2").ToString) Then
                                    ATemp4 = rd1("CantMin1").ToString
                                    If (CDec(txtcantidad.Text) >= CDec(rd1("CantMin1").ToString)) And (CDec(txtcantidad.Text) <= CDec(rd1("CantMin2").ToString)) Then
                                          txtprecio.Text = FormatNumber(rd1("PreMin").ToString, 2)
                                          temp = 1
                                    End If
                              End If
                              If ATemp1 <> 0 Or ATemp2 <> 0 Or ATemp3 <> 0 Or ATemp4 <> 0 Or ATemp5 <> 0 Then
                                    If temp = 0 Then
                                          MsgBox("El producto no existe en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                          txtprecio.SelectionStart = 0
                                          txtprecio.SelectionLength = Len(txtprecio.Text)
                                          Exit Sub
                                    End If
                              End If
                        End If
                  End If
                  rd1.Close()
                  cnn1.Close()

                  If txtcantidad.Text = "" Or txtprecio.Text = "" Or txtcantidad.Text = "." Then
                        Exit Sub
                  Else
                        txttotal.Text = CDec(txtcantidad.Text) * CDec(txtprecio.Text)
                        txttotal.Text = FormatNumber(txttotal.Text, 2)
                  End If
            Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                  cnn1.Close()
            End Try
      End Sub

      Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
            Dim index As Integer = grdcaptura.CurrentRow.Index

            'Pasa arriba
            cbocodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
            cbodescripcion.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
            txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
            txtcantidad.Text = grdcaptura.Rows(index).Cells(3).Value.ToString
            txtprecio.Text = grdcaptura.Rows(index).Cells(4).Value.ToString
            txttotal.Text = grdcaptura.Rows(index).Cells(5).Value.ToString

            grdcaptura.Rows.Remove(grdcaptura.Rows(index))
            cbodescripcion.Focus().Equals(True)
      End Sub

      Private Sub frmKits_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
            cbonombre.Focus().Equals(True)
      End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class