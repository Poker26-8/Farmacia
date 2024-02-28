Public Class frmAgregarMesa
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try

            Dim TEMPORAL As Integer = 0
            Dim TIEMPO As Integer = 0

            If cktemporal.Checked = True Then
                TEMPORAL = 1
            Else
                TEMPORAL = 0
            End If

            If cbTiempo.Checked = True Then
                TIEMPO = 1
            Else
                TIEMPO = 0
            End If

            If (cktemporal.Checked) Then

                Dim idempleado As Integer = 0

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IdEmpleado FROM usuarios WHERE Alias='" & cbomesero.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        idempleado = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM mesa WHERE Nombre_mesa='" & cbomesa.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Mesa SET Temporal=" & TEMPORAL & ",Contabiliza=" & TIEMPO & ", Precio=" & txtprecio.Text & ", Ubicacion='" & cboubicacion.Text & "',Tipo='" & cbopara.Text & "',IdEmpleado=" & idempleado & ",Mesero='" & cbomesero.Text & "' WHERE Nombre_mesa='" & cbomesa.Text & "'"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE mesasxempleados SET IdEmpleado=" & idempleado & " WHERE Mesa='" & cbomesa.Text & "'"
                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Mesa actualizada correctamente", vbInformation + vbOKOnly, titulomensajes)
                            cnn2.Close()
                        End If



                    End If
                Else
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO Mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo) VALUES('" & cbomesa.Text & "'," & TEMPORAL & ",'Desocupada'," & TIEMPO & "," & txtprecio.Text & "," & IIf(txtOrden.Text = "", "0", txtOrden.Text) & ",''," & idempleado & ",'" & cbomesero.Text & "','" & cboubicacion.Text & "',0,0,'" & cbopara.Text & "')"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesasxempleados(Mesa,IdEmpleado,Grupo,Temporal) VALUES('" & cbomesa.Text & "'," & idempleado & ",'',1)"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Mesa agregada correctamente", vbInformation + vbOKOnly, titulorestaurante)
                        cnn2.Close()
                    End If


                End If
                    rd1.Close()
                cnn1.Close()

            Else

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & cbomesa.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Mesa SET Temporal=" & TEMPORAL & ",Contabiliza=" & TIEMPO & ", Precio=" & txtprecio.Text & ", Ubicacion='" & cboubicacion.Text & "',Tipo='" & cbopara.Text & "' WHERE Nombre_mesa='" & cbomesa.Text & "'"
                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Mesa actualizada correctamente", vbInformation + vbOKOnly, titulomensajes)
                        End If
                        cnn2.Close()

                    End If
                Else

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO Mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo) VALUES('" & cbomesa.Text & "'," & TEMPORAL & ",'Desocupada'," & TIEMPO & "," & txtprecio.Text & "," & IIf(txtOrden.Text = "", "0", txtOrden.Text) & ",'',0,'','" & cboubicacion.Text & "',0,0,'" & cbopara.Text & "')"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Mesa agregada correctamente", vbInformation + vbOKOnly, titulomensajes)
                    End If
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

            End If



            btnLimpiar.PerformClick()
            frmMesas.btnLimpiar.PerformClick()
            cbomesa.Focus.Equals(True)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try

    End Sub

    Private Sub cbomesa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbomesa.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboubicacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboubicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboubicacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbopara.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbopara_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbopara.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtprecio.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtOrden.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        cbomesa.Text = ""
        cboubicacion.Text = ""
        cbopara.Text = ""
        txtprecio.Text = ""
        txtOrden.Text = ""
        cbTiempo.Checked = False
        cktemporal.Checked = False
        lblmesero.Text = ""

    End Sub

    Private Sub cbomesa_DropDown(sender As Object, e As EventArgs) Handles cbomesa.DropDown
        Try
            cbomesa.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre_mesa FROM Mesa WHERE Nombre_mesa<>'' ORDER BY Nombre_mesa"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomesa.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboubicacion_DropDown(sender As Object, e As EventArgs) Handles cboubicacion.DropDown
        Try
            cboubicacion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Ubicacion FROM Mesa WHERE Ubicacion<>'' ORDER BY Ubicacion"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboubicacion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & cbomesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM Mesa WHERE Nombre_mesa='" & cbomesa.Text & "' AND Ubicacion='" & cboubicacion.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Mesa eliminada correctamente", vbInformation + vbOKOnly, titulomensajes)
                    End If
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

    Private Sub frmAgregarMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cbomesa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbomesa.SelectedValueChanged
        Try

            Dim tiempo As Integer = 0
            Dim temporal As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM mesa WHERE Nombre_mesa='" & cbomesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboubicacion.Text = rd1("Ubicacion").ToString
                    cbopara.Text = rd1("Tipo").ToString
                    txtprecio.Text = rd1("Precio").ToString
                    txtOrden.Text = rd1("Orden").ToString

                    temporal = rd1("Temporal").ToString
                    tiempo = rd1("Contabiliza").ToString

                    If temporal = 1 Then
                        cktemporal.Checked = True
                    Else
                        cktemporal.Checked = False
                    End If
                    If tiempo = 1 Then
                        cbTiempo.Checked = True
                    Else
                        cbTiempo.Checked = False
                    End If

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cktemporal_CheckedChanged(sender As Object, e As EventArgs) Handles cktemporal.CheckedChanged
        If (cktemporal.Checked) Then
            Me.Size = New Size(354, 373)
        Else
            Me.Size = New Size(354, 330)
        End If
    End Sub

    Private Sub cbomesero_DropDown(sender As Object, e As EventArgs) Handles cbomesero.DropDown
        Try
            cbomesero.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Alias FROM Usuarios WHERE Alias<>'' AND Puesto='MESERO' order by Alias"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomesero.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
End Class