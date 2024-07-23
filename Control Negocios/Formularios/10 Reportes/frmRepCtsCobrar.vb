Public Class frmRepCtsCobrar

    Private Sub optestadocuenta_Click(sender As System.Object, e As System.EventArgs) Handles optestadocuenta.Click
        If (optestadocuenta.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            txtcobrar.Text = "0.00"
            cbo.Text = ""
            cbo.Visible = True
            mCalendar1.Visible = True
            mCalendar2.Visible = True
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 13
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Num. Nota"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha venta"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Cargo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Abono"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Saldo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Forma de pago"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Monto"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Banco"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "Referencia"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(11)
                    .HeaderText = "Usuario"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(12)
                    .HeaderText = "Fecha cobro"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optvencimientos_Click(sender As System.Object, e As System.EventArgs) Handles optvencimientos.Click
        If (optvencimientos.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            txtcobrar.Text = "0.00"
            cbo.Text = ""
            cbo.Visible = True
            mCalendar1.Visible = True
            mCalendar2.Visible = True
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 5
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Num. Nota"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Concepto"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha cobro"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Cargo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optnotascliente_Click(sender As System.Object, e As System.EventArgs) Handles optnotascliente.Click
        If (optnotascliente.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            txtcobrar.Text = "0.00"
            cbo.Text = ""
            cbo.Visible = True
            mCalendar1.Visible = False
            mCalendar2.Visible = False
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 7
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha venta"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha cobro"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub opttodos_Click(sender As System.Object, e As System.EventArgs) Handles opttodos.Click
        If (opttodos.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            txtcobrar.Text = "0.00"
            cbo.Text = ""
            cbo.Visible = False
            mCalendar1.Visible = False
            mCalendar2.Visible = False
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 7
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha venta"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha cobro"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optfechacobro_Click(sender As System.Object, e As System.EventArgs) Handles optfechacobro.Click
        If (optfechacobro.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            txtcobrar.Text = "0.00"
            cbo.Text = ""
            cbo.Visible = False
            mCalendar1.Visible = True
            mCalendar2.Visible = True
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 7
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha venta"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha cobro"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub cbo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbo.DropDown
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        Dim querry As String = ""
        cbo.Items.Clear()
        If (optestadocuenta.Checked) Then
            querry = "select distinct Cliente from AbonoI where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and IdCliente<>0"
        End If
        If (optvencimientos.Checked) Then
            querry = "select distinct Cliente from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Status='RESTA'"
        End If
        If (optnotascliente.Checked) Then
            querry = "select distinct Cliente from Ventas where Status='RESTA' order by Cliente"
        End If
        Try
            If querry <> "" Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    querry
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbo.Items.Add(
                        rd1(0).ToString
                        )
                Loop
                rd1.Close() : cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        Dim dias As Integer = 0

        grdcaptura.Rows.Clear()

        If (optestadocuenta.Checked) Then
            If cbo.Text = "" Then MsgBox("Selecciona un cliente para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select DiasCred from Clientes where Nombre='" & cbo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    dias = rd1("DiasCred").ToString
                End If
            End If
            rd1.Close()

            Dim cargo_f As Double = 0
            Dim abono_f As Double = 0
            Dim debe As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumFolio,Cliente,Concepto,Fecha,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario from AbonoI where Cliente='" & cbo.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim NumNota As String = rd1("NumFolio").ToString
                    Dim cliente As String = rd1("Cliente").ToString
                    Dim concepto As String = rd1("Concepto").ToString
                    Dim fecha As String = rd1("Fecha").ToString
                    Dim cargo As Double = rd1("Cargo").ToString
                    Dim abono As Double = rd1("Abono").ToString
                    Dim saldo As Double = rd1("Saldo").ToString
                    Dim formapago As String = rd1("FormaPago").ToString
                    Dim montoforma As Double = rd1("Monto").ToString
                    'Dim tarjeta As Double = rd1("Tarjeta").ToString
                    ' Dim trsnfe As Double = rd1("Transfe").ToString
                    'Dim monedro As Double = rd1("Monedero").ToString
                    'Dim otro As Double = rd1("Otro").ToString
                    Dim banco As String = rd1("Banco").ToString
                    Dim refe As String = rd1("Referencia").ToString
                    Dim usuario As String = rd1("Usuario").ToString

                    'cnn2.Close() : cnn2.Open()
                    'cmd2 = cnn2.CreateCommand
                    'cmd2.CommandText = "SELECT DiasCred FROM clientes WHERE Nombre='" & MyClien & "'"
                    'rd2 = cmd2.ExecuteReader
                    'If rd2.HasRows Then
                    '    If rd2.Read Then
                    '        dias = rd2(0).ToString
                    '    End If
                    'End If
                    'rd2.Close()
                    'cnn2.Close()

                    Dim vence As Date = DateAdd(DateInterval.Day, dias, CDate(fecha))

                    grdcaptura.Rows.Add(NumNota, cliente, concepto, FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(cargo, 2), FormatNumber(abono, 2), FormatNumber(saldo, 2), formapago, montoforma, banco, refe, usuario, FormatDateTime(vence, DateFormat.ShortDate))
                    'grdcaptura.Rows.Add(NumNota, cliente, concepto, FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(cargo, 2), FormatNumber(abono, 2), FormatNumber(saldo, 2), FormatNumber(efectivo, 2), FormatNumber(tarjeta, 2), FormatNumber(trsnfe, 2), FormatNumber(monedro, 2), FormatNumber(otro, 2), banco, refe, usuario, FormatDateTime(vence, DateFormat.ShortDate))
                    cargo_f = cargo_f + cargo
                    abono_f = abono_f + abono
                End If
            Loop
            rd1.Close() : cnn1.Close()
            debe = cargo_f - abono_f
            txtcobrar.Text = FormatNumber(debe, 2)
        End If

        If (optvencimientos.Checked) Then
            If cbo.Text = "" Then MsgBox("Selecciona un cliente para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select DiasCred from Clientes where Nombre='" & cbo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    dias = rd1("DiasCred").ToString
                End If
            End If
            rd1.Close()

            Dim cargo_f As Double = 0
            Dim abono_f As Double = 0
            Dim debe As Double = 0

            Dim fecha As Date = Nothing

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumFolio,Cliente,Concepto,Cargo from AbonoI where Cliente='" & cbo.Text & "' and Cargo<>0 order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    fecha = rd1("Fecha").ToString
                    Dim vence As Date = DateAdd(DateInterval.Day, dias, CDate(fecha))
                    If vence > M1 And vence < M2 Then
                        Dim NumNota As String = rd1("NumFolio").ToString
                        Dim cliente As String = rd1("Cliente").ToString
                        Dim concepto As String = rd1("Concepto").ToString
                        Dim cargo As Double = rd1("Cargo").ToString

                        grdcaptura.Rows.Add(NumNota, cliente, concepto, FormatDateTime(vence, DateFormat.ShortDate), FormatNumber(cargo, 2))
                        cargo_f = cargo_f + cargo
                    End If
                End If
            Loop
            rd1.Close() : cnn1.Close()
            debe = cargo_f
            txtcobrar.Text = FormatNumber(debe, 2)
        End If

        If (optnotascliente.Checked) Then
            If cbo.Text = "" Then MsgBox("Selecciona un cliente para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select DiasCred from Clientes where Nombre='" & cbo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    dias = rd1("DiasCred").ToString
                End If
            End If
            rd1.Close()

            Dim debe As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Folio,CLiente,Totales,ACuenta,Resta,FVenta from Ventas where Cliente='" & cbo.Text & "' and Status='RESTA' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFolio As String = rd1("Folio").ToString
                    Dim MyClien As String = rd1("CLiente").ToString
                    Dim MyTotal As Double = rd1("Totales").ToString
                    Dim MyAcuen As Double = rd1("ACuenta").ToString
                    Dim MyResta As Double = rd1("Resta").ToString
                    Dim MyFecha As String = rd1("FVenta").ToString
                    Dim MyVence As Date = DateAdd(DateInterval.Day, dias, CDate(MyFecha))

                    grdcaptura.Rows.Add(MyFolio, MyClien, FormatNumber(MyTotal, 2), FormatNumber(MyAcuen, 2), FormatNumber(MyResta, 2), FormatDateTime(MyFecha, DateFormat.ShortDate), FormatDateTime(MyVence, DateFormat.ShortDate))
                    debe = debe + MyResta
                End If
            Loop
            rd1.Close() : cnn1.Close()
            txtcobrar.Text = FormatNumber(debe, 2)
        End If

        If (opttodos.Checked) Then
            cnn1.Close() : cnn1.Open()
            Dim debe As Double = 0
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Folio,Cliente,Totales,ACuenta,Resta,FVenta from Ventas where Status='RESTA' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFolio As String = rd1("Folio").ToString
                    Dim MyClien As String = rd1("Cliente").ToString
                    Dim MyTotal As Double = rd1("Totales").ToString
                    Dim MyAcuen As Double = rd1("ACuenta").ToString
                    Dim MyResta As Double = rd1("Resta").ToString
                    Dim MyFecha As String = rd1("FVenta").ToString


                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT DiasCred FROM clientes WHERE Nombre='" & MyClien & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            dias = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()

                    Dim MyVence As Date = DateAdd(DateInterval.Day, dias, CDate(MyFecha))

                    grdcaptura.Rows.Add(MyFolio, MyClien, FormatNumber(MyTotal, 2), FormatNumber(MyAcuen, 2), FormatNumber(MyResta, 2), FormatDateTime(MyFecha, DateFormat.ShortDate), FormatDateTime(MyVence, DateFormat.ShortDate))
                    debe = debe + MyResta
                End If
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close()
            txtcobrar.Text = FormatNumber(debe, 2)
        End If

        If (optfechacobro.Checked) Then
            cnn1.Close() : cnn1.Open()

            Dim cargo_f As Double = 0
            Dim abono_f As Double = 0
            Dim debe As Double = 0

            cnn2.Close() : cnn2.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Cliente,FVenta,FPago,Folio,Totales,ACuenta,Resta from Ventas where Status='RESTA' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim cliente As String = rd1("Cliente").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select DiasCred from Clientes where Nombre='" & cliente & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            dias = rd2("DiasCred").ToString
                        End If
                    End If
                    rd2.Close()

                    Dim fecha As String = rd1("FVenta").ToString
                    Dim vence As Date = rd1("FPago").ToString()
                    If vence > M1 And vence < M2 Then
                        Dim NumNota As String = rd1("Folio").ToString
                        Dim MyTotal As Double = rd1("Totales").ToString
                        Dim MyAcuen As Double = rd1("ACuenta").ToString
                        Dim MyResta As Double = rd1("Resta").ToString


                        grdcaptura.Rows.Add(NumNota, cliente, FormatNumber(MyTotal, 2), FormatNumber(MyAcuen, 2), FormatNumber(MyResta, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatDateTime(vence, DateFormat.ShortDate))
                        debe = debe + MyResta
                    End If
                End If
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close()
            txtcobrar.Text = FormatNumber(debe, 2)
        End If

        If grdcaptura.Rows.Count > 0 Then
            btnexportar.Enabled = True
        Else
            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub btnexportar_Click(sender As System.Object, e As System.EventArgs) Handles btnexportar.Click
        If grdcaptura.Rows.Count = 0 Then Exit Sub
        If MsgBox("¿Deseas exportar esta información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocio Pro") = vbOK Then
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exBook As Microsoft.Office.Interop.Excel.Workbook
            Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Application.ActiveSheet

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = grdcaptura.Rows.Count

                Dim Fila As Integer = 0
                Dim Col As Integer = 0

                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                If (optestadocuenta.Checked) Then
                    exSheet.Cells.Range("A1:P1").Merge()
                    exSheet.Cells.Item(1, 1) = "Estado de cuenta de " & cbo.Text
                    exSheet.Columns("E").NumberFormat = "$#,##0.00"
                    exSheet.Columns("F").NumberFormat = "$#,##0.00"
                    exSheet.Columns("G").NumberFormat = "$#,##0.00"
                    exSheet.Columns("H").NumberFormat = "$#,##0.00"
                    exSheet.Columns("I").NumberFormat = "$#,##0.00"
                    exSheet.Columns("J").NumberFormat = "$#,##0.00"
                    exSheet.Columns("K").NumberFormat = "$#,##0.00"
                    exSheet.Columns("L").NumberFormat = "$#,##0.00"

                    For i As Integer = 1 To NCol
                        exSheet.Cells.Item(2, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                    Next

                    For Fila = 0 To NRow - 1
                        For Col = 0 To NCol - 1
                            exSheet.Cells.Item(Fila + 3, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
                        Next
                        barcarga.Value = barcarga.Value + 1
                    Next

                    Dim Fila2 As Integer = Fila + 2

                    exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Total a cobrar"
                    exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1

                    exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtcobrar.Text, 2)

                    exSheet.Rows.Item(1).Font.Bold = 1
                    exSheet.Rows.Item(2).Font.Bold = 1
                    exSheet.Rows.Item(1).HorizontalAlignment = 3
                    exSheet.Columns.AutoFit()
                End If

                If (optvencimientos.Checked) Then
                    exSheet.Cells.Range("A1:E1").Merge()
                    exSheet.Cells.Item(1, 1) = "Vencimientos de " & cbo.Text
                    exSheet.Columns("E").NumberFormat = "$#,##0.00"

                    For i As Integer = 1 To NCol
                        exSheet.Cells.Item(2, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                    Next

                    For Fila = 0 To NRow - 1
                        For Col = 0 To NCol - 1
                            exSheet.Cells.Item(Fila + 3, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
                        Next
                        barcarga.Value = barcarga.Value + 1
                    Next

                    Dim Fila2 As Integer = Fila + 2

                    exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Total a cobrar"
                    exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1

                    exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtcobrar.Text, 2)

                    exSheet.Rows.Item(1).Font.Bold = 1
                    exSheet.Rows.Item(2).Font.Bold = 1
                    exSheet.Rows.Item(1).HorizontalAlignment = 3
                    exSheet.Columns.AutoFit()
                End If

                If (optnotascliente.Checked) Or (opttodos.Checked) Or (optfechacobro.Checked) Then
                    Dim m1 As Date = mCalendar1.SelectionStart.ToShortDateString
                    Dim m2 As Date = mCalendar2.SelectionStart.ToShortDateString

                    exSheet.Cells.Range("A1:G1").Merge()
                    If (optnotascliente.Checked) Then exSheet.Cells.Item(1, 1) = "Notas del cliente " & cbo.Text
                    If (opttodos.Checked) Then exSheet.Cells.Item(1, 1) = "Todos los clientes"
                    If (optfechacobro.Checked) Then exSheet.Cells.Item(1, 1) = "Fechas de cobro " & FormatDateTime(m1, DateFormat.ShortDate) & " - " & FormatDateTime(m2, DateFormat.ShortDate) & ""
                    exSheet.Columns("C").NumberFormat = "$#,##0.00"
                    exSheet.Columns("D").NumberFormat = "$#,##0.00"
                    exSheet.Columns("E").NumberFormat = "$#,##0.00"

                    For i As Integer = 1 To NCol
                        exSheet.Cells.Item(2, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                    Next

                    For Fila = 0 To NRow - 1
                        For Col = 0 To NCol - 1
                            exSheet.Cells.Item(Fila + 3, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
                        Next
                        barcarga.Value = barcarga.Value + 1
                    Next

                    Dim Fila2 As Integer = Fila + 2

                    exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Total a cobrar"
                    exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1

                    exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtcobrar.Text, 2)

                    exSheet.Rows.Item(1).Font.Bold = 1
                    exSheet.Rows.Item(2).Font.Bold = 1
                    exSheet.Rows.Item(1).HorizontalAlignment = 3
                    exSheet.Columns.AutoFit()
                End If

                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing
                barcarga.Value = 0
                barcarga.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

            MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        optestadocuenta.PerformClick()
        mCalendar1.SetDate(Now)
        mCalendar2.SetDate(Now)
        cbo.Text = ""
        grdcaptura.Rows.Clear()
        txtcobrar.Text = "0.00"
        btnexportar.Enabled = False
    End Sub

    Private Sub frmRepCtsCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class