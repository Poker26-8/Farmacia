Public Class frmDepGrup
    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        Try
            cboNombre.Items.Clear()
            Dim soy As String = ""
            If lblTipo.Text = "Catalogo de Departamentos" Then
                soy = "Departamentos"
            ElseIf lblTipo.Text = "Catalogo de Grupos" Then
                soy = "Grupo"
            Else
                soy = ""
                Exit Sub
            End If
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If soy = "Departamentos" Then
                cmd1.CommandText = "Select distinct Nombre from Departamentos where Nombre<>''"
            ElseIf soy = "Grupo" Then
                cmd1.CommandText = "Select distinct Nombre from Grupo where Nombre<>''"
            Else
                Exit Sub
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Do While rd1.Read
                    cboNombre.Items.Add(rd1(0).ToString)
                Loop
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            Dim soy As String = ""
            If lblTipo.Text = "Catalogo de Departamentos" Then
                soy = "Departamentos"
            ElseIf lblTipo.Text = "Catalogo de Grupos" Then
                soy = "Grupo"
            Else
                soy = ""
                Exit Sub
            End If
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If soy = "Departamentos" Then
                cmd1.CommandText = "Select Id from Departamentos where Nombre='" & cboNombre.Text & "'"
            ElseIf soy = "Grupo" Then
                cmd1.CommandText = "Select Id from Grupo where Nombre='" & cboNombre.Text & "'"
            Else
                Exit Sub
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblid.Text = rd1(0).ToString
                Else
                    MsgBox("EL registro no existe, Revisa la información", vbInformation + vbOKOnly, "Delsscom Farmacias")
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim soy As String = ""
            If lblTipo.Text = "Catalogo de Departamentos" Then
                soy = "Departamentos"
            ElseIf lblTipo.Text = "Catalogo de Grupos" Then
                soy = "Grupo"
            Else
                soy = ""
                Exit Sub
            End If
            If lblid.Text <> "" Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If soy = "Departamentos" Then
                    cmd1.CommandText = "Update Departamentos set Nombre='" & cboNombre.Text & "' where Id=" & lblid.Text
                ElseIf soy = "Grupo" Then
                    cmd1.CommandText = "Update Grupo set Nombre='" & cboNombre.Text & "' where Id=" & lblid.Text
                Else
                    Exit Sub
                End If
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Registro Actualizado Correctamente", vbInformation + vbOKOnly, "Delsscom Farmacias")
                    btnNuevo.PerformClick()
                End If
                cnn1.Close()
            Else
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If soy = "Departamentos" Then
                    cmd1.CommandText = "Insert Into Departamentos(Nombre) values('" & cboNombre.Text & "')"
                ElseIf soy = "Grupo" Then
                    cmd1.CommandText = "Insert Into Grupo(Nombre) values('" & cboNombre.Text & "')"
                Else
                    Exit Sub
                End If
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Registro Agregado Correctamente", vbInformation + vbOKOnly, "Delsscom Farmacias")
                    btnNuevo.PerformClick()
                End If
                cnn1.Close()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboNombre.Text = ""
        lblid.Text = ""
    End Sub

    Private Sub frmDepGrup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If lblid.Text = "" Then
                MsgBox("Selecciona un Registro del catalogo para eliminarlo", vbCritical + vbOKOnly, "Delsscom Farmacias")
                Exit Sub
            End If
            Dim soy As String = ""
            If lblTipo.Text = "Catalogo de Departamentos" Then
                soy = "Departamentos"
            ElseIf lblTipo.Text = "Catalogo de Grupos" Then
                soy = "Grupo"
            Else
                soy = ""
                Exit Sub
            End If
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If soy = "Departamentos" Then
                cmd1.CommandText = "Delete from Departamentos where Id=" & lblid.Text
            ElseIf soy = "Grupo" Then
                cmd1.CommandText = "Delete from Grupo where Id=" & lblid.Text
            Else
                Exit Sub
            End If
            If cmd1.ExecuteNonQuery Then
                MsgBox("Registro Eliminado Correctamente", vbInformation + vbOKOnly, "Delsscom Farmacias")
                btnNuevo.PerformClick()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class