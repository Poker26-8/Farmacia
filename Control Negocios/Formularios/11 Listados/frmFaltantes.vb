Imports Microsoft.Office.Interop

Public Class frmFaltantes

    Private Sub frmFaltantes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub optproveedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optproveedor.CheckedChanged
        If (optproveedor.Checked) Then
            cbofiltro.Enabled = True
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            grdcaptura.Rows.Clear()
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optdepto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optdepto.CheckedChanged
        If (optdepto.Checked) Then
            cbofiltro.Enabled = True
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            grdcaptura.Rows.Clear()
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optgrupo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optgrupo.CheckedChanged
        If (optgrupo.Checked) Then
            cbofiltro.Enabled = True
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            grdcaptura.Rows.Clear()
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofiltro_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofiltro.DropDown
        cbofiltro.Items.Clear()
        Try
            Dim consluta As String = ""
            If (optproveedor.Checked) Then consluta = "select distinct ProvPri from Productos where Codigo = Left(Codigo,6)"
            If (optdepto.Checked) Then consluta = "select distinct Departamento from Productos where Codigo = Left(Codigo,6)"
            If (optgrupo.Checked) Then consluta = "select distinct Grupo from Productos where Codigo = Left(Codigo,6)"

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                consluta
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbofiltro.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofiltro_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbofiltro.SelectedValueChanged
        Dim consulta As String = ""
        If (optproveedor.Checked) Then consulta = "select * from Productos where ProvPri='" & cbofiltro.Text & "' order by Nombre"
        If (optdepto.Checked) Then consulta = "select * from Productos where Departamento='" & cbofiltro.Text & "' order by Nombre"
        If (optgrupo.Checked) Then consulta = "select * from Productos where Grupo='" & cbofiltro.Text & "' order by Nombre"

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                consulta
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString()
                    Dim barras As String = rd1("CodBarra").ToString()
                    Dim nombre As String = rd1("Nombre").ToString()
                    Dim unidad As String = rd1("UCompra").ToString()
                    Dim exist As Double = IIf(rd1("Existencia").ToString = "", 0, rd1("Existencia").ToString)
                    Dim prov As String = rd1("ProvPri").ToString
                    Dim precompra As Double = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                    Dim mini As Double = IIf(rd1("Min").ToString = "", 1, rd1("Min").ToString)
                    Dim maxi As Double = IIf(rd1("Max").ToString = "", 1, rd1("Max").ToString)
                    Dim falta As Double = FormatNumber(maxi - exist, 2)
                    Dim cuantocuesta As Double = FormatNumber(falta * precompra)

                    grdcaptura.Rows.Add(codigo, barras, nombre, prov, exist & " " & unidad, mini & " " & unidad, maxi & " " & unidad, falta & " " & unidad, cuantocuesta)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub opttodos_CheckedChanged(sender As Object, e As EventArgs) Handles opttodos.CheckedChanged
        If opttodos.Checked = True Then
            Try
                grdcaptura.Rows.Clear()
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from Productos"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Dim codigo As String = rd1("Codigo").ToString()
                    Dim barras As String = rd1("CodBarra").ToString()
                    Dim nombre As String = rd1("Nombre").ToString()
                    Dim unidad As String = rd1("UCompra").ToString()
                    Dim exist As Double = IIf(rd1("Existencia").ToString = "", 0, rd1("Existencia").ToString)
                    Dim prov As String = rd1("ProvPri").ToString
                    Dim precompra As Double = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                    Dim mini As Double = IIf(rd1("Min").ToString = "", 1, rd1("Min").ToString)
                    Dim maxi As Double = IIf(rd1("Max").ToString = "", 1, rd1("Max").ToString)
                    Dim falta As Double = FormatNumber(maxi - exist, 2)
                    Dim cuantocuesta As Double = FormatNumber(falta * precompra)

                    grdcaptura.Rows.Add(codigo, barras, nombre, prov, exist & " " & unidad, mini & " " & unidad, maxi & " " & unidad, falta & " " & unidad, cuantocuesta)
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        grdcaptura.Rows.Clear()
        cbofiltro.Text = ""
        cbofiltro.Items.Clear()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
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



                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value
                    Next

                    'bardatos.Value = bardatos.Value + 1
                    My.Application.DoEvents()
                Next


                exSheet.Columns.AutoFit()

                MsgBox("Datos exportados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub
End Class