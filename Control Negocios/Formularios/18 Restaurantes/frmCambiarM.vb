Public Class frmCambiarM
    Private Sub frmCambiarM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        Try
            If cbomesa.Text = "" Then MsgBox("Necesita seleccionar la mesa de destino", vbInformation + vbOKOnly, titulorestaurante) : Exit Sub : cbomesa.Focus.Equals(True)
            Dim varconta As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Contabiliza FROM Mesa WHERE Nombre_mesa='" & lblmesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    varconta = rd1("Contabiliza").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If lblmesa.Text <> "" Then

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "UPDATE Comandas SET NMESA='" & cbomesa.Text & "' WHERE NMESA='" & lblmesa.Text & "'"
                cmd3.ExecuteNonQuery()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "UPDATE Comanda1 SET Nombre='" & cbomesa.Text & "' WHERE Nombre='" & lblmesa.Text & "'"
                cmd3.ExecuteNonQuery()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "UPDATE Rep_Comandas SET NMESA='" & cbomesa.Text & "' WHERE NMESA='" & lblmesa.Text & "'"
                cmd3.ExecuteNonQuery()
                cnn3.Close()

            Else
                MsgBox("Seleccione la mesa para el cambio", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
            lblmesa.Text = ""
            cbomesa.Text = ""
            btnSalir.PerformClick()
            frmMesas.btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class