Public Class frmDetalleEntregado
    Private Sub frmDetalleEntregado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmEntregaPedidos.Enabled = True
    End Sub

    Private Sub frmDetalleEntregado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblFolio.Text = frmEntregaPedidos.cboFolio.Text
            If lblFolio.Text = "" Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from pedidosdet where Cantidad>CantidadE"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    DataGridView1.Rows.Add(rd1("NumPed").ToString, rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("Unidad").ToString, rd1("Cantidad").ToString, rd1("CantidadE").ToString, FormatNumber(rd1("Cantidad").ToString, 2) - CDec(FormatNumber(rd1("CantidadE").ToString, 2)), FormatNumber(rd1("Precio").ToString, 2), FormatNumber(CDec(rd1("Cantidad").ToString * rd1("Precio").ToString), 2), rd1("Proveedor").ToString)
                Loop
                rd1.Close()
                cnn1.Close()
            Else
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from pedidosven where NumPedido='" & lblFolio.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select * from pedidosvendet where Folio=" & rd1("Folio").ToString & ""
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        cnn3.Close()
                        cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "Select * from pedidosdet where NumPed='" & lblFolio.Text & "' and Codigo='" & rd2("Codigo").ToString & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.Read Then
                            grdCaptura.Rows.Add(rd1("Folio").ToString, rd3("Codigo").ToString, rd3("Nombre").ToString, rd3("Unidad").ToString, rd3("Cantidad").ToString, rd3("CantidadE").ToString, rd1("Cliente").ToString, rd2("Fecha").ToString, FormatNumber(rd2("Precio").ToString, 2), FormatNumber(rd2("Total").ToString, 2))
                        End If
                        rd3.Close()
                        cnn3.Close()
                    Loop
                    rd2.Close()
                    cnn2.Close()
                Loop
                rd1.Close()
                cnn1.Close()

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from pedidosdet where NumPed='" & lblFolio.Text & "' and Cantidad>CantidadE"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    DataGridView1.Rows.Add(rd1("NumPed").ToString, rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("Unidad").ToString, rd1("Cantidad").ToString, rd1("CantidadE").ToString, FormatNumber(rd1("Cantidad").ToString, 2) - CDec(FormatNumber(rd1("CantidadE").ToString, 2)), FormatNumber(rd1("Precio").ToString, 2), FormatNumber(CDec(rd1("Cantidad").ToString * rd1("Precio").ToString), 2), rd1("Proveedor").ToString)
                Loop
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
            cnn1.Close()
        End Try
    End Sub

End Class