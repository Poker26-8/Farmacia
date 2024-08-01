Public Class frmClavesSat
    Private Sub frmClavesSat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtClavePro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClavePro.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            txtDescripcion.Focus.Equals(True)
        End If
    End Sub
    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtDescripcion.Text = ""
        txtClavePro.Text = ""
        txtClavePro.Focus.Equals(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtClavePro.Text = "" Then MsgBox("Ingrese la clave", vbInformation + vbOKOnly, titulocentral) : txtClavePro.Focus.Equals(True) : Exit Sub
            If txtDescripcion.Text = "" Then MsgBox("Ingrese la descripción", vbInformation + vbOKOnly, titulocentral) : txtDescripcion.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT ClaveProdSat FROM productosat WHERE ClaveProdSat='" & txtClavePro.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO productosat(ClaveProdSat,Descripcion,PalabrasSimilares) VALUES('" & txtClavePro.Text & "','" & txtDescripcion.Text & "','')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Clave agregada correctamente", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()

            End If
            rd1.Close()
            cnn1.Close()

            btnLimpiar.PerformClick()
            frmCambiaCodigo.Close()
            frmCambiaCodigo.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class