

Imports System.Net
Imports System.IO
Imports Microsoft.VisualBasic.Devices
Imports System.IO.Ports

Public Class frmPolleria

    Private Const V As String = "',')"
    Dim cantidadempleados As Double = 0
    Dim cantidaddepartamentos As Double = 0
    Dim cantidadgrupos As Double = 0
    Dim cantidadproductos As Double = 0

    Dim CodigoProducto As String = ""

    Dim existencia As Double = 0
    Public descripcion As String = ""
    Dim unidadventa As String = ""
    Dim minimo As Double = 0
    Dim ubicacion As String = ""
    Dim multiplo As Double = 0
    Dim dosxuno As Integer = 0
    Dim tresxdos As Integer = 0

    Dim min As Double = 0
    Dim PU As Double = 0
    Dim Importe As Double = 0
    Dim cantidad As Double = 0
    Dim cantidad2 As Double = 0

    Dim foliocomanda1 As Integer = 0
    Dim reportecomanda As Integer = 0

    Dim montomapeo As Double = 0

    Dim contralogueo As String = ""
    Dim usuariologueo As String = ""

    Friend WithEvents btnEmp, btnDepa, btnGrupo, btnProd As System.Windows.Forms.Button

    Public WithEvents serialPortT As New SerialPort()
    Private Sub frmPolleria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT Clave,Alias FROM Usuarios WHERE IdEmpleado=" & id_usu_log
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                contralogueo = rd2(0).ToString
                usuariologueo = rd2(1).ToString

            End If
        End If
        rd2.Close()
        cnn2.Close()

        pEmpleado.Controls.Clear()
        pDepartamento.Controls.Clear()
        pgrupo.Controls.Clear()
        pProductos.Controls.Clear()

        Empleados()
        Departamentos()

    End Sub

    Public Sub Empleados()

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT COUNT(IdEmpleado) FROM Usuarios"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                cantidadempleados = rd1(0).ToString
            End If
        End If
        rd1.Close()


        Dim emple As Integer = 1
        Dim cuantos As Integer = Math.Truncate(pEmpleado.Height / 95)

        Try

            If cantidadempleados <= 8 Then
                pEmpleado.AutoScroll = False
            Else
                pEmpleado.AutoScroll = True
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Alias FROM Usuarios WHERE Alias<>'' AND Status='1' ORDER BY Alias"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim aleas As String = rd1(0).ToString

                    btnEmp = New Button
                    btnEmp.Text = aleas
                    btnEmp.Name = "btnEmp(" & emple & ")"
                    btnEmp.Left = 0
                    btnEmp.Height = 95
                    btnEmp.Width = 96


                    If emple > cuantos And emple < ((cuantos * 2) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 1)
                        btnEmp.Top = (emple - (cuantos + 1)) * (btnEmp.Height + 0.5)
                        '2
                    ElseIf emple > (cuantos * 2) And emple < ((cuantos * 3) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 2)
                        btnEmp.Top = (emple - ((cuantos * 2) + 1)) * (btnEmp.Height + 0.5)
                        '3
                    ElseIf emple > (cuantos * 3) And emple < ((cuantos * 4) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 3)
                        btnEmp.Top = (emple - ((cuantos * 3) + 1)) * (btnEmp.Height + 0.5)
                        '4
                    ElseIf emple > (cuantos * 4) And emple < ((cuantos * 5) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 4)
                        btnEmp.Top = (emple - ((cuantos * 4) + 1)) * (btnEmp.Height + 0.5)
                        '5
                    ElseIf emple > (cuantos * 5) And emple < ((cuantos * 6) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 5)
                        btnEmp.Top = (emple - ((cuantos * 5) + 1)) * (btnEmp.Height + 0.5)
                        '6
                    ElseIf emple > (cuantos * 6) And emple < ((cuantos * 7) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 6)
                        btnEmp.Top = (emple - ((cuantos * 6) + 1)) * (btnEmp.Height + 0.5)
                        '7
                    ElseIf emple > (cuantos * 7) And emple < ((cuantos * 8) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 7)
                        btnEmp.Top = (emple - ((cuantos * 7) + 1)) * (btnEmp.Height + 0.5)
                        '8
                    ElseIf emple > (cuantos * 8) And emple < ((cuantos * 9) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 8)
                        btnEmp.Top = (emple - ((cuantos * 8) + 1)) * (btnEmp.Height + 0.5)
                        '9
                    ElseIf emple > (cuantos * 9) And emple < ((cuantos * 10) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 9)
                        btnEmp.Top = (emple - ((cuantos * 9) + 1)) * (btnEmp.Height + 0.5)
                        '10
                    ElseIf emple > (cuantos * 10) And emple < ((cuantos * 11) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 10)
                        btnEmp.Top = (emple - ((cuantos * 10) + 1)) * (btnEmp.Height + 0.5)
                        '11
                    ElseIf emple > (cuantos * 11) And emple < ((cuantos * 12) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 11)
                        btnEmp.Top = (emple - ((cuantos * 11) + 1)) * (btnEmp.Height + 0.5)
                        '12
                    ElseIf emple > (cuantos * 12) And emple < ((cuantos * 13) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 12)
                        btnEmp.Top = (emple - ((cuantos * 12) + 1)) * (btnEmp.Height + 0.5)
                        '13
                    ElseIf emple > (cuantos * 13) And emple < ((cuantos * 14) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 13)
                        btnEmp.Top = (emple - ((cuantos * 13) + 1)) * (btnEmp.Height + 0.5)
                        '14
                    ElseIf emple > (cuantos * 14) And emple < ((cuantos * 15) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 14)
                        btnEmp.Top = (emple - ((cuantos * 14) + 1)) * (btnEmp.Height + 0.5)
                        '15
                    ElseIf emple > (cuantos * 15) And emple < ((cuantos * 16) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 15)
                        btnEmp.Top = (emple - ((cuantos * 15) + 1)) * (btnEmp.Height + 0.5)
                        '16
                    ElseIf emple > (cuantos * 16) And emple < ((cuantos * 17) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 16)
                        btnEmp.Top = (emple - ((cuantos * 16) + 1)) * (btnEmp.Height + 0.5)
                        '17
                    ElseIf emple > (cuantos * 17) And emple < ((cuantos * 18) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 17)
                        btnEmp.Top = (emple - ((cuantos * 17) + 1)) * (btnEmp.Height + 0.5)
                        '18
                    ElseIf emple > (cuantos * 18) And emple < ((cuantos * 19) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 18)
                        btnEmp.Top = (emple - ((cuantos * 18) + 1)) * (btnEmp.Height + 0.5)
                        '19
                    ElseIf emple > (cuantos * 19) And emple < ((cuantos * 20) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 19)
                        btnEmp.Top = (emple - ((cuantos * 19) + 1)) * (btnEmp.Height + 0.5)
                        '20
                    ElseIf emple > (cuantos * 20) And emple < ((cuantos * 21) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 20)
                        btnEmp.Top = (emple - ((cuantos * 20) + 1)) * (btnEmp.Height + 0.5)
                        '21
                    ElseIf emple > (cuantos * 21) And emple < ((cuantos * 22) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 21)
                        btnEmp.Top = (emple - ((cuantos * 21) + 1)) * (btnEmp.Height + 0.5)
                        '22
                    ElseIf emple > (cuantos * 22) And emple < ((cuantos * 23) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 22)
                        btnEmp.Top = (emple - ((cuantos * 22) + 1)) * (btnEmp.Height + 0.5)
                        '23
                    ElseIf emple > (cuantos * 23) And emple < ((cuantos * 24) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 23)
                        btnEmp.Top = (emple - ((cuantos * 23) + 1)) * (btnEmp.Height + 0.5)
                        '24
                    ElseIf emple > (cuantos * 24) And emple < ((cuantos * 25) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 24)
                        btnEmp.Top = (emple - ((cuantos * 24) + 1)) * (btnEmp.Height + 0.5)
                        '25
                    ElseIf emple > (cuantos * 25) And emple < ((cuantos * 26) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 25)
                        btnEmp.Top = (emple - ((cuantos * 25) + 1)) * (btnEmp.Height + 0.5)
                        '26
                    ElseIf emple > (cuantos * 26) And emple < ((cuantos * 27) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 26)
                        btnEmp.Top = (emple - ((cuantos * 26) + 1)) * (btnEmp.Height + 0.5)
                        '27
                    ElseIf emple > (cuantos * 27) And emple < ((cuantos * 28) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 27)
                        btnEmp.Top = (emple - ((cuantos * 27) + 1)) * (btnEmp.Height + 0.5)
                        '28
                    ElseIf emple > (cuantos * 28) And emple < ((cuantos * 29) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 28)
                        btnEmp.Top = (emple - ((cuantos * 28) + 1)) * (btnEmp.Height + 0.5)
                        '29
                    ElseIf emple > (cuantos * 29) And emple < ((cuantos * 30) + 1) Then
                        btnEmp.Left = (btnEmp.Width * 29)
                        btnEmp.Top = (emple - ((cuantos * 29) + 1)) * (btnEmp.Height + 0.5)
                        '30
                    Else
                        btnEmp.Left = 0
                        btnEmp.Top = (emple - 1) * (btnEmp.Height + 0.5)
                    End If


                    Dim pn As Integer = 0

                    cnn9.Close() : cnn9.Open()
                    cmd9 = cnn9.CreateCommand
                    cmd9.CommandText = "select NMESA from Comandas where NMESA='" & Trim(btnEmp.Text) & "' and Status='RESTA'"
                    rd9 = cmd9.ExecuteReader
                    If rd9.HasRows Then
                        If rd9.Read Then
                            pn = 1

                            If pn <> 0 Then
                                btnEmp.BackColor = Color.FromArgb(255, 128, 0)
                            Else
                                btnEmp.BackColor = Color.FromArgb(255, 255, 128)
                            End If

                        End If
                    Else
                        ' btnMesa2.BackColor = Color.FromArgb(255, 128, 0)
                    End If
                    rd9.Close()
                    cnn9.Close()


                    btnEmp.FlatStyle = FlatStyle.Popup
                    btnEmp.Font = New Font(btnEmp.Font, FontStyle.Bold)
                    btnEmp.FlatAppearance.BorderSize = 0
                    AddHandler btnEmp.Click, AddressOf btnEmp_Click
                    pEmpleado.Controls.Add(btnEmp)
                    My.Application.DoEvents()

                    emple += 1

                End If
            Loop
            rd1.Close()

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub btnEmp_Click(sender As Object, e As EventArgs)

        Dim btnEmpleado As Button = CType(sender, Button)

        lblAtiende.Text = ""
        lblAtiende.Text = btnEmpleado.Text
    End Sub

    Public Sub Departamentos()

        Dim deptos As Integer = 1
        Dim cuantos As Integer = Math.Truncate(pDepartamento.Height / 40)
        Try

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Departamento FROM Productos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cantidaddepartamentos = cantidaddepartamentos + 1
                End If
            Loop
            rd1.Close()

            If cantidaddepartamentos <= 10 Then
                pDepartamento.AutoScroll = False
            Else
                pDepartamento.AutoScroll = True
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Departamento FROM Productos WHERE Departamento<>'INSUMO' AND Departamento<>'EXTRAS' AND Departamento<>'SERVICIOS' ORDER BY Departamento"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim departamento As String = rd1("Departamento").ToString

                    btnDepa = New Button
                    btnDepa.Text = departamento
                    btnDepa.Name = "btnDepto(" & deptos & ")"
                    btnDepa.Left = 0
                    btnDepa.Height = 90
                    btnDepa.Width = pDepartamento.Width

                    If deptos > cuantos And deptos < ((cuantos * 2) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 1)
                        btnDepa.Top = (deptos - (cuantos + 1)) * (btnDepa.Height + 0.5)
                        '2
                    ElseIf deptos > (cuantos * 2) And deptos < ((cuantos * 3) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 2)
                        btnDepa.Top = (deptos - ((cuantos * 2) + 1)) * (btnDepa.Height + 0.5)
                        '3
                    ElseIf deptos > (cuantos * 3) And deptos < ((cuantos * 4) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 3)
                        btnDepa.Top = (deptos - ((cuantos * 3) + 1)) * (btnDepa.Height + 0.5)
                        '4
                    ElseIf deptos > (cuantos * 4) And deptos < ((cuantos * 5) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 4)
                        btnDepa.Top = (deptos - ((cuantos * 4) + 1)) * (btnDepa.Height + 0.5)
                        '5
                    ElseIf deptos > (cuantos * 5) And deptos < ((cuantos * 6) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 5)
                        btnDepa.Top = (deptos - ((cuantos * 5) + 1)) * (btnDepa.Height + 0.5)
                        '6
                    ElseIf deptos > (cuantos * 6) And deptos < ((cuantos * 7) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 6)
                        btnDepa.Top = (deptos - ((cuantos * 6) + 1)) * (btnDepa.Height + 0.5)
                        '7
                    ElseIf deptos > (cuantos * 7) And deptos < ((cuantos * 8) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 7)
                        btnDepa.Top = (deptos - ((cuantos * 7) + 1)) * (btnDepa.Height + 0.5)
                        '8
                    ElseIf deptos > (cuantos * 8) And deptos < ((cuantos * 9) + 1) Then
                        btnGrupo.Left = (btnDepa.Width * 8)
                        btnGrupo.Top = (deptos - ((cuantos * 8) + 1)) * (btnDepa.Height + 0.5)
                        '9
                    ElseIf deptos > (cuantos * 9) And deptos < ((cuantos * 10) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 9)
                        btnDepa.Top = (deptos - ((cuantos * 9) + 1)) * (btnDepa.Height + 0.5)
                        '10
                    ElseIf deptos > (cuantos * 10) And deptos < ((cuantos * 11) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 10)
                        btnDepa.Top = (deptos - ((cuantos * 10) + 1)) * (btnDepa.Height + 0.5)
                        '11
                    ElseIf deptos > (cuantos * 11) And deptos < ((cuantos * 12) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 11)
                        btnDepa.Top = (deptos - ((cuantos * 11) + 1)) * (btnDepa.Height + 0.5)
                        '12
                    ElseIf deptos > (cuantos * 12) And deptos < ((cuantos * 13) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 12)
                        btnDepa.Top = (deptos - ((cuantos * 12) + 1)) * (btnDepa.Height + 0.5)
                        '13
                    ElseIf deptos > (cuantos * 13) And deptos < ((cuantos * 14) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 13)
                        btnDepa.Top = (deptos - ((cuantos * 13) + 1)) * (btnDepa.Height + 0.5)
                        '14
                    ElseIf deptos > (cuantos * 14) And deptos < ((cuantos * 15) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 14)
                        btnDepa.Top = (deptos - ((cuantos * 14) + 1)) * (btnDepa.Height + 0.5)
                        '15
                    ElseIf deptos > (cuantos * 15) And deptos < ((cuantos * 16) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 15)
                        btnDepa.Top = (deptos - ((cuantos * 15) + 1)) * (btnDepa.Height + 0.5)
                        '16
                    ElseIf deptos > (cuantos * 16) And deptos < ((cuantos * 17) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 16)
                        btnDepa.Top = (deptos - ((cuantos * 16) + 1)) * (btnDepa.Height + 0.5)
                        '17
                    ElseIf deptos > (cuantos * 17) And deptos < ((cuantos * 18) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 17)
                        btnDepa.Top = (deptos - ((cuantos * 17) + 1)) * (btnDepa.Height + 0.5)
                        '18
                    ElseIf deptos > (cuantos * 18) And deptos < ((cuantos * 19) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 18)
                        btnDepa.Top = (deptos - ((cuantos * 18) + 1)) * (btnDepa.Height + 0.5)
                        '19
                    ElseIf deptos > (cuantos * 19) And deptos < ((cuantos * 20) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 19)
                        btnDepa.Top = (deptos - ((cuantos * 19) + 1)) * (btnDepa.Height + 0.5)
                        '20
                    ElseIf deptos > (cuantos * 20) And deptos < ((cuantos * 21) + 1) Then
                        btnDepa.Left = (btnDepa.Width * 20)
                        btnDepa.Top = (deptos - ((cuantos * 20) + 1)) * (btnDepa.Height + 0.5)
                        '21
                    Else
                        btnDepa.Left = 0
                        btnDepa.Top = (deptos - 1) * (btnDepa.Height + 0.5)
                    End If




                    btnDepa.BackColor = pDepartamento.BackColor
                    btnDepa.FlatStyle = FlatStyle.Popup
                    btnDepa.FlatAppearance.BorderSize = 0
                    AddHandler btnDepa.Click, AddressOf btnDepto_Click
                    pDepartamento.Controls.Add(btnDepa)
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
        'CantidadProductos = 0
        Grupos(btnDepartamento.Text)
    End Sub

    Public Sub Grupos(ByVal depto As String)

        Dim grupos As Integer = 1
        Dim cuantos As Integer = Math.Truncate(pgrupo.Height / 40)
        cantidadgrupos = 0
        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT distinct Grupo FROM Productos WHERE Departamento='" & depto & "' ORDER BY Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    cantidadgrupos = cantidadgrupos + 1
                End If
            Loop
            rd2.Close()

            If cantidadgrupos <= 18 Then
                pgrupo.AutoScroll = False
            Else
                pgrupo.AutoScroll = True
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT distinct Grupo FROM Productos WHERE Departamento='" & depto & "' AND Departamento<>'INGREDIENTES' AND Departamento<>'SERVICIOS' AND Grupo<>'EXTRAS' order by Grupo asc"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    Dim grupo As String = rd2(0).ToString
                    btnGrupo = New Button
                    btnGrupo.Text = grupo
                    btnGrupo.Tag = depto
                    btnGrupo.Name = "btnGrupo(" & grupos & ")"
                    btnGrupo.Left = 0
                    btnGrupo.Height = 95
                    btnGrupo.Width = 95

                    If grupos > cuantos And grupos < ((cuantos * 2) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 1)
                        btnGrupo.Top = (grupos - (cuantos + 1)) * (btnGrupo.Height + 0.5)
                        '2
                    ElseIf grupos > (cuantos * 2) And grupos < ((cuantos * 3) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 2)
                        btnGrupo.Top = (grupos - ((cuantos * 2) + 1)) * (btnGrupo.Height + 0.5)
                        '3
                    ElseIf grupos > (cuantos * 3) And grupos < ((cuantos * 4) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 3)
                        btnGrupo.Top = (grupos - ((cuantos * 3) + 1)) * (btnGrupo.Height + 0.5)
                        '4
                    ElseIf grupos > (cuantos * 4) And grupos < ((cuantos * 5) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 4)
                        btnGrupo.Top = (grupos - ((cuantos * 4) + 1)) * (btnGrupo.Height + 0.5)
                        '5
                    ElseIf grupos > (cuantos * 5) And grupos < ((cuantos * 6) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 5)
                        btnGrupo.Top = (grupos - ((cuantos * 5) + 1)) * (btnGrupo.Height + 0.5)
                        '6
                    ElseIf grupos > (cuantos * 6) And grupos < ((cuantos * 7) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 6)
                        btnGrupo.Top = (grupos - ((cuantos * 6) + 1)) * (btnGrupo.Height + 0.5)
                        '7
                    ElseIf grupos > (cuantos * 7) And grupos < ((cuantos * 8) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 7)
                        btnGrupo.Top = (grupos - ((cuantos * 7) + 1)) * (btnGrupo.Height + 0.5)
                        '8
                    ElseIf grupos > (cuantos * 8) And grupos < ((cuantos * 9) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 8)
                        btnGrupo.Top = (grupos - ((cuantos * 8) + 1)) * (btnGrupo.Height + 0.5)
                        '9
                    ElseIf grupos > (cuantos * 9) And grupos < ((cuantos * 10) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 9)
                        btnGrupo.Top = (grupos - ((cuantos * 9) + 1)) * (btnGrupo.Height + 0.5)
                        '10
                    ElseIf grupos > (cuantos * 10) And grupos < ((cuantos * 11) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 10)
                        btnGrupo.Top = (grupos - ((cuantos * 10) + 1)) * (btnGrupo.Height + 0.5)
                        '11
                    ElseIf grupos > (cuantos * 11) And grupos < ((cuantos * 12) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 11)
                        btnGrupo.Top = (grupos - ((cuantos * 11) + 1)) * (btnGrupo.Height + 0.5)
                        '12
                    ElseIf grupos > (cuantos * 12) And grupos < ((cuantos * 13) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 12)
                        btnGrupo.Top = (grupos - ((cuantos * 12) + 1)) * (btnGrupo.Height + 0.5)
                        '13
                    ElseIf grupos > (cuantos * 13) And grupos < ((cuantos * 14) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 13)
                        btnGrupo.Top = (grupos - ((cuantos * 13) + 1)) * (btnGrupo.Height + 0.5)
                        '14
                    ElseIf grupos > (cuantos * 14) And grupos < ((cuantos * 15) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 14)
                        btnGrupo.Top = (grupos - ((cuantos * 14) + 1)) * (btnGrupo.Height + 0.5)
                        '15
                    ElseIf grupos > (cuantos * 15) And grupos < ((cuantos * 16) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 15)
                        btnGrupo.Top = (grupos - ((cuantos * 15) + 1)) * (btnGrupo.Height + 0.5)
                        '16
                    ElseIf grupos > (cuantos * 16) And grupos < ((cuantos * 17) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 16)
                        btnGrupo.Top = (grupos - ((cuantos * 16) + 1)) * (btnGrupo.Height + 0.5)
                        '17
                    ElseIf grupos > (cuantos * 17) And grupos < ((cuantos * 18) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 17)
                        btnGrupo.Top = (grupos - ((cuantos * 17) + 1)) * (btnGrupo.Height + 0.5)
                        '18
                    ElseIf grupos > (cuantos * 18) And grupos < ((cuantos * 19) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 18)
                        btnGrupo.Top = (grupos - ((cuantos * 18) + 1)) * (btnGrupo.Height + 0.5)
                        '19
                    ElseIf grupos > (cuantos * 19) And grupos < ((cuantos * 20) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 19)
                        btnGrupo.Top = (grupos - ((cuantos * 19) + 1)) * (btnGrupo.Height + 0.5)
                        '20
                    ElseIf grupos > (cuantos * 20) And grupos < ((cuantos * 21) + 1) Then
                        btnGrupo.Left = (btnGrupo.Width * 20)
                        btnGrupo.Top = (grupos - ((cuantos * 20) + 1)) * (btnGrupo.Height + 0.5)
                        '21
                    Else
                        btnGrupo.Left = 0
                        btnGrupo.Top = (grupos - 1) * (btnGrupo.Height + 0.5)
                    End If

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnGrupo_Click(sender As Object, e As EventArgs)
        Dim btnGrupos As Button = CType(sender, Button)
        pProductos.Controls.Clear()

        If cnn3.State = 1 Then
            cnn3.Close()
        End If
        'CantidadProductos = 0
        Productos(btnGrupo.Tag, btnGrupos.Text)
    End Sub

    Public Sub Productos(ByVal depto As String, ByVal grupo As String)

        Dim prods As Integer = 1
        Dim cuantos As Integer = Math.Truncate(pProductos.Height / 130)

        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre,Codigo FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre,Codigo"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    cantidadproductos = cantidadproductos + 1
                End If
            Loop
            rd3.Close()

            If cantidadproductos <= 7 Then
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
                    btnProd.Height = 130
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

                    btnProd.BackColor = Color.SkyBlue
                    btnProd.FlatStyle = FlatStyle.Popup
                    btnProd.FlatAppearance.BorderSize = 0

                    If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & rd3(1).ToString & ".jpg") Then
                        btnProd.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & rd3(1).ToString & ".jpg")
                        btnProd.BackgroundImageLayout = ImageLayout.Stretch
                        btnProd.TextAlign = ContentAlignment.BottomCenter
                        btnProd.ForeColor = Color.Black
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

    Private Sub btnProd_Click(sender As Object, e As EventArgs)
        Dim btnProducto As Button = CType(sender, Button)

        CodigoProducto = ""
        CodigoProducto = btnProducto.Tag


        Dim puertoba As String = ""
        Dim bascula As String = ""

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Pto-Bascula'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                puertoba = rd2(0).ToString
            End If
        End If
        rd2.Close()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Bascula'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                bascula = rd2(0).ToString
            End If
        End If
        rd2.Close()

        If bascula <> "SBascula" Then

            ' Configurar el puerto serie
            With serialPortT
                .PortName = puertoba ' Cambia esto al puerto correcto de tu báscula
                .BaudRate = 9600 ' Ajusta la velocidad según las especificaciones de tu báscula
                .DataBits = 8
                .StopBits = StopBits.One
                .Parity = Parity.None
            End With

            ' Abrir el puerto serie
            If Not serialPortT.IsOpen Then
                serialPortT.Open()
                ' MessageBox.Show("Conectado a la báscula.")
            End If

            ' Leer datos de la báscula
            If serialPortT.IsOpen Then
                Dim data As Double = serialPortT.ReadLine()
                cantidad = data
                cantidad = FormatNumber(cantidad, 2)
            Else
                MessageBox.Show("La báscula no está conectada.")
            End If

            ObtenerProducto(CodigoProducto)

            ' Cerrar el puerto serie al cerrar la aplicación
            If serialPortT.IsOpen Then
                serialPortT.Close()
            End If

            My.Application.DoEvents()

            EnviarComanda()
            pEmpleado.Controls.Clear()
            Empleados()

        Else
            ppeso.Visible = True
            txtPeso.Focus.Equals(True)
        End If


        cnn2.Close()








    End Sub

    Private Sub lblTotalVenta_TextChanged(sender As Object, e As EventArgs) Handles lblTotalVenta.TextChanged

        If lblTotalVenta.Text = "" Then Exit Sub
        Dim TotalImporte As Double = lblTotalVenta.Text
        Dim CantidadLetra As String = ""
        If TotalImporte > 0 Then

            CantidadLetra = UCase(convLetras(TotalImporte))
        Else

            CantidadLetra = ""
        End If
        LBLLETRA.Text = CantidadLetra

    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick

        Dim index As Integer = grdCaptura.CurrentRow.Index

        Dim importe = grdCaptura.Rows(index).Cells(4).Value.ToString

        lblTotalVenta.Text = lblTotalVenta.Text - importe
        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)

        grdCaptura.Rows.Remove(grdCaptura.CurrentRow)

    End Sub

    Public Sub ObtenerProducto(Codigo As String)
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & Codigo & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    If rd1("Departamento").ToString = "SERVICIOS" Then
                        existencia = 0
                        Exit Sub
                    End If

                    descripcion = rd1("Nombre").ToString
                    unidadventa = rd1("UVenta").ToString
                    minimo = rd1("Min").ToString
                    ubicacion = rd1("Ubicacion").ToString
                    multiplo = rd1("Multiplo").ToString
                    dosxuno = rd1("E1").ToString
                    tresxdos = rd1("e2").ToString
                    existencia = rd1("Existencia").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            Call find_preciovta(Codigo)
            min = existencia

            PU = (PU)
            Importe = cantidad * PU
            If Importe <> 0 Then
                UpGridCaptura()
            Else
                MsgBox("Este producto no tiene precio de venta, no se agregara en la comanda", vbInformation + vbOKOnly, "Delsscom® Restaurant")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        If lblAtiende.Text = "" Then MsgBox("Debe seleccionar un empleado", vbInformation + vbOKOnly, titulorestaurante) : Exit Sub
        Try
            Dim idemp As Integer = 0
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT IdEmpleado FROM Usuarios WHERE Alias='" & usuariologueo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    idemp = rd2(0).ToString

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT Vent_NVen FROM permisos WHERE IdEmpleado=" & idemp & ""
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If rd3(0).ToString = 1 Then



                                montomapeo = 0

                                cnn1.Close() : cnn1.Open()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "SELECT SUM(Total) FROM Comandas WHERE NMESA='" & lblAtiende.Text & "'"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        montomapeo = IIf(montomapeo = 0, 0, montomapeo) + IIf(rd1(0).ToString = 0, 0, rd1(0).ToString)
                                        montomapeo = FormatNumber(montomapeo, 2)
                                        'frmPagarPollos.txtSubtotalmapeo.Text = montomapeo
                                        frmPagarPollos.lblsubtotalmapeo.Text = FormatNumber(montomapeo, 2)
                                        frmPagarPollos.subtotalmapeo = montomapeo
                                        frmPagarPollos.lblmesa.Text = lblAtiende.Text
                                        frmPagarPollos.lblusuario2.Text = usuariologueo
                                        'frmPagarPollos.contraseñamesero = contralogueo
                                        'frmPagarPollos.COMENSALES = 1
                                        frmPagarPollos.Show()
                                        Me.Close()

                                    Else
                                        MsgBox("El cliente aun no tienen consumo asignado", vbInformation + vbOKOnly, titulomensajes)
                                        Exit Sub
                                    End If
                                End If
                                rd1.Close()
                                cnn1.Close()

                            Else
                                MsgBox("El usuario no cuenta con permisos para cerrar la cuenta", vbInformation + vbOKOnly, titulomensajes)
                                Exit Sub
                            End If
                            rd1.Close()
                            cnn1.Close()

                        Else
                            MsgBox("El usuario no cuenta con permisos para cerrar la cuenta", vbInformation + vbOKOnly, titulomensajes)
                            Exit Sub
                        End If
                    Else
                        MsgBox("El usuario no tiene asignados ningun permiso", vbInformation + vbOK, titulomensajes)
                        Exit Sub
                    End If
                    rd3.Close()
                    cnn3.Close()
                End If
            Else
                MsgBox("clave o usuario incorrectos", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
            rd2.Close()
            cnn2.Close()
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
                    MyPrecio = rd2("PrecioVentaIVA").ToString
                ElseIf PEDI = True Then
                    MyPrecio = rd2("PecioVentaMinIVA").ToString
                End If
                PU = FormatNumber(MyPrecio, 2)
            End If
        End If
        rd2.Close()
        cnn2.Close()

    End Sub


    Public Sub UpGridCaptura()

        Dim TotalVenta As Double = 0


        Try
            With Me.grdCaptura
                Dim banderaentraa As Integer = 0
                banderaentraa = 0
                For qq As Integer = 0 To grdCaptura.Rows.Count - 1

                    If grdCaptura.Rows(qq).Cells(0).Value = CodigoProducto Then

                        grdCaptura.Rows(qq).Cells(1).Value = descripcion

                        grdCaptura.Rows(qq).Cells(2).Value = grdCaptura.Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))


                        grdCaptura.Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                        grdCaptura.Rows(qq).Cells(4).Value = grdCaptura.Rows(qq).Cells(4).Value.ToString + CDec(FormatNumber(Importe, 2))

                        grdCaptura.Rows(qq).Cells(5).Value = cantidad2

                        lblTotalVenta.Text = lblTotalVenta.Text + Importe
                        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                        banderaentraa = 1

                    End If
                Next

                If banderaentraa = 0 Then

                    grdCaptura.Rows.Add(CodigoProducto, descripcion,
                    FormatNumber(cantidad, 2),
                    FormatNumber(PU, 2),
                    FormatNumber(Importe, 2)
                                        )
                    lblTotalVenta.Text = lblTotalVenta.Text + Importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub EnviarComanda()

        Try

            If lblAtiende.Text = "" Then MsgBox("Debe seleccionar a un empleado", vbInformation + vbOKOnly, titulorestaurante) : btnLimpiar.PerformClick() : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Max(Folio) FROM Comanda1"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    foliocomanda1 = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) + 1
                Else
                    foliocomanda1 = "1"
                End If
            Else
                foliocomanda1 = "1"
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Max(Id) FROM rep_comandas"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    reportecomanda = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) + 1
                Else
                    reportecomanda = "1"
                End If
            Else
                reportecomanda = "1"
            End If
            rd1.Close()

            Dim mysubtotal As Double = 0
            Dim codigoproducto As String = ""
            Dim mytotalc As Double = 0
            Dim myivac As Double = 0

            cnn2.Close() : cnn2.Open()
            For luffy As Integer = 0 To grdCaptura.Rows.Count - 1

                codigoproducto = grdCaptura.Rows(luffy).Cells(0).Value.ToString

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IVA FROM productos WHERE Codigo='" & codigoproducto & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        If grdCaptura.Rows(luffy).Cells(3).Value.ToString <> "" Then
                            If CDec(grdCaptura.Rows(luffy).Cells(3).Value.ToString) > 0 Then

                                mysubtotal = mysubtotal + (CDec(grdCaptura.Rows(luffy).Cells(3).Value.ToString)) / (1 + rd1("IVA").ToString)
                                mysubtotal = FormatNumber(mysubtotal, 2)


                                mytotalc = IIf(mytotalc = 0, 0, mytotalc) / (1 + rd1("IVA").ToString)


                            End If
                        End If

                    End If
                Loop


                rd1.Close()
            Next luffy

            If grdCaptura.Rows.Count < 1 Then MsgBox("Debes seleccionar un producto", vbInformation + vbOKOnly, titulorestaurante) : Exit Sub

            Dim totales As Double = 0
            totales = lblTotalVenta.Text

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO comanda1(Folio,Nombre,Subtotal,IVA,Totales,TComensales,IdCliente,Direccion,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista) VALUES(" & foliocomanda1 & ",'" & lblAtiende.Text & "'," & mysubtotal & "," & mytotalc & "," & totales & ",'','','','" & lblAtiende.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','','','')"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            Dim EMPLEADO As String = ""
            Dim MYCODE As String = ""
            Dim MYDESC As String = ""
            Dim MYCANT As Double = 0
            Dim MYPRECIO As Double = 0
            Dim MYTOTAL As Double = 0
            Dim UVENTA As String = ""
            Dim MYIVA As Double = 0
            Dim MYPRECIOSIN As Double = 0
            Dim MYPRECIOCOMPRA As Double = 0
            Dim MYTOTALSIN As Double = 0
            Dim MYCOSTVUE As Double = 0
            Dim MYDEPTO As String = ""
            Dim MYGRUPO As String = ""
            Dim MYMCD As Double = 0
            Dim MYMULTIPLO As Double = 0
            Dim COMENTARIO As String = ""

            Dim MYEXINV As Double = 0
            Dim MYMULTIPLOD As Double = 0

            Dim HrTiempo As String = ""
            Dim HrEntrega As String = ""


            For deku As Integer = 0 To grdCaptura.Rows.Count - 1

                If grdCaptura.Rows(deku).Cells(0).Value.ToString <> "" Then

                    EMPLEADO = lblAtiende.Text
                    MYCODE = grdCaptura.Rows(deku).Cells(0).Value.ToString
                    MYDESC = grdCaptura.Rows(deku).Cells(1).Value.ToString
                    MYCANT = grdCaptura.Rows(deku).Cells(2).Value.ToString
                    MYPRECIO = grdCaptura.Rows(deku).Cells(3).Value.ToString
                    MYTOTAL = grdCaptura.Rows(deku).Cells(4).Value.ToString
                    COMENTARIO = grdCaptura.Rows(deku).Cells(5).Value

                    MYPRECIO = FormatNumber(MYPRECIO, 2)
                    MYTOTAL = FormatNumber(MYTOTAL, 2)

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & MYCODE & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                            MYIVA = rd2("iva").ToString
                            MYPRECIOSIN = IIf(MYPRECIO = 0, 0, MYPRECIO) / (1 + MYIVA)

                            MYTOTALSIN = IIf(MYTOTAL = 0, 0, MYTOTAL) / (1 + MYIVA)

                            MYPRECIOSIN = FormatNumber(MYPRECIOSIN, 2)
                            MYTOTALSIN = FormatNumber(MYTOTALSIN, 2)

                            If rd2("Departamento").ToString = "SERVICIOS" Then
                                MYCOSTVUE = 0
                                MYDEPTO = rd2("Departamento").ToString
                                MYGRUPO = rd2("Grupo").ToString
                            End If

                            MYMCD = rd2("MCD").ToString
                            MYMULTIPLO = rd2("Multiplo").ToString
                            MYDEPTO = rd2("Departamento").ToString
                            MYGRUPO = rd2("Grupo").ToString
                            UVENTA = rd2("UVenta").ToString

                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & Strings.Left(MYCODE, 7) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then

                            MYMULTIPLOD = rd2("Multiplo").ToString

                            MYEXINV = rd2("Existencia").ToString / MYMULTIPLOD

                            If rd2("Departamento").ToString <> "SERVICIOS" Then
                                MYPRECIOCOMPRA = rd2("PrecioCompra").ToString
                                MYCOSTVUE = (MYPRECIOCOMPRA) * (MYCANT / MYMCD)
                            End If

                        End If
                    End If
                    rd2.Close()

                    HrTiempo = Format(Date.Now, "HH:mm:ss")
                    HrTiempo = Format(Date.Now, "HH:mm:ss")

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "INSERT INTO comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT) VALUES(" & foliocomanda1 & ",'" & lblAtiende.Text & "','" & MYCODE & "','" & MYDESC & "'," & MYCANT & ",'" & UVENTA & "'," & MYCOSTVUE & ",0," & MYPRECIO & "," & MYTOTAL & "," & MYPRECIOSIN & "," & MYTOTALSIN & ",'','" & Format(Date.Now, "yyyy-MM-dd") & "','" & MYDEPTO & "','" & MYGRUPO & "','1','RESTA','" & COMENTARIO & "','','" & lblAtiende.Text & "','1',0,'" & HrTiempo & "','" & HrEntrega & "')"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "INSERT INTO rep_comandas(Id,NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,EstatusT,Hr,EntregaT) VALUES(" & reportecomanda & ",'" & lblAtiende.Text & "','" & MYCODE & "','" & MYDESC & "'," & MYCANT & ",'" & UVENTA & "'," & MYCOSTVUE & ",0," & MYPRECIO & "," & MYTOTAL & "," & MYPRECIOSIN & "," & MYTOTALSIN & ",'','" & Format(Date.Now, "yyyy-MM-dd") & "','" & MYDEPTO & "','" & MYGRUPO & "','1','ORDENADA','" & COMENTARIO & "','','" & lblAtiende.Text & "','1',0,'" & HrTiempo & "','" & HrEntrega & "')"
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()

                End If
            Next
            cnn2.Close()
            cnn1.Close()

            'lblAtiende.Text = ""
            lblTotalVenta.Text = "0.00"
            LBLLETRA.Text = ""

            Limpiar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub BTNINTRO_Click(sender As Object, e As EventArgs) Handles BTNINTRO.Click
        With ppeso
            cantidad = txtPeso.Text
        End With

        ObtenerProducto(CodigoProducto)
        My.Application.DoEvents()

        EnviarComanda()
        pEmpleado.Controls.Clear()
        Empleados()

        My.Application.DoEvents()

        ppeso.Visible = False
        txtPeso.Text = ""
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtPeso.Text = txtPeso.Text + btn1.Text
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtPeso.Text = txtPeso.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtPeso.Text = txtPeso.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtPeso.Text = txtPeso.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtPeso.Text = txtPeso.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtPeso.Text = txtPeso.Text + btn6.Text
    End Sub

    Private Sub BTN7_Click(sender As Object, e As EventArgs) Handles BTN7.Click
        txtPeso.Text = txtPeso.Text + BTN7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtPeso.Text = txtPeso.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtPeso.Text = txtPeso.Text + btn9.Text
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtPeso.Text = txtPeso.Text + btn0.Text
    End Sub

    Private Sub btnp_Click(sender As Object, e As EventArgs) Handles btnp.Click
        txtPeso.Text = txtPeso.Text + btnp.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FRMPRUBEA.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ppeso.Visible = False
        Exit Sub

    End Sub

    Private Sub btnlimpia_Click(sender As Object, e As EventArgs) Handles btnlimpia.Click
        txtPeso.Text = CutCad(txtPeso.Text)
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function

    Public Sub Limpiar()
        'pProductos.Controls.Clear()
        grdCaptura.Rows.Clear()

    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdCaptura.Rows.Clear()
        lblTotalVenta.Text = "0.00"
        LBLLETRA.Text = ""
        lblAtiende.Text = ""
        pProductos.Controls.Clear()
    End Sub

    Private Sub btnAsiganar_Click(sender As Object, e As EventArgs) Handles btnAsiganar.Click
        EnviarComanda()

        pEmpleado.Controls.Clear()
        Empleados()
    End Sub



End Class