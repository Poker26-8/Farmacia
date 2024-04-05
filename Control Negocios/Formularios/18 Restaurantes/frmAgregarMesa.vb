Public Class frmAgregarMesa

    Public IDUSU As Integer = 0
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try

            Dim TEMPORAL As Integer = 0
            Dim TIEMPO As Integer = 0
            Dim ORDEN As Integer = 0

            If cbTiempo.Checked = True Then
                TIEMPO = 1
            Else
                TIEMPO = 0
            End If

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT MAX(Orden) FROM mesa"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    ORDEN = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) + 1
                Else
                    ORDEN = "1"
                End If
            Else

                ORDEN = "1"
            End If
            rd2.Close()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & cbomesa.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Mesa SET Temporal=" & TEMPORAL & ",Contabiliza=" & TIEMPO & ", Precio=" & txtprecio.Text & ", Ubicacion='" & cboubicacion.Text & "',Tipo='" & cbopara.Text & "' WHERE Nombre_mesa='" & cbomesa.Text & "'"
                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Mesa actualizada correctamente", vbInformation + vbOKOnly, titulorestaurante)
                        End If
                        cnn2.Close()

                    End If
                Else

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO Mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo) VALUES('" & cbomesa.Text & "'," & TEMPORAL & ",'Desocupada'," & TIEMPO & "," & txtprecio.Text & "," & ORDEN & ",'',0,'','" & cboubicacion.Text & "',0,0,'" & cbopara.Text & "')"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesasxempleados(Mesa,IdEmpleado,Grupo,Temporal) VALUES('" & cbomesa.Text & "'," & IDUSU & ",'',0)"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Mesa agregada correctamente", vbInformation + vbOKOnly, titulorestaurante)
                    End If
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()


            btnLimpiar.PerformClick()
            frmMesas.btnLimpiar.PerformClick()
            cbomesa.Focus.Equals(True)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
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
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        cbomesa.Text = ""
        cboubicacion.Text = ""
        cbopara.Text = ""
        txtprecio.Text = ""
        cbTiempo.Checked = False

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

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM mesa WHERE Nombre_mesa='" & cbomesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboubicacion.Text = rd1("Ubicacion").ToString
                    cbopara.Text = rd1("Tipo").ToString
                    txtprecio.Text = rd1("Precio").ToString

                    tiempo = rd1("Contabiliza").ToString

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

End Class