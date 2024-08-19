Imports MySql.Data

Public Class frmAsignarusuarios
    Private Sub frmAsignarusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboUsuario.Items.Clear()
        Dim cnn33 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargetNube, sinfo) Then
                If .getDt(cnn33, dt, "Select Nombre from usuarios order by Nombre", sinfo) Then
                    For Each dr In dt.Rows
                        cboUsuario.Items.Add(dr(0).ToString)
                    Next
                End If
                cnn33.Close()
            End If
        End With

        llena_Usuarios(cboSucursal)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Trim(cboUsuario.Text) = "" Then MsgBox("El campo Sucursal no puede esta vacío") : Exit Sub

        Dim cnnp As New MySqlClient.MySqlConnection
        Dim sinfop As String = ""
        Dim drp As DataRow
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnnp, sTargetNube, sinfop) Then

                If .getDr(cnnp, drp, "select Id from usuarios where Nombre = '" & Trim(cboUsuario.Text.ToUpper) & "'", sinfop) Then

                    Dim varstr1 As Integer = 0
                    Dim drp1 As DataRow
                    If .getDr(cnnp, drp1, "select Id from sucursales where nombre = '" & Trim(cboSucursal.Text.ToUpper) & "'", sinfop) Then
                        varstr1 = drp1("Id").ToString
                    Else
                        If Trim(cboSucursal.Text.ToUpper) <> "" Then
                            MsgBox("La sucursal NO existe")
                            Exit Sub
                        End If
                    End If

                    If .runSp(cnnp, "update usuarios set NumSuc = " & varstr1 & " where Id = " & drp("Id").ToString & "", sinfop) Then
                        MsgBox("Registro actualizado correctamente")
                        cboSucursal.Text = ""
                        cboUsuario.Text = ""
                    End If

                Else
                    MsgBox("El usuario NO existe")
                End If
                cnnp.Close()

            End If
        End With
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub cboUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUsuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn33 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            With oData
                If .dbOpen(cnn33, sTargetNube, sinfo) Then
                    If .getDr(cnn33, dr, "Select NumSuc from usuarios where Nombre = '" & Trim(cboUsuario.Text) & "' order by Nombre", sinfo) Then
                        If dr("NumSuc").ToString > 0 Then
                            Dim dr1 As DataRow
                            If .getDr(cnn33, dr1, "select nombre from sucursales where Id = " & dr("NumSuc").ToString, sinfo) Then
                                cboSucursal.Text = dr1("nombre").ToString
                            End If
                        Else
                            cboSucursal.Text = ""
                        End If
                    End If
                    cnn33.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboUsuario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboUsuario.SelectedValueChanged
        On Error GoTo puertita
        Dim cnn33 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargetNube, sinfo) Then
                If .getDr(cnn33, dr, "Select NumSuc from usuarios where Nombre = '" & Trim(cboUsuario.Text) & "' order by Nombre", sinfo) Then
                    If dr("NumSuc").ToString > 0 Then
                        Dim dr1 As DataRow
                        If .getDr(cnn33, dr1, "select nombre from sucursales where Id = " & dr("NumSuc").ToString, sinfo) Then
                            cboSucursal.Text = dr1("nombre").ToString
                        End If
                    Else
                        cboSucursal.Text = ""
                    End If
                End If
                cnn33.Close()
            End If
        End With

        Exit Sub

puertita:

        cboSucursal.Text = ""

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
End Class