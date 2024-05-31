
Imports System.IO
Public Class frmProductosDR

    Private Sub TraeDatos2(ByVal vemos As String)
        Try

            grdpreferencia.Rows.Clear()
            grdextras.Rows.Clear()
            grdpromociones.Rows.Clear()

            Dim modo_almacen As Integer = 0

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand

            If vemos = "CODIGO" Then
                cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            End If
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    txtCodBarrasNormal.Text = rd2("CodBarra").ToString
                    cboCodCortoNormal.Text = rd2("Codigo").ToString
                    cboDescripcionTicketNormal.Text = rd2("Nombre").ToString
                    cboIvaNormal.Text = rd2("IVA").ToString
                    txtCompra.Text = rd2("UCompra").ToString
                    txtVentaActual.Text = rd2("UVenta").ToString
                    txtVentaMinima.Text = rd2("UMinima").ToString
                    txtUcompra.Text = rd2("MCD").ToString
                    txtUVenta.Text = rd2("Multiplo").ToString
                    txtMinAlmacen.Text = rd2("Min").ToString
                    txtMaxAlmacen.Text = rd2("Max").ToString
                    txtComision.Text = rd2("Comision").ToString
                    cboProveedoresNormal.Text = rd2("ProvPri").ToString
                    cboProvEme.Text = rd2("ProvEme").ToString
                    cboDepartamentoNormal.Text = rd2("Departamento").ToString
                    cboGrupoNormal.Text = rd2("Grupo").ToString
                    cboImprimirComandaNormal.Text = rd2("GPrint").ToString
                    cboUbicacion.Text = rd2("Ubicacion").ToString
                    modo_almacen = rd2("Modo_Almacen").ToString

                    If modo_almacen = 1 Then
                        rboDescIngredientes.Checked = True
                    Else
                        rboDescProductos.Checked = False
                    End If

                    txtmilitros.Text = rd2("Mililitros").ToString
                    txtcopas.Text = rd2("Copas").ToString

                End If
            End If
            rd2.Close()

            My.Application.DoEvents()
            If servidor <> "" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg")
                End If
            Else
                If File.Exists(equipo_servidor & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(equipo_servidor & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg")
                End If
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    grdpreferencia.Rows.Add(rd2("NombrePrefe").ToString)

                End If
            Loop
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    grdextras.Rows.Add(rd2("Codigo").ToString, rd2("Descx").ToString)
                End If
            Loop
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    grdpromociones.Rows.Add(rd2("Codigo").ToString, rd2("Descx").ToString)
                End If
            Loop
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtcantidadpromo.Text = rd2("F44").ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TraeDatos(ByVal vemos As String)
        Try

            grdpreferencia.Rows.Clear()
            grdextras.Rows.Clear()
            grdpromociones.Rows.Clear()

            Dim modo_almacen As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If vemos = "CODIGO" Then
                cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            End If

            If vemos = "BARRAS" Then
                cmd1.CommandText = "SELECT * FROM Productos WHERE CodBarra='" & txtCodBarrasNormal.Text & "'"
            End If

            If vemos = "NOMBRE" Then
                cmd1.CommandText = "SELECT * FROM Productos WHERE Nombre='" & cboDescripcionTicketNormal.Text & "'"
            End If


            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    txtCodBarrasNormal.Text = rd1("CodBarra").ToString
                    cboCodCortoNormal.Text = rd1("Codigo").ToString
                    cboDescripcionTicketNormal.Text = rd1("Nombre").ToString
                    cboIvaNormal.Text = rd1("IVA").ToString
                    txtCompra.Text = rd1("UCompra").ToString
                    txtVentaActual.Text = rd1("UVenta").ToString
                    txtVentaMinima.Text = rd1("UMinima").ToString
                    txtUcompra.Text = rd1("MCD").ToString
                    txtUVenta.Text = rd1("Multiplo").ToString
                    txtMinAlmacen.Text = rd1("Min").ToString
                    txtMaxAlmacen.Text = rd1("Max").ToString
                    txtComision.Text = rd1("Comision").ToString
                    cboProveedoresNormal.Text = rd1("ProvPri").ToString
                    cboProvEme.Text = rd1("ProvEme").ToString
                    cboDepartamentoNormal.Text = rd1("Departamento").ToString
                    cboGrupoNormal.Text = rd1("Grupo").ToString
                    cboImprimirComandaNormal.Text = rd1("GPrint").ToString
                    cboUbicacion.Text = rd1("Ubicacion").ToString
                    modo_almacen = rd1("Modo_Almacen").ToString

                    If modo_almacen = 1 Then
                        rboDescIngredientes.Checked = True
                    Else
                        rboDescProductos.Checked = False
                    End If

                    txtmilitros.Text = rd1("Mililitros").ToString
                    txtcopas.Text = rd1("Copas").ToString

                End If
            End If
            rd1.Close()

            My.Application.DoEvents()
            If servidor <> "" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg\" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg")
                End If
            Else
                If File.Exists(equipo_servidor & "\ProductosImg" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(equipo_servidor & "\ProductosImg" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg")
                End If
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    grdpreferencia.Rows.Add(rd1("NombrePrefe").ToString)

                End If
            Loop
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdextras.Rows.Add(rd1("Codigo").ToString, rd1("Descx").ToString)
                End If
            Loop
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdpromociones.Rows.Add(rd1("Codigo").ToString, rd1("Descx").ToString)
                End If
            Loop
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcantidadpromo.Text = rd1("F44").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub frmProductosDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDescripcionTicketNormal.Focus.Equals(True)
        rboDescProductos.Checked = True

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Copa'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    If rd1(0).ToString = "1" Then
                        PCopeo.Visible = True
                    Else
                        PCopeo.Visible = False
                    End If

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtVentaActual_TextChanged(sender As Object, e As EventArgs) Handles txtVentaActual.TextChanged
        If txtCompra.Text & txtVentaActual.Text <> "" Then eqv1.Text = "¿Cuantos(as) " & txtVentaActual.Text & " hay por cada " & txtCompra.Text & "?"
    End Sub

    Private Sub txtVentaActual_LostFocus(sender As Object, e As EventArgs) Handles txtVentaActual.LostFocus
        If txtCompra.Text & txtVentaActual.Text <> "" Then eqv1.Text = "¿Cuantos(as) " & txtVentaActual.Text & " hay por cada " & txtCompra.Text & "?"
    End Sub

    Private Sub txtVentaMinima_TextChanged(sender As Object, e As EventArgs) Handles txtVentaMinima.TextChanged
        If txtCompra.Text & txtVentaActual.Text <> "" Then eqv2.Text = "¿Cuantos(as) " & txtVentaMinima.Text & " hay por cada " & txtVentaActual.Text & "?"
    End Sub

    Private Sub txtCodBarrasNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodBarrasNormal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            TraeDatos("BARRAS")
            cboDescripcionTicketNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDescripcionTicketNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcionTicketNormal.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            grdpreferencia.Rows.Clear()
            grdextras.Rows.Clear()
            grdpromociones.Rows.Clear()

            Dim modo_almacen As Integer = 0

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM Productos WHERE Nombre='" & cboDescripcionTicketNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    txtCodBarrasNormal.Text = rd3("CodBarra").ToString
                    cboCodCortoNormal.Text = rd3("Codigo").ToString
                    cboIvaNormal.Text = rd3("IVA").ToString
                    txtCompra.Text = rd3("UCompra").ToString
                    txtVentaActual.Text = rd3("UVenta").ToString
                    txtVentaMinima.Text = rd3("UMinima").ToString
                    txtUcompra.Text = rd3("MCD").ToString
                    txtUVenta.Text = rd3("Multiplo").ToString
                    txtMinAlmacen.Text = rd3("Min").ToString
                    txtMaxAlmacen.Text = rd3("Max").ToString
                    txtComision.Text = rd3("Comision").ToString
                    cboProveedoresNormal.Text = rd3("ProvPri").ToString
                    cboProvEme.Text = rd3("ProvEme").ToString
                    cboDepartamentoNormal.Text = rd3("Departamento").ToString
                    cboGrupoNormal.Text = rd3("Grupo").ToString
                    cboImprimirComandaNormal.Text = rd3("GPrint").ToString
                    cboUbicacion.Text = rd3("Ubicacion").ToString
                    modo_almacen = rd3("Modo_Almacen").ToString

                    If modo_almacen = 1 Then
                        rboDescIngredientes.Checked = True
                    Else
                        rboDescProductos.Checked = False
                    End If


                End If
            End If
            rd3.Close()

            My.Application.DoEvents()
            If servidor <> "" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg")
                End If
            Else
                If File.Exists(equipo_servidor & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(equipo_servidor & "\ImagenesProductos\" & cboCodCortoNormal.Text & ".jpg")
                End If
            End If

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    grdpreferencia.Rows.Add(rd3("NombrePrefe").ToString)

                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    grdextras.Rows.Add(rd3("Codigo").ToString, rd3("Descx").ToString)
                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    grdpromociones.Rows.Add(rd3("Codigo").ToString, rd3("Descx").ToString)
                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    txtcantidadpromo.Text = rd3("F44").ToString
                End If
            End If
            rd3.Close()
            cnn3.Close()

            cboIvaNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCodCortoNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodCortoNormal.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            TraeDatos2("CODIGO")
            cboDescripcionTicketNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboIvaNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboIvaNormal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCompra.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCompra.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtVentaActual.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtVentaActual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentaActual.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtVentaMinima.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtVentaMinima_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentaMinima.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtUcompra.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtUcompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUcompra.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtUVenta.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtUVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUVenta.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMinAlmacen.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMinAlmacen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinAlmacen.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMaxAlmacen.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMaxAlmacen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaxAlmacen.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtComision.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtComision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComision.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboProveedoresNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboProveedoresNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProveedoresNormal.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboProvEme.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboProvEme_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProvEme.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboDepartamentoNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDepartamentoNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDepartamentoNormal.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboGrupoNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboGrupoNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboGrupoNormal.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboImprimirComandaNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboImprimirComandaNormal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboImprimirComandaNormal.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboUbicacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUbicacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardarNormal.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDescripcionTicketNormal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcionTicketNormal.SelectedValueChanged
        TraeDatos("NOMBRE")
    End Sub

    Private Sub cboIvaNormal_DropDown(sender As Object, e As EventArgs) Handles cboIvaNormal.DropDown
        cboIvaNormal.Items.Clear()

        cnn5.Close() : cnn5.Open()
        cmd5 = cnn5.CreateCommand
        cmd5.CommandText = "SELECT DISTINCT IVA FROM iva"
        rd5 = cmd5.ExecuteReader
        Do While rd5.Read
            If rd5.HasRows Then
                cboIvaNormal.Items.Add(rd5(0).ToString)
            End If
        Loop
        rd5.Close()
        cnn5.Close()
    End Sub

    Private Sub cboDescripcionTicketNormal_DropDown(sender As Object, e As EventArgs) Handles cboDescripcionTicketNormal.DropDown
        Try
            cboDescripcionTicketNormal.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDescripcionTicketNormal.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCodSat_DropDown(sender As Object, e As EventArgs) Handles cboCodSat.DropDown
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT ClaveSat FROM productos WHERE ClaveSat<>'' ORDER BY ClaveSat"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodSat.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboUnidadSat_DropDown(sender As Object, e As EventArgs) Handles cboUnidadSat.DropDown
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT UnidadSat FROM productos WHERE UnidadSat<>'' ORDER BY UnidadSat"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboUnidadSat.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnNuevoNormal_Click(sender As Object, e As EventArgs) Handles btnNuevoNormal.Click

        txtCodBarrasNormal.Text = ""
        cboCodCortoNormal.Text = ""
        cboDescripcionTicketNormal.Text = ""
        cboIvaNormal.Text = ""
        txtCompra.Text = ""
        txtVentaActual.Text = ""
        txtVentaMinima.Text = ""
        txtUcompra.Text = ""
        txtUVenta.Text = ""
        eqv1.Text = ""
        eqv2.Text = ""
        txtMinAlmacen.Text = ""
        txtMaxAlmacen.Text = ""
        txtComision.Text = "0"
        cboProveedoresNormal.Text = ""
        cboProvEme.Text = ""
        cboDepartamentoNormal.Text = ""
        cboGrupoNormal.Text = ""
        cboImprimirComandaNormal.Text = ""
        cboUbicacion.Text = ""
        cboCodSat.Text = ""
        txtCodSat.Text = ""
        cboUnidadSat.Text = ""
        txtUnidadSat.Text = ""
        rboDescIngredientes.Checked = False
        rboDescProductos.Checked = True

        cbopreferencia.Text = ""
        cboextras.Text = ""
        cbopromociones.Text = ""
        txtcantidadpromo.Text = "0"

        txtmilitros.Text = "0"
        txtcopas.Text = "0"

        grdpreferencia.Rows.Clear()
        grdextras.Rows.Clear()
        grdpromociones.Rows.Clear()

        picImagen.Image = Nothing

        cboDescripcionTicketNormal.Focus.Equals(True)

    End Sub

    Private Sub btnSalirNormal_Click(sender As Object, e As EventArgs) Handles btnSalirNormal.Click
        If MessageBox.Show("Desea Cerrar esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            frmProductos.ActiveForm.Close()
        End If
    End Sub

    Private Sub btnImagen_Click(sender As Object, e As EventArgs) Handles btnImagen.Click
        If cboCodCortoNormal.Text = "" Then MsgBox("Necesitas seleccionar un producto para asignar una imagen.", vbInformation + vbOKOnly, titulomensajes) : cboCodCortoNormal.Focus.Equals(True) : Exit Sub

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT * FROM Productos WHERE codigo='" & cboCodCortoNormal.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then

        Else
            MsgBox("Producto no valido", vbInformation + vbOKOnly, titulomensajes)

        End If
        rd1.Close()
        cnn1.Close()

        Dim imagen As New OpenFileDialog
        With imagen
            .Filter = "Archivos de imagen(*.jpg;*.png)|*jpg;*.png"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picImagen.Image = Image.FromFile(.FileName)
                picImagen.BackgroundImageLayout = ImageLayout.Center
            End If
        End With
    End Sub

    Private Sub btnEliminarNormal_Click(sender As Object, e As EventArgs) Handles btnEliminarNormal.Click

        Try

            If MsgBox("¿Desea eliminar este producto?", vbInformation + vbYesNo, titulomensajes) = vbYes Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodCortoNormal.Text & "' AND Nombre='" & cboDescripcionTicketNormal.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "DELETE FROM productos WHERE Codigo='" & cboCodCortoNormal.Text & "' AND Nombre='" & cboDescripcionTicketNormal.Text & "'"
                        cmd3.ExecuteNonQuery()



                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM  preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "'"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()


                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM miprod WHERE CodigoP='" & cboCodCortoNormal.Text & "' AND DescripP='" & cboDescripcionTicketNormal.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM miprod WHERE CodigoP='" & cboCodCortoNormal.Text & "' AND DescripP='" & cboDescripcionTicketNormal.Text & "'"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()
                        cnn3.Close()
                    End If
                Else
                    MsgBox("El producto no esta registrado", vbInformation + vbOKOnly, titulomensajes)
                End If
                rd2.Close()
                cnn2.Close()
                btnNuevoNormal.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub cbopreferencia_DropDown(sender As Object, e As EventArgs) Handles cbopreferencia.DropDown
        Try

            cbopreferencia.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT NombrePrefe FROM preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "' AND NombrePrefe<>'' ORDER BY NombrePrefe"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbopreferencia.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()

        End Try
    End Sub

    Private Sub cbopreferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbopreferencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If AscW(e.KeyChar) = Keys.Enter Then
            grdpreferencia.Rows.Add(cbopreferencia.Text)
            cbopreferencia.Text = ""
            cbopreferencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboextras_DropDown(sender As Object, e As EventArgs) Handles cboextras.DropDown
        Try
            cboextras.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Grupo='EXTRAS' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboextras.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboextras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboextras.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo FROM Productos WHERE Nombre='" & cboextras.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    grdextras.Rows.Add(rd1(0).ToString, cboextras.Text)
                    cboextras.Text = ""
                    cboextras.Focus.Equals(True)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        End If
    End Sub

    Private Sub cbopromociones_DropDown(sender As Object, e As EventArgs) Handles cbopromociones.DropDown
        Try
            cbopromociones.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Departamento='PROMOCIONES' AND Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbopromociones.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbopromociones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbopromociones.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo FROM Productos WHERE Nombre='" & cbopromociones.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    grdpromociones.Rows.Add(rd1(0).ToString, cbopromociones.Text)
                    cbopromociones.Text = ""
                    cbopromociones.Focus.Equals(True)

                End If
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub

    Private Sub grdpreferencia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpreferencia.CellDoubleClick
        Try

            Dim index As String = grdpreferencia.CurrentRow.Index
            Dim prefe As String = grdpreferencia.Rows(index).Cells(0).Value.ToString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM preferencia WHERE NombrePrefe='" & prefe & "' AND Codigo='" & cboCodCortoNormal.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM preferencia WHERE NombrePrefe='" & prefe & "' AND Codigo='" & cboCodCortoNormal.Text & "' "
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()


            grdpreferencia.Rows.Remove(grdpreferencia.CurrentRow)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdextras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdextras.CellDoubleClick
        Try

            Dim index As String = grdextras.CurrentRow.Index
            Dim codextra As String = grdextras.Rows(index).Cells(0).Value.ToString
            Dim extra As String = grdextras.Rows(index).Cells(1).Value.ToString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "' AND Codigo='" & codextra & "' AND Descx='" & extra & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "' AND Codigo='" & codextra & "' AND Descx='" & extra & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()


            grdextras.Rows.Remove(grdextras.CurrentRow)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdpromociones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpromociones.CellDoubleClick
        Try

            Dim index As String = grdpromociones.CurrentRow.Index
            Dim codpromo As String = grdpromociones.Rows(index).Cells(0).Value.ToString
            Dim promocion As String = grdpromociones.Rows(index).Cells(1).Value.ToString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "' AND Codigo='" & codpromo & "' AND Descx='" & promocion & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "' AND Codigo='" & codpromo & "' AND Descx='" & promocion & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()


            grdpromociones.Rows.Remove(grdpromociones.CurrentRow)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnGuardarNormal_Click(sender As Object, e As EventArgs) Handles btnGuardarNormal.Click
        Try
            If cboCodCortoNormal.Text = "" Then MsgBox("Ingrese el codigo del producto", vbInformation + vbOKOnly, titulomensajes) : cboCodCortoNormal.Focus.Equals(True) : Exit Sub
            If cboDescripcionTicketNormal.Text = "" Then MsgBox("Ingrese el nombre del producto", vbInformation + vbOKOnly, titulomensajes) : cboDescripcionTicketNormal.Focus.Equals(True) : Exit Sub
            If cboIvaNormal.Text = "" Then MsgBox("Seleccione el iva para el producto", vbInformation + vbOKOnly, titulomensajes) : cboIvaNormal.Focus.Equals(True) : Exit Sub


            Dim tipo_almacen As Integer = 0

            If rboDescIngredientes.Checked = True Then
                tipo_almacen = 1
            ElseIf rboDescProductos.Checked = True Then
                tipo_almacen = 0
            End If
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "UPDATE productos SET CodBarra='" & txtCodBarrasNormal.Text & "',Nombre='" & cboDescripcionTicketNormal.Text & "',IVA=" & cboIvaNormal.Text & ",UCompra='" & txtCompra.Text & "', UVenta='" & txtVentaActual.Text & "',UMinima='" & txtVentaMinima.Text & "',MCD='" & txtUcompra.Text & "',Multiplo='" & txtUVenta.Text & "',Min='" & txtMinAlmacen.Text & "',Max='" & txtMaxAlmacen.Text & "',Comision='" & txtComision.Text & "',ProvPri='" & cboProveedoresNormal.Text & "',ProvEme='" & cboProvEme.Text & "',ProvRes=0,Departamento='" & cboDepartamentoNormal.Text & "',Grupo='" & cboGrupoNormal.Text & "',Modo_Almacen=" & tipo_almacen & ",Ubicacion='" & cboUbicacion.Text & "',ClaveSat='" & txtCodSat.Text & "',UnidadSat='" & txtUnidadSat.Text & "',NumPromo='0',PercentIVAret=0,ISR=0,IIEPS=0,E1=0,E2=0,Mililitros=" & txtmilitros.Text & ",Copas=" & txtcopas.Text & ", Actu=0 WHERE Codigo='" & cboCodCortoNormal.Text & "'"
                    If cmd3.ExecuteNonQuery() Then
                        MsgBox("Producto actulizado correctamente", vbInformation + vbOKOnly, titulomensajes)
                    End If
                    cnn3.Close()

                End If
            Else

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO Productos(Codigo,CodBarra,Nombre,NombreLargo,UCompra,UVenta,UMinima,ProvPri,ProvEme,Departamento,Grupo,GPrint,Ubicacion,MCD,Multiplo,Min,Max,Comision,ClaveSat,UnidadSat,Modo_Almacen,Existencia,Fecha,Fecha_Inicial,Fecha_Final,Mililitros,Copas) VALUES('" & cboCodCortoNormal.Text & "','" & txtCodBarrasNormal.Text & "','" & cboDescripcionTicketNormal.Text & "','" & cboDescripcionTicketNormal.Text & "','" & txtCompra.Text & "','" & txtVentaActual.Text & "','" & txtVentaMinima.Text & "','" & cboProveedoresNormal.Text & "','" & cboProvEme.Text & "','" & cboDepartamentoNormal.Text & "','" & cboGrupoNormal.Text & "','" & cboImprimirComandaNormal.Text & "','" & cboUbicacion.Text & "'," & txtUcompra.Text & "," & txtUVenta.Text & "," & txtMinAlmacen.Text & "," & txtMaxAlmacen.Text & "," & txtComision.Text & ",'" & cboCodSat.Text & "','" & cboUnidadSat.Text & "'," & tipo_almacen & ",'0','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "'," & txtmilitros.Text & "," & txtcopas.Text & ")"

                If cmd3.ExecuteNonQuery() Then
                    MsgBox("Producto agregado correctamente", vbInformation + vbOKOnly, titulomensajes)
                End If
                cnn3.Close()

            End If
            rd2.Close()
            cnn2.Close()



            If grdpreferencia.Rows.Count > 0 Then
                For sasuke As Integer = 0 To grdpreferencia.Rows.Count - 1


                    Dim preferencia As String = grdpreferencia.Rows(sasuke).Cells(0).Value.ToString
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "' AND NombrePrefe='" & preferencia & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                        End If
                    Else
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "INSERT INTO preferencia(Codigo,NombrePrefe) VALUES('" & cboCodCortoNormal.Text & "','" & preferencia & "')"
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()
                    End If

                Next
                rd2.Close()
                cnn2.Close()
            End If

            If grdextras.Rows.Count > 0 Then
                For sakura As Integer = 0 To grdextras.Rows.Count - 1

                    Dim extras As String = grdextras.Rows(sakura).Cells(1).Value.ToString
                    Dim codigo As String = grdextras.Rows(sakura).Cells(0).Value.ToString
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM extras WHERE  CodigoAlpha='" & cboCodCortoNormal.Text & "' AND Codigo='" & codigo & "' AND Descx='" & extras & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                        End If
                    Else

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "INSERT INTO extras(CodigoAlpha,Codigo,Descx) VALUES('" & cboCodCortoNormal.Text & "','" & codigo & "','" & extras & "')"
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()
                    End If

                Next
                rd2.Close()
                cnn2.Close()
            End If

            If grdpromociones.Rows.Count > 0 Then
                For kakashi As Integer = 0 To grdpromociones.Rows.Count - 14

                    Dim codigo As String = grdpromociones.Rows(kakashi).Cells(0).Value.ToString
                    Dim promocion As String = grdpromociones.Rows(kakashi).Cells(1).Value.ToString
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELETC * FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "' AND Codigo='" & codigo & "' AND Descx='" & cboDescripcionTicketNormal.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                        End If
                    Else
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "INSERT INTO promociones(CodigoAlpha,Codigo,Descx) VALUES('" & cboCodCortoNormal.Text & "','" & codigo & "','" & promocion & "')"
                        cmd3.ExecuteNonQuery()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "UPDATE productos SET F44=" & txtcantidadpromo.Text & " WHERE Codigo='" & cboDepartamentoNormal.Text & "'"
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()


                    End If
                Next
                rd2.Close()
                cnn2.Close()
            End If


            btnNuevoNormal.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboCodCortoNormal_DropDown(sender As Object, e As EventArgs) Handles cboCodCortoNormal.DropDown
        Try
            cboCodCortoNormal.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM Productos WHERE Codigo<>'' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodCortoNormal.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCodCortoNormal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodCortoNormal.SelectedValueChanged

        Try

            grdpreferencia.Rows.Clear()
            grdextras.Rows.Clear()
            grdpromociones.Rows.Clear()

            Dim modo_almacen As Integer = 0

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM Productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then

                    txtCodBarrasNormal.Text = rd3("CodBarra").ToString
                    cboCodCortoNormal.Text = rd3("Codigo").ToString
                    cboDescripcionTicketNormal.Text = rd3("Nombre").ToString
                    cboIvaNormal.Text = rd3("IVA").ToString
                    txtCompra.Text = rd3("UCompra").ToString
                    txtVentaActual.Text = rd3("UVenta").ToString
                    txtVentaMinima.Text = rd3("UMinima").ToString
                    txtUcompra.Text = rd3("MCD").ToString
                    txtUVenta.Text = rd3("Multiplo").ToString
                    txtMinAlmacen.Text = rd3("Min").ToString
                    txtMaxAlmacen.Text = rd3("Max").ToString
                    txtComision.Text = rd3("Comision").ToString
                    cboProveedoresNormal.Text = rd3("ProvPri").ToString
                    cboProvEme.Text = rd3("ProvEme").ToString
                    cboDepartamentoNormal.Text = rd3("Departamento").ToString
                    cboGrupoNormal.Text = rd3("Grupo").ToString
                    cboImprimirComandaNormal.Text = rd3("GPrint").ToString
                    cboUbicacion.Text = rd3("Ubicacion").ToString
                    modo_almacen = rd3("Modo_Almacen").ToString

                    If modo_almacen = 1 Then
                        rboDescIngredientes.Checked = True
                    Else
                        rboDescProductos.Checked = False
                    End If

                    txtmilitros.Text = rd3("Mililitros").ToString
                    txtcopas.Text = rd3("Copas").ToString

                End If
            End If
            rd3.Close()

            My.Application.DoEvents()
            If servidor <> "" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg")
                End If
            Else
                If File.Exists(equipo_servidor & "\ProductosImg" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg") Then
                    picImagen.Image = Image.FromFile(equipo_servidor & "\ProductosImg" & baseseleccionada & "\" & cboCodCortoNormal.Text & ".jpg")
                End If
            End If

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    grdpreferencia.Rows.Add(rd3("NombrePrefe").ToString)

                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    grdextras.Rows.Add(rd3("Codigo").ToString, rd3("Descx").ToString)
                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    grdpromociones.Rows.Add(rd3("Codigo").ToString, rd3("Descx").ToString)
                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodCortoNormal.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    txtcantidadpromo.Text = rd3("F44").ToString
                End If
            End If
            rd3.Close()
            cnn3.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try


    End Sub

    Private Sub txtmilitros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmilitros.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtmilitros.Text) Then
                txtcopas.Focus.Equals(True)
            Else
                txtmilitros.Text = ""
            End If
        End If
    End Sub

    Private Sub txtcopas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcopas.KeyPress
        If AscW(e.Handled) = Keys.Enter Then
            If IsNumeric(txtcopas.Text) Then
                btnGuardarNormal.Focus.Equals(True)
            Else
                txtcopas.Text = ""
            End If
        End If
    End Sub

    Private Sub cboDepartamentoNormal_DropDown(sender As Object, e As EventArgs) Handles cboDepartamentoNormal.DropDown
        Try
            cboDepartamentoNormal.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Departamento FROM productos WHERE Departamento<>'' ORDER BY Departamento"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDepartamentoNormal.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
End Class