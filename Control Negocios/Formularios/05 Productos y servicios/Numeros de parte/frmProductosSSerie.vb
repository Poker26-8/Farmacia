Imports System.Net
Imports System.IO
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data

Public Class frmProductosSSerie
    Private Sub ShowData(ByVal tipo As String)
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If tipo = "BARRAS" Then
                cmd1.CommandText =
                    "select * from Productos where CodBarra='" & txtbarras.Text & "'"
            End If
            If tipo = "CODIGO" Then
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & cboCodigo.Text & "'"
            End If
            If tipo = "PRODU" Then
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cboNombre.Text & "' and Length(Codigo)<=6"
            End If
            If tipo = "SERIE" Then
                cmd1.CommandText =
                    "select * from Productos where N_Serie='" & txtn_serie.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtbarras.Text = rd1("CodBarra").ToString()
                    cboCodigo.Text = rd1("Codigo").ToString()
                    cboNombre.Text = rd1("Nombre").ToString()
                    cboIVA.Text = rd1("IVA").ToString()
                    txtUnidad.Text = rd1("UVenta").ToString()
                    txtpcompra.Text = FormatNumber(rd1("PrecioCompra").ToString(), 2)
                    txtpcompra2.Text = FormatNumber(CDbl(txtpcompra.Text) * (1 + CDbl(cboIVA.Text)), 2)
                    txtpventa.Text = FormatNumber(rd1("PrecioVentaIVA").ToString(), 2)
                    cboProvP.Text = rd1("ProvPri").ToString()
                    cboDepto.Text = rd1("Departamento").ToString()
                    cboGrupo.Text = rd1("Grupo").ToString()
                    cboubicacion.Text = rd1("Ubicacion").ToString()
                    chkKIT.Checked = IIf(rd1("ProvRes").ToString() = True, True, False)
                    txtClaveSAT.Text = rd1("UnidadSat").ToString()
                    txtCodigoSAT.Text = rd1("ClaveSat").ToString()
                    txtutilidad.Text = rd1("Porcentaje").ToString()
                    txtn_serie.Text = rd1("N_Serie").ToString()
                    txtpcompra.Enabled = False
                    txtpventa.Enabled = False
                    txtpcompra2.Enabled = False
                    txtutilidad.Enabled = False
                End If
            End If
            rd1.Close()

            If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg") Then
                picImagen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg")
                txtrutaimagen.Text = ""
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmProductosSSerie_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtbarras_GotFocus(sender As Object, e As System.EventArgs) Handles txtbarras.GotFocus
        txtbarras.SelectionStart = 0
        txtbarras.SelectionLength = Len(txtbarras.Text)
    End Sub

    Private Sub txtbarras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarras.KeyPress
        If Not IsNumeric(txtbarras.Text) Then txtbarras.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtbarras.Text <> "" Then
                ShowData("BARRAS")
            End If
            cboCodigo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtCodigoSAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoSAT.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtClaveSAT.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtClaveSAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClaveSAT.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboClaveSAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtClaveSAT.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboCodigo_DropDown(sender As System.Object, e As System.EventArgs) Handles cboCodigo.DropDown
        cboCodigo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If cboNombre.Text <> "" Then
                cmd1.CommandText =
                "select * from Productos where Nombre='" & cboNombre.Text & "'"
            Else
                cmd1.CommandText =
                "select * from Productos"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboCodigo.Items.Add(
                    rd1("Codigo").ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCodigo_GotFocus(sender As Object, e As System.EventArgs) Handles cboCodigo.GotFocus
        cboCodigo.SelectionStart = 0
        cboCodigo.SelectionLength = Len(cboCodigo.Text)
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Len(cboCodigo.Text) >= 7 Then
            cboCodigo.Text = Strings.Left(cboCodigo.Text, Len(cboCodigo.Text) - 1)
            cboCodigo.SelectionStart = 0
            cboCodigo.SelectionLength = Len(cboCodigo.Text)
        End If
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboNombre.Focus().Equals(True)
            ShowData("CODIGO")
        End If
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCodigo.SelectedValueChanged
        ShowData("CODIGO")
    End Sub

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Productos order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboNombre.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_GotFocus(sender As Object, e As System.EventArgs) Handles cboNombre.GotFocus
        cboNombre.SelectionStart = 0
        cboNombre.SelectionLength = Len(cboNombre.Text)
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            ShowData("PRODU")
            txtn_serie.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        ShowData("PRODU")
    End Sub

    Private Sub cboIVA_DropDown(sender As System.Object, e As System.EventArgs) Handles cboIVA.DropDown
        cboIVA.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct IVA from IVA"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboIVA.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboIVA_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboIVA.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtUnidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtUnidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If (txtpcompra.Enabled) Then
                txtpcompra.Focus().Equals(True)
            Else
                cboProvP.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtpcompra_GotFocus(sender As Object, e As System.EventArgs) Handles txtpcompra.GotFocus
        txtpcompra.SelectionStart = 0
        txtpcompra.SelectionLength = Len(txtpcompra.Text)
    End Sub

    Private Sub txtpcompra_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpcompra.KeyPress
        If Not IsNumeric(txtpcompra.Text) Then txtpcompra.Text = "0.00" : Exit Sub
        If Not IsNumeric(txtpcompra2.Text) Then txtpcompra2.Text = "0.00" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtpcompra.Text = "" Then MsgBox("Campo obligatorio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            txtpcompra.Text = FormatNumber(txtpcompra.Text, 2)
            txtpcompra2.Text = CDbl(txtpcompra.Text) * (1 + CDbl(cboIVA.Text))
            txtpcompra2.Text = FormatNumber(txtpcompra2.Text, 2)
            txtpcompra2.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpventa_GotFocus(sender As Object, e As System.EventArgs) Handles txtpventa.GotFocus
        txtpventa.SelectionStart = 0
        txtpventa.SelectionLength = Len(txtpventa.Text)
    End Sub

    Private Sub txtpventa_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpventa.KeyPress
        If Not IsNumeric(txtpventa.Text) Then txtpventa.Text = "0.00" : Exit Sub
        If Not IsNumeric(txtpcompra2.Text) Then txtpcompra2.Text = "0.00" : Exit Sub
        If Not IsNumeric(txtutilidad.Text) Then txtutilidad.Text = "0" : Exit Sub

        If AscW(e.KeyChar) = Keys.Enter Then
            If txtpventa.Text = "" Then MsgBox("Campo obligatorio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            cboProvP.Focus().Equals(True)
            txtpventa.Text = FormatNumber(txtpventa.Text, 2)
            If CDec(txtpcompra2.Text) = 0 Then txtutilidad.Text = "0" : Exit Sub
            If Not txtpcompra2.Text = "" And Not txtpventa.Text = "" Then
                Dim compra As Double = txtpcompra2.Text
                Dim venta As Double = txtpventa.Text
                Dim utilidad As Double = 0
                Dim d As Double = 0

                d = venta * 100
                utilidad = (d / compra) - 100
                txtutilidad.Text = FormatNumber(utilidad, 1)
            End If
        End If
    End Sub

    Private Sub cboProvP_DropDown(sender As System.Object, e As System.EventArgs) Handles cboProvP.DropDown
        cboProvP.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct NComercial from Proveedores order by NComercial"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboProvP.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboProvP_GotFocus(sender As Object, e As System.EventArgs) Handles cboProvP.GotFocus
        cboProvP.SelectionStart = 0
        cboProvP.SelectionLength = Len(cboProvP.Text)
    End Sub

    Private Sub cboProvP_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboProvP.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboDepto.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboDepto_DropDown(sender As System.Object, e As System.EventArgs) Handles cboDepto.DropDown
        cboDepto.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Departamento from Productos order by Departamento"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboDepto.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDepto_GotFocus(sender As Object, e As System.EventArgs) Handles cboDepto.GotFocus
        cboDepto.SelectionStart = 0
        cboDepto.SelectionLength = Len(cboDepto.Text)
    End Sub

    Private Sub cboDepto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboGrupo.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboGrupo_DropDown(sender As System.Object, e As System.EventArgs) Handles cboGrupo.DropDown
        cboGrupo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Grupo from Productos where Departamento='" & cboDepto.Text & "' order by Grupo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboGrupo.Items.Add(
                        rd1(0).ToString()
                        )
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboGrupo_GotFocus(sender As Object, e As System.EventArgs) Handles cboGrupo.GotFocus
        cboGrupo.SelectionStart = 0
        cboGrupo.SelectionLength = Len(cboGrupo.Text)
    End Sub

    Private Sub cboGrupo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboGrupo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtbarras.Text = ""
        cboCodigo.Items.Clear()
        cboCodigo.Text = ""
        cboNombre.Items.Clear()
        cboNombre.Text = ""
        cboIVA.Items.Clear()
        cboIVA.Text = ""
        txtUnidad.Text = ""
        txtutilidad.Text = ""
        txtpcompra.Text = "0.00"
        txtpcompra.Enabled = True
        txtpcompra2.Text = "0.00"
        txtpcompra2.Enabled = True
        txtutilidad.Text = "0"
        txtutilidad.Enabled = True
        txtpventa.Text = "0.00"
        txtpventa.Enabled = True
        cboProvP.Items.Clear()
        cboProvP.Text = ""
        cboDepto.Items.Clear()
        cboDepto.Text = ""
        cboGrupo.Items.Clear()
        cboGrupo.Text = ""
        cboubicacion.Items.Clear()
        cboubicacion.Text = ""
        chkKIT.Checked = False
        txtCodigoSAT.Text = ""
        txtClaveSAT.Text = ""
        picImagen.Image = Nothing
        txtrutaimagen.Text = ""
        txtn_serie.Text = ""
        cboComanda.Text = ""
        cboCodigo.Focus().Equals(True)
    End Sub

    Private Sub btnImagen_Click(sender As System.Object, e As System.EventArgs) Handles btnImagen.Click
        Try
            If cboCodigo.Text = "" Then MsgBox("Necesitas seleccionar un producto para asignar una imagne.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboCodigo.Focus().Equals(True) : Exit Sub
            txtrutaimagen.Text = ""
            My.Application.DoEvents()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
            Else
                MsgBox("Producto no válido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close() : Exit Sub
            End If
            rd1.Close() : cnn1.Close()

            Dim imagen As New OpenFileDialog
            If (picImagen.Image Is Nothing) Then
            Else
                picImagen.Image.Dispose()
            End If
            With imagen
                .Filter = "Archivos de imagen (*.jpg;*.png)|*.jpg;*.png"
                If .ShowDialog = DialogResult.OK Then
                    txtrutaimagen.Text = .FileName
                    picImagen.Image = Image.FromFile(.FileName)
                    picImagen.BackgroundImageLayout = ImageLayout.Zoom
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cboCodigo.Text = "" Then MsgBox("El campo [Código] no puede estar vacío.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboCodigo.Focus().Equals(True) : Exit Sub
        If Len(cboCodigo.Text) > 6 Then MsgBox("El código corto debe de ser de 6 caracteres com máximo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboCodigo.Focus().Equals(True) : Exit Sub
        If cboNombre.Text = "" Then MsgBox("Necesitas escribir el nombre del producto." & vbNewLine & "(Descripción corta para el ticket de venta)", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True)
        If cboIVA.Text = "" Then MsgBox("Selecciona un impuesto válido para el producto. Sí el producto no genera impuestos, selecciona '0'.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboIVA.Focus().Equals(True) : Exit Sub
        If txtUnidad.Text = "" Then MsgBox("Escribe la unidad de venta del producto para poder registrarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocisos Pro") : txtUnidad.Focus().Equals(True) : Exit Sub
        If txtpcompra.Text = "" Then MsgBox("El precio de compra del producto no puede estar vacío, por defecto '0'.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtpcompra.Focus().Equals(True) : Exit Sub
        If txtpventa.Text = "" Then MsgBox("El precio de venta del producto no puede estar vacío, por defecto '0'.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtpventa.Focus().Equals(True) : Exit Sub
        If cboProvP.Text = "" Then MsgBox("Selecciona un proveedor de tu catálogo para este producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboProvP.Focus().Equals(True) : Exit Sub
        If cboDepto.Text = "" Then MsgBox("Escribe o selecciona un deparatamento para el producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDepto.Focus().Equals(True) : Exit Sub
        If cboGrupo.Text = "" Then MsgBox("Escribe o selecciona en grupo para el producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboGrupo.Focus().Equals(True) : Exit Sub

        Dim p_compra As Double = txtpcompra.Text
        Dim p_venta As Double = txtpventa.Text
        Dim porcentaje As Double = txtutilidad.Text
        Dim iva As Double = cboIVA.Text
        Dim p_ventaiva As Double = (1 + iva) * p_venta
        Dim existencia As Double = 0
        Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")

        Dim img As String = ""

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id from Proveedores where NComercial='" & cboProvP.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
            Else
                MsgBox("Este proveedor no está registrado en el catálogo. Regístralo para continuar." = vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close() : Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    'Actualiza
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "update Productos set CodBarra='" & txtbarras.Text & "', Nombre='" & cboNombre.Text & "', ProvPri='" & cboProvP.Text & "', IVA=" & cboIVA.Text & ", UVenta='" & txtUnidad.Text & "', PrecioCompra=" & p_compra & ", PrecioVenta=" & p_venta & ", PrecioVentaIVA=" & p_ventaiva & ", Departamento='" & cboDepto.Text & "', Grupo='" & cboGrupo.Text & "', Ubicacion='" & cboubicacion.Text & "', ProvRes=" & IIf(chkKIT.Checked, 1, 0) & ", ClaveSat='" & txtCodigoSAT.Text & "', UnidadSat='" & txtClaveSAT.Text & "', Unico=0, N_Serie='" & txtn_serie.Text & "',GPrint='" & cboComanda.Text & "' where Codigo='" & cboCodigo.Text & "'"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Datos de producto actualizados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                        If (picImagen.Image Is Nothing) Then
                        Else
                            If txtrutaimagen.Text <> "" Then
                                If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg") Then
                                    File.Delete(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg")
                                End If
                                picImagen.Image.Save(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                            End If
                        End If

                        btnNuevo.PerformClick()
                    End If
                    cnn2.Close()
                End If
            Else
                'Inserta
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "insert into Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioCompra,PrecioVenta,PrecioVentaIVA,IVA,Existencia,Porcentaje,Fecha,pres_vol,id_tbMoneda,Promocion,Afecta_exis,Almacen3,ClaveSat,UnidadSat,Cargado,CargadoInv,Uso,Color,Genero,Marca,Articulo,Dia,Descu,Fecha_Inicial,Fecha_Final,Promo_Monedero,Unico,N_Serie,GPrint) values('" & cboCodigo.Text & "','" & txtbarras.Text & "','" & cboNombre.Text & "','','" & cboProvP.Text & "','" & cboProvP.Text & "'," & IIf(chkKIT.Checked, 1, 0) & ",'" & txtUnidad.Text & "','" & txtUnidad.Text & "','" & txtUnidad.Text & "',1,1,'" & cboDepto.Text & "','" & cboGrupo.Text & "','" & cboubicacion.Text & "',1,1,0," & p_compra & "," & p_venta & "," & p_ventaiva & "," & iva & "," & existencia & "," & porcentaje & ",'" & fecha & "',0,1,0,0," & p_compra & ",'" & txtCodigoSAT.Text & "','" & txtClaveSAT.Text & "',0,0,'','','','','',0,'0','" & fecha & "','" & fecha & "',0,0,'" & txtn_serie.Text & "','" & cboComanda.Text & "')"
                If cmd2.ExecuteNonQuery Then
                    MsgBox("Datos de producto registrados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                    If (picImagen.Image Is Nothing) Then
                    Else
                        If txtrutaimagen.Text <> "" Then
                            If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg") Then
                                File.Delete(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg")
                            End If
                            picImagen.Image.Save(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        End If
                    End If

                    btnNuevo.PerformClick()
                End If
                cnn2.Close()
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If cboCodigo.Text = "" Then MsgBox("Selecciona un producto para poder eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboCodigo.Focus().Equals(True) : Exit Sub
        If cboNombre.Text = "" Then MsgBox("Selecciona un producto para poder eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub

        Try
            Dim elimina As Boolean = False
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & cboCodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        elimina = True
                    End If
                Else
                    MsgBox("No puedes eliminar un producto que no está registardo en el catálogo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    elimina = False
                    rd1.Close() : cnn1.Close() : Exit Sub
                End If
                rd1.Close()

                If (elimina) Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "delete from Productos where Codigo='" & cboCodigo.Text & "'"
                    If cmd1.ExecuteNonQuery Then

                        If (picImagen.Image Is Nothing) Then
                        Else
                            If txtrutaimagen.Text = "" Then
                                picImagen.Image.Dispose()
                                If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg") Then
                                    File.Delete(My.Application.Info.DirectoryPath & "\ProductosImg\" & cboCodigo.Text & ".jpg")
                                    picImagen.Image = Nothing
                                End If
                            Else
                                picImagen.Image = Nothing
                            End If
                        End If
                        MsgBox("Registro de producto eliminado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "delete from Kits where Cod='" & cboCodigo.Text & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "delete from Kits wwhere Codigo='" & cboCodigo.Text & "'"
                    cmd1.ExecuteNonQuery()

                End If
                btnNuevo.PerformClick()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
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
            Dim codigo, barras, nombre, unidad, proveedor, depto, grupo, prod_sat, unidad_sat, n_serie As String
            Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")
            Dim iva, compra, compra_iva, venta_siva, venta_civa, porcentaje As Double
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1
                codigo = NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString())
                If codigo = "" Then Exit For
                barras = NulCad(DataGridView1.Rows(zef).Cells(1).Value.ToString())
                nombre = UCase(NulCad(DataGridView1.Rows(zef).Cells(2).Value.ToString()))
                iva = NulVa(DataGridView1.Rows(zef).Cells(3).Value.ToString())
                unidad = NulCad(DataGridView1.Rows(zef).Cells(4).Value.ToString())
                compra = NulVa(DataGridView1.Rows(zef).Cells(5).Value.ToString())
                compra_iva = CDbl(compra) * (1 + CDbl(iva))
                venta_siva = FormatNumber(NulVa(DataGridView1.Rows(zef).Cells(6).Value.ToString()) / (1 + iva), 2)
                venta_civa = NulVa(DataGridView1.Rows(zef).Cells(6).Value.ToString())
                porcentaje = FormatNumber(((venta_civa * 100) / compra_iva) - 100, 2)
                proveedor = NulCad(DataGridView1.Rows(zef).Cells(7).Value.ToString())
                depto = NulCad(DataGridView1.Rows(zef).Cells(8).Value.ToString())
                grupo = NulCad(DataGridView1.Rows(zef).Cells(9).Value.ToString())
                prod_sat = NulCad(DataGridView1.Rows(zef).Cells(10).Value.ToString())
                unidad_sat = NulCad(DataGridView1.Rows(zef).Cells(11).Value.ToString())
                n_serie = NulCad(DataGridView1.Rows(zef).Cells(12).Value.ToString())

                If (Comprueba(codigo, nombre, barras, proveedor, n_serie)) Then
                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioCompra,PrecioVenta,PrecioVentaIVA,IVA,Existencia,Porcentaje,Fecha,pres_vol,id_tbMoneda,Promocion,Afecta_exis,Almacen3,ClaveSat,UnidadSat,Cargado,CargadoInv,Uso,Color,Genero,Marca,Articulo,Dia,Descu,Fecha_Inicial,Fecha_Final,Promo_Monedero,Unico,N_Serie) values('" & codigo & "','" & barras & "','" & nombre & "','" & nombre & "','" & proveedor & "','" & proveedor & "',0,'" & unidad & "','" & unidad & "','" & unidad & "',1,1,'" & depto & "','" & grupo & "','',1,1,0," & compra & "," & venta_siva & "," & venta_civa & "," & iva & ",0," & porcentaje & ",'" & fecha & "',0,1,0,0," & compra & ",'" & prod_sat & "','" & unidad_sat & "',0,0,'','','','','',0,'0','" & fecha & "','" & fecha & "',0,0,'" & txtn_serie.Text & "')"
                    cmd1.ExecuteNonQuery()
                Else
                    conteo += 1
                    barsube.Value = conteo
                    Continue For
                End If
                conteo += 1
                barsube.Value = conteo
            Next
            cnn1.Close()
            MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Function Comprueba(ByVal codigo As String, ByVal nombre As String, ByVal barras As String, ByVal provee As String, ByVal n_serie As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Id from Proveedores where NComercial='" & provee & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
            Else
                If cnn3.State = 0 Then cnn3.Open() : cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "insert into Proveedores(NComercial,Compania,RFC,CURP,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Saldo,Credito,DiasCred) values('" & provee & "','" & provee & "','','','','','','','','','','',0,0,0)"
                cmd3.ExecuteNonQuery() : cnn3.Close()
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Productos where Codigo='" & codigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MsgBox("Ya cuentas con un producto registrado con el código corto " & codigo & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                End If
            End If
            rd2.Close()

            If barras = "" Then
            Else
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where CodBarra='" & barras & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        MsgBox("Ya cuentas con un producto registrado con el código de barras " & barras & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        valida = False
                    End If
                End If
                rd2.Close()
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Productos where Nombre='" & nombre & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MsgBox("Ya cuentas con un producto registrado con el nombre " & nombre & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                End If
            End If
            rd2.Close()

            If n_serie = "" Then
            Else
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where N_Serie='" & n_serie & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        MsgBox("Ya cuentas con un producto registrado con el número de parte " & n_serie & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        valida = False
                    End If
                End If
                rd2.Close()
            End If

            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
        Return Nothing
    End Function

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

    Private Sub txtpcompra_Click(sender As System.Object, e As System.EventArgs) Handles txtpcompra.Click
        txtpcompra.SelectionStart = 0
        txtpcompra.SelectionLength = Len(txtpcompra.Text)
    End Sub

    Private Sub txtpcompra2_Click(sender As System.Object, e As System.EventArgs) Handles txtpcompra2.Click
        txtpcompra2.SelectionStart = 0
        txtpcompra2.SelectionLength = Len(txtpcompra2.Text)
    End Sub

    Private Sub txtpcompra2_GotFocus(sender As Object, e As System.EventArgs) Handles txtpcompra2.GotFocus
        txtpcompra2.SelectionStart = 0
        txtpcompra2.SelectionLength = Len(txtpcompra2.Text)
    End Sub

    Private Sub txtpcompra2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpcompra2.KeyPress
        If Not IsNumeric(txtpcompra.Text) Then txtpcompra.Text = "0.00" : Exit Sub
        If Not IsNumeric(txtpcompra2.Text) Then txtpcompra2.Text = "0.00" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtpcompra2.Text = "" Then MsgBox("Campo obligatorio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            txtpcompra2.Text = FormatNumber(txtpcompra2.Text, 2)
            txtpcompra.Text = CDbl(txtpcompra2.Text) / (1 + CDbl(cboIVA.Text))
            txtpcompra.Text = FormatNumber(txtpcompra.Text, 2)
            txtutilidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtutilidad_Click(sender As System.Object, e As System.EventArgs) Handles txtutilidad.Click
        txtutilidad.SelectionStart = 0
        txtutilidad.SelectionLength = Len(txtutilidad.Text)
    End Sub

    Private Sub txtutilidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtutilidad.GotFocus
        txtutilidad.SelectionStart = 0
        txtutilidad.SelectionLength = Len(txtutilidad.Text)
    End Sub

    Private Sub txtutilidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtutilidad.KeyPress
        If Not IsNumeric(txtutilidad.Text) Then txtutilidad.Text = "0" : Exit Sub
        If Not IsNumeric(txtpcompra2.Text) Then txtpcompra2.Text = "0.00" : Exit Sub
        If Not IsNumeric(txtpventa.Text) Then txtpventa.Text = "0.00" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtutilidad.Text = "" Then MsgBox("Campo obligatorio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            txtutilidad.Text = FormatNumber(txtutilidad.Text, 1)
            txtpventa.Text = CDbl(txtpcompra2.Text) * (1 + (CDbl(txtutilidad.Text) / 100))
            txtpventa.Text = FormatNumber(txtpventa.Text, 2)
            txtpventa.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtn_serie_Click(sender As Object, e As EventArgs) Handles txtn_serie.Click
        txtn_serie.SelectionStart = 0
        txtn_serie.SelectionLength = Len(txtn_serie.Text)
    End Sub

    Private Sub txtn_serie_GotFocus(sender As Object, e As EventArgs) Handles txtn_serie.GotFocus
        txtn_serie.SelectionStart = 0
        txtn_serie.SelectionLength = Len(txtn_serie.Text)
    End Sub

    Private Sub txtn_serie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtn_serie.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtn_serie.Text = "" Then
            Else
                ShowData("SERIE")
            End If
            cboIVA.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboubicacion_DropDown(sender As Object, e As EventArgs) Handles cboubicacion.DropDown
        cboubicacion.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Ubicacion from Productos order by Ubicacion"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboubicacion.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboubicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboubicacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboComanda.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboComanda_DropDown(sender As Object, e As EventArgs) Handles cboComanda.DropDown
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT GPrint FROM Productos WHERE GPrint<>'' ORDER BY GPrint"
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

    Private Sub cboComanda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboComanda.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub
End Class