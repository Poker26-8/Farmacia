Imports System.IO
Public Class frmEliminarAbono

    Dim ideliminar As Double = 0
    Dim montoeliminar As Double = 0
    Dim formaeliminar As String = ""
    Dim bancoeliminar As String = ""
    Dim referenciaeliminar As String = ""
    Dim cuentaeliminar As String = ""

    Dim idemp As Integer = 0
    Dim idcliente As Integer = 0

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Cliente FROM abonoi WHERE Cliente<>'' ORDER BY Cliente"
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

    Private Sub cboFolio_DropDown(sender As Object, e As EventArgs) Handles cboFolio.DropDown
        Try
            cboFolio.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If cboCliente.Text = "" Then
                cmd5.CommandText = "SELECT DISTINCT NumFolio FROM abonoi WHERE NumFolio<>'' ORDER BY NumFolio"
            Else
                cmd5.CommandText = "SELECT DISTINCT NumFolio FROM abonoi WHERE NumFolio<>'' AND Cliente='" & cboCliente.Text & "' ORDER BY NumFolio"
            End If


            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboFolio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFolio.SelectedValueChanged
        Try
            grdAbonos.Rows.Clear()
            Dim fecha As Date = Nothing
            Dim fechan As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If cboCliente.Text = "" Then
                cmd1.CommandText = "SELECT * FROM abonoi WHERE NumFolio=" & cboFolio.Text & " AND Concepto='ABONO' AND Status=0"
            Else
                cmd1.CommandText = "SELECT * FROM abonoi WHERE NumFolio=" & cboFolio.Text & " AND Concepto='ABONO' AND Cliente='" & cboCliente.Text & "' AND Status=0"
            End If

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboCliente.Text = rd1("Cliente").ToString
                    idcliente = rd1("IdCliente").ToString

                    fecha = rd1("Fecha").ToString
                    fechan = Format(fecha, "yyyy-MM-dd")

                    grdAbonos.Rows.Add(rd1("Id").ToString,
                                       fechan,
                                       rd1("FormaPago").ToString,
                                       rd1("Banco").ToString,
                                       rd1("Referencia").ToString,
                                       rd1("CuentaC").ToString,
                                       FormatNumber(rd1("Monto").ToString, 2),
                                       rd1("Usuario").ToString
)

                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        cboCliente.Text = ""
        cboFolio.Text = ""
        grdAbonos.Rows.Clear()
        cboFolio.Focus.Equals(True)
        txtMonto.Text = "0.00"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub grdAbonos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdAbonos.CellClick
        Dim celda As DataGridViewCellEventArgs = e

        If celda.ColumnIndex = 0 Then
            ideliminar = grdAbonos.CurrentRow.Cells(0).Value.ToString
            formaeliminar = grdAbonos.CurrentRow.Cells(2).Value.ToString
            bancoeliminar = grdAbonos.CurrentRow.Cells(3).Value.ToString
            referenciaeliminar = grdAbonos.CurrentRow.Cells(4).Value.ToString
            cuentaeliminar = grdAbonos.CurrentRow.Cells(5).Value.ToString
            montoeliminar = grdAbonos.CurrentRow.Cells(6).Value.ToString

            txtMonto.Text = FormatNumber(montoeliminar, 2)
        End If

        If celda.ColumnIndex = 1 Then
            ideliminar = grdAbonos.CurrentRow.Cells(0).Value.ToString
            formaeliminar = grdAbonos.CurrentRow.Cells(2).Value.ToString
            bancoeliminar = grdAbonos.CurrentRow.Cells(3).Value.ToString
            referenciaeliminar = grdAbonos.CurrentRow.Cells(4).Value.ToString
            cuentaeliminar = grdAbonos.CurrentRow.Cells(5).Value.ToString
            montoeliminar = grdAbonos.CurrentRow.Cells(6).Value.ToString

            txtMonto.Text = FormatNumber(montoeliminar, 2)
        End If

        If celda.ColumnIndex = 2 Then
            ideliminar = grdAbonos.CurrentRow.Cells(0).Value.ToString
            formaeliminar = grdAbonos.CurrentRow.Cells(2).Value.ToString
            bancoeliminar = grdAbonos.CurrentRow.Cells(3).Value.ToString
            referenciaeliminar = grdAbonos.CurrentRow.Cells(4).Value.ToString
            cuentaeliminar = grdAbonos.CurrentRow.Cells(5).Value.ToString
            montoeliminar = grdAbonos.CurrentRow.Cells(6).Value.ToString
            txtMonto.Text = FormatNumber(montoeliminar, 2)
        End If

        If celda.ColumnIndex = 3 Then
            ideliminar = grdAbonos.CurrentRow.Cells(0).Value.ToString
            formaeliminar = grdAbonos.CurrentRow.Cells(2).Value.ToString
            bancoeliminar = grdAbonos.CurrentRow.Cells(3).Value.ToString
            referenciaeliminar = grdAbonos.CurrentRow.Cells(4).Value.ToString
            cuentaeliminar = grdAbonos.CurrentRow.Cells(5).Value.ToString
            montoeliminar = grdAbonos.CurrentRow.Cells(6).Value.ToString
            txtMonto.Text = FormatNumber(montoeliminar, 2)
        End If

        If celda.ColumnIndex = 4 Then
            ideliminar = grdAbonos.CurrentRow.Cells(0).Value.ToString
            formaeliminar = grdAbonos.CurrentRow.Cells(2).Value.ToString
            bancoeliminar = grdAbonos.CurrentRow.Cells(3).Value.ToString
            referenciaeliminar = grdAbonos.CurrentRow.Cells(4).Value.ToString
            cuentaeliminar = grdAbonos.CurrentRow.Cells(5).Value.ToString
            montoeliminar = grdAbonos.CurrentRow.Cells(6).Value.ToString
            txtMonto.Text = FormatNumber(montoeliminar, 2)
        End If

        If celda.ColumnIndex = 5 Then
            ideliminar = grdAbonos.CurrentRow.Cells(0).Value.ToString
            formaeliminar = grdAbonos.CurrentRow.Cells(2).Value.ToString
            bancoeliminar = grdAbonos.CurrentRow.Cells(3).Value.ToString
            referenciaeliminar = grdAbonos.CurrentRow.Cells(4).Value.ToString
            cuentaeliminar = grdAbonos.CurrentRow.Cells(5).Value.ToString
            montoeliminar = grdAbonos.CurrentRow.Cells(6).Value.ToString
            txtMonto.Text = FormatNumber(montoeliminar, 2)
        End If

        If celda.ColumnIndex = 6 Then
            ideliminar = grdAbonos.CurrentRow.Cells(0).Value.ToString
            formaeliminar = grdAbonos.CurrentRow.Cells(2).Value.ToString
            bancoeliminar = grdAbonos.CurrentRow.Cells(3).Value.ToString
            referenciaeliminar = grdAbonos.CurrentRow.Cells(4).Value.ToString
            cuentaeliminar = grdAbonos.CurrentRow.Cells(5).Value.ToString
            montoeliminar = grdAbonos.CurrentRow.Cells(6).Value.ToString
            txtMonto.Text = FormatNumber(montoeliminar, 2)
        End If
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click

        Try
            Dim mysaldo As Double = 0
            Dim monto As Double = 0
            Dim acuentaventa As Double = 0
            Dim restaventa As Double = 0
            Dim nuevoacuenta As Double = 0
            Dim nuevoresta As Double = 0
            Dim IDMAX As Integer = 0

            monto = txtMonto.Text

            If MsgBox("Desea eliminar el abono de " & montoeliminar & " con el folio de venta " & cboFolio.Text, vbInformation + vbYesNo, titulocentral) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT EliAbono FROM permisos WHERE IdEmpleado=" & idemp
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(0).ToString = 1 Then
                        Else
                            MsgBox("El usuario no tiene permisos para realizar esta operación", vbInformation + vbOKOnly, titulocentral)
                            txtContraseña.Text = ""
                            lblUsuario.Text = ""
                            txtContraseña.Focus.Equals(True)
                            Exit Sub
                        End If
                    End If
                Else
                    Exit Sub
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select Saldo,Id from AbonoI where Id=(select MAX(Id) from AbonoI where Cliente='" & cboCliente.Text & "' AND Status=0)"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        mysaldo = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + monto, 2)
                        IDMAX = rd1(1).ToString
                    End If
                Else
                    mysaldo = FormatNumber(txtMonto.Text)
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Acuenta,Resta FROM ventas WHERE FOlio='" & cboFolio.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        acuentaventa = rd1(0).ToString
                        restaventa = rd1(1).ToString

                        nuevoacuenta = CDbl(acuentaventa) - CDbl(monto)
                        nuevoresta = CDbl(restaventa) + CDbl(monto)


                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE ventas SET Acuenta=" & nuevoacuenta & ",Resta='" & nuevoresta & "',Status='RESTA' WHERE Folio='" & cboFolio.Text & "'"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "Update abonoi SET Status=1 WHERE NumFolio=" & cboFolio.Text & " AND Cliente='" & cboCliente.Text & "' AND Id=" & ideliminar & ""
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Monto,Banco,Referencia,Usuario,Corte,CorteU,Cargado,MontoSF,CargadoAndroid,CuentaC) VALUES(" & cboFolio.Text & "," & idcliente & ",'" & cboCliente.Text & "','CANCELACION ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & monto & ",0," & mysaldo & ",'" & formaeliminar & "'," & monto & ",'" & bancoeliminar & "','" & referenciaeliminar & "','" & lblUsuario.Text & "',0,0,0,0,0,'" & cuentaeliminar & "')"
                        cmd2.ExecuteNonQuery()

                        If formaeliminar = "EFECTIVO" Then
                        Else
                            Dim saldocuenta As Double = 0
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cuentaeliminar & "')"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    saldocuenta = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) - monto

                                    cnn3.Close() : cnn3.Open()
                                    cmd3 = cnn3.CreateCommand
                                    cmd3.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & formaeliminar & "','" & bancoeliminar & "','" & referenciaeliminar & "','ABONO CANCELADO'," & monto & "," & monto & ",0," & saldocuenta & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & cboFolio.Text & "','" & cboCliente.Text & "','','" & cuentaeliminar & "','')"
                                    cmd3.ExecuteNonQuery()
                                    cnn3.Close()
                                End If
                            Else

                            End If
                            rd2.Close()
                            cnn2.Close()
                        End If

                    End If
                End If
                rd1.Close()
                cnn1.Close()

                MsgBox("Abono eliminado correctamente", vbInformation + vbOKOnly, titulocentral)

                Dim impresorati As String = ""
                Dim tamticket As Integer = 0

                impresorati = ImpresoraImprimir()
                tamticket = TamImpre()

                If tamticket = "80" Then
                    pEliminar80.DefaultPageSettings.PrinterSettings.PrinterName = impresorati
                    pEliminar80.Print()
                End If

                If tamticket = "58" Then

                End If
                btnnuevo.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            idemp = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Alias,Status,IdEmpleado FROM usuarios WHERE Clave='" & txtContraseña.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(1).ToString = 1 Then

                        lblUsuario.Text = rd1(0).ToString
                        idemp = rd1(2).ToString
                    Else
                        MsgBox("El usuario esta inactivo", vbInformation + vbOKOnly, titulocentral)
                        txtContraseña.Text = ""
                        lblUsuario.Text = ""
                        txtContraseña.Focus.Equals(True)
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulocentral)
                txtContraseña.Text = ""
                lblUsuario.Text = ""
                txtContraseña.Focus.Equals(True)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub

    Private Sub cboCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedValueChanged
        Try
            idcliente = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM clientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    idcliente = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmEliminarAbono_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pEliminar80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pEliminar80.PrintPage
        Try

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

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 153
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 250, 150)
                        Y += 153
                    End If
                End If
            Else
                Y = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString

                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()


            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("A B O N O   C A N C E L A D O", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cboFolio.Text, fuente_datos, Brushes.Black, 280, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 280, Y, sf)
            Y += 15

            If cboCliente.Text <> "" Then

                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboCliente.Text, 1, 48), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
            End If


            e.Graphics.DrawString("Forma Pago:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(formaeliminar, fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 18

            If bancoeliminar <> "" Then
                e.Graphics.DrawString("Banco:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(bancoeliminar, fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 18

                e.Graphics.DrawString("Referecnia:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(referenciaeliminar, fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 18

                e.Graphics.DrawString("Cuenta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(cuentaeliminar, fuente_prods, Brushes.Black, 270, Y, sf)
                Y += 18
            End If

            e.Graphics.DrawString("Monto:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(montoeliminar, fuente_prods, Brushes.Black, 270, Y, sf)
            Y += 18

            e.Graphics.DrawString("Realizo: " & lblUsuario.Text, fuente_prods, Brushes.Black, 137, Y, sc)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub pEliminar58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pEliminar58.PrintPage
        Try
            'Fuentes prederminadas
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_datos As New Drawing.Font(tipografia, 9, FontStyle.Regular)
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

            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                    If tLogo = "CUAD" Then
                        e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                        Y += 153
                    End If
                    If tLogo = "RECT" Then
                        e.Graphics.DrawImage(Logotipo, 30, 0, 110, 110)
                        Y += 153
                    End If
                End If
            Else
                Y = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie1").ToString

                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd1.Close()


            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("A B O N O   C A N C E L A D O", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 17
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Folio: " & cboFolio.Text, fuente_datos, Brushes.Black, 280, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_fecha, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_fecha, Brushes.Black, 180, Y, sf)
            Y += 15

            If cboCliente.Text <> "" Then

                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 12
                e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                Y += 7.5
                e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15

                e.Graphics.DrawString("Nombre: " & Mid(cboCliente.Text, 1, 37), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
            End If


            e.Graphics.DrawString("Forma Pago:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(formaeliminar, fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            If bancoeliminar <> "" Then
                e.Graphics.DrawString("Banco:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(bancoeliminar, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 18

                e.Graphics.DrawString("Referecnia:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(referenciaeliminar, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 18

                e.Graphics.DrawString("Cuenta:", fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(cuentaeliminar, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 18
            End If

            e.Graphics.DrawString("Monto:", fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(montoeliminar, fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 18

            e.Graphics.DrawString("Realizo: " & lblUsuario.Text, fuente_prods, Brushes.Black, 90, Y, sc)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        cnn1.Close()
        End Try
    End Sub
End Class