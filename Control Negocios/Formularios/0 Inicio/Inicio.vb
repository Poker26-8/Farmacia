Imports System.Net
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


        Dim res As Integer = 0

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM formatos WHERE Facturas='Restaurante'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    res = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

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

    Private Sub Inicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrimeraConfig = ""
        Login.Hide()
        'Timer1.Start()
        verif()
        Permisos(id_usu_log)
        If varrutabase = "" Then
            ActualizaCampos()
        End If
        SFormatos("Pollos", "")
        SFormatos("Pto-Bascula", "")
        SFormatos("TBascula", "")
        SFormatos("Bascula", "")
        SFormatos("Prefijo", "")
        SFormatos("Codigo", "")
        SFormatos("Peso", "")
        SFormatos("Taller", "")
        SFormatos("MesasPropias", "")
        SFormatos("Copa", "")
        SFormatos("ToleHabi", "")
        SFormatos("SalidaHab", "")
        SFormatos("PrecioDia", "")
        SFormatos("Cuartos", "")
        'Licencia()
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from loginrecargas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                varnumero = rd1("numero").ToString
                varusuario = rd1("usuario").ToString
                varcontra = rd1("password").ToString
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        'ActualizaCampos()
        'Validaciones del módulo de trasporte

        'Validaciones del módulo de asistencia


        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Gimnasio'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NotasCred").ToString() = 1 Then
                        GimnasiosToolStripMenuItem.Visible = True
                    Else
                        GimnasiosToolStripMenuItem.Visible = False
                    End If
                End If
            Else
                GimnasiosToolStripMenuItem.Visible = False
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Nomina'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        NominaToolStripMenuItem.Visible = True
                    Else
                        NominaToolStripMenuItem.Visible = False
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try


        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Mod_Asis'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        pAsistencia.Visible = True
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try


        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Formatos where Facturas='Control_Servicios'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("NumPart").ToString() = 1 Then
                        ControlDeServiciosToolStripMenuItem.Visible = True

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Rep_Servicios FROM permisos WHERE IdEmpleado=" & id_usu_log
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                If rd2(0).ToString = 1 Then
                                    ReporteDeControlDeServiciosToolStripMenuItem.Visible = True
                                Else
                                    ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
                                End If

                            End If
                        Else
                            ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
                        End If
                        rd2.Close()
                    Else
                        ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        'series
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select NotasCred from Formatos where Facturas='Series'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = 1 Then
                        ReporteDeSeries.Visible = True
                    Else
                        ReporteDeSeries.Visible = False
                    End If

                End If
                End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try


        'Validación de la aditoria

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='Audita'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    validaciones.audita = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Produccion'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = "1" Then
                        pMod_Produccion.Enabled = True
                        pMod_Produccion.Visible = True
                        pControl_Procesos.Visible = False
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='Partes'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = "1" Then
                        pVentasT.Visible = False
                        ZapateríaToolStripMenuItem.Visible = False
                        pMod_Precios.Visible = False
                        pMod_Produccion.Visible = False
                        Button5.Visible = False
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Escuelas'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = 1 Then
                        pClientes.Visible = False
                        pMonederos.Visible = False
                        GruposToolStripMenuItem.Visible = True
                        AlumnosToolStripMenuItem.Visible = True
                        InscripciónToolStripMenuItem.Visible = True
                        ZapateríaToolStripMenuItem.Visible = False
                        ProductosToolStripMenuItem.Visible = True
                        ComprasTouchToolStripMenuItem.Visible = False
                        AlumnosToolStripMenuItem1.Visible = True
                        pVentasT.Visible = False
                        pAbonosV.Visible = False
                        Button5.Visible = False
                    End If
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select NumPart from Formatos where Facturas='Costeo'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = 0 Then
                        MsgBox("Por favor configura el método de costeo de tu inventario antes de comenzar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        PrimeraConfig = "1"
                        frmConfigs.Show()
                        frmConfigs.tabFuncionalidades1.Focus().Equals(True)
                        frmConfigs.tabFuncionalidades1.Select()
                        frmConfigs.TopMost = True
                    End If
                End If
            End If
            rd1.Close()

            Dim refa As Integer = 0
            Dim restaurante As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Restaurante'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    restaurante = rd1(0).ToString
                    If restaurante = 1 Then
                        Button12.Visible = True
                        Button13.Visible = True
                        btnPagarComandas.Visible = True
                        btnvtatouch.Visible = True
                        CORTEMESERO.Visible = True
                        pMod_Produccion.Visible = True
                        pMod_Produccion.Enabled = True
                    Else
                        Button12.Visible = False
                        Button13.Visible = False
                        btnPagarComandas.Visible = False
                        btnvtatouch.Visible = False
                        CORTEMESERO.Visible = False
                    End If

                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Pollos'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    restaurante = rd1(0).ToString
                    If restaurante = 1 Then
                        btnpollo.Visible = True
                    Else
                        btnpollo.Visible = False
                    End If

                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Refaccionaria'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    refa = rd1(0).ToString
                    If refa = 1 Then
                        btnRefaccionaria.Visible = True
                    Else

                        btnRefaccionaria.Visible = False
                    End If

                End If
            End If
            rd1.Close()

            Dim telefonia As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Telefonia'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    telefonia = rd1(0).ToString
                    If telefonia = 1 Then
                        btnTelefonia.Visible = True
                    Else

                        btnTelefonia.Visible = False
                    End If

                End If
            End If
            rd1.Close()

            Dim hoteles As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Hoteles'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    hoteles = rd1(0).ToString
                    If hoteles = 1 Then
                        btnHoteleria.Visible = True
                    Else
                        btnHoteleria.Visible = False
                    End If
                End If
            End If
            rd1.Close()

            Dim migracion As Boolean = False

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='Migracion'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = "" Then
                        migracion = True
                    Else
                        migracion = False
                    End If
                End If
            End If
            rd1.Close() : cnn1.Close()

            If (migracion) Then
                pMigracion.Visible = True
            Else
                pMigracion.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        Dim coma As OleDbCommand = New OleDbCommand
        Dim lect As OleDbDataReader = Nothing


        'cias.Close()
        'cias.Open()
        'coma = cias.CreateCommand
        'coma.CommandText = "Select Zink from Server"
        'lect = coma.ExecuteReader
        'If lect.Read Then
        '    zinc = lect(0).ToString
        'End If
        'lect.Close()
        'cias.Close()

        'Valida sincronizador
        'If zinc = 1 Then
        '    If IO.File.Exists(ARCHIVO_DE_CONFIGURACION) Then

        '        filenum = FreeFile()
        '        FileOpen(filenum, ARCHIVO_DE_CONFIGURACION, OpenMode.Random, OpenAccess.ReadWrite)

        '        recordLen = Len(config)

        '        FileGet(filenum, config, 1)

        '        ipserver = Trim(config.ipr)
        '        database = Trim(config.baser)
        '        userbd = Trim(config.usuarior)
        '        passbd = Trim(config.passr)
        '        If IsNumeric(Trim(config.sucursalr)) Then
        '            susursalr = Trim(config.sucursalr)
        '        End If

        '        sTargetdSincro = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=300"

        '        FileClose()

        '        sTargetdAutoFac = ""


        '        If Not IsNumeric(susursalr) Then
        '            frmConfigSincro.Show()
        '        Else
        '            frmSincro.Show()
        '            'frmSincro.BringToFront()
        '            Me.WindowState = FormWindowState.Minimized
        '        End If
        '    Else
        '        'Se configuran los datos porque no está activado
        '        frmConfigSincro.Show()
        '        Me.WindowState = FormWindowState.Minimized
        '    End If
        'End If

        VieneDe_Compras = ""
        VieneDe_Folios = ""

        Actualiza_Promos()
    End Sub

    Public Sub verif()

        'abonoi
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Mesero FROM abonoi"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoi add column Mesero varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Descuento FROM abonoi"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoi add column Descuento float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT cat_Formas FROM Permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Permisos add column cat_Formas int(11) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT cat_Bancos FROM Permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Permisos add column cat_Bancos int(11) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT cat_Cuentas FROM Permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Permisos add column cat_Cuentas int(11) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Valor from FormasPago"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Alter table FormasPago add column Valor varchar(255)"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select NoPrintCom from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Alter table Ticket add column NoPrintCom int(11) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        'permisos
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Rep_Servicios from Permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Alter table Permisos add column Rep_Servicios int(1) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Rep_CamPrecio from Permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Alter table Permisos add column Rep_CamPrecio int(1) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Rep_EstResultado FROM Permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Permisos ADD column Rep_EstResultado int(1) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Rep_Auditoria FROM Permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Permisos ADD column Rep_Auditoria int(1) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'ticket
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Cab7 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Alter table Ticket add column Cab7 varchar(255) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'compras
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Serie FROM comprasdet"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE comprasdet add column Serie varchar(80) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'mesa
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Impresion FROM mesa"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE mesa add column Impresion int(11) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try


        'mesa
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Color FROM usuarios"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE usuarios add column Color varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ''permisosm
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Mesas FROM permisosm"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE permisosm add column Mesas INT(1) default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'cartaporte
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PesoBrutoVehicular FROM cartaporte"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE cartaporte add column PesoBrutoVehicular varchar(100) default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'cartaporte1
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PesoBrutoVehicular FROM cartaportei"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE cartaportei add column PesoBrutoVehicular varchar(100) default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ''productos

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrecioVentaIVA2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PrecioVentaIVA2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        'Try
        '    cnn1.Close() : cnn1.Open()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "SELECT Mililitros,Copas FROM productos"
        '    rd1 = cmd1.ExecuteReader
        '    If rd1.Read Then
        '    End If
        '    rd1.Close() : cnn1.Close()
        'Catch ex As Exception
        '    rd1.Close()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column Mililitros float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column Copas float default '0'"
        '    cmd1.ExecuteNonQuery()
        '    cnn1.Close()
        'End Try

        'Try
        '    cnn1.Close() : cnn1.Open()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "SELECT CodBarra1,CodBarra2,CodBarra3,PrecioVenta2,PorcMin2,PreMin2,PorcMay2,PorcMM2,PorcEsp2,PreMay2,PreMM2,PreEsp2,CantMin3,CantMin4,CantMay3,CantMay4,CantMM3,CantMM4,CantEsp3,CantEsp4,CantLst3,CantLst4,Porcentaje2 FROM productos"
        '    rd1 = cmd1.ExecuteReader
        '    If rd1.Read Then
        '    End If
        '    rd1.Close() : cnn1.Close()
        'Catch ex As Exception
        '    rd1.Close()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CodBarra1 varchar(50) default ''"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CodBarra2 varchar(50) default ''"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CodBarra3 varchar(50) default ''"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PrecioVenta2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PorcMin2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PreMin2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PorcMay2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PorcMM2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PorcEsp2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PreMay2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PreMM2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column PreEsp2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantMin3 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantMin4 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantMay3 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantMay4 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantMM3 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantMM4 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantEsp3 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantEsp4 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantLst3 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CantLst4 float default '0'"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column CodBarra3 varchar(50) default ''"
        '    cmd1.ExecuteNonQuery()

        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = "ALTER TABLE productos add column Porcentaje2 float default '0'"
        '    cmd1.ExecuteNonQuery()

        'End Try

        'usuarios
        Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select P1,P2,P3 from Usuarios"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Alter table Usuarios add column P1 varchar(255)"
            cmd1.ExecuteNonQuery()
            cmd1.CommandText = "Alter table Usuarios add column P2 varchar(255)"
            cmd1.ExecuteNonQuery()
            cmd1.CommandText = "Alter table Usuarios add column P3 varchar(255)"
            cmd1.ExecuteNonQuery()
        End Try

        'clientes
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Observaciones FROM clientes"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE clientes add column Observaciones varchar(150) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'ventas
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Pedido FROM ventas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE ventas add column Pedido int default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
    End Sub

    Private Sub ActualizaCampos()
        Try
            cnn2.Close() : cnn2.Open()

            If Not TablaExiste(cnn2, "alumnos") Then
                Using command As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand(
                    "CREATE TABLE `alumnos` (
                    `Id` int(11) NOT NULL,
                    `Nombre` varchar(250) NOT NULL DEFAULT '',
                    `Matricula` varchar(100) NOT NULL DEFAULT '',
                    `Telefono` varchar(150) NOT NULL DEFAULT '',
                    `Tutor` varchar(250) NOT NULL DEFAULT '',
                    `Contacto` varchar(150) NOT NULL DEFAULT '',
                    `Calle` varchar(250) NOT NULL DEFAULT '',
                    `N_Int` varchar(100) NOT NULL DEFAULT '',
                    `N_Ext` varchar(100) NOT NULL DEFAULT '',
                    `Colonia` varchar(250) NOT NULL DEFAULT '',
                    `CP` varchar(20) DEFAULT NOT NUL DEFAULT '',
                    `Delegacion` varchar(250) DEFAULT '',
                    `Estado` varchar(250) DEFAULT '',
                    `Id_Grupo` int(11) DEFAULT '0',
                    `Grupo` varchar(250) DEFAULT '', 
                    `Lunes` int(11) DEFAULT '0', `Martes` int(11) DEFAULT '0', `Miercoles` int(11) DEFAULT '0', `Jueves` int(11) DEFAULT '0', `Viernes` int(11) DEFAULT '0', `Sabado` int(11) DEFAULT '0', `Domingo` int(11) DEFAULT '0',
                    `Inscripcion` DATE NOT NULL,
                    `F_Nacimiento` DATE NOT NULL,
                    `F_Inicio` DATE NOT NULL,
                    `Comentario` text NOT NULL,
                    `Curso` varchar(255) NOT NULL DEFAULT '',
                    `Baja` DATE NOT NULL,
                    `Status` INT(1) NOT NULL DEFAULT '0'
                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;", cnn2)
                    command.ExecuteNonQuery()
                End Using

                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `alumnos` ADD PRIMARY KEY (`Id`);", cnn2)
                    command2.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `alumnos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;", cnn2)
                    command2.ExecuteNonQuery()
                End Using
            End If


            If Not TablaExiste(cnn2, "control_servicios") Then
                Using command As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand(
                    "CREATE TABLE `control_servicios` (
                    `Id` int(11) NOT NULL,
                    `Codigo` varchar(250) NOT NULL DEFAULT '',
                    `Nombre` varchar(250) NOT NULL DEFAULT '',
                    `Folio` int(11) NOT NULL DEFAULT '0',
                    `Encargado` varchar(100) NOT NULL DEFAULT '',
                    `Inicio` date NOT NULL,
                    `Termino`date NOT NULL,
                    `Status` int(1) NOT NULL DEFAULT '0',
                    `Comentario` text NOT NULL,
                    `Usuario` varchar(100) NOT NULL DEFAULT '',
                    `Entregado` DATE NOT NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;", cnn2)
                    command.ExecuteNonQuery()
                End Using

                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `control_servicios` ADD PRIMARY KEY (`Id`);", cnn2)
                    command2.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `control_servicios` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;", cnn2)
                    command2.ExecuteNonQuery()
                End Using
            End If

            If Not TablaExiste(cnn2, "control_servicios_det") Then
                Using command As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand(
                    "CREATE TABLE `control_servicios_det` (
                    `Id` int(11) NOT NULL,
                    `Id_cs` int(11) NOT NULL DEFAULT '0',
                    `Proceso` varchar(250) NOT NULL DEFAULT '',
                    `Entrega`date NOT NULL,
                    `Status` int(1) NOT NULL DEFAULT '0',
                    `Comentario` text NOT NULL,
                    `Entregado` DATE NOT NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;", cnn2)
                    command.ExecuteNonQuery()
                End Using

                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `control_servicios_det` ADD PRIMARY KEY (`Id`);", cnn2)
                    command2.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `control_servicios_det` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;", cnn2)
                    command2.ExecuteNonQuery()
                End Using
            End If



            If Not TablaExiste(cnn2, "clientes") Then
                Using command As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand("CREATE TABLE IF NOT EXISTS `clientes` (
                                      `Id` int(11) NOT NULL,
                                      `Nombre` varchar(255) NOT NULL DEFAULT '',
                                      `RazonSocial` varchar(255) NOT NULL DEFAULT '',
                                      `Tipo` varchar(100) NOT NULL DEFAULT '',
                                      `RFC` varchar(50) NOT NULL DEFAULT '',
                                      `Telefono` varchar(100) NOT NULL DEFAULT '',
                                      `Correo` varchar(100) NOT NULL DEFAULT '',
                                      `Credito` float NOT NULL DEFAULT '0',
                                      `DiasCred` float NOT NULL DEFAULT '0',
                                      `Comisionista` varchar(255) NOT NULL DEFAULT '',
                                      `Suspender` int(1) NOT NULL DEFAULT '0',
                                      `Calle` varchar(255) NOT NULL DEFAULT '',
                                      `Colonia` varchar(250) NOT NULL DEFAULT '',
                                      `CP` varchar(50) NOT NULL DEFAULT '',
                                      `Delegacion` varchar(250) NOT NULL DEFAULT '',
                                      `Entidad` varchar(100) NOT NULL DEFAULT '',
                                      `Pais` varchar(100) NOT NULL DEFAULT '',
                                      `RegFis` varchar(255) NOT NULL DEFAULT '',
                                      `NInterior` varchar(50) NOT NULL DEFAULT '',
                                      `NExterior` varchar(50) NOT NULL DEFAULT '',
                                      `CargadoAndroid` int(1) NOT NULL DEFAULT '0',
                                      `Cargado` int(1) NOT NULL DEFAULT '0',
                                      `Template` longtext NOT NULL DEFAULT '',
                                      `SaldoFavor` float NOT NULL DEFAULT '0'
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;", cnn2)
                    command.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `clientes` ADD PRIMARY KEY (`Id`);", cnn2)
                    command2.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `clientes` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;", cnn2)
                    command2.ExecuteNonQuery()
                End Using
            End If

            If Not TablaExiste(cnn2, "grupos") Then
                Using commmand As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand("CREATE TABLE `grupos` (                                      
                                      `Id` int(11) NOT NULL,
                                      `Nombre` varchar(250) DEFAULT '',
                                      `Inicio` varchar(255) DEFAULT '',
                                      `Termino` varchar(250) DEFAULT '',
                                      `Cupo` float DEFAULT '0'                                    
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;", cnn2)
                    commmand.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `grupos` ADD PRIMARY KEY (`Id`);", cnn2)
                    command2.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `grupos` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;", cnn2)
                    command2.ExecuteNonQuery()
                End Using
            End If

            'LoginRecargas
            If Not TablaExiste(cnn2, "loginrecargas") Then
                Using command As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"CREATE TABLE IF NOT EXISTS `loginrecargas` (
                                                                                        `Id` int(11) NOT NULL,
                                                                                        `numero` varchar(255) NOT NULL DEFAULT '',
                                                                                        `usuario` varchar(255) NOT NULL DEFAULT '',
                                                                                        `password` varchar(255) NOT NULL DEFAULT ''
                                                                                        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;", cnn2)
                    command.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `loginrecargas` ADD PRIMARY KEY (`Id`);", cnn2)
                    command2.ExecuteNonQuery()
                End Using
                Using command2 As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand($"ALTER TABLE `loginrecargas` MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;", cnn2)
                    command2.ExecuteNonQuery()
                End Using
            End If


            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show($"Error al agregar la columna: {ex.Message}")
        End Try

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
        Dim FileSerie As String
        Dim SerieLib As String
        Dim SFile As String
        FileSerie = My.Computer.FileSystem.SpecialDirectories.Programs & "\ControlNegocios\Lib3r4c10n.dll"
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

    Private Sub ProducirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pProducir.Click
        frmProduccion.Show()
        frmProduccion.BringToFront()
    End Sub

    Private Sub NotasDeCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pNotasC.Click
        frmNotasCredito.Show()
        frmNotasCredito.BringToFront()
    End Sub

    Private Sub CapturaToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles pCaptura.Click
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Partes'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString() = 1 Then
                    frmComprasS.Show()
                    frmComprasS.BringToFront()
                Else
                    frmCompras.Show()
                    frmCompras.BringToFront()
                End If
            End If
        End If
        rd1.Close() : cnn1.Close()
    End Sub

    Private Sub btnProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnProductos.Click
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Partes'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString() = 1 Then
                    frmProductosSerie.Show()
                    frmProductosSerie.BringToFront()
                    Exit Sub
                Else
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select NumPart from Formatos where Facturas='Escuelas'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            If rd2(0).ToString() = 1 Then
                                frmProductos_Escuelas.Show()
                                frmProductos_Escuelas.BringToFront()
                                Exit Sub
                            End If
                        End If
                    Else
                        rd2.Close() : cnn2.Close()
                        frmProductos.Show()
                        frmProductos.BringToFront()
                        Exit Sub
                    End If
                    rd2.Close()
                    cnn2.Close()
                End If
            End If
        End If
        rd1.Close() : cnn1.Close()
    End Sub

    Private Sub btnClientes_Click(sender As System.Object, e As System.EventArgs) Handles btnClientes.Click
        frmClientes.Show()
        frmClientes.BringToFront()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim parte As Integer = 0
        Dim series As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Partes'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                parte = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "select NumPart from Formatos where Facturas='Series'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                series = rd1(0).ToString
            End If
        End If
        rd1.Close()

        If parte = 1 Then
            frmComprasS.Show()
            frmComprasS.BringToFront()
        ElseIf series = 1 Then
            frmComprasSeries.Show()
            frmComprasSeries.BringToFront()
        Else
            frmCompras.Show()
            frmCompras.BringToFront()
        End If


        cnn1.Close()
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
        'Dim partes As Integer = 0
        'Dim series As Integer = 0
        'Dim descuento As Integer = 0

        'cnn1.Close() : cnn1.Open()
        'cmd1 = cnn1.CreateCommand
        'cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Partes'"
        'rd1 = cmd1.ExecuteReader
        'If rd1.HasRows Then
        '    If rd1.Read Then
        '        partes = rd1(0).ToString
        '    End If
        'End If
        'rd1.Close()

        'cmd1 = cnn1.CreateCommand
        'cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Desc_Ventas'"
        'rd1 = cmd1.ExecuteReader
        'If rd1.HasRows Then
        '    If rd1.Read Then
        '        descuento = rd1(0).ToString
        '    End If
        'End If
        'rd1.Close()

        'cmd1 = cnn1.CreateCommand
        'cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Series'"
        'rd1 = cmd1.ExecuteReader
        'If rd1.HasRows Then
        '    If rd1.Read Then
        '        series = rd1(0).ToString
        '    End If
        'End If
        'rd1.Close()
        'cnn1.Close()

        'If partes = 1 Then
        '    frmVentas1_Partes.Show()
        '    frmVentas1_Partes.BringToFront()
        'ElseIf descuento Then
        '    frmVentas1_Descuentos.Show()
        '    frmVentas1_Descuentos.BringToFront()
        'ElseIf series Then
        '    frmVentas_Series.Show()
        '    frmVentas_Series.BringToFront()
        'Else
        '    frmVentas1.Show()
        '    frmVentas1.BringToFront()

        'End If
        frmVentas1.Show()
        frmVentas1.BringToFront()
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
        frmRepVentas.Show()
        frmRepVentas.BringToFront()
    End Sub

    Private Sub ReporteDeComprasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles pRepCompras.Click
        frmRepCompras.Show()
        frmRepCompras.BringToFront()
    End Sub

    Private Sub NóminaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmPagoNomina.Show()
        frmPagoNomina.BringToFront()
    End Sub

    Private Sub TransporteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)


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

        Try
            Dim DATO As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Series'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    DATO = rd1(0).ToString

                    If DATO = 1 Then
                        frmSeries.Show()
                        frmSeries.BringToFront()
                    Else
                        frmAjusteInv.Show()
                        frmAjusteInv.BringToFront()
                    End If

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception

        End Try


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

        Dim partes As Integer = 0
        Dim restaurante As Integer = 0
        Dim refaccionaria As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Partes'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                partes = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Restaurante'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                restaurante = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Refaccionaria'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                refaccionaria = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()


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

        Dim partes As Integer = 0
        Dim restaurante As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Partes'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                partes = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Restaurante'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                restaurante = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

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
        frmPedidos.Show()
        frmPedidos.BringToFront()
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

            Dim partes As Integer = 0
            Dim series As Integer = 0
            Dim descuento As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Partes'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    partes = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Desc_Ventas'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    descuento = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='Series'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    series = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If partes = 1 Then
                frmVentas1_Partes.Show()
                frmVentas1_Partes.BringToFront()
            ElseIf descuento Then
                frmVentas1_Descuentos.Show()
                frmVentas1_Descuentos.BringToFront()
            ElseIf series Then
                frmVentas_Series.Show()
                frmVentas_Series.BringToFront()
            Else
                frmVentas1.Show()
                frmVentas1.BringToFront()

            End If


            'cnn1.Close() : cnn1.Open()

            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText =
            '    "select NotasCred from Formatos where Facturas='Partes'"
            'rd1 = cmd1.ExecuteReader
            'If rd1.HasRows Then
            '    If rd1.Read Then
            '        If rd1(0).ToString() = "1" Then
            '            frmVentas1_Partes.Show()
            '            frmVentas1_Partes.BringToFront()
            '        Else
            '            rd1.Close()
            '            cnn1.Close()

            '            cnn2.Close() : cnn2.Open()
            '            cmd2 = cnn2.CreateCommand
            '            cmd2.CommandText =
            '                "select NotasCred from Formatos where Facturas='Desc_Ventas'"
            '            rd2 = cmd2.ExecuteReader
            '            If rd2.HasRows Then
            '                If rd2.Read Then
            '                    If rd2(0).ToString = "1" Then
            '                        rd2.Close() : cnn2.Close()

            '                        frmVentas1_Descuentos.Show()
            '                        frmVentas1_Descuentos.BringToFront()
            '                    Else
            '                        rd2.Close() : cnn2.Close()
            '                        frmVentas1.Show()
            '                        frmVentas1.BringToFront()
            '                    End If
            '                End If
            '            End If
            '            rd2.Close()
            '            cnn2.Close()
            '        End If
            '    End If
            'End If
            'rd1.Close() : cnn1.Close()
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
                "select * from Permisos where IdEmpleado=" & id_usuario
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
                    If rd5("Rep_Inv").ToString = True Then
                        pInventario.Enabled = True
                        P.R_Inventario = True
                    Else
                        pInventario.Enabled = False
                        P.R_Inventario = False
                        Inv += 1
                    End If
                    If rd5("Rep_Aju").ToString = True Then
                        pAjuste.Enabled = True
                        P.R_Ajuste = True
                    Else
                        pAjuste.Enabled = False
                        P.R_Ajuste = False
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
                    Else
                        pAdmin.Enabled = True
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
                End If
            End If
            rd5.Close()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select NotasCred from Formatos where Facturas='Mod_Prod'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    If rd5(0).ToString = "" Then
                        pMod_Produccion.Enabled = False
                    Else
                        pMod_Produccion.Enabled = True
                    End If
                End If
            End If
            rd5.Close()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select NotasCred from Formatos where Facturas='Mod_Comp'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    If rd5(0).ToString = "" Then
                        pMod_Precios.Enabled = False
                    Else
                        pMod_Precios.Enabled = True
                    End If
                End If
            End If
            rd5.Close()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select NotasCred from Formatos where Facturas='Mod_Asis'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    If rd5(0).ToString = "" Then
                        pAsistencia.Enabled = False
                    Else
                        pAsistencia.Enabled = True
                    End If
                End If
            End If
            rd5.Close()

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

    Private Sub btnSincronizador_Click(sender As System.Object, e As System.EventArgs) Handles btnSincronizador.Click
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

    Private Sub btnSincronizador_MouseEnter(sender As Object, e As System.EventArgs) Handles btnSincronizador.MouseEnter
        Label2.Visible = True
    End Sub

    Private Sub btnSincronizador_MouseLeave(sender As Object, e As System.EventArgs) Handles btnSincronizador.MouseLeave
        Label2.Visible = False
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
        frmRepVentas.Show()
        frmRepVentas.BringToFront()
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

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        frmMesas.Show()
        frmMesas.BringToFront()

        'frmMesero.Show()
        ' frmMesero.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
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
                        cmd2.CommandText = "SELECT * FROM Usuarios WHERE Clave='" & ClaveUsuario & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                frmVTouchR.lblAtendio.Text = rd2("Alias").ToString
                                frmVTouchR.txtUsuario.Text = rd2("Clave").ToString
                                frmVTouchR.Show()
                                frmVTouchR.BringToFront()
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()


                    Else
                        With frmVentaTouchT

                            frmVentaTouchT.Show()
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
        Dim dato As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Telefonia'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                dato = rd1(0).ToString

                If dato = 1 Then
                    frmTallerT.Show()
                Else
                    Exit Sub
                End If

            End If
        Else
            Exit Sub
        End If
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub btnRefaccionaria_Click(sender As Object, e As EventArgs) Handles btnRefaccionaria.Click
        Try
            Dim dato As Integer = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM Formatos WHERE Facturas='Refaccionaria'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    dato = rd1(0).ToString

                    If dato = 1 Then
                        frmMenuPrincipal.Show()
                    Else
                        Exit Sub
                    End If
                End If
            Else
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

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
        frmCorte2.Show()
        frmCorte2.BringToFront()
    End Sub



    Private Sub btnPagarComa_Click(sender As Object, e As EventArgs) Handles btnPagarComa.Click
        frmPagarComanda.Show()
        frmPagarComanda.BringToFront()
    End Sub

    Private Sub ReporteDeVentaDeAntibióticosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeVentaDeAntibióticosToolStripMenuItem.Click
        frmcofepris.Show()
        frmcofepris.BringToFront()
    End Sub

    Private Sub btnPagarComandas_Click(sender As Object, e As EventArgs) Handles btnPagarComandas.Click
        frmPagarComanda.Show()
        frmPagarComanda.BringToFront()
    End Sub
End Class