Imports System.Net
Imports System.IO
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Text
Imports System.Data.SqlClient
Public Class frmAutoservicio
    Public valorxd As Integer = 0
    Public SiPago As Integer = 0
    Public hayTerminal As Integer = 0
    Public validaTarjeta As Double = 0

    Dim numTerminal As String = ""
    Dim numClave As String = ""
    Dim URLsolicitud As String = ""
    Dim URLresultado As String = ""


    Public CantidadProd As Integer = 0
    Public CodigoProducto As String = ""
    Public cantidad As Double = 0
    Dim T_Precio As String = ""
    Dim H_Inicia As String = ""
    Dim H_Final As String = ""
    Public globaltotal As Double = 0
    Public CampoDsct As Double = 0
    Dim soydescuento As Double = 0

    Dim TotDeptos As Integer = 0
    Dim TotGrupos As Integer = 0
    Dim TotProductos As Integer = 0

    Public Cliente As String = ""
    Public Id_Cliente As Integer = 0
    Dim Tipo_Precio As String = ""
    Dim MYFOLIO As Integer = 0

    Friend WithEvents pComanda As System.Drawing.Printing.PrintDocument

    Public G_Comanda As String = ""
    Public cadenafact As String = ""

    Friend WithEvents btnDepto, btnGrupo, btnProd As System.Windows.Forms.Button

    Public Sub Folio()
        If cnn9.State = 1 Then cnn9.Close()
        cnn9.Open()

        cmd9 = cnn9.CreateCommand
        cmd9.CommandText =
            "select MAX(Folio) from Ventas"
        rd9 = cmd9.ExecuteReader
        If rd9.HasRows Then
            If rd9.Read Then
                lblFolio.Text = CDbl(IIf(rd9(0).ToString = "", "0", rd9(0).ToString)) + 1
            Else
                lblFolio.Text = "1"
            End If
        Else
            lblFolio.Text = "1"
        End If
        rd9.Close()
        cnn9.Close()
    End Sub

    Private Sub tFecha_Tick(sender As System.Object, e As System.EventArgs) Handles tFecha.Tick
        Me.Text = "Delsscom® Control Negocios Pro  -  Ventas de AutoServicio" & Strings.Space(40) & Date.Now
        lblfecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
    End Sub

    Private Sub frmVentasTouch_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmVentasTouchPago.Close()
    End Sub

    Public MontoEfectivo As Double = 0
    Public MontoTarjeta As Double = 0
    Public MontoMonedero As Double = 0
    Public Cambio As Double = 0
    Public Resta As Double = 0
    Public Monedero As String = ""
    Public Direccion As String = ""

    Private Sub frmVentasTouch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from DatosProsepago"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                hayTerminal = 1
                numTerminal = rd1("Terminal").ToString
                numClave = rd1("Clave").ToString
                URLsolicitud = rd1("Solicitud").ToString
                URLresultado = rd1("Resultado").ToString
            Else
                hayTerminal = 0
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try



        If File.Exists(My.Application.Info.DirectoryPath & "\Fondo.jpg") Then
            pProductos.BackgroundImage = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\Fondo.jpg")
            pProductos.BackgroundImageLayout = ImageLayout.Stretch
        End If

        tFecha.Start()
        tFolio.Start()
        If cnn1.State = 1 Then
            cnn1.Close()
        End If
        TotDeptos = 0
        MontoEfectivo = 0
        MontoTarjeta = 0
        MontoMonedero = 0
        Cambio = 0
        Resta = 0
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
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        pDeptos.Controls.Clear()
        pGrupos.Controls.Clear()
        pProductos.Controls.Clear()
        Departamentos()
    End Sub

    Private Sub Departamentos()
        Dim deptos As Integer = 0
        Try
            If TotDeptos <= 8 Then
                pDeptos.AutoScroll = False
            Else
                pDeptos.AutoScroll = True
            End If
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select distinct Departamento from Productos order by Departamento asc"
            rd1 = cmd1.ExecuteReader


            Dim btnDepto As Button
            Dim btnWidth As Integer

            'If TotDeptos <= 10 Then
            '    btnWidth = pDeptos.Width
            'Else
            '    btnWidth = pDeptos.Width - 17
            'End If

            While rd1.Read()
                Dim departamento As String = rd1(0).ToString()

                btnDepto = New Button()
                btnDepto.Text = departamento
                btnDepto.Name = "btnDepto(" & deptos & ")"
                btnDepto.Width = 100
                btnDepto.Height = pDeptos.Height
                btnDepto.BackColor = pDeptos.BackColor
                btnDepto.FlatStyle = FlatStyle.Popup
                btnDepto.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                btnDepto.FlatAppearance.BorderSize = 0

                ' Calcular posición horizontal
                btnDepto.Left = deptos * (btnDepto.Width + 2) ' Espacio entre botones: 5

                ' Posición vertical fija (si lo deseas)
                btnDepto.Top = 0

                AddHandler btnDepto.Click, AddressOf btnDepto_Click
                pDeptos.Controls.Add(btnDepto)

                If deptos = 0 Then
                    Grupos(departamento) ' Llamada a la función para el primer departamento
                End If

                deptos += 1
            End While

            rd1.Close()
            cnn1.Close()
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
        'Try
        '    cnn2.Close() : cnn2.Open()

        '    cmd2 = cnn2.CreateCommand
        '    cmd2.CommandText =
        '        "select distinct Grupo from Productos where Departamento='" & depto & "' AND Grupo<>'INSUMO' order by Grupo asc"
        '    rd2 = cmd2.ExecuteReader
        '    Do While rd2.Read
        '        If rd2.HasRows Then TotGrupos = TotGrupos + 1
        '    Loop
        '    rd2.Close()

        '    If TotGrupos <= 10 Then
        '        pGrupos.AutoScroll = False
        '    Else
        '        pGrupos.AutoScroll = True
        '    End If

        '    cmd2 = cnn2.CreateCommand
        '    cmd2.CommandText =
        '        "select distinct Grupo from Productos where Departamento='" & depto & "' AND Grupo<>'INSUMO' order by Grupo asc"
        '    rd2 = cmd2.ExecuteReader
        '    Do While rd2.Read
        '        If rd2.HasRows Then
        '            Dim grupo As String = rd2(0).ToString
        '            btnGrupo = New Button
        '            btnGrupo.Text = grupo
        '            btnGrupo.Tag = depto
        '            btnGrupo.Name = "btnGrupo(" & grupos & ")"
        '            btnGrupo.Height = 55
        '            btnGrupo.Left = 0
        '            If TotGrupos <= 10 Then
        '                btnGrupo.Width = pGrupos.Width
        '            Else
        '                btnGrupo.Width = pGrupos.Width - 17
        '            End If
        '            btnGrupo.Top = grupos * (btnGrupo.Height + 0.5)
        '            btnGrupo.BackColor = pGrupos.BackColor
        '            btnGrupo.FlatStyle = FlatStyle.Popup
        '            btnGrupo.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        '            btnGrupo.FlatAppearance.BorderSize = 0
        '            AddHandler btnGrupo.Click, AddressOf btnGrupo_Click
        '            pGrupos.Controls.Add(btnGrupo)
        '            If grupos = 0 Then
        '                Productos(depto, grupo)
        '            End If
        '            grupos += 1
        '        End If
        '    Loop
        '    rd2.Close()
        '    cnn2.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        '    cnn2.Close()
        'End Try
        Try
            cnn2.Close()
            cnn2.Open()

            ' Calcular el número total de grupos
            cmd2 = cnn2.CreateCommand()
            cmd2.CommandText = "select distinct Grupo from Productos where Departamento='" & depto & "' AND Grupo<>'INSUMO' order by Grupo asc"
            rd2 = cmd2.ExecuteReader()
            TotGrupos = 0
            Do While rd2.Read()
                TotGrupos += 1
            Loop
            rd2.Close()

            ' Habilitar o deshabilitar el scroll automático según la cantidad de grupos
            If TotGrupos <= 8 Then
                pGrupos.AutoScroll = False
            Else
                pGrupos.AutoScroll = True
            End If

            ' Crear los botones de grupos
            cmd2.CommandText = "select distinct Grupo from Productos where Departamento='" & depto & "' AND Grupo<>'INSUMO' order by Grupo asc"
            rd2 = cmd2.ExecuteReader()
            grupos = 0
            Do While rd2.Read()
                If rd2.HasRows Then
                    Dim grupo As String = rd2(0).ToString()
                    btnGrupo = New Button()
                    btnGrupo.Text = grupo
                    btnGrupo.Tag = depto ' Almacenar el departamento en el Tag del botón
                    btnGrupo.Name = "btnGrupo(" & grupos & ")"
                    btnGrupo.Height = pGrupos.Height
                    btnGrupo.Width = 100
                    btnGrupo.Left = 0
                    btnGrupo.Left = grupos * (btnGrupo.Width + 2) ' Espacio vertical entre botones: 5
                    btnGrupo.BackColor = pGrupos.BackColor
                    btnGrupo.FlatStyle = FlatStyle.Popup
                    btnGrupo.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                    btnGrupo.FlatAppearance.BorderSize = 0
                    AddHandler btnGrupo.Click, AddressOf btnGrupo_Click
                    pGrupos.Controls.Add(btnGrupo)

                    If grupos = 0 Then
                        Productos(depto, grupo) ' Llamada a la función para el primer grupo
                    End If

                    grupos += 1
                End If
            Loop

            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
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
        Dim cuantos As Integer = Math.Truncate(pProductos.Height / 130)

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
                    btnProd.Height = 135
                    btnProd.Width = 200

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

                    btnProd.BackColor = Color.FromArgb(192, 255, 192)
                    btnProd.FlatStyle = FlatStyle.Popup
                    Dim fuenteNegrita As New Font(btnProd.Font, FontStyle.Bold)
                    btnProd.Font = fuenteNegrita
                    btnProd.Font = New Font("Segoe UI", 10, FontStyle.Bold)

                    btnProd.FlatAppearance.BorderSize = 0
                    If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & rd3(1).ToString & ".jpg") Then
                        btnProd.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & rd3(1).ToString & ".jpg")
                        btnProd.BackgroundImageLayout = ImageLayout.Zoom

                        btnProd.TextAlign = ContentAlignment.BottomCenter
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

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Existencia,Departamento from Productos where Codigo='" & Strings.Left(codigo, 7) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            MyExistencia = CDbl(rd2(0).ToString) / MyMultip
                            If rd2(1).ToString = "SERVICIOS" Then
                                MyExistencia = 0
                            Else
                                If chec = True Then
                                    Existe = rd1("Existencia").ToString
                                    Dim TExis As Double = Existe - CDbl(txtcantidad.Text)
                                    If TExis <= 0 Then
                                        MsgBox("No puedes vender productos sin existencia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                        rd1.Close() : cnn1.Close()
                                        rd2.Close() : cnn2.Close()
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                    End If
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
        Dim H_Actual As String = Format(Date.Now, "HH:mm")
        Dim ATemp1, ATemp2, ATemp3, ATemp4 As Double

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
                    If Tipo_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                        MyPrecio = CDbl(IIf(rd3("PreEsp").ToString = "", "0", rd3(0).ToString)) * TiCambio
                        MyPrecio = FormatNumber(MyPrecio, 2)
                    Else
                        MyPrecio = CDbl(IIf(rd3("PrecioVentaIVA").ToString = "", "0", rd3("PrecioVentaIVA").ToString)) * TiCambio
                        MyPrecio = FormatNumber(MyPrecio, 2)

                        If Not IsDBNull(rd3("CantLst1").ToString) And Not IsDBNull(rd3("CantLst2").ToString) Then
                            If CDbl(cantidad) >= CDbl(rd3("CantLst1").ToString) And CDbl(cantidad) <= CDbl(rd3("CantLst2").ToString) Then
                                MyPrecio = CDbl(IIf(rd3("PrecioVentaIVA").ToString = "", "0", rd3("PrecioVentaIVA").ToString))
                                MyPrecio = FormatNumber(MyPrecio, 2)
                                temp = 1
                            End If
                        End If

                        If Not IsDBNull(rd3("CantEsp1").ToString) And Not IsDBNull(rd3("CantEsp2").ToString) Then
                            ATemp1 = rd3("CantEsp1").ToString
                            If CDbl(cantidad) >= CDbl(rd3("CantEsp1").ToString) And CDbl(cantidad) <= CDbl(rd3("CantEsp2").ToString) Then
                                MyPrecio = CDbl(IIf(rd3("PreEsp").ToString = "", "0", rd3("PreEsp").ToString))
                                MyPrecio = FormatNumber(MyPrecio, 2)
                                temp = 1
                            End If
                        End If

                        If Not IsDBNull(rd3("CantMM1").ToString) And Not IsDBNull(rd3("CantMM2").ToString) Then
                            ATemp2 = rd3("CantMM1").ToString
                            If CDbl(cantidad) >= CDbl(rd3("CantMM1").ToString) And CDbl(cantidad) <= CDbl(rd3("CantMM2").ToString) Then
                                MyPrecio = CDbl(IIf(rd3("PreMM").ToString = "", "0", rd3("PreMM").ToString))
                                MyPrecio = FormatNumber(MyPrecio, 2)
                                temp = 1
                            End If
                        End If

                        If Not IsDBNull(rd3("CantMay1").ToString) And Not IsDBNull(rd3("CantMay2").ToString) Then
                            ATemp3 = rd3("CantMay1").ToString
                            If CDbl(cantidad) >= CDbl(rd3("CantMay1").ToString) And CDbl(cantidad) <= CDbl(rd3("CantMay2").ToString) Then
                                MyPrecio = CDbl(IIf(rd3("PreMay").ToString = "", "0", rd3("PreMay").ToString))
                                MyPrecio = FormatNumber(MyPrecio, 2)
                                temp = 1
                            End If
                        End If

                        If Not IsDBNull(rd3("CantMin1").ToString) And Not IsDBNull(rd3("CantMin2").ToString) Then
                            ATemp4 = rd3("CantMin1").ToString
                            If CDbl(cantidad) >= CDbl(rd3("CantMin1").ToString) And CDbl(cantidad) <= CDbl(rd3("CantMin2").ToString) Then
                                MyPrecio = CDbl(IIf(rd3("PreMin").ToString = "", "0", rd3("PreMin").ToString))
                                MyPrecio = FormatNumber(MyPrecio, 2)
                                temp = 1
                            End If
                        End If
                    End If

                    If ATemp1 <> 0 Or ATemp2 <> 0 Or ATemp3 <> 0 Or ATemp4 <> 0 Then
                        If temp = 0 Then
                            cnn5.Close() : cnn5.Open()
                            cmd5 = cnn5.CreateCommand
                            cmd5.CommandText =
                                "select * from Productos where Codigo='" & codigo & "'"
                            rd5 = cmd5.ExecuteReader
                            If rd5.HasRows Then
                                If rd5.Read Then
                                    MyPrecio = CDbl(IIf(rd5("PrecioVentaIVA").ToString = "", "0", rd5("PrecioVentaIVA").ToString))
                                    MyPrecio = FormatNumber(MyPrecio, 2)
                                End If
                            Else
                                MsgBox("El producto no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            End If
                            rd5.Close()
                            cnn5.Close()
                            rd3.Close() : cnn4.Close()
                            Exit Sub
                        End If
                    End If
                End If
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
        globaltotal = TotalVenta
        grdProducto.DefaultCellStyle.SelectionBackColor = Color.White
        grdProducto.DefaultCellStyle.SelectionForeColor = Color.Black
        With grdProducto.Rows
            .Clear()
            .Add("Descripción: ", myDescrip)
            .Add("Cantidad: ", cantidad)
            .Add("Existencia: ", MyExistencia)
        End With
    End Sub

    Private Sub btnProd_Click(sender As Object, e As EventArgs)
        On Error GoTo keseso
        Dim btnProducto As Button = CType(sender, Button)

        CodigoProducto = ""
        CodigoProducto = btnProducto.Tag
        Ajusta_Grid()
        T_Precio = DatosRecarga("TipoPrecio")
        H_Inicia = DatosRecarga("HoraInicia")
        H_Final = DatosRecarga("HoraTermina")

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

    Private Sub tFolio_Tick(sender As System.Object, e As System.EventArgs) Handles tFolio.Tick

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        CantidadProd = 1
    End Sub

    Private Sub btnaceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnaceptar.Click
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

    Private Sub lblTotal_TextChanged(sender As Object, e As System.EventArgs) Handles lblTotal.TextChanged
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

    Private Sub btnsalir_Click(sender As System.Object, e As System.EventArgs) Handles btnsalir.Click
        txtcantidad.Text = "0"
        panCantidad.Visible = False
        CantidadProd = 0
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

    Private Sub btnc0_Click(sender As System.Object, e As System.EventArgs) Handles btnc0.Click
        txtcantidad.Text = "0"
    End Sub

    Private Sub btnpagar_Click(sender As System.Object, e As System.EventArgs) Handles btnpagar.Click
        If frmVentasTouchPago.Visible = False Then
            frmVentasTouchPago.Show(Me)
            frmVentasTouchPago.txtresta.Text = FormatNumber(lblTotal.Text, 2)
            frmVentasTouchPago.resta = FormatNumber(lblTotal.Text, 2)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmVentasTouchBuscar.Show()
    End Sub

    Async Function EnviarSolicitudAPI() As Task

        ' Label1.Visible = True
        ' Valores a enviar a la API
        Dim TipoPlan As String = "00"
        Dim Terminal As String = numTerminal
        Dim Importe As String = validaTarjeta
        Dim pv As String = "DELSSCOM"
        Dim nombre As String = "MOSTRADOR"
        Dim concepto As String = "Venta"
        Dim referencia As String = lblFolio.Text & FormatDateTime(Date.Now, DateFormat.ShortDate) & FormatDateTime(Date.Now, DateFormat.ShortTime) ' se recomienda poner el folio de la venta y la fecha, asi me dijo el wey de procepago, dice que no se debe de repetir

        Dim correo As String = ""
        Dim membresia As String = "false"
        Dim clave As String = numClave

        Dim cadenatexto As String = TipoPlan & Terminal & Importe & nombre & concepto & referencia & correo & clave
        ' MsgBox(cadenatexto)
        Dim CadenaEncriptada As String = CalculateSHA1(cadenatexto)

        ' URL de la API
        Dim url As String = URLsolicitud

        ' Construye la solicitud HTTP
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' datos a enviar con metodo post
        Dim postData As String = $"&tipoPlan={TipoPlan}&terminal={Terminal}&importe={Importe}&nombre={nombre}&concepto={concepto}&referencia={referencia}&correo={correo}&pv={pv}&CadenaEncriptada={CadenaEncriptada}"
        'MsgBox(postData)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = byteArray.Length

        Try
            ' Aqui se activa el pago en la terminal
            Using dataStream As Stream = Await request.GetRequestStreamAsync()
                Await dataStream.WriteAsync(byteArray, 0, byteArray.Length)
            End Using


            ' Envía la solicitud y procesa la respuesta

            Dim response As WebResponse = Await request.GetResponseAsync()

            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = Await reader.ReadToEndAsync()
                ' MessageBox.Show("Respuesta de la API: " & responseFromServer)
                valorxd = responseFromServer
                'Thread.Sleep(4000)
                EnviarSolicitudAPI2()
            End Using
        Catch ex As WebException
            MessageBox.Show("Error en la solicitud: " & ex.Message)
        End Try
    End Function

    Private Function CalculateSHA1(input As String) As String
        Try
            Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(input)
            bytesToHash = sha1Obj.ComputeHash(bytesToHash)
            Dim strResult As String = ""
            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next
            Return strResult
        Catch ex As Exception
            MessageBox.Show("Funcion getSHA1Hash: | " & ex.ToString)
        End Try

    End Function


    Async Function EnviarSolicitudAPI2() As Task
        ' Valores a enviar a la API
        Dim idsolicitud As String = valorxd
        Dim clave As String = numClave

        ' Genera el hash SHA-1 de los valores
        Dim CadenaEncriptada As String = CalculateSHA1(idsolicitud & clave)

        ' URL de la API

        Dim url As String = URLresultado

        ' Construye la solicitud HTTP
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Construye los datos a enviar en la solicitud
        Dim postData As String = $"&idsolicitud={idsolicitud}&cadenaEncriptada={CadenaEncriptada}"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = byteArray.Length

        ' Escribe los datos en el cuerpo de la solicitud

        Using dataStream As Stream = Await request.GetRequestStreamAsync()
            Await dataStream.WriteAsync(byteArray, 0, byteArray.Length)
        End Using


        ' Envía la solicitud y procesa la respuesta
        Try
            Dim response As WebResponse = Await request.GetResponseAsync()
            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = Await reader.ReadToEndAsync()

                If responseFromServer = "901" Then
                    EnviarSolicitudAPI2()
                End If

                Dim xmlDoc As New XmlDocument()
                xmlDoc.LoadXml(responseFromServer)
                Dim descripcionValue2 As String = ""
                ' Obtener el valor de la etiqueta <descripcion>
                Dim descripcionValue As String = xmlDoc.SelectSingleNode("/PVresultado/descripcion").InnerText
                If descripcionValue = "0" Then
                Else
                    descripcionValue2 = xmlDoc.SelectSingleNode("/PVresultado/causaDenegada").InnerText
                End If

                If descripcionValue = "0" Then
                    MsgBox("El proceso de la transacción no ah sido completado", vbCritical + vbOKOnly, "Operación Incomppleta")
                    SiPago = 0
                ElseIf descripcionValue = "1" Then
                    MsgBox("La operación es rechazada por el banco o cancelada por el usuario", vbCritical + vbOKOnly, "Operación Denegada")
                    SiPago = 0
                ElseIf descripcionValue = "2" Then
                    If descripcionValue2 = "Denegada, Saldo insuficiente" Then
                        MsgBox("Tarjeta Denegada, Saldo insuficiente", vbCritical + vbOKOnly, "Operación Fallida")
                        SiPago = 0
                    Else
                        SiPago = 1
                        GuardarVenta()
                    End If
                ElseIf descripcionValue = "3" Then
                    MsgBox("Ya se llevo a cabo el proceso por parte de Pprosepago", vbInformation + vbOKOnly, "Operación Liquidada")
                    SiPago = 0
                End If

                'MessageBox.Show("Respuesta de la API: " & responseFromServer)
            End Using
        Catch ex As WebException
            MessageBox.Show("Error en la solicitud: " & ex.Message)
        End Try
    End Function


    Public Sub GuardarVenta()

        Try


            Dim VarUser As String = "", VarIdUsuario As Integer = 0
            Dim DsctoProd As Single = 0, PorcentDscto As Single = 0, DsctoProdTod As Single = 0
            Dim IdCliente As Integer = 0, ConteoXD As Double = 0
            Dim MySubtotal As Double = 0


            cnn1.Close() : cnn1.Open()
            For i As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(i).Cells(1).Value.ToString = "" Then
                Else
                    Dim valor As String = grdcaptura.Rows(i).Cells(0).Value.ToString
                    Dim code As String = Mid(valor, 1, InStr(1, valor, vbNewLine) - 1)
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & code & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(i).Cells(3).Value.ToString) / (1 + CDbl(rd1(0).ToString)))
                        End If
                    End If
                    rd1.Close()
                    ConteoXD = ConteoXD + CDbl(grdcaptura.Rows(i).Cells(1).Value.ToString)
                End If
            Next
            cnn1.Close()

            Dim TotalIEPSPrint As Double = 0
            Dim SubtotalPrint As Double = 0

            If Cliente = "" Then
                If (lbltipoventa.Text = "MOSTRADOR" And Resta <> 0) Or (lbltipoventa.Text = "" And Resta <> 0) Then
                    MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
                If Id_Cliente = 0 Then
                    If Resta > 0 Then
                        MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        Exit Sub
                    End If
                End If
            End If

            If modo_caja = "CAJA" Then
                If Cliente = "" And Resta <> 0 Then
                    MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    frmVentasTouchPago.txtefectivo.Focus().Equals(True)
                    Exit Sub
                End If
            End If
            If grdcaptura.Rows.Count < 0 Then Exit Sub
            If Resta <> 0 Then
                If modo_caja = "CAJA" Then
                    If Cliente = "" Then
                        MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        frmVentasTouchPago.txtefectivo.Focus().Equals(True)
                        Exit Sub
                    End If
                End If
            End If

            Dim Credito_Cliente As Double = 0
            Dim AFavor_Cliente As Double = 0
            Dim Adeuda_Cliente As Double = 0

            cnn1.Close() : cnn1.Open()

            If Cliente = "" Then
                IdCliente = 0
                Credito_Cliente = 0
                AFavor_Cliente = 0
                Adeuda_Cliente = 0
            Else
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Clientes where Nombre='" & Cliente & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        IdCliente = rd1("Id").ToString
                        Credito_Cliente = rd1("Credito").ToString
                    End If
                Else
                    IdCliente = 0
                End If
                rd1.Close()

                Dim MySaldo1 As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoI where Id=(select max(Id) from AbonoI where IdCliente=" & IdCliente & ")"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo1 = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                        If MySaldo1 < 0 Then
                            Adeuda_Cliente = 0
                            AFavor_Cliente = Math.Abs(MySaldo1)
                            AFavor_Cliente = FormatNumber(AFavor_Cliente, 2)
                        Else
                            AFavor_Cliente = 0
                            Adeuda_Cliente = Math.Abs(MySaldo1)
                            Adeuda_Cliente = FormatNumber(Adeuda_Cliente, 2)
                        End If
                    End If
                Else
                    Adeuda_Cliente = 0
                    AFavor_Cliente = 0
                End If
                rd1.Close()
            End If

            If validaTarjeta = 0 Then
                If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub
            Else
                If SiPago = 0 Then
                    If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub
                End If
            End If

            'Comienza proceso de guardado de la venta
            If validaTarjeta <> 0 Then
                If hayTerminal = 0 Then
                    GoTo kakaxd
                End If
            End If

            If SiPago = 0 Then
                If validaTarjeta <> 0 Then
                    EnviarSolicitudAPI()
                    Exit Sub
                ElseIf SiPago = 1 Then
                    GoTo kakaxd
                End If
            Else
                GoTo kakaxd
            End If



