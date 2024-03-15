Public Class frmCalcularH

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
    Private Sub frmCalcularH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        VarMinutos = "10.00"
        varHoras = "60"

        Dim precioa As Double = 0

        Try
            cnn2.Close() : cnn2.Open()
            cnn1.Close() : cnn1.Open()
            cnn3.Close() : cnn3.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Precio FROM detallehotel WHERE Habitacion='" & lblpc.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    precioa = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TipoCobroBillar'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2(0).ToString = "HORA" Then

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then

                                Dim fechaentrada As Date = Nothing
                                fechaentrada = rd1("HorEnt").ToString
                                txtHorIni.Text = Format(fechaentrada, "yyyy/MM/dd HH:mm")
                                txtHorFin.Text = Format(Date.Now, "HH:mm")
                                txtHorFin.Text = Format(Date.Now, "yyyy/MM/dd HH:mm")

                                vardias = DateDiff(DateInterval.Day, CDate(txtHorIni.Text), CDate(txtHorFin.Text))
                                varHoras = DateDiff(DateInterval.Hour, CDate(txtHorIni.Text), CDate(txtHorFin.Text))
                                VarMinutos = DateDiff(DateInterval.Minute, CDate(txtHorIni.Text), CDate(txtHorFin.Text))

                                varhora = VarMinutos / 60
                                txtTiempoUso.Text = FormatNumber(VarMinutos, 2)
                                txtHoras.Text = FormatNumber(varHoras, 2)


                                If txtTiempoUso.Text <= 1440 Then

                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "SELECT * FROM habitacion WHERE N_Habitacion='" & lblpc.Text & "'"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            txtPrecioHora.Text = FormatNumber(rd3("Precio").ToString, 2)
                                            txtTotalPag.Text = rd3("Precio").ToString * txtTiempoUso.Text
                                            txtTotalPag.Text = txtTotalPag.Text / 1440
                                            txtTotalPag.Text = FormatNumber(txtTotalPag.Text, 2)
                                        End If
                                    End If
                                    rd3.Close()
                                Else
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "SELECT * FROM habitacion WHERE N_Habitacion='" & lblpc.Text & "'"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            txtPrecioHora.Text = FormatNumber(rd3("Precio").ToString, 2)
                                            txtTotalPag.Text = rd3("Precio").ToString * txtTiempoUso.Text
                                            txtTotalPag.Text = txtTotalPag.Text / 1440
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
                                    VarNum = VarNum * 1440 / 1
                                    VarNum = Mid(FormatNumber(VarNum), 1, 2)
                                    txtHoras.Text = entVar & VarNum
                                Else
                                    txtHoras.Text = entVar & strXd
                                End If

                            End If
                        End If
                        rd1.Close()
                        cnn1.Close()
                        cnn3.Close()


                    Else

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                        rd1 = cmd2.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then

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

                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "SELECT * FROM habitacion WHERE N_Habitacion='" & lblpc.Text & "'"
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
                                cnn3.Close()

                            End If
                        End If
                        rd1.Close()
                        cnn1.Close()
                    End If
                End If
            End If
            rd2.Close()
            cnn2.Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnDesocupar_Click(sender As Object, e As EventArgs) Handles btnDesocupar.Click

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM asigpc WHERE Nombre='" & lblpc.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Dim fechasalida As Date = Date.Now
                    Dim fechaentradaentrada As Date = rd1("HorEnt").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO HistAsigPC(Nombre,NumHrs,Total,NumPC,HorEnt,HorSal,Fecha) values('" & rd1("Nombre").ToString & "'," & CDec(txtTiempoUso.Text) & "," & Val(txtPrecioHora.Text) & "," & rd1("NumPC").ToString & ",'" & Format(fechaentradaentrada, "yyyy/MM/dd HH:mm:ss") & "','" & Format(fechasalida, " yyyy/MM/dd HH:mm:ss") & "','" & Format(fechasalida, "yyyy/MM/dd") & "')"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()


                End If
            End If
            rd1.Close()
            cnn1.Close()

            Dim totalpagar As Double = 0
            totalpagar = FormatNumber(txtTotalPag.Text, 2)

            Dim precioh As Double = 0
            precioh = txtPrecioHora.Text

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE Comandas SET Cantidad=" & txtHoras.Text & ",Precio=" & precioh & ",Total=" & totalpagar & ",PrecioSinIVA=" & precioh & ",TotalSinIVA=" & totalpagar & ",Hr='',EntregaT='' WHERE NMESA='" & lblpc.Text & "' AND Comentario='Renta de Habitacion'"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            Me.Close()
            frmPagarH.Controls.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmPagarH.Controls.Clear()
    End Sub
End Class