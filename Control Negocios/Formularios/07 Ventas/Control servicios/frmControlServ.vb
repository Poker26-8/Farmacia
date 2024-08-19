Public Class frmControlServ
    Private Sub frmControlServv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbousuario_DropDown(sender As Object, e As EventArgs) Handles cbousuario.DropDown
        cbousuario.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Alias from Usuarios where Puesto='RESPONSABLE'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbousuario.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbousuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbousuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpinicio.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpinicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpinicio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtptermino.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtptermino_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtptermino.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If txtproceso.Text = "" Then MsgBox("Es necesario escribir una descripción del procesos a realizar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtproceso.Focus().Equals(True) : Exit Sub
        If cbousuario.Text = "" Then MsgBox("Necesitas seleccionar un encargado del proceso.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbousuario.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Folio from control_servicios where Folio=" & lblfolio.Text & " and Codigo='" & txtcodigo.Text & "' AND Status=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("Este servicio ya cuenta con proceso activo.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If MsgBox("¿Deseas guardar la información para dar inicio a los procesos?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into control_servicios(Codigo,Nombre,Folio,Encargado,Inicio,Termino,Status,Comentario,Usuario,ComentarioVen) values('" & txtcodigo.Text & "','" & cbonombre.Text & "'," & lblfolio.Text & ",'" & cbousuario.Text & "','" & Format(dtpinicio.Value, "yyyy-MM-dd") & "','" & Format(dtptermino.Value, "yyyy-MM-dd") & "',0,'" & txtproceso.Text & "','" & lblusuario.Text & "','" & txtComentario.Text & "')"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Información guardada correctamente.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Me.Close()
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                Dim id_usu As Integer = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select Alias,IdEmpleado,Area from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString()
                        id_usu = rd1("IdEmpleado").ToString()

                        If rd1("Area") = "ADMINISTRACIÓN" Then
                            btnCambiar.Visible = True
                        Else
                            btnCambiar.Visible = False
                        End If

                    End If

                    Else
                    MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtusuario.SelectAll()
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

                btnguardar.Focus().Equals(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        Try

            If lblusuario.Text = "" Then MsgBox("Necesita proporcionar la contraseña del administrador") : txtusuario.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Folio FROM control_servicios WHERE Folio='" & lblfolio.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE control_servicios SET Encargado='" & cbousuario.Text & "' WHERE Folio='" & lblfolio.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Encargado actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class