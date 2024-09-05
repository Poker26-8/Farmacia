Public Class frmAnticipoProv

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NComercial from Proveedores where NComercial<>'' order by NComercial"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboNombre.Items.Add(
                        rd1(0).ToString
                        )
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Compania,RFC from Proveedores where NComercial='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtrazon.Text = rd1("Compania").ToString
                    txtrfc.Text = rd1("RFC").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpfecha.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpfecha.KeyPress
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

    Private Sub txtefectivo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtefectivo.KeyPress
        If Not IsNumeric(txtefectivo.Text) Then txtefectivo.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbotipo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbotipo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbotipo.Text = "" Then txtefectivo.Focus().Equals(True) : Exit Sub
            cbobanco.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbobanco_DropDown(sender As System.Object, e As System.EventArgs) Handles cbobanco.DropDown
        cbobanco.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Banco from Bancos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbobanco.Items.Add(
                        rd1(0).ToString
                        )
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbobanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtreferencia.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpagos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpagos.TextChanged
        If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"
        If txtpagos.Text = "" Then txtpagos.Text = "0.00"
        txttotal.Text = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)
        txttotal.Text = FormatNumber(txttotal.Text, 2)
    End Sub

    Private Sub txtefectivo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtefectivo.TextChanged
        If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"
        If txtpagos.Text = "" Then txtpagos.Text = "0.00"
        txttotal.Text = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)
        txttotal.Text = FormatNumber(txttotal.Text, 2)
    End Sub

    Private Sub txtreferencia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtreferencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmonto.Focus().Equals(True)
        End If
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
        If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbotipo.Text <> "" And cbobanco.Text <> "" And txtreferencia.Text <> "" And CDbl(txtmonto.Text) <> 0 Then
                grdPagos.Rows.Add(
                    cbotipo.Text,
                    cbobanco.Text,
                    txtreferencia.Text,
                    FormatNumber(txtmonto.Text, 2)
                    )

                Dim pagos As Double = 0
                For t As Integer = 0 To grdPagos.Rows.Count - 1
                    pagos = pagos + CDbl(grdPagos.Rows(t).Cells(3).Value.ToString)
                Next

                txtpagos.Text = FormatNumber(pagos, 2)
            End If
            cbotipo.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        cboNombre.Items.Clear()
        cboNombre.Text = ""
        txtrazon.Text = ""
        txtrfc.Text = ""
        dtpfecha.Value = Date.Now
        cbotipo.Text = ""
        cbobanco.Text = ""
        txtreferencia.Text = ""
        txtmonto.Text = "0.00"
        txtefectivo.Text = "0.00"
        txtpagos.Text = "0.00"
        txttotal.Text = "0.00"
        grdPagos.Rows.Clear()
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub txtusuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim id_usuario As Integer = 0

            If txtusuario.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IdEmpleado from Usuarios where Clave='" & txtusuario.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            'lblusuario.Text = rd1("Alias").ToString
                            id_usuario = rd1("IdEmpleado").ToString
                        End If
                    Else
                        MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                    rd1.Close()

                    Dim per_anticipo As Boolean = False

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Comp_Anti from Permisos where IdEmpleado=" & id_usuario
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            per_anticipo = rd1("Comp_Anti").ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                    If Not (per_anticipo) Then
                        MsgBox("No cuentas con permiso para realizar anticipos a proveedores." & vbNewLine & "Consulta a tu administrador.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        Dim id_usuario As Integer = 0

        If txtrazon.Text = "" Then MsgBox("Se requieren los datos completos del proveedor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If CDbl(txtpagos.Text) > 0 Then
            If grdPagos.Rows.Count = 0 Then
                MsgBox("Proceso incorrecto para agregar pagos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtpagos.Text = "0.00"
                cbotipo.Focus().Equals(True)
                Exit Sub
            End If
        End If

        If txtusuario.Text = "" Then MsgBox("Ingresa tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IdEmpleado from Usuarios where Clave='" & txtusuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    'lblusuario.Text = rd1("Alias").ToString
                    id_usuario = rd1("IdEmpleado").ToString
                End If
            Else
                MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close()
                cnn1.Close()
                txtusuario.Focus().Equals(True)
                Exit Sub
            End If
            rd1.Close()

            Dim per_anticipo As Boolean = False

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Comp_Anti from Permisos where IdEmpleado=" & id_usuario
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    per_anticipo = rd1("Comp_Anti").ToString
                End If
            End If
            rd1.Close()

            If Not (per_anticipo) Then
                MsgBox("No cuentas con permiso para realizar anticipos a proveedores." & vbNewLine & "Consulta a tu administrador.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close() : Exit Sub
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        If MsgBox("¿Deseas guardar este anticipo al proveedor " & cboNombre.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            If cboNombre.Text <> "" Then
                Dim id_prov As Integer = 0
                Dim MyTotal As Double = 0
                Dim MySaldo As Double = 0
                MyTotal = CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Id from Proveedores where NComercial='" & cboNombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            id_prov = rd1("Id").ToString
                        End If
                    Else
                        MsgBox("Ocurrió un error al extraer la información del proveedor, corrobora los datos e inténtalo de nuevo más tarde." & vbNewLine & "Sí el problema persiste comunícate con tu proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where IdProv=" & id_prov & ")"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = CDbl(If(rd1(0).ToString = "", 0, rd1(0).ToString)) - MyTotal
                        End If
                    Else
                        MySaldo = -MyTotal
                    End If
                    rd1.Close()

                    Dim tarjeta As Double = 0
                    Dim tarnsfe As Double = 0
                    Dim otro As Double = 0
                    Dim banco As String = ""
                    Dim refer As String = ""

                    If CDbl(txtpagos.Text) > 0 Then
                        For y As Integer = 0 To grdPagos.Rows.Count - 1
                            Dim tipo As String = grdPagos.Rows(y).Cells(0).Value.ToString
                            If tipo = "TARJETA" Then
                                tarjeta = tarjeta + CDbl(grdPagos.Rows(y).Cells(3).Value.ToString)
                            End If
                            If tipo = "TRANSFERENCIA" Then
                                tarjeta = tarjeta + CDbl(grdPagos.Rows(y).Cells(3).Value.ToString)
                            End If
                            If tipo = "OTRO" Then
                                tarjeta = tarjeta + CDbl(grdPagos.Rows(y).Cells(3).Value.ToString)
                            End If
                            banco = banco & " -" & CStr(grdPagos.Rows(y).Cells(1).Value.ToString)
                            refer = refer & " -" & CStr(grdPagos.Rows(y).Cells(2).Value.ToString)
                        Next
                    End If

                    If CDbl(txtpagos.Text) > 0 Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Fecha,Hora,Folio) values('Anticipo a proveedor','" & banco & "','" & refer & "','Anticipo'," & CDbl(txtpagos.Text) & "," & CDbl(txtpagos.Text) & ",0,'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','')"
                        cmd1.ExecuteNonQuery()
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,FechaCompleta,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('','',''," & id_prov & ",'" & txtrazon.Text & "','ANTICIPO','" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(dtpfecha.Value, "yyyy-MM-dd HH:mm:ss") & "',0," & MyTotal & "," & MySaldo & "," & CDbl(txtefectivo.Text) & "," & tarjeta & "," & tarnsfe & "," & otro & ",'" & banco & "','" & refer & "','',0,0,0)"
                    If cmd1.ExecuteNonQuery Then
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE Proveedores SET Saldo=Saldo + " & MyTotal & " WHERE NComercial='" & cboNombre.Text & "'"
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("Anticipo registrado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        btnnuevo.PerformClick()
                    End If

                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub cbotipo_DropDown(sender As Object, e As EventArgs) Handles cbotipo.DropDown
        cbotipo.Items.Clear()
        cbotipo.Items.Add("TARJETA")
        cbotipo.Items.Add("TRANSFERENCIA")
        cbotipo.Items.Add("DEPOSITO")
        cbotipo.Items.Add("OTRO")
    End Sub

    Private Sub frmAnticipoProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class