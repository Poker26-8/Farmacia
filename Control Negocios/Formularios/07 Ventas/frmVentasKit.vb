Public Class frmVentasKit

    Public Vienna As String = ""
    Private Sub frmVentasKit_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Kits"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboNombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboNombre.Text <> "" Then
                Call cboNombre_SelectedValueChanged(cboNombre, New EventArgs())
                txtcantid.Focus().Equals(True)
            Else
                'cbocodigo.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        grdcaptura.Rows.Clear()
        txtprec.Text = "0.00"
        txtcantid.Text = "1"

        Dim cantidad As Double = 0
        Dim precio As Double = 0
        Dim multiplo As Double = 0
        Dim total As Double = 0
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim grupo As String = ""
        Dim existencia As Double = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,Cantidad from Kits where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                If rd1.HasRows Then
                    cantidad = rd1("Cantidad").ToString
                    codigo = rd1("Codigo").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from Productos where Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            precio = rd2("PreEsp").ToString
                            multiplo = rd2("Multiplo").ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            grupo = rd2("Grupo").ToString
                            nombre = rd2("Nombre").ToString
                            existencia = rd2("Existencia").ToString
                        End If
                    End If
                    rd2.Close()

                    total = precio * cantidad

                    If grupo <> "SERVICIOS" Then
                        grdcaptura.Rows.Add(codigo, nombre, cantidad, FormatNumber(precio, 2), FormatNumber(total, 2), (existencia / multiplo), IIf(((existencia / multiplo) / cantidad) < 1, "0", ((existencia / multiplo) / cantidad)))
                    Else
                        grdcaptura.Rows.Add(codigo, nombre, cantidad, FormatNumber(precio, 2), FormatNumber(total, 2), "0", "0")
                    End If
                End If
            Loop
            cnn2.Close()
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Nombre='" & cboNombre.Text & "' and ProvRes=1 and Departamento<>'SERVICIOS'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtprec.Text = rd1("PrecioVentaIVA").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()
            txtprec.Text = FormatNumber(txtprec.Text, 2)

            For zef As Integer = 0 To grdcaptura.Rows.Count - 1
                Dim puede As Double = grdcaptura.Rows(zef).Cells(6).Value.ToString()

                If puede < 1 Then
                    grdcaptura.Rows(zef).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtcantid_Click(sender As System.Object, e As System.EventArgs) Handles txtcantid.Click
        txtcantid.SelectionStart = 0
        txtcantid.SelectionLength = Len(txtcantid.Text)
    End Sub

    Private Sub txtcantid_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantid.GotFocus
        txtcantid.SelectionStart = 0
        txtcantid.SelectionLength = Len(txtcantid.Text)
    End Sub

    Private Sub txtcantid_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantid.KeyPress
        If Not IsNumeric(txtcantid.Text) Then txtcantid.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cboNombre.Text & "' and ProvRes=1 and Departamento<>'SERVICIOS'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtprec.Text = CDbl(rd1("PrecioVentaIVA").ToString) * CDbl(txtcantid.Text)
                    End If
                End If
                rd1.Close()
                txtprec.Text = FormatNumber(txtprec.Text, 2)

                Dim cantidad As Double = 0
                Dim precio As Double = 0
                Dim multiplo As Double = 0
                Dim total As Double = 0
                Dim nombre As String = ""
                Dim grupo As String = ""
                Dim existencia As Double = 0

                grdcaptura.Rows.Clear()

                Dim codigo As String = ""
                Dim cant As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Codigo,Cantidad from Kits where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                cnn2.Close() : cnn2.Open()
                Do While rd1.Read
                    If rd1.HasRows Then
                        codigo = rd1("Codigo").ToString
                        cantidad = rd1("Cantidad").ToString

                        cant = cantidad * CDbl(txtcantid.Text)

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from Productos where Codigo='" & codigo & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                precio = rd2("PreEsp").ToString
                                multiplo = rd2("Multiplo").ToString
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                grupo = rd2("Grupo").ToString
                                nombre = rd2("Nombre").ToString
                                existencia = rd2("Existencia").ToString
                            End If
                        End If
                        rd2.Close()

                        total = precio * cant

                        If grupo <> "SERVICIOS" Then
                            grdcaptura.Rows.Add(codigo, nombre, cant, FormatNumber(precio, 2), FormatNumber(total, 2), (existencia / multiplo), IIf(((existencia / multiplo) / cant) < 1, "0", ((existencia / multiplo) / cantidad)))
                        Else
                            grdcaptura.Rows.Add(codigo, nombre, cant, FormatNumber(precio, 2), FormatNumber(total, 2), "0", "0")
                        End If
                    End If
                Loop
                cnn2.Close()
                rd1.Close() : cnn1.Close()

                For zef As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim puede As Double = grdcaptura.Rows(zef).Cells(6).Value.ToString()

                    If puede < 1 Then
                        grdcaptura.Rows(zef).DefaultCellStyle.ForeColor = Color.Red
                    End If
                Next
                btnmandar.Focus().Equals(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnmandar_Click(sender As System.Object, e As System.EventArgs) Handles btnmandar.Click
        If txtcantid.Text = "" Then MsgBox("Escribe una cantidad válida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantid.Focus().Equals(True) : Exit Sub
        For lna As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim puede As Integer = grdcaptura.Rows(lna).Cells(6).Value.ToString()

            If puede <= 0 Then
                MsgBox("No se puede continuar porque no cuentas con piezas suficientes del producto " & grdcaptura.Rows(lna).Cells(1).Value.ToString & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If
        Next
        EnviaVentas(Vienna)
        Me.Close()
    End Sub

    Private Sub EnviaVentas(ByVal Formulario As String)
        If Formulario = "Ventas1" Then
            With frmVentas1_Partes
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cboNombre.Text & "' and ProvRes=1 and Departamento<>'SERVICIOS'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        .grdcaptura.Rows.Add(rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("UVenta").ToString, txtcantid.Text, FormatNumber(CDbl(txtprec.Text) / CDbl(txtcantid.Text), 2), FormatNumber(txtprec.Text, 2), rd1("Existencia").ToString, "", "", "", "0", "0", "0", FormatNumber(txtprec.Text, 2))
                    End If
                End If
                rd1.Close() : cnn1.Close()

                Dim VarSumXD As Double = 0
                For w = 0 To .grdcaptura.Rows.Count - 1
                    If .grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
                    Else
                        VarSumXD = VarSumXD + CDbl(.grdcaptura.Rows(w).Cells(5).Value.ToString)
                    End If
                    .txtSubTotal.Text = FormatNumber(VarSumXD, 2)
                Next

                If CDbl(.txtdescuento1.Text) > 0 Then
                    .txtSubTotal.Tag = 1
                End If
                If CDbl(.txtdescuento1.Text) <= 0 Then
                    .txtPagar.Text = CDbl(.txtSubTotal.Text) - CDbl(.txtdescuento2.Text)
                    .txtPagar.Text = FormatNumber(.txtPagar.Text, 2)
                End If

                Call .txtdescuento1_TextChanged(.txtdescuento1, New EventArgs())
            End With
        End If
        If Formulario = "Ventas2" Then
            'With frmVentas2_Descuentos
            '    cnn1.Close() : cnn1.Open()
            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText =
            '        "select * from Productos where Nombre='" & cboNombre.Text & "' and ProvRes=1 and Departamento<>'SERVICIOS'"
            '    rd1 = cmd1.ExecuteReader
            '    If rd1.HasRows Then
            '        If rd1.Read Then
            '            .grdcaptura.Rows.Add(rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("UVenta").ToString, txtcantid.Text, FormatNumber(CDbl(txtprec.Text) / CDbl(txtcantid.Text), 2), FormatNumber(txtprec.Text, 2), rd1("Existencia").ToString, "", "", "", "0", "0", "0", FormatNumber(txtprec.Text, 2))
            '        End If
            '    End If
            '    rd1.Close() : cnn1.Close()

            '    Dim VarSumXD As Double = 0
            '    For w = 0 To .grdcaptura.Rows.Count - 1
            '        If .grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
            '        Else
            '            VarSumXD = VarSumXD + CDbl(.grdcaptura.Rows(w).Cells(5).Value.ToString)
            '        End If
            '        .txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            '    Next

            '    If CDbl(.txtdescuento1.Text) > 0 Then
            '        .txtSubTotal.Tag = 1
            '    End If
            '    If CDbl(.txtdescuento1.Text) <= 0 Then
            '        .txtPagar.Text = CDbl(.txtSubTotal.Text) - CDbl(.txtdescuento2.Text)
            '        .txtPagar.Text = FormatNumber(.txtPagar.Text, 2)
            '    End If

            '    Call .txtdescuento1_TextChanged(.txtdescuento1, New EventArgs())
            'End With
        End If
        If Formulario = "Ventas3" Then
            'With frmVentas3_Descuentos
            '    cnn1.Close() : cnn1.Open()
            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText =
            '        "select * from Productos where Nombre='" & cboNombre.Text & "' and ProvRes=1 and Departamento<>'SERVICIOS'"
            '    rd1 = cmd1.ExecuteReader
            '    If rd1.HasRows Then
            '        If rd1.Read Then
            '            .grdcaptura.Rows.Add(rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("UVenta").ToString, txtcantid.Text, FormatNumber(CDbl(txtprec.Text) / CDbl(txtcantid.Text), 2), FormatNumber(txtprec.Text, 2), rd1("Existencia").ToString, "", "", "", "0", "0", "0", FormatNumber(txtprec.Text, 2))
            '        End If
            '    End If
            '    rd1.Close() : cnn1.Close()

            '    Dim VarSumXD As Double = 0
            '    For w = 0 To .grdcaptura.Rows.Count - 1
            '        If .grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
            '        Else
            '            VarSumXD = VarSumXD + CDbl(.grdcaptura.Rows(w).Cells(5).Value.ToString)
            '        End If
            '        .txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            '    Next

            '    If CDbl(.txtdescuento1.Text) > 0 Then
            '        .txtSubTotal.Tag = 1
            '    End If
            '    If CDbl(.txtdescuento1.Text) <= 0 Then
            '        .txtPagar.Text = CDbl(.txtSubTotal.Text) - CDbl(.txtdescuento2.Text)
            '        .txtPagar.Text = FormatNumber(.txtPagar.Text, 2)
            '    End If

            '    Call .txtdescuento1_TextChanged(.txtdescuento1, New EventArgs())
            'End With
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtcantid.Text = "" Then MsgBox("Escribe una cantidad válida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantid.Focus().Equals(True) : Exit Sub
        For lna As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim puede As Integer = grdcaptura.Rows(lna).Cells(6).Value.ToString()

            If puede <= 0 Then
                MsgBox("No se puede continuar porque no cuentas con piezas suficientes del producto " & grdcaptura.Rows(lna).Cells(1).Value.ToString & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If
        Next
        EnviaVentas2(Vienna)
        Me.Close()
    End Sub

    Public Sub EnviaVentas2(ByVal Formulario As String)
        Dim cod_kit As String = ""

        Dim cod_prod As String = ""
        Dim cant_prod As Double = 0
        Dim pre_prod As Double = 0

        If Formulario = "frmVentas1" Then
            With frmVentas1_Partes
                cnn1.Close() : cnn1.Open()

                For pipi As Integer = 0 To grdcaptura.Rows.Count - 1
                    cod_prod = grdcaptura.Rows(pipi).Cells(0).Value.ToString()
                    cant_prod = grdcaptura.Rows(pipi).Cells(2).Value.ToString()
                    pre_prod = grdcaptura.Rows(pipi).Cells(3).Value.ToString()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & cod_prod & "' and ProvRes=0 and Departamento<>'SERVICIOS'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            .grdcaptura.Rows.Add(cod_prod, rd1("Nombre").ToString, rd1("UVenta").ToString, cant_prod, pre_prod, FormatNumber(pre_prod * cant_prod, 2), rd1("Existencia").ToString, "", "", "", "0", "0", "0", FormatNumber(pre_prod * cant_prod, 2))
                        End If
                    End If
                    rd1.Close()

                    Dim VarSumXD As Double = 0
                    For w = 0 To .grdcaptura.Rows.Count - 1
                        If .grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
                        Else
                            VarSumXD = VarSumXD + CDbl(.grdcaptura.Rows(w).Cells(5).Value.ToString)
                        End If
                        .txtSubTotal.Text = FormatNumber(VarSumXD, 2)
                    Next

                    If CDbl(.txtdescuento1.Text) > 0 Then
                        .txtSubTotal.Tag = 1
                    End If
                    If CDbl(.txtdescuento1.Text) <= 0 Then
                        .txtPagar.Text = CDbl(.txtSubTotal.Text) - CDbl(.txtdescuento2.Text)
                        .txtPagar.Text = FormatNumber(.txtPagar.Text, 2)
                    End If

                    Call .txtdescuento1_TextChanged(.txtdescuento1, New EventArgs())
                Next
                cnn1.Close()
            End With
        End If
        If Formulario = "frmVentas2" Then
            'With frmVentas2_Descuentos
            '    cnn1.Close() : cnn1.Open()

            '    For pipi As Integer = 0 To grdcaptura.Rows.Count - 1
            '        cod_prod = grdcaptura.Rows(pipi).Cells(0).Value.ToString()
            '        cant_prod = grdcaptura.Rows(pipi).Cells(2).Value.ToString()
            '        pre_prod = grdcaptura.Rows(pipi).Cells(3).Value.ToString()

            '        cmd1 = cnn1.CreateCommand
            '        cmd1.CommandText =
            '            "select * from Productos where Codigo='" & cod_prod & "' and ProvRes=0 and Departamento<>'SERVICIOS'"
            '        rd1 = cmd1.ExecuteReader
            '        If rd1.HasRows Then
            '            If rd1.Read Then
            '                .grdcaptura.Rows.Add(cod_prod, rd1("Nombre").ToString, rd1("UVenta").ToString, cant_prod, pre_prod, FormatNumber(pre_prod * cant_prod, 2), rd1("Existencia").ToString, "", "", "", "0", "0", "0", FormatNumber(pre_prod * cant_prod, 2))
            '            End If
            '        End If
            '        rd1.Close()

            '        Dim VarSumXD As Double = 0
            '        For w = 0 To .grdcaptura.Rows.Count - 1
            '            If .grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
            '            Else
            '                VarSumXD = VarSumXD + CDbl(.grdcaptura.Rows(w).Cells(5).Value.ToString)
            '            End If
            '            .txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            '        Next

            '        If CDbl(.txtdescuento1.Text) > 0 Then
            '            .txtSubTotal.Tag = 1
            '        End If
            '        If CDbl(.txtdescuento1.Text) <= 0 Then
            '            .txtPagar.Text = CDbl(.txtSubTotal.Text) - CDbl(.txtdescuento2.Text)
            '            .txtPagar.Text = FormatNumber(.txtPagar.Text, 2)
            '        End If

            '        Call .txtdescuento1_TextChanged(.txtdescuento1, New EventArgs())
            '    Next
            '    cnn1.Close()
            'End With
        End If
        If Formulario = "frmVentas3" Then
            'With frmVentas3_Descuentos
            '    cnn1.Close() : cnn1.Open()

            '    For pipi As Integer = 0 To grdcaptura.Rows.Count - 1
            '        cod_prod = grdcaptura.Rows(pipi).Cells(0).Value.ToString()
            '        cant_prod = grdcaptura.Rows(pipi).Cells(2).Value.ToString()
            '        pre_prod = grdcaptura.Rows(pipi).Cells(3).Value.ToString()

            '        cmd1 = cnn1.CreateCommand
            '        cmd1.CommandText =
            '            "select * from Productos where Codigo='" & cod_prod & "' and ProvRes=0 and Departamento<>'SERVICIOS'"
            '        rd1 = cmd1.ExecuteReader
            '        If rd1.HasRows Then
            '            If rd1.Read Then
            '                .grdcaptura.Rows.Add(cod_prod, rd1("Nombre").ToString, rd1("UVenta").ToString, cant_prod, pre_prod, FormatNumber(pre_prod * cant_prod, 2), rd1("Existencia").ToString, "", "", "", "0", "0", "0", FormatNumber(pre_prod * cant_prod, 2))
            '            End If
            '        End If
            '        rd1.Close()

            '        Dim VarSumXD As Double = 0
            '        For w = 0 To .grdcaptura.Rows.Count - 1
            '            If .grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
            '            Else
            '                VarSumXD = VarSumXD + CDbl(.grdcaptura.Rows(w).Cells(5).Value.ToString)
            '            End If
            '            .txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            '        Next

            '        If CDbl(.txtdescuento1.Text) > 0 Then
            '            .txtSubTotal.Tag = 1
            '        End If
            '        If CDbl(.txtdescuento1.Text) <= 0 Then
            '            .txtPagar.Text = CDbl(.txtSubTotal.Text) - CDbl(.txtdescuento2.Text)
            '            .txtPagar.Text = FormatNumber(.txtPagar.Text, 2)
            '        End If

            '        Call .txtdescuento1_TextChanged(.txtdescuento1, New EventArgs())
            '    Next
            '    cnn1.Close()
            'End With
        End If
    End Sub

    Private Sub frmVentasKit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class