kakaxd:


            Dim credito_dispo As Double = (Credito_Cliente + AFavor_Cliente) - ((CDbl(lblTotal.Text) + Adeuda_Cliente) - (MontoEfectivo + MontoTarjeta))

            If Resta > 0 Then
                If lbltipoventa.Text <> "MOSTRADOR" And ((CDbl(lblTotal.Text) + Adeuda_Cliente) - (MontoTarjeta + MontoEfectivo)) > (Credito_Cliente + AFavor_Cliente) Then
                    MsgBox("No se puede completar la operación porque se rebasaría el crédito disponible." & vbNewLine & "Crédito disponible: " & FormatNumber(Credito_Cliente - Adeuda_Cliente, 2) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close() : frmVentasTouchPago.txtefectivo.Focus().Equals(True) : Exit Sub
                End If
            End If

            If frmVentasTouchPago.Visible = True Then
                frmVentasTouchPago.Hide()
            End If

            Dim MyStatus As String = ""
            Dim ACuenta As Double = 0
            Dim ACUenta2 As Double = 0
            Dim MyMonto As Double = 0

            Dim SubTotal As Double = 0
            Dim IVA_Vent As Double = 0
            Dim Total_Ve As Double = 0
            Dim Descuento As Double = 0
            Dim MontoSDesc As Double = 0

            Dim CodCadena As String = ""
            Dim cadena As String = ""
            Dim ope1 As Double = 0
            Dim Car As Integer = 0

            Dim letters As String = ""
            Dim Numeros As String = ""
            Dim Letras As String = ""
            Dim lic As String = ""

            ope1 = Math.Cos(CDbl(lblFolio.Text))
            If ope1 > 0 Then
                cadena = Strings.Left(Replace(CStr(ope1), ".", "9"), 10)
            Else
                cadena = Strings.Left(Replace(CStr(Math.Abs(ope1)), ".", "8"), 10)
            End If
            For i = 1 To 10
                Car = Mid(cadena, i, 1)
                Select Case Car
                    Case Is = 0
                        letters = letters & "Y"
                    Case Is = 1
                        letters = letters & "Z"
                    Case Is = 2
                        letters = letters & "W"
                    Case Is = 3
                        letters = letters & "H"
                    Case Is = 4
                        letters = letters & "S"
                    Case Is = 5
                        letters = letters & "B"
                    Case Is = 6
                        letters = letters & "C"
                    Case Is = 7
                        letters = letters & "P"
                    Case Is = 8
                        letters = letters & "Q"
                    Case Is = 9
                        letters = letters & "A"
                    Case Else
                        letters = letters & Car
                End Select
            Next
            For w = 1 To 10 Step 2
                Numeros = Mid(lblFolio.Text, w, 4)
                Letras = Mid(letters, w, 4)
                lic = lic & Numeros & Letras & "-"
            Next
            lic = Strings.Left(lic, Len(lic) - 1)
            CodCadena = lic
            cadenafact = Trim(CodCadena)

            Select Case lbltipoventa.Text
                Case Is = "MOSTRADOR"
                    IdCliente = 0
                    Cliente = ""
                    ACuenta = FormatNumber((MontoEfectivo - Cambio) + MontoTarjeta, 2)
                    MySubtotal = FormatNumber(MySubtotal, 2)

                    If Resta = 0 Then
                        MyStatus = "PAGADO"
                    Else
                        MyStatus = "RESTA"
                    End If

                    IVA_Vent = FormatNumber(CDbl(lblTotal.Text) - lblTotal.Text, 2)
                    SubTotal = FormatNumber(MySubtotal, 2)
                    Total_Ve = FormatNumber(CDbl(lblTotal.Text), 2)
                    Descuento = globaltotal - CDec(lblTotal.Text)
                    Descuento = FormatNumber(Descuento, 2)
                    MontoSDesc = FormatNumber(CDbl(lblTotal.Text) - Descuento, 2)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Comentario,StatusE,IP,Franquicia,Formato,Fecha,CodFactura) values(" & IdCliente & ",'" & Cliente & "','" & Direccion & "'," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACuenta & "," & Resta & ",'" & lblatiende.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','','" & MyStatus & "','',''," & MontoSDesc & ",'','',0,'" & dameIP2() & "',1,'TICKET','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & cadenafact & "')"
                    cmd1.ExecuteNonQuery()
                Case Is <> "MOSTRADOR"
                    MyMonto = MontoEfectivo + MontoTarjeta + AFavor_Cliente
                    MySubtotal = FormatNumber(MySubtotal, 2)

                    If MyMonto > CDbl(lblTotal.Text) Then
                        ACUenta2 = FormatNumber(CDbl(lblTotal.Text), 2)
                        Resta = 0
                    Else
                        ACUenta2 = FormatNumber(MyMonto, 2)
                        Resta = FormatNumber(CDbl(lblTotal.Text) - MyMonto, 2)
                    End If

                    If Resta = 0 Then
                        MyStatus = "PAGADO"
                    Else
                        MyStatus = "RESTA"
                    End If

                    IVA_Vent = FormatNumber(CDbl(lblTotal.Text) - MySubtotal, 2)
                    SubTotal = FormatNumber(MySubtotal, 2)
                    Total_Ve = FormatNumber(CDbl(lblTotal.Text), 2)
                    Descuento = 0
                    MontoSDesc = FormatNumber(CDbl(lblTotal.Text) - Descuento, 2)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Comentario,StatusE,IP,Franquicia,Formato,Fecha,CodFactura) values(" & IdCliente & ",'" & Cliente & "','" & Direccion & "'," & SubTotal & "," & IVA_Vent & "," & Total_Ve & "," & Descuento & ",0," & ACUenta2 & "," & Resta & ",'" & lblatiende.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','','','" & MyStatus & "','',''," & MontoSDesc & ",'','',0,'" & dameIP2() & "',1,'TICKET','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & cadenafact & "')"
                    cmd1.ExecuteNonQuery()
            End Select

            MYFOLIO = 0

            Do Until MYFOLIO <> 0
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select MAX(Folio) from Ventas WHERE IP='" & dameIP2() & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MYFOLIO = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())
                    End If
                End If
                rd1.Close()
            Loop



            'Actualiza tablas de pago
            If MontoTarjeta > 0 Or MontoMonedero Then
                If MontoMonedero > 0 Then
                    Dim SaldoMone As Double = 0
                    Dim NuveoSald As Double = 0
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from MovMonedero where Id=(select MAX(Id) from MovMonedero where Monedero='" & Monedero & "')"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            SaldoMone = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                        End If
                    End If
                    rd1.Close()
                    NuveoSald = SaldoMone - MontoMonedero

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) values('" & Monedero & "','Venta',0," & MontoMonedero & "," & NuveoSald & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MYFOLIO & ")"
                    cmd1.ExecuteNonQuery()
                End If
                If MontoTarjeta > 0 Then

                End If
            End If

            'Actualiza [Monedero] / [MovMonedero]
            If Monedero <> "" Then
                Dim sal_monedero As Double = 0
                Dim porc_mone As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from MovMonedero where Id=(select MAX(Id) from MovMonedero where Monedero='" & Monedero & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sal_monedero = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Monedero where Barras='" & Monedero
                If rd1.HasRows Then
                    If rd1.Read Then
                        porc_mone = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                Dim nvo_saldo As Double = 0
                Dim porcentaje As Double = 0
                Dim ope As Double = 0

                If porc_mone > 0 Then
                    porcentaje = porc_mone / 100
                    ope = CDbl(lblTotal.Text) * ope
                    nvo_saldo = FormatNumber(ope + sal_monedero, 2)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Monedero set Saldo=" & nvo_saldo & " where Barras='" & Monedero & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) values('" & Monedero & "','Venta'," & ope & ",0," & nvo_saldo & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MYFOLIO & ")"
                    cmd1.ExecuteNonQuery()
                End If
            End If
            cnn1.Close() : cnn1.Open()

            Dim MySaldo As Double = 0

            If lbltipoventa.Text <> "MOSTRADOR" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & IdCliente & ")"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + CDbl(lblTotal.Text), 2)
                    End If
                Else
                    MySaldo = FormatNumber(lblTotal.Text, 2)
                End If
                rd1.Close()

                If Resta > 0 And AFavor_Cliente > 0 And CDbl(lblTotal.Text) = Resta Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario,MontoSF) values(" & MYFOLIO & "," & IdCliente & ",'" & Cliente & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','" & lblatiende.Text & "'," & Resta & ")"
                    cmd1.ExecuteNonQuery()
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Banco,Referencia,Usuario) values(" & MYFOLIO & "," & IdCliente & ",'" & Cliente & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & Total_Ve & ",0," & MySaldo & ",'','','" & lblatiende.Text & "')"
                    cmd1.ExecuteNonQuery()
                End If
            End If

            ACuenta = FormatNumber(MontoEfectivo - Cambio + MontoTarjeta, 2)

            If ACuenta > 0 Then
                Dim EfectivoX As Double = FormatNumber(MontoEfectivo - Cambio, 2)
                MontoTarjeta = FormatNumber(MontoTarjeta, 2)
                Dim Bancos As String = ""
                Dim Refes As String = ""
                Dim soy As String = ""
                Dim soy2 As Double = 0

                'If MontoTarjeta <> 0 Then
                '    soy = "TARJETA"
                '    soy2 = MontoTarjeta
                'Else
                '    soy = "EFECTIVO"
                '    soy2 = EfectivoX
                'End If

                Select Case lbltipoventa.Text
                    Case Is = "MOSTRADOR"

                        If MontoTarjeta > 0 Then

                            soy = "TARJETA"
                            soy2 = MontoTarjeta

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Referencia,Usuario) values(" & MYFOLIO & ",0,'" & Cliente & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & soy2 & "," & MySaldo & ",'" & soy & "'," & soy2 & ",'" & Refes & "','" & lblatiende.Text & "')"
                            If cmd1.ExecuteNonQuery Then
                            Else
                            End If
                        End If

                        If EfectivoX > 0 Then
                            soy = "EFECTIVO"
                            soy2 = EfectivoX

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Referencia,Usuario) values(" & MYFOLIO & ",0,'" & Cliente & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & soy2 & "," & MySaldo & ",'" & soy & "'," & soy2 & ",'" & Refes & "','" & lblatiende.Text & "')"
                            If cmd1.ExecuteNonQuery Then
                            Else
                            End If
                        End If

                    Case Is <> "MOSTRADOR"
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & IdCliente & ")"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MySaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - ACuenta, 2)
                            End If
                        Else
                            MySaldo = FormatNumber(lblTotal.Text, 2)
                        End If
                        rd1.Close()

                        If Resta > 0 And AFavor_Cliente > 0 Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Referencia,Usuario,MontoSF) values(" & MYFOLIO & "," & IdCliente & ",'" & Cliente & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACuenta & "," & MySaldo & ",'" & soy & "'," & soy2 & ",'" & Refes & "','" & lblatiende.Text & "'," & Resta & ")"
                            cmd1.ExecuteNonQuery()
                        Else
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "insert into AbonoI(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Referencia,Usuario) values(" & MYFOLIO & "," & IdCliente & ",'" & Cliente & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACuenta & "," & MySaldo & ",'" & Refes & "','" & lblatiende.Text & "')"
                            cmd1.ExecuteNonQuery()
                        End If
                End Select
            End If
            cnn1.Close()

            cnn1.Open()
            Dim descuprod As Double = 0
            For R As Integer = 0 To grdcaptura.Rows.Count - 1

                If grdcaptura.Rows(R).Cells(0).Value.ToString = "" Then GoTo Door
                Dim myvalor As String = grdcaptura.Rows(R).Cells(0).Value.ToString
                Dim mycode As String = Mid(myvalor, 1, InStr(1, myvalor, vbNewLine) - 1)

                Dim mydesc As String = ""
                Dim myunid As String = ""
                Dim mycant As Double = grdcaptura.Rows(R).Cells(1).Value.ToString
                Dim myprecio As Double = grdcaptura.Rows(R).Cells(2).Value.ToString
                descuprod = CDbl(myprecio) * (CampoDsct / 100)
                Dim caduca As String = ""
                Dim lote As String = ""
                Dim mytotal As Double = FormatNumber(mycant * myprecio, 2)
                Dim GPrint As String = ""

                Dim ieps As Double = 0
                Dim tasaieps As Double = 0

                Dim MyIVA As Double = 0

                Dim MyMCD As Double = 0
                Dim MyMulti2 As Double = 0
                Dim MyMultiplo As Double = 0
                Dim MyDepto As String = ""
                Dim MyGrupo As String = ""
                Dim Kit As Boolean = False
                Dim Existencia As Double = 0
                Dim Pre_Comp As Double = 0

                Dim MyCostVUE As Double = 0
                Dim MyProm As Double = 0

                Dim myprecioS As Double = 0
                Dim mytotalS As Double = 0

                Dim modo_almacen As Integer = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & mycode & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        mydesc = rd1("Nombre").ToString
                        myunid = rd1("UVenta").ToString
                        tasaieps = rd1("IIEPS").ToString
                        MyIVA = rd1("IVA").ToString
                    End If
                End If
                rd1.Close()

                myprecioS = FormatNumber(myprecio / (1 + MyIVA), 6)
                mytotalS = FormatNumber(mytotal / (1 + MyIVA), 6)

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & mycode & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyCostVUE = 0
                        MyProm = 0
                        MyDepto = rd1("Departamento").ToString
                        MyGrupo = rd1("Grupo").ToString
                        Kit = rd1("ProvRes").ToString
                        MyMCD = rd1("MCD").ToString
                        MyMulti2 = rd1("Multiplo").ToString
                        GPrint = rd1("GPrint").ToString()
                        modo_almacen = rd1("Modo_Almacen").ToString
                        If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                            rd1.Close() : cnn1.Close()
                            GoTo Door
                        End If
                    End If
                End If
                rd1.Close()
                Dim existe As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        existe = rd1("Existencia").ToString
                        MyMultiplo = rd1("Multiplo").ToString
                        Existencia = existe / MyMultiplo
                        If rd1("Departamento").ToString <> "SERVICIOS" Then
                            Pre_Comp = rd1("PrecioCompra").ToString
                            MyCostVUE = Pre_Comp * (mycant / MyMCD)
                        End If
                    End If
                End If
                rd1.Close()
Door:
                If grdcaptura.Rows(R).Cells(0).Value.ToString <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into VentasDetalle(Folio,Codigo,Nombre,Unidad,Cantidad,CostoVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,CostVR,Descto,VDCosteo,TotalIEPS,TasaIEPS,Caducidad,Lote,CantidadE,Descuento,GPrint) values(" & MYFOLIO & ",'" & mycode & "','" & mydesc & "','" & myunid & "'," & mycant & "," & MyProm & "," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','','0','" & MyDepto & "','" & MyGrupo & "',''," & descuprod & ",0," & ieps & "," & tasaieps & ",'" & caduca & "','" & lote & "',0," & descuprod & ",'" & GPrint & "')"
                    cmd1.ExecuteNonQuery()

                    If MyDepto <> "SERVICIOS" And Kit = False Then


                        Dim existencia_inicial As Double = 0
                        Dim opecantreal As Double = 0
                        Dim opediferencia As Double = 0

                        Dim codigoingre As String = ""
                        Dim descripingre As String = ""
                        Dim cantiingre As Double = 0

                        If modo_almacen = 1 Then



                            cnn4.Close() : cnn4.Open()
                            cnn3.Close() : cnn3.Open()

                            cmd4 = cnn4.CreateCommand
                            cmd4.CommandText = "SELECT CodigoP,Codigo,Descrip,Cantidad FROM miprod WHERE CodigoP='" & mycode & "'"
                            rd4 = cmd4.ExecuteReader
                            Do While rd4.Read
                                If rd4.HasRows Then

                                    existencia_inicial = 0
                                    opecantreal = 0
                                    opediferencia = 0

                                    codigoingre = rd4("Codigo").ToString
                                    descripingre = rd4("Descrip").ToString
                                    cantiingre = rd4("Cantidad").ToString * mycant

                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "select Existencia,Multiplo,PrecioCompra from Productos where Codigo = '" & codigoingre & "'"
                                    rd3 = cmd3.ExecuteReader
                                    If rd3.HasRows Then
                                        If rd3.Read Then
                                            existencia_inicial = rd3(0).ToString
                                            opecantreal = cantiingre * CDec(rd3(1).ToString)
                                            opediferencia = existencia_inicial + opecantreal

                                            cnn2.Close() : cnn2.Open()
                                            cmd2 = cnn2.CreateCommand
                                            cmd2.CommandText = "INSERT INTO cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio) VALUES('" & codigoingre & "','" & descripingre & "','Venta - Ingrediente'," & existencia_inicial & "," & opecantreal & "," & opediferencia & "," & rd3(2).ToString & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & lblatiende.Text & "','" & MYFOLIO & "')"
                                            cmd2.ExecuteNonQuery()
                                            cnn2.Close()

                                        End If
                                    End If
                                    rd3.Close()


                                    cnn2.Close() : cnn2.Open()
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "UPDATE Productos SET Existencia=Existencia-" & cantiingre * mycant & "*" & MyMulti2 & " WHERE Codigo='" & codigoingre & "'"
                                    cmd2.ExecuteNonQuery()

                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "insert into Mov_Ingre(Codigo,Descripcion,Cantidad,Fecha)values('" & codigoingre & "','" & descripingre & "','" & cantiingre & "','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                                    cmd2.ExecuteNonQuery()
                                    cnn2.Close()


                                End If
                            Loop
                            rd4.Close()
                            cnn4.Close()
                            cnn3.Close()

                        Else
                            Dim nueva_existe As Double = 0
                            nueva_existe = FormatNumber(Existencia - (mycant * MyMultiplo), 2)

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                            "update Productos set CargadoInv=0, Cargado=0, Existencia=" & nueva_existe & " where Codigo='" & Strings.Left(mycode, 6) & "'"
                            cmd1.ExecuteNonQuery()

                            If Len(mycode) = 6 Then
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & Existencia & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblatiende.Text & "','" & MYFOLIO & "','','','','','')"
                                cmd1.ExecuteNonQuery()
                            Else
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & existe & "," & mycant & "," & nueva_existe & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblatiende.Text & "','" & MYFOLIO & "','','','','','')"
                                cmd1.ExecuteNonQuery()
                            End If

                        End If

                    End If
                End If

                If Kit = True Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Kits where Nombre='" & mydesc & "'"
                    rd1 = cmd1.ExecuteReader
                    cnn2.Close() : cnn2.Open()
                    Do While rd1.Read
                        If rd1.HasRows Then
                            Dim Cod As String = rd1("Codigo").ToString
                            Dim cant As Double = FormatNumber(CDbl(rd1("Cantidad").ToString) * mycant, 2)

                            Dim exi_hay As Double = 0
                            Dim exi_mas As Double = 0

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select * from Productos where Codigo='" & Strings.Left(Cod, 7) & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    exi_hay = rd2("Existencia").ToString
                                End If
                            End If
                            rd2.Close()

                            exi_mas = FormatNumber(exi_hay - cant, 2)

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & mycode & "','" & mydesc & "','Venta'," & exi_hay & "," & mycant & "," & exi_mas & "," & myprecio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblatiende.Text & "','" & MYFOLIO & "','','','','','')"
                            cmd2.ExecuteNonQuery()
                        End If
                    Loop
                    cnn2.Close()
                    rd1.Close()
                End If
            Next
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try


        Try

            Dim Tamaño As String = ""
            Dim Impresora As String = ""

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Tamaño = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Impresora = rd1(0).ToString
                End If
            Else
                MsgBox("No tienes una impresora configurada para imprimir en formato ticket.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd2.Close() : cnn2.Close()
                rd1.Close() : cnn1.Close()

                ImprimeComanda(MYFOLIO)

                Call BorraLotes()

                btnlimpiar.PerformClick()
                MYFOLIO = 0

                If modo_caja = "CAJA" Then
                Else
                    lbltipoventa.Text = "MOSTRADOR"
                End If
                txtbarras.Focus().Equals(True)
                MYFOLIO = 0
                Exit Sub
            End If
            cnn1.Close()
            If MsgBox("¿Deseas imprimir nota de venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Ventas() : Exit Sub
                If Tamaño = "80" Then
                    pVenta80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pVenta80.Print()
                End If
                If Tamaño = "58" Then
                    pVenta58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pVenta58.Print()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString.ToString())
            cnn1.Close()
        End Try

        ImprimeComanda(MYFOLIO)

        Call BorraLotes()

        btnlimpiar.PerformClick()

        If modo_caja = "CAJA" Then
        Else
            lbltipoventa.Text = "MOSTRADOR"
        End If
        txtbarras.Focus().Equals(True)

    End Sub

    Private Sub Termina_Error_Ventas()
        ImprimeComanda(MYFOLIO)

        Call BorraLotes()

        btnlimpiar.PerformClick()
        MYFOLIO = 0

        If modo_caja = "CAJA" Then
        Else
            lbltipoventa.Text = "MOSTRADOR"
        End If
        txtbarras.Focus().Equals(True)
    End Sub

    Private Sub ImprimeComanda(ByVal Folio As Integer)
        Dim impresora As String = ""

        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select distinct GPrint from VentasDetalle where Folio=" & Folio
            rd2 = cmd2.ExecuteReader

            cnn3.Close() : cnn3.Open()

            Do While rd2.Read
                G_Comanda = rd2(0).ToString()
                MYFOLIO = Folio

                If G_Comanda <> "" Then
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & G_Comanda & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            impresora = rd3(0).ToString()

                            pComanda = New System.Drawing.Printing.PrintDocument
                            AddHandler pComanda.PrintPage, AddressOf pComanda_PrintPage

                            pComanda.PrinterSettings.PrinterName = impresora
                            pComanda.Print()

                            G_Comanda = ""
                            impresora = ""
                        End If
                    Else
                        MsgBox("No tienes impresora configurada para el grupo de impresión " & G_Comanda & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    rd3.Close()
                End If
            Loop
            cnn3.Close()
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub


    Private Sub pComanda_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New System.Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New System.Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New System.Drawing.Font(tipografia, 8, FontStyle.Regular)
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

        Try
            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New System.Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("C O M A N D A", New System.Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New System.Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & MYFOLIO, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 285, Y, sf)
            Y += 19

            e.Graphics.DrawString("PRODUCTO", New System.Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("CANTIDAD", New System.Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 280, Y, sf)
            Y += 6
            e.Graphics.DrawString("--------------------------------------------------------", New System.Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from VentasDetalle where Folio=" & MYFOLIO & " and GPrint='" & G_Comanda & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim nombre As String = rd1("Nombre").ToString()
                    Dim canti As Double = rd1("Cantidad").ToString()

                    e.Graphics.DrawString(Mid(nombre, 1, 45), fuente_prods, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 280, Y, sf)
                    Y += 21
                End If
            Loop
            rd1.Close()
            cnn1.Close()
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New System.Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Dim modo_caja As String = DatosRecarga("Modo")

    Private Sub txtbarras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtbarras.KeyPress
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

    Private Sub pVenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVenta80.PrintPage

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

    Private Sub pVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVenta58.PrintPage

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmVentasTouch2.Show()
        frmVentasTouch2.BringToFront()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then TextBox1.Text = "0" : lblTotal.Text = FormatNumber(lblTotal.Text, 2)

        soydescuento = TextBox1.Text
        If soydescuento >= "100" Then MsgBox("No se puede aplicar esa cantidad de descuento", vbInformation + vbOKOnly, "Delsscom Control Negocios") : lblTotal.Text = globaltotal : TextBox1.Text = "0" : Exit Sub
        CampoDsct = IIf(TextBox1.Text = "", "0", TextBox1.Text)
        Dim subtotal As Double = 0
        If lblTotal.Text = "" Then
            lblTotal.Text = "0.00"
        End If
        subtotal = lblTotal.Text
        lblTotal.Text = CDbl(globaltotal) - ((CampoDsct / 100) * CDbl(globaltotal))
        lblTotal.Text = FormatNumber(lblTotal.Text, 2)
    End Sub

    Private Sub btnlimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnlimpiar.Click
        tFolio.Stop()
        pProductos.Controls.Clear()
        pGrupos.Controls.Clear()
        pDeptos.Controls.Clear()
        txtbarras.Text = ""
        CodigoProducto = ""
        cantidad = 0
        CantidadProd = 0
        Monedero = ""
        MontoEfectivo = 0
        MontoTarjeta = 0
        MontoMonedero = 0
        Cambio = 0
        Resta = 0
        Cliente = ""
        Id_Cliente = 0
        Direccion = ""
        TotDeptos = 0
        TotGrupos = 0
        TotProductos = 0
        MYFOLIO = 0
        lbltipoventa.Text = "MOSTRADOR"
        grdcaptura.Rows.Clear()
        grdProducto.Rows.Clear()

        frmVentasTouchPago.txtefectivo.Text = "0.00"
        frmVentasTouchPago.txttarjeta.Text = "0.00"
        frmVentasTouchPago.txtcambio.Text = "0.00"
        frmVentasTouchPago.resta = 0
        frmVentasTouchPago.txtresta.Text = "0.00"
        frmVentasTouchPago.txtMonedero.Text = ""
        frmVentasTouchPago.txtmone.Text = "0.00"
        frmVentasTouchPago.cboNombre.Text = ""
        frmVentasTouchPago.txtDireccion.Text = ""
        frmVentasTouchPago.Label20.Visible = False
        frmVentasTouchPago.txtcredito.Visible = False
        frmVentasTouchPago.Label17.Visible = False
        frmVentasTouchPago.txtafavor.Visible = False
        frmVentasTouchPago.Label18.Visible = False
        frmVentasTouchPago.txtadeuda.Visible = False
        frmVentasTouchPago.txtcredito.Text = "0.00"
        frmVentasTouchPago.txtafavor.Text = "0.00"
        frmVentasTouchPago.txtadeuda.Text = "0.00"
        frmVentasTouchPago.txtsaldo.Text = "0.00"
        Refresh()
        Departamentos()
        TextBox1.Text = "0"
        globaltotal = 0
        CampoDsct = 0
        lblTotal.Text = "0.00"
        lblcantidadletra.Text = ""

        SiPago = 0
        validaTarjeta = 0
        My.Application.DoEvents()
    End Sub
End Class