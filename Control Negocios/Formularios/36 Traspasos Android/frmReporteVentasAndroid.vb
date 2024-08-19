﻿Imports MySql.Data

Public Class frmReporteVentasAndroid
    Private Sub frmReporteVentasAndroid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cnnp As New MySqlClient.MySqlConnection
        Dim sinfop As String = ""
        Dim drp As DataRow
        Dim dtp As New DataTable
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnnp, sTargetNube, sinfop) Then

                If .getDt(cnnp, dtp, "select Nombre from usuarios where NumSuc > 0 ", sinfop) Then
                    For Each drp In dtp.Rows
                        ComboBox1.Items.Add(drp(0).ToString)
                    Next
                End If

                If .getDt(cnnp, dtp, "Select nombre from sucursales where nombre <> 'MATRIZ' order by nombre", sinfop) Then
                    For Each drp In dtp.Rows
                        ComboBox2.Items.Add(drp(0).ToString)
                    Next
                End If

                cnnp.Close()

            End If
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        DataGridView1.Rows.Clear()

        Dim cnnp As New MySqlClient.MySqlConnection
        Dim sinfop As String = ""
        Dim drp As DataRow
        Dim dtp As New DataTable
        Dim odata As New ToolKitSQL.myssql
        Dim varstr As String = ""
        With odata
            If .dbOpen(cnnp, sTargetNube, sinfop) Then

                Dim varIdUsu As Integer = 0
                Dim varAlias As String = ""
                Dim drusu As DataRow
                If .getDr(cnnp, drusu, "select Id, Alias from usuarios where Nombre = '" & Trim(ComboBox1.Text) & "' ", sinfop) Then
                    varIdUsu = drusu("Id").ToString
                    varAlias = drusu("Alias").ToString
                End If

                If Trim(ComboBox1.Text) <> "" Then
                    varstr = "select * from ventas where NumSuc > 0 and Usuario = '" & varAlias & "' order by Id"
                Else
                    varstr = "select * from ventas where NumSuc > 0 order by Id"
                End If


                If .getDt(cnnp, dtp, varstr, sinfop) Then

                    For Each drp In dtp.Rows

                        Dim varNumsuc As String = ""
                        Dim drsucu As DataRow
                        If .getDr(cnnp, drsucu, "select nombre from sucursales where Id= " & drp("NumSuc").ToString & "", sinfop) Then
                            varNumsuc = drsucu("nombre").ToString
                        End If

                        DataGridView1.Rows.Add(drp("Id").ToString, drp("NomCliente").ToString, drp("Total").ToString, drp("FechaHora").ToString, drp("Usuario").ToString, drp("Status").ToString, varNumsuc)

                    Next

                End If

                MsgBox("Reporte Terminado")

                cnnp.Close()

            End If
        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView2.Rows.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        DataGridView2.Rows.Clear()

        If Trim(ComboBox2.Text) = "" Then
            MsgBox("hay que seleccionar una sucursal para poder generar el reporte")
        End If

        Dim cnnp As New MySqlClient.MySqlConnection
        Dim sinfop As String = ""
        Dim drp As DataRow
        Dim dtp As New DataTable
        Dim odata As New ToolKitSQL.myssql
        Dim varstr As String = ""
        With odata
            If .dbOpen(cnnp, sTargetNube, sinfop) Then

                Dim varIdSuc As String = ""
                Dim drsucu As DataRow
                If .getDr(cnnp, drsucu, "select Id from sucursales where nombre = '" & Trim(ComboBox2.Text) & "'", sinfop) Then
                    varIdSuc = drsucu("Id").ToString
                End If

                varstr = "select * from productos2 where NumSuc = " & varIdSuc & ""

                If .getDt(cnnp, dtp, varstr, sinfop) Then

                    For Each drp In dtp.Rows



                        DataGridView2.Rows.Add(drp("Id").ToString, drp("Codigo").ToString, drp("Descripcion").ToString, drp("Existencia").ToString, Trim(ComboBox2.Text), False)

                    Next

                End If

                MsgBox("Reporte Terminado")

                cnnp.Close()

            End If
        End With


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim existensuc As Integer = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            If DataGridView2.Rows(i).Cells(5).Value Then
                existensuc += 1
            End If
        Next

        If existensuc = 0 Then
            MsgBox("Hay que seleccionar mínimo un Producto para devolver el inventario")
            Exit Sub
        End If


        Dim cnn10 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata10 As New ToolKitSQL.myssql
        Dim ssql3 As String = ""
        Dim varFecha As String = Format(Date.Now, "dd/MM/yyyy")

        Dim sSQL As String = "insert into traspasos(Usuario,TotalProd,Fecha,Tipo,Cargado,Sucursal) " &
                       "values(''," & existensuc & ",'" & varFecha & "','ENTRADA',1,'" & Trim(ComboBox2.Text) & "')"
        Dim sinfo As String = ""

        Dim cnnp As New MySqlClient.MySqlConnection
        Dim sinfop As String = ""
        Dim drp As DataRow
        Dim odatap As New ToolKitSQL.myssql

        With odata10

            If .dbOpen(cnn10, sTargett, sinfo) Then

                If odatap.dbOpen(cnnp, sTargetNube, sinfop) Then

                    If .runSp(cnn10, sSQL, sinfo) Then

                        Dim varidtraspaso As Integer = maxIdTras()

                        For i = 0 To DataGridView2.Rows.Count - 1
                            If DataGridView2.Rows(i).Cells(5).Value Then

                                sSQL = "insert into traspasosdetalle(IdTraspaso,Codigo,Descripcion,Cantidad) " &
                               "values(" & varidtraspaso & ",'" & DataGridView2.Rows(i).Cells(1).Value.ToString & "','" & DataGridView2.Rows(i).Cells(2).Value.ToString & "'," & Replace(DataGridView2.Rows(i).Cells(3).Value.ToString, ",", "") & ")"
                                If .runSp(cnn10, sSQL, sinfo) Then

                                    Dim dr2 As DataRow
                                    .getDr(cnn10, dr2, "select Id,Existencia,Multiplo from productos where Codigo = '" & DataGridView2.Rows(i).Cells(1).Value.ToString & "'", sinfo)

                                    If .runSp(cnn10, "update productos set Existencia = Existencia + " & CDec(Replace(DataGridView2.Rows(i).Cells(3).Value.ToString, ",", "")) & ", Cargado = 0 where Codigo = '" & DataGridView2.Rows(i).Cells(1).Value.ToString & "'", sinfo) Then


                                        'cardex local
                                        Dim MyExist As String = 0
                                        Dim MyNewEsist As String = 0

                                        MyExist = FormatNumber(CDec(dr2("Existencia").ToString), 2)
                                        MyNewEsist = CDec(MyExist) + CDec(DataGridView2.Rows(i).Cells(3).Value.ToString)

                                        Dim varidsucursal As Integer = 0
                                        varidsucursal = dameIdSucursalNube(DataGridView2.Rows(i).Cells(4).Value.ToString)

                                        Dim ssql31 As String = ""
                                        ssql31 = "insert into cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio,NumSuc) values('" & DataGridView2.Rows(i).Cells(1).Value.ToString & "','" & DataGridView2.Rows(i).Cells(2).Value.ToString & "','REGRESO INVENTARIO Android'," & CDec(DataGridView2.Rows(i).Cells(3).Value.ToString) & ",'0','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','ADMIN','" & MyExist & "','" & MyNewEsist & "',''," & varidsucursal & ")"

                                        .runSp(cnn10, ssql31, sinfo)


                                        'cardex nube
                                        Dim dr3 As DataRow
                                        odatap.getDr(cnnp, dr3, "select Id,Existencia from productos2 where Codigo = '" & DataGridView2.Rows(i).Cells(1).Value.ToString & "'", sinfo)

                                        MyExist = FormatNumber(CDec(dr3("Existencia").ToString), 2)
                                        MyNewEsist = CDec(MyExist) - CDec(DataGridView2.Rows(i).Cells(3).Value.ToString)

                                        ssql31 = "insert into cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio,NumSuc) values('" & DataGridView2.Rows(i).Cells(1).Value.ToString & "','" & DataGridView2.Rows(i).Cells(2).Value.ToString & "','REGRESO INVENTARIO Android'," & CDec(DataGridView2.Rows(i).Cells(3).Value.ToString) & ",'0','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','ADMIN','" & MyExist & "','" & MyNewEsist & "',''," & varidsucursal & ")"

                                        odatap.runSp(cnnp, ssql31, sinfo)

                                        'eliminar el producto
                                        odatap.runSp(cnnp, "delete from productos2 where Codigo = '" & DataGridView2.Rows(i).Cells(1).Value.ToString & "' and NumSuc = " & varidsucursal, sinfop)

                                    End If

                                End If


                            End If
                        Next

                    End If

                    cnnp.Close()
                End If

                cnn10.Close()
            End If
        End With



        MsgBox("Inventario Regresado Correctamente")


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        For i = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(i).Cells(5).Value = True
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        For i = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(i).Cells(5).Value = False
        Next
    End Sub

    Function maxIdTras() As Integer
        Dim cnn3 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dr3 As DataRow
        Dim sinfo As String = ""
        Dim oData3 As New ToolKitSQL.myssql
        With oData3
            If .dbOpen(cnn3, sTargett, sinfo) Then
                If .getDr(cnn3, dr3, "select max(Id) as XD from traspasos where Eliminado = 0", sinfo) Then
                    cnn3.Close()
                    Return dr3(0).ToString
                End If
                cnn3.Close()
                Return 0
            End If
        End With
    End Function

    Function dameIdSucursalNube(varsucu As String) As Integer
        Dim cnn33 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dr3 As DataRow
        Dim sinfo As String = ""
        Dim oData33 As New ToolKitSQL.myssql
        With oData33
            If .dbOpen(cnn33, sTargetNube, sinfo) Then
                If .getDr(cnn33, dr3, "select Id from sucursales where nombre = '" & varsucu & "'", sinfo) Then
                    cnn33.Close()
                    Return dr3(0).ToString
                End If
                cnn33.Close()
                Return 0
            End If
        End With
    End Function
End Class