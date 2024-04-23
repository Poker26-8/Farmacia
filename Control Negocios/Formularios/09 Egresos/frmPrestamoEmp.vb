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
                "select * from Usuarios where Nombre='" & cbonombre.Text & "'"
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

    Private Sub txtmonto_Click(sender As System.Object, e As System.EventArgs) Handles txtmonto.Click
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub txtmonto_GotFocus(sender As Object, e As System.EventArgs) Handles txtmonto.GotFocus
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
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
                    "select * from Usuarios where Nombre='" & cbonombre.Text & "'"
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
                rd1.Close() : cnn1.Close()

                txtpersonal.Text = FormatNumber(cargo_p - abono_p, 2)
                txttrabajo.Text = FormatNumber(cargo_t - abono_t, 2)
                txtsaldo.Text = FormatNumber(CDbl(txtpersonal.Text) + CDbl(txttrabajo.Text), 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            txtmonto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = "0" : Exit Sub
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
        If CDbl(txtmonto.Text) <= 0 Then MsgBox("El monto del préstamo no puede ser menor o igual a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonto.Focus().Equals(True) : Exit Sub
        If ValidaPermisos(lblusuario.Text, "Egr_PEmp") = False Then MsgBox("No cuentas con permisos para realizar este movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar este préstamo?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim tipo_mov As String = ""


            If optpersonal.Checked = True Then
                tipo_mov = "PERSONAL"
            End If
            If opttrabajo.Checked = True Then
                tipo_mov = "TRABAJO"
            End If

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into SaldosEmpleados(Folio,IdEmpleado,Nombre,Fecha,FechaPago,FechaPagado,Cargo,Abono,Tipo,Concepto,Monto,Nota,Usuario,Corte,CorteU) values(" & lblFolio.Text & "," & lblid_usu.Text & ",'" & cbonombre.Text & "','" & Format(dtpfecha.Value, "yyyy/MM/dd") & "','" & Format(dtppago.Value, "yyyy/MM/dd") & "',''," & CDbl(txtmonto.Text) & ",0,'" & tipo_mov & "','PRESTAMO'," & CDbl(txtmonto.Text) & ",'" & txtcomentario.Text & "','" & lblusuario.Text & "',0,0)"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Préstamo realizado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnnuevo.PerformClick()
                End If
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
        txtmonto.Text = "0.00"
        dtpfecha.Value = Date.Now
        dtppago.Value = Date.Now
        txtsaldo.Text = "0.00"
        txtcomentario.Text = ""
        SiguienteFolio()
        cbonombre.Focus().Equals(True)
    End Sub


End Class