Imports Core.DAL.Addendas

Public Class frmHisClinica

    Dim motivo As String = ""
    Private Sub frmHisClinica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT MAX(Folio) FROM ventas"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                lblNumCita.Text = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) + 1
            End If
        Else
            lblNumCita.Text = 1
        End If
        rd2.Close()
        cnn2.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblFecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
        lblHora.Text = FormatDateTime(Date.Now, DateFormat.LongTime)
    End Sub

    Private Sub cboMedicos_DropDown(sender As Object, e As EventArgs) Handles cboMedicos.DropDown
        Try
            cboMedicos.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' AND Puesto='MEDICO' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMedicos.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
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
            txtCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecio.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim cantidad As Double = 1
            Dim total As Double = 0

            total = CDec(cantidad) * CDec(txtPrecio.Text)
            grdCaptura.Rows.Add(txtNotacion.Text,
                                txtdiente.Text,
                                txtCodigo.Text,
                                cboDescripcion.Text,
                                FormatNumber(cantidad, 2),
                                FormatNumber(txtPrecio.Text, 2),
                                FormatNumber(total, 2))

            txtTotalP.Text = txtTotalP.Text + CDec(total)
            txtTotalP.Text = FormatNumber(txtTotalP.Text, 2)

            txtCodigo.Text = ""
            cboDescripcion.Text = ""
            txtPrecio.Text = "0.00"

        End If
    End Sub

    Private Sub cboDescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,PrecioVentaIVA FROM productos WHERE Nombre='" & cboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCodigo.Text = rd1("Codigo").ToString
                    txtPrecio.Text = rd1("PrecioVentaIVA").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnd1_Click(sender As Object, e As EventArgs) Handles btnd1.Click
        txtNotacion.Text = "18"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub btnd2_Click(sender As Object, e As EventArgs) Handles btnd2.Click
        txtNotacion.Text = "17"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd3_Click(sender As Object, e As EventArgs) Handles btnd3.Click
        txtNotacion.Text = "16"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd4_Click(sender As Object, e As EventArgs) Handles btnd4.Click
        txtNotacion.Text = "15"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd5_Click(sender As Object, e As EventArgs) Handles btnd5.Click
        txtNotacion.Text = "14"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd6_Click(sender As Object, e As EventArgs) Handles btnd6.Click
        txtNotacion.Text = "13"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd7_Click(sender As Object, e As EventArgs) Handles btnd7.Click
        txtNotacion.Text = "12"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd8_Click(sender As Object, e As EventArgs) Handles btnd8.Click
        txtNotacion.Text = "11"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub btnd9_Click(sender As Object, e As EventArgs) Handles btnd9.Click
        txtNotacion.Text = "21"
        txtdiente.Text = "incisivo Central"
    End Sub

    Private Sub btnd10_Click(sender As Object, e As EventArgs) Handles btnd10.Click
        txtNotacion.Text = "22"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd11_Click(sender As Object, e As EventArgs) Handles btnd11.Click
        txtNotacion.Text = "23"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd12_Click(sender As Object, e As EventArgs) Handles btnd12.Click
        txtNotacion.Text = "24"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd13_Click(sender As Object, e As EventArgs) Handles btnd13.Click
        txtNotacion.Text = "25"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd14_Click(sender As Object, e As EventArgs) Handles btnd14.Click
        txtNotacion.Text = "26"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd15_Click(sender As Object, e As EventArgs) Handles btnd15.Click
        txtNotacion.Text = "27"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd16_Click(sender As Object, e As EventArgs) Handles btnd16.Click
        txtNotacion.Text = "28"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub btnd17_Click(sender As Object, e As EventArgs) Handles btnd17.Click
        txtNotacion.Text = "48"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub btnd18_Click(sender As Object, e As EventArgs) Handles btnd18.Click
        txtNotacion.Text = "47"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd19_Click(sender As Object, e As EventArgs) Handles btnd19.Click
        txtNotacion.Text = "46"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd20_Click(sender As Object, e As EventArgs) Handles btnd20.Click
        txtNotacion.Text = "45"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd21_Click(sender As Object, e As EventArgs) Handles btnd21.Click
        txtNotacion.Text = "44"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd22_Click(sender As Object, e As EventArgs) Handles btnd22.Click
        txtNotacion.Text = "43"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd23_Click(sender As Object, e As EventArgs) Handles btnd23.Click
        txtNotacion.Text = "42"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd24_Click(sender As Object, e As EventArgs) Handles btnd24.Click
        txtNotacion.Text = "41"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub btnd25_Click(sender As Object, e As EventArgs) Handles btnd25.Click
        txtNotacion.Text = "31"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub btnd26_Click(sender As Object, e As EventArgs) Handles btnd26.Click
        txtNotacion.Text = "32"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd27_Click(sender As Object, e As EventArgs) Handles btnd27.Click
        txtNotacion.Text = "33"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd28_Click(sender As Object, e As EventArgs) Handles btnd28.Click
        txtNotacion.Text = "34"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd29_Click(sender As Object, e As EventArgs) Handles btnd29.Click
        txtNotacion.Text = "35"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd30_Click(sender As Object, e As EventArgs) Handles btnd30.Click
        txtNotacion.Text = "36"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd31_Click(sender As Object, e As EventArgs) Handles btnd31.Click
        txtNotacion.Text = "37"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd32_Click(sender As Object, e As EventArgs) Handles btnd32.Click
        txtNotacion.Text = "38"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim index As Integer = grdCaptura.CurrentRow.Index

        Dim tot As Double = grdCaptura.Rows(index).Cells(6).Value.ToString

        txtTotalP.Text = txtTotalP.Text - CDec(tot)

        grdCaptura.Rows.Remove(grdCaptura.Rows(index))
    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
        Dim MyOpe As Double = CDbl(IIf(txtTotalP.Text = "", "0", txtTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))
        If MyOpe < 0 Then
            txtCambio.Text = FormatNumber(-MyOpe, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
    End Sub

    Private Sub txtEfectivo_Click(sender As Object, e As EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_GotFocus(sender As Object, e As EventArgs) Handles txtEfectivo.GotFocus
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "" : Exit Sub
        If txtEfectivo.Text = "" And AscW(e.KeyChar) = 46 Then
            txtEfectivo.Text = "0.00"
            txtEfectivo.SelectionStart = 0
            txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
            txtEfectivo.Focus().Equals(True)
        End If

        If AscW(e.KeyChar) = Keys.Enter Then
            txtEfectivo.Text = FormatNumber(txtEfectivo.Text, 2)
            Dim MyOpe As Double = CDbl(IIf(txtTotalP.Text = "", "0", txtTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))
            If MyOpe < 0 Then
                txtCambio.Text = FormatNumber(-MyOpe, 2)
                txtResta.Text = "0.00"
            Else
                txtResta.Text = FormatNumber(MyOpe, 2)
                txtCambio.Text = "0.00"
            End If
            txtCambio.Text = FormatNumber(txtCambio.Text, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)
            btnPagar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If txtdiente.Text = "" Then MsgBox("Seleccione un diente", vbInformation + vbOKOnly, titulocentral) : Exit Sub
            If cboMedicos.Text = "" Then MsgBox("Seleccione un medico", vbInformation + vbOKOnly, titulocentral) : Exit Sub

            If grdCaptura.Rows.Count < 1 Then MsgBox("Seleccione un producto", vbInformation + vbOKOnly, titulocentral) : Exit Sub


            Dim total As Double = 0
            Dim acuenta As Double = 0
            Dim efectivo As Double = 0
            Dim cambio As Double = 0
            Dim resta As Double = 0

            Dim folio As Integer = 0
            Dim IVA As Double = 0
            Dim totiva As Double = 0
            Dim ivaporpro As Double = 0
            Dim IVATOTAL As Double = 0
            Dim SUBTOTAL As Double = 0
            Dim status As String = ""

            Dim ope1 As Double = 0
            Dim Car As Integer = 0
            Dim letters As String = ""
            Dim Numeros As String = ""
            Dim Letras As String = ""
            Dim lic As String = ""
            Dim CodCadena As String = ""
            Dim cadena As String = ""

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

            Dim MYSALDO As Double = 0

            total = txtTotalP.Text
            cambio = FormatNumber(txtCambio.Text, 2)
            efectivo = txtEfectivo.Text
            acuenta = FormatNumber(CDec(efectivo) - CDec(cambio), 2)
            resta = txtResta.Text

            If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then cnn1.Close() : Exit Sub


            cnn1.Close() : cnn1.Open()
            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                Dim cod As String = grdCaptura.Rows(luffy).Cells(2).Value.ToString
                Dim tot As Double = grdCaptura.Rows(luffy).Cells(6).Value.ToString

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IVA from  productos WHERE Codigo='" & cod & "'"
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
            SUBTOTAL = FormatNumber(CDec(txtTotalP.Text) - CDec(IVATOTAL), 2)

            ope1 = Math.Cos(CDbl(lblNumCita.Text))
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
                Numeros = Mid(lblNumCita.Text, w, 4)
                Letras = Mid(letters, w, 4)
                lic = lic & Numeros & Letras & "-"
            Next
            lic = Strings.Left(lic, Len(lic) - 1)
            CodCadena = lic
            CodCadena = Trim(CodCadena)

            If txtResta.Text > 0 Then
                status = "RESTA"
            Else
                status = "PAGADO"
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO ventas(IdCliente,Cliente,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,FVenta,HVenta,Fpago,Status,FEntrega,CodFactura,IP,Formato,Fecha) VALUES('" & txtId.Text & "','" & txtNombre.Text & "'," & SUBTOTAL & "," & IVATOTAL & "," & total & "," & acuenta & "," & resta & ",'','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & status & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & CodCadena & "','" & dameIP2() & "','TICKET','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO hisclinicadental(Fecha,Hora,FechaC,Medico,IdCliente,Paciente,Edad,Sexo,Motivo,Total,ACuenta,Cambio,Resta) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & lblHora.Text & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & cboMedicos.Text & "'," & txtId.Text & ",'" & txtNombre.Text & "','" & txtEdad.Text & "','" & txtSexo.Text & "','" & motivo & "'," & total & "," & acuenta & "," & cambio & "," & resta & ")"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT MAX(Id) FROM hisclinicadental"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    folio = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
                End If
            Else
                folio = 1
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT MAX(Folio) FROM ventas"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    lblNumCita.Text = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
                End If
            Else
                lblNumCita.Text = 1
            End If
            rd2.Close()
            cnn2.Close()

            If acuenta > 0 Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & txtNombre.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + txtTotalP.Text, 2)
                    End If
                Else
                    MYSALDO = FormatNumber(txtTotalP.Text, 2)
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & MyFolio & "," & txtId.Text & ",'" & txtNombre.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "'," & total & ",0," & MYSALDO & ",'','','',0,'')"
                cmd1.ExecuteNonQuery()

                MYSALDO = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & txtNombre.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - acuenta, 2)
                    End If
                Else
                    MYSALDO = FormatNumber(txtTotalP.Text, 2)
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Abono,Saldo,FormaPago,Monto) VALUES(" & lblNumCita.Text & "," & txtId.Text & ",'" & txtNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & acuenta & "'," & MYSALDO & ",'EFECTIVO'," & acuenta & ")"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

            End If


            cnn2.Close() : cnn2.Open()

            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                Dim notacion As String = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                Dim diente As String = grdCaptura.Rows(luffy).Cells(1).Value.ToString
                Dim codigo As String = grdCaptura.Rows(luffy).Cells(2).Value.ToString
                Dim descripcion As String = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                Dim cantidad As Double = grdCaptura.Rows(luffy).Cells(4).Value.ToString
                Dim precio As Double = grdCaptura.Rows(luffy).Cells(5).Value.ToString
                Dim totalp As Double = grdCaptura.Rows(luffy).Cells(6).Value.ToString

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT UVenta,MCD,PrecioCompra,Departamento,Grupo,IVA,Multiplo FROM productos WHERE Codigo='" & codigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        uventa = rd2("UVenta").ToString
                        mymcd = rd2("MCD").ToString
                        mymultiplo = rd2("Multiplo").ToString
                        depto = rd2("Departamento").ToString
                        grupo = rd2("Grupo").ToString
                        preciocompra = rd2("PrecioCompra").ToString
                        MYCOSTVUE = preciocompra * (cantidad / mymcd)
                        IVAP = rd2("IVA").ToString
                    End If
                End If
                rd2.Close()

                If IVAP > 0 Then
                    PrecioSiniVA = precio / (1 + IVAP)
                    TotalSinIVA = totalp / (1 + IVAP)
                Else

                End If


                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO ventasdetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVUE,Precio,Total,PrecioSinIVA,TotalSiniVA,Fecha,FechaCompleta,Depto,Grupo) VALUES(" & lblNumCita.Text & ",'" & codigo & "','" & descripcion & "','" & uventa & "'," & cantidad & "," & MYCOSTVUE & "," & precio & "," & total & "," & PrecioSiniVA & "," & TotalSinIVA & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & depto & "','" & grupo & "')"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO hisclinicadentaldet(Folio,Notacion,Diente,Codigo,Descripcion,Cantidad,Precio,Total,Fecha) VALUES(" & folio & ",'" & notacion & "','" & diente & "','" & codigo & "','" & descripcion & "'," & cantidad & "," & precio & "," & totalp & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
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

            Next
            cnn1.Close()
            cnn2.Close()

            Dim tamticket As Integer = TamImpre()
            Dim tampapel As String = TraerFormatoImpresion()
            Dim IMPRESORA As String = ImpresoraImprimir()

            If tampapel = "TICKET" Then
                If TamImpre() = "80" Then
                    PDentista80.DefaultPageSettings.PrinterSettings.PrinterName = IMPRESORA
                    PDentista80.Print()
                End If

                If TamImpre() = "58" Then
                    pDentista58.DefaultPageSettings.PrinterSettings.PrinterName = IMPRESORA
                    pDentista58.Print()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnMotivo_Click(sender As Object, e As EventArgs) Handles btnMotivo.Click
        gbxMotivo.Visible = True
        rbMotivo.Focus.Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gbxMotivo.Visible = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        motivo = rbMotivo.Text
        gbxMotivo.Visible = False
    End Sub

    Private Sub PDentista80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PDentista80.PrintPage

    End Sub

    Private Sub pDentista58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pDentista58.PrintPage

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        grdCaptura.Rows.Clear()
        txtNotacion.Text = ""
        txtdiente.Text = ""
        rbMotivo.Text = ""
        txtTotalP.Text = "0.00"
        txtEfectivo.Text = "0.00"
        txtResta.Text = "0.00"
        txtCambio.Text = "0.00"
    End Sub
End Class