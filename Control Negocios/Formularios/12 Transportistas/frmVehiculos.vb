Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

Public Class frmVehiculos

    Protected id_transporte As Integer = 0

    Private Sub frmVehiculos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpaceite_ant.Value = Date.Now
        dtpafinacion_ant.Value = Date.Now
        dtpaceite_prox.Value = Date.Now
        dtpafinacion_prox.Value = Date.Now
        dtpvencimiento.Value = Date.Now
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        cbomodelo.Text = ""
        cbomarca.Text = ""
        txtplacas.Text = ""
        cboarea.Text = ""
        txtChofer.Text = ""
        txtseguros.Text = ""
        txtpoliza.Text = ""
        dtpvencimiento.Value = Date.Now
        txttelefono.Text = ""
        txtagente.Text = ""
        txtcontacto.Text = ""
        dtpafinacion_ant.Value = Date.Now
        dtpaceite_ant.Value = Date.Now
        dtpafinacion_prox.Value = Date.Now
        dtpaceite_prox.Value = Date.Now
        cbovencimiento2.Text = ""
        cbovencimiento1.Text = ""
        cbonocircula.Text = ""
        grdServicio.Rows.Clear()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If MsgBox("¿Desea Guardar los datos del vehículo?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then
                Exit Sub
            End If

            If cbomodelo.Text = "" Then MsgBox("Ingrese la Submarca del Vehículo!!!", vbInformation + vbOKOnly, titulocentral) : cbomodelo.Focus() : Exit Sub
            If cbomarca.Text = "" Then MsgBox("Ingrese la marca del Vehículo!!!", vbInformation + vbOKOnly, titulocentral) : cbomarca.Focus() : Exit Sub
            If txtplacas.Text = "" Then MsgBox("Ingrese las placas del Vehículo!!!", vbInformation + vbOKOnly, titulocentral) : txtplacas.Focus() : Exit Sub
            If cboarea.Text = "" Then MsgBox("Seleccione el área!!!", vbInformation + vbOKOnly, titulocentral) : cboarea.Focus() : Exit Sub
            If txtChofer.Text = "" Then MsgBox("Seleccione un chofer!!!", vbInformation + vbOKOnly, titulocentral) : txtChofer.Focus() : Exit Sub

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM Transporte WHERE Placas='" & txtplacas.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE transporte SET Modelo='" & cbomodelo.Text & "',Marca='" & cbomarca.Text & "',Area='" & cboarea.Text & "',Poliza='" & txtpoliza.Text & "',Seguro='" & txtseguros.Text & "',Vence_Seguro='" & Format(dtpvencimiento.Value, "yyyy-MM-dd") & "',Contacto_Seguro='" & txttelefono.Text & "',Agente='" & txtagente.Text & "',Contacto_Agente='" & txtcontacto.Text & "',Verifica1='" & cbovencimiento1.Text & "',Verifica2='" & cbovencimiento2.Text & "',NoCircula='" & cbonocircula.Text & "',Afina_Ant='" & Format(dtpafinacion_ant.Value, "yyyy-MM-dd") & "',Aceite_Ant='" & Format(dtpaceite_ant.Value, "yyyy-MM-dd") & "',Afina_Prox='" & Format(dtpafinacion_prox.Value, "yyyy-MM-dd") & "',Aceite_Prox='" & Format(dtpaceite_prox.Value, "yyyy-MM-dd") & "',Chofer='" & txtChofer.Text & "' WHERE Placas='" & txtplacas.Text & "'"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Transporte actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()

                End If
            Else
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Transporte(Modelo,Marca,Placas,Area,Chofer,Poliza,Seguro,Vence_Seguro,Contacto_Seguro,Agente,Contacto_Agente,Verifica1,Verifica2,NoCircula,Afina_Ant,Aceite_Ant,Afina_Prox,Aceite_Prox) VALUES('" & cbomodelo.Text & "','" & cbomarca.Text & "','" & txtplacas.Text & "','" & cboarea.Text & "','" & txtChofer.Text & "','" & txtpoliza.Text & "','" & txtseguros.Text & "','" & Format(dtpvencimiento.Value, "yyyy-MM-dd") & "','" & txttelefono.Text & "','" & txtagente.Text & "','" & txtcontacto.Text & "','" & cbovencimiento1.Text & "','" & cbovencimiento2.Text & "','" & cbonocircula.Text & "','" & Format(dtpafinacion_ant.Value, "yyyyy-MM-dd") & "','" & Format(dtpaceite_ant.Value, "yyyy-MM-dd") & "','" & Format(dtpafinacion_prox.Value, "yyyy-MM-dd") & "','" & Format(dtpaceite_prox.Value, "yyyy-MM-dd") & "')"
                If cmd2.ExecuteNonQuery Then
                    MsgBox("Transporte agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                End If


                For LUFFY As Integer = 0 To grdServicio.Rows.Count - 1
                    Dim s As String = grdServicio.Rows(LUFFY).Cells(0).Value.ToString
                    Dim f As Date = grdServicio.Rows(LUFFY).Cells(1).Value.ToString

                    cmd2.CommandText = "insert into Servicios(Nombre,Placa,Fecha) values('" & s & "','" & txtplacas.Text & "','" & Format(f, "yyyy-MM-dd") & "')"
                    cmd2.ExecuteNonQuery()
                Next
                cnn2.Close()

            End If


            cnn2.Close()
            rd1.Close()
            cnn1.Close()

            btnNuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbomodelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbomodelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbomarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbomarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbomarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtplacas.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtplacas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtplacas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            grdServicio.Rows.Clear()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Modelo,Marca,Area,Chofer,Seguro,Poliza,Vence_Seguro,Contacto_Seguro,Agente,Contacto_Agente,Verifica1,Verifica2,NoCircula,Afina_Ant,Aceite_Ant,Afina_Prox,Aceite_Prox FROM transporte WHERE Placas='" & txtplacas.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbomodelo.Text = rd1("Modelo").ToString
                    cbomarca.Text = rd1("Marca").ToString
                    cboarea.Text = rd1("Area").ToString
                    txtChofer.Text = rd1("Chofer").ToString
                    txtseguros.Text = rd1("Seguro").ToString
                    txtpoliza.Text = rd1("Poliza").ToString
                    dtpvencimiento.Value = rd1("Vence_Seguro").ToString
                    txttelefono.Text = rd1("Contacto_Seguro").ToString
                    txtagente.Text = rd1("Agente").ToString
                    txtcontacto.Text = rd1("Contacto_Agente").ToString
                    cbovencimiento1.Text = rd1("Verifica1").ToString
                    cbovencimiento2.Text = rd1("Verifica2").ToString
                    cbonocircula.Text = rd1("NoCircula").ToString
                    dtpafinacion_ant.Value = rd1("Afina_Ant").ToString
                    dtpaceite_ant.Value = rd1("Aceite_Ant").ToString
                    dtpafinacion_prox.Value = rd1("Afina_Prox").ToString
                    dtpaceite_prox.Value = rd1("Aceite_Prox").ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre,Fecha FROM servicios WHERE Placa='" & txtplacas.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim fe As Date = rd1(1).ToString
                    Dim fec As String = Format(fe, "yyyy-MM-dd")

                    grdServicio.Rows.Add(rd1(0).ToString, fec)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cboarea.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboarea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboarea.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtChofer.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtChofer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChofer.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtseguros.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtseguros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtseguros.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtpoliza.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtpoliza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpoliza.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txttelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtagente.Focus.Equals(True)
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtagente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtagente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcontacto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcontacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontacto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbovencimiento1.Focus.Equals(True)
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cbovencimiento2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbovencimiento2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbonocircula.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbovencimiento1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbovencimiento1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbovencimiento2.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbonocircula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonocircula.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbomodelo_DropDown(sender As Object, e As EventArgs) Handles cbomodelo.DropDown
        Try
            cbomodelo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Modelo FROM transporte WHERE Modelo<>'' ORDER BY Modelo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomodelo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbomarca_DropDown(sender As Object, e As EventArgs) Handles cbomarca.DropDown
        Try
            cbomarca.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Marca FROM transporte WHERE Marca<>'' ORDER BY Marca"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbomarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtChofer_DropDown(sender As Object, e As EventArgs) Handles txtChofer.DropDown
        Try
            txtChofer.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM porteoperador WHERE Nombre<>'' ORDER BY nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    txtChofer.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
    Private Sub cboServicios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboServicios.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnServicio.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnServicio_Click(sender As Object, e As EventArgs) Handles btnServicio.Click
        If cboServicios.Text = "" Then
            If MsgBox("Selecciona un servicio para continuar!!!", vbOKOnly + vbOKOnly, titulocentral) = MsgBoxResult.Ok Then
                cboServicios.DroppedDown = True
                Exit Sub
            End If
        Else
            Dim ser As String = ""
            Dim fec As Date = Nothing
            Dim fech As String = ""

            ser = cboServicios.Text
            fec = dtpFechaServicio.Value
            fech = Format(fec, "yyyy-MM-dd")

            grdServicio.Rows.Add(ser, fech)
            cboServicios.Text = ""
            dtpFechaServicio.Value = Date.Now
        End If
    End Sub

    Private Sub grdServicio_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdServicio.CellDoubleClick
        Dim index As Integer = grdServicio.CurrentRow.Index

        cboServicios.Text = grdServicio.Rows(index).Cells(0).Value.ToString
        dtpFechaServicio.Value = grdServicio.Rows(index).Cells(1).Value.ToString

        grdServicio.Rows.Remove(grdServicio.CurrentRow)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Deseas cerrar el formulario?", vbOKCancel + vbOKOnly, titulocentral) = MsgBoxResult.Ok Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtplacas.Text = "" Then
            MsgBox("Selecciona una placa para Eliminar!!!!", vbOKOnly + vbOKOnly, titulocentral)
            Exit Sub
        End If

        If MsgBox("¿Deseas Eliminar el Vehículo seleccionado?", vbOKCancel + vbOKOnly, titulocentral) = MsgBoxResult.Ok Then
            cnn1.Close()
            cnn1.Open()
            cmd1.Connection = cnn1
            cmd1.CommandType = CommandType.Text
            cmd1.CommandText = "delete from Transporte where Placas=''" & txtplacas.Text & ""
            If cmd1.ExecuteNonQuery Then
                MsgBox("Vehículo Eliminado Correctamente!!!!")
            End If
            rd1.Close()
            cmd1.CommandText = "delete from Servicios where Placa='" & txtplacas.Text & "'"
            cmd1.ExecuteNonQuery()
            btnNuevo.PerformClick()
            cnn1.Close()
        End If
    End Sub


End Class