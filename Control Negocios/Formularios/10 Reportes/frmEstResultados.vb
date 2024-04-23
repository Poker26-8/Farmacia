Imports System.IO
Public Class frmEstResultados
    Private Sub frmEstResultados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpinicio.Value = Date.Now
        dtpfinal.Value = Date.Now
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim PCodigo As String = "", PNombre As String = ""

        Dim ventas As Double = 0
        Dim devoluciones As Double = 0
        Dim descuentos As Double = 0
        Dim ventas_totales As Double = 0
        Dim cantidad As Double = 0
        Dim costo As Double = 0
        Dim compras As Double = 0

        On Error GoTo kaka
        'Primero va a sacar qué productos son los que se han vendido en el periodo de tiempo que se haya puesto

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select distinct Codigo from VentasDetalle where Fecha between '" & Format(dtpinicio.Value, "yyyy-MM-dd") & "' and '" & Format(dtpfinal.Value, "yyyy-MM-dd") & "'"
        rd1 = cmd1.ExecuteReader
        cnn2.Close() : cnn2.Open()
        Do While rd1.Read
            If rd1.HasRows Then
                PCodigo = rd1(0).ToString()

                ventas = ventas + TotVentas(PCodigo)
                devoluciones = devoluciones + TotDevolucion(PCodigo)
                descuentos = descuentos + TotDescuentos(PCodigo)
                'ventas_totales = ventas_totales + (ventas + devoluciones + descuentos)

                cantidad = TotCantidad(PCodigo)

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select PrecioCompra from Productos where Codigo='" & PCodigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        costo = rd2(0).ToString()
                    End If
                End If
                rd2.Close()

                compras = compras + (cantidad * costo)
            End If
            txtventas_n.Text = FormatNumber(ventas, 2)
            txtdevos.Text = FormatNumber(devoluciones, 2)
            txtdescu.Text = FormatNumber(descuentos, 2)
            txtventas.Text = CDbl(txtventas_n.Text) - (CDbl(txtdevos.Text) + CDbl(txtdescu.Text))
            txtventas.Text = FormatNumber(txtventas.Text, 2)
            txtcosto.Text = FormatNumber(compras, 2)
            txtutilidad_bruta.Text = CDbl(txtventas.Text) - CDbl(txtcosto.Text)
        Loop
        cnn2.Close()
        rd1.Close() : cnn1.Close()

        Dim gastosadministrativoas As Double = 0
        Dim gastosoperacion As Double = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select * from otrosgastos where Tipo='ADMINISTRACION' and Fecha between '" & Format(dtpinicio.Value, "yyyy-MM-dd") & "' and '" & Format(dtpfinal.Value, "yyyy-MM-dd") & "'"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            ' gastosadministrativoas = gastosadministrativoas + CDec(rd1("Efectivo").ToString) + CDec(rd1("Transfe").ToString)
            gastosadministrativoas = gastosadministrativoas + CDec(rd1("Total").ToString)
        Loop
        rd1.Close() : cnn1.Close()

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select * from otrosgastos where Tipo='OPERACION' and Fecha between '" & Format(dtpinicio.Value, "yyyy-MM-dd") & "' and '" & Format(dtpfinal.Value, "yyyy-MM-dd") & "'"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            ' gastosoperacion = gastosoperacion + CDec(rd1("Efectivo").ToString) + CDec(rd1("Transfe").ToString)
            gastosoperacion = gastosoperacion + CDec(rd1("Total").ToString)
        Loop
        rd1.Close() : cnn1.Close()

        txtgastos_op.Text = FormatNumber(gastosoperacion, 2)
        txtgastos_ad.Text = FormatNumber(gastosadministrativoas, 2)

        Dim operaciontotal As Double = 0
        operaciontotal = CDec(gastosadministrativoas) + CDec(gastosoperacion)

        txtutilidad_im.Text = FormatNumber(txtutilidad_bruta.Text - operaciontotal)
