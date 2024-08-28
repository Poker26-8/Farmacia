Public Class frmModificar
    Private Sub frmModificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rtbAsunto.Focus()

        If txtID.Text = "" Then
            FrmAgenda.tActuales.Start()
            Me.Close()
        End If

        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Hora,Minuto,Dia,Mes,Anio,Usuario,Asunto from Agenda where Id=" & txtID.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboHora.Text = rd1("Hora").ToString
                    cboMinuto.Text = rd1("Minuto").ToString
                    txtDia.Text = rd1("Dia").ToString
                    cboMes.Tag = rd1("Mes").ToString
                    cboTagMes()
                    My.Application.DoEvents()
                    cboAño.Text = rd1("Anio").ToString
                    cboUsuario.Text = rd1("Usuario").ToString
                    rtbAsunto.Text = rd1("Asunto").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub cboMesTag()
        If cboMes.Text = "Enero" Then
            cboMes.Tag = 1
        ElseIf cboMes.Text = "Febrero" Then
            cboMes.Tag = 2
        ElseIf cboMes.Text = "Marzo" Then
            cboMes.Tag = 3
        ElseIf cboMes.Text = "Abril" Then
            cboMes.Tag = 4
        ElseIf cboMes.Text = "Mayo" Then
            cboMes.Tag = 5
        ElseIf cboMes.Text = "Junio" Then
            cboMes.Tag = 6
        ElseIf cboMes.Text = "Julio" Then
            cboMes.Tag = 7
        ElseIf cboMes.Text = "Agosto" Then
            cboMes.Tag = 8
        ElseIf cboMes.Text = "Septiembre" Then
            cboMes.Tag = 9
        ElseIf cboMes.Text = "Octubre" Then
            cboMes.Tag = 10
        ElseIf cboMes.Text = "Noviembre" Then
            cboMes.Tag = 11
        ElseIf cboMes.Text = "Diciembre" Then
            cboMes.Tag = 12
        End If
    End Sub

    Public Sub cboTagMes()
        If cboMes.Tag = 1 Then
            cboMes.Text = "Enero"
        ElseIf cboMes.Tag = 2 Then
            cboMes.Text = "Febrero"
        ElseIf cboMes.Tag = 3 Then
            cboMes.Text = "Marzo"
        ElseIf cboMes.Tag = 4 Then
            cboMes.Text = "Abril"
        ElseIf cboMes.Tag = 5 Then
            cboMes.Text = "Mayo"
        ElseIf cboMes.Tag = 6 Then
            cboMes.Text = "Junio"
        ElseIf cboMes.Tag = 7 Then
            cboMes.Text = "Julio"
        ElseIf cboMes.Tag = 8 Then
            cboMes.Text = "Agosto"
        ElseIf cboMes.Tag = 9 Then
            cboMes.Text = "Septiembre"
        ElseIf cboMes.Tag = 10 Then
            cboMes.Text = "Octubre"
        ElseIf cboMes.Tag = 11 Then
            cboMes.Text = "Noviembre"
        ElseIf cboMes.Tag = 12 Then
            cboMes.Text = "Diciembre"
        End If
    End Sub

    Private Sub cboUsuario_DropDown(sender As Object, e As EventArgs) Handles cboUsuario.DropDown
        cboUsuario.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Alias FROM Usuarios ORDER BY Alias"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboUsuario.Items.Add(
                        rd1(0).ToString
                        )
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboHora_DropDown(sender As Object, e As EventArgs) Handles cboHora.DropDown
        cboHora.Items.Clear()
        For H As Integer = 0 To 23
            Dim hora As String = ""
            If H < 10 Then
                hora = "0" & H
            Else
                hora = H
            End If
            cboHora.Items.Add(
                hora
                )
        Next
    End Sub

    Private Sub cboMinuto_DropDown(sender As Object, e As EventArgs) Handles cboMinuto.DropDown
        cboMinuto.Items.Clear()
        For M As Integer = 0 To 59
            Dim minuto As String = ""
            If M < 10 Then
                'minuto = "0" & M
                minuto = M
            Else
                minuto = M
            End If
            cboMinuto.Items.Add(
                minuto
                )
        Next
    End Sub

    Private Sub cboAño_DropDown(sender As Object, e As EventArgs) Handles cboAño.DropDown
        cboAño.Items.Clear()
        cboAño.Items.Add(Now.Year)
        For A As Integer = 1 To 20
            cboAño.Items.Add(
                Now.Year + A
                )
        Next
    End Sub

    Private Sub cboMes_DropDown(sender As Object, e As EventArgs) Handles cboMes.DropDown
        cboMes.Items.Clear()

        Dim mes As String = ""
        For val As Integer = 1 To 12
            If val = 1 Then
                mes = "Enero"
            ElseIf val = 2 Then
                mes = "Febrero"
            ElseIf val = 3 Then
                mes = "Marzo"
            ElseIf val = 4 Then
                mes = "Abril"
            ElseIf val = 5 Then
                mes = "Mayo"
            ElseIf val = 6 Then
                mes = "Junio"
            ElseIf val = 7 Then
                mes = "Julio"
            ElseIf val = 8 Then
                mes = "Agosto"
            ElseIf val = 9 Then
                mes = "Septiembre"
            ElseIf val = 10 Then
                mes = "Octubre"
            ElseIf val = 11 Then
                mes = "Noviembre"
            ElseIf val = 12 Then
                mes = "Diciembre"
            End If
            cboMes.Items.Add(
                mes
                )
        Next
    End Sub

    Private Sub cboHora_GotFocus(sender As Object, e As EventArgs) Handles cboHora.GotFocus
        cboHora.SelectionStart = 0
        cboHora.SelectionLength = 20
    End Sub

    Private Sub cboHora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboHora.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMinuto.Focus()
        End If
    End Sub

    Private Sub cboHora_LostFocus(sender As Object, e As EventArgs) Handles cboHora.LostFocus
        If CDec(cboHora.Text) < 10 Then
            cboHora.Text = "0" & cboHora.Text
        End If
    End Sub

    Private Sub cboMinuto_GotFocus(sender As Object, e As EventArgs) Handles cboMinuto.GotFocus
        cboMinuto.SelectionStart = 0
        cboMinuto.SelectionLength = 20
    End Sub

    Private Sub cboMinuto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMinuto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtDia.Focus()
        End If
    End Sub

    Private Sub cboMinuto_LostFocus(sender As Object, e As EventArgs) Handles cboMinuto.LostFocus
        If CDec(cboMinuto.Text) < 10 Then
            cboMinuto.Text = "0" & cboMinuto.Text
        End If
    End Sub

    Private Sub txtDia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMes.Focus()
        End If
    End Sub

    Private Sub cboMes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMes.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboMes.Text <> "Enero" Or cboMes.Text <> "Febrero" Or cboMes.Text <> "Marzo" Or cboMes.Text <> "Abril" Or cboMes.Text <> "Mayo" Or cboMes.Text <> "Junio" Or cboMes.Text <> "Julio" Or cboMes.Text <> "Agosto" Or cboMes.Text <> "Septiembre" Or cboMes.Text <> "Octubre" Or cboMes.Text <> "Noviembre" Or cboMes.Text <> "Diciembre" Then
                cboMesTag()
                cboAño.Focus()
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        FrmAgenda.tActuales.Start()
        Me.Close()
    End Sub

    Private Sub cboAño_GotFocus(sender As Object, e As EventArgs) Handles cboAño.GotFocus
        cboAño.SelectionStart = 0
        cboAño.SelectionLength = 20
    End Sub

    Private Sub cboAño_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboAño.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboUsuario.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboUsuario_GotFocus(sender As Object, e As EventArgs) Handles cboUsuario.GotFocus
        cboUsuario.SelectionStart = 0
        cboUsuario.SelectionLength = 20
    End Sub

    Private Sub cboUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUsuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            rtbAsunto.Focus()
        End If
    End Sub

    Private Sub rtbAsunto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtbAsunto.KeyPress
        If AscW(e.KeyChar) = Keys.Tab Then
            btnEdit.Focus()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Desea eliminar éste evento de manera permanente?" + vbNewLine + "Esta acción no se puede deshacer", vbInformation + vbOKCancel, titulocentral) = vbOK Then
            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from Agenda where Id=" & txtID.Text
                cmd1.ExecuteNonQuery()
                cnn1.Close()

                MsgBox("Evento eliminado con éxito.", vbInformation + vbOKOnly, titulocentral)

                Me.Hide()
                If (FrmAgenda.optHora.Checked) Then
                    ActualHora(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
                End If
                If (FrmAgenda.optDia.Checked) Then
                    ActualDia(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
                End If
                FrmAgenda.tActuales.Start()
                My.Application.DoEvents()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'Corrobora que todos los campos estén llenos
        If cboHora.Text = "" Or cboMinuto.Text = "" Or txtDia.Text = "" Or cboMes.Text = "" Or cboAño.Text = "" Or cboUsuario.Text = "" Or rtbAsunto.Text = "" Then
            MsgBox("Necesita llenar todos los datos para guardar el evento.", vbInformation + vbOKOnly, titulocentral)
            Exit Sub
        End If

        'Corrobora que la fecha sea coherente
        Dim añito As String = Format(Now, "yyyy")
        Dim añote As String = cboAño.Text
        If añote < añito Then
            MsgBox("No puedes guardar un evento en un año pasado.", vbInformation + vbOKOnly, titulocentral)
            cboAño.Focus()
            Exit Sub
        End If

        Dim mesesito As Integer = Now.Month
        Dim mesesote As Integer = CInt(cboMes.Tag)
        If añote = añito Then
            If mesesote < mesesito Then
                MsgBox("No puedes guardar un evento en un mes pasado.", vbInformation + vbOKOnly, titulocentral)
                cboMes.Focus()
                Exit Sub
            End If
        End If

        Dim fechita As String = Format(Now, "dd")
        Dim fechota As String = txtDia.Text
        If añote = añito Then
            If mesesote = mesesito Then
                If fechota < fechita Then
                    MsgBox("No puedes guardar un evento en un día pasado.", vbInformation + vbOKOnly, titulocentral)
                    txtDia.Focus()
                    Exit Sub
                End If
            End If
        End If

        Dim tiempito As String = Format(Now, "HHmm")
        Dim tiempote As String = cboHora.Text & cboMinuto.Text
        If añote = añito Then
            If mesesote = mesesito Then
                If fechota = fechita Then
                    If tiempote < tiempito Then
                        MsgBox("No puedes guardar un evento en una hora pasada.", vbInformation + vbOKOnly, titulocentral)
                        txtDia.Focus()
                        Exit Sub
                    End If
                End If
            End If
        End If

        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Agenda set Hora=" & cboHora.Text & ", Minuto=" & cboMinuto.Text & ", Dia=" & txtDia.Text & ", Mes=" & cboMes.Tag & ", Anio=" & cboAño.Text & ", Asunto='" & QuitaSaltos(rtbAsunto.Text, "") & "', Usuario='" & cboUsuario.Text & "', Activo=1 where Id=" & txtID.Text
            cmd1.ExecuteNonQuery()
            cnn1.Close()

            MsgBox("Evento modificado con éxito.", vbInformation + vbOKOnly, titulocentral)

            Me.Hide()
            If (FrmAgenda.optHora.Checked) Then
                ActualHora(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
            End If
            If (FrmAgenda.optDia.Checked) Then
                ActualDia(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
            End If
            FrmAgenda.tActuales.Start()
            My.Application.DoEvents()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class