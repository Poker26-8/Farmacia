Public Class frmCatGrupos
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles dtpTermino.ValueChanged

    End Sub

    Private Sub Id_Grupo()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select MAX(Id) from Grupos"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtId.Text = IIf(rd1(0).ToString = "", 0, rd1(0).ToString()) + 1
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmCatGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Id_Grupo()
        cbogrupo.Focus().Equals(True)
    End Sub

    Private Sub cbogrupo_DropDown(sender As Object, e As EventArgs) Handles cbogrupo.DropDown
        cbogrupo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Nombre from Grupos order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbogrupo.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbogrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbogrupo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Grupos where Nombre='" & cbogrupo.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        txtId.Text = rd2("Id").ToString()
                        dtpInicio.Text = rd2("Inicio").ToString()
                        dtpTermino.Text = rd2("Termino").ToString()
                        txtcupo.Text = rd2("Cupo").ToString()
                    End If
                End If
                rd2.Close() : cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
            dtpInicio.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpInicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpInicio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpTermino.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpTermino_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpTermino.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcupo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcupo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Dim Inicio As String = Format(dtpInicio.Value, "HH:mm:ss")
        Dim Termino As String = Format(dtpTermino.Value, "HH:mm:ss")

        If cbogrupo.Text = "" Then MsgBox("Ingresa el nombre dle grupo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbogrupo.Focus().Equals(True) : Exit Sub
        If CDbl(txtcupo.Text) = 0 Then MsgBox("El cupo del grupo debe de ser mayor a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcupo.Focus().Equals(True) : Exit Sub

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Grupos where Nombre='" & cbogrupo.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MsgBox("El grupo ya existe.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                    txtId.Text = rd2("Id").ToString()
                    My.Application.DoEvents()

                    If MsgBox("¿Deseas actualizar los datos del grupo?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                        'Actualiza datos del grupo
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Grupos set Nombre='" & cbogrupo.Text & "', Inicio='" & Inicio & "', Termino='" & Termino & "', Cupo=" & txtcupo.Text & " where Id=" & rd2("Id").ToString()
                        If cmd1.ExecuteNonQuery Then
                            MsgBox("Datos de grupo actualizados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                        cnn1.Close()
                    End If
                End If
            Else
                If MsgBox("¿Deseas guardar los datos del grupo?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Grupos(Nombre,Inicio,Termino,Cupo) values('" & cbogrupo.Text & "','" & Inicio & "','" & Termino & "'," & txtcupo.Text & ")"
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("Datos de grupo guardados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    cnn1.Close()
                End If
            End If
            rd2.Close() : cnn2.Close()
            cnn1.Close()

            btnlimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        cbogrupo.Text = ""
        dtpInicio.Value = Now
        dtpTermino.Value = Now
        txtcupo.Text = "0"
        Id_Grupo()
        cbogrupo.Focus().Equals(True)
    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If cbogrupo.Text = "" Then MsgBox("Necesitas seleccionar un grupo para poder eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbogrupo.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas eliminar el grupo " & cbogrupo.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "delete from Grupos where Nombre='" & cbogrupo.Text & "'"
                If cmd2.ExecuteNonQuery Then
                    MsgBox("Grupo eliminado corretamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnlimpiar.PerformClick()
                End If
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
        End If
    End Sub
End Class