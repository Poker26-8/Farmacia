Imports System.Runtime.InteropServices.ComTypes
Imports Chilkat
Imports Core.DAL.Addendas

Public Class frmPagarD

    Public efectivo As Double = 0
    Public tarjeta As Double = 0
    Public transferencia As Double = 0
    Public otros As Double = 0
    Public cambio As Double = 0
    Public resta As Double = 0

    Private Sub frmPagarD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim MYSALDO As Double = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Credito,SaldoFavor FROM clientes WHERE Nombre='" & lblCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblcredito.Text = rd1("Credito").ToString
                    lblSaldoFavor.Text = FormatNumber(rd1("SaldoFavor").ToString(), 4)
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo FROM AbonoI WHERE Id=(SELECT max(Id) FROM AbonoI WHERE Cliente='" & lblCliente.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.HasRows Then
                    MYSALDO = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                    If MYSALDO > 0 Then
                        lblAdeudo.Text = Math.Abs(MYSALDO)
                        lblAdeudo.Text = FormatNumber(lblAdeudo.Text, 4)
                    Else
                        lblAdeudo.Text = "0.00"
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Private Sub lblTotal_TextChanged(sender As Object, e As EventArgs) Handles lblTotalP.TextChanged

        If lblTotalP.Text = "" Then Exit Sub
        Dim TotalImporte As Double = lblTotalP.Text
        Dim CantidadLetra As String = ""
        If TotalImporte > 0 Then

            CantidadLetra = UCase(convLetras(TotalImporte))
        Else

            CantidadLetra = ""
        End If
        lblLetras.Text = CantidadLetra

    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTarjeta.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtTransferencia_TextChanged(sender As Object, e As EventArgs) Handles txtTransferencia.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtOtros_TextChanged(sender As Object, e As EventArgs) Handles txtOtros.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pCredito.Visible = True
        Me.Size = New Size(500, 562)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pCredito.Visible = False
        Me.Size = New Size(500, 487)
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjeta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTransferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtOtros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOtros.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then cnn1.Close() : Exit Sub

        Dim total As Double = 0
        Dim acuenta As Double = 0


        Dim IVA As Double = 0
        Dim totiva As Double = 0
        Dim ivaporpro As Double = 0
        Dim IVATOTAL As Double = 0
        Dim SUBTOTAL As Double = 0

        Dim ope1 As Double = 0
        Dim Car As Integer = 0
        Dim letters As String = ""
        Dim Numeros As String = ""
        Dim Letras As String = ""
        Dim lic As String = ""
        Dim CodCadena As String = ""
        Dim cadena As String = ""

        Dim status As String = ""
        Dim folioventa As Integer = 0
        Dim MYSALDO As Double = 0

        Dim uventa As String = ""
        Dim preciocompra As Double = 0
        Dim MYCOSTVUE As Double = 0
        Dim mymcd As Double = 0
        Dim mymultiplo As Double = 0
        Dim depto As String = ""
        Dim grupo As String = ""
        Dim IVAP As Double = 0
        Dim PrecioSiniVA As Double = 0
        Dim TotalSinIVA As Double = 0
        Dim exispro As Double = 0
        Dim myexistencia As Double = 0
        Dim existencia As Double = 0
        Dim existencia2 As Double = 0
        Dim kit As Integer = 0

        total = lblTotalP.Text
        efectivo = txtEfectivo.Text
        tarjeta = txtTarjeta.Text
        transferencia = txtTransferencia.Text
        otros = txtOtros.Text

        If lbltitulo.ForeColor = Color.FromArgb(24, 108, 84) Then
            cambio = lblCambio.Text
        End If

        If lbltitulo.ForeColor = Color.FromArgb(194, 45, 43) Then
            resta = lblCreditoCli.Text
        End If
        acuenta = FormatNumber(CDec(efectivo) + CDec(tarjeta) + CDec(transferencia) + CDec(otros) - CDec(cambio), 2)



        cnn1.Close() : cnn1.Open()
        For luffy As Integer = 0 To frmHisClinica.grdCaptura.Rows.Count - 1

            Dim cod As String = frmHisClinica.grdCaptura.Rows(luffy).Cells(2).Value.ToString
            Dim tot As Double = frmHisClinica.grdCaptura.Rows(luffy).Cells(6).Value.ToString

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IVA from productos WHERE Codigo='" & cod & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If IVA > 0 Then
                        totiva = CDec(tot) / (1 + 0.16)
                        ivaporpro = CDec(tot) - CDec(totiva)
                        IVATOTAL = IVATOTAL + CDec(ivaporpro)

                    End If
                End If
            End If
            rd1.Close()
        Next
        cnn1.Close()

        IVATOTAL = FormatNumber(IVATOTAL, 2)
        SUBTOTAL = FormatNumber(CDec(lblTotalP.Text) - CDec(IVATOTAL), 2)

        ope1 = Math.Cos(CDbl(frmHisClinica.lblNumCita.Text))
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
            Numeros = Mid(frmHisClinica.lblNumCita.Text, w, 4)
            Letras = Mid(letters, w, 4)
            lic = lic & Numeros & Letras & "-"
        Next
        lic = Strings.Left(lic, Len(lic) - 1)
        CodCadena = lic
        CodCadena = Trim(CodCadena)

        If resta > 0 Then
            status = "RESTA"
        Else
            status = "PAGADO"
        End If

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "INSERT INTO ventas(IdCliente,Cliente,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,FVenta,HVenta,Fpago,Status,FEntrega,CodFactura,IP,Formato,Fecha) VALUES('" & frmHisClinica.txtId.Text & "','" & lblCliente.Text & "'," & SUBTOTAL & "," & IVATOTAL & "," & total & "," & acuenta & "," & resta & ",'" & frmHisClinica.lblUsuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & status & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & CodCadena & "','" & dameIP2() & "','TICKET','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
        cmd1.ExecuteNonQuery()
        cnn1.Close()

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT MAX(Folio) FROM ventas"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                folioventa = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
            End If
        Else
            folioventa = 1
        End If
        rd2.Close()
        cnn2.Close()

        If acuenta > 0 Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & lblCliente.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + lblTotalP.Text, 2)
                End If
            Else
                MYSALDO = FormatNumber(lblTotalP.Text, 2)
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & folioventa & "," & frmHisClinica.txtId.Text & ",'" & lblCliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "'," & total & ",0," & MYSALDO & ",'','','" & frmHisClinica.lblUsuario.Text & "',0,'')"
            cmd1.ExecuteNonQuery()

            MYSALDO = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & lblCliente.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - acuenta, 2)
                End If
            Else
                MYSALDO = FormatNumber(lblTotalP.Text, 2)
            End If
            rd1.Close()

            If txtEfectivo.Text > 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Abono,Saldo,FormaPago,Monto,Usuario) VALUES(" & folioventa & "," & frmHisClinica.txtId.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & efectivo & "'," & MYSALDO & ",'EFECTIVO'," & efectivo & ",'" & frmHisClinica.lblUsuario.Text & "')"
                cmd1.ExecuteNonQuery()
            End If

            If txtTarjeta.Text > 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Abono,Saldo,FormaPago,Monto,Usuario) VALUES(" & folioventa & "," & frmHisClinica.txtId.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & tarjeta & "'," & MYSALDO & ",'TARJETA'," & tarjeta & ",'" & frmHisClinica.lblUsuario.Text & "')"
                cmd1.ExecuteNonQuery()
            End If

            If txtTransferencia.Text > 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Abono,Saldo,FormaPago,Monto,Usuario) VALUES(" & folioventa & "," & frmHisClinica.txtId.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & transferencia & "'," & MYSALDO & ",'TRANSFERENCIA'," & transferencia & ",'" & frmHisClinica.lblUsuario.Text & "')"
                cmd1.ExecuteNonQuery()
            End If

            If txtOtros.Text > 0 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Abono,Saldo,FormaPago,Monto,Usuario) VALUES(" & folioventa & "," & frmHisClinica.txtId.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & otros & "'," & MYSALDO & ",'OTROS'," & otros & ",'" & frmHisClinica.lblUsuario.Text & "')"
                cmd1.ExecuteNonQuery()
            End If

            cnn1.Close()

            cnn2.Close() : cnn2.Open()
        End If

        For luffy As Integer = 0 To frmHisClinica.grdCaptura.Rows.Count - 1

            Dim notacion As String = frmHisClinica.grdCaptura.Rows(luffy).Cells(0).Value.ToString
            Dim diente As String = frmHisClinica.grdCaptura.Rows(luffy).Cells(1).Value.ToString
            Dim codigo As String = frmHisClinica.grdCaptura.Rows(luffy).Cells(2).Value.ToString
            Dim descripcion As String = frmHisClinica.grdCaptura.Rows(luffy).Cells(3).Value.ToString
            Dim cantidad As Double = frmHisClinica.grdCaptura.Rows(luffy).Cells(4).Value.ToString
            Dim precio As Double = frmHisClinica.grdCaptura.Rows(luffy).Cells(5).Value.ToString
            Dim totalp As Double = frmHisClinica.grdCaptura.Rows(luffy).Cells(6).Value.ToString

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT UVenta,MCD,PrecioCompra,Departamento,Grupo,IVA,Multiplo,Existencia,ProvRes FROM productos WHERE Codigo='" & codigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    uventa = rd2("UVenta").ToString
                    mymcd = rd2("MCD").ToString
                    mymultiplo = rd2("Multiplo").ToString
                    depto = rd2("Departamento").ToString
                    grupo = rd2("Grupo").ToString
                    exispro = rd2("Existencia").ToString
                    existencia = exispro / mymultiplo
                    IVAP = rd2("IVA").ToString
                    kit = rd2("ProvRes").ToString

                    If CStr(rd2("Departamento").ToString()) = "SERVICIOS" Then
                        preciocompra = rd2("PrecioCompra").ToString
                        MYCOSTVUE = preciocompra * (cantidad / mymcd)
                    End If
                End If
            End If
            rd2.Close()

            If IVAP > 0 Then
                PrecioSiniVA = precio / (1 + IVAP)
                TotalSinIVA = totalp / (1 + IVAP)
            Else
                PrecioSiniVA = precio
                TotalSinIVA = totalp
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO ventasdetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVUE,Precio,Total,PrecioSinIVA,TotalSiniVA,Fecha,FechaCompleta,Depto,Grupo) VALUES(" & folioventa & ",'" & codigo & "','" & descripcion & "','" & uventa & "'," & cantidad & "," & MYCOSTVUE & "," & precio & "," & totalp & "," & PrecioSiniVA & "," & TotalSinIVA & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & depto & "','" & grupo & "')"
            cmd1.ExecuteNonQuery()
            Dim nuevaexistencia As Double = 0
            If mymultiplo > 1 And mymcd > 1 Then
                nuevaexistencia = FormatNumber(CDec(cantidad) * CDec(mymultiplo), 2)
            Else
                nuevaexistencia = FormatNumber(CDec(cantidad) * CDec(mymultiplo), 2)
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE Productos SET CargadoInv=0, Cargado=0, Existencia=Existencia - " & nuevaexistencia & " WHERE Codigo='" & Strings.Left(codigo, 6) & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Existencia FROM Productos WHERE Codigo='" & Strings.Left(codigo, 6) & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    existencia2 = rd1(0).ToString
                End If
            End If
            rd1.Close()

            If Len(codigo) = 6 Then
                myexistencia = FormatNumber(existencia2 / mymultiplo, 2)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & descripcion & "','Venta'," & existencia & "," & cantidad & "," & myexistencia & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & frmHisClinica.lblUsuario.Text & "','" & MyFolio & "','','','','" & frmHisClinica.cboMedicos.Text & "','')"
                cmd1.ExecuteNonQuery()
            Else
                myexistencia = FormatNumber(CDec(existencia - cantidad) / CDec(mymultiplo), 2)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & descripcion & "','Venta'," & existencia & "," & cantidad & "," & myexistencia & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & frmHisClinica.lblUsuario.Text & "','" & MyFolio & "','','','','" & frmHisClinica.cboMedicos.Text & "','')"
                cmd1.ExecuteNonQuery()
            End If
        Next
        rd1.Close()
        cnn1.Close()

        Dim tamticket As Integer = TamImpre()
        Dim tampapel As String = TraerFormatoImpresion()
        Dim IMPRESORA As String = ImpresoraImprimir()

        If tampapel = "TICKET" Then
            If TamImpre() = "80" Then
                frmHisClinica.PDentista80.DefaultPageSettings.PrinterSettings.PrinterName = IMPRESORA
                frmHisClinica.PDentista80.Print()
            End If

            If TamImpre() = "58" Then
                frmHisClinica.pDentista58.DefaultPageSettings.PrinterSettings.PrinterName = IMPRESORA
                frmHisClinica.pDentista58.Print()
            End If

        End If

        If cambio > 0 Then
            frmCambio.lblCambio.Text = lblCambio.Text
            frmCambio.BringToFront()
            frmCambio.Show()

            Me.Close()
            Limpia()

        Else
            Me.Close()
            Limpia()

        End If


    End Sub

    Public Sub Limpia()
        txtEfectivo.Text = "0.00"
        txtTarjeta.Text = "0.00"
        txtTransferencia.Text = "0.00"
        txtOtros.Text = "0.00"
        txtReferencia.Text = ""
        lblCreditoCli.Text = "0.00"
        lblCambio.Text = "0.00"
        lblcredito.Text = "0.00"
        lblAdeudo.Text = "0.00"
        lblSaldoFavor.Text = "0.00"
        lblLetras.Text = ""
        lblTotalP.Text = ""

        frmHisClinica.grdCaptura.Rows.Clear()
        frmHisClinica.txtTotalP.Text = "0.00"
        frmHisClinica.txtNotacion.Text = ""
        frmHisClinica.txtdiente.Text = ""
    End Sub
End Class