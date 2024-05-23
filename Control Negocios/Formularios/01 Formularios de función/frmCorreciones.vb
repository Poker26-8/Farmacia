Imports System.Web.Services
Imports System.Web.Services.Description
Imports Core.DAL.DE
Imports iTextSharp.text

Public Class frmCorreciones

    Public CodigoProducto As String = ""
    Public descripcionpro As String = ""

    Dim TotPrefe As Integer = 0
    Dim totExtras As Integer = 0
    Dim TotPromociones As Integer = 0
    Dim TotDeptos As Integer = 0
    Dim TotGrupo As Integer = 0
    Dim TotProductos As Integer = 0
    Dim CantidadProductos As Double = 0

    'promociones
    Public cantidadPromo As Double = 0
    Public cantpromo As Double = 0
    Dim banderaPromo As Integer = 0

    Dim VarComensal As Integer = 0

    Dim nompreferencia As String = ""
    Dim nombreExtras As String = ""
    Dim nombrepromocion As String = ""

    Public cantidad As Double = 0
    Dim cantidad2 As Double = 0
    Dim respuesta As String = ""
    Dim damecodigo As String = ""

    Dim descripcion As String = ""
    Dim unidadventa As String = ""
    Dim minimo As Double = 0
    Dim ubicacion As String = ""
    Dim multiplo As Double = 0
    Dim doxuno As Integer = 0
    Dim tresxdos As Integer = 0
    Dim existencia As Double = 0
    Dim departamento As String = ""
    Dim GRUPO As String = ""

    Dim min As Double = 0
    Dim PU As Double = 0
    Dim Importe As Double = 0

    Dim TestStr As String = ""

    Friend WithEvents btnDepto, btnGrupo, btnProd, btnPrefe, btnExtra, btnPromo As System.Windows.Forms.Button

    Private Sub frmCorreciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Departamentos()
    End Sub


    Public Sub Departamentos()

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
                    btnDepto.Width = 110

                    'If TotDeptos <= 10 Then
                    '    btnDepto.Width = pDepartamento.Width
                    'Else
                    '    btnDepto.Width = pDepartamento.Width - 17
                    'End If

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
        pproductos.Controls.Clear()
        pPromociones.Controls.Clear()
        pExtras.Controls.Clear()
        pPromociones.Controls.Clear()

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
                    btnGrupo.Height = 40
                    btnGrupo.Width = 100

                    'If TotGrupo <= 10 Then
                    '    btnGrupo.Width = pgrupo.Width
                    'Else
                    '    btnGrupo.Width = pgrupo.Width - 17
                    'End If
                    btnGrupo.Top = grupos * (btnGrupo.Height + 1)
                    btnGrupo.BackColor = pgrupo.BackColor
                    btnGrupo.FlatStyle = FlatStyle.Popup
                    btnGrupo.FlatAppearance.BorderSize = 0
                    AddHandler btnGrupo.Click, AddressOf btnGrupo_Click
                    pgrupo.Controls.Add(btnGrupo)
                    If grupos = 0 Then
                        productos(depto, grupo)
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
        pPreferencias.Controls.Clear()
        pExtras.Controls.Clear()
        pPromociones.Controls.Clear()

        If cnn3.State = 1 Then
            cnn3.Close()
        End If
        CantidadProductos = 0
        productos(btnGrupo.Tag, btnGrupos.Text)
    End Sub

    Public Sub productos(ByVal depto As String, ByVal grupo As String)
        Try
            Dim prod As Integer = 1
            Dim messa As New List(Of String)()
            TotProductos = 0

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT distinct Nombre FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    TotProductos = TotProductos + 1
                End If
            Loop
            rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT DISTINCT Nombre FROM Productos WHERE Departamento='" & depto & "' AND Grupo='" & grupo & "' order by Nombre"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then
                    messa.Add(rd3.GetString("Nombre"))
                End If
            Loop
            rd3.Close()

            Dim sumadeanchosporboton As Integer = 0
            sumadeanchosporboton = TotProductos * 102

            Dim sumadealtos As Integer = 0
            sumadealtos = TotProductos * 62

            If TotProductos = 0 Then Exit Sub
            Dim cuantosColumnas As Double = Math.Ceiling(Math.Sqrt(TotProductos)) ' Calculamos el número de columnas necesarias
            cuantosColumnas = FormatNumber(cuantosColumnas, 2)

            Dim cuantosFilas As Integer = Math.Ceiling(TotProductos / cuantosColumnas) ' Calculamos el número de filas necesarias

            ' Tamaño fijo de los botones
            Dim btnWidth As Integer = 100 ' Ancho fijo del botón
            Dim btnHeight As Integer = 60 ' Alto fijo del botón

            '' Espacio entre botones
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
        pPreferencias.Controls.Clear()
        pExtras.Controls.Clear()

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Codigo FROM productos WHERE Nombre='" & btnProducto.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                CodigoProducto = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        Preferencias(CodigoProducto)
        Extras(CodigoProducto)

        banderaPromo = 0
        lblpromo.Text = "0"

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
                    respuesta = ""
                    ObtenerProducto(CodigoProducto)

                ElseIf VarComensal = 1 Then

                    damecodigo = btnProducto.Tag

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


        nompreferencia = ""

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

    Private Sub grdCaptura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim index As Integer = grdCaptura.CurrentRow.Index

        cnn1.Close() : cnn1.Open()
        If celda.ColumnIndex = 2 Then

            'frmTePreCant.txtrespuesta.Text = ""
            'frmTePreCant.txtrespuesta.Focus.Equals(True)

            '' CodigoProducto = grdCaptura.Rows(index).Cells(0).Value.ToString

            'frmTePreCant.Show()
            'frmTePreCant.BringToFront()
        End If
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


    Public Sub ObtenerProducto(Codigo As String)
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT * FROM Productos WHERE Codigo='" & Codigo & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Departamento").ToString() = "SERVICIOS" Then
                        existencia = 0
                        Exit Sub
                    End If

                    descripcion = rd1("Nombre").ToString()
                    unidadventa = rd1("UVenta").ToString()
                    minimo = rd1("Min").ToString()
                    ubicacion = rd1("Ubicacion").ToString()
                    multiplo = rd1("Multiplo").ToString()
                    existencia = rd1("Existencia").ToString()
                    GRUPO = rd1("Grupo").ToString()
                    'Consulta sí hay 2x1
                    doxuno = rd1("E1").ToString()
                    'Consulta sí hay 3x2
                    tresxdos = rd1("E2").ToString()
                End If
            End If
            rd1.Close() : cnn1.Close()

            Call find_preciovta(Codigo)
            min = existencia

            PU = (PU)
            Importe = cantidad * PU

            If GRUPO = "PROMOCIONES" Then
                UpGridCaptura()
            Else
                If Importe <> 0 Then
                    UpGridCaptura()
                Else
                    MsgBox("Este producto no tiene precio de venta, no se agregara en la comanda", vbInformation + vbOKOnly, "Delsscom® Restaurant")
                End If
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
        Dim TotalVenta As Double = 0
        Dim esta As String = ""
        Dim acumula As Integer = 0
        Dim hora_dia As String = Format(Date.Now, "HH:mm:ss")

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "SELECT * FROM Ticket"
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
                        .Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                        .Rows(qq).Cells(2).Value = .Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                        .Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                        .Rows(qq).Cells(4).Value = .Rows(qq).Cells(4).Value.ToString + CDec(FormatNumber(Importe, 2))
                        .Rows(qq).Cells(5).Value = txtRespuesta.Text

                        'grdcaptura.Rows(qq).Cells(6).Value = lblPromo.Text

                        lblTotalVenta.Text = lblTotalVenta.Text + Importe
                        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                        banderaentraa = 1
                    End If
                Next

                If banderaentraa = 0 Then
                    .Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), respuesta, "", lblpromo.Text, "")

                    lblTotalVenta.Text = lblTotalVenta.Text + Importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End If
            End With
        Else
            Dim inicio1, fin1, inicio2, fin2 As String
            Dim hora_i1, hora_f1, hora_i2, hora_f2 As String

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
                    .Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), "", "")

                    lblTotalVenta.Text = lblTotalVenta.Text + Importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End With

                With Me.grdCaptura
                    For ii As Integer = 0 To grdCaptura.Rows.Count - 1
                        grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", "")
                    Next
                End With
                Exit Sub

                ''Domingo
                'If dia = 0 Then
                '    inicio1 = "HInicioD"
                '    fin1 = "HFinD"
                '    inicio2 = "HInicioD2"
                '    fin2 = "HFinD2"
                'End If

                ''Lunes
                'If dia = 1 Then
                '    inicio1 = "HInicioL"
                '    fin1 = "HFinL"
                '    inicio2 = "HInicioL2"
                '    fin2 = "HFinL2"
                'End If

                ''Martes
                'If dia = 2 Then
                '    inicio1 = "HInicioM"
                '    fin1 = "HFinM"
                '    inicio2 = "HInicioM2"
                '    fin2 = "HFinM2"
                'End If

                ''Miercoles
                'If dia = 3 Then
                '    inicio1 = "HInicioMi"
                '    fin1 = "HFinMi"
                '    inicio2 = "HInicioMi2"
                '    fin2 = "HFinMi2"
                'End If

                ''Jueves
                'If dia = 4 Then
                '    inicio1 = "HInicioJ"
                '    fin1 = "HFinJ"
                '    inicio2 = "HInicioJ2"
                '    fin2 = "HFinJ2"
                'End If

                ''Viernes
                'If dia = 5 Then
                '    inicio1 = "HInicioV"
                '    fin1 = "HFinV"
                '    inicio2 = "HInicioV2"
                '    fin2 = "HFinV2"
                'End If

                ''Sabado
                'If dia = 6 Then
                '    inicio1 = "HInicioS"
                '    fin1 = "HFinS"
                '    inicio2 = "HInicioS2"
                '    fin2 = "HFinS2"
                'End If

                'cnn2.Close() : cnn2.Open()

                'cmd2 = cnn2.CreateCommand
                'cmd2.CommandText =
                '    "select * from Promos where Codigo='" & CodigoProducto & "'"
                'rd2 = cmd2.ExecuteReader
                'If rd2.HasRows Then
                '    If rd2.Read Then
                '        hora_i1 = rd2(inicio1).ToString()
                '        hora_f1 = rd2(fin1).ToString()
                '        hora_i2 = rd2(inicio2).ToString()
                '        hora_f2 = rd2(fin2).ToString()
                '    End If
                'End If
                'rd2.Close() : cnn2.Close()

                ''COMENTARIO'
                ''Mayor que - >
                ''Menor que - <

                ''Primera validación
                'If CDate(hora_dia) > CDate(hora_i1) And CDate(hora_dia) < CDate(hora_f1) Then
                '    Dim canti As Double = 0

                '    'Pasa porque es el día y la hora
                '    '(1) - Primero cuenta los que ya están
                '    For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '        If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '            canti = canti + grdCaptura.Rows(p1).Cells(5).Value()
                '        End If
                '    Next

                '    If canti = 0 Then
                '        grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), 1, IIf(nompreferencia = "", "", nompreferencia), lblpromo.Text, "")

                '        lblTotalVenta.Text = lblTotalVenta.Text + Importe
                '        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)

                '        Exit Sub
                '    Else
                '        Dim cantidad_final As Double = canti + cantidad
                '        Dim division As Double = 0
                '        Dim cantidad_valor As Double = 0

                '        division = FormatNumber(cantidad_final / 2.1, 0)
                '        cantidad_valor = cantidad_final - division

                '        Dim total_importe As Double = 0
                '        total_importe = PU * cantidad_valor

                '        For qq As Integer = 0 To grdCaptura.Rows.Count - 1

                '            If grdCaptura.Rows(qq).Cells(0).Value = CodigoProducto Then
                '                grdCaptura.Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                '                grdCaptura.Rows(qq).Cells(2).Value = grdCaptura.Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                '                grdCaptura.Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                '                grdCaptura.Rows(qq).Cells(4).Value = CDec(FormatNumber(total_importe, 2))
                '                grdCaptura.Rows(qq).Cells(5).Value = cantidad2
                '                grdCaptura.Rows(qq).Cells(6).Value = IIf(nompreferencia = "", "", nompreferencia)

                '            End If
                '        Next

                '        For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '            Dim total As Double = 0
                '            If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '                total = total + grdCaptura.Rows(p1).Cells(4).Value()
                '            End If
                '            lblTotalVenta.Text = FormatNumber(total, 2)
                '        Next
                '        Exit Sub
                '    End If
                'End If

                ''Segunda validación
                'If CDate(hora_dia) > CDate(hora_i2) And CDate(hora_dia) < CDate(hora_f2) Then
                '    Dim canti As Double = 0

                '    'Pasa porque es el día y la hora
                '    '(1) - Primero cuenta los que ya están
                '    For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '        If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '            canti = canti + grdCaptura.Rows(p1).Cells(2).Value()
                '        End If
                '    Next

                '    If canti = 0 Then
                '        grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), 1, IIf(nompreferencia = "", "", nompreferencia), lblpromo.Text, "")

                '        lblTotalVenta.Text = lblTotalVenta.Text + Importe
                '        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)

                '        Exit Sub
                '    Else
                '        Dim cantidad_final As Double = canti + cantidad
                '        Dim division As Double = 0
                '        Dim cantidad_valor As Double = 0

                '        division = FormatNumber(cantidad_final / 2.1, 0)
                '        cantidad_valor = cantidad_final - division

                '        Dim total_importe As Double = 0
                '        total_importe = PU * cantidad_valor

                '        For qq As Integer = 0 To grdCaptura.Rows.Count - 1

                '            If grdCaptura.Rows(qq).Cells(0).Value = CodigoProducto Then
                '                grdCaptura.Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                '                grdCaptura.Rows(qq).Cells(2).Value = grdCaptura.Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                '                grdCaptura.Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                '                grdCaptura.Rows(qq).Cells(4).Value = CDec(FormatNumber(total_importe, 2))
                '                grdCaptura.Rows(qq).Cells(5).Value = cantidad2
                '                grdCaptura.Rows(qq).Cells(6).Value = IIf(nompreferencia = "", "", nompreferencia)

                '            End If
                '        Next

                '        For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '            Dim total As Double = 0
                '            If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '                total = total + grdCaptura.Rows(p1).Cells(4).Value()
                '            End If
                '            lblTotalVenta.Text = FormatNumber(total, 2)
                '        Next
                '        Exit Sub
                '    End If
                'End If
            End If

            '3x2
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

                With grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), "", "")

                End With

                With Me.grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), "", "")

                End With
                For q As Integer = 0 To grdCaptura.Rows.Count - 1
                    TotalVenta = TotalVenta + CDbl(grdCaptura.Rows(q).Cells(4).Value.ToString)
                    lblTotalVenta.Text = FormatNumber(TotalVenta, 2)
                Next

                With Me.grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", "")

                End With
                Exit Sub

                ''Domingo
                'If dia = 0 Then
                '    inicio1 = "HInicioD3"
                '    fin1 = "HFinD3"
                '    inicio2 = "HInicioD33"
                '    fin2 = "HFinD33"
                'End If

                ''Lunes
                'If dia = 1 Then
                '    inicio1 = "HInicioL3"
                '    fin1 = "HFinL3"
                '    inicio2 = "HInicioL33"
                '    fin2 = "HFinL33"
                'End If

                ''Martes
                'If dia = 2 Then
                '    inicio1 = "HInicioM3"
                '    fin1 = "HFinM3"
                '    inicio2 = "HInicioM33"
                '    fin2 = "HFinM33"
                'End If

                ''Miercoles
                'If dia = 3 Then
                '    inicio1 = "HInicioMi3"
                '    fin1 = "HFinMi3"
                '    inicio2 = "HInicioMi33"
                '    fin2 = "HFinMi33"
                'End If

                ''Jueves
                'If dia = 4 Then
                '    inicio1 = "HInicioJ3"
                '    fin1 = "HFinJ3"
                '    inicio2 = "HInicioJ33"
                '    fin2 = "HFinJ33"
                'End If

                ''Viernes
                'If dia = 5 Then
                '    inicio1 = "HInicioV3"
                '    fin1 = "HFinV3"
                '    inicio2 = "HInicioV33"
                '    fin2 = "HFinV33"
                'End If

                ''Sabado
                'If dia = 6 Then
                '    inicio1 = "HInicioS3"
                '    fin1 = "HFinS3"
                '    inicio2 = "HInicioS33"
                '    fin2 = "HFinS33"
                'End If

                'cnn2.Close() : cnn2.Open()

                'cmd2 = cnn2.CreateCommand
                'cmd2.CommandText =
                '    "select * from Promos where Codigo='" & CodigoProducto & "'"
                'rd2 = cmd2.ExecuteReader
                'If rd2.HasRows Then
                '    If rd2.Read Then
                '        hora_i1 = rd2(inicio1).ToString()
                '        hora_f1 = rd2(fin1).ToString()
                '        hora_i2 = rd2(inicio2).ToString()
                '        hora_f2 = rd2(fin2).ToString()
                '    End If
                'End If
                'rd2.Close() : cnn2.Close()

                ''COMENTARIO'
                ''Mayor que - >
                ''Menor que - <

                ''Primera validación
                'If CDate(hora_dia) > CDate(hora_i1) And CDate(hora_dia) < CDate(hora_f1) Then
                '    Dim canti As Double = 0

                '    'Pasa porque es el día y la hora
                '    '(1) - Primero cuenta los que ya están
                '    For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '        If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '            canti = canti + grdCaptura.Rows(p1).Cells(2).Value()
                '        End If
                '    Next

                '    If canti = 0 Then
                '        grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), 1, IIf(nompreferencia = "", "", nompreferencia), lblpromo.Text, "")

                '        lblTotalVenta.Text = lblTotalVenta.Text + Importe
                '        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)

                '        Exit Sub
                '    ElseIf canti = 1 Then
                '        For qq As Integer = 0 To grdCaptura.Rows.Count - 1
                '            If grdCaptura.Rows(qq).Cells(0).Value = CodigoProducto Then
                '                grdCaptura.Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                '                grdCaptura.Rows(qq).Cells(2).Value = grdCaptura.Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                '                grdCaptura.Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                '                grdCaptura.Rows(qq).Cells(4).Value = grdCaptura.Rows(qq).Cells(4).Value.ToString + CDec(FormatNumber(Importe, 2))
                '                grdCaptura.Rows(qq).Cells(5).Value = cantidad2
                '                grdCaptura.Rows(qq).Cells(6).Value = IIf(nompreferencia = "", "", nompreferencia)
                '            End If
                '        Next
                '        For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '            Dim total As Double = 0
                '            If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '                total = total + grdCaptura.Rows(p1).Cells(4).Value()
                '            End If
                '            lblTotalVenta.Text = FormatNumber(total, 2)
                '        Next
                '        Exit Sub
                '    ElseIf canti > 1 Then
                '        Dim cantidad_final As Double = canti + cantidad
                '        Dim division As Double = 0
                '        Dim cantidad_valor As Double = 0

                '        division = FormatNumber(cantidad_final / 3.3, 0)
                '        cantidad_valor = cantidad_final - division

                '        Dim total_importe As Double = 0
                '        total_importe = PU * cantidad_valor

                '        For qq As Integer = 0 To grdCaptura.Rows.Count - 1
                '            If grdCaptura.Rows(qq).Cells(0).Value = CodigoProducto Then
                '                grdCaptura.Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                '                grdCaptura.Rows(qq).Cells(2).Value = grdCaptura.Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                '                grdCaptura.Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                '                grdCaptura.Rows(qq).Cells(4).Value = CDec(FormatNumber(total_importe, 2))
                '                grdCaptura.Rows(qq).Cells(5).Value = cantidad2
                '                grdCaptura.Rows(qq).Cells(6).Value = IIf(nompreferencia = "", "", nompreferencia)
                '            End If
                '        Next

                '        For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '            Dim total As Double = 0
                '            If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '                total = total + grdCaptura.Rows(p1).Cells(4).Value()
                '            End If
                '            lblTotalVenta.Text = FormatNumber(total, 2)
                '        Next
                '        Exit Sub
                '    End If
                'End If

                ''Segunda validación
                'If CDate(hora_dia) > CDate(hora_i1) And CDate(hora_dia) < CDate(hora_f1) Then
                '    Dim canti As Double = 0

                '    'Pasa porque es el día y la hora
                '    '(1) - Primero cuenta los que ya están
                '    For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '        If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '            canti = canti + grdCaptura.Rows(p1).Cells(2).Value()
                '        End If
                '    Next

                '    If canti = 0 Then
                '        grdCaptura.Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), 1, IIf(nompreferencia = "", "", nompreferencia), lblpromo.Text, "")

                '        lblTotalVenta.Text = lblTotalVenta.Text + Importe
                '        lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)

                '        Exit Sub
                '    ElseIf canti = 1 Then
                '        For qq As Integer = 0 To grdCaptura.Rows.Count - 1
                '            If grdCaptura.Rows(qq).Cells(0).Value = CodigoProducto Then
                '                grdCaptura.Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                '                grdCaptura.Rows(qq).Cells(2).Value = grdCaptura.Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                '                grdCaptura.Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                '                grdCaptura.Rows(qq).Cells(4).Value = grdCaptura.Rows(qq).Cells(4).Value.ToString + CDec(FormatNumber(Importe, 2))
                '                grdCaptura.Rows(qq).Cells(5).Value = cantidad2
                '                grdCaptura.Rows(qq).Cells(6).Value = IIf(nompreferencia = "", "", nompreferencia)
                '            End If
                '        Next
                '        For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '            Dim total As Double = 0
                '            If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '                total = total + grdCaptura.Rows(p1).Cells(4).Value()
                '            End If
                '            lblTotalVenta.Text = FormatNumber(total, 2)
                '        Next
                '        Exit Sub
                '    ElseIf canti > 1 Then
                '        Dim cantidad_final As Double = canti + cantidad
                '        Dim division As Double = 0
                '        Dim cantidad_valor As Double = 0

                '        division = FormatNumber(cantidad_final / 3.3, 0)
                '        cantidad_valor = cantidad_final - division

                '        Dim total_importe As Double = 0
                '        total_importe = PU * cantidad_valor

                '        For qq As Integer = 0 To grdCaptura.Rows.Count - 1
                '            If grdCaptura.Rows(qq).Cells(0).Value = CodigoProducto Then
                '                grdCaptura.Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                '                grdCaptura.Rows(qq).Cells(2).Value = grdCaptura.Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                '                grdCaptura.Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                '                grdCaptura.Rows(qq).Cells(4).Value = CDec(FormatNumber(total_importe, 2))
                '                grdCaptura.Rows(qq).Cells(5).Value = cantidad2
                '                grdCaptura.Rows(qq).Cells(6).Value = IIf(nompreferencia = "", "", nompreferencia)
                '            End If
                '        Next

                '        For p1 As Integer = 0 To grdCaptura.Rows.Count - 1
                '            Dim total As Double = 0
                '            If grdCaptura.Rows(p1).Cells(0).Value.ToString() = CodigoProducto Then
                '                total = total + grdCaptura.Rows(p1).Cells(4).Value()
                '            End If
                '            lblTotalVenta.Text = FormatNumber(total, 2)
                '        Next
                '        Exit Sub
                '    End If
                'End If
            End If

            With Me.grdCaptura

                Dim banderaentraa As Integer = 0
                banderaentraa = 0

                If acumula = 1 Then
                    For dx As Integer = 0 To grdCaptura.Rows.Count - 1
                        If CodigoProducto = grdCaptura.Rows(dx).Cells(0).Value.ToString Then
                            grdCaptura.Rows(dx).Cells(2).Value = cantidad + CDbl(grdCaptura.Rows(dx).Cells(2).Value.ToString)
                            grdCaptura.Rows(dx).Cells(4).Value = FormatNumber(Importe + CDbl(grdCaptura.Rows(dx).Cells(4).Value.ToString), 2)

                            lblTotalVenta.Text = lblTotalVenta.Text + Importe
                            lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)

                            GoTo deku
                        End If
                    Next

                    .Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), 1, IIf(nompreferencia = "", "", nompreferencia), lblpromo.Text, "")

                    lblTotalVenta.Text = lblTotalVenta.Text + Importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                Else
                    .Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), 1, IIf(nompreferencia = "", "", nompreferencia), lblpromo.Text, "")

                    lblTotalVenta.Text = lblTotalVenta.Text + Importe
                    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                End If

