Imports Microsoft.Office.Interop

Public Class frmReporteAsistencia

    Private Sub frmReporteAsistencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        optTodos.Checked = True
        grdCaptura.Rows.Clear()
        cbofiltro.Items.Clear()
        cbofiltro.Text = ""
    End Sub

    Private Sub cbofiltro_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofiltro.DropDown
        Dim instruccion As String = ""
        If optArea.Checked Then
            instruccion = "select distinct Area from Usuarios order by Area"
        End If
        If optPuesto.Checked Then
            instruccion = "select distinct Puesto from Usuarios order by Puesto"
        End If
        If optEmpleado.Checked Then
            instruccion = "select distinct Nombre from Usuarios order by Nombre"
        End If
        cbofiltro.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = instruccion
            rd1 = cmd1.ExecuteReader

            Do While rd1.Read
                If rd1.HasRows Then cbofiltro.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub optTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optTodos.CheckedChanged
        If optTodos.Checked = True Then
            cbofiltro.Items.Clear()
            cbofiltro.Text = ""
            cbofiltro.Visible = False

            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label6.Visible = False

            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox4.Visible = False

            grdCaptura.ColumnCount = 0
            grdCaptura.Rows.Clear()

            grdCaptura.ColumnCount = 9
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Nombre"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(1)
                    .HeaderText = "Puesto"
                    .Width = 120
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(2)
                    .HeaderText = "Área"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(3)
                    .HeaderText = "Tipo"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(4)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(5)
                    .HeaderText = "Hora"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(6)
                    .HeaderText = "Diferencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(7)
                    .HeaderText = "En tolerancia"
                    .Width = 75
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(8)
                    .HeaderText = "Días descanso"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            End With
        End If
    End Sub

    Private Sub optPuesto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optPuesto.CheckedChanged
        If optPuesto.Checked = True Then
            cbofiltro.Items.Clear()
            cbofiltro.Text = ""
            cbofiltro.Visible = False

            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label6.Visible = False

            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox4.Visible = False

            grdCaptura.ColumnCount = 0
            grdCaptura.Rows.Clear()

            grdCaptura.ColumnCount = 9
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Nombre"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(1)
                    .HeaderText = "Puesto"
                    .Width = 120
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(2)
                    .HeaderText = "Área"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(3)
                    .HeaderText = "Tipo"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(4)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(5)
                    .HeaderText = "Hora"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(6)
                    .HeaderText = "Diferencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(7)
                    .HeaderText = "En tolerancia"
                    .Width = 75
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(8)
                    .HeaderText = "Días descanso"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            End With
        End If
    End Sub

    Private Sub optArea_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optArea.CheckedChanged
        If optArea.Checked = True Then
            cbofiltro.Items.Clear()
            cbofiltro.Text = ""
            cbofiltro.Visible = False

            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label6.Visible = False

            TextBox1.Visible = False
            TextBox2.Visible = False
            TextBox4.Visible = False

            grdCaptura.ColumnCount = 0
            grdCaptura.Rows.Clear()

            grdCaptura.ColumnCount = 9
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Nombre"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                With .Columns(1)
                    .HeaderText = "Puesto"
                    .Width = 120
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(2)
                    .HeaderText = "Área"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(3)
                    .HeaderText = "Tipo"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(4)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(5)
                    .HeaderText = "Hora"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(6)
                    .HeaderText = "Diferencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(7)
                    .HeaderText = "En tolerancia"
                    .Width = 75
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(8)
                    .HeaderText = "Días descanso"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
            End With
        End If
    End Sub

    Private Sub optEmpleado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optEmpleado.CheckedChanged
        If optEmpleado.Checked = True Then
            cbofiltro.Items.Clear()
            cbofiltro.Text = ""
            cbofiltro.Visible = True

            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            Label6.Visible = True

            TextBox1.Visible = True
            TextBox2.Visible = True
            TextBox4.Visible = True

            grdCaptura.ColumnCount = 0
            grdCaptura.Rows.Clear()

            grdCaptura.ColumnCount = 8
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Puesto"
                    .Width = 130
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(1)
                    .HeaderText = "Área"
                    .Width = 120
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                With .Columns(2)
                    .HeaderText = "Tipo"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(4)
                    .HeaderText = "Hora"
                    .Width = 90
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns(5)
                    .HeaderText = "Diferencia"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(6)
                    .HeaderText = "En tolerancia"
                    .Width = 75
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                With .Columns(7)
                    .HeaderText = "Días descanso"
                    .Width = 80
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With
                'With .Columns(8)
                '    .HeaderText = "Horas trabajadas"
                '    .Width = 90
                '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'End With
            End With
        End If
    End Sub

    Private Sub btnReporte_Click(sender As System.Object, e As System.EventArgs) Handles btnReporte.Click
        Dim Month1 As Date = Nothing
        Dim Month2 As Date = Nothing
        Dim sql As String = ""

        Dim nombre As String = ""
        Dim area As String = ""
        Dim puesto As String = ""
        Dim descansos As Integer = 0
        Dim hora_entrada As String = ""
        Dim hora_salida As String = ""
        Dim tolerancia_ent As Double = 0
        Dim tolerancia_sal As Double = 0

        Dim horas As Double = 0
        Dim sueldo As Double = 0
        Dim sueldo_por_hora As Double = 0

        Month1 = mCalendar1.SelectionStart.ToShortDateString
        Month2 = mCalendar2.SelectionStart.ToShortDateString

        grdCaptura.Rows.Clear()

        If optTodos.Checked Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "select distinct NumEmp, Nombre from Asistencia where Fecha between '" & Format(Month1, "yyyy-MM-dd") & "' and '" & Format(Month2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader

                cnn2.Close() : cnn2.Open()
                Do While rd1.Read
                    If rd1.HasRows Then
                        nombre = rd1("Nombre").ToString

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, HE, HS, TE, TS from Horarios where IdUsu=" & rd1(0).ToString()
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                If rd2(0).ToString = True Then descansos += 1
                                If rd2(1).ToString = True Then descansos += 1
                                If rd2(2).ToString = True Then descansos += 1
                                If rd2(3).ToString = True Then descansos += 1
                                If rd2(4).ToString = True Then descansos += 1
                                If rd2(5).ToString = True Then descansos += 1
                                If rd2(6).ToString = True Then descansos += 1
                                hora_entrada = rd2(7).ToString
                                hora_salida = rd2(8).ToString
                                tolerancia_ent = rd2(9).ToString
                                tolerancia_sal = rd2(10).ToString
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Area, Puesto from Usuarios where IdEmpleado=" & rd1(0).ToString()
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                area = rd2(0).ToString()
                                puesto = rd2(1).ToString()
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Estatus,Fecha,Hora from Asistencia where NumEmp=" & rd1(0).ToString() & " and Fecha between '" & Format(Month1, "yyyy-MM-dd") & "' and '" & Format(Month2, "yyyy-MM-dd") & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            Dim diferencia As String = ""
                            Dim max_hora As String = ""
                            Dim que_pato As String = ""
                            If rd2("Estatus").ToString = "ENTRADA" Then
                                If hora_entrada <> "" Then
                                    diferencia = DateDiff(DateInterval.Minute, CDate(hora_entrada), CDate(rd2("Hora").ToString()))
                                    max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_ent), CDate(hora_entrada))
                                    If CDate(rd2("Hora").ToString()) > CDate(max_hora) Then
                                        que_pato = "No"
                                    Else
                                        que_pato = "Sí"
                                    End If
                                End If
                            Else
                                If hora_salida <> "" Then
                                    diferencia = DateDiff(DateInterval.Minute, CDate(hora_salida), CDate(rd2("Hora").ToString()))
                                    max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_sal), CDate(hora_salida))
                                    If CDate(rd2("Hora").ToString()) > CDate(max_hora) Then
                                        que_pato = "No"
                                    Else
                                        que_pato = "Sí"
                                    End If
                                End If
                            End If
                            grdCaptura.Rows.Add(nombre, puesto, area, rd2("Estatus").ToString(), FormatDateTime(rd2("Fecha").ToString(), DateFormat.ShortDate), rd2("Hora").ToString(), diferencia, que_pato, descansos)
                        Loop
                        rd2.Close()
                    End If
                Loop
                rd1.Close() : cnn1.Close()
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try
        End If

        If optPuesto.Checked Then
            If cbofiltro.Text = "" Then MsgBox("Selecciona un puesto para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios") : cbofiltro.Focus().Equals(True) : Exit Sub
            sql = "select distinct Asistencia.Nombre, Asistencia.NumEmp from Asistencia, Usuarios where Asistencia.NumEmp=Usuarios.IdEmpleado and Usuarios.Puesto='" & cbofiltro.Text & "' and Asistencia.Fecha>='" & Format(Month1, "yyyy-MM-dd") & "' and Asistencia.Fecha<='" & Format(Month2, "yyyy-MM-dd") & "'"

            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = sql

                rd1 = cmd1.ExecuteReader

                Do While rd1.Read
                    If rd1.HasRows Then
                        nombre = rd1("Nombre").ToString
                        cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, HE, HS, TE, TS from Horarios where IdUsu=" & rd1("NumEmp").ToString

                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                If rd2(0).ToString = True Then descansos += 1
                                If rd2(1).ToString = True Then descansos += 1
                                If rd2(2).ToString = True Then descansos += 1
                                If rd2(3).ToString = True Then descansos += 1
                                If rd2(4).ToString = True Then descansos += 1
                                If rd2(5).ToString = True Then descansos += 1
                                If rd2(6).ToString = True Then descansos += 1
                                hora_entrada = rd2(7).ToString
                                hora_salida = rd2(8).ToString
                                tolerancia_ent = rd2(9).ToString
                                tolerancia_sal = rd2(10).ToString
                            End If
                        Else
                            rd2.Close()
                            cnn2.Close()
                            Exit Sub
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Area, Puesto from Usuarios where IdEmpleado=" & rd1("NumEmp").ToString

                        rd2 = cmd2.ExecuteReader

                        If rd2.HasRows Then
                            If rd2.Read Then
                                area = rd2(0).ToString
                                puesto = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Estatus,Hora,Fecha from Asistencia where Nombre='" & rd1(0).ToString & "' and Fecha>='" & Format(Month1, "yyyy-MM-dd") & "' and Fecha<='" & Format(Month2, "yyyy-MM-dd") & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            Dim diferencia As String = ""
                            Dim max_hora As String = ""
                            Dim que_pato As String = ""
                            If rd2("Estatus").ToString = "ENTRADA" Then
                                If hora_entrada <> "" Then
                                    diferencia = DateDiff(DateInterval.Minute, CDate(hora_entrada), CDate(rd2("Hora").ToString))
                                    max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_ent), CDate(hora_entrada))
                                    If CDate(rd2("Hora").ToString) > CDate(max_hora) Then
                                        que_pato = "No"
                                    Else
                                        que_pato = "Sí"
                                    End If
                                End If
                            Else
                                If hora_salida <> "" Then
                                    diferencia = DateDiff(DateInterval.Minute, CDate(hora_salida), CDate(rd2("Hora").ToString))
                                    max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_sal), CDate(hora_salida))
                                    If CDate(rd2("Hora").ToString) > CDate(max_hora) Then
                                        que_pato = "No"
                                    Else
                                        que_pato = "Sí"
                                    End If
                                End If
                            End If
                            grdCaptura.Rows.Add(nombre, puesto, area, rd2("Hora").ToString, FormatDateTime(rd2("Fecha").ToString, DateFormat.ShortDate), rd2("Estatus").ToString, diferencia, que_pato, descansos)
                        Loop
                        rd2.Close()
                        cnn2.Close()
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try
        End If

        If optArea.Checked Then
            If cbofiltro.Text = "" Then MsgBox("Selecciona un área para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios") : cbofiltro.Focus().Equals(True) : Exit Sub
            sql = "select distinct Asistencia.Nombre, Asistencia.NumEmp from Asistencia, Usuarios where Asistencia.NumEmp=Usuarios.IdEmpleado and Usuarios.Area='" & cbofiltro.Text & "' and Asistencia.Fecha>='" & Format(Month1, "yyyy-MM-dd") & "' and Asistencia.Fecha<='" & Format(Month2, "yyyy-MM-dd") & "'"

            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = sql

                rd1 = cmd1.ExecuteReader

                Do While rd1.Read
                    If rd1.HasRows Then
                        nombre = rd1("Nombre").ToString
                        cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, HE, HS, TE, TS from Horarios where IdUsu=" & rd1("NumEmp").ToString

                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                If rd2(0).ToString = True Then descansos += 1
                                If rd2(1).ToString = True Then descansos += 1
                                If rd2(2).ToString = True Then descansos += 1
                                If rd2(3).ToString = True Then descansos += 1
                                If rd2(4).ToString = True Then descansos += 1
                                If rd2(5).ToString = True Then descansos += 1
                                If rd2(6).ToString = True Then descansos += 1
                                hora_entrada = rd2(7).ToString
                                hora_salida = rd2(8).ToString
                                tolerancia_ent = rd2(9).ToString
                                tolerancia_sal = rd2(10).ToString
                            End If
                        Else
                            rd2.Close()
                            cnn2.Close()
                            Exit Sub
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Area, Puesto from Usuarios where IdEmpleado=" & rd1("NumEmp").ToString

                        rd2 = cmd2.ExecuteReader

                        If rd2.HasRows Then
                            If rd2.Read Then
                                area = rd2(0).ToString
                                puesto = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Estatus,Hora,Fecha from Asistencia where Nombre='" & rd1(0).ToString & "' and Fecha>='" & Format(Month1, "yyyy-MM-dd") & "' and Fecha<='" & Format(Month2, "yyyy-MM-dd") & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            Dim diferencia As String = ""
                            Dim max_hora As String = ""
                            Dim que_pato As String = ""
                            If rd2("Estatus").ToString = "ENTRADA" Then
                                If hora_entrada <> "" Then
                                    diferencia = DateDiff(DateInterval.Minute, CDate(hora_entrada), CDate(rd2("Hora").ToString))
                                    max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_ent), CDate(hora_entrada))
                                    If CDate(rd2("Hora").ToString) > CDate(max_hora) Then
                                        que_pato = "No"
                                    Else
                                        que_pato = "Sí"
                                    End If
                                End If
                            Else
                                If hora_salida <> "" Then
                                    diferencia = DateDiff(DateInterval.Minute, CDate(hora_salida), CDate(rd2("Hora").ToString))
                                    max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_sal), CDate(hora_salida))
                                    If CDate(rd2("Hora").ToString) > CDate(max_hora) Then
                                        que_pato = "No"
                                    Else
                                        que_pato = "Sí"
                                    End If
                                End If
                            End If
                            grdCaptura.Rows.Add(nombre, puesto, area, rd2("Hora").ToString, FormatDateTime(rd2("Fecha").ToString, DateFormat.ShortDate), rd2("Estatus").ToString, diferencia, que_pato, descansos)
                        Loop
                        rd2.Close()
                        cnn2.Close()
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try
        End If

        Dim id_emple As Integer = 0

        If optEmpleado.Checked Then
            If cbofiltro.Text = "" Then MsgBox("Selecciona un empleado para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios") : cbofiltro.Focus().Equals(True) : Exit Sub

            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select IdEmpleado,Puesto,Area from Usuarios where Nombre='" & cbofiltro.Text & "'"

                rd1 = cmd1.ExecuteReader

                If rd1.HasRows Then
                    If rd1.Read Then
                        id_emple = rd1("IdEmpleado").ToString
                        puesto = rd1("Puesto").ToString
                        area = rd1("Area").ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, HE, HS, TE, TS from Horarios where IdUsu=" & id_emple

                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(0).ToString = True Then descansos += 1
                        If rd1(1).ToString = True Then descansos += 1
                        If rd1(2).ToString = True Then descansos += 1
                        If rd1(3).ToString = True Then descansos += 1
                        If rd1(4).ToString = True Then descansos += 1
                        If rd1(5).ToString = True Then descansos += 1
                        If rd1(6).ToString = True Then descansos += 1
                        hora_entrada = rd1(7).ToString
                        hora_salida = rd1(8).ToString
                        tolerancia_ent = rd1(9).ToString
                        tolerancia_sal = rd1(10).ToString
                    End If
                Else
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Estatus,Hora,Fecha from Asistencia where Nombre='" & cbofiltro.Text & "' and Fecha>='" & Format(Month1, "yyyy-MM-dd") & "' and Fecha<='" & Format(Month2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader

                Do While rd1.Read
                    Dim diferencia As String = ""
                    Dim max_hora As String = ""
                    Dim que_pato As String = ""
                    If rd1("Estatus").ToString = "Entrada" Then
                        If hora_entrada <> "" Then
                            diferencia = DateDiff(DateInterval.Minute, CDate(hora_entrada), CDate(rd1("Hora").ToString))
                            max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_ent), CDate(hora_entrada))
                            If CDate(rd1("Hora").ToString) > CDate(max_hora) Then
                                que_pato = "No"
                            Else
                                que_pato = "Sí"
                            End If
                        End If
                    Else
                        If hora_salida <> "" Then
                            diferencia = DateDiff(DateInterval.Minute, CDate(hora_salida), CDate(rd1("Hora").ToString))
                            max_hora = DateAdd(DateInterval.Minute, CDbl(tolerancia_sal), CDate(hora_salida))
                            If CDate(rd1("Hora").ToString) > CDate(max_hora) Then
                                que_pato = "No"
                            Else
                                que_pato = "Sí"
                            End If
                        End If
                    End If
                    grdCaptura.Rows.Add(puesto, area, rd1("Estatus").ToString(), FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate), rd1("Hora").ToString, diferencia, que_pato, descansos)
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        optTodos.Checked = True
        cbofiltro.Items.Clear()
        cbofiltro.Text = ""
        cbofiltro.Visible = False
        grdCaptura.Rows.Clear()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        'If grdCaptura.Rows.Count = 0 Then Exit Sub
        'If MsgBox("¿Deseas exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios") = vbOK Then
        '     Dim exApp As New Microsoft.Office.Interop.Excel.Application
        '     Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        '     Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        '     barExportar.Value = 0
        '     barExportar.Visible = True
        '     barExportar.Maximum = grdCaptura.Rows.Count
        '     barExportar.Minimum = 0

        '     Try
        '          'Añadimos el Libro al programa, y la hoja al libro
        '          exLibro = exApp.Workbooks.Add
        '          exHoja = exLibro.Worksheets.Application.ActiveSheet

        '          Dim Fila As Integer = 0
        '          Dim Col As Integer = 0

        '          ' ¿Cuantas columnas y cuantas filas?
        '          Dim NCol As Integer = grdCaptura.ColumnCount
        '          Dim NRow As Integer = grdCaptura.RowCount

        '          'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
        '          For i As Integer = 1 To NCol
        '               exHoja.Cells.Item(1, i) = grdCaptura.Columns(i - 1).HeaderText.ToString
        '               'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
        '          Next

        '          For Fila = 0 To NRow - 1
        '               For Col = 0 To NCol - 1
        '                    exHoja.Cells.Item(Fila + 2, Col + 1) = grdCaptura.Rows(Fila).Cells(Col).Value.ToString
        '               Next
        '               My.Application.DoEvents()
        '               barExportar.Value = barExportar.Value + 1
        '          Next

        '          Dim Fila2 As Integer = Fila + 2
        '          Dim Col2 As Integer = Col

        '          'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
        '          exHoja.Rows.Item(1).Font.Bold = 1
        '          exHoja.Rows.Item(1).HorizontalAlignment = 3
        '          exHoja.Columns.AutoFit()

        '          'Aplicación visible
        '          exApp.Application.Visible = True

        '          exHoja = Nothing
        '          exLibro = Nothing
        '          exApp = Nothing

        '          MsgBox("Reporte exportado de manera correcta.", vbInformation + vbOKOnly, "Delsscom Control Negoicos")

        '     Catch ex As Exception
        '          MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
        '     End Try

        '     barExportar.Value = 0
        '     barExportar.Visible = False
        'End If
    End Sub

    Private Sub cbofiltro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbofiltro.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
End Class