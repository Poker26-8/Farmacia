Imports System.IO
Imports System.Data.OleDb
Public Class frmClientes

    Private Sub Info_Click(sender As System.Object, e As System.EventArgs) Handles Info.Click
        If Info.Text = "> Más información" Then
            Info.Text = "v Menos información"
            Me.Size = New Size(837, 437)
        Else
            Info.Text = "> Más información"
            Me.Size = New Size(837, 290)
        End If
    End Sub

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select distinct Nombre from Clientes where Nombre<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboNombre.Items.Add(
                    rd1(0).ToString
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
            If cboNombre.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select *  from Clientes where Nombre='" & cboNombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtId.Text = rd1("Id").ToString
                            cboRazon.Text = rd1("RazonSocial").ToString
                            cboTipo.Text = rd1("Tipo").ToString
                            cboRFC.Text = rd1("RFC").ToString
                            txtTelefono.Text = rd1("Telefono").ToString
                            txtCorreo.Text = rd1("Correo").ToString
                            txtCredito.Text = rd1("Credito").ToString
                            txtCredito.Text = FormatNumber(txtCredito.Text, 2)
                            txtDias.Text = rd1("DiasCred").ToString
                            cboVendedor.Text = rd1("Comisionista").ToString
                            chkSusp.Checked = IIf(rd1("Suspender").ToString = False, False, True)
                            txtCalle.Text = rd1("Calle").ToString
                            txtninterior.Text = rd1("NInterior").ToString
                            txtnexterior.Text = rd1("NExterior").ToString
                            txtColonia.Text = rd1("Colonia").ToString
                            txtCP.Text = rd1("CP").ToString
                            txtDelegacion.Text = rd1("Delegacion").ToString
                            txtEntidad.Text = rd1("Entidad").ToString
                            txtPais.Text = rd1("Pais").ToString
                            txtClaveRegFis.Text = rd1("RegFis").ToString
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            cboRazon.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        If cboNombre.Text = "" Then Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select *  from Clientes where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtId.Text = rd1("Id").ToString
                    cboRazon.Text = rd1("RazonSocial").ToString
                    cboTipo.Text = rd1("Tipo").ToString
                    cboRFC.Text = rd1("RFC").ToString
                    txtTelefono.Text = rd1("Telefono").ToString
                    txtCorreo.Text = rd1("Correo").ToString
                    txtCredito.Text = rd1("Credito").ToString
                    txtCredito.Text = FormatNumber(txtCredito.Text, 2)
                    txtDias.Text = rd1("DiasCred").ToString
                    cboVendedor.Text = rd1("Comisionista").ToString
                    chkSusp.Checked = IIf(rd1("Suspender").ToString = False, False, True)
                    txtCalle.Text = rd1("Calle").ToString
                    txtninterior.Text = rd1("NInterior").ToString
                    txtnexterior.Text = rd1("NExterior").ToString
                    txtColonia.Text = rd1("Colonia").ToString
                    txtCP.Text = rd1("CP").ToString
                    txtDelegacion.Text = rd1("Delegacion").ToString
                    txtEntidad.Text = rd1("Entidad").ToString
                    txtPais.Text = rd1("Pais").ToString
                    txtClaveRegFis.Text = rd1("RegFis").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboRazon_DropDown(sender As System.Object, e As System.EventArgs) Handles cboRazon.DropDown
        cboRazon.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select distinct RazonSocial from Clientes where RazonSocial<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboRazon.Items.Add(
                     rd1(0).ToString
                     )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboRazon_GotFocus(sender As Object, e As System.EventArgs) Handles cboRazon.GotFocus
        cboRazon.SelectionStart = 0
        cboRazon.SelectionLength = Len(cboRazon.Text)
    End Sub

    Private Sub cboRazon_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboRazon.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboRazon.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select *  from Clientes where RazonSocial='" & cboRazon.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtId.Text = rd1("Id").ToString
                            cboNombre.Text = rd1("Nombre").ToString
                            cboTipo.Text = rd1("Tipo").ToString
                            cboRFC.Text = rd1("RFC").ToString
                            txtTelefono.Text = rd1("Telefono").ToString
                            txtCorreo.Text = rd1("Correo").ToString
                            txtCredito.Text = rd1("Credito").ToString
                            txtCredito.Text = FormatNumber(txtCredito.Text, 2)
                            txtDias.Text = rd1("DiasCred").ToString
                            cboVendedor.Text = rd1("Comisionista").ToString
                            chkSusp.Checked = IIf(rd1("Suspender").ToString = False, False, True)
                            txtCalle.Text = rd1("Calle").ToString
                            txtninterior.Text = rd1("NInterior").ToString
                            txtnexterior.Text = rd1("NExterior").ToString
                            txtColonia.Text = rd1("Colonia").ToString
                            txtCP.Text = rd1("CP").ToString
                            txtDelegacion.Text = rd1("Delegacion").ToString
                            txtEntidad.Text = rd1("Entidad").ToString
                            txtPais.Text = rd1("Pais").ToString
                            txtClaveRegFis.Text = rd1("RegFis").ToString
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            cboTipo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboRazon_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboRazon.SelectedValueChanged
        If cboRazon.Text = "" Then Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from Clientes where RazonSocial='" &
                 cboRazon.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtId.Text = rd1("Id").ToString
                    cboNombre.Text = rd1("Nombre").ToString
                    cboTipo.Text = rd1("Tipo").ToString
                    cboRFC.Text = rd1("RFC").ToString
                    txtTelefono.Text = rd1("Telefono").ToString
                    txtCorreo.Text = rd1("Correo").ToString
                    txtCredito.Text = rd1("Credito").ToString
                    txtCredito.Text = FormatNumber(txtCredito.Text, 2)
                    txtDias.Text = rd1("DiasCred").ToString
                    cboVendedor.Text = rd1("Comisionista").ToString
                    chkSusp.Checked = IIf(rd1("Suspender").ToString = False, False, True)
                    txtCalle.Text = rd1("Calle").ToString
                    txtninterior.Text = rd1("NInterior").ToString
                    txtnexterior.Text = rd1("NExterior").ToString
                    txtColonia.Text = rd1("Colonia").ToString
                    txtCP.Text = rd1("CP").ToString
                    txtDelegacion.Text = rd1("Delegacion").ToString
                    txtEntidad.Text = rd1("Entidad").ToString
                    txtPais.Text = rd1("Pais").ToString
                    txtClaveRegFis.Text = rd1("RegFis").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboTipo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboTipo.Text = "" Then
                cboTipo.Text = "Lista"
            End If
            cboRFC.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboRFC_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboRFC.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboRFC.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Clientes where RFC='" & cboRFC.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtId.Text = rd1("Id").ToString
                            cboNombre.Text = rd1("Nombre").ToString
                            cboRazon.Text = rd1("RazonSocial").ToString
                            cboTipo.Text = rd1("Tipo").ToString
                            txtTelefono.Text = rd1("Telefono").ToString
                            txtCorreo.Text = rd1("Correo").ToString
                            txtCredito.Text = rd1("Credito").ToString
                            txtCredito.Text = FormatNumber(txtCredito.Text, 2)
                            txtDias.Text = rd1("DiasCred").ToString
                            cboVendedor.Text = rd1("Comisionista").ToString
                            chkSusp.Checked = IIf(rd1("Suspender").ToString = False, False, True)
                            txtCalle.Text = rd1("Calle").ToString
                            txtninterior.Text = rd1("NInterior").ToString
                            txtnexterior.Text = rd1("NExterior").ToString
                            txtColonia.Text = rd1("Colonia").ToString
                            txtCP.Text = rd1("CP").ToString
                            txtDelegacion.Text = rd1("Delegacion").ToString
                            txtEntidad.Text = rd1("Entidad").ToString
                            txtPais.Text = rd1("Pais").ToString
                            txtClaveRegFis.Text = rd1("RegFis").ToString
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If

            txtDias.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDias_GotFocus(sender As Object, e As System.EventArgs) Handles txtDias.GotFocus
        txtDias.SelectionStart = 0
        txtDias.SelectionLength = Len(txtDias.Text)
    End Sub

    Private Sub txtDias_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDias.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCredito.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCredito_GotFocus(sender As Object, e As System.EventArgs) Handles txtCredito.GotFocus
        txtCredito.SelectionStart = 0
        txtCredito.SelectionLength = Len(txtCredito.Text)
    End Sub

    Private Sub txtCredito_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCredito.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboVendedor.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboVendedor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorreo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboregimen.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cboNombre.Text = "" Then MsgBox("Necesitas escribir el nombre del cliente para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If cboTipo.Text = "" Then MsgBox("Selecciona el tipo de cliente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboTipo.Focus().Equals(True) : Exit Sub
        If cboRazon.Text = "" Then MsgBox("Necesitas escribir la razón social del cliente para continuar." & vbNewLine & "En caso de no conocerlo, puede ser el mismo que el nombre comercial.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboRazon.Focus().Equals(True) : Exit Sub

        Dim existe As Boolean = False
        Dim sql As String = ""
        'Consulta sí ya existe o no
        If txtId.Text <> "" Then
            existe = True
        Else
            existe = False
        End If

        Try
            If existe Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Clientes where Id=" & txtId.Text & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'Actualiza
                        sql = "update Clientes set Tipo='" & cboTipo.Text & "', RFC='" & cboRFC.Text & "', Telefono='" & txtTelefono.Text & "', Correo='" & txtCorreo.Text & "', Credito=" & CDbl(txtCredito.Text) & ", DiasCred=" & txtDias.Text & ", Comisionista='" & cboVendedor.Text & "', Suspender=" & IIf(chkSusp.Checked, 1, 0) & ", Calle='" & txtCalle.Text & "', Colonia='" & txtColonia.Text & "', CP='" & txtCP.Text & "', Delegacion='" & txtDelegacion.Text & "', Entidad='" & txtEntidad.Text & "', Pais='" & txtPais.Text & "', RegFis='" & txtClaveRegFis.Text & "', NInterior='" & txtninterior.Text & "', NExterior='" & txtnexterior.Text & "',RazonSocial='" & cboRazon.Text & "' where Id=" & txtId.Text
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    sql
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos actualizados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If

                cnn1.Close()
            Else
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Clientes where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    MsgBox("Al parecer ya hay un cliente registrado bajo ese nombre.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    cboNombre.Focus.Equals(True)
                    Exit Sub
                Else
                    sql = "insert into Clientes(Nombre,RazonSocial,Tipo,RFC,Telefono,Correo,Credito,DiasCred,Comisionista,Suspender,Calle,Colonia,CP,Delegacion,Entidad,Pais,RegFis,NInterior,NExterior) values('" & cboNombre.Text & "','" & cboRazon.Text & "','" & cboTipo.Text & "','" & cboRFC.Text & "','" & txtTelefono.Text & "','" & txtCorreo.Text & "'," & CDbl(txtCredito.Text) & "," & txtDias.Text & ",'" & cboVendedor.Text & "'," & IIf(chkSusp.Checked, 1, 0) & ",'" & txtCalle.Text & "','" & txtColonia.Text & "','" & txtCP.Text & "','" & txtDelegacion.Text & "','" & txtEntidad.Text & "','" & txtPais.Text & "','" & txtClaveRegFis.Text & "','" & txtninterior.Text & "','" & txtnexterior.Text & "')"
                End If
                rd1.Close()

                cnn1.CreateCommand()
                cmd1.CommandText =
                    sql
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos guardados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If

                cnn1.Close()
            End If

            btnNuveo.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnNuveo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuveo.Click
        txtId.Text = ""
        cboNombre.Text = ""
        cboRazon.Text = ""
        cboTipo.Text = ""
        cboRFC.Text = ""
        txtDias.Text = "0"
        txtCredito.Text = "0.00"
        cboVendedor.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        chkSusp.Checked = False
        txtCalle.Text = ""
        txtColonia.Text = ""
        txtCP.Text = ""
        txtDelegacion.Text = ""
        txtEntidad.Text = ""
        txtPais.Text = ""
        cboregimen.Text = ""
        txtnexterior.Text = ""
        txtninterior.Text = ""
        cboregimen.Items.Clear()
        txtClaveRegFis.Text = ""
        Info.Text = "> Más información"
        Me.Size = New Size(496, 265)
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        'Eliminar el registro activo, tiene que haber un cliente seleccionado
        If txtId.Text = "" Then
            MsgBox("Necesitas seleccionar un cliente para poder eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cboNombre.Focus.Equals(True)
            Exit Sub
        Else
            If MsgBox("¿Deseas eliminar los datos de éste cliente?" & vbNewLine & "Ésta acción no se puede deshacer.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "delete from Clientes where Id=" & txtId.Text
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "delete from Entregas where IdCliente=" & txtId.Text
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()

                    btnNuveo.PerformClick()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub btnDomicilios_Click(sender As System.Object, e As System.EventArgs) Handles btnDomicilios.Click
        If txtId.Text = "" Then
            MsgBox("Necesitas seleccionar un cliente para poder agregarle direcciones de entrega.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cboNombre.Focus.Equals(True)
            Exit Sub
        Else
            frmEntregas.txtNombre.Text = cboNombre.Text
            frmEntregas.txtId.Text = txtId.Text
            frmEntregas.Show(Me)
        End If
    End Sub

    Private Sub frmClientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtId.Text = ""
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='Migracion'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = "0" Then

                        cnn2.Close() : cnn2.Open()

                        cnn2.Close()

                    Else
                        btnmigra.Visible = False
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboRFC_DropDown(sender As System.Object, e As System.EventArgs) Handles cboRFC.DropDown
        cboRFC.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand()
            cmd1.CommandText =
                 "select distinct RFC from Clientes where RFC<>'' order by RFC asc"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboRFC.Items.Add(
                     rd1(0).ToString
                     )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtCalle_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCP.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCP_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtninterior.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtColonia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtColonia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtDelegacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDelegacion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDelegacion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEntidad.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEntidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEntidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPais.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPais_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPais.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboVendedor_DropDown(sender As System.Object, e As System.EventArgs) Handles cboVendedor.DropDown
        cboVendedor.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select distinct Alias from Usuarios where Comisionista=1"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboVendedor.Items.Add(
                     rd1(0).ToString
                     )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboregimen_DropDown(sender As System.Object, e As System.EventArgs) Handles cboregimen.DropDown
        cboregimen.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Descripcion from RegimenFiscalSat"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboregimen.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboregimen_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboregimen.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select ClaveRegFis from RegimenFiscalSat where Descripcion='" & cboregimen.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtClaveRegFis.Text = rd1(0).ToString
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtClaveRegFis_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClaveRegFis.TextChanged
        If txtClaveRegFis.Text <> "" Then
            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select Descripcion from RegimenFiscalSat where ClaveRegFis='" & Trim(txtClaveRegFis.Text) & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        cboregimen.Text = rd2(0).ToString
                    End If
                End If
                rd2.Close() : cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn2.Close()
            End Try
        End If
    End Sub

    Private Sub cboregimen_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboregimen.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub frmClientes_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub cboTipo_DropDown(sender As System.Object, e As System.EventArgs) Handles cboTipo.DropDown
        cboTipo.Items.Clear()
        cboTipo.Items.Add("Lista")
        cboTipo.Items.Add("Mayoreo")
        cboTipo.Items.Add("Medio Mayoreo")
        cboTipo.Items.Add("Minimo")
        cboTipo.Items.Add("Especial")
    End Sub

    Private Sub txtninterior_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtninterior.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnexterior.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnexterior_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnexterior.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtColonia.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmRepClientes.Show()
    End Sub

    Private Sub btnmigra_Click(sender As Object, e As EventArgs) Handles btnmigra.Click

        btnmigra.Enabled = False
        My.Application.DoEvents()
        Dim cnn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BaseExportar\DL1.mdb;;Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
        Dim cmd1 As OleDbCommand = New OleDbCommand
        Dim rd1 As OleDbDataReader

        Dim nombre As String = ""
        Dim razonsocial As String = ""
        Dim tipo As String = ""
        Dim rfc As String = ""
        Dim telefono As String = ""
        Dim correo As String = ""
        Dim credito As Double = 0
        Dim diascred As Double = 0
        Dim comisionista As String = ""
        Dim suspender As Boolean = False
        Dim calle As String = ""
        Dim colonia As String = ""
        Dim cp As String = ""
        Dim delegacion As String = ""
        Dim entidad As String = ""
        Dim pais As String = ""
        Dim regfis As String = ""
        Dim ninterior As String = ""
        Dim nexterior As String = ""

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Clientes ORDER BY Id"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Do While rd1.Read

                    nombre = rd1("Nombre").ToString
                    razonsocial = rd1("RazonSocial").ToString
                    tipo = rd1("Tipo").ToString
                    rfc = rd1("RFC").ToString
                    telefono = rd1("Telefono1").ToString
                    correo = rd1("Email").ToString
                    credito = rd1("Credito").ToString
                    diascred = IIf(rd1("DiasCredito").ToString = "", 0, rd1("DiasCredito").ToString)
                    comisionista = rd1("Comisionista").ToString
                    suspender = rd1("SuspVent").ToString
                    calle = rd1("Calle").ToString
                    colonia = rd1("Colonia").ToString
                    cp = rd1("CP").ToString
                    delegacion = rd1("Delegacion").ToString
                    entidad = rd1("Entidad").ToString
                    pais = rd1("CPais").ToString
                    regfis = rd1("Regfis").ToString
                    ninterior = rd1("CNumberInt").ToString
                    nexterior = rd1("CNumberExt").ToString

                    If nombre = "" Then
                        nombre = razonsocial
                    End If

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO clientes(Nombre,RazonSocial,Tipo,RFC,Telefono,Correo,Credito,DiasCred,Comisionista,Suspender,Calle,Colonia,CP,Delegacion,Entidad,Pais,RegFis,NInterior,NExterior,CargadoAndroid,Cargado,SaldoFavor) VALUES('" & nombre & "','" & razonsocial & "','" & tipo & "','" & rfc & "','" & telefono & "','" & correo & "'," & credito & "," & diascred & ",'" & comisionista & "'," & suspender & ",'" & calle & "','" & colonia & "','" & cp & "','" & delegacion & "','" & entidad & "','" & pais & "','" & regfis & "','" & ninterior & "','" & nexterior & "',0,0,0)"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                Loop
            End If
            MsgBox("Clientes importados correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
            rd1.Close()
            cnn1.Close()
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        My.Application.DoEvents()
        btnmigra.Enabled = True
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

            Dim nombre, razonsocial, tipo, rfc, telefono, correo, comisionista, calle, colonia, cp, delegacion, entidad, pais, regfis, ninterior, nexterior As String
            Dim credito, diascred As Double
            Dim suspender As Integer = 0
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For dx As Integer = 0 To DataGridView1.Rows.Count - 1
                contadorconexion += 1

                nombre = NulCad(DataGridView1.Rows(dx).Cells(0).Value.ToString())
                razonsocial = NulCad(DataGridView1.Rows(dx).Cells(1).Value.ToString())
                tipo = NulCad(DataGridView1.Rows(dx).Cells(2).Value.ToString())
                rfc = NulCad(DataGridView1.Rows(dx).Cells(3).Value.ToString())
                telefono = NulCad(DataGridView1.Rows(dx).Cells(4).Value.ToString())
                correo = NulCad(DataGridView1.Rows(dx).Cells(5).Value.ToString())
                credito = NulVa(DataGridView1.Rows(dx).Cells(6).Value.ToString())
                diascred = NulVa(DataGridView1.Rows(dx).Cells(7).Value.ToString())
                comisionista = DataGridView1.Rows(dx).Cells(8).Value.ToString()
                suspender = NulVa(DataGridView1.Rows(dx).Cells(9).Value.ToString())
                calle = NulCad(DataGridView1.Rows(dx).Cells(10).Value.ToString())
                colonia = NulCad(DataGridView1.Rows(dx).Cells(11).Value.ToString())
                cp = NulCad(DataGridView1.Rows(dx).Cells(12).Value.ToString())
                delegacion = NulCad(DataGridView1.Rows(dx).Cells(13).Value.ToString())
                entidad = NulCad(DataGridView1.Rows(dx).Cells(14).Value.ToString())
                pais = NulCad(DataGridView1.Rows(dx).Cells(15).Value.ToString())
                regfis = NulCad(DataGridView1.Rows(dx).Cells(16).Value.ToString())
                ninterior = NulCad(DataGridView1.Rows(dx).Cells(17).Value.ToString())
                nexterior = NulCad(DataGridView1.Rows(dx).Cells(18).Value.ToString())

                If nombre = "" Then
                    nombre = razonsocial
                End If

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                If (Comprueba(nombre)) Then

                    If cnn1.State = 0 Then cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO clientes(Nombre,RazonSocial,Tipo,RFC,Telefono,Correo,Credito,DiasCred,Comisionista,Suspender,Calle,Colonia,CP,Delegacion,Entidad,Pais,NInterior,NExterior,CargadoAndroid,Cargado,SaldoFavor) VALUES('" & nombre & "','" & razonsocial & "','" & tipo & "','" & rfc & "','" & telefono & "','" & correo & "', " & credito & "," & diascred & ",'" & comisionista & "'," & suspender & ",'" & calle & "','" & colonia & "','" & cp & "','" & delegacion & "','" & entidad & "','" & pais & "','" & ninterior & "','" & nexterior & "',0,0,0)"
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
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " clientes fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

    End Sub

    Private Function Comprueba(ByVal nombre As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM clientes WHERE Nombre='" & nombre & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MsgBox("Ya cuentas con un cliente registrado con el nombre " & nombre & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    valida = False
                    Exit Function
                End If
            End If
            rd2.Close()
            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQL(DataGridView1)
        End If
    End Sub
End Class