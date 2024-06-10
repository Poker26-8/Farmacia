
Imports System.IO
Imports System.Net
Public Class frmManejo

    Dim focou As String = ""

    Friend WithEvents btnUbicacion As System.Windows.Forms.Button
    Friend WithEvents btnHabitacionn As System.Windows.Forms.Button

    Dim VarMinutos As String = ""
    Dim varHoras As String = ""
    Dim vardias As String = ""
    Dim varhora As Double = 0
    Private Sub frmManejo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TRAERUBICACION()

        Dim nLogo As String = ""
        Dim contrainicio As Integer = 0
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TomaContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    contrainicio = rd1(0).ToString

                    If contrainicio = 1 Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Clave,Alias FROM Usuarios WHERE IdEmpleado=" & id_usu_log
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                txtpass.Text = rd2(0).ToString
                                lblusuario.Text = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()

                    End If
                End If
            End If
            rd1.Close()
            cnn2.Close()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select NotasCred from Formatos where Facturas='LogoG'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    nLogo = rd1(0).ToString

                    If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                        piclogo.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

            primerBoton()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub primerBoton()
        For Each control As Control In pUbicaciones.Controls
            If TypeOf control Is Button Then
                DirectCast(control, Button).PerformClick()
                Exit For
            End If
        Next
    End Sub

    Public Sub TRAERUBICACION()


        Dim ubi As Integer = 1
        Dim cuantos As Integer = Math.Truncate(psuperior.Height / 100)

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT Ubicacion FROM habitacion WHERE Ubicacion<>'' ORDER BY Ubicacion"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    btnUbicacion = New Button
                    btnUbicacion.Height = 115
                    btnUbicacion.Width = 80
                    btnUbicacion.Text = rd2(0).ToString
                    btnUbicacion.Name = "btnUbicacion(" & ubi & ")"
                    btnUbicacion.Tag = rd2(0).ToString

                    If ubi > cuantos And ubi < ((cuantos * 2) + 1) Then
                        btnUbicacion.Left = (btnUbicacion.Width * 1)
                        btnUbicacion.Top = (ubi - (cuantos + 1)) * (btnUbicacion.Height + 0.5)
                        '2
                    ElseIf ubi > (cuantos * 2) And ubi < ((cuantos * 3) + 1) Then
                        btnUbicacion.Left = (btnUbicacion.Width * 2)
                        btnUbicacion.Top = (ubi - ((cuantos * 2) + 1)) * (btnUbicacion.Height + 0.5)
                        '3
                    ElseIf ubi > (cuantos * 3) And ubi < ((cuantos * 4) + 1) Then
                        btnUbicacion.Left = (btnUbicacion.Width * 3)
                        btnUbicacion.Top = (ubi - ((cuantos * 3) + 1)) * (btnUbicacion.Height + 0.5)
                        '4
                    ElseIf ubi > (cuantos * 4) And ubi < ((cuantos * 5) + 1) Then
                        btnUbicacion.Left = (btnUbicacion.Width * 4)
                        btnUbicacion.Top = (ubi - ((cuantos * 4) + 1)) * (btnUbicacion.Height + 0.5)
                        '5
                    ElseIf ubi > (cuantos * 5) And ubi < ((cuantos * 6) + 1) Then
                        btnUbicacion.Left = (btnUbicacion.Width * 5)
                        btnUbicacion.Top = (ubi - ((cuantos * 5) + 1)) * (btnUbicacion.Height + 0.5)
                        '6
                    ElseIf ubi > (cuantos * 5) And ubi < ((cuantos * 7) + 1) Then
                        btnUbicacion.Left = (btnUbicacion.Width * 6)
                        btnUbicacion.Top = (ubi - ((cuantos * 6) + 1)) * (btnUbicacion.Height + 0.5)
                        '7
                    Else
                        btnUbicacion.Left = 0
                        btnUbicacion.Top = (ubi - 1) * (btnUbicacion.Height + 0.5)
                    End If

                    btnUbicacion.FlatStyle = FlatStyle.Flat
                    btnUbicacion.FlatAppearance.BorderSize = 0
                    btnUbicacion.FlatAppearance.MouseDownBackColor = Color.White

                    AddHandler btnUbicacion.Click, AddressOf btnUbicacion_Click
                    pUbicaciones.Controls.Add(btnUbicacion)
                    ubi = CDec(ubi) + 1

                End If
            Loop
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs)

        pHab.Controls.Clear()
        Dim hab As Button = CType(sender, Button)
        crear_Habitacion(hab.Text)
        Me.Text = hab.Text

    End Sub

    Public Sub crear_Habitacion(ByVal ubicacion As String)

        Dim salidahab As String = ""
        Dim tolehab As Double = 0
        Dim habita As Integer = 1
        Dim estado As String = ""
        Dim cuantos As UInteger = Math.Truncate(pHab.Height / 100)
        Dim cuantoslaterales As Double = Math.Truncate(pHab.Width / 75)
        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT N_Habitacion from habitacion  WHERE Ubicacion='" & ubicacion & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    Dim habitacion As String = ""

                    btnHabitacionn = New Button
                    btnHabitacionn.Text = rd3(0).ToString
                    btnHabitacionn.Width = 100
                    btnHabitacionn.Height = 100
                    btnHabitacionn.FlatStyle = FlatStyle.Flat
                    btnHabitacionn.FlatAppearance.BorderSize = 0
                    btnHabitacionn.Name = "btnHabitacionn(" & habita & ")"
                    btnHabitacionn.TextAlign = ContentAlignment.BottomCenter
                    btnHabitacionn.Font = New Font("Arial", 20)

                    If habita > cuantos And habita < ((cuantos * 2) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 1)
                        btnHabitacionn.Top = (habita - (cuantos + 1)) * (btnHabitacionn.Height + 0.5)
                        '2
                    ElseIf habita > (cuantos * 2) And habita < ((cuantos * 3) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 2)
                        btnHabitacionn.Top = (habita - ((cuantos * 2) + 1)) * (btnHabitacionn.Height + 0.5)
                        '3
                    ElseIf habita > (cuantos * 3) And habita < ((cuantos * 4) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 3)
                        btnHabitacionn.Top = (habita - ((cuantos * 3) + 1)) * (btnHabitacionn.Height + 0.5)
                        '4
                    ElseIf habita > (cuantos * 4) And habita < ((cuantos * 5) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 4)
                        btnHabitacionn.Top = (habita - ((cuantos * 4) + 1)) * (btnHabitacionn.Height + 0.5)
                        '5
                    ElseIf habita > (cuantos * 5) And habita < ((cuantos * 6) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 5)
                        btnHabitacionn.Top = (habita - ((cuantos * 5) + 1)) * (btnHabitacionn.Height + 0.5)
                        '6
                    ElseIf habita > (cuantos * 6) And habita < ((cuantos * 7) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 6)
                        btnHabitacionn.Top = (habita - ((cuantos * 6) + 1)) * (btnHabitacionn.Height + 0.5)
                        '7
                    ElseIf habita > (cuantos * 7) And habita < ((cuantos * 8) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 7)
                        btnHabitacionn.Top = (habita - ((cuantos * 7) + 1)) * (btnHabitacionn.Height + 0.5)
                        '8
                    ElseIf habita > (cuantos * 8) And habita < ((cuantos * 9) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 8)
                        btnHabitacionn.Top = (habita - ((cuantos * 8) + 1)) * (btnHabitacionn.Height + 0.5)
                        '9
                    ElseIf habita > (cuantos * 9) And habita < ((cuantos * 10) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 9)
                        btnHabitacionn.Top = (habita - ((cuantos * 9) + 1)) * (btnHabitacionn.Height + 0.5)
                        '10
                    ElseIf habita > (cuantos * 10) And habita < ((cuantos * 11) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 10)
                        btnHabitacionn.Top = (habita - ((cuantos * 10) + 1)) * (btnHabitacionn.Height + 0.5)
                        '11
                    ElseIf habita > (cuantos * 11) And habita < ((cuantos * 12) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 11)
                        btnHabitacionn.Top = (habita - ((cuantos * 11) + 1)) * (btnHabitacionn.Height + 0.5)
                        '12
                    ElseIf habita > (cuantos * 12) And habita < ((cuantos * 13) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 12)
                        btnHabitacionn.Top = (habita - ((cuantos * 12) + 1)) * (btnHabitacionn.Height + 0.5)
                        '13
                    ElseIf habita > (cuantos * 13) And habita < ((cuantos * 14) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 13)
                        btnHabitacionn.Top = (habita - ((cuantos * 13) + 1)) * (btnHabitacionn.Height + 0.5)
                        '14
                    ElseIf habita > (cuantos * 14) And habita < ((cuantos * 15) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 14)
                        btnHabitacionn.Top = (habita - ((cuantos * 14) + 1)) * (btnHabitacionn.Height + 0.5)
                        '15
                    ElseIf habita > (cuantos * 15) And habita < ((cuantos * 16) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 15)
                        btnHabitacionn.Top = (habita - ((cuantos * 15) + 1)) * (btnHabitacionn.Height + 0.5)
                        '16
                    ElseIf habita > (cuantos * 16) And habita < ((cuantos * 17) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 16)
                        btnHabitacionn.Top = (habita - ((cuantos * 16) + 1)) * (btnHabitacionn.Height + 0.5)
                        '17
                    ElseIf habita > (cuantos * 17) And habita < ((cuantos * 18) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 17)
                        btnHabitacionn.Top = (habita - ((cuantos * 17) + 1)) * (btnHabitacionn.Height + 0.5)
                        '18
                    ElseIf habita > (cuantos * 18) And habita < ((cuantos * 19) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 18)
                        btnHabitacionn.Top = (habita - ((cuantos * 18) + 1)) * (btnHabitacionn.Height + 0.5)
                        '19
                    ElseIf habita > (cuantos * 19) And habita < ((cuantos * 20) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 19)
                        btnHabitacionn.Top = (habita - ((cuantos * 19) + 1)) * (btnHabitacionn.Height + 0.5)
                        '20
                    ElseIf habita > (cuantos * 20) And habita < ((cuantos * 21) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 20)
                        btnHabitacionn.Top = (habita - ((cuantos * 20) + 1)) * (btnHabitacionn.Height + 0.5)
                        '21
                    ElseIf habita > (cuantos * 21) And habita < ((cuantos * 22) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 21)
                        btnHabitacionn.Top = (habita - ((cuantos * 21) + 1)) * (btnHabitacionn.Height + 0.5)
                        '22
                    ElseIf habita > (cuantos * 22) And habita < ((cuantos * 23) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 22)
                        btnHabitacionn.Top = (habita - ((cuantos * 22) + 1)) * (btnHabitacionn.Height + 0.5)
                        '23
                    ElseIf habita > (cuantos * 23) And habita < ((cuantos * 24) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 23)
                        btnHabitacionn.Top = (habita - ((cuantos * 23) + 1)) * (btnHabitacionn.Height + 0.5)
                        '24
                    ElseIf habita > (cuantos * 24) And habita < ((cuantos * 25) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 24)
                        btnHabitacionn.Top = (habita - ((cuantos * 24) + 1)) * (btnHabitacionn.Height + 0.5)
                        '25
                    ElseIf habita > (cuantos * 25) And habita < ((cuantos * 26) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 25)
                        btnHabitacionn.Top = (habita - ((cuantos * 25) + 1)) * (btnHabitacionn.Height + 0.5)
                        '26
                    ElseIf habita > (cuantos * 26) And habita < ((cuantos * 27) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 26)
                        btnHabitacionn.Top = (habita - ((cuantos * 26) + 1)) * (btnHabitacionn.Height + 0.5)
                        '27
                    ElseIf habita > (cuantos * 27) And habita < ((cuantos * 28) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 27)
                        btnHabitacionn.Top = (habita - ((cuantos * 27) + 1)) * (btnHabitacionn.Height + 0.5)
                        '28
                    ElseIf habita > (cuantos * 28) And habita < ((cuantos * 29) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 28)
                        btnHabitacionn.Top = (habita - ((cuantos * 28) + 1)) * (btnHabitacionn.Height + 0.5)
                        '29
                    ElseIf habita > (cuantos * 29) And habita < ((cuantos * 30) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 29)
                        btnHabitacionn.Top = (habita - ((cuantos * 29) + 1)) * (btnHabitacionn.Height + 0.5)
                        '30
                    ElseIf habita > (cuantos * 30) And habita < ((cuantos * 31) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 30)
                        btnHabitacionn.Top = (habita - ((cuantos * 30) + 1)) * (btnHabitacionn.Height + 0.5)
                        '31
                    ElseIf habita > (cuantos * 31) And habita < ((cuantos * 32) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 31)
                        btnHabitacionn.Top = (habita - ((cuantos * 31) + 1)) * (btnHabitacionn.Height + 0.5)
                        '32
                    ElseIf habita > (cuantos * 32) And habita < ((cuantos * 33) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 32)
                        btnHabitacionn.Top = (habita - ((cuantos * 32) + 1)) * (btnHabitacionn.Height + 0.5)
                        '33
                    ElseIf habita > (cuantos * 33) And habita < ((cuantos * 34) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 33)
                        btnHabitacionn.Top = (habita - ((cuantos * 33) + 1)) * (btnHabitacionn.Height + 0.5)
                        '34
                    ElseIf habita > (cuantos * 34) And habita < ((cuantos * 35) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 34)
                        btnHabitacionn.Top = (habita - ((cuantos * 34) + 1)) * (btnHabitacionn.Height + 0.5)
                        '35
                    ElseIf habita > (cuantos * 35) And habita < ((cuantos * 36) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 35)
                        btnHabitacionn.Top = (habita - ((cuantos * 35) + 1)) * (btnHabitacionn.Height + 0.5)
                        '36
                    ElseIf habita > (cuantos * 36) And habita < ((cuantos * 37) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 36)
                        btnHabitacionn.Top = (habita - ((cuantos * 36) + 1)) * (btnHabitacionn.Height + 0.5)
                        '37
                    ElseIf habita > (cuantos * 37) And habita < ((cuantos * 38) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 37)
                        btnHabitacionn.Top = (habita - ((cuantos * 37) + 1)) * (btnHabitacionn.Height + 0.5)
                        '38
                    ElseIf habita > (cuantos * 38) And habita < ((cuantos * 39) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 38)
                        btnHabitacionn.Top = (habita - ((cuantos * 38) + 1)) * (btnHabitacionn.Height + 0.5)
                        '39
                    ElseIf habita > (cuantos * 39) And habita < ((cuantos * 40) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 39)
                        btnHabitacionn.Top = (habita - ((cuantos * 39) + 1)) * (btnHabitacionn.Height + 0.5)
                        '40
                    ElseIf habita > (cuantos * 40) And habita < ((cuantos * 41) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 40)
                        btnHabitacionn.Top = (habita - ((cuantos * 40) + 1)) * (btnHabitacionn.Height + 0.5)
                        '41
                    ElseIf habita > (cuantos * 41) And habita < ((cuantos * 42) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 41)
                        btnHabitacionn.Top = (habita - ((cuantos * 41) + 1)) * (btnHabitacionn.Height + 0.5)
                        '42
                    ElseIf habita > (cuantos * 42) And habita < ((cuantos * 43) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 42)
                        btnHabitacionn.Top = (habita - ((cuantos * 42) + 1)) * (btnHabitacionn.Height + 0.5)
                        '43
                    ElseIf habita > (cuantos * 43) And habita < ((cuantos * 44) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 43)
                        btnHabitacionn.Top = (habita - ((cuantos * 43) + 1)) * (btnHabitacionn.Height + 0.5)
                        '44
                    ElseIf habita > (cuantos * 44) And habita < ((cuantos * 45) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 44)
                        btnHabitacionn.Top = (habita - ((cuantos * 44) + 1)) * (btnHabitacionn.Height + 0.5)
                        '45
                    ElseIf habita > (cuantos * 45) And habita < ((cuantos * 46) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 45)
                        btnHabitacionn.Top = (habita - ((cuantos * 45) + 1)) * (btnHabitacionn.Height + 0.5)
                        '46
                    ElseIf habita > (cuantos * 46) And habita < ((cuantos * 47) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 46)
                        btnHabitacionn.Top = (habita - ((cuantos * 46) + 1)) * (btnHabitacionn.Height + 0.5)
                        '47
                    ElseIf habita > (cuantos * 47) And habita < ((cuantos * 48) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 47)
                        btnHabitacionn.Top = (habita - ((cuantos * 47) + 1)) * (btnHabitacionn.Height + 0.5)
                        '48
                    ElseIf habita > (cuantos * 48) And habita < ((cuantos * 49) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 48)
                        btnHabitacionn.Top = (habita - ((cuantos * 48) + 1)) * (btnHabitacionn.Height + 0.5)
                        '49
                    ElseIf habita > (cuantos * 49) And habita < ((cuantos * 50) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 49)
                        btnHabitacionn.Top = (habita - ((cuantos * 49) + 1)) * (btnHabitacionn.Height + 0.5)
                        '50
                    ElseIf habita > (cuantos * 50) And habita < ((cuantos * 51) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 50)
                        btnHabitacionn.Top = (habita - ((cuantos * 50) + 1)) * (btnHabitacionn.Height + 0.5)
                        '51
                    ElseIf habita > (cuantos * 51) And habita < ((cuantos * 52) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 51)
                        btnHabitacionn.Top = (habita - ((cuantos * 51) + 1)) * (btnHabitacionn.Height + 0.5)
                        '52
                    ElseIf habita > (cuantos * 52) And habita < ((cuantos * 53) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 52)
                        btnHabitacionn.Top = (habita - ((cuantos * 52) + 1)) * (btnHabitacionn.Height + 0.5)
                        '53
                    ElseIf habita > (cuantos * 53) And habita < ((cuantos * 54) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 53)
                        btnHabitacionn.Top = (habita - ((cuantos * 53) + 1)) * (btnHabitacionn.Height + 0.5)
                        '54
                    ElseIf habita > (cuantos * 54) And habita < ((cuantos * 55) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 54)
                        btnHabitacionn.Top = (habita - ((cuantos * 54) + 1)) * (btnHabitacionn.Height + 0.5)
                        '55
                    ElseIf habita > (cuantos * 55) And habita < ((cuantos * 56) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 55)
                        btnHabitacionn.Top = (habita - ((cuantos * 55) + 1)) * (btnHabitacionn.Height + 0.5)
                        '56
                    ElseIf habita > (cuantos * 56) And habita < ((cuantos * 57) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 56)
                        btnHabitacionn.Top = (habita - ((cuantos * 56) + 1)) * (btnHabitacionn.Height + 0.5)
                        '57
                    ElseIf habita > (cuantos * 57) And habita < ((cuantos * 58) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 57)
                        btnHabitacionn.Top = (habita - ((cuantos * 57) + 1)) * (btnHabitacionn.Height + 0.5)
                        '58
                    ElseIf habita > (cuantos * 58) And habita < ((cuantos * 59) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 58)
                        btnHabitacionn.Top = (habita - ((cuantos * 58) + 1)) * (btnHabitacionn.Height + 0.5)
                        '59
                    ElseIf habita > (cuantos * 59) And habita < ((cuantos * 60) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 59)
                        btnHabitacionn.Top = (habita - ((cuantos * 59) + 1)) * (btnHabitacionn.Height + 0.5)
                        '60
                    ElseIf habita > (cuantos * 60) And habita < ((cuantos * 61) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 60)
                        btnHabitacionn.Top = (habita - ((cuantos * 60) + 1)) * (btnHabitacionn.Height + 0.5)
                        '61
                    ElseIf habita > (cuantos * 61) And habita < ((cuantos * 62) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 61)
                        btnHabitacionn.Top = (habita - ((cuantos * 61) + 1)) * (btnHabitacionn.Height + 0.5)
                        '62
                    ElseIf habita > (cuantos * 62) And habita < ((cuantos * 63) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 62)
                        btnHabitacionn.Top = (habita - ((cuantos * 62) + 1)) * (btnHabitacionn.Height + 0.5)
                        '63
                    ElseIf habita > (cuantos * 63) And habita < ((cuantos * 64) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 63)
                        btnHabitacionn.Top = (habita - ((cuantos * 63) + 1)) * (btnHabitacionn.Height + 0.5)
                        '64
                    ElseIf habita > (cuantos * 64) And habita < ((cuantos * 65) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 64)
                        btnHabitacionn.Top = (habita - ((cuantos * 64) + 1)) * (btnHabitacionn.Height + 0.5)
                        '65
                    ElseIf habita > (cuantos * 65) And habita < ((cuantos * 66) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 65)
                        btnHabitacionn.Top = (habita - ((cuantos * 65) + 1)) * (btnHabitacionn.Height + 0.5)
                        '66
                    ElseIf habita > (cuantos * 66) And habita < ((cuantos * 67) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 66)
                        btnHabitacionn.Top = (habita - ((cuantos * 66) + 1)) * (btnHabitacionn.Height + 0.5)
                        '67
                    ElseIf habita > (cuantos * 67) And habita < ((cuantos * 68) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 67)
                        btnHabitacionn.Top = (habita - ((cuantos * 67) + 1)) * (btnHabitacionn.Height + 0.5)
                        '68
                    ElseIf habita > (cuantos * 68) And habita < ((cuantos * 69) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 68)
                        btnHabitacionn.Top = (habita - ((cuantos * 68) + 1)) * (btnHabitacionn.Height + 0.5)
                        '69
                    ElseIf habita > (cuantos * 69) And habita < ((cuantos * 70) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 69)
                        btnHabitacionn.Top = (habita - ((cuantos * 69) + 1)) * (btnHabitacionn.Height + 0.5)
                        '70
                    ElseIf habita > (cuantos * 70) And habita < ((cuantos * 71) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 70)
                        btnHabitacionn.Top = (habita - ((cuantos * 70) + 1)) * (btnHabitacionn.Height + 0.5)
                        '71
                    ElseIf habita > (cuantos * 71) And habita < ((cuantos * 72) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 71)
                        btnHabitacionn.Top = (habita - ((cuantos * 71) + 1)) * (btnHabitacionn.Height + 0.5)
                        '72
                    ElseIf habita > (cuantos * 72) And habita < ((cuantos * 73) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 72)
                        btnHabitacionn.Top = (habita - ((cuantos * 72) + 1)) * (btnHabitacionn.Height + 0.5)
                        '73
                    ElseIf habita > (cuantos * 73) And habita < ((cuantos * 74) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 73)
                        btnHabitacionn.Top = (habita - ((cuantos * 73) + 1)) * (btnHabitacionn.Height + 0.5)
                        '74
                    ElseIf habita > (cuantos * 74) And habita < ((cuantos * 75) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 74)
                        btnHabitacionn.Top = (habita - ((cuantos * 74) + 1)) * (btnHabitacionn.Height + 0.5)
                        '75
                    ElseIf habita > (cuantos * 75) And habita < ((cuantos * 76) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 75)
                        btnHabitacionn.Top = (habita - ((cuantos * 75) + 1)) * (btnHabitacionn.Height + 0.5)
                        '76
                    ElseIf habita > (cuantos * 76) And habita < ((cuantos * 77) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 76)
                        btnHabitacionn.Top = (habita - ((cuantos * 76) + 1)) * (btnHabitacionn.Height + 0.5)
                        '77
                    ElseIf habita > (cuantos * 77) And habita < ((cuantos * 78) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 77)
                        btnHabitacionn.Top = (habita - ((cuantos * 77) + 1)) * (btnHabitacionn.Height + 0.5)
                        '78
                    ElseIf habita > (cuantos * 78) And habita < ((cuantos * 79) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 78)
                        btnHabitacionn.Top = (habita - ((cuantos * 78) + 1)) * (btnHabitacionn.Height + 0.5)
                        '79
                    ElseIf habita > (cuantos * 79) And habita < ((cuantos * 80) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 79)
                        btnHabitacionn.Top = (habita - ((cuantos * 79) + 1)) * (btnHabitacionn.Height + 0.5)
                        '80
                    ElseIf habita > (cuantos * 80) And habita < ((cuantos * 81) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 80)
                        btnHabitacionn.Top = (habita - ((cuantos * 80) + 1)) * (btnHabitacionn.Height + 0.5)
                        '81
                    ElseIf habita > (cuantos * 81) And habita < ((cuantos * 82) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 81)
                        btnHabitacionn.Top = (habita - ((cuantos * 81) + 1)) * (btnHabitacionn.Height + 0.5)
                        '82
                    ElseIf habita > (cuantos * 82) And habita < ((cuantos * 83) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 82)
                        btnHabitacionn.Top = (habita - ((cuantos * 82) + 1)) * (btnHabitacionn.Height + 0.5)
                        '83
                    ElseIf habita > (cuantos * 83) And habita < ((cuantos * 84) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 83)
                        btnHabitacionn.Top = (habita - ((cuantos * 83) + 1)) * (btnHabitacionn.Height + 0.5)
                        '84
                    ElseIf habita > (cuantos * 84) And habita < ((cuantos * 85) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 84)
                        btnHabitacionn.Top = (habita - ((cuantos * 84) + 1)) * (btnHabitacionn.Height + 0.5)
                        '85
                    ElseIf habita > (cuantos * 85) And habita < ((cuantos * 86) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 85)
                        btnHabitacionn.Top = (habita - ((cuantos * 85) + 1)) * (btnHabitacionn.Height + 0.5)
                        '86
                    ElseIf habita > (cuantos * 86) And habita < ((cuantos * 87) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 86)
                        btnHabitacionn.Top = (habita - ((cuantos * 86) + 1)) * (btnHabitacionn.Height + 0.5)
                        '87
                    ElseIf habita > (cuantos * 87) And habita < ((cuantos * 88) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 87)
                        btnHabitacionn.Top = (habita - ((cuantos * 87) + 1)) * (btnHabitacionn.Height + 0.5)
                        '88
                    ElseIf habita > (cuantos * 88) And habita < ((cuantos * 89) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 88)
                        btnHabitacionn.Top = (habita - ((cuantos * 88) + 1)) * (btnHabitacionn.Height + 0.5)
                        '89
                    ElseIf habita > (cuantos * 89) And habita < ((cuantos * 90) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 89)
                        btnHabitacionn.Top = (habita - ((cuantos * 89) + 1)) * (btnHabitacionn.Height + 0.5)
                        '90
                    ElseIf habita > (cuantos * 90) And habita < ((cuantos * 91) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 90)
                        btnHabitacionn.Top = (habita - ((cuantos * 90) + 1)) * (btnHabitacionn.Height + 0.5)
                        '91
                    ElseIf habita > (cuantos * 91) And habita < ((cuantos * 92) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 91)
                        btnHabitacionn.Top = (habita - ((cuantos * 91) + 1)) * (btnHabitacionn.Height + 0.5)
                        '92
                    ElseIf habita > (cuantos * 92) And habita < ((cuantos * 93) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 92)
                        btnHabitacionn.Top = (habita - ((cuantos * 92) + 1)) * (btnHabitacionn.Height + 0.5)
                        '93
                    ElseIf habita > (cuantos * 93) And habita < ((cuantos * 94) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 93)
                        btnHabitacionn.Top = (habita - ((cuantos * 93) + 1)) * (btnHabitacionn.Height + 0.5)
                        '94
                    ElseIf habita > (cuantos * 94) And habita < ((cuantos * 95) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 94)
                        btnHabitacionn.Top = (habita - ((cuantos * 94) + 1)) * (btnHabitacionn.Height + 0.5)
                        '95
                    ElseIf habita > (cuantos * 95) And habita < ((cuantos * 96) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 95)
                        btnHabitacionn.Top = (habita - ((cuantos * 95) + 1)) * (btnHabitacionn.Height + 0.5)
                        '96
                    ElseIf habita > (cuantos * 96) And habita < ((cuantos * 97) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 96)
                        btnHabitacionn.Top = (habita - ((cuantos * 96) + 1)) * (btnHabitacionn.Height + 0.5)
                        '97
                    ElseIf habita > (cuantos * 97) And habita < ((cuantos * 98) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 97)
                        btnHabitacionn.Top = (habita - ((cuantos * 97) + 1)) * (btnHabitacionn.Height + 0.5)
                        '98
                    ElseIf habita > (cuantos * 98) And habita < ((cuantos * 99) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 98)
                        btnHabitacionn.Top = (habita - ((cuantos * 98) + 1)) * (btnHabitacionn.Height + 0.5)
                        '99
                    ElseIf habita > (cuantos * 99) And habita < ((cuantos * 100) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 99)
                        btnHabitacionn.Top = (habita - ((cuantos * 99) + 1)) * (btnHabitacionn.Height + 0.5)
                        '100
                    ElseIf habita > (cuantos * 100) And habita < ((cuantos * 101) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 100)
                        btnHabitacionn.Top = (habita - ((cuantos * 100) + 1)) * (btnHabitacionn.Height + 0.5)
                        '101
                    ElseIf habita > (cuantos * 101) And habita < ((cuantos * 102) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 101)
                        btnHabitacionn.Top = (habita - ((cuantos * 101) + 1)) * (btnHabitacionn.Height + 0.5)
                        '102
                    ElseIf habita > (cuantos * 102) And habita < ((cuantos * 103) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 102)
                        btnHabitacionn.Top = (habita - ((cuantos * 102) + 1)) * (btnHabitacionn.Height + 0.5)
                        '103
                    ElseIf habita > (cuantos * 103) And habita < ((cuantos * 104) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 103)
                        btnHabitacionn.Top = (habita - ((cuantos * 103) + 1)) * (btnHabitacionn.Height + 0.5)
                        '104
                    ElseIf habita > (cuantos * 104) And habita < ((cuantos * 105) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 104)
                        btnHabitacionn.Top = (habita - ((cuantos * 104) + 1)) * (btnHabitacionn.Height + 0.5)
                        '105
                    ElseIf habita > (cuantos * 105) And habita < ((cuantos * 106) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 105)
                        btnHabitacionn.Top = (habita - ((cuantos * 105) + 1)) * (btnHabitacionn.Height + 0.5)
                        '106
                    ElseIf habita > (cuantos * 106) And habita < ((cuantos * 107) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 106)
                        btnHabitacionn.Top = (habita - ((cuantos * 106) + 1)) * (btnHabitacionn.Height + 0.5)
                        '107
                    ElseIf habita > (cuantos * 107) And habita < ((cuantos * 108) + 1) Then
                        btnHabitacionn.Left = (btnHabitacionn.Width * 107)
                        btnHabitacionn.Top = (habita - ((cuantos * 107) + 1)) * (btnHabitacionn.Height + 0.5)

                    Else
                        btnHabitacionn.Left = 0
                        btnHabitacionn.Top = (habita - 1) * (btnHabitacionn.Height + 0.5)
                    End If

                    cnn4.Close() : cnn4.Open()
                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT Estado FROM habitacion WHERE N_Habitacion='" & btnHabitacionn.Text & "'"
                    rd4 = cmd4.ExecuteReader
                    If rd4.HasRows Then
                        If rd4.Read Then

                            estado = rd4(0).ToString

                            If estado = "Desocupada" Then
                                btnHabitacionn.BackColor = Color.FromArgb(77, 201, 125)

                            ElseIf estado = "Ocupada" Then
                                btnHabitacionn.BackColor = Color.FromArgb(192, 39, 71)
                                Try
                                    cnn1.Close() : cnn1.Open()
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='SalidaHab'"
                                    rd1 = cmd1.ExecuteReader
                                    If rd1.HasRows Then
                                        If rd1.Read Then
                                            salidahab = rd1(0).ToString
                                        End If
                                    End If
                                    rd1.Close()

                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText = "SELECT NumPart FROM formatos WHERE Facturas='ToleHabi'"
                                    rd1 = cmd1.ExecuteReader
                                    If rd1.HasRows Then
                                        If rd1.Read Then
                                            tolehab = rd1(0).ToString
                                        End If
                                    End If
                                    rd1.Close()

                                    cnn2.Close() : cnn2.Open()

                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText = "Select * FROM AsigPC WHERE Nombre='" & btnHabitacionn.Text & "'"
                                    rd1 = cmd1.ExecuteReader
                                    If rd1.HasRows Then
                                        If rd1.Read Then

                                            Dim mesa As String = rd1("Nombre").ToString
                                            Dim horasas As Double = 0
                                            cmd2 = cnn2.CreateCommand
                                            cmd2.CommandText = "SELECT Horas FROM detallehotel WHERE Habitacion='" & mesa & "'"
                                            rd2 = cmd2.ExecuteReader
                                            If rd2.HasRows Then
                                                If rd2.Read Then
                                                    horasas = rd2(0).ToString
                                                End If
                                            End If
                                            rd2.Close()

                                            Dim tiempouso As Double = 0


                                            Dim fechaentradan As Date = Nothing
                                            Dim fechaentrada As String = ""

                                            Dim fechasalida As String = ""


                                            fechaentradan = rd1("HorEnt").ToString
                                            fechaentrada = Format(fechaentradan, "yyyy/MM/dd HH:mm")

                                            fechasalida = Format(Date.Now, "yyyy/MM/dd HH:mm")

                                            vardias = DateDiff(DateInterval.Day, CDate(fechaentradan), CDate(fechasalida))
                                            varHoras = DateDiff(DateInterval.Hour, CDate(fechaentradan), CDate(fechasalida))
                                            VarMinutos = DateDiff(DateInterval.Minute, CDate(fechaentradan), CDate(fechasalida))

                                            varhora = VarMinutos / 60
                                            tiempouso = FormatNumber(varHoras, 2)

                                            Dim tiempo As Double = tiempouso
                                            Dim horas As Double = horasas

                                            Dim fechasalidahab As DateTime = fechaentradan.AddHours(horas)
                                            Dim nuevafechasalida As String = ""

                                            If tolehab > 0 Then
                                                Dim fechacontolerancia As DateTime = fechasalidahab.AddMinutes(tolehab)

                                                nuevafechasalida = Format(fechacontolerancia, "yyyy/MM/dd HH:mm")
                                            Else

                                                nuevafechasalida = Format(fechasalidahab, "yyyy/MM/dd HH:mm")
                                            End If

                                            If horas = "24" Then

                                                If salidahab <> "" Then
                                                    Dim fechasaldia As DateTime = fechaentradan.AddHours(horas)
                                                    Dim fechasaldiac As String = Format(fechasaldia, "yyyy/MM/dd")
                                                    Dim fechaslaidanueva As String = fechasaldiac & " " & salidahab

                                                    ' MsgBox(fechaslaidanueva)
                                                    'MsgBox(fechasalida)

                                                    Dim fechasalida2 As DateTime = DateTime.ParseExact(fechaslaidanueva, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)
                                                    Dim fechaentrada2 As DateTime = DateTime.ParseExact(fechasalida, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)

                                                    If fechaentrada2 > fechasalida2 Then

                                                        'Dim timpo As Date = Nothing
                                                        'Dim timpon As String = ""
                                                        'timpo = fechasalida
                                                        'timpon = Format(timpo, "HH:mm")

                                                        'If timpon >= salidahab Then
                                                        btnHabitacionn.BackColor = Color.Violet
                                                        'Else
                                                        '    btnHabitacionn.BackColor = Color.FromArgb(192, 39, 71)
                                                        'End If
                                                    Else
                                                        btnHabitacionn.BackColor = Color.FromArgb(192, 39, 71)
                                                    End If

                                                End If

                                            Else
                                                If fechasalida >= nuevafechasalida Then
                                                    btnHabitacionn.BackColor = Color.Violet
                                                Else
                                                    btnHabitacionn.BackColor = Color.FromArgb(192, 39, 71)
                                                End If
                                            End If

                                        End If
                                    End If
                                    rd1.Close()
                                    cnn1.Close()
                                    cnn2.Close()
                                Catch ex As Exception
                                    MessageBox.Show(ex.ToString)
                                End Try


                                Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\ocupada.png"
                                If File.Exists(ruta) Then
                                    btnHabitacionn.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\ocupada.png")
                                Else
                                    btnHabitacionn.BackgroundImage = Nothing
                                End If

                            ElseIf estado = "Reservacion" Then
                                btnHabitacionn.BackColor = Color.FromArgb(1, 100, 156)
                            ElseIf estado = "Mantenimiento" Then
                                btnHabitacionn.BackColor = Color.LightGray

                                Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\mantenimiento.png"
                                If File.Exists(ruta) Then
                                    btnHabitacionn.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\mantenimiento.png")
                                Else
                                    btnHabitacionn.BackgroundImage = Nothing
                                End If

                            ElseIf estado = "Limpieza" Then
                                btnHabitacionn.BackColor = Color.Aqua

                                Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\limpiar.png"
                                If File.Exists(ruta) Then
                                    btnHabitacionn.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\limpiar.png")
                                Else
                                    btnHabitacionn.BackgroundImage = Nothing
                                End If

                            ElseIf estado = "Ventilacion" Then
                                btnHabitacionn.BackColor = Color.Yellow

                                Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\ventilacion.png"
                                If File.Exists(ruta) Then
                                    btnHabitacionn.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\ventilacion.png")
                                Else
                                    btnHabitacionn.BackgroundImage = Nothing
                                End If
                            Else
                                btnHabitacionn.BackColor = Color.FromArgb(77, 201, 125)
                            End If

                            '____________________________________________

                        End If
                    End If
                    rd4.Close()
                    cnn4.Close()
                    btnHabitacionn.BackgroundImageLayout = ImageLayout.Zoom
                    pHab.Controls.Add(btnHabitacionn)
                    AddHandler btnHabitacionn.Click, AddressOf btnHabitacionn_Click

                    habita += 1
                End If
            Loop
            rd3.Close()
            cnn3.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Sub btnHabitacionn_Click(sender As Object, e As EventArgs)
        Dim nhab As Button = CType(sender, Button)
        focou = "USU"
        Try

            txtHabitacion.Text = nhab.Text

            Dim estado As String = ""
            Dim cliente As String = ""
            Dim tiempo As Integer = 0
            Dim estadohabitaciona As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Estado,Tiempo FROM habitacion WHERE N_Habitacion='" & txtHabitacion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    estadohabitaciona = rd1(0).ToString
                    tiempo = rd1(1).ToString

                    If estadohabitaciona = "Ocupada" Then

                        btnPagar.Enabled = True

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM asigpc WHERE Nombre='" & txtHabitacion.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                frmCalcularNuvHab.lblpc.Text = txtHabitacion.Text
                                frmCalcularNuvHab.Show()
                            End If

                        End If
                        rd1.Close()
                        cnn1.Close()

                    Else
                        If tiempo = 1 Then

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT * FROM Asigpc WHERE Nombre='" & txtHabitacion.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                End If
                            Else

                                Dim tipo As String = ""
                                Dim ubicacion As String = ""
                                Dim precio As Double = 0
                                Dim descripcion As String = ""
                                Dim telefono As String = ""
                                Dim entrada As Date = Nothing
                                Dim salida As Date = Nothing

                                cnn1.Close() : cnn1.Open()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "SELECT * FROM habitacion WHERE N_Habitacion='" & txtHabitacion.Text & "'"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then

                                        tipo = rd1("Tipo").ToString
                                        ubicacion = rd1("Ubicacion").ToString
                                        descripcion = rd1("Caracteristicas").ToString
                                        estado = rd1("Estado").ToString


                                        frmDetalleH.habitacionn = txtHabitacion.Text
                                        frmDetalleH.lblhabitacion.Text = txtHabitacion.Text
                                        frmDetalleH.lbltipo.Text = tipo
                                        frmDetalleH.lblCaracteristicas.Text = descripcion


                                        cnn2.Close() : cnn2.Open()
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText = "SELECT * FROM detallehotel WHERE Habitacion='" & txtHabitacion.Text & "'"
                                        rd2 = cmd2.ExecuteReader
                                        If rd2.HasRows Then
                                            If rd2.Read Then
                                                cliente = rd2("Cliente").ToString
                                                telefono = rd2("Telefono").ToString
                                                entrada = rd2("FEntrada").ToString
                                                salida = rd2("FSalida").ToString

                                                frmDetalleH.cbocliente.Text = cliente
                                                frmDetalleH.txttelefono.Text = telefono
                                                frmDetalleH.dtpEntrada.Value = entrada
                                                frmDetalleH.dtpSalida.Value = salida

                                            End If
                                        End If
                                        rd2.Close()

                                        If estado = "Desocupada" Then
                                            frmDetalleH.lblEstado.Text = estado
                                            frmDetalleH.lblEstado.BackColor = Color.FromArgb(84, 204, 96)
                                            frmDetalleH.lblEstado.ForeColor = Color.White
                                        ElseIf estado = "Ocupada" Then
                                            frmDetalleH.lblEstado.Text = estado
                                            frmDetalleH.lblEstado.BackColor = Color.FromArgb(192, 39, 71)
                                            frmDetalleH.lblEstado.ForeColor = Color.White
                                        ElseIf estado = "Reservacion" Then
                                            frmDetalleH.lblEstado.Text = estado
                                            frmDetalleH.lblEstado.BackColor = Color.FromArgb(1, 100, 156)
                                            frmDetalleH.lblEstado.ForeColor = Color.White
                                        ElseIf estado = "Mantenimiento" Then
                                            frmDetalleH.lblEstado.Text = estado
                                            frmDetalleH.lblEstado.BackColor = Color.LightGray
                                            frmDetalleH.lblEstado.ForeColor = Color.Black
                                        ElseIf estado = "Limpieza" Then
                                            frmDetalleH.lblEstado.Text = estado
                                            frmDetalleH.lblEstado.BackColor = Color.Aqua
                                            frmDetalleH.lblEstado.ForeColor = Color.Black
                                        ElseIf estado = "Ventilacion" Then
                                            frmDetalleH.lblEstado.Text = estado
                                            frmDetalleH.lblEstado.BackColor = Color.Yellow
                                            frmDetalleH.lblEstado.ForeColor = Color.Black
                                        End If

                                        frmDetalleH.Show()
                                        Me.Close()
                                    End If
                                End If
                                rd1.Close()
                                cnn1.Close()
                                cnn2.Close()
                            End If
                            rd2.Close()
                            cnn2.Close()


                        End If
                    End If

                End If
            End If
            rd1.Close()
            cnn1.Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnHabitacion_Click(sender As Object, e As EventArgs) Handles btnHabitaciony.Click
        frmHabitaciones.Show()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmMenuHabitaciones.Show()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        pUbicaciones.Controls.Clear()
        TRAERUBICACION()
        txtpass.Text = ""
        lblusuario.Text = ""
        lblidusuario.Text = ""
        txtHabitacion.Text = ""

        lblcliente.Text = ""
        lblidcliente.Text = ""
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function

