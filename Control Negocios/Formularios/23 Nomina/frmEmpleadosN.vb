Public Class frmEmpleadosN

    Dim idregimen As String = ""
    Dim idperiodo As String = ""
    Dim idjornada As String = ""
    Dim idcontrato As String = ""
    Dim idriesgo As String = ""
    Dim idformapago As Integer = 0
    Dim idbanco As String = ""
    Dim idempresa As Integer = 0
    Dim idempleado As Integer = 0
    Dim claveestado As String = ""

    Private Sub cboRegimen_DropDown(sender As Object, e As EventArgs) Handles cboRegimen.DropDown
        Try
            cboRegimen.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Rct_nombre FROM regimen_contratacion_trabajador WHERE Rct_nombre<>'' ORDER BY Rct_nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboRegimen.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close() : cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboRegimen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboRegimen.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Rct_id FROM regimen_contratacion_trabajador WHERE Rct_nombre='" & cboRegimen.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidregimen.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboPeriodo_DropDown(sender As Object, e As EventArgs) Handles cboPeriodo.DropDown
        Try
            cboPeriodo.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Pp_nombre FROM periodicidad_pago WHERE Pp_nombre<>'' ORDER BY Pp_nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboPeriodo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboPeriodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPeriodo.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Pp_id FROM periodicidad_pago WHERE Pp_nombre='" & cboPeriodo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1.HasRows Then
                    lblidperiodo.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboJornada_DropDown(sender As Object, e As EventArgs) Handles cboJornada.DropDown
        Try
            cboJornada.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Tj_nombre FROM tipo_jornada WHERE Tj_nombre<>'' ORDER BY Tj_id"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboJornada.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboJornada_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboJornada.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Tj_id FROM tipo_jornada WHERE Tj_nombre='" & cboJornada.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidjornada.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboContrato_DropDown(sender As Object, e As EventArgs) Handles cboContrato.DropDown
        Try
            cboContrato.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Tc_nombre FROM tipo_contrato WHERE Tc_nombre<>'' ORDER BY Tc_id"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboContrato.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboContrato_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboContrato.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Tc_id FROM tipo_contrato WHERE Tc_nombre='" & cboContrato.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidcontrato.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDepartamento_DropDown(sender As Object, e As EventArgs) Handles cboDepartamento.DropDown
        Try
            cboDepartamento.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Departamento FROM usuarios WHERE Puesto<>'' ORDER BY Departamento"
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

    Private Sub cboPuesto_DropDown(sender As Object, e As EventArgs) Handles cboPuesto.DropDown
        Try
            cboPuesto.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Puesto FROM usuarios WHERE Puesto<>'' ORDER BY puesto"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboPuesto.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboRiesgo_DropDown(sender As Object, e As EventArgs) Handles cboRiesgo.DropDown
        Try
            cboRiesgo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Descripcion FROM riesgo_puesto WHERE Descripcion<>'' ORDER BY Rp_id"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboRiesgo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboRiesgo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboRiesgo.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Rp_id FROM riesgo_puesto WHERE Descripcion='" & cboRiesgo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidriesgo.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboTipoPago_DropDown(sender As Object, e As EventArgs) Handles cboTipoPago.DropDown
        Try
            cboTipoPago.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboTipoPago.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboTipoPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoPago.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM formaspago WHERE FormaPago='" & cboTipoPago.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idformapago = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboBancos_DropDown(sender As Object, e As EventArgs) Handles cboBancos.DropDown
        Try
            cboBancos.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Banco FROM bancos WHERE Banco<>'' ORDER BY Banco"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboBancos.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboBancos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboBancos.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cb_id FROM bancos WHERE Banco='" & cboBancos.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidbanco.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboEmpresa_DropDown(sender As Object, e As EventArgs) Handles cboEmpresa.DropDown
        Try
            cboEmpresa.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Em_RazonSocial FROM datosnegocio WHERE Em_RazonSocial<>'' ORDER BY Em_RazonSocial"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboEmpresa.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboEmpresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Emisor_id FROM datosnegocio WHERE Em_RazonSocial='" & cboEmpresa.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idempresa = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboempleado_DropDown(sender As Object, e As EventArgs) Handles cboempleado.DropDown
        Try


            cboempleado.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If idempresa = 1 Then
                cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' AND Status=1 ORDER BY Nombre"
            Else
                cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' AND Status=1 AND Emp_empresa=" & idempresa & " ORDER BY Nombre"
            End If

            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboempleado.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboempleado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboempleado.SelectedValueChanged
        Try
            Dim claveregimen As String = ""
            Dim claveestado As String = ""
            Dim claveperiodo As String = ""
            Dim clavejornada As String = ""
            Dim clavecontrato As String = ""
            Dim claveriesgo As String = ""
            Dim clavebanco As String = ""

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Rfc,Curp,NSS,NumExt,NumInt,Colonia,Calle,Delegacion,Cp,Entidad,Telefono,Correo,Ingreso,Departamento,Puesto,Sueldoxdia,FormaPago,ClaveP,CuentaP,Emp_regimen,Emp_Periodo,Emp_Jornada,Emp_Contrato,Emp_Riesgo,Banco,Estado FROM usuarios WHERE Nombre='" & cboempleado.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idempleado = rd1("IdEmpleado").ToString
                    txtRfc.Text = rd1("Rfc").ToString
                    txtcurp.Text = rd1("Curp").ToString
                    txtnss.Text = rd1("NSS").ToString
                    txtnumext.Text = rd1("NumExt").ToString
                    txtnumint.Text = rd1("NumInt").ToString
                    txtcolonia.Text = rd1("Colonia").ToString
                    txtCalle.Text = rd1("Calle").ToString
                    txtdelegacion.Text = rd1("Delegacion").ToString
                    txtcp.Text = rd1("Cp").ToString
                    txtPais.Text = rd1("Entidad").ToString
                    txtTelefono.Text = rd1("Telefono").ToString
                    txtCorreo.Text = rd1("Correo").ToString
                    dtpFingreso.Value = rd1("Ingreso").ToString
                    cboDepartamento.Text = rd1("Departamento").ToString
                    cboPuesto.Text = rd1("Puesto").ToString
                    txtSalario.Text = rd1("Sueldoxdia").ToString
                    cboTipoPago.Text = rd1("FormaPago").ToString
                    txtClave.Text = rd1("ClaveP").ToString
                    txtCuenta.Text = rd1("CuentaP").ToString
                    claveregimen = rd1("Emp_regimen").ToString
                    claveperiodo = rd1("Emp_Periodo").ToString
                    clavejornada = rd1("Emp_Jornada").ToString
                    clavecontrato = rd1("Emp_Contrato").ToString
                    claveriesgo = rd1("Emp_Riesgo").ToString
                    clavebanco = rd1("Banco").ToString
                    claveestado = rd1("Estado").ToString


                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Rct_nombre,Cat_id FROM regimen_contratacion_trabajador WHERE Cat_id='" & claveregimen & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboRegimen.Text = rd2(0).ToString
                            lblidregimen.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Pp_nombre,Pp_id FROM periodicidad_pago WHERE Pp_id='" & claveperiodo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboPeriodo.Text = rd2(0).ToString
                            lblidperiodo.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT tj_nombre,Tj_id FROM tipo_jornada WHERE Tj_id='" & clavejornada & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboJornada.Text = rd2(0).ToString
                            lblidjornada.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Tc_nombre,Tc_id FROM tipo_contrato WHERE Tc_id='" & clavecontrato & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboContrato.Text = rd2(0).ToString
                            lblidcontrato.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Descripcion,Rp_id FROM riesgo_Puesto WHERE Rp_id='" & claveriesgo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboRiesgo.Text = rd2(0).ToString
                            lblidriesgo.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Banco,Cb_id FROM bancos WHERE Cb_id='" & clavebanco & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboBancos.Text = rd2(0).ToString
                            lblidbanco.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Nombre,ClaveEdo FROM porteestados WHERE ClaveEdo='" & claveestado & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cboEstado.Text = rd2(0).ToString
                            lblidestado.Text = rd2(1).ToString
                        End If
                    End If
                    rd2.Close()

                End If
            End If
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboEstado_DropDown(sender As Object, e As EventArgs) Handles cboEstado.DropDown
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM porteestados WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboEstado.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT ClaveEdo FROM porteestados WHERE Nombre='" & cboEstado.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidestado.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If verifica() Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Nombre FROM usuarios WHERE Nombre='" & cboempleado.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE usuarios SET Departamento='" & cboDepartamento.Text & "',Emp_Regimen='" & lblidregimen.Text & "',Emp_Periodo='" & lblidperiodo.Text & "',Emp_Jornada='" & lblidjornada.Text & "',Emp_contrato='" & lblidcontrato.Text & "',Emp_Riesgo='" & lblidriesgo.Text & "',Estado='" & lblidestado.Text & "',Rfc='" & txtRfc.Text & "',Curp='" & txtcurp.Text & "',NumExt='" & txtnumext.Text & "',NumInt='" & txtnumint.Text & "',FormaPago='" & cboTipoPago.Text & "',Banco='" & lblidbanco.Text & "',ClaveP='" & txtClave.Text & "',CuentaP='" & txtCuenta.Text & "' WHERE Nombre='" & cboempleado.Text & "' AND IdEmpleado=" & idempleado & ""
                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Colaborador actualizado correctamente", vbInformation + vbOKOnly, titulonomina)
                            cnn2.Close()
                        End If


                    End If
                End If
                rd1.Close()
                cnn1.Close()
                btnLimpiar.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboEmpresa.Text = ""
        cboempleado.Text = ""
        txtRfc.Text = ""
        txtcurp.Text = ""
        txtnss.Text = ""
        txtCalle.Text = ""
        txtnumext.Text = ""
        txtnumint.Text = ""
        txtcolonia.Text = ""
        txtdelegacion.Text = ""
        txtcp.Text = ""
        cboEstado.Text = ""
        txtPais.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
        dtpFingreso.Value = Date.Now
        dtpFNacimiento.Value = Date.Now
        cboRegimen.Text = ""
        cboPeriodo.Text = ""
        cboJornada.Text = ""
        cboContrato.Text = ""
        cboRiesgo.Text = ""
        cboDepartamento.Text = ""
        cboPuesto.Text = ""
        cboTipoPago.Text = ""
        txtClave.Text = ""
        txtCuenta.Text = ""
        txtSalario.Text = ""
        cboBancos.Text = ""

        lblidestado.Text = ""
        lblidregimen.Text = ""
        lblidperiodo.Text = ""
        lblidjornada.Text = ""
        lblidcontrato.Text = ""
        lblidriesgo.Text = ""
        lblidbanco.Text = ""
    End Sub

    Private Sub frmEmpleadosN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmMenuNomina.Show()
    End Sub

    Private Sub btnRfc_Click(sender As Object, e As EventArgs) Handles btnRfc.Click
        System.Diagnostics.Process.Start("chrome.exe", "http://consultas.curp.gob.mx/CurpSP/")
    End Sub

    Private Function verifica()

        If txtRfc.Text = "" Then
            MsgBox("El RFC es Invalido, Verifique.", MsgBoxStyle.Information, titulonomina)
            txtRfc.Focus.Equals(True)
            Return False
        End If

        If txtcurp.Text = "" Then
            MsgBox("El CURP es Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            txtcurp.Focus.Equals(True)
            Return False
        End If

        If txtCalle.Text = "" Then
            MsgBox("El Calle es Requerida, Verifique.", MsgBoxStyle.Information, titulonomina)
            txtCalle.Focus.Equals(True)
            Return False
        End If

        If txtnumext.Text = "" Then
            MsgBox("El Numero es Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            txtnumext.Focus.Equals(True)
            Return False
        End If

        If txtcolonia.Text = "" Then
            MsgBox("El Colonia es Requerida, Verifique.", MsgBoxStyle.Information, titulonomina)
            txtcolonia.Focus.Equals(True)
            Return False
        End If

        If txtdelegacion.Text = "" Then
            MsgBox("El Delegacion es Requerida, Verifique.", MsgBoxStyle.Information, titulonomina)
            txtdelegacion.Focus.Equals(True)
            Return False
        End If

        If txtcp.Text = "" Then
            MsgBox("El CP es Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            txtcp.Focus.Equals(True)
            Return False
        End If

        If txtTelefono.Text = "" Then
            MsgBox("Debe registrar por lo menos 1 Telefono.", MsgBoxStyle.Information, titulonomina)
            txtTelefono.Focus.Equals(True)
            Return False
        End If

        If txtSalario.Text = "" Then
            MsgBox("Debe registrar El importe del Salario.", MsgBoxStyle.Information, titulonomina)
            txtSalario.Focus.Equals(True)
            Return False
        End If

        If cboRegimen.Text = "" Then
            MsgBox("Regimen Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            cboRegimen.Focus.Equals(True)
            Return False
        End If

        If cboPeriodo.Text = "" Then
            MsgBox("Periodo Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            cboPeriodo.Focus.Equals(True)
            Return False
        End If

        If cboDepartamento.Text = "" Then
            MsgBox("Departamento Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            cboDepartamento.Focus.Equals(True)
            Return False
        End If

        If cboPuesto.Text = "" Then
            MsgBox("Puesto Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            cboPuesto.Focus.Equals(True)
            Return False
        End If

        If cboTipoPago.Text = "" Then
            MsgBox("Tipo de Pago Requerido, Verifique.", MsgBoxStyle.Information, titulonomina)
            cboTipoPago.Focus.Equals(True)
            Return False
        End If

        If dtpFingreso.Value > Date.Now Then
            MsgBox("Fecha de Ingreso Invalida, Verifique.", MsgBoxStyle.Information, titulonomina)
            Return False
        End If

        If cboEstado.Text = "" Then
            MsgBox("Debe seleccionar un Estado", vbInformation + vbOKOnly, titulonomina)
            cboEstado.Focus.Equals(True)
            Return False
        End If

        Return True

    End Function

    Private Sub cboEmpresa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboEmpresa.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboempleado.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboempleado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboempleado.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtRfc.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtRfc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRfc.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcurp.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcurp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcurp.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnss.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtnss_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnss.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCalle.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalle.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumext.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtnumext_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumext.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumint.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtnumint_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumint.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcolonia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcolonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcolonia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdelegacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtdelegacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdelegacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcp.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcp.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboEstado.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboEstado.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPais.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPais.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCorreo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpFingreso.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpFingreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFingreso.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpFNacimiento.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpFNacimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFNacimiento.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboRegimen.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboRegimen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboRegimen.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboPeriodo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboPeriodo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPeriodo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboJornada.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboJornada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboJornada.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboContrato.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboContrato_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboContrato.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboRiesgo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboRiesgo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboRiesgo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboDepartamento.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDepartamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDepartamento.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboPuesto.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboPuesto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPuesto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTipoPago.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTipoPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoPago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtClave.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCuenta.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSalario.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtSalario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSalario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboBancos.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboBancos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBancos.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAgregar.Focus.Equals(True)
        End If
    End Sub
End Class