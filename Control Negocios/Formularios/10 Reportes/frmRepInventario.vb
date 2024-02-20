Imports Microsoft.Office.Interop.Excel

Public Class frmRepInventario

    Dim Libreria As Boolean = False
    Dim Partes As Boolean = False

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btncardex.Click
        frmCardex.Show()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles btnentrada.Click
        frmTraspEntrada.Show()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles btnsalida.Click
        frmTraspSalida.Show()
    End Sub

    Private Sub btnetiquetas_Click(sender As System.Object, e As System.EventArgs) Handles btnetiquetas.Click
        frmEtiquetas.Show()
    End Sub

    Private Sub optProveedor_Click(sender As System.Object, e As System.EventArgs) Handles optProveedor.Click
        If (optProveedor.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = True
            boxcaduca.Enabled = False
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            My.Application.DoEvents()

            If (Libreria) Then
            Else
                If (Partes) Then
                    grdcaptura.ColumnCount = 10
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "N. Parte"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(3)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(4)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 9
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(3)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(4)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                End If
            End If
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub frmRepInventario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim fecha As String = DatosRecarga("FechaCosteo")
        cbofiltro.Items.Clear()
        cbofiltro.Text = ""
        cbofiltro.Enabled = True

        optProveedor.Checked = True
        optDepartamento.Checked = False
        optGrupo.Checked = False
        optTodos.Checked = False
        optCaducos.Checked = False
        optCaducidad.Checked = False
        optCaducidades.Checked = False

        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 0
        dtpFin.Value = Date.Now
        dtpIni.Value = Date.Now
        boxcaduca.Enabled = False

        If fecha <> "" Then
            IniCosteo.Value = fecha
        Else
            IniCosteo.Value = Now
        End If
        FinaCosteo.Value = Now

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='Libreria'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Libreria = IIf(rd1(0).ToString = "0", False, True)
                End If
            Else
                Libreria = False
            End If
            rd1.Close()

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
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        optProveedor.PerformClick()
    End Sub

    Private Sub optDepartamento_Click(sender As Object, e As System.EventArgs) Handles optDepartamento.Click
        If (optDepartamento.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = True
            boxcaduca.Enabled = False
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            My.Application.DoEvents()

            If (Libreria) Then
            Else
                If (Partes) Then
                    grdcaptura.ColumnCount = 10
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "N. Parte"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(3)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(4)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 9
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(3)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(4)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                End If
            End If
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optGrupo_Click(sender As System.Object, e As System.EventArgs) Handles optGrupo.Click
        If (optGrupo.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = True
            boxcaduca.Enabled = False
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            My.Application.DoEvents()

            If (Libreria) Then
            Else
                If (Partes) Then
                    grdcaptura.ColumnCount = 10
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "N. Parte"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(3)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(4)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 9
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(3)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(4)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                End If
            End If
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optTodos_Click(sender As System.Object, e As System.EventArgs) Handles optTodos.Click
        If (optTodos.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = False
            boxcaduca.Enabled = False
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            My.Application.DoEvents()

            If (Libreria) Then
            Else
                If (Partes) Then
                    grdcaptura.ColumnCount = 10
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "N. Parte"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(3)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(4)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 9
                    With grdcaptura
                        With .Columns(0)
                            .HeaderText = "Código"
                            .Width = 70
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(1)
                            .HeaderText = "Cod. Barras"
                            .Width = 90
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(2)
                            .HeaderText = "Descripción"
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End With
                        With .Columns(3)
                            .HeaderText = "Unidad"
                            .Width = 60
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(4)
                            .HeaderText = "Existencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(5)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                End If
                My.Application.DoEvents()
            End If

            Dim rows As Integer = 0
            Dim ValCompra As Double = 0
            Dim ValVenta As Double = 0

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select count(Codigo) from Productos where Length(Codigo)<=6 and Departamento<>'SERVICIOS'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        rows = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                txtregistros.Text = rows

                barCarga.Visible = True
                barCarga.Value = 0
                barCarga.Maximum = rows

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Length(Codigo)>=1 and Length(Codigo)<=6 and Departamento<>'SERVICIOS' order by Nombre"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Dim codigo As String = IIf(rd1("Codigo").ToString = "", "-", rd1("Codigo").ToString)
                    Dim barras As String = IIf(rd1("CodBarra").ToString = "", "", rd1("CodBarra").ToString)
                    Dim nombre As String = IIf(rd1("Nombre").ToString = "", "-", rd1("Nombre").ToString)
                    Dim unidad As String = IIf(rd1("UVenta").ToString = "", "SN", rd1("UVenta").ToString)
                    Dim existe As Double = IIf(rd1("Existencia").ToString = "", 0, rd1("Existencia").ToString)
                    Dim mutiplo As Double = IIf(rd1("Multiplo").ToString = "", 0, rd1("Multiplo").ToString)
                    Dim exitencia As Double = existe / mutiplo
                    Dim pcompra As Double = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                    Dim pventa As Double = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)
                    Dim n_parte As String = IIf(rd1("N_Serie").ToString() = "", "", rd1("N_Serie").ToString())

                    Dim vcompra As Double = pcompra * existe
                    Dim vventa As Double = pventa * existe
                    vcompra = IIf(vcompra < 0, 0, vcompra)
                    vventa = IIf(vventa < 0, 0, vventa)
                    If (Libreria) Then

                    Else
                        If (Partes) Then
                            grdcaptura.Rows.Add(codigo, barras, n_parte, nombre, unidad, existe, FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                        Else
                            grdcaptura.Rows.Add(codigo, barras, nombre, unidad, existe, FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                        End If
                    End If
                    ValCompra = ValCompra + vcompra
                    ValVenta = ValVenta + vventa
                    barCarga.Value = barCarga.Value + 1
                Loop
                rd1.Close() : cnn1.Close()
                barCarga.Visible = False
                barCarga.Value = 0
                txtCompraTot.Text = FormatNumber(ValCompra, 2)
                txtVentaTot.Text = FormatNumber(ValVenta, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbofiltro_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofiltro.DropDown
        cbofiltro.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If (optProveedor.Checked) Then
                cmd1.CommandText =
                    "select distinct ProvPri from Productos where ProvPri<>''"
            End If
            If (optDepartamento.Checked) Then
                cmd1.CommandText =
                    "select distinct Departamento from Productos where Departamento <> 'SERVICIOS' and Departamento<>''"
            End If
            If (optGrupo.Checked) Then
                cmd1.CommandText =
                    "select distinct Grupo from Productos where Grupo<>''"
            End If
            If (optCaducidades.Checked) Then
                cmd1.CommandText =
                    "select distinct Nombre from Productos where Nombre<>''"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbofiltro.Items.Add(rd1(0).ToString)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofiltro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbofiltro.KeyPress
        Dim sql1 As String = "", sql2 As String = ""
        Dim rows As Integer = 0
        Dim ValCompra As Double = 0
        Dim ValVenta As Double = 0
        txtCompraTot.Text = "0.00"
        txtVentaTot.Text = "0.00"

        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                If (optProveedor.Checked) Then
                    sql1 = "select count(Codigo) from Productos where ProvPri='" & cbofiltro.Text & "' and Length(Codigo)<=6"
                    sql2 = "select * from Productos where ProvPri='" & cbofiltro.Text & "' and Length(Codigo)<=6 order by Nombre"
                End If
                If (optDepartamento.Checked) Then
                    sql1 = "select count(Codigo) from Productos where Departamento='" & cbofiltro.Text & "' and Length(Codigo)<=6"
                    sql2 = "select * from Productos where Departamento='" & cbofiltro.Text & "' and Length(Codigo)<=6 order by Nombre"
                End If
                If (optGrupo.Checked) Then
                    sql1 = "select count(Codigo) from Productos where Grupo='" & cbofiltro.Text & "' and Length(Codigo)<=6"
                    sql2 = "select * from Productos where Grupo='" & cbofiltro.Text & "' and Length(Codigo)<=6 order by Nombre"
                End If
                If (optCaducidades.Checked) Then
                    btnCaduc.Focus().Equals(True)
                    Exit Sub
                End If

                grdcaptura.Rows.Clear()

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    sql1
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        rows = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                txtregistros.Text = rows

                barCarga.Visible = True
                barCarga.Value = 0
                barCarga.Maximum = rows

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    sql2
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Dim codigo As String = IIf(rd1("Codigo").ToString = "", "-", rd1("Codigo").ToString)
                    Dim barras As String = IIf(rd1("CodBarra").ToString = "", "", rd1("CodBarra").ToString)
                    Dim nombre As String = IIf(rd1("Nombre").ToString = "", "-", rd1("Nombre").ToString)
                    Dim unidad As String = IIf(rd1("UVenta").ToString = "", "SN", rd1("UVenta").ToString)
                    Dim existe As Double = IIf(rd1("Existencia").ToString = "", 0, rd1("Existencia").ToString)
                    Dim mutiplo As Double = IIf(rd1("Multiplo").ToString = "", 0, rd1("Multiplo").ToString)
                    Dim exitencia As Double = existe / mutiplo
                    Dim pcompra As Double = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                    Dim pventa As Double = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)

                    Dim vcompra As Double = pcompra * existe
                    Dim vventa As Double = pventa * existe

                    If (Libreria) Then

                    Else
                        grdcaptura.Rows.Add(codigo, barras, nombre, unidad, existe, FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                    End If
                    ValCompra = ValCompra + vcompra
                    ValVenta = ValVenta + vventa
                    barCarga.Value = barCarga.Value + 1
                Loop
                rd1.Close() : cnn1.Close()
                barCarga.Visible = False
                barCarga.Value = 0
                txtCompraTot.Text = FormatNumber(ValCompra, 2)
                txtVentaTot.Text = FormatNumber(ValVenta, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnexcel_Click(sender As System.Object, e As System.EventArgs) Handles btnexcel.Click
        If grdcaptura.Rows.Count = 0 Then Exit Sub
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

                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila = 0 To NRow - 1
                    For Col = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
                    Next
                Next

                If (optCaducos.Checked) Or (optCaducidad.Checked) Or (optCaducidades.Checked) Then
                Else
                    Dim Fila2 As Integer = Fila + 2
                    exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Valor de Compra Total"
                    exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1
                    exSheet.Cells.Item(Fila2 + 3, Col - 1) = "Valor de Venta Total"
                    exSheet.Cells.Item(Fila2 + 3, Col - 1).Font.Bold = 1

                    exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtCompraTot.Text, 2)
                    exSheet.Cells.Item(Fila2 + 3, Col) = FormatNumber(txtVentaTot.Text, 2)
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

    Private Sub btncatalogo_Click(sender As System.Object, e As System.EventArgs) Handles btncatalogo.Click
        If MsgBox("¿Deseas exportar todo tu catálogo a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            cbofiltro.Items.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = False

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0

            grdcaptura.ColumnCount = 14
            With grdcaptura.Columns(0)
                .Name = "Código"
                .Width = 45
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(1)
                .Name = "Cod. Barras"
                .Width = 110
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(2)
                .Name = "Nombre"
                .Width = 210
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(3)
                .Name = "Nombre Largo"
                .Width = 250
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(4)
                .Name = "Proveedor"
                .Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(5)
                .Name = "Unidad"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(6)
                .Name = "Departamento"
                .Width = 110
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(7)
                .Name = "Grupo"
                .Width = 110
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(8)
                .Name = "Precio de Compra"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(9)
                .Name = "Precio de Venta"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(10)
                .Name = "Precio Venta IVA"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(11)
                .Name = "Precio Venta Minimo"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(12)
                .Name = "IVA"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(13)
                .Name = "Existencia"
                .Width = 80
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            Dim rows As Integer = 0

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select count(Codigo) from Productos"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        rows = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barCarga.Value = 0
                barCarga.Visible = True
                barCarga.Maximum = rows

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos order by Nombre"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim barras As String = rd1("CodBarra").ToString
                    Dim nlargo As String = rd1("NombreLargo").ToString
                    Dim prove As String = rd1("ProvPri").ToString
                    Dim unidad As String = rd1("UVenta").ToString
                    Dim depart As String = rd1("Departamento").ToString
                    Dim grupo As String = rd1("Grupo").ToString

                    Dim p_compra As Double = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                    Dim p_venta As Double = IIf(rd1("PrecioVenta").ToString = "", 0, rd1("PrecioVenta").ToString)
                    Dim p_ventaiva As Double = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)
                    Dim p_minimo As Double = IIf(rd1("PreMin").ToString = "", 0, rd1("PreMin").ToString)

                    Dim iva As Double = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                    Dim existencia As Double = IIf(IsDBNull(rd1("Existencia").ToString), 0, rd1("Existencia").ToString)

                    grdcaptura.Rows.Add(codigo, barras, nombre, nlargo, prove, unidad, depart, grupo, FormatNumber(p_compra, 2), p_venta, p_ventaiva, p_minimo, iva, existencia)
                    barCarga.Value += 1
                Loop
                rd1.Close() : cnn1.Close()
                barCarga.Value = 0
                barCarga.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

            My.Application.DoEvents()

            barCarga.Value = 0
            barCarga.Visible = True
            barCarga.Maximum = grdcaptura.Rows.Count

            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            Try
                lblexportar.Visible = True
                exLibro = exApp.Workbooks.Add
                exHoja = exLibro.Worksheets.Application.ActiveSheet

                exHoja.Columns("A").NumberFormat = "@"
                exHoja.Columns("B").NumberFormat = "@"
                exHoja.Columns("I").NumberFormat = "$#,##0.00"
                exHoja.Columns("J").NumberFormat = "$#,##0.00"
                exHoja.Columns("K").NumberFormat = "$#,##0.00"
                exHoja.Columns("L").NumberFormat = "$#,##0.00"

                Dim Fila As Integer = 0
                Dim Col As Integer = 0

                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                For i As Integer = 1 To NCol
                    exHoja.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila = 0 To NRow - 1
                    For Col = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 2, Col + 1) = Convert.ToString(grdcaptura.Rows(Fila).Cells(Col).Value.ToString)
                    Next
                    My.Application.DoEvents()
                    lblexportar.Text = "Exportando producto " & grdcaptura.Rows(Fila).Cells(2).Value.ToString
                    barCarga.Value = barCarga.Value + 1
                Next

                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.Item(1).HorizontalAlignment = 3
                exHoja.Columns.AutoFit()

                exApp.Application.Visible = True

                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            barCarga.Value = 0
            barCarga.Visible = False

            My.Application.DoEvents()

            MsgBox("Catálogo exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
            lblexportar.Visible = False
            grdcaptura.Rows.Clear()
            optProveedor.PerformClick()
        End If
    End Sub

    Private Sub optCaducos_Click(sender As System.Object, e As System.EventArgs) Handles optCaducos.Click
        If (optCaducos.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = False
            boxcaduca.Enabled = True
            dtpFin.Enabled = False
            dtpIni.Enabled = False
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            My.Application.DoEvents()
            grdcaptura.ColumnCount = 6
            With grdcaptura
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
            btnCaduc.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnCaduc_Click(sender As System.Object, e As System.EventArgs) Handles btnCaduc.Click
        If (optCaducos.Checked) Then
            Caducos()
        End If
        If (optCaducidad.Checked) Then
            Caducidad()
        End If
        If (optCaducidades.Checked) Then
            If cbofiltro.Text = "" Then MsgBox("Selecciona un producto para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofiltro.Focus().Equals(True) : Exit Sub
            Caducidades()
        End If
        If (optperdidas.Checked) Then
            Perdidas()
        End If
    End Sub

    Public Sub Perdidas()
        Dim conteo As Double = 0
        Try
            grdcaptura.Rows.Clear()
            cnn1.Close() : cnn1.Open()

            Dim valor_co As Double = 0
            Dim valor_ve As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Merma where Fecha between '" & Format(dtpIni.Value, "yyyy-MM-dd 00:00:00") & "' and '" & Format(dtpFin.Value, "yyyy-MM-dd 23:59:59") & "' order by Id"
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim cantidad As Double = rd1("Cantidad").ToString
                    Dim unidad As String = rd1("Unidad").ToString
                    Dim fecha As String = rd1("Fecha").ToString
                    Dim compra As Double = 0, venta As Double = 0
                    Dim v_compra As Double = 0
                    Dim v_venta As Double = 0
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from Productos where Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            compra = rd2("PrecioCompra").ToString
                            venta = rd2("PrecioVentaIVA").ToString
                        End If
                    End If
                    rd2.Close()
                    v_compra = Math.Abs(cantidad) * compra
                    v_venta = Math.Abs(cantidad) * venta
                    grdcaptura.Rows.Add(codigo, nombre, unidad, cantidad, FormatDateTime(fecha, DateFormat.ShortDate), FormatNumber(compra, 2))

                    valor_co = valor_co + v_compra
                    valor_ve = valor_ve + v_venta
                End If
                conteo += 1
            Loop
            cnn2.Close()
            rd1.Close() : cnn1.Close()
            txtCompraTot.Text = FormatNumber(valor_co, 2)
            txtVentaTot.Text = FormatNumber(valor_ve, 2)
            txtregistros.Text = conteo
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub Caducidades()
        Dim EXIST As Single = 0
        Dim CantCompra As Single = 0
        Dim CantVta As Single = 0
        Dim idL As Double = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Productos.Codigo,Productos.Nombre, SUM(LoteCaducidad.Cantidad) as TCant, LoteCaducidad.Lote, LoteCaducidad.id, LoteCaducidad.Caducidad from Productos INNER JOIN LoteCaducidad ON Productos.Codigo=LoteCaducidad.Codigo where Productos.Nombre='" & cbofiltro.Text & "' GROUP BY Productos.Codigo,Productos.Nombre,LoteCaducidad.Lote,LoteCaducidad.id,LoteCaducidad.Caducidad"
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
                        "select LoteCaducidad.Codigo,SUM(VentasDetalle.Cantidad) as CantVend, LoteCaducidad.id from LoteCaducidad INNER JOIN VentasDetalle ON LoteCaducidad.Lote=VentasDetalle.Lote where LoteCaducidad.id=" & idL & " and LoteCaducidad.Codigo='" & codigo & "' and VentasDetalle.Fecha between '" & Format(dtpIni.Value, "yyyy-MM-dd") & "' and '" & Format(dtpFin.Value, "yyyy-MM-dd") & "' GROUP BY LoteCaducidad.Codigo,LoteCaducidad.id"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then
                            CantVta = CantCompra + CDbl(rd2("CantVend").ToString)
                        End If
                    Loop
                    rd2.Close()

                    CantCompra = EXIST + CantVta

                    grdcaptura.Rows.Add(codigo, nombre, lote, fecha, CantCompra, CantVta, EXIST)
                End If
            Loop
            cnn2.Close()
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub Caducidad()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select P.Codigo,P.Nombre,P.UVenta,Lc.Cantidad,Lc.Caducidad,Lc.Lote from Productos P INNER JOIN LoteCaducidad Lc ON P.Codigo=Lc.Codigo where Lc.Caducidad between '" & Format(dtpIni.Value, "yyyy-MM-dd") & "' and '" & Format(dtpFin.Value, "yyyy-MM-dd") & "' and Lc.Cantidad>0 order by Lc.Caducidad"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("UVenta").ToString
                    Dim canidad As Double = rd1("Cantidad").ToString
                    Dim fecha As String = FormatDateTime(rd1("Caducidad").ToString, DateFormat.ShortDate)
                    Dim lote As String = rd1("Lote").ToString

                    grdcaptura.Rows.Add(codigo, nombre, unidad, canidad, fecha, lote)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Caducos()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select P.Codigo,P.Nombre,P.UVenta,Lc.Cantidad,Lc.Caducidad,Lc.Lote from Productos P INNER JOIN LoteCaducidad Lc ON P.Codigo=Lc.Codigo where Lc.Caducidad<'" & Format(Date.Now, "yyyy-MM-dd") & "' and Lc.Cantidad>0 order by Lc.Caducidad"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("UVenta").ToString
                    Dim canidad As Double = rd1("Cantidad").ToString
                    Dim fecha As String = FormatDateTime(rd1("Caducidad").ToString, DateFormat.ShortDate)
                    Dim lote As String = rd1("Lote").ToString

                    grdcaptura.Rows.Add(codigo, nombre, unidad, canidad, fecha, lote)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub optCaducidad_Click(sender As System.Object, e As System.EventArgs) Handles optCaducidad.Click
        If (optCaducidad.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = False
            boxcaduca.Enabled = True
            dtpFin.Enabled = True
            dtpIni.Enabled = True
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            My.Application.DoEvents()
            grdcaptura.ColumnCount = 6
            With grdcaptura
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
            btnCaduc.Focus().Equals(True)
        End If
    End Sub

    Private Sub optCaducidades_Click(sender As System.Object, e As System.EventArgs) Handles optCaducidades.Click
        If (optCaducidades.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = True
            boxcaduca.Enabled = True
            dtpFin.Enabled = True
            dtpIni.Enabled = True
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            My.Application.DoEvents()
            grdcaptura.ColumnCount = 7
            With grdcaptura
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
            btnCaduc.Focus().Equals(True)
        End If
    End Sub

    Private Sub optCaducidad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optCaducidad.CheckedChanged

    End Sub
    Private Sub btnreporte_Click(sender As System.Object, e As System.EventArgs) Handles btnreporte.Click
        'Producto
        Dim PCodigo As String = ""
        Dim PNombre As String = ""
        Dim PCosto As Double = 0
        Dim PPrecio As Double = 0
        Dim PIVA As Double = 0

        Dim cuantos As Integer = 0

        Dim InvInicial As Double = 0
        Dim InvFinal As Double = 0
        Dim TotalInvInicial As Double = 0
        Dim CostoInvIni As Double = 0
        Dim Efectivo_Ventas As Double = 0
        Dim Efectivo_Costo As Double = 0
        Dim Tota_Utilidad As Double = 0

        'Compras
        Dim CantComp As Double = 0
        Dim CtsTotal As Double = 0
        'Devoluciones
        Dim DevProd As Double = 0
        Dim Efe_Devol As Double = 0
        'Ventas
        Dim VtaTotal As Double = 0
        Dim CantProd As Double = 0

        Dim FechaInvInicial As String = ""
        Dim FechaIni As String = ""
        Dim FechaFin As String = ""
        Dim Reporte As Boolean = False
        Dim FolReporte As Integer = 0

        On Error GoTo quepaso_wey

        FechaInvInicial = DatosRecarga("FechaCosteo")
        If FechaInvInicial = "" Then
            SFormatos("FechaCosteo", Format(Date.Now, "dd/MM/yyyy"))
            MsgBox("La fecha establecida para el inventario inicial es: " & Format(Date.Now, "dd/MM/yyyy"), vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            FechaInvInicial = Format(Date.Now, "dd/MM/yyyy")
            FechaIni = Format(Date.Now, "dd/MM/yyyy")
            FechaFin = Format(Date.Now, "dd/MM/yyyy")
            EInvInicial()
            Exit Sub
        Else
            FechaIni = FechaInvInicial
            FechaFin = Format(Date.Now, "dd/MM/yyyy")
        End If

        Reporte = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "update Productos set Cargado=0, CargadoInv=0, InvInicial=0,InvFinal=0, InvInicialCosto=0, InvFinalCosto=0"
        cmd1.ExecuteNonQuery()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select distinct (TA.Codigo), PR.Nombre from TAlmacen TA INNER JOIN Productos PR ON TA.Codigo=PR.Codigo where TA.Fecha>='" & FechaIni & "' and TA.Fecha<='" & FechaFin & "' and TA.FolioReporte=0"
        rd1 = cmd1.ExecuteReader
        cnn2.Close() : cnn2.Open()
        Do While rd1.Read
            'Llena código y nombre
            PCodigo = rd1("Codigo").ToString()
            PNombre = rd1("Nombre").ToString()

            'Obtiene inventario inicial
            InvInicial = InventarioI(PCodigo, CostoInvIni)

            'Obtiene el la cantidad comprada
            CantComp = CompP(PCodigo, FechaIni, FechaFin)

            'Obtiene la cantidad de productos devueltos
            DevProd = Canc_Dev(PCodigo, FechaIni, FechaFin)

            'Obtiene la cantidad de ventas | Precio del producto con IVA | Total de la ventas | Total en costo por las ventas
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select PrecioCompra, PrecioVentaIVA, IVA from Productos where Codigo='" & PCodigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    PIVA = rd2("IVA").ToString()
                    PCosto = rd2("PrecioCompra").ToString()
                    PPrecio = rd2("PrecioVentaIVA").ToString()
                End If
            End If
            rd2.Close()

            Efe_Devol = Efectivo_Dev(PCodigo, FechaIni, FechaFin)

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select SUM(VD.Total) as TotalPre, SUM(VD.Cantidad) as CantP from Ventas V INNER JOIN VentasDetalle VD ON VD.Folio=V.Folio where VD.Codigo='" & PCodigo & "' and V.Status<>'CANCELADA' and VD.Fecha>='" & Format(CDate(FechaIni), "yyyy-MM-dd") & "' and VD.Fecha<='" & Format(CDate(FechaFin), "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    VtaTotal = IIf(rd2("TotalPre").ToString() = "", 0, rd2("TotalPre").ToString())
                    CantProd = IIf(rd2("CantP").ToString() = "", 0, rd2("CantP").ToString())
                End If
            Else
                VtaTotal = 0
                CantProd = 0
            End If
            rd2.Close()

            InvFinal = ((InvInicial + CantComp) - CantProd) + DevProd

            CtsTotal = CantProd * PCosto

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "update Productos set Cargado=0, CargadoInv=0, InvInicial=" & InvInicial & " where Codigo='" & PCodigo & "'"
            cmd2.ExecuteNonQuery()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "update Productos set Cargado=0, CargadoInv=0, InvFinal=" & InvFinal & " where Codigo='" & PCodigo & "'"
            cmd2.ExecuteNonQuery()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "insert into RepoMen(Codigo,PDesc,InvIni,Compra,CantDev,InvFin,CVta,PPrecio,VtaTotal,CostoTotal) values('" & PCodigo & "','" & PNombre & "'," & InvInicial & "," & CantComp & "," & DevProd & "," & InvFinal & "," & CantProd & "," & PPrecio & "," & VtaTotal & "," & CtsTotal & ")"
            cmd2.ExecuteNonQuery()

            Reporte = True
            cuantos += 1
        Loop
        cnn2.Close()
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select sum(VtaTotal) as Vent, sum(CostoTotal) as Cost from RepoMen"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Efectivo_Ventas = rd1("Vent").ToString()
                Efectivo_Costo = rd1("Cost").ToString()
            End If
        End If
        rd1.Close() : cnn1.Close()

        Tota_Utilidad = FormatNumber(Efectivo_Ventas - Efectivo_Costo, 4)

        System.Threading.Thread.Sleep(1000)

        If Reporte = True Then
            If MsgBox("¿Deseas establecer un inventario inicial para el siguiente reporte?", vbQuestion + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update TAlmacen set FechaReporte='" & Format(Date.Now, "dd/MM/yyyy") & "' where FolioReporte=0"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select MAX(FolioReporte) from TAlmacen"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        FolReporte = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()) + 1
                    End If
                Else
                    FolReporte = 1
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update TAlmacen set FolioReporte=" & FolReporte & " where FolioReporte=0"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Devoluciones set FolioReporte=" & FolReporte & " where FolioReporte=0"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update ComprasDet set FolioRep=" & FolReporte & " where FolioRep=0"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into HEResultados(Codigo,PDesc,InvIni,Compra,CantDev,InvFin,Cvta,PPrecio,VtaTotal,CostoTotal) select Codigo,PDesc,InvIni,Compra,CantDev,InvFin,CVta,PPrecio,VtaTotal,CostoTotal from RepoMen"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select MAX(Folio_Rep) from HEResultados"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        FolReporte = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()) + 1
                    End If
                Else
                    FolReporte = 1
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update HEResultados set C_Vtas=" & Efectivo_Ventas & ", C_Utilidad=" & Tota_Utilidad & ", C_Costo=" & Efectivo_Costo & ", Folio_Rep=" & FolReporte & ", Fecha_Rep='" & Format(Date.Now, "dd/MM/yyyy") & "', Fecha_Ini='" & FechaIni & "' where Folio_Rep=0"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update VentasDetalle set VDCosteo=1 where VDCosteo=0"
                cmd1.ExecuteNonQuery()

                cnn1.Close()

                EInvInicial()
                SFormatos("FechaCosteo", Format(Date.Now, "dd/MM/yyyy"))
            End If

            'Genera el reporte (yo digo que en Excel), sí en Excel
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from RepoMen order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdestado.Rows.Add(
                        rd1("Codigo").ToString(),
                        rd1("PDesc").ToString(),
                        rd1("InvIni").ToString(),
                        rd1("Compra").ToString(),
                        rd1("CantDev").ToString(),
                        rd1("InvFin").ToString(),
                        rd1("CVta").ToString(),
                        rd1("PPrecio").ToString(),
                        rd1("VtaTotal").ToString(),
                        rd1("CostoTotal").ToString()
                        )
                End If
            Loop
            rd1.Close() : cnn1.Close()

            If grdestado.Rows.Count = 0 Then Exit Sub
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exBook As Microsoft.Office.Interop.Excel.Workbook
            Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

            exBook = exApp.Workbooks.Add
            exSheet = exBook.Application.ActiveSheet

            exSheet.Columns("A").NumberFormat = "@"
            exSheet.Columns("B").NumberFormat = "@"

            Dim Fila As Integer = 0
            Dim Col As Integer = 0

            Dim NCol As Integer = grdestado.ColumnCount
            Dim NRow As Integer = grdestado.RowCount

            For i As Integer = 1 To NCol
                exSheet.Cells.Item(1, i) = grdestado.Columns(i - 1).HeaderText.ToString
            Next

            For Fila = 0 To NRow - 1
                For Col = 0 To NCol - 1
                    exSheet.Cells.Item(Fila + 2, Col + 1) = grdestado.Rows(Fila).Cells(Col).Value.ToString
                Next
            Next

            Dim Fila2 As Integer = Fila + 2
            ''Aquí manda los datos conclusorios

            'exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Valor de Compra Total"
            'exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1
            'exSheet.Cells.Item(Fila2 + 3, Col - 1) = "Valor de Venta Total"
            'exSheet.Cells.Item(Fila2 + 3, Col - 1).Font.Bold = 1

            'exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtCompraTot.Text, 2)
            'exSheet.Cells.Item(Fila2 + 3, Col) = FormatNumber(txtVentaTot.Text, 2)

            exSheet.Rows.Item(1).Font.Bold = 1
            exSheet.Rows.Item(1).HorizontalAlignment = 3
            exSheet.Columns.AutoFit()

            exApp.Application.Visible = True
            exSheet = Nothing
            exBook = Nothing
            exApp = Nothing

            barCarga.Value = 0
            barCarga.Visible = False

            MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Else
            If DatosRecarga("FechaCosteo") = "" Then
                EInvInicial()
                SFormatos("FechaCosteo", Format(Date.Now, "yyyy-MM-dd"))
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(FolioReporte) from TAlmacen where FolioReporte=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = 0 Then
                        EInvInicial()
                        SFormatos("FechaCosteo", Format(Date.Now, "yyyy-MM-dd"))
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()
        End If

        Exit Sub
quepaso_wey:
        MsgBox(Err.Number & " - " & Err.Description & vbNewLine &
               "No se pudo continuar con el proceso, inténtalo de nuevo más tarde. Sí el problema persiste comunícate con tu proveedor de software", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Exit Sub
    End Sub

    Private Sub EInvInicial()
        Dim codigoProd As String = ""
        Dim fechaAhora As String = Format(Date.Now, "dd/MM/yyyy")
        Dim unidadProd As String = ""
        Dim existeProd As Double = 0
        Dim costoProd As Double = 0
        Dim totalCosto As Double = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos"
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                If rd1.HasRows Then
                    codigoProd = rd1("Codigo").ToString()
                    unidadProd = rd1("UVenta").ToString()
                    existeProd = rd1("Existencia").ToString()
                    costoProd = rd1("PrecioCompra").ToString()
                    totalCosto = existeProd * costoProd

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into TAlmacen(Codigo,Fecha,Folio,TipoMov,Entrada,UndE,Salida,UndS,Exist,Costo,Debe,ExiCont,Haber,Saldo,FolioReporte,FechaReporte) values('" & codigoProd & "','" & fechaAhora & "',0,'Inventario inicial',0,'" & unidadProd & "',0,'" & unidadProd & "'," & existeProd & "," & costoProd & ",0," & existeProd & "," & totalCosto & "," & totalCosto & ",0,'')"
                    cmd2.ExecuteNonQuery()
                End If
            Loop
            rd1.Close() : cnn1.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function InventarioI(ByVal COD As String, ByRef CostoInv As Double) As Double
        Dim FCosteo As String = DatosRecarga("FechaCosteo")
        FCosteo = IIf(FCosteo = "", Format(Date.Now, "dd/MM/yyyy"), FCosteo)

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            ' cmd3.CommandText =
            '  "select TOP 1 IDTAlmacen,Exist,Saldo from TAlmacen where Codigo='" & COD & "' and Fecha>='" & FCosteo & "' and FolioReporte=0 and TipoMov='Inventario inicial' order by IDTAlmacen desc"
            cmd3.CommandText =
                "select IDTAlmacen,Exist,Saldo from TAlmacen where Codigo='" & COD & "' and Fecha>='" & FCosteo & "' and FolioReporte=0 and TipoMov='Inventario inicial' LIMIT 1"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    InventarioI = rd3("Exist").ToString()
                    CostoInv = rd3("Saldo").ToString()
                End If
            Else
                InventarioI = 0
                CostoInv = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Function CompP(ByVal Cod As String, ByVal FFechaIni As Date, ByVal FFechaFin As Date) As Double
        CompP = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select SUM(Cantidad) as II from ComprasDet where Codigo='" & Cod & "' and FechaC>='" & Format(FFechaIni, "yyyy-MM-dd 00:00:00") & "' and FechaC<='" & Format(FFechaFin, "yyyy-MM-dd 23:59:59") & "' and FolioRep=0"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    CompP = IIf(rd3("II").ToString() = "", 0, rd3("II").ToString())
                End If
            Else
                CompP = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Function Canc_Dev(ByVal Cod As String, ByVal FFechaIni As Date, ByVal FFechaFin As Date) As Double
        Canc_Dev = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select SUM(Cantidad) as CD from Devoluciones where Codigo='" & Cod & "' and Fecha>='" & Format(FFechaIni, "yyyy-MM-dd 00:00:00") & "' and Fecha<='" & Format(FFechaFin, "yyyy-MM-dd 23:59:59") & "' and FolioReporte=0"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Canc_Dev = IIf(rd3("CD").ToString() = "", 0, rd3("CD").ToString())
                End If
            Else
                Canc_Dev = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
        Return Canc_Dev
    End Function

    Private Function Efectivo_Dev(ByVal Cod As String, ByVal FFechaIni As Date, ByVal FFechaFin As Date) As Double
        Efectivo_Dev = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select SUM(Cantidad * CostoVUE) as Cant from Devoluciones where Codigo='" & Cod & "' and Facturado='DEVOLUCION' and Fecha>='" & Format(FFechaIni, "yyyy-MM-dd 00:00:00") & "' and Fecha<='" & Format(FFechaFin, "yyyy-MM-dd 23:59:59") & "' and FolioReporte=0"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Efectivo_Dev = IIf(rd3("Cant").ToString() = "", 0, rd3("Cant").ToString())
                End If
            Else
                Efectivo_Dev = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Sub btnExistencia_Click(sender As Object, e As EventArgs) Handles btnExistencia.Click
        Try

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0

            grdcaptura.ColumnCount = 3
            With grdcaptura.Columns(0)
                .Name = "Código"
                .Width = 45
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(1)
                .Name = "Nombre"
                .Width = 110
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With grdcaptura.Columns(2)
                .Name = "Existencias"
                .Width = 210
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If (optProveedor.Checked) Then
                cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE ProvPri='" & cbofiltro.Text & "'"
            End If

            If (optDepartamento.Checked) Then
                cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Departamento='" & cbofiltro.Text & "'"
            End If

            If (optGrupo.Checked) Then
                cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Grupo='" & cbofiltro.Text & "'"
            End If

            If (optTodos.Checked) Then
                cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos"
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    grdcaptura.Rows.Add(rd1(0).ToString,
                                        rd1(1).ToString,
                                        rd1(2).ToString()
)

                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnExpExis_Click(sender As Object, e As EventArgs) Handles btnExpExis.Click
        If grdcaptura.Rows.Count = 0 Then Exit Sub
        If MsgBox("¿Deseas exportar esta información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocio Pro") = vbOK Then

            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exBook As Microsoft.Office.Interop.Excel.Workbook
            Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

            Try

                exBook = exApp.Workbooks.Add
                exSheet = exBook.Application.ActiveSheet

                Dim Fila As Integer = 0
                Dim Col As Integer = 0

                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila = 0 To NRow - 1
                    For Col = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
                    Next
                Next

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

    Private Sub btnImpExis_Click(sender As Object, e As EventArgs) Handles btnImpExis.Click

        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQL(DataGridView1)
        End If


    End Sub

    Private Sub Excel_Grid_SQL(ByVal tabla As DataGridView)

        Dim con As OleDb.OleDbConnection
        Dim dt As New System.Data.DataTable
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim cuadro_dialogo As New OpenFileDialog
        Dim ruta As String = ""
        Dim sheet As String = "hoja1"

        With cuadro_dialogo
            .Filter = "Archivos de cálculo(*.xls;*.xlsx)|*.xls;*.xlsx"
            .Title = "Selecciona el archivo a importar"
            .Multiselect = False
            .InitialDirectory = My.Application.Info.DirectoryPath & "\Archivos de importación"
            .ShowDialog()
        End With

    End Sub
End Class