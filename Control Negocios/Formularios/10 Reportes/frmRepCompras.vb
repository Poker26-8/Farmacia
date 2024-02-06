Public Class frmRepCompras

    Private Sub opttotales_Click(sender As System.Object, e As System.EventArgs) Handles opttotales.Click
        If (opttotales.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            cms1.Enabled = True

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Referencia"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Remisión"
                    .Width = 75
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
                    .HeaderText = "Subtotal"
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
                    .HeaderText = "Fecha"
                    .Width = 95
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Estado"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optproveedor_Click(sender As System.Object, e As System.EventArgs) Handles optproveedor.Click
        If (optproveedor.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            cms1.Enabled = True

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Factura"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Remisión"
                    .Width = 75
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
                    .HeaderText = "Subtotal"
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
                    .HeaderText = "Fecha"
                    .Width = 95
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Estado"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optrecibidos_Click(sender As System.Object, e As System.EventArgs) Handles optrecibidos.Click
        If (optrecibidos.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            cms1.Enabled = False

            grdcaptura.ColumnCount = 10
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Factura"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Remisión"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Proveedor"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Código"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Fecha"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optrecibidosdepto_Click(sender As System.Object, e As System.EventArgs) Handles optrecibidosdepto.Click
        If (optrecibidosdepto.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            cms1.Enabled = False

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Proveedor"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Código"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Fecha"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optreibidosgrupo_Click(sender As System.Object, e As System.EventArgs) Handles optreibidosgrupo.Click
        If (optreibidosgrupo.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            cms1.Enabled = False

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Proveedor"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Código"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Descripción"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Fecha"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub optabonosprove_Click(sender As System.Object, e As System.EventArgs) Handles optabonosprove.Click
        If (optabonosprove.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            cms1.Enabled = False

            grdcaptura.ColumnCount = 9
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Factura"
                    .Width = 95
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Remisión"
                    .Width = 95
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
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Monto"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Efectivo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Pagos"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Banco"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Referencia"
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

    Private Sub optabonosproves_Click(sender As System.Object, e As System.EventArgs) Handles optabonosproves.Click
        If (optabonosproves.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            cms1.Enabled = False

            grdcaptura.ColumnCount = 9
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Factura"
                    .Width = 95
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Remisión"
                    .Width = 95
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
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Monto"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Efectivo"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Pagos"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Banco"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Referencia"
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

    Private Sub optnotascred_Click(sender As System.Object, e As System.EventArgs) Handles optnotascred.Click
        If (optnotascred.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            cms1.Enabled = False

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
                    .HeaderText = "Nota crédito"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Proveedor"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
                    .HeaderText = "Fecha"
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

    Private Sub optdevueltos_Click(sender As System.Object, e As System.EventArgs) Handles optdevueltos.Click
        If (optdevueltos.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            cms1.Enabled = False

            grdcaptura.ColumnCount = 11
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Factura"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Remisión"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Nota crédito"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Proveedor"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Código"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(10)
                    .HeaderText = "Fecha"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub btnreporte_Click(sender As System.Object, e As System.EventArgs) Handles btnreporte.Click
        Dim Month1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim Month2 As Date = mCalendar2.SelectionStart.ToShortDateString

        Dim cuantas As Double = 0

        barcarga.Visible = False
        barcarga.Value = 0
        grdcaptura.Rows.Clear()

        'Compras totales
        If (opttotales.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from Compras where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Status<>'CANCELADA'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                    btnexportar.Enabled = True
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Status<>'CANCELADA' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFolio As Integer = rd1("Id").ToString
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MySubt As Double = rd1("Sub2").ToString
                    Dim MyIVA As Double = rd1("IVA").ToString
                    Dim MyTota As Double = rd1("Total").ToString
                    Dim MyFecha As String = rd1("FechaC").ToString
                    Dim Estado As String = rd1("Status").ToString

                    grdcaptura.Rows.Add(MyFolio, MyRemi, MyProv, FormatNumber(MySubt, 2), FormatNumber(MyIVA, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFecha, DateFormat.ShortDate), Estado)
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            barcarga.Value = 0
            barcarga.Visible = False
            rd1.Close() : cnn1.Close()
        End If

        'Compras totales por proveedor
        If (optproveedor.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un proveedor para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from Compras where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Proveedor='" & ComboBox1.Text & "' and Status<>'CANCELADA'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Proveedor='" & ComboBox1.Text & "' and Status<>'CANCELADA' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFact As String = rd1("NumFactura").ToString
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MySubt As Double = rd1("Sub2").ToString
                    Dim MyIVA As Double = rd1("IVA").ToString
                    Dim MyTota As Double = rd1("Total").ToString
                    Dim MyFecha As String = rd1("FechaC").ToString
                    Dim Estado As String = rd1("Status").ToString

                    grdcaptura.Rows.Add(MyFact, MyRemi, MyProv, FormatNumber(MySubt, 2), FormatNumber(MyIVA, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFecha, DateFormat.ShortDate), Estado)
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Visible = False
            barcarga.Value = 0
        End If

        'Productos recibidos
        If (optrecibidos.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFact As String = rd1("NumFactura").ToString
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MyCodi As String = rd1("Codigo").ToString
                    Dim MyDesc As String = rd1("Nombre").ToString
                    Dim MyUnid As String = rd1("UCompra").ToString
                    Dim MyCant As Double = rd1("Cantidad").ToString
                    Dim MyPrec As Double = rd1("Precio").ToString
                    Dim MyTota As Double = MyCant * MyPrec
                    Dim MyFech As String = rd1("FechaC").ToString

                    grdcaptura.Rows.Add(MyRemi, MyFact, MyProv, MyCodi, MyDesc, MyUnid, MyCant, FormatNumber(MyPrec, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFech, DateFormat.ShortDate))
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Value = 0
            barcarga.Visible = False
        End If

        'Productos recibidos (concentrado)
        If (optconcentrado.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select distinct Codigo from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and  '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim mycode As String = rd1(0).ToString()
                        Dim cantidad As Double = 0
                        Dim precio As Double = 0
                        Dim unidad As String = ""
                        Dim nombre As String = ""
                        Dim total As Double = 0

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select sum(Cantidad) from ComprasDet where Codigo='" & mycode & "' and FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and  '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                cantidad = rd2(0).ToString()
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Precio, UCompra, Nombre from ComprasDet where Id=(select MAX(Id) from ComprasDet where Codigo='" & mycode & "')"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                precio = rd2(0).ToString()
                                unidad = rd2(1).ToString()
                                nombre = rd2(2).ToString()
                            End If
                        End If
                        rd2.Close()

                        total = cantidad * precio

                        grdcaptura.Rows.Add(mycode, nombre, unidad, cantidad, precio, total)
                    End If
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

        'Productos recibidos por departamento
        If (optrecibidosdepto.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un departamento para generar el reporte.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0 and Depto='" & ComboBox1.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Value = 0
            barcarga.Visible = True
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0 and Depto='" & ComboBox1.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MyCode As String = rd1("Codigo").ToString
                    Dim MyDesc As String = rd1("Nombre").ToString
                    Dim MyUnid As String = rd1("UCompra").ToString
                    Dim MyCant As Double = rd1("Cantidad").ToString
                    Dim MyPrec As Double = rd1("Precio").ToString
                    Dim MyTota As Double = MyCant * MyPrec
                    Dim MyFech As String = rd1("FechaC").ToString

                    grdcaptura.Rows.Add(MyProv, MyCode, MyDesc, MyUnid, MyCant, FormatNumber(MyPrec, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFech, DateFormat.ShortDate))
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Value = 0
            barcarga.Visible = False
        End If

        'Productos recibidos por grupo
        If (optreibidosgrupo.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un grupo para generar el reporte.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0 and Grupo='" & ComboBox1.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Value = 0
            barcarga.Visible = True
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0 and Grupo='" & ComboBox1.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MyCode As String = rd1("Codigo").ToString
                    Dim MyDesc As String = rd1("Nombre").ToString
                    Dim MyUnid As String = rd1("UCompra").ToString
                    Dim MyCant As Double = rd1("Cantidad").ToString
                    Dim MyPrec As Double = rd1("Precio").ToString
                    Dim MyTota As Double = MyCant * MyPrec
                    Dim MyFech As String = rd1("FechaC").ToString

                    grdcaptura.Rows.Add(MyProv, MyCode, MyDesc, MyUnid, MyCant, FormatNumber(MyPrec, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFech, DateFormat.ShortDate))
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Value = 0
            barcarga.Visible = False
        End If

        'Abono por proveedor
        If (optabonosprove.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un proveedor para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from AbonoE where Proveedor='" & ComboBox1.Text & "' and Fecha between '" & Format(Month1, "yyyy-MM-dd") & "' and '" & Format(Month2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Value = 0
            barcarga.Visible = True
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from AbonoE where Proveedor='" & ComboBox1.Text & "' and Fecha between '" & Format(Month1, "yyyy-MM-dd") & "' and '" & Format(Month2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFact As String = rd1("NumFactura").ToString
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MyFech As String = rd1("Fecha").ToString
                    Dim MyMont As Double = rd1("Abono").ToString
                    Dim MyEfec As Double = rd1("Efectivo").ToString
                    Dim tar As Double = rd1("Tarjeta").ToString
                    Dim tra As Double = rd1("Transfe").ToString
                    Dim otr As Double = rd1("Otro").ToString
                    Dim MyPago As Double = tra + tar + otr
                    Dim MyBanc As String = rd1("Banco").ToString
                    Dim MyRefe As String = rd1("Referencia").ToString

                    grdcaptura.Rows.Add(MyFact, MyRemi, MyProv, FormatDateTime(MyFech, DateFormat.ShortDate), FormatNumber(MyMont, 2), FormatNumber(MyEfec, 2), FormatNumber(MyPago, 2), MyBanc, MyRefe)
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Value = 0
            barcarga.Visible = False
        End If

        'Abonos a proveedores
        If (optabonosproves.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from AbonoE where Fecha between '" & Format(Month1, "yyyy-MM-dd") & "' and '" & Format(Month2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from AbonoE where Fecha between '" & Format(Month1, "yyyy-MM-dd") & "' and '" & Format(Month2, "yyyy-MM-dd") & "' and Concepto='ABONO'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFact As String = rd1("NumFactura").ToString
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MyFech As String = rd1("Fecha").ToString
                    Dim MyMont As Double = rd1("Abono").ToString
                    Dim MyEfec As Double = rd1("Efectivo").ToString
                    Dim tar As Double = rd1("Tarjeta").ToString
                    Dim tra As Double = rd1("Transfe").ToString
                    Dim otr As Double = rd1("Otro").ToString
                    Dim MyPago As Double = tra + tar + otr
                    Dim MyBanc As String = rd1("Banco").ToString
                    Dim MyRefe As String = rd1("Referencia").ToString

                    grdcaptura.Rows.Add(MyFact, MyRemi, MyProv, FormatDateTime(MyFech, DateFormat.ShortDate), FormatNumber(MyMont, 2), FormatNumber(MyEfec, 2), FormatNumber(MyPago, 2), MyBanc, MyRefe)
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Visible = False
            barcarga.Value = 0
        End If

        'Notas de crédito
        If (optnotascred.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from Compras where NotaCred<>'' and FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and NotaCred<>'' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyFact As String = rd1("NumFactura").ToString
                    Dim MyNCre As String = rd1("NotaCred").ToString
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MySubt As Double = rd1("Sub2").ToString
                    Dim MyIVA As Double = rd1("IVA").ToString
                    Dim MyTota As Double = rd1("Total").ToString
                    Dim MyFech As String = rd1("FechaC").ToString

                    grdcaptura.Rows.Add(MyRemi, MyFact, MyNCre, MyProv, FormatNumber(MySubt, 2), FormatNumber(MyIVA, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFech, DateFormat.ShortDate))
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Value = 0
            barcarga.Visible = False
        End If

        'Notas de crédito por proveedor
        If (optnotascredprov.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un proveedor para continuar con el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from Compras where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and NotaCred<>'' and Proveedor='" & ComboBox1.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Proveedor='" & ComboBox1.Text & "' and NotaCred<>'' order by Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyFact As String = rd1("NumFactura").ToString
                    Dim MyNCre As String = rd1("NotaCred").ToString
                    Dim MySubt As Double = rd1("Sub2").ToString
                    Dim MyIVA As Double = rd1("IVA").ToString
                    Dim MyTota As Double = rd1("Total").ToString
                    Dim MyFech As String = rd1("FechaC").ToString

                    grdcaptura.Rows.Add(MyRemi, MyFact, MyNCre, FormatNumber(MySubt, 2), FormatNumber(MyIVA, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFech, DateFormat.ShortDate))
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Value = 0
            barcarga.Visible = False
        End If

        'Productos devueltos
        If (optdevueltos.Checked) Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select count(Id) from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0 and NotaCred<>''"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            barcarga.Visible = True
            barcarga.Value = 0
            barcarga.Maximum = cuantas

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ComprasDet where FechaC between '" & Format(Month1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Month2, "yyyy-MM-dd 23:59:59") & "' and Id_Compra<>0 and NotaCred<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim MyFact As String = rd1("NumFactura").ToString
                    Dim MyRemi As String = rd1("NumRemision").ToString
                    Dim MyNCre As String = rd1("NotaCred").ToString
                    Dim MyProv As String = rd1("Proveedor").ToString
                    Dim MyCodi As String = rd1("Codigo").ToString
                    Dim MyDesc As String = rd1("Nombre").ToString
                    Dim MyUnid As String = rd1("UCompra").ToString
                    Dim MyCant As Double = rd1("Cantidad").ToString
                    Dim MyPrec As Double = rd1("Precio").ToString
                    Dim MyTota As Double = MyCant * MyPrec
                    Dim MyFech As String = rd1("FechaC").ToString

                    grdcaptura.Rows.Add(MyRemi, MyFact, MyNCre, MyProv, MyCodi, MyDesc, MyUnid, MyCant, FormatNumber(MyPrec, 2), FormatNumber(MyTota, 2), FormatDateTime(MyFech, DateFormat.ShortDate))
                    barcarga.Value = barcarga.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barcarga.Value = 0
            barcarga.Visible = False
        End If
        If grdcaptura.Rows.Count > 0 Then
            btnexportar.Enabled = True
        Else
            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub ComboBox1_DropDown(sender As System.Object, e As System.EventArgs) Handles ComboBox1.DropDown
        Dim m1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim m2 As Date = mCalendar2.SelectionStart.ToShortDateString
        Dim querry As String = ""

        ComboBox1.Items.Clear()
        If (optproveedor.Checked) Then
            querry = "select distinct Proveedor from Compras where FechaC between '" & Format(m1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(m2, "yyyy-MM-dd 23:59:59") & "' and NumRemision<>'' and Proveedor<>''"
        End If
        If (optrecibidosdepto.Checked) Then
            querry = "select distinct Depto from ComprasDet where FechaC between '" & Format(m1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(m2, "yyyy-MM-dd 23:59:59") & "' and NumRemision<>'' and Proveedor<>''"
        End If
        If (optreibidosgrupo.Checked) Then
            querry = "select distinct Grupo from ComprasDet where FechaC between '" & Format(m1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(m2, "yyyy-MM-dd 23:59.59") & "' and NumRemision<>'' and Proveedor<>''"
        End If
        If (optabonosprove.Checked) Then
            querry = "select distinct Proveedor from AbonoE where Fecha between '" & Format(m1, "yyyy-MM-dd") & "' and '" & Format(m2, "yyyy-MM-dd") & "' and NumRemision<>'' and Proveedor<>''"
        End If
        If (optnotascredprov.Checked) Then
            querry = "select distinct Proveedor from Compras where FechaC between '" & Format(m1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(m2, "yyyy-MM-dd 23:59:59") & "' and NumRemision<>'' and Proveedor<>'' and NotaCred<>''"
        End If
        If querry <> "" Then
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
        End If        
    End Sub

    Private Sub optnotascredprov_Click(sender As System.Object, e As System.EventArgs) Handles optnotascredprov.Click
        If (optnotascredprov.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True
            cms1.Enabled = False

            grdcaptura.ColumnCount = 7
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
                    .HeaderText = "Factura"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
                    .HeaderText = "Fecha"
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

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        opttotales.PerformClick()
        ComboBox1.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Visible = False
        grdcaptura.Rows.Clear()
        mCalendar1.SetDate(Now)
        mCalendar2.SetDate(Now)
        btnexportar.Enabled = False
        barcarga.Visible = False
        barcarga.Value = 0
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

                If (opttotales.Checked) Then
                    exSheet.Columns("B").NumberFormat = "@"
                    exSheet.Columns("D").NumberFormat = "$#,##0.00"
                    exSheet.Columns("E").NumberFormat = "$#,##0.00"
                    exSheet.Columns("F").NumberFormat = "$#,##0.00"
                End If
                If (optproveedor.Checked) Then
                    exSheet.Columns("A").NumberFormat = "@"
                    exSheet.Columns("B").NumberFormat = "@"
                    exSheet.Columns("D").NumberFormat = "$#,##0.00"
                    exSheet.Columns("E").NumberFormat = "$#,##0.00"
                    exSheet.Columns("F").NumberFormat = "$#,##0.00"
                End If
                If (optrecibidos.Checked) Then
                    exSheet.Columns("A").NumberFormat = "@"
                    exSheet.Columns("B").NumberFormat = "@"
                    exSheet.Columns("D").NumberFormat = "@"
                    exSheet.Columns("H").NumberFormat = "$#,##0.00"
                    exSheet.Columns("I").NumberFormat = "$#,##0.00"
                End If
                If (optrecibidosdepto.Checked) Or (optreibidosgrupo.Checked) Then
                    exSheet.Columns("B").NumberFormat = "@"
                    exSheet.Columns("F").NumberFormat = "$#,##0.00"
                    exSheet.Columns("G").NumberFormat = "$#,##0.00"
                End If
                If (optabonosprove.Checked) Or (optabonosproves.Checked) Or (optnotascred.Checked) Then
                    exSheet.Columns("A").NumberFormat = "@"
                    exSheet.Columns("B").NumberFormat = "@"
                    exSheet.Columns("C").NumberFormat = "@"
                    exSheet.Columns("E").NumberFormat = "$#,##0.00"
                    exSheet.Columns("F").NumberFormat = "$#,##0.00"
                    exSheet.Columns("G").NumberFormat = "$#,##0.00"
                End If
                If (optnotascredprov.Checked) Then
                    exSheet.Columns("A").NumberFormat = "@"
                    exSheet.Columns("B").NumberFormat = "@"
                    exSheet.Columns("C").NumberFormat = "@"
                    exSheet.Columns("D").NumberFormat = "$#,##0.00"
                    exSheet.Columns("E").NumberFormat = "$#,##0.00"
                    exSheet.Columns("F").NumberFormat = "$#,##0.00"
                End If
                If (optdevueltos.Checked) Then
                    exSheet.Columns("A").NumberFormat = "@"
                    exSheet.Columns("B").NumberFormat = "@"
                    exSheet.Columns("C").NumberFormat = "@"
                    exSheet.Columns("E").NumberFormat = "@"
                    exSheet.Columns("I").NumberFormat = "$#,##0.00"
                    exSheet.Columns("J").NumberFormat = "$#,##0.00"
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
            barcarga.Value = 0
            barcarga.Visible = False

            MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        End If
    End Sub

    Private Sub frmRepCompras_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        opttotales.PerformClick()
    End Sub

    Private Sub optconcentrado_Click(sender As Object, e As EventArgs) Handles optconcentrado.Click
        If (optconcentrado.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False
            cms1.Enabled = False

            grdcaptura.ColumnCount = 6
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Código"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
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
                    .HeaderText = "Unidad"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Cantidad"
                    .Width = 85
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Precio"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Total"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnexportar.Enabled = False
        End If
    End Sub

    Private Sub EliminarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarCompraToolStripMenuItem.Click
        Dim id_fila As Integer = grdcaptura.CurrentRow.Index
        Dim remision As String = grdcaptura.Rows(id_fila).Cells(1).Value.ToString()

        If MsgBox("¿Deseas eliminar la compra con No. de Remisión: " & remision & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                Dim id_compra As Integer = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from AbonoE where NumRemision='" & remision & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Compras where NumRemision='" & remision & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_compra = rd1("Id").ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from ComprasDet where Id_Compra=" & id_compra
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from Compras where Id=" & id_compra
                cmd1.ExecuteNonQuery()

                cnn1.Close()

                MsgBox("Registro de compra eliminado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnreporte.PerformClick()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub
End Class