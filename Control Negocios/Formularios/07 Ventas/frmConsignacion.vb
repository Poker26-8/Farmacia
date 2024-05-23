Public Class frmConsignacion
    Private Sub cbofolio_DropDown(sender As Object, e As EventArgs) Handles cbofolio.DropDown
        Try
            cbofolio.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Folio from Ventas where Folio <> ''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cbofolio.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofolio.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from ventas where Folio=" & cbofolio.Text & ""
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtvendedor.Text = rd1("Usuario").ToString
                cbonombre.Text = rd1("Cliente").ToString
                txtdireccion.Text = rd1("Direccion").ToString
                GoTo perra
            Else
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
perra:
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from VentasDetalle where FOlio=" & cbofolio.Text & ""
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                grdcaptura.Rows.Add(rd1("Id".ToString), rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("Unidad").ToString, rd1("Cantidad").ToString, "0", rd1("Precio").ToString, rd1("Total").ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class