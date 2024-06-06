Public Class frmCobroEmp
    Private Sub frmCobroEmp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpfecha.Value = Date.Now
        dtppago.Value = Date.Now
    End Sub

    Private Sub frmCobroEmp_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
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
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim id_usu As Integer = 0

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Nombre='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblid_usu.Text = rd1("IdEmpleado").ToString()
                        id_usu = rd1("IdEmpleado").ToString()
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

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from SaldosEmpleados where IdEmpleado=" & id_usu
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
                rd1.Close()
                cnn1.Close()

                txtpersonal.Text = FormatNumber(cargo_p - abono_p, 2)
                txttrabajo.Text = FormatNumber(cargo_t - abono_t, 2)
                txtglobal.Text = FormatNumber(CDbl(txtpersonal.Text) + CDbl(txttrabajo.Text), 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            cbofolio.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Dim id_usu As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Usuarios where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblid_usu.Text = rd1("IdEmpleado").ToString()
                    id_usu = rd1("IdEmpleado").ToString()
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

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from SaldosEmpleados where IdEmpleado=" & id_usu
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
            rd1.Close()
            cnn1.Close()

            txtpersonal.Text = FormatNumber(cargo_p - abono_p, 2)
            txttrabajo.Text = FormatNumber(cargo_t - abono_t, 2)
            txtglobal.Text = FormatNumber(CDbl(txtpersonal.Text) + CDbl(txttrabajo.Text), 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofolio_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofolio.DropDown
        cbofolio.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Folio from SaldosEmpleados where IdEmpleado=" & lblid_usu.Text & " and Concepto='PRESTAMO' and Estado=0"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbofolio.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofolio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbofolio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbofolio.Text = "" Then Exit Sub
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select SUM(Monto),Fecha,FechaPago from SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='PRESTAMO'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtprestamo.Text = FormatNumber(rd1(0).ToString, 2)
                        dtpfecha.Value = rd1("Fecha").ToString()
                        dtppago.Value = rd1("FechaPago").ToString()
                    End If
                End If
                rd1.Close()

                If Date.Now > dtppago.Value Then MsgBox("Ya pasó la fecha de pago de éste préstamo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                Dim abono As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='COBRO'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        abono = abono + IIf(rd1("Abono").ToString() = "", 0, rd1("Abono").ToString())
                    End If
                Loop
                rd1.Close()

                txtresta.Text = FormatNumber(CDbl(txtprestamo.Text) - abono, 2)
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofolio_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbofolio.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT SUM(Monto),Fecha,FechaPago FROM SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='PRESTAMO'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtprestamo.Text = FormatNumber(rd1(0).ToString, 2)
                    dtpfecha.Value = rd1("Fecha").ToString()
                    dtppago.Value = rd1("FechaPago").ToString()
                End If
            End If
            rd1.Close()

            If Date.Now > dtppago.Value Then MsgBox("Ya pasó la fecha de pago de éste préstamo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

            Dim abono As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='COBRO'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    abono = abono + IIf(rd1("Abono").ToString() = "", 0, rd1("Abono").ToString())
                End If
            Loop
            rd1.Close()

            txtresta.Text = FormatNumber(CDbl(txtprestamo.Text) - abono, 2)
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtmonto_Click(sender As System.Object, e As System.EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtmonto_GotFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtefectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtefectivo.Text) Then txtefectivo.Text = "0" : Exit Sub
            txtcomentario.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcomentario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click

        Dim total As Double = 0
        total = CDbl(txtefectivo.Text) + CDbl(txtPagos.Text)

        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If lblid_usu.Text = "" Then MsgBox("Selecciona un empleado para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub

        If CDbl(txtresta.Text) > 0 Then MsgBox("El monto de abono no puede ser menor o igual a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtefectivo.Focus().Equals(True) : Exit Sub

        If CDbl(total) > CDbl(txtprestamo.Text) Then MsgBox("El abono al préstamo no puede ser mayor al monto restante.", vbInformation + vbOKOnly, "")
        If ValidaPermisos(lblusuario.Text, "Ing_CEmp") = False Then MsgBox("No cuentas con permisos para realizar este movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocioss Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar este abono a préstamo?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                Dim id_pres As Integer = 0
                Dim tipo_mov As String = ""
                Dim prestamo As Double = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT SUM(Monto),Id,Tipo FROM SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='PRESTAMO' and Estado=0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_pres = rd1("Id").ToString()
                        tipo_mov = rd1("Tipo").ToString()
                        prestamo = rd1(0).ToString()
                    End If
                End If
                rd1.Close()

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
                    fechanueva = Format(fecha, "yyyy-MM-dd")

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into SaldosEmpleados(Folio,IdEmpleado,Nombre,Fecha,FechaPago,FechaPagado,Cargo,Abono,Tipo,Concepto,FormaPago,Monto,Nota,Banco,Referencia,Comentario,Cuenta,BancoC,Usuario,Corte,CorteU) values(" & cbofolio.Text & "," & lblid_usu.Text & ",'" & cbonombre.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(dtppago.Value, "yyyy-MM-dd") & "','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "',0," & montop & ",'" & tipo_mov & "','COBRO','" & formap & "'," & montop & ",'" & txtcomentario.Text & "','" & bancop & "','" & referenciap & "','" & comentario & "','" & cuentap & "','" & bancocp & "','" & lblusuario.Text & "',0,0)"
                    cmd1.ExecuteNonQuery()

                    Dim saldocuenta As Double = 0

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cuentap & "')"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            saldocuenta = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) + montop

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','COBRO PRESTAMO'," & montop & ",0," & montop & "," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','" & cbofolio.Text & "','" & comentario & "','" & cuentap & "','" & bancocp & "')"
                            cmd1.ExecuteNonQuery()

                        End If
                    Else
                        saldocuenta = -montop

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','COBRO PRESTAMO'," & montop & ",0," & montop & "," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','" & cbofolio.Text & "','" & comentario & "','" & cuentap & "','" & bancocp & "')"
                        cmd1.ExecuteNonQuery()

                    End If
                    rd2.Close()
                    cnn2.Close()

                Next
                If txtefectivo.Text > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into SaldosEmpleados(Folio,IdEmpleado,Nombre,Fecha,FechaPago,FechaPagado,Cargo,Abono,Tipo,Concepto,FormaPago,Monto,Nota,Banco,Referencia,Comentario,Cuenta,BancoC,Usuario,Corte,CorteU) values(" & cbofolio.Text & "," & lblid_usu.Text & ",'" & cbonombre.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(dtppago.Value, "yyyy-MM-dd") & "','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "',0," & CDbl(txtefectivo.Text) & ",'" & tipo_mov & "','COBRO','EFECTIVO'," & CDbl(txtefectivo.Text) & ",'" & txtcomentario.Text & "','','','','','','" & lblusuario.Text & "',0,0)"
                    cmd1.ExecuteNonQuery()
                End If



                If CDbl(txtefectivo.Text) + CDbl(txtPagos.Text) >= prestamo Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE SaldosEmpleados SET Estado=1 where Id=" & id_pres
                    cmd1.ExecuteNonQuery()
                End If
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
                    "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString()
                        btnguardar.Focus().Equals(True)
                    End If
                Else
                    MsgBox("No se encuentra el usuario, revisa la contraseña.", vbInformation + vbOKOnly, "Delsscom Contol Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub
                    rd1.Close() : cnn1.Close()
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        cbonombre.Text = ""
        txtarea.Text = ""
        txtnss.Text = ""
        txtsueldo.Text = "0.00"
        txtpersonal.Text = "0.00"
        txttrabajo.Text = "0.00"
        txtglobal.Text = "0.00"
        cbofolio.Text = ""
        txtefectivo.Text = "0.00"
        txtprestamo.Text = "0.00"
        txtresta.Text = "0.00"
        txtcomentario.Text = ""
        cbonombre.Focused.Equals(True)
        txtPagos.Text = "0.00"
        grdpago.Rows.Clear()
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

    Private Sub cbotpago_DropDown(sender As Object, e As EventArgs) Handles cbotpago.DropDown
        Try
            cbotpago.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
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
            cmd5.CommandText = "SELECT DISTINCT(Banco) FROM bancos WHERE Banco<>'' ORDER BY Banco"
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

    Private Sub grdpago_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpago.CellDoubleClick
        Dim index As Integer = grdpago.CurrentRow.Index

        Dim importe = grdpago.Rows(index).Cells(3).Value.ToString

        grdpago.Rows.Remove(grdpago.Rows(index))
        txtpagos.Text = txtpagos.Text - CDec(importe)
        txtpagos.Text = FormatNumber(txtpagos.Text, 2)
    End Sub

    Private Sub txtPagos_TextChanged(sender As Object, e As EventArgs) Handles txtPagos.TextChanged

        txtresta.Text = CDbl(IIf(txtprestamo.Text = "", 0, txtprestamo.Text)) - CDbl(CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtPagos.Text = "", 0, txtPagos.Text)))

        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As EventArgs) Handles txtefectivo.TextChanged
        If Strings.Left(txtefectivo.Text, 1) = "," Or Strings.Left(txtefectivo.Text, 1) = "." Then Exit Sub

        txtresta.Text = CDbl(IIf(txtprestamo.Text = "", 0, txtprestamo.Text)) - (CDbl(IIf(txtefectivo.Text = "", 0, txtefectivo.Text)) + CDbl(IIf(txtPagos.Text = "", 0, txtPagos.Text)))

        If txtresta.Text < 0 Then
            txtresta.Text = FormatNumber(-txtresta.Text, 2)
        Else
            txtresta.Text = FormatNumber(txtresta.Text, 2)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class