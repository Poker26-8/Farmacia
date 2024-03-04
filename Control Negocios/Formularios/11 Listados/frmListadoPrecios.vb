Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports MySql.Data

Public Class frmListadoPrecios
    Dim Partes As Boolean = False
    Private Sub optproveedores_Click(sender As System.Object, e As System.EventArgs) Handles optproveedores.Click
        If (optproveedores.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = True

            If (Partes) Then
                grdcaptura.ColumnCount = 14

                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(1)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(2)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(3)
                        .HeaderText = "Producto"
                        .Width = 260
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.True
                    End With

                    With .Columns(4)
                        .HeaderText = "Unidad"
                        .Width = 50
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(5)
                        .HeaderText = "Proveedor"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(6)
                        .HeaderText = "Costo s/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(7)
                        .HeaderText = "Costo c/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(8)
                        .HeaderText = "P. Mínimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(9)
                        .HeaderText = "P. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(10)
                        .HeaderText = "P. Med. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(11)
                        .HeaderText = "P. Especial"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(12)
                        .HeaderText = "P. Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(13)
                        .HeaderText = "% de utilidad en precio de público"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 13
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(1)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(2)
                        .HeaderText = "Producto"
                        .Width = 260
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.True
                    End With

                    With .Columns(3)
                        .HeaderText = "Unidad"
                        .Width = 50
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(4)
                        .HeaderText = "Proveedor"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(5)
                        .HeaderText = "Costo s/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(6)
                        .HeaderText = "Costo c/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(7)
                        .HeaderText = "P. Mínimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(8)
                        .HeaderText = "P. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(9)
                        .HeaderText = "P. Med. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(10)
                        .HeaderText = "P. Especial"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(11)
                        .HeaderText = "P. Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(12)
                        .HeaderText = "% de utilidad en precio de público"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            End If
        End If
    End Sub

    Private Sub optdepto_Click(sender As System.Object, e As System.EventArgs) Handles optdepto.Click
        If (optdepto.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = True

            If (Partes) Then
                grdcaptura.ColumnCount = 14

                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(1)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(2)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(3)
                        .HeaderText = "Producto"
                        .Width = 260
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.True
                    End With

                    With .Columns(4)
                        .HeaderText = "Unidad"
                        .Width = 50
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(5)
                        .HeaderText = "Proveedor"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(6)
                        .HeaderText = "Costo s/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(7)
                        .HeaderText = "Costo c/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(8)
                        .HeaderText = "P. Mínimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(9)
                        .HeaderText = "P. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(10)
                        .HeaderText = "P. Med. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(11)
                        .HeaderText = "P. Especial"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(12)
                        .HeaderText = "P. Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(13)
                        .HeaderText = "% de utilidad en precio de público"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 13
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(1)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(2)
                        .HeaderText = "Producto"
                        .Width = 260
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.True
                    End With

                    With .Columns(3)
                        .HeaderText = "Unidad"
                        .Width = 50
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(4)
                        .HeaderText = "Proveedor"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(5)
                        .HeaderText = "Costo s/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(6)
                        .HeaderText = "Costo c/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(7)
                        .HeaderText = "P. Mínimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(8)
                        .HeaderText = "P. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(9)
                        .HeaderText = "P. Med. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(10)
                        .HeaderText = "P. Especial"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(11)
                        .HeaderText = "P. Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(12)
                        .HeaderText = "% de utilidad en precio de público"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                End With
            End If
        End If
    End Sub

    Private Sub optgrupo_Click(sender As System.Object, e As System.EventArgs) Handles optgrupo.Click
        If (optgrupo.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = True

            If (Partes) Then
                grdcaptura.ColumnCount = 14

                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(1)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(2)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(3)
                        .HeaderText = "Producto"
                        .Width = 260
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.True
                    End With

                    With .Columns(4)
                        .HeaderText = "Unidad"
                        .Width = 50
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(5)
                        .HeaderText = "Proveedor"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(6)
                        .HeaderText = "Costo s/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(7)
                        .HeaderText = "Costo c/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(8)
                        .HeaderText = "P. Mínimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(9)
                        .HeaderText = "P. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(10)
                        .HeaderText = "P. Med. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(11)
                        .HeaderText = "P. Especial"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(12)
                        .HeaderText = "P. Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(13)
                        .HeaderText = "% de utilidad en precio de público"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 13
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(1)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(2)
                        .HeaderText = "Producto"
                        .Width = 260
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.True
                    End With

                    With .Columns(3)
                        .HeaderText = "Unidad"
                        .Width = 50
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(4)
                        .HeaderText = "Proveedor"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(5)
                        .HeaderText = "Costo s/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(6)
                        .HeaderText = "Costo c/IVA"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(7)
                        .HeaderText = "P. Mínimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(8)
                        .HeaderText = "P. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(9)
                        .HeaderText = "P. Med. Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(10)
                        .HeaderText = "P. Especial"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(11)
                        .HeaderText = "P. Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(12)
                        .HeaderText = "% de utilidad en precio de público"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            End If
        End If
    End Sub

    Private Sub opttodos_Click(sender As System.Object, e As System.EventArgs) Handles opttodos.Click
        If (opttodos.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = False
            grdcaptura.ColumnCount = 27

            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Código"
                    .Width = 60
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Cod. Barras"
                    .Width = 120
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Producto"
                    .Width = 260
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.True
                End With

                With .Columns(3)
                    .HeaderText = "Unidad"
                    .Width = 50
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Proveedor"
                    .Width = 180
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Costo s/IVA"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Costo c/IVA"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(7)
                    .HeaderText = "P. Mínimo"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(8)
                    .HeaderText = "P. Mayoreo"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(9)
                    .HeaderText = "P. Med. Mayoreo"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(10)
                    .HeaderText = "P. Especial"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(11)
                    .HeaderText = "P. Lista"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(12)
                    .HeaderText = "% de utilidad en precio de público"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                'marcia

                'cantidadlistas
                With .Columns(13)
                    .HeaderText = "Desde_Cant_Lista"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(14)
                    .HeaderText = "Hasta_Cant_Lista"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                'minimos
                With .Columns(15)
                    .HeaderText = "% Minimo"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(16)
                    .HeaderText = "Desde_Cant_Min"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(17)
                    .HeaderText = "Hasta_Cant_Min"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                'mayoreo

                With .Columns(18)
                    .HeaderText = "% Mayoreo"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(19)
                    .HeaderText = "Desde_Cant_May"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(20)
                    .HeaderText = "Hasta_Cant_May"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                'medio mayoreo
                With .Columns(21)
                    .HeaderText = "% MedioMa"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(22)
                    .HeaderText = "Desde_Cant_MedioMa"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(23)
                    .HeaderText = "Hasta_Cant_MedioMa"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                'especial
                With .Columns(24)
                    .HeaderText = "% Esp"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(25)
                    .HeaderText = "Desde_Cant_Esp"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(26)
                    .HeaderText = "Hasta_Cant_Esp"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

            End With

            Dim codigo As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim unidad As String = ""
            Dim provee As String = ""

            Dim cost_siva As Double = 0
            Dim cost_civa As Double = 0
            Dim pre_list As Double = 0, pre_mini As Double = 0, pre_mayo As Double = 0, pre_medi As Double = 0, pre_espe As Double = 0
            Dim porcentaje As Double = 0
            Dim TiCamb As Double = 0
            Dim conteo As Double = 0
            Dim order_by As String = ""

            'marcia
            Dim desdecantlista As Double = 0
            Dim hastacanlista As Double = 0

            Dim pormin As Double = 0
            Dim desdecantmin As Double = 0
            Dim hastacantmin As Double = 0

            Dim pormay As Double = 0
            Dim desdecantmay As Double = 0
            Dim hastacantmay As Double = 0

            Dim pormedio As Double = 0
            Dim desdecantmedio As Double = 0
            Dim hastacantmedio As Double = 0

            Dim poresp As Double = 0
            Dim desdecantesp As Double = 0
            Dim hastacantesp As Double = 0


            If (optord_nombre.Checked) Then order_by = "Nombre"
            If (optord_depto.Checked) Then order_by = "Departamento"
            If (optord_grupo.Checked) Then order_by = "Grupo"

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select count(Codigo) from Productos"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        conteo = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                ProgressBar1.Value = 0
                ProgressBar1.Visible = True
                ProgressBar1.Maximum = conteo

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos order by " & order_by
                rd1 = cmd1.ExecuteReader
                cnn2.Close() : cnn2.Open()
                Do While rd1.Read
                    codigo = rd1("Codigo").ToString
                    barras = rd1("CodBarra").ToString
                    nombre = rd1("Nombre").ToString
                    unidad = rd1("UVenta").ToString
                    provee = rd1("ProvPri").ToString

                    desdecantlista = rd1("CantLst1").ToString
                    hastacanlista = rd1("CantLst2").ToString

                    pormin = rd1("PorcMin").ToString
                    desdecantmin = rd1("CantMin1").ToString
                    hastacantmin = rd1("CantMin2").ToString

                    pormay = rd1("PorcMay").ToString
                    desdecantmay = rd1("CantMay1").ToString
                    hastacantmay = rd1("CantMay2").ToString

                    pormedio = rd1("PorcMM").ToString
                    desdecantmedio = rd1("CantMM1").ToString
                    hastacantmedio = rd1("CantMM2").ToString

                    poresp = rd1("PorcEsp").ToString
                    desdecantesp = rd1("CantEsp1").ToString
                    hastacantesp = rd1("CantEsp2").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from Productos INNER JOIN tb_moneda ON Productos.id_tbMoneda=tb_moneda.id where Codigo='" & codigo & "' order by Nombre"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            TiCamb = rd2("tipo_cambio").ToString

                            cost_siva = IIf(rd2("PrecioCompra").ToString = "", 0, rd2("PrecioCompra").ToString)
                            cost_civa = CDbl(IIf(rd2("PrecioCompra").ToString = "", 0, rd2("PrecioCompra").ToString)) * (1 + CDbl(rd2("IVA").ToString))

                            pre_list = IIf(rd2("PrecioVentaIVA").ToString = "", 0, rd2("PrecioVentaIVA").ToString)
                            pre_mini = IIf(rd2("PreMin").ToString = "", 0, rd2("PreMin").ToString)
                            pre_medi = IIf(rd2("PreMM").ToString = "", 0, rd2("PreMM").ToString)
                            pre_mayo = IIf(rd2("PreMay").ToString = "", 0, rd2("PreMay").ToString)
                            pre_espe = IIf(rd2("PreEsp").ToString = "", 0, rd2("PreEsp").ToString)
                            porcentaje = IIf(rd2("Porcentaje").ToString = "", 0, rd2("Porcentaje").ToString)
                        End If
                    End If
                    rd2.Close()

                    grdcaptura.Rows.Add(codigo, barras, nombre, unidad, provee, FormatNumber(cost_siva, 2), FormatNumber(cost_civa, 2), FormatNumber(pre_mini * TiCamb, 2), FormatNumber(pre_mayo * TiCamb, 2), FormatNumber(pre_medi * TiCamb, 2), FormatNumber(pre_espe * TiCamb, 2), FormatNumber(pre_list * TiCamb, 2), FormatNumber(porcentaje, 2), desdecantlista, hastacanlista, pormin, desdecantmin, hastacantmin, pormay, desdecantmay, hastacantmay, pormedio, desdecantmedio, hastacantmedio, poresp, desdecantesp, hastacantesp)
                    ProgressBar1.Value = ProgressBar1.Value + 1
                Loop
                cnn2.Close()
                rd1.Close() : cnn1.Close()
                ProgressBar1.Value = 0
                ProgressBar1.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub frmListadoPrecios_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        optord_nombre.Checked = True
    End Sub

    Private Sub cbofiltro_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofiltro.DropDown
        cbofiltro.Items.Clear()
        grdcaptura.Rows.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If (optproveedores.Checked) Then
                cmd1.CommandText =
                    "select distinct ProvPri from Productos order by ProvPri"
            End If
            If (optdepto.Checked) Then
                cmd1.CommandText =
                    "select distinct Departamento from Productos order by Departamento"
            End If
            If (optgrupo.Checked) Then
                cmd1.CommandText =
                    "select distinct Grupo from Productos order by Grupo"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbofiltro.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofiltro_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbofiltro.SelectedValueChanged
        LlenaGrid()
    End Sub

    Public Sub LlenaGrid()
        If cbofiltro.Text = "" Then Exit Sub
        grdcaptura.Rows.Clear()

        Try
            Dim codigo As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim unidad As String = ""
            Dim provee As String = ""

            Dim cost_siva As Double = 0
            Dim cost_civa As Double = 0
            Dim pre_list As Double = 0, pre_mini As Double = 0, pre_mayo As Double = 0, pre_medi As Double = 0, pre_espe As Double = 0
            Dim porcentaje As Double = 0

            Dim TiCamb As Double = 0
            Dim conteo As Double = 0
            Dim order_by As String = ""

            If (optord_nombre.Checked) Then order_by = "Nombre"
            If (optord_depto.Checked) Then order_by = "Departamento"
            If (optord_grupo.Checked) Then order_by = "Grupo"

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If (optproveedores.Checked) Then
                cmd1.CommandText =
                    "select count(Codigo) from Productos where ProvPri='" & cbofiltro.Text & "'"
            End If
            If (optdepto.Checked) Then
                cmd1.CommandText =
                    "select count(Codigo) from Productos where Departamento='" & cbofiltro.Text & "'"
            End If
            If (optgrupo.Checked) Then
                cmd1.CommandText =
                    "select count(Codigo) from Productos where Grupo='" & cbofiltro.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    conteo = rd1(0).ToString
                End If
            End If
            rd1.Close()

            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            ProgressBar1.Maximum = conteo

            cmd1 = cnn1.CreateCommand
            If (optproveedores.Checked) Then
                cmd1.CommandText =
                    "select * from Productos where ProvPri='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            If (optdepto.Checked) Then
                cmd1.CommandText =
                    "select * from Productos where Departamento='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            If (optgrupo.Checked) Then
                cmd1.CommandText =
                    "select * from Productos where Grupo='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                codigo = rd1("Codigo").ToString
                barras = rd1("CodBarra").ToString
                nombre = rd1("Nombre").ToString
                unidad = rd1("UVenta").ToString
                provee = rd1("ProvPri").ToString

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos INNER JOIN tb_moneda ON Productos.id_tbMoneda=tb_moneda.id where Codigo='" & codigo & "' order by Nombre"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        TiCamb = rd2("tipo_cambio").ToString

                        cost_siva = IIf(rd2("PrecioCompra").ToString = "", 0, rd2("PrecioCompra").ToString)
                        cost_civa = CDbl(IIf(rd2("PrecioCompra").ToString = "", 0, rd2("PrecioCompra").ToString)) * (1 + CDbl(rd2("IVA").ToString))

                        pre_list = IIf(rd2("PrecioVentaIVA").ToString = "", 0, rd2("PrecioVentaIVA").ToString)
                        pre_mini = IIf(rd2("PreMin").ToString = "", 0, rd2("PreMin").ToString)
                        pre_medi = IIf(rd2("PreMM").ToString = "", 0, rd2("PreMM").ToString)
                        pre_mayo = IIf(rd2("PreMay").ToString = "", 0, rd2("PreMay").ToString)
                        pre_espe = IIf(rd2("PreEsp").ToString = "", 0, rd2("PreEsp").ToString)
                        porcentaje = IIf(rd2("Porcentaje").ToString = "", 0, rd2("Porcentaje").ToString)
                    End If
                End If
                rd2.Close()

                grdcaptura.Rows.Add(codigo, barras, nombre, unidad, provee, FormatNumber(cost_siva, 2), FormatNumber(cost_civa, 2), FormatNumber(pre_mini * TiCamb, 2), FormatNumber(pre_mayo * TiCamb, 2), FormatNumber(pre_medi * TiCamb, 2), FormatNumber(pre_espe * TiCamb, 2), FormatNumber(pre_list * TiCamb, 2), FormatNumber(porcentaje, 2))
                ProgressBar1.Value = ProgressBar1.Value + 1
            Loop
            cnn2.Close()
            rd1.Close() : cnn1.Close()
            ProgressBar1.Value = 0
            ProgressBar1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub optord_nombre_Click(sender As System.Object, e As System.EventArgs) Handles optord_nombre.Click
        If (optord_nombre.Checked) Then
            If (optproveedores.Checked) Or (optdepto.Checked) Or (optgrupo.Checked) Then
                LlenaGrid()
            End If
            If (opttodos.Checked) Then
                opttodos.PerformClick()
            End If
        End If
    End Sub

    Private Sub optord_depto_Click(sender As System.Object, e As System.EventArgs) Handles optord_depto.Click
        If (optord_depto.Checked) Then
            If (optproveedores.Checked) Or (optdepto.Checked) Or (optgrupo.Checked) Then
                LlenaGrid()
            End If
            If (opttodos.Checked) Then
                opttodos.PerformClick()
            End If
        End If
    End Sub

    Private Sub optord_grupo_Click(sender As System.Object, e As System.EventArgs) Handles optord_grupo.Click
        If (optord_grupo.Checked) Then
            If (optproveedores.Checked) Or (optdepto.Checked) Or (optgrupo.Checked) Then
                LlenaGrid()
            End If
            If (opttodos.Checked) Then
                opttodos.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnexportar_Click(sender As System.Object, e As System.EventArgs) Handles btnexportar.Click
        If grdcaptura.Rows.Count = 0 Then MsgBox("Genera el reporte para poder exportar los datos a Excel.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
        If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim exApp As New Excel.Application
            Dim exBook As Excel.Workbook
            Dim exSheet As Excel.Worksheet

            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Worksheets.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("B").NumberFormat = "@"
                exSheet.Columns("F").NumberFormat = "$#,##0.00"
                exSheet.Columns("G").NumberFormat = "$#,##0.00"
                exSheet.Columns("H").NumberFormat = "$#,##0.00"
                exSheet.Columns("I").NumberFormat = "$#,##0.00"
                exSheet.Columns("J").NumberFormat = "$#,##0.00"
                exSheet.Columns("K").NumberFormat = "$#,##0.00"
                exSheet.Columns("L").NumberFormat = "$#,##0.00"
                exSheet.Columns("M").NumberFormat = "#,##0"

                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value
                    Next

                    ProgressBar1.Value = ProgressBar1.Value + 1
                    lblprod.Text = "Registros exportados: " & ProgressBar1.Value
                    My.Application.DoEvents()
                Next

                exSheet.Rows.Item(1).Font.Bold = 1
                exSheet.Rows.Item(1).HorizontalAlignment = 3
                exSheet.Columns.AutoFit()

                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing

                MsgBox("Datos exportados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub txtCod_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCod.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCod.Text = "" Then
                Exit Sub
            End If

            Dim Zi As Integer = 0
            Do
                If Zi - grdcaptura.Rows.Count = 45 * Math.Sin(0) Then Exit Do
                If InStr(1, grdcaptura.Rows(Zi).Cells(0).Value.ToString, LCase(txtCod.Text)) > 0 Then
                    If grdcaptura.Rows.Count = Math.Cos(0) + 1 Then Exit Do
                    grdcaptura.Rows.Remove(grdcaptura.Rows(Zi))
                    Zi -= 1
                End If
                Zi += 1
            Loop
        End If
    End Sub

    Private Sub btnimportar_Click(sender As System.Object, e As System.EventArgs) Handles btnimportar.Click
        Dim con As OleDb.OleDbConnection
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim file_dialog As New OpenFileDialog
        Dim ruta As String = ""
        Dim sheet As String = ""

        With file_dialog
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx"
            .Title = "Selecciona el archivo a importar"
            .Multiselect = False
            .InitialDirectory = Replace(My.Application.Info.DirectoryPath, "\Reportes", "")
            .ShowDialog()
        End With
        If file_dialog.FileName.ToString <> "" Then
            ruta = file_dialog.FileName.ToString

            con = New OleDb.OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" &
                " Data Source='" & ruta & "'; " &
                "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                sheet = "hoja1"
                da = New OleDbDataAdapter("select * from [" & sheet & "$]", con)

                con.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                grdimporta.DataSource = ds
                grdimporta.DataMember = "MyData"
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                con.Close()
            End Try
            My.Application.DoEvents()

            Dim codigo As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim pre_compra As Double = 0
            Dim pre_minimo As Double = 0
            Dim pre_mediom As Double = 0
            Dim pre_mayore As Double = 0
            Dim pre_especi As Double = 0
            Dim pre_lista As Double = 0

            Dim por_list As Double = 0
            Dim por_mini As Double = 0
            Dim por_medi As Double = 0
            Dim por_mayo As Double = 0
            Dim por_espe As Double = 0

            Dim IVA As Double = 0
            Dim porcentaje As Double = 0

            'marcia

            Dim desdecantlista As Double = 0
            Dim hastacantlista As Double = 0

            Dim porminimo As Double = 0
            Dim desdecantmin As Double = 0
            Dim hastacantmin As Double = 0

            Dim pormay As Double = 0
            Dim desdecantmay As Double = 0
            Dim hastacantmay As Double = 0

            Dim pormedio As Double = 0
            Dim desdecantmedio As Double = 0
            Dim hastacantmedio As Double = 0

            Dim poresp As Double = 0
            Dim desdecantesp As Double = 0
            Dim hastacantesp As Double = 0

            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            ProgressBar1.Maximum = grdimporta.Rows.Count

            lblprod.Visible = True
            lblprod.Text = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            For X As Integer = 0 To grdimporta.Rows.Count - 1
                If (grdimporta.Rows.Count - 1) = 0 Then
                    MsgBox("No se encuentra la 'Hoja1' en el archivo de excel seleccionado." & vbNewLine & "Escriba el nombre de la hoja donde se encuentran los datos e inténtelo de nuevo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close() : Exit Sub
                End If
                codigo = Convert.ToString(grdimporta.Rows.Item(X).Cells(0).Value)
                barras = Convert.ToString(grdimporta.Rows.Item(X).Cells(1).Value)
                nombre = Convert.ToString(grdimporta.Rows.Item(X).Cells(2).Value)
                If codigo = "" Then Exit For
                pre_compra = Convert.ToString(grdimporta.Rows.Item(X).Cells(5).Value)
                pre_minimo = Convert.ToString(grdimporta.Rows.Item(X).Cells(7).Value)
                pre_mayore = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(8).Value)
                pre_mediom = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(9).Value)
                pre_especi = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(10).Value)
                pre_lista = Convert.ToString(grdimporta.Rows.Item(X).Cells(11).Value)
                porcentaje = Convert.ToString(grdimporta.Rows.Item(X).Cells(12).Value)

                desdecantlista = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(13).Value)
                hastacantlista = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(14).Value)

                porminimo = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(15).Value)
                desdecantmin = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(16).Value)
                hastacantmin = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(17).Value)

                pormay = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(18).Value)
                desdecantmay = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(19).Value)
                hastacantmay = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(20).Value)

                pormedio = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(21).Value)
                desdecantmedio = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(22).Value)
                hastacantmedio = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(23).Value)

                poresp = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(24).Value)
                desdecantesp = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(25).Value)
                hastacantesp = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(26).Value)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & codigo & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        IVA = rd1("IVA").ToString
                        lblprod.Text = "Importando producto: " & nombre
                        My.Application.DoEvents()

                        If pre_compra <> 0 Then
                            por_list = ((pre_lista * 100) / pre_compra) - 100
                            If por_list < 0 Then por_list = 0

                            por_mini = ((pre_minimo * 100) / pre_compra) - 100
                            If por_mini < 0 Then por_mini = 0

                            por_medi = ((pre_mediom * 100) / pre_compra) - 100
                            If por_medi < 0 Then por_medi = 0

                            por_mayo = ((pre_mayore * 100) / pre_compra) - 100
                            If por_mayo < 0 Then por_mayo = 0

                            por_espe = ((pre_especi * 100) / pre_compra) - 100
                            If por_espe < 0 Then por_espe = 0
                        Else
                            por_list = 0
                            por_mini = 0
                            por_medi = 0
                            por_mayo = 0
                            por_espe = 0
                        End If

                        Dim pre_lista_siva As Double = pre_lista / (1 + IVA)

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Productos set PrecioCompra=" & pre_compra & ", Porcentaje=" & por_list & ", PrecioVenta=" & pre_lista_siva & ", PrecioventaIVA=" & pre_lista & ", PorcMin=" & por_mini & ", PreMin=" & pre_minimo & ", PorcMM=" & por_medi & ", PreMM=" & pre_mediom & ", PorcMay=" & por_mayo & ", PreMay=" & pre_mayore & ", PorcEsp=" & por_espe & ", PreEsp=" & pre_especi & ", Almacen3=" & pre_compra & ",Porcentaje=" & porcentaje & ",CantLst1=" & desdecantlista & ", CantLst2=" & hastacantlista & ",PorcMin=" & porminimo & ",CantMin1=" & desdecantmin & ",CantMin2=" & hastacantmin & ",PorcMay=" & pormay & ",CantMay1=" & desdecantmay & ",CantMay2=" & hastacantmay & ",PorcMM=" & pormedio & ",CantMM1=" & desdecantmedio & ",CantMM2=" & hastacantmedio & ",PorcEsp=" & poresp & ",CantEsp1=" & desdecantesp & ",CantEsp2=" & hastacantesp & "  where Codigo='" & codigo & "'"
                        If cmd2.ExecuteNonQuery Then
                        Else
                            MsgBox("No se pudieron actualizar los precios del producto " & nombre, vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                        ProgressBar1.Value = ProgressBar1.Value + 1
                        My.Application.DoEvents()
                    End If
                Else
                    MsgBox("No se puede localizar el código " & codigo & " ubicado en las fila " & X & ".")
                    rd1.Close()
                    Continue For
                End If
                rd1.Close()
            Next
            cnn1.Close() : cnn2.Close()
            MsgBox("Datos importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            grdimporta.Rows.Clear()
            lblprod.Text = ""
            lblprod.Visible = False
            ProgressBar1.Visible = False
            ProgressBar1.Value = 0
        End If
    End Sub

    Private Sub frmListadoPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Partes'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = 1 Then
                        Partes = True
                    Else
                        Partes = False
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub


End Class
