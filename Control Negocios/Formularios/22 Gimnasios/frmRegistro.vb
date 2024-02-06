Public Class frmRegistro
    Public folVentaFact As Integer = 0
    Public lic As String = ""
    Private Sub frmRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Clientes where Nombre<>'' order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboCliente.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub cboProducto_DropDown(sender As Object, e As EventArgs) Handles cboProducto.DropDown
        Try
            cboProducto.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Productos where Nombre<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboProducto.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboProducto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboProducto.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select PrecioVentaIVA from Productos where Nombre='" & cboProducto.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtPrecio.Text = rd1(0).ToString
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Alias from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    lblusuario.Text = rd1(0).ToString
                    btnguardar.Focus.Equals(True)
                Else
                    MsgBox("Usuario Incorrecto", vbCritical + vbOKOnly, "Delsscom Control Gimnasios")
                    txtusuario.Text = ""
                    txtusuario.Focus.Equals(True)
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtusuario_TextChanged(sender As Object, e As EventArgs) Handles txtusuario.TextChanged
        If txtusuario.Text = "" Then
            lblusuario.Text = "USUARIO"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        cboCliente.Text = ""
        cboProducto.Text = ""
        cboCliente.Items.Clear()
        cboProducto.Items.Clear()
        txtPrecio.Text = "0.00"
        mcinicio.SelectionStart = mcinicio.TodayDate
        mcfin.SelectionStart = mcfin.TodayDate
        txtusuario.Text = ""
        lblusuario.Text = "USUARIO"
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If lblusuario.Text = "USUARIO" Then
            MsgBox("Ingrese su contraseña para continuar", vbInformation + vbOKOnly, "Delsscom Control Gimnasios")
            txtusuario.Text = ""
            txtusuario.Focus.Equals(True)
            Exit Sub
        End If

        Dim inicio As Date = mcinicio.SelectionStart.ToShortDateString
        Dim fin As Date = mcfin.SelectionStart.ToShortDateString
        Dim precio As Double = 0
        Dim id As Integer = 0
        Dim credito As Double = 0
        Dim saldo As Double = 0
        Dim sumatotal As Double = 0
        Dim pocentajeiva As Double = 0
        Dim subtotal As Double = 0
        Dim subtotal2 As Double = 0
        Dim iva As Double = 0
        Dim total As Double = 0
        Dim acuenta As String = "0.00"
        Dim maxfolio As Integer = 0
        Dim maxfolio2 As Integer = 0

        Dim codigo As String = ""
        Dim cantidad As String = "1"
        Dim unidad As String = ""
        Dim departamento As String = ""
        Dim grupo As String = ""
        Dim existencias As Double = 0
        Dim saldofinal As Double = 0

        precio = FormatNumber(txtPrecio.Text, 2)
        If cboCliente.Text = "" Then
            MsgBox("Selecciona un cliente para poder continuar", vbInformation + vbOKOnly, "Delsscom® Control Gimnasios")
            cboCliente.Focus()
            Exit Sub
        End If
        If cboProducto.Text = "" Then
            MsgBox("Seleccione un servicio para poder continuar", vbInformation + vbOKOnly, "Delsscom® Control Gimnasios")
            cboProducto.Focus()
            Exit Sub
        End If
        If MsgBox("¿Deseas Guardar la Membresia?", vbQuestion + vbOKCancel, "Delsscom® Control Gimnasios") = vbCancel Then
            Exit Sub
        End If

        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select Id, Credito from Clientes where Nombre='" & cboCliente.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.Read Then
            id = rd1(0).ToString
            credito = rd1(1).ToString
        Else
            MsgBox("No existe un cliente registrado bajo ese nombre", vbCritical + vbOKOnly, "Delsscom Control Gimnasios")
            rd1.Close()
            cnn1.Close()
            Exit Sub
        End If
        rd1.Close()
        cnn1.Close()

        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select Saldo from Abonoi where idCliente=" & id & " order by Id desc"
        rd1 = cmd1.ExecuteReader
        If rd1.Read Then
            saldo = rd1(0).ToString
        Else
            saldo = 0
        End If
        rd1.Close()
        cnn1.Close()

        sumatotal = precio + CDec(saldo)

        If sumatotal > credito Then
            MsgBox("El Crédito fue revazado, no se puede realizar la venta", vbCritical + vbOKOnly, "Delsscom Control Gimnasios")
            Exit Sub
        Else
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from Productos where Nombre='" & cboProducto.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                pocentajeiva = rd1("IVA").ToString
                codigo = rd1("Codigo").ToString
                unidad = rd1("UVenta").ToString
                departamento = rd1("Departamento").ToString
                grupo = rd1("Grupo").ToString
                existencias = rd1("Existencia").ToString
            End If
            If pocentajeiva = 0 Then
                subtotal = Math.Round(subtotal2, 2, MidpointRounding.ToEven)
            Else
                subtotal2 = CDec(precio) / 1.16
                subtotal = Math.Round(subtotal2, 2, MidpointRounding.ToEven)
            End If
            iva = precio - CDec(subtotal)
            rd1.Close()
            cnn1.Close()

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Max(Folio) from Ventas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1(0).ToString = "" Then
                    maxfolio = 1
                    folVentaFact = maxfolio
                Else
                    maxfolio = rd1(0).ToString + 1
                    folVentaFact = maxfolio
                End If
            Else
                maxfolio = 1
                maxfolio = maxfolio
            End If
            rd1.Close()
            'Cambia()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Insert into Ventas(idCliente,Cliente,Subtotal,IVA,Totales,Acuenta,Resta,Usuario,FVenta,HVenta,FPago,Status,MontoSinDesc,FEntrega,CodFactura) values(" & id & ", '" & cboCliente.Text & "'," & subtotal & "," & iva & "," & precio & ",'" & acuenta & "', '" & FormatNumber(precio, 2) & "', '" & lblusuario.Text & "', '" & Format(Date.Now, "yyyy-MM-dd") & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & Format(Date.Now, "yyyy-MM-dd") & "','RESTA','" & FormatNumber(precio, 2) & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & lic & "')"
            If cmd1.ExecuteNonQuery Then
                'MsgBox("Si jal x1")
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Max(Folio) from Ventas"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    maxfolio2 = rd1(0).ToString
                End If

                rd1.Close()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into VentasDetalle(Folio,Codigo,Nombre,Cantidad,Unidad,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Depto,Grupo,TotalIEPS,TasaIeps) values(" & maxfolio2 & ", '" & codigo & "', '" & cboProducto.Text & "', '" & cantidad & "', '" & unidad & "', '" & precio & "', '" & FormatNumber(precio, 2) & "', '" & FormatNumber(subtotal2, 6) & "', '" & FormatNumber(subtotal2, 6) & "', '" & Format(Date.Now, "yyyy-MM-dd") & "', '" & departamento & "', '" & grupo & "','0','0')"
                If cmd1.ExecuteNonQuery Then
                    ' MsgBox("Si jal x2")
                    saldofinal = precio + CDec(saldo)
                    cnn1.Close()
                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "insert into Abonoi(NumFolio,idCliente,Cliente,Concepto,Fecha,Cargo,Saldo,MontoSF,CorteU) values('" & maxfolio2 & "', " & id & ", '" & cboCliente.Text & "', 'NOTA VENTA', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & FormatNumber(precio, 2) & "', '" & saldofinal & "','0','0')"
                    If cmd1.ExecuteNonQuery Then
                        'MsgBox("Si jal x3")
                        cnn1.Close()
                        cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Insert into Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) values('" & codigo & "', '" & cboProducto.Text & "','Venta'," & cantidad & ", '" & precio & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & lblusuario.Text & "', '" & existencias & "', '0', '" & maxfolio2 & "')"
                        If cmd1.ExecuteNonQuery Then
                            'MsgBox("Si jala X4")
                        End If

                        cnn1.Close()
                        cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Insert into MembresiasGym(Cliente,Producto,Precio,Inicio,Fin) values('" & cboCliente.Text & "','" & cboProducto.Text & "', " & precio & ", '" & Format(inicio, "yyyy-MM-dd") & "', '" & Format(fin, "yyyy-MM-dd") & "')"
                        If cmd1.ExecuteNonQuery Then
                            MsgBox("Membresia registrada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Gimnasios")
                            'MsgBox("Si jala X5")
                            ticket.Print()
                            btnlimpiar.PerformClick()
                        End If
                        cnn1.Close()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmReporte.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmRenovacion.Show()
    End Sub

    Private Sub ticket_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles ticket.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Bold)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim Y As Double = 0
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}

        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.Read Then
            For w = 0 To 7
                Dim dato As String = rd1(w).ToString
                e.Graphics.DrawString(dato, fuente_fecha, Brushes.Black, 150, Y, centro)
                Y += 12
            Next
        End If
        rd1.Close()
        cnn1.Close()
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_datos, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("REGISTRO DE MEMBRESIAS", fuente_datos, Brushes.Black, 138, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_datos, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/yyyy"), fuente_fecha, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_fecha, Brushes.Black, 280, Y, derecha)
        Y += 15
        e.Graphics.DrawString("Cliente: " & cboCliente.Text, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_datos, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Servicio: " & cboProducto.Text, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Precio: $" & txtPrecio.Text, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha de inicio: " & mcinicio.SelectionStart.ToShortDateString, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha de término: " & mcfin.SelectionStart.ToShortDateString, fuente_prods, Brushes.Black, 1, Y)

        e.HasMorePages = False
    End Sub


End Class