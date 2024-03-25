Public Class frmDetalleH

    Public habitacionn As String = ""
    Dim minutosTiempoH As Double = 0
    Dim cfolio As Integer = 0
    Private Sub frmDetalleH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbodescripcion.Focused.Equals(True)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If lblEstado.Text = "Ocupada" Or lblEstado.Text = "Reservacion" Then
        Else
            cbocliente.Text = ""
            dtpEntrada.Value = Date.Now
            dtpSalida.Value = Date.Now
            txttelefono.Text = ""
            lblidcliented.Text = ""
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmManejo.Show()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim ESTADO As String = ""



        If cboRegistro.Text = "HOSPEDAR" Then
            ESTADO = "Ocupada"
        ElseIf cboRegistro.Text = "RESERVACION" Then
            ESTADO = "Reservacion"
        ElseIf cboRegistro.Text = "MANTENIMIENTO" Then
            ESTADO = "Mantenimiento"
        ElseIf cboRegistro.Text = "LIMPIEZA" Then
            ESTADO = "Limpieza"
        ElseIf cboRegistro.Text = "VENTILACION" Then
            ESTADO = "Ventilacion"
        End If

        If lblusuario.Text = "" Then MsgBox("Ingrese la contraseña de usuario", vbInformation + vbOKOnly, titulohotelriaa) : txtcontra.Focus.Equals(True) : Exit Sub

        If ESTADO = "Ocupada" Then

            Try

                If cbocliente.Text = "" Then MsgBox("Debe seleccionar el cliente para asignar la habitación", vbInformation + vbOKOnly, titulohotelriaa)
                If cbocliente.Text <> "" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM Clientes WHERE Nombre='" & cbocliente.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO clientes(Nombre,RazonSocial,Telefono) VALUES('" & cbocliente.Text & "','" & cbocliente.Text & "','" & txttelefono.Text & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                    cnn1.Close()

                End If

                If minutosTiempoH = 0 Then
                    HrTiempo = Format(Date.Now, "HH:mm:ss")
                    HrEntrega = Format(Date.Now, "HH:mm:ss")
                ElseIf minutosTiempoH > 0 Then
                    HrTiempo = Format(Date.Now, "HH:mm:ss")
                    'HrEntrega = Format(DateAdd("n", minutosTiempo, Date.Now), "HH:mm:ss")
                End If

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO AsigPC(Nombre,Tipo,HorEnt,HorSal,Fecha,Ocupada) VALUES('" & lblhabitacion.Text & "','Habitacion','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "',1)"
                cmd1.ExecuteNonQuery()

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT MAX(Folio) FROM Comanda1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        cfolio = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) + 1
                    Else
                        cfolio = 1
                    End If
                Else
                    cfolio = 1
                End If
                rd2.Close()
                cnn2.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO Comanda1(Folio,IdCliente,Nombre,Direccion,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,TComensales) VALUES(" & cfolio & "," & IIf(lblidcliented.Text = "", "0", lblidcliented.Text) & ",'" & lblhabitacion.Text & "','','" & lblusuario.Text & "','" & Format(Date.Now, "yyyyy-MM-dd") & "','" & Format(Date.Now, "yyyyy-MM-dd HH:mm:ss") & "','','','','',0)"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

                cnn1.Close() : cnn1.Open()
                For bj As Integer = 0 To grdCaptura.Rows.Count - 1

                    Dim codigo As String = grdCaptura.Rows(bj).Cells(0).Value.ToString
                    Dim nombre As String = grdCaptura.Rows(bj).Cells(1).Value.ToString
                    Dim cantidad As Double = grdCaptura.Rows(bj).Cells(2).Value.ToString
                    Dim precio As Double = grdCaptura.Rows(bj).Cells(3).Value.ToString
                    Dim total As Double = grdCaptura.Rows(bj).Cells(4).Value.ToString
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM detallehotel WHERE Habitacion='" & lblhabitacion.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                        End If
                    Else

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO detallehotel(Habitacion,Tipo,Estado,Horas,Precio,Cliente,Telefono,FEntrada,FSalida,Caracteristicas) VALUES('" & lblhabitacion.Text & "','" & lbltipo.Text & "','" & ESTADO & "'," & txtHoras.Text & "," & precio & ",'" & cbocliente.Text & "','" & txttelefono.Text & "','" & Format(dtpEntrada.Value, "yyyy/MM/dd HH:mm:ss") & "','" & Format(dtpSalida.Value, "yyyy/MM/dd") & "','" & lblCaracteristicas.Text & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVR,CostVP,CostVUE,Descuento,Precio,Total,PrecioSinIva,TotalSinIVA,Comisionista,Fecha,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Depto,Grupo,EstatusT,Hr,EntregaT) VALUES(" & cfolio & ",'" & lblhabitacion.Text & "','" & codigo & "','" & nombre & "'," & cantidad & ",'SER','0','0','" & precio & "',0," & precio & "," & total & "," & precio & "," & total & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'RESTA','xc3','','" & lblusuario.Text & "',0,'HABITACION','HABITACION',0,'" & HrTiempo & "','" & HrEntrega & "')"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO rep_comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVR,CostVP,CostVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Depto,Grupo,EstatusT,Hr,EntregaT) VALUES(" & cfolio & ",'" & lblhabitacion.Text & "','" & codigo & "','" & nombre & "'," & cantidad & ",'SER',0,'0'," & precio & "," & precio & "," & total & "," & precio & "," & total & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'RESTA','xc3 ','','" & lblusuario.Text & "',0,'HABITACION','HABITACION',0,'" & HrTiempo & "','" & HrEntrega & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                    End If
                    rd1.Close()
                Next
                cnn1.Close()

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "UPDATE habitacion SET Estado='" & ESTADO & "' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
                cmd2.ExecuteNonQuery()
                cnn2.Close()

                MsgBox("La habitacion " & lblhabitacion.Text & " fue asignada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
                btnLimpiar.PerformClick()
                Me.Close()
                frmManejo.Show()
                frmManejo.pUbicaciones.Controls.Clear()
                frmManejo.TRAERUBICACION()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()

            End Try

        End If

        If ESTADO = "Reservacion" Then

            If cbocliente.Text = "" Then MsgBox("Debe seleccionar un cliente", vbInformation + vbOKOnly, titulohotelriaa) : cbocliente.Focus.Equals(True) : Exit Sub

            Try

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE habitacion SET Estado='" & ESTADO & "' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM detallehotel WHERE Habitacion='" & lblhabitacion.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO detallehotel(Habitacion,Tipo,Estado,Cliente,Telefono,FEntrada,FSalida,Caracteristicas) VALUES('" & lblhabitacion.Text & "','" & lbltipo.Text & "','" & ESTADO & "','" & cbocliente.Text & "','" & txttelefono.Text & "','" & Format(dtpEntrada.Value, "yyyy-MM-dd") & "','" & Format(dtpSalida.Value, "yyyy-MM-dd") & "','" & lblCaracteristicas.Text & "')"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Habitación reservada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
                    End If
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

                btnLimpiar.PerformClick()
                Me.Close()
                frmManejo.Show()
                frmManejo.pUbicaciones.Controls.Clear()
                frmManejo.TRAERUBICACION()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

        If ESTADO = "Mantenimiento" Then


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE Habitacion SET Estado='Mantenimiento' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            MsgBox("La habitacion " & lblhabitacion.Text & " fue asignada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
            btnLimpiar.PerformClick()
            Me.Close()
            frmManejo.Show()
            frmManejo.pUbicaciones.Controls.Clear()
            frmManejo.TRAERUBICACION()
        End If

        If ESTADO = "Limpieza" Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE habitacion SET Estado='Limpieza' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            MsgBox("La habitacion " & lblhabitacion.Text & " fue asignada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
            btnLimpiar.PerformClick()
            Me.Close()
            frmManejo.Show()
            frmManejo.pUbicaciones.Controls.Clear()
            frmManejo.TRAERUBICACION()
        End If

        If ESTADO = "Ventilacion" Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE habitacion SET Estado='Ventilacion' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            MsgBox("La habitacion " & lblhabitacion.Text & " fue asignada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
            btnLimpiar.PerformClick()
            Me.Close()
            frmManejo.Show()
            frmManejo.pUbicaciones.Controls.Clear()
            frmManejo.TRAERUBICACION()
        End If


    End Sub

    Private Sub cbocliente_DropDown(sender As Object, e As EventArgs) Handles cbocliente.DropDown

        Try
            cbocliente.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbocliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub

    Private Sub cbocliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbocliente.SelectedValueChanged

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Telefono,Id FROM clientes WHERE Nombre='" & cbocliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txttelefono.Text = rd1(0).ToString
                    lblidcliented.Text = rd1(1).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub cbocliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txttelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboRegistro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboRegistro.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpEntrada.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcontra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontra.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status,IdEmpleado FROM Usuarios WHERE Clave='" & txtcontra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        If rd1(1).ToString = 1 Then
                            lblusuario.Text = rd1(0).ToString

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Desocupar FROM Permisos WHERE IdEmpleado=" & rd1(2).ToString
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    If rd2(0).ToString = 1 And lblEstado.Text <> "Desocupada" Then
                                        pdesocupar.Visible = True
                                    Else
                                        pdesocupar.Visible = False
                                    End If
                                End If
                            End If
                            rd2.Close()

                        Else
                            MsgBox("El usuario no esta activo por favor contacte a su administrador", vbInformation + vbOKOnly, titulohotelriaa)
                            txtcontra.Focus.Equals(True)
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, titulohotelriaa)
                    txtcontra.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                btnGuardar.Focus.Equals(True)

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboRegistro.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpEntrada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpEntrada.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpSalida.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnDesocupar_Click(sender As Object, e As EventArgs) Handles btnDesocupar.Click
        Try

            If MsgBox("¿Desea realizar este cambio?", vbQuestion + vbYesNo + vbDefaultButton1, titulohotelriaa) = vbNo Then
                Exit Sub
            End If

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM detallehotel WHERE Habitacion='" & lblhabitacion.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "DELETE FROM detallehotel WHERE Habitacion='" & lblhabitacion.Text & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE habitacion SET Estado='Desocupada' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("La habitacion esta lista para su uso", vbInformation + vbOKOnly, titulohotelriaa)
                    End If
                    cnn1.Close()

                End If
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE habitacion SET Estado='Desocupada' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("La habitacion esta lista para su uso", vbInformation + vbOKOnly, titulohotelriaa)
                End If
                cnn1.Close()
            End If
            rd2.Close()
            cnn2.Close()

            btnLimpiar.PerformClick()
            Me.Close()
            frmManejo.Show()
            frmManejo.pUbicaciones.Controls.Clear()
            frmManejo.TRAERUBICACION()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub dtpSalida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpSalida.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodescripcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbodescripcion_DropDown(sender As Object, e As EventArgs) Handles cbodescripcion.DropDown
        Try
            cbodescripcion.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbodescripcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbodescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodescripcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If cbodescripcion.Text = "" Then
                btnGuardar.Focus.Equals(True)
            Else
                cbocodigo.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub cbodescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbodescripcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo FROM productos WHERE Nombre='" & cbodescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbocodigo.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocodigo_DropDown(sender As Object, e As EventArgs) Handles cbocodigo.DropDown
        Try
            cbocodigo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM productos WHERE Codigo<>'' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbocodigo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigo.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then

                Dim TiCambio As Double = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & cbocodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtprecio.Text = rd1("PrecioVentaIVA").ToString
                        txtprecio.Text = FormatNumber(txtprecio.Text, 2)

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT tipo_cambio FROM tb_moneda,Productos WHERE Codigo='" & cbocodigo.Text & "' AND Productos.id_tbMoneda=tb_moneda.id"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                TiCambio = rd2(0).ToString
                                If TiCambio = 0 Then TiCambio = 1
                            End If
                        Else

                            TiCambio = 1
                        End If
                        rd2.Close()
                        cnn2.Close()

                    End If
                Else
                    MsgBox("El código no se encuentra en la base de datos.", vbInformation + vbOKOnly, titulohotelriaa)
                    rd1.Close()
                    cnn1.Close()
                    cbocodigo.Focus().Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
                txtCantidad.Focus.Equals(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        Try

            Dim chec As Boolean = False

            e.KeyChar = UCase(e.KeyChar)
            If AscW(e.KeyChar) = Keys.Enter Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select VSE from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        chec = rd1(0).ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cbocodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                        Else
                            If chec = True Then

                            End If
                        End If
                    End If
                End If
                rd1.Close()
                cnn1.Close()
                Call UpGrid()

                cbocodigo.Text = ""
                cbodescripcion.Text = ""
                txtCantidad.Text = "1"
                txtprecio.Text = "0.00"
                txtTotal.Text = "0.00"
                cbodescripcion.Focused.Equals(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try


    End Sub

    Private Sub UpGrid()

        Try
            Dim Acumula As Boolean = False
            Dim Val_Punto As Integer = 0
            Dim Mid_precio As String = ""
            Dim codigo As String = cbocodigo.Text
            Dim nombre As String = cbodescripcion.Text
            Dim unidad As String = "N/A" 'txtunidad.Text
            Dim cantid As Double = IIf(txtCantidad.Text = "", "0", txtCantidad.Text)
            Dim precio As Double = 0

            Val_Punto = InStr(1, txtprecio.Text, ".")
            If Val_Punto = 0 Then
                precio = FormatNumber(txtprecio.Text, 4)
            Else
                Mid_precio = Mid(txtprecio.Text, Val_Punto, 40)
                If Len(Mid_precio) = 2 Then
                    precio = FormatNumber(txtprecio.Text, 4)
                ElseIf Len(Mid_precio) > 2 Then
                    precio = FormatNumber(txtprecio.Text, 4)
                End If
            End If

            Dim existencia As Double = 0
            If unidad <> "N/A" Then
                existencia = existencia 'txtexistencia.Text
            Else
                existencia = 0
            End If

            Dim total As Double = txtTotal.Text
            Dim PU As Double = CDbl(txtTotal.Text) / (1 + IvaDSC(cbocodigo.Text))
            Dim IvaIeps As Double = PU - (PU / (1 + ProdsIEPS(cbocodigo.Text)))
            Dim ieps As Double = ProdsIEPS(cbocodigo.Text)

            Dim desucentoiva As Double = 0
            Dim total1 As Double = 0
            Dim monedero As Double = 0
            Dim minimo As Double = 0
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT IVA,Promo_Monedero,Min FROM Productos WHERE Codigo='" & cbocodigo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    monedero = rd3(1).ToString()
                    minimo = rd3(2).ToString()
                    If CDbl(rd3(0).ToString) = 0.16 Then
                        desucentoiva = FormatNumber(CDbl(txtTotal.Text) / 1.16, 4)
                        total1 = FormatNumber(CDbl(txtTotal.Text) / 1.16, 4)
                    Else
                        desucentoiva = FormatNumber(txtTotal.Text, 4)
                        total1 = 0
                    End If
                End If
            Else
                desucentoiva = FormatNumber(txtTotal.Text, 4)
                total1 = 0
            End If
            rd3.Close()
            cnn3.Close()

            Dim acumulaxd As Integer = 0
            cnn1.Close()
            cnn1.Open()
            cmd1.CommandText = "Select NotasCred from Formatos where Facturas='Acumula'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                acumulaxd = rd1(0).ToString
            End If
            rd1.Close()
            cnn1.Close()

            If acumulaxd = 1 Then
                For dx As Integer = 0 To grdCaptura.Rows.Count - 1
                    If codigo = grdCaptura.Rows(dx).Cells(0).Value.ToString Then
                        grdCaptura.Rows(dx).Cells(3).Value = cantid + CDec(grdCaptura.Rows(dx).Cells(3).Value)
                        grdCaptura.Rows(dx).Cells(4).Value = FormatNumber(total + CDec(grdCaptura.Rows(dx).Cells(4).Value), 4)
                        GoTo kak
                    End If
                Next
                grdCaptura.Rows.Add(codigo, nombre, cantid, FormatNumber(precio, 4), FormatNumber(total, 5), existencia, FormatNumber(IvaIeps, 4), FormatNumber(ieps, 4), desucentoiva, total1, monedero)
            Else
                grdCaptura.Rows.Add(codigo, nombre, cantid, FormatNumber(precio, 4), FormatNumber(total, 4), existencia, FormatNumber(IvaIeps, 4), FormatNumber(ieps, 4), desucentoiva, total1, monedero)
            End If
kak:
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try

    End Sub

    Public Function IvaDSC(ByVal cod As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & cod & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    IvaDSC = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
                End If
            Else
                IvaDSC = 0
            End If
            rd3.Close()
            cnn3.Close()
            Return IvaDSC
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtCantidad.Text) Then

                txtTotal.Text = CDbl(txtCantidad.Text) * CDbl(txtprecio.Text)
                txtTotal.Text = FormatNumber(txtTotal.Text, 4)
                txtprecio.Focus.Equals(True)
            End If
        End If
    End Sub
End Class