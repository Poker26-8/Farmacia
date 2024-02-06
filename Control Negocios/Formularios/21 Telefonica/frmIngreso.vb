
Imports System.IO
Public Class frmIngreso

    Dim ordenfolio As Integer = 0
    Private Sub frmIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim idtelefono As Integer = 0
        Try

            If lblusuario.Text = "" Then MsgBox("ingrese la contraseña para realizar esta operación", vbInformation + vbOKOnly, titulotaller) : txtcontra.Focus.Equals(True) : Exit Sub

            If cboCliente.Text <> "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Nombre FROM Clientes WHERE Nombre='" & cboCliente.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO clientes(Nombre,RazonSocial) VALUES('" & cboCliente.Text & "','" & cboCliente.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM dispositivos WHERE Serie='" & cboSerie.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    idtelefono = rd1("Id").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Productos SET Serie='" & cboSerie.Text & "',Tipo='" & cboTipo.Text & "',Marca='" & txtmarca.Text & "',Modelo='" & txtmodelo.Text & "',Comentario='" & rtbComentario.Text & "',Color='" & txtcolor.Text & "' WHERE Id=" & idtelefono & ""
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Dispositivo actualizado correctamente", vbInformation + vbOKOnly, titulomensajes)
                    End If
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Dispositivos(Serie,Tipo,Marca,Modelo,Comentario,Color)VALUES('" & cboSerie.Text & "','" & cboTipo.Text & "','" & txtmarca.Text & "','" & txtmodelo.Text & "','" & rtbComentario.Text & "','" & txtcolor.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Dispositivo agregado correctamente", vbInformation + vbOKOnly, titulomensajes)
                End If
                cnn2.Close()
            End If
            rd1.Close()


            If grdaccesorio.Rows.Count > 0 Then

                For luffy As Integer = 0 To grdaccesorio.Rows.Count - 1

                    Dim accesorio As String = grdaccesorio.Rows(luffy).Cells(0).Value.ToString
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM accesorios WHERE Serie='" & cboSerie.Text & "' AND Descripcion='" & accesorio & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO accesorios(Serie,Descripcion) VALUES('" & cboSerie.Text & "','" & accesorio & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()

                Next
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM dispositivos WHERE Serie='" & cboSerie.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idtelefono = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM tallerd WHERE SerieD='" & cboSerie.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO tallerd(IdDispositivo,SerieD,Cliente,Tecnico,Operacion,Status,FechaEntrada,FechaEstimada,Fallas) values(" & idtelefono & ",'" & cboSerie.Text & "','" & cboCliente.Text & "','" & cboTecnico.Text & "','" & cboOperacion.Text & "','" & cboStatus.Text & "','" & Format(dtpIngreso.Value, "yyyy-MM-dd HH:mm:ss") & "','" & Format(dtpEntrega.Value, "yyyy-MM-dd HH:mm:ss") & "','" & rtbfallas.Text & "')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT MAX(Id) FROM tallerd"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    ordenfolio = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                End If
            Else
                ordenfolio = 1
            End If
            rd1.Close()


            '-------------------------------------------imprimir ticket----------------------------------------------
            Dim tamimpre As Integer = 0
            Dim impresora As String = ""
            Dim copias As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tamimpre = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impresora = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select Copias from ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    copias = rd1(0).ToString
                End If
            End If
            rd1.Close()


            If impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, titulotaller) : Exit Sub



            If tamimpre = "80" Then

                For SASUKE As Integer = 1 To copias
                    PEntrada80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PEntrada80.Print()
                Next

            End If

            If tamimpre = "58" Then
                For SASUKE As Integer = 1 To copias
                    PEntrada58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PEntrada58.Print()
                Next
            End If
            cnn1.Close()

            btnNuevo.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtaccesorios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtaccesorios.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If txtaccesorios.Text = "" Then
                btnGuardar.Focus.Equals(True)
            Else
                grdaccesorio.Rows.Add(txtaccesorios.Text)
                txtaccesorios.Text = ""
                txtaccesorios.Focus.Equals(True)
            End If


        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmTallerT.Show()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboCliente.Text = ""
        cboTecnico.Text = ""
        cboOperacion.Text = ""
        cboStatus.Text = ""
        dtpIngreso.Value = Date.Now
        dtpEntrega.Value = Date.Now

        cboSerie.Text = ""
        cboTipo.Text = ""
        txtmarca.Text = ""
        txtmodelo.Text = ""
        rtbComentario.Text = ""
        txtcolor.Text = ""
        grdaccesorio.Rows.Clear()
        txtaccesorios.Text = ""
        rtbfallas.Text = ""
    End Sub

    Private Sub grdaccesorio_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdaccesorio.CellDoubleClick
        Dim index As String = grdaccesorio.CurrentRow.Index
        Dim accesorio As String = grdaccesorio.Rows(index).Cells(0).Value.ToString

        cnn1.Close()

        grdaccesorio.Rows.Remove(grdaccesorio.CurrentRow)
    End Sub

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboTecnico_DropDown(sender As Object, e As EventArgs) Handles cboTecnico.DropDown
        Try
            cboTecnico.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' ORDER BY nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboTecnico.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTecnico.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTecnico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTecnico.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboOperacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboOperacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboOperacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboStatus.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboStatus.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpIngreso.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpEntrega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpEntrega.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboSerie.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcolor.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtmarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmodelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtmodelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmodelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            rtbComentario.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcolor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcolor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboSerie_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSerie.SelectedValueChanged
        grdaccesorio.Rows.Clear()

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT * FROM dispositivos WHERE Serie='" & cboSerie.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then

                cboTipo.Text = rd1("Tipo").ToString
                txtmarca.Text = rd1("Marca").ToString
                txtmodelo.Text = rd1("Modelo").ToString
                rtbComentario.Text = rd1("Comentario").ToString
                txtcolor.Text = rd1("Color").ToString

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Descripcion FROM accesorios WHERE Serie='" & cboSerie.Text & "'"
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    If rd2.HasRows Then

                        grdaccesorio.Rows.Add(rd2(0).ToString)

                    End If
                Loop
                rd2.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM tallerd WHERE SerieD='" & cboSerie.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        cboTecnico.Text = rd2("Tecnico").ToString
                        cboStatus.Text = rd2("Status").ToString
                        cboOperacion.Text = rd2("Operacion").ToString
                        dtpEntrega.Value = rd2("FechaEstimada").ToString
                        rtbfallas.Text = rd2("Fallas").ToString
                    End If
                End If
                rd2.Close()
                cnn2.Close()

            End If
        End If
        rd1.Close()
        cnn1.Close()

        cboTipo.Focus.Equals(True)
    End Sub

    Private Sub cboSerie_DropDown(sender As Object, e As EventArgs) Handles cboSerie.DropDown
        Try
            cboSerie.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT SerieD FROM tallerd WHERE Cliente='" & cboCliente.Text & "' AND Status<>'Equipo reparado'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboSerie.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub rtbComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtbComentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtaccesorios.Focus.Equals(True)
        End If
    End Sub

    Private Sub PEntrada80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PEntrada80.PrintPage

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
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try


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
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie = rd2("Pie3").ToString
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd2.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("O R D E N  D E  S E R V I C I O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 16

            e.Graphics.DrawString("Folio: " & ordenfolio, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 285, Y, sf)
            Y += 15

            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("D A T O S  D E L  E Q U I P O", New Drawing.Font(tipografia, 11, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 16

            e.Graphics.DrawString("Cliente: " & Mid(cboCliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            Y += 13.5
            If Mid(cboCliente.Text, 29, 100) <> "" Then
                e.Graphics.DrawString(Mid(cboCliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
            End If
            Y += 5

            e.Graphics.DrawString("Técnico: " & Mid(cboTecnico.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            Y += 13.5
            If Mid(cboTecnico.Text, 29, 100) <> "" Then
                e.Graphics.DrawString(Mid(cboTecnico.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
            End If
            Y += 5

            e.Graphics.DrawString("N° Serie: " & cboSerie.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Tipo: " & cboTipo.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 13
            e.Graphics.DrawString("Marca: " & txtmarca.Text, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Modelo: " & txtmodelo.Text, fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 17

            e.Graphics.DrawString("Accesorios:", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
            Y += 17
            For naruto As Integer = 0 To grdaccesorio.Rows.Count - 1

                Dim accesorio As String = grdaccesorio.Rows(naruto).Cells(0).Value.ToString

                e.Graphics.DrawString(accesorio, fuente_prods, Brushes.Black, 1, Y)
                Y += 20
            Next

            e.Graphics.DrawString("Tarea: " & cboOperacion.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Estatus: " & cboStatus.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            If rtbfallas.Text <> "" Then

                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 16
                e.Graphics.DrawString("F A L L A S", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 12
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 16

                e.Graphics.DrawString(Mid(rtbfallas.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
                If Mid(rtbfallas.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(rtbfallas.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13.5
                End If
                Y += 5

            End If
            Y += 10

            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 142.5, Y, sc)

            cnn2.Close()
            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try

    End Sub

    Private Sub txtcontra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontra.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Alias FROM Usuarios WHERE Clave='" & txtcontra.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    lblusuario.Text = rd1(1).ToString

                    btnGuardar.Focus.Equals(True)
                End If
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub

    Private Sub cboSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSerie.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTipo.Focus.Equals(True)
        End If
    End Sub

    Private Sub rtbfallas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtbfallas.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub PEntrada58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PEntrada58.PrintPage
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
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try


            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 120)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie = rd2("Pie3").ToString
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd2.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("O R D E N  D E  S E R V I C I O", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 10
            e.Graphics.DrawString("-------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 16

            e.Graphics.DrawString("Folio: " & ordenfolio, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString("-----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("D A T O S  D E L  E Q U I P O", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 10
            e.Graphics.DrawString("-----------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Cliente: " & Mid(cboCliente.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            Y += 13.5
            If Mid(cboCliente.Text, 29, 100) <> "" Then
                e.Graphics.DrawString(Mid(cboCliente.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
            End If
            Y += 5

            e.Graphics.DrawString("Técnico: " & Mid(cboTecnico.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            Y += 13.5
            If Mid(cboTecnico.Text, 29, 100) <> "" Then
                e.Graphics.DrawString(Mid(cboTecnico.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
            End If
            Y += 5

            e.Graphics.DrawString("N° Serie: " & cboSerie.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Tipo: " & cboTipo.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Marca: " & txtmarca.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Modelo: " & txtmodelo.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Accesorios:", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 1, Y)
            Y += 15
            For naruto As Integer = 0 To grdaccesorio.Rows.Count - 1

                Dim accesorio As String = grdaccesorio.Rows(naruto).Cells(0).Value.ToString

                e.Graphics.DrawString(accesorio, fuente_prods, Brushes.Black, 1, Y)
                Y += 20
            Next

            e.Graphics.DrawString("Tarea: " & cboOperacion.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("Estatus: " & cboStatus.Text, fuente_prods, Brushes.Black, 1, Y)
            Y += 14

            If rtbfallas.Text <> "" Then

                e.Graphics.DrawString("--------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                e.Graphics.DrawString("F A L L A S", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 10
                e.Graphics.DrawString("--------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString(Mid(rtbfallas.Text, 1, 28), fuente_prods, Brushes.Black, 1, Y)
                Y += 1
                If Mid(rtbfallas.Text, 29, 100) <> "" Then
                    e.Graphics.DrawString(Mid(rtbfallas.Text, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                    Y += 13
                End If
                Y += 5

            End If
            Y += 8

            e.Graphics.DrawString("Lo atiende " & lblusuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

            cnn2.Close()
            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("No se pudo generar el docuemnto, a continuación se muestra la descripción del error." & vbNewLine & ex.ToString())
            cnn1.Close()
        End Try
    End Sub
End Class