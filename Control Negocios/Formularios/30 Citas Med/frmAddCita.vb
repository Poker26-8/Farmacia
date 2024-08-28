Public Class frmAddCita
    Private Sub frmAddCita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rtbAsunto.Focus()
        cboHora.Text = Format(Now, "HH")
        cboMinuto.Text = Format(Now, "mm")
        txtDia.Text = Format(Now, "dd")

        Dim val As Integer = Now.Month
        Dim mes As String = ""
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
        cboMes.Text = mes
        cboMesTag()
        cboAño.Text = Format(Now, "yyyy")
    End Sub

    Public Sub cboMesTag()
        If cboMes.Text = "Enero" Then
            cboMes.Tag = 1
        ElseIf cboMes.Text = "Febrero" Then
            cboMes.Tag = 1
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
                minuto = "0" & M
            Else
                minuto = M
            End If
            cboMinuto.Items.Add(
                minuto
                )
        Next
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

    Private Sub cboAño_DropDown(sender As Object, e As EventArgs) Handles cboAño.DropDown
        cboAño.Items.Clear()
        cboAño.Items.Add(Now.Year)
        For A As Integer = 1 To 20
            cboAño.Items.Add(Now.Year + A)
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

    Private Sub cboMes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMes.SelectedValueChanged
        cboMesTag()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        FrmAgenda.tActuales.Start()
        Me.Hide()
        My.Application.DoEvents()
        If (FrmAgenda.optHora.Checked) Then
            ActualHora(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
        End If
        If (FrmAgenda.optDia.Checked) Then
            ActualDia(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
        End If
        My.Application.DoEvents()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'CorroboraR que todos los campos estén llenos
        If cboHora.Text = "" Or cboMinuto.Text = "" Or txtDia.Text = "" Or cboMes.Text = "" Or cboAño.Text = "" Or cboUsuario.Text = "" Or rtbAsunto.Text = "" Then
            MsgBox("Necesita llenar todos los datos para guardar el evento.", vbInformation + vbOKOnly, titulocentral)
            Exit Sub
        End If

        'CorroboraR que la fecha sea coherente
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
                "select * from Agenda where Minuto=" & cboMinuto.Text & " and Hora=" & cboHora.Text & " and Dia=" & txtDia.Text & " and Mes=" & cboMes.Tag & " and Anio=" & cboAño.Text & " and Usuario='" & cboUsuario.Text & "' and Activo=1"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("Ya hay una cita programada para el día " & txtDia.Text & "/" & cboMes.Tag & "/" & cboAño.Text & " a las " & cboHora.Text & ":" & cboMinuto.Text & ".", vbInformation + vbOKCancel, titulocentral)
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                End If
            Else
                'Agrega el evento con normalidad
                cnn2.Close()
                cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "insert into Agenda(Hora,Minuto,Dia,Mes,Anio,Asunto,Usuario,Activo) values(" & cboHora.Text & "," & cboMinuto.Text & "," & txtDia.Text & "," & cboMes.Tag & "," & cboAño.Text & ",'" & QuitaSaltos(rtbAsunto.Text, " ") & "','" & cboUsuario.Text & "',1)"
                cmd2.ExecuteNonQuery()
                cnn2.Close()

                MsgBox("Evento guardado con éxito.", vbInformation + vbOKOnly, "Delsscom Agenda de citas")
            End If
            rd1.Close()
            cnn1.Close()

            FrmAgenda.tActuales.Start()
            Me.Hide()
            If (FrmAgenda.optHora.Checked) Then
                ActualHora(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
            End If
            If (FrmAgenda.optDia.Checked) Then
                ActualDia(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
            End If
            If (FrmAgenda.optMes.Checked) Then
                ActualMes(FrmAgenda.grdCaptura, FrmAgenda.cboUsuario.Text)
            End If
            My.Application.DoEvents()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class