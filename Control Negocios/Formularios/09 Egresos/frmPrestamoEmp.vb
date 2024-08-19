Public Class frmPrestamoEmp
    Private Sub frmPrestamoEmp_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cbonombre.Focus().Equals(True)
    End Sub

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Nombre from Usuarios where Status=1 order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Dim id_usu As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IdEmpleado,Area,NSS,Sueldo from Usuarios where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_usu = rd1("IdEmpleado").ToString()
                    lblid_usu.Text = rd1("IdEmpleado").ToString()
                    txtarea.Text = IIf(rd1("Area").ToString() = "", "", rd1("Area").ToString())
                    txtnss.Text = IIf(rd1("NSS").ToString() = "", "", rd1("NSS").ToString())
                    txtsueldo.Text = FormatNumber(IIf(rd1("Sueldo").ToString() = "", 0, rd1("Sueldo").ToString()), 2)
                End If
            End If
            rd1.Close()

            Dim cargo_p As Double = 0
            Dim cargo_t As Double = 0
            Dim abono_p As Double = 0
            Dim abono_t As Double = 0

            'Carga los saldos del empleado sí tiene préstamos pendientes
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Tipo,Cargo,Abono from SaldosEmpleados where IdEmpleado=" & id_usu
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    If rd1("Tipo").ToString() = "PERSONAL" Then
                        cargo_p = cargo_p + IIf(rd1("Cargo").ToString() = "", 0, rd1("Cargo").ToString())
                        abono_p = abono_p + IIf(rd1("Abono").ToString() = "", 0, rd1("Abono").ToString())
                    End If
                    If rd1("Tipo").ToString() = "TRABAJO" Then
                        cargo_t = cargo_t + IIf(rd1("Cargo").ToString() = "", 0, rd1("Cargo").ToString())
                        abono_t = abono_t + IIf(rd1("Abono").ToString() = "", 0, rd1("Abono").ToString())
                    End If
                End If
            Loop
            rd1.Close() : cnn1.Close()

            txtpersonal.Text = FormatNumber(cargo_p - abono_p, 2)
            txttrabajo.Text = FormatNumber(cargo_t - abono_t, 2)
            txtsaldo.Text = FormatNumber(CDbl(txtpersonal.Text) + CDbl(txttrabajo.Text), 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmPrestamoEmp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpfecha.Value = Date.Now
        dtppago.Value = Date.Now
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select max(Folio) from SaldosEmpleados where Concepto='PRESTAMO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    lblFolio.Text = IIf(rd2(0).ToString() = "", 0, rd2(0).ToString()) + 1
                End If
            Else
                lblFolio.Text = 1
            End If
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtmonto_Click(sender As System.Object, e As System.EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtmonto_GotFocus(sender As Object, e As System.EventArgs) Handles txtEfectivo.GotFocus
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtsaldo_Click(sender As System.Object, e As System.EventArgs) Handles txtsaldo.Click
        txtsaldo.SelectionStart = 0
        txtsaldo.SelectionLength = Len(txtsaldo.Text)
    End Sub

    Private Sub txtsaldo_GotFocus(sender As Object, e As System.EventArgs) Handles txtsaldo.GotFocus
        txtsaldo.SelectionStart = 0
        txtsaldo.SelectionLength = Len(txtsaldo.Text)
    End Sub

    Private Sub cbonombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim id_usu As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select IdEmpleado,Area,NSS,Sueldo from Usuarios where Nombre='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_usu = rd1("IdEmpleado").ToString()
                        lblid_usu.Text = rd1("IdEmpleado").ToString()
                        txtarea.Text = IIf(rd1("Area").ToString() = "", "", rd1("Area").ToString())
                        txtnss.Text = IIf(rd1("NSS").ToString() = "", "", rd1("NSS").ToString())
                        txtsueldo.Text = FormatNumber(IIf(rd1("Sueldo").ToString() = "", 0, rd1("Sueldo").ToString()), 2)
                    End If
                End If
                rd1.Close()

                Dim cargo_p As Double = 0
                Dim cargo_t As Double = 0
                Dim abono_p As Double = 0
                Dim abono_t As Double = 0

                'Carga los saldos del empleado sí tiene préstamos pendientes
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Tipo,Cargo,Abono from SaldosEmpleados where IdEmpleado=" & id_usu
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        If rd1("Tipo").ToString() = "PERSONAL" Then
                            cargo_p = cargo_p + IIf(rd1("Cargo").ToString() = "", 0, rd1("Cargo").ToString())
                            abono_p = abono_p + IIf(rd1("Abono").ToString() = "", 0, rd1("Abono").ToString())
                        End If
                        If rd1("Tipo").ToString() = "TRABAJO" Then
                            cargo_t = cargo_t + IIf(rd1("Cargo").ToString() = "", 0, rd1("Cargo").ToString())
                            abono_t = abono_t + IIf(rd1("Abono").ToString() = "", 0, rd1("Abono").ToString())
                        End If
                    End If
                Loop
                rd1.Close() : cnn1.Close()

                txtpersonal.Text = FormatNumber(cargo_p - abono_p, 2)
                txttrabajo.Text = FormatNumber(cargo_t - abono_t, 2)
                txtsaldo.Text = FormatNumber(CDbl(txtpersonal.Text) + CDbl(txttrabajo.Text), 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            txtEfectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "0" : Exit Sub
            txtTotal.Text = CDbl(txtEfectivo.Text) + CDbl(txtPagos.Text)
            txtTotal.Text = FormatNumber(txtTotal.Text, 2)
            dtpfecha.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpfecha.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtppago.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtppago_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtppago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcomentario.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcomentario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub SiguienteFolio()
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select MAX(Folio) from SaldosEmpleados where Concepto='PRESTAMO'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    lblFolio.Text = IIf(rd3(0).ToString() = "", 0, rd3(0).ToString()) + 1
                End If
            Else
                lblFolio.Text = "1"
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If lblid_usu.Text = "" Then MsgBox("Selecciona un empleado para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub

        If optpersonal.Checked = False And opttrabajo.Checked = False Then MsgBox("Selecciona una opción de préstamo para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : optpersonal.Focus().Equals(True) : Exit Sub

        If CDbl(txtTotal.Text) <= 0 Then MsgBox("El monto del préstamo no puede ser menor o igual a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtEfectivo.Focus().Equals(True) : Exit Sub

        If ValidaPermisos(lblusuario.Text, "Egr_PEmp") = False Then MsgBox("No cuentas con permisos para realizar este movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar este préstamo?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim tipo_mov As String = ""


            If optpersonal.Checked = True Then
                tipo_mov = "PERSONAL"
            End If
            If opttrabajo.Checked = True Then
                tipo_mov = "TRABAJO"
            End If

            Dim cargo As Double = CDbl(txtEfectivo.Text) + CDbl(txtPagos.Text)
            cargo = FormatNumber(cargo, 2)
            Try

                For luffy As Integer = 0 To grdpago.Rows.Count - 1

                    Dim formap As String = grdpago.Rows(luffy).Cells(0).Value.ToString
                    Dim bancop As String = grdpago.Rows(luffy).Cells(1).Value.ToString
                    Dim referenciap As String = grdpago.Rows(luffy).Cells(2).Value.ToString
                    Dim montop As Double = grdpago.Rows(luffy).Cells(3).Value.ToString
                    Dim fecha As Date = grdpago.Rows(luffy).Cells(4).Value.ToString
                    Dim comentario As String = grdpago.Rows(luffy).Cells(5).Value.ToString
                    Dim cuentap As String = grdpago.Rows(luffy).Cells(6).Value.ToString
                    Dim bancocp As String = grdpago.Rows(luffy).Cells(7).Value.ToString
                    Dim fechanueva As String = ""
                    fechanueva = Format(fecha, "yyyy-MM-dd"
                                      )
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into SaldosEmpleados(Folio,IdEmpleado,Nombre,Fecha,FechaPago,FechaPagado,Cargo,Abono,Tipo,Concepto,FormaPago,Monto,Nota,Banco,Referencia,Comentario,Cuenta,BancoC,Usuario,Corte,CorteU) values(" & lblFolio.Text & "," & lblid_usu.Text & ",'" & cbonombre.Text & "','" & Format(dtpfecha.Value, "yyyy/MM/dd") & "','" & Format(dtppago.Value, "yyyy/MM/dd") & "',''," & montop & ",0,'" & tipo_mov & "','PRESTAMO','" & formap & "'," & montop & ",'" & txtcomentario.Text & "','" & bancop & "','" & referenciap & "','" & comentario & "','´" & cuentap & "','" & bancocp & "','" & lblusuario.Text & "',0,0)"
                    cmd1.ExecuteNonQuery()

                    Dim saldocuenta As Double = 0

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cuentap & "')"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            saldocuenta = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) - montop

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','PRESTAMO'," & montop & "," & montop & ",0," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','" & lblFolio.Text & "','" & cbonombre.Text & "', '" & comentario & "','" & cuentap & "','" & bancocp & "')"
                            cmd1.ExecuteNonQuery()

                        End If
                    Else
                        saldocuenta = -montop

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','PRESTAMO'," & montop & "," & montop & ",0," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','" & lblFolio.Text & "','" & cbonombre.Text & "', '" & comentario & "','" & cuentap & "','" & bancocp & "')"
                        cmd1.ExecuteNonQuery()
                    End If
                    rd2.Close()
                    cnn2.Close()

                Next

                If txtEfectivo.Text > 0 Then
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "insert into SaldosEmpleados(Folio,IdEmpleado,Nombre,Fecha,FechaPago,FechaPagado,Cargo,Abono,Tipo,Concepto,FormaPago,Monto,Nota,Banco,Referencia,Comentario,Cuenta,BancoC,Usuario,Corte,CorteU) values(" & lblFolio.Text & "," & lblid_usu.Text & ",'" & cbonombre.Text & "','" & Format(dtpfecha.Value, "yyyy/MM/dd") & "','" & Format(dtppago.Value, "yyyy/MM/dd") & "',''," & CDbl(txtEfectivo.Text) & ",0,'" & tipo_mov & "','PRESTAMO','EFECTIVO'," & CDbl(txtEfectivo.Text) & ",'" & txtcomentario.Text & "','','','','','','" & lblusuario.Text & "',0,0)"
                    cmd1.ExecuteNonQuery()
                End If

                MsgBox("Préstamo realizado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnnuevo.PerformClick()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString()
                        btnguardar.Focus().Equals(True)
                    End If
                Else
                    MsgBox("No se encuentra el usuario, revisa la contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub
                    rd1.Close() : cnn1.Close()
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        lblid_usu.Text = ""
        lblusuario.Text = ""
        txtcontraseña.Text = ""
        cbonombre.Text = ""
        cbonombre.Items.Clear()
        txtpersonal.Text = "0.00"
        txttrabajo.Text = "0.00"
        txtarea.Text = ""
        txtnss.Text = ""
        txtsueldo.Text = "0.00"
        optpersonal.Checked = False
        opttrabajo.Checked = False
        txtEfectivo.Text = "0.00"
        dtpfecha.Value = Date.Now
        dtppago.Value = Date.Now
        txtsaldo.Text = "0.00"
        txtcomentario.Text = ""
        SiguienteFolio()
        cbonombre.Focus().Equals(True)
        grdpago.Rows.Clear()
        txtPagos.Text = "0.00"
        txtTotal.Text = "0.00"
    End Sub

    Private Sub cbotpago_DropDown(sender As Object, e As EventArgs) Handles cbotpago.DropDown
        Try
            cbotpago.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago from formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbotpago.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbotpago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbotpago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbobanco_DropDown(sender As Object, e As EventArgs) Handles cbobanco.DropDown
        Try
            cbobanco.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Banco FROM bancos WHERE Banco<>'' ORDER BY Banco"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbobanco.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbobanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumref.Focus.Equals(True)
        End If

    End Sub

    Private Sub txtnumref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumref.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmontopago.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtmontopago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmontopago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtmontopago.Text) Then
                txtComentarioPago.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtComentarioPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarioPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuentaRecepcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCuentaRecepcion_DropDown(sender As Object, e As EventArgs) Handles cboCuentaRecepcion.DropDown
        Try
            cboCuentaRecepcion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCuentaRecepcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCuentaRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuentaRecepcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnPagos.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCuentaRecepcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCuentaRecepcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Banco FROM cuentasbancarias WHERE CuentaBan='" & cboCuentaRecepcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboBancoRecepcion.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Dim tipo As String = cbotpago.Text
        Dim banco As String = cbobanco.Text
        Dim referencia As String = txtnumref.Text
        Dim monto As Double = txtmontopago.Text
        Dim fecha As Date = Format(dtpFecha_P.Value, "yyyy-MM-dd")
        Dim cuenta As String = cboCuentaRecepcion.Text
        Dim bancoref As String = cboBancoRecepcion.Text
        Dim comentario As String = txtComentarioPago.Text
        Dim totalpagos As Double = 0

        If tipo = "MONEDERO" Then
            If referencia = "" Then
                MsgBox("Debe ingresar una refrencia", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If monto = 0 Then
                MsgBox("Debe ingresar un monto", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
        Else
            If tipo = "" Then
                MsgBox("Debe seleccionar una forma de pago", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If banco = "" Then
                MsgBox("Debe seleccionar una banco", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If referencia = "" Then
                MsgBox("Debe ingresar una refrencia", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If monto = 0 Then
                MsgBox("Debe ingresar un monto", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
        End If

        grdpago.Rows.Add(tipo, banco, referencia, monto, fecha, comentario, cuenta, bancoref)

        totalpagos = txtPagos.Text + monto
        txtPagos.Text = FormatNumber(totalpagos, 2)

        limpiarforma()
    End Sub

    Public Sub limpiarforma()
        cbotpago.Text = ""
        cbobanco.Text = ""
        txtnumref.Text = ""
        txtmontopago.Text = "0.00"
        cboCuentaRecepcion.Text = ""
        cboBancoRecepcion.Text = ""
        txtComentarioPago.Text = ""
    End Sub

    Private Sub grdpago_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpago.CellDoubleClick
        Dim index As Integer = grdpago.CurrentRow.Index
        Dim importe = grdpago.Rows(index).Cells(3).Value.ToString

        grdpago.Rows.Remove(grdpago.Rows(index))
        txtPagos.Text = txtPagos.Text - CDec(importe)
        txtPagos.Text = FormatNumber(txtPagos.Text, 2)
    End Sub

    Private Sub txtPagos_TextChanged(sender As Object, e As EventArgs) Handles txtPagos.TextChanged
        txtTotal.Text = CDbl(IIf(txtEfectivo.Text = "", 0, txtEfectivo.Text)) + CDbl(IIf(txtPagos.Text = "", 0, txtPagos.Text))
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class