Public Class frmRegistros
    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Cliente FROM optica WHERE Cliente<>'' ORDER BY Cliente"
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
            Dim fecha As Date = Nothing
            Dim fechan As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM optica WHERE cliente='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    fecha = rd1("Fecha").ToString
                    fechan = Format(fecha, "yyyy-MM-dd HH:mm:ss")

                    grdCaptura.Rows.Add(rd1("Medico").ToString,
                                        rd1("EsfD").ToString,
                                        rd1("CilD").ToString,
                                        rd1("EjeD").ToString,
                                        rd1("AddD").ToString,
                                        rd1("EsfI").ToString,
                                        rd1("CilI").ToString,
                                        rd1("EjeI").ToString,
                                        rd1("AddI").ToString,
                                        rd1("DIP").ToString,
                                        rd1("Nota").ToString,
                                        fechan,
                                        rd1("Usuario").ToString
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
End Class