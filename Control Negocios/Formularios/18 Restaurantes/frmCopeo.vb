Public Class frmCopeo
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtcodigo.Text = ""
        cboNombre.Text = ""
        txtMili.Text = ""
        txtCopas.Text = ""
        txtCodigoC.Text = ""
        cboNombreC.Text = ""
        grdCaptura.Rows.Clear()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()

        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Productos WHERE Departamento<>'SERVICIOS' AND Grupo<>'EXTRAS' AND Grupo<>'PROMOCIONES' AND Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboNombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboNombreC_DropDown(sender As Object, e As EventArgs) Handles cboNombreC.DropDown
        cboNombreC.Items.Clear()

        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Grupo='COPEO' AND Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboNombreC.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,Mililitros,Copas FROM productos WHERE Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1(0).ToString
                    txtMili.Text = rd1(1).ToString
                    txtCopas.Text = rd1(2).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombreC_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombreC.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo FROM productos WHERE Nombre='" & cboNombreC.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCodigoC.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombreC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombreC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboNombreC.Text <> "" Then
                grdCaptura.Rows.Add(txtCodigoC.Text, cboNombreC.Text)

                cboNombreC.Text = ""
                txtCodigoC.Text = ""

            End If
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboNombreC.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If grdCaptura.Rows.Count = 0 Then MsgBox("Necesita tener productos seleccionados", vbInformation + vbOKOnly, titulorestaurante) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM copeos WHERE CodigoAlpha='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else

                For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                    Dim codigoc As String = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO copeos(CodigoAlpha,Nombre,Codigo,Mililitros,Copas) VALUES('" & txtcodigo.Text & "','" & cboNombre.Text & "','" & codigoc & "'," & txtMili.Text & "," & txtCopas.Text & ")"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                Next
                MsgBox("Produto asignado correctamente", vbInformation + vbOKOnly, titulorestaurante)

            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class