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

    Public Function SformatosInicio()

        SFormatos("SinNumCoemensal", "0")
                           SFormatos("CobroSimplificado", "0")
                           SFormatos("Pollos", "")
                           SFormatos("Pto-Bascula", "")
                           SFormatos("TBascula", "")
                           SFormatos("Bascula", "")
                           SFormatos("Prefijo", "")
                           SFormatos("Codigo", "")
                           SFormatos("Peso", "")
                           SFormatos("Taller", "")
                           SFormatos("MesasPropias", "")
                           SFormatos("Copa", "")
                           SFormatos("ToleHabi", "")
                           SFormatos("SalidaHab", "")
                           SFormatos("PrecioDia", "")
                           SFormatos("Cuartos", "")
                           SFormatos("CobroExacto", "")


                           SFormatos("Gimnasio", "")
                           SFormatos("Consignacion", "")
                           SFormatos("Nomina", "")
                           SFormatos("Mod_Asis", "")
                           SFormatos("Control_Servicios", "")
                           SFormatos("Series", "")
                           SFormatos("TiendaLinea", "")
                           SFormatos("Produccion", "")
                           SFormatos("Partes", "")
                           SFormatos("Escuelas", "")
                           SFormatos("Costeo", "")
                           SFormatos("Restaurante", "")
                           SFormatos("Refaccionaria", "")
                           SFormatos("Pollos", "")
                           SFormatos("Telefonia", "")
                           SFormatos("Hoteles", "")
                           SFormatos("Migracion", "")
                           SFormatos("Optica", "")
                           SFormatos("Mov_Cuenta", "")
                           SFormatos("Ordenes", "")
                           SFormatos("VerExistencias", "")
                           SFormatos("LinkAuto", "")
                           SFormatos("Whatsapp", "")
                           SFormatos("Transportistas", "")
                           SFormatos("Propina", "0")
                           SFormatos("LimpiarV", "0")
                           SFormatos("ProduccionPro", "0")
                           SFormatos("Dentista", "0")


    End Function

    Public Async Function RunAsyncFunctions() As Task

        Dim task1 = Function1Async()
        Dim task2 = FunctionVentasAsync()
        Dim task3 = FunctionClinetesAsync()

        Await Task.WhenAll(task1, task2, task3)

    End Function

    Public Async Function RunAsyncFunctionsV2() As Task


        Dim task22 = FunctionVentas2Async()
        Dim task33 = FunctionClinetes2Async()

        Await Task.WhenAll(task22, task33)

    End Function

    Public Async Function RunAsyncFunctionsV3() As Task
        Dim task44 = FunctionVentas3Async()
        Dim task54 = FunctionClinetes3Async()

        Await Task.WhenAll(task44, task54)
    End Function
    '------------------------------------------PANTALLA DE VENTAS 3-------------------------------------------------
    Public Async Function FunctionVentas3Async() As Task(Of String)

        frmVentas3.cbodesc.Items.Clear()

        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand

        If frmVentas1.cbonota.Text = "" Then
            cmd5.CommandText = "select distinct Nombre from Productos where Grupo<>'INSUMO' and ProvRes<>1 order by Nombre"
        Else
            cmd5.CommandText = "select distinct Nombre from VentasDetalle where Folio=" & frmVentas1.cbonota.Text & " order by Nombre"
        End If

        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                frmVentas3.cbodesc.Items.Add(rd5(0).ToString)
            End If
        Loop
        rd5.Close()
        cnn5.Close()

    End Function
    Public Async Function FunctionClinetes3Async() As Task(Of String)


        frmVentas3.cboNombre.Items.Clear()
        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand
        cmd5.CommandText = "SELECT distinct Nombre FROM Clientes WHERE Nombre<>'' order by Nombre asc"
        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                frmVentas3.cboNombre.Items.Add(rd5(0).ToString)
            End If
        Loop
        rd5.Close()
        cnn5.Close()



    End Function
    '------------------------------------------PANTALLA DE VENTAS 2-------------------------------------------------
    Public Async Function FunctionVentas2Async() As Task(Of String)

        frmVentas2.cbodesc.Items.Clear()

                           cnn5.Close() : cnn5.Open()
                           cmd5 = cnn5.CreateCommand

                           If frmVentas1.cbonota.Text = "" Then
                               cmd5.CommandText = "select distinct Nombre from Productos where Grupo<>'INSUMO' and ProvRes<>1 order by Nombre"
                           Else
                               cmd5.CommandText = "select distinct Nombre from VentasDetalle where Folio=" & frmVentas1.cbonota.Text & " order by Nombre"
                           End If

                           rd5 = cmd5.ExecuteReader
                           Do While rd5.Read
                               If rd5.HasRows Then
                                   frmVentas2.cbodesc.Items.Add(rd5(0).ToString)
                               End If
                           Loop
                           rd5.Close()
        cnn5.Close()

    End Function
    Public Async Function FunctionClinetes2Async() As Task(Of String)


        frmVentas2.cboNombre.Items.Clear()
        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand
        cmd5.CommandText = "SELECT distinct Nombre FROM Clientes WHERE Nombre<>'' order by Nombre asc"
        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                frmVentas2.cboNombre.Items.Add(rd5(0).ToString)
            End If
        Loop
        rd5.Close()
        cnn5.Close()



    End Function

    '-----------------------------------------PAANTALLA DE VENTAS 1-------------------------------------------------
    Public Async Function FunctionVentasAsync() As Task(Of String)

        frmVentas1.cbodesc.Items.Clear()
        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand

        If frmVentas1.cbonota.Text = "" Then
            cmd5.CommandText = "select distinct Nombre from Productos where Grupo<>'INSUMO' and ProvRes<>1 order by Nombre"
        Else
            cmd5.CommandText = "select distinct Nombre from VentasDetalle where Folio=" & frmVentas1.cbonota.Text & " order by Nombre"
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
