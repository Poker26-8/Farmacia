
Imports System.IO
Public Class frmProductosSR

    Dim buscar As String = ""

    Public codigopromocion As String = ""

    Private Sub frmProductosSR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDescripcion.Focused.Equals(True)
        rboDescProductos.Checked = True
    End Sub

    Private Sub txtCodBarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodBarras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            TraerDatos("barra")
            cboDescripcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim modoalmacen As Integer = 0

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,IVA,UVenta,PrecioCompra,PrecioVentaIVA,PrecioDomicilioIVA,ProvPri,Departamento,Grupo,GPrint,Existencia,ProvRes,Modo_Almacen,CodBarra FROM Productos WHERE Nombre='" & cboDescripcion.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cboCodCorto.Text = rd1(0).ToString
                        cboIva.Text = rd1(1).ToString
                        txtUnidad.Text = rd1(2).ToString
                        txtPrecioCompra.Text = FormatNumber(rd1(3).ToString, 2)
                        txtPrecioLocal.Text = FormatNumber(rd1(4).ToString, 2)
                        txtPrecioDomicilio.Text = FormatNumber(rd1(5).ToString, 2)
                        cboProveedores.Text = rd1(6).ToString
                        cboDepartamento.Text = rd1(7).ToString
                        cboGrupo.Text = rd1(8).ToString
                        cboComanda.Text = rd1(9).ToString
                        txtExistencia.Text = rd1(10).ToString
                        chkKit.Checked = IIf(rd1(11).ToString, 1, 0)
                        modoalmacen = rd1(12).ToString
                        txtCodBarras.Text = rd1(13).ToString

                        If modoalmacen = 1 Then
                            rboDescIngredientes.Checked = True
                        Else
                            rboDescProductos.Checked = True
                        End If

                    End If
                End If
                rd1.Close()

                grdpromociones.Rows.Clear()
                grdextras.Rows.Clear()
                grdpreferencia.Rows.Clear()
                txtcantidadpromo.Text = "0"

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCorto.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        grdpreferencia.Rows.Add(rd1("NombrePrefe").ToString)

                    End If
                Loop
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,Descx FROM extras WHERE CodigoAlpha='" & cboCodCorto.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdextras.Rows.Add(rd1(0).ToString, rd1(1).ToString)
                    End If
                Loop
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT F44 FROM productos WHERE Codigo='" & cboCodCorto.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtcantidadpromo.Text = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,Descx FROM promociones WHERE CodigoAlpha='" & cboCodCorto.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdpromociones.Rows.Add(rd1(0).ToString, rd1(1).ToString)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                If servidor <> "" Then

                    If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg") Then
                        PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg")
                    End If
                Else
                    If File.Exists(equipo_servidor & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg") Then
                        PictureBox1.Image = Image.FromFile(equipo_servidor & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

            cboIva.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCodCorto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodCorto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim modoalmacen As Integer = 0

            grdextras.Rows.Clear()
            grdpreferencia.Rows.Clear()
            grdpromociones.Rows.Clear()
            txtcantidadpromo.Text = "0"

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT Nombre,IVA,UCompra,PrecioCompra,precioVentaIVA,PrecioDomicilioIVA,ProvPri,Departamento,Grupo,GPrint,Existencia,CodBarra,ProvRes,Modo_Almacen FROM Productos WHERE Codigo='" & cboCodCorto.Text & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then

                    cboDescripcion.Text = rd4(0).ToString
                    cboIva.Text = rd4(1).ToString
                    txtUnidad.Text = rd4(2).ToString
                    txtPrecioCompra.Text = rd4(3).ToString
                    txtPrecioLocal.Text = rd4(4).ToString
                    txtPrecioDomicilio.Text = rd4(5).ToString
                    cboProveedores.Text = rd4(6).ToString
                    cboDepartamento.Text = rd4(7).ToString
                    cboGrupo.Text = rd4(8).ToString
                    cboComanda.Text = rd4(9).ToString
                    txtExistencia.Text = rd4(10).ToString
                    txtCodBarras.Text = rd4(11).ToString
                    chkKit.Checked = IIf(rd4(12).ToString = "", 1, 0)
                    modoalmacen = rd4(13).ToString

                    If modoalmacen = 1 Then
                        rboDescIngredientes.Checked = True
                    Else
                        rboDescProductos.Checked = True
                    End If

                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCorto.Text & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then

                    grdpreferencia.Rows.Add(rd4("NombrePrefe").ToString)

                End If
            Loop
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT Codigo,Descx FROM extras WHERE CodigoAlpha='" & cboCodCorto.Text & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then
                    grdextras.Rows.Add(rd4(0).ToString, rd4(1).ToString)
                End If
            Loop
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT F44 FROM productos WHERE Codigo='" & cboCodCorto.Text & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    txtcantidadpromo.Text = rd4(0).ToString
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT Codigo,Descx FROM promociones WHERE Codigo='" & cboCodCorto.Text & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then
                    grdpromociones.Rows.Add(rd4(0).ToString, rd4(1).ToString)
                End If
            Loop
            rd4.Close()
            cnn4.Close()


            If servidor <> "" Then

                If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg") Then
                    PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg")
                End If
            Else
                If File.Exists(equipo_servidor & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg") Then
                    PictureBox1.Image = Image.FromFile(equipo_servidor & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg")
                End If
            End If



            cboDescripcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboIva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboIva.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtUnidad.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtUnidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnidad.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecioCompra.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecioCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioCompra.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecioLocal.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecioLocal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioLocal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecioDomicilio.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecioDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioDomicilio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboProveedores.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboProveedores_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProveedores.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboDepartamento.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDepartamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDepartamento.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboGrupo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboGrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboGrupo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboComanda.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboComanda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboComanda.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtExistencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtExistencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim img As String = ""
        If MsgBox("Desea guardar los datos", vbInformation + vbOKCancel, "Delsscom® Restaurant") = vbCancel Then
            Exit Sub
        End If

        Try
            Dim p_compra As Double = txtPrecioCompra.Text
            Dim iva As Double = cboIva.Text
            Dim p_venta As Double = txtPrecioLocal.Text
            Dim p_domicilio As Double = txtPrecioDomicilio.Text
            Dim p_ventaiva As Double = (1 + iva) * p_venta
            Dim p_domiiva As Double = (1 + iva) * p_domicilio


            Dim modo_almacen As Integer = 0

            If rboDescProductos.Checked = True Then
                modo_almacen = 0
            End If

            If rboDescIngredientes.Checked = True Then
                modo_almacen = 1
            End If

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & cboCodCorto.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Productos SET CodBarra='" & txtCodBarras.Text & "',Nombre='" & cboDescripcion.Text & "',IVA=" & cboIva.Text & ",UCompra='" & txtUnidad.Text & "',PrecioCompra=" & p_compra & ",PrecioVenta=" & p_venta & ",PrecioVentaIVA=" & p_ventaiva & ",PrecioDomicilio=" & p_domicilio & ",PrecioDomicilioIVA=" & p_domiiva & ",ProvPri='" & cboProveedores.Text & "',Departamento='" & cboDepartamento.Text & "',Grupo='" & cboGrupo.Text & "',GPrint='" & cboComanda.Text & "',Existencia=" & txtExistencia.Text & ",ProvRes=" & IIf(chkKit.Checked, 1, 0) & ",Modo_Almacen=" & modo_almacen & " WHERE Codigo='" & cboCodCorto.Text & "'"
                    If cmd2.ExecuteNonQuery() Then
                        My.Application.DoEvents()


                        If (PictureBox1.Image Is Nothing) Then
                        Else
                            If txtrutaimagen.Text <> "" Then
                                If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg") Then
                                    File.Delete(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg")
                                End If
                                PictureBox1.Image.Save(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                            End If
                        End If

                        MsgBox("Producto actualizado correctamente", vbInformation + vbOKOnly, titulomensajes)
                    End If
                    cnn2.Close()
                End If
            Else
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,UCompra,UVenta,UMInima,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioCompra,PrecioVenta,PrecioVentaIVA,PrecioDomicilio,PrecioDomicilioIVA,IVA,Existencia,id_tbMoneda,Almacen3,GPrint,Fecha,Fecha_Inicial,Fecha_Final,ProvRes,Modo_Almacen)VALUES('" & cboCodCorto.Text & "','" & txtCodBarras.Text & "','" & cboDescripcion.Text & "','" & cboDescripcion.Text & "','" & cboProveedores.Text & "','" & cboProveedores.Text & "','" & txtUnidad.Text & "','" & txtUnidad.Text & "','" & txtUnidad.Text & "',1,1,'" & cboDepartamento.Text & "','" & cboGrupo.Text & "','',1,1,0," & p_compra & "," & p_venta & "," & p_ventaiva & "," & p_domicilio & "," & p_domiiva & "," & cboIva.Text & "," & txtExistencia.Text & ",1," & p_venta & ",'" & cboComanda.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "'," & IIf(chkKit.Checked, 1, 0) & "," & modo_almacen & ")"
                If cmd2.ExecuteNonQuery() Then


                    crea_ruta(My.Application.Info.DirectoryPath & "\ImagenesProductos\")
                    If Not PictureBox1.Image Is Nothing Then
                        If img = My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg" Then
                        Else
                            PictureBox1.Image.Save(My.Application.Info.DirectoryPath & "\ImagenesProductos\", System.Drawing.Imaging.ImageFormat.Jpeg)
                        End If

                    End If

                    MsgBox("Producto agregado correctamente", vbInformation + vbOKOnly, titulomensajes)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

            If grdpreferencia.Rows.Count > 0 Then
                For luffy As Integer = 0 To grdpreferencia.Rows.Count - 1

                    Dim preferencia As String = grdpreferencia.Rows(luffy).Cells(0).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCorto.Text & "' AND NombrePrefe='" & preferencia & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO preferencia(Codigo,NombrePrefe) VALUES('" & cboCodCorto.Text & "','" & preferencia & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                    cnn1.Close()
                Next
            End If

            If grdextras.Rows.Count > 0 Then
                For goku As Integer = 0 To grdextras.Rows.Count - 1

                    Dim codigoextra As String = grdextras.Rows(goku).Cells(0).Value.ToString
                    Dim extra As String = grdextras.Rows(goku).Cells(1).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCorto.Text & "' AND Codigo='" & codigoextra & "' AND Descx='" & extra & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.HasRows Then

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO extras(CodigoAlpha,Codigo,Descx) VALUES('" & cboCodCorto.Text & "','" & codigoextra & "','" & extra & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                    cnn1.Close()
                Next
            End If

            If grdpromociones.Rows.Count > 0 Then

                If txtcantidadpromo.Text > 0 Then
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE Productos SET F44=" & txtcantidadpromo.Text & " WHERE Codigo='" & cboCodCorto.Text & "'"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()
                End If

                For picolo As Integer = 0 To grdpromociones.Rows.Count - 1

                    Dim codigopromo As String = grdpromociones.Rows(picolo).Cells(0).Value.ToString
                    Dim descpromo As String = grdpromociones.Rows(picolo).Cells(1).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM promociones WHERE Codigo='" & codigopromo & "' AND Descx='" & descpromo & "' AND Codigo='" & cboCodCorto.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO promociones(CodigoAlpha,Codigo,Descx) VALUES('" & cboCodCorto.Text & "','" & codigopromo & "','" & descpromo & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                    cnn1.Close()

                Next
            End If

            cboDescripcion.Focus.Equals(True)
            btnNuevo.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtCodBarras.Text = ""
        cboCodCorto.Text = ""
        cboDescripcion.Text = ""
        cboIva.Text = ""
        txtUnidad.Text = ""
        txtPrecioCompra.Text = "0.00"
        txtPrecioLocal.Text = "0.00"
        txtPrecioDomicilio.Text = "0.00"
        cboProveedores.Text = ""
        cboDepartamento.Text = ""
        cboGrupo.Text = ""
        cboComanda.Text = ""
        txtExistencia.Text = ""

        grdextras.Rows.Clear()
        grdpreferencia.Rows.Clear()
        grdpromociones.Rows.Clear()

        chkKit.Checked = False
        rboDescIngredientes.Checked = False
        rboDescProductos.Checked = False

        cbopreferencia.Text = ""
        cboextras.Text = ""
        cbopromociones.Text = ""
        txtcantidadpromo.Text = "0"
        PictureBox1.Image = Nothing
        TraerDatos("nada")
    End Sub

    Private Sub cboIva_DropDown(sender As Object, e As EventArgs) Handles cboIva.DropDown
        Try
            cboIva.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT IVA FROM iva ORDER BY IVA"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboIva.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        Try
            cboDescripcion.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Productos WHERE Nombre<>'' ORDER BY Nombre"
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
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCodCorto_DropDown(sender As Object, e As EventArgs) Handles cboCodCorto.DropDown
        Try
            cboCodCorto.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM Productos WHERE Codigo<>'' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodCorto.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboDepartamento_DropDown(sender As Object, e As EventArgs) Handles cboDepartamento.DropDown
        Try

            cboDepartamento.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Departamento FROM productos WHERE Departamento<>'' ORDER BY Departamento"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDepartamento.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboProveedores_DropDown(sender As Object, e As EventArgs) Handles cboProveedores.DropDown
        Try
            cboProveedores.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT NComercial FROM proveedores WHERE NComercial<>'' ORDER BY NComercial"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboProveedores.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboGrupo_DropDown(sender As Object, e As EventArgs) Handles cboGrupo.DropDown
        Try
            cboGrupo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Grupo FROM productos where Grupo<>'' ORDER BY Grupo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboGrupo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboComanda_DropDown(sender As Object, e As EventArgs) Handles cboComanda.DropDown
        Try

            cboComanda.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT GPrint FROM productos where GPrint<>'' ORDER BY GPrint"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboComanda.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbopreferencia_DropDown(sender As Object, e As EventArgs) Handles cbopreferencia.DropDown
        Try

            cbopreferencia.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT NombrePrefe FROM preferencia WHERE Codigo='" & cboCodCorto.Text & "' AND NombrePrefe<>'' ORDER BY NombrePrefe"
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

    Private Sub cboDescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedValueChanged
        cboDescripcion_KeyPress(cboDescripcion, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub cbopreferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbopreferencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If AscW(e.KeyChar) = Keys.Enter Then

            grdpreferencia.Rows.Add(cbopreferencia.Text)
            cbopreferencia.Text = ""
        End If
    End Sub

    Private Sub grdpreferencia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpreferencia.CellDoubleClick
        Try

            Dim index As String = grdpreferencia.CurrentRow.Index
            Dim prefe As String = grdpreferencia.Rows(index).Cells(0).Value.ToString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM preferencia WHERE NombrePrefe='" & prefe & "' AND Codigo='" & cboCodCorto.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM preferencia WHERE NombrePrefe='" & prefe & "' AND Codigo='" & cboCodCorto.Text & "' "
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

    Private Sub grdextras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdextras.CellDoubleClick
        Try

            Dim index As String = grdextras.CurrentRow.Index
            Dim codextra As String = grdextras.Rows(index).Cells(0).Value.ToString
            Dim extra As String = grdextras.Rows(index).Cells(1).Value.ToString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCorto.Text & "' AND Codigo='" & codextra & "' AND Descx='" & extra & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM extras WHERE CodigoAlpha='" & cboCodCorto.Text & "' AND Codigo='" & codextra & "' AND Descx='" & extra & "'"
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("Desea Cerrar esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            frmProductos.ActiveForm.Close()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try

            If MsgBox("¿Desea eliminar este producto?", vbInformation + vbYesNo, titulomensajes) = vbYes Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodCorto.Text & "' AND Nombre='" & cboDescripcion.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "DELETE FROM productos WHERE Codigo='" & cboCodCorto.Text & "' AND Nombre='" & cboDescripcion.Text & "'"
                        cmd3.ExecuteNonQuery()



                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM preferencia WHERE Codigo='" & cboCodCorto.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM  preferencia WHERE Codigo='" & cboCodCorto.Text & "'"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()


                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM extras WHERE CodigoAlpha='" & cboCodCorto.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM extras WHERE CodigoAlpha='" & cboCodCorto.Text & "'"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCorto.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM promociones WHERE CodigoAlpha='" & cboCodCorto.Text & "'"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd3.Close()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT * FROM miprod WHERE CodigoP='" & cboCodCorto.Text & "' AND DescripP='" & cboDescripcion.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "DELETE FROM miprod WHERE CodigoP='" & cboCodCorto.Text & "' AND DescripP='" & cboDescripcion.Text & "'"
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
                btnNuevo.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
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

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
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

        On Error GoTo nopasowey
        If cuadro_dialogo.FileName <> "" Then
            ruta = cuadro_dialogo.FileName.ToString

            con = New OleDb.OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" &
                "data source=" & ruta & "; " &
                "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            da = New OleDb.OleDbDataAdapter("select * from [" & sheet & "$]", con)

            con.Open()
            da.Fill(ds, "MyData")
            dt = ds.Tables("MyData")
            tabla.DataSource = ds
            tabla.DataMember = "MyData"
            con.Close()
        End If

        Dim codigo, barras, nombre, proveedor, comanda, unidad, departamento, grupo, clavesat, unidadsat As String
        Dim IVA, PrecioCompra, PrecioVentaIVA, precioventa, PrecioVentadomicilio, precioventadomicilioiva, Existencia, MCD, Multiplo As Double
        Dim conteo As Integer = 0

        pbimportar.Value = 0
        pbimportar.Maximum = grdsql.Rows.Count

        cnn1.Close() : cnn1.Open()
        For luffy As Integer = 0 To grdsql.Rows.Count - 1
            codigo = NulCad(grdsql.Rows(luffy).Cells(0).Value.ToString())
            If codigo = "" Then Exit Sub
            barras = NulCad(grdsql.Rows(luffy).Cells(1).Value.ToString())
            nombre = NulCad(grdsql.Rows(luffy).Cells(2).Value.ToString())
            proveedor = NulCad(grdsql.Rows(luffy).Cells(3).Value.ToString())
            comanda = NulCad(grdsql.Rows(luffy).Cells(4).Value.ToString())
            unidad = NulCad(grdsql.Rows(luffy).Cells(5).Value.ToString())
            departamento = NulCad(grdsql.Rows(luffy).Cells(6).Value.ToString())
            grupo = NulCad(grdsql.Rows(luffy).Cells(7).Value.ToString())
            IVA = NulVa(grdsql.Rows(luffy).Cells(8).Value.ToString())
            PrecioCompra = NulVa(grdsql.Rows(luffy).Cells(9).Value.ToString)
            PrecioVentaIVA = NulVa(grdsql.Rows(luffy).Cells(10).Value.ToString())
            precioventa = NulVa(grdsql.Rows(luffy).Cells(11).Value.ToString())
            PrecioVentadomicilio = NulVa(grdsql.Rows(luffy).Cells(12).Value.ToString())
            precioventadomicilioiva = NulVa(grdsql.Rows(luffy).Cells(13).Value.ToString())
            Existencia = NulVa(grdsql.Rows(luffy).Cells(14).Value.ToString())
            clavesat = grdsql.Rows(luffy).Cells(15).Value.ToString
            unidadsat = grdsql.Rows(luffy).Cells(16).Value.ToString

            If (Comprueba(codigo, nombre, barras, proveedor)) Then



                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,IVA,UCompra,UVenta,UMinima,MCD,Multiplo,Min,Max,PrecioCompra,PorcMin,Porcentaje,PrecioVenta,PrecioVentaIVA,PrecioDomicilio,PrecioDom icilioIVA,PreMin,Departamento,Grupo,ProvRes,Existencia,Fecha,Fecha_Inicial,Fecha_Final) VALUES('" & codigo & "','" & barras & "','" & nombre & "','" & nombre & "','" & proveedor & "','" & proveedor & "'," & IVA & ",'" & unidad & "','" & unidad & "','" & unidad & "','1','1','1','1'," & PrecioCompra & ",'0','0'," & precioventa & "," & PrecioVentaIVA & "," & PrecioVentadomicilio & "," & precioventadomicilioiva & "," & PrecioVentadomicilio & ",'" & departamento & "','" & grupo & "','" & comanda & "'," & Existencia & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                If cmd1.ExecuteNonQuery Then

                Else

                End If
                cnn1.Close()
            Else
                conteo += 1
                pbimportar.Value = conteo
                Continue For
            End If
            conteo += 1
            pbimportar.Value = conteo
        Next
        cnn1.Close()
        MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        'grdsql.Rows.Clear()
        pbimportar.Value = 0

        Exit Sub
nopasowey:
        MsgBox(Err.Number & " - " & Err.Description &
               vbNewLine &
               "Ocurrió un error al intentar importar el archivo, inténtalo de nuevo más tarde. De persistir el problema comunícate con tu proveedor de sotware.", vbInformation + vbOKOnly, titulomensajes)
        Exit Sub
    End Sub

    Private Function Comprueba(ByVal codigo As String, ByVal nombre As String, ByVal barras As String, ByVal provee As String) As Boolean
        Dim valida As Boolean = True
        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT Id From Proveedores WHERE NComercial='" & provee & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
            Else

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO Proveedores(NComercial,Compania,RFC,CURP,Vendedor,Calle,Colonia,Delegacion,Entidad,CP,Telefono,Correo,Saldo,Credito,DiasCred) VALUES('" & provee & "','" & provee & "','','','','','','','','','','','0','0','0')"
                cmd3.ExecuteNonQuery()
                cnn3.Close()
            End If
        End If
        rd2.Close()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                MsgBox("Ya cuentas con un producto registrado con el código corto " & codigo & ".", vbInformation + vbOKOnly, titulomensajes)
                valida = False
            End If
        End If
        rd2.Close()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select * from Productos where CodBarra='" & barras & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then

            Else
                MsgBox("Ya cuentas con un producto registrado con el código de barras " & barras & ".", vbInformation + vbOKOnly, titulomensajes)
                valida = False
            End If
        End If
        rd2.Close()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select * from Productos where Nombre='" & nombre & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                MsgBox("Ya cuentas con un producto registrado con el nombre " & nombre & ".", vbInformation + vbOKOnly, titulomensajes)
                valida = False
            End If
        End If
        rd2.Close()
        cnn2.Close()
        Return valida
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboCodCorto.Text = "" Then MsgBox("Necesitas seleccionar un producto para asignar una imagen.", vbInformation + vbOKOnly, titulomensajes) : cboCodCorto.Focus.Equals(True) : Exit Sub
        txtrutaimagen.Text = ""
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT * FROM Productos WHERE codigo='" & cboCodCorto.Text & "'"
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
                txtrutaimagen.Text = .FileName
                PictureBox1.Image = Image.FromFile(.FileName)
                PictureBox1.BackgroundImageLayout = ImageLayout.Zoom


            End If
        End With
    End Sub

    Private Sub cboCodCorto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodCorto.SelectedValueChanged
        cboCodCorto_KeyPress(cboCodCorto, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Public Sub TraerDatos(ByVal dato As String)

        Try
            grdextras.Rows.Clear()
            grdpreferencia.Rows.Clear()
            grdpromociones.Rows.Clear()
            txtcantidadpromo.Text = "0"

            If dato = "barra" Then
                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT Codigo,Nombre,IVA,UCompra,PrecioCompra,precioVentaIVA,PrecioDomicilioIVA,ProvPri,Departamento,Grupo,GPrint,Existencia FROM Productos WHERE CodBarra='" & txtCodBarras.Text & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then

                        cboCodCorto.Text = rd3(0).ToString
                        cboDescripcion.Text = rd3(1).ToString
                        cboIva.Text = rd3(2).ToString
                        txtUnidad.Text = rd3(3).ToString
                        txtPrecioCompra.Text = rd3(4).ToString
                        txtPrecioLocal.Text = rd3(5).ToString
                        txtPrecioDomicilio.Text = rd3(6).ToString
                        cboProveedores.Text = rd3(7).ToString
                        cboDepartamento.Text = rd3(8).ToString
                        cboGrupo.Text = rd3(9).ToString
                        cboComanda.Text = rd3(10).ToString
                        txtExistencia.Text = rd3(11).ToString
                    End If
                End If
                rd3.Close()
                cnn3.Close()

                If servidor <> "" Then

                    If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg") Then
                        PictureBox1.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg")
                    End If
                Else
                    If File.Exists(equipo_servidor & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg") Then
                        PictureBox1.Image = Image.FromFile(equipo_servidor & "\ImagenesProductos\" & cboCodCorto.Text & ".jpg")
                    End If
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try


    End Sub

    Private Sub grdpromociones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpromociones.CellDoubleClick
        Try

            Dim index As String = grdpromociones.CurrentRow.Index
            Dim codpromo As String = grdpromociones.Rows(index).Cells(0).Value.ToString
            Dim promocion As String = grdpromociones.Rows(index).Cells(1).Value.ToString

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM promociones WHERE CodigoAlpha='" & cboCodCorto.Text & "' AND Codigo='" & codpromo & "' AND Descx='" & promocion & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "DELETE FROM promociones WHERE CodigoAlpha='" & cboCodCorto.Text & "' AND Codigo='" & codpromo & "' AND Descx='" & promocion & "'"
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

    Private Sub cbopromociones_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbopromociones.SelectedValueChanged
        'Try
        '    cnn2.Close() : cnn2.Open()
        '    cmd2 = cnn2.CreateCommand
        '    cmd2.CommandText = "SELECT Codigo FROM productos WHERE Nombre='" &  & "'"
        '    rd2 = cmd2.ExecuteReader
        '    If rd2.HasRows Then
        '        If rd2.Read Then
        '            codigopromocion = rd2(0).ToString
        '        End If
        '    End If
        '    rd2.Close()
        '    cnn2.Close()
        '    codigopromocion = ""

        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        '    cnn2.Close()
        'End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class