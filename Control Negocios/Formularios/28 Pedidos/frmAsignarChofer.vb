Public Class frmAsignarChofer
    Private Sub frmAsignarChofer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim codigo As String = ""
        Dim existencia As Double = 0
        Dim cantidadp As Double = 0
        Dim diferencia As Double = 0
        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM cotpeddet WHERE Tipo='PEDIDO' group by codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    codigo = rd1("Codigo").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Existencia FROM productos WHERE Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            existencia = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT SUM(Cantidad) FROM cotpeddet WHERE Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cantidadp = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()

                    diferencia = CDbl(existencia) - CDbl(cantidadp)

                    grdCaptura.Rows.Add(codigo, existencia, cantidadp, diferencia)

                End If
            Loop
            cnn2.Close()
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub
End Class