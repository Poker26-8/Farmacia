Public Class frmRepVentas
    Dim Partes As Boolean = False
    Private Sub frmRepVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mCalendar1.SetDate(Now)
        mCalendar2.SetDate(Now)
        grdcaptura.Rows.Clear()
        opttotales.PerformClick()

        dtpinicio.Text = "00:00:00"
        dtpfin.Text = "23:59:59"

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Partes'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = 1 Then
                        Partes = True
                    Else
                        Partes = False
                    End If
                End If
            End If
            rd1.Close()

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ventas order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim fechas As Date = rd1("FVenta").ToString()
                    Dim horas As Date = rd1("HVenta").ToString()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "update Ventas set Fecha='" & Format(fechas, "yyyy-MM-dd") & " " & Format(horas, "HH:mm:ss") & "' where Folio=" & rd1("Folio").ToString()
                    cmd2.ExecuteNonQuery()
                End If
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnuevo.Click
        grdcaptura.Rows.Clear()
        opttotales.Checked = True
        barcarga.Visible = False
        barcarga.Value = 0
        mCalendar1.SetDate(Now)
        mCalendar2.SetDate(Now)
        ComboBox1.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Visible = False
        txtrestante.Text = "0.00"
        txtVendido.Text = "0.00"
    End Sub

    Private Sub opttotales_Click(sender As System.Object, e As System.EventArgs) Handles opttotales.Click
        If (opttotales.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 15
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
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
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Iva"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Totales"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Propina"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Devolución"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(10)
                    .HeaderText = "IEEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(11)
                    .HeaderText = "Forma Pago"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(12)
                    .HeaderText = "Estado"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(13)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(14)
                    .HeaderText = "N° Factura"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False

            lblacuenta.Visible = True
            txtacuenta.Visible = True
            lblresta.Visible = True
            txtresta.Visible = True
            lbliva.Visible = True
            txtiva.Visible = True
            lblutilidad.Visible = False
            txtutilidad.Visible = False
            lblCosto.Visible = False
            lblCosto.Visible = False
            lblpeso.Visible = False
            txtpeso.Visible = False
            btnprint.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub opttotalesdet_Click(sender As System.Object, e As System.EventArgs) Handles opttotalesdet.Click
        If (opttotalesdet.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            If (Partes) Then
                grdcaptura.ColumnCount = 17
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
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
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Costo"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(14)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(15)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(16)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 16
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
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
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Costo"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(14)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(15)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            End If

            Exportar.Enabled = False
            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = True
            txtutilidad.Visible = True
            lblCosto.Visible = True
            txtCosto.Visible = True
            lblpeso.Visible = False
            txtpeso.Visible = False

            lblieps.Visible = True
            txtieps.Visible = True

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optcliente_Click(sender As System.Object, e As System.EventArgs) Handles optcliente.Click
        If (optcliente.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 10
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "IEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "IVA"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Estado"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(9)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False

            lblacuenta.Visible = True
            txtacuenta.Visible = True
            lblresta.Visible = True
            txtresta.Visible = True
            lbliva.Visible = True
            txtiva.Visible = True
            lblutilidad.Visible = False
            txtutilidad.Visible = False
            lblCosto.Visible = False
            txtCosto.Visible = False
            lblpeso.Visible = False
            txtpeso.Visible = False
            btnprint.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Public Function Saca_NumParte(ByVal codix As String) As String
        Saca_NumParte = ""
        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select N_Serie from Productos where Codigo='" & codix & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    Saca_NumParte = rd4(0).ToString()
                End If
            Else
                Saca_NumParte = ""
            End If
            rd4.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
            Saca_NumParte = ""
        End Try
        Return Saca_NumParte
    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        Dim cuenta As Double = 0

        Dim T_descuento As Double = 0
        Dim T_subtotal As Double = 0
        Dim T_ieps As Double = 0
        Dim T_iva As Double = 0
        Dim T_total As Double = 0
        Dim T_acuenta As Double = 0
        Dim t_resta As Double = 0
        Dim T_Propina As Double = 0
        Dim T_Costo As Double = 0
        Dim T_productos As Double = 0

        txtiva.Text = "0.00"
        txtdescuento.Text = "0.00"
        txtsubtotal.Text = "0.00"
        txtieps.Text = "0.00"
        txttotal.Text = "0.00"
        txtutilidad.Text = "0.00"
        txtpeso.Text = "0.00"
        txtacuenta.Text = "0.00"
        txtresta.Text = "0.00"

        grdcaptura.Rows.Clear()
        Exportar.Enabled = True

        'Totales
        If (opttotales.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand

            If ComboBox1.Text = "" Then

                cmd1.CommandText =
              "select count(Folio) from Ventas where FVenta>='" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' and FVenta<='" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpfin.Value, "HH:mm:ss") & "' and Status<>'CANCELADA'"
            Else
                cmd1.CommandText =
              "select count(Folio) from Ventas where FVenta>='" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' and FVenta<='" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpfin.Value, "HH:mm:ss") & "' and Status='" & ComboBox1.Text & "'"
            End If


            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand

            If ComboBox1.Text = "" Then

                cmd1.CommandText =
                    "select * from Ventas where FVenta>='" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' and FVenta<='" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpfin.Value, "HH:mm:ss") & "' and Status<>'CANCELADA' order by Folio"
            Else
                cmd1.CommandText =
                    "select * from Ventas where FVenta>='" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' and FVenta<='" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpfin.Value, "HH:mm:ss") & "' and Status='" & ComboBox1.Text & "' order by Folio"
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As String = rd1("Folio").ToString()
                    Dim cliente As String = rd1("Cliente").ToString()
                    'Dim descuento As Double = 0
                    Dim descuento As Double = rd1("Descuento").ToString()
                    Dim devolucion As Double = rd1("Devolucion").ToString
                    Dim subtotal As Double = rd1("Subtotal").ToString
                    ' Dim IVA As Double = 0
                    Dim IVA As String = rd1("IVA").ToString
                    Dim IEPS As Double = 0
                    'Dim total As Double = 0
                    Dim total As Double = rd1("Totales").ToString
                    Dim acuenta As Double = rd1("ACuenta").ToString()
                    Dim resta As Double = rd1("Resta").ToString()
                    Dim status As String = rd1("Status").ToString()
                    Dim formato As String = rd1("Formato").ToString()
                    Dim fecha As Date = rd1("FVenta").ToString()
                    Dim factura As Integer = rd1("Facturado").ToString
                    Dim propina As Double = rd1("Propina").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select sum(Total) as Tot, sum(TotalSinIVA) as Sub, sum(Descto) as Descu, sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            IEPS = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                        End If
                    End If
                    rd2.Close()

                    'subtotal = rd1("Subtotal").ToString

                    Dim formapago As String = ""

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT FormaPago FROM abonoi WHERE NumFolio='" & folio & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            formapago = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()

                    grdcaptura.Rows.Add(folio, cliente, FormatNumber(subtotal, 2), FormatNumber(IVA, 2), FormatNumber(total, 2), FormatNumber(propina, 2), FormatNumber(descuento, 2), FormatNumber(devolucion, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2), FormatNumber(IEPS, 2), formapago, status, Format(fecha, "yyyy-MM-dd"), factura)
                    barcarga.Value = barcarga.Value + 1

                    T_Propina = T_Propina + propina
                    T_descuento = T_descuento + descuento
                    T_ieps = T_ieps + IEPS
                    T_iva = T_iva + IVA
                    T_subtotal = T_subtotal + subtotal
                    T_total = T_total + total
                    T_acuenta = T_acuenta + acuenta
                    t_resta = t_resta + resta
                End If
            Loop
            rd1.Close() : cnn1.Close()
            txtPropina.Text = FormatNumber(T_Propina, 2)
            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            barcarga.Visible = False
            barcarga.Value = 0
        End If

        If optDerivados.Checked = True Then
            Try
                Dim temp As Integer = 0
                Dim Totales As Double = 0
                cnn2.Close() : cnn2.Open()

                Dim folio As Integer = 0
                Dim cliente As String = ""

                Dim codigo As String = "", barras As String = "", descrip As String = "", unidad As String = "", cantidad As Double = 0, precio As Double = 0, ieps As Double = 0, fecha As String = "", Dscto As Double = 0, MyTotalSI As Double = 0, lote As String = "", caduca As String = "", n_parte As String = ""
                Dim MyUC2 As Double = 0, IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImporteDsct As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
                Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0

                Dim soyTotal As Double = 0
                Dim voy As Double = 0
                Dim ahorasi As Double = 0
                Dim porcentajee As Double = 0
                Dim sumaPorcentaje As Double = 0

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Existencia from Productos where Codigo='" & ComboBox1.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        soyTotal = rd1(0).ToString
                    End If
                Else
                    soyTotal = 0
                End If
                rd1.Close()
                cnn1.Close()

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                            "select * from VentasDetalle where left(Codigo, 6)='" & Strings.Left(ComboBox1.Text, 6) & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Codigo "
                rd3 = cmd3.ExecuteReader
                Do While rd3.Read
                    cantidad = IIf(rd3("Cantidad").ToString() = "", 1, rd3("Cantidad").ToString())
                    voy = voy + cantidad
                Loop

                ahorasi = soyTotal + CDec(voy)
                rd3.Close()
                cnn3.Close()

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                            "select * from VentasDetalle where left(Codigo, 6)='" & Strings.Left(ComboBox1.Text, 6) & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Codigo "
                rd3 = cmd3.ExecuteReader
                Do While rd3.Read
                    If rd3.HasRows Then
                        codigo = rd3("Codigo").ToString()
                        barras = CB(codigo)
                        descrip = rd3("Nombre").ToString()
                        unidad = rd3("Unidad").ToString()
                        cantidad = IIf(rd3("Cantidad").ToString() = "", 1, rd3("Cantidad").ToString())
                        precio = IIf(rd3("Precio").ToString() = "", 0, rd3("Precio").ToString())
                        MyTotalSI = IIf(rd3("TotalSinIVA").ToString() = "", 0, rd3("TotalSinIVA").ToString())
                        ieps = rd3("TotalIEPS").ToString()
                        fecha = rd3("Fecha").ToString()
                        MyUC2 = DameUti(folio, codigo, cantidad)
                        IvaTemp = IvaDSC(codigo)
                        YTem = CDbl(rd3("TotalSinIVA").ToString()) - (CDbl(rd3("TotalSinIVA").ToString()) * Desc2)
                        XTem = CDbl(rd3("TotalSinIVA").ToString()) * IvaTemp
                        lote = rd3("Lote").ToString()
                        caduca = IIf(rd3("Caducidad").ToString() = "", "", rd3("Caducidad").ToString())
                        ImporteDsct = Desc / cantidad
                        Dscto = rd3("Descto").ToString()
                        If IvaTemp = 0.16 Then
                            ImpDscto = Dscto * 1.16
                        Else
                            ImpDscto = Dscto
                        End If
                    End If


                    VarSumXD = MyTotalSI + XTem
                    VarSubtotal = ImpDscto + VarSumXD

                    n_parte = Saca_NumParte(codigo)

                    If Len(codigo) <= 6 Then
                        porcentajee = 0
                        sumaPorcentaje = 0
                    Else
                        porcentajee = cantidad * 100 / ahorasi
                        porcentajee = FormatNumber(porcentajee, 2)
                        sumaPorcentaje = sumaPorcentaje + CDec(porcentajee)
                    End If

                    grdcaptura.Rows.Add(folio, cliente, codigo, barras, descrip, unidad, cantidad, porcentajee, FormatNumber(precio, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))


                    T_descuento = T_descuento + ImpDscto
                    T_ieps = T_ieps + ieps
                    T_iva = T_iva + XTem
                    T_subtotal = T_subtotal + MyTotalSI
                    T_total = T_total + (MyTotalSI + XTem)
                    txtutilidad.Text = CDbl(txtutilidad.Text) + MyUC2

                Loop
                If Len(codigo) <= 6 Then
                    txtrestante.Text = 0
                    txtVendido.Text = 0
                Else
                    txtrestante.Text = soyTotal * 100 / ahorasi
                    txtrestante.Text = FormatNumber(txtrestante.Text, 2)
                    txtVendido.Text = sumaPorcentaje
                End If

                ' End If
                ' Loop
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        'TotalesDetalle
        If (opttotalesdet.Checked) Then
            Dim temp As Integer = 0
            Dim Totales As Double = 0
            cnn2.Close() : cnn2.Open()

            Dim folio As Integer = 0
            Dim cliente As String = ""

            Dim codigo As String = "", barras As String = "", descrip As String = "", unidad As String = "", cantidad As Double = 0, precio As Double = 0, ieps As Double = 0, fecha As String = "", Dscto As Double = 0, MyTotalSI As Double = 0, lote As String = "", caduca As String = "", n_parte As String = ""
            Dim MyUC2 As Double = 0, IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImporteDsct As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
            Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0, propinas As Double = 0, costo As Double = 0, sumacosto As Double = 0, DESCU As Double = 0

            Dim nuvaiva As Double = 0
            Dim nuevosubtotal As Double = 0

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select * from Ventas where FVenta>='" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' and FVenta<='" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpfin.Value, "HH:mm:ss") & "' and Status<>'CANCELADA' order by Folio"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    propinas = rd2("Propina").ToString
                    DESCU = rd2("Descuento").ToString
                    T_Propina = T_Propina + CDbl(propinas)
                    T_descuento = T_descuento + CDbl(DESCU)
                End If
            Loop
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select * from Ventas where FVenta>='" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' and FVenta<='" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpfin.Value, "HH:mm:ss") & "' and Status<>'CANCELADA' order by Folio"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    folio = rd2("Folio").ToString
                    cliente = rd2("Cliente").ToString
                    temp = folio
                    Desc = CDbl(rd2("Descuento").ToString)
                    Desc3 = Desc3 + CDbl(rd2("Descuento").ToString)
                    Desc2 = FormatNumber(CDbl(rd2("Descuento").ToString) / (CDbl(rd2("Totales").ToString) + IIf(CDbl(rd2("Totales").ToString) <= 0, 1, 0)), 2)
                    Totales = Totales + CDbl(rd2("Totales").ToString)


                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select * from VentasDetalle where Folio=" & folio
                    rd3 = cmd3.ExecuteReader
                    Do While rd3.Read
                        If rd3.HasRows Then
                            codigo = rd3("Codigo").ToString()
                            barras = CB(codigo)
                            descrip = rd3("Nombre").ToString()
                            unidad = rd3("Unidad").ToString()
                            cantidad = IIf(rd3("Cantidad").ToString() = "", 1, rd3("Cantidad").ToString())
                            precio = IIf(rd3("Precio").ToString() = "", 0, rd3("Precio").ToString())
                            ' MyTotalSI = IIf(rd3("TotalSinIVA").ToString() = "", 0, rd3("TotalSinIVA").ToString())
                            MyTotalSI = IIf(rd3("Total").ToString() = "", 0, rd3("Total").ToString())
                            ieps = rd3("TotalIEPS").ToString()
                            fecha = rd3("Fecha").ToString()
                            MyUC2 = DameUti(folio, codigo, cantidad)
                            IvaTemp = IvaDSC(codigo)
                            'YTem = CDbl(rd3("TotalSinIVA").ToString()) - (CDbl(rd3("TotalSinIVA").ToString()) * Desc2)
                            'XTem = CDbl(rd3("Total").ToString()) * (1 + IvaTemp)
                            XTem = CDbl(rd3("Total").ToString()) / (1 + IvaTemp)
                            nuvaiva = MyTotalSI - CDbl(XTem)
                            nuevosubtotal = MyTotalSI - CDbl(nuvaiva)

                            lote = rd3("Lote").ToString()
                            caduca = IIf(rd3("Caducidad").ToString() = "", "", rd3("Caducidad").ToString())
                            ImporteDsct = Desc / cantidad
                            Dscto = rd3("Descto").ToString()
                            costo = rd3("CostoVP").ToString

                            If IvaTemp = 0.16 Then
                                ImpDscto = Dscto * 1.16
                            Else
                                ImpDscto = Dscto
                            End If
                        End If
                        sumacosto = FormatNumber(CDbl(costo) * CDbl(cantidad), 2)

                        n_parte = Saca_NumParte(codigo)

                        If (Partes) Then
                            grdcaptura.Rows.Add(folio, cliente, codigo, barras, n_parte, descrip, unidad, cantidad, costo, FormatNumber(VarSubtotal, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))
                        Else

                            grdcaptura.Rows.Add(folio, cliente, codigo, barras, descrip, unidad, cantidad, costo, FormatNumber(precio, 2), FormatNumber(nuevosubtotal, 2), FormatNumber(nuvaiva, 2), FormatNumber(MyTotalSI, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))

                        End If
                        T_Costo = T_Costo + sumacosto
                        ' T_descuento = T_descuento + ImpDscto
                        T_ieps = T_ieps + ieps
                        T_iva = T_iva + nuvaiva
                        T_iva = FormatNumber(T_iva, 2)
                        T_subtotal = T_subtotal + nuevosubtotal
                        T_subtotal = FormatNumber(T_subtotal, 2)
                    Loop
                    rd3.Close()
                End If
            Loop
            rd2.Close()

            cnn2.Close() : cnn3.Close()
            txtPropina.Text = FormatNumber(T_Propina, 2)
            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            'txttotal.Text = FormatNumber(txtsubtotal.Text + T_iva - txtdescuento.Text, 2)
            txttotal.Text = FormatNumber(CDbl(T_subtotal) + CDbl(T_iva) + CDbl(T_Propina) - txtdescuento.Text, 2)
            txtCosto.Text = FormatNumber(T_Costo, 2)
            txtutilidad.Text = FormatNumber(CDbl(txttotal.Text) - CDbl(txtCosto.Text), 2)
            txtSuma.Text = FormatNumber(T_productos, 2)
        End If

        'Detalle pago
        If (optdetalle2.Checked) Then
            Dim temp As Integer = 0
            Dim Totales As Double = 0
            cnn2.Close() : cnn2.Open()

            Dim folio As Integer = 0
            Dim cliente As String = ""
            Dim acuenta As Double = 0
            Dim resta As Double = 0

            Dim codigo As String = "", barras As String = "", descrip As String = "", unidad As String = "", cantidad As Double = 0, precio As Double = 0, ieps As Double = 0, fecha As String = "", Dscto As Double = 0, MyTotalSI As Double = 0, lote As String = "", caduca As String = "", n_parte As String = ""
            Dim MyUC2 As Double = 0, IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImporteDsct As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
            Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select * from ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Status<>'CANCELADA' order by Folio"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    folio = rd2("Folio").ToString
                    cliente = rd2("Cliente").ToString
                    temp = folio
                    Desc = CDbl(rd2("Descuento").ToString)
                    Desc3 = Desc3 + CDbl(rd2("Descuento").ToString)
                    Desc2 = FormatNumber(CDbl(rd2("Descuento").ToString) / (CDbl(rd2("Totales").ToString) + IIf(CDbl(rd2("Totales").ToString) <= 0, 1, 0)), 2)
                    Totales = Totales + CDbl(rd2("Totales").ToString)
                    acuenta = rd2("ACuenta").ToString()
                    resta = rd2("Resta").ToString()

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select * from VentasDetalle where Folio=" & folio
                    rd3 = cmd3.ExecuteReader
                    Do While rd3.Read
                        If rd3.HasRows Then
                            codigo = rd3("Codigo").ToString()
                            barras = CB(codigo)
                            descrip = rd3("Nombre").ToString()
                            unidad = rd3("Unidad").ToString()
                            cantidad = IIf(rd3("Cantidad").ToString() = "", 1, rd3("Cantidad").ToString())
                            precio = IIf(rd3("Precio").ToString() = "", 0, rd3("Precio").ToString())
                            MyTotalSI = IIf(rd3("TotalSinIVA").ToString() = "", 0, rd3("TotalSinIVA").ToString())
                            ieps = rd3("TotalIEPS").ToString()
                            fecha = rd3("Fecha").ToString()
                            MyUC2 = DameUti(folio, codigo, cantidad)
                            IvaTemp = IvaDSC(codigo)
                            YTem = CDbl(rd3("TotalSinIVA").ToString()) - (CDbl(rd3("TotalSinIVA").ToString()) * Desc2)
                            XTem = CDbl(rd3("TotalSinIVA").ToString()) * IvaTemp
                            lote = rd3("Lote").ToString()
                            caduca = IIf(rd3("Caducidad").ToString() = "", "", rd3("Caducidad").ToString())
                            ImporteDsct = Desc / cantidad
                            Dscto = rd3("Descto").ToString()
                            If IvaTemp = 0.16 Then
                                ImpDscto = Dscto * 1.16
                            Else
                                ImpDscto = Dscto
                            End If
                        End If

                        VarSumXD = MyTotalSI + XTem
                        VarSubtotal = ImpDscto + VarSumXD

                        n_parte = Saca_NumParte(codigo)

                        If (Partes) Then
                            grdcaptura.Rows.Add(folio, cliente, codigo, barras, n_parte, descrip, unidad, cantidad, FormatNumber(VarSubtotal, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2))
                        Else
                            'grdcaptura.Rows.Add(folio, cliente, codigo, barras, descrip, unidad, cantidad, FormatNumber(VarSubtotal, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))

                            grdcaptura.Rows.Add(folio, cliente, codigo, barras, descrip, unidad, cantidad, FormatNumber(precio, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2))
                        End If

                        T_descuento = T_descuento + ImpDscto
                        T_ieps = T_ieps + ieps
                        T_iva = T_iva + XTem
                        T_subtotal = T_subtotal + MyTotalSI
                        T_total = T_total + (MyTotalSI + XTem)
                        T_productos = T_productos + CDbl(cantidad)
                        txtutilidad.Text = CDbl(txtutilidad.Text) + MyUC2
                    Loop
                    rd3.Close()
                End If
            Loop
            rd2.Close()

            cnn2.Close() : cnn3.Close()
            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtutilidad.Text = FormatNumber(CDbl(txtutilidad.Text), 2)
            txtSuma.Text = FormatNumber(T_productos, 2)
        End If


        'Cliente
        If (optcliente.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un cliente para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Folio) from Ventas where Fventa between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Status<>'CANCELADA' and Cliente='" & ComboBox1.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Status<>'CANCELADA' and Cliente='" & ComboBox1.Text & "' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As String = rd1("Folio").ToString
                    Dim descuento As Double = 0
                    Dim subtotal As Double = 0
                    Dim IVA As Double = 0
                    Dim IEPS As Double = 0
                    Dim total As Double = 0
                    Dim acuenta As Double = rd1("ACuenta").ToString
                    Dim resta As Double = rd1("Resta").ToString
                    Dim status As String = rd1("Status").ToString
                    Dim fecha As Date = rd1("Fventa").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select sum(Total) as Tot, sum(TotalSinIVA) as Sub, sum(Descto) as Descu, sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            subtotal = IIf(rd2("Sub").ToString() = "", 0, rd2("Sub").ToString())
                            IVA = CDbl(IIf(rd2("Tot").ToString() = "", 0, rd2("Tot").ToString())) - CDbl(IIf(rd2("Sub").ToString() = "", 0, rd2("Sub").ToString()))
                            total = IIf(rd2("Tot").ToString() = "", 0, rd2("Tot").ToString())
                            descuento = IIf(rd2("Descu").ToString() = "", 0, rd2("Descu").ToString())
                            IEPS = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                        End If
                    End If
                    rd2.Close()

                    grdcaptura.Rows.Add(folio, FormatNumber(subtotal, 2), FormatNumber(descuento, 2), FormatNumber(IEPS, 2), FormatNumber(IVA, 2), FormatNumber(total, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2), status, FormatDateTime(fecha, DateFormat.ShortDate))
                    barcarga.Value = barcarga.Value + 1

                    T_descuento = T_descuento + descuento
                    T_ieps = T_ieps + IEPS
                    T_iva = T_iva + IVA
                    T_subtotal = T_subtotal + subtotal
                    T_total = T_total + total
                    T_acuenta = T_acuenta + acuenta
                    t_resta = t_resta + resta
                End If
            Loop
            rd1.Close() : cnn1.Close()
            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            barcarga.Visible = False
            barcarga.Value = 0
        End If


        'Cliente detalle
        If (optclientedet.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un cliente para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Ventas.Folio) from Ventas INNER JOIN VentasDetalle ON Ventas.Folio=VentasDetalle.Folio where Ventas.FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Ventas.Cliente='" & ComboBox1.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            Dim temp As Integer = 0
            Dim Totales As Double = 0
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()

            cmd1 = cnn1.CreateCommand
            'cmd1.CommandText = "select * FROM Ventas V INNER JOIN VentasDetalle VD ON V.Folio=VD.Folio where V.FVenta between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and V.Nombre='" & ComboBox1.Text & "'"
            cmd1.CommandText = "select * FROM Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Cliente='" & ComboBox1.Text & "'"

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As Integer = rd1("Folio").ToString
                    Dim codigo As String = "", barras As String = "", descrip As String = "", unidad As String = "", cantidad As Double = 0, precio As Double = 0, ieps As Double = 0, fecha As String = "", Dscto As Double = 0, MyTotalSI As Double = 0, lote As String = "", caduca As String = "", n_parte As String = ""
                    Dim MyUC2 As Double = 0, IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImporteDsct As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
                    Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0

                    If temp <> folio Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from Ventas where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                temp = folio
                                Desc = CDbl(rd1("Descuento").ToString)
                                Desc3 = Desc3 + CDbl(rd1("Descuento").ToString)
                                Desc2 = FormatNumber(CDbl(rd1("Descuento").ToString) / (CDbl(rd1("Totales").ToString) + IIf(CDbl(rd1("Totales").ToString) <= 0, 1, 0)), 2)
                                Totales = Totales + CDbl(rd1("Totales").ToString)
                                T_acuenta = T_acuenta + CDbl(rd1("ACuenta").ToString)
                                t_resta = t_resta + CDbl(rd1("Resta").ToString)
                            End If
                        End If
                        rd2.Close()
                    End If

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from VentasDetalle where Folio=" & folio
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then
                            codigo = rd2("Codigo").ToString()
                            barras = CB(codigo)
                            descrip = rd2("Nombre").ToString()
                            unidad = rd2("Unidad").ToString()
                            cantidad = IIf(rd2("Cantidad").ToString() = "", 1, rd2("Cantidad").ToString())

                            precio = IIf(rd2("Precio").ToString = "", 0, rd2("Precio").ToString())
                            MyTotalSI = IIf(rd2("TotalSinIVA").ToString() = "", 0, rd2("TotalSinIVA").ToString())
                            ieps = rd2("TotalIEPS").ToString()
                            fecha = rd2("Fecha").ToString()
                            MyUC2 = DameUti(folio, codigo, cantidad)
                            IvaTemp = IvaDSC(codigo)
                            YTem = CDbl(rd2("TotalSinIVA").ToString()) - (CDbl(rd2("TotalSinIVA").ToString()) * Desc2)
                            XTem = CDbl(rd2("TotalSinIVA").ToString()) * IvaTemp
                            lote = rd2("Lote").ToString()
                            caduca = IIf(rd2("Caducidad").ToString() = "", "", rd2("Caducidad").ToString())
                            ImporteDsct = Desc / cantidad
                            Dscto = rd2("Descto").ToString()
                            If IvaTemp = 0.16 Then
                                ImpDscto = Dscto * 1.16
                            Else
                                ImpDscto = Dscto
                            End If

                            VarSumXD = MyTotalSI + XTem
                            VarSubtotal = ImpDscto + VarSumXD
                            n_parte = Saca_NumParte(codigo)

                            If (Partes) Then
                                grdcaptura.Rows.Add(folio, codigo, barras, n_parte, descrip, unidad, cantidad, FormatNumber(precio, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))
                                'grdcaptura.Rows.Add(folio, codigo, barras, n_parte, descrip, unidad, cantidad, FormatNumber(VarSubtotal, 2), FormatNumber(ImpDscto, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ieps, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))
                            Else
                                grdcaptura.Rows.Add(folio, codigo, barras, descrip, unidad, cantidad, FormatNumber(precio, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ImpDscto, 2), FormatNumber(ieps, 2), FormatNumber(XTem, 2), FormatNumber(MyTotalSI + XTem, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))
                            End If
                            T_productos = T_productos + CDbl(cantidad)
                        End If
                    Loop
                    rd2.Close()

                    T_descuento = T_descuento + ImpDscto
                    T_ieps = T_ieps + ieps
                    T_iva = T_iva + XTem
                    T_subtotal = T_subtotal + MyTotalSI
                    T_total = T_total + (MyTotalSI + XTem)
                    txtutilidad.Text = CDbl(txtutilidad.Text) + MyUC2

                End If
                barcarga.Value = barcarga.Value + 1
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close() : cnn3.Close()
            barcarga.Visible = False
            barcarga.Value = 0

            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            txtutilidad.Text = FormatNumber(txtutilidad.Text, 2)
            txtSuma.Text = FormatNumber(T_productos, 2)
        End If


        'Departamente
        If (optdepto.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un departamento para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from VentasDetalle where Depto='" & ComboBox1.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            Dim IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
            Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0

            Dim temp As Integer = 0
            Dim Totales As Double = 0

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from VentasDetalle where Depto='" & ComboBox1.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0 order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As Integer = rd1("Folio").ToString
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim barras As String = CB(codigo)
                    Dim descrip As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("Unidad").ToString
                    Dim cantidad As Double = IIf(rd1("Cantidad").ToString = "", 0, rd1("Cantidad").ToString)
                    Dim precio As Double = rd1("PrecioSinIVA").ToString
                    Dim ieps As Double = rd1("TotalIEPS").ToString
                    Dim fecha As String = rd1("Fecha").ToString
                    Dim Dscto As Double = rd1("Descto").ToString
                    Dim MyTotalSI As Double = rd1("TotalSinIVA").ToString
                    Dim MyTotal As Double = rd1("Total").ToString
                    Dim lote As String = rd1("Lote").ToString
                    Dim caduca As String = rd1("Caducidad").ToString
                    Dim MyUC2 As Double = DameUti(folio, codigo, cantidad)
                    Dim ImporteDsct As Double = Dscto / cantidad

                    grdcaptura.Rows.Add(folio, codigo, barras, descrip, unidad, cantidad, FormatNumber(precio, 2), FormatNumber(ImporteDsct, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ieps, 2), FormatNumber(MyTotal - MyTotalSI, 2), FormatNumber(MyTotal, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))

                    T_descuento = T_descuento + ImpDscto
                    T_ieps = T_ieps + ieps
                    T_iva = T_iva + (MyTotal - MyTotalSI)
                    T_subtotal = T_subtotal + MyTotalSI
                    T_total = T_total + (MyTotal + XTem)
                    txtutilidad.Text = CDbl(txtutilidad.Text) + MyUC2
                    T_productos = T_productos + CDbl(cantidad)
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close() : cnn3.Close()
            barcarga.Visible = False
            barcarga.Value = 0

            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            txtutilidad.Text = FormatNumber(txtutilidad.Text, 2)
            txtSuma.Text = FormatNumber(T_productos, 2)
        End If


        'Grupo
        If (optgrupo.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un grupo para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from VentasDetalle where Grupo='" & ComboBox1.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            Dim IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
            Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0

            Dim temp As Integer = 0
            Dim Totales As Double = 0

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from VentasDetalle where Grupo='" & ComboBox1.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0 order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As Integer = rd1("Folio").ToString
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim barras As String = CB(codigo)
                    Dim descrip As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("Unidad").ToString
                    Dim cantidad As Double = IIf(rd1("Cantidad").ToString = "", 0, rd1("Cantidad").ToString)
                    Dim precio As Double = rd1("PrecioSinIVA").ToString
                    Dim ieps As Double = rd1("TotalIEPS").ToString
                    Dim fecha As String = rd1("Fecha").ToString
                    Dim Dscto As Double = rd1("Descto").ToString
                    Dim MyTotalSI As Double = rd1("TotalSinIVA").ToString
                    Dim MyTotal As Double = rd1("Total").ToString
                    Dim lote As String = rd1("Lote").ToString
                    Dim caduca As String = rd1("Caducidad").ToString
                    Dim MyUC2 As Double = DameUti(folio, codigo, cantidad)
                    Dim ImporteDsct As Double = Dscto / cantidad

                    grdcaptura.Rows.Add(folio, codigo, barras, descrip, unidad, cantidad, FormatNumber(precio, 2), FormatNumber(ImporteDsct, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ieps, 2), FormatNumber(MyTotal - MyTotalSI, 2), FormatNumber(MyTotal, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))

                    T_descuento = T_descuento + ImpDscto
                    T_ieps = T_ieps + ieps
                    T_iva = T_iva + (MyTotal - MyTotalSI)
                    T_subtotal = T_subtotal + MyTotalSI
                    T_total = T_total + (MyTotal + XTem)
                    T_productos = T_productos + CDbl(cantidad)
                    txtutilidad.Text = CDbl(txtutilidad.Text) + MyUC2

                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close()
            barcarga.Visible = False
            barcarga.Value = 0

            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            txtutilidad.Text = FormatNumber(txtutilidad.Text, 2)
            txtSuma.Text = FormatNumber(T_productos, 2)
        End If


        'Productos
        If (optproducto.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un proucto para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from VentasDetalle where Nombre='" & ComboBox1.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            Dim IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
            Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0

            Dim temp As Integer = 0
            Dim Totales As Double = 0
            Dim T_Peso As Double = 0

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from VentasDetalle where Nombre='" & ComboBox1.Text & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0 order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As Integer = rd1("Folio").ToString
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim barras As String = CB(codigo)
                    Dim descrip As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("Unidad").ToString
                    Dim cantidad As Double = IIf(rd1("Cantidad").ToString = "", 0, rd1("Cantidad").ToString)
                    Dim precio As Double = rd1("PrecioSinIVA").ToString
                    Dim ieps As Double = rd1("TotalIEPS").ToString
                    Dim fecha As String = rd1("Fecha").ToString
                    Dim Dscto As Double = rd1("Descto").ToString
                    Dim MyTotalSI As Double = rd1("TotalSinIVA").ToString
                    Dim MyTotal As Double = rd1("Total").ToString
                    Dim lote As String = rd1("Lote").ToString
                    Dim caduca As String = rd1("Caducidad").ToString
                    Dim MyUC2 As Double = DameUti(folio, codigo, cantidad)
                    Dim ImporteDsct As Double = Dscto / cantidad
                    Dim opeso As Double = Peso_Prod(codigo) * cantidad

                    grdcaptura.Rows.Add(folio, descrip, opeso, unidad, cantidad, FormatNumber(precio, 2), FormatNumber(ImporteDsct, 2), FormatNumber(MyTotalSI - ieps, 2), FormatNumber(ieps, 2), FormatNumber(MyTotal - MyTotalSI, 2), FormatNumber(MyTotal, 2), FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(MyUC2, 2))

                    T_descuento = T_descuento + ImpDscto
                    T_ieps = T_ieps + ieps
                    T_iva = T_iva + (MyTotal - MyTotalSI)
                    T_subtotal = T_subtotal + MyTotalSI
                    T_total = T_total + (MyTotal + XTem)
                    T_productos = T_productos + CDbl(cantidad)
                    txtutilidad.Text = CDbl(txtutilidad.Text) + MyUC2
                    txtpeso.Text = CDbl(txtpeso.Text) + opeso

                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close()
            barcarga.Visible = False
            barcarga.Value = 0

            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            txtutilidad.Text = FormatNumber(txtutilidad.Text, 2)
            txtSuma.Text = FormatNumber(T_productos, 2)
        End If


        'Vendedor
        If (optvendedor.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un usuario para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Folio) from Ventas where Usuario='" & ComboBox1.Text & "' and FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Folio <>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            Dim IvaTemp As Double = 0, YTem As Double = 0, XTem As Double = 0, ImpDscto As Double = 0, VarSumXD As Double = 0, VarSubtotal As Double = 0
            Dim Desc As Double = 0, Desc3 As Double = 0, Desc2 As Double = 0

            Dim temp As Integer = 0
            Dim Totales As Double = 0

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ventas where Usuario='" & ComboBox1.Text & "' and FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As Integer = rd1("Folio").ToString
                    Dim Dscto As Double = rd1("Descuento").ToString
                    Dim MyTotalSI As Double = rd1("Subtotal").ToString
                    Dim MyTotal As Double = rd1("Totales").ToString
                    Dim iva As String = rd1("IVA").ToString
                    Dim acuentas As Double = rd1("ACuenta").ToString()
                    Dim resta As Double = rd1("Resta").ToString()
                    Dim estatus As String = rd1("Status").ToString()




                    grdcaptura.Rows.Add(folio, FormatNumber(Dscto, 2), FormatNumber(MyTotalSI, 2), FormatNumber(MyTotal - MyTotalSI, 2), FormatNumber(MyTotal, 2), FormatNumber(acuentas, 2), FormatNumber(resta, 2), estatus)

                    T_descuento = T_descuento + ImpDscto
                    T_iva = T_iva + (MyTotal - MyTotalSI)
                    T_subtotal = T_subtotal + MyTotalSI
                    T_total = T_total + (MyTotal + XTem)

                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close()
            barcarga.Visible = False
            barcarga.Value = 0

            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            txtutilidad.Text = FormatNumber(txtutilidad.Text, 2)
        End If


        'Devoluciones
        If (optdevoluciones.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from Devoluciones where Fecha between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Devoluciones where Fecha between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As String = rd1("Folio").ToString()
                    Dim cliente As String = rd1("Nombre").ToString()
                    Dim cantid As Double = rd1("Cantidad").ToString()
                    Dim precio As Double = rd1("Precio").ToString()
                    Dim total_devo As Double = rd1("Total").ToString()
                    Dim fecha As String = rd1("Fecha").ToString()

                    grdcaptura.Rows.Add(folio, cliente, cantid, FormatNumber(precio, 2), FormatNumber(total_devo, 2), fecha)
                    barcarga.Value = barcarga.Value + 1

                    T_total = T_total + total_devo
                End If
            Loop
            rd1.Close() : cnn1.Close()
            txttotal.Text = FormatNumber(T_total, 2)
            barcarga.Visible = False
            barcarga.Value = 0
        End If


        'Prod mas ven
        If (optmasvendido.Checked) Then

            Dim sumacantidad As Double = 0
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Delete from ProMasVen"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Codigo, Nombre, Unidad from VentasDetalle where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and (Facturado <> 'DEVOLUCION' and Facturado <> 'CANCELADO' and Folio <> 0 ) order by Codigo"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    'cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            cnn2.Close() : cnn2.Open()
            'cmd1.CommandText = "SELECT * FROM "
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim codigo As String = rd1("Codigo").ToString()
                    Dim nombre As String = rd1("Nombre").ToString()
                    Dim unidad As String = rd1("Unidad").ToString()
                    Dim cantidad As Double = 0
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select sum(Cantidad) from VentasDetalle where Codigo='" & codigo & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and (Facturado <> 'DEVOLUCION' and Facturado <> 'CANCELADO' and Folio <> 0 )"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cantidad = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into ProMasVen(Cod,Cant,Descrip,Unidad,Inicio,Final) values('" & codigo & "'," & cantidad & ",'" & nombre & "','" & unidad & "','" & Format(M1, "yyyy-MM-dd") & "','" & Format(M2, "yyyy-MM-dd") & "')"
                    cmd2.ExecuteNonQuery()

                    sumacantidad = sumacantidad + CDbl(cantidad)
                End If
            Loop
            cnn2.Close()
            rd1.Close()
            cnn1.Close()

            txtSuma.Text = FormatNumber(sumacantidad, 2)

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ProMasVen order by Cant"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdcaptura.Rows.Add(rd1("Cod").ToString(), rd1("Descrip").ToString(), rd1("Unidad").ToString(), rd1("Cant").ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()

        End If

        'prod mas ven provee

        If (optmasvendidoprov.Checked) Then

            Try
                Dim cantidadpro As Double = 0

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                'cmd1.CommandText = "SELECT count(VD.folio) FROM ventasdetalle VD INNER JOIN productos P ON VD.Codigo=P.Codigo AND VD.Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "'"
                cmd1.CommandText = "SELECT count(Codigo) FROM ventasdetalle WHERE Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuenta = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuenta


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT DISTINCT VD.CODIGO,VD.NOMBRE,vD.Unidad FROM ventasdetalle VD INNER JOIN productos P ON VD.Codigo=P.Codigo WHERE VD.Fecha between '" & Format(M1, "yyyy-MM-dd") & "' AND '" & Format(M2, "yyyy-MM-dd") & "' AND P.ProvPri='" & ComboBox1.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        Dim codigo As String = rd1("Codigo").ToString()
                        Dim nombre As String = rd1("Nombre").ToString()
                        Dim unidad As String = rd1("Unidad").ToString()
                        Dim cantidad As Double = 0
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                        "select sum(Cantidad) from VentasDetalle where Codigo='" & codigo & "' and Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and (Facturado <> 'DEVOLUCION' and Facturado <> 'CANCELADO' and Folio <> 0 )"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                cantidad = rd2(0).ToString()
                            End If
                        End If
                        rd2.Close()

                        grdcaptura.Rows.Add(codigo, nombre, unidad, cantidad)
                        cantidadpro = cantidadpro + CDbl(cantidad)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtSuma.Text = FormatNumber(cantidadpro, 2)

                barcarga.Visible = False
                barcarga.Value = 0

            Catch ex As Exception
                MessageBox.Show(e.ToString)
                cnn1.Close()
            End Try

        End If

        'Formatos
        If (RadioButton1.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Folio) from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Status<>'CANCELADA'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    '     cuenta = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuenta

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Status<>'CANCELADA' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim folio As String = rd1("Folio").ToString()
                    Dim cliente As String = rd1("Cliente").ToString()
                    Dim descuento As Double = 0
                    Dim subtotal As Double = 0
                    Dim IVA As Double = 0
                    Dim IEPS As Double = 0
                    Dim total As Double = 0
                    Dim acuenta As Double = rd1("ACuenta").ToString()
                    Dim resta As Double = rd1("Resta").ToString()
                    Dim status As String = rd1("Status").ToString()
                    Dim fecha As Date = rd1("FVenta").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select sum(Total) as Tot, sum(TotalSinIVA) as Sub, sum(Descto) as Descu, sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            subtotal = IIf(rd2("Sub").ToString = "", 0, rd2("Sub").ToString())
                            IVA = CDbl(IIf(rd2("Tot").ToString() = "", 0, rd2("Tot").ToString())) - CDbl(IIf(rd2("Sub").ToString() = "", 0, rd2("Sub").ToString()))
                            total = IIf(rd2("Tot").ToString() = "", 0, rd2("Tot").ToString())
                            descuento = IIf(rd2("Descu").ToString() = "", 0, rd2("Descu").ToString())
                            IEPS = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                        End If
                    End If
                    rd2.Close()

                    grdcaptura.Rows.Add(folio, cliente, FormatNumber(descuento, 2), FormatNumber(subtotal, 2), FormatNumber(IEPS, 2), FormatNumber(IVA, 2), FormatNumber(total, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2), status, FormatDateTime(fecha, DateFormat.ShortDate))
                    ' barcarga.Value = barcarga.Value + 1

                    T_descuento = T_descuento + descuento
                    T_ieps = T_ieps + IEPS
                    T_iva = T_iva + IVA
                    T_subtotal = T_subtotal + subtotal
                    T_total = T_total + total
                    T_acuenta = T_acuenta + acuenta
                    t_resta = t_resta + resta
                End If
            Loop
            rd1.Close() : cnn1.Close()
            txtdescuento.Text = FormatNumber(T_descuento, 2)
            txtieps.Text = FormatNumber(T_ieps, 2)
            txtsubtotal.Text = FormatNumber(T_subtotal, 2)
            txtiva.Text = FormatNumber(T_iva, 2)
            txttotal.Text = FormatNumber(T_total, 2)
            txtacuenta.Text = FormatNumber(T_acuenta, 2)
            txtresta.Text = FormatNumber(t_resta, 2)
            barcarga.Visible = False
            barcarga.Value = 0
        End If
    End Sub

    Public Function Peso_Prod(ByVal codigo As String) As Double
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select Multiplo from Productos where Codigo='" & codigo & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    Peso_Prod = rd5(0).ToString()
                End If
            End If
            rd5.Close() : cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn5.Close()
        End Try
    End Function

    Private Function DameUti(ByVal folio As Integer, ByVal codigo As String, ByVal cantidad As Double) As Double
        Try
            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select Utilidad from Costeo where Referencia='" & folio & "' and Salida=" & cantidad & " and Codigo='" & codigo & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    DameUti = IIf(rd4(0).ToString() = "", 0, rd4(0).ToString())
                End If
            End If
            rd4.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try
    End Function

    Private Sub ComboBox1_DropDown(sender As System.Object, e As System.EventArgs) Handles ComboBox1.DropDown
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        Dim querry As String = ""
        ComboBox1.Items.Clear()

        If (opttotales.Checked) Then
            querry = "SELECT DISTINCT Status FROM ventas WHERE FVenta BETWEEN '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' AND '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' "
        End If

        If (optcliente.Checked) Then
            querry = "select distinct Cliente from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Cliente<>'' order by Cliente"
        End If
        If (optclientedet.Checked) Then
            querry = "select distinct Cliente from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Cliente<>'' order by Cliente"
        End If
        If (optdepto.Checked) Then
            querry = "select distinct Depto from VentasDetalle where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Depto<>'' order by Depto"
        End If
        If (optgrupo.Checked) Then
            querry = "select distinct Grupo from VentasDetalle where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Grupo<>'' order by Grupo"
        End If
        If (optproducto.Checked) Then
            querry = "select distinct Nombre from VentasDetalle where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Nombre<>'' order by Nombre"
        End If
        If (optvendedor.Checked) Then
            querry = "select distinct Usuario from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "' and Usuario<>''"
        End If

        If (optmasvendidoprov.Checked) Then
            querry = "SELECT DISTINCT ProvPri FROM Productos WHERE ProvPri<>'' ORDER BY ProvPri"
        End If

        If (RadioButton1.Checked) Then
            querry = "select distinct Formato from Ventas where FVenta between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpfin.Text & "'"
        End If

        If (optDerivados.Checked) Then
            querry =
                    "select Codigo from Productos where LENGTH(Codigo)=6 order by Codigo"
        End If

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                querry
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then ComboBox1.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function CB(ByVal cod As String) As String
        Try
            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select * from Productos where Codigo='" & cod & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    CB = rd4("CodBarra").ToString
                End If
            End If
            rd4.Close() : cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
        Return CB
    End Function

    Private Function IvaDSC(ByVal cod As String) As Double
        Try
            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select * from Productos where Codigo='" & cod & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    IvaDSC = rd4("IVA").ToString
                End If
            Else
                IvaDSC = 0
            End If
            rd4.Close() : cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
        Return IvaDSC
    End Function

    Private Sub optclientedet_Click(sender As System.Object, e As System.EventArgs) Handles optclientedet.Click
        If (optclientedet.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            If (Partes) Then
                grdcaptura.ColumnCount = 15
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(1)
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(2)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(14)
                        .HeaderText = "Ult. Costo"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 14
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(1)
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(2)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "Ult. Costo"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            End If

            Exportar.Enabled = False
            lblacuenta.Visible = True
            txtacuenta.Visible = True
            lblresta.Visible = True
            txtresta.Visible = True
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = False
            txtutilidad.Visible = False


            lblpeso.Visible = False
            txtpeso.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optdepto_Click(sender As System.Object, e As System.EventArgs) Handles optdepto.Click
        If (optdepto.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 14
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Código"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Cod. Barras"
                    .Width = 120
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Unidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Cantidad"
                    .Width = 85
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "IEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "IVA"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(11)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(12)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(13)
                    .HeaderText = "Ult. Costo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = True
            txtutilidad.Visible = True


            lblpeso.Visible = False
            txtpeso.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optgrupo_Click(sender As System.Object, e As System.EventArgs) Handles optgrupo.Click
        If (optgrupo.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 14
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Código"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Cod. Barras"
                    .Width = 120
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Unidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Cantidad"
                    .Width = 85
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "IEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "IVA"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(11)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(12)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(13)
                    .HeaderText = "Ult. Costo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = True
            txtutilidad.Visible = True

            lblpeso.Visible = False
            txtpeso.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optproducto_Click(sender As System.Object, e As System.EventArgs) Handles optproducto.Click
        If (optproducto.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 13
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Peso"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Unidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Cantidad"
                    .Width = 85
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "IEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "IVA"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(11)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(12)
                    .HeaderText = "Utl. Costo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = False
            txtutilidad.Visible = False


            lblpeso.Visible = True
            txtpeso.Visible = True

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optvendedor_Click(sender As Object, e As EventArgs) Handles optvendedor.Click
        If (optvendedor.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "IVA"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Totales"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "A Cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Status"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
            lblacuenta.Visible = True
            txtacuenta.Visible = True
            lblresta.Visible = True
            txtresta.Visible = True
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = False
            txtutilidad.Visible = False


            lblpeso.Visible = False
            txtpeso.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optdevoluciones_Click(sender As Object, e As EventArgs) Handles optdevoluciones.Click
        If (optdevoluciones.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 6
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripcion"
                    .Width = 280
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Cantidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha"
                    .Width = 130
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
            lblacuenta.Visible = True
            txtacuenta.Visible = True
            lblresta.Visible = True
            txtresta.Visible = True
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = False
            txtutilidad.Visible = False


            lblieps.Visible = False
            txtieps.Visible = False

            lblpeso.Visible = False
            txtpeso.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub


    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        If (RadioButton1.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            ComboBox1.Focus().Equals(True)
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 11
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "IEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "IVA"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Estado"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False

            lblacuenta.Visible = True
            txtacuenta.Visible = True
            lblresta.Visible = True
            txtresta.Visible = True
            lbliva.Visible = True
            txtiva.Visible = True
            lblutilidad.Visible = False
            txtutilidad.Visible = False


            lblpeso.Visible = False
            txtpeso.Visible = False
            btnprint.Visible = False

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optmasvendido_Click(sender As Object, e As EventArgs) Handles optmasvendido.Click
        If (optmasvendido.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 4
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Codigo"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripción"
                    .Width = 240
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Unidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Cantidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False

            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            lbliva.Visible = False
            txtiva.Visible = False
            lblutilidad.Visible = False
            txtutilidad.Visible = False
            lblCosto.Visible = False
            txtCosto.Visible = False

            lblpeso.Visible = False
            txtpeso.Visible = False
            btnprint.Visible = False
            lbldescuento.Visible = False
            txtdescuento.Visible = False
            lblsubtotal.Visible = False
            txtsubtotal.Visible = False
            lbltotal.Visible = False
            txttotal.Visible = False
        End If
    End Sub

    Private Sub optmasvendidoprov_Click(sender As Object, e As EventArgs) Handles optmasvendidoprov.Click
        If (optmasvendidoprov.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            ComboBox1.Focus().Equals(True)
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            grdcaptura.ColumnCount = 4
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Codigo"
                    .Width = 90
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripción"
                    .Width = 240
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Unidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Cantidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With

            'Exportar.Enabled = False

            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            lbliva.Visible = False
            txtiva.Visible = False
            lblutilidad.Visible = False
            txtutilidad.Visible = False

            lblpeso.Visible = False
            txtpeso.Visible = False
            btnprint.Visible = False
            lbldescuento.Visible = False
            txtdescuento.Visible = False
            lblsubtotal.Visible = False
            txtsubtotal.Visible = False
            lbltotal.Visible = False
            txttotal.Visible = False
        End If
    End Sub

    Private Sub Exportar_Click(sender As Object, e As EventArgs) Handles Exportar.Click

        If grdcaptura.Rows.Count = 0 Then
            Exit Sub
        End If

        If MsgBox("¿Desea exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Application.ActiveSheet

            Dim Fila As Integer = 0
            Dim Col As Integer = 0

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = grdcaptura.ColumnCount
            Dim NRow As Integer = grdcaptura.RowCount

            exHoja.Columns("A").NumberFormat = "@"
            exHoja.Columns("B").NumberFormat = "@"
            exHoja.Columns("C").NumberFormat = "@"
            exHoja.Columns("D").NumberFormat = "@"
            exHoja.Columns("I").NumberFormat = "@"
            exHoja.Columns("G").NumberFormat = "@"
            exHoja.Columns("K").NumberFormat = "@"
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila = 0 To NRow - 1
                For Col = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
                Next
            Next

            Dim Fila2 As Integer = Fila + 2
            Dim Col2 As Integer = Col

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()

            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
        End Try

    End Sub

    Private Sub optdetalle2_Click(sender As Object, e As EventArgs) Handles optdetalle2.Click
        If (optdetalle2.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            If (Partes) Then
                grdcaptura.ColumnCount = 18
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
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
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(14)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(15)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(16)
                        .HeaderText = "A Cuenta"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(17)
                        .HeaderText = "Resta"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 17
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
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
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(14)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(15)
                        .HeaderText = "A Cuenta"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(16)
                        .HeaderText = "Resta"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            End If

            Exportar.Enabled = False
            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = True
            txtutilidad.Visible = True
            lblCosto.Visible = False
            txtCosto.Visible = False

            lblpeso.Visible = False
            txtpeso.Visible = False

            lblieps.Visible = True
            txtieps.Visible = True

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub optDerivados_Click(sender As Object, e As EventArgs) Handles optDerivados.Click
        If (optDerivados.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            txtiva.Text = "0.00"
            txtdescuento.Text = "0.00"
            txtsubtotal.Text = "0.00"
            txtieps.Text = "0.00"
            txttotal.Text = "0.00"
            txtutilidad.Text = "0.00"
            txtpeso.Text = "0.00"
            txtacuenta.Text = "0.00"
            txtresta.Text = "0.00"
            txtrestante.Text = "0.00"
            txtVendido.Text = "0.00"
            txtPropina.Text = "0.00"
            txtCosto.Text = "0.00"
            txtSuma.Text = "0.00"

            If (Partes) Then
                grdcaptura.ColumnCount = 17
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
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
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Porcentaje"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(14)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(15)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(16)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 16
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
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
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Porcentaje"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(14)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(15)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            End If

            Exportar.Enabled = False
            lblacuenta.Visible = False
            txtacuenta.Visible = False
            lblresta.Visible = False
            txtresta.Visible = False
            txtiva.Visible = True
            lbliva.Visible = True
            lblutilidad.Visible = True
            txtutilidad.Visible = True


            lblpeso.Visible = False
            txtpeso.Visible = False

            lblieps.Visible = True
            txtieps.Visible = True

            lbldescuento.Visible = True
            txtdescuento.Visible = True
            lblsubtotal.Visible = True
            txtsubtotal.Visible = True
            lbltotal.Visible = True
            txttotal.Visible = True
        End If
    End Sub

    Private Sub lblutilidad_DoubleClick(sender As Object, e As EventArgs) Handles lblutilidad.DoubleClick
        'cnn1.Close() : cnn1.Open()

        'For pipi As Integer = 0 To grdcaptura.Rows.Count - 1
        '    Dim folio As Integer = grdcaptura.Rows(pipi).Cells(0).Value.ToString()
        '    Dim codigo As String = grdcaptura.Rows(pipi).Cells(2).Value.ToString()
        '    Dim cantidad As Double = grdcaptura.Rows(pipi).Cells(6).Value.ToString()
        '    Dim iva As Double = 0
        '    Dim precio As Double = 0
        '    Dim Pre_Comp As Double = 0
        '    Dim MyCostVUE As Double = 0

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText =
        '        "select * from Productos where Codigo='" & codigo & "'"
        '    rd1 = cmd1.ExecuteReader
        '    If rd1.HasRows Then
        '        If rd1.Read Then
        '            precio = rd1("PrecioVentaIVA").ToString()
        '            iva = rd1("IVA").ToString()
        '            Pre_Comp = rd1("PrecioCompra").ToString()
        '            MyCostVUE = Pre_Comp * (cantidad / CDbl(rd1("MCD").ToString()))
        '        End If
        '    End If
        '    rd1.Close()

        '    Dim total1 As Double = precio * cantidad

        '    Dim precio1 As Double = precio / (1 + iva)
        '    Dim total2 As Double = total1 / (1 + iva)

        '    Dim iva1 As Double = total2 - total1

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText =
        '        "update VentasDetalle set Precio=" & FormatNumber(precio, 2) & ", Total=" & FormatNumber(total1, 2) & ", PrecioSinIVA=" & FormatNumber(precio1, 2) & ", TotalSinIVA=" & FormatNumber(total2, 2) & ", CostoVUE=" & MyCostVUE & " where Codigo='" & codigo & "' and Folio=" & folio
        '    cmd1.ExecuteNonQuery()
        'Next
        'cnn1.Close()
    End Sub
End Class