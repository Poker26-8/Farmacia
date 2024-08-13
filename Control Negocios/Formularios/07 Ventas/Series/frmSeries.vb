Imports System.Web.Services

Public Class frmSeries
    Private Sub frmSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbodesc_DropDown(sender As Object, e As EventArgs) Handles cbodesc.DropDown
        Try
            cbodesc.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbodesc.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbodesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodesc.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim query As String = ""

            If cbodesc.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand

                    If IsNumeric(cbodesc.Text) Then
                        query = "SELECT * FROM Productos WHERE CodBarra='" & cbodesc.Text & "'"
                    Else
                        query = "SELECT * FROM Productos WHERE Nombre='" & cbodesc.Text & "'"
                    End If

                    cmd1.CommandText = query
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cboCodigo.Text = rd1("Codigo").ToString
                            rd1.Close() : cnn1.Close()
                            Call cboCodigo_KeyPress(cboCodigo, New KeyPressEventArgs(ChrW(Keys.Enter)))

                            txtFisica.Focus().Equals(True)
                            Exit Sub
                        End If
                    Else
                        cboCodigo.Focus().Equals(True)
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If

            cboCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbodesc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbodesc.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo FROM Productos WHERE Nombre='" & cbodesc.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboCodigo.Text = rd1(0).ToString
                End If
            Else
                MsgBox("No se encuentra en la base de datos.", vbInformation + vbOKOnly, titulocentral)
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                Dim activo As Integer = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Status,Alias,IdEmpleado FROM usuarios WHERE Clave='" & txtClave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        activo = rd1(0).ToString

                        If activo = 1 Then
                            lblusuario.Text = rd1(1).ToString
                        Else
                            MsgBox("El usuario esta inactivo contacta a tu administrador", vbInformation + vbOKOnly, titulocentral)
                            txtClave.Focus.Equals(True)
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("La clave es incorrecta", vbInformation + vbOKOnly, titulocentral)
                    txtClave.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

                If cbodesc.Text = "" Then
                    cbodesc.Focused.Equals(True)
                Else
                    btnguardar.Focus.Equals(True)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As EventArgs) Handles cboCodigo.DropDown
        Try
            cboCodigo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT Codigo FROM productos WHERE LEFT(Codigo, 6)='" & cboCodigo.Text & "' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodigo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboCodigo.Text <> "" Then

                Dim factor As Double = 0
                Dim operad As Double = 0
                Dim codigo As String = Mid(cboCodigo.Text, 1, 6)

                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT MCD,UVenta,Nombre FROM Productos WHERE Codigo='" & cboCodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            factor = IIf(rd1("MCD").ToString = "", 0, rd1("MCD").ToString)
                            txtunidad.Text = rd1("UVenta").ToString
                            cbodesc.Text = rd1("Nombre").ToString
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            operad = rd1("Existencia").ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                    If factor > 0 Then
                        txtSistema.Text = operad * factor
                    End If
                    If txtSistema.Text <> "" Then
                        txtSistema.Text = FormatNumber(txtSistema.Text, 2)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

                Try

                    grdseries.Rows.Clear()
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM series WHERE Codigo='" & cboCodigo.Text & "' AND Status='0'"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            grdseries.Rows.Add(rd1("Codigo").ToString,
                                               rd1("Nombre").ToString,
                                               rd1("Serie").ToString)
                        End If
                    Loop
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                txtFisica.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub cboCodigo_GotFocus(sender As Object, e As EventArgs) Handles cboCodigo.GotFocus
        cboCodigo.SelectionStart = 0
        cboCodigo.SelectionLength = Len(cboCodigo.Text)
    End Sub

    Private Sub cboCodigo_Click(sender As Object, e As EventArgs) Handles cboCodigo.Click
        cboCodigo.SelectionStart = 0
        cboCodigo.SelectionLength = Len(cboCodigo.Text)
    End Sub

    Private Sub txtFisica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFisica.KeyPress
        If Not IsNumeric(txtFisica.Text) Then txtFisica.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtFisica.Text <> "" Then
                btnguardar.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtFisica_LostFocus(sender As Object, e As EventArgs) Handles txtFisica.LostFocus
        If txtSistema.Text <> "" Then
            If txtFisica.Text <> "" Then
                If Not IsNumeric(txtFisica.Text) Then txtFisica.Text = "" : Exit Sub
                If Not IsNumeric(txtSistema.Text) Then txtSistema.Text = "" : Exit Sub

                Dim str As String = ""
                Dim diferencia As Double = 0
                str = Mid(txtFisica.Text, 1, 1)
                If str <> "-" Then
                    txtFisica.Text = Trim(Replace(txtFisica.Text, "-", ""))
                End If
                diferencia = CDbl(IIf(txtFisica.Text = "", 0, txtFisica.Text)) - CDbl(IIf(txtSistema.Text = "", 0, txtSistema.Text))
                txtDiferencia.Text = diferencia
            End If
        End If
    End Sub

    Private Sub btnserie_Click(sender As Object, e As EventArgs) Handles btnserie.Click
        Me.Close()
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        txtClave.Text = ""
        lblusuario.Text = ""
        cboCodigo.Text = ""
        cboCodigo.Items.Clear()
        cbodesc.Text = ""
        cbodesc.Items.Clear()
        txtunidad.Text = ""
        txtSistema.Text = ""
        txtFisica.Text = ""
        txtDiferencia.Text = ""
        btnnuevo_serie.PerformClick()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click

        If cboCodigo.Text = "" Or cbodesc.Text = "" Or txtunidad.Text = "" Or txtSistema.Text = "" Or txtFisica.Text = "" Or txtDiferencia.Text = "" Then
            MsgBox("Faltan datos del producto para poder guardar el ajuste de inventario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cbodesc.Focus().Equals(True)
        End If
        If lblusuario.Text = "" Then
            MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtClave.Focus().Equals(True)
            Exit Sub
        End If

        Try
            Dim idUsu As Integer = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado FROM Usuarios WHERE Alias='" & lblusuario.Text & "' AND Clave='" & txtClave.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idUsu = rd1(0).ToString
                End If
            End If
            rd1.Close()

            Dim per_ajuste As Boolean = False
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Permisos WHERE IdEmpleado= " & idUsu
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    per_ajuste = rd1("Rep_Aju").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

            If Not (per_ajuste) Then
                MsgBox("No cuentas con permiso para realizar ajuste de inventario.", vbInformation + vbOKOnly, titulocentral)
                Exit Sub
            End If
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        If MsgBox("¿Deseas guardar este ajuste de inventario?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

            Dim MyMCD As Double = 0
            Dim MyMult2 As Double = 0
            Dim MyMulti As Double = 0
            Dim MyExist As Double = 0
            Dim MyPreci As Double = 0
            Dim MyDepto As String = ""
            Dim MyGrupo As String = ""
            Dim MyUnida As String = ""

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyUnida = rd1("UVenta").ToString
                        MyMCD = IIf(rd1("MCD").ToString = "", 0, rd1("MCD").ToString)
                        MyMult2 = IIf(rd1("Multiplo").ToString = "", 0, rd1("Multiplo").ToString)
                        MyDepto = rd1("Departamento").ToString
                        MyGrupo = rd1("Grupo").ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & Strings.Left(cboCodigo.Text, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyPreci = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)
                    End If
                End If
                rd1.Close()

                Dim existemmmmmmmcias As Double = 0
                existemmmmmmmcias = CDbl(txtFisica.Text) / MyMCD

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Productos SET Cargado=0, CargadoInv=0, Existencia=" & existemmmmmmmcias & " WHERE Codigo='" & Strings.Left(cboCodigo.Text, 6) & "'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) VALUES('" & cboCodigo.Text & "','" & cbodesc.Text & "','Ajuste de inventario'," & CDbl(txtSistema.Text) & "," & CDbl(txtDiferencia.Text) & "," & CDbl(txtFisica.Text) & "," & MyPreci & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','','','','','','')"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
                btnnuevo.PerformClick()
                btnnuevo_serie.PerformClick()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

    End Sub

    Private Sub grdseries_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdseries.CellDoubleClick
        Dim t As Integer = grdseries.CurrentRow.Index

        txtserie.Text = grdseries.Rows(t).Cells(2).Value.ToString
        cboCodigo.Text = grdseries.Rows(t).Cells(0).Value.ToString
        cbodesc.Text = grdseries.Rows(t).Cells(1).Value.ToString
        grdseries.Rows.Remove(grdseries.Rows(t))
        txtserie.Focus.Equals(True)
    End Sub

    Private Sub txtserie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtserie.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtserie.Text = "" Then
                btnguardar.Focus.Equals(True)
            Else
                If grdseries.Rows.Count < txtSistema.Text Then
                    grdseries.Rows.Add(cboCodigo.Text, cbodesc.Text, txtserie.Text)
                Else
                    MsgBox("Se alcanzo el limite permitido de series", vbInformation + vbOKOnly, titulocentral)
                End If
                txtserie.Text = ""
                txtserie.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub btnnuevo_serie_Click(sender As Object, e As EventArgs) Handles btnnuevo_serie.Click
        txtserie.Text = ""
        cbofactura.Text = ""
        txtfecha.Text = ""
        grdseries.Rows.Clear()
    End Sub

    Private Sub btnguardars_Click(sender As Object, e As EventArgs) Handles btnguardars.Click

        If grdseries.Rows.Count = 0 Then
            MsgBox("Debe de ingresar una serie", vbInformation + vbOKOnly, titulocentral)
            txtserie.Focus.Equals(True)
            Exit Sub
        End If

        If txtClave.Text = "" Then
            MsgBox("Por favor, indique la clave del vendedor.", vbInformation + vbOKOnly, titulocentral)
            txtClave.Focus.Equals(True)
            Exit Sub
        End If

        If MsgBox("¿Desea guardar las series del producto " & cbodesc.Text & " ?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then Exit Sub

        Dim codigo As String = ""
        Dim serie As String = ""
        Dim nombre As String = ""
        For zi As Integer = 0 To grdseries.Rows.Count - 1

            codigo = grdseries.Rows(zi).Cells(0).Value.ToString
            serie = grdseries.Rows(zi).Cells(2).Value.ToString
            nombre = grdseries.Rows(zi).Cells(1).Value.ToString
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Series WHERE Serie='" & serie & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                End If
            Else
                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO Series(Codigo,Nombre,Serie,Fecha,FechaEliminado,Factura,FFactura,Status) VALUES('" & codigo & "','" & nombre & "','" & serie & "','" & Format(Date.Now, "yyyyy-MM-dd HH:mm:ss") & "','','" & cbofactura.Text & "','" & txtfecha.Text & "','0')"
                cmd3.ExecuteNonQuery()
                cnn3.Close()
            End If
            rd2.Close()
            cnn2.Close()
        Next
        MsgBox("Series agregadas correctamente", vbInformation + vbOK, titulocentral)

        btnnuevo_serie.PerformClick()
    End Sub

    Private Sub cbofactura_DropDown(sender As Object, e As EventArgs) Handles cbofactura.DropDown
        cbofactura.Items.Clear()

        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT NumFactura FROM Compras where NumFactura<>'' order by NumFactura"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbofactura.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbofactura_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofactura.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FechaC FROM Compras WHERE NumFactura='" & cbofactura.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    'txtfecha.Text = rd1(0).ToString
                    txtfecha.Text = FormatDateTime(rd1(0).ToString, DateFormat.ShortDate)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQL(DataGridView1)
        End If
    End Sub

    Private Sub Excel_Grid_SQL(ByVal tabla As DataGridView)
        Dim con As OleDb.OleDbConnection
        Dim dt As New System.Data.DataTable
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim cuadro_dialogo As New OpenFileDialog
        Dim ruta As String = ""
        Dim sheet As String = "hoja1"

        With cuadro_dialogo
            .Filter = "Archivos de cálculo(*.xls;*.xlsx)|*.xls;*.xlsx"
            .Title = "Selecciona el archivo a importar"
            .Multiselect = False
            .InitialDirectory = My.Application.Info.DirectoryPath & "\Archivos de importación"
            .ShowDialog()
        End With

        Try
            If cuadro_dialogo.FileName.ToString() <> "" Then
                ruta = cuadro_dialogo.FileName.ToString()
                con = New OleDb.OleDbConnection(
                    "Provider=Microsoft.ACE.OLEDB.12.0;" &
                    " Data Source='" & ruta & "'; " &
                    "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

                da = New OleDb.OleDbDataAdapter("select * from [" & sheet & "$]", con)

                con.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                tabla.DataSource = ds
                tabla.DataMember = "MyData"
                con.Close()
            End If

            'Variables para alojar los datos del archivo de excel
            Dim codigo, nombre, serie As String

            Dim conteo As Integer = 0

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1

                codigo = NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString())
                If codigo = "" Then Exit For
                nombre = UCase(NulCad(DataGridView1.Rows(zef).Cells(1).Value.ToString()))
                serie = NulCad(DataGridView1.Rows(zef).Cells(2).Value.ToString())

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                nombre = Trim(Replace(nombre, "‘", ""))
                nombre = Trim(Replace(nombre, "'", "''"))
                nombre = Trim(Replace(nombre, "*", ""))
                nombre = Trim(Replace(nombre, "", ""))

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Codigo,Nombre from productos WHERE Codigo='" & codigo & "' AND Nombre='" & nombre & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then

                        If cnn1.State = 0 Then cnn1.Open()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO series(Codigo,Nombre,Serie,Fecha,NotaVenta,FechaEliminado,Status,Factura,FFactura) VALUES('" & codigo & "','" & nombre & "','" & serie & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','',0,'','')"
                        If cmd1.ExecuteNonQuery Then
                        Else
                            'MsgBox(codigo, nombre)
                        End If

                        conteo += 1
                    End If
                End If
                rd2.Close()



            Next
            cnn2.Close()
            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()


            MsgBox(conteo & " series fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Function NulCad(ByVal cadena As String) As String
        If IsDBNull(cadena) Then
            NulCad = ""
        Else
            NulCad = Replace(cadena, "'", "") : Replace(cadena, "*", "")
        End If
    End Function
End Class