deku:
                'For qq As Integer = 0 To grdCaptura.Rows.Count - 1

                '        If .Rows(qq).Cells(0).Value = CodigoProducto Then
                '            .Rows(qq).Cells(1).Value = CodigoProducto & vbNewLine & descripcion
                '            .Rows(qq).Cells(2).Value = .Rows(qq).Cells(2).Value.ToString + CDec(FormatNumber(cantidad, 2))
                '            .Rows(qq).Cells(3).Value = FormatNumber(PU, 2)
                '            .Rows(qq).Cells(4).Value = .Rows(qq).Cells(4).Value.ToString + CDec(FormatNumber(Importe, 2))
                '            .Rows(qq).Cells(5).Value = cantidad2
                '            .Rows(qq).Cells(6).Value = IIf(nompreferencia = "", "", nompreferencia)

                '            lblTotalVenta.Text = lblTotalVenta.Text + Importe
                '            lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                '            banderaentraa = 1
                '        End If
                '    Next

                'If banderaentraa = 0 Then
                '    .Rows.Add(CodigoProducto, CodigoProducto & vbNewLine & descripcion, FormatNumber(cantidad, 2), FormatNumber(PU, 2), FormatNumber(Importe, 2), 1, IIf(nompreferencia = "", "", nompreferencia), lblpromo.Text, "")

                '    lblTotalVenta.Text = lblTotalVenta.Text + Importe
                '    lblTotalVenta.Text = FormatNumber(lblTotalVenta.Text, 2)
                'End If
            End With
        End If
    End Sub
End Class