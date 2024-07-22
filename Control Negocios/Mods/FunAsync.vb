Imports System.Threading.Tasks

Module FunAsync

    Dim respuesta As String = ""
    Dim siono As Integer = 0



    Public Async Function ValidarAsync(valor As String) As Task(Of Integer)

        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand
        cmd5.CommandText = "select Facturas, NotasCred, NumPart from Formatos where Facturas='" & valor & "'"
        rd5 = cmd5.ExecuteReader
        If rd5.HasRows Then
            If rd5.Read Then
                respuesta = rd5("NotasCred").ToString
                siono = rd5("NumPart").ToString
            End If
        Else
            siono = ""
        End If
        rd5.Close() : cnn5.Close()

        Return siono
    End Function

    Public Async Function RunAsyncFunctions() As Task

        Dim task1 = Function1Async()
        Dim task2 = FunctionVentasAsync()
        Dim task3 = FunctionClinetesAsync()

        Await Task.WhenAll(task1, task2, task3)

    End Function

    '' Función 1 asíncrona de ejemplo
    Public Async Function FunctionVentasAsync() As Task(Of String)

        frmVentas1.cbodesc.Items.Clear()

        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand

        If frmVentas1.cbonota.Text = "" Then
            cmd5.CommandText =
                        "select distinct Nombre from Productos where Grupo<>'INSUMO' and ProvRes<>1 order by Nombre"
        Else
            cmd5.CommandText =
                        "select distinct Nombre from VentasDetalle where Folio=" & frmVentas1.cbonota.Text & " order by Nombre"
        End If

        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                frmVentas1.cbodesc.Items.Add(rd5(0).ToString)
            End If
        Loop
        rd5.Close()
        cnn5.Close()


    End Function

    Public Async Function FunctionClinetesAsync() As Task(Of String)

        frmVentas1.cboNombre.Items.Clear()

        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand
        cmd5.CommandText = "SELECT distinct Nombre FROM Clientes WHERE Nombre<>'' order by Nombre asc"
        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                frmVentas1.cboNombre.Items.Add(rd5(0).ToString)
            End If
        Loop
        rd5.Close()
        cnn5.Close()
    End Function
    Private Async Function Function1Async() As Task(Of String)

        frmProductosS.cboNombre.Items.Clear()
        frmProductos.cboNombre.Items.Clear()


        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand
        cmd5.CommandText = "SELECT DISTINCT Nombre from Productos WHERE Nombre<>'' ORDER BY Nombre"
        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                frmProductosS.cboNombre.Items.Add(rd5(0).ToString)
                frmProductos.cboNombre.Items.Add(rd5(0).ToString)

            End If
        Loop
        rd5.Close()
        cnn5.Close()
    End Function

End Module
