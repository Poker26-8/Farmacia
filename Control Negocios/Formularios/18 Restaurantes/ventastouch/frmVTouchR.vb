Imports System.IO
Imports System.Threading
Imports QRCoder
Public Class frmVTouchR

    Dim TotDeptos As Integer = 0
    Dim TotGrupos As Integer = 0
    Dim totpreferencia As Integer = 0
    Dim TotPromociones As Integer = 0
    Dim totProductos As Integer = 0
    Dim totextras As Integer = 0

    Public CodigoProducto As String = 0

    Public nombrepreferencia As String = ""
    Public nombreextras As String = ""
    Public nombrepromos As String = ""

    Public descripcion As String = ""
    Dim unidad As String = ""
    Dim minimo As Double = 0
    Dim MyMultiplo As Double = 0
    Dim existencia As Double = 0
    Dim dosxuno As Double = 0
    Dim tresxdos As Double = 0
    Public cantidad As Double = 0
    Dim precio As Double = 0
    Dim importe As Double = 0
    Dim grupo As String = ""

    Dim dia As Integer = 0
    Dim TestStr As String = ""

    Public banderacantidad As Integer = 0
    Public banderaprecio As Integer = 0
    Public banderacomentario As Integer = 0
    Dim banderaPROMOCION As Integer = 0

    Dim descripcionpro As String = ""

    Dim cortesia_venta As Integer = 0
    Dim Tiva As Double = 0
    Dim Foliore As Integer = 0

    Dim Prods() As String

    Public TotalImporte As Double = 0
    Public Cambio As Single
    Public PorPagar As Single
    Public montoTotal As Double = 0

    Public TotalIVAPrint As Double = 0

    Public Resta As Double = 0
    Dim MYFOLIO As Integer = 0

    Public rutacomanda As String = ""
    Public desglosaiva As Integer = 0

    Dim respuesta As String = ""

    'promociones
    Public cantidadPromo As Double
    Public cantpromo As Double = 0
    Public codigop As String = 0

    Friend WithEvents btnDepto, btnGrupo, btnProd, btnPrefe, btnExtra, btnPromo As System.Windows.Forms.Button
    Public cadenafact As String = ""
    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick
        TFolio.Stop()

        TFolio.Interval = 5000
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Max(Folio) FROM Ventas"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then


                lblfolio.Text = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) + 1
            Else
                lblfolio.Text = "1"


            End If
        Else
            lblfolio.Text = "1"
        End If
        rd1.Close()
        cnn1.Close()
        TFolio.Start()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick
        TFecha.Stop()
        Me.Text = "Delsscom® Restaurant - Ventas Touch" & Strings.Space(50) & Date.Now
        lblFecha.Text = Format(Date.Now, "yyyy/MM/dd")
        lblFechaPago.Text = Format(Date.Now, "yyyy/MM/dd")
        TFecha.Start()
    End Sub

    Private Sub Actualiza_Promos()
        Dim dia_hoy As Integer = Date.Now.DayOfWeek
        Dim dia_tex As String = ""

        If dia_hoy = 0 Then dia_tex = "Domingo"
        If dia_hoy = 1 Then dia_tex = "Lunes"
        If dia_hoy = 2 Then dia_tex = "Martes"
        If dia_hoy = 3 Then dia_tex = "Miercoles"
        If dia_hoy = 4 Then dia_tex = "Jueves"
        If dia_hoy = 5 Then dia_tex = "Viernes"
        If dia_hoy = 6 Then dia_tex = "Sabado"

        'COMENTARIO DE DÍAS'
        '0 -> Domingo       '4 -> Jueves
        '1 -> Lunes         '5 -> Viernes
        '2 -> Martes        '6 -> Sábado
        '3 -> Miércoles

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "update Productos set E1=0, E2=0"
            cmd3.ExecuteNonQuery()

            cnn4.Close() : cnn4.Open()

            'Primero 2x1
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select * from Promos where " & dia_tex & "=1"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    Dim codigo As String = rd3("Codigo").ToString()

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText =
                        "update Productos set E1=1 where Codigo='" & codigo & "'"
                    cmd4.ExecuteNonQuery()
                End If
            Loop
            rd3.Close()

            'Primero 3x2
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select * from Promos where " & dia_tex & "2=1"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    Dim codigo As String = rd3("Codigo").ToString()

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText =
                        "update Productos set E2=1 where Codigo='" & codigo & "'"
                    cmd4.ExecuteNonQuery()
                End If
            Loop
            rd3.Close()
            cnn3.Close()

            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn3.Close()
        End Try
    End Sub

    Private Sub frmVTouchR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFecha.Start()
        TFolio.Start()
        TotDeptos = 0
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select distinct Departamento from Productos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then TotDeptos = TotDeptos + 1
            Loop
            rd1.Close()
            cnn1.Close()

            pdepa.Controls.Clear()
            PGrupo.Controls.Clear()
            pproductos.Controls.Clear()
            pPreferencia.Controls.Clear()
            pExtras.Controls.Clear()
            pPromociones.Controls.Clear()
            Departamentos()

            If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
                pproductos.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
                pproductos.BackgroundImageLayout = ImageLayout.Stretch
            End If

            Actualiza_Promos()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lblRestaPagar.Text = "0.00"
        lblImporteEfectivo.Text = "0.00"
        lblCambio.Text = "0.00"
        lblTotalPagar.Text = "0.00"
        lblCantidadLetra.Text = ""
        lblPagos.Text = "0.00"
        lblDescuento.Text = "0.00"
        lblPropina.Text = "0.00"
        lbltotalventa.Text = "0.00"
        grdCaptura.Rows.Clear()
        pExtras.Controls.Clear()
        pPreferencia.Controls.Clear()
        pPromociones.Controls.Clear()
        Actualiza_Promos()
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim INDEX As Double = grdCaptura.CurrentRow.Index

        Dim IMPORTE = grdCaptura.Rows(INDEX).Cells(4).Value.ToString
        lblTotalPagar.Text = lblTotalPagar.Text - IMPORTE
        lblRestaPagar.Text = lblRestaPagar.Text - IMPORTE

        lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)
        lblRestaPagar.Text = FormatNumber(lblRestaPagar.Text, 2)


        grdCaptura.Rows.Remove(grdCaptura.CurrentRow)
        lblPropina.Text = "0.00"
        lbltotalventa.Text = "0.00"
        lblRestaPagar.Text = "0.00"
    End Sub

    Private Sub btnProd_Click(sender As Object, e As EventArgs)

        On Error GoTo nopaso

        Dim btnProducto As Button = CType(sender, Button)

        pPreferencia.Controls.Clear()
        pExtras.Controls.Clear()

        CodigoProducto = ""
        CodigoProducto = btnProducto.Tag
        cantidadPromo = 0
        Preferencias(btnProducto.Tag)
        Extras(btnProducto.Tag)
        Promociones(btnProducto.Tag)

        cantidad = 1
        ObtenerProducto(CodigoProducto)
nopaso:
    End Sub

    Private Sub lblTotalPagar_TextChanged(sender As Object, e As EventArgs) Handles lblTotalPagar.TextChanged
        If lblTotalPagar.Text = "" Then Exit Sub
        Dim TotalImporte As Double = lblTotalPagar.Text
        Dim CantidadLetra As String = ""

        If TotalImporte > 0 Then
            btnPagar.Enabled = True
            CantidadLetra = UCase(convLetras(TotalImporte))
        Else
            btnPagar.Enabled = False
            CantidadLetra = ""
        End If
        lblCantidadLetra.Text = CantidadLetra
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        PTeclado.Visible = False
    End Sub

    Private Sub btnOcacional_Click(sender As Object, e As EventArgs) Handles btnOcacional.Click
        frmProductoOcasionalTouch.focomesasmostrar = 0
        frmProductoOcasionalTouch.Show()
        frmProductoOcasional.BringToFront()
    End Sub

    Public Sub ObtenerProducto(Codigo As String)

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Codigo & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Departamento").ToString = "SERVICIOS" Then
                        Exit Sub
                    End If

                    descripcion = rd1("Nombre").ToString
                    unidad = rd1("UVenta").ToString
                    minimo = rd1("Min").ToString
                    MyMultiplo = rd1("Multiplo").ToString
                    dosxuno = rd1("E1").ToString
                    tresxdos = rd1("E2").ToString
                    grupo = rd1("Grupo").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Existencia,Departamento FROM Productos WHERE Codigo='" & Strings.Left(Codigo, 6) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            existencia = rd2("Existencia").ToString
                            If rd2("Departamento").ToString = "SERVICIOS" Then
                                existencia = 0
                            End If
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()

                End If
            End If
            rd1.Close()
            cnn1.Close()

            Call find_preciovta(Codigo)
            minimo = existencia

            If dosxuno = 1 Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "select * from Promos where Codigo='" & Codigo & "' and Promo2x1=1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        If rd2("Promo2x1").ToString = 1 Then
                            dia = Weekday(Date.Now)
                            Select Case dia
                                Case = 1
                                    If rd2("Domingo").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioD").ToString And TestStr <= rd2("HFinD").ToString Or TestStr >= rd2("HInicioD2").ToString And TestStr <= rd2("HFinD2").ToString Then
                                            dosxuno = 1
                                        Else
                                            dosxuno = 0
                                        End If
                                    Else
                                        dosxuno = 0
                                    End If

                                Case = 2
                                    If rd2("Lunes").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioL").ToString And TestStr <= rd2("HFinL").ToString Or TestStr >= rd2("HInicioL2").ToString And TestStr <= rd2("HFinL2").ToString Then
                                            dosxuno = 1
                                        Else
                                            dosxuno = 0
                                        End If
                                    Else
                                        dosxuno = 0
                                    End If

                                Case = 3
                                    If rd2("Martes").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioM").ToString And TestStr <= rd2("HFinM").ToString Or TestStr >= rd2("HInicioM2").ToString And TestStr <= rd2("HFinM2").ToString Then
                                            dosxuno = 1
                                        Else
                                            dosxuno = 0
                                        End If
                                    Else
                                        dosxuno = 0
                                    End If

                                Case = 4
                                    If rd2("Miercoles").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioMi").ToString And TestStr <= rd2("HFinMi").ToString Or TestStr >= rd2("HInicioMi2").ToString And TestStr <= rd2("HFinMi2").ToString Then
                                            dosxuno = 1
                                        Else
                                            dosxuno = 0
                                        End If
                                    Else
                                        dosxuno = 0
                                    End If

                                Case = 5
                                    If rd2("Jueves").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioJ").ToString And TestStr <= rd2("HFinJ").ToString Or TestStr >= rd2("HInicioJ2").ToString And TestStr <= rd2("HFinJ2").ToString Then
                                            dosxuno = 1
                                        Else
                                            dosxuno = 0
                                        End If
                                    Else

                                        dosxuno = 0
                                    End If

                                Case = 6
                                    If rd2("Viernes").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioV").ToString And TestStr <= rd2("HFinV").ToString Or TestStr >= rd2("HInicioV2").ToString And TestStr <= rd2("HFinV2").ToString Then
                                            dosxuno = 1
                                        Else
                                            dosxuno = 0
                                        End If
                                    Else
                                        dosxuno = 0
                                    End If


                                Case = 7
                                    If rd2("Sabado").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioS").ToString And TestStr <= rd2("HFinS").ToString Or TestStr >= rd2("HInicioS2").ToString And TestStr <= rd2("HFinS2").ToString Then
                                            dosxuno = 1
                                        Else
                                            dosxuno = 0
                                        End If
                                    Else
                                        dosxuno = 0
                                    End If

                                Case Else
                                    dosxuno = 0
                            End Select
                        End If
                    Else
                        dosxuno = 0
                    End If
                End If
                rd2.Close()
                cnn2.Close()
            End If

            If tresxdos = 1 Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "select * from Promos where Codigo='" & Codigo & "' and Promo3x2=1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        If rd2("Promo3x2").ToString = 1 Then
                            dia = Weekday(Date.Now)
                            Select Case dia
                                Case = 1
                                    If rd2("Domingo2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioD3").ToString And TestStr <= rd2("HFinD3").ToString Or TestStr >= rd2("HInicioD33").ToString And TestStr <= rd2("HFinD33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 2
                                    If rd2("Lunes2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioL3").ToString And TestStr <= rd2("HFinL3").ToString Or TestStr >= rd2("HInicioL33").ToString And TestStr <= rd2("HFinL33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 3
                                    If rd2("Martes2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioM3").ToString And TestStr <= rd2("HFin1M3").ToString Or TestStr >= rd2("HInicioM33").ToString And TestStr <= rd2("HFinM33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 4
                                    If rd2("Miercoles2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioMi3").ToString And TestStr <= rd2("HFinMi3").ToString Or TestStr >= rd2("HInicioMi33").ToString And TestStr <= rd2("HFinMi33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 5
                                    If rd2("Jueves2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioJ3").ToString And TestStr <= rd2("HFinJ3").ToString Or TestStr >= rd2("HInicioJ33").ToString And TestStr <= rd2("HFinJ33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 6
                                    If rd2("Viernes2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioV3").ToString And TestStr <= rd2("HFinV3").ToString Or TestStr >= rd2("HInicioV33").ToString And TestStr <= rd2("HFinV33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 7
                                    If rd2("Sabado2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioS3").ToString And TestStr <= rd2("HFinS3").ToString Or TestStr >= rd2("HInicioS33").ToString And TestStr <= rd2("HFinS33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If
                                Case Else
                                    tresxdos = 0
                            End Select
                        End If
                    Else
                        tresxdos = 0
                    End If
                Else
                    tresxdos = 0
                End If
                rd2.Close()
                cnn2.Close()

            End If

            precio = (precio)


            importe = cantidad * precio

            If grupo = "PROMOCIONES" Then
                UpGridCaptura()
            Else
                If importe <> 0 Then
                    UpGridCaptura()
                Else
                    MsgBox("Este producto no tiene precio de venta, no se agregara en la comanda", vbInformation + vbOKOnly, "Delsscom® Restaurant")
                End If
            End If



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub find_preciovta(codigo As String)

        Dim MyPrecio As Double = 0

        Try

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If PEDI = False Then

                        If rd2("Grupo").ToString = "PROMOCIONES" Then
                            MyPrecio = 0
                        Else
                            MyPrecio = rd2("PrecioVentaIVA").ToString
                        End If


                    ElseIf PEDI = True Then
                        If rd2("Grupo").ToString = "PROMOCIONES" Then
                            MyPrecio = 0
                        Else
                            MyPrecio = rd2("PrecioVentaIVA").ToString
                        End If

                    End If
                    precio = FormatNumber(MyPrecio, 2)
                End If
            End If
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Public Sub UpGridCaptura()

        Dim TotalVenta As Double = 0
        Dim acumula As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Acumula'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                acumula = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        If dosxuno = 1 Then

            With grdCaptura.Rows
                .Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(precio, 2), FormatNumber(importe, 2), "", "")

                lblTotalPagar.Text = lblTotalPagar.Text + importe
                lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)
                lblRestaPagar.Text = lblRestaPagar.Text + importe
                lblRestaPagar.Text = FormatNumber(lblRestaPagar.Text, 2)

            End With

            With Me.grdCaptura
                For ii As Integer = 0 To grdCaptura.Rows.Count - 1
                    grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", "")
                Next
            End With
            Exit Sub
        End If

        If tresxdos = 1 Then

            With grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(precio, 2), FormatNumber(importe, 2), "", "")

            End With

            With Me.grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(precio, 2), FormatNumber(importe, 2), "", "")

            End With
            For q As Integer = 0 To grdCaptura.Rows.Count - 1
                TotalVenta = TotalVenta + CDbl(grdCaptura.Rows(q).Cells(4).Value.ToString)
                lblTotalPagar.Text = FormatNumber(TotalVenta, 2)

                lblRestaPagar.Text = FormatNumber(TotalVenta, 2)
            Next

            With Me.grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", "")

            End With
            Exit Sub
        End If

        With Me.grdCaptura

            Dim banderaproducto As Integer = 0
            banderaproducto = 0

            If acumula = 1 Then
                For dx As Integer = 0 To grdCaptura.Rows.Count - 1
                    If CodigoProducto = grdCaptura.Rows(dx).Cells(0).Value.ToString Then
                        grdCaptura.Rows(dx).Cells(2).Value = cantidad + CDec(grdCaptura.Rows(dx).Cells(2).Value)
                        grdCaptura.Rows(dx).Cells(4).Value = FormatNumber(importe + CDec(grdCaptura.Rows(dx).Cells(4).Value), 2)

                        lblTotalPagar.Text = lblTotalPagar.Text + importe
                        lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)

                        lblRestaPagar.Text = lblRestaPagar.Text + importe
                        lblRestaPagar.Text = FormatNumber(lblRestaPagar.Text, 2)

                        GoTo deku
                    End If
                Next

                grdCaptura.Rows.Add(CodigoProducto,
                                        CodigoProducto & vbNewLine & descripcion,
                                        cantidad,
                                        FormatNumber(precio, 2),
                                        FormatNumber(importe, 2),
    respuesta, "")

                lblTotalPagar.Text = lblTotalPagar.Text + importe
                lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)

                lblRestaPagar.Text = lblRestaPagar.Text + importe
                lblRestaPagar.Text = FormatNumber(lblRestaPagar.Text, 2)

            Else
                If banderaproducto = 0 Then

                    grdCaptura.Rows.Add(CodigoProducto,
                                        CodigoProducto & vbNewLine & descripcion,
                                        cantidad,
                                        FormatNumber(precio, 2),
                                        FormatNumber(importe, 2),
    respuesta, "")

                    lblTotalPagar.Text = lblTotalPagar.Text + importe
                    lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)

                    lblRestaPagar.Text = lblRestaPagar.Text + importe
                    lblRestaPagar.Text = FormatNumber(lblRestaPagar.Text, 2)

                End If
            End If
