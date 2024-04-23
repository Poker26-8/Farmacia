Imports Core.DAL33

Public Class frmAbonoNotas
    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Cliente from Ventas where Cliente<>'' and Status='RESTA' order by Cliente"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IdCliente from Ventas where Cliente='" & cbonombre.Text & "' and IdCliente<>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblid_usu.Text = IIf(rd1(0).ToString = 0, "MOSTRADOR", rd1(0).ToString())
                End If
            Else
                lblid_usu.Text = "MOSTRADOR"
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtfolios.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtfolios_Click(sender As System.Object, e As System.EventArgs) Handles txtfolios.Click
        txtfolios.SelectionStart = 0
        txtfolios.SelectionLength = Len(txtfolios.Text)
    End Sub

    Private Sub txtfolios_GotFocus(sender As Object, e As System.EventArgs) Handles txtfolios.GotFocus
        txtfolios.SelectionStart = 0
        txtfolios.SelectionLength = Len(txtfolios.Text)
    End Sub

    Private Sub txtfolios_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtfolios.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                If Strings.Right(txtfolios.Text, 1) = "," Then txtfolios.Text = Mid(txtfolios.Text, 1, Len(txtfolios.Text) - 1)
                If txtfolios.Text = "" Then Exit Sub

                Dim NNV As Integer = 0
                Dim Remision(10) As String

                Do While Strings.Left(txtfolios.Text, 1) = ","
                    txtfolios.Text = Mid(txtfolios.Text, 2)
                Loop

                Dim w As String = ""
                Dim x As Integer = 0
                Dim Zi As Integer = 0

                w = txtfolios.Text
                For Zi = 1 To 10
                    x = InStr(1, w, ",") - 1
                    If x < 0 Then Exit For

                    Remision(Zi) = Mid(w, 1, InStr(1, w, ",") - 1)
                    w = Mid(w, InStr(1, w, ",") + 1, 200)
                Next
                NNV = Zi
                If Zi > 10 Then MsgBox("El número de notas de venta para abonar no puede ser mayor a 10.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtfolios.Focus().Equals(True) : Exit Sub
                If Zi < 11 Then Remision(Zi) = w
                cnn1.Close() : cnn1.Open()
                For zu = 1 To Zi

                    'Nota de venta pagada
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Ventas where Folio=" & Remision(Zi) & " and Status='PAGADO'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' ya fue pagada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                            txtfolios.Text = Len(Remision(Zi))
                            Exit Sub
                        End If
                    End If
                    rd1.Close()

                    'Nota de venta cancelada
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Ventas where Folio=" & Remision(Zi) & " and Status='CANCELADO'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' fue cancelada.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                            txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                            txtfolios.Text = Len(Remision(Zi))
                            Exit Sub
                        End If
                    End If
                    rd1.Close()

                    'Nota de venta inexistente
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Ventas where Folio=" & Remision(Zi) & ""
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                    Else
                        MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' no existe.")
                        txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                        txtfolios.Text = Len(Remision(Zi))
                        Exit Sub
                    End If
                    rd1.Close()
                Next

                Dim MyComp As String = ""
                For nu = 1 To 10
                    MyComp = Remision(nu)
                    For Zi = 1 To 10
                        If Remision(Zi) = "" Then Exit For
                        If Zi <> nu And Remision(Zi) = MyComp Then
                            MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' está repetida.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                            txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                            txtfolios.Text = Len(Remision(Zi))
                            Exit Sub
                        End If
                    Next
                Next

                Dim MyTotal As Double = 0
                For zu = 1 To 10
                    If Remision(zu) = "" Then Exit For
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Resta from Ventas where Folio=" & Remision(zu) & " and Cliente='" & cbonombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MyTotal = MyTotal + CDbl(IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()))
                        End If
                    End If
                    rd1.Close()
                Next

                txtapagar.Text = FormatNumber(MyTotal, 2)
                txtresta.Text = FormatNumber(MyTotal, 2)
                txtefectivo.Focus().Equals(True)
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbobanco_DropDown(sender As System.Object, e As System.EventArgs) Handles cbobanco.DropDown
        cbobanco.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Banco from Bancos order by Banco"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbobanco.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbobanco_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbobanco.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbobanco.Text = "" Then Exit Sub
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Bancos where Banco='" & cbobanco.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                Else
                    MsgBox("Éste banco no se encuentra registrado en el catálogo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            txtnumero.Focus().Equals(True)
        End If
    End Sub

    Private Sub frmAbonoNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim MyPago As Double = 0
            Dim MySaldo As Double = 0
            Dim MyAcuenta As Double = 0

            If Trim(cbonombre.Text) = "" Or Trim(txtfolios.Text) = "" Then MsgBox("Falta el Nombre del cliente o el folio de la venta", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focused.Equals(True) : Exit Sub

            If lblusuario.Text = "" Then
                MsgBox("Indique la clave del vendedor para continuar", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
                cbonombre.Focused.Equals(True)
                Exit Sub
            End If

            If MsgBox("¿Desear guardar los datos de este abono?", vbQuestion + vbOKCancel, "Delsscom COntrol Negocios Pro") = vbCancel Then Exit Sub

            Dim NNV As Integer = 0
            Dim Remision(10) As String

            Do While Strings.Left(txtfolios.Text, 1) = ","
                txtfolios.Text = Mid(txtfolios.Text, 2)
            Loop

            Dim w As String = ""
            Dim x As Integer = 0
            Dim Zi As Integer = 0

            w = txtfolios.Text
            For Zi = 1 To 10
                x = InStr(1, w, ",") - 1
                If x < 0 Then Exit For

                Remision(Zi) = Mid(w, 1, InStr(1, w, ",") - 1)
                w = Mid(w, InStr(1, w, ",") + 1, 200)
            Next
            NNV = Zi
            If Zi > 10 Then MsgBox("El número de notas de venta para abonar no puede ser mayor a 10.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtfolios.Focus().Equals(True) : Exit Sub
            If Zi < 11 Then Remision(Zi) = w
            cnn1.Close() : cnn1.Open()
            For zu = 1 To Zi

                'Nota de venta pagada
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "select * from Ventas where Folio=" & Remision(Zi) & " and Status='PAGADO'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' ya fue pagada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                        txtfolios.Text = Len(Remision(Zi))
                        Exit Sub
                    End If
                End If
                rd1.Close()

                'Nota de venta cancelada
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "select * from Ventas where Folio=" & Remision(Zi) & " and Status='CANCELADO'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' fue cancelada.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                        txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                        txtfolios.Text = Len(Remision(Zi))
                        Exit Sub
                    End If
                End If
                rd1.Close()

                'Nota de venta inexistente
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "select * from Ventas where Folio=" & Remision(Zi) & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                Else
                    MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' no existe.")
                    txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                    txtfolios.Text = Len(Remision(Zi))
                    Exit Sub
                End If
                rd1.Close()
            Next

            Dim MyComp As String = ""
            For nu = 1 To 10
                MyComp = Remision(nu)
                For Zi = 1 To 10
                    If Remision(Zi) = "" Then Exit For
                    If Zi <> nu And Remision(Zi) = MyComp Then
                        MsgBox("La nota de venta con el folio '" & Remision(Zi) & "' está repetida.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                        txtfolios.SelectionStart = InStr(1, txtfolios.Text, "," & Remision(Zi))
                        txtfolios.Text = Len(Remision(Zi))
                        Exit Sub
                    End If
                Next
            Next

            MyPago = CDec(txtefectivo.Text) + CDec(txtpagos.Text) - CDec(txtcambio.Text)

            For zu = 1 To NNV
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Resta,Acuenta from Ventas where Folio=" & Remision(zu) & ""
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    If MyPago < rd1(0).ToString Then
                        rd1.Close()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Update Ventas set Acuenta=Acuenta+" & MyPago & " where FOlio=" & Remision(zu) & ""
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Update Ventas set Resta=Resta-" & MyPago & " where Folio=" & Remision(zu) & ""
                        cmd1.ExecuteNonQuery()
                        MySaldo = 0
                        cnn1.Close()
                    Else
                        MySaldo = MyPago - CDec(rd1(0).ToString)
                        MyAcuenta = CDec(rd1(0).ToString) + CDec(rd1(1).ToString)

                        cnn1.Close()
                        cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Update Ventas set Acuenta=" & MyAcuenta & " where FOlio=" & Remision(zu) & ""
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Update Ventas set Resta=0, Status='PAGADO' where Folio=" & Remision(zu) & ""
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()
                    End If

                End If
                MyPago = MySaldo
            Next

            MyPago = CDec(txtefectivo.Text) + CDec(txtpagos.Text) - CDec(txtcambio.Text)

            Dim totaltarjeta As Double = 0
            Dim totaltransfe As Double = 0
            Dim otro As Double = 0
            Dim numTarjeta As String = ""

            If DataGridView1.Rows.Count > 0 Then
                For xxx As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(xxx).Cells(0).Value.ToString = "TRAJETA" Then
                        totaltarjeta = totaltarjeta + CDec(DataGridView1.Rows(xxx).Cells(3).Value)
                        numTarjeta = DataGridView1.Rows(xxx).Cells(2).Value.ToString
                    ElseIf DataGridView1.Rows(xxx).Cells(0).Value.ToString = "TRANSFERENCIA" Then
                        totaltransfe = totaltransfe + CDec(DataGridView1.Rows(xxx).Cells(3).Value)
                    Else
                        otro = otro + CDec(DataGridView1.Rows(xxx).Cells(3).Value)
                    End If
                Next
            End If

            Dim pagoo As Double = 0

            If lblid_usu.Text <> 0 Then
                pagoo = CDec(txtefectivo.Text) + CDec(txtpagos.Text) - CDec(txtcambio.Text)
                For zu = 1 To NNV
                    cnn1.Close()
                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Select Saldo from Abonoi where IdCliente=" & lblid_usu.Text & " order by Id desc"
                    rd1 = cmd1.ExecuteReader
                    If rd1.Read Then
                        MySaldo = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                    Else
                        MySaldo = MyPago
                    End If
                    MySaldo = MySaldo - MyPago
                    rd1.Close()

                    If txtefectivo.Text <> "0.00" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                        "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Comentario) values(" & Remision(zu) & "," & lblid_usu.Text & ",'" & IIf(cbonombre.Text = "", "PUBLICO EN GENERAL", cbonombre.Text) & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & txtefectivo.Text & "," & (MySaldo) & ",'EFECTIVO'," & txtefectivo.Text & ",'','','" & lblusuario.Text & "','')"
                        If cmd1.ExecuteNonQuery Then

                        End If
                        cnn1.Close()
                    End If
                    Dim FormaPago As String = ""
                    Dim TotFormaPago As Double = 0
                    Dim BancoFP As String = ""
                    Dim ReferenciaFP As String = ""
                    Dim CmentarioFP As String = ""
                    For R As Integer = 0 To DataGridView1.Rows.Count - 1
                        FormaPago = DataGridView1.Rows(R).Cells(0).Value.ToString()
                        If CStr(DataGridView1.Rows(R).Cells(0).Value.ToString()) = FormaPago Then
                            TotFormaPago = CDbl(DataGridView1.Rows(R).Cells(3).Value.ToString())
                            BancoFP = BancoFP & "-" & CStr(DataGridView1.Rows(R).Cells(1).Value.ToString())
                            ReferenciaFP = DataGridView1.Rows(R).Cells(2).Value.ToString()
                            'CmentarioFP = DataGridView1.Rows(R).Cells(4).Value.ToString()
                        End If

                        If TotFormaPago > 0 Then
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Comentario) values(" & Remision(zu) & "," & lblid_usu.Text & ",'" & IIf(cbonombre.Text = "", "PUBLICO EN GENERAL", cbonombre.Text) & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & TotFormaPago & "," & (MySaldo) & ",'" & FormaPago & "'," & TotFormaPago & ",'" & BancoFP & "','" & ReferenciaFP & "','" & lblusuario.Text & "','" & CmentarioFP & "')"
                            If cmd2.ExecuteNonQuery() Then
                            End If
                            cnn2.Close()
                        End If
                    Next
                Next
                MsgBox("Abonos realizados correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select ALias from usuarios where CLave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    lblusuario.Text = rd1(0).ToString
                    Button2.Focus.Equals(True)
                Else
                    MsgBox("Contraseña incorrecta", vbCritical + vbOKOnly, "Control Negocios Pro")
                    txtcontraseña.SelectAll()
                    txtcontraseña.Focus.Equals(True)
                End If
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lblid_usu.Text = ""
        cbonombre.Text = ""
        txtfolios.Text = ""
        txtapagar.Text = "0.00"
        txtefectivo.Text = "0.00"
        txtcambio.Text = "0.00"
        txtpagos.Text = "0.00"
        txtresta.Text = "0.00"
        cbotipo.Text = ""
        cbobanco.Text = ""
        txtnumero.Text = ""
        txtmonto.Text = "0.00"
        DataGridView1.Rows.Clear()
        lblusuario.Text = ""
        txtcontraseña.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cbotipo.Text = "" Or txtmonto.Text = "0.00" Then
            Exit Sub
        End If
        DataGridView1.Rows.Add(cbotipo.Text, cbobanco.Text, txtnumero.Text, txtmonto.Text, dtppago.Value)
        Dim soypagos As Double = 0
        If DataGridView1.Rows.Count = 0 Then
        Else
            For xxx As Integer = 0 To DataGridView1.Rows.Count - 1
                soypagos = soypagos + CDec(DataGridView1.Rows(xxx).Cells(3).Value)
            Next
            txtpagos.Text = FormatNumber(soypagos, 2)
        End If
    End Sub

    Private Sub cbotipo_DropDown(sender As Object, e As EventArgs) Handles cbotipo.DropDown
        Try
            cbotipo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' AND Valor=''"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbotipo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
End Class