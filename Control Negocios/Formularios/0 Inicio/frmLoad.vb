Imports Core.DAL.DE
Imports MySql.Data

Public Class frmLoad

    Private Sub frmLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Login.Hide()
        ProgressBar1.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 2
        Label1.Text = ProgressBar1.Value & "% Cargado, Espere Por Favor ..."


        'Timer1.Enabled = True
    End Sub

    Public Sub cargaTodo()

        PrimeraConfig = ""
        Login.Hide()

        Label1.Text = "Cargando base de datos..."
        My.Application.DoEvents()

        verif()

        ProgressBar1.Value = 50
        Label1.Text = "Actualizando base de datos..."
        My.Application.DoEvents()

        Inicio.Permisos(id_usu_log)

        ProgressBar1.Value = 55
        Label1.Text = "Verificando datos..."
        My.Application.DoEvents()

        If varrutabase = "" Then
            ActualizaCampos()
        End If
        ProgressBar1.Value = 60
        Label1.Text = "Cargando Permisos de usuario..."
        My.Application.DoEvents()
        'Licencia()
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select numero,usuario,password from loginrecargas"
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

        If tienda_enlinea = True Then
            Inicio.Nuevos_Pedidos()
        End If
        SformatosInicio()

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()


        Dim tiendalinea As Integer = DatosRecarga2("TiendaLinea")

        Dim consignacion As Integer = DatosRecarga2("Consignacion")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Dim Mod_Asis As Integer = DatosRecarga2("Mod_Asis")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()
        Dim Control_Servicios As Integer = DatosRecarga2("Control_Servicios")
        Dim series As Integer = DatosRecarga2("Series")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()
        Dim produccion As Integer = DatosRecarga2("Produccion")
        Dim partes As Integer = DatosRecarga2("Partes")
        ProgressBar1.Value = ProgressBar1.Value + 1
        ProgressBar1.Value = 70
        My.Application.DoEvents()
        Dim escuelas As Integer = DatosRecarga2("Escuelas")
        Dim costeo As Integer = DatosRecarga2("Costeo")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()
        Dim restaurante As Integer = DatosRecarga2("Restaurante")
        Dim refaccionaria As Integer = DatosRecarga2("Refaccionaria")
        Dim pollos As Integer = DatosRecarga2("pollos")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Dim Migracion As Integer = DatosRecarga2("Migracion")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()
        Dim Mov_Cuenta As Integer = DatosRecarga2("Mov_Cuenta")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()
        Dim produccionpro As Integer = DatosRecarga2("ProduccionPro")
        Dim VentasRuta As Integer = DatosRecarga2("VentasRuta")
        ' Dim dentista As Integer = Await ValidarAsync("Dentista")
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()
        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()




        ProgressBar1.Value = ProgressBar1.Value + 1
        ProgressBar1.Value = 80
        My.Application.DoEvents()

        If tiendalinea = 1 Then
            Inicio.PedidosTiendaEnLíneaToolStripMenuItem.Visible = True
            Inicio.pedidos_tienda.Visible = True
        Else
            Inicio.PedidosTiendaEnLíneaToolStripMenuItem.Visible = False
            Inicio.pedidos_tienda.Visible = False
        End If



        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        If consignacion = 1 Then
            Inicio.menuconsignaciones.Visible = True
        Else
            Inicio.menuconsignaciones.Visible = False
        End If

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()


        If Mod_Asis = 1 Then
            Inicio.pAsistencia.Visible = True
        Else
            Inicio.pAsistencia.Visible = False
        End If

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        If Control_Servicios = 1 Then
            Inicio.ControlDeServiciosToolStripMenuItem.Visible = True
        Else
            Inicio.ControlDeServiciosToolStripMenuItem.Visible = False
        End If

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT Rep_Servicios FROM permisos WHERE IdEmpleado=" & id_usu_log
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                If rd2(0).ToString = 1 Then
                    If Control_Servicios = 1 Then
                        Inicio.ReporteDeControlDeServiciosToolStripMenuItem.Visible = True
                    Else
                        Inicio.ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
                    End If
                Else
                    Inicio.ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
                End If
            End If
        Else
            Inicio.ReporteDeControlDeServiciosToolStripMenuItem.Visible = False
        End If
        rd2.Close()
        cnn2.Close()
        My.Application.DoEvents()


        ProgressBar1.Value = ProgressBar1.Value + 1

        My.Application.DoEvents()

        If series = 1 Then
            Inicio.ReporteDeSeries.Visible = True
        Else
            Inicio.ReporteDeSeries.Visible = False
        End If

        If produccion = 1 Then
            Inicio.pMod_Produccion.Enabled = True
            Inicio.pMod_Produccion.Visible = True
            '  pControl_Procesos.Visible = False
        Else
            Inicio.pMod_Produccion.Enabled = False
            Inicio.pMod_Produccion.Visible = False
            'pControl_Procesos.Visible = False
        End If

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        If partes = 1 Then
            Inicio.pVentasT.Visible = False
            Inicio.ZapateríaToolStripMenuItem.Visible = False
            Inicio.pMod_Precios.Visible = False
            Inicio.pMod_Produccion.Visible = False
            Inicio.Button5.Visible = False
        End If

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        If escuelas = 1 Then
            Inicio.pClientes.Visible = False
            Inicio.pMonederos.Visible = False
            Inicio.GruposToolStripMenuItem.Visible = True
            Inicio.AlumnosToolStripMenuItem.Visible = True
            Inicio.InscripciónToolStripMenuItem.Visible = True
            Inicio.ZapateríaToolStripMenuItem.Visible = False
            Inicio.ProductosToolStripMenuItem.Visible = True
            Inicio.ComprasTouchToolStripMenuItem.Visible = False
            Inicio.AlumnosToolStripMenuItem1.Visible = True
            Inicio.pVentasT.Visible = False
            Inicio.pAbonosV.Visible = False
            Inicio.Button5.Visible = False
        End If

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        If costeo = 1 Then
        Else
            MsgBox("Por favor configura el método de costeo de tu inventario antes de comenzar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            PrimeraConfig = "1"
            frmConfigs.Show()
            frmConfigs.tabFuncionalidades1.Focus().Equals(True)
            frmConfigs.tabFuncionalidades1.Select()
            frmConfigs.TopMost = True
        End If


        ProgressBar1.Value = 90

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()





        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        If Migracion = 1 Then
            Inicio.pMigracion.Visible = True
        Else
            Inicio.pMigracion.Visible = False
        End If



        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        If Mov_Cuenta = 1 Then
            Inicio.ReporteMovCuentasToolStripMenuItem.Visible = True
            Inicio.MovCuentasToolStripMenuItem.Visible = True
        Else
            Inicio.ReporteMovCuentasToolStripMenuItem.Visible = False
            Inicio.MovCuentasToolStripMenuItem.Visible = False
        End If


        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        ''Validación de la aditoria

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
            cnn1.Close()

            ProgressBar1.Value = 100
            My.Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        Me.Hide()
        ProgressBar1.Value = 0
        Inicio.Show()
        My.Application.DoEvents()

    End Sub

    Public Sub verif()
        ' vartabladispositivos
        'Try
        '    cnn1.Close()
        '    cnn1.Open()
        '    cmd1 = cnn1.CreateCommand
        '    cmd1.CommandText = vartabladispositivos
        '    If cmd1.ExecuteNonQuery Then
        '    Else

        '    End If

        '    cnn1.Close()
        'Catch ex As Exception
        'End Try
        'trasladosdet
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Lote FROM trasladosdet"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE trasladosdet add column Lote varchar(150) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        'trasladosdet
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FCaduca FROM trasladosdet"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE trasladosdet add column FCaduca varchar(150) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        'departamentos
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cargado FROM Departamentos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Departamentos add column Cargado INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'grupo
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cargado FROM Grupo"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Grupo add column Cargado INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ' ventas detalle
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Antibiotico FROM VentasDetalle"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE VentasDetalle add column Antibiotico INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Controlado FROM VentasDetalle"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE VentasDetalle add column Controlado INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        ' productos
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Anti FROM Productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Productos add column Anti INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Caduca FROM Productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Productos add column Caduca INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrecioMaximoPublico FROM Productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Productos add column PrecioMaximoPublico double DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Laboratorio FROM Productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Productos add column Laboratorio varchar(255) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrincipioActivo FROM Productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Productos add column PrincipioActivo varchar(255) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Controlado FROM Productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Productos add column Controlado INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'trasladosdet
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Num_Traslado FROM trasladosdet"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE trasladosdet add column Num_Traslado INT DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comisionista FROM trasladosdet"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE trasladosdet add column Comisionista varchar(255) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'devoluciones
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comentario FROM devoluciones"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE devoluciones add column Comentario varchar(255) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'profesion
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Profesion FROM ctmedicos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE ctmedicos add column Profesion varchar(150) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'CEDULA
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cedula FROM usuarios"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE usuarios add column Cedula varchar(50) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'escuela
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Escuela FROM usuarios"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE usuarios add column Escuela varchar(255) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        'especialidad
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Especialidad FROM usuarios"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE usuarios add column Especialidad varchar(255) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'logor
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT LogoR FROM usuarios"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE usuarios add column LogoR varchar(50) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'hismesa
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FH FROM hismesa"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE hismesa add column FH datetime"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'hismesa
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FA FROM hismesa"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE hismesa add column FA datetime"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'ventas
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comision FROM ventas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE ventas add column Comision double DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'clientes
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumCliente FROM clientes"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE clientes add column NumCliente varchar(100) DEFAULT ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'PERMISOS
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT ReimprimirTicket FROM permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE permisos add column ReimprimirTicket int(1) NOT NULL DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Ad_Ruta FROM permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE permisos add column Ad_Ruta int(1) NOT NULL DEFAULT '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'pedidosvendet
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comentario FROM pedidosvendet"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE pedidosvendet add column Comentario varchar(255)"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'CotPedDet
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comentario FROM CotPedDet"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE CotPedDet add column Comentario varchar(255)"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'ventasdetalla
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FechaCompleta FROM ventasdetalle"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE ventasdetalle add column FechaCompleta datetime"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'abonoe
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FechaCompleta FROM abonoe"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoe add column FechaCompleta datetime"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'abonoi
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FechaCompleta FROM abonoi"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoi add column FechaCompleta datetime"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'productoeliminado
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Departamento FROM productoeliminado"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productoeliminado add column Departamento VARCHAR(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'clientes
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id_Tienda FROM clientes"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE clientes add column Id_Tienda INTEGER(11) default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'refaccionaria
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Motor FROM refaccionaria"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE refaccionaria add column Motor varchar(255) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        'vehiculo2
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Motor FROM vehiculo2"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE vehiculo2 add column Motor varchar(255) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try


        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'permisos
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Precio FROM miprod"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE miprod add column Precio double default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrecioIVA FROM miprod"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE miprod add column PrecioIVA double default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'permisos
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT EliAbono FROM permisos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE permisos add column EliAbono int(1) default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
        'abonoi
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Status FROM abonoi"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoi add column Status int default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'movcuenta
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cliente FROM movcuenta"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE movcuenta add column Cliente varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo FROM movcuenta"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE movcuenta add column Saldo double default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'saldosempleados
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FormaPago FROM saldosempleados"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE saldosempleados add column FormaPago varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Banco FROM saldosempleados"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE saldosempleados add column Banco varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Referencia FROM saldosempleados"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE saldosempleados add column Referencia varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comentario FROM saldosempleados"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE saldosempleados add column Comentario varchar(255) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cuenta FROM saldosempleados"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE saldosempleados add column Cuenta varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT BancoC FROM saldosempleados"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE saldosempleados add column BancoC varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        'OTROSGASTOS
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FormaPago FROM otrosgastos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE otrosgastos add column FormaPago varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Monto FROM otrosgastos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE otrosgastos add column Monto double default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Banco FROM otrosgastos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE otrosgastos add column Banco varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Referencia FROM otrosgastos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE otrosgastos add column Referencia varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comentario FROM otrosgastos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE otrosgastos add column Comentario varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CuentaC FROM otrosgastos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE otrosgastos add column CuentaC varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT BancoC FROM otrosgastos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE otrosgastos add column BancoC varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        'abonoe
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FormaPago FROM abonoe"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoe add column FormaPago varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Monto FROM abonoe"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoe add column Monto double default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Comentario FROM abonoe"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoe add column Comentario varchar(255) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CuentaRep FROM abonoe"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoe add column CuentaRep varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT BancoRep FROM abonoe"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoe add column BancoRep varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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
            cmd1.CommandText = "SELECT Parcialidad FROM abonoi"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE abonoi add column Parcialidad varchar(100) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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


        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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

        'MESASXEMPLEADOS
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Letra FROM mesasxempleados"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE mesasxempleados add column Letra VARCHAR(10) default ''"
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

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT T_Entrega FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column T_Entrega float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Resumen FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column Resumen varchar(250) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Descripcion_Tienda FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column Descripcion_Tienda text"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Actu FROM Productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column Actu Int(1) default 0"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Descripcion FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column Descripcion text default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Mililitros FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column Mililitros float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Copas FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column Copas float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CodBarra1 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CodBarra1 varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CodBarra2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CodBarra2 varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CodBarra3 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CodBarra3 varchar(50) default ''"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrecioVenta2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PrecioVenta2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PorcMin2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PorcMin2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PreMin2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PreMin2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PorcMay2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PorcMay2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PorcMM2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PorcMM2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PorcEsp2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PorcEsp2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PreMay2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PreMay2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PreMM2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PreMM2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PreEsp2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column PreEsp2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantMin3 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantMin3 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantMin4 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantMin4 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantMay3 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantMay3 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantMay4 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantMay4 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantMM3 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantMM3 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantMM4 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantMM4 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantEsp3 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantEsp3 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantEsp4 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantEsp4 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantLst3 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantLst3 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantLst4 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column CantLst4 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Porcentaje2 FROM productos"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE productos add column Porcentaje2 float default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

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

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

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
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Referencia FROM Clientes"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE Clientes add column Referencia varchar(255) default ''"
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

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Fecha FROM ventas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE ventas add column Fecha datetime"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Consignar FROM ventas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE ventas add column Consignar int default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        ProgressBar1.Value = ProgressBar1.Value + 1
        My.Application.DoEvents()

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT CantidadC FROM ventasdetalle"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE ventasdetalle add column CantidadC int default '0'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT FechaSal FROM asigpc"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            rd1.Close()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "ALTER TABLE asigpc add column FechaSal datetime"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End Try
    End Sub

    Public Sub ActualizaCampos()
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
End Class