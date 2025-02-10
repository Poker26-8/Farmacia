
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ClosedXML.Excel
Public Class frmRepInventario

    Dim Libreria As Boolean = False
    Dim Partes As Boolean = False


    Dim copeo As Integer = 0
    Dim restaurante As Integer = 0
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btncardex.Click
        frmCardex.Show()
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
                    grdcaptura.ColumnCount = 12
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(11)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 11
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
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
    Private Sub Lote_Caducidad(ByVal codigo As String, ByVal cantidad As Double, ByVal fecha As Date, ByVal lote As String)
        Dim caduci As String = ""

        If fecha = Nothing Then
            caduci = Date.Now
        Else
            caduci = Format(fecha, "yyyy-MM")
            My.Application.DoEvents()

        End If
        Try
            cnn4.Close() : cnn4.Open()
            cnn5.Close() : cnn5.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select Codigo from LoteCaducidad where Codigo='" & codigo & "' and Lote='" & lote & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                'Existe
                If rd4.Read Then
                    cmd5 = cnn5.CreateCommand
                    cmd5.CommandText = "update LoteCaducidad set Cantidad=" & cantidad & " where Codigo='" & codigo & "' and Lote='" & lote & "'"

                    cmd5.ExecuteNonQuery()
                End If
            Else
                'No existe
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & codigo & "','" & lote & "','" & caduci & "'," & cantidad & ")"
                cmd5.ExecuteNonQuery()
            End If
            rd4.Close()
            cnn4.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try
    End Sub

    Private Async Sub frmRepInventario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
            restaurante = Await ValidarAsync("Restaurante")
            Dim copas As Integer = Await ValidarAsync("Copa")
            Dim part As Integer = Await ValidarAsync("Partes")
            Dim refaccion As Integer = Await ValidarAsync("Refaccionaria")



            If copas = 1 Then
                copeo = 1
            Else
                copeo = 0
            End If

            If part = 1 Then
                Partes = True
            Else
                Partes = False
            End If

            If refaccion = 1 Then
                Partes = True
            Else
                Partes = False
            End If

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
            cnn1.Close()
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
                    grdcaptura.ColumnCount = 12
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(11)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 11
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
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
                    grdcaptura.ColumnCount = 12
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(11)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 11
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
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
                    grdcaptura.ColumnCount = 12
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(11)
                            .HeaderText = "Valor de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                    End With
                Else
                    grdcaptura.ColumnCount = 11
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
                            .HeaderText = "Pedidos"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(6)
                            .HeaderText = "Diferencia"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(7)
                            .HeaderText = "Precio de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(8)
                            .HeaderText = "Precio de venta"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(9)
                            .HeaderText = "Valor de compra"
                            .Width = 75
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            .Visible = True
                            .Resizable = DataGridViewTriState.False
                        End With
                        With .Columns(10)
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
                    "select Codigo,CodBarra,Nombre,UVenta,Existencia,Multiplo,PrecioCompra,PrecioVentaIVA,N_Serie,Copas from Productos where Length(Codigo)>=1 and Length(Codigo)<=6 and Departamento<>'SERVICIOS' order by Nombre"
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
                    Dim copas As Double = IIf(rd1("Copas").ToString() = 0, 1, rd1("Copas").ToString())

                    Dim vcompra As Double = pcompra * exitencia
                    Dim vventa As Double = pventa * exitencia
                    vcompra = IIf(vcompra < 0, 0, vcompra)
                    vventa = IIf(vventa < 0, 0, vventa)

                    Dim sumapedidos As Double = 0
                    Dim diferencia As Double = 0

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT SUM(Cantidad) FROM pedidosvendet WHERE Codigo='" & codigo & "' GROUP BY Codigo"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            sumapedidos = IIf(rd3(0).ToString = "", 0, rd3(0).ToString)
                        End If
                    Else
                        sumapedidos = "0"
                            End If
                            rd3.Close()
                    cnn3.Close()

                    diferencia = CDbl(exitencia) - CDbl(sumapedidos)

                    If (Libreria) Then

        Else
            If (Partes) Then
                            grdcaptura.Rows.Add(codigo, barras, n_parte, nombre, unidad, FormatNumber(exitencia, 2), sumapedidos, FormatNumber(diferencia, 2), FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                        Else
                            If restaurante = 1 And copeo = 1 Then
                                Dim existe_temp As Double = exitencia
                                Dim nueva_existe As Double = 0
                                If copas > 1 Then

                                    Dim posicion As Integer = 0
                                    Dim entero As String = ""
                                    Dim decimaaal As String = ""

                                    Dim decimaal_db As Double = 0

                                    posicion = InStr(CStr(exitencia), ".")
                                    If posicion = 0 Then
                                        nueva_existe = exitencia
                                    Else
                                        entero = Mid(CStr(exitencia), 1, posicion - 1)
                                        decimaaal = "0" & Mid(CStr(exitencia), posicion, 200)

                                        decimaal_db = FormatNumber(CDbl(decimaaal) * copas, 0)
                                        nueva_existe = entero & "." & decimaal_db
                                    End If

                                Else
                                    nueva_existe = exitencia
                                End If


                                grdcaptura.Rows.Add(codigo, barras, nombre, unidad, FormatNumber(nueva_existe, 2), sumapedidos, FormatNumber(diferencia, 2), FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                            Else
                                grdcaptura.Rows.Add(codigo, barras, nombre, unidad, FormatNumber(exitencia, 2), sumapedidos, FormatNumber(diferencia, 2), FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                            End If
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
                    "select distinct ProvPri from Productos where ProvPri<>'' ORDER BY ProvPri"
            End If
            If (optDepartamento.Checked) Then
                cmd1.CommandText =
                    "select distinct Departamento from Productos where Departamento <> 'SERVICIOS' and Departamento<>'' ORDER BY Departamento"
            End If
            If (optGrupo.Checked) Then
                cmd1.CommandText =
                    "select distinct Grupo from Productos where Grupo<>'' ORDER BY Grupo"
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
                    sql2 = "select Codigo,CodBarra,Nombre,UVenta,Existencia,Multiplo,PrecioCompra,PrecioVentaIVA,Copas,N_Serie from Productos where ProvPri='" & cbofiltro.Text & "' and Length(Codigo)<=6 order by Nombre"
                End If
                If (optDepartamento.Checked) Then
                    sql1 = "select count(Codigo) from Productos where Departamento='" & cbofiltro.Text & "' and Length(Codigo)<=6"
                    sql2 = "select Codigo,CodBarra,Nombre,UVenta,Existencia,Multiplo,PrecioCompra,PrecioVentaIVA,Copas,N_Serie from Productos where Departamento='" & cbofiltro.Text & "' and Length(Codigo)<=6 order by Nombre"
                End If
                If (optGrupo.Checked) Then
                    sql1 = "select count(Codigo) from Productos where Grupo='" & cbofiltro.Text & "' and Length(Codigo)<=6"
                    sql2 = "select Codigo,CodBarra,Nombre,UVenta,Existencia,Multiplo,PrecioCompra,PrecioVentaIVA,Copas,N_Serie from Productos where Grupo='" & cbofiltro.Text & "' and Length(Codigo)<=6 order by Nombre"
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
                    Dim copas As Double = IIf(rd1("Copas").ToString() = 0, 1, rd1("Copas").ToString())
                    Dim parte As String = IIf(rd1("N_Serie").ToString = "", "", rd1("N_Serie").ToString)

                    Dim vcompra As Double = pcompra * existe
                    Dim vventa As Double = pventa * existe

                    Dim peidos As Double = 0
                    Dim diferencia As Double = 0

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT SUM(Cantidad) FROM pedidosvendet WHERE Codigo='" & codigo & "' GROUP BY Codigo"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            peidos = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
                        End If
                    Else
                        peidos = "0"
                    End If
                    rd2.Close()
                    cnn2.Close()

                    diferencia = CDbl(existe) - CDbl(peidos)

                    If (Libreria) Then

                    Else
                        If (Partes) Then
                            grdcaptura.Rows.Add(codigo, barras, parte, nombre, unidad, existe, peidos, diferencia, FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                        Else
                            If restaurante = 1 And copeo = 1 Then
                                Dim existe_temp As Double = existe
                                Dim nueva_existe As Double = 0
                                If copas > 1 Then

                                    Dim posicion As Integer = 0
                                    Dim entero As String = ""
                                    Dim decimaaal As String = ""

                                    Dim decimaal_db As Double = 0

                                    posicion = InStr(CStr(existe), ".")
                                    If posicion = 0 Then
                                        nueva_existe = existe
                                    Else
                                        entero = Mid(CStr(existe), 1, posicion - 1)
                                        decimaaal = "0" & Mid(CStr(existe), posicion, 200)

                                        decimaal_db = FormatNumber(CDbl(decimaaal) * copas, 0)
                                        nueva_existe = entero & "." & decimaal_db
                                    End If
                                Else
                                    nueva_existe = existe
                                End If

                                grdcaptura.Rows.Add(codigo, barras, nombre, unidad, nueva_existe, peidos, diferencia, FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                            Else
                                grdcaptura.Rows.Add(codigo, barras, nombre, unidad, existe, peidos, diferencia, FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))
                            End If
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
    Public Sub ExportarDataGridViewAExcelxd(dgv As DataGridView)
        If grdcaptura.Rows.Count = 0 Then MsgBox("Genera el reporte para poder exportar los datos a Excel.", vbInformation + vbOKOnly, titulocentral) : Exit Sub
        If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

            Dim voy As Integer = 0
            ' Crea un nuevo libro de trabajo de Excel
            Using workbook As New XLWorkbook()

                ' Añade una nueva hoja de trabajo
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Datos")

                ' Escribe los encabezados de columna
                For colIndex As Integer = 0 To dgv.Columns.Count - 1
                    Dim headerCell As IXLCell = worksheet.Cell(1, colIndex + 1)
                    worksheet.Cell(1, colIndex + 1).Value = dgv.Columns(colIndex).HeaderText
                    headerCell.Value = dgv.Columns(colIndex).HeaderText
                    headerCell.Style.Font.Bold = True  ' Aplica negrita a los encabezados
                Next


                For rowIndex As Integer = 0 To dgv.Rows.Count - 1
                    For colIndex As Integer = 0 To dgv.Columns.Count - 1
                        Dim cellValue As Object = dgv.Rows(rowIndex).Cells(colIndex).Value
                        Dim cellValueString As String = If(cellValue Is Nothing, String.Empty, cellValue.ToString())
                        worksheet.Cell(rowIndex + 2, colIndex + 1).Value = cellValueString
                        Dim cell As IXLCell = worksheet.Cell(rowIndex + 2, colIndex + 1)
                        cell.Value = cellValueString
                        cell.Style.NumberFormat.Format = "@"
                    Next
                    voy = voy + 1
                    My.Application.DoEvents()
                Next

                worksheet.Columns().AdjustToContents()
                ' Usa MemoryStream para guardar el archivo en memoria y abrirlo
                Using memoryStream As New System.IO.MemoryStream()
                    ' Guarda el libro de trabajo en el MemoryStream
                    workbook.SaveAs(memoryStream)

                    ' Guarda el MemoryStream en un archivo temporal para abrirlo
                    Dim tempFilePath As String = IO.Path.GetTempPath() & Guid.NewGuid().ToString() & ".xlsx"
                    System.IO.File.WriteAllBytes(tempFilePath, memoryStream.ToArray())

                    ' Abre el archivo temporal en Excel
                    Process.Start(tempFilePath)
                End Using

                'workbook.SaveAs(filePath)
            End Using
            MessageBox.Show("Datos exportados exitosamente")

        End If
    End Sub

    Private Sub btnexcel_Click(sender As System.Object, e As System.EventArgs) Handles btnexcel.Click
        If grdcaptura.Rows.Count = 0 Then Exit Sub
        ExportarDataGridViewAExcelxd(grdcaptura)
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
                    "select Codigo,Nombre,CodBarra,NombreLargo,ProvPri,UVenta,Departamento,Grupo,PrecioCompra,PrecioVenta,PrecioVentaIVA,PreMin,IVA,Existencia from Productos order by Nombre"
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
                "select Codigo,Nombre,Cantidad,Unidad,Fecha from Merma where Fecha between '" & Format(dtpIni.Value, "yyyy-MM-dd 00:00:00") & "' and '" & Format(dtpFin.Value, "yyyy-MM-dd 23:59:59") & "' order by Id"
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
                        "select PrecioCompra,PrecioVentaIVA from Productos where Codigo='" & codigo & "'"
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
        Dim FechaIni As Date = Nothing
        Dim FechaFin As Date = Nothing
        Dim Reporte As Boolean = False
        Dim FolReporte As Integer = 0


        FechaInvInicial = DatosRecarga("FechaCosteo")
        If FechaInvInicial = "" Then
            SFormatos("FechaCosteo", Format(Date.Now, "dd/MM/yyyy"))
            MsgBox("La fecha establecida para el inventario inicial es: " & Format(Date.Now, "dd/MM/yyyy"), vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            FechaInvInicial = Format(Date.Now, "dd/MM/yyyy")
            FechaIni = Date.Now
            FechaFin = Date.Now
            EInvInicial()
            Exit Sub
        Else
            FechaIni = FechaInvInicial
            FechaFin = Date.Now
        End If

        Reporte = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "update Productos set Cargado=0, CargadoInv=0, InvInicial=0,InvFinal=0, InvInicialCosto=0, InvFinalCosto=0"
        cmd1.ExecuteNonQuery()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select distinct (TA.Codigo), PR.Nombre from TAlmacen TA INNER JOIN Productos PR ON TA.Codigo=PR.Codigo where TA.Fecha>='" & Format(FechaIni, "yyyy-MM-dd") & "' and TA.Fecha<='" & Format(FechaFin, "yyyy-MM-dd") & "' and TA.FolioReporte=0"
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
                "select SUM(VD.Total) as TotalPre, SUM(VD.Cantidad) as CantP from Ventas V INNER JOIN VentasDetalle VD ON VD.Folio=V.Folio where VD.Codigo='" & PCodigo & "' and V.Status<>'CANCELADA' and (VD.Fecha>='" & Format(CDate(FechaIni), "yyyy-MM-dd") & "' and VD.Fecha<='" & Format(CDate(FechaFin), "yyyy-MM-dd") & "') and VD.VDCosteo=0"
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
                Efectivo_Ventas = IIf(rd1("Vent").ToString = "", 0, rd1("Vent").ToString)
                Efectivo_Costo = IIf(rd1("Cost").ToString = "", 0, rd1("Cost").ToString)
            End If
        End If
        rd1.Close() : cnn1.Close()

        Tota_Utilidad = FormatNumber(Efectivo_Ventas - Efectivo_Costo, 4)

        Inserta_Reporte()

        Dim fol_historico As Integer = 0

        System.Threading.Thread.Sleep(1000)

        If Reporte = True Then

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

            fol_historico = FolReporte

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

            'Genera crystal
            Dim root_name_recibo As String = ""
            Dim FileOpen As New ProcessStartInfo
            Dim FileNta As New EdoResultados
            Dim strServerName As String = System.Windows.Forms.Application.StartupPath
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table

            crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\")
            root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf"

            If System.IO.File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf") Then
                System.IO.File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf")
            End If

            If varrutabase <> "" Then
                If System.IO.File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf") Then
                    System.IO.File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf")
                End If
            End If

            With crConnectionInfo
                .ServerName = "C:\ControlNegociosPro\DL1.mdb"
                .DatabaseName = "C:\ControlNegociosPro\DL1.mdb"
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
            FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & fol_historico & "'"
            FileNta.DataDefinition.FormulaFields("F_Inicial").Text = "'" & FormatDateTime(FechaIni, DateFormat.ShortDate) & "'"
            FileNta.DataDefinition.FormulaFields("F_Reporte").Text = "'" & FormatDateTime(FechaFin, DateFormat.ShortDate) & "'"

            FileNta.Refresh()
            FileNta.Refresh()
            FileNta.Refresh()
            If System.IO.File.Exists(root_name_recibo) Then
                System.IO.File.Delete(root_name_recibo)
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
                    MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            FileNta.Close()

            If varrutabase <> "" Then

                If System.IO.File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf") Then
                    System.IO.File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf")
                End If

                System.IO.File.Copy("C:\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ESTADO RESULTADOS\Folio_" & fol_historico & ".pdf")
            End If
            Exit Sub
            'MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
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

    Private Sub Inserta_Reporte()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New System.Data.DataTable

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
                .runSp(a_cnn, "delete from RepoMen", sinfo)
                sinfo = ""

                cnn4.Close() : cnn4.Open()

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                    "select Codigo,PDesc,InvIni,Compra,CantDev,InvFin,CVta,PPrecio,VtaTotal,CostoTotal from RepoMen"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then
                        If .runSp(a_cnn, "insert into RepoMen(Codigo,PDesc,InvIni,Compra,CantDev,InvFini,CVta,PPrecio,VtaTotal,CostoTotal) values('" & rd4("Codigo").ToString() & "','" & rd4("PDesc").ToString() & "'," & rd4("InvIni").ToString() & "," & rd4("Compra").ToString() & "," & rd4("CantDev").ToString() & "," & rd4("InvFin").ToString() & "," & rd4("CVta").ToString() & "," & rd4("PPrecio").ToString() & "," & rd4("VtaTotal").ToString() & "," & rd4("CostoTotal").ToString() & ")", sinfo) Then
                            sinfo = ""
                        Else
                            MsgBox(sinfo)
                        End If
                    End If
                Loop
                rd4.Close()
                cnn4.Close()
                a_cnn.Close()
            End If
        End With
    End Sub

    Private Sub EInvInicial()
        Dim codigoProd As String = ""
        Dim fechaAhora As Date = Date.Now
        Dim unidadProd As String = ""
        Dim existeProd As Double = 0
        Dim costoProd As Double = 0
        Dim totalCosto As Double = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,UVenta,Existencia,PrecioCompra from Productos"
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
                        "insert into TAlmacen(Codigo,Fecha,Folio,TipoMov,Entrada,UndE,Salida,UndS,Exist,Costo,Debe,ExiCont,Haber,Saldo,FolioReporte,FechaReporte) values('" & codigoProd & "','" & Format(fechaAhora, "yyyy-MM-dd") & "',0,'Inventario inicial',0,'" & unidadProd & "',0,'" & unidadProd & "'," & existeProd & "," & costoProd & ",0," & existeProd & "," & totalCosto & "," & totalCosto & ",0,'')"
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
        Dim fecha_consulta As Date = FCosteo

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select IDTAlmacen,Exist,Saldo from TAlmacen where Codigo='" & COD & "' and Fecha>='" & Format(fecha_consulta, "yyyy-MM-dd") & "' and FolioReporte=0 and TipoMov='Inventario inicial' LIMIT 1"
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

            If (rbPositivas.Checked) Then

                If (optProveedor.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE ProvPri='" & cbofiltro.Text & "' AND Existencia>0"
                End If

                If (optDepartamento.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Departamento='" & cbofiltro.Text & "' AND Existencia>0"
                End If

                If (optGrupo.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Grupo='" & cbofiltro.Text & "' AND Existencia>0"
                End If

                If (optTodos.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Existencia>0"
                End If

            End If

            If (rbNegativas.Checked) Then

                If (optProveedor.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE ProvPri='" & cbofiltro.Text & "' AND Existencia<=0"
                End If

                If (optDepartamento.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Departamento='" & cbofiltro.Text & "' AND Existencia<=0"
                End If

                If (optGrupo.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Grupo='" & cbofiltro.Text & "' AND Existencia<=0"
                End If

                If (optTodos.Checked) Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos WHERE Existencia<=0"
                End If

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

        ExportarDataGridViewAExcel(grdcaptura)

        'If grdcaptura.Rows.Count = 0 Then Exit Sub
        'If MsgBox("¿Deseas exportar esta información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocio Pro") = vbOK Then

        '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
        '    Dim exBook As Microsoft.Office.Interop.Excel.Workbook
        '    Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

        '    Try

        '        exBook = exApp.Workbooks.Add
        '        exSheet = exBook.Application.ActiveSheet
        '        exSheet.Columns("A").NumberFormat = "@"

        '        Dim columnasAExportar As Integer() = {0, 2, 4} ' Aquí se colocan los índices de las columnas que quieres exportar
        '        Dim Fila As Integer = 0
        '        Dim Col As Integer = 0
        '        ' Dim NCol As Integer = grdcaptura.ColumnCount
        '        Dim NRow As Integer = grdcaptura.RowCount

        '        For i As Integer = 1 To columnasAExportar.Length - 1
        '            ' exSheet.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
        '            exSheet.Cells.Item(1, i + 1) = grdcaptura.Columns(columnasAExportar(i)).HeaderText.ToString()
        '        Next

        '        For Fila = 0 To NRow - 1
        '            For Col = 0 To columnasAExportar.Length - 1
        '                'exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString
        '                exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(columnasAExportar(Col)).Value.ToString()
        '            Next
        '        Next

        '        exSheet.Rows.Item(1).Font.Bold = True
        '        exSheet.Rows.Item(1).HorizontalAlignment = 3
        '        exSheet.Columns.AutoFit()

        '        exApp.Application.Visible = True
        '        exSheet = Nothing
        '        exBook = Nothing
        '        exApp = Nothing

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString)
        '    End Try
        '    barCarga.Value = 0
        '    barCarga.Visible = False

        '    MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        'End If
    End Sub

    Public Sub ExportarDataGridViewAExcel(dgv As DataGridView)
        If grdcaptura.Rows.Count = 0 Then MsgBox("Genera el reporte para poder exportar los datos a Excel.", vbInformation + vbOKOnly, titulocentral) : Exit Sub
        If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            btnExpExis.Enabled = False
            Dim voy As Integer = 0
            ' Crea un nuevo libro de trabajo de Excel
            Using workbook As New XLWorkbook()

                ' Añade una nueva hoja de trabajo
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Datos")

                ' Escribe los encabezados de columna
                Dim columnasExportar As Integer() = {0, 1, 2, 4} ' Columnas a exportar
                For i As Integer = 0 To columnasExportar.Length - 1
                    Dim colIndex As Integer = columnasExportar(i)
                    Dim headerCell As IXLCell = worksheet.Cell(1, i + 1)
                    headerCell.Value = dgv.Columns(colIndex).HeaderText
                    headerCell.Style.Font.Bold = True ' Aplica negrita a los encabezados
                Next

                ' Agregar encabezados personalizados para "Lote" y "Caducidad"
                Dim loteHeader As IXLCell = worksheet.Cell(1, columnasExportar.Length + 1) ' La siguiente columna
                loteHeader.Value = "Lote"
                loteHeader.Style.Font.Bold = True

                Dim caducidadHeader As IXLCell = worksheet.Cell(1, columnasExportar.Length + 2) ' La siguiente columna
                caducidadHeader.Value = "Caducidad"
                caducidadHeader.Style.Font.Bold = True

                ' Escribe los datos de las columnas que quieres exportar
                For rowIndex As Integer = 0 To dgv.Rows.Count - 1
                    For i As Integer = 0 To columnasExportar.Length - 1
                        Dim colIndex As Integer = columnasExportar(i)
                        Dim cellValue As Object = dgv.Rows(rowIndex).Cells(colIndex).Value
                        Dim cellValueString As String = If(cellValue Is Nothing, String.Empty, cellValue.ToString())
                        Dim cell As IXLCell = worksheet.Cell(rowIndex + 2, i + 1)
                        cell.Value = cellValueString
                        cell.Style.NumberFormat.Format = "@" ' Formato de texto
                    Next
                    voy = voy + 1
                    txtregistros.Text = voy
                    My.Application.DoEvents()
                Next

                worksheet.Columns().AdjustToContents()
                ' Usa MemoryStream para guardar el archivo en memoria y abrirlo
                Using memoryStream As New System.IO.MemoryStream()
                    ' Guarda el libro de trabajo en el MemoryStream
                    workbook.SaveAs(memoryStream)

                    ' Guarda el MemoryStream en un archivo temporal para abrirlo
                    Dim tempFilePath As String = IO.Path.GetTempPath() & Guid.NewGuid().ToString() & ".xlsx"
                    System.IO.File.WriteAllBytes(tempFilePath, memoryStream.ToArray())

                    ' Abre el archivo temporal en Excel
                    Process.Start(tempFilePath)
                End Using

                'workbook.SaveAs(filePath)
            End Using
            MessageBox.Show("Datos exportados exitosamente")
            btnExpExis.Enabled = True
            txtregistros.Text = ""
            barCarga.Value = 0
            barCarga.Visible = False
        End If
    End Sub

    Private Sub btnImpExis_Click(sender As Object, e As EventArgs) Handles btnImpExis.Click
        CargarDatosDesdeExcel()
    End Sub
    Private Sub CargarDatosDesdeExcel()
        btnImpExis.Enabled = False
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de Excel|*.xlsx"
        openFileDialog.Title = "Seleccionar archivo Excel"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Dim dt As New DataTable()
            Using workbook As New XLWorkbook(filePath)
                Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                Dim firstRow As IXLRow = worksheet.Row(1)
                For Each cell As IXLCell In firstRow.CellsUsed()
                    dt.Columns.Add(cell.Value.ToString())
                Next

                For rowIndex As Integer = 2 To worksheet.RowsUsed().Count()
                    Dim row As DataRow = dt.NewRow()
                    Dim currentRow As IXLRow = worksheet.Row(rowIndex)
                    For colIndex As Integer = 1 To dt.Columns.Count
                        row(colIndex - 1) = currentRow.Cell(colIndex).GetValue(Of String)()
                    Next
                    dt.Rows.Add(row)
                Next
            End Using

            DataGridView1.DataSource = dt

            Try
                Dim NOMBRE, CODIGO, BARRAS As String
                Dim EXISTENCIA, existenciacardex, existencia_final, diferencia, mcd, MyPreci As Double
                Dim conteo As Integer = 0
                Dim LOTE As String = ""
                Dim CADUCA As Date = Date.Now

                cnn1.Close() : cnn1.Open()
                Dim contadorconexion As Integer = 0
                'For z As Integer = 0 To DataGridView1.Rows.Count - 1
                '    CODIGO = DataGridView1.Rows.Item(z).Cells(0).Value
                '    cnn3.Close()
                '    cnn3.Open()
                '    cmd3 = cnn3.CreateCommand
                '    cmd3.CommandText = "Update Productos set Existencia=0 where Codigo='" & CODIGO & "'"
                '    cmd3.ExecuteNonQuery()
                '    cnn3.Close()
                'Next

                For X As Integer = 0 To DataGridView1.Rows.Count - 1

                    contadorconexion += 1

                    CODIGO = DataGridView1.Rows.Item(X).Cells(0).Value
                    If CODIGO = "" Then
                        GoTo kaka
                    End If
                    BARRAS = DataGridView1.Rows.Item(X).Cells(1).Value
                    NOMBRE = DataGridView1.Rows.Item(X).Cells(2).Value
                    EXISTENCIA = DataGridView1.Rows.Item(X).Cells(3).Value
                    LOTE = DataGridView1.Rows.Item(X).Cells(4).Value
                    If LOTE <> "" Then
                        CADUCA = DataGridView1.Rows.Item(X).Cells(5).Value
                    End If

                    If contadorconexion > 499 Then
                        cnn1.Close() : cnn1.Open()
                        contadorconexion = 1
                    End If

                    If (Comprueba(CODIGO)) Then
                        If cnn1.State = ConnectionState.Closed Then cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Existencia,Multiplo,PrecioVentaIVA FROM productos WHERE Codigo='" & CODIGO & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then

                                existenciacardex = If(IsDBNull(rd1("Existencia")), 0, CDbl(rd1("Existencia")))
                                mcd = If(IsDBNull(rd1("Multiplo")), 1, CDbl(rd1("Multiplo")))
                                MyPreci = If(IsDBNull(rd1("PrecioVentaIVA")), 0, CDbl(rd1("PrecioVentaIVA")))

                                diferencia = existenciacardex - EXISTENCIA
                                existencia_final = EXISTENCIA * mcd
                                existencia_final = existencia_final

                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "INSERT INTO cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario) VALUES('" & CODIGO & "','" & NOMBRE & "','Ajuste de inventario Excel'," & existenciacardex & "," & diferencia & ", " & EXISTENCIA & "," & MyPreci & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','')"
                                cmd2.ExecuteNonQuery()

                                If EXISTENCIA = 0 Then
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "delete from lotecaducidad where  codigo='" & Strings.Left(CODIGO, 6) & "'"
                                    cmd2.ExecuteNonQuery()

                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "UPDATE productos SET Cargado='0',CargadoInv='0',Existencia=0 WHERE codigo='" & Strings.Left(CODIGO, 6) & "' and CodBarra='" & BARRAS & "'"
                                    cmd2.ExecuteNonQuery()

                                    cnn2.Close()
                                Else
                                    Dim caducaxd As String = ""
                                    caducaxd = Format(CADUCA, "yyyy-MM")
                                    Dim cantlote As Double = 0
                                    Dim diferencialote As Double = 0
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "Select Cantidad from LoteCaducidad where Codigo='" & CODIGO & "' and Lote='" & LOTE & "' and Caducidad='" & caducaxd & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.Read Then
                                        cantlote = rd2(0).ToString
                                    End If
                                    rd2.Close()
                                    diferencia = EXISTENCIA - cantlote

                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "UPDATE productos SET Cargado='0',CargadoInv='0',Existencia=Existencia+" & diferencia & " WHERE codigo='" & Strings.Left(CODIGO, 6) & "' and CodBarra='" & BARRAS & "'"
                                    cmd2.ExecuteNonQuery()
                                    cnn2.Close()

                                    If LOTE <> "" Then
                                        Dim sumaxd As Double = 0
                                        Lote_Caducidad(CODIGO, EXISTENCIA, CADUCA, LOTE)
                                    End If
                                End If
                            End If
                        End If
                        rd1.Close()


                    Else
                        conteo += 1
                        txtregistros.Text = conteo
                        My.Application.DoEvents()
                        Continue For
                    End If
                    conteo += 1
                    txtregistros.Text = conteo
                    My.Application.DoEvents()
                Next
kaka:
                cnn1.Close()
                MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnImpExis.Enabled = True
                txtregistros.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

    End Sub


    Private Function Comprueba(ByVal codigo As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Codigo FROM productos WHERE Codigo='" & codigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                End If
            Else
                MsgBox("El código corto no existe " & codigo & ".", vbInformation + vbOKOnly, titulocentral)
                valida = False
            End If
            rd2.Close()
            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
        Return Nothing
    End Function

    Private Function NulVa(ByVal cifra As Double) As Double
        If IsDBNull(cifra) Then
            NulVa = 0
        Else
            NulVa = cifra
        End If
    End Function

    Private Sub rbAjuste_CheckedChanged(sender As Object, e As EventArgs) Handles rbAjuste.CheckedChanged
        Try
            If (rbAjuste.Checked) Then
                grdcaptura.Rows.Clear()
                grdcaptura.ColumnCount = 0
                grdcaptura.ColumnCount = 5

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
                With grdcaptura.Columns(3)
                    .Name = "Inventario Fisico"
                    .Width = 210
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With grdcaptura.Columns(4)
                    .Name = "Diferencias"
                    .Width = 210
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,Nombre,Existencia FROM productos"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdcaptura.Rows.Add(rd1(0).ToString, rd1(1).ToString, rd1(2).ToString, 0, rd1(2).ToString)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        If e.ColumnIndex > 0 Then
            Dim nuevoValor As String = ""
            Dim INDEX As Double = grdcaptura.CurrentRow.Index
            Dim valorActual As String = grdcaptura.Rows(INDEX).Cells(3).Value.ToString

            Dim existencia As String = grdcaptura.Rows(INDEX).Cells(2).Value.ToString
            Dim diferencia As Double = 0
            nuevoValor = InputBox("Ingresa la nueva existencia", "Editar Existencia", valorActual.ToString())
            If nuevoValor <> "" Then
                ' grdcaptura.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = nuevoValor
                grdcaptura.Rows(INDEX).Cells(3).Value = nuevoValor

                diferencia = CDbl(existencia) - CDbl(nuevoValor)
                grdcaptura.Rows(INDEX).Cells(4).Value = diferencia
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmMinMax.Show()
        frmMinMax.BringToFront()
    End Sub

    Private Sub optperdidas_Click(sender As Object, e As EventArgs) Handles optperdidas.Click
        If (optperdidas.Checked) Then

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
                grdcaptura.ColumnCount = 8
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 70
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(1)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    End With
                    With .Columns(2)
                        .HeaderText = "Cantidad"
                        .Width = 60
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Unidad"
                        .Width = 60
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "Fecha"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Departamento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "grupo"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Usuario"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With

                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Codigo,Nombre,Cantidad,Unidad,Fecha,Depto,Grupo,Usuario FROM merma ORDER BY nombre"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            Dim fecha As Date = Nothing
                            Dim f As String = ""
                            fecha = Format(rd1("Fecha").ToString)
                            f = Format(fecha, "yyyy-MM-dd HH:mm:ss")

                            grdcaptura.Rows.Add(rd1("Codigo").ToString,
                                                rd1("Nombre").ToString,
                                                rd1("Cantidad").ToString,
                                                rd1("Unidad").ToString,
                                                f,
                                                rd1("Depto").ToString,
                                                rd1("Grupo").ToString,
                                                rd1("Usuario").ToString
)
                        End If
                    Loop
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

            End If
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnCaracteristicas_Click(sender As Object, e As EventArgs) Handles btnCaracteristicas.Click

        CargarDatosDesdeExcelCa()
    End Sub

    Private Sub CargarDatosDesdeExcelCa()
        btnImpExis.Enabled = False
        ' Crear el OpenFileDialog para seleccionar el archivo Excel
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de Excel|*.xlsx"
        openFileDialog.Title = "Seleccionar archivo Excel"

        ' Si el usuario selecciona un archivo
        If openFileDialog.ShowDialog() = DialogResult.OK Then

            ' Ruta del archivo Excel seleccionado
            Dim filePath As String = openFileDialog.FileName

            ' Crear un DataTable para almacenar los datos
            Dim dt As New DataTable()

            ' Abrir el archivo de Excel usando ClosedXML
            Using workbook As New XLWorkbook(filePath)
                ' Asumimos que los datos están en la primera hoja
                Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                ' Obtener la primera fila como encabezados y añadir columnas al DataTable
                Dim firstRow As IXLRow = worksheet.Row(1)
                For Each cell As IXLCell In firstRow.CellsUsed()
                    dt.Columns.Add(cell.Value.ToString())
                Next

                ' Recorrer las filas restantes y añadirlas al DataTable
                For rowIndex As Integer = 2 To worksheet.RowsUsed().Count()
                    Dim row As DataRow = dt.NewRow()
                    Dim currentRow As IXLRow = worksheet.Row(rowIndex)

                    For colIndex As Integer = 1 To dt.Columns.Count
                        row(colIndex - 1) = currentRow.Cell(colIndex).GetValue(Of String)()
                    Next

                    dt.Rows.Add(row)
                Next
            End Using

            ' Asignar el DataTable al DataGridView para mostrar los datos
            DataGridView1.DataSource = dt

            Try
                Dim NOMBRE, CODIGO, BARRAS As String
                Dim Anti, Controla, Caducac As Integer
                Dim conteo = 0


                cnn1.Close() : cnn1.Open()
                Dim contadorconexion As Integer = 0

                For X As Integer = 0 To DataGridView1.Rows.Count - 1
                    '     For Each row As DataGridViewRow In DataGridView1.Rows
                    'If row.IsNewRow Then Continue For ' Ignorar la última fila nueva

                    contadorconexion += 1

                    CODIGO = DataGridView1.Rows.Item(X).Cells(0).Value
                    If CODIGO = "" Then
                        GoTo kaka
                    End If
                    BARRAS = DataGridView1.Rows.Item(X).Cells(1).Value
                    NOMBRE = DataGridView1.Rows.Item(X).Cells(2).Value
                    Anti = DataGridView1.Rows.Item(X).Cells(3).Value
                    Controla = DataGridView1.Rows.Item(X).Cells(4).Value
                    Caducac = DataGridView1.Rows.Item(X).Cells(5).Value





                    If contadorconexion > 499 Then
                        cnn1.Close() : cnn1.Open()
                        contadorconexion = 1
                    End If

                    If (Comprueba(CODIGO)) Then
                        If cnn1.State = ConnectionState.Closed Then cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Anti,Controlado,Caduca FROM productos WHERE Codigo='" & CODIGO & "'"
                        cmd1.Parameters.AddWithValue("@Codigo", CODIGO)
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then


                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "UPDATE productos SET Anti=" & Anti & ",Controlado=" & Controla & ",Caduca=" & Caducac & " WHERE Codigo='" & CODIGO & "' and CodBarra='" & BARRAS & "' AND Nombre='" & NOMBRE & "'"
                                cmd2.ExecuteNonQuery()
                                cnn2.Close()

                            End If
                        End If
                        rd1.Close()
                    Else
                        conteo += 1
                        txtregistros.Text = conteo
                        My.Application.DoEvents()
                        Continue For
                    End If
                    conteo += 1
                    txtregistros.Text = conteo
                    My.Application.DoEvents()
                Next
kaka:
                cnn1.Close()
                MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnImpExis.Enabled = True
                txtregistros.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try


        End If

    End Sub

    Private Sub rbLotes_Click(sender As Object, e As EventArgs) Handles rbLotes.Click
        If (rbLotes.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = False
            boxcaduca.Enabled = False
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
                    .HeaderText = "Cod. Barras"
                    .Width = 180
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(3)
                    .HeaderText = "Existencia Total"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Existencia Lotes"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Faltante en Lotes"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With
        End If
        My.Application.DoEvents()
        Try
            Dim cod As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim existencia As Double = 0
            Dim existencialote As Double = 0
            Dim diferencia As Double = 0

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo,CodBarra,Nombre,Existencia from Productos where Caduca=1 order by Codigo"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Do While rd1.Read
                    cod = rd1(0).ToString
                    barras = rd1(1).ToString
                    nombre = rd1(2).ToString
                    existencia = rd1(3).ToString

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select Sum(Cantidad) from lotecaducidad where Codigo='" & cod & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            existencialote = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)

                            diferencia = existencia - existencialote
                            diferencia = FormatNumber(diferencia, 2)
                            If existencia = existencialote Then
                                Continue Do
                            End If
                        End If
                    End If
                    rd2.Close()
                    grdcaptura.Rows.Add(cod, barras, nombre, existencia, existencialote, diferencia)
                    My.Application.DoEvents()
                Loop
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub rbListaLotes_Click(sender As Object, e As EventArgs) Handles rbListaLotes.Click
        If (rbListaLotes.Checked) Then
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            cbofiltro.Enabled = False
            boxcaduca.Enabled = False
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
                    .HeaderText = "Cod. Barras"
                    .Width = 180
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(3)
                    .HeaderText = "Existencia Lote"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Lote"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Caducidad"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With
        End If
        My.Application.DoEvents()
        Try
            Dim cod As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim existencialote As Double = 0
            Dim lote As String = ""
            Dim caducidad As String = ""

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo,CodBarra,Nombre,Existencia from Productos where Caduca=1"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Do While rd1.Read
                    cod = rd1(0).ToString
                    barras = rd1(1).ToString
                    nombre = rd1(2).ToString

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select Lote,Caducidad,Cantidad from lotecaducidad where Codigo='" & cod & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        Do While rd2.Read
                            lote = rd2(0).ToString
                            caducidad = rd2(1).ToString
                            existencialote = rd2(2).ToString
                            grdcaptura.Rows.Add(cod, barras, nombre, existencialote, lote, caducidad)
                        Loop
                    End If
                    rd2.Close()
                    cnn2.Close()
                    My.Application.DoEvents()
                Loop
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class