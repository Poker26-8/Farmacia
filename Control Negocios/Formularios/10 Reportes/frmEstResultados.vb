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
End Class