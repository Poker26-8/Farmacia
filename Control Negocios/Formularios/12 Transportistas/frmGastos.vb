Public Class frmGastos
    Private Sub frmGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        dtpFecha_P.Value = Date.Now
    End Sub

    Private Sub cboiPlaca_DropDown(sender As Object, e As EventArgs) Handles cboiPlaca.DropDown
        Try
            cboiPlaca.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Placas FROM transporte WHERE Placas<>'' ORDER BY placas"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboiPlaca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
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

    Private Sub cboArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboArea.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboiPlaca.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboiPlaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboiPlaca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtChofer.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtChofer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChofer.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtModelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtFactura.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFactura.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboConcepto.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboConcepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            rtbObservaciones.Focus.Equals(True)
        End If
    End Sub

    Private Sub rtbObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtbObservaciones.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSubtotal.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtEfectivo.Text) Then
                btnGuardar.Focus.Equals(True)
            Else
                txtEfectivo.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub cbotpago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbotpago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbobanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtReferencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMonto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtMonto.Text) Then
                txtComentarioPago.Focus.Equals(True)
            Else
                txtMonto.Text = "0.00"
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
        Dim referencia As String = txtReferencia.Text
        Dim monto As Double = txtMonto.Text
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
        txtReferencia.Text = ""
        txtMonto.Text = "0.00"
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If lblUsuario.Text = "" Then MsgBox("Escribe tu contraseña para guardar el movimiento.", vbInformation + vbOKOnly, titulocentral) : txtContraseña.Focus().Equals(True) : Exit Sub

        If txtFactura.Text = "" Then MsgBox("Escribe un folio para guardar el movimiento.", vbInformation + vbOKOnly, titulocentral) : txtFactura.Focus().Equals(True) : Exit Sub

        If CDbl(txtTotal.Text) <= 0 Then MsgBox("Necesitas agregar una cantidad válida para guardar el movimiento.", vbInformation + vbOKOnly, titulocentral) : txtEfectivo.Focus().Equals(True) : Exit Sub

        If cboArea.Text = "" Then MsgBox("Selecciona el tipo de movimiento para guardar.", vbInformation + vbOKOnly, titulocentral) : cboArea.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar este gasto?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                Dim efectivo As Double = 0
                efectivo = txtEfectivo.Text

                Dim subtotal As Double = 0
                subtotal = txtSubtotal.Text

                Dim ivat As Double = 0
                ivat = txtIva.Text

                Dim observaciones As String = ""
                observaciones = rtbObservaciones.Text.TrimEnd(vbCrLf.ToCharArray)

                cnn1.Close() : cnn1.Open()

                For luffy As Integer = 0 To grdpago.Rows.Count - 1

                    Dim formap As String = grdpago.Rows(luffy).Cells(0).Value.ToString
                    Dim bancop As String = grdpago.Rows(luffy).Cells(1).Value.ToString
                    Dim referenciap As String = grdpago.Rows(luffy).Cells(2).Value.ToString
                    Dim montop As Double = grdpago.Rows(luffy).Cells(3).Value.ToString
                    Dim fechap As Date = grdpago.Rows(luffy).Cells(4).Value.ToString
                    Dim comentariop As String = grdpago.Rows(luffy).Cells(5).Value.ToString
                    Dim cuentac As String = grdpago.Rows(luffy).Cells(6).Value.ToString
                    Dim bancocp As String = grdpago.Rows(luffy).Cells(7).Value.ToString

                    Dim fechanueva As String = ""
                    fechanueva = Format(fechap, "yyyy-MM-dd")

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO otrosgastos(Tipo,Concepto,Folio,Fecha,FormaPago,Monto,Total,Nota,Banco,Referencia,Comentario,CuentaC,BancoC,Usuario,Corte,CorteU,Modelo,Placas) values('" & cboArea.Text & "','" & cboConcepto.Text & "','" & txtFactura.Text & "','" & Format(dtpFecha.Value, "yyyy/MM/dd") & "','" & formap & "'," & montop & "," & CDbl(montop) & ",'" & observaciones & "','" & bancop & "','" & referenciap & "','" & comentariop & "','" & cuentac & "','" & bancocp & "','" & lblUsuario.Text & "','0','0','" & txtModelo.Text & "','" & cboiPlaca.Text & "')"
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
                            cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','OTROS GASTOS'," & montop & "," & montop & ",0," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','','" & txtFactura.Text & "','" & comentariop & "','" & cuentac & "','" & bancocp & "')"
                            cmd1.ExecuteNonQuery()
                        End If
                    Else
                        saldocuenta = -montop
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formap & "','" & bancop & "','" & referenciap & "','OTROS GASTOS'," & montop & "," & montop & ",0," & saldocuenta & ",'" & fechanueva & "','" & Format(Date.Now, "HH:mm:ss") & "','" & txtFactura.Text & "','','" & comentariop & "','" & cuentac & "','" & bancocp & "')"
                        cmd1.ExecuteNonQuery()
                    End If
                    rd2.Close()
                    cnn2.Close()

                Next

                If txtEfectivo.Text > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into OtrosGastos(Tipo,Concepto,Folio,Fecha,FormaPago,Monto,Total,Nota,Banco,Referencia,Comentario,CuentaC,BancoC,Usuario,Corte,CorteU,Efectivo,Tarjeta,Transfe,Modelo,Placas) values('" & cboArea.Text & "','" & cboConcepto.Text & "','" & txtFactura.Text & "','" & Format(dtpFecha.Value, "yyyy/MM/dd") & "','EFECTIVO'," & efectivo & "," & efectivo & ",'" & observaciones & "','','','','','','" & lblUsuario.Text & "','0','0',0,0,0,'" & txtModelo.Text & "','" & cboiPlaca.Text & "')"
                    cmd1.ExecuteNonQuery()
                End If
                cnn1.Close()

                cnn2.Close() : cnn2.Open()
                cnn3.Close() : cnn3.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Id from otrosgastos WHERE placas='" & cboiPlaca.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT MAX(Id) FROM otrosgastos WHERE Placas='" & cboiPlaca.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                Dim idmax As Integer = 0
                                idmax = rd3(0).ToString

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "UPDATE otrosgastos SET Subtotal=" & subtotal & ",IVA=" & ivat & " WHERE Id=" & idmax
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()

                    End If
                End If
                rd2.Close()
                cnn2.Close()

                MsgBox("Registro agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                btnNuevo.PerformClick()

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboArea.Text = ""
        cboiPlaca.Text = ""
        txtChofer.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtFactura.Text = ""
        cboConcepto.Text = ""
        rtbObservaciones.Text = ""

        dtpFecha.Value = Date.Now
        txtTotal.Text = "0.00"
        txtEfectivo.Text = "0.00"
        txtPagos.Text = "0.00"

        cbotpago.Text = ""
        cbobanco.Text = ""
        txtReferencia.Text = ""
        txtMonto.Text = "0.00"
        txtComentarioPago.Text = ""
        cboCuentaRecepcion.Text = ""
        cboBancoRecepcion.Text = ""
        dtpFecha_P.Value = Date.Now
        grdpago.Rows.Clear()
        cboArea.Focus.Equals(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtContraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblUsuario.Text = rd1("Alias").ToString()
                        btnGuardar.Focus().Equals(True)
                    End If
                Else
                    MsgBox("No se encuentra el usuario, revisa la contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtContraseña.Focus().Equals(True) : Exit Sub
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

    Private Sub txtEfectivo_Click(sender As Object, e As EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_GotFocus(sender As Object, e As EventArgs) Handles txtEfectivo.GotFocus
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub cboiPlaca_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboiPlaca.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Marca,Chofer,Modelo FROM transporte WHERE Placas='" & cboiPlaca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtMarca.Text = rd1("Marca").ToString
                    txtChofer.Text = rd1("Chofer").ToString
                    txtModelo.Text = rd1("Modelo").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub



    Private Sub txtSubtotal_TextChanged(sender As Object, e As EventArgs) Handles txtSubtotal.TextChanged
        If txtFactura.Text <> "" Then
            Dim iva As Double = 0
            iva = 0.16
            txtIva.Text = CDec(iva) * CDec(IIf(txtSubtotal.Text = "", "0", txtSubtotal.Text))
            txtIva.Text = FormatNumber(txtIva.Text, 2)
        End If

        If txtFactura.Text = "" Then
            Dim iva As Decimal = 0
            iva = 0.0
            txtIva.Text = CDec(iva) * CDec(IIf(txtSubtotal.Text = "", "0", txtSubtotal.Text))
            txtIva.Text = FormatNumber(txtIva.Text, 2)
        End If

        txtSubtotal.Text = txtSubtotal.Text
        txtTotal.Text = CDec(IIf(txtSubtotal.Text = "", "0", txtSubtotal.Text)) + CDec(txtIva.Text)
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)
        '  txtTotal.Focus.Equals(True) : txtTotal.SelectionStart = 0 : txtTotal.MaxLength = 20

        If txtSubtotal.Text = "" Then
            txtTotal.Text = "0.00"
            txtIva.Text = "0.00"
            txtSubtotal.Text = "0.00"
        End If
    End Sub

    Private Sub txtSubtotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubtotal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEfectivo.Focus.Equals(True)
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtSubtotal.Text.IndexOf(".") Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


End Class