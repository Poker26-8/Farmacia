Public Class frmConsultaBodega
    Private Sub frmConsultaBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
        Dim pago As Date = Nothing, actual As Date = Nothing

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id,Dimensiones,Cliente,Id_Cliente,Inicio,Siguiente,Precio from Bodegas where Nombre='" & txtbodega.Text & "' and Ubicacion='" & txtplanta.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtID.Text = rd1("Id").ToString
                    txtdimensiones.Text = rd1("Dimensiones").ToString
                    txtdueño.Text = rd1("Cliente").ToString
                    txtid_cliente.Text = rd1("Id_Cliente").ToString
                    txtinicio.Text = FormatDateTime(rd1("Inicio").ToString, DateFormat.ShortDate)
                    txtnext.Text = FormatDateTime(rd1("Siguiente").ToString, DateFormat.ShortDate)
                    txtprecio.Text = FormatNumber(rd1("Precio").ToString, 2)
                    pago = rd1("Siguiente").ToString
                    actual = FormatDateTime(Date.Now, DateFormat.ShortDate)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        If pago < actual Then
            Me.Size = New Size(639, 288)
        Else
            Me.Size = New Size(639, 239)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        lblFecha.Text = Date.Now
        Timer1.Start()
    End Sub

    Private Sub cbovisitas_DropDown(sender As Object, e As EventArgs) Handles cbovisitas.DropDown
        cbovisitas.Items.Clear()
        cbovisitas.Items.Add(txtdueño.Text)
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select DISTINCT Nombre from Autoriza where Id_Bodega=" & txtID.Text
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbovisitas.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbovisitas.Text = "" Then MsgBox("Selecciona un visitante para conceder la entrada.", vbInformation + vbOKOnly, titulocentral) : cbovisitas.Focus().Equals(True) : Exit Sub
        If txtUsuario.Text = "" Then MsgBox("Escribe tu contraseña de usuario para continuar.", vbInformation + vbOKOnly, titulocentral) : txtUsuario.Focus().Equals(True) : Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into Movimientos(Id_Bodega,Nombre_Bodega,Movimiento,Fecha,Hora,Id_Cliente,Nombre,Usuario,Estado) values(" & txtID.Text & ",'" & txtbodega.Text & "','Entrada','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0,'" & cbovisitas.Text & "','" & lblusuario.Text & "',0)"
            If cmd1.ExecuteNonQuery Then
                MsgBox("Entrada registrada correctamente.", vbInformation + vbOKOnly, titulocentral)
                cbovisitas.Text = ""
                cbovisitas.Items.Clear()
            End If

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtUsuario.Text = "" Then Exit Sub
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtUsuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString
                    End If
                Else
                    MsgBox("Contraseña incorrecta, corrobora la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios")
                    txtUsuario.SelectionStart = 0
                    txtUsuario.SelectionLength = Len(txtUsuario.Text)
                    txtUsuario.Focus().Equals(True)
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString) : cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If cbovisitas.Text = "" Then MsgBox("Selecciona un visitante para conceder la entrada.", vbInformation + vbOKOnly, titulocentral) : cbovisitas.Focus().Equals(True) : Exit Sub
        If txtUsuario.Text = "" Then MsgBox("Escribe tu contraseña de usuario para continuar.", vbInformation + vbOKOnly, titulocentral) : txtUsuario.Focus().Equals(True) : Exit Sub

        Dim id_mov As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id from Movimientos where Nombre='" & cbovisitas.Text & "' and Estado=0 and Id_Bodega=" & txtID.Text & " and Movimiento='Entrada'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_mov = rd1("Id").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into Movimientos(Id_Bodega,Nombre_Bodega,Movimiento,Fecha,Hora,Id_Cliente,Nombre,Usuario,Estado) values(" & txtID.Text & ",'" & txtbodega.Text & "','Salida','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0,'" & cbovisitas.Text & "','" & lblusuario.Text & "',1)"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "update Movimientos set Estado=1 where Id=" & id_mov
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Salida registrada correctamente.", vbInformation + vbOKOnly, titulocentral)
                        cbovisitas.Text = ""
                        cbovisitas.Items.Clear()
                    End If
                    cnn2.Close()
                End If
            Else
                MsgBox("No hay una entrada registrada bajo este nombre, por lo que no puedes darle salida.", vbInformation + vbOKOnly, titulocentral)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("¿Estás seguro de que deseas terminar la renta de esta bodega?" & vbNewLine & "Ésta acción no se puede deshacer.", vbInformation + vbOKCancel, titulocentral) = vbOK Then
            If txtUsuario.Text = "" Then
                MsgBox("Escribe tu contraseña de usuario para continuar.", vbInformation + vbOKOnly, titulocentral)
                txtUsuario.Focus().Equals(True) : Exit Sub
            End If

            Dim termina As Boolean = False

            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Movimientos(Id_Bodega,Nombre_Bodega,Movimiento,Fecha,Hora,FechaC,Id_Cliente,Nombre,Usuario,Estado) values(" & txtID.Text & ",'" & txtbodega.Text & "','Termino de renta','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "'," & txtid_cliente.Text & ",'" & txtdueño.Text & "','" & lblusuario.Text & "',0)"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from Autoriza where Id_Bodega=" & txtID.Text
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Bodegas set Precio=0, Estado=0, Inicio='', Periodo='', Id_Cliente=0, Cliente='', Siguiente='' where Id=" & txtID.Text
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Se terminó la renta de la bodega " & txtbodega.Text & " ubicada en " & txtplanta.Text & "." & vbNewLine & "Aún puedes consultar el reporte de sus movimientos.", vbInformation + vbOKOnly, titulocentral)
                    termina = True
                Else
                    termina = False
                End If

                cnn1.Close()

                Me.Close()
                frmMapa.primerBoton()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub
End Class