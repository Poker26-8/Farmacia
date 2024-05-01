Public Class frmRepetirProducto
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmRepetirProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Codigo,Nombre,UVenta,Cantidad,Precio FROM comandas WHERE Codigo<>'xc3' order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdComandas.Rows.Add(rd1(0).ToString,
                        rd1(1).ToString,
                                         rd1(2).ToString,
                                         rd1(3).ToString,
                                         rd1(4).ToString
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

    Private Sub grdComandas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdComandas.CellDoubleClick
        Dim INDEX As Integer = grdComandas.CurrentRow.Index

        Dim codigo As String = grdComandas.Rows(INDEX).Cells(0).Value.ToString
        Dim descripcion As String = grdComandas.Rows(INDEX).Cells(1).Value.ToString
        Dim cantida As Double = grdComandas.Rows(INDEX).Cells(3).Value.ToString
        Dim precio As Double = grdComandas.Rows(INDEX).Cells(4).Value.ToString
        Dim total As Double = 0
        total = CDbl(cantida) * CDbl(precio)

        Dim nuevades As String = codigo & vbNewLine & descripcion
        frmAgregarProducto.grdCaptura.Rows.Add(codigo, nuevades, FormatNumber(cantida, 2), FormatNumber(precio, 2), FormatNumber(total, 2), "1", "", "0", "")
        frmAgregarProducto.lblTotalVenta.Text = frmAgregarProducto.lblTotalVenta.Text + CDbl(total)
        frmAgregarProducto.lblTotalVenta.Text = FormatNumber(frmAgregarProducto.lblTotalVenta.Text, 2)
    End Sub
End Class