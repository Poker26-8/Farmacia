Imports Microsoft.Office.Interop

Public Class frmRepAsistenciaGym
    Private Sub frmRepAsistenciaGym_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub CboEmpleado_DropDown(sender As Object, e As EventArgs) Handles CboEmpleado.DropDown
        CboEmpleado.Items.Clear()
        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "Select distinct Nombre from AsistenciaGym where Nombre<>'' order by Nombre"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            CboEmpleado.Items.Add(rd1(0).ToString)
        Loop
        rd1.Close()
        cnn1.Close()

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Public Function GridAExcel(ByVal ElGrid As DataGridView, ByVal titulo As String) As Boolean

        'Creamos las variables
        Dim exApp As New Excel.Application
        Dim exLibro As Excel.Workbook
        Dim exHoja As Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()

            'Aplicación visible
            btnexportar.Enabled = True
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Try
            Dim MonthV1 As Date = Nothing
            Dim MonthV2 As Date = Nothing
            Dim Sql As String = ""
            Dim DiasDesc As String = ""
            Dim HoraEnt As String = ""
            Dim HoraSal As String = ""
            Dim ToleEnt As String = ""
            Dim ToleSal As String = ""
            Dim Puesto As String = ""
            Dim Area As String = ""
            MonthV1 = MonthCalendar1.SelectionRange.Start.ToShortDateString()
            MonthV2 = MonthCalendar2.SelectionRange.Start.ToShortDateString()

            lbl_proceso.Text = "Procesando ..."
            lbl_proceso.Visible = True
            ProgressBar2.Value = 0
            If RbTodos.Checked = True Then
                If CboEmpleado.Text = "" Then
                    GridCaptura.Rows.Clear()
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "select NumEmp,Nombre,Estatus,Fecha,Hora from AsistenciaGym where Fecha>='" & Format(MonthV1, "yyyy/MM/dd") & "' And Fecha<='" & Format(MonthV2, "yyyy/MM/dd") & "'"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        My.Application.DoEvents()
                        GridCaptura.Rows.Add(rd2("NumEmp").ToString, rd2("Nombre").ToString, rd2("Estatus").ToString, FormatDateTime(rd2("Fecha").ToString), FormatDateTime(rd2("Hora").ToString))
                        ProgressBar2.Value = CInt(ProgressBar2.Value) + 1
                    Loop
                    rd2.Close()
                    cnn2.Close()
                    ProgressBar2.Visible = False
                    lbl_proceso.Visible = False
                    Button1.Enabled = True
                Else
                    GridCaptura.Rows.Clear()
                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "select NumEmp,Nombre,Estatus,Fecha,Hora from AsistenciaGym where Nombre = '" & CboEmpleado.Text & "' and Fecha>='" & Format(MonthV1, "yyyy/MM/dd") & "' And Fecha<='" & Format(MonthV1, "yyyy/MM/dd") & "'"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        My.Application.DoEvents()
                        GridCaptura.Rows.Add(rd2("NumEmp").ToString, rd2("Nombre").ToString, rd2("Estatus").ToString, FormatDateTime(rd2("Fecha").ToString), FormatDateTime(rd2("Hora").ToString))
                        ProgressBar2.Value = CInt(ProgressBar2.Value) + 1
                    Loop
                    rd2.Close()
                    cnn2.Close()
                    ProgressBar2.Visible = False
                    lbl_proceso.Visible = False
                    Button1.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
        If GridCaptura.Rows.Count = 0 Then
            MsgBox("Sin datos para exportar", vbInformation + vbOKOnly, "")
            Exit Sub
        Else
            btnexportar.Enabled = False
            GridAExcel(GridCaptura, "Todos")
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class