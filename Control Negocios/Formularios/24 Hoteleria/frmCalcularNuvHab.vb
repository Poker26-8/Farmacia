Public Class frmCalcularNuvHab

    Dim VarMinutos As String = ""
    Dim varHoras As String = ""
    Dim vardias As String = ""
    Dim varhora As Double = 0

    Dim timpo As Date = Nothing
    Dim timpon As String = ""
    Private Sub frmCalcularNuvHab_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ToleHab As String = ""
        Dim salidahotel As DateTime = Nothing
        Dim salidahotel2 As String = ""
        Dim precioaumento As Double = 0
        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='SalidaHab'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    salidahotel = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
                    salidahotel2 = Format(salidahotel, "HH:mm")
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='PrecioDia'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    precioaumento = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NumPart FROM formatos WHERE Facturas='ToleHabi'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    ToleHab = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Horas,Precio FROM detallehotel WHERE Habitacion='" & lblpc.Text & "' AND Status='PAGADO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    lblHoras.Text = rd2(0).ToString
                    lblPrecio.Text = rd2(1).ToString
                    lblAnticipo.Text = rd2(1).ToString
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


                    Dim fechasalida As DateTime = fechaentrada.AddHours(horas)

                    If ToleHab > 0 Then
                        Dim fechatolerancia As DateTime = fechasalida.AddMinutes(ToleHab)
                        lblsalida.Text = Format(fechatolerancia, "yyyy/MM/dd HH:mm")
                    Else
                        lblsalida.Text = Format(fechasalida, "yyyy/MM/dd HH:mm")
                    End If

                    If horas = "24" Then

                        If salidahotel2 <> "" Then
                            lblsalida.Text = ""
                            Dim fechasalidadia As DateTime = fechaentrada.AddHours(horas)
                            Dim fechasalidactole As DateTime = salidahotel.AddMinutes(ToleHab)
                            Dim TIEMPOSALIDA As String = Format(fechasalidactole, "HH:mm")
                            Dim fechasalidadia2 As String = Format(fechasalidadia, "yyyy/MM/dd")
                            lblsalida.Text = fechasalidadia2 & " " & TIEMPOSALIDA

                            Dim fechSalida As DateTime = DateTime.ParseExact(lblsalida.Text, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)
                            Dim fechEntrada As DateTime = DateTime.ParseExact(lblHorFin.Text, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)

                            If fechEntrada > fechSalida Then
                                MsgBox("se acabo el tiempó")
                                lblPagar.Text = CDbl(precioaumento * vardias) - CDbl(lblAnticipo.Text)
                            Else
                                lblPagar.Text = CDbl(lblPrecio.Text) - CDbl(lblAnticipo.Text)
                            End If

                        End If

                    Else
                        If lblHorFin.Text >= lblsalida.Text Then
                            MsgBox("El tiempo de renta de la habitación termino.", vbInformation + vbOKOnly, titulohotelriaa)
                            lblPagar.Text = CDbl(lblPrecio.Text)
                            ' lblPagar.Text = lblPagar.Text + CDbl(precioaumento)
                            lblPagar.Text = CDbl(precioaumento) - CDbl(lblAnticipo.Text)
                        Else
                            lblPagar.Text = CDbl(lblPrecio.Text) - CDbl(lblAnticipo.Text)
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

            If MsgBox("¿Se desocupara la habitación, Esta en lo corerecto?", vbInformation + vbYesNo) = vbNo Then
                Exit Sub
            End If
            Dim FOLIOCOMANDA As Integer = 0

            Dim totalpagar As Double = 0
            totalpagar = FormatNumber(lblPagar.Text, 2)

            Dim precioh As Double = 0
            precioh = lblPrecio.Text

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT MAX(Id) FROM comanda1"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    FOLIOCOMANDA = rd2(0).ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()

            cnn1.Close() : cnn1.Open()

            If lblPagar.Text > 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM comandas WHERE NMesa='" & lblpc.Text & "' AND Codigo='xc3'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                    End If
                Else
                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "INSERT INTO comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVR,CostVP,CostVUE,Descuento,Precio,Total,PrecioSinIva,TotalSinIVA,Comisionista,Fecha,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Depto,Grupo,EstatusT,Hr,EntregaT) VALUES(" & FOLIOCOMANDA & ",'" & lblpc.Text & "','xc3','Tiempo Habitacion',1,'SER',0,0,0,0," & lblPrecio.Text & "," & totalpagar & "," & lblPrecio.Text & "," & totalpagar & ",'0','" & Format(Date.Now, "yyyy/MM/dd") & "',0,'RESTA','Renta de Habitacion','','',0,'HABITACION','HABITACION',0,'" & HrTiempo & "','" & HrEntrega & "')"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM AsigPC WHERE Nombre='" & lblpc.Text & "'"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM detallehotel WHERE Habitacion='" & lblpc.Text & "'"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & lblpc.Text & "'"
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()
                End If
                rd1.Close()
                cnn1.Close()
            Else

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

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "DELETE FROM detallehotel WHERE Habitacion='" & lblpc.Text & "'"
                        cmd3.ExecuteNonQuery()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & lblpc.Text & "'"
                        cmd3.ExecuteNonQuery()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "UPDATE Habitacion SET Estado='Desocupada' WHERE N_Habitacion='" & lblpc.Text & "'"
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()
                    End If
                End If
                rd1.Close()
                cnn1.Close()


            End If




            Me.Close()
            frmManejo.primerBoton()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        cnn1.Close()
        End Try

    End Sub
End Class