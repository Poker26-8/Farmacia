Public Class frmElige_Proveedores
    Private Sub frmElige_Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Proveedores order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    DataGridView1.Rows.Add(rd1("Id").ToString(), rd1("Compania").ToString(), rd1("NComercial").ToString(), rd1("Telefono").ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            DataGridView1.Rows.Clear()

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Proveedores where Compania LIKE '%" & TextBox1.Text & "%'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        DataGridView1.Rows.Add(rd1("Id").ToString(), rd1("Compania").ToString(), rd1("NComercial").ToString(), rd1("Telefono").ToString())
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Proveedores order by Id"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        DataGridView1.Rows.Add(rd1("Id").ToString(), rd1("Compania").ToString(), rd1("NComercial").ToString(), rd1("Telefono").ToString())
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        frmPedidos.Crea_Pestaña(DataGridView1.CurrentRow.Cells(1).Value.ToString())

        Me.Close()
    End Sub
End Class