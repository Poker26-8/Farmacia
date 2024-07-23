Public Class frmRepCtsPagar
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        Dim dias As Integer = 0

        grdcaptura.Rows.Clear()

        If (RadioButton3.Checked) Then
            If cbo.Text = "" Then MsgBox("Selecciona un provveedor para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select DiasCred from Proveedores where Compania='" & cbo.Text & "'"
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
                "select NumRemision,NumFactura,Proveedor,Concepto,Fecha,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro from AbonoE where Proveedor='" & cbo.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim remision As String = rd1("NumRemision").ToString()
                    Dim factura As String = rd1("NumFactura").ToString()
                    Dim proveedor As String = rd1("Proveedor").ToString
                    Dim concepto As String = rd1("Concepto").ToString
                    Dim fecha As String = rd1("Fecha").ToString
                    Dim cargo As Double = rd1("Cargo").ToString
                    Dim abono As Double = rd1("Abono").ToString
                    Dim saldo As Double = rd1("Saldo").ToString
                    Dim efectivo As Double = rd1("Efectivo").ToString
                    Dim tarjeta As Double = rd1("Tarjeta").ToString
                    Dim trsnfe As Double = rd1("Transfe").ToString
                    Dim otro As Double = rd1("Otro").ToString
                    Dim vence As Date = DateAdd(DateInterval.Day, dias, CDate(fecha))

                    grdcaptura.Rows.Add(remision, factura, proveedor, concepto, FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(cargo, 2), FormatNumber(abono, 2), FormatNumber(saldo, 2), FormatNumber(efectivo, 2), FormatNumber(tarjeta, 2), FormatNumber(trsnfe, 2), FormatNumber(otro, 2))
                    cargo_f = cargo_f + cargo
                    abono_f = abono_f + abono
                End If
            Loop
            rd1.Close() : cnn1.Close()
            debe = cargo_f - abono_f
            TextBox1.Text = FormatNumber(debe, 2)
        End If


        If (RadioButton5.Checked) Then
            If cbo.Text = "" Then MsgBox("Selecciona un proveedor para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select DiasCred from Proveedores where Compania='" & cbo.Text & "'"
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
                "select NumRemision,NumFactura,Proveedor,Total,ACuenta,Resta,FechaC,FechaP from Compras where Proveedor='" & cbo.Text & "' and FechaC between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Status='RESTA' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim remision As String = rd1("NumRemision").ToString()
                    Dim factura As String = rd1("NumFactura").ToString()
                    Dim proveedor As String = rd1("Proveedor").ToString
                    Dim total As Double = rd1("Total").ToString()
                    Dim acuenta As Double = rd1("ACuenta").ToString()
                    Dim resta As Double = rd1("Resta").ToString()
                    Dim fecha As String = rd1("FechaC").ToString
                    Dim pago As Date = rd1("FechaP").ToString()

                    grdcaptura.Rows.Add(remision, factura, proveedor, FormatNumber(total, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatDateTime(pago, DateFormat.ShortDate))
                    cargo_f = cargo_f + resta
                End If
            Loop
            rd1.Close() : cnn1.Close()
            debe = cargo_f
            TextBox1.Text = FormatNumber(debe, 2)
        End If

    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        If (RadioButton3.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            cbo.Text = ""
            cbo.Visible = True
            mCalendar1.Visible = True
            mCalendar2.Visible = True
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 12
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Remisión"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Factura"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Proveedor"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Concepto"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Fecha"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Cargo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Abono"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Saldo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Efectivo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Tarjeta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "Transfe."
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(11)
                    .HeaderText = "Otro"
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

    Private Sub frmRepCtsPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbo.Text = ""
    End Sub

    Private Sub cbo_DropDown(sender As Object, e As EventArgs) Handles cbo.DropDown
        cbo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If (RadioButton3.Checked) Then
                cmd1.CommandText =
                    "select distinct Proveedor from AbonoE"
            Else
                cmd1.CommandText =
                    "select distinct Proveedor from Compras where Status='RESTA'"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbo.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles RadioButton5.Click
        If (RadioButton5.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            cbo.Text = ""
            cbo.Visible = True
            mCalendar1.Visible = True
            mCalendar2.Visible = True
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Remisión"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Factura"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Proveedor"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha compra"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Fecha de pago"
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

    Private Sub RadioButton6_Click(sender As Object, e As EventArgs) Handles RadioButton6.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString

        If (RadioButton6.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            cbo.Text = ""
            cbo.Visible = False
            mCalendar1.Visible = False
            mCalendar2.Visible = False
            cbo.Focus().Equals(True)

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Remisión"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Factura"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Proveedor"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha compra"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Fecha de pago"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If

        cnn1.Close() : cnn1.Open()

        Dim cargo_f As Double = 0
        Dim abono_f As Double = 0
        Dim debe As Double = 0

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NumRemision,NumFactura,Proveedor,Total,ACuenta,Resta,FechaC,FechaP from Compras where Status='RESTA' order by Id"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then
                Dim remision As String = rd1("NumRemision").ToString()
                Dim factura As String = rd1("NumFactura").ToString()
                Dim proveedor As String = rd1("Proveedor").ToString
                Dim total As Double = rd1("Total").ToString()
                Dim acuenta As Double = rd1("ACuenta").ToString()
                Dim resta As Double = rd1("Resta").ToString()
                Dim fecha As String = rd1("FechaC").ToString
                Dim pago As Date = rd1("FechaP").ToString()

                grdcaptura.Rows.Add(remision, factura, proveedor, FormatNumber(total, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatDateTime(pago, DateFormat.ShortDate))
                cargo_f = cargo_f + resta
            End If
        Loop
        rd1.Close() : cnn1.Close()
        debe = cargo_f
        TextBox1.Text = FormatNumber(debe, 2)
    End Sub
End Class