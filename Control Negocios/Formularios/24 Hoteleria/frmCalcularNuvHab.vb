Public Class frmCalcularNuvHab

    Dim VarMinutos As String = ""
    Dim varHoras As String = ""
    Dim vardias As String = ""
    Dim varhora As Double = 0

    Dim timpo As Date = Nothing
    Dim timpon As String = ""
    Private Sub frmCalcularNuvHab_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Horas,Precio FROM detallehotel WHERE Habitacion='" & lblpc.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    lblHoras.Text = rd2(0).ToString
                    lblPrecio.Text = rd2(1).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "Select * FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    Dim fechaentrada As Date = Nothing
                    fechaentrada = rd1("HorEnt").ToString
                    lblhorini.Text = Format(fechaentrada, "yyyy/MM/dd HH:mm")
                    lblHorFin.Text = Format(Date.Now, "yyyy/MM/dd HH:mm")

                    vardias = DateDiff(DateInterval.Day, CDate(lblHorIni.Text), CDate(lblHorFin.Text))
                    varHoras = DateDiff(DateInterval.Hour, CDate(lblHorIni.Text), CDate(lblHorFin.Text))
                    VarMinutos = DateDiff(DateInterval.Minute, CDate(lblHorIni.Text), CDate(lblHorFin.Text))

                    varhora = VarMinutos / 60
                    lbltiempouso.Text = FormatNumber(varHoras, 2)

                    Dim tiempo As Double = lbltiempouso.Text
                    Dim horas As Double = lblHoras.Text


                    If horas = "24" Then


                        'If VarMinutos > 1140 Then

                        '    timpo = lblHorFin.Text
                        '    timpon = Format(timpo, "HH:mm")

                        '    If timpon >= "12:00" Then
                        '        MsgBox("Tiene que entregar la habitación el huesped")
                        '    End If

                        'End If
                        lblPagar.Text = CDbl(lblPrecio.Text)

                    Else
                        lblPagar.Text = CDbl(lblPrecio.Text)

                        If tiempo >= horas Then
                            MsgBox("El tiempo de renta de la habitación termino.", vbInformation + vbOKOnly, titulohotelriaa)
                        End If
                    End If


                End If
            End If
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnDesocupar_Click(sender As Object, e As EventArgs) Handles btnDesocupar.Click

        Try

            Dim totalpagar As Double = 0
            totalpagar = FormatNumber(lblPagar.Text, 2)

            Dim precioh As Double = 0
            precioh = lblPrecio.Text

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM asigpc WHERE Nombre='" & lblpc.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    Dim hrentrada As Date = Nothing
                    Dim hentradanu As String = ""

                    hrentrada = rd1("HorEnt").ToString
                    hentradanu = Format(hrentrada, "yyyy/MM/dd HH:mm:ss")

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO histasigpc(Nombre,NumHrs,Total,HorEnt,HorSal,Fecha) VALUES('" & lblpc.Text & "'," & lbltiempouso.Text & "," & lblPagar.Text & ",'" & hentradanu & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & Format(Date.Now, "yyyy/MM/dd") & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()


                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "UPDATE comandas SET Cantidad=" & lblHoras.Text & ",Precio=" & lblPrecio.Text & ",Total=" & totalpagar & ",PrecioSinIVA=" & precioh & ",TotalSinIVA=" & totalpagar & ",Hr='',EntregaT='' WHERE Nmesa='" & lblpc.Text & "' AND Comentario='Renta de Habitacion'"
                    cmd3.ExecuteNonQuery()


                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()


                End If
            End If
            rd1.Close()
            cnn1.Close()

            Me.Close()
            frmManejo.primerBoton()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        cnn1.Close()
        End Try

    End Sub
End Class