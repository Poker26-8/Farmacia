Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ClosedXML.Excel

Public Class frmActualizarTodo
    Private Sub optTodos_Click(sender As Object, e As EventArgs) Handles optTodos.Click
        If (optTodos.Checked) Then
            Try

                grdCaptura.Rows.Clear()
                cboFiltro.Visible = False
                cboFiltro.Text = ""
                rbDepartamento.Checked = False
                dbGrupo.Checked = False

                Dim codigo As String = ""
                Dim codbarra As String = ""
                Dim descripcion As String = ""
                Dim IVA As Double = 0
                Dim UNIDAD As String = ""
                Dim preciocompra As Double = 0
                Dim preciomaximo As Double = 0
                Dim precioventa As Double = 0
                Dim proveedor As String = ""
                Dim departamento As String = ""
                Dim grupo As String = ""
                Dim clavesat As String = ""
                Dim unidadsat As String = ""
                Dim existencia As Double = 0
                Dim antibiotico As Integer = 0
                Dim caduca As Integer = 0
                Dim controlado As Integer = 0
                Dim laboratorio As String = ""
                Dim principio As String = ""
                Dim ubicacion As String = ""
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,CodBarra,Nombre,IVA,UVenta,PrecioCompra,PrecioMaximoPublico,PrecioVentaIVA,ProvPri,Departamento,Grupo,ClaveSat,UnidadSat,Existencia,Anti,Caduca,controlado,Laboratorio,PrincipioActivo,Ubicacion FROM productos"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        codigo = rd1("Codigo").ToString
                        codbarra = rd1("CodBarra").ToString
                        descripcion = rd1("Nombre").ToString
                        IVA = rd1("IVA").ToString
                        UNIDAD = rd1("UVenta").ToString
                        preciocompra = rd1("PrecioCompra").ToString
                        preciomaximo = rd1("PrecioMaximoPublico").ToString
                        precioventa = rd1("PrecioVentaIVA").ToString
                        proveedor = rd1("ProvPri").ToString
                        departamento = rd1("Departamento").ToString
                        grupo = rd1("Grupo").ToString
                        clavesat = rd1("ClaveSat").ToString
                        unidadsat = rd1("UnidadSat").ToString
                        existencia = rd1("Existencia").ToString
                        antibiotico = rd1("Anti").ToString
                        caduca = rd1("Caduca").ToString
                        controlado = rd1("controlado").ToString
                        laboratorio = rd1("Laboratorio").ToString
                        principio = rd1("PrincipioActivo").ToString
                        ubicacion = rd1("Ubicacion").ToString

                        grdCaptura.Rows.Add(codigo, codbarra, descripcion, IVA, UNIDAD, preciocompra, preciomaximo, precioventa, proveedor, departamento, grupo, clavesat, unidadsat, existencia, antibiotico, caduca, controlado, laboratorio, principio, ubicacion)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarDataGridViewAExcel(grdCaptura)
    End Sub

    Public Sub ExportarDataGridViewAExcel(dgv As DataGridView)
        If grdCaptura.Rows.Count = 0 Then MsgBox("Genera el reporte para poder exportar los datos a Excel.", vbInformation + vbOKOnly, titulocentral) : Exit Sub
        If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim voy As Integer = 0
            ' Crea un nuevo libro de trabajo de Excel
            Using workbook As New XLWorkbook()

                ' Añade una nueva hoja de trabajo
                Dim worksheet As IXLWorksheet =
            workbook.Worksheets.Add("Datos")

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
                    'txtCod.Text = voy
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

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        CargarDatosDesdeExcel()
    End Sub

    Private Sub CargarDatosDesdeExcel()
        ' Crear el OpenFileDialog para seleccionar el archivo Excel
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de Excel|*.xlsx"
        openFileDialog.Title = "Seleccionar archivo Excel"

        ' Si el usuario selecciona un archivo
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Ruta del archivo Excel seleccionado
            Dim filePath As String = openFileDialog.FileName

            ' Crear un DataTable para almacenar los datos
            Dim dt As New DataTable()

            ' Abrir el archivo de Excel usando ClosedXML
            Using workbook As New XLWorkbook(filePath)
                ' Asumimos que los datos están en la primera hoja
                Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                ' Obtener la primera fila como encabezados y añadir columnas al DataTable
                Dim firstRow As IXLRow = worksheet.Row(1)
                For Each cell As IXLCell In firstRow.CellsUsed()
                    dt.Columns.Add(cell.Value.ToString())
                Next

                ' Recorrer las filas restantes y añadirlas al DataTable
                For rowIndex As Integer = 2 To worksheet.RowsUsed().Count()
                    Dim row As DataRow = dt.NewRow()
                    Dim currentRow As IXLRow = worksheet.Row(rowIndex)

                    For colIndex As Integer = 1 To dt.Columns.Count
                        row(colIndex - 1) = currentRow.Cell(colIndex).GetValue(Of String)()
                    Next

                    dt.Rows.Add(row)
                Next
            End Using

            ' Asignar el DataTable al DataGridView para mostrar los datos
            DataGridView1.DataSource = dt

            Dim codigo As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim iva As Double = 0
            Dim unidad As String = ""
            Dim preciocompra As Double = 0
            Dim preciomaximo As Double = 0
            Dim precioventa As Double = 0
            Dim proveedor As String = ""
            Dim departamento As String = ""
            Dim grupo As String = ""
            Dim claveproducto As String = ""
            Dim claveunidad As String = ""
            Dim existencia As Double = 0
            Dim antibiotico As Integer = 0
            Dim caduca As Integer = 0
            Dim controlado As Integer = 0
            Dim laboratorio As String = ""
            Dim principioactivo As String = ""
            Dim ubicacion As String = ""

            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            ProgressBar1.Maximum = DataGridView1.Rows.Count

            lblprod.Visible = True
            lblprod.Text = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            For X As Integer = 0 To DataGridView1.Rows.Count - 1

                codigo = Convert.ToString(DataGridView1.Rows.Item(X).Cells(0).Value)
                barras = Convert.ToString(DataGridView1.Rows.Item(X).Cells(1).Value)
                nombre = Convert.ToString(DataGridView1.Rows.Item(X).Cells(2).Value)
                If codigo = "" Then Exit For
                iva = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(3).Value)
                unidad = Convert.ToString(DataGridView1.Rows.Item(X).Cells(4).Value)
                preciocompra = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(5).Value)
                preciomaximo = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(6).Value)
                precioventa = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(7).Value)
                proveedor = Convert.ToString(DataGridView1.Rows.Item(X).Cells(8).Value)
                departamento = Convert.ToString(DataGridView1.Rows.Item(X).Cells(9).Value)
                grupo = Convert.ToString(DataGridView1.Rows.Item(X).Cells(10).Value)
                claveproducto = Convert.ToString(DataGridView1.Rows.Item(X).Cells(11).Value)
                claveunidad = Convert.ToString(DataGridView1.Rows.Item(X).Cells(12).Value)
                existencia = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(13).Value)
                antibiotico = Convert.ToInt32(DataGridView1.Rows.Item(X).Cells(14).Value)
                caduca = Convert.ToInt32(DataGridView1.Rows.Item(X).Cells(15).Value)
                controlado = Convert.ToInt32(DataGridView1.Rows.Item(X).Cells(16).Value)
                laboratorio = Convert.ToString(DataGridView1.Rows.Item(X).Cells(17).Value)
                principioactivo = Convert.ToString(DataGridView1.Rows.Item(X).Cells(18).Value)
                ubicacion = Convert.ToString(DataGridView1.Rows.Item(X).Cells(19).Value)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT * FROM Productos WHERE Codigo='" & codigo & "' AND CodBarra='" & barras & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblprod.Text = "Importando producto: " & nombre
                        My.Application.DoEvents()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Productos set Nombre='" & nombre & "',IVA=" & iva & ",UVenta='" & unidad & "',PrecioCompra=" & preciocompra & ",PrecioMaximoPublico=" & preciomaximo & ",PrecioVentaIVA=" & precioventa & ",ProvPri='" & proveedor & "',Departamento='" & departamento & "',Grupo='" & grupo & "',ClaveSat='" & claveproducto & "',UnidadSat='" & claveunidad & "',Existencia=" & existencia & ",Anti=" & antibiotico & ",Caduca=" & caduca & ",Controlado=" & controlado & ",Laboratorio='" & laboratorio & "',PrincipioActivo='" & principioactivo & "',Ubicacion='" & ubicacion & "',Cargado=0 where Codigo='" & codigo & "' AND CodBarra='" & barras & "'"
                        If cmd2.ExecuteNonQuery Then
                        Else
                            MsgBox("No se pudieron actualizar los datos del producto " & nombre, vbInformation + vbOKOnly, "Delsscom Farmacias")
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

        End If
        cnn2.Close()
        MsgBox("Datos importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        lblprod.Text = ""
        lblprod.Visible = False
        ProgressBar1.Visible = False
        ProgressBar1.Value = 0
    End Sub

    Private Sub rbDepartamento_Click(sender As Object, e As EventArgs) Handles rbDepartamento.Click
        If (rbDepartamento.Checked) Then
            grdCaptura.Rows.Clear()
            cboFiltro.Text = ""
            cboFiltro.Visible = True
            dbGrupo.Checked = False
            optTodos.Checked = False
        End If
    End Sub

    Private Sub dbGrupo_Click(sender As Object, e As EventArgs) Handles dbGrupo.Click
        If (dbGrupo.Checked) Then
            grdCaptura.Rows.Clear()
            cboFiltro.Text = ""
            cboFiltro.Visible = True
            rbDepartamento.Checked = False
            optTodos.Checked = False
        End If

    End Sub

    Private Sub cboFiltro_DropDown(sender As Object, e As EventArgs) Handles cboFiltro.DropDown
        Try
            cboFiltro.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbDepartamento.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Departamento FROM productos WHERE Departamento<>'' ORDER BY Departamento"
            End If

            If (dbGrupo.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Grupo FROM productos WHERE Grupo<>'' ORDER BY Grupo"
            End If

            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboFiltro.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub frmActualizarTodo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub rbDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles rbDepartamento.CheckedChanged
        If (rbDepartamento.Checked) Then
            cboFiltro.Text = ""
            cboFiltro.Visible = True
            grdCaptura.Rows.Clear()
        End If
    End Sub

    Private Sub cboFiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFiltro.SelectedValueChanged
        Try
            grdCaptura.Rows.Clear()
            Dim codigo As String = ""
            Dim codbarra As String = ""
            Dim descripcion As String = ""
            Dim IVA As Double = 0
            Dim UNIDAD As String = ""
            Dim preciocompra As Double = 0
            Dim preciomaximo As Double = 0
            Dim precioventa As Double = 0
            Dim proveedor As String = ""
            Dim departamento As String = ""
            Dim grupo As String = ""
            Dim clavesat As String = ""
            Dim unidadsat As String = ""
            Dim existencia As Double = 0
            Dim antibiotico As Integer = 0
            Dim caduca As Integer = 0
            Dim controlado As Integer = 0
            Dim laboratorio As String = ""
            Dim principio As String = ""
            Dim ubicacion As String = ""
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If (rbDepartamento.Checked) Then
                cmd1.CommandText = "SELECT Codigo,CodBarra,Nombre,IVA,UVenta,PrecioCompra,PrecioMaximoPublico,PrecioVentaIVA,ProvPri,Departamento,Grupo,ClaveSat,UnidadSat,Existencia,Anti,Caduca,controlado,Laboratorio,PrincipioActivo,Ubicacion FROM productos WHERE Departamento='" & cboFiltro.Text & "'"
            End If

            If (dbGrupo.Checked) Then
                cmd1.CommandText = "SELECT Codigo,CodBarra,Nombre,IVA,UVenta,PrecioCompra,PrecioMaximoPublico,PrecioVentaIVA,ProvPri,Departamento,Grupo,ClaveSat,UnidadSat,Existencia,Anti,Caduca,controlado,Laboratorio,PrincipioActivo,Ubicacion FROM productos WHERE Grupo='" & cboFiltro.Text & "'"
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    codigo = rd1("Codigo").ToString
                    codbarra = rd1("CodBarra").ToString
                    descripcion = rd1("Nombre").ToString
                    IVA = rd1("IVA").ToString
                    UNIDAD = rd1("UVenta").ToString
                    preciocompra = rd1("PrecioCompra").ToString
                    preciomaximo = rd1("PrecioMaximoPublico").ToString
                    precioventa = rd1("PrecioVentaIVA").ToString
                    proveedor = rd1("ProvPri").ToString
                    departamento = rd1("Departamento").ToString
                    grupo = rd1("Grupo").ToString
                    clavesat = rd1("ClaveSat").ToString
                    unidadsat = rd1("UnidadSat").ToString
                    existencia = rd1("Existencia").ToString
                    antibiotico = rd1("Anti").ToString
                    caduca = rd1("Caduca").ToString
                    controlado = rd1("controlado").ToString
                    laboratorio = rd1("Laboratorio").ToString
                    principio = rd1("PrincipioActivo").ToString
                    ubicacion = rd1("Ubicacion").ToString

                    grdCaptura.Rows.Add(codigo, codbarra, descripcion, IVA, UNIDAD, preciocompra, preciomaximo, precioventa, proveedor, departamento, grupo, clavesat, unidadsat, existencia, antibiotico, caduca, controlado, laboratorio, principio, ubicacion)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmActualizarTodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbDepartamento.Checked = True
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        InsertarDesdeExcel
    End Sub

    Private Sub InsertarDesdeExcel()
        ' Crear el OpenFileDialog para seleccionar el archivo Excel
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de Excel|*.xlsx"
        openFileDialog.Title = "Seleccionar archivo Excel"

        ' Si el usuario selecciona un archivo
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Ruta del archivo Excel seleccionado
            Dim filePath As String = openFileDialog.FileName

            ' Crear un DataTable para almacenar los datos
            Dim dt As New DataTable()

            ' Abrir el archivo de Excel usando ClosedXML
            Using workbook As New XLWorkbook(filePath)
                ' Asumimos que los datos están en la primera hoja
                Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                ' Obtener la primera fila como encabezados y añadir columnas al DataTable
                Dim firstRow As IXLRow = worksheet.Row(1)
                For Each cell As IXLCell In firstRow.CellsUsed()
                    dt.Columns.Add(cell.Value.ToString())
                Next

                ' Recorrer las filas restantes y añadirlas al DataTable
                For rowIndex As Integer = 2 To worksheet.RowsUsed().Count()
                    Dim row As DataRow = dt.NewRow()
                    Dim currentRow As IXLRow = worksheet.Row(rowIndex)

                    For colIndex As Integer = 1 To dt.Columns.Count
                        row(colIndex - 1) = currentRow.Cell(colIndex).GetValue(Of String)()
                    Next

                    dt.Rows.Add(row)
                Next
            End Using

            ' Asignar el DataTable al DataGridView para mostrar los datos
            DataGridView1.DataSource = dt

            Dim codigo As String = ""
            Dim barras As String = ""
            Dim nombre As String = ""
            Dim iva As Double = 0
            Dim unidad As String = ""
            Dim preciocompra As Double = 0
            Dim preciomaximo As Double = 0
            Dim precioventa As Double = 0
            Dim proveedor As String = ""
            Dim departamento As String = ""
            Dim grupo As String = ""
            Dim claveproducto As String = ""
            Dim claveunidad As String = ""
            Dim existencia As Double = 0
            Dim antibiotico As Integer = 0
            Dim caduca As Integer = 0
            Dim controlado As Integer = 0
            Dim laboratorio As String = ""
            Dim principioactivo As String = ""
            Dim ubicacion As String = ""

            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            ProgressBar1.Maximum = DataGridView1.Rows.Count

            lblprod.Visible = True
            lblprod.Text = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            For X As Integer = 0 To DataGridView1.Rows.Count - 1

                codigo = Convert.ToString(DataGridView1.Rows.Item(X).Cells(0).Value)
                barras = Convert.ToString(DataGridView1.Rows.Item(X).Cells(1).Value)
                nombre = Convert.ToString(DataGridView1.Rows.Item(X).Cells(2).Value)
                If codigo = "" Then Exit For
                iva = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(3).Value)
                unidad = Convert.ToString(DataGridView1.Rows.Item(X).Cells(4).Value)
                preciocompra = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(5).Value)
                preciomaximo = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(6).Value)
                precioventa = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(7).Value)
                proveedor = Convert.ToString(DataGridView1.Rows.Item(X).Cells(8).Value)
                departamento = Convert.ToString(DataGridView1.Rows.Item(X).Cells(9).Value)
                grupo = Convert.ToString(DataGridView1.Rows.Item(X).Cells(10).Value)
                claveproducto = Convert.ToString(DataGridView1.Rows.Item(X).Cells(11).Value)
                claveunidad = Convert.ToString(DataGridView1.Rows.Item(X).Cells(12).Value)
                existencia = Convert.ToDouble(DataGridView1.Rows.Item(X).Cells(13).Value)
                antibiotico = Convert.ToInt32(DataGridView1.Rows.Item(X).Cells(14).Value)
                caduca = Convert.ToInt32(DataGridView1.Rows.Item(X).Cells(15).Value)
                controlado = Convert.ToInt32(DataGridView1.Rows.Item(X).Cells(16).Value)
                laboratorio = Convert.ToString(DataGridView1.Rows.Item(X).Cells(17).Value)
                principioactivo = Convert.ToString(DataGridView1.Rows.Item(X).Cells(18).Value)
                ubicacion = Convert.ToString(DataGridView1.Rows.Item(X).Cells(19).Value)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT * FROM Productos WHERE Codigo='" & codigo & "' AND CodBarra='" & barras & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else

                    lblprod.Text = "Importando producto: " & nombre
                    My.Application.DoEvents()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO productos(Codigo,CodBarra,Nombre,NombreLargo,IVA,UCompra,UVenta,UMinima,MCD,Multiplo,ProvPri,Departamento,Grupo,Ubicacion,Min,Max,PrecioCompra,PrecioVentaIVA,PrecioMaximoPublico,Existencia,Almacen3,Id_tbMoneda,Fecha,Fecha_Inicial,Fecha_Final,ClaveSat,UnidadSat,Anti,Caduca,Controlado,Laboratorio,PrincipioActivo) VALUES('" & codigo & "','" & barras & "','" & nombre & "','" & nombre & "'," & iva & ",'" & unidad & "','" & unidad & "','" & unidad & "',1,1,'" & proveedor & "','" & departamento & "','" & grupo & "','" & ubicacion & "',1,1," & preciocompra & "," & precioventa & "," & preciomaximo & "," & existencia & "," & preciocompra & ",1,'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-mm-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & claveproducto & "','" & claveunidad & "'," & antibiotico & "," & caduca & "," & controlado & ",'" & laboratorio & "','" & principioactivo & "')"


                    If cmd2.ExecuteNonQuery Then
                    Else
                        MsgBox("No se pudieron insertar los datos del producto " & nombre, vbInformation + vbOKOnly, "Delsscom Farmacias")
                    End If
                    ProgressBar1.Value = ProgressBar1.Value + 1
                    My.Application.DoEvents()

                End If
                rd1.Close()
            Next

        End If
        cnn2.Close()
        MsgBox("Datos importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        lblprod.Text = ""
        lblprod.Visible = False
        ProgressBar1.Visible = False
        ProgressBar1.Value = 0
    End Sub
End Class