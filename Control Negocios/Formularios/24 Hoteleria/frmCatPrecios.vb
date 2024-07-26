Public Class frmCatPrecios
    Private Sub frmCatPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtHoras.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtHoras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHoras.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecio1.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecio1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecio1.Text) Then
                txtPrecio2.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPrecio2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecio2.Text) Then
                txtPrecio3.Focus.Equals(True)
            End If
        End If
    End Sub


    Private Sub txtPrecio3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio3.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecio3.Text) Then
                txtPrecio4.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPrecio4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio4.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecio4.Text) Then
                txtPrecio5.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPrecio5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio5.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecio5.Text) Then
                btnGuardar.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre FROM detallehotelprecios WHERE Nombre='" & cboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE detallehotelprecios SET Horas=" & txtHoras.Text & ",PrecioA=" & txtPrecio1.Text & ",PrecioB=" & txtPrecio2.Text & ",PrecioC=" & txtPrecio3.Text & ",PrecioD=" & txtPrecio4.Text & ",PrecioE=" & txtPrecio5.Text & " WHERE Nombre='" & cboDescripcion.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Precio actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO detallehotelprecios(Nombre,Horas,PrecioA,PrecioB,PrecioC,PrecioD,PrecioE) VALUES('" & cboDescripcion.Text & "'," & txtHoras.Text & "," & txtPrecio1.Text & "," & txtPrecio2.Text & "," & txtPrecio3.Text & "," & txtPrecio4.Text & "," & txtPrecio5.Text & ")"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Precio agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
            btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboDescripcion.Text = ""
        txtHoras.Text = ""
        txtPrecio1.Text = "0.00"
        txtPrecio2.Text = "0.00"
        txtPrecio3.Text = "0.00"
        txtPrecio4.Text = "0.00"
        txtPrecio5.Text = "0.00"
        cboDescripcion.Focus.Equals(True)
    End Sub

    Private Sub cboDescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Horas,PrecioA,PrecioB,PrecioC,PrecioD,PrecioE FROM detallehotelprecios WHERE Nombre='" & cboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtHoras.Text = rd1("Horas").ToString
                    txtPrecio1.Text = rd1("PrecioA").ToString
                    txtPrecio2.Text = rd1("PrecioB").ToString
                    txtPrecio3.Text = rd1("PrecioC").ToString
                    txtPrecio4.Text = rd1("PrecioD").ToString
                    txtPrecio5.Text = rd1("PrecioE").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        Try
            cboDescripcion.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM detallehotelprecios WHERE Nombre<>'' ORDER BY Nombre"
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
End Class