Public Class frmReporte_CS
    Private Sub opttotales_Click(sender As Object, e As EventArgs) Handles opttotales.Click
        If (opttotales.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False

            grdcaptura.ColumnCount = 7
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Nombre"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Fecha de inicio"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha de entrega"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Descripción"
                    .Width = 240
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Encargado"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Id"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = False
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
        End If
    End Sub

    Private Sub opttotalesdet_Click(sender As Object, e As EventArgs) Handles opttotalesdet.Click
        If (opttotalesdet.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True

            grdcaptura.ColumnCount = 6
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Nombre"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Fecha de inicio"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha de entrega"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Descripción"
                    .Width = 240
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Id"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = False
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
        End If
    End Sub

    Private Sub optcliente_Click(sender As Object, e As EventArgs) Handles optcliente.Click
        If (optcliente.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = False

            grdcaptura.ColumnCount = 8
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Nombre"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Fecha de inicio"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha de entrega"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Descripción"
                    .Width = 240
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Encargado"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Fecha entregado"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Id"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = False
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
        End If
    End Sub

    Private Sub optclientedet_Click(sender As Object, e As EventArgs) Handles optclientedet.Click
        If (optclientedet.Checked) Then
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Items.Clear()
            ComboBox1.Text = ""
            ComboBox1.Visible = True

            grdcaptura.ColumnCount = 7
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Nombre"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Fecha de inicio"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Fecha de entrega"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Descripción"
                    .Width = 240
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Fecha entregado"
                    .Width = 100
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Id"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = False
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            Exportar.Enabled = False
        End If
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString

        ComboBox1.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Encargado from control_servicios where Termino between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    ComboBox1.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString

        grdcaptura.Rows.Clear()

        If (opttotales.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Folio,Nombre,Inicio,Termino,Comentario,Encargado,Id from control_servicios where Status=0 and Termino between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Termino"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdcaptura.Rows.Add(rd1("Folio").ToString(), rd1("Nombre").ToString(), FormatDateTime(rd1("Inicio").ToString, DateFormat.ShortDate), FormatDateTime(rd1("Termino").ToString, DateFormat.ShortDate), rd1("Comentario").ToString(), rd1("Encargado").ToString(), rd1("Id").ToString())
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

        If (opttotalesdet.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un encargado para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Folio,Nombre,Inicio,Termino,Comentario,Id from control_servicios where Status=0 and Encargado='" & ComboBox1.Text & "' and Termino between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Termino"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdcaptura.Rows.Add(rd1("Folio").ToString(), rd1("Nombre").ToString(), FormatDateTime(rd1("Inicio").ToString, DateFormat.ShortDate), FormatDateTime(rd1("Termino").ToString, DateFormat.ShortDate), rd1("Comentario").ToString(), rd1("Id").ToString())
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

        If (optcliente.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Folio,Nombre,Inicio,Termino,Comentario,Encargado,Entregado,Id from control_servicios where Status=1 and Entregado between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Termino"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdcaptura.Rows.Add(rd1("Folio").ToString(), rd1("Nombre").ToString(), FormatDateTime(rd1("Inicio").ToString, DateFormat.ShortDate), FormatDateTime(rd1("Termino").ToString, DateFormat.ShortDate), rd1("Comentario").ToString(), rd1("Encargado").ToString(), rd1("Entregado").ToString(), rd1("Id").ToString())
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

        If (optclientedet.Checked) Then
            If ComboBox1.Text = "" Then MsgBox("Selecciona un encargado para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : ComboBox1.Focus().Equals(True) : Exit Sub

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Folio,Nombre,Inicio,Termino,Comentario,Entregado,Id from control_servicios where Status=1 and Encargado='" & ComboBox1.Text & "' and Entregado between '" & Format(M1, "yyyy-MM-dd") & "' and '" & Format(M2, "yyyy-MM-dd") & "' order by Termino"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdcaptura.Rows.Add(rd1("Folio").ToString(), rd1("Nombre").ToString(), FormatDateTime(rd1("Inicio").ToString, DateFormat.ShortDate), FormatDateTime(rd1("Termino").ToString, DateFormat.ShortDate), rd1("Comentario").ToString(), rd1("Entregado").ToString(), rd1("Id").ToString())
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

        If grdcaptura.Rows.Count > 0 Then Exportar.Enabled = True
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index
        Dim id As Integer = 0

        If grdcaptura.Rows.Count > 0 Then
            If (opttotales.Checked) Then
                id = grdcaptura.Rows(index).Cells(6).Value.ToString()
            End If
            If (opttotalesdet.Checked) Then
                id = grdcaptura.Rows(index).Cells(5).Value.ToString()
            End If
            If (optcliente.Checked) Then
                id = grdcaptura.Rows(index).Cells(7).Value.ToString()
            End If
            If (optclientedet.Checked) Then
                id = grdcaptura.Rows(index).Cells(6).Value.ToString()
            End If

            pProcesos.Visible = True
            grdpendientes.Rows.Clear()
            grdconcluidos.Rows.Clear()

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Proceso,Status,Entrega,Comentario,Entregado from control_servicios_det where Id_cs=" & id
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim procesos As String = rd1("Proceso").ToString()
                        Dim status As Integer = rd1("Status").ToString()
                        Dim fecha_entrega As Date = rd1("Entrega").ToString()
                        Dim comen As String = rd1("Comentario").ToString

                        If status = 0 Then
                            grdpendientes.Rows.Add(procesos, FormatDateTime(fecha_entrega, DateFormat.ShortDate))
                        Else
                            grdconcluidos.Rows.Add(procesos, FormatDateTime(fecha_entrega, DateFormat.ShortDate), FormatDateTime(rd1("Entregado").ToString, DateFormat.ShortDate), comen)
                        End If
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pProcesos.Visible = False
        grdpendientes.Rows.Clear()
        grdconcluidos.Rows.Clear()
    End Sub

    Private Sub Exportar_Click(sender As Object, e As EventArgs) Handles Exportar.Click

    End Sub

    Private Sub frmReporte_CS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class