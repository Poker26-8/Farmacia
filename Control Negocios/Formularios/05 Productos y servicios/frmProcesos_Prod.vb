Public Class frmProcesos_Prod

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct DescripP from MiProd order by DescripP"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
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

    Private Sub frmProcesos_Prod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbonombre.Focus().Equals(True)
        nueva_p = False
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select CodigoP,UVentaP from MiProd where DescripP='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1("CodigoP").ToString
                    txtunidad.Text = rd1("UVentaP").ToString
                    txtcantidad.Text = "1.00"
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbonombre.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select CodigoP,UVentaP from MiProd where DescripP='" & cbonombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtcodigo.Text = rd1("CodigoP").ToString
                            txtunidad.Text = rd1("UVentaP").ToString
                            txtcantidad.Text = "1.00"
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            txtcodigo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcodigo_Click(sender As System.Object, e As System.EventArgs) Handles txtcodigo.Click
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_GotFocus(sender As Object, e As System.EventArgs) Handles txtcodigo.GotFocus
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcodigo.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select DescripP,UVentaP from MiProd where CodigoP='" & txtcodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cbonombre.Text = rd1("DescripP").ToString
                            txtunidad.Text = rd1("UVentaP").ToString
                            txtcantidad.Text = "1.00"
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_Click(sender As System.Object, e As System.EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Then Exit Sub
            If CDec(txtcantidad.Text) = 0 Then MsgBox("Ingresa una cantidad válida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            txtcantidad.Text = FormatNumber(txtcantidad.Text, 2)
            cbolote.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbolote_DropDown(sender As System.Object, e As System.EventArgs) Handles cbolote.DropDown
        cbolote.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Lote from Procesos_Prod where Codigo='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbolote.Items.Add(
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

    Private Sub cbolote_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbolote.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Cantidad from Procesos_Prod where Codigo='" & txtcodigo.Text & "' and Lote='" & cbolote.Text & "' and Proceso='Inicio de producción'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcantidad.Text = FormatNumber(rd1("Cantidad").ToString, 2)
                    txtcantidad.ReadOnly = True
                    boxInicio.Enabled = True
                    boxFin.Enabled = True
                End If
            Else
                boxInicio.Enabled = False
                boxFin.Enabled = False
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Dim nueva_p As Boolean = False

    Private Sub cbolote_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbolote.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then            
            If cbolote.Text <> "" Then
                If cbolote.Text = "" Then MsgBox("Es necesario que asignes un número de lote a la producción." & vbNewLine & "Campo necesario para identificar la producción.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
                If InStr(cbolote.Text, " ") > 0 Then
                    MsgBox("El lote no puede contener espacios, esto para evitar errores de captura y consulta." & vbNewLine & "Te sugerimos usar guiones en su lugar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
                End If

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Cantidad from Procesos_Prod where Codigo='" & txtcodigo.Text & "' and Lote='" & cbolote.Text & "' and Proceso='Inicio de producción'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            'Ya existe, sólo habilita las cosas y ya
                            txtcantidad.Text = FormatNumber(rd1("Cantidad").ToString, 2)
                            txtcantidad.ReadOnly = True
                            boxInicio.Enabled = True
                            boxFin.Enabled = True
                            txtproceso.Focus().Equals(True)
                            rd1.Close()
                        End If
                    Else
                        'No existe, va a pedir contraseña para iniciarla
                        rd1.Close()
                        nueva_p = True
                        If txtusuario.Text = "" Then
                            MsgBox("No cuentas con una producción previa bajo este lote, para iniciar la producción ingresa tu contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtusuario.Focus().Equals(True)
                            rd1.Close()
                            cnn1.Close()
                            Exit Sub
                        Else
                            If (nueva_p) Then
                                If MsgBox("¿Deseas iniciar la producción de " & txtcantidad.Text & " " & txtunidad.Text & " del producto " & cbonombre.Text & " bajo el lote " & cbolote.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "insert into Procesos_Prod(Proceso,Codigo,Nombre,Cantidad,Lote,Encargado,Usuario,Status,Fecha) values('Inicio de producción','" & txtcodigo.Text & "','" & cbonombre.Text & "'," & txtcantidad.Text & ",'" & cbolote.Text & "','" & lblusuario.Text & "','" & lblusuario.Text & "',1,'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
                                    If cmd1.ExecuteNonQuery Then
                                        txtproceso.Focus().Equals(True)
                                        boxInicio.Enabled = True
                                        boxFin.Enabled = True
                                    End If

                                    nueva_p = False
                                Else
                                    cnn1.Close()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub txtusuario_Click(sender As System.Object, e As System.EventArgs) Handles txtusuario.Click
        txtusuario.SelectionStart = 0
        txtusuario.SelectionLength = Len(txtusuario.Text)
    End Sub

    Private Sub txtusuario_GotFocus(sender As Object, e As System.EventArgs) Handles txtusuario.GotFocus
        txtusuario.SelectionStart = 0
        txtusuario.SelectionLength = Len(txtusuario.Text)
    End Sub

    Private Sub txtusuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        Dim pasa As Boolean = False

        If AscW(e.KeyChar) = Keys.Enter Then
            If txtusuario.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Alias from Usuarios where Clave='" & txtusuario.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblusuario.Text = rd1("Alias").ToString
                            pasa = True
                        End If
                    Else
                        MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtusuario.SelectionStart = 0
                        txtusuario.SelectionLength = Len(txtusuario.Text)
                        pasa = False
                    End If
                    rd1.Close()

                    If (pasa) Then
                        If (nueva_p) Then
                            If MsgBox("¿Deseas iniciar la producción de " & txtcantidad.Text & " " & txtunidad.Text & " del producto " & cbonombre.Text & " bajo el lote " & cbolote.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Procesos_Prod(Proceso,Codigo,Nombre,Cantidad,Lote,Encargado,Usuario,Status,Fecha) values('Inicio de producción','" & txtcodigo.Text & "','" & cbonombre.Text & "'," & txtcantidad.Text & ",'" & cbolote.Text & "','" & lblusuario.Text & "','" & lblusuario.Text & "',1,'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
                                If cmd1.ExecuteNonQuery Then                                    
                                    boxInicio.Enabled = True
                                    boxFin.Enabled = True
                                    txtproceso.Focus().Equals(True)
                                End If

                                nueva_p = False
                            Else
                                cnn1.Close()
                                Exit Sub
                            End If
                        End If


                    End If

                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            Else
                pasa = False
            End If
            Exit Sub
        End If
    End Sub

    Private Sub txtproceso_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtproceso.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboEncargado.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboEncargado_DropDown(sender As System.Object, e As System.EventArgs) Handles cboEncargado.DropDown
        cboEncargado.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Alias from Usuarios order by Alias"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboEncargado.Items.Add(
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

    Private Sub cboEncargado_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboEncargado.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

        End If
    End Sub

    Private Sub cboDesc1_DropDown(sender As System.Object, e As System.EventArgs) Handles cboDesc1.DropDown
        cboDesc1.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Descrip from MiProd where CodigoP='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboDesc1.Items.Add(
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

    Private Sub cboDesc1_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboDesc1.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,UVenta from Productos where Descrip='" & cboDesc1.Text & "' and CodigoP='" & txtcodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcod.Text = rd1("Codigo").ToString
                    txtUnidad1.Text = rd1("UVenta").ToString
                    txtCant1.Text = "0.00"
                    txtRequiere.Text = "0.00"
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDesc1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboDesc1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboDesc1.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Codigo,UVenta from Productos where Descrip='" & cboDesc1.Text & "' and CodigoP='" & txtcodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtcod.Text = rd1("Codigo").ToString
                            txtUnidad1.Text = rd1("UVenta").ToString
                            txtCant1.Text = "0.00"
                            txtRequiere.Text = "0.00"
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            txtcod.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcod_Click(sender As System.Object, e As System.EventArgs) Handles txtcod.Click
        txtcod.SelectionStart = 0
        txtcod.SelectionLength = Len(txtcod.Text)
    End Sub

    Private Sub txtcod_GotFocus(sender As Object, e As System.EventArgs) Handles txtcod.GotFocus
        txtcod.SelectionStart = 0
        txtcod.SelectionLength = Len(txtcod.Text)
    End Sub

    Private Sub txtcod_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcod.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Cantidad from MiProd where CodigoP='" & txtcodigo.Text & "' and Codigo='" & txtcod.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Dim cantidad As Double = rd1("Cantidad").ToString

                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            Else
                btninicio.Focus().Equals(True)
            End If
        End If
    End Sub
End Class