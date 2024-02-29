Public Class frmcortemesero
    Private Sub frmcortemesero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbturno.Checked = True
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

                        End If

                    Else

                    End If
                End If




            Else

            End If

            cnn1.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try

    End Sub

    Private Sub PCorte80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCorte80.PrintPage

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

        '[1]. Datos de la venta
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("C O R T E   P O R   M E S E R O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 18
        e.Graphics.DrawString("DEL:" & Format(dtpfecha.Value, "yyyy-MM-dd"), fuente_prods, Brushes.Black, 1, Y)
        Y += 15

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = ""
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then

            End If
        End If

        Dim totalmesero As Double = 0
        Dim formapagos As String = ""
        Dim meseros As String = ""
        Dim TOTAL As Double = 0
        Dim TOTALCUENTAS As Double = 0

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()
        cnn3.Close() : cnn3.Open()
        cnn4.Close() : cnn4.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT DISTINCT Mesero FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "'"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then
                meseros = rd1(0).ToString
                TOTAL = 0
                TOTALCUENTAS = 0

                'PRIMERA PARTE
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 18
                e.Graphics.DrawString("MESERO:" & meseros, fuente_datos, Brushes.Black, 140, Y, sc)
                Y += 15

                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 12
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 25

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = ""
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read

                Loop

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM abonoi WHERE Concepto='ABONO' AND Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' group by formapago order by formapago"
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    If rd2.HasRows Then

                        formapagos = rd2("FormaPago").ToString



                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT sum(Monto) FROM abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' AND Concepto='ABONO' AND FormaPago='" & formapagos & "' group by formapago order by formapago"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                totalmesero = rd3(0).ToString

                                TOTAL = TOTAL + totalmesero

                                e.Graphics.DrawString(formapagos, fuente_datos, Brushes.Black, 10, Y)
                                e.Graphics.DrawString("$ " & totalmesero, fuente_datos, Brushes.Black, 240, Y, sc)
                                Y += 15
                            End If
                        End If
                        rd3.Close()


                    End If
                Loop
                rd2.Close()

                e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 190, Y)
                Y += 6
                e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 190, Y)
                Y += 20


                e.Graphics.DrawString("TOTAL FORMAS PAGO", fuente_prods, Brushes.Black, 10, Y)
                e.Graphics.DrawString("$ " & TOTAL, fuente_prods, Brushes.Black, 240, Y, sc)
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
                cmd4.CommandText = "SELECT * FROM Abonoi WHERE Fecha='" & Format(dtpfecha.Value, "yyyy-MM-dd") & "' AND Mesero='" & meseros & "' AND Concepto='ABONO'"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then

                        SALDO = rd4("Saldo").ToString
                        If SALDO = 0 Then

                            dx = "PAGADO"
                            CUENTAS = rd4("Monto").ToString

                            e.Graphics.DrawString(dx, fuente_datos, Brushes.Black, 10, Y)
                            e.Graphics.DrawString("$ " & CUENTAS, fuente_datos, Brushes.Black, 240, Y, sc)
                            Y += 15
                            TOTALCUENTAS = TOTALCUENTAS + CUENTAS
                        End If

                    End If
                Loop
                rd4.Close()

                e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 190, Y)
                Y += 6
                e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 190, Y)
                Y += 20

                e.Graphics.DrawString("TOTAL CUENTAS", fuente_prods, Brushes.Black, 10, Y)
                e.Graphics.DrawString("$ " & TOTALCUENTAS, fuente_prods, Brushes.Black, 240, Y, sc)
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

    End Sub
End Class