Imports Core.DAL.Addendas
Imports System.IO
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
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' AND Area='MEDICO' ORDER BY Nombre"
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



    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then


            If cboDescripcion.Text = "" Then Exit Sub
            If txtCodigo.Text = "" Then Exit Sub
            If txtdiente.Text = "" Then Exit Sub

            Dim cantidad As Double = txtCantidad.Text
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

            txtNotacion.Text = ""
            txtdiente.Text = ""

            cboDescripcion.Focus.Equals(True)
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
            Dim exispro As Double = 0
            Dim myexistencia As Double = 0
            Dim existencia As Double = 0
            Dim existencia2 As Double = 0
            Dim kit As Integer = 0

            Dim MYSALDO As Double = 0

            'total = txtTotalP.Text
            'cambio = FormatNumber(txtCambio.Text, 2)
            'efectivo = txtEfectivo.Text
            'acuenta = FormatNumber(CDec(efectivo) - CDec(cambio), 2)
            'resta = txtResta.Text

            If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then cnn1.Close() : Exit Sub


            'cnn1.Close() : cnn1.Open()
            'For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

            '    Dim cod As String = grdCaptura.Rows(luffy).Cells(2).Value.ToString
            '    Dim tot As Double = grdCaptura.Rows(luffy).Cells(6).Value.ToString

            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText = "SELECT IVA from  productos WHERE Codigo='" & cod & "'"
            '    rd1 = cmd1.ExecuteReader
            '    If rd1.HasRows Then
            '        If rd1.Read Then
            '            If IVA > 0 Then
            '                totiva = CDec(tot) / (1 + 0.16)
            '                ivaporpro = CDec(tot) - CDec(totiva)
            '                IVATOTAL = IVATOTAL + CDec(ivaporpro)

            '            End If
            '        End If
            '    End If
            '    rd1.Close()
            'Next
            'cnn1.Close()

            'IVATOTAL = FormatNumber(IVATOTAL, 2)
            'SUBTOTAL = FormatNumber(CDec(txtTotalP.Text) - CDec(IVATOTAL), 2)

            'ope1 = Math.Cos(CDbl(lblNumCita.Text))
            'If ope1 > 0 Then
            '    cadena = Strings.Left(Replace(CStr(ope1), ".", "9"), 10)
            'Else
            '    cadena = Strings.Left(Replace(CStr(Math.Abs(ope1)), ".", "8"), 10)
            'End If
            'For i = 1 To 10
            '    Car = Mid(cadena, i, 1)
            '    Select Case Car
            '        Case Is = 0
            '            letters = letters & "Y"
            '        Case Is = 1
            '            letters = letters & "Z"
            '        Case Is = 2
            '            letters = letters & "W"
            '        Case Is = 3
            '            letters = letters & "H"
            '        Case Is = 4
            '            letters = letters & "S"
            '        Case Is = 5
            '            letters = letters & "B"
            '        Case Is = 6
            '            letters = letters & "C"
            '        Case Is = 7
            '            letters = letters & "P"
            '        Case Is = 8
            '            letters = letters & "Q"
            '        Case Is = 9
            '            letters = letters & "A"
            '        Case Else
            '            letters = letters & Car
            '    End Select
            'Next
            'For w = 1 To 10 Step 2
            '    Numeros = Mid(lblNumCita.Text, w, 4)
            '    Letras = Mid(letters, w, 4)
            '    lic = lic & Numeros & Letras & "-"
            'Next
            'lic = Strings.Left(lic, Len(lic) - 1)
            'CodCadena = lic
            'CodCadena = Trim(CodCadena)

            'If txtResta.Text > 0 Then
            '    status = "RESTA"
            'Else
            '    status = "PAGADO"
            'End If

            cnn1.Close() : cnn1.Open()
            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText = "INSERT INTO ventas(IdCliente,Cliente,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,FVenta,HVenta,Fpago,Status,FEntrega,CodFactura,IP,Formato,Fecha) VALUES('" & txtId.Text & "','" & txtNombre.Text & "'," & SUBTOTAL & "," & IVATOTAL & "," & total & "," & acuenta & "," & resta & ",'" & lblUsuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & status & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & CodCadena & "','" & dameIP2() & "','TICKET','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
            'cmd1.ExecuteNonQuery()

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

            'cmd2 = cnn2.CreateCommand
            'cmd2.CommandText = "SELECT MAX(Folio) FROM ventas"
            'rd2 = cmd2.ExecuteReader
            'If rd2.HasRows Then
            '    If rd2.Read Then
            '        lblNumCita.Text = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
            '    End If
            'Else
            '    lblNumCita.Text = 1
            'End If
            'rd2.Close()
            cnn2.Close()

            'If acuenta > 0 Then

            '    cnn1.Close() : cnn1.Open()
            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText = "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & txtNombre.Text & "')"
            '    rd1 = cmd1.ExecuteReader
            '    If rd1.HasRows Then
            '        If rd1.Read Then
            '            MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + txtTotalP.Text, 2)
            '        End If
            '    Else
            '        MYSALDO = FormatNumber(txtTotalP.Text, 2)
            '    End If
            '    rd1.Close()

            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText = "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF,Comentario) values(" & MyFolio & "," & txtId.Text & ",'" & txtNombre.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "'," & total & ",0," & MYSALDO & ",'','','" & lblUsuario.Text & "',0,'')"
            '    cmd1.ExecuteNonQuery()

            '    MYSALDO = 0

            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText = "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & txtNombre.Text & "')"
            '    rd1 = cmd1.ExecuteReader
            '    If rd1.HasRows Then
            '        If rd1.Read Then
            '            MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - acuenta, 2)
            '        End If
            '    Else
            '        MYSALDO = FormatNumber(txtTotalP.Text, 2)
            '    End If
            '    rd1.Close()

            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Abono,Saldo,FormaPago,Monto,Usuario) VALUES(" & lblNumCita.Text & "," & txtId.Text & ",'" & txtNombre.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & acuenta & "'," & MYSALDO & ",'EFECTIVO'," & acuenta & ",'" & lblUsuario.Text & "')"
            '    cmd1.ExecuteNonQuery()
            '    cnn1.Close()

            'End If


            cnn2.Close() : cnn2.Open()

            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                Dim notacion As String = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                Dim diente As String = grdCaptura.Rows(luffy).Cells(1).Value.ToString
                Dim codigo As String = grdCaptura.Rows(luffy).Cells(2).Value.ToString
                Dim descripcion As String = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                Dim cantidad As Double = grdCaptura.Rows(luffy).Cells(4).Value.ToString
                Dim precio As Double = grdCaptura.Rows(luffy).Cells(5).Value.ToString
                Dim totalp As Double = grdCaptura.Rows(luffy).Cells(6).Value.ToString

                'cmd2 = cnn2.CreateCommand
                'cmd2.CommandText = "SELECT UVenta,MCD,PrecioCompra,Departamento,Grupo,IVA,Multiplo,Existencia,ProvRes FROM productos WHERE Codigo='" & codigo & "'"
                'rd2 = cmd2.ExecuteReader
                'If rd2.HasRows Then
                '    If rd2.Read Then
                '        uventa = rd2("UVenta").ToString
                '        mymcd = rd2("MCD").ToString
                '        mymultiplo = rd2("Multiplo").ToString
                '        depto = rd2("Departamento").ToString
                '        grupo = rd2("Grupo").ToString
                '        exispro = rd2("Existencia").ToString
                '        existencia = exispro / mymultiplo
                '        IVAP = rd2("IVA").ToString
                '        kit = rd2("ProvRes").ToString

                '        If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                '            preciocompra = rd2("PrecioCompra").ToString
                '            MYCOSTVUE = preciocompra * (cantidad / mymcd)
                '        End If
                '    End If
                'End If
                'rd2.Close()

                'If IVAP > 0 Then
                '    PrecioSiniVA = precio / (1 + IVAP)
                '    TotalSinIVA = totalp / (1 + IVAP)
                'Else
                '    PrecioSiniVA = precio
                '    TotalSinIVA = totalp
                'End If

                'cnn1.Close() : cnn1.Open()
                'cmd1 = cnn1.CreateCommand
                'cmd1.CommandText = "INSERT INTO ventasdetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVUE,Precio,Total,PrecioSinIVA,TotalSiniVA,Fecha,FechaCompleta,Depto,Grupo) VALUES(" & lblNumCita.Text & ",'" & codigo & "','" & descripcion & "','" & uventa & "'," & cantidad & "," & MYCOSTVUE & "," & precio & "," & totalp & "," & PrecioSiniVA & "," & TotalSinIVA & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & depto & "','" & grupo & "')"
                'cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO hisclinicadentaldet(Folio,Notacion,Diente,Codigo,Descripcion,Cantidad,Precio,Total,Fecha) VALUES(" & folio & ",'" & notacion & "','" & diente & "','" & codigo & "','" & descripcion & "'," & cantidad & "," & precio & "," & totalp & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
                cmd1.ExecuteNonQuery()

                'Dim nuevaexistencia As Double = 0
                'If mymultiplo > 1 And mymcd > 1 Then
                '    nuevaexistencia = FormatNumber(CDec(cantidad) * CDec(mymultiplo), 2)
                'Else
                '    nuevaexistencia = FormatNumber(CDec(cantidad) * CDec(mymultiplo), 2)
                'End If

                'cmd1 = cnn1.CreateCommand
                'cmd1.CommandText = "UPDATE Productos SET CargadoInv=0, Cargado=0, Existencia=Existencia - " & nuevaexistencia & " WHERE Codigo='" & Strings.Left(codigo, 6) & "'"
                'cmd1.ExecuteNonQuery()

                'cmd1 = cnn1.CreateCommand
                'cmd1.CommandText = "SELECT Existencia FROM Productos WHERE Codigo='" & Strings.Left(codigo, 6) & "'"
                'rd1 = cmd1.ExecuteReader
                'If rd1.HasRows Then
                '    If rd1.Read Then
                '        existencia2 = rd1(0).ToString
                '    End If
                'End If
                'rd1.Close()

                'If Len(codigo) = 6 Then
                '    myexistencia = FormatNumber(existencia2 / mymultiplo, 2)

                '    cmd1 = cnn1.CreateCommand
                '    cmd1.CommandText = "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & descripcion & "','Venta'," & existencia & "," & cantidad & "," & myexistencia & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblUsuario.Text & "','" & MyFolio & "','','','','" & cboMedicos.Text & "','')"
                '    cmd1.ExecuteNonQuery()
                'Else
                '    myexistencia = FormatNumber(CDec(existencia - cantidad) / CDec(mymultiplo), 2)

                '    cmd1 = cnn1.CreateCommand
                '    cmd1.CommandText =
                '        "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & descripcion & "','Venta'," & existencia & "," & cantidad & "," & myexistencia & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblUsuario.Text & "','" & MyFolio & "','','','','" & cboMedicos.Text & "','')"
                '    cmd1.ExecuteNonQuery()
                'End If

            Next
            cnn1.Close()
            cnn2.Close()

            'Dim tamticket As Integer = TamImpre()
            'Dim tampapel As String = TraerFormatoImpresion()
            'Dim IMPRESORA As String = ImpresoraImprimir()

            'If tampapel = "TICKET" Then
            '    If TamImpre() = "80" Then
            '        PDentista80.DefaultPageSettings.PrinterSettings.PrinterName = IMPRESORA
            '        PDentista80.Print()
            '    End If

            '    If TamImpre() = "58" Then
            '        pDentista58.DefaultPageSettings.PrinterSettings.PrinterName = IMPRESORA
            '        pDentista58.Print()
            '    End If

            'End If

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
        Dim pagare As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim total_prods As Double = 0
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

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie1,Pagare,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString
                    pagare = rd1("Pagare").ToString

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
            cnn1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("NOTA DE VENTA", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_datos, Brushes.Black, 280, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 280, Y, sf)
            Y += 19

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("MÉDICO", New Drawing.Font(tipografia, 18, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Nombre: " & Mid(cboMedicos.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Cedula: " & Mid(txtCedula.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
            Y += 17

            '[2]. Datos del cliente
            If txtNombre.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                Dim caracteresPorLinea11 As Integer = 36
                Dim texto11 As String = txtNombre.Text
                Dim inicio11 As Integer = 0
                Dim longitudTexto11 As Integer = texto11.Length

                While inicio11 < longitudTexto11
                    Dim longitudBloque11 As Integer = Math.Min(caracteresPorLinea11, longitudTexto11 - inicio11)
                    Dim bloque11 As String = texto11.Substring(inicio11, longitudBloque11)
                    e.Graphics.DrawString(bloque11, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 13
                    inicio11 += caracteresPorLinea11
                End While


            End If

            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 15
            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 195, Y, sf)
            e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            For miku As Integer = 0 To grdCaptura.Rows.Count - 1

                Dim num As String = grdCaptura.Rows(miku).Cells(0).Value.ToString()
                Dim diente As String = grdCaptura.Rows(miku).Cells(1).Value.ToString()
                Dim codigo As String = grdCaptura.Rows(miku).Cells(2).Value.ToString()
                Dim nombre As String = grdCaptura.Rows(miku).Cells(3).Value.ToString()
                Dim canti As Double = grdCaptura.Rows(miku).Cells(4).Value.ToString()
                Dim precio As Double = grdCaptura.Rows(miku).Cells(5).Value.ToString()
                Dim total As Double = grdCaptura.Rows(miku).Cells(6).Value.ToString

                e.Graphics.DrawString("N°: " & num, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString("Diente: " & num, fuente_prods, Brushes.Black, 52, Y)
                Y += 15
                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(Mid(nombre, 1, 48), fuente_prods, Brushes.Black, 52, Y)
                Y += 12.5
                e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 60, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 193, Y, sf)
                e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 15
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                total_prods = total_prods + canti
            Next
            Y += 5

            If rbMotivo.Text <> "" Then

                Dim comentariogen As String = ""
                comentariogen = rbMotivo.Text.TrimEnd(vbCrLf.ToCharArray)

                Dim caracteresPorLinea As Integer = 36
                Dim texto As String = comentariogen
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                    Y += 13
                    inicio += caracteresPorLinea
                End While
            End If

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 10, FontStyle.Regular), Brushes.Black, 140, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Total:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtTotalP.Text, 2), fuente_prods, Brushes.Black, 170, Y)
            Y += 18

            e.Graphics.DrawString(convLetras(txtTotalP.Text), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
            Y += 18

            If CDbl(frmPagarD.efectivo) > 0 Then
                e.Graphics.DrawString("Efectivo:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(frmPagarD.efectivo, 2), fuente_prods, Brushes.Black, 170, Y)
                Y += 20
            End If
            If CDbl(frmPagarD.cambio) > 0 Then
                e.Graphics.DrawString("Cambio:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(frmPagarD.cambio, 2), fuente_prods, Brushes.Black, 170, Y)
                Y += 20
            End If

            If CDbl(frmPagarD.resta) > 0 Then
                e.Graphics.DrawString("Resta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & FormatNumber(frmPagarD.resta, 2), fuente_prods, Brushes.Black, 170, Y)
                Y += 20
            End If

            'Imprime pie de página
            Dim cadena_pie As String = Pie
            Dim caracteresPorLinea1 As Integer = 47
            Dim texto1 As String = cadena_pie
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto1.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 7, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 16
                inicio1 += caracteresPorLinea1
            End While


            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

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

    Private Sub txtCodigo_DropDown(sender As Object, e As EventArgs) Handles txtCodigo.DropDown
        txtCodigo.Items.Clear()
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM Productos WHERE LEFT(Codigo, 6) = LEFT('" & txtCodigo.Text & "', 6) ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then txtCodigo.Items.Add(
                    rd5(0).ToString
                    )
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCantidad.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecio.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboMedicos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMedicos.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cedula FROM usuarios WHERE Nombre='" & cboMedicos.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCedula.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblUsuario.Text = rd1("Alias").ToString
                        btnGuardar.Focus().Equals(True)
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If cboMedicos.Text <> "" Then
            frmCitasD.lblMedicoC.Text = cboMedicos.Text
            frmCitasD.lblClienteC.Text = txtNombre.Text

            frmCitasD.BringToFront()
            frmCitasD.Show()
        End If

    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click

        If lblUsuario.Text = "" Then MsgBox("Ingrese la contraseña", vbInformation + vbOKOnly, titulocentral) : txtcontraseña.Focus.Equals(True) : Exit Sub
        If cboMedicos.Text = "" Then MsgBox("Seleccione un medico", vbInformation + vbOKOnly, titulocentral) : Exit Sub

        If grdCaptura.Rows.Count < 1 Then MsgBox("Seleccione un producto", vbInformation + vbOKOnly, titulocentral) : Exit Sub

        frmPagarD.lblTotalP.Text = txtTotalP.Text
        frmPagarD.lblCambio.Text = txtTotalP.Text
        frmPagarD.lblCliente.Text = txtNombre.Text
        frmPagarD.BringToFront()
        frmPagarD.Show()
    End Sub
End Class