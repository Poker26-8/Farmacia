Imports ClosedXML.Excel
Imports Microsoft.Office.Interop
Public Class frmRepEntradas



    'Friend WithEvents txtforma1 As System.Windows.Forms.TextBox



    Private Sub frmRepEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                Dim devolucionesEFEC As Double = 0
                Dim sumadevolucionesEFEC As Double = 0
                Dim sumadevolucionesTOTALESEFEC As Double = 0

                Dim devolucionesFORMAS As Double = 0
                Dim sumadevolucionesFORMAS As Double = 0
                Dim sumadevolucionesTOTALESFORMAS As Double = 0


                grdpagos.Rows.Clear()
                grdcaptura.Rows.Clear()
                grdCanceñlaciones.Rows.Clear()
                grddevoluciones.Rows.Clear()

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
                                    grdCanceñlaciones.Rows.Add(formapago, sumacancelacionesformas)
                                    sumacancelacionestotalesformas = sumacancelacionestotalesformas + CDbl(sumacancelacionesformas)
                                End If
                            End If
                            rd2.Close()

                        End If

                    End If
                Loop
                rd1.Close()
                ''''''''''''''''''''''''''''''''

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario<>'' AND Concepto='DEVOLUCION'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        formapago = rd1(0).ToString

                        If formapago = "EFECTIVO" Then

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario<>'' AND Concepto='DEVOLUCION' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                    sumadevolucionesEFEC = rd2(0).ToString
                                    sumadevolucionesTOTALESEFEC = sumadevolucionesTOTALESEFEC + CDbl(sumadevolucionesEFEC)
                                End If
                            End If
                            rd2.Close()

                        Else
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario<>'' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                    sumadevolucionesFORMAS = rd2(0).ToString
                                    grddevoluciones.Rows.Add(formapago, sumadevolucionesFORMAS)
                                    sumadevolucionesTOTALESFORMAS = sumadevolucionesTOTALESFORMAS + CDbl(sumadevolucionesFORMAS)
                                End If
                            End If
                            rd2.Close()

                        End If
                        sumadevoluciones = sumadevolucionesTOTALESEFEC + sumadevolucionesTOTALESFORMAS
                    End If
                Loop
                rd1.Close()

                rd2.Close()

                Dim otrosgastos As Double = 0
                'Otros gastos
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select SUM(Total) from OtrosGastos where Usuario<>'' and CorteU=0 AND Concepto<>'NOMINA'AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        otrosgastos = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                        otrosgastos = FormatNumber(otrosgastos, 2)
                    End If
                End If
                rd2.Close()


                Dim efecompras As Double = 0
                Dim trasnfecompras As Double = 0
                Dim tarjecompras As Double = 0
                Dim otrocompras As Double = 0
                Dim sumatodocomppras As Double = 0

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                      "SELECT SUM(Efectivo) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        efecompras = CDec(efecompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                    End If
                End If
                rd2.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                      "SELECT SUM(Tarjeta) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        tarjecompras = CDec(tarjecompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                    End If
                End If
                rd2.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                      "SELECT SUM(Transfe) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        trasnfecompras = CDec(trasnfecompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                    End If
                End If
                rd2.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                      "SELECT SUM(Otro) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        otrocompras = CDec(otrocompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                    End If
                End If
                rd2.Close()
                sumatodocomppras = efecompras + tarjecompras + trasnfecompras + otrocompras


                txtCompras.Text = FormatNumber(sumatodocomppras, 2)


                ''''''''''''''''''''''''''''''''
                cnn2.Close()
                cnn1.Close()


                txtEfectivo.Text = FormatNumber(SUMATOTALEFECTIVO, 2)

                My.Application.DoEvents()
                txttotalformas.Text = FormatNumber(sumatotalformas, 2)
                txtSalTarj.Text = FormatNumber(CDec(txttotalformas.Text) - CDec(txtcancelacionestotales.Text), 2)

                My.Application.DoEvents()

                txtCancelaefectivo.Text = FormatNumber(sumacancelacionestotalesEFEC, 2)
                txtcancelacionestotales.Text = IIf(sumacancelacionestotalesformas = 0, 0, sumacancelacionestotalesformas)
                My.Application.DoEvents()
                txtDevoefectivo.Text = FormatNumber(sumadevolucionesEFEC, 2)
                txtdevolucionesformas.Text = FormatNumber(sumadevolucionesTOTALESFORMAS, 2)
                My.Application.DoEvents()


                txtIngresos.Text = FormatNumber(CDec(txtEfectivo.Text) + CDec(txttotalformas.Text), 2)
                txtEgresos.Text = FormatNumber(CDec(txtCancelaefectivo.Text) + CDec(txtDevoefectivo.Text) + CDec(otrosgastos) + CDec(IIf(txtcancelacionestotales.Text = 0, 0,
                txtcancelacionestotales.Text)) + CDec(txtdevolucionesformas.Text), 2)
                My.Application.DoEvents()
                txtTotalAbono.Text = FormatNumber(CDec(txtIngresos.Text) - CDec(txtEgresos.Text) - CDec(txtCompras.Text), 2)
                My.Application.DoEvents()

                txtOtrosgastos.Text = FormatNumber(otrosgastos, 2)
                My.Application.DoEvents()
                txtEfeCaja.Text = FormatNumber(CDec(txtEfectivo.Text) - CDec(txtCancelaefectivo.Text) - CDec(txtDevoefectivo.Text) - CDec(txtOtrosgastos.Text) - efecompras, 2)
                My.Application.DoEvents()
            End If


        End If
    End Sub
    Private Sub optAbonoEfectivo_CheckedChanged(sender As Object, e As EventArgs) Handles optAbonoEfectivo.CheckedChanged
        If optAbonoEfectivo.Checked = True Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 6
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Efectivo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optCargosEfectivo_CheckedChanged(sender As Object, e As EventArgs) Handles optCargosEfectivo.CheckedChanged
        If optCargosEfectivo.Checked = True Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 6
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Efectivo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optAbonosTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles optAbonosTarjeta.CheckedChanged
        If optAbonosTarjeta.Checked = True Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 7
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Monto"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Comentario"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optEgresosTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles optEgresosTarjeta.CheckedChanged
        If optEgresosTarjeta.Checked = True Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 6
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Monto"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optAbonosTransferencia_CheckedChanged(sender As Object, e As EventArgs) Handles optAbonosTransferencia.CheckedChanged
        If optAbonosTransferencia.Checked = True Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 7
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
            txtEgresos.Text = "0.00"
            txtTotalAbono.Text = "0.00"
            txtEfeCaja.Text = "0.00"
            txtSalTarj.Text = "0.00"
            txttotalformas.Text = "0.00"
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Transferencia"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Comentario"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optEgresosTransferencia_CheckedChanged(sender As Object, e As EventArgs) Handles optEgresosTransferencia.CheckedChanged
        If optEgresosTransferencia.Checked = True Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 6
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
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .Width = 250
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Efectivo"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
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

        Dim devolucionesEFEC As Double = 0
        Dim sumadevolucionesEFEC As Double = 0
        Dim sumadevolucionesTOTALESEFEC As Double = 0

        Dim devolucionesFORMAS As Double = 0
        Dim sumadevolucionesFORMAS As Double = 0
        Dim sumadevolucionesTOTALESFORMAS As Double = 0


        If optVendedor.Checked = True Then

            grdpagos.Rows.Clear()
            grdcaptura.Rows.Clear()
            grdCanceñlaciones.Rows.Clear()
            grddevoluciones.Rows.Clear()


            cnn1.Close()
            cnn1.Open()


            cmd1 = cnn1.CreateCommand
            If ComboBox1.Text = "" Then
                cmd1.CommandText = "Select Monto,NumFolio,Cliente,Concepto,Fecha,FormaPago,Comentario,Usuario from Abonoi  where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and Concepto<>'NOTA VENTA' order by Id"
            Else
                cmd1.CommandText = "Select Monto,NumFolio,Cliente,Concepto,Fecha,FormaPago,Comentario,Usuario from Abonoi  where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto<>'NOTA VENTA' order by Id"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                VarEfectivo = rd1("Monto")

                grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), rd1("FormaPago").ToString, FormatNumber(VarEfectivo, 2), rd1("Comentario").ToString, rd1("Usuario").ToString)
                My.Application.DoEvents()
            Loop
            rd1.Close()
            cnn1.Close()

            Dim CONCEPTOABONO As String = ""


            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cmd1 = cnn1.CreateCommand

            If ComboBox1.Text = "" Then
                cmd1.CommandText = "SELECT DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario<>'' AND Concepto='ABONO'"
            Else
                cmd1.CommandText = "SELECT DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario='" & ComboBox1.Text & "' AND Concepto='ABONO'"
            End If


            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    formapago = rd1(0).ToString

                    If formapago = "EFECTIVO" Then

                        cmd2 = cnn2.CreateCommand

                        If ComboBox1.Text = "" Then
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario<>'' AND Concepto='ABONO' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        Else
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='ABONO' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        End If


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

                        If ComboBox1.Text = "" Then
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario<>'' AND Concepto='ABONO' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        Else
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='ABONO' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        End If


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
            If ComboBox1.Text = "" Then
                cmd1.CommandText = "Select DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario<>'' AND Concepto='NOTA CANCELADA'"
            Else
                cmd1.CommandText = "Select DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario='" & ComboBox1.Text & "' AND Concepto='NOTA CANCELADA'"
            End If


            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    formapago = rd1(0).ToString

                    If formapago = "EFECTIVO" Then

                        cmd2 = cnn2.CreateCommand

                        If ComboBox1.Text = "" Then
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario<>'' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        Else
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        End If

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

                        If ComboBox1.Text = "" Then
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario<>'' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        Else
                            cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        End If

                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                sumacancelacionesformas = rd2(0).ToString
                                grdCanceñlaciones.Rows.Add(formapago, sumacancelacionesformas)
                                sumacancelacionestotalesformas = sumacancelacionestotalesformas + CDbl(sumacancelacionesformas)
                            End If
                        End If
                        rd2.Close()

                    End If

                End If
            Loop
            rd1.Close()


            ''''''''''''''''''''''''''''''''

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select DISTINCT(formaPago) FROM Abonoi WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND Usuario='" & ComboBox1.Text & "' And Concepto ='DEVOLUCION'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    formapago = rd1(0).ToString

                    If formapago = "EFECTIVO" Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='DEVOLUCION' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                sumadevolucionesEFEC = rd2(0).ToString
                                sumadevolucionesTOTALESEFEC = sumadevolucionesTOTALESEFEC + CDbl(sumadevolucionesEFEC)
                            End If
                        End If
                        rd2.Close()

                    Else
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Sum(Monto) FROM Abonoi WHERE FormaPago='" & formapago & "' AND FormaPago<>'EFECTIVO' AND Usuario='" & ComboBox1.Text & "' AND Concepto='NOTA CANCELADA' AND Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                sumadevolucionesFORMAS = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
                                grddevoluciones.Rows.Add(formapago, sumadevolucionesFORMAS)
                                sumadevolucionesTOTALESFORMAS = sumadevolucionesTOTALESFORMAS + CDbl(sumadevolucionesFORMAS)
                            End If
                        End If
                        rd2.Close()

                    End If
                    sumadevoluciones = sumadevolucionesTOTALESEFEC + sumadevolucionesTOTALESFORMAS
                End If
            Loop
            rd1.Close()

            rd2.Close()


            Dim otrosgastos As Double = 0
            'Otros gastos
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Monto) from OtrosGastos where Usuario<>'' and Usuario='" & ComboBox1.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    otrosgastos = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                    otrosgastos = FormatNumber(otrosgastos, 2)
                End If
            End If
            rd2.Close()


            Dim efecompras As Double = 0
            Dim trasnfecompras As Double = 0
            Dim tarjecompras As Double = 0
            Dim otrocompras As Double = 0
            Dim sumatodocomppras As Double = 0

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                      "SELECT SUM(Efectivo) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto='ABONO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    efecompras = CDec(efecompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                      "SELECT SUM(Tarjeta) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto='ABONO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    tarjecompras = CDec(tarjecompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                      "SELECT SUM(Transfe) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto='ABONO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    trasnfecompras = CDec(trasnfecompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                      "SELECT SUM(Otro) FROM AbonoE WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto='ABONO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    otrocompras = CDec(otrocompras) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()
            sumatodocomppras = efecompras + tarjecompras + trasnfecompras + otrocompras


            txtCompras.Text = FormatNumber(sumatodocomppras, 2)

            cnn2.Close()
            cnn1.Close()


            'txtEfectivo.Text = FormatNumber(SUMATOTALEFECTIVO, 2)
            'txtEfeCaja.Text = FormatNumber(CDec(txtEfectivo.Text) - CDec(txtCancelaefectivo.Text) - CDec(txtDevoefectivo.Text), 2)

            'txttotalformas.Text = FormatNumber(sumatotalformas, 2)
            'txtSalTarj.Text = FormatNumber(CDec(txttotalformas.Text) - CDec(txtcancelacionestotales.Text), 2)



            'txtCancelaefectivo.Text = FormatNumber(sumacancelacionestotalesEFEC, 2)
            'txtcancelacionestotales.Text = IIf(sumacancelacionestotalesformas = 0, 0, sumacancelacionestotalesformas)

            'txtDevoefectivo.Text = FormatNumber(sumadevoluciones, 2)
            'txtdevolucionesformas.Text = FormatNumber(sumadevoluciones, 2)



            'txtIngresos.Text = FormatNumber(CDec(txtEfectivo.Text) + CDec(txttotalformas.Text), 2)
            'txtEgresos.Text = FormatNumber(CDec(txtCancelaefectivo.Text) + CDec(txtDevoefectivo.Text) + CDec(IIf(txtcancelacionestotales.Text = 0, 0,
            'txtcancelacionestotales.Text)) + CDec(txtdevolucionesformas.Text), 2)

            'txtTotalAbono.Text = FormatNumber(CDec(txtIngresos.Text) - CDec(txtEgresos.Text), 2)

            txtEfectivo.Text = FormatNumber(SUMATOTALEFECTIVO, 2)

            My.Application.DoEvents()
            txttotalformas.Text = FormatNumber(sumatotalformas, 2)
            txtSalTarj.Text = FormatNumber(CDec(txttotalformas.Text) - CDec(txtcancelacionestotales.Text), 2)

            My.Application.DoEvents()

            txtCancelaefectivo.Text = FormatNumber(sumacancelacionestotalesEFEC, 2)
            txtcancelacionestotales.Text = IIf(sumacancelacionestotalesformas = 0, 0, sumacancelacionestotalesformas)
            My.Application.DoEvents()
            txtDevoefectivo.Text = FormatNumber(sumadevolucionesTOTALESEFEC, 2)
            txtdevolucionesformas.Text = FormatNumber(sumadevolucionesTOTALESFORMAS, 2)
            My.Application.DoEvents()


            txtIngresos.Text = FormatNumber(CDec(txtEfectivo.Text) + CDec(txttotalformas.Text), 2)
            txtEgresos.Text = FormatNumber(CDec(txtCancelaefectivo.Text) + CDec(txtDevoefectivo.Text) + CDec(otrosgastos) + CDec(IIf(txtcancelacionestotales.Text = 0, 0,
            txtcancelacionestotales.Text)) + CDec(txtdevolucionesformas.Text), 2)
            My.Application.DoEvents()
            txtTotalAbono.Text = FormatNumber(CDec(txtIngresos.Text) - CDec(txtEgresos.Text) - CDec(txtCompras.Text), 2)
            My.Application.DoEvents()

            txtOtrosgastos.Text = FormatNumber(otrosgastos, 2)
            My.Application.DoEvents()
            txtEfeCaja.Text = FormatNumber(CDec(txtEfectivo.Text) - CDec(txtCancelaefectivo.Text) - CDec(txtDevoefectivo.Text) - CDec(txtOtrosgastos.Text) - efecompras, 2)
            My.Application.DoEvents()

        End If



        If optAbonoEfectivo.Checked = True Then

            grdpagos.Rows.Clear()
            grdcaptura.Rows.Clear()
            grdCanceñlaciones.Rows.Clear()
            grddevoluciones.Rows.Clear()
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText = "Select Efectivo,NumFolio,Cliente,Concepto,Fecha,Usuario from Abonoi where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and Concepto='ABONO' and Efectivo<>'0' order by Id"
                Else
                    cmd1.CommandText = "Select Efectivo,NumFolio,Cliente,Concepto,Fecha,Usuario from Abonoi where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto='ABONO' and Efectivo<>'0' order by Id"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    VarEfectivo = rd1("Efectivo").ToString

                    grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), VarEfectivo, rd1("Usuario").ToString)
                    If rd1("Concepto").ToString = "ABONO" Then
                        Efectivo = CDec(Efectivo) + CDec(VarEfectivo)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                txtEfectivo.Text = FormatNumber(CDec(Efectivo), 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If optCargosEfectivo.Checked = True Then

            Dim formaspago As String = ""

            grdCanceñlaciones.Rows.Clear()
            grdcaptura.Rows.Clear()
            grddevoluciones.Rows.Clear()
            grdpagos.Rows.Clear()


            Try
                cnn1.Close()
                cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText = "Select Efectivo,NumFolio,Cliente,Concepto,Fecha,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and Concepto <>'ABONO' and Concepto<>'NOTA VENTA' order by Id"
                Else
                    cmd1.CommandText = "Select Efectivo,NumFolio,Cliente,Concepto,Fecha,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and usuario='" & ComboBox1.Text & "' and Concepto<>'ABONO' and Concepto<>'NOTA VENTA' order by Id"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read


                    VarEfectivo = rd1("Efectivo").ToString
                    grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), VarEfectivo, rd1("Usuario").ToString)
                    If rd1("Concepto").ToString = "DEVOLUCION" Then
                        DevoEfe = CDec(DevoEfe) + CDec(rd1("Efectivo").ToString)
                    ElseIf rd1("Concepto").ToString = "NOTA CANCELADA" Then
                        CancelaEfe = CDec(CancelaEfe) + CDec(rd1("Efectivo").ToString)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                txtCancelaefectivo.Text = FormatNumber(CancelaEfe, 2)
                txtDevoefectivo.Text = FormatNumber(DevoEfe, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If optAbonosTarjeta.Checked = True Then

            grdCanceñlaciones.Rows.Clear()
            grdcaptura.Rows.Clear()
            grddevoluciones.Rows.Clear()
            grdpagos.Rows.Clear()

            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText = "Select FormaMonto,NumFolio,Cliente,Concepto,Fecha,Comentario,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and Concepto='ABONO' and FormaPago='" & cboFormaPago.Text & "' order by Id"
                Else
                    cmd1.CommandText = "Select FormaMonto,NumFolio,Cliente,Concepto,Fecha,Comentario,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto='ABONO' and FormaPago='" & cboFormaPago.Text & "' order by Id"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read


                    Tarjetas = rd1("FormaMonto").ToString
                    grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), Tarjetas, rd1("Comentario").ToString, rd1("Usuario").ToString)

                    If rd1("Concepto").ToString = "ABONO" Then
                        txttotalformas.Text = CDec(txttotalformas.Text) + CDec(Tarjetas)
                    End If

                Loop
                rd1.Close()
                cnn1.Close()
                txttotalformas.Text = FormatNumber(txttotalformas.Text, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If optEgresosTarjeta.Checked = True Then

            grdpagos.Rows.Clear()
            grddevoluciones.Rows.Clear()
            grdcaptura.Rows.Clear()
            grdCanceñlaciones.Rows.Clear()


            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText = "Select FormaMonto,NumFolio,Cliente,Concepto,Fecha,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and Concepto='NOTA CANCELADA' and FormaPago='" & cboFormaPago.Text & "' order by Id"
                Else
                    cmd1.CommandText = "Select FormaMonto,NumFolio,Cliente,Concepto,Fecha,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Concepto='NOTA CANCELADA' and FormaPago='" & cboFormaPago.Text & "' order by Id"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    CancelaTarj = CDec(rd1("FormaMonto").ToString)
                    grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), CancelaTarj, rd1("Usuario").ToString)

                    If rd1("Concepto").ToString = "NOTA CANCELADA" Then
                        txtcancelacionestotales.Text = CDec(txtcancelacionestotales.Text) + CDec(CancelaTarj)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                txtcancelacionestotales.Text = FormatNumber(txtcancelacionestotales.Text, 2)
                If grdcaptura.Rows.Count = 0 Then
                    MsgBox("No se realizaron Cancelaciones de Tarjetas", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If optAbonosTransferencia.Checked = True Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText = "Select Transfe,NumFolio,Cliente,Concepto,Fecha,Comentario,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and FormaPago='" & cboFormaPago.Text & "' order by Id"
                Else
                    cmd1.CommandText = "Select Transfe,NumFolio,Cliente,Concepto,Fecha,Comentario,Usuario from Abono where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and FormaPago='" & cboFormaPago.Text & "' order by Id"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Transfe = rd1("Transfe").ToString
                    grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto"), FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), Transfe, rd1("Comentario").ToString, rd1("Usuario").ToString)
                    If rd1("Concepto").ToString = "ABONO" Then
                        txtdevolucionesformas.Text = CDec(txtdevolucionesformas.Text) + CDec(Transfe)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                txtdevolucionesformas.Text = FormatNumber(txtdevolucionesformas.Text, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If optEgresosTransferencia.Checked = True Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText = "Select Transfe,NumFolio,Cliente,Concepto,Fecha,Usuario from AbonoI where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario<>'' and Transfe<>'0' order By Id"
                Else
                    cmd1.CommandText = "Select Transfe,NumFolio,Cliente,Concepto,Fecha,Usuario from AbonoI where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Usuario='" & ComboBox1.Text & "' and Transfe<>'0' order by Id"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    DevoTransf = rd1("Transfe").ToString
                    grdcaptura.Rows.Add(rd1("NumFolio").ToString, rd1("Cliente").ToString, rd1("Concepto").ToString, FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), DevoTransf, rd1("Usuario").ToString)
                    If rd1("Concepto").ToString = "NOTA CANCELADA" Then
                        '  txtCancelacionTrans.Text = CDec(txtCancelacionTrans.Text) + CDec(DevoTransf)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                ' txtCancelacionTrans.Text = FormatNumber(txtCancelacionTrans.Text, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarDataGridViewAExcel(grdcaptura)

        'If grdcaptura.Rows.Count = 0 Then
        '    MsgBox("No hay Información para exportar", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '    Exit Sub
        'End If
        'If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
        '    btnExportar.Enabled = False
        '    Dim exApp As New Excel.Application
        '    Dim exBook As Excel.Workbook
        '    Dim exSheet As Excel.Worksheet

        '    Try
        '        exBook = exApp.Workbooks.Add
        '        exSheet = exBook.Worksheets.Application.ActiveSheet

        '        exSheet.Columns("A").NumberFormat = "@"
        '        exSheet.Columns("B").NumberFormat = "@"
        '        exSheet.Columns("D").NumberFormat = "@"

        '        Dim NCol As Integer = grdcaptura.ColumnCount
        '        Dim NRow As Integer = grdcaptura.RowCount

        '        For i As Integer = 1 To NCol
        '            exSheet.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
        '        Next

        '        For Fila As Integer = 0 To NRow - 1
        '            For Col As Integer = 0 To NCol - 1
        '                exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value
        '            Next
        '            My.Application.DoEvents()
        '        Next

        '        exSheet.Rows.Item(1).Font.Bold = 1
        '        exSheet.Rows.Item(1).HorizontalAlignment = 3
        '        exSheet.Columns.AutoFit()

        '        MsgBox("Datos exportados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '        exApp.Application.Visible = True
        '        exSheet = Nothing
        '        exBook = Nothing
        '        exApp = Nothing
        '        btnExportar.Enabled = True

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '    End Try
        'End If
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grdcaptura.Rows.Clear()
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
        txtOtrosgastos.Text = "0.00"
        txtCompras.Text = "0.00"

        grdCanceñlaciones.Rows.Clear()
        grdpagos.Rows.Clear()
        grddevoluciones.Rows.Clear()
    End Sub

    Private Sub cboFormaPago_DropDown(sender As Object, e As EventArgs) Handles cboFormaPago.DropDown
        Try
            cboFormaPago.Items.Clear()

            If (optAbonosTarjeta.Checked) Or (optEgresosTarjeta.Checked) Or (optAbonosTransferencia.Checked) Then

                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText = "SELECT DISTINCT FormaPago FROM Abono WHERE FormaPago<>'' ORDER BY FormaPago"
                rd5 = cmd5.ExecuteReader
                Do While rd5.Read
                    If rd5.HasRows Then
                        cboFormaPago.Items.Add(rd5(0).ToString)
                    End If
                Loop
                rd5.Close()
                cnn5.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub


End Class