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
            txttarjeta.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttarjeta_Click(sender As System.Object, e As System.EventArgs) Handles txttarjeta.Click
        txttarjeta.SelectionStart = 0
        txttarjeta.SelectionLength = Len(txttarjeta.Text)
    End Sub

    Private Sub txttarjeta_GotFocus(sender As Object, e As System.EventArgs) Handles txttarjeta.GotFocus
        txttarjeta.SelectionStart = 0
        txttarjeta.SelectionLength = Len(txttarjeta.Text)
    End Sub

    Private Sub txttarjeta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttarjeta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txttarjeta.Text) Then txttarjeta.Text = "0"
            txttarjeta.Text = FormatNumber(txttarjeta.Text, 2)
            txttransfe.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtefectivo_LostFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.LostFocus
        If Not IsNumeric(txtefectivo.Text) Then Exit Sub
        If Not IsNumeric(txttransfe.Text) Then Exit Sub
        If Not IsNumeric(txttarjeta.Text) Then Exit Sub
        txttotal.Text = CDbl(txtefectivo.Text) + CDbl(txttarjeta.Text) + CDbl(txttransfe.Text)
    End Sub

    Private Sub txttarjeta_LostFocus(sender As Object, e As System.EventArgs) Handles txttarjeta.LostFocus
        If Not IsNumeric(txtefectivo.Text) Then Exit Sub
        If Not IsNumeric(txttransfe.Text) Then Exit Sub
        If Not IsNumeric(txttarjeta.Text) Then Exit Sub
        txttotal.Text = CDbl(txtefectivo.Text) + CDbl(txttarjeta.Text) + CDbl(txttransfe.Text)
    End Sub

    Private Sub txttransfe_Click(sender As System.Object, e As System.EventArgs) Handles txttransfe.Click
        txttransfe.SelectionStart = 0
        txttransfe.SelectionLength = Len(txttransfe.Text)
    End Sub

    Private Sub txttransfe_GotFocus(sender As Object, e As System.EventArgs) Handles txttransfe.GotFocus
        txttransfe.SelectionStart = 0
        txttransfe.SelectionLength = Len(txttransfe.Text)
    End Sub

    Private Sub txttransfe_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttransfe.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txttransfe.Text) Then txttransfe.Text = "0"
            txttransfe.Text = FormatNumber(txttransfe.Text, 2)
            txtcomentario.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttransfe_LostFocus(sender As Object, e As System.EventArgs) Handles txttransfe.LostFocus
        If Not IsNumeric(txtefectivo.Text) Then Exit Sub
        If Not IsNumeric(txttransfe.Text) Then Exit Sub
        If Not IsNumeric(txttarjeta.Text) Then Exit Sub
        txttotal.Text = CDbl(txtefectivo.Text) + CDbl(txttarjeta.Text) + CDbl(txttransfe.Text)
    End Sub

    Private Sub txtcomentario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomentario.KeyPress
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
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into OtrosGastos(Tipo,Concepto,Folio,Fecha,Efectivo,Tarjeta,Transfe,Total,Nota,Usuario,Corte,CorteU) values('" & cbotipo.Text & "','" & cboconcepto.Text & "','" & txtfolio.Text & "','" & Format(dtpfecha.Value, "yyyy/MM/dd") & "'," & CDbl(txtefectivo.Text) & "," & CDbl(txttarjeta.Text) & "," & txttransfe.Text & "," & CDbl(txttotal.Text) & ",'" & txtcomentario.Text & "','" & lblusuario.Text & "','0','0')"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Movimiento de gasto guardado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnnuevo.PerformClick()
                End If

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
        txttarjeta.Text = "0.00"
        txttransfe.Text = "0.00"
        txttotal.Text = "0.00"
        txtcomentario.Text = ""
        dtpfecha.Value = Date.Now
        cboconcepto.Focus().Equals(True)
    End Sub
End Class