Imports System.IO
Imports MySql.Data.MySqlClient


Public Class frmTraspSalida
    Dim renglon As Integer = 0
    Dim usu_copia As String = ""

    Private config As datosSincronizador
    Private configF As datosAutoFac

    Private filenum As Integer
    Private recordLen As String
    Dim barras As String = ""
    Dim Serchixd As Boolean = False
    Dim ban As Integer = 0
    Private Sub frmTraspSalida_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Folio()
        cbodesc.Focus().Equals(True)
        usu_copia = ""

        If IO.File.Exists(ARCHIVO_DE_CONFIGURACION) Then

            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACION, OpenMode.Random, OpenAccess.ReadWrite)

            recordLen = Len(config)

            FileGet(filenum, config, 1)

            ipserver = Trim(config.ipr)
            database = Trim(config.baser)
            userbd = Trim(config.usuarior)
            passbd = Trim(config.passr)
            If IsNumeric(Trim(config.sucursalr)) Then
                susursalr = Trim(config.sucursalr)
            End If

            sTargetdSincro = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=300"

            FileClose()

            sTargetdAutoFac = ""

            If IO.File.Exists(ARCHIVO_DE_CONFIGURACION_F) Then
                filenum = FreeFile()
                FileOpen(filenum, ARCHIVO_DE_CONFIGURACION_F, OpenMode.Random, OpenAccess.ReadWrite)
                recordLen = Len(configF)
                FileGet(filenum, configF, 1)
                ipserverF = Trim(configF.ipr)
                databaseF = Trim(configF.baser)
                userbdF = Trim(configF.usuarior)
                passbdF = Trim(configF.passr)
                sTargetdAutoFac = "server=" & ipserverF & ";uid=" & userbdF & ";password=" & passbdF & ";database=" & databaseF & ";persist security info=false;connect timeout=300"

                'Label1.Text = "AutoFact base: " & databaseF
                FileClose()
            Else
                ipserverF = ""
                databaseF = ""
                userbdF = ""
                passbdF = ""
            End If

            soySucursal()
        End If

    End Sub
    Public Sub soySucursal()
        Try
            Dim cnn As MySqlConnection = New MySqlConnection
            Dim sSQL As String = "SELECT nombre FROM sucursales where Id=" & susursalr & ""
            Dim dr As DataRow
            Dim dt1 As New DataTable
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            With oData
                If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                    If .getDt(cnn, dt1, sSQL, "etres") Then
                        For Each dr In dt1.Rows
                            Label1.Text = (dr("nombre").ToString)
                        Next
                    End If
                    cnn.Close()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub Folio()
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select MAX(Folio) from Traslados where Concepto='SALIDA'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    lblfolio.Text = IIf(rd3(0).ToString = "", 0, rd3(0).ToString) + 1
                End If
            Else
                lblfolio.Text = "1"
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Sub frmTraspSalida_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cbo.Focus().Equals(True)
    End Sub

    Private Sub cbo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbo.DropDown
        cbo.Items.Clear()
        Try

            Dim sincro As Integer = 0

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Sincronizador'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    sincro = rd2(0).ToString

                End If
            End If
            rd2.Close()

            If sTargetdSincro = "" Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select distinct Nombre from Traslados where Concepto='SALIDA'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbo.Items.Add(
                        rd1(0).ToString
                        )
                Loop
                rd1.Close() : cnn1.Close()
            Else

                Dim cnn As MySqlConnection = New MySqlConnection
                Dim sSQL As String = "SELECT Distinct nombre FROM sucursales where nombre<>'" & Label1.Text & "' order by Nombre "
                Dim dt1 As New DataTable
                Dim dr As DataRow
                Dim sinfo As String = ""
                Dim oData As New ToolKitSQL.myssql
                With oData
                    If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                        If .getDt(cnn, dt1, sSQL, "etres") Then
                            For Each dr In dt1.Rows
                                cbo.Items.Add(dr("nombre").ToString)
                            Next
                        End If
                        cnn.Close()
                    End If
                End With


            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpfecha.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpfecha.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbodesc_DropDown(sender As System.Object, e As System.EventArgs) Handles cbodesc.DropDown
        If Serchixd = True Then
            Serchixd = False
        Else
            cbodesc.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select distinct Nombre from Productos where Departamento<>'SERVICIOS' ORDER BY Nombre"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbodesc.Items.Add(
                        rd1(0).ToString
                        )
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbodesc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbodesc.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbodesc.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub

            If (CodBarras()) Then
                cbocodigo.Focus().Equals(True)
            Else
                If ban = 1 Then
                    cbocodigo.Focus.Equals(True)
                Else
                    cbocodigo.Focus().Equals(True)
                End If


            End If


        End If
    End Sub

    Public Function CodBarras() As Boolean

        Try

            If cbodesc.Text <> "" Then
                Try
                    cnn1.Close()
                    cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Codigo,UVenta,Nombre,PrecioCompra,CodBarra from Productos where CodBarra='" & cbodesc.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cbocodigo.Text = rd1("Codigo").ToString
                            txtunidad.Text = rd1("UVenta").ToString
                            cbodesc.Text = rd1("Nombre").ToString
                            txtprecio.Text = rd1("PrecioCompra").ToString
                            barras = rd1("CodBarra").ToString
                            ban = 1
                        End If
                    Else
                        Exit Function
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

                Dim existenciaa As Decimal = 0
                Dim multiploo As Decimal = 0

                Try
                    cnn1.Close()
                    cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Existencia from Productos where Codigo='" & Mid(cbocodigo.Text, 1, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            existenciaa = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Multiplo from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            multiploo = rd1(0).ToString

                            If multiploo > 0 Then
                                txtexistencia.Text = FormatNumber(
                                    existenciaa / multiploo,
                                    2)
                            End If
                            If txtexistencia.Text = "" Then
                                txtexistencia.Text = "0"
                            End If
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

                Dim canti As Double = 0
                canti = IIf(txtcantidad.Text = "", 1, txtcantidad.Text)
                Dim precio As Double = 0
                precio = txtprecio.Text
                Dim tot As Double = 0
                tot = CDec(canti) * CDec(precio)
                txttotal.Text = tot

                'grdcaptura.Rows.Add(cbocodigo.Text, cbodesc.Text, txtunidad.Text, txtcantidad.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(txttotal.Text, 2), txtexistencia.Text, barras)

                'cbocodigo.Text = ""
                'cbodesc.Text = ""
                'txtunidad.Text = ""
                'txtcantidad.Text = "1"
                'txtprecio.Text = "0.00"
                'txttotal.Text = "0.00"
                'txtexistencia.Text = ""


                cbocodigo.Focus.Equals(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Function



    Private Sub cbodesc_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbodesc.SelectedValueChanged
        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Codigo from Productos where (Nombre='" & cbodesc.Text & "' or CodBarra='" & cbodesc.Text & "')"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cbocodigo.Text = rd2("Codigo").ToString
                End If
            End If
            rd2.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub cbocodigo_Click(sender As System.Object, e As System.EventArgs) Handles cbocodigo.Click
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_GotFocus(sender As Object, e As System.EventArgs) Handles cbocodigo.GotFocus
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbocodigo.Text <> "" Then
                Try
                    cnn1.Close()
                    cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Codigo,UVenta,Nombre,PrecioCompra,CodBarra from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cbocodigo.Text = rd1("Codigo").ToString
                            txtunidad.Text = rd1("UVenta").ToString
                            cbodesc.Text = rd1("Nombre").ToString
                            txtprecio.Text = rd1("PrecioCompra").ToString
                            barras = rd1("CodBarra").ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

                Dim existenciaa As Decimal = 0
                Dim multiploo As Decimal = 0

                Try
                    cnn1.Close()
                    cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Existencia from Productos where Codigo='" & Mid(cbocodigo.Text, 1, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            existenciaa = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Multiplo from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            multiploo = rd1(0).ToString

                            If multiploo > 0 Then
                                txtexistencia.Text = FormatNumber(
                                    existenciaa / multiploo,
                                    2)
                            End If
                            If txtexistencia.Text = "" Then
                                txtexistencia.Text = "0"
                            End If
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try

                txtcantidad.Focus.Equals(True)
            End If
            If AscW(e.KeyChar) = Keys.Enter And cbocodigo.Text = "" And grdcaptura.RowCount > 0 Then
                btnguardar.Focus()
            End If
        End If
    End Sub

    Private Sub txtcantidad_Click(sender As System.Object, e As System.EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If Not IsNumeric(txtcantidad.Text) Then txtcantidad.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Or txtcantidad.Text = "0" Or txtcantidad.Text = "0.00" Then
                MsgBox("Ingresa una cantidad válida", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                txtcantidad.Focus()
                Exit Sub
            End If
            txtprecio_KeyPress(txtprecio, New KeyPressEventArgs(ChrW(Keys.Enter)))
            ' txtprecio.Focus()
        End If
    End Sub

    Private Sub txtprecio_Click(sender As System.Object, e As System.EventArgs) Handles txtprecio.Click
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_GotFocus(sender As Object, e As System.EventArgs) Handles txtprecio.GotFocus
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        If Not IsNumeric(txtprecio.Text) Then txtprecio.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim existenciareal As Double = 0

            If txtcantidad.Text = "" Then txtcantidad.Focus() : Exit Sub
            If txtprecio.Text = "" Then txtprecio.Focus() : Exit Sub

            txtprecio.Text = FormatNumber(txtprecio.Text, 2)
            txttotal.Text = FormatNumber(CDec(txtprecio.Text) * CDec(txtcantidad.Text), 2)

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Caduca,Existencia FROM productos WHERE Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = 1 Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select Codigo  from LoteCaducidad where Codigo='" & cbocodigo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                For luffy As Integer = 0 To grdcaptura.Rows.Count - 1
                                    Dim c As String = grdcaptura.Rows(luffy).Cells(0).Value.ToString

                                    If cbocodigo.Text = c Then
                                        Dim ca As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString
                                        Dim sumc As Double = CDec(sumc) + CDec(ca)
                                        Dim totsuma As Double = CDec(txtcantidad.Text) + sumc
                                        If totsuma > CDec(txtexistencia.Text) Then
                                            MsgBox("La suma de las cantidades es mayor a la existencia, Favor de modificar el dato.", vbInformation + vbOKOnly, "Delsscom Farmacias")
                                            Exit Sub
                                        End If
                                    End If
                                Next

                                gbLotes.Visible = True
                                txtcodlote.Text = cbocodigo.Text
                                txtnombrelote.Text = cbodesc.Text
                                TextBox1.Text = txtcantidad.Text
                                ConsultaLotes(cbocodigo.Text)
                                My.Application.DoEvents()



                            End If
                        Else
                            MsgBox("Revisa la cantidad de lotes del  producto para poder continuar", vbExclamation + vbOKOnly, "Delsscom Farmacias")
                        End If
                        rd2.Close()
                    Else

                        existenciareal = rd1("Existencia").ToString
                        If txtcantidad.Text > existenciareal Then
                            MsgBox("La cantidad es mayor a la existencia, Debe de ser menor", vbInformation + vbOKOnly, "Delsscom Farmacias")
                            Exit Sub
                        End If

                        For luffy As Integer = 0 To grdcaptura.Rows.Count - 1

                            Dim cod As String = grdcaptura.Rows(luffy).Cells(0).Value.ToString

                            If cbocodigo.Text = cod Then
                                Dim cant As Double = grdcaptura.Rows(luffy).Cells(3).Value.ToString

                                Dim canti As Double = CDec(canti) + CDec(cant)
                                Dim totalsuma As Double = txtcantidad.Text + CDec(canti)

                                If totalsuma > existenciareal Then
                                    MsgBox("Esta por revasar la existencia, Necesita modificar la cantidad del registro", vbInformation + vbOKOnly, "Delsscom Farmacias")
                                    Exit Sub
                                End If
                            End If
                        Next

                        For xsd As Integer = 0 To grdcaptura.Rows.Count - 1
                            If cbocodigo.Text = grdcaptura.Rows(xsd).Cells(0).Value.ToString Then
                                grdcaptura.Rows(xsd).Cells(3).Value = grdcaptura.Rows(xsd).Cells(3).Value + CDec(txtcantidad.Text)
                                grdcaptura.Rows(xsd).Cells(5).Value = grdcaptura.Rows(xsd).Cells(5).Value + CDec(txttotal.Text)
                                GoTo kaka
                            End If
                        Next
                        grdcaptura.Rows.Add(cbocodigo.Text, cbodesc.Text, txtunidad.Text, txtcantidad.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(txttotal.Text, 2), txtexistencia.Text, barras)

                        '
kaka:
                        cbocodigo.Text = ""
                        cbodesc.Text = ""
                        txtunidad.Text = ""
                        txtcantidad.Text = "1"
                        txtprecio.Text = ""
                        txttotal.Text = ""
                        txtexistencia.Text = ""
                        cbodesc.Focus().Equals(True)
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
            cnn2.Close()


        End If
    End Sub

    Public Sub ConsultaLotes(varcodigo As String)
        Try
            Dim lotexd As String = ""

            DataGridView1.Rows.Clear()
            cnn7.Close() : cnn7.Open()
            cmd7 = cnn7.CreateCommand
            cmd7.CommandText = "Select Id,Lote,Caducidad,Cantidad from LoteCaducidad where Codigo='" & varcodigo & "' and Cantidad >0"
            rd7 = cmd7.ExecuteReader
            If rd7.HasRows Then
                Do While rd7.Read
                    lotexd = rd7("Lote").ToString
                    Dim fechalote As Date = rd7("Caducidad").ToString
                    Dim f As String = ""
                    f = Format(fechalote, "MM-yyyy")




                    DataGridView1.Rows.Add(False, rd7("Id").ToString, lotexd, f, "0", rd7("Cantidad").ToString)
                    My.Application.DoEvents()
                Loop
            End If
            rd7.Close()
            cnn7.Close()

            For deku As Integer = 0 To DataGridView2.Rows.Count - 1
                If DataGridView2.Rows(deku).Cells(0).Value.ToString = cbocodigo.Text Then
                    Dim lote As String = DataGridView2.Rows(deku).Cells(2).Value.ToString
                    Dim cant As Double = DataGridView2.Rows(deku).Cells(4).Value.ToString

                    For bachira As Integer = 0 To DataGridView1.Rows.Count - 1
                        If lote = DataGridView1.Rows(bachira).Cells(2).Value.ToString Then
                            DataGridView1.Rows(bachira).Cells(5).Value = CDec(DataGridView1.Rows(bachira).Cells(5).Value) - cant
                        End If
                    Next

                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn7.Close()
        End Try
    End Sub

    Private Sub txtusuario_Click(sender As System.Object, e As System.EventArgs) Handles txtusuario.Click
        txtusuario.SelectionStart = 0
        txtusuario.SelectionLength = Len(txtusuario.Text)
    End Sub

    Private Sub txtusuario_GotFocus(sender As Object, e As System.EventArgs) Handles txtusuario.GotFocus
        txtusuario.SelectionStart = 0
        txtusuario.SelectionLength = Len(txtusuario.Text)
    End Sub

    Private Sub txtusuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString
                        btnguardar.Focus.Equals(True)
                    End If
                Else
                    MsgBox("La clave del vendedor es incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close() : cnn1.Close()
                    txtusuario.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub
    Public Sub BorraLotes()
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "delete from LoteCaducidad where Cantidad<=0"
            cmd5.ExecuteNonQuery()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        usu_copia = ""
        cbo.Text = ""
        cbo.Items.Clear()
        dtpfecha.Value = Date.Now
        cbodocumento.Text = ""
        cbodocumento.Items.Clear()
        lblusuario.Text = ""
        txtusuario.Text = ""
        cbocodigo.Text = ""
        cbodesc.Text = ""
        cbodesc.Items.Clear()
        txtunidad.Text = ""
        txtcantidad.Text = "1"
        txtprecio.Text = "0.00"
        txttotal.Text = "0.00"
        txtexistencia.Text = ""
        txtcoment.Visible = False
        txtcoment.Text = ""
        grdcaptura.Rows.Clear()
        btncopia.Enabled = False
        btnguardar.Enabled = True
        barras = ""
        DataGridView2.Rows.Clear()
        DataGridView1.Rows.Clear()
        gbLotes.Visible = False
        btnguardar.Enabled = True
        BorraLotes()
        Folio()
    End Sub

    Private Sub txtcantidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcantidad.TextChanged
        If txtcantidad.Text = "" Or Not IsNumeric(txtcantidad.Text) Then Exit Sub
        If txtprecio.Text = "" Or Not IsNumeric(txtprecio.Text) Then Exit Sub
        txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
        txttotal.Text = FormatNumber(txttotal.Text, 2)
    End Sub

    Private Sub cbodesc_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbodesc.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F2
                If cbodesc.Text <> "" Then MsgBox("Primero baja el producto para asignar un comentario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbodesc.Focus().Equals(True) : Exit Sub
                If grdcaptura.Rows.Count = 0 Then MsgBox("No cuentas con productos para asignar comentarios.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
                If txtcoment.Visible = False Then
                    txtcoment.Visible = True
                    txtcoment.Focus().Equals(True)
                Else
                    txtcoment.Visible = False
                    cbodesc.Focus().Equals(True)
                End If
        End Select
    End Sub

    Private Sub txtcoment_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcoment.KeyPress
        If AscW(e.KeyChar) = 0 Then
            txtcoment.Text = ""
            txtcoment.Visible = False
            cbodesc.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcoment.Visible = False
            If renglon = 0 Then
                grdcaptura.Rows.Add("", txtcoment.Text, "", "", "", "", "", "", "", "", "", "", "", "")
            Else
                grdcaptura.Rows(renglon).Cells(1).Value = txtcoment.Text
            End If
            For t As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(t).Cells(0).Value.ToString) = "" Then
                    grdcaptura.Rows(t).DefaultCellStyle.ForeColor = Color.DarkOrange
                    grdcaptura.Rows(t).DefaultCellStyle.SelectionBackColor = Color.Pink
                    grdcaptura.Rows(t).DefaultCellStyle.SelectionForeColor = Color.Black
                End If
            Next
            txtcoment.Text = ""
            renglon = 0
            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index
        Dim CODx As String = ""
        Dim CantDX As Double = 0
        Dim MyNota As String = ""

        cbodesc.Focus().Equals(True)
        If grdcaptura.Rows.Count > 0 Then
            If grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
                renglon = grdcaptura.CurrentRow.Index
                txtcoment.Visible = True
                txtcoment.Text = grdcaptura.Rows(index).Cells(1).Value.ToString()
                txtcoment.Focus().Equals(True)
                Exit Sub
            End If

            cbocodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString()
            cbodesc.Text = grdcaptura.Rows(index).Cells(1).Value.ToString()
            txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString()
            txtcantidad.Text = IIf(grdcaptura.Rows(index).Cells(3).Value.ToString = "", 1, grdcaptura.Rows(index).Cells(3).Value.ToString)
            txtprecio.Text = FormatNumber(grdcaptura.Rows(index).Cells(4).Value.ToString())
            txttotal.Text = FormatNumber(grdcaptura.Rows(index).Cells(5).Value.ToString())
            txtexistencia.Text = grdcaptura.Rows(index).Cells(6).Value.ToString()

            If grdcaptura.Rows.Count = 1 Then
                CODx = grdcaptura.Rows(index).Cells(0).Value.ToString
                CantDX = IIf(grdcaptura.Rows(index).Cells(3).Value.ToString = "", 1, grdcaptura.Rows(index).Cells(3).Value.ToString)
                grdcaptura.Rows.Clear()
            Else
                CODx = grdcaptura.Rows(index).Cells(0).Value.ToString
                CantDX = grdcaptura.Rows(index).Cells(3).Value.ToString

                If grdcaptura.Rows(index).Cells(1).Value.ToString <> "" And grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
                    MyNota = grdcaptura.Rows(index).Cells(1).Value.ToString
                    If grdcaptura.Rows.Count = 1 Then
                        grdcaptura.Rows.Clear()
                    Else
                        grdcaptura.Rows.Remove(grdcaptura.Rows(index))
                    End If
                Else
                    grdcaptura.Rows.Remove(grdcaptura.Rows(index))
                End If
            End If
            My.Application.DoEvents()


            For i As Integer = DataGridView2.Rows.Count - 1 To 0 Step -1
                If DataGridView2.Rows(i).Cells(0).Value.ToString() = CODx Then
                    DataGridView2.Rows.Remove(DataGridView2.Rows(i))
                End If
            Next
        End If

    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        Dim Folio_T As Integer = 0
        If cbo.Text = "" Then MsgBox("Escribe o selecciona una bodega de origen.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo.Focus().Equals(True) : Exit Sub
        If grdcaptura.Rows.Count = 0 Then MsgBox("Carga productos al traspaso para poder guardarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbodesc.Focus().Equals(True) : Exit Sub
        If lblfolio.Text = "" Then Folio()
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus().Equals(True) : Exit Sub
        btnguardar.Enabled = False
        Dim MYFOLIO As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Alias from Usuarios where Clave='" & txtusuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblusuario.Text = rd1("Alias").ToString
                End If
            Else
                MsgBox("Contraseña incorrecta, revisa la información.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close()

            Dim MyTotal As Double = 0

            For IU As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(IU).Cells(0).Value.ToString <> "" Then
                    MyTotal = MyTotal + CDbl(grdcaptura.Rows(IU).Cells(5).Value.ToString())
                End If
            Next

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "insert into Traslados(Nombre,Totales,FVenta,HVenta,Usuario,Concepto,Cargado,FPago,FCancelado,Comisionista) values('" & cbo.Text & "'," & MyTotal & ",'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','SALIDA',0,'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & cbo.Text & "')"
            If cmd1.ExecuteNonQuery Then
            Else
                MsgBox("No se pudo insertar el traslado en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select MAX(Folio) from Traslados where Concepto='SALIDA'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MYFOLIO = rd1(0).ToString
                End If
            End If
            rd1.Close()

            For bombita As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(bombita).Cells(0).Value.ToString() = "" Then
                    GoTo Nota
                End If

                Dim codigo As String = grdcaptura.Rows(bombita).Cells(0).Value.ToString()
                Dim nombre As String = grdcaptura.Rows(bombita).Cells(1).Value.ToString()
                Dim unidad As String = grdcaptura.Rows(bombita).Cells(2).Value.ToString()
                Dim cantidad As Double = grdcaptura.Rows(bombita).Cells(3).Value.ToString()
                Dim precio As Double = grdcaptura.Rows(bombita).Cells(4).Value.ToString()
                Dim total As Double = cantidad * precio
                Dim existe As Double = grdcaptura.Rows(bombita).Cells(6).Value.ToString()
                Dim depto As String = ""
                Dim grupo As String = ""

                Dim existencia As Double = 0
                Dim multiplo As Double = 0
                Dim mcd As Double = 0
                Dim barras As String = ""

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Multiplo, Departamento, Grupo, CodBarra from Productos where Codigo='" & codigo & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        multiplo = rd1(0).ToString
                        depto = rd1(1).ToString
                        grupo = rd1(2).ToString
                        barras = rd1(3).ToString
                    End If
                End If
                rd1.Close()
                Dim voy As Integer = 0
                Dim mycodd As String = codigo
                Dim mycant2 As Double = cantidad
                Dim caduca As String = ""
                Dim lote As String = ""
                Dim mycantfinal As Double = cantidad

                If DataGridView2.Rows.Count > 0 Then
                    For cuca As Integer = 0 To DataGridView2.Rows.Count - 1
                        If codigo = DataGridView2.Rows(cuca).Cells(0).Value.ToString Then
                            lote = DataGridView2.Rows(cuca).Cells(2).Value.ToString
                            caduca = DataGridView2.Rows(cuca).Cells(3).Value.ToString
                            mycant2 = DataGridView2.Rows(cuca).Cells(4).Value.ToString
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                    "insert into TrasladosDet(Folio,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Existe,Fecha,Concepto,Depto,Grupo,CostVR,Lote,FCaduca,Barras) values(" & MYFOLIO & ",'" & codigo & "','" & nombre & "','" & unidad & "'," & mycant2 & "," & precio & "," & total & "," & existe & ",'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','SALIDA','" & depto & "','" & grupo & "','','" & lote & "','" & caduca & "','" & barras & "')"
                            cmd1.ExecuteNonQuery()
                            voy += 1
                        End If

                    Next
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "insert into TrasladosDet(Folio,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Existe,Fecha,Concepto,Depto,Grupo,CostVR,Lote,FCaduca,Barras) values(" & MYFOLIO & ",'" & codigo & "','" & nombre & "','" & unidad & "'," & cantidad & "," & precio & "," & total & "," & existe & ",'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','SALIDA','" & depto & "','" & grupo & "','','','','" & barras & "')"
                    cmd1.ExecuteNonQuery()
                    voy = 1
                End If

                If voy = 0 Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "insert into TrasladosDet(Folio,Codigo,Nombre,Unidad,Cantidad,Precio,Total,Existe,Fecha,Concepto,Depto,Grupo,CostVR,Lote,FCaduca,Barras) values(" & MYFOLIO & ",'" & codigo & "','" & nombre & "','" & unidad & "'," & cantidad & "," & precio & "," & total & "," & existe & ",'" & Format(dtpfecha.Value, "yyyy-MM-dd") & "','SALIDA','" & depto & "','" & grupo & "','','','','" & barras & "')"
                    cmd1.ExecuteNonQuery()
                End If



                Dim MyExiste As Double = 0
                Dim existenc As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Existencia from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyExiste = IIf(rd1("Existencia").ToString = "", 0, rd1("Existencia").ToString)
                    End If
                End If
                rd1.Close()

                Dim mynuevaexis As Double = MyExiste - cantidad * multiplo

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Productos set Cargado=0, CargadoInv=0, Existencia=" & mynuevaexis & " where Codigo='" & Strings.Left(codigo, 6) & "'"
                cmd1.ExecuteNonQuery()

                If DataGridView2.Rows.Count > 0 Then
                    For xd As Integer = 0 To DataGridView2.Rows.Count - 1
                        Dim idLote As Integer = DataGridView2.Rows(xd).Cells(1).Value.ToString
                        lote = DataGridView2.Rows(xd).Cells(2).Value.ToString
                        ' Dim co As String = DataGridView2.Rows(xd).Cells(0).Value.ToString

                        Dim cant_lote As Double = GetCantLote(codigo, lote)
                        cantidad = DataGridView2.Rows(xd).Cells(4).Value.ToString
                        If cant_lote > cantidad Then
                            Dim nueva_cant As Double = cant_lote - cantidad
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                    "update LoteCaducidad set Cantidad=" & nueva_cant & " where Id=" & idLote
                            cmd1.ExecuteNonQuery()
                        Else
                            Dim nueva_cant As Double = cant_lote - cantidad
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                    "update LoteCaducidad set Cantidad=" & nueva_cant & " where Codigo='" & codigo & "' AND Id=" & idLote
                            cmd1.ExecuteNonQuery()

                        End If
                    Next
                End If

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Final,Precio,Fecha,Usuario,Folio,Tipo,Cedula,Receta,Medico,Domicilio) values('" & codigo & "','" & nombre & "','Traspaso de salida'," & MyExiste & "," & mycantfinal & "," & mynuevaexis & "," & precio & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & lblusuario.Text & "','" & lblfolio.Text & "','','','','','')"
                cmd1.ExecuteNonQuery()
                Continue For
Nota:
                Dim comentario As String = grdcaptura.Rows(bombita).Cells(1).Value.ToString()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update TrasladosDet set CostVR='" & comentario & "' where Id=" & MYFOLIO & " and Codigo='" & codigo & "'"
                cmd1.ExecuteNonQuery()
            Next
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            btnguardar.Enabled = True
        End Try

        Dim Imprime As Boolean = False
        Dim TPrint As String = ""
        Dim Imprime_En As String = ""
        Dim Impresora As String = ""
        Dim Tamaño As String = ""
        Dim Pasa_Print As Boolean = False
        Dim Copias As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Formato from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Venta'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    TPrint = rd1(0).ToString()
                End If
            Else
                TPrint = "TICKET"
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
            btnguardar.Enabled = True
        End Try

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NoPrint,Copias from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Imprime = rd1("NoPrint").ToString()
                Copias = rd1("Copias").ToString()
            End If
        End If
        rd1.Close() : cnn1.Close()
        Try



            If (Imprime) Then
                If MsgBox("¿Deseas imprimir recibo del traspaso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Pasa_Print = True
                Else
                    Pasa_Print = False
                End If
            Else
                Pasa_Print = True
            End If

            If (Pasa_Print) Then
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

                If TPrint = "PDF - CARTA" Then

                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Impresora = rd1(0).ToString
                        End If
                    Else
                        cnn1.Close()
                    End If
                    rd1.Close() : cnn1.Close()
                End If

                If TPrint = "TICKET" Then
                    If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : btnnuevo.PerformClick() : Exit Sub
                    If Tamaño = "80" Then
                        For t As Integer = 1 To Copias
                            pSalida80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            pSalida80.Print()
                        Next
                    End If
                    If Tamaño = "58" Then
                        For t As Integer = 1 To Copias
                            pSalida58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                            pSalida58.Print()
                        Next
                    End If
                End If
            End If
            btnnuevo.PerformClick()
            btnguardar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            btnguardar.Enabled = True
        End Try
    End Sub


    Private Function GetCantLote(ByVal cod As String, ByVal lote As String) As Double
        GetCantLote = 0
        If cod = "" Then GetCantLote = 0 : Exit Function
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                      "select Cantidad from LoteCaducidad where Codigo='" & cod & "' and Lote='" & lote & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    GetCantLote = rd5(0).ToString
                End If
            Else
                GetCantLote = 0
            End If
            rd5.Close() : cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
        Return GetCantLote
    End Function
    Private Sub pSalida80_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pSalida80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
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

        On Error GoTo milky

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 130
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Pie2,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos de la venta
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString(" - T R A S P A S O - ", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 14
        e.Graphics.DrawString("S A L I D A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("Folio: " & lblfolio.Text, fuente_fecha, Brushes.Black, 285, Y, sf)
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/yyyy HH:mm:ss"), fuente_fecha, Brushes.Black, 1, Y)
        Y += 17
        e.Graphics.DrawString("Destino: " & cbo.Text, fuente_fecha, Brushes.Black, 1, Y)
        Y += 12

        Y += 4
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 12


        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)

        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim total_prods As Double = 0

        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                Y -= 5
                e.Graphics.DrawString(Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 1, 25), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                If Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 26, 50) <> "" Then
                    Y += 11
                    e.Graphics.DrawString(Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 26, 50), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                End If
                Y += 21
                Continue For
            End If
            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
            Dim existencia As Double = grdcaptura.Rows(miku).Cells(6).Value.ToString()
            Dim barras As String = grdcaptura.Rows(miku).Cells(7).Value.ToString()
            Dim lote As String = ""
            Dim caducidad As Date = Date.Now
            Dim cantidadlote As Double = 0

            e.Graphics.DrawString(barras, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 120, Y)
            Y += 15

            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
            e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)

            Y += 17
            If DataGridView2.Rows.Count > 0 Then
                For asd As Integer = DataGridView2.Rows.Count - 1 To 0 Step -1
                    If codigo = DataGridView2.Rows(asd).Cells(0).Value.ToString Then
                        lote = DataGridView2.Rows(asd).Cells(2).Value.ToString
                        caducidad = DataGridView2.Rows(asd).Cells(3).Value.ToString
                        cantidadlote = DataGridView2.Rows(asd).Cells(4).Value.ToString
                        If lote <> "" Then
                            e.Graphics.DrawString("Lote: " & lote, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
                            e.Graphics.DrawString(Format(caducidad, "MM-yyyy"), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 93, Y)
                            e.Graphics.DrawString("Cant.: " & cantidadlote, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                            Y += 15
                            DataGridView2.Rows.RemoveAt(asd)
                        End If
                    End If
                Next
            End If


            total_prods = total_prods + canti
        Next
        Y -= 1
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Y += 18
        e.Graphics.DrawString("Movimiento realizado por " & lblusuario.Text, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 142.5, Y, sc)

        e.HasMorePages = False
        Exit Sub
milky:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub cbodocumento_DropDown(sender As System.Object, e As System.EventArgs) Handles cbodocumento.DropDown
        cbodocumento.Items.Clear()
        grdcaptura.Rows.Clear()
        DataGridView2.Rows.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Folio from Traslados where Concepto='SALIDA'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbodocumento.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbodocumento_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbodocumento.SelectedValueChanged
        Dim id As Integer = 0
        Dim usu As String = ""
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Folio,Nombre,FVenta,Usuario from Traslados where Folio=" & cbodocumento.Text & " and Concepto='SALIDA'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    id = rd1("Folio").ToString
                    cbo.Text = rd1("Nombre").ToString
                    dtpfecha.Value = rd1("FVenta").ToString
                    usu_copia = rd1("Usuario").ToString
                    btncopia.Enabled = True
                    btnguardar.Enabled = False
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,Nombre,Unidad,Cantidad,Precio,Total,Existe,CostVR from TrasladosDet where Folio=" & id & " and Concepto='SALIDA'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("Unidad").ToString
                    Dim cantid As Double = rd1("Cantidad").ToString
                    Dim precio As Double = rd1("Precio").ToString
                    Dim total As Double = rd1("Total").ToString
                    Dim existe As Double = rd1("Existe").ToString
                    Dim comenta As String = rd1("CostVR").ToString

                    grdcaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), FormatNumber(total, 2), existe)
                    If comenta <> "" Then
                        grdcaptura.Rows.Add("", comenta, "", "", "", "", "")
                    End If
                End If
            Loop
            rd1.Close() : cnn1.Close()

            For t As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(t).Cells(0).Value.ToString) = "" Then
                    grdcaptura.Rows(t).DefaultCellStyle.ForeColor = Color.DarkOrange
                    grdcaptura.Rows(t).DefaultCellStyle.SelectionBackColor = Color.Pink
                    grdcaptura.Rows(t).DefaultCellStyle.SelectionForeColor = Color.Black
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btncopia_Click(sender As Object, e As EventArgs) Handles btncopia.Click

    End Sub

    Private Sub pSalida58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pSalida58.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
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

        On Error GoTo milky

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                Y += 130
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Pie2,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 10
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 10
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                    Y += 10
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                    Y += 10
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                    Y += 10
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                    Y += 10
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                    Y += 10
                End If
                Y += 8
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos de la venta
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 12
        e.Graphics.DrawString(" - T R A S P A S O - ", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
        Y += 12
        e.Graphics.DrawString("S A L I D A", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("Folio: " & lblfolio.Text, fuente_datos, Brushes.Black, 180, Y, sf)
        e.Graphics.DrawString("Fecha: " & FormatDateTime(dtpfecha.Value, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("Destino: " & cbo.Text, fuente_datos, Brushes.Black, 1, Y)
        Y += 8

        Y += 4
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 14


        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 100, Y, sc)
        Y += 11
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sf)
        e.Graphics.DrawString("EXIST.", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 150, Y)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 13

        Dim total_prods As Double = 0

        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                Y -= 5
                e.Graphics.DrawString(Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 1, 20), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                If Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 20, 40) <> "" Then
                    Y += 11
                    e.Graphics.DrawString(Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 21, 40), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                End If
                Y += 11
                Continue For
            End If
            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
            Dim existencia As Double = grdcaptura.Rows(miku).Cells(6).Value.ToString()
            Dim lote As String = ""
            Dim caducidad As Date = Date.Now
            Dim cantidadlote As Double = 0

            e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 36, Y)
            Y += 15
            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 30, Y, sf)
            e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 35, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 100, Y, sf)
            e.Graphics.DrawString(existencia, fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 17

            If DataGridView2.Rows.Count > 0 Then
                For asd As Integer = 0 To DataGridView2.Rows.Count - 1
                    If codigo = DataGridView2.Rows(asd).Cells(0).Value.ToString Then
                        lote = DataGridView2.Rows(asd).Cells(2).Value.ToString
                        caducidad = DataGridView2.Rows(asd).Cells(3).Value.ToString
                        cantidadlote = DataGridView2.Rows(asd).Cells(4).Value.ToString
                        If lote <> "" Then
                            e.Graphics.DrawString("Lote: " & lote, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
                            e.Graphics.DrawString("Caducidad: " & Format(caducidad, "MM-yyyy"), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 85, Y)
                            e.Graphics.DrawString("Cant.: " & cantidadlote, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 180, Y, sf)
                            Y += 15
                        End If
                    End If
                Next
            End If
            Y += 10

            total_prods = total_prods + canti
        Next
        Y -= 1
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 13
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 100, Y, sc)
        Y += 10
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 10

        Y += 10
        e.Graphics.DrawString("Movimiento realizado por " & lblusuario.Text, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 90, Y, sc)

        e.HasMorePages = False
        Exit Sub
milky:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub frmTraspSalida_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        cbodesc.Focus.Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnGuardarLote_Click(sender As Object, e As EventArgs) Handles btnGuardarLote.Click
        If TextBox1.Text = "" Then
            Exit Sub
        End If
        Dim ventatotal As Double = 0
        Dim voy As Integer = 0
        Dim voyconteo As Double = 0
        Dim senecesita As Double = 0
        Dim tengo As Double = 0
        ventatotal = TextBox1.Text


        For lucas As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(lucas).Cells(4).Value Is Nothing OrElse IsDBNull(DataGridView1.Rows(lucas).Cells(4).Value) Then
                MsgBox("La cantidad no puede ir vacia, Ingresa una cantidad valida", vbCritical + vbOKOnly, "Delsscom Farmacias")
                Exit Sub
            End If

            senecesita = DataGridView1.Rows(lucas).Cells(4).Value.ToString
            tengo = DataGridView1.Rows(lucas).Cells(5).Value
            If DataGridView1.Rows(lucas).Cells(0).Value Then
                If senecesita > tengo Then
                    MsgBox("La Cantidad es mayor a la existencia del lote, revisa la informacion", vbCritical + vbOKOnly, "Delsscom Farmacias")
                    Exit Sub
                End If
            End If
        Next

        For yuta As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(yuta).Cells(0).Value Then
                voyconteo = voyconteo + CDec(DataGridView1.Rows(yuta).Cells(4).Value)
                voy += 1
            End If
        Next

        If CDec(txtcantidad.Text) > CDec(txtexistencia.Text) Then
            MsgBox("La cantidad es mayor a la existencia, Modifique el dato", vbInformation + vbOKOnly, "Delsscom Farmacias")
            Exit Sub
        End If

        If voy = 0 Then
            MsgBox("Selecciona un lote, y agrega una cantidad valida para continuar", vbInformation + vbOKOnly, "Delsscom Farmacias")
            Exit Sub
        End If

        If voyconteo > ventatotal Then
            MsgBox("La suma de las cantidades es mayor a la de la venta, revisa la informacion", vbCritical + vbOKOnly, "Delsscom Farmacias")
            Exit Sub
        End If

        If voyconteo < ventatotal Then
            MsgBox("La suma de las cantidades es menor a la de la venta, revisa la informacion", vbCritical + vbOKOnly, "Delsscom Farmacias")
            Exit Sub
        End If

        For xxx As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(xxx).Cells(0).Value Then
                If DataGridView1.Rows(xxx).Cells(4).Value.ToString = "0" Or DataGridView1.Rows(xxx).Cells(4).Value.ToString = "" Then
                    MsgBox("La cantidad del lote no es valida, revisa la informacion", vbCritical + vbOKOnly, "Delsscom Farmacias")
                Else
                    DataGridView2.Rows.Add(txtcodlote.Text, DataGridView1.Rows(xxx).Cells(1).Value.ToString, DataGridView1.Rows(xxx).Cells(2).Value.ToString, DataGridView1.Rows(xxx).Cells(3).Value.ToString, DataGridView1.Rows(xxx).Cells(4).Value.ToString)
                End If
            End If
        Next
        If DataGridView2.Rows.Count <> 0 Then


            For xsd As Integer = 0 To grdcaptura.Rows.Count - 1
                If cbocodigo.Text = grdcaptura.Rows(xsd).Cells(0).Value.ToString Then
                    grdcaptura.Rows(xsd).Cells(3).Value = grdcaptura.Rows(xsd).Cells(3).Value + CDec(txtcantidad.Text)
                    grdcaptura.Rows(xsd).Cells(5).Value = grdcaptura.Rows(xsd).Cells(5).Value + CDec(txttotal.Text)
                    GoTo kaka
                End If
            Next
            grdcaptura.Rows.Add(cbocodigo.Text, cbodesc.Text, txtunidad.Text, txtcantidad.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(txttotal.Text, 2), txtexistencia.Text, barras)

kaka:
            ' 
            ' cboLote_KeyPress(cboLote, New KeyPressEventArgs(ChrW(Keys.Enter)))
            cbocodigo.Text = ""
            cbodesc.Text = ""
            txtunidad.Text = ""
            txtcantidad.Text = "1"
            txtprecio.Text = ""
            txttotal.Text = ""
            txtexistencia.Text = ""
            cbodesc.Focus().Equals(True)

            gbLotes.Visible = False



        End If

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        'DataGridView2.Rows.Clear()
        'DataGridView1.Rows.Clear()
        'txtcodlote.Text = ""
        'txtnombrelote.Text = ""
        'TextBox1.Text = ""
        gbLotes.Visible = False
    End Sub

    Private Sub chkBuscaProd_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscaProd.CheckedChanged
        If (chkBuscaProd.Checked) Then
            txtProdClave.Text = ""
            Serchixd = False
            Panel5.Visible = True
            txtProdClave.Focus().Equals(True)
            Panel5.BringToFront()
            My.Application.DoEvents()
        End If
    End Sub

    Private Sub txtProdClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProdClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodesc.Items.Clear()

            Try
                cnn3.Close() : cnn3.Open()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select distinct Nombre from Productos where Nombre like '%" & txtProdClave.Text & "%' order by Nombre"
                rd3 = cmd3.ExecuteReader
                Do While rd3.Read
                    If rd3.HasRows Then cbodesc.Items.Add(rd3(0).ToString())
                Loop
                rd3.Close() : cnn3.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try
            Serchixd = True
            Panel5.Visible = False
            My.Application.DoEvents()
            chkBuscaProd.Checked = False
            cbodesc.Focus().Equals(True)
            cbodesc.DroppedDown = True
        End If
    End Sub
End Class