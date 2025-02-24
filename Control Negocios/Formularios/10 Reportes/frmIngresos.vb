Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class frmIngresos
    Private Sub frmIngresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        optVendedor.Checked = True
    End Sub

    Private Sub optVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles optVendedor.CheckedChanged
        If optVendedor.Checked = True Then
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 8
            txtCancelaefectivo.Text = "0.00"
            txtDevoefectivo.Text = "0.00"
            txtIngresos.Text = "0.00"
            txtEfectivo.Text = "0.00"
            'txtTarjeta.Text = "0.00"
            'txtTransfe.Text = "0.00"
            'txtMonedero.Text = "0.00"
            'txtDepo.Text = "0.00"
            txtTotalAbono.Text = "0.00"
            'txtCancelacionT.Text = "0.00"
            'txtCancelacionTrans.Text = "0.00"
            'txtDevolTrasn.Text = "0.00"
            'txtEgresoMon.Text = "0.00"
            'txtEgresoDep.Text = "0.00"
            txtEgresos.Text = "0.00"
            txtTotalAbono.Text = "0.00"
            txtEfeCaja.Text = "0.00"
            txtSalTarj.Text = "0.00"
            txttotalformas.Text = "0.00"
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Forma de Pago"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Monto de Pago"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False

                End With

                With .Columns(6)
                    .HeaderText = "Comentario"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        Try
            ComboBox1.Items.Clear()
            Dim M1 As Date = MC1.SelectionStart.ToShortDateString
            Dim M2 As Date = MC2.SelectionStart.ToShortDateString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Usuario from AbonoI where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Usuario"
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim VarEfectivo As Double
        Dim Ingresos As Double

        Dim Efectivo As Double
        Dim Tarjetas As Double
        Dim Transfe As Double
        Dim Deposito As Double
        Dim Monedero As Double

        Dim CancelaEfe As Double
        Dim DevoEfe As Double
        Dim CancelaTarj As Double
        Dim DevoTransf As Double
        Dim CancelaTransfe As Double

        txtCancelaefectivo.Text = "0.00"
        ' txtCancelacionT.Text = "0.00"
        txtDevoefectivo.Text = "0.00"
        txtIngresos.Text = "0.00"
        txtEfectivo.Text = "0.00"
        'txtTarjeta.Text = "0.00"
        'txtTransfe.Text = "0.00"
        'txtMonedero.Text = "0.00"
        'txtDepo.Text = "0.00"
        txtTotalAbono.Text = "0.00"
        txttotalformas.Text = "0.00"
        txtcancelacionestotales.Text = "0.00"

        Dim M1 As Date = MC1.SelectionStart.ToShortDateString
        Dim M2 As Date = MC2.SelectionStart.ToShortDateString

        Dim formapago As String = ""

        Dim sumaformas As Double = 0
        Dim sumatotalformas As Double = 0

        Dim SUMATOTALEFECTIVO As Double = 0

        Dim SUMACANCELACIONESEFEC As Double = 0
        Dim sumacancelacionestotalesEFEC As Double = 0

        Dim sumacancelacionesformas As Double = 0
        Dim sumacancelacionestotalesformas As Double = 0

        Dim devoluciones As Double = 0
        Dim sumadevoluciones As Double = 0



        If optVendedor.Checked = True Then
            If ComboBox1.Text = "" Then
                MsgBox("Selecciona un usuario para continuar con el reporte", vbCritical + vbOKOnly, "Delsscom Farmacias")
                Exit Sub
            End If
            grdpagos.Rows.Clear()
            grdcaptura.Rows.Clear()
            'grdCanceñlaciones.Rows.Clear()
            'grddevoluciones.Rows.Clear()


            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Monto,NumFolio,Cliente,Concepto,Fecha,FormaPago,Comentario,Usuario from Abonoi  where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto<>'NOTA VENTA' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                VarEfectivo = rd1("Monto")
                grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), rd1("FormaPago").ToString, FormatNumber(VarEfectivo, 2), rd1("Comentario").ToString, rd1("Usuario").ToString)
            Loop
            rd1.Close()
            cnn1.Close()

            Dim CONCEPTOABONO As String = ""


            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario='" & ComboBox1.Text & "' AND Concepto='ABONO'"

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    formapago = rd1(0).ToString
                    If formapago = "EFECTIVO" Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='ABONO' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                Efectivo = rd2(0).ToString
                                ' grdpagos.Rows.Add(formapago, Efectivo)
                                SUMATOTALEFECTIVO = SUMATOTALEFECTIVO + CDbl(Efectivo)
                            End If
                        End If
                        rd2.Close()
                    Else
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='ABONO' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                sumaformas = rd2(0).ToString
                                grdpagos.Rows.Add(formapago, sumaformas)
                                sumatotalformas = sumatotalformas + CDbl(sumaformas)
                            End If
                        End If
                        rd2.Close()
                    End If
                End If
            Loop
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario='" & ComboBox1.Text & "' AND Concepto='NOTA CANCELADA'"

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    formapago = rd1(0).ToString
                    If formapago = "EFECTIVO" Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"

                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                SUMACANCELACIONESEFEC = rd2(0).ToString
                                sumacancelacionestotalesEFEC = sumacancelacionestotalesEFEC + CDbl(SUMACANCELACIONESEFEC)
                            End If
                        End If
                        rd2.Close()
                    Else
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"

                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                sumacancelacionesformas = rd2(0).ToString
                                'grdCanceñlaciones.Rows.Add(formapago, sumacancelacionesformas)
                                sumacancelacionestotalesformas = sumacancelacionestotalesformas + CDbl(sumacancelacionesformas)
                            End If
                        End If
                        rd2.Close()
                    End If
                End If
            Loop
            rd1.Close()
            cnn2.Close()
            cnn1.Close()


            txtEfectivo.Text = FormatNumber(SUMATOTALEFECTIVO, 2)
            txtEfeCaja.Text = FormatNumber(CDec(txtEfectivo.Text) - CDec(txtCancelaefectivo.Text) - CDec(txtDevoefectivo.Text), 2)

            txttotalformas.Text = FormatNumber(sumatotalformas, 2)
            txtSalTarj.Text = FormatNumber(CDec(txttotalformas.Text) - CDec(txtcancelacionestotales.Text), 2)

            txtCancelaefectivo.Text = FormatNumber(sumacancelacionestotalesEFEC, 2)
            txtcancelacionestotales.Text = IIf(sumacancelacionestotalesformas = 0, 0, sumacancelacionestotalesformas)

            txtDevoefectivo.Text = FormatNumber(sumadevoluciones, 2)
            txtdevolucionesformas.Text = FormatNumber(sumadevoluciones, 2)

            txtIngresos.Text = FormatNumber(CDec(txtEfectivo.Text) + CDec(txttotalformas.Text), 2)
            txtEgresos.Text = FormatNumber(CDec(txtCancelaefectivo.Text) + CDec(txtDevoefectivo.Text) + CDec(IIf(txtcancelacionestotales.Text = 0, 0,
            txtcancelacionestotales.Text)) + CDec(txtdevolucionesformas.Text), 2)

            txtTotalAbono.Text = FormatNumber(CDec(txtIngresos.Text) - CDec(txtEgresos.Text), 2)

        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grdcaptura.Rows.Clear()
        txtCancelaefectivo.Text = "0.00"
        txtDevoefectivo.Text = "0.00"
        txtIngresos.Text = "0.00"
        txtEfectivo.Text = "0.00"
        txtTotalAbono.Text = "0.00"
        txtEgresos.Text = "0.00"
        txtTotalAbono.Text = "0.00"
        txtEfeCaja.Text = "0.00"
        txtSalTarj.Text = "0.00"
        txttotalformas.Text = "0.00"
        grdpagos.Rows.Clear()

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then

            ComboBox1.Text = ""
            ComboBox1.Visible = False
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 8
            txtCancelaefectivo.Text = "0.00"
            txtDevoefectivo.Text = "0.00"
            txtIngresos.Text = "0.00"
            txtEfectivo.Text = "0.00"

            txtTotalAbono.Text = "0.00"

            txtEgresos.Text = "0.00"
            txtTotalAbono.Text = "0.00"
            txtEfeCaja.Text = "0.00"
            txtSalTarj.Text = "0.00"
            txttotalformas.Text = "0.00"
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Forma de Pago"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Monto de Pago"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False

                End With

                With .Columns(6)
                    .HeaderText = "Comentario"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            If (RadioButton2.Checked) Then
                Dim VarEfectivo As Double
                Dim Ingresos As Double

                Dim Efectivo As Double

                Dim M1 As Date = MC1.SelectionStart.ToShortDateString
                Dim M2 As Date = MC2.SelectionStart.ToShortDateString

                Dim formapago As String = ""

                Dim sumaformas As Double = 0
                Dim sumatotalformas As Double = 0

                Dim SUMATOTALEFECTIVO As Double = 0

                Dim SUMACANCELACIONESEFEC As Double = 0
                Dim sumacancelacionestotalesEFEC As Double = 0

                Dim sumacancelacionesformas As Double = 0
                Dim sumacancelacionestotalesformas As Double = 0

                Dim devoluciones As Double = 0
                Dim sumadevoluciones As Double = 0


                grdpagos.Rows.Clear()
                grdcaptura.Rows.Clear()

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Monto,NumFolio,Cliente,Concepto,Fecha,FormaPago,Comentario,Usuario from Abonoi  where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and Concepto<>'NOTA VENTA' order by Id"
                rd1 = cmd1.ExecuteReader

                Do While rd1.Read
                    VarEfectivo = rd1("Monto")

                    grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), rd1("FormaPago").ToString, FormatNumber(VarEfectivo, 2), rd1("Comentario").ToString, rd1("Usuario").ToString)

                Loop
                rd1.Close()
                cnn1.Close()

                Dim CONCEPTOABONO As String = ""


                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario<>'' AND Concepto='ABONO'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        formapago = rd1(0).ToString

                        If formapago = "EFECTIVO" Then

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario<>'' AND Concepto='ABONO' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    Efectivo = rd2(0).ToString
                                    ' grdpagos.Rows.Add(formapago, Efectivo)
                                    SUMATOTALEFECTIVO = SUMATOTALEFECTIVO + CDbl(Efectivo)
                                End If
                            End If
                            rd2.Close()
                        Else
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario<>'' AND Concepto='ABONO' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    sumaformas = rd2(0).ToString
                                    grdpagos.Rows.Add(formapago, sumaformas)
                                    sumatotalformas = sumatotalformas + CDbl(sumaformas)
                                End If
                            End If
                            rd2.Close()
                        End If

                    End If
                Loop
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario<>'' AND Concepto='NOTA CANCELADA'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        formapago = rd1(0).ToString

                        If formapago = "EFECTIVO" Then

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario<>'' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                    SUMACANCELACIONESEFEC = rd2(0).ToString
                                    sumacancelacionestotalesEFEC = sumacancelacionestotalesEFEC + CDbl(SUMACANCELACIONESEFEC)
                                End If
                            End If
                            rd2.Close()

                        Else
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario<>'' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                    sumacancelacionesformas = rd2(0).ToString

                                    sumacancelacionestotalesformas = sumacancelacionestotalesformas + CDbl(sumacancelacionesformas)
                                End If
                            End If
                            rd2.Close()

                        End If

                    End If
                Loop
                rd1.Close()
                cnn2.Close()
                cnn1.Close()


                txtEfectivo.Text = FormatNumber(SUMATOTALEFECTIVO, 2)
                txtEfeCaja.Text = FormatNumber(CDec(txtEfectivo.Text) - CDec(txtCancelaefectivo.Text) - CDec(txtDevoefectivo.Text), 2)

                txttotalformas.Text = FormatNumber(sumatotalformas, 2)
                txtSalTarj.Text = FormatNumber(CDec(txttotalformas.Text) - CDec(txtcancelacionestotales.Text), 2)


                txtCancelaefectivo.Text = FormatNumber(sumacancelacionestotalesEFEC, 2)
                txtcancelacionestotales.Text = IIf(sumacancelacionestotalesformas = 0, 0, sumacancelacionestotalesformas)

                txtDevoefectivo.Text = FormatNumber(sumadevoluciones, 2)
                txtdevolucionesformas.Text = FormatNumber(sumadevoluciones, 2)


                txtIngresos.Text = FormatNumber(CDec(txtEfectivo.Text) + CDec(txttotalformas.Text), 2)
                txtEgresos.Text = FormatNumber(CDec(txtCancelaefectivo.Text) + CDec(txtDevoefectivo.Text) + CDec(IIf(txtcancelacionestotales.Text = 0, 0,
                txtcancelacionestotales.Text)) + CDec(txtdevolucionesformas.Text), 2)

                txtTotalAbono.Text = FormatNumber(CDec(txtIngresos.Text) - CDec(txtEgresos.Text), 2)

            End If


        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarDataGridViewAExcel(grdcaptura)
    End Sub
    Public Sub ExportarDataGridViewAExcel(dgv As DataGridView)
        If grdcaptura.Rows.Count = 0 Then MsgBox("Genera el reporte para poder exportar los datos a Excel.", vbInformation + vbOKOnly, titulocentral) : Exit Sub
        If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

            Dim voy As Integer = 0
            ' Crea un nuevo libro de trabajo de Excel
            Using workbook As New XLWorkbook()

                ' Añade una nueva hoja de trabajo
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Datos")

                ' Escribe los encabezados de columna
                For colIndex As Integer = 0 To dgv.Columns.Count - 1
                    Dim headerCell As IXLCell = worksheet.Cell(1, colIndex + 1)
                    worksheet.Cell(1, colIndex + 1).Value = dgv.Columns(colIndex).HeaderText
                    headerCell.Value = dgv.Columns(colIndex).HeaderText
                    headerCell.Style.Font.Bold = True  ' Aplica negrita a los encabezados
                Next


                For rowIndex As Integer = 0 To dgv.Rows.Count - 1
                    For colIndex As Integer = 0 To dgv.Columns.Count - 1
                        Dim cellValue As Object = dgv.Rows(rowIndex).Cells(colIndex).Value
                        Dim cellValueString As String = If(cellValue Is Nothing, String.Empty, cellValue.ToString())
                        worksheet.Cell(rowIndex + 2, colIndex + 1).Value = cellValueString
                        Dim cell As IXLCell = worksheet.Cell(rowIndex + 2, colIndex + 1)
                        cell.Value = cellValueString
                        cell.Style.NumberFormat.Format = "@"
                    Next
                    voy = voy + 1
                    My.Application.DoEvents()
                Next

                worksheet.Columns().AdjustToContents()
                ' Usa MemoryStream para guardar el archivo en memoria y abrirlo
                Using memoryStream As New System.IO.MemoryStream()
                    ' Guarda el libro de trabajo en el MemoryStream
                    workbook.SaveAs(memoryStream)

                    ' Guarda el MemoryStream en un archivo temporal para abrirlo
                    Dim tempFilePath As String = IO.Path.GetTempPath() & Guid.NewGuid().ToString() & ".xlsx"
                    System.IO.File.WriteAllBytes(tempFilePath, memoryStream.ToArray())

                    ' Abre el archivo temporal en Excel
                    Process.Start(tempFilePath)
                End Using

                'workbook.SaveAs(filePath)
            End Using
            MessageBox.Show("Datos exportados exitosamente")

        End If
    End Sub
End Class