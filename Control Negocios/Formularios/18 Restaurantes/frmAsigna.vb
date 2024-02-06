Public Class frmAsigna
    Dim CFOLIO As Integer = 0
    Dim minutosTiempo As Double = 0
    Public nombrepc As String = ""
    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmAsigna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtHora.Text = Format(Date.Now, "HH:mm:ss")
        nombrepc = ObtenerNombreEquipo()
    End Sub

    Private Sub btnIniciarTiempo_Click(sender As Object, e As EventArgs)

        If frmMesas.txtUsuario.Text = "" Then
            MsgBox("Falta clave de Usuario", vbInformation + vbOKOnly, titulomensajes)
            Me.Close()
            frmMesas.txtUsuario.Focus.Equals(True)
        End If

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO AsigPC(Nombre,HorEnt,HorSal,Fecha,Ocupada) values('" & lblpc.Text & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','" & Format(Date.Now, "yyyy-MM-dd") & "',1)"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE Mesa SET Status='Ocupada' WHERE Nombre_mesa='" & lblpc.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO Comanda1(IdCliente,Direccion,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Nombre,TComensales) VALUES(0,'','','','','','','','','" & lblpc.Text & "',0)"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT MAX(Folio) FROM Comanda1"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    CFOLIO = rd2(0).ToString
                Else
                    CFOLIO = 0
                End If
            Else
                CFOLIO = 0
            End If
            rd2.Close()

            If minutosTiempo = 0 Then
                HrTiempo = Format(Date.Now, "HH:mm:ss")
                HrEntrega = Format(Date.Now, "HH:mm:ss")
            ElseIf minutosTiempo > 0 Then
                HrTiempo = Format(Date.Now, "HH:mm:ss")
                'HrEntrega = Format(DateAdd("n", minutosTiempo, Date.Now), "HH:mm:ss")
            End If

            Dim MyPreciosin As Double = 0
            Dim MyTotalSin As Double = 0
            Dim MyComen As String = ""

            MyPreciosin = 0
            MyPreciosin = 0 - MyPreciosin
            MyTotalSin = FormatNumber(MyPreciosin, 2)
            MyComen = frmMesas.lblusuario.Text

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "insert into Comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Depto,Grupo,EstatusT,Hr,EntregaT) values(" & CFOLIO & ",'" & lblpc.Text & "','" & "xc3" & "','" & "Tiempo X hora " & lblpc.Text & "',0,'" & "SER" & "',0,0,0,0," & MyPreciosin & "," & MyTotalSin & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'" & "RESTA" & "','" & "Renta de Mesa" & "',' ','" & MyComen & "',0,'" & "MESAS" & "','" & "MESAS" & "',0,'" & HrTiempo & "','" & HrEntrega & "')"
            cmd2.ExecuteNonQuery()
            cnn2.Close()

            If MsgBox("¿Desea Imprimir el Ticket?", vbInformation + vbOKCancel, "Delsscom Solutions® Restuarant") = vbOK Then

                Dim tamimpre As String = ""
                Dim ruta_impresor As String = ""
                Dim tipopapel As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select NotasCred from Formatos where Facturas='TamImpre'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        tamimpre = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Impresora from RutasImpresion where Tipo='TICKET'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        ruta_impresor = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                If tamimpre = "80" Then
                    EntradaBillar80.DefaultPageSettings.PrinterSettings.PrinterName = ruta_impresor
                    EntradaBillar80.Print()
                End If

            End If

            Me.Close()

            frmMesas.Close()
            frmMesas.Show()
            frmMesas.txtUsuario.Text = id_usu_log
            Call frmMesas.TRAERLUGAR()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try

    End Sub

    Private Sub EntradaBillar80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles EntradaBillar80.PrintPage

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
                Y += 18

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
        e.Graphics.DrawString(Format(Date.Now, "yyyy/MM/dd"), fuente_b, Brushes.Black, 45, Y)
        Y += 20
        e.Graphics.DrawString("Hora de Asignación: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(Format(Date.Now, "HH:mm:ss"), fuente_b, Brushes.Black, 135, Y)
        Y += 20
        e.Graphics.DrawString("Tiempo de la Mesa: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(lblpc.Text, fuente_b, Brushes.Black, 135, Y)
        Y += 20
        e.Graphics.DrawString(pie1, fuente_b, Brushes.Black, 1, Y)


        e.HasMorePages = False

    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnIniciarTiempo_Click_1(sender As Object, e As EventArgs) Handles btnIniciarTiempo.Click

        If frmMesas.lblusuario.Text = "" Then
            MsgBox("Falta clave de Usuario", vbInformation + vbOKOnly, titulomensajes)
            Me.Close()
            frmMesas.txtUsuario.Focus.Equals(True)
        End If

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO AsigPC(Nombre,HorEnt,HorSal,Fecha,Ocupada) values('" & lblpc.Text & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','" & Format(Date.Now, "yyyy-MM-dd") & "',1)"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE Mesa SET Status='Ocupada' WHERE Nombre_mesa='" & lblpc.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO Comanda1(IdCliente,Direccion,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Nombre,TComensales) VALUES(0,'','','','','','','','','" & lblpc.Text & "',0)"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT MAX(Folio) FROM Comanda1"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    CFOLIO = rd2(0).ToString
                Else
                    CFOLIO = 0
                End If
            Else
                CFOLIO = 0
            End If
            rd2.Close()

            If minutosTiempo = 0 Then
                HrTiempo = Format(Date.Now, "HH:mm:ss")
                HrEntrega = Format(Date.Now, "HH:mm:ss")
            ElseIf minutosTiempo > 0 Then
                HrTiempo = Format(Date.Now, "HH:mm:ss")
                'HrEntrega = Format(DateAdd("n", minutosTiempo, Date.Now), "HH:mm:ss")
            End If

            Dim MyPreciosin As Double = 0
            Dim MyTotalSin As Double = 0
            Dim MyComen As String = ""

            MyPreciosin = 0
            MyPreciosin = 0 - MyPreciosin
            MyTotalSin = FormatNumber(MyPreciosin, 2)
            MyComen = frmMesas.lblusuario.Text

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "insert into Comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Depto,Grupo,EstatusT,Hr,EntregaT) values(" & CFOLIO & ",'" & lblpc.Text & "','" & "xc3" & "','" & "Tiempo X hora " & lblpc.Text & "',0,'" & "SER" & "',0,0,0,0," & MyPreciosin & "," & MyTotalSin & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'" & "RESTA" & "','" & "Renta de Mesa" & "',' ','" & MyComen & "',0,'" & "MESAS" & "','" & "MESAS" & "',0,'" & HrTiempo & "','" & HrEntrega & "')"
            cmd2.ExecuteNonQuery()
            cnn2.Close()

            If MsgBox("¿Desea Imprimir el Ticket?", vbInformation + vbOKCancel, "Delsscom Solutions® Restuarant") = vbOK Then

                Dim tamimpre As String = ""
                Dim ruta_impresor As String = ""
                Dim tipopapel As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select NotasCred from Formatos where Facturas='TamImpre'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        tamimpre = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Impresora from RutasImpresion where Tipo='TICKET'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        ruta_impresor = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                If tamimpre = "80" Then
                    EntradaBillar80.DefaultPageSettings.PrinterSettings.PrinterName = ruta_impresor
                    EntradaBillar80.Print()
                End If

            End If

            Me.Close()

            frmMesas.Close()
            frmMesas.Show()
            frmMesas.txtUsuario.Text = id_usu_log
            Call frmMesas.TRAERLUGAR()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub
End Class