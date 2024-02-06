

Imports System.IO
Imports AForge.Controls

Public Class frmAsistenciaEmp
    Dim WithEvents FpVer As FlexCodeSDK.FinFPVer
    Dim Template As String = Clipboard.GetText()
    Dim EmpID As String
    Dim FpIndex As Byte
    Dim VarEmpleado As String = ""
    Dim VarRuta As String = My.Application.Info.DirectoryPath
    Public valorr As Date = Nothing
    Public soy As Integer = 0

    Public Sub GuardaRegistro()
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "select Estatus from Asistencia where Id = (select max(Id) from Asistencia where NumEmp = " & EmpID & ")"
        rd1 = cmd1.ExecuteReader
        If rd1.Read Then
            If rd1(0).ToString = "Entrada" Then
                rd1.Close()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert Into Asistencia(NumEmp,Nombre,Hora,Fecha,Estatus)Values(" & EmpID & ",'" & VarEmpleado & "','" & lblhora.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','Salida')"
                If cmd1.ExecuteNonQuery Then
                    Voz(lblnombre.Text)
                    Voz("Salida Registrada Correctamente")
                End If
                rd1.Close()
            Else
                rd1.Close()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert Into Asistencia(NumEmp,Nombre,Hora,Fecha,Estatus)Values(" & EmpID & ",'" & VarEmpleado & "','" & lblhora.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','Entrada')"
                If cmd1.ExecuteNonQuery Then
                    Voz(lblnombre.Text)
                    Voz("Entrada Registrada Correctamente")
                End If
                rd1.Close()
            End If
        Else
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Insert Into Asistencia(NumEmp,Nombre,Hora,Fecha,Estatus)Values(" & EmpID & ",'" & VarEmpleado & "','" & lblhora.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','Entrada')"
            If cmd1.ExecuteNonQuery Then
                Voz(lblnombre.Text)
                Voz("Entrada Registrada Correctamente")
            End If
            rd1.Close()
            cnn1.Close()
        End If
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub LimpiaEmpleado_Tick(sender As Object, e As EventArgs) Handles LimpiaEmpleado.Tick
        lblnombre.Text = ""
        picHuella.Image = Nothing
        soy = 0
        LimpiaEmpleado.Stop()
    End Sub

    Private Sub timerFecha_Tick(sender As Object, e As EventArgs) Handles timerFecha.Tick
        lblfecha.Text = FormatDateTime(Date.Now, DateFormat.LongDate)
        lblhora.Text = FormatDateTime(Date.Now, DateFormat.LongTime)
    End Sub
    Private Sub cargadatos()
        FpVer = New FlexCodeSDK.FinFPVer
        FpVer.AddDeviceInfo("C700F001339", "1SX-J98-067-81L-40X", "VLT1-FF2F-6C40-5A20-4058-62GV")
        FpVer.PictureSamplePath = VarRuta & "\temp.bmp"
        FpVer.PictureSampleHeight = 4000
        FpVer.PictureSampleWidth = 4000
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select * from Usuarios"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            FpVer.FPLoad(rd1("IdEmpleado").ToString, 7, rd1("Template").ToString, "YourSecretKey" & rd1("IdEmpleado").ToString)
        Loop
        FpVer.FPVerificationStart()
        rd1.Close()
        cnn1.Close()
        timerFecha.Start()
    End Sub

    Private Sub frmAsistenciaEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargadatos()
    End Sub
    Private Sub FpVer_FPVerificationID(ByVal ID As String, ByVal FingerNr As FlexCodeSDK.FingerNumber) Handles FpVer.FPVerificationID
        EmpID = ID
        FpIndex = FingerNr
    End Sub

    Private Sub FpVer_FPVerificationImage() Handles FpVer.FPVerificationImage
        Dim imgFile As System.IO.FileStream = New System.IO.FileStream(VarRuta & "\temp.bmp", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
        Dim fileBytes(imgFile.Length) As Byte
        imgFile.Read(fileBytes, 0, fileBytes.Length)
        imgFile.Close()
        Dim ms As System.IO.MemoryStream = New MemoryStream(fileBytes)
        picHuella.Image = Image.FromStream(ms)
    End Sub

    Private Sub FpVer_FPVerificationStatus(ByVal Status As FlexCodeSDK.VerificationStatus) Handles FpVer.FPVerificationStatus
        If Status = FlexCodeSDK.VerificationStatus.v_OK Then
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre FROM Usuarios WHERE IdEmpleado = " & EmpID & ""
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                VarEmpleado = rd1(0).ToString
                lblnombre.Text = VarEmpleado
                My.Application.DoEvents()
                GuardaRegistro()
                My.Application.DoEvents()
                LimpiaEmpleado.Start()
            End If
            rd1.Close()
            cnn1.Close()
        ElseIf Status = FlexCodeSDK.VerificationStatus.v_NotMatch Then
            MsgBox("Cliente no Registrado.", MsgBoxStyle.Critical)
            lblnombre.Text = ""
            picHuella.Image = Nothing

        End If
    End Sub

    Private Sub Voz(ByVal texto As String)
        Try
            Dim audio = CreateObject("SAPI.spvoice")
            audio.volume = 100
            audio.rate = 0
            audio.speak(texto)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub frmAsistenciaEmp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FpVer.FPVerificationStop()
    End Sub
End Class