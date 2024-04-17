Imports System.IO
Imports System.Net
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data

Public Class frmConsultaNotas

    Dim VaDe As String = ""
    Dim TipoVenta As Integer = 0

    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim PosicionSinEncabezado As Integer = 0
    Dim pagina As Integer = 0

    Dim donde_va As String = ""

    'variables para imprimir abonos
    Dim abonoa As Double = 0
    Dim formaa As String = ""
    Dim bancoa As String = ""
    Dim referenciaa As String = ""
    Private Sub Borra()
        cbonombre.Items.Clear()
        lblfechaventa.Text = ""
        lblhoraventa.Text = ""
        cbonombre.Text = ""
        txtdireccion.Text = ""
        txtvendedor.Text = ""
        cbofolio.Items.Clear()
        cbofolio.Text = ""
        '  txtfecha.Text = ""
        ' txthora.Text = ""
        grdcaptura.Rows.Clear()
        txtsubtotal.Text = "0.00"
        txtacuenta.Text = "0.00"
        txtdescuento.Text = "0.00"
        txtresta.Text = "0.00"
        txtvence.Text = "0.00"
        txttotal.Text = "0.00"
        txtefectivo.Text = "0.00"
        txtcambio.Text = "0.00"
        txtpagos.Text = "0.00"
        txtrestaabono.Text = "0.00"
        cbotipo.Items.Clear()
        cbotipo.Text = ""
        cbobanco.Items.Clear()
        cbobanco.Text = ""
        txtnumero.Text = ""
        txtmonto.Text = "0.00"
        dtpfecha.Value = Now
        grdpagos.Rows.Clear()
        grdAbonos.Rows.Clear()
        lblNumCliente.Text = ""
        ' lblusuario.Text = ""
        'txtusuario.Text = ""
        VaDe = ""
        VieneDe_Folios = ""
        boxpagos.Enabled = False
        donde_va = ""
    End Sub

    Private Sub cbofolio_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofolio.DropDown
        cbofolio.Items.Clear()
        txtdireccion.Text = ""
        txtvendedor.Text = ""
        grdcaptura.Rows.Clear()
        grdAbonos.Rows.Clear()
        lblfechaventa.Text = ""
        lblhoraventa.Text = ""

        'txtfecha.Text = ""
        'txthora.Text = ""
        txtsubtotal.Text = "0.00"
        txttotal.Text = "0.00"
        txtvence.Text = ""
        txtacuenta.Text = "0.00"
        txtresta.Text = "0.00"
        txtdescuento.Text = "0.00"
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If (optnotas.Checked) Then
                If cbonombre.Text <> "" Then
                    cmd1.CommandText = "select Folio from Ventas where Status<>'CANCELADA' and Cliente='" & cbonombre.Text & "' order by Folio"
                Else
                    cmd1.CommandText = "select Folio from Ventas where Status<>'CANCELADA' order by Folio"
                End If
            End If
            If (optcobrar.Checked) Then
                If cbonombre.Text <> "" Then
                    cmd1.CommandText = "select Folio from Ventas where Status='RESTA' and Cliente='" & cbonombre.Text & "' order by Folio"
                Else
                    cmd1.CommandText = "select Folio from Ventas where Status='RESTA' order by Folio"
                End If
            End If

            If (optpagadas.Checked) Then
                cmd1.CommandText = "select Folio from Ventas where Status='PAGADO' order by Folio"
            End If

            If (optanceladas.Checked) Then
                cmd1.CommandText = "select Folio from Ventas where Status='CANCELADA' order by Folio"
            End If

            If (optcotiz.Checked) Then
                If cbonombre.Text <> "" Then
                    cmd1.CommandText = "select Folio from CotPed where Cliente='" & cbonombre.Text & "' and Tipo='COTIZACION' order by Folio"
                Else
                    cmd1.CommandText = "select Folio from CotPed where Tipo='COTIZACION' order by Folio"
                End If
            End If

            If (optPedidos.Checked) Then
                If cbonombre.Text <> "" Then
                    cmd1.CommandText = "SELECT Folio FROM pedidosven WHERE Cliente='" & cbonombre.Text & "' AND Tipo='PEDIDO' ORDER BY Folio"
                Else
                    cmd1.CommandText = "SELECT Folio FROM pedidosven WHERE Tipo='PEDIDO' ORDER BY Folio"
                End If
            End If

            If (optdevos.Checked) Then
                cmd1.CommandText = "select distinct Folio from Devoluciones where Facturado='DEVOLUCION' order by Folio"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbofolio.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Private Sub cbofolio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbofolio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cbofolio_SelectedValueChanged(cbofolio, New EventArgs())
            If (optcobrar.Checked) Then
                txtefectivo.Focus().Equals(True)
                Exit Sub
            End If
            If (optcotiz.Checked) Then
                btnVentas.Focus().Equals(True)
                Exit Sub
            End If
            btnCopia.Focus().Equals(True)
        End If
    End Sub
    Private Sub cbofolio_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbofolio.SelectedValueChanged
        Dim VarArch As String = ""
        Dim VarCliente As Integer = 0

        Dim MYFOLIO As Integer = IIf(cbofolio.Text = "", 0, cbofolio.Text)

        Dim codigo, nombre, unidad, comentario As String
        Dim cantidad, precio, total, descue As Double



        If cbofolio.Text <> "" Then
            grdcaptura.Rows.Clear()
            grdAbonos.Rows.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                If (optnotas.Checked) Then cmd1.CommandText = "select * from Ventas where Folio=" & MYFOLIO
                If (optcobrar.Checked) Then cmd1.CommandText = "select * from Ventas where Folio=" & MYFOLIO
                If (optpagadas.Checked) Then cmd1.CommandText = "select * from Ventas where Folio=" & MYFOLIO
                If (optanceladas.Checked) Then cmd1.CommandText = "select * from Ventas where Folio= " & MYFOLIO
                If (optcotiz.Checked) Then cmd1.CommandText = "select * from CotPed where Folio=" & MYFOLIO
                If (optPedidos.Checked) Then cmd1.CommandText = "SELECT * FROM pedidosven WHERE Folio=" & MYFOLIO
                If (optdevos.Checked) Then cmd1.CommandText = "select * from Ventas where Folio=" & MYFOLIO
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If (optcobrar.Checked) Then
                            If rd1("Status").ToString() = "PAGADO" Then MsgBox("Esta nota de venta ya fue pagada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : rd1.Close() : cnn1.Close() : Exit Sub
                            If rd1("Status").ToString() = "CANCELADA" Then MsgBox("Esta nota de venta fue cancelada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : rd1.Close() : cnn1.Close() : Exit Sub
                            If rd1("FPago").ToString() <> "" Then
                                txtvence.Text = FormatDateTime(rd1("FPago").ToString(), DateFormat.ShortDate)
                            End If
                        End If

                        VarCliente = IIf(rd1("IdCliente").ToString() = "", 0, rd1("IdCliente").ToString())

                        If VarCliente = 0 Then lblNumCliente.Text = "MOSTRADOR"
                        If VarCliente <> 0 Then lblNumCliente.Text = VarCliente

                        If (optcotiz.Checked) Or (optPedidos.Checked) Then
                            txtsubtotal.Text = FormatNumber(rd1("Totales").ToString(), 2)
                            cbonombre.Text = rd1("Cliente").ToString()
                            txtdescuento.Text = FormatNumber(IIf(rd1("Descuento").ToString() = "", 0, rd1("Descuento").ToString()), 2)
                            ' txtfecha.Text = FormatDateTime(rd1("Fecha").ToString(), DateFormat.ShortDate)
                            lblfechaventa.Text = FormatDateTime(rd1("Fecha").ToString(), DateFormat.ShortDate)
                            ' txthora.Text = FormatDateTime(rd1("Hora").ToString(), DateFormat.LongTime)
                            lblhoraventa.Text = FormatDateTime(rd1("Hora").ToString(), DateFormat.LongTime)
                        Else
                            txtsubtotal.Text = FormatNumber(IIf(rd1("MontoSinDesc").ToString() = "", "0", rd1("MontoSinDesc".ToString())), 2)
                            cbonombre.Text = rd1("Cliente").ToString()
                            txtdescuento.Text = FormatNumber(IIf(rd1("Descuento").ToString() = "", 0, rd1("Descuento").ToString()), 2)
                            'txtfecha.Text = FormatDateTime(rd1("FVenta").ToString(), DateFormat.ShortDate)
                            'txthora.Text = FormatDateTime(rd1("HVenta").ToString(), DateFormat.LongTime)
                            lblfechaventa.Text = FormatDateTime(rd1("FVenta").ToString(), DateFormat.ShortDate)
                            lblhoraventa.Text = FormatDateTime(rd1("HVenta").ToString(), DateFormat.LongTime)
                        End If



                        If Not (optcotiz.Checked) And Not (optdevos.Checked) And Not (optPedidos.Checked) Then
                            If CDbl(rd1("Devolucion").ToString()) > 0 Then
                                txtdescuento.Text = FormatNumber(CDbl(txtdescuento.Text) + CDbl(rd1("Devolucion").ToString()), 2)
                            End If
                        End If
                        txtdireccion.Text = rd1("Direccion").ToString()
                            txtvendedor.Text = rd1("Usuario").ToString()
                            txtacuenta.Text = FormatNumber(IIf(rd1("ACuenta").ToString() = "", 0, rd1("ACuenta").ToString()), 2)
                            txtresta.Text = FormatNumber(IIf(rd1("Resta").ToString() = "", 0, rd1("Resta").ToString()), 2)
                            txttotal.Text = FormatNumber(IIf(rd1("Totales").ToString() = "", 0, rd1("Totales").ToString()), 2)
                            If (optcobrar.Checked) Then
                                txtrestaabono.Text = FormatNumber(IIf(rd1("Resta").ToString() = "", 0, rd1("Resta").ToString()), 2)
                            End If
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            If (optpagadas.Checked) Or (optnotas.Checked) Or (optcobrar.Checked) Or (optanceladas.Checked) Then cmd2.CommandText = "select * from VentasDetalle where Folio=" & MYFOLIO
                        If (optcotiz.Checked) Then cmd2.CommandText = "select * from CotPedDet where Folio=" & MYFOLIO
                        If (optPedidos.Checked) Then cmd2.CommandText = "SELECT * FROM pedidosvendet WHERE Folio=" & MYFOLIO
                        If (optdevos.Checked) Then cmd2.CommandText = "select * from Devoluciones where Folio=" & MYFOLIO
                            rd2 = cmd2.ExecuteReader
                            Do While rd2.Read
                                If rd2.HasRows Then
                                    codigo = rd2("Codigo").ToString()
                                    nombre = rd2("Nombre").ToString()
                                    If (optdevos.Checked) Then
                                        unidad = rd2("UVenta").ToString()
                                        comentario = ""
                                        descue = 0
                                    Else
                                    If (optpagadas.Checked) Or (optnotas.Checked) Or (optcobrar.Checked) Or (optanceladas.Checked) Or (optcotiz.Checked) Or (optPedidos.Checked) Then
                                        descue = rd2("Descuento").ToString()
                                        unidad = rd2("Unidad").ToString()
                                    Else
                                        unidad = rd2("Unidad").ToString()
                                            comentario = rd2("CostVR").ToString()
                                            descue = 0
                                        End If
                                    End If
                                    cantidad = rd2("Cantidad").ToString()
                                    precio = rd2("Precio").ToString()
                                    total = rd2("Total").ToString()

                                    grdcaptura.Rows.Add(codigo, nombre, unidad, cantidad, FormatNumber(precio, 4), FormatNumber(total, 4), "0")
                                    If comentario <> "" Then
                                        grdcaptura.Rows.Add("", comentario, "", "", "", "")
                                    End If
                                End If
                            Loop
                            rd2.Close() : cnn2.Close()
                            For t As Integer = 0 To grdcaptura.Rows.Count - 1
                                If CStr(grdcaptura.Rows(t).Cells(0).Value.ToString) = "" Then
                                    grdcaptura.Rows(t).DefaultCellStyle.ForeColor = Color.DarkOrange
                                    grdcaptura.Rows(t).DefaultCellStyle.SelectionBackColor = Color.Pink
                                    grdcaptura.Rows(t).DefaultCellStyle.SelectionForeColor = Color.Black
                                End If
                            Next
                        End If
                    End If
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                'cmd1.CommandText = "SELECT Fecha,Hora,Abono,Efectivo,Tarjeta,Transfe,Monedero,Otro,Banco,Referencia,Comentario,Usuario FROM AbonoI WHERE NumFolio='" & cbofolio.Text & "' AND Concepto='ABONO'"
                cmd1.CommandText = "SELECT Fecha,Hora,Abono,FormaPago,Banco,Referencia,Comentario,CuentaC,BRecepcion,Usuario FROM AbonoI WHERE NumFolio='" & cbofolio.Text & "' AND Concepto='ABONO'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        Dim fecha As Date = Nothing
                        fecha = rd1(0).ToString


                        grdAbonos.Rows.Add(Format(fecha, "yyyy-MM-dd"),
                                           rd1(1).ToString,
                                           rd1(2).ToString,
                                           rd1(3).ToString,
                                           rd1(4).ToString,
                                           rd1(5).ToString,
                                           rd1(6).ToString,
                                           rd1(9).ToString,
                                           rd1(7).ToString,
                                           rd1(8).ToString)


                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
                cnn2.Close()
            End Try
        End If
    End Sub


    Private Sub frmConsultaNotas_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        optnotas.Checked = True
        optnotas.PerformClick()
    End Sub
    Private Sub frmConsultaNotas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        optnotas.Checked = True
        VaDe = ""
        donde_va = ""
        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TomaContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                tomacontralog = rd1(0).ToString

                If tomacontralog = "1" Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Clave,Alias FROM Usuarios WHERE IdEmpleado=" & id_usu_log
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtusuario.Text = rd2(0).ToString
                            lblusuario.Text = rd2(1).ToString
                            txtusuario.PasswordChar = "*"
                            'txtusuario.ForeColor = Color.Black
                        End If
                    End If
                    rd2.Close()
                End If
            End If
        End If
        rd1.Close()
        cnn1.Close()
        cnn2.Close()
    End Sub


    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbofolio.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdireccion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles cbotipo.DropDown
        cbotipo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct FormaPago from FormasPago where FormaPago<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbotipo.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbotipo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus().Equals(True)
        End If
    End Sub

    Private Sub ComboBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpfecha.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If (optnotas.Checked) Then cmd1.CommandText = "select distinct Cliente from Ventas where Status<>'CANCELADA' AND Cliente<>''"
            If (optcobrar.Checked) Then cmd1.CommandText = "select distinct Cliente from Ventas where Status='RESTA' AND Cliente<>''"
            If (optpagadas.Checked) Then cmd1.CommandText = "select distinct Cliente from Ventas where Status='PAGADO' AND Cliente<>''"
            If (optanceladas.Checked) Then cmd1.CommandText = "select distinct Cliente from Ventas where Status='CANCELADA' AND Cliente<>''"
            If (optcotiz.Checked) Then cmd1.CommandText = "select distinct Cliente from CotPed where Tipo='COTIZACION' AND Cliente<>''"
            If (optPedidos.Checked) Then cmd1.CommandText = "SELECT DISTINCT Cliente FROM cotped WHERE Tipo='PEDIDO' AND Cliente<>''"

            If (optdevos.Checked) Then rd1.Close() : cnn1.Close() : Exit Sub

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub


    Private Sub optnotas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optnotas.CheckedChanged
        If (optnotas.Checked) Then

            grdAbonos.Rows.Clear()
            Borra()
            cbonombre.Items.Clear()
            cbonombre.Text = ""

            cbofolio.Items.Clear()
            btnCancela.Visible = True
            btnAbono.Visible = False
            btnCopia.Visible = True
            btnVentas.Visible = True
            boxpagos.Enabled = False
            cboCunetaRep.Text = ""
            txtBancoRep.Text = ""
            txtefectivo.Enabled = False

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select distinct Cliente from Ventas where Status<>'CANCELADA'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            btnCopia.Visible = True
            lblNumCliente.Text = "MOSTRADOR"
        End If
    End Sub
    Private Sub optcobrar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optcobrar.CheckedChanged
        If (optcobrar.Checked) Then
            grdAbonos.Rows.Clear()
            Borra()
            cbonombre.Items.Clear()
            cbonombre.Text = ""

            cbofolio.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select distinct Cliente from Ventas where Status='RESTA'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            txtefectivo.Text = "0.00"
            btnAbono.Visible = True
            btnVentas.Visible = True
            btnCancela.Visible = False
            boxpagos.Enabled = True
            txtefectivo.Enabled = True

            btnCopia.Visible = True
            lblNumCliente.Text = "MOSTRADOR"
            cbotipo.Text = ""
            cbobanco.Text = ""
            txtnumero.Text = ""
            txtmonto.Text = "0.00"
            grdpagos.Rows.Clear()
            txtcambio.Text = "0.00"
            cboCunetaRep.Text = ""
            txtBancoRep.Text = ""
        End If
    End Sub
    Public Sub otropago()
        txtefectivo.Text = "0.00"
        btnAbono.Visible = True
        btnVentas.Visible = True
        btnCancela.Visible = False
        boxpagos.Enabled = True
        txtefectivo.Enabled = True

        btnCopia.Visible = True
        lblNumCliente.Text = "MOSTRADOR"
        cbotipo.Text = ""
        cbobanco.Text = ""
        txtnumero.Text = ""
        txtmonto.Text = "0.00"
        grdpagos.Rows.Clear()
        txtcambio.Text = "0.00"
        cboCunetaRep.Text = ""
        txtBancoRep.Text = ""
    End Sub
    Private Sub optpagadas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optpagadas.CheckedChanged
        If (optpagadas.Checked) Then
            grdAbonos.Rows.Clear()
            Borra()
            cbonombre.Items.Clear()
            cbonombre.Text = ""

            cbofolio.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select distinct Cliente from Ventas where Status='PAGADO'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            txtefectivo.Text = "0.00"
            txtefectivo.Enabled = False
            btnCopia.Visible = True
            btnCancela.Visible = True
            btnAbono.Visible = False
            boxpagos.Enabled = False
            btnVentas.Visible = True
            lblNumCliente.Text = "MOSTRADOR"
        End If
    End Sub
    Private Sub optanceladas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optanceladas.CheckedChanged
        If (optanceladas.Checked) Then
            grdAbonos.Rows.Clear()
            Borra()
            cbonombre.Items.Clear()
            cbonombre.Text = ""

            cbofolio.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select distinct Cliente from Ventas where Status='CANCELADA'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            btnCopia.Visible = False
            btnCancela.Visible = False
            btnAbono.Visible = False
            btnVentas.Visible = False
            txtefectivo.Enabled = False
            txtefectivo.Text = "0.00"
            lblNumCliente.Text = "MOSTRADOR"
            boxpagos.Enabled = False
        End If
    End Sub
    Private Sub optcotiz_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optcotiz.CheckedChanged
        If (optcotiz.Checked) Then
            grdAbonos.Rows.Clear()
            Borra()
            cbonombre.Items.Clear()
            cbonombre.Text = ""

            cbofolio.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select distinct Cliente from CotPed"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            btnCopia.Visible = True
            btnAbono.Visible = False
            btnCancela.Visible = False
            btnVentas.Visible = True
            lblNumCliente.Text = "MOSTRADOR"
            boxpagos.Enabled = False
            txtefectivo.Enabled = False
            txtefectivo.Text = "0.00"
        End If
    End Sub

    Private Sub optdevos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optdevos.CheckedChanged
        If (optdevos.Checked) Then
            grdAbonos.Rows.Clear()
            Borra()
            cbonombre.Items.Clear()
            cbonombre.Text = ""

            cbofolio.Items.Clear()

            btnCopia.Visible = True
            btnAbono.Visible = False
            btnCancela.Visible = False
            btnVentas.Visible = False
            lblNumCliente.Text = "MOSTRADOR"
            boxpagos.Enabled = False
            txtefectivo.Enabled = False
            txtefectivo.Text = "0.00"
        End If
    End Sub


    Private Sub cbonombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                 "select Id from Clientes where Nombre='" & cbonombre.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    lblNumCliente.Text = IIf(rd2(0).ToString() = "", "MOSTRADOR", rd2(0).ToString())
                End If
            End If
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub btnVentas_Click(sender As System.Object, e As System.EventArgs) Handles btnVentas.Click
        If cbofolio.Text = "" Then MsgBox("Selecciona un folio para poder exportarlo a la pantalla de ventas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofolio.Focus().Equals(True) : Exit Sub

        Dim tipo_venta As String = ""
        Dim partes As Integer = 0
        Dim series As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Partes'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    partes = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Series'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    series = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If partes = 1 Then
                tipo_venta = "frmVentas1_Partes"
            ElseIf series = 1 Then
                tipo_venta = "frmVentas_Series"
            Else
                tipo_venta = "frmVentas1"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Dim VarCodigo As String = ""

        'If VieneDe_Folios = "" Then VieneDe_Folios = "frmVentas1"
        If VieneDe_Folios = "" Then VieneDe_Folios = tipo_venta

        If tipo_venta = "frmVentas1" Then
            'Ventas1
            If VieneDe_Folios = "frmVentas1" Then
                With frmVentas1
                    .Show()

                    .btnnuevo.PerformClick()
                    cnn1.Close() : cnn1.Open()
                    For ctm As Integer = 0 To grdcaptura.Rows.Count - 1
                        VarCodigo = grdcaptura.Rows(ctm).Cells(0).Value.ToString()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select * from Productos where Codigo='" & grdcaptura.Rows(ctm).Cells(0).Value.ToString() & "'"
                        rd1 = cmd1.ExecuteReader
                        If grdcaptura.Rows.Count < 0 Then
                            MsgBox("Hay productos que ya fueron dados de baja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            Exit Sub
                        End If
                        If Not rd1.HasRows And grdcaptura.Rows.Count > 1 Then
                            grdcaptura.Rows.Remove(grdcaptura.Rows(ctm))
                        End If
                        rd1.Close()
                    Next
                    cnn1.Close()

                    Dim VarMul As Integer = 0
                    Dim VarCode As String = ""
                    Dim VarConeto As Double = 0
                    Dim existencia As Double = 0
                    Dim descuentoiva As Double = 0
                    Dim total1 As Double = 0

                    .grdcaptura.Rows.Clear()
                    .cboNombre.Text = cbonombre.Text
                    .cboNombre_KeyPress(.cboNombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
                    .txtdireccion.Text = txtdireccion.Text

                    cnn1.Close() : cnn1.Open()
                    For degm As Integer = 0 To grdcaptura.Rows.Count - 1
                        .grdcaptura.Rows.Add()
                        'Codigo
                        .grdcaptura(0, degm).Value = grdcaptura(0, degm).Value.ToString()
                        VarCode = grdcaptura(0, degm).Value.ToString()
                        'Nombre
                        .grdcaptura(1, degm).Value = grdcaptura(1, degm).Value.ToString()
                        'Unidad
                        .grdcaptura(2, degm).Value = grdcaptura(2, degm).Value.ToString()
                        'Cantidad
                        .grdcaptura(3, degm).Value = grdcaptura(3, degm).Value.ToString()
                        VarConeto = VarConeto + CDbl(grdcaptura(3, degm).Value.ToString())
                        'Precio
                        .grdcaptura(4, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 4)
                        'Total
                        .grdcaptura(5, degm).Value = FormatNumber(grdcaptura(5, degm).Value.ToString(), 4)
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select * from Productos where Codigo='" & VarCode & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                VarMul = rd1("Multiplo").ToString()
                            End If
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select * from Productos where Codigo='" & Strings.Left(VarCode, 6) & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                If rd1("Existencia").ToString() = 0 Then
                                    .grdcaptura(6, degm).Value = 0
                                Else
                                    .grdcaptura(6, degm).Value = CDbl(rd1("Existencia").ToString()) / VarMul
                                End If
                            End If
                        End If
                        rd1.Close()
                        'Lote
                        '.grdcaptura(7, degm).Value = 0
                        .grdcaptura(7, degm).Value = 0
                        .grdcaptura(8, degm).Value = ""
                        .grdcaptura(9, degm).Value = ""
                        'IVAS
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select IVA from Productos where Codigo='" & VarCode & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                If rd1(0).ToString() = 0 Then
                                    descuentoiva = grdcaptura(5, degm).Value.ToString()
                                    total1 = 0
                                Else
                                    descuentoiva = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
                                    total1 = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
                                End If
                            End If
                        Else
                            descuentoiva = grdcaptura(5, degm).Value.ToString()
                            total1 = 0
                        End If
                        rd1.Close()
                        .grdcaptura(10, degm).Value = 0
                        .grdcaptura(11, degm).Value = 0
                        .grdcaptura(12, degm).Value = descuentoiva
                        .grdcaptura(13, degm).Value = total1
                        .grdcaptura(14, degm).Value = 0
                    Next
                    cnn1.Close()

                    .txtSubTotal.Text = FormatNumber(txtsubtotal.Text, 2)
                    .txtdescuento2.Text = FormatNumber(txtdescuento.Text, 2)
                    .txtdescuento1.Text = FormatNumber(((CDbl(txtdescuento.Text) * 100) / CDbl(txtsubtotal.Text)), 2)
                    .txtPagar.Text = FormatNumber(txttotal.Text, 2)
                    .txtResta.Text = FormatNumber(txttotal.Text)

                    .txtcotped.Text = ""
                    If (optcotiz.Checked) Then
                        .txtcotped.Text = cbofolio.Text
                    End If

                    .lblpedido.Text = ""
                    If (optPedidos.Checked) Then
                        .lblpedido.Text = cbofolio.Text
                    End If

                End With
            End If
        End If

        If tipo_venta = "frmVentas1_Partes" Then
            If VieneDe_Folios = "frmVentas1_Partes" Then
                With frmVentas1_Partes
                    .Show()
                    .btnnuevo.PerformClick()
                    cnn1.Close() : cnn1.Open()
                    For ctm As Integer = 0 To grdcaptura.Rows.Count - 1
                        VarCodigo = grdcaptura.Rows(ctm).Cells(0).Value.ToString()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select * from Productos where Codigo='" & grdcaptura.Rows(ctm).Cells(0).Value.ToString() & "'"
                        rd1 = cmd1.ExecuteReader
                        If grdcaptura.Rows.Count < 0 Then
                            MsgBox("Hay productos que ya fueron dados de baja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            Exit Sub
                        End If
                        If Not rd1.HasRows And grdcaptura.Rows.Count > 1 Then
                            grdcaptura.Rows.Remove(grdcaptura.Rows(ctm))
                        End If
                        rd1.Close()
                    Next
                    cnn1.Close()

                    Dim VarMul As Integer = 0
                    Dim VarCode As String = ""
                    Dim VarConeto As Double = 0
                    Dim existencia As Double = 0
                    Dim descuentoiva As Double = 0
                    Dim total1 As Double = 0

                    .grdcaptura.Rows.Clear()
                    .cboNombre.Text = cbonombre.Text
                    .cboNombre_KeyPress(.cboNombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
                    .txtdireccion.Text = txtdireccion.Text

                    cnn1.Close() : cnn1.Open()
                    For degm As Integer = 0 To grdcaptura.Rows.Count - 1
                        .grdcaptura.Rows.Add()
                        'Codigo
                        .grdcaptura(0, degm).Value = grdcaptura(0, degm).Value.ToString()
                        VarCode = grdcaptura(0, degm).Value.ToString()
                        'Nombre
                        .grdcaptura(1, degm).Value = grdcaptura(1, degm).Value.ToString()
                        'Unidad
                        .grdcaptura(2, degm).Value = grdcaptura(2, degm).Value.ToString()
                        'Cantidad
                        .grdcaptura(3, degm).Value = grdcaptura(3, degm).Value.ToString()
                        VarConeto = VarConeto + CDbl(grdcaptura(3, degm).Value.ToString())
                        'Precio
                        .grdcaptura(4, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 4)
                        'Total
                        .grdcaptura(5, degm).Value = FormatNumber(grdcaptura(5, degm).Value.ToString(), 4)
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select * from Productos where Codigo='" & VarCode & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                VarMul = rd1("Multiplo").ToString()
                            End If
                        End If
                        rd1.Close()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select * from Productos where Codigo='" & Strings.Left(VarCode, 6) & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                If rd1("Existencia").ToString() = 0 Then
                                    .grdcaptura(6, degm).Value = 0
                                Else
                                    .grdcaptura(6, degm).Value = CDbl(rd1("Existencia").ToString()) / VarMul
                                End If
                            End If
                        End If
                        rd1.Close()
                        'Lote
                        '.grdcaptura(7, degm).Value = 0
                        .grdcaptura(7, degm).Value = 0
                        .grdcaptura(8, degm).Value = ""
                        .grdcaptura(9, degm).Value = ""
                        'IVAS
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                             "select IVA from Productos where Codigo='" & VarCode & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                If rd1(0).ToString() = 0 Then
                                    descuentoiva = grdcaptura(5, degm).Value.ToString()
                                    total1 = 0
                                Else
                                    descuentoiva = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
                                    total1 = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
                                End If
                            End If
                        Else
                            descuentoiva = grdcaptura(5, degm).Value.ToString()
                            total1 = 0
                        End If
                        rd1.Close()
                        .grdcaptura(10, degm).Value = 0
                        .grdcaptura(11, degm).Value = 0
                        .grdcaptura(12, degm).Value = descuentoiva
                        .grdcaptura(13, degm).Value = total1
                        .grdcaptura(14, degm).Value = 0
                    Next
                    cnn1.Close()

                    .txtSubTotal.Text = FormatNumber(txtsubtotal.Text, 2)
                    .txtdescuento2.Text = FormatNumber(txtdescuento.Text, 2)
                    .txtdescuento1.Text = FormatNumber(((CDbl(txtdescuento.Text) * 100) / CDbl(txtsubtotal.Text)), 2)
                    .txtPagar.Text = FormatNumber(txttotal.Text, 2)
                    .txtResta.Text = FormatNumber(txttotal.Text)

                    .txtcotped.Text = ""
                    If (optcotiz.Checked) Then
                        .txtcotped.Text = cbofolio.Text
                    End If

                    .lblpedido.Text = ""
                    If (optPedidos.Checked) Then
                        .lblpedido.Text = cbofolio.Text
                    End If
                End With

            End If
        End If

        'Ventas 2
        'If VieneDe_Folios = "frmVentas2" Then
        '    With frmVentas2
        '        .Show()
        '        .btnnuevo.PerformClick()
        '        cnn1.Close() : cnn1.Open()
        '        For ctm As Integer = 0 To grdcaptura.Rows.Count - 1
        '            VarCodigo = grdcaptura.Rows(ctm).Cells(0).Value.ToString()
        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select * from Productos where Codigo='" & grdcaptura.Rows(ctm).Cells(0).Value.ToString() & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If grdcaptura.Rows.Count < 0 Then
        '                MsgBox("Hay productos que ya fueron dados de baja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '                Exit Sub
        '            End If
        '            If Not rd1.HasRows And grdcaptura.Rows.Count > 1 Then
        '                grdcaptura.Rows.Remove(grdcaptura.Rows(ctm))
        '            End If
        '            rd1.Close()
        '        Next
        '        cnn1.Close()

        '        Dim VarMul As Integer = 0
        '        Dim VarCode As String = ""
        '        Dim VarConeto As Double = 0
        '        Dim existencia As Double = 0
        '        Dim descuentoiva As Double = 0
        '        Dim total1 As Double = 0

        '        .grdcaptura.Rows.Clear()
        '        .cboNombre.Text = cbonombre.Text
        '        .cboNombre_KeyPress(.cboNombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
        '        .txtdireccion.Text = txtdireccion.Text
        '        cnn1.Close() : cnn1.Open()
        '        For degm As Integer = 0 To grdcaptura.Rows.Count - 1
        '            .grdcaptura.Rows.Add()
        '            'Codigo
        '            .grdcaptura(0, degm).Value = grdcaptura(0, degm).Value.ToString()
        '            VarCode = grdcaptura(0, degm).Value.ToString()
        '            'Nombre
        '            .grdcaptura(1, degm).Value = grdcaptura(1, degm).Value.ToString()
        '            'Unidad
        '            .grdcaptura(2, degm).Value = grdcaptura(2, degm).Value.ToString()
        '            'Cantidad
        '            .grdcaptura(3, degm).Value = grdcaptura(3, degm).Value.ToString()
        '            VarConeto = VarCode + CDbl(grdcaptura(3, degm).Value.ToString())
        '            'Precio
        '            .grdcaptura(4, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 4)
        '            'Total
        '            .grdcaptura(5, degm).Value = FormatNumber(grdcaptura(5, degm).Value.ToString(), 4)
        '            'Existencia
        '            .grdcaptura(6, degm).Value = FormatNumber(grdcaptura(6, degm).Value.ToString(), 4)
        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select * from Productos where Codigo='" & VarCode & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If rd1.HasRows Then
        '                If rd1.Read Then
        '                    VarMul = rd1("Multiplo").ToString()
        '                End If
        '            End If
        '            rd1.Close()

        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select * from Productos where Codigo='" & Strings.Left(VarCode, 6) & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If rd1.HasRows Then
        '                If rd1.Read Then
        '                    If rd1("Existencia").ToString() = 0 Then
        '                        .grdcaptura(7, degm).Value = 0
        '                    Else
        '                        .grdcaptura(7, degm).Value = CDbl(rd1("Existencia").ToString()) / VarMul
        '                    End If
        '                End If
        '            End If
        '            rd1.Close()
        '            'Lote
        '            '.grdcaptura(7, degm).Value = 0
        '            .grdcaptura(8, degm).Value = 0
        '            .grdcaptura(9, degm).Value = 0
        '            'IVAS
        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select IVA from Productos where Codigo='" & VarCode & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If rd1.HasRows Then
        '                If rd1.Read Then
        '                    If rd1(0).ToString() = 0 Then
        '                        descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                        total1 = 0
        '                    Else
        '                        descuentoiva = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
        '                        total1 = FormatNumber((CDbl(grdcaptura(6, degm).Value.ToString()) / 1.16), 2)
        '                    End If
        '                End If
        '            Else
        '                descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                total1 = 0
        '            End If
        '            rd1.Close()
        '            .grdcaptura(10, degm).Value = descuentoiva
        '            .grdcaptura(11, degm).Value = total1
        '            .grdcaptura(12, degm).Value = 0
        '            .grdcaptura(13, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '            '.grdcaptura(14, degm).Value = 0
        '        Next
        '        cnn1.Close()

        '        .txtSubTotal.Text = FormatNumber(txtsubtotal.Text, 2)
        '        .txtdescuento2.Text = FormatNumber(txtdescuento.Text, 2)
        '        .txtdescuento1.Text = FormatNumber(((CDbl(txtdescuento.Text) * 100) / CDbl(txtsubtotal.Text)), 2)
        '        .txtPagar.Text = FormatNumber(txttotal.Text, 2)
        '        .txtResta.Text = FormatNumber(txttotal.Text)
        '        .txtcotped.Text = cbofolio.Text
        '    End With
        'End If

        'Ventas 3
        'If VieneDe_Folios = "frmVentas3" Then
        '    With frmVentas3
        '        .Show()
        '        .btnnuevo.PerformClick()
        '        cnn1.Close() : cnn1.Open()
        '        For ctm As Integer = 0 To grdcaptura.Rows.Count - 1
        '            VarCodigo = grdcaptura.Rows(ctm).Cells(0).Value.ToString()
        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select * from Productos where Codigo='" & grdcaptura.Rows(ctm).Cells(0).Value.ToString() & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If grdcaptura.Rows.Count < 0 Then
        '                MsgBox("Hay productos que ya fueron dados de baja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '                Exit Sub
        '            End If
        '            If Not rd1.HasRows And grdcaptura.Rows.Count > 1 Then
        '                grdcaptura.Rows.Remove(grdcaptura.Rows(ctm))
        '            End If
        '            rd1.Close()
        '        Next
        '        cnn1.Close()

        '        Dim VarMul As Integer = 0
        '        Dim VarCode As String = ""
        '        Dim VarConeto As Double = 0
        '        Dim existencia As Double = 0
        '        Dim descuentoiva As Double = 0
        '        Dim total1 As Double = 0

        '        .grdcaptura.Rows.Clear()
        '        .cboNombre.Text = cbonombre.Text
        '        .cboNombre_KeyPress(.cboNombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
        '        .txtdireccion.Text = txtdireccion.Text
        '        cnn1.Close() : cnn1.Open()
        '        For degm As Integer = 0 To grdcaptura.Rows.Count - 1
        '            .grdcaptura.Rows.Add()
        '            Codigo
        '            .grdcaptura(0, degm).Value = grdcaptura(0, degm).Value.ToString()
        '            VarCode = grdcaptura(0, degm).Value.ToString()
        '            Nombre
        '            .grdcaptura(1, degm).Value = grdcaptura(1, degm).Value.ToString()
        '            Unidad
        '            .grdcaptura(2, degm).Value = grdcaptura(2, degm).Value.ToString()
        '            Cantidad
        '            .grdcaptura(3, degm).Value = grdcaptura(3, degm).Value.ToString()
        '            VarConeto = VarCode + CDbl(grdcaptura(3, degm).Value.ToString())
        '            Precio
        '            .grdcaptura(4, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '            Total
        '            .grdcaptura(5, degm).Value = FormatNumber(grdcaptura(5, degm).Value.ToString(), 2)
        '            existencia
        '            .grdcaptura(6, degm).Value = FormatNumber(grdcaptura(6, degm).Value.ToString(), 2)
        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select * from Productos where Codigo='" & VarCode & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If rd1.HasRows Then
        '                If rd1.Read Then
        '                    VarMul = rd1("Multiplo").ToString()
        '                End If
        '            End If
        '            rd1.Close()

        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select * from Productos where Codigo='" & Strings.Left(VarCode, 6) & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If rd1.HasRows Then
        '                If rd1.Read Then
        '                    If rd1("Existencia").ToString() = 0 Then
        '                        .grdcaptura(7, degm).Value = 0
        '                    Else
        '                        .grdcaptura(7, degm).Value = CDbl(rd1("Existencia").ToString()) / VarMul
        '                    End If
        '                End If
        '            End If
        '            rd1.Close()
        '            Lote
        '            .grdcaptura(7, degm).Value = 0
        '            .grdcaptura(8, degm).Value = 0
        '            .grdcaptura(9, degm).Value = 0
        '            IVAS
        '            cmd1 = cnn1.CreateCommand
        '            cmd1.CommandText =
        '                 "select IVA from Productos where Codigo='" & VarCode & "'"
        '            rd1 = cmd1.ExecuteReader
        '            If rd1.HasRows Then
        '                If rd1.Read Then
        '                    If rd1(0).ToString() = 0 Then
        '                        descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                        total1 = 0
        '                    Else
        '                        descuentoiva = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
        '                        total1 = FormatNumber((CDbl(grdcaptura(6, degm).Value.ToString()) / 1.16), 2)
        '                    End If
        '                End If
        '            Else
        '                descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                total1 = 0
        '            End If
        '            rd1.Close()
        '            .grdcaptura(10, degm).Value = descuentoiva
        '            .grdcaptura(11, degm).Value = total1
        '            .grdcaptura(12, degm).Value = 0
        '            .grdcaptura(13, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '            .grdcaptura(14, degm).Value = 0
        '        Next
        '        cnn1.Close()

        '        .txtSubTotal.Text = FormatNumber(txtsubtotal.Text, 2)
        '        .txtdescuento2.Text = FormatNumber(txtdescuento.Text, 2)
        '        .txtdescuento1.Text = FormatNumber(((CDbl(txtdescuento.Text) * 100) / CDbl(txtsubtotal.Text)), 2)
        '        .txtPagar.Text = FormatNumber(txttotal.Text, 2)
        '        .txtResta.Text = FormatNumber(txttotal.Text)
        '        .txtcotped.Text = cbofolio.Text
        '    End With
        'End If

        'If tipo_venta = "Partes" Then
        '    If VieneDe_Folios = "" Then VieneDe_Folios = "frmVentas1_Partes"

        'End If

        'If tipo_venta = "Descuentos" Then
        '    If VieneDe_Folios = "" Then VieneDe_Folios = "frmVentas1_Descuentos"

        '    'Ventas1
        '    If VieneDe_Folios = "frmVentas1_Descuentos" Then
        '        With frmVentas1_Descuentos
        '            .Show()
        '            .btnnuevo.PerformClick()
        '            cnn1.Close() : cnn1.Open()
        '            For ctm As Integer = 0 To grdcaptura.Rows.Count - 1
        '                VarCodigo = grdcaptura.Rows(ctm).Cells(0).Value.ToString()
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & grdcaptura.Rows(ctm).Cells(0).Value.ToString() & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If grdcaptura.Rows.Count < 0 Then
        '                    MsgBox("Hay productos que ya fueron dados de baja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '                    Exit Sub
        '                End If
        '                If Not rd1.HasRows And grdcaptura.Rows.Count > 1 Then
        '                    grdcaptura.Rows.Remove(grdcaptura.Rows(ctm))
        '                End If
        '                rd1.Close()
        '            Next
        '            cnn1.Close()

        '            Dim VarMul As Integer = 0
        '            Dim VarCode As String = ""
        '            Dim VarConeto As Double = 0
        '            Dim existencia As Double = 0
        '            Dim descuentoiva As Double = 0
        '            Dim total1 As Double = 0

        '            .grdcaptura.Rows.Clear()
        '            .cboNombre.Text = cbonombre.Text
        '            .cboNombre_KeyPress(.cboNombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
        '            .txtdireccion.Text = txtdireccion.Text
        '            cnn1.Close() : cnn1.Open()
        '            For degm As Integer = 0 To grdcaptura.Rows.Count - 1
        '                .grdcaptura.Rows.Add()
        '                'Codigo
        '                .grdcaptura(0, degm).Value = grdcaptura(0, degm).Value.ToString()
        '                VarCode = grdcaptura(0, degm).Value.ToString()
        '                'Nombre
        '                .grdcaptura(1, degm).Value = grdcaptura(1, degm).Value.ToString()
        '                'Unidad
        '                .grdcaptura(2, degm).Value = grdcaptura(2, degm).Value.ToString()
        '                'Cantidad
        '                .grdcaptura(3, degm).Value = grdcaptura(3, degm).Value.ToString()
        '                VarConeto = VarConeto + CDbl(grdcaptura(3, degm).Value.ToString())
        '                'Precio
        '                .grdcaptura(4, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '                'Descuento
        '                .grdcaptura(5, degm).Value = FormatNumber(grdcaptura(5, degm).Value.ToString(), 2)
        '                'Total
        '                .grdcaptura(6, degm).Value = FormatNumber(grdcaptura(6, degm).Value.ToString(), 2)
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & VarCode & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        VarMul = rd1("Multiplo").ToString()
        '                    End If
        '                End If
        '                rd1.Close()

        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & Strings.Left(VarCode, 6) & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        If rd1("Existencia").ToString() = 0 Then
        '                            .grdcaptura(7, degm).Value = 0
        '                        Else
        '                            .grdcaptura(7, degm).Value = CDbl(rd1("Existencia").ToString()) / VarMul
        '                        End If
        '                    End If
        '                End If
        '                rd1.Close()
        '                'Lote
        '                '.grdcaptura(7, degm).Value = 0
        '                .grdcaptura(8, degm).Value = 0
        '                .grdcaptura(9, degm).Value = 0
        '                'IVAS
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select IVA from Productos where Codigo='" & VarCode & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        If rd1(0).ToString() = 0 Then
        '                            descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                            total1 = 0
        '                        Else
        '                            descuentoiva = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
        '                            total1 = FormatNumber((CDbl(grdcaptura(6, degm).Value.ToString()) / 1.16), 2)
        '                        End If
        '                    End If
        '                Else
        '                    descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                    total1 = 0
        '                End If
        '                rd1.Close()
        '                .grdcaptura(10, degm).Value = descuentoiva
        '                .grdcaptura(11, degm).Value = total1
        '                .grdcaptura(12, degm).Value = 0
        '                .grdcaptura(13, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '                '.grdcaptura(14, degm).Value = 0
        '            Next
        '            cnn1.Close()

        '            .txtSubTotal.Text = FormatNumber(txtsubtotal.Text, 2)
        '            .txtdescuento2.Text = FormatNumber(txtdescuento.Text, 2)
        '            If CDbl(.txtdescuento2.Text) <> 0 Then
        '                .txtdescuento1.Text = "0"
        '                .txtdescuento1.Enabled = False
        '            Else
        '                .txtdescuento1.Text = FormatNumber(((CDbl(txtdescuento.Text) * 100) / CDbl(txtsubtotal.Text)), 2)
        '            End If
        '            .txtPagar.Text = FormatNumber(txttotal.Text, 2)
        '            .txtResta.Text = FormatNumber(txttotal.Text)
        '            .txtcotped.Text = cbofolio.Text
        '        End With
        '    End If

        '    'Ventas2
        '    If VieneDe_Folios = "frmVentas2_Descuentos" Then
        '        With frmVentas2_Descuentos
        '            .Show()
        '            .btnnuevo.PerformClick()
        '            cnn1.Close() : cnn1.Open()
        '            For ctm As Integer = 0 To grdcaptura.Rows.Count - 1
        '                VarCodigo = grdcaptura.Rows(ctm).Cells(0).Value.ToString()
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & grdcaptura.Rows(ctm).Cells(0).Value.ToString() & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If grdcaptura.Rows.Count < 0 Then
        '                    MsgBox("Hay productos que ya fueron dados de baja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '                    Exit Sub
        '                End If
        '                If Not rd1.HasRows And grdcaptura.Rows.Count > 1 Then
        '                    grdcaptura.Rows.Remove(grdcaptura.Rows(ctm))
        '                End If
        '                rd1.Close()
        '            Next
        '            cnn1.Close()

        '            Dim VarMul As Integer = 0
        '            Dim VarCode As String = ""
        '            Dim VarConeto As Double = 0
        '            Dim existencia As Double = 0
        '            Dim descuentoiva As Double = 0
        '            Dim total1 As Double = 0

        '            .grdcaptura.Rows.Clear()
        '            .cboNombre.Text = cbonombre.Text
        '            .cboNombre_KeyPress(.cboNombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
        '            .txtdireccion.Text = txtdireccion.Text
        '            cnn1.Close() : cnn1.Open()
        '            For degm As Integer = 0 To grdcaptura.Rows.Count - 1
        '                .grdcaptura.Rows.Add()
        '                'Codigo
        '                .grdcaptura(0, degm).Value = grdcaptura(0, degm).Value.ToString()
        '                VarCode = grdcaptura(0, degm).Value.ToString()
        '                'Nombre
        '                .grdcaptura(1, degm).Value = grdcaptura(1, degm).Value.ToString()
        '                'Unidad
        '                .grdcaptura(2, degm).Value = grdcaptura(2, degm).Value.ToString()
        '                'Cantidad
        '                .grdcaptura(3, degm).Value = grdcaptura(3, degm).Value.ToString()
        '                VarConeto = VarConeto + CDbl(grdcaptura(3, degm).Value.ToString())
        '                'Precio
        '                .grdcaptura(4, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '                'Descuento
        '                .grdcaptura(5, degm).Value = FormatNumber(grdcaptura(5, degm).Value.ToString(), 2)
        '                'Total
        '                .grdcaptura(6, degm).Value = FormatNumber(grdcaptura(6, degm).Value.ToString(), 2)
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & VarCode & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        VarMul = rd1("Multiplo").ToString()
        '                    End If
        '                End If
        '                rd1.Close()

        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & Strings.Left(VarCode, 6) & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        If rd1("Existencia").ToString() = 0 Then
        '                            .grdcaptura(7, degm).Value = 0
        '                        Else
        '                            .grdcaptura(7, degm).Value = CDbl(rd1("Existencia").ToString()) / VarMul
        '                        End If
        '                    End If
        '                End If
        '                rd1.Close()
        '                'Lote
        '                '.grdcaptura(7, degm).Value = 0
        '                .grdcaptura(8, degm).Value = 0
        '                .grdcaptura(9, degm).Value = 0
        '                'IVAS
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select IVA from Productos where Codigo='" & VarCode & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        If rd1(0).ToString() = 0 Then
        '                            descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                            total1 = 0
        '                        Else
        '                            descuentoiva = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
        '                            total1 = FormatNumber((CDbl(grdcaptura(6, degm).Value.ToString()) / 1.16), 2)
        '                        End If
        '                    End If
        '                Else
        '                    descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                    total1 = 0
        '                End If
        '                rd1.Close()
        '                .grdcaptura(10, degm).Value = descuentoiva
        '                .grdcaptura(11, degm).Value = total1
        '                .grdcaptura(12, degm).Value = 0
        '                .grdcaptura(13, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '                '.grdcaptura(14, degm).Value = 0
        '            Next
        '            cnn1.Close()

        '            .txtSubTotal.Text = FormatNumber(txtsubtotal.Text, 2)
        '            .txtdescuento2.Text = FormatNumber(txtdescuento.Text, 2)
        '            If CDbl(.txtdescuento2.Text) <> 0 Then
        '                .txtdescuento1.Text = "0"
        '                .txtdescuento1.Enabled = False
        '            Else
        '                .txtdescuento1.Text = FormatNumber(((CDbl(txtdescuento.Text) * 100) / CDbl(txtsubtotal.Text)), 2)
        '            End If
        '            .txtPagar.Text = FormatNumber(txttotal.Text, 2)
        '            .txtResta.Text = FormatNumber(txttotal.Text)
        '            .txtcotped.Text = cbofolio.Text
        '        End With
        '    End If

        '    'Ventas3    
        '    If VieneDe_Folios = "frmVentas3_Descuentos" Then
        '        With frmVentas3_Descuentos
        '            .Show()
        '            .btnnuevo.PerformClick()
        '            cnn1.Close() : cnn1.Open()
        '            For ctm As Integer = 0 To grdcaptura.Rows.Count - 1
        '                VarCodigo = grdcaptura.Rows(ctm).Cells(0).Value.ToString()
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & grdcaptura.Rows(ctm).Cells(0).Value.ToString() & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If grdcaptura.Rows.Count < 0 Then
        '                    MsgBox("Hay productos que ya fueron dados de baja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '                    Exit Sub
        '                End If
        '                If Not rd1.HasRows And grdcaptura.Rows.Count > 1 Then
        '                    grdcaptura.Rows.Remove(grdcaptura.Rows(ctm))
        '                End If
        '                rd1.Close()
        '            Next
        '            cnn1.Close()

        '            Dim VarMul As Integer = 0
        '            Dim VarCode As String = ""
        '            Dim VarConeto As Double = 0
        '            Dim existencia As Double = 0
        '            Dim descuentoiva As Double = 0
        '            Dim total1 As Double = 0

        '            .grdcaptura.Rows.Clear()
        '            .cboNombre.Text = cbonombre.Text
        '            .cboNombre_KeyPress(.cboNombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
        '            .txtdireccion.Text = txtdireccion.Text
        '            cnn1.Close() : cnn1.Open()
        '            For degm As Integer = 0 To grdcaptura.Rows.Count - 1
        '                .grdcaptura.Rows.Add()
        '                'Codigo
        '                .grdcaptura(0, degm).Value = grdcaptura(0, degm).Value.ToString()
        '                VarCode = grdcaptura(0, degm).Value.ToString()
        '                'Nombre
        '                .grdcaptura(1, degm).Value = grdcaptura(1, degm).Value.ToString()
        '                'Unidad
        '                .grdcaptura(2, degm).Value = grdcaptura(2, degm).Value.ToString()
        '                'Cantidad
        '                .grdcaptura(3, degm).Value = grdcaptura(3, degm).Value.ToString()
        '                VarConeto = VarConeto + CDbl(grdcaptura(3, degm).Value.ToString())
        '                'Precio
        '                .grdcaptura(4, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '                'Descuento
        '                .grdcaptura(5, degm).Value = FormatNumber(grdcaptura(5, degm).Value.ToString(), 2)
        '                'Total
        '                .grdcaptura(6, degm).Value = FormatNumber(grdcaptura(6, degm).Value.ToString(), 2)
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & VarCode & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        VarMul = rd1("Multiplo").ToString()
        '                    End If
        '                End If
        '                rd1.Close()

        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select * from Productos where Codigo='" & Strings.Left(VarCode, 6) & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        If rd1("Existencia").ToString() = 0 Then
        '                            .grdcaptura(7, degm).Value = 0
        '                        Else
        '                            .grdcaptura(7, degm).Value = CDbl(rd1("Existencia").ToString()) / VarMul
        '                        End If
        '                    End If
        '                End If
        '                rd1.Close()
        '                'Lote
        '                '.grdcaptura(7, degm).Value = 0
        '                .grdcaptura(8, degm).Value = 0
        '                .grdcaptura(9, degm).Value = 0
        '                'IVAS
        '                cmd1 = cnn1.CreateCommand
        '                cmd1.CommandText =
        '                     "select IVA from Productos where Codigo='" & VarCode & "'"
        '                rd1 = cmd1.ExecuteReader
        '                If rd1.HasRows Then
        '                    If rd1.Read Then
        '                        If rd1(0).ToString() = 0 Then
        '                            descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                            total1 = 0
        '                        Else
        '                            descuentoiva = FormatNumber((CDbl(grdcaptura(5, degm).Value.ToString()) / 1.16), 2)
        '                            total1 = FormatNumber((CDbl(grdcaptura(6, degm).Value.ToString()) / 1.16), 2)
        '                        End If
        '                    End If
        '                Else
        '                    descuentoiva = grdcaptura(5, degm).Value.ToString()
        '                    total1 = 0
        '                End If
        '                rd1.Close()
        '                .grdcaptura(10, degm).Value = descuentoiva
        '                .grdcaptura(11, degm).Value = total1
        '                .grdcaptura(12, degm).Value = 0
        '                .grdcaptura(13, degm).Value = FormatNumber(grdcaptura(4, degm).Value.ToString(), 2)
        '                '.grdcaptura(14, degm).Value = 0
        '            Next
        '            cnn1.Close()

        '            .txtSubTotal.Text = FormatNumber(txtsubtotal.Text, 2)
        '            .txtdescuento2.Text = FormatNumber(txtdescuento.Text, 2)
        '            If CDbl(.txtdescuento2.Text) <> 0 Then
        '                .txtdescuento1.Text = "0"
        '                .txtdescuento1.Enabled = False
        '            Else
        '                .txtdescuento1.Text = FormatNumber(((CDbl(txtdescuento.Text) * 100) / CDbl(txtsubtotal.Text)), 2)
        '            End If
        '            .txtPagar.Text = FormatNumber(txttotal.Text, 2)
        '            .txtResta.Text = FormatNumber(txttotal.Text)
        '            .txtcotped.Text = cbofolio.Text
        '        End With
        '    End If
        'End If
    End Sub

    Private Sub txtefectivo_Click(sender As System.Object, e As System.EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub


    Private Sub txtpagos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpagos.TextChanged
        If (optcobrar.Checked) Then
            If txtefectivo.Text = "" Then Exit Sub
            If txtpagos.Text = "" Then Exit Sub
            If txtresta.Text = "" Then Exit Sub
            If txtrestaabono.Text = "" Then Exit Sub
            If txtdescu.Text = "" Then Exit Sub

            Dim resta As Double = 0
            resta = (CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))) - CDbl(txtdescu.Text)
            If resta >= 0 Then
                txtrestaabono.Text = FormatNumber(resta, 2)
                txtcambio.Text = "0.00"
            Else
                txtrestaabono.Text = "0.00"
                txtcambio.Text = FormatNumber(Math.Abs(resta), 2)
            End If
        End If
    End Sub

    Private Sub cbobanco_DropDown(sender As System.Object, e As System.EventArgs) Handles cbobanco.DropDown
        cbobanco.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Banco from Bancos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbobanco.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub dtpfecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpfecha.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumero.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnumero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmonto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtmonto_Click(sender As System.Object, e As System.EventArgs) Handles txtmonto.Click
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub txtmonto_GotFocus(sender As Object, e As System.EventArgs) Handles txtmonto.GotFocus
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub txtmonto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If CDbl(txtmonto.Text) > CDbl(txtresta.Text) Then
                MsgBox("El abono no puede ser mayor al restante ya que no se regresará cambio ni se generará saldo a favor.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonto.SelectAll() : Exit Sub
            End If
            txtmonto.Text = FormatNumber(txtmonto.Text, 2)
            cboCunetaRep.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnPago_Click(sender As System.Object, e As System.EventArgs) Handles btnPago.Click
        If cbotipo.Text = "" Then MsgBox("Falta el tipo de pago", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbotipo.Focus().Equals(True) : Exit Sub
        If cbobanco.Text = "" Then MsgBox("Falta el banco", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbobanco.Focus().Equals(True) : Exit Sub
        If txtnumero.Text = "" Then MsgBox("Falta el numero de referencia", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtnumero.Focus().Equals(True) : Exit Sub
        If txtmonto.Text = "" Or CDbl(txtmonto.Text) = 0 Then MsgBox("Ingresa un monto válido", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonto.Focus().Equals(True) : Exit Sub

        grdpagos.Rows.Add(cbotipo.Text, cbobanco.Text, txtnumero.Text, FormatNumber(txtmonto.Text, 2), FormatDateTime(dtpfecha.Value, DateFormat.ShortDate), "", cboCunetaRep.Text, txtBancoRep.Text)

        cbotipo.Text = ""
        cbobanco.Text = ""
        dtpfecha.Value = Now
        txtnumero.Text = ""
        txtmonto.Text = "0.00"
        Dim total_pagos As Double = 0
        For t1 As Integer = 0 To grdpagos.Rows.Count - 1
            total_pagos = total_pagos + CDbl(grdpagos.Rows(t1).Cells(3).Value.ToString())
        Next
        txtpagos.Text = FormatNumber(total_pagos, 2)
        cbotipo.Focus().Equals(True)
    End Sub

    Private Sub txtefectivo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtefectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Text = FormatNumber(txtefectivo.Text, 2)
            btnAbono.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnAbono_Click(sender As System.Object, e As System.EventArgs) Handles btnAbono.Click
        If Not (optcobrar.Checked) And Not (optPedidos.Checked) Then MsgBox("No puedes abonar una nota que ya fue pagado o cancelada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofolio.Focus().Equals(True) : Exit Sub
        If cbofolio.Text = "" Then MsgBox("Selecciona un folio para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofolio.Focus().Equals(True) : Exit Sub
        If cbonombre.Text = "" Then MsgBox("Falta el nombre del cliente de la venta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Exit Sub

        Dim id_usuarioa As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Usuarios where Clave='" & txtusuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_usuarioa = rd1("IdEmpleado").ToString()
                End If
            Else
                MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                VaDe = "ABONO"
                txtusuario.SelectionStart = 0
                txtusuario.SelectionLength = Len(txtusuario.Text)
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Permisos where IdEmpleado=" & id_usuarioa
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Vent_Abo").ToString() = False Then
                        MsgBox("No cuentas con permiso para realizar abonos a notas de venta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtusuario.SelectAll()
                        Exit Sub
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try

            'Nota de venta pagada
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If (optPedidos.Checked) Then
                cmd1.CommandText =
                "select * from pedidosven where Folio=" & cbofolio.Text & " and Status='PAGADO' and Cliente='" & cbonombre.Text & "'"
            Else
                cmd1.CommandText =
                "select * from Ventas where Folio=" & cbofolio.Text & " and Status='PAGADO' and Cliente='" & cbonombre.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("La nota de venta " & cbofolio.Text & " ya fue pagada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cbofolio.Focus().Equals(True)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
            End If
            rd1.Close()

            'Nota de venta cancelada
            cmd1 = cnn1.CreateCommand
            If (optPedidos.Checked) Then
                cmd1.CommandText =
               "SELECT * from pedidosven where Folio=" & cbofolio.Text & " and Status='CANCELADA' and Cliente='" & cbonombre.Text & "'"
            Else
                cmd1.CommandText =
               "select * from Ventas where Folio=" & cbofolio.Text & " and Status='CANCELADA' and Cliente='" & cbonombre.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("La nota de venta " & cbofolio.Text & " fue cancelada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cbofolio.Focus().Equals(True)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
            End If
            rd1.Close()

            'Nota inexistente
            cmd1 = cnn1.CreateCommand
            If (optPedidos.Checked) Then
                cmd1.CommandText =
                "SELECT * FROM pedidosven WHERE Folio=" & cbofolio.Text & " AND Cliente='" & cbonombre.Text & "'"
            Else
                cmd1.CommandText =
                "select * from Ventas where Folio=" & cbofolio.Text & " and Cliente='" & cbonombre.Text & "'"
            End If

            rd1 = cmd1.ExecuteReader
            If Not rd1.HasRows Then
                MsgBox("La nota de venta " & cbofolio.Text & " no existe.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cbofolio.Focus().Equals(True)
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Dim MyPago As Double = 0
        Dim MySaldo As Double = 0

        Dim resta, acuenta, descuentos As Double
        MyPago = ((CDbl(txtefectivo.Text) + CDbl(txtpagos.Text)) - CDbl(txtcambio.Text)) + CDbl(txtdescu.Text)
        If MyPago <> 0 Then
        Else
            MsgBox("El abono tiene que ser mayor a 0", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        'Validación de datos
        If MyPago < 0 Then MsgBox("El pago no es válido. Corrobora la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub


        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If (optPedidos.Checked) Then
                cmd1.CommandText =
                "select Resta, ACuenta, Descuento from pedidosven where Folio=" & cbofolio.Text
            Else
                cmd1.CommandText =
                "select Resta, ACuenta, Descuento from Ventas where Folio=" & cbofolio.Text
            End If

            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Dim n_resta As Double = 0
                Dim n_acuenta As Double = 0
                Dim n_descu As Double = txtdescu.Text

                If rd1.Read Then
                    resta = rd1(0).ToString()
                    acuenta = rd1(1).ToString()
                    descuentos = rd1(2).ToString()

                    If MyPago < resta Then
                        n_resta = resta - MyPago
                        n_acuenta = acuenta + MyPago

                        'El pago es menor al restante
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand

                        If optPedidos.Checked Then
                            cmd2.CommandText =
                             "UPDATE pedidosven SET Resta=" & n_resta & ", ACuenta=" & n_acuenta & ", Descuento=" & n_descu & " WHERE Folio=" & cbofolio.Text
                        Else
                            cmd2.CommandText =
                             "update Ventas set Resta=" & n_resta & ", ACuenta=" & n_acuenta & ", Descuento=" & n_descu & " where Folio=" & cbofolio.Text
                        End If
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    Else
                        'El pago cubre el restante
                        n_acuenta = acuenta + MyPago
                        descuentos = descuentos + n_descu
                        'El pago es menor al restante
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        If optPedidos.Checked Then
                            cmd2.CommandText =
                        "UPDATE pedidosven set Resta=0, ACuenta=" & n_acuenta & ",Descuento=" & n_descu & ", Status='PAGADO' WHERE Folio=" & cbofolio.Text
                        Else
                            cmd2.CommandText =
                        "update Ventas set Resta=0, ACuenta=" & n_acuenta & ",Descuento=" & n_descu & ", Status='PAGADO' where Folio=" & cbofolio.Text
                        End If
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try


        'Configuración de pagos
        Dim efectivo As Double = 0
        Dim TotSaldo As Double = 0

        Try
            cnn1.Close() : cnn1.Open()

            Dim MyAcuent As Double = 0

            Dim BancoP As String = ""
            Dim MontoP As Double = 0
            Dim RefeP As String = ""
            Dim FechaP As String = ""
            Dim comentario As String = ""
            Dim cuentarep As String = ""
            Dim bancorep As String = ""

            MyAcuent = CDbl(txtpagos.Text) + (CDbl(txtefectivo.Text) - CDbl(txtcambio.Text))

            If MyAcuent > 0 Then
                efectivo = CDbl(txtefectivo.Text) - CDbl(txtcambio.Text)

                If lblNumCliente.Text <> "MOSTRADOR" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & cbonombre.Text & "')"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()) - MyAcuent
                        End If
                    Else
                        MySaldo = 0
                    End If
                    rd1.Close()
                Else
                    MySaldo = 0
                End If

                If efectivo > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF,Comentario,CuentaC,BRecepcion) values(" & cbofolio.Text & "," & IIf(lblNumCliente.Text = "MOSTRADOR", 0, lblNumCliente.Text) & ",'" & cbonombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & efectivo & "," & MySaldo & ",'EFECTIVO'," & efectivo & ",'','','" & lblusuario.Text & "',0,0,0,0,'','','')"
                    cmd1.ExecuteNonQuery()
                End If

                If grdpagos.Rows.Count > 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select distinct FormaPago from FormasPago where FormaPago<>''"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            Dim FormaP As String = rd1(0).ToString()

                            For T As Integer = 0 To grdpagos.Rows.Count - 1
                                If CStr(grdpagos.Rows(T).Cells(0).Value.ToString()) = FormaP Then
                                    MontoP = MontoP + CDbl(grdpagos.Rows(T).Cells(3).Value.ToString())
                                    BancoP = BancoP & " - " & grdpagos.Rows(T).Cells(1).Value.ToString()
                                    RefeP = RefeP & " " & grdpagos.Rows(T).Cells(2).Value.ToString()
                                    comentario = comentario & " " & grdpagos.Rows(T).Cells(5).Value.ToString()
                                    cuentarep = cuentarep & " " & grdpagos.Rows(T).Cells(6).Value.ToString()
                                    bancorep = bancorep & " " & grdpagos.Rows(T).Cells(7).Value.ToString()

                                End If
                            Next

                            If FormaP = "SALDO FAVOR" Then
                                If MontoP > 0 Then
                                    TotSaldo = MontoP
                                End If
                            End If

                            If MontoP > 0 Then
                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                     "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF,Comentario,CuentaC,BRecepcion) values(" & cbofolio.Text & "," & IIf(lblNumCliente.Text = "MOSTRADOR", 0, lblNumCliente.Text) & ",'" & cbonombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & MontoP & "," & MySaldo & ",'" & FormaP & "'," & MontoP & ",'" & BancoP & "','" & RefeP & "','" & lblusuario.Text & "',0,0,0,0,'" & comentario & "','" & cuentarep & "','" & bancorep & "')"
                                cmd2.ExecuteNonQuery()
                                cnn2.Close()

                                MontoP = 0
                            End If
                        End If
                    Loop
                    rd1.Close()
                End If
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        'Actualización de saldo a favor
        If TotSaldo > 0 Then

        End If


        Try
            cnn1.Close() : cnn1.Open()
            If grdpagos.Rows.Count > 0 Then
                For T As Integer = 0 To grdpagos.Rows.Count - 1
                    Dim FormaP As String = grdpagos.Rows(T).Cells(0).Value.ToString()
                    Dim BancoP As String = grdpagos.Rows(T).Cells(1).Value.ToString()
                    Dim MontoP As Double = grdpagos.Rows(T).Cells(3).Value.ToString()
                    Dim RefeP As String = grdpagos.Rows(T).Cells(2).Value.ToString()
                    Dim FechaP As String = grdpagos.Rows(T).Cells(4).Value.ToString()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                            "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Fecha,Hora,Folio) values('" & FormaP & "','" & BancoP & "','" & RefeP & "','Venta'," & MontoP & ",0," & MontoP & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & cbofolio.Text & "')"
                    cmd1.ExecuteNonQuery()
                Next
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        MsgBox("Abono registrado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        'Imprime Abono en base a la configuración de las notas de venta
        Dim Imprime As Boolean = False
        Dim TPrint As String = "TICKET"
        Dim Imprime_En As String = ""
        Dim Impresora As String = ""
        Dim Tamaño As String = ""
        Dim Pasa_Print As Boolean = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Imprime = rd1("NoPrint").ToString
            End If
        End If
        rd1.Close() : cnn1.Close()

        If (Imprime) Then
            If MsgBox("¿Deseas imprimir nota de abono?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Pasa_Print = True
            Else
                Pasa_Print = False
            End If
        Else
            Pasa_Print = True
        End If

        If Pasa_Print = True Then
            Try
                cnn3.Close() : cnn3.Open()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                "select Formato from RutasImpresion where Tipo='Venta' and Equipo='" & ObtenerNombreEquipo() & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        TPrint = rd3(0).ToString()
                    End If
                End If
                rd3.Close()

                If TPrint = "" Then MsgBox("No se ha establecido un tamañao para la impresión.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cnn3.Close() : Borra() : Exit Sub

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        Impresora = rd3(0).ToString()
                    End If
                End If
                rd3.Close()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='TamImpre'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        Tamaño = rd3(0).ToString()
                    End If
                Else
                    Tamaño = "80"
                End If
                rd3.Close()
                cnn3.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try

            If TPrint = "TICKET" Then
                If Tamaño = "80" Then
                    pAbono80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pAbono80.Print()
                End If
                If Tamaño = "58" Then
                    pAbono58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pAbono58.Print()
                End If
            End If
            If TPrint = "MEDIA CARTA" Then
                'pVentaMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                'pVentaMediaCarta.Print()
            End If
            If TPrint = "CARTA" Then
                'pVentaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                'pVentaCarta.Print()
            End If
            If TPrint = "PDF - CARTA" Then
                'Genera PDF y lo guarda en la ruta

            End If

        End If

        Borra()
        otropago()
        End Sub

    Private Sub pAbono80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pAbono80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
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

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 130
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                        Y += 120
                    End If
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
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("A B O N O", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                'If txtDireccion.Text <> "" Then
                '    e.Graphics.DrawString(Mid(txtDireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                '    Y += 13.5
                '    If Mid(txtDireccion.Text, 36, 70) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                '    If Mid(txtDireccion.Text, 71, 105) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                'End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
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

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                total_prods = total_prods + canti
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

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Restaba:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            If CDbl(txtdescu.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescu.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            If CDbl(txtcambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtcambio.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Dim concepto As String = ""
            Dim monto As Double = 0

            If CDbl(txtpagos.Text) > 0 Then
                For r As Integer = 0 To grdpagos.Rows.Count - 1
                    concepto = grdpagos.Rows(r).Cells(0).Value.ToString
                    monto = CDbl(grdpagos.Rows(r).Cells(3).Value.ToString())

                    e.Graphics.DrawString("Pago con " & concepto & ":", fuente_prods, Brushes.Black, 1, Y)
                    If Len("Pago con " & concepto & ":") > 26 Then
                        Y += 13.5
                    End If
                    e.Graphics.DrawString(simbolo & FormatNumber(monto, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                    Y += 13.5
                Next
            End If
            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtrestaabono.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Y += 19

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
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnCopia_Click(sender As System.Object, e As System.EventArgs) Handles btnCopia.Click
        If cbofolio.Text = "" Then MsgBox("Selecciona un folio para poder imprimir una copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofolio.Focus().Equals(True) : Exit Sub

        Dim formato As String = ""
        Dim imp_ticket As String = ""
        Dim imp_carta As String = ""
        Dim tamticket As Integer = 0

        If (optcotiz.Checked) Then
            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select Comentario from CotPed where Folio=" & cbofolio.Text
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        formato = rd2(0).ToString()
                    End If
                End If
                rd2.Close()
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
        Else
            If (optdevos.Checked) Then
                formato = "TICKET"
            Else
                Try
                    formato = "TICKET"
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Formato from Ventas where Folio=" & cbofolio.Text
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            formato = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            tamticket = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn2.Close()
                End Try
            End If
        End If

        If formato = "TICKET" Then
            Try
                cnn3.Close() : cnn3.Open()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        imp_ticket = rd3(0).ToString()
                    End If
                End If
                rd3.Close() : cnn3.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try
        End If

        If formato = "CARTA" Then
            Try
                cnn3.Close() : cnn3.Open()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        imp_carta = rd3(0).ToString()
                    End If
                End If
                rd3.Close() : cnn3.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try
        End If

        If MsgBox("¿Deseas imprimir una copia?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            If (optnotas.Checked) Then TipoVenta = 1
            If (optcobrar.Checked) Then TipoVenta = 2
            If (optpagadas.Checked) Then TipoVenta = 3
            If (optanceladas.Checked) Then TipoVenta = 4

            If (optcotiz.Checked) Then TipoVenta = 5

            If (optdevos.Checked) Then TipoVenta = 7

            If (optnotas.Checked) Or (optcobrar.Checked) Or (optpagadas.Checked) Or (optanceladas.Checked) Then


                If formato = "TICKET" Then
                    If tamticket = "80" Then
                        If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        pVentas80.PrinterSettings.PrinterName = imp_ticket
                        pVentas80.Print()
                    Else
                        If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        pVenta58.PrinterSettings.PrinterName = imp_ticket
                        pVenta58.Print()
                    End If
                End If
                If formato = "CARTA" Then
                    If imp_carta = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    pVentasCarta.PrinterSettings.PrinterName = imp_carta
                    pVentasCarta.Print()
                End If
                If formato = "PDF - CARTA" Then
                    If varrutabase <> "" Then
                        'root_name_recibo2 = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\" & Folio & ".pdf"
                        If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & cbofolio.Text & ".pdf") Then
                            Process.Start("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & cbofolio.Text & ".pdf")
                        End If
                    Else
                        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\VENTAS\Venta_" & cbofolio.Text & ".pdf") Then
                            Process.Start(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\VENTAS\Venta_" & cbofolio.Text & ".pdf")
                        End If
                    End If
                End If
            End If
            If (optcotiz.Checked) Then
                If formato = "TICKET" Then

                    If tamticket = "80" Then
                        If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        pCotiz80.PrinterSettings.PrinterName = imp_ticket
                        pCotiz80.Print()
                    Else
                        If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        pCotiz58.PrinterSettings.PrinterName = imp_ticket
                        pCotiz58.Print()
                    End If

                End If

                If formato = "CARTA" Then
                    If imp_carta = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    pCotizCarta.PrinterSettings.PrinterName = imp_carta
                    pCotizCarta.Print()
                End If
                If formato = "PDF - CARTA" Then
                    If (optcotiz.Checked) Then
                        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & cbofolio.Text & ".pdf") Then
                            Process.Start(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & cbofolio.Text & ".pdf")
                        End If
                    End If
                End If
            End If
            If (optdevos.Checked) Then
                If tamticket = "80" Then
                    If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    pDevos80.PrinterSettings.PrinterName = imp_ticket
                    pDevos80.Print()
                Else
                    If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    pDevos58.PrinterSettings.PrinterName = imp_ticket
                    pDevos58.Print()
                End If

            End If
        End If
    End Sub

    Private Sub txtusuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                Dim id_usu As Integer = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select * from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString()
                        id_usu = rd1("IdEmpleado").ToString()
                    End If
                Else
                    MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtusuario.SelectAll()
                    Exit Sub
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select * from Permisos where IdEmpleado=" & id_usu
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Vent_CFol").ToString() = False Then
                            MsgBox("No cuentas con permisos para realizar movimientos en este formulario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            Borra()
                            Me.Close()
                        End If
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                btnAbono.Focus().Equals(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnCancela_Click(sender As System.Object, e As System.EventArgs) Handles btnCancela.Click
        If cbofolio.Text = "" Then MsgBox("Necesitas seleccionar un folio para poder cancelarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofolio.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then
            MsgBox("Ingresa tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtusuario.Focus().Equals(True)
            VaDe = "CANCELA"
            Exit Sub
        End If

        Dim id_usuarioa As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Usuarios where Clave='" & txtusuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_usuarioa = rd1("IdEmpleado").ToString()
                End If
            Else
                MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                VaDe = "CANCELA"
                txtusuario.SelectionStart = 0
                txtusuario.SelectionLength = Len(txtusuario.Text)
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Permisos where IdEmpleado=" & id_usuarioa
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Vent_Canc").ToString() = False Then
                        MsgBox("No cuentas con permiso para realizar cancelaciones.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtusuario.SelectAll()
                        Exit Sub
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()

            'Nota de venta pagada
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Devoluciones where Folio=" & cbofolio.Text & " and Facturado='DEVOLUCION'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("La nota de venta " & cbofolio.Text & " no puede ser cancelada porque ya se han efectuado devoluciones de la misma.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cbofolio.Focus().Equals(True)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
            End If
            rd1.Close()

            'Nota de venta cancelada
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Ventas where Folio=" & cbofolio.Text & " and Status='CANCELADA' and Cliente='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("La nota de venta " & cbofolio.Text & " fue cancelada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cbofolio.Focus().Equals(True)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
            End If
            rd1.Close()

            'Nota de venta facturada
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Folio from VentasDetalle where Folio=" & cbofolio.Text & " and Facturado<>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("La nota de venta " & cbofolio.Text & " fya fue facturada, por lo que no puede ser cancelada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cbofolio.Focus().Equals(True)
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
            End If
            rd1.Close()

            'Nota inexistente
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Ventas where Folio=" & cbofolio.Text & " and Cliente='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If Not rd1.HasRows Then
                MsgBox("La nota de venta " & cbofolio.Text & " no existe.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cbofolio.Focus().Equals(True)
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If MsgBox("¿Deseas cancelar este folio?" & vbNewLine & "Esta acción no se puede deshacer", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            For dl As Integer = 0 To grdcaptura.Rows.Count - 1
                Dim codigo As String = grdcaptura.Rows(dl).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(dl).Cells(1).Value.ToString()
                Dim cantidad As Double = grdcaptura.Rows(dl).Cells(3).Value.ToString()

                Dim MyMultiplo As Double = 0
                Dim MyPrecio As Double = 0

                Dim MyExist As Double = 0
                Dim MyNewExist As Double = 0
                Dim MyNewExistLote As Double = 0

                Dim lote As String = ""
                Dim fecha_cad As String = ""

                If grdcaptura.Rows(dl).Cells(0).Value.ToString() <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "select * from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If rd1("ProvRes").ToString() = True Then
                                'Es un kit
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                     "select * from Kits where Nombre='" & nombre & "'"
                                rd2 = cmd2.ExecuteReader
                                Do While rd2.Read
                                    If rd2.HasRows Then
                                        Dim mi_codigo As String = rd2("Codigo").ToString()
                                        Dim mi_nombre As String = rd2("Nombre").ToString()
                                        Dim mi_precio As Double = rd2("PPrecio").ToString()
                                        Dim mi_cantidad As Double = rd2("Cantidad").ToString()

                                        cmd3 = cnn3.CreateCommand
                                        cmd3.CommandText =
                                             "select * from Productos where Codigo='" & Strings.Left(mi_codigo, 6) & "'"
                                        rd3 = cmd3.ExecuteReader
                                        If rd3.HasRows Then
                                            If rd3.Read Then
                                                MyExist = rd3("Existencia").ToString()
                                                MyMultiplo = rd3("Multiplo").ToString()

                                                MyNewExist = MyExist + (mi_cantidad * cantidad * MyMultiplo)
                                            End If
                                        End If
                                        rd3.Close()

                                        cmd3 = cnn3.CreateCommand
                                        cmd3.CommandText =
                                             "update Productos set Cargado=0, CargadoInv=0, Existencia=" & MyNewExist & " where Codigo='" & Strings.Left(mi_codigo, 6) & "'"
                                        cmd3.ExecuteNonQuery()

                                        'Actualiza registro de PEPS
                                        ActualizaPEPS(cbofolio.Text, mi_codigo, (mi_cantidad * cantidad))

                                        'Inserta el movimiento en el cardex
                                        cmd3 = cnn3.CreateCommand
                                        cmd3.CommandText =
                                             "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & Strings.Left(mi_codigo, 6) & "','" & mi_nombre & "','Cancelación de venta'," & MyExist & "," & mi_cantidad * cantidad & "," & MyNewExist & "," & mi_precio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & cbofolio.Text & "','','','','','')"
                                        cmd3.ExecuteNonQuery()
                                    End If
                                Loop
                                rd2.Close()
                            Else
                                MyMultiplo = rd1("Multiplo").ToString()
                                MyPrecio = rd1("PrecioVenta").ToString()
                                MyExist = rd1("Existencia").ToString()
                                MyNewExist = MyExist + (cantidad * MyMultiplo)

                                'Es un producto solito
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                     "select * from VentasDetalle where Codigo='" & codigo & "' and Folio=" & cbofolio.Text
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    If rd2.Read Then
                                        lote = rd2("Lote").ToString()
                                        fecha_cad = rd2("Caducidad").ToString()
                                    End If
                                End If
                                rd2.Close()

                                'Actualiza la existencia en productos
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                     "update Productos set Cargado=0, CargadoInv=0, Existencia=" & MyNewExist & " where Codigo='" & Strings.Left(codigo, 6) & "'"
                                cmd2.ExecuteNonQuery()

                                'Actualiza registro de PEPS
                                ActualizaPEPS(cbofolio.Text, codigo, cantidad)

                                'Inserta el movimiento en el cardex
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                     "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & Strings.Left(codigo, 6) & "','" & nombre & "','Cancelación de venta'," & MyExist & "," & cantidad & "," & MyNewExist & "," & MyPrecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & cbofolio.Text & "','','','','','')"
                                cmd2.ExecuteNonQuery()

                                'Actualiza lotes de caducidad
                                If lote <> "" Then
                                    Dim id_lote As Integer = 0
                                    Dim cant_lote As Double = 0

                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                         "select Id,Cantidad from LoteCaducidad where Codigo='" & codigo & "' and Lote='" & lote & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        If rd2.Read Then
                                            id_lote = rd2(0).ToString()
                                            cant_lote = rd2(1).ToString()
                                        End If
                                    Else
                                        id_lote = 0
                                        cant_lote = 0
                                    End If
                                    rd2.Close()

                                    Dim nueva_cant_lote As Double = cant_lote + cantidad

                                    If id_lote = 0 Then
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText =
                                             "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & codigo & "','" & lote & "','" & Format(CDate(fecha_cad), "yyyy-MM-dd") & "'," & nueva_cant_lote & ")"
                                        cmd2.ExecuteNonQuery()
                                    Else
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText =
                                             "update LoteCaducidad set Cantidad=" & nueva_cant_lote & " where Codigo='" & codigo & "' and Lote='" & lote & "'"
                                        cmd2.ExecuteNonQuery()
                                    End If
                                End If

                            End If
                        End If
                    Else
                        MsgBox("El código " & codigo & " fue eliminado de la base de datos." & vbNewLine & "La nota de venta no puede ser cancelada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        Exit Sub
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close() : cnn2.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Dim acuenta As Double = 0
        Dim monto_efectivo As Double = 0
        Dim monto_efectivo2 As Double = 0
        Dim monto_tarjeta As Double = 0
        Dim monto_transfe As Double = 0
        Dim monto_monedero As Double = 0
        Dim monto_otro As Double = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "update Ventas set Status='CANCELADA', FCancelado='" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "' where Folio=" & cbofolio.Text
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "update Ventas set Cargado=0 where Folio=" & cbofolio.Text
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select ACuenta from Ventas where Folio=" & cbofolio.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    acuenta = rd1(0).ToString()
                End If
            End If
            rd1.Close()


            Dim cuentapagar As String = ""
            Dim mysaldo2 As Double = 0
            Dim sumapagos As Double = 0

            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()
            cnn4.Close() : cnn4.Open()

            If acuenta > 0 Then
                'Monto en efectivo

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Distinct FormaPago FROM AbonoI WHERE NumFolio='" & cbofolio.Text & "' AND Concepto='ABONO'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        cuentapagar = rd1(0).ToString

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Monto from AbonoI where NumFolio='" & cbofolio.Text & "' and Concepto='ABONO' AND FormaPago='" & cuentapagar & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                sumapagos = rd2(0).ToString

                                If lblNumCliente.Text <> "MOSTRADOR" Then
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "select Saldo from AbonoI where Id=(select max(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            mysaldo2 = CDbl(IIf(rd3(0).ToString() = "", 0, rd3(0).ToString())) - CDbl(txtacuenta.Text)
                                        End If
                                    Else
                                        mysaldo2 = -CDbl(txttotal.Text)
                                    End If
                                    rd3.Close()

                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText =
                                 "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Corte,CorteU) values('" & cbofolio.Text & "'," & IIf(lblNumCliente.Text = "MOSTRADOR", 0, lblNumCliente.Text) & ",'" & cbonombre.Text & "','NOTA CANCELADA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & sumapagos & "," & monto_efectivo2 & ",'" & cuentapagar & "'," & sumapagos & ",'','','" & lblusuario.Text & "',0,0)"
                                    cmd4.ExecuteNonQuery()
                                End If


                                If lblNumCliente.Text = "MOSTRADOR" Then
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText =
                             "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & lblNumCliente.Text & ")"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            mysaldo2 = CDbl(IIf(rd3(0).ToString() = "", 0, rd3(0).ToString())) + CDbl(txtacuenta.Text)
                                            mysaldo2 = mysaldo2 - CDbl(txtresta.Text)
                                        End If
                                    Else
                                        mysaldo2 = CDbl(txtacuenta.Text)
                                    End If
                                    rd3.Close()

                                    cmd4 = cnn4.CreateCommand
                                    cmd4.CommandText =
                             "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Corte,CorteU) values('" & cbofolio.Text & "'," & IIf(lblNumCliente.Text = "MOSTRADOR", 0, lblNumCliente.Text) & ",'" & cbonombre.Text & "','CARGO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & CDbl(txtacuenta.Text) & ",0," & mysaldo2 & ",'',0,'','','" & lblusuario.Text & "',0,0)"
                                    cmd4.ExecuteNonQuery()
                                End If
                            End If
                        End If
                        rd2.Close()

                    End If
                Loop
                rd1.Close()
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "update Ventas set MontoCance=" & monto_efectivo & " where Folio=" & cbofolio.Text
            cmd1.ExecuteNonQuery()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "update VentasDetalle set CostoVUE=0, Facturado='CANCELADO', CostoVP=0 where Folio=" & cbofolio.Text
            cmd1.ExecuteNonQuery()

            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
            cnn1.Close()

            If acuenta > 0 Then
                MsgBox("Salen $" & FormatNumber(acuenta, 2) & " de caja por motivo de cancelación.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        MsgBox("Cancelación realizada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        btnCancela.Enabled = True
        Borra()
    End Sub

    Private Sub ActualizaPEPS(ByVal folio As Integer, ByVal codigo As String, ByVal cantidad As Double)
        Dim cant_registros As Integer = 0
        Dim suma_registros As Double = 0
        Dim cuestan_registros As Double = 0

        Dim costo_registro As Double = 0

        Dim p_nombre As String = ""
        Dim p_unidad As String = ""

        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select * from Productos where Codigo='" & codigo & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    p_nombre = rd4("Nombre").ToString()
                    p_unidad = rd4("UVenta").ToString()
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select count(Id) from costeo where Referencia='" & folio & "' and Codigo='" & codigo & "' and Concepto='VENTA'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    cant_registros = rd4(0).ToString()
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select SUM(Salida), SUM(Costo) from costeo where Referencia='" & folio & "' and Codigo='" & codigo & "' and Concepto='VENTA'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    suma_registros = rd4(0).ToString()
                    cuestan_registros = rd4(1).ToString()
                End If
            End If
            rd4.Close()

            If cant_registros = 1 Then
                'Aquí sólo se ocupó una entrada y se inserta con el mismo costo

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                     "select Costo from costeo where Referencia='" & folio & "' and Codigo='" & codigo & "' and Concepto='VENTA'"
                rd4 = cmd4.ExecuteReader
                If rd4.HasRows Then
                    If rd4.Read Then
                        costo_registro = rd4("Costo").ToString()
                    End If
                End If
                rd4.Close()

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                     "insert into costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','CANCELACION','" & folio & "','" & codigo & "','" & p_nombre & "','" & p_unidad & "'," & cantidad & ",0," & cantidad & "," & costo_registro & ",0,0,'" & lblusuario.Text & "')"
                cmd4.ExecuteNonQuery()
            ElseIf cant_registros > 1 Then
                costo_registro = cuestan_registros / cant_registros

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                     "insert into costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','CANCELACION','" & folio & "','" & codigo & "','" & p_nombre & "','" & p_unidad & "'," & cantidad & ",0," & cantidad & "," & costo_registro & ",0,0,'" & lblusuario.Text & "')"
                cmd4.ExecuteNonQuery()
            End If

            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try
    End Sub


    'Formato de entrega
    Public Sub Insert_Entregas()
        Dim oData As New ToolKitSQL.myssql
        Dim sSql As String = ""
        Dim a_cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sInfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim my_folio As Integer = 0
        Dim MyStatus As String = ""
        Dim tel_cliente As String = ""

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sInfo) Then
                .runSp(a_cnn, "delete from EntregasDetalle", sInfo) : sInfo = ""
                .runSp(a_cnn, "delete from Entregas", sInfo) : sInfo = ""

                If cbonombre.Text <> "" Then
                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select * from Clientes where Nombre='" & cbonombre.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            tel_cliente = rd3("Telefono").ToString()
                        End If
                    End If
                    rd3.Close() : cnn3.Close()
                End If

                If .runSp(a_cnn, "insert into Entregas(Nombre,Direccion,Telefono,Total,Descuento,ACuenta,Resta,Usuario,Fecha) values('" & cbonombre.Text & "','" & txtdireccion.Text & "','" & tel_cliente & "'," & CDbl(txttotal.Text) & "," & CDbl(txtdescuento.Text) & ",0,0,'" & txtvendedor.Text & "',#" & Date.Now & "#)", sInfo) Then
                    sInfo = ""
                End If

                If .getDr(a_cnn, dr, "select MAX(Folio) from Entregas", sInfo) Then
                    my_folio = dr(0).ToString()
                End If

                Dim cod_temp As String = ""

                For pipo As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(pipo).Cells(0).Value.ToString()
                    If codigo = "" Then GoTo doorcita

                    Dim nombre As String = grdcaptura.Rows(pipo).Cells(1).Value.ToString()
                    Dim unidad As String = grdcaptura.Rows(pipo).Cells(2).Value.ToString()
                    Dim cantidad As Double = grdcaptura.Rows(pipo).Cells(3).Value.ToString()

                    If codigo <> "" Then
                        cod_temp = codigo
                        .runSp(a_cnn, "insert into EntregasDetalle(Folio,Codigo,Nombre,Cantidad,UVenta,Comentario) values(" & my_folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "','')", sInfo)
                        sInfo = ""
                    End If
                    Continue For
doorcita:
                    If grdcaptura.Rows(pipo).Cells(1).Value.ToString() <> "" Then
                        'Es comentario
                        .runSp(a_cnn, "update EntregasDetalle set Comentario='" & grdcaptura.Rows(pipo).Cells(1).Value.ToString() & "' where Codigo='" & cod_temp & "' and Folio=" & my_folio, sInfo)
                        sInfo = ""
                    End If
                Next
                a_cnn.Close()
            End If
        End With
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (optnotas.Checked) Or (optcobrar.Checked) Or (optpagadas.Checked) Or (optanceladas.Checked) Then

            If varrutabase <> "" Then
                If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf") Then
                    Process.Start("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf")
                End If
            Else
                If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf") Then
                    Process.Start(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf")
                Else

                    Panel6.Visible = True
                    My.Application.DoEvents()

                    'Inserta
                    Insert_Entregas()
                    'PDF
                    PDF_Entregas()
                    Panel6.Visible = False
                    My.Application.DoEvents()

                End If
            End If
        End If
    End Sub
    Public Sub PDF_Entregas()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo

        'Nombre del CrystalReport
        Dim FileNta As New EntregaDescuento

        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\")
        root_name_recibo = My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf"

        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf") Then
            File.Delete(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .DatabaseName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & cbofolio.Text & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & txtvendedor.Text & "'"
        FileNta.DataDefinition.FormulaFields("conLetra").Text = "'" & convLetras(txttotal.Text) & "'"

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then
            System.IO.File.Copy(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & cbofolio.Text & ".pdf")
        End If
    End Sub

    Private Sub pAbono58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pAbono58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
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
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("A B O N O", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If
                Y += 3
                'If txtDireccion.Text <> "" Then
                '    e.Graphics.DrawString(Mid(txtDireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                '    Y += 13.5
                '    If Mid(txtDireccion.Text, 36, 70) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                '    If Mid(txtDireccion.Text, 71, 105) <> "" Then
                '        e.Graphics.DrawString(Mid(txtDireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                '        Y += 13.5
                '    End If
                'End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 18
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
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
                ' e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 6, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 15

            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Restaba:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            If CDbl(txtefectivo.Text) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtefectivo.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            If CDbl(txtcambio.Text) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtcambio.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            Dim tarjeta As Double = 0
            Dim transfe As Double = 0
            Dim otro As Double = 0
            If CDbl(txtpagos.Text) > 0 Then
                For r As Integer = 0 To grdpagos.Rows.Count - 1
                    Select Case grdpagos.Rows(r).Cells(0).Value.ToString
                        Case Is = "TARJETA"
                            tarjeta = tarjeta + CDbl(grdpagos.Rows(r).Cells(3).Value.ToString())
                        Case Is = "TRANSFERENCIA"
                            transfe = transfe + CDbl(grdpagos.Rows(r).Cells(3).Value.ToString())
                        Case Is = "OTRO"
                            otro = otro + CDbl(grdpagos.Rows(r).Cells(3).Value.ToString())
                    End Select
                Next

                If tarjeta > 0 Then
                    e.Graphics.DrawString("Pago con tarjeta(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(tarjeta, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                If transfe > 0 Then
                    e.Graphics.DrawString("Pago con transfe.(s):", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(transfe, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                If otro > 0 Then
                    e.Graphics.DrawString("Otros pagos:", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(otro, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
            End If
            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtrestaabono.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            Y += 15

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
            Y += 15
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            cnn1.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pVentas80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVentas80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
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
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 130
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                        Y += 120
                    End If
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

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("COPIA NOTA VENTA", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
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

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = IIf(grdcaptura.Rows(miku).Cells(2).Value.ToString() = "", "PZA", grdcaptura.Rows(miku).Cells(2).Value.ToString())
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                'If descuento <> 0 Then
                '    Y -= 4
                '    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                '    Y += 12
                'End If
                total_prods = total_prods + canti
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

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15

            ' If TipoVenta = 2 Then
            ' If CDbl(txtresta.Text) > 0 Then
            e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18
            'End If
            'End If

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18



            Y += 19

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
            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pVentasCarta_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVentasCarta.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim Y As Double = 0
        Dim X As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim pagare As String = ""
        Dim clausu(10) As String

        Dim continua_en As String = ""

        Y = 35

        Try
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, 10, 200, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, 30, 220, 110)
                    'e.Graphics.DrawRectangle(pen, 0, 5, 220, 110)
                End If
                X = 230
            Else
                X = 0
            End If

            e.Graphics.DrawString("COPIA NOTA DE VENTA", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            e.Graphics.DrawString("FOLIO  " & cbofolio.Text, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Red, 840, 0, sf)

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
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    pagare = rd1("Pagare").ToString()
                    clausu(0) = rd1("C1").ToString()
                    clausu(1) = rd1("C2").ToString()
                    clausu(2) = rd1("C3").ToString()
                    clausu(3) = rd1("C4").ToString()
                    clausu(4) = rd1("C5").ToString()
                    clausu(5) = rd1("C6").ToString()
                    clausu(6) = rd1("C7").ToString()
                    clausu(7) = rd1("C8").ToString()
                    clausu(8) = rd1("C9").ToString()
                    clausu(9) = rd1("C10").ToString()

                    Y += 10
                    e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Red, X, Y)
                    e.Graphics.DrawString("Lo atiende " & lblusuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            If tLogo <> "SIN" Then
                X = 520
            Else
                X = 300
            End If

            If cbonombre.Text <> "" Then
                Y = 35
                e.Graphics.DrawString(cbonombre.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                Y += 16

                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                End If

                'If dtpFecha_E.Visible = True Then
                '    Y += 20
                '    e.Graphics.DrawString("Fecha de entrega:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, X, Y)
                '    e.Graphics.DrawString(FormatDateTime(dtpFecha_E.Value, DateFormat.ShortDate), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, (X + 140), Y)
                'End If
            End If

            e.Graphics.DrawLine(pen, 1, 160, 840, 160)
            Y = 164
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("UNIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 110, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 220, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, Y, sf)
            e.Graphics.DrawLine(pen, 1, 182, 840, 182)
            Y = 185

            Dim total_prods As Double = 0

            printLine = 0
            Do While printLine = grdcaptura.Rows.Count - 1
                If Y + 20 > 1050 Then
                    e.HasMorePages = True
                    pagina += 1
                    Exit Do
                Else
                End If

                If grdcaptura.Rows(printLine).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(printLine).Cells(0).Value.ToString = "" Then
                    Y -= 7
                    e.Graphics.DrawString(grdcaptura.Rows(printLine).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Gray, 220, Y)
                    Y += 21
                    printLine += 1
                    Continue Do
                End If
                Dim codigo As String = grdcaptura.Rows(printLine).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(printLine).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(printLine).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(printLine).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(printLine).Cells(4).Value.ToString()
                Dim descu As Double = grdcaptura.Rows(printLine).Cells(5).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 220, Y)
                Y += 12.5
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 220, Y)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 40, Y, sc)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 145, Y, sc)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 830, Y, sf)
                Y += 22
                If descu <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descu, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti

                printLine += 1
                Contador += 1
            Loop

            printLine = 0


            Y -= 3
            e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
            Y += 5
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 450, Y, sf)
            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 0, Y)

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
            e.Graphics.DrawString(FormatNumber(txttotal.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)

            Y += 13
            Dim y_temp As Double = Y
            If Pie <> "" Then
                Y += 7
                e.Graphics.DrawString(Mid(Pie, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
                If Mid(Pie, 36, 70) <> "" Then
                    e.Graphics.DrawString(Mid(Pie, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                End If
                If Mid(Pie, 71, 105) <> "" Then
                    e.Graphics.DrawString(Mid(Pie, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                End If
            End If

            Y = y_temp
            Y += 2.5
            If CDbl(txtdescuento.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtdescuento.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If

            If TipoVenta = 2 Then
                If CDbl(txtresta.Text) > 0 Then
                    e.Graphics.DrawString("Resta:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                    e.Graphics.DrawString(FormatNumber(txtresta.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 15.5
                End If
            End If

            e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 417, 1080, sc)
            e.Graphics.DrawString(pagina, New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, 1080, sf)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pCotiz80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCotiz80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
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
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 130
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                        Y += 120
                    End If
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
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            If TipoVenta = 5 Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawString("COPIA COTIZACIÓN", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 17
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 18
            End If
            If TipoVenta = 6 Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawString("COPIA PEDIDO", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 12
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 18
            End If

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
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

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descu As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                If descu <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descu, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
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

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            Y += 19
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pDevos80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pDevos80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
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
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 130
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                        Y += 120
                    End If
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
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("COPIA DEVOLUCIÓN", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
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
            Dim precio As Double = 0
            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                precio = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                total_prods = total_prods + canti
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


            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            'If CDbl(txttotal.Text) > 0 Then
            '    e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
            '    e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            '    Y += 13.5
            'End If



            e.Graphics.DrawString("Total de la devolución:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(Letras(precio), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            Y += 18
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub pCotizCarta_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCotizCarta.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim Y As Double = 0
        Dim X As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Y = 35

        Try
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, 10, 200, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, 30, 220, 110)
                    'e.Graphics.DrawRectangle(pen, 0, 5, 220, 110)
                End If
                X = 230
            Else
                X = 0
            End If

            If TipoVenta = 5 Then
                e.Graphics.DrawString("COPIA COTIZACION", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            End If
            If TipoVenta = 6 Then
                e.Graphics.DrawString("COPIA PEDIDO", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            End If
            e.Graphics.DrawString("FOLIO  " & cbofolio.Text, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Red, 840, 0, sf)

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
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    Y += 10
                    e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Red, X, Y)
                    e.Graphics.DrawString("Lo atiende " & lblusuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            'e.Graphics.DrawLine(pen, 510, 20, 510, 100)            

            If tLogo <> "SIN" Then
                X = 520
            Else
                X = 300
            End If

            If cbonombre.Text <> "" Then
                Y = 35
                e.Graphics.DrawString(cbonombre.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                Y += 16

                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                End If
            End If

            e.Graphics.DrawLine(pen, 1, 160, 840, 160)
            Y = 164
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("UNIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 110, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 220, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, Y, sf)
            e.Graphics.DrawLine(pen, 1, 182, 840, 182)
            Y = 185

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 7
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Gray, 220, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descue As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)
                Dim caducidad As String = grdcaptura.Rows(miku).Cells(9).Value.ToString

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 220, Y)
                Y += 12.5
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 220, Y)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 40, Y, sc)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 145, Y, sc)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 830, Y, sf)
                Y += 22
                If descue <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento %" & descue, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
            Y += 5
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 450, Y, sf)
            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 0, Y)

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0


            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 580, Y)
            e.Graphics.DrawString(FormatNumber(txttotal.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)

            Y += 13

            If CDbl(txtdescuento.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtdescuento.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        e.HasMorePages = False
    End Sub
    Private Sub pDevosCarta_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim Y As Double = 0
        Dim X As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim pagare As String = ""
        Dim clausu(10) As String

        Dim continua_en As String = ""

        Y = 35

        Try
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 0, 10, 200, 120)
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 0, 30, 220, 110)
                    'e.Graphics.DrawRectangle(pen, 0, 5, 220, 110)
                End If
                X = 230
            Else
                X = 0
            End If

            e.Graphics.DrawString("COPIA DE DEVOLUCIÓN", New Drawing.Font("Lucida Sans Typewriter", 16, FontStyle.Bold), Brushes.Navy, X, 0)
            e.Graphics.DrawString("FOLIO  " & cbofolio.Text, New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Red, 840, 0, sf)

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
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, X, Y)
                        Y += 12
                    End If

                    Y += 10
                    e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongDate) & " " & FormatDateTime(Date.Now, DateFormat.ShortTime), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Red, X, Y)
                    e.Graphics.DrawString("Lo atiende " & lblusuario.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            If tLogo <> "SIN" Then
                X = 520
            Else
                X = 300
            End If

            If cbonombre.Text <> "" Then
                Y = 35
                e.Graphics.DrawString(cbonombre.Text, New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, X, Y)
                Y += 16

                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, X, Y)
                        Y += 13.5
                    End If
                End If

                'If dtpFecha_E.Visible = True Then
                '    Y += 20
                '    e.Graphics.DrawString("Fecha de entrega:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, X, Y)
                '    e.Graphics.DrawString(FormatDateTime(dtpFecha_E.Value, DateFormat.ShortDate), New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, (X + 140), Y)
                'End If
            End If

            e.Graphics.DrawLine(pen, 1, 160, 840, 160)
            Y = 164
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("UNIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 110, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 220, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 680, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 820, Y, sf)
            e.Graphics.DrawLine(pen, 1, 182, 840, 182)
            Y = 185

            Dim total_prods As Double = 0

            printLine = 0
            Do While printLine = grdcaptura.Rows.Count - 1
                If Y + 20 > 1050 Then
                    e.HasMorePages = True
                    pagina += 1
                    Exit Do
                Else
                End If

                If grdcaptura.Rows(printLine).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(printLine).Cells(0).Value.ToString = "" Then
                    Y -= 7
                    e.Graphics.DrawString(grdcaptura.Rows(printLine).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Gray, 220, Y)
                    Y += 21
                    printLine += 1
                    Continue Do
                End If
                Dim codigo As String = grdcaptura.Rows(printLine).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(printLine).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(printLine).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(printLine).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(printLine).Cells(4).Value.ToString()
                Dim descu As Double = grdcaptura.Rows(printLine).Cells(5).Value.ToString()
                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 220, Y)
                Y += 12.5
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 220, Y)
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 40, Y, sc)
                e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 145, Y, sc)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 680, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 830, Y, sf)
                Y += 22
                If descu <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descu, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti

                printLine += 1
                Contador += 1
            Loop

            printLine = 0


            Y -= 3
            e.Graphics.DrawLine(pen, 1, CInt(Y), 840, CInt(Y))
            Y += 5
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 450, Y, sf)
            e.Graphics.DrawString(Letras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 0, Y)

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            e.Graphics.DrawString("Total:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
            e.Graphics.DrawString(FormatNumber(txttotal.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)

            Y += 13
            Dim y_temp As Double = Y
            If Pie <> "" Then
                Y += 7
                e.Graphics.DrawString(Mid(Pie, 1, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                Y += 12
                If Mid(Pie, 36, 70) <> "" Then
                    e.Graphics.DrawString(Mid(Pie, 36, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                End If
                If Mid(Pie, 71, 105) <> "" Then
                    e.Graphics.DrawString(Mid(Pie, 71, 35), New Drawing.Font(tipografia, 9, FontStyle.Italic), Brushes.Navy, 0, Y)
                    Y += 12
                End If
            End If

            Y = y_temp
            Y += 2.5
            If CDbl(txtdescuento.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 570, Y)
                e.Graphics.DrawString(FormatNumber(txtdescuento.Text, 2), New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, Y, sf)
                Y += 15.5
            End If

            e.Graphics.DrawString("Documento generado con un sistema Delsscom®", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 417, 1080, sc)
            e.Graphics.DrawString(pagina, New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 835, 1080, sf)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVenta58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
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

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("COPIA DE NOTA DE VENTA", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            Y += 10
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 29), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                    If Mid(txtdireccion.Text, 29, 58) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 29, 58), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                    If Mid(txtdireccion.Text, 59, 88) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 59, 88), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = IIf(grdcaptura.Rows(miku).Cells(2).Value.ToString() = "", "PZA", grdcaptura.Rows(miku).Cells(2).Value.ToString())
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

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
                'e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                'If descuento <> 0 Then
                '    Y -= 4
                '    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                '    Y += 12
                'End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 15

            If TipoVenta = 2 Then
                If CDbl(txtresta.Text) > 0 Then
                    e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
            End If

            Y += 10

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
            Y += 10
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            Dim va_whatsapp As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NumPart from Formatos where Facturas='Whatsapp'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        va_whatsapp = rd1(0).ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pDevo58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pDevos58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
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
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("COPIA DEVOLUCIÓN", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 180, Y, sf)
            Y += 15

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 29), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                    If Mid(txtdireccion.Text, 29, 58) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 29, 58), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                    If Mid(txtdireccion.Text, 59, 88) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 59, 88), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0
            Dim precio As Double = 0
            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                precio = grdcaptura.Rows(miku).Cells(4).Value.ToString()
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
                ' e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0


            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            'If CDbl(txttotal.Text) > 0 Then
            '    e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
            '    e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            '    Y += 13.5
            'End If



            e.Graphics.DrawString("Total de la devolución:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString(Letras(precio), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pCotiz58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCotiz58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
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
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd1.Close()

            '[1]. Datos de la venta
            If TipoVenta = 5 Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("COPIA COTIZACIÓN", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
            End If
            If TipoVenta = 6 Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("COPIA PEDIDO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
            End If

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 14
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 18
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                    If Mid(txtdireccion.Text, 36, 70) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 70), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                    If Mid(txtdireccion.Text, 71, 105) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 105), fuente_prods, Brushes.Black, 1, Y)
                        Y += 12
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim total_prods As Double = 0

            For miku As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(miku).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 18
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
                Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
                Dim descu As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()

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
                '  e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                If descu <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descu, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim MySubtotal As Double = 0
            Dim TotalIVAPrint As Double = 0
            Dim TotalIEPS As Double = 0

            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            If CDbl(txtdescuento.Text) > 0 Then
                e.Graphics.DrawString("Descuento:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtdescuento.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If
            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 10

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)

            Y += 15
            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCunetaRep_DropDown(sender As Object, e As EventArgs) Handles cboCunetaRep.DropDown
        Try
            cboCunetaRep.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCunetaRep.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCunetaRep_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCunetaRep.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Banco FROM cuentasbancarias WHERE CuentaBan='" & cboCunetaRep.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtBancoRep.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCunetaRep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCunetaRep.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnPago.Focus().Equals(True)
        End If
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub txtdescu_TextChanged(sender As Object, e As EventArgs) Handles txtdescu.TextChanged
        If donde_va = "Descuento Moneda" Then
            Dim resta As Double = 0

            If txtdescu.Enabled = True Then
                Dim descu As Double = IIf(txtdescu.Text = "", 0, txtdescu.Text)

                Dim resta_original As Double = txtresta.Text
                Dim porcentaje_descuento As Double = 0

                If txtdescu.Text = "" Then
                    txtdescu.Text = "0.00"
                    resta = CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))
                    txtrestaabono.Text = FormatNumber(resta, 2)
                    txtdescu_porc.Text = "0"
                    Exit Sub
                Else
                    If descu <> 0 Then
                        porcentaje_descuento = (descu * 100) / resta_original
                        txtdescu_porc.Text = FormatNumber(porcentaje_descuento, 1)
                    Else
                        txtdescu_porc.Text = "0"
                    End If
                End If


                resta = (CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))) - CDbl(txtdescu.Text)
                If resta >= 0 Then
                    txtrestaabono.Text = FormatNumber(resta, 2)
                    txtcambio.Text = "0.00"
                Else
                    txtrestaabono.Text = "0.00"
                    txtcambio.Text = FormatNumber(Math.Abs(resta), 2)
                End If
            Else
                txtdescu.Text = "0"
                resta = CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))
                txtdescu_porc.Text = "0"
                If resta >= 0 Then
                    txtrestaabono.Text = FormatNumber(resta, 2)
                    txtcambio.Text = "0.00"
                Else
                    txtrestaabono.Text = "0.00"
                    txtcambio.Text = FormatNumber(Math.Abs(resta), 2)
                End If
                txtrestaabono.Text = FormatNumber(resta, 2)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtdescu_Click(sender As Object, e As EventArgs) Handles txtdescu.Click
        donde_va = "Descuento Moneda"
        txtdescu.SelectionStart = 0
        txtdescu.SelectionLength = Len(txtdescu.Text)
    End Sub

    Private Sub txtdescu_GotFocus(sender As Object, e As EventArgs) Handles txtdescu.GotFocus
        donde_va = "Descuento Moneda"
        txtdescu.SelectionStart = 0
        txtdescu.SelectionLength = Len(txtdescu.Text)
    End Sub

    Private Sub txtdescu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescu.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdescu.Text = FormatNumber(txtdescu.Text, 2)
            txtefectivo.Focus().Equals(True)
            Valida_Descuento()
        End If
    End Sub

    Private Sub txtdescu_porc_TextChanged(sender As Object, e As EventArgs) Handles txtdescu_porc.TextChanged
        If donde_va = "Descuento Porcentaje" Then
            Dim resta As Double = 0

            If txtdescu.Enabled = True Then
                Dim descu_porcentaje As Double = IIf(txtdescu_porc.Text = "", 0, txtdescu_porc.Text)

                Dim resta_original As Double = txtresta.Text
                Dim descuento As Double = 0

                If txtdescu_porc.Text = "" Then
                    txtdescu_porc.Text = "0"
                    txtdescu.Text = "0.00"
                    resta = CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))
                    txtrestaabono.Text = FormatNumber(resta, 2)
                    Exit Sub
                Else
                    If descu_porcentaje <> 0 Then
                        descuento = (descu_porcentaje * resta_original) / 100
                        txtdescu.Text = FormatNumber(descuento, 2)
                    Else
                        txtdescu.Text = "0.00"
                    End If
                End If

                resta = (CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))) - CDbl(txtdescu.Text)
                If resta >= 0 Then
                    txtrestaabono.Text = FormatNumber(resta, 2)
                    txtcambio.Text = "0.00"
                Else
                    txtrestaabono.Text = "0.00"
                    txtcambio.Text = FormatNumber(Math.Abs(resta), 2)
                End If
            Else
                txtdescu.Text = "0"
                resta = CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))
                txtdescu_porc.Text = "0"
                If resta >= 0 Then
                    txtrestaabono.Text = FormatNumber(resta, 2)
                    txtcambio.Text = "0.00"
                Else
                    txtrestaabono.Text = "0.00"
                    txtcambio.Text = FormatNumber(Math.Abs(resta), 2)
                End If
                txtrestaabono.Text = FormatNumber(resta, 2)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtdescu_porc_GotFocus(sender As Object, e As EventArgs) Handles txtdescu_porc.GotFocus
        donde_va = "Descuento Porcentaje"
        txtdescu_porc.SelectionStart = 0
        txtdescu_porc.SelectionLength = Len(txtdescu_porc.Text)
        txtdescu_porc.SelectAll()
    End Sub

    Private Sub txtdescu_porc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescu_porc.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdescu.Focus().Equals(True)
            Valida_Descuento()
        End If
    End Sub

    Private Sub txtdescu_porc_Click(sender As Object, e As EventArgs) Handles txtdescu_porc.Click
        donde_va = "Descuento Porcentaje"
        txtdescu_porc.SelectionStart = 0
        txtdescu_porc.SelectionLength = Len(txtdescu_porc.Text)
        txtdescu_porc.SelectAll()
    End Sub

    Private Sub Valida_Descuento()
        Dim Desc As Double = 0
        Dim CampoDsct As Double = txtdescu_porc.Text
        Dim resta As Double = 0

        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                    "select NotasCred from Formatos where Facturas='Mdescuento'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    Desc = rd5(0).ToString()
                    If CampoDsct > Desc Then
                        MsgBox("No puedes rebasar el descuento máximo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtdescu.Text = "0.00"
                        txtdescu_porc.Text = "0"
                        resta = CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))
                        If resta >= 0 Then
                            txtrestaabono.Text = FormatNumber(resta, 2)
                            txtcambio.Text = "0.00"
                        Else
                            txtrestaabono.Text = "0.00"
                            txtcambio.Text = FormatNumber(Math.Abs(resta), 2)
                        End If
                        Exit Sub
                    End If
                End If
            End If
            rd5.Close() : cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtdescuento_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento.TextChanged

    End Sub

    Private Sub txtsubtotal_TextChanged(sender As Object, e As EventArgs) Handles txtsubtotal.TextChanged

    End Sub

    Private Sub txtvence_TextChanged(sender As Object, e As EventArgs) Handles txtvence.TextChanged

    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index
        Dim servicio_control As Integer = 0
        Dim comentario As String = ""
        Dim cometareiopro As String = ""

        If grdcaptura.Rows(index).Cells(0).Value.ToString() = "" Then Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Control_Servicios'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    servicio_control = rd1("NumPart").ToString()
                End If
            Else
                servicio_control = 0
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from VentasDetalle where Folio=" & cbofolio.Text & " and Codigo='" & grdcaptura.Rows(index).Cells(0).Value.ToString() & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    comentario = rd1("CostVR").ToString()
                    cometareiopro = rd1("Comentario").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If servicio_control = 1 Then
            frmControlServ.txtcodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString()
            frmControlServ.cbonombre.Text = grdcaptura.Rows(index).Cells(1).Value.ToString()
            frmControlServ.txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString()
            frmControlServ.txtcantidad.Text = grdcaptura.Rows(index).Cells(3).Value.ToString()
            frmControlServ.txtComentario.Text = cometareiopro
            frmControlServ.txtproceso.Text = comentario
            frmControlServ.lblfolio.Text = cbofolio.Text
            My.Application.DoEvents()
            frmControlServ.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim formato As String = ""
        Dim tamimpre As String = ""
        Dim imp_ticket As String = ""
        cnn2.Close() : cnn2.Open()


        formato = "TICKET"


        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                tamimpre = rd2(0).ToString
            End If
        End If
        rd2.Close()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                imp_ticket = rd2(0).ToString()
            End If
        End If
        rd2.Close()

        If formato = "TICKET" Then
            If tamimpre = "80" Then
                If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                PCAbono80.PrinterSettings.PrinterName = imp_ticket
                PCAbono80.Print()
            Else
                If imp_ticket = "" Then MsgBox("No hay una impresora configurada para imprimir la copia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                PCAbono58.PrinterSettings.PrinterName = imp_ticket
                PCAbono58.Print()
            End If
        End If
        cnn2.Close()

    End Sub

    Private Sub PCAbono80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCAbono80.PrintPage

        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
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

        Try

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 100
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                        Y += 100
                    End If
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
            e.Graphics.DrawString("COPIA DE ABONO", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(lblfechaventa.Text, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(lblhoraventa.Text, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
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

            For dx As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(dx).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(dx).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(dx).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(dx).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(dx).Cells(1).Value.ToString()
                Dim unidad As String = IIf(grdcaptura.Rows(dx).Cells(2).Value.ToString() = "", "PZA", grdcaptura.Rows(dx).Cells(2).Value.ToString())
                Dim canti As Double = grdcaptura.Rows(dx).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(dx).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(dx).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 21
                If descuento <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next

            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 18

            e.Graphics.DrawString(convLetras(txttotal.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Restaba:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            If CDbl(abonoa) > 0 Then
                e.Graphics.DrawString("Monto:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(abonoa, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            'If CDbl(txtresta.Text) > 0 Then
            e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 13.5
            'End If

            If formaa <> "" Then
                e.Graphics.DrawString("Forma de Pago:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(formaa, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            If bancoa <> "" Then
                e.Graphics.DrawString("Banco:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(bancoa, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            If referenciaa <> "" Then
                e.Graphics.DrawString("Referencia:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(referenciaa, fuente_prods, Brushes.Black, 285, Y, sf)
                Y += 13.5
            End If

            Dim caracteresPorLinea As Integer = 30
            Dim texto As String = Pie
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                Y += 15
                inicio += caracteresPorLinea
            End While

            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            e.HasMorePages = False
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try


    End Sub

    Private Sub grdAbonos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdAbonos.CellClick
        Dim celda As DataGridViewCellEventArgs = e

        If celda.ColumnIndex = 0 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 1 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 2 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 3 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 4 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True

        End If

        If celda.ColumnIndex = 5 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 6 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 7 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 8 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If

        If celda.ColumnIndex = 9 Then
            abonoa = grdAbonos.CurrentRow.Cells(2).Value.ToString
            formaa = grdAbonos.CurrentRow.Cells(3).Value.ToString
            bancoa = grdAbonos.CurrentRow.Cells(4).Value.ToString
            referenciaa = grdAbonos.CurrentRow.Cells(5).Value.ToString
            Button2.Enabled = True
        End If
    End Sub

    Private Sub PCAbono58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCAbono58.PrintPage

        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
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

        Try


            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 120)
                    Y += 100
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 100
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
                        Y += 11
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
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
            e.Graphics.DrawString("COPIA DE NOTA DE ABONO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & cbofolio.Text, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(lblfechaventa.Text, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatDateTime(lblhoraventa.Text, DateFormat.LongTime), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 19

            '[2]. Datos del cliente
            If cbonombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cbonombre.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(cbonombre.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(cbonombre.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 3
                If txtdireccion.Text <> "" Then
                    e.Graphics.DrawString(Mid(txtdireccion.Text, 1, 35), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(txtdireccion.Text, 36, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 36, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                    If Mid(txtdireccion.Text, 71, 35) <> "" Then
                        e.Graphics.DrawString(Mid(txtdireccion.Text, 71, 35), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            Else
                Y += 4
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 130, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            Dim total_prods As Double = 0
            For dx As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(dx).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(dx).Cells(0).Value.ToString = "" Then
                    Y -= 5
                    e.Graphics.DrawString(grdcaptura.Rows(dx).Cells(1).Value.ToString(), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                    Y += 21
                    Continue For
                End If
                Dim codigo As String = grdcaptura.Rows(dx).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(dx).Cells(1).Value.ToString()
                Dim unidad As String = IIf(grdcaptura.Rows(dx).Cells(2).Value.ToString() = "", "PZA", grdcaptura.Rows(dx).Cells(2).Value.ToString())
                Dim canti As Double = grdcaptura.Rows(dx).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(dx).Cells(4).Value.ToString()
                Dim descuento As Double = grdcaptura.Rows(dx).Cells(5).Value.ToString()

                Dim total As Double = FormatNumber(canti * precio, 2)

                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 25
                Dim texto As String = nombre
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, fuente_prods, Brushes.Black, 30, Y)
                    Y += 12.5
                    inicio += caracteresPorLinea
                End While

                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 15, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 25, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 120, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                If descuento <> 0 Then
                    Y -= 4
                    e.Graphics.DrawString("Descuento: %" & descuento, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                    Y += 12
                End If
                total_prods = total_prods + canti
            Next

            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txttotal.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            Dim caracteresPorLinea11 As Integer = 25
            Dim texto11 As String = convLetras(txttotal.Text)
            Dim inicio11 As Integer = 0
            Dim longitudTexto11 As Integer = texto11.Length

            While inicio11 < longitudTexto11
                Dim longitudBloque11 As Integer = Math.Min(caracteresPorLinea11, longitudTexto11 - inicio11)
                Dim bloque11 As String = texto11.Substring(inicio11, longitudBloque11)
                e.Graphics.DrawString(bloque11, New Font("Arial", 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 18
                inicio11 += caracteresPorLinea11
            End While

            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Restaba:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            If CDbl(abonoa) > 0 Then
                e.Graphics.DrawString("Monto:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(abonoa, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 12
            End If

            If CDbl(txtresta.Text) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(txtresta.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13.5
            End If

            If formaa <> "" Then
                e.Graphics.DrawString("Forma de Pago:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(formaa, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13.5
            End If

            If bancoa <> "" Then
                e.Graphics.DrawString("Banco:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(bancoa, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13.5
            End If

            If referenciaa <> "" Then
                e.Graphics.DrawString("Referencia:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(referenciaa, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 13.5
            End If

            Dim caracteresPorLinea1 As Integer = 30
            Dim texto1 As String = Pie
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                Y += 15
                inicio1 += caracteresPorLinea1
            End While

            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            cnn1.Close()
            e.HasMorePages = False
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As EventArgs) Handles txtefectivo.TextChanged

        If (optcobrar.Checked) Then
            If txtefectivo.Text = "" Then Exit Sub
            If txtpagos.Text = "" Then Exit Sub
            If txtresta.Text = "" Then Exit Sub
            If txtrestaabono.Text = "" Then Exit Sub
            If txtcambio.Text = "" Then Exit Sub
            If txtdescu.Text = "" Then Exit Sub

            Dim resta As Double = 0
            resta = (CDbl(txtresta.Text) - (CDbl(txtefectivo.Text) + CDbl(txtpagos.Text))) - CDbl(txtdescu.Text)
            If resta >= 0 Then
                txtrestaabono.Text = FormatNumber(resta, 2)
                txtcambio.Text = "0.00"
            Else
                txtrestaabono.Text = "0.00"
                txtcambio.Text = FormatNumber(Math.Abs(resta), 2)
            End If
        End If
    End Sub

    Private Sub optPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles optPedidos.CheckedChanged
        If (optPedidos.Checked) Then

            grdAbonos.Rows.Clear()
            Borra()
            cbonombre.Items.Clear()
            cbonombre.Text = ""

            cbofolio.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT DISTINCT Cliente FROM CotPed"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbonombre.Items.Add(rd1(0).ToString())
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            btnCopia.Visible = True
            btnAbono.Visible = True
            btnCancela.Visible = False
            btnVentas.Visible = True
            lblNumCliente.Text = "MOSTRADOR"
            boxpagos.Enabled = True
            txtefectivo.Enabled = True
            txtefectivo.Text = "0.00"
        End If
    End Sub
End Class