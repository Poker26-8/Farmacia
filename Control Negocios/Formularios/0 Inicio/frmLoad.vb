Imports Core.DAL.DE
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmLoad
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ProgressBar1.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 2
        Label1.Text = ProgressBar1.Value & "% Cargado, Espere Por Favor ..."
        If (ProgressBar1.Value = 10) Then
            Label1.Text = "Cargando base de datos..."
        ElseIf (ProgressBar1.Value = 30) Then
            Label1.Text = "Actualizando base de datos..."
        ElseIf (ProgressBar1.Value = 60) Then
            Label1.Text = "Verificando datos..."
        ElseIf (ProgressBar1.Value = 80) Then
            cargaTodo()
            My.Application.DoEvents()
            Label1.Text = "Cargando Permisos de usuario..."
        ElseIf (ProgressBar1.Value = 100) Then

            Timer1.Enabled = False
            Me.Hide()
            ProgressBar1.Value = 0
            Inicio.Show()
            My.Application.DoEvents()
            '   Inicio.Text = "Delsscom Solutions® Control Negocios Pro" & Strings.Space(40) & FormatDateTime(Date.Now, DateFormat.ShortDate) & Strings.Space(50) & lblEmpresa.Text
        End If
    End Sub

    Private Sub frmLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Login.Hide()
        Timer1.Enabled = True
    End Sub

    Public Async Sub cargaTodo()
        PrimeraConfig = ""
        Login.Hide()

        ' Me.Show()
        My.Application.DoEvents()

        ' Await SformatosInicio()

        Inicio.verif()
        Inicio.Permisos(id_usu_log)
        If varrutabase = "" Then
            Inicio.ActualizaCampos()
        End If
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
        My.Application.DoEvents()

        Dim tiendalinea As Integer = DatosRecarga2("TiendaLinea")
        Dim gimnasios As Integer = DatosRecarga2("Gimnasio")
        Dim consignacion As Integer = DatosRecarga2("Consignacion")
        Dim nomina As Integer = DatosRecarga2("Nomina")
        Dim Mod_Asis As Integer = DatosRecarga2("Mod_Asis")
        Dim Control_Servicios As Integer = DatosRecarga2("Control_Servicios")
        Dim series As Integer = DatosRecarga2("Series")
        My.Application.DoEvents()
        Dim produccion As Integer = DatosRecarga2("Produccion")
        Dim partes As Integer = DatosRecarga2("Partes")
        Dim escuelas As Integer = DatosRecarga2("Escuelas")
        Dim costeo As Integer = DatosRecarga2("Costeo")
        Dim restaurante As Integer = DatosRecarga2("Restaurante")
        Dim refaccionaria As Integer = DatosRecarga2("Refaccionaria")
        Dim pollos As Integer = DatosRecarga2("pollos")
        My.Application.DoEvents()
        Dim telefonia As Integer = DatosRecarga2("Telefonia")
        Dim Hoteles As Integer = DatosRecarga2("Hoteles")
        Dim Migracion As Integer = DatosRecarga2("Migracion")
        Dim Optica As Integer = DatosRecarga2("Optica")
        Dim Mov_Cuenta As Integer = DatosRecarga2("Mov_Cuenta")
        Dim transportistas As Integer = DatosRecarga2("Transportistas")
        Dim produccionpro As Integer = DatosRecarga2("ProduccionPro")
        Dim dentista As Integer = DatosRecarga2("Dentista")
        ' Dim dentista As Integer = Await ValidarAsync("Dentista")
        My.Application.DoEvents()

        If dentista = 1 Then
            Inicio.btnDentista.Visible = True
        Else
            Inicio.btnDentista.Visible = False
        End If

        If produccionpro = 1 Then
            Inicio.TproduccionCos.Visible = True
        Else
            Inicio.TproduccionCos.Visible = False
        End If

        If tiendalinea = 1 Then
            Inicio.PedidosTiendaEnLíneaToolStripMenuItem.Visible = True
            Inicio.pedidos_tienda.Visible = True
        Else
            Inicio.PedidosTiendaEnLíneaToolStripMenuItem.Visible = False
            Inicio.pedidos_tienda.Visible = False
        End If

        If gimnasios = 1 Then
            Inicio.GimnasiosToolStripMenuItem.Visible = True
        Else
            Inicio.GimnasiosToolStripMenuItem.Visible = False
        End If

        If consignacion = 1 Then
            Inicio.menuconsignaciones.Visible = True
        Else
            Inicio.menuconsignaciones.Visible = False
        End If

        If nomina = 1 Then
            Inicio.NominaToolStripMenuItem.Visible = True
        Else
            Inicio.NominaToolStripMenuItem.Visible = False
        End If

        If Mod_Asis = 1 Then
            Inicio.pAsistencia.Visible = True
        Else
            Inicio.pAsistencia.Visible = False
        End If

        If Control_Servicios = 1 Then
            Inicio.ControlDeServiciosToolStripMenuItem.Visible = True
        Else
            Inicio.ControlDeServiciosToolStripMenuItem.Visible = False
        End If

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

        If partes = 1 Then
            Inicio.pVentasT.Visible = False
            Inicio.ZapateríaToolStripMenuItem.Visible = False
            Inicio.pMod_Precios.Visible = False
            Inicio.pMod_Produccion.Visible = False
            Inicio.Button5.Visible = False
        End If

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

        If costeo = 1 Then
        Else
            MsgBox("Por favor configura el método de costeo de tu inventario antes de comenzar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            PrimeraConfig = "1"
            frmConfigs.Show()
            frmConfigs.tabFuncionalidades1.Focus().Equals(True)
            frmConfigs.tabFuncionalidades1.Select()
            frmConfigs.TopMost = True
        End If

        If restaurante = 1 Then
            Inicio.Button12.Visible = True
            Inicio.btnPagarComandas.Visible = True
            Inicio.btnvtatouch.Visible = True
            Inicio.CORTEMESERO.Visible = True
            Inicio.pMod_Produccion.Visible = True
            Inicio.pMod_Produccion.Enabled = True
            frmPermisos.btnPermisosRestaurante.Visible = True
            Inicio.repHistorialMesas.Visible = True
        Else
            Inicio.Button12.Visible = False
            Inicio.btnPagarComandas.Visible = False
            Inicio.btnvtatouch.Visible = False
            Inicio.CORTEMESERO.Visible = False
            frmPermisos.btnPermisosRestaurante.Visible = False
            Inicio.repHistorialMesas.Visible = False
        End If

        If refaccionaria = 1 Then
            Inicio.btnRefaccionaria.Visible = True
        Else
            Inicio.btnRefaccionaria.Visible = False
        End If

        If pollos = 1 Then
            Inicio.btnpollo.Visible = True
        Else
            Inicio.btnpollo.Visible = False
        End If

        If telefonia = 1 Then
            Inicio.btnTelefonia.Visible = True
        Else
            Inicio.btnTelefonia.Visible = False
        End If

        If Hoteles = 1 Then
            Inicio.btnHoteleria.Visible = True
            Inicio.ReporteDeHotelToolStripMenuItem.Visible = True
        Else
            Inicio.btnHoteleria.Visible = False
            Inicio.ReporteDeHotelToolStripMenuItem.Visible = False
        End If

        If Migracion = 1 Then
            Inicio.pMigracion.Visible = True
        Else
            Inicio.pMigracion.Visible = False
        End If

        If Optica = 1 Then
            Inicio.btnOptica.Visible = True
        Else
            Inicio.btnOptica.Visible = False
        End If

        If Mov_Cuenta = 1 Then
            Inicio.ReporteMovCuentasToolStripMenuItem.Visible = True
            Inicio.MovCuentasToolStripMenuItem.Visible = True
        Else
            Inicio.ReporteMovCuentasToolStripMenuItem.Visible = False
            Inicio.MovCuentasToolStripMenuItem.Visible = False
        End If

        If transportistas = 1 Then
            Inicio.TransportistasToolStripMenuItem.Visible = True
        Else
            Inicio.TransportistasToolStripMenuItem.Visible = False
        End If

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

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        'Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        'Dim coma As OleDbCommand = New OleDbCommand
        'Dim lect As OleDbDataReader = Nothing

        'VieneDe_Compras = ""
        'VieneDe_Folios = ""

        '   Actualiza_Promos()
    End Sub
End Class