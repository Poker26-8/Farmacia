Public Class frmPercepciones
    Private Sub frmPercepciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim fila As Integer = 0 ' para matriz de grid
        DTHoy.Value = Date.Now ' para calculos necesarios de fecha 

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT atpc_id,atpc_descripcion FROM tipo_percepcion_contable ORDER BY atpc_descripcion"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdPercepcion.Rows.Add(rd1("atpc_id").ToString, rd1("atpc_descripcion").ToString)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmMenuNomina.Show()
    End Sub
End Class