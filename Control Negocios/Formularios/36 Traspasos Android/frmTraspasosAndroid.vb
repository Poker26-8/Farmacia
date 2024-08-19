Imports MySql.Data.MySqlClient

Public Class frmTraspasosAndroid
    Dim banderaentra As Integer = 0
    Private configA As datosAndroid
    Private filenum As Integer
    Private recordLen As String
    Private currentRecord As Long
    Private lastRecord As Long
    Private Sub frmTraspasosAndroid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sTargett = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"

        If IO.File.Exists(ARCHIVO_DE_CONFIGURACION_A) Then

            banderaentra = 1

            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACION_A, OpenMode.Random, OpenAccess.ReadWrite)
            recordLen = Len(configA)
            FileGet(filenum, configA, 1)
            ipserverA = Trim(configA.ipr)
            databaseA = Trim(configA.baser)
            userbdA = Trim(configA.usuarior)
            passbdA = Trim(configA.passr)
            If ipserverA = "" Or databaseA = "" Or userbdA = "" Or passbdA = "" Then
                sTargetNube = ""
            Else
                sTargetNube = "server=" & ipserverA & ";uid=" & userbdA & ";Password=" & passbdA & ";database=" & databaseA & ";persist security info=false;connect timeout=300"
            End If

            Dim cnnp As MySqlConnection = New MySqlConnection
            Dim sinfop As String = ""
            Dim drp As DataRow
            Dim odata As New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnnp, sTargetNube, sinfop) Then
                    If .getDr(cnnp, drp, "select nombre from sucursales where Id = 1 or nombre = 'MATRIZ'", sinfop) Then
                        lblconexion.Text = "Conexión: exitosa"
                    Else
                        lblconexion.Text = "ERROR de Conexión"
                    End If
                    cnnp.Close()
                Else
                    lblconexion.Text = "ERROR de Conexión"
                End If
            End With

            FileClose()

        Else
            ipserverA = ""
            databaseA = ""
            userbdA = ""
            passbdA = ""

        End If

        btnNuevoProd.PerformClick()

        llena_Usuarios(cboRuta)
    End Sub
    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click
        cboRuta.Text = ""
        cboFolio.Text = ""
        cboCodigo.Text = ""
        cboProducto.Text = ""
        txtCantidad.Text = 0
        lbl_exist.Text = 0
        dgProd.Rows.Clear()
        txtTotal.Text = 0
        GroupBox1.Enabled = True
        cboRuta.Focus()

        llena_Usuarios(cboRuta)
    End Sub
    Private Sub cboFolio_DropDown(sender As Object, e As System.EventArgs) Handles cboFolio.DropDown
        cboFolio.Items.Clear()
        get_Folios(cboFolio)
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As System.EventArgs) Handles cboCodigo.DropDown
        cboCodigo.Items.Clear()
        get_Codigo(cboCodigo)
    End Sub

    Private Sub cboProducto_DropDown(sender As Object, e As System.EventArgs) Handles cboProducto.DropDown
        cboProducto.Items.Clear()
        get_Descripcion(cboProducto)
    End Sub

    Private Sub cboRuta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboRuta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboProducto.Focus()
        End If
    End Sub

    Private Sub cboProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboProducto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboProducto.Text = "" Then cboCodigo.Focus() : Exit Sub
            Dim dt1 As New DataTable
            getDescFilV(cboProducto.Text, dt1)
            If dt1.Rows.Count > 0 Then
                For Each dr In dt1.Rows
                    cboCodigo.Text = dr("Codigo").ToString
                    txtCantidad.Text = 0
                    lbl_exist.Text = dr("Existencia").ToString
                Next
                txtCantidad.Focus()
            Else
                cboCodigo.Text = ""
                cboProducto.Text = ""
                txtCantidad.Text = 0
                lbl_exist.Text = 0
                cboCodigo.Focus()
            End If
        End If
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboCodigo.Text = "" Then btnGuardar.Focus() : Exit Sub
            Dim dt1 As New DataTable
            getCodigoFilV(cboCodigo.Text, dt1)
            If dt1.Rows.Count > 0 Then
                For Each dr In dt1.Rows
                    cboProducto.Text = dr("Nombre").ToString
                    txtCantidad.Text = 0
                    lbl_exist.Text = dr("Existencia").ToString
                Next
                cboProducto.Focus()
            Else
                cboProducto.Text = ""
                txtCantidad.Text = 0
                lbl_exist.Text = 0
                cboCodigo.Text = ""
                btnGuardar.Focus()
            End If

        End If
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCodigo.SelectedValueChanged
        On Error GoTo puerta
        If cboCodigo.Text = "" Then Exit Sub
        Dim dt1 As New DataTable
        getCodigoFilV(cboCodigo.Text, dt1)
        If dt1.Rows.Count > 0 Then
            For Each dr In dt1.Rows
                cboProducto.Text = dr("Nombre").ToString
                txtCantidad.Text = 0
                lbl_exist.Text = dr("Existencia").ToString
            Next
        Else
            cboProducto.Text = ""
            txtCantidad.Text = 0
            lbl_exist.Text = 0
        End If
