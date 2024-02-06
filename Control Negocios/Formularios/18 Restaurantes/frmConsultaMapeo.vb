Public Class frmConsultaMapeo

    Dim codigo As String = ""
    Dim descripcion As String = ""
    Dim unidad As String = ""
    Dim cantidad As Double = 0
    Dim precio As Double = 0
    Dim total As Double = 0
    Dim comensal As String = ""

    Dim totalcompra As Double = 0
    Private Sub frmConsultaMapeo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    codigo = rd1("Codigo").ToString
                    descripcion = rd1("Nombre").ToString
                    unidad = rd1("UVenta").ToString
                    cantidad = rd1("Cantidad").ToString
                    precio = rd1("Precio").ToString
                    total = rd1("Total").ToString
                    comensal = rd1("Comensal").ToString

                    totalcompra = totalcompra + CDec(total)

                    grdcaptura.Rows.Add(codigo, descripcion, unidad, cantidad, precio, total, comensal)

                End If
            Loop
            rd1.Close()
            cnn1.Close()

            lbltotal.Text = FormatNumber(totalcompra, 2)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class