deku:
            'For q As Integer = 0 To grdCaptura.Rows.Count - 1

            '    If grdCaptura.Rows(q).Cells(0).Value = CodigoProducto Then
            '        grdCaptura.Rows(q).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
            '        grdCaptura.Rows(q).Cells(2).Value = FormatNumber(CDbl(grdCaptura.Rows(q).Cells(2).Value.ToString()) + CDec(cantidad), 2)
            '        grdCaptura.Rows(q).Cells(3).Value = FormatNumber(precio, 2)
            '        grdCaptura.Rows(q).Cells(4).Value = FormatNumber(CDbl(grdCaptura.Rows(q).Cells(4).Value.ToString()) + importe, 2)

            '        lblTotalPagar.Text = lblTotalPagar.Text + importe
            '        lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)
            '        lblRestaPagar.Text = lblRestaPagar.Text + importe
            '        lblRestaPagar.Text = FormatNumber(lblRestaPagar.Text, 2)
            '        banderaproducto = 1
            '    End If

            'Next q



        End With


    End Sub

    Public Sub Departamentos()
        Dim deptos As Integer = 0

        Try

            If TotDeptos <= 9 Then
                pdepa.AutoScroll = False
            Else
                pdepa.AutoScroll = True
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select distinct Departamento from Productos where Departamento<>'INSUMO' AND Departamento<>'EXTRAS' order by Departamento"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim departamento As String = rd1("Departamento").ToString

                    btnDepto = New Button
                    btnDepto.Text = departamento
                    btnDepto.Name = "btnDepto(" & deptos & ")"
                    btnDepto.Left = 0
                    btnDepto.Height = 55

                    If TotDeptos <= 9 Then
                        btnDepto.Width = pdepa.Width
                    Else
                        btnDepto.Width = pdepa.Width - 17
                    End If
                    btnDepto.Top = (deptos) * (btnDepto.Height + 0.5)
                    btnDepto.BackColor = pdepa.BackColor
                    btnDepto.FlatStyle = FlatStyle.Popup
                    btnDepto.FlatAppearance.BorderSize = 0
                    AddHandler btnDepto.Click, AddressOf btnDepto_Click
                    pdepa.Controls.Add(btnDepto)
                    If deptos = 0 Then
                        Grupos(departamento)
                    End If
                    deptos += 1

                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Try
            Dim id As Integer = 0
            Dim exacto As Integer = 0

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT IdEmpleado FROM usuarios WHERE Alias='" & lblAtendio.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.Read Then
                If rd3.HasRows Then
                    id = rd3(0).ToString
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT CobrarM FROM permisosM WHERE IdEmpleado=" & id & ""
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            If rd2(0).ToString = 1 Then
                                If frmPagarTouch.Visible = False Then

                                    cnn1.Close() : cnn1.Open()
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='CobroExacto'"
                                    rd1 = cmd1.ExecuteReader
                                    If rd1.HasRows Then
                                        If rd1.Read Then
                                            exacto = rd1(0).ToString

                                            If exacto = 1 Then
                                                frmPagarTouch.Show(Me)
                                                frmPagarTouch.txtEfectivo.Focus.Equals(True)
                                                frmPagarTouch.focomapeo = 1
                                                frmPagarTouch.txtSubtotalmapeo.Text = FormatNumber(lblTotalPagar.Text, 2)
                                                frmPagarTouch.lblfolio.Text = lblfolio.Text
                                                frmPagarTouch.txtEfectivo.Text = frmPagarTouch.txtTotal.Text
                                                frmPagarTouch.btnIntro.Focus.Equals(True)
                                            Else
                                                frmPagarTouch.Show(Me)
                                                frmPagarTouch.txtEfectivo.Focus.Equals(True)
                                                frmPagarTouch.focomapeo = 1
                                                frmPagarTouch.txtSubtotalmapeo.Text = FormatNumber(lblTotalPagar.Text, 2)
                                                frmPagarTouch.lblfolio.Text = lblfolio.Text
                                            End If

                                        End If
                                    End If
                                    rd1.Close()
                                    cnn1.Close()


                                End If
                            Else
                                MsgBox("EL usuario no cuenta con el permiso para cerrar las cuentas", vbInformation + vbOKOnly, titulomensajes)
                            End If
                        End If
                    Else
                        MsgBox("EL usuario no tiene permisos asignados", vbInformation + vbOKOnly, titulomensajes)
                    End If
                    rd2.Close()
                    cnn2.Close()
                End If
            End If
            rd3.Close()
            cnn3.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Public Sub btnDepto_Click(sender As Object, e As EventArgs)
        Dim btnDepartamento As Button = CType(sender, Button)
        btnDepartamento.Font.Bold.Equals(True)

        PGrupo.Controls.Clear()
        pproductos.Controls.Clear()
        pPreferencia.Controls.Clear()
        pExtras.Controls.Clear()
        pPromociones.Controls.Clear()

        If cnn2.State = 1 Then
            cnn2.Close()
        End If

        totProductos = 0
        Grupos(btnDepartamento.Text)
    End Sub

    Private Sub grdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellClick
        Dim celda As DataGridViewCellEventArgs = e

        If celda.ColumnIndex = 2 Then
            PTeclado.Show()
            pletras.Enabled = False
            txtRespuesta.Text = ""
            pCampo.Text = "Cantidad"
            txtRespuesta.Focus.Equals(True)
            CodigoProducto = grdCaptura.CurrentRow.Cells(0).Value.ToString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select Nombre FROM Productos WHERE Codigo='" & CodigoProducto & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    descripcionpro = rd1(0).ToString
                End If
            End If
            rd1.Close()
            banderacantidad = 1
        End If

        If celda.ColumnIndex = 3 Then
            PTeclado.Show()
            pletras.Enabled = False
            txtRespuesta.Text = ""
            pCampo.Text = "Cambiar Precio"
            txtRespuesta.Focus.Equals(True)
            CodigoProducto = grdCaptura.CurrentRow.Cells(0).Value.ToString
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select Nombre FROM Productos WHERE Codigo='" & CodigoProducto & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    descripcionpro = rd1(0).ToString
                End If
            End If
            rd1.Close()
            banderaprecio = 1
        End If

        If celda.ColumnIndex = 4 Then

            PTeclado.Show()
            pletras.Enabled = True
            txtRespuesta.Text = ""
            pCampo.Text = "Comentario"
            txtRespuesta.Focus.Equals(True)
            CodigoProducto = grdCaptura.CurrentRow.Cells(0).Value.ToString
            banderacomentario = 1
        End If
    End Sub

    Private Sub btnCortesia_Click(sender As Object, e As EventArgs) Handles btnCortesia.Click

        Dim VarId As Integer = 0
        Dim VarCortesia As Integer = 0

        Dim cuenta As Double = 0
        Dim CODIG As String = ""
        Dim DESC1 As String = ""
        Dim cant As Double = 0
        Dim PUVCIVA As Double = 0
        Dim TOTAL1 As Double = 0
        Dim UDV As String = ""
        Dim Comen As String = ""
        Dim CostVUE1 As Double = 0
        Dim PrecioSinIVA1 As Double = 0
        Dim TOTALSIVA As Double = 0
        Dim DEPA As String = ""
        Dim GRUPO1 As String = ""

        Try
            cortesia_venta = 1
            lblRestaPagar.Text = "0.00"

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT idEmpleado FROM Usuarios WHERE Alias='" & lblAtendio.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    VarId = rd1(0).ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "select CortesiaM from permisosm where IdEmpleado=" & VarId & ""
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            VarCortesia = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()

                End If
            End If
            rd1.Close()
            cnn1.Close()

            If VarCortesia = 0 Then
                MsgBox("Usuario sin privilegios para la cortesia", vbInformation + vbOKOnly, "Delsscom® Restaurant")
                Exit Sub
            End If

            Tiva = CDec(lblTotalPagar.Text) * 0.16
            cuenta = CDec(CDec(lblImporteEfectivo.Text) + CDec(lblPagos.Text)) - CDec(lblCambio.Text)

            Tiva = 0
            cuenta = FormatNumber(cuenta, 2)

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,Status,Descuento,Comisionista,Concepto,MntoCortesia) values(" & IIf(VarId, 0, VarId) & ",'" & lblCliente.Text & "','" & lblDireccion.Text & "',0," & Tiva & ",0," & cuenta & "," & lblRestaPagar.Text & ",'" & lblAtendio.Text & "','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & "PAGADO" & "',0,0,'" & "CORTESIA" & "'," & CDec(lblTotalPagar.Text) & ")"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT MAX(Folio) from Ventas"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    Foliore = IIf(rd4(0).ToString = "", 1, rd4(0).ToString)
                Else
                    Foliore = 0
                End If
            Else
                Foliore = 0
            End If
            rd4.Close()
            cnn4.Close()

            For LUFFY As Integer = 0 To grdCaptura.Rows.Count - 1

                Prods = Strings.Split(grdCaptura.Rows(LUFFY).Cells(1).Value.ToString, vbCrLf)
                CODIG = Prods(0)
                DESC1 = Prods(1)
                cant = grdCaptura.Rows(LUFFY).Cells(2).Value.ToString
                PUVCIVA = grdCaptura.Rows(LUFFY).Cells(3).Value.ToString
                Comen = grdCaptura.Rows(LUFFY).Cells(5).Value
                TOTAL1 = 0

                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText = "SELECT * FROM Productos WHERE Codigo='" & CODIG & "'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows <> 0 Then
                    If rd5.Read Then
                        CostVUE1 = rd5("PrecioCompra").ToString
                        PrecioSinIVA1 = 0
                        TOTALSIVA = 0
                        DEPA = Trim(rd5("Departamento").ToString)
                        GRUPO1 = rd5("Grupo").ToString
                        UDV = rd5("UVenta").ToString
                    End If
                End If
                rd5.Close()
                cnn5.Close()

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO VentasDetalle(Codigo,Folio,Nombre,Unidad,Cantidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Depto,Grupo,TotalIEPS,TasaIEPS) VALUES('" & CODIG & "'," & Foliore & ",'" & DESC1 & "','" & UDV & "'," & cant & "," & PUVCIVA & "," & CostVUE1 & "," & PUVCIVA & "," & TOTAL1 & "," & PrecioSinIVA1 & "," & TOTALSIVA & ",'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'" & DEPA & "','" & GRUPO1 & "',0,0)"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO VtaImpresion(Folio,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo) VALUES(" & Foliore & ",'" & CODIG & "','" & DESC1 & "'," & cant & ",'" & UDV & "'," & PUVCIVA & "," & CostVUE1 & "," & PUVCIVA & "," & TOTAL1 & "," & PrecioSinIVA1 & "," & TOTALSIVA & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "','" & DEPA & "','" & GRUPO1 & "')"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Productos SET Existencia=Existencia -" & CDec(cant) & " WHERE Codigo='" & CODIG & "'"
                cnn1.Close()

            Next

            MsgBox("Cortesia agregada correctamente", vbInformation + vbOKOnly, titulomensajes)

            Dim tamimpresion As Integer = 0
            Dim impresora As String = ""

            tamimpresion = TamImpre()
            impresora = ImpresoraImprimir()


            If tamimpresion = "80" Then
                Cortesia80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                Cortesia80.Print()
            ElseIf tamimpresion = "58" Then
                Cortesia58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                Cortesia58.Print()
            End If
            cnn1.Close()

            cortesia_venta = 0
            btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Open()
            cnn3.Close()
            cnn5.Close()
            cnn4.Close()
        End Try

    End Sub

    Private Sub Grupos(ByVal depto As String)

        Dim grupos As Integer = 0
        TotGrupos = 0
        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT Grupo FROM Productos WHERE Departamento='" & depto & "' AND Grupo<>'EXTRAS' AND Grupo<>'PROMOCIONES' ORDER BY Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    If rd2.HasRows Then TotGrupos = TotGrupos + 1
                End If
            Loop
            rd2.Close()

            If TotGrupos <= 9 Then
                PGrupo.AutoScroll = False
            Else
                PGrupo.AutoScroll = True
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT distinct Grupo FROM Productos WHERE Departamento='" & depto & "'AND Grupo<>'EXTRAS' AND Grupo<>'PROMOCIONES' order by Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    Dim grupo As String = rd2(0).ToString
                    btnGrupo = New Button
                    btnGrupo.Text = grupo
                    btnGrupo.Tag = depto
                    btnGrupo.Name = "btnGrupo(" & grupos & ")"
                    btnGrupo.Height = 55
                    btnGrupo.Width = 110
                    btnGrupo.Left = 0

                    'If TotGrupos <= 9 Then
                    '    btnGrupo.Width = PGrupo.Width
                    'Else
                    '    btnGrupo.Width = PGrupo.Width - 17
                    'End If
                    btnGrupo.Top = grupos * (btnGrupo.Height + 0.5)
                    btnGrupo.BackColor = PGrupo.BackColor
                    btnGrupo.FlatStyle = FlatStyle.Popup
                    btnGrupo.FlatAppearance.BorderSize = 0
                    AddHandler btnGrupo.Click, AddressOf btnGrupo_Click
                    PGrupo.Controls.Add(btnGrupo)
                    If grupos = 0 Then
                        Productos(depto, grupo)
                    End If
                    grupos += 1
                End If
            Loop
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub btnGrupo_Click(sender As Object, e As EventArgs)
        Dim btnGrupos As Button = CType(sender, Button)
        pproductos.Controls.Clear()
        If cnn3.State = 1 Then
            cnn3.Close()
        End If
        TotDeptos = 0
        Productos(btnGrupos.Tag, btnGrupos.Text)
    End Sub

    Private Sub PVentaTouch80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVentaTouch80.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 10, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim Pie2 As String = ""
        Dim Pie3 As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Dim cantidad As Double = 0
        Dim nombre As String = ""
        Dim precio As Double = 0
        Dim total As Double = 0

        Dim MyImporte As Double = 0
        Dim ope As Double = 0
        Dim TotalIVA As Double = 0

        Dim articulos As Integer = 0
        Dim cuentatotal As Double = 0

        Dim ligaqr As String = ""
        Dim whats As String = DatosRecarga("Whatsapp")

        Dim autofact As String = DatosRecarga("LinkAuto")
        Dim siqr As String = DatosRecarga2("LinkAuto")

        If whats <> "" Then
            ligaqr = "http://wa.me/" & whats
        End If

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 12
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
                "select * from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                Pie = rd4("Pie1").ToString
                Pie2 = rd4("Pie2").ToString
                Pie3 = rd4("Pie3").ToString
                'Razón social
                If rd4("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'RFC
                If rd4("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd4("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Colonia
                If rd4("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd4("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Teléfono
                If rd4("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Correo
                If rd4("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd4.Close()
        cnn4.Close()

        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("C L I E N T E", fuente_b, Brushes.Black, 135, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        Dim zu As Integer = 1

        If lblCliente.Text = "" Then
            e.Graphics.DrawString("MOSTRADOR", fuente_r, Brushes.Black, 1, Y)
            Y += 15
        Else
            e.Graphics.DrawString("Télefono: " & lblTelefono.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Cliente: " & lblCliente.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 15
        End If

        Do While Trim(lblDireccion.Text) <> ""
            lblDireccion.Text = Mid(lblDireccion.Text, zu, 38)
            If Trim(lblDireccion.Text) <> "" Then
                e.Graphics.DrawString("Direccion: " & lblDireccion.Text, fuente_b, Brushes.Black, 1, Y)
                Y += 12
            End If
            zu = zu + 38
        Loop
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 135, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 270, Y, derecha)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 215, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 20

        cnn3.Close() : cnn3.Open()
        cnn4.Close() : cnn4.Open()

        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "select * from VentasDetalle where Folio='" & MYFOLIO & "'"
        rd3 = cmd3.ExecuteReader
        Do While rd3.Read
            If rd3.HasRows Then

                cantidad = rd3("Cantidad").ToString
                nombre = rd3("Nombre").ToString
                precio = rd3("Precio").ToString
                total = rd3("Total").ToString

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "select IVA from Productos where Codigo='" & rd3("Codigo").ToString & "' "
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then
                        If rd4(0).ToString > 0 Then
                            ope = total / (1 + rd4(0).ToString)
                            TotalIVA = TotalIVA + CDec(ope) * CDec(rd4(0).ToString)
                            TotalIVA = FormatNumber(TotalIVA, 2)
                        End If

                    End If
                Loop
                rd4.Close()

                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 30
                Dim texto As String = nombre
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25, Y)
                    Y += 17
                    inicio += caracteresPorLinea
                End While


                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_b, Brushes.Black, 215, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20

                articulos = articulos + cantidad
                cuentatotal = cuentatotal + total
            End If
        Loop
        rd3.Close()

        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
        Y += 25



        If DesglosaIVA = 1 Then
            e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(cuentatotal - CDbl(TotalIVA), 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15

            e.Graphics.DrawString("IVA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(TotalIVA, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
        Else
            e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(cuentatotal, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
        End If

        If lblDescuento.Text > 0 Then
            e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(lblDescuento.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15

            e.Graphics.DrawString("TOTAL CON DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(CDbl(lblTotalPagar.Text) - CDbl(lblDescuento.Text), 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
        End If

        If lblPropina.Text > 0 Then
            e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(lblPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15

            e.Graphics.DrawString("TOTAL CON PROPINA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(CDbl(lbltotalventa.Text) + CDbl(lblPropina.Text), 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15
        End If


        e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(CDbl(lbltotalventa.Text) + CDbl(lblPropina.Text), 2), fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 20

        If Resta > 0 Then
            e.Graphics.DrawString("RESTA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(Resta, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 15

        End If

        If lblImporteEfectivo.Text > 0 Then
            e.Graphics.DrawString("EFECTIVO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(lblImporteEfectivo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            If lblCambio.Text > 0 Then
                e.Graphics.DrawString("CAMBIO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(lblCambio.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

        End If

        If frmPagarTouch.grdPagos.Rows.Count > 0 Then
            e.Graphics.DrawString("---------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            For lol As Integer = 0 To frmPagarTouch.grdPagos.Rows.Count - 1

                Dim forma As String = frmPagarTouch.grdPagos.Rows(lol).Cells(0).Value.ToString
                Dim monto As Double = frmPagarTouch.grdPagos.Rows(lol).Cells(3).Value.ToString

                If forma = "EFECTIVO" Then
                Else
                    e.Graphics.DrawString("PAGO CON: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(forma, fuente_b, Brushes.Black, 200, Y, derecha)
                    Y += 15

                    e.Graphics.DrawString("MONTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(FormatNumber(monto, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 15
                    e.Graphics.DrawString("---------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                    Y += 15
                End If
            Next
        End If




        Dim CantidaLetra As String = ""

        CantidaLetra = "Son: " & convLetras(lbltotalventa.Text)
        Y += 20

        If Mid(CantidaLetra, 1, 37) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 38), fuente_r, Brushes.Black, 1, Y)
            CantidaLetra = Mid(CantidaLetra, 40, 500)
            Y += 20
        End If

        If Mid(CantidaLetra, 1, 37) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 38), fuente_r, Brushes.Black, 1, Y)
            CantidaLetra = Mid(CantidaLetra, 40, 500)
            Y += 20
        End If

        Pie2 = EliminarSaltosLinea(Pie2, " ")
        If Trim(Pie2) <> "" Then
            e.Graphics.DrawString(Mid(Pie2, 1, 38), fuente_r, Brushes.Black, 1, Y)
            Pie2 = Mid(Pie2, 39, 700)
            Y += 15
        End If

        e.Graphics.DrawString("Lo atendio: " & lblAtendio.Text, fuente_r, Brushes.Black, 1, Y)
        Y += 20

        Dim autofac As Integer = 0
        Dim linkauto As String = ""

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='AutoFac'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                autofac = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='LinkAuto'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                linkauto = rd1(0).ToString
                siqr = rd1(1).ToString
            End If
        End If
        rd1.Close()

        Dim siqrwhats As Integer = 0

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='WhatsApp'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                siqrwhats = rd1(1).ToString
            End If
        End If
        rd1.Close()

        cnn1.Close()
        If siqrwhats = 1 Then
            If ligaqr <> "" Then
                picQR.Image.Dispose()
                Dim entrada As String = ligaqr
                Dim Gen As New QRCodeGenerator
                Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                Dim Code As New QRCode(data)
                If picQR.Image IsNot Nothing Then
                    picQR.Image.Dispose()
                End If
                picQR.Image = Code.GetGraphic(200)
                My.Application.DoEvents()
                e.Graphics.DrawString("Escríbenos por Whatsapp", fuente_c, Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawImage(picQR.Image, 83, CInt(Y), 85, 85)
                Y += 60
                If picQR.Image IsNot Nothing Then
                    picQR.Image.Dispose()
                End If
            End If

        End If

        Y += 35
        If autofac = 1 Then

            If siqr = "1" Then
                picQR.Image.Dispose()
                Dim entrada As String = linkauto
                Dim Gen As New QRCodeGenerator
                Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                Dim Code As New QRCode(data)

                ' Asegúrate de liberar los recursos de la imagen anterior antes de asignar la nueva imagen
                If picQR.Image IsNot Nothing Then
                    picQR.Image.Dispose()
                End If
                ' Asigna la nueva imagen al PictureBox
                picQR.Image = Code.GetGraphic(200)
                My.Application.DoEvents()
                e.Graphics.DrawString("Codigo para facturar:", fuente_c, Brushes.Black, 1, Y)
                Y += 25
                e.Graphics.DrawString(Trim(cadenafact), fuente_c, Brushes.Black, 1, Y)
                Y += 25
                ' Usa Using para garantizar la liberación de recursos de la fuente
                e.Graphics.DrawString("Realiza tu factura aqui", fuente_c, Brushes.Black, 1, Y)
                Y += 10
                ' Dibuja la imagen en el contexto gráfico
                e.Graphics.DrawImage(picQR.Image, 83, CInt(Y + 15), 85, 85)
                Y += 20
                picQR.Image.Dispose()
            End If

        Else

        End If

        e.HasMorePages = False
        cnn4.Close()
        cnn3.Close()
    End Sub

    Private Sub Productos(ByVal depto As String, ByVal grupo As String)
        Dim prods As Integer = 1
        Dim cuantos As UInteger = Math.Truncate(pproductos.Height / 70)

        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre,Codigo FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre,Codigo"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    totProductos = totProductos + 1
                End If
            Loop
            rd3.Close()

            If totProductos <= 10 Then
                pproductos.AutoScroll = False
            Else
                pproductos.AutoScroll = True
            End If

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre,Codigo FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre,Codigo"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    Dim producto As String = rd3(0).ToString
                    btnProd = New Button
                    btnProd.Text = producto
                    btnProd.Tag = rd3(1).ToString
                    btnProd.Name = "btnProducto(" & prods & ")"
                    btnProd.Height = 70
                    btnProd.Width = 130

                    If prods > cuantos And prods < ((cuantos * 2) + 1) Then
                        btnProd.Left = (btnProd.Width * 1)
                        btnProd.Top = (prods - (cuantos + 1)) * (btnProd.Height + 0.5)
                        '2
                    ElseIf prods > (cuantos * 2) And prods < ((cuantos * 3) + 1) Then
                        btnProd.Left = (btnProd.Width * 2)
                        btnProd.Top = (prods - ((cuantos * 2) + 1)) * (btnProd.Height + 0.5)
                        '3
                    ElseIf prods > (cuantos * 3) And prods < ((cuantos * 4) + 1) Then
                        btnProd.Left = (btnProd.Width * 3)
                        btnProd.Top = (prods - ((cuantos * 3) + 1)) * (btnProd.Height + 0.5)
                        '4
                    ElseIf prods > (cuantos * 4) And prods < ((cuantos * 5) + 1) Then
                        btnProd.Left = (btnProd.Width * 4)
                        btnProd.Top = (prods - ((cuantos * 4) + 1)) * (btnProd.Height + 0.5)
                        '5
                    ElseIf prods > (cuantos * 5) And prods < ((cuantos * 6) + 1) Then
                        btnProd.Left = (btnProd.Width * 5)
                        btnProd.Top = (prods - ((cuantos * 5) + 1)) * (btnProd.Height + 0.5)
                        '6
                    ElseIf prods > (cuantos * 6) And prods < ((cuantos * 7) + 1) Then
                        btnProd.Left = (btnProd.Width * 6)
                        btnProd.Top = (prods - ((cuantos * 6) + 1)) * (btnProd.Height + 0.5)
                        '7
                    ElseIf prods > (cuantos * 7) And prods < ((cuantos * 8) + 1) Then
                        btnProd.Left = (btnProd.Width * 7)
                        btnProd.Top = (prods - ((cuantos * 7) + 1)) * (btnProd.Height + 0.5)
                        '8
                    ElseIf prods > (cuantos * 8) And prods < ((cuantos * 9) + 1) Then
                        btnProd.Left = (btnProd.Width * 8)
                        btnProd.Top = (prods - ((cuantos * 8) + 1)) * (btnProd.Height + 0.5)
                        '9
                    ElseIf prods > (cuantos * 9) And prods < ((cuantos * 10) + 1) Then
                        btnProd.Left = (btnProd.Width * 9)
                        btnProd.Top = (prods - ((cuantos * 9) + 1)) * (btnProd.Height + 0.5)
                        '10
                    ElseIf prods > (cuantos * 10) And prods < ((cuantos * 11) + 1) Then
                        btnProd.Left = (btnProd.Width * 10)
                        btnProd.Top = (prods - ((cuantos * 10) + 1)) * (btnProd.Height + 0.5)
                        '11
                    ElseIf prods > (cuantos * 11) And prods < ((cuantos * 12) + 1) Then
                        btnProd.Left = (btnProd.Width * 11)
                        btnProd.Top = (prods - ((cuantos * 11) + 1)) * (btnProd.Height + 0.5)
                        '12
                    ElseIf prods > (cuantos * 12) And prods < ((cuantos * 13) + 1) Then
                        btnProd.Left = (btnProd.Width * 12)
                        btnProd.Top = (prods - ((cuantos * 12) + 1)) * (btnProd.Height + 0.5)
                        '13
                    ElseIf prods > (cuantos * 13) And prods < ((cuantos * 14) + 1) Then
                        btnProd.Left = (btnProd.Width * 13)
                        btnProd.Top = (prods - ((cuantos * 13) + 1)) * (btnProd.Height + 0.5)
                        '14
                    ElseIf prods > (cuantos * 14) And prods < ((cuantos * 15) + 1) Then
                        btnProd.Left = (btnProd.Width * 14)
                        btnProd.Top = (prods - ((cuantos * 14) + 1)) * (btnProd.Height + 0.5)
                        '15
                    ElseIf prods > (cuantos * 15) And prods < ((cuantos * 16) + 1) Then
                        btnProd.Left = (btnProd.Width * 15)
                        btnProd.Top = (prods - ((cuantos * 15) + 1)) * (btnProd.Height + 0.5)
                        '16
                    ElseIf prods > (cuantos * 16) And prods < ((cuantos * 17) + 1) Then
                        btnProd.Left = (btnProd.Width * 16)
                        btnProd.Top = (prods - ((cuantos * 16) + 1)) * (btnProd.Height + 0.5)
                        '17
                    ElseIf prods > (cuantos * 17) And prods < ((cuantos * 18) + 1) Then
                        btnProd.Left = (btnProd.Width * 17)
                        btnProd.Top = (prods - ((cuantos * 17) + 1)) * (btnProd.Height + 0.5)
                        '18
                    ElseIf prods > (cuantos * 18) And prods < ((cuantos * 19) + 1) Then
                        btnProd.Left = (btnProd.Width * 18)
                        btnProd.Top = (prods - ((cuantos * 18) + 1)) * (btnProd.Height + 0.5)
                        '19
                    ElseIf prods > (cuantos * 19) And prods < ((cuantos * 20) + 1) Then
                        btnProd.Left = (btnProd.Width * 19)
                        btnProd.Top = (prods - ((cuantos * 19) + 1)) * (btnProd.Height + 0.5)
                        '20
                    ElseIf prods > (cuantos * 20) And prods < ((cuantos * 21) + 1) Then
                        btnProd.Left = (btnProd.Width * 20)
                        btnProd.Top = (prods - ((cuantos * 20) + 1)) * (btnProd.Height + 0.5)
                        '21
                    ElseIf prods > (cuantos * 21) And prods < ((cuantos * 22) + 1) Then
                        btnProd.Left = (btnProd.Width * 21)
                        btnProd.Top = (prods - ((cuantos * 21) + 1)) * (btnProd.Height + 0.5)
                        '22
                    ElseIf prods > (cuantos * 22) And prods < ((cuantos * 23) + 1) Then
                        btnProd.Left = (btnProd.Width * 22)
                        btnProd.Top = (prods - ((cuantos * 22) + 1)) * (btnProd.Height + 0.5)
                        '23
                    ElseIf prods > (cuantos * 23) And prods < ((cuantos * 24) + 1) Then
                        btnProd.Left = (btnProd.Width * 23)
                        btnProd.Top = (prods - ((cuantos * 23) + 1)) * (btnProd.Height + 0.5)
                        '24
                    ElseIf prods > (cuantos * 24) And prods < ((cuantos * 25) + 1) Then
                        btnProd.Left = (btnProd.Width * 24)
                        btnProd.Top = (prods - ((cuantos * 24) + 1)) * (btnProd.Height + 0.5)
                        '25
                    ElseIf prods > (cuantos * 25) And prods < ((cuantos * 26) + 1) Then
                        btnProd.Left = (btnProd.Width * 25)
                        btnProd.Top = (prods - ((cuantos * 25) + 1)) * (btnProd.Height + 0.5)
                        '26
                    ElseIf prods > (cuantos * 26) And prods < ((cuantos * 27) + 1) Then
                        btnProd.Left = (btnProd.Width * 26)
                        btnProd.Top = (prods - ((cuantos * 26) + 1)) * (btnProd.Height + 0.5)
                        '27
                    ElseIf prods > (cuantos * 27) And prods < ((cuantos * 28) + 1) Then
                        btnProd.Left = (btnProd.Width * 27)
                        btnProd.Top = (prods - ((cuantos * 27) + 1)) * (btnProd.Height + 0.5)
                        '28
                    ElseIf prods > (cuantos * 28) And prods < ((cuantos * 29) + 1) Then
                        btnProd.Left = (btnProd.Width * 28)
                        btnProd.Top = (prods - ((cuantos * 28) + 1)) * (btnProd.Height + 0.5)
                        '29
                    ElseIf prods > (cuantos * 29) And prods < ((cuantos * 30) + 1) Then
                        btnProd.Left = (btnProd.Width * 29)
                        btnProd.Top = (prods - ((cuantos * 29) + 1)) * (btnProd.Height + 0.5)
                        '30
                    ElseIf prods > (cuantos * 30) And prods < ((cuantos * 31) + 1) Then
                        btnProd.Left = (btnProd.Width * 30)
                        btnProd.Top = (prods - ((cuantos * 30) + 1)) * (btnProd.Height + 0.5)
                        '31
                    ElseIf prods > (cuantos * 31) And prods < ((cuantos * 32) + 1) Then
                        btnProd.Left = (btnProd.Width * 31)
                        btnProd.Top = (prods - ((cuantos * 31) + 1)) * (btnProd.Height + 0.5)
                        '32
                    ElseIf prods > (cuantos * 32) And prods < ((cuantos * 33) + 1) Then
                        btnProd.Left = (btnProd.Width * 32)
                        btnProd.Top = (prods - ((cuantos * 32) + 1)) * (btnProd.Height + 0.5)
                        '33
                    ElseIf prods > (cuantos * 33) And prods < ((cuantos * 34) + 1) Then
                        btnProd.Left = (btnProd.Width * 33)
                        btnProd.Top = (prods - ((cuantos * 33) + 1)) * (btnProd.Height + 0.5)
                        '34
                    ElseIf prods > (cuantos * 34) And prods < ((cuantos * 35) + 1) Then
                        btnProd.Left = (btnProd.Width * 34)
                        btnProd.Top = (prods - ((cuantos * 34) + 1)) * (btnProd.Height + 0.5)
                        '35
                    ElseIf prods > (cuantos * 35) And prods < ((cuantos * 36) + 1) Then
                        btnProd.Left = (btnProd.Width * 35)
                        btnProd.Top = (prods - ((cuantos * 35) + 1)) * (btnProd.Height + 0.5)
                        '36
                    ElseIf prods > (cuantos * 36) And prods < ((cuantos * 37) + 1) Then
                        btnProd.Left = (btnProd.Width * 36)
                        btnProd.Top = (prods - ((cuantos * 36) + 1)) * (btnProd.Height + 0.5)
                        '37
                    ElseIf prods > (cuantos * 37) And prods < ((cuantos * 38) + 1) Then
                        btnProd.Left = (btnProd.Width * 37)
                        btnProd.Top = (prods - ((cuantos * 37) + 1)) * (btnProd.Height + 0.5)
                        '38
                    ElseIf prods > (cuantos * 38) And prods < ((cuantos * 39) + 1) Then
                        btnProd.Left = (btnProd.Width * 38)
                        btnProd.Top = (prods - ((cuantos * 38) + 1)) * (btnProd.Height + 0.5)
                        '39
                    ElseIf prods > (cuantos * 39) And prods < ((cuantos * 40) + 1) Then
                        btnProd.Left = (btnProd.Width * 39)
                        btnProd.Top = (prods - ((cuantos * 39) + 1)) * (btnProd.Height + 0.5)
                        '40
                    ElseIf prods > (cuantos * 40) And prods < ((cuantos * 41) + 1) Then
                        btnProd.Left = (btnProd.Width * 40)
                        btnProd.Top = (prods - ((cuantos * 40) + 1)) * (btnProd.Height + 0.5)
                        '41
                    ElseIf prods > (cuantos * 41) And prods < ((cuantos * 42) + 1) Then
                        btnProd.Left = (btnProd.Width * 41)
                        btnProd.Top = (prods - ((cuantos * 41) + 1)) * (btnProd.Height + 0.5)
                        '42
                    ElseIf prods > (cuantos * 42) And prods < ((cuantos * 43) + 1) Then
                        btnProd.Left = (btnProd.Width * 42)
                        btnProd.Top = (prods - ((cuantos * 42) + 1)) * (btnProd.Height + 0.5)
                        '43
                    ElseIf prods > (cuantos * 43) And prods < ((cuantos * 44) + 1) Then
                        btnProd.Left = (btnProd.Width * 43)
                        btnProd.Top = (prods - ((cuantos * 43) + 1)) * (btnProd.Height + 0.5)
                        '44
                    ElseIf prods > (cuantos * 44) And prods < ((cuantos * 45) + 1) Then
                        btnProd.Left = (btnProd.Width * 44)
                        btnProd.Top = (prods - ((cuantos * 44) + 1)) * (btnProd.Height + 0.5)
                        '45
                    ElseIf prods > (cuantos * 45) And prods < ((cuantos * 46) + 1) Then
                        btnProd.Left = (btnProd.Width * 45)
                        btnProd.Top = (prods - ((cuantos * 45) + 1)) * (btnProd.Height + 0.5)
                        '46
                    ElseIf prods > (cuantos * 46) And prods < ((cuantos * 47) + 1) Then
                        btnProd.Left = (btnProd.Width * 46)
                        btnProd.Top = (prods - ((cuantos * 46) + 1)) * (btnProd.Height + 0.5)
                        '47
                    ElseIf prods > (cuantos * 47) And prods < ((cuantos * 48) + 1) Then
                        btnProd.Left = (btnProd.Width * 47)
                        btnProd.Top = (prods - ((cuantos * 47) + 1)) * (btnProd.Height + 0.5)
                        '48
                    ElseIf prods > (cuantos * 48) And prods < ((cuantos * 49) + 1) Then
                        btnProd.Left = (btnProd.Width * 48)
                        btnProd.Top = (prods - ((cuantos * 48) + 1)) * (btnProd.Height + 0.5)
                        '49
                    ElseIf prods > (cuantos * 49) And prods < ((cuantos * 50) + 1) Then
                        btnProd.Left = (btnProd.Width * 49)
                        btnProd.Top = (prods - ((cuantos * 49) + 1)) * (btnProd.Height + 0.5)
                        '50
                    ElseIf prods > (cuantos * 50) And prods < ((cuantos * 51) + 1) Then
                        btnProd.Left = (btnProd.Width * 50)
                        btnProd.Top = (prods - ((cuantos * 50) + 1)) * (btnProd.Height + 0.5)
                        '51
                    ElseIf prods > (cuantos * 51) And prods < ((cuantos * 52) + 1) Then
                        btnProd.Left = (btnProd.Width * 51)
                        btnProd.Top = (prods - ((cuantos * 51) + 1)) * (btnProd.Height + 0.5)
                        '52
                    ElseIf prods > (cuantos * 52) And prods < ((cuantos * 53) + 1) Then
                        btnProd.Left = (btnProd.Width * 52)
                        btnProd.Top = (prods - ((cuantos * 52) + 1)) * (btnProd.Height + 0.5)
                        '53
                    ElseIf prods > (cuantos * 53) And prods < ((cuantos * 54) + 1) Then
                        btnProd.Left = (btnProd.Width * 53)
                        btnProd.Top = (prods - ((cuantos * 53) + 1)) * (btnProd.Height + 0.5)
                        '54
                    ElseIf prods > (cuantos * 54) And prods < ((cuantos * 55) + 1) Then
                        btnProd.Left = (btnProd.Width * 54)
                        btnProd.Top = (prods - ((cuantos * 54) + 1)) * (btnProd.Height + 0.5)
                        '55
                    ElseIf prods > (cuantos * 55) And prods < ((cuantos * 56) + 1) Then
                        btnProd.Left = (btnProd.Width * 55)
                        btnProd.Top = (prods - ((cuantos * 55) + 1)) * (btnProd.Height + 0.5)
                        '56
                    ElseIf prods > (cuantos * 56) And prods < ((cuantos * 57) + 1) Then
                        btnProd.Left = (btnProd.Width * 56)
                        btnProd.Top = (prods - ((cuantos * 56) + 1)) * (btnProd.Height + 0.5)
                        '57
                    ElseIf prods > (cuantos * 57) And prods < ((cuantos * 58) + 1) Then
                        btnProd.Left = (btnProd.Width * 57)
                        btnProd.Top = (prods - ((cuantos * 57) + 1)) * (btnProd.Height + 0.5)
                        '58
                    ElseIf prods > (cuantos * 58) And prods < ((cuantos * 59) + 1) Then
                        btnProd.Left = (btnProd.Width * 58)
                        btnProd.Top = (prods - ((cuantos * 58) + 1)) * (btnProd.Height + 0.5)
                        '59
                    ElseIf prods > (cuantos * 59) And prods < ((cuantos * 60) + 1) Then
                        btnProd.Left = (btnProd.Width * 59)
                        btnProd.Top = (prods - ((cuantos * 59) + 1)) * (btnProd.Height + 0.5)
                        '60
                    ElseIf prods > (cuantos * 60) And prods < ((cuantos * 61) + 1) Then
                        btnProd.Left = (btnProd.Width * 60)
                        btnProd.Top = (prods - ((cuantos * 60) + 1)) * (btnProd.Height + 0.5)
                        '61
                    ElseIf prods > (cuantos * 61) And prods < ((cuantos * 62) + 1) Then
                        btnProd.Left = (btnProd.Width * 61)
                        btnProd.Top = (prods - ((cuantos * 61) + 1)) * (btnProd.Height + 0.5)
                        '62
                    ElseIf prods > (cuantos * 62) And prods < ((cuantos * 63) + 1) Then
                        btnProd.Left = (btnProd.Width * 62)
                        btnProd.Top = (prods - ((cuantos * 62) + 1)) * (btnProd.Height + 0.5)
                        '63
                    ElseIf prods > (cuantos * 63) And prods < ((cuantos * 64) + 1) Then
                        btnProd.Left = (btnProd.Width * 63)
                        btnProd.Top = (prods - ((cuantos * 63) + 1)) * (btnProd.Height + 0.5)
                        '64
                    ElseIf prods > (cuantos * 64) And prods < ((cuantos * 65) + 1) Then
                        btnProd.Left = (btnProd.Width * 64)
                        btnProd.Top = (prods - ((cuantos * 64) + 1)) * (btnProd.Height + 0.5)
                        '65
                    ElseIf prods > (cuantos * 65) And prods < ((cuantos * 66) + 1) Then
                        btnProd.Left = (btnProd.Width * 65)
                        btnProd.Top = (prods - ((cuantos * 65) + 1)) * (btnProd.Height + 0.5)
                        '66
                    ElseIf prods > (cuantos * 66) And prods < ((cuantos * 67) + 1) Then
                        btnProd.Left = (btnProd.Width * 66)
                        btnProd.Top = (prods - ((cuantos * 66) + 1)) * (btnProd.Height + 0.5)
                        '67
                    ElseIf prods > (cuantos * 67) And prods < ((cuantos * 68) + 1) Then
                        btnProd.Left = (btnProd.Width * 67)
                        btnProd.Top = (prods - ((cuantos * 67) + 1)) * (btnProd.Height + 0.5)
                        '68
                    ElseIf prods > (cuantos * 68) And prods < ((cuantos * 69) + 1) Then
                        btnProd.Left = (btnProd.Width * 68)
                        btnProd.Top = (prods - ((cuantos * 68) + 1)) * (btnProd.Height + 0.5)
                        '69
                    ElseIf prods > (cuantos * 69) And prods < ((cuantos * 70) + 1) Then
                        btnProd.Left = (btnProd.Width * 69)
                        btnProd.Top = (prods - ((cuantos * 69) + 1)) * (btnProd.Height + 0.5)
                        '70
                    ElseIf prods > (cuantos * 70) And prods < ((cuantos * 71) + 1) Then
                        btnProd.Left = (btnProd.Width * 70)
                        btnProd.Top = (prods - ((cuantos * 70) + 1)) * (btnProd.Height + 0.5)
                        '71
                    ElseIf prods > (cuantos * 71) And prods < ((cuantos * 72) + 1) Then
                        btnProd.Left = (btnProd.Width * 71)
                        btnProd.Top = (prods - ((cuantos * 71) + 1)) * (btnProd.Height + 0.5)
                        '72
                    ElseIf prods > (cuantos * 72) And prods < ((cuantos * 73) + 1) Then
                        btnProd.Left = (btnProd.Width * 72)
                        btnProd.Top = (prods - ((cuantos * 72) + 1)) * (btnProd.Height + 0.5)
                        '73
                    ElseIf prods > (cuantos * 73) And prods < ((cuantos * 74) + 1) Then
                        btnProd.Left = (btnProd.Width * 73)
                        btnProd.Top = (prods - ((cuantos * 73) + 1)) * (btnProd.Height + 0.5)
                        '74
                    ElseIf prods > (cuantos * 74) And prods < ((cuantos * 75) + 1) Then
                        btnProd.Left = (btnProd.Width * 74)
                        btnProd.Top = (prods - ((cuantos * 74) + 1)) * (btnProd.Height + 0.5)
                        '75
                    ElseIf prods > (cuantos * 75) And prods < ((cuantos * 76) + 1) Then
                        btnProd.Left = (btnProd.Width * 75)
                        btnProd.Top = (prods - ((cuantos * 75) + 1)) * (btnProd.Height + 0.5)
                        '76
                    ElseIf prods > (cuantos * 76) And prods < ((cuantos * 77) + 1) Then
                        btnProd.Left = (btnProd.Width * 76)
                        btnProd.Top = (prods - ((cuantos * 76) + 1)) * (btnProd.Height + 0.5)
                        '77
                    ElseIf prods > (cuantos * 77) And prods < ((cuantos * 78) + 1) Then
                        btnProd.Left = (btnProd.Width * 77)
                        btnProd.Top = (prods - ((cuantos * 77) + 1)) * (btnProd.Height + 0.5)
                        '78
                    ElseIf prods > (cuantos * 78) And prods < ((cuantos * 79) + 1) Then
                        btnProd.Left = (btnProd.Width * 78)
                        btnProd.Top = (prods - ((cuantos * 78) + 1)) * (btnProd.Height + 0.5)
                        '79
                    ElseIf prods > (cuantos * 79) And prods < ((cuantos * 80) + 1) Then
                        btnProd.Left = (btnProd.Width * 79)
                        btnProd.Top = (prods - ((cuantos * 79) + 1)) * (btnProd.Height + 0.5)
                        '80
                    ElseIf prods > (cuantos * 80) And prods < ((cuantos * 81) + 1) Then
                        btnProd.Left = (btnProd.Width * 80)
                        btnProd.Top = (prods - ((cuantos * 80) + 1)) * (btnProd.Height + 0.5)
                        '81
                    ElseIf prods > (cuantos * 81) And prods < ((cuantos * 82) + 1) Then
                        btnProd.Left = (btnProd.Width * 81)
                        btnProd.Top = (prods - ((cuantos * 81) + 1)) * (btnProd.Height + 0.5)
                        '82
                    ElseIf prods > (cuantos * 82) And prods < ((cuantos * 83) + 1) Then
                        btnProd.Left = (btnProd.Width * 82)
                        btnProd.Top = (prods - ((cuantos * 82) + 1)) * (btnProd.Height + 0.5)
                        '83
                    ElseIf prods > (cuantos * 83) And prods < ((cuantos * 84) + 1) Then
                        btnProd.Left = (btnProd.Width * 83)
                        btnProd.Top = (prods - ((cuantos * 83) + 1)) * (btnProd.Height + 0.5)
                        '84
                    ElseIf prods > (cuantos * 84) And prods < ((cuantos * 85) + 1) Then
                        btnProd.Left = (btnProd.Width * 84)
                        btnProd.Top = (prods - ((cuantos * 84) + 1)) * (btnProd.Height + 0.5)
                        '85
                    ElseIf prods > (cuantos * 85) And prods < ((cuantos * 86) + 1) Then
                        btnProd.Left = (btnProd.Width * 85)
                        btnProd.Top = (prods - ((cuantos * 85) + 1)) * (btnProd.Height + 0.5)
                        '86
                    ElseIf prods > (cuantos * 86) And prods < ((cuantos * 87) + 1) Then
                        btnProd.Left = (btnProd.Width * 86)
                        btnProd.Top = (prods - ((cuantos * 86) + 1)) * (btnProd.Height + 0.5)
                        '87
                    ElseIf prods > (cuantos * 87) And prods < ((cuantos * 88) + 1) Then
                        btnProd.Left = (btnProd.Width * 87)
                        btnProd.Top = (prods - ((cuantos * 87) + 1)) * (btnProd.Height + 0.5)
                        '88
                    ElseIf prods > (cuantos * 88) And prods < ((cuantos * 89) + 1) Then
                        btnProd.Left = (btnProd.Width * 88)
                        btnProd.Top = (prods - ((cuantos * 88) + 1)) * (btnProd.Height + 0.5)
                        '89
                    ElseIf prods > (cuantos * 89) And prods < ((cuantos * 90) + 1) Then
                        btnProd.Left = (btnProd.Width * 89)
                        btnProd.Top = (prods - ((cuantos * 89) + 1)) * (btnProd.Height + 0.5)
                        '90
                    ElseIf prods > (cuantos * 90) And prods < ((cuantos * 91) + 1) Then
                        btnProd.Left = (btnProd.Width * 90)
                        btnProd.Top = (prods - ((cuantos * 90) + 1)) * (btnProd.Height + 0.5)
                        '91
                    ElseIf prods > (cuantos * 91) And prods < ((cuantos * 92) + 1) Then
                        btnProd.Left = (btnProd.Width * 91)
                        btnProd.Top = (prods - ((cuantos * 91) + 1)) * (btnProd.Height + 0.5)
                        '92
                    ElseIf prods > (cuantos * 92) And prods < ((cuantos * 93) + 1) Then
                        btnProd.Left = (btnProd.Width * 92)
                        btnProd.Top = (prods - ((cuantos * 92) + 1)) * (btnProd.Height + 0.5)
                        '93
                    ElseIf prods > (cuantos * 93) And prods < ((cuantos * 94) + 1) Then
                        btnProd.Left = (btnProd.Width * 93)
                        btnProd.Top = (prods - ((cuantos * 93) + 1)) * (btnProd.Height + 0.5)
                        '94
                    ElseIf prods > (cuantos * 94) And prods < ((cuantos * 95) + 1) Then
                        btnProd.Left = (btnProd.Width * 94)
                        btnProd.Top = (prods - ((cuantos * 94) + 1)) * (btnProd.Height + 0.5)
                        '95
                    ElseIf prods > (cuantos * 95) And prods < ((cuantos * 96) + 1) Then
                        btnProd.Left = (btnProd.Width * 95)
                        btnProd.Top = (prods - ((cuantos * 95) + 1)) * (btnProd.Height + 0.5)
                        '96
                    ElseIf prods > (cuantos * 96) And prods < ((cuantos * 97) + 1) Then
                        btnProd.Left = (btnProd.Width * 96)
                        btnProd.Top = (prods - ((cuantos * 96) + 1)) * (btnProd.Height + 0.5)
                        '97
                    ElseIf prods > (cuantos * 97) And prods < ((cuantos * 98) + 1) Then
                        btnProd.Left = (btnProd.Width * 97)
                        btnProd.Top = (prods - ((cuantos * 97) + 1)) * (btnProd.Height + 0.5)
                        '98
                    ElseIf prods > (cuantos * 98) And prods < ((cuantos * 99) + 1) Then
                        btnProd.Left = (btnProd.Width * 98)
                        btnProd.Top = (prods - ((cuantos * 98) + 1)) * (btnProd.Height + 0.5)
                        '99
                    ElseIf prods > (cuantos * 99) And prods < ((cuantos * 100) + 1) Then
                        btnProd.Left = (btnProd.Width * 99)
                        btnProd.Top = (prods - ((cuantos * 99) + 1)) * (btnProd.Height + 0.5)
                        '100
                    ElseIf prods > (cuantos * 100) And prods < ((cuantos * 101) + 1) Then
                        btnProd.Left = (btnProd.Width * 100)
                        btnProd.Top = (prods - ((cuantos * 100) + 1)) * (btnProd.Height + 0.5)
                        '101
                    ElseIf prods > (cuantos * 101) And prods < ((cuantos * 102) + 1) Then
                        btnProd.Left = (btnProd.Width * 101)
                        btnProd.Top = (prods - ((cuantos * 101) + 1)) * (btnProd.Height + 0.5)
                        '102
                    ElseIf prods > (cuantos * 102) And prods < ((cuantos * 103) + 1) Then
                        btnProd.Left = (btnProd.Width * 102)
                        btnProd.Top = (prods - ((cuantos * 102) + 1)) * (btnProd.Height + 0.5)
                        '103
                    ElseIf prods > (cuantos * 103) And prods < ((cuantos * 104) + 1) Then
                        btnProd.Left = (btnProd.Width * 103)
                        btnProd.Top = (prods - ((cuantos * 103) + 1)) * (btnProd.Height + 0.5)
                        '104
                    ElseIf prods > (cuantos * 104) And prods < ((cuantos * 105) + 1) Then
                        btnProd.Left = (btnProd.Width * 104)
                        btnProd.Top = (prods - ((cuantos * 104) + 1)) * (btnProd.Height + 0.5)
                        '105
                    ElseIf prods > (cuantos * 105) And prods < ((cuantos * 106) + 1) Then
                        btnProd.Left = (btnProd.Width * 105)
                        btnProd.Top = (prods - ((cuantos * 105) + 1)) * (btnProd.Height + 0.5)
                        '106
                    ElseIf prods > (cuantos * 106) And prods < ((cuantos * 107) + 1) Then
                        btnProd.Left = (btnProd.Width * 106)
                        btnProd.Top = (prods - ((cuantos * 106) + 1)) * (btnProd.Height + 0.5)
                        '107
                    ElseIf prods > (cuantos * 107) And prods < ((cuantos * 108) + 1) Then
                        btnProd.Left = (btnProd.Width * 107)
                        btnProd.Top = (prods - ((cuantos * 107) + 1)) * (btnProd.Height + 0.5)

                    Else
                        btnProd.Left = 0
                        btnProd.Top = (prods - 1) * (btnProd.Height + 0.5)
                    End If

                    btnProd.BackColor = Color.Orange
                    btnProd.FlatStyle = FlatStyle.Popup
                    btnProd.FlatAppearance.BorderSize = 0

                    If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & rd3(1).ToString & ".jpg") Then
                        btnProd.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & rd3(1).ToString & ".jpg")
                        btnProd.BackgroundImageLayout = ImageLayout.Stretch
                        btnProd.TextAlign = ContentAlignment.BottomCenter
                        btnProd.ForeColor = Color.White
                    End If

                    AddHandler btnProd.Click, AddressOf btnProd_Click
                    pproductos.Controls.Add(btnProd)
                    If prods = 0 Then
                        Preferencias(producto)
                        Extras(producto)
                    End If
                    prods += 1
                End If
            Loop
            rd3.Close()
            cnn3.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Sub Preferencias(ByVal producto As String)
        Dim preferencia As Integer = 1
        Dim cuantospre As UInteger = Math.Truncate(pPreferencia.Height / 90)

        Try
            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT DISTINCT NombrePrefe FROM Preferencia WHERE Codigo='" & CodigoProducto & "' order by NombrePrefe asc"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then totpreferencia = totpreferencia + 1
            Loop
            rd4.Close()

            If totpreferencia <= 4 Then
                pPreferencia.AutoScroll = False
            Else
                pPreferencia.AutoScroll = True - 17
            End If

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT DISTINCT NombrePrefe FROM Preferencia WHERE Codigo='" & producto & "' order by NombrePrefe asc"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then
                    Dim preferencias As String = rd4(0).ToString

                    btnPrefe = New Button
                    btnPrefe.Text = preferencias
                    btnPrefe.Name = "btnPrefe(" & preferencia & ")"
                    btnPrefe.Width = 90
                    btnPrefe.Height = 70

                    If preferencia > cuantospre And preferencia < ((cuantospre * 2) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 1)
                        btnPrefe.Top = (preferencia - (cuantospre + 1)) * (btnPrefe.Height + 0.5)
                        '2
                    ElseIf preferencia > (cuantospre * 2) And preferencia < ((cuantospre * 3) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 2)
                        btnPrefe.Top = (preferencia - ((cuantospre * 2) + 1)) * (btnPrefe.Height + 0.5)
                        '3
                    ElseIf preferencia > (cuantospre * 3) And preferencia < ((cuantospre * 4) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 3)
                        btnPrefe.Top = (preferencia - ((cuantospre * 3) + 1)) * (btnPrefe.Height + 0.5)
                        '4
                    ElseIf preferencia > (cuantospre * 4) And preferencia < ((cuantospre * 5) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 4)
                        btnPrefe.Top = (preferencia - ((cuantospre * 4) + 1)) * (btnPrefe.Height + 0.5)
                        '5
                    ElseIf preferencia > (cuantospre * 5) And preferencia < ((cuantospre * 6) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 5)
                        btnPrefe.Top = (preferencia - ((cuantospre * 5) + 1)) * (btnPrefe.Height + 0.5)
                        '6
                    ElseIf preferencia > (cuantospre * 6) And preferencia < ((cuantospre * 7) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 6)
                        btnPrefe.Top = (preferencia - ((cuantospre * 6) + 1)) * (btnPrefe.Height + 0.5)
                        '7
                    ElseIf preferencia > (cuantospre * 7) And preferencia < ((cuantospre * 8) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 7)
                        btnPrefe.Top = (preferencia - ((cuantospre * 7) + 1)) * (btnPrefe.Height + 0.5)
                        '8
                    ElseIf preferencia > (cuantospre * 8) And preferencia < ((cuantospre * 9) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 8)
                        btnPrefe.Top = (preferencia - ((cuantospre * 8) + 1)) * (btnPrefe.Height + 0.5)
                        '9
                    ElseIf preferencia > (cuantospre * 9) And preferencia < ((cuantospre * 10) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 9)
                        btnPrefe.Top = (preferencia - ((cuantospre * 9) + 1)) * (btnPrefe.Height + 0.5)
                        '10
                    ElseIf preferencia > (cuantospre * 10) And preferencia < ((cuantospre * 11) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 10)
                        btnPrefe.Top = (preferencia - ((cuantospre * 10) + 1)) * (btnPrefe.Height + 0.5)
                    Else
                        btnPrefe.Left = 0
                        btnPrefe.Top = (preferencia - 1) * (btnPrefe.Height + 0.5)
                    End If

                    btnPrefe.BackColor = Color.Orange
                    btnPrefe.FlatStyle = FlatStyle.Flat
                    btnPrefe.FlatAppearance.BorderSize = 1
                    AddHandler btnPrefe.Click, AddressOf btnPrefe_click
                    pPreferencia.Controls.Add(btnPrefe)
                    preferencia += 1
                End If
            Loop
            rd4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
    End Sub

    Private Sub btnPrefe_click(sender As Object, e As EventArgs)

        Dim btnPreferencia As Button = CType(sender, Button)
        nombrepreferencia = btnPreferencia.Text

        With Me.grdCaptura

            Dim totalnuevo As Double = 0

            For q As Integer = 0 To grdCaptura.Rows.Count - 1

                If grdCaptura.Rows(q).Cells(0).Value = CodigoProducto Then

                    grdCaptura.Rows(q).Cells(7).Value = nombrepreferencia


                End If
            Next q
        End With
    End Sub

    Public Sub Extras(ByVal producto As String)

        Try
            Dim cuantosextras As UInteger = Math.Truncate(pExtras.Height / 90)
            Dim extras As Integer = 1

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Descx,Codigo FROM extras WHERE CodigoAlpha='" & producto & "' order by Descx"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then totextras = totextras + 1
            Loop
            rd1.Close()

            If totextras <= 7 Then
                pExtras.AutoScroll = False
            Else
                pExtras.AutoScroll = True - 17
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Descx,Codigo FROM    Extras WHERE CodigoAlpha='" & producto & "' order by Descx"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim extra As String = rd1(0).ToString

                    btnExtra = New Button
                    btnExtra.Text = extra
                    btnExtra.Tag = rd1(1).ToString
                    btnExtra.Name = "btnExtra(" & extras & ")"
                    btnExtra.Width = 90
                    btnExtra.Height = 70

                    If extras > cuantosextras And extras < ((cuantosextras * 2) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 1)
                        btnExtra.Top = (extras - (cuantosextras + 1)) * (btnExtra.Height + 0.5)
                        '2
                    ElseIf extras > (cuantosextras * 2) And extras < ((cuantosextras * 3) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 2)
                        btnExtra.Top = (extras - ((cuantosextras * 2) + 1)) * (btnExtra.Height + 0.5)
                        '3
                    ElseIf extras > (cuantosextras * 3) And extras < ((cuantosextras * 4) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 3)
                        btnExtra.Top = (extras - ((cuantosextras * 3) + 1)) * (btnExtra.Height + 0.5)
                        '4
                    ElseIf extras > (cuantosextras * 4) And extras < ((cuantosextras * 5) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 4)
                        btnExtra.Top = (extras - ((cuantosextras * 4) + 1)) * (btnExtra.Height + 0.5)
                        '5
                    ElseIf extras > (cuantosextras * 5) And extras < ((cuantosextras * 6) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 5)
                        btnExtra.Top = (extras - ((cuantosextras * 5) + 1)) * (btnExtra.Height + 0.5)
                    Else
                        btnExtra.Left = 0
                        btnExtra.Top = (extras - 1) * (btnExtra.Height + 0.5)
                    End If

                    btnExtra.BackColor = Color.Orange
                    btnExtra.FlatStyle = FlatStyle.Flat
                    btnExtra.FlatAppearance.BorderSize = 1
                    AddHandler btnExtra.Click, AddressOf btnExtra_Click
                    pExtras.Controls.Add(btnExtra)
                    extras += 1

                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnExtra_Click(sender As Object, e As EventArgs)

        Dim btnExt As Button = CType(sender, Button)
        CodigoProducto = btnExt.Tag

        ObtenerProducto(CodigoProducto)
    End Sub

    Public Sub Promociones(ByVal producto As String)

        Dim promocion As Integer = 1
        Dim cuantospro As Integer = Math.Truncate(pPromociones.Height / 70)

        If cantidadPromo = 0 Then

            cantpromo = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select * from Productos where Codigo = '" & CodigoProducto & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cantidadPromo = CDec(IIf(rd1("F44").ToString = "", "0", rd1("F44").ToString))
                Else
                    cantidadPromo = 1
                End If
            Else
                cantidadPromo = 1
            End If
            rd1.Close()
            cnn1.Close()

        End If


        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT count(Id) FROM Promociones WHERE CodigoAlpha='" & producto & "' order by Descx"
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then TotPromociones = TotPromociones + 1
        Loop
        rd2.Close()

        If TotPromociones <= 10 Then
            pPromociones.AutoScroll = False
        Else
            pPromociones.AutoScroll = True
        End If

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT DISTINCT Descx,Codigo FROM Promociones WHERE CodigoAlpha='" & producto & "' order by Descx"
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then

                Dim promociones As String = rd2(0).ToString
                Dim codigop As String = rd2(1).ToString

                btnPromo = New Button
                btnPromo.Text = promociones
                btnPromo.Tag = codigop
                btnPromo.Name = "btnPromo(" & promocion & ")"
                btnPromo.Height = 70
                btnPromo.Width = 100

                If promocion > cuantospro And promocion < ((cuantospro * 2) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 1)
                    btnPromo.Top = (promocion - (cuantospro + 1)) * (btnPromo.Height + 0.5)
                    '2
                ElseIf promocion > (cuantospro * 2) And promocion < ((cuantospro * 3) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 2)
                    btnPromo.Top = (promocion - ((cuantospro * 2) + 1)) * (btnPromo.Height + 0.5)
                    '3
                ElseIf promocion > (cuantospro * 3) And promocion < ((cuantospro * 4) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 3)
                    btnPromo.Top = (promocion - ((cuantospro * 3) + 1)) * (btnPromo.Height + 0.5)
                    '4
                ElseIf promocion > (cuantospro * 4) And promocion < ((cuantospro * 5) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 4)
                    btnPromo.Top = (promocion - ((cuantospro * 4) + 1)) * (btnPromo.Height + 0.5)
                    '5
                ElseIf promocion > (cuantospro * 5) And promocion < ((cuantospro * 6) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 5)
                    btnPromo.Top = (promocion - ((cuantospro * 5) + 1)) * (btnPromo.Height + 0.5)
                    '6
                ElseIf promocion > (cuantospro * 6) And promocion < ((cuantospro * 7) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 6)
                    btnPromo.Top = (promocion - ((cuantospro * 6) + 1)) * (btnPromo.Height + 0.5)
                    '7
                ElseIf promocion > (cuantospro * 7) And promocion < ((cuantospro * 8) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 7)
                    btnPromo.Top = (promocion - ((cuantospro * 7) + 1)) * (btnPromo.Height + 0.5)
                    '8
                ElseIf promocion > (cuantospro * 8) And promocion < ((cuantospro * 9) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 8)
                    btnPromo.Top = (promocion - ((cuantospro * 8) + 1)) * (btnPromo.Height + 0.5)
                    '9
                ElseIf promocion > (cuantospro * 9) And promocion < ((cuantospro * 10) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 9)
                    btnPromo.Top = (promocion - ((cuantospro * 9) + 1)) * (btnPromo.Height + 0.5)
                    '10
                ElseIf promocion > (cuantospro * 10) And promocion < ((cuantospro * 11) + 1) Then
                    btnPromo.Left = (btnPromo.Width * 10)
                    btnPromo.Top = (promocion - ((cuantospro * 10) + 1)) * (btnPromo.Height + 0.5)
                Else
                    btnPromo.Left = 0
                    btnPromo.Top = (promocion - 1) * (btnPromo.Height + 0.5)
                End If

                btnPromo.BackColor = Color.Orange
                btnPromo.FlatStyle = FlatStyle.Flat
                btnPromo.FlatAppearance.BorderSize = 1
                AddHandler btnPromo.Click, AddressOf btnPromo_Click
                pPromociones.Controls.Add(btnPromo)
                promocion += 1
            End If
        Loop
        rd2.Close()
        cnn2.Close()

    End Sub

    Private Sub btnPromo_Click(sender As Object, e As EventArgs)
        Dim btnPromocion As Button = CType(sender, Button)

        CodigoProducto = btnPromocion.Tag



        If cantpromo < cantidadPromo Then
            PTeclado.Show()
            pletras.Enabled = True
            txtRespuesta.Focus.Equals(True)
            txtRespuesta.Text = ""
            pCampo.Text = "Cantidad"
            CodigoProducto = CodigoProducto
            banderaPROMOCION = 1



        End If

    End Sub

    Public Sub ActualizarImporte()

        Dim MyOpe As Double = 0

        TotalImporte = CDec(lblTotalPagar.Text)
        Cambio = CDbl(lblPagos.Text) - TotalImporte

        If Cambio >= 0 Then
            PorPagar = 0
        Else
            PorPagar = -Cambio
            Cambio = 0
        End If

        lblCambio.Text = FormatNumber(Cambio, 2)
        lblRestaPagar.Text = FormatNumber(PorPagar, 2)


    End Sub

    Public Sub monto_importe()

        montoTotal = 0
        Dim TOTAL As Double = 0
        Dim ZI As Integer = 0
        ZI = 0

        While ZI <> grdCaptura.Rows.Count
            TOTAL = TOTAL + (grdCaptura.Rows(ZI).Cells(4).Value.ToString)
            ZI = ZI + 1
        End While
        montoTotal = TOTAL

    End Sub

    Public Sub GuardarVenta()

        Dim saldomonedero As Double = 0
        Dim porcentajemonedero As Double = 0
        Dim idmonedero As Integer = 0
        Dim clientemonedero As String = ""
        Dim saldonuevo As Double = 0
        Dim foliomonedero As String = ""

        Dim MySubtotal As Double = 0

        Dim codigoproducto As String = ""

        Dim ivaproducto As Double = 0
        Dim SLDOCUENTA As Double = 0
        Dim TOTALADEUDA As Double = 0

        Dim montomonerdero As Double = 0
        Dim formamonedero As String = ""

        Try

            If frmPagarTouch.txtmonedero.Text <> "" Then
                Dim sal_monedero As Double = 0
                Dim tipo_mone As Integer = 0
                Dim porcentaje_mone As Double = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Formatos where Facturas='Porc_Mone'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        tipo_mone = rd1("NumPart").ToString()
                        porcentaje_mone = IIf(rd1("NotasCred").ToString() = "", 0, rd1("NotasCred").ToString())
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Saldo from Monedero WHERE Barras='" & frmPagarTouch.txtmonedero.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sal_monedero = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                    End If
                End If
                rd1.Close()

                Dim porc_mone As Double = 0
                Dim precio_prod As Double = 0
                Dim cantid_prod As Double = 0
                Dim nvo_saldo As Double = 0
                Dim porcentaje As Double = 0
                Dim opee As Double = 0

                Dim total_venta As Double = 0
                Dim total_bono As Double = 0
                'Por venta
                If tipo_mone = 1 Then
                    total_venta = lbltotalventa.Text
                    total_bono = (porcentaje_mone * total_venta) / 100

                    nvo_saldo = total_bono + sal_monedero
                End If

                'Por producto
                If tipo_mone = 0 Then
                    For denji As Integer = 0 To grdCaptura.Rows.Count - 1
                        porc_mone = grdCaptura(14, denji).Value
                        precio_prod = grdCaptura(4, denji).Value
                        cantid_prod = grdCaptura(3, denji).Value

                        total_bono = (porc_mone * precio_prod) / 100
                        opee = opee + (total_bono * cantid_prod)
                    Next
                    nvo_saldo = opee + sal_monedero
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Monedero set Saldo=" & nvo_saldo & " where Barras='" & frmPagarTouch.txtmonedero.Text & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) values('" & frmPagarTouch.txtmonedero.Text & "','Venta'," & opee & "," & total_bono & "," & nvo_saldo & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MYFOLIO & ")"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            End If


            MySubtotal = 0
            Dim ope As Double = 0
            TotalIVAPrint = 0
            ope = 0
            Dim txtconteo As Double = 0


            Dim subtotalventa As Double = 0
            Dim subtotalmap As Double = 0
            Dim ivaproducto2 As Double = 0
            Dim restaiva As Double = 0

            For messi As Integer = 0 To grdCaptura.Rows.Count - 1
                If grdCaptura.Rows(messi).Cells(1).Value <> "" Then
                    codigoproducto = grdCaptura.Rows(messi).Cells(0).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "select IVA from Productos where Codigo='" & codigoproducto & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            ivaproducto = rd1(0).ToString
                            If ivaproducto > 0 Then
                                subtotalmap = grdCaptura.Rows(messi).Cells(4).Value.ToString
                                ivaproducto2 = subtotalmap / (1 + ivaproducto)
                                restaiva = subtotalmap - CDbl(ivaproducto2)
                                TotalIVAPrint = TotalIVAPrint + CDbl(restaiva)
                            End If
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                End If
            Next messi

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 2)

            If lblCliente.Text = "" Then
                If (lblTipoVenta.Text = "MOSTRADOR" And lblRestaPagar.Text <> 0) Then
                    MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom® Restaurant")
                    Exit Sub
                End If

                If lblNumCliente.Text = 0 Then
                    If lblRestaPagar.Text > 0 Then
                        MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, titulomensajes)
                        Exit Sub
                    End If
                End If
            End If


            If grdCaptura.Rows.Count < 1 Then
                Exit Sub
            End If

            If Resta <> 0 Then
                If lblCliente.Text = "" Then
                    MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    frmVentasTouchPago.txtefectivo.Focus().Equals(True)
                    Exit Sub
                End If
            End If


            If MsgBox("Desea guardar los datos de esta venta", vbInformation + vbOKCancel, "Delsscom® Restaurant") = vbCancel Then
                Exit Sub
                frmPagarTouch.btnIntro.Enabled = True
            End If

            Dim Credito_Cliente As Double = 0
            Dim AFavor_Cliente As Double = 0
            Dim Adeuda_Cliente As Double = 0

            cnn1.Close() : cnn1.Open()

            If lblCliente.Text = "" Then
                lblNumCliente.Text = "0"
                Credito_Cliente = 0
                AFavor_Cliente = 0
                Adeuda_Cliente = 0
            Else
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Clientes WHERE Nombre='" & lblCliente.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblNumCliente.Text = rd1("Id").ToString
                        Credito_Cliente = rd1("Credito").ToString
                    End If
                Else
                    lblNumCliente.Text = "0"
                End If
                rd1.Close()

                Dim MySaldo1 As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Saldo FROM Abonoi WHERE Id=(SELECT MAX(Id) from Abonoi WHERE IdCliente=" & lblNumCliente.Text & ")"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo1 = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                        If MySaldo1 < 0 Then
                            Adeuda_Cliente = 0
                            AFavor_Cliente = Math.Abs(MySaldo1)
                            AFavor_Cliente = FormatNumber(AFavor_Cliente, 2)
                        Else
                            AFavor_Cliente = 0
                            Adeuda_Cliente = Math.Abs(MySaldo1)
                            Adeuda_Cliente = FormatNumber(Adeuda_Cliente, 2)
                        End If
                    End If
                Else
                    Adeuda_Cliente = 0
                    AFavor_Cliente = 0
                End If
                rd1.Close()

            End If

            Dim montoefectivo As Double = lblImporteEfectivo.Text
            Dim montopagos As Double = lblPagos.Text
            Dim CAMBIO As Double = lblCambio.Text
            Dim propina As Double = lblPropina.Text

            Dim credito_dispo As Double = (Credito_Cliente + AFavor_Cliente) - ((CDbl(lbltotalventa.Text) + Adeuda_Cliente) - (montoefectivo + montopagos))

            If lblRestaPagar.Text > 0 Then
                If lblTipoVenta.Text <> "MOSTRADOR" And ((CDbl(lbltotalventa.Text) + Adeuda_Cliente) - (montopagos + montoefectivo)) > (Credito_Cliente + AFavor_Cliente) Then
                    MsgBox("No se puede completar la operación porque se rebasaría el crédito disponible." & vbNewLine & "Crédito disponible: " & FormatNumber(Credito_Cliente - Adeuda_Cliente, 2) & ".", vbInformation + vbOKOnly, titulomensajes)
                    cnn1.Close() : frmVentasTouchPago.txtefectivo.Focus().Equals(True) : Exit Sub
                End If
            End If



            Dim MyStatus As String = ""
            Dim ACuenta As Double = 0
            Dim ACUenta2 As Double = 0
            Dim MyMonto As Double = 0


            Dim SubTotal As Double = 0
            Dim IVA_Vent As Double = 0
            Dim Total_Ve As Double = 0
            Dim Descuento As Double = 0
            Dim MontoSDesc As Double = 0

            Dim CodCadena As String = ""
            Dim cadena As String = ""
            Dim ope1 As Double = 0
            Dim Car As Integer = 0

            Dim letters As String = ""
            Dim Numeros As String = ""
            Dim Letras As String = ""
            Dim lic As String = ""

            ope1 = Math.Cos(CDbl(lblfolio.Text))
            If ope1 > 0 Then
                cadena = Strings.Left(Replace(CStr(ope1), ".", "9"), 10)
            Else
                cadena = Strings.Left(Replace(CStr(Math.Abs(ope1)), ".", "8"), 10)
            End If
            For i = 1 To 10
                Car = Mid(cadena, i, 1)
                Select Case Car
                    Case Is = 0
                        letters = letters & "Y"
                    Case Is = 1
                        letters = letters & "Z"
                    Case Is = 2
                        letters = letters & "W"
                    Case Is = 3
                        letters = letters & "H"
                    Case Is = 4
                        letters = letters & "S"
                    Case Is = 5
                        letters = letters & "B"
                    Case Is = 6
                        letters = letters & "C"
                    Case Is = 7
                        letters = letters & "P"
                    Case Is = 8
                        letters = letters & "Q"
                    Case Is = 9
                        letters = letters & "A"
                    Case Else
                        letters = letters & Car
                End Select
            Next
            For w = 1 To 10 Step 2
                Numeros = Mid(lblfolio.Text, w, 4)
                Letras = Mid(letters, w, 4)
                lic = lic & Numeros & Letras & "-"
            Next
            lic = Strings.Left(lic, Len(lic) - 1)
            CodCadena = lic
            cadenafact = Trim(CodCadena)

            Select Case lblTipoVenta.Text
                Case Is = "MOSTRADOR"
                    lblNumCliente.Text = "0"
                    lblCliente.Text = ""

                    ACuenta = FormatNumber((montoefectivo + montopagos) - CAMBIO - lblPropina.Text, 2)
                    MySubtotal = FormatNumber(MySubtotal, 2)

                    If Resta = 0 Then
                        MyStatus = "PAGADO"
                    Else
                        MyStatus = "RESTA"
                    End If

                    If TotalIVAPrint > 0 Then
                        SubTotal = lbltotalventa.Text - TotalIVAPrint
                    Else
                        SubTotal = lbltotalventa.Text
                    End If
                    SubTotal = FormatNumber(SubTotal, 2)
                    Total_Ve = FormatNumber(CDbl(lbltotalventa.Text), 2)
                    Descuento = lblDescuento.Text
                    MontoSDesc = FormatNumber(CDbl(lblTotalPagar.Text) - Descuento, 2)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Comentario,StatusE,IP,Propina,Formato,Fecha) values(" & lblNumCliente.Text & ",'" & lblCliente.Text & "','" & frmPagarTouch.rbtDireccion.Text & "'," & SubTotal & "," & TotalIVAPrint & "," & Total_Ve & "," & Descuento & ",0," & ACuenta & "," & Resta & ",'" & lblAtendio.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','','" & MyStatus & "','',''," & MontoSDesc & ",'','',0,'" & dameIP2() & "'," & propina & ",'TICKET','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                    cmd1.ExecuteNonQuery()

                Case Is <> "MOSTRADOR"
                    MyMonto = montoefectivo + montopagos + AFavor_Cliente
                    MySubtotal = FormatNumber(MySubtotal, 2)

                    If MyMonto > CDbl(lblTotalPagar.Text) Then
                        ACUenta2 = FormatNumber(CDbl(lblTotalPagar.Text), 2)
                        Resta = 0
                    Else
                        ACUenta2 = FormatNumber(MyMonto, 2)
                        Resta = FormatNumber(CDbl(lblTotalPagar.Text) - MyMonto, 2)
                    End If


                    If Resta = 0 Then
                        MyStatus = "PAGADO"
                    Else
                        MyStatus = "RESTA"
                    End If

                    If TotalIVAPrint > 0 Then
                        SubTotal = lbltotalventa.Text - TotalIVAPrint
                    Else
                        SubTotal = lbltotalventa.Text
                    End If
                    Total_Ve = FormatNumber(CDbl(lbltotalventa.Text), 2)
                    Descuento = lblDescuento.Text
                    MontoSDesc = FormatNumber(CDbl(lbltotalventa.Text) - Descuento, 2)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Comentario,StatusE,IP,Formato,Fecha) values(" & lblNumCliente.Text & ",'" & lblCliente.Text & "','" & frmPagarTouch.rbtDireccion.Text & "'," & SubTotal & "," & TotalIVAPrint & "," & Total_Ve & "," & Descuento & ",0," & ACUenta2 & "," & Resta & ",'" & lblAtendio.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','','" & MyStatus & "','',''," & MontoSDesc & ",'','',0,'" & dameIP2() & "','TICKET','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
                    cmd1.ExecuteNonQuery()

            End Select

            If CDec(montomonerdero) > 0 Then
                If CDec(montomonerdero) = CDec(lblTotalPagar.Text) Then
                Else
                    cnn4.Close() : cnn4.Open()
                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "UPDATE Monedero SET Saldo=Saldo + " & saldonuevo & " WHERE Id=" & idmonedero & ""
                    cmd4.ExecuteNonQuery()
                    cnn4.Close()
                End If
            Else

                cnn4.Close() : cnn4.Open()
                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "UPDATE Monedero set Saldo = Saldo + " & saldonuevo & " WHERE Id=" & idmonedero & ""
                cmd4.ExecuteNonQuery()
                cnn4.Close()
            End If


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT MAX(Folio) FROM Ventas WHERE IP='" & dameIP2() & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MYFOLIO = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                End If
            End If
            rd1.Close()
            cnn1.Close() : cnn1.Open()

            Dim MySaldo As Double = 0
            If lblTipoVenta.Text <> "MOSTRADOR" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Saldo FROM Abonoi WHERE Id=(SELECT MAX(Id) FROM Abonoi WHERE IdCliente=" & lblTipoVenta.Text & ")"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + CDbl(lblTotalPagar.Text), 2)
                    End If
                Else
                    MySaldo = FormatNumber(lbltotalventa.Text, 2)
                End If
                rd1.Close()

                If Resta > 0 And AFavor_Cliente > 0 And CDbl(lblTotalPagar.Text) = Resta Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Banco,Referencia,Usuario,MontoSF) values(" & MYFOLIO & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'" & lblPropina.Text & "','','','','" & lblAtendio.Text & "'," & Resta & ")"
                    cmd1.ExecuteNonQuery()
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Banco,Referencia,Usuario) values(" & MYFOLIO & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & "," & lblPropina.Text & ",'','','','" & lblAtendio.Text & "')"
                    cmd1.ExecuteNonQuery()
                End If
            End If

            ACuenta = FormatNumber(montoefectivo + montopagos - CAMBIO - lblPropina.Text, 2)

            If ACuenta > 0 Then
                Dim EfectivoX As Double = FormatNumber(montoefectivo - CAMBIO, 2)

                If frmPagarTouch.grdPagos.Rows.Count > 0 Then

                    For tobi As Integer = 0 To frmPagarTouch.grdPagos.Rows.Count - 1

                        Dim formapago As String = frmPagarTouch.grdPagos.Rows(tobi).Cells(0).Value.ToString
                        Dim bancopago As String = frmPagarTouch.grdPagos.Rows(tobi).Cells(1).Value.ToString
                        Dim referenciapago As String = frmPagarTouch.grdPagos.Rows(tobi).Cells(2).Value.ToString
                        Dim montopago As Double = frmPagarTouch.grdPagos.Rows(tobi).Cells(3).Value.ToString
                        Dim comentariopago As String = frmPagarTouch.grdPagos.Rows(tobi).Cells(5).Value.ToString
                        Dim cuentarefe As String = frmPagarTouch.grdPagos.Rows(tobi).Cells(6).Value.ToString
                        Dim bancorefe As String = frmPagarTouch.grdPagos.Rows(tobi).Cells(7).Value.ToString

                        Dim saldocuenta As Double = 0

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cuentarefe & "')"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                saldocuenta = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) + montopago

                                cnn1.Close() : cnn1.Open()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formapago & "','" & bancopago & "','" & referenciapago & "','VENTA'," & montopago & ",0," & montopago & "," & saldocuenta & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & MYFOLIO & "','" & lblCliente.Text & "','" & comentariopago & "','" & cuentarefe & "','" & bancorefe & "')"
                                cmd1.ExecuteNonQuery()
                                cnn1.Close()
                            End If
                        Else
                            saldocuenta = -montopago

                            cnn1.Close() : cnn1.Open()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formapago & "','" & bancopago & "','" & referenciapago & "','VENTA'," & montopago & ",0," & montopago & "," & saldocuenta & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & MYFOLIO & "','" & lblCliente.Text & "','" & comentariopago & "','" & cuentarefe & "','" & bancorefe & "')"
                            cmd1.ExecuteNonQuery()
                            cnn1.Close()
                        End If
                        rd2.Close()
                        cnn2.Close()


                        Dim nuevopago As Double = 0
                        If lblPropina.Text > 0 Then
                            If EfectivoX > 0 Then
                                nuevopago = montopago
                            Else
                                nuevopago = montopago - lblPropina.Text
                            End If


                        Else
                            nuevopago = montopago
                        End If

                        If formapago = "MONEDERO" Then

                            Dim SALNUVMONEDERO As Double = 0
                            Dim saldomone As Double = 0

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Saldo FROM monedero WHERE Barras='" & referenciapago & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                    saldomone = rd2(0).ToString
                                    SALNUVMONEDERO = saldomone - CDbl(montopago)
                                    SALNUVMONEDERO = FormatNumber(SALNUVMONEDERO, 2)

                                    cnn3.Close() : cnn3.Open()
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "UPDATE monedero set Saldo=" & SALNUVMONEDERO & " WHERE Barras='" & referenciapago & "'"
                                    cmd3.ExecuteNonQuery()

                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "INSERT INTO movmonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) VALUES('" & referenciapago & "','Venta',0," & montopago & "," & SALNUVMONEDERO & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MYFOLIO & ")"
                                    cmd3.ExecuteNonQuery()
                                    cnn3.Close()

                                End If
                            End If
                            rd2.Close()
                            cnn2.Close()

                        End If
                        cnn1.Close() : cnn1.Open()

                        Select Case lblTipoVenta.Text

                            Case Is = "MOSTRADOR"

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                            "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,Mesero,Descuento) values(" & MYFOLIO & ",0,'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & nuevopago & ",0," & propina & ",'" & formapago & "'," & nuevopago & ",'" & bancopago & "','" & referenciapago & "','" & comentariopago & "','" & lblAtendio.Text & "','" & lblAtendio.Text & "'," & Descuento & ")"
                                cmd1.ExecuteNonQuery()
                            Case Is <> "MOSTRADOR"
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                            "select Saldo from Abonoi where Id=(select MAX(Id) from Abonoi where IdCliente=" & lblTipoVenta.Text & ")"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - ACuenta, 2)
                                    End If
                                Else
                                    MySaldo = FormatNumber(lbltotalventa.Text, 2)
                                End If
                                rd1.Close()

                                If Resta > 0 And AFavor_Cliente > 0 Then
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,MontoSF,Mesero,Descuento) values(" & MYFOLIO & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACuenta & "," & MySaldo & "," & propina & ",'" & formapago & "'," & montopago & ",'" & bancopago & "','" & referenciapago & "','" & cuentarefe & "'," & bancorefe & "','" & comentariopago & "','" & lblAtendio.Text & "'," & Resta & ",'" & lblAtendio.Text & "'," & Descuento & ")"
                                    cmd1.ExecuteNonQuery()
                                Else
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,Mesero,Descuento) values(" & MYFOLIO & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACuenta & "," & MySaldo & "," & propina & ",'" & formapago & "'," & montopago & ",'" & bancopago & "','" & referenciapago & "','" & comentariopago & "','" & lblAtendio.Text & "','" & lblAtendio.Text & "'," & Descuento & ")"
                                    cmd1.ExecuteNonQuery()
                                End If
                        End Select
                    Next
                End If

                If EfectivoX > 0 Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM abonoi WHERE NumFolio=" & MYFOLIO
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "UPDATE abonoi SET Propina=0 WHERE NumFolio=" & MYFOLIO & " AND FormaPago<>'EFECTIVO'"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()
                End If


                If EfectivoX > 0 Then

                    ACuenta = FormatNumber(montoefectivo - CAMBIO - lblPropina.Text, 2)

                    Select Case lblTipoVenta.Text
                        Case Is = "MOSTRADOR"
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,Mesero,Descuento) values(" & MYFOLIO & ",0,'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACuenta & ",0," & propina & ",'EFECTIVO'," & ACuenta & ",'','','','" & lblAtendio.Text & "','" & lblAtendio.Text & "'," & Descuento & ")"
                            cmd1.ExecuteNonQuery()

                        Case Is <> "MOSTRADOR"
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "select Saldo from Abonoi where Id=(select MAX(Id) from Abonoi where IdCliente=" & lblTipoVenta.Text & ")"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - ACuenta, 2)
                                End If
                            Else
                                MySaldo = FormatNumber(lbltotalventa.Text, 2)
                            End If
                            rd1.Close()

                            If Resta > 0 And AFavor_Cliente > 0 Then
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,MontoSF,Mesero,Descuento) values(" & MYFOLIO & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACuenta & "," & MySaldo & "," & propina & ",'EFECTIVO'," & EfectivoX & ",0,'','','','" & lblAtendio.Text & "'," & Resta & ",'" & lblAtendio.Text & "'," & Descuento & ")"

                                cmd1.ExecuteNonQuery()
                            Else
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,Mesero,Descuento) values(" & MYFOLIO & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACuenta & "," & MySaldo & "," & propina & ",'EFECTIVO'," & EfectivoX & ",'','','','" & lblAtendio.Text & "','" & lblAtendio.Text & "'," & Descuento & ")"
                                cmd1.ExecuteNonQuery()
                            End If
                    End Select
                End If
            End If
            cnn1.Close()
            cnn1.Open()

            For pain As Integer = 0 To grdCaptura.Rows.Count - 1

                Prods = Split(grdCaptura.Rows(pain).Cells(1).Value.ToString, vbCrLf)
                Dim unidadv As String = ""
                Dim MYIVA As Double = 0
                Dim MyPrecioSin As Double = 0
                Dim MyTotalSin As Double = 0

                Dim MyCostVUE As Double = 0
                Dim MyProm As Double = 0
                Dim MyDepto As String = ""
                Dim MyGrupo As String = ""
                Dim MyMCD As Double = 0
                Dim MyMult2 As Double = 0
                Dim GImpre As String = ""

                Dim MyTotal As Double = 0
                Dim MYCODE = Prods(0)
                Dim MyDes = Prods(1)
                Dim MYCANT = grdCaptura.Rows(pain).Cells(2).Value.ToString
                Dim MyPrecio As Double = 0
                MyPrecio = grdCaptura.Rows(pain).Cells(3).Value.ToString

                MyTotal = grdCaptura.Rows(pain).Cells(4).Value.ToString
                Dim comensal = IIf(grdCaptura.Rows(pain).Cells(5).Value.ToString = "", "", grdCaptura.Rows(pain).Cells(5).Value.ToString)
                Dim pep = IIf(grdCaptura.Rows(pain).Cells(6).Value.ToString = "", "", grdCaptura.Rows(pain).Cells(6).Value.ToString)
                Dim Comentario As String = grdCaptura.Rows(pain).Cells(7).Value

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM Productos where Codigo='" & MYCODE & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        unidadv = rd2("UVenta").ToString
                        MYIVA = rd2("IVA").ToString
                        MyPrecioSin = IIf(MyPrecio = 0, 0, MyPrecio) / (1 + MYIVA)
                        MyTotalSin = IIf(MyTotal = 0, 0, MyTotal) / (1 + MYIVA)
                        MyPrecioSin = FormatNumber(MyPrecioSin, 2)

                        If MYCODE = "WXYZ" Then
                            MyCostVUE = 0
                            MyProm = 0
                            MyDepto = "UNICO"
                            MyGrupo = "UNICO"
                            MyMCD = "1"
                            MyMultiplo = "1"
                            GImpre = "UNICO"
                        Else
                            If rd2("Departamento").ToString = "SERVICIOS" Then
                                MyCostVUE = rd2("PrecioCompra").ToString
                                MyProm = 0
                                MyDepto = rd2("Departamento").ToString
                                MyGrupo = rd2("Grupo").ToString
                            End If
                            MyMCD = rd2("MCD").ToString
                            MyMult2 = rd2("Multiplo").ToString
                            MyDepto = rd2("Departamento").ToString
                            MyGrupo = rd2("Grupo").ToString
                            GImpre = rd2("GPrint").ToString
                        End If
                    End If
                End If
                rd2.Close()
                cnn2.Close()

                Dim existencia_inicial As Integer = 0
                Dim opeCantReal As Integer = 0
                Dim opediferencia As Integer = 0

                Dim VarCodigo As String = ""
                Dim VarDesc As String = ""
                Dim VarCanti As Double = 0

                existencia_inicial = 0
                opeCantReal = 0
                opediferencia = 0

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT * FROM Productos  WHERE Codigo='" & MYCODE & "'"
                rd3 = cmd3.ExecuteReader
                MyCostVUE = 0
                If rd3.HasRows Then
                    If rd3.Read Then
                        If rd3("Modo_Almacen").ToString = 1 Then

                            cnn1.Close() : cnn1.Open()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "SELECT CodigoP,Codigo,Descrip,Cantidad FROM MiProd WHERE CodigoP='" & Strings.Left(MYCODE, 6) & "'"
                            rd1 = cmd1.ExecuteReader
                            Do While rd1.Read
                                If rd1.HasRows Then


                                    existencia_inicial = 0
                                    opeCantReal = 0
                                    opediferencia = 0

                                    VarCodigo = rd1("Codigo").ToString
                                    VarDesc = rd1("Descrip").ToString
                                    VarCanti = rd1("Cantidad").ToString * grdCaptura.Rows(pain).Cells(2).Value.ToString

                                    Dim KIT As Integer = 0
                                    Dim MyMulti2 As Double = 0
                                    Dim Unico As Integer = 0
                                    Dim gprint As String = ""
                                    Dim Pre_Comp As Double = 0

                                    cnn2.Close() : cnn2.Open()
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & VarCodigo & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        If rd2.Read Then


                                            MyCostVUE = 0
                                            MyProm = 0
                                            MyDepto = rd2("Departamento").ToString()
                                            MyGrupo = rd2("Grupo").ToString()
                                            KIT = rd2("ProvRes").ToString()
                                            MyMCD = rd2("MCD").ToString()
                                            MyMulti2 = rd2("Multiplo").ToString()
                                            Unico = rd2("Unico").ToString()
                                            gprint = rd2("GPrint").ToString
                                            If CStr(rd2("Departamento").ToString()) = "SERVICIOS" Then
                                                rd2.Close() : cnn2.Close()
                                                GoTo Door
                                            End If
                                        End If
                                    End If
                                    rd2.Close()

                                    Dim existe As Double = 0

                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Strings.Left(VarCodigo, 6) & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        If rd2.Read Then
                                            existe = rd2("Existencia").ToString()
                                            MyMultiplo = rd2("MCD").ToString()
                                            existencia = existe / MyMultiplo
                                            If rd2("Departamento").ToString() <> "SERVICIOS" Then
                                                Pre_Comp = rd2("PrecioCompra").ToString()
                                                MyCostVUE = Pre_Comp * (MYCANT / MyMCD)
                                            End If
                                        End If
                                    End If
                                    rd2.Close()

                                    opeCantReal = CDbl(VarCanti) * CDbl(MyMulti2)

                                    Dim nueva_existe As Double = 0
                                    nueva_existe = existencia - (VarCanti / MyMCD)

                                    cnn4.Close() : cnn4.Open()
                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Precio,Fecha,Usuario,Final,Folio) VALUES('" & VarCodigo & "','" & VarDesc & "','Venta - Ingrediente'," & existencia & "," & opeCantReal & "," & Pre_Comp & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblAtendio.Text & "'," & nueva_existe & ",'" & MYFOLIO & "')"
                                    cmd4.ExecuteNonQuery()
                                    cnn4.Close()

                                    cnn4.Close() : cnn4.Open()
                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText = "UPDATE Productos SET Cargado=0,CargadoInv=0,Existencia=" & nueva_existe & " WHERE Codigo='" & Strings.Left(VarCodigo, 6) & "'"
                                    cmd4.ExecuteNonQuery()

                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText = "INSERT INTO Mov_Ingre(Codigo,Descripcion,Cantidad,Fecha) VALUES('" & VarCodigo & "','" & VarDesc & "','" & VarCanti & "','" & Format(Date.Now, "yyyy/MM/dd") & "')"
                                    cmd4.ExecuteNonQuery()
                                    cnn4.Close()

                                End If
                            Loop
                            rd1.Close()
                            cnn1.Close()
                        Else

                            Dim KIT As Integer = 0
                            Dim MyMulti2 As Double = 0
                            Dim Unico As Integer = 0
                            Dim gprint As String = ""
                            Dim Pre_Comp As Double = 0

                            If grdCaptura.Rows(pain).Cells(0).Value.ToString = "" Then GoTo Door

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "select * from Productos where Codigo='" & MYCODE & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    MyCostVUE = rd2("PrecioCompra").ToString
                                    MyProm = 0
                                    MyDepto = rd2("Departamento").ToString()
                                    MyGrupo = rd2("Grupo").ToString()
                                    KIT = rd2("ProvRes").ToString()
                                    MyMCD = rd2("MCD").ToString()
                                    MyMulti2 = rd2("Multiplo").ToString()
                                    Unico = rd2("Unico").ToString()
                                    gprint = rd2("GPrint").ToString
                                    If CStr(rd2("Departamento").ToString()) = "SERVICIOS" Then
                                        rd2.Close() : cnn2.Close()
                                        GoTo Door
                                    End If
                                End If
                            End If
                            rd2.Close()
                            Dim existe As Double = 0

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(MYCODE, 6) & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    existe = rd2("Existencia").ToString()
                                    MyMultiplo = rd2("MCD").ToString()
                                    existencia = existe / MyMultiplo
                                    If rd2("Departamento").ToString() <> "SERVICIOS" Then
                                        Pre_Comp = rd2("PrecioCompra").ToString()
                                        MyCostVUE = Pre_Comp * (MYCANT / MyMCD)
                                    End If
                                End If
                            End If
                            rd2.Close()
Door:




                            'existencia_inicial = rd3("Existencia").ToString
                            'opeCantReal = CDec(grdCaptura.Rows(pain).Cells(2).Value.ToString) * CDec(rd3("Multiplo").ToString)
                            'opediferencia = existencia_inicial - opeCantReal

                            Dim nueva_existe As Double = 0
                            nueva_existe = existencia - (MYCANT / MyMCD)

                            cnn4.Close() : cnn4.Open()
                            cmd4 = cnn4.CreateCommand
                            cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Precio,Fecha,Usuario,Final,Folio) VALUES('" & rd3("Codigo").ToString & "','" & rd3("Nombre").ToString & "','Venta'," & existencia & "," & MYCANT & "," & Pre_Comp & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblAtendio.Text & "'," & nueva_existe & ",' ')"
                            cmd4.ExecuteNonQuery()

                            cmd4 = cnn4.CreateCommand
                            cmd4.CommandText = "UPDATE Productos SET Existencia= " & nueva_existe & " ,Cargado=0,CargadoInv=0 WHERE Codigo='" & Strings.Left(MYCODE, 6) & "'"

                            cmd4.ExecuteNonQuery()
                            cnn4.Close()
                            cnn2.Close()
                        End If
                    End If
                End If
                rd3.Close()
                cnn3.Close()

                Dim vartasa As String = ""
                Dim vartotal As String = ""

                vartasa = 0
                vartotal = 0

                cnn4.Close() : cnn4.Open()
                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "INSERT INTO VentasDetalle(Folio,Codigo,Nombre,Cantidad,Unidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,GPrint,Comentario,TasaIeps,TotalIEPS,Comensal,Facturado) VALUES(" & MYFOLIO & ",'" & MYCODE & "','" & MyDes & "'," & MYCANT & ",'" & unidadv & "'," & MyCostVUE & "," & MyCostVUE & "," & MyPrecio & "," & MyTotal & "," & MyPrecioSin & "," & MyTotalSin & ",'0','" & Format(Date.Now, "yyyy/MM/dd") & "','" & MyDepto & "','" & MyGrupo & "','" & GImpre & "','" & Comentario & "'," & vartasa & "," & vartotal & ",'" & comensal & "','0')"
                cmd4.ExecuteNonQuery()
                cnn4.Close()


                cnn4.Close() : cnn4.Open()
                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "INSERT INTO Comandas(Id,Nmesa,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Hr,EntregaT) VALUES(" & MYFOLIO & ",'" & lblTipoVenta.Text & "','" & MYCODE & "','" & MyDes & "','" & unidadv & "'," & MYCANT & ",0,0,0," & MyPrecio & "," & MyTotal & "," & MyPrecioSin & "," & MyTotalSin & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','',0,'" & MyDepto & "','" & MyGrupo & "','" & comensal & "','PAGADO','" & Comentario & "','" & GImpre & "','" & lblAtendio.Text & "','1','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "')"
                cmd4.ExecuteNonQuery()
                cnn4.Close()

                cnn4.Close() : cnn4.Open()
                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "INSERT INTO rep_comandas(Id,Nmesa,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Hr,EntregaT) VALUES(" & MYFOLIO & ",'" & lblTipoVenta.Text & "','" & MYCODE & "','" & MyDes & "','" & unidadv & "'," & MYCANT & ",0,0,0," & MyPrecio & "," & MyTotal & "," & MyPrecioSin & "," & MyTotalSin & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','',0,'" & MyDepto & "','" & MyGrupo & "','" & comensal & "','PAGADO','" & Comentario & "','" & GImpre & "','" & lblAtendio.Text & "','1','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "')"
                cmd4.ExecuteNonQuery()
                cnn4.Close()


            Next

            '.......................imprimir ticket-------------------------------------------------------------------------------


            Dim impresoracomanda As String = ""
            Dim tamcomanda As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tamcomanda = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT GPrint FROM comandas WHERE Id='" & MYFOLIO & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    rutacomanda = rd1(0).ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Impresora FROM rutasImpresion where Tipo='" & rutacomanda & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            impresoracomanda = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()

                    If impresoracomanda = "" Then
                    Else
                        If tamcomanda = "80" Then
                            PComanda80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                            PComanda80.Print()
                        ElseIf tamcomanda = "58" Then
                            PComanda58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                            PComanda58.Print()

                        End If
                    End If



                    cnn2.Close()
                End If
            Loop
            rd1.Close()

            Dim imprimirticket As Integer = 0
            Dim copiasticket As Integer = 0
            Dim Pasa_Print As Boolean = False
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NoPrint,Copias FROM Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    imprimirticket = rd1(0).ToString
                    copiasticket = rd1(1).ToString
                End If
            End If
            rd1.Close()

            If (imprimirticket) Then
                If MsgBox("¿Deseas imprimir nota de venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Pasa_Print = True
                Else
                    Pasa_Print = False
                End If
            Else
                Pasa_Print = True
            End If


            If (Pasa_Print) Then
                Dim papel As String = ""
                Dim impresoraventa As String = ""
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Desglosa'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        desglosaiva = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Formato FROM RutasImpresion WHERE Tipo='Venta'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        papel = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='" & papel & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        impresoracomanda = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                If impresoracomanda <> "" Then

                    If tamcomanda = "80" Then
                        PVentaTouch80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                        PVentaTouch80.Print()

                    ElseIf tamcomanda = "58" Then
                        PVentaTouch58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                        PVentaTouch58.Print()
                    End If

                End If



            End If

            cnn1.Close()

            btnLimpiar.PerformClick()
            frmPagarTouch.Close()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "DELETE FROM comandas WHERE Id='" & MYFOLIO & "'"
            cmd2.ExecuteNonQuery()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try


    End Sub

#Region "teclado"

    Private Sub btnco_Click(sender As Object, e As EventArgs) Handles btnco.Click
        txtRespuesta.Focus.Equals(True)
        txtRespuesta.Text = ""
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtRespuesta.Text = txtRespuesta.Text + btn1.Text
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtRespuesta.Text = txtRespuesta.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtRespuesta.Text = txtRespuesta.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtRespuesta.Text = txtRespuesta.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtRespuesta.Text = txtRespuesta.Text + btn5.Text
    End Sub

    Private Sub btnpunto_Click(sender As Object, e As EventArgs) Handles btnpunto.Click
        txtRespuesta.Text = txtRespuesta.Text + btnpunto.Text
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        txtRespuesta_KeyPress(txtRespuesta, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtRespuesta.Text = txtRespuesta.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtRespuesta.Text = txtRespuesta.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtRespuesta.Text = txtRespuesta.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtRespuesta.Text = txtRespuesta.Text + btn9.Text
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtRespuesta.Text = txtRespuesta.Text + btn0.Text
    End Sub

    Private Sub btnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        txtRespuesta.Text = txtRespuesta.Text + btnQ.Text
    End Sub

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        txtRespuesta.Text = txtRespuesta.Text + btnW.Text
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        txtRespuesta.Text = txtRespuesta.Text + btnespacio.Text
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        txtRespuesta.Text = txtRespuesta.Text + btnR.Text
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        txtRespuesta.Text = txtRespuesta.Text + btnT.Text
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        txtRespuesta.Text = txtRespuesta.Text + btnY.Text
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        txtRespuesta.Text = txtRespuesta.Text + btnU.Text
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        txtRespuesta.Text = txtRespuesta.Text + btnI.Text
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        txtRespuesta.Text = txtRespuesta.Text + btnO.Text
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        txtRespuesta.Text = txtRespuesta.Text + btnpunto.Text
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        txtRespuesta.Text = txtRespuesta.Text + btnA.Text
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        txtRespuesta.Text = txtRespuesta.Text + btnS.Text
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        txtRespuesta.Text = txtRespuesta.Text + btnD.Text
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        txtRespuesta.Text = txtRespuesta.Text + btnF.Text
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        txtRespuesta.Text = txtRespuesta.Text + btnG.Text
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        txtRespuesta.Text = txtRespuesta.Text + btnH.Text
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        txtRespuesta.Text = txtRespuesta.Text + btnJ.Text
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        txtRespuesta.Text = txtRespuesta.Text + btnK.Text
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        txtRespuesta.Text = txtRespuesta.Text + btnL.Text
    End Sub

    Private Sub btnÑ_Click(sender As Object, e As EventArgs) Handles btnÑ.Click
        txtRespuesta.Text = txtRespuesta.Text + btnÑ.Text
    End Sub

    Private Sub btnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        txtRespuesta.Text = txtRespuesta.Text + btnZ.Text
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        txtRespuesta.Text = txtRespuesta.Text + btnX.Text
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        txtRespuesta.Text = txtRespuesta.Text + btnC.Text
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        txtRespuesta.Text = txtRespuesta.Text + btnV.Text
    End Sub

    Private Sub txtRespuesta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRespuesta.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then

            respuesta = txtRespuesta.Text
            Dim totalventa As Double = 0

            With Me.grdCaptura
                Dim banderaproducto As Integer = 0
                banderaproducto = 0
                Dim totalnuevo As Double = 0

                If pCampo.Text = "Comensal" Then

                    'ObtenerProducto(damecodigo)
                End If

                If pCampo.Text = "Cantidad" Then
                    If banderacantidad = 1 Then
                        For q As Integer = 0 To grdCaptura.Rows.Count - 1
                            lbltotalventa.Text = "0.00"

                            If grdCaptura.Rows(q).Cells(0).Value = CodigoProducto Then
                                grdCaptura.Rows(q).Cells(1).Value = CodigoProducto & vbNewLine & descripcionpro
                                grdCaptura.Rows(q).Cells(2).Value = FormatNumber(respuesta, 2)
                                grdCaptura.Rows(q).Cells(3).Value = grdCaptura.Rows(q).Cells(3).Value.ToString
                                totalnuevo = respuesta * grdCaptura.Rows(q).Cells(3).Value.ToString
                                grdCaptura.Rows(q).Cells(4).Value = FormatNumber(totalnuevo, 2)

                                banderaproducto = 1
                            End If
                        Next q
                    End If
                End If

                If pCampo.Text = "Cambiar Precio" Then

                    Dim idcliente As Integer = 0

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT IdEmpleado FROM usuarios WHERE Alias='" & lblAtendio.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.Read Then
                        If rd3.HasRows Then
                            idcliente = rd3(0).ToString

                            cnn2.Close() : cnn2.Open()
                            cmd2.CommandText = "SELECT Prod_Pre FROM permisos WHERE IdEmpleado=" & idcliente & ""
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                    If rd2(0).ToString = 1 Then
                                        If banderaprecio = 1 Then
                                            For q As Integer = 0 To grdCaptura.Rows.Count - 1
                                                lblTotalPagar.Text = "0.00"
                                                lblRestaPagar.Text = "0.00"
                                                If grdCaptura.Rows(q).Cells(0).Value = CodigoProducto Then
                                                    grdCaptura.Rows(q).Cells(1).Value = CodigoProducto & vbNewLine & descripcionpro

                                                    grdCaptura.Rows(q).Cells(2).Value = grdCaptura.Rows(q).Cells(2).Value.ToString
                                                    grdCaptura.Rows(q).Cells(3).Value = FormatNumber(respuesta, 2)
                                                    totalnuevo = grdCaptura.Rows(q).Cells(2).Value.ToString * respuesta
                                                    grdCaptura.Rows(q).Cells(4).Value = FormatNumber(totalnuevo, 2)

                                                    lblTotalPagar.Text = lblTotalPagar.Text + totalnuevo
                                                    lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)

                                                    banderaproducto = 1
                                                End If
                                            Next q
                                        End If
                                        cnn1.Close()
                                    Else
                                        MsgBox("El usuario no tiene permisos para asignar los precios", vbInformation + vbOKOnly, titulomensajes)
                                        txtRespuesta.Text = ""
                                        txtRespuesta.Focus.Equals(True)
                                        Exit Sub
                                    End If
                                Else
                                    MsgBox("El usuario no tiene permisos para asignar los precios", vbInformation + vbOKOnly, titulomensajes)
                                    Exit Sub
                                End If

                            End If
                            rd2.Close()
                            cnn2.Close()

                        End If
                    End If
                    rd3.Close()
                    cnn3.Close()
                End If

                If pCampo.Text = "Comentario" Then
                    If banderacomentario = 1 Then
                        For q As Integer = 0 To grdCaptura.Rows.Count - 1

                            If grdCaptura.Rows(q).Cells(0).Value = CodigoProducto Then
                                grdCaptura.Rows(q).Cells(7).Value = respuesta
                            End If

                        Next
                    End If
                End If


                If banderaPROMOCION = 1 Then
                    If (txtRespuesta.Text + cantpromo) <= cantidadPromo Then
                        cantpromo = CDec(cantpromo) + CDec(txtRespuesta.Text)


                        cantidad = txtRespuesta.Text
                        ObtenerProducto(CodigoProducto)
                    Else
                        MsgBox("La suma de los productos de la promoción no puede ser mayor a " & cantidadPromo & "")
                    End If
                End If

                For luffy As Integer = 0 To grdCaptura.Rows.Count - 1
                    totalventa = totalventa + grdCaptura.Rows(luffy).Cells(4).Value.ToString
                    lbltotalventa.Text = FormatNumber(totalventa, 2)
                    lblTotalPagar.Text = FormatNumber(totalventa, 2)
                    lblRestaPagar.Text = FormatNumber(totalventa, 2)
                Next
            End With

            banderaprecio = 0
            banderacantidad = 0
            txtRespuesta.Text = ""
            PTeclado.Visible = False

        End If

    End Sub

    Private Sub PVentaTouch58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVentaTouch58.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 6, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim Pie2 As String = ""
        Dim Pie3 As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Dim cantidad As Double = 0
        Dim nombre As String = ""
        Dim precio As Double = 0
        Dim total As Double = 0

        Dim MyImporte As Double = 0
        Dim ope As Double = 0
        Dim TotalIVA As Double = 0

        Dim articulos As Integer = 0
        Dim cuentatotal As Double = 0

        Dim ligaqr As String = ""
        Dim whats As String = DatosRecarga("Whatsapp")

        Dim autofact As String = DatosRecarga("LinkAuto")
        Dim siqr As String = DatosRecarga2("LinkAuto")

        If whats <> "" Then
            ligaqr = "http://wa.me/" & whats
        End If


        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                Y += 120
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 12, 5, 160, 80)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
                "select * from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                Pie = rd4("Pie1").ToString
                Pie2 = rd4("Pie2").ToString
                Pie3 = rd4("Pie3").ToString
                'Razón social
                If rd4("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'RFC
                If rd4("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'Calle  N°.
                If rd4("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Colonia
                If rd4("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Delegación / Municipio - Entidad
                If rd4("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Teléfono
                If rd4("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Correo
                If rd4("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                Y += 10
            End If
        Else
            Y += 0
        End If
        rd4.Close()
        cnn4.Close()

        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 9
        e.Graphics.DrawString("C L I E N T E", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 9
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 12

        Dim zu As Integer = 1

        If lblCliente.Text = "" Then
            e.Graphics.DrawString("MOSTRADOR", fuente_r, Brushes.Black, 1, Y)
            Y += 10
        Else
            e.Graphics.DrawString("Télefono: " & lblTelefono.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 10
            e.Graphics.DrawString("Cliente: " & lblCliente.Text, fuente_b, Brushes.Black, 1, Y)
            Y += 10
        End If

        Do While Trim(lblDireccion.Text) <> ""
            lblDireccion.Text = Mid(lblDireccion.Text, zu, 38)
            If Trim(lblDireccion.Text) <> "" Then
                e.Graphics.DrawString("Direccion: " & lblDireccion.Text, fuente_b, Brushes.Black, 1, Y)
                Y += 10
            End If
            zu = zu + 38
        Loop
        Y += 7
        e.Graphics.DrawString("-----------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 11
        e.Graphics.DrawString("-----------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 12
        e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_b, Brushes.Black, 1, Y)
        Y += 12

        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
        Y += 11
        e.Graphics.DrawString("-----------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 12

        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 38, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 133, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 20

        cnn3.Close() : cnn3.Open()
        cnn4.Close() : cnn4.Open()

        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "select * from VentasDetalle where Folio='" & MYFOLIO & "'"
        rd3 = cmd3.ExecuteReader
        Do While rd3.Read
            If rd3.HasRows Then

                cantidad = rd3("Cantidad").ToString
                nombre = rd3("Nombre").ToString
                precio = rd3("Precio").ToString
                total = rd3("Total").ToString

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "select IVA from Productos where Codigo='" & rd3("Codigo").ToString & "' "
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then
                        ope = total / 1.16
                        TotalIVA = TotalIVA + CDec(ope) * CDec(rd4(0).ToString)
                        TotalIVA = FormatNumber(TotalIVA, 2)
                    End If
                Loop
                rd4.Close()

                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)


                Dim caracteresPorLinea As Integer = 25
                Dim texto As String = nombre
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                    Y += 15
                    inicio += caracteresPorLinea
                End While

                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_b, Brushes.Black, 133, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20

                articulos = articulos + cantidad
                cuentatotal = cuentatotal + total
            End If
        Loop
        rd3.Close()

        e.Graphics.DrawString("-----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
        Y += 25

        If lblDescuento.Text > 0 Then
            e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(lblDescuento.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
        End If

        If lblPropina.Text > 0 Then
            e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(lblPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
        End If

        If DesglosaIVA = 1 Then
            e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(cuentatotal, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15

            e.Graphics.DrawString("IVA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(TotalIVA, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
        Else
            e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(cuentatotal, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
        End If

        e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(lbltotalventa.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 20

        If Resta > 0 Then
            e.Graphics.DrawString("RESTA: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(Resta, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15

        End If

        If lblImporteEfectivo.Text > 0 Then
            e.Graphics.DrawString("EFECTIVO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(lblImporteEfectivo.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            If lblCambio.Text > 0 Then
                e.Graphics.DrawString("CAMBIO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(lblCambio.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20
            End If

        End If

        If frmPagarTouch.grdPagos.Rows.Count > 0 Then
            e.Graphics.DrawString("---------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            For lol As Integer = 0 To frmPagarTouch.grdPagos.Rows.Count - 1

                Dim forma As String = frmPagarTouch.grdPagos.Rows(lol).Cells(0).Value.ToString
                Dim monto As Double = frmPagarTouch.grdPagos.Rows(lol).Cells(3).Value.ToString


                If forma = "EFECTIVO" Then
                Else
                    e.Graphics.DrawString("PAGO CON: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(forma, fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                    e.Graphics.DrawString("MONTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(FormatNumber(monto, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                    e.Graphics.DrawString("---------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                    Y += 15
                End If

            Next
        End If


        Dim CantidaLetra As String = ""

        CantidaLetra = "Son: " & convLetras(lbltotalventa.Text)
        Y += 20

        If Mid(CantidaLetra, 1, 27) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 27), fuente_r, Brushes.Black, 1, Y)
            Y += 12
        End If

        If Mid(CantidaLetra, 28, 56) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 28, 56), fuente_r, Brushes.Black, 1, Y)
            Y += 12
        End If

        Pie2 = EliminarSaltosLinea(Pie2, " ")
        If Trim(Pie2) <> "" Then
            e.Graphics.DrawString(Mid(Pie2, 1, 30), fuente_r, Brushes.Black, 1, Y)
            Pie2 = Mid(Pie2, 39, 700)
            Y += 15
        End If

        e.Graphics.DrawString("Lo atendio: " & lblAtendio.Text, fuente_r, Brushes.Black, 1, Y)
        Y += 20

        Dim autofac As Integer = 0
        Dim linkauto As String = ""

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='AutoFac'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                autofac = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='LinkAuto'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                linkauto = rd1(0).ToString
                siqr = rd1(1).ToString
            End If
        End If
        rd1.Close()

        Dim siqrwhats As Integer = 0

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='WhatsApp'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                siqrwhats = rd1(1).ToString
            End If
        End If
        rd1.Close()

        cnn1.Close()
        If siqrwhats = 1 Then
            If ligaqr <> "" Then
                Dim entrada As String = ligaqr
                Dim Gen As New QRCodeGenerator
                Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                Dim Code As New QRCode(data)
                If picQR.Image IsNot Nothing Then
                    picQR.Image.Dispose()
                End If
                picQR.Image = Code.GetGraphic(200)
                My.Application.DoEvents()
                e.Graphics.DrawString("Escríbenos por Whatsapp", fuente_c, Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawImage(picQR.Image, 30, CInt(Y), 85, 85)
                Y += 60
                If picQR.Image IsNot Nothing Then
                    picQR.Image.Dispose()
                End If
            End If

        End If

        Y += 35
        If autofac = 1 Then

            If siqr = "1" Then
                picQR.Image.Dispose()
                Dim entrada As String = linkauto
                Dim Gen As New QRCodeGenerator
                Dim data = Gen.CreateQrCode(entrada, QRCodeGenerator.ECCLevel.Q)
                Dim Code As New QRCode(data)

                ' Asegúrate de liberar los recursos de la imagen anterior antes de asignar la nueva imagen
                If picQR.Image IsNot Nothing Then
                    picQR.Image.Dispose()
                End If
                ' Asigna la nueva imagen al PictureBox
                picQR.Image = Code.GetGraphic(200)
                My.Application.DoEvents()
                e.Graphics.DrawString("Codigo para facturar:", fuente_c, Brushes.Black, 1, Y)
                Y += 25
                e.Graphics.DrawString(Trim(cadenafact), fuente_c, Brushes.Black, 1, Y)
                Y += 25
                ' Usa Using para garantizar la liberación de recursos de la fuente
                e.Graphics.DrawString("Realiza tu factura aqui", fuente_c, Brushes.Black, 1, Y)
                Y += 10
                ' Dibuja la imagen en el contexto gráfico
                e.Graphics.DrawImage(picQR.Image, 30, CInt(Y + 15), 85, 85)
                Y += 20
                picQR.Image.Dispose()
            End If

        Else

        End If

        e.HasMorePages = False
        cnn4.Close()
        cnn3.Close()

    End Sub

    Private Sub PComanda80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PComanda80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nom_logo As String = ""
        Dim logo As Image = Nothing
        Dim tamlogo As String = ""

        Dim pie1 As String = ""
        Dim pie2 As String = ""
        Dim pie3 As String = ""

        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
                "select * from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                pie1 = rd4("Pie1").ToString
                pie2 = rd4("Pie2").ToString
                pie3 = rd4("Pie3").ToString
                'Razón social
                If rd4("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'RFC
                If rd4("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd4("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Colonia
                If rd4("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd4("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Teléfono
                If rd4("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Correo
                If rd4("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd4.Close()

        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("C O M A N D A", fuente_b, Brushes.Black, 135, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("FOLIO:" & MYFOLIO, fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 270, Y, derecha)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
        Y += 20
        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText = "Select * From VentasDetalle Where Gprint ='" & rutacomanda & "' and Folio=" & MYFOLIO & ""
        rd4 = cmd4.ExecuteReader
        Do While rd4.Read
            If rd4.HasRows Then

                Dim comentario2 As String = rd4("Comentario").ToString
                Dim nombre As String = rd4("Nombre").ToString
                Dim cantidad As Double = rd4("Cantidad").ToString
                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(nombre, fuente_b, Brushes.Black, 35, Y)
                Y += 20

                If comentario2 = "" Then

                Else
                    Dim comentario As String = rd4("Comentario").ToString
                    e.Graphics.DrawString("NOTA:" & comentario, fuente_b, Brushes.Black, 1, Y)
                    Y += 20
                End If
            End If
        Loop
        rd4.Close()
        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        cnn4.Close()
        e.HasMorePages = False
    End Sub

    Private Sub PComanda58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PComanda58.PrintPage
        Dim fuente_r As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim pluma As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim pie1 As String = ""
        Dim pie2 As String = ""
        Dim pie3 As String = ""

        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText = "select * from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.Read Then
            For w As Integer = 0 To 6
                Dim dato As String = rd4(w).ToString
                e.Graphics.DrawString(dato, fuente_c, Brushes.Black, 90, Y, centro)
                Y += 18

            Next
            pie1 = rd4(7).ToString
            pie2 = rd4(8).ToString
            pie3 = rd4(9).ToString
        End If
        rd4.Close()

        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("C O M A N D A", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("FOLIO:" & MYFOLIO, fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText = "Select * From VentasDetalle Where Gprint ='" & rutacomanda & "' and Folio=" & MYFOLIO & ""
        rd4 = cmd4.ExecuteReader
        Do While rd4.Read
            If rd4.HasRows Then

                Dim comentario2 As String = rd4("Comentario").ToString
                Dim nombre As String = rd4("Nombre").ToString
                Dim cantidad As Double = rd4("Cantidad").ToString
                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(nombre, fuente_b, Brushes.Black, 35, Y)
                Y += 20

                If comentario2 = "" Then

                Else
                    Dim comentario As String = rd4("Comentario").ToString
                    e.Graphics.DrawString("NOTA:" & comentario, fuente_b, Brushes.Black, 1, Y)
                    Y += 20
                End If
            End If
        Loop
        rd4.Close()

        e.Graphics.DrawString("--------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        cnn4.Close()
        e.HasMorePages = False
    End Sub

    Private Sub Cortesia80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Cortesia80.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim Pie2 As String = ""
        Dim Pie3 As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 90
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 90
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
                "select * from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                Pie = rd4("Pie1").ToString
                Pie2 = rd4("Pie2").ToString
                Pie3 = rd4("Pie3").ToString
                'Razón social
                If rd4("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'RFC
                If rd4("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd4("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Colonia
                If rd4("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd4("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Teléfono
                If rd4("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Correo
                If rd4("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd4.Close()
        cnn4.Close()

        e.Graphics.DrawString("---------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("C O R T E S I A", fuente_b, Brushes.Black, 135, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 270, Y, derecha)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CLIENTE: " & lblCliente.Text, fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("FOLIO: " & Foliore, fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 215, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 20
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        If grdCaptura.Rows.Count > 0 Then
            For barbi As Integer = 0 To grdCaptura.Rows.Count - 1

                Prods = Split(grdCaptura.Rows(barbi).Cells(1).Value.ToString, vbCrLf)

                Dim codigo As String = grdCaptura.Rows(barbi).Cells(0).Value.ToString
                Dim descripcion As String = Prods(1)
                Dim cantidad As Double = grdCaptura.Rows(barbi).Cells(2).Value.ToString
                Dim precio As Double = grdCaptura.Rows(barbi).Cells(3).Value.ToString
                Dim total As Double = grdCaptura.Rows(barbi).Cells(4).Value.ToString

                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 30
                Dim texto As String = descripcion
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                    Y += 15
                    inicio += caracteresPorLinea
                End While

                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_b, Brushes.Black, 215, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20

            Next
        End If
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 16

        e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(lblTotalPagar.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 15

        e.Graphics.DrawString("TOTAl A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("0.00", fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 15

        Dim CantidaLetra As String = ""
        CantidaLetra = "Son: " & convLetras(lblTotalPagar.Text)
        Y += 15

        If Mid(CantidaLetra, 1, 30) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 30), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Mid(CantidaLetra, 31, 60) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 31, 60), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Trim(Pie2) <> "" Then
            e.Graphics.DrawString(Mid(Pie2, 1, 38), fuente_r, Brushes.Black, 1, Y)
            Y += 20
        End If

        e.Graphics.DrawString("Lo atendio: " & lblAtendio.Text, fuente_r, Brushes.Black, 1, Y)
        Y += 20

        e.HasMorePages = False
    End Sub

    Private Sub Cortesia58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Cortesia58.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim Pie2 As String = ""
        Dim Pie3 As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                Y += 90
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 12, 5, 160, 80)
                Y += 90
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
                "select * from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                Pie = rd4("Pie1").ToString
                Pie2 = rd4("Pie2").ToString
                Pie3 = rd4("Pie3").ToString
                'Razón social
                If rd4("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'RFC
                If rd4("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'Calle  N°.
                If rd4("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Colonia
                If rd4("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Delegación / Municipio - Entidad
                If rd4("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Teléfono
                If rd4("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Correo
                If rd4("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                Y += 12
            End If
        Else
            Y += 0
        End If
        rd4.Close()
        cnn4.Close()

        e.Graphics.DrawString("---------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("C O R T E S I A", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 11
        e.Graphics.DrawString("-----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
        Y += 11
        e.Graphics.DrawString("-----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CLIENTE: " & lblCliente.Text, fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("FOLIO: " & Foliore, fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 11
        e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 10
        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 103, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15
        e.Graphics.DrawString("---------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        If grdCaptura.Rows.Count > 0 Then
            For barbi As Integer = 0 To grdCaptura.Rows.Count - 1

                Prods = Split(grdCaptura.Rows(barbi).Cells(1).Value.ToString, vbCrLf)

                Dim codigo As String = grdCaptura.Rows(barbi).Cells(0).Value.ToString
                Dim descripcion As String = Prods(1)
                Dim cantidad As Double = grdCaptura.Rows(barbi).Cells(2).Value.ToString
                Dim precio As Double = grdCaptura.Rows(barbi).Cells(3).Value.ToString
                Dim total As Double = grdCaptura.Rows(barbi).Cells(4).Value.ToString

                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 25
                Dim texto As String = descripcion
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 8, FontStyle.Regular), Brushes.Black, 20, Y)
                    Y += 15
                    inicio += caracteresPorLinea
                End While


                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_b, Brushes.Black, 133, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20

            Next
        End If
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 16

        e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(lblTotalPagar.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15

        e.Graphics.DrawString("TOTAl A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("0.00", fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15

        Dim CantidaLetra As String = ""
        CantidaLetra = "Son: " & convLetras(lblTotalPagar.Text)
        Y += 15

        If Mid(CantidaLetra, 1, 30) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 30), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Mid(CantidaLetra, 31, 60) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 31, 60), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Trim(Pie2) <> "" Then
            e.Graphics.DrawString(Mid(Pie2, 1, 38), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        e.Graphics.DrawString("Lo atendio: " & lblAtendio.Text, fuente_r, Brushes.Black, 1, Y)


        e.HasMorePages = False

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If grdCaptura.Rows.Count > 0 Then
            Dim INDEX As Double = grdCaptura.CurrentRow.Index

            Dim IMPORTE = grdCaptura.Rows(INDEX).Cells(4).Value.ToString
            lblTotalPagar.Text = lblTotalPagar.Text - IMPORTE
            lblRestaPagar.Text = lblRestaPagar.Text - IMPORTE

            lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)
            lblRestaPagar.Text = FormatNumber(lblRestaPagar.Text, 2)


            grdCaptura.Rows.Remove(grdCaptura.CurrentRow)
            lblPropina.Text = "0.00"
            lbltotalventa.Text = "0.00"
            lblRestaPagar.Text = "0.00"
        End If

    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        txtRespuesta.Text = txtRespuesta.Text + btnB.Text
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        txtRespuesta.Text = txtRespuesta.Text + btnN.Text
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        txtRespuesta.Text = txtRespuesta.Text + btnM.Text
    End Sub

    Private Sub btnComa_Click(sender As Object, e As EventArgs) Handles btnComa.Click
        txtRespuesta.Text = txtRespuesta.Text + btnComa.Text
    End Sub

    Private Sub btnespacio_Click(sender As Object, e As EventArgs) Handles btnespacio.Click
        txtRespuesta.Text = txtRespuesta.Text + btnespacio.Text
    End Sub


#End Region
End Class