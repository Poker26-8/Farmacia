Imports Microsoft.Office.Interop

Public Class frmListadoProductos

    Private Sub optproveedor_Click(sender As System.Object, e As System.EventArgs) Handles optproveedor.Click
        If (optproveedor.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = True
            grdcaptura.ColumnCount = 9

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
                    .HeaderText = "Descripción"
                    .Width = 260
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.True
                End With
                With .Columns(3)
                    .HeaderText = "Descripción larga"
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Departamento"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Grupo"
                    .Width = 180
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Existencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optdepartamento_Click(sender As System.Object, e As System.EventArgs) Handles optdepartamento.Click
        If (optdepartamento.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = True
            grdcaptura.ColumnCount = 9

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
                    .HeaderText = "Descripción"
                    .Width = 260
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.True
                End With
                With .Columns(3)
                    .HeaderText = "Descripción larga"
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Departamento"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Grupo"
                    .Width = 180
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Existencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optgrupo_Click(sender As System.Object, e As System.EventArgs) Handles optgrupo.Click
        If (optgrupo.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = True
            grdcaptura.ColumnCount = 9

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
                    .HeaderText = "Descripción"
                    .Width = 260
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.True
                End With
                With .Columns(3)
                    .HeaderText = "Descripción larga"
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Departamento"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Grupo"
                    .Width = 180
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Existencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub opttodos_Click(sender As System.Object, e As System.EventArgs) Handles opttodos.Click
        If (opttodos.Checked) Then
            grdcaptura.Rows.Clear()
            cbofiltro.Text = ""
            cbofiltro.Enabled = False
            grdcaptura.ColumnCount = 9

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
                    .HeaderText = "Descripción"
                    .Width = 260
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.True
                End With
                With .Columns(3)
                    .HeaderText = "Descripción larga"
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
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Departamento"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Grupo"
                    .Width = 180
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Existencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Dim conteo As Integer = 0

            Dim codigo As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim nom_la As String = ""
            Dim unidad As String = ""
            Dim provee As String = ""
            Dim depto As String = ""
            Dim grupo As String = ""
            Dim existe As Double = 0
            Dim multias As Double = 0

            Dim order_by As String = ""

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

                bardatos.Visible = True
                bardatos.Value = 0
                bardatos.Maximum = conteo

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,Departamento,Grupo,Multiplo from Productos order by " & order_by & ""
                rd1 = cmd1.ExecuteReader
                cnn2.Close() : cnn2.Open()
                Do While rd1.Read
                    codigo = rd1("Codigo").ToString
                    barras = rd1("CodBarra").ToString
                    nombre = rd1("Nombre").ToString
                    unidad = rd1("UVenta").ToString
                    provee = rd1("ProvPri").ToString
                    depto = rd1("Departamento").ToString
                    grupo = rd1("Grupo").ToString
                    multias = rd1("Multiplo").ToString

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Existencia from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            Dim exis As Double = rd2(0).ToString
                            existe = exis / multias
                        End If
                    End If
                    rd2.Close()

                    grdcaptura.Rows.Add(codigo, barras, nombre, nom_la, unidad, provee, depto, grupo, existe)
                    bardatos.Value = bardatos.Value + 1
                Loop
                rd1.Close() : cnn1.Close()
                cnn2.Close()
                bardatos.Value = 0
                bardatos.Visible = False
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
            If (optproveedor.Checked) Then
                cmd1.CommandText =
                    "select distinct ProvPri from Productos order by ProvPri"
            End If
            If (optdepartamento.Checked) Then
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
            Dim nom_la As String = ""
            Dim unidad As String = ""
            Dim provee As String = ""
            Dim depto As String = ""
            Dim grupo As String = ""
            Dim existe As Double = 0
            Dim multias As Double = 0

            Dim conteo As Double = 0
            Dim order_by As String = ""

            If (optord_nombre.Checked) Then order_by = "Nombre"
            If (optord_depto.Checked) Then order_by = "Departamento"
            If (optord_grupo.Checked) Then order_by = "Grupo"

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If (optproveedor.Checked) Then
                cmd1.CommandText =
                    "select count(Codigo) from Productos where ProvPri='" & cbofiltro.Text & "'"
            End If
            If (optdepartamento.Checked) Then
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

            bardatos.Value = 0
            bardatos.Visible = True
            bardatos.Maximum = conteo

            cmd1 = cnn1.CreateCommand
            If (optproveedor.Checked) Then
                cmd1.CommandText =
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,Departamento,Grupo,Multiplo from Productos where ProvPri='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            If (optdepartamento.Checked) Then
                cmd1.CommandText =
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,Departamento,Grupo,Multiplo from Productos where Departamento='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            If (optgrupo.Checked) Then
                cmd1.CommandText =
                    "select Codigo,CodBarra,Nombre,UVenta,ProvPri,Departamento,Grupo,Multiplo from Productos where Grupo='" & cbofiltro.Text & "' order by " & order_by & ""
            End If
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                codigo = rd1("Codigo").ToString
                barras = rd1("CodBarra").ToString
                nombre = rd1("Nombre").ToString
                unidad = rd1("UVenta").ToString
                provee = rd1("ProvPri").ToString
                depto = rd1("Departamento").ToString
                grupo = rd1("Grupo").ToString
                multias = rd1("Multiplo").ToString

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select Existencia from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        Dim exis As Double = rd2(0).ToString
                        existe = exis / multias
                    End If
                End If
                rd2.Close()

                grdcaptura.Rows.Add(codigo, barras, nombre, nom_la, unidad, provee, depto, grupo, existe)
                bardatos.Value = bardatos.Value + 1
            Loop
            rd1.Close() : cnn1.Close()
            cnn2.Close()
            bardatos.Value = 0
            bardatos.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmListadoProductos_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        optord_nombre.Checked = True
    End Sub

    Private Sub optord_nombre_Click(sender As System.Object, e As System.EventArgs) Handles optord_nombre.Click
        If (optord_nombre.Checked) Then
            If (optproveedor.Checked) Or (optdepartamento.Checked) Or (optgrupo.Checked) Then
                LlenaGrid()
            End If
            If (opttodos.Checked) Then
                opttodos.PerformClick()
            End If
        End If
    End Sub

    Private Sub optord_depto_Click(sender As System.Object, e As System.EventArgs) Handles optord_depto.Click
        If (optord_depto.Checked) Then
            If (optproveedor.Checked) Or (optdepartamento.Checked) Or (optgrupo.Checked) Then
                LlenaGrid()
            End If
            If (opttodos.Checked) Then
                opttodos.PerformClick()
            End If
        End If
    End Sub

    Private Sub optord_grupo_Click(sender As System.Object, e As System.EventArgs) Handles optord_grupo.Click
        If (optord_grupo.Checked) Then
            If (optproveedor.Checked) Or (optdepartamento.Checked) Or (optgrupo.Checked) Then
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


            bardatos.Minimum = 0
            bardatos.Value = 0
            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Worksheets.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("B").NumberFormat = "@"



                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value
                    Next

                    bardatos.Value = bardatos.Value + 1
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

    Private Sub frmListadoProductos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class