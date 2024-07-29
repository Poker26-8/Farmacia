Public Class frmLotesyCad
    Private Sub optCaducos_Click(sender As Object, e As EventArgs) Handles optCaducos.Click

        If (optCaducos.Checked) Then
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Enabled = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            My.Application.DoEvents()

            grdCaptura.ColumnCount = 6
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Código"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(2)
                    .HeaderText = "Unidad"
                    .Width = 60
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
                With .Columns(4)
                    .HeaderText = "F.Caducidad"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Lote"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
            btnReporte.Focus().Equals(True)
        End If

    End Sub

    Private Sub optCaducidad_Click(sender As Object, e As EventArgs) Handles optCaducidad.Click

        If (optCaducidad.Checked) Then
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Enabled = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            My.Application.DoEvents()
            grdCaptura.ColumnCount = 6
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Código"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(2)
                    .HeaderText = "Unidad"
                    .Width = 60
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
                With .Columns(4)
                    .HeaderText = "F.Caducidad"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Lote"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnReporte.Focus().Equals(True)
        End If

    End Sub

    Private Sub optCaducidades_Click(sender As Object, e As EventArgs) Handles optCaducidades.Click
        If (optCaducidades.Checked) Then
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Enabled = True

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            My.Application.DoEvents()
            grdCaptura.ColumnCount = 7
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Código"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(2)
                    .HeaderText = "Lote"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "F.Caducidad"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Comprados"
                    .Width = 85
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Vendidos"
                    .Width = 85
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Existentes"
                    .Width = 85
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
            btnReporte.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        grdCaptura.Rows.Clear()

        If (optCaducos.Checked) Then
            Caducos()
        End If
        If (optCaducidad.Checked) Then
            Caducidad()
        End If
        If (optCaducidades.Checked) Then
            If cboDatos.Text = "" Then MsgBox("Selecciona un producto para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDatos.Focus().Equals(True) : Exit Sub
            Caducidades()
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdCaptura.Rows.Count = 0 Then Exit Sub
        If MsgBox("¿Deseas exportar esta información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocio Pro") = vbOK Then
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exBook As Microsoft.Office.Interop.Excel.Workbook
            Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("B").NumberFormat = "@"
                If (optCaducos.Checked) Or (optCaducidad.Checked) Or (optCaducidades.Checked) Then
                Else
                    exSheet.Columns("F").NumberFormat = "$#,##0.00"
                    exSheet.Columns("G").NumberFormat = "$#,##0.00"
                    exSheet.Columns("H").NumberFormat = "$#,##0.00"
                    exSheet.Columns("I").NumberFormat = "$#,##0.00"
                End If

                Dim Fila As Integer = 0
                Dim Col As Integer = 0

                Dim NCol As Integer = grdCaptura.ColumnCount
                Dim NRow As Integer = grdCaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdCaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila = 0 To NRow - 1
                    For Col = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdCaptura.Rows(Fila).Cells(Col).Value.ToString
                    Next
                Next

                If (optCaducos.Checked) Or (optCaducidad.Checked) Or (optCaducidades.Checked) Then
                Else
                    Dim Fila2 As Integer = Fila + 2
                    exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Valor de Compra Total"
                    exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1
                    exSheet.Cells.Item(Fila2 + 3, Col - 1) = "Valor de Venta Total"
                    exSheet.Cells.Item(Fila2 + 3, Col - 1).Font.Bold = 1

                    'exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtCompraTot.Text, 2)
                    ' exSheet.Cells.Item(Fila2 + 3, Col) = FormatNumber(txtVentaTot.Text, 2)
                End If

                exSheet.Rows.Item(1).Font.Bold = 1
                exSheet.Rows.Item(1).HorizontalAlignment = 3
                exSheet.Columns.AutoFit()

                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            barCarga.Value = 0
            barCarga.Visible = False

            MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Caducos()

        Dim m1 As Date = mcdesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select P.Codigo,P.Nombre,P.UVenta,Lc.Cantidad,Lc.Caducidad,Lc.Lote from Productos P INNER JOIN LoteCaducidad Lc ON P.Codigo=Lc.Codigo where Lc.Caducidad BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' and Lc.Cantidad>0 order by P.Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("UVenta").ToString
                    Dim canidad As Double = rd1("Cantidad").ToString
                    Dim fecha As String = FormatDateTime(rd1("Caducidad").ToString, DateFormat.ShortDate)
                    Dim lote As String = rd1("Lote").ToString

                    grdCaptura.Rows.Add(codigo, nombre, unidad, canidad, fecha, lote)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub Caducidad()
        Dim m1 As Date = mcdesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select P.Codigo,P.Nombre,P.UVenta,Lc.Cantidad,Lc.Caducidad,Lc.Lote from Productos P INNER JOIN LoteCaducidad Lc ON P.Codigo=Lc.Codigo where Lc.Caducidad between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and Lc.Cantidad>0 order by P.Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("UVenta").ToString
                    Dim canidad As Double = rd1("Cantidad").ToString
                    Dim fecha As String = FormatDateTime(rd1("Caducidad").ToString, DateFormat.ShortDate)
                    Dim lote As String = rd1("Lote").ToString

                    grdCaptura.Rows.Add(codigo, nombre, unidad, canidad, fecha, lote)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub Caducidades()
        Dim m1 As Date = mcdesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString
        Dim EXIST As Single = 0
        Dim CantCompra As Single = 0
        Dim CantVta As Single = 0
        Dim idL As Double = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Productos.Codigo,Productos.Nombre, SUM(LoteCaducidad.Cantidad) as TCant, LoteCaducidad.Lote, LoteCaducidad.id, LoteCaducidad.Caducidad from Productos INNER JOIN LoteCaducidad ON Productos.Codigo=LoteCaducidad.Codigo where Productos.Nombre='" & cboDatos.Text & "' GROUP BY Productos.Codigo,Productos.Nombre,LoteCaducidad.Lote,LoteCaducidad.id,LoteCaducidad.Caducidad"
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    EXIST = rd1("TCant").ToString
                    idL = rd1("id").ToString
                    Dim fecha As String = FormatDateTime(rd1("Caducidad").ToString, DateFormat.ShortDate)
                    Dim lote As String = rd1("Lote").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select LoteCaducidad.Codigo,SUM(VentasDetalle.Cantidad) as CantVend, LoteCaducidad.id from LoteCaducidad INNER JOIN VentasDetalle ON LoteCaducidad.Lote=VentasDetalle.Lote where LoteCaducidad.id=" & idL & " and LoteCaducidad.Codigo='" & codigo & "' and VentasDetalle.Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' GROUP BY LoteCaducidad.Codigo,LoteCaducidad.id"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then
                            CantVta = CantCompra + CDbl(rd2("CantVend").ToString)
                        End If
                    Loop
                    rd2.Close()

                    CantCompra = EXIST + CantVta

                    grdCaptura.Rows.Add(codigo, nombre, lote, fecha, CantCompra, CantVta, EXIST)
                End If
            Loop
            cnn2.Close()
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown
        cboDatos.Items.Clear()

        If (optCaducos.Checked) Then
            Exit Sub
        End If
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            If (optCaducidades.Checked) Then
                cmd5.CommandText = "select distinct Nombre from Productos where Nombre<>''"
            End If
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDatos.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub frmLotesyCad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        optCaducos.Checked = True
        mcdesde.SetDate(Now)
        mcHasta.SetDate(Now)
    End Sub

    Private Sub cboDatos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDatos.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnReporte.Focus.Equals(True)
        End If
    End Sub

    Private Sub optCaducos_CheckedChanged(sender As Object, e As EventArgs) Handles optCaducos.CheckedChanged
        If (optCaducos.Checked) Then
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Enabled = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            My.Application.DoEvents()

            grdCaptura.ColumnCount = 6
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Código"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(2)
                    .HeaderText = "Unidad"
                    .Width = 60
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
                With .Columns(4)
                    .HeaderText = "F.Caducidad"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Lote"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdCaptura.Rows.Clear()
        optCaducos.Checked = True
        mcdesde.SetDate(Now)
        mcHasta.SetDate(Now)
    End Sub
End Class