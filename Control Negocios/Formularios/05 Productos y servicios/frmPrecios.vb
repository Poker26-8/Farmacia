Public Class frmPrecios

    Dim CUATROD As String
    Dim A1 As Byte
    Dim A2 As Byte
    Dim A3 As Byte
    Dim A4 As Byte
    Dim A5 As Byte
    Dim B1 As Byte
    Dim B2 As Byte
    Dim B3 As Byte
    Dim B4 As Byte
    Dim B5 As Byte
    Dim Cambio As Byte
    Dim Cambio1 As Byte
    Dim Cambio2 As Byte
    Dim Cambio3 As Byte
    Dim Prom As Integer
    Dim alias_precios As String = ""

    Private Sub BtnPrecios_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrecios.Click
        frmCambioPrecio.Show()
    End Sub

    REM Hacer local este proceso
    Private Sub C1(ByVal index As Byte)
        Try
            Select Case index
                Case 1
                    If (TxtUtiM.Text = "" Or TxtUtiM.Text = "." Or Trim(TxtUtiM.Text) = "" Or TxtUtiM.Text = "0" Or CDec(TxtUtiM.Text) = 0) Then TxtPMI.Text = "0.00" : Exit Sub
                    TxtPMI.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtUtiM.Text = "", "0", TxtUtiM.Text)) / 100) + 1)
                    TxtPMI.Text = FormatNumber(TxtPMI.Text, 4)
                    A1 = 0

                    If (TxtUtiM2.Text = "" Or TxtUtiM2.Text = "." Or Trim(TxtUtiM2.Text) = "" Or TxtUtiM2.Text = "0" Or CDec(TxtUtiM2.Text) = 0) Then TxtPMI2.Text = "0.00" : Exit Sub
                    TxtPMI2.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtUtiM2.Text = "", "0", TxtUtiM2.Text)) / 100) + 1)
                    TxtPMI2.Text = FormatNumber(TxtPMI2.Text, 4)
                    A1 = 0

                Case 2
                    If (TxtPorMay.Text = "" Or TxtPorMay.Text = "." Or Trim(TxtPorMay.Text) = "" Or TxtPorMay.Text = "0" Or CDec(TxtPorMay.Text) = 0) Then TxtPreMay.Text = "0.00" : Exit Sub
                    TxtPreMay.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorMay.Text = "", "0", TxtPorMay.Text)) / 100) + 1)
                    TxtPreMay.Text = FormatNumber(TxtPreMay.Text, 4)
                    A2 = 0

                    If (TxtPorMay2.Text = "" Or TxtPorMay2.Text = "." Or Trim(TxtPorMay2.Text) = "" Or TxtPorMay2.Text = "0" Or CDec(TxtPorMay2.Text) = 0) Then TxtPreMay2.Text = "0.00" : Exit Sub
                    TxtPreMay2.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorMay2.Text = "", "0", TxtPorMay2.Text)) / 100) + 1)
                    TxtPreMay2.Text = FormatNumber(TxtPreMay2.Text, 4)
                    A2 = 0

                Case 3
                    If (TxtPorMM.Text = "" Or TxtPorMM.Text = "." Or Trim(TxtPorMM.Text) = "" Or TxtPorMM.Text = "0" Or CDec(TxtPorMM.Text) = 0) Then TxtPreMM.Text = "0.00" : Exit Sub
                    TxtPreMM.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorMM.Text = "", "0", TxtPorMM.Text)) / 100) + 1)
                    TxtPreMM.Text = FormatNumber(TxtPreMM.Text, 4)
                    A3 = 0

                    If (TxtPorMM2.Text = "" Or TxtPorMM2.Text = "." Or Trim(TxtPorMM2.Text) = "" Or TxtPorMM2.Text = "0" Or CDec(TxtPorMM2.Text) = 0) Then TxtPreMM2.Text = "0.00" : Exit Sub
                    TxtPreMM2.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorMM2.Text = "", "0", TxtPorMM2.Text)) / 100) + 1)
                    TxtPreMM2.Text = FormatNumber(TxtPreMM2.Text, 4)
                    A3 = 0

                Case 4
                    If (TxtPorEsp.Text = "" Or TxtPorEsp.Text = "." Or Trim(TxtPorEsp.Text) = "" Or TxtPorEsp.Text = "0" Or CDec(TxtPorEsp.Text) = 0) Then TxtPreEsp.Text = "0.00" : Exit Sub
                    TxtPreEsp.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorEsp.Text = "", "0", TxtPorEsp.Text)) / 100) + 1)
                    TxtPreEsp.Text = FormatNumber(TxtPreEsp.Text, 4)
                    A4 = 0

                    If (TxtPorEsp2.Text = "" Or TxtPorEsp2.Text = "." Or Trim(TxtPorEsp2.Text) = "" Or TxtPorEsp2.Text = "0" Or CDec(TxtPorEsp2.Text) = 0) Then TxtPreEsp2.Text = "0.00" : Exit Sub
                    TxtPreEsp2.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorEsp2.Text = "", "0", TxtPorEsp2.Text)) / 100) + 1)
                    TxtPreEsp2.Text = FormatNumber(TxtPreEsp2.Text, 4)
                    A4 = 0

                Case 5
                    If (TxtPorLta.Text = "" Or TxtPorLta.Text = "." Or Trim(TxtPorLta.Text) = "" Or TxtPorLta.Text = "0" Or CDec(TxtPorLta.Text) = 0) Then TxtPreLta.Text = "0.00" : Exit Sub
                    TxtPreLta.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorLta.Text = "", "0", TxtPorLta.Text)) / 100) + 1)
                    TxtPreLta.Text = FormatNumber(TxtPreLta.Text, 4)
                    A5 = 0

                    If (TxtPorLta2.Text = "" Or TxtPorLta2.Text = "." Or Trim(TxtPorLta2.Text) = "" Or TxtPorLta2.Text = "0" Or CDec(TxtPorLta2.Text) = 0) Then TxtPreLta2.Text = "0.00" : Exit Sub
                    TxtPreLta2.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * ((CDec(IIf(TxtPorLta2.Text = "", "0", TxtPorLta2.Text)) / 100) + 1)
                    TxtPreLta2.Text = FormatNumber(TxtPreLta2.Text, 4)
                    A5 = 0
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    REM Hacer local este proceso
    Private Sub T1(ByVal ind As Byte)
        Try
            Select Case ind
                Case 1
                    If (TxtPMI.Text = "" Or TxtPMI.Text = "." Or Trim(TxtPMI.Text) = "" Or TxtPMI.Text = "0" Or CDec(TxtPMI.Text) = 0) Then TxtUtiM.Text = "0" : Exit Sub
                    If TxtPMI.Text = "" Or TxtPMI.Text = "." Or TxtPMI.Text = "0.00" Or CDec(TxtPMI.Text) = 0 Then
                        TxtPMI.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtUtiM.Text = ((CDec(IIf(TxtPMI.Text = "", "0", TxtPMI.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtUtiM.Text = FormatNumber(TxtUtiM.Text, 2)
                        End If
                    End If
                    B1 = 0

                    If (TxtPMI2.Text = "" Or TxtPMI2.Text = "." Or Trim(TxtPMI2.Text) = "" Or TxtPMI2.Text = "0" Or CDec(TxtPMI2.Text) = 0) Then TxtUtiM2.Text = "0" : Exit Sub
                    If TxtPMI2.Text = "" Or TxtPMI2.Text = "." Or TxtPMI2.Text = "0.00" Or CDec(TxtPMI2.Text) = 0 Then
                        TxtPMI2.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtUtiM2.Text = ((CDec(IIf(TxtPMI2.Text = "", "0", TxtPMI2.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtUtiM2.Text = FormatNumber(TxtUtiM2.Text, 2)
                        End If
                    End If
                    B1 = 0

                Case 2
                    If (TxtPreMay.Text = "" Or TxtPreMay.Text = "." Or Trim(TxtPreMay.Text) = "" Or TxtPreMay.Text = "0" Or CDec(TxtPreMay.Text) = 0) Then TxtPorMay.Text = "0" : Exit Sub
                    If TxtPreMay.Text = "" Or TxtPreMay.Text = "." Or TxtPreMay.Text = "0.00" Or CDec(TxtPreMay.Text) = 0 Then
                        TxtPreMay.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorMay.Text = ((CDec(IIf(TxtPreMay.Text = "", "0", TxtPreMay.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorMay.Text = FormatNumber(TxtPorMay.Text, 2)
                        End If
                    End If
                    B2 = 0

                    If (TxtPreMay2.Text = "" Or TxtPreMay2.Text = "." Or Trim(TxtPreMay2.Text) = "" Or TxtPreMay2.Text = "0" Or CDec(TxtPreMay2.Text) = 0) Then TxtPorMay2.Text = "0" : Exit Sub
                    If TxtPreMay2.Text = "" Or TxtPreMay2.Text = "." Or TxtPreMay2.Text = "0.00" Or CDec(TxtPreMay2.Text) = 0 Then
                        TxtPreMay2.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorMay2.Text = ((CDec(IIf(TxtPreMay2.Text = "", "0", TxtPreMay2.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorMay2.Text = FormatNumber(TxtPorMay2.Text, 2)
                        End If
                    End If
                    B2 = 0

                Case 3
                    If (TxtPreMM.Text = "" Or TxtPreMM.Text = "." Or Trim(TxtPreMM.Text) = "" Or TxtPreMM.Text = "0" Or CDec(TxtPreMM.Text) = 0) Then TxtPorMM.Text = "0" : Exit Sub
                    If TxtPreMM.Text = "" Or TxtPreMM.Text = "." Or TxtPreMM.Text = "0.00" Or CDec(TxtPreMM.Text) = 0 Then
                        TxtPreMM.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorMM.Text = ((CDec(IIf(TxtPreMM.Text = "", "0", TxtPreMM.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorMM.Text = FormatNumber(TxtPorMM.Text, 2)
                        End If
                    End If
                    B3 = 0

                    If (TxtPreMM2.Text = "" Or TxtPreMM2.Text = "." Or Trim(TxtPreMM2.Text) = "" Or TxtPreMM2.Text = "0" Or CDec(TxtPreMM2.Text) = 0) Then TxtPorMM2.Text = "0" : Exit Sub
                    If TxtPreMM2.Text = "" Or TxtPreMM2.Text = "." Or TxtPreMM2.Text = "0.00" Or CDec(TxtPreMM2.Text) = 0 Then
                        TxtPreMM2.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorMM2.Text = ((CDec(IIf(TxtPreMM2.Text = "", "0", TxtPreMM2.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorMM2.Text = FormatNumber(TxtPorMM2.Text, 2)
                        End If
                    End If
                    B3 = 0

                Case 4
                    If (TxtPreEsp.Text = "" Or TxtPreEsp.Text = "." Or Trim(TxtPreEsp.Text) = "" Or TxtPreEsp.Text = "0" Or CDec(TxtPreEsp.Text) = 0) Then TxtPorEsp.Text = "0" : Exit Sub
                    If TxtPreEsp.Text = "" Or TxtPreEsp.Text = "." Or TxtPreEsp.Text = "0.00" Or CDec(TxtPreEsp.Text) = 0 Then
                        TxtPreEsp.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorEsp.Text = ((CDec(IIf(TxtPreEsp.Text = "", "0", TxtPreEsp.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorEsp.Text = FormatNumber(TxtPorEsp.Text, 2)
                        End If
                    End If
                    B4 = 0

                    If (TxtPreEsp2.Text = "" Or TxtPreEsp2.Text = "." Or Trim(TxtPreEsp2.Text) = "" Or TxtPreEsp2.Text = "0" Or CDec(TxtPreEsp2.Text) = 0) Then TxtPorEsp2.Text = "0" : Exit Sub
                    If TxtPreEsp2.Text = "" Or TxtPreEsp2.Text = "." Or TxtPreEsp2.Text = "0.00" Or CDec(TxtPreEsp2.Text) = 0 Then
                        TxtPreEsp2.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorEsp2.Text = ((CDec(IIf(TxtPreEsp2.Text = "", "0", TxtPreEsp2.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorEsp2.Text = FormatNumber(TxtPorEsp2.Text, 2)
                        End If
                    End If
                    B4 = 0

                Case 5
                    If (TxtPreLta.Text = "" Or TxtPreLta.Text = "." Or Trim(TxtPreLta.Text) = "" Or TxtPreLta.Text = "0" Or CDec(TxtPreLta.Text) = 0) Then TxtPorLta.Text = "0" : Exit Sub
                    If TxtPreLta.Text = "" Or TxtPreLta.Text = "." Or TxtPreLta.Text = "0.00" Or CDec(TxtPreLta.Text) = 0 Then
                        TxtPreLta.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorLta.Text = ((CDec(IIf(TxtPreLta.Text = "", "0", TxtPreLta.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorLta.Text = FormatNumber(TxtPorLta.Text, 2)
                        End If
                    End If
                    B5 = 0

                    If (TxtPreLta2.Text = "" Or TxtPreLta2.Text = "." Or Trim(TxtPreLta2.Text) = "" Or TxtPreLta2.Text = "0" Or CDec(TxtPreLta2.Text) = 0) Then TxtPorLta2.Text = "0" : Exit Sub
                    If TxtPreLta2.Text = "" Or TxtPreLta2.Text = "." Or TxtPreLta2.Text = "0.00" Or CDec(TxtPreLta2.Text) = 0 Then
                        TxtPreLta2.Text = "0.00"
                    Else
                        If CboDescripcion.Text <> "" And cboCodigo.Text <> "" Then
                            TxtPorLta2.Text = ((CDec(IIf(TxtPreLta2.Text = "", "0", TxtPreLta2.Text)) / CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text))) - 1) * 100
                            TxtPorLta2.Text = FormatNumber(TxtPorLta2.Text, 2)
                        End If
                    End If
                    B5 = 0


            End Select
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub frmPrecios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFechaI.Value = Now
        dtpFechaF.Value = Now
    End Sub

    Private Sub CodBar()

        Try
            If CboDescripcion.Text = "" And cboCodigo.Text = "" Then
                Exit Sub
            Else
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                If Len(cboCodigo.Text) > 0 Then
                    cmd1.CommandText =
                        "select Nombre,Codigo from Productos where Codigo='" & cboCodigo.Text & "'"
                End If
                If Len(CboDescripcion.Text) > 0 Then
                    cmd1.CommandText =
                        "select Nombre,Codigo from Productos where CodBarra='" & CboDescripcion.Text & "'"
                End If
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        CboDescripcion.Text = rd1("Nombre").ToString()
                        cboCodigo.Text = rd1("Codigo").ToString()
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Nombre,Codigo from Productos where N_Serie='" & CboDescripcion.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            CboDescripcion.Text = rd2("Nombre").ToString()
                            cboCodigo.Text = rd2("Codigo").ToString()
                        End If
                    End If
                    rd2.Close() : cnn2.Close()
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Codigo,UVenta,PrecioCompra,IVA,PorcMin,PorcMay,PorcMM,PorcEsp,Porcentaje,PreMin,PreMay,PreMM,PreEsp,PrecioVentaIVA,Status_Promocion,Porcentaje_Promo,CantMin1,CantMay1,CantMM1,CantEsp1,CantLst1,CantMin2,CantMay2,CantMM2,CantEsp2,CantLst2,Promo_Monedero,pres_vol from Productos where Nombre='" & CboDescripcion.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cboCodigo.Text = rd1("Codigo").ToString()

                        cnn2.Close() : cnn2.Open()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select tm.id,tm.nombre_moneda,tm.tipo_cambio from tb_moneda tm,Productos p where Codigo='" & cboCodigo.Text & "' and p.id_tbMoneda=tm.id"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                LblMoneda.Tag = rd2("id").ToString()
                                LblMoneda.Text = rd2("nombre_moneda").ToString()
                                LblValor.Text = FormatNumber(rd2("tipo_cambio").ToString(), 2)
                            End If
                        End If
                        rd2.Close() : cnn2.Close()

                        'CboDescripcion.Text = rd1("Nombre").ToString()
                        'cboCodigo.Text = rd1("Codigo").ToString()
                        TxtUnidad.Text = rd1("UVenta").ToString()
                        TxtPC.Text = FormatNumber(rd1("PrecioCompra").ToString() * LblValor.Text, 2)
                        TxtMonedaSIVA.Text = FormatNumber(rd1("PrecioCompra").ToString(), 2)
                        TxtPCI.Text = FormatNumber(IIf(CDec(TxtPC.Text) = 0, 0, TxtPC.Text) * (rd1("IVA").ToString() + 1), 2)
                        TxtMonedaSIVA.Text = FormatNumber(CDec(TxtPC.Text) / CDec(IIf(LblValor.Text = "0.00", "1", LblValor.Text)), 2)
                        TxtMonedaIva.Text = FormatNumber(CDec(TxtPCI.Text) / CDec(IIf(LblValor.Text = "0.00", "1", LblValor.Text)), 2)

                        TxtUtiM.Text = IIf(rd1("PorcMin").ToString = "", "0", FormatNumber(rd1("PorcMin").ToString, 2))
                        TxtPorMay.Text = IIf(rd1("PorcMay").ToString = "", "0", FormatNumber(rd1("PorcMay").ToString, 2))
                        TxtPorMM.Text = IIf(rd1("PorcMM").ToString = "", "0", FormatNumber(rd1("PorcMM").ToString, 2))
                        TxtPorEsp.Text = IIf(rd1("PorcEsp").ToString = "", "0", FormatNumber(rd1("PorcEsp").ToString, 2))
                        TxtPorLta.Text = IIf(rd1("Porcentaje").ToString = "", "0", FormatNumber(rd1("Porcentaje").ToString, 2))
                        TxtPMI.Text = IIf(rd1("PreMin").ToString = "", "0.00", FormatNumber(rd1("PreMin").ToString, 2))
                        TxtPreMay.Text = IIf(rd1("PreMay").ToString = "", "0.00", FormatNumber(rd1("PreMay").ToString, 2))
                        TxtPreMM.Text = IIf(rd1("PreMM").ToString = "", "0.00", FormatNumber(rd1("PreMM").ToString, 2))
                        TxtPreEsp.Text = IIf(rd1("PreEsp").ToString = "", "0.00", FormatNumber(rd1("PreEsp").ToString, 2))

                        If CDec(rd1("PrecioVentaIVA").ToString) > 0 Then
                            TxtPreLta.Text = CDec(rd1("PrecioVentaIVA").ToString) * CDec(LblValor.Text)
                            TxtMonedaIva.Text = FormatNumber(CDec(TxtPCI.Text) / CDec(IIf(LblValor.Text = "0.00", "1", LblValor.Text)), 2)
                        End If

                        ChkPromocion.Checked = Promos(rd1("Status_Promocion").ToString)
                        TxtPromoPercent.Text = rd1("Porcentaje_Promo").ToString
                        If TxtPromoPercent.Text = "" Then TxtPromoPercent.Text = "0"

                        TxtCantMin.Text = IIf(rd1("CantMin1").ToString = "", "0", rd1("CantMin1").ToString)
                        TxtCantMay.Text = IIf(rd1("CantMay1").ToString = "", "0", rd1("CantMay1").ToString)
                        TxtCantMM.Text = IIf(rd1("CantMM1").ToString = "", "0", rd1("CantMM1").ToString)
                        TxtCantEsp.Text = IIf(rd1("CantEsp1").ToString = "", "0", rd1("CantEsp1").ToString)
                        TxtCantLta.Text = IIf(rd1("CantLst1").ToString = "", "0", rd1("CantLst1").ToString)

                        txtCantMin2.Text = IIf(rd1("CantMin2").ToString = "", "0", rd1("CantMin2").ToString)
                        txtCantMay2.Text = IIf(rd1("CantMay2").ToString = "", "0", rd1("CantMay2").ToString)
                        TxtCantMM2.Text = IIf(rd1("CantMM2").ToString = "", "0", rd1("CantMM2").ToString)
                        TxtCantEsp2.Text = IIf(rd1("CantEsp2").ToString = "", "0", rd1("CantEsp2").ToString)
                        TxtCantLta2.Text = IIf(rd1("CantLst2").ToString = "", "0", rd1("CantLst2").ToString)
                        txtmonedero.Text = rd1("Promo_Monedero").ToString()
                        ChkTodos.Checked = rd1("pres_vol").ToString()
                        'dtpFechaI.Value = rd1("Fecha_Inicial").ToString()
                        'dtpFechaF.Value = rd1("Fecha_Final").ToString()

                        Dim activar As Integer = IIf(rd1("pres_vol").ToString() = True, 1, 0)
                        If activar = 1 Then
                            Call ActivarP()
                        Else
                            Call DesactivarP()
                        End If
                    End If
                End If
                rd1.Close() : cnn1.Close()
                If IsNumeric(CboDescripcion.Text) Then
                    CboDescripcion.Text = ""
                End If
                cnn2.Close() : cnn1.Close()
                My.Application.DoEvents()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub ActivarP()
        TxtUtiM.Enabled = True
        TxtUtiM2.Enabled = True
        TxtPMI.Enabled = True
        TxtPMI2.Enabled = True
        TxtCantMin.Enabled = True
        txtCantMin2.Enabled = True
        TxtCantMin3.Enabled = True
        txtCantMin4.Enabled = True

        TxtPorMay.Enabled = True
        TxtPorMay2.Enabled = True
        TxtPreMay.Enabled = True
        TxtPreMay2.Enabled = True
        TxtCantMay.Enabled = True
        txtCantMay2.Enabled = True
        TxtCantMay3.Enabled = True
        txtCantMay4.Enabled = True

        TxtPorMM.Enabled = True
        TxtPorMM2.Enabled = True
        TxtPreMM.Enabled = True
        TxtPreMM2.Enabled = True
        TxtCantMM.Enabled = True
        TxtCantMM2.Enabled = True
        TxtCantMM3.Enabled = True
        TxtCantMM4.Enabled = True

        TxtPorEsp.Enabled = True
        TxtPorEsp2.Enabled = True
        TxtPreEsp.Enabled = True
        TxtPreEsp2.Enabled = True
        TxtCantEsp.Enabled = True
        TxtCantEsp2.Enabled = True
        TxtCantEsp3.Enabled = True
        TxtCantEsp4.Enabled = True
    End Sub

    Private Sub DesactivarP()
        TxtUtiM.Enabled = False
        TxtUtiM2.Enabled = False
        TxtPMI.Enabled = False
        TxtPMI2.Enabled = False
        TxtCantMin.Enabled = False
        txtCantMin2.Enabled = False
        TxtCantMin3.Enabled = False
        txtCantMin4.Enabled = False

        TxtPorMay.Enabled = False
        TxtPorMay2.Enabled = False
        TxtPreMay.Enabled = False
        TxtPreMay2.Enabled = False
        TxtCantMay.Enabled = False
        txtCantMay2.Enabled = False
        TxtCantMay3.Enabled = False
        txtCantMay4.Enabled = False

        TxtPorMM.Enabled = False
        TxtPorMM2.Enabled = False
        TxtPreMM.Enabled = False
        TxtPreMM2.Enabled = False
        TxtCantMM.Enabled = False
        TxtCantMM2.Enabled = False
        TxtCantMM3.Enabled = False
        TxtCantMM4.Enabled = False

        TxtPorEsp.Enabled = False
        TxtPorEsp2.Enabled = False
        TxtPreEsp.Enabled = False
        TxtPreEsp.Enabled = False
        TxtCantEsp.Enabled = False
        TxtCantEsp2.Enabled = False
        TxtCantEsp3.Enabled = False
        TxtCantEsp4.Enabled = False
    End Sub

    Private Sub CboDescripcion_DropDown(sender As Object, e As System.EventArgs) Handles CboDescripcion.DropDown
        CboDescripcion.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Productos order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then CboDescripcion.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub CboDescripcion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboDescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            CodBar()
            cnn1.Close()
            lblTM.Text = UCase(LblMoneda.Text)
            If Len(CboDescripcion.Text) = 0 Then
                cboCodigo.Focus().Equals(True)
                Exit Sub
            Else
                Dim IVA As Double = 0
                Try
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Codigo,IVA from Productos where Nombre='" & CboDescripcion.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboCodigo.Text = rd2("Codigo").ToString()
                            IVA = rd2("IVA").ToString()
                            TxtPCI.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * (1 + IVA)
                            TxtPCI.Text = FormatNumber(TxtPCI.Text, 2)
                        End If
                    End If
                    rd2.Close() : cnn2.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                cboCodigo.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Function Promos(ByVal Bool As Boolean) As Byte
        If Bool = True Then
            dtpFechaI.Enabled = True
            dtpFechaF.Enabled = True
            TxtPromoPercent.Enabled = True
            Promos = 1
        Else
            dtpFechaI.Enabled = False
            dtpFechaF.Enabled = False
            TxtPromoPercent.Enabled = True
            Promos = 0
        End If
    End Function

    Private Sub CboDescripcion_LostFocus(sender As Object, e As System.EventArgs) Handles CboDescripcion.LostFocus
        CboDescripcion.Tag = 0
        Call cboCodigo_KeyPress(cboCodigo, New KeyPressEventArgs(ChrW(Keys.Enter)))
        CboDescripcion.Tag = ""
    End Sub

    Private Sub CboDescripcion_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CboDescripcion.SelectedValueChanged
        Dim IVA As Double = 0
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,IVA from Productos where Nombre='" & CboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboCodigo.Text = rd1("Codigo").ToString
                    IVA = rd1("IVA").ToString
                    TxtPCI.Text = CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) * (1 + IVA)
                    TxtPCI.Text = FormatNumber(TxtPCI.Text, 2)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCodigo_DropDown(sender As System.Object, e As System.EventArgs) Handles cboCodigo.DropDown
        cboCodigo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If CboDescripcion.Text <> "" Then
                cmd1.CommandText =
                    "select Codigo from Productos where Nombre='" & CboDescripcion.Text & "'"
            Else
                cmd1.CommandText =
                    "select Codigo from Productos where left(Codigo,6)='" & Strings.Left(cboCodigo.Text, 6) & "' order by Codigo"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboCodigo.Items.Add(
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

    Private Sub cboCodigo_GotFocus(sender As Object, e As System.EventArgs) Handles cboCodigo.GotFocus
        cboCodigo.SelectionStart = 0
        cboCodigo.SelectionLength = Len(cboCodigo.Text)
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If cboCodigo.Text = "" Then Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Codigo from Productos where Codigo='" & cboCodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        rd1.Close()
                        cnn1.Close()
                        find_cod()
                    End If
                Else
                    MsgBox("El producto no existe en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cboCodigo.Focus().Equals(True)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                If CboDescripcion.Text <> "" Then
                    TxtPC.Focus().Equals(True)
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub find_cod()
        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select Codigo,Status_Promocion,Porcentaje_Promo,Nombre,UVenta,PrecioCompra,PorcMin,PorcMin2,PorcMay,PorcMay2,PorcMM,PorcMM2,PorcEsp,PorcEsp2,Porcentaje,Porcentaje2,PreMin,PreMin2,PreMay,PreMay2,PreMM,PreMM2,PreEsp,PreEsp2,PrecioVentaIVA,PrecioVentaIVA2,CantMin1,CantMin2,CantMin3,CantMin4,CantMay1,CantMay2,CantMay3,CantMay4,CantMM1,CantMM2,CantMM3,CantMM4,CantEsp1,CantEsp2,CantEsp3,CantEsp4,CantLst1,CantLst2,CantLst3,CantLst4,Promo_Monedero,pres_vol,IVA from Productos where Codigo='" & cboCodigo.Text & "'"
            rd4 = cmd4.ExecuteReader
            If Not rd4.HasRows Then
                MsgBox("No existe un producto con este código.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd4.Close()
                cnn4.Close()
                cboCodigo.Focus().Equals(True)
                Exit Sub
            Else
                If rd4.Read Then
                    cboCodigo.Text = rd4("Codigo").ToString

                    cnn5.Close()
                    cnn5.Open()
                    cmd5 = cnn5.CreateCommand
                    cmd5.CommandText =
                        "select tm.id,tm.nombre_moneda,tm.tipo_cambio from tb_moneda tm,Productos p where Codigo='" & cboCodigo.Text & "' and p.id_tbMoneda=tm.id"
                    rd5 = cmd5.ExecuteReader
                    If rd5.HasRows Then
                        If rd5.Read Then
                            LblMoneda.Tag = rd5("id").ToString
                            LblMoneda.Text = rd5("nombre_moneda").ToString
                            LblValor.Text = FormatNumber(rd5("tipo_cambio").ToString, 2)
                        End If
                    End If
                    rd5.Close()
                    cnn5.Close()

                    ChkPromocion.Checked = Promos(rd4("Status_Promocion").ToString)
                    TxtPromoPercent.Text = rd4("Porcentaje_Promo").ToString
                    If TxtPromoPercent.Text = "" Then TxtPromoPercent.Text = "0"

                    CboDescripcion.Text = rd4("Nombre").ToString
                    cboCodigo.Text = rd4("Codigo").ToString
                    TxtUnidad.Text = rd4("UVenta").ToString
                    TxtPC.Text = FormatNumber(CDec(IIf(rd4("PrecioCompra").ToString = "", "0", rd4("PrecioCompra").ToString)) * CDec(LblValor.Text), 2)
                    TxtMonedaSIVA.Text = FormatNumber(CDec(IIf(rd4("PrecioCompra").ToString = "", "0", rd4("PrecioCompra").ToString)), 2)
                    TxtPCI.Text = FormatNumber(IIf(CDec(TxtPC.Text) = 0, 0, TxtPC.Text) * (rd4("IVA").ToString + 1), 2)
                    TxtMonedaSIVA.Text = FormatNumber(CDec(TxtPC.Text) / CDec(IIf(LblValor.Text = "0.00", "1", LblValor.Text)), 2)
                    TxtMonedaIva.Text = FormatNumber(CDec(TxtPCI.Text) / CDec(IIf(LblValor.Text = "0.00", "1", LblValor.Text)), 2)

                    TxtUtiM.Text = IIf(rd4("PorcMin").ToString = "", "0", FormatNumber(rd4("PorcMin").ToString, 2))
                    TxtUtiM2.Text = IIf(rd4("PorcMin2").ToString = "", "0", FormatNumber(rd4("PorcMin2").ToString, 2))

                    TxtPorMay.Text = IIf(rd4("PorcMay").ToString = "", "0", FormatNumber(rd4("PorcMay").ToString, 2))
                    TxtPorMay2.Text = IIf(rd4("PorcMay2").ToString = "", "0", FormatNumber(rd4("PorcMay2").ToString, 2))

                    TxtPorMM.Text = IIf(rd4("PorcMM").ToString = "", "0", FormatNumber(rd4("PorcMM").ToString, 2))
                    TxtPorMM2.Text = IIf(rd4("PorcMM2").ToString = "", "0", FormatNumber(rd4("PorcMM2").ToString, 2))

                    TxtPorEsp.Text = IIf(rd4("PorcEsp").ToString = "", "0", FormatNumber(rd4("PorcEsp").ToString, 2))
                    TxtPorEsp2.Text = IIf(rd4("PorcEsp2").ToString = "", "0", FormatNumber(rd4("PorcEsp2").ToString, 2))

                    TxtPorLta.Text = IIf(rd4("Porcentaje").ToString = "", "0", FormatNumber(rd4("Porcentaje").ToString, 2))
                    TxtPorLta2.Text = IIf(rd4("Porcentaje2").ToString = "", "0", FormatNumber(rd4("Porcentaje2").ToString, 2))

                    TxtPMI.Text = IIf(rd4("PreMin").ToString = "", "0.00", FormatNumber(rd4("PreMin").ToString, 2))
                    TxtPMI2.Text = IIf(rd4("PreMin2").ToString = "", "0.00", FormatNumber(rd4("PreMin2").ToString, 2))

                    TxtPreMay.Text = IIf(rd4("PreMay").ToString = "", "0.00", FormatNumber(rd4("PreMay").ToString, 2))
                    TxtPreMay2.Text = IIf(rd4("PreMay2").ToString = "", "0.00", FormatNumber(rd4("PreMay2").ToString, 2))

                    TxtPreMM.Text = IIf(rd4("PreMM").ToString = "", "0.00", FormatNumber(rd4("PreMM").ToString, 2))
                    TxtPreMM2.Text = IIf(rd4("PreMM2").ToString = "", "0.00", FormatNumber(rd4("PreMM2").ToString, 2))

                    TxtPreEsp.Text = IIf(rd4("PreEsp").ToString = "", "0.00", FormatNumber(rd4("PreEsp").ToString, 2))
                    TxtPreEsp2.Text = IIf(rd4("PreEsp2").ToString = "", "0.00", FormatNumber(rd4("PreEsp2").ToString, 2))

                    If CDec(rd4("PrecioVentaIVA").ToString) > 0 Then
                        TxtPreLta.Text = CDec(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString)) * CDec(LblValor.Text)
                        TxtPreLta2.Text = CDec(IIf(rd4("PrecioVentaIVA2").ToString = "", "0", rd4("PrecioVentaIVA2").ToString)) * CDec(LblValor.Text)
                        TxtMonedaIva.Text = FormatNumber(CDec(TxtPCI.Text) / CDec(IIf(LblValor.Text = "0.00", "1", LblValor.Text)), 2)
                    Else
                        TxtPreLta.Text = "0.00"
                        TxtPreLta2.Text = "0.00"
                    End If
                    TxtCantMin.Text = IIf(rd4("CantMin1").ToString = "", "0", rd4("CantMin1").ToString)
                    txtCantMin2.Text = IIf(rd4("CantMin2").ToString = "", "0", rd4("CantMin2").ToString)
                    TxtCantMin3.Text = IIf(rd4("CantMin3").ToString = "", "0", rd4("CantMin3").ToString)
                    txtCantMin4.Text = IIf(rd4("CantMin4").ToString = "", "0", rd4("CantMin4").ToString)

                    TxtCantMay.Text = IIf(rd4("CantMay1").ToString = "", "0", rd4("CantMay1").ToString)
                    txtCantMay2.Text = IIf(rd4("CantMay2").ToString = "", "0", rd4("CantMay2").ToString)
                    TxtCantMay3.Text = IIf(rd4("CantMay3").ToString = "", "0", rd4("CantMay3").ToString)
                    txtCantMay4.Text = IIf(rd4("CantMay4").ToString = "", "0", rd4("CantMay4").ToString)

                    TxtCantMM.Text = IIf(rd4("CantMM1").ToString = "", "0", rd4("CantMM1").ToString)
                    TxtCantMM2.Text = IIf(rd4("CantMM2").ToString = "", "0", rd4("CantMM2").ToString)
                    TxtCantMM3.Text = IIf(rd4("CantMM3").ToString = "", "0", rd4("CantMM3").ToString)
                    TxtCantMM4.Text = IIf(rd4("CantMM4").ToString = "", "0", rd4("CantMM4").ToString)

                    TxtCantEsp.Text = IIf(rd4("CantEsp1").ToString = "", "0", rd4("CantEsp1").ToString)
                    TxtCantEsp2.Text = IIf(rd4("CantEsp2").ToString = "", "0", rd4("CantEsp2").ToString)
                    TxtCantEsp3.Text = IIf(rd4("CantEsp3").ToString = "", "0", rd4("CantEsp3").ToString)
                    TxtCantEsp4.Text = IIf(rd4("CantEsp4").ToString = "", "0", rd4("CantEsp4").ToString)

                    TxtCantLta.Text = IIf(rd4("CantLst1").ToString = "", "0", rd4("CantLst1").ToString)
                    TxtCantLta2.Text = IIf(rd4("CantLst2").ToString = "", "0", rd4("CantLst2").ToString)
                    TxtCantLta3.Text = IIf(rd4("CantLst3").ToString = "", "0", rd4("CantLst3").ToString)
                    TxtCantLta4.Text = IIf(rd4("CantLst4").ToString = "", "0", rd4("CantLst4").ToString)

                    txtmonedero.Text = rd4("Promo_Monedero").ToString()
                    ChkTodos.Checked = rd4("pres_vol").ToString
                    'dtpFechaI.Value = rd4("Fecha_Inicial").ToString
                    'dtpFechaF.Value = rd4("Fecha_Final").ToString
                    Dim activar As Integer = IIf(rd4("pres_vol").ToString = True, 1, 0)
                    If activar = 1 Then
                        Call ActivarP()
                    Else
                        Call DesactivarP()
                    End If
                End If
            End If
            rd4.Close()

            Dim codi As String = Mid(cboCodigo.Text, 1, 6)

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select PrecioCompra from Productos where Codigo='" & codi & "' and ProvRes=0"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    cnn5.Close()
                    cnn5.Open()

                    cmd5 = cnn5.CreateCommand
                    cmd5.CommandText =
                        "select PrecioCompra,MCD,IVA from Productos where Codigo='" & cboCodigo.Text & "' and ProvRes=0"
                    rd5 = cmd5.ExecuteReader
                    If rd5.HasRows Then
                        If rd5.Read Then
                            If CDec(rd5("MCD").ToString) > 0 Then
                                TxtPC.Text = (CDec(IIf(rd4("PrecioCompra").ToString = "", "0", rd4("PrecioCompra").ToString)) * CDec(LblValor.Text)) / CDec(rd5("MCD").ToString)
                                TxtPC.Text = FormatNumber(TxtPC.Text, 2)
                                TxtPCI.Text = CDec(IIf(TxtPC.Text = "", "0", TxtPC.Text)) * (CDec(rd5("IVA").ToString) + 1)
                                TxtPCI.Text = FormatNumber(TxtPCI.Text, 2)
                                TxtMonedaSIVA.Text = CDec(IIf(TxtPC.Text = "", "1", TxtPC.Text)) / CDec(LblValor.Text)
                                TxtMonedaSIVA.Text = FormatNumber(TxtMonedaSIVA.Text, 2)
                                TxtMonedaIva.Text = CDec(IIf(TxtPCI.Text = "", "1", TxtPCI.Text)) / CDec(LblValor.Text)
                                TxtMonedaIva.Text = FormatNumber(TxtMonedaIva.Text, 2)
                            End If
                        End If
                    End If
                    rd5.Close()
                    cnn5.Close()
                End If
            End If
            rd4.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try
    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If (ChkTodos.Checked) Then
            ActivarP()
        Else
            DesactivarP()
        End If
    End Sub

    Private Sub ChkPromocion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkPromocion.CheckedChanged
        If ChkPromocion.Checked = True Then
            GpbPromociones.Visible = True
            dtpFechaF.Enabled = True
            dtpFechaI.Enabled = True
        Else
            GpbPromociones.Visible = False
            dtpFechaF.Enabled = False
            dtpFechaI.Enabled = False
        End If
    End Sub

    Private Sub TxtPCI_Click(sender As Object, e As System.EventArgs) Handles TxtPCI.Click
        TxtPCI.SelectionStart = 0
        TxtPCI.SelectionLength = Len(TxtPCI.Text)
    End Sub

    Private Sub TxtPCI_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPCI.GotFocus
        TxtPCI.SelectionStart = 0
        TxtPCI.SelectionLength = Len(TxtPCI.Text)
    End Sub

    Private Sub TxtPCI_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPCI.KeyPress
        If Not IsNumeric(TxtPCI.Text) Then TxtPCI.Text = "" : Exit Sub
        Cambio1 = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPCI.Text) = "" Then Exit Sub
            Cambio1 = 0
            TxtPCI.Text = FormatNumber(TxtPCI.Text, 2)
            TxtMonedaSIVA.Focus().Equals(True)
        Else
            Cambio1 = 1
        End If
    End Sub

    Private Sub TxtPCI_LostFocus(sender As Object, e As System.EventArgs) Handles TxtPCI.LostFocus
        TxtPCI.Text = FormatNumber(IIf(TxtPCI.Text = "", TxtPCI.Text = "0.00", TxtPCI.Text), 2)
    End Sub

    Private Sub TxtPCI_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPCI.TextChanged
        If Cambio1 = 1 Then
            If Not IsNumeric(TxtPCI.Text) Then TxtPCI.Text = "" : Exit Sub
            If Trim(TxtPCI.Text) = "" Then Exit Sub
            Cambio1 = 0
            Call Chang()
        End If
    End Sub

    Private Function Chang()
        Try
            Dim MyCodIVA As Double = 0

            If TxtPCI.Text = "" Or TxtPCI.Text = "." Then Return Nothing : Exit Function

            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IVA from Productos where Nombre='" & CboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MyCodIVA = rd1("IVA").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            TxtPC.Text = FormatNumber(CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) / (1 + MyCodIVA), 2)

            TxtMonedaSIVA.Text = FormatNumber(CDec(TxtPC.Text) / CDec(IIf(LblValor.Text = "", "0", LblValor.Text)), 2)
            TxtMonedaIva.Text = FormatNumber(CDec(TxtMonedaSIVA.Text) * (1 + MyCodIVA), 2)
            TxtMonedaSIVA.Text = FormatNumber(TxtMonedaSIVA.Text, 2)
            TxtMonedaIva.Text = FormatNumber(TxtMonedaIva.Text, 2)
            TxtPC.Text = FormatNumber(TxtPC.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return Nothing
    End Function

    Private Sub TxtMonedaIva_Click(sender As Object, e As System.EventArgs) Handles TxtMonedaIva.Click
        TxtMonedaIva.SelectionStart = 0
        TxtMonedaIva.SelectionLength = Len(TxtMonedaIva.Text)
    End Sub

    Private Sub TxtMonedaIva_GotFocus(sender As Object, e As System.EventArgs) Handles TxtMonedaIva.GotFocus
        TxtMonedaIva.SelectionStart = 0
        TxtMonedaIva.SelectionLength = Len(TxtMonedaIva.Text)
    End Sub

    Private Sub TxtMonedaIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonedaIva.KeyPress
        If Not IsNumeric(TxtMonedaIva.Text) Then TxtMonedaIva.Text = "" : Exit Sub
        Cambio3 = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtMonedaIva.Text) = "" Then Exit Sub
            Cambio3 = 0
            TxtMonedaIva.Text = FormatNumber(TxtMonedaIva.Text, 2)
            TxtPorLta.Focus().Equals(True)
        Else
            Cambio3 = 1
        End If
    End Sub

    Private Sub TxtMonedaIva_LostFocus(sender As Object, e As System.EventArgs) Handles TxtMonedaIva.LostFocus
        If TxtMonedaIva.Text = "" Then TxtMonedaIva.Text = "0.00"
        TxtMonedaIva.Text = FormatNumber(TxtMonedaIva.Text, 2)
    End Sub

    Private Sub TxtMonedaIva_TextChanged(sender As Object, e As System.EventArgs) Handles TxtMonedaIva.TextChanged
        If Cambio3 = 1 Then
            If Not IsNumeric(TxtMonedaIva.Text) Then TxtMonedaIva.Text = "" : Exit Sub
            If Trim(TxtMonedaIva.Text) = "" Then Exit Sub
            Cambio3 = 0
            Call cmb()
        End If
    End Sub

    Private Function cmb()
        Try
            Dim cal As Double = 0
            Dim MyCodIVA As Double = 0

            If TxtMonedaIva.Text = "" Or TxtMonedaIva.Text = "." Then Return Nothing : Exit Function

            cnn2.Close()
            cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select IVA from Productos where Nombre='" & CboDescripcion.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MyCodIVA = rd2("IVA").ToString
                End If
            End If

            cal = CDec(TxtMonedaIva.Text) / CDec(MyCodIVA + 1)
            TxtMonedaSIVA.Text = FormatNumber(cal, 2)
            TxtPC.Text = FormatNumber(CDec(TxtMonedaSIVA.Text) * CDec(LblValor.Text), 2)
            TxtPCI.Text = FormatNumber(CDec(TxtPC.Text) * (MyCodIVA + 1), 2)

            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return Nothing
    End Function

    Private Sub TxtMonedaSIVA_Click(sender As Object, e As System.EventArgs) Handles TxtMonedaSIVA.Click
        TxtMonedaSIVA.SelectionStart = 0
        TxtMonedaSIVA.SelectionLength = Len(TxtMonedaSIVA.Text)
    End Sub

    Private Sub TxtMonedaSIVA_GotFocus(sender As Object, e As System.EventArgs) Handles TxtMonedaSIVA.GotFocus
        TxtMonedaSIVA.SelectionStart = 0
        TxtMonedaSIVA.SelectionLength = Len(TxtMonedaSIVA.Text)
    End Sub

    Private Sub TxtMonedaSIVA_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonedaSIVA.KeyPress
        If Not IsNumeric(TxtMonedaSIVA.Text) Then TxtMonedaSIVA.Text = "" : Exit Sub
        Cambio2 = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtMonedaSIVA.Text) = "" Then Exit Sub
            Cambio2 = 0
            TxtMonedaSIVA.Text = FormatNumber(TxtMonedaSIVA.Text, 2)
            TxtMonedaIva.Focus().Equals(True)
        Else
            Cambio2 = 1
        End If
    End Sub

    Private Sub TxtMonedaSIVA_LostFocus(sender As Object, e As System.EventArgs) Handles TxtMonedaSIVA.LostFocus
        If TxtMonedaSIVA.Text = "" Then TxtMonedaSIVA.Text = "0"
        TxtMonedaSIVA.Text = FormatNumber(TxtMonedaSIVA.Text, 2)
    End Sub

    Private Sub TxtMonedaSIVA_TextChanged(sender As Object, e As System.EventArgs) Handles TxtMonedaSIVA.TextChanged
        If Cambio2 = 1 Then
            If Not IsNumeric(TxtMonedaSIVA.Text) Then TxtMonedaSIVA.Text = "" : Exit Sub
            If Trim(TxtMonedaSIVA.Text) = "" Then Exit Sub
            Cambio2 = 0
            Call cmM()
        End If
    End Sub

    Private Function cmM()
        Try
            Dim cal As Double = 0
            Dim MyCodIVA As Double = 0
            Dim aux As Double = 0

            If TxtMonedaSIVA.Text = "" Or TxtMonedaSIVA.Text = "." Then Return Nothing : Exit Function

            cal = CDec(TxtMonedaSIVA.Text) * CDec(LblValor.Text)
            TxtPC.Text = FormatNumber(cal, 2)

            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IVA from Productos where Nombre='" & CboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MyCodIVA = rd1("IVA").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            cal = CDec(TxtMonedaSIVA.Text) * CDec(MyCodIVA + 1)
            TxtMonedaIva.Text = FormatNumber(cal, 2)
            aux = CDec(TxtPC.Text) * CDec(MyCodIVA + 1)
            TxtPCI.Text = FormatNumber(aux, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return Nothing
    End Function

    Private Sub TxtPC_Click(sender As Object, e As System.EventArgs) Handles TxtPC.Click
        TxtPC.SelectionStart = 0
        TxtPC.SelectionLength = Len(TxtPC.Text)
    End Sub

    Private Sub TxtPC_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPC.GotFocus
        TxtPC.SelectionStart = 0
        TxtPC.SelectionLength = Len(TxtPC.Text)
    End Sub

    Private Sub TxtPC_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPC.KeyPress
        If Not IsNumeric(TxtPC.Text) Then TxtPC.Text = "" : Exit Sub
        Cambio = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPC.Text) = "" Then Exit Sub
            Cambio = 0
            TxtPCI.Focus().Equals(True)
        Else
            Cambio = 1
        End If
    End Sub

    Private Sub TxtPC_LostFocus(sender As Object, e As System.EventArgs) Handles TxtPC.LostFocus
        If TxtPC.Text = "" Then TxtPC.Text = "0.00"
        TxtPC.Text = FormatNumber(TxtPC.Text, 2)
    End Sub

    Private Sub TxtPC_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPC.TextChanged
        If Cambio = 1 Then
            If Not IsNumeric(TxtPC.Text) Then TxtPC.Text = "" : Exit Sub
            If Trim(TxtPC.Text) = "" Then Exit Sub
            Cambio = 0
            Call cam()
        End If
    End Sub

    Private Function cam()
        Try
            Dim MyCodIVA As Double = 0
            If TxtPC.Text = "" Or TxtPC.Text = "." Then Return Nothing : Exit Function

            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IVA from Productos where Nombre='" & CboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MyCodIVA = rd1("IVA").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            TxtPCI.Text = CDec(IIf(TxtPC.Text = "", "0", TxtPC.Text)) * (1 + MyCodIVA)
            TxtPCI.Text = FormatNumber(TxtPCI.Text, 2)
            TxtMonedaSIVA.Text = FormatNumber(CDec(IIf(TxtPC.Text = "", "0", TxtPC.Text)) / CDec(LblValor.Text), 2)
            TxtMonedaIva.Text = FormatNumber(CDec(IIf(TxtPCI.Text = "", "0", TxtPCI.Text)) / CDec(LblValor.Text), 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return Nothing
    End Function

    Private Sub ChkTodos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ChkTodos.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            ChkPromocion.Focus().Equals(True)
        End If
    End Sub

    Private Sub ChkPromocion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ChkPromocion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If GpbPromociones.Visible = True Then
                If dtpFechaI.Enabled = True Then
                    dtpFechaI.Focus().Equals(True)
                Else
                    TxtPreLta.Focus().Equals(True)
                End If
            Else
                TxtPorLta.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub TxtPorLta_Click(sender As System.Object, e As System.EventArgs) Handles TxtPorLta.Click
        TxtPorLta.SelectionStart = 0
        TxtPorLta.SelectionLength = Len(TxtPorLta.Text)
    End Sub

    Private Sub TxtPorLta_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPorLta.GotFocus
        TxtPorLta.SelectionStart = 0
        TxtPorLta.SelectionLength = Len(TxtPorLta.Text)
    End Sub

    Private Sub TxtPorLta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorLta.KeyPress
        If Not IsNumeric(TxtPorLta.Text) Then TxtPorLta.Text = "" : Exit Sub
        A5 = 5
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorLta.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A5)
            A5 = 0
            TxtPorLta.Text = FormatNumber(TxtPorLta.Text, 2)
            TxtPreLta.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorLta_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPorLta.TextChanged
        If Not IsNumeric(TxtPorLta.Text) Then TxtPorLta.Text = "" : Exit Sub
        If Trim(TxtPorLta.Text) = "" Then Exit Sub
        Call C1(A5)
    End Sub

    Private Sub TxtPreLta_Click(sender As System.Object, e As System.EventArgs) Handles TxtPreLta.Click
        TxtPreLta.SelectionStart = 0
        TxtPreLta.SelectionLength = Len(TxtPreLta.Text)
    End Sub

    Private Sub TxtPreLta_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPreLta.GotFocus
        TxtPreLta.SelectionStart = 0
        TxtPreLta.SelectionLength = Len(TxtPreLta.Text)
    End Sub

    Private Sub TxtPreLta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPreLta.KeyPress
        If Not IsNumeric(TxtPreLta.Text) Then TxtPreLta.Text = "" : Exit Sub
        B5 = 5
        If TxtPCI.Text = "0" Then
            If TxtPCI.Text = "0.00" Or TxtPCI.Text = "0" Or CDec(TxtPCI.Text) = 0 Then
                MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                TxtPCI.Focus().Equals(True)
                Exit Sub
            End If
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreLta.Text) = "" Then Exit Sub
            Call T1(B5)
            B5 = 0
            TxtPreLta.Text = FormatNumber(TxtPreLta.Text, 2)
            TxtCantLta.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreLta_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPreLta.TextChanged
        If Not IsNumeric(TxtPreLta.Text) Then TxtPreLta.Text = "" : Exit Sub
        If Trim(TxtPreLta.Text) = "" Then Exit Sub
        Call T1(B5)
    End Sub

    Private Sub TxtCantLta_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantLta.Click
        TxtCantLta.SelectionStart = 0
        TxtCantLta.SelectionLength = Len(TxtCantLta.Text)
    End Sub

    Private Sub TxtCantLta_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantLta.GotFocus
        TxtCantLta.SelectionStart = 0
        TxtCantLta.SelectionLength = Len(TxtCantLta.Text)
    End Sub

    Private Sub TxtCantLta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantLta.KeyPress
        If Not IsNumeric(TxtCantLta.Text) Then TxtCantLta.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtCantLta2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantLta_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantLta.LostFocus
        If TxtCantLta.Text = "" Then
            TxtCantLta.Text = "0"
        End If
    End Sub

    Private Sub TxtCantLta2_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantLta2.Click
        TxtCantLta2.SelectionStart = 0
        TxtCantLta2.SelectionLength = Len(TxtCantLta2.Text)
    End Sub

    Private Sub TxtCantLta2_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantLta2.GotFocus
        TxtCantLta2.SelectionStart = 0
        TxtCantLta2.SelectionLength = Len(TxtCantLta2.Text)
    End Sub

    Private Sub TxtCantLta2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantLta2.KeyPress
        If Not IsNumeric(TxtCantLta2.Text) Then TxtCantLta2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantLta2_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantLta2.LostFocus
        If TxtCantLta2.Text = "" Then
            TxtCantLta2.Text = "0"
        End If
    End Sub

    Private Sub TxtUtiM_Click(sender As System.Object, e As System.EventArgs) Handles TxtUtiM.Click
        TxtUtiM.SelectionStart = 0
        TxtUtiM.SelectionLength = Len(TxtUtiM.Text)
    End Sub

    Private Sub TxtUtiM_GotFocus(sender As Object, e As System.EventArgs) Handles TxtUtiM.GotFocus
        TxtUtiM.SelectionStart = 0
        TxtUtiM.SelectionLength = Len(TxtUtiM.Text)
    End Sub

    Private Sub TxtUtiM_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUtiM.KeyPress
        If Not IsNumeric(TxtUtiM.Text) Then TxtUtiM.Text = "" : Exit Sub
        A1 = 1
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtUtiM.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A1)
            A1 = 0
            TxtPMI.Text = FormatNumber(TxtPMI.Text)
            TxtPMI.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtUtiM_LostFocus(sender As Object, e As System.EventArgs) Handles TxtUtiM.LostFocus
        TxtUtiM.Text = FormatNumber(TxtUtiM.Text, 2)
    End Sub

    Private Sub TxtUtiM_TextChanged(sender As Object, e As System.EventArgs) Handles TxtUtiM.TextChanged
        If Not IsNumeric(TxtUtiM.Text) Then TxtUtiM.Text = "" : Exit Sub
        If Trim(TxtUtiM.Text) = "" Then Exit Sub
        Call C1(A1)
    End Sub

    Private Sub TxtPMI_Click(sender As System.Object, e As System.EventArgs) Handles TxtPMI.Click
        TxtPMI.SelectionStart = 0
        TxtPMI.SelectionLength = Len(TxtPMI.Text)
    End Sub

    Private Sub TxtPMI_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPMI.GotFocus
        TxtPMI.SelectionStart = 0
        TxtPMI.SelectionLength = Len(TxtPMI.Text)
    End Sub

    Private Sub TxtPMI_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPMI.KeyPress
        If Not IsNumeric(TxtPMI.Text) Then TxtPMI.Text = "" : Exit Sub
        B1 = 1
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPMI.Text) = "" Then Exit Sub
            Call T1(B1)
            B5 = 0
            TxtPMI.Text = FormatNumber(TxtPMI.Text, 2)
            TxtCantMin.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPMI_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPMI.TextChanged
        If Not IsNumeric(TxtPMI.Text) Then TxtPMI.Text = "" : Exit Sub
        If Trim(TxtPMI.Text) = "" Then Exit Sub
        Call T1(B1)
    End Sub

    Private Sub TxtCantMin_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantMin.Click
        TxtCantMin.SelectionStart = 0
        TxtCantMin.SelectionLength = Len(TxtCantMin.Text)
    End Sub

    Private Sub TxtCantMin_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantMin.GotFocus
        TxtCantMin.SelectionStart = 0
        TxtCantMin.SelectionLength = Len(TxtCantMin.Text)
    End Sub

    Private Sub TxtCantMin_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantMin.KeyPress
        If Not IsNumeric(TxtCantMin.Text) Then TxtCantMin.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCantMin2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMin_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantMin.LostFocus
        If TxtCantMin.Text = "" Then
            TxtCantMin.Text = "0"
        End If
    End Sub

    Private Sub txtCantMin2_Click(sender As System.Object, e As System.EventArgs) Handles txtCantMin2.Click
        txtCantMin2.SelectionStart = 0
        txtCantMin2.SelectionLength = Len(txtCantMin2.Text)
    End Sub

    Private Sub txtCantMin2_GotFocus(sender As Object, e As System.EventArgs) Handles txtCantMin2.GotFocus
        txtCantMin2.SelectionStart = 0
        txtCantMin2.SelectionLength = Len(txtCantMin2.Text)
    End Sub

    Private Sub txtCantMin2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantMin2.KeyPress
        If Not IsNumeric(txtCantMin2.Text) Then txtCantMin2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorMay.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtCantMin2_LostFocus(sender As Object, e As System.EventArgs) Handles txtCantMin2.LostFocus
        If txtCantMin2.Text = "" Then
            txtCantMin2.Text = "0"
        End If
    End Sub

    Private Sub TxtPorMay_Click(sender As System.Object, e As System.EventArgs) Handles TxtPorMay.Click
        TxtPorMay.SelectionStart = 0
        TxtPorMay.SelectionLength = Len(TxtPorMay.Text)
    End Sub

    Private Sub TxtPorMay_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPorMay.GotFocus
        TxtPorMay.SelectionStart = 0
        TxtPorMay.SelectionLength = Len(TxtPorMay.Text)
    End Sub

    Private Sub TxtPorMay_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorMay.KeyPress
        If Not IsNumeric(TxtPorMay.Text) Then TxtPorMay.Text = "" : Exit Sub
        A2 = 2
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorMay.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A2)
            A2 = 0
            TxtPorMay.Text = FormatNumber(TxtPorMay.Text, 2)
            TxtPreMay.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorMay_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPorMay.TextChanged
        If Not IsNumeric(TxtPorMay.Text) Then TxtPorMay.Text = "" : Exit Sub
        If Trim(TxtPorMay.Text) = "" Then Exit Sub
        Call C1(A2)
    End Sub

    Private Sub TxtPreMay_Click(sender As System.Object, e As System.EventArgs) Handles TxtPreMay.Click
        TxtPreMay.SelectionStart = 0
        TxtPreMay.SelectionLength = Len(TxtPreMay.Text)
    End Sub

    Private Sub TxtPreMay_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPreMay.GotFocus
        TxtPreMay.SelectionStart = 0
        TxtPreMay.SelectionLength = Len(TxtPreMay.Text)
    End Sub

    Private Sub TxtPreMay_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPreMay.KeyPress
        If Not IsNumeric(TxtPreMay.Text) Then TxtPreMay.Text = "" : Exit Sub
        B2 = 2
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreMay.Text) = "" Then Exit Sub
            Call T1(B2)
            TxtPreMay.Text = FormatNumber(TxtPreMay.Text, 2)
            TxtCantMay.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreMay_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPreMay.TextChanged
        If Not IsNumeric(TxtPreMay.Text) Then TxtPreMay.Text = "" : Exit Sub
        If Trim(TxtPreMay.Text) = "" Then Exit Sub
        Call T1(B2)
    End Sub

    Private Sub TxtCantMay_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantMay.Click
        TxtCantMay.SelectionStart = 0
        TxtCantMay.SelectionLength = Len(TxtCantMay.Text)
    End Sub

    Private Sub TxtCantMay_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantMay.GotFocus
        TxtCantMay.SelectionStart = 0
        TxtCantMay.SelectionLength = Len(TxtCantMay.Text)
    End Sub

    Private Sub TxtCantMay_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantMay.KeyPress
        If Not IsNumeric(TxtCantMay.Text) Then TxtCantMay.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCantMay2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMay_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantMay.LostFocus
        If TxtCantMay.Text = "" Then
            TxtCantMay.Text = "0"
        End If
    End Sub

    Private Sub txtCantMay2_Click(sender As System.Object, e As System.EventArgs) Handles txtCantMay2.Click
        txtCantMay2.SelectionStart = 0
        txtCantMay2.SelectionLength = Len(txtCantMay2.Text)
    End Sub

    Private Sub txtCantMay2_GotFocus(sender As Object, e As System.EventArgs) Handles txtCantMay2.GotFocus
        txtCantMay2.SelectionStart = 0
        txtCantMay2.SelectionLength = Len(txtCantMay2.Text)
    End Sub

    Private Sub txtCantMay2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantMay2.KeyPress
        If Not IsNumeric(txtCantMay2.Text) Then txtCantMay2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorMM.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtCantMay2_LostFocus(sender As Object, e As System.EventArgs) Handles txtCantMay2.LostFocus
        If txtCantMay2.Text = "" Then
            txtCantMay2.Text = "0"
        End If
    End Sub

    Private Sub TxtPorMM_Click(sender As System.Object, e As System.EventArgs) Handles TxtPorMM.Click
        TxtPorMM.SelectionStart = 0
        TxtPorMM.SelectionLength = Len(TxtPorMM.Text)
    End Sub

    Private Sub TxtPorMM_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPorMM.GotFocus
        TxtPorMM.SelectionStart = 0
        TxtPorMM.SelectionLength = Len(TxtPorMM.Text)
    End Sub

    Private Sub TxtPorMM_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorMM.KeyPress
        If Not IsNumeric(TxtPorMM.Text) Then TxtPorMM.Text = "" : Exit Sub
        A3 = 3
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorMM.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A3)
            A3 = 0
            TxtPorMM.Text = FormatNumber(TxtPorMM.Text, 2)
            TxtPreMM.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorMM_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPorMM.TextChanged
        If Not IsNumeric(TxtPorMM.Text) Then TxtPorMM.Text = "" : Exit Sub
        If Trim(TxtPorMM.Text) = "" Then Exit Sub
        Call C1(A3)
    End Sub

    Private Sub TxtPreMM_Click(sender As System.Object, e As System.EventArgs) Handles TxtPreMM.Click
        TxtPreMM.SelectionStart = 0
        TxtPreMM.SelectionLength = Len(TxtPreMM.Text)
    End Sub

    Private Sub TxtPreMM_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPreMM.GotFocus
        TxtPreMM.SelectionStart = 0
        TxtPreMM.SelectionLength = Len(TxtPreMM.Text)
    End Sub

    Private Sub TxtPreMM_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPreMM.KeyPress
        If Not IsNumeric(TxtPreMM.Text) Then TxtPreMM.Text = "" : Exit Sub
        B3 = 3
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreMM.Text) = "" Then Exit Sub
            Call T1(B3)
            TxtPreMM.Text = FormatNumber(TxtPreMM.Text, 2)
            TxtCantMM.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreMM_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPreMM.TextChanged
        If Not IsNumeric(TxtPreMM.Text) Then TxtPreMM.Text = "" : Exit Sub
        If Trim(TxtPreMM.Text) = "" Then Exit Sub
        Call T1(B3)
    End Sub

    Private Sub TxtCantMM_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantMM.Click
        TxtCantMM.SelectionStart = 0
        TxtCantMM.SelectionLength = Len(TxtCantMM.Text)
    End Sub

    Private Sub TxtCantMM_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantMM.GotFocus
        TxtCantMM.SelectionStart = 0
        TxtCantMM.SelectionLength = Len(TxtCantMM.Text)
    End Sub

    Private Sub TxtCantMM_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantMM.KeyPress
        If Not IsNumeric(TxtCantMM.Text) Then TxtCantMM.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtCantMM2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMM_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantMM.LostFocus
        If TxtCantMM.Text = "" Then
            TxtCantMM.Text = "0"
        End If
    End Sub

    Private Sub TxtCantMM2_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantMM2.Click
        TxtCantMM2.SelectionStart = 0
        TxtCantMM2.SelectionLength = Len(TxtCantMM2.Text)
    End Sub

    Private Sub TxtCantMM2_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantMM2.GotFocus
        TxtCantMM2.SelectionStart = 0
        TxtCantMM2.SelectionLength = Len(TxtCantMM2.Text)
    End Sub

    Private Sub TxtCantMM2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantMM2.KeyPress
        If Not IsNumeric(TxtCantMM2.Text) Then TxtCantMM2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorEsp.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMM2_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantMM2.LostFocus
        If TxtCantMM2.Text = "" Then
            TxtCantMM2.Text = "0"
        End If
    End Sub

    Private Sub TxtPorEsp_Click(sender As System.Object, e As System.EventArgs) Handles TxtPorEsp.Click
        TxtPorEsp.SelectionStart = 0
        TxtPorEsp.SelectionLength = Len(TxtPorEsp.Text)
    End Sub

    Private Sub TxtPorEsp_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPorEsp.GotFocus
        TxtPorEsp.SelectionStart = 0
        TxtPorEsp.SelectionLength = Len(TxtPorEsp.Text)
    End Sub

    Private Sub TxtPorEsp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorEsp.KeyPress
        If Not IsNumeric(TxtPorEsp.Text) Then TxtPorEsp.Text = "" : Exit Sub
        A4 = 4
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorEsp.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A4)
            A4 = 0
            TxtPorEsp.Text = FormatNumber(TxtPorEsp.Text, 2)
            TxtPreEsp.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorEsp_TextChanged(sender As Object, e As System.EventArgs) Handles TxtPorEsp.TextChanged
        If Not IsNumeric(TxtPorEsp.Text) Then TxtPorEsp.Text = "" : Exit Sub
        If Trim(TxtPorEsp.Text) Then Exit Sub
        Call C1(A4)
    End Sub

    Private Sub TxtPreEsp_Click(sender As System.Object, e As System.EventArgs) Handles TxtPreEsp.Click
        TxtPreEsp.SelectionStart = 0
        TxtPreEsp.SelectionLength = Len(TxtPreEsp.Text)
    End Sub

    Private Sub TxtPreEsp_GotFocus(sender As Object, e As System.EventArgs) Handles TxtPreEsp.GotFocus
        TxtPreEsp.SelectionStart = 0
        TxtPreEsp.SelectionLength = Len(TxtPreEsp.Text)
    End Sub

    Private Sub TxtPreEsp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPreEsp.KeyPress
        If Not IsNumeric(TxtPreEsp.Text) Then TxtPreEsp.Text = "" : Exit Sub
        B4 = 4
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreEsp.Text) = "" Then Exit Sub
            Call T1(B4)
            B4 = 0
            TxtPreEsp.Text = FormatNumber(TxtPreEsp.Text, 2)
            TxtCantEsp.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreEsp_LostFocus(sender As Object, e As System.EventArgs) Handles TxtPreEsp.LostFocus
        If Not IsNumeric(TxtPreEsp.Text) Then TxtPreEsp.Text = "" : Exit Sub
        If Trim(TxtPreEsp.Text) Then Exit Sub
        Call T1(B4)
    End Sub

    Private Sub TxtCantEsp_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantEsp.Click
        TxtCantEsp.SelectionStart = 0
        TxtCantEsp.SelectionLength = Len(TxtCantEsp.Text)
    End Sub

    Private Sub TxtCantEsp_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantEsp.GotFocus
        TxtCantEsp.SelectionStart = 0
        TxtCantEsp.SelectionLength = Len(TxtCantEsp.Text)
    End Sub

    Private Sub TxtCantEsp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantEsp.KeyPress
        If Not IsNumeric(TxtCantEsp.Text) Then TxtCantEsp.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtCantEsp2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantEsp_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantEsp.LostFocus
        If TxtCantEsp.Text = "" Then
            TxtCantEsp.Text = "0"
        End If
    End Sub

    Private Sub TxtCantEsp2_Click(sender As System.Object, e As System.EventArgs) Handles TxtCantEsp2.Click
        TxtCantEsp2.SelectionStart = 0
        TxtCantEsp2.SelectionLength = Len(TxtCantEsp2.Text)
    End Sub

    Private Sub TxtCantEsp2_GotFocus(sender As Object, e As System.EventArgs) Handles TxtCantEsp2.GotFocus
        TxtCantEsp2.SelectionStart = 0
        TxtCantEsp2.SelectionLength = Len(TxtCantEsp2.Text)
    End Sub

    Private Sub TxtCantEsp2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantEsp2.KeyPress
        If Not IsNumeric(TxtCantEsp2.Text) Then TxtCantEsp2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorLta.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantEsp2_LostFocus(sender As Object, e As System.EventArgs) Handles TxtCantEsp2.LostFocus
        If TxtCantEsp2.Text = "" Then
            TxtCantEsp2.Text = "0"
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        TxtPC.Text = "0.00"
        TxtUnidad.Text = ""
        TxtPCI.Text = "0.00"
        TxtUtiM.Text = "0"
        TxtUtiM2.Text = "0"
        TxtPMI.Text = "0.00"
        TxtPMI2.Text = "0.00"
        TxtCantMin.Text = "0"
        txtCantMin2.Text = "0"
        TxtCantMin3.Text = "0"
        txtCantMin4.Text = "0"

        TxtPorMay.Text = "0"
        TxtPorMay2.Text = "0"
        TxtPreMay.Text = "0.00"
        TxtPreMay2.Text = "0.00"
        TxtCantMay.Text = "0"
        txtCantMay2.Text = "0"
        TxtCantMay3.Text = "0"
        txtCantMay4.Text = "0"

        TxtPorMM.Text = "0"
        TxtPorMM2.Text = "0"
        TxtPreMM.Text = "0.00"
        TxtPreMM2.Text = "0.00"
        TxtCantMM.Text = "0"
        TxtCantMM2.Text = "0"
        TxtCantMM3.Text = "0"
        TxtCantMM4.Text = "0"


        TxtPorEsp.Text = "0"
        TxtPorEsp2.Text = "0"
        TxtPreEsp.Text = "0.00"
        TxtPreEsp2.Text = "0.00"
        TxtCantEsp.Text = "0"
        TxtCantEsp2.Text = "0"
        TxtCantEsp3.Text = "0"
        TxtCantEsp4.Text = "0"


        TxtPorLta.Text = "0"
        TxtPorLta2.Text = "0"
        TxtPreLta.Text = "0.00"
        TxtPreLta2.Text = "0.00"
        TxtCantLta.Text = "0"
        TxtCantLta2.Text = "0"
        TxtCantLta3.Text = "0"
        TxtCantLta4.Text = "0"

        ChkTodos.Checked = False
        ChkPromocion.Checked = False
        Call DesactivarP()
        cboCodigo.Text = ""
        CboDescripcion.Text = ""

        LblValor.Text = "0.00"
        LblMoneda.Text = ""
        TxtMonedaIva.Text = "0.00"
        TxtMonedaSIVA.Text = "0.00"

        TxtPromoPercent.Text = "0"
        dtpFechaF.Value = Date.Now
        dtpFechaI.Value = Date.Now
        txtmonedero.Text = "0"

        Call Promos(False)
        txtcontraseña.Text = ""
        CboDescripcion.Focus().Equals(True)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim pmin As Double = TxtPMI.Text
            Dim pmay As Double = TxtPreMay.Text
            Dim pmay2 As Double = TxtPreMay2.Text

            Dim pmme As Double = TxtPreMM.Text
            Dim pmme2 As Double = TxtPreMM2.Text

            Dim pesp As Double = TxtPreEsp.Text
            Dim pesp2 As Double = TxtPreEsp2.Text

            Dim plis As Double = TxtPreLta.Text
            Dim pvi As Double = CDbl(TxtPMI.Text) / CDbl(LblValor.Text)
            Dim pvi2 As Double = CDbl(TxtPMI2.Text) / CDbl(LblValor.Text)

            Dim pven As Double = CDbl(TxtPreLta.Text) / CDbl(LblValor.Text)
            Dim pven2 As Double = CDbl(TxtPreLta2.Text) / CDbl(LblValor.Text)

            Dim uti_min As Double = TxtUtiM.Text
            Dim uti_min2 As Double = TxtUtiM2.Text

            Dim uti_may As Double = TxtPorMay.Text
            Dim uti_may2 As Double = TxtPorMay2.Text

            Dim uti_mm As Double = TxtPorMM.Text
            Dim uti_mm2 As Double = TxtPorMM2.Text

            'porcentaje especial
            Dim uti_esp As Double = TxtPorEsp.Text
            Dim uti_esp2 As Double = TxtPorEsp2.Text

            Dim uti_lta As Double = TxtPorLta.Text
            Dim uti_lta2 As Double = TxtPorLta2.Text

            Dim fecha As String = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")

            If cboCodigo.Text = "" Or CboDescripcion.Text = "" Then MsgBox("Selecciona un producto para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : CboDescripcion.Focus() : Exit Sub
            If TxtPC.Text = "" Then MsgBox("Escribe un valor en costo sin IVA.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : TxtPC.Focus() : Exit Sub
            If TxtPCI.Text = "" Then MsgBox("Escribe un valor en costo con IVA.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : TxtPCI.Focus() : Exit Sub
            If txtcontraseña.Text = "" Then MsgBox("Escriba su contraseña por favor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus() : Exit Sub


            If MsgBox("¿Deseas actualizar los precios de este producto?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        alias_precios = rd1("Alias").ToString()
                    End If
                Else
                    MsgBox("No existe el usuario, corrobora la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtcontraseña.SelectionStart = 0 : txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select IVA from Productos where Codigo='" & cboCodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Dim IVA As Double = rd1("IVA").ToString
                        Dim PComp As Double = 0, PVent As Double = 0
                        Dim NPcomp As Double = TxtPC.Text, NPvent As Double = TxtPreLta.Text

                        cnn2.Close() : cnn2.Open()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select PrecioCompra, PrecioVentaIVA from Productos where Codigo='" & cboCodigo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                PComp = rd2(0).ToString
                                PVent = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()

                        If PComp <> CDbl(TxtPC.Text) Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into ModPrecios(Codigo,Nombre,Tipo,Anterior,Nuevo,Fecha,Usuario) values('" & cboCodigo.Text & "','" & CboDescripcion.Text & "','Compra'," & PComp & "," & NPcomp & ",'" & fecha & "','" & lblusuario.Text & "')"
                            cmd2.ExecuteNonQuery()
                        End If

                        If PVent <> CDbl(TxtPreLta.Text) Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into ModPrecios(Codigo,Nombre,Tipo,Anterior,Nuevo,Fecha,Usuario) values('" & cboCodigo.Text & "','" & CboDescripcion.Text & "','Venta'," & PVent & "," & NPvent & ",'" & fecha & "','" & lblusuario.Text & "')"
                            cmd2.ExecuteNonQuery()
                        End If

                        If (ChkPromocion.Checked) Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update Productos set PrecioCompra=" & NPcomp & ", Almacen3=" & NPcomp & ", PorcMin=" & uti_min & ",PorcMin2=" & uti_min & ", PorcMay=" & uti_may & ",PorcMay2=" & uti_may2 & ", PorcMM=" & uti_mm & ",PorcMM2=" & uti_mm2 & ", PorcEsp=" & uti_esp & ",PorcEsp2=" & uti_esp2 & ", Porcentaje=" & uti_lta & ",Porcentaje2=" & uti_lta2 & ", PreMin=" & pvi & ",PreMin2=" & pvi2 & ", PreMay=" & pmay & ",PreMay2=" & pmay2 & ", PreMM=" & pmme & ",PreMM2=" & pmme2 & ", PreEsp=" & pesp & ",PreEsp2=" & pesp2 & ", PrecioVenta=" & pven & ",PrecioVenta2=" & pven2 & ", PrecioVentaIVA=" & pven & ",PrecioVentaIVA2=" & pven2 & ", CantMin1=" & TxtCantMin.Text & ", CantMin2=" & txtCantMin2.Text & ",CantMin3=" & TxtCantMin3.Text & ",CantMin4=" & txtCantMin4.Text & ", CantMay1=" & TxtCantMay.Text & ", CantMay2=" & txtCantMay2.Text & ",CantMay3=" & TxtCantMay3.Text & ",CantMay4=" & txtCantMay4.Text & ", CantMM1=" & TxtCantMM.Text & ", CantMM2=" & TxtCantMM2.Text & ",CantMM3=" & TxtCantMM3.Text & ",CantMM4=" & TxtCantMM4.Text & ", CantEsp1=" & TxtCantEsp.Text & ", CantEsp2=" & TxtCantEsp2.Text & ",CantEsp3=" & TxtCantEsp3.Text & ",CantEsp4=" & TxtCantEsp4.Text & ", CantLst1=" & TxtCantLta.Text & ", CantLst2=" & TxtCantLta2.Text & ",CantLst3=" & TxtCantLta3.Text & ",CantLst4=" & TxtCantLta4.Text & ", pres_vol=" & IIf(ChkTodos.Checked, 1, 0) & ", Porcentaje_Promo=" & TxtPromoPercent.Text & ", Status_Promocion=1, Fecha_Inicial='" & Format(dtpFechaI.Value, "yyyy-MM-dd") & "', Fecha_Final='" & Format(dtpFechaF.Value, "yyyy-MM-dd") & "', Promo_Monedero=" & txtmonedero.Text & ", Actu=0 where Codigo='" & cboCodigo.Text & "'"
                            cmd2.ExecuteNonQuery()
                        Else

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update Productos set PrecioCompra=" & NPcomp & ", Almacen3=" & NPcomp & ", PorcMin=" & uti_min & ",PorcMin2=" & uti_min2 & ", PorcMay=" & uti_may & ",PorcMay2=" & uti_may2 & ", PorcMM=" & uti_mm & ",PorcMM2=" & uti_mm2 & ", PorcEsp=" & uti_esp & ",PorcEsp2=" & uti_esp2 & ", Porcentaje=" & uti_lta & ",Porcentaje2=" & uti_lta2 & ", PreMin=" & pvi & ",PreMin2=" & pvi2 & ", PreMay=" & pmay & ",PreMay2=" & pmay2 & ", PreMM=" & pmme & ",PreMM2=" & pmme2 & ", PreEsp=" & pesp & ",PreEsp2=" & pesp2 & ", PrecioVenta=" & pven & ",PrecioVenta2=" & pven2 & ", PrecioVentaIVA=" & pven & ",PrecioVentaIVA2=" & pven2 & ", CantMin1=" & TxtCantMin.Text & ", CantMin2=" & txtCantMin2.Text & ",CantMin3=" & TxtCantMin3.Text & ",CantMin4=" & txtCantMin4.Text & ", CantMay1=" & TxtCantMay.Text & ", CantMay2=" & txtCantMay2.Text & ",CantMay3=" & TxtCantMay3.Text & ",CantMay4=" & txtCantMay4.Text & ", CantMM1=" & TxtCantMM.Text & ", CantMM2=" & TxtCantMM2.Text & ",CantMM3=" & TxtCantMM3.Text & ",CantMM4=" & TxtCantMM4.Text & ", CantEsp1=" & TxtCantEsp.Text & ", CantEsp2=" & TxtCantEsp2.Text & ",CantEsp3=" & TxtCantEsp3.Text & ",CantEsp4=" & TxtCantEsp4.Text & ", CantLst1=" & TxtCantLta.Text & ", CantLst2=" & TxtCantLta2.Text & ",CantLst3=" & TxtCantLta3.Text & ",CantLst4=" & TxtCantLta4.Text & ", pres_vol=" & IIf(ChkTodos.Checked, 1, 0) & ", Status_Promocion=0, Promo_Monedero=" & txtmonedero.Text & ", Actu=0 where Codigo='" & cboCodigo.Text & "'"
                            cmd2.ExecuteNonQuery()
                        End If

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Productos set Cargado=0 where Codigo='" & cboCodigo.Text & "'"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "delete from Precios_Rango where Codigo='" & cboCodigo.Text & "'"
                        cmd2.ExecuteNonQuery()

                        If CDbl(TxtCantMin3.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantMin3.Text & "," & TxtPMI2.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantMin.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantMin.Text & "," & TxtPMI.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantMay3.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantMay3.Text & "," & TxtPreMay2.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantMay.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantMay.Text & "," & TxtPreMay.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantMM3.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantMM3.Text & "," & TxtPreMM2.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantMM.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantMM.Text & "," & TxtPreMM.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantEsp3.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantEsp3.Text & "," & TxtPreEsp2.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantEsp.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantEsp.Text & "," & TxtPreEsp.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantLta3.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantLta3.Text & "," & TxtPreLta2.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If

                        If CDbl(TxtCantLta.Text) > 0 Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Precios_Rango(Codigo,Desde,Precio,Status) values('" & cboCodigo.Text & "'," & TxtCantLta.Text & "," & TxtPreLta.Text & ",0)"
                            cmd2.ExecuteNonQuery()
                        End If


                        cnn2.Close()
                    End If
                End If
                rd1.Close() : cnn1.Close()

                MsgBox("Precios actualizados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnNuevo.PerformClick()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close() : cnn2.Close()
        End Try
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCodigo.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    rd1.Close()
                    cnn1.Close()
                    find_cod()
                End If
            Else
                MsgBox("El producto no existe en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cboCodigo.Focus().Equals(True)
                rd1.Close()
                cnn1.Close()
                Exit Sub
            End If
            If CboDescripcion.Text <> "" Then
                TxtPC.Focus().Equals(True)
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtcontraseña_Click(sender As System.Object, e As System.EventArgs) Handles txtcontraseña.Click
        txtcontraseña.SelectionStart = 0
        txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
    End Sub

    Private Sub cbofiltro_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtmonedero_GotFocus(sender As Object, e As System.EventArgs) Handles txtmonedero.GotFocus
        txtmonedero.SelectionStart = 0
        txtmonedero.SelectionLength = Len(txtmonedero.Text)
    End Sub

    Private Sub txtmonedero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonedero.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtmonedero.Text = "" Then txtmonedero.Text = "0"
            If CDbl(txtmonedero.Text) > 100 Then MsgBox("El porcentaje de bonificación para monedero no puede ser mayor a 100%", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonedero.SelectionStart = 0 : txtmonedero.SelectionLength = Len(txtmonedero.Text) : Exit Sub
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                If txtcontraseña.Text <> "" Then
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblusuario.Text = rd1("Alias").ToString()
                            alias_precios = rd1("Alias").ToString()
                        End If
                    Else
                        MsgBox("No existe el usuario, corrobora la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtcontraseña.SelectionStart = 0 : txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
                        rd1.Close() : cnn1.Close()
                        Exit Sub
                    End If
                    rd1.Close()
                    cnn1.Close()
                    btnGuardar.Focus().Equals(True)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub TxtUtiM2_Click(sender As Object, e As EventArgs) Handles TxtUtiM2.Click
        TxtUtiM2.SelectionStart = 0
        TxtUtiM2.SelectionLength = Len(TxtUtiM2.Text)
    End Sub

    Private Sub TxtUtiM2_GotFocus(sender As Object, e As EventArgs) Handles TxtUtiM2.GotFocus
        TxtUtiM2.SelectionStart = 0
        TxtUtiM2.SelectionLength = Len(TxtUtiM2.Text)
    End Sub

    Private Sub TxtUtiM2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUtiM2.KeyPress
        If Not IsNumeric(TxtUtiM2.Text) Then TxtUtiM2.Text = "" : Exit Sub
        A1 = 1
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtUtiM2.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A1)
            A1 = 0
            TxtPMI2.Text = FormatNumber(TxtPMI2.Text)
            TxtPMI2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtUtiM2_TextChanged(sender As Object, e As EventArgs) Handles TxtUtiM2.TextChanged
        If Not IsNumeric(TxtUtiM2.Text) Then TxtUtiM2.Text = "" : Exit Sub
        If Trim(TxtUtiM2.Text) = "" Then Exit Sub
        Call C1(A1)
    End Sub

    Private Sub TxtPMI2_Click(sender As Object, e As EventArgs) Handles TxtPMI2.Click
        TxtPMI2.SelectionStart = 0
        TxtPMI2.SelectionLength = Len(TxtPMI2.Text)
    End Sub

    Private Sub TxtPMI2_GotFocus(sender As Object, e As EventArgs) Handles TxtPMI2.GotFocus
        TxtPMI2.SelectionStart = 0
        TxtPMI2.SelectionLength = Len(TxtPMI2.Text)
    End Sub

    Private Sub TxtPMI2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPMI2.KeyPress
        If Not IsNumeric(TxtPMI2.Text) Then TxtPMI2.Text = "" : Exit Sub
        B1 = 1
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPMI2.Text) = "" Then Exit Sub
            Call T1(B1)
            B5 = 0
            TxtPMI2.Text = FormatNumber(TxtPMI2.Text, 2)
            TxtCantMin3.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPMI2_TextChanged(sender As Object, e As EventArgs) Handles TxtPMI2.TextChanged
        If Not IsNumeric(TxtPMI2.Text) Then TxtPMI2.Text = "" : Exit Sub
        If Trim(TxtPMI2.Text) = "" Then Exit Sub
        Call T1(B1)
    End Sub

    Private Sub TxtCantMin3_Click(sender As Object, e As EventArgs) Handles TxtCantMin3.Click
        TxtCantMin3.SelectionStart = 0
        TxtCantMin3.SelectionLength = Len(TxtCantMin3.Text)
    End Sub

    Private Sub TxtCantMin3_GotFocus(sender As Object, e As EventArgs) Handles TxtCantMin3.GotFocus
        TxtCantMin3.SelectionStart = 0
        TxtCantMin3.SelectionLength = Len(TxtCantMin3.Text)
    End Sub

    Private Sub TxtCantMin3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantMin3.KeyPress
        If Not IsNumeric(TxtCantMin3.Text) Then TxtCantMin3.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCantMin4.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMin3_LostFocus(sender As Object, e As EventArgs) Handles TxtCantMin3.LostFocus
        If TxtCantMin3.Text = "" Then
            TxtCantMin3.Text = "0"
        End If
    End Sub

    Private Sub txtCantMin4_Click(sender As Object, e As EventArgs) Handles txtCantMin4.Click
        txtCantMin4.SelectionStart = 0
        txtCantMin4.SelectionLength = Len(txtCantMin4.Text)
    End Sub

    Private Sub txtCantMin4_GotFocus(sender As Object, e As EventArgs) Handles txtCantMin4.GotFocus
        txtCantMin4.SelectionStart = 0
        txtCantMin4.SelectionLength = Len(txtCantMin4.Text)
    End Sub

    Private Sub txtCantMin4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantMin4.KeyPress
        If Not IsNumeric(txtCantMin4.Text) Then txtCantMin4.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorMay.Focus().Equals(True)
        End If
    End Sub
    Private Sub txtCantMin4_LostFocus(sender As Object, e As EventArgs) Handles txtCantMin4.LostFocus
        If txtCantMin4.Text = "" Then
            txtCantMin4.Text = "0"
        End If
    End Sub

    Private Sub TxtPorMay2_Click(sender As Object, e As EventArgs) Handles TxtPorMay2.Click
        TxtPorMay2.SelectionStart = 0
        TxtPorMay2.SelectionLength = Len(TxtPorMay2.Text)
    End Sub

    Private Sub TxtPorMay2_GotFocus(sender As Object, e As EventArgs) Handles TxtPorMay2.GotFocus
        TxtPorMay2.SelectionStart = 0
        TxtPorMay2.SelectionLength = Len(TxtPorMay2.Text)
    End Sub

    Private Sub TxtPorMay2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPorMay2.KeyPress
        If Not IsNumeric(TxtPorMay2.Text) Then TxtPorMay2.Text = "" : Exit Sub
        A2 = 2
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorMay2.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A2)
            A2 = 0
            TxtPorMay2.Text = FormatNumber(TxtPorMay2.Text, 2)
            TxtPreMay2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorMay2_TextChanged(sender As Object, e As EventArgs) Handles TxtPorMay2.TextChanged
        If Not IsNumeric(TxtPorMay2.Text) Then TxtPorMay2.Text = "" : Exit Sub
        If Trim(TxtPorMay2.Text) = "" Then Exit Sub
        Call C1(A2)
    End Sub

    Private Sub TxtPreMay2_Click(sender As Object, e As EventArgs) Handles TxtPreMay2.Click
        TxtPreMay2.SelectionStart = 0
        TxtPreMay2.SelectionLength = Len(TxtPreMay2.Text)
    End Sub

    Private Sub TxtPreMay2_GotFocus(sender As Object, e As EventArgs) Handles TxtPreMay2.GotFocus
        TxtPreMay2.SelectionStart = 0
        TxtPreMay2.SelectionLength = Len(TxtPreMay2.Text)
    End Sub

    Private Sub TxtPreMay2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPreMay2.KeyPress
        If Not IsNumeric(TxtPreMay2.Text) Then TxtPreMay2.Text = "" : Exit Sub
        B2 = 2
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreMay2.Text) = "" Then Exit Sub
            Call T1(B2)
            TxtPreMay2.Text = FormatNumber(TxtPreMay2.Text, 2)
            TxtCantMay3.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreMay2_TextChanged(sender As Object, e As EventArgs) Handles TxtPreMay2.TextChanged
        If Not IsNumeric(TxtPreMay2.Text) Then TxtPreMay2.Text = "" : Exit Sub
        If Trim(TxtPreMay2.Text) = "" Then Exit Sub
        Call T1(B2)
    End Sub

    Private Sub TxtCantMay3_Click(sender As Object, e As EventArgs) Handles TxtCantMay3.Click
        TxtCantMay3.SelectionStart = 0
        TxtCantMay3.SelectionLength = Len(TxtCantMay3.Text)
    End Sub

    Private Sub TxtCantMay3_GotFocus(sender As Object, e As EventArgs) Handles TxtCantMay3.GotFocus
        TxtCantMay3.SelectionStart = 0
        TxtCantMay3.SelectionLength = Len(TxtCantMay3.Text)
    End Sub

    Private Sub TxtCantMay3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantMay3.KeyPress
        If Not IsNumeric(TxtCantMay3.Text) Then TxtCantMay3.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCantMay4.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMay3_LostFocus(sender As Object, e As EventArgs) Handles TxtCantMay3.LostFocus
        If TxtCantMay3.Text = "" Then
            TxtCantMay3.Text = "0"
        End If
    End Sub

    Private Sub txtCantMay4_Click(sender As Object, e As EventArgs) Handles txtCantMay4.Click
        txtCantMay4.SelectionStart = 0
        txtCantMay4.SelectionLength = Len(txtCantMay4.Text)
    End Sub

    Private Sub txtCantMay4_GotFocus(sender As Object, e As EventArgs) Handles txtCantMay4.GotFocus
        txtCantMay4.SelectionStart = 0
        txtCantMay4.SelectionLength = Len(txtCantMay4.Text)
    End Sub

    Private Sub txtCantMay4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantMay4.KeyPress
        If Not IsNumeric(txtCantMay4.Text) Then txtCantMay4.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorMM.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtCantMay4_LostFocus(sender As Object, e As EventArgs) Handles txtCantMay4.LostFocus
        If txtCantMay4.Text = "" Then
            txtCantMay4.Text = "0"
        End If
    End Sub

    Private Sub TxtPorMM2_Click(sender As Object, e As EventArgs) Handles TxtPorMM2.Click
        TxtPorMM2.SelectionStart = 0
        TxtPorMM2.SelectionLength = Len(TxtPorMM2.Text)
    End Sub

    Private Sub TxtPorMM2_GotFocus(sender As Object, e As EventArgs) Handles TxtPorMM2.GotFocus
        TxtPorMM2.SelectionStart = 0
        TxtPorMM2.SelectionLength = Len(TxtPorMM2.Text)
    End Sub

    Private Sub TxtPorMM2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPorMM2.KeyPress
        If Not IsNumeric(TxtPorMM2.Text) Then TxtPorMM2.Text = "" : Exit Sub
        A3 = 3
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorMM2.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A3)
            A3 = 0
            TxtPorMM2.Text = FormatNumber(TxtPorMM2.Text, 2)
            TxtPreMM2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorMM2_TextChanged(sender As Object, e As EventArgs) Handles TxtPorMM2.TextChanged
        If Not IsNumeric(TxtPorMM2.Text) Then TxtPorMM2.Text = "" : Exit Sub
        If Trim(TxtPorMM2.Text) = "" Then Exit Sub
        Call C1(A3)
    End Sub

    Private Sub TxtPreMM2_Click(sender As Object, e As EventArgs) Handles TxtPreMM2.Click
        TxtPreMM2.SelectionStart = 0
        TxtPreMM2.SelectionLength = Len(TxtPreMM2.Text)
    End Sub

    Private Sub TxtPreMM2_GotFocus(sender As Object, e As EventArgs) Handles TxtPreMM2.GotFocus
        TxtPreMM2.SelectionStart = 0
        TxtPreMM2.SelectionLength = Len(TxtPreMM2.Text)
    End Sub

    Private Sub TxtPreMM2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPreMM2.KeyPress
        If Not IsNumeric(TxtPreMM2.Text) Then TxtPreMM2.Text = "" : Exit Sub
        B3 = 3
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreMM2.Text) = "" Then Exit Sub
            Call T1(B3)
            TxtPreMM2.Text = FormatNumber(TxtPreMM2.Text, 2)
            TxtCantMM3.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreMM2_TextChanged(sender As Object, e As EventArgs) Handles TxtPreMM2.TextChanged
        If Not IsNumeric(TxtPreMM2.Text) Then TxtPreMM2.Text = "" : Exit Sub
        If Trim(TxtPreMM2.Text) = "" Then Exit Sub
        Call T1(B3)
    End Sub

    Private Sub TxtCantMM3_Click(sender As Object, e As EventArgs) Handles TxtCantMM3.Click
        TxtCantMM3.SelectionStart = 0
        TxtCantMM3.SelectionLength = Len(TxtCantMM3.Text)
    End Sub

    Private Sub TxtCantMM3_GotFocus(sender As Object, e As EventArgs) Handles TxtCantMM3.GotFocus
        TxtCantMM3.SelectionStart = 0
        TxtCantMM3.SelectionLength = Len(TxtCantMM3.Text)
    End Sub

    Private Sub TxtCantMM3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantMM3.KeyPress
        If Not IsNumeric(TxtCantMM3.Text) Then TxtCantMM3.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtCantMM4.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMM3_LostFocus(sender As Object, e As EventArgs) Handles TxtCantMM3.LostFocus
        If TxtCantMM3.Text = "" Then
            TxtCantMM3.Text = "0"
        End If
    End Sub

    Private Sub TxtCantMM4_Click(sender As Object, e As EventArgs) Handles TxtCantMM4.Click
        TxtCantMM4.SelectionStart = 0
        TxtCantMM4.SelectionLength = Len(TxtCantMM4.Text)
    End Sub

    Private Sub TxtCantMM4_GotFocus(sender As Object, e As EventArgs) Handles TxtCantMM4.GotFocus
        TxtCantMM4.SelectionStart = 0
        TxtCantMM4.SelectionLength = Len(TxtCantMM4.Text)
    End Sub

    Private Sub TxtCantMM4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantMM4.KeyPress
        If Not IsNumeric(TxtCantMM4.Text) Then TxtCantMM4.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorEsp.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantMM4_LostFocus(sender As Object, e As EventArgs) Handles TxtCantMM4.LostFocus
        If TxtCantMM4.Text = "" Then
            TxtCantMM4.Text = "0"
        End If
    End Sub

    Private Sub TxtPorEsp2_Click(sender As Object, e As EventArgs) Handles TxtPorEsp2.Click
        TxtPorEsp2.SelectionStart = 0
        TxtPorEsp2.SelectionLength = Len(TxtPorEsp2.Text)
    End Sub

    Private Sub TxtPorEsp2_GotFocus(sender As Object, e As EventArgs) Handles TxtPorEsp2.GotFocus
        TxtPorEsp2.SelectionStart = 0
        TxtPorEsp2.SelectionLength = Len(TxtPorEsp2.Text)
    End Sub

    Private Sub TxtPorEsp2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPorEsp2.KeyPress
        If Not IsNumeric(TxtPorEsp2.Text) Then TxtPorEsp2.Text = "" : Exit Sub
        A4 = 4
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorEsp2.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A4)
            A4 = 0
            TxtPorEsp2.Text = FormatNumber(TxtPorEsp2.Text, 2)
            TxtPreEsp2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorEsp2_TextChanged(sender As Object, e As EventArgs) Handles TxtPorEsp2.TextChanged
        If Not IsNumeric(TxtPorEsp2.Text) Then TxtPorEsp2.Text = "" : Exit Sub
        If Trim(TxtPorEsp2.Text) Then Exit Sub
        Call C1(A4)
    End Sub

    Private Sub TxtPreEsp2_Click(sender As Object, e As EventArgs) Handles TxtPreEsp2.Click
        TxtPreEsp2.SelectionStart = 0
        TxtPreEsp2.SelectionLength = Len(TxtPreEsp2.Text)
    End Sub

    Private Sub TxtPreEsp2_GotFocus(sender As Object, e As EventArgs) Handles TxtPreEsp2.GotFocus
        TxtPreEsp2.SelectionStart = 0
        TxtPreEsp2.SelectionLength = Len(TxtPreEsp2.Text)
    End Sub

    Private Sub TxtPreEsp2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPreEsp2.KeyPress
        If Not IsNumeric(TxtPreEsp2.Text) Then TxtPreEsp2.Text = "" : Exit Sub
        B4 = 4
        If TxtPCI.Text = "0" Or TxtPCI.Text = "0.00" Or CDec(TxtPCI.Text) = 0 Then
            MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            TxtPCI.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreEsp2.Text) = "" Then Exit Sub
            Call T1(B4)
            B4 = 0
            TxtPreEsp2.Text = FormatNumber(TxtPreEsp2.Text, 2)
            TxtCantEsp3.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreEsp2_LostFocus(sender As Object, e As EventArgs) Handles TxtPreEsp2.LostFocus
        If Not IsNumeric(TxtPreEsp2.Text) Then TxtPreEsp2.Text = "" : Exit Sub
        If Trim(TxtPreEsp2.Text) Then Exit Sub
        Call T1(B4)
    End Sub

    Private Sub TxtCantEsp3_Click(sender As Object, e As EventArgs) Handles TxtCantEsp3.Click
        TxtCantEsp3.SelectionStart = 0
        TxtCantEsp3.SelectionLength = Len(TxtCantEsp3.Text)
    End Sub

    Private Sub TxtCantEsp3_GotFocus(sender As Object, e As EventArgs) Handles TxtCantEsp3.GotFocus
        TxtCantEsp3.SelectionStart = 0
        TxtCantEsp3.SelectionLength = Len(TxtCantEsp3.Text)
    End Sub

    Private Sub TxtCantEsp3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantEsp3.KeyPress
        If Not IsNumeric(TxtCantEsp3.Text) Then TxtCantEsp3.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtCantEsp4.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantEsp3_LostFocus(sender As Object, e As EventArgs) Handles TxtCantEsp3.LostFocus
        If TxtCantEsp3.Text = "" Then
            TxtCantEsp3.Text = "0"
        End If
    End Sub

    Private Sub TxtCantEsp4_Click(sender As Object, e As EventArgs) Handles TxtCantEsp4.Click
        TxtCantEsp4.SelectionStart = 0
        TxtCantEsp4.SelectionLength = Len(TxtCantEsp4.Text)
    End Sub

    Private Sub TxtCantEsp4_GotFocus(sender As Object, e As EventArgs) Handles TxtCantEsp4.GotFocus
        TxtCantEsp4.SelectionStart = 0
        TxtCantEsp4.SelectionLength = Len(TxtCantEsp4.Text)
    End Sub

    Private Sub TxtCantEsp4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantEsp4.KeyPress
        If Not IsNumeric(TxtCantEsp4.Text) Then TxtCantEsp4.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtPorLta.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantEsp4_LostFocus(sender As Object, e As EventArgs) Handles TxtCantEsp4.LostFocus
        If TxtCantEsp4.Text = "" Then
            TxtCantEsp4.Text = "0"
        End If
    End Sub

    Private Sub TxtPorLta2_Click(sender As Object, e As EventArgs) Handles TxtPorLta2.Click
        TxtPorLta2.SelectionStart = 0
        TxtPorLta2.SelectionLength = Len(TxtPorLta2.Text)
    End Sub

    Private Sub TxtPorLta2_GotFocus(sender As Object, e As EventArgs) Handles TxtPorLta2.GotFocus
        TxtPorLta2.SelectionStart = 0
        TxtPorLta2.SelectionLength = Len(TxtPorLta2.Text)
    End Sub

    Private Sub TxtPorLta2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPorLta2.KeyPress
        If Not IsNumeric(TxtPorLta2.Text) Then TxtPorLta2.Text = "" : Exit Sub
        A5 = 5
        If AscW(e.KeyChar) = Keys.Enter Then
            If TxtPorLta2.Text = "" Or TxtPCI.Text = "" Then Exit Sub
            Call C1(A5)
            A5 = 0
            TxtPorLta2.Text = FormatNumber(TxtPorLta2.Text, 2)
            TxtPreLta2.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPorLta2_TextChanged(sender As Object, e As EventArgs) Handles TxtPorLta2.TextChanged
        If Not IsNumeric(TxtPorLta2.Text) Then TxtPorLta2.Text = "" : Exit Sub
        If Trim(TxtPorLta2.Text) = "" Then Exit Sub
        Call C1(A5)
    End Sub

    Private Sub TxtPreLta2_Click(sender As Object, e As EventArgs) Handles TxtPreLta2.Click
        TxtPreLta2.SelectionStart = 0
        TxtPreLta2.SelectionLength = Len(TxtPreLta2.Text)
    End Sub

    Private Sub TxtPreLta2_GotFocus(sender As Object, e As EventArgs) Handles TxtPreLta2.GotFocus
        TxtPreLta2.SelectionStart = 0
        TxtPreLta2.SelectionLength = Len(TxtPreLta2.Text)
    End Sub

    Private Sub TxtPreLta2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPreLta2.KeyPress
        If Not IsNumeric(TxtPreLta2.Text) Then TxtPreLta2.Text = "" : Exit Sub
        B5 = 5
        If TxtPCI.Text = "0" Then
            If TxtPCI.Text = "0.00" Or TxtPCI.Text = "0" Or CDec(TxtPCI.Text) = 0 Then
                MsgBox("El precio de compra con IVA no puede ser cero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                TxtPCI.Focus().Equals(True)
                Exit Sub
            End If
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(TxtPreLta2.Text) = "" Then Exit Sub
            Call T1(B5)
            B5 = 0
            TxtPreLta2.Text = FormatNumber(TxtPreLta2.Text, 2)
            TxtCantLta3.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtPreLta2_TextChanged(sender As Object, e As EventArgs) Handles TxtPreLta2.TextChanged
        If Not IsNumeric(TxtPreLta2.Text) Then TxtPreLta2.Text = "" : Exit Sub
        If Trim(TxtPreLta2.Text) = "" Then Exit Sub
        Call T1(B5)
    End Sub

    Private Sub TxtCantLta3_Click(sender As Object, e As EventArgs) Handles TxtCantLta3.Click
        TxtCantLta3.SelectionStart = 0
        TxtCantLta3.SelectionLength = Len(TxtCantLta3.Text)
    End Sub

    Private Sub TxtCantLta3_GotFocus(sender As Object, e As EventArgs) Handles TxtCantLta3.GotFocus
        TxtCantLta3.SelectionStart = 0
        TxtCantLta3.SelectionLength = Len(TxtCantLta3.Text)
    End Sub

    Private Sub TxtCantLta3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantLta3.KeyPress
        If Not IsNumeric(TxtCantLta3.Text) Then TxtCantLta3.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            TxtCantLta4.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantLta3_LostFocus(sender As Object, e As EventArgs) Handles TxtCantLta3.LostFocus
        If TxtCantLta3.Text = "" Then
            TxtCantLta3.Text = "0"
        End If
    End Sub

    Private Sub TxtCantLta4_Click(sender As Object, e As EventArgs) Handles TxtCantLta4.Click
        TxtCantLta4.SelectionStart = 0
        TxtCantLta4.SelectionLength = Len(TxtCantLta4.Text)
    End Sub

    Private Sub TxtCantLta4_GotFocus(sender As Object, e As EventArgs) Handles TxtCantLta4.GotFocus
        TxtCantLta4.SelectionStart = 0
        TxtCantLta4.SelectionLength = Len(TxtCantLta4.Text)
    End Sub

    Private Sub TxtCantLta4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantLta4.KeyPress
        If Not IsNumeric(TxtCantLta4.Text) Then TxtCantLta4.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub TxtCantLta4_LostFocus(sender As Object, e As EventArgs) Handles TxtCantLta4.LostFocus
        If TxtCantLta4.Text = "" Then
            TxtCantLta4.Text = "0"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            optmone_depto.Visible = True
            optmone_grup.Visible = True
            cbodepto_grupo.Visible = True
            txtporc_mone.Visible = True
            lblporc_mone.Visible = True
            btnmone_guarda.Visible = True
        Else
            optmone_depto.Visible = False
            optmone_grup.Visible = False
            cbodepto_grupo.Visible = False
            txtporc_mone.Visible = False
            lblporc_mone.Visible = False
            btnmone_guarda.Visible = False
        End If
    End Sub

    Private Sub cbodepto_grupo_DropDown(sender As Object, e As EventArgs) Handles cbodepto_grupo.DropDown
        cbodepto_grupo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If optmone_depto.Checked = True Then
                cmd1.CommandText =
                    "select distinct Departamento from Productos order by Departamento"
            End If
            If optmone_grup.Checked = True Then
                cmd1.CommandText =
                    "select distinct Grupo from Productos order by Grupo"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbodepto_grupo.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbodepto_grupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodepto_grupo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtporc_mone.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtporc_mone_Click(sender As Object, e As EventArgs) Handles txtporc_mone.Click
        txtporc_mone.SelectionStart = 0
        txtporc_mone.SelectionLength = Len(txtporc_mone.Text)
    End Sub

    Private Sub txtporc_mone_GotFocus(sender As Object, e As EventArgs) Handles txtporc_mone.GotFocus
        txtporc_mone.SelectionStart = 0
        txtporc_mone.SelectionLength = Len(txtporc_mone.Text)
    End Sub

    Private Sub txtporc_mone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtporc_mone.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnmone_guarda.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnmone_guarda_Click(sender As Object, e As EventArgs) Handles btnmone_guarda.Click
        If CDbl(txtporc_mone.Text) = 0 Then MsgBox("El porcentaje debe de ser mayor a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtporc_mone.Focus().Equals(True) : Exit Sub
        If cbodepto_grupo.Text = "" Then MsgBox("Selecciona un " & IIf(optmone_depto.Checked = True, "departamento", "grupo") & " para guardar el ajuste.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbodepto_grupo.Focus.Equals(True) : Exit Sub
        If MsgBox("¿Deseas asignar el " & txtporc_mone.Text & " porciento de abono por venta en el " & IIf(optmone_depto.Checked = True, "departamento", "grupo") & ": '" & cbodepto_grupo.Text & "'?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If optmone_depto.Checked = True Then
                cmd1.CommandText =
                    "update Productos set Promo_Monedero=" & txtporc_mone.Text & " where Departamento='" & cbodepto_grupo.Text & "'"
            End If
            If optmone_grup.Checked = True Then
                cmd1.CommandText =
                    "update Productos swt Promo_Monedero=" & txtporc_mone.Text & " where Grupo='" & cbodepto_grupo.Text & "'"
            End If
            If cmd1.ExecuteNonQuery Then
                MsgBox("Porcentaje de abono a monedero actualizado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cbodepto_grupo.Text = ""
                txtporc_mone.Text = "0"
                cbodepto_grupo.Focus.Equals(True)
            End If

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class