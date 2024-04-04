
Imports System.IO
Public Class frmServicioCuarto

    Dim TotDeptosh As Integer = 0
    Dim TotGruposh As Integer = 0
    Dim totProductosh As Integer = 0

    Public CodigoProducto As String = 0


    Public descripcion As String = ""
    Dim unidad As String = ""
    Dim minimo As Double = 0
    Dim MyMultiplo As Double = 0
    Dim existencia As Double = 0
    Dim cantidad As String = ""
    Dim precio As Double = 0
    Dim importe As Double = 0

    Dim comanda As String = ""
    Dim Hab() As String
    Friend WithEvents btnDeptoH, btnGrupoH, btnProdH As System.Windows.Forms.Button

    Dim seleccionarcodigo As String = ""
    Dim seleccionanombre As String = ""
    Dim banderacantidad As Integer = 0
    Dim banderaprecio As Integer = 0

    Private Sub frmServicioCuarto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TFecha.Start()
        TFolio.Start()
        TotDeptosh = 0
        Dim nLogo As String = ""
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select distinct Departamento from Productos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then TotDeptosh = TotDeptosh + 1
            Loop
            rd1.Close()


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

            pdepa.Controls.Clear()
            PGrupo.Controls.Clear()
            pproductos.Controls.Clear()
            Departamentos()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try


    End Sub

    Public Sub Departamentos()

        Dim deptosh As Integer = 0
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select distinct Departamento from Productos where Departamento<>'INSUMO' AND Departamento<>'EXTRAS' order by Departamento"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Dim departamento As String = rd1("Departamento").ToString

                    btnDeptoH = New Button
                    btnDeptoH.Text = departamento
                    btnDeptoH.Name = "btnDepto(" & deptosh & ")"
                    btnDeptoH.Left = 0
                    btnDeptoH.Height = 55

                    If TotDeptosh <= 9 Then
                        btnDeptoH.Width = pdepa.Width
                    Else
                        btnDeptoH.Width = pdepa.Width - 17
                    End If

                    btnDeptoH.Top = (deptosh) * (btnDeptoH.Height + 0.5)
                    btnDeptoH.BackColor = pdepa.BackColor
                    btnDeptoH.FlatStyle = FlatStyle.Popup
                    btnDeptoH.FlatAppearance.BorderSize = 0
                    AddHandler btnDeptoH.Click, AddressOf btnDepto_Click
                    pdepa.Controls.Add(btnDeptoH)
                    If deptosh = 0 Then
                        Grupos(departamento)
                    End If
                    deptosh += 1
                End If
            End If
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

        PGrupo.Controls.Clear()
        pproductos.Controls.Clear()

        If cnn2.State = 1 Then
            cnn2.Close()
        End If

        totProductosh = 0
        Grupos(btnDepartamento.Text)
    End Sub

    Public Sub Grupos(ByVal depto As String)
        Dim grupos As Integer = 0
        TotGruposh = 0
        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT Grupo FROM Productos WHERE Departamento='" & depto & "' AND Grupo<>'EXTRAS' ORDER BY Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    TotGruposh = TotGruposh + 1
                End If
            Loop
            rd2.Close()

            If TotGruposh <= 9 Then
                PGrupo.AutoScroll = False
            Else
                PGrupo.AutoScroll = True
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT distinct Grupo FROM Productos WHERE Departamento='" & depto & "'AND Grupo<>'EXTRAS' order by Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    Dim grupo As String = rd2(0).ToString
                    btnGrupoH = New Button
                    btnGrupoH.Text = grupo
                    btnGrupoH.Tag = depto
                    btnGrupoH.Name = "btnGrupo(" & grupos & ")"
                    btnGrupoH.Height = 55
                    btnGrupoH.Left = 0

                    If TotGruposh <= 9 Then
                        btnGrupoH.Width = PGrupo.Width
                    Else
                        btnGrupoH.Width = PGrupo.Width - 17
                    End If
                    btnGrupoH.Top = grupos * (btnGrupoH.Height + 0.5)
                    btnGrupoH.BackColor = PGrupo.BackColor
                    btnGrupoH.FlatStyle = FlatStyle.Popup
                    btnGrupoH.FlatAppearance.BorderSize = 0
                    AddHandler btnGrupoH.Click, AddressOf btnGrupo_Click
                    PGrupo.Controls.Add(btnGrupoH)
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
        pproductos.Controls.Clear()
        If cnn3.State = 1 Then
            cnn3.Close()
        End If
        TotDeptosh = 0
        Productos(btnGrupos.Tag, btnGrupos.Text)
    End Sub

    Public Sub Productos(ByVal depto As String, ByVal grupo As String)

        Dim prods As Integer = 1
        Dim cuantos As UInteger = Math.Truncate(pproductos.Height / 70)

        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre,Codigo FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre,Codigo"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    totProductosh = totProductosh + 1
                End If
            Loop
            rd3.Close()

            If totProductosh <= 10 Then
                pproductos.AutoScroll = False
            Else
                pproductos.AutoScroll = True
            End If

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre,Codigo FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre,Codigo"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    Dim producto As String = rd3(0).ToString
                    btnProdH = New Button
                    btnProdH.Text = producto
                    btnProdH.Tag = rd3(1).ToString
                    btnProdH.Name = "btnProducto(" & prods & ")"
                    btnProdH.Height = 70
                    btnProdH.Width = 130

                    If prods > cuantos And prods < ((cuantos * 2) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 1)
                        btnProdH.Top = (prods - (cuantos + 1)) * (btnProdH.Height + 0.5)
                        '2
                    ElseIf prods > (cuantos * 2) And prods < ((cuantos * 3) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 2)
                        btnProdH.Top = (prods - ((cuantos * 2) + 1)) * (btnProdH.Height + 0.5)
                        '3
                    ElseIf prods > (cuantos * 3) And prods < ((cuantos * 4) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 3)
                        btnProdH.Top = (prods - ((cuantos * 3) + 1)) * (btnProdH.Height + 0.5)
                        '4
                    ElseIf prods > (cuantos * 4) And prods < ((cuantos * 5) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 4)
                        btnProdH.Top = (prods - ((cuantos * 4) + 1)) * (btnProdH.Height + 0.5)
                        '5
                    ElseIf prods > (cuantos * 5) And prods < ((cuantos * 6) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 5)
                        btnProdH.Top = (prods - ((cuantos * 5) + 1)) * (btnProdH.Height + 0.5)
                        '6
                    ElseIf prods > (cuantos * 6) And prods < ((cuantos * 7) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 6)
                        btnProdH.Top = (prods - ((cuantos * 6) + 1)) * (btnProdH.Height + 0.5)
                        '7
                    ElseIf prods > (cuantos * 7) And prods < ((cuantos * 8) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 7)
                        btnProdH.Top = (prods - ((cuantos * 7) + 1)) * (btnProdH.Height + 0.5)
                        '8
                    ElseIf prods > (cuantos * 8) And prods < ((cuantos * 9) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 8)
                        btnProdH.Top = (prods - ((cuantos * 8) + 1)) * (btnProdH.Height + 0.5)
                        '9
                    ElseIf prods > (cuantos * 9) And prods < ((cuantos * 10) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 9)
                        btnProdH.Top = (prods - ((cuantos * 9) + 1)) * (btnProdH.Height + 0.5)
                        '10
                    ElseIf prods > (cuantos * 10) And prods < ((cuantos * 11) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 10)
                        btnProdH.Top = (prods - ((cuantos * 10) + 1)) * (btnProdH.Height + 0.5)
                        '11
                    ElseIf prods > (cuantos * 11) And prods < ((cuantos * 12) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 11)
                        btnProdH.Top = (prods - ((cuantos * 11) + 1)) * (btnProdH.Height + 0.5)
                        '12
                    ElseIf prods > (cuantos * 12) And prods < ((cuantos * 13) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 12)
                        btnProdH.Top = (prods - ((cuantos * 12) + 1)) * (btnProdH.Height + 0.5)
                        '13
                    ElseIf prods > (cuantos * 13) And prods < ((cuantos * 14) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 13)
                        btnProdH.Top = (prods - ((cuantos * 13) + 1)) * (btnProdH.Height + 0.5)
                        '14
                    ElseIf prods > (cuantos * 14) And prods < ((cuantos * 15) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 14)
                        btnProdH.Top = (prods - ((cuantos * 14) + 1)) * (btnProdH.Height + 0.5)
                        '15
                    ElseIf prods > (cuantos * 15) And prods < ((cuantos * 16) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 15)
                        btnProdH.Top = (prods - ((cuantos * 15) + 1)) * (btnProdH.Height + 0.5)
                        '16
                    ElseIf prods > (cuantos * 16) And prods < ((cuantos * 17) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 16)
                        btnProdH.Top = (prods - ((cuantos * 16) + 1)) * (btnProdH.Height + 0.5)
                        '17
                    ElseIf prods > (cuantos * 17) And prods < ((cuantos * 18) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 17)
                        btnProdH.Top = (prods - ((cuantos * 17) + 1)) * (btnProdH.Height + 0.5)
                        '18
                    ElseIf prods > (cuantos * 18) And prods < ((cuantos * 19) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 18)
                        btnProdH.Top = (prods - ((cuantos * 18) + 1)) * (btnProdH.Height + 0.5)
                        '19
                    ElseIf prods > (cuantos * 19) And prods < ((cuantos * 20) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 19)
                        btnProdH.Top = (prods - ((cuantos * 19) + 1)) * (btnProdH.Height + 0.5)
                        '20
                    ElseIf prods > (cuantos * 20) And prods < ((cuantos * 21) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 20)
                        btnProdH.Top = (prods - ((cuantos * 20) + 1)) * (btnProdH.Height + 0.5)
                        '21
                    ElseIf prods > (cuantos * 21) And prods < ((cuantos * 22) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 21)
                        btnProdH.Top = (prods - ((cuantos * 21) + 1)) * (btnProdH.Height + 0.5)
                        '22
                    ElseIf prods > (cuantos * 22) And prods < ((cuantos * 23) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 22)
                        btnProdH.Top = (prods - ((cuantos * 22) + 1)) * (btnProdH.Height + 0.5)
                        '23
                    ElseIf prods > (cuantos * 23) And prods < ((cuantos * 24) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 23)
                        btnProdH.Top = (prods - ((cuantos * 23) + 1)) * (btnProdH.Height + 0.5)
                        '24
                    ElseIf prods > (cuantos * 24) And prods < ((cuantos * 25) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 24)
                        btnProdH.Top = (prods - ((cuantos * 24) + 1)) * (btnProdH.Height + 0.5)
                        '25
                    ElseIf prods > (cuantos * 25) And prods < ((cuantos * 26) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 25)
                        btnProdH.Top = (prods - ((cuantos * 25) + 1)) * (btnProdH.Height + 0.5)
                        '26
                    ElseIf prods > (cuantos * 26) And prods < ((cuantos * 27) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 26)
                        btnProdH.Top = (prods - ((cuantos * 26) + 1)) * (btnProdH.Height + 0.5)
                        '27
                    ElseIf prods > (cuantos * 27) And prods < ((cuantos * 28) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 27)
                        btnProdH.Top = (prods - ((cuantos * 27) + 1)) * (btnProdH.Height + 0.5)
                        '28
                    ElseIf prods > (cuantos * 28) And prods < ((cuantos * 29) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 28)
                        btnProdH.Top = (prods - ((cuantos * 28) + 1)) * (btnProdH.Height + 0.5)
                        '29
                    ElseIf prods > (cuantos * 29) And prods < ((cuantos * 30) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 29)
                        btnProdH.Top = (prods - ((cuantos * 29) + 1)) * (btnProdH.Height + 0.5)
                        '30
                    ElseIf prods > (cuantos * 30) And prods < ((cuantos * 31) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 30)
                        btnProdH.Top = (prods - ((cuantos * 30) + 1)) * (btnProdH.Height + 0.5)
                        '31
                    ElseIf prods > (cuantos * 31) And prods < ((cuantos * 32) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 31)
                        btnProdH.Top = (prods - ((cuantos * 31) + 1)) * (btnProdH.Height + 0.5)
                        '32
                    ElseIf prods > (cuantos * 32) And prods < ((cuantos * 33) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 32)
                        btnProdH.Top = (prods - ((cuantos * 32) + 1)) * (btnProdH.Height + 0.5)
                        '33
                    ElseIf prods > (cuantos * 33) And prods < ((cuantos * 34) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 33)
                        btnProdH.Top = (prods - ((cuantos * 33) + 1)) * (btnProdH.Height + 0.5)
                        '34
                    ElseIf prods > (cuantos * 34) And prods < ((cuantos * 35) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 34)
                        btnProdH.Top = (prods - ((cuantos * 34) + 1)) * (btnProdH.Height + 0.5)
                        '35
                    ElseIf prods > (cuantos * 35) And prods < ((cuantos * 36) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 35)
                        btnProdH.Top = (prods - ((cuantos * 35) + 1)) * (btnProdH.Height + 0.5)
                        '36
                    ElseIf prods > (cuantos * 36) And prods < ((cuantos * 37) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 36)
                        btnProdH.Top = (prods - ((cuantos * 36) + 1)) * (btnProdH.Height + 0.5)
                        '37
                    ElseIf prods > (cuantos * 37) And prods < ((cuantos * 38) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 37)
                        btnProdH.Top = (prods - ((cuantos * 37) + 1)) * (btnProdH.Height + 0.5)
                        '38
                    ElseIf prods > (cuantos * 38) And prods < ((cuantos * 39) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 38)
                        btnProdH.Top = (prods - ((cuantos * 38) + 1)) * (btnProdH.Height + 0.5)
                        '39
                    ElseIf prods > (cuantos * 39) And prods < ((cuantos * 40) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 39)
                        btnProdH.Top = (prods - ((cuantos * 39) + 1)) * (btnProdH.Height + 0.5)
                        '40
                    ElseIf prods > (cuantos * 40) And prods < ((cuantos * 41) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 40)
                        btnProdH.Top = (prods - ((cuantos * 40) + 1)) * (btnProdH.Height + 0.5)
                        '41
                    ElseIf prods > (cuantos * 41) And prods < ((cuantos * 42) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 41)
                        btnProdH.Top = (prods - ((cuantos * 41) + 1)) * (btnProdH.Height + 0.5)
                        '42
                    ElseIf prods > (cuantos * 42) And prods < ((cuantos * 43) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 42)
                        btnProdH.Top = (prods - ((cuantos * 42) + 1)) * (btnProdH.Height + 0.5)
                        '43
                    ElseIf prods > (cuantos * 43) And prods < ((cuantos * 44) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 43)
                        btnProdH.Top = (prods - ((cuantos * 43) + 1)) * (btnProdH.Height + 0.5)
                        '44
                    ElseIf prods > (cuantos * 44) And prods < ((cuantos * 45) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 44)
                        btnProdH.Top = (prods - ((cuantos * 44) + 1)) * (btnProdH.Height + 0.5)
                        '45
                    ElseIf prods > (cuantos * 45) And prods < ((cuantos * 46) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 45)
                        btnProdH.Top = (prods - ((cuantos * 45) + 1)) * (btnProdH.Height + 0.5)
                        '46
                    ElseIf prods > (cuantos * 46) And prods < ((cuantos * 47) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 46)
                        btnProdH.Top = (prods - ((cuantos * 46) + 1)) * (btnProdH.Height + 0.5)
                        '47
                    ElseIf prods > (cuantos * 47) And prods < ((cuantos * 48) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 47)
                        btnProdH.Top = (prods - ((cuantos * 47) + 1)) * (btnProdH.Height + 0.5)
                        '48
                    ElseIf prods > (cuantos * 48) And prods < ((cuantos * 49) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 48)
                        btnProdH.Top = (prods - ((cuantos * 48) + 1)) * (btnProdH.Height + 0.5)
                        '49
                    ElseIf prods > (cuantos * 49) And prods < ((cuantos * 50) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 49)
                        btnProdH.Top = (prods - ((cuantos * 49) + 1)) * (btnProdH.Height + 0.5)
                        '50
                    ElseIf prods > (cuantos * 50) And prods < ((cuantos * 51) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 50)
                        btnProdH.Top = (prods - ((cuantos * 50) + 1)) * (btnProdH.Height + 0.5)
                        '51
                    ElseIf prods > (cuantos * 51) And prods < ((cuantos * 52) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 51)
                        btnProdH.Top = (prods - ((cuantos * 51) + 1)) * (btnProdH.Height + 0.5)
                        '52
                    ElseIf prods > (cuantos * 52) And prods < ((cuantos * 53) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 52)
                        btnProdH.Top = (prods - ((cuantos * 52) + 1)) * (btnProdH.Height + 0.5)
                        '53
                    ElseIf prods > (cuantos * 53) And prods < ((cuantos * 54) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 53)
                        btnProdH.Top = (prods - ((cuantos * 53) + 1)) * (btnProdH.Height + 0.5)
                        '54
                    ElseIf prods > (cuantos * 54) And prods < ((cuantos * 55) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 54)
                        btnProdH.Top = (prods - ((cuantos * 54) + 1)) * (btnProdH.Height + 0.5)
                        '55
                    ElseIf prods > (cuantos * 55) And prods < ((cuantos * 56) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 55)
                        btnProdH.Top = (prods - ((cuantos * 55) + 1)) * (btnProdH.Height + 0.5)
                        '56
                    ElseIf prods > (cuantos * 56) And prods < ((cuantos * 57) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 56)
                        btnProdH.Top = (prods - ((cuantos * 56) + 1)) * (btnProdH.Height + 0.5)
                        '57
                    ElseIf prods > (cuantos * 57) And prods < ((cuantos * 58) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 57)
                        btnProdH.Top = (prods - ((cuantos * 57) + 1)) * (btnProdH.Height + 0.5)
                        '58
                    ElseIf prods > (cuantos * 58) And prods < ((cuantos * 59) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 58)
                        btnProdH.Top = (prods - ((cuantos * 58) + 1)) * (btnProdH.Height + 0.5)
                        '59
                    ElseIf prods > (cuantos * 59) And prods < ((cuantos * 60) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 59)
                        btnProdH.Top = (prods - ((cuantos * 59) + 1)) * (btnProdH.Height + 0.5)
                        '60
                    ElseIf prods > (cuantos * 60) And prods < ((cuantos * 61) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 60)
                        btnProdH.Top = (prods - ((cuantos * 60) + 1)) * (btnProdH.Height + 0.5)
                        '61
                    ElseIf prods > (cuantos * 61) And prods < ((cuantos * 62) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 61)
                        btnProdH.Top = (prods - ((cuantos * 61) + 1)) * (btnProdH.Height + 0.5)
                        '62
                    ElseIf prods > (cuantos * 62) And prods < ((cuantos * 63) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 62)
                        btnProdH.Top = (prods - ((cuantos * 62) + 1)) * (btnProdH.Height + 0.5)
                        '63
                    ElseIf prods > (cuantos * 63) And prods < ((cuantos * 64) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 63)
                        btnProdH.Top = (prods - ((cuantos * 63) + 1)) * (btnProdH.Height + 0.5)
                        '64
                    ElseIf prods > (cuantos * 64) And prods < ((cuantos * 65) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 64)
                        btnProdH.Top = (prods - ((cuantos * 64) + 1)) * (btnProdH.Height + 0.5)
                        '65
                    ElseIf prods > (cuantos * 65) And prods < ((cuantos * 66) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 65)
                        btnProdH.Top = (prods - ((cuantos * 65) + 1)) * (btnProdH.Height + 0.5)
                        '66
                    ElseIf prods > (cuantos * 66) And prods < ((cuantos * 67) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 66)
                        btnProdH.Top = (prods - ((cuantos * 66) + 1)) * (btnProdH.Height + 0.5)
                        '67
                    ElseIf prods > (cuantos * 67) And prods < ((cuantos * 68) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 67)
                        btnProdH.Top = (prods - ((cuantos * 67) + 1)) * (btnProdH.Height + 0.5)
                        '68
                    ElseIf prods > (cuantos * 68) And prods < ((cuantos * 69) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 68)
                        btnProdH.Top = (prods - ((cuantos * 68) + 1)) * (btnProdH.Height + 0.5)
                        '69
                    ElseIf prods > (cuantos * 69) And prods < ((cuantos * 70) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 69)
                        btnProdH.Top = (prods - ((cuantos * 69) + 1)) * (btnProdH.Height + 0.5)
                        '70
                    ElseIf prods > (cuantos * 70) And prods < ((cuantos * 71) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 70)
                        btnProdH.Top = (prods - ((cuantos * 70) + 1)) * (btnProdH.Height + 0.5)
                        '71
                    ElseIf prods > (cuantos * 71) And prods < ((cuantos * 72) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 71)
                        btnProdH.Top = (prods - ((cuantos * 71) + 1)) * (btnProdH.Height + 0.5)
                        '72
                    ElseIf prods > (cuantos * 72) And prods < ((cuantos * 73) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 72)
                        btnProdH.Top = (prods - ((cuantos * 72) + 1)) * (btnProdH.Height + 0.5)
                        '73
                    ElseIf prods > (cuantos * 73) And prods < ((cuantos * 74) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 73)
                        btnProdH.Top = (prods - ((cuantos * 73) + 1)) * (btnProdH.Height + 0.5)
                        '74
                    ElseIf prods > (cuantos * 74) And prods < ((cuantos * 75) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 74)
                        btnProdH.Top = (prods - ((cuantos * 74) + 1)) * (btnProdH.Height + 0.5)
                        '75
                    ElseIf prods > (cuantos * 75) And prods < ((cuantos * 76) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 75)
                        btnProdH.Top = (prods - ((cuantos * 75) + 1)) * (btnProdH.Height + 0.5)
                        '76
                    ElseIf prods > (cuantos * 76) And prods < ((cuantos * 77) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 76)
                        btnProdH.Top = (prods - ((cuantos * 76) + 1)) * (btnProdH.Height + 0.5)
                        '77
                    ElseIf prods > (cuantos * 77) And prods < ((cuantos * 78) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 77)
                        btnProdH.Top = (prods - ((cuantos * 77) + 1)) * (btnProdH.Height + 0.5)
                        '78
                    ElseIf prods > (cuantos * 78) And prods < ((cuantos * 79) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 78)
                        btnProdH.Top = (prods - ((cuantos * 78) + 1)) * (btnProdH.Height + 0.5)
                        '79
                    ElseIf prods > (cuantos * 79) And prods < ((cuantos * 80) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 79)
                        btnProdH.Top = (prods - ((cuantos * 79) + 1)) * (btnProdH.Height + 0.5)
                        '80
                    ElseIf prods > (cuantos * 80) And prods < ((cuantos * 81) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 80)
                        btnProdH.Top = (prods - ((cuantos * 80) + 1)) * (btnProdH.Height + 0.5)
                        '81
                    ElseIf prods > (cuantos * 81) And prods < ((cuantos * 82) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 81)
                        btnProdH.Top = (prods - ((cuantos * 81) + 1)) * (btnProdH.Height + 0.5)
                        '82
                    ElseIf prods > (cuantos * 82) And prods < ((cuantos * 83) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 82)
                        btnProdH.Top = (prods - ((cuantos * 82) + 1)) * (btnProdH.Height + 0.5)
                        '83
                    ElseIf prods > (cuantos * 83) And prods < ((cuantos * 84) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 83)
                        btnProdH.Top = (prods - ((cuantos * 83) + 1)) * (btnProdH.Height + 0.5)
                        '84
                    ElseIf prods > (cuantos * 84) And prods < ((cuantos * 85) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 84)
                        btnProdH.Top = (prods - ((cuantos * 84) + 1)) * (btnProdH.Height + 0.5)
                        '85
                    ElseIf prods > (cuantos * 85) And prods < ((cuantos * 86) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 85)
                        btnProdH.Top = (prods - ((cuantos * 85) + 1)) * (btnProdH.Height + 0.5)
                        '86
                    ElseIf prods > (cuantos * 86) And prods < ((cuantos * 87) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 86)
                        btnProdH.Top = (prods - ((cuantos * 86) + 1)) * (btnProdH.Height + 0.5)
                        '87
                    ElseIf prods > (cuantos * 87) And prods < ((cuantos * 88) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 87)
                        btnProdH.Top = (prods - ((cuantos * 87) + 1)) * (btnProdH.Height + 0.5)
                        '88
                    ElseIf prods > (cuantos * 88) And prods < ((cuantos * 89) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 88)
                        btnProdH.Top = (prods - ((cuantos * 88) + 1)) * (btnProdH.Height + 0.5)
                        '89
                    ElseIf prods > (cuantos * 89) And prods < ((cuantos * 90) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 89)
                        btnProdH.Top = (prods - ((cuantos * 89) + 1)) * (btnProdH.Height + 0.5)
                        '90
                    ElseIf prods > (cuantos * 90) And prods < ((cuantos * 91) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 90)
                        btnProdH.Top = (prods - ((cuantos * 90) + 1)) * (btnProdH.Height + 0.5)
                        '91
                    ElseIf prods > (cuantos * 91) And prods < ((cuantos * 92) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 91)
                        btnProdH.Top = (prods - ((cuantos * 91) + 1)) * (btnProdH.Height + 0.5)
                        '92
                    ElseIf prods > (cuantos * 92) And prods < ((cuantos * 93) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 92)
                        btnProdH.Top = (prods - ((cuantos * 92) + 1)) * (btnProdH.Height + 0.5)
                        '93
                    ElseIf prods > (cuantos * 93) And prods < ((cuantos * 94) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 93)
                        btnProdH.Top = (prods - ((cuantos * 93) + 1)) * (btnProdH.Height + 0.5)
                        '94
                    ElseIf prods > (cuantos * 94) And prods < ((cuantos * 95) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 94)
                        btnProdH.Top = (prods - ((cuantos * 94) + 1)) * (btnProdH.Height + 0.5)
                        '95
                    ElseIf prods > (cuantos * 95) And prods < ((cuantos * 96) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 95)
                        btnProdH.Top = (prods - ((cuantos * 95) + 1)) * (btnProdH.Height + 0.5)
                        '96
                    ElseIf prods > (cuantos * 96) And prods < ((cuantos * 97) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 96)
                        btnProdH.Top = (prods - ((cuantos * 96) + 1)) * (btnProdH.Height + 0.5)
                        '97
                    ElseIf prods > (cuantos * 97) And prods < ((cuantos * 98) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 97)
                        btnProdH.Top = (prods - ((cuantos * 97) + 1)) * (btnProdH.Height + 0.5)
                        '98
                    ElseIf prods > (cuantos * 98) And prods < ((cuantos * 99) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 98)
                        btnProdH.Top = (prods - ((cuantos * 98) + 1)) * (btnProdH.Height + 0.5)
                        '99
                    ElseIf prods > (cuantos * 99) And prods < ((cuantos * 100) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 99)
                        btnProdH.Top = (prods - ((cuantos * 99) + 1)) * (btnProdH.Height + 0.5)
                        '100
                    ElseIf prods > (cuantos * 100) And prods < ((cuantos * 101) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 100)
                        btnProdH.Top = (prods - ((cuantos * 100) + 1)) * (btnProdH.Height + 0.5)
                        '101
                    ElseIf prods > (cuantos * 101) And prods < ((cuantos * 102) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 101)
                        btnProdH.Top = (prods - ((cuantos * 101) + 1)) * (btnProdH.Height + 0.5)
                        '102
                    ElseIf prods > (cuantos * 102) And prods < ((cuantos * 103) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 102)
                        btnProdH.Top = (prods - ((cuantos * 102) + 1)) * (btnProdH.Height + 0.5)
                        '103
                    ElseIf prods > (cuantos * 103) And prods < ((cuantos * 104) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 103)
                        btnProdH.Top = (prods - ((cuantos * 103) + 1)) * (btnProdH.Height + 0.5)
                        '104
                    ElseIf prods > (cuantos * 104) And prods < ((cuantos * 105) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 104)
                        btnProdH.Top = (prods - ((cuantos * 104) + 1)) * (btnProdH.Height + 0.5)
                        '105
                    ElseIf prods > (cuantos * 105) And prods < ((cuantos * 106) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 105)
                        btnProdH.Top = (prods - ((cuantos * 105) + 1)) * (btnProdH.Height + 0.5)
                        '106
                    ElseIf prods > (cuantos * 106) And prods < ((cuantos * 107) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 106)
                        btnProdH.Top = (prods - ((cuantos * 106) + 1)) * (btnProdH.Height + 0.5)
                        '107
                    ElseIf prods > (cuantos * 107) And prods < ((cuantos * 108) + 1) Then
                        btnProdH.Left = (btnProdH.Width * 107)
                        btnProdH.Top = (prods - ((cuantos * 107) + 1)) * (btnProdH.Height + 0.5)

                    Else
                        btnProdH.Left = 0
                        btnProdH.Top = (prods - 1) * (btnProdH.Height + 0.5)
                    End If

                    btnProdH.BackColor = Color.Orange
                    btnProdH.FlatStyle = FlatStyle.Popup
                    btnProdH.FlatAppearance.BorderSize = 0

                    AddHandler btnProdH.Click, AddressOf btnProd_Click
                    pproductos.Controls.Add(btnProdH)
                    If prods = 0 Then

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

    Private Sub lblTotalPagar_TextChanged(sender As Object, e As EventArgs) Handles lblTotalPagar.TextChanged

        If lblTotalPagar.Text = "" Then Exit Sub
        Dim TotalImporte As Double = lblTotalPagar.Text
        Dim CantidadLetra As String = ""

        If TotalImporte > 0 Then
            ' btnPagar.Enabled = True
            CantidadLetra = UCase(convLetras(TotalImporte))
        Else
            'btnPagar.Enabled = False
            CantidadLetra = ""
        End If
        lblCantidadLetra.Text = CantidadLetra

    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim INDEX As Double = grdCaptura.CurrentRow.Index
        Dim IMPORTE = grdCaptura.Rows(INDEX).Cells(4).Value.ToString
        lblTotalPagar.Text = lblTotalPagar.Text - IMPORTE

        lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)

        grdCaptura.Rows.Remove(grdCaptura.CurrentRow)

    End Sub
    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick

        TFecha.Stop()
        Me.Text = "Delsscom® Hotelerias - Ventas Touch" & Strings.Space(50) & Date.Now
        lblFecha.Text = Format(Date.Now, "yyyy/MM/dd")
        TFecha.Start()

    End Sub

    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick

        TFolio.Stop()

        TFolio.Interval = 5000
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Max(Folio) FROM Comanda1"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then


                lblfolio.Text = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) + 1
            Else
                lblfolio.Text = "1"


            End If
        Else
            lblfolio.Text = "1"
        End If
        rd1.Close()
        cnn1.Close()
        TFolio.Start()

    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        EnviarProductoC()
    End Sub

    Public Sub find_preciovta(codigo As String)

        Dim MyPrecio As Double = 0

        Try

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            If txtBarras.Text = "" Then
                cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
            Else
                cmd2.CommandText = "SELECT * FROM Productos WHERE CodBarra='" & codigo & "'"
            End If

            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If PEDI = False Then
                        MyPrecio = rd2("PrecioVentaIVA").ToString
                    ElseIf PEDI = True Then
                        MyPrecio = rd2("PrecioVentaIVA").ToString
                    End If
                    precio = FormatNumber(MyPrecio, 2)
                End If
            End If
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        frmManejo.Show()
        frmManejo.btnLimpiar.PerformClick()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lblTotalPagar.Text = "0.00"
        grdCaptura.Rows.Clear()
        txtBarras.Text = ""
    End Sub

    Private Sub btnProd_Click(sender As Object, e As EventArgs)
        On Error GoTo nopaso
        Dim btnProducto As Button = CType(sender, Button)

        CodigoProducto = ""
        CodigoProducto = btnProducto.Tag

        ObtenerProducto(CodigoProducto)