#Region "teclado"

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtpass.Text = txtpass.Text + btn1.Text
        txtpass.Focus.Equals(True)
    End Sub

    Private Sub btnborra_Click(sender As Object, e As EventArgs) Handles btnborra.Click
        txtpass.Text = CutCad(txtpass.Text)
        lblidusuario.Text = ""
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtpass.Text = txtpass.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtpass.Text = txtpass.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtpass.Text = txtpass.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtpass.Text = txtpass.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtpass.Text = txtpass.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtpass.Text = txtpass.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtpass.Text = txtpass.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtpass.Text = txtpass.Text + btn9.Text
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtpass.Text = txtpass.Text + btn9.Text
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        txtpass_KeyPress(txtpass, New KeyPressEventArgs(ControlChars.Cr))
    End Sub
#End Region

    Private Sub txtpass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpass.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then

            Try

                If txtpass.Text = "" Then txtpass.Focus.Equals(True) : Exit Sub

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status,IdEmpleado FROM Usuarios WHERE Clave='" & txtpass.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then



                        If rd1(1).ToString = 1 Then


                            lblusuario.Text = rd1(0).ToString
                            lblidusuario.Text = rd1(2).ToString
                            'KeyOP(focou)

                            'frmServicioCuarto.Show()
                            'frmServicioCuarto.lblCliente.Text = lblcliente.Text
                            'frmServicioCuarto.lblNumCliente.Text = lblidcliente.Text
                            'frmServicioCuarto.lblAtendio.Text = lblusuario.Text
                            'frmServicioCuarto.lblHabitacion.Text = txtHabitacion.Text
                            'Me.Close()
                        Else
                            MsgBox("El usuario no esta activo contacta a tu administrador", vbInformation + vbOKOnly, titulohotelriaa)
                            txtpass.Text = ""
                            txtpass.Focus.Equals(True)
                            lblusuario.Text = ""
                            cnn1.Close()
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("contraseña incorrecta", vbInformation + vbOKOnly, titulohotelriaa)
                    cnn1.Close()
                    txtpass.Text = ""
                    txtpass.Focus.Equals(True)
                    lblusuario.Text = ""
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

    End Sub

    Private Sub KeyOP(ByVal valor As String)

        Select Case valor
            Case "USU"
                Dim usuarioo As Integer = 0
                Dim usuariocomanda As Integer = 0

                If frmPagarH.Visible = False Then
                    If txtpass.Text <> "" And lblusuario.Text <> "" Then

                        Try
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT * FROM Usuarios WHERE Clave='" & txtpass.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    usuarioo = rd2(0).ToString
                                End If
                            End If
                            rd2.Close()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Nombre FROM comanda1 WHERE Nombre='" & txtHabitacion.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    usuariocomanda = rd2(0).ToString
                                End If
                            End If
                            rd2.Close()
                            cnn2.Close()
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString)
                            cnn2.Close()
                        End Try

                        If usuarioo = usuariocomanda Then

                        Else
                            If usuariocomanda = 0 Then

                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "SELECT * FROM Comandas WHERE NMESA='" & txtHabitacion.Text & "'"
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    If rd2.Read Then

                                    End If
                                End If
                                rd2.Close()
                                cnn2.Close()

                            Else

                            End If
                        End If



                    Else
                        MsgBox("Contraseña incorrecta, revisa la información registrada.", vbInformation + vbOKOnly, titulohotelriaa)
                        txtpass.Text = ""
                        txtpass.Focus().Equals(True)
                        Exit Sub
                    End If
                Else

                End If

        End Select
    End Sub

    Private Sub btnServicio_Click(sender As Object, e As EventArgs) Handles btnServicio.Click
        If lblusuario.Text = "" Then MsgBox("Ingrese la contraseña de usuario", vbInformation + vbOKOnly, titulohotelriaa) : txtpass.Focus.Equals(True) : Exit Sub

        If txtHabitacion.Text = "" Then MsgBox("Dede seleccionar alguna habitación", vbInformation + vbOKOnly, titulohotelriaa) : Exit Sub

        frmServicioCuarto.Show()
        frmServicioCuarto.lblCliente.Text = lblcliente.Text
        frmServicioCuarto.lblNumCliente.Text = lblidcliente.Text
        frmServicioCuarto.lblAtendio.Text = lblusuario.Text
        frmServicioCuarto.lblHabitacion.Text = txtHabitacion.Text
        Me.Close()
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Try

            Dim idempleado As Integer = 0
            Dim empleado As String = ""
            Dim realizarventas As Integer = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Nombre FROM usuarios WHERE Clave='" & txtpass.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idempleado = rd1(0).ToString
                    empleado = rd1(1).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Vent_NVen FROM permisos WHERE IdEmpleado=" & idempleado & ""
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    realizarventas = rd1(0).ToString

                    If realizarventas = 1 Then


                        frmPagarH.lblAtendio.Text = lblusuario.Text
                        frmPagarH.lblHabitacion.Text = txtHabitacion.Text
                        frmPagarH.lblNumCliente.Text = lblidcliente.Text
                        frmPagarH.lblCliente.Text = lblcliente.Text
                        frmPagarH.focoh = 1
                        frmPagarH.Show()
                        Me.Close()
                    Else
                        MsgBox("El empleado no tiene permisos para realizar ventas", vbInformation + vbOKOnly, titulohotelriaa)
                    End If

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnCambiarH_Click(sender As Object, e As EventArgs) Handles btnCambiarH.Click

        Try
            If txtHabitacion.Text = "" Then
                MsgBox("Debe seleccionar una Hbaitación ocupada.", vbInformation + vbOKOnly, titulohotelriaa)
                Exit Sub
            End If

            If lblusuario.Text = "" Then
                MsgBox("Ingrese la clave de Usuario", vbInformation + vbOKOnly, titulohotelriaa)
                Exit Sub
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Cambiar FROM permisos WHERE IdEmpleado=" & lblidusuario.Text & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        If rd1(0).ToString = 1 Then

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT * FROM comanda1 WHERE Nombre='" & txtHabitacion.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    frmCambiarHab.lblhabitacion.Text = txtHabitacion.Text
                                    frmCambiarHab.Show()
                                End If
                            Else
                                MsgBox("Para el cambio la habitacion tiene que estar ocupada.", vbInformation + vbOKOnly, titulohotelriaa)
                                Exit Sub
                            End If
                            rd2.Close()


                        Else
                            MsgBox("No cuentas con el permiso para realizar esta operación", vbInformation + vbOKOnly, titulohotelriaa)
                            Exit Sub
                        End If

                    End If
                Else
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

                cnn2.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmCancelarHab.Show()
        frmCancelarHab.BringToFront()
    End Sub
End Class