puerta:
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboCodigo.Text = "" Then MsgBox("Debe seleccionar o escribir un código de producto") : cboCodigo.Focus() : Exit Sub
            If cboProducto.Text = "" Then MsgBox("Debe seleccionar o escribir la descripción de producto") : cboProducto.Focus() : Exit Sub
            If IsNumeric(txtCantidad.Text) = False Then MsgBox("La cantidad debe tener un valor númerico") : txtCantidad.Focus() : Exit Sub

            dgProd.Rows.Add(cboCodigo.Text, cboProducto.Text, FormatNumber(txtCantidad.Text, 2))

            txtTotal.Text = CDec(txtTotal.Text) + CDec(txtCantidad.Text)

            cboCodigo.Text = "" : cboProducto.Text = "" : txtCantidad.Text = 0 : lbl_exist.Text = 0

            cboProducto.Focus()
        End If
    End Sub

    Private Sub cboProducto_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboProducto.SelectedValueChanged
        On Error GoTo puerta
        If cboProducto.Text = "" Then Exit Sub
        Dim dt1 As New DataTable
        getDescFilV(cboProducto.Text, dt1)
        If dt1.Rows.Count > 0 Then
            For Each dr In dt1.Rows
                cboCodigo.Text = dr("Codigo").ToString
                txtCantidad.Text = 0
                lbl_exist.Text = dr("Existencia").ToString
            Next
        Else
            cboCodigo.Text = ""
            txtCantidad.Text = 0
            lbl_exist.Text = 0
        End If
puerta:
    End Sub

    Private Sub dgProd_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgProd.RowsRemoved
        If dgProd.RowCount > 0 Then
            txtTotal.Text = 0
            For i = 0 To dgProd.RowCount - 1
                txtTotal.Text = CDec(txtTotal.Text) + CDec(dgProd.Rows(i).Cells(2).Value)
            Next
        Else
            txtTotal.Text = 0
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

        If CDec(txtTotal.Text) <= 0 Then MsgBox("La cantidad de productos no puede ser 0") : Exit Sub
        If Trim(cboRuta.Text) = "" Then MsgBox("Hay que seleccionar una sucursal para poder enviar el traspaso") : Exit Sub

        Dim dt1 As New DataTable
        If cboFolio.Text = "" Then
            guardarTraspaso(dgProd, Trim(cboRuta.Text), txtTotal.Text, Format(Date.Now, "dd/MM/yyyy"))
            MsgBox("Traspaso Guardado Correctamente")
            btnNuevoProd.PerformClick()
        End If

    End Sub

    Private Sub cboFolio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboFolio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboFolio.Text = "" Then Exit Sub

            cboRuta.Text = ""
            cboCodigo.Text = ""
            cboProducto.Text = ""
            txtCantidad.Text = 0
            txtTotal.Text = 0
            lbl_exist.Text = 0
            dgProd.Rows.Clear()

            Dim dt1 As New DataTable
            Dim dt As New DataTable

            get_Folios_Fill(cboFolio.Text, dt, dt1)
            If dt.Rows.Count > 0 Then
                GroupBox1.Enabled = False
                For Each dr In dt.Rows
                    cboRuta.Text = dr("Sucursal").ToString 'dr("Usuario").ToString
                    cboCodigo.Text = ""
                    cboProducto.Text = ""
                    txtCantidad.Text = 0
                    lbl_exist.Text = 0
                    dgProd.Rows.Clear()
                    For Each dr1 In dt1.Rows
                        dgProd.Rows.Add(dr1("Codigo").ToString, dr1("Descripcion").ToString, dr1("Cantidad").ToString)
                        txtTotal.Text = CDec(txtTotal.Text) + CDec(dr1("Cantidad").ToString)
                    Next
                Next
            Else
                GroupBox1.Enabled = True
                cboFolio.Text = ""
            End If
        End If

    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboFolio.SelectedValueChanged
        On Error GoTo puerta

        cboRuta.Text = ""
        cboCodigo.Text = ""
        cboProducto.Text = ""
        txtCantidad.Text = 0
        txtTotal.Text = 0
        lbl_exist.Text = 0
        dgProd.Rows.Clear()

        Dim dt1 As New DataTable
        Dim dt As New DataTable

        get_Folios_Fill(cboFolio.Text, dt, dt1)
        If dt.Rows.Count > 0 Then
            GroupBox1.Enabled = False
            For Each dr In dt.Rows
                cboRuta.Text = dr("Usuario").ToString
                cboCodigo.Text = ""
                cboProducto.Text = ""
                txtCantidad.Text = 0
                lbl_exist.Text = 0
                dgProd.Rows.Clear()
                For Each dr1 In dt1.Rows
                    dgProd.Rows.Add(dr1("Codigo").ToString, dr1("Descripcion").ToString, dr1("Cantidad").ToString)
                    txtTotal.Text = CDec(txtTotal.Text) + CDec(dr1("Cantidad").ToString)
                Next
            Next
        End If

