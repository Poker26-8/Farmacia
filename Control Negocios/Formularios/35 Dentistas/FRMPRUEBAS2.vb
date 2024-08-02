Public Class FRMPRUEBAS2
    Private Sub btn1arr_Click(sender As Object, e As EventArgs) Handles btn1arr.Click
        btn1arr.BackColor = Color.Red
    End Sub

    Private Sub btn1der_Click(sender As Object, e As EventArgs) Handles btn1der.Click
        btn1der.BackColor = Color.Green
    End Sub

    Private Sub btn1aba_Click(sender As Object, e As EventArgs) Handles btn1aba.Click
        btn1aba.BackColor = Color.Blue
    End Sub

    Private Sub btn1izq_Click(sender As Object, e As EventArgs) Handles btn1izq.Click
        btn1izq.BackColor = Color.Yellow
    End Sub

    Private Sub btn1cen_Click(sender As Object, e As EventArgs) Handles btn1cen.Click
        btn1cen.BackColor = Color.Orange
    End Sub

    Private Sub FRMPRUEBAS2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '    Public Sub Crea_Mesas(ByVal ubicacion As String)

    '    Dim tables As Integer = 0
    '    Dim tipo As String = ""
    '    Dim id_mesero As Integer = 0

    '    Dim simesaspropia As Integer = 0
    '    Dim simesaspropusuario As Integer = 0
    '    Dim totaldepotos As Integer = 0

    '    If idempleado = 0 Then
    '        pmesas.Controls.Clear()
    '        Exit Sub
    '    End If

    '    Try
    '        cnn2.Close() : cnn2.Open()
    '        cmd2 = cnn2.CreateCommand
    '        cmd2.CommandText = "SELECT * FROM Formatos WHERE Facturas='MesasPropias'"
    '        rd2 = cmd2.ExecuteReader
    '        If rd2.HasRows Then
    '            If rd2.Read Then
    '                If rd2("numPart").ToString = 1 Then
    '                    simesaspropia = 1
    '                Else
    '                    simesaspropia = 0
    '                End If
    '            Else
    '                simesaspropia = 0
    '            End If
    '        End If
    '        rd2.Close()


    '        If simesaspropia = 1 Then
    '            cmd2 = cnn2.CreateCommand
    '            cmd2.CommandText = "SELECT Area FROM Usuarios WHERE IdEmpleado=" & id_usu_log & ""
    '            rd2 = cmd2.ExecuteReader
    '            If rd2.Read Then
    '                If rd2.HasRows Then
    '                    If rd2(0).ToString = "ADMINISTRACION" Or rd2(0).ToString = "CAJERO" Then
    '                        simesaspropusuario = 1
    '                    Else
    '                        simesaspropusuario = 0
    '                    End If
    '                End If
    '            End If
    '            rd2.Close()
    '        End If


    '        If simesaspropia = 1 Then
    '            cmd2 = cnn2.CreateCommand

    '            If simesaspropusuario = 1 Then
    '                cmd2.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
    '            Else
    '                cmd2.CommandText = "SELECT COUNT(Mesa) FROM Mesasxempleados  WHERE IdEmpleado=" & id_usu_log & ""
    '            End If
    '        Else
    '            cmd2.CommandText = "SELECT COUNT(Nombre_mesa) FROM Mesa"
    '        End If

    '        rd2 = cmd2.ExecuteReader
    '        If rd2.Read Then
    '            totaldepotos = rd2(0).ToString
    '        End If
    '        rd2.Close()

    '        cmd2 = cnn2.CreateCommand
    '        If simesaspropia = 1 Then
    '            If simesaspropusuario = 1 Then

    '                cmd2.CommandText = "SELECT Nombre_mesa,TempNom,X,y,Tipo,IdEmpleado FROM Mesa  WHERE Ubicacion='" & ubicacion & "' order by Orden"

    '            Else
    '                If tomacontralog = 1 Then
    '                    cmd2.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & id_usu_log & " AND Mesa.Ubicacion='" & ubicacion & "' order by Orden"
    '                Else
    '                    cmd2.CommandText = "SELECT Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa and Mesasxempleados.IdEmpleado = " & idempleado & " AND Mesa.Ubicacion='" & ubicacion & "' order by Orden"
    '                End If

    '            End If
    '        Else
    '            cmd2.CommandText = "SELECT Nombre_mesa,TempNom,X,Y,Tipo,IdEmpleado FROM Mesa WHERE Ubicacion='" & ubicacion & "' ORDER BY Orden"
    '        End If
    '        rd2 = cmd2.ExecuteReader
    '        Do While rd2.Read
    '            If rd2.HasRows Then
    '                Dim messa As String = ""


    '                If rd2("TempNom").ToString = "" Then
    '                    messa = rd2("Nombre_mesa").ToString
    '                Else
    '                    messa = rd2("TempNom").ToString
    '                End If

    '                btnMesa = New Button
    '                'btnMesa2.Text = rd2("Nombre_mesa").ToString
    '                btnMesa.Text = messa
    '                btnMesa.FlatStyle = FlatStyle.Flat
    '                btnMesa.FlatAppearance.BorderSize = 0
    '                btnMesa.Left = rd2("X").ToString
    '                btnMesa.Top = rd2("Y").ToString
    '                btnMesa.Name = "btnMesa(" & tables & ")"
    '                btnMesa.TextAlign = ContentAlignment.BottomCenter
    '                tipo = rd2("Tipo").ToString
    '                id_mesero = IIf(rd2("IdEmpleado").ToString = "", 0, rd2("IdEmpleado").ToString)

    '                If id_mesero <> 0 Then
    '                    cnn3.Close() : cnn3.Open()
    '                    cmd3 = cnn3.CreateCommand
    '                    cmd3.CommandText = "SELECT Color FROM Usuarios WHERE IdEmpleado=" & id_mesero
    '                    rd3 = cmd3.ExecuteReader
    '                    If rd3.HasRows Then
    '                        If rd3.Read Then
    '                            'Dim col As String = rd3(0).ToString
    '                            'btnMesa.BackColor = Color.FromArgb(col)
    '                            btnMesa.BackColor = Color.FromArgb(255, 255, 128)
    '                        End If

    '                    End If
    '                    rd3.Close()
    '                    cnn3.Close()
    '                Else
    '                    btnMesa.BackColor = Color.FromArgb(255, 255, 128)
    '                End If

    '                Dim pn As Integer = 0

    '                cnn9.Close() : cnn9.Open()
    '                cmd9 = cnn9.CreateCommand
    '                cmd9.CommandText = "select NMESA from Comandas where NMESA='" & Trim(btnMesa.Text) & "' and Status='RESTA'"
    '                rd9 = cmd9.ExecuteReader
    '                If rd9.HasRows Then
    '                    If rd9.Read Then
    '                        pn = 1

    '                        If pn <> 0 Then
    '                            btnMesa.BackColor = Color.FromArgb(255, 128, 0)
    '                        Else
    '                            btnMesa.BackColor = Color.FromArgb(255, 255, 128)
    '                        End If

    '                    End If
    '                Else
    '                    ' btnMesa2.BackColor = Color.FromArgb(255, 128, 0)
    '                End If
    '                rd9.Close()
    '                cnn9.Close()


    '                If tipo = "2" Then
    '                    Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 2.png"
    '                    If File.Exists(ruta) Then
    '                        btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 2.png")
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    Else
    '                        btnMesa.BackgroundImage = Nothing
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    End If
    '                Else
    '                    btnMesa.BackgroundImage = Nothing
    '                    btnMesa.Width = 100
    '                    btnMesa.Height = 100
    '                End If

    '                If tipo = "4" Then
    '                    Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 4.png"
    '                    If File.Exists(ruta) Then
    '                        btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 4.png")
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    Else
    '                        btnMesa.BackgroundImage = Nothing
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    End If
    '                End If

    '                If tipo = "6" Then
    '                    Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 6.png"
    '                    If File.Exists(ruta) Then
    '                        btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 6.png")
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    Else
    '                        btnMesa.BackgroundImage = Nothing
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    End If
    '                End If

    '                If tipo = "8" Then
    '                    Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 8.png"
    '                    If File.Exists(ruta) Then
    '                        btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 8.png")
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    Else
    '                        btnMesa.BackgroundImage = Nothing
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    End If
    '                End If

    '                If tipo = "10" Then
    '                    Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 10.png"
    '                    If File.Exists(ruta) Then
    '                        btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\MESA 10.png")
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    Else
    '                        btnMesa.BackgroundImage = Nothing
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    End If
    '                End If

    '                If tipo = "B" Then
    '                    Dim ruta As String = My.Application.Info.DirectoryPath & "\ImagenesProductos\BILLAR.png"
    '                    If File.Exists(ruta) Then
    '                        btnMesa.BackgroundImage = Image.FromFile(My.Application.Info.DirectoryPath & "\ImagenesProductos\BILLAR.png")
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    Else
    '                        btnMesa.BackgroundImage = Nothing
    '                        btnMesa.Width = 100
    '                        btnMesa.Height = 100
    '                    End If
    '                End If

    '                btnMesa.BackgroundImageLayout = ImageLayout.Zoom

    '                pmesas.Controls.Add(btnMesa)
    '                AddHandler btnMesa.Click, AddressOf btnMesa_Click
    '                AddHandler btnMesa.MouseDown, AddressOf btnMesa_MouseDown
    '                AddHandler btnMesa.MouseUp, AddressOf btnMesa_MouseUp
    '                AddHandler btnMesa.MouseMove, AddressOf btnMesa_MouseMove
    '                tables += 1
    '            End If
    '        Loop
    '        rd2.Close()
    '        cnn2.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try

    'Select Case Mesa.Nombre_mesa, Mesa.TempNom,Mesa.X,Mesa.Y,Mesa.Tipo,Mesa.IdEmpleado FROM Mesa, Mesasxempleados where Mesasxempleados.Mesa = Mesa.Nombre_mesa And Mesasxempleados.IdEmpleado = 22 And Mesa.Ubicacion='TEMPORALES' order by Orden
End Class