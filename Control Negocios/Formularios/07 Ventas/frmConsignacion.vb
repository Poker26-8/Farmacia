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

    Private Sub Exportar_Click(sender As Object, e As EventArgs) Handles Exportar.Click
        If grdcaptura.Rows.Count = 0 Then
            MsgBox("Selecciona un folio consignado para exportar la información a excel", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        If MsgBox("¿Desea exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub
        Exportar.Enabled = False

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Application.ActiveSheet

            Dim Fila As Integer = 0
            Dim Col As Integer = 0

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = grdcaptura.ColumnCount
            Dim NRow As Integer = grdcaptura.RowCount

            exHoja.Columns("A").NumberFormat = "@"
            exHoja.Columns("B").NumberFormat = "@"
            exHoja.Columns("C").NumberFormat = "@"
            exHoja.Columns("D").NumberFormat = "@"
            exHoja.Columns("I").NumberFormat = "@"
            exHoja.Columns("G").NumberFormat = "@"
            exHoja.Columns("K").NumberFormat = "@"
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila = 0 To NRow - 1
                For Col = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
                Next
            Next

            Dim Fila2 As Integer = Fila + 2
            Dim Col2 As Integer = Col

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            Exportar.Enabled = True
            'Aplicación visible
            MsgBox("Información exportada correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
            My.Application.DoEvents()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Exportar.Enabled = True
        End Try
    End Sub
End Class