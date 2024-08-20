Public Class frmControlServicios
    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress
        Dim puesto As String = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            grdPendientes.Rows.Clear()

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias,Puesto from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString()
                        puesto = rd1("Puesto").ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id,Nombre,Comentario,Termino,Folio from control_servicios where Encargado='" & lblusuario.Text & "' and Status=0 order by Termino ASC"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdPendientes.Rows.Add(rd1("Id").ToString(), rd1("Nombre").ToString(), rd1("Comentario").ToString(), FormatDateTime(rd1("Termino").ToString(), DateFormat.ShortDate), rd1("Folio").ToString)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If grdPendientes.Rows.Count > 0 Then
                For t As Integer = 0 To grdPendientes.Rows.Count - 1
                    Dim fecha As Date = grdPendientes.Rows(t).Cells(3).Value

                    If CDate(Date.Now) > fecha Then
                        grdPendientes.Rows(t).DefaultCellStyle.BackColor = Color.Red
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lblusuario.Text = ""
        txtusuario.Text = ""
        grdPendientes.Rows.Clear()
        limpia_1()
        txtcomentarioventa.Text = ""
        txtusuario.Focus().Equals(True)
    End Sub

    Private Sub grdPendientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPendientes.CellDoubleClick
        Dim index As Integer = grdPendientes.CurrentRow.Index
        Dim id As Integer = grdPendientes.Rows(index).Cells(0).Value.ToString()

        Dim status As Integer = 0

        limpia_1()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,Nombre,Comentario,Inicio,Termino,ComentarioVen from control_servicios where Id=" & id & " and Status=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtid.Text = id
                    txtcodigo.Text = rd1("Codigo").ToString()
                    txtnombre.Text = rd1("Nombre").ToString()
                    txtproceso.Text = rd1("Comentario").ToString()
                    dtpInicio.Text = FormatDateTime(rd1("Inicio").ToString(), DateFormat.ShortDate)
                    dtptermino.Text = FormatDateTime(rd1("Termino").ToString(), DateFormat.ShortDate)
                    txtcomentarioventa.Text = rd1("ComentarioVen").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            muestra_detalle()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub limpia_1()
        txtcodigo.Text = ""
        txtnombre.Text = ""
        txtproceso.Text = ""
        dtpInicio.Text = ""
        dtptermino.Text = ""
        grdFin.Rows.Clear()
        cboproceso.Text = ""
        dtpf_proceso.Value = Date.Now
        txtn_proceso.Text = ""
        txtfecha_p.Text = ""
        txtcomentario.Text = ""
        Button3.Visible = False
    End Sub

    Private Sub cboproceso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboproceso.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpf_proceso.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpf_proceso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpf_proceso.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim fecha_1 As Date = dtptermino.Text
            Dim fecha_2 As Date = dtpf_proceso.Value

            If fecha_2 > fecha_1 Then
                MsgBox("La fecha seleccionada es mayor a la fecha de entrega programada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            End If
            btnfin.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnfin_Click(sender As Object, e As EventArgs) Handles btnfin.Click
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "insert into control_servicios_det(Id_cs,Proceso,Entrega,Status,Comentario) values(" & txtid.Text & ",'" & cboproceso.Text & "','" & Format(dtpf_proceso.Value, "yyyy-MM-dd") & "',0,'')"
            If cmd2.ExecuteNonQuery Then
                MsgBox("Proceso registrado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cboproceso.Text = ""
                dtpf_proceso.Value = Date.Now
                cboproceso.Focus().Equals(True)
                muestra_detalle()
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "update control_servicios set Status=0 where Id=" & txtid.Text
            cmd2.ExecuteNonQuery()

            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub muestra_detalle()
        grdFin.Rows.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id,Proceso,Entrega from control_servicios_det where Id_cs=" & txtid.Text & " and Status=0 order by Entrega ASC"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdFin.Rows.Add(rd1("Id").ToString(), rd1("Proceso").ToString(), FormatDateTime(rd1("Entrega").ToString, DateFormat.ShortDate))
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If grdFin.Rows.Count = 0 Then Button3.Visible = True Else Button3.Visible = False
    End Sub

    Private Sub grdFin_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFin.CellDoubleClick
        Dim index As Integer = grdFin.CurrentRow.Index
        Dim id As Integer = grdFin.Rows(index).Cells(0).Value.ToString()

        txt_id.Text = id
        txtn_proceso.Text = grdFin.Rows(index).Cells(1).Value.ToString()
        txtfecha_p.Text = FormatDateTime(grdFin.Rows(index).Cells(2).Value.ToString())
        txtcomentario.Focus().Equals(True)
    End Sub

    Private Sub txtcomentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcomentario.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Button1.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("¿Deseas concluir el proceso?" & vbNewLine & "Ésta acción no se puede deshacer.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update control_servicios_det set Status=1, Comentario='" & txtcomentario.Text & "', Entregado='" & Format(Date.Now, "yyyy-MM-dd") & "' where Id=" & txt_id.Text
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Proceso concluido correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    limpia_2()
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub
    Private Sub limpia_2()
        txtn_proceso.Text = ""
        txtfecha_p.Text = ""
        txtcomentario.Text = ""
        muestra_detalle()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("¿Deseas dar por terminado este servicio?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update control_servicios set Status=1, Entregado='" & Format(Date.Now, "yyyy-MM-dd") & "' where Id=" & txtid.Text
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Servicio concluido correctemanete.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Button2.PerformClick()
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub frmControlServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class