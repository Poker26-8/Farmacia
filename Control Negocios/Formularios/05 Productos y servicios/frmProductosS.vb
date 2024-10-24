Imports System.Net
Imports System.IO
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data
Imports System.Runtime.Remoting.Contexts

Public Class frmProductosS

    Private Sub ShowData(ByVal tipo As String)
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If tipo = "BARRAS" Then
                cmd1.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where CodBarra='" & txtbarras.Text & "'"
            End If

            If tipo = "BARRAS1" Then
                cmd1.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where CodBarra1='" & txtBarras1.Text & "'"
            End If

            If tipo = "BARRAS2" Then
                cmd1.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where CodBarra2='" & txtBarras2.Text & "'"
            End If

            If tipo = "CODIGO" Then
                cmd1.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where Codigo='" & cboCodigo.Text & "'"
            End If
            If tipo = "PRODU" Then
                cmd1.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where Nombre='" & cboNombre.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtbarras.Text = rd1("CodBarra").ToString()
                    txtBarras1.Text = rd1("CodBarra1").ToString
                    txtBarras2.Text = rd1("CodBarra2").ToString
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
                    chkUnico.Checked = IIf(rd1("Unico").ToString() = True, True, False)
                    cboComanda.Text = rd1("GPrint").ToString
                    txtpcompra.Enabled = False
                    txtpventa.Enabled = False
                    txtpcompra2.Enabled = False
                    txtutilidad.Enabled = False

                    lblExistencia.Visible = False
                    txtExistencia.Visible = False
                    txtExistencia.Text = "0"
                    chkAnti.Checked = IIf(rd1("Anti").ToString() = True, True, False)
                    cchkCaducidad.Checked = IIf(rd1("Caduca").ToString() = True, True, False)
                    chkControlado.Checked = IIf(rd1("Controlado").ToString() = True, True, False)
                    txtpmp.Text = FormatNumber(rd1("PrecioMaximoPublico").ToString, 2)
                    txtlaboratorio.Text = rd1("Laboratorio").ToString
                    txtPrincipioActivo.Text = rd1("PrincipioActivo").ToString
                    txtIEPS.Text = rd1("IIEPS").ToString
                End If
            End If
            rd1.Close()

            If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg") Then
                picImagen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg")
                txtrutaimagen.Text = ""
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub ShowData2(ByVal tipo As String)
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            If tipo = "BARRAS" Then
                cmd2.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Resumen,Descripcion_Tienda,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where CodBarra='" & txtbarras.Text & "'"
            End If

            If tipo = "BARRAS1" Then
                cmd2.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Resumen,Descripcion_Tienda,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where CodBarra1='" & txtBarras1.Text & "'"
            End If

            If tipo = "BARRAS2" Then
                cmd2.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Resumen,Descripcion_Tienda,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where CodBarra2='" & txtBarras2.Text & "'"
            End If

            If tipo = "CODIGO" Then
                cmd2.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Resumen,Descripcion_Tienda,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where Codigo='" & cboCodigo.Text & "'"
            End If
            If tipo = "PRODU" Then
                cmd2.CommandText =
                    "select CodBarra,CodBarra1,CodBarra2,Codigo,Nombre,IVA,UVenta,PrecioCompra,PrecioVentaIVA,ProvPri,Departamento,Grupo,Ubicacion,ProvRes,UnidadSat,ClaveSat,Porcentaje,Unico,GPrint,Resumen,Descripcion_Tienda,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado from Productos where Nombre='" & cboNombre.Text & "'"
            End If
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtbarras.Text = rd2("CodBarra").ToString()
                    txtBarras1.Text = rd2("CodBarra1").ToString
                    txtBarras2.Text = rd2("CodBarra2").ToString
                    cboCodigo.Text = rd2("Codigo").ToString()
                    cboNombre.Text = rd2("Nombre").ToString()
                    cboIVA.Text = rd2("IVA").ToString()
                    txtUnidad.Text = rd2("UVenta").ToString()
                    txtpcompra.Text = FormatNumber(rd2("PrecioCompra").ToString(), 2)
                    txtpcompra2.Text = FormatNumber(CDbl(txtpcompra.Text) * (1 + CDbl(cboIVA.Text)), 2)
                    txtpventa.Text = FormatNumber(rd2("PrecioVentaIVA").ToString(), 2)
                    cboProvP.Text = rd2("ProvPri").ToString()
                    cboDepto.Text = rd2("Departamento").ToString()
                    cboGrupo.Text = rd2("Grupo").ToString()
                    cboubicacion.Text = rd2("Ubicacion").ToString()
                    chkKIT.Checked = IIf(rd2("ProvRes").ToString() = True, True, False)
                    txtClaveSAT.Text = rd2("UnidadSat").ToString()
                    txtCodigoSAT.Text = rd2("ClaveSat").ToString()
                    txtutilidad.Text = rd2("Porcentaje").ToString()
                    chkUnico.Checked = IIf(rd2("Unico").ToString() = True, True, False)
                    cboComanda.Text = rd2("GPrint").ToString
                    txtpcompra.Enabled = False
                    txtpventa.Enabled = False
                    txtpcompra2.Enabled = False
                    txtutilidad.Enabled = False
                    chkAnti.Checked = IIf(rd2("Anti").ToString() = True, True, False)
                    cchkCaducidad.Checked = IIf(rd2("Caduca").ToString() = True, True, False)
                    txtpmp.Text = FormatNumber(rd2("PrecioMaximoPublico").ToString, 2)
                    txtlaboratorio.Text = rd2("Laboratorio").ToString
                    txtPrincipioActivo.Text = rd2("PrincipioActivo").ToString
                    txtIEPS.Text = rd2("IIEPS").ToString

                    'TIENDA LINEA
                    txt_resumen.Text = rd2("Resumen").ToString
                    txt_descripcion.Text = rd2("Descripcion_Tienda").ToString
                    chkControlado.Checked = IIf(rd2("Controlado").ToString() = True, True, False)

                    lblExistencia.Visible = False
                    txtExistencia.Visible = False
                    txtExistencia.Text = "0"
                End If
            End If
            rd2.Close()

            If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg") Then
                picImagen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg")
                txtrutaimagen.Text = ""
            End If
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub
    Private Sub txtbarras_GotFocus(sender As Object, e As System.EventArgs) Handles txtbarras.GotFocus
        txtbarras.SelectionStart = 0
        txtbarras.SelectionLength = Len(txtbarras.Text)
    End Sub

    Private Sub txtbarras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarras.KeyPress
        'If Not IsNumeric(txtbarras.Text) Then txtbarras.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtbarras.Text <> "" Then
                ShowData("BARRAS")
            End If
            txtBarras1.Focus().Equals(True)
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
                "select Codigo from Productos where Nombre='" & cboNombre.Text & "'"
            Else
                cmd1.CommandText =
                "select Codigo from Productos"
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
            cboIVA.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        ShowData2("PRODU")
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
            If cboCodigo.Text <> "" Then
                cboProvP.Focus().Equals(True)
            Else
                txtExistencia.Focus().Equals(True)
            End If

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
                "select distinct Nombre from Departamentos order by Nombre"
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
        e.Handled = True
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
                "select distinct Nombre from Grupo order by Nombre"
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
        e.Handled = True
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtbarras.Text = ""
        txtBarras1.Text = ""
        txtBarras2.Text = ""
        cboCodigo.Items.Clear()
        cboCodigo.Text = ""
        chkAnti.Checked = False
        cchkCaducidad.Checked = False
        chkControlado.Checked = False
        txtpmp.Text = "0.00"
        txtlaboratorio.Text = ""
        txtPrincipioActivo.Text = ""
        txtIEPS.Text = "0"
        'cboNombre.Items.Clear()
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
        chkUnico.Checked = False
        cboCodigo.Focus().Equals(True)
        cboComanda.Text = ""
        'TIENDA EN LINEA
        txt_resumen.Text = ""
        txt_descripcion.Text = ""

        lblExistencia.Visible = True
        txtExistencia.Text = "0"
        txtExistencia.Visible = True
    End Sub

    Private Sub btnImagen_Click(sender As System.Object, e As System.EventArgs) Handles btnImagen.Click
        Try
            If cboCodigo.Text = "" Then MsgBox("Necesitas seleccionar un producto para asignar una imagen.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboCodigo.Focus().Equals(True) : Exit Sub
            txtrutaimagen.Text = ""
            My.Application.DoEvents()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Codigo='" & cboCodigo.Text & "'"
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
        'If cboProvP.Text = "" Then MsgBox("Selecciona un proveedor de tu catálogo para este producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboProvP.Focus().Equals(True) : Exit Sub
        'If cboDepto.Text = "" Then MsgBox("Escribe o selecciona un deparatamento para el producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboDepto.Focus().Equals(True) : Exit Sub
        'If cboGrupo.Text = "" Then MsgBox("Escribe o selecciona en grupo para el producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboGrupo.Focus().Equals(True) : Exit Sub

        Dim p_compra As Double = txtpcompra.Text
        Dim p_venta As Double = txtpventa.Text
        Dim porcentaje As Double = txtutilidad.Text
        Dim iva As Double = cboIVA.Text
        Dim p_ventaiva As Double = p_venta
        Dim existencia As Double = txtExistencia.Text
        Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")
        Dim pmp As Double = txtpmp.Text
        Dim pa As String = txtPrincipioActivo.Text
        Dim lab As String = txtlaboratorio.Text
        Dim ieps As Double = IIf(txtIEPS.Text = "", 0, txtIEPS.Text)

        Dim img As String = ""


        crea_ruta("C:\DelsscomFarmacias\ProductosImg" & base)
        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\DelsscomFarmacias\ProductosImg" & base)
        End If

        If (CompruebaBarras(txtbarras.Text)) Then

        Else
            Exit Sub
        End If

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id from Proveedores where NComercial='" & cboProvP.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
            Else
                'MsgBox("Este proveedor no está registrado en el catálogo. Regístralo para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                'rd1.Close() : cnn1.Close() : Exit Sub
                rd1.Close()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into Proveedores(NComercial,Compania) values('" & cboProvP.Text & "','" & cboProvP.Text & "')"
                cmd1.ExecuteNonQuery()
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    'Actualiza
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "update Productos set CodBarra='" & txtbarras.Text & "',CodBarra1='" & txtBarras1.Text & "',CodBarra2='" & txtBarras2.Text & "', Nombre='" & cboNombre.Text & "', ProvPri='" & cboProvP.Text & "', IVA=" & cboIVA.Text & ", UVenta='" & txtUnidad.Text & "', PrecioCompra=" & p_compra & ", PrecioVenta=" & p_venta & ", PrecioVentaIVA=" & p_ventaiva & ", Departamento='" & cboDepto.Text & "', Grupo='" & cboGrupo.Text & "', Ubicacion='" & cboubicacion.Text & "', ProvRes=" & IIf(chkKIT.Checked, 1, 0) & ", ClaveSat='" & txtCodigoSAT.Text & "', UnidadSat='" & txtClaveSAT.Text & "', Unico=" & IIf(chkUnico.Checked = True, 1, 0) & ",GPrint='" & cboComanda.Text & "', Resumen='" & txt_resumen.Text & "', Descripcion_Tienda='" & txt_descripcion.Text & "', Actu=0, Anti=" & IIf(chkAnti.Checked = True, 1, 0) & ", Caduca=" & IIf(cchkCaducidad.Checked = True, 1, 0) & ",PrecioMaximoPublico=" & pmp & ",Laboratorio='" & lab & "',PrincipioActivo='" & pa & "',IIEPS=" & ieps & ",Controlado=" & IIf(chkControlado.Checked = True, 1, 0) & " where Codigo='" & cboCodigo.Text & "'"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Datos de producto actualizados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                        If (picImagen.Image Is Nothing) Then
                        Else
                            If txtrutaimagen.Text <> "" Then
                                If varrutabase <> "" Then
                                    If File.Exists("\\" & varrutabase & "\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg") Then
                                        File.Delete("\\" & varrutabase & "\v\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg")
                                    End If
                                    picImagen.Image.Save("\\" & varrutabase & "\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                                End If

                                If File.Exists("C:\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg") Then
                                    File.Delete("C:\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg")
                                End If
                                picImagen.Image.Save("C:\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                            End If
                        End If

                        btnNuevo.PerformClick()
                    End If
                    cnn2.Close()
                End If
            Else
                If iva = 0 Then
                    p_ventaiva = p_venta
                    'Else
                    '    p_ventaiva = (1 + iva) * p_venta
                End If
                'Inserta
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "insert into Productos(Codigo,CodBarra,CodBarra1,CodBarra2,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioCompra,PrecioVenta,PrecioVentaIVA,IVA,Existencia,Porcentaje,Fecha,pres_vol,id_tbMoneda,Promocion,Afecta_exis,Almacen3,ClaveSat,UnidadSat,Cargado,CargadoInv,Uso,Color,Genero,Marca,Articulo,Dia,Descu,Fecha_Inicial,Fecha_Final,Promo_Monedero,Unico,GPrint,Resumen,Descripcion_Tienda,Anti,Caduca,PrecioMaximoPublico,Laboratorio,PrincipioActivo,IIEPS,Controlado) values('" & cboCodigo.Text & "','" & txtbarras.Text & "','" & txtBarras1.Text & "','" & txtBarras2.Text & "','" & cboNombre.Text & "','" & cboNombre.Text & "','" & cboProvP.Text & "','" & cboProvP.Text & "'," & IIf(chkKIT.Checked, 1, 0) & ",'" & txtUnidad.Text & "','" & txtUnidad.Text & "','" & txtUnidad.Text & "',1,1,'" & cboDepto.Text & "','" & cboGrupo.Text & "','" & cboubicacion.Text & "',1,1,0," & p_compra & "," & p_venta & "," & p_ventaiva & "," & iva & "," & existencia & "," & porcentaje & ",'" & fecha & "',0,1,0,0," & p_compra & ",'" & txtCodigoSAT.Text & "','" & txtClaveSAT.Text & "',0,0,'','','','','',0,'0','" & fecha & "','" & fecha & "',0," & IIf(chkUnico.Checked = True, 1, 0) & ",'" & cboComanda.Text & "','" & txt_resumen.Text & "','" & txt_descripcion.Text & "'," & IIf(chkAnti.Checked, 1, 0) & "," & IIf(cchkCaducidad.Checked, 1, 0) & "," & pmp & ",'" & lab & "','" & pa & "'," & ieps & "," & IIf(chkControlado.Checked = True, 1, 0) & ")"
                If cmd2.ExecuteNonQuery Then
                    MsgBox("Datos de producto registrados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                    If (picImagen.Image Is Nothing) Then
                    Else
                        If txtrutaimagen.Text <> "" Then
                            If varrutabase <> "" Then
                                If File.Exists("\\" & varrutabase & "\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg") Then
                                    File.Delete("\\" & varrutabase & "\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg")
                                End If
                                picImagen.Image.Save("\\" & varrutabase & "\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                            End If

                            If File.Exists("C:\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg") Then
                                File.Delete("C:\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg")
                            End If
                            picImagen.Image.Save("C:\DelsscomFarmacias\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
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
                    "select Codigo from Productos where Codigo='" & cboCodigo.Text & "'"
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
                                If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg") Then
                                    File.Delete(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & cboCodigo.Text & ".jpg")
                                    picImagen.Image = Nothing
                                End If
                            Else
                                picImagen.Image = Nothing
                            End If
                        End If
                        MsgBox("Registro de producto eliminado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO productoeliminado(Codigo,Nombre,CargadoAndroid,Departamento) VALUES('" & cboCodigo.Text & "','" & cboNombre.Text & "',0,'" & cboDepto.Text & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "delete from Kits where Cod='" & cboCodigo.Text & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "delete from Kits where Codigo='" & cboCodigo.Text & "'"
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

    Private Async Sub frmProductosS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try

            Dim tiendalinea As Integer = DatosRecarga2("TiendaLinea")

            If tiendalinea = 1 Then
                btn_tienda.Visible = True
            Else
                btn_tienda.Visible = False
            End If
            Me.Show()
            txtbarras.Focus().Equals(True)
            My.Application.DoEvents()



            'RunAsyncFunctions()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
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
            Dim codigo, barras, nombre, unidad, proveedor, depto, grupo, prod_sat, unidad_sat, numparte As String
            Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")
            Dim iva, compra, compra_iva, venta_siva, venta_civa, porcentaje, existencia, ieps As Double
            Dim conteo As Integer = 0
            Dim antibio As Integer = 0

            Dim lote As String = ""
            Dim caducidad As Date = Date.Now

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1

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
                porcentaje = IIf(compra_iva = 0, 0, FormatNumber(((venta_civa * 100) / compra_iva) - 100, 2))
                proveedor = NulCad(DataGridView1.Rows(zef).Cells(7).Value.ToString())
                depto = NulCad(DataGridView1.Rows(zef).Cells(8).Value.ToString())
                grupo = NulCad(DataGridView1.Rows(zef).Cells(9).Value.ToString())
                prod_sat = NulCad(DataGridView1.Rows(zef).Cells(10).Value.ToString())
                unidad_sat = NulCad(DataGridView1.Rows(zef).Cells(11).Value.ToString())
                existencia = NulVa(DataGridView1.Rows(zef).Cells(12).Value.ToString())
                'ieps = NulVa(DataGridView1.Rows(zef).Cells(13).Value.ToString())
                'numparte = NulCad(DataGridView1.Rows(zef).Cells(14).Value.ToString())

                lote = NulCad(DataGridView1.Rows(zef).Cells(13).Value.ToString())
                caducidad = NulCad(IIf(DataGridView1.Rows(zef).Cells(14).Value.ToString() = "", Date.Now, DataGridView1.Rows(zef).Cells(14).Value.ToString()))
                antibio = NulVa(DataGridView1.Rows(zef).Cells(15).Value.ToString())

                caducidad = Format(caducidad, "yyyy-MM-dd")

                'If lote <> "" Then
                '    Lote_Caducidad(codigo, existencia, caducidad, lote)
                '    conteo += 1
                '    Continue For9
                'End If

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                nombre = Trim(Replace(nombre, "‘", ""))
                nombre = Trim(Replace(nombre, "'", "''"))
                nombre = Trim(Replace(nombre, "*", ""))
                nombre = Trim(Replace(nombre, "", ""))

                proveedor = Trim(Replace(proveedor, "'", "''"))
                depto = Trim(Replace(depto, "'", "''"))
                grupo = Trim(Replace(grupo, "'", "''"))


                If (Comprueba(codigo, nombre, barras, proveedor)) Then
                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioCompra,PrecioVenta,PrecioVentaIVA,IVA,Existencia,Porcentaje,Fecha,pres_vol,id_tbMoneda,Promocion,Afecta_exis,Almacen3,ClaveSat,UnidadSat,Cargado,CargadoInv,Uso,Color,Genero,Marca,Articulo,Dia,Descu,Fecha_Inicial,Fecha_Final,Promo_Monedero,Unico,Anti,GPrint) values('" & codigo & "','" & barras & "','" & nombre & "','" & nombre & "','" & proveedor & "','" & proveedor & "',0,'" & unidad & "','" & unidad & "','" & unidad & "',1,1,'" & depto & "','" & grupo & "','',1,1,0," & compra & "," & venta_siva & "," & venta_civa & "," & iva & "," & existencia & "," & porcentaje & ",'" & fecha & "',0,1,0,0," & compra & ",'" & prod_sat & "','" & unidad_sat & "',0,0,'','','','','',0,'0','" & fecha & "','" & fecha & "',0,0," & antibio & ",'')"
                    If cmd1.ExecuteNonQuery Then
                        If lote <> "" Then
                            Lote_Caducidad(codigo, existencia, caducidad, lote)
                        End If
                    Else
                        'MsgBox(codigo, nombre)
                    End If

                Else
                    MsgBox("El codigo " & codigo & " y nombre" & nombre & " ya existe.", vbInformation + vbOKOnly, titulocentral)

                    If lote <> "" Then

                        Lote_Caducidad(codigo, existencia, caducidad, lote)

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "UPDATE productos SET Existencia = Existencia + " & existencia & " WHERE Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()

                    End If

                    conteo += 1
                    barsube.Value = conteo

                    Continue For
                End If
                conteo += 1
                barsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Lote_Caducidad(ByVal codigo As String, ByVal cantidad As Double, ByVal fecha As String, ByVal lote As String)
        Dim caduci As Date = Nothing

        If fecha = "" Then
            caduci = Date.Now
        Else
            caduci = fecha
        End If
        Try
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Codigo from LoteCaducidad where Codigo='" & codigo & "' and Lote='" & lote & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                'Existe
                If rd2.Read Then
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "update LoteCaducidad set Cantidad=" & cantidad & " where Codigo='" & codigo & "' and Lote='" & lote & "'"

                    cmd3.ExecuteNonQuery()
                End If
            Else
                'No existe
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & codigo & "','" & lote & "','" & Format(caduci, "yyyy-MM-dd") & "'," & cantidad & ")"
                cmd3.ExecuteNonQuery()
            End If
            rd2.Close()
            cnn2.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Function Comprueba(ByVal codigo As String, ByVal nombre As String, ByVal barras As String, ByVal provee As String) As Boolean
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
                "select Codigo from Productos where Codigo='" & codigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'MsgBox("Ya cuentas con un producto registrado con el código corto " & codigo & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                    Exit Function
                End If
            End If
            rd2.Close()

            If barras <> "" Then
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select CodBarra from Productos where CodBarra='" & barras & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        'MsgBox("Ya cuentas con un producto registrado con el código de barras " & barras & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        valida = False
                        Exit Function
                    End If
                End If
                rd2.Close()
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Nombre from Productos where Nombre='" & nombre & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'MsgBox("Ya cuentas con un producto registrado con el nombre " & nombre & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                    Exit Function
                End If
            End If
            rd2.Close()

            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
        Return Nothing
    End Function

    Private Function CompruebaBarras(ByVal barras As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()

            If barras <> "" Then
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select CodBarra from Productos where CodBarra='" & barras & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        MsgBox("Ya cuentas con un producto registrado con el código de barras " & barras & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
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
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub Label3_DoubleClick(sender As Object, e As EventArgs) Handles Label3.DoubleClick
        frmsubeclientes.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub barsube_Click(sender As Object, e As EventArgs) Handles barsube.Click

    End Sub

    Private Sub cboComanda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboComanda.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        My.Application.DoEvents()
        Dim cnn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BaseExportar\DL1.mdb;;Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
        Dim cmd1 As OleDbCommand = New OleDbCommand
        Dim rd1 As OleDbDataReader
        Dim cuantos As Integer = 0
        Dim codigo As String = ""
        Dim codbarras As String = ""
        Dim nombre As String = ""
        Dim nombrelargo As String = ""
        Dim provpri As String = ""
        Dim proveme As String = ""
        Dim provres As Boolean = False
        Dim ucompra As String = ""
        Dim uventa As String = ""
        Dim ventamin As String = ""
        Dim mcd As Integer = 0
        Dim multiplo As Integer = 0
        Dim departamento As String = ""
        Dim grupo As String = ""
        Dim ubicacion As String = ""
        Dim min As Integer = 0
        Dim max As Integer = 0
        Dim comision As String = ""
        Dim preciocompra As Double = 0
        Dim porcentagemin As Double = 0
        Dim porcentage As Double = 0
        Dim precioventa As Double = 0
        Dim precioventaiva As Double = 0
        Dim precioventaminiva As Double = 0
        Dim iva As Double = 0
        Dim existencia As Double = 0
        Dim pormay As Double = 0
        Dim pormm As Double = 0
        Dim poresp As Double = 0
        Dim premay As Double = 0
        Dim premm As Double = 0
        Dim preesp As Double = 0
        Dim prelta As Double = 0
        Dim cantmin As Double = 0
        Dim cantmay As Double = 0
        Dim cantmm As Double = 0
        Dim cantesp As Double = 0
        Dim cantlta As Double = 0
        Dim cantmin2 As Double = 0
        Dim cantmay2 As Double = 0
        Dim cantmm2 As Double = 0
        Dim cantesp2 As Double = 0
        Dim cantlta2 As Double = 0
        Dim presvol As Boolean = False
        Dim id_tbmoneda As Integer = 0
        Dim almacen3 As Double = 0
        Dim clavesat As String = ""
        Dim claveunidad As String = ""
        Dim isr As Double = 0
        Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")

        Dim conteo As Integer = 0
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,VentaMin,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioCompra,PorcentageMin,Porcentage,PrecioVenta,PrecioVentaIVA,PecioVentaMinIVA,IVA,Existencia,PorMay,PorMm,PorEsp,PreMay,PreMM,PreEsp,PreLta,CantMin,CantMay,CantMM,CantEsp,CantLta,CantMin2,CantMay2,CantMM2,CantEsp2,CantLta2,pres_vol,id_tbMoneda,Almacen3,ClaveSat,ClaveUnidadSat,isr from Productos order by Codigo"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Do While rd1.Read
                    codigo = rd1("Codigo").ToString
                    codbarras = rd1("CodBarra").ToString
                    nombre = rd1("Nombre").ToString
                    nombrelargo = rd1("NombreLargo").ToString
                    provpri = rd1("ProvPri").ToString
                    proveme = rd1("ProvEme").ToString
                    provres = rd1("ProvRes").ToString
                    ucompra = rd1("UCompra").ToString
                    uventa = rd1("UVenta").ToString
                    ventamin = rd1("VentaMin").ToString
                    mcd = IIf(rd1("MCD").ToString = "", 0, rd1("MCD").ToString)
                    multiplo = IIf(rd1("Multiplo").ToString = "", 0, rd1("Multiplo").ToString)
                    departamento = rd1("Departamento").ToString
                    grupo = rd1("Grupo").ToString
                    ubicacion = rd1("Ubicacion").ToString
                    min = IIf(rd1("Min").ToString = "", 0, rd1("Min").ToString)
                    max = IIf(rd1("Max").ToString = "", 0, rd1("Max").ToString)
                    comision = rd1("Comision").ToString
                    preciocompra = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                    porcentagemin = IIf(rd1("PorcentageMin").ToString = "", 0, rd1("PorcentageMin").ToString)
                    porcentage = IIf(rd1("Porcentage").ToString = "", 0, rd1("Porcentage").ToString)
                    precioventa = IIf(rd1("PrecioVenta").ToString = "", 0, rd1("PrecioVenta").ToString)
                    precioventaiva = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)
                    precioventaminiva = IIf(rd1("PecioVentaMinIVA").ToString = "", 0, rd1("PecioVentaMinIVA").ToString)
                    iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                    existencia = IIf(rd1("Existencia").ToString = "", 0, rd1("Existencia").ToString)
                    pormay = IIf(rd1("PorMay").ToString = "", 0, rd1("PorMay").ToString)
                    pormm = IIf(rd1("PorMm").ToString = "", 0, rd1("PorMM").ToString)
                    poresp = IIf(rd1("PorEsp").ToString = "", 0, rd1("PorEsp").ToString)
                    premay = IIf(rd1("PreMay").ToString = "", 0, rd1("PreMay").ToString)
                    premm = IIf(rd1("PreMM").ToString = "", 0, rd1("PreMM").ToString)
                    preesp = IIf(rd1("PreEsp").ToString = "", 0, rd1("PreEsp").ToString)
                    prelta = IIf(rd1("PreLta").ToString = "", 0, rd1("PreLta").ToString)
                    cantmin = IIf(rd1("CantMin").ToString = "", 0, rd1("CantMin").ToString)
                    cantmay = IIf(rd1("CantMay").ToString = "", 0, rd1("CantMay").ToString)
                    cantmm = IIf(rd1("CantMM").ToString = "", 0, rd1("CantMM").ToString)
                    cantesp = IIf(rd1("CantEsp").ToString = "", 0, rd1("CantEsp").ToString)
                    cantlta = IIf(rd1("CantLta").ToString = "", 0, rd1("CantLta").ToString)
                    cantmin2 = IIf(rd1("CantMin2").ToString = "", 0, rd1("CantMin2").ToString)
                    cantmay2 = IIf(rd1("CantMay2").ToString = "", 0, rd1("CantMay2").ToString)
                    cantmm2 = IIf(rd1("CantMM2").ToString = "", 0, rd1("CantMM2").ToString)
                    cantesp2 = IIf(rd1("CantEsp2").ToString = "", 0, rd1("CantEsp2").ToString)
                    cantlta2 = IIf(rd1("CantLta2").ToString = "", 0, rd1("CantLta2").ToString)
                    presvol = rd1("pres_vol").ToString
                    id_tbmoneda = IIf(rd1("id_tbMoneda").ToString = "", 0, rd1("id_tbMoneda").ToString)
                    almacen3 = IIf(rd1("Almacen3").ToString = "", 0, rd1("Almacen3").ToString)
                    clavesat = rd1("ClaveSat").ToString
                    claveunidad = rd1("ClaveUnidadSat").ToString
                    isr = IIf(rd1("isr").ToString = "", 0, rd1("isr").ToString)


                    nombre = nombre.Replace("’", "")

                    nombrelargo = Trim(Replace(nombrelargo, "'", ""))
                    nombrelargo = nombrelargo.Replace("’", "")
                    My.Application.DoEvents()
                    nombre = Trim(Replace(nombre, "‘", ""))
                    nombre = Trim(Replace(nombre, "'", "''"))

                    nombre = Trim(Replace(nombre, "'", ""))
                    nombrelargo = Trim(Replace(nombrelargo, "'", ""))



                    My.Application.DoEvents()


                    codbarras = Trim(Replace(codbarras, "‘", ""))
                    codbarras = Trim(Replace(codbarras, "'", "''"))
                    '

                    nombrelargo = Trim(Replace(nombrelargo, "‘", ""))
                    nombrelargo = Trim(Replace(nombrelargo, "'", "''"))
                    provpri = Trim(Replace(provpri, "'", "''"))
                    departamento = Trim(Replace(departamento, "'", "''"))
                    grupo = Trim(Replace(grupo, "'", "''"))

                    departamento = Trim(Replace(departamento, "‘", "''"))
                    grupo = Trim(Replace(grupo, "‘", "''"))

                    'If (Comprueba(codigo, nombre, codbarras)) Then

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Insert into Productos(Codigo, CodBarra, nombre, nombrelargo, provpri, proveme, provres, ucompra, uventa, UMinima, mcd, multiplo, departamento, grupo, ubicacion, min, max, comision, preciocompra, PorcMin, Porcentaje, precioventa, precioventaiva,PreMin, iva, existencia, PorcMay, PorcMM, PorcEsp, premay, premm, preesp, CantMin1, CantMay1, CantMM1, CantEsp1, CantLst1, cantmin2, cantmay2, cantmm2, cantesp2, CantLst2, pres_vol, id_tbmoneda, almacen3, clavesat, UnidadSat, isr,Fecha,Fecha_inicial,fecha_final) values('" & codigo & "','" & codbarras & "','" & nombre & "','" & nombrelargo & "','" & provpri & "','" & proveme & "'," & provres & ",'" & ucompra & "','" & uventa & "','" & ventamin & "'," & mcd & "," & multiplo & ",'" & departamento & "','" & grupo & "','" & ubicacion & "'," & min & "," & max & ",'" & comision & "'," & preciocompra & "," & porcentagemin & "," & porcentage & "," & precioventa & "," & precioventaiva & "," & precioventaminiva & "," & iva & "," & existencia & "," & pormay & "," & pormm & "," & poresp & "," & premay & "," & premm & "," & preesp & "," & cantmin & "," & cantmay & "," & cantmm & "," & cantesp & "," & cantlta & "," & cantmin2 & "," & cantmay2 & "," & cantmm2 & "," & cantesp2 & "," & cantlta & "," & presvol & "," & id_tbmoneda & "," & almacen3 & ",'" & clavesat & "','" & claveunidad & "'," & isr & ",'" & fecha & "','" & fecha & "','" & fecha & "')"
                    If cmd2.ExecuteNonQuery Then
                        cuantos = cuantos + 1
                        txtbarras.Text = cuantos
                        My.Application.DoEvents()
                    Else
                        MsgBox("Revisa el codigo " & codigo & " hay un error", vbCritical + vbOKOnly)
                    End If

                    'Else
                    '    'conteo += 1
                    '    'barsube.Value = conteo
                    '    Continue Do
                    'End If


                Loop
                cnn2.Close()
                MsgBox("Se insertaron " & cuantos & " productos")
                rd1.Close()
                cnn1.Close()
                txtbarras.Text = ""
            End If
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        My.Application.DoEvents()
        Button1.Enabled = True
    End Sub

    Private Function Comprueba(ByVal cod As String, ByVal desc As String, ByVal codbarra As String) As Boolean
        Dim valida As Boolean = True

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select Codigo from Productos where Codigo='" & cod & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                'MsgBox("Ya cuentas con un producto registrado con el código corto " & cod & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                valida = False
            End If
        End If
        rd2.Close()

        If codbarra <> "" Then
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select CodBarra from Productos where CodBarra='" & codbarra & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'MsgBox("Ya cuentas con un producto registrado con el código de barras " & codbarra & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                End If
            End If
            rd2.Close()
        End If

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select Nombre from Productos where Nombre='" & desc & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                'MsgBox("Ya cuentas con un producto registrado con el nombre " & desc & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                valida = False
            End If
        End If
        rd2.Close()

        cnn2.Close()
        Return valida

    End Function




    Private Sub txtBarras1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarras1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtBarras1.Text <> "" Then
                ShowData("BARRAS1")
            End If
            txtBarras2.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtBarras2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarras2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtBarras2.Text <> "" Then
                ShowData("BARRAS2")
            End If
            cboNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub lblInfo_Click(sender As Object, e As EventArgs) Handles lblInfo.Click
        If lblInfo.Text = ">> Más Información" Then
            lblInfo.Text = "v Menos información"
            Me.Size = New Size(759, 688)
        Else
            lblInfo.Text = ">> Más Información"
            Me.Size = New Size(759, 447)
        End If
    End Sub

    Private Sub cboComanda_DropDown(sender As Object, e As EventArgs) Handles cboComanda.DropDown
        Try
            cboComanda.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT GPrint FROM productos WHERE Gprint<>'' ORDER BY GPrint"
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
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_10(DataGridView1)
        End If
    End Sub

    Private Sub Excel_Grid_10(ByVal tabla As DataGridView)
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
            Dim codigo, barras, nombre, unidad, proveedor, depto, grupo, prod_sat, unidad_sat, numparte As String
            Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")
            Dim iva, compra, compra_iva, venta_siva, venta_civa, porcentaje, existencia, ieps As Double
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1

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
                porcentaje = IIf(compra_iva = 0, 0, FormatNumber(((venta_civa * 100) / compra_iva) - 100, 2))
                proveedor = NulCad(DataGridView1.Rows(zef).Cells(7).Value.ToString())
                depto = NulCad(DataGridView1.Rows(zef).Cells(8).Value.ToString())
                grupo = NulCad(DataGridView1.Rows(zef).Cells(9).Value.ToString())
                prod_sat = NulCad(DataGridView1.Rows(zef).Cells(10).Value.ToString())
                unidad_sat = NulCad(DataGridView1.Rows(zef).Cells(11).Value.ToString())
                existencia = NulVa(DataGridView1.Rows(zef).Cells(12).Value.ToString())
                ieps = IIf(DataGridView1.Rows(zef).Cells(13).Value.ToString() = "", 0, DataGridView1.Rows(zef).Cells(13).Value.ToString())
                numparte = IIf(DataGridView1.Rows(zef).Cells(14).Value.ToString() = "", 0, DataGridView1.Rows(zef).Cells(14).Value.ToString())

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                nombre = Trim(Replace(nombre, "‘", ""))
                nombre = Trim(Replace(nombre, "'", "''"))
                proveedor = Trim(Replace(proveedor, "'", "''"))
                depto = Trim(Replace(depto, "'", "''"))
                grupo = Trim(Replace(grupo, "'", "''"))


                If (Comprueba(codigo, nombre, barras, proveedor)) Then
                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioCompra,PrecioVenta,PrecioVentaIVA,IVA,Existencia,Porcentaje,Fecha,pres_vol,id_tbMoneda,Promocion,Afecta_exis,Almacen3,ClaveSat,UnidadSat,Cargado,CargadoInv,Uso,Color,Genero,Marca,Articulo,Dia,Descu,Fecha_Inicial,Fecha_Final,Promo_Monedero,Unico,IIEPS,N_Serie,GPrint) values('" & codigo & "','" & barras & "','" & nombre & "','" & nombre & "','" & proveedor & "','" & proveedor & "',0,'" & unidad & "','" & unidad & "','" & unidad & "',1,1,'" & depto & "','" & grupo & "','',1,1,0," & compra & "," & venta_siva & "," & venta_civa & "," & iva & "," & existencia & "," & porcentaje & ",'" & fecha & "',0,1,0,0," & compra & ",'" & prod_sat & "','" & unidad_sat & "',0,0,'','','','','',0,'0','" & fecha & "','" & fecha & "',0,0," & ieps & ",'" & numparte & "','')"
                    If cmd1.ExecuteNonQuery Then

                    Else
                        MsgBox(codigo, nombre)
                    End If

                Else
                    MsgBox(codigo, nombre)
                    conteo += 1
                    barsube.Value = conteo

                    Continue For
                End If
                conteo += 1
                barsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQL2(DataGridView1)
        End If
    End Sub

    Private Sub Excel_Grid_SQL2(ByVal tabla As DataGridView)
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
            Dim codigo As String = ""
            Dim desdelista, hastalista, desdeminimo, hastaminimo, desdemayoreo, hastamayoreo, desdemedio, hastamedio, desdeespecial, hastaespecial As Double
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1

                codigo = NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString())
                If codigo = "" Then Exit For
                desdelista = NulVa(DataGridView1.Rows(zef).Cells(1).Value.ToString())
                hastalista = NulVa(DataGridView1.Rows(zef).Cells(2).Value.ToString())
                desdeminimo = NulVa(DataGridView1.Rows(zef).Cells(3).Value.ToString())
                hastaminimo = NulVa(DataGridView1.Rows(zef).Cells(4).Value.ToString())
                desdemayoreo = NulVa(DataGridView1.Rows(zef).Cells(5).Value.ToString())
                hastamayoreo = NulVa(DataGridView1.Rows(zef).Cells(6).Value.ToString())
                desdemedio = NulVa(DataGridView1.Rows(zef).Cells(7).Value.ToString())
                hastamedio = NulVa(DataGridView1.Rows(zef).Cells(8).Value.ToString())
                desdeespecial = NulVa(DataGridView1.Rows(zef).Cells(9).Value.ToString())
                hastaespecial = NulVa(DataGridView1.Rows(zef).Cells(10).Value.ToString())

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If



                If (Comprueba2(codigo)) Then
                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE productos SET CantLst1=" & desdelista & ",CantLst2=" & hastalista & ",CantMin1=" & desdeminimo & ",CantMin2=" & hastaminimo & ",CantMay1=" & desdemayoreo & ",CantMay2=" & hastamayoreo & ",CantMM1=" & desdemedio & ",CantMM2=" & hastamedio & ",CantEsp1=" & desdeespecial & ",CantEsp2=" & hastaespecial & " WHERE Codigo='" & codigo & "'"
                    If cmd1.ExecuteNonQuery Then

                    Else
                        'MsgBox(codigo, nombre)
                    End If

                Else
                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE productos SET CantLst1=" & desdelista & ",CantLst2=" & hastalista & ",CantMin1=" & desdeminimo & ",CantMin2=" & hastaminimo & ",CantMay1=" & desdemayoreo & ",CantMay2=" & hastamayoreo & ",CantMM1=" & desdemedio & ",CantMM2=" & hastamedio & ",CantEsp1=" & desdeespecial & ",CantEsp2=" & hastaespecial & " WHERE Codigo='" & codigo & "'"
                    If cmd1.ExecuteNonQuery Then

                    Else
                        'MsgBox(codigo, nombre)
                    End If

                    conteo += 1
                    barsube.Value = conteo

                    Continue For
                End If
                conteo += 1
                barsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Function Comprueba2(ByVal xxd As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Nombre from Departamentos where Nombre='" & xxd & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'MsgBox("Ya cuentas con un producto registrado con el código corto " & codigo & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                    Exit Function
                End If
            End If
            rd2.Close()
            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
        Return Nothing
    End Function
    Private Function Comprueba3(ByVal xd As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Nombre from Grupo where Nombre='" & xd & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'MsgBox("Ya cuentas con un producto registrado con el código corto " & codigo & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                    Exit Function
                End If
            End If
            rd2.Close()
            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
        Return Nothing
    End Function

    Private Sub btn_tienda_Click(sender As Object, e As EventArgs) Handles btn_tienda.Click
        box_tienda.Visible = True
        txt_resumen.Focus().Equals(True)
    End Sub

    Private Sub txt_resumen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_resumen.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txt_descripcion.Focus().Equals(True)
        End If
    End Sub

    Private Sub txt_descripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_descripcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btn_guardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        box_tienda.Visible = False
        btnGuardar.Focus().Equals(True)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Enabled = False
        My.Application.DoEvents()
        Dim cnn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BaseExportar\DL1.mdb;;Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
        Dim cmd1 As OleDbCommand = New OleDbCommand
        Dim rd1 As OleDbDataReader
        Dim codigo As String = ""
        Dim lote As String = ""
        Dim fecha As Date = Nothing
        Dim cantidad As Double = 0
        Dim cuantos As Integer = 0
        Dim fechaformateada As String = ""
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo,Lote,FechaCaducidad,Cantidad from LoteCaducidad"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                codigo = rd1("Codigo").ToString
                lote = rd1("Lote").ToString
                fecha = IIf(rd1("FechaCaducidad").ToString = "", Date.Now, rd1("FechaCaducidad"))
                cantidad = rd1("Cantidad").ToString
                fechaformateada = Format(fecha, "yyyy-MM-dd")
                cnn2.Close()
                cnn2.Open()
                My.Application.DoEvents()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & codigo & "','" & lote & "','" & fechaformateada & "'," & cantidad & ")"
                If cmd2.ExecuteNonQuery Then
                    cuantos = cuantos + 1
                    txtbarras.Text = cuantos
                    My.Application.DoEvents()
                Else
                    MsgBox("Hay un error con el codigo: " & codigo & " y el lote: " & lote, vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
            Loop
            MsgBox("Se insertaron " & cuantos & " lotes correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cnn2.Close()
            rd1.Close()
            cnn1.Close()
            My.Application.DoEvents()
            txtbarras.Text = ""
            Button4.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtExistencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExistencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboProvP.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQLD(DataGridView1)
        End If
    End Sub
    Private Sub Excel_Grid_SQLD(ByVal tabla As DataGridView)
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
            Dim nombre As String
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1


                nombre = UCase(NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString()))

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                nombre = Trim(Replace(nombre, "‘", ""))
                nombre = Trim(Replace(nombre, "'", "''"))
                nombre = Trim(Replace(nombre, "*", ""))
                nombre = Trim(Replace(nombre, "", ""))

                If (Comprueba2(nombre)) Then
                    If cnn1.State = 0 Then cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Departamentos(Nombre) values('" & nombre & "')"
                    If cmd1.ExecuteNonQuery Then
                        conteo += 1
                    End If
                Else
                    MsgBox("El Departamento " & nombre & " ya existe.", vbInformation + vbOKOnly, titulocentral)

                    Continue For
                End If
                barsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " Departamentos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Excel_Grid_SQLG(ByVal tabla As DataGridView)
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
            Dim nombre As String
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1


                nombre = UCase(NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString()))

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                nombre = Trim(Replace(nombre, "‘", ""))
                nombre = Trim(Replace(nombre, "'", "''"))
                nombre = Trim(Replace(nombre, "*", ""))
                nombre = Trim(Replace(nombre, "", ""))

                If (Comprueba3(nombre)) Then
                    If cnn1.State = 0 Then cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Grupo(Nombre) values('" & nombre & "')"
                    If cmd1.ExecuteNonQuery Then
                        conteo += 1
                    End If
                Else
                    MsgBox("El Grupo " & nombre & " ya existe.", vbInformation + vbOKOnly, titulocentral)

                    Continue For
                End If
                barsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " Grupos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQLG(DataGridView1)
        End If
    End Sub

    Private Sub cchkCaducidad_CheckedChanged(sender As Object, e As EventArgs) Handles cchkCaducidad.CheckedChanged
        If cchkCaducidad.Checked = False Then
            Try
                Dim cad As Integer = 0
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Caduca from Productos where Codigo='" & cboCodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cad = rd1(0).ToString
                    Else
                        cad = 0
                    End If
                Else

                End If
                rd1.Close()
                cnn1.Close()

                If cad = 1 Then
                    cnn1.Close()
                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Select Lote from LoteCaducidad where Codigo='" & cboCodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MsgBox("Necesitas terminar el producto con lotes registrados", vbInformation + vbOKOnly, "Delsscom Farmacias")
                            cchkCaducidad.Checked = True
                            Exit Sub
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmDepGrup.Close()
        My.Application.DoEvents()
        frmDepGrup.Show()
        frmDepGrup.BringToFront()
        My.Application.DoEvents()
        frmDepGrup.lblTipo.Text = "Catalogo de Departamentos"
        My.Application.DoEvents()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frmDepGrup.Close()
        My.Application.DoEvents()
        frmDepGrup.Show()
        frmDepGrup.BringToFront()
        My.Application.DoEvents()
        frmDepGrup.lblTipo.Text = "Catalogo de Grupos"
        My.Application.DoEvents()
    End Sub
End Class