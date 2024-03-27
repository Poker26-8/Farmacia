Public Class frmFormaPago
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If cboMoneda.Text <> "" And txtValor.Text <> "" Then
                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM formaspago WHERE FormaPago='" & cboMoneda.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        rd1.Close()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Update FormasPago set Valor='" & txtValor.Text & "' where FormaPago='" & cboMoneda.Text & "'"
                        If cmd1.ExecuteNonQuery() Then
                            MsgBox("Forma de pago actualizada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                        End If
                    End If
                Else
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO formaspago(FormaPago,Valor) VALUES('" & cboMoneda.Text & "','" & txtValor.Text & "')"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Forma de pago agregada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                    End If
                    cnn2.Close()
                End If
                cnn1.Close()
                btnNuevo.PerformClick()
                Exit Sub
            Else

            End If



            If cboFormaPago.Text = "" Then MsgBox("Ingrese la forma de pago", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro") : cboFormaPago.Focused.Equals(True) : Exit Sub

            If cboFormaPago.Text <> "" Then

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM formaspago WHERE FormaPago='" & cboFormaPago.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("Ya cuentas con una forma de pago bajo este nombre.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close() : cnn1.Close() : Exit Sub
                    End If
                Else
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO formaspago(FormaPago) VALUES('" & cboFormaPago.Text & "')"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Forma de pago agregada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                    End If
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

            End If
            btnNuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboFormaPago.Text = ""
        txtId.Text = ""
        cboFormaPago.Focus.Equals(True)
        cboMoneda.Text = ""
        txtValor.Text = ""
    End Sub

    Private Sub cboFormaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboFormaPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboFormaPago_DropDown(sender As Object, e As EventArgs) Handles cboFormaPago.DropDown
        Try
            cboFormaPago.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' AND Valor=''"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboFormaPago.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboFormaPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFormaPago.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM formaspago WHERE FormaPago='" & cboFormaPago.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtId.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try

            If cboFormaPago.Text = "TARJETA" Or cboFormaPago.Text = "TRANSFERENCIA" Or cboFormaPago.Text = "SALDO FAVOR" Then MsgBox("El concepto de pago " & cboFormaPago.Text & " no puede ser eliminado ya que forma parte del catálogo indispensable de formas de pago en el sistema.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

            cnn3.Close() : cnn3.Open()
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Formaspago WHERE FormaPago='" & cboFormaPago.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM formaspago WHERE FormaPago='" & cboFormaPago.Text & "'"
                    If cmd3.ExecuteNonQuery Then
                        MsgBox("Forma de pago eliminada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                    End If
                    cnn3.Close()
                End If
            End If

            If cboMoneda.Text <> "" Then
                cnn3.Close() : cnn3.Open()
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Formaspago WHERE FormaPago='" & cboMoneda.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then Then
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "DELETE FROM formaspago WHERE FormaPago='" & cboMoneda.Text & "'"
                        If cmd3.ExecuteNonQuery Then
                            MsgBox("Forma de pago eliminada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                        End If
                        cnn3.Close()
                    End If
                End If
            End If
            btnNuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Sub cboMoneda_DropDown(sender As Object, e As EventArgs) Handles cboMoneda.DropDown
        Try
            cboMoneda.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct FormaPago from FormasPago where FormaPago<>'' and Valor<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboMoneda.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboMoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from FormasPago where FormaPago='" & cboMoneda.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtValor.Text = rd1("Valor").ToString
                txtId.Text = rd1("Id").ToString
            End If
            rd1.Close()
            cnn1.Close()
            txtValor.Focus.Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class