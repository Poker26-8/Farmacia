Public Class frmRenovacion
    Public folVentaFact As Integer = 0
    Public lic As String = ""
    Private Sub frmRenovacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbtodas.Checked = True
        busca()
        lblinicio.Text = DateTimePicker1.Value.ToShortDateString
        lblfin.Text = DateTimePicker2.Value.ToShortDateString
    End Sub
    Public Sub busca()
        grdcaptura.Rows.Clear()
        If rbtodas.Checked = True Then
            Try
                txtPrecio.Text = "0.00"
                grdcaptura.Rows.Clear()
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from MembresiasGym"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    grdcaptura.Rows.Add(rd1(0).ToString, rd1(1).ToString, rd1(2).ToString, rd1(3).ToString, FormatDateTime(rd1(4).ToString, DateFormat.ShortDate), FormatDateTime(rd1(5).ToString, DateFormat.ShortDate))
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If rbvencidas.Checked = True Then
            Try
                Dim fecha As Date = Date.Now
                txtPrecio.Text = "0.00"
                grdcaptura.Rows.Clear()
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from MembresiasGym where Fin< '" & Format(fecha, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    grdcaptura.Rows.Add(rd1(0).ToString, rd1(1).ToString, rd1(2).ToString, rd1(3).ToString, FormatDateTime(rd1(4).ToString, DateFormat.ShortDate), FormatDateTime(rd1(5).ToString, DateFormat.ShortDate))
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        lblinicio.Text = ""
        lblfin.Text = ""
        txtPrecio.Text = "0.00"
        lblid.Text = ""
        mcinicio.SelectionStart = Today
        mcfin.SelectionStart = Today
        txtservicio.Text = ""
        txtcliente.Text = ""
        rbtodas.Checked = True
        busca()
    End Sub
    Private Sub mcinicio_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mcinicio.DateSelected
        lblinicio.Text = mcinicio.SelectionStart.ToShortDateString
    End Sub

    Private Sub mcfin_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mcfin.DateSelected
        lblfin.Text = mcfin.SelectionStart.ToShortDateString
    End Sub

    Private Sub txtservicio_DropDown(sender As Object, e As EventArgs) Handles txtservicio.DropDown
        txtservicio.Items.Clear()
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select distinct Nombre from Productos where Nombre<>'' order by Nombre"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            txtservicio.Items.Add(rd1(0).ToString)
        Loop
        rd1.Close()
        cnn1.Close()

    End Sub

    Private Sub rbtodas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtodas.CheckedChanged
        busca()
    End Sub

    Private Sub rbvencidas_CheckedChanged(sender As Object, e As EventArgs) Handles rbvencidas.CheckedChanged
        busca()
    End Sub
    Sub MessageBoxTimer()
        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        AckTime = 3
        Select Case InfoBox.Popup("!!!Selecciona las fechas de renovación¡¡¡", AckTime, "Este mensaje se cerrara automaticamente en 3 segundos", 0)
            Case 1, -1
                Exit Sub
        End Select
    End Sub

    Private Sub grdcaptura_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellContentDoubleClick
        Dim soy As Integer = 0
        soy = grdcaptura.CurrentRow.Index
        lblid.Text = grdcaptura.Rows(soy).Cells(0).Value
        txtcliente.Text = grdcaptura.Rows(soy).Cells(1).Value.ToString
        txtservicio.Text = grdcaptura.Rows(soy).Cells(2).Value.ToString
        txtPrecio.Text = FormatNumber(grdcaptura.Rows(soy).Cells(3).Value, 2)
        lblinicio.Text = grdcaptura.Rows(soy).Cells(4).Value
        lblfin.Text = grdcaptura.Rows(soy).Cells(5).Value
        MessageBoxTimer()
    End Sub
    Private Sub txtservicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtservicio.SelectedValueChanged
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select PrecioVentaIVA from Productos where Nombre='" & txtservicio.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.Read Then
            txtPrecio.Text = FormatNumber(rd1(0).ToString, 2)
        End If
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Alias from Usuarios where Clave='" & txtusuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                lblusuario.Text = rd1(0).ToString
                btnguardar.Focus.Equals(True)
            Else
                MsgBox("Contraseña incorrecta", vbCritical + vbOKOnly, "Delsscom Control Gimnasios")
                txtusuario.Text = ""
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtusuario_TextChanged(sender As Object, e As EventArgs) Handles txtusuario.TextChanged
        If txtusuario.Text = "" Then
            lblusuario.Text = "USUARIO"
        End If
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If lblusuario.Text = "USUARIO" Then
            MsgBox("Ingrese su contraseña para continuar", vbInformation + vbOKOnly, "Delsscom Control Gimnasios")
            txtusuario.Text = ""
            txtusuario.Focus()
            Exit Sub
        End If

        Dim inicio As Date = DateTimePicker1.Value
        Dim fin As Date = DateTimePicker2.Value
        Dim folio As Integer = 0
        Dim precio As Double = 0
        precio = txtPrecio.Text
        Dim contador As Integer = 0

        precio = FormatNumber(txtPrecio.Text, 2)
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

        If lblid.Text = "" Then
            If rbvencidas.Checked = True Then
                If grdcaptura.Rows.Count = 0 Then
                    MsgBox("Sin membresias vencidas, no es posible actualizar", vbExclamation + vbOKOnly, "Delsscom® Control Gimnasios")
                    Exit Sub
                Else
                    If MsgBox("¿Deseas renovar la membresia vencida a los clientes?", vbQuestion + vbOKCancel, "Delsscom® Control Gimnasios") = vbCancel Then
                        Exit Sub
                    End If
                    Try
                        For xxx = 0 To grdcaptura.Rows.Count - 1
                            folio = grdcaptura.Rows(xxx).Cells(0).Value
                            Dim masinicio As Date = grdcaptura.Rows(xxx).Cells(4).Value
                            Dim masfinal As Date = grdcaptura.Rows(xxx).Cells(5).Value

                            masinicio = DateAdd(DateInterval.Month, 1, masinicio)
                            masfinal = DateAdd(DateInterval.Month, 1, masfinal)


                            cnn1.Close()
                            cnn1.Open()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "Select Id, Credito from Clientes where Nombre='" & grdcaptura.Rows(xxx).Cells(1).Value.ToString & "'"
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
                            precio = grdcaptura.Rows(xxx).Cells(3).Value
                            sumatotal = precio + CDec(saldo)

                            If sumatotal > credito Then
                                MsgBox("El Crédito fue revazado, no se puede realizar la venta", vbCritical + vbOKOnly, "Delsscom Control Gimnasios")
                                Continue For
                            Else
                                cnn1.Close()
                                cnn1.Open()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "Select * from Productos where Nombre='" & grdcaptura.Rows(xxx).Cells(2).Value.ToString & "'"
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
                                cmd1.CommandText = "Insert into Ventas(idCliente,Cliente,Subtotal,IVA,Totales,Acuenta,Resta,Usuario,FVenta,HVenta,FPago,Status,MontoSinDesc,FEntrega,CodFactura) values(" & id & ", '" & grdcaptura.Rows(xxx).Cells(1).Value.ToString & "'," & subtotal & "," & iva & "," & precio & ",'" & acuenta & "', '" & FormatNumber(precio, 2) & "', '" & lblusuario.Text & "', '" & Format(Date.Now, "yyyy-MM-dd") & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & Format(Date.Now, "yyyy-MM-dd") & "','RESTA','" & FormatNumber(precio, 2) & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & lic & "')"
                                If cmd1.ExecuteNonQuery Then
                                    ' MsgBox("Si jal x1")
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
                                    cmd1.CommandText = "Insert into VentasDetalle(Folio,Codigo,Nombre,Cantidad,Unidad,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Depto,Grupo,TotalIEPS,TasaIeps) values(" & maxfolio2 & ", '" & codigo & "', '" & grdcaptura.Rows(xxx).Cells(2).Value.ToString & "', '" & cantidad & "', '" & unidad & "', '" & precio & "', '" & FormatNumber(precio, 2) & "', '" & FormatNumber(subtotal2, 6) & "', '" & FormatNumber(subtotal2, 6) & "', '" & Format(Date.Now, "yyyy-MM-dd") & "', '" & departamento & "', '" & grupo & "','0','0')"
                                    If cmd1.ExecuteNonQuery Then
                                        'MsgBox("Si jal x2")
                                        saldofinal = precio + CDec(saldo)
                                        cnn1.Close()
                                        cnn1.Open()
                                        cmd1 = cnn1.CreateCommand
                                        cmd1.CommandText = "insert into Abonoi(NumFolio,idCliente,Cliente,Concepto,Fecha,Cargo,Saldo,MontoSF,CorteU) values('" & maxfolio2 & "', " & id & ", '" & grdcaptura.Rows(xxx).Cells(1).Value.ToString & "', 'NOTA VENTA', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & FormatNumber(precio, 2) & "', '" & saldofinal & "','0','0')"
                                        If cmd1.ExecuteNonQuery Then
                                            'MsgBox("Si jal x3")
                                            cnn1.Close()
                                            cnn1.Open()
                                            cmd1 = cnn1.CreateCommand
                                            cmd1.CommandText = "Insert into Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) values('" & codigo & "', '" & grdcaptura.Rows(xxx).Cells(2).Value.ToString & "','Venta'," & cantidad & ", '" & precio & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & lblusuario.Text & "', '" & existencias & "', '0', '" & maxfolio2 & "')"
                                            If cmd1.ExecuteNonQuery Then
                                            Else

                                                'MsgBox("Si jala X4")
                                            End If

                                            cnn1.Close()
                                            cnn1.Open()
                                            cmd1 = cnn1.CreateCommand
                                            cmd1.CommandText = "Update MembresiasGym set inicio='" & Format(masinicio, "yyyy-MM-dd") & "', Fin='" & Format(masfinal, "yyyy-MM-dd") & "' where Id=" & folio
                                            If cmd1.ExecuteNonQuery Then
                                                contador = contador + 1
                                            End If
                                            cnn1.Close()
                                        End If
                                    End If
                                End If
                            End If
                            '''''''''''''''''''''''''''''''''''''''''''
                        Next
                        If contador = 0 Then
                            btnlimpiar.PerformClick()
                        Else
                            MsgBox("Se renovaron: " & contador & " membresias correctamente", vbInformation + vbOKOnly, "Delsscom® Control Gimnasios")
                            btnlimpiar.PerformClick()
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                    End Try
                End If
            Else
                MsgBox("Selecciona un cliente para renovarle la membresia", vbInformation + vbOKOnly, "Delsscom® Control Gimnasios")
                Exit Sub
            End If
        Else
            If MsgBox("¿Deseas renovar la membresia al cliente seleccionado?", vbQuestion + vbOKCancel, "Delsscom® Control Gimnasios") = vbCancel Then
                Exit Sub
            End If

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Id, Credito from Clientes where Nombre='" & txtcliente.Text & "'"
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
                cmd1.CommandText = "Select * from Productos where Nombre='" & txtservicio.Text & "'"
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
                    subtotal = precio
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
                cmd1.CommandText = "Insert into Ventas(idCliente,Cliente,Subtotal,IVA,Totales,Acuenta,Resta,Usuario,FVenta,HVenta,FPago,Status,MontoSinDesc,FEntrega,CodFactura) values(" & id & ", '" & txtcliente.Text & "'," & subtotal & "," & iva & "," & precio & ",'" & acuenta & "', '" & FormatNumber(precio, 2) & "', '" & lblusuario.Text & "', '" & Format(Date.Now, "yyyy-MM-dd") & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & Format(Date.Now, "yyyy-MM-dd") & "','RESTA','" & FormatNumber(precio, 2) & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & lic & "')"
                If cmd1.ExecuteNonQuery Then
                    ' MsgBox("Si jal x1")
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
                    cmd1.CommandText = "Insert into VentasDetalle(Folio,Codigo,Nombre,Cantidad,Unidad,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Depto,Grupo,TotalIEPS,TasaIeps) values(" & maxfolio2 & ", '" & codigo & "', '" & txtservicio.Text & "', '" & cantidad & "', '" & unidad & "', '" & precio & "', '" & FormatNumber(precio, 2) & "', '" & FormatNumber(subtotal2, 6) & "', '" & FormatNumber(subtotal2, 6) & "', '" & Format(Date.Now, "yyyy-MM-dd") & "', '" & departamento & "', '" & grupo & "','0','0')"
                    If cmd1.ExecuteNonQuery Then
                        'MsgBox("Si jal x2")
                        saldofinal = precio + CDec(saldo)
                        cnn1.Close()
                        cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "insert into Abonoi(NumFolio,idCliente,Cliente,Concepto,Fecha,Cargo,Saldo,MontoSF,CorteU) values('" & maxfolio2 & "', " & id & ", '" & txtcliente.Text & "', 'NOTA VENTA', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & FormatNumber(precio, 2) & "', '" & saldofinal & "','0','0')"
                        If cmd1.ExecuteNonQuery Then
                            'MsgBox("Si jal x3")
                            cnn1.Close()
                            cnn1.Open()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "Insert into Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) values('" & codigo & "', '" & txtservicio.Text & "','Venta'," & cantidad & ", '" & precio & "', '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "', '" & lblusuario.Text & "', '" & existencias & "', '0', '" & maxfolio2 & "')"
                            If cmd1.ExecuteNonQuery Then
                            Else

                                'MsgBox("Si jala X4")
                            End If

                            cnn1.Close()
                            cnn1.Open()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "Update MembresiasGym set Producto='" & txtservicio.Text & "', Inicio='" & Format(inicio, "yyyy-MM-dd") & "', Fin='" & Format(fin, "yyyy-MM-dd") & "', Precio=" & precio & " where Cliente='" & txtcliente.Text & "' and Id=" & lblid.Text
                            If cmd1.ExecuteNonQuery Then
                                MsgBox("Membresia Renovada Correctamente", vbInformation + vbOKOnly, "Delsscom® Control Gimnasios")
                                ticket.Print()
                                btnlimpiar.PerformClick()
                                cnn1.Close()
                            End If
                            cnn1.Close()
                        End If
                    End If
                End If
            End If

        End If
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
                If dato <> "" Then
                    e.Graphics.DrawString(dato, fuente_fecha, Brushes.Black, 150, Y, centro)
                    Y += 12
                End If
            Next
        End If
        rd1.Close()
        cnn1.Close()
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_datos, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("RENOVACION DE MEMBRESIAS", fuente_datos, Brushes.Black, 138, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_datos, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/yyyy"), fuente_fecha, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_fecha, Brushes.Black, 280, Y, derecha)
        Y += 15
        e.Graphics.DrawString("Cliente: " & txtcliente.Text, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_datos, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Servicio: " & txtservicio.Text, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Precio: $" & txtPrecio.Text, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha de inicio: " & mcinicio.SelectionStart.ToShortDateString, fuente_prods, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha de término: " & mcfin.SelectionStart.ToShortDateString, fuente_prods, Brushes.Black, 1, Y)
        Y += 40
        e.HasMorePages = False
    End Sub

    Private Sub txtcliente_DropDown(sender As Object, e As EventArgs) Handles txtcliente.DropDown
        Try
            txtcliente.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Clientes where Nombre<>'' order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                txtcliente.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        lblinicio.Text = DateTimePicker1.Value.ToShortDateString
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        lblfin.Text = DateTimePicker2.Value.ToShortDateString
    End Sub
End Class