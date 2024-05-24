﻿Public Class frmConsignacion
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
            cmd1.CommandText = "Select distinct Folio from Ventas where status='RESTA' and Folio <> ''"
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
        If txtefectivo.Text = "" Then
        Else
            txtrestaabono.Text = CDec(txtresta.Text) - CDec(txtefectivo.Text)
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
            CalculaDatos()
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
            MyPago = CDbl(txtefectivo.Text)
            If MyPago <> 0 Then
            Else
                MsgBox("El abono tiene que ser mayor a 0", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If

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
End Class