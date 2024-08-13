Public Class frmCitasD
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtTelefono.Text = ""
        dtpFecha.Value = Date.Now
        dtoHora.Text = "00:00:00"
        rtMotivo.Text = ""
        txtTelefono.Focus.Equals(True)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            Dim motivo As String = ""
            motivo = rtMotivo.Text.TrimEnd(vbCrLf.ToCharArray)

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO citas(Medico,Cliente,Telefono,Fecha,Hora,FechaC,Motivo) VALUES('" & lblMedicoC.Text & "','" & lblClienteC.Text & "','" & txtTelefono.Text & "','" & Format(dtpFecha.Value, "yyyy-MM-dd") & "','" & Format(dtoHora.Value, "HH:mm:ss") & "','" & Format(dtpFecha.Value, "yyyy-MM-dd HH:mm:ss") & "','" & motivo & "')"
            If cmd1.ExecuteNonQuery() Then
                MsgBox("La cita fue asignada correctamente", vbInformation + vbOKOnly, titulocentral)
            End If
            cnn1.Close()

            btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmCitasD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class