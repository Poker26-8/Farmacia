Public Class frmServicios

    Private Sub cboCodigo_DropDown(sender As System.Object, e As System.EventArgs) Handles cboCodigo.DropDown
        cboCodigo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Departamento='SERVICIOS' and Grupo='SERVICIOS' order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboCodigo.Items.Add(
                    rd1(0).ToString()
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
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select CodBarra,Nombre,IVA,PrecioVenta,PrecioVentaIVA,PreMin from Productos where Codigo='" & cboCodigo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtbarras.Text = rd1("CodBarra").ToString()
                        cboNombre.Text = rd1("Nombre").ToString()
                        cboIVA.Text = rd1("IVA").ToString()
                        txtVentasIVA.Text = FormatNumber(rd1("PrecioVenta").ToString(), 2)
                        txtVentacIVA.Text = FormatNumber(rd1("PrecioVentaIVA").ToString(), 2)
                        txtVentaMin.Text = FormatNumber(rd1("PreMin").ToString(), 2)
                    End If
                Else
                    cboNombre.Text = ""
                    cboIVA.Text = ""
                    txtVentasIVA.Text = "0.00"
                    txtVentacIVA.Text = "0.00"
                    txtVentaMin.Text = "0.00"
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cboNombre.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCodigo.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select CodBarra,Nombre,IVA,PrecioVenta,PrecioVentaIVA,PreMin from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtbarras.Text = rd1("CodBarra").ToString()
                    cboNombre.Text = rd1("Nombre").ToString()
                    cboIVA.Text = rd1("IVA").ToString()
                    txtVentasIVA.Text = FormatNumber(rd1("PrecioVenta").ToString(), 2)
                    txtVentacIVA.Text = FormatNumber(rd1("PrecioVentaIVA").ToString(), 2)
                    txtVentaMin.Text = FormatNumber(rd1("PreMin").ToString(), 2)
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Nombre from Productos where Departamento='SERVICIOS' and Grupo='SERVICIOS' order by Nombre"
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
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select CodBarra,Codigo,IVA,PrecioVenta,PrecioVentaIVA,PreMin from Productos where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtbarras.Text = rd1("CodBarra").ToString()
                        cboCodigo.Text = rd1("Codigo").ToString()
                        cboIVA.Text = rd1("IVA").ToString()
                        txtVentasIVA.Text = FormatNumber(rd1("PrecioVenta").ToString(), 2)
                        txtVentacIVA.Text = FormatNumber(rd1("PrecioVentaIVA").ToString(), 2)
                        txtVentaMin.Text = FormatNumber(rd1("PreMin").ToString(), 2)
                    End If
                Else
                    cboIVA.Text = ""
                    txtVentasIVA.Text = "0.00"
                    txtVentacIVA.Text = "0.00"
                    txtVentaMin.Text = "0.00"
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cboIVA.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select CodBarra,Codigo,IVA,PrecioVenta,PrecioVentaIVA,PreMin from Productos where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtbarras.Text = rd1("CodBarra").ToString()
                    cboCodigo.Text = rd1("Codigo").ToString()
                    cboIVA.Text = rd1("IVA").ToString()
                    txtVentasIVA.Text = FormatNumber(rd1("PrecioVenta").ToString(), 2)
                    txtVentacIVA.Text = FormatNumber(rd1("PrecioVentaIVA").ToString(), 2)
                    txtVentaMin.Text = FormatNumber(rd1("PreMin").ToString(), 2)
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboIVA_DropDown(sender As System.Object, e As System.EventArgs) Handles cboIVA.DropDown
        cboIVA.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IVA from IVA"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboIVA.Items.Add(
                    rd1("IVA").ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboIVA_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboIVA.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtVentasIVA.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtVentasIVA_GotFocus(sender As Object, e As System.EventArgs) Handles txtVentasIVA.GotFocus
        txtVentasIVA.SelectionStart = 0
        txtVentasIVA.SelectionLength = Len(txtVentasIVA.Text)
    End Sub

    Private Sub txtVentasIVA_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVentasIVA.KeyPress
        If Not IsNumeric(txtVentasIVA.Text) Then txtVentasIVA.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtVentasIVA.Text = FormatNumber(txtVentasIVA.Text, 2)
            txtVentacIVA.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtVentacIVA_GotFocus(sender As Object, e As System.EventArgs) Handles txtVentacIVA.GotFocus
        txtVentacIVA.SelectionStart = 0
        txtVentacIVA.SelectionLength = Len(txtVentacIVA.Text)
    End Sub

    Private Sub txtVentacIVA_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVentacIVA.KeyPress
        If Not IsNumeric(txtVentacIVA.Text) Then txtVentacIVA.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtVentaMin.Focus().Equals(True)
            txtVentacIVA.Text = FormatNumber(txtVentacIVA.Text, 2)
        End If
    End Sub

    Private Sub txtVentaMin_GotFocus(sender As Object, e As System.EventArgs) Handles txtVentaMin.GotFocus
        txtVentaMin.SelectionStart = 0
        txtVentaMin.SelectionLength = Len(txtVentaMin.Text)
    End Sub

    Private Sub txtVentaMin_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVentaMin.KeyPress
        If Not IsNumeric(txtVentaMin.Text) Then txtVentaMin.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
            txtVentaMin.Text = FormatNumber(txtVentaMin.Text, 2)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        cboCodigo.Items.Clear()
        cboCodigo.Text = ""
        cboNombre.Items.Clear()
        cboNombre.Text = ""
        cboIVA.Items.Clear()
        cboIVA.Text = ""
        txtVentasIVA.Text = "0.00"
        txtVentacIVA.Text = "0.00"
        txtVentaMin.Text = "0.00"
        txtbarras.Text = ""
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If cboCodigo.Text = "" Then MsgBox("Selecciona un producto para poder eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboCodigo.Focus().Equals(True) : Exit Sub
        If cboNombre.Text = "" Then MsgBox("Selecciona un producto para poder eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Codigo='" & cboCodigo.Text & "' and Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If Not rd1.HasRows Then
                MsgBox("No puedes eliminar un servicio que no está registrado en el catálogo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close()
                cnn1.Close()
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from Productos where Codigo='" & cboCodigo.Text & "' and Nombre='" & cboNombre.Text & "'"
            If cmd1.ExecuteNonQuery Then
                MsgBox("Servicio eliminado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnNuevo.PerformClick()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cboCodigo.Text = "" Then MsgBox("El código interno no puede estar vacío.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboCodigo.Focus().Equals(True) : Exit Sub
        If cboNombre.Text = "" Then MsgBox("Escribe le nombre del servicio para poder registrarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If cboIVA.Text = "" Then MsgBox("Selecciona un impuesto para el servicio. Sí el servicio no genera algún impuesto selecciona '0'.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboIVA.Focus().Equals(True) : Exit Sub
        If txtVentasIVA.Text = "" Then MsgBox("Escribe el precio de venta sin IVA para el servicio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtVentasIVA.Focus().Equals(True) : Exit Sub
        If txtVentacIVA.Text = "" Then MsgBox("Escribe el precio de venta con IVA para el servicio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtVentacIVA.Focus().Equals(True) : Exit Sub
        If txtVentaMin.Text = "" Then MsgBox("Escribe el precio de venta *mínimo* para el producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtVentaMin.Focus().Equals(True) : Exit Sub

        Dim precioventa As Double = txtVentasIVA.Text
        Dim precioiva As Double = txtVentacIVA.Text
        Dim preciominimo As Double = txtVentaMin.Text

        Dim fecha As String = Format(Date.Now, "yyyy-MM-dd")

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Departamento from Productos where Codigo='" & cboCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    'Actualiza
                    If rd1("Departamento").ToString = "SERVICIOS" Then
                        cnn2.Close() : cnn2.Open()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Productos set CodBarra='" & txtbarras.Text & "', Nombre='" & cboNombre.Text & "', IVA=" & cboIVA.Text & ", PrecioVenta=" & precioventa & ", PrecioVentaIVA=" & precioiva & ", PreMin=" & preciominimo & ", ClaveSat='" & txtCodigoSAT.Text & "', UnidadSat='" & txtClaveSAT.Text & "' where Codigo='" & cboCodigo.Text & "'"
                        If cmd2.ExecuteNonQuery Then
                            MsgBox("Servicio actualizado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            btnNuevo.PerformClick()
                        End If
                        cnn2.Close()
                    Else
                        MsgBox("Este código pertenece a un producto, no a un servicio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close() : cnn1.Close()
                        btnNuevo.PerformClick()
                        Exit Sub
                    End If
                End If
            Else
                'Inserta
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "insert into Productos(Codigo,CodBarra,Nombre,NombreLargo,ProvPri,ProvEme,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Ubicacion,Min,Max,Comision,PrecioVenta,PrecioVentaIVA,PreMin,IVA,Existencia,Fecha,pres_vol,id_tbMoneda,Promocion,Afecta_exis,ClaveSat,UnidadSat,Cargado,CargadoInv,Uso,Color,Genero,Marca,Articulo,Dia,Descu,Fecha_Inicial,Fecha_Final) values('" & cboCodigo.Text & "','" & txtbarras.Text & "','" & cboNombre.Text & "','','','',0,'N/A','N/A','N/A',1,1,'SERVICIOS','SERVICIOS','',1,1,0," & precioventa & "," & precioiva & "," & preciominimo & "," & cboIVA.Text & ",0,'" & fecha & "',0,1,0,0,'" & txtCodigoSAT.Text & "','" & txtClaveSAT.Text & "',0,0,'','','','','',0,'0','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                If cmd2.ExecuteNonQuery Then
                    MsgBox("Servicio agregado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnNuevo.PerformClick()
                End If
                cnn2.Close()
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtCodigoSAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoSAT.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Descripcion from ProductoSat where ClaveProdSat='" & txtCodigoSAT.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cboCodigoSAT.Text = rd1("Descripcion").ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cboCodigoSAT.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboCodigoSAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCodigoSAT.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select ClaveProdSat from ProductoSat where Descripcion='" & cboCodigoSAT.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtCodigoSAT.Text = rd1("ClaveProdSat").ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            txtClaveSAT.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtClaveSAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClaveSAT.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NomUnidad from UnidadMedSat where ClaveUnidad='" & txtClaveSAT.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cboClaveSAT.Text = rd1("NomUnidad").ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cboClaveSAT.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboClaveSAT_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboClaveSAT.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select ClaveUnidad from UnidadMedSat where NomUnidad='" & cboClaveSAT.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtClaveSAT.Text = rd1("ClaveUnidad").ToString()
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub frmServicios_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboCodigo.Focus().Equals(True)
    End Sub

    Private Sub txtbarras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtbarras.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select UVenta,Codigo,IVA,PrecioVenta,PrecioVentaIVA,PreMin from Productos where CodBarra='" & txtbarras.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If rd1("UVenta").ToString <> "N/A" Then
                                MsgBox("Ya cuentas con un producto registrado bajo este código de barras.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                btnNuevo.PerformClick()
                            End If
                            cboCodigo.Text = rd1("Codigo").ToString()
                            cboIVA.Text = rd1("IVA").ToString()
                            txtVentasIVA.Text = FormatNumber(rd1("PrecioVenta").ToString(), 2)
                            txtVentacIVA.Text = FormatNumber(rd1("PrecioVentaIVA").ToString(), 2)
                            txtVentaMin.Text = FormatNumber(rd1("PreMin").ToString(), 2)
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If
            cboCodigo.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class