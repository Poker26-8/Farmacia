Imports iTextSharp.text.pdf

Public Class FfmConsultaCorte
    Public VentasC, DevolucionesC, ServiciosC, RecargasC, TotalContado, VentasCre, AbonosCre, DevolucionesCre, TotalCredito, TotalGeneral, Ingresos, SaldoInicial, Retiros, DevolucionesT, SumaIngresos, SumaCajero, SumaDiferencia, TotalIngresos, TotalCajero, TotalDiferencia, IngresosF, DevolucionesF, SumaIngresosF, SumaCajeroF, SumaDiferenciaF, TotalIngresosF, TotalCajeroF, TotalDiferenciaF, TotalCancelaciones, ComprasCanceladas, Compras As Double
    Public fechainicio, fechafinal, fechacorte As Date
    Dim cajero, atiende As String
    Public Sub GeneraBarras(ByVal pic As PictureBox, ByVal codigo As String)
        Dim barcod As New Barcode128

        barcod.BarHeight = 200
        barcod.Code = codigo
        barcod.GenerateChecksum = True
        barcod.CodeType = Barcode.CODE128

        Try
            Dim bmp As New Bitmap(barcod.CreateDrawingImage(Color.Black, Color.White))
            Dim img As Image = New Bitmap(bmp.Width, bmp.Height)
            Dim grf As Graphics = Graphics.FromImage(img)

            grf.FillRectangle(New SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height)
            grf.DrawImage(bmp, 0, 0)
            pic.Image = img
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub PCierre80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCierre80.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_prods2 As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim otraY As Integer = 0


        e.Graphics.DrawString("Nombre de la farmacia", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString(farmaciaseleccionada, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 12

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
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
                Y += 6
            End If
        Else
            Y += 0
        End If
        rd1.Close() : cnn1.Close()

        e.Graphics.DrawString("Atiende: " & atiende, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 12
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 7
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("** CORTE DE CAJA **", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 20

        e.Graphics.DrawString("FOLIO: " & txtCodigo.Text, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA:" & Format(fechacorte, "yyyy/MM/dd HH:mm:ss"), New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA CORTE INICIAl:" & Format(fechainicio, "yyyy/MM/dd HH:mm:ss"), New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA CORTE FINAL:" & Format(fechafinal, "yyyy/MM/dd HH:mm:ss"), New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("CAJERO: " & cajero, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 12
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("VENTAS DE CONTADO: ", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ventas:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(FormatNumber(VentasC, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & FormatNumber(DevolucionesC, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Servicios:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(FormatNumber(ServiciosC, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Venta de tiempo aire:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(FormatNumber(RecargasC, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL CONTADO:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(FormatNumber(TotalContado, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 20

        e.Graphics.DrawString("VENTAS DE CREDITO: ", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ventas:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(FormatNumber(VentasCre, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Abonos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & FormatNumber(AbonosCre, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & FormatNumber(DevolucionesCre, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL CREDITO:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(FormatNumber(TotalCredito, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL GENERAL:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(TotalGeneral, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 13
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("SISTEMA", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString("CAJERO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 190, Y)
        e.Graphics.DrawString("DIF", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("EFECTIVO/PESOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ingresos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(FormatNumber(Ingresos, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Saldo Inicial:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(FormatNumber(SaldoInicial, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Retiros:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & FormatNumber(Retiros, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & FormatNumber(DevolucionesT, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Cancelaciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & FormatNumber(TotalCancelaciones, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Compras:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & FormatNumber(Compras, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Compras Canceladas:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(FormatNumber(ComprasCanceladas, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 175, Y)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString(FormatNumber(SumaIngresos, 2), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(FormatNumber(SumaCajero, 2), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(FormatNumber(SumaDiferencia, 2), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("TOTAL EFECTIVO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(TotalIngresos, 2), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(FormatNumber(TotalCajero, 2), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(FormatNumber(TotalDiferencia, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 13
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15

        e.Graphics.DrawString("DOCUMENTOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 190, Y, sc)
        Y += 15
        e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ingresos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(" " & FormatNumber(IngresosF, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & FormatNumber(DevolucionesF, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString(FormatNumber(SumaIngresosF, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(FormatNumber(SumaCajeroF, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(FormatNumber(SumaDiferenciaF, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("TOTAL DOCUMENTOS", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(TotalIngresosF, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(FormatNumber(TotalCajeroF, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(FormatNumber(TotalDiferenciaF, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 30
        otraY = Y


        GeneraBarras(PictureBox1, txtCodigo.Text)
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        e.Graphics.DrawImage(bm, 40, otraY, 210, 40)
        Y += 45
        e.Graphics.DrawString(txtCodigo.Text, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 100
        e.Graphics.DrawString("--------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString("Cajero", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
    End Sub

    Private Sub FfmConsultaCorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Focus.Equals(True)
    End Sub

    Private Sub FfmConsultaCorte_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtCodigo.Focus.Equals(True)
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from corteusuariofar where FOlio='" & txtCodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If MsgBox("¿Deseas reimprimir el corte del folio ingresado?", vbQuestion + vbOKCancel, "Delsscom Farmacias") = vbCancel Then
                        Exit Sub
                    End If
                    If rd1.Read Then
                        VentasC = rd1("VentasC").ToString
                        DevolucionesC = rd1("DevolucionesC").ToString
                        ServiciosC = rd1("ServiciosC").ToString
                        RecargasC = rd1("RecargasC").ToString
                        TotalContado = rd1("TotalContado").ToString
                        VentasCre = rd1("VentasCre").ToString
                        AbonosCre = rd1("AbonosCre").ToString
                        DevolucionesCre = rd1("DevolucionesCre").ToString
                        TotalCredito = rd1("TotalCredito").ToString
                        TotalGeneral = rd1("TotalGeneral").ToString
                        Ingresos = rd1("Ingresos").ToString
                        SaldoInicial = rd1("SaldoInicial").ToString
                        Retiros = rd1("Retiros").ToString
                        DevolucionesT = rd1("DevolucionesT").ToString
                        SumaIngresos = rd1("SumaIngresos").ToString
                        SumaCajero = rd1("SumaCajero").ToString
                        SumaDiferencia = rd1("SumaDiferencia").ToString
                        TotalIngresos = rd1("TotalIngresos").ToString
                        TotalCajero = rd1("TotalCajero").ToString
                        TotalDiferencia = rd1("TotalDiferencia").ToString
                        IngresosF = rd1("IngresosF").ToString
                        DevolucionesF = rd1("DevolucionesF").ToString
                        SumaIngresosF = rd1("SumaIngresosF").ToString
                        SumaCajeroF = rd1("SumaCajeroF").ToString
                        SumaDiferenciaF = rd1("SumaDiferenciaF").ToString
                        TotalIngresosF = rd1("TotalIngresosF").ToString
                        TotalCajeroF = rd1("TotalCajeroF").ToString
                        TotalDiferenciaF = rd1("TotalDiferenciaF").ToString
                        fechacorte = rd1("FCorte").ToString
                        cajero = rd1("Cajero").ToString
                        atiende = rd1("Usuario").ToString
                        fechainicio = rd1("FInicial").ToString
                        fechafinal = rd1("FFinal").ToString
                        TotalCancelaciones = rd1("TotalCancelaciones").ToString
                        ComprasCanceladas = rd1("ComprasCanceladas").ToString
                        Compras = rd1("Compras").ToString


                        Dim impre As Integer = TamImpre()
                        Dim impresora As String = ImpresoraImprimir()
                        If impre = "80" Then
                            PCierre80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PCierre80.Print()
                        End If
                    End If
                Else
                    MsgBox("Corte no registrado" & vbCrLf & "Verifica el Folio ingresado", vbCritical + vbOKOnly, "Delsscom Farmacias")
                    txtCodigo.Text = ""
                    txtCodigo.Focus.Equals(True)
                    My.Application.DoEvents()
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
                txtCodigo.Text = ""
                txtCodigo.Focus.Equals(True)
                My.Application.DoEvents()
                PictureBox1.Image = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class