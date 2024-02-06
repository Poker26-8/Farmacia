Imports Microsoft.Office.Interop.Excel

Public Class frmReporte
    Private Sub frmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles cbocliente.DropDown
        cbocliente.Items.Clear()
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select distinct Cliente from MembresiasGym where Cliente<>'' order by Cliente"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            cbocliente.Items.Add(rd1(0).ToString)
        Loop
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        grdcaptura.Rows.Clear()
        cbocliente.Items.Clear()
        cbocliente.Text = ""
        mcinicio.SelectionStart = Today
        mcfin.SelectionStart = Today
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim m1 As Date = mcinicio.SelectionStart.ToShortDateString
        Dim m2 As Date = mcfin.SelectionStart.ToShortDateString
        grdcaptura.Rows.Clear()
        Dim fechadehoy As Date = Date.Now
        Dim fechafinal As Date = Nothing

        fechadehoy = FormatDateTime(fechadehoy, DateFormat.ShortDate)

        If cbocliente.Text = "" Then
            grdcaptura.Rows.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from MembresiasGym where Inicio>='" & Format(m1, "yyyy/MM/dd") & "' and Fin<='" & Format(m2, "yyyy/MM/dd") & "' order by Cliente"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                fechafinal = FormatDateTime(rd1(5).ToString)
                Dim dias As Double = DateDiff(DateInterval.Day, CDate(fechadehoy), CDate(fechafinal))

                grdcaptura.Rows.Add(rd1(1).ToString, rd1(2).ToString, rd1(3).ToString, FormatDateTime(rd1(4).ToString, DateFormat.ShortDate), FormatDateTime(rd1(5).ToString, DateFormat.ShortDate), dias)
            Loop
            rd1.Close()
            cnn1.Close()

            Dim fecha As Date = Date.Now

            fecha = FormatDateTime(fecha, DateFormat.ShortDate)

            For i = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(i).Cells(4).Value < fecha Then
                    grdcaptura.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
                Else
                    grdcaptura.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                End If
            Next
        Else
            grdcaptura.Rows.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from MembresiasGym where Inicio>='" & Format(m1, "yyyy/MM/dd") & "' and Fin<='" & Format(m2, "yyyy/MM/dd") & "' and Cliente='" & cbocliente.Text & "' order by Cliente"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                fechafinal = FormatDateTime(rd1(5).ToString)
                Dim dias As Double = DateDiff(DateInterval.Day, CDate(fechadehoy), CDate(fechafinal))
                grdcaptura.Rows.Add(rd1(1).ToString, rd1(2).ToString, rd1(3).ToString, FormatDateTime(rd1(4).ToString, DateFormat.ShortDate), FormatDateTime(rd1(5).ToString, DateFormat.ShortDate), dias)
            Loop
            rd1.Close()
            cnn1.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
        btnexportar.Enabled = False
        If MsgBox("¿Deseas Exportar la Información a un Documento de Excel?.", vbQuestion + vbOKCancel, "Delsscom® Control Gimnasios") = vbCancel Then
            Exit Sub
        End If
        If grdcaptura.Rows.Count = 0 Then
            MsgBox("No hay registros para poder exportarlos a Excel.", vbInformation + vbOKOnly, "Delsscom® Control Gimnasios")
            Exit Sub
        End If

        Dim exapp As New Application
        Dim exLib As Workbook
        Dim exHoj As Worksheet

        Try
            exLib = exapp.Workbooks.Add()
            exHoj = exLib.Worksheets.Application.ActiveSheet

            Dim Fila As Integer = 0
            Dim Cola As Integer = 0
            Dim NFilas As Integer = grdcaptura.RowCount
            Dim NColas As Integer = grdcaptura.ColumnCount

            For i As Integer = 1 To NColas
                exHoj.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
            Next

            For Fila = 0 To NFilas - 1
                For Cola = 0 To NColas - 1
                    exHoj.Cells.Item(Fila + 2, Cola + 1) = Convert.ToString(grdcaptura.Rows(Fila).Cells(Cola).Value.ToString)
                Next
            Next

            exHoj.Rows.Item(1).Font.Bold = 1
            exHoj.Rows.Item(1).HorizontalAlignment = 3
            btnexportar.Enabled = True
            MsgBox("Información Exportada Correctamente!!!.", vbInformation + vbOKOnly, "Delsscom® Control Gimasios")
            exapp.Application.Visible = True

            exHoj = Nothing
            exLib = Nothing
            exHoj = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class