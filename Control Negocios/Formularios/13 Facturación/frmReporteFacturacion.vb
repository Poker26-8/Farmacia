Imports Core.DAL.CFDI
Imports Microsoft.Office.Interop.Excel
Imports Org.BouncyCastle.Cms

Public Class frmReporteFacturacion
    Private Sub cbo_DropDown(sender As Object, e As EventArgs) Handles cbo.DropDown
        Dim inicio As String = ""
        Dim final As String = ""
        inicio = Format(mc1.SelectionStart.ToShortDateString)
        final = Format(mc2.SelectionStart.ToShortDateString)
        cbo.Items.Clear()
        If optVentas.Checked = True Then
            cbo.Items.Add("TODAS")
            cbo.Items.Add("FACTURADAS")
            cbo.Items.Add("NO FACTURADAS")
        End If
        If optCli.Checked = True Then
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct nom_nombre_cliente from Facturas where nom_nombre_cliente<>'' and Fecha >='" & inicio & " 00:00:00 ' and Fecha <= '" & final & " 23:59:59' order by nom_nombre_cliente"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cbo.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        End If
        If optGlob.Checked = True Then
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select id_evento from Facturas where nom_rfc_cliente='XAXX010101000' order by id_evento desc"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cbo.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        grdcaptura.Rows.Clear()
        Dim inicio As String = ""
        Dim final As String = ""
        Dim soy1 As String = ""
        Dim soy2 As String = ""
        Dim soy3 As String = ""
        inicio = Format(mc1.SelectionStart.ToShortDateString)
        final = Format(mc2.SelectionStart.ToShortDateString)
        Dim idEvento As Integer = 0
        If optTotal.Checked = True Then

            Dim varFolioDx As String = ""
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from Facturas where Fecha >= '" & inicio & " 00:00:00' and Fecha <= '" & final & " 23:59:59' order by id_evento"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Select Folio from Ventas where Facturado ='" & rd1("id_evento").ToString & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.Read Then
                    varFolioDx = rd2(0).ToString
                    If varFolioDx <> "" Then
                        varFolioDx = varFolioDx
                    Else
                        varFolioDx = varFolioDx
                    End If
                End If

                rd2.Close()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Select Descripcion from FormaPagoSat where ClavePago='" & rd1("nom_metodo_pago").ToString & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.Read Then
                    soy3 = rd2(0).ToString
                End If
                rd2.Close()
                cnn2.Close()

                If rd1("nom_status").ToString = "1" Then
                    soy1 = "ACTIVA"
                Else
                    soy1 = "CANCELADA"
                End If
                If rd1("estatus_fac").ToString = "1" Then
                    soy2 = "FACTURA"
                ElseIf rd1("estatus_fac").ToString = "2" Then
                    soy2 = "PRE FACTURA"
                ElseIf rd1("estatus_fac").ToString = "3" Then
                    soy2 = "ERROR"
                ElseIf rd1("estatus_fac").ToString = "4" Then
                    soy2 = "ARRENDAMIENTO"
                ElseIf rd1("estatus_fac").ToString = "5" Then
                    soy2 = "HONORARIOS"
                ElseIf rd1("estatus_fac").ToString = "6" Then
                    soy2 = "NOTAS CREDITO"
                End If
                grdcaptura.Rows.Add(rd1("id_evento").ToString, varFolioDx, rd1("nom_nombre_cliente").ToString, FormatNumber(rd1("preciopaq").ToString, 2), rd1("iva").ToString, FormatNumber(rd1("nom_total_pagado").ToString, 2), FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), soy1, soy2, soy3)
            Loop
            rd1.Close()
            cnn1.Close()
        End If

        If optDet.Checked = True Then
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from Facturas where Fecha >='" & inicio & " 00:00:00' and Fecha <='" & final & " 23:59:59' order by id_evento"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "select * from detalle_factura where factura= " & rd1("nom_id").ToString & ""
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    grdcaptura.Rows.Add(rd1("id_evento").ToString, rd2("id_prod").ToString, rd2("descripcion").ToString, rd2("unidad").ToString, FormatNumber(rd2("cantidad").ToString, 2), FormatNumber(CDec(rd2("totaliva").ToString) / CDec(rd2("cantidad").ToString), 2), FormatNumber(rd2("totaliva").ToString, 2))
                Loop
                rd2.Close()
                cnn2.Close()
            Loop
            rd1.Close()
            cnn1.Close()
        End If

        If optCli.Checked = True Then
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from Facturas where nom_nombre_cliente='" & cbo.Text & "' and Fecha >='" & inicio & " 00:00:00' and Fecha <='" & final & " 23:59:59' order by id_evento"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Select Descripcion from FormaPagoSat where ClavePago='" & rd1("nom_metodo_pago").ToString & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.Read Then
                    soy3 = rd2(0).ToString
                End If
                rd2.Close()
                cnn2.Close()

                If rd1("nom_status").ToString = "1" Then
                    soy1 = "ACTIVA"
                Else
                    soy1 = "CANCELADA"
                End If
                If rd1("estatus_fac").ToString = "1" Then
                    soy2 = "FACTURA"
                ElseIf rd1("estatus_fac").ToString = "2" Then
                    soy2 = "PRE FACTURA"
                ElseIf rd1("estatus_fac").ToString = "3" Then
                    soy2 = "ERROR"
                ElseIf rd1("estatus_fac").ToString = "4" Then
                    soy2 = "ARRENDAMIENTO"
                ElseIf rd1("estatus_fac").ToString = "5" Then
                    soy2 = "HONORARIOS"
                ElseIf rd1("estatus_fac").ToString = "6" Then
                    soy2 = "NOTAS CREDITO"
                End If
                grdcaptura.Rows.Add(rd1("id_evento").ToString, rd1("nom_nombre_cliente").ToString, FormatNumber(rd1("preciopaq").ToString, 2), rd1("iva").ToString, FormatNumber(rd1("nom_total_pagado").ToString, 2), FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), soy1, soy2, soy3)
            Loop
            rd1.Close()
            cnn1.Close()
        End If

        If optGlob.Checked = True Then
            If cbo.Text = "" Then Exit Sub

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from Facturas where id_evento=" & cbo.Text & ""
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtFolFac.Text = rd1("id_evento").ToString
                txtClieFact.Text = rd1("nom_nombre_cliente").ToString
                txtStotFac.Text = FormatNumber(rd1("preciopaq").ToString, 2)
                txtivaFac.Text = rd1("iva").ToString
                txttotFac.Text = FormatNumber(rd1("nom_total_pagado").ToString, 2)
                txtFecFac.Text = FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate)
                GroupBox1.Visible = True

                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "select * from detalle_factura where Factura=" & rd1("nom_id").ToString & ""
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    grdcaptura.Rows.Add(rd2("descripcion").ToString, FormatNumber(rd2("preciou").ToString, 2), FormatNumber(CDec(rd2("totaliva").ToString) - CDec(rd2("preciou").ToString), 2), FormatNumber(rd2("totaliva").ToString, 2))
                Loop
                rd1.Close()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
        End If

        If optVentas.Checked = True Then
            Dim varFacturado As String = ""
            Dim f1 As Date = mc1.SelectionStart.ToShortDateString
            Dim f2 As Date = mc2.SelectionStart.ToShortDateString
            Dim varSubtotal As Double = 0
            Dim varIVA As Double = 0
            Dim varTotal As Double = 0
            If cbo.Text = "TODAS" Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from Ventas where Subtotal <> 0 and Totales <> 0 and FVenta >='" & Format(f1, "yyyy-MM-dd") & "' and FVenta <='" & Format(f2, "yyyy-MM-dd") & "' order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1("Facturado").ToString = "0" Then
                        varFacturado = "NO"
                    Else
                        varFacturado = "SI"
                    End If
                    grdcaptura.Rows.Add(rd1("Folio").ToString, rd1("Nombre").ToString, FormatNumber(rd1("Subtotal").ToString, 2), rd1("IVA").ToString, FormatNumber(rd1("Totales").ToString, 2), FormatDateTime(rd1("FVenta").ToString, DateFormat.ShortDate), varFacturado)
                Loop
                rd1.Close()
                cnn1.Close()
            ElseIf cbo.Text = "FACTURADAS" Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from Ventas where Facturado <> 0 and Subtotal <> 0 and Totales <> 0 and FVenta >='" & Format(f1, "yyyy-MM-dd") & "' and FVenta <='" & Format(f2, "yyyy-MM-dd") & "' order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    varFacturado = "SI"
                    grdcaptura.Rows.Add(rd1("Folio").ToString, rd1("Nombre").ToString, FormatNumber(rd1("Subtotal").ToString, 2), rd1("IVA").ToString, FormatNumber(rd1("Totales").ToString, 2), FormatDateTime(rd1("FVenta").ToString, DateFormat.ShortDate), varFacturado)

                    varSubtotal = CDec(varSubtotal) + CDec(rd1("Subtotal").ToString)
                    varIVA = CDec(varIVA) + CDec(rd1("IVA").ToString)
                    varTotal = CDec(varTotal) + CDec(rd1("Totales").ToString)
                Loop
                txtStotFac.Text = FormatNumber(varSubtotal, 2)
                txtivaFac.Text = FormatNumber(varIVA, 2)
                txttotFac.Text = FormatNumber(varTotal, 2)
                rd1.Close()
                cnn1.Close()
            ElseIf cbo.Text = "NO FACTURADAS" Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from Ventas where Facturado = 0 and Subtotal <> 0 and Totales <> 0 and FVenta >='" & Format(f1, "yyyy-MM-dd") & "' and FVenta <='" & Format(f2, "yyyy-MM-dd") & "' order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    varFacturado = "NO"
                    grdcaptura.Rows.Add(rd1("Folio").ToString, rd1("Nombre").ToString, FormatNumber(rd1("Subtotal").ToString, 2), rd1("IVA").ToString, FormatNumber(rd1("Totales").ToString, 2), FormatDateTime(rd1("FVenta").ToString, DateFormat.ShortDate), varFacturado)

                    varSubtotal = CDec(varSubtotal) + CDec(rd1("Subtotal").ToString)
                    varIVA = CDec(varIVA) + CDec(rd1("IVA").ToString)
                    varTotal = CDec(varTotal) + CDec(rd1("Totales").ToString)
                Loop
                txtStotFac.Text = FormatNumber(varSubtotal, 2)
                txtivaFac.Text = FormatNumber(varIVA, 2)
                txttotFac.Text = FormatNumber(varTotal, 2)
                rd1.Close()
                cnn1.Close()
            End If
        End If

        If (optParci.Checked) Then

            Dim foliopar As String = ""
            Dim idfractura As Integer = 0
            Dim clienterazon As String = ""
            Dim monto As Double = 0
            Dim fecha As Date = Nothing
            Dim stado As Integer = 0
            Dim estadoparcialidad As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Parcialidades WHERE Fecha between '" & Format(inicio, "yyyy/MM/dd") & "' AND '" & Format(final, "yyyy/MM/dd") & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    foliopar = rd1("FolioPar").ToString
                    idfractura = rd1("IdFact").ToString
                    clienterazon = rd1("CliRazon").ToString
                    monto = rd1("Monto").ToString
                    fecha = rd1("Fecha").ToString
                    stado = rd1("Estatus_Par").ToString

                    If stado = 1 Then
                        estadoparcialidad = "Activa"
                    Else
                        estadoparcialidad = "Cancelada"
                    End If

                    grdcaptura.Rows.Add(foliopar, idfractura, clienterazon, monto, fecha, fecha, estadoparcialidad, "Parcialidad")

                End If
            Loop
            rd1.Close()
            cnn1.Close()
        End If
    End Sub

    Private Sub optTotal_Click(sender As Object, e As EventArgs) Handles optTotal.Click
        grdcaptura.ColumnCount = 0
        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 10
        cbo.Visible = False
        GroupBox1.Visible = False
        With grdcaptura
            With .Columns(0)
                .HeaderText = "Factura"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .Width = 100
                .HeaderText = "Notas de Venta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "Cliente"
                .Width = 180
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Subtotal"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "IVA"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "Total"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "Fecha"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "Estatus"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "Tipo doc."
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "Forma de pago"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub optCli_Click(sender As Object, e As EventArgs) Handles optCli.Click
        grdcaptura.ColumnCount = 0
        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 9
        cbo.Visible = True
        cbo.Items.Clear()
        cbo.Text = ""
        GroupBox1.Visible = False
        With grdcaptura
            With .Columns(0)
                .HeaderText = "Factura"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .Width = 200
                .HeaderText = "cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "subtotal"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "IVA"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Total"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "Fecha"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "estatus"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "Tipo Doc."
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "Tipo de pago"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub optDet_Click(sender As Object, e As EventArgs) Handles optDet.Click
        grdcaptura.ColumnCount = 0
        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 7
        cbo.Visible = False
        GroupBox1.Visible = False
        With grdcaptura
            With .Columns(0)
                .HeaderText = "Factura"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .Width = 100
                .HeaderText = "Codigo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "Producto"
                .Width = 300
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Unidad"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Cantidad"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "Precio"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "Total"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub optGlob_Click(sender As Object, e As EventArgs) Handles optGlob.Click
        grdcaptura.ColumnCount = 0
        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 4
        cbo.Visible = True
        GroupBox1.Visible = True
        With grdcaptura
            With .Columns(0)
                .HeaderText = "# Nota de venta"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .Width = 100
                .HeaderText = "subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "IVA"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Total"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub optVentas_Click(sender As Object, e As EventArgs) Handles optVentas.Click
        grdcaptura.ColumnCount = 0
        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 7
        cbo.Visible = True
        GroupBox1.Visible = True
        With grdcaptura
            With .Columns(0)
                .HeaderText = "Nota de venta"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .Width = 300
                .HeaderText = "Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "Subtotal"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "IVA"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Total"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "Fecha"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "Facturado"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub optParci_CheckedChanged(sender As Object, e As EventArgs) Handles optParci.CheckedChanged

        grdcaptura.ColumnCount = 0
        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 8
        cboParci.Visible = False

        With grdcaptura

            With .Columns(0)
                .HeaderText = "Parcialidad"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(1)
                .HeaderText = "Factura"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(2)
                .HeaderText = "Cliente"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(3)
                .HeaderText = "Monto"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(4)
                .HeaderText = "Fecha"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(5)
                .HeaderText = "Fecha Pago"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(6)
                .HeaderText = "Status"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(7)
                .HeaderText = "Tipo Documento"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

        End With

    End Sub
End Class