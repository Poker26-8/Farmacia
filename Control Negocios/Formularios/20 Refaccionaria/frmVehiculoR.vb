Public Class frmVehiculoR
    Private Sub frmVehiculoR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try

            Dim taller As Integer = 0

            If (chkTaller.Checked) Then
                taller = 1
            Else
                taller = 0
            End If

            If cbomarca.Text = "" Then MsgBox("Ingrese la marca", vbInformation + vbOKOnly, titulorefaccionaria) : cbomarca.Focus.Equals(True) : Exit Sub

            If cbomodelo.Text = "" Then MsgBox("Ingrese el modelo", vbInformation + vbOKOnly, titulorefaccionaria) : cbomodelo.Focus.Equals(True) : Exit Sub

            If cboCliente.Text <> "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Id FROM clientes WHERE Nombre='" & cboCliente.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO Clientes(Nombre,RazonSocial,Credito) VALUES('" & cboCliente.Text & "','" & cboCliente.Text & "',1000)"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Descripcion FROM vehiculo WHERE Descripcion='" & cbodescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE vehiculo SET Descripcion='" & cbodescripcion.Text & "',Marca='" & cbomarca.Text & "',Submarca='" & cbosubmarca.Text & "',Modelo='" & cbomodelo.Text & "',Cilindros='" & cbocilindros.Text & "',Desplazamiento='" & cbodesplazamiento.Text & "',Version='" & txtversion.Text & "',StatusT=" & taller & ",Cliente='" & cboCliente.Text & "',Placa='" & txtPlacas.Text & "' WHERE IdVehiculo=" & txtid.Text & ""
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Vehiculo actualizado correctamente", vbInformation + vbOKOnly, titulorefaccionaria)
                    End If
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO vehiculo(Placa,Descripcion,Marca,Submarca,Modelo,Cilindros,Desplazamiento,Version,StatusT,Cliente) VALUES('" & txtPlacas.Text & "','" & cbodescripcion.Text & "','" & cbomarca.Text & "','" & cbosubmarca.Text & "','" & cbomodelo.Text & "','" & cbocilindros.Text & "','" & cbodesplazamiento.Text & "','" & txtversion.Text & "'," & taller & ",'" & cboCliente.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Vehiculo agregado correctamente", vbInformation + vbOKOnly, titulorefaccionaria)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

            btnlimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("¿Desea salir?", vbInformation + vbOKCancel, titulorefaccionaria) = vbOK Then
            Me.Close()
            frmMenuPrincipal.Show()
        End If
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        cbomarca.Text = ""
        cbosubmarca.Text = ""
        cbocilindros.Text = ""
        cbomodelo.Text = ""
        txtPlacas.Text = ""
        txtversion.Text = ""
        cbodesplazamiento.Text = ""
        cbodescripcion.Text = ""
        chkTaller.Checked = False
        txtid.Text = ""
        cboCliente.Text = ""
    End Sub

    Private Sub cbomarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbomarca.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim valor As String = cbodescripcion.Text
            Dim valornuevo As String = valor + cbomarca.Text + " "
            cbodescripcion.Text = valornuevo
            cbosubmarca.Focus.Equals(True)

        End If
    End Sub

    Private Sub cbosubmarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbosubmarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim valor As String = cbodescripcion.Text
            Dim valornuevo As String = valor + cbosubmarca.Text + " "
            cbodescripcion.Text = valornuevo
            cbocilindros.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbocilindros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocilindros.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbomodelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbomodelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbomodelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim valor As String = cbodescripcion.Text
            Dim valornuevo As String = valor + cbomodelo.Text + " "
            cbodescripcion.Text = valornuevo
            cbodesplazamiento.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPlacas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlacas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            'Dim valor As String = cbodescripcion.Text
            'Dim valornuevo As String = valor + txtPlacas.Text + " "
            'cbodescripcion.Text = valornuevo
            txtversion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtversion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtversion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbodesplazamiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodesplazamiento.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtversion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbodescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodescripcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbodescripcion_DropDown(sender As Object, e As EventArgs) Handles cbodescripcion.DropDown
        Try
            cbodescripcion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Descripcion FROM vehiculo WHERE Descripcion<>'' ORDER BY Descripcion"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbodescripcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbodescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbodescripcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Marca,Submarca,Cilindros,Modelo,Placa,Version,Desplazamiento,IdVehiculo FROM vehiculo WHERE Descripcion='" & cbodescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbomarca.Text = rd1("Marca").ToString
                    cbosubmarca.Text = rd1("Submarca").ToString
                    cbocilindros.Text = rd1("Cilindros").ToString
                    cbomodelo.Text = rd1("Modelo").ToString
                    txtPlacas.Text = rd1("Placa").ToString
                    txtversion.Text = rd1("Version").ToString
                    cbodesplazamiento.Text = rd1("Desplazamiento").ToString
                    txtid.Text = rd1("IdVehiculo").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub chkTaller_CheckedChanged(sender As Object, e As EventArgs) Handles chkTaller.CheckedChanged
        If (chkTaller.Checked) Then
            lblcliente.Visible = True
            cboCliente.Visible = True
            cboCliente.Text = ""

            lblplaca.Visible = True
            txtPlacas.Visible = True
            txtPlacas.Text = ""

        Else
            lblcliente.Visible = False
            cboCliente.Visible = False
            cboCliente.Text = ""

            lblplaca.Visible = False
            txtPlacas.Visible = False
            txtPlacas.Text = ""
        End If
    End Sub

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPlacas.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbomarca_DropDown(sender As Object, e As EventArgs) Handles cbomarca.DropDown
        Try
            cbomarca.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM marcas WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
End Class