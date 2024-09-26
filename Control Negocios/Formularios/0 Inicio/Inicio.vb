﻿Imports System.Net
Imports System.IO
Imports System.Data.OleDb
Imports Microsoft.Office.Core
Imports MySql.Data

Public Class Inicio

    Private config As datosSincronizador
    Private configF As datosAutoFac
    Private filenum As Integer
    Private recordLen As String
    Private currentRecord As Long
    Private lastRecord As Long

    Dim num_Sucursales As Integer = 0
    Dim es_matriz As Integer = 0
    Dim dt_Sucursales As New DataTable
    Dim dr_Sucursales As DataRow
    Dim codigopro As String = ""
    Public CONTRASEÑAA As String = ""
    Public perRuta As Integer = 0

    Private Sub Inicio_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            Dim base3 As String = "cn1"
            'Verifica que exista la carpeta, en caso contrario la crea
            If Not Directory.Exists("C:\RControlNegociosPro\CN") Then
                Directory.CreateDirectory("C:\RControlNegociosPro\CN")
            End If

            Dim nobreBD As String = base3 & "[" & Format(Now.ToString("ddMMyyyy")) & "]" & "[" & Format(Now.ToString("HHmmss")) & "]" & ".sql"
            Dim cadena = "cmd.exe /c  C:\xampp\mysql\bin\mysqldump.exe -h localhost -u root " & base3 & " -R> C:\RControlNegociosPro\CN\" & nobreBD

            Shell(cadena)

            ' MessageBox.Show("Backup exitoso!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Login.Close()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pEmpleados.Click
        frmEmpleados.Show()
        frmEmpleados.BringToFront()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pClientes.Click
        frmClientes.Show()
        frmClientes.BringToFront()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pProveedores.Click
        frmProveedores.Show()
        frmProveedores.BringToFront()
    End Sub

    Private Sub pMonederos_Click(sender As System.Object, e As System.EventArgs) Handles pMonederos.Click
        frmMonederos.Show()
        frmMonederos.BringToFront()
    End Sub

    Private Sub VehículosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmVehiculos.Show()
        frmVehiculos.BringToFront()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pSalir.Click
        Me.Close()
        Login.Close()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmProductos.Show()
        frmProductos.BringToFront()
    End Sub

    Private Sub PreciosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pPrecios.Click


        Dim res As String = DatosRecarga2("Restaurante")

        'Try
        '    cnn1.Close() : cnn1.Open()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "SELECT NumPart FROM formatos WHERE Facturas='Restaurante'"
        '    rd1 = cmd1.ExecuteReader
        '    If rd1.HasRows Then
        '        If rd1.Read Then
        '            res = rd1(0).ToString
        '        End If
        '    End If
        '    rd1.Close()
        '    cnn1.Close()

        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        '    cnn1.Close()
        'End Try

        If res = 1 Then
            frmPreciosRest.Show()
            frmPreciosRest.BringToFront()
        Else
            frmPrecios.Show()
            frmPrecios.BringToFront()
        End If


    End Sub

    Private Sub Actualiza_Promos()
        'Dim dia_hoy As Integer = Date.Now.DayOfWeek
        'Dim dia_tex As String = ""

        'If dia_hoy = 0 Then dia_tex = "Domingo"
        'If dia_hoy = 1 Then dia_tex = "Lunes"
        'If dia_hoy = 2 Then dia_tex = "Martes"
        'If dia_hoy = 3 Then dia_tex = "Miercoles"
        'If dia_hoy = 4 Then dia_tex = "Jueves"
        'If dia_hoy = 5 Then dia_tex = "Viernes"
        'If dia_hoy = 6 Then dia_tex = "Sabado"

        ''COMENTARIO DE DÍAS'
        ''0 -> Domingo       '4 -> Jueves
        ''1 -> Lunes         '5 -> Viernes
        ''2 -> Martes        '6 -> Sábado
        ''3 -> Miércoles

        'Try
        '    cnn3.Close() : cnn3.Open()

        '    cmd3 = cnn3.CreateCommand
        '    cmd3.CommandText =
        '        "update Productos set E1=0, E2=0"
        '    cmd3.ExecuteNonQuery()

        '    cnn3.Close() : cnn3.Open()

        '    'Primero 2x1
        '    cmd3 = cnn3.CreateCommand
        '    cmd3.CommandText =
        '        "select * from Promos where " & dia_tex & "=1"
        '    rd3 = cmd3.ExecuteReader
        '    Do While rd3.Read
        '        If rd3.HasRows Then
        '            Dim codigo As String = rd3("Codigo").ToString()

        '            cmd4 = cnn4.CreateCommand
        '            cmd4.CommandText =
        '                "update Productos set E1=1 where Codigo='" & codigo & "'"
        '            cmd4.ExecuteNonQuery()
        '        End If
        '    Loop
        '    rd3.Close()

        '    'Primero 3x2
        '    cmd3 = cnn3.CreateCommand
        '    cmd3.CommandText =
        '        "select * from Promos where " & dia_tex & "2=1"
        '    rd3 = cmd3.ExecuteReader
        '    Do While rd3.Read
        '        If rd3.HasRows Then
        '            Dim codigo As String = rd3("Codigo").ToString()

        '            cmd4 = cnn4.CreateCommand
        '            cmd4.CommandText =
        '                "update Productos set E2=1 where Codigo='" & codigo & "'"
        '            cmd4.ExecuteNonQuery()
        '        End If
        '    Loop
        '    rd3.Close()
        '    cnn3.Close()

        '    cnn3.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString())
        '    cnn3.Close()
        'End Try
    End Sub

    Public Sub Nuevos_Pedidos()
        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select COUNT(Id_Orden) from Pedidos_Tienda where Status=0"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    pedidos_tienda.Text = "Nuevos pedidos: " & rd4(0).ToString()
                End If
            End If
            rd4.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try
    End Sub

    Private Async Sub Inicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'PrimeraConfig = ""
        'Login.Hide()

        'Me.Show()

        'Await SformatosInicio()

        'verif()
        'Permisos(id_usu_log)
        'If varrutabase = "" Then
        '    ActualizaCampos()
        'End If

        ''Licencia()
        'Try
        '    cnn1.Close()
        '    cnn1.Open()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "Select numero,usuario,password from loginrecargas"
        '    rd1 = cmd1.ExecuteReader
        '    If rd1.Read Then
        '        varnumero = rd1("numero").ToString
        '        varusuario = rd1("usuario").ToString
        '        varcontra = rd1("password").ToString
        '    End If
        '    rd1.Close()
        '    cnn1.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        '    cnn1.Close()
        'End Try

        'If tienda_enlinea = True Then
        '    Nuevos_Pedidos()
        'End If

        'Dim tiendalinea As Integer = Await ValidarAsync("TiendaLinea")
        'Dim gimnasios As Integer = Await ValidarAsync("Gimnasio")
        'Dim consignacion As Integer = Await ValidarAsync("Consignacion")
        'Dim nomina As Integer = Await ValidarAsync("Nomina")
        'Dim Mod_Asis As Integer = Await ValidarAsync("Mod_Asis")
        'Dim Control_Servicios As Integer = Await ValidarAsync("Control_Servicios")
        'Dim series As Integer = Await ValidarAsync("Series")
        'Dim produccion As Integer = Await ValidarAsync("Produccion")
        'Dim partes As Integer = Await ValidarAsync("Partes")
        'Dim escuelas As Integer = Await ValidarAsync("Escuelas")
        'Dim costeo As Integer = Await ValidarAsync("Costeo")
        'Dim restaurante As Integer = Await ValidarAsync("Restaurante")
        'Dim refaccionaria As Integer = Await ValidarAsync("Refaccionaria")
        'Dim pollos As Integer = Await ValidarAsync("pollos")
        'Dim telefonia As Integer = Await ValidarAsync("Telefonia")
        'Dim Hoteles As Integer = Await ValidarAsync("Hoteles")
        'Dim Migracion As Integer = Await ValidarAsync("Migracion")
        'Dim Optica As Integer = Await ValidarAsync("Optica")
        'Dim Mov_Cuenta As Integer = Await ValidarAsync("Mov_Cuenta")
        'Dim transportistas As Integer = Await ValidarAsync("Transportistas")
        'Dim produccionpro As Integer = Await ValidarAsync("ProduccionPro")
        'Dim dentista As Integer = Await ValidarAsync("Dentista")

        'If dentista = 1 Then
        '    btnDentista.Visible = True
        'Else
        '    btnDentista.Visible = False
        'End If

        'If produccionpro = 1 Then
        '    TproduccionCos.Visible = True
        'Else
        '    TproduccionCos.Visible = False
        'End If

        'If tiendalinea = 1 Then
        '    PedidosTiendaEnLíneaToolStripMenuItem.Visible = True
        '    pedidos_tienda.Visible = True
        'Else
        '    PedidosTiendaEnLíneaToolStripMenuItem.Visible = False
        '    pedidos_tienda.Visible = False
        'End If

        'If gimnasios = 1 Then
        '    GimnasiosToolStripMenuItem.Visible = True
        'Else
        '    GimnasiosToolStripMenuItem.Visible = False
        'End If

        'If consignacion = 1 Then
        '    menuconsignaciones.Visible = True
        'Else
        '    menuconsignaciones.Visible = False
        'End If

        'If nomina = 1 Then
        '    NominaToolStripMenuItem.Visible = True
        'Else
        '    NominaToolStripMenuItem.Visible = False
        'End If

        'If Mod_Asis = 1 Then
        '    pAsistencia.Visible = True
        'Else
        '    pAsistencia.Visible = False
        'End If

        'If Control_Servicios = 1 Then
        '    ControlDeServiciosToolStripMenuItem.Visible = True
        'Else
        '    ControlDeServiciosToolStripMenuItem.Visible = False
        'End If

        'cnn2.Close() : cnn2.Open()
        'cmd2 = cnn2.CreateCommand
        'cmd2.CommandText = "SELECT Rep_Servicios FROM permisos WHERE IdEmpleado=" & id_usu_log
        'rd2 = cmd2.ExecuteReader
        'If rd2.HasRows Then
        '    If rd2.Read Then
        '        If rd2(0).ToString = 1 Then
        '            If Control_Servicios = 1 Then
        '                ReporteDeControlDeServiciosToolStripMenuItem.Visible = True
        '            Else
        '                ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
        '            End If
        '        Else
        '            ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
        '        End If
        '    End If
        'Else
        '    ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
        'End If
        'rd2.Close()
        'cnn2.Close()

        'If series = 1 Then
        '    ReporteDeSeries.Visible = True
        'Else
        '    ReporteDeSeries.Visible = False
        'End If

        'If produccion = 1 Then
        '    pMod_Produccion.Enabled = True
        '    pMod_Produccion.Visible = True
        '    '  pControl_Procesos.Visible = False
        'Else
        '    pMod_Produccion.Enabled = False
        '    pMod_Produccion.Visible = False
        '    'pControl_Procesos.Visible = False
        'End If

        'If partes = 1 Then
        '    pVentasT.Visible = False
        '    ZapateríaToolStripMenuItem.Visible = False
        '    pMod_Precios.Visible = False
        '    pMod_Produccion.Visible = False
        '    Button5.Visible = False
        'End If

        'If escuelas = 1 Then
        '    pClientes.Visible = False
        '    pMonederos.Visible = False
        '    GruposToolStripMenuItem.Visible = True
        '    AlumnosToolStripMenuItem.Visible = True
        '    InscripciónToolStripMenuItem.Visible = True
        '    ZapateríaToolStripMenuItem.Visible = False
        '    ProductosToolStripMenuItem.Visible = True
        '    ComprasTouchToolStripMenuItem.Visible = False
        '    AlumnosToolStripMenuItem1.Visible = True
        '    pVentasT.Visible = False
        '    pAbonosV.Visible = False
        '    Button5.Visible = False
        'End If

        'If costeo = 1 Then
        'Else
        '    MsgBox("Por favor configura el método de costeo de tu inventario antes de comenzar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        '    PrimeraConfig = "1"
        '    frmConfigs.Show()
        '    frmConfigs.tabFuncionalidades1.Focus().Equals(True)
        '    frmConfigs.tabFuncionalidades1.Select()
        '    frmConfigs.TopMost = True
        'End If

        'If restaurante = 1 Then
        '    Button12.Visible = True
        '    btnPagarComandas.Visible = True
        '    btnvtatouch.Visible = True
        '    CORTEMESERO.Visible = True
        '    pMod_Produccion.Visible = True
        '    pMod_Produccion.Enabled = True
        '    frmPermisos.btnPermisosRestaurante.Visible = True
        '    repHistorialMesas.Visible = True
        'Else
        '    Button12.Visible = False
        '    btnPagarComandas.Visible = False
        '    btnvtatouch.Visible = False
        '    CORTEMESERO.Visible = False
        '    frmPermisos.btnPermisosRestaurante.Visible = False
        '    repHistorialMesas.Visible = False
        'End If

        'If refaccionaria = 1 Then
        '    btnRefaccionaria.Visible = True
        'Else
        '    btnRefaccionaria.Visible = False
        'End If

        'If pollos = 1 Then
        '    btnpollo.Visible = True
        'Else
        '    btnpollo.Visible = False
        'End If

        'If telefonia = 1 Then
        '    btnTelefonia.Visible = True
        'Else
        '    btnTelefonia.Visible = False
        'End If

        'If Hoteles = 1 Then
        '    btnHoteleria.Visible = True
        '    ReporteDeHotelToolStripMenuItem.Visible = True
        'Else
        '    btnHoteleria.Visible = False
        '    ReporteDeHotelToolStripMenuItem.Visible = False
        'End If

        'If Migracion = 1 Then
        '    pMigracion.Visible = True
        'Else
        '    pMigracion.Visible = False
        'End If

        'If Optica = 1 Then
        '    btnOptica.Visible = True
        'Else
        '    btnOptica.Visible = False
        'End If

        'If Mov_Cuenta = 1 Then
        '    ReporteMovCuentasToolStripMenuItem.Visible = True
        '    MovCuentasToolStripMenuItem.Visible = True
        'Else
        '    ReporteMovCuentasToolStripMenuItem.Visible = False
        '    MovCuentasToolStripMenuItem.Visible = False
        'End If

        'If transportistas = 1 Then
        '    TransportistasToolStripMenuItem.Visible = True
        'Else
        '    TransportistasToolStripMenuItem.Visible = False
        'End If

        '''Validación de la aditoria

        'Try
        '    cnn1.Close() : cnn1.Open()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText =
        '        "select NotasCred from Formatos where Facturas='Audita'"
        '    rd1 = cmd1.ExecuteReader
        '    If rd1.HasRows Then
        '        If rd1.Read Then
        '            validaciones.audita = rd1(0).ToString
        '        End If
        '    End If
        '    rd1.Close()
        '    cnn1.Close()

        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        '    cnn1.Close()
        'End Try

        ''Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        ''Dim coma As OleDbCommand = New OleDbCommand
        ''Dim lect As OleDbDataReader = Nothing

        ''VieneDe_Compras = ""
        ''VieneDe_Folios = ""

        ''   Actualiza_Promos()
    End Sub

    Private Sub Licencia()
        Dim ULocal As String
        Dim Linea As Integer
        Dim FileSerie As String
        Dim SerieLib As String
        Dim SFile As String
        Dim params As Integer = 0

        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Evaluo from Parametros"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    params = IIf(rd2("Evaluo").ToString, 1, 0)
                End If
            End If
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            If Not rd2.IsClosed Then
                rd2.Close()
            End If
            cnn2.Close()
        End Try

        If cnn2.State = 1 Then cnn2.Close()

        If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Programs & "\DelsscomControlNegocios\") Then
            crea_ruta(My.Computer.FileSystem.SpecialDirectories.Programs & "\DelsscomControlNegocios\")
        End If

        If Not Directory.Exists("C:\RControlNegociosPro") Then
            crea_ruta("C:\RControlNegociosPro")
        End If

        ULocal = "C:\RControlNegociosPro\DCloc.dll" ' esta fuciona bien
        FileSerie = My.Computer.FileSystem.SpecialDirectories.Programs & "\DelsscomControlNegocios\Lib3r4c10n.dll" ' esta funciona bien

        If FileIO.FileSystem.FileExists(FileSerie) = False Then
            If Login.txtRuta.Text <> "" Then
                If FileIO.FileSystem.FileExists(ULocal) Then
                    Linea = redCont(ULocal) + 1
                    If Linea <= 0 Or Linea >= 30 Then
                        frmPagado.Show()
                        Panel1.Enabled = False
                        MenuStrip1.Enabled = False
                    Else
                        If WriteCont(Linea, ULocal) = False Then
                            End
                        End If
                        MsgBox("Perido de evaluación: " & Linea & " de 30", vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                Else

                    Try
                        cnn3.Close() : cnn3.Open()

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText =
                            "update Parametros set Evaluo=1"
                        cmd3.ExecuteNonQuery()

                        cnn3.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn3.Close()
                    End Try

                    If cnn3.State = 1 Then cnn3.Close()

                    MsgBox("Perido de evaluación: 1 de 30", vbOKOnly, "Delsscom Control Negocios Pro")
                    If WriteCont(1, ULocal) = False Then
                        End
                    End If
                End If
            Else
                If params = 0 Then
                    If FileIO.FileSystem.FileExists(ULocal) Then
                        Linea = redCont(ULocal) + 1
                        If Linea <= 0 Or Linea >= 30 Then
                            frmPagado.Show()
                            Panel1.Enabled = False
                            MenuStrip1.Enabled = False
                        Else
                            If WriteCont(Linea, ULocal) = False Then
                                End
                            End If
                            MsgBox("Perido de evaluación: " & Linea & " de 30", vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                    Else
                        Try
                            cnn3.Close() : cnn3.Open()

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "update Parametros set Evaluo=1"
                            cmd3.ExecuteNonQuery()

                            cnn3.Close()
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString)
                            cnn3.Close()
                        End Try

                        MsgBox("Perido de evaluación: 1 de 30", vbOKOnly, "Delsscom Control Negocios Pro")
                        If WriteCont(1, ULocal) = False Then
                            End
                        End If
                    End If
                Else
                    If FileIO.FileSystem.FileExists(ULocal) Then
                        Linea = redCont(ULocal) + 1
                        If Linea <= 0 Or Linea >= 30 Then
                            frmPagado.Show()
                            Panel1.Enabled = False
                            MenuStrip1.Enabled = False
                        Else
                            If WriteCont(Linea, ULocal) = False Then
                                End
                            End If
                            MsgBox("Perido de evaluación: " & Linea & " de 30", vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                    Else
                        frmPagado.Show()
                        Panel1.Enabled = False
                        MenuStrip1.Enabled = False
                    End If
                End If
            End If
        Else
            SerieLib = frmPagado.GenLicencia(MyNumPC)
            SFile = redSerie(FileSerie)
            If SerieLib <> SFile Then
                MsgBox("La licencia de este sistema es incorrecta.", vbInformation)
                End
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click

        'crea_dir(My.Computer.FileSystem.SpecialDirectories.Programs & "\ControlNegocios")

        Dim FileSerie As String
        Dim SerieLib As String
        Dim SFile As String
        FileSerie = My.Computer.FileSystem.SpecialDirectories.Programs & "\DelsscomControlNegocios\Lib3r4c10n.dll"
        If System.IO.File.Exists(FileSerie) Then
            SerieLib = frmPagado.GenLicencia(MyNumPC)
            SFile = redSerie(FileSerie)
            If SerieLib = SFile Then
                frmLiberado.Show()
            End If
        Else
            frmPagado.Show()
            Panel1.Enabled = False
            MenuStrip1.Enabled = False
            Me.Enabled = False
        End If

    End Sub

    Private Sub ArmadoDeKitsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pKits.Click
        frmKits.Show()
        frmKits.BringToFront()
    End Sub

    Private Sub ConsultaDeFoliosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pcFolios.Click
        frmConsultaNotas.Show()
        frmConsultaNotas.BringToFront()
    End Sub

    Private Sub VentasTouchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pVentasT.Click
        frmVentasTouch.Show()
        frmVentasTouch.BringToFront()
    End Sub

    Private Async Sub ProducirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pProducir.Click

        Try
            Dim produccion As Integer = Await ValidarAsync("Produccion")

            If produccion = 1 Then
                frmProduccion.Show()
                frmProduccion.BringToFront()
            Else

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try



    End Sub

    Private Sub NotasDeCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pNotasC.Click
        frmNotasCredito.Show()
        frmNotasCredito.BringToFront()
    End Sub

    Private Sub CapturaToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles pCaptura.Click

        Dim parte As Integer = DatosRecarga2("Partes")
        Dim series As Integer = DatosRecarga2("Series")
        Dim refaccion As Integer = DatosRecarga2("Refaccionaria")

        If parte = 1 Then
            frmComprasS.Show()
            frmComprasS.BringToFront()
        ElseIf series = 1 Then
            frmComprasSeries.Show()
            frmComprasSeries.BringToFront()

        ElseIf refaccion = 1 Then
            frmComprasS.Show()
            frmComprasS.BringToFront()
        Else
            frmCompras.Show()
            frmCompras.BringToFront()
            ' frmNuvCompras.Show()
            ' frmNuvCompras.BringToFront()
        End If


    End Sub

    Private Sub btnProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnProductos.Click


        Dim partes As Integer = DatosRecarga2("Partes")
        Dim escuelas As Integer = DatosRecarga2("Escuelas")

        If partes = 1 Then
            frmProductosSerie.Show()
            frmProductosSerie.BringToFront()

        ElseIf escuelas = 1 Then
            frmProductos_Escuelas.Show()
            frmProductos_Escuelas.BringToFront()
        Else
            frmProductosS.Show()
            frmProductosS.BringToFront()
        End If
    End Sub

    Private Sub btnClientes_Click(sender As System.Object, e As System.EventArgs) Handles btnClientes.Click
        frmClientes.Show()
        frmClientes.BringToFront()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim parte As Integer = DatosRecarga2("Partes")
        Dim series As Integer = DatosRecarga2("Series")
        Dim refaccion As Integer = DatosRecarga2("Refaccionaria")


        If parte = 1 Then
            frmComprasS.Show()
            frmComprasS.BringToFront()
        ElseIf series = 1 Then
            frmComprasSeries.Show()
            frmComprasSeries.BringToFront()

        ElseIf refaccion = 1 Then
            frmComprasS.Show()
            frmComprasS.BringToFront()
        Else
            frmCompras.Show()
            frmCompras.BringToFront()

            ' frmNuvCompras.Show()
            ' frmNuvCompras.BringToFront()
        End If

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        frmVentasTouch.Show()
        frmVentasTouch.BringToFront()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        frmConsultaNotas.Show()
        frmConsultaNotas.BringToFront()
    End Sub

    Private Sub AnticipoAProveedoresToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pAnticipoP.Click
        frmAnticipoProv.Show()
        frmAnticipoProv.BringToFront()
    End Sub

    Private Sub AbonosANotasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pAbonosV.Click
        frmAbonoNotas.Show()
        frmAbonoNotas.BringToFront()
    End Sub

    Private Sub CobroAEmpleadoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pCEmpleado.Click
        frmCobroEmp.Show()
        frmCobroEmp.BringToFront()
    End Sub

    Private Sub PréstamoAEmpleadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pPEmpleados.Click
        frmPrestamoEmp.Show()
        frmPrestamoEmp.BringToFront()
    End Sub

    Private Sub ConformarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pConformar.Click
        frmConformaProducto.Show()
        frmConformaProducto.BringToFront()
    End Sub

    Private Sub VentasMostradorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pVentasM.Click

        'Dim partes As Integer = DatosRecarga2("Partes")
        'Dim series As Integer = DatosRecarga2("Series")
        'Dim descuento As Integer = DatosRecarga2("Desc_Ventas")
        'Dim refaccion As Integer = DatosRecarga2("Refaccionaria")

        'If partes = 1 Then
        '    frmVentas1_Partes.Show()
        '    frmVentas1_Partes.BringToFront()
        'ElseIf descuento = 1 Then
        '    frmVentas1_Descuentos.Show()
        '    frmVentas1_Descuentos.BringToFront()
        'ElseIf series = 1 Then
        '    frmVentas_Series.Show()
        '    frmVentas_Series.BringToFront()

        'ElseIf refaccion = 1 Then
        '    frmVentas_refa.Show()
        '    frmVentas_refa.BringToFront()
        'Else
        '    frmVentas1.Show()
        '    frmVentas1.BringToFront()
        'End If
        frmVentas3.Show()
        frmVentas3.BringToFront()
    End Sub

    Private Sub RegistroDeEmpleadoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pHorariosEmp.Click
        frmHorariosEmp.Show()
        frmHorariosEmp.BringToFront()
    End Sub

    Private Sub RegistroDeHuellaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRegistroHuella.Click
        frmHuellaEmp.Show()
        frmHuellaEmp.BringToFront()
    End Sub

    Private Sub AsistenciaToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles pRegistroAsis.Click
        frmAsistenciaEmp.Show()
        frmAsistenciaEmp.BringToFront()
    End Sub

    Private Sub ReporteDeAsistenciaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pReporteAsis.Click
        frmReporteAsistencia.Show()
        frmReporteAsistencia.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        frmAsistenciaEmp.Show()
        frmAsistenciaEmp.BringToFront()
    End Sub

    Private Sub CuentasPorPagarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pCuentasPag.Click
        frmCtsPagar.Show()
        frmCtsPagar.BringToFront()
    End Sub

    Private Sub ReporteDeVentasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRepVentas.Click
        'frmRepVentas.Show()
        'frmRepVentas.BringToFront()

        frmNuvRepVentas.Show()
        frmNuvRepVentas.BringToFront()
    End Sub

    Private Sub ReporteDeComprasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRepCompras.Click
        frmRepCompras.Show()
        frmRepCompras.BringToFront()
    End Sub

    Private Sub NóminaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmPagoNomina.Show()
        frmPagoNomina.BringToFront()
    End Sub

    Private Sub OtrosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmOtrosGastos.Show()
        frmOtrosGastos.BringToFront()
    End Sub

    Private Sub PorCobrarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pCobrar.Click
        frmRepCtsCobrar.Show()
        frmRepCtsCobrar.BringToFront()
    End Sub

    Private Sub PorPagarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pPagar.Click
        frmRepCtsPagar.Show()
        frmRepCtsPagar.BringToFront()
    End Sub

    Private Sub ReporteDeIngresosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRepIngEgr.Click
        frmRepEntradas.Show()
        frmRepEntradas.BringToFront()
    End Sub

    Private Sub InventarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pInventario.Click


        frmRepInventario.Show()
        frmRepInventario.BringToFront()




    End Sub

    Private Sub AjusteDeInventarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pAjuste.Click

        Dim DATO As Integer = DatosRecarga2("Series")

        If DATO = 1 Then
            frmSeries.Show()
            frmSeries.BringToFront()
        Else
            frmAjusteInv.Show()
            frmAjusteInv.BringToFront()
        End If

    End Sub

    Private Sub ListadoDePreciosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pLisPrecios.Click
        frmListadoPrecios.Show()
        frmListadoPrecios.BringToFront()
    End Sub

    Private Sub ListadoDeProductosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pLisProductos.Click
        frmListadoProductos.Show()
        frmListadoProductos.BringToFront()
    End Sub

    Private Sub RequisicionesPorRecetaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRequiere_Art.Click
        frmRequiere.Show()
        frmRequiere.BringToFront()
    End Sub

    Private Sub RequisicionesGlobalesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRequiere_Glo.Click
        frmRequiereGlobal.Show()
        frmRequiereGlobal.BringToFront()
    End Sub

    Private Sub ConfiguracionesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pConfigs.Click
        frmConfigs.Show()
        frmConfigs.BringToFront()
    End Sub

    Private Sub SencillaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pSencilla.Click

        Dim partes As Integer = DatosRecarga2("Partes")
        Dim restaurante As Integer = DatosRecarga2("Restaurante")
        Dim refaccionaria As Integer = DatosRecarga2("Refaccionaria")

        If partes = 1 Then
            frmProductosSSerie.Show()
            frmProductosSSerie.BringToFront()

        ElseIf restaurante = 1 Then
            frmProductosSR.Show()
            frmProductosSR.BringToFront()

        ElseIf refaccionaria = 1 Then
            frmProRefaccionaria.Show()
            frmProRefaccionaria.BringToFront()
        Else

            frmProductosS.Show()
            frmProductosS.BringToFront()
        End If

    End Sub

    Private Sub DerivadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pDerivados.Click

        Dim partes As Integer = DatosRecarga2("Partes")
        Dim restaurante As Integer = DatosRecarga2("Restaurante")

        If partes = 1 Then
            frmProductosSerie.Show()
            frmProductosSerie.BringToFront()
        ElseIf restaurante = 1 Then
            frmProductosDR.Show()
            frmProductosDR.BringToFront()
        Else
            frmProductos.Show()
            frmProductos.BringToFront()
        End If

    End Sub

    Private Sub CapturaDeServiciosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pServicios.Click
        frmServicios.Show()
        frmServicios.BringToFront()
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pPedidos.Click
        'frmPedidos.Show()
        ' frmPedidos.BringToFront()

        frmPedidosN.Show()
        frmPedidosN.BringToFront()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        Me.Text = "Delsscom Solutions® Control Negocios Pro" & Strings.Space(70) & FormatDateTime(Date.Now, DateFormat.LongDate) & Strings.Space(80) & empresa_activa

        Timer1.Start()
    End Sub

    Private Sub ReportesDeSalidasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRepEgr.Click
        frmRepSalidas.Show()
        frmRepSalidas.BringToFront()
    End Sub

    Private Sub ProcesosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProcesosToolStripMenuItem.Click
        frmProcesos_Prod.Show()
        frmProcesos_Prod.BringToFront()
    End Sub

    Private Sub ReporteDeVentasGráficasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRepVentasG.Click
        frmRepVentasGraf.Show()
        frmRepVentasGraf.BringToFront()
    End Sub

    Private Sub btnVentasN_Click(sender As System.Object, e As System.EventArgs) Handles btnVentasN.Click
        Try

            'Dim partes As Integer = DatosRecarga2("Partes")
            'Dim series As Integer = DatosRecarga2("Series")
            'Dim descuento As Integer = DatosRecarga2("Desc_Ventas")
            'Dim refaccionaria As Integer = DatosRecarga2("Refaccionaria")

            'If partes = 1 Then
            '    frmVentas1_Partes.Show()
            '    frmVentas1_Partes.BringToFront()

            'ElseIf descuento = 1 Then
            '    frmVentas1_Descuentos.Show()
            '    frmVentas1_Descuentos.BringToFront()

            'ElseIf series = 1 Then
            '    frmVentas_Series.Show()
            '    frmVentas_Series.BringToFront()

            'ElseIf refaccionaria = 1 Then
            '    frmVentas_refa.Show()
            '    frmVentas_refa.BringToFront()
            'Else
            '    frmVentas1.Show()
            '    frmVentas1.BringToFront()
            'End If
            frmVentas3.Show()
            frmVentas3.BringToFront()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub PermisosDeUsuarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pPermisos.Click
        frmPermisos.Show()
        frmPermisos.BringToFront()
    End Sub

    Public Sub Permisos(ByRef id_usuario As Integer)
        Dim Cat As Integer = 0
        Dim Dive As Integer = 0

        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select Cat_Emp,Cat_Cli,cat_Formas,cat_Bancos,cat_Cuentas,Cat_Prov,Cat_Mone,Asis_Hora,Asis_Hue,Asis_Asis,Asis_Rep,Prod_Prod,Prod_Serv,Prod_Pre,Prod_Prom,Prod_Kits,Comp_Ped,Comp_CPed,Comp_Com,Comp_CCom,Comp_NCred,Comp_CtPag,Comp_Abon,Comp_Anti,Vent_Most,Vent_Touch,Vent_NVen,Vent_Coti,Vent_Pedi,Vent_Devo,Vent_CFol,Vent_Abo,Vent_Canc,Vent_EPrec,Ing_CEmp,Egr_PEmp,Egr_Nom,Egr_Tran,Egr_Otro,Rep_Vent,Rep_VentG,Rep_Comp,Rep_CCob,Rep_CPag,Rep_Ent,Rep_Sal,Rep_Aju,Rep_Inv,Rep_CamPrecio,Rep_EstResultado,Rep_Auditoria,List_Pre,List_Pro,List_Fal,Fact_Fact,Fact_Rep,Ad_Perm,Ad_Conf,Ad_Util,Ad_Cort,EliAbono,Ad_Ruta from Permisos where IdEmpleado=" & id_usuario
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    Cat = 0
                    REM Empleados
                    If rd5("Cat_Emp").ToString = True Then
                        pEmpleados.Enabled = True
                        P.C_Empleados = True
                    Else
                        pEmpleados.Enabled = False
                        P.C_Empleados = False
                        Cat += 1
                    End If
                    REM Clientes
                    If rd5("Cat_Cli").ToString = True Then
                        pClientes.Enabled = True
                        btnClientes.Enabled = True
                        P.C_Clientes = True
                    Else
                        pClientes.Enabled = False
                        btnClientes.Enabled = False
                        P.C_Clientes = False
                        Cat += 1
                    End If

                    If rd5("cat_Formas").ToString = True Then
                        FormasDePagoToolStripMenuItem.Enabled = True
                    Else
                        FormasDePagoToolStripMenuItem.Enabled = False
                        Cat += 1
                    End If

                    If rd5("cat_Bancos").ToString = True Then
                        pBancos.Enabled = True
                    Else
                        pBancos.Enabled = False
                        Cat += 1
                    End If

                    If rd5("cat_Cuentas").ToString = True Then
                        CuentasBancariasToolStripMenuItem.Enabled = True
                    Else
                        CuentasBancariasToolStripMenuItem.Enabled = False
                        Cat += 1
                    End If

                    REM Proveedores
                    If rd5("Cat_Prov").ToString = True Then
                        pProveedores.Enabled = True
                        P.C_Proveedores = True
                    Else
                        pProveedores.Enabled = False
                        P.C_Proveedores = False
                        Cat += 1
                    End If

                    REM Monederos
                    If rd5("Cat_Mone").ToString = True Then
                        pMonederos.Enabled = True
                        P.C_Monederos = True
                    Else
                        pMonederos.Enabled = False
                        P.C_Monederos = False
                        Cat += 1
                    End If
                    Dive = 0

                    REM ---
                    If Cat = 4 Then
                        pCatalogos.Enabled = False
                    Else
                        pCatalogos.Enabled = True
                    End If

                    Dim Asis As Integer = 0
                    If rd5("Asis_Hora").ToString = True Then
                        pHorariosEmp.Enabled = True
                        P.A_Horarios = True
                    Else
                        pHorariosEmp.Enabled = False
                        P.A_Horarios = False
                        Asis += 1
                    End If

                    If rd5("Asis_Hue").ToString = True Then
                        pRegistroHuella.Enabled = True
                        P.A_Huella = True
                    Else
                        pRegistroHuella.Enabled = False
                        P.A_Huella = False
                        Asis += 1
                    End If

                    If rd5("Asis_Asis").ToString = True Then
                        pRegistroAsis.Enabled = True
                        P.A_Asistencia = True
                    Else
                        pRegistroAsis.Enabled = False
                        P.A_Asistencia = False
                        Button2.Enabled = False
                        Asis += 1
                    End If

                    If rd5("Asis_Rep").ToString = True Then
                        pReporteAsis.Enabled = True
                        P.A_Reporte = True
                    Else
                        pReporteAsis.Enabled = False
                        P.A_Reporte = False
                        Asis += 1
                    End If

                    If Asis = 4 Then
                        pAsistencia.Enabled = False
                    Else
                        pAsistencia.Enabled = True
                    End If

                    'Productos
                    Dim Prods As Integer = 0
                    If rd5("Prod_Prod").ToString = True Then
                        pCaptura_Prod.Enabled = True
                        P.P_Productos = True
                        frmCompras.btnprod.Enabled = True
                    Else
                        pCaptura_Prod.Enabled = False
                        btnProductos.Enabled = False
                        P.P_Productos = False
                        frmCompras.btnprod.Enabled = False
                        Prods += 1
                    End If

                    If rd5("Prod_Serv").ToString = True Then
                        pServicios.Enabled = True
                        P.P_Servicios = True
                    Else
                        pServicios.Enabled = False
                        P.P_Servicios = False
                        Prods += 1
                    End If

                    If rd5("Prod_Pre").ToString = True Then
                        pPrecios.Enabled = True
                        P.P_Precios = True
                    Else
                        pPrecios.Enabled = False
                        P.P_Precios = False
                        Prods += 1
                    End If

                    If rd5("Prod_Prom").ToString = True Then
                        P.P_Productos = True
                    Else
                        P.P_Promociones = False
                    End If

                    If rd5("Prod_Kits").ToString = True Then
                        pKits.Enabled = True
                        P.P_Kits = True
                    Else
                        pKits.Enabled = False
                        P.P_Kits = False
                        Prods += 1
                    End If

                    If Prods = 4 Then
                        pProductos_Serv.Enabled = False
                    Else
                        pProductos_Serv.Enabled = True
                    End If

                    'Compras
                    Dim Comp As Integer = 0
                    If rd5("Comp_Ped").ToString = True Then
                        pPedidos.Enabled = True
                        P.C_Pedidos = True
                    Else
                        pPedidos.Enabled = False
                        P.C_Pedidos = False
                        Comp += 1
                    End If

                    If rd5("Comp_CPed").ToString() = True Then
                        P.C_CPedidos = True
                    Else
                        P.C_CPedidos = False
                    End If

                    If rd5("Comp_Com").ToString = True Then
                        pCaptura.Enabled = True
                        P.C_Compras = True
                    Else
                        pCaptura.Enabled = False
                        Button4.Enabled = False
                        P.C_Compras = False
                        Comp += 1
                    End If

                    If rd5("Comp_CCom").ToString = True Then
                        P.C_CCompras = True
                    Else
                        P.C_CCompras = False
                    End If

                    If rd5("Comp_NCred").ToString = True Then
                        pNotasC.Enabled = True
                        P.C_NotasCred = True
                    Else
                        pNotasC.Enabled = False
                        P.C_NotasCred = False
                        Comp += 1
                    End If

                    If rd5("Comp_CtPag").ToString = True Then
                        pCuentasPag.Enabled = True
                        P.C_CPagar = True
                    Else
                        pCuentasPag.Enabled = False
                        P.C_CPagar = False
                        Comp += 1
                    End If

                    If rd5("Comp_Abon").ToString = True Then
                        P.C_Abonos = True
                    Else
                        P.C_Abonos = False
                    End If

                    If rd5("Comp_Anti").ToString = True Then
                        pAnticipoP.Enabled = True
                        P.C_Anticipos = True
                    Else
                        pAnticipoP.Enabled = False
                        P.C_Anticipos = False
                        Comp += 1
                    End If

                    If Comp = 5 Then
                        pCompras.Enabled = False
                    Else
                        pCompras.Enabled = True
                    End If

                    'Ventas
                    Dim Vent As Integer = 0
                    If rd5("Vent_Most").ToString = True Then
                        pVentasM.Enabled = True
                        P.V_Mostrador = True
                    Else
                        pVentasM.Enabled = False
                        btnVentasN.Enabled = False
                        P.V_Mostrador = False
                        Vent += 1
                    End If

                    If rd5("Vent_Touch").ToString = True Then
                        pVentasT.Enabled = True
                        P.V_Touch = True
                    Else
                        pVentasT.Enabled = False
                        Button5.Enabled = False
                        P.V_Touch = False
                        Vent += 1
                    End If

                    If rd5("Vent_NVen").ToString = True Then
                        P.V_Ventas = True
                    Else
                        P.V_Ventas = False
                    End If

                    If rd5("Vent_Coti").ToString = True Then
                        P.V_Cotizaciones = True
                    Else
                        P.V_Cotizaciones = False
                    End If

                    If rd5("Vent_Pedi").ToString = True Then
                        P.V_Pedidos = True
                    Else
                        P.V_Pedidos = False
                    End If

                    If rd5("Vent_Devo").ToString = True Then
                        P.V_Devoluciones = True
                    Else
                        P.V_Devoluciones = False
                    End If

                    If rd5("Vent_CFol").ToString = True Then
                        pcFolios.Enabled = True
                        P.V_Folios = True
                    Else
                        pcFolios.Enabled = False
                        Button7.Enabled = False
                        P.V_Folios = False
                        Vent += 1
                    End If

                    If rd5("Vent_Abo").ToString = True Then
                        pAbonosV.Enabled = True
                        P.V_Abonos = True
                    Else
                        pAbonosV.Enabled = False
                        P.V_Abonos = False
                        Vent += 1
                    End If

                    If rd5("Vent_Canc").ToString = True Then
                        P.V_Cancelaciones = True
                    Else
                        P.V_Cancelaciones = False
                    End If

                    If rd5("Vent_EPrec").ToString = True Then
                        P.V_Precios = True
                    Else
                        P.V_Precios = False
                    End If

                    If Vent = 4 Then
                        pVentas.Enabled = False
                    Else
                        pVentas.Enabled = True
                    End If

                    'Ingresos
                    Dim Inge As Integer = 0
                    If rd5("Ing_CEmp").ToString = True Then
                        pCEmpleado.Enabled = True
                        P.I_CobroE = True
                    Else
                        pCEmpleado.Enabled = False
                        P.I_CobroE = False
                        Inge += 1
                    End If

                    If Inge = 1 Then
                        pIngresos.Enabled = False
                    Else
                        pIngresos.Enabled = True
                    End If

                    'Egresos
                    Dim Egre As Integer = 0
                    Dim Gast As Integer = 0
                    If rd5("Egr_PEmp").ToString = True Then
                        pPEmpleados.Enabled = True
                        P.E_PrestamoE = True
                    Else
                        pPEmpleados.Enabled = False
                        P.E_PrestamoE = False
                        Egre += 1
                    End If

                    If rd5("Egr_Nom").ToString = True Then
                        pNomina.Enabled = True
                        P.E_Nomina = True
                    Else
                        pNomina.Enabled = False
                        P.E_Nomina = False
                        Egre += 1
                    End If

                    If rd5("Egr_Tran").ToString = True Then
                        pTransporte.Enabled = True
                        P.E_Transporte = True
                    Else
                        pTransporte.Enabled = False
                        P.E_Transporte = False
                        Egre += 1
                    End If

                    If rd5("Egr_Otro").ToString = True Then
                        pOtros.Enabled = True
                        P.E_Otro = True
                    Else
                        pOtros.Enabled = False
                        P.E_Otro = False
                        Egre += 1
                    End If

                    If Egre = 4 Then
                        pEgresos.Enabled = False
                    Else
                        pEgresos.Enabled = True
                    End If

                    'Reportes
                    Dim Repo As Integer = 0
                    Dim CUent As Integer = 0
                    Dim Inv As Integer = 0
                    If rd5("Rep_Vent").ToString = True Then
                        pRepVentas.Enabled = True
                        Button9.Enabled = True
                        P.R_Ventas = True
                    Else
                        pRepVentas.Enabled = False
                        Button9.Enabled = False
                        P.R_Ventas = False
                        Repo += 1
                    End If

                    If rd5("Rep_VentG").ToString = True Then
                        pRepVentasG.Enabled = True
                        P.R_VentasG = True
                    Else
                        pRepVentasG.Enabled = False
                        P.R_VentasG = False
                        Repo += 1
                    End If

                    If rd5("Rep_Comp").ToString = True Then
                        pRepCompras.Enabled = True
                        P.R_Compras = True
                    Else
                        pRepCompras.Enabled = False
                        P.R_Compras = False
                        Repo += 1
                    End If

                    If rd5("Rep_CCob").ToString = True Then
                        pCobrar.Enabled = True
                        P.R_CuentasC = True
                    Else
                        pCobrar.Enabled = False
                        P.R_CuentasC = False
                        CUent += 1
                    End If

                    If rd5("Rep_CPag").ToString = True Then
                        pPagar.Enabled = True
                        P.R_CuentasP = True
                    Else
                        pPagar.Enabled = False
                        P.R_CuentasP = False
                        CUent += 1
                    End If

                    If CUent = 2 Then
                        Repo += 1
                        pRepCuentas.Enabled = False
                    Else
                        Repo += 0
                        pRepCuentas.Enabled = True
                    End If

                    If rd5("Rep_Ent").ToString = True Then
                        pRepIngEgr.Enabled = True
                        P.R_Entradas = True
                    Else
                        pRepIngEgr.Enabled = False
                        P.R_Entradas = False
                        Repo += 1
                    End If

                    If rd5("Rep_Sal").ToString = True Then
                        pRepEgr.Enabled = True
                        ReporteDeEgresosToolStripMenuItem.Enabled = True
                        P.R_Salidas = True
                    Else
                        pRepEgr.Enabled = False
                        ReporteDeEgresosToolStripMenuItem.Enabled = False
                        P.R_Salidas = False
                        Repo += 1
                    End If

                    If rd5("Rep_Aju").ToString = True Then
                        pAjuste.Enabled = True
                    Else
                        pAjuste.Enabled = False
                    End If

                    If rd5("Rep_Inv").ToString = True Then
                        pInventario.Enabled = True
                        P.R_Inventario = True
                    Else
                        pInventario.Enabled = False
                        P.R_Inventario = False
                        Inv += 1
                    End If

                    If Inv = 2 Then
                        pRepInventario.Enabled = False
                        Repo += 1
                    Else
                        Repo += 0
                        pRepInventario.Enabled = True
                    End If


                    If rd5("Rep_CamPrecio").ToString = True Then
                        pRepPrecios.Enabled = True
                    Else
                        pRepPrecios.Enabled = False
                    End If

                    If rd5("Rep_EstResultado").ToString = True Then
                        pEstResultados.Enabled = True
                    Else
                        pEstResultados.Enabled = False
                    End If

                    If rd5("Rep_Auditoria").ToString = True Then
                        ReporteDeAuditoriaToolStripMenuItem.Enabled = True
                    Else
                        ReporteDeAuditoriaToolStripMenuItem.Enabled = False
                    End If

                    'If Repo = 7 Then
                    '    pReportes.Enabled = False
                    'Else
                    '    pReportes.Enabled = True
                    'End If

                    'Listados
                    Dim List As Integer = 0
                    If rd5("List_Pre").ToString = True Then
                        pLisPrecios.Enabled = True
                        P.L_Precios = True
                    Else
                        pLisPrecios.Enabled = False
                        P.L_Precios = False
                        List += 1
                    End If

                    If rd5("List_Pro").ToString = True Then
                        pLisProductos.Enabled = True
                        P.L_Productos = True
                    Else
                        pLisProductos.Enabled = False
                        P.L_Productos = False
                        List += 1
                    End If

                    If rd5("List_Fal").ToString = True Then
                        pFaltantes.Enabled = True
                        P.L_Faltantes = True
                    Else
                        pFaltantes.Enabled = False
                        P.L_Faltantes = False
                        List += 1
                    End If

                    If List = 3 Then
                        pListados.Enabled = False
                    Else
                        pListados.Enabled = True
                    End If

                    'Facturación
                    Dim Fact As Integer = 0
                    If rd5("Fact_Fact").ToString = True Then
                        pFacturas.Enabled = True
                        P.F_Facturas = True
                    Else
                        pFacturas.Enabled = False
                        Button10.Enabled = False
                        P.F_Facturas = False
                        Fact += 1
                    End If

                    If rd5("Fact_Rep").ToString = True Then
                        pRepFact.Enabled = True
                        P.F_Reporte = True
                    Else
                        pRepFact.Enabled = False
                        P.F_Reporte = False
                        Fact += 1
                    End If

                    If Fact = 2 Then
                        pFacturacion.Enabled = False
                    Else
                        pFacturacion.Enabled = True
                    End If

                    'Administración
                    Dim Admi As Integer = 0
                    If rd5("Ad_Perm").ToString = True Then
                        pPermisos.Enabled = True
                        P.Ad_Permisos = True
                    Else
                        pPermisos.Enabled = False
                        P.Ad_Permisos = False
                        Admi += 1
                    End If

                    If rd5("Ad_Ruta").ToString = True Then
                        perRuta = 1
                    Else
                        perRuta = 0
                    End If

                    If rd5("Ad_Conf").ToString = True Then
                        pConfigs.Enabled = True
                        P.Ad_Configs = True
                    Else
                        pConfigs.Enabled = False
                        P.Ad_Configs = False
                        Admi += 1
                    End If

                    If rd5("Ad_Util").ToString = True Then
                        pUtilerias.Enabled = True
                        P.Ad_Utilidades = True
                    Else
                        pUtilerias.Enabled = False
                        P.Ad_Utilidades = False
                        Admi += 1
                    End If

                    If Admi = 3 Then
                        pAdmin.Enabled = False
                        Button11.Enabled = False
                    Else
                        pAdmin.Enabled = True
                        Button11.Enabled = True
                    End If

                    'Corte
                    If rd5("Ad_Cort").ToString = True Then
                        pCaja.Enabled = True
                        P.Ad_Corte = True
                    Else
                        pCaja.Enabled = False
                        Button11.Enabled = False
                        P.Ad_Corte = False
                    End If

                    If rd5("EliAbono").ToString = True Then
                        EliminarAbonosToolStripMenuItem.Enabled = True
                    Else
                        EliminarAbonosToolStripMenuItem.Enabled = False
                    End If
                End If
            End If
            rd5.Close()

            Dim modprod As String = DatosRecarga("Mod_Prod")
            Dim ModComp As String = DatosRecarga("Mod_Comp")
            Dim ModAsis As String = DatosRecarga("Mod_Asis")

            If modprod = "0" Or modprod = "" Then
                pMod_Produccion.Enabled = False
            Else
                pMod_Produccion.Enabled = True
            End If

            If ModComp = "0" Or ModComp = "" Then
                pMod_Precios.Visible = False
            Else
                pMod_Precios.Visible = True
            End If

            If ModAsis = "0" Or ModAsis = "" Then
                pAsistencia.Enabled = False
            Else
                pAsistencia.Enabled = True
            End If
            cnn5.Close()
        Catch ex As Exception
            cnn5.Close()
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub pEstResultados_Click(sender As System.Object, e As System.EventArgs) Handles pEstResultados.Click
        frmEstResultados.Show()
        frmEstResultados.BringToFront()
    End Sub

    Private Sub MigraciónDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles pMigracion.Click
        frmMigracion.Show()
        frmMigracion.BringToFront()
    End Sub

    Private Sub pBancos_Click_1(sender As System.Object, e As System.EventArgs) Handles pBancos.Click
        frmCatBancos.Show()
        frmCatBancos.BringToFront()
    End Sub

    Private Sub ZapateríaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ZapateríaToolStripMenuItem.Click
        frmProductosZap.Show()
        frmProductosZap.BringToFront()
    End Sub

    Private Sub pOtros_Click(sender As System.Object, e As System.EventArgs) Handles pOtros.Click
        frmOtrosGastos.Show()
        frmOtrosGastos.BringToFront()
    End Sub

    Private Sub pNomina_Click(sender As System.Object, e As System.EventArgs) Handles pNomina.Click
        frmPagoNomina.Show()
        frmPagoNomina.BringToFront()
    End Sub

    Private Sub pFaltantes_Click(sender As System.Object, e As System.EventArgs) Handles pFaltantes.Click
        frmFaltantes.Show()
        frmFaltantes.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnSincro_Click(sender As System.Object, e As System.EventArgs)
        frmAct_Sincronizador.Show()
        frmAct_Sincronizador.BringToFront()
    End Sub

    Private Sub btnSincronizador_Click(sender As System.Object, e As System.EventArgs)
        frmSincro.Show()
        frmSincro.BringToFront()
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As System.EventArgs) Handles Button3.MouseEnter
        Label1.Visible = True
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As System.EventArgs) Handles Button3.MouseLeave
        Label1.Visible = False
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        frmModulos.Show()
        frmModulos.BringToFront()
    End Sub

    Private Sub pFacturas_Click(sender As Object, e As EventArgs) Handles pFacturas.Click
        frmfacturacion.Show()
        frmfacturacion.BringToFront()
    End Sub

    Private Sub pRepPrecios_Click(sender As Object, e As EventArgs) Handles pRepPrecios.Click
        frmRepPrecios.Show()
        frmRepPrecios.BringToFront()
    End Sub

    Private Sub pCaja_Click(sender As Object, e As EventArgs) Handles pCaja.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        frmNuvRepVentas.Show()
        frmNuvRepVentas.BringToFront()


        'frmRepVentas.Show()
        'frmRepVentas.BringToFront()

        'frmEtiquetas2.Show()
        'frmEtiquetas2.BringToFront()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        frmfacturacion.Show()
        frmfacturacion.BringToFront()

    End Sub

    Private Sub ReporteDeEgresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeEgresosToolStripMenuItem.Click
        frmRepSalidas.Show()
        frmRepSalidas.BringToFront()
    End Sub

    Private Sub pRepFact_Click(sender As Object, e As EventArgs) Handles pRepFact.Click
        frmReporteFacturacion.Show()
        frmReporteFacturacion.BringToFront()
    End Sub

    Private Sub SubeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubeClientesToolStripMenuItem.Click
        frmsubeclientes.Show()
        frmsubeclientes.BringToFront()
    End Sub



    Private Sub SubeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubeProveedoresToolStripMenuItem.Click
        frmsubeProveedores.Show()
        frmsubeProveedores.BringToFront()
    End Sub

    Private Sub SubeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubeUsuariosToolStripMenuItem.Click
        frmSubeUsuarios.Show()
        frmSubeUsuarios.BringToFront()
    End Sub

    Private Sub FormasDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormasDePagoToolStripMenuItem.Click
        frmFormaPago.Show()
        frmFormaPago.BringToFront()
    End Sub

    Private Sub CuentasBancariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasBancariasToolStripMenuItem.Click
        frmCuentabANCARIA.Show()
        frmCuentabANCARIA.BringToFront()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnComandera.Click
        frmMesas.Show()
        frmMesas.BringToFront()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        frmPermisosRestaurant.Show()
        frmPermisosRestaurant.BringToFront()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        frmProductos_Escuelas.Show()
        frmProductos_Escuelas.BringToFront()
    End Sub

    Private Sub InscripciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InscripciónToolStripMenuItem.Click
        frmInscripcion.Show()
        frmInscripcion.BringToFront()
    End Sub

    Private Sub AlumnosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlumnosToolStripMenuItem.Click
        frmAlumnos.Show()
        frmAlumnos.BringToFront()
    End Sub

    Private Sub GruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GruposToolStripMenuItem.Click
        frmCatGrupos.Show()
        frmCatGrupos.BringToFront()
    End Sub

    Private Sub ComprasTouchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasTouchToolStripMenuItem.Click
        frmComprasTouch.Show()
        frmComprasTouch.BringToFront()
    End Sub

    Private Sub AlumnosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AlumnosToolStripMenuItem1.Click
        frmRepCuentas.Show()
        frmRepCuentas.BringToFront()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        frmConfigRecargas.Show()
        frmConfigRecargas.BringToFront()
    End Sub

    Private Sub btnvtatouch_Click(sender As Object, e As EventArgs) Handles btnvtatouch.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select NotasCred from Formatos where Facturas='TomaContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = 1 Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Alias,Clave FROM Usuarios WHERE Clave='" & ClaveUsuario & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                frmVTouchR.lblAtendio.Text = rd2("Alias").ToString
                                frmVTouchR.txtUsuario.Text = rd2("Clave").ToString
                                frmVTouchR.Show()
                                frmVTouchR.BringToFront()

                                ' frmNuevo.Show()
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()


                    Else
                        With frmTecladoVtaTouchEntrada

                            frmTecladoVtaTouchEntrada.Show()
                            CONTRASEÑAA = .Respuesta
                            frmVTouchR.txtUsuario.Text = CONTRASEÑAA

                        End With

                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnTelefonia_Click(sender As Object, e As EventArgs) Handles btnTelefonia.Click
        Dim dato As Integer = DatosRecarga2("Telefonia")

        If dato = 1 Then
            frmTallerT.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnRefaccionaria_Click(sender As Object, e As EventArgs) Handles btnRefaccionaria.Click
        Try
            Dim dato As Integer = DatosRecarga2("Refaccionaria")

            If dato = 1 Then
                frmMenuPrincipal.Show()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub RegistroDeHuellaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RegistroDeHuellaToolStripMenuItem.Click
        frmHuellaCliente.Show()
        frmHuellaCliente.BringToFront()
    End Sub

    Private Sub RegistroDeAsistenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeAsistenciaToolStripMenuItem.Click
        frmRegistroAsistencia.Show()
        frmRegistroAsistencia.BringToFront()
    End Sub

    Private Sub ReporteDeAsistenciaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteDeAsistenciaToolStripMenuItem.Click
        frmRepAsistenciaGym.Show()
        frmRepAsistenciaGym.BringToFront()
    End Sub

    Private Sub RegistroDeMembresiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeMembresiasToolStripMenuItem.Click
        frmRegistro.Show()
        frmRegistro.BringToFront()
    End Sub

    Private Sub ControlDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeServiciosToolStripMenuItem.Click
        frmControlServicios.Show()
        frmControlServicios.BringToFront()
    End Sub

    Private Sub ReporteDeControlDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeControlDeServiciosToolStripMenuItem.Click
        frmReporte_CS.Show()
        frmReporte_CS.BringToFront()
    End Sub

    Private Sub btnHoteleria_Click(sender As Object, e As EventArgs) Handles btnHoteleria.Click
        frmMenuHabitaciones.Show()
        frmMenuHabitaciones.BringToFront()
    End Sub

    Private Sub MenuNominaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuNominaToolStripMenuItem.Click
        frmMenuNomina.Show()
        frmMenuNomina.BringToFront()
    End Sub

    Private Sub ReporteDeSeriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeSeries.Click
        frmRepSeries.Show()
        frmRepSeries.BringToFront()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnpollo.Click
        frmPolleria.Show()
        frmPolleria.BringToFront()
    End Sub

    Private Sub ControlServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmControlServ.Show()
        frmControlServ.BringToFront()
    End Sub

    Private Sub ReporteDeAuditoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeAuditoriaToolStripMenuItem.Click
        frmRepAuditoria.Show()
        frmRepAuditoria.BringToFront()
    End Sub

    Private Sub CortePorMeseroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CORTEMESERO.Click
        frmcortemesero.Show()
        frmcortemesero.BringToFront()
    End Sub

    Private Sub CorteDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorteDeCajaToolStripMenuItem.Click

        Dim datos = DatosRecarga2("Restaurante")

        If datos = 1 Then
            frmCorteCaja.Show()
            frmCorteCaja.BringToFront()
        Else
            frmCorte2.Show()
            frmCorte2.BringToFront()
        End If



    End Sub


    Private Sub ReporteDeVentaDeAntibióticosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentaDeAntibióticosToolStripMenuItem.Click
        frmcofepris.Show()
        frmcofepris.BringToFront()
    End Sub

    Private Sub btnPagarComandas_Click(sender As Object, e As EventArgs) Handles btnPagarComandas.Click
        frmNuevoPagarComandas.Show()
        frmNuevoPagarComandas.BringToFront()
    End Sub

    Private Sub VehiculosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehiculosToolStripMenuItem.Click
        frmVehP.Show()
        frmVehP.BringToFront()
    End Sub

    Private Sub ReporteCOFEPRISToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCOFEPRISToolStripMenuItem.Click
        frmcofepris.Show()
        frmcofepris.BringToFront()
    End Sub

    Private Sub CorteDeCajaNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorteDeCajaNToolStripMenuItem.Click
        frmCorte3.Show()
        frmCorte3.BringToFront()
    End Sub

    Private Sub PedidosTiendaEnLíneaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosTiendaEnLíneaToolStripMenuItem.Click
        frmPedidos_Tienda.Show()
        frmPedidos_Tienda.BringToFront()
    End Sub

    Private Sub SubeMonederosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubeMonederosToolStripMenuItem.Click
        frmSubeMonedero.Show()
        frmSubeMonedero.BringToFront()
    End Sub

    Private Sub menuconsignaciones_Click(sender As Object, e As EventArgs) Handles menuconsignaciones.Click
        frmConsignacion.Show()
        frmConsignacion.BringToFront()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        frmConfigs.Show()
        frmConfigs.BringToFront()
    End Sub

    Private Sub ReporteMovCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteMovCuentasToolStripMenuItem.Click
        frmRepMovCuentas.Show()
        frmRepMovCuentas.BringToFront()

    End Sub

    Private Sub MovCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovCuentasToolStripMenuItem.Click
        frmMovCuentas.Show()
        frmMovCuentas.BringToFront()
    End Sub

    Private Sub EliminarAbonosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarAbonosToolStripMenuItem.Click
        frmEliminarAbono.Show()
        frmEliminarAbono.BringToFront()
    End Sub

    Private Sub ReporteDeHotelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeHotelToolStripMenuItem.Click
        frmRepHoteles.Show()
        frmRepHoteles.BringToFront()
    End Sub

    Private Sub btnOptica_Click(sender As Object, e As EventArgs) Handles btnOptica.Click
        frmOptica.Show()
        frmOptica.BringToFront()
    End Sub

    Private Sub btnAuto_Click(sender As Object, e As EventArgs) Handles btnAuto.Click
        frmAutoservicio.Show()
        frmAutoservicio.BringToFront()
    End Sub

    Private Sub pRegistro_Precios_Click(sender As Object, e As EventArgs) Handles pRegistro_Precios.Click
        frmComparador.Show()
        frmComparador.BringToFront()
    End Sub

    Private Sub pReporte_Precios_Click(sender As Object, e As EventArgs) Handles pReporte_Precios.Click
        frmRepComparador.Show()
        frmRepComparador.BringToFront()


    End Sub

    Private Sub pedidos_tienda_Click(sender As Object, e As EventArgs) Handles pedidos_tienda.Click
        'FrmDentistas.Show()
        'FrmDentistas.BringToFront()
    End Sub

    Private Sub VehículosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles VehículosToolStripMenuItem.Click
        frmVehiculos.Show()
        frmVehiculos.BringToFront()
    End Sub

    Private Sub OperadoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperadoresToolStripMenuItem.Click
        frmOperadores.Show()
        frmOperadores.BringToFront()
    End Sub

    Private Sub GastosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GastosToolStripMenuItem1.Click
        frmGastos.Show()
        frmGastos.BringToFront()
    End Sub

    Private Sub ReporteDeGastosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeGastosToolStripMenuItem.Click
        frmRepGastos.Show()
        frmRepGastos.BringToFront()
    End Sub

    Private Sub EstadoDeResultadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeResultadosToolStripMenuItem.Click
        frmEstadoResultados.Show()
        frmEstadoResultados.BringToFront()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        frmProducirQ.Show()
        frmProducirQ.BringToFront()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        frmLotesyCad.BringToFront()
        frmLotesyCad.Show()
    End Sub

    Private Sub ReporteHistorialDeMesasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles repHistorialMesas.Click
        frmHisMesas.BringToFront()
        frmHisMesas.Show()
    End Sub

    Private Sub btnDentista_Click(sender As Object, e As EventArgs) Handles btnDentista.Click
        FrmDentistas.BringToFront()
        FrmDentistas.Show()

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MenuVentasRuta.Click
        frmTraspasosAndroid.Show()
        frmTraspasosAndroid.BringToFront()
    End Sub

    Private Sub btnBodegas_Click(sender As Object, e As EventArgs) Handles btnBodegas.Click
        frmMapa.BringToFront()
        frmMapa.Show()

        'frmpruebas.Show()
    End Sub

    Private Sub pCompras_Click(sender As Object, e As EventArgs) Handles pCompras.Click

    End Sub

    Private Sub btnPediatra_Click(sender As Object, e As EventArgs) Handles btnPediatra.Click
        frmPediatria.BringToFront()
        frmPediatria.Show()
    End Sub

    Private Sub Button12_Click_1(sender As Object, e As EventArgs) Handles Button12.Click

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO `formaspago` (`Id`, `FormaPago`, `Valor`) VALUES
(1, 'TRANSFERENCIA', ''),
(2, 'TARJETA', ''),
(3, 'MONEDERO', ''),
(4, 'SALDO A FAVOR', '');
"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        Catch ex As Exception
            MsgBox("Las formas ya fueron agregadas")
            cnn1.Close()
        End Try

    End Sub
End Class