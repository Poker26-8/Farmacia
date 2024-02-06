Public Class frmAbonoNotas
    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Ventas where Nombre<>'' and Status='RESTA' order by Nombre"
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
                "select IdCliente from Ventas where Nombre='" & cbonombre.Text & "' and IdCliente<>0"
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
                        "select * from Ventas where Folio=" & Remision(Zi) & " and Status='PAGADO' and Nombre='" & cbonombre.Text & "'"
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
                        "select * from Ventas where Folio=" & Remision(Zi) & " and Status='CANCELADO' and Nombre='" & cbonombre.Text & "'"
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
                        "select * from Ventas where Folio=" & Remision(Zi) & " and Nombre='" & cbonombre.Text & "'"
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
                        "select Resta from Ventas where Folio=" & Remision(zu) & " and Nombre='" & cbonombre.Text & "'"
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
            : cnn1.Close()
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
                    MsgBox("Éste banco no se encuentra registrado en e catálogo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
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
End Class