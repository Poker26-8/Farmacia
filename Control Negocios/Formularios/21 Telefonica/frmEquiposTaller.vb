Public Class frmEquiposTaller
    Private Sub frmEquiposTaller_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbTodos.Checked = True
    End Sub

    Private Sub rbOrden_Click(sender As Object, e As EventArgs) Handles rbOrden.Click
        If (rbOrden.Checked) Then

            rbCliente.Checked = False
            rbtecnico.Checked = False
            rbtarea.Checked = False

            grdCaptura.Rows.Clear()
            cboOpciones.Visible = True
        End If
    End Sub

    Private Sub rbCliente_Click(sender As Object, e As EventArgs) Handles rbCliente.Click
        If (rbCliente.Checked) Then

            rbOrden.Checked = False
            rbtecnico.Checked = False
            rbtarea.Checked = False

            grdCaptura.Rows.Clear()
            cboOpciones.Visible = True
            cboOpciones.Text = ""
        End If
    End Sub

    Private Sub cboOpciones_DropDown(sender As Object, e As EventArgs) Handles cboOpciones.DropDown
        Try

            cboOpciones.Items.Clear()


            If (rbTodos.Checked) Then
                cboOpciones.Visible = False
                rbOrden.Checked = False
                rbCliente.Checked = False

            Else
                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand

                If (rbOrden.Checked) Then
                    cmd5.CommandText = "SELECT DISTINCT SerieD FROM tallerd"
                End If

                If (rbCliente.Checked) Then
                    cmd5.CommandText = "SELECT DISTINCT Cliente FROM tallerd"
                End If

                If (rbtecnico.Checked) Then
                    cmd5.CommandText = "SELECT DISTINCT Tecnico FROM tallerd"
                End If

                If (rbtarea.Checked) Then
                    cmd5.CommandText = "SELECT DISTINCT Operacion FROM tallerd"
                End If

                rd5 = cmd5.ExecuteReader
                Do While rd5.Read
                    If rd5.HasRows Then
                        cboOpciones.Items.Add(rd5(0).ToString)
                    End If
                Loop
                rd5.Close()
                cnn5.Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboOpciones_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboOpciones.SelectedValueChanged
        Try
            grdCaptura.Rows.Clear()

            If (rbTodos.Checked) Then
            Else

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If (rbOrden.Checked) Then
                    cmd1.CommandText = "SELECT Id,Operacion,Cliente,Tecnico,SerieD,FechaEntrada,FechaEstimada,Status FROM tallerd WHERE SerieD='" & cboOpciones.Text & "'"
                End If

                If (rbCliente.Checked) Then
                    cmd1.CommandText = "SELECT Id,Operacion,Cliente,Tecnico,SerieD,FechaEntrada,FechaEstimada,Status FROM tallerd WHERE Cliente='" & cboOpciones.Text & "'"
                End If

                If (rbtecnico.Checked) Then
                    cmd1.CommandText = "SELECT Id,Operacion,Cliente,Tecnico,SerieD,FechaEntrada,FechaEstimada,Status FROM tallerd WHERE Tecnico='" & cboOpciones.Text & "'"
                End If

                If (rbtarea.Checked) Then
                    cmd1.CommandText = "SELECT Id,Operacion,Cliente,Tecnico,SerieD,FechaEntrada,FechaEstimada,Status FROM tallerd WHERE Operacion='" & cboOpciones.Text & "'"
                End If

                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim norden As Integer = rd1("Id").ToString
                        Dim operacion As String = rd1("Operacion").ToString
                        Dim cliente As String = rd1("Cliente").ToString
                        Dim tecnico As String = rd1("Tecnico").ToString
                        Dim tipo As String = ""
                        Dim marca As String = ""
                        Dim modelo As String = ""
                        Dim serie As String = rd1("SerieD").ToString
                        Dim ingreso As Date = rd1("FechaEntrada").ToString
                        Dim salida As Date = rd1("FechaEstimada").ToString
                        Dim status As String = rd1("Status").ToString


                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Tipo,Marca,Modelo FROM dispositivos WHERE Serie='" & serie & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                tipo = rd2("Tipo").ToString
                                marca = rd2("Marca").ToString
                                modelo = rd2("Modelo").ToString
                            End If
                        End If
                        rd2.Close()

                        grdCaptura.Rows.Add(norden, operacion, cliente, tecnico, tipo, marca, modelo, serie, Format(ingreso, "yyyy-MM-dd HH:mm:ss"), Format(salida, "yyyy-MM-dd HH:mm:ss"), status)

                        For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                            Dim operacione As String = grdCaptura.Rows(luffy).Cells(1).Value.ToString
                            Dim situacion As String = grdCaptura.Rows(luffy).Cells(10).Value.ToString

                            If operacione = "Reparacion" Then
                                grdCaptura.Rows(luffy).Cells(1).Style.BackColor = Color.FromArgb(1, 100, 156)
                            ElseIf operacione = "Revision Preventiva" Then
                                grdCaptura.Rows(luffy).Cells(1).Style.BackColor = Color.FromArgb(205, 204, 4)
                            End If

                            If situacion = "En reparacion" Then
                                grdCaptura.Rows(luffy).Cells(10).Style.BackColor = Color.FromArgb(204, 0, 205)
                            ElseIf situacion = "Equipo recibido" Then
                                grdCaptura.Rows(luffy).Cells(10).Style.BackColor = Color.FromArgb(0, 152, 205)
                            ElseIf situacion = "Equipo reparado" Then
                                grdCaptura.Rows(luffy).Cells(10).Style.BackColor = Color.FromArgb(2, 180, 48)
                            End If
                        Next

                    End If

                Loop
                cnn2.Close()
                rd1.Close()
                cnn1.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        frmTallerT.Show()
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        Try

            grdCaptura.Rows.Clear()
            cboOpciones.Text = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id,Operacion,Cliente,Tecnico,SerieD,FechaEntrada,FechaEstimada,Status FROM tallerd ORDER BY Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim orden As Integer = rd1("Id").ToString
                    Dim tarea As String = rd1("Operacion").ToString
                    Dim cliente As String = rd1("Cliente").ToString
                    Dim tecnico As String = rd1("Tecnico").ToString
                    Dim tipo As String = ""
                    Dim marca As String = ""
                    Dim modelo As String = ""
                    Dim serie = rd1("SerieD").ToString
                    Dim ingreso As Date = rd1("FechaEntrada").ToString
                    Dim salida As Date = rd1("FechaEstimada").ToString
                    Dim status As String = rd1("Status").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Tipo,Marca,Modelo FROM dispositivos WHERE Serie='" & serie & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            tipo = rd2(0).ToString
                            marca = rd2(1).ToString
                            modelo = rd2(2).ToString
                        End If
                    End If
                    rd2.Close()

                    grdCaptura.Rows.Add(orden, tarea, cliente, tecnico, tipo, marca, modelo, serie, ingreso, salida, status)

                    For fresa As Integer = 0 To grdCaptura.Rows.Count - 1

                        Dim operacione As String = grdCaptura.Rows(fresa).Cells(1).Value.ToString
                        Dim situacion As String = grdCaptura.Rows(fresa).Cells(10).Value.ToString

                        If operacione = "Reparacion" Then
                            grdCaptura.Rows(fresa).Cells(1).Style.BackColor = Color.FromArgb(1, 100, 156)
                        ElseIf operacione = "Revision Preventiva" Then
                            grdCaptura.Rows(fresa).Cells(1).Style.BackColor = Color.FromArgb(205, 204, 4)
                        End If

                        If situacion = "En reparacion" Then
                            grdCaptura.Rows(fresa).Cells(10).Style.BackColor = Color.FromArgb(204, 0, 205)
                        ElseIf situacion = "Equipo recibido" Then
                            grdCaptura.Rows(fresa).Cells(10).Style.BackColor = Color.FromArgb(0, 152, 205)
                        ElseIf situacion = "Equipo reparado" Then
                            grdCaptura.Rows(fresa).Cells(10).Style.BackColor = Color.FromArgb(2, 180, 48)
                        End If

                    Next

                End If
            Loop
            cnn2.Close()
            rd1.Close()
            cnn1.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub rbtecnico_Click(sender As Object, e As EventArgs) Handles rbtecnico.Click
        If (rbtecnico.Checked) Then
            rbOrden.Checked = False
            rbCliente.Checked = False
            rbtarea.Checked = False

            grdCaptura.Rows.Clear()
            cboOpciones.Visible = True
            cboOpciones.Text = ""
        End If
    End Sub

    Private Sub rbtarea_Click(sender As Object, e As EventArgs) Handles rbtarea.Click
        If (rbtarea.Checked) Then
            rbOrden.Checked = False
            rbCliente.Checked = False
            rbtecnico.Checked = False

            cboOpciones.Visible = True
            cboOpciones.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class