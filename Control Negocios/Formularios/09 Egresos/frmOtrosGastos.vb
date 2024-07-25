Public Class frmOtrosGastos

    Private Sub cbotipo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbotipo.DropDown
        cbotipo.Items.Clear()
        cbotipo.Items.Add("ADMINISTRACION")
        cbotipo.Items.Add("OPERACION")
        cbotipo.Items.Add("VENTAS")
    End Sub

    Private Sub frmOtrosGastos_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtfolio.Focus().Equals(True)
    End Sub

    Private Sub txtfolio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtfolio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboconcepto.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboconcepto_DropDown(sender As System.Object, e As System.EventArgs) Handles cboconcepto.DropDown
        cboconcepto.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Concepto from OtrosGastos order by Concepto"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboconcepto.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboconcepto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboconcepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtefectivo_Click(sender As System.Object, e As System.EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtefectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtefectivo.Text) Then txtefectivo.Text = "0"
            txtefectivo.Text = FormatNumber(txtefectivo.Text, 2)
            txttotal.Text = FormatNumber(txtefectivo.Text, 2)
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttarjeta_Click(sender As System.Object, e As System.EventArgs) Handles txtpagos.Click
        txtpagos.SelectionStart = 0
        txtpagos.SelectionLength = Len(txtpagos.Text)
    End Sub

    Private Sub txttarjeta_GotFocus(sender As Object, e As System.EventArgs) Handles txtpagos.GotFocus
        txtpagos.SelectionStart = 0
        txtpagos.SelectionLength = Len(txtpagos.Text)
    End Sub

    Private Sub txttarjeta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpagos.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtpagos.Text) Then txtpagos.Text = "0"
            txtpagos.Text = FormatNumber(txtpagos.Text, 2)
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtefectivo_LostFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.LostFocus
        If Not IsNumeric(txtefectivo.Text) Then Exit Sub
        If Not IsNumeric(txtpagos.Text) Then Exit Sub
        txttotal.Text = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)
    End Sub

    Private Sub txtcomentario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomentario.KeyPress

        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
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

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub
        If txtfolio.Text = "" Then MsgBox("Escribe un folio para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtfolio.Focus().Equals(True) : Exit Sub
        If cboconcepto.Text = "" Then MsgBox("Escribe o selecciona el concepto del gasto para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboconcepto.Focus().Equals(True) : Exit Sub
        If CDbl(txttotal.Text) <= 0 Then MsgBox("Necesitas agregar una cantidad válida para guardar el movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtefectivo.Focus().Equals(True) : Exit Sub
        If cbotipo.Text = "" Then MsgBox("Selecciona el tipo de movimiento para guardar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbotipo.Focus().Equals(True) : Exit Sub
        If ValidaPermisos(lblusuario.Text, "Egr_Otro") = False Then MsgBox("No cuentas con permisos para realizar este movimiento.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar este gasto?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try

                Dim efectivo As Double = 0
                efectivo = txtefectivo.Text
                cnn1.Close() : cnn1.Open()
                For luffy As Integer = 0 To grdpago.Rows.Count - 1

                    Dim formap As String = grdpago.Rows(luffy).Cells(0).Value.ToString
                    Dim bancop As String = grdpago.Rows(luffy).Cells(1).Value.ToString
                    Dim referenciap As String = grdpago.Rows(luffy).Cells(2).Value.ToString
                    Dim montop As String = grdpago.Rows(luffy).Cells(3).Value.ToString
                    Dim fechap As Date = grdpago.Rows(luffy).Cells(4).Value.ToString
                    Dim comentariop As String = grdpago.Rows(luffy).Cells(5).Value.ToString
                    Dim cuentac As String = grdpago.Rows(luffy).Cells(6).Value.ToString
                    Dim bancocp As String = grdpago.Rows(luffy).Cells(7).Value.ToString

                    Dim fechanueva As String = ""
                    fechanueva = Format(fechap, "yyyy-MM-dd")

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO otrosgastos(Tipo,Concepto,Folio,Fecha,FormaPago,Monto,Total,Nota,Banco,Referencia,Comentario,CuentaC,BancoC,Usuario,Corte,CorteU) values('" & cbotipo.Text & "','" & cboconcepto.Text & "','" & txtfolio.Text & "','" & Format(dtpfecha.Value, "yyyy/MM/dd") & "','" & formap & "'," & montop & "," & CDbl(montop) & ",'" & txtcomentario.Text & "','" & bancop & "','" & referenciap & "','" & comentariop & "','" & cuentac & "','" & bancocp & "','" & lblusuario.Text & "','0','0')"
                    cmd1.ExecuteNonQuery()

                    Dim saldocuenta As Double = 0

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cuentac & "')"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            saldocuenta = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) - montop

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','OTROS GASTOS'," & montop & "," & montop & ",0," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','','" & txtfolio.Text & "','" & comentariop & "','" & cuentac & "','" & bancocp & "')"
                            cmd1.ExecuteNonQuery()
                        End If
                    Else
                        saldocuenta = -montop
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','OTROS GASTOS'," & montop & "," & montop & ",0," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','" & txtfolio.Text & "','','" & comentariop & "','" & cuentac & "','" & bancocp & "')"
                        cmd1.ExecuteNonQuery()
                    End If
                    rd2.Close()
                    cnn2.Close()
                Next

                If txtefectivo.Text > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into OtrosGastos(Tipo,Concepto,Folio,Fecha,FormaPago,Monto,Total,Nota,Banco,Referencia,Comentario,CuentaC,BancoC,Usuario,Corte,CorteU,Efectivo,Tarjeta,Transfe) values('" & cbotipo.Text & "','" & cboconcepto.Text & "','" & txtfolio.Text & "','" & Format(dtpfecha.Value, "yyyy/MM/dd") & "','EFECTIVO'," & efectivo & "," & efectivo & ",'" & txtcomentario.Text & "','','','','','','" & lblusuario.Text & "','0','0',0,0,0)"
                    cmd1.ExecuteNonQuery()

                End If
                MsgBox("Registro agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                btnnuevo.PerformClick()

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        cbotipo.Text = ""
        lblusuario.Text = ""
        txtcontraseña.Text = ""
        txtfolio.Text = ""
        cboconcepto.Text = ""
        cboconcepto.Items.Clear()
        txtefectivo.Text = "0.00"
        txtpagos.Text = "0.00"
        txttotal.Text = "0.00"
        txtcomentario.Text = ""
        dtpfecha.Value = Date.Now
        grdpago.Rows.Clear()
        cboconcepto.Focus().Equals(True)
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

    Private Sub txttarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtpagos.TextChanged
        If Not IsNumeric(txtefectivo.Text) Then Exit Sub
        txttotal.Text = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)
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
            txtmonto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtmonto.Text) Then
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

    Private Sub cboCuentaRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuentaRecepcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnPagos.Focus.Equals(True)
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
        Dim monto As Double = txtmonto.Text
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

        totalpagos = txtpagos.Text + monto
        txtpagos.Text = FormatNumber(totalpagos, 2)


        limpiarforma()
    End Sub

    Public Sub limpiarforma()
        cbotpago.Text = ""
        cbobanco.Text = ""
        txtnumref.Text = ""
        txtmonto.Text = "0.00"
        cboCuentaRecepcion.Text = ""
        cboBancoRecepcion.Text = ""
        txtComentarioPago.Text = ""
    End Sub

    Private Sub grdpago_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpago.CellDoubleClick
        Dim index As Integer = grdpago.CurrentRow.Index

        Dim importe = grdpago.Rows(index).Cells(3).Value.ToString

        grdpago.Rows.Remove(grdpago.Rows(index))
        txtpagos.Text = txtpagos.Text - CDec(importe)
        txtpagos.Text = FormatNumber(txtpagos.Text, 2)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class