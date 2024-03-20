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
    Dim comensaleliminar As String = ""
    Dim comandaeliminar As Integer = 0

    Dim IMPCOMANDA As String = ""
    Dim CantidadP As String = ""
    Public usuarioingresado As String = ""

    Dim SinNumComensal As Integer = 0
    Dim idempleado As Integer = 0
    Dim aleas As String = ""
    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick
        TFecha.Stop()

        Me.Text = "PAGAR MESAS,COMANDAS" & Strings.Space(50) & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & Strings.Space(50) & "USUARIO: " & usuarioingresado
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


                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IdEmpleado,Alias,Puesto,Area FROM Usuarios WHERE Clave='" & txtContra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        If rd1(2).ToString = "MESERO" Or rd1(3).ToString = "MESERO" Then
                            MsgBox("ES MESERO")
                            lblUsuario.Text = ""
                            txtContra.Text = ""
                            txtContra.Focus.Equals(True)
                            Exit Sub

                        Else
                            idempleado = rd1(0).ToString
                            aleas = rd1(1).ToString
                            lblUsuario.Text = aleas


                        End If
                    End If
                Else
                    MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulorestaurante)
                    txtContra.Text = ""
                    lblUsuario.Text = ""
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()

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
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM comanda1 WHERE Nombre<>'' ORDER BY Nombre"
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

                If txtPorcentaje.Text > 100 Then
                    txtPorcentaje.Text = "0"
                    Exit Sub
                End If

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
        grdCaptura.Rows.Clear()
        pCambioMesa.Visible = False
        cboMesa.Focused.Equals(True)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Dim CancelComand As Integer = 0

        Dim canc As String = ""

        Dim COSTVUE1 As Double = 0
        Dim PRECIOSINIVA1 As Double = 0
        Dim IVA As Double = 0
        Dim PRECIOSINIVA11 As Double = 0
        Dim TOTALSINIVA As Double = 0
        Dim TOTAL1 As Double = 0
        Dim DEPA As String = ""
        Dim GRUPO1 As String = ""

        CantidadP = 0
        Try
            If lblUsuario.Text = "" Then MsgBox("Ingrese la contraseña del cajero") : txtContra.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Status FROM Usuarios WHERE Alias='" & lblUsuario.Text & "'"
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

                            If IVA > 0 Then
                                PRECIOSINIVA11 = FormatNumber(PRECIOSINIVA1 / (1 + IVA), 2)
                                TOTALSINIVA = FormatNumber(CDec(CantidadP * precioeliminar) / (1 + IVA), 2)
                            Else
                                PRECIOSINIVA11 = PRECIOSINIVA1
                                TOTALSINIVA = FormatNumber(CDec(CantidadP * precioeliminar), 2)
                            End If

                            TOTAL1 = FormatNumber(CDec(CantidadP * precioeliminar), 2)
                            DEPA = rd3("Departamento").ToString
                            GRUPO1 = rd3("Grupo").ToString
                            IMPCOMANDA = rd3("GPrint").ToString
                        End If
                    End If
                    rd3.Close()

                    cnn4.Close() : cnn4.Open()
                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "INSERT INTO Devoluciones(Folio,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,ImporteEfec,NMESA,CUsuario,Hr,TipoMov) VALUES(" & comandaeliminar & ",'" & codigoeliminar & "','" & descripcioneliminar & "','" & unidadeliminar & "'," & CantidadP & ",0,0," & COSTVUE1 & "," & precioeliminar & "," & TOTAL1 & "," & PRECIOSINIVA11 & "," & TOTALSINIVA & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','',0,'" & DEPA & "','" & GRUPO1 & "',0,'" & cboMesa.Text & "','" & lblUsuario.Text & "','" & Format(Date.Now, "HH:mm:ss") & "','CANCELACION')"
                    cmd4.ExecuteNonQuery()
                    cnn4.Close()

                    If cantidadeliminar = CantidadP Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand

                        If cboMesa.Text = "" Then
                            cmd2.CommandText = "UPDATE rep_comandas SET Status='CANCELADA' WHERE Codigo='" & codigoeliminar & "' AND Nombre='" & descripcioneliminar & "' AND Id=" & comandaeliminar & ""
                        Else
                            cmd2.CommandText = "UPDATE rep_comandas SET Status='CANCELADA' WHERE NMESA='" & cboMesa.Text & "' AND Codigo='" & codigoeliminar & "' AND Nombre='" & descripcioneliminar & "' AND Id=" & comandaeliminar & ""
                        End If
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        If cboMesa.Text = "" Then
                            cmd2.CommandText = "DELETE FROM Comandas WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "' AND Nombre='" & descripcioneliminar & "'"
                        Else
                            cmd2.CommandText = "DELETE FROM Comandas WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "' AND Nmesa='" & cboMesa.Text & "' AND Nombre='" & descripcioneliminar & "'"
                        End If
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM comandas WHERE Nmesa='" & cboMesa.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then

                            End If
                        Else
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & cboMesa.Text & "'"
                            cmd2.ExecuteNonQuery()
                            cnn2.Close()
                        End If
                        rd1.Close()
                        cnn1.Close()

                        MsgBox("Cancelación realizada correctamente.", vbInformation + vbOKOnly, titulomensajes)
                    Else

                        HrTiempo = Format(Date.Now, "yyyy/MM/dd")
                        HrEntrega = Format(Date.Now, "yyyy/MM/dd")

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand

                        If cboMesa.Text = "" Then
                            cmd2.CommandText = "UPDATE Rep_Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "'"
                        Else
                            cmd2.CommandText = "UPDATE Rep_Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "' AND NMESA='" & cboMesa.Text & "'"
                        End If
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand

                        If cboMesa.Text = "" Then
                            cmd2.CommandText = "UPDATE Rep_Comandas SET Total=Cantidad * Precio,TotalSinIva=Cantidad*Precio WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "'"
                        Else
                            cmd2.CommandText = "UPDATE Rep_Comandas SET Total=Cantidad * Precio,TotalSinIva=Cantidad*Precio WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "' AND NMesa='" & cboMesa.Text & "'"
                        End If
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
                                cmd4.CommandText = "INSERT INTO Rep_Comandas(NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Grupo,EstatusT,Hr,EntregaT) VALUES('" & cboMesa.Text & "','" & rd2("Codigo").ToString & "','" & rd2("Nombre").ToString & "'," & CantidadP & ",'" & rd2("UVenta").ToString & "'," & rd2("CostVUE").ToString & "," & rd2("CostVP").ToString & "," & rd2("Precio").ToString & "," & rd2("Precio").ToString * rd2("Cantidad").ToString & "," & rd2("PrecioSinIVA").ToString & "," & rd2("Precio").ToString * rd2("Cantidad").ToString & ",'" & rd2("Comisionista").ToString & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & rd2("Depto").ToString & "','" & rd2("Comensal").ToString & "','CANCELADA','" & rd2("Comentario").ToString & "','" & rd2("GPrint").ToString & "','" & rd2("CUsuario").ToString & "','" & rd2("Total_comensales").ToString & "','" & rd2("Grupo").ToString & "',0,'" & HrTiempo & "','" & HrEntrega & "')"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand

                        If cboMesa.Text = "" Then
                            cmd2.CommandText = "UPDATE Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "'"
                        Else
                            cmd2.CommandText = "UPDATE Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "' AND Nmesa='" & cboMesa.Text & "'"
                        End If
                        cmd2.ExecuteNonQuery()


                        cmd2 = cnn2.CreateCommand
                        If cboMesa.Text = "" Then
                            cmd2.CommandText = "UPDATE Comandas SET Total= Cantidad * Precio,TotalSinIVA=cantidad*Precio  WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "'"
                        Else
                            cmd2.CommandText = "UPDATE Comandas SET Total= Cantidad * Precio,TotalSinIVA=cantidad*Precio  WHERE Id=" & comandaeliminar & " AND Codigo='" & codigoeliminar & "' AND Nmesa='" & cboMesa.Text & "'"
                        End If
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()


                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM comandas WHERE Nmesa='" & cboMesa.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then

                            End If
                        Else
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & cboMesa.Text & "'"
                            cmd2.ExecuteNonQuery()
                            cnn2.Close()
                        End If
                        rd1.Close()
                        cnn1.Close()

                        MsgBox("Cancelación realizada correctamente.", vbInformation + vbOKOnly, titulomensajes)
                    End If
                    cnn3.Close()

                    'imprimir ticket devolucion
                    Dim tamimpre As Integer = 0
                    Dim impresora As String = ""

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TamImpre'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            tamimpre = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='" & IMPCOMANDA & "' AND Equipo='" & ObtenerNombreEquipo() & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            impresora = rd1(0).ToString
                        End If
                    End If
                    cnn1.Close()

                    If impresora = "" Then
                        MsgBox("No tiene asignada la ruta de impresion de comanda el producto", vbInformation + vbOKOnly, titulorestaurante)
                        Exit Sub
                    Else

                        If tamimpre = "80" Then
                            PDevolucion80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PDevolucion80.Print()
                        ElseIf tamimpre = "58" Then
                            PDevolucion58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PDevolucion58.Print()

                        End If

                    End If


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
        comensaleliminar = grdCaptura.CurrentRow.Cells(6).Value.ToString
        comandaeliminar = grdCaptura.CurrentRow.Cells(7).Value.ToString
    End Sub

    Private Sub PDevolucion80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PDevolucion80.PrintPage

        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("C O M A N D A   C A N C E L A D A", fuente_b, Brushes.Black, 135, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & comandaeliminar, fuente_r, Brushes.Black, 1, Y)

            If cboMesa.Text <> "" Then
                e.Graphics.DrawString("Mesa: " & cboMesa.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            End If
            Y += 18

            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
            e.Graphics.DrawString("COMENSAL", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            e.Graphics.DrawString(CantidadP, fuente_b, Brushes.Black, 1, Y)

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = descripcioneliminar
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                Y += 15
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString(comensaleliminar, fuente_b, Brushes.Black, 240, Y, derecha)
            Y += 15

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("MESERO: " & lblMesero.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("CAJERO: " & lblUsuario.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub PDevolucion58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PDevolucion58.PrintPage

        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("C O M A N D A   C A N C E L A D A", fuente_b, Brushes.Black, 90, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & comandaeliminar, fuente_r, Brushes.Black, 1, Y)

            If cboMesa.Text <> "" Then
                e.Graphics.DrawString("Mesa: " & cboMesa.Text, fuente_r, Brushes.Black, 180, Y, derecha)
            End If
            Y += 18

            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
            e.Graphics.DrawString("COMENSAL", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString(CantidadP, fuente_b, Brushes.Black, 1, Y)

            Dim caracteresPorLinea As Integer = 27
            Dim texto As String = descripcioneliminar
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 27, Y)
                Y += 15
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString(comensaleliminar, fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("MESERO: " & lblMesero.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("CAJERO: " & lblUsuario.Text, fuente_r, Brushes.Black, 180, Y, derecha)
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnPrecuenta_Click(sender As Object, e As EventArgs) Handles btnPrecuenta.Click
        Try

            If lblUsuario.Text = "" Then MsgBox("Debe ingresar la contraseña del cajero", vbInformation + vbOKOnly, titulorestaurante) : txtContra.Focus.Equals(True) : Exit Sub

            Dim tamimpre As Integer = 0
            Dim impresora As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Precuenta FROM permisosm WHERE IdEmpleado=" & idempleado
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = "1" Then

                    Else
                        MsgBox("El usuario no tiene permiso para realizar esta operación", vbInformation + vbOKOnly, titulorestaurante)
                        Exit Sub
                    End If

                End If
            Else
                MsgBox("Usuario sin asignación de permisos", vbInformation + vbOKOnly, titulorestaurante)
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tamimpre = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='TICKET' AND Equipo='" & ObtenerNombreEquipo() & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impresora = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If impresora = "" Then
                MsgBox("La impresora no esta configurada", vbInformation + vbOKOnly, titulorestaurante)
                Exit Sub
            Else
                If tamimpre = "80" Then
                    PPrecuenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PPrecuenta80.Print()
                ElseIf tamimpre = "58" Then
                    PPrecuenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PPrecuenta58.Print()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub PPrecuenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PPrecuenta80.PrintPage
        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("P R E C U E N T A", fuente_b, Brushes.Black, 135, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            If cboMesa.Text = "" Then
                e.Graphics.DrawString("Comanda: " & cboComanda.Text, fuente_r, Brushes.Black, 1, Y)
                Y += 18
            Else

                e.Graphics.DrawString("MESA: " & cboMesa.Text, fuente_r, Brushes.Black, 1, Y)
                Y += 18
            End If

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

            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                Dim nombre As String = grdCaptura.Rows(luffy).Cells(1).Value.ToString
                Dim cantidad As Double = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                Dim precio As Double = grdCaptura.Rows(luffy).Cells(4).Value.ToString
                Dim total As Double = grdCaptura.Rows(luffy).Cells(5).Value.ToString

                e.Graphics.DrawString(cantidad, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 30
                Dim texto As String = nombre
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 35, Y)
                    Y += 17
                    inicio += caracteresPorLinea
                End While

                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_p, Brushes.Black, 215, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                Y += 15
            Next
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            If txtPropina.Text > 0 Then
                e.Graphics.DrawString("SERVICIO: " & "$ " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            If txtefecporcentaje.Text > 0 Then
                e.Graphics.DrawString("DESCUENTO: " & "$ " & FormatNumber(txtefecporcentaje.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            e.Graphics.DrawString("SUBTOTAL: " & "$ " & FormatNumber(lblSubtotal.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            e.Graphics.DrawString("TOTAL A PAGAR: " & "$ " & FormatNumber(lbltotalventa.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            Dim CantidaLetra As String = ""
            CantidaLetra = "Son: " & convLetras(lbltotalventa.Text)

            e.Graphics.DrawString("MESERO: " & lblMesero.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("CAJERO: " & lblUsuario.Text, fuente_r, Brushes.Black, 270, Y, derecha)


            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub PPrecuenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PPrecuenta58.PrintPage

        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("P R E C U E N T A", fuente_b, Brushes.Black, 90, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            If cboMesa.Text = "" Then
                e.Graphics.DrawString("Comanda: " & cboComanda.Text, fuente_r, Brushes.Black, 1, Y)
                Y += 18
            Else

                e.Graphics.DrawString("MESA: " & cboMesa.Text, fuente_r, Brushes.Black, 1, Y)
                Y += 18
            End If

            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 133, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                Dim nombre As String = grdCaptura.Rows(luffy).Cells(1).Value.ToString
                Dim cantidad As Double = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                Dim precio As Double = grdCaptura.Rows(luffy).Cells(4).Value.ToString
                Dim total As Double = grdCaptura.Rows(luffy).Cells(5).Value.ToString

                e.Graphics.DrawString(cantidad, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 26
                Dim texto As String = nombre
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                    Y += 17
                    inicio += caracteresPorLinea
                End While

                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_p, Brushes.Black, 133, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_p, Brushes.Black, 180, Y, derecha)
                Y += 15
            Next
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            If txtPropina.Text > 0 Then
                e.Graphics.DrawString("SERVICIO: " & "$ " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20
            End If

            If txtefecporcentaje.Text > 0 Then
                e.Graphics.DrawString("DESCUENTO: " & "$ " & FormatNumber(txtefecporcentaje.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20
            End If

            e.Graphics.DrawString("SUBTOTAL: " & "$ " & FormatNumber(lblSubtotal.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.Graphics.DrawString("TOTAL A PAGAR: " & "$ " & FormatNumber(lbltotalventa.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            Dim CantidaLetra As String = ""
            CantidaLetra = "Son: " & convLetras(lbltotalventa.Text)

            e.Graphics.DrawString("MESERO: " & lblMesero.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("CAJERO: " & lblUsuario.Text, fuente_r, Brushes.Black, 180, Y, derecha)


            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btnCancM_Click(sender As Object, e As EventArgs) Handles btnCancM.Click
        pCambioMesa.Visible = False
        cboCambioM.Text = ""
    End Sub

    Private Sub btnAceptarM_Click(sender As Object, e As EventArgs) Handles btnAceptarM.Click
        Try
            If lblUsuario.Text = "" Then MsgBox("Ingrese la contraseña por favor", vbInformation + vbOKOnly, titulorestaurante) : txtContra.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CambioM FROM permisosm WHERE IdEmpleado=" & idempleado
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = "1" Then

                        If cboCambioM.Text <> "" Then

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "UPDATE Comanda1 SET Nombre='" & cboCambioM.Text & "' WHERE Nombre='" & cboMesa.Text & "'"
                            cmd2.ExecuteNonQuery()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "UPDATE comandas SET Nmesa='" & cboCambioM.Text & "' WHERE Nmesa='" & cboMesa.Text & "'"
                            cmd2.ExecuteNonQuery()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "UPDATE rep_comandas SET NMESA='" & cboCambioM.Text & "' WHERE NMESA='" & cboMesa.Text & "' AND Status='ORDENADA'"
                            If cmd2.ExecuteNonQuery() Then
                                MsgBox("Cambio de mesa exitoso", vbInformation + vbOKOnly, titulorestaurante)
                                cnn2.Close()
                                pCambioMesa.Visible = False
                                txtCambio.Text = ""
                            End If

                        End If
                    Else
                        MsgBox("El usuario no tiene permiso para realizar esta operación", vbInformation + vbOKOnly, titulorestaurante)
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Usuario sin asignación de permisos", vbInformation + vbOKOnly, titulorestaurante)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Try

            If lblUsuario.Text = "" Then MsgBox("Ingrese la contraseña por favor", vbInformation + vbOKOnly) : txtContra.Focus.Equals(True) : Exit Sub

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT CobrarM FROM permisosm WHERE IdEmpleado=" & idempleado
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2(0).ToString = 1 Then

                    Else
                        MsgBox("El empleado no cuenta con permisos para realizar esta operación", vbInformation + vbOKOnly, titulorestaurante)
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("El empleado no tiene asignado permisos", vbInformation + vbOKOnly, titulorestaurante)
                Exit Sub
            End If
            rd2.Close()
            cnn2.Close()

            Dim mypago As Double = 0

            mypago = CDec(txtEfectivo.Text) + CDec(txtPagos.Text) - CDec(txtCambio.Text) - CDec(txtefecporcentaje.Text)

            If mypago < CDec(lbltotalventa.Text) Then
                MsgBox("Debe cerrar la cuenta", vbInformation + vbOKOnly, titulorestaurante)
                Exit Sub
            End If

            If MsgBox("¿Desea guardar los datos de esta venta?", vbQuestion + vbYesNo + vbDefaultButton1) = vbNo Then
                Exit Sub
            End If

            If CDec(lbltotalventa.Text) <= CDec(mypago) Then
                mypago = lbltotalventa.Text
                txtResta.Text = 0
            End If

#Region "CODIGO AUTOFACTURAR"
            Dim letras As String
            Dim letters As String = ""
            Dim pc As String = lblFolio.Text
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
                car = Mid(lblFolio.Text, i, 1)
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

            Dim totalcomisiones As Double = 0
            Dim preciosiniva As Double = 0
            Dim ivatot As Double = 0
            Dim totaliva As Double = 0

            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1
                Dim codigo As String = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                Dim cantidad As Double = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                Dim precio As Double = grdCaptura.Rows(luffy).Cells(4).Value.ToString
                Dim iva As Double = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & codigo & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        iva = rd1("IVA").ToString
                        totalcomisiones = totalcomisiones + CDbl(cantidad) * CDbl(rd1("Comision").ToString)

                        If iva > 0 Then
                            preciosiniva = CDbl(precio) / (1 + iva)
                            ivatot = CDbl(precio) - CDbl(FormatNumber(preciosiniva, 2))
                            totaliva = totaliva + ivatot
                        End If

                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Next
            totaliva = FormatNumber(totaliva, 2)

            Dim totalventa As Double = 0
            totalventa = lbltotalventa.Text

            Dim subtotalventa As Double = 0
            subtotalventa = CDbl(lbltotalventa.Text) - CDbl(totaliva)

            Dim restaventa As Double = 0
            restaventa = txtResta.Text

            Dim propinaventa As Double = 0
            propinaventa = txtPropina.Text

            Dim descuentoventa As Double = 0
            descuentoventa = txtefecporcentaje.Text

            Dim idcliente As Integer = 0
            Dim nombre As String = ""

            If cbocliente.Text = "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Id,Nombre FROM clientes WHERE Nombre='PUBLICO EN GENERAL'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        idcliente = rd1(0).ToString
                        nombre = rd1(1).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Else
                nombre = cbocliente.Text
            End If



            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "DELETE FROM VtaImpresion"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales) VALUES(" & idcliente & ",'" & nombre & "',''," & FormatNumber(subtotalventa, 2) & "," & FormatNumber(totaliva, 2) & "," & Format(totalventa, 2) & ")"
            cmd3.ExecuteNonQuery()
            cnn3.Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try

    End Sub
End Class