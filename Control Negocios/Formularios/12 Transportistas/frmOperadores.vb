Public Class frmOperadores
    Private Sub frmOperadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboNombre.Focus.Equals(True)
    End Sub
    Private Sub frmOperadores_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        Try
            cboNombre.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM porteoperador WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboNombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtRfc.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtRfc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRfc.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtLicencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtLicencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLicencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSueldo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtSueldo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtSueldo.Text) Then
                txtfacebook.Focus.Equals(True)
            Else
                txtSueldo.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub txtfacebook_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfacebook.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCp.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCp.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtTelefono.Text) Then
                txtCalle.Focus.Equals(True)
            Else
                txtTelefono.Text = ""
            End If

        End If
    End Sub

    Private Sub txtCalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalle.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNumExt.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNumExt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumExt.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNumInt.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNumInt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumInt.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtColonia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtColonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColonia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMunicipio.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMunicipio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMunicipio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEstado.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEstado.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        cboNombre.Focus.Equals(True)
        cboNombre.Text = ""
        txtRfc.Text = ""
        txtLicencia.Text = ""
        txtSueldo.Text = "0.00"
        txtfacebook.Text = ""
        txtCp.Text = ""
        txtTelefono.Text = ""
        txtCalle.Text = ""
        txtNumExt.Text = ""
        txtNumInt.Text = ""
        txtColonia.Text = ""
        txtMunicipio.Text = ""
        txtEstado.Text = ""
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea cerra este formulario?", vbOKCancel + vbOKOnly, titulocentral) = MsgBoxResult.Ok Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If MsgBox("¿Desea guardar los datos de Operador?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then
                Exit Sub
            End If

            If cboNombre.Text = "" Then MsgBox("Ingrese el nombre del operador", vbInformation + vbOKOnly, titulocentral) : cboNombre.Focus.Equals(True) : Exit Sub
            If txtRfc.Text = "" Then MsgBox("Ingrese el RFC del operador", vbInformation + vbOKOnly, titulocentral) : txtRfc.Focus.Equals(True) : Exit Sub
            If txtLicencia.Text = "" Then MsgBox("Ingrese la licencia del operador", vbInformation + vbOKOnly, titulocentral) : txtLicencia.Focus.Equals(True) : Exit Sub
            If txtSueldo.Text = "" Then MsgBox("Ingrese el sueldo del Operador", vbInformation + vbOKOnly, titulocentral) : txtSueldo.Focus() : Exit Sub
            If txtCp.Text = "" Then MsgBox("Ingrese el CP del Operador", vbInformation + vbOKOnly, titulocentral) : txtCp.Focus() : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre FROM porteoperador WHERE Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE porteoperador SET RFC='" & txtRfc.Text & "',Licencia='" & txtLicencia.Text & "',Sueldo='" & txtSueldo.Text & "',CP='" & txtCp.Text & "',Calle='" & txtCalle.Text & "',NumE='" & txtNumExt.Text & "',NumI='" & txtNumInt.Text & "',Colonia='" & txtColonia.Text & "',Edo='" & txtEstado.Text & "',Mun='" & txtMunicipio.Text & "',Facebook='" & txtfacebook.Text & "',Telefono='" & txtTelefono.Text & "' WHERE Nombre='" & cboNombre.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Operador actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
                        btnNuevo.PerformClick()
                    End If
                    cnn2.Close()

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO porteoperador(Nombre,RFC,Licencia,Sueldo,CP,Calle,NumE,NumI,Colonia,Edo,Mun,Facebook,Telefono) VALUES('" & cboNombre.Text & "','" & txtRfc.Text & "','" & txtLicencia.Text & "','" & txtSueldo.Text & "','" & txtCp.Text & "','" & txtCalle.Text & "','" & txtNumExt.Text & "','" & txtNumInt.Text & "','" & txtColonia.Text & "','" & txtEstado.Text & "','" & txtMunicipio.Text & "','" & txtfacebook.Text & "','" & txtTelefono.Text & "')"
                If cmd2.ExecuteNonQuery Then
                    MsgBox("Operador agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                    btnNuevo.PerformClick()
                Else
                    MsgBox("Revisa la información proporcionada", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()

            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If MsgBox("¿Desea Eliminar los datos de Operador?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then
            Exit Sub
        End If

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "DELETE FROM PorteOperador WHERE Nombre='" & cboNombre.Text & "'"
        If cmd1.ExecuteNonQuery Then
            MsgBox("Operador Eliminado Correctamente!!!", vbInformation + vbOKOnly, "Delsscom® Control Negocios 2022")
            btnNuevo.PerformClick()
        End If
        cnn1.Close()

    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT RFC,Licencia,Sueldo,CP,Calle,NumE,NumI,Colonia,Edo,Mun,Facebook,Telefono FROM porteoperador WHERE Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    txtRfc.Text = rd1(0).ToString
                    txtLicencia.Text = rd1(1).ToString
                    txtSueldo.Text = rd1(2).ToString
                    txtCp.Text = rd1(3).ToString
                    txtCalle.Text = rd1(4).ToString
                    txtNumExt.Text = rd1(5).ToString
                    txtNumInt.Text = rd1(6).ToString
                    txtColonia.Text = rd1(7).ToString
                    txtEstado.Text = rd1(8).ToString
                    txtMunicipio.Text = rd1(9).ToString
                    txtfacebook.Text = rd1(10).ToString
                    txtTelefono.Text = rd1(11).ToString
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