puerta:
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    frmSucursal.Show()
    '    frmSucursal.BringToFront()
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    frmAsignarUsuarios.Show()
    '    frmAsignarUsuarios.BringToFront()
    'End Sub

    'Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
    '    frmReporteVtaAndroid.Show()
    '    frmReporteVtaAndroid.BringToFront()
    'End Sub


    Function get_MaxId(ByRef lb1 As Label)
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim sSQL As String = "Select max(Id) as XD from traspasos"
        Dim sinfo As String = ""
        Dim dr_max As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargett, sinfo) Then
                If .getDr(cnn33, dr_max, sSQL, sinfo) Then
                    If dr_max(0).ToString <> "" Then
                        lb1.Text = CDec(dr_max(0).ToString) + CDec(1)
                    Else
                        lb1.Text = 1
                    End If
                Else
                    lb1.Text = 1
                End If
                cnn33.Close()
            End If
        End With
    End Function

    Function get_Folios(ByRef combo As ComboBox)
        combo.Items.Clear()
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim sSQL As String = "Select Id from traspasos where Eliminado = 0 order by Id"
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        With oData
            If .dbOpen(cnn33, sTargett, sinfo) Then
                If .getDt(cnn33, dt1, sSQL, sinfo) Then
                    For Each dr In dt1.Rows
                        combo.Items.Add(dr(0).ToString)
                    Next
                End If
                cnn33.Close()
            End If
        End With
    End Function

    Function get_Codigo(ByRef combo As ComboBox)
        combo.Items.Clear()
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim sSQL As String = "Select Codigo from productos where CHAR_LENGTH(Codigo) <= 6 order by Codigo"
        Dim dt1 As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargett, sinfo) Then
                If .getDt(cnn33, dt1, sSQL, sinfo) Then
                    For Each dr In dt1.Rows
                        combo.Items.Add(dr("Codigo").ToString)
                    Next
                End If
                cnn33.Close()
            End If
        End With
    End Function

    Function llena_Usuarios(ByRef combo As ComboBox)
        combo.Items.Clear()
        Dim cnn33 As MySqlConnection = New MySqlConnection
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

    Function get_Descripcion(ByRef combo As ComboBox)
        combo.Items.Clear()
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim sSQL As String = "Select Nombre from productos where CHAR_LENGTH(Codigo) <= 6 order by Nombre"
        Dim dt1 As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargett, sinfo) Then
                If .getDt(cnn33, dt1, sSQL, sinfo) Then
                    For Each dr In dt1.Rows
                        combo.Items.Add(dr("Nombre").ToString)
                    Next
                End If
                cnn33.Close()
            End If
        End With
    End Function

    Function getDescFilV(ByVal prod As String, ByRef dtuno As DataTable)
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim sSQL As String = "Select * from Productos where Nombre = '" & prod & "'"
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargett, sinfo) Then
                If .getDt(cnn33, dtuno, sSQL, sinfo) Then
                End If
                cnn33.Close()
            End If
        End With
    End Function

    Function getCodigoFilV(ByVal codi As String, ByRef dtuno As DataTable)
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim sSQL As String = "Select * from productos where Codigo = '" & codi & "'"
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargett, sinfo) Then
                If .getDt(cnn33, dtuno, sSQL, sinfo) Then
                End If
                cnn33.Close()
            End If
        End With
    End Function

    Function guardarTraspaso(ByVal dg As DataGridView, ByVal varUsuario As String, ByVal varTotalProd As Double, ByVal varFecha As String)

        Dim cnn10 As MySqlConnection = New MySqlConnection
        Dim odata10 As New ToolKitSQL.myssql
        Dim ssql3 As String = ""

        Dim sSQL As String = "insert into traspasos(Usuario,TotalProd,Fecha,Tipo,Cargado,Sucursal) " &
               "values(''," & varTotalProd & ",'" & varFecha & "','SALIDA',0,'" & varUsuario & "')"
        Dim sinfo As String = ""
        With odata10
            If .dbOpen(cnn10, sTargett, sinfo) Then
                If .runSp(cnn10, sSQL, sinfo) Then
                    guardarTraspasoDetalle(dg, maxIdTras(), varFecha, maxIdTrasNube())
                End If
                cnn10.Close()
            End If
        End With

    End Function

    Function guardarTraspasoDetalle(ByVal dg As DataGridView, ByVal IdTras As Integer, ByVal Fecha As String, ByVal IdTrasNube As Integer)

        Dim cnn11 As MySqlConnection = New MySqlConnection
        Dim odata11 As New ToolKitSQL.myssql
        Dim ssql3 As String = ""

        Dim dr3 As DataRow
        Dim sinfo As String = ""
        With odata11
            If .dbOpen(cnn11, sTargett, sinfo) Then

                For i = 0 To dg.Rows.Count - 1
                    Dim sSQL As String = "insert into traspasosdetalle(IdTraspaso,Codigo,Descripcion,Cantidad) " &
                                "values(" & IdTras & ",'" & dg.Rows(i).Cells(0).Value.ToString & "','" & dg.Rows(i).Cells(1).Value.ToString & "'," & Replace(dg.Rows(i).Cells(2).Value.ToString, ",", "") & ")"
                    If .runSp(cnn11, sSQL, sinfo) Then

                        Dim drp As DataRow

                        If .getDr(cnn11, drp, "select * from productos where Codigo = '" & Mid(dg.Rows(i).Cells(0).Value.ToString, 1, 6) & "'", sinfo) Then

                            Dim MyExist As String = ""
                            Dim MyNewEsist As String = ""

                            MyExist = 0
                            If CDec(drp("Multiplo").ToString) > 1 And CDec(drp("Existencia").ToString) > 0 Then
                                MyExist = FormatNumber(CDec(drp("Existencia").ToString), 2)
                                If Len(Mid(dg.Rows(i).Cells(0).Value.ToString, 1, 6)) > 6 Then
                                    MyNewEsist = CDec(MyExist) - CDec(dg.Rows(i).Cells(2).Value.ToString)
                                Else
                                    MyNewEsist = CDec(MyExist) - CDec(CDec(dg.Rows(i).Cells(2).Value.ToString) * CDec(drp("Multiplo").ToString))
                                End If
                            Else
                                MyExist = drp("Existencia").ToString
                                MyNewEsist = CDec(MyExist) - CDec(dg.Rows(i).Cells(2).Value.ToString)
                            End If

                            Dim sqlnew As String = ""
                            Dim ssql31 As String = ""

                            sqlnew = "update productos set Existencia = " & CDec(Replace(MyNewEsist, ",", "")) & ", Cargado = 1 where Codigo = '" & Mid(drp("Codigo").ToString, 1, 6) & "'"

                            If .runSp(cnn11, sqlnew, sinfo) Then

                                If Len(drp("Codigo").ToString) > 6 Then
                                    ssql31 = "insert into cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) values('" & drp("Codigo").ToString & "','" & dg.Rows(i).Cells(1).Value.ToString & "','TRASPASO SALIDA Android'," & CDec(dg.Rows(i).Cells(2).Value.ToString) & ",'0','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','ADMIN','" & MyExist & "','" & MyNewEsist & "','')"
                                Else
                                    ssql31 = "insert into cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) values('" & drp("Codigo").ToString & "','" & dg.Rows(i).Cells(1).Value.ToString & "','TRASPASO SALIDA Android'," & CDec(CDec(dg.Rows(i).Cells(2).Value.ToString) * CDec(drp("Multiplo").ToString)) & ",'0','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','ADMIN','" & MyExist & "','" & MyNewEsist & "','')"
                                End If
                                .runSp(cnn11, ssql31, sinfo)

                            End If

                        End If

                    End If

                Next

                cnn11.Close()
            End If
        End With
    End Function

    Function maxIdTras() As Integer
        Dim cnn3 As MySqlConnection = New MySqlConnection
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

    Function maxIdTrasNube() As Integer
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim dr3 As DataRow
        Dim sinfo As String = ""
        Dim oData33 As New ToolKitSQL.myssql
        With oData33
            If .dbOpen(cnn33, sTargett, sinfo) Then
                If .getDr(cnn33, dr3, "select max(Id) as XD from traspasos", sinfo) Then
                    cnn33.Close()
                    Return dr3(0).ToString
                End If
                cnn33.Close()
                Return 0
            End If
        End With
    End Function

    Function get_Folios_Fill(ByVal varFol As String, ByRef dtP As DataTable, ByRef dtP1 As DataTable)
        Dim cnn33 As MySqlConnection = New MySqlConnection
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn33, sTargett, sinfo) Then
                .getDt(cnn33, dtP, "Select * from traspasos where Id = " & varFol & " and Eliminado = 0", sinfo)
                .getDt(cnn33, dtP1, "Select * from traspasosdetalle where IdTraspaso = " & varFol & "", sinfo)
                cnn33.Close()
            End If
        End With
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmSucursales.Show()
        frmSucursales.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmAsignarusuarios.Show()
        frmAsignarusuarios.BringToFront()
    End Sub
End Class