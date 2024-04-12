
Imports System.Security.Cryptography
Imports System.IO
Public Class frmProductoR
    Private Sub frmProductoR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Delsscom® Control Negocios -  Relaciones Crusada Vehiculo/Refacción" & Strings.Space(40) & Date.Now
        Tid.Start()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try

            Dim codigo As String = ""
            Dim barra As String = ""
            Dim numparte As String = ""
            Dim nombrev As String = ""
            Dim marca As String = ""
            Dim observacion As String = ""
            Dim medida As String = ""
            Dim ubicacion As String = ""
            Dim servicio As String = ""
            Dim unidad As String = ""
            Dim vehiculo As Integer = 0
            Dim nombre As String = ""
            Dim piezas As Double = 0

            cnn1.Close() : cnn1.Open()

            For luffy As Integer = 0 To grdcaptura.Rows.Count - 1

                codigo = grdcaptura.Rows(luffy).Cells(0).Value.ToString
                numparte = grdcaptura.Rows(luffy).Cells(1).Value.ToString
                barra = grdcaptura.Rows(luffy).Cells(2).Value.ToString
                nombrev = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                marca = grdcaptura.Rows(luffy).Cells(4).Value.ToString
                medida = grdcaptura.Rows(luffy).Cells(5).Value.ToString
                observacion = grdcaptura.Rows(luffy).Cells(6).Value.ToString
                ubicacion = grdcaptura.Rows(luffy).Cells(7).Value.ToString
                servicio = grdcaptura.Rows(luffy).Cells(8).Value.ToString
                unidad = grdcaptura.Rows(luffy).Cells(9).Value.ToString
                piezas = grdcaptura.Rows(luffy).Cells(10).Value.ToString
                vehiculo = grdcaptura.Rows(luffy).Cells(11).Value.ToString
                nombre = grdcaptura.Rows(luffy).Cells(12).Value.ToString

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Refaccionaria WHERE CodigoPro='" & cboCodigo.Text & "' AND IdVehiculo=" & vehiculo & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "UPDATE refaccionaria SET Marca='" & marca & "',Medida='" & txtMedida.Text & "',Observaciones='" & txtObservacion.Text & "',Ubicacion='" & cboCodigo.Text & "',Servicio='" & cboservicio.Text & "',NPiezas='" & txtpiezas.Text & "',IdVehiculo=" & vehiculo & " WHERE CodigoPro='" & cboCodigo.Text & "' AND IdVehiculo=" & vehiculo & ""
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()
                        btnNuevo.PerformClick()
                    End If
                Else

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "INSERT INTO refaccionaria(CodigoPro,NumParte,CodBarra,Nombre,Marca,Medida,Observaciones,Ubicacion,Servicio,UVenta,NPiezas,IdVehiculo) VALUES('" & codigo & "','" & numparte & "','" & barra & "','" & nombre & "','" & marca & "','" & medida & "','" & observacion & "','" & ubicacion & "','" & servicio & "','" & unidad & "','" & piezas & "'," & vehiculo & ")"
                    If cmd3.ExecuteNonQuery() Then
                        MsgBox("Producto agregado correctamente", vbInformation + vbOKOnly, titulorefaccionaria)
                    End If
                    cnn3.Close()

                End If
                rd1.Close()

            Next

            grdcaptura.Rows.Clear()
            grd.Rows.Clear()
            cboNombre.Focus.Equals(True)
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtbarras.Text = ""
        txtnumparte.Text = ""
        cboservicio.Text = ""
        cbovehiculo.Text = ""
        txtidvehiculo.Text = ""
        cboCodigo.Text = ""
        cboNombre.Text = ""
        cboMarca.Text = ""
        txtpiezas.Text = ""
        txtObservacion.Text = ""
        txtunidad.Text = ""
        cboubicacion.Text = ""
        txtMedida.Text = ""
        PictureBox1.Image = Nothing
        grdcaptura.Rows.Clear()
        grd.Rows.Clear()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea salir?", vbInformation + vbOKCancel, titulorefaccionaria) = vbOK Then
            Me.Close()
            frmMenuPrincipal.Show()
        End If
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As EventArgs) Handles cboCodigo.DropDown
        Try
            cboCodigo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM Productos WHERE Codigo<>'' ORDER BY Codigo"
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

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        Try
            cboNombre.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboNombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboservicio_DropDown(sender As Object, e As EventArgs) Handles cboservicio.DropDown
        Try

            cboservicio.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Servicio FROM refaccionaria WHERE Servicio<>'' ORDER BY Servicio"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboservicio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        datosentrada("Nombre")
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodigo.SelectedValueChanged
        datosentrada("Codigo")
    End Sub

    Public Sub datosentrada(ByVal dato As String)
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If dato = "Codigo" Then
                cmd1.CommandText = "SELECT CodBarra,N_Serie,Codigo,Nombre,Ubicacion,UVenta FROM productos WHERE Codigo='" & cboCodigo.Text & "'"
            End If

            If dato = "Nombre" Then

                cmd1.CommandText = "SELECT CodBarra,N_Serie,Codigo,Nombre,Ubicacion,UVenta FROM productos WHERE Nombre='" & cboNombre.Text & "'"

            End If

            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtbarras.Text = rd1(0).ToString
                    txtnumparte.Text = rd1(1).ToString

                    If dato = "Codigo" Then
                        cboNombre.Text = rd1(3).ToString
                    End If

                    If dato = "Nombre" Then
                        cboCodigo.Text = rd1(2).ToString
                    End If

                    cboubicacion.Text = rd1(4).ToString
                    txtunidad.Text = rd1(5).ToString

                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Servicio FROM refaccionaria WHERE CodigoPro='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboservicio.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg") Then
                PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtbarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarras.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT N_Serie,Codigo,Nombre,Ubicacion,UVenta FROM productos WHERE CodBarra='" & txtbarras.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        txtnumparte.Text = rd1(0).ToString
                        cboCodigo.Text = rd1(1).ToString
                        cboNombre.Text = rd1(2).ToString
                        cboubicacion.Text = rd1(3).ToString
                        txtunidad.Text = rd1(4).ToString

                    End If
                End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If
    End Sub

    Private Sub txtnumparte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumparte.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT CodBarra,Codigo,Nombre,Ubicacion,UVenta FROM productos WHERE N_Serie='" & txtnumparte.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        txtbarras.Text = rd1(0).ToString
                        cboCodigo.Text = rd1(1).ToString
                        cboNombre.Text = rd1(2).ToString
                        cboubicacion.Text = rd1(3).ToString
                        txtunidad.Text = rd1(4).ToString

                    End If
                End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If
    End Sub

    Private Sub cbovehiculo_DropDown(sender As Object, e As EventArgs) Handles cbovehiculo.DropDown
        Try
            cbovehiculo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Descripcion FROM vehiculo WHERE Descripcion<>'' ORDER BY Descripcion"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbovehiculo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbovehiculo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbovehiculo.SelectedValueChanged
        Try

            grd.Rows.Clear()
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdVehiculo FROM vehiculo WHERE Descripcion='" & cbovehiculo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtidvehiculo.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM refaccionaria WHERE IdVehiculo=" & txtidvehiculo.Text & " AND Servicio='" & cboservicio.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    grd.Rows.Add(rd1("CodigoPro").ToString,
                                 rd1("NumParte").ToString,
                                 rd1("CodBarra").ToString,
                                   rd1("Nombre").ToString(),
                                 rd1("Marca").ToString,
                                 rd1("Medida").ToString,
                                 rd1("Observaciones").ToString,
                                 rd1("Ubicacion").ToString,
                                 rd1("Servicio").ToString,
                                 rd1("UVenta").ToString,
                                 rd1("NPiezas").ToString,
                                 rd1("IdVehiculo").ToString
)

                End If
            Loop
            rd1.Close()
            cnn1.Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Tid_Tick(sender As Object, e As EventArgs) Handles Tid.Tick
        cnn9.Close() : cnn9.Open()
        cmd9 = cnn9.CreateCommand
        cmd9.CommandText = "select IdVehiculo from Vehiculo where Descripcion='" & cbovehiculo.Text & "'"
        rd9 = cmd9.ExecuteReader
        If rd9.HasRows Then
            If rd9.Read Then
                txtidvehiculo.Text = rd9(0).ToString
            End If
        End If
        rd9.Close()
        cnn9.Close()
    End Sub

    Private Sub cbovehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbovehiculo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            If cbovehiculo.Text = "" Then
                MsgBox("Ingrese o seleccione un vehiculo", vbInformation + vbOKOnly, titulorefaccionaria)
                cbovehiculo.Focus.Equals(True)
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM vehiculo WHERE Descripcion='" & cbovehiculo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MsgBox("El vehiculo ya esta registrado", vbInformation + vbOKOnly, titulotaller)
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO Vehiculo(Descripcion) VALUES('" & cbovehiculo.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

            End If

            txtObservacion.Focus.Equals(True)

        End If
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboservicio.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboservicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboservicio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbovehiculo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboubicacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboubicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboubicacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtunidad.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtunidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtunidad.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMedida.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMedida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMedida.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtpiezas.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtpiezas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpiezas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboservicio.Text = "" Then MsgBox("Ingrese o Seleccione un vehiculo", vbInformation + vbOKOnly, titulorefaccionaria) : cboservicio.Focus.Equals(True) : Exit Sub

            If cbovehiculo.Text = "" Then MsgBox("Ingrese o Seleccione un vehiculo", vbInformation + vbOKOnly, titulorefaccionaria) : cbovehiculo.Focus.Equals(True) : Exit Sub

            If cboCodigo.Text = "" Then
                cboNombre.Focus.Equals(True)
            Else
                grdcaptura.Rows.Add(cboCodigo.Text,
                                    txtnumparte.Text,
                                    txtbarras.Text,
                                    cbovehiculo.Text,
                                    cboMarca.Text,
                                    txtMedida.Text,
                                    txtObservacion.Text,
                                    cboubicacion.Text,
                                    cboservicio.Text,
                                    txtunidad.Text,
                                    txtpiezas.Text,
                                    txtidvehiculo.Text,
                                    cboNombre.Text
)
            End If
            btnguardar.Focus.Equals(True)

        End If
    End Sub

    Private Sub grd_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellDoubleClick

        Dim index As Integer = grd.CurrentRow.Index

        cboCodigo.Text = grd.Rows(index).Cells(0).Value.ToString
        txtnumparte.Text = grd.Rows(index).Cells(1).Value.ToString
        txtbarras.Text = grd.Rows(index).Cells(2).Value.ToString
        cboMarca.Text = grd.Rows(index).Cells(3).Value.ToString
        cboNombre.Text = grd.Rows(index).Cells(4).Value.ToString
        txtMedida.Text = grd.Rows(index).Cells(5).Value.ToString
        txtObservacion.Text = grd.Rows(index).Cells(6).Value.ToString
        cboubicacion.Text = grd.Rows(index).Cells(7).Value.ToString
        '8
        txtunidad.Text = grd.Rows(index).Cells(9).Value.ToString
        txtpiezas.Text = grd.Rows(index).Cells(10).Value.ToString
        '10


        grd.Rows.Remove(grd.Rows(index))

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try

            If cboCodigo.Text = "" Then MsgBox("Debe de seleccionar un codigo de producto", vbInformation + vbOKOnly, titulorefaccionaria) : cboNombre.Focus.Equals(True) : Exit Sub


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM Refaccionaria WHERE CodigoPro='" & cboCodigo.Text & "' AND IdVehiculo=" & txtidvehiculo.Text & ""
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            Else
                MsgBox("EL producto no esta registrado", vbInformation + vbOKOnly, titulorefaccionaria)
                cboNombre.Focus.Equals(True)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios") = vbOK Then
            Excel_Grid_SQL(grdsql)
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

        On Error GoTo nopaso

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

        Dim codigo, barras, parte, nombre, unidad, proveedor, depto, grupo, prod_sat, unidad_sat, ubicacion, medidas, observaciones, marca As String
        Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")
        Dim iva, compra, venta_siva, venta_civa, porcentaje, existencia As Double
        Dim conteo As Integer = 0


nopaso:
        MsgBox(Err.Number & " - " & Err.Description &
               vbNewLine &
               "Ocurrió un error al intentar importar el archivo, inténtalo de nuevo más tarde. De persistir el problema comunícate con tu proveedor de sotware.", vbInformation + vbOKOnly, titulorefaccionaria)
        Exit Sub
    End Sub

    Private Sub cboCodigo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCodigo.SelectedIndexChanged

    End Sub
End Class