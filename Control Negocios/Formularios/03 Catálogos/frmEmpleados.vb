Imports System.IO
Imports System.Net

Public Class frmEmpleados

    Private Sub Info_Click(sender As System.Object, e As System.EventArgs) Handles Info.Click
        If Info.Text = "> Más información" Then
            Info.Text = "v Menos información"
            Me.Size = New Size(456, 570)
            Me.StartPosition = FormStartPosition.CenterScreen
        Else
            Info.Text = "> Más información"
            Me.Size = New Size(456, 319)
        End If
    End Sub

    Private Sub frmEmpleados_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub frmEmpleados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtId.Text = ""
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Usuarios where Nombre<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboNombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtId.Text = rd1("IdEmpleado").ToString
                        dtpIngreso.Value = rd1("Ingreso").ToString
                        cboArea.Text = rd1("Area").ToString
                        txtPuesto.Text = rd1("Puesto").ToString
                        txtAlias.Text = rd1("Alias").ToString
                        txtSueldo.Text = FormatNumber(rd1("Sueldo").ToString, 2)
                        txthoras.Text = rd1("Horas").ToString()
                        txtSeguro.Text = rd1("NSS").ToString
                        chkComi.Checked = IIf(rd1("Comisionista").ToString = False, False, True)
                        txtCalle.Text = rd1("Calle").ToString
                        txtColonia.Text = rd1("Colonia").ToString
                        txtCP.Text = rd1("CP").ToString
                        txtDelegacion.Text = rd1("Delegacion").ToString
                        txtEntidad.Text = rd1("Entidad").ToString
                        txtWhats.Text = rd1("Telefono").ToString
                        txtCorreo.Text = rd1("Correo").ToString
                        txtFace.Text = rd1("Facebook").ToString
                    End If
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            txtSueldo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Usuarios where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtId.Text = rd1("IdEmpleado").ToString
                    dtpIngreso.Value = rd1("Ingreso").ToString
                    cboArea.Text = rd1("Area").ToString
                    txtPuesto.Text = rd1("Puesto").ToString
                    txtAlias.Text = rd1("Alias").ToString
                    txtSueldo.Text = FormatNumber(rd1("Sueldo").ToString, 2)
                    txthoras.Text = rd1("Horas").ToString()
                    txtSeguro.Text = rd1("NSS").ToString
                    chkComi.Checked = IIf(rd1("Comisionista").ToString = False, False, True)
                    txtCalle.Text = rd1("Calle").ToString
                    txtColonia.Text = rd1("Colonia").ToString
                    txtCP.Text = rd1("CP").ToString
                    txtDelegacion.Text = rd1("Delegacion").ToString
                    txtEntidad.Text = rd1("Entidad").ToString
                    txtWhats.Text = rd1("Telefono").ToString
                    txtCorreo.Text = rd1("Correo").ToString
                    txtFace.Text = rd1("Facebook").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub dtpIngreso_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpIngreso.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboArea.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboArea_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboArea.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPuesto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtSueldo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSueldo.Text = FormatNumber(txtSueldo.Text, 2)
            txthoras.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPuesto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPuesto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtAlias.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtSeguro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeguro.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpIngreso.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtAlias_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlias.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtId.Text = "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select * from  Usuarios where Alias='" & txtAlias.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cboNombre.Text = rd1("Nombre").ToString
                            dtpIngreso.Value = rd1("Ingreso").ToString
                            cboArea.Text = rd1("Area").ToString
                            txtSueldo.Text = FormatNumber(rd1("Sueldo").ToString, 2)
                            txthoras.Text = rd1("Horas").ToString()
                            txtPuesto.Text = rd1("Puesto").ToString
                            txtSeguro.Text = rd1("NSS").ToString
                            chkComi.Checked = IIf(rd1("Comisionista").ToString = False, False, True)
                            txtId.Text = rd1("IdEmpleado").ToString
                            txtCalle.Text = rd1("Calle").ToString
                            txtColonia.Text = rd1("Colonia").ToString
                            txtCP.Text = rd1("CP").ToString
                            txtDelegacion.Text = rd1("Delegacion").ToString
                            txtEntidad.Text = rd1("Entidad").ToString
                            txtWhats.Text = rd1("Telefono").ToString
                            txtFace.Text = rd1("Facebook").ToString
                            txtCorreo.Text = rd1("Correo").ToString
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            btnGuardar.Focus.Equals(True)
            End If
    End Sub

    Private Sub txtCalle_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtColonia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtColonia_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtColonia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCP.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCP_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP.KeyPress
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
            txtWhats.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtWhats_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWhats.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtFace.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtFace_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFace.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorreo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        cboNombre.Text = ""
        cboNombre.Items.Clear()
        dtpIngreso.Value = Date.Now
        cboArea.Text = ""
        txtPuesto.Text = ""
        txtSueldo.Text = "0.00"
        txthoras.Text = "0"
        txtsueldo_hora.Text = "0.00"
        txtSeguro.Text = ""
        txtAlias.Text = ""
        chkComi.Checked = False
        txtId.Text = ""
        txtCalle.Text = ""
        txtColonia.Text = ""
        txtCP.Text = ""
        txtDelegacion.Text = ""
        txtEntidad.Text = ""
        txtWhats.Text = ""
        txtFace.Text = ""
        txtCorreo.Text = ""
        picFotica.Image = Nothing
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cboNombre.Text = "" Then MsgBox("Necesitas escribir el nombre del usuario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If txtAlias.Text = "" Then MsgBox("Necesitas asignarle un alias del usuario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtAlias.Focus().Equals(True) : Exit Sub
        If cboArea.Text = "" Then MsgBox("Necesitas seleccionar el área del usuario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboArea.Focus().Equals(True) : Exit Sub
        If txtPuesto.Text = "" Then MsgBox("Necesitas escribir el puesto del usuario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtPuesto.Focus().Equals(True) : Exit Sub

        If txtCorreo.Text <> "" Then
            If InStr(1, txtCorreo.Text, "@") = 0 Then
                MsgBox("El correo electrónico es inválido.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                txtCorreo.SelectionStart = 0
                txtCorreo.SelectionLength = Len(txtCorreo.Text)
                Exit Sub
            End If
        End If

        Dim existe As Boolean = False
        Dim sql As String = ""
        Dim carpeta As String = ""
        Dim sueldo As Double = txtSueldo.Text

        If txtId.Text = "" Then
            existe = False
        Else
            existe = True
        End If

        Try
            If existe Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where IdEmpleado=" & txtId.Text
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sql = "update Usuarios set Area='" & cboArea.Text & "', Puesto='" & txtPuesto.Text & "', Sueldo=" & sueldo & ", NSS='" & txtSeguro.Text & "',Ingreso='" & Format(dtpIngreso.Value, "yyyy-MM-dd") & "', Alias='" & txtAlias.Text & "', Comisionista=" & IIf(chkComi.Checked = False, 0, 1) & ", Calle='" & txtCalle.Text & "', Colonia='" & txtColonia.Text & "', CP='" & txtCP.Text & "', Delegacion='" & txtDelegacion.Text & "', Entidad='" & txtEntidad.Text & "', Telefono='" & txtWhats.Text & "', Facebook='" & txtFace.Text & "', Correo='" & txtCorreo.Text & "', Cargado=0, Horas=" & txthoras.Text & ",Sueldoxdia=" & txtsueldo_hora.Text & " where IdEmpleado=" & txtId.Text
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = sql
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos de usuario actualizados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If

                cnn1.Close()
            Else
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    MsgBox("Parece que ya hay un usuario registrado bajo ese nombre.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    cboNombre.Focus.Equals(True)
                    Exit Sub
                Else
                    sql = "insert into Usuarios(Nombre,Alias,Area,Puesto,NSS,Clave,Ingreso,Sueldo,Comisionista,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Status,Cargado,Template,Horas,Sueldoxdia) values('" & cboNombre.Text & "','" & txtAlias.Text & "','" & cboArea.Text & "','" & txtPuesto.Text & "','" & txtSeguro.Text & "','','" & Format(dtpIngreso.Value, "yyyy-MM-dd") & "'," & sueldo & "," & IIf(chkComi.Checked = False, 0, 1) & ",'" & txtCalle.Text & "','" & txtColonia.Text & "','" & txtCP.Text & "','" & txtDelegacion.Text & "','" & txtEntidad.Text & "','" & txtWhats.Text & "','" & txtFace.Text & "','" & txtCorreo.Text & "',1,0,0," & txthoras.Text & "," & txtsueldo_hora.Text & ")"
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = sql
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos de usuario registrados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    If MsgBox("¿Deseas configurar sus permisos?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                        'Manda los datos del usuario al formulario de permisos para configurar sus permisos
                        frmPermisos.Show()
                        frmPermisos.cboNombre.Text = cboNombre.Text
                        frmPermisos.txtarea.Text = cboArea.Text
                        frmPermisos.txtpuesto.Text = txtPuesto.Text
                        frmPermisos.txtingreso.Text = FormatDateTime(dtpIngreso.Value, DateFormat.ShortDate)
                        frmPermisos.cboNombre_SelectedValueChanged(frmPermisos, New EventArgs())

                        cnn1.Close()
                    End If
                End If
                cnn1.Close()

                If picFotica.Image Is Nothing Then
                Else
                    picFotica.Image.Save(carpeta, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            End If

            btnNuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            picFotica.Dispose()
        End Try
    End Sub

    Private Sub picFotica_DoubleClick(sender As System.Object, e As System.EventArgs) Handles picFotica.DoubleClick
        Dim fila As String = String.Empty

        Using file = New OpenFileDialog
            file.RestoreDirectory = True
            file.Title = "Selecciona la imagen del empleado"
            file.Filter = "Archivos de imagen (*.jpg;*.png) |*.jpg;*png"
            If file.ShowDialog = Windows.Forms.DialogResult.OK Then
                fila = file.FileName
            End If
        End Using
        My.Application.DoEvents()
        picFotica.Image = Image.FromFile(fila)
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If txtId.Text = "" Then
            MsgBox("Selecciona un usuario para eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            cboNombre.Focus.Equals(True)
            Exit Sub
        End If

        If MsgBox("¿Deseas eliminar los datos de éste usuario?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from Usuarios where IdEmpleado=" & txtId.Text
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from Permisos where IdEmpleado=" & txtId.Text
            If cmd1.ExecuteNonQuery Then
                MsgBox("Datos de usuario eliminados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                btnNuevo.PerformClick()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        btnNuevo.PerformClick()
    End Sub

    Private Sub frmEmpleados_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub btnhuella_Click(sender As System.Object, e As System.EventArgs) Handles btnhuella.Click
        If txtId.Text = "" Then MsgBox("Selecciona un usuario para registrar su huella.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If txtAlias.Text = "" Then MsgBox("No se puede continuar debido a un error inesperado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If MsgBox("¿Deseas capturar la huella del usuario " & txtAlias.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            With frmHuella
                .txtusuario.Text = cboNombre.Text
                .txtId.Text = txtId.Text
                .Show(Me)
            End With
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txthoras_Click(sender As Object, e As EventArgs) Handles txthoras.Click
        txthoras.SelectionStart = 0
        txthoras.SelectionLength = Len(txthoras.Text)
    End Sub

    Private Sub txthoras_GotFocus(sender As Object, e As EventArgs) Handles txthoras.GotFocus
        txthoras.SelectionStart = 0
        txthoras.SelectionLength = Len(txthoras.Text)
    End Sub

    Private Sub txthoras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txthoras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtSueldo.Text <> "" And CDbl(txtSueldo.Text) > 0 And txthoras.Text <> "" And CDbl(txthoras.Text) > 0 Then
                txtsueldo_hora.Text = CDbl(txtSueldo.Text) / CDbl(txthoras.Text)
                txtsueldo_hora.Text = FormatNumber(txtsueldo_hora.Text, 2)
            End If
            txtSeguro.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtSueldo_TextChanged(sender As Object, e As EventArgs) Handles txtSueldo.TextChanged
        If txtSueldo.Text = "" Then Exit Sub
        If txthoras.Text = "" Then Exit Sub
        If txtSueldo.Text <> "" And CDbl(txtSueldo.Text) > 0 And txthoras.Text <> "" And CDbl(txthoras.Text) > 0 Then
            txtsueldo_hora.Text = CDbl(txtSueldo.Text) / CDbl(txthoras.Text)
            txtsueldo_hora.Text = FormatNumber(txtsueldo_hora.Text, 2)
        End If
    End Sub

    Private Sub txthoras_TextChanged(sender As Object, e As EventArgs) Handles txthoras.TextChanged
        If txtSueldo.Text = "" Then Exit Sub
        If txthoras.Text = "" Then Exit Sub
        If txtSueldo.Text <> "" And CDbl(txtSueldo.Text) > 0 And txthoras.Text <> "" And CDbl(txthoras.Text) > 0 Then
            txtsueldo_hora.Text = CDbl(txtSueldo.Text) / CDbl(txthoras.Text)
            txtsueldo_hora.Text = FormatNumber(txtsueldo_hora.Text, 2)
        End If
    End Sub
End Class