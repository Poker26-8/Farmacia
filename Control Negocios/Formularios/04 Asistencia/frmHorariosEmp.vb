Public Class frmHorariosEmp

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Usuarios order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboNombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmHorariosEmp_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub frmHorariosEmp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        If cboNombre.Text = "" Then Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Area,Puesto,IdEmpleado from Usuarios where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtarea.Text = rd1("Area").ToString()
                    txtpuesto.Text = rd1("Puesto").ToString()
                    txtid.Text = rd1("IdEmpleado").ToString()
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,TE,TS from Horarios where IdUsu=" & txtid.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Monday").ToString() = True Then
                        chkLunes.Checked = True
                    Else
                        chkLunes.Checked = False
                    End If
                    If rd1("Tuesday").ToString() = True Then
                        chkMartes.Checked = True
                    Else
                        chkMartes.Checked = False
                    End If
                    If rd1("Wednesday").ToString() = True Then
                        chkMiercoles.Checked = True
                    Else
                        chkMiercoles.Checked = False
                    End If
                    If rd1("Thursday").ToString() = True Then
                        chkJueves.Checked = True
                    Else
                        chkJueves.Checked = False
                    End If
                    If rd1("Friday").ToString() = True Then
                        chkViernes.Checked = True
                    Else
                        chkViernes.Checked = False
                    End If
                    If rd1("Saturday").ToString() = True Then
                        chkSabado.Checked = True
                    Else
                        chkSabado.Checked = False
                    End If
                    If rd1("Sunday").ToString() = True Then
                        chkDomingo.Checked = True
                    Else
                        chkDomingo.Checked = False
                    End If
                    dtpEntrada.Value = FormatDateTime(Date.Now, DateFormat.ShortDate) & " " & rd1("HE").ToString()
                    dtpSalida.Value = FormatDateTime(Date.Now, DateFormat.ShortDate) & " " & rd1("HS").ToString()
                    txtEntrada.Text = rd1("TE").ToString()
                    txtSalida.Text = rd1("TS").ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
            dtpEntrada.Focus().Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub dtpEntrada_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpEntrada.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpSalida.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpSalida_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpSalida.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEntrada.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtEntrada_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEntrada.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSalida.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtSalida_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalida.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        cboNombre.Items.Clear()
        cboNombre.Text = String.Empty
        txtarea.Text = String.Empty
        txtpuesto.Text = String.Empty
        txtid.Text = String.Empty
        chkLunes.Checked = False
        chkMartes.Checked = False
        chkMiercoles.Checked = False
        chkJueves.Checked = False
        chkViernes.Checked = False
        chkSabado.Checked = False
        chkDomingo.Checked = False
        dtpEntrada.Value = Now
        dtpSalida.Value = Now
        txtEntrada.Text = String.Empty
        txtSalida.Text = String.Empty
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cboNombre.Text = "" Then MsgBox("Selecciona un usuario para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If txtid.Text = "" Then MsgBox("Selecciona un usuario para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub

        Dim existe As Boolean = False
        Dim mensaje As String = String.Empty

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IdUsu from Horarios where IdUsu=" & txtid.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    existe = True
                Else
                    existe = False
                End If
            Else
                existe = False
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            If (existe) Then
                cmd1.CommandText =
                    "update Horarios set Monday=" & IIf(chkLunes.Checked, 1, 0) & ", Tuesday=" & IIf(chkMartes.Checked, 1, 0) & ", Wednesday=" & IIf(chkMiercoles.Checked, 1, 0) & ", Thursday=" & IIf(chkJueves.Checked, 1, 0) & ", Friday=" & IIf(chkViernes.Checked, 1, 0) & ", Saturday=" & IIf(chkSabado.Checked, 1, 0) & ", Sunday=" & IIf(chkDomingo.Checked, 1, 0) & ", HE='" & Format(dtpEntrada.Value, "HH:mm:ss") & "', HS='" & Format(dtpSalida.Value, "HH:mm:ss") & "', TE=" & txtEntrada.Text & ", TS=" & txtSalida.Text & " where IdUsu=" & txtid.Text
                mensaje = "Horarios de usuario actualizados."
            Else
                cmd1.CommandText =
                    "insert into Horarios(IdUsu,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,HE,HS,TE,TS) values(" & txtid.Text & "," & IIf(chkLunes.Checked, 1, 0) & "," & IIf(chkMartes.Checked, 1, 0) & "," & IIf(chkMiercoles.Checked, 1, 0) & "," & IIf(chkJueves.Checked, 1, 0) & "," & IIf(chkViernes.Checked, 1, 0) & "," & IIf(chkSabado.Checked, 1, 0) & "," & IIf(chkDomingo.Checked, 1, 0) & ",'" & Format(dtpEntrada.Value, "HH:mm:ss") & "','" & Format(dtpSalida.Value, "HH:mm:ss") & "'," & txtEntrada.Text & "," & txtSalida.Text & ")"
                mensaje = "Horarios de usuario registrados."
            End If
            If cmd1.ExecuteNonQuery Then
                MsgBox(mensaje, vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnNuevo.PerformClick()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If txtid.Text = "" Then MsgBox("Selecciona un usuario para eliminar sus horarios.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If cboNombre.Text = "" Then MsgBox("Selecciona un empleado para eliminar sus horarios.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub

        Try
            If MsgBox("¿Deseas eliminar los horarios de éste usuario." & vbNewLine & "Esta acción no se puede deshacer." & vbNewLine & vbNewLine & "Importante: Sólo se eliminarán los horarios del usuario más no su registro y permisos.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from Horarios where IdUsu=" & txtid.Text
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Horarios de usuario eliminados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnNuevo.PerformClick()
                End If
                cnn1.Close()
            Else
                cboNombre.Focus().Equals(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
End Class