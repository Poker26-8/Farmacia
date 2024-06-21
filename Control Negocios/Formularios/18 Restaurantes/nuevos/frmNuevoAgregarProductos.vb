Imports System.IO
Public Class frmNuevoAgregarProductos

    Friend WithEvents btnDepto, btnGrupo, btnProd, btnPrefe, btnExtra, btnPromo As System.Windows.Forms.Button


    Dim TotDeptos As Integer = 0
    Dim TotGrupo As Integer = 0
    Dim TotProductos As Integer = 0
    Dim TotPrefe As Integer = 0
    Dim totExtras As Integer = 0
    Dim TotPromociones As Integer = 0
    Dim CantidadProductos As Integer = 0
    Public cantidadPromo As Double
    Public cantpromo As Double = 0

    Dim VarComensal As Integer = 0
    Public cantidad As Double = 0
    Dim cantidad2 As Double = 0

    Dim CodigoProducto As String = ""
    Dim existencia As Double = 0
    Dim descripcion As String = ""
    Dim unidadventa As String = ""
    Dim grupo As String = ""
    Dim doxuno As Integer = 0
    Dim tresxdos As Integer = 0

    Dim PU As Double = 0
    Dim descuentoseleccionado As Double = 0

    Dim importe As Double = 0
    Dim importedes As Double = 0
    Dim importemenosdes As Double = 0
    Dim totalventa As Double = 0
    Private Sub frmNuevoAgregarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
            pProductos.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
            pProductos.BackgroundImageLayout = ImageLayout.Stretch
        End If

        pDepartamento.Controls.Clear()
        pgrupo.Controls.Clear()
        pProductos.Controls.Clear()

        Departeamentos()
    End Sub

    Public Sub Departeamentos()

        Dim deptos As Integer = 0
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Departamento FROM Productos WHERE Departamento<>'INSUMO' AND Departamento<>'EXTRAS' AND Departamento<>'SERVICIOS' ORDER BY Departamento"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim departamento As String = rd1("Departamento").ToString

                    btnDepto = New Button
                    btnDepto.Text = departamento
                    btnDepto.Name = "btnDepto(" & deptos & ")"
                    btnDepto.Left = 0
                    btnDepto.Height = 40

                    If TotDeptos <= 10 Then
                        btnDepto.Width = pDepartamento.Width
                    Else
                        btnDepto.Width = pDepartamento.Width - 17
                    End If

                    btnDepto.Top = (deptos) * (btnDepto.Height + 1)
                    btnDepto.BackColor = pDepartamento.BackColor
                    btnDepto.FlatStyle = FlatStyle.Popup
                    btnDepto.FlatAppearance.BorderSize = 0
                    AddHandler btnDepto.Click, AddressOf btnDepto_Click
                    pDepartamento.Controls.Add(btnDepto)
                    If deptos = 0 Then
                        Grupos(departamento)
                    End If
                    deptos += 1
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub btnDepto_Click(sender As Object, e As EventArgs)

        Dim btnDepartamento As Button = CType(sender, Button)
        btnDepartamento.Font.Bold.Equals(True)

        pgrupo.Controls.Clear()
        pProductos.Controls.Clear()

        If cnn2.State = 1 Then
            cnn2.Close()
        End If
        CantidadProductos = 0
        Grupos(btnDepartamento.Text)

    End Sub
    Public Sub Grupos(ByVal depto As String)
        Dim grupos As Integer = 0
        TotGrupo = 0
        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT distinct Grupo FROM Productos WHERE Departamento='" & depto & "' AND Grupo<>'PROMOCIONES' ORDER BY Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    TotGrupo = TotGrupo + 1
                End If
            Loop
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT distinct Grupo FROM Productos WHERE Departamento='" & depto & "' AND Departamento<>'INGREDIENTES' AND Departamento<>'SERVICIOS' AND Grupo<>'EXTRAS' AND Grupo<>'PROMOCIONES' order by Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    Dim grupo As String = rd2(0).ToString
                    btnGrupo = New Button
                    btnGrupo.Text = grupo
                    btnGrupo.Tag = depto
                    btnGrupo.Name = "btnGrupo(" & grupos & ")"
                    btnGrupo.Left = 0
                    btnGrupo.Height = 45

                    If TotGrupo <= 10 Then
                        btnGrupo.Width = pgrupo.Width
                    Else
                        btnGrupo.Width = pgrupo.Width - 17
                    End If
                    btnGrupo.Top = grupos * (btnGrupo.Height + 1)
                    btnGrupo.BackColor = pgrupo.BackColor
                    btnGrupo.FlatStyle = FlatStyle.Popup
                    btnGrupo.FlatAppearance.BorderSize = 0
                    AddHandler btnGrupo.Click, AddressOf btnGrupo_Click
                    pgrupo.Controls.Add(btnGrupo)
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
        CantidadProductos = 0
        Productos(btnGrupo.Tag, btnGrupos.Text)
    End Sub

    Public Sub Productos(ByVal depto As String, ByVal grupo As String)
        Dim prods As Integer = 1
        Dim cuantos As Integer = Math.Truncate(pProductos.Height / 70)

        Try

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre,Codigo FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre,Codigo"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    TotProductos = TotProductos + 1
                End If
            Loop
            rd3.Close()

            If TotProductos <= 10 Then
                pProductos.AutoScroll = False
            Else
                pProductos.AutoScroll = True
            End If

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre,Codigo FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre,Codigo"
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

                    btnProd.BackColor = Color.Orange
                    btnProd.FlatStyle = FlatStyle.Popup
                    btnProd.FlatAppearance.BorderSize = 0

                    If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & baseseleccionada & "\" & rd3(1).ToString & ".jpg") Then
                        btnProd.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & baseseleccionada & "\" & rd3(1).ToString & ".jpg")
                        btnProd.BackgroundImageLayout = ImageLayout.Stretch
                        btnProd.TextAlign = ContentAlignment.BottomCenter
                        btnProd.ForeColor = Color.Black
                    End If

                    AddHandler btnProd.Click, AddressOf btnProd_Click
                    pProductos.Controls.Add(btnProd)
                    If prods = 0 Then
                        ' Preferencias(producto)
                        ' Extras(producto)
                    End If
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

    Private Sub btnProd_Click(sender As Object, e As EventArgs)
        Dim btnProducto As Button = CType(sender, Button)
        '  pPreferencias.Controls.Clear()
        'pExtras.Controls.Clear()


        CodigoProducto = ""
        CodigoProducto = btnProducto.Tag
        cantidadPromo = 0

        If cnn3.State = 1 Then
            cnn3.Close()
        End If

        If cantidadPromo = 0 Then

            cantpromo = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select * from Productos where Codigo = '" & CodigoProducto & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cantidadPromo = CDec(IIf(rd1("F44").ToString = "", "0", rd1("F44").ToString))
                Else
                    cantidadPromo = 1
                End If
            Else
                cantidadPromo = 1
            End If
            rd1.Close()
            cnn1.Close()

        End If

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Comensal FROM Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                VarComensal = rd1(0).ToString

                If VarComensal = 0 Then

                    cantidad = 1
                    cantidad2 = 1
                    ' respuesta = ""
                    ObtenerProducto(btnProducto.Tag)

                ElseIf VarComensal = 1 Then

                    'damecodigo = btnProducto.Tag

                    'With pteclado
                    '    .Show()
                    '    gdato.Text = "Comensal"
                    '    cantidad = 1
                    '    txtRespuesta.Focus.Equals(True)
                    'End With
                End If

            End If
        End If
        rd1.Close()
        cnn1.Close()

    End Sub
    Public Sub ObtenerProducto(Codigo As String)

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & Codigo & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Grupo").ToString = "SERVICIOS" Then
                        existencia = 0
                    End If
                    descripcion = rd1("Nombre").ToString
                    unidadventa = rd1("UVenta").ToString
                    existencia = rd1("Existencia").ToString
                    grupo = rd1("Grupo").ToString
                    doxuno = rd1("E1").ToString
                    tresxdos = rd1("E2").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            Call find_preciovta(Codigo)

            importedes = CDec(descuentoseleccionado / 100)
            importe = CDec(lblCantidad.Text) * CDec(PU)
            importemenosdes = CDec(importe * importedes)
            totalventa = CDec(importe) - CDec(importemenosdes)

            If grupo = "PROMOCIONES" Then
                UpGridCaptura()
            Else
                UpGridCaptura()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub find_preciovta(codigo As String)
        Dim MyPrecio As Double = 0

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                If PEDI = False Then
                    If rd2("Grupo").ToString() = "PROMOCIONES" Then
                        MyPrecio = 0
                    Else
                        MyPrecio = rd2("PrecioVentaIVA").ToString()
                    End If
                ElseIf PEDI = True Then
                    If rd2("Grupo").ToString() = "PROMOCIONES" Then
                        MyPrecio = 0
                    Else
                        'MyPrecio = rd2("PrecioVentaMinIVA").ToString()
                        MyPrecio = rd2("PrecioVentaIVA").ToString()
                    End If
                End If
                PU = MyPrecio
            End If
        End If
        rd2.Close() : cnn2.Close()
    End Sub

    Public Sub UpGridCaptura()

        Dim esta As String = ""
        Dim acumula As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT * FROM Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                esta = rd1("Comensal").ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Acumula'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                acumula = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        If esta = 1 Then
            With Me.grdCaptura
                Dim banderaentraa As Integer = 0
                banderaentraa = 0

                For qq As Integer = 0 To .Rows.Count - 1

                Next

                If banderaentraa = 0 Then
                    .Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2),, FormatNumber(descuentoseleccionado, 2), FormatNumber(totalventa, 2), respuesta, "", lblpromo.Text, "")

                    lblTotalVenta.Text = lblTotalVenta.Text + importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End If
            End With
        End If

    End Sub
End Class