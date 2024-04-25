Public Class frmVehP
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim STADO As Integer = 0

            If cboStatus.Text = "ACTIVO" Then
                STADO = 1
            Else
                STADO = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM vehiculo WHERE Placa='" & cboPlaca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.HasRows Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE vehiculo SET Marca='" & txtMarca.Text & "',Modelo='" & txtModelo.Text & "',NEconomico='" & txtEconomico.Text & "',StatusT=" & STADO & ""
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Vehiculo actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO vehiculo(Placa,Marca,Modelo,StatusT,NEconomico) VALUES('" & cboPlaca.Text & "','" & txtMarca.Text & "','" & txtModelo.Text & "'," & STADO & ",'" & txtEconomico.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Vehiculo agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
            btnNuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmVehP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboPlaca.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtEconomico.Text = ""
        cboStatus.Text = ""
    End Sub

    Private Sub cboPlaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPlaca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtModelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEconomico.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEconomico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEconomico.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboStatus.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboStatus.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboPlaca_DropDown(sender As Object, e As EventArgs) Handles cboPlaca.DropDown
        Try
            cboPlaca.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Placa FROM vehiculo WHERE Placa<>'' ORDER BY Placa"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboPlaca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboPlaca_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPlaca.SelectedValueChanged
        Try

            Dim activo As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM vehiculo WHERE Placa='" & cboPlaca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtMarca.Text = rd1("Marca").ToString
                    txtModelo.Text = rd1("Modelo").ToString
                    txtEconomico.Text = rd1("NEconomico").ToString
                    activo = rd1("StatusT").ToString

                    If activo = 1 Then
                        cboStatus.Text = "ACTIVO"
                    Else
                        cboStatus.Text = "INACTIVO"
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