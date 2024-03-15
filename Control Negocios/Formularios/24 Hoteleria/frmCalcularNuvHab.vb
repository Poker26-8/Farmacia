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

                    If tiempo >= horas Then
                        MsgBox("El tiempo de renta de la habitacion a terminado.", vbInformation + vbOKOnly, titulohotelriaa)
                    Else


                    End If

                    Dim pxh As Double = 0
                    pxh = CDbl(lblPrecio.Text) / CDbl(lblHoras.Text)

                    lblPagar.Text = CDbl(lbltiempouso.Text) * CDbl(pxh)
                    lblPagar.Text = FormatNumber(lblPagar.Text, 2)


                    If VarMinutos > 1140 Then

                        timpo = lblHorFin.Text
                        timpon = Format(timpo, "HH:mm")

                        If timpon >= "12:00" Then
                            MsgBox("Tiene que entregar la avitacion el huesped")
                        End If
                        'agregardia = lblHorIni.Text
                        'agregardia = agregardia.AddDays(1)
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

        timpo = lblHorFin.Text
        timpon = Format(timpon, "HH:mm")



        If lbltiempouso.Text < lblHoras.Text Then
            MsgBox("HAY QUE PAGAR COMPLETO")
        Else
            MsgBox("YA PAGASTE COMPLETO")


        End If

    End Sub
End Class