Public Class frmRegistroBodega

    Dim fechacatual As Date = Nothing

    Private Sub frmRegistroBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fechacatual = Date.Now
        Dim f As String = ""
        f = Format(fechacatual, "yyyy-MM-dd")
        txtfactual.Text = f

    End Sub

    Private Sub frmRegistroBodega_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cboCliente.Focus.Equals(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboCliente.Text = ""
        txtid_cliente.Text = ""
        txtDireccion.Text = ""
        txttelefono.Text = ""
        txtCorreo.Text = ""
        txtNombre.Text = ""
        txtTelefonoC.Text = ""
        txtCorreoC.Text = ""
        grdCaptura.Rows.Clear()
        cboPeriodo.Text = ""
        txtPrecio.Text = "0.00"
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If cboCliente.Text = "" Then MsgBox("Necesitas escribir/seleccionar un cliente titular de la renta.", vbInformation + vbOKOnly, titulocentral) : cboCliente.Focus.Equals(True) : Exit Sub

        If txttelefono.Text = "" Then MsgBox("Escribe el teléfono de contacto del titular.", vbInformation + vbOKOnly, titulocentral) : txttelefono.Focus.Equals(True) : Exit Sub

        If cboPeriodo.Text = "" Then MsgBox("Selecciona el periodo de renta.", vbInformation + vbOKOnly, titulocentral) : cboPeriodo.Focus.Equals(True) : Exit Sub

        If CDec(txtPrecio.Text) = 0 Then MsgBox("Escribe un precio de renta por mes válido.", vbInformation + vbOKOnly, titulocentral) : txtPrecio.Focus.Equals(True) : Exit Sub

        If txtUsuario.Text = "" Then MsgBox("Escribe tu contraseña de usuario para continuar.", vbInformation + vbOKOnly, titulocentral) : txtUsuario.Focus.Equals(True) : Exit Sub

        Dim id As Integer = 0
        Dim estado As Integer = 0

        Try
            If MsgBox("¿Deseas guadar esta información e iniciar el periodo de renta de la bodega " & lblbodega.Text & "?", vbInformation + vbOKCancel, titulocentral) = vbOK Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Id,Estado FROM bodegas WHERE Nombre='" & lblbodega.Text & "' AND Ubicacion='" & lblubicacion.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id = rd1(0).ToString
                        estado = rd1(1).ToString
                    End If
                End If
                rd1.Close()

                If estado = 1 Then MsgBox("Proceso erróneo, inténtalo de nuevo más tarde.", vbInformation + vbOKOnly, titulocentral) : cnn1.Close() : Exit Sub

                For luffy As Integer = 0 To grdCaptura.Rows.Count - 1
                    Dim nombre As String = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                    Dim tel As String = grdCaptura.Rows(luffy).Cells(1).Value.ToString
                    Dim correo As String = grdCaptura.Rows(luffy).Cells(2).Value.ToString

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO autoriza(Id_Bodega,Nombre,Tel,Correo) VALUES(" & id & ",'" & nombre & "','" & tel & "','" & correo & "')"
                    cmd1.ExecuteNonQuery()
                Next

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO movimientos(Id_Bodega,Nombre_Bodega,Movimiento,Fecha,Hora,FechaC,Id_Cliente,Nombre,Usuario,estado) VALUES(" & id & ",'" & lblbodega.Text & "','Registro inicial','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "'," & txtid_cliente.Text & ",'" & cboCliente.Text & "','" & lblUsuario.Text & "',0)"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE bodegas SET Precio=" & CDbl(txtPrecio.Text) & ", Periodo='" & cboPeriodo.Text & "', Id_Cliente=" & txtid_cliente.Text & ", Cliente='" & cboCliente.Text & "',Estado=1,Inicio='" & txtfactual.Text & "',Siguiente='" & txtfpago.Text & "' WHERE Id=" & id
                If cmd1.ExecuteNonQuery() Then
                    MsgBox("Bodega rentada correctamente.", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn1.Close()

                Me.Close()
                frmMapa.Focus().Equals(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txttelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtNombre.Text = "" Then
                cboPeriodo.Focus.Equals(True)
            Else
                txtTelefonoC.Focus.Equals(True)
            End If


        End If
    End Sub

    Private Sub txtTelefonoC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefonoC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreoC.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreoC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreoC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If txtNombre.Text = "" Then cboCliente.Focus.Equals(True) : Exit Sub

            grdCaptura.Rows.Add(txtNombre.Text,
                                txtTelefonoC.Text,
                                txtCorreoC.Text)
            txtNombre.Text = ""
            txtTelefonoC.Text = ""
            txtCorreoC.Text = ""
            txtNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedValueChanged

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id,Telefono,Correo,Calle,Colonia,Delegacion,Entidad,CP FROM clientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtid_cliente.Text = rd1(0).ToString
                    txttelefono.Text = rd1(1).ToString
                    txtCorreo.Text = rd1(2).ToString

                    Dim direccion As String = ""

                    If rd1("Calle").ToString <> "" Then
                        direccion = direccion & rd1("Calle").ToString
                    End If
                    If rd1("Colonia").ToString <> "" Then
                        direccion = direccion & " " & rd1("Colonia").ToString
                    End If
                    If rd1("Delegacion").ToString <> "" Then
                        direccion = direccion & " " & rd1("Delegacion").ToString
                    End If
                    If rd1("Entidad").ToString <> "" Then
                        direccion = direccion & " " & rd1("Entidad").ToString
                    End If
                    If rd1("CP").ToString <> "" Then
                        direccion = direccion & " CP." & rd1("CP").ToString
                    End If
                    txtDireccion.Text = direccion
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub
    Private Sub cboPeriodo_DropDown(sender As Object, e As EventArgs) Handles cboPeriodo.DropDown
        cboPeriodo.Items.Clear()
        cboPeriodo.Items.Add("Mensual")
        cboPeriodo.Items.Add("Anual")
    End Sub

    Private Sub txtPrecio_Click(sender As Object, e As EventArgs) Handles txtPrecio.Click
        txtPrecio.SelectionStart = 0
        txtPrecio.SelectionLength = Len(txtPrecio.Text)
    End Sub

    Private Sub txtPrecio_GotFocus(sender As Object, e As EventArgs) Handles txtPrecio.GotFocus
        txtPrecio.SelectionStart = 0
        txtPrecio.SelectionLength = Len(txtPrecio.Text)
    End Sub

    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
    End Sub

    Private Sub cboPeriodo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPeriodo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecio.Focus().Equals(True)
        End If
    End Sub


    Private Sub cboPeriodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPeriodo.SelectedValueChanged

        If cboPeriodo.Text = "Mensual" Then
            Dim fechasalida As DateTime = fechacatual.AddMonths(1)
            txtfpago.Text = Format(fechasalida, "yyyy-MM-dd")
        End If

        If cboPeriodo.Text = "Anual" Then
            Dim fechasalida As DateTime = fechacatual.AddYears(1)
            txtfpago.Text = Format(fechasalida, "yyyy-MM-dd")
        End If

    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecio.Text) Then
                btnGuardar.Focus().Equals(True)
            End If

        End If
    End Sub

    Private Sub frmRegistroBodega_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMapa.btnReporte.Enabled = True
        frmMapa.btnconsulta.Enabled = True
        frmMapa.Crea_Bodegas(frmMapa.Text)
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
                        btnGuardar.Focus().Equals(True)
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


End Class