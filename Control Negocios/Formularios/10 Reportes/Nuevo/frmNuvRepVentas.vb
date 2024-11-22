Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports ClosedXML.Excel
Public Class frmNuvRepVentas
    Dim idabono As Integer = 0
    Dim Partes As Boolean = False
    Private Sub frmNuvRepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdCaptura.EditMode = DataGridViewEditMode.EditOnEnter
        mcDesde.SetDate(Now)
        mcHasta.SetDate(Now)
        grdCaptura.Rows.Clear()
        rbVentasTotales.PerformClick()

        dtpinicio.Text = "00:00:00"
        dtpFin.Text = "23:59:59"

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

            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText =
            '    "select NumPart from Formatos where Facturas='Farmacia'"
            'rd1 = cmd1.ExecuteReader
            'If rd1.HasRows Then
            '    If rd1.Read Then
            '        If rd1(0).ToString() = 1 Then
            '            btnAntibiotico.Visible = True
            '            btnControlado.Visible = True
            '        Else
            '            btnAntibiotico.Visible = False
            '            btnControlado.Visible = False
            '        End If
            '    End If
            'End If
            'rd1.Close()

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub rbVentasTotales_Click(sender As Object, e As EventArgs) Handles rbVentasTotales.Click

        If (rbVentasTotales.Checked) Then

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            grdCaptura.ColumnCount = 15

            rbComandasCance.Checked = False
            rbCortesias.Checked = False
            txtPropina.Visible = True
            lblPropina.Visible = True
            btnImprimir.Visible = False
            With grdCaptura
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(10)
                    .HeaderText = "IEEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(11)
                    .HeaderText = "Forma Pago"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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

            btnExcel.Enabled = False
        End If

    End Sub

    Private Sub rbVentasDetalle_Click(sender As Object, e As EventArgs) Handles rbVentasDetalle.Click
        If (rbVentasDetalle.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"
            lblPropina.Visible = False
            txtPropina.Visible = False

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            If (Partes) Then
                grdCaptura.ColumnCount = 17
                With grdCaptura
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
                grdCaptura.ColumnCount = 16
                With grdCaptura
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
            btnExcel.Enabled = False
        End If

    End Sub

    Private Sub rbVentasClientes_Click(sender As Object, e As EventArgs) Handles rbVentasClientes.Click
        If (rbVentasClientes.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"
            txtPropina.Visible = False
            lblPropina.Visible = False

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 10
            With grdCaptura
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "IEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "IVA"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Estado"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(9)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnExcel.Enabled = False
        End If
    End Sub

    Private Sub rbVentasCliDetalle_Click(sender As Object, e As EventArgs) Handles rbVentasCliDetalle.Click
        If (rbVentasCliDetalle.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"
            txtPropina.Visible = False
            lblPropina.Visible = False

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            If (Partes) Then
                grdCaptura.ColumnCount = 14
                With grdCaptura
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

                End With
            Else
                grdCaptura.ColumnCount = 13
                With grdCaptura
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
                End With
            End If

            btnExcel.Enabled = False

        End If
    End Sub

    Private Sub rbVentasDepa_Click(sender As Object, e As EventArgs) Handles rbVentasDepa.Click
        If (rbVentasDepa.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"
            txtPropina.Visible = False
            lblPropina.Visible = False

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 14
            With grdCaptura
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

            btnExcel.Enabled = False

        End If
    End Sub

    Private Sub rbVentasGrupo_Click(sender As Object, e As EventArgs) Handles rbVentasGrupo.Click
        If (rbVentasGrupo.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False
            txtPropina.Visible = False
            lblPropina.Visible = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 14
            With grdCaptura
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

            btnExcel.Enabled = False

        End If
    End Sub

    Private Sub rbVentasPago_Click(sender As Object, e As EventArgs) Handles rbVentasPago.Click
        If (rbVentasPago.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            If (Partes) Then
                grdCaptura.ColumnCount = 18
                With grdCaptura
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
                grdCaptura.ColumnCount = 17
                With grdCaptura
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

            btnExcel.Enabled = False

        End If
    End Sub

    Private Sub rbVentasProducto_Click(sender As Object, e As EventArgs) Handles rbVentasProducto.Click
        If (rbVentasProducto.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 13
            With grdCaptura
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
            btnExcel.Enabled = False
        End If
    End Sub

    Private Sub rbVentasVendedor_Click(sender As Object, e As EventArgs) Handles rbVentasVendedor.Click
        If (rbVentasVendedor.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False
            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 8
            With grdCaptura
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

            btnExcel.Enabled = False

        End If

    End Sub

    Private Sub rbDevoluciones_Click(sender As Object, e As EventArgs) Handles rbDevoluciones.Click
        If (rbDevoluciones.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 6
            With grdCaptura
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

            btnExcel.Enabled = False
        End If
    End Sub

    Private Sub rbProductoVendido_Click(sender As Object, e As EventArgs) Handles rbProductoVendido.Click
        If (rbProductoVendido.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = True
            grdCaptura.ColumnCount = 4
            With grdCaptura
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

            btnExcel.Enabled = False
        End If
    End Sub

    Private Sub rbVendidoProveedor_Click(sender As Object, e As EventArgs) Handles rbVendidoProveedor.Click
        If (rbVendidoProveedor.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True
            cboDatos.Focus().Equals(True)

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 4
            With grdCaptura
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

            btnExcel.Enabled = False
        End If
    End Sub

    Private Sub rbVentasFormato_Click(sender As Object, e As EventArgs) Handles rbVentasFormato.Click
        If (rbVentasFormato.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True
            cboDatos.Focus().Equals(True)

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False
            grdCaptura.ColumnCount = 11
            With grdCaptura
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

            btnExcel.Enabled = False
        End If
    End Sub

    Private Sub rbVentasPorcentaje_Click(sender As Object, e As EventArgs) Handles rbVentasPorcentaje.Click
        If (rbVentasPorcentaje.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Items.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            If (Partes) Then
                grdCaptura.ColumnCount = 17
                With grdCaptura
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
                grdCaptura.ColumnCount = 16
                With grdCaptura
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

            btnExcel.Enabled = False
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim m1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString

        Dim cuantos As Double = 0

        Dim T_Propina As Double = 0
        Dim T_Suma As Double = 0
        Dim T_Costo As Double = 0
        Dim T_Subtotal As Double = 0
        Dim T_Descuento As Double = 0
        Dim T_IEPS As Double = 0
        Dim T_IVA As Double = 0
        Dim T_Total As Double = 0
        Dim T_ACuenta As Double = 0
        Dim T_Resta As Double = 0

        Dim folio As String = ""
        Dim cliente As String = ""
        Dim subtotal As Double = 0
        Dim Iva As Double = 0
        Dim total As Double = 0
        Dim propina As Double = 0
        Dim descuento As Double = 0
        Dim descu As Double = 0
        Dim devolucion As Double = 0
        Dim acuenta As Double = 0
        Dim resta As Double = 0
        Dim ieps As Double = 0
        Dim formapago As String = ""
        Dim status As String = ""
        Dim fecha As Date = Nothing
        Dim fechanueva As String = ""
        Dim facturado As Integer = 0

        Dim codigo As String = ""
        Dim barras As String = ""
        Dim parte As String = ""
        Dim descripcion As String = ""
        Dim uventa As String = ""
        Dim cantidad As Double = 0
        Dim costo As Double = 0
        Dim sumacosto As Double = 0
        Dim precio As Double = 0
        Dim utilidad As Double = 0
        Dim existencia As Double = 0
        Dim porcentaje As Double = 0

        Dim nuevototal As Double = 0
        Dim nuevosubtotal As Double = 0

        Dim mesa As String = ""
        Dim usua As String = ""
        Dim hr As String = ""

        txtPropina.Text = "0.00"
        txtSuma.Text = "0.00"
        txtCosto.Text = "0.00"
        txtCostoUtilidad.Text = "0.00"
        txtSubtotal.Text = "0.00"
        txtDescuento.Text = "0.00"
        txtIeps.Text = "0.00"
        txtIVA.Text = "0.00"
        txtTotal.Text = "0.00"
        txtAcuenta.Text = "0.00"
        txtResta.Text = "0.00"

        grdCaptura.Rows.Clear()
        btnExcel.Enabled = True

        If (rbTraspasos.Checked) Then
            Try
                If cboDatos.Text = "" Then
                    MsgBox("Selecciona una opción para continuar", vbExclamation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "SALIDA" Then
                    cmd1.CommandText = "Select Folio,FVenta from Traslados where Concepto='SALIDA' and FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                Else
                    cmd1.CommandText = "Select Folio,FVenta from Traslados where Concepto='ENTRADA' and FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Dim idtraspaso As Integer = rd1("Folio").ToString
                    Dim fechatraspaso As Date = rd1("FVenta").ToString

                    fechanueva = Format(fechatraspaso, "dd-MM-yyyy")

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select Codigo,Nombre,Cantidad,Unidad,Precio,Total from TrasladosDet where Folio=" & idtraspaso & " and Concepto='" & cboDatos.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        codigo = rd2("Codigo").ToString
                        descripcion = rd2("Nombre").ToString
                        cantidad = rd2("Cantidad").ToString
                        uventa = rd2("Unidad").ToString
                        precio = rd2("Precio").ToString
                        total = rd2("Total").ToString

                        grdCaptura.Rows.Add(codigo, descripcion, cantidad & " " & uventa, precio, total, fechanueva)
                        subtotal = subtotal + total
                    Loop
                    rd2.Close()
                    cnn2.Close()
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()
                txtTotal.Text = FormatNumber(subtotal, 2)
                txtSubtotal.Text = FormatNumber(subtotal, 2)
            Catch ex As Exception
                cnn1.Close()
                MessageBox.Show(ex.ToString)
            End Try
        End If

        If (rbFiscal.Checked) Then
            folio = ""
            cliente = ""
            subtotal = 0
            Iva = 0
            total = 0
            descuento = 0
            devolucion = 0
            acuenta = 0
            resta = 0
            ieps = 0
            formapago = ""
            status = ""
            fecha = Nothing
            fechanueva = ""
            facturado = 0
            Dim fechaabono As Date=Date.now
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT COUNT(Folio) FROM Ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                Else
                    cmd1.CommandText = "SELECT COUNT(Folio) FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status='" & cboDatos.Text & "'"
                End If

                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT Folio,Cliente,Subtotal,IVA,totales,Propina,Descuento,Devolucion,ACuenta,Resta,Status,Fecha,Facturado FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                Else
                    cmd1.CommandText = "SELECT Folio,Cliente,Subtotal,IVA,totales,Propina,Descuento,Devolucion,ACuenta,Resta,Status,Fecha,Facturado FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status='" & cboDatos.Text & "' ORDER BY Folio"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString
                        subtotal = IIf(rd1("Subtotal").ToString = "", 0, rd1("Subtotal").ToString)
                        Iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                        total = IIf(rd1("totales").ToString = "", 0, rd1("totales").ToString)
                        propina = IIf(rd1("Propina").ToString = "", 0, rd1("Propina").ToString)
                        descuento = IIf(rd1("Descuento").ToString = "", 0, rd1("Descuento").ToString)
                        devolucion = IIf(rd1("Devolucion").ToString = "", 0, rd1("Devolucion").ToString)
                        acuenta = IIf(rd1("ACuenta").ToString = "", 0, rd1("ACuenta").ToString)
                        resta = IIf(rd1("Resta").ToString = "", 0, rd1("Resta").ToString)
                        status = IIf(rd1("Status").ToString = "", "", rd1("Status").ToString)
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd HH:mm:ss")
                        facturado = IIf(rd1("Facturado").ToString = "", 0, rd1("Facturado").ToString)

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                        "select sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                ieps = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                            End If
                        End If
                        rd2.Close()
                        grdCaptura.Rows.Add(folio, cliente, total, fechanueva, facturado)
                        formapago = ""
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT FormaPago,Concepto,Monto,Banco,Referencia,Fecha,CuentaC,Id,Parcialidad FROM abonoi WHERE NumFolio='" & folio & "' AND Concepto='ABONO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            Do While rd2.Read
                                formapago = rd2(0).ToString()
                                fechaabono = rd2(5).ToString()
                                fechanueva = Format(fechaabono, "yyyy-MM-dd")
                                grdCaptura.Rows.Add("", rd2(1).ToString, rd2(2).ToString, "", rd2(8).ToString, formapago, rd2(3).ToString, rd2(4).ToString, rd2(6).ToString, fechanueva, rd2(7).ToString)
                            Loop
                        End If
                        rd2.Close()



                        T_Subtotal = T_Subtotal + subtotal
                        T_IVA = T_IVA + Iva
                        T_Total = T_Total + total
                        T_Propina = T_Propina + propina
                        T_Descuento = T_Descuento + descuento
                        T_ACuenta = T_ACuenta + acuenta
                        T_Resta = T_Resta + resta
                        T_IEPS = T_IEPS + ieps

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtPropina.Text = FormatNumber(T_Propina, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)

                barcarga.Visible = False
                barcarga.Value = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try
        End If

        If (rbVentasTotales.Checked) Then

            folio = ""
            cliente = ""
            subtotal = 0
            Iva = 0
            total = 0
            descuento = 0
            devolucion = 0
            acuenta = 0
            resta = 0
            ieps = 0
            formapago = ""
            status = ""
            fecha = Nothing
            fechanueva = ""
            facturado = 0

            T_Subtotal = 0
            T_IVA = 0
            T_Total = 0
            T_Propina = 0
            T_Descuento = 0
            T_ACuenta = 0
            T_Resta = 0
            T_IEPS = 0

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT COUNT(Folio) FROM Ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA'"
                Else
                    cmd1.CommandText = "SELECT COUNT(Folio) FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status='" & cboDatos.Text & "'"
                End If

                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT Folio,Cliente,Subtotal,IVA,totales,Propina,Descuento,Devolucion,ACuenta,Resta,Status,Fecha,Facturado FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                Else
                    cmd1.CommandText = "SELECT Folio,Cliente,Subtotal,IVA,totales,Propina,Descuento,Devolucion,ACuenta,Resta,Status,Fecha,Facturado FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status='" & cboDatos.Text & "' ORDER BY Folio"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString
                        subtotal = IIf(rd1("Subtotal").ToString = "", 0, rd1("Subtotal").ToString)
                        Iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                        total = IIf(rd1("totales").ToString = "", 0, rd1("totales").ToString)
                        propina = IIf(rd1("Propina").ToString = "", 0, rd1("Propina").ToString)
                        descuento = IIf(rd1("Descuento").ToString = "", 0, rd1("Descuento").ToString)
                        devolucion = IIf(rd1("Devolucion").ToString = "", 0, rd1("Devolucion").ToString)
                        acuenta = IIf(rd1("ACuenta").ToString = "", 0, rd1("ACuenta").ToString)
                        resta = IIf(rd1("Resta").ToString = "", 0, rd1("Resta").ToString)
                        status = IIf(rd1("Status").ToString = "", "", rd1("Status").ToString)
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd HH:mm:ss")
                        facturado = IIf(rd1("Facturado").ToString = "", 0, rd1("Facturado").ToString)

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                        "select sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                ieps = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT FormaPago FROM abonoi WHERE NumFolio='" & folio & "' AND Concepto='ABONO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                formapago = rd2(0).ToString
                            End If
                        End If
                        rd2.Close()

                        grdCaptura.Rows.Add(folio, cliente, subtotal, Iva, total, propina, descuento, devolucion, acuenta, resta, ieps, formapago, status, fechanueva, facturado)

                        T_Subtotal = T_Subtotal + subtotal
                        T_IVA = T_IVA + Iva
                        T_Total = T_Total + total
                        T_Propina = T_Propina + propina
                        T_Descuento = T_Descuento + descuento
                        T_ACuenta = T_ACuenta + acuenta
                        T_Resta = T_Resta + resta
                        T_IEPS = T_IEPS + ieps

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtPropina.Text = FormatNumber(T_Propina, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)

                barcarga.Visible = False
                barcarga.Value = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try

        End If

        If (rbVentasDetalle.Checked) Then

            folio = ""
            cliente = ""
            codigo = ""
            barras = ""
            parte = ""
            descripcion = ""
            uventa = ""
            cantidad = 0
            costo = 0
            sumacosto = 0
            precio = 0
            subtotal = 0
            Iva = 0
            total = 0
            descuento = 0
            ieps = 0
            fecha = Nothing
            fechanueva = ""
            utilidad = 0
            nuevototal = 0

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Propina,Descuento FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        propina = rd1("Propina").ToString
                        descuento = rd1("Descuento").ToString

                        T_Propina = T_Propina + CDbl(propina)
                        T_Descuento = T_Descuento + descuento
                    End If
                Loop
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Cliente FROM Ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString


                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Codigo,Nombre,Unidad,Cantidad,CostoVUE,Precio,PrecioSinIva,Total,Descto,TotalIEPS,Fecha FROM ventasdetalle WHERE Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            If rd2.HasRows Then
                                codigo = rd2("Codigo").ToString
                                barras = CB(codigo)
                                descripcion = rd2("Nombre").ToString
                                uventa = rd2("Unidad").ToString
                                cantidad = rd2("Cantidad").ToString
                                costo = rd2("CostoVUE").ToString
                                precio = IIf(rd2("Precio").ToString = "", 0, rd2("Precio").ToString)
                                subtotal = IIf(rd2("PrecioSinIva").ToString = "", 0, rd2("PrecioSinIva").ToString)
                                total = IIf(rd2("Total").ToString = "", 0, rd2("Total").ToString)
                                descuento = IIf(rd2("Descto").ToString = "", 0, rd2("Descto").ToString)
                                ieps = IIf(rd2("TotalIEPS").ToString = "", 0, rd2("TotalIEPS").ToString)
                                fecha = rd2("Fecha").ToString
                                fechanueva = Format(fecha, "yyyy-MM-dd")
                                utilidad = DameUti(folio, codigo, cantidad)
                                subtotal = subtotal * cantidad

                                T_Subtotal = T_Subtotal + subtotal
                                T_Total = T_Total + (total)
                                Iva = CDbl(total) - CDbl(subtotal)

                                parte = Saca_NumParte(codigo)

                                If (Partes) Then
                                    grdCaptura.Rows.Add(folio, cliente, codigo, IIf(barras = "", "", barras), parte, descripcion, uventa, FormatNumber(cantidad, 2), FormatNumber(costo, 2), FormatNumber(precio, 2), FormatNumber(subtotal, 2), FormatNumber(Iva, 2), FormatNumber(total, 2), FormatNumber(descuento, 2), FormatNumber(ieps, 2), fechanueva, FormatNumber(utilidad, 2))
                                Else
                                    grdCaptura.Rows.Add(folio, cliente, codigo, IIf(barras = "", "", barras), descripcion, uventa, FormatNumber(cantidad, 2), FormatNumber(costo, 2), FormatNumber(precio, 2), FormatNumber(subtotal, 2), FormatNumber(Iva, 2), FormatNumber(total, 2), FormatNumber(descuento, 2), FormatNumber(ieps, 2), fechanueva, FormatNumber(utilidad, 2))
                                End If

                                T_Costo = T_Costo + sumacosto
                                T_IVA = T_IVA + Iva
                                T_IEPS = T_IEPS + ieps

                                If codigo <> "xc3" Then
                                    T_Suma = T_Suma + cantidad
                                End If


                                nuevototal = T_Total
                                '  nuevosubtotal = T_Subtotal - CDbl(T_Descuento) + CDbl(T_Propina)
                                nuevosubtotal = T_Subtotal + CDbl(T_Propina)
                                T_Costo = T_Costo + costo
                            End If
                        Loop
                        rd2.Close()
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIeps.Text = FormatNumber(T_IEPS, 2)
                txtPropina.Text = FormatNumber(T_Propina, 2)
                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtSubtotal.Text = FormatNumber(nuevosubtotal, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(nuevototal, 2)
                txtCostoUtilidad.Text = CDbl(txtTotal.Text - txtCosto.Text)
                txtSuma.Text = FormatNumber(T_Suma, 2)

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try

        End If

        If (rbVentasClientes.Checked) Then
            Try
                folio = ""
                subtotal = 0
                descuento = 0
                ieps = 0
                Iva = 0
                total = 0
                acuenta = 0
                resta = 0
                status = ""
                fecha = Nothing
                fechanueva = ""
                cuantos = 0

                If cboDatos.Text = "" Then MsgBox("Selecciona un cliente para generar el reporte.", vbInformation + vbOKOnly, titulocentral) : cboDatos.Focus().Equals(True) : Exit Sub

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Folio) FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' and Cliente='" & cboDatos.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        cuantos = rd1(0).ToString
                    End If
                Loop
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Subtotal,Descuento,IVA,Totales,ACuenta,Resta,Status,Fecha FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' AND Cliente='" & cboDatos.Text & "' ORDER BY Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        subtotal = IIf(rd1("Subtotal").ToString = "", 0, rd1("Subtotal").ToString)
                        descuento = IIf(rd1("Descuento").ToString = "", 0, rd1("Descuento").ToString)
                        Iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                        total = IIf(rd1("Totales").ToString = "", 0, rd1("Totales").ToString)
                        acuenta = IIf(rd1("ACuenta").ToString = "", 0, rd1("ACuenta").ToString)
                        resta = IIf(rd1("Resta").ToString = "", 0, rd1("Resta").ToString)
                        status = rd1("Status").ToString
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd HH:mm:ss")
                        acuenta = IIf(rd1("ACuenta").ToString = "", 0, rd1("ACuenta").ToString)
                        resta = IIf(rd1("Resta").ToString = "", 0, rd1("Resta").ToString)

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                        "select sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                ieps = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                            End If
                        End If
                        rd2.Close()

                        grdCaptura.Rows.Add(folio, subtotal, FormatNumber(descuento, 2), FormatNumber(ieps, 2), FormatNumber(Iva, 2), FormatNumber(total, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2), status, fechanueva)
                        barcarga.Value = barcarga.Value + 1

                        T_Subtotal = T_Subtotal + subtotal
                        T_Descuento = T_Descuento + descuento
                        T_IEPS = T_IEPS + ieps
                        T_IVA = T_IVA + Iva
                        T_Total = T_Total + total
                        T_ACuenta = T_ACuenta + acuenta
                        T_Resta = T_Resta + resta

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIeps.Text = FormatNumber(T_IEPS, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)

                barcarga.Visible = False
                barcarga.Value = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try
        End If

        If (rbVentasCliDetalle.Checked) Then

            cuantos = 0
            folio = 0
            codigo = ""
            barras = ""
            parte = ""
            descripcion = ""
            uventa = ""
            cantidad = 0
            precio = 0
            subtotal = 0
            descuento = 0
            ieps = 0
            Iva = 0
            total = 0
            fecha = Nothing
            fechanueva = ""
            utilidad = 0

            Try
                If cboDatos.Text = "" Then MsgBox("Selecciona un cliente para generar el reporte.", vbInformation + vbOKOnly, titulocentral) : cboDatos.Focus().Equals(True) : Exit Sub

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select count(Ventas.Folio) from Ventas INNER JOIN VentasDetalle ON Ventas.Folio=VentasDetalle.Folio where Ventas.Fecha between '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' and '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' and Ventas.Cliente='" & cboDatos.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                Dim temp As Integer = 0

                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Descuento,Propina,ACuenta,Resta FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH.mm:ss") & "' AND Cliente='" & cboDatos.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        descuento = rd1("Descuento").ToString
                        propina = rd1("Propina").ToString

                        If temp <> folio Then
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Folio FROM Ventas WHERE Folio=" & folio
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    temp = folio
                                    T_ACuenta = T_ACuenta + CDbl(rd1("ACuenta").ToString)
                                    T_Resta = T_Resta + CDbl(rd1("Resta").ToString)
                                End If
                            End If
                            rd2.Close()
                        End If

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Codigo,Nombre,Unidad,Cantidad,Precio,TotalSinIVA,TotalIEPS,Total,Fecha,CostoVUE FROM ventasdetalle WHERE Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            If rd2.HasRows Then
                                codigo = rd2("Codigo").ToString
                                barras = CB(codigo)
                                parte = Saca_NumParte(codigo)
                                descripcion = rd2("Nombre").ToString
                                uventa = rd2("Unidad").ToString
                                cantidad = IIf(rd2("Cantidad").ToString = "", 0, rd2("Cantidad").ToString)
                                precio = IIf(rd2("Precio").ToString = "", 0, rd2("Precio").ToString)
                                subtotal = IIf(rd2("TotalSinIVA").ToString = "", 0, rd2("TotalSinIVA").ToString)
                                ieps = IIf(rd2("TotalIEPS").ToString() = "", 0, rd2("TotalIEPS").ToString)
                                total = IIf(rd2("Total").ToString = "", 0, rd2("Total").ToString)
                                fecha = rd2("Fecha").ToString
                                fechanueva = Format(fecha, "yyyy-MM-dd")
                                costo = IIf(rd2("CostoVUE").ToString = "", 0, rd2("CostoVUE").ToString)

                                T_Subtotal = T_Subtotal + subtotal
                                T_Total = T_Total + total

                                Iva = CDbl(total) - CDbl(subtotal)

                                If (Partes) Then
                                Else
                                    grdCaptura.Rows.Add(folio, codigo, IIf(barras = "", "", barras), descripcion, uventa, cantidad, precio, FormatNumber(subtotal, 2), "0.00", FormatNumber(ieps, 2), FormatNumber(Iva, 2), FormatNumber(total, 2), fechanueva)
                                End If

                                If codigo <> "xc3" Then
                                    T_Suma = T_Suma + cantidad
                                End If

                                T_Propina = T_Propina + propina
                                T_Descuento = T_Descuento + descuento
                                T_IEPS = T_IEPS + ieps
                                T_IVA = T_IVA + Iva
                                nuevosubtotal = T_Subtotal + propina
                                nuevototal = T_Total
                                T_Costo = T_Costo + costo
                            End If
                        Loop
                        rd2.Close()

                    End If
                    barcarga.Value = barcarga.Value + 1
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                barcarga.Visible = False
                barcarga.Value = 0

                txtPropina.Text = FormatNumber(T_Propina, 2)
                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIeps.Text = FormatNumber(T_IEPS, 2)
                txtIeps.Text = FormatNumber(T_IVA, 2)
                txtSubtotal.Text = FormatNumber(nuevosubtotal, 2)
                txtTotal.Text = FormatNumber(nuevototal, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)
                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtCostoUtilidad.Text = FormatNumber(CDbl(txtTotal.Text) - CDbl(txtCosto.Text), 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try


        End If

        If (rbVentasDepa.Checked) Then

            cuantos = 0
            folio = 0
            codigo = ""
            barras = ""
            descripcion = ""
            uventa = ""
            cantidad = 0
            precio = 0
            descuento = 0
            subtotal = 0
            ieps = 0
            Iva = 0
            total = 0
            utilidad = 0
            nuevosubtotal = 0

            If cboDatos.Text = "" Then MsgBox("Selecciona un departamento para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDatos.Focus().Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT COUNT(Id) FROM VentasDetalle WHERE Depto='" & cboDatos.Text & "' AND Fecha between '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantos = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantos

            cnn2.Close() : cnn2.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Folio,Codigo,Nombre,Unidad,Cantidad,Precio,Descto,Total,TotalIEPS,Total,Fecha,CostoVUE FROM ventasdetalle WHERE Depto='" & cboDatos.Text & "' AND Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Facturado<>'DEVOLUCION' AND Facturado<>'CANCELADO' AND Folio<>0 ORDER BY Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    folio = rd1("Folio").ToString
                    codigo = rd1("Codigo").ToString
                    barras = CB(codigo)
                    descripcion = rd1("Nombre").ToString
                    uventa = rd1("Unidad").ToString
                    cantidad = IIf(rd1("Cantidad").ToString = "", 0, rd1("Cantidad").ToString)
                    precio = IIf(rd1("Precio").ToString = "", 0, rd1("Precio").ToString)
                    descuento = IIf(rd1("Descto").ToString = "", 0, rd1("Descto").ToString)
                    subtotal = IIf(rd1("Total").ToString = "", 0, rd1("Total").ToString)
                    ieps = IIf(rd1("TotalIEPS").ToString() = "", 0, rd1("TotalIEPS").ToString)
                    total = IIf(rd1("Total").ToString = "", 0, rd1("Total").ToString)
                    fecha = rd1("Fecha").ToString
                    fechanueva = Format(fecha, "yyyy-MM-dd")
                    costo = IIf(rd1("CostoVUE").ToString = "", 0, rd1("CostoVUE").ToString)

                    T_Subtotal = T_Subtotal + subtotal
                    T_Total = T_Total + total
                    Iva = CDbl(T_Total) - CDbl(T_Subtotal)

                    grdCaptura.Rows.Add(folio, codigo, IIf(barras = "", "", barras), descripcion, uventa, cantidad, precio, descuento, subtotal, ieps, Iva, total, fechanueva, utilidad)

                    If codigo <> "xc3" Then
                        T_Suma = T_Suma + cantidad
                    End If
                    T_Costo = T_Costo + costo
                    T_Descuento = T_Descuento + descuento
                    T_IEPS = T_IEPS + ieps
                    T_IVA = T_IVA + Iva
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close()
            cnn1.Close()
            barcarga.Visible = False
            barcarga.Value = 0

            txtSuma.Text = FormatNumber(T_Suma, 2)
            txtCosto.Text = FormatNumber(T_Costo, 2)
            txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
            txtTotal.Text = FormatNumber(T_Total, 2)
            txtDescuento.Text = FormatNumber(T_Descuento, 2)
            txtIeps.Text = FormatNumber(T_IEPS, 2)
            txtIVA.Text = FormatNumber(T_IVA, 2)
            txtCostoUtilidad.Text = FormatNumber(CDbl(txtTotal.Text) - CDbl(txtCosto.Text))
        End If

        If (rbVentasGrupo.Checked) Then
            Try
                cuantos = 0
                folio = 0
                codigo = ""
                barras = ""
                descripcion = ""
                uventa = ""
                cantidad = 0
                precio = 0
                descuento = 0
                subtotal = 0
                ieps = 0
                Iva = 0
                total = 0
                fecha = Nothing
                utilidad = 0

                If cboDatos.Text = "" Then MsgBox("Selecciona un grupo para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDatos.Focus().Equals(True) : Exit Sub

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select count(Id) from VentasDetalle where Grupo='" & cboDatos.Text & "' and Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio <>0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Codigo,Nombre,Unidad,Cantidad,Precio,Descto,TotalSinIVA,TotalIEPS,Total,Fecha,CostoVUE FROM VentasDetalle where Grupo='" & cboDatos.Text & "' AND Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Facturado<>'DEVOLUCION' AND Facturado<>'CANCELADO' AND Folio <>0 order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        codigo = rd1("Codigo").ToString
                        barras = CB(codigo)
                        descripcion = rd1("Nombre").ToString
                        uventa = rd1("Unidad").ToString
                        cantidad = rd1("Cantidad").ToString
                        precio = IIf(rd1("Precio").ToString = "", 0, rd1("Precio").ToString)
                        descuento = IIf(rd1("Descto").ToString = "", 0, rd1("Descto").ToString)
                        subtotal = IIf(rd1("TotalSinIVA").ToString = "", 0, rd1("TotalSinIVA").ToString)
                        ieps = IIf(rd1("TotalIEPS").ToString = "", 0, rd1("TotalIEPS").ToString)
                        total = IIf(rd1("Total").ToString = "", 0, rd1("Total").ToString)
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd")
                        costo = IIf(rd1("CostoVUE").ToString = "", 0, rd1("CostoVUE").ToString)

                        Iva = CDbl(total) - CDbl(subtotal)

                        grdCaptura.Rows.Add(folio, codigo, IIf(barras = "", "", barras), descripcion, uventa, cantidad, precio, descuento, subtotal, ieps, Iva, total, fecha, utilidad)

                        T_Subtotal = T_Subtotal + subtotal
                        T_Total = T_Total + total
                        T_Costo = T_Costo + costo
                        T_IVA = T_IVA + Iva
                        T_Descuento = T_Descuento + descuento
                        T_IEPS = T_IEPS + ieps
                        If codigo <> "xc3" Then
                            T_Suma = T_Suma + cantidad
                        End If
                        barcarga.Value = barcarga.Value + 1
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIeps.Text = FormatNumber(T_IEPS, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtCostoUtilidad.Text = FormatNumber(CDbl(T_Total) - CDbl(T_Costo), 2)

                barcarga.Visible = False
                barcarga.Value = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

        If (rbVentasPago.Checked) Then
            Try
                cuantos = 0
                folio = 0
                cliente = ""
                codigo = ""
                barras = ""
                descripcion = ""
                uventa = ""
                cantidad = 0
                precio = 0
                subtotal = 0
                descuento = 0
                descu = 0
                ieps = 0
                Iva = 0
                total = 0
                fecha = Nothing
                utilidad = 0
                acuenta = 0
                resta = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Folio) FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Cliente,Descuento,ACuenta,Resta FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "' AND Status<>'CANCELADA' order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString
                        descuento = rd1("Descuento").ToString
                        acuenta = IIf(rd1("ACuenta").ToString = 0, 0, rd1("ACuenta").ToString)
                        resta = IIf(rd1("Resta").ToString = 0, 0, rd1("Resta").ToString)

                        T_ACuenta = T_ACuenta + acuenta
                        T_Resta = T_Resta + resta

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Codigo,Nombre,Unidad,Cantidad,Precio,Descto,TotalIEPS,Fecha,TotalSinIVA,Total,CostoVUE FROM ventasdetalle WHERE Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            If rd2.HasRows Then
                                codigo = rd2("Codigo").ToString
                                barras = CB(codigo)
                                descripcion = rd2("Nombre").ToString
                                uventa = rd2("Unidad").ToString
                                cantidad = IIf(rd2("Cantidad").ToString = "", 1, rd2("Cantidad").ToString)
                                precio = IIf(rd2("Precio").ToString = "", 0, rd2("Precio").ToString)
                                descu = IIf(rd2("Descto").ToString = "", 0, rd2("Descto").ToString)
                                ieps = IIf(rd2("TotalIEPS").ToString = 0, 0, rd2("TotalIEPS").ToString)
                                fecha = rd2("Fecha").ToString
                                fechanueva = Format(fecha, "yyyy-MM-dd")
                                utilidad = DameUti(folio, codigo, cantidad)

                                subtotal = IIf(rd2("TotalSinIVA").ToString = 0, 0, rd2("TotalSinIVA").ToString)
                                total = IIf(rd2("Total").ToString = 0, 0, rd2("Total").ToString)
                                costo = IIf(rd2("CostoVUE").ToString = 0, 0, rd2("CostoVUE").ToString)

                                T_Total = T_Total + total
                                T_Subtotal = T_Subtotal + subtotal
                                Iva = CDbl(total) - CDbl(subtotal)
                                parte = Saca_NumParte(codigo)

                                If (Partes) Then
                                    grdCaptura.Rows.Add(folio, cliente, codigo, IIf(barras = "", "", barras), parte, descripcion, uventa, FormatNumber(cantidad, 2), FormatNumber(precio, 2), FormatNumber(subtotal, 2), FormatNumber(descu, 2), FormatNumber(ieps, 2), FormatNumber(Iva, 2), FormatNumber(total, 2), fechanueva, FormatNumber(utilidad, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2))
                                Else
                                    grdCaptura.Rows.Add(folio, cliente, codigo, IIf(barras = "", "", barras), descripcion, uventa, FormatNumber(cantidad, 2), FormatNumber(precio, 2), FormatNumber(subtotal, 2), FormatNumber(descu, 2), FormatNumber(ieps, 2), FormatNumber(Iva, 2), FormatNumber(total, 2), fechanueva, FormatNumber(utilidad, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2))
                                End If


                                T_IVA = T_IVA + Iva
                                T_Descuento = T_Descuento + descuento
                                T_IEPS = T_IEPS + ieps
                                T_Costo = T_Costo + costo

                                If codigo <> "xc3" Then
                                    T_Suma = T_Suma + cantidad
                                End If

                            End If
                        Loop
                        rd2.Close()

                        barcarga.Value = barcarga.Value + 1
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtIeps.Text = FormatNumber(T_IEPS, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)
                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtCostoUtilidad.Text = FormatNumber(CDbl(txtTotal.Text) - CDbl(txtCosto.Text))
                barcarga.Visible = False
                barcarga.Value = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If (rbVentasProducto.Checked) Then
            Try
                If cboDatos.Text = "" Then MsgBox("Selecciona un proucto para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDatos.Focus().Equals(True) : Exit Sub

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT count(Id) from ventasdetalle WHERE Nombre='" & cboDatos.Text & "' AND Fecha between '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Facturado<>'DEVOLUCION' AND Facturado<>'CANCELADO' AND Folio <>0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Nombre,Unidad,Cantidad,Precio,Descto,TotalSinIVA,TotalIEPS,Total,CostoVUE,Fecha FROM VentasDetalle where Nombre='" & cboDatos.Text & "' AND Fecha between '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Facturado<>'DEVOLUCION' AND Facturado<>'CANCELADO' AND Folio <>0 order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        descripcion = rd1("Nombre").ToString
                        uventa = rd1("Unidad").ToString
                        cantidad = IIf(rd1("Cantidad").ToString = "", 1, rd1("Cantidad").ToString)
                        precio = IIf(rd1("Precio").ToString = "", 0, rd1("Precio").ToString)
                        descu = IIf(rd1("Descto").ToString = "", 0, rd1("Descto").ToString)
                        subtotal = IIf(rd1("TotalSinIVA").ToString = "", 0, rd1("TotalSinIVA").ToString)
                        ieps = IIf(rd1("TotalIEPS").ToString = "", 0, rd1("TotalIEPS").ToString)
                        total = IIf(rd1("Total").ToString = "", 0, rd1("Total").ToString)
                        Iva = CDbl(total) - CDbl(subtotal)
                        Dim opeso As Double = Peso_Prod(codigo) * cantidad
                        costo = IIf(rd1("CostoVUE").ToString = "", 0, rd1("CostoVUE").ToString)
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd")
                        utilidad = DameUti(folio, codigo, cantidad)

                        grdCaptura.Rows.Add(folio, descripcion, opeso, uventa, cantidad, precio, descu, subtotal, ieps, Iva, total, fechanueva, utilidad)

                        T_Subtotal = T_Subtotal + subtotal
                        T_Total = T_Total + total
                        T_IVA = T_IVA + Iva
                        T_Descuento = T_Descuento + descuento
                        T_IEPS = T_IEPS + ieps
                        T_Costo = T_Costo + costo
                        If codigo <> "xc3" Then
                            T_Suma = T_Suma + cantidad
                        End If

                        barcarga.Value = barcarga.Value + 1
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                barcarga.Visible = False
                barcarga.Value = 0

                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIeps.Text = FormatNumber(T_IEPS, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try

        End If

        If (rbVentasVendedor.Checked) Then
            Try
                cuantos = 0
                folio = 0
                descuento = 0
                subtotal = 0
                Iva = 0
                total = 0
                acuenta = 0
                resta = 0
                status = ""

                If cboDatos.Text = "" Then MsgBox("Selecciona un usuario para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDatos.Focus().Equals(True) : Exit Sub

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT count(Folio) FROM Ventas WHERE Usuario='" & cboDatos.Text & "' AND Fecha between '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "' AND Folio <>0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Descuento,IVA,Subtotal,Totales,ACuenta,Resta,Status,Propina FROM Ventas WHERE Usuario='" & cboDatos.Text & "' AND Fecha between '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "' AND Status<>'CANCELADA' order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        descuento = rd1("Descuento").ToString
                        Iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                        subtotal = IIf(rd1("Subtotal").ToString = "", 0, rd1("Subtotal").ToString)
                        total = IIf(rd1("Totales").ToString = "", 0, rd1("Totales").ToString)
                        acuenta = IIf(rd1("ACuenta").ToString = "", 0, rd1("ACuenta").ToString)
                        resta = IIf(rd1("Resta").ToString = "", 0, rd1("Resta").ToString)
                        status = rd1("Status").ToString
                        propina = IIf(rd1("Propina").ToString = "", 0, rd1("Propina").ToString)

                        grdCaptura.Rows.Add(folio, descuento, subtotal, Iva, total, acuenta, resta, status)

                        barcarga.Value = barcarga.Value + 1

                        T_Suma = T_Suma + cantidad
                        T_Descuento = T_Descuento + descuento
                        T_IVA = T_IVA + Iva
                        T_Subtotal = T_Subtotal + subtotal
                        T_Total = T_Total + total
                        T_ACuenta = T_ACuenta + acuenta
                        T_Resta = T_Resta + resta
                        T_Propina = T_Propina + propina

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                barcarga.Visible = False
                barcarga.Value = 0

                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)
                txtPropina.Text = FormatNumber(T_Propina, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try


        End If

        If (rbDevoluciones.Checked) Then
            Try
                cuantos = 0
                folio = 0
                descripcion = ""
                cantidad = 0
                precio = 0
                total = 0
                fecha = Nothing

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT count(Id) FROM Devoluciones WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT FOlio,Nombre,Cantidad,CostoVUE,Precio,Total,Fecha,TotalSinIVA FROM Devoluciones WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "' order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("FOlio").ToString
                        descripcion = rd1("Nombre").ToString
                        cantidad = rd1("Cantidad").ToString
                        costo = rd1("CostoVUE").ToString
                        precio = rd1("Precio").ToString
                        total = rd1("Total").ToString
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd HH:mm:ss")
                        subtotal = IIf(rd1("TotalSinIVA").ToString = "", 0, rd1("TotalSinIVA").ToString)

                        T_Subtotal = T_Subtotal + subtotal
                        T_Total = T_Total + total
                        Iva = CDbl(total) - CDbl(subtotal)

                        grdCaptura.Rows.Add(folio, descripcion, cantidad, precio, total, fechanueva)
                        barcarga.Value = barcarga.Value + 1
                        T_Suma = T_Suma + cantidad
                        T_IVA = T_IVA + Iva
                        T_Costo = T_Costo + costo
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                barcarga.Visible = False
                barcarga.Value = 0

                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtCostoUtilidad.Text = FormatNumber(txtTotal.Text - txtCosto.Text, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

        If (rbProductoVendido.Checked) Then
            Try
                cuantos = 0
                codigo = ""
                descripcion = ""
                uventa = ""
                cantidad = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Delete from ProMasVen"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(CODIGO) FROM VentasDetalle where Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and (Facturado <> 'DEVOLUCION' and Facturado <> 'CANCELADO' and Folio <> 0 ) order by Codigo"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT distinct Codigo, Nombre, Unidad FROM VentasDetalle where Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and (Facturado <> 'DEVOLUCION' and Facturado <> 'CANCELADO' and Folio <> 0 ) order by Codigo"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        codigo = rd1("Codigo").ToString
                        descripcion = rd1("Nombre").ToString
                        uventa = rd1("Unidad").ToString

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                        "select sum(Cantidad) from VentasDetalle where Codigo='" & codigo & "' and Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and (Facturado <> 'DEVOLUCION' and Facturado <> 'CANCELADO' and Folio <> 0 )"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                cantidad = rd2(0).ToString()
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO ProMasVen(Cod,Cant,Descrip,Unidad,Inicio,Final) values('" & codigo & "'," & cantidad & ",'" & descripcion & "','" & uventa & "','" & Format(m1, "yyyy-MM-dd") & "','" & Format(m2, "yyyy-MM-dd") & "')"
                        cmd2.ExecuteNonQuery()

                        T_Suma = T_Suma + cantidad
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "select Cod,Descrip,Unidad,Cant from ProMasVen order by Cant"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdCaptura.Rows.Add(rd1("Cod").ToString(), rd1("Descrip").ToString(), rd1("Unidad").ToString(), rd1("Cant").ToString())
                    End If
                Loop
                rd1.Close() : cnn1.Close()



                barcarga.Visible = False
                barcarga.Value = 0

                txtSuma.Text = FormatNumber(T_Suma, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try


        End If

        If (rbVendidoProveedor.Checked) Then
            Try
                cuantos = 0
                codigo = ""
                descripcion = ""
                uventa = ""
                cantidad = 0

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT count(Codigo) FROM ventasdetalle WHERE Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT DISTINCT VD.CODIGO,VD.NOMBRE,vD.Unidad FROM ventasdetalle VD INNER JOIN productos P ON VD.Codigo=P.Codigo WHERE VD.Fecha between '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND P.ProvPri='" & cboDatos.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        codigo = rd1("Codigo").ToString
                        descripcion = rd1("Nombre").ToString
                        uventa = rd1("Unidad").ToString

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                        "select sum(Cantidad) from VentasDetalle where Codigo='" & codigo & "' and Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and (Facturado <> 'DEVOLUCION' and Facturado <> 'CANCELADO' and Folio <> 0 )"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                cantidad = rd2(0).ToString()
                            End If
                        End If
                        rd2.Close()

                        grdCaptura.Rows.Add(codigo, descripcion, uventa, cantidad)
                        barcarga.Value = barcarga.Value + 1
                        T_Suma = T_Suma + CDbl(cantidad)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtSuma.Text = FormatNumber(T_Suma, 2)
                barcarga.Visible = False
                barcarga.Value = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try
        End If

        If (rbVentasFormato.Checked) Then
            Try
                cuantos = 0
                folio = 0
                cliente = ""
                descuento = 0
                subtotal = 0
                ieps = 0
                Iva = 0
                total = 0
                acuenta = 0
                resta = 0
                status = 0
                fecha = Nothing

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select count(Folio) from Ventas where Fecha between '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "' and Status<>'CANCELADA'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Folio,Cliente,Descuento,Subtotal,IVA,Totales,Fecha,Status,Acuenta,Propina from Ventas where Fecha between '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "' and Status<>'CANCELADA' order by Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString
                        descuento = rd1("Descuento").ToString
                        subtotal = rd1("Subtotal").ToString
                        Iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                        total = IIf(rd1("Totales").ToString = "", 0, rd1("Totales").ToString)
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd HH:mm:ss")
                        status = rd1("Status").ToString
                        acuenta = rd1("Acuenta").ToString
                        propina = rd1("Propina").ToString

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select sum(Total) as Tot, sum(TotalSinIVA) as Sub, sum(Descto) as Descu, sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                ieps = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                            End If
                        End If
                        rd2.Close()

                        grdCaptura.Rows.Add(folio, cliente, FormatNumber(descuento, 2), FormatNumber(subtotal, 2), FormatNumber(ieps, 2), FormatNumber(Iva, 2), FormatNumber(total, 2), FormatNumber(acuenta, 2), FormatNumber(resta, 2), status, fechanueva)
                        T_Subtotal = T_Subtotal + subtotal
                        T_Descuento = T_Descuento + descuento
                        T_Total = T_Total + total
                        T_Descuento = T_Descuento + descuento
                        T_IVA = T_IVA + Iva
                        T_IEPS = T_IEPS + ieps
                        T_ACuenta = T_ACuenta + acuenta
                        T_Resta = T_Resta + resta
                        T_Propina = T_Propina + propina

                        barcarga.Value = barcarga.Value + 1
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtIeps.Text = FormatNumber(T_IVA, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)
                txtPropina.Text = FormatNumber(T_Propina, 2)

                barcarga.Visible = False
                barcarga.Value = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

        If (rbVentasPorcentaje.Checked) Then
            existencia = 0
            Dim VOY As Double = 0
            Dim AHORASI As Double = 0

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Existencia from Productos where Codigo='" & cboDatos.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existencia = rd1(0).ToString
                    End If
                Else
                    existencia = 0
                End If
                rd1.Close()

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                            "select Cantidad from VentasDetalle where left(Codigo, 6)='" & Strings.Left(cboDatos.Text, 6) & "' and Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' order by Codigo "
                rd3 = cmd3.ExecuteReader
                Do While rd3.Read
                    cantidad = IIf(rd3("Cantidad").ToString() = "", 1, rd3("Cantidad").ToString())
                    voy = voy + cantidad
                Loop

                AHORASI = existencia + CDec(VOY)
                rd3.Close()
                cnn3.Close()


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Folio,Cliente,Fecha FROM Ventas WHERE Fecha between '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "' ORDER BY FOLIO"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText =
                                    "select Codigo,Nombre,Unidad,Cantidad,Precio,TotalSinIVA,Descto,TotalIEPS,Total from VentasDetalle where left(Codigo, 6)='" & Strings.Left(cboDatos.Text, 6) & "' and Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and Folio=" & folio & " order by Codigo "
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                codigo = rd3("Codigo").ToString
                                barras = CB(codigo)
                                descripcion = rd3("Nombre").ToString
                                uventa = rd3("Unidad").ToString
                                cantidad = rd3("Cantidad").ToString
                                precio = rd3("Precio").ToString
                                subtotal = rd3("TotalSinIVA").ToString
                                descu = rd3("Descto").ToString
                                ieps = rd3("TotalIEPS").ToString
                                fecha = rd1("Fecha").ToString
                                fechanueva = Format(fecha, "yyyy-MM-dd")
                                utilidad = DameUti(folio, codigo, cantidad)
                                total = rd3("Total").ToString

                                T_Subtotal = T_Subtotal + subtotal
                                T_Total = T_Total + total

                                Iva = CDbl(total) - CDbl(subtotal)

                                If Len(codigo) <= 6 Then
                                    porcentaje = 0
                                    'sumaPorcentaje = 0
                                Else
                                    porcentaje = cantidad * 100 / AHORASI
                                    porcentaje = FormatNumber(porcentaje, 2)
                                    ' sumaPorcentaje = sumaPorcentaje + CDec(porcentaje)
                                End If

                                grdCaptura.Rows.Add(folio, cliente, codigo, barras, descripcion, uventa, cantidad, porcentaje, precio, subtotal, descu, ieps, Iva, total, fechanueva, utilidad)

                                T_Descuento = T_Descuento + descu
                                T_IEPS = T_IEPS + ieps
                                T_IVA = T_IVA + Iva
                            End If
                        End If
                        rd3.Close()

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                cnn3.Close()

                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtIeps.Text = FormatNumber(T_IEPS, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

        If (rbComandasCance.Checked) Then
            cuantos = 0
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(IDC) FROM rep_comandas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Status='CANCELADA'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Nombre,Cantidad,UVenta,Precio,Total,NMESA,CUsuario,Fecha,Hr,CostVUE FROM rep_comandas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Status='CANCELADA' ORDER BY Nombre"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        descripcion = rd1("Nombre").ToString
                        cantidad = rd1("Cantidad").ToString
                        uventa = rd1("UVenta").ToString
                        precio = rd1("Precio").ToString
                        total = rd1("Total").ToString
                        mesa = rd1("NMESA").ToString
                        usua = rd1("CUsuario").ToString
                        fecha = rd1("Fecha").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd")
                        hr = rd1("Hr").ToString
                        costo = rd1("CostVUE").ToString

                        grdCaptura.Rows.Add(descripcion, cantidad, uventa, precio, total, mesa, usua, fechanueva, hr)
                        barcarga.Value = barcarga.Value + 1

                        T_Total = T_Total + total
                        T_Suma = T_Suma + cantidad
                        T_Costo = T_Costo + costo
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                barcarga.Visible = False
                barcarga.Value = 0

                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtCostoUtilidad.Text = FormatNumber(CDbl(txtTotal.Text - txtCosto.Text), 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        If (rbCortesias.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT v.Folio,Nombre,Cantidad,Unidad,Precio,Cliente,v.Usuario,FVenta,HVenta,CostoVUE FROM Ventas V INNER JOIN VentasDetalle VD On V.Folio=VD.Folio WHERE V.Concepto='CORTESIA' AND V.Fecha BETWEEN  '" & Format(m1, "yyyy-MM-dd") & " " & dtpinicio.Text & "'  and '" & Format(m2, "yyyy-MM-dd") & " " & dtpFin.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        descripcion = rd1("Nombre").ToString
                        cantidad = rd1("Cantidad").ToString
                        uventa = rd1("Unidad").ToString
                        precio = rd1("Precio").ToString
                        total = precio * cantidad
                        mesa = rd1("Cliente").ToString
                        usua = rd1("Usuario").ToString
                        fecha = rd1("FVenta").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd")
                        hr = rd1("HVenta").ToString
                        costo = rd1("CostoVUE").ToString

                        grdCaptura.Rows.Add(folio, descripcion, cantidad, uventa, precio, total, mesa, usua, fechanueva, hr)

                        T_Total = T_Total + total
                        T_Suma = T_Suma + cantidad
                        T_Costo = T_Costo + costo
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtCosto.Text = FormatNumber(T_Costo, 2)
                txtSuma.Text = FormatNumber(T_Suma, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtCostoUtilidad.Text = FormatNumber(CDbl(txtTotal.Text - txtCosto.Text), 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Function CB(ByVal cod As String) As String
        Try
            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select CodBarra from Productos where Codigo='" & cod & "'"
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
    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown
        Dim M1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim M2 As Date = mcHasta.SelectionStart.ToShortDateString
        Dim querry As String = ""
        cboDatos.Items.Clear()

        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbVentasTotales.Checked) Then
                querry = "SELECT DISTINCT Status FROM ventas WHERE Fecha BETWEEN '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' AND '" & Format(M2, "yyyy-MM-dd") & " " & dtpFin.Text & "' "
            End If

            If (rbVentasClientes.Checked) Then
                querry = "select distinct Cliente from Ventas where Fecha between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpFin.Text & "' and Cliente<>'' order by Cliente"
            End If

            If (rbVentasCliDetalle.Checked) Then
                querry = "select distinct Cliente from Ventas where Fecha between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpFin.Text & "' and Cliente<>'' order by Cliente"
            End If
            If (rbVentasDepa.Checked) Then
                querry = "select distinct Depto from VentasDetalle where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Depto<>'' order by Depto"
            End If
            If (rbVentasGrupo.Checked) Then
                querry = "select distinct Grupo from VentasDetalle where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Grupo<>'' order by Grupo"
            End If
            If (rbVentasProducto.Checked) Then
                querry = "select distinct Nombre from VentasDetalle where Fecha between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' and Nombre<>'' order by Nombre"
            End If
            If (rbVentasVendedor.Checked) Then
                querry = "select distinct Usuario from Ventas where Fecha between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpFin.Text & "' and Usuario<>''"
            End If

            If (rbVendidoProveedor.Checked) Then
                querry = "SELECT DISTINCT ProvPri FROM Productos WHERE ProvPri<>'' ORDER BY ProvPri"
            End If

            If (rbVentasFormato.Checked) Then
                querry = "select distinct Formato from Ventas where Fecha between '" & Format(M1, "yyyy-MM-dd") & " " & dtpinicio.Text & "' and '" & Format(M2, "yyyy-MM-dd") & " " & dtpFin.Text & "'"
            End If

            If (rbVentasPorcentaje.Checked) Then
                querry =
                    "select Codigo from Productos where LENGTH(Codigo)=6 order by Codigo"
            End If

            If (rbTraspasos.Checked) Then
                cboDatos.Items.Add("ENTRADA")
                cboDatos.Items.Add("SALIDA")
                grdCaptura.Rows.Clear()
                txtTotal.Text = "0.00"
                txtSubtotal.Text = "0.00"
                Exit Sub
            End If

            cmd5.CommandText = querry
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

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        ExportarDataGridViewAExcel(grdCaptura)
        'If grdCaptura.Rows.Count = 0 Then
        '    Exit Sub
        'End If

        'If MsgBox("¿Desea exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        ''Creamos las variables
        'Dim exApp As New Microsoft.Office.Interop.Excel.Application
        'Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        'Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        'Try
        '    'Añadimos el Libro al programa, y la hoja al libro
        '    exLibro = exApp.Workbooks.Add
        '    exHoja = exLibro.Worksheets.Application.ActiveSheet

        '    'exHoja.Columns("A").NumberFormat = "@"
        '    'exHoja.Columns("B").NumberFormat = "@"
        '    'exHoja.Columns("C").NumberFormat = "@"
        '    'exHoja.Columns("D").NumberFormat = "@"
        '    'exHoja.Columns("I").NumberFormat = "@"
        '    'exHoja.Columns("G").NumberFormat = "@"
        '    'exHoja.Columns("K").NumberFormat = "@"

        '    Dim Fila As Integer = 0
        '    Dim Col As Integer = 0

        '    ' ¿Cuantas columnas y cuantas filas?
        '    Dim NCol As Integer = grdCaptura.ColumnCount
        '    Dim NRow As Integer = grdCaptura.RowCount

        '    'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
        '    For i As Integer = 1 To NCol
        '        exHoja.Cells.Item(1, i) = grdCaptura.Columns(i - 1).HeaderText.ToString
        '        'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
        '    Next

        '    For Fila = 0 To NRow - 1
        '        For Col = 0 To NCol - 1
        '            exHoja.Cells.Item(Fila + 2, Col + 1) = grdCaptura.Rows(Fila).Cells(Col).Value.ToString

        '        Next
        '    Next

        '    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
        '    exHoja.Rows.Item(1).Font.Bold = 1
        '    exHoja.Rows.Item(1).HorizontalAlignment = 3
        '    exHoja.Columns.AutoFit()

        '    'Aplicación visible
        '    exApp.Application.Visible = True

        '    exHoja = Nothing
        '    exLibro = Nothing
        '    exApp = Nothing

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
        'End Try
    End Sub

    Public Sub ExportarDataGridViewAExcel(dgv As DataGridView)
        If grdCaptura.Rows.Count = 0 Then MsgBox("Genera el reporte para poder exportar los datos a Excel.", vbInformation + vbOKOnly, titulocentral) : Exit Sub
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grdCaptura.Rows.Clear()
        rbVentasTotales.Checked = True
        barcarga.Visible = False
        barcarga.Value = 0
        mcDesde.SetDate(Now)
        mcHasta.SetDate(Now)
        cboDatos.Text = ""
        cboDatos.Items.Clear()
        cboDatos.Visible = False
        'txtrestante.Text = "0.00"
        'txtVendido.Text = "0.00"
        txtTotal.Text = "0.00"
        txtAcuenta.Text = "0.00"
        txtSubtotal.Text = "0.00"


    End Sub

    Private Sub btnAntibiotico_Click(sender As Object, e As EventArgs) Handles btnAntibiotico.Click
        Dim M1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim M2 As Date = mcHasta.SelectionStart.ToShortDateString
        Try
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 13
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Código"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descripción"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Cantidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Existencia"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha Entrada"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha Salida"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "N° Receta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Cedula"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Prescribe"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(10)
                    .HeaderText = "Domicilio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(11)
                    .HeaderText = "Lote"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(12)
                    .HeaderText = "Caducidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Dim cedula, nombre, direccion As String
            Dim fecha As String = ""
            Dim fecha2 As String = ""
            Dim fechanuv As String = ""
            Dim fechanuv2 As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select VE.Folio,PR.Codigo,PR.Nombre,Sum(VD.Cantidad)as Cantidad,PR.Existencia,VD.Fecha,RAnt.receta ,RAnt.Status,RAnt.me_id,VD.Lote,VD.Caducidad From (((VentasDetalle VD INNER JOIN Productos PR ON VD.Codigo=PR.Codigo)INNER JOIN Ventas VE ON VD.Folio=VE.Folio)INNER JOIN rep_antib RAnt ON RAnt.Folio=VE.Folio ) Where VD.Antibiotico=1 AND FVenta BETWEEN '" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "'  Group By VE.Folio,PR.Codigo,PR.Nombre,VD.Cantidad,PR.Existencia,VD.Fecha,RAnt.receta,RAnt.Status,RAnt.me_id,VD.Lote,VD.Caducidad"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    If rd1("me_id").ToString = "" Then

                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "Select Cedula,Nombre,Domicilio From ctmedicos CM,rep_antib RES Where CM.id=RES.me_id and RES.Folio=" & rd1("Folio") & ""
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                cedula = rd2(0).ToString
                                nombre = rd2(1).ToString
                                direccion = rd2(2).ToString
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()
                    End If

                    fecha = rd1("Fecha").ToString
                    fecha2 = FEntrada(rd1("Codigo").ToString)
                    fechanuv = Format(fecha, "yyyy-MM-dd")
                    fechanuv2 = Format(fecha2, "yyyy-MM-dd HH:mm:ss")



                    grdCaptura.Rows.Add(rd1("Folio").ToString,
                                        rd1("Codigo").ToString,
                                        rd1("Nombre").ToString,
                                        rd1("Cantidad").ToString,
                                        rd1("Existencia").ToString,
                                        fecha2,
                                        fecha,
                                        rd1("Receta").ToString,
                                        cedula,
                                        nombre,
                                        direccion,
                                        rd1("Lote").ToString,
                                        rd1("Caducidad").ToString
)


                End If
            Loop
            rd1.Close()
            cnn1.Close()

            btnExcel.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnControlado_Click(sender As Object, e As EventArgs) Handles btnControlado.Click
        Dim M1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim M2 As Date = mcHasta.SelectionStart.ToShortDateString
        Try
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 11
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Código"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descripción"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Cantidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Existencia"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha Entrada"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha Salida"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "N° Receta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Cedula"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Prescribe"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(10)
                    .HeaderText = "Domicilio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Dim cedula, nombre, direccion As String
            Dim fecha As Date = Nothing
            Dim fecha2 As Date = Nothing
            Dim fechanuv As String = ""
            Dim fechanuv2 As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select VE.Folio,PR.Codigo,PR.Nombre,Sum(VD.Cantidad)as Cantidad,PR.Existencia,VD.Fecha,RAnt.receta ,RAnt.Status,RAnt.me_id From (((VentasDetalle VD INNER JOIN Productos PR ON VD.Codigo=PR.Codigo)INNER JOIN Ventas VE ON VD.Folio=VE.Folio)INNER JOIN rep_antib RAnt ON RAnt.Folio=VE.Folio ) Where VD.Grupo='CONTROLADO' AND FVenta >='" & Format(M1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND FVenta <='" & Format(M2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "'  Group By VE.Folio,PR.Codigo,PR.Nombre,VD.Cantidad,PR.Existencia,VD.Fecha,RAnt.receta ,RAnt.Status,RAnt.me_id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    If rd1("me_id").ToString = "" Then

                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "Select Cedula,Nombre,Domicilio From ctmedicos CM,rep_antib RES Where CM.id=RES.me_id and RES.Folio=" & rd1("Folio") & ""
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                cedula = rd2(0).ToString
                                nombre = rd2(1).ToString
                                direccion = rd2(2).ToString
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()
                    End If

                    fecha = rd1("Fecha").ToString
                    fecha2 = FEntrada(rd1("Codigo").ToString)
                    fechanuv = Format(fecha, "yyyy-MM-dd")
                    fechanuv2 = Format(fecha2, "yyyy-MM-dd HH:mm:ss")

                    grdCaptura.Rows.Add(rd1("Folio").ToString,
                                        rd1("Codigo").ToString,
                                        rd1("Nombre").ToString,
                                        rd1("Cantidad").ToString,
                                        rd1("Existencia").ToString,
                                        fechanuv2,
                                        fechanuv,
                                        rd1("Receta").ToString,
                                        cedula,
                                        nombre,
                                        direccion
)


                End If
            Loop
            rd1.Close()
            cnn1.Close()

            btnExcel.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Function FEntrada(ByVal codigo As String)

        Try
            Dim fecha As Date = Nothing

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT FechaC FROM comprasdet WHERE Codigo='" & codigo & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    FEntrada = rd3(0).ToString
                End If
            Else
                ' FEntrada = IIf(rd3(0).ToString = "", Date.Now, rd3(0).ToString)
                FEntrada = ""
            End If
            rd3.Close()
            cnn3.Close()

            If FEntrada = "" Then
                FEntrada = Date.Now
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Sub rbFiscal_Click(sender As Object, e As EventArgs) Handles rbFiscal.Click
        If (rbFiscal.Checked) Then

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 11
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Nota de Venta"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Facturado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Forma de Pago"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Banco"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Referencia"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Cuenta"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "Id"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = False
                    .Resizable = DataGridViewTriState.False
                End With
            End With

        End If
    End Sub

    Private Sub rbComandasCance_Click(sender As Object, e As EventArgs) Handles rbComandasCance.Click
        If (rbComandasCance.Checked) Then

            rbVentasTotales.Checked = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbVentasTotales.Checked = False
            rbVentasDetalle.Checked = False
            rbVentasClientes.Checked = False
            rbVentasCliDetalle.Checked = False
            rbVentasDepa.Checked = False
            rbVentasGrupo.Checked = False
            rbVentasPago.Checked = False
            rbVentasProducto.Checked = False
            rbVentasVendedor.Checked = False
            rbDevoluciones.Checked = False
            rbProductoVendido.Checked = False
            rbVendidoProveedor.Checked = False
            rbVentasFormato.Checked = False
            rbVentasPorcentaje.Checked = False
            rbFiscal.Checked = False

            grdCaptura.ColumnCount = 9
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cantidad"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Unidad"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Precio"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Total"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Mesa"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Usuario"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Hora"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

        End If
    End Sub

    Private Sub rbCortesias_Click(sender As Object, e As EventArgs) Handles rbCortesias.Click
        If (rbCortesias.Checked) Then

            rbVentasTotales.Checked = False

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbVentasTotales.Checked = False
            rbVentasDetalle.Checked = False
            rbVentasClientes.Checked = False
            rbVentasCliDetalle.Checked = False
            rbVentasDepa.Checked = False
            rbVentasGrupo.Checked = False
            rbVentasPago.Checked = False
            rbVentasProducto.Checked = False
            rbVentasVendedor.Checked = False
            rbDevoluciones.Checked = False
            rbProductoVendido.Checked = False
            rbVendidoProveedor.Checked = False
            rbVentasFormato.Checked = False
            rbVentasPorcentaje.Checked = False
            rbFiscal.Checked = False

            grdCaptura.ColumnCount = 10
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Cantidad"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Unidad"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Precio"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Total"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Mesa"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Usuario"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Hora"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

        End If
    End Sub

    Private Sub rbFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiscal.CheckedChanged

    End Sub

    Private Sub rbTraspasos_Click(sender As Object, e As EventArgs) Handles rbTraspasos.Click
        If rbTraspasos.Checked = True Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = True

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            rbComandasCance.Checked = False
            rbCortesias.Checked = False

            btnImprimir.Visible = False

            grdCaptura.ColumnCount = 6
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Codigo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripcion"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Cantidad"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Precio"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Total"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        If rbFiscal.Checked = True Then
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim celda As DataGridViewCellEventArgs = e
                Dim fila As Integer = grdCaptura.CurrentRow.Index
                If celda.ColumnIndex = 0 Then
                    Dim selectedRow As DataGridViewRow = grdCaptura.Rows(e.RowIndex)
                    If selectedRow.Cells(0).Value.ToString <> "" And selectedRow.Cells(4).Value.ToString = "0" Then
                        frmfacturacion.Close()
                        My.Application.DoEvents()
                        frmfacturacion.Show()
                        frmfacturacion.BringToFront()
                        frmfacturacion.Cmb_RazonS.Text = selectedRow.Cells(1).Value.ToString
                        frmfacturacion.Cmb_RazonS_KeyPress(frmfacturacion.Cmb_RazonS, New KeyPressEventArgs(ChrW(Keys.Enter)))
                        frmfacturacion.txtNotaVenta.Text = selectedRow.Cells(0).Value.ToString
                        frmfacturacion.txtNotaVenta_KeyPress(frmfacturacion.txtNotaVenta, New KeyPressEventArgs(ChrW(Keys.Enter)))
                    End If
                End If

                If celda.ColumnIndex = 4 Then
                    boxcantidad.Visible = True
                    Dim selectedRow As DataGridViewRow = grdCaptura.Rows(e.RowIndex)
                    idabono = selectedRow.Cells(10).Value.ToString
                    txtcantidad.Text = selectedRow.Cells(4).Value.ToString
                    txtcodigo.Tag = fila
                    txtcantidad.Focus.Equals(True)
                End If
            End If
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            grdCaptura.Rows(txtcodigo.Tag).Cells(4).Value = txtcantidad.Text
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Update Abonoi set Parcialidad='" & txtcantidad.Text & "' where Id=" & idabono & ""
                If cmd1.ExecuteNonQuery Then
                    boxcantidad.Visible = False
                    txtcantidad.Text = ""
                    txtcantidad.Tag = ""
                    txtcodigo.Text = ""
                    txtcodigo.Tag = ""
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim impresora As String = ""
        Dim tama As Integer = 0
        tama = TamImpre()
        impresora = ImpresoraImprimir()

        If tama = 80 Then
            PMasVendido80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
            Dim ps As New System.Drawing.Printing.PaperSize("Custom", 310, 3100)
            PMasVendido80.DefaultPageSettings.PaperSize = ps
            PMasVendido80.Print()
        End If
    End Sub

    Private Sub PMasVendido80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PMasVendido80.PrintPage
        Try

            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 9, FontStyle.Regular)
            Dim fuente_a As New Font("Lucida Sans Typewriter", 12, FontStyle.Bold)

            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            Dim CODIGO As String = ""
            Dim DESCRIPCION As String = ""
            Dim UNIDAD As String = ""
            Dim CANTIDAD As Double = 0

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("PRODUCTO MÁS VENDIDO", fuente_b, Brushes.Black, 135, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Fecha Inicial: " & Format(dtpinicio.Value, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("Fecha Final:   " & Format(dtpFin.Value, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CODIGO", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 65, Y)
            e.Graphics.DrawString("UNIDAD", fuente_b, Brushes.Black, 205, Y, derecha)
            e.Graphics.DrawString("CANTIDAD", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            For LUFFY As Integer = 0 To grdCaptura.Rows.Count - 1

                CODIGO = grdCaptura.Rows(LUFFY).Cells(0).Value.ToString
                DESCRIPCION = grdCaptura.Rows(LUFFY).Cells(1).Value.ToString
                UNIDAD = grdCaptura.Rows(LUFFY).Cells(2).Value.ToString
                CANTIDAD = grdCaptura.Rows(LUFFY).Cells(3).Value.ToString

                e.Graphics.DrawString(CODIGO, New Font("Arial", 8, FontStyle.Regular), Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 30
                Dim texto As String = DESCRIPCION
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 65, Y)
                    Y += 15
                    inicio += caracteresPorLinea
                End While

                e.Graphics.DrawString(UNIDAD, fuente_p, Brushes.Black, 215, Y, derecha)
                e.Graphics.DrawString(FormatNumber(CANTIDAD, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                Y += 20
            Next
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdCaptura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmRepMac.BringToFront()
        frmRepMac.Show()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub lblPropina_Click(sender As Object, e As EventArgs) Handles lblPropina.Click

    End Sub
End Class