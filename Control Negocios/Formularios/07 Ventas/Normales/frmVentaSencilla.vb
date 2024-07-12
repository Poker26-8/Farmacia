Imports Org.BouncyCastle.Math.EC

Public Class frmVentaSencilla

    Dim Promo As Boolean = False
    Dim Anti As String = ""

    Dim T_Precio As String = ""
    Dim H_Inicia As String = ""
    Dim H_Final As String = ""
    Private Sub frmVentaSencilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbodesc_DropDown(sender As Object, e As EventArgs) Handles cbodesc.DropDown
        Try
            cbodesc.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT distinct Nombre FROM Productos WHERE Grupo<>'INSUMO' and ProvRes<>1 order by Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbodesc.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbodesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodesc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        Dim Multiplica As String = ""
        Dim VSE As Boolean = False
        Dim Multiplo As Double = 0
        Dim Minimo As Double = 0
        Dim TiCambio As Double = 0
        Dim PreLst As Double = 0, PreEsp As Double = 0
        Dim H_Actual As String = Format(Date.Now, "HH:mm")

        If AscW(e.KeyChar) = Keys.Enter And cbodesc.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If Strings.Left(cbodesc.Text, 1) = "*" Then
                Multiplica = "*"
                cbodesc.Text = Mid(cbodesc.Text, 2, 99)
            End If

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT VSE FROM Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        VSE = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Productos WHERE Nombre='" & cbodesc.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Promo = IIf(rd1("Status_Promocion").ToString = False, False, True)
                        Anti = rd1("Grupo").ToString
                        If Anti = "ANTIBIOTICO" Or Anti = "CONTROLADO" Then
                            If MsgBox("Este en un " & Anti & " ¿deseas continuar con el proceso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                                cbocodigo.Text = ""
                                cbodesc.Text = ""
                                txtunidad.Text = ""
                                txtcantidad.Text = ""
                                txtprecio.Text = "0.00"
                                txtprecio.Tag = 0
                                txttotal.Text = "0.00"
                                txtexistencia.Text = ""
                                cboLote.Text = ""
                                cboLote.Tag = 0
                                ' txtfechacad.Text = ""
                                ' txtubicacion.Text = ""
                                cbodesc.Focus().Equals(True)
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                        If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                            cbocodigo.Text = rd1("Codigo").ToString
                            cbocodigo.Focus().Equals(True)
                            rd1.Close()
                            cnn1.Close()
                            Exit Sub
                        End If

                        cbocodigo.Text = rd1("Codigo").ToString()
                        cbodesc.Text = rd1("Nombre").ToString()
                        txtunidad.Text = rd1("UVenta").ToString()
                        Multiplo = rd1("Multiplo").ToString()
                        Minimo = rd1("Min").ToString()
                        ' txtubicacion.Text = rd1("Ubicacion").ToString()

                        cnn2.Close() : cnn2.Open() : cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Existencia FROM Productos WHERE Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                txtexistencia.Text = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) / Multiplo
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT FechaC FROM ComprasDet WHERE Codigo='" & cbocodigo.Text & "' LIMIT 1"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                Label2.Text = "Descrpción " & FormatDateTime(rd2(0).ToString, DateFormat.ShortDate)
                            End If
                        Else
                            Label2.Text = "Descrpción"
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                TiCambio = rd2(0).ToString
                                If TiCambio = 0 Then TiCambio = 1
                            End If
                        Else
                            TiCambio = 1
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT PrecioVentaIVA, PreEsp FROM Productos where Codigo='" & cbocodigo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                PreLst = rd2(0).ToString
                                PreEsp = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                        cbocodigo.Focus().Equals(True)
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                End If
                rd1.Close()

                '----------------------cod de barras---------------------------------------------------------------
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select * from Productos where CodBarra='" & cbodesc.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        Promo = IIf(rd1("Status_Promocion").ToString = False, False, True)
                        Anti = rd1("Grupo").ToString
                        If Anti = "ANTIBIOTICO" Or Anti = "CONTROLADO" Then
                            If MsgBox("Este en un " & Anti & " ¿deseas continuar con el proceso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                                cbocodigo.Text = ""
                                cbodesc.Text = ""
                                txtunidad.Text = ""
                                txtcantidad.Text = ""
                                txtprecio.Text = "0.00"
                                txtprecio.Tag = 0
                                txttotal.Text = "0.00"
                                txtexistencia.Text = ""
                                cboLote.Text = ""
                                cboLote.Tag = 0
                                '  txtfechacad.Text = ""
                                ' txtubicacion.Text = ""
                                cbodesc.Focus().Equals(True)
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                        If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                            cbocodigo.Text = rd1("Codigo").ToString
                            cbocodigo.Focus().Equals(True)
                            rd1.Close()
                            cnn1.Close()
                            Exit Sub
                        End If

                        cbocodigo.Text = rd1("Codigo").ToString()
                        cbodesc.Text = rd1("Nombre").ToString()
                        txtunidad.Text = rd1("UVenta").ToString()
                        Multiplo = rd1("Multiplo").ToString()
                        Minimo = rd1("Min").ToString()
                        'txtubicacion.Text = rd1("Ubicacion").ToString()

                        cnn2.Close() : cnn2.Open() : cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Existencia from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                txtexistencia.Text = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) / Multiplo
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                TiCambio = rd2(0).ToString
                                If TiCambio = 0 Then TiCambio = 1
                            End If
                        Else
                            TiCambio = 1
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select PrecioVentaIVA, PreEsp from Productos where Codigo='" & cbocodigo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                PreLst = rd2(0).ToString
                                PreEsp = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()

                        If Multiplica = "" Then
                            txtcantidad.Text = "1"
                            If CDbl(txtexistencia.Text) - CDbl(txtcantidad.Text) < 0 Then
                                If VSE = True Then
                                    If Me.Text = "Ventas (1)" Then
                                        MsgBox("No se puede vender sin existencias.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                        rd1.Close() : cnn1.Close()
                                        cbocodigo.Text = ""
                                        cbodesc.Text = ""
                                        txtunidad.Text = ""
                                        txtcantidad.Text = ""
                                        txtprecio.Text = "0.00"
                                        txtprecio.Tag = 0
                                        txttotal.Text = "0.00"
                                        txtexistencia.Text = ""
                                        cboLote.Text = ""
                                        cboLote.Tag = 0
                                        ' txtfechacad.Text = ""
                                        ' txtubicacion.Text = ""
                                        txtprecio.ReadOnly = False
                                        cbodesc.Focus().Equals(True)
                                        Exit Sub
                                    End If
                                End If
                            End If
                            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
                            txttotal.Text = FormatNumber(txttotal.Text, 4)
                            My.Application.DoEvents()

                            'Si hay lote se detiene
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Cantidad>0"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    cboLote.Focus.Equals(True)
                                    rd2.Close() : cnn2.Close()
                                    Exit Sub
                                End If
                            End If
                            rd2.Close() : cnn2.Close()

                            Call UpGrid()
                            My.Application.DoEvents()
                            Dim voy2 As Double = 0
                            Dim VarSumXD As Double = 0
                            For w = 0 To grdcaptura.Rows.Count - 1
                                If grdcaptura.Rows(w).Cells(6).Value.ToString = "" Then
                                Else
                                    VarSumXD = VarSumXD + CDbl(grdcaptura.Rows(w).Cells(5).Value.ToString)
                                    voy2 = voy2 + CDec(grdcaptura.Rows(w).Cells(3).Value)
                                End If
                                txtSubTotal.Text = FormatNumber(VarSumXD, 2)
                            Next
                            txtcant_productos.Text = FormatNumber(voy2, 2)
                            If CDbl(txtdescuento1.Text) > 0 Then
                                txtSubTotal.Tag = 1
                            End If
                            '   txtcoment.Text = ""
                            cbocodigo.Text = ""
                            cbocodigo.Items.Clear()
                            cbodesc.Text = ""
                            cbodesc.Items.Clear()
                            txtunidad.Text = ""
                            txtcantidad.Text = "1"
                            txtprecio.Text = "0.00"
                            txtprecio.Tag = 0
                            txttotal.Text = "0.00"
                            txtexistencia.Text = ""
                            ' txtfechacad.Text = ""
                            cboLote.Text = ""
                            cboLote.Tag = 0
                            ' txtubicacion.Text = ""
                            cnn1.Close()

                            If CDbl(txtdescuento1.Text) <= 0 Then
                                txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
                                txtPagar.Text = FormatNumber(txtPagar.Text, 2)
                            End If

                            Call txtdescuento1_TextChanged(txtdescuento1, New EventArgs())

                            cbodesc.Focus().Equals(True)
                            txtprecio.ReadOnly = False
                        Else
                            txtcantidad.Focus().Equals(True)
                        End If
                        rd1.Close() : cnn1.Close()
                        Exit Sub
                        cnn2.Close()
                    End If
                Else
                    CodBar()
                    If cbocodigo.Text <> "" Then
                        cnn2.Close() : cnn2.Open()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                Promo = IIf(rd2("Status_Promocion").ToString = False, False, True)
                                Anti = rd2("Grupo").ToString
                                If Anti = "ANTIBIOTICO" Or Anti = "CONTROLADO" Then
                                    If MsgBox("Este en un " & Anti & " ¿deseas continuar con el proceso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                                        cbocodigo.Text = ""
                                        cbodesc.Text = ""
                                        txtunidad.Text = ""
                                        txtcantidad.Text = ""
                                        txtprecio.Text = "0.00"
                                        txtprecio.Tag = 0
                                        txttotal.Text = "0.00"
                                        txtexistencia.Text = ""
                                        cboLote.Text = ""
                                        cboLote.Tag = 0
                                        'txtfechacad.Text = ""
                                        '  txtubicacion.Text = ""
                                        cbodesc.Focus().Equals(True)
                                        rd2.Close() : cnn2.Close()
                                        Exit Sub
                                    End If
                                End If
                                If CStr(rd2("Departamento").ToString) = "SERVICIOS" Then
                                    cbocodigo.Text = rd2("Codigo").ToString
                                    cbocodigo.Focus().Equals(True)
                                    rd1.Close()
                                    cnn1.Close()
                                    Exit Sub
                                End If

                                cbocodigo.Text = rd2("Codigo").ToString()
                                cbodesc.Text = rd2("Nombre").ToString()
                                txtunidad.Text = rd2("UVenta").ToString()
                                Multiplo = rd2("Multiplo").ToString()
                                Minimo = rd2("Min").ToString()
                                ' txtubicacion.Text = rd2("Ubicacion").ToString()

                                cnn3.Close() : cnn3.Open() : cmd3 = cnn3.CreateCommand
                                cmd3.CommandText =
                                    "select Existencia from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                                rd3 = cmd3.ExecuteReader
                                If rd3.HasRows Then
                                    If rd3.Read Then
                                        txtexistencia.Text = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString)) / Multiplo
                                    End If
                                End If
                                rd3.Close()

                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText =
                                    "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                                rd3 = cmd3.ExecuteReader
                                If rd3.HasRows Then
                                    If rd3.Read Then
                                        TiCambio = rd3(0).ToString
                                        If TiCambio = 0 Then TiCambio = 1
                                    End If
                                Else
                                    TiCambio = 1
                                End If
                                rd3.Close()

                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText =
                                    "select PrecioVentaIVA, PreEsp from Productos where Codigo='" & cbocodigo.Text & "'"
                                rd3 = cmd3.ExecuteReader
                                If rd3.HasRows Then
                                    If rd3.Read Then
                                        PreLst = rd3(0).ToString
                                        PreEsp = rd3(1).ToString
                                    End If
                                End If
                                rd3.Close()

                                cboLote.Items.Clear()
                                cmd3 = cnn3.CreateCommand
                                'If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                                'cmd3.CommandText =
                                '"select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                                'rd3 = cmd3.ExecuteReader
                                'Do While rd3.Read
                                '    If rd3.HasRows Then cboLote.Items.Add(rd3("Lote").ToString())
                                'Loop
                                'rd3.Close()
                                'Else
                                If cbocodigo.Text = "" Then Exit Sub
                                    cmd3.CommandText =
                                    "select distinct(Lote) as Lt from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Cantidad>0"
                                    rd3 = cmd3.ExecuteReader
                                    Do While rd3.Read
                                        If rd3.HasRows Then cboLote.Items.Add(rd3("Lt").ToString())
                                    Loop
                                    rd3.Close()
                                ' End If

                                If cbotipo.Visible = False Then
                                    If T_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                                        txtprecio.Text = FormatNumber(PreEsp * TiCambio, 4)
                                        txtprecio.Tag = FormatNumber(PreEsp * TiCambio, 4)
                                    Else
                                        txtprecio.Text = FormatNumber(PreLst * TiCambio, 4)
                                        txtprecio.Tag = FormatNumber(PreLst * TiCambio, 4)
                                    End If
                                    If (Promo) Then
                                        txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                        txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                        txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    End If
                                    txtprecio.ReadOnly = False
                                Else
                                    If (Promo) Then
                                        txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                        txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                        txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                        txtprecio.ReadOnly = False
                                    Else
                                        If cbonota.Text = "" Then
                                            txtprecio.Text = Cambio(TiCambio)
                                            txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                            txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                            txtprecio.ReadOnly = False
                                        Else
                                            cmd3 = cnn3.CreateCommand
                                            cmd3.CommandText =
                                                "select Precio from VentasDetalle where Codigo='" & cbocodigo.Text & "' and Folio=" & cbonota.Text & ""
                                            rd3 = cmd3.ExecuteReader
                                            If rd3.HasRows Then
                                                If rd3.Read Then
                                                    txtprecio.Text = rd3(0).ToString
                                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                                    txtprecio.ReadOnly = True
                                                End If
                                            Else
                                                txtprecio.Text = Cambio(TiCambio)
                                                txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                                txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                                txtprecio.ReadOnly = False
                                            End If
                                            rd3.Close()
                                        End If
                                    End If
                                End If
                                cnn3.Close()

                                If Multiplica = "" Then
                                    txtcantidad.Text = "1"
                                    If CDbl(txtexistencia.Text) - CDbl(txtcantidad.Text) < 0 Then
                                        If VSE = False Then
                                            If Me.Text = "Ventas (1)" Then
                                                MsgBox("No se puede vender sin existencias.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                                rd2.Close() : cnn2.Close()
                                                cbocodigo.Text = ""
                                                cbodesc.Text = ""
                                                txtunidad.Text = ""
                                                txtcantidad.Text = ""
                                                txtprecio.Text = "0.00"
                                                txtprecio.Tag = 0
                                                txttotal.Text = "0.00"
                                                txtexistencia.Text = ""
                                                '   cboLote.Text = ""
                                                '   cboLote.Tag = 0
                                                ' txtfechacad.Text = ""
                                                ' txtubicacion.Text = ""
                                                txtprecio.ReadOnly = False
                                                cbodesc.Focus().Equals(True)
                                                Exit Sub
                                            End If
                                        End If
                                    End If
                                    txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
                                    txttotal.Text = FormatNumber(txttotal.Text, 4)
                                    My.Application.DoEvents()

                                    'Si hay lote se detiene
                                    cnn3.Close() : cnn3.Open()
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText =
                                "select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Cantidad>0"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            cboLote.Focus.Equals(True)
                                            rd3.Close() : cnn3.Close()
                                            Exit Sub
                                        End If
                                    End If
                                    rd3.Close()
                                    cnn3.Close()

                                    Call UpGrid()
                                    My.Application.DoEvents()
                                    Dim voy2 As Double = 0
                                    Dim VarSumXD As Double = 0
                                    For w = 0 To grdcaptura.Rows.Count - 1
                                        If grdcaptura.Rows(w).Cells(6).Value.ToString = "" Then
                                        Else
                                            VarSumXD = VarSumXD + CDbl(grdcaptura.Rows(w).Cells(5).Value.ToString)
                                            voy2 = voy2 + CDec(grdcaptura.Rows(w).Cells(3).Value)
                                        End If
                                        txtSubTotal.Text = FormatNumber(VarSumXD, 2)
                                    Next
                                    txtcant_productos.Text = FormatNumber(voy2, 2)
                                    If CDbl(txtdescuento1.Text) > 0 Then
                                        txtSubTotal.Tag = 1
                                    End If
                                    '  txtcoment.Text = ""
                                    cbocodigo.Text = ""
                                    cbocodigo.Items.Clear()
                                    cbodesc.Text = ""
                                    cbodesc.Items.Clear()
                                    txtunidad.Text = ""
                                    txtcantidad.Text = "1"
                                    txtprecio.Text = "0.00"
                                    txtprecio.Tag = 0
                                    txttotal.Text = "0.00"
                                    txtexistencia.Text = ""
                                    ' txtfechacad.Text = ""
                                    ' cboLote.Text = ""
                                    ' cboLote.Tag = 0
                                    'txtubicacion.Text = ""
                                    cnn1.Close()

                                    If CDbl(txtdescuento1.Text) <= 0 Then
                                        txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
                                        txtPagar.Text = FormatNumber(txtPagar.Text, 2)
                                    End If

                                    Call txtdescuento1_TextChanged(txtdescuento1, New EventArgs())

                                    cbodesc.Focus().Equals(True)
                                    txtprecio.ReadOnly = False
                                Else
                                    txtcantidad.Focus().Equals(True)
                                End If
                                rd2.Close() : cnn2.Close()
                                Exit Sub
                            End If
                        Else
                            MsgBox("Producto no encontrado en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd2.Close() : cnn2.Close()
                        End If
                        cnn2.Close()
                    End If
                End If
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If


    End Sub

    Private Sub txtdescuento1_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento1.TextChanged

    End Sub

    Private Sub UpGrid()

    End Sub

    Private Function Cambio(ByVal Moneda As Double) As Double

    End Function

    Public Sub CodBar()

    End Sub
End Class