Imports System.IO
Imports DPFP
Imports DPFP.Capture
Imports System.Text

Public Class frmHuella

    Implements DPFP.Capture.EventHandler
    Private Captura As DPFP.Capture.Capture
    Private Enroler As DPFP.Processing.Enrollment
    Private template As DPFP.Template
    Private verificadorrr As DPFP.Verification.Verification
    Private Delegate Sub _delegadoVeces(ByVal texto As String)
    Private Delegate Sub _delegadoControl()
    Private Delegate Sub _delegadoCancela()

    Protected Overridable Sub Inicial()
        Try
            Captura = New DPFP.Capture.Capture
            If Not Captura Is Nothing Then
                Captura.EventHandler = Me
                Enroler = New DPFP.Processing.Enrollment()
                Dim texto As New StringBuilder()
                texto.AppendFormat("x {0}", Enroler.FeaturesNeeded)
                txtMuestras.Text = texto.ToString()
                verificadorrr = New Verification.Verification
                template = New Template
            Else
                MsgBox("No se pudo iniciar la captura. Asegúrese de que el lector esté conectado e instalado en la computadora." & vbNewLine & "De persistir el problema comunícate con tu proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo iniciar la captura. Este problema a menudo ocurre porque el lector está siendo utilizado en otra venta/otro proceso." & vbNewLine & "De persistir el problema comunícate con tu proveedor de software.")
        End Try
    End Sub

    Protected Sub IniciaCaptura()
        If Not Captura Is Nothing Then
            Try
                Captura.StartCapture()
            Catch ex As Exception
                MessageBox.Show(ex.ToString() & " - No se puede iniciarl la captura.")
            End Try
        End If
    End Sub

    Protected Sub DetienCaptura()
        If Not Captura Is Nothing Then
            Try
                Captura.StopCapture()
            Catch ex As Exception
                MessageBox.Show(ex.ToString() & " - No se puede detener la captura.")
            End Try
        End If
    End Sub

    Protected Function ConvertMuestra(ByVal sample As DPFP.Sample) As Bitmap
        Dim convertidor As New DPFP.Capture.SampleConversion()
        Dim mapabits As Bitmap = Nothing
        convertidor.ConvertToPicture(sample, mapabits)
        Return mapabits
    End Function

    Private Sub PonerImg(ByVal bmp)
        picHuella.Image = bmp
    End Sub

    Protected Function ExtraerCar(ByVal sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()
        Dim feed As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim caract As New DPFP.FeatureSet()

        extractor.CreateFeatureSet(sample, Purpose, feed, caract)

        If (feed = DPFP.Capture.CaptureFeedback.Good) Then
            Return caract
        Else
            Return Nothing
        End If
    End Function

    Protected Sub Procesar(ByVal sample As DPFP.Sample)
        Dim caracte As DPFP.FeatureSet = ExtraerCar(sample, DPFP.Processing.DataPurpose.Enrollment)
        If (Not caracte Is Nothing) Then
            Try
                Enroler.AddFeatures(caracte)
            Finally
                Dim text As New StringBuilder()
                text.AppendFormat("x {0}", Enroler.FeaturesNeeded)
                mostrarVeces(text.ToString)
                Select Case Enroler.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready
                        template = Enroler.Template

                        DetienCaptura()
                        modificaControl()
                    Case DPFP.Processing.Enrollment.Status.Failed
                        Enroler.Clear()
                        DetienCaptura()
                        IniciaCaptura()
                End Select
            End Try
        End If
    End Sub

    Private Sub mostrarVeces(ByVal texto As String)
        If (txtMuestras.InvokeRequired) Then
            Dim deleg As New _delegadoVeces(AddressOf mostrarVeces)
            Me.Invoke(deleg, New Object() {texto})
        Else
            txtMuestras.Text = texto
        End If
    End Sub

    Private Sub modificaControl()
        If (btnGuardar.InvokeRequired) Then
            Dim deleg As New _delegadoControl(AddressOf modificaControl)
            Me.Invoke(deleg, New Object() {})
        Else
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub Limpiar()
        DetienCaptura()
        picHuella.Image = Nothing
        txtusuario.Text = ""
        txtId.Text = ""
        txtMuestras.Text = ""
        btnGuardar.Enabled = False
        Inicial()
        IniciaCaptura()
    End Sub

    Private Sub limpiaCampos()
        If (txtusuario.InvokeRequired) Then
            Dim deleg As New _delegadoCancela(AddressOf limpiaCampos)
            Me.Invoke(deleg, New Object() {})
        Else
            txtusuario.Text = ""
            txtId.Text = ""
            btnGuardar.Enabled = True
            picHuella.Image = Nothing
        End If
    End Sub

    Private Sub frmHuella_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DetienCaptura()
    End Sub

    Private Sub frmHuella_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DetienCaptura()
        Inicial()
        IniciaCaptura()
    End Sub

    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        PonerImg(ConvertMuestra(Sample))
        Dim caracteristicas As DPFP.FeatureSet = ExtraerCar(Sample, DPFP.Processing.DataPurpose.Verification)
        If Not caracteristicas Is Nothing Then
            Dim result As New DPFP.Verification.Verification.Result
            Dim verificado As Boolean = False
            Dim nombre As String = ""

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If IsDBNull(rd1("Template")) Then
                    Else
                        Dim memoria As New MemoryStream(CType(rd1("Template"), Byte()))
                        template.DeSerialize(memoria.ToArray())
                        If template.Size > 4 Then
                            verificadorrr.Verify(caracteristicas, template, result)
                            If (result.Verified) Then
                                nombre = rd1("Nombre").ToString
                                verificado = True
                                Exit Do
                            End If
                        Else
                        End If
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                If (verificado) Then
                    MsgBox("Ya hay un usuario registrado con ésta huella digítal." & vbNewLine & "(" & nombre & ")", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    DetienCaptura()
                    limpiaCampos()
                Else
                    Procesar(Sample)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Public Sub OnFingerGone(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone

    End Sub

    Public Sub OnFingerTouch(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch

    End Sub

    Public Sub OnReaderConnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect

    End Sub

    Public Sub OnReaderDisconnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect

    End Sub

    Public Sub OnSampleQuality(Capture As Object, ReaderSerialNumber As String, CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If (txtusuario.Text = "" Or txtId.Text = "") Then MsgBox("Ocurrió un error inesperado, inténtalo de nuevo más tarde.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Me.Close()
        If txtMuestras.Text <> "x 0" Then
            MsgBox("Aún no completas la captura de la huella.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            btnGuardar.Enabled = False
            Exit Sub
        End If

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Usuarios set Template=@pru where IdEmpleado=" & txtId.Text
            Using fm As New MemoryStream(template.Bytes)
                cmd1.Parameters.AddWithValue("@pru", fm.ToArray())
            End Using
            If cmd1.ExecuteNonQuery Then
                MsgBox("Huella registrada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                DetienCaptura()
                Limpiar()
                Me.Close()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class