
Imports System.Net
Imports System.IO
Public Class frmMesas

    Dim tim As New Timer()

    Friend WithEvents btnArea As System.Windows.Forms.Button
    Friend WithEvents btnMesa As System.Windows.Forms.Button
    Friend WithEvents btnMesaNM As System.Windows.Forms.Button

    Dim down As Boolean = False
    Dim inicial, final As New Point
    Public foco As String = ""
    Dim NOMBREMESA As String = ""
    Dim idempleado As Integer = 0

    Public montomapeo As Double = 0
    Public mapearmesas As Integer = 0

    Dim simesaspropianm As Integer = 0
    Dim simesaspropusuarionm As Integer = 0

    Dim nombreubicacion As String = ""
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        frmPasa_Mesa.Show()
        frmPasa_Mesa.BringToFront()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        tim.Stop()

        If mapearmesas = 1 Then
            TRAERLUGAR()
        Else
            CrearBD_MesaNM()
        End If
        tim.Start()
    End Sub

    Private Sub frmMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        tim.Interval = 15000
        AddHandler tim.Tick, AddressOf Timer_Tick
        tim.Start()

        txtUsuario.Focus.Equals(True)

        Me.Text = "Mesas mapeables" & Strings.Space(55) & "COMANDERO"

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TomaContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                tomacontralog = rd1(0).ToString


                If tomacontralog = "1" Then

                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Clave,Alias FROM Usuarios WHERE IdEmpleado=" & id_usu_log
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtUsuario.Text = rd2(0).ToString
                            ' lblusuario.Text = rd2(1).ToString
                            txtUsuario.PasswordChar = "*"
                            txtUsuario.ForeColor = Color.Black
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()
                Else
                    lblusuario.Text = ""
                    txtUsuario.Text = ""
                End If

            End If
        End If
        rd1.Close()
        cnn2.Close()

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Mapeo'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                mapearmesas = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        ' If lblusuario.Text <> "" Then
        If mapearmesas = 1 Then
            TRAERLUGAR()
            primerBoton()

            pmesas.Visible = True
            pmesaNM.Visible = False

            If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
                pmesas.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
                pmesas.BackgroundImageLayout = ImageLayout.Stretch
            End If

        Else
            pmesaNM.Visible = True
            pmesas.Visible = False
            CrearBD_MesaNM()


            If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
                pmesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
                pmesaNM.BackgroundImageLayout = ImageLayout.Stretch
            End If
        End If
        'End If
    End Sub

    Public Sub primerBoton()
        For Each control As Control In parea.Controls
            If TypeOf control Is Button Then
                DirectCast(control, Button).PerformClick()
                Exit For
            End If
        Next
    End Sub


    Public Sub TRAERLUGAR()

        Dim ubi As Integer = 1
        Dim cuantos As Integer = Math.Truncate(psuperior.Height / 100)
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT Ubicacion FROM Mesa WHERE Ubicacion<>'' ORDER BY Ubicacion"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    btnArea = New Button
                    btnArea.Height = psuperior.Height
                    btnArea.Width = 80
                    btnArea.Text = rd1(0).ToString
                    btnArea.Name = "btnArea(" & ubi & ")"
                    btnArea.Tag = rd1(0).ToString

                    If ubi > cuantos And ubi < ((cuantos * 2) + 1) Then
                        btnArea.Left = (btnArea.Width * 1)
                        btnArea.Top = (ubi - (cuantos + 1)) * (btnArea.Height + 0.5)
                        '2
                    ElseIf ubi > (cuantos * 2) And ubi < ((cuantos * 3) + 1) Then
                        btnArea.Left = (btnArea.Width * 2)
                        btnArea.Top = (ubi - ((cuantos * 2) + 1)) * (btnArea.Height + 0.5)
                        '3
                    ElseIf ubi > (cuantos * 3) And ubi < ((cuantos * 4) + 1) Then
                        btnArea.Left = (btnArea.Width * 3)
                        btnArea.Top = (ubi - ((cuantos * 3) + 1)) * (btnArea.Height + 0.5)
                        '4
                    ElseIf ubi > (cuantos * 4) And ubi < ((cuantos * 5) + 1) Then
                        btnArea.Left = (btnArea.Width * 4)
                        btnArea.Top = (ubi - ((cuantos * 4) + 1)) * (btnArea.Height + 0.5)
                        '5
                    ElseIf ubi > (cuantos * 5) And ubi < ((cuantos * 6) + 1) Then
                        btnArea.Left = (btnArea.Width * 5)
                        btnArea.Top = (ubi - ((cuantos * 5) + 1)) * (btnArea.Height + 0.5)
                        '6
                    ElseIf ubi > (cuantos * 5) And ubi < ((cuantos * 7) + 1) Then
                        btnArea.Left = (btnArea.Width * 6)
                        btnArea.Top = (ubi - ((cuantos * 6) + 1)) * (btnArea.Height + 0.5)
                        '7
                    Else
                        btnArea.Left = 0
                        btnArea.Top = (ubi - 1) * (btnArea.Height + 0.5)
                    End If



                    btnArea.FlatStyle = FlatStyle.Flat
                    btnArea.FlatAppearance.BorderSize = 0
                    btnArea.FlatAppearance.MouseOverBackColor = Color.White


                    AddHandler btnArea.Click, AddressOf btnArea_Click
                    parea.Controls.Add(btnArea)
                    ubi = CDec(ubi) + 1
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub


    Private Sub btnArea_Click(sender As Object, e As EventArgs)
        pmesas.Controls.Clear()
        Dim mesa As Button = CType(sender, Button)

        nombreubicacion = mesa.Text
        Crea_Mesas(mesa.Text)
        Dim valor As String = ""
        valor = mesa.Text

        For Each control As Control In parea.Controls
            If TypeOf control Is Button Then
                Dim boton As Button = DirectCast(control, Button)
                If boton.Text = valor Then
                    mesa.BackColor = Color.FromArgb(255, 255, 128)
                Else
                    mesa.BackColor = Color.FromArgb(255, 255, 128)
                    boton.BackColor = Color.FromArgb(255, 192, 128)
                End If
            End If
        Next
        Me.Text = mesa.Text

    End Sub

    Public Sub Crea_Mesas(ByVal ubicacion As String)
        Dim tables As Integer = 0
        Dim tipo As String = ""
        Dim id_mesero As Integer = 0

        Dim simesaspropia As Integer = 0
        Dim simesaspropusuario As Integer = 0
        Dim totaldepotos As Integer = 0


        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Formatos WHERE Facturas='MesasPropias'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2("NotasCred").ToString = 1 Then
                        simesaspropia = 1
                    Else
                        simesaspropia = 0
                    End If
                Else
                    simesaspropia = 0
                End If
            End If
            rd2.Close()


            If simesaspropia = 1 Then
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Area FROM Usuarios WHERE IdEmpleado=" & id_usu_log & ""
                rd2 = cmd2.ExecuteReader
                If rd2.Read Then
                    If rd2.HasRows Then
                        If rd2(0).ToString = "ADMINISTRACION" Or rd2(0).ToString = "CAJERO" Then
                            simesaspropusuario = 1
                        Else
                            simesaspropusuario = 0
                        End If
                    End If
                End If
                rd2.Close()
            End If


            If simesaspropia = 1 Then
                cmd2 = cnn2.CreateCommand

                If simesaspropusuario = 1 Then
                    cmd2.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
                Else
                    cmd2.CommandText = "SELECT COUNT(Mesa) FROM Mesasxempleados  WHERE IdEmpleado=" & id_usu_log & ""
                End If
            Else
                cmd2.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
            End If
            rd2 = cmd2.ExecuteReader
            If rd2.Read Then
                totaldepotos = rd2(0).ToString
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            If simesaspropia = 1 Then
                If simesaspropusuario = 1 Then
                    cmd2.CommandText = "SELECT Nombre_mesa,TempNom,X,y,Tipo,IdEmpleado FROM Mesa  WHERE Ubicacion='" & ubicacion & "' order by Orden"
                Else
                    cmd2.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & id_usu_log & " AND Mesa.Ubicacion='" & ubicacion & "' order by Orden"
                End If
            Else
                cmd2.CommandText = "SELECT Nombre_mesa,TempNom,X,Y,Tipo,IdEmpleado FROM Mesa WHERE Ubicacion='" & ubicacion & "' ORDER BY Orden"
            End If
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    Dim messa As String = ""


                    If rd2("TempNom").ToString = "" Then
                        messa = rd2("Nombre_mesa").ToString
                    Else
                        messa = rd2("TempNom").ToString
                    End If

                    btnMesa = New Button
                    'btnMesa2.Text = rd2("Nombre_mesa").ToString
                    btnMesa.Text = messa
                    btnMesa.FlatStyle = FlatStyle.Flat
                    btnMesa.FlatAppearance.BorderSize = 0
                    btnMesa.Left = rd2("X").ToString
                    btnMesa.Top = rd2("Y").ToString
                    btnMesa.Name = "btnMesa(" & tables & ")"
                    btnMesa.TextAlign = ContentAlignment.BottomCenter
                    tipo = rd2("Tipo").ToString
                    id_mesero = IIf(rd2("IdEmpleado").ToString = "", 0, rd2("IdEmpleado").ToString)

                    If id_mesero <> 0 Then
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Color FROM Usuarios WHERE IdEmpleado=" & id_mesero
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                'Dim col As String = rd3(0).ToString
                                'btnMesa.BackColor = Color.FromArgb(col)
                                btnMesa.BackColor = Color.FromArgb(255, 255, 128)
                            End If

                        End If
                        rd3.Close()
                        cnn3.Close()
                    Else
                        btnMesa.BackColor = Color.FromArgb(255, 255, 128)
                    End If

                    Dim pn As Integer = 0

                    cnn9.Close() : cnn9.Open()
                    cmd9 = cnn9.CreateCommand
                    cmd9.CommandText = "select NMESA from Comandas where NMESA='" & Trim(btnMesa.Text) & "' and Status='RESTA'"
                    rd9 = cmd9.ExecuteReader
                    If rd9.HasRows Then
                        If rd9.Read Then
                            pn = 1

                            If pn <> 0 Then
                                btnMesa.BackColor = Color.FromArgb(255, 128, 0)
                            Else
                                btnMesa.BackColor = Color.FromArgb(255, 255, 128)
                            End If

                        End If
                    Else
                        ' btnMesa2.BackColor = Color.FromArgb(255, 128, 0)
                    End If
                    rd9.Close()
                    cnn9.Close()


                    If tipo = "2" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 2.png"
                        If File.Exists(ruta) Then
                            btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 2.png")
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        Else
                            btnMesa.BackgroundImage = Nothing
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        End If
                    Else
                        btnMesa.BackgroundImage = Nothing
                        btnMesa.Width = 100
                        btnMesa.Height = 100
                    End If

                    If tipo = "4" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 4.png"
                        If File.Exists(ruta) Then
                            btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 4.png")
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        Else
                            btnMesa.BackgroundImage = Nothing
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        End If
                    End If

                    If tipo = "6" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 6.png"
                        If File.Exists(ruta) Then
                            btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 6.png")
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        Else
                            btnMesa.BackgroundImage = Nothing
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        End If
                    End If

                    If tipo = "8" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 8.png"
                        If File.Exists(ruta) Then
                            btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 8.png")
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        Else
                            btnMesa.BackgroundImage = Nothing
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        End If
                    End If

                    If tipo = "10" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 10.png"
                        If File.Exists(ruta) Then
                            btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 10.png")
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        Else
                            btnMesa.BackgroundImage = Nothing
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        End If
                    End If

                    If tipo = "B" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\BILLAR.png"
                        If File.Exists(ruta) Then
                            btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\BILLAR.png")
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        Else
                            btnMesa.BackgroundImage = Nothing
                            btnMesa.Width = 100
                            btnMesa.Height = 100
                        End If
                    End If

                    btnMesa.BackgroundImageLayout = ImageLayout.Zoom

                    pmesas.Controls.Add(btnMesa)
                    AddHandler btnMesa.Click, AddressOf btnMesa_Click
                    AddHandler btnMesa.MouseDown, AddressOf btnMesa_MouseDown
                    AddHandler btnMesa.MouseUp, AddressOf btnMesa_MouseUp
                    AddHandler btnMesa.MouseMove, AddressOf btnMesa_MouseMove
                    tables += 1
                End If
            Loop
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Function ObtenerTotalMesas() As Integer
        ' Aquí implementa la lógica para obtener el total de mesas
        Dim totalmesa2 As Double = 0

        cnn3.Close() : cnn3.Open()
        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "SELECT * FROM Formatos WHERE Facturas='MesasPropias'"
        rd3 = cmd3.ExecuteReader
        If rd3.HasRows Then
            If rd3.Read Then
                If rd3("NotasCred").ToString = 1 Then
                    simesaspropianm = 1
                Else
                    simesaspropianm = 0
                End If
            Else
                simesaspropianm = 0
            End If
        End If
        rd3.Close()

        If simesaspropianm = 1 Then
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Area FROM Usuarios WHERE IdEmpleado=" & id_usu_log & ""
            rd3 = cmd3.ExecuteReader
            If rd3.Read Then
                If rd3.HasRows Then
                    If rd3(0).ToString = "ADMINISTRACI´´ON" Or rd3(0).ToString = "CAJERO" Then
                        simesaspropusuarionm = 1
                    Else
                        simesaspropusuarionm = 0
                    End If
                End If
            End If
            rd3.Close()
        End If

        If simesaspropianm = 1 Then
            If simesaspropusuarionm = 1 Then
                cmd3.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
            Else
                cmd3.CommandText = "SELECT COUNT(Mesa) FROM Mesasxempleados  WHERE IdEmpleado=" & id_usu_log & ""
            End If
        Else
            cmd3.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
        End If
        rd3 = cmd3.ExecuteReader
        If rd3.Read Then
            totalmesa2 = rd3(0).ToString
        End If
        rd3.Close()
        cnn3.Close()

        Return totalmesa2
    End Function
    Public Sub CrearBD_MesaNM()

        Dim tables As Integer = 0
        Dim tipo As String = ""
        Dim id_mesero As Integer = 0
        Dim mesa As Integer = 1
        Dim messa As New List(Of String)()

        Try


            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Formatos WHERE Facturas='MesasPropias'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2("NotasCred").ToString = 1 Then
                        simesaspropianm = 1
                    Else
                        simesaspropianm = 0
                    End If
                Else
                    simesaspropianm = 0
                End If
            End If
            rd2.Close()

            If simesaspropianm = 1 Then
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Area FROM Usuarios WHERE IdEmpleado=" & id_usu_log & ""
                rd2 = cmd2.ExecuteReader
                If rd2.Read Then
                    If rd2.HasRows Then
                        If rd2(0).ToString = "ADMINISTRACIÓN" Or rd2(0).ToString = "CAJERO" Then
                            simesaspropusuarionm = 1
                        Else
                            simesaspropusuarionm = 0
                        End If
                    End If
                End If
                rd2.Close()
            End If

            cmd2 = cnn2.CreateCommand
            If simesaspropianm = 1 Then
                If simesaspropusuarionm = 0 Then
                    'cmd2.CommandText = "SELECT Nombre_mesa,TempNom,X,y,Tipo,IdEmpleado FROM Mesa order by Orden"
                    cmd2.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & id_usu_log & " order by Orden"
                Else
                    cmd2.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & id_usu_log & " order by Orden"
                End If
            Else
                cmd2.CommandText = "SELECT Nombre_mesa,TempNom,X,Y,Tipo,IdEmpleado FROM Mesa order by Orden"
            End If
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    id_mesero = IIf(rd2("IdEmpleado").ToString = "", 0, rd2("IdEmpleado").ToString)

                    If rd2("TempNom").ToString = "" Then
                        messa.Add(rd2.GetString("Nombre_mesa"))
                    Else
                        messa.Add(rd2.GetString("TempNom"))

                    End If
                End If
            Loop
            rd2.Close()

            Dim totalMesas As Double = ObtenerTotalMesas()

            If totalMesas = 0 Then Exit Sub
            Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(totalMesas)) ' Calculamos el número de columnas necesarias
            Dim cuantosFilas As Integer = Math.Ceiling(totalMesas / cuantosColumnas) ' Calculamos el número de filas necesarias

            ' Tamaño fijo de los botones
            Dim btnWidth As Integer = 140 ' Ancho fijo del botón
            Dim btnHeight As Integer = 100 ' Alto fijo del botón

            ' Espacio entre botones
            Dim espacioHorizontal As Integer = 5
            Dim espacioVertical As Integer = 5

            pmesaNM.Controls.Clear() ' Limpiamos los controles existentes en el panel

            For fila As Integer = 0 To cuantosFilas - 1
                For columna As Integer = 0 To cuantosColumnas - 1
                    If mesa > totalMesas Then Exit For ' Si ya hemos agregado todas las mesas, salimos del bucle

                    ' Obtener el nombre de la mesa correspondiente
                    Dim nombreMesa As String = messa(mesa - 1)

                    btnMesaNM = New Button
                    btnMesaNM.Text = nombreMesa
                    btnMesaNM.Width = btnWidth
                    btnMesaNM.Height = btnHeight
                    btnMesaNM.FlatStyle = FlatStyle.Flat
                    btnMesaNM.FlatAppearance.BorderSize = 0
                    btnMesaNM.Name = "btnMesa(" & nombreMesa & ")"
                    btnMesaNM.TextAlign = ContentAlignment.BottomCenter

                    If id_mesero <> 0 Then
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Color FROM Usuarios WHERE IdEmpleado=" & id_mesero
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                btnMesaNM.BackColor = Color.FromArgb(255, 255, 128)
                            End If

                        End If
                        rd3.Close()
                        cnn3.Close()
                    Else
                        btnMesaNM.BackColor = Color.FromArgb(255, 255, 128)
                    End If

                    Dim pn As Integer = 0

                    cnn9.Close() : cnn9.Open()
                    cmd9 = cnn9.CreateCommand
                    cmd9.CommandText = "select NMESA from Comandas where NMESA='" & Trim(btnMesaNM.Text) & "' and Status='RESTA'"
                    rd9 = cmd9.ExecuteReader
                    If rd9.HasRows Then
                        If rd9.Read Then
                            pn = 1

                            If pn <> 0 Then
                                btnMesaNM.BackColor = Color.FromArgb(255, 128, 0)
                            Else
                                btnMesaNM.BackColor = Color.FromArgb(255, 255, 128)
                            End If

                        End If
                    Else
                        ' btnMesa2.BackColor = Color.FromArgb(255, 128, 0)
                    End If
                    rd9.Close()

                    cmd9 = cnn9.CreateCommand
                    cmd9.CommandText = "SELECT Tipo FROM mesa WHERE Nombre_mesa='" & btnMesaNM.Text & "'"
                    rd9 = cmd9.ExecuteReader
                    If rd9.HasRows Then
                        If rd9.Read Then
                            tipo = rd9("Tipo").ToString
                        End If
                    End If
                    cnn9.Close()

                    If tipo = "2" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 2.png"
                        If File.Exists(ruta) Then
                            btnMesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 2.png")

                        End If
                    End If

                    If tipo = "4" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 4.png"
                        If File.Exists(ruta) Then
                            btnMesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 4.png")
                        End If
                    End If

                    If tipo = "6" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 6.png"
                        If File.Exists(ruta) Then
                            btnMesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 6.png")
                        End If
                    End If

                    If tipo = "8" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 8.png"
                        If File.Exists(ruta) Then
                            btnMesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 8.png")
                        End If
                    End If

                    If tipo = "10" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 10.png"
                        If File.Exists(ruta) Then
                            btnMesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 10.png")
                        End If
                    End If

                    If tipo = "B" Then
                        Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\BILLAR.png"
                        If File.Exists(ruta) Then
                            btnMesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\BILLAR.png")
                        End If
                    End If
                    btnMesaNM.BackgroundImageLayout = ImageLayout.Zoom

                    ' Posicionar el botón dentro del panel
                    btnMesaNM.Left = columna * (btnMesaNM.Width + espacioHorizontal)
                    btnMesaNM.Top = fila * (btnMesaNM.Height + espacioVertical)

                    AddHandler btnMesaNM.Click, AddressOf btnMesa_Click
                    pmesaNM.Controls.Add(btnMesaNM)
                    mesa += 1


                Next
            Next
            cnn2.Close()

            ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
            Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
            Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
            pmesaNM.AutoScrollMinSize = New Size(panelWidth, panelHeight)

            ' Ajustar el tamaño de la fuente de los botones cuando se crea el diseño inicial
            AjustarTamañoFuenteBotones()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub AjustarTamañoFuenteBotones()
        ' Calcular el tamaño de la fuente en función del tamaño del formulario
        Dim factorReduccion As Double = 24 * (pmesas.Width / 800) ' Ajusta 24 según el tamaño base del formulario (800x600)

        ' Limitar el tamaño de la fuente mínimo y máximo
        If factorReduccion < 8 Then
            factorReduccion = 8
        ElseIf factorReduccion > 24 Then
            factorReduccion = 24
        End If

        ' Iterar a través de los controles del panel y ajustar el tamaño de la fuente de los botones
        For Each control As Control In pmesas.Controls
            If TypeOf control Is Button Then
                Dim boton As Button = CType(control, Button)
                boton.Font = New Font(boton.Font.FontFamily, CType(factorReduccion, Single))
            End If
        Next
    End Sub

    Private Sub btnMesa_Click(sender As Object, e As EventArgs)

        Dim tables As Button = CType(sender, Button)
        foco = "USU"
        lbltotalmesa.Text = "0.00"

        Dim totalcomanda As Double = 0

        Dim total_billar As Double = 0

        Dim totalc As Double = 0
        frmPagar.Close()

        frmCalcula.Close()

        If tables.BackColor <> Color.White Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Total FROM Comandas WHERE Nmesa='" & tables.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        totalc = rd1(0).ToString

                        totalcomanda = CDbl(totalcomanda) + totalc
                    End If
                Loop
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Total FROM Comandas WHERE Nmesa='" & tables.Text & "' and Codigo='xc3'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        total_billar = rd1(0).ToString()
                    Else
                        total_billar = 0
                    End If
                Loop
                rd1.Close()

                lbltotalmesa.Text = FormatNumber(totalcomanda, 2)



                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Comandas WHERE Nmesa='" & tables.Text & "' ORDER BY Comensal"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'lblusuario.Text = rd1("CUsuario").ToString
                        'txtNComensales.Text = IIf(rd1("Total_comensales").ToString = "", 1, rd1("Total_comensales").ToString)

                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT TComensales FROM Comanda1 WHERE Nombre='" & tables.Text & "' ORDER BY Id desc"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtNComensales.Text = rd1(0).ToString
                    Else
                        txtNComensales.Text = "1"
                    End If
                Else
                    txtNComensales.Text = "1"
                End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

            txtMesa.Text = tables.Text
            Dim mesa As String = txtMesa.Text

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Formatos WHERE Facturas='TomaContra'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("NotasCred").ToString = "1" Then
                        Else
                            'txtUsuario.Text = ""
                        End If

                    End If
                Else
                    ' txtUsuario.Text = ""
                End If
                rd1.Close()

                'btncobro.Enabled = False
                btnconsulta.Enabled = False

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & mesa & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        NOMBREMESA = rd1("Nombre_mesa").ToString
                    End If
                End If
                rd1.Close()

                If txtNComensales.Text = "" And txtNComensales.Visible = True Then
                    txtNComensales.Focus().Equals(True)
                Else
                    txtUsuario.Focus().Equals(True)
                End If

                If tables.BackColor <> Color.White Then
                    btncobro.Enabled = True
                    btnconsulta.Enabled = True
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Contabiliza FROM Mesa WHERE Nombre_mesa='" & mesa & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(0).ToString = 1 Then
                            If total_billar = 0 Then
                                'btncobro.Enabled = False

                                frmAsigna.lblpc.Text = mesa
                                foco = "B"
                                If lblusuario.Text <> "" Then
                                    Try
                                        cnn2.Close() : cnn2.Open()
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText = "SELECT * FROM AsigPC WHERE Nombre='" & tables.Text & "'"
                                        rd2 = cmd2.ExecuteReader
                                        If rd2.HasRows Then
                                            If rd2.Read Then
                                                If MsgBox("¿Deseas consultar el tiempo de la mesa?", vbInformation + vbOKCancel, titulomensajes) = vbCancel Then Exit Sub



                                                frmCalcula.lblpc.Text = tables.Text
                                                frmCalcula.Show()
                                            End If
                                        Else
                                            frmAsigna.Show()
                                            frmAsigna.BringToFront()
                                        End If
                                        rd2.Close()
                                        cnn2.Close()
                                    Catch ex As Exception
                                        MessageBox.Show(ex.ToString)
                                        cnn2.Close()
                                    End Try
                                End If
                            End If
                        End If
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub btnMesa_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            down = True
            inicial = e.Location
        End If
    End Sub

    Private Sub btnMesa_MouseUp(sender As Object, e As MouseEventArgs)

        Dim table As Button = CType(sender, Button)
        Dim x As Double = e.X + table.Left - inicial.X
        Dim y As Double = e.Y + table.Top - inicial.Y
        down = False
        My.Application.DoEvents()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE Mesa SET X=" & x & ", Y=" & y & " WHERE Nombre_mesa='" & NOMBREMESA & "' AND Ubicacion='" & nombreubicacion & "'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress


        If AscW(e.KeyChar) = Keys.Enter Then
            Try

                If lblusuario.Text = "" And txtUsuario.Text = "" Then
                    MsgBox("Ingresa la contraseña", vbInformation + vbOKOnly)
                    Exit Sub
                Else

                    If txtMesa.Text = "" Then
                        MsgBox("Seleeciona una mesa", vbInformation + vbOKOnly, titulorestaurante)
                        Exit Sub
                    Else
                        frmAgregarProducto.lblatiende.Text = lblusuario.Text
                        frmAgregarProducto.lblmesa.Text = txtMesa.Text
                        frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                        frmAgregarProducto.Show()
                        frmAgregarProducto.BringToFront()
                        Me.Close()
                    End If

                End If

                '        cnn1.Close() : cnn1.Open()
                '        cmd1 = cnn1.CreateCommand
                '        cmd1.CommandText = "SELECT Alias,Status,IdEmpleado FROM Usuarios WHERE Clave='" & txtUsuario.Text & "'"
                '        rd1 = cmd1.ExecuteReader
                '        If rd1.HasRows Then
                '            If rd1.Read Then
                '                lblusuario.Text = rd1(0).ToString
                '                idempleado = rd1(2).ToString
                '                id_usu_log = rd1(2).ToString

                '                If rd1(1).ToString Then
                ' KeyOP(foco)

                '                    If mapearmesas = 1 Then
                '                        TRAERLUGAR()
                '                        primerBoton()

                '                        pmesas.Visible = True
                '                        pmesaNM.Visible = False

                '                        If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
                '                            pmesas.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
                '                            pmesas.BackgroundImageLayout = ImageLayout.Stretch
                '                        End If
                '                    Else
                '                        pmesaNM.Visible = True
                '                        pmesas.Visible = False
                '                        CrearBD_MesaNM()
                '                        If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
                '                            pmesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
                '                            pmesaNM.BackgroundImageLayout = ImageLayout.Stretch
                '                        End If
                '                    End If

                '                Else
                '                    MsgBox("El usuario no esta activo contacte a su administrador", vbInformation + vbOKOnly, titulomensajes)
                '                    rd1.Close()
                '                    cnn1.Close()
                '                End If
                '            Else
                '                MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulomensajes)
                '                cnn1.Close()
                '                Exit Sub
                '            End If
                '        Else
                '            lblusuario.Text = ""
                '            txtUsuario.Text = ""
                '            txtMesa.Text = ""
                '            Exit Sub
                '        End If
                '        rd1.Close()
                '        cnn1.Close()

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
                Dim mesero As Integer = 0
                Dim VarArea As String = ""
                Dim VarComen As String = ""

                If frmPagar.Visible = False Then
                    If txtUsuario.Text <> "" And lblusuario.Text <> "" Then

                        Try
                            cnn1.Close() : cnn1.Open()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "SELECT * FROM Usuarios WHERE Clave='" & txtUsuario.Text & "'"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    usuarioo = rd1("IdEmpleado").ToString
                                    VarArea = rd1("Area").ToString
                                End If
                            End If
                            rd1.Close()

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "SELECT * FROM Mesa WHERE Nombre_mesa='" & txtMesa.Text & "'"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    mesero = IIf(rd1("IdEmpleado").ToString = "", 0, rd1("IdEmpleado").ToString)
                                End If
                            End If
                            rd1.Close()
                            cnn1.Close()
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString)
                            cnn1.Close()
                        End Try

                        Dim id1 As Integer = usuarioo
                        Dim id2 As Integer = mesero

                        If id1 = id2 Then

                            cnn1.Close() : cnn1.Open()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "SELECT * FROM Comandas WHERE Nmesa='" & txtMesa.Text & "'"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then

                                    VarComen = rd1("CUsuario").ToString

                                    'cnn2.Close() : cnn2.Open()
                                    'cmd2 = cnn2.CreateCommand
                                    'cmd2.CommandText = ""
                                    'cmd2.ExecuteNonQuery()
                                    'cnn2.Close()

                                    If VarArea = "ADMINISTRACIÓN" Or VarComen = lblusuario.Text Then
                                        frmAgregarProducto.Show()
                                        My.Application.DoEvents()
                                        frmAgregarProducto.lblatiende.Text = lblusuario.Text
                                        frmAgregarProducto.lblmesa.Text = txtMesa.Text
                                        frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                                        Me.Close()
                                    Else
                                        If VarComen = lblusuario.Text Then
                                            frmAgregarProducto.Show()
                                            My.Application.DoEvents()
                                            frmAgregarProducto.lblatiende.Text = lblusuario.Text
                                            frmAgregarProducto.lblmesa.Text = txtMesa.Text
                                            frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                                            Me.Close()
                                        Else
                                            MsgBox("El usuario no es correcto.", vbInformation + vbOKOnly, titulomensajes)
                                            txtUsuario.Text = ""
                                            txtUsuario.Focus().Equals(True)
                                        End If
                                    End If
                                End If
                            Else
                                frmAgregarProducto.Show()
                                My.Application.DoEvents()
                                frmAgregarProducto.lblatiende.Text = lblusuario.Text
                                frmAgregarProducto.lblmesa.Text = txtMesa.Text
                                frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                                Me.Close()
                            End If
                            rd1.Close()
                            cnn1.Close()

                        Else
                            If mesero = 0 Then
                                cnn1.Close() : cnn1.Open()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "SELECT * FROM Comandas WHERE NMESA='" & txtMesa.Text & "'"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        VarComen = rd1("CUsuario").ToString

                                        cnn2.Close() : cnn2.Open()
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText = "UPDATE Comanda1 SET TComensales=" & txtNComensales.Text & " WHERE Nombre='" & txtMesa.Text & "'"
                                        cmd2.ExecuteNonQuery()
                                        cnn2.Close()

                                        If VarArea = "ADMINISTRACIÓN" Or VarComen = lblusuario.Text Then
                                            frmAgregarProducto.Show()
                                            My.Application.DoEvents()
                                            frmAgregarProducto.lblatiende.Text = lblusuario.Text
                                            frmAgregarProducto.lblmesa.Text = txtMesa.Text
                                            frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                                            Me.Close()
                                        Else
                                            If VarComen = lblusuario.Text Then
                                                frmAgregarProducto.Show()
                                                My.Application.DoEvents()
                                                frmAgregarProducto.lblatiende.Text = lblusuario.Text
                                                frmAgregarProducto.lblmesa.Text = txtMesa.Text
                                                frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                                                Me.Close()
                                            Else
                                                MsgBox("El usuario no es correcto.", vbInformation + vbOKOnly, titulorestaurante)
                                                txtUsuario.Text = ""
                                                txtUsuario.Focus().Equals(True)
                                            End If
                                        End If

                                    End If
                                Else
                                    frmAgregarProducto.Show()
                                    My.Application.DoEvents()
                                    frmAgregarProducto.lblmesa.Text = txtMesa.Text
                                    frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                                    frmAgregarProducto.lblatiende.Text = lblusuario.Text
                                    Me.Close()
                                End If
                                rd1.Close()
                                cnn1.Close()

                            Else
                                MsgBox("No tienes asignada esta mesa, por favor selecciona otra.", vbInformation + vbOKOnly, titulomensajes)
                                txtMesa.Text = ""
                                txtUsuario.Text = ""
                                lblusuario.Text = ""
                            End If
                        End If


                    Else
                        MsgBox("Contraseña incorrecta, revisa la información registrada.", vbInformation + vbOKOnly, titulomensajes)
                        txtUsuario.Text = ""
                        txtUsuario.Focus().Equals(True)
                        Exit Sub
                    End If

                Else
                    If txtUsuario.Text <> "" And lblusuario.Text <> "" Then

                    End If
                End If

            Case "B"

                Dim contabiliza As Integer = 0
                Dim status As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias FROM Usuarios WHERE Clave='" & txtUsuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1(0).ToString

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Contabiliza,Status FROM mesa WHERE Nombre_mesa='" & txtMesa.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                contabiliza = rd2(0).ToString
                                status = rd2(1).ToString

                                If contabiliza = 1 And status = "Ocupada" Then
                                    frmAgregarProducto.Show()
                                    My.Application.DoEvents()
                                    frmAgregarProducto.lblatiende.Text = lblusuario.Text
                                    frmAgregarProducto.lblmesa.Text = txtMesa.Text
                                    frmAgregarProducto.lblNcomensales.Text = txtNComensales.Text
                                End If

                            End If
                        End If
                        rd2.Close()

                    End If
                End If
                cnn2.Close()
                rd1.Close()
                cnn1.Close()
        End Select
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Me.Text = "Mesas"
        txtMesa.Text = ""
        parea.Controls.Clear()
        pmesas.Controls.Clear()

        If mapearmesas = 1 Then
            TRAERLUGAR()
        Else
            CrearBD_MesaNM()
        End If

        lbltotalmesa.Text = ""
        montomapeo = 0

    End Sub

    Private Sub btnMesa_MouseMove(sender As Object, e As MouseEventArgs)
        Dim table As Button = CType(sender, Button)
        If (down) Then
            table.Left = e.X + table.Left - inicial.X
            table.Top = e.Y + table.Top - inicial.Y
        End If
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtUsuario.Text = txtUsuario.Text + btn1.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtUsuario.Text = txtUsuario.Text + btn3.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtUsuario.Text = txtUsuario.Text + btn4.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtUsuario.Text = txtUsuario.Text + btn5.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtUsuario.Text = txtUsuario.Text + btn6.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtUsuario.Text = txtUsuario.Text + btn7.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtUsuario.Text = txtUsuario.Text + btn8.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtUsuario.Text = txtUsuario.Text + btn9.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtUsuario.Text = txtUsuario.Text + btn0.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btnborra_Click(sender As Object, e As EventArgs) Handles btnborra.Click
        txtUsuario.Text = CutCad(txtUsuario.Text)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtUsuario.Text = txtUsuario.Text + btn2.Text
        txtUsuario.Focus.Equals(True)
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        txtUsuario_KeyPress(txtUsuario, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub txtMesa_TextChanged(sender As Object, e As EventArgs) Handles txtMesa.TextChanged
        If txtMesa.Text = "" Then
        Else
            btnconsulta.Enabled = True
        End If
    End Sub

    Private Sub btnconsulta_Click(sender As Object, e As EventArgs) Handles btnconsulta.Click
        frmConsultaMapeo.lblmesa.Text = txtMesa.Text
        frmConsultaMapeo.Show()
    End Sub

    Private Sub btnjuntar_Click(sender As Object, e As EventArgs) Handles btnjuntar.Click

        Try
            Dim IDEMPLEADO As Integer = 0
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT IdEmpleado FROM Usuarios WHERE Clave='" & txtUsuario.Text & "' AND Alias='" & lblusuario.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then

                    IDEMPLEADO = rd2(0).ToString

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT JuntarM FROM permisosm WHERE IdEmpleado=" & IDEMPLEADO & ""
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If rd3(0).ToString = 1 Then
                                frmJuntarMesas.Show()
                            Else
                                MsgBox("EL usuario no cuenta con permisos para realizar esta operación", vbInformation + vbOKOnly, titulomensajes)
                                Exit Sub
                            End If
                        End If
                    Else
                        MsgBox("No tiene asignados permisos este usuario", vbInformation + vbOKOnly, titulomensajes)
                        Exit Sub
                    End If
                    rd3.Close()
                    cnn3.Close()

                End If
            Else
                MsgBox("Usuario o contraseña invalidos", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
            rd2.Close()
            cnn2.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
            cnn3.Close()
        End Try

    End Sub

    Private Sub btncambiar_Click(sender As Object, e As EventArgs) Handles btncambiar.Click


        Dim cambiomesa As Integer = 0

        If txtMesa.Text = "" Then
            MsgBox("Debe seleccionar una mesa con consumo de favor", vbInformation + vbOKOnly, titulomensajes)
            Exit Sub
        End If

        If lblusuario.Text = "" Then
            MsgBox("Ingrese la clave de Usuario", vbInformation + vbOKOnly, titulomensajes)
            Exit Sub
        Else
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CambioM FROM permisosm WHERE IdEmpleado='" & id_usu_log & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cambiomesa = rd1(0).ToString

                    If cambiomesa = 1 Then
                        frmCambiarM.lblmesa.Text = txtMesa.Text
                        frmCambiarM.Show()
                    Else
                        MsgBox("No cuentas con permisos para cambiar de mesa", vbInformation + vbOKOnly, titulomensajes)
                        Exit Sub
                    End If


                End If
            Else
                MsgBox("Este usuario no tiene Permisos para cambiar la mesa", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

        End If

    End Sub

    Private Sub btncobro_Click(sender As Object, e As EventArgs) Handles btncobro.Click
        If lbltotalmesa.Text = "0.00" Then
            Exit Sub

        Else
            Try
                Dim idemp As Integer = 0

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT IdEmpleado FROM Usuarios WHERE Clave='" & txtUsuario.Text & "' AND Alias='" & lblusuario.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        idemp = rd2(0).ToString

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT CobrarM FROM permisosm WHERE IdEmpleado=" & idemp & ""
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                If rd3(0).ToString = 1 Then

                                    montomapeo = 0

                                    cnn1.Close() : cnn1.Open()
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText = "SELECT SUM(Total) FROM Comandas WHERE NMESA='" & txtMesa.Text & "'"
                                    rd1 = cmd1.ExecuteReader
                                    If rd1.HasRows Then
                                        If rd1.Read Then
                                            montomapeo = IIf(montomapeo = 0, 0, montomapeo) + IIf(rd1(0).ToString = 0, 0, rd1(0).ToString)
                                            lbltotalmesa.Text = FormatNumber(montomapeo, 2)

                                            If lbltotalmesa.Text > 0 Then

                                                'frmPagar.txtSubtotalmapeo.Text = lbltotalmesa.Text
                                                'frmPagar.subtotalmapeo = lbltotalmesa.Text
                                                'frmPagar.focomapeo = 1
                                                'frmPagar.txtEfectivo.Focus.Equals(True)
                                                'frmPagar.lblmesa.Text = txtMesa.Text
                                                'frmPagar.lblusuario2.Text = lblusuario.Text
                                                'frmPagar.contraseñamesero = txtUsuario.Text
                                                'frmPagar.COMENSALES = txtNComensales.Text
                                                'frmPagar.Show()


                                                frmNuevoPagar.txtSubtotalmapeo.Text = lbltotalmesa.Text
                                                frmNuevoPagar.subtotalmapeo = lbltotalmesa.Text
                                                frmNuevoPagar.focomapeo = 1
                                                frmNuevoPagar.txtEfectivo.Focus.Equals(True)
                                                frmNuevoPagar.lblmesa.Text = txtMesa.Text
                                                frmNuevoPagar.lblusuario2.Text = lblusuario.Text
                                                frmNuevoPagar.contraseñamesero = txtUsuario.Text
                                                frmNuevoPagar.COMENSALES = txtNComensales.Text
                                                frmNuevoPagar.Show()

                                            End If
                                        Else
                                            MsgBox("La mesa aun no tienen consumo asignado", vbInformation + vbOKOnly, titulomensajes)
                                            Exit Sub
                                        End If
                                    End If
                                    rd1.Close()
                                    cnn1.Close()

                                Else
                                    MsgBox("El usuario no cuenta con permisos para cerrar la cuenta", vbInformation + vbOKOnly, titulomensajes)
                                    Exit Sub
                                End If

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
        End If

    End Sub

    Private Sub btntemporales_Click(sender As Object, e As EventArgs) Handles btntemporales.Click
        frmPasa_Mesa.Show()
        frmPasa_Mesa.BringToFront()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmNuevo.Show()
        frmNuevo.BringToFront()
    End Sub

    Private Sub frmMesas_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CrearBD_MesaNM()
        AjustarTamañoFuenteBotones()
    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged
        Try
            If txtUsuario.Text = "" Then Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtUsuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(1).ToString = 1 Then
                        lblusuario.Text = rd1(0).ToString

                        If mapearmesas = 1 Then
                            TRAERLUGAR()
                            primerBoton()

                            pmesas.Visible = True
                            pmesaNM.Visible = False

                            If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
                                pmesas.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
                                pmesas.BackgroundImageLayout = ImageLayout.Stretch
                            End If
                        Else
                            pmesaNM.Visible = True
                            pmesas.Visible = False
                            CrearBD_MesaNM()
                            If File.Exists(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg") Then
                                pmesaNM.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\FondoComanda.jpg")
                                pmesaNM.BackgroundImageLayout = ImageLayout.Stretch
                            End If
                        End If

                    Else
                        MsgBox("El usuario no esta activo contacte a su administrador")
                        txtUsuario.Text = ""
                        lblusuario.Text = ""
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulorestaurante)
                txtUsuario.Text = ""
                lblusuario.Text = ""
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmMesas_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        'tim.Stop()

        'If mapearmesas = 1 Then
        '    TRAERLUGAR()
        'Else
        '    CrearBD_MesaNM()
        'End If
        'tim.Start()
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function






End Class