Public Class frmcortemesero
    Private Sub frmcortemesero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbturno.Checked = True
    End Sub

    Private Sub rbperiodo_Click(sender As Object, e As EventArgs) Handles rbperiodo.Click
        If (rbperiodo.Checked) Then
            pperiodo.Visible = True
            dtpht.Visible = True
        End If
    End Sub

    Private Sub rbturno_Click(sender As Object, e As EventArgs) Handles rbturno.Click
        If (rbturno.Checked) Then
            pperiodo.Visible = False
            dtpht.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cbomesero_DropDown(sender As Object, e As EventArgs) Handles cbomesero.DropDown
        Try
            cbomesero.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Alias FROM usuarios WHERE Alias<>'' AND Puesto='MESERO' ORDER BY Alias"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomesero.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Try
            Dim totalmesero As Double = 0
            Dim formapagos As String = ""
            Dim meseros As String = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Mesero FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    meseros = rd1(0).ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT DISTINCT FormaPago FROM abonoi WHERE Concepto='ABONO' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' ORDER BY FormaPago"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then

                            formapagos = rd2(0).ToString

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT SUM(Monto) FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' AND Concepto='ABONO'"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then
                                    totalmesero = rd3(0).ToString

                                    MsgBox("el saldo total de " & meseros & " es de $" & totalmesero)

                                End If
                            End If
                            rd3.Close()

                        End If
                    Loop
                    rd2.Close()
                End If
            Loop
            rd1.Close()
            cnn1.Close()


            Dim TAMIMPRE As Integer = 0
            Dim tipopapel As String = ""

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try

    End Sub
End Class