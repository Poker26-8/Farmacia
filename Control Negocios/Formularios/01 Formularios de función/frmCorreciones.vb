Imports Core.DAL.DE
Imports iTextSharp.text

Public Class frmCorreciones

    Dim CodigoProducto As String = ""
    Dim TotPrefe As Integer = 0
    Dim totExtras As Integer = 0
    Dim TotPromociones As Integer = 0


    Friend WithEvents btnDepto, btnGrupo, btnProd, btnPrefe, btnExtra, btnPromo As System.Windows.Forms.Button
    Dim TotProductos As Integer = 0
    Private Sub frmCorreciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        productos()
    End Sub

    Public Sub productos()
        Try
            Dim prod As Integer = 1
            Dim messa As New List(Of String)()

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre FROM Productos order by Nombre"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    TotProductos = TotProductos + 1
                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre FROM Productos order by Nombre"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    messa.Add(rd3.GetString("Nombre"))
                End If
            Loop
            rd3.Close()



            If TotProductos = 0 Then Exit Sub
            Dim cuantosColumnas As Integer = Math.Ceiling(Math.Sqrt(TotProductos)) ' Calculamos el número de columnas necesarias
            Dim cuantosFilas As Integer = Math.Ceiling(TotProductos / cuantosColumnas) ' Calculamos el número de filas necesarias

            ' Tamaño fijo de los botones
            Dim btnWidth As Integer = 100 ' Ancho fijo del botón
            Dim btnHeight As Integer = 60 ' Alto fijo del botón

            ' Espacio entre botones
            Dim espacioHorizontal As Integer = 2
            Dim espacioVertical As Integer = 2

            pproductos.Controls.Clear()

            For fila As Integer = 0 To cuantosFilas - 1
                For columna As Integer = 0 To cuantosColumnas - 1
                    If prod > TotProductos Then Exit For ' Si ya hemos agregado todas las mesas, salimos del bucle

                    ' Obtener el nombre de la mesa correspondiente
                    Dim nombreMesa As String = messa(prod - 1)

                    btnProd = New Button
                    btnProd.Text = nombreMesa
                    btnProd.Name = "btnProducto(" & nombreMesa & ")"
                    btnProd.Height = btnHeight
                    btnProd.Width = btnWidth

                    btnProd.BackColor = Color.Orange
                    btnProd.FlatStyle = FlatStyle.Popup
                    btnProd.FlatAppearance.BorderSize = 0

                    ' Posicionar el botón dentro del panel
                    btnProd.Left = columna * (btnProd.Width + espacioHorizontal)
                    btnProd.Top = fila * (btnProd.Height + espacioVertical)

                    AddHandler btnProd.Click, AddressOf btnProd_Click
                    pproductos.Controls.Add(btnProd)
                    If prod = 0 Then
                        Preferencias(nombreMesa)
                        Extras(nombreMesa)
                    End If
                    prod += 1

                Next
            Next
            cnn3.Close()

            ' Calcular el tamaño mínimo para habilitar el scroll si es necesario
            Dim panelWidth As Integer = (cuantosColumnas * (btnWidth + espacioHorizontal)) + SystemInformation.VerticalScrollBarWidth
            Dim panelHeight As Integer = (cuantosFilas * (btnHeight + espacioVertical))
            pproductos.AutoScrollMinSize = New Size(panelWidth, panelHeight)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnProd_Click(sender As Object, e As EventArgs)
        Dim btnProducto As Button = CType(sender, Button)

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Codigo FROM productos WHERE Nombre='" & btnProducto.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                CodigoProducto = rd1(0).ToString
                MsgBox(CodigoProducto)
            End If
        End If
        rd1.Close()
        cnn1.Close()

        pPreferencias.Controls.Clear()
        pExtras.Controls.Clear()

        Preferencias(CodigoProducto)
        Extras(CodigoProducto)

    End Sub

    Public Sub Preferencias(ByVal producto As String)
        Dim preferencia As Integer = 1
        Dim cuantospre As Integer = Math.Truncate(pPreferencias.Height / 55)

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT DISTINCT IdPrefe FROM preferencia WHERE Codigo='" & CodigoProducto & "' order by Codigo"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then
                TotPrefe = TotPrefe + 1
            End If
        Loop
        rd1.Close()

        If TotPrefe <= 4 Then
            pPreferencias.AutoScroll = False
        Else
            pPreferencias.AutoScroll = True
        End If

        Try

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT distinct NombrePrefe FROM Preferencia WHERE Codigo='" & producto & "' order by NombrePrefe"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim preferencias As String = rd1("NombrePrefe").ToString

                    btnPrefe = New Button
                    btnPrefe.Text = preferencias
                    btnPrefe.Name = "btnPrefe(" & preferencia & ")"
                    btnPrefe.Height = 55
                    btnPrefe.Width = 70

                    If preferencia > cuantospre And preferencia < ((cuantospre * 2) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 1)
                        btnPrefe.Top = (preferencia - (cuantospre + 1)) * (btnPrefe.Height + 0.5)
                        '2
                    ElseIf preferencia > (cuantospre * 2) And preferencia < ((cuantospre * 3) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 2)
                        btnPrefe.Top = (preferencia - ((cuantospre * 2) + 1)) * (btnPrefe.Height + 0.5)
                        '3
                    ElseIf preferencia > (cuantospre * 3) And preferencia < ((cuantospre * 4) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 3)
                        btnPrefe.Top = (preferencia - ((cuantospre * 3) + 1)) * (btnPrefe.Height + 0.5)
                        '4
                    ElseIf preferencia > (cuantospre * 4) And preferencia < ((cuantospre * 5) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 4)
                        btnPrefe.Top = (preferencia - ((cuantospre * 4) + 1)) * (btnPrefe.Height + 0.5)
                        '5
                    ElseIf preferencia > (cuantospre * 5) And preferencia < ((cuantospre * 6) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 5)
                        btnPrefe.Top = (preferencia - ((cuantospre * 5) + 1)) * (btnPrefe.Height + 0.5)
                        '6
                    ElseIf preferencia > (cuantospre * 6) And preferencia < ((cuantospre * 7) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 6)
                        btnPrefe.Top = (preferencia - ((cuantospre * 6) + 1)) * (btnPrefe.Height + 0.5)
                        '7
                    ElseIf preferencia > (cuantospre * 7) And preferencia < ((cuantospre * 8) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 7)
                        btnPrefe.Top = (preferencia - ((cuantospre * 7) + 1)) * (btnPrefe.Height + 0.5)
                        '8
                    ElseIf preferencia > (cuantospre * 8) And preferencia < ((cuantospre * 9) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 8)
                        btnPrefe.Top = (preferencia - ((cuantospre * 8) + 1)) * (btnPrefe.Height + 0.5)
                        '9
                    ElseIf preferencia > (cuantospre * 9) And preferencia < ((cuantospre * 10) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 9)
                        btnPrefe.Top = (preferencia - ((cuantospre * 9) + 1)) * (btnPrefe.Height + 0.5)
                        '10
                    ElseIf preferencia > (cuantospre * 10) And preferencia < ((cuantospre * 11) + 1) Then
                        btnPrefe.Left = (btnPrefe.Width * 10)
                        btnPrefe.Top = (preferencia - ((cuantospre * 10) + 1)) * (btnPrefe.Height + 0.5)
                    Else
                        btnPrefe.Left = 0
                        btnPrefe.Top = (preferencia - 1) * (btnPrefe.Height + 0.5)
                    End If


                    btnPrefe.BackColor = Color.Orange
                    btnPrefe.FlatStyle = FlatStyle.Flat
                    btnPrefe.FlatAppearance.BorderSize = 1
                    AddHandler btnPrefe.Click, AddressOf btnPrefe_Click
                    pPreferencias.Controls.Add(btnPrefe)
                    preferencia += 1

                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnPrefe_Click(sender As Object, e As EventArgs)
        Dim btnPreferencia As Button = CType(sender, Button)

    End Sub

    Public Sub Extras(ByVal productos As String)
        Dim extra As Integer = 1

        Dim cuantosextra As Integer = Math.Truncate(pExtras.Height / 60)

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT distinct Descx,Codigo FROM Extras WHERE CodigoAlpha='" & productos & "' order by Descx"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    Dim extras As String = rd2("Descx").ToString

                    btnExtra = New Button
                    btnExtra.Text = extras
                    btnExtra.Tag = rd2("Codigo").ToString
                    btnExtra.Name = "btnExtra(" & extra & ")"
                    btnExtra.Height = 70
                    btnExtra.Width = 80

                    If extra > cuantosextra And extra < ((cuantosextra * 2) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 1)
                        btnExtra.Top = (extra - (cuantosextra + 1)) * (btnExtra.Height + 0.5)
                        '2
                    ElseIf extra > (cuantosextra * 2) And extra < ((cuantosextra * 3) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 2)
                        btnExtra.Top = (extra - ((cuantosextra * 2) + 1)) * (btnExtra.Height + 0.5)
                        '3
                    ElseIf extra > (cuantosextra * 3) And extra < ((cuantosextra * 4) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 3)
                        btnExtra.Top = (extra - ((cuantosextra * 3) + 1)) * (btnExtra.Height + 0.5)
                        '4
                    ElseIf extra > (cuantosextra * 4) And extra < ((cuantosextra * 5) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 4)
                        btnExtra.Top = (extra - ((cuantosextra * 4) + 1)) * (btnExtra.Height + 0.5)
                        '5
                    ElseIf extra > (cuantosextra * 5) And extra < ((cuantosextra * 6) + 1) Then
                        btnExtra.Left = (btnExtra.Width * 5)
                        btnExtra.Top = (extra - ((cuantosextra * 5) + 1)) * (btnExtra.Height + 0.5)
                    Else
                        btnExtra.Left = 0
                        btnExtra.Top = (extra - 1) * (btnExtra.Height + 0.5)
                    End If

                    btnExtra.BackColor = Color.Orange
                    btnExtra.FlatStyle = FlatStyle.Flat
                    btnExtra.FlatAppearance.BorderSize = 1
                    AddHandler btnExtra.Click, AddressOf btnExtra_Click
                    pExtras.Controls.Add(btnExtra)
                    extra += 1

                End If
            Loop
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub btnExtra_Click(sender As Object, e As EventArgs)

        Dim btnEx As Button = CType(sender, Button)
        'CodigoProducto = btnEx.Tag

        'If cantidad > 1 Then
        'Else
        '    cantidad = 1
        'End If
        'ObtenerProducto(CodigoProducto)

    End Sub

End Class