Imports System.Net
Imports System.IO

Public Class frmAbonoCompras
    Dim id_prov As Integer = 0

    Dim nLogo As String = ""
    Dim tLogo As String = ""
    Dim simbolo As String = ""

    Private Sub frmAbonoCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        nLogo = DatosRecarga("LogoG")
        tLogo = DatosRecarga("TipoLogo")
        simbolo = DatosRecarga("Simbolo")
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Resta,IdProv from Compras where Proveedor='" & cboproveedor.Text & "' and NumRemision='" & txtremision.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtpagar.Text = FormatNumber(rd1("Resta").ToString, 2)
                    txtresta.Text = FormatNumber(rd1("Resta").ToString, 2)
                    id_prov = rd1("IdProv").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        txtremision.Focus().Equals(True)
    End Sub

    Private Sub txtremision_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtremision.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtremision.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Resta,IdProv from Compras where Proveedor='" & cboproveedor.Text & "' and NumRemision='" & txtremision.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtpagar.Text = FormatNumber(rd1("Resta").ToString, 2)
                            txtresta.Text = FormatNumber(rd1("Resta").ToString, 2)
                            id_prov = rd1("IdProv").ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                txtefectivo.Focus().Equals(True)
            End If
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
            cbotipo.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbotipo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbotipo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbotipo.Text = "" Then
                btnguardar.Focus().Equals(True)
            Else
                cbobanco.Focus().Equals(True)
            End If
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
                If rd1.HasRows Then cbobanco.Items.Add(
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

    Private Sub cbobanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbobanco.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtrefe.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtrefe_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrefe.KeyPress
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

    Private Sub txtmonto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbotipo.Text = "" Or cbobanco.Text = "" Or txtrefe.Text = "" Then MsgBox("Faltan datos para continuar con el pago.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Dim pagos As Double = 0
            grdpagos.Rows.Add(cbotipo.Text, cbobanco.Text, txtrefe.Text, FormatNumber(txtmonto.Text, 2))
            grdpagos.Refresh()

            For t As Integer = 0 To grdpagos.Rows.Count - 1
                pagos = pagos + CDbl(grdpagos.Rows(t).Cells(3).Value.ToString)
            Next
            txtpagos.Text = FormatNumber(pagos, 2)

            cbotipo.Text = ""
            cbobanco.Text = ""
            txtrefe.Text = ""
            txtmonto.Text = "0.00"
        End If
    End Sub

    Private Sub txtpagos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpagos.TextChanged
        If txtpagos.Text = "" Then txtpagos.Text = "0.00"
        If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"
        If txtpagar.Text = "" Then txtpagar.Text = "0.00"
        If txtresta.Text = "" Then txtresta.Text = "0.00"

        txtresta.Text = CDbl(txtpagar.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtefectivo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtefectivo.TextChanged
        If txtpagos.Text = "" Then txtpagos.Text = "0.00"
        If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"
        If txtpagar.Text = "" Then txtpagar.Text = "0.00"
        If txtresta.Text = "" Then txtresta.Text = "0.00"

        txtresta.Text = CDbl(txtpagar.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub txtresta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtresta.TextChanged
        If CDbl(txtresta.Text) < 0 Then
            MsgBox("El monto abonado no puede ser superiror al total del pago.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtefectivo.Text = "0.00"
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        cboproveedor.Items.Clear()
        cboproveedor.Text = ""
        txtremision.Text = ""
        txtusuario.Text = ""
        txtpagar.Text = "0.00"
        txtresta.Text = "0.00"
        txtefectivo.Text = "0.00"
        txtpagos.Text = "0.00"
        dtpfecha.Value = Date.Now
        cbotipo.Text = ""
        cbobanco.Items.Clear()
        cbobanco.Text = ""
        txtrefe.Text = ""
        txtmonto.Text = "0.00"
        grdpagos.Rows.Clear()
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        If lblUsuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Exit Sub

        Dim id_usuario As Integer = 0

        cnn1.Close() : cnn1.Open()

        Dim per_abono As Boolean = False

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT IdEmpleado FROM Usuarios WHERE Alias='" & lblUsuario.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                id_usuario = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Comp_Abon from Permisos where IdEmpleado=" & id_usuario
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                per_abono = rd1("Comp_Abon").ToString
            End If
        End If
        rd1.Close() : cnn1.Close()

        If Not (per_abono) Then
            MsgBox("No cuentas con permiso para realizar abonos a compras." & vbNewLine & "Consulta a tu administardor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        If CDbl(txtpagos.Text) > 0 Then
            If grdpagos.Rows.Count = 0 Then MsgBox("Procedimiento erróneo para abonar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            ' txtpagos.Text = "0.00"
            txtpagos.Focus().Equals(True)
        End If

        If MsgBox("¿Deseas guardar el abono de esta compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") Then
            Dim num_fac As String = ""
            Dim num_ped As String = ""

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumRemision from Compras where NumRemision='" & txtremision.Text & "' and Status='PAGADO' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("La compra con remisión " & txtremision.Text & " ya fue pagada en su totalidad.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumRemision from Compras where NumRemision='" & txtremision.Text & "' and Status='CANCELADA' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("La compra con remisión " & txtremision.Text & " ya fue cancelada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumFactura,NumPedido,IdProv from Compras where NumRemision='" & txtremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        num_fac = rd1("NumFactura").ToString
                        num_ped = rd1("NumPedido").ToString
                        id_prov = rd1("IdProv").ToString
                    End If
                Else
                    MsgBox("La compra con remisión " & txtremision.Text & " no existe.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()

                Dim MyPago As Double = 0
                Dim MySaldo As Double = 0
                Dim acuenta As Double = 0
                Dim resta As Double = 0

                Dim tarjeta As Double = 0, transfe As Double = 0, otro As Double = 0
                Dim banco As String = "", refer As String = ""
                Dim pagos As Double = 0

                For yu As Integer = 0 To grdpagos.Rows.Count - 1
                    If CStr(grdpagos.Rows(yu).Cells(0).Value.ToString) = "TARJETA" Then
                        tarjeta = tarjeta + CDbl(grdpagos.Rows(yu).Cells(3).Value.ToString)
                    End If
                    If CStr(grdpagos.Rows(yu).Cells(0).Value.ToString) = "TRANSFERENCIA" Then
                        transfe = transfe + CDbl(grdpagos.Rows(yu).Cells(3).Value.ToString)
                    End If
                    If CStr(grdpagos.Rows(yu).Cells(0).Value.ToString) = "OTRO" Then
                        otro = otro + CDbl(grdpagos.Rows(yu).Cells(3).Value.ToString)
                    End If
                    If CStr(grdpagos.Rows(yu).Cells(1).Value.ToString) <> "" Then
                        banco = banco & "-" & grdpagos.Rows(yu).Cells(1).Value.ToString
                    End If
                    If CStr(grdpagos.Rows(yu).Cells(2).Value.ToString) <> "" Then
                        refer = refer & "-" & grdpagos.Rows(yu).Cells(2).Value.ToString
                    End If
                Next
                pagos = tarjeta + transfe + otro


                MyPago = CDbl(txtpagos.Text) + CDbl(txtefectivo.Text)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Resta,ACuenta from Compras where NumRemision='" & txtremision.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        acuenta = rd1(1).ToString
                        resta = rd1(0).ToString

                        cnn2.Close() : cnn2.Open()
                        If MyPago < CDbl(rd1(0).ToString) Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update Compras set ACuenta=" & CDbl(acuenta + MyPago) & " where NumRemision='" & txtremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                            cmd2.ExecuteNonQuery()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update Compras set Resta=" & CDbl(resta - MyPago) & " where NumRemision='" & txtremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                            cmd2.ExecuteNonQuery()
                        Else
                            acuenta = acuenta + resta
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update Compras set ACuenta=" & CDbl(acuenta) & " where NumRemision='" & txtremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                            cmd2.ExecuteNonQuery()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update Compras set Resta=0, Status='PAGADO' where NumRemision='" & txtremision.Text & "' and Proveedor='" & cboproveedor.Text & "'"
                            cmd2.ExecuteNonQuery()
                        End If
                        cnn2.Close()
                    End If
                End If
                rd1.Close()



                If pagos > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Fecha,Hora,Folio) values('Compra','" & banco & "','" & refer & "','COMPRA'," & pagos & "," & pagos & ",0,'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & txtremision.Text & "')"
                    cmd1.ExecuteNonQuery()
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "select Saldo from AbonoE where Id=(select max(Id) from AbonoE where Proveedor='" & cboproveedor.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = CDbl(IIf(rd1(0).ToString = "", 0, rd1(0).ToString)) - MyPago
                    End If
                Else
                    MySaldo = MyPago
                End If
                rd1.Close()


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,FechaCompleta,Cargo,Saldo,Abono,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & txtremision.Text & "','" & num_fac & "','" & num_ped & "'," & id_prov & ",'" & cboproveedor.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "',0," & MySaldo & ",'" & CDbl(MyPago) & "'," & CDbl(txtefectivo.Text) & "," & tarjeta & "," & transfe & "," & otro & ",'" & banco & "','" & refer & "','" & lblUsuario.Text & "',0,0,0)"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Abono a compra registardo correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    frmCtsPagar.txtresta.Text = FormatNumber(txtresta.Text, 2)
                    cnn1.Close()

                    If MsgBox("¿Deseas imprimir comprobante?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                        Dim ImprimeEn As String = ""
                        Dim Impresora As String = ""
                        Dim tPapel As String = ""
                        Dim tMilimetros As String = ""

                        cnn1.Close() : cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Formato from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Compras'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                tPapel = rd1(0).ToString
                            End If
                        Else
                            MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de ventas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd1.Close()
                            cnn1.Close()
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select NotasCred from Formatos where Facturas='TamImpre'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                tMilimetros = rd1(0).ToString
                            End If
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & tPapel & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                Impresora = rd1(0).ToString
                            End If
                        Else
                            If tPapel = "MEDIA CARTA" Then
                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    If rd2.Read Then
                                        Impresora = rd2(0).ToString()
                                    End If
                                Else
                                    MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                End If
                                rd2.Close() : cnn2.Close()
                            End If
                            cnn1.Close()
                        End If
                        rd1.Close() : cnn1.Close()

                        If tPapel = "TICKET" Then
                            If tMilimetros = "80" Then
                                pTicket80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                                pTicket80.Print()
                            End If
                            If tMilimetros = "58" Then
                                pTicket58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                                pTicket58.Print()
                            End If
                        Else
                        End If
                    End If

                    Call frmCtsPagar.cboremision_KeyPress(frmCtsPagar.cboremision, New KeyPressEventArgs(ChrW(Keys.Enter)))
                    frmCtsPagar.btnabono.Enabled = True
                    btnnuevo.PerformClick()
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtusuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblUsuario.Text = rd1("Alias").ToString

                    End If
                Else
                    MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()

                'PERMISO PARA ABONAR A COMPRAS (PENDIENTE)
                '
                '

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboproveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboproveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub cbotipo_DropDown(sender As Object, e As EventArgs) Handles cbotipo.DropDown
        cbotipo.Items.Clear()
        cbotipo.Items.Add("TARJETA")
        cbotipo.Items.Add("TRANSFERENCIA")
        cbotipo.Items.Add("DEPOSITO")
        cbotipo.Items.Add("OTRO")
    End Sub

    Private Sub pTicket80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pTicket80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim Logotipo As Drawing.Image = Nothing

        Dim Pie As String = ""

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 130
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Pie2,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()


        '[1]. Datos de la compra
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("PAGO DE COMPRA", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12

        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18
        e.Graphics.DrawString("Fecha: " & Date.Now, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 13.5
        e.Graphics.DrawString("Usuario: " & lblUsuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 17
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 12
        e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7.5
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Cliente: " & cboproveedor.Text, fuente_datos, Brushes.Black, 1, Y)
        Y += 13.5
        e.Graphics.DrawString("N° Remisión: " & txtremision.Text, fuente_datos, Brushes.Black, 1, Y)
        Y += 13.5
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 20

        Dim MyPago As Double = (CDbl(txtefectivo.Text) - CDbl(TextBox1.Text)) + CDbl(txtpagos.Text)

        e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(MyPago, 2), fuente_prods, Brushes.Black, 285, Y, sf)
        Y += 17

        If CDbl(txtefectivo.Text) <> 0 Then
            e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 15, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
        End If
        If CDbl(txtpagos.Text) <> 0 Then
            e.Graphics.DrawString("Pagos:", fuente_prods, Brushes.Black, 15, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtpagos.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
        End If
        e.HasMorePages = False
    End Sub
End Class