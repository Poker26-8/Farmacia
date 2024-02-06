
Imports AForge.Controls.Joystick
Imports System.IO

Public Class frmHuellaEmp
    Dim WithEvents FpReg As FlexCodeSDK.FinFPReg
    Dim Template As String = Clipboard.GetText()
    Dim FingerIndex As String = "7"
    Private Sub cargaaa()
        FpReg = New FlexCodeSDK.FinFPReg
        FpReg.AddDeviceInfo("BY00F000615", "1SX-398-067-81L-40X", "VLT1-FF2F-6c40-5A20-4058-62GV")
        FpReg.PictureSamplePath = My.Application.Info.DirectoryPath & "\temp.bmp"
        FpReg.PictureSampleHeight = 4000
        FpReg.PictureSampleWidth = 4000
        txtMuestras.Text = "0"
        btnGuardar.Enabled = False
    End Sub

    Private Sub frmHuellaEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaaa()
    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        Try
            cboNombre.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from usuarios where Nombre<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboNombre.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select IdEmpleado from usuarios where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtId.Text = rd1(0).ToString
                If cboNombre.Text = "" Then MsgBox("Seleccione un Empleado para poder Registrar la huella") : cboNombre.Focus() : Exit Sub
                FpReg.FPRegistrationStart("YourSecretKey" & txtId.Text)
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Private Sub FpReg_FPRegistrationImage() Handles FpReg.FPRegistrationImage
        Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\temp.bmp", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
        Dim fileBytes(imgFile.Length) As Byte
        imgFile.Read(fileBytes, 0, fileBytes.Length)
        imgFile.Close()
        Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
        picHuella.Image = Image.FromStream(ms)
    End Sub
    Private Sub FpvReg_FPRegistrationStatus(ByVal Status As FlexCodeSDK.RegistrationStatus) Handles FpReg.FPRegistrationStatus
        If Status = FlexCodeSDK.RegistrationStatus.r_OK Then
            Clipboard.SetText(Template)
            btnGuardar.Enabled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub FpReg_FPRegistrationTemplate(ByVal FPTemplate As String) Handles FpReg.FPRegistrationTemplate
        Template = FPTemplate
    End Sub

    Private Sub FpReg_FPSamplesNeeded(ByVal Samples As Short) Handles FpReg.FPSamplesNeeded
        txtMuestras.Text = "x" & Str(Samples)
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Update Usuarios set FingerIndex='" & FingerIndex & "', Template='" & Template & "' where Nombre='" & cboNombre.Text & "' and IdEmpleado=" & txtId.Text & ""
        If cmd1.ExecuteNonQuery Then
            MsgBox("Huella Guardada Correctamente", vbInformation + vbOKOnly, "Delsscom Control Gimnasios")
            btnGuardar.Enabled = False
            cboNombre.Text = ""
            txtId.Text = ""
            picHuella.Image = Nothing
            cboNombre.Focus.Equals(True)
            cargaaa()
        End If
        rd1.Close()
        cnn1.Close()
    End Sub
End Class