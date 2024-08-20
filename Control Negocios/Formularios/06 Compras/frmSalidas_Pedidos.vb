Public Class frmSalidas_Pedidos
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Codigo from VentasDetalle where (Fecha between '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "') and LENGTH(Codigo)<7"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1(0).ToString()
                    Dim nombre As String = ""
                    Dim cantidad As Double = 0

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Nombre from Productos where Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            nombre = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select SUM(Cantidad) from VentasDetalle where Codigo='" & codigo & "' and (Fecha between '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "')"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cantidad = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close()

                    DataGridView1.Rows.Add(codigo, nombre, cantidad)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.Rows.Count = 0 Then MsgBox("No se encontraron registros que puedan se utilizados.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : Exit Sub
        Try
            frmPedidos.grdcaptura.Rows.Clear()

            cnn1.Close() : cnn1.Open()
            For DEKU As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim codigo As String = DataGridView1.Rows(DEKU).Cells(0).Value.ToString()
                Dim cantidad As Double = DataGridView1.Rows(DEKU).Cells(2).Value.ToString()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                End If
                rd1.Close()

            Next
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmSalidas_Pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class