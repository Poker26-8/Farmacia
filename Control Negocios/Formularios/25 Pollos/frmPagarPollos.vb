Imports Core.DAL
Imports System.IO
Public Class frmPagarPollos

    Public subtotalmapeo As Double = 0

    Dim vercomanda As String = ""
    Dim vercodigo As String = ""
    Dim verdescripcion As String = ""
    Dim verunidad As String = ""
    Dim vercantidad As Double = 0
    Dim verprecio As Double = 0
    Dim vertotal As Double = 0
    Dim vercomensal As String = ""
    Dim vermesero As String = ""
    Dim verid As Integer = 0

    Dim cantidadp As Double = 0
    Dim CodigoProductoSel As String = ""

    Dim folio As String = ""

    Dim nLogo As String = ""
    Dim tLogo As String = ""
    Dim simbolo As String = ""
    Dim DesglosaIVA As String = ""
    Dim facLinea As Integer = ""

    Private Sub frmPagarPollos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        nLogo = DatosRecarga("LogoG")
        tLogo = DatosRecarga("TipoLogo")
        simbolo = DatosRecarga("Simbolo")
        DesglosaIVA = DatosRecarga("Desglosa")
        facLinea = DatosRecarga("AutoFac")

        TFolioP.Start()

        Try

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    vercomanda = rd2("IDC").ToString
                    vercodigo = rd2("Codigo").ToString
                    verdescripcion = rd2("Nombre").ToString
                    verunidad = rd2("UVenta").ToString
                    vercantidad = rd2("Cantidad").ToString
                    verprecio = rd2("Precio").ToString
                    vertotal = rd2("Total").ToString
                    vercomensal = rd2("Comensal").ToString
                    vermesero = rd2("CUsuario").ToString
                    verid = rd2("Id").ToString
                    grdComandas.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, verprecio, vertotal, verid)
                End If
            Loop
            rd2.Close()
            cnn2.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub TFolioP_Tick(sender As Object, e As EventArgs) Handles TFolioP.Tick
        TFolioP.Stop()

        cnntimer.Close() : cnntimer.Open()
        cmdtimer = cnntimer.CreateCommand
        cmdtimer.CommandText = "SELECT MAX(Folio) FROM Ventas"
        rdtimer = cmdtimer.ExecuteReader
        If rdtimer.HasRows Then
            If rdtimer.Read Then
                lblfolio.Text = CDbl(IIf(rdtimer(0).ToString = "", "0", rdtimer(0).ToString)) + 1
            Else
                lblfolio.Text = "1"
            End If
        Else
            lblfolio.Text = "1"
        End If
        rdtimer.Close()
        cnntimer.Close()

        TFolioP.Start()
    End Sub

    Private Sub grdComandas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdComandas.CellClick


        Dim celda As DataGridViewCellEventArgs = e

        If celda.ColumnIndex = 4 Then

            CodigoProductoSel = grdComandas.CurrentRow.Cells(1).Value.ToString
            PCantidad.Visible = True
            txtCantidad.Focus.Equals(True)
            btnIntro.Enabled = True
            btnlimpiar.Enabled = True
        End If

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtCantidad.Text = txtCantidad.Text + btn1.Text
    End Sub

    Private Sub btnIntro_Click(sender As Object, e As EventArgs) Handles btnIntro.Click


        Dim totalnuevo As Double = 0
        Dim totalventa As Double = 0

        For q As Integer = 0 To grdComandas.Rows.Count - 1
            lblsubtotalmapeo.Text = "0.00"
            If grdComandas.Rows(q).Cells(1).Value = CodigoProductoSel Then

                grdComandas.Rows(q).Cells(4).Value = txtCantidad.Text
                totalnuevo = txtCantidad.Text * grdComandas.Rows(q).Cells(5).Value.ToString
                grdComandas.Rows(q).Cells(6).Value = FormatNumber(totalnuevo, 2)

            End If

        Next q

        For luffy As Integer = 0 To grdComandas.Rows.Count - 1
            totalventa = totalventa + grdComandas.Rows(luffy).Cells(6).Value.ToString
            lblsubtotalmapeo.Text = FormatNumber(totalventa, 2)
        Next

        PCantidad.Visible = False
        txtCantidad.Text = ""
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Me.Close()
        frmPolleria.Show()
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then
            btnIntro.PerformClick()
        End If

    End Sub


    Private Sub btnPrecuenta_Click(sender As Object, e As EventArgs) Handles btnPrecuenta.Click


        If grdComandas.Rows.Count <> 0 Then

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "DELETE FROM vtaimpresion"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            Dim zi As Integer = 0

            Dim codi As String = ""
            Dim nom As String = ""
            Dim udv As String = ""
            Dim canti As Double = 0
            Dim puvciva As Double = 0
            Dim TOTALL As Double = 0
            Dim idcoma As Integer = 0

            Dim CostVUE1 As Double = 0
            Dim PrecioSinIVA11 As Double = 0
            Dim TotalSinIVA11 As Double = 0
            Dim Depa11 As String = ""
            Dim Grupo11 As String = ""

            Do While zi <> grdComandas.Rows.Count

                codi = grdComandas.Rows(zi).Cells(1).Value.ToString
                nom = grdComandas.Rows(zi).Cells(2).Value.ToString
                udv = grdComandas.Rows(zi).Cells(3).Value.ToString
                canti = grdComandas.Rows(zi).Cells(4).Value.ToString
                puvciva = grdComandas.Rows(zi).Cells(5).Value.ToString
                TOTALL = grdComandas.Rows(zi).Cells(6).Value.ToString
                idcoma = grdComandas.Rows(zi).Cells(7).Value.ToString

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT PrecioCompra,PrecioVentaIVA,IVA,Departamento,Grupo FROM Productos WHERE Codigo='" & codi & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        CostVUE1 = rd1("PrecioCompra").ToString
                        PrecioSinIVA11 = FormatNumber((rd1("PrecioVentaIVA").ToString) / CDec(rd1("IVA").ToString + 1), 2)
                        TotalSinIVA11 = FormatNumber(CDec(PrecioSinIVA11) * (canti), 2)
                        Depa11 = rd1("Departamento").ToString
                        Grupo11 = rd1("Grupo").ToString
                    End If
                End If
                rd1.Close()

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO VtaImpresion(Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Mesa) VALUES('" & codi & "','" & nom & "'," & canti & ",'" & udv & "'," & puvciva & "," & CostVUE1 & "," & puvciva & "," & TOTALL & "," & PrecioSinIVA11 & "," & TotalSinIVA11 & ",'','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Depa11 & "','" & Grupo11 & "','1','" & lblmesa.Text & "')"
                cmd3.ExecuteNonQuery()
                cnn3.Close()

                zi = zi + 1
            Loop
            cnn1.Close()


            Dim tamimpre As Integer = 0
            Dim impresora As String = ""


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tamimpre = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='TICKET'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impresora = rd1(0).ToString
                End If
            Else
                MsgBox("No tienes una impresora configurada para imprimir en formato ticket.", vbInformation + vbOKOnly, titulomensajes)
                cnn1.Close()
            End If
            rd1.Close()
            cnn1.Close()

            If tamimpre = "80" Then
                Precuenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                Precuenta80.Print()
            End If

            If tamimpre = "58" Then
                Precuenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                Precuenta58.Print()
            End If
        End If
    End Sub

    Private Sub Precuenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Precuenta80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_a As New Font("Lucida Sans Typewriter", 12, FontStyle.Bold)

        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim pie1 As String = ""

        Dim cantidad As Double = 0
        Dim descri As String = ""
        Dim precio As Double = 0
        Dim TOTAL As Double = 0


        Dim ope As Double = 0
        Dim TotalIVA As Double = 0
        Try

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 FROM Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    pie1 = rd2("Pie1").ToString
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    Y += 12
                End If
            Else
                Y += 0
            End If
            rd2.Close()
            cnn2.Close()

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("P R E C U E N T A", fuente_b, Brushes.Black, 135, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Empleado: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 215, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Nombre,Precio,Total,Cantidad FROM vtaimpresion WHERE Mesa='" & lblmesa.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    descri = rd3("Nombre").ToString
                    precio = rd3("Precio").ToString
                    TOTAL = rd3("Total").ToString
                    cantidad = rd3("Cantidad").ToString

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & rd3("Codigo").ToString & "'"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then
                            ope = TOTAL / 1.16
                            TotalIVA = TotalIVA + CDec(ope) * CDec(rd3(0).ToString)
                            TotalIVA = FormatNumber(TotalIVA, 2)
                        End If
                    Loop
                    rd4.Close()

                    cantidad = FormatNumber(cantidad, 2)

                    e.Graphics.DrawString(cantidad, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                    Dim caracteresPorLineap As Integer = 40
                    Dim textop As String = descri
                    Dim iniciop As Integer = 0
                    Dim longitudTextop As Integer = textop.Length

                    While iniciop < longitudTextop
                        Dim longitudBloquep As Integer = Math.Min(caracteresPorLineap, longitudTextop - iniciop)
                        Dim bloquep As String = textop.Substring(iniciop, longitudBloquep)
                        e.Graphics.DrawString(bloquep, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 35, Y)
                        Y += 17
                        iniciop += caracteresPorLineap
                    End While

                    e.Graphics.DrawString(FormatNumber(precio, 2), fuente_p, Brushes.Black, 215, Y, derecha)
                    e.Graphics.DrawString(FormatNumber(TOTAL, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                    Y += 13

                End If
            Loop
            rd3.Close()
            cnn3.Close()
            cnn4.Close()

            Y += 7
            e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_a, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(lblsubtotalmapeo.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
            Y += 20

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            Dim CantidaLetra As String = ""
            CantidaLetra = "Son: " & convLetras(lblsubtotalmapeo.Text)

            Dim caracteresPorLinea As Integer = 40
            Dim texto As String = CantidaLetra
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                inicio += caracteresPorLinea
            End While

            Dim caracteresPorLinea1 As Integer = 40
            Dim texto1 As String = pie1
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto1.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 135, Y, centro)
                Y += 15
                inicio1 += caracteresPorLinea1
            End While
            Y += 5

            e.Graphics.DrawString("Le atiende: " & lblusuario2.Text, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 135, Y, centro)
            Y += 20


            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PCantidad.Visible = False
        txtCantidad.Text = ""
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtCantidad.Text = txtCantidad.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtCantidad.Text = txtCantidad.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtCantidad.Text = txtCantidad.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtCantidad.Text = txtCantidad.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtCantidad.Text = txtCantidad.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtCantidad.Text = txtCantidad.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtCantidad.Text = txtCantidad.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtCantidad.Text = txtCantidad.Text + btn9.Text
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtCantidad.Text = txtCantidad.Text + btn0.Text
    End Sub

    Private Sub btnpunto_Click(sender As Object, e As EventArgs) Handles btnpunto.Click
        txtCantidad.Text = txtCantidad.Text + btnpunto.Text
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        txtCantidad.Text = CutCad(txtCantidad.Text)
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            If MsgBox("¿Desea elimianr el pedidod de este cliente?", vbInformation + vbYesNo, titulocentral) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & lblmesa.Text & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "DELETE FROM comandas WHERE Nmesa='" & lblmesa.Text & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "DELETE FROM rep_comandas WHERE NMESA='" & lblmesa.Text & "'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

                MsgBox("Pedido eliminado correctamente.", vbInformation + vbOKOnly, titulocentral)

                Me.Close()
                frmPolleria.pEmpleado.Controls.Clear()
                frmPolleria.Empleados()
                frmPolleria.Show()
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboComanda_DropDown(sender As Object, e As EventArgs) Handles cboComanda.DropDown
        Try
            cboComanda.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Id FROM comandas WHERE Nmesa='" & lblmesa.Text & "'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboComanda.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboComanda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboComanda.SelectedValueChanged
        Try

            grdComandas.Rows.Clear()
            lblsubtotalmapeo.Text = "0.00"

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Id FROM comandas WHERE Id=" & cboComanda.Text & " AND Nmesa='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    grdComandas.Rows.Add(rd2(0).ToString,
                                         rd2(1).ToString,
                                         rd2(2).ToString,
                                         rd2(3).ToString,
                                         rd2(4).ToString,
                                         rd2(5).ToString,
                                         rd2(6).ToString,
                                         rd2(7).ToString)

                    lblsubtotalmapeo.Text = lblsubtotalmapeo.Text + CDec(rd2(6).ToString)

                End If
            Loop
            rd2.Close()
            cnn2.Close()
            lblsubtotalmapeo.Text = FormatNumber(lblsubtotalmapeo.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub traercomanda()

        Try
            grdComandas.Rows.Clear()
            lblsubtotalmapeo.Text = "0.00"

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Id FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    vercomanda = rd2("IDC").ToString
                    vercodigo = rd2("Codigo").ToString
                    verdescripcion = rd2("Nombre").ToString
                    verunidad = rd2("UVenta").ToString
                    vercantidad = rd2("Cantidad").ToString
                    verprecio = rd2("Precio").ToString
                    vertotal = rd2("Total").ToString
                    verid = rd2("Id").ToString
                    grdComandas.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, verprecio, vertotal, verid)

                    lblsubtotalmapeo.Text = lblsubtotalmapeo.Text + vertotal
                End If
            Loop
            rd2.Close()
            cnn2.Close()
            lblsubtotalmapeo.Text = FormatNumber(lblsubtotalmapeo.Text, 2)
            cboComanda.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        lblforma.Text = ""
        cboComanda.Text = ""
        grdComandas.Rows.Clear()
        traercomanda()
    End Sub

    Public Function GuardarVenta(ByVal formapago) As String

        Dim mypago As Double = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "DELETE FROM vtaimpresion"
        cmd1.ExecuteNonQuery()
        cnn1.Close()

        mypago = CDec(lblsubtotalmapeo.Text)


        Dim CODIGO As String = ""
        Dim canti As Double = 0
        Dim totcomi As Double = 0
        Dim TIva As Double = 0

        Dim precio As Double = 0
        Dim totals As Double = 0
        Dim IVA As Double = 0
        Dim TOTIVA As Double = 0
        For luffy As Integer = 0 To grdComandas.Rows.Count - 1
            CODIGO = grdComandas.Rows(luffy).Cells(1).Value.ToString
            canti = grdComandas.Rows(luffy).Cells(4).Value.ToString

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT IVA,Comision,PrecioVentaIVA FROM Productos WHERE Codigo='" & CODIGO & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    totcomi = totcomi + CDec(CDec(canti) * CDec(rd2("Comision").ToString))
                    If rd2("IVA").ToString = 0 Then
                    Else
                        precio = rd2("PrecioVentaIVA").ToString
                        totals = CDec(canti) * CDec(precio)

                        TIva = CDec(totals) * (1 + rd2("IVA").ToString)
                        IVA = CDec(TIva) - CDec(totals)


                        TOTIVA = TOTIVA + IVA
                        'TIva = CDec(TIva) + (canti * CDec(CDec((CDec(rd2("PrecioVentaIVA").ToString / (1 + rd2("IVA").ToString)) * 0.16))))
                    End If

                End If
            End If

            rd2.Close()
            cnn2.Close()
        Next

#Region "CODIGO AUTOFACTURAR"
        Dim letras As String
        Dim letters As String = ""
        Dim pc As String = lblfolio.Text
        Dim opee As Double = 0
        Dim lic As String = ""
        Dim numeros As String
        Dim car As String

        opee = Math.Cos(CDec(pc))
        If opee > 0 Then
            pc = Strings.Left(Replace(CStr(opee), ".", "9"), 10)
        Else
            pc = Strings.Left(Replace(CStr(Math.Abs(opee)), ".", "8"), 10)
        End If
        For i = 1 To 10
            car = Mid(lblfolio.Text, i, 1)
            Select Case car
                Case Is = 0
                    letters = letters & "Y"
                Case Is = 1
                    letters = letters & "Z"
                Case Is = 2
                    letters = letters & "W"
                Case Is = 3
                    letters = letters & "X"
                Case Is = 4
                    letters = letters & "T"
                Case Is = 5
                    letters = letters & "B"
                Case Is = 6
                    letters = letters & "A"
                Case Is = 7
                    letters = letters & "D"
                Case Is = 8
                    letters = letters & "C"
                Case Is = 9
                    letters = letters & "P"
                Case Else
                    letters = letters & car
            End Select

        Next
        For i = 1 To 10 Step 2
            numeros = Mid(pc, i, 2)
            letras = Mid(letters, i, 2)
            lic = lic & numeros & letras & "-"
        Next
        lic = Strings.Left(lic, lic.Length - 1)
#End Region

        Dim SUBTOTAL1 As Double = 0
        SUBTOTAL1 = CDec(lblsubtotalmapeo.Text) - CDec(TOTIVA)

        Dim totalventa As Double = 0
        totalventa = lblsubtotalmapeo.Text

        cnn3.Close() : cnn3.Open()
        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "INSERT INTO ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Propina,Usuario,FVenta,HVenta,FPago,Status,Descuento,Comisionista,TComensales,Corte,CorteU,CodFactura,IP,Fecha) VALUES('','" & lblmesa.Text & "',''," & SUBTOTAL1 & "," & TOTIVA & "," & totalventa & "," & totalventa & ",0,0,'" & lblusuario2.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','PAGADO',0,'','','1','0','" & lic & "','" & dameIP2() & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
        cmd3.ExecuteNonQuery()
        cnn3.Close()

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT MAX(Folio) FROM Ventas"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                folio = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        Dim deku As Integer = 0
        Dim mycodigo As String = ""
        Dim mydescripcion As String = ""
        Dim myunidad As String = ""
        Dim mycantidad As Double = 0
        Dim myprecio As Double = 0
        Dim mytotal As Double = 0

        Dim COSTVUE1 As Double = 0
        Dim PRECIOSINIVA1 As Double = 0
        Dim DEPA As String = ""
        Dim GRUPO As String = ""
        Dim TOTALSIVA As Double = 0
        Dim MULTIPLO As Double = 0

        Dim varieps As String = ""
        Dim vartotal As String = ""

        Do While deku <> grdComandas.Rows.Count

            mycodigo = grdComandas.Rows(deku).Cells(1).Value.ToString
            mydescripcion = grdComandas.Rows(deku).Cells(2).Value.ToString
            myunidad = grdComandas.Rows(deku).Cells(3).Value.ToString
            mycantidad = grdComandas.Rows(deku).Cells(4).Value.ToString
            myprecio = grdComandas.Rows(deku).Cells(5).Value.ToString
            mytotal = grdComandas.Rows(deku).Cells(6).Value.ToString

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT PrecioCompra,PrecioVentaIVA,iva,Departamento,Grupo,Multiplo FROM Productos WHERE Codigo='" & mycodigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    COSTVUE1 = rd2("PrecioCompra").ToString
                    PRECIOSINIVA1 = FormatNumber(rd2("PrecioVentaIVA").ToString / CDec(rd2("iva").ToString + 1), 2)
                    DEPA = rd2("Departamento").ToString
                    GRUPO = rd2("Grupo").ToString
                    MULTIPLO = rd2("Multiplo").ToString

                    If CDec(rd2("IVA").ToString) > 0 Then
                        TOTALSIVA = FormatNumber(mytotal / 1.16, 2)
                    Else
                        TOTALSIVA = "0.00"
                    End If
                End If
            End If
            rd2.Close()
            cnn2.Close()

            varieps = 0
            vartotal = 0

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO ventasdetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,TasaIEPS,TotalIEPS,Descto) VALUES(" & folio & ",'" & mycodigo & "','" & mydescripcion & "','" & myunidad & "'," & mycantidad & "," & myprecio & "," & COSTVUE1 & "," & myprecio & "," & mytotal & "," & PRECIOSINIVA1 & "," & TOTALSIVA & ",'','" & Format(Date.Now, "yyyy-MM-dd") & "','" & DEPA & "','" & GRUPO & "',''," & varieps & "," & vartotal & ",0)"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO vtaimpresion(Folio,Codigo,Nombre,UVenta,Cantidad,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,comensal,Propina,Mesa) VALUES(" & folio & ",'" & mycodigo & "','" & mydescripcion & "','" & myunidad & "'," & mycantidad & "," & myprecio & "," & COSTVUE1 & "," & myprecio & "," & mytotal & "," & PRECIOSINIVA1 & "," & TOTALSIVA & ",'','" & Format(Date.Now, "yyyy-MM-dd") & "','" & DEPA & "','" & GRUPO & "','',0,'" & lblmesa.Text & "')"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE Rep_Comandas SET Status='PAGADO' WHERE NMESA='" & lblmesa.Text & "' AND Status='ORDENADA'"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "DELETE FROM Comandas WHERE Nmesa='" & lblmesa.Text & "'"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            deku = deku + 1
        Loop

        Dim MontoEffe As Double = 0

        MontoEffe = lblsubtotalmapeo.Text

        If CDec(MontoEffe) > 0 Then

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Propina,Monto,Banco,Referencia,Comentario,Usuario,Comisiones) VALUES(" & folio & ",0,'" & lblmesa.Text & "','ABONO','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','0'," & MontoEffe & ",'0','" & formapago & "','0'," & MontoEffe & ",'','','','" & lblusuario2.Text & "'," & totcomi & ")"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

        End If

        Dim existencia_inicial As Double = 0
        Dim opeCantReal As Double = 0
        Dim opediferencia As Double = 0

        Dim VarCodigo As String = ""
        Dim VarDesc As String = ""
        Dim VarCanti As Double = 0

        For koni = 0 To grdComandas.Rows.Count - 1
            existencia_inicial = 0
            opeCantReal = 0
            opediferencia = 0


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Multiplo,Modo_Almacen,Existencia FROM Productos WHERE Codigo='" & mycodigo & "' "
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MULTIPLO = rd1("Multiplo").ToString

                    If rd1("Modo_Almacen").ToString = 1 Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT CodigoP,Codigo,Descrip,Cantidad FROM MiProd WHERE CodigoP='" & grdComandas.Rows(koni).Cells(1).Value.ToString & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            If rd2.HasRows Then
                                existencia_inicial = 0
                                opeCantReal = 0
                                opediferencia = 0

                                VarCodigo = rd2("Codigo").ToString
                                VarDesc = rd2("Descrip").ToString
                                VarCanti = rd2("Cantidad").ToString * grdComandas.Rows(koni).Cells(4).Value.ToString

                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "SELECT Existencia,Multiplo FROM Productos WHERE Codigo='" & VarCodigo & "'"
                                rd3 = cmd3.ExecuteReader
                                If rd3.HasRows Then
                                    If rd3.Read Then
                                        existencia_inicial = rd3("Existencia").ToString
                                        opeCantReal = CDec(VarCanti) * CDec(rd1("Multiplo").ToString)
                                        opediferencia = existencia_inicial + opeCantReal

                                        cnn4.Close() : cnn4.Open()
                                        cmd4 = cnn4.CreateCommand
                                        cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) VALUES('" & VarCodigo & "','" & VarDesc & "','Venta-Ingrediente'," & opeCantReal & "," & CDec(rd1("PrecioCompra").ToString) & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblusuario2.Text & "'," & existencia_inicial & "," & opediferencia & "," & folio & ")"
                                        cmd4.ExecuteNonQuery()
                                        cnn4.Close()
                                    End If
                                End If
                                rd3.Close()

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "UPDATE Productos SET Existencia=Existencia-" & rd2("Cantidad").ToString * grdComandas.Rows(koni).Cells(4).Value.ToString & " * " & MULTIPLO & " WHERE Codigo='" & VarCodigo & "'"
                                cmd4.ExecuteNonQuery()

                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "INSERT INTO Mov_Ingre(Codigo,Descripcion,Cantidad,Fecha) VALUES('" & VarCodigo & "','" & VarDesc & "'," & VarCanti & ",'" & Format(Date.Now, "yyyy/MM/dd") & "')"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()
                            End If
                        Loop
                        rd2.Close()
                        cnn2.Close()
                        cnn3.Close()

                    Else

                        existencia_inicial = 0
                        opeCantReal = 0
                        opediferencia = 0

                        existencia_inicial = rd1("Existencia").ToString
                        opeCantReal = CDec(VarCanti) * CDec(MULTIPLO)
                        opediferencia = existencia_inicial - opeCantReal


                        cnn4.Close() : cnn4.Open()
                        cmd4 = cnn4.CreateCommand
                        cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) VALUES('" & VarCodigo & "','" & VarDesc & "','Venta-Ingrediente'," & opeCantReal & "," & CDec(rd1("PrecioCompra").ToString) & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblusuario2.Text & "'," & existencia_inicial & "," & opediferencia & "," & folio & ")"
                        cmd4.ExecuteNonQuery()

                        cmd4 = cnn4.CreateCommand
                        cmd4.CommandText = "UPDATE Productos SET Existencia=Existencia-" & grdComandas.Rows(koni).Cells(4).Value.ToString & " * " & MULTIPLO & " WHERE Codigo='" & grdComandas.Rows(koni).Cells(1).Value.ToString & "'"
                        cmd4.ExecuteNonQuery()
                        cnn4.Close()
                    End If

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Next

#Region "TICKET"

        Dim copias As Integer = 0
        Dim TamImpre As Integer = 0
        Dim impresora As String = ""
        Dim imprime As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Copias FROM Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                copias = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                TamImpre = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NoPrint FROM Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                imprime = rd1(0).ToString
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
        Else
            MsgBox("No tienes una impresora configurada para imprimir en formato Ticket.", vbInformation + vbOKOnly, titulomensajes)
            cnn1.Close()
        End If
        rd1.Close()
        cnn1.Close()

        If imprime = 1 Then

            If MessageBox.Show("Desea Cerrar esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then

                If TamImpre = "80" Then
                    For naruto As Integer = 1 To copias
                        PVenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PVenta80.Print()
                    Next
                End If

                If TamImpre = "58" Then
                    For naruto As Integer = 1 To copias
                        PVenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PVenta58.Print()
                    Next
                End If
            End If

        Else
            If TamImpre = "80" Then
                For naruto As Integer = 1 To copias
                    PVenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PVenta80.Print()
                Next
            End If

            If TamImpre = "58" Then
                For naruto As Integer = 1 To copias
                    PVenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PVenta58.Print()
                Next
            End If

        End If

#End Region

        cnn3.Close() : cnn3.Open()
        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "DELETE FROM Comanda1 WHERE Nombre='" & lblmesa.Text & "'"
        cmd3.ExecuteNonQuery()
        cnn3.Close()


        btnlimpiar.PerformClick()
        Me.Close()

        frmPolleria.Show()

    End Function

    Private Sub btnEfectivo_Click(sender As Object, e As EventArgs) Handles btnEfectivo.Click
        btnTarjeta.Enabled = False
        btnTransfe.Enabled = False
        lblforma.Text = "EFECTIVO"
        GuardarVenta("EFECTIVO")
    End Sub

    Private Sub btnTarjeta_Click(sender As Object, e As EventArgs) Handles btnTarjeta.Click
        btnEfectivo.Enabled = False
        btnTransfe.Enabled = False
        lblforma.Text = "TARJETA"
        GuardarVenta("TARJETA")
    End Sub

    Private Sub btnTransfe_Click(sender As Object, e As EventArgs) Handles btnTransfe.Click
        btnEfectivo.Enabled = False
        btnTarjeta.Enabled = False
        lblforma.Text = "TRANSFERENCIA"
        GuardarVenta("TRANSFERENCIA")
    End Sub

    Private Sub PVenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVenta80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_a As New Font("Lucida Sans Typewriter", 12, FontStyle.Bold)

        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim Logotipo As Drawing.Image = Nothing

        Dim foliofactura As String = ""

        Dim pie1 As String = ""

        Dim TotalIVA As Double = 0
        Dim ope As Double = 0
        Dim articulos As Double = 0

        Dim nombrepro As String = ""
        Dim preciopro As Double = 0
        Dim importepro As Double = 0
        Dim cantidadpro As Double = 0
        Dim usuario As String = ""

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select CodFactura FROM Ventas WHERE Folio=" & folio
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    foliofactura = rd2(0).ToString
                End If
            End If
            rd2.Close()

            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 95
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 95
                End If
            Else
                Y = 0
            End If


            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    pie1 = rd2("Pie1").ToString
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
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd2.Close()
            cnn2.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Empleado: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Folio: " & folio, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 23
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 215, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            cnn4.Close() : cnn4.Open()
            cnn3.Close() : cnn3.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT Codigo,Nombre,Precio,Total,Cantidad FROM vtaimpresion WHERE Mesa='" & lblmesa.Text & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then
                    nombrepro = rd4("Nombre").ToString
                    preciopro = rd4("Precio").ToString
                    importepro = rd4("Total").ToString
                    cantidadpro = rd4("Cantidad").ToString

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & rd4("Codigo").ToString & "'"
                    rd3 = cmd3.ExecuteReader
                    Do While rd3.Read
                        If rd3.HasRows Then
                            ope = importepro / 1.16
                            TotalIVA = TotalIVA + CDec(ope) * CDec(rd3(0).ToString)
                        End If
                    Loop
                    rd3.Close()

                    e.Graphics.DrawString(FormatNumber(cantidadpro, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                    Dim caracteresPorLinea As Integer = 40
                    Dim texto As String = nombrepro
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40, Y)
                        Y += 13
                        inicio += caracteresPorLinea
                    End While

                    e.Graphics.DrawString(simbolo & " " & preciopro, fuente_p, Brushes.Black, 200, Y, derecha)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(importepro, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                    Y += 13

                    articulos = articulos + cantidadpro

                End If
            Loop
            rd4.Close()
            cnn4.Close()
            cnn3.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 15

            If TotalIVA <> 0 Then

                If DesglosaIVA = 1 Then
                    e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(subtotalmapeo) - CDec(TotalIVA), 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 25
                    e.Graphics.DrawString("IVA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TotalIVA, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 25
                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(lblsubtotalmapeo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 25
                End If

                e.Graphics.DrawString("TOTAL A PAGAR", fuente_a, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(lblsubtotalmapeo.Text), 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 25
            Else
                e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_a, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(lblsubtotalmapeo.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 25

            End If

            If lblforma.Text <> "" Then
                e.Graphics.DrawString(lblforma.Text, fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(lblsubtotalmapeo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            Dim cantidadLetra As String = ""
            cantidadLetra = convLetras(lblsubtotalmapeo.Text)

            Dim caracteresPorLinea1 As Integer = 40
            Dim texto1 As String = cantidadLetra
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto1.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio1 += caracteresPorLinea1
            End While

            Dim caracteresPorLinea2 As Integer = 40
            Dim texto2 As String = pie1
            Dim inicio2 As Integer = 0
            Dim longitudTexto2 As Integer = texto2.Length

            While inicio2 < longitudTexto2
                Dim longitudBloque2 As Integer = Math.Min(caracteresPorLinea2, longitudTexto2 - inicio2)
                Dim bloque2 As String = texto2.Substring(inicio2, longitudBloque2)
                e.Graphics.DrawString(bloque2, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40, Y)
                Y += 13
                inicio2 += caracteresPorLinea2
            End While

            e.Graphics.DrawString("Lo atendio: " & usuario, fuente_r, Brushes.Black, 135, Y, sc)
            Y += 15

            If facLinea = 1 Then
                e.Graphics.DrawString("Folio para Facturar", fuente_b, Brushes.Black, 135, Y, sc)
                Y += 15
                e.Graphics.DrawString(foliofactura, fuente_b, Brushes.Black, 135, Y, sc)
            Else

            End If

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try


    End Sub

    Private Sub grdComandas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdComandas.CellDoubleClick

        Dim index As Integer = grdComandas.CurrentRow.Index

        Dim idc As Integer = grdComandas.Rows(index).Cells(0).Value.ToString
        Dim id As Integer = grdComandas.Rows(index).Cells(7).Value.ToString
        Dim importe As Double = grdComandas.Rows(index).Cells(6).Value.ToString

        lblsubtotalmapeo.Text = lblsubtotalmapeo.Text - importe
        lblsubtotalmapeo.Text = FormatNumber(lblsubtotalmapeo.Text, 2)



        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "DELETE FROM Comandas WHERE IDC=" & idc & " and Id=" & id & ""
        cmd1.ExecuteNonQuery()
        cnn1.Close()



        grdComandas.Rows.Remove(grdComandas.CurrentRow)
    End Sub
End Class