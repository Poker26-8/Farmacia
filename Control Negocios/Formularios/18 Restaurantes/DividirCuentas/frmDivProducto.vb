Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class frmDivProducto

    Private filaSeleccionada As New Dictionary(Of Integer, Boolean)()

    Dim totalventa As Double = 0

    Dim idempleas As Double = 0

    Public abecedario As List(Of Char) = ObtenerAbecedario()
    Private Sub frmDivProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            totalventa = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cantidad,Codigo,Nombre,Precio,Total FROM comandas WHERE Nmesa='" & lblorigen.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdCaptura.Rows.Add(FormatNumber(rd1(0).ToString, 2),
                                        rd1(1).ToString,
                                        rd1(2).ToString,
                                        FormatNumber(rd1(3).ToString, 2),
                                        FormatNumber(rd1(4).ToString, 2)
                                        )

                    totalventa = totalventa + rd1(4).ToString
                End If
            Loop
            rd1.Close()
            cnn1.Close()

            lblTotalVenta.Text = FormatNumber(totalventa, 2)

            Dim letra As String = ""
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Letra,IdEmpleado from mesasxempleados where Mesa='" & lblorigen.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    letra = rd1(0).ToString
                    idempleas = rd1(1).ToString

                    txtabcd.Text = ObtenerSiguienteLetra(letra)

                End If
            End If
            rd1.Close()
            cnn1.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function ObtenerSiguienteLetra(letraActual As Char) As Char
        ' Convertir la letra a mayúscula para manejar casos mixtos
        letraActual = Char.ToUpper(letraActual)

        ' Obtener el índice de la letra actual en el abecedario
        Dim indice As Integer = abecedario.IndexOf(letraActual)

        ' Calcular el índice de la siguiente letra
        Dim indiceSiguiente As Integer = (indice + 1) Mod abecedario.Count

        ' Devolver la siguiente letra
        Return abecedario(indiceSiguiente)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdCaptura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellContentClick

        ' Verificar si se hizo clic en la columna del botón "Eliminar"
        If e.ColumnIndex = grdCaptura.Columns(5).Index AndAlso e.RowIndex >= 0 Then
            ' Verificar si la fila ya ha sido seleccionada
            If Not filaSeleccionada.ContainsKey(e.RowIndex) Then
                ' La fila aún no ha sido seleccionada, cambiar el color de fondo a uno
                ' y registrar que ha sido seleccionada
                grdCaptura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red ' Cambiar a un color
                filaSeleccionada.Add(e.RowIndex, True)
            Else
                ' La fila ya ha sido seleccionada, cambiar el color de fondo a otro
                ' y actualizar su estado
                If filaSeleccionada(e.RowIndex) Then
                    grdCaptura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White ' Cambiar a otro color
                    filaSeleccionada(e.RowIndex) = False
                Else
                    grdCaptura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red ' Cambiar a otro color
                    filaSeleccionada(e.RowIndex) = True
                End If
            End If
        End If
    End Sub

    Public Function FilasSeleccionadas() As List(Of DataGridViewRow)
        Dim filas As New List(Of DataGridViewRow)()

        For Each row As DataGridViewRow In grdCaptura.Rows
            If filaSeleccionada.ContainsKey(row.Index) AndAlso filaSeleccionada(row.Index) Then
                If row.DefaultCellStyle.BackColor = Color.Red Then
                    filas.Add(row)
                End If
            End If
        Next

        Return filas
    End Function


    Private Sub btnAdd1_Click(sender As Object, e As EventArgs) Handles btnAdd1.Click

        Dim nuevot As Double = 0
        Dim TOTAL1 As Double = 0

        ' Obtener las filas seleccionadas con color rojo
        Dim filasSeleccionadas As List(Of DataGridViewRow) = Me.FilasSeleccionadas()

        ' Resto del código...

        ' Agregar las filas al otro DataGridView (grdOtro)
        For Each row As DataGridViewRow In filasSeleccionadas
            grd1.Rows.Add(row.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value).ToArray())
        Next


        For MONKEYD As Integer = 0 To grd1.Rows.Count - 1
            TOTAL1 = TOTAL1 + grd1.Rows(MONKEYD).Cells(4).Value.ToString
        Next
        lblTotal1.Text = FormatNumber(TOTAL1, 2)


        ' Limpiar las filas seleccionadas en el DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            filaSeleccionada(row.Index) = False
            row.DefaultCellStyle.BackColor = grdCaptura.DefaultCellStyle.BackColor ' Cambiar al color por defecto
        Next

        ' Eliminar las filas seleccionadas del DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            ' Eliminar la fila del DataGridView
            grdCaptura.Rows.Remove(row)
            ' Limpiar la selección y restaurar el color de fondo en el diccionario y en la fila
            filaSeleccionada.Remove(row.Index)
        Next


        'calcular el total del grid original
        For dx As Integer = 0 To grdCaptura.Rows.Count - 1
            nuevot = nuevot + grdCaptura.Rows(dx).Cells(4).Value.ToString
        Next
        lblTotalVenta.Text = FormatNumber(nuevot, 2)

        btnAceptar.Enabled = True
    End Sub

    Private Sub btnAdd2_Click(sender As Object, e As EventArgs) Handles btnAdd2.Click

        Dim nuevot As Double = 0
        Dim TOTAL1 As Double = 0

        ' Obtener las filas seleccionadas con color rojo
        Dim filasSeleccionadas As List(Of DataGridViewRow) = Me.FilasSeleccionadas()

        ' Resto del código...

        ' Agregar las filas al otro DataGridView (grdOtro)
        For Each row As DataGridViewRow In filasSeleccionadas
            grd2.Rows.Add(row.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value).ToArray())
        Next


        For MONKEYD As Integer = 0 To grd2.Rows.Count - 1
            TOTAL1 = TOTAL1 + grd2.Rows(MONKEYD).Cells(4).Value.ToString
        Next
        lblTotal2.Text = FormatNumber(TOTAL1, 2)


        ' Limpiar las filas seleccionadas en el DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            filaSeleccionada(row.Index) = False
            row.DefaultCellStyle.BackColor = grdCaptura.DefaultCellStyle.BackColor ' Cambiar al color por defecto
        Next

        ' Eliminar las filas seleccionadas del DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            ' Eliminar la fila del DataGridView
            grdCaptura.Rows.Remove(row)
            ' Limpiar la selección y restaurar el color de fondo en el diccionario y en la fila
            filaSeleccionada.Remove(row.Index)
        Next


        'calcular el total del grid original
        For dx As Integer = 0 To grdCaptura.Rows.Count - 1
            nuevot = nuevot + grdCaptura.Rows(dx).Cells(4).Value.ToString
        Next
        lblTotalVenta.Text = FormatNumber(nuevot, 2)

        btnAceptar.Enabled = True
    End Sub

    Private Sub btnAdd3_Click(sender As Object, e As EventArgs) Handles btnAdd3.Click

        Dim nuevot As Double = 0
        Dim TOTAL1 As Double = 0

        ' Obtener las filas seleccionadas con color rojo
        Dim filasSeleccionadas As List(Of DataGridViewRow) = Me.FilasSeleccionadas()

        ' Resto del código...

        ' Agregar las filas al otro DataGridView (grdOtro)
        For Each row As DataGridViewRow In filasSeleccionadas
            grd3.Rows.Add(row.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value).ToArray())
        Next


        For MONKEYD As Integer = 0 To grd3.Rows.Count - 1
            TOTAL1 = TOTAL1 + grd3.Rows(MONKEYD).Cells(4).Value.ToString
        Next
        lblTotal3.Text = FormatNumber(TOTAL1, 2)


        ' Limpiar las filas seleccionadas en el DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            filaSeleccionada(row.Index) = False
            row.DefaultCellStyle.BackColor = grdCaptura.DefaultCellStyle.BackColor ' Cambiar al color por defecto
        Next

        ' Eliminar las filas seleccionadas del DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            ' Eliminar la fila del DataGridView
            grdCaptura.Rows.Remove(row)
            ' Limpiar la selección y restaurar el color de fondo en el diccionario y en la fila
            filaSeleccionada.Remove(row.Index)
        Next


        'calcular el total del grid original
        For dx As Integer = 0 To grdCaptura.Rows.Count - 1
            nuevot = nuevot + grdCaptura.Rows(dx).Cells(4).Value.ToString
        Next
        lblTotalVenta.Text = FormatNumber(nuevot, 2)

        btnAceptar.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim nuevonombre As String = ""
            Dim NUEVOFOLIO As Integer = 0
            Dim ubi As String = ""

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT MAX(Id) FROM comanda1"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    NUEVOFOLIO = IIf(rd3(0).ToString = "", 0, rd3(0).ToString) + 1
                End If
            Else
                NUEVOFOLIO = 1
            End If
            rd3.Close()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Ubicacion FROM mesa WHERE Nombre_mesa='" & lblorigen.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    ubi = rd3(0).ToString
                End If
            End If
            rd3.Close()
            cnn3.Close()


            If grd1.Rows.Count <> 0 Then

                nuevonombre = lblorigen.Text & "_" & txtabcd.Text

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM mesasxempleados WHERE Mesa='" & nuevonombre & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Mesasxempleados SET Letra='" & txtabcd.Text & "' WHERE Mesa='" & lblorigen.Text & "'"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo,Impresion) VALUES('" & nuevonombre & "',1,'Ocupada',0,0,0,''," & idempleas & ",'','" & ubi & "',0,0,'2',0)"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesasxempleados(Mesa,IdEmpleado,Grupo,Temporal,Letra) VALUES('" & nuevonombre & "',0,'',1,'')"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO comanda1(IdCliente,Nombre,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,MontoEfecCanc,Status,Comisionista,Facturado,TComensales,Domi) VALUES(0,'" & nuevonombre & "',''," & lblTotal1.Text & ",0," & lblTotal1.Text & ",0,0,0," & lblTotal1.Text & ",'" & frmNuevoPagar.lblusuario2.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','',0,'','',0,'',0)"
                    cmd2.ExecuteNonQuery()



                    For LUFFY As Integer = 0 To grd1.Rows.Count - 1

                        Dim cant As Double = grd1.Rows(LUFFY).Cells(0).Value.ToString
                        Dim cod As String = grd1.Rows(LUFFY).Cells(1).Value.ToString
                        Dim nom As String = grd1.Rows(LUFFY).Cells(2).Value.ToString
                        Dim precio As Double = grd1.Rows(LUFFY).Cells(3).Value.ToString
                        Dim total As Double = grd1.Rows(LUFFY).Cells(4).Value.ToString

                        Dim unidad As String = ""
                        Dim depa As String = ""
                        Dim grupo As String = ""
                        Dim gprint As String = ""

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cod & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                unidad = rd1("UVenta").ToString
                                depa = rd1("Departamento").ToString
                                grupo = rd1("Grupo").ToString
                                gprint = rd1("GPrint").ToString
                            End If
                        End If
                        rd1.Close()
                        cnn1.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE comandas SET Nmesa='" & nuevonombre & "' WHERE Nmesa='" & lblorigen.Text & "' AND Codigo='" & cod & "' AND Nombre='" & nom & "'"
                        cmd2.ExecuteNonQuery()

                        'cmd2 = cnn2.CreateCommand
                        'cmd2.CommandText = "INSERT INTO comandas(Id,NMESA,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostVUE,Descuento,Precio,Total,PrecioSinIva,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT,Estado) VALUES(" & NUEVOFOLIO & ",'" & nuevonombre & "','" & cod & "','" & nom & "','" & unidad & "'," & cant & ",0,0,0,0," & precio & "," & total & ",0,0,'" & Format(Date.Now, "yyyy-MM-dd") & "','',0,'" & depa & "','" & grupo & "','1','RESTA','','','" & lblmesero.Text & "','1',1,'" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "',0)"
                        'cmd2.ExecuteNonQuery()
                    Next
                    cnn2.Close()

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT Letra from mesasxempleados where Mesa='" & lblorigen.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            txtabcd.Text = ObtenerSiguienteLetra(rd3(0).ToString)
                        End If
                    End If
                    rd3.Close()
                    cnn3.Close()


                End If
                rd1.Close()
                cnn1.Close()

            End If



            If grd2.Rows.Count <> 0 Then

                nuevonombre = lblorigen.Text & "_" & txtabcd.Text

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM mesasxempleados WHERE Mesa='" & nuevonombre & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Mesasxempleados SET Letra='" & txtabcd.Text & "' WHERE Mesa='" & lblorigen.Text & "'"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo,Impresion) VALUES('" & nuevonombre & "',1,'Ocupada',0,0,0,''," & idempleas & ",'','" & ubi & "',0,0,'2',0)"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesasxempleados(Mesa,IdEmpleado,Grupo,Temporal,Letra) VALUES('" & nuevonombre & "',0,'',1,'')"
                    cmd2.ExecuteNonQuery()


                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO comanda1(IdCliente,Nombre,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,MontoEfecCanc,Status,Comisionista,Facturado,TComensales,Domi) VALUES(0,'" & nuevonombre & "',''," & lblTotal2.Text & ",0," & lblTotal2.Text & ",0,0,0," & lblTotal2.Text & ",'" & frmNuevoPagar.lblusuario2.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','',0,'','',0,'',0)"
                    cmd2.ExecuteNonQuery()

                    For LUFFY As Integer = 0 To grd2.Rows.Count - 1

                        Dim cant As Double = grd2.Rows(LUFFY).Cells(0).Value.ToString
                        Dim cod As String = grd2.Rows(LUFFY).Cells(1).Value.ToString
                        Dim nom As String = grd2.Rows(LUFFY).Cells(2).Value.ToString
                        Dim precio As Double = grd2.Rows(LUFFY).Cells(3).Value.ToString
                        Dim total As Double = grd2.Rows(LUFFY).Cells(4).Value.ToString

                        Dim unidad As String = ""
                        Dim depa As String = ""
                        Dim grupo As String = ""
                        Dim gprint As String = ""

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cod & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                unidad = rd1("UVenta").ToString
                                depa = rd1("Departamento").ToString
                                grupo = rd1("Grupo").ToString
                                gprint = rd1("GPrint").ToString
                            End If
                        End If
                        rd1.Close()
                        cnn1.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE comandas SET Nmesa='" & nuevonombre & "' WHERE Nmesa='" & lblorigen.Text & "' AND Codigo='" & cod & "' AND Nombre='" & nom & "'"
                        cmd2.ExecuteNonQuery()
                    Next
                    cnn2.Close()

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT Letra from mesasxempleados where Mesa='" & lblorigen.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            txtabcd.Text = ObtenerSiguienteLetra(rd3(0).ToString)
                        End If
                    End If
                    rd3.Close()
                    cnn3.Close()

                End If
                rd1.Close()
                cnn1.Close()

            End If



            If grd3.Rows.Count <> 0 Then

                nuevonombre = lblorigen.Text & "_" & txtabcd.Text

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM mesasxempleados WHERE Mesa='" & nuevonombre & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Mesasxempleados SET Letra='" & txtabcd.Text & "' WHERE Mesa='" & lblorigen.Text & "'"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo,Impresion) VALUES('" & nuevonombre & "',1,'Ocupada',0,0,0,''," & idempleas & ",'','" & ubi & "',0,0,'2',0)"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesasxempleados(Mesa,IdEmpleado,Grupo,Temporal,Letra) VALUES('" & nuevonombre & "',0,'',1,'')"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO comanda1(IdCliente,Nombre,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,MontoEfecCanc,Status,Comisionista,Facturado,TComensales,Domi) VALUES(0,'" & nuevonombre & "',''," & lblTotal3.Text & ",0," & lblTotal3.Text & ",0,0,0," & lblTotal3.Text & ",'" & frmNuevoPagar.lblusuario2.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','',0,'','',0,'',0)"
                    cmd2.ExecuteNonQuery()

                    For LUFFY As Integer = 0 To grd3.Rows.Count - 1

                        Dim cant As Double = grd3.Rows(LUFFY).Cells(0).Value.ToString
                        Dim cod As String = grd3.Rows(LUFFY).Cells(1).Value.ToString
                        Dim nom As String = grd3.Rows(LUFFY).Cells(2).Value.ToString
                        Dim precio As Double = grd3.Rows(LUFFY).Cells(3).Value.ToString
                        Dim total As Double = grd3.Rows(LUFFY).Cells(4).Value.ToString

                        Dim unidad As String = ""
                        Dim depa As String = ""
                        Dim grupo As String = ""
                        Dim gprint As String = ""

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cod & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                unidad = rd1("UVenta").ToString
                                depa = rd1("Departamento").ToString
                                grupo = rd1("Grupo").ToString
                                gprint = rd1("GPrint").ToString
                            End If
                        End If
                        rd1.Close()
                        cnn1.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE comandas SET Nmesa='" & nuevonombre & "' WHERE Nmesa='" & lblorigen.Text & "' AND Codigo='" & cod & "' AND Nombre='" & nom & "'"
                        cmd2.ExecuteNonQuery()
                    Next
                    cnn2.Close()

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT Letra from mesasxempleados where Mesa='" & lblorigen.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then

                            txtabcd.Text = ObtenerSiguienteLetra(rd3(0).ToString)
                        End If
                    End If
                    rd3.Close()
                    cnn3.Close()

                End If
                rd1.Close()
                cnn1.Close()
            End If
            Me.Close()
            frmNuevoPagar.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Function ObtenerAbecedario() As List(Of Char)
        Dim letrasAbecedario As New List(Of Char)()
        For i As Integer = Asc("A") To Asc("Z")
            letrasAbecedario.Add(Chr(i))
        Next
        Return letrasAbecedario
    End Function

    Private Function CrearNombreUnico(nombreBase As String) As String
        Dim nuevoNombre As String = nombreBase
        Dim indice As Integer = 0
        Dim letra As Char = "A"

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Nombre_mesa FROM mesa WHERE nOMBRE_MESA = '" & lblorigen.Text & "'"
        rd1 = cmd1.ExecuteReader
        While rd1.Read
            If rd1.HasRows Then
                indice += 1

                If indice >= abecedario.Count Then
                    ' Si se agotan las letras del abecedario, añadir un sufijo numérico
                    nuevoNombre = $"{nombreBase}_{indice}"

                Else
                    ' Agregar una letra del abecedario
                    letra = abecedario(indice)
                    nuevoNombre = $"{nombreBase}_{letra}"

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo,Impresion) VALUES('" & nuevoNombre & "',1,'Ocupada',0,0,0,'',0,'" & frmNuevoPagar.lblMesero.Text & "','',0,0,'2',0)"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesasxempleados(Mesa,IdEmpleado,Grupo,Temporal,Letra) VALUES('" & nuevoNombre & "',0,'',1,'" & letra & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            End If
        End While
        rd1.Close()
        cnn1.Close()
        cnn2.Close()

        Return nuevoNombre
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs)




    End Sub
End Class