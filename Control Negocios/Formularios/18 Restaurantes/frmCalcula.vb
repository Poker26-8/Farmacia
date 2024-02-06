Public Class frmCalcula

    Dim VarMinutos As String = ""
    Dim varHoras As String = ""
    Dim vardias As String = ""
    Dim varhora As Double = 0

    Dim xd As String = ""
    Dim xd1 As Integer = 0
    Dim vandXD As Double = 0
    Dim strXd As String = ""
    Dim entVar As String = ""
    Dim VarNum As String = ""

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmCalcula_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        VarMinutos = "10.00"
        varHoras = "60.00"

        Dim ToleBillar As String = ""

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='ToleBillar'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    ToleBillar = rd1(0).ToString
                Else
                    ToleBillar = 0
                End If
            Else
                ToleBillar = 0
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TipoCobroBillar'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = "HORA" Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                Dim fechaentrada As Date = Nothing
                                fechaentrada = rd2("HorEnt").ToString
                                txtHorIni.Text = Format(fechaentrada, "yyyy/MM/dd HH:mm")
                                txtHorFin.Text = Format(Date.Now, "HH:mm")
                                txtHorFin.Text = Format(Date.Now, "yyyy/MM/dd HH:mm")

                                vardias = DateDiff(DateInterval.Day, CDate(txtHorIni.Text), CDate(txtHorFin.Text))
                                varHoras = DateDiff(DateInterval.Hour, CDate(txtHorIni.Text), CDate(txtHorFin.Text))
                                VarMinutos = DateDiff(DateInterval.Minute, CDate(txtHorIni.Text), CDate(txtHorFin.Text))

                                varhora = VarMinutos / 60

                                txtTiempoUso.Text = FormatNumber(VarMinutos, 2)
                                txtHoras.Text = FormatNumber(varHoras, 2)

                                If CDec(txtTiempoUso.Text) <= CDec(ToleBillar) Then

                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & lblpc.Text & "'"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            txtPrecioHora.Text = FormatNumber(rd3("Precio").ToString, 2)
                                            txtTotalPag.Text = "0.00"
                                        End If
                                    End If
                                    rd3.Close()

                                Else
                                    If txtTiempoUso.Text <= 60.0 Then
                                        cmd3 = cnn3.CreateCommand
                                        cmd3.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & lblpc.Text & "'"
                                        rd3 = cmd3.ExecuteReader
                                        If rd3.HasRows Then
                                            If rd3.Read Then
                                                txtPrecioHora.Text = FormatNumber(rd3("Precio").ToString, 2)
                                                txtTotalPag.Text = rd3("Precio").ToString * txtTiempoUso.Text
                                                txtTotalPag.Text = txtTotalPag.Text / 60
                                                txtTotalPag.Text = FormatNumber(txtTotalPag.Text, 2)
                                            End If
                                        End If
                                        rd3.Close()
                                    Else
                                        cmd3 = cnn3.CreateCommand
                                        cmd3.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & lblpc.Text & "'"
                                        rd3 = cmd3.ExecuteReader
                                        If rd3.HasRows Then
                                            If rd3.Read Then
                                                txtPrecioHora.Text = FormatNumber(rd3("Precio").ToString, 2)
                                                txtTotalPag.Text = rd3("Precio").ToString * txtTiempoUso.Text
                                                txtTotalPag.Text = txtTotalPag.Text / 60
                                                txtTotalPag.Text = FormatNumber(txtTotalPag.Text, 2)
                                            End If
                                        End If
                                        rd3.Close()
                                    End If

                                    txtHoras.Text = varhora
                                    txtHoras.Text = FormatNumber(txtHoras.Text, 2)

                                    xd = txtHoras.Text
                                    strXd = ""
                                    entVar = ""
                                    vandXD = 0

                                    For xd1 = 1 To Len(xd)
                                        If vandXD = 1 Then
                                            strXd = strXd & CStr(Mid(xd, xd1, 1))
                                        Else
                                            entVar = entVar & CStr(Mid(xd, xd1, 1))
                                        End If

                                        If CStr(Mid(xd, xd1, 1)) = "." Then
                                            vandXD = 1
                                        End If
                                    Next xd1

                                    If strXd > 60 Then
                                        VarNum = "." & strXd
                                        VarNum = VarNum * 60 / 1
                                        VarNum = Mid(FormatNumber(VarNum), 1, 2)
                                        txtHoras.Text = entVar & VarNum
                                    Else
                                        txtHoras.Text = entVar & strXd
                                    End If

                                End If

                            End If
                        End If
                        rd2.Close()

                    Else

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                Dim fechaentrada As Date = Nothing
                                fechaentrada = rd2("HorEnt").ToString
                                txtHorIni.Text = Format(fechaentrada, "yyyy/MM/dd HH:mm")

                                txtHorFin.Text = Format(Date.Now, "HH:mm")
                                txtHorFin.Text = Format(Date.Now, "yyyy/MM/dd HH:mm")

                                vardias = DateDiff(DateInterval.Day, CDate(txtHorIni.Text), CDate(txtHorFin.Text))
                                varHoras = DateDiff(DateInterval.Hour, CDate(txtHorIni.Text), CDate(txtHorFin.Text)) 'las horas entre las fechas
                                VarMinutos = DateDiff(DateInterval.Minute, CDate(txtHorIni.Text), CDate(txtHorFin.Text)) 'los minutos entre las horas

                                Dim ope1 As Double = CDec(vardias) * 24
                                Dim ope2 As Double = CDec(varHoras) * 60

                                varHoras = varHoras - ope1
                                VarMinutos = VarMinutos - ope2

                                Dim minutosfinal As Double = CDec(ope2 + VarMinutos)

                                txtTiempoUso.Text = FormatNumber(minutosfinal, 2)
                                txtHoras.Text = FormatNumber(varHoras, 2)

                                If CDec(txtTiempoUso.Text) <= CDec(ToleBillar) Then
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & lblpc.Text & "'"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            txtPrecioHora.Text = FormatNumber(rd3("Precio").ToString, 2)
                                            txtTotalPag.Text = "0.00"
                                        End If
                                    End If
                                    rd3.Close()
                                Else
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & lblpc.Text & "'"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then

                                            txtPrecioHora.Text = FormatNumber(rd3("Precio").ToString, 2)
                                            txtTotalPag.Text = rd3("Precio").ToString * txtTiempoUso.Text
                                            txtTotalPag.Text = txtTotalPag.Text / 60
                                            txtTotalPag.Text = FormatNumber(txtTotalPag.Text, 2)
                                            txtHoras.Text = varhora
                                            txtHoras.Text = FormatNumber(txtHoras.Text)

                                            xd = txtHoras.Text
                                            strXd = ""
                                            entVar = ""
                                            vandXD = 0

                                            For xd1 = 1 To Len(xd)
                                                If vandXD = 1 Then
                                                    strXd = strXd & CStr(Mid(xd, xd1, 1))
                                                Else
                                                    entVar = entVar & CStr(Mid(xd, xd1, 1))
                                                End If

                                                If CStr(Mid(xd, xd1, 1)) = "." Then
                                                    vandXD = 1
                                                End If

                                            Next xd1

                                            If strXd > 60 Then
                                                VarNum = "." & strXd
                                                VarNum = VarNum * 60 / 1
                                                VarNum = Mid(FormatNumber(VarNum), 1, 2)
                                                txtHoras.Text = entVar / VarNum
                                            Else
                                                txtHoras.Text = entVar & strXd
                                            End If

                                        End If
                                    End If
                                    rd3.Close()
                                End If

                            End If
                        End If
                        rd2.Close()

                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try

    End Sub

    Private Sub txtPrecioHora_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioHora.KeyDown

        VarMinutos = "10.00"
        If VarMinutos > txtTiempoUso.Text Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "update Precio set Precio=" & Replace(txtPrecioHora.Text, ",", "") & ""
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End If

    End Sub

    Private Sub btnDesocupar_Click(sender As Object, e As EventArgs) Handles btnDesocupar.Click

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Dim fechasalida As Date = Date.Now
                    Dim fechaentradaentrada As Date = rd1("HorEnt").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO HistAsigPC(Nombre,NumHrs,Total,NumPC,HorEnt,HorSal,Fecha) values('" & rd1("Nombre").ToString & "'," & CDec(txtTiempoUso.Text) & "," & Val(txtPrecioHora.Text) & "," & rd1("NumPC").ToString & ",'" & Format(fechaentradaentrada, "yyyy/MM/dd HH:mm:ss") & "','" & Format(fechasalida, " yyyy/MM/dd HH:mm:ss") & "','" & Format(fechasalida, "yyyy/MM/dd") & "')"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Mesa SET Status='Desocupada' WHERE Nombre_mesa='" & lblpc.Text & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()

            Dim totalpagar As Double = 0
            totalpagar = FormatNumber(txtTotalPag.Text, 2)


            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE Comandas SET Cantidad=" & txtHoras.Text & ",Precio=" & txtPrecioHora.Text & ",Total=" & totalpagar & ",PrecioSinIVA=" & txtPrecioHora.Text & ",TotalSinIVA=" & totalpagar & ",Hr='',EntregaT='' WHERE NMESA='" & lblpc.Text & "' AND Comentario='Renta de Mesa' AND Total=0 AND Precio=0"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            If MsgBox("¿Desea Imprimir el Ticket?", vbInformation + vbOKCancel, "Delsscom Solutions® Restuarant") = vbOK Then

                Dim tamimpre As String = ""
                Dim ruta_impresor As String = ""


                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Impresora FROM RutasImpresion WHERE Equipo='" & ObtenerNombreEquipo() & "' AND Tipo='TICKET'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        ruta_impresor = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        tamimpre = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()


                If tamimpre = "80" Then
                    BillarCobro80.DefaultPageSettings.PrinterSettings.PrinterName = ruta_impresor
                    BillarCobro80.Print()
                Else
                    BillarCobro58.DefaultPageSettings.PrinterSettings.PrinterName = ruta_impresor
                    BillarCobro58.Print()
                End If
            End If

            Hide()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try

    End Sub

    Private Sub BillarCobro80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles BillarCobro80.PrintPage

        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim pie1 As String = ""
        Dim pie2 As String = ""
        Dim pie3 As String = ""

        cnn2.Close() : cnn2.Open()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "select * from Ticket"
        rd2 = cmd2.ExecuteReader
        If rd2.Read Then
            For w As Integer = 0 To 6
                Dim dato As String = rd2(w).ToString
                e.Graphics.DrawString(dato, fuente_c, Brushes.Black, 135, Y, centro)
                Y += 13

            Next
            pie1 = rd2(7).ToString
            pie2 = rd2(8).ToString
            pie3 = rd2(9).ToString
        End If
        rd2.Close()
        cnn2.Close()

        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("Fecha: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(Format(Date.Now, "yyyy/MM/dd"), fuente_c, Brushes.Black, 130, Y)
        Y += 20
        e.Graphics.DrawString("Hora de Asignacion: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtHorIni.Text, fuente_c, Brushes.Black, 150, Y)
        Y += 20
        e.Graphics.DrawString("Hora de Terminación:", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtHorFin.Text, fuente_c, Brushes.Black, 270, Y, derecha)
        Y += 20
        e.Graphics.DrawString("Número de Servicio: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(lblpc.Text, fuente_c, Brushes.Black, 150, Y)
        Y += 20
        e.Graphics.DrawString("Tiempo:", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtHoras.Text & " hrs.", fuente_c, Brushes.Black, 70, Y)
        Y += 20
        e.Graphics.DrawString("Precio por Hora: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(txtPrecioHora.Text, 2), fuente_c, Brushes.Black, 120, Y)
        Y += 20
        e.Graphics.DrawString("Total a Pagar: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(txtTotalPag.Text, 2), fuente_c, Brushes.Black, 120, Y)
        e.HasMorePages = False

    End Sub

    Private Sub BillarCobro58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles BillarCobro58.PrintPage
        Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim pie1 As String = ""
        Dim pie2 As String = ""
        Dim pie3 As String = ""

        cnn2.Close() : cnn2.Open()



        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "select * from Ticket"
        rd2 = cmd2.ExecuteReader
        If rd2.Read Then
            For w As Integer = 0 To 6
                Dim dato As String = rd2(w).ToString
                e.Graphics.DrawString(dato, fuente_c, Brushes.Black, 90, Y, centro)
                Y += 12

            Next
            pie1 = rd2(7).ToString
            pie2 = rd2(8).ToString
            pie3 = rd2(9).ToString
        End If
        rd2.Close()
        cnn2.Close()

        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("Fecha: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(Format(Date.Now, "yyyy/MM/dd"), fuente_c, Brushes.Black, 130, Y)
        Y += 20
        e.Graphics.DrawString("Hora de Asignacion: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtHorIni.Text, fuente_c, Brushes.Black, 150, Y)
        Y += 20
        e.Graphics.DrawString("Hora de Terminación:", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtHorFin.Text, fuente_c, Brushes.Black, 270, Y, derecha)
        Y += 20
        e.Graphics.DrawString("Número de Servicio: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(lblpc.Text, fuente_c, Brushes.Black, 150, Y)
        Y += 20
        e.Graphics.DrawString("Tiempo:", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtHoras.Text & " hrs.", fuente_c, Brushes.Black, 70, Y)
        Y += 20
        e.Graphics.DrawString("Precio por Hora: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(txtPrecioHora.Text, 2), fuente_c, Brushes.Black, 120, Y)
        Y += 20
        e.Graphics.DrawString("Total a Pagar: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(txtTotalPag.Text, 2), fuente_c, Brushes.Black, 120, Y)
        e.HasMorePages = False
    End Sub
End Class