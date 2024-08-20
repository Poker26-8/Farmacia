Public Class frmComparador

    Dim proveedorseleccionado As String = ""
    Dim codigoseleccionado As String = ""
    Dim nombreseleccionado As String = ""
    Dim precioseleccionado As Double = 0

    Public suge As Double = 0
    Private Sub frmComparador_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtCodBarra.Focus.Equals(True)
    End Sub

    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecio.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboproveedor.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboproveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboproveedor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCodBarra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodBarra.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboDescripcion.Text = "" Then
                Datos()
                cboDescripcion.Focus.Equals(True)
            Else
                cboDescripcion.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        Try
            cboDescripcion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDescripcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As EventArgs) Handles cboCodigo.DropDown
        Try
            cboCodigo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM productos WHERE Codigo<>'' ORDER BY Codigo"
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
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboproveedor_DropDown(sender As Object, e As EventArgs) Handles cboproveedor.DropDown
        Try
            cboproveedor.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT NComercial FROM proveedores WHERE NComercial<>'' ORDER BY NComercial"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboproveedor.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Public Sub Datos()
        Try
            GrdCaptura.Rows.Clear()
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,Nombre,PrecioCompra,ProvPri FROM productos WHERE CodBarra='" & txtCodBarra.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboCodigo.Text = rd1(0).ToString
                    cboDescripcion.Text = rd1(1).ToString
                    txtPrecio.Text = rd1(2).ToString
                    cboproveedor.Text = rd1(3).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,Descripcion,Proveedor,PrecioAnt FROM precios WHERE CodBarra='" & txtCodBarra.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then


                    GrdCaptura.Rows.Add(rd1(0).ToString,
                                        rd1(1).ToString,
                                        rd1(2).ToString,
                                        rd1(3).ToString
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

    Public Sub Datos2()
        Try
            GrdCaptura.Rows.Clear()
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Codigo,CodBarra,Nombre,ProvPri,PrecioCompra FROM productos WHERE Nombre='" & cboDescripcion.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtCodBarra.Text = rd2(1).ToString
                    cboCodigo.Text = rd2(0).ToString
                    cboDescripcion.Text = rd2(2).ToString
                    cboproveedor.Text = rd2(3).ToString
                    txtPrecio.Text = rd2(4).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Codigo,Descripcion,Proveedor,PrecioAnt FROM precios WHERE Descripcion='" & cboDescripcion.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then



                    GrdCaptura.Rows.Add(rd2("Codigo").ToString,
                                        rd2("Descripcion").ToString,
                                        rd2("Proveedor").ToString,
                                        rd2("PrecioAnt").ToString)
                End If
            Loop
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboDescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedValueChanged
        Datos2()
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodigo.SelectedValueChanged

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtCodBarra.Text = ""
        cboCodigo.Text = ""
        cboDescripcion.Text = ""
        txtPrecio.Text = ""
        cboproveedor.Text = ""
        GrdCaptura.Rows.Clear()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo FROM precios WHERE Codigo='" & cboCodigo.Text & "' AND Proveedor='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE precios SET Proveedor='" & cboproveedor.Text & "', PrecioAnt=" & txtPrecio.Text & " WHERE CodBarra='" & txtCodBarra.Text & "' AND Proveedor='" & cboproveedor.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Precios aisgnados correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO precios(Codigo,CodBarra,Descripcion,PrecioAnt,Proveedor) VALUES('" & cboCodigo.Text & "','" & txtCodBarra.Text & "','" & cboDescripcion.Text & "'," & txtPrecio.Text & ",'" & cboproveedor.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Precios aisgnados correctamente", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
            cboDescripcion.Focus.Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
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
            Dim codigo, barras, nombre, proveedor As String
            Dim venta_civa As Double
            Dim conteo As Integer = 0


            pbsube.Value = 0
            pbsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1

                codigo = NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString())
                If codigo = "" Then Exit For
                barras = NulCad(DataGridView1.Rows(zef).Cells(1).Value.ToString())
                nombre = UCase(NulCad(DataGridView1.Rows(zef).Cells(2).Value.ToString()))
                proveedor = NulCad(DataGridView1.Rows(zef).Cells(3).Value.ToString())
                venta_civa = NulVa(DataGridView1.Rows(zef).Cells(4).Value.ToString())




                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()

                    contadorconexion = 1
                End If

                nombre = Trim(Replace(nombre, "‘", ""))
                nombre = Trim(Replace(nombre, "'", "''"))
                nombre = Trim(Replace(nombre, "*", ""))
                nombre = Trim(Replace(nombre, "", ""))

                proveedor = Trim(Replace(proveedor, "'", "''"))

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT NComercial FROM proveedores WHERE NComercial='" & proveedor & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO proveedores(NComercial,Compania) VALUES('" & proveedor & "','" & proveedor & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close() : cnn2.Open()

                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO precios(Codigo,CodBarra,Descripcion,PrecioAnt,Proveedor) VALUES('" & codigo & "','" & barras & "','" & nombre & "'," & venta_civa & ",'" & proveedor & "')"
                cmd1.ExecuteNonQuery()

                conteo += 1
                pbsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing

            tabla.Dispose()
            DataGridView1.Rows.Clear()
            pbsube.Value = 0

            MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

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

    Private Function NulVa(ByVal cifra As Double) As Double
        If IsDBNull(cifra) Then
            NulVa = 0
        Else
            NulVa = cifra
        End If
    End Function

    Private Sub txtCodBarra_TextChanged(sender As Object, e As EventArgs) Handles txtCodBarra.TextChanged
        txtCodBarra_KeyPress(txtCodBarra, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub btnCance_Click(sender As Object, e As EventArgs) Handles btnCance.Click
        gbCantidad.Visible = False
    End Sub

    Private Sub btnGC_Click(sender As Object, e As EventArgs) Handles btnGC.Click

        frmPedidosN.cboProveedor.Text = proveedorseleccionado


        Dim total As Double = CDec(txtCantidad.Text) * CDec(precioseleccionado)
        Dim iva As Double = 0
        Dim preciosiniva As Double = 0
        Dim ivaproducto As Double = 0
        Dim cantidadiva As Double = 0

        Dim unidad As String = ""
        Dim existencia As Double = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT IVA,UCompra,Existencia FROM productos WHERE Codigo='" & codigoseleccionado & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                unidad = rd1("UCompra").ToString
                existencia = rd1("Existencia").ToString

                If rd1(0).ToString > 0 Then
                    iva = rd1(0).ToString
                    preciosiniva = CDec(precioseleccionado) / (1 + iva)
                    ivaproducto = CDec(precioseleccionado) - CDec(preciosiniva)
                    cantidadiva = ivaproducto * CDec(txtCantidad.Text)
                End If
            End If
        End If
        rd1.Close()
        cnn1.Close()

        frmPedidosN.grdCaptura.Rows.Add(
                codigoseleccionado,
                txtCodBarra.Text,
                nombreseleccionado,
                unidad,
                existencia,
                FormatNumber(txtCantidad.Text, 2),
                suge,
                FormatNumber(precioseleccionado, 2),
                FormatNumber(total, 2)
                )

        frmPedidosN.txtSubtotal.Text = frmPedidosN.txtSubtotal.Text + CDec(total)


        frmPedidosN.Show()
        frmPedidosN.BringToFront()



        gbCantidad.Visible = False
        Me.Close()

    End Sub

    Private Sub GrdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdCaptura.CellClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim index As Integer = GrdCaptura.CurrentRow.Index

        If celda.ColumnIndex = 2 Then
            codigoseleccionado = GrdCaptura.Rows(index).Cells(0).Value.ToString
            nombreseleccionado = GrdCaptura.Rows(index).Cells(1).Value.ToString
            proveedorseleccionado = GrdCaptura.Rows(index).Cells(2).Value.ToString
            precioseleccionado = GrdCaptura.Rows(index).Cells(3).Value.ToString

            gbCantidad.Visible = True
            txtCantidad.Focus.Equals(True)
        End If


    End Sub


    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGC.Focus.Equals(True)
        End If
    End Sub

    Private Sub frmComparador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class