Public Class frmCambiarHab
    Private Sub cbohabitacion_DropDown(sender As Object, e As EventArgs) Handles cbohabitacion.DropDown

        Try
            cbohabitacion.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT N_Habitacion FROM habitacion WHERE N_Habitacion<>'' AND Estado<>'Ocupada' AND Estado<>'Ventilacion' AND Estado<>'Mantenimiento'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbohabitacion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub

    Private Sub cbohabitacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbohabitacion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnCambiar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmManejo.Show()
    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click

        Try
            Dim tipo As String = ""
            Dim precio As Double = 0
            Dim caracteristicas As String = ""

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT Tipo,Precio,Caracteristicas FROM habitacion WHERE N_Habitacion='" & cbohabitacion.Text & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    tipo = rd4(0).ToString
                    precio = rd4(1).ToString
                    caracteristicas = rd4(2).ToString
                End If
            End If
            rd3.Close()


            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE habitacion SET Estado='Desocupada' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
            cmd3.ExecuteNonQuery()

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE habitacion SET Estado='Ocupada' WHERE N_Habitacion='" & cbohabitacion.Text & "'"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE detallehotel SET Habitacion='" & cbohabitacion.Text & "',Tipo='" & tipo & "',Precio=" & precio & ",Caracteristicas='" & caracteristicas & "' WHERE Habitacion='" & lblhabitacion.Text & "'"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE asigpc SET Nombre='" & cbohabitacion.Text & "' WHERE Nombre='" & lblhabitacion.Text & "'"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE comanda1 SET Nombre='" & cbohabitacion.Text & "' WHERE Nombre='" & lblhabitacion.Text & "'"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE comandas SET Nmesa='" & cbohabitacion.Text & "' WHERE Nmesa='" & lblhabitacion.Text & "'"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE rep_comandas SET NMESA='" & cbohabitacion.Text & "' WHERE NMESA='" & lblhabitacion.Text & "'"
            cmd3.ExecuteNonQuery()
            cnn3.Close()
            cnn4.Close()
            MsgBox("Cambio de la habitación correctamente", vbInformation + vbOKOnly, titulohotelriaa)


            Me.Close()
            frmManejo.pHab.Controls.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub frmCambiarHab_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class