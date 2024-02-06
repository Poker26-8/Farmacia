Imports System.Net
Imports System.IO

Public Class frmComprasTouch
    Public CantidadProd As Integer = 0
    Public CodigoProducto As String = ""
    Public cantidad As Double = 0

    Dim TotDeptos As Integer = 0
    Dim TotGrupos As Integer = 0
    Dim TotProductos As Integer = 0

    Public Proveedor As String = ""
    Public Id_Provee As Integer = 0

    Dim MYFOLIO As Integer = 0

    Friend WithEvents btnDepto, btnGrupo, btnProd As System.Windows.Forms.Button

    Private Sub tFecha_Tick(sender As Object, e As EventArgs) Handles tFecha.Tick
        lblfecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
    End Sub

    Public Sub Folio()
        Try
            cnn9.Close() : cnn9.Open()

            cmd9 = cnn9.CreateCommand
            cmd9.CommandText =
                "select MAX(Id) from Compras"
            rd9 = cmd9.ExecuteReader
            If rd9.HasRows Then
                If rd9.Read Then
                    lblFolio.Text = IIf(rd9(0).ToString() = "", 0, rd9(0).ToString()) + 1
                Else
                    lblFolio.Text = "1"
                End If
            Else
                lblFolio.Text = "1"
            End If
            rd9.Close()
            cnn9.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn9.Close()
        End Try
    End Sub

    Private Sub frmComprasTouch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If File.Exists(My.Application.Info.DirectoryPath & "\Fondo.jpg") Then
            pProductos.BackgroundImage = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\Fondo.jpg")
        End If

        tFecha.Start()
        tFolio.Start()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Departamento from Productos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then TotDeptos = TotDeptos + 1
            Loop
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Alias from Usuarios where IdEmpleado=" & id_usu_log
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblatiende.Text = rd1(0).ToString
                End If
            End If

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        lblid_prov.Text = "0"

        pDeptos.Controls.Clear()
        pGrupos.Controls.Clear()
        pProductos.Controls.Clear()
        Departamentos()
    End Sub

    Private Sub Departamentos()
        Dim deptos As Integer = 0
        Try
            If TotDeptos <= 10 Then
                pDeptos.AutoScroll = False
            Else
                pDeptos.AutoScroll = True
            End If
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Departamento from Productos order by Departamento asc"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim departamento As String = rd1(0).ToString
                    btnDepto = New Button
                    btnDepto.Text = departamento
                    btnDepto.Name = "btnDepto(" & deptos & ")"
                    btnDepto.Left = 0
                    btnDepto.Height = 55
                    If TotDeptos <= 10 Then
                        btnDepto.Width = pDeptos.Width
                    Else
                        btnDepto.Width = pDeptos.Width - 17
                    End If
                    btnDepto.Top = (deptos) * (btnDepto.Height + 0.5)
                    btnDepto.BackColor = pDeptos.BackColor
                    btnDepto.FlatStyle = FlatStyle.Flat
                    btnDepto.FlatAppearance.BorderSize = 0
                    AddHandler btnDepto.Click, AddressOf btnDepto_Click
                    pDeptos.Controls.Add(btnDepto)
                    If deptos = 0 Then
                        Grupos(departamento)
                    End If
                    deptos += 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnDepto_Click(sender As Object, e As EventArgs)
        Dim btnDepartamento As Button = CType(sender, Button)
        btnDepartamento.Font.Bold.Equals(True)
        pGrupos.Controls.Clear()
        pProductos.Controls.Clear()
        If cnn2.State = 1 Then
            cnn2.Close()
        End If
        CantidadProd = 0
        Grupos(btnDepartamento.Text)
    End Sub

    Private Sub Grupos(ByVal depto As String)
        Dim grupos As Integer = 0
        TotGrupos = 0
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select distinct Grupo from Productos where Departamento='" & depto & "' AND Grupo<>'INSUMO' order by Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then TotGrupos = TotGrupos + 1
            Loop
            rd2.Close()

            If TotGrupos <= 10 Then
                pGrupos.AutoScroll = False
            Else
                pGrupos.AutoScroll = True
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select distinct Grupo from Productos where Departamento='" & depto & "' AND Grupo<>'INSUMO' order by Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    Dim grupo As String = rd2(0).ToString
                    btnGrupo = New Button
                    btnGrupo.Text = grupo
                    btnGrupo.Tag = depto
                    btnGrupo.Name = "btnGrupo(" & grupos & ")"
                    btnGrupo.Height = 55
                    btnGrupo.Left = 0
                    If TotGrupos <= 10 Then
                        btnGrupo.Width = pGrupos.Width
                    Else
                        btnGrupo.Width = pGrupos.Width - 17
                    End If
                    btnGrupo.Top = grupos * (btnGrupo.Height + 0.5)
                    btnGrupo.BackColor = pGrupos.BackColor
                    btnGrupo.FlatStyle = FlatStyle.Flat
                    btnGrupo.FlatAppearance.BorderSize = 0
                    AddHandler btnGrupo.Click, AddressOf btnGrupo_Click
                    pGrupos.Controls.Add(btnGrupo)
                    If grupos = 0 Then
                        Productos(depto, grupo)
                    End If
                    grupos += 1
                End If
            Loop
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub btnGrupo_Click(sender As Object, e As EventArgs)
        Dim btnGrupos As Button = CType(sender, Button)
        pProductos.Controls.Clear()
        If cnn3.State = 1 Then
            cnn3.Close()
        End If
        CantidadProd = 0
        Productos(btnGrupos.Tag, btnGrupos.Text)
    End Sub

    Private Sub Productos(ByVal depto As String, ByVal grupo As String)
        Dim prods As Integer = 1
        Dim cuantos As Integer = Math.Truncate(pProductos.Height / 70)

        Try
            cnn3.Close()
            cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Nombre,Codigo from Productos where Departamento='" & depto & "' and Grupo='" & grupo & "' order by Nombre,Codigo"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    Dim producto As String = rd3(0).ToString
                    btnProd = New Button
                    btnProd.Text = producto
                    btnProd.Tag = rd3(1).ToString
                    btnProd.Name = "btnProducto(" & prods & ")"
                    btnProd.Height = 70
                    btnProd.Width = 130

                    If prods > cuantos And prods < ((cuantos * 2) + 1) Then
                        btnProd.Left = (btnProd.Width * 1)
                        btnProd.Top = (prods - (cuantos + 1)) * (btnProd.Height + 0.5)
                        '2
                    ElseIf prods > (cuantos * 2) And prods < ((cuantos * 3) + 1) Then
                        btnProd.Left = (btnProd.Width * 2)
                        btnProd.Top = (prods - ((cuantos * 2) + 1)) * (btnProd.Height + 0.5)
                        '3
                    ElseIf prods > (cuantos * 3) And prods < ((cuantos * 4) + 1) Then
                        btnProd.Left = (btnProd.Width * 3)
                        btnProd.Top = (prods - ((cuantos * 3) + 1)) * (btnProd.Height + 0.5)
                        '4
                    ElseIf prods > (cuantos * 4) And prods < ((cuantos * 5) + 1) Then
                        btnProd.Left = (btnProd.Width * 4)
                        btnProd.Top = (prods - ((cuantos * 4) + 1)) * (btnProd.Height + 0.5)
                        '5
                    ElseIf prods > (cuantos * 5) And prods < ((cuantos * 6) + 1) Then
                        btnProd.Left = (btnProd.Width * 5)
                        btnProd.Top = (prods - ((cuantos * 5) + 1)) * (btnProd.Height + 0.5)
                        '6
                    ElseIf prods > (cuantos * 6) And prods < ((cuantos * 7) + 1) Then
                        btnProd.Left = (btnProd.Width * 6)
                        btnProd.Top = (prods - ((cuantos * 6) + 1)) * (btnProd.Height + 0.5)
                        '7
                    ElseIf prods > (cuantos * 7) And prods < ((cuantos * 8) + 1) Then
                        btnProd.Left = (btnProd.Width * 7)
                        btnProd.Top = (prods - ((cuantos * 7) + 1)) * (btnProd.Height + 0.5)
                        '8
                    ElseIf prods > (cuantos * 8) And prods < ((cuantos * 9) + 1) Then
                        btnProd.Left = (btnProd.Width * 8)
                        btnProd.Top = (prods - ((cuantos * 8) + 1)) * (btnProd.Height + 0.5)
                        '9
                    ElseIf prods > (cuantos * 9) And prods < ((cuantos * 10) + 1) Then
                        btnProd.Left = (btnProd.Width * 9)
                        btnProd.Top = (prods - ((cuantos * 9) + 1)) * (btnProd.Height + 0.5)
                        '10
                    ElseIf prods > (cuantos * 10) And prods < ((cuantos * 11) + 1) Then
                        btnProd.Left = (btnProd.Width * 10)
                        btnProd.Top = (prods - ((cuantos * 10) + 1)) * (btnProd.Height + 0.5)
                        '11
                    ElseIf prods > (cuantos * 11) And prods < ((cuantos * 12) + 1) Then
                        btnProd.Left = (btnProd.Width * 11)
                        btnProd.Top = (prods - ((cuantos * 11) + 1)) * (btnProd.Height + 0.5)
                        '12
                    ElseIf prods > (cuantos * 12) And prods < ((cuantos * 13) + 1) Then
                        btnProd.Left = (btnProd.Width * 12)
                        btnProd.Top = (prods - ((cuantos * 12) + 1)) * (btnProd.Height + 0.5)
                        '13
                    ElseIf prods > (cuantos * 13) And prods < ((cuantos * 14) + 1) Then
                        btnProd.Left = (btnProd.Width * 13)
                        btnProd.Top = (prods - ((cuantos * 13) + 1)) * (btnProd.Height + 0.5)
                        '14
                    ElseIf prods > (cuantos * 14) And prods < ((cuantos * 15) + 1) Then
                        btnProd.Left = (btnProd.Width * 14)
                        btnProd.Top = (prods - ((cuantos * 14) + 1)) * (btnProd.Height + 0.5)
                        '15
                    ElseIf prods > (cuantos * 15) And prods < ((cuantos * 16) + 1) Then
                        btnProd.Left = (btnProd.Width * 15)
                        btnProd.Top = (prods - ((cuantos * 15) + 1)) * (btnProd.Height + 0.5)
                        '16
                    ElseIf prods > (cuantos * 16) And prods < ((cuantos * 17) + 1) Then
                        btnProd.Left = (btnProd.Width * 16)
                        btnProd.Top = (prods - ((cuantos * 16) + 1)) * (btnProd.Height + 0.5)
                        '17
                    ElseIf prods > (cuantos * 17) And prods < ((cuantos * 18) + 1) Then
                        btnProd.Left = (btnProd.Width * 17)
                        btnProd.Top = (prods - ((cuantos * 17) + 1)) * (btnProd.Height + 0.5)
                        '18
                    ElseIf prods > (cuantos * 18) And prods < ((cuantos * 19) + 1) Then
                        btnProd.Left = (btnProd.Width * 18)
                        btnProd.Top = (prods - ((cuantos * 18) + 1)) * (btnProd.Height + 0.5)
                        '19
                    ElseIf prods > (cuantos * 19) And prods < ((cuantos * 20) + 1) Then
                        btnProd.Left = (btnProd.Width * 19)
                        btnProd.Top = (prods - ((cuantos * 19) + 1)) * (btnProd.Height + 0.5)
                        '20
                    ElseIf prods > (cuantos * 20) And prods < ((cuantos * 21) + 1) Then
                        btnProd.Left = (btnProd.Width * 20)
                        btnProd.Top = (prods - ((cuantos * 20) + 1)) * (btnProd.Height + 0.5)
                        '21
                    ElseIf prods > (cuantos * 21) And prods < ((cuantos * 22) + 1) Then
                        btnProd.Left = (btnProd.Width * 21)
                        btnProd.Top = (prods - ((cuantos * 21) + 1)) * (btnProd.Height + 0.5)
                        '22
                    ElseIf prods > (cuantos * 22) And prods < ((cuantos * 23) + 1) Then
                        btnProd.Left = (btnProd.Width * 22)
                        btnProd.Top = (prods - ((cuantos * 22) + 1)) * (btnProd.Height + 0.5)
                        '23
                    ElseIf prods > (cuantos * 23) And prods < ((cuantos * 24) + 1) Then
                        btnProd.Left = (btnProd.Width * 23)
                        btnProd.Top = (prods - ((cuantos * 23) + 1)) * (btnProd.Height + 0.5)
                        '24
                    ElseIf prods > (cuantos * 24) And prods < ((cuantos * 25) + 1) Then
                        btnProd.Left = (btnProd.Width * 24)
                        btnProd.Top = (prods - ((cuantos * 24) + 1)) * (btnProd.Height + 0.5)
                        '25
                    ElseIf prods > (cuantos * 25) And prods < ((cuantos * 26) + 1) Then
                        btnProd.Left = (btnProd.Width * 25)
                        btnProd.Top = (prods - ((cuantos * 25) + 1)) * (btnProd.Height + 0.5)
                        '26
                    ElseIf prods > (cuantos * 26) And prods < ((cuantos * 27) + 1) Then
                        btnProd.Left = (btnProd.Width * 26)
                        btnProd.Top = (prods - ((cuantos * 26) + 1)) * (btnProd.Height + 0.5)
                        '27
                    ElseIf prods > (cuantos * 27) And prods < ((cuantos * 28) + 1) Then
                        btnProd.Left = (btnProd.Width * 27)
                        btnProd.Top = (prods - ((cuantos * 27) + 1)) * (btnProd.Height + 0.5)
                        '28
                    ElseIf prods > (cuantos * 28) And prods < ((cuantos * 29) + 1) Then
                        btnProd.Left = (btnProd.Width * 28)
                        btnProd.Top = (prods - ((cuantos * 28) + 1)) * (btnProd.Height + 0.5)
                        '29
                    ElseIf prods > (cuantos * 29) And prods < ((cuantos * 30) + 1) Then
                        btnProd.Left = (btnProd.Width * 29)
                        btnProd.Top = (prods - ((cuantos * 29) + 1)) * (btnProd.Height + 0.5)
                        '30
                    ElseIf prods > (cuantos * 30) And prods < ((cuantos * 31) + 1) Then
                        btnProd.Left = (btnProd.Width * 30)
                        btnProd.Top = (prods - ((cuantos * 30) + 1)) * (btnProd.Height + 0.5)
                        '31
                    ElseIf prods > (cuantos * 31) And prods < ((cuantos * 32) + 1) Then
                        btnProd.Left = (btnProd.Width * 31)
                        btnProd.Top = (prods - ((cuantos * 31) + 1)) * (btnProd.Height + 0.5)
                        '32
                    ElseIf prods > (cuantos * 32) And prods < ((cuantos * 33) + 1) Then
                        btnProd.Left = (btnProd.Width * 32)
                        btnProd.Top = (prods - ((cuantos * 32) + 1)) * (btnProd.Height + 0.5)
                        '33
                    ElseIf prods > (cuantos * 33) And prods < ((cuantos * 34) + 1) Then
                        btnProd.Left = (btnProd.Width * 33)
                        btnProd.Top = (prods - ((cuantos * 33) + 1)) * (btnProd.Height + 0.5)
                        '34
                    ElseIf prods > (cuantos * 34) And prods < ((cuantos * 35) + 1) Then
                        btnProd.Left = (btnProd.Width * 34)
                        btnProd.Top = (prods - ((cuantos * 34) + 1)) * (btnProd.Height + 0.5)
                        '35
                    ElseIf prods > (cuantos * 35) And prods < ((cuantos * 36) + 1) Then
                        btnProd.Left = (btnProd.Width * 35)
                        btnProd.Top = (prods - ((cuantos * 35) + 1)) * (btnProd.Height + 0.5)
                        '36
                    ElseIf prods > (cuantos * 36) And prods < ((cuantos * 37) + 1) Then
                        btnProd.Left = (btnProd.Width * 36)
                        btnProd.Top = (prods - ((cuantos * 36) + 1)) * (btnProd.Height + 0.5)
                        '37
                    ElseIf prods > (cuantos * 37) And prods < ((cuantos * 38) + 1) Then
                        btnProd.Left = (btnProd.Width * 37)
                        btnProd.Top = (prods - ((cuantos * 37) + 1)) * (btnProd.Height + 0.5)
                        '38
                    ElseIf prods > (cuantos * 38) And prods < ((cuantos * 39) + 1) Then
                        btnProd.Left = (btnProd.Width * 38)
                        btnProd.Top = (prods - ((cuantos * 38) + 1)) * (btnProd.Height + 0.5)
                        '39
                    ElseIf prods > (cuantos * 39) And prods < ((cuantos * 40) + 1) Then
                        btnProd.Left = (btnProd.Width * 39)
                        btnProd.Top = (prods - ((cuantos * 39) + 1)) * (btnProd.Height + 0.5)
                        '40
                    ElseIf prods > (cuantos * 40) And prods < ((cuantos * 41) + 1) Then
                        btnProd.Left = (btnProd.Width * 40)
                        btnProd.Top = (prods - ((cuantos * 40) + 1)) * (btnProd.Height + 0.5)
                        '41
                    ElseIf prods > (cuantos * 41) And prods < ((cuantos * 42) + 1) Then
                        btnProd.Left = (btnProd.Width * 41)
                        btnProd.Top = (prods - ((cuantos * 41) + 1)) * (btnProd.Height + 0.5)
                        '42
                    ElseIf prods > (cuantos * 42) And prods < ((cuantos * 43) + 1) Then
                        btnProd.Left = (btnProd.Width * 42)
                        btnProd.Top = (prods - ((cuantos * 42) + 1)) * (btnProd.Height + 0.5)
                        '43
                    ElseIf prods > (cuantos * 43) And prods < ((cuantos * 44) + 1) Then
                        btnProd.Left = (btnProd.Width * 43)
                        btnProd.Top = (prods - ((cuantos * 43) + 1)) * (btnProd.Height + 0.5)
                        '44
                    ElseIf prods > (cuantos * 44) And prods < ((cuantos * 45) + 1) Then
                        btnProd.Left = (btnProd.Width * 44)
                        btnProd.Top = (prods - ((cuantos * 44) + 1)) * (btnProd.Height + 0.5)
                        '45
                    ElseIf prods > (cuantos * 45) And prods < ((cuantos * 46) + 1) Then
                        btnProd.Left = (btnProd.Width * 45)
                        btnProd.Top = (prods - ((cuantos * 45) + 1)) * (btnProd.Height + 0.5)
                        '46
                    ElseIf prods > (cuantos * 46) And prods < ((cuantos * 47) + 1) Then
                        btnProd.Left = (btnProd.Width * 46)
                        btnProd.Top = (prods - ((cuantos * 46) + 1)) * (btnProd.Height + 0.5)
                        '47
                    ElseIf prods > (cuantos * 47) And prods < ((cuantos * 48) + 1) Then
                        btnProd.Left = (btnProd.Width * 47)
                        btnProd.Top = (prods - ((cuantos * 47) + 1)) * (btnProd.Height + 0.5)
                        '48
                    ElseIf prods > (cuantos * 48) And prods < ((cuantos * 49) + 1) Then
                        btnProd.Left = (btnProd.Width * 48)
                        btnProd.Top = (prods - ((cuantos * 48) + 1)) * (btnProd.Height + 0.5)
                        '49
                    ElseIf prods > (cuantos * 49) And prods < ((cuantos * 50) + 1) Then
                        btnProd.Left = (btnProd.Width * 49)
                        btnProd.Top = (prods - ((cuantos * 49) + 1)) * (btnProd.Height + 0.5)
                        '50
                    ElseIf prods > (cuantos * 50) And prods < ((cuantos * 51) + 1) Then
                        btnProd.Left = (btnProd.Width * 50)
                        btnProd.Top = (prods - ((cuantos * 50) + 1)) * (btnProd.Height + 0.5)
                        '51
                    ElseIf prods > (cuantos * 51) And prods < ((cuantos * 52) + 1) Then
                        btnProd.Left = (btnProd.Width * 51)
                        btnProd.Top = (prods - ((cuantos * 51) + 1)) * (btnProd.Height + 0.5)
                        '52
                    ElseIf prods > (cuantos * 52) And prods < ((cuantos * 53) + 1) Then
                        btnProd.Left = (btnProd.Width * 52)
                        btnProd.Top = (prods - ((cuantos * 52) + 1)) * (btnProd.Height + 0.5)
                        '53
                    ElseIf prods > (cuantos * 53) And prods < ((cuantos * 54) + 1) Then
                        btnProd.Left = (btnProd.Width * 53)
                        btnProd.Top = (prods - ((cuantos * 53) + 1)) * (btnProd.Height + 0.5)
                        '54
                    ElseIf prods > (cuantos * 54) And prods < ((cuantos * 55) + 1) Then
                        btnProd.Left = (btnProd.Width * 54)
                        btnProd.Top = (prods - ((cuantos * 54) + 1)) * (btnProd.Height + 0.5)
                        '55
                    ElseIf prods > (cuantos * 55) And prods < ((cuantos * 56) + 1) Then
                        btnProd.Left = (btnProd.Width * 55)
                        btnProd.Top = (prods - ((cuantos * 55) + 1)) * (btnProd.Height + 0.5)
                        '56
                    ElseIf prods > (cuantos * 56) And prods < ((cuantos * 57) + 1) Then
                        btnProd.Left = (btnProd.Width * 56)
                        btnProd.Top = (prods - ((cuantos * 56) + 1)) * (btnProd.Height + 0.5)
                        '57
                    ElseIf prods > (cuantos * 57) And prods < ((cuantos * 58) + 1) Then
                        btnProd.Left = (btnProd.Width * 57)
                        btnProd.Top = (prods - ((cuantos * 57) + 1)) * (btnProd.Height + 0.5)
                        '58
                    ElseIf prods > (cuantos * 58) And prods < ((cuantos * 59) + 1) Then
                        btnProd.Left = (btnProd.Width * 58)
                        btnProd.Top = (prods - ((cuantos * 58) + 1)) * (btnProd.Height + 0.5)
                        '59
                    ElseIf prods > (cuantos * 59) And prods < ((cuantos * 60) + 1) Then
                        btnProd.Left = (btnProd.Width * 59)
                        btnProd.Top = (prods - ((cuantos * 59) + 1)) * (btnProd.Height + 0.5)
                        '60
                    ElseIf prods > (cuantos * 60) And prods < ((cuantos * 61) + 1) Then
                        btnProd.Left = (btnProd.Width * 60)
                        btnProd.Top = (prods - ((cuantos * 60) + 1)) * (btnProd.Height + 0.5)
                        '61
                    ElseIf prods > (cuantos * 61) And prods < ((cuantos * 62) + 1) Then
                        btnProd.Left = (btnProd.Width * 61)
                        btnProd.Top = (prods - ((cuantos * 61) + 1)) * (btnProd.Height + 0.5)
                        '62
                    ElseIf prods > (cuantos * 62) And prods < ((cuantos * 63) + 1) Then
                        btnProd.Left = (btnProd.Width * 62)
                        btnProd.Top = (prods - ((cuantos * 62) + 1)) * (btnProd.Height + 0.5)
                        '63
                    ElseIf prods > (cuantos * 63) And prods < ((cuantos * 64) + 1) Then
                        btnProd.Left = (btnProd.Width * 63)
                        btnProd.Top = (prods - ((cuantos * 63) + 1)) * (btnProd.Height + 0.5)
                        '64
                    ElseIf prods > (cuantos * 64) And prods < ((cuantos * 65) + 1) Then
                        btnProd.Left = (btnProd.Width * 64)
                        btnProd.Top = (prods - ((cuantos * 64) + 1)) * (btnProd.Height + 0.5)
                        '65
                    ElseIf prods > (cuantos * 65) And prods < ((cuantos * 66) + 1) Then
                        btnProd.Left = (btnProd.Width * 65)
                        btnProd.Top = (prods - ((cuantos * 65) + 1)) * (btnProd.Height + 0.5)
                        '66
                    ElseIf prods > (cuantos * 66) And prods < ((cuantos * 67) + 1) Then
                        btnProd.Left = (btnProd.Width * 66)
                        btnProd.Top = (prods - ((cuantos * 66) + 1)) * (btnProd.Height + 0.5)
                        '67
                    ElseIf prods > (cuantos * 67) And prods < ((cuantos * 68) + 1) Then
                        btnProd.Left = (btnProd.Width * 67)
                        btnProd.Top = (prods - ((cuantos * 67) + 1)) * (btnProd.Height + 0.5)
                        '68
                    ElseIf prods > (cuantos * 68) And prods < ((cuantos * 69) + 1) Then
                        btnProd.Left = (btnProd.Width * 68)
                        btnProd.Top = (prods - ((cuantos * 68) + 1)) * (btnProd.Height + 0.5)
                        '69
                    ElseIf prods > (cuantos * 69) And prods < ((cuantos * 70) + 1) Then
                        btnProd.Left = (btnProd.Width * 69)
                        btnProd.Top = (prods - ((cuantos * 69) + 1)) * (btnProd.Height + 0.5)
                        '70
                    ElseIf prods > (cuantos * 70) And prods < ((cuantos * 71) + 1) Then
                        btnProd.Left = (btnProd.Width * 70)
                        btnProd.Top = (prods - ((cuantos * 70) + 1)) * (btnProd.Height + 0.5)
                        '71
                    ElseIf prods > (cuantos * 71) And prods < ((cuantos * 72) + 1) Then
                        btnProd.Left = (btnProd.Width * 71)
                        btnProd.Top = (prods - ((cuantos * 71) + 1)) * (btnProd.Height + 0.5)
                        '72
                    ElseIf prods > (cuantos * 72) And prods < ((cuantos * 73) + 1) Then
                        btnProd.Left = (btnProd.Width * 72)
                        btnProd.Top = (prods - ((cuantos * 72) + 1)) * (btnProd.Height + 0.5)
                        '73
                    ElseIf prods > (cuantos * 73) And prods < ((cuantos * 74) + 1) Then
                        btnProd.Left = (btnProd.Width * 73)
                        btnProd.Top = (prods - ((cuantos * 73) + 1)) * (btnProd.Height + 0.5)
                        '74
                    ElseIf prods > (cuantos * 74) And prods < ((cuantos * 75) + 1) Then
                        btnProd.Left = (btnProd.Width * 74)
                        btnProd.Top = (prods - ((cuantos * 74) + 1)) * (btnProd.Height + 0.5)
                        '75
                    ElseIf prods > (cuantos * 75) And prods < ((cuantos * 76) + 1) Then
                        btnProd.Left = (btnProd.Width * 75)
                        btnProd.Top = (prods - ((cuantos * 75) + 1)) * (btnProd.Height + 0.5)
                        '76
                    ElseIf prods > (cuantos * 76) And prods < ((cuantos * 77) + 1) Then
                        btnProd.Left = (btnProd.Width * 76)
                        btnProd.Top = (prods - ((cuantos * 76) + 1)) * (btnProd.Height + 0.5)
                        '77
                    ElseIf prods > (cuantos * 77) And prods < ((cuantos * 78) + 1) Then
                        btnProd.Left = (btnProd.Width * 77)
                        btnProd.Top = (prods - ((cuantos * 77) + 1)) * (btnProd.Height + 0.5)
                        '78
                    ElseIf prods > (cuantos * 78) And prods < ((cuantos * 79) + 1) Then
                        btnProd.Left = (btnProd.Width * 78)
                        btnProd.Top = (prods - ((cuantos * 78) + 1)) * (btnProd.Height + 0.5)
                        '79
                    ElseIf prods > (cuantos * 79) And prods < ((cuantos * 80) + 1) Then
                        btnProd.Left = (btnProd.Width * 79)
                        btnProd.Top = (prods - ((cuantos * 79) + 1)) * (btnProd.Height + 0.5)
                        '80
                    ElseIf prods > (cuantos * 80) And prods < ((cuantos * 81) + 1) Then
                        btnProd.Left = (btnProd.Width * 80)
                        btnProd.Top = (prods - ((cuantos * 80) + 1)) * (btnProd.Height + 0.5)
                        '81
                    ElseIf prods > (cuantos * 81) And prods < ((cuantos * 82) + 1) Then
                        btnProd.Left = (btnProd.Width * 81)
                        btnProd.Top = (prods - ((cuantos * 81) + 1)) * (btnProd.Height + 0.5)
                        '82
                    ElseIf prods > (cuantos * 82) And prods < ((cuantos * 83) + 1) Then
                        btnProd.Left = (btnProd.Width * 82)
                        btnProd.Top = (prods - ((cuantos * 82) + 1)) * (btnProd.Height + 0.5)
                        '83
                    ElseIf prods > (cuantos * 83) And prods < ((cuantos * 84) + 1) Then
                        btnProd.Left = (btnProd.Width * 83)
                        btnProd.Top = (prods - ((cuantos * 83) + 1)) * (btnProd.Height + 0.5)
                        '84
                    ElseIf prods > (cuantos * 84) And prods < ((cuantos * 85) + 1) Then
                        btnProd.Left = (btnProd.Width * 84)
                        btnProd.Top = (prods - ((cuantos * 84) + 1)) * (btnProd.Height + 0.5)
                        '85
                    ElseIf prods > (cuantos * 85) And prods < ((cuantos * 86) + 1) Then
                        btnProd.Left = (btnProd.Width * 85)
                        btnProd.Top = (prods - ((cuantos * 85) + 1)) * (btnProd.Height + 0.5)
                        '86
                    ElseIf prods > (cuantos * 86) And prods < ((cuantos * 87) + 1) Then
                        btnProd.Left = (btnProd.Width * 86)
                        btnProd.Top = (prods - ((cuantos * 86) + 1)) * (btnProd.Height + 0.5)
                        '87
                    ElseIf prods > (cuantos * 87) And prods < ((cuantos * 88) + 1) Then
                        btnProd.Left = (btnProd.Width * 87)
                        btnProd.Top = (prods - ((cuantos * 87) + 1)) * (btnProd.Height + 0.5)
                        '88
                    ElseIf prods > (cuantos * 88) And prods < ((cuantos * 89) + 1) Then
                        btnProd.Left = (btnProd.Width * 88)
                        btnProd.Top = (prods - ((cuantos * 88) + 1)) * (btnProd.Height + 0.5)
                        '89
                    ElseIf prods > (cuantos * 89) And prods < ((cuantos * 90) + 1) Then
                        btnProd.Left = (btnProd.Width * 89)
                        btnProd.Top = (prods - ((cuantos * 89) + 1)) * (btnProd.Height + 0.5)
                        '90
                    ElseIf prods > (cuantos * 90) And prods < ((cuantos * 91) + 1) Then
                        btnProd.Left = (btnProd.Width * 90)
                        btnProd.Top = (prods - ((cuantos * 90) + 1)) * (btnProd.Height + 0.5)
                        '91
                    ElseIf prods > (cuantos * 91) And prods < ((cuantos * 92) + 1) Then
                        btnProd.Left = (btnProd.Width * 91)
                        btnProd.Top = (prods - ((cuantos * 91) + 1)) * (btnProd.Height + 0.5)
                        '92
                    ElseIf prods > (cuantos * 92) And prods < ((cuantos * 93) + 1) Then
                        btnProd.Left = (btnProd.Width * 92)
                        btnProd.Top = (prods - ((cuantos * 92) + 1)) * (btnProd.Height + 0.5)
                        '93
                    ElseIf prods > (cuantos * 93) And prods < ((cuantos * 94) + 1) Then
                        btnProd.Left = (btnProd.Width * 93)
                        btnProd.Top = (prods - ((cuantos * 93) + 1)) * (btnProd.Height + 0.5)
                        '94
                    ElseIf prods > (cuantos * 94) And prods < ((cuantos * 95) + 1) Then
                        btnProd.Left = (btnProd.Width * 94)
                        btnProd.Top = (prods - ((cuantos * 94) + 1)) * (btnProd.Height + 0.5)
                        '95
                    ElseIf prods > (cuantos * 95) And prods < ((cuantos * 96) + 1) Then
                        btnProd.Left = (btnProd.Width * 95)
                        btnProd.Top = (prods - ((cuantos * 95) + 1)) * (btnProd.Height + 0.5)
                        '96
                    ElseIf prods > (cuantos * 96) And prods < ((cuantos * 97) + 1) Then
                        btnProd.Left = (btnProd.Width * 96)
                        btnProd.Top = (prods - ((cuantos * 96) + 1)) * (btnProd.Height + 0.5)
                        '97
                    ElseIf prods > (cuantos * 97) And prods < ((cuantos * 98) + 1) Then
                        btnProd.Left = (btnProd.Width * 97)
                        btnProd.Top = (prods - ((cuantos * 97) + 1)) * (btnProd.Height + 0.5)
                        '98
                    ElseIf prods > (cuantos * 98) And prods < ((cuantos * 99) + 1) Then
                        btnProd.Left = (btnProd.Width * 98)
                        btnProd.Top = (prods - ((cuantos * 98) + 1)) * (btnProd.Height + 0.5)
                        '99
                    ElseIf prods > (cuantos * 99) And prods < ((cuantos * 100) + 1) Then
                        btnProd.Left = (btnProd.Width * 99)
                        btnProd.Top = (prods - ((cuantos * 99) + 1)) * (btnProd.Height + 0.5)
                        '100
                    ElseIf prods > (cuantos * 100) And prods < ((cuantos * 101) + 1) Then
                        btnProd.Left = (btnProd.Width * 100)
                        btnProd.Top = (prods - ((cuantos * 100) + 1)) * (btnProd.Height + 0.5)
                        '101
                    ElseIf prods > (cuantos * 101) And prods < ((cuantos * 102) + 1) Then
                        btnProd.Left = (btnProd.Width * 101)
                        btnProd.Top = (prods - ((cuantos * 101) + 1)) * (btnProd.Height + 0.5)
                        '102
                    ElseIf prods > (cuantos * 102) And prods < ((cuantos * 103) + 1) Then
                        btnProd.Left = (btnProd.Width * 102)
                        btnProd.Top = (prods - ((cuantos * 102) + 1)) * (btnProd.Height + 0.5)
                        '103
                    ElseIf prods > (cuantos * 103) And prods < ((cuantos * 104) + 1) Then
                        btnProd.Left = (btnProd.Width * 103)
                        btnProd.Top = (prods - ((cuantos * 103) + 1)) * (btnProd.Height + 0.5)
                        '104
                    ElseIf prods > (cuantos * 104) And prods < ((cuantos * 105) + 1) Then
                        btnProd.Left = (btnProd.Width * 104)
                        btnProd.Top = (prods - ((cuantos * 104) + 1)) * (btnProd.Height + 0.5)
                        '105
                    ElseIf prods > (cuantos * 105) And prods < ((cuantos * 106) + 1) Then
                        btnProd.Left = (btnProd.Width * 105)
                        btnProd.Top = (prods - ((cuantos * 105) + 1)) * (btnProd.Height + 0.5)
                        '106
                    ElseIf prods > (cuantos * 106) And prods < ((cuantos * 107) + 1) Then
                        btnProd.Left = (btnProd.Width * 106)
                        btnProd.Top = (prods - ((cuantos * 106) + 1)) * (btnProd.Height + 0.5)
                        '107
                    ElseIf prods > (cuantos * 107) And prods < ((cuantos * 108) + 1) Then
                        btnProd.Left = (btnProd.Width * 107)
                        btnProd.Top = (prods - ((cuantos * 107) + 1)) * (btnProd.Height + 0.5)

                    Else
                        btnProd.Left = 0
                        btnProd.Top = (prods - 1) * (btnProd.Height + 0.5)
                    End If

                    btnProd.BackColor = Color.White
                    btnProd.FlatStyle = FlatStyle.Flat
                    btnProd.FlatAppearance.BorderSize = 0
                    If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & rd3(1).ToString & ".jpg") Then
                        btnProd.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg\" & rd3(1).ToString & ".jpg")
                        btnProd.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    AddHandler btnProd.Click, AddressOf btnProd_Click
                    pProductos.Controls.Add(btnProd)
                    prods += 1
                End If
            Loop
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Dim PctoAnt As Integer = 0
    Dim chec As Boolean = False
    Dim myDescrip As String = ""
    Dim MyUnidad As String = ""
    Dim MyMinimo As Double = 0
    Dim MyMultip As Double = 0
    Dim MyExistencia As Double = 0
    Dim MyPrecio As Double = 0
    Dim MyImporte As Double = 0
    Dim Existe As Double = 0
    Dim Min As Double = 0

    Public Sub ObtenerProducto(ByVal codigo As String)
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select VSE from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    chec = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & codigo & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    myDescrip = rd1("Nombre").ToString
                    MyUnidad = rd1("UVenta").ToString
                    MyMinimo = rd1("Min").ToString
                    MyMultip = rd1("Multiplo").ToString
                    MyExistencia = CDbl(rd1("Existencia").ToString) / MyMultip
                    rd2.Close() : cnn2.Close()

                    Call find_precio(codigo)
                    Min = MyExistencia

                    MyImporte = cantidad * MyPrecio
                End If
            End If
            rd1.Close()
            cnn1.Close()

            UpGrid()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub find_precio(ByVal codigo As String)
        Dim temp As Double = 0
        Dim TiCambio As Double = 0

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select tipo_cambio from tb_moneda,Productos where Codigo='" & codigo & "' and Productos.id_tbMoneda=tb_moneda.id"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TiCambio = rd3(0).ToString
                    If TiCambio = 0 Then TiCambio = 1
                End If
            Else
                TiCambio = 1
            End If
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select * from Productos where Codigo='" & codigo & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    MyPrecio = CDbl(IIf(rd3("PrecioCompra").ToString = "", "0", rd3("PrecioCompra").ToString)) * TiCambio
                    MyPrecio = FormatNumber(MyPrecio, 2)
                End If
            Else
                MyPrecio = 0
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Dim moneda As String = ""

    Public Sub Ajusta_Grid()
        moneda = DatosRecarga("Moneda")
    End Sub

    Private Sub tFolio_Tick(sender As Object, e As EventArgs) Handles tFolio.Tick
        tFolio.Stop()
        Folio()
        tFolio.Start()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CantidadProd = 1
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        If CDbl(txtcantidad.Text) > 0 Then
            cantidad = txtcantidad.Text
            If CantidadProd = 1 Then
                ObtenerProducto(CodigoProducto)
                CantidadProd = 0
                cantidad = 0
            End If
            panCantidad.Visible = False
            txtcantidad.Text = "0"
        Else
            txtcantidad.Text = "0"
        End If
    End Sub

    Public Sub UpGrid()
        grdcaptura.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke
        grdcaptura.DefaultCellStyle.SelectionForeColor = Color.Blue
        If cantidad = 0 Then Exit Sub
        With grdcaptura.Rows
            .Add(CodigoProducto & vbNewLine & myDescrip, FormatNumber(cantidad, 2), FormatNumber(MyPrecio, 2), FormatNumber(MyImporte, 2), MyUnidad)
        End With
        Dim TotalVenta As Double = 0
        For T As Integer = 0 To grdcaptura.Rows.Count - 1
            TotalVenta = TotalVenta + CDbl(grdcaptura.Rows(T).Cells(3).Value.ToString)
        Next
        lblTotal.Text = FormatNumber(TotalVenta, 2)

        grdProducto.DefaultCellStyle.SelectionBackColor = Color.White
        grdProducto.DefaultCellStyle.SelectionForeColor = Color.Black
        With grdProducto.Rows
            .Clear()
            .Add("Descripción: ", myDescrip)
            .Add("Cantidad: ", cantidad)
            .Add("Existencia: ", MyExistencia)
        End With
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        txtcantidad.Text = "0"
        panCantidad.Visible = False
        CantidadProd = 0
    End Sub

    Private Sub btnProd_Click(sender As Object, e As EventArgs)
        On Error GoTo keseso
        Dim btnProducto As Button = CType(sender, Button)

        CodigoProducto = ""
        CodigoProducto = btnProducto.Tag
        Ajusta_Grid()

        If CantidadProd = 1 Then
            PctoAnt = btnProducto.TabIndex
            CodigoProducto = btnProducto.Tag
            panCantidad.Visible = True
            txtcantidad.Focus().Equals(True)
        Else
            PctoAnt = btnProducto.TabIndex
            CodigoProducto = btnProducto.Tag
            cantidad = 1

            ObtenerProducto(btnProducto.Tag)

            cantidad = 0
        End If
        Exit Sub
