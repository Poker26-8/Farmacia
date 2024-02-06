Imports AForge.Video.DirectShow
Imports DPFP
Imports System.IO

Public Class frmHuellaCliente
    Dim WithEvents FpReg As FlexCodeSDK.FinFPReg
    Dim Template As String = Clipboard.GetText()
    Dim FingerIndex As String = "7"
    Private videoSource As VideoCaptureDevice
    Private Sub frmHuellaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaaa()
    End Sub
    Private Sub cargaaa()
        FpReg = New FlexCodeSDK.FinFPReg
        FpReg.AddDeviceInfo("BY00F000615", "1SX-398-067-81L-40X", "VLT1-FF2F-6c40-5A20-4058-62GV")
        FpReg.PictureSamplePath = My.Application.Info.DirectoryPath & "\temp.bmp"
        FpReg.PictureSampleHeight = 4000
        FpReg.PictureSampleWidth = 4000
        txtMuestras.Text = "0"
        btnguardar.Enabled = False
    End Sub
    Private Sub txtnombre_DropDown(sender As Object, e As EventArgs) Handles txtnombre.DropDown
        Try
            txtnombre.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Clientes where Nombre<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                txtnombre.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtnombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtnombre.SelectedValueChanged
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select Id from Clientes where Nombre='" & txtnombre.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.Read Then
            txtCredencial.Text = rd1(0).ToString
            If txtnombre.Text = "" Then MsgBox("Seleccione un Empleado para poder Registrar la huella") : txtnombre.Focus() : Exit Sub
            FpReg.FPRegistrationStart("YourSecretKey" & txtCredencial.Text)
        End If
        rd1.Close()
        cnn1.Close()
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
            btnguardar.Enabled = True
            btnguardar.Focus()
        End If
    End Sub

    Private Sub FpReg_FPRegistrationTemplate(ByVal FPTemplate As String) Handles FpReg.FPRegistrationTemplate
        Template = FPTemplate
    End Sub

    Private Sub FpReg_FPSamplesNeeded(ByVal Samples As Short) Handles FpReg.FPSamplesNeeded
        txtMuestras.Text = "x" & Str(Samples)
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Update Clientes set FingerIndex='" & FingerIndex & "', Template='" & Template & "' where Nombre='" & txtnombre.Text & "' and Id=" & txtCredencial.Text & ""
        If cmd1.ExecuteNonQuery Then
            MsgBox("Huella Guardada Correctamente", vbInformation + vbOKOnly, "Delsscom Control Gimnasios")
            Button2.PerformClick()
            btnguardar.Enabled = False
            txtnombre.Text = ""
            txtCredencial.Text = ""
            picHuella.Image = Nothing
            txtnombre.Focus()
            cargaaa()
        End If
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If visor.IsRunning = True Then
                My.Application.DoEvents()
                PictureBox1.Image = visor.GetCurrentVideoFrame()
                PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
            End If
        Catch ex As Exception
            MessageBox.Show("Try taking snapshot again when video image is visible.", "Cannot Save Image", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtCredencial.Text = "" Then MsgBox("Selecciona un Cliente para capturar su fotografia", vbInformation + vbOKOnly, "Delsscom Control Gimnasios") : txtnombre.Focus.Equals(True) : Exit Sub
        Try
            crea_ruta(My.Application.Info.DirectoryPath & "\ClientesGym\")
            Dim strFilename As String
            strFilename = My.Application.Info.DirectoryPath & "\ClientesGym\" & txtCredencial.Text & ".jpg"
            If (PictureBox1.Image Is Nothing) Then
                Exit Sub
            Else
                PictureBox1.Image.Save(strFilename)
                My.Application.DoEvents()
                MsgBox("Imagen guardada correctamente", vbInformation + vbOKOnly, "Delsscom Control Gimnasios")
                limpiatodo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub crea_ruta(ByVal rutx As String)
        If Directory.Exists(rutx) Then
        Else
            Directory.CreateDirectory(rutx)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim webcamform As New AForge.Video.DirectShow.VideoCaptureDeviceForm
        webcamform.ShowDialog()

        Dim webcam As New AForge.Video.DirectShow.VideoCaptureDevice(webcamform.VideoDeviceMoniker)
        webcam.Start()

        Me.visor.VideoSource = webcam
        visor.Start()
        Button3.Enabled = False
    End Sub

    Private Sub limpiatodo()
        PictureBox1.Image = Nothing
        Button3.Enabled = True
        txtnombre.Text = ""
        txtCredencial.Text = ""
    End Sub
End Class