kaka:

    End Sub



    Private Function TotCantidad(ByVal COD As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select sum(Cantidad) as Cant from VentasDetalle where Codigo='" & COD & "' and Fecha between '" & Format(dtpinicio.Value, "yyyy-MM-dd") & "' and '" & Format(dtpfinal.Value, "yyyy-MM-dd") & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TotCantidad = IIf(rd3("Cant").ToString() = "", 0, rd3("Cant").ToString())
                End If
            Else
                TotCantidad = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Function TotDescuentos(ByVal COD As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select sum(Descto) as Descu from VentasDetalle where Codigo='" & COD & "' and Fecha between '" & Format(dtpinicio.Value, "yyyy-MM-dd") & "' and '" & Format(dtpfinal.Value, "yyyy-MM-dd") & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TotDescuentos = IIf(rd3("Descu").ToString() = "", 0, rd3("Descu").ToString())
                End If
            Else
                TotDescuentos = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Function TotVentas(ByVal COD As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select sum(Total) as Tot from VentasDetalle where Codigo='" & COD & "' and Fecha between '" & Format(dtpinicio.Value, "yyyy-MM-dd") & "' and '" & Format(dtpfinal.Value, "yyyy-MM-dd") & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TotVentas = IIf(rd3("Tot").ToString() = "", 0, rd3("Tot").ToString())
                End If
            Else
                TotVentas = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Function TotDevolucion(ByVal COD As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select sum(Total) as Tot from Devoluciones where Codigo='" & COD & "' and Fecha between '" & Format(dtpinicio.Value, "yyyy-MM-dd 00:00:00") & "' and '" & Format(dtpfinal.Value, "yyyy-MM-dd 23:59:59") & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TotDevolucion = IIf(rd3("Tot").ToString() = "", 0, rd3("Tot").ToString())
                End If
            Else
                TotDevolucion = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            Dim tam As Double = 0
            Dim impresora As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tam = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Equipo='" & ObtenerNombreEquipo() & "' AND Tipo='TICKET'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impresora = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If impresora <> "" Then
                If tam = "80" Then
                    PRecibo80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PRecibo80.Print()
                End If
                If tam = "58" Then
                    PRecibo58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PRecibo58.Print()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub PRecibo80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PRecibo80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 10, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 10, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 9, FontStyle.Bold)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")

        Try
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 5
                End If
            Else
                Y += 0
            End If
            rd2.Close()
            cnn2.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("ESTADO  DE  RESULTADOS", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Fecha Inicial: " & dtpinicio.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Fecha Final: " & dtpfinal.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtventas_n.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("DEVOLUCIONES SOBRE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtdevos.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("DESCUENTOS SOBRE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtdescu.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("VENTAS NETAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtventas.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("COSTO DE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtcosto.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("UTILIDAD BRUTA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtutilidad_bruta.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("GASTOS ADMINISTRATIVOS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtgastos_ad.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("GASTOS OPERATIVOS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtgastos_op.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("GASTOS DE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtgastos_ve.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("UTILIDAD ANTES DE IMPUESTOS: ", fuente_p, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtutilidad_im.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("IMPUESTOS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtimpuestos.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20

            e.Graphics.DrawString("UTILIDAD NETA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtutilidad.Text, fuente_c, Brushes.Black, 280, Y, derecha)
            Y += 20
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub PRecibo58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PRecibo58.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")

        Try
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 0, 160, 80)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 5
                End If
            Else
                Y += 0
            End If
            rd2.Close()
            cnn2.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("ESTADO  DE  RESULTADOS", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Fecha Inicial: " & dtpinicio.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Fecha Final: " & dtpfinal.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtventas_n.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("DEVOLUCIONES SOBRE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtdevos.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("DESCUENTOS SOBRE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtdescu.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("VENTAS NETAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtventas.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("COSTO DE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtcosto.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("UTILIDAD BRUTA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtutilidad_bruta.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("GASTOS ADMINISTRATIVOS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtgastos_ad.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("GASTOS OPERATIVOS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtgastos_op.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("GASTOS DE VENTAS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtgastos_ve.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("UTILIDAD ANTES DE IMPUESTOS: ", fuente_p, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtutilidad_im.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("IMPUESTOS: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtimpuestos.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("UTILIDAD NETA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(txtutilidad.Text, fuente_c, Brushes.Black, 180, Y, derecha)
            Y += 20
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub
End Class