keseso:
        MsgBox(Err.Number & " - " & Err.Description)
        Exit Sub
    End Sub

    Private Sub lblTotal_TextChanged(sender As Object, e As EventArgs) Handles lblTotal.TextChanged
        If lblTotal.Text = "" Then Exit Sub
        Dim TotalImporte As Double = lblTotal.Text
        Dim CantidadLetra As String = ""
        If TotalImporte > 0 Then
            btnpagar.Enabled = True
            CantidadLetra = UCase(Letras(TotalImporte))
        Else
            btnpagar.Enabled = False
            CantidadLetra = ""
        End If
        lblcantidadletra.Text = CantidadLetra
    End Sub

    Private Sub btnpoint_Click(sender As System.Object, e As System.EventArgs) Handles btnpoint.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "."
        Else
            txtcantidad.Text = "0."
        End If
    End Sub

    Private Sub btn0_Click(sender As System.Object, e As System.EventArgs) Handles btn0.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "0"
        Else
            txtcantidad.Text = "0"
        End If
    End Sub

    Private Sub btn1_Click(sender As System.Object, e As System.EventArgs) Handles btn1.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "1"
        Else
            txtcantidad.Text = "1"
        End If
    End Sub

    Private Sub btn2_Click(sender As System.Object, e As System.EventArgs) Handles btn2.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "2"
        Else
            txtcantidad.Text = "2"
        End If
    End Sub

    Private Sub btn3_Click(sender As System.Object, e As System.EventArgs) Handles btn3.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "3"
        Else
            txtcantidad.Text = "3"
        End If
    End Sub

    Private Sub btn4_Click(sender As System.Object, e As System.EventArgs) Handles btn4.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "4"
        Else
            txtcantidad.Text = "4"
        End If
    End Sub

    Private Sub btn5_Click(sender As System.Object, e As System.EventArgs) Handles btn5.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "5"
        Else
            txtcantidad.Text = "5"
        End If
    End Sub

    Private Sub btn6_Click(sender As System.Object, e As System.EventArgs) Handles btn6.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "6"
        Else
            txtcantidad.Text = "6"
        End If
    End Sub

    Private Sub btn7_Click(sender As System.Object, e As System.EventArgs) Handles btn7.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "7"
        Else
            txtcantidad.Text = "7"
        End If
    End Sub

    Private Sub btn8_Click(sender As System.Object, e As System.EventArgs) Handles btn8.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "8"
        Else
            txtcantidad.Text = "8"
        End If
    End Sub

    Private Sub btn9_Click(sender As System.Object, e As System.EventArgs) Handles btn9.Click
        If txtcantidad.Text <> "0" And txtcantidad.Text <> "" And txtcantidad.Text <> "0.00" Then
            txtcantidad.Text = txtcantidad.Text & "9"
        Else
            txtcantidad.Text = "9"
        End If
    End Sub

    Private Sub cboproveedor_DropDown(sender As Object, e As EventArgs) Handles cboproveedor.DropDown
        cboproveedor.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Compania from Proveedores where Compania<>'' order by Compania"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboproveedor.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnc0_Click(sender As System.Object, e As System.EventArgs) Handles btnc0.Click
        txtcantidad.Text = "0"
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        tFolio.Stop()
        pProductos.Controls.Clear()
        pGrupos.Controls.Clear()
        pDeptos.Controls.Clear()
        txtbarras.Text = ""
        CodigoProducto = ""
        cantidad = 0
        CantidadProd = 0
        Proveedor = ""
        Id_Provee = 0
        TotDeptos = 0
        TotGrupos = 0
        TotProductos = 0
        MYFOLIO = 0
        lbltipoventa.Text = "MOSTRADOR"
        grdcaptura.Rows.Clear()
        grdProducto.Rows.Clear()
        lblTotal.Text = "0.00"
        lblcantidadletra.Text = ""
        cboproveedor.Text = ""
        cboproveedor.Items.Clear()
        lblid_prov.Text = "0"
        Refresh()
        Departamentos()
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index

        With grdcaptura.Rows
            .Remove(grdcaptura.Rows(index))
        End With
        My.Application.DoEvents()
        Dim TotalVenta As Double = 0
        For T As Integer = 0 To grdcaptura.Rows.Count - 1
            TotalVenta = TotalVenta + CDbl(grdcaptura.Rows(T).Cells(3).Value.ToString)
        Next
        lblTotal.Text = FormatNumber(TotalVenta, 2)

        grdProducto.DefaultCellStyle.SelectionBackColor = Color.White
        grdProducto.DefaultCellStyle.SelectionForeColor = Color.Black
    End Sub

    Private Sub txtbarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtbarras.Text = "" Then
                Exit Sub
            End If

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where CodBarra='" & txtbarras.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        CodigoProducto = rd1("Codigo").ToString
                        cantidad = 1
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                If CodigoProducto <> "" Then
                    ObtenerProducto(CodigoProducto)
                End If
                txtbarras.Text = ""
                txtbarras.Focus().Equals(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnpagar_Click(sender As Object, e As EventArgs) Handles btnpagar.Click
        If grdcaptura.Rows.Count = 0 Then MsgBox("Necesitas agregar productos a la compra para poder guardarla.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select MAX(Id) from Compras"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    MYFOLIO = IIf(rd2(0).ToString() = "", 0, rd2(0).ToString()) + 1
                End If
            Else
                MYFOLIO = 1
            End If
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Id from Proveedores where Compania='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Id_Provee = rd1(0).ToString()
                End If
            Else
                Id_Provee = 0
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If MsgBox("¿Deseas guardar esta compra?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            For t As Integer = 0 To grdcaptura.Rows.Count - 1
                If CDbl(grdcaptura.Rows(t).Cells(1).Value.ToString) = 0 Then
                    MsgBox("Falta alguna cantidad.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
                If CDbl(grdcaptura.Rows(t).Cells(2).Value.ToString) = 0 Then
                    MsgBox("Falta algún precio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
            Next

            Dim MySaldo As Double = 0
            Dim Status As String = "PAGADO"

            Try

                cnn1.Close() : cnn1.Open()

                If Id_Provee <> 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoE where Id=(select MAX(ID) from AbonoE where IdProv=" & Id_Provee & ")"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = IIf(rd1(0).ToString(), 0, rd1(0).ToString()) + CDbl(lblTotal.Text)
                        End If
                    Else
                        MySaldo = CDbl(lblTotal.Text)
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values('" & MYFOLIO & "','" & MYFOLIO & "','" & MYFOLIO & "'," & Id_Provee & ",'" & cboproveedor.Text & "','COMPRA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & CDbl(lblTotal.Text) & ",0," & MySaldo & ",'','','" & lblatiende.Text & "')"
                    cmd1.ExecuteNonQuery()

                    MySaldo = 0

                    Do Until MySaldo <> 0
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from AbonoE where Id=(select MAX(ID) from AbonoE where IdProv=" & Id_Provee & ")"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MySaldo = IIf(rd1(0).ToString(), 0, rd1(0).ToString()) - CDbl(lblTotal.Text)
                            End If
                        End If
                        rd1.Close()
                    Loop

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & MYFOLIO & "','" & MYFOLIO & "','" & MYFOLIO & "'," & Id_Provee & ",'" & cboproveedor.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & CDbl(lblTotal.Text) & "," & MySaldo & "," & CDbl(lblTotal.Text) & ",0,0,0,'','','" & lblatiende.Text & "',0,0,0)"
                    cmd1.ExecuteNonQuery()
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoE(NumRemision,NumFactura,NumPedido,IdProv,Proveedor,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Efectivo,Tarjeta,Transfe,Otro,Banco,Referencia,Usuario,Corte,CorteU,Cargado) values('" & MYFOLIO & "','" & MYFOLIO & "','" & MYFOLIO & "'," & Id_Provee & ",'" & cboproveedor.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & CDbl(lblTotal.Text) & ",0," & CDbl(lblTotal.Text) & ",0,0,0,'','','" & lblatiende.Text & "',0,0,0)"
                    cmd1.ExecuteNonQuery()
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "insert into Compras(NumRemision,NumFactura,NumPedido,NotaCred,IdProv,Proveedor,Sub1,Desc1,Sub2,IVA,Total,Desc2,IEPS,Pagar,ACuenta,Resta,FechaC,FechaP,FechaNC,Status,FechaCancela,Usuario,Corte,CorteU,Cargado,Anticipo) values('" & MYFOLIO & "','" & MYFOLIO & "','" & MYFOLIO & "',''," & Id_Provee & ",'" & cboproveedor.Text & "',0,0,0,0," & CDbl(lblTotal.Text) & ",0,0," & CDbl(lblTotal.Text) & ",0," & CDbl(lblTotal.Text) & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','','" & Status & "','','" & lblatiende.Text & "',0,0,0,0)"
                cmd1.ExecuteNonQuery()

                Dim IdCompra As Integer = 0

                Do Until IdCompra <> 0
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select * from Compras where NumRemision='" & MYFOLIO & "' and Proveedor='" & cboproveedor.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            IdCompra = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()
                Loop

                Dim Zi As Integer = 0
                Do While grdcaptura.Rows.Count <> Zi
                    Dim myvalor As String = grdcaptura.Rows(Zi).Cells(0).Value.ToString()
                    Dim mycode As String = Mid(myvalor, 1, InStr(1, myvalor, vbNewLine) - 1)
                    Dim nombre As String = ""
                    Dim unidad As String = ""
                    Dim cantid As Double = grdcaptura.Rows(Zi).Cells(1).Value.ToString()
                    Dim precio As Double = FormatNumber(CDbl(grdcaptura.Rows(Zi).Cells(2).Value.ToString()), 4)
                    Dim tottal As Double = FormatNumber(CDbl(grdcaptura.Rows(Zi).Cells(3).Value.ToString()), 2)
                    Dim existe As Double = 0
                    Dim caduc As String = ""
                    Dim lote As String = ""
                    Dim dpto As String = "", grupo As String = ""
                    Dim mymultiplo As Double = 0
                    Dim iva_prod As Double = 0
                    Dim pcompra As Double = 0, pventaiva As Double = 0, pminimo As Double = 0, pmayoreo As Double = 0, pespecial As Double = 0, pmedio As Double = 0
                    Dim porventa As Double = 0, porminimo As Double = 0, pormayoreo As Double = 0, porespecial As Double = 0, pormedio As Double = 0

                    Dim tipo_anti As String = ""

                    pcompra = precio

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select * from Productos where Codigo='" & mycode & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            nombre = rd1("Nombre").ToString()
                            unidad = rd1("UCompra").ToString()
                            iva_prod = CDbl(rd1("IVA").ToString()) + 1
                            mymultiplo = rd1("Multiplo").ToString()
                            porventa = rd1("Porcentaje").ToString()
                            porminimo = rd1("PorcMin").ToString()
                            pormayoreo = rd1("PorcMay").ToString()
                            pormedio = rd1("PorcMM").ToString()
                            porespecial = rd1("PorcEsp").ToString()
                            dpto = rd1("Departamento").ToString()
                            grupo = rd1("Grupo").ToString()
                            existe = rd1("Existencia").ToString()
                        End If
                    End If
                    rd1.Close()

                    Dim nueva_exis As Double = existe + (cantid * mymultiplo)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "insert into ComprasDet(Id_Compra,NumRemision,NumFactura,Proveedor,Codigo,Nombre,UCompra,Cantidad,Precio,Total,FechaC,Grupo,Depto,Caducidad,Lote,FolioRep,NotaCred) values(" & IdCompra & ",'" & MYFOLIO & "','" & MYFOLIO & "','" & cboproveedor.Text & "','" & mycode & "','" & nombre & "','" & unidad & "'," & cantid & "," & precio & "," & tottal & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & grupo & "','" & dpto & "','" & caduc & "','" & lote & "',0,'')"
                    cmd1.ExecuteNonQuery()

                    'cmd1 = cnn1.CreateCommand
                    'cmd1.CommandText =
                    '"insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','COMPRA','" & cboremision.Text & "','" & codigo & "','" & nombre & "','" & unidad & "'," & (cantid * mymultiplo) & ",0," & (cantid * mymultiplo) & "," & pcompra & ",0,0,'" & alias_compras & "')"
                    'cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "update Productos set Existencia=" & nueva_exis & ", PrecioCompra=" & pcompra & ", Cargado=0, Almacen3=" & pcompra & " where Codigo='" & mycode & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & nombre & "','Ingreso por compra'," & existe & "," & CDbl(cantid * mymultiplo) & "," & CDbl(existe + (cantid * mymultiplo)) & "," & pcompra & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblatiende.Text & "','" & MYFOLIO & "','" & tipo_anti & "','','','','')"
                    cmd1.ExecuteNonQuery()
                    Zi += 1
                Loop

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "delete from AuxCompras"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try

            If MsgBox("¿Deseas imprimir comprobante?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Dim ImprimeEn As String = ""
                Dim Impresora As String = ""
                Dim tPapel As String = ""
                Dim tMilimetros As String = ""

                Dim copias As Integer = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Copias from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        copias = rd1(0).ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Formato from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Compras'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        tPapel = rd1(0).ToString
                    End If
                Else
                    MsgBox("No se ha establecido un tamaño de papel para el formato de impresión de ventas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='TamImpre'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        tMilimetros = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & tPapel & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Impresora = rd1(0).ToString
                    End If
                Else
                    If tPapel = "MEDIA CARTA" Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                Impresora = rd2(0).ToString()
                            End If
                        Else
                            MsgBox("No tienes una impresora configurada para imprimir en formato " & tPapel & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                        rd2.Close() : cnn2.Close()
                    End If
                    cnn1.Close()
                End If
                rd1.Close() : cnn1.Close()

                If tPapel = "TICKET" Then
                    If tMilimetros = "80" Then
                        For copi As Integer = 1 To copias
                            pTicket80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            pTicket80.Print()
                        Next
                    End If
                    If tMilimetros = "58" Then
                        For copi As Integer = 1 To copias
                            pTicket58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            pTicket58.Print()
                        Next
                    End If
                Else
                End If

                btnlimpiar.PerformClick()
                cboproveedor.Focus().Equals(True)
            End If

        End If
    End Sub

    Private Sub pTicket80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pTicket80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 130
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos de la compra
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("C O M P R A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12

        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("N° Remisión: " & MYFOLIO, fuente_datos, Brushes.Black, 1, Y)
        Y += 13.5
        Y += 4
        e.Graphics.DrawString("Fecha: " & Date.Now, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 13.5
        e.Graphics.DrawString("Usuario: " & lblatiende.Text, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 17

        '[2]. Datos del proveedor
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                If rd1("Compania").ToString <> "" Then
                    e.Graphics.DrawString("Nombre: " & Mid(rd1("Compania").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(rd1("Compania").ToString, 29, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Compania").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                If rd1("RFC").ToString <> "" Then
                    e.Graphics.DrawString("RFC: " & rd1("RFC").ToString, fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                If rd1("Correo").ToString <> "" Then
                    e.Graphics.DrawString("Correo: " & Mid(rd1("Correo").ToString, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                    If Mid(rd1("Correo").ToString, 29, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Correo").ToString, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 13.5
                    End If
                End If
                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If
        Else
            If cboproveedor.Text <> "" Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("CLIENTE", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboproveedor.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5

                Y += 8
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
            End If
            Y += 8
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
        End If
        rd1.Close()


        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 11
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
        e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim total_prods As Integer = 0

        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim myvalor As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim mycode As String = Mid(myvalor, 1, InStr(1, myvalor, vbNewLine) - 1)
            Dim nombre As String = Replace(grdcaptura.Rows(miku).Cells(0).Value.ToString(), Mid(myvalor, 1, InStr(1, myvalor, vbNewLine) - 1), "")
            Dim canti As Double = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(2).Value.ToString()
            Dim total As Double = FormatNumber(canti * precio, 2)

            nombre = EliminarSaltosLinea(nombre, "")

            e.Graphics.DrawString(mycode, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
            Y += 12.5
            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 21
            total_prods += 1
        Next
        Y -= 3
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Y += 3
        e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(lblTotal.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
        Y += 18
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.HasMorePages = False
    End Sub

    Private Sub pTicket58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pTicket58.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 45, 0, 90, 90)
                Y += 100
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 8, 0, 170, 100)
                Y += 110
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
                    Y += 10.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
                    Y += 10.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 10
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 94, Y, sc)
                    Y += 12
                End If
                Y += 6
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos del pedido
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 10
        e.Graphics.DrawString("C O M P R A", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 94, Y, sc)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("N° Remisión: " & MYFOLIO, fuente_datos, Brushes.Black, 1, Y)
        Y += 11
        Y += 4
        e.Graphics.DrawString("Fecha: " & Date.Now, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("Usuario: " & lblatiende.Text, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 19

        '[2]. Datos del proveedor
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 9.5
                e.Graphics.DrawString("PROVEEDOR", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 94, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 11

                If rd1("Compania").ToString <> "" Then
                    e.Graphics.DrawString("Nombre: " & Mid(rd1("Compania").ToString, 1, 23), fuente_prods, Brushes.Black, 1, Y)
                    Y += 10
                    If Mid(rd1("Compania").ToString, 24, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Compania").ToString, 24, 100), fuente_prods, Brushes.Black, 1, Y)
                        Y += 10
                    End If
                End If
                If rd1("RFC").ToString <> "" Then
                    e.Graphics.DrawString("RFC: " & rd1("RFC").ToString, fuente_prods, Brushes.Black, 1, Y)
                    Y += 10
                End If
                If rd1("Correo").ToString <> "" Then
                    e.Graphics.DrawString("Correo: " & Mid(rd1("Correo").ToString, 1, 23), fuente_prods, Brushes.Black, 1, Y)
                    Y += 10
                    If Mid(rd1("Correo").ToString, 24, 100) <> "" Then
                        e.Graphics.DrawString(Mid(rd1("Correo").ToString, 24, 100), fuente_prods, Brushes.Black, 1, Y)
                    End If
                End If
                Y += 12
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 9.5
            End If
        End If
        rd1.Close()


        e.Graphics.DrawString("Producto", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
        Y += 10
        e.Graphics.DrawString("Cant.", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("P.Unit", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 115, Y, sf)
        e.Graphics.DrawString("Total", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 187, Y, sf)
        Y += 5.5
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 16

        Dim total_prods As Integer = 0
        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim myvalor As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim mycode As String = Mid(myvalor, 1, InStr(1, myvalor, vbNewLine) - 1)
            Dim nombre As String = Replace(grdcaptura.Rows(miku).Cells(0).Value.ToString(), Mid(myvalor, 1, InStr(1, myvalor, vbNewLine) - 1), "")
            Dim canti As Double = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(2).Value.ToString()
            Dim total As Double = FormatNumber(canti * precio, 2)

            nombre = EliminarSaltosLinea(nombre, "")

            e.Graphics.DrawString(mycode, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 24), fuente_prods, Brushes.Black, 42, Y)
            Y += 10
            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 28, Y, sf)
            e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 31, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 115, Y, sf)
            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 188, Y, sf)
            Y += 20
            total_prods += 1
        Next

        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 94, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 17

        Y += 3
        e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(lblTotal.Text, 2), fuente_prods, Brushes.Black, 187, Y, sf)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.HasMorePages = False
    End Sub

    Private Sub cbofolio_DropDown(sender As Object, e As EventArgs) Handles cbofolio.DropDown
        cbofolio.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumRemision from Compras order by NumRemision"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbofolio.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboproveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboproveedor.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Proveedores where Compania='" & cboproveedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblid_prov.Text = rd1("Id").ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pCopia80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCopia80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 130
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos de la compra
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("C O M P R A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12

        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim id_compra As Integer = 0
        Dim fecha As String = ""
        Dim hora As String = ""
        Dim proveedor As String = ""
        Dim usuario As String = ""
        Dim total_compra As Double = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Compras where NumRemision='" & cbofolio.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id_compra = rd1("Id").ToString()
                    fecha = rd1("FechaC").ToString()
                    usuario = rd1("Usuario").ToString()
                    proveedor = rd1("Proveedor").ToString()
                    total_compra = rd1("Total").ToString()
                End If
            Else
                Exit Sub
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        e.Graphics.DrawString("N° Remisión: " & cbofolio.Text, fuente_datos, Brushes.Black, 1, Y)
        Y += 13.5
        Y += 4
        e.Graphics.DrawString("Fecha: " & fecha, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 13.5
        e.Graphics.DrawString("Usuario: " & usuario, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 17


        If proveedor <> "" Then
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
            e.Graphics.DrawString("CLIENTE", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7.5
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Nombre: " & Mid(proveedor, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            Y += 13.5

            Y += 8
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
        End If
        Y += 8
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 12


        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 11
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
        e.Graphics.DrawString("TOTAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 240, Y)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim total_prods As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ComprasDet where Id_Compra=" & id_compra
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim mycode As String = rd1("Codigo").ToString()
                    Dim nombre As String = rd1("Nombre").ToString()
                    Dim canti As Double = rd1("Cantidad").ToString()
                    Dim precio As Double = rd1("Precio").ToString()
                    Dim total As Double = rd1("Total").ToString()

                    e.Graphics.DrawString(mycode, fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 52, Y)
                    Y += 12.5
                    e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
                    e.Graphics.DrawString("x", fuente_prods, Brushes.Black, 55, Y)
                    e.Graphics.DrawString(simbolo & FormatNumber(precio, 2), fuente_prods, Brushes.Black, 180, Y, sf)
                    e.Graphics.DrawString(simbolo & FormatNumber(total, 2), fuente_prods, Brushes.Black, 285, Y, sf)
                    Y += 21
                    total_prods += 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Y -= 3
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Y += 3
        e.Graphics.DrawString("Total a pagar:", fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString(simbolo & FormatNumber(total_compra, 2), fuente_prods, Brushes.Black, 285, Y, sf)
        Y += 18
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.HasMorePages = False
    End Sub

    Private Sub cboproveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboproveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnpagar.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofolio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If MsgBox("¿Deseas imprimir una copia del folio '" & cbofolio.Text & "'?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Dim impresora As String = ""

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Impresora = rd1(0).ToString
                    End If
                End If
                rd1.Close() : cnn1.Close()

                pCopia80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                pCopia80.Print()
            End If
        End If
    End Sub
End Class