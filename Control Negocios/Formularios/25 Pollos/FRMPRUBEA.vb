
Imports System.IO.Ports
Public Class FRMPRUBEA

    Public WithEvents serialPortT As New SerialPort()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Configurar el puerto serie
        With serialPortT
            .PortName = "COM9" ' Cambia esto al puerto correcto de tu báscula
            .BaudRate = 9600 ' Ajusta la velocidad según las especificaciones de tu báscula
            .DataBits = 8
            .StopBits = StopBits.One
            .Parity = Parity.None
        End With

        ' Abrir el puerto serie
        If Not serialPortT.IsOpen Then
            serialPortT.Open()
            MessageBox.Show("Conectado a la báscula.")
        End If

        ' Leer datos de la báscula
        If serialPortT.IsOpen Then
            Dim data As String = serialPortT.ReadLine()
            TXTCANTIDAD.Text = data
            TXTCANTIDAD.Text = Mid(data, 3)
            MessageBox.Show("Datos de la báscula: " & data)
        Else
            MessageBox.Show("La báscula no está conectada.")
        End If


        ' Cerrar el puerto serie al cerrar la aplicación
        If serialPortT.IsOpen Then
            serialPortT.Close()
        End If
    End Sub
End Class