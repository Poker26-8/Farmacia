Public Class frmConfigRecargas
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        If txtnumero.Text.Length <> 10 Then MsgBox("El número de télefono debe de ser de 10 digitos", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtnumero.Focus.Equals(True) : Exit Sub
        If txtusuario.Text = "" Then MsgBox("El usuario no puede ir vacio", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus.Equals(True) : Exit Sub
        If txtcontra.Text = "" Then MsgBox("La contraseña no puede ir vacia", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontra.Focus.Equals(True) : Exit Sub

        If lblid.Text <> "" Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Update loginrecargas set numero='" & txtnumero.Text & "', usuario='" & txtusuario.Text & "', password='" & txtcontra.Text & "' where id=" & lblid.Text & ""
                If cmd1.ExecuteNonQuery Then
                    varnumero = txtnumero.Text
                    varusuario = txtusuario.Text
                    varcontra = txtcontra.Text
                    MsgBox("Datos actualizados correctamente", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                Else
                    MsgBox("Error al actualizar los datos de la cuenta", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into loginrecargas(numero,usuario,password) values('" & txtnumero.Text & "','" & txtusuario.Text & "','" & txtcontra.Text & "')"
                If cmd1.ExecuteNonQuery Then
                    varnumero = txtnumero.Text
                    varusuario = txtusuario.Text
                    varcontra = txtcontra.Text
                    cnn1.Close()

                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Select * from Productos where Codigo='RECAR'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.Read Then
                        rd1.Close()
                        cnn1.Close()
                    Else
                        rd1.Close()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Insert into Productos(Codigo,Nombre,ProvPri,ProvEme,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Min,Max) values('RECARG','RECARGA TELEFONICA','DELSSCOM','DELSSCOM','SERV','SERV','SERV',1,1,'RECARGAS','RECARGAS',1,1)"
                        If cmd1.ExecuteNonQuery Then
                            MsgBox("Datos registrados correctamente", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
                        Else
                            MsgBox("Error al registrar los datos de la cuenta", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                            cnn1.Close()
                            Exit Sub
                        End If
                    End If
                    Exit Sub
                Else
                    MsgBox("Error al registrar los datos de la cuenta", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub frmConfigRecargas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from loginrecargas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtnumero.Text = rd1("numero").ToString
                txtusuario.Text = rd1("usuario").ToString
                txtcontra.Text = rd1("password").ToString
                lblid.Text = rd1("id").ToString
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtnumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumero.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            txtusuario.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcontra.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcontra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontra.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button25.Focus().Equals(True)
        End If
    End Sub
End Class