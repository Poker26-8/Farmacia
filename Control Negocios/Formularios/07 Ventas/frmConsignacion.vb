
Imports System.IO

Public Class frmConsignacion
    Public id As Integer = 0
    Public folio As Integer = 0
    Public precio As Double = 0
    Dim canti As Double = 0
    Public codigo As String = ""
    Public unidad As String = ""
    Public nombre As String = ""
    Private Sub cbofolio_DropDown(sender As Object, e As EventArgs) Handles cbofolio.DropDown
        Try
            cbofolio.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Folio from Ventas where status='RESTA' and Folio <> '' and Consignar=1"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cbofolio.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofolio.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from ventas where Folio=" & cbofolio.Text & ""
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                limpiaDatos()
                My.Application.DoEvents()
                txtvendedor.Text = rd1("Usuario").ToString
                lblid.Text = rd1("IdCliente").ToString
                cbonombre.Text = rd1("Cliente").ToString
                txtdireccion.Text = rd1("Direccion").ToString
                txtsubtotal.Text = FormatNumber(rd1("Subtotal").ToString, 2)
                txtdescuento.Text = FormatNumber(rd1("Descuento").ToString, 2)
                txttotal.Text = FormatNumber(rd1("Totales").ToString, 2)
                txtacuenta.Text = FormatNumber(rd1("ACuenta").ToString, 2)
                txtresta.Text = FormatNumber(rd1("Resta").ToString, 2)
                txtrestaabono.Text = FormatNumber(txtresta.Text, 2)
                GoTo perra
            Else
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
perra:
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from VentasDetalle where FOlio=" & cbofolio.Text & ""
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                grdcaptura.Rows.Add(rd1("Id").ToString, rd1("FOlio").ToString, rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("Unidad").ToString, rd1("Cantidad").ToString, rd1("CantidadC").ToString, rd1("Precio").ToString, rd1("Total").ToString)
            Loop
            rd1.Close()
            cnn1.Close()
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As EventArgs) Handles txtefectivo.TextChanged
        calculaAbono()
    End Sub
    Public Sub calculaAbono()
        If txtefectivo.Text = "" Or txtPagos.Text = "" Then
        Else
            txtrestaabono.Text = CDec(txtresta.Text) - CDec(txtefectivo.Text) - CDec(txtPagos.Text)
            txtrestaabono.Text = FormatNumber(txtrestaabono.Text, 2)
        End If

    End Sub
    Public Sub limpiaDatos()
        grdcaptura.Rows.Clear()
        txtsubtotal.Text = "0.00"
        txtdescuento.Text = "0.00"
        txtacuenta.Text = "0.00"
        txtefectivo.Text = "0.00"
        txtresta.Text = "0.00"
        txttotal.Text = "0.00"
        txtrestaabono.Text = "0.00"
    End Sub

    Private Sub grdcaptura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellContentClick

    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim fila As Integer = grdcaptura.CurrentRow.Index


        If celda.ColumnIndex = 6 Then
            boxcantidad.Visible = True
            txtcantidad.Focus().Equals(True)
            Dim selectedRow As DataGridViewRow = grdcaptura.Rows(e.RowIndex)
            id = selectedRow.Cells(0).Value.ToString
            folio = selectedRow.Cells(1).Value.ToString
            codigo = selectedRow.Cells(2).Value.ToString
            nombre = selectedRow.Cells(3).Value.ToString
            unidad = selectedRow.Cells(4).Value.ToString
            precio = selectedRow.Cells(7).Value.ToString
            canti = selectedRow.Cells(6).Value.ToString
            txtcantidad.Tag = selectedRow.Cells(5).Value.ToString

            'txtcodigo.Text = grdcaptura.CurrentRow.Cells(0).Value.ToString
            txtcodigo.Tag = fila
            'txtnombre.Text = grdcaptura.CurrentRow.Cells(1).Value.ToString
            txtcantidad.Focus().Equals(True)
        End If
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim fila As Integer = DataGridView1.CurrentRow.Index


        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        id = selectedRow.Cells(0).Value.ToString
        canti = selectedRow.Cells(5).Value.ToString
        txtcantidad.Tag = selectedRow.Cells(5).Value.ToString
        txtcodigo.Tag = fila

        For xxx As Integer = 0 To grdcaptura.Rows.Count - 1
            If grdcaptura.Rows(xxx).Cells(0).Value = id Then
                grdcaptura.Rows(xxx).Cells(6).Value = grdcaptura.Rows(xxx).Cells(6).Value - CDec(canti)
            End If
        Next

        DataGridView1.Rows.Remove(DataGridView1.Rows(fila))
        CalculaDatos()
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Or txtcantidad.Text = "0" Or txtcantidad.Text = "0.00" Then
                boxcantidad.Visible = False
                Exit Sub
            End If
            Dim inicial As Double = txtcantidad.Tag
            Dim final As Double = 0
            Dim actual As Double = 0
            Dim tot As Double = 0

            Dim precioxd As Double = precio
            Dim total As Double = CDbl(precio) * CDbl(txtcantidad.Text)

            actual = canti + CDec(txtcantidad.Text)

            If actual > inicial Then MsgBox("No puedes entregar una cantidad mayor a la que está pendiente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.SelectAll() : Exit Sub
            final = inicial - actual

            DataGridView1.Rows.Add(id, folio, codigo, nombre, unidad, txtcantidad.Text, FormatNumber(precio, 2), FormatNumber(total, 2))
            grdcaptura.Rows(txtcodigo.Tag).Cells(6).Value = grdcaptura.Rows(txtcodigo.Tag).Cells(6).Value + CDec(txtcantidad.Text)
            txtcantidad.Text = ""
            boxcantidad.Visible = False
            txtcodigo.Tag = ""
            txtcantidad.Tag = ""
            'CalculaDatos()
            My.Application.DoEvents()
        End If
    End Sub

    Public Sub CalculaDatos()
        Dim TotalAcumulado As Double = 0
        For xxx As Integer = 0 To DataGridView1.Rows.Count - 1
            TotalAcumulado = TotalAcumulado + CDec(DataGridView1.Rows(xxx).Cells(7).Value)
        Next
        txtefectivo.Text = FormatNumber(TotalAcumulado, 2)
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        cbofolio.Text = ""
        txtvendedor.Text = ""
        cbonombre.Text = ""
        txtdireccion.Text = ""
        DataGridView1.Rows.Clear()
        grdcaptura.Rows.Clear()
        txtefectivo.Text = "0.00"
        txtresta.Text = "0.00"
        txtrestaabono.Text = "0.00"
        txtsubtotal.Text = "0.00"
        txtdescuento.Text = "0.00"
        txttotal.Text = "0.00"
        txtacuenta.Text = "0.00"
        cbofolio.Focused.Equals(True)
        lblid.Text = ""
        boxcantidad.Visible = False
        txtcantidad.Text = ""
        chkConsignar.Checked = False
        ComboBox1.Text = ""
        grdpagos.Rows.Clear()
        txtPagos.Text = "0.00"
    End Sub

    Private Sub btnAbono_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("¿Deseas registrar el abono de los productos seleccionados?", vbQuestion + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                Exit Sub
            End If
            Dim MyPago As Double = 0
            Dim MySaldo As Double = 0

            Dim resta, acuenta, descuentos As Double
            MyPago = CDbl(txtefectivo.Text) + CDec(txtPagos.Text)
            If MyPago <> 0 Then
            Else
                MsgBox("El abono tiene que ser mayor a 0", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If
            If MyPago < 0 Then MsgBox("El pago no es válido. Corrobora la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            If MyPago > txttotal.Text Then MsgBox("El pago no puede ser mayor al total de la cuenta. Corrobora la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from ventas where Folio=" & cbofolio.Text & ""
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                resta = rd1("Resta").ToString()
                acuenta = rd1("ACuenta").ToString()
                descuentos = rd1("Descuento").ToString()
                If MyPago < resta Then
                    Dim n_resta As Double = resta - MyPago
                    Dim n_acuenta As Double = acuenta + MyPago
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                         "update Ventas set Resta=" & n_resta & ", ACuenta=" & n_acuenta & " where Folio=" & cbofolio.Text
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                Else
                    Dim n_acuenta As Double = acuenta + MyPago
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                    "update Ventas set Resta=0, ACuenta=" & n_acuenta & ", Status='PAGADO' where Folio=" & cbofolio.Text
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()

            For xxx As Integer = 0 To DataGridView1.Rows.Count - 1
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Update VentasDetalle set CantidadC=CantidadC+" & DataGridView1.Rows(xxx).Cells(5).Value & " where Id=" & DataGridView1.Rows(xxx).Cells(0).Value & " and Folio=" & DataGridView1.Rows(xxx).Cells(1).Value & ""
                If cmd1.ExecuteNonQuery Then

                Else

                End If
                cnn1.Close()
            Next


            Dim TotSaldo As Double = 0

            cnn1.Close() : cnn1.Open()

            Dim MyAcuent As Double = 0
            Dim efectivo As Double = 0
            Dim BancoP As String = ""
            Dim MontoP As Double = 0
            Dim RefeP As String = ""
            Dim FechaP As String = ""
            Dim comentario As String = ""
            Dim cuentarep As String = ""
            Dim bancorep As String = ""

            MyAcuent = CDbl(txtefectivo.Text)

            If MyAcuent > 0 Then
                efectivo = CDbl(txtefectivo.Text)

                If cbonombre.Text <> "MOSTRADOR" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & cbonombre.Text & "')"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()) - MyAcuent
                        End If
                    Else
                        MySaldo = 0
                    End If
                    rd1.Close()
                Else
                    MySaldo = 0
                End If

                If efectivo > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF,Comentario,CuentaC,BRecepcion) values(" & cbofolio.Text & "," & IIf(cbofolio.Text = "MOSTRADOR", 0, lblid.Text) & ",'" & cbonombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & efectivo & "," & MySaldo & ",'EFECTIVO'," & efectivo & ",'','','ADMIN',0,0,0,0,'','','')"
                    cmd1.ExecuteNonQuery()
                End If

                If grdpagos.Rows.Count > 0 Then

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select distinct FormaPago from FormasPago where FormaPago<>''"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            Dim FormaP As String = rd1(0).ToString()

                            For T As Integer = 0 To grdpagos.Rows.Count - 1
                                If CStr(grdpagos.Rows(T).Cells(0).Value.ToString()) = FormaP Then
                                    MontoP = MontoP + CDbl(grdpagos.Rows(T).Cells(3).Value.ToString())
                                    BancoP = BancoP & " - " & grdpagos.Rows(T).Cells(1).Value.ToString()
                                    RefeP = RefeP & " " & grdpagos.Rows(T).Cells(2).Value.ToString()
                                    comentario = comentario & " " & grdpagos.Rows(T).Cells(5).Value.ToString()
                                    cuentarep = cuentarep & " " & grdpagos.Rows(T).Cells(6).Value.ToString()
                                    bancorep = bancorep & " " & grdpagos.Rows(T).Cells(7).Value.ToString()

                                End If
                            Next

                            If FormaP = "SALDO FAVOR" Then
                                If MontoP > 0 Then
                                    TotSaldo = MontoP
                                End If
                            End If

                            If MontoP > 0 Then
                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                     "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF,Comentario,CuentaC,BRecepcion) values(" & cbofolio.Text & "," & IIf(lblid.Text = "MOSTRADOR", 0, lblid.Text) & ",'" & cbonombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MontoP & "," & MySaldo & ",'" & FormaP & "'," & MontoP & ",'" & BancoP & "','" & RefeP & "','ADMIN',0,0,0,0,'" & comentario & "','" & cuentarep & "','" & bancorep & "')"
                                cmd2.ExecuteNonQuery()
                                cnn2.Close()
                                MontoP = 0
                            End If
                        Else
                            MsgBox("No se Puede registrar el abono ya que una forma de pago no existe en el catalogo", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            Continue Do
                        End If
                    Loop
                    rd1.Close()
                End If


            End If

            cnn1.Close()
            MsgBox("Abonos registrados correctamente", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")

            Dim Imprime As Boolean = False
            Dim TPrint As String = "TICKET"
            Dim Imprime_En As String = ""
            Dim Impresora As String = ""
            Dim Tamaño As String = ""
            Dim Pasa_Print As Boolean = False

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Imprime = rd1("NoPrint").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

            If (Imprime) Then
                If MsgBox("¿Deseas imprimir nota de abono?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Pasa_Print = True
                Else
                    Pasa_Print = False
                End If
            Else
                Pasa_Print = True
            End If

            Try
                If Pasa_Print = True Then
                    Try
                        cnn3.Close() : cnn3.Open()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText =
                    "select Formato from RutasImpresion where Tipo='Venta' and Equipo='" & ObtenerNombreEquipo() & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                TPrint = rd3(0).ToString()
                            End If
                        End If
                        rd3.Close()

                        If TPrint = "" Then MsgBox("No se ha establecido un tamañao para la impresión.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cnn3.Close() : btnnuevo.PerformClick() : Exit Sub

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText =
                        "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                Impresora = rd3(0).ToString()
                            End If
                        End If
                        rd3.Close()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText =
                    "select NotasCred from Formatos where Facturas='TamImpre'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                Tamaño = rd3(0).ToString()
                            End If
                        Else
                            Tamaño = "80"
                        End If
                        rd3.Close()
                        cnn3.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString())
                        cnn3.Close()
                    End Try

                    If TPrint = "TICKET" Then
                        If Tamaño = "80" Then
                            PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            PrintDocument1.Print()
                        End If
                        If Tamaño = "58" Then
                            'pAbono58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            'pAbono58.Print()
                        End If
                    End If
                    If TPrint = "MEDIA CARTA" Then
                        'pVentaMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        'pVentaMediaCarta.Print()
                    End If
                    If TPrint = "CARTA" Then
                        'pVentaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        'pVentaCarta.Print()
                    End If
                    If TPrint = "PDF - CARTA" Then
                        'Genera PDF y lo guarda en la ruta

                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            btnnuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        Try
            ComboBox1.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Folio from Ventas where status='RESTA' and Folio <> ''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                ComboBox1.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If MsgBox("¿Deseas enviar a consignación el folio: " & ComboBox1.Text & "?", vbQuestion + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                Exit Sub
            End If

            Dim soy As Integer = 0

            If chkConsignar.Checked = True Then
                soy = 1
            Else
                soy = 0
            End If

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Update Ventas set Consignar=" & soy & " where Folio=" & ComboBox1.Text & ""
            If cmd1.ExecuteNonQuery Then
                MsgBox("Folio enviado a consignación correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close()
            Else
                MsgBox("Ocurrio un error al enviar el folio a consignación", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close()
            End If
            chkConsignar.Checked = False
            ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbotipo_DropDown(sender As Object, e As EventArgs) Handles cbotipo.DropDown
        cbotipo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct FormaPago from FormasPago where FormaPago<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbotipo.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbobanco_DropDown(sender As Object, e As EventArgs) Handles cbobanco.DropDown
        cbobanco.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Banco from Bancos"
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

    Private Sub cboCunetaRep_DropDown(sender As Object, e As EventArgs) Handles cboCunetaRep.DropDown
        Try
            cboCunetaRep.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCunetaRep.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnPago_Click(sender As Object, e As EventArgs) Handles btnPago.Click
        If cbotipo.Text = "" Then MsgBox("Falta el tipo de pago", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbotipo.Focus().Equals(True) : Exit Sub
        If cbobanco.Text = "" Then MsgBox("Falta el banco", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbobanco.Focus().Equals(True) : Exit Sub
        If txtnumero.Text = "" Then MsgBox("Falta el numero de referencia", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtnumero.Focus().Equals(True) : Exit Sub
        If txtmonto.Text = "" Or CDbl(txtmonto.Text) = 0 Then MsgBox("Ingresa un monto válido", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonto.Focus().Equals(True) : Exit Sub

        grdpagos.Rows.Add(cbotipo.Text, cbobanco.Text, txtnumero.Text, FormatNumber(txtmonto.Text, 2), FormatDateTime(dtpfecha.Value, DateFormat.ShortDate), "", cboCunetaRep.Text, txtBancoRep.Text)

        cbotipo.Text = ""
        cbobanco.Text = ""
        dtpfecha.Value = Now
        txtnumero.Text = ""
        txtmonto.Text = "0.00"
        Dim total_pagos As Double = 0
        For t1 As Integer = 0 To grdpagos.Rows.Count - 1
            total_pagos = total_pagos + CDbl(grdpagos.Rows(t1).Cells(3).Value.ToString())
        Next
        txtPagos.Text = FormatNumber(total_pagos, 2)
        cbotipo.Focus().Equals(True)
    End Sub

    Private Sub txtPagos_TextChanged(sender As Object, e As EventArgs) Handles txtPagos.TextChanged
        calculaAbono()
    End Sub

    Private Sub frmConsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Try
            Dim voy As Integer = 0
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Consignar from Ventas where Folio=" & ComboBox1.Text & ""
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                voy = rd1(0).ToString
            End If
            rd1.Close()
            cnn1.Close()
            If voy = 0 Then
                chkConsignar.Checked = False
            Else
                chkConsignar.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmRepConsignacion.Show()
        frmRepConsignacion.BringToFront()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 130
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                        Y += 120
                    End If
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
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

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("A B O N O", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If

                Dim codigo As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(6).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(7).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Adeudo anterior:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            'If CDbl(txtdescu.Text) > 0 Then
            '    e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
            '    e.Graphics.DrawString(simbolo & FormatNumber(txtdescu.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            '    Y += 13.5
            'End If
            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            'If CDbl(txtcambio.Text) > 0 Then
            '    e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
            '    e.Graphics.DrawString(simbolo & FormatNumber(txtcambio.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            '    Y += 13.5
            'End If

            Dim concepto As String = ""
            Dim monto As Double = 0

            If CDbl(txtPagos.Text) > 0 Then
                For r As Integer = 0 To grdpagos.Rows.Count - 1
                    concepto = grdpagos.Rows(r).Cells(0).Value.ToString
                    monto = CDbl(grdpagos.Rows(r).Cells(3).Value.ToString())

                    e.Graphics.DrawString("Pago con " & concepto & ":", fuente_prods, Brushes.Black, 1, Y)
                    If Len("Pago con " & concepto & ":") > 26 Then
                        Y += 13.5
                    End If
                    e.Graphics.DrawString(simbolo & FormatNumber(monto, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                    Y += 13.5
                Next
            End If
            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtrestaabono.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Y += 19

            e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            Y += 13.5
            If Mid(Pie, 36, 70) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If
            If Mid(Pie, 71, 105) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If
            Y += 18
            e.Graphics.DrawString("Lo atiende ", fuente_prods, Brushes.Black, 142.5, Y, sc)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
End Class