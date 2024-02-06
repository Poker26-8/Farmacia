Public Class frmVehiculos

     Protected id_transporte As Integer = 0

     Private Sub frmVehiculos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
          dtpaceite_ant.Value = Date.Now
          dtpafinacion_ant.Value = Date.Now
          dtpaceite_prox.Value = Date.Now
          dtpafinacion_prox.Value = Date.Now
     End Sub

     Private Sub cbomodelo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbomodelo.DropDown
          cbomodelo.Items().Clear()
          Try
               cnn1.Close()
               cnn1.Open()

               cmd1 = cnn1.CreateCommand
               cmd1.CommandText =
                    "select Modelo from Transporte order by Modelo"
               rd1 = cmd1.ExecuteReader
               Do While rd1.Read
                    If rd1.HasRows Then
                         cbomodelo.Items().Add(
                              rd1(0).ToString
                              )
                    End If
               Loop
               rd1.Close()
               cnn1.Close()
          Catch ex As Exception
               MessageBox.Show(ex.ToString)
               cnn1.Close()
          End Try
     End Sub

     Private Sub cbomodelo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbomodelo.KeyPress
          If AscW(e.KeyChar) = Keys.Enter Then
               cbomarca.Focus().Equals(True)
          End If
     End Sub

    Private Sub cbomodelo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbomodelo.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select * from Transporte where Modelo='" & cbomodelo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_transporte = rd1("Id").ToString
                    cbomarca.Text = rd1("Marca").ToString
                    txtplacas.Text = rd1("Placas").ToString
                    cboarea.Text = rd1("Area").ToString
                    txtchofer.Text = rd1("Chofer").ToString
                    txtseguros.Text = rd1("Seguro").ToString
                    txtpoliza.Text = rd1("Poliza").ToString
                    dtpvencimiento.Value = rd1("VenceSeguro").ToString
                    txttelefono.Text = rd1("Contacto_Seguro").ToString
                    txtagente.Text = rd1("Agente").ToString
                    txtcontacto.Text = rd1("Contacto_Agente").ToString
                    cbovencimiento1.Text = rd1("Verifica1").ToString
                    cbovencimiento2.Text = rd1("Verifica2").ToString
                    cbonocircula.Text = rd1("NoCircula").ToString
                    dtpafinacion_ant.Value = rd1("Afina_Ant").ToString
                    dtpaceite_ant.Value = rd1("Aceite_Ant").ToString
                    dtpafinacion_prox.Value = rd1("Afina_Prox").ToString
                    dtpaceite_prox.Value = rd1("Aceite_Prox").ToString
                End If
            Else
                MsgBox("Datos erróneos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
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