
Imports System.IO
Public Class frmIngresoDispositivo

    Public idempleado As Integer = 0
    Public idcliente As Integer = 0
    Public folio As Integer = 0
    Private Sub frmIngresoDispositivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        cboimpresion.Text = "TICKET"
    End Sub

    Private Sub cboSerie_DropDown(sender As Object, e As EventArgs) Handles cboSerie.DropDown

        Try
            cboSerie.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT SerieD FROM tallerd WHERE SerieD<>'' AND Status<>'Equipo reparado' ORDER BY SerieD"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboSerie.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub

    Private Sub cboSerie_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSerie.SelectedValueChanged

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            Dim IDCLIENTE As Integer = 0
            Dim MySaldo As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Fallas,Status,Tecnico,Id,Cliente FROM tallerd WHERE SerieD='" & cboSerie.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtfallas.Text = rd1(0).ToString
                    cboStatus.Text = rd1(1).ToString
                    txtTecnico.Text = rd1(2).ToString
                    txtOrden.Text = rd1(3).ToString
                    txtcliente.Text = rd1(4).ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Marca,Modelo FROM dispositivos WHERE Serie='" & cboSerie.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtMarca.Text = rd2(0).ToString
                            txtModelo.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Id,Credito FROM Clientes WHERE Nombre='" & txtcliente.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            IDCLIENTE = rd2("Id").ToString
                            txtMaximo.Text = FormatNumber(rd2("Credito").ToString, 2)
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "select Saldo from Abono where Id=(select max(Id) from Abono where IdCliente=" & IDCLIENTE & ")"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            MySaldo = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                            If MySaldo < 0 Then
                                txtadeuda.Text = "0.00"
                                txtFavor.Text = Math.Abs(MySaldo)
                                txtFavor.Text = FormatNumber(txtFavor.Text, 2)
                            Else
                                txtFavor.Text = "0.00"
                                txtadeuda.Text = Math.Abs(MySaldo)
                                txtadeuda.Text = FormatNumber(txtadeuda.Text, 2)
                            End If
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()

                End If
            End If
            cnn2.Close()
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        txtTotal.Text = CDbl(IIf(txtCantidad.Text = "" Or txtCantidad.Text = ".", "0", txtCantidad.Text)) * CDbl(IIf(txtPrecio.Text = "" Or txtPrecio.Text = ".", "0", txtPrecio.Text))
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        Call Actualiza()
    End Sub

    Private Sub Actualiza()
        If txtSubTotal.Tag = 0 Then
            txtSubTotal.Text = txtSubTotal.Text
            txtSubTotal.Text = CDbl(IIf(txtSubTotal.Text = "", "0", txtSubTotal.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text))
            txtSubTotal.Text = FormatNumber(txtSubTotal.Text, 2)
        End If
        If txtSubTotal.Tag <> 0 Then
            txtSubTotal.Text = txtSubTotal.Text
        End If
    End Sub

    Private Sub UpGrid()
        Try

            Dim TPapel As String = ""
            Dim Alerta_Min As Boolean = False
            Dim Acumula As Boolean = False
            Dim minimo As Double = 0

            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='TPapelV'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TPapel = rd3(0).ToString
                End If
            End If
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='MinimoA'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Alerta_Min = IIf(rd3(0).ToString() = "1", True, False)
                End If
            End If
            rd3.Close()

            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='Acumula'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Acumula = IIf(rd3(0).ToString() = "1", True, False)
                End If
            End If
            rd3.Close()
            cnn3.Close()

            If TPapel = "MEDIA CARTA" Then
                If grdCaptura.Rows.Count > 13 Then
                    MsgBox("Se establecen 13 partidas como máximo para el formato de impresión 'MEDIA CARTA'", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
            End If

            Dim Val_Punto As Integer = 0
            Dim Mid_precio As String = ""

            Dim codigo As String = cboCodigo.Text
            Dim nombre As String = cboDescripcion.Text
            Dim unidad As String = txtUnidad.Text
            Dim cantid As Double = IIf(txtCantidad.Text = "", "0", txtCantidad.Text)
            Dim precio As Double = 0

            Val_Punto = InStr(1, txtPrecio.Text, ".")
            If Val_Punto = 0 Then
                precio = FormatNumber(txtPrecio.Text, 2)
            Else
                Mid_precio = Mid(txtPrecio.Text, Val_Punto, 20)
                If Len(Mid_precio) = 2 Then
                    precio = FormatNumber(txtPrecio.Text, 2)
                ElseIf Len(Mid_precio) > 2 Then
                    precio = FormatNumber(txtPrecio.Text, 2)
                End If
            End If

            Dim total As Double = txtTotal.Text
            Dim existencia As Double = 0
            If unidad <> "N/A" Then
                existencia = txtexistencia.Text
            Else
                existencia = 0
            End If

            Dim PU As Double = CDbl(txtTotal.Text) / (1 + IvaDSC(cboCodigo.Text))
            Dim IvaIeps As Double = PU - (PU / (1 + ProdsIEPS(cboCodigo.Text)))
            Dim ieps As Double = ProdsIEPS(cboCodigo.Text)

            Dim desucentoiva As Double = 0
            Dim total1 As Double = 0
            Dim monedero As Double = 0
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select IVA,Promo_Monedero,Min from Productos where Codigo='" & cboCodigo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    monedero = rd3(1).ToString()
                    minimo = rd3(2).ToString()
                    If CDbl(rd3(0).ToString) = 0.16 Then
                        desucentoiva = FormatNumber(CDbl(txtTotal.Text) / 1.16, 2)
                        total1 = FormatNumber(CDbl(txtTotal.Text) / 1.16, 2)
                    Else
                        desucentoiva = FormatNumber(txtTotal.Text, 2)
                        total1 = 0
                    End If
                End If
            Else
                desucentoiva = FormatNumber(txtTotal.Text, 2)
                total1 = 0
            End If
            rd3.Close()
            cnn3.Close()

            If Acumula = True Then
                If grdCaptura.Rows.Count <> 0 Then
                    For naruto As Integer = 0 To grdCaptura.Rows.Count - 1
                        'El código corto es igual
                        If grdCaptura.Rows(naruto).Cells(0).Value.ToString = "" Then Continue For
                        If grdCaptura.Rows(naruto).Cells(0).Value.ToString = codigo Then
                            'El lote es igual
                            If grdCaptura.Rows(naruto).Cells(8).Value.ToString() = codigo Then
                                'Agrega en el mismo registro porque el código y el lote son iguales
                                Dim canti As Double = grdCaptura.Rows(naruto).Cells(3).Value.ToString()
                                Dim nueva_cant As Double = canti + cantid
                                Dim preci As Double = grdCaptura.Rows(naruto).Cells(4).Value.ToString()

                                Dim nuevo_precio As Double = 0
                                'If cbotipo.Visible = True Then
                                '    nuevo_precio = preci
                                'Else
                                '    nuevo_precio = ConsultaPrecio(codigo, nueva_cant)
                                'End If


                                grdCaptura(3, naruto).Value = nueva_cant
                                grdCaptura(5, naruto).Value = FormatNumber((nueva_cant * nuevo_precio), 2)
                            Else
                                'Agrega uno nuevo porque el codigo es el mismo pero el lote no
                                grdCaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero)
                            End If
                        Else
                            'Agrega normal uno nuevo
                            grdCaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero)
                        End If
                    Next
                Else
                    'Es el primer registro que agrega y lo pone normal
                    grdCaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero)
                End If
            Else
                'Sólo agrega uno y ya
                grdCaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), FormatNumber(total, 2), existencia, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero)
            End If

            If Alerta_Min = True Then
                If (existencia - cantid) <= minimo Then
                    MsgBox("Se ha alcanzo el mínimo en almacén para este producto.", vbCritical & vbOKOnly, "Delsscom Control Negocios Pro")
                End If
            End If
            cboDescripcion.Focus.Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Function IvaDSC(ByVal cod As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "SELECT IVA from Productos WHERE Codigo='" & cod & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    IvaDSC = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
                End If
            Else
                IvaDSC = 0
            End If
            rd3.Close()
            cnn3.Close()
            Return IvaDSC
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboSerie.Text = ""
        cboStatus.Text = ""
        txtTecnico.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtOrden.Text = ""
        txtfallas.Text = ""
        txtcliente.Text = ""
        txtMaximo.Text = "0.00"
        txtadeuda.Text = "0.00"
        txtFavor.Text = "0.00"

        cboCodigo.Text = ""
        cboDescripcion.Text = ""
        txtUnidad.Text = ""
        txtCantidad.Text = ""
        txtPrecio.Text = "0.00"
        txtTotal.Text = "0.00"
        txtexistencia.Text = ""
        txtSubTotal.Text = "0.00"
        txtdescuento2.Text = "0.00"
        txtPagar.Text = "0.00"
        grdCaptura.Rows.Clear()
        cboimpresion.Text = "TICKET"
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim Tpagar As Single = 0, tmpIva As Single = 0, tmpDsct As Single = 0, tmpSub As Single = 0
        Dim index As Integer = grdCaptura.CurrentRow.Index

        Dim CODx As String = ""
        Dim CantDX As Double = 0
        Dim MyNota As String = ""

        cboDescripcion.Focus().Equals(True)

        If grdCaptura.Rows.Count > 0 Then
            cboCodigo.Text = grdCaptura.Rows(index).Cells(0).Value.ToString
            cboDescripcion.Text = grdCaptura.Rows(index).Cells(1).Value.ToString
            txtUnidad.Text = grdCaptura.Rows(index).Cells(2).Value.ToString
            txtCantidad.Text = "" ' grdcaptura.Rows(index).Cells(3).Value.ToString
            txtPrecio.Text = FormatNumber(grdCaptura.Rows(index).Cells(4).Value.ToString, 2)
            txtPrecio.Tag = FormatNumber(grdCaptura.Rows(index).Cells(4).Value.ToString, 2)
            txtTotal.Text = FormatNumber(grdCaptura.Rows(index).Cells(5).Value.ToString, 2)
            ' txtexistencia.Text = grdCaptura.Rows(index).Cells(6).Value.ToString

            If grdCaptura.Rows.Count = 1 Then
                CODx = grdCaptura.Rows(index).Cells(0).Value.ToString
                CantDX = grdCaptura.Rows(index).Cells(3).Value.ToString
                grdCaptura.Rows.Clear()
            Else
                CODx = grdCaptura.Rows(index).Cells(0).Value.ToString
                CantDX = grdCaptura.Rows(index).Cells(3).Value.ToString
                If grdCaptura.Rows(index).Cells(1).Value.ToString <> "" And grdCaptura.Rows(index).Cells(0).Value.ToString = "" Then
                    MyNota = grdCaptura.Rows(index).Cells(1).Value.ToString
                    If grdCaptura.Rows.Count = 1 Then
                        grdCaptura.Rows.Clear()
                    Else
                        grdCaptura.Rows.Remove(grdCaptura.Rows(index))
                    End If
                Else
                    grdCaptura.Rows.Remove(grdCaptura.Rows(index))
                End If
            End If

            Dim SUBsinIVA As Double = 0
            Dim SinDesct As Double = 0

            If txtSubTotal.Text = "0.00" Or CDbl(txtSubTotal.Text) = 0 Then cboDescripcion.Focus().Equals(True)
            txtPagar.Text = CDbl(txtPagar.Text) - CDbl(txtTotal.Text)
            txtSubTotal.Text = CDbl(txtSubTotal.Text) - CDbl(txtTotal.Text)

            cboCodigo.Focus().Equals(True)
            txtPagar.Text = FormatNumber(txtPagar.Text, 2)
            txtSubTotal.Text = FormatNumber(txtSubTotal.Text, 2)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0

            Dim Cliente As String = ""
            Dim IdCliente As Integer = 0
            Dim dias_credito As Double = 0
            Dim max_cred As Double = 0

            Dim VarUser As String = "", VarIdUsuario As Integer = 0

            Dim TotalIEPSPrint As Double = 0

            If cboSerie.Text = "" Then MsgBox("Debe seleccionar la serie del equipo", vbInformation + vbOKOnly, titulotaller) : cboSerie.Focus.Equals(True) : Exit Sub

            If lblusuario.Text = "" Then MsgBox("Debe de ingresar la contraseña", vbInformation + vbOKOnly, titulotaller) : txtcontra.Focus.Equals(True)

            If grdCaptura.Rows.Count > 0 Then
                cnn1.Close() : cnn1.Open()

                For d As Integer = 0 To grdCaptura.Rows.Count - 1

                    If CStr(grdCaptura.Rows(d).Cells(0).Value.ToString) <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                        "SELECT IVA FROM Productos WHERE Codigo='" & CStr(grdCaptura.Rows(d).Cells(0).Value.ToString) & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                If CDbl(grdCaptura.Rows(d).Cells(10).Value.ToString) <> 0 Then
                                    MySubtotal = MySubtotal + (CDbl(grdCaptura.Rows(d).Cells(10).Value.ToString) - (CDbl(grdCaptura.Rows(d).Cells(9).Value.ToString)))

                                    Dim iva As Double = rd1(0).ToString

                                    If iva > 0 Then
                                        Dim preciosiniva = grdCaptura.Rows(d).Cells(4).Value.ToString / CDbl(1 + iva)

                                        TotalIVAPrint = preciosiniva
                                    End If

                                    'TotalIVAPrint = TotalIVAPrint + (CDbl(grdCaptura.Rows(d).Cells(10).Value.ToString) - (CDbl(grdCaptura.Rows(d).Cells(9).Value.ToString)) * CDbl(rd1(0).ToString))
                                End If
                            End If
                        End If
                        rd1.Close()
                    End If
                Next
                cnn1.Close()
                TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
                MySubtotal = FormatNumber(MySubtotal, 4)


                If txtcliente.Text <> "" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "select Id,DiasCred from Clientes where Nombre='" & txtcliente.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            IdCliente = rd1("Id").ToString
                            Cliente = txtcliente.Text
                            dias_credito = rd1("DiasCred").ToString()
                        End If
                    Else
                        IdCliente = 0
                        Cliente = ""
                        dias_credito = 0
                    End If
                    rd1.Close()
                    cnn1.Close()
                End If

                If lblusuario.Text = "" Then
                    MsgBox("Escribe/Revisa tu contraseña para continuar.", vbInformation + vbOKOnly, titulotaller)
                    cnn1.Close()
                    txtcontra.Focus().Equals(True) : Exit Sub
                Else
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Alias,IdEmpleado FROM Usuarios WHERE Clave='" & txtcontra.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            VarUser = rd1("Alias").ToString
                            VarIdUsuario = rd1("IdEmpleado").ToString
                        End If
                    Else
                        MsgBox("No se encuentra un usuario registrado bajo esta contraseña.", vbInformation + vbOKOnly, titulotaller)
                        rd1.Close() : cnn1.Close()
                        txtcontra.Focus().Equals(True) : Exit Sub
                    End If
                    rd1.Close()
                    cnn1.Close()
                End If

                Dim per_venta As Integer = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT Vent_NVen FROM Permisos WHERE IdEmpleado= " & VarIdUsuario
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        per_venta = rd1("Vent_NVen").ToString
                    End If
                End If
                rd1.Close() : cnn1.Close()

                If per_venta = 0 Then
                    MsgBox("No cuentas con permiso para realizar notas de venta.", vbInformation + vbOKOnly, titulotaller)
                    Exit Sub
                End If

                If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, titulotaller) = vbCancel Then cnn1.Close() : Exit Sub

                Dim credito_dispo As Double = (CDbl(txtMaximo.Text) + CDbl(txtFavor.Text)) - ((CDbl(txtPagar.Text) + CDbl(txtadeuda.Text)))

                If CDbl(txtPagar.Text) > 0 Then
                    If txtcliente.Text <> "MOSTRADOR" And ((CDbl(txtPagar.Text) + CDbl(txtadeuda.Text))) > (CDbl(txtMaximo.Text) + CDbl(txtFavor.Text)) Then
                        MsgBox("No se puede completar la operación porque se rebasaría el crédito disponible." & vbNewLine & "Crédito disponible: " & FormatNumber(credito_dispo, 2) & ".", vbInformation + vbOKOnly, titulotaller)
                        cnn1.Close() : Exit Sub
                    End If
                End If

                Dim ACuenta As Double = 0

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
                    Numeros = Mid(lblfolio.Text, w, 2)
                    Letras = Mid(letters, w, 2)
                    lic = lic & Numeros & Letras & "-"
                Next
                lic = Strings.Left(lic, Len(lic) - 1)
                CodCadena = lic

                Dim Resta As Double = 0
                Dim MyMonto As Double = 0
                Dim ACUenta2 As Double = 0
                Dim MyStatus As String = ""

                Dim SubTotal As Double = 0
                Dim IVA_Vent As Double = 0
                Dim Total_Ve As Double = 0
                Dim Descuento As Double = 0
                Dim MontoSDesc As Double = 0
                Select Case txtcliente.Text
                    Case Is <> "MOSTRADOR"

                        Resta = FormatNumber(txtPagar.Text, 2)
                        MySubtotal = FormatNumber(MySubtotal, 2)

                        If MyMonto > CDbl(txtPagar.Text) Then
                            ACUenta2 = FormatNumber(CDbl(txtPagar.Text), 2)
                            Resta = 0
                        Else
                            ACUenta2 = FormatNumber(MyMonto, 2)
                            Resta = FormatNumber(CDbl(txtPagar.Text) - MyMonto, 2)
                        End If

                        If Resta = 0 Then
                            MyStatus = "PAGADO"
                        Else
                            MyStatus = "RESTA"
                        End If

                        IVA_Vent = FormatNumber(CDbl(txtPagar.Text) - TotalIVAPrint, 2)
                        SubTotal = FormatNumber(TotalIVAPrint, 2)
                        Total_Ve = FormatNumber(CDbl(txtPagar.Text), 2)
                        Descuento = FormatNumber(txtdescuento2.Text, 2)
                        MontoSDesc = FormatNumber(CDbl(txtPagar.Text) + Descuento, 2)

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Entrega,Comentario,StatusE,FolMonedero,CodFactura,IP,Formato) values(" & IdCliente & ",'" & txtcliente.Text & "',''," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACUenta2 & "," & Resta & ",'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','','" & MyStatus & "','',''," & MontoSDesc & ",'','0','',0,'','" & CodCadena & "','" & dameIP2() & "','" & cboimpresion.Text & "')"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()

                End Select

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select MAX(Folio) from Ventas where IP='" & dameIP2() & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        folio = rd2(0).ToString()
                    End If
                End If
                rd2.Close()

                cnn2.Close()

                cnn1.Close() : cnn1.Open()
                'Inserta en [AbonoI]
                Dim MySaldo As Double = 0
                If txtcliente.Text <> "MOSTRADOR" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from Abono where Id=(select MAX(Id) from Abono where IdCliente=" & IdCliente & ")"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + CDbl(txtPagar.Text), 2)
                        End If
                    Else
                        MySaldo = FormatNumber(txtPagar.Text, 2)
                    End If
                    rd1.Close()

                    Resta = FormatNumber(txtPagar.Text, 2)

                    If CDbl(txtPagar.Text) > 0 And CDbl(txtFavor.Text) > 0 And CDbl(txtPagar.Text) = CDbl(txtPagar.Text) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & folio & "," & IdCliente & ",'" & txtcliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','" & lblusuario.Text & "'," & Resta & ",'')"
                        cmd1.ExecuteNonQuery()
                    Else
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Abono(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & folio & "," & IdCliente & ",'" & txtcliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','" & lblusuario.Text & "',0,'')"
                        cmd1.ExecuteNonQuery()
                    End If

                End If

                'ACuenta = FormatNumber(CDbl(txtefectivo.Text) - CDbl(txtCambio.Text) + CDbl(txtMontoP.Text), 2)
                ACuenta = "0.00"

                If ACuenta > 0 Then
                End If
                cnn1.Close()

                cnn1.Close() : cnn1.Open()

                For R As Integer = 0 To grdCaptura.Rows.Count - 1

                    Dim mycode As String = grdCaptura.Rows(R).Cells(0).Value.ToString
                    Dim mydesc As String = grdCaptura.Rows(R).Cells(1).Value.ToString
                    Dim myunid As String = grdCaptura.Rows(R).Cells(2).Value.ToString
                    Dim mycant As Double = grdCaptura.Rows(R).Cells(3).Value.ToString
                    Dim myprecio As Double = grdCaptura.Rows(R).Cells(4).Value.ToString
                    Dim mytotal As Double = FormatNumber(mycant * myprecio, 2)

                    Dim ieps As Double = grdCaptura.Rows(R).Cells(7).Value.ToString
                    Dim tasaieps As Double = grdCaptura.Rows(R).Cells(8).Value.ToString
                    Dim monedero As Double = grdCaptura(11, R).Value

                    Dim MyIVA As Double = 0

                    Dim MyMCD As Double = 0
                    Dim MyMulti2 As Double = 0
                    Dim MyMultiplo As Double = 0
                    Dim MyDepto As String = ""
                    Dim MyGrupo As String = ""
                    Dim Kit As Boolean = False
                    Dim Existencia As Double = 0
                    Dim Pre_Comp As Double = 0

                    Dim MyCostVUE As Double = 0
                    Dim MyProm As Double = 0

                    Dim myprecioS As Double = 0
                    Dim mytotalS As Double = 0

                    TotalIEPSPrint = TotalIEPSPrint + CDbl(grdCaptura.Rows(R).Cells(7).Value.ToString)

                    myprecioS = FormatNumber(myprecio / (1 + MyIVA), 6)
                    mytotalS = FormatNumber(mytotal / (1 + MyIVA), 6)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA,Departamento,Grupo,ProvRes,MCD,Multiplo from Productos where Codigo='" & mycode & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MyCostVUE = 0
                            MyProm = 0
                            MyIVA = rd1(0).ToString
                            MyDepto = rd1(1).ToString
                            MyGrupo = rd1(2).ToString
                            Kit = rd1(3).ToString
                            MyMCD = rd1(4).ToString
                            MyMulti2 = rd1(5).ToString
                            If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                                rd1.Close()
                                GoTo Door
                            End If

                        End If
                    End If
                    rd1.Close()



                    Dim existe As Double = 0

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select Existencia,MCD,Departamento,PrecioCompra from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            existe = rd1("Existencia").ToString()
                            MyMultiplo = rd1("MCD").ToString()
                            Existencia = existe / MyMultiplo
                            If rd1("Departamento").ToString() <> "SERVICIOS" Then
                                Pre_Comp = rd1("PrecioCompra").ToString()
                                MyCostVUE = Pre_Comp * (mycant / MyMCD)
                            End If
                        End If
                    End If
                    rd1.Close()
Door:

                    If grdCaptura.Rows(R).Cells(0).Value.ToString() <> "" Then

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Promo_Monedero,Unico,Descuento) values(" & folio & ",'" & mycode & "','" & mydesc & "','" & myunid & "'," & mycant & "," & MyProm & "," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','','0','" & MyDepto & "','" & MyGrupo & "','0',0,0," & ieps & "," & tasaieps & ",'','',0," & monedero & ",0,0)"
                        cmd1.ExecuteNonQuery()

                        Dim necesito As Double = mycant / MyMCD
                        Dim tengo As Double = 0
                        Dim cuanto_cuestan As Double = 0
                        Dim id_peps As Integer = 0
                        Dim utilidad As Double = 0

                        Dim quedan As Double = 0
                        Dim v_costo As Double = 0
                        Dim v_venta As Double = 0

                        If MyDepto <> "SERVICIOS" And Kit = False Then
                            'Cálculos de PePs
                            Do While necesito > 0
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "select Id,Saldo,Costo from PEPS where Id=(select MIN(Id) from PEPS where (Concepto='COMPRA' or Concepto='ENTRADA') and Saldo>0 and Codigo='" & Strings.Left(mycode, 6) & "')"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        id_peps = rd1("Id").ToString()
                                        tengo = rd1("Saldo").ToString()
                                        cuanto_cuestan = rd1("Costo").ToString()
                                    End If
                                Else
                                    'Esto para evitar un bucle cuando no hay una compra previa
                                    rd1.Close()
                                    Exit Do
                                End If
                                rd1.Close()

                                'En todo va a hacer los cálculos de la utilidad
                                If tengo >= necesito Then
                                    quedan = tengo - necesito
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "update PEPS set Saldo=" & quedan & " where Id=" & id_peps
                                    cmd1.ExecuteNonQuery()

                                    v_costo = necesito * cuanto_cuestan
                                    v_venta = necesito * myprecio
                                    utilidad = utilidad + (v_venta - v_costo)

                                    Exit Do
                                ElseIf tengo < necesito Then
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "update PEPS set Saldo=0 where Id=" & id_peps
                                    cmd1.ExecuteNonQuery()

                                    v_costo = tengo * cuanto_cuestan
                                    v_venta = tengo * myprecio
                                    utilidad = (v_venta - v_costo)
                                    necesito = necesito - tengo

                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "insert into PEPS(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MyFolio & "','" & Strings.Left(mycode, 6) & "','" & mydesc & "','" & myunid & "',0," & (tengo * MyMultiplo) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblusuario.Text & "')"
                                    cmd1.ExecuteNonQuery()
                                    utilidad = 0
                                End If
                            Loop
                            'Sí alcanzan las que tengo en el primer registro, entonces guarda y avanza
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into PEPS(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MyFolio & "','" & Strings.Left(mycode, 6) & "','" & mydesc & "','" & myunid & "',0," & (necesito * MyMultiplo) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblusuario.Text & "')"
                            cmd1.ExecuteNonQuery()

                            Dim nueva_existe As Double = 0
                            nueva_existe = Existencia - (mycant / MyMCD)

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "update Productos set CargadoInv=0, Cargado=0, Existencia=" & nueva_existe & " where Codigo='" & Strings.Left(mycode, 6) & "'"
                            cmd1.ExecuteNonQuery()

                            If Len(mycode) = 6 Then
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & Existencia & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MyFolio & "','','','','','')"
                                cmd1.ExecuteNonQuery()
                            Else
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & existe & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MyFolio & "','','','','','')"
                                cmd1.ExecuteNonQuery()
                            End If
                        End If

                        utilidad = 0
                        v_venta = 0
                        v_costo = 0
                        necesito = 0
                        tengo = 0
                    End If

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE tallerd SET Status='Equipo reparado' WHERE Id=" & txtOrden.Text & " AND Cliente='" & txtcliente.Text & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                    If grdCaptura.Rows(R).Cells(0).Value.ToString = "" And grdCaptura.Rows(R).Cells(1).Value.ToString <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update VentasDetalle set CostVR='" & grdCaptura.Rows(R).Cells(1).Value.ToString & "' where CostVR='' and Codigo='" & mycode & "' and Folio=" & MyFolio
                        cmd1.ExecuteNonQuery()
                    End If

                Next
                cnn1.Close()
            Else
                MsgBox("Debe de asignar las refacciones al dispositivo", vbInformation + vbOKOnly, titulotaller)
                Exit Sub
            End If

            '--------------------------------------------------------------------------------------------------------------------------
            Dim pide As String = "", contra As String = txtcontra.Text, usu As String = lblusuario.Text

            Dim Imprime As Integer = 0
            Dim Pasa_Print As Integer = 0
            Dim TPrint As String = ""
            Dim Imprime_En As String = ""
            Dim Impresora As String = ""
            Dim Tamaño As String = ""

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NoPrint from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Imprime = rd1(0).ToString
                End If
            End If
            rd1.Close()

            If Imprime = 1 Then
                If MsgBox("¿Deseas imprimir nota de venta?", vbInformation + vbOKCancel, titulotaller) = vbOK Then
                    Pasa_Print = 1
                Else
                    Pasa_Print = 0
                End If
            Else
                Pasa_Print = 1
            End If

            If Pasa_Print = 1 Then

                TPrint = cboimpresion.Text

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='TamImpre'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Tamaño = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Impresora = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                If TPrint = "TICKET" Then
                    If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, titulotaller) : Exit Sub
                    If Tamaño = "80" Then
                        PVenta80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        PVenta80.Print()
                    End If
                    If Tamaño = "58" Then
                        PVenta58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        PVenta58.Print()
                    End If
                End If

            End If
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='TomaContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    pide = rd1(0).ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

            btnLimpiar.PerformClick()
            If pide = "1" Then
                lblusuario.Text = usu
                txtcontra.Text = contra
            End If
            cboDescripcion.Focus().Equals(True)
            folio = 0

            btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtcontra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontra.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Alias FROM Usuarios WHERE Clave='" & txtcontra.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idempleado = rd1(0).ToString
                    lblusuario.Text = rd1(1).ToString

                    Button2.Focus.Equals(True)
                End If
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub

    Private Sub btnCoti_Click(sender As Object, e As EventArgs) Handles btnCoti.Click

        Try

            If grdCaptura.Rows.Count > 0 Then

                If cboimpresion.Text = "" Then MsgBox("Debe seleccionar el tipo de impresion", vbInformation + vbOKOnly, titulotaller) : cboimpresion.Focus.Equals(True) : Exit Sub

                If cboSerie.Text = "" Then MsgBox("Debe de seleccionar una serie de un dispositivo") : cboSerie.Focus.Equals(True) : Exit Sub

                Dim MySubtotal As Double = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Id FROM clientes WHERE Nombre='" & txtcliente.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        idcliente = rd1(0).ToString
                    End If
                Else
                    idcliente = 0
                End If
                rd1.Close()

                'Permiso para realizar cotizaciones
                Dim per_venta As Boolean = False

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Vent_Coti FROM  permisos WHERE IdEmpleado=" & idempleado
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        per_venta = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                If Not (per_venta) Then
                    MsgBox("No cuentas con permiso para realizar cotizaciones.", vbInformation + vbOKOnly, titulotaller)
                    Exit Sub
                End If

                For i As Integer = 0 To grdCaptura.Rows.Count - 1
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select IVA from Productos where Codigo='" & grdCaptura.Rows(i).Cells(0).Value.ToString() & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySubtotal = MySubtotal + (CDbl(grdCaptura.Rows(i).Cells(5).Value.ToString) / (1 + CDbl(rd1(0).ToString)))
                        End If
                    End If
                    rd1.Close()
                Next


                If MsgBox("¿Deseas guardar los datos de esta cotización?", vbInformation + vbOKCancel, titulotaller) = vbCancel Then cnn1.Close() : Exit Sub

                Dim SubTotal As Double = 0
                Dim IVA_Vent As Double = 0
                Dim Total_Ve As Double = 0

                IVA_Vent = CDbl(txtPagar.Text) - MySubtotal
                SubTotal = MySubtotal
                Total_Ve = txtPagar.Text
                folio = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO CotPed(IdCliente,Cliente,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,Fecha,Hora,Status,Tipo,Comentario,IP) VALUES(" & idcliente & ",'" & txtcliente.Text & "'," & SubTotal & "," & IVA_Vent & "," & Total_Ve & ",0,0,'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','COTIZACION','COTIZACION','','" & dameIP2() & "')"
                cmd1.ExecuteNonQuery()

                Do Until folio <> 0
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT MAX(Folio) FROM cotped WHERE Tipo='COTIZACION' AND IP='" & dameIP2() & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            folio = rd1(0).ToString
                        End If
                    Else
                        folio = 1
                    End If
                    rd1.Close()
                Loop
                cnn1.Close()

                cnn1.Close() : cnn1.Open()

                For sasuke As Integer = 0 To grdCaptura.Rows.Count - 1

                    Dim MyIVA As Double = 0
                    Dim MyMCD As Double = 0
                    Dim MyDepto As String = ""
                    Dim MyGrupo As String = ""
                    Dim myprecioS As Double = 0
                    Dim mytotalS As Double = 0
                    Dim Pre_Comp As Double = 0

                    Dim MyCostVUE As Double = 0
                    Dim MyProm As Double = 0

                    Dim codigo As String = grdCaptura.Rows(sasuke).Cells(0).Value.ToString
                    Dim nombre As String = grdCaptura.Rows(sasuke).Cells(1).Value.ToString
                    Dim unidad As String = grdCaptura.Rows(sasuke).Cells(2).Value.ToString
                    Dim cantidad As Double = grdCaptura.Rows(sasuke).Cells(3).Value.ToString
                    Dim precio As Double = grdCaptura.Rows(sasuke).Cells(4).Value.ToString
                    Dim total As Double = grdCaptura.Rows(sasuke).Cells(5).Value.ToString

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT IVA,Departamento,Grupo,MCD FROM productos WHERE Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MyIVA = rd1(0).ToString
                            MyDepto = rd1("Departamento").ToString
                            MyGrupo = rd1("Grupo").ToString
                            MyMCD = rd1("MCD").ToString
                            If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                                rd1.Close() : cnn1.Close()
                            End If
                        End If
                    End If
                    rd1.Close()

                    myprecioS = FormatNumber(precio / (1 + MyIVA), 6)
                    mytotalS = FormatNumber(total / (1 + MyIVA), 6)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select Departamento,PrecioCompra from Productos where Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If rd1("Departamento").ToString <> "SERVICIOS" Then
                                Pre_Comp = rd1("PrecioCompra").ToString
                                MyCostVUE = Pre_Comp * (cantidad / MyMCD)
                            End If
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO cotpeddet(Folio,Codigo,Nombre,Cantidad,Unidad,CostoV,Precio,Total,PrecioSIVA,TotalSIVA,Fecha,Usuario,Depto,Grupo,CostVR,Tipo) VALUES(" & folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "'," & MyCostVUE & "," & precio & "," & total & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MyDepto & "','" & MyGrupo & "','','COTIZACION')"
                    cmd1.ExecuteNonQuery()

                    If grdCaptura.Rows(sasuke).Cells(0).Value.ToString = "" And grdCaptura.Rows(sasuke).Cells(1).Value.ToString <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                        "update CotPedDet set CostVR='" & grdCaptura.Rows(sasuke).Cells(1).Value.ToString & "' where CostVR='' and Tipo='COTIZACION' and Codigo='" & codigo & "' and Folio=" & MyFolio
                        cmd1.ExecuteNonQuery()
                    End If

                Next
                cnn1.Close()
            Else
                MsgBox("Debe de ingresar piezas", vbInformation + vbOKOnly, titulotaller)
                Exit Sub
            End If
            cnn1.Close()

            '----------------imprimir ticket------------------------

            Dim Imprime As Integer = 0
            Dim Pasa_Print As Integer = 0
            Dim TPrint As String = ""
            Dim Imprime_En As String = ""
            Dim Impresora As String = ""
            Dim Tamaño As String = ""

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NoPrint from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Imprime = rd1(0).ToString
                End If
            End If
            rd1.Close()

            If Imprime = 1 Then
                If MsgBox("¿Deseas imprimir esta cotización?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Pasa_Print = 1
                Else
                    Pasa_Print = 0
                End If
            Else
                Pasa_Print = True
            End If

            TPrint = cboimpresion.Text

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Tamaño = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Impresora = rd1(0).ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If TPrint = "TICKET" Then
                If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
                If Tamaño = "80" Then
                    PCotiza80.PrinterSettings.PrinterName = Impresora
                    PCotiza80.Print()
                End If
                If Tamaño = "58" Then
                    PCotiza58.PrinterSettings.PrinterName = Impresora
                    PCotiza58.Print()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboimpresion_DropDown(sender As Object, e As EventArgs) Handles cboimpresion.DropDown
        cboimpresion.Items.Clear()
        cboimpresion.Items.Add("TICKET")
        'cboimpresion.Items.Add("CARTA")
        'cboimpresion.Items.Add("MEDIA CARTA")
        cboimpresion.Items.Add("PDF - CARTA")
    End Sub

    Private Sub PCotiza80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCotiza80.PrintPage

        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
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

            ' Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O T I Z A C I Ó N", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 285, Y, sf)
            Y += 15

            '[2]. Datos del cliente
            If txtcliente.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(txtcliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(txtcliente.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(txtcliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            If cboSerie.Text <> "" Then
                e.Graphics.DrawString("D I S P O S I T I V O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Serie: " & cboSerie.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("N° Orden: " & txtOrden.Text, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 15

                e.Graphics.DrawString("Marca: " & txtMarca.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("Modelo: " & txtModelo.Text, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 15

                e.Graphics.DrawString("Técnico: " & txtTecnico.Text, fuente_prods, Brushes.Black, 1, Y)
                Y += 15

                If txtfallas.Text <> "" Then
                    e.Graphics.DrawString("Fallas:" & Mid(txtfallas.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtfallas.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtfallas.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtfallas.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtfallas.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 3
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 18
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0
            For miku As Integer = 0 To grdCaptura.Rows.Count - 1
                If grdCaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdCaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdCaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdCaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdCaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdCaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdCaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdCaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descu As Double = grdCaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 13
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3

            e.Graphics.DrawString("----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdCaptura.Rows.Count - 1
                If CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdCaptura.Rows(N).Cells(7).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdCaptura.Rows(N).Cells(7).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(6).Value.ToString) * (CDbl(txtdescuento2.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdCaptura.Rows(N).Cells(7).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(6).Value.ToString) * (CDbl(txtdescuento2.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If

                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If

            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            cnn1.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try


    End Sub

    Private Sub PCotiza58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCotiza58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 6, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 120)
                    Y += 80
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 80
                End If
            Else
                Y = 0
            End If

            ' Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("C O T I Z A C I Ó N", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 15

            '[2]. Datos del cliente
            If txtcliente.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(txtcliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If Mid(txtcliente.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(txtcliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            If cboSerie.Text <> "" Then
                e.Graphics.DrawString("D I S P O S I T I V O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Serie: " & cboSerie.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("N° Orden: " & txtOrden.Text, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 15

                e.Graphics.DrawString("Marca: " & txtMarca.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("Modelo: " & txtModelo.Text, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 15

                e.Graphics.DrawString("Técnico: " & txtTecnico.Text, fuente_prods, Brushes.Black, 1, Y)
                Y += 15

                If txtfallas.Text <> "" Then
                    e.Graphics.DrawString("Fallas:" & Mid(txtfallas.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtfallas.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtfallas.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtfallas.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtfallas.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 3
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 18
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 12
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0
            For miku As Integer = 0 To grdCaptura.Rows.Count - 1
                If grdCaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdCaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdCaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdCaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdCaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdCaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdCaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdCaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descu As Double = grdCaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)

                e.Graphics.DrawString(Mid(nombre, 1, 25), fuente_prods, Brushes.Black, 33, Y)
                Y += 12
                If Mid(nombre, 26, 50) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 26, 50), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                If Mid(nombre, 51, 76) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 51, 76), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3

            e.Graphics.DrawString("----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdCaptura.Rows.Count - 1
                If CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdCaptura.Rows(N).Cells(7).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdCaptura.Rows(N).Cells(7).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(6).Value.ToString) * (CDbl(txtdescuento2.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdCaptura.Rows(N).Cells(7).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(6).Value.ToString) * (CDbl(txtdescuento2.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If

                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento2.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento2.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 13.5
                End If
            End If

            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            cnn1.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnstatus_Click(sender As Object, e As EventArgs) Handles btnstatus.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE tallerd Set Status='En reparacion' WHERE Id=" & txtOrden.Text & " AND Status<>'Equipo reparado'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Foliov()
        Timer1.Start()
    End Sub

    Public Sub Foliov()
        Try
            If cnn9.State = 1 Then cnn9.Close()
            cnn9.Open()
            cmd9 = cnn9.CreateCommand
            cmd9.CommandText = "select MAX(Folio) from Ventas"
            rd9 = cmd9.ExecuteReader
            If rd9.HasRows Then
                If rd9.Read Then
                    lblfolio.Text = CDbl(IIf(rd9(0).ToString = "", "0", rd9(0).ToString)) + 1
                Else
                    lblfolio.Text = "1"
                End If
            Else
                lblfolio.Text = "1"
            End If
            rd9.Close() : cnn9.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn9.Close()
        End Try
    End Sub

    Private Sub PVenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVenta80.PrintPage

        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
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

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()
            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("N O T A  D E  V E N T A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If txtcliente.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(txtcliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(txtcliente.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(txtcliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13
                End If
            End If

            If cboSerie.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("D I S P O S I T I V O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Serie: " & cboSerie.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("N° Orden: " & txtOrden.Text, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13

                e.Graphics.DrawString("Marca: " & txtMarca.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("Modelo: " & txtModelo.Text, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13
                e.Graphics.DrawString("Técnico: " & txtTecnico.Text, fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If txtfallas.Text <> "" Then
                    e.Graphics.DrawString("Fallas: " & txtfallas.Text, fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If

                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdCaptura.Rows.Count - 1
                If grdCaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdCaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdCaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If

                Dim codigo As String = grdCaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdCaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdCaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdCaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdCaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)


                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 100, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdCaptura.Rows.Count - 1
                If CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(10).Value.ToString)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(10).Value.ToString)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtPagar.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If
            Y += 2

            e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 142.5, Y, sc)
            Y += 13.5
            If Mid(Pie, 36, 70) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If
            If Mid(Pie, 71, 105) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 142.5, Y, sc)
                Y += 13.5
            End If


            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try

    End Sub

    Private Sub PVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVenta58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 120)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd1.Close()
            cnn1.Close()
            '[1]. Datos de la venta
            e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("N O T A  D E  V E N T A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 12
            e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 13
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 10

            '[2]. Datos del cliente
            If txtcliente.Text <> "" Then
                e.Graphics.DrawString("-----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("-----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12

                e.Graphics.DrawString("Nombre: " & Mid(txtcliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(txtcliente.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(txtcliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13
                End If
            End If

            If cboSerie.Text <> "" Then
                e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("D I S P O S I T I V O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14

                e.Graphics.DrawString("Serie: " & cboSerie.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("N° Orden: " & txtOrden.Text, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13

                e.Graphics.DrawString("Marca: " & txtMarca.Text, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("Modelo: " & txtModelo.Text, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13
                e.Graphics.DrawString("Técnico: " & txtTecnico.Text, fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If txtfallas.Text <> "" Then
                    e.Graphics.DrawString("Fallas: " & txtfallas.Text, fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If

                e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y)
            Y += 6
            e.Graphics.DrawString("-----------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdCaptura.Rows.Count - 1
                If grdCaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdCaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdCaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If

                Dim codigo As String = grdCaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdCaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdCaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdCaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdCaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)


                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)

                e.Graphics.DrawString(Mid(nombre, 1, 25), fuente_prods, Brushes.Black, 33, Y)
                Y += 12
                If Mid(nombre, 26, 50) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 26, 50), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                If Mid(nombre, 51, 76) <> "" Then
                    e.Graphics.DrawString(Mid(nombre, 51, 76), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If

                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 50, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
            Next
            Y -= 3
            e.Graphics.DrawString("----------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("----------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdCaptura.Rows.Count - 1
                If CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdCaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(10).Value.ToString)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) - (CDbl(grdCaptura.Rows(N).Cells(10).Value.ToString)) * CDbl(rd1(0).ToString))
                            End If
                            If CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString) <> 0 Then
                                TotalIEPS = TotalIEPS + CDbl(grdCaptura.Rows(N).Cells(11).Value.ToString)
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString(convLetras(txtPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 15

            If CDbl(txtPagar.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            Dim IVA As Double = CDbl(txtPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If IVA > 0 And IVA <> CDbl(txtPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(IVA, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                        Y += 12
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
            End If
            Y += 2

            e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 90, Y, sc)
            Y += 12
            If Mid(Pie, 36, 70) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 12
            End If
            If Mid(Pie, 71, 105) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 12
            End If


            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("¿Desea salir?", vbInformation + vbYesNo, titulotaller) = vbYes Then
            Me.Close()
            frmTallerT.Show()
        End If
    End Sub

    Private Sub cboimpresion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboimpresion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button2.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        Try
            cboDescripcion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDescripcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress

        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim mcd As Double = 0
            Dim Minimo As Double = 0
            Dim ticambio As Double = 0
            Dim PreLst As Double = 0
            Dim PreEsp As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,Nombre,UVenta,Multiplo,Existencia FROM productos WHERE Nombre='" & cboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboCodigo.Text = rd1("Codigo").ToString
                    cboDescripcion.Text = rd1("Nombre").ToString()
                    txtUnidad.Text = rd1("UVenta").ToString
                    mcd = rd1("Multiplo").ToString
                    txtexistencia.Text = CDbl(IIf(rd1("Existencia").ToString = "", "0", rd1("Existencia").ToString)) * mcd

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT tipo_cambio FROM tb_moneda,Productos WHERE Codigo='" & cboCodigo.Text & "' AND Productos.id_tbMoneda=tb_moneda.id"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            ticambio = rd2(0).ToString
                            If ticambio = 0 Then ticambio = 1
                        End If
                    Else
                        ticambio = 1
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT PrecioVentaIVA, PreEsp FROM Productos WHERE Codigo='" & cboCodigo.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            PreLst = rd2(0).ToString
                            PreEsp = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    txtPrecio.Text = FormatNumber(PreLst * ticambio, 2)
                    txtPrecio.Tag = FormatNumber(PreLst * ticambio, 2)

                    cboCodigo.Focus().Equals(True)
                End If
            End If
            cnn2.Close()
            rd1.Close()
            cnn1.Close()

        End If

    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter And (cboCodigo.Text <> "" Or cboDescripcion.Text <> "") Then

            Dim MCD As Double = 0
            Dim Multiplo As Double = 0
            Dim Minimo As Double = 0
            Dim TiCambio As Double = 0
            Dim PreLst As Double = 0, PreEsp As Double = 0

            If cboCodigo.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Departamento,Nombre,PrecioVentaIVA,UVenta,Codigo,MCD,Multiplo,Min,PreEsp,Existencia FROM productos WHERE Codigo='" & cboCodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                                cboDescripcion.Text = rd1("Nombre").ToString
                                txtPrecio.Text = rd1("PrecioVentaIVA").ToString
                                txtPrecio.Tag = rd1("PrecioVentaIVA").ToString
                                txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)

                                txtUnidad.Text = rd1("UVenta").ToString

                                txtCantidad.Focus().Equals(True)
                                rd1.Close()
                                cnn1.Close()
                                Exit Sub
                            End If

                            txtUnidad.Text = rd1("UVenta").ToString
                            cboCodigo.Text = rd1("Codigo").ToString
                            cboDescripcion.Text = rd1("Nombre").ToString
                            MCD = rd1("MCD").ToString
                            Multiplo = rd1("Multiplo").ToString
                            Minimo = rd1("Min").ToString
                            PreLst = rd1("PrecioVentaIVA").ToString
                            PreEsp = rd1("PreEsp").ToString
                            txtexistencia.Text = CDbl(IIf(rd1("Existencia").ToString = "", "0", rd1("Existencia").ToString)) * MCD

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT tipo_cambio FROM tb_moneda,Productos WHERE Codigo='" & cboCodigo.Text & "' AND Productos.id_tbMoneda=tb_moneda.id"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    TiCambio = rd2(0).ToString
                                    If TiCambio = 0 Then TiCambio = 1
                                End If
                            Else
                                TiCambio = 1
                            End If
                            rd2.Close()

                            txtPrecio.Text = FormatNumber(PreLst * TiCambio, 2)
                            txtPrecio.Tag = FormatNumber(PreLst * TiCambio, 2)


                        End If
                    Else
                        MsgBox("El código no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        cboCodigo.Focus().Equals(True)
                        Exit Sub
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            txtCantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As EventArgs) Handles cboCodigo.DropDown
        Try
            cboCodigo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM Productos WHERE Codigo<>'' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodigo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not IsNumeric(txtCantidad.Text) Then txtCantidad.Text = ""
        If txtCantidad.Text = "" Then Exit Sub
        If AscW(e.KeyChar) = Keys.Enter And cboDescripcion.Text = "" Then cboDescripcion.Focus().Equals(True)
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim Edita As Boolean = False
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Vent_EPrec from Permisos where IdEmpleado=" & id_usu_log
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Edita = rd1("Vent_EPrec").ToString
                    End If
                End If
                rd1.Close()

                If Edita = False Then

                    If cboCodigo.Text = "" Then cboDescripcion.Focus().Equals(True) : Exit Sub


                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "SELECT PreMin FROM Productos WHERE Codigo='" & cboCodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(txtPrecio.Text) < CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) Then
                                MsgBox("El precio de venta mínimo para el producto es de " & FormatNumber(CDbl(rd1(0).ToString), 2) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtPrecio.SelectionStart = 0 : txtPrecio.SelectionLength = Len(txtPrecio.Text) : Exit Sub
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                    rd1.Close()

                    If CDbl(IIf(txtCantidad.Text = "", "0", txtCantidad.Text)) = 0 Or txtCantidad.Text = "" Then cboCodigo.Focus().Equals(True) : Exit Sub
                    If CDbl(IIf(txtPrecio.Text = "", "0", txtPrecio.Text)) = 0 Or txtPrecio.Text = "" Then cboCodigo.Focus().Equals(True) : Exit Sub

                    txtTotal.Text = CDbl(txtCantidad.Text) * CDbl(txtPrecio.Text)
                    txtTotal.Text = FormatNumber(txtTotal.Text, 2)
                    txtPrecio.Focus().Equals(True)
                Else

                    txtPrecio.Focus().Equals(True)
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try


        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        Dim temp As Double = 0
        Dim TiCambio As Double = 0
        Dim H_Actual As String = Format(Date.Now, "HH:mm")
        If txtCantidad.Text = "" Or txtCantidad.Text = "." Then Exit Sub

        Try
            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "select tipo_cambio from tb_moneda,Productos where Codigo='" & cboCodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    TiCambio = rd4(0).ToString
                    If TiCambio = 0 Then TiCambio = 1
                End If
            Else
                TiCambio = 1
            End If
            rd4.Close()

            Dim ATemp1, ATemp2, ATemp3, ATemp4 As Double

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                    "SELECT PrecioVentaIVA,CantLst1,CantLst2,CantEsp1,CantEsp2,PreEsp,CantMM1,CantMM2,PreMM,CantMay1,CantMay2 FROM Productos WHERE Codigo='" & cboCodigo.Text & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then

                    txtPrecio.Text = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString)) * TiCambio
                    txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
                    txtPrecio.Tag = FormatNumber(txtPrecio.Text, 2)

                    If Not IsDBNull(rd4("CantLst1").ToString) And Not IsDBNull(rd4("CantLst2").ToString) Then
                        If CDbl(txtCantidad.Text) >= CDbl(rd4("CantLst1").ToString) And CDbl(txtCantidad.Text) <= CDbl(rd4("CantLst2").ToString) Then
                            txtPrecio.Text = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString))
                            txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
                            txtPrecio.Tag = FormatNumber(txtPrecio.Text, 2)
                            temp = 1
                        End If
                    End If

                    If Not IsDBNull(rd4("CantEsp1").ToString) And Not IsDBNull(rd4("CantEsp2").ToString) Then
                        ATemp1 = rd4("CantEsp1").ToString
                        If CDbl(txtCantidad.Text) >= CDbl(rd4("CantEsp1").ToString) And CDbl(txtCantidad.Text) <= CDbl(rd4("CantEsp2").ToString) Then
                            txtPrecio.Text = CDbl(IIf(rd4("PreEsp").ToString = "", "0", rd4("PreEsp").ToString))
                            txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
                            txtPrecio.Tag = FormatNumber(txtPrecio.Text, 2)
                            temp = 1
                        End If
                    End If

                    If Not IsDBNull(rd4("CantMM1").ToString) And Not IsDBNull(rd4("CantMM2").ToString) Then
                        ATemp2 = rd4("CantMM1").ToString
                        If CDbl(txtCantidad.Text) >= CDbl(rd4("CantMM1").ToString) And CDbl(txtCantidad.Text) <= CDbl(rd4("CantMM2").ToString) Then
                            txtPrecio.Text = CDbl(IIf(rd4("PreMM").ToString = "", "0", rd4("PreMM").ToString))
                            txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
                            txtPrecio.Tag = FormatNumber(txtPrecio.Text, 2)
                            temp = 1
                        End If
                    End If

                    If Not IsDBNull(rd4("CantMay1").ToString) And Not IsDBNull(rd4("CantMay2").ToString) Then
                        ATemp3 = rd4("CantMay1").ToString
                        If CDbl(txtCantidad.Text) >= CDbl(rd4("CantMay1").ToString) And CDbl(txtCantidad.Text) <= CDbl(rd4("CantMay2").ToString) Then
                            txtPrecio.Text = CDbl(IIf(rd4("PreMay").ToString = "", "0", rd4("PreMay").ToString))
                            txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
                            txtPrecio.Tag = FormatNumber(txtPrecio.Text, 2)
                            temp = 1
                        End If
                    End If

                    If Not IsDBNull(rd4("CantMin1").ToString) And Not IsDBNull(rd4("CantMin2").ToString) Then
                        ATemp4 = rd4("CantMin1").ToString
                        If CDbl(txtCantidad.Text) >= CDbl(rd4("CantMin1").ToString) And CDbl(txtCantidad.Text) <= CDbl(rd4("CantMin2").ToString) Then
                            txtPrecio.Text = CDbl(IIf(rd4("PreMin").ToString = "", "0", rd4("PreMin").ToString))
                            txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
                            txtPrecio.Tag = FormatNumber(txtPrecio.Text, 2)
                            temp = 1
                        End If
                    End If

                    If ATemp1 <> 0 Or ATemp2 <> 0 Or ATemp3 <> 0 Or ATemp4 <> 0 Then
                        If temp = 0 Then
                            cnn5.Close() : cnn5.Open()
                            cmd5 = cnn5.CreateCommand
                            cmd5.CommandText =
                                "select * from Productos where Codigo='" & cboCodigo.Text & "'"
                            rd5 = cmd5.ExecuteReader
                            If rd5.HasRows Then
                                If rd5.Read Then
                                    txtPrecio.Text = CDbl(IIf(rd5("PrecioVentaIVA").ToString = "", "0", rd5("PrecioVentaIVA").ToString))
                                    txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
                                    txtPrecio.Tag = FormatNumber(txtPrecio.Text, 2)
                                End If
                            Else
                                MsgBox("El producto no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            End If
                            rd5.Close()
                            cnn5.Close()
                            rd4.Close() : cnn4.Close()
                            Exit Sub
                        End If
                    End If

                End If
            End If
            rd4.Close()
            cnn4.Close()
            txtPrecio.ReadOnly = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
        If txtPrecio.Text = "" Then txtPrecio.Text = "0.00"
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim chec As Boolean = False
        Dim editap As Boolean = False
        If Not IsNumeric(txtPrecio.Text) Then txtPrecio.Text = ""
        If cboCodigo.Text = "" Then MsgBox("Necesitas seleccionar un producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDescripcion.Focus().Equals(True) : Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select VSE from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    chec = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "SELECT Vent_EPrec FROM Permisos WHERE IdEmpleado=" & id_usu_log
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    editap = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "SELECT * FROM Productos WHERE Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If CStr(rd1(0).ToString) = "SERVICIOS" Then
                        If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                        If AscW(e.KeyChar) = Keys.Enter Then
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                    "select *  from LoteCaducidad where Codigo='" & cboCodigo.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                txtTotal.Focus().Equals(True)
                            Else
                                rd1.Close() : cnn1.Close()
                                rd2.Close() : cnn2.Close()
                                txtTotal_KeyPress(txtTotal, New KeyPressEventArgs(ChrW(Keys.Enter)))
                            End If
                            rd2.Close() : cnn2.Close()
                        End If
                    Else
                        If chec = True Then
                            Dim existencia As Double = rd1("Existencia").ToString
                            Dim TExiste As Double = existencia - CDbl(txtCantidad.Text)
                            If TExiste < 0 Then

                                If Me.Text = "Ventas(1)" Then
                                    MsgBox("No puedes vender sin existencia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                    txtCantidad.Focus().Equals(True)
                                    rd1.Close() : cnn1.Close()
                                    Exit Sub
                                Else
                                    If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                    If AscW(e.KeyChar) = Keys.Enter Then
                                        cnn2.Close() : cnn2.Open()
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText =
                                "select *  from LoteCaducidad where Codigo='" & cboCodigo.Text & "'"
                                        rd2 = cmd2.ExecuteReader
                                        If rd2.HasRows Then
                                            txtTotal.Focus().Equals(True)
                                        Else
                                            rd1.Close() : cnn1.Close()
                                            rd2.Close() : cnn2.Close()
                                            txtTotal_KeyPress(txtTotal, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                        End If
                                        rd2.Close() : cnn2.Close()
                                    End If
                                End If
                            Else
                                If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                If AscW(e.KeyChar) = Keys.Enter Then
                                    cnn2.Close() : cnn2.Open()
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                "select *  from LoteCaducidad where Codigo='" & cboCodigo.Text & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        txtTotal.Focus().Equals(True)
                                    Else
                                        rd1.Close() : cnn1.Close()
                                        rd2.Close() : cnn2.Close()
                                        txtTotal_KeyPress(txtTotal, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                    End If
                                    rd2.Close() : cnn2.Close()
                                End If
                            End If

                        Else
                            If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                            If AscW(e.KeyChar) = Keys.Enter Then

                                rd1.Close() : cnn1.Close()
                                rd2.Close() : cnn2.Close()
                                txtTotal_KeyPress(txtTotal, New KeyPressEventArgs(ChrW(Keys.Enter)))
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If txtPrecio.Text = "" Then
                txtPrecio.Text = "0.00"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotal.KeyPress
        Dim chec As Boolean = False
        Dim renta As Boolean = False

        If AscW(e.KeyChar) = Keys.Enter Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select VSE from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    chec = rd1(0).ToString()
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT * FROM Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                    ElseIf CStr(rd1("Grupo").ToString()) = "RENTAS" Then
                        renta = True
                    Else
                        If chec = True Then

                        End If
                    End If
                End If
            End If
            rd1.Close()

            Dim dia As Integer = 0
            Dim decu As String = ""
            Dim pre_ini As Double = txtPrecio.Text, pre_fini As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT Dia,Descu FROM Productos WHERE Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    dia = rd1(0).ToString
                    decu = rd1(1).ToString
                End If
            End If
            rd1.Close()

            If dia = 0 Then
            Else
                'If dia = CInt(txtdia.Text) Then
                '    Dim descu As Double = CDbl(decu) / 100
                '    Dim p1 As Double = CDbl(pre_ini) * descu
                '    pre_fini = pre_ini - p1

                '    txtPrecio.Text = FormatNumber(pre_fini, 2)
                'End If
            End If

            If cboCodigo.Text = "" Then cboDescripcion.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtCantidad.Text = "", "0", txtCantidad.Text)) = 0 Or txtCantidad.Text = "" Then cboCodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtPrecio.Text = "", "0", txtPrecio.Text)) = 0 Or txtPrecio.Text = "" Then cboCodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select PreMin from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            End If
            rd1.Close()
            cnn1.Close()

            ' txtefectivo.Text = "0.00"
            ' txtCambio.Text = "0.00"
            txtTotal.Text = CDbl(txtCantidad.Text) * CDbl(txtPrecio.Text)
            txtTotal.Text = FormatNumber(txtTotal.Text, 2)
            Call UpGrid()

            Dim VarSumXD As Double = 0
            For w = 0 To grdCaptura.Rows.Count - 1
                If grdCaptura.Rows(w).Cells(5).Value.ToString = "" Then
                Else
                    VarSumXD = VarSumXD + CDbl(grdCaptura.Rows(w).Cells(5).Value.ToString)
                End If
                txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            Next

            cboCodigo.Text = ""
            cboCodigo.Items.Clear()
            cboDescripcion.Text = ""
            cboDescripcion.Items.Clear()
            txtUnidad.Text = ""
            txtCantidad.Text = ""
            txtPrecio.Text = ""
            txtTotal.Text = ""
            txtexistencia.Text = ""

            txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
            txtPagar.Text = FormatNumber(txtPagar.Text, 2)

            cboDescripcion.Focus().Equals(True)

        End If
    End Sub
End Class