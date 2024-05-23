

Public Class frmCardex

    Private Sub frmCardex_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mCalendar1.SetDate(Now)
        mCalendar2.SetDate(Now)
    End Sub

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        cbonombre.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Cardex where Fecha between'" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' AND Nombre<>'' ORDER BY Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        txtcodigo.Text = ""
        lblExistencia.Text = ""
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1("Codigo").ToString
                    cboCodigo.Text = rd1("Codigo").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnreporte_Click(sender As System.Object, e As System.EventArgs) Handles btnreporte.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        grdcaptura.Rows.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand



            If cbonombre.Text = "" Then
                cmd1.CommandText =
                    "select * from Cardex where Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' order by Id"
            Else
                cmd1.CommandText =
                    "select * from Cardex where Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' and Nombre='" & cbonombre.Text & "' order by Id"
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                Dim codigo As String = rd1("Codigo").ToString
                Dim nombre As String = rd1("Nombre").ToString
                Dim folio As String = rd1("Folio").ToString
                Dim movimi As String = rd1("Movimiento").ToString
                Dim precio As Double = rd1("Precio").ToString
                Dim inicia As Double = rd1("Inicial").ToString
                Dim cantidad As Double = rd1("Cantidad").ToString
                Dim final As Double = rd1("Final").ToString
                Dim usuario As String = rd1("Usuario").ToString
                Dim fecha As String = rd1("Fecha").ToString

                grdcaptura.Rows.Add(codigo, nombre, folio, movimi, FormatNumber(precio, 2), inicia, cantidad, final, usuario, FormatDateTime(fecha, DateFormat.GeneralDate))
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        If cbonombre.Text <> "" Then
            Dim vas As Integer = grdcaptura.Rows.Count - 1

            cnn1.Close() : cnn1.Open()
            For RT As Integer = 0 To vas
                Dim existencia As Double = 0
                Dim multiplo As Double = 0
                Dim exist As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Existencia,Multiplo from Productos where Codigo='" & grdcaptura.Rows(RT).Cells(0).Value.ToString & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existencia = rd1(0).ToString
                        multiplo = rd1(1).ToString
                        If Len(grdcaptura.Rows(RT).Cells(0).Value.ToString) <= 6 Then
                            exist = existencia / multiplo
                            lblExistencia.Text = FormatNumber(exist, 2)
                        End If
                    End If
                End If
                rd1.Close()

                If Len(grdcaptura.Rows(RT).Cells(0).Value.ToString) > 6 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Existencia,Multiplo from Productos where Codigo='" & Mid(grdcaptura.Rows(RT).Cells(0).Value.ToString, 1, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            existencia = rd1(0).ToString
                            multiplo = rd1(1).ToString
                            If Len(grdcaptura.Rows(RT).Cells(0).Value.ToString) <= 6 Then
                                exist = CDbl(rd1(0).ToString) / multiplo
                                lblExistencia.Text = FormatNumber(exist, 2)
                            End If
                        End If
                    Else
                        lblExistencia.Text = "0.00"
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
        End If

        If cbonombre.Text <> "" Then
            Dim vas As Integer = grdcaptura.Rows.Count - 1

            cnn1.Close() : cnn1.Open()
            For RT As Integer = 0 To vas
                Dim existencia As Double = 0
                Dim multiplo As Double = 0
                Dim exist As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Existencia,Multiplo from Productos where Codigo='" & grdcaptura.Rows(RT).Cells(0).Value.ToString & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existencia = rd1(0).ToString
                        multiplo = rd1(1).ToString
                        If Len(grdcaptura.Rows(RT).Cells(0).Value.ToString) <= 6 Then
                            exist = existencia / multiplo
                            lblExistencia.Text = FormatNumber(exist, 2)
                        End If
                    End If
                End If
                rd1.Close()

                If Len(grdcaptura.Rows(RT).Cells(0).Value.ToString) > 6 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Existencia, Multiplo  from Productos where Codigo='" & Mid(grdcaptura.Rows(RT).Cells(0).Value.ToString, 1, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            existencia = CDbl(rd1(0).ToString) / multiplo
                            lblExistencia.Text = FormatNumber(exist, 2)

                            End If
                    Else
                        lblExistencia.Text = "0.00"
                    End If
                    rd1.Close()
                End If
            Next
            cnn1.Close()
        End If
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

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("D").NumberFormat = "$#,##0.00"

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

            MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        End If
    End Sub

    Private Sub cbonombre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbonombre.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F3
                frmBuscaRepts.VieneDe = "Cardex"
                frmBuscaRepts.Show()
        End Select
    End Sub

    Private Sub frmCardex_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cbonombre.Focus().Equals(True)
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As EventArgs) Handles cboCodigo.DropDown
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString
        cboCodigo.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT DISTINCT Codigo FROM Cardex WHERE Fecha between'" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' AND Codigo<>'' order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboCodigo.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodigo.SelectedValueChanged
        txtcodigo.Text = ""
        lblExistencia.Text = ""
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1("Codigo").ToString
                    cbonombre.Text = rd1("Nombre").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class