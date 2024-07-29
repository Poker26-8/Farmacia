Public Class frmHisMesas
    Private Sub frmHisMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        optMesero.Checked = True
    End Sub

    Private Sub optTodos_Click(sender As Object, e As EventArgs) Handles optTodos.Click

        Dim m1 As Date = mcdesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mchasta.SelectionStart.ToShortDateString

        If (optTodos.Checked) Then

            Dim dato As String = ""

            cboDatos.Text = ""
            cboDatos.Visible = True
            grdDatos.Rows.Clear()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Mesa,Mesero,Cerro,FAbierto,HAbierto,FCerrado,HCerrado,Status FROM hismesa"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    If rd1("Status").ToString = 1 Then
                        dato = "MESA CERRADA"
                    Else
                        dato = "MESA ABIERTA"
                    End If

                    grdDatos.Rows.Add(rd1("Mesa").ToString,
                                      rd1("Mesero").ToString,
                                      rd1("Cerro").ToString,
                                      rd1("FAbierto").ToString,
                                      rd1("HAbierto").ToString,
                                      rd1("FCerrado").ToString,
                                      rd1("HCerrado").ToString,
                                      dato)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

        End If


    End Sub

    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown

        If (optMesero.Checked) Then
            Try
                cboDatos.Items.Clear()
                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText = "SELECT DISTINCT Mesero FROM hismesa WHERE Mesero<>'' ORDER BY Mesero"
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
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim m1 As Date = mcdesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mchasta.SelectionStart.ToShortDateString
        Try
            Dim dato As String = ""
            grdDatos.Rows.Clear()

            If (optMesero.Checked) Then


                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Mesa,Mesero,Cerro,FAbierto,HAbierto,FCerrado,HCerrado,Status FROM hismesa WHERE Mesero='" & cboDatos.Text & "' AND Fabierto BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        If rd1("Status").ToString = 1 Then
                            dato = "MESA CERRADA"
                        Else
                            dato = "MESA ABIERTA"
                        End If

                        grdDatos.Rows.Add(rd1("Mesa").ToString,
                                     rd1("Mesero").ToString,
                                     rd1("Cerro").ToString,
                                     rd1("FAbierto").ToString,
                                     rd1("HAbierto").ToString,
                                     rd1("FCerrado").ToString,
                                     rd1("HCerrado").ToString,
                                     dato)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class