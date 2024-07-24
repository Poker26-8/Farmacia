Public Class frmVehiculos

     Protected id_transporte As Integer = 0

    Private Sub frmVehiculos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpaceite_ant.Value = Date.Now
        dtpafinacion_ant.Value = Date.Now
        dtpaceite_prox.Value = Date.Now
        dtpafinacion_prox.Value = Date.Now
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        cbomodelo.Text = ""
        cbomarca.Text = ""
        txtplacas.Text = ""
        cboarea.Text = ""
        txtchofer.Text = ""
        txtseguros.Text = ""
        txtpoliza.Text = ""
        dtpvencimiento.Value = Date.Now
        txttelefono.Text = ""
        txtagente.Text = ""
        txtcontacto.Text = ""
        dtpafinacion_ant.Value = Date.Now
        dtpaceite_ant.Value = Date.Now
        dtpafinacion_prox.Value = Date.Now
        dtpaceite_prox.Value = Date.Now
        cbovencimiento2.Text = ""
        cbovencimiento1.Text = ""
        cbonocircula.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Transporte WHERE Placas='" & txtplacas.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = ""
                    If cmd2.ExecuteNonQuery Then

                    End If
                    cnn2.Close()

                End If
            Else
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Transporte() VALUES()"
                If cmd2.ExecuteNonQuery Then
                    MsgBox("Transporte agregado correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                End If
                cnn2.Close()
            End If
            cnn2.Close()
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class