﻿

Imports System.Runtime.InteropServices.ComTypes
Imports System.IO
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
    Dim totaleliminar As Double = 0
    Dim comensaleliminar As String = ""
    Dim comandaeliminar As Integer = 0

    Dim IMPCOMANDA As String = ""
    Dim CantidadP As String = ""
    Public usuarioingresado As String = ""

    Dim SinNumComensal As Integer = 0
    Dim idempleado As Integer = 0
    Dim aleas As String = ""

    Dim idcliente As Integer = 0

    Dim folioventa As Integer = 0
    Dim foliomonedero As String = ""
    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick
        TFecha.Stop()

        Me.Text = "PAGAR MESAS,COMANDAS" & Strings.Space(50) & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & Strings.Space(50) & "USUARIO: " & usuarioingresado
        TFecha.Start()
    End Sub

    Private Sub frmPagarComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFecha.Start()
        TFolio.Start()


        TraerUsuario()
    End Sub

    Public Sub TraerUsuario()

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TomaContra'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2(0).ToString = 1 Then

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Alias,Clave FROM usuarios WHERE IdEmpleado=" & id_usu_log
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                lblUsuario.Text = rd3(0).ToString
                                txtContra.Text = rd3(1).ToString
                                idempleado = id_usu_log
                            End If
                        End If
                        rd3.Close()
                        cnn3.Close()
                    Else
                        lblUsuario.Text = ""
                        txtContra.Text = ""
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
                            MsgBox("No puede realizar ninguna de estas operaciones", vbInformation + vbOKOnly, titulorestaurante)
                            lblUsuario.Text = ""
                            txtContra.Text = ""
                            txtContra.Focus.Equals(True)
                            Exit Sub

                        Else
                            idempleado = rd1(0).ToString
                            aleas = rd1(1).ToString
                            lblUsuario.Text = aleas
                            usuarioingresado = lblUsuario.Text

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

                btnCerrar.Focus.Equals(True)
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
            cmd5.CommandText = "SELECT DISTINCT Id FROM Comandas WHERE Nmesa='" & cboMesa.Text & "' AND Id<>'' ORDER BY Id"
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

                    grdCaptura.Rows.Add(codigo, nombre, unidad, cantidad, precio, total, comensal, comanda)

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
            txtEfectivo.Focus.Equals(True)
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

        TraerUsuario()

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
        totaleliminar = grdCaptura.CurrentRow.Cells(5).Value.ToString
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
            Dim SLD1 As Double = 0
            Dim SLD As Double = 0
            Dim myefectivo As Double = 0

            mypago = CDec(txtEfectivo.Text) + CDec(txtPagos.Text) - CDec(txtCambio.Text) - CDec(txtefecporcentaje.Text)
            SLD1 = CDbl(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)) + CDbl(IIf(txtPagos.Text = 0, 0, txtPagos.Text))
            myefectivo = CDbl(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text))

            If CDbl(SLD1) >= CDbl(lbltotalventa.Text) Then
                SLD = 0
            End If

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
            Dim status As String = ""

            Dim idmonedero As Integer = 0
            Dim saldomonedero As Double = 0
            Dim porcentajemonedero As Double = 0

            Dim pagarmonedero As Double = 0

            Dim saldomonnuevo As Double = 0

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

            If mypago < lbltotalventa.Text Then
                status = "RESTA"
            Else
                status = "PAGADO"
            End If

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "DELETE FROM VtaImpresion"
            cmd3.ExecuteNonQuery()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Propina,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,MontoCance,Status,Comisionista,Facturado,Concepto,N_Traslado,Corte,CorteU,MontoSinDesc,Cargado,FEntrega,Entrega,Comentario,CantidadE,FolMonedero,CodFactura,IP,Formato,TComensales,MntoCortesia,Franquicia) VALUES(" & idcliente & ",'" & nombre & "',''," & subtotalventa & "," & totaliva & "," & totalventa & "," & propinaventa & "," & descuentoventa & ",0," & mypago & "," & restaventa & ",'" & lblUsuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','',0,'" & status & "','" & totalcomisiones & "',0,'',0,0,0," & totalventa & ",0,'" & Format(Date.Now, "yyyy-MM-dd") & "',0,'',0,'','" & lic & "','" & dameIP2() & "','TICKET','',0,1)"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT MAX(folio) FROM ventas"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    folioventa = rd4(0).ToString
                End If
            End If
            rd4.Close()
            cnn4.Close()



            If grdPagos.Rows.Count > 0 Then
                For forace = 0 To grdPagos.Rows.Count - 1

                    Dim formapago As String = grdPagos.Rows(forace).Cells(0).Value.ToString
                    Dim banco As String = grdPagos.Rows(forace).Cells(1).Value.ToString
                    Dim referencia As String = grdPagos.Rows(forace).Cells(2).Value.ToString
                    Dim monto As Double = grdPagos.Rows(forace).Cells(3).Value.ToString
                    Dim coment As String = grdPagos.Rows(forace).Cells(4).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Fecha,Hora,Folio,Comentario) VALUES('" & formapago & "','" & banco & "','" & referencia & "','Venta'," & monto & ",0," & monto & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & lblFolio.Text & "','" & coment & "')"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()

                    If CDbl(monto) > 0 Then
                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO abonoi      (NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargado,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Comentario,Propina,Comisiones,Mesero,Descuento) VALUES(" & folioventa & "," & idcliente & ",'" & nombre & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & mypago & "," & SLD & ",'" & formapago & "'," & monto & ",'" & banco & "','" & referencia & "','" & lblUsuario.Text & "','" & coment & "'," & propinaventa & "," & totalcomisiones & ",'" & lblMesero.Text & "'," & descuentoventa & ")"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()
                    End If

                    If formapago = "MONEDERO" Then

                        foliomonedero = grdPagos.Rows(forace).Cells(2).Value.ToString
                        pagarmonedero = grdPagos.Rows(forace).Cells(3).Value.ToString

                        If foliomonedero <> "" Then

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT * FROM Monedero WHERE Barras='" & foliomonedero & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    idmonedero = rd2("Id").ToString
                                    saldomonedero = rd2("Saldo").ToString
                                    porcentajemonedero = rd2("Porcentaje").ToString
                                End If
                            End If
                            rd2.Close()
                            cnn2.Close()

                            saldomonnuevo = CDec(CDec(lbltotalventa.Text) - CDec(pagarmonedero)) * CDec(porcentajemonedero / 100)
                            Dim conversaldo As String = ""
                            conversaldo = ""
                            For i = 1 To Len(saldomonnuevo)
                                If Mid(saldomonnuevo, i, 1) = "." Then
                                    Exit For
                                End If
                                conversaldo = saldomonnuevo
                            Next i
                            saldomonnuevo = conversaldo
                        End If

                        If CDec(monto) > 0 Then
                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "UPDATE Monedero SET Saldo=Saldo-" & CDec(monto) & ",Cargado='0' WHERE Id=" & idmonedero & ""
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If

                    End If
                Next
            End If

            If pagarmonedero > 0 Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "UPDATE Monedero SET Saldo=Saldo + " & CDec(saldomonnuevo) & ", Cargado='0' WHERE Id=" & idmonedero & ""
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "UPDATE Monedero SET Cargado='0' WHERE Folio='" & foliomonedero & "'"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If

            If CDbl(myefectivo) > 0 Then
                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Comentario,Propina,Comisiones,Mesero,Descuento) VALUES(" & folioventa & "," & idcliente & ",'" & nombre & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "',0," & mypago & "," & SLD & ",'EFECTIVO'," & myefectivo & ",'','','" & lblUsuario.Text & "',''," & propinaventa & "," & totalcomisiones & ",'" & lblMesero.Text & "'," & descuentoventa & ")"
                cmd3.ExecuteNonQuery()
                cnn3.Close()
            End If


            Dim loba As Integer = 0
            Dim codigog As String = ""
            Dim descripciong As String = ""
            Dim unidadg As String = ""
            Dim cantidadg As Double = 0
            Dim preciog As Double = 0
            Dim totalg As Double = 0
            Dim comensalg As String = ""
            Dim comandag As Integer = 0

            Dim PrecioCompra As Double = 0
            Dim PrecioSinIVA1 As Double = 0
            Dim departamento As String = ""
            Dim grupo As String = ""
            Dim multiplo As Double = 0
            Dim TotalSinIVA1 As Double = 0
            Dim gprint As String = ""

            Dim varieps As String = ""
            Dim vartotal As String = ""

            'insertar a ventasdetalle
            Do While loba <> grdCaptura.Rows.Count

                codigog = grdCaptura.Rows(loba).Cells(0).Value.ToString
                descripciong = grdCaptura.Rows(loba).Cells(1).Value.ToString
                unidadg = grdCaptura.Rows(loba).Cells(2).Value.ToString
                cantidadg = grdCaptura.Rows(loba).Cells(3).Value.ToString
                preciog = grdCaptura.Rows(loba).Cells(4).Value.ToString
                totalg = grdCaptura.Rows(loba).Cells(5).Value.ToString
                comensalg = grdCaptura.Rows(loba).Cells(6).Value.ToString
                comandag = grdCaptura.Rows(loba).Cells(7).Value.ToString

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigog & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        PrecioCompra = rd2("PrecioCompra").ToString
                        PrecioSinIVA1 = FormatNumber(rd2("PrecioVentaIVA").ToString / CDec(rd2("IVA").ToString + 1), 2)
                        departamento = rd2("Departamento").ToString
                        grupo = rd2("Grupo").ToString
                        multiplo = rd2("Multiplo").ToString
                        gprint = rd2("GPrint").ToString
                        If CDec(rd2("IVA").ToString) > 0 Then
                            TotalSinIVA1 = FormatNumber(totalg / 1.16, 2)
                        Else
                            TotalSinIVA1 = totalg
                        End If
                    End If
                Else
                    If codigog = "WXYZ" Then
                        PrecioCompra = 0
                        PrecioSinIVA1 = FormatNumber(preciog, 2)
                        departamento = "UNICO"
                        grupo = "UNICO"
                        multiplo = 1
                        TotalSinIVA1 = FormatNumber(totalg, 2)
                    End If
                End If
                rd2.Close()
                cnn2.Close()

                varieps = 0
                vartotal = 0

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO ventasdetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,TotalIEPS,TasaIEPS,GPrint,Comensal,Comentario,Usuario) VALUES(" & folioventa & ",'" & codigog & "','" & descripciong & "','" & unidadg & "'," & cantidadg & "," & PrecioCompra & "," & preciog & "," & preciog & "," & totalg & "," & PrecioSinIVA1 & "," & TotalSinIVA1 & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','','0','" & departamento & "','" & grupo & "',0," & vartotal & "," & varieps & ",'" & gprint & "','" & comensalg & "','','" & lblUsuario.Text & "')"
                cmd3.ExecuteNonQuery()
                cnn3.Close()

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO vtaimpresion(Folio,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,Comensal,Propina,Mesa) VALUES(" & folioventa & ",'" & codigog & "','" & descripciong & "','" & unidadg & "'," & cantidadg & ",0," & PrecioCompra & "," & preciog & "," & preciog & "," & totalg & "," & PrecioSinIVA1 & "," & TotalSinIVA1 & ",'" & Format(Date.Now, "yyyyy-MM-dd") & "','','0','" & departamento & "','" & grupo & "','" & comensalg & "'," & propinaventa & ",'" & cboMesa.Text & "')"
                cmd3.ExecuteNonQuery()

                If cboComanda.Text <> "" Then

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "UPDATE Rep_Comandas SET Status='PAGADO' WHERE Id=" & cboComanda.Text & " AND NMESA='" & cboMesa.Text & "' AND Status<>'CANCELADA'"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM Comandas WHERE NMESA='" & cboMesa.Text & "' AND Id=" & cboComanda.Text & ""
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & cboMesa.Text & "' AND Folio=" & cboComanda.Text & ""
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()

                End If

                If cboComanda.Text = "" Then

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "UPDATE Rep_Comandas SET Status='PAGADO' WHERE NMESA='" & cboMesa.Text & "' AND Status<>'CANCELADA'"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM Comandas WHERE NMESA='" & cboMesa.Text & "'"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & cboMesa.Text & "'"
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()

                End If



                If saldomonnuevo <> 0 Then
                    Dim saldomonderopro As Double = 0
                    saldomonderopro = 0
                    saldomonderopro = CDec(CDec(lbltotalventa.Text) - CDec(pagarmonedero)) * CDec(porcentajemonedero / 100)

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "INSERT INTO MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) VALUES('" & foliomonedero & "','Asigna Puntos','" & saldomonderopro & "'," & pagarmonedero & "," & saldomonnuevo & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & folioventa & ")"
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()
                End If

                loba = loba + 1
            Loop


            Dim MCD As Double = 0
            Dim MCD1 As Double = 0
            Dim KIT As Integer = 0
            Dim unico As Integer = 0
            Dim existencia As Double = 0
            Dim nuevaexistencia As Double = 0
            Dim opeCantReal As Double = 0

            codigog = ""
            descripciong = ""
            unidadg = ""
            cantidadg = 0
            preciog = 0
            totalg = 0
            comensalg = ""
            comandag = 0

            PrecioCompra = 0
            PrecioSinIVA1 = 0
            departamento = ""
            grupo = ""
            multiplo = 0
            TotalSinIVA1 = 0
            gprint = ""

            Dim kreaper As Integer = 0
            Dim modo_almacen As Integer = 0

            Dim nuevocodigo As String = ""
            Dim nuevadescripcion As String = ""
            Dim nuevacantidad As Double = 0


            For kreaper = 0 To grdCaptura.Rows.Count - 1

                codigog = grdCaptura.Rows(kreaper).Cells(0).Value.ToString
                descripciong = grdCaptura.Rows(kreaper).Cells(1).Value.ToString
                unidadg = grdCaptura.Rows(kreaper).Cells(2).Value.ToString
                cantidadg = grdCaptura.Rows(kreaper).Cells(3).Value.ToString
                preciog = grdCaptura.Rows(kreaper).Cells(4).Value.ToString
                totalg = grdCaptura.Rows(kreaper).Cells(5).Value.ToString
                comensalg = grdCaptura.Rows(kreaper).Cells(6).Value.ToString

                cnn2.Close() : cnn2.Open()
                cnn3.Close() : cnn3.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & codigog & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        modo_almacen = rd2("Modo_Almacen").ToString


                        If modo_almacen = 1 Then

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT CodigoP,Codigo,Descrip,Cantidad FROM MiProd WHERE CodigoP='" & Strings.Left(codigog, 6) & "'"
                            rd3 = cmd3.ExecuteReader
                            Do While rd3.Read
                                If rd3.HasRows Then
                                    nuevocodigo = rd2("Codigo").ToString
                                    nuevadescripcion = rd2("Descrip").ToString
                                    nuevacantidad = rd2("Cantidad").ToString * grdCaptura.Rows(kreaper).Cells(3).Value.ToString

                                    cnn4.Close() : cnn4.Open()
                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText = "SELECT * FROM Productos WHERE Codigo='" & nuevocodigo & "'"
                                    rd4 = cmd4.ExecuteReader
                                    If rd4.HasRows Then
                                        If rd4.Read Then
                                            PrecioCompra = 0
                                            departamento = rd4("Departamento").ToString
                                            grupo = rd4("Grupo").ToString
                                            KIT = rd4("ProvRes").ToString
                                            MCD = rd4("MCD").ToString
                                            multiplo = rd4("Multiplo").ToString
                                            unico = rd4("Unico").ToString
                                            gprint = rd4("GPrint").ToString
                                            If CStr(rd4("Departamento").ToString()) = "SERVICIOS" Then
                                                rd4.Close() : cnn4.Close()
                                                GoTo Door
                                            End If
                                        End If
                                    End If
                                    rd4.Close()

                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Strings.Left(nuevocodigo, 6) & "'"
                                    rd4 = cmd4.ExecuteReader
                                    If rd4.HasRows Then
                                        If rd4.Read Then
                                            existencia = rd4("Existencia").ToString()
                                            MCD1 = rd4("MCD").ToString()
                                            nuevaexistencia = existencia / MCD1
                                            If rd4("Departamento").ToString() <> "SERVICIOS" Then
                                                PrecioCompra = rd4("PrecioCompra").ToString()
                                                'MyCostVUE = Pre_Comp * (MYCANT / MyMCD)
                                            End If
                                        End If
                                    End If
                                    rd4.Close()

                                    opeCantReal = CDbl(nuevacantidad) * CDbl(multiplo)
                                    Dim nueva_existe As Double = 0
                                    nueva_existe = nuevaexistencia - (nuevacantidad / MCD)


                                    cnn1.Close() : cnn1.Open()
                                    cmd1 = cnn4.CreateCommand
                                    cmd1.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) VALUES('" & nuevocodigo & "','" & nuevadescripcion & "','Venta-Ingrediente'," & opeCantReal & "," & PrecioCompra & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblUsuario.Text & "'," & existencia & "," & nueva_existe & "," & folioventa & ")"
                                    cmd1.ExecuteNonQuery()
                                    cnn1.Close()

                                    cnn1.Close() : cnn1.Open()
                                    cmd1 = cnn4.CreateCommand
                                    cmd1.CommandText = "UPDATE Productos SET Cargado=0,CargadoInv=0,Existencia=" & nueva_existe & " WHERE Codigo='" & Strings.Left(nuevocodigo, 6) & "'"
                                    cmd1.ExecuteNonQuery()

                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText = "INSERT INTO Mov_Ingre(Codigo,Descripcion,Cantidad,Fecha) VALUES('" & nuevocodigo & "','" & nuevadescripcion & "'," & nuevacantidad & ",'" & Format(Date.Now, "yyyy/MM/dd") & "')"
                                    cmd1.ExecuteNonQuery()
                                    cnn1.Close()


                                End If
                            Loop
                            rd3.Close()
                            cnn3.Close()
                            cnn4.Close()

                        Else
                            If grdCaptura.Rows(kreaper).Cells(0).Value.ToString = "" Then GoTo Door

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Strings.Left(codigog, 6) & "'"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then
                                    PrecioCompra = 0
                                    departamento = rd3("Departamento").ToString
                                    grupo = rd3("Grupo").ToString
                                    KIT = rd3("ProvRes").ToString
                                    MCD = rd3("MCD").ToString
                                    multiplo = rd3("Multiplo").ToString
                                    unico = rd3("Unico").ToString
                                    gprint = rd3("GPrint").ToString
                                    If rd3("Departamento").ToString() = "SERVICIOS" Then
                                        rd3.Close() : cnn3.Close()
                                        GoTo Door
                                    End If
                                End If
                            End If
                            rd3.Close()

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Strings.Left(codigog, 6) & "'"
                            rd3 = cmd3.ExecuteReader
                            If rd3.HasRows Then
                                If rd3.Read Then
                                    existencia = rd3("Existencia").ToString()
                                    MCD1 = rd3("MCD").ToString()
                                    nuevaexistencia = existencia / MCD1
                                    If rd3("Departamento").ToString() <> "SERVICIOS" Then
                                        PrecioCompra = rd3("PrecioCompra").ToString()
                                    End If
                                End If
                            End If
                            rd3.Close()
Door:

                            opeCantReal = 0
                            opeCantReal = CDbl(cantidadg) * CDbl(multiplo)
                            Dim existenciaactu As Double = 0
                            existenciaactu = 0
                            existenciaactu = nuevaexistencia - (cantidadg / MCD)

                            cnn4.Close() : cnn4.Open()
                            cmd4 = cnn4.CreateCommand
                            cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) VALUES('" & codigog & "','" & descripciong & "','Venta-Ingrediente'," & opeCantReal & "," & PrecioCompra & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblUsuario.Text & "'," & existencia & "," & existenciaactu & "," & folioventa & ")"
                            cmd4.ExecuteNonQuery()

                            cmd4 = cnn4.CreateCommand
                            cmd4.CommandText = "UPDATE Productos SET Existencia=" & existenciaactu & ",Cargado=0,CargadoInv=0 WHERE Codigo='" & Strings.Left(codigog, 6) & "'"
                            cmd4.ExecuteNonQuery()
                            cnn4.Close()
                        End If

                    End If
                End If
                rd2.Close()
                cnn2.Close()
                cnn3.Close()
            Next

            If pagarmonedero <> 0 Then
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Mov_Monedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) VALUES('" & foliomonedero & "','Pago Puntos'," & saldomonnuevo & "," & saldomonnuevo & "," & pagarmonedero & ",'" & Format(Date.Now, "yyyy/MM/dd") & "'," & lblFolio.Text & ")"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If

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
                            PPVenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PPVenta80.Print()
                        Next
                    End If

                    If TamImpre = "58" Then
                        For naruto As Integer = 1 To copias
                            PPVenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                            PPVenta58.Print()
                        Next
                    End If

                End If
            Else
                If TamImpre = "80" Then
                    For naruto As Integer = 1 To copias
                        PPVenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PPVenta80.Print()
                    Next
                End If

                If TamImpre = "58" Then
                    For naruto As Integer = 1 To copias
                        PPVenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PPVenta58.Print()
                    Next
                End If

            End If

