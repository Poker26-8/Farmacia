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
                    "select * from SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='PRESTAMO'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtprestamo.Text = FormatNumber(IIf(rd1("Monto").ToString() = "", 0, rd1("Monto").ToString()), 2)
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
            txtmonto.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofolio_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbofolio.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='PRESTAMO'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtprestamo.Text = FormatNumber(IIf(rd1("Monto").ToString() = "", 0, rd1("Monto").ToString()), 2)
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

    Private Sub txtmonto_Click(sender As System.Object, e As System.EventArgs) Handles txtmonto.Click
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub txtmonto_GotFocus(sender As Object, e As System.EventArgs) Handles txtmonto.GotFocus
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = "0" : Exit Sub
            txtmonto.Text = FormatNumber(txtmonto.Text, 2)
            txtcomentario.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcomentario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub
        If lblid_usu.Text = "" Then MsgBox("Selecciona un empleado para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
        If CDbl(txtmonto.Text) <= 0 Then MsgBox("El monto de abono no puede ser menor o igual a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonto.Focus().Equals(True) : Exit Sub
        If CDbl(txtmonto.Text) > CDbl(txtresta.Text) Then MsgBox("El abono al préstamo no puede ser mayor al monto restante.", vbInformation + vbOKOnly, "")
        If ValidaPermisos(lblusuario.Text, "Ing_CEmp") = False Then MsgBox("No cuentas con permisos para realizar este movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocioss Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar este abono a préstamo?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                Dim id_pres As Integer = 0
                Dim tipo_mov As String = ""
                Dim prestamo As Double = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from SaldosEmpleados where Folio=" & cbofolio.Text & " and Concepto='PRESTAMO' and Estado=0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_pres = rd1("Id").ToString()
                        tipo_mov = rd1("Tipo").ToString()
                        prestamo = rd1("Monto").ToString()
                    End If
                End If
                rd1.Close()

                MsgBox(id_pres)
                MsgBox(tipo_mov)
                MsgBox(prestamo)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into SaldosEmpleados(Folio,IdEmpleado,Nombre,Fecha,FechaPago,FechaPagado,Cargo,Abono,Tipo,Concepto,Monto,Nota,Usuario,Corte,CorteU) values(" & cbofolio.Text & "," & lblid_usu.Text & ",'" & cbonombre.Text & "','" & dtpfecha.Value & "','" & dtppago.Value & "','',0," & CDbl(txtmonto.Text) & ",'" & tipo_mov & "','COBRO'," & CDbl(txtmonto.Text) & ",'" & txtcomentario.Text & "','" & lblusuario.Text & "',0,0)"
                If cmd1.ExecuteNonQuery() Then

                End If

                If CDbl(txtmonto.Text) >= prestamo Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update SaldosEmpleados set Estado=1 where Id=" & id_pres
                    cmd1.ExecuteNonQuery()
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
        txtmonto.Text = "0.00"
        txtprestamo.Text = "0.00"
        txtresta.Text = "0.00"
        txtcomentario.Text = ""
        cbonombre.Focused.Equals(True)
    End Sub
End Class