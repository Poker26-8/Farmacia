

Imports System.IO.Ports
Imports System.Windows.Forms.VisualStyles.VisualStyleElement



Public Class FRMPRUBEA

    Public WithEvents serialPortT As New SerialPort()
    'Public WithEvents serialPorta As SerialPort

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim NUEVOPESO As Double = 0
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

            ' Lee los datos disponibles en el búfer de entrada del puerto serie
            Dim data2 As String = serialPortT.ReadExisting()

            ' Leer datos de la báscula
            If serialPortT.IsOpen Then
                serialPortT.Write("P")

                ' Espera un momento para que la báscula procese el comando
                System.Threading.Thread.Sleep(1000)


                'Dim Data As String = serialPortT.ReadLine()
                Dim Data As String = serialPortT.ReadExisting()


                ' Elimina los dos últimos caracteres (" kg") y convierte la cadena resultante en un número
                If Double.TryParse(Data.Substring(0, Data.Length - 3), NUEVOPESO) Then
                    Console.WriteLine(NUEVOPESO)
                Else
                    Console.WriteLine("No se pudo convertir el peso.")
                End If



                TXTCANTIDAD.Text = Trim(NUEVOPESO)
                'TXTCANTIDAD.Text = Mid(Data, 3)

                MessageBox.Show("Datos de la báscula: " & NUEVOPESO)
            Else
                MessageBox.Show("La báscula no está conectada.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        ' Cerrar el puerto serie al cerrar la aplicación
        If serialPortT.IsOpen Then
            serialPortT.Close()
        End If
    End Sub

    Private Sub FRMPRUBEA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '' Configura el puerto serie
        'With serialPortT
        '    .PortName = "COM9" ' Cambia esto al puerto correcto de tu báscula
        '    .BaudRate = 9600 ' Ajusta la velocidad según las especificaciones de tu báscula
        '    .DataBits = 8
        '    .StopBits = StopBits.One
        '    .Parity = Parity.None
        'End With

        '' Abre el puerto serie
        'Try
        '    serialPortT.Open()
        '    MessageBox.Show("Conectado a la báscula.")
        'Catch ex As Exception
        '    MessageBox.Show("Error al abrir el puerto serie: " & ex.Message)
        'End Try



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Try
        '    ' Configura el puerto serie con los parámetros correctos
        '    serialPorta = New SerialPort("COM9", 9600, Parity.None, 8, StopBits.One)
        '    serialPorta.ReadTimeout = 10000 ' Establece un tiempo de espera para la lectura


        '    serialPorta.Open()
        '    serialPorta.Write("P")



        '    ' Lee los datos de la báscula
        '    Dim weightData As String = serialPorta.ReadLine()

        '    ' Actualiza la interfaz de usuario con el peso leído
        '    UpdateWeight(weightData)
        'Catch ex As Exception
        '    ' Maneja cualquier error que pueda ocurrir durante la lectura
        '    MessageBox.Show("Error al leer el peso: " & ex.Message)
        'End Try

        '' Cierra el puerto serie antes de cerrar la aplicación
        'If serialPorta IsNot Nothing AndAlso serialPorta.IsOpen Then
        '    serialPorta.Close()
        'End If

    End Sub


    Private Sub UpdateWeight(weightData As String)
        ' Aquí puedes procesar y mostrar el peso en tu interfaz de usuario
        ' Asegúrate de convertir weightData al formato correcto según la salida de tu báscula

        ' Ejemplo: Mostrar el peso en un cuadro de texto
        'TXTCANTIDAD.Invoke(Sub() TXTCANTIDAD.Text = "Peso: " & weightData)
    End Sub

    Private Sub FRMPRUBEA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Cierra el puerto serie al cerrar la aplicación
        If serialPortT.IsOpen Then
            serialPortT.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ' Envía el comando "P" para obtener los datos
            serialPortT.Write("P")

            ' Espera un momento para que la báscula procese el comando
            System.Threading.Thread.Sleep(10000)

            serialPortT.Write("P")
            ' Lee la respuesta de la báscula
            Dim data As String = serialPortT.ReadExisting()

            ' Muestra los datos en un cuadro de texto
            TXTCANTIDAD.Text = data
        Catch ex As Exception
            MessageBox.Show("Error al obtener los datos de la báscula: " & ex.Message)
        End Try
    End Sub
End Class