#End Region

            If CDec(txtResta.Text) = 0 Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Comanda1 WHERE Nombre='" & cboMesa.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM Mesa WHERE Nombre_mesa='" & cboMesa.Text & "' AND Temporal='1'"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM MesasxEmpleados WHERE Mesa='" & cboMesa.Text & "' AND Temporal='1'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            End If


                btnLimpiar.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try

    End Sub

    Private Sub btnagregarpago_Click(sender As Object, e As EventArgs) Handles btnagregarpago.Click


        Dim tipo As String = cboforma.Text
        Dim banco As String = cboBanco.Text
        Dim referencia As String = txtreferencia.Text
        Dim monto As Double = txtmonto.Text
        Dim comen As String = txtComentario.Text

        Dim totalpagos As Double = 0
        If tipo = "MONEDERO" Then
        Else

            If tipo = "" Then
                MsgBox("Debe seleccionar una forma de pago", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If banco = "" Then
                MsgBox("Debe seleccionar una banco", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If referencia = "" Then
                MsgBox("Debe ingresar una refrencia", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If monto = 0 Then
                MsgBox("Debe ingresar un monto", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

        End If

        grdPagos.Rows.Add(tipo, banco, referencia, monto, comen)
        totalpagos = txtPagos.Text + monto
        txtPagos.Text = FormatNumber(totalpagos, 2)
        limpiarforma()
    End Sub

    Public Sub limpiarforma()
        cboforma.Text = ""
        cboBanco.Text = ""
        txtreferencia.Text = ""
        txtmonto.Text = "0.00"
        txtComentario.Text = ""

    End Sub

    Private Sub grdPagos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagos.CellDoubleClick

        Dim index As Integer = grdPagos.CurrentRow.Index

        Dim importe = grdPagos.Rows(index).Cells(3).Value.ToString

        grdPagos.Rows.Remove(grdPagos.Rows(index))
        txtPagos.Text = txtPagos.Text - CDec(importe)
        txtPagos.Text = FormatNumber(txtPagos.Text, 2)

    End Sub

    Private Sub cboforma_DropDown(sender As Object, e As EventArgs) Handles cboforma.DropDown
        Try
            cboforma.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboforma.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboBanco_DropDown(sender As Object, e As EventArgs) Handles cboBanco.DropDown
        Try
            cboBanco.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Banco FROM bancos WHERE Banco<>'' ORDER BY Banco"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboBanco.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtPagos_TextChanged(sender As Object, e As EventArgs) Handles txtPagos.TextChanged

        Dim Resta As Double = 0

        Try
            Resta = CDec(IIf(txtPagos.Text = "", "0", txtPagos.Text)) - CDec(IIf(lbltotalventa.Text = "", "0", lbltotalventa.Text))

            Resta = FormatNumber(Resta, 2)
            myope = CDec(IIf(lbltotalventa.Text = "", "0", lbltotalventa.Text)) - (CDec(IIf(txtPagos.Text = "", "0", txtPagos.Text)) + CDec(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))

            If myope < 0 Then
                Resta = -myope
                txtResta.Text = "0.00"
            Else
                txtResta.Text = myope
                Resta = "0.00"
            End If
            Resta = FormatNumber(Resta, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)

            If txtPagos.Text > 0 Then
                btnCerrar.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub cboforma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboforma.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboBanco.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboBanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtreferencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtreferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtreferencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmonto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtmonto.Text) Then
                txtComentario.Focus.Equals(True)
            Else
                txtmonto.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub txtComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentario.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnagregarpago.Focus.Equals(True)
        End If
    End Sub

    Public Sub traernumerocomensal()

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='SinNumComensal'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                SinNumComensal = rd2(0).ToString
            End If
        End If
        rd2.Close()
        cnn2.Close()

    End Sub
    Private Sub PPVenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PPVenta80.PrintPage
        Try

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
            Dim nLogo As String = DatosRecarga("LogoG")
            Dim tLogo As String = DatosRecarga("TipoLogo")
            Dim simbolo As String = DatosRecarga("Simbolo")
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")
            Dim facLinea As Integer = DatosRecarga("AutoFac")
            Dim foliofactura As String = ""

            Dim articulos As Integer = 0

            Dim ivaventa As Double = 0
            Dim subtotalventa As Double = 0
            Dim totalesventa As Double = 0

            Dim codigot As String = ""
            Dim nombret As String = ""
            Dim preciot As Double = 0
            Dim totalt As Double = 0
            Dim cantidadt As Double = 0

            Dim pie As String = ""

            Dim comen_sal As String = ""
            Dim TOTALCOM As Double = 0
            Dim numdec As String = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select CodFactura FROM Ventas WHERE Folio=" & folioventa
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    foliofactura = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Subtotal,IVA,Totales FROM Ventas WHERE Folio=" & folioventa
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    subtotalventa = rd2(0).ToString
                    ivaventa = rd2(1).ToString
                    totalventa = rd2(2).ToString
                End If
            End If
            rd2.Close()


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

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    pie = rd2("Pie1").ToString
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

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            If cboMesa.Text = "" Then
                e.Graphics.DrawString("Comanda: " & cboComanda.Text, fuente_r, Brushes.Black, 1, Y)
            Else
                e.Graphics.DrawString("Mesa: " & cboMesa.Text, fuente_r, Brushes.Black, 1, Y)
            End If

            e.Graphics.DrawString("Folio: " & folioventa, fuente_r, Brushes.Black, 270, Y, derecha)
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

            traernumerocomensal()

            If SinNumComensal = 0 Then

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "Select Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, comensal,Propina from VtaImpresion where Folio=" & folioventa & " Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then

                        nombret = rd4("Nombre").ToString
                        preciot = rd4("Precio").ToString
                        totalt = rd4("Tot").ToString
                        cantidadt = rd4("Cant").ToString

                        e.Graphics.DrawString(FormatNumber(cantidadt, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 32
                        Dim texto As String = nombret
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40, Y)
                            Y += 13
                            inicio += caracteresPorLinea
                        End While

                        e.Graphics.DrawString(simbolo & " " & preciot, fuente_p, Brushes.Black, 200, Y, derecha)
                        e.Graphics.DrawString(simbolo & " " & FormatNumber(totalt, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                        Y += 13

                        articulos = articulos + cantidadt
                    End If
                Loop
                rd4.Close()


                e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                Y += 11
            Else

                Dim conta As Integer = 0
                Dim contband As Integer = 0
                Dim comensal As String = ""

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "SELECT DISTINCT comensal FROM VtaImpresion"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then
                        comensal = rd4(0).ToString

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, Comensal,Propina FROM VtaImpresion where Folio=" & folioventa & " and Comensal='" & comensal & "' Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                        rd3 = cmd3.ExecuteReader

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * from VtaImpresion where comensal='" & comensal & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            conta = conta + 1
                        Loop
                        rd1.Close()

                        Do While rd3.Read
                            If rd3.HasRows Then
                                conta = conta
                                contband = contband + 1

                                If comen_sal <> rd3("Comensal").ToString Then
                                    e.Graphics.DrawString("Detalle Comensal:", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(rd3("Comensal").ToString, fuente_b, Brushes.Black, 120, Y)
                                    TOTALCOM = 0
                                End If
                                Y += 20


                                nombret = rd3("Nombre").ToString
                                preciot = rd3("Precio").ToString
                                totalt = rd3("Tot").ToString
                                cantidadt = rd3("Cant").ToString

                                e.Graphics.DrawString(FormatNumber(cantidadt, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                                Dim caracteresPorLinea As Integer = 32
                                Dim texto As String = nombret
                                Dim inicio As Integer = 0
                                Dim longitudTexto As Integer = texto.Length

                                While inicio < longitudTexto
                                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                                    e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40, Y)
                                    Y += 13
                                    inicio += caracteresPorLinea
                                End While

                                e.Graphics.DrawString(simbolo & " " & preciot, fuente_p, Brushes.Black, 195, Y, derecha)
                                e.Graphics.DrawString(simbolo & " " & FormatNumber(totalt, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                                Y += 13

                                articulos = articulos + cantidadt
                                TOTALCOM = CDec(TOTALCOM) + CDec(totalt)

                                If contband < conta Then

                                    comen_sal = rd3("Comensal").ToString
                                ElseIf contband = conta Then
                                    comen_sal = ""
                                End If

                                If comen_sal <> rd3("Comensal").ToString Then
                                    If numdec <> "" Then
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    Else
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    End If
                                    Y += 20
                                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TOTALCOM, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                                    Y += 15

                                    e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                                    Y += 16
                                End If
                                comen_sal = rd3("Comensal").ToString
                                totalventa = totalventa + totalt

                            End If
                        Loop
                        rd3.Close()

                    End If
                Loop
                rd4.Close()


            End If
            Y += 10
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 25

            If ivaventa <> 0 Then

                If DesglosaIVA = False Then
                    e.Graphics.DrawString("SUBTOTAL: " & simbolo & " " & FormatNumber(subtotalventa, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("IVA: " & simbolo & " " & FormatNumber(ivaventa, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("TOTAL A PAGAR: " & simbolo & " " & FormatNumber(totalventa, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 30

                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: " & simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                e.Graphics.DrawString("TOTAL A PAGAR: " & simbolo & " " & FormatNumber(CDec(lbltotalventa.Text), 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 25
            Else
                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: " & simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                e.Graphics.DrawString("TOTAL A PAGAR: " & simbolo & " " & FormatNumber(lbltotalventa.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 25
            End If

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO" & simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If
            If CDec(txtefecporcentaje.Text) <> 0 Then
                e.Graphics.DrawString("DESCUENTO: " & simbolo & " " & FormatNumber(txtefecporcentaje.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            For deku As Integer = 0 To grdPagos.Rows.Count - 1

                Dim formapago As String = grdPagos.Rows(deku).Cells(0).Value.ToString
                Dim bancopago As String = grdPagos.Rows(deku).Cells(1).Value.ToString
                Dim refenciapago As String = grdPagos.Rows(deku).Cells(2).Value.ToString
                Dim montopago As Double = grdPagos.Rows(deku).Cells(3).Value.ToString


                If formapago = "EFECTIVO" Then
                Else
                    If formapago = "MONEDERO" Then

                        e.Graphics.DrawString("MONEDERO: " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                        Y += 20

                        e.Graphics.DrawString("FOLIO DEL MONEDERO: " & foliomonedero, fuente_b, Brushes.Black, 150, Y)
                        Y += 20
                    Else
                        If montopago > 0 Then
                            e.Graphics.DrawString("PAGO EN: " & simbolo & " " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                            Y += 20

                            e.Graphics.DrawString("BANCO: " & bancopago, fuente_b, Brushes.Black, 100, Y)
                            Y += 20

                            e.Graphics.DrawString("NUM TARJ: " & refenciapago, fuente_b, Brushes.Black, 100, Y)
                            Y += 20
                        End If
                    End If
                End If

            Next

            If CDec(txtResta.Text) <> 0 Then
                e.Graphics.DrawString("RESTA: " & simbolo & " " & FormatNumber(txtResta.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            If CDec(txtCambio.Text) <> 0 Then
                e.Graphics.DrawString("CAMBIO: " & simbolo & " " & FormatNumber(txtCambio.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 10
            End If
            Y += 15

            Dim cantidadLetra As String = ""
            cantidadLetra = convLetras(lbltotalventa.Text)

            If Mid(cantidadLetra, 1, 38) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 1, 38), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If

            If Mid(cantidadLetra, 39, 70) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 39, 70), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If
            Y += 10

            If Mid(pie, 1, 38) <> "" Then
                e.Graphics.DrawString(Mid(pie, 1, 38), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If
            Y += 5

            e.Graphics.DrawString("Cajero: " & lblUsuario.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Mesero: " & lblMesero.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15

            If facLinea = 1 Then
                e.Graphics.DrawString("Folio para Facturar", fuente_b, Brushes.Black, 135, Y, sc)
                Y += 15
                e.Graphics.DrawString(foliofactura, fuente_b, Brushes.Black, 135, Y, sc)
            End If

            e.HasMorePages = False
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnCortesia_Click(sender As Object, e As EventArgs) Handles btnCortesia.Click
        Try
            folioventa = 0
            Dim idcli As Integer = 0
            Dim cli As String = ""

            Dim preciocompra As Double = 0
            Dim departamento As String = ""
            Dim grupo As String = ""
            Dim gprint As String = ""

            If lblUsuario.Text = "" Then MsgBox("Ingrese la contraseña de favor", vbInformation + vbOKOnly, titulorestaurante) : txtContra.Focus.Equals(True) : Exit Sub

            If codigoeliminar = "" Then MsgBox("Necesita seleccionar un producto", vbInformation + vbOKOnly, titulorestaurante) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CortesiaM FROM permisosm WHERE IdEmpleado=" & idempleado
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = 1 Then
                    Else
                        MsgBox("El usuario no tiene permisos para realizar esta operación", vbInformation + vbOKOnly, titulorestaurante)
                        lblUsuario.Text = ""
                        txtContra.Text = ""
                        txtContra.Focus.Equals(True)
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Usuario sin asignación de permisos", vbInformation + vbOKOnly, titulorestaurante)
                txtContra.Text = ""
                txtContra.Focus.Equals(True)
                lblUsuario.Text = ""
                Exit Sub
            End If
            rd1.Close()

            If cbocliente.Text = "" Then

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Id,Nombre FROM clientes WHERE Nombre='PUBLICO EN GENERAL'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        idcli = rd1(0).ToString
                        cli = rd1(1).ToString
                    End If
                End If
                rd1.Close()
            Else
                idcli = idcliente
                cli = cbocliente.Text
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrecioCompra,Departamento,Grupo,GPrint FROM productos WHERE Codigo='" & codigoeliminar & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    preciocompra = rd1("PrecioCompra").ToString
                    departamento = rd1("Departamento").ToString
                    grupo = rd1("Grupo").ToString
                    gprint = rd1("GPrint").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()




            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "DELETE FROM vtaimpresion"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Propina,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,MontoSinDesc,FEntrega,Status,Comisionista,Concepto,IP,Formato) VALUES(" & idcli & ",'" & cli & "','',0,0,0,0," & totaleliminar & ",0,0,0,'" & lblUsuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0,'" & Format(Date.Now, "yyyy-MM-dd") & "','PAGADO','0','CORTESIA','" & dameIP2() & "','TICKET')"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT MAX(Folio) FROM ventas"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    folioventa = rd2(0).ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Propina,Comisiones,Mesero,Descuento) VALUES(" & folioventa & "," & idcli & ",'" & cli & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0,0,0,'CORTESIA',0,'','','" & lblUsuario.Text & "',0,0,'" & lblMesero.Text & "'," & precioeliminar & ")"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO ventasdetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,GPrint,Comensal,Comentario,Usuario) VALUES(" & folioventa & ",'" & codigoeliminar & "','" & descripcioneliminar & "','" & unidadeliminar & "'," & cantidadeliminar & "," & preciocompra & "," & precioeliminar & "," & precioeliminar & ",0,0,0,'" & Format(Date.Now, "yyyy-MM-dd") & "','','0','" & departamento & "','" & grupo & "','0','" & gprint & "','" & comensaleliminar & "','CORTESIA','" & lblUsuario.Text & "')"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO vtaimpresion(Folio,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,Comensal,Propina,Mesa) VALUES(" & folioventa & ",'" & codigoeliminar & "','" & descripcioneliminar & "','" & unidadeliminar & "'," & cantidadeliminar & ",0," & preciocompra & "," & precioeliminar & "," & precioeliminar & ",0,0,0,'" & Format(Date.Now, "yyyy-MM-dd") & "','0',0,'" & departamento & "','" & grupo & "','" & comensaleliminar & "',0,'" & cboMesa.Text & "')"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "UPDATE productos SET Existencia=Existencia-" & CDbl(cantidadeliminar) & " WHERE Codigo='" & codigoeliminar & "'"
            cmd2.ExecuteNonQuery()
            cnn2.Close()

            If cboComanda.Text <> "" Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "UPDATE rep_comandas SET Status='CORTESIA' WHERE Id=" & cboComanda.Text & " AND NMESA='" & cboMesa.Text & "' AND Codigo='" & codigoeliminar & "'"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM comandas WHERE Id=" & cboComanda.Text & " AND Nmesa='" & cboMesa.Text & "' AND Codigo='" & codigoeliminar & "'"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If

            If cboComanda.Text = "" Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "UPDATE rep_comandas SET Status='CORTESIA' WHERE NMESA='" & cboMesa.Text & "' AND Codigo='" & codigoeliminar & "'"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM comandas WHERE Nmesa='" & cboMesa.Text & "' AND Codigo='" & codigoeliminar & "'"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If

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

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM mesa WHERE Nombre_mesa='" & cboMesa.Text & "' AND Temporal=1"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM mesasxempleados WHERE Mesa='" & cboMesa.Text & "' AND Temporal=1"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

            'ticket
            Dim tamimpre As Integer = 0
            Dim impresora As String = ""
            Dim copias As Double = 0

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
            cmd1.CommandText = "SELECT Copias FROM ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    copias = rd1(0).ToString
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
                MsgBox("Necesita configurar una impresora", vbInformation + vbOKOnly, titulorestaurante)
            Else

                If tamimpre = "80" Then
                    For sasuke As Integer = 1 To copias
                        PCortesia80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PCortesia80.Print()
                    Next
                End If

                If tamimpre = "58" Then
                    For rin As Integer = 1 To copias
                        PCortesia58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PCortesia58.Print()
                    Next
                End If

            End If

            btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocliente_DropDown(sender As Object, e As EventArgs) Handles cbocliente.DropDown
        Try
            cbocliente.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbocliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbocliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbocliente.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM clientes WHERE Nombre='" & cbocliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idcliente = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub PPVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PPVenta58.PrintPage

        Try

            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
            Dim fuente_a As New Font("Lucida Sans Typewriter", 10, FontStyle.Bold)

            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            Dim Logotipo As Drawing.Image = Nothing
            Dim nLogo As String = DatosRecarga("LogoG")
            Dim tLogo As String = DatosRecarga("TipoLogo")
            Dim simbolo As String = DatosRecarga("Simbolo")
            Dim DesglosaIVA As String = DatosRecarga("Desglosa")
            Dim facLinea As Integer = DatosRecarga("AutoFac")
            Dim foliofactura As String = ""

            Dim articulos As Integer = 0

            Dim ivaventa As Double = 0
            Dim subtotalventa As Double = 0
            Dim totalesventa As Double = 0

            Dim codigot As String = ""
            Dim nombret As String = ""
            Dim preciot As Double = 0
            Dim totalt As Double = 0
            Dim cantidadt As Double = 0

            Dim pie As String = ""

            Dim comen_sal As String = ""
            Dim TOTALCOM As Double = 0
            Dim numdec As String = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select CodFactura FROM Ventas WHERE Folio=" & folioventa
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    foliofactura = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Subtotal,IVA,Totales FROM Ventas WHERE Folio=" & folioventa
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    subtotalventa = rd2(0).ToString
                    ivaventa = rd2(1).ToString
                    totalventa = rd2(2).ToString
                End If
            End If
            rd2.Close()


            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 80)
                    Y += 90
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    pie = rd2("Pie1").ToString
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
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd2.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            If cboMesa.Text = "" Then
                e.Graphics.DrawString("Comanda: " & cboComanda.Text, fuente_r, Brushes.Black, 1, Y)
            Else
                e.Graphics.DrawString("Mesa: " & cboMesa.Text, fuente_r, Brushes.Black, 1, Y)
            End If

            e.Graphics.DrawString("Folio: " & folioventa, fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 23
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 133, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            traernumerocomensal()

            If SinNumComensal = 0 Then

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "Select Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, comensal,Propina from VtaImpresion where Folio=" & folioventa & " Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then

                        nombret = rd4("Nombre").ToString
                        preciot = rd4("Precio").ToString
                        totalt = rd4("Tot").ToString
                        cantidadt = rd4("Cant").ToString

                        e.Graphics.DrawString(FormatNumber(cantidadt, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 27
                        Dim texto As String = nombret
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 30, Y)
                            Y += 13
                            inicio += caracteresPorLinea
                        End While

                        e.Graphics.DrawString(simbolo & " " & preciot, fuente_p, Brushes.Black, 133, Y, derecha)
                        e.Graphics.DrawString(simbolo & " " & FormatNumber(totalt, 2), fuente_p, Brushes.Black, 180, Y, derecha)
                        Y += 13

                        articulos = articulos + cantidadt
                    End If
                Loop
                rd4.Close()


                e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                Y += 11
            Else

                Dim conta As Integer = 0
                Dim contband As Integer = 0
                Dim comensal As String = ""

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "SELECT DISTINCT comensal FROM VtaImpresion"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then
                        comensal = rd4(0).ToString

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, Comensal,Propina FROM VtaImpresion where Folio=" & folioventa & " and Comensal='" & comensal & "' Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                        rd3 = cmd3.ExecuteReader

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * from VtaImpresion where comensal='" & comensal & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            conta = conta + 1
                        Loop
                        rd1.Close()

                        Do While rd3.Read
                            If rd3.HasRows Then
                                conta = conta
                                contband = contband + 1

                                If comen_sal <> rd3("Comensal").ToString Then
                                    e.Graphics.DrawString("Detalle Comensal:", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(rd3("Comensal").ToString, fuente_b, Brushes.Black, 120, Y)
                                    TOTALCOM = 0
                                End If
                                Y += 20


                                nombret = rd3("Nombre").ToString
                                preciot = rd3("Precio").ToString
                                totalt = rd3("Tot").ToString
                                cantidadt = rd3("Cant").ToString

                                e.Graphics.DrawString(FormatNumber(cantidadt, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                                Dim caracteresPorLinea As Integer = 27
                                Dim texto As String = nombret
                                Dim inicio As Integer = 0
                                Dim longitudTexto As Integer = texto.Length

                                While inicio < longitudTexto
                                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                                    e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 30, Y)
                                    Y += 13
                                    inicio += caracteresPorLinea
                                End While

                                e.Graphics.DrawString(simbolo & " " & preciot, fuente_p, Brushes.Black, 133, Y, derecha)
                                e.Graphics.DrawString(simbolo & " " & FormatNumber(totalt, 2), fuente_p, Brushes.Black, 180, Y, derecha)
                                Y += 13

                                articulos = articulos + cantidadt
                                TOTALCOM = CDec(TOTALCOM) + CDec(totalt)

                                If contband < conta Then

                                    comen_sal = rd3("Comensal").ToString
                                ElseIf contband = conta Then
                                    comen_sal = ""
                                End If

                                If comen_sal <> rd3("Comensal").ToString Then
                                    If numdec <> "" Then
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    Else
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    End If
                                    Y += 20
                                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TOTALCOM, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                                    Y += 15

                                    e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                                    Y += 16
                                End If
                                comen_sal = rd3("Comensal").ToString
                                totalventa = totalventa + totalt

                            End If
                        Loop
                        rd3.Close()

                    End If
                Loop
                rd4.Close()


            End If
            Y += 10
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 25

            If ivaventa <> 0 Then

                If DesglosaIVA = False Then
                    e.Graphics.DrawString("SUBTOTAL: " & simbolo & " " & FormatNumber(subtotalventa, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("IVA: " & simbolo & " " & FormatNumber(ivaventa, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("TOTAL A PAGAR: " & simbolo & " " & FormatNumber(totalventa, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 30

                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: " & simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 20
                End If

                e.Graphics.DrawString("TOTAL A PAGAR: " & simbolo & " " & FormatNumber(CDec(lbltotalventa.Text), 2), fuente_a, Brushes.Black, 180, Y, derecha)
                Y += 25
            Else
                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: " & simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 20
                End If

                e.Graphics.DrawString("TOTAL A PAGAR: " & simbolo & " " & FormatNumber(lbltotalventa.Text, 2), fuente_a, Brushes.Black, 180, Y, derecha)
                Y += 25
            End If

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO" & simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20
            End If
            If CDec(txtefecporcentaje.Text) <> 0 Then
                e.Graphics.DrawString("DESCUENTO: " & simbolo & " " & FormatNumber(txtefecporcentaje.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20
            End If

            For deku As Integer = 0 To grdPagos.Rows.Count - 1

                Dim formapago As String = grdPagos.Rows(deku).Cells(0).Value.ToString
                Dim bancopago As String = grdPagos.Rows(deku).Cells(1).Value.ToString
                Dim refenciapago As String = grdPagos.Rows(deku).Cells(2).Value.ToString
                Dim montopago As Double = grdPagos.Rows(deku).Cells(3).Value.ToString


                If formapago = "EFECTIVO" Then
                Else
                    If formapago = "MONEDERO" Then

                        e.Graphics.DrawString("MONEDERO: " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                        Y += 20

                        e.Graphics.DrawString("FOLIO DEL MONEDERO: " & foliomonedero, fuente_b, Brushes.Black, 90, Y)
                        Y += 20
                    Else
                        If montopago > 0 Then
                            e.Graphics.DrawString("PAGO EN: " & simbolo & " " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                            Y += 20

                            e.Graphics.DrawString("BANCO: " & bancopago, fuente_b, Brushes.Black, 70, Y)
                            Y += 20

                            e.Graphics.DrawString("NUM TARJ: " & refenciapago, fuente_b, Brushes.Black, 70, Y)
                            Y += 20
                        End If
                    End If
                End If

            Next

            If CDec(txtResta.Text) <> 0 Then
                e.Graphics.DrawString("RESTA: " & simbolo & " " & FormatNumber(txtResta.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20
            End If

            If CDec(txtCambio.Text) <> 0 Then
                e.Graphics.DrawString("CAMBIO: " & simbolo & " " & FormatNumber(txtCambio.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 10
            End If
            Y += 14

            Dim cantidadLetra As String = ""
            cantidadLetra = convLetras(lbltotalventa.Text)

            If Mid(cantidadLetra, 1, 28) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 1, 28), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If

            If Mid(cantidadLetra, 29, 48) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 29, 48), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If
            Y += 10

            If Mid(pie, 1, 28) <> "" Then
                e.Graphics.DrawString(Mid(pie, 1, 28), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If
            Y += 5

            e.Graphics.DrawString("Cajero: " & lblUsuario.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Mesero: " & lblMesero.Text, fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 15

            If facLinea = 1 Then
                e.Graphics.DrawString("Folio para Facturar", fuente_b, Brushes.Black, 85, Y, sc)
                Y += 15
                e.Graphics.DrawString(foliofactura, fuente_b, Brushes.Black, 85, Y, sc)
            End If

            e.HasMorePages = False
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub PCortesia80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCortesia80.PrintPage
        Try
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
            Dim nLogo As String = DatosRecarga("LogoG")
            Dim tLogo As String = DatosRecarga("TipoLogo")
            Dim simbolo As String = DatosRecarga("Simbolo")

            Dim pie As String = ""
            Dim articulos As Double = 0

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
                    pie = rd2("Pie1").ToString
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

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("C O R T E S I A", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            If cboMesa.Text = "" Then
                e.Graphics.DrawString("Comanda: " & cboComanda.Text, fuente_r, Brushes.Black, 1, Y)
            Else
                e.Graphics.DrawString("Mesa: " & cboMesa.Text, fuente_r, Brushes.Black, 1, Y)
            End If

            e.Graphics.DrawString("Folio: " & folioventa, fuente_r, Brushes.Black, 270, Y, derecha)
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


            e.Graphics.DrawString(FormatNumber(cantidadeliminar, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

            Dim caracteresPorLinea As Integer = 32
            Dim texto As String = descripcioneliminar
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40, Y)
                Y += 13
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString(simbolo & " " & precioeliminar, fuente_p, Brushes.Black, 200, Y, derecha)
            e.Graphics.DrawString(simbolo & " " & FormatNumber(totaleliminar, 2), fuente_p, Brushes.Black, 270, Y, derecha)
            Y += 13

            articulos = articulos + cantidadeliminar

            e.Graphics.DrawString("---------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 10
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 20

            e.Graphics.DrawString("TOTAL A PAGAR: " & "0.00", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            If Mid(pie, 1, 32) <> "" Then
                e.Graphics.DrawString(Mid(pie, 1, 32), fuente_r, Brushes.Black, 90, Y)
                Y += 15
            End If

            e.Graphics.DrawString("Cajero: " & lblUsuario.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Mesero: " & lblMesero.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 20

            e.HasMorePages = False
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub PCortesia58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCortesia58.PrintPage

        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
            Dim fuente_a As New Font("Lucida Sans Typewriter", 10, FontStyle.Bold)

            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            Dim Logotipo As Drawing.Image = Nothing
            Dim nLogo As String = DatosRecarga("LogoG")
            Dim tLogo As String = DatosRecarga("TipoLogo")
            Dim simbolo As String = DatosRecarga("Simbolo")

            Dim pie As String = ""
            Dim articulos As Double = 0

            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 80)
                    Y += 90
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
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
                    pie = rd2("Pie1").ToString
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
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd2.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("C O R T E S I A", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            If cboMesa.Text = "" Then
                e.Graphics.DrawString("Comanda: " & cboComanda.Text, fuente_r, Brushes.Black, 1, Y)
            Else
                e.Graphics.DrawString("Mesa: " & cboMesa.Text, fuente_r, Brushes.Black, 1, Y)
            End If

            e.Graphics.DrawString("Folio: " & folioventa, fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 23
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 133, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20


            e.Graphics.DrawString(FormatNumber(cantidadeliminar, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

            Dim caracteresPorLinea As Integer = 27
            Dim texto As String = descripcioneliminar
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 30, Y)
                Y += 13
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString(simbolo & " " & precioeliminar, fuente_p, Brushes.Black, 130, Y, derecha)
            e.Graphics.DrawString(simbolo & " " & FormatNumber(totaleliminar, 2), fuente_p, Brushes.Black, 180, Y, derecha)
            Y += 13

            articulos = articulos + cantidadeliminar

            e.Graphics.DrawString("---------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 10
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 20

            e.Graphics.DrawString("TOTAL A PAGAR: " & "0.00", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            If Mid(pie, 1, 32) <> "" Then
                e.Graphics.DrawString(Mid(pie, 1, 32), fuente_r, Brushes.Black, 70, Y)
                Y += 15
            End If

            e.Graphics.DrawString("Cajero: " & lblUsuario.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Mesero: " & lblMesero.Text, fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 20

            e.HasMorePages = False
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub


End Class