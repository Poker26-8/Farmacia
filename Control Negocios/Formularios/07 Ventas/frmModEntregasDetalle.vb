Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data

Public Class frmModEntregasDetalle

    Private Sub Insert_Entregas()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim my_folio As Integer = 0
        Dim MyStatus As String = ""
        Dim ACuenta As Double = 0
        Dim Resta As Double = 0
        Dim tel_cliente As String = ""

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
                .runSp(a_cnn, "delete from EntregasDetalle", sinfo)
                .runSp(a_cnn, "delete from Entregas", sinfo)
                sinfo = ""

                If lblcliente.Text <> "" Then
                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select * from Clientes where Nombre='" & lblcliente.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            tel_cliente = rd3("Telefono").ToString()
                        End If
                    End If
                    rd3.Close() : cnn3.Close()
                End If

                'Inserta en la tabla de Ventas
                If .runSp(a_cnn, "insert into Entregas(Nombre,Direccion,Telefono,Usuario,Fecha) values('" & lblcliente.Text & "','" & EliminarSaltosLinea(txtdireccion.Text, " ") & "','" & tel_cliente & "','MOSTRADOR',#" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "#)", sinfo) Then
                    sinfo = ""
                Else
                    MsgBox(sinfo)
                End If

                If .getDr(a_cnn, dr, "select MAX(Folio) from Entregas", sinfo) Then
                    my_folio = dr(0).ToString()
                End If

                Dim cod_temp As String = ""

                cnn1.Close() : cnn1.Open()

                For pipo As Integer = 0 To grdentregados.Rows.Count - 1
                    Dim codigo As String = grdentregados.Rows(pipo).Cells(1).Value.ToString()
                    Dim nombre As String = grdentregados.Rows(pipo).Cells(2).Value.ToString()
                    Dim cantidad As Double = grdentregados.Rows(pipo).Cells(3).Value.ToString()
                    Dim unidad As String = ""

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select UVenta from Productos where Codigo='" & codigo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            unidad = rd1(0).ToString()
                        End If
                    End If
                    rd1.Close()

                    If codigo <> "" Then
                        cod_temp = codigo
                        If .runSp(a_cnn, "insert into EntregasDetalle(Folio,Codigo,Nombre,Cantidad,UVenta) values(" & my_folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "')", sinfo) Then
                            sinfo = ""
                        Else
                            MsgBox(sinfo)
                        End If
                    End If
                Next
                a_cnn.Close()
            End If
        End With
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Dim valiente As Integer = 0
        Dim folio As Integer = Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        Dim folioentrega As Integer = 0
        Dim pasa As Boolean = False

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select max(Valor) from ModEntregas where Folio=" & folio
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    valiente = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                    valiente = valiente + 1
                Else
                    valiente = 1
                End If
            Else
                valiente = 1
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ModEntregas where Folio=" & folio & " and Valor=" & valiente & ""
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "insert into ModEntregas(Valor,Folio,Fecha,Chofer) values(" & valiente & "," & folio & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & txtchofer.Text & "')"
                If cmd2.ExecuteNonQuery Then
                    pasa = True
                Else
                    MsgBox("No fue posible guardar la entrega." & vbNewLine & "Sí el problema persiste comuníquese con soporte técnico.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
                cnn2.Close()
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select MAX(Id) from ModEntregas"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    folioentrega = IIf(rd1(0).ToString() = "", 1, rd1(0).ToString())
                End If
            End If
            rd1.Close()

            For moana As Integer = 0 To grdentregados.Rows.Count - 1
                Dim valito As String = grdentregados.Rows(moana).Cells(0).Value.ToString()
                Dim codigo As String = grdentregados.Rows(moana).Cells(1).Value.ToString()
                Dim nombre As String = grdentregados.Rows(moana).Cells(2).Value.ToString()
                Dim cantidad As Double = grdentregados.Rows(moana).Cells(3).Value.ToString()
                Dim precio As Double = 0
                Dim total As Double = 0


                If valito = "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO ModEntregasDet(FolioEntrega,Codigo,Producto,Cantidad,FolioVenta,Precio,Total) VALUES(" & folioentrega & ",'" & codigo & "','" & nombre & "'," & cantidad & "," & folio & "," & precio & "," & total & ")"
                    cmd1.ExecuteNonQuery()

                    If (pasa) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update VentasDetalle set CantidadE=CantidadE+" & cantidad & " where Folio=" & folio & " and Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set Cant_Ent=Cant_Ent-" & cantidad & " where Codigo='" & codigo & "'"
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        Dim Imprime As Boolean = False
        Dim TPrint As String = ""
        Dim Imprime_En As String = ""
        Dim Impresora As String = ""
        Dim Tamaño As String = ""
        Dim Pasa_Print As Boolean = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NoPrint from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Imprime = rd1(0).ToString
            End If
        End If
        rd1.Close() : cnn1.Close()

        If (Imprime) Then
            If MsgBox("¿Deseas imprimir comprobante de entrega?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Pasa_Print = True
            Else
                Pasa_Print = False
            End If
        Else
            Pasa_Print = True
        End If

        If Pasa_Print = True Then
            TPrint = cboimpresion.Text

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

                'Genera PDF y lo guarda en la ruta
                Panel6.Visible = True
                My.Application.DoEvents()
                Insert_Entregas()
                PDF_Entregas()
                Panel6.Visible = False
                My.Application.DoEvents()

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
                    If TPrint = "MEDIA CARTA" Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                Impresora = rd2(0).ToString()
                            End If
                        Else
                            MsgBox("No tienes una impresora configurada para imprimir en formato " & TPrint & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd2.Close() : cnn2.Close()
                            rd1.Close() : cnn1.Close()

                            cnn1.Close() : cnn1.Open()
                            txtchofer.Text = ""
                            grdentregados.Rows.Clear()
                            carga()
                            Exit Sub
                        End If
                        rd2.Close() : cnn2.Close()
                    End If
                    cnn1.Close()
                End If
                rd1.Close() : cnn1.Close()
            End If

            If TPrint = "TICKET" Then
                If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Entregas() : Exit Sub
                If Tamaño = "80" Then
                    pentrega80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pentrega80.Print()
                End If
                If Tamaño = "58" Then
                    pentrega58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pentrega58.Print()
                End If
            Else
                'If TPrint = "MEDIA CARTA" Then
                '    pVentaMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                '    pVentaMediaCarta.Print()
                'End If                
                If TPrint = "CARTA" Then
                    'If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Ventas() : Exit Sub
                    'pVentaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    'pVentaCarta.Print()
                End If
            End If
        End If

        txtchofer.Text = ""
        grdentregados.Rows.Clear()
        carga()
    End Sub

    Private Sub PDF_Entregas()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New EntregaDescuento
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\")
        root_name_recibo = My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf"

        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf") Then
            File.Delete(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .DatabaseName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next


        'Los totales los va a mandar directos
        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & Replace(lblfolio.Text, "FOLIO: ", "") & "'"
        FileNta.DataDefinition.FormulaFields("Folio_Entrega").Text = "'" & lblEntrega.Text & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & "MOSTRADOR" & "'"

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then
            System.IO.File.Copy(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf")
        End If
    End Sub

    Private Sub PDF_Entregas_Copia(ByVal folio As Integer)
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New EntregaDescuento
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\")
        root_name_recibo = My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & ".pdf"

        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & ".pdf") Then
            File.Delete(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .DatabaseName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next


        'Los totales los va a mandar directos
        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & Replace(lblfolio.Text, "FOLIO: ", "") & "'"
        FileNta.DataDefinition.FormulaFields("Folio_Entrega").Text = "'" & folio & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & "MOSTRADOR" & "'"

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then
            System.IO.File.Copy(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\ENTREGAS\" & lblEntrega.Text & "-" & lblfolio.Text & ".pdf")
        End If
    End Sub

    Private Sub Termina_Error_Entregas()
        txtchofer.Text = ""
        grdentregados.Rows.Clear()
        carga()
    End Sub


    Private Sub frmModEntregasDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim folio As String = Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        Dim foli As Integer = folio
        Dim cantidad As Double = 0
        Dim cantidst As Double = 0
        Dim pendiente As Double = 0
        Dim precio As Double = 0
        Dim tot As Double = 0
        Dim valor As Integer = 0

        cbofecha.Items.Clear()
        cbofecha.Tag = ""

        Dim por_entregar As Double = 0

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from VentasDetalle where Folio=" & folio
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cantidad = rd1("Cantidad").ToString
                cantidst = rd1("CantidadE").ToString
                precio = rd1("Precio").ToString

                pendiente = cantidad - cantidst
                tot = CDec(precio * pendiente)
                tot = FormatNumber(tot, 2)
                por_entregar = por_entregar + tot
                If pendiente = 0 Then
                Else
                    grdvendidos.Rows.Add(rd1("Codigo").ToString, rd1("Nombre").ToString, pendiente, FormatNumber(precio, 2), FormatNumber(tot, 2))
                End If
            Loop
            rd1.Close()

            TextBox1.Text = FormatNumber(por_entregar, 2)

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select MAX(Id) from ModEntregas"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblEntrega.Text = CDbl(IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())) + 1
                End If
            Else
                lblEntrega.Text = "1"
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ModEntregasDet where FolioVenta=" & foli & ""
            rd1 = cmd1.ExecuteReader

            cnn2.Close() : cnn2.Open()

            Dim entregados As Double = 0

            Do While rd1.Read
                Dim F_Entrega As Integer = rd1("FolioEntrega").ToString()
                Dim codigo As String = rd1("Codigo").ToString()
                Dim nombre As String = rd1("Producto").ToString()
                Dim canti As Double = rd1("Cantidad").ToString()
                Dim preci As Double = 0
                Dim fecha As String = ""
                Dim chofer As String = ""

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select PrecioVentaIVA from Productos where Codigo='" & codigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        preci = rd2(0).ToString()
                    End If
                End If
                rd2.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from ModEntregas where Id=" & F_Entrega
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        valor = rd2("Valor").ToString()
                        fecha = rd2("Fecha").ToString()
                        chofer = rd2("Chofer").ToString()
                    End If
                End If
                rd2.Close()

                tot = CDec(precio * cantidad)
                tot = Math.Round(tot)

                entregados = entregados + tot

                grdentregados.Rows.Add(valor, codigo, nombre, canti, FormatNumber(precio, 2), FormatNumber(tot, 2), fecha, chofer)
            Loop
            cnn2.Close()
            rd1.Close()

            TextBox2.Text = FormatNumber(entregados, 2)

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Fecha from ModEntregas where Folio=" & foli
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbofecha.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()

            txtcantidad.Text = ""
            txtcodigo.Text = ""
            txtnombre.Text = ""

            txtchofer.Focus().Equals(True)
            My.Application.DoEvents()

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "Select Id from Clientes where Nombre='" & lblcliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                lblidCliente.Text = rd1(0).ToString
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub carga()
        Dim folio As String = Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        Dim foli As Integer = folio
        Dim cantidad As Double = 0
        Dim cantidst As Double = 0
        Dim pendiente As Double = 0
        Dim precio As Double = 0
        Dim tot As Double = 0
        Dim valor As Integer = 0

        grdvendidos.Rows.Clear()
        grdentregados.Rows.Clear()

        cbofecha.Items.Clear()
        cbofecha.Tag = ""

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from VentasDetalle where Folio=" & folio
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cantidad = rd1("Cantidad").ToString
                cantidst = rd1("CantidadE").ToString
                precio = rd1("Precio").ToString

                pendiente = cantidad - cantidst
                tot = CDec(precio * pendiente)
                tot = FormatNumber(tot, 2)
                If pendiente = 0 Then
                Else
                    grdvendidos.Rows.Add(rd1("Codigo").ToString, rd1("Nombre").ToString, pendiente, precio, tot)
                End If
            Loop
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select MAX(Id) from ModEntregas"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblEntrega.Text = CDbl(IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())) + 1
                End If
            Else
                lblEntrega.Text = "1"
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ModEntregasDet where FolioVenta=" & foli & ""
            rd1 = cmd1.ExecuteReader

            cnn2.Close() : cnn2.Open()

            Do While rd1.Read
                Dim F_Entrega As Integer = rd1("FolioEntrega").ToString()
                Dim codigo As String = rd1("Codigo").ToString()
                Dim nombre As String = rd1("Producto").ToString()
                Dim canti As Double = rd1("Cantidad").ToString()
                Dim preci As Double = 0
                Dim fecha As String = ""
                Dim chofer As String = ""

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select PrecioVentaIVA from Productos where Codigo='" & codigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        preci = rd2(0).ToString()
                    End If
                End If
                rd2.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from ModEntregas where Id=" & F_Entrega
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        valor = rd2("Valor").ToString()
                        fecha = rd2("Fecha").ToString()
                        chofer = rd2("Chofer").ToString()
                    End If
                End If
                rd2.Close()

                tot = CDec(precio * cantidad)
                tot = Math.Round(tot)

                grdentregados.Rows.Add(valor, codigo, nombre, canti, FormatNumber(tot, 2), fecha, chofer)
            Loop
            cnn2.Close()
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Fecha from ModEntregas where Folio=" & foli
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbofecha.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()

            txtcantidad.Text = ""
            txtcodigo.Text = ""
            txtnombre.Text = ""

            txtchofer.Focus().Equals(True)
            My.Application.DoEvents()

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "Select Id from Clientes where Nombre='" & lblcliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                lblidCliente.Text = rd1(0).ToString
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdvendidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdvendidos.CellDoubleClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim fila As Integer = grdvendidos.CurrentRow.Index

        If celda.ColumnIndex = 2 Then
            boxcantidad.Visible = True
            txtcantidad.Focus().Equals(True)
            txtcantidad.Tag = grdvendidos.CurrentRow.Cells(2).Value.ToString
            txtcodigo.Text = grdvendidos.CurrentRow.Cells(0).Value.ToString
            txtcodigo.Tag = fila
            txtnombre.Text = grdvendidos.CurrentRow.Cells(1).Value.ToString
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If txtcantidad.Text = "" Then
                boxcantidad.Visible = False
                Exit Sub
            End If
            Dim inicial As Double = txtcantidad.Tag
            Dim final As Double = 0
            Dim actual As Double = 0
            Dim tot As Double = 0

            Dim precio As Double = grdvendidos.Rows(txtcodigo.Tag).Cells(3).Value.ToString()
            Dim total As Double = CDbl(grdvendidos.Rows(txtcodigo.Tag).Cells(3).Value.ToString()) * CDbl(txtcantidad.Text)

            actual = txtcantidad.Text

            If actual > inicial Then MsgBox("No puedes entregar una cantidad mayor a la que está pendiente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.SelectAll() : Exit Sub
            final = inicial - actual

            grdentregados.Rows.Add("", txtcodigo.Text, txtnombre.Text, actual, FormatNumber(precio, 2), FormatNumber(total, 2), "", txtchofer.Text)
            My.Application.DoEvents()

            grdvendidos.Rows(txtcodigo.Tag).Cells(2).Value = final
            tot = CDec(grdvendidos.Rows(txtcodigo.Tag).Cells(2).Value * grdvendidos.Rows(txtcodigo.Tag).Cells(3).Value)
            grdvendidos.Rows(txtcodigo.Tag).Cells(4).Value = tot
            txtcantidad.Text = ""
            txtcantidad.Tag = ""
            txtcodigo.Text = ""
            txtcodigo.Tag = ""
            txtnombre.Text = ""
            boxcantidad.Visible = False
            Dim totas As Double = 0

            For ty As Integer = 0 To grdentregados.Rows.Count - 1
                totas = totas + CDbl(grdentregados.Rows(ty).Cells(5).Value.ToString())
            Next
            TextBox2.Text = FormatNumber(totas, 2)

        End If
    End Sub

    Private Sub pentrega80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pentrega80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
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

        'Variables de consulta del sistema
        Dim nom_logo As String = ""
        Dim logo As Image = Nothing
        Dim tamlogo As String = ""

        'Variables de consulta de la venta
        Dim cliente As String = ""
        Dim adress As String = ""
        Dim id_cliente As Integer = 0
        Dim usuario As String = ""
        Dim fecha As Date = Nothing
        Dim comentario_venta As String = ""

        'Valores de la venta (productos)
        Dim codigo As String = ""
        Dim producto As String = ""
        Dim cantidad As Double = 0

        '[Primera parte]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)

                If tLogo = "CUADRO" Then
                    e.Graphics.DrawImage(Logotipo, 50, 0, 180, 140)
                    Y += 155
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 20, 0, 240, 100)
                    Y += 110
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
                Pie = rd1("Pie3").ToString
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
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ventas where Folio=" & Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                id_cliente = rd1("idCliente").ToString()
                cliente = rd1("Nombre").ToString()
                adress = rd1("Direccion").ToString()
                comentario_venta = rd1("Comentario").ToString()
            End If
        End If
        rd1.Close()
        cnn1.Close()

        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TICKET DE ENTREGA", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("Folio: " & Trim(Replace(lblfolio.Text, "FOLIO: ", "")), fuente_datos, Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.ShortTime), fuente_prods, Brushes.Black, 285, Y, sf)
        Y += 19

        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand


        If cliente <> "" Then
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
            e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 7.5
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Nombre: " & Mid(cliente, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            Y += 13.5
            If Mid(cliente, 29, 100) <> "" Then
                e.Graphics.DrawString(Mid(cliente, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                Y += 13.5
            End If
            Y += 3
            Dim MyNota As String = ""
            Dim zu As Integer = 1

            MyNota = txtdireccion.Text
            Do While Trim(MyNota) <> ""
                MyNota = Mid(txtdireccion.Text, zu, 38)
                If Trim(MyNota) <> "" Then
                    e.Graphics.DrawString(MyNota, fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If
                zu = zu + 38
            Loop
            Y += 4
            Y += 8
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
        Else
            Y += 4
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
        End If

        Dim articulos As Double = 0

        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 50, Y)
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 200, Y)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        For akaza As Integer = 0 To grdentregados.Rows.Count - 1
            Dim valito As String = grdentregados.Rows(akaza).Cells(0).Value.ToString

            codigo = grdentregados.Rows(akaza).Cells(1).Value.ToString
            producto = grdentregados.Rows(akaza).Cells(2).Value.ToString
            cantidad = grdentregados.Rows(akaza).Cells(3).Value.ToString

            If valito = "" Then
                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)
                e.Graphics.DrawString(producto, fuente_prods, Brushes.Black, 58, Y)
                Y += 12.5
                e.Graphics.DrawString(cantidad, fuente_prods, Brushes.Black, 280, Y, sf)
                Y += 21
                articulos = articulos + cantidad
            End If
        Next
        Y -= 3
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        If comentario_venta <> "" Then
            Dim comentaaaa As String = comentario_venta
            Y += 2
            e.Graphics.DrawString("COMENTARIO", New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 140, Y, sc)
            Y += 12
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
        End If
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & articulos, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        If txtchofer.Text <> "" Then
            Y += 5
            e.Graphics.DrawString("CHOFER: " & txtchofer.Text, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 140, Y, sc)
            Y += 20
        End If
        Y += 80
        e.Graphics.DrawLine(New Pen(Brushes.Black, 1), 40, CInt(Y), 229, CInt(Y))
        Y += 8
        e.Graphics.DrawString("Firma", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 135, Y, sc)
        e.HasMorePages = False

    End Sub

    Private Sub Inserta_Entrega_Folio(ByVal folio As Integer)
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim my_folio As Integer = 0
        Dim MyStatus As String = ""
        Dim ACuenta As Double = 0
        Dim Resta As Double = 0
        Dim tel_cliente As String = ""

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
                .runSp(a_cnn, "delete from EntregasDetalle", sinfo)
                .runSp(a_cnn, "delete from Entregas", sinfo)
                sinfo = ""

                If lblcliente.Text <> "" Then
                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select * from Clientes where Nombre='" & lblcliente.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            tel_cliente = rd3("Telefono").ToString()
                        End If
                    End If
                    rd3.Close() : cnn3.Close()
                End If

                'Inserta en la tabla de Ventas
                If .runSp(a_cnn, "insert into Entregas(Nombre,Direccion,Telefono,Usuario,Fecha) values('" & lblcliente.Text & "','" & EliminarSaltosLinea(txtdireccion.Text, " ") & "','" & tel_cliente & "','MOSTRADOR',#" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "#)", sinfo) Then
                    sinfo = ""
                Else
                    MsgBox(sinfo)
                End If

                If .getDr(a_cnn, dr, "select MAX(Folio) from Entregas", sinfo) Then
                    my_folio = dr(0).ToString()
                End If

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from ModEntregasDet where FolioEntrega=" & folio
                rd1 = cmd1.ExecuteReader
                cnn2.Close() : cnn2.Open()

                Do While rd1.Read
                    Dim codigo As String = rd1("Codigo").ToString()
                    Dim nombre As String = rd1("Producto").ToString()
                    Dim cantidad As Double = rd1("Cantidad").ToString()
                    Dim unidad As String = ""

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select UVenta from Productos where Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            unidad = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close()

                    If codigo <> "" Then
                        If .runSp(a_cnn, "insert into EntregasDetalle(Folio,Codigo,Nombre,Cantidad,UVenta) values(" & my_folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "')", sinfo) Then
                            sinfo = ""
                        Else
                            MsgBox(sinfo)
                        End If
                    End If
                Loop
                cnn2.Close()
                rd1.Close() : cnn2.Close()
                a_cnn.Close()
            End If
        End With
    End Sub

    Private Sub btncopia_Click(sender As Object, e As EventArgs) Handles btncopia.Click
        Dim Id_Folio As Integer = 0

        Try

            If cboFolio.Text <> "" Then
                Id_Folio = cboFolio.Text
            End If
            If cbofecha.Text <> "" Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id from ModEntregas where Fecha='" & cbofecha.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Id_Folio = rd1(0).ToString()
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Dim impre As String = ""

        Dim Imprime As Boolean = False
        Dim TPrint As String = ""
        Dim Imprime_En As String = ""
        Dim Impresora As String = ""
        Dim Tamaño As String = ""
        Dim Pasa_Print As Boolean = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NoPrint from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Imprime = rd1(0).ToString
            End If
        End If
        rd1.Close() : cnn1.Close()

        If (Imprime) Then
            If MsgBox("¿Deseas imprimir una copia del comprobante de entrega?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Pasa_Print = True
            Else
                Pasa_Print = False
            End If
        Else
            Pasa_Print = True
        End If

        If Pasa_Print = True Then
            TPrint = cboimpresion.Text

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

                'Genera PDF y lo guarda en la ruta
                Panel6.Visible = True
                My.Application.DoEvents()
                Inserta_Entrega_Folio(Id_Folio)
                PDF_Entregas_Copia(Id_Folio)
                Panel6.Visible = False
                    My.Application.DoEvents()

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
                    If TPrint = "MEDIA CARTA" Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                Impresora = rd2(0).ToString()
                            End If
                        Else
                            MsgBox("No tienes una impresora configurada para imprimir en formato " & TPrint & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd2.Close() : cnn2.Close()
                            rd1.Close() : cnn1.Close()

                            cnn1.Close() : cnn1.Open()
                            txtchofer.Text = ""
                            grdentregados.Rows.Clear()
                            carga()
                            Exit Sub
                        End If
                        rd2.Close() : cnn2.Close()
                    End If
                    cnn1.Close()
                End If
                rd1.Close() : cnn1.Close()
            End If

            If TPrint = "TICKET" Then
                If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Entregas() : Exit Sub
                If Tamaño = "80" Then
                    If cboFolio.Text <> "" Then
                        PCopiaFolio80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        PCopiaFolio80.Print()
                    End If
                    If cbofecha.Text <> "" Then
                        pcopia80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pcopia80.Print()
                    End If
                End If
                If Tamaño = "58" Then
                    'pVenta58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    'pVenta58.Print()
                End If
            Else
                'If TPrint = "MEDIA CARTA" Then
                '    pVentaMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                '    pVentaMediaCarta.Print()
                'End If                
                If TPrint = "CARTA" Then
                    'If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Ventas() : Exit Sub
                    'pVentaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    'pVentaCarta.Print()
                End If
            End If
        End If

        txtchofer.Text = ""
        grdentregados.Rows.Clear()
        carga()

    End Sub

    Private Sub pcopia80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pcopia80.PrintPage
        Dim fuentota As New Font("Lucida Console", 11, FontStyle.Bold)
        Dim fuentita As New Font("Lucida Console", 6, FontStyle.Regular)
        Dim fuente_r As New Font("Lucida Console", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Console", 8, FontStyle.Bold)
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim Y As Double = 0

        Dim folio As Integer = Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        Dim valor As Integer = 0
        valor = cbofecha.Tag

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")

        'Variables de consulta del sistema
        Dim nom_logo As String = ""
        Dim logo As Image = Nothing
        Dim tamlogo As String = ""
        Dim PieNota1 As String = ""
        Dim PieNota2 As String = ""
        Dim PieNota3 As String = ""

        'Variables de consulta de la venta
        Dim cliente As String = ""
        Dim adress As String = ""
        Dim id_cliente As Integer = 0
        Dim usuario As String = ""
        Dim fecha As Date = Nothing

        'Valores de la venta (productos)
        Dim codigo As String = ""
        Dim producto As String = ""
        Dim cantidad As Double = 0
        Dim chofer As String = ""

        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)

                If tLogo = "CUADRO" Then
                    e.Graphics.DrawImage(Logotipo, 50, 0, 180, 140)
                    Y += 155
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 20, 0, 240, 100)
                    Y += 110
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
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()
        cnn1.Close()

        cnn2.Close()
        My.Application.DoEvents()
        cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select * from Ventas where Folio=" & Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                id_cliente = rd2("idCliente").ToString
                cliente = rd2("Nombre").ToString
                adress = rd2("Direccion").ToString
            End If
        End If
        rd2.Close()
        cnn2.Close()

        Y += 10
        e.Graphics.DrawString("COPIA DE ENTREGA", fuentota, Brushes.Black, 135, Y, sc)
        Y += 30

        '[Tercera parte]. Impresió de los datos del cliente (nombre y dirección)
        If cliente <> "" Then
            e.Graphics.DrawString("-------------------------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
            Y += 11
            e.Graphics.DrawString("C L I E N T E", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("-------------------------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
            Y += 12
        End If

        Dim MyNota As String = ""
        Dim zu As Integer = 1

        MyNota = txtdireccion.Text

        If cliente <> "" Then
            e.Graphics.DrawString("Nombre:" & cliente, fuente_r, Brushes.Black, 1, Y)
            Y += 15

            Do While Trim(MyNota) <> ""
                MyNota = Mid(txtdireccion.Text, zu, 38)
                If Trim(MyNota) <> "" Then
                    e.Graphics.DrawString(MyNota, fuente_r, Brushes.Black, 1, Y)
                    Y += 12
                End If
                zu = zu + 38
            Loop
            Y += 4
        End If
        Y += 7
        e.Graphics.DrawString("---------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
        Y += 12

        If id_cliente <> 0 Then
            e.Graphics.DrawString("Cliente: " & id_cliente, fuente_r, Brushes.Black, 1, Y)
        End If

        e.Graphics.DrawString("Folio: " & Trim(Replace(lblfolio.Text, "FOLIO: ", "")), fuente_r, Brushes.Black, 269, Y, sf)
        Y += 12
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/yyyy"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 269, Y, sf)
        Y += 11
        e.Graphics.DrawString("---------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
        Y += 15

        Dim articulos As Double = 0

        '[Quinta parte]. Títulos del ciclo donde muestra los productos
        e.Graphics.DrawString("CODIGO", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPCIÓN", fuente_b, Brushes.Black, 60, Y)
        e.Graphics.DrawString("CANTIDAD", fuente_b, Brushes.Black, 269, Y, sf)
        Y += 18

        Try
            Dim identrega As Integer = 0

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM ModEntregas WHERE Fecha='" & cbofecha.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    chofer = rd2("Chofer").ToString
                    identrega = rd2("Id").ToString
                End If
            End If
            rd2.Close()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from ModEntregasDet where FolioEntrega=" & identrega & ""
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                codigo = rd1("Codigo").ToString
                producto = rd1("Producto").ToString
                cantidad = rd1("Cantidad").ToString

                e.Graphics.DrawString(codigo, fuente_r, Brushes.Black, 1, Y)

                'Do While Trim(producto) <> ""
                '    producto = Mid(producto, zu, 28)
                '    If Trim(producto) <> "" Then
                '        e.Graphics.DrawString(producto, fuente_r, Brushes.Black, 60, Y)
                '        Y += 12
                '    End If
                '    zu = zu + 15
                'Loop
                If Mid(producto, 1, 28) <> "" Then
                    e.Graphics.DrawString(Mid(producto, 1, 28), fuente_r, Brushes.Black, 60, Y)
                    Y += 12
                End If
                If Mid(producto, 29, 56) <> "" Then
                    e.Graphics.DrawString(Mid(producto, 28, 56), fuente_r, Brushes.Black, 60, Y)
                    Y += 12
                End If
                Y += 13
                e.Graphics.DrawString(cantidad, fuente_r, Brushes.Black, 269, Y, sf)
                Y += 12
                articulos = articulos + cantidad
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        Y += 35

        e.Graphics.DrawString("Chofer: " & chofer, fuente_r, Brushes.Black, 1, Y)
        Y += 35
        e.Graphics.DrawString("Cantidad de artículos: " & articulos, fuente_r, Brushes.Black, 1, Y)
        Y += 30
        Y += 40
        e.Graphics.DrawLine(New Pen(Brushes.Black, 1), 40, CInt(Y), 229, CInt(Y))
        Y += 10
        e.Graphics.DrawString("Firma", fuentita, Brushes.Black, 135, Y, sc)
        Y += 30

        e.HasMorePages = False
    End Sub

    Private Sub cbofecha_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofecha.SelectedValueChanged
        Dim fecha_s As String = cbofecha.Text
        Dim fecha_g As String = ""

        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Valor from ModEntregas where Fecha='" & cbofecha.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbofecha.Tag = rd1(0).ToString
                End If
            End If

            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        For gyooturo As Integer = 0 To grdentregados.Rows.Count - 1
            fecha_g = grdentregados.Rows(gyooturo).Cells(4).Value.ToString
            If fecha_g = fecha_s Then
                grdentregados.Rows(gyooturo).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                grdentregados.Rows(gyooturo).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub cboDomi_DropDown(sender As Object, e As EventArgs) Handles cboDomi.DropDown
        cboDomi.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Contador from Entregas where IdCliente=(select Id from Clientes where Nombre='" & lblcliente.Text & "')"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboDomi.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDomi_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDomi.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Domicilio from Entregas where Contador=" & cboDomi.Text & " and IdCliente=" & lblidCliente.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtdireccion.Text = rd1(0).ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub PCopiaFolio80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCopiaFolio80.PrintPage

        Dim fuentota As New Font("Lucida Console", 11, FontStyle.Bold)
        Dim fuentita As New Font("Lucida Console", 6, FontStyle.Regular)
        Dim fuente_r As New Font("Lucida Console", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Console", 8, FontStyle.Bold)
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")

        'Variables de consulta del sistema
        Dim nom_logo As String = ""
        Dim logo As Image = Nothing
        Dim tamlogo As String = ""
        Dim PieNota1 As String = ""
        Dim PieNota2 As String = ""
        Dim PieNota3 As String = ""

        'Variables de consulta de la venta
        Dim cliente As String = ""
        Dim adress As String = ""
        Dim id_cliente As Integer = 0
        Dim usuario As String = ""
        Dim fecha As Date = Nothing

        'Valores de la venta (productos)
        Dim codigo As String = ""
        Dim producto As String = ""
        Dim cantidad As Double = 0
        Dim chofer As String = ""

        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)

                If tLogo = "CUADRO" Then
                    e.Graphics.DrawImage(Logotipo, 50, 0, 180, 140)
                    Y += 155
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 20, 0, 240, 100)
                    Y += 110
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
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()
        cnn1.Close()

        cnn2.Close() : cnn2.Open()
        My.Application.DoEvents()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select * from Ventas where Folio=" & Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                id_cliente = rd2("idCliente").ToString
                cliente = rd2("Nombre").ToString
                adress = rd2("Direccion").ToString
            End If
        End If
        rd2.Close()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText =
            "select * from ModEntregas where Id=" & cboFolio.Text
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                chofer = rd2("Chofer").ToString
            End If
        End If
        rd2.Close()
        cnn2.Close()

        Y += 10
        e.Graphics.DrawString("COPIA DE ENTREGA", fuentota, Brushes.Black, 135, Y, sc)
        Y += 30

        '[Tercera parte]. Impresió de los datos del cliente (nombre y dirección)
        If cliente <> "" Then
            e.Graphics.DrawString("-------------------------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
            Y += 11
            e.Graphics.DrawString("C L I E N T E", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("-------------------------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
            Y += 12
        End If

        Dim MyNota As String = ""
        Dim zu As Integer = 1

        MyNota = txtdireccion.Text

        If cliente <> "" Then
            e.Graphics.DrawString("Nombre:" & cliente, fuente_r, Brushes.Black, 1, Y)
            Y += 12

            Do While Trim(MyNota) <> ""
                MyNota = Mid(txtdireccion.Text, zu, 38)
                If Trim(MyNota) <> "" Then
                    e.Graphics.DrawString(MyNota, fuente_r, Brushes.Black, 1, Y)
                    Y += 12
                End If
                zu = zu + 38
            Loop
        End If
        Y += 7
        e.Graphics.DrawString("---------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
        Y += 12

        If id_cliente <> 0 Then
            e.Graphics.DrawString("Cliente: " & id_cliente, fuente_r, Brushes.Black, 1, Y)
        End If

        e.Graphics.DrawString("Folio Entrega: " & cboFolio.Text, fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Folio: " & Trim(Replace(lblfolio.Text, "FOLIO: ", "")), fuente_r, Brushes.Black, 269, Y, sf)
        Y += 14
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/yyyy"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 269, Y, sf)
        Y += 11
        e.Graphics.DrawString("---------------------------------------", fuente_b, Brushes.Black, 269, Y, sf)
        Y += 15

        Dim articulos As Double = 0

        '[Quinta parte]. Títulos del ciclo donde muestra los productos
        e.Graphics.DrawString("CODIGO", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPCIÓN", fuente_b, Brushes.Black, 60, Y)
        e.Graphics.DrawString("CANTIDAD", fuente_b, Brushes.Black, 269, Y, sf)
        Y += 18

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select * from ModEntregasDet where FolioEntrega=" & cboFolio.Text & ""
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                codigo = rd1("Codigo").ToString
                producto = rd1("Producto").ToString
                cantidad = rd1("Cantidad").ToString

                e.Graphics.DrawString(codigo, fuente_r, Brushes.Black, 1, Y)

                If Mid(producto, 1, 28) <> "" Then
                    e.Graphics.DrawString(Mid(producto, 1, 28), fuente_r, Brushes.Black, 60, Y)
                    Y += 12
                End If
                If Mid(producto, 29, 56) <> "" Then
                    e.Graphics.DrawString(Mid(producto, 28, 56), fuente_r, Brushes.Black, 60, Y)
                    Y += 12
                End If
                Y += 13
                e.Graphics.DrawString(cantidad, fuente_r, Brushes.Black, 269, Y, sf)
                Y += 15
                articulos = articulos + cantidad
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        Y += 20

        e.Graphics.DrawString("Chofer: " & chofer, fuente_r, Brushes.Black, 1, Y)
        Y += 35
        e.Graphics.DrawString("Cantidad de artículos: " & articulos, fuente_r, Brushes.Black, 1, Y)
        Y += 30
        Y += 40
        e.Graphics.DrawLine(New Pen(Brushes.Black, 1), 40, CInt(Y), 229, CInt(Y))
        Y += 10
        e.Graphics.DrawString("Firma", fuentita, Brushes.Black, 135, Y, sc)
        Y += 30

        e.HasMorePages = False

    End Sub

    Private Sub cboFolio_DropDown(sender As Object, e As EventArgs) Handles cboFolio.DropDown
        cbofecha.Text = ""
        Try

            Dim folio0 As String = Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
            Dim folii As Integer = folio0

            cboFolio.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Id FROM ModEntregas WHERE Folio=" & folii & ""
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub cboimpresion_DropDown(sender As Object, e As EventArgs) Handles cboimpresion.DropDown
        cboimpresion.Items.Clear()
        cboimpresion.Items.Add("TICKET")
        'cboimpresion.Items.Add("CARTA")
        'cboimpresion.Items.Add("MEDIA CARTA")
        cboimpresion.Items.Add("PDF - CARTA")
    End Sub

    Private Sub cbofecha_DropDown(sender As Object, e As EventArgs) Handles cbofecha.DropDown
        cboFolio.Text = ""
    End Sub

    Private Sub pentrega58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pentrega58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 6, FontStyle.Regular)
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

        'Variables de consulta del sistema
        Dim nom_logo As String = ""
        Dim logo As Image = Nothing
        Dim tamlogo As String = ""

        'Variables de consulta de la venta
        Dim cliente As String = ""
        Dim adress As String = ""
        Dim id_cliente As Integer = 0
        Dim usuario As String = ""
        Dim fecha As Date = Nothing
        Dim comentario_venta As String = ""

        'Valores de la venta (productos)
        Dim codigo As String = ""
        Dim producto As String = ""
        Dim cantidad As Double = 0

        '[Primera parte]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)

                If tLogo = "CUADRO" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
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
                Pie = rd1("Pie3").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 11
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                    Y += 11
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
                Y += 2
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ventas where Folio=" & Trim(Replace(lblfolio.Text, "FOLIO: ", ""))
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                id_cliente = rd1("idCliente").ToString()
                cliente = rd1("Cliente").ToString()
                adress = rd1("Direccion").ToString()
                comentario_venta = rd1("Comentario").ToString()
            End If
        End If
        rd1.Close()
        cnn1.Close()

        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TICKET DE ENTREGA", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("Folio: " & Trim(Replace(lblfolio.Text, "FOLIO: ", "")), fuente_datos, Brushes.Black, 180, Y, sf)
        Y += 15
        e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.ShortTime), fuente_prods, Brushes.Black, 180, Y, sf)
        Y += 19

        cnn1.Close()
        cnn1.Open()
        cmd1 = cnn1.CreateCommand


        If cliente <> "" Then
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("C L I E N T E", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("Nombre: " & Mid(cliente, 1, 28), fuente_prods, Brushes.Black, 1, Y)
            Y += 12
            If Mid(cliente, 29, 100) <> "" Then
                e.Graphics.DrawString(Mid(cliente, 29, 100), fuente_prods, Brushes.Black, 1, Y)
                Y += 12
            End If
            Y += 3
            Dim MyNota As String = ""
            Dim zu As Integer = 1

            MyNota = txtdireccion.Text
            Do While Trim(MyNota) <> ""
                MyNota = Mid(txtdireccion.Text, zu, 38)
                If Trim(MyNota) <> "" Then
                    e.Graphics.DrawString(MyNota, fuente_prods, Brushes.Black, 1, Y)
                    Y += 12
                End If
                zu = zu + 38
            Loop
            Y += 4
            Y += 8
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
        Else
            Y += 4
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 12
        End If

        Dim articulos As Double = 0

        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 30, Y)
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        For akaza As Integer = 0 To grdentregados.Rows.Count - 1
            Dim valito As String = grdentregados.Rows(akaza).Cells(0).Value.ToString

            codigo = grdentregados.Rows(akaza).Cells(1).Value.ToString
            producto = grdentregados.Rows(akaza).Cells(2).Value.ToString
            cantidad = grdentregados.Rows(akaza).Cells(3).Value.ToString

            If valito = "" Then
                e.Graphics.DrawString(codigo, fuente_prods, Brushes.Black, 1, Y)

                e.Graphics.DrawString(Mid(producto, 1, 25), fuente_prods, Brushes.Black, 33, Y)
                Y += 12
                If Mid(producto, 26, 50) <> "" Then
                    e.Graphics.DrawString(Mid(producto, 26, 50), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                If Mid(producto, 51, 76) <> "" Then
                    e.Graphics.DrawString(Mid(producto, 51, 76), fuente_prods, Brushes.Black, 33, Y)
                    Y += 12
                End If
                'e.Graphics.DrawString(producto, fuente_prods, Brushes.Black, 58, Y)
                Y += 12.5
                e.Graphics.DrawString(cantidad, fuente_prods, Brushes.Black, 180, Y, sf)
                Y += 21
                articulos = articulos + cantidad
            End If
        Next
        Y -= 3
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        If comentario_venta <> "" Then
            Dim comentaaaa As String = comentario_venta
            Y += 2
            e.Graphics.DrawString("COMENTARIO", New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 90, Y, sc)
            Y += 12
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            If Mid(comentaaaa, 1, 40) <> "" Then
                e.Graphics.DrawString(Mid(comentaaaa, 1, 40), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 20, Y)
                comentaaaa = Mid(comentaaaa, 41, 500)
                Y += 10
            End If
            Y -= 3
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
        End If
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & articulos, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 90, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        If txtchofer.Text <> "" Then
            Y += 5
            e.Graphics.DrawString("CHOFER: " & txtchofer.Text, New Drawing.Font(tipografia, 6, FontStyle.Regular), Brushes.Black, 90, Y, sc)
            Y += 10
        End If
        Y += 35
        e.Graphics.DrawLine(New Pen(Brushes.Black, 1), 40, CInt(Y), 229, CInt(Y))
        Y += 10
        e.Graphics.DrawString("Firma", New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Black, 90, Y, sc)
        e.HasMorePages = False
    End Sub
End Class