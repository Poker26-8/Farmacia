Public Class frmRepCitas
    Private Sub frmRepCitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        optClientes.Checked = True

    End Sub

    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown
        Try
            cboDatos.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            If optClientes.Checked Then
                cmd5.CommandText = "SELECT DISTINCT Cliente FROM citas WHERE Cliente<>'' ORDER BY Cliente"
            End If
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDatos.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim m1 As Date = mcdesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mchasta.SelectionStart.ToShortDateString

        Dim fecha As Date = Nothing
        Dim fechac As String = ""
        Try

            If (optClientes.Checked) Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Medico,Cliente,Telefono,FechaC,Motivo FROM citas WHERE Cliente='" & cboDatos.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        fecha = rd1("FechaC").ToString
                        fechac = Format(fecha, "yyyy-MM-dd HH:mm:ss")

                        grdCaptura.Rows.Add(rd1("Medico").ToString,
                                            rd1("Cliente").ToString,
                                            rd1("Telefono").ToString,
                                            fechac,
                                            rd1("Motivo").ToString
                                            )
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub optClientes_Click(sender As Object, e As EventArgs) Handles optClientes.Click
        If (optClientes.Checked) Then
            grdCaptura.Rows.Clear()
            cboDatos.Text = ""
            optTodos.Checked = False
            cboDatos.Visible = True
        End If
    End Sub

    Private Sub optTodos_Click(sender As Object, e As EventArgs) Handles optTodos.Click
        If (optTodos.Checked) Then
            grdCaptura.Rows.Clear()
            cboDatos.Text = ""
            optClientes.Checked = False
            cboDatos.Visible = False

            Dim fecha As Date = Nothing
            Dim fechac As String = ""
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM citas"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        fecha = rd1("FechaC").ToString
                        fechac = Format(fecha, "yyyy-MM-dd HH:mm:ss")

                        grdCaptura.Rows.Add(rd1("Medico").ToString,
                                            rd1("Cliente").ToString,
                                            rd1("Telefono").ToString,
                                            fechac,
                                            rd1("Motivo").ToString
)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub
End Class