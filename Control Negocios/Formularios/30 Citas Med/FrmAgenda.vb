Public Class FrmAgenda

    Dim id_cita As Integer = 0
    Dim tipo As Integer = 0
    Dim cadena_con As String = ""

    Private Sub FrmAgenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboUsuario.Focus.Equals(True)

        tHora.Start()
        My.Application.DoEvents()
        tActuales.Start()
        My.Application.DoEvents()
        tEstado.Start()
        refer = ""
        My.Application.DoEvents()

        btnAgregar.Visible = True
        btnModificar.Visible = False
        btnDetalle.Visible = False
    End Sub

    Private Sub FrmAgenda_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cboUsuario.Focus.Equals(True)
    End Sub

    Private Sub cboUsuario_DropDown(sender As Object, e As EventArgs) Handles cboUsuario.DropDown
        Try
            cboUsuario.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Alias FROM usuarios WHERE Alias<>'' ORDER BY Alias"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboUsuario.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub tHora_Tick(sender As Object, e As EventArgs) Handles tHora.Tick

        lblHora.Text = FormatDateTime(Now, DateFormat.ShortTime)

        Dim CHora As String = ""

        CHora = Mid(lblHora.Text, 1, 2)
        lblHora.Tag = CHora

        Dim valor As Integer = Now.DayOfWeek
        Dim dia As String = ""
        If valor = 1 Then
            dia = "Lunes"
        ElseIf valor = 2 Then
            dia = "Martes"
        ElseIf valor = 3 Then
            dia = "Miércoles"
        ElseIf valor = 4 Then
            dia = "Jueves"
        ElseIf valor = 5 Then
            dia = "Viernes"
        ElseIf valor = 6 Then
            dia = "Sábado"
        ElseIf valor = 7 Then
            dia = "Domingo"
        End If

        Dim dian As String = Format(Date.Now, "dd")

        lblDía.Text = dia & ", " & dian
        lblDía.Tag = dia

        My.Application.DoEvents()

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
        lblMes.Text = mes

        My.Application.DoEvents()

        Dim Hoy As String = Format(Now, "dd/MM/yyyy")
        Dim X As Integer = 0

        For vic As Integer = 0 To 3
            X = InStr(1, Hoy, "/") - 1
            If X < 0 Then Exit For
            If vic = 0 Then
                Fechita(1) = Mid(Hoy, 1, InStr(1, Hoy, "/") - 1)
            ElseIf vic = 1 Then
                Fechita(2) = Mid(Hoy, 1, InStr(1, Hoy, "/") - 1)
            End If
            Hoy = Mid(Hoy, InStr(1, Hoy, "/") + 1, 200)
        Next
        Fechita(3) = Hoy

        Dim A_horita As String = Format(Now, "HH:MM")
        Dim S As Integer = 0

        For dan As Integer = 0 To 2
            S = InStr(1, A_horita, ":") - 1
            If S < 0 Then Exit For
            If dan = 0 Then
                Tiempo(1) = Mid(A_horita, 1, InStr(1, A_horita, ":") - 1)
            End If
            A_horita = Mid(A_horita, InStr(1, A_horita, ":") + 1, 200)
        Next
        Tiempo(2) = A_horita

    End Sub

    Private Sub tActuales_Tick(sender As Object, e As EventArgs) Handles tActuales.Tick
        If (optHora.Checked) Then
            ActualHora(grdCaptura, cboUsuario.Text)
        End If
        If (optDia.Checked) Then
            ActualDia(grdCaptura, cboUsuario.Text)
        End If
        If (optMes.Checked) Then
            ActualMes(grdCaptura, cboUsuario.Text)
        End If
    End Sub

    Private Sub grdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellClick
        id_cita = grdCaptura.CurrentRow.Cells(0).Value.ToString
        refer = grdCaptura.CurrentRow.Cells(1).Value.ToString
    End Sub

    Private Sub cboUsuario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboUsuario.SelectedValueChanged
        grdCaptura.Rows.Clear()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If id_cita = 0 Then
            MsgBox("Seleccione un registro con información para poder modificarlo.", vbInformation + vbOKOnly, titulocentral)
            Exit Sub
        End If
        frmModificar.txtID.Text = id_cita
        tActuales.Stop()
        My.Application.DoEvents()
        frmModificar.Show()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmAddCita.BringToFront()
        frmAddCita.Show()
        tActuales.Stop()
    End Sub

    Private Sub tEstado_Tick(sender As Object, e As EventArgs) Handles tEstado.Tick
        Estado()
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        If id_cita = 0 Then
            MsgBox("Seleccione un registro con información para poder modificarlo.", vbInformation + vbOKOnly, titulocentral)
            Exit Sub
        End If
        If refer = "" Then
            MsgBox("Seleccione un registro con información para poder modificarlo.", vbInformation + vbOKOnly, titulocentral)
            Exit Sub
        End If
        tActuales.Stop()
        If (optDia.Checked) Then
            frmDetalleCita.Text = "Detalle del día " & lblDía.Text & " entre las " & Mid(refer, 1, 2) & ":00 y las " & Mid(refer, 1, 2) + 1 & ":00"
        End If
        If (optMes.Checked) Then
            frmDetalleCita.Text = "Detalle del día " & refer & " de " & lblMes.Text
        End If
        frmDetalleCita.cbousu.Text = cboUsuario.Text
        frmDetalleCita.txtReferencia.Text = refer
        My.Application.DoEvents()
        frmDetalleCita.Show()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        frmConsultaCita.BringToFront()
        frmConsultaCita.Show()

    End Sub

    Private Sub optHora_Click(sender As Object, e As EventArgs) Handles optHora.Click
        grdCaptura.Rows.Clear()
        grdCaptura.ColumnCount = 0
        tipo = 1
        If cboUsuario.Text = "" Then
            MsgBox("Seleccione un usuario por consultar.", vbInformation + vbOKOnly, titulocentral)
            cboUsuario.Focus()
            optHora.Checked = False
            Exit Sub
        End If

        'Ajusta el grid
        grdCaptura.ColumnCount = 4
        With grdCaptura.Columns(0)
            .Name = "Id"
            .Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = False
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(1)
            .Name = "Hora"
            .Width = 60
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = True
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(2)
            .Name = "Evento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Visible = True
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(3)
            .Name = "Activo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Visible = False
            .Resizable = DataGridViewTriState.False
        End With

        Dim minuto As String = ""
        Dim hora As String = ""

        Try
            cnn1.Close()
            cnn1.Open()

            For field As Integer = 0 To 60
                If field = 60 Then Exit For
                minuto = field

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Hora,Minuto,Id,Asunto,Activo from Agenda where Minuto=" & minuto & " and Hora=" & Tiempo(1) & " and Dia=" & Fechita(1) & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & cboUsuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If CDec(rd1("Hora").ToString) < 10 Then
                            hora = "0" & rd1("Hora").ToString
                        Else
                            hora = rd1("Hora").ToString
                        End If
                        If CDec(rd1("Minuto").ToString) < 10 Then
                            minuto = "0" & rd1("Minuto").ToString
                        Else
                            minuto = rd1("Minuto").ToString
                        End If

                        grdCaptura.Rows.Add(rd1("Id").ToString, hora & ":" & minuto, rd1("Asunto").ToString, rd1("Activo").ToString)
                    End If
                Else
                    If field < 10 Then
                        minuto = "0" & field
                    Else
                        minuto = field
                    End If

                    If CDec(Tiempo(1)) < 10 Then
                        hora = "0" & Tiempo(1)
                    Else
                        hora = Tiempo(1)
                    End If

                    grdCaptura.Rows.Add("0", hora & ":" & minuto, "", "NULO")
                End If
                rd1.Close()

                If grdCaptura.Rows(field).Cells(3).Value.ToString = "NULO" Then
                Else
                    If grdCaptura.Rows(field).Cells(3).Value = False Then
                        grdCaptura.Rows(field).DefaultCellStyle.BackColor = Color.Beige
                    End If
                End If
            Next
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        btnAgregar.Visible = True
        btnModificar.Visible = True
        btnDetalle.Visible = False
    End Sub

    Private Sub optDia_Click(sender As Object, e As EventArgs) Handles optDia.Click
        grdCaptura.Rows.Clear()
        grdCaptura.ColumnCount = 0
        tipo = 2

        If cboUsuario.Text = "" Then
            MsgBox("Seleccione un usuario por consultar.", vbInformation + vbOKOnly, titulocentral)
            cboUsuario.Focus()
            optDia.Checked = True
            Exit Sub
        End If

        'Ajusta el grid
        grdCaptura.ColumnCount = 4
        With grdCaptura.Columns(0)
            .Name = "Id"
            .Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = False
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(1)
            .Name = "Hora"
            .Width = 60
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = True
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(2)
            .Name = "Evento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Visible = True
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(3)
            .Name = "Activo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Visible = False
            .Resizable = DataGridViewTriState.False
        End With

        Dim hora As String = ""
        Dim horx As String = ""
        Dim evento As String = ""

        Try
            cnn3.Close() : cnn3.Open()
            cnn2.Close() : cnn2.Open()

            For field As Integer = 0 To 24
                If field = 24 Then Exit For
                hora = field

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select Hora,Id,Activo from Agenda where Hora=" & hora & " and Dia=" & Fechita(1) & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & cboUsuario.Text & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Asunto from Agenda where Hora=" & hora & " and Dia=" & Fechita(1) & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & cboUsuario.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            If rd2.HasRows Then
                                evento = evento & " - " & rd2(0).ToString
                            End If
                        Loop
                        rd2.Close()
                        evento = Mid(evento, 4, 10000)

                        If CDec(rd3("Hora").ToString) < 10 Then
                            horx = "0" & rd3("Hora").ToString
                        Else
                            horx = rd3("Hora").ToString
                        End If

                        grdCaptura.Rows.Add(rd3("Id").ToString, horx & ":00", evento, rd3("Activo").ToString)
                    End If
                Else
                    If hora < 10 Then
                        horx = "0" & field
                    Else
                        horx = field
                    End If
                    grdCaptura.Rows.Add("0", horx & ":00", "", "NULO")
                End If

                If grdCaptura.Rows(field).Cells(3).Value.ToString = "NULO" Then
                Else
                    If grdCaptura.Rows(field).Cells(3).Value = False Then
                        grdCaptura.Rows(field).DefaultCellStyle.BackColor = Color.Beige
                    End If
                End If

                My.Application.DoEvents()
                rd3.Close()
            Next
            cnn2.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
            cnn2.Close()
        End Try

        btnAgregar.Visible = True
        btnModificar.Visible = False
        btnDetalle.Visible = True
    End Sub

    Private Sub optMes_Click(sender As Object, e As EventArgs) Handles optMes.Click
        grdCaptura.Rows.Clear()
        grdCaptura.ColumnCount = 0
        tipo = 3

        If cboUsuario.Text = "" Then
            MsgBox("Seleccione un usuario por consultar.", vbInformation + vbOKOnly, titulocentral)
            cboUsuario.Focus()
            optMes.Checked = True
            Exit Sub
        End If

        'Ajusta el grid
        grdCaptura.ColumnCount = 4
        With grdCaptura.Columns(0)
            .Name = "Id"
            .Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = False
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(1)
            .Name = "Hora"
            .Width = 60
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = True
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(2)
            .Name = "Evento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Visible = True
            .Resizable = DataGridViewTriState.False
        End With
        With grdCaptura.Columns(3)
            .Name = "Activo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Visible = False
            .Resizable = DataGridViewTriState.False
        End With

        Dim R As Integer = Date.DaysInMonth(Now.Year, Now.Month)
        Dim dia As String = ""
        Dim evento As String = ""

        Try
            cnn4.Close() : cnn4.Open()
            cnn2.Close() : cnn2.Open()

            For field As Integer = 1 To R
                dia = field

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                    "select Id,Dia,Activo from Agenda where Dia=" & dia & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & cboUsuario.Text & "'"
                rd4 = cmd4.ExecuteReader
                If rd4.HasRows Then
                    If rd4.Read Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Asunto from Agenda where Dia=" & dia & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & cboUsuario.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            If rd2.HasRows Then
                                evento = evento & " - " & rd2(0).ToString
                            End If
                        Loop
                        evento = Mid(evento, 4, 10000)
                        rd2.Close()

                        grdCaptura.Rows.Add(rd4("Id").ToString, rd4("Dia").ToString, evento, rd4("Activo").ToString)
                    End If
                Else
                    grdCaptura.Rows.Add("0", dia, "", "XD")
                End If

                If grdCaptura.Rows(field - 1).Cells(3).Value.ToString = "XD" Then
                Else
                    If grdCaptura.Rows(field - 1).Cells(3).Value = False Then
                        grdCaptura.Rows(field - 1).DefaultCellStyle.BackColor = Color.Beige
                    End If
                End If

                My.Application.DoEvents()
                rd4.Close()
            Next
            cnn2.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
            cnn2.Close()
        End Try

        btnAgregar.Visible = True
        btnModificar.Visible = False
        btnDetalle.Visible = True
    End Sub
End Class