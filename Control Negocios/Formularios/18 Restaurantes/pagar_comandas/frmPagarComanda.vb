Public Class frmPagarComanda

    Dim totalventa As Double = 0
    Dim myope As Double = 0

    Dim idusuario As Integer = 0
    Dim estadousuario As String = ""
    Dim codigoeliminar As String = ""
    Dim descripcioneliminar As String = ""
    Dim unidadeliminar As String = ""
    Dim cantidadeliminar As Double = 0
    Dim precioeliminar As Double = 0
    Dim comandaeliminar As Integer = 0
    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick
        TFecha.Stop()

        Me.Text = Format(Date.Now, "yyyy/MM/dd HH:mm:ss")

        TFecha.Start()
    End Sub

    Private Sub frmPagarComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFecha.Start()
        TFolio.Start()
    End Sub

    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick
        TFolio.Stop()
        Folio()
        TFolio.Start()
    End Sub

    Public Sub Folio()

        Try

            cnntimer.Close() : cnntimer.Open()
            cmdtimer = cnntimer.CreateCommand
            cmdtimer.CommandText = "SELECT MAX(Folio) FROM ventas"
            rdtimer = cmdtimer.ExecuteReader
            If rdtimer.HasRows Then
                If rdtimer.Read Then
                    lblFolio.Text = IIf(rdtimer(0).ToString = "", "0", rdtimer(0).ToString) + 1
                Else
                    lblFolio.Text = "1"
                End If
            Else
                lblFolio.Text = "1"
            End If
            rdtimer.Close()
            cnntimer.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnntimer.Close()
        End Try

    End Sub

    Private Sub txtContra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContra.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then

            Try
                Dim idempleado As Integer = 0
                Dim aleas As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IdEmpleado,Alias FROM Usuarios WHERE Clave='" & txtContra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        idempleado = rd1(0).ToString
                        aleas = rd1(1).ToString
                        lblUsuario.Text = aleas

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT CobrarM FROM permisosm WHERE IdEmpleado=" & idempleado & ""
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                If rd2(0).ToString = 1 Then
                                    btnCerrar.Enabled = True
                                Else
                                    MsgBox("El empleado no cuenta con permisos para cobrar", vbInformation + vbOKOnly, titulorestaurante)
                                    Exit Sub
                                End If
                            End If
                        Else
                            MsgBox("El empleado no tiene asignado permisos", vbInformation + vbOKOnly, titulorestaurante)
                            Exit Sub
                        End If
                        rd2.Close()

                    End If
                Else
                    MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulorestaurante)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try

        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboMesa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMesa.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboComanda.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboComanda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboComanda.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboComensal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboComensal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboComensal.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnCerrar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboMesa_DropDown(sender As Object, e As EventArgs) Handles cboMesa.DropDown
        Try
            cboMesa.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nmesa FROM comandas WHERE Nmesa<>'' ORDER BY Nmesa"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMesa.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboComanda_DropDown(sender As Object, e As EventArgs) Handles cboComanda.DropDown
        Try
            cboComanda.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If cboMesa.Text = "" Then
                cmd5.CommandText = "SELECT DISTINCT Id FROM Comandas WHERE Id<>'' ORDER BY Id"
            Else
                cmd5.CommandText = "SELECT DISTINCT Id FROM Comandas WHERE Nmesa='" & cboMesa.Text & "' AND Id<>'' ORDER BY Id"
            End If


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

    Private Sub cboComensal_DropDown(sender As Object, e As EventArgs) Handles cboComensal.DropDown
        Try
            cboComensal.Items.Clear()

            If cboMesa.Text <> "" Then
                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand

                cmd5.CommandText = "SELECT DISTINCT Comensal FROM comandas WHERE Comensal<>'' AND Nmesa='" & cboMesa.Text & "'  ORDER BY Comensal"

                rd5 = cmd5.ExecuteReader
                Do While rd5.Read
                    If rd5.HasRows Then
                        cboComensal.Items.Add(rd5(0).ToString)
                    End If
                Loop
                rd5.Close()
                cnn5.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCambioM_DropDown(sender As Object, e As EventArgs) Handles cboCambioM.DropDown
        Try
            cboCambioM.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre_mesa FROM mesa WHERE Nombre_mesa<>'' ORDER BY Nombre_mesa"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCambioM.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboMesa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesa.SelectedValueChanged
        Try
            grdCaptura.Rows.Clear()
            txtPorcentaje.Text = "0"
            txtefecporcentaje.Text = "0.00"
            totalventa = 0

            btnCambio.Enabled = True
            btnCancelar.Enabled = True
            btnCortesia.Enabled = True
            btnPrecuenta.Enabled = True

            Dim propina As Double = 0
            Dim porcepropina As Double = 0
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Propina'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    propina = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Usuario FROM comanda1 WHERE Nombre='" & cboMesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    lblMesero.Text = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM comandas WHERE Nmesa='" & cboMesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    Dim codigo As String = rd2("Codigo").ToString
                    Dim nombre As String = rd2("Nombre").ToString
                    Dim unidad As String = rd2("UVenta").ToString
                    Dim cantidad As Double = rd2("Cantidad").ToString
                    Dim precio As Double = rd2("Precio").ToString
                    Dim total As Double = rd2("Total").ToString
                    Dim comensal As String = rd2("Comensal").ToString
                    Dim comanda As Integer = rd2("Id").ToString

                    grdCaptura.Rows.Add(codigo, nombre, unidad, cantidad, precio, total, comensal, comanda)

                    totalventa = totalventa + CDbl(total)

                End If
            Loop
            rd2.Close()
            cnn2.Close()

            If propina > 0 Then
                lblSubtotal.Text = FormatNumber(totalventa, 2)
                porcepropina = CDbl(totalventa) * (propina / 100)
                txtPropina.Text = FormatNumber(porcepropina, 2)
                lbltotalventa.Text = FormatNumber(CDbl(totalventa) + CDbl(txtPropina.Text), 2)
                txtResta.Text = FormatNumber(lbltotalventa.Text, 2)
            Else
                lblSubtotal.Text = FormatNumber(totalventa, 2)
                lbltotalventa.Text = FormatNumber(totalventa, 2)
                txtResta.Text = lbltotalventa.Text
            End If
            cboComanda.Text = ""
            cboComensal.Text = ""
            txtEfectivo.Focus.Equals(True)
            totalventa = 0

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPorcentaje.Text) Then

                Dim SALDO As Double = IIf(lblSubtotal.Text = "", "0", lblSubtotal.Text)
                Dim PORCENTAJE As Double = (txtPorcentaje.Text / 100)
                Dim porcentajetot As Double = CDbl(SALDO) * CDbl(PORCENTAJE)
                txtefecporcentaje.Text = FormatNumber(porcentajetot, 2)

                Dim subtotal As Double = 0
                subtotal = CDbl(lblSubtotal.Text) - CDbl(porcentajetot)
                lbltotalventa.Text = FormatNumber(subtotal, 2)


                Dim propina As Double = 0
                Dim porcpropina As Double = 0
                Dim totalpropina As Double = 0
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Propina'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        propina = rd1(0).ToString
                        If propina > 0 Then
                            porcpropina = propina / 100
                            totalpropina = CDbl(subtotal) * CDbl(porcpropina)
                            txtPropina.Text = FormatNumber(totalpropina, 2)
                            txtResta.Text = FormatNumber(CDbl(lbltotalventa.Text) + CDbl(txtPropina.Text), 2)
                            lbltotalventa.Text = FormatNumber(txtResta.Text, 2)
                        End If

                    End If
                End If
                rd1.Close()
                cnn1.Close()

            End If
        End If
    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged

        If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "0.00" : Exit Sub
        If Strings.Left(txtEfectivo.Text, 1) = "," Or Strings.Left(txtEfectivo.Text, 1) = "." Then Exit Sub


        myope = IIf(lbltotalventa.Text = "", "0.00", lbltotalventa.Text) - (CDbl(txtEfectivo.Text) + CDbl(txtPagos.Text))

        If myope < 0 Then
            txtCambio.Text = FormatNumber(-myope, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(myope, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
        myope = 0
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnCerrar.Enabled = True
            btnCerrar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnCambio_Click(sender As Object, e As EventArgs) Handles btnCambio.Click
        pCambioMesa.Visible = True
    End Sub

    Private Sub cboComanda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboComanda.SelectedValueChanged
        grdCaptura.Rows.Clear()
        TraerDatos("Comanda")

    End Sub

    Public Sub TraerDatos(ByVal tipo As String)
        Try
            totalventa = 0
            Dim propina As Double = 0
            Dim porcpropina As Double = 0

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Propina'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    propina = rd3(0).ToString
                End If
            End If
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            If tipo = "Comanda" Then

                If cboMesa.Text = "" Then
                    cmd3.CommandText = "SELECT * FROM comandas WHERE Id=" & cboComanda.Text & " ORDER BY Nombre"
                Else
                    cmd3.CommandText = "SELECT * FROM comandas WHERE Nmesa='" & cboMesa.Text & "' AND Id=" & cboComanda.Text & " ORDER BY Nombre"
                End If

            End If

            If tipo = "Comensal" Then
                If cboMesa.Text <> "" Then
                    cmd3.CommandText = "SELECT * FROM comandas WHERE Nmesa='" & cboMesa.Text & "' AND Comensal='" & cboComensal.Text & "' ORDER BY Nombre"
                End If
            End If


            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    lblMesero.Text = rd3("CUsuario").ToString

                    Dim codigo As String = rd3("Codigo").ToString
                    Dim nombre As String = rd3("Nombre").ToString
                    Dim unidad As String = rd3("UVenta").ToString
                    Dim cantidad As Double = rd3("Cantidad").ToString
                    Dim precio As Double = rd3("Precio").ToString
                    Dim total As Double = rd3("Total").ToString
                    Dim comensal As String = rd3("Comensal").ToString
                    Dim comanda As Integer = rd3("Id").ToString

                    grdCaptura.Rows.Add(codigo, nombre, unidad, cantidad, precio, total, comensal)

                    totalventa = totalventa + CDbl(total)

                End If
            Loop
            rd3.Close()
            cnn3.Close()

            If propina > 0 Then
                lblSubtotal.Text = FormatNumber(totalventa, 2)

                porcpropina = CDbl(totalventa) * (propina / 100)
                txtPropina.Text = FormatNumber(porcpropina, 2)
                lbltotalventa.Text = FormatNumber(CDbl(lblSubtotal.Text) + CDbl(porcpropina), 2)
                txtResta.Text = FormatNumber(lbltotalventa.Text, 2)
            Else
                lblSubtotal.Text = FormatNumber(totalventa, 2)
                lbltotalventa.Text = FormatNumber(lblSubtotal.Text, 2)
                txtResta.Text = FormatNumber(lbltotalventa.Text, 2)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub cboComensal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboComensal.SelectedValueChanged
        grdCaptura.Rows.Clear()
        TraerDatos("Comensal")
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboMesa.Text = ""
        cboComanda.Text = ""
        cboComensal.Text = ""
        lblMesero.Text = ""
        lblSubtotal.Text = "0.00"
        lbltotalventa.Text = "0.00"
        txtPorcentaje.Text = "0"
        txtefecporcentaje.Text = "0.00"
        txtPropina.Text = "0.00"
        txtPagos.Text = "0.00"
        txtEfectivo.Text = "0.00"
        txtCambio.Text = "0.00"
        txtResta.Text = "0.00"
        cboMesa.Text = ""
        cboMesa.Focused.Equals(True)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Dim CancelComand As Integer = 0
        Dim CantidadP As String = ""
        Dim canc As String = ""

        Dim COSTVUE1 As Double = 0
        Dim PRECIOSINIVA1 As Double = 0
        Dim IVA As Double = 0
        Dim PRECIOSINIVA11 As Double = 0
        Dim TOTALSINIVA As Double = 0
        Dim TOTAL1 As Double = 0
        Dim DEPA As String = ""
        Dim GRUPO1 As String = ""

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Status FROM Usuarios WHERE Alias='" & lblMesero.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    idusuario = rd1(0).ToString
                    estadousuario = rd1(1).ToString

                    If estadousuario = 1 Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT CancelarM FROM permisosm WHERE IdEmpleado=" & idusuario & ""
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                            End If
                        Else
                            MsgBox("El usuario no cuenta con permisos para realizar esta accion", vbInformation + vbOKOnly, titulorestaurante)
                            Exit Sub
                        End If
                        rd2.Close()
                        cnn2.Close()
                    Else
                        MsgBox("El usuario no esta activo contacte a su administrador", vbInformation + vbOKOnly, titulorestaurante)
                        Exit Sub
                    End If

                End If
            Else
                MsgBox("El usuario no esta registrado", vbInformation + vbOKOnly, titulorestaurante)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

            If grdCaptura.Rows.Count < 0 Then Exit Sub

            CantidadP = InputBox("Ingrese cantidad a cancelar para el producto " & descripcioneliminar, "Cancelar Producto", 1)
            My.Application.DoEvents()

            If CantidadP <> "" Then
                If cantidadeliminar >= CantidadP Then
                    If MsgBox("¿Seguro que desea continuar con la cancelacion?", vbInformation + vbOKCancel, "Delsscom® Restaurant") = vbCancel Then
                        Exit Sub
                    End If
                    canc = Val(CantidadP)

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigoeliminar & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.Read Then
                        If rd3.HasRows Then

                            COSTVUE1 = rd3("PrecioCompra").ToString
                            PRECIOSINIVA1 = rd3("PrecioVentaIVA").ToString
                            IVA = rd3("IVA").ToString
                            PRECIOSINIVA11 = FormatNumber(PRECIOSINIVA1 / IVA, 2)
                            TOTALSINIVA = FormatNumber(CDec(CantidadP * precioeliminar / 1.6), 2)
                            TOTAL1 = FormatNumber(CDec(CantidadP * precioeliminar), 2)
                            DEPA = rd3("Departamento").ToString
                            GRUPO1 = rd3("Grupo").ToString

                        End If
                    End If
                    rd3.Close()

                    cnn4.Close() : cnn4.Open()
                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "INSERT INTO Devoluciones(Folio,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,ImporteEfec,NMESA,CUsuario,Hr,TipoMov) VALUES(" & comandaeliminar & ",'" & codigoeliminar & "','" & descripcioneliminar & "','" & unidadeliminar & "'," & CantidadP & ",0,0," & COSTVUE1 & "," & precioeliminar & "," & TOTAL1 & "," & PRECIOSINIVA1 & "," & TOTALSINIVA & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','',0,'" & DEPA & "','" & GRUPO1 & "',0,'" & cboMesa.Text & "','" & lblUsuario.Text & "','" & Format(Date.Now, "HH:mm:ss") & "','CANCELACION')"
                    cmd4.ExecuteNonQuery()
                    cnn4.Close()

                    If cantidadeliminar = CantidadP Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Rep_Comandas SET Status='CANCELADA' WHERE NMESA='" & cboMesa.Text & "' AND Codigo='" & codigoeliminar & "',Nombre='" & descripcioneliminar & "' Id=" & comandaeliminar & ""
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "DELETE FROM Comandas WHERE Id=" & comandaeliminar & ""
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT NMESA FROM Comandas WHERE NMESA='" & cboMesa.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                            End If
                        Else
                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "DELETE FROM Comanda1"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT NMESA FROM Comandas WHERE NMESA='" & cboMesa.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "DELETE FROM Mesa WHERE Nombre_Mesa='" & cboMesa.Text & "' AND Temporal=1"
                                cmd3.ExecuteNonQuery()

                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "DELETE FROM MesasxEmpleados WHERE Mesa='" & cboMesa.Text & "' AND Temporal=1"
                                cmd3.ExecuteNonQuery()
                                cnn3.Close()

                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                        MsgBox("Cancelación realizada correctamente.", vbInformation + vbOKOnly, titulomensajes)
                        Me.Close()
                    Else

                        HrTiempo = Format(Date.Now, "yyyy/MM/dd")
                        HrEntrega = Format(Date.Now, "yyyy/MM/dd")

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Rep_Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "'"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Rep_Comandas SET Total=Cantidad * Precio WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM Rep_Comandas WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "' AND Status<>'CANCELADA'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "INSERT INTO Rep_Comandas(NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Grupo,EstatusT,Hr,EntregaT) VALUES('" & cboMesa.Text & "','" & rd2("Codigo").ToString & "','" & rd2("Nombre").ToString & "'," & CantidadP & ",'" & rd2("UVenta").ToString & "'," & rd2("CostVUE").ToString & "," & rd2("CostVP").ToString & "," & rd2("Precio").ToString & "," & rd2("Total").ToString & "," & rd2("PrecioSinIVA").ToString & "," & rd2("TotalSinIVA").ToString & ",'" & rd2("Comisionista").ToString & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & rd2("Depto").ToString & "','" & rd2("Comensal").ToString & "','CANCELADA','" & rd2("Comentario").ToString & "','" & rd2("GPrint").ToString & "','" & rd2("CUsuario").ToString & "','" & rd2("Total_comensales").ToString & "','" & rd2("Grupo").ToString & "',0,'" & HrTiempo & "','" & HrEntrega & "')"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                    End If

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE IDC=" & comandaeliminar & ""
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Comandas SET Total= Cantidad * Precio  WHERE IDC=" & comandaeliminar & ""
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                    cnn3.Close()
                    'Call PRINT1(comandaeliminar, codigoeliminar)
                Else
                    MsgBox("No es posible cancelar una cantidad mayor a este producto.", vbInformation + vbOKOnly, titulomensajes)
                End If
            End If
            cnn3.Close()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try


    End Sub

    Private Sub grdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellClick

        codigoeliminar = grdCaptura.CurrentRow.Cells(0).Value.ToString
        descripcioneliminar = grdCaptura.CurrentRow.Cells(1).Value.ToString
        unidadeliminar = grdCaptura.CurrentRow.Cells(2).Value.ToString
        cantidadeliminar = grdCaptura.CurrentRow.Cells(3).Value.ToString
        precioeliminar = grdCaptura.CurrentRow.Cells(4).Value.ToString
        comandaeliminar = grdCaptura.CurrentRow.Cells(7).Value.ToString
    End Sub

End Class