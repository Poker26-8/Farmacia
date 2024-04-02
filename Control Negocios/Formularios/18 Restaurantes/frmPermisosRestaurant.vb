Public Class frmPermisosRestaurant
    Private Sub frmPermisosRestaurant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim TIPOCOBRO As String = ""

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Comensal FROM Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    If rd2(0).ToString = "1" Then
                        cbSeparadas.Checked = True
                    Else
                        cbSeparadas.Checked = False
                    End If

                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Propina'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtPorcentage.Text = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='ToleBillar'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txttolerancia.Text = rd2(0).ToString
                End If
            End If
            rd2.Close()

            Dim propias As Integer = 0

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='MesasPropias'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    propias = rd2(0).ToString

                    If propias = 1 Then
                        cbMesasPropias.Checked = True
                    Else
                        cbMesasPropias.Checked = False
                    End If

                End If
            End If
            rd2.Close()

            Dim cuartos As Integer = 0

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Cuartos'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cuartos = rd2(0).ToString

                    If cuartos = 1 Then
                        chkCuartos.Checked = True
                    Else
                        chkCuartos.Checked = False
                    End If

                End If
            End If
            rd2.Close()


            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Copa'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2(0).ToString = 1 Then
                        cbCopas.Checked = True
                    Else
                        cbCopas.Checked = False
                    End If
                End If
            End If
            rd2.Close()


            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TipoCobroBillar'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    TIPOCOBRO = rd2(0).ToString
                End If
            End If
            rd2.Close()

            If TIPOCOBRO = "HORA" Then
                rbhora.Checked = True
            ElseIf TIPOCOBRO = "MINUTO" Then
                rbminuto.Checked = True
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='SinNumCoemensal'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2(0).ToString = 1 Then
                        chkSinComensal.Checked = True
                    Else
                        chkSinComensal.Checked = False
                    End If
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Mapeo'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2(0).ToString = 1 Then
                        rbM.Checked = True
                    Else
                        rbNM.Checked = True
                    End If
                End If
            End If
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        Try
            cboNombre.Items.Clear()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Nombre FROM Usuarios WHERE Nombre<>'' ORDER BY Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboNombre.Items.Add(rd1(0).ToString)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Area,Clave FROM Usuarios WHERE Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblid_usu.Text = rd1(0).ToString
                    txtarea.Text = rd1(1).ToString
                    txtcontra.Text = rd1(2).ToString
                End If
            End If
            rd1.Close()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM PermisosM WHERE IdEmpleado=" & lblid_usu.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    If rd1("Precuenta").ToString = True Then cbPrecuentas.Checked = True Else cbPrecuentas.Checked = False
                    If rd1("CambioM").ToString = True Then cbCambioM.Checked = True Else cbCambioM.Checked = False
                    If rd1("CancelarM").ToString = True Then cbCancelarComanda.Checked = True Else cbCancelarComanda.Checked = False
                    If rd1("CortesiaM").ToString = True Then cbCortesia.Checked = True Else cbCortesia.Checked = False
                    If rd1("JuntarM").ToString = True Then cbJuntar.Checked = True Else cbJuntar.Checked = False
                    If rd1("CobrarM").ToString = True Then cbCobrar.Checked = True Else cbCobrar.Checked = False
                    If rd1("Mesas").ToString = True Then cbmesas.Checked = True Else cbmesas.Checked = False
                End If
            Else
                cbPrecuentas.Checked = False
                cbCambioM.Checked = False
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub Label12_MouseHover(sender As Object, e As EventArgs) Handles Label12.MouseHover
        txtcontra.PasswordChar = ""
    End Sub

    Private Sub Label12_MouseLeave(sender As Object, e As EventArgs) Handles Label12.MouseLeave
        txtcontra.PasswordChar = "*"
    End Sub

    Private Sub txtcontraseña_Click(sender As Object, e As EventArgs) Handles txtcontraseña.Click
        txtcontraseña.SelectionStart = 0
        txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
    End Sub

    Private Sub txtcontraseña_GotFocus(sender As Object, e As EventArgs) Handles txtcontraseña.GotFocus
        txtcontraseña.SelectionStart = 0
        txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcontraseña.Text <> "" Then

                Dim id_empleado As Integer = 0
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM Usuarios WHERE Clave='" & txtcontraseña.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If rd1("Area").ToString = "ADMINISTRACIÓN" Or rd1("Area").ToString = "OPERACIÓN" Then
                                id_empleado = rd1("IdEmpleado").ToString
                                lblusuario.Text = rd1("Alias").ToString
                            Else
                                MsgBox("Solo los administradores pueden modificar los permisos", vbInformation + vbOKOnly, titulorestaurante)
                                txtcontra.Text = ""
                                txtcontra.Focus.Equals(True)
                                Exit Sub
                            End If

                        End If
                        End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Restaurante'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                            If rd1(0).ToString = 1 Then
                                btnguardar.Focus.Equals(True)
                            Else
                                MsgBox("No cuentas con permisos suficientes para interactuar con este formulario.", vbInformation + vbOKOnly, titulomensajes)
                                rd1.Close() : cnn1.Close() : Exit Sub
                            End If

                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

            End If
            btnguardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        cboNombre.Text = ""
        txtarea.Text = ""
        txtcontra.Text = ""
        lblusuario.Text = ""
        cbCambioM.Checked = False
        cbPrecuentas.Checked = False
        cbCancelarComanda.Checked = False
        cbCortesia.Checked = False
        cbJuntar.Checked = False
        cbCobrar.Checked = False
        cbmesas.Checked = False
        cbSeparadas.Checked = False
        chkSinComensal.Checked = False
        cbCopas.Checked = False
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        If cboNombre.Text = "" Then MsgBox("Selecciona un usuario para poder asignarle permisos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If txtcontra.Text = "" Then MsgBox("Asígnale una contraseña al usuario para continuar.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : txtcontra.Focus().Equals(True) : Exit Sub

        If lblusuario.Text = "" Then MsgBox("Debe ingresar una contraseña para continuar.", vbInformation + vbOKOnly, titulomensajes) : lblusuario.Focus.Equals(True) : Exit Sub

        If MsgBox("¿Deseas registrar los permisos de este empleado?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim id_emp As Double = 0

            Try
                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT * FROM Usuarios WHERE Clave='" & txtcontra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("IdEmpleado").ToString = lblid_usu.Text Then
                        Else
                            MsgBox("Ya cuentas con un usuario registrado bajo esa contraseña.", vbInformation + vbOKOnly, titulomensajes)
                            rd1.Close() : cnn1.Close()
                            txtcontra.SelectAll()
                            Exit Sub
                        End If
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT * FROM Usuarios WHERE Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_emp = rd1("IdEmpleado").ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from PermisosM where IdEmpleado=" & id_emp
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE PermisosM set Precuenta=" & IIf(cbPrecuentas.Checked = True, 1, 0) & ",CambioM=" & IIf(cbCambioM.Checked = True, 1, 0) & ",CancelarM=" & IIf(cbCancelarComanda.Checked = True, 1, 0) & ",CortesiaM=" & IIf(cbCortesia.Checked = True, 1, 0) & ",JuntarM=" & IIf(cbJuntar.Checked = True, 1, 0) & ",CobrarM=" & IIf(cbCobrar.Checked = True, 1, 0) & ",Mesas=" & IIf(cbmesas.Checked = True, 1, 0) & " WHERE IdEmpleado=" & id_emp

                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Permisos actualizados correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                        End If

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Usuarios set Clave='" & txtcontra.Text & "' where IdEmpleado=" & lblid_usu.Text
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                    End If
                Else

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO PermisosM(IdEmpleado,Precuenta,CambioM,CancelarM,CortesiaM,JuntarM,CobrarM,Mesas) VALUES(" & id_emp & "," & IIf(cbPrecuentas.Checked = True, 1, 0) & "," & IIf(cbCambioM.Checked = True, 1, 0) & "," & IIf(cbCancelarComanda.Checked = True, 1, 0) & "," & IIf(cbCortesia.Checked = True, 1, 0) & "," & IIf(cbJuntar.Checked = True, 1, 0) & "," & IIf(cbCobrar.Checked = True, 1, 0) & "," & IIf(cbmesas.Checked = True, 1, 0) & ")"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Permisos insertados correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                    End If

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "update Usuarios set Clave='" & txtcontra.Text & "' where IdEmpleado=" & lblid_usu.Text
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                btnnuevo.PerformClick()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbSeparadas_CheckedChanged(sender As Object, e As EventArgs) Handles cbSeparadas.CheckedChanged

        Dim valor As Integer = 0

        If (cbSeparadas.Checked) Then
            valor = 1
        Else
            valor = 0
        End If

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "UPDATE Ticket SET Comensal=" & valor & ""
        cmd1.ExecuteNonQuery()
        cnn1.Close()

    End Sub

    Private Sub btnporcentage_Click(sender As Object, e As EventArgs) Handles btnporcentage.Click
        If txtPorcentage.Text = "" Then Exit Sub

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "select Facturas,NotasCred,NumPart from Formatos where Facturas='Propina'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "update Formatos set NotasCred='" & txtPorcentage.Text & "' where Facturas='Propina'"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Datos actualizados correctamente", vbInformation + vbOKOnly, titulomensajes)
                End If
            End If
        Else
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "insert into Formatos(Facturas,NotasCred,NumPart) values('Propina','" & txtPorcentage.Text & "',0)"
            If cmd2.ExecuteNonQuery() Then
                MsgBox("Datos guardados correctamente", vbInformation + vbOKOnly, titulomensajes)
            End If

        End If
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub btnguardartolerancia_Click(sender As Object, e As EventArgs) Handles btnguardartolerancia.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Facturas FROM Formatos WHERE Facturas='ToleBillar'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Formatos SET NotasCred='" & txttolerancia.Text & "' WHERE Facturas='ToleBillar'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Formatos(Facturas,NotasCred,NumPart)VALUES('ToleBillar','" & txttolerancia.Text & "','0')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
            MsgBox("Tolerancia agregada corectamente", vbInformation + vbOKOnly, titulorestaurante)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub CambioTipoBillar()

        Try

            If (rbhora.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Facturas FROM Formatos WHERE Facturas='TipoCobroBillar'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Formatos SET NotasCred='HORA' WHERE Facturas='TipoCobroBillar'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Insert INTO Formatos(Facturas,NotasCred,NumPart) VALUES('TipoCobroBillar','HORA','0')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

            ElseIf (rbminuto.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Facturas FROM Formatos WHERE Facturas='TipoCobroBillar'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Formatos SET NotasCred='MINUTO' WHERE Facturas='TipoCobroBillar'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Insert INTO Formatos(Facturas,NotasCred,NumPart) VALUES('TipoCobroBillar','MINUTOS','0')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub rbhora_Click(sender As Object, e As EventArgs) Handles rbhora.Click
        CambioTipoBillar()
    End Sub

    Private Sub rbminuto_Click(sender As Object, e As EventArgs) Handles rbminuto.Click
        CambioTipoBillar()
    End Sub

    Private Sub chkSinComensal_CheckedChanged(sender As Object, e As EventArgs) Handles chkSinComensal.CheckedChanged
        Try
            Dim sincomensal As Integer = 0

            If (chkSinComensal.Checked) Then
                sincomensal = 1
            Else
                sincomensal = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Facturas FROM Formatos WHERE Facturas='SinNumCoemensal'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Formatos SET NotasCred='" & sincomensal & "' WHERE Facturas='SinNumCoemensal'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Formatos(Facturas,NotasCred,NumPart) VALUES('SinNumCoemensal','" & sincomensal & "','0')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboImpre_Comanda_DropDown(sender As Object, e As EventArgs) Handles cboImpre_Comanda.DropDown
        cboImpre_Comanda.Items.Clear()
        For Each printer As String In Drawing.Printing.PrinterSettings.InstalledPrinters
            cboImpre_Comanda.Items.Add(printer)
        Next
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM rutasimpresion WHERE Tipo='UNICO'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE rutasimpresion SET Equipo='" & ObtenerNombreEquipo() & "', Impresora='" & cboImpre_Comanda.Text & "' WHERE Tipo='UNICO'"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Impresora actualizada correctamente", vbInformation + vbOKOnly, titulomensajes)
                    End If
                    cnn2.Close()

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO rutasimpresion(Equipo,Tipo,Formato,Impresora)VALUES('" & ObtenerNombreEquipo() & "','UNICO','','" & cboImpre_Comanda.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Impresora agregada correctaente", vbInformation + vbOKOnly, titulomensajes)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcontraseña.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub cbMesasPropias_CheckedChanged(sender As Object, e As EventArgs) Handles cbMesasPropias.CheckedChanged
        Try
            If (cbMesasPropias.Checked) Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Formatos SET NotasCred='1',NumPart='0' WHERE Facturas='MesasPropias'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Formatos SET NotasCred='0',NumPart='0' WHERE Facturas='MesasPropias'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cbCopas_CheckedChanged(sender As Object, e As EventArgs) Handles cbCopas.CheckedChanged
        Try
            If (cbCopas.Checked) Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Formatos SET NotasCred='1',NumPart='0' WHERE Facturas='Copa'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Formatos SET NotasCred='0',NumPart='0' WHERE Facturas='Copa'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CambiodeMesa()
        Try
            If (rbM.Checked) Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Facturas FROM formatos WHERE Facturas='Mapeo'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE formatos SET Facturas='Mapeo',NotasCred='1',NumPart=0 WHERE Facturas='Mapeo'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO formatos(Facturas,NotasCred,NumPart) VALUES('Mapeo','1',0)"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

            End If

            If (rbNM.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Facturas FROM formatos WHERE Facturas='Mapeo'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE formatos SET Facturas='Mapeo',NotasCred='0',NumPart=0 WHERE Facturas='Mapeo'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO formatos(Facturas,NotasCred,NumPart) VALUES('Mapeo','0',0)"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub rbM_Click(sender As Object, e As EventArgs) Handles rbM.Click
        CambiodeMesa()
    End Sub

    Private Sub rbNM_Click(sender As Object, e As EventArgs) Handles rbNM.Click
        CambiodeMesa()
    End Sub

    Private Sub chkCuartos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuartos.CheckedChanged
        Try
            If (chkCuartos.Checked) Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Formatos SET NotasCred='1',NumPart='0' WHERE Facturas='Cuartos'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Formatos SET NotasCred='0',NumPart='0' WHERE Facturas='Cuartos'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class