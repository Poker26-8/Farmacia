Public Class frmDetalleH

    Public habitacionn As String = ""
    Dim minutosTiempoH As Double = 0
    Dim cfolio As Integer = 0
    Private Sub frmDetalleH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM detallehotel WHERE Habitacion='" & lblhabitacion.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                    End If
                Else

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO detallehotel(Habitacion,Tipo,Estado,Precio,Cliente,Telefono,FEntrada,FSalida,Caracteristicas) VALUES('" & lblhabitacion.Text & "','" & lbltipo.Text & "','" & ESTADO & "'," & lblprecio.Text & ",'" & cbocliente.Text & "','" & txttelefono.Text & "','" & Format(dtpEntrada.Value, "yyyy/MM/dd") & "','" & Format(dtpSalida.Value, "yyyy/MM/dd") & "','" & lblCaracteristicas.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE habitacion SET Estado='" & ESTADO & "' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()


                End If
                rd1.Close()
                cnn1.Close()

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO AsigPC(Nombre,Tipo,HorEnt,HorSal,Fecha,Ocupada) VALUES('" & lblhabitacion.Text & "','Habitacion','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "',1)"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE habitacion SET Estado='Ocupada' WHERE N_Habitacion='" & lblhabitacion.Text & "'"
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

                If minutosTiempoH = 0 Then
                    HrTiempo = Format(Date.Now, "HH:mm:ss")
                    HrEntrega = Format(Date.Now, "HH:mm:ss")
                ElseIf minutosTiempoH > 0 Then
                    HrTiempo = Format(Date.Now, "HH:mm:ss")
                    'HrEntrega = Format(DateAdd("n", minutosTiempo, Date.Now), "HH:mm:ss")
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO Comanda1(Folio,IdCliente,Nombre,Direccion,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,TComensales) VALUES(" & cfolio & "," & lblidcliented.Text & ",'" & lblhabitacion.Text & "','','" & lblusuario.Text & "','" & Format(Date.Now, "yyyyy-MM-dd") & "','','','','','',0)"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIva,TotalSinIva,Comisionista,Fecha,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Depto,Grupo,EstatusT,Hr,EntregaT) VALUES(" & cfolio & ",'" & lblhabitacion.Text & "','xc3','" & "Tiempo " & lblhabitacion.Text & "',1,'SER','0','0'," & lblprecio.Text & "," & lblprecio.Text & "," & lblprecio.Text & "," & lblprecio.Text & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'RESTA','Renta de Habitacion','','" & lblusuario.Text & "',0,'HABITACION','HABITACION',0,'" & HrTiempo & "','" & HrEntrega & "')"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO rep_comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVR,CostVUE,CostVP,Precio,Total,PrecioSinIva,TotalSinIva,Comisionista,Fecha,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Depto,Grupo,EstatusT,Hr,EntregaT) VALUES(" & cfolio & ",'" & lblhabitacion.Text & "','xc3','" & "Tiempo " & lblhabitacion.Text & "',1,'SER',0,'0','0'," & lblprecio.Text & "," & lblprecio.Text & "," & lblprecio.Text & "," & lblprecio.Text & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'RESTA','Renta de Habitacion','','" & lblusuario.Text & "',0,'HABITACION','HABITACION',0,'" & HrTiempo & "','" & HrEntrega & "')"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

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
                    cmd2.CommandText = "INSERT INTO detallehotel(Habitacion,Tipo,Estado,Precio,Cliente,Telefono,FEntrada,FSalida,Caracteristicas) VALUES('" & lblhabitacion.Text & "','" & lbltipo.Text & "','" & ESTADO & "'," & lblprecio.Text & ",'" & cbocliente.Text & "','" & txttelefono.Text & "','" & Format(dtpEntrada.Value, "yyyy-MM-dd") & "','" & Format(dtpSalida.Value, "yyyy-MM-dd") & "','" & lblCaracteristicas.Text & "')"
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
            btnGuardar.Focus.Equals(True)
        End If
    End Sub
End Class