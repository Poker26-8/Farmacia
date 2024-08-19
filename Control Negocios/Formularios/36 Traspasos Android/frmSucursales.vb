Imports MySql.Data

Public Class frmSucursales
    Private Sub frmSucursales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llena_Usuarios(cboSucursal)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Trim(cboSucursal.Text) = "" Then MsgBox("El campo Sucursal no puede esta vacío") : Exit Sub
        If Trim(cboSucursal.Text.ToUpper) = "MATRIZ" Then MsgBox("El campo Sucursal no puede ser MATRIZ, hay que cambiarlo") : Exit Sub

        Dim cnnp As New MySqlClient.MySqlConnection
        Dim sinfop As String = ""
        Dim drp As DataRow
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnnp, sTargetNube, sinfop) Then

                If .getDr(cnnp, drp, "select Id from sucursales where nombre = '" & Trim(cboSucursal.Text) & "'", sinfop) Then
                    If .runSp(cnnp, "Delete from sucursales where Id = " & drp("Id").ToString & "", sinfop) Then
                        llena_Usuarios(cboSucursal)
                        MsgBox("Registro Eliminado Correctamente")
                        cboSucursal.Text = ""
                    End If
                Else
                    MsgBox("La sucursal NO existe")
                End If
                cnnp.Close()

            End If
        End With
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Trim(cboSucursal.Text) = "" Then MsgBox("El campo Sucursal no puede esta vacío") : Exit Sub
        If Trim(cboSucursal.Text.ToUpper) = "MATRIZ" Then MsgBox("El campo Sucursal no puede ser MATRIZ, hay que cambiarlo") : Exit Sub

        Dim cnnp As New MySqlClient.MySqlConnection
        Dim sinfop As String = ""
        Dim drp As DataRow
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnnp, sTargetNube, sinfop) Then

                Dim varstr1 As String = ""
                Dim varstr2 As String = ""
                If .getDr(cnnp, drp, "select FechaInicio,FechaTermino from sucursales where Id = 1 or nombre = 'MATRIZ'", sinfop) Then
                    varstr1 = drp("FechaInicio").ToString
                    varstr2 = drp("FechaTermino").ToString
                End If

                If .getDr(cnnp, drp, "select nombre from sucursales where nombre = '" & Trim(cboSucursal.Text.ToUpper) & "'", sinfop) Then
                    MsgBox("La sucursal ya existe")
                Else
                    If .runSp(cnnp, "insert into sucursales(nombre,direccion,FechaInicio,FechaTermino) values('" & Trim(cboSucursal.Text.ToUpper) & "','','" & varstr1 & "','" & varstr2 & "') ", sinfop) Then
                        llena_Usuarios(cboSucursal)
                        MsgBox("Registro guardado correctamente")
                        cboSucursal.Text = ""
                    End If
                End If
                cnnp.Close()

            End If
        End With
    End Sub
    Function llena_Usuarios(ByRef combo As ComboBox)
        combo.Items.Clear()
        Dim cnn33 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargetNube, sinfo) Then
                If .getDt(cnn33, dt, "Select nombre from sucursales where nombre <> 'MATRIZ' order by nombre", sinfo) Then
                    For Each dr In dt.Rows
                        combo.Items.Add(dr(0).ToString)
                    Next
                End If
                cnn33.Close()
            End If
        End With
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class