nopaso:
    End Sub

    Public Sub ObtenerProducto(Codigo As String)
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If txtBarras.Text = "" Then
                cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Codigo & "'"
            Else
                cmd1.CommandText = "SELECT * FROM Productos WHERE CodBarra='" & Codigo & "'"
            End If

            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Departamento").ToString = "SERVICIOS" Then
                        existencia = 0
                    End If

                    descripcion = rd1("Nombre").ToString
                    unidad = rd1("UVenta").ToString
                    minimo = rd1("Min").ToString
                    MyMultiplo = rd1("Multiplo").ToString
                    existencia = rd1("Existencia").ToString
                    'dosxuno = rd1("E1").ToString
                    ' tresxdos = rd1("E2").ToString



                End If
            End If
            rd1.Close()
            cnn1.Close()

            Call find_preciovta(Codigo)
            minimo = existencia

            precio = (precio)
            cantidad = 1
            importe = cantidad * precio

            If importe <> 0 Then
                UpGridCaptura()
            Else
                MsgBox("Este producto no tiene precio de venta, no se agregara en la comanda", vbInformation + vbOKOnly, titulohotelriaa)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub PComandaH80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PComandaH80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)

        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)


        Dim Y As Double = 0
        Dim pie1 As String = ""

        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim cantidad As Double = 0
        Dim comensall As String = ""
        Dim comentario As String = ""
        Dim idc As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    pie1 = rd1("Pie1")

                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If

                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If

                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If

                    If rd1("Cab6").ToString <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 4

                End If
            End If
            rd1.Close()

            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("C O M A N D A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & lblfolio.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 19
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Habitación: " & lblHabitacion.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 150, Y, sf)
            Y += 6
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IDC,Codigo,Nombre,Cantidad,Comensal,Comentario FROM comandas  WHERE GPrint='" & comanda & "' and Id=" & lblfolio.Text & " AND Nmesa='" & lblHabitacion.Text & "' group by Comensal,IDC,Codigo,Nombre,Cantidad,Comentario order by comensal"
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

                    If Mid(nombre, 1, 30) <> "" Then
                        e.Graphics.DrawString(Mid(nombre, 1, 31), fuente_datos, Brushes.Black, 48, Y)
                        Y += 15
                    End If
                    If Mid(nombre, 31, 60) <> "" Then
                        e.Graphics.DrawString(Mid(nombre, 31, 60), fuente_datos, Brushes.Black, 48, Y)
                        Y += 15
                    End If

                    If comentario <> "" Then
                        e.Graphics.DrawString("NOTA: " & comentario, fuente_datos, Brushes.Black, 1, Y)
                        Y += 15
                    End If

                End If
            Loop
            rd1.Close()
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

            Y += 15
            e.Graphics.DrawString("MESERO: ", fuente_datos, Brushes.Black, 1, Y)
            e.Graphics.DrawString(lblAtendio.Text, fuente_prods, Brushes.Black, 70, Y)

            cnn1.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub PComandaH58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PComandaH58.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)

        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)


        Dim Y As Double = 0
        Dim pie1 As String = ""

        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim cantidad As Double = 0
        Dim comensall As String = ""
        Dim comentario As String = ""
        Dim idc As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    pie1 = rd1("Pie1")

                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If

                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If

                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If

                    If rd1("Cab6").ToString <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    Y += 4

                End If
            End If
            rd1.Close()

            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("C O M A N D A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 12
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & lblfolio.Text, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 19
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Habitación: " & lblHabitacion.Text, fuente_datos, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 60, Y, sf)
            Y += 6
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IDC,Codigo,Nombre,Cantidad,Comensal,Comentario FROM comandas  WHERE GPrint='" & comanda & "' and Id=" & lblfolio.Text & " AND Nmesa='" & lblHabitacion.Text & "'  group by Comensal,IDC,Codigo,Nombre,Cantidad,Comentario order by comensal"
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

                    If Mid(nombre, 1, 22) <> "" Then
                        e.Graphics.DrawString(Mid(nombre, 1, 31), fuente_datos, Brushes.Black, 1, Y)
                        Y += 15
                    End If
                    If Mid(nombre, 31, 60) <> "" Then
                        e.Graphics.DrawString(Mid(nombre, 31, 60), fuente_datos, Brushes.Black, 1, Y)
                        Y += 15
                    End If

                    If comentario <> "" Then
                        e.Graphics.DrawString("NOTA: " & comentario, fuente_datos, Brushes.Black, 1, Y)
                        Y += 15
                    End If

                End If
            Loop
            rd1.Close()
            e.Graphics.DrawString("-------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)

            Y += 15
            e.Graphics.DrawString("MESERO: ", fuente_datos, Brushes.Black, 1, Y)
            e.Graphics.DrawString(lblAtendio.Text, fuente_prods, Brushes.Black, 50, Y)

            cnn1.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnCantidad_Click(sender As Object, e As EventArgs) Handles btnCantidad.Click
        PTeclado.Show()
        PTeclado.BringToFront()
    End Sub

    Private Sub grdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellClick

        Dim celda As DataGridViewCellEventArgs = e
        Dim index As Integer = grdCaptura.CurrentRow.Index

        If celda.ColumnIndex = 2 Then
            PTeclado.Show()
            txtRespuesta.Focus.Equals(True)
            txtRespuesta.Text = ""
            gdato.Text = "Cantidad"

            seleccionarcodigo = grdCaptura.Rows(index).Cells(0).Value.ToString
            seleccionanombre = grdCaptura.Rows(index).Cells(1).Value.ToString

            banderacantidad = 1
        End If

        If celda.ColumnIndex = 3 Then
            PTeclado.Show()
            txtRespuesta.Focus.Equals(True)
            txtRespuesta.Text = ""
            gdato.Text = "Cambiar Precio"

            seleccionarcodigo = grdCaptura.Rows(index).Cells(0).Value.ToString
            seleccionanombre = grdCaptura.Rows(index).Cells(1).Value.ToString

            banderaprecio = 1
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        PTeclado.Visible = False
    End Sub
    Public Sub UpGridCaptura()

        Dim TotalVenta As Double = 0

        Try
            With Me.grdCaptura
                Dim banderaproducto As Integer = 0
                banderaproducto = 0

                If banderaproducto = 0 Then
                    grdCaptura.Rows.Add(CodigoProducto,
                        CodigoProducto & vbNewLine & descripcion,
                        1, FormatNumber(precio, 2),
                        FormatNumber(importe, 2),
1, "")
                    lblTotalPagar.Text = lblTotalPagar.Text + importe
                    lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)
                End If
            End With

        Catch ex As Exception

        End Try

    End Sub
    Public Sub EnviarProductoC()

        Dim foliocomanda As Integer = 0
        Dim codigoproc As String = ""

        foliocomanda = lblfolio.Text

        Dim mysubtotal As Double = 0

        For excesos As Integer = 0 To grdCaptura.Rows.Count - 1
            If grdCaptura.Rows(excesos).Cells(0).Value <> "" Then
                Hab = Split(grdCaptura.Rows(excesos).Cells(1).Value.ToString, vbCrLf)
                codigoproc = Hab(0)


                If CodigoProducto <> "WXYZ" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT IVA FROM productos WHERE Codigo='" & codigoproc & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.Read Then

                    End If

                    If grdCaptura.Rows(excesos).Cells(3).Value.ToString <> "" Then
                        If CDec(grdCaptura.Rows(excesos).Cells(3).Value.ToString) > 0 Then
                            mysubtotal = mysubtotal + (CDec(grdCaptura.Rows(excesos).Cells(3).Value.ToString)) / (1 + rd1("IVA").ToString)
                            mysubtotal = FormatNumber(mysubtotal, 2)
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                End If

            End If
        Next excesos

        If grdCaptura.Rows.Count < 1 Then
            Exit Sub
        End If

        If MsgBox("Desea enviar a producccion", vbInformation + vbOKCancel, titulohotelriaa) = vbCancel Then
            Exit Sub
        End If

        'cnn1.Close() : cnn1.Open()
        'cmd1 = cnn1.CreateCommand
        'cmd1.CommandText = "INSERT INTO comanda1(Folio,IdCliente,Nombre,Direccion,Usuario,Fventa,FPago,FCancelado,Status,Comisionista) VALUES(" & foliocomanda & "," & IIf(lblNumCliente.Text = "", 0, lblNumCliente.Text) & ",'" & lblHabitacion.Text & "','','" & lblAtendio.Text & "','" & Format(Date.Now, "yyyy/MM-dd") & "','','','','')"
        'cmd1.ExecuteNonQuery()
        'cnn1.Close()

        Dim habitacion As String = ""
        Dim codigohot As String = ""
        Dim nombrehot As String = ""
        Dim cantidadhot As Double = 0
        Dim preciohot As Double = 0
        Dim totalhot As Double = 0
        Dim comentario As String = ""

        Dim ivahot As Double = 0
        Dim preciosinivahot As Double = 0
        Dim totalsinivahot As Double = 0

        Dim costovue As Double = 0
        Dim promo As Double = 0
        Dim departamentohot As String = ""
        Dim grupohot As String = ""
        Dim mcdhot As Double = 0
        Dim multiplohot As Double = 0
        Dim impresionhot As String = ""
        Dim unidadhot As String = ""

        Dim existenciahot As Double = 0
        Dim multiplo7 As Double = 0

        Dim preciocomprahot As Double = 0

        Dim comandafolio As String = ""

        For crazy As Integer = 0 To grdCaptura.Rows.Count - 1

            habitacion = lblHabitacion.Text
            codigohot = grdCaptura.Rows(crazy).Cells(0).Value.ToString
            Hab = Split(grdCaptura.Rows(crazy).Cells(1).Value.ToString, vbCrLf)
            nombrehot = Hab(1)
            cantidadhot = grdCaptura.Rows(crazy).Cells(2).Value.ToString
            preciohot = grdCaptura.Rows(crazy).Cells(3).Value.ToString
            totalhot = grdCaptura.Rows(crazy).Cells(4).Value.ToString
            comentario = grdCaptura.Rows(crazy).Cells(7).Value
            preciohot = FormatNumber(preciohot, 2)
            totalhot = FormatNumber(totalhot, 2)

            If codigohot <> "WXYZ" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & codigohot & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        ivahot = rd1("IVA").ToString

                        preciosinivahot = IIf(preciohot = 0, 0, preciohot) / (1 + ivahot)
                        totalsinivahot = IIf(totalhot = 0, 0, totalhot) / (1 + ivahot)
                        preciosinivahot = FormatNumber(preciosinivahot, 2)

                        If rd1("Departamento").ToString = "SERVICIOS" Then
                            costovue = 0
                            promo = 0
                            departamentohot = rd1("Departamento").ToString
                            grupohot = rd1("Grupo").ToString
                        End If
                        mcdhot = rd1("MCD").ToString
                        multiplohot = rd1("Multiplo").ToString
                        departamentohot = rd1("Departamento").ToString
                        grupohot = rd1("Grupo").ToString
                        impresionhot = rd1("GPrint").ToString
                        unidadhot = rd1("UVenta").ToString

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & Strings.Left(codigohot, 7) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                existenciahot = rd2("Existencia").ToString / rd2("Multiplo").ToString
                                multiplo7 = rd2("Multiplo").ToString

                                If rd2("Departamento").ToString <> "SERVICIOS" Then
                                    preciocomprahot = rd2("PrecioCompra").ToString
                                    costovue = (preciocomprahot) * (cantidadhot / mcdhot)
                                End If

                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                    End If
                End If
                rd1.Close()
                cnn1.Close()
            End If

            If grdCaptura.Rows(crazy).Cells(0).Value.ToString <> "" Then


                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT MAX(Folio) FROM Comanda1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        comandafolio = rd2(0).ToString
                        lblfolio.Text = comandafolio
                    End If
                Else
                    comandafolio = 0
                    lblfolio.Text = comandafolio + 1
                End If
                rd2.Close()
                cnn2.Close()

                If codigohot <> "WXYZ" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO Comandas(Id,NMESA,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT,Estado) VALUES(" & comandafolio & ",'" & lblHabitacion.Text & "','" & codigohot & "','" & nombrehot & "','" & unidadhot & "'," & cantidadhot & ",0," & costovue & "," & IIf(promo = 0, 0, promo) & "," & preciohot & "," & totalhot & "," & preciosinivahot & "," & totalsinivahot & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','','" & departamentohot & "','" & grupohot & "','1','RESTA','" & comentario & "','" & impresionhot & "','" & lblAtendio.Text & "','1',0,'" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "',0)"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()

                End If

                If codigohot = "WXYZ" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO Comandas(Id,NMESA,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT,Estado) VALUES(" & comandafolio & ",'" & lblHabitacion.Text & "','" & codigohot & "','" & nombrehot & "','" & unidadhot & "'," & cantidadhot & ",0,0,0," & preciohot & "," & totalhot & "," & preciosinivahot & "," & totalsinivahot & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','','UNICO','UNICO','1','RESTA','" & comentario & "','UNICO','" & lblAtendio.Text & "','1',0,'" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "',0)"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()

                End If

                If codigohot <> "WXYZ" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO Rep_Comandas(Id,NMESA,Codigo,Nombre,Cantidad,Uventa,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Grupo,EstatusT,Hr,EntregaT) VALUES(" & lblfolio.Text & ",'" & lblHabitacion.Text & "','" & codigohot & "','" & nombrehot & "'," & cantidadhot & ",'" & unidadhot & "'," & costovue & "," & IIf(promo = 0, 0, promo) & "," & preciohot & "," & totalhot & "," & preciosinivahot & "," & totalhot & ",'','" & Format(Date.Now, "yyyy/MM/dd") & "','" & departamentohot & "','1','ORDENADA','" & comentario & "','" & impresionhot & "','" & Trim(lblAtendio.Text) & "','1','" & grupohot & "',0,'" & HrTiempo & "','" & HrEntrega & "')"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()

                End If

                If codigohot = "WXYZ" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO Rep_Comandas(Id,NMESA,Codigo,Nombre,Cantidad,Uventa,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Grupo,EstatusT,Hr,EntregaT) VALUES(" & lblfolio.Text & ",'" & lblHabitacion.Text & "','" & codigohot & "','" & nombrehot & "'," & cantidadhot & ",'" & unidadhot & "',0,0," & preciohot & "," & totalhot & "," & preciohot & "," & totalhot & ",'','" & Format(Date.Now, "yyyy/MM/dd") & "','UNICO','1','ORDENADA','" & comentario & "','" & DatosRecarga("PRINT_PRED") & "','" & Trim(lblAtendio.Text) & "','1','UNICO',0,'" & HrTiempo & "','" & HrEntrega & "')"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()

                End If

            End If

        Next crazy

        Dim tamimpre As Integer = 0
        Dim impresoracomanda As String = ""



        cnn2.Close() : cnn2.Open()
        cnn3.Close() : cnn3.Open()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                tamimpre = rd2(0).ToString
            End If
        End If
        rd2.Close()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT DISTINCT GPrint FROM comandas WHERE Id=" & lblfolio.Text
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                comanda = rd2(0).ToString
                If comanda = "" Then
                Else
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT Impresora FROM RutasImpresion WHERE Tipo='" & comanda & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            impresoracomanda = rd3(0).ToString
                        End If
                    End If
                    rd3.Close()

                    If tamimpre = 80 Then
                        PComandaH80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                        PComandaH80.Print()
                    End If

                    If tamimpre = 58 Then
                        PComandaH58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                        PComandaH58.Print()
                    End If
                End If


            End If
        Loop
        rd2.Close()
        cnn2.Close()
        cnn3.Close()

        btnLimpiar.PerformClick()
        lblfolio.Text = foliocomanda
        Me.Close()
        frmManejo.Show()
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtRespuesta.Text = txtRespuesta.Text + btn7.Text
    End Sub
    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtRespuesta.Text = txtRespuesta.Text + btn8.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtRespuesta.Text = txtRespuesta.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtRespuesta.Text = txtRespuesta.Text + btn6.Text
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtRespuesta.Text = txtRespuesta.Text + btn1.Text
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtRespuesta.Text = txtRespuesta.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtRespuesta.Text = txtRespuesta.Text + btn3.Text
    End Sub

    Private Sub btnborrar_Click(sender As Object, e As EventArgs) Handles btnborrar.Click
        txtRespuesta.Text = CutCad(txtRespuesta.Text)
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function

    Private Sub btnpunto_Click(sender As Object, e As EventArgs) Handles btnpunto.Click
        txtRespuesta.Text = txtRespuesta.Text + btnpunto.Text
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtRespuesta.Text = txtRespuesta.Text + btn0.Text
    End Sub

    Private Sub txtRespuesta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRespuesta.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtRespuesta.Text) Then

                Dim totaldeventa As Double = 0
                Dim totalnuevo As Double = 0
                Dim banderaproducto As Integer = 0

                With Me.grdCaptura
                    If gdato.Text = "Cantidad" Then
                        If banderacantidad = 1 Then
                            For q As Integer = 0 To grdCaptura.Rows.Count - 1
                                lblTotalPagar.Text = "0.00"
                                If grdCaptura.Rows(q).Cells(0).Value = seleccionarcodigo Then
                                    grdCaptura.Rows(q).Cells(1).Value = seleccionanombre
                                    grdCaptura.Rows(q).Cells(2).Value = FormatNumber(txtRespuesta.Text, 2)
                                    grdCaptura.Rows(q).Cells(3).Value = grdCaptura.Rows(q).Cells(3).Value.ToString
                                    totalnuevo = txtRespuesta.Text * grdCaptura.Rows(q).Cells(3).Value.ToString
                                    grdCaptura.Rows(q).Cells(4).Value = FormatNumber(totalnuevo, 2)

                                    lblTotalPagar.Text = lblTotalPagar.Text + totalnuevo
                                    lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)
                                    banderaproducto = 1
                                End If
                            Next
                        End If
                    End If


                    If gdato.Text = "Cambiar Precio" Then
                        Dim idempleado As Integer = 0

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT IdEmpleado FROM usuarios WHERE Alias='" & lblAtendio.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                idempleado = rd3(0).ToString

                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "SELECT Prod_pre FROM permisos WHERE IdEmpleado=" & idempleado & ""
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    If rd2.Read Then
                                        If rd2(0).ToString = 1 Then
                                            If banderaprecio = 1 Then
                                                For q As Integer = 0 To grdCaptura.Rows.Count - 1
                                                    lblTotalPagar.Text = "0.00"
                                                    If grdCaptura.Rows(q).Cells(0).Value = seleccionarcodigo Then
                                                        grdCaptura.Rows(q).Cells(1).Value = seleccionanombre
                                                        grdCaptura.Rows(q).Cells(2).Value = grdCaptura.Rows(q).Cells(2).Value
                                                        grdCaptura.Rows(q).Cells(3).Value = txtRespuesta.Text
                                                        totalnuevo = grdCaptura.Rows(q).Cells(2).Value * txtRespuesta.Text
                                                        grdCaptura.Rows(q).Cells(4).Value = FormatNumber(totalnuevo, 2)

                                                        lblTotalPagar.Text = lblTotalPagar.Text + totalnuevo
                                                        lblTotalPagar.Text = FormatNumber(lblTotalPagar.Text, 2)

                                                        banderaproducto = 1
                                                    End If
                                                Next
                                            End If
                                        Else
                                            MsgBox("El usuario no tiene permisos para asignar los precios", vbInformation + vbOKOnly, titulohotelriaa)
                                            txtRespuesta.Text = ""
                                            txtRespuesta.Focus.Equals(True)
                                            Exit Sub
                                        End If
                                    End If
                                Else
                                    MsgBox("El usuario no tiene permisos para asignar los precios", vbInformation + vbOKOnly, titulohotelriaa)
                                    Exit Sub
                                End If
                                rd2.Close()
                                cnn2.Close()
                            End If
                        End If
                        rd3.Close()
                        cnn3.Close()

                    End If
                End With
                banderacantidad = 0
                banderaprecio = 0
                txtRespuesta.Text = ""
                PTeclado.Visible = False
            End If
        End If
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        txtRespuesta_KeyPress(txtRespuesta, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub txtBarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            ObtenerProducto(txtBarras.Text)
            txtBarras.Text = ""
            txtBarras.Focus.Equals(True)
        End If
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtRespuesta.Text = txtRespuesta.Text + btn9.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtRespuesta.Text = txtRespuesta.Text + btn4.Text
    End Sub
End Class