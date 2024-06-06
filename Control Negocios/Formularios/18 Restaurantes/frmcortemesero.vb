Imports System.IO
Public Class frmcortemesero
    Private Sub frmcortemesero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbturno.Checked = True
        dtpht.Text = "00:00:00"
        dtpfhal.Text = "23:59:59"
    End Sub

    Private Sub rbperiodo_Click(sender As Object, e As EventArgs) Handles rbperiodo.Click
        If (rbperiodo.Checked) Then
            pperiodo.Visible = True
            dtpht.Visible = True
        End If
    End Sub

    Private Sub rbturno_Click(sender As Object, e As EventArgs) Handles rbturno.Click
        If (rbturno.Checked) Then
            pperiodo.Visible = False
            dtpht.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cbomesero_DropDown(sender As Object, e As EventArgs) Handles cbomesero.DropDown
        Try
            cbomesero.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Alias FROM usuarios WHERE Alias<>'' AND Puesto='MESERO' ORDER BY Alias"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomesero.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Try


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM comanda1"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("Hay mesas con consumo favor de terminar la venta, para realizar la operación", vbInformation + vbOKOnly, titulorestaurante)
                    Exit Sub
                End If
            End If
            rd1.Close()
            cnn1.Close()
            Dim TAMIMPRE As Integer = 0
            Dim tipopapel As String = ""
            Dim impresora As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    TAMIMPRE = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Formato FROM rutasimpresion WHERE Tipo='Venta' AND Equipo='" & ObtenerNombreEquipo() & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tipopapel = rd1(0).ToString
                End If
            End If
            rd1.Close()

            If tipopapel = "TICKET" Then


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='" & tipopapel & "' AND Equipo='" & ObtenerNombreEquipo() & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        impresora = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                If impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

                If (rbturno.Checked) Then
                    If cbomesero.Text = "" Then

                        If TAMIMPRE = "80" Then
                            PCorte80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PCorte80.Print()
                        End If

                        If TAMIMPRE = "58" Then
                            PCorte58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PCorte58.Print()
                        End If

                    Else

                        If TAMIMPRE = "80" Then
                            PCorteU80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PCorteU80.Print()
                        End If

                        If TAMIMPRE = "58" Then
                            PCorteU58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PCorteU58.Print()
                        End If
                    End If

                End If

                If (rbperiodo.Checked) Then
                    If cbomesero.Text = "" Then

                        If TAMIMPRE = "80" Then
                            pCortePe80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            pCortePe80.Print()
                        End If

                        If TAMIMPRE = "58" Then
                            pCortePe58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            pCortePe58.Print()
                        End If
                    Else
                        If TAMIMPRE = "80" Then
                            PCortePU80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PCortePU80.Print()
                        End If

                        If TAMIMPRE = "58" Then
                            PCortePU58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PCortePU58.Print()
                        End If

                    End If
                End If

                cnn1.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try

    End Sub

    Private Sub PCorte80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCorte80.PrintPage

        Try


            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 250, 150)
                    Y += 120
                End If
            Else
                Y = 20
            End If


            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()


            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Hora:" & Format(Date.Now, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            Dim totalmesero As Double = 0
            Dim formapagos As String = ""
            Dim meseros As String = ""
            Dim TOTAL As Double = 0
            Dim TOTALCUENTAS As Double = 0

            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim IMPUESTO As Double = 0
            Dim DESCUENTO As Double = 0
            Dim PROPINAS As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()
            cnn9.Close() : cnn9.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Mesero FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    meseros = rd1(0).ToString
                    TOTAL = 0
                    TOTALCUENTAS = 0
                    totalventa = 0
                    totalsiva = 0
                    IMPUESTO = 0
                    DESCUENTO = 0
                    PROPINAS = 0

                    'PRIMERA PARTE
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 18
                    e.Graphics.DrawString("MESERO:" & meseros, fuente_datos, Brushes.Black, 140, Y, sc)
                    Y += 25

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO' AND Mesero='" & meseros & "' order by formapago"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then

                            totalventa = totalventa + rd2("Monto").ToString
                            totalsiva = totalventa / 1.16
                            IMPUESTO = totalventa - CDec(totalsiva)

                            DESCUENTO = DESCUENTO + rd2("Descuento").ToString
                            PROPINAS = PROPINAS + rd2("Propina").ToString
                        End If
                    Loop
                    rd2.Close()


                    e.Graphics.DrawString("VENTA BRUTA:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 20
                    e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(DESCUENTO, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VEN ANTES DE IMP: ", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 20
                    e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(IMPUESTO, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(PROPINAS, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("TOTAL VENTA:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(CDbl(totalventa) + CDbl(PROPINAS), 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("FORMAS DE PAGO:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25


                    cmd9 = cnn9.CreateCommand
                    cmd9.CommandText = "SELECT * FROM abonoi WHERE Concepto='ABONO' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' group by formapago order by formapago"
                    rd9 = cmd9.ExecuteReader
                    Do While rd9.Read
                        If rd9.HasRows Then

                            formapagos = rd9("FormaPago").ToString
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT sum(Monto) FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' AND Concepto='ABONO' AND FormaPago='" & formapagos & "' group by formapago order by formapago"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then
                                    totalmesero = rd3(0).ToString

                                    TOTAL = TOTAL + totalmesero

                                    e.Graphics.DrawString(formapagos, fuente_datos, Brushes.Black, 10, Y)
                                    e.Graphics.DrawString("$ " & FormatNumber(totalmesero, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                                    Y += 15
                                End If
                            End If
                            rd3.Close()

                        End If
                    Loop
                    rd9.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL PAGOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTAL, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 25

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("CUENTAS DEL MESERO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25


                    Dim CUENTAS As String = ""
                    Dim SALDO As Double = 0
                    Dim dx As String = ""

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' AND Concepto='ABONO' ORDER BY NumFolio"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then

                            SALDO = rd4("Saldo").ToString
                            If SALDO = 0 Then

                                dx = "PAGADO"
                                CUENTAS = rd4("Monto").ToString

                                e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                                e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                                Y += 15
                                TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                            End If

                        End If
                    Loop
                    rd4.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CUENTAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 240, Y, sf)
                    Y += 25
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
            cnn9.Close()

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
            cnn9.Close()
        End Try
    End Sub

    Private Sub PCorteU80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCorteU80.PrintPage

        Try


            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 250, 150)
                    Y += 120
                End If
            Else
                Y = 30
            End If


            Dim FORMAPAGO As String = ""


            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()
            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            'PRIMERA PARTE
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("MESERO:" & cbomesero.Text, fuente_datos, Brushes.Black, 140, Y, sc)
            Y += 25

            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim descuento As Double = 0
            Dim impuesto As Double = 0
            Dim propina As Double = 0

            Dim TOTALFORMA As Double = 0
            Dim totalsuma As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO' order by mesero"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    totalventa = totalventa + rd1("Monto").ToString
                    totalsiva = totalventa / 1.16
                    impuesto = CDbl(totalventa) - CDbl(totalsiva)
                    propina = propina + rd1("Propina").ToString
                    descuento = descuento + rd1("Descuento").ToString
                End If
            Loop

            e.Graphics.DrawString("VENTA BRUTA", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(descuento, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("VEN ANTES DE IMP:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(impuesto, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(propina, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE VENTAS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(CDbl(totalventa) + CDbl(propina), 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 25

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT FormaPago FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO' group by FormaPago order by FormaPago"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    FORMAPAGO = rd2(0).ToString

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT SUM(Monto) FROM abonoi WHERE Mesero='" & cbomesero.Text & "'  AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO' AND FormaPago='" & FORMAPAGO & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then

                            TOTALFORMA = rd3(0).ToString

                            totalsuma = totalsuma + TOTALFORMA
                            e.Graphics.DrawString(FORMAPAGO, fuente_datos, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(TOTALFORMA, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                            Y += 15
                        End If
                    End If
                    rd3.Close()

                End If
            Loop
            rd2.Close()

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("TOTAL FORMAS PAGO:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalsuma, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 25

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("CUENTAS DEL MESERO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 25

            Dim SALDO As Double = 0
            Dim CUENTAS As Double = 0
            Dim dx As String = ""
            Dim TOTALCUENTAS As Double = 0

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & cbomesero.Text & "' AND Concepto='ABONO'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then

                    SALDO = rd4("Saldo").ToString
                    If SALDO = 0 Then

                        dx = "PAGADO"
                        CUENTAS = rd4("Monto").ToString

                        e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                        e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                        Y += 15
                        TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                    End If

                End If
            Loop
            rd4.Close()

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("TOTAL CUENTAS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 25
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)


            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()

        End Try
    End Sub

    Private Sub pCortePe80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCortePe80.PrintPage
        Try

            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")



            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 250, 150)
                    Y += 120
                End If
            Else
                Y = 20
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()


            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd") & " " & Format(dtpht.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("AL:" & Format(dtpfechaal.Value, "yyyy-MM-dd") & " " & Format(dtpfhal.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            Dim mesero As String = ""
            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim IMPUESTO As Double = 0
            Dim DESCUENTO As Double = 0
            Dim PROPINAS As Double = 0

            Dim formapagos As String = ""
            Dim totalmesero As Double = 0
            Dim TOTAL As Double = 0

            Dim TOTALCUENTAS As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn9.Close() : cnn9.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Mesero FROM abonoi WHERE Fecha between '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora between '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    mesero = rd1(0).ToString

                    TOTAL = 0
                    TOTALCUENTAS = 0
                    totalventa = 0
                    totalsiva = 0
                    IMPUESTO = 0
                    DESCUENTO = 0
                    PROPINAS = 0

                    'PRIMERA PARTE
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 18
                    e.Graphics.DrawString("MESERO:" & mesero, fuente_datos, Brushes.Black, 140, Y, sc)
                    Y += 25

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM abonoi WHERE Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND Mesero='" & mesero & "' order by formapago"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then

                            totalventa = totalventa + rd2("Monto").ToString
                            totalsiva = totalventa / 1.16
                            IMPUESTO = totalventa - CDec(totalsiva)

                            DESCUENTO = DESCUENTO + rd2("Descuento").ToString
                            PROPINAS = PROPINAS + rd2("Propina").ToString
                        End If
                    Loop
                    rd2.Close()

                    e.Graphics.DrawString("VENTA BRUTA:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 20
                    e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(DESCUENTO, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VEN ANTES DE IMP:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 20
                    e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(IMPUESTO, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(PROPINAS, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("TOTAL DE VENTA:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(CDbl(totalventa) + CDbl(PROPINAS), 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25

                    cmd9 = cnn9.CreateCommand
                    cmd9.CommandText = "SELECT * FROM abonoi WHERE Concepto='ABONO' AND Fecha BETWEEN '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Mesero='" & mesero & "' group by formapago order by formapago"
                    rd9 = cmd9.ExecuteReader
                    Do While rd9.Read
                        If rd9.HasRows Then

                            formapagos = rd9("FormaPago").ToString
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT sum(Monto) FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & mesero & "' AND Concepto='ABONO' AND FormaPago='" & formapagos & "' group by formapago order by formapago"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then
                                    totalmesero = rd3(0).ToString

                                    TOTAL = TOTAL + totalmesero

                                    e.Graphics.DrawString(formapagos, fuente_datos, Brushes.Black, 10, Y)
                                    e.Graphics.DrawString("$ " & FormatNumber(totalmesero, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                                    Y += 15
                                End If
                            End If
                            rd3.Close()


                        End If
                    Loop
                    rd9.Close()


                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL FORMAS PAGO:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTAL, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                    Y += 25

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("CUENTAS DEL MESERO:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25

                    Dim CUENTAS As String = ""
                    Dim SALDO As Double = 0
                    Dim dx As String = ""

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha BETWEEN '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Mesero='" & mesero & "' AND Concepto='ABONO'"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then

                            SALDO = rd4("Saldo").ToString
                            If SALDO = 0 Then

                                dx = "PAGADO"
                                CUENTAS = rd4("Monto").ToString

                                e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                                e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                                Y += 15
                                TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                            End If

                        End If
                    Loop
                    rd4.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CUENTAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 240, Y, sf)
                    Y += 25
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn9.Close()
            cnn4.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn9.Close()
            cnn4.Close()
        End Try
    End Sub

    Private Sub PCortePU80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCortePU80.PrintPage
        Try


            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 10, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")



            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 250, 150)
                    Y += 120
                End If
            Else
                Y = 20
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd") & " " & Format(dtpht.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("al:" & Format(dtpfechaal.Value, "yyyy-MM-dd") & " " & Format(dtpfhal.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            'PRIMERA PARTE
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("MESERO:" & cbomesero.Text, fuente_datos, Brushes.Black, 140, Y, sc)
            Y += 25

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim impuesto As Double = 0
            Dim propina As Double = 0
            Dim descuento As Double = 0
            Dim FORMAPAGO As String = ""
            Dim TOTALFORMA As Double = 0
            Dim totalsuma As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' order by mesero"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then


                    totalventa = totalventa + rd1("Monto").ToString
                    totalsiva = totalventa / 1.16
                    impuesto = CDbl(totalventa) - CDbl(totalsiva)
                    propina = propina + rd1("Propina").ToString
                    descuento = descuento + rd1("Descuento").ToString
                End If
            Loop
            rd1.Close()

            e.Graphics.DrawString("VENTA BRUTA", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(descuento, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("VEN ANTES DE IMP:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(impuesto, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(propina, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE VENTAS:", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(CDbl(totalventa) + CDbl(propina), 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 15

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 25

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT FormaPago FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha BETWEEN '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' group by FormaPago order by FormaPago"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    FORMAPAGO = rd2(0).ToString

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT SUM(Monto) FROM abonoi WHERE Mesero='" & cbomesero.Text & "'  AND Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND FormaPago='" & FORMAPAGO & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then

                            TOTALFORMA = rd3(0).ToString

                            totalsuma = totalsuma + TOTALFORMA
                            e.Graphics.DrawString(FORMAPAGO, fuente_datos, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(TOTALFORMA, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                            Y += 15
                        End If
                    End If
                    rd3.Close()

                End If
            Loop
            rd2.Close()

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("TOTAL FORMAS PAGO", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(totalsuma, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 25

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("CUENTAS DEL MESERO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 25

            Dim SALDO As Double = 0
            Dim CUENTAS As Double = 0
            Dim dx As String = ""
            Dim TOTALCUENTAS As Double = 0

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora between '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Mesero='" & cbomesero.Text & "' AND Concepto='ABONO'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then

                    SALDO = rd4("Saldo").ToString
                    If SALDO = 0 Then

                        dx = "PAGADO"
                        CUENTAS = rd4("Monto").ToString

                        e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                        e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 270, Y, sf)
                        Y += 15
                        TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                    End If

                End If
            Loop
            rd4.Close()

            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 6
            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 270, Y, sf)
            Y += 20

            e.Graphics.DrawString("TOTAL CUENTAS", fuente_prods, Brushes.Black, 10, Y)
            e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 20
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try

    End Sub

    Private Sub PCorte58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCorte58.PrintPage

        Try


            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 8, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 5
            End If


            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()


            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15


            Dim totalmesero As Double = 0
            Dim formapagos As String = ""
            Dim meseros As String = ""
            Dim TOTAL As Double = 0
            Dim TOTALCUENTAS As Double = 0

            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim IMPUESTO As Double = 0
            Dim DESCUENTO As Double = 0
            Dim PROPINAS As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()
            cnn9.Close() : cnn9.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Mesero FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    meseros = rd1(0).ToString
                    TOTAL = 0
                    TOTALCUENTAS = 0
                    totalventa = 0
                    totalsiva = 0
                    IMPUESTO = 0
                    DESCUENTO = 0
                    PROPINAS = 0

                    'PRIMERA PARTE
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 18
                    e.Graphics.DrawString("MESERO:" & meseros, fuente_datos, Brushes.Black, 90, Y, sc)
                    Y += 25

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO' AND Mesero='" & meseros & "' order by formapago"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then

                            totalventa = totalventa + rd2("Monto").ToString
                            totalsiva = totalventa / 1.16
                            IMPUESTO = totalventa - CDec(totalsiva)

                            DESCUENTO = DESCUENTO + rd2("Descuento").ToString
                            PROPINAS = PROPINAS + rd2("Propina").ToString
                        End If
                    Loop
                    rd2.Close()

                    e.Graphics.DrawString("VENTA BRUTA:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 20
                    e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(DESCUENTO, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    'e.Graphics.DrawString("VEN ANTES DE IMP:", fuente_prods, Brushes.Black, 10, Y)
                    'e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    'Y += 20
                    'e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
                    'e.Graphics.DrawString("$ " & FormatNumber(IMPUESTO, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    'Y += 15

                    'e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    'Y += 6
                    'e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    'Y += 20

                    e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(PROPINAS, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("TOTAL VENTAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(CDbl(totalventa) + CDbl(PROPINAS), 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25


                    cmd9 = cnn9.CreateCommand
                    cmd9.CommandText = "SELECT * FROM abonoi WHERE Concepto='ABONO' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' group by formapago order by formapago"
                    rd9 = cmd9.ExecuteReader
                    Do While rd9.Read
                        If rd9.HasRows Then

                            formapagos = rd9("FormaPago").ToString
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT sum(Monto) FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' AND Concepto='ABONO' AND FormaPago='" & formapagos & "' group by formapago order by formapago"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then
                                    totalmesero = rd3(0).ToString

                                    TOTAL = TOTAL + totalmesero

                                    e.Graphics.DrawString(formapagos, fuente_datos, Brushes.Black, 10, Y)
                                    e.Graphics.DrawString("$ " & FormatNumber(totalmesero, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                    Y += 15
                                End If
                            End If
                            rd3.Close()

                        End If
                    Loop
                    rd9.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL FORMAS PAGO", fuente_prods, Brushes.Black, 8, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTAL, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 25

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("CUENTAS DEL MESERO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25


                    Dim CUENTAS As String = ""
                    Dim SALDO As Double = 0
                    Dim dx As String = ""

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' AND Concepto='ABONO'"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then

                            SALDO = rd4("Saldo").ToString
                            If SALDO = 0 Then

                                dx = "PAGADO"
                                CUENTAS = rd4("Monto").ToString

                                e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                                e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                Y += 15
                                TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                            End If

                        End If
                    Loop
                    rd4.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 150, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 150, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CUENTAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 25
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
            cnn9.Close()

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
            cnn9.Close()
        End Try

    End Sub

    Private Sub PCorteU58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCorteU58.PrintPage

        Try
            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 8, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 10
            End If


            Dim FORMAPAGO As String = ""


            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()
            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            'PRIMERA PARTE
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("MESERO:" & cbomesero.Text, fuente_datos, Brushes.Black, 90, Y, sc)
            Y += 25

            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim descuento As Double = 0
            Dim impuesto As Double = 0
            Dim propina As Double = 0

            Dim TOTALFORMA As Double = 0
            Dim totalsuma As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO'  group by Mesero order by mesero"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    totalventa = totalventa + rd1("Monto").ToString
                    totalsiva = totalventa / 1.16
                    impuesto = CDbl(totalventa) - CDbl(totalsiva)
                    propina = propina + rd1("Propina").ToString
                    descuento = descuento + rd1("Descuento").ToString

                    e.Graphics.DrawString("VENTA BRUTA", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(descuento, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VEN ANTES DE IMP:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15
                    e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(impuesto, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15
                    e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(propina, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15


                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("FORMAS DE PAGO:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT DISTINCT FormaPago FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO' group by FormaPago order by FormaPago"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then
                            FORMAPAGO = rd2(0).ToString

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT SUM(Monto) FROM abonoi WHERE Mesero='" & cbomesero.Text & "'  AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Concepto='ABONO' AND FormaPago='" & FORMAPAGO & "'"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then

                                    TOTALFORMA = rd3(0).ToString

                                    totalsuma = totalsuma + TOTALFORMA
                                    e.Graphics.DrawString(FORMAPAGO, fuente_datos, Brushes.Black, 10, Y)
                                    e.Graphics.DrawString("$ " & FormatNumber(TOTALFORMA, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                    Y += 15
                                End If
                            End If
                            rd3.Close()

                        End If
                    Loop
                    rd2.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL FORMAS PAGO:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsuma, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 25

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("CUENTAS DEL MESERO:", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25

                    Dim SALDO As Double = 0
                    Dim CUENTAS As Double = 0
                    Dim dx As String = ""
                    Dim TOTALCUENTAS As Double = 0

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & cbomesero.Text & "' AND Concepto='ABONO'"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then

                            SALDO = rd4("Saldo").ToString
                            If SALDO = 0 Then

                                dx = "PAGADO"
                                CUENTAS = rd4("Monto").ToString

                                e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                                e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                Y += 15
                                TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                            End If

                        End If
                    Loop
                    rd4.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CUENTAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 25
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()

        End Try

    End Sub

    Private Sub pCortePe58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCortePe58.PrintPage

        Try

            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 8, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")



            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 20
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()


            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd") & " " & Format(dtpht.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("AL:" & Format(dtpfechaal.Value, "yyyy-MM-dd") & " " & Format(dtpfhal.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            Dim mesero As String = ""
            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim IMPUESTO As Double = 0
            Dim DESCUENTO As Double = 0
            Dim PROPINAS As Double = 0

            Dim formapagos As String = ""
            Dim totalmesero As Double = 0
            Dim TOTAL As Double = 0

            Dim TOTALCUENTAS As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn9.Close() : cnn9.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Mesero FROM abonoi WHERE Fecha between '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora between '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    mesero = rd1(0).ToString

                    TOTAL = 0
                    TOTALCUENTAS = 0
                    totalventa = 0
                    totalsiva = 0
                    IMPUESTO = 0
                    DESCUENTO = 0
                    PROPINAS = 0

                    'PRIMERA PARTE
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 18
                    e.Graphics.DrawString("MESERO:" & mesero, fuente_datos, Brushes.Black, 90, Y, sc)
                    Y += 25

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM abonoi WHERE Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND Mesero='" & mesero & "' group by formapago order by formapago"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                            totalventa = totalventa + rd2("Monto").ToString
                            totalsiva = totalventa / 1.16
                            IMPUESTO = totalventa - CDec(totalsiva)

                            DESCUENTO = DESCUENTO + rd2("Descuento").ToString
                            PROPINAS = PROPINAS + rd2("Propina").ToString

                            e.Graphics.DrawString("VENTA BRUTA:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 20
                            e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(DESCUENTO, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 15

                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 6
                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 20

                            e.Graphics.DrawString("VEN ANTES DE IMP:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 20
                            e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(IMPUESTO, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 15

                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 6
                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 20

                            e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 15

                            e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(PROPINAS, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 15


                            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 15
                            e.Graphics.DrawString("FORMAS DE PAGO:", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                            Y += 12
                            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 25

                            cmd9 = cnn9.CreateCommand
                            cmd9.CommandText = "SELECT * FROM abonoi WHERE Concepto='ABONO' AND Fecha BETWEEN '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Mesero='" & mesero & "' group by formapago order by formapago"
                            rd9 = cmd9.ExecuteReader
                            Do While rd9.Read
                                If rd9.HasRows Then

                                    formapagos = rd9("FormaPago").ToString
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "SELECT sum(Monto) FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & mesero & "' AND Concepto='ABONO' AND FormaPago='" & formapagos & "' group by formapago order by formapago"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            totalmesero = rd3(0).ToString

                                            TOTAL = TOTAL + totalmesero

                                            e.Graphics.DrawString(formapagos, fuente_datos, Brushes.Black, 10, Y)
                                            e.Graphics.DrawString("$ " & FormatNumber(totalmesero, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                            Y += 15
                                        End If
                                    End If
                                    rd3.Close()


                                End If
                            Loop
                            rd9.Close()


                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 6
                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 20

                            e.Graphics.DrawString("TOTAL FORMAS PAGO:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(TOTAL, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 25

                            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 15
                            e.Graphics.DrawString("CUENTAS DEL MESERO:", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                            Y += 12
                            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 25

                            Dim CUENTAS As String = ""
                            Dim SALDO As Double = 0
                            Dim dx As String = ""

                            cmd4 = cnn4.CreateCommand
                            cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha BETWEEN '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Mesero='" & mesero & "' AND Concepto='ABONO'"
                            rd4 = cmd4.ExecuteReader
                            Do While rd4.Read
                                If rd4.HasRows Then

                                    SALDO = rd4("Saldo").ToString
                                    If SALDO = 0 Then

                                        dx = "PAGADO"
                                        CUENTAS = rd4("Monto").ToString

                                        e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                                        e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                        Y += 15
                                        TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                                    End If

                                End If
                            Loop
                            rd4.Close()

                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 6
                            e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 20

                            e.Graphics.DrawString("TOTAL CUENTAS:", fuente_prods, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                            Y += 25
                            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

                        End If
                    End If
                    rd2.Close()



                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn9.Close()
            cnn4.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn9.Close()
            cnn4.Close()
        End Try

    End Sub

    Private Sub PCortePU58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCortePU58.PrintPage
        Try


            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Bold)
            Dim fuente_prods As New Drawing.Font(tipografia, 8, FontStyle.Regular)
            Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")



            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 20
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 18
            e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd") & " " & Format(dtpht.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("al:" & Format(dtpfechaal.Value, "yyyy-MM-dd") & " " & Format(dtpfhal.Value, "HH:mm:ss"), fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            'PRIMERA PARTE
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("MESERO:" & cbomesero.Text, fuente_datos, Brushes.Black, 90, Y, sc)
            Y += 25

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            Dim totalventa As Double = 0
            Dim totalsiva As Double = 0
            Dim impuesto As Double = 0
            Dim propina As Double = 0
            Dim descuento As Double = 0
            Dim FORMAPAGO As String = ""
            Dim TOTALFORMA As Double = 0
            Dim totalsuma As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO'  group by Mesero order by mesero"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    totalventa = totalventa + rd1("Monto").ToString
                    totalsiva = totalventa / 1.16
                    impuesto = CDbl(totalventa) - CDbl(totalsiva)
                    propina = propina + rd1("Propina").ToString
                    descuento = descuento + rd1("Descuento").ToString

                    e.Graphics.DrawString("VENTA BRUTA", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("DESCUENTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(descuento, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VEN ANTES DE IMP:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsiva, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15
                    e.Graphics.DrawString("IMPUESTOS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(impuesto, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("VENTA TOTAL:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalventa, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15
                    e.Graphics.DrawString("PROPINAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(propina, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 15


                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("FORMAS DE PAGO:", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT DISTINCT FormaPago FROM abonoi WHERE Mesero='" & cbomesero.Text & "' AND Fecha BETWEEN '" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' group by FormaPago order by FormaPago"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then

                            FORMAPAGO = rd2(0).ToString

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT SUM(Monto) FROM abonoi WHERE Mesero='" & cbomesero.Text & "'  AND Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND FormaPago='" & FORMAPAGO & "'"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then

                                    TOTALFORMA = rd3(0).ToString

                                    totalsuma = totalsuma + TOTALFORMA
                                    e.Graphics.DrawString(FORMAPAGO, fuente_datos, Brushes.Black, 10, Y)
                                    e.Graphics.DrawString("$ " & FormatNumber(TOTALFORMA, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                    Y += 15
                                End If
                            End If
                            rd3.Close()

                        End If
                    Loop
                    rd2.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL FORMAS PAGO:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(totalsuma, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 25

                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawString("CUENTAS DEL MESERO:", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 12
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 25

                    Dim SALDO As Double = 0
                    Dim CUENTAS As Double = 0
                    Dim dx As String = ""
                    Dim TOTALCUENTAS As Double = 0

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha BETWEEN'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpfechaal.Value, "yyyy-MM-dd") & "' AND Hora between '" & Format(dtpht.Value, "HH:mm:ss") & "' AND '" & Format(dtpfhal.Value, "HH:mm:ss") & "' AND Mesero='" & cbomesero.Text & "' AND Concepto='ABONO'"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then

                            SALDO = rd4("Saldo").ToString
                            If SALDO = 0 Then

                                dx = "PAGADO"
                                CUENTAS = rd4("Monto").ToString

                                e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                                e.Graphics.DrawString("$ " & FormatNumber(CUENTAS, 2), fuente_datos, Brushes.Black, 180, Y, sf)
                                Y += 15
                                TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                            End If

                        End If
                    Loop
                    rd4.Close()

                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 6
                    e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CUENTAS:", fuente_prods, Brushes.Black, 10, Y)
                    e.Graphics.DrawString("$ " & FormatNumber(TOTALCUENTAS, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 20
                    e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

                End If
            Loop

            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try
    End Sub
End Class