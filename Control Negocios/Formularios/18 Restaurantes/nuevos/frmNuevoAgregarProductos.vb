Imports System.IO
Imports Microsoft.VisualBasic.Devices
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
    Dim TestStr As String = ""

    Dim codigoseleccionado As String = ""
    Dim comandaeliminar As String = ""

    Dim ivaproducto As Double = 0
    Dim iva As Double = 0
    Dim totaliva As Double = 0

    Dim rutacomanda As String = ""
    Dim CFOLIO As Integer = 0
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

        descuentoseleccionado = lblDescuento.Text

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

                    If .Rows(qq).Cells(0).Value = CodigoProducto Then
                        .Rows(qq).Cells(1).Value = descripcion
                        .Rows(qq).Cells(2).Value = .Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                        .Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                        .Rows(qq).Cells(4).Value = .Rows(qq).Cells(4).Value.ToString + CDec(FormatNumber(importe, 2))
                        .Rows(qq).Cells(5).Value = lblComensal.Text

                        'grdcaptura.Rows(qq).Cells(6).Value = lblPromo.Text

                        lblTotalVenta.Text = lblTotalVenta.Text + importe
                        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                        banderaentraa = 1
                    End If
                Next

                If banderaentraa = 0 Then
                    .Rows.Add(CodigoProducto, descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(descuentoseleccionado, 2), FormatNumber(totalventa, 2), lblComensal.Text, "", "")

                    lblTotalVenta.Text = lblTotalVenta.Text + importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End If
            End With
        Else
            Dim dia As Integer = Date.Now.DayOfWeek
            '2x1
            If doxuno = 1 Then
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM Promos WHERE Codigo='" & CodigoProducto & "' AND Promo2x1=1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        If rd2("Promo2x1").ToString = 1 Then
                            dia = Weekday(Date.Now)
                            Select Case dia
                                Case = 1
                                    If rd2("Domingo").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioD").ToString And TestStr <= rd2("HFinD").ToString Or TestStr >= rd2("HInicioD2").ToString And TestStr <= rd2("HFinD2").ToString Then
                                            doxuno = 1
                                        Else
                                            doxuno = 0
                                        End If
                                    Else
                                        doxuno = 0
                                    End If

                                Case = 2
                                    If rd2("Lunes").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioL").ToString And TestStr <= rd2("HFinL").ToString Or TestStr >= rd2("HInicioL2").ToString And TestStr <= rd2("HFinL2").ToString Then
                                            doxuno = 1
                                        Else
                                            doxuno = 0
                                        End If
                                    Else
                                        doxuno = 0
                                    End If

                                Case = 3
                                    If rd2("Martes").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioM").ToString And TestStr <= rd2("HFinM").ToString Or TestStr >= rd2("HInicioM2").ToString And TestStr <= rd2("HFinM2").ToString Then
                                            doxuno = 1
                                        Else
                                            doxuno = 0
                                        End If
                                    Else
                                        doxuno = 0
                                    End If

                                Case = 4
                                    If rd2("Miercoles").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioMi").ToString And TestStr <= rd2("HFinMi").ToString Or TestStr >= rd2("HInicioMi2").ToString And TestStr <= rd2("HFinMi2").ToString Then
                                            doxuno = 1
                                        Else
                                            doxuno = 0
                                        End If
                                    Else
                                        doxuno = 0
                                    End If

                                Case = 5
                                    If rd2("Jueves").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioJ").ToString And TestStr <= rd2("HFinJ").ToString Or TestStr >= rd2("HInicioJ2").ToString And TestStr <= rd2("HFinJ2").ToString Then
                                            doxuno = 1
                                        Else
                                            doxuno = 0
                                        End If
                                    Else
                                        doxuno = 0
                                    End If

                                Case = 6
                                    If rd2("Viernes").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioV").ToString And TestStr <= rd2("HFinV").ToString Or TestStr >= rd2("HInicioV2").ToString And TestStr <= rd2("HFinV2").ToString Then
                                            doxuno = 1
                                        Else
                                            doxuno = 0
                                        End If
                                    Else
                                        doxuno = 0
                                    End If

                                Case = 7
                                    If rd2("Sabado").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioS").ToString And TestStr <= rd2("HFinS").ToString Or TestStr >= rd2("HInicioS2").ToString And TestStr <= rd2("HFinS2").ToString Then
                                            doxuno = 1
                                        Else
                                            doxuno = 0
                                        End If
                                    Else
                                        doxuno = 0
                                    End If

                                Case Else
                                    doxuno = 0
                            End Select
                        End If
                    Else
                        doxuno = 0
                    End If
                End If
                rd2.Close()
                cnn2.Close()

                With grdCaptura.Rows
                    .Add(CodigoProducto, descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(descuentoseleccionado, 2), FormatNumber(importe, 2), "", "")

                    lblTotalVenta.Text = lblTotalVenta.Text + importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End With

                With Me.grdCaptura
                    For ii As Integer = 0 To grdCaptura.Rows.Count - 1
                        grdCaptura.Rows.Add(CodigoProducto, descripcion, FormatNumber(cantidad, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", "")
                    Next
                End With
                Exit Sub
            End If


            If tresxdos = 1 Then
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM promos WHERE Codigo='" & CodigoProducto & "' AND Promo3x2=1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        If rd2("Promo3x2").ToString = 1 Then
                            dia = Weekday(Date.Now)
                            Select Case dia
                                Case = 1
                                    If rd2("Domingo2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioD3").ToString And TestStr <= rd2("HFinD3").ToString Or TestStr >= rd2("HInicioD33").ToString And TestStr <= rd2("HFinD33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 2
                                    If rd2("Lunes2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioL3").ToString And TestStr <= rd2("HFinL3").ToString Or TestStr >= rd2("HInicioL33").ToString And TestStr <= rd2("HFinL33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 3
                                    If rd2("Martes2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioM3").ToString And TestStr <= rd2("HFin1M3").ToString Or TestStr >= rd2("HInicioM33").ToString And TestStr <= rd2("HFinM33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 4
                                    If rd2("Miercoles2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioMi3").ToString And TestStr <= rd2("HFinMi3").ToString Or TestStr >= rd2("HInicioMi33").ToString And TestStr <= rd2("HFinMi33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 5
                                    If rd2("Jueves2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioJ3").ToString And TestStr <= rd2("HFinJ3").ToString Or TestStr >= rd2("HInicioJ33").ToString And TestStr <= rd2("HFinJ33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 6
                                    If rd2("Viernes2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioV3").ToString And TestStr <= rd2("HFinV3").ToString Or TestStr >= rd2("HInicioV33").ToString And TestStr <= rd2("HFinV33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If

                                Case = 7
                                    If rd2("Sabado2").ToString = 1 Then
                                        TestStr = Format(Date.Now, "HH:mm:ss")
                                        If TestStr >= rd2("HInicioS3").ToString And TestStr <= rd2("HFinS3").ToString Or TestStr >= rd2("HInicioS33").ToString And TestStr <= rd2("HFinS33").ToString Then
                                            tresxdos = 1
                                        Else
                                            tresxdos = 0
                                        End If
                                    Else
                                        tresxdos = 0
                                    End If
                                Case Else
                                    tresxdos = 0
                            End Select
                        End If
                    Else
                        tresxdos = 0
                    End If
                Else
                    tresxdos = 0
                End If
                rd2.Close()
                cnn2.Close()

                With grdCaptura.Rows.Add(CodigoProducto, descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(descuentoseleccionado, 2), FormatNumber(importe, 2), "", "")

                End With

                With Me.grdCaptura.Rows.Add(CodigoProducto, descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(descuentoseleccionado, 2), FormatNumber(importe, 2), "", "")

                End With
                For q As Integer = 0 To grdCaptura.Rows.Count - 1
                    totalventa = totalventa + CDbl(grdCaptura.Rows(q).Cells(4).Value.ToString)
                    lblTotalVenta.Text = FormatNumber(totalventa, 2)
                Next

                With Me.grdCaptura.Rows.Add(CodigoProducto, descripcion, FormatNumber(cantidad, 2), FormatNumber(0, 2), FormatNumber(2, 0), FormatNumber(0, 2), "", "")

                End With
                Exit Sub
            End If

            With Me.grdCaptura
                Dim banderaentraa As Integer = 0
                banderaentraa = 0
                If acumula = 1 Then
                    For dx As Integer = 0 To grdCaptura.Rows.Count - 1
                        If CodigoProducto = grdCaptura.Rows(dx).Cells(0).Value.ToString Then
                            grdCaptura.Rows(dx).Cells(2).Value = cantidad + CDbl(grdCaptura.Rows(dx).Cells(2).Value.ToString)
                            grdCaptura.Rows(dx).Cells(4).Value = FormatNumber(importe + CDbl(grdCaptura.Rows(dx).Cells(4).Value.ToString), 2)

                            lblTotalVenta.Text = lblTotalVenta.Text + totalventa
                            lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)

                            GoTo deku
                        End If
                    Next

                    .Rows.Add(CodigoProducto, descripcion, FormatNumber(lblCantidad.Text, 2), FormatNumber(PU, 2), FormatNumber(descuentoseleccionado, 2), FormatNumber(totalventa, 2), 1, lblComensal.Text, "", "")

                    lblTotalVenta.Text = lblTotalVenta.Text + importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                Else
                    .Rows.Add(CodigoProducto, descripcion, FormatNumber(lblCantidad.Text, 2), FormatNumber(PU, 2), FormatNumber(descuentoseleccionado, 2), FormatNumber(totalventa, 2), lblComensal.Text, "", "")

                    lblTotalVenta.Text = lblTotalVenta.Text + totalventa
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End If
deku:
            End With
            lblCantidad.Text = "1.00"
            lblDescuento.Text = "0"
            lblComensal.Text = "1"
        End If

    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        EnviarComanda()
    End Sub
    Private Sub btnComanda_Click(sender As Object, e As EventArgs) Handles btnComanda.Click
        frmProductoOcasional.focomesasmostrar = 1
        frmProductoOcasional.agregarpro = 1
        frmProductoOcasional.Show()
    End Sub

    Private Sub btnResumen_Click(sender As Object, e As EventArgs) Handles btnResumen.Click

    End Sub

    Private Sub btnTeclado_Click(sender As Object, e As EventArgs) Handles btnTeclado.Click
        frmTecladoNum.cantidad = 1
        frmTecladoNum.Show()
        frmTecladoNum.BringToFront()
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        lblCantidad.Text = lblCantidad.Text - 1

        If lblCantidad.Text <= 0 Then
            lblCantidad.Text = "1.00"
        End If
        lblCantidad.Text = FormatNumber(lblCantidad.Text, 2)
    End Sub
    Private Sub btnAumentar_Click(sender As Object, e As EventArgs) Handles btnAumentar.Click
        lblCantidad.Text = lblCantidad.Text + 1
        lblCantidad.Text = FormatNumber(lblCantidad.Text, 2)
    End Sub
    Private Sub btnComensal_Click(sender As Object, e As EventArgs) Handles btnComensal.Click
        frmTecladoNum.comensal = 1
        frmTecladoNum.Show()
        frmTecladoNum.BringToFront()
    End Sub
    Private Sub btn1Tiempo_Click(sender As Object, e As EventArgs) Handles btn1Tiempo.Click
        Tiempos("5")
    End Sub

    Private Sub btnElminarTodo_Click(sender As Object, e As EventArgs) Handles btnElminarTodo.Click
        grdCaptura.Rows.Clear()
        lblTotalVenta.Text = "0.00"
    End Sub

    Private Sub btnEliminarPro_Click(sender As Object, e As EventArgs) Handles btnEliminarPro.Click
        If comandaeliminar <> "" Then

            Dim index As Integer = grdCaptura.CurrentRow.Index

            Dim total As Double = grdCaptura.Rows(index).Cells(5).Value.ToString
            lblTotalVenta.Text = lblTotalVenta.Text - CDec(total)
            lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
            grdCaptura.Rows.Remove(grdCaptura.CurrentRow)
        End If
    End Sub

    Private Sub btn2Tiempo_Click(sender As Object, e As EventArgs) Handles btn2Tiempo.Click
        Tiempos("10")
    End Sub

    Private Sub btn3Tiempo_Click(sender As Object, e As EventArgs) Handles btn3Tiempo.Click
        Tiempos("15")
    End Sub

    Private Sub Tiempos(ByVal min As Integer)
        Dim tiempo As Integer = 0


        For zi = 0 To grdCaptura.Rows.Count - 1
            grdCaptura.Rows(zi).Cells(7).Value = min
        Next
        If min = 5 Then
            grdCaptura.Rows.Add("--------------------", "Primer Tiempo", "0", "0", "0", "0", "", "", "")
        ElseIf min = 10 Then
            grdCaptura.Rows.Add("--------------------", "Segundo Tiempo", "0", "0", "0", "0", "", "", "")
        ElseIf min = 15 Then
            grdCaptura.Rows.Add("--------------------", "Tercer Tiempo", "0", "0", "0", "0", "", "", "")
        End If


    End Sub
    Private Sub btnDescuento_Click(sender As Object, e As EventArgs) Handles btnDescuento.Click
        frmTecladoNum.descuento = 1
        frmTecladoNum.Show()
        frmTecladoNum.BringToFront()
    End Sub

    Private Sub btnComentario_Click(sender As Object, e As EventArgs) Handles btnComentario.Click
        frmTecladoAgregarPro.comentario = 1
        frmTecladoAgregarPro.CODIGO = codigoseleccionado
        frmTecladoAgregarPro.Show()
        frmTecladoAgregarPro.BringToFront()
    End Sub

    Private Sub grdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellClick


        Dim index As Integer = grdCaptura.CurrentRow.Index
        Dim celda As DataGridViewCellEventArgs = e

        codigoseleccionado = grdCaptura.CurrentRow.Cells(0).Value.ToString
        comandaeliminar = grdCaptura.CurrentRow.Cells(0).Value.ToString
    End Sub

    Public Sub EnviarComanda()

        For n As Integer = 0 To grdCaptura.Rows.Count - 1
            If grdCaptura.Rows(n).Cells(0).Value <> "" Then

                CodigoProducto = grdCaptura.Rows(n).Cells(0).Value.ToString

                If CodigoProducto = "--------------------" Then
                    Continue For
                End If

                Dim TOTAL As Double = grdCaptura.Rows(n).Cells(4).Value.ToString

                If CodigoProducto <> "WXYZ" Then
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "select IVA from Productos where Codigo='" & CodigoProducto & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.Read Then
                        If grdCaptura.Rows(n).Cells(3).Value.ToString <> "" Then

                            If rd1(0).ToString > 0 Then
                                IVAPRODUCTO = CDbl(TOTAL) / (1 + rd1(0).ToString)
                                iva = CDbl(TOTAL) - CDbl(IVAPRODUCTO)
                                totaliva = totaliva + CDbl(iva)
                            End If

                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                End If
            End If
        Next n
        totaliva = FormatNumber(totaliva, 2)


        If grdCaptura.Rows.Count < 1 Then
            Exit Sub
        End If

        If MsgBox("Desea enviar a producccion", vbInformation + vbOKCancel, titulomensajes) = vbCancel Then
            Exit Sub
        End If

        Dim mysubtotal As Double = 0
        Dim mytotalventa As Double = 0

        mytotalventa = lblTotalVenta.Text
        mysubtotal = CDbl(mytotalventa) - CDbl(totaliva)

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "INSERT INTO Comanda1(Nombre,Subtotal,IVA,Totales,Resta,TComensales,IdCliente,Direccion,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista) VALUES('" & lblMesa.Text & "'," & mysubtotal & "," & totaliva & "," & mytotalventa & "," & mytotalventa & "," & CInt(lblComensal.Text) & ",'','','" & lblmesero.Text & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','','','','')"
        cmd1.ExecuteNonQuery()
        cnn1.Close()

        Dim drawline As String = ""
        Dim FOLIO1 As String = ""
        Dim MYCODE As String = ""
        Dim MYDESC As String = ""
        Dim MYCANT As Double = 0
        Dim MYPRECIO As Double = 0
        Dim DESCUENTO As Double = 0
        Dim TOTALC As Double = 0
        Dim COMENSAL As String = ""
        Dim EXTRAS As String = ""
        Dim COMENTARIO As String = ""

        Dim MYIVA As Double = 0
        Dim PRECIOSINIVA As Double = 0
        Dim TOTALSINIVA As Double = 0

        Dim MYCOSTOVUE As Double = 0
        Dim MYPROMO As Double = 0
        Dim MYDEPARTAMENTO As String = ""
        Dim MYGRUPO As String = ""
        Dim MYMCD As Double = 0
        Dim MYMULTIPLO As Double = 0
        Dim MYMULTIPLOD As Double = 0
        Dim MYGPRINT As String = ""
        Dim MYEXISTENCIA As Double = 0
        Dim PRECIOCOMPRA As Double = 0
        Dim UVENTA As String = ""


        Dim MinutosTiempo As Integer = 0
        Dim HrTiempo As String = ""
        Dim HrEntrega As String = ""

        FOLIO1 = Trim(lblMesa.Text)

        For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

            If grdCaptura.Rows(luffy).Cells(0).Value = "--------------------" Then
                drawline = grdCaptura.Rows(luffy).Cells(1).Value.ToString
            Else
                MYCODE = grdCaptura.Rows(luffy).Cells(0).Value.ToString
                MYDESC = grdCaptura.Rows(luffy).Cells(1).Value.ToString
                MYCANT = grdCaptura.Rows(luffy).Cells(2).Value.ToString
                MYPRECIO = grdCaptura.Rows(luffy).Cells(3).Value.ToString
                DESCUENTO = grdCaptura.Rows(luffy).Cells(4).Value.ToString
                TOTALC = grdCaptura.Rows(luffy).Cells(5).Value.ToString
                COMENSAL = grdCaptura.Rows(luffy).Cells(6).Value.ToString
                EXTRAS = grdCaptura.Rows(luffy).Cells(7).Value.ToString
                COMENTARIO = grdCaptura.Rows(luffy).Cells(8).Value

                If MYCODE <> "WXYZ" Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & MYCODE & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            MYIVA = rd2(0).ToString
                            If MYIVA > 0 Then
                                PRECIOSINIVA = IIf(MYPRECIO = 0, 0, MYPRECIO) / (1 + MYIVA)
                                TOTALSINIVA = IIf(TOTALC = 0, 0, TOTALC) / (1 + MYIVA)
                            Else
                                PRECIOSINIVA = FormatNumber(PRECIOSINIVA, 2)
                                TOTALSINIVA = FormatNumber(TOTALSINIVA, 2)
                            End If
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & MYCODE & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            If rd2("departamento").ToString = "SERVICIOS" Then
                                MYCOSTOVUE = 0
                                MYPROMO = 0
                                MYDEPARTAMENTO = rd2("Departamento").ToString
                                MYGRUPO = rd2("Grupo").ToString
                            End If
                            MYMCD = rd2("MCD").ToString
                            MYMULTIPLO = rd2("Multiplo").ToString
                            MYDEPARTAMENTO = rd2("Departamento").ToString
                            MYGRUPO = rd2("Grupo").ToString
                            MYGPRINT = rd2("GPrint").ToString
                            UVENTA = rd2("UVenta").ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM productos WHERE codigo='" & Strings.Left(MYCODE, 7) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            MYMULTIPLOD = rd2("Multiplo").ToString
                            MYEXISTENCIA = rd2("Existencia").ToString / CDec(MYMULTIPLOD)

                            If rd2("Departamento").ToString <> "SERVICIOS" Then
                                PRECIOCOMPRA = rd2("PrecioCompra").ToString
                                MYCOSTOVUE = CDec(PRECIOCOMPRA) * (MYCANT / MYMCD)
                            End If

                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()
                End If

                If MYCODE <> "" Then

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT MAX(Id) FROM comanda1"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            CFOLIO = IIf(rd3(0).ToString = "", 0, rd3(0).ToString)
                        End If
                    Else
                        CFOLIO = 1
                    End If
                    rd3.Close()
                    cnn3.Close()

                    If MinutosTiempo = 0 Then
                        HrTiempo = Format(Date.Now, "HH:mm:ss")
                        HrEntrega = Format(Date.Now, "HH:mm:ss")
                    ElseIf MinutosTiempo > 0 Then
                        HrTiempo = Format(Date.Now, "HH:mm:ss")
                        HrEntrega = Format(DateAdd("n", MinutosTiempo, Date.Now), "HH:mm:ss")
                    End If

                    If MYCODE <> "WXYZ" Then

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO comandas(Id,NMESA,Codigo,Nombre,UVenta,Cantidad,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT) VALUES(" & CFOLIO & ",'" & FOLIO1 & "','" & MYCODE & "','" & MYDESC & "','" & UVENTA & "'," & MYCANT & "," & MYCOSTOVUE & "," & IIf(MYPROMO = 0, 0, MYPROMO) & "," & MYPRECIO & "," & TOTALC & "," & PRECIOSINIVA & "," & TOTALSINIVA & ",'" & drawline & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & MYDEPARTAMENTO & "','" & MYGRUPO & "','" & COMENSAL & "','RESTA','" & COMENTARIO & "','" & MYGPRINT & "','" & lblmesero.Text & "','1',0,'" & HrTiempo & "','" & HrEntrega & "')"
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO rep_comandas(Id,NMESA,Codigo,Nombre,UVenta,Cantidad,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT) VALUES(" & CFOLIO & ",'" & FOLIO1 & "','" & MYCODE & "','" & MYDESC & "','" & UVENTA & "'," & MYCANT & "," & MYCOSTOVUE & "," & IIf(MYPROMO = 0, 0, MYPROMO) & "," & MYPRECIO & "," & TOTALC & "," & PRECIOSINIVA & "," & TOTALSINIVA & ",'" & drawline & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & MYDEPARTAMENTO & "','" & MYGRUPO & "','" & COMENSAL & "','ORDENADA','" & COMENTARIO & "','" & MYGPRINT & "','" & lblmesero.Text & "','1',0,'" & HrTiempo & "','" & HrEntrega & "')"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()
                    End If

                    If MYCODE = "WXYZ" Then

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO comandas(Id,NMESA,Codigo,Nombre,UVenta,Cantidad,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT) VALUES(" & CFOLIO & ",'" & FOLIO1 & "','" & MYCODE & "','" & MYDESC & "','PZA'," & MYCANT & ",0,0," & MYPRECIO & "," & TOTALC & "," & MYPRECIO & "," & TOTALC & ",'" & drawline & "','" & Format(Date.Now, "yyyy-MM-dd") & "','UNCIO','UNICO','" & COMENSAL & "','RESTA','" & COMENTARIO & "','UNICO','" & lblmesero.Text & "',1,0,'" & HrTiempo & "','" & HrEntrega & "')"
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "INSERT INTO rep_comandas(Id,NMESA,Codigo,Nombre,UVenta,Cantidad,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT) VALUES(" & CFOLIO & ",'" & FOLIO1 & "','" & MYCODE & "','" & MYDESC & "','PZA'," & MYCANT & ",0,0," & MYPRECIO & "," & TOTALC & "," & MYPRECIO & "," & TOTALC & ",'" & drawline & "','" & Format(Date.Now, "yyyy/MM/dd") & "','UNICO','UNICO','" & COMENSAL & "','ORDENADA','" & COMENTARIO & "','UNICO','" & lblmesero.Text & "','1',0,'" & HrTiempo & "','" & HrEntrega & "')"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()
                    End If


                End If
            End If
        Next

        Dim tamticket As Integer = 0

        Dim impresoracomanda As String = ""

        tamticket = TamImpre()

        cnn4.Close() : cnn4.Open()
        cmd4 = cnn4.CreateCommand
        cmd4.CommandText = "SELECT DISTINCT GPrint FROM Comandas WHERE Nmesa='" & lblMesa.Text & "' AND Id=" & CFOLIO
        rd4 = cmd4.ExecuteReader
        If rd4.Read Then
            If rd4.HasRows Then
                rutacomanda = rd4(0).ToString

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT Impresora from rutasimpresion where Tipo='" & rutacomanda & "' AND Equipo='" & ObtenerNombreEquipo() & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        impresoracomanda = rd3(0).ToString
                    End If
                End If
                rd3.Close()

                If impresoracomanda = "" Then
                Else
                    If tamticket = 80 Then
                        PComanda80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda

                        If PComanda80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda Then
                            PComanda80.Print()
                        Else
                            MsgBox("La impresora no esta configurada", vbInformation + vbOKOnly, titulorestaurante)
                            GoTo safo
                        End If
                    End If

                    If tamticket = 58 Then
                        PComanda58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                        If PComanda58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda Then
                            PComanda58.Print()
                        Else
                            GoTo safo
                        End If
                    End If
                End If

            End If
        End If
        rd4.Close()
        cnn4.Close()
        cnn3.Close()
safo:

        grdCaptura.Rows.Clear()
        lblTotalVenta.Text = "0.00"
        Me.Close()
        frmMesas.Show()
    End Sub

    Private Sub PComanda80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PComanda80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)

        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)

        Dim Y As Double = 0
        Dim SinNumCoemensal As Integer = 0

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select NotasCred from Formatos where Facturas='SinNumComensal'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    SinNumCoemensal = rd2(0).ToString
                End If
            Else
                SinNumCoemensal = 0
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If

                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If

                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd2("Cab6").ToString <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 4
                End If
            Else
            End If
            rd2.Close()

            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("C O M A N D A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            If SinNumCoemensal = 1 Then
                e.Graphics.DrawString("MESA: " & lblMesa.Text, fuente_datos, Brushes.Black, 1, Y)
                Y += 15
            Else
                e.Graphics.DrawString("N° MESA: " & lblMesa.Text, fuente_datos, Brushes.Black, 1, Y)
                e.Graphics.DrawString("Comensales: " & "1", fuente_datos, Brushes.Black, 285, Y, sf)
                Y += 15
            End If

            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 150, Y, sf)
            Y += 6
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            Dim codigo As String = ""
            Dim nombre As String = ""
            Dim cantidad As Double = 0
            Dim comensall As String = ""
            Dim comentario As String = ""
            Dim tiempo As String = ""
            Dim idc As Integer = 0

            If SinNumCoemensal = 1 Then

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select IDC,Codigo,Nombre,Cantidad,Comensal,Comentario,Comisionista from Comandas WHERE GPrint='" & rutacomanda & "' AND Id=" & CFOLIO & " group by Comensal,IDC,Codigo,Nombre,Cantidad,Comentario,Comisionista order by comensal"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        codigo = rd1("Codigo").ToString
                        nombre = rd1("Nombre").ToString
                        cantidad = rd1("Cantidad").ToString
                        comensall = rd1("Comensal").ToString
                        comentario = rd1("Comentario").ToString
                        tiempo = rd1("Comisionita").ToString

                        idc = rd1("IDC").ToString


                        e.Graphics.DrawString(cantidad, fuente_datos, Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 30
                        Dim texto As String = nombre
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                            Y += 15
                            inicio += caracteresPorLinea
                        End While

                        If comentario <> "" Then
                            e.Graphics.DrawString("NOTA: " & comentario, fuente_datos, Brushes.Black, 1, Y)
                            Y += 15
                        End If


                        If tiempo <> "" Then
                            e.Graphics.DrawString("------------" & tiempo & "--------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 20
                        End If

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Else
                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT DISTINCT Comisionista FROM comandas WHERE Id=" & CFOLIO & ""
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    If rd2.HasRows Then
                        tiempo = rd2("Comisionista").ToString


                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "select IDC,Codigo,Nombre,Cantidad,Comensal,Comentario,Gprint,Comisionista from Comandas where id=" & CFOLIO & " and GPrint='" & rutacomanda & "' AND Comisionista='" & tiempo & "' group by Comensal,IDC,Codigo,Nombre,Cantidad,Comentario,Gprint,Comisionista Order By Comensal"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            If rd1.HasRows Then
                                codigo = rd1("Codigo").ToString
                                nombre = rd1("Nombre").ToString
                                cantidad = rd1("Cantidad").ToString
                                comensall = rd1("Comensal").ToString
                                comentario = rd1("Comentario").ToString
                                idc = rd1("IDC").ToString



                                e.Graphics.DrawString(cantidad, fuente_datos, Brushes.Black, 1, Y)

                                Dim caracteresPorLinea As Integer = 30
                                Dim texto As String = nombre
                                Dim inicio As Integer = 0
                                Dim longitudTexto As Integer = texto.Length

                                While inicio < longitudTexto
                                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                                    e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                                    Y += 15
                                    inicio += caracteresPorLinea
                                End While


                                If comentario <> "" Then
                                    e.Graphics.DrawString("NOTA: " & comentario, fuente_datos, Brushes.Black, 1, Y)
                                    Y += 15
                                End If

                            End If
                        Loop
                        rd1.Close()

                        If tiempo <> "" Then
                            e.Graphics.DrawString("------------" & tiempo & "--------------", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 20
                        End If

                    End If
                Loop
                rd2.Close()
                cnn2.Close()
                cnn1.Close()

                e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            End If
            Y += 15
            e.Graphics.DrawString("MESERO: ", fuente_datos, Brushes.Black, 1, Y)
            e.Graphics.DrawString(lblmesero.Text, fuente_prods, Brushes.Black, 70, Y)

            cnn2.Close()
            cnn1.Close()

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

            cnn2.Close()
            cnn1.Close()
        End Try
    End Sub

    Private Sub PComanda58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PComanda58.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim pluma As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim SinNumCoemensal As Integer = 0

        Dim conta As Integer = 0
        Dim contband As Integer = 0
        Dim comen_sal As String = ""

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select NotasCred from Formatos where Facturas='SinNumComensal'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    SinNumCoemensal = rd2(0).ToString
                End If
            Else
                SinNumCoemensal = 0
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, fuente_c, Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If

                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, fuente_c, Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If

                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, fuente_c, Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, fuente_c, Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, fuente_c, Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, fuente_c, Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd2("Cab6").ToString <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, fuente_c, Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    Y += 4
                End If
            Else
            End If
            rd2.Close()

            e.Graphics.DrawString("-------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 14

            e.Graphics.DrawString("C O M A N D A", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("-------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 17

            e.Graphics.DrawString("Folio: " & MyFolio, fuente_b, Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongTime), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 18
            e.Graphics.DrawString("-------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 16

            If SinNumCoemensal = 1 Then
                e.Graphics.DrawString("MESA: " & lblMesa.Text, fuente_b, Brushes.Black, 1, Y)
                Y += 14
            Else
                e.Graphics.DrawString("NMESA: " & lblMesa.Text, fuente_b, Brushes.Black, 1, Y)
                Y += 11
                e.Graphics.DrawString("Comensales: " & "1", fuente_b, Brushes.Black, 1, Y)
                Y += 14
            End If

            e.Graphics.DrawString("-------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 13

            e.Graphics.DrawString("CANTIDAD", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRODUCTO", fuente_b, Brushes.Black, 130, Y, derecha)
            Y += 6
            e.Graphics.DrawString("-------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 14

            Dim codigo As String = ""
            Dim nombre As String = ""
            Dim cantidad As Double = 0
            Dim comensall As String = ""
            Dim comentario As String = ""
            Dim idc As Integer = 0
            Dim tiempo As String = ""
            If SinNumCoemensal = 1 Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select IDC,Codigo,Nombre,Cantidad,Comensal,Comentario,Comisionista from Comandas  where GPrint='" & rutacomanda & "' and Id=" & CFOLIO & " group by Comensal,IDC,Codigo,Nombre,Cantidad,Comentario,Comisionista order by comensal"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        codigo = rd1("Codigo").ToString
                        nombre = rd1("Nombre").ToString
                        cantidad = rd1("Cantidad").ToString
                        comensall = rd1("Comensal").ToString
                        comentario = rd1("Comentario").ToString
                        tiempo = rd1("Comisionista").ToString

                        idc = rd1("IDC").ToString

                        e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 25
                        Dim texto As String = nombre
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                            Y += 15
                            inicio += caracteresPorLinea
                        End While


                        If comentario <> "" Then
                            e.Graphics.DrawString("NOTA: " & comentario, fuente_b, Brushes.Black, 1, Y)
                            Y += 13
                        End If

                        If tiempo = "LN" Then
                            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 15
                        End If

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                e.Graphics.DrawString("-------------------------------", fuente_b, Brushes.Black, 1, Y)
            Else
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select IDC,Codigo,Nombre,Cantidad,Comensal,Comentario,Gprint,Comisionista from Comandas where id=" & CFOLIO & " and GPrint='" & rutacomanda & "' group by Comensal,IDC,Codigo,Nombre,Cantidad,Comentario,Gprint,Comisionista Order By Comensal"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        codigo = rd1("Codigo").ToString
                        nombre = rd1("Nombre").ToString
                        cantidad = rd1("Cantidad").ToString
                        comensall = rd1("Comensal").ToString
                        comentario = rd1("Comentario").ToString
                        tiempo = rd1("Comisionista").ToString
                        idc = rd1("IDC").ToString

                        e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 25
                        Dim texto As String = nombre
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                            Y += 15
                            inicio += caracteresPorLinea
                        End While

                        If comentario <> "" Then
                            e.Graphics.DrawString("NOTA: " & comentario, fuente_b, Brushes.Black, 1, Y)
                            Y += 14
                        End If

                        If tiempo = "LN" Then
                            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                            Y += 15
                        End If

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                e.Graphics.DrawString("-------------------------------", fuente_b, Brushes.Black, 1, Y)
            End If
            Y += 13
            e.Graphics.DrawString("MESERO: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(lblmesero.Text, fuente_b, Brushes.Black, 70, Y)

            cnn2.Close()
            cnn1.Close()

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

            cnn2.Close()
            cnn1.Close()
        End Try
    End Sub

End Class