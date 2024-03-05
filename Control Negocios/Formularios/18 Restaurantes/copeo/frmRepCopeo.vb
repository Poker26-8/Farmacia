Public Class frmRepCopeo
    Private Sub rbTodos_Click(sender As Object, e As EventArgs) Handles rbTodos.Click

        Try
            Dim existencia As String = ""
            Dim militros As Double = 0
            Dim copas As Double = 0
            Dim militroscopa As Double = 0


            Dim eximili As Double = 0
            Dim resultado As Double = 0
            Dim resultado2 As Double = 0

            'eximili=existencia despues del . * mililitros
            'resultado=eximili/100
            'resultado2=eximili/militroscopa

            Dim exispunto As String = ""

            Dim existenciasincopas As String = ""

            Dim rows As Integer = 0
            Dim ValCompra As Double = 0
            Dim ValVenta As Double = 0


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT COUNT(Codigo) FROM Productos ORDER BY Nombre"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    rows = rd1(0).ToString
                End If
            End If
            rd1.Close()

            txtregistros.Text = rows
            barCarga.Visible = True
            barCarga.Value = 0
            barCarga.Maximum = rows

            cmd1.CommandText = "SELECT * FROM Productos ORDER BY Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("Uventa").ToString

                    existencia = rd1("Existencia").ToString
                    militros = rd1("Mililitros").ToString
                    copas = rd1("Copas").ToString

                    Dim existenciapartida() As String = existencia.ToString().Split(".")
                    Dim parteAntesDelPunto As String = existenciapartida(0)

                    Dim pcompra As Double = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                    Dim pventa As Double = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)

                    Dim vcompra As Double = pcompra * existencia
                    Dim vventa As Double = pventa * existencia
                    vcompra = IIf(vcompra < 0, 0, vcompra)
                    vventa = IIf(vventa < 0, 0, vventa)

                    Dim EXISTENCIAREAL As Double = 0

                    If existencia.IndexOf(".") <> -1 Then
                        exispunto = existenciapartida(1)
                        'convertir el numero a double de nuevo
                        exispunto = exispunto.Substring(0, Math.Min(2, exispunto.Length))

                        militroscopa = CDbl(militros) / CDbl(copas)

                        eximili = exispunto * CDbl(militros)
                        resultado = CDbl(eximili) / 100
                        resultado2 = CDbl(resultado) / CDbl(militroscopa)
                        resultado2 = Math.Round(resultado2, MidpointRounding.AwayFromZero)

                        If copas = resultado2 Then
                            EXISTENCIAREAL = CDbl(parteAntesDelPunto) + 1
                        Else
                            EXISTENCIAREAL = parteAntesDelPunto & "." & resultado2

                        End If

                    Else
                        EXISTENCIAREAL = parteAntesDelPunto
                    End If

                    grdCaptura.Rows.Add(codigo,
                                        nombre,
                                        unidad,
                                        EXISTENCIAREAL,
                                        FormatNumber(pcompra, 2),
                                        FormatNumber(pventa, 2),
                                        FormatNumber(vcompra, 2),
                                        FormatNumber(vventa, 2))


                    ValCompra = ValCompra + vcompra
                    ValVenta = ValVenta + vventa

                    barCarga.Value = barCarga.Value + 1
                End If
            Loop
            rd1.Close()
            cnn1.Close()

            barCarga.Visible = False
            barCarga.Value = 0
            txtCompraTot.Text = FormatNumber(ValCompra, 2)
            txtVentaTot.Text = FormatNumber(ValVenta, 2)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnentrada_Click(sender As Object, e As EventArgs) Handles btnentrada.Click
        frmTraspEntrada.Show()
    End Sub

    Private Sub btnsalida_Click(sender As Object, e As EventArgs) Handles btnsalida.Click
        frmTraspSalida.Show()
    End Sub

    Private Sub btnetiquetas_Click(sender As Object, e As EventArgs) Handles btnetiquetas.Click
        frmEtiquetas.Show()
    End Sub

    Private Sub btncardex_Click(sender As Object, e As EventArgs) Handles btncardex.Click
        frmCardex.Show()
    End Sub

    Private Sub btnexcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click

        If grdCaptura.Rows.Count = 0 Then Exit Sub
        If MsgBox("¿Deseas exportar esta información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocio Pro") = vbOK Then
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exBook As Microsoft.Office.Interop.Excel.Workbook
            Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("B").NumberFormat = "@"

                exSheet.Columns("F").NumberFormat = "$#,##0.00"
                    exSheet.Columns("G").NumberFormat = "$#,##0.00"
                    exSheet.Columns("H").NumberFormat = "$#,##0.00"
                    exSheet.Columns("I").NumberFormat = "$#,##0.00"


                    Dim Fila As Integer = 0
                Dim Col As Integer = 0

                Dim NCol As Integer = grdCaptura.ColumnCount
                Dim NRow As Integer = grdCaptura.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdCaptura.Columns(i - 1).HeaderText.ToString
                Next

                For Fila = 0 To NRow - 1
                    For Col = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdCaptura.Rows(Fila).Cells(Col).Value.ToString
                    Next
                Next

                Dim Fila2 As Integer = Fila + 2
                    exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Valor de Compra Total"
                    exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1
                    exSheet.Cells.Item(Fila2 + 3, Col - 1) = "Valor de Venta Total"
                    exSheet.Cells.Item(Fila2 + 3, Col - 1).Font.Bold = 1

                    exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtCompraTot.Text, 2)
                    exSheet.Cells.Item(Fila2 + 3, Col) = FormatNumber(txtVentaTot.Text, 2)


                exSheet.Rows.Item(1).Font.Bold = 1
                exSheet.Rows.Item(1).HorizontalAlignment = 3
                exSheet.Columns.AutoFit()

                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            barCarga.Value = 0
            barCarga.Visible = False

            MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            lblexportar.Visible = False
            grdCaptura.Rows.Clear()
            rbProveedor.PerformClick()
        End If

    End Sub

    Private Sub frmRepCopeo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbProveedor.Checked = True
    End Sub

    Private Sub rbProveedor_Click(sender As Object, e As EventArgs) Handles rbProveedor.Click
        If (rbProveedor.Checked) Then

            rbDepartamento.Checked = False
            rbGrupo.Checked = False
            rbTodos.Checked = False
            cbofiltro.Text = ""
            cbofiltro.Visible = True
            grdCaptura.Rows.Clear()

            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            cbofiltro.Focus.Equals(True)

        End If
    End Sub

    Private Sub cbofiltro_DropDown(sender As Object, e As EventArgs) Handles cbofiltro.DropDown

        Try
            cbofiltro.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbProveedor.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Provpri FROM productos WHERE ProvPri<>'' ORDER BY ProvPri"
            End If

            If (rbDepartamento.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Departamento FROM productos WHERE Departamento<>'' ORDER BY Departamento"
            End If

            If (rbGrupo.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Grupo FROM productos WHERE Grupo<>'' ORDER BY Grupo"
            End If

            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbofiltro.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub

    Private Sub rbDepartamento_Click(sender As Object, e As EventArgs) Handles rbDepartamento.Click
        If (rbDepartamento.Checked) Then

            rbProveedor.Checked = False
            rbGrupo.Checked = False
            rbTodos.Checked = False
            cbofiltro.Text = ""
            cbofiltro.Visible = True
            grdCaptura.Rows.Clear()

            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            cbofiltro.Focus.Equals(True)

        End If
    End Sub

    Private Sub rbGrupo_Click(sender As Object, e As EventArgs) Handles rbGrupo.Click
        If (rbGrupo.Checked) Then

            rbProveedor.Checked = False
            rbDepartamento.Checked = False
            rbTodos.Checked = False
            cbofiltro.Text = ""
            cbofiltro.Visible = True
            grdCaptura.Rows.Clear()

            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"

            cbofiltro.Focus.Equals(True)

        End If
    End Sub

    Private Sub cbofiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofiltro.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then

            Dim query1 As String = ""
            Dim query2 As String = ""
            Dim rows As Integer = 0

            Dim ValCompra As Double = 0
            Dim ValVenta As Double = 0
            txtCompraTot.Text = "0.00"
            txtVentaTot.Text = "0.00"


            Dim existencia As String = ""
            Dim militros As Double = 0
            Dim copas As Double = 0
            Dim militroscopa As Double = 0


            Dim eximili As Double = 0
            Dim resultado As Double = 0
            Dim resultado2 As Double = 0

            'eximili=existencia despues del . * mililitros
            'resultado=eximili/100
            'resultado2=eximili/militroscopa

            Dim exispunto As String = ""
            Dim existenciasincopas As String = ""


            Try
                If (rbProveedor.Checked) Then
                    query1 = "SELECT COUNT(Codigo) FROM productos WHERE Provpri='" & cbofiltro.Text & "'"

                    query2 = "SELECT * FROM Productos WHERE ProvPri='" & cbofiltro.Text & "' ORDER BY Nombre"
                End If

                If (rbDepartamento.Checked) Then
                    query1 = "SELECT COUNT(Codigo) FROM productos WHERE Departamento='" & cbofiltro.Text & "'"

                    query2 = "SELECT * FROM productos WHERE Departamento='" & cbofiltro.Text & "' ORDER BY Nombre"
                End If

                If (rbGrupo.Checked) Then
                    query1 = "SELECT COUNT(Codigo) FROM productos WHERE Grupo='" & cbofiltro.Text & "'"

                    query2 = "SELECT * FROM productos WHERE Grupo='" & cbofiltro.Text & "' ORDER BY Nombre"
                End If

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = query1
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        rows = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                txtregistros.Text = rows
                barCarga.Visible = True
                barCarga.Value = 0
                barCarga.Maximum = rows

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = query2
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        Dim codigo As String = rd1("Codigo").ToString
                        Dim nombre As String = rd1("Nombre").ToString
                        Dim unidad As String = rd1("Uventa").ToString

                        existencia = rd1("Existencia").ToString
                        militros = rd1("Mililitros").ToString
                        copas = rd1("Copas").ToString

                        Dim existenciapartida() As String = existencia.ToString().Split(".")
                        Dim parteAntesDelPunto As String = existenciapartida(0)

                        Dim pcompra As Double = IIf(rd1("PrecioCompra").ToString = "", 0, rd1("PrecioCompra").ToString)
                        Dim pventa As Double = IIf(rd1("PrecioVentaIVA").ToString = "", 0, rd1("PrecioVentaIVA").ToString)

                        Dim vcompra As Double = pcompra * existencia
                        Dim vventa As Double = pventa * existencia
                        vcompra = IIf(vcompra < 0, 0, vcompra)
                        vventa = IIf(vventa < 0, 0, vventa)

                        Dim EXISTENCIAREAL As Double = 0
                        If existencia.IndexOf(".") <> -1 Then
                            exispunto = existenciapartida(1)
                            'convertir el numero a double de nuevo
                            exispunto = exispunto.Substring(0, Math.Min(2, exispunto.Length))

                            militroscopa = CDbl(militros) / CDbl(copas)


                            eximili = exispunto * CDbl(militros)
                            resultado = CDbl(eximili) / 100
                            resultado2 = CDbl(resultado) / CDbl(militroscopa)
                            resultado2 = Math.Round(resultado2, MidpointRounding.AwayFromZero)

                            If copas = resultado2 Then
                                EXISTENCIAREAL = CDbl(parteAntesDelPunto) + 1
                            Else
                                EXISTENCIAREAL = parteAntesDelPunto & "." & resultado2

                            End If

                        Else
                            EXISTENCIAREAL = parteAntesDelPunto
                        End If

                        grdCaptura.Rows.Add(codigo, nombre, unidad, EXISTENCIAREAL, FormatNumber(pcompra, 2), FormatNumber(pventa, 2), FormatNumber(vcompra, 2), FormatNumber(vventa, 2))


                        ValCompra = ValCompra + vcompra
                        ValVenta = ValVenta + vventa

                        barCarga.Value = barCarga.Value + 1


                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                barCarga.Visible = False
                barCarga.Value = 0
                txtCompraTot.Text = FormatNumber(ValCompra, 2)
                txtVentaTot.Text = FormatNumber(ValVenta, 2)

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

    End Sub

    Private Sub btnreporte_Click(sender As Object, e As EventArgs) Handles btnreporte.Click
        Try

            'Producto
            Dim PCodigo As String = ""
            Dim PNombre As String = ""
            Dim PCosto As Double = 0
            Dim PPrecio As Double = 0
            Dim PIVA As Double = 0

            Dim cuantos As Integer = 0

            Dim InvInicial As Double = 0
            Dim InvFinal As Double = 0
            Dim TotalInvInicial As Double = 0
            Dim CostoInvIni As Double = 0
            Dim Efectivo_Ventas As Double = 0
            Dim Efectivo_Costo As Double = 0
            Dim Tota_Utilidad As Double = 0

            'Compras
            Dim CantComp As Double = 0
            Dim CtsTotal As Double = 0
            'Devoluciones
            Dim DevProd As Double = 0
            Dim Efe_Devol As Double = 0
            'Ventas
            Dim VtaTotal As Double = 0
            Dim CantProd As Double = 0

            Dim FechaInvInicial As String = ""
            Dim FechaIni As String = ""
            Dim FechaFin As String = ""
            Dim Reporte As Boolean = False
            Dim FolReporte As Integer = 0

            FechaInvInicial = DatosRecarga("FechaCosteo")
            If FechaInvInicial = "" Then
                SFormatos("FechaCosteo", Format(Date.Now, "dd/MM/yyyy"))
                MsgBox("La fecha establecida para el inventario inicial es: " & Format(Date.Now, "dd/MM/yyyy"), vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                FechaInvInicial = Format(Date.Now, "dd/MM/yyyy")
                FechaIni = Format(Date.Now, "dd/MM/yyyy")
                FechaFin = Format(Date.Now, "dd/MM/yyyy")
                EInvInicial()
                Exit Sub
            Else
                FechaIni = FechaInvInicial
                FechaFin = Format(Date.Now, "dd/MM/yyyy")
            End If

            Reporte = False

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Productos set Cargado=0, CargadoInv=0, InvInicial=0,InvFinal=0, InvInicialCosto=0, InvFinalCosto=0"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct (TA.Codigo), PR.Nombre from TAlmacen TA INNER JOIN Productos PR ON TA.Codigo=PR.Codigo where TA.Fecha>='" & FechaIni & "' and TA.Fecha<='" & FechaFin & "' and TA.FolioReporte=0"
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                'Llena código y nombre
                PCodigo = rd1("Codigo").ToString()
                PNombre = rd1("Nombre").ToString()

                'Obtiene inventario inicial
                InvInicial = InventarioI(PCodigo, CostoInvIni)

                'Obtiene el la cantidad comprada
                CantComp = CompP(PCodigo, FechaIni, FechaFin)

                'Obtiene la cantidad de productos devueltos
                DevProd = Canc_Dev(PCodigo, FechaIni, FechaFin)

                'Obtiene la cantidad de ventas | Precio del producto con IVA | Total de la ventas | Total en costo por las ventas
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select PrecioCompra, PrecioVentaIVA, IVA from Productos where Codigo='" & PCodigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        PIVA = rd2("IVA").ToString()
                        PCosto = rd2("PrecioCompra").ToString()
                        PPrecio = rd2("PrecioVentaIVA").ToString()
                    End If
                End If
                rd2.Close()

                Efe_Devol = Efectivo_Dev(PCodigo, FechaIni, FechaFin)

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select SUM(VD.Total) as TotalPre, SUM(VD.Cantidad) as CantP from Ventas V INNER JOIN VentasDetalle VD ON VD.Folio=V.Folio where VD.Codigo='" & PCodigo & "' and V.Status<>'CANCELADA' and VD.Fecha>='" & Format(CDate(FechaIni), "yyyy-MM-dd") & "' and VD.Fecha<='" & Format(CDate(FechaFin), "yyyy-MM-dd") & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        VtaTotal = IIf(rd2("TotalPre").ToString() = "", 0, rd2("TotalPre").ToString())
                        CantProd = IIf(rd2("CantP").ToString() = "", 0, rd2("CantP").ToString())
                    End If
                Else
                    VtaTotal = 0
                    CantProd = 0
                End If
                rd2.Close()

                InvFinal = ((InvInicial + CantComp) - CantProd) + DevProd

                CtsTotal = CantProd * PCosto

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "update Productos set Cargado=0, CargadoInv=0, InvInicial=" & InvInicial & " where Codigo='" & PCodigo & "'"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "update Productos set Cargado=0, CargadoInv=0, InvFinal=" & InvFinal & " where Codigo='" & PCodigo & "'"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "insert into RepoMen(Codigo,PDesc,InvIni,Compra,CantDev,InvFin,CVta,PPrecio,VtaTotal,CostoTotal) values('" & PCodigo & "','" & PNombre & "'," & InvInicial & "," & CantComp & "," & DevProd & "," & InvFinal & "," & CantProd & "," & PPrecio & "," & VtaTotal & "," & CtsTotal & ")"
                cmd2.ExecuteNonQuery()

                Reporte = True
                cuantos += 1
            Loop
            cnn2.Close()
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select sum(VtaTotal) as Vent, sum(CostoTotal) as Cost from RepoMen"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Efectivo_Ventas = rd1("Vent").ToString()
                    Efectivo_Costo = rd1("Cost").ToString()
                End If
            End If
            rd1.Close() : cnn1.Close()

            Tota_Utilidad = FormatNumber(Efectivo_Ventas - Efectivo_Costo, 4)

            System.Threading.Thread.Sleep(1000)

            If Reporte = True Then
                If MsgBox("¿Deseas establecer un inventario inicial para el siguiente reporte?", vbQuestion + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update TAlmacen set FechaReporte='" & Format(Date.Now, "dd/MM/yyyy") & "' where FolioReporte=0"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select MAX(FolioReporte) from TAlmacen"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            FolReporte = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()) + 1
                        End If
                    Else
                        FolReporte = 1
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update TAlmacen set FolioReporte=" & FolReporte & " where FolioReporte=0"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Devoluciones set FolioReporte=" & FolReporte & " where FolioReporte=0"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update ComprasDet set FolioRep=" & FolReporte & " where FolioRep=0"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into HEResultados(Codigo,PDesc,InvIni,Compra,CantDev,InvFin,Cvta,PPrecio,VtaTotal,CostoTotal) select Codigo,PDesc,InvIni,Compra,CantDev,InvFin,CVta,PPrecio,VtaTotal,CostoTotal from RepoMen"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select MAX(Folio_Rep) from HEResultados"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            FolReporte = IIf(rd1(0).ToString() = "", 0, rd1(0).ToString()) + 1
                        End If
                    Else
                        FolReporte = 1
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update HEResultados set C_Vtas=" & Efectivo_Ventas & ", C_Utilidad=" & Tota_Utilidad & ", C_Costo=" & Efectivo_Costo & ", Folio_Rep=" & FolReporte & ", Fecha_Rep='" & Format(Date.Now, "dd/MM/yyyy") & "', Fecha_Ini='" & FechaIni & "' where Folio_Rep=0"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update VentasDetalle set VDCosteo=1 where VDCosteo=0"
                    cmd1.ExecuteNonQuery()

                    cnn1.Close()

                    EInvInicial()
                    SFormatos("FechaCosteo", Format(Date.Now, "dd/MM/yyyy"))
                End If

                'Genera el reporte (yo digo que en Excel), sí en Excel
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from RepoMen order by Codigo"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        grdestado.Rows.Add(
                            rd1("Codigo").ToString(),
                            rd1("PDesc").ToString(),
                            rd1("InvIni").ToString(),
                            rd1("Compra").ToString(),
                            rd1("CantDev").ToString(),
                            rd1("InvFin").ToString(),
                            rd1("CVta").ToString(),
                            rd1("PPrecio").ToString(),
                            rd1("VtaTotal").ToString(),
                            rd1("CostoTotal").ToString()
                            )
                    End If
                Loop
                rd1.Close() : cnn1.Close()

                If grdestado.Rows.Count = 0 Then Exit Sub
                Dim exApp As New Microsoft.Office.Interop.Excel.Application
                Dim exBook As Microsoft.Office.Interop.Excel.Workbook
                Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

                exBook = exApp.Workbooks.Add
                exSheet = exBook.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"
                exSheet.Columns("B").NumberFormat = "@"

                Dim Fila As Integer = 0
                Dim Col As Integer = 0

                Dim NCol As Integer = grdestado.ColumnCount
                Dim NRow As Integer = grdestado.RowCount

                For i As Integer = 1 To NCol
                    exSheet.Cells.Item(1, i) = grdestado.Columns(i - 1).HeaderText.ToString
                Next

                For Fila = 0 To NRow - 1
                    For Col = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 2, Col + 1) = grdestado.Rows(Fila).Cells(Col).Value.ToString
                    Next
                Next

                Dim Fila2 As Integer = Fila + 2
                ''Aquí manda los datos conclusorios

                'exSheet.Cells.Item(Fila2 + 2, Col - 1) = "Valor de Compra Total"
                'exSheet.Cells.Item(Fila2 + 2, Col - 1).Font.Bold = 1
                'exSheet.Cells.Item(Fila2 + 3, Col - 1) = "Valor de Venta Total"
                'exSheet.Cells.Item(Fila2 + 3, Col - 1).Font.Bold = 1

                'exSheet.Cells.Item(Fila2 + 2, Col) = FormatNumber(txtCompraTot.Text, 2)
                'exSheet.Cells.Item(Fila2 + 3, Col) = FormatNumber(txtVentaTot.Text, 2)

                exSheet.Rows.Item(1).Font.Bold = 1
                exSheet.Rows.Item(1).HorizontalAlignment = 3
                exSheet.Columns.AutoFit()

                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing

                barCarga.Value = 0
                barCarga.Visible = False

                MsgBox("Reporte exportado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Else
                If DatosRecarga("FechaCosteo") = "" Then
                    EInvInicial()
                    SFormatos("FechaCosteo", Format(Date.Now, "yyyy-MM-dd"))
                End If

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select count(FolioReporte) from TAlmacen where FolioReporte=0"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(0).ToString() = 0 Then
                            EInvInicial()
                            SFormatos("FechaCosteo", Format(Date.Now, "yyyy-MM-dd"))
                        End If
                    End If
                End If
                rd1.Close() : cnn1.Close()
            End If

            Exit Sub


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Function InventarioI(ByVal COD As String, ByRef CostoInv As Double) As Double
        Dim FCosteo As String = DatosRecarga("FechaCosteo")
        FCosteo = IIf(FCosteo = "", Format(Date.Now, "dd/MM/yyyy"), FCosteo)

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            ' cmd3.CommandText =
            '  "select TOP 1 IDTAlmacen,Exist,Saldo from TAlmacen where Codigo='" & COD & "' and Fecha>='" & FCosteo & "' and FolioReporte=0 and TipoMov='Inventario inicial' order by IDTAlmacen desc"
            cmd3.CommandText =
                "select IDTAlmacen,Exist,Saldo from TAlmacen where Codigo='" & COD & "' and Fecha>='" & FCosteo & "' and FolioReporte=0 and TipoMov='Inventario inicial' LIMIT 1"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    InventarioI = rd3("Exist").ToString()
                    CostoInv = rd3("Saldo").ToString()
                End If
            Else
                InventarioI = 0
                CostoInv = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Sub EInvInicial()
        Dim codigoProd As String = ""
        Dim fechaAhora As String = Format(Date.Now, "dd/MM/yyyy")
        Dim unidadProd As String = ""
        Dim existeProd As Double = 0
        Dim costoProd As Double = 0
        Dim totalCosto As Double = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos"
            rd1 = cmd1.ExecuteReader
            cnn2.Close() : cnn2.Open()
            Do While rd1.Read
                If rd1.HasRows Then
                    codigoProd = rd1("Codigo").ToString()
                    unidadProd = rd1("UVenta").ToString()
                    existeProd = rd1("Existencia").ToString()
                    costoProd = rd1("PrecioCompra").ToString()
                    totalCosto = existeProd * costoProd

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into TAlmacen(Codigo,Fecha,Folio,TipoMov,Entrada,UndE,Salida,UndS,Exist,Costo,Debe,ExiCont,Haber,Saldo,FolioReporte,FechaReporte) values('" & codigoProd & "','" & fechaAhora & "',0,'Inventario inicial',0,'" & unidadProd & "',0,'" & unidadProd & "'," & existeProd & "," & costoProd & ",0," & existeProd & "," & totalCosto & "," & totalCosto & ",0,'')"
                    cmd2.ExecuteNonQuery()
                End If
            Loop
            rd1.Close() : cnn1.Close() : cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function CompP(ByVal Cod As String, ByVal FFechaIni As Date, ByVal FFechaFin As Date) As Double
        CompP = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select SUM(Cantidad) as II from ComprasDet where Codigo='" & Cod & "' and FechaC>='" & Format(FFechaIni, "yyyy-MM-dd 00:00:00") & "' and FechaC<='" & Format(FFechaFin, "yyyy-MM-dd 23:59:59") & "' and FolioRep=0"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    CompP = IIf(rd3("II").ToString() = "", 0, rd3("II").ToString())
                End If
            Else
                CompP = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

    Private Function Canc_Dev(ByVal Cod As String, ByVal FFechaIni As Date, ByVal FFechaFin As Date) As Double
        Canc_Dev = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select SUM(Cantidad) as CD from Devoluciones where Codigo='" & Cod & "' and Fecha>='" & Format(FFechaIni, "yyyy-MM-dd 00:00:00") & "' and Fecha<='" & Format(FFechaFin, "yyyy-MM-dd 23:59:59") & "' and FolioReporte=0"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Canc_Dev = IIf(rd3("CD").ToString() = "", 0, rd3("CD").ToString())
                End If
            Else
                Canc_Dev = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
        Return Canc_Dev
    End Function

    Private Function Efectivo_Dev(ByVal Cod As String, ByVal FFechaIni As Date, ByVal FFechaFin As Date) As Double
        Efectivo_Dev = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select SUM(Cantidad * CostoVUE) as Cant from Devoluciones where Codigo='" & Cod & "' and Facturado='DEVOLUCION' and Fecha>='" & Format(FFechaIni, "yyyy-MM-dd 00:00:00") & "' and Fecha<='" & Format(FFechaFin, "yyyy-MM-dd 23:59:59") & "' and FolioReporte=0"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Efectivo_Dev = IIf(rd3("Cant").ToString() = "", 0, rd3("Cant").ToString())
                End If
            Else
                Efectivo_Dev = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function


End Class