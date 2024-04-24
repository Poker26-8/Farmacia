Public Class frmAsignarChofer2

    Dim direccion As String = ""
    Private Sub cboChofer_DropDown(sender As Object, e As EventArgs) Handles cboChofer.DropDown
        Try
            cboChofer.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Alias FROM usuarios WHERE Puesto='CHOFER'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboChofer.Items.Add(rd5(0).ToString)
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
            cmd5.CommandText = "SELECT DISTINCT Cliente FROM cotped WHERE Tipo='PEDIDO'"
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

    Private Sub cboPedido_DropDown(sender As Object, e As EventArgs) Handles cboPedido.DropDown
        Try
            cboPedido.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If cboCliente.Text = "" Then
                cmd5.CommandText = "SELECT DISTINCT Folio FROM cotped ORDER BY Folio"
            Else
                cmd5.CommandText = "SELECT DISTINCT Folio FROM cotped WHERE Cliente='" & cboCliente.Text & "' ORDER BY Folio"
            End If

            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboPedido.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboVehiculo_DropDown(sender As Object, e As EventArgs) Handles cboVehiculo.DropDown
        Try
            cboVehiculo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Placa FROM vehiculo WHERE Placa<>'' ORDER BY Placa"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboVehiculo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboChofer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboChofer.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboVehiculo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboVehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboVehiculo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCliente.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboPedido.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPedido.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpEntrega.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpEntrega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpEntrega.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            grdCaptura.Rows.Add(cboChofer.Text,
                                cboVehiculo.Text,
                                cboCliente.Text,
                                direccion,
                                cboPedido.Text,
                                dtpEntrega.Text
)

        End If
    End Sub

    Private Sub cboPedido_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPedido.SelectedValueChanged
        Try
            direccion = ""
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Direccion FROM cotped WHERE Folio='" & cboPedido.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    direccion = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub
End Class