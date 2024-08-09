Public Class frmMedicosD

    Dim logor As String = ""
    Private Sub frmMedicosD_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtCedula.Focus.Equals(True)
    End Sub

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEscuela.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEscuela_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEscuela.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEspecialidad.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEspecialidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEspecialidad.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre FROM usuarios WHERE Nombre='" & lblNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE usuarios SET Cedula='" & txtCedula.Text & "', Escuela='" & txtEscuela.Text & "',Especialidad='" & txtEspecialidad.Text & "',LogoR='" & logor & "' WHERE Nombre='" & lblNombre.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Médico actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                End If
            Else

            End If
            rd1.Close()
            cnn1.Close()

            btnNuevo.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtCedula.Text = ""
        txtEscuela.Text = ""
        txtEspecialidad.Text = ""

        rbnunam.Checked = False
        rbnipn.Checked = False
        rbnuam.Checked = False
        optudabol.Checked = False
        optuniversitas.Checked = False
        rbbuap.Checked = False
        optHIPO.Checked = False
        optixtla.Checked = False
        optUMSN.Checked = False
        optULA.Checked = False
        optANAHUAC.Checked = False
        optUV.Checked = False
        optunigua.Checked = False
        optUAEM.Checked = False
        optUVM.Checked = False
        optIESCH.Checked = False
        logor = ""
        txtCedula.Focus.Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub rbnunam_CheckedChanged(sender As Object, e As EventArgs) Handles rbnunam.CheckedChanged
        If (rbnunam.Checked) Then
            logor = ""
            logor = "UNAM"
        End If
    End Sub

    Private Sub rbnipn_CheckedChanged(sender As Object, e As EventArgs) Handles rbnipn.CheckedChanged
        If (rbnipn.Checked) Then
            logor = ""
            logor = "IPN"
        End If
    End Sub

    Private Sub rbnuam_CheckedChanged(sender As Object, e As EventArgs) Handles rbnuam.CheckedChanged
        If (rbnuam.Checked) Then
            logor = ""
            logor = "UAM"
        End If
    End Sub

    Private Sub optudabol_CheckedChanged(sender As Object, e As EventArgs) Handles optudabol.CheckedChanged
        If (optudabol.Checked) Then
            logor = ""
            logor = "UDABOL"
        End If
    End Sub

    Private Sub optuniversitas_CheckedChanged(sender As Object, e As EventArgs) Handles optuniversitas.CheckedChanged
        If (optuniversitas.Checked) Then
            logor = ""
            logor = "DEUS"
        End If
    End Sub

    Private Sub rbbuap_CheckedChanged(sender As Object, e As EventArgs) Handles rbbuap.CheckedChanged
        If (rbbuap.Checked) Then
            logor = ""
            logor = "BUAP"
        End If
    End Sub

    Private Sub optHIPO_CheckedChanged(sender As Object, e As EventArgs) Handles optHIPO.CheckedChanged
        If (optHIPO.Checked) Then
            logor = ""
            logor = "HIPOUNI"
        End If
    End Sub

    Private Sub optixtla_CheckedChanged(sender As Object, e As EventArgs) Handles optixtla.CheckedChanged
        If (optixtla.Checked) Then
            logor = ""
            logor = "IXTLA"
        End If
    End Sub

    Private Sub optUAEM_CheckedChanged(sender As Object, e As EventArgs) Handles optUAEM.CheckedChanged
        If (optUAEM.Checked) Then
            logor = ""
            logor = "UAEM"
        End If
    End Sub

    Private Sub optULA_CheckedChanged(sender As Object, e As EventArgs) Handles optULA.CheckedChanged
        If (optULA.Checked) Then
            logor = ""
            logor = "ULA"
        End If
    End Sub

    Private Sub optANAHUAC_CheckedChanged(sender As Object, e As EventArgs) Handles optANAHUAC.CheckedChanged
        If (optANAHUAC.Checked) Then
            logor = ""
            logor = "ANAHUAC"
        End If
    End Sub

    Private Sub optUV_CheckedChanged(sender As Object, e As EventArgs) Handles optUV.CheckedChanged
        If (optUV.Checked) Then
            logor = ""
            logor = "UV"
        End If
    End Sub

    Private Sub optunigua_CheckedChanged(sender As Object, e As EventArgs) Handles optunigua.CheckedChanged
        If (optunigua.Checked) Then
            logor = ""
            logor = "UNIGUA"
        End If
    End Sub

    Private Sub optUVM_CheckedChanged(sender As Object, e As EventArgs) Handles optUVM.CheckedChanged
        If (optUVM.Checked) Then
            logor = ""
            logor = "UVM"
        End If
    End Sub

    Private Sub optUMSN_CheckedChanged(sender As Object, e As EventArgs) Handles optUMSN.CheckedChanged
        If (optUMSN.Checked) Then
            logor = ""
            logor = "UMSN"
        End If
    End Sub

    Private Sub optIESCH_CheckedChanged(sender As Object, e As EventArgs) Handles optIESCH.CheckedChanged
        If (optIESCH.Checked) Then
            logor = ""
            logor = "IESCH"
        End If
    End Sub
End Class