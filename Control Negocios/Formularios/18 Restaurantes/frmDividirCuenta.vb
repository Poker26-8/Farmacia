Public Class frmDividirCuenta

    Public mesa As String = ""

    Private Sub frmDividirCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblmesa.Text = mesa

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id,Cantidad,Nombre FROM comandas WHERE Nmesa='" & lblmesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdmesa.Rows.Add(rd1(0).ToString,
                        rd1(1).ToString,
                                     rd1(2).ToString
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

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub grdmesa_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdmesa.CellDoubleClick

        Dim index As Integer = grdmesa.CurrentRow.Index

        Dim id As Double = 0
        Dim canti As Double = 0
        Dim nombre As String = ""

        id = grdmesa.Rows(index).Cells(0).Value.ToString
        canti = grdmesa.Rows(index).Cells(1).Value.ToString
        nombre = grdmesa.Rows(index).Cells(2).Value.ToString

        grdcomensal.Rows.Add(id, canti, nombre)
    End Sub
End Class