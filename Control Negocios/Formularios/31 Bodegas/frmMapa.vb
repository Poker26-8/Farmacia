Imports System.Security

Public Class frmMapa

    Friend WithEvents btnbodega As System.Windows.Forms.Button
    Friend WithEvents btnplanta As System.Windows.Forms.Button

    Public edita As Boolean = False
    Dim tim As New Timer()

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        tim.Stop()
        Crea_Plantas()
        tim.Start()
    End Sub

    Private Sub frmMapa_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        tim.Interval = 15000
        AddHandler tim.Tick, AddressOf Timer_Tick
        tim.Start()

        Crea_Plantas()
        primerBoton()

        Dim fecha_hoy As Date = Format(Date.Now, "dd/MM/yyyy")
        Dim fecha1 As Date = Format(DateAdd(DateInterval.Day, 1, fecha_hoy), "dd/MM/yyyy")
        Dim fecha2 As Date = Format(DateAdd(DateInterval.Day, 2, fecha_hoy), "dd/MM/yyyy")
        Dim fecha3 As Date = Format(DateAdd(DateInterval.Day, 3, fecha_hoy), "dd/MM/yyyy")
        Dim fecha4 As Date = Format(DateAdd(DateInterval.Day, 4, fecha_hoy), "dd/MM/yyyy")
        Dim fecha5 As Date = Format(DateAdd(DateInterval.Day, 5, fecha_hoy), "dd/MM/yyyy")
        Dim fecha_pago As Date = Nothing
        Dim estado As Boolean = False

        Dim bodega As String = "", ubicacion As String = "", cliente As String = ""


        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT Nombre,Ubicacion,Cliente,Estado,Siguiente FROM Bodegas"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    bodega = rd1("Nombre").ToString
                    ubicacion = rd1("Ubicacion").ToString
                    cliente = rd1("Cliente").ToString
                    estado = rd1("Estado").ToString
                    If (estado) Then
                        fecha_pago = rd1("Siguiente").ToString
                        fecha_pago = FormatDateTime(fecha_pago, DateFormat.ShortDate)

                        If fecha_hoy >= fecha_pago Then
                            MsgBox("Está pendiente el pago de la bodega " & bodega & " ubicada en " & ubicacion & "" & vbNewLine & "a nombre de " & cliente & ".")
                        ElseIf fecha1 = fecha_pago Then
                            MsgBox("Mañana vence la renta de la bodega " & bodega & " ubicada en " & ubicacion & "" & vbNewLine & "a nombre de " & cliente & ".")
                        ElseIf fecha2 = fecha_pago Then
                            MsgBox("En dos días vence la renta de la bodega " & bodega & " ubicada en " & ubicacion & "" & vbNewLine & "a nombre de " & cliente & ".")
                        ElseIf fecha3 = fecha_pago Then
                            MsgBox("En tres días vence la renta de la bodega " & bodega & " ubicada en " & ubicacion & "" & vbNewLine & "a nombre de " & cliente & ".")
                        ElseIf fecha4 = fecha_pago Then
                            MsgBox("En cuatro días vence la renta de la bodega " & bodega & " ubicada en " & ubicacion & "" & vbNewLine & "a nombre de " & cliente & ".")
                        ElseIf fecha5 = fecha_pago Then
                            MsgBox("En cinco días vence la renta de la bodega " & bodega & " ubicada en " & ubicacion & "" & vbNewLine & "a nombre de " & cliente & ".")
                        End If
                    End If
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub primerBoton()
        For Each control As Control In pUbicaciones.Controls
            If TypeOf control Is Button Then
                DirectCast(control, Button).PerformClick()
                Exit For
            End If
        Next
    End Sub

    Public Sub Crea_Plantas()
        Dim plantas As Integer = 0
        Try
            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT DISTINCT Ubicacion FROM bodegas WHERE Ubicacion<>''"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then
                    btnplanta = New Button
                    btnplanta.Height = pUbicaciones.Height
                    btnplanta.Width = pUbicaciones.Width / 4
                    btnplanta.Text = rd4(0).ToString
                    btnplanta.Name = "btnplanta(" & plantas & ")"
                    btnplanta.Tag = rd4(0).ToString
                    btnplanta.FlatStyle = FlatStyle.Flat
                    btnplanta.FlatAppearance.BorderSize = 0
                    btnplanta.Font = New Font("Segoe UI", 9.5, FontStyle.Bold)
                    btnplanta.FlatAppearance.MouseOverBackColor = Color.Salmon

                    If plantas = 0 Then
                        btnplanta.Top = 0
                        btnplanta.Left = 0
                    End If
                    If plantas = 1 Then
                        btnplanta.Top = 0
                        btnplanta.Left = pUbicaciones.Width / 4
                    End If
                    If plantas = 2 Then
                        btnplanta.Top = 0
                        btnplanta.Left = pUbicaciones.Width / 2
                    End If
                    If plantas = 3 Then
                        btnplanta.Top = 0
                        btnplanta.Left = (pUbicaciones.Width / 4) * 3
                    End If
                    If plantas = 4 Then
                        btnplanta.Top = 0
                        btnplanta.Left = 0
                    End If

                    pUbicaciones.Controls.Add(btnplanta)
                    AddHandler btnplanta.Click, AddressOf btnplanta_Click
                    plantas += 1

                End If
            Loop
            rd4.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
    End Sub

    Public Sub btnplanta_Click(sender As Object, e As System.EventArgs)
        pBodegas.Controls.Clear()
        Dim buton As Button = CType(sender, Button)
        Crea_Bodegas(buton.Text)
        Me.Text = buton.Text
        txtbodega.Text = ""
    End Sub

    Public Sub Crea_Bodegas(ByVal planta As String)

        Dim bodegas As Integer = 1
        Dim cuantos As Integer = Math.Truncate(pBodegas.Height / 70)
        Dim estado As Boolean = 0
        Dim orientacion As String = "", dimensiones As String = ""

        Dim fecha_hoy As Date = Format(Date.Now, "dd/MM/yyyy")
        Dim fecha_pago1 As Date = Format(DateAdd(DateInterval.Day, 5, fecha_hoy), "dd/MM/yyyy")
        Dim fecha_pago2 As Date = Format(DateAdd(DateInterval.Day, 4, fecha_hoy), "dd/MM/yyyy")
        Dim fecha_pago3 As Date = Format(DateAdd(DateInterval.Day, 3, fecha_hoy), "dd/MM/yyyy")
        Dim fecha_pago4 As Date = Format(DateAdd(DateInterval.Day, 2, fecha_hoy), "dd/MM/yyyy")
        Dim fecha_pago5 As Date = Format(DateAdd(DateInterval.Day, 1, fecha_hoy), "dd/MM/yyyy")
        Dim fecha_consulta As Date = Nothing

        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Nombre,Id,Estado,Siguiente,Dimensiones FROM bodegas WHERE Ubicacion='" & planta & "' AND Nombre<>'' ORDER BY Nombre"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    btnbodega = New Button
                    btnbodega.Text = rd3("Nombre").ToString
                    btnbodega.Tag = rd3("Id").ToString
                    btnbodega.FlatStyle = FlatStyle.Flat
                    btnbodega.FlatAppearance.BorderSize = 0
                    btnbodega.Name = "btnBodega(" & bodegas & ")"
                    btnbodega.TextAlign = ContentAlignment.MiddleCenter
                    btnbodega.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                    estado = rd3("Estado").ToString
                    If (estado) Then
                        fecha_consulta = rd3("Siguiente").ToString
                        fecha_consulta = FormatDateTime(fecha_consulta, DateFormat.ShortDate)
                    End If
                    dimensiones = rd3("Dimensiones").ToString
                    btnbodega.Width = 90
                    btnbodega.Height = 70

                    If (estado) Then
                        If fecha_pago1 = fecha_consulta Then
                            btnbodega.BackColor = Color.NavajoWhite
                        ElseIf fecha_pago2 = fecha_consulta Then
                            btnbodega.BackColor = Color.NavajoWhite
                        ElseIf fecha_pago3 = fecha_consulta Then
                            btnbodega.BackColor = Color.NavajoWhite
                        ElseIf fecha_pago4 = fecha_consulta Then
                            btnbodega.BackColor = Color.NavajoWhite
                        ElseIf fecha_pago5 = fecha_consulta Then
                            btnbodega.BackColor = Color.NavajoWhite
                        ElseIf fecha_hoy >= fecha_consulta Then
                            btnbodega.BackColor = Color.LightCoral
                        Else
                            btnbodega.BackColor = Color.LightGreen
                        End If
                    Else
                        btnbodega.BackColor = Color.White
                    End If

                    If bodegas > cuantos And bodegas < ((cuantos * 2) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 1)
                        btnbodega.Top = (bodegas - (cuantos + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 2) And bodegas < ((cuantos * 3) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 2)
                        btnbodega.Top = (bodegas - ((cuantos * 2) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 3) And bodegas < ((cuantos * 4) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 3)
                        btnbodega.Top = (bodegas - ((cuantos * 3) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 4) And bodegas < ((cuantos * 5) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 4)
                        btnbodega.Top = (bodegas - ((cuantos * 4) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 5) And bodegas < ((cuantos * 6) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 5)
                        btnbodega.Top = (bodegas - ((cuantos * 5) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 6) And bodegas < ((cuantos * 7) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 6)
                        btnbodega.Top = (bodegas - ((cuantos * 6) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 7) And bodegas < ((cuantos * 8) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 7)
                        btnbodega.Top = (bodegas - ((cuantos * 7) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 8) And bodegas < ((cuantos * 9) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 8)
                        btnbodega.Top = (bodegas - ((cuantos * 8) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 9) And bodegas < ((cuantos * 10) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 9)
                        btnbodega.Top = (bodegas - ((cuantos * 9) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 10) And bodegas < ((cuantos * 11) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 10)
                        btnbodega.Top = (bodegas - ((cuantos * 10) + 1)) * (btnbodega.Height)

                    ElseIf bodegas > (cuantos * 11) And bodegas < ((cuantos * 12) + 1) Then
                        btnbodega.Left = (btnbodega.Width * 11)
                        btnbodega.Top = (bodegas - ((cuantos * 11) + 1)) * (btnbodega.Height)

                    Else
                        btnbodega.Left = 0
                        btnbodega.Top = (bodegas - 1) * (btnbodega.Height)
                    End If

                    pBodegas.Controls.Add(btnbodega)
                    AddHandler btnbodega.Click, AddressOf btnbodega_Click
                    bodegas = CDec(bodegas) + 1

                End If
            Loop
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Public Sub btnbodega_Click(sender As Object, e As EventArgs)
        If btnHabilitar.Text = "Guardar cambios" Then
        Else
            Dim bode As Button = CType(sender, Button)
            Dim id As Integer = bode.Tag
            Dim nombre As String = bode.Text
            Dim estado As Boolean = False
            Dim tamaño As String = ""

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id,Estado,Dimensiones from Bodegas where Nombre='" & nombre & "' and Ubicacion='" & Me.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id = rd1("Id").ToString
                        estado = rd1("Estado").ToString
                        tamaño = rd1("Dimensiones").ToString
                    End If
                End If
                rd1.Close()

                If (estado) Then
                    'Ya está ocupada y se va a consultar o cobrar
                    txtbodega.Text = bode.Text
                Else
                    'Se va a registrar una nueva entrada
                    If MsgBox("¿Deseas iniciar la renta de esta bodega?", vbInformation + vbOKCancel, "Delsscom Control Negocios") = vbOK Then
                        btnReporte.Enabled = False
                        btnconsulta.Enabled = False
                        frmRegistroBodega.Label1.Text = "RENTA DE BODEGA " & nombre & " EN " & Me.Text
                        frmRegistroBodega.lblbodega.Text = nombre
                        frmRegistroBodega.lbltamaño.Text = tamaño
                        frmRegistroBodega.lblubicacion.Text = Me.Text
                        frmRegistroBodega.Show()
                    End If
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnnueva_Click(sender As Object, e As EventArgs) Handles btnnueva.Click
        pAgregarMesa.Visible = True
        If Me.Text <> "Mapa" Then
            cboplantas.Text = Me.Text
            cboplantas.Focus.Equals(True)
        Else
            cboplantas.Focus.Equals(True)
        End If

    End Sub

    Private Sub btnAddBodega_Click(sender As Object, e As EventArgs) Handles btnAddBodega.Click
        Try

            If cboplantas.Text = "" Then MsgBox("Seleccione una planta.", vbInformation + vbOKOnly, titulocentral) : cboplantas.Focus.Equals(True) : Exit Sub
            If txtNombre.Text = "" Then MsgBox("Ingrese el nombre de la bodega.", vbInformation + vbOKOnly, titulocentral) : txtNombre.Focus.Equals(True) : Exit Sub
            If cbopersonas.Text = "" Then MsgBox("Ingrese la medida de la bodega.", vbInformation + vbOKOnly, titulocentral) : cbopersonas.Focus.Equals(True) : Exit Sub

            pBodegas.Controls.Clear()
            Me.Text = cboplantas.Text
            Crea_Bodegas(cboplantas.Text)

            Dim query As String = ""
            Dim idbodega As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre FROM bodegas WHERE Nombre='" & txtNombre.Text & "' AND Ubicacion='" & cboplantas.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("Ya cuentas con una bodega registrada en ésta ubicación, cambia de ubicación o el nombre de la bodega.", vbInformation + vbOKOnly, titulocentral)
                    txtNombre.SelectionStart = 0
                    txtNombre.SelectionLength = Len(txtNombre.Text)
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO bodegas(Nombre,Ubicacion,Estado,Precio,Dimensiones) VALUES('" & txtNombre.Text & "','" & cboplantas.Text & "',0,0,'" & cbopersonas.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Bodega agregada correctamente")
                    cnn2.Close()
                End If

                'query = "SELECT MAX(Id) from bodegas"
            End If
            rd1.Close()
            cnn1.Close()

            Crea_Plantas()
            Crea_Bodegas(cboplantas.Text)
            cbopersonas.Text = ""
            txtNombre.Text = ""
            txtNombre.Focus.Equals(True)

            'If query <> "" Then
            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText = query
            '    rd1 = cmd1.ExecuteReader
            '    If rd1.HasRows Then
            '        If rd1.Read Then
            '            idbodega = IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + 1
            '        Else
            '            idbodega = 1
            '        End If
            '    Else
            '        idbodega = 1
            '    End If
            '    rd1.Close()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboplantas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboplantas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNombre.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbopersonas.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbopersonas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbopersonas.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAddBodega.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnHabilitar_Click(sender As Object, e As EventArgs) Handles btnHabilitar.Click
        If edita = False Then
            If pAgregarMesa.Controls.Count = 0 Then
            Else
                If Me.Text = "Mapa" Then MsgBox("Necesitas seleccionar una planta para agregar la bodega.", vbInformation + vbOKOnly, titulocentral) : edita = False : Exit Sub
            End If
            edita = True
            btnHabilitar.Text = "Guardar cambios"
            btnconsulta.Visible = False
            btnReporte.Visible = False
            btnnueva.Visible = True
        Else
            edita = False
            pAgregarMesa.Visible = False
            cboplantas.Text = ""
            cbopersonas.Text = ""
            txtNombre.Text = ""
            btnHabilitar.Text = "Habilitar edición"
            btnconsulta.Visible = True
            btnReporte.Visible = True
            btnnueva.Visible = False
        End If
    End Sub


End Class