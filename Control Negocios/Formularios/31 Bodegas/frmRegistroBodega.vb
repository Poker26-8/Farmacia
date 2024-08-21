Public Class frmRegistroBodega
    Private Sub frmRegistroBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim fechacatual As Date = Date.Now
        Dim f As String = ""
        f = Format(fechacatual, "yyyy-MM-dd")
        txtfactual.Text = f
        Dim fechasalida As DateTime = fechacatual.AddMonths(1)
        txtfpago.Text = Format(fechasalida, "yyyy-MM-dd")
    End Sub

    Private Sub frmRegistroBodega_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cboCliente.Focus.Equals(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboCliente.Text = ""
        txtid_cliente.Text = ""
        txtDireccion.Text = ""
        txttelefono.Text = ""
        txtCorreo.Text = ""
        txtNombre.Text = ""
        txtTelefonoC.Text = ""
        txtCorreoC.Text = ""
        grdCaptura.Rows.Clear()
        cboPeriodo.Text = ""
        txtPrecio.Text = "0.00"
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txttelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelefonoC.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelefonoC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefonoC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreoC.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreoC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreoC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            grdCaptura.Rows.Add(txtNombre.Text,
                                txtTelefonoC.Text,
                                txtCorreoC.Text)
            txtNombre.Text = ""
            txtTelefonoC.Text = ""
            txtCorreoC.Text = ""
            txtNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY nombre"
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

    Private Sub cboCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedValueChanged

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id,Telefono,Correo,Calle,Colonia,Delegacion,Entidad,CP FROM clientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtid_cliente.Text = rd1(0).ToString
                    txttelefono.Text = rd1(1).ToString
                    txtCorreo.Text = rd1(2).ToString

                    Dim direccion As String = ""

                    If rd1("Calle").ToString <> "" Then
                        direccion = direccion & rd1("Calle").ToString
                    End If
                    If rd1("Colonia").ToString <> "" Then
                        direccion = direccion & " " & rd1("Colonia").ToString
                    End If
                    If rd1("Delegacion").ToString <> "" Then
                        direccion = direccion & " " & rd1("Delegacion").ToString
                    End If
                    If rd1("Entidad").ToString <> "" Then
                        direccion = direccion & " " & rd1("Entidad").ToString
                    End If
                    If rd1("CP").ToString <> "" Then
                        direccion = direccion & " CP." & rd1("CP").ToString
                    End If
                    txtDireccion.Text = direccion
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