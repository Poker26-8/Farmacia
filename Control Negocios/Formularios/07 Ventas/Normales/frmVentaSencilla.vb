Imports Org.BouncyCastle.Math.EC

Public Class frmVentaSencilla

    Dim Promo As Boolean = False
    Dim Anti As String = ""

    Dim T_Precio As String = ""
    Dim H_Inicia As String = ""
    Dim H_Final As String = ""
    Dim donde_va As String = ""
    Dim modo_caja As String = ""
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
                                txtfechacad.Text = ""
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
                                Label2.Text = "Descripción " & FormatDateTime(rd2(0).ToString, DateFormat.ShortDate)
                            End If
                        Else
                            Label2.Text = "Descripción"
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
                                txtfechacad.Text = ""
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
                                        txtfechacad.Text = ""
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
                            txtfechacad.Text = ""
                            cboLote.Text = ""
                            cboLote.Tag = 0
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
                                        txtfechacad.Text = ""
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
                                If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                                    cmd3.CommandText =
                                    "select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                                    rd3 = cmd3.ExecuteReader
                                    Do While rd3.Read
                                        If rd3.HasRows Then cboLote.Items.Add(rd3("Lote").ToString())
                                    Loop
                                    rd3.Close()
                                Else
                                    If cbocodigo.Text = "" Then Exit Sub
                                    cmd3.CommandText =
                                "select distinct(Lote) as Lt from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Cantidad>0"
                                    rd3 = cmd3.ExecuteReader
                                    Do While rd3.Read
                                        If rd3.HasRows Then cboLote.Items.Add(rd3("Lt").ToString())
                                    Loop
                                    rd3.Close()
                                End If

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
                                                cboLote.Text = ""
                                                cboLote.Tag = 0
                                                txtfechacad.Text = ""

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
                                    txtfechacad.Text = ""
                                    cboLote.Text = ""
                                    cboLote.Tag = 0

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

    Public Function IvaDSC(ByVal cod As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & cod & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    IvaDSC = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
                End If
            Else
                IvaDSC = 0
            End If
            rd3.Close()
            cnn3.Close()
            Return IvaDSC
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Sub UpGrid()
        Dim TPapel As String = ""
        Dim Conteo As Double = 0
        Dim Alerta_Min As Boolean = False
        Dim Acumula As Boolean = False
        Dim minimo As Double = 0

        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='MinimoA'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Alerta_Min = IIf(rd3(0).ToString() = "1", True, False)
                End If
            End If
            rd3.Close()

            If TPapel = "MEDIA CARTA" Then
                If grdCaptura.Rows.Count > 13 Then
                    MsgBox("Se establecen 13 partidas como máximo para el formato de impresión 'MEDIA CARTA'", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
            End If

            Dim Val_Punto As Integer = 0
            Dim Mid_precio As String = ""

            Dim codigo As String = cbocodigo.Text
            Dim nombre As String = cbodesc.Text
            Dim unidad As String = txtunidad.Text
            Dim cantid As Double = IIf(txtcantidad.Text = "", "0", txtcantidad.Text)
            Dim precio As Double = 0

            Val_Punto = InStr(1, txtprecio.Text, ".")
            If Val_Punto = 0 Then
                precio = FormatNumber(txtprecio.Text, 4)
            Else
                Mid_precio = Mid(txtprecio.Text, Val_Punto, 40)
                If Len(Mid_precio) = 2 Then
                    precio = FormatNumber(txtprecio.Text, 4)
                ElseIf Len(Mid_precio) > 2 Then
                    precio = FormatNumber(txtprecio.Text, 4)
                End If
            End If
            Dim total As Double = txttotal.Text

            Dim existencia As Double = 0
            If unidad <> "N/A" Then
                existencia = txtexistencia.Text
            Else
                existencia = 0
            End If

            Dim lote As String = cboLote.Text
            Dim id_lote As Integer = IIf(cboLote.Tag = 0, 0, cboLote.Tag)
            Dim fcad As String = txtfechacad.Text
            Dim PU As Double = CDbl(txttotal.Text) / (1 + IvaDSC(cbocodigo.Text))

            Dim IvaIeps As Double = PU - (PU / (1 + ProdsIEPS(cbocodigo.Text)))
            Dim ieps As Double = ProdsIEPS(cbocodigo.Text)

            Dim desucentoiva As Double = 0
            Dim total1 As Double = 0
            Dim monedero As Double = 0

            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select IVA,Promo_Monedero,Min from Productos where Codigo='" & cbocodigo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    monedero = rd3(1).ToString()
                    minimo = rd3(2).ToString()
                    If CDbl(rd3(0).ToString) = 0.16 Then
                        desucentoiva = FormatNumber(CDbl(txttotal.Text) / 1.16, 4)
                        total1 = FormatNumber(CDbl(txttotal.Text) / 1.16, 4)
                    Else
                        desucentoiva = FormatNumber(txttotal.Text, 4)
                        total1 = 0
                    End If
                End If
            Else
                desucentoiva = FormatNumber(txttotal.Text, 4)
                total1 = 0
            End If
            rd3.Close()
            cnn3.Close()

            Dim acumulaxd As Integer = 0
            cnn1.Close()
            cnn1.Open()
            cmd1.CommandText = "Select NotasCred from Formatos where Facturas='Acumula'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                acumulaxd = rd1(0).ToString
            End If
            rd1.Close()
            cnn1.Close()

            If acumulaxd = 1 Then
                For xxx As Integer = 0 To grdCaptura.Rows.Count - 1
                    If codigo = grdCaptura.Rows(xxx).Cells(0).Value.ToString Then
                        grdCaptura.Rows(xxx).Cells(3).Value = cantid + CDec(grdCaptura.Rows(xxx).Cells(3).Value)
                        grdCaptura.Rows(xxx).Cells(5).Value = FormatNumber(total + CDec(grdCaptura.Rows(xxx).Cells(5).Value), 2)
                        GoTo kak
                    End If
                Next
                grdCaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 4), FormatNumber(total, 2), existencia, id_lote, lote, fcad, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2))
            Else
                grdCaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 4), FormatNumber(total, 2), existencia, id_lote, lote, fcad, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2))
            End If

kak:

            If Alerta_Min = True Then
                If (existencia - cantid) <= minimo Then
                    MsgBox("Se ha alcanzo el mínimo en almacén para este producto.", vbCritical & vbOKOnly, "Delsscom Control Negocios Pro")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Function CantLte() As Double
        If cboLote.Tag <> 0 Then
            Try
                cnn5.Close() : cnn5.Open()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText = "Select Cantidad From LoteCaducidad Where id=" & cboLote.Tag
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        CantLte = rd5(0).ToString
                    End If
                End If
                rd5.Close() : cnn5.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn5.Close()
            End Try
        End If
    End Function

    Private Function Cambio(ByVal Moneda As Double) As Double
        Cambio = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select * from Productos where Codigo='" & Trim(cbocodigo.Text) & "'"
            rd3 = cmd3.ExecuteReader

            Select Case cbotipo.Text
                Case Is = "Lista"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PrecioVentaIVA").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PrecioVentaIVA").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Lista 2"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PrecioVentaIVA2").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PrecioVentaIVA2").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Minimo"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMin").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMin").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Minimo 2"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMin2").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMin2").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Mayoreo"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMay").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMay").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Mayoreo 2"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMay2").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMay2").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Medio Mayoreo"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMM").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMM").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Medio Mayoreo 2"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMM2").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMM2").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Especial"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreEsp").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreEsp").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

                Case Is = "Especial 2"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreEsp2").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreEsp2").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()

            End Select

            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
        Return Cambio
    End Function

    Public Sub CodBar()
        If cbocodigo.Text = "" And cbodesc.Text = "" Then Exit Sub

        'Código de barras 1
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            If cbocodigo.Text = "" Then
                cmd3.CommandText =
                    "select * from Productos where CodBarra='" & cbodesc.Text & "'"
            Else
                cmd3.CommandText =
                    "select * from Productos where CodBarra='" & cbocodigo.Text & "'"
            End If
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    cbocodigo.Text = rd3("Codigo").ToString
                    Anti = rd3("Grupo").ToString
                End If
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try

        'Código de barras 2
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            If cbocodigo.Text = "" Then
                cmd3.CommandText =
                    "select * from Productos where CodBarra1='" & cbodesc.Text & "'"
            Else
                cmd3.CommandText =
                    "select * from Productos where CodBarra1='" & cbocodigo.Text & "'"
            End If
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    cbocodigo.Text = rd3("Codigo").ToString
                    Anti = rd3("Grupo").ToString
                End If
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try

        'Código de barras 3
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            If cbocodigo.Text = "" Then
                cmd3.CommandText =
                    "select * from Productos where CodBarra2='" & cbodesc.Text & "'"
            Else
                cmd3.CommandText =
                    "select * from Productos where CodBarra2='" & cbocodigo.Text & "'"
            End If
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    cbocodigo.Text = rd3("Codigo").ToString
                    Anti = rd3("Grupo").ToString
                End If
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Sub cbocodigo_Click(sender As Object, e As EventArgs) Handles cbocodigo.Click
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_TextChanged(sender As Object, e As EventArgs) Handles cbocodigo.TextChanged
        Dim nombre As String = cbocodigo.Text
        If System.IO.File.Exists(ruta_servidor & "\ProductosImg\" & nombre & ".jpg") Then
            '  picProd.Image = System.Drawing.Image.FromFile(ruta_servidor & "\ProductosImg\" & nombre & ".jpg")
        End If
    End Sub

    Private Sub cbocodigo_DropDown(sender As Object, e As EventArgs) Handles cbocodigo.DropDown
        cbocodigo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Codigo FROM Productos WHERE LEFT(Codigo, 6) = LEFT('" & cbocodigo.Text & "', 6) ORDER BY Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbocodigo.Items.Add(
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

    Private Sub cbocodigo_GotFocus(sender As Object, e As EventArgs) Handles cbocodigo.GotFocus
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)

        T_Precio = DatosRecarga("TipoPrecio")
        H_Inicia = DatosRecarga("HoraInicia")
        H_Final = DatosRecarga("HoraTermina")
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter And (cbocodigo.Text <> "" Or cbodesc.Text <> "") Then
            Dim MCD As Double = 0
            Dim Multiplo As Double = 0
            Dim Minimo As Double = 0
            Dim TiCambio As Double = 0
            Dim PreLst As Double = 0, PreEsp As Double = 0
            Dim H_Actual As String = Format(Date.Now, "HH:mm")

            If cbocodigo.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Promo = IIf(rd1("Status_Promocion").ToString = True, True, False)
                            Anti = rd1("Grupo").ToString
                            If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                                cbodesc.Text = rd1("Nombre").ToString
                                txtprecio.Text = rd1("PrecioVentaIVA").ToString
                                txtprecio.Tag = rd1("PrecioVentaIVA").ToString
                                txtprecio.Text = FormatNumber(txtprecio.Text, 4)

                                txtunidad.Text = rd1("UVenta").ToString
                                txtexistencia.Text = CDbl(IIf(rd1("Existencia").ToString = "", "0", rd1("Existencia").ToString))
                                txtcantidad.Focus().Equals(True)
                                rd1.Close()
                                cnn1.Close()
                                Exit Sub
                            End If

                            'If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cbocodigo.Text & ".jpg") Then
                            '    '   picProd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cbocodigo.Text & ".jpg")
                            'End If

                            txtunidad.Text = rd1("UVenta").ToString()
                            cbocodigo.Text = rd1("Codigo").ToString()
                            cbodesc.Text = rd1("Nombre").ToString()
                            MCD = rd1("MCD").ToString()
                            Multiplo = rd1("Multiplo").ToString()
                            Minimo = rd1("Min").ToString()

                            cnn2.Close() : cnn2.Open()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                            "select Existencia from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    txtexistencia.Text = FormatNumber(CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) / Multiplo, 2)
                                End If
                            End If
                            rd2.Close()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select FechaC from ComprasDet where Codigo='" & cbocodigo.Text & "' LIMIT 1"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    Label2.Text = "Descripción " & FormatDateTime(rd2(0).ToString, DateFormat.ShortDate)
                                End If
                            Else
                                Label2.Text = "Descripción"
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

                            cboLote.Items.Clear()
                            cmd2 = cnn2.CreateCommand
                            If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                                cmd2.CommandText =
                                    "select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                                rd2 = cmd2.ExecuteReader
                                Do While rd2.Read
                                    If rd2.HasRows Then cboLote.Items.Add(rd2("Lote").ToString())
                                Loop
                                rd2.Close()
                            Else
                                If cbocodigo.Text = "" Then Exit Sub
                                cmd2.CommandText =
                                    "select distinct(Lote) as Lt from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Cantidad>0"
                                rd2 = cmd2.ExecuteReader
                                Do While rd2.Read
                                    If rd2.HasRows Then cboLote.Items.Add(rd2("Lt").ToString())
                                Loop
                                rd2.Close()
                            End If

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
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText =
                                            "select Precio from VentasDetalle where Codigo='" & cbocodigo.Text & "' and Folio=" & cbonota.Text & ""
                                        rd2 = cmd2.ExecuteReader
                                        If rd2.HasRows Then
                                            If rd2.Read Then
                                                txtprecio.Text = rd2(0).ToString
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
                                        rd2.Close()
                                    End If
                                End If
                            End If
                            cnn2.Close()
                        End If
                    Else
                        MsgBox("El código no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        cbocodigo.Focus().Equals(True)
                        Exit Sub
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            txtcantidad.Focus().Equals(True)
            My.Application.DoEvents()
            ' leePeso()
            My.Application.DoEvents()
        End If

        If AscW(e.KeyChar) = Keys.Enter And (cbocodigo.Text = "" And cbodesc.Text = "") Then
            If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                btndevo.Focus().Equals(True)
            Else
                Dim descu As Double = 0
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select NotasCred from Formatos where Facturas='MDescuento'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            descu = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                If descu > 0 Then
                    txtdescuento1.ReadOnly = False
                Else
                    txtdescuento1.ReadOnly = True
                End If
            End If
            If Me.Text = "Ventas (1)" Then
                    txtefectivo.Focus().Equals(True)
                End If
                'If Me.Text = "Cotización (1)" Then
                '    Button3.Focus().Equals(True)
                'End If
            End If

    End Sub

    Private Sub txtcantidad_Click(sender As Object, e As EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If txtcantidad.Text = "" Then Exit Sub
        If AscW(e.KeyChar) = Keys.Enter And cbodesc.Text = "" Then cbodesc.Focus().Equals(True)
        If AscW(e.KeyChar) = Keys.Enter Then

            Try
                Dim VSE As Boolean = False
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT VSE FROM Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        VSE = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                If VSE = True Then
                    If txtunidad.Text <> "N/A" Then
                        Dim canti As Double = txtcantidad.Text
                        Dim exis As Double = txtexistencia.Text
                        If canti > exis Then
                            MsgBox("No puedes vender una cantidad mayor a las existencias registradas", vbCritical + vbOKOnly, "Delsscom COntrol Negocios PRO")
                            txtcantidad.Focus.Equals(True)
                            Exit Sub
                        End If
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

            If Not IsNumeric(txtcantidad.Text) Then txtcantidad.Text = ""

            Dim Edita As Boolean = False
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Permisos WHERE IdEmpleado=" & id_usu_log
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Edita = rd1("Vent_EPrec").ToString
                    End If
                End If

                rd1.Close()

                If Edita = False Then
                    If cbocodigo.Text = "" Then cbodesc.Focus().Equals(True) : Exit Sub
                    If ValCantDev(13) = False Then
                        Exit Sub
                    End If

                    If CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text)) = 0 Or txtcantidad.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub
                    If CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text)) = 0 Or txtprecio.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select PreMin,PreMin2 from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                            Dim premin1 As Double = 0
                            Dim premin2 As Double = 0
                            Dim premasbajo As Double = 0

                            premin1 = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                            premin2 = IIf(rd1(1).ToString = "", 0, rd1(1).ToString)

                            premasbajo = Math.Min(premin1, premin2)
                            Dim precioxd As Double = txtprecio.Text
                            'CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) 
                            If CDbl(precioxd) < CDbl(premasbajo) Then
                                MsgBox("El precio de venta mínimo para el producto es de " & FormatNumber(CDbl(rd1(0).ToString), 4) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtprecio.SelectionStart = 0 : txtprecio.SelectionLength = Len(txtprecio.Text) : Exit Sub
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                    rd1.Close()

                    txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
                    txttotal.Text = FormatNumber(txttotal.Text, 4)
                    txtprecio.Focus().Equals(True)
                Else
                    If ValCantDev(13) = False Then
                        cnn1.Close()
                        Exit Sub
                    End If
                    txtprecio.Focus().Equals(True)
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If
    End Sub

    Private Function ValCantDev(ByVal ka As Integer) As Boolean
        Try
            Dim getpaso As Boolean = False
            ValCantDev = False

            If cbonota.Text <> "" Then
                If cbocodigo.Text <> "" And ka = 13 Then
                    Call Cant(cbocodigo.Text, getpaso)
                    ValCantDev = getpaso
                End If
            Else
                ValCantDev = True
            End If

            Return ValCantDev
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Function

    Private Function CalPreDevo(ByVal folio As Integer, ByVal cod As String) As Double
        Dim precio As Double = 0

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Precio FROM VentasDetalle where Folio=" & folio & " and Codigo='" & cbocodigo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    precio = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
                End If
            Else
                precio = 0
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try

        Return precio
    End Function

    Private Sub Cant(ByVal codigo As String, ByRef paso As Boolean)
        Dim canti As Double = 0
        If txtcantidad.Text = "" Then Exit Sub
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select Folio,Codigo,Cantidad from VentasDetalle where Folio=" & cbonota.Text & " and Codigo='" & codigo & "' order by Nombre"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    canti = rd5(2).ToString
                    If CDbl(txtcantidad.Text) > canti Then
                        MsgBox("No puedes devolver una cantidad mayor a la vendida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtcantidad.SelectionStart = 0
                        txtcantidad.SelectionLength = Len(txtcantidad.Text)
                        rd5.Close() : cnn5.Close()
                        paso = False
                        Exit Sub
                    Else
                        paso = True
                        txtprecio.Focus().Equals(True)
                    End If
                End If
            End If
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged
        Dim temp As Double = 0
        Dim TiCambio As Double = 0
        Dim H_Actual As String = Format(Date.Now, "HH:mm")
        If txtcantidad.Text = "" Or txtcantidad.Text = "." Then Exit Sub

        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    TiCambio = rd4(0).ToString
                    If TiCambio = 0 Then TiCambio = 1
                End If
            Else
                TiCambio = 1
            End If
            rd4.Close()

            If cbotipo.Visible = False Then
                If Promo = True Then
                    txttotal.Text = CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text)) * CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text))
                    txttotal.Text = FormatNumber(txttotal.Text, 4)
                    rd4.Close() : cnn4.Close()
                    Exit Sub
                End If

                Dim ATemp1, ATemp2, ATemp3, ATemp4 As Double

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                rd4 = cmd4.ExecuteReader
                If rd4.HasRows Then
                    If rd4.Read Then
                        If T_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                            txtprecio.Text = CDbl(IIf(rd4("PreEsp").ToString = "", "0", rd4("PreEsp").ToString)) * TiCambio
                            txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                            txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                        Else
                            txtprecio.Text = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString)) * TiCambio
                            txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                            txtprecio.Tag = FormatNumber(txtprecio.Text, 4)

                            If Not IsDBNull(rd4("CantLst1").ToString) And Not IsDBNull(rd4("CantLst2").ToString) Then
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantLst1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantLst2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantLst3").ToString) And Not IsDBNull(rd4("CantLst4").ToString) Then
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantLst3").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantLst4").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PrecioVentaIVA2").ToString = "", "0", rd4("PrecioVentaIVA2").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantEsp1").ToString) And Not IsDBNull(rd4("CantEsp2").ToString) Then
                                ATemp1 = rd4("CantEsp1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantEsp1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantEsp2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreEsp").ToString = "", "0", rd4("PreEsp").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantEsp3").ToString) And Not IsDBNull(rd4("CantEsp4").ToString) Then
                                ATemp1 = rd4("CantEsp3").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantEsp3").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantEsp4").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreEsp2").ToString = "", "0", rd4("PreEsp2").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMM1").ToString) And Not IsDBNull(rd4("CantMM2").ToString) Then
                                ATemp2 = rd4("CantMM1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMM1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMM2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMM").ToString = "", "0", rd4("PreMM").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMM3").ToString) And Not IsDBNull(rd4("CantMM4").ToString) Then
                                ATemp2 = rd4("CantMM3").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMM3").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMM4").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMM2").ToString = "", "0", rd4("PreMM2").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMay1").ToString) And Not IsDBNull(rd4("CantMay2").ToString) Then
                                ATemp3 = rd4("CantMay1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMay1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMay2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMay").ToString = "", "0", rd4("PreMay").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMay3").ToString) And Not IsDBNull(rd4("CantMay4").ToString) Then
                                ATemp3 = rd4("CantMay3").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMay3").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMay4").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMay2").ToString = "", "0", rd4("PreMay2").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMin1").ToString) And Not IsDBNull(rd4("CantMin2").ToString) Then
                                ATemp4 = rd4("CantMin1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMin1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMin2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMin").ToString = "", "0", rd4("PreMin").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMin3").ToString) And Not IsDBNull(rd4("CantMin4").ToString) Then
                                ATemp4 = rd4("CantMin3").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMin3").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMin4").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMin2").ToString = "", "0", rd4("PreMin2").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    temp = 1
                                End If
                            End If

                        End If

                        If ATemp1 <> 0 Or ATemp2 <> 0 Or ATemp3 <> 0 Or ATemp4 <> 0 Then
                            If temp = 0 Then
                                cnn5.Close() : cnn5.Open()
                                cmd5 = cnn5.CreateCommand
                                cmd5.CommandText =
                                    "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                                rd5 = cmd5.ExecuteReader
                                If rd5.HasRows Then
                                    If rd5.Read Then
                                        txtprecio.Text = CDbl(IIf(rd5("PrecioVentaIVA").ToString = "", "0", rd5("PrecioVentaIVA").ToString))
                                        txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                                        txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                                    End If
                                Else
                                    MsgBox("El producto no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                End If
                                rd5.Close()
                                cnn5.Close()
                                rd4.Close() : cnn4.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                rd4.Close()
            End If
            cnn4.Close()


            If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                txtprecio.Text = CalPreDevo(cbonota.Text, cbocodigo.Text)
                txtprecio.Text = FormatNumber(txtprecio.Text, 4)
                txtprecio.Tag = FormatNumber(txtprecio.Text, 4)
                txtprecio.ReadOnly = True
            Else
                txtprecio.ReadOnly = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
        If txtprecio.Text = "" Then txtprecio.Text = "0.00"
    End Sub

    Private Sub txtprecio_Click(sender As Object, e As EventArgs) Handles txtprecio.Click
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_GotFocus(sender As Object, e As EventArgs) Handles txtprecio.GotFocus
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress


        Dim editap As Boolean = False
        Dim VSE As Boolean = False

        If Not IsNumeric(txtprecio.Text) Then txtprecio.Text = ""
        If cbocodigo.Text = "" Then MsgBox("Necesitas seleccionar un producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbodesc.Focus().Equals(True) : Exit Sub

        Try

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT VSE FROM Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    VSE = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If VSE = True Then
                If txtunidad.Text <> "N/A" Then
                    Dim canti As Double = txtcantidad.Text
                    Dim exis As Double = txtexistencia.Text
                    If canti > exis Then
                        MsgBox("No puedes vender una cantidad mayor a las existencias registradas", vbCritical + vbOKOnly, "Delsscom Control Negocios PRO")
                        txtcantidad.Focus.Equals(True)
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Vent_EPrec from Permisos where IdEmpleado=" & id_usu_log
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    editap = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If CStr(rd1(0).ToString) = "SERVICIOS" Then
                        If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                        If AscW(e.KeyChar) = Keys.Enter Then
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select *  from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                cboLote.Focus().Equals(True)
                            Else
                                rd1.Close() : cnn1.Close()
                                rd2.Close() : cnn2.Close()
                                cboLote_KeyPress(cboLote, New KeyPressEventArgs(ChrW(Keys.Enter)))
                            End If
                            rd2.Close() : cnn2.Close()
                        End If
                    Else
                        If VSE = True Then
                            Dim existencia As Double = rd1("Existencia").ToString
                            Dim TExiste As Double = existencia - CDbl(txtcantidad.Text)

                            If TExiste < 0 And btndevo.Text = "DEVOLUCIÓN" Then
                                If Me.Text = "Ventas(1)" Then
                                    If txtunidad.Text <> "N/A" Then
                                        MsgBox("No puedes vender sin existencia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                        txtcantidad.Focus().Equals(True)
                                        rd1.Close() : cnn1.Close()
                                        Exit Sub
                                    End If
                                Else
                                    If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                    If AscW(e.KeyChar) = Keys.Enter Then
                                        cnn2.Close() : cnn2.Open()
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText =
                                "select *  from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                                        rd2 = cmd2.ExecuteReader
                                        If rd2.HasRows Then
                                            cboLote.Focus().Equals(True)
                                        Else
                                            rd1.Close() : cnn1.Close()
                                            rd2.Close() : cnn2.Close()
                                            cboLote_KeyPress(cboLote, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                        End If
                                        rd2.Close() : cnn2.Close()
                                    End If
                                End If
                            Else
                                If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                If AscW(e.KeyChar) = Keys.Enter Then
                                    cnn2.Close() : cnn2.Open()
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                "select *  from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        cboLote.Focus().Equals(True)
                                    Else
                                        rd1.Close() : cnn1.Close()
                                        rd2.Close() : cnn2.Close()
                                        cboLote_KeyPress(cboLote, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                    End If
                                    rd2.Close() : cnn2.Close()
                                End If
                            End If
                        Else
                            If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                            If AscW(e.KeyChar) = Keys.Enter Then
                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                "select *  from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    cboLote.Focus().Equals(True)
                                Else
                                    rd1.Close() : cnn1.Close()
                                    rd2.Close() : cnn2.Close()
                                    cboLote_KeyPress(cboLote, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                End If
                                rd2.Close() : cnn2.Close()
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If txtprecio.Text = "" Then
                txtprecio.Text = "0.00"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub txtprecio_TextChanged(sender As Object, e As EventArgs) Handles txtprecio.TextChanged
        txttotal.Text = CDbl(IIf(txtcantidad.Text = "" Or txtcantidad.Text = ".", "0", txtcantidad.Text)) * CDbl(IIf(txtprecio.Text = "" Or txtprecio.Text = ".", "0", txtprecio.Text))
        txttotal.Text = FormatNumber(txttotal.Text, 4)
    End Sub

    Private Sub txttotal_Click(sender As Object, e As EventArgs) Handles txttotal.Click
        txttotal.SelectionStart = 0
        txttotal.SelectionLength = Len(txttotal.Text)
    End Sub

    Private Sub txttotal_GotFocus(sender As Object, e As EventArgs) Handles txttotal.GotFocus
        txttotal.SelectionStart = 0
        txttotal.SelectionLength = Len(txttotal.Text)
    End Sub

    Private Sub txttotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotal.KeyPress
        Dim edita_pr As Boolean = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select EditaPrecios from Permisos where IdEmpleado=" & id_usu_log
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                edita_pr = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()
        If edita_pr = False And AscW(e.KeyChar) = 13 Then e.KeyChar = ChrW(0)

        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtprecio.Text) And IsNumeric(txttotal.Text) Then
                txtcantidad.Text = FormatNumber(CDbl(txttotal.Text) / CDbl(txtprecio.Text), 4)
            Else
                txttotal.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub txttotal_TextChanged(sender As Object, e As EventArgs) Handles txttotal.TextChanged
        Call Actualiza()
    End Sub

    Private Sub Actualiza()
        If txtSubTotal.Tag = 0 Then
            txtSubTotal.Text = txtSubTotal.Text
            txtSubTotal.Text = CDbl(IIf(txtSubTotal.Text = "", "0", txtSubTotal.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text))
            txtSubTotal.Text = FormatNumber(txtSubTotal.Text, 2)
        End If
        If txtSubTotal.Tag <> 0 Then
            txtSubTotal.Text = txtSubTotal.Text
        End If
    End Sub

    Private Sub cboLote_DropDown(sender As Object, e As EventArgs) Handles cboLote.DropDown
        cboLote.Items.Clear()
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
            cmd1.CommandText =
                "select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboLote.Items.Add(
                    rd1("Lote").ToString
                    )
            Loop
            rd1.Close()
        Else
            If cbocodigo.Text = "" Then Exit Sub
            cmd1.CommandText =
                "select distinct(Lote) as Lt from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Cantidad>0"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboLote.Items.Add(
                    rd1("Lt").ToString
                    )
            Loop
            rd1.Close()
        End If
        cnn1.Close()
    End Sub

    Private Sub cboLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboLote.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        Dim chec As Boolean = False
        Dim renta As Boolean = False
        Dim cant_lotes As Double = 0

        If cboLote.Text = "" Then
            If cboLote.Items.Count > 0 Then
                MsgBox("Necesitas seleccionar un lote de producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If
        End If

        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select VSE from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    chec = rd1(0).ToString()
                End If
            End If
            rd1.Close()


            If cboLote.Text <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Cantidad from LoteCaducidad where Lote='" & cboLote.Text & "' and Codigo='" & cbocodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cant_lotes = rd1(0).ToString()
                    End If
                End If
                rd1.Close()

                cant_lotes = cant_lotes - CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text))

                For i = 0 To grdCaptura.Rows.Count - 1
                    If grdCaptura.Rows(i).Cells(8).Value.ToString = cboLote.Text Then
                        cant_lotes = cant_lotes - CDec(grdCaptura.Rows(i).Cells(3).Value.ToString)
                    End If
                Next

                If cant_lotes < 0 Then
                    MsgBox("No cuentas con unidades suficiente del lote para venderlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cboLote.Text = ""
                    cbodesc.Focus().Equals(True)
                    cnn1.Close()
                    Exit Sub
                End If
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                    ElseIf CStr(rd1("Grupo").ToString()) = "RENTAS" Then
                        renta = True
                    Else
                        If chec = True Then
                            If btndevo.Text <> "GUARDAR DEVOLUCIÓN" Then
                                Dim Existe As Double = rd1("Existencia").ToString()
                                Dim TExiste As Double = Existe - CDbl(txtcantidad.Text)
                                If Me.Text = "Ventas (1)" Then
                                    If txtexistencia.Text <= 0 Then
                                        MsgBox("No está permitido vender sin existencias.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                        txtcantidad.Focus().Equals(True)
                                        rd1.Close() : cnn1.Close()
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()

            If ReviewLote() = False Then Exit Sub

            If cboLote.Tag = 0 Then
                cboLote.Text = ""
                cboLote.Tag = 0
                txtfechacad.Text = ""
            Else
                Dim CantLote As Double = CantLte()
                If CDbl(txtcantidad.Text) > CantLote Then
                    MsgBox("No cuentas con suficientes unidades para cubrir a cantidad ingresada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtcantidad.Focus().Equals(True)
                    cnn1.Close()
                    Exit Sub
                End If
            End If

            If ValCantDev(13) = False Then
                cnn1.Close()
                Exit Sub
            End If

            If Anti = "ANTIBIOTICO" Or Anti = "CONTROLADO" Then
                If MsgBox("Este producto es un " & Anti & ", ¿deseas continuar con el proceso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                    cbocodigo.Text = ""
                    cbodesc.Text = ""
                    txtunidad.Text = ""
                    txtcantidad.Text = ""
                    txtprecio.Text = "0.00"
                    txttotal.Text = "0.00"
                    txtexistencia.Text = ""
                    cboLote.Text = ""
                    txtfechacad.Text = ""
                    cbodesc.Focus().Equals(True)
                    cnn1.Close()
                    Exit Sub
                End If
            End If

            Dim dia As Integer = 0
            Dim decu As String = ""
            Dim pre_ini As Double = txtprecio.Text, pre_fini As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Dia,Descu from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    dia = rd1(0).ToString
                    decu = rd1(1).ToString
                End If
            End If
            rd1.Close()

            If dia = 0 Then
            Else
                If dia = CInt(txtdia.Text) Then
                    Dim descu As Double = CDbl(decu) / 100
                    Dim p1 As Double = CDbl(pre_ini) * descu
                    pre_fini = pre_ini - p1

                    txtprecio.Text = FormatNumber(pre_fini, 4)
                End If
            End If

            If cbocodigo.Text = "" Then cbodesc.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text)) = 0 Or txtcantidad.Text = "" Then cbocodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text)) = 0 Or txtprecio.Text = "" Then cbocodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select PreMin,PreMin2 from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If Promo = False Then

                        Dim premin1 As Double = 0
                        Dim premin2 As Double = 0
                        Dim premasbajo As Double = 0

                        premin1 = rd1(0).ToString
                        premin2 = rd1(1).ToString
                        premasbajo = Math.Min(premin1, premin2)
                        If CDbl(txtprecio.Text) < CDbl(IIf(premasbajo = 0, 0, premasbajo)) Then
                            If btndevo.Text <> "GUARDAR DEVOLUCIÓN" Then
                                MsgBox("El precio de venta mínimo establecido es de " & FormatNumber(premasbajo, 4) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                txtprecio.Focus().Equals(True)
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()

            txtefectivo.Text = "0.00"
            txtCambio.Text = "0.00"
            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
            txttotal.Text = FormatNumber(txttotal.Text, 4)
            Call UpGrid()

            'If Anti = "CONTROLADO" Or Anti = "ANTIBIOTICO" Then
            '    grdantis.Rows.Add(cbocodigo.Text, cbodesc.Text, txtunidad.Text, txtcantidad.Text, FormatNumber(txtprecio.Text, 4), FormatNumber(txttotal.Text, 4), FormatNumber(txtexistencia.Text, 4))
            'End If

            Dim VarSumXD As Double = 0
            Dim total_prods As Double = 0
            For w = 0 To grdCaptura.Rows.Count - 1
                If grdCaptura.Rows(w).Cells(5).Value.ToString = "" Then
                Else
                    VarSumXD = VarSumXD + (CDbl(grdCaptura.Rows(w).Cells(3).Value.ToString) * CDbl(grdCaptura.Rows(w).Cells(4).Value.ToString))
                    total_prods = total_prods + CDbl(grdCaptura.Rows(w).Cells(3).Value.ToString)
                End If
                txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            Next

            txtcant_productos.Text = total_prods

            If CDbl(txtdescuento1.Text) > 0 Then
                txtSubTotal.Tag = 1
            End If

            txtcoment.Text = ""
            cbocodigo.Text = ""
            cbocodigo.Items.Clear()
            cbodesc.Text = ""
            cbodesc.Items.Clear()
            txtunidad.Text = ""
            txtcantidad.Text = "1"
            txtprecio.Text = "0.00"
            txttotal.Text = "0.00"
            txtexistencia.Text = ""
            txtfechacad.Text = ""
            cboLote.Text = ""
            '      picProd.Image = Nothing
            cboLote.Items.Clear()
            cnn1.Close()
            donde_va = "Descuento Porcentaje"

            If CDbl(txtdescuento1.Text) <= 0 Then
                txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
                txtPagar.Text = FormatNumber(txtPagar.Text, 2)
            End If

            Call txtdescuento1_TextChanged(txtdescuento1, New EventArgs())

            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboLote_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboLote.SelectedValueChanged
        ReviewLote()
    End Sub

    Private Function ReviewLote() As Boolean
        ReviewLote = True
        If cboLote.Text <> "" Then
            ReviewLote = False
            Try
                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Lote='" & cboLote.Text & "' and Cantidad>0"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        cboLote.Tag = rd5("Id").ToString
                        txtfechacad.Text = rd5("Caducidad").ToString
                        ReviewLote = True
                    End If
                Else
                    MsgBox("El lote no está registrado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cboLote.Text = ""
                    cboLote.Tag = 0
                    txtfechacad.Text = ""
                    ReviewLote = False
                End If
                rd5.Close()
                cnn5.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn5.Close()
            End Try
        End If
    End Function

    Private Sub txtdescuento1_MultilineChanged(sender As Object, e As EventArgs) Handles txtdescuento1.MultilineChanged
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub

    Private Sub txtdescuento1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescuento1.KeyPress
        If txtdescuento1.Text = "" And AscW(e.KeyChar) = 46 Then
            txtdescuento1.Text = "0.00"
            txtdescuento1.SelectionStart = 0
            txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
            txtdescuento1.Focus().Equals(True)
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If modo_caja = "CAJA" Then
                txtefectivo.Focus().Equals(True)
            Else
                btnventa.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtdescuento1_Click(sender As Object, e As EventArgs) Handles txtdescuento1.Click
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub


    Private Sub txtdescuento1_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento1.TextChanged

    End Sub

    Private Sub btn500_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btn500.KeyPress

    End Sub
End Class