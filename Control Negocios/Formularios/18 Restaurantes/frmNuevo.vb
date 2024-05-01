Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmNuevo

    Friend WithEvents btnMesa As System.Windows.Forms.Button
    Dim btnaccion = New DataGridViewButtonColumn()
    Dim btnaccion2 = New DataGridViewTextBoxCell()
    Dim rowIndex As Integer = 0 ' 
    Private Sub frmNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mesa()


        ' btnaccion.Name = "Eliminar"
        btnaccion2.value = "Inventario Fisico"

        ' grdCaptura.Columns.Add(btnaccion2)

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "select distinct nombre_mesa from mesa"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then

                grdCaptura2.Rows.Add(rd1(0).ToString, "222")
                ' Agregar la celda a una fila específica en el control DataGridView
                'grdCaptura.Rows(rowIndex).Cells.Add(btnaccion2)
            End If
        Loop
        rd1.Close()
        cnn1.Close()



    End Sub

    Private Sub grdCaptura_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        e.Paint(e.CellBounds, DataGridViewPaintParts.All)


    End Sub

    Public Sub Mesa()
        Try
            Dim mesa As Integer = 1
            Dim totalMesas As Double = ObtenerTotalMesas()
            Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totalMesas)) ' Calculamos el número de columnas necesarias
            Dim cuantosFilas As Integer = Math.Ceiling(totalMesas / cuantosColumnas) ' Calculamos el número de filas necesarias

            ' Tamaño fijo de los botones
            Dim btnWidth As Integer = 250 ' Ancho fijo del botón
            Dim btnHeight As Integer = 100 ' Alto fijo del botón

            ' Espacio entre botones
            Dim espacioHorizontal As Integer = 5
            Dim espacioVertical As Integer = 5

            pmesas.Controls.Clear() ' Limpiamos los controles existentes en el panel

            Dim nombre As New List(Of String)()

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Nombre_mesa,TempNom,X,y,Tipo,IdEmpleado FROM Mesa order by Orden"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    nombre.Add(rd3.GetString("Nombre_mesa"))
                End If
            Loop
            rd3.Close()
            cnn3.Close()




            For fila As Integer = 0 To cuantosFilas - 1
                For columna As Integer = 0 To cuantosColumnas - 1
                    If mesa > totalMesas Then Exit For ' Si ya hemos agregado todas las mesas, salimos del bucle

                    ' Obtener el nombre de la mesa correspondiente
                    Dim nombreMesa As String = nombre(mesa - 1)

                    ' Obtener el nombre de la mesa
                    Dim btnMesa As New Button()


                    btnMesa.Text = nombreMesa
                    ' btnMesa.Width = pmesas.Width / cuantosColumnas ' Ancho del botón
                    'btnMesa.Height = pmesas.Height / cuantosFilas ' Alto del botón

                    btnMesa.Width = btnWidth ' Ancho del botón
                    btnMesa.Height = btnHeight ' Alto del botón

                    btnMesa.BackColor = Color.FromArgb(238, 220, 162)
                    btnMesa.FlatStyle = FlatStyle.Flat
                    btnMesa.FlatAppearance.BorderSize = 0
                    btnMesa.Name = "btnMesa(" & nombreMesa & ")"
                    btnMesa.TextAlign = ContentAlignment.BottomCenter
                    btnMesa.Font = New Font(btnMesa.Font, FontStyle.Bold)

                    ' Posicionar el botón dentro del panel
                    btnMesa.Left = columna * (btnMesa.Width + espacioHorizontal)
                    btnMesa.Top = fila * (btnMesa.Height + espacioVertical)

                    AddHandler btnMesa.Click, AddressOf btnMesa_Click
                    pmesas.Controls.Add(btnMesa)

                    mesa += 1


                Next
            Next

            ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
            Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
            Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
            pmesas.AutoScrollMinSize = New Size(panelWidth, panelHeight)

            ' Ajustar el tamaño de la fuente de los botones cuando se crea el diseño inicial
            AjustarTamañoFuenteBotones()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function ObtenerTotalMesas() As Integer
        ' Aquí implementa la lógica para obtener el total de mesas según la ubicación
        ' Por ejemplo, puedes ejecutar una consulta SQL similar a la que tenías en tu código original
        ' y devolver el número total de mesas
        Dim totalmesa2 As Double = 0

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                totalmesa2 = rd2(0).ToString
            End If
        End If
        rd2.Close()
        cnn2.Close()

        Return totalmesa2
    End Function


    Private Sub btnMesa_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmNuevo_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Mesa()
        AjustarTamañoFuenteBotones()
    End Sub

    Private Sub AjustarTamañoFuenteBotones()
        ' Calcular el tamaño de la fuente en función del tamaño del formulario
        Dim factorReduccion As Double = 24 * (pmesas.Width / 800) ' Ajusta 24 según el tamaño base del formulario (800x600)

        ' Limitar el tamaño de la fuente mínimo y máximo
        If factorReduccion < 8 Then
            factorReduccion = 8
        ElseIf factorReduccion > 24 Then
            factorReduccion = 24
        End If

        ' Iterar a través de los controles del panel y ajustar el tamaño de la fuente de los botones
        For Each control As Control In pmesas.Controls
            If TypeOf control Is Button Then
                Dim boton As Button = CType(control, Button)
                boton.Font = New Font(boton.Font.FontFamily, CType(factorReduccion, Single))
            End If
        Next
    End Sub

    Private Sub grdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' Manejar el evento de clic de la celda del botón
        'If e.ColumnIndex = grdCaptura.Columns("Eliminar").Index AndAlso e.RowIndex >= 0 Then
        '    MessageBox.Show("Haz clic en el botón en la fila " & (e.RowIndex + 1).ToString())
        '    ' Aquí puedes realizar las acciones que desees al hacer clic en el botón
        'End If

        If e.ColumnIndex = 1 AndAlso e.RowIndex >= 0 Then ' Las columnas en DataGridView son base cero, por lo que la tercera columna tiene el índice 2
            grdCaptura1.BeginEdit(True) ' Iniciar la edición de la celda
        End If

    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        'If e.ColumnIndex = 1 Then
        '    grdCaptura.EditMode = DataGridViewEditMode.EditOnEnter
        '    MsgBox("HHHH")
        'End If
    End Sub

    Private Sub grdCaptura_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura2.CellDoubleClick
        If e.ColumnIndex > 0 Then
            Dim valorActual As String = grdCaptura2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim nuevoValor As String = InputBox("Ingresa la nueva existencia", "Editar Existencia", valorActual.ToString())
            If nuevoValor <> "" Then
                grdCaptura2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = nuevoValor
            End If
        End If
    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click
        PDF_MESAS()
    End Sub

    Private Sub PDF_MESAS()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New PruebaMesa
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        ' Lista para almacenar nombres de mesa
        Dim nombres_mesas As New List(Of String)

        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\")
        root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf"

        If File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf") Then
            File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf")
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

        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand
        cmd5.CommandText = "SELECT DISTINCT Nombre_mesa FROM mesa WHERE Nombre_mesa<>''"
        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                nombres_mesas.Add(rd5(0).ToString())
            End If
        Loop
        rd5.Close()
        cnn5.Close()

        ' Asignar los nombres de mesa al informe
        For Each nombre As String In nombres_mesas
            FileNta.DataDefinition.FormulaFields("mesamy").Text = "'" & nombre & "'"
            FileNta.Refresh()
        Next

        ' FileNta.DataDefinition.FormulaFields("mesamy").Text = "'" & mesa & "'"

        ' FileNta.Refresh()
        'FileNta.Refresh()
        'FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
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
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            FileNta.Close()

            If varrutabase <> "" Then

            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf")
            End If

            System.IO.File.Copy("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta1.pdf")
        End If


    End Sub
End Class