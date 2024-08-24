Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class frmListadoPrecios
    Dim Partes As Boolean = False
    Private Sub optproveedores_Click(sender As System.Object, e As System.EventArgs) Handles optproveedores.Click
        If (optproveedores.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = True

            If (Partes) Then
                grdcaptura.ColumnCount = 48

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
                        .HeaderText = "% precio de público"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'marcia

                    'cantidadlistas
                    With .Columns(14)
                        .HeaderText = "Desde_Cant_Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(15)
                        .HeaderText = "Hasta_Cant_Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'minimos
                    With .Columns(16)
                        .HeaderText = "% Minimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(17)
                        .HeaderText = "Desde_Cant_Min"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(18)
                        .HeaderText = "Hasta_Cant_Min"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'mayoreo

                    With .Columns(19)
                        .HeaderText = "% Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(20)
                        .HeaderText = "Desde_Cant_May"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(21)
                        .HeaderText = "Hasta_Cant_May"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'medio mayoreo
                    With .Columns(22)
                        .HeaderText = "% MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(23)
                        .HeaderText = "Desde_Cant_MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(24)
                        .HeaderText = "Hasta_Cant_MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'especial
                    With .Columns(25)
                        .HeaderText = "% Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(26)
                        .HeaderText = "Desde_Cant_Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(27)
                        .HeaderText = "Hasta_Cant_Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    'OTROS PRECIOS
                    With .Columns(28)
                        .HeaderText = "% Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(29)
                        .HeaderText = "Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(30)
                        .HeaderText = "Cant Lista3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(31)
                        .HeaderText = "Cant Lista4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(32)
                        .HeaderText = "% Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(33)
                        .HeaderText = "Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(34)
                        .HeaderText = "Cant Min3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(35)
                        .HeaderText = "Cant Min4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(36)
                        .HeaderText = "% Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(37)
                        .HeaderText = "Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(38)
                        .HeaderText = "Cant May3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(39)
                        .HeaderText = "Cant May4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(40)
                        .HeaderText = "% Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(41)
                        .HeaderText = "Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(42)
                        .HeaderText = "Cant MM3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(43)
                        .HeaderText = "Cant MM4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(44)
                        .HeaderText = "% Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(45)
                        .HeaderText = "Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(46)
                        .HeaderText = "Cant Esp3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(47)
                        .HeaderText = "Cant Esp4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                End With


            Else
                grdcaptura.ColumnCount = 47
                With grdcaptura
                    With .Columns(0)
                        .HeaderText = "Código"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(1)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(2)
                        .HeaderText = "Producto"
                        .Width = 260
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.True
                    End With

                    With .Columns(3)
                        .HeaderText = "Unidad"
                        .Width = 50
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(4)
                        .HeaderText = "Proveedor"
                        .Width = 180
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
                        .HeaderText = "% precio de público"
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
                    'OTROS PRECIOS
                    With .Columns(27)
                        .HeaderText = "% Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(28)
                        .HeaderText = "Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(29)
                        .HeaderText = "Cant Lista3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(30)
                        .HeaderText = "Cant Lista4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(31)
                        .HeaderText = "% Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(32)
                        .HeaderText = "Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(33)
                        .HeaderText = "Cant Min3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(34)
                        .HeaderText = "Cant Min4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(35)
                        .HeaderText = "% Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(36)
                        .HeaderText = "Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(37)
                        .HeaderText = "Cant May3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(38)
                        .HeaderText = "Cant May4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(39)
                        .HeaderText = "% Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(40)
                        .HeaderText = "Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(41)
                        .HeaderText = "Cant MM3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(42)
                        .HeaderText = "Cant MM4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(43)
                        .HeaderText = "% Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(44)
                        .HeaderText = "Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(45)
                        .HeaderText = "Cant Esp3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(46)
                        .HeaderText = "Cant Esp4"
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
                grdcaptura.ColumnCount = 48

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

                    'marcia

                    'cantidadlistas
                    With .Columns(14)
                        .HeaderText = "Desde_Cant_Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(15)
                        .HeaderText = "Hasta_Cant_Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'minimos
                    With .Columns(16)
                        .HeaderText = "% Minimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(17)
                        .HeaderText = "Desde_Cant_Min"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(18)
                        .HeaderText = "Hasta_Cant_Min"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'mayoreo

                    With .Columns(19)
                        .HeaderText = "% Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(20)
                        .HeaderText = "Desde_Cant_May"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(21)
                        .HeaderText = "Hasta_Cant_May"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'medio mayoreo
                    With .Columns(22)
                        .HeaderText = "% MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(23)
                        .HeaderText = "Desde_Cant_MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(24)
                        .HeaderText = "Hasta_Cant_MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'especial
                    With .Columns(25)
                        .HeaderText = "% Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(26)
                        .HeaderText = "Desde_Cant_Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(27)
                        .HeaderText = "Hasta_Cant_Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    'OTROS PRECIOS
                    With .Columns(28)
                        .HeaderText = "% Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(29)
                        .HeaderText = "Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(30)
                        .HeaderText = "Cant Lista3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(31)
                        .HeaderText = "Cant Lista4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(32)
                        .HeaderText = "% Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(33)
                        .HeaderText = "Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(34)
                        .HeaderText = "Cant Min3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(35)
                        .HeaderText = "Cant Min4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(36)
                        .HeaderText = "% Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(37)
                        .HeaderText = "Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(38)
                        .HeaderText = "Cant May3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(39)
                        .HeaderText = "Cant May4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(40)
                        .HeaderText = "% Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(41)
                        .HeaderText = "Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(42)
                        .HeaderText = "Cant MM3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(43)
                        .HeaderText = "Cant MM4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(44)
                        .HeaderText = "% Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(45)
                        .HeaderText = "Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(46)
                        .HeaderText = "Cant Esp3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(47)
                        .HeaderText = "Cant Esp4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                End With
            Else
                grdcaptura.ColumnCount = 47
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

                    'OTROS PRECIOS
                    With .Columns(27)
                        .HeaderText = "% Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(28)
                        .HeaderText = "Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(29)
                        .HeaderText = "Cant Lista3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(30)
                        .HeaderText = "Cant Lista4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(31)
                        .HeaderText = "% Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(32)
                        .HeaderText = "Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(33)
                        .HeaderText = "Cant Min3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(34)
                        .HeaderText = "Cant Min4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(35)
                        .HeaderText = "% Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(36)
                        .HeaderText = "Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(37)
                        .HeaderText = "Cant May3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(38)
                        .HeaderText = "Cant May4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(39)
                        .HeaderText = "% Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(40)
                        .HeaderText = "Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(41)
                        .HeaderText = "Cant MM3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(42)
                        .HeaderText = "Cant MM4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(43)
                        .HeaderText = "% Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(44)
                        .HeaderText = "Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(45)
                        .HeaderText = "Cant Esp3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(46)
                        .HeaderText = "Cant Esp4"
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
                grdcaptura.ColumnCount = 48

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

                    'marcia

                    'cantidadlistas
                    With .Columns(14)
                        .HeaderText = "Desde_Cant_Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(15)
                        .HeaderText = "Hasta_Cant_Lista"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'minimos
                    With .Columns(16)
                        .HeaderText = "% Minimo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(17)
                        .HeaderText = "Desde_Cant_Min"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(18)
                        .HeaderText = "Hasta_Cant_Min"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'mayoreo

                    With .Columns(19)
                        .HeaderText = "% Mayoreo"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(20)
                        .HeaderText = "Desde_Cant_May"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(21)
                        .HeaderText = "Hasta_Cant_May"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'medio mayoreo
                    With .Columns(22)
                        .HeaderText = "% MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(23)
                        .HeaderText = "Desde_Cant_MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(24)
                        .HeaderText = "Hasta_Cant_MedioMa"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    'especial
                    With .Columns(25)
                        .HeaderText = "% Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(26)
                        .HeaderText = "Desde_Cant_Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(27)
                        .HeaderText = "Hasta_Cant_Esp"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    'OTROS PRECIOS
                    With .Columns(28)
                        .HeaderText = "% Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(29)
                        .HeaderText = "Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(30)
                        .HeaderText = "Cant Lista3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(31)
                        .HeaderText = "Cant Lista4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(32)
                        .HeaderText = "% Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(33)
                        .HeaderText = "Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(34)
                        .HeaderText = "Cant Min3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(35)
                        .HeaderText = "Cant Min4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(36)
                        .HeaderText = "% Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(37)
                        .HeaderText = "Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(38)
                        .HeaderText = "Cant May3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(39)
                        .HeaderText = "Cant May4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(40)
                        .HeaderText = "% Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(41)
                        .HeaderText = "Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(42)
                        .HeaderText = "Cant MM3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(43)
                        .HeaderText = "Cant MM4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(44)
                        .HeaderText = "% Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(45)
                        .HeaderText = "Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(46)
                        .HeaderText = "Cant Esp3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(47)
                        .HeaderText = "Cant Esp4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdcaptura.ColumnCount = 47
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

                    'OTROS PRECIOS
                    With .Columns(27)
                        .HeaderText = "% Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(28)
                        .HeaderText = "Pre.Lista2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(29)
                        .HeaderText = "Cant Lista3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(30)
                        .HeaderText = "Cant Lista4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(31)
                        .HeaderText = "% Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(32)
                        .HeaderText = "Pre.Min2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(33)
                        .HeaderText = "Cant Min3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(34)
                        .HeaderText = "Cant Min4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(35)
                        .HeaderText = "% Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(36)
                        .HeaderText = "Pre.May2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(37)
                        .HeaderText = "Cant May3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(38)
                        .HeaderText = "Cant May4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(39)
                        .HeaderText = "% Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(40)
                        .HeaderText = "Pre.MM2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(41)
                        .HeaderText = "Cant MM3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(42)
                        .HeaderText = "Cant MM4"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With


                    With .Columns(43)
                        .HeaderText = "% Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(44)
                        .HeaderText = "Pre.Esp2"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(45)
                        .HeaderText = "Cant Esp3"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(46)
                        .HeaderText = "Cant Esp4"
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

            Dim cnn100 As MySqlConnection = New MySqlConnection()
            cnn100 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300")


            Dim cmd100 As MySqlCommand
            Dim rd100 As MySqlDataReader




            Dim cnn200 As MySqlConnection = New MySqlConnection()

            cnn200 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300")
            Dim cmd200 As MySqlCommand
            Dim rd200 As MySqlDataReader


            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = False
            grdcaptura.ColumnCount = 47

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

                'OTROS PRECIOS
                With .Columns(27)
                    .HeaderText = "% Pre.Lista2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(28)
                    .HeaderText = "Pre.Lista2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(29)
                    .HeaderText = "Cant Lista3"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(30)
                    .HeaderText = "Cant Lista4"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With


                With .Columns(31)
                    .HeaderText = "% Pre.Min2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(32)
                    .HeaderText = "Pre.Min2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(33)
                    .HeaderText = "Cant Min3"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(34)
                    .HeaderText = "Cant Min4"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With


                With .Columns(35)
                    .HeaderText = "% Pre.May2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(36)
                    .HeaderText = "Pre.May2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(37)
                    .HeaderText = "Cant May3"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(38)
                    .HeaderText = "Cant May4"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With


                With .Columns(39)
                    .HeaderText = "% Pre.MM2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(40)
                    .HeaderText = "Pre.MM2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(41)
                    .HeaderText = "Cant MM3"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(42)
                    .HeaderText = "Cant MM4"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With


                With .Columns(43)
                    .HeaderText = "% Pre.Esp2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(44)
                    .HeaderText = "Pre.Esp2"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(45)
                    .HeaderText = "Cant Esp3"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(46)
                    .HeaderText = "Cant Esp4"
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

            'demas precios
            Dim porcentaje2 As Double = 0
            Dim preciolista2 As Double = 0
            Dim cantlista3 As Double = 0
            Dim cantlista4 As Double = 0

            Dim porcentajemin2 As Double = 0
            Dim preciomin2 As Double = 0
            Dim cantmin3 As Double = 0
            Dim cantmin4 As Double = 0

            Dim porcentajemay2 As Double = 0
            Dim preciomay2 As Double = 0
            Dim cantmay3 As Double = 0
            Dim cantmay4 As Double = 0

            Dim porcentajemedio2 As Double = 0
            Dim preciomedio2 As Double = 0
            Dim cantmedio3 As Double = 0
            Dim cantmedio4 As Double = 0

            Dim porcentajeesp2 As Double = 0
            Dim precioesp2 As Double = 0
            Dim cantesp3 As Double = 0
            Dim cantesp4 As Double = 0

            If (optord_nombre.Checked) Then order_by = "Nombre"
            If (optord_depto.Checked) Then order_by = "Departamento"
            If (optord_grupo.Checked) Then order_by = "Grupo"

            Try
                cnn100.Close() : cnn100.Open()

                cmd100 = cnn100.CreateCommand
                cmd100.CommandText =
                    "select count(Codigo) from Productos"
                rd100 = cmd100.ExecuteReader
                If rd100.HasRows Then
                    If rd100.Read Then
                        conteo = rd100(0).ToString
                    End If
                End If
                rd100.Close()

                ProgressBar1.Value = 0
                ProgressBar1.Visible = True
                ProgressBar1.Maximum = conteo

                cmd100 = cnn100.CreateCommand
                cmd100.CommandText =
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,CantLst1,CantLst2,PorcMin,CantMin1,CantMin2,PorcMay,CantMay1,CantMay2,PorcMM,CantMM1,CantMM2,PorcEsp,CantEsp1,CantEsp2,CantLst3,CantLst4,CantMin3,CantMin4,CantMay3,CantMay4,CantMM3,CantMM4,CantEsp3,CantEsp4 from Productos order by " & order_by
                rd100 = cmd100.ExecuteReader
                ' cnn200.Close() : cnn200.Open()
                Do While rd100.Read

                    codigo = rd100("Codigo").ToString
                    barras = rd100("CodBarra").ToString
                    nombre = rd100("Nombre").ToString
                    unidad = rd100("UVenta").ToString
                    provee = rd100("ProvPri").ToString

                    desdecantlista = rd100("CantLst1").ToString
                    hastacanlista = rd100("CantLst2").ToString

                    pormin = rd100("PorcMin").ToString
                    desdecantmin = rd100("CantMin1").ToString
                    hastacantmin = rd100("CantMin2").ToString

                    pormay = rd100("PorcMay").ToString
                    desdecantmay = rd100("CantMay1").ToString
                    hastacantmay = rd100("CantMay2").ToString

                    pormedio = rd100("PorcMM").ToString
                    desdecantmedio = rd100("CantMM1").ToString
                    hastacantmedio = rd100("CantMM2").ToString

                    poresp = rd100("PorcEsp").ToString
                    desdecantesp = rd100("CantEsp1").ToString
                    hastacantesp = rd100("CantEsp2").ToString

                    cantlista3 = rd100("CantLst3").ToString
                    cantlista4 = rd100("CantLst4").ToString

                    cantmin3 = rd100("CantMin3").ToString
                    cantmin4 = rd100("CantMin4").ToString

                    cantmay3 = rd100("CantMay3").ToString
                    cantmay4 = rd100("CantMay4").ToString

                    cantmedio3 = rd100("CantMM3").ToString
                    cantmedio4 = rd100("CantMM4").ToString

                    cantesp3 = rd100("CantEsp3").ToString
                    cantesp4 = rd100("CantEsp4").ToString

                    cnn200.Close() : cnn200.Open()
                    cmd200 = cnn200.CreateCommand
                    cmd200.CommandText =
                        "select tipo_cambio,PrecioCompra,IVA,PrecioVentaIVA,PreMin,PreMM,PreMay,PreEsp,Porcentaje,Porcentaje2,PrecioVentaIVA2,PorcMin2,PreMin2,PorcMay2,PreMay2,PorcMM2,PreMM2,PorcEsp2,PreEsp2 from Productos p INNER JOIN tb_moneda tm ON p.id_tbMoneda=tm.id where Codigo='" & codigo & "' order by Nombre"
                    rd200 = cmd200.ExecuteReader
                    If rd200.HasRows Then
                        If rd200.Read Then
                            TiCamb = rd200("tipo_cambio").ToString

                            cost_siva = IIf(rd200("PrecioCompra").ToString = "", 0, rd200("PrecioCompra").ToString)
                            cost_civa = CDbl(IIf(rd200("PrecioCompra").ToString = "", 0, rd200("PrecioCompra").ToString)) * (1 + CDbl(rd200("IVA").ToString))

                            pre_list = IIf(rd200("PrecioVentaIVA").ToString = "", 0, rd200("PrecioVentaIVA").ToString)
                            pre_mini = IIf(rd200("PreMin").ToString = "", 0, rd200("PreMin").ToString)
                            pre_medi = IIf(rd200("PreMM").ToString = "", 0, rd200("PreMM").ToString)
                            pre_mayo = IIf(rd200("PreMay").ToString = "", 0, rd200("PreMay").ToString)
                            pre_espe = IIf(rd200("PreEsp").ToString = "", 0, rd200("PreEsp").ToString)
                            porcentaje = IIf(rd200("Porcentaje").ToString = "", 0, rd200("Porcentaje").ToString)

                            porcentaje2 = IIf(rd200("Porcentaje2").ToString = "", 0, rd200("Porcentaje2").ToString)
                            preciolista2 = IIf(rd200("PrecioVentaIVA2").ToString = "", 0, rd200("PrecioVentaIVA2").ToString)

                            porcentajemin2 = IIf(rd200("PorcMin2").ToString = "", 0, rd200("PorcMin2").ToString)
                            preciomin2 = IIf(rd200("PreMin2").ToString = "", 0, rd200("PreMin2").ToString)

                            porcentajemay2 = IIf(rd200("PorcMay2").ToString = "", 0, rd200("PorcMay2").ToString)
                            preciomay2 = IIf(rd200("PreMay2").ToString = "", 0, rd200("PreMay2").ToString)

                            porcentajemedio2 = IIf(rd200("PorcMM2").ToString = "", 0, rd200("PorcMM2").ToString)
                            preciomedio2 = IIf(rd200("PreMM2").ToString = "", 0, rd200("PreMM2").ToString)

                            porcentajeesp2 = IIf(rd200("PorcEsp2").ToString = "", 0, rd200("PorcEsp2").ToString)
                            precioesp2 = IIf(rd200("PreEsp2").ToString = "", 0, rd200("PreEsp2").ToString)
                        End If
                    End If
                    rd200.Close()

                    grdcaptura.Rows.Add(codigo, barras, nombre, unidad, provee, FormatNumber(cost_siva, 2), FormatNumber(cost_civa, 2), FormatNumber(pre_mini * TiCamb, 2), FormatNumber(pre_mayo * TiCamb, 2), FormatNumber(pre_medi * TiCamb, 2), FormatNumber(pre_espe * TiCamb, 2), FormatNumber(pre_list * TiCamb, 2), FormatNumber(porcentaje, 2), desdecantlista, hastacanlista, pormin, desdecantmin, hastacantmin, pormay, desdecantmay, hastacantmay, pormedio, desdecantmedio, hastacantmedio, poresp, desdecantesp, hastacantesp, porcentaje2, preciolista2, cantlista3, cantlista4, porcentajemin2, preciomin2, cantmin3, cantmin4, porcentajemay2, preciomay2, cantmay3, cantmay4, porcentajemedio2, preciomedio2, cantmedio3, cantmedio4, porcentajeesp2, precioesp2, cantesp3, cantesp4)
                    ProgressBar1.Value = ProgressBar1.Value + 1
                Loop
                cnn200.Close()
                rd100.Close() : cnn100.Close()
                ProgressBar1.Value = 0
                ProgressBar1.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn100.Close()
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

            Dim cantlista As Double = 0
            Dim canlista2 As Double = 0
            Dim porcentajemin As Double = 0
            Dim canmin As Double = 0
            Dim canmin2 As Double = 0
            Dim porcentajemay As Double = 0
            Dim canmay As Double = 0
            Dim canmay2 As Double = 0
            Dim porcentajemed As Double = 0
            Dim cantmed As Double = 0
            Dim cantmed2 As Double = 0
            Dim porcentajeesp As Double = 0
            Dim cantesp As Double = 0
            Dim cantesp2 As Double = 0

            Dim PORCENTAJE2 As Double = 0
            Dim PRELISTA2 As Double = 0
            Dim CANTLISTA3 As Double = 0
            Dim CANTLISTA4 As Double = 0

            Dim PORMIN2 As Double = 0
            Dim PREMIN2 As Double = 0
            Dim CANMIN3 As Double = 0
            Dim CANMIN4 As Double = 0

            Dim PORMAY2 As Double = 0
            Dim PREMAY2 As Double = 0
            Dim CANTMAY3 As Double = 0
            Dim CANTMAY4 As Double = 0

            Dim PORMM2 As Double = 0
            Dim PREMM2 As Double = 0
            Dim CANTMM3 As Double = 0
            Dim CANTMM4 As Double = 0

            Dim PORESP2 As Double = 0
            Dim PREESP2 As Double = 0
            Dim CANTESP3 As Double = 0
            Dim CANTESP4 As Double = 0

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
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,CantLst1,CantLst2,PorcMin,CantMin1,CantMin2,PorcMay,CantMay1,CantMay2,PorcMM,CantMM1,CantMM2,PorcEsp,CantEsp1,CantEsp2,CantLst3,CantLst4,CantMin3,CantMin4,CantMay3,CantMay4,CantMM3,CantMM4,CantEsp3,CantEsp4 from Productos where ProvPri='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            If (optdepto.Checked) Then
                cmd1.CommandText =
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,CantLst1,CantLst2,PorcMin,CantMin1,CantMin2,PorcMay,CantMay1,CantMay2,PorcMM,CantMM1,CantMM2,PorcEsp,CantEsp1,CantEsp2,CantLst3,CantLst4,CantMin3,CantMin4,CantMay3,CantMay4,CantMM3,CantMM4,CantEsp3,CantEsp4 from Productos where Departamento='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            If (optgrupo.Checked) Then
                cmd1.CommandText =
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,CantLst1,CantLst2,PorcMin,CantMin1,CantMin2,PorcMay,CantMay1,CantMay2,PorcMM,CantMM1,CantMM2,PorcEsp,CantEsp1,CantEsp2,CantLst3,CantLst4,CantMin3,CantMin4,CantMay3,CantMay4,CantMM3,CantMM4,CantEsp3,CantEsp4 from Productos where Grupo='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                codigo = rd1("Codigo").ToString
                barras = rd1("CodBarra").ToString
                nombre = rd1("Nombre").ToString
                unidad = rd1("UVenta").ToString
                provee = rd1("ProvPri").ToString

                cantlista = rd1("CantLst1").ToString
                canlista2 = rd1("CantLst2").ToString
                porcentajemin = rd1("PorcMin").ToString
                canmin = rd1("CantMin1").ToString
                canmin2 = rd1("CantMin2").ToString
                porcentajemay = rd1("PorcMay").ToString
                canmay = rd1("CantMay1").ToString
                canmay2 = rd1("CantMay2").ToString
                porcentajemed = rd1("PorcMM").ToString
                cantmed = rd1("CantMM1").ToString
                cantmed2 = rd1("CantMM2").ToString
                porcentajeesp = rd1("PorcEsp").ToString
                cantesp = rd1("CantEsp1").ToString
                cantesp2 = rd1("CantEsp2").ToString

                CANTLISTA3 = IIf(rd1("CantLst3").ToString = "", 0, rd1("CantLst3").ToString)
                CANTLISTA4 = IIf(rd1("CantLst4").ToString = "", 0, rd1("CantLst4").ToString)


                CANMIN3 = IIf(rd1("CantMin3").ToString = "", 0, rd1("CantMin3").ToString)
                CANMIN4 = IIf(rd1("CantMin4").ToString = "", 0, rd1("CantMin4").ToString)

                CANTMAY3 = IIf(rd1("CantMay3").ToString = "", 0, rd1("CantMay3").ToString)
                CANTMAY4 = IIf(rd1("CantMay4").ToString = "", 0, rd1("CantMay4").ToString)

                CANTMM3 = IIf(rd1("CantMM3").ToString = "", 0, rd1("CantMM3").ToString)
                CANTMM4 = IIf(rd1("CantMM4").ToString = "", 0, rd1("CantMM4").ToString)

                CANTESP3 = IIf(rd1("CantEsp3").ToString = "", 0, rd1("CantEsp3").ToString)
                CANTESP4 = IIf(rd1("CantEsp4").ToString = "", 0, rd1("CantEsp4").ToString)

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select tipo_cambio,PrecioCompra,IVA,PrecioVentaIVA,PreMin,PreMM,PreMay,PreEsp,Porcentaje,Porcentaje2,PrecioVentaIVA2,PorcMin2,PreMin2,PorcMay2,PreMay2,PorcMM2,PreMM2,PorcEsp2,PreEsp2 from Productos INNER JOIN tb_moneda ON Productos.id_tbMoneda=tb_moneda.id where Codigo='" & codigo & "' order by Nombre"
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

                        PORCENTAJE2 = IIf(rd2("Porcentaje2").ToString = "", 0, rd2("Porcentaje2").ToString)
                        PRELISTA2 = IIf(rd2("PrecioVentaIVA2").ToString = "", 0, rd2("PrecioVentaIVA2").ToString)

                        PORMIN2 = IIf(rd2("PorcMin2").ToString = "", 0, rd2("PorcMin2").ToString)
                        PREMIN2 = IIf(rd2("PreMin2").ToString = "", 0, rd2("PreMin2").ToString)

                        PORMAY2 = IIf(rd2("PorcMay2").ToString = "", 0, rd2("PorcMay2").ToString)
                        PREMAY2 = IIf(rd2("PreMay2").ToString = "", 0, rd2("PreMay2").ToString)

                        PORMM2 = IIf(rd2("PorcMM2").ToString = "", 0, rd2("PorcMM2").ToString)
                        PREMM2 = IIf(rd2("PreMM2").ToString = "", 0, rd2("PreMM2").ToString)

                        PORESP2 = IIf(rd2("PorcEsp2").ToString = "", 0, rd2("PorcEsp2").ToString)
                        PREESP2 = IIf(rd2("PreEsp2").ToString = "", 0, rd2("PreEsp2").ToString)
                    End If
                End If
                rd2.Close()

                PORMIN2 = FormatNumber(PORMIN2, 2)
                PREMIN2 = FormatNumber(PREMIN2, 2)
                CANMIN3 = FormatNumber(CANMIN3, 2)
                CANMIN4 = FormatNumber(CANMIN4, 2)

                PORMAY2 = FormatNumber(PORMAY2, 2)
                PREMAY2 = FormatNumber(PREMAY2, 2)
                CANTMAY3 = FormatNumber(CANTMAY3, 2)
                CANTMAY4 = FormatNumber(CANTMAY4, 2)

                PORMM2 = FormatNumber(PORMM2, 2)
                PREMM2 = FormatNumber(PREMM2, 2)
                CANTMM3 = FormatNumber(CANTMM3, 2)
                CANTMM4 = FormatNumber(CANTMM4, 2)

                PORESP2 = FormatNumber(PORESP2, 2)
                PREESP2 = FormatNumber(PREESP2, 2)
                CANTESP3 = FormatNumber(cantesp2, 2)
                CANTESP4 = FormatNumber(CANTESP4, 2)

                grdcaptura.Rows.Add(codigo, barras, nombre, unidad, provee, FormatNumber(cost_siva, 2), FormatNumber(cost_civa, 2), FormatNumber(pre_mini * TiCamb, 2), FormatNumber(pre_mayo * TiCamb, 2), FormatNumber(pre_medi * TiCamb, 2), FormatNumber(pre_espe * TiCamb, 2), FormatNumber(pre_list * TiCamb, 2), FormatNumber(porcentaje, 2), cantlista, canlista2, porcentajemin, canmin, canmin2, porcentajemay, canmay, canmay2, porcentajemed, cantmed, cantmed2, porcentajeesp, cantesp, cantesp2, FormatNumber(PORCENTAJE2, 2), FormatNumber(PRELISTA2, 2), FormatNumber(CANTLISTA3, 2), FormatNumber(CANTLISTA4, 2), PORMIN2, PREMIN2, CANMIN3, CANMIN4, PORMAY2, PREMAY2, CANTMAY3, CANTMAY4, PORMM2, PREMM2, CANTMM3, CANTMM4, PORESP2, PREESP2, CANTESP3, CANTESP4)
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
            Dim voy As Integer = 0

            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Worksheets.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("B").NumberFormat = "@"
                exSheet.Columns("F").NumberFormat = "#,##0.00"
                exSheet.Columns("G").NumberFormat = "#,##0.00"
                exSheet.Columns("H").NumberFormat = "#,##0.00"
                exSheet.Columns("I").NumberFormat = "#,##0.00"
                exSheet.Columns("J").NumberFormat = "#,##0.00"
                exSheet.Columns("K").NumberFormat = "#,##0.00"
                exSheet.Columns("L").NumberFormat = "#,##0.00"
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
                    voy = voy + 1
                    txtCod.Text = voy
                    ''ProgressBar1.Value = ProgressBar1.Value + 1
                    'lblprod.Text = "Registros exportados: " & voy
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
            Dim por_list2 As Double = 0
            Dim por_mini As Double = 0
            Dim por_min2 As Double = 0
            Dim por_medi As Double = 0
            Dim por_mm2 As Double = 0
            Dim por_mayo As Double = 0
            Dim por_may2 As Double = 0
            Dim por_espe As Double = 0
            Dim por_esp2 As Double = 0

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

            'demas precios
            Dim porcentajelista2 As Double = 0
            Dim preciolista2 As Double = 0
            Dim cantlista3 As Double = 0
            Dim cantlista4 As Double = 0

            Dim porcentajemin2 As Double = 0
            Dim preciominimo2 As Double = 0
            Dim cantminimo3 As Double = 0
            Dim cantminimo4 As Double = 0

            Dim porcentajemay2 As Double = 0
            Dim preciomay2 As Double = 0
            Dim cantmay3 As Double = 0
            Dim cantmay4 As Double = 0

            Dim porcentajemm2 As Double = 0
            Dim preciomm2 As Double = 0
            Dim cantmm3 As Double = 0
            Dim cantmm4 As Double = 0

            Dim porcentajeesp2 As Double = 0
            Dim precioesp2 As Double = 0
            Dim cantesp3 As Double = 0
            Dim cantesp4 As Double = 0

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

                ' If row.IsNewRow Then Continue For ' Ignorar la última fila nueva

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

                porcentajelista2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(27).Value)
                preciolista2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(28).Value)
                cantlista3 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(29).Value)
                cantlista4 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(30).Value)

                porcentajemin2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(31).Value)
                preciominimo2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(32).Value)
                cantminimo3 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(33).Value)
                cantminimo4 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(34).Value)

                porcentajemay2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(35).Value)
                preciomay2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(36).Value)
                cantmay3 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(37).Value)
                cantmay4 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(38).Value)

                porcentajemm2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(39).Value)
                preciomm2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(40).Value)
                cantmm3 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(41).Value)
                cantmm4 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(42).Value)

                porcentajeesp2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(43).Value)
                precioesp2 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(44).Value)
                cantesp3 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(45).Value)
                cantesp4 = Convert.ToDouble(grdimporta.Rows.Item(X).Cells(46).Value)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select IVA from Productos where Codigo='" & codigo & "'"
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

                            por_list2 = ((preciolista2 * 100) / pre_compra) - 100
                            If por_list2 < 0 Then por_list2 = 0

                            por_min2 = ((preciominimo2 * 100) / pre_compra) - 100
                            If por_min2 < 0 Then por_min2 = 0

                            por_may2 = ((preciomay2 * 100) / pre_compra) - 100
                            If por_may2 < 0 Then por_may2 = 0

                            por_mm2 = ((preciomm2 * 100) / pre_compra) - 100
                            If por_mm2 < 0 Then por_mm2 = 0

                            por_esp2 = ((precioesp2 * 100) / pre_compra) - 100
                            If por_esp2 < 0 Then por_esp2 = 0

                        Else
                            por_list = 0
                            por_mini = 0
                            por_medi = 0
                            por_mayo = 0
                            por_espe = 0
                            por_list2 = 0
                            por_min2 = 0
                            por_may2 = 0
                            por_mm2 = 0
                            por_esp2 = 0

                        End If

                        Dim pre_lista_siva As Double = pre_lista / (1 + IVA)
                        Dim pre_lista2_siva As Double = preciolista2 / (1 + IVA)
                        Dim pre_min2_siva As Double = preciominimo2 / (1 + IVA)
                        Dim pre_may2_siva As Double = preciomay2 / (1 + IVA)

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Productos set PrecioCompra=" & pre_compra & ", Porcentaje=" & por_list & ",Porcentaje2=" & por_list2 & ", PrecioVenta=" & pre_lista_siva & ",PrecioVenta2=" & pre_lista2_siva & ",PrecioventaIVA=" & pre_lista & ",PrecioVentaIVA2=" & preciolista2 & ", PorcMin=" & por_mini & ",PorcMin2=" & por_min2 & ", PreMin=" & pre_minimo & ",PreMin2=" & preciominimo2 & ", PorcMM=" & por_medi & ",PorcMM2=" & por_mm2 & ", PreMM=" & pre_mediom & ",PreMM2=" & preciomm2 & ", PorcMay=" & por_mayo & ",PorcMay2=" & por_may2 & ", PreMay=" & pre_mayore & ",PreMay2=" & preciomay2 & ", PorcEsp=" & por_espe & ",PorcEsp2=" & por_esp2 & ", PreEsp=" & pre_especi & ",PreEsp2=" & precioesp2 & ", Almacen3=" & pre_compra & ",Porcentaje=" & porcentaje & ",CantLst1=" & desdecantlista & ", CantLst2=" & hastacantlista & ",CantLst3=" & cantlista3 & ",CantLst4=" & cantlista4 & ",PorcMin=" & porminimo & ",PorcMin2=" & porcentajemin2 & ",CantMin1=" & desdecantmin & ",CantMin2=" & hastacantmin & ",CantMin3=" & cantminimo3 & ",CantMin4=" & cantminimo4 & ",PorcMay=" & pormay & ",PorcMay2=" & porcentajemay2 & ",PorcEsp2=" & porcentajeesp2 & ",CantMay1=" & desdecantmay & ",CantMay2=" & hastacantmay & ",CantMay3=" & cantmay3 & ",CantMay4=" & cantmay4 & ",PorcMM=" & pormedio & ",PorcMM2=" & porcentajemm2 & ",CantMM1=" & desdecantmedio & ",CantMM2=" & hastacantmedio & ",CantMM3=" & cantmm3 & ",CantMM4=" & cantmm4 & ",PorcEsp=" & poresp & ",CantEsp1=" & desdecantesp & ",CantEsp2=" & hastacantesp & ",CantEsp3=" & cantesp3 & ",CantEsp4=" & cantesp4 & "  where Codigo='" & codigo & "'"
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
            'grdimporta.Rows.Clear()
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
