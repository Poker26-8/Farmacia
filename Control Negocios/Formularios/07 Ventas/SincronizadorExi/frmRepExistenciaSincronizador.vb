Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class frmRepExistenciaSincronizador

    Dim dt1 As New DataTable
    Dim dt2 As New DataTable

    Public idsucursal As Integer = 0
    Private Sub frmRepExistenciaSincronizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbosucursal.Focus.Equals(True)


    End Sub

    Private Sub cbosucursal_DropDown(sender As Object, e As EventArgs) Handles cbosucursal.DropDown
        Try
            cbosucursal.Items.Clear()
            Dim cnn As MySqlConnection = New MySqlConnection
            Dim sSQL As String = "SELECT Distinct nombre FROM sucursales order by Nombre"
            Dim dt1 As New DataTable
            Dim dr As DataRow
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            With oData
                If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                    If .getDt(cnn, dt1, sSQL, "etres") Then
                        For Each dr In dt1.Rows
                            cbosucursal.Items.Add(dr("nombre").ToString)
                        Next
                    End If
                    cnn.Close()
                End If
            End With
        Catch ex As Exception
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnuevo_Click(sender As Object, e As EventArgs) Handles btnuevo.Click
        cbosucursal.Text = ""
        cboFiltro.Text = ""
        grdCaptura.Rows.Clear()
        rbTodos.Checked = False
        rbCodigo.Checked = False
        rbDesc.Checked = False
        llena_Descipciones()
        llena_Codigos()
        cbosucursal.Focus.Equals(True)
    End Sub

    Private Sub cboFiltro_DropDown(sender As Object, e As EventArgs) Handles cboFiltro.DropDown
        cboFiltro.Items.Clear()
        Dim drllenado As DataRow

        llena_Descipciones()
        llena_Codigos()

        My.Application.DoEvents()

        If rbDesc.Checked = True Then
            For Each drllenado In dt1.Rows
                cboFiltro.Items.Add(drllenado(0).ToString)
            Next
        ElseIf rbCodigo.Checked = True Then
            For Each drllenado In dt2.Rows
                cboFiltro.Items.Add(drllenado(0).ToString)
            Next
        End If
    End Sub

    Sub llena_Descipciones()
        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        With odata1
            If .dbOpen(cnn1, sTargetdSincro, sinfo1) Then

                If cbosucursal.Text = "" Then

                    If .getDt(cnn1, dt1, "SELECT DISTINCT Nombre FROM productos ORDER BY Nombre", sinfo1) Then

                    End If

                Else
                    If .getDt(cnn1, dt1, "SELECT DISTINCT Nombre FROM productos WHERE NumSuc=" & idsucursal & " ORDER BY Nombre", sinfo1) Then

                    End If
                End If

                cnn1.Close()
            End If
        End With
    End Sub

    Sub llena_Codigos()
        Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo2 As String = ""
        Dim odata2 As New ToolKitSQL.myssql
        With odata2
            If .dbOpen(cnn2, sTargetdSincro, sinfo2) Then

                If cbosucursal.Text = "" Then
                    If .getDt(cnn2, dt2, "SELECT DISTINCT Codigo FROM productos order by Codigo", sinfo2) Then
                    End If
                Else
                    If .getDt(cnn2, dt2, "SELECT DISTINCT Codigo FROM productos WHERE NumSuc=" & idsucursal & " order by Codigo", sinfo2) Then
                    End If
                End If

                cnn2.Close()
            End If
        End With
    End Sub

    Private Sub cbosucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbosucursal.SelectedValueChanged
        Dim CNN1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim SINFO As String = ""
        Dim ODATA As New ToolKitSQL.myssql
        Dim drLoc As DataRow
        With ODATA
            .dbOpen(CNN1, sTargetdSincro, SINFO)
            If .getDr(CNN1, drLoc, "SELECT Id FROM sucursales WHERE Nombre='" & cbosucursal.Text & "'", SINFO) Then
                idsucursal = drLoc(0).ToString
            End If
        End With
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim cnn3 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo3 As String = ""
        Dim odata3 As New ToolKitSQL.myssql
        Dim dt3 As New DataTable
        Dim dr3 As DataRow
        grdCaptura.Rows.Clear()

        If (rbTodos.Checked) Then
            With odata3
                If .dbOpen(cnn3, sTargetdSincro, sinfo3) Then

                    If cbosucursal.Text = "" Then

                        If .getDt(cnn3, dt3, "SELECT P.Id, P.Codigo, P.Nombre ,P.PrecioVentaIVA, P.exitencia, S.nombre as sucursal FROM productos P, sucursales S WHERE P.NumSuc= S.Id", sinfo3) Then
                            For Each dr3 In dt3.Rows
                                grdCaptura.Rows.Add(dr3(5).ToString, dr3(1).ToString, dr3(2).ToString, dr3(4).ToString, dr3(3).ToString)
                            Next
                        End If
                        cnn3.Close()

                    Else

                        If .getDt(cnn3, dt3, "SELECT Codigo, Nombre ,PrecioVentaIVA, exitencia FROM productos WHERE NumSuc=" & idsucursal & "", sinfo3) Then

                            For Each dr3 In dt3.Rows
                                grdCaptura.Rows.Add(cbosucursal.Text, dr3(0).ToString, dr3(1).ToString, dr3(3).ToString, dr3(2).ToString)
                            Next

                        End If

                    End If


                End If
            End With

        ElseIf (rbDesc.Checked) Then

            If cboFiltro.Text = "" Then MsgBox("Debe seleccionar o escribir un producto") : Exit Sub


            With odata3
                If .dbOpen(cnn3, sTargetdSincro, sinfo3) Then

                    If cbosucursal.Text = "" Then

                        If .getDt(cnn3, dt3, "select P.Id, P.Codigo, P.Nombre as descripcion, P.PrecioVentaIVA, P.exitencia, S.nombre as sucursal from productos P, sucursales S where P.NumSuc = S.Id and P.Nombre like '%" & cboFiltro.Text & "%' ", sinfo3) Then
                            For Each dr3 In dt3.Rows
                                grdCaptura.Rows.Add(dr3(5).ToString, dr3(1).ToString, dr3(2).ToString, dr3(4).ToString, dr3(3).ToString)
                            Next
                        End If
                        cnn3.Close()
                    Else
                        If .getDt(cnn3, dt3, "select Codigo, Nombre, PrecioVentaIVA, exitencia from productos WHERE NumSuc=" & idsucursal & " and Nombre like '%" & cboFiltro.Text & "%' ", sinfo3) Then
                            For Each dr3 In dt3.Rows
                                grdCaptura.Rows.Add(cbosucursal.Text, dr3(0).ToString, dr3(1).ToString, dr3(3).ToString, dr3(2).ToString)
                            Next
                        End If
                        cnn3.Close()
                    End If
                End If
            End With

        ElseIf (rbCodigo.Checked) Then

            If cboFiltro.Text = "" Then MsgBox("Debe seleccionar o escribir un producto") : Exit Sub

            With odata3
                If .dbOpen(cnn3, sTargetdSincro, sinfo3) Then

                    If cbosucursal.Text = "" Then
                        If .getDt(cnn3, dt3, "select P.Id, P.Codigo, P.Nombre as descripcion, P.PrecioVentaIVA, P.exitencia, S.nombre as sucursal from productos P, sucursales S where P.NumSuc = S.Id and P.Codigo = '" & cboFiltro.Text & "' ", sinfo3) Then
                            For Each dr3 In dt3.Rows
                                grdCaptura.Rows.Add(dr3(5).ToString, dr3(1).ToString, dr3(2).ToString, dr3(4).ToString, dr3(3).ToString)
                            Next
                        End If
                        cnn3.Close()

                    Else
                        If .getDt(cnn3, dt3, "select Codigo, Nombre, PrecioVentaIVA, exitencia FROM productos where NumSuc =" & idsucursal & " and Codigo = '" & cboFiltro.Text & "' ", sinfo3) Then
                            For Each dr3 In dt3.Rows
                                grdCaptura.Rows.Add(cbosucursal.Text, dr3(0).ToString, dr3(1).ToString, dr3(3).ToString, dr3(2).ToString)
                            Next
                        End If
                        cnn3.Close()
                    End If


                End If
            End With
        End If

    End Sub
End Class