
Imports System.IO
Public Class frmTallerR

    Dim var_placa As String = ""
    Dim var_vehiculo As String = ""
    Dim IDCLIENTE As Integer = 0
    Dim FOLIO As Integer = 0
    Friend WithEvents btnVehiculo As System.Windows.Forms.Button
    Private Sub frmTallerR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TVehiculo.Start()
        TVenta.Start()
        TFecha.Start()
        cboimpresion.Text = "TICKET"
    End Sub

    Private Sub TVehiculo_Tick(sender As Object, e As EventArgs) Handles TVehiculo.Tick
        TVehiculo.Stop()
        vehiculos()
        TVehiculo.Start()
    End Sub

    Public Sub vehiculos()
        Dim vehi As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT IdVehiculo,Descripcion,Placa FROM Vehiculo WHERE StatusT=1 ORDER BY Descripcion"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim vehiculos As String = rd1("Descripcion").ToString
                    Dim placa As String = rd1("Placa").ToString
                    btnVehiculo = New Button
                    btnVehiculo.Text = vehiculos
                    btnVehiculo.Tag = placa
                    btnVehiculo.Name = "btnVehiculo(" & vehiculos & ")"
                    btnVehiculo.Height = 80
                    btnVehiculo.Width = 80

                    btnVehiculo.Top = (vehi) * (btnVehiculo.Height + 1)
                    btnVehiculo.FlatStyle = FlatStyle.Flat
                    btnVehiculo.BackColor = Color.FromArgb(255, 255, 255)
                    btnVehiculo.FlatAppearance.BorderSize = 0.5

                    Dim pn As Integer = 0

                    cnn4.Close() : cnn4.Open()
                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "select Vehiculo from comandasveh where Vehiculo='" & btnVehiculo.Text & "'"
                    rd4 = cmd4.ExecuteReader
                    If rd4.HasRows Then
                        If rd4.Read Then
                            pn = 1
                            If pn <> 0 Then
                                btnVehiculo.BackColor = Color.FromArgb(45, 170, 220)
                                My.Application.DoEvents()
                            End If
                        End If
                    End If
                    rd4.Close()
                    cnn4.Close()

                    pVehiculos.Controls.Add(btnVehiculo)
                    AddHandler btnVehiculo.Click, AddressOf btnVehiculo_Click
                    vehi = CDec(vehi) + 1
                End If
            Loop
            rd1.Close()
            cnn1.Close()
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub btnVehiculo_Click(sender As Object, e As EventArgs)

        Dim btnVehiculo As Button = CType(sender, Button)
        Dim id As Integer = 0
        var_vehiculo = btnVehiculo.Text
        var_placa = btnVehiculo.Tag

        grdProductos.Rows.Clear()
        lblTotalPagar.Text = "0.00"

        If btnVehiculo.BackColor = Color.FromArgb(255, 255, 255) Then

            btnpagar.Enabled = False

            Dim descripcion As String = ""
            Dim marca As String = ""
            Dim modelo As String = ""
            Dim cliente As String = ""
            Dim observaciones As String = ""

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Descripcion,Marca,Modelo,IdVehiculo,Cliente,Observaciones FROM Vehiculo WHERE Descripcion='" & var_vehiculo & "' and StatusT=1"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    descripcion = rd2(0).ToString
                    marca = rd2(1).ToString
                    modelo = rd2(2).ToString
                    id = rd2(3).ToString
                    cliente = rd2(4).ToString
                    observaciones = rd2(5).ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()

            frmAsignacionRef.txtVeh.Text = descripcion
            frmAsignacionRef.txtCliente.Text = cliente
            frmAsignacionRef.lblObservaciones.Text = observaciones
            frmAsignacionRef.marcaveh = marca
            frmAsignacionRef.placa = var_placa
            frmAsignacionRef.idvehiculo = id
            frmAsignacionRef.Show()

            'frmAsignaRefaccion.cbovehiculo.Text = descripcion
            'frmAsignaRefaccion.marcaveh = marca
            'frmAsignaRefaccion.idvehiculo = id
            'frmAsignaRefaccion.txtCliente.Text = cliente
            'frmAsignaRefaccion.placa = var_placa
            'frmAsignaRefaccion.Show()

        End If

        If btnVehiculo.BackColor = Color.FromArgb(45, 170, 220) Then

            btnpagar.Enabled = True


            txtvehiculo.Text = var_vehiculo
            txtplaca.Text = var_placa

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM comandasveh WHERE Vehiculo='" & var_vehiculo & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    Dim total As Double = CDbl(1 * rd2("Precio").ToString)
                    Dim idveh As Integer = rd2("IdVehiculo").ToString

                    grdProductos.Rows.Add(rd2("Codigo").ToString,
                                          rd2("Nombre").ToString,
                                          rd2("Cantidad").ToString,
                                          rd2("Precio").ToString,
                                          total
)
                    lblcliente.Text = rd2("Cliente").ToString

                    lblTotalPagar.Text = lblTotalPagar.Text + CDbl(total)
                    btnpagar.Enabled = True
                    lblidvehiculo.Text = idveh
                End If
            Loop
            rd2.Close()
            cnn2.Close()

        End If

    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        grdProductos.Rows.Clear()
        lblTotalPagar.Text = "0.00"
        lblCantidadLetra.Text = ""
        txtvehiculo.Text = ""
        lblcliente.Text = ""
        lblidvehiculo.Text = ""
        cboimpresion.Text = "TICKET"
        txtMaximo.Text = "0.00"
        txtFavor.Text = "0.00"
        txtadeuda.Text = "0.00"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        frmMenuPrincipal.Show()
    End Sub

    Private Sub TVenta_Tick(sender As Object, e As EventArgs) Handles TVenta.Tick
        TVenta.Stop()
        Ventas()
        TVenta.Start()
    End Sub

    Public Sub Ventas()

        cnntimer.Close() : cnntimer.Open()
        cmdtimer = cnntimer.CreateCommand
        cmdtimer.CommandText = "SELECT MAX(Folio) FROM ventas"
        rdtimer = cmdtimer.ExecuteReader
        If rdtimer.HasRows Then
            If rdtimer.Read Then
                lblFolio.Text = CDbl(IIf(rdtimer(0).ToString = "", "0", rdtimer(0).ToString)) + 1
            Else
                lblFolio.Text = "1"
            End If
        Else
            lblFolio.Text = "1"
        End If
        rdtimer.Close()
        cnntimer.Close()

    End Sub

    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick
        Me.Text = "Delsscom® Control Negocios -  Ventas touch" & Strings.Space(40) & Date.Now
        lblfecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
    End Sub

    Private Sub txtclave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtclave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Alias FROM usuarios WHERE Clave='" & txtclave.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblatiende.Text = rd1(0).ToString

                End If
            Else
                MsgBox("El usuario no esta registrado, contacte a su administrador", vbInformation + vbOKOnly, titulorefaccionaria)
                txtclave.Focus.Equals(True)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub

    Private Sub lblTotalPagar_TextChanged(sender As Object, e As EventArgs) Handles lblTotalPagar.TextChanged
        If lblTotalPagar.Text = "" Then Exit Sub
        Dim TotalImporte As Double = lblTotalPagar.Text
        Dim CantidadLetra As String = ""
        If TotalImporte > 0 Then
            btnpagar.Enabled = True
            CantidadLetra = UCase(Letras(TotalImporte))
        Else
            btnpagar.Enabled = False
            CantidadLetra = ""
        End If
        lblCantidadLetra.Text = CantidadLetra
    End Sub

    Private Sub btnpagar_Click(sender As Object, e As EventArgs) Handles btnpagar.Click
        Try
            Dim Cliente As String = ""
            Dim dias_credito As Double = 0
            Dim max_cred As Double = 0

            Dim fecha_pago As String = ""


            If lblcliente.Text = "" Then
                IDCLIENTE = 0
                Cliente = ""
                dias_credito = 0
                fecha_pago = ""
            Else
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Clientes where Nombre='" & lblcliente.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        IDCLIENTE = rd1("Id").ToString
                        Cliente = lblcliente.Text
                        dias_credito = rd1("DiasCred").ToString()
                        fecha_pago = DateAdd(DateInterval.Day, dias_credito, Date.Now)
                    End If
                Else
                    IDCLIENTE = 0
                    Cliente = ""
                    dias_credito = 0
                    fecha_pago = ""
                End If
                rd1.Close() : cnn1.Close()
            End If


            Dim VarUser As String = "", VarIdUsuario As Integer = 0

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0

            If lblatiende.Text = "" Then
                MsgBox("Escribe/Revisa tu contraseña para continuar.", vbInformation + vbOKOnly, titulorefaccionaria)
                cnn1.Close()
                txtclave.Focus().Equals(True) : Exit Sub
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Usuarios WHERE Clave='" & txtclave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        VarUser = rd1("Alias").ToString
                        VarIdUsuario = rd1("IdEmpleado").ToString
                    End If
                Else
                    MsgBox("No se encuentra un usuario registrado bajo esta contraseña.", vbInformation + vbOKOnly, titulorefaccionaria)
                    rd1.Close() : cnn1.Close()
                    txtclave.Focus().Equals(True) : Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            End If

            If grdProductos.Rows.Count > 0 Then
                cnn1.Close() : cnn1.Open()

                For d As Integer = 0 To grdProductos.Rows.Count - 1


                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "SELECT IVA FROM Productos WHERE Codigo='" & CStr(grdProductos.Rows(d).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                            Dim iva As Double = rd1(0).ToString

                            If iva > 0 Then
                                Dim preciosiniva = grdProductos.Rows(d).Cells(3).Value.ToString / CDbl(1 + iva)

                                TotalIVAPrint = preciosiniva
                            End If
                        End If
                    End If
                    rd1.Close()
                Next
                cnn1.Close()
                TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)

                Dim per_venta As Integer = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT * FROM Permisos WHERE IdEmpleado= " & VarIdUsuario
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        per_venta = rd1("Vent_NVen").ToString
                    End If
                End If
                rd1.Close() : cnn1.Close()

                If per_venta = 0 Then
                    MsgBox("No cuentas con permiso para realizar notas de venta.", vbInformation + vbOKOnly, titulorefaccionaria)
                    Exit Sub
                End If

                If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, titulorefaccionaria) = vbCancel Then cnn1.Close() : Exit Sub

                Dim credito_dispo As Double = (CDbl(txtMaximo.Text) + CDbl(txtFavor.Text)) - ((CDbl(lblTotalPagar.Text) + CDbl(txtadeuda.Text)))


                If CDbl(lblTotalPagar.Text) > 0 Then
                    If lblcliente.Text <> "MOSTRADOR" And ((CDbl(lblTotalPagar.Text) + CDbl(txtadeuda.Text))) > (CDbl(txtMaximo.Text) + CDbl(txtFavor.Text)) Then
                        MsgBox("No se puede completar la operación porque se rebasaría el crédito disponible." & vbNewLine & "Crédito disponible: " & FormatNumber(credito_dispo, 2) & ".", vbInformation + vbOKOnly, titulotaller)
                        cnn1.Close() : Exit Sub
                    End If
                End If



                Dim CodCadena As String = ""
                Dim cadena As String = ""
                Dim ope1 As Double = 0
                Dim Car As Integer = 0
                Dim letters As String = ""
                Dim Numeros As String = ""
                Dim Letras As String = ""
                Dim lic As String = ""

                ope1 = Math.Cos(CDbl(lblFolio.Text))
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
                    Numeros = Mid(lblFolio.Text, w, 2)
                    Letras = Mid(letters, w, 2)
                    lic = lic & Numeros & Letras & "-"
                Next
                lic = Strings.Left(lic, Len(lic) - 1)
                CodCadena = lic

                Dim ACuenta As Double = 0
                Dim Resta As Double = 0
                Dim MyMonto As Double = 0
                Dim ACUenta2 As Double = 0
                Dim MyStatus As String = ""

                Dim SubTotal As Double = 0
                Dim IVA_Vent As Double = 0
                Dim Total_Ve As Double = 0
                Dim Descuento As Double = 0
                Dim MontoSDesc As Double = 0
                Select Case lblcliente.Text
                    Case Is <> "MOSTRADOR"

                        Resta = FormatNumber(lblTotalPagar.Text, 2)
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

                        IVA_Vent = FormatNumber(CDbl(lblTotalPagar.Text) - TotalIVAPrint, 2)
                        SubTotal = FormatNumber(TotalIVAPrint, 2)
                        Total_Ve = FormatNumber(CDbl(lblTotalPagar.Text), 2)
                        'Descuento = FormatNumber(txtdescuento2.Text, 2)
                        'MontoSDesc = FormatNumber(CDbl(txtPagar.Text) + Descuento, 2)

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Entrega,Comentario,StatusE,FolMonedero,CodFactura,IP,Formato) values(" & IDCLIENTE & ",'" & lblcliente.Text & "',''," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACUenta2 & "," & Resta & ",'" & lblatiende.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & fecha_pago & "','','" & MyStatus & "','',''," & MontoSDesc & ",'','0','',0,'','" & CodCadena & "','" & dameIP2() & "','" & cboimpresion.Text & "')"
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
                        FOLIO = rd2(0).ToString()
                    End If
                End If
                rd2.Close()
                cnn2.Close()

                cnn1.Close() : cnn1.Open()
                'Inserta en [AbonoI]
                Dim MySaldo As Double = 0
                If lblcliente.Text <> "MOSTRADOR" Then

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from Abonoi where Id=(select MAX(Id) from Abonoi where IdCliente=" & IDCLIENTE & ")"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + CDbl(lblTotalPagar.Text), 2)
                        End If
                    Else
                        MySaldo = FormatNumber(lblTotalPagar.Text, 2)
                    End If
                    rd1.Close()

                    Resta = FormatNumber(lblTotalPagar.Text, 2)

                    If CDbl(lblTotalPagar.Text) > 0 And CDbl(txtFavor.Text) > 0 And CDbl(lblTotalPagar.Text) = CDbl(lblTotalPagar.Text) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & FOLIO & "," & IDCLIENTE & ",'" & lblcliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','','" & lblatiende.Text & "'," & Resta & ",'')"
                        cmd1.ExecuteNonQuery()
                    Else
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & FOLIO & "," & IDCLIENTE & ",'" & lblcliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','','" & lblatiende.Text & "',0,'')"
                        cmd1.ExecuteNonQuery()
                    End If
                End If

                ACuenta = "0.00"

                If ACuenta > 0 Then
                End If
                cnn1.Close()

                cnn1.Close() : cnn1.Open()
                For R As Integer = 0 To grdProductos.Rows.Count - 1

                    Dim mycode As String = grdProductos.Rows(R).Cells(0).Value.ToString
                    Dim mydesc As String = grdProductos.Rows(R).Cells(1).Value.ToString
                    Dim myunid As String = "" ' = grdCaptura.Rows(R).Cells(2).Value.ToString
                    Dim mycant As Double = grdProductos.Rows(R).Cells(2).Value.ToString
                    Dim myprecio As Double = grdProductos.Rows(R).Cells(3).Value.ToString
                    Dim mytotal As Double = FormatNumber(mycant * myprecio, 2)

                    Dim ieps As Double = 0
                    Dim tasaieps As Double = 0

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

                    '  TotalIEPSPrint = TotalIEPSPrint + CDbl(grdCaptura.Rows(R).Cells(7).Value.ToString)

                    myprecioS = FormatNumber(myprecio / (1 + MyIVA), 6)
                    mytotalS = FormatNumber(mytotal / (1 + MyIVA), 6)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA,Departamento,Grupo,ProvRes,MCD,Multiplo,UVenta from Productos where Codigo='" & mycode & "'"
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
                            myunid = rd1(6).ToString
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
                    "select * from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
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

                    If grdProductos.Rows(R).Cells(0).Value.ToString() <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Promo_Monedero,Unico,Descuento) values(" & FOLIO & ",'" & mycode & "','" & mydesc & "','" & myunid & "'," & mycant & "," & MyProm & "," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','','0','" & MyDepto & "','" & MyGrupo & "','0',0,0," & ieps & "," & tasaieps & ",'','',0,0,0,0)"
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

                            Do While necesito > 0
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "select Id,Saldo,Costo from costeo where Id=(select MIN(Id) from costeo where (Concepto='COMPRA' or Concepto='ENTRADA') and Saldo>0 and Codigo='" & Strings.Left(mycode, 6) & "')"
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
                                        "update costeo set Saldo=" & quedan & " where Id=" & id_peps
                                    cmd1.ExecuteNonQuery()

                                    v_costo = necesito * cuanto_cuestan
                                    v_venta = necesito * myprecio
                                    utilidad = utilidad + (v_venta - v_costo)

                                    Exit Do
                                ElseIf tengo < necesito Then
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "update costeo set Saldo=0 where Id=" & id_peps
                                    cmd1.ExecuteNonQuery()

                                    v_costo = tengo * cuanto_cuestan
                                    v_venta = tengo * myprecio
                                    utilidad = (v_venta - v_costo)
                                    necesito = necesito - tengo

                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                        "insert into costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MyFolio & "','" & Strings.Left(mycode, 6) & "','" & mydesc & "','" & myunid & "',0," & (tengo * MyMultiplo) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblatiende.Text & "')"
                                    cmd1.ExecuteNonQuery()
                                    utilidad = 0
                                End If
                            Loop
                            'Sí alcanzan las que tengo en el primer registro, entonces guarda y avanza
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MyFolio & "','" & Strings.Left(mycode, 6) & "','" & mydesc & "','" & myunid & "',0," & (necesito * MyMultiplo) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblatiende.Text & "')"
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
                                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & Existencia & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblatiende.Text & "','" & MyFolio & "','','','','','')"
                                cmd1.ExecuteNonQuery()
                            Else
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & existe & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblatiende.Text & "','" & MyFolio & "','','','','','')"
                                cmd1.ExecuteNonQuery()
                            End If
                        End If
                        utilidad = 0
                        v_venta = 0
                        v_costo = 0
                        necesito = 0
                        tengo = 0
                    End If



                    If grdProductos.Rows(R).Cells(0).Value.ToString = "" And grdProductos.Rows(R).Cells(1).Value.ToString <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update VentasDetalle set CostVR='" & grdProductos.Rows(R).Cells(1).Value.ToString & "' where CostVR='' and Codigo='" & mycode & "' and Folio=" & MyFolio
                        cmd1.ExecuteNonQuery()
                    End If

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM comandasveh WHERE IdVehiculo=" & lblidvehiculo.Text & " AND Cliente='" & lblcliente.Text & "' AND Placa='" & var_placa & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Vehiculo SET Placa='', StatusT=0,Cliente='' WHERE Descripcion='" & txtvehiculo.Text & "' AND IdVehiculo='" & lblidvehiculo.Text & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                Next
                cnn1.Close()
            Else
                MsgBox("Debe de asignar los productos.", vbInformation + vbOKOnly, titulorefaccionaria)
                Exit Sub
            End If

            Dim pide As String = "", contra As String = txtclave.Text, usu As String = lblatiende.Text

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
            cnn1.Close()

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
                cnn1.Close() : cnn1.Open()
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
                cnn1.Close()

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

            btnlimpiar.PerformClick()
            If pide = "1" Then
                lblatiende.Text = usu
                txtclave.Text = contra
            End If
            FOLIO = 0

            btnlimpiar.PerformClick()
            pVehiculos.Controls.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub lblcliente_TextChanged(sender As Object, e As EventArgs) Handles lblcliente.TextChanged
        Try
            Dim MySaldo As Double = 0


            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Id,Credito FROM Clientes WHERE Nombre='" & lblcliente.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    IDCLIENTE = rd3(0).ToString
                    txtMaximo.Text = rd3(1).ToString
                End If
            End If
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "select Saldo from Abonoi where Id=(select max(Id) from Abonoi where IdCliente=" & IDCLIENTE & ")"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    MySaldo = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
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
            rd3.Close()
            cnn3.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboimpresion_DropDown(sender As Object, e As EventArgs) Handles cboimpresion.DropDown
        cboimpresion.Items.Clear()
        cboimpresion.Items.Add("TICKET")
        'cboimpresion.Items.Add("CARTA")
        'cboimpresion.Items.Add("MEDIA CARTA")
        cboimpresion.Items.Add("PDF - CARTA")
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
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie = rd2("Pie3").ToString
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
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd2.Close()
            cnn2.Close()
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
            If lblcliente.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(lblcliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(lblcliente.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(lblcliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13
                End If
            End If

            If txtvehiculo.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("V E H I C U L O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString(var_vehiculo, fuente_prods, Brushes.Black, 1, Y)
                Y += 13
                e.Graphics.DrawString("Placa: " & var_placa, fuente_prods, Brushes.Black, 1, Y)
                Y += 13
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

            cnn2.Close() : cnn2.Open()

            For miku As Integer = 0 To grdProductos.Rows.Count - 1

                If grdProductos.Rows(miku).Cells(1).Value.ToString() <> "" And grdProductos.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdProductos.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If

                Dim codigo As String = grdProductos.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdProductos.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = ""
                Dim canti As Double = grdProductos.Rows(miku).Cells(2).Value.ToString()
                Dim precio As Double = grdProductos.Rows(miku).Cells(3).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT UVenta FROM productos WHERE Codigo='" & codigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        unidad = rd2(0).ToString
                    End If
                End If
                rd2.Close()

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 100, Y)
                e.Graphics.DrawString(simbolo & precio, fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & total, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21

                total_prods = total_prods + canti
            Next
            cnn2.Close()

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

            cnn2.Close() : cnn2.Open()
            For N As Integer = 0 To grdProductos.Rows.Count - 1
                If CStr(grdProductos.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdProductos.Rows(N).Cells(0).Value.ToString) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                            Dim ivaa As Double = rd2(0).ToString

                            If ivaa > 0 Then
                                Dim preciosiniva = grdProductos.Rows(N).Cells(3).Value.ToString / CDbl(1 + ivaa)
                                preciosiniva = FormatNumber(preciosiniva, 2)
                                Dim ivapro = grdProductos.Rows(N).Cells(3).Value.ToString - preciosiniva
                                ivapro = FormatNumber(ivapro, 2)

                                MySubtotal = MySubtotal + (CDbl(lblTotalPagar.Text) - CDbl(ivapro))

                                TotalIVAPrint = ivapro

                            End If

                            'If CDbl(grdProductos.Rows(N).Cells(11).Value.ToString) <> 0 Then

                            'End If
                            'If CDbl(grdProductos.Rows(N).Cells(11).Value.ToString) <> 0 Then
                            '    TotalIEPS = TotalIEPS + CDbl(grdProductos.Rows(N).Cells(11).Value.ToString)
                            'End If
                        End If
                    End If
                    rd2.Close()
                End If
            Next
            cnn2.Close()

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)


            If MySubtotal > 0 Then
                e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(MySubtotal, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 18
            Else
                e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(lblTotalPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 18
            End If


            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(lblTotalPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            If CDbl(lblTotalPagar.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(lblTotalPagar.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            ' Dim IVA As Double = CDbl(lblTotalPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If TotalIVAPrint > 0 And TotalIVAPrint <> CDbl(lblTotalPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(TotalIVAPrint, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 13.5
                End If
            End If
            Y += 8

            e.Graphics.DrawString(convLetras(lblTotalPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

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

            e.Graphics.DrawString("Lo atiende " & lblatiende.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub PVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVenta58.PrintPage
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
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
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
            e.Graphics.DrawString("----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("N O T A  D E  V E N T A", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 12
            e.Graphics.DrawString("---------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 12
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 11

            '[2]. Datos del cliente
            If lblcliente.Text <> "" Then
                e.Graphics.DrawString("------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(lblcliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13
                If Mid(lblcliente.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(lblcliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13
                End If
            End If

            If txtvehiculo.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("V E H I C U L O", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString(txtvehiculo.Text, fuente_prods, Brushes.Black, 1, Y)
                Y += 13
                e.Graphics.DrawString("-------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0

            cnn3.Close() : cnn3.Open()

            For miku As Integer = 0 To grdProductos.Rows.Count - 1

                If grdProductos.Rows(miku).Cells(1).Value.ToString() <> "" And grdProductos.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdProductos.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If

                Dim codigo As String = grdProductos.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdProductos.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = ""
                Dim canti As Double = grdProductos.Rows(miku).Cells(2).Value.ToString()
                Dim precio As Double = grdProductos.Rows(miku).Cells(3).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT UVenta FROM productos WHERE Codigo='" & codigo & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        unidad = rd3(0).ToString
                    End If
                End If
                rd3.Close()

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
                e.Graphics.DrawString(simbolo & precio, fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & total, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21

                total_prods = total_prods + canti
            Next

            Y -= 3
            e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdProductos.Rows.Count - 1
                If CStr(grdProductos.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdProductos.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                            Dim ivaa As Double = rd1(0).ToString

                            If ivaa > 0 Then
                                Dim preciosiniva = grdProductos.Rows(N).Cells(3).Value.ToString / CDbl(1 + ivaa)
                                preciosiniva = FormatNumber(preciosiniva, 2)
                                Dim ivapro = grdProductos.Rows(N).Cells(3).Value.ToString - preciosiniva
                                ivapro = FormatNumber(ivapro, 2)
                                MySubtotal = MySubtotal + CDbl(preciosiniva)

                                TotalIVAPrint = preciosiniva

                            End If

                            'If CDbl(grdProductos.Rows(N).Cells(11).Value.ToString) <> 0 Then

                            'End If
                            'If CDbl(grdProductos.Rows(N).Cells(11).Value.ToString) <> 0 Then
                            '    TotalIEPS = TotalIEPS + CDbl(grdProductos.Rows(N).Cells(11).Value.ToString)
                            'End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)


            If MySubtotal > 0 Then
                e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(MySubtotal, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 18
            Else
                e.Graphics.DrawString("Subtotal:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(lblTotalPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 18
            End If


            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(lblTotalPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            If CDbl(lblTotalPagar.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(lblTotalPagar.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13.5
            End If

            Dim IVA As Double = CDbl(lblTotalPagar.Text) - TotalIVAPrint
            If DesglosaIVA = "1" Then
                If TotalIVAPrint > 0 Then
                    If TotalIVAPrint > 0 And TotalIVAPrint <> CDbl(lblTotalPagar.Text) Then
                        Y += 12
                        e.Graphics.DrawString("*** IVA 16%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & FormatNumber(TotalIVAPrint, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                        Y += 13.5
                    End If
                End If
                If TotalIEPS > 0 Then
                    e.Graphics.DrawString("*** IEPS 8%", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(TotalIEPS, 2), New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 13.5
                End If
            End If
            Y += 8

            e.Graphics.DrawString(convLetras(lblTotalPagar.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString(Mid(Pie, 1, 35), fuente_prods, Brushes.Black, 90, Y, sc)
            Y += 13.5
            If Mid(Pie, 36, 70) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 36, 70), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 13.5
            End If
            If Mid(Pie, 71, 105) <> "" Then
                e.Graphics.DrawString(Mid(Pie, 71, 105), fuente_prods, Brushes.Black, 90, Y, sc)
                Y += 13.5
            End If

            e.Graphics.DrawString("Lo atiende " & lblatiende.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub



    Private Sub btnRefaccion_Click(sender As Object, e As EventArgs)

        If txtclave.Text = "" Then MsgBox("Debe ingresar la contraseña por favor", vbInformation + vbOKOnly, titulorefaccionaria) : txtclave.Focus.Equals(True) : Exit Sub

        If grdProductos.Rows.Count = 0 Then MsgBox("Debe seleccionar un vehiculo", vbInformation + vbOKOnly, titulorefaccionaria) : Exit Sub

        Dim id As Integer = 0
        var_vehiculo = btnVehiculo.Text
        var_placa = btnVehiculo.Tag
        Try

            Dim descripcion As String = ""
            Dim marca As String = ""
            Dim modelo As String = ""
            Dim cliente As String = ""


            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Descripcion,Marca,Modelo,IdVehiculo,Cliente FROM Vehiculo WHERE Descripcion='" & var_vehiculo & "' and StatusT=1"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    descripcion = rd2(0).ToString
                    marca = rd2(1).ToString
                    modelo = rd2(2).ToString
                    id = rd2(3).ToString
                    cliente = rd2(4).ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()

            frmAsignaRefaccion.cbovehiculo.Text = descripcion
            frmAsignaRefaccion.idvehiculo = id
            frmAsignaRefaccion.txtCliente.Text = cliente
            frmAsignaRefaccion.placa = var_placa
            frmAsignaRefaccion.Show()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class