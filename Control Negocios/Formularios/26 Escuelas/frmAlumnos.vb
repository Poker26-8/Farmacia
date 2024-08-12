Public Class frmAlumnos
    Private Sub frmAlumnos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Nombre from Alumnos  order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboNombre.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id,Matricula,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado,Grupo,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Inscripcion,Baja from Alumnos where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    LBLID.Text = rd1("Id").ToString()
                    cboMatricula.Text = rd1("Matricula").ToString()
                    txttelefono.Text = rd1("Telefono").ToString()
                    txttutor.Text = rd1("Tutor").ToString()
                    txtcontacto.Text = rd1("Contacto").ToString()
                    txtcalle.Text = rd1("Calle").ToString()
                    txtnint.Text = rd1("N_Int").ToString()
                    txtnext.Text = rd1("N_Ext").ToString()
                    txtcolonia.Text = rd1("Colonia").ToString()
                    txtcp.Text = rd1("CP").ToString()
                    txtdelegacion.Text = rd1("Delegacion").ToString()
                    txtestado.Text = rd1("Estado").ToString()
                    txtgrupo.Text = rd1("Grupo").ToString()
                    If rd1("Lunes").ToString() = 1 Then optlunes.Checked = True
                    If rd1("Martes").ToString() = 1 Then optmartes.Checked = True
                    If rd1("Miercoles").ToString() = 1 Then optmiercoles.Checked = True
                    If rd1("Jueves").ToString() = 1 Then optjueves.Checked = True
                    If rd1("Viernes").ToString() = 1 Then optviernes.Checked = True
                    If rd1("Sabado").ToString() = 1 Then optsabado.Checked = True
                    txtinscripcion.Text = FormatDateTime(rd1("Inscripcion").ToString(), DateFormat.ShortDate)
                    TextBox1.Text = rd1("Baja").ToString()
                    If txtgrupo.Text <> "" Then
                        Dame_Horario(txtgrupo.Text)
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Dame_Horario(ByVal grupo As String)
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Inicio,Termino from Grupos where Nombre='" & grupo & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    txthorario.Text = rd3("Inicio").ToString() & " - " & rd3("Termino").ToString()
                End If
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboNombre.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id,Matricula,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado,Grupo,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Inscripcion,Baja from Alumnos where Nombre='" & cboNombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            LBLID.Text = rd1("Id").ToString()
                            cboMatricula.Text = rd1("Matricula").ToString()
                            txttelefono.Text = rd1("Telefono").ToString()
                            txttutor.Text = rd1("Tutor").ToString()
                            txtcontacto.Text = rd1("Contacto").ToString()
                            txtcalle.Text = rd1("Calle").ToString()
                            txtnint.Text = rd1("N_Int").ToString()
                            txtnext.Text = rd1("N_Ext").ToString()
                            txtcolonia.Text = rd1("Colonia").ToString()
                            txtcp.Text = rd1("CP").ToString()
                            txtdelegacion.Text = rd1("Delegacion").ToString()
                            txtestado.Text = rd1("Estado").ToString()
                            txtgrupo.Text = rd1("Grupo").ToString()
                            If rd1("Lunes").ToString() = 1 Then optlunes.Checked = True
                            If rd1("Martes").ToString() = 1 Then optmartes.Checked = True
                            If rd1("Miercoles").ToString() = 1 Then optmiercoles.Checked = True
                            If rd1("Jueves").ToString() = 1 Then optjueves.Checked = True
                            If rd1("Viernes").ToString() = 1 Then optviernes.Checked = True
                            If rd1("Sabado").ToString() = 1 Then optsabado.Checked = True
                            txtinscripcion.Text = FormatDateTime(rd1("Inscripcion").ToString(), DateFormat.ShortDate)
                            TextBox1.Text = rd1("Baja").ToString()
                            If txtgrupo.Text <> "" Then
                                Dame_Horario(txtgrupo.Text)
                            End If
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If
            cboMatricula.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboMatricula_DropDown(sender As Object, e As EventArgs) Handles cboMatricula.DropDown
        cboMatricula.Items.Clear()
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select distinct Matricula from Alumnos  order by Matricula"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    cboMatricula.Items.Add(rd2(0).ToString())
                End If
            Loop
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboMatricula_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMatricula.SelectedValueChanged
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Id,Nombre,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado,Grupo,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Inscripcion,Baja from Alumnos where Matricula=" & cboMatricula.Text & ""
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    LBLID.Text = rd2("Id").ToString()
                    cboNombre.Text = rd2("Nombre").ToString()
                    txttelefono.Text = rd2("Telefono").ToString()
                    txttutor.Text = rd2("Tutor").ToString()
                    txtcontacto.Text = rd2("Contacto").ToString()
                    txtcalle.Text = rd2("Calle").ToString()
                    txtnint.Text = rd2("N_Int").ToString()
                    txtnext.Text = rd2("N_Ext").ToString()
                    txtcolonia.Text = rd2("Colonia").ToString()
                    txtcp.Text = rd2("CP").ToString()
                    txtdelegacion.Text = rd2("Delegacion").ToString()
                    txtestado.Text = rd2("Estado").ToString()
                    txtgrupo.Text = rd2("Grupo").ToString()
                    If rd2("Lunes").ToString() = 1 Then optlunes.Checked = True
                    If rd2("Martes").ToString() = 1 Then optmartes.Checked = True
                    If rd2("Miercoles").ToString() = 1 Then optmiercoles.Checked = True
                    If rd2("Jueves").ToString() = 1 Then optjueves.Checked = True
                    If rd2("Viernes").ToString() = 1 Then optviernes.Checked = True
                    If rd2("Sabado").ToString() = 1 Then optsabado.Checked = True
                    txtinscripcion.Text = rd2("Inscripcion").ToString()
                    TextBox1.Text = rd1("Baja").ToString()
                    If txtgrupo.Text <> "" Then
                        Dame_Horario(txtgrupo.Text)
                    End If
                End If
            End If
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMatricula.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboMatricula.Text <> "" Then
                Try
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Id,Nombre,Telefono,Tutor,Contacto,Calle,N_Int,N_Ext,Colonia,CP,Delegacion,Estado,Grupo,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Inscripcion,Baja from Alumnos where Matricula=" & cboMatricula.Text & ""
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            LBLID.Text = rd2("Id").ToString()
                            cboNombre.Text = rd2("Nombre").ToString()
                            txttelefono.Text = rd2("Telefono").ToString()
                            txttutor.Text = rd2("Tutor").ToString()
                            txtcontacto.Text = rd2("Contacto").ToString()
                            txtcalle.Text = rd2("Calle").ToString()
                            txtnint.Text = rd2("N_Int").ToString()
                            txtnext.Text = rd2("N_Ext").ToString()
                            txtcolonia.Text = rd2("Colonia").ToString()
                            txtcp.Text = rd2("CP").ToString()
                            txtdelegacion.Text = rd2("Delegacion").ToString()
                            txtestado.Text = rd2("Estado").ToString()
                            txtgrupo.Text = rd2("Grupo").ToString()
                            If rd2("Lunes").ToString() = 1 Then optlunes.Checked = True
                            If rd2("Martes").ToString() = 1 Then optmartes.Checked = True
                            If rd2("Miercoles").ToString() = 1 Then optmiercoles.Checked = True
                            If rd2("Jueves").ToString() = 1 Then optjueves.Checked = True
                            If rd2("Viernes").ToString() = 1 Then optviernes.Checked = True
                            If rd2("Sabado").ToString() = 1 Then optsabado.Checked = True
                            txtinscripcion.Text = rd2("Inscripcion").ToString()
                            TextBox1.Text = rd1("Baja").ToString()
                            If txtgrupo.Text <> "" Then
                                Dame_Horario(txtgrupo.Text)
                            End If
                        End If
                    End If
                    rd2.Close() : cnn2.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn2.Close()
                End Try
            End If
            txttelefono.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txttutor.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttutor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttutor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcontacto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcontacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontacto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcalle.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcalle.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnint.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnint_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnint.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnext.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnext_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnext.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcolonia.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcolonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcolonia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcp.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcp.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdelegacion.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdelegacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdelegacion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtestado.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtestado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtestado.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtgrupo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtgrupo_DropDown(sender As Object, e As EventArgs) Handles txtgrupo.DropDown
        txtgrupo.Items.Clear()
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select distinct Nombre from Grupos order by Nombre"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    txtgrupo.Items.Add(rd3(0).ToString())
                End If
            Loop
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try
    End Sub

    Private Sub txtgrupo_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtgrupo.SelectedValueChanged
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Inicio,Termino from Grupos where Nombre='" & txtgrupo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    txthorario.Text = rd3("Inicio").ToString() & " - " & rd3("Termino").ToString()
                End If
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try
    End Sub

    Private Sub txtgrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtgrupo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        LBLID.Text = ""
        cboNombre.Text = ""
        cboMatricula.Text = ""
        txttelefono.Text = ""
        txttutor.Text = ""
        txtcontacto.Text = ""
        txtcalle.Text = ""
        txtnint.Text = ""
        txtnext.Text = ""
        txtcolonia.Text = ""
        txtdelegacion.Text = ""
        txtcp.Text = ""
        txtestado.Text = ""
        txtgrupo.Text = ""
        txthorario.Text = ""
        optlunes.Checked = False
        optmartes.Checked = False
        optmiercoles.Checked = False
        optjueves.Checked = False
        optviernes.Checked = False
        optsabado.Checked = False
        txtinscripcion.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If cboNombre.Text = "" Then MsgBox("Escribe el nombre del alumno.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If cboMatricula.Text = "" Then MsgBox("Escribe le número de matricula.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboMatricula.Focus().Equals(True) : Exit Sub
        If txttutor.Text = "" Then MsgBox("Escribe el nombre del padre o tutor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txttutor.Focus().Equals(True) : Exit Sub
        If txtcontacto.Text = "" Then MsgBox("Escribe el contacto del padre o tutor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontacto.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña paara continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas actualizar la información del alumno?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim id_grupo As Integer = 0
            Dim id_alumno As Integer = LBLID.Text

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id from Grupos where Nombre='" & txtgrupo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_grupo = rd1(0).ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Clientes set Nombre='" & cboNombre.Text & "', RazonSocial='" & cboNombre.Text & "' where Id=" & id_alumno
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update AbonoI set Cliente='" & cboNombre.Text & "' where IdCliente=" & id_alumno
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Ventas set Cliente='" & cboNombre.Text & "' where IdCliente=" & id_alumno
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Alumnos set Nombre='" & cboNombre.Text & "', Telefono='" & txttelefono.Text & "', Tutor='" & txttutor.Text & "', Contacto='" & txtcontacto.Text & "', Calle='" & txtcalle.Text & "', N_Int='" & txtnint.Text & "', N_Ext='" & txtnext.Text & "', Colonia='" & txtcolonia.Text & "', CP='" & txtcolonia.Text & "', Delegacion='" & txtdelegacion.Text & "', Estado='" & txtestado.Text & "', Id_Grupo=" & id_grupo & ", Grupo='" & txtgrupo.Text & "', Lunes=" & IIf(optlunes.Checked = True, 1, 0) & ", Martes=" & IIf(optmartes.Checked = True, 1, 0) & ", Miercoles=" & IIf(optmiercoles.Checked = True, 1, 0) & ", Jueves=" & IIf(optjueves.Checked = True, 1, 0) & ", Viernes=" & IIf(optviernes.Checked = True, 1, 0) & ", Sabado=" & IIf(optsabado.Checked = True, 1, 0) & " where Id=" & id_alumno
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos del alumno actualizados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnlimpiar.PerformClick()
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcontraseña.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblusuario.Text = rd1("Alias").ToString()
                        End If
                    Else
                        MsgBox("Contraseña incorrecta, inténtalo de nuevo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close() : cnn1.Close()
                        txtcontraseña.SelectAll()
                        Exit Sub
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If cboNombre.Text = "" Then MsgBox("Debes seleccionar un alumno.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If cboMatricula.Text = "" Then MsgBox("Debes seleccionar un alumno.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboMatricula.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña paara continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas dar de baja al alumno?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Alumnos set status=0, baja='" & Format(Date.Now, "yyyy-MM-dd") & "' where Nombre='" & cboNombre.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Alumno puesto en baja correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
                cnn1.Close()

                CanceaVentaCliente(cboNombre.Text)
                btnlimpiar.PerformClick()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub CanceaVentaCliente(ByVal nombre As String)
        Dim monto_efectivo As Double = 0
        Dim monto_efectivo2 As Double = 0
        Dim monto_tarjeta As Double = 0
        Dim monto_transfe As Double = 0
        Dim monto_monedero As Double = 0
        Dim monto_otro As Double = 0

        Try
            cnn5.Close() : cnn5.Open()
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select Folio,IdCliente,ACuenta,Resta,Totales from Ventas where Cliente='" & cboNombre.Text & "' and Resta>0 order by Folio"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then

                    Dim folio As Integer = rd5("Folio").ToString()
                    Dim id_cliente As Integer = rd5("IdCliente").ToString()
                    Dim acuenta As Double = rd5("ACuenta").ToString()
                    Dim resta As Double = rd5("Resta").ToString()

                    Dim tot_venta As Double = rd5("Totales").ToString()


                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "update Ventas set Status='CANCELADA', FCancelado='" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "' where Folio=" & folio
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "update Ventas set Cargado=0 where Folio=" & folio
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "select ACuenta from Ventas where Folio=" & folio
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            acuenta = rd1(0).ToString()
                        End If
                    End If
                    rd1.Close()


                    Dim cuentapagar As String = ""
                    Dim mysaldo2 As Double = 0
                    Dim sumapagos As Double = 0

                    If acuenta > 0 Then
                        'Monto en efectivo
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select sum(Efectivo) from AbonoI where NumFolio='" & folio & "' and Concepto='ABONO'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                monto_efectivo = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                            End If
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select sum(Efectivo) from Abono where NumFolio='" & folio & "' and Concepto='ABONO'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                monto_efectivo2 = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                            End If
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Distinct FormaPago FROM Abono WHERE NumFolio='" & folio & "' AND Concepto='ABONO'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then
                                cuentapagar = rd1(0).ToString

                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "select sum(FormaMonto) from Abono where NumFolio='" & folio & "' and Concepto='ABONO' AND FormaPago='" & cuentapagar & "'"
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    If rd2.Read Then
                                        sumapagos = rd2(0).ToString
                                    End If
                                End If
                                rd2.Close()

                                '----------------------------------------------------------meter las formas d epago endiferentes---------------------------------------------------------------
                                If id_cliente <> 0 Then
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "select Saldo from Abono where Id=(select max(Id) from Abono where IdCliente=" & id_cliente & ")"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            mysaldo2 = CDbl(IIf(rd3(0).ToString() = "", 0, rd3(0).ToString())) - CDbl(acuenta)
                                        End If
                                    Else
                                        mysaldo2 = -CDbl(tot_venta)
                                    End If
                                    rd3.Close()
                                End If

                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText =
                                    "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,Corte,CorteU) values('" & folio & "'," & id_cliente & ",'" & cboNombre.Text & "','NOTA CANCELADA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & CDbl(tot_venta) & "," & mysaldo2 & "," & monto_efectivo2 & ",'" & cuentapagar & "'," & sumapagos & ",'','','" & lblusuario.Text & "',0,0)"
                                cmd4.ExecuteNonQuery()

                                If id_cliente <> 0 Then
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText =
                                        "select Saldo from Abono where Id=(select MAX(Id) from Abono where IdCliente=" & id_cliente & ")"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            mysaldo2 = CDbl(IIf(rd3(0).ToString() = "", 0, rd3(0).ToString())) + CDbl(acuenta)
                                            mysaldo2 = mysaldo2 - CDbl(resta)
                                        End If
                                    Else
                                        mysaldo2 = CDbl(acuenta)
                                    End If
                                    rd3.Close()

                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText =
                                        "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,Corte,CorteU) values('" & folio & "'," & id_cliente & ",'" & cboNombre.Text & "','CARGO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & CDbl(acuenta) & ",0," & mysaldo2 & ",'','',0,'','','" & lblusuario.Text & "',0,0)"
                                    cmd4.ExecuteNonQuery()
                                End If

                                '---------------------------------------------------------------------------------------------------------------------------------------------------------------
                            End If
                        Loop
                        rd1.Close()

                        'Monto en tarjeta
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select sum(Tarjeta) from AbonoI where NumFolio='" & folio & "' and Concepto='ABONO'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                monto_tarjeta = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                            End If
                        End If
                        rd1.Close()

                        'Monto en transferencia
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select sum(Transfe) from AbonoI where NumFolio='" & folio & "' and Concepto='ABONO'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                monto_transfe = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                            End If
                        End If
                        rd1.Close()

                        'Monto en monedero
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select sum(Monedero) from AbonoI where NumFolio='" & folio & "' and Concepto='ABONO'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                monto_monedero = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                            End If
                        End If
                        rd1.Close()

                        'Monto en otros conceptos
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select sum(Otro) from AbonoI where NumFolio='" & folio & "' and Concepto='ABONO'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                monto_otro = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                            End If
                        End If
                        rd1.Close()
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "update Ventas set MontoCance=" & monto_efectivo & " where Folio=" & folio
                    cmd1.ExecuteNonQuery()

                    Dim MySaldo As Double = 0


                    If id_cliente <> 0 Then
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "select Saldo from Abono where Id=(select max(Id) from Abono where IdCliente=" & id_cliente & ")"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                mysaldo2 = CDbl(IIf(rd3(0).ToString() = "", 0, rd3(0).ToString())) - CDbl(resta)
                            End If
                        End If
                        rd3.Close()
                    End If

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText =
                        "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,FormaPago,FormaMonto,Banco,Referencia,Usuario,Corte,CorteU) values('" & folio & "'," & id_cliente & ",'" & cboNombre.Text & "','NOTA CANCELADA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & CDbl(tot_venta) & "," & mysaldo2 & "," & monto_efectivo2 & ",'" & cuentapagar & "'," & sumapagos & ",'','','" & lblusuario.Text & "',0,0)"
                    cmd4.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "update VentasDetalle set CostoVUE=0, Facturado='CANCELADO', CostoVP=0 where Folio=" & folio
                    cmd1.ExecuteNonQuery()

                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn5.Close()
        End Try
    End Sub
End Class