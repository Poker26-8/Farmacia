Public Class frmPermisos
    Public contraaa As String = ""
    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Nombre from Usuarios order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboNombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub cboNombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select IdEmpleado,Area,Puesto,Clave,Ingreso from Usuarios where Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblid_usu.Text = rd1("IdEmpleado").ToString
                    txtarea.Text = rd1("Area").ToString
                    txtpuesto.Text = rd1("Puesto").ToString
                    txtcontra.Text = rd1("Clave").ToString
                    txtingreso.Text = FormatDateTime(rd1("Ingreso").ToString, DateFormat.ShortDate)
                    contraaa = txtcontra.Text
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Cat_Emp,Cat_Cli,Cat_Prov,Cat_Mone,cat_Formas,cat_Bancos,cat_Cuentas,Asis_Hora,Asis_Hue,Asis_Asis,Asis_Rep,Prod_Prod,Prod_Serv,Prod_Pre,Prod_Prom,Prod_Kits,Comp_Ped,Comp_CPed,Comp_Com,Comp_CCom,Comp_NCred,Comp_CtPag,Comp_Abon,Comp_Anti,Vent_Most,Vent_Touch,Vent_NVen,Vent_Coti,Vent_Pedi,Vent_Devo,Vent_CFol,Vent_Abo,Vent_Canc,Vent_EPrec,Ing_CEmp,Egr_PEmp,Egr_Nom,Egr_Tran,Egr_Otro,Rep_Vent,Rep_VentG,Rep_Comp,Rep_CCob,Rep_CPag,Rep_Ent,Rep_Sal,Rep_Inv,Rep_Aju,List_Pre,List_Pro,List_Fal,Fact_Fact,Fact_Rep,Ad_Perm,Ad_Conf,Ad_Util,Ad_Cort,Ad_Cli,Rep_Servicios,Rep_CamPrecio,Rep_EstResultado,Rep_Auditoria,EliAbono,ReimprimirTicket,Ad_Ruta from Permisos where IdEmpleado=" & lblid_usu.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    'Catalogos
                    If rd1("Cat_Emp").ToString = True Then cat_Emp.Checked = True Else cat_Emp.Checked = False
                    If rd1("Cat_Cli").ToString = True Then cat_Cli.Checked = True Else cat_Cli.Checked = False
                    If rd1("Cat_Prov").ToString = True Then cat_Pro.Checked = True Else cat_Pro.Checked = False
                    If rd1("Cat_Mone").ToString = True Then cat_Mon.Checked = True Else cat_Mon.Checked = False
                    If rd1("cat_Formas").ToString = True Then cat_Formas.Checked = True Else cat_Formas.Checked = False
                    If rd1("cat_Bancos").ToString = True Then cat_Bancos.Checked = True Else cat_Bancos.Checked = False
                    If rd1("cat_Cuentas").ToString = True Then cat_cuentas.Checked = True Else cat_cuentas.Checked = False

                    'Asistencia
                    If rd1("Asis_Hora").ToString = True Then asis_Emp.Checked = True Else asis_Emp.Checked = False
                    If rd1("Asis_Hue").ToString = True Then asis_Hue.Checked = True Else asis_Hue.Checked = False
                    If rd1("Asis_Asis").ToString = True Then asis_Asi.Checked = True Else asis_Asi.Checked = False
                    If rd1("Asis_Rep").ToString = True Then asis_Rep.Checked = True Else asis_Rep.Checked = False

                    'Productos
                    If rd1("Prod_Prod").ToString = True Then prod_Pro.Checked = True Else prod_Pro.Checked = False
                    If rd1("Prod_Serv").ToString = True Then prod_Ser.Checked = True Else prod_Ser.Checked = False
                    If rd1("Prod_Pre").ToString = True Then prod_Pre.Checked = True Else prod_Pre.Checked = False
                    If rd1("Prod_Prom").ToString = True Then prod_Prom.Checked = True Else prod_Prom.Checked = False
                    If rd1("Prod_Kits").ToString = True Then prod_Kit.Checked = True Else prod_Kit.Checked = False

                    'Compras
                    If rd1("Comp_Ped").ToString = True Then com_Ped.Checked = True Else com_Ped.Checked = False
                    If rd1("Comp_CPed").ToString = True Then com_CPed.Checked = True Else com_CPed.Checked = False
                    If rd1("Comp_Com").ToString = True Then com_Com.Checked = True Else com_Com.Checked = False
                    If rd1("Comp_CCom").ToString = True Then com_CCom.Checked = True Else com_CCom.Checked = False
                    If rd1("Comp_NCred").ToString = True Then com_NCre.Checked = True Else com_NCre.Checked = False
                    If rd1("Comp_CtPag").ToString = True Then com_CPag.Checked = True Else com_CPag.Checked = False
                    If rd1("Comp_Abon").ToString = True Then com_ACom.Checked = True Else com_ACom.Checked = False
                    If rd1("Comp_Anti").ToString = True Then com_APro.Checked = True Else com_APro.Checked = False

                    'Ventas
                    If rd1("Vent_Most").ToString = True Then ven_Mos.Checked = True Else ven_Mos.Checked = False
                    If rd1("Vent_Touch").ToString = True Then ven_Tou.Checked = True Else ven_Tou.Checked = False
                    If rd1("Vent_NVen").ToString = True Then ven_Not.Checked = True Else ven_Not.Checked = False
                    If rd1("Vent_Coti").ToString = True Then ven_Cot.Checked = True Else ven_Cot.Checked = False
                    If rd1("Vent_Pedi").ToString = True Then ven_Ped.Checked = True Else ven_Ped.Checked = False
                    If rd1("Vent_Devo").ToString = True Then ven_Dev.Checked = True Else ven_Dev.Checked = False
                    If rd1("Vent_CFol").ToString = True Then ven_Fol.Checked = True Else ven_Fol.Checked = False
                    If rd1("Vent_Abo").ToString = True Then ven_Abo.Checked = True Else ven_Abo.Checked = False
                    If rd1("Vent_Canc").ToString = True Then ven_Can.Checked = True Else ven_Can.Checked = False
                    If rd1("Vent_EPrec").ToString = True Then ven_Edi.Checked = True Else ven_Edi.Checked = False

                    'Ingresos
                    If rd1("Ing_CEmp").ToString = True Then ing_Emp.Checked = True Else ing_Emp.Checked = False

                    'Egresos
                    If rd1("Egr_PEmp").ToString = True Then egr_Emp.Checked = True Else egr_Emp.Checked = False
                    If rd1("Egr_Nom").ToString = True Then egr_Nom.Checked = True Else egr_Nom.Checked = False
                    If rd1("Egr_Tran").ToString = True Then egr_Tra.Checked = True Else egr_Tra.Checked = False
                    If rd1("Egr_Otro").ToString = True Then egr_Gas.Checked = True Else egr_Gas.Checked = False

                    'Reportes
                    If rd1("Rep_Vent").ToString = True Then rep_Ven.Checked = True Else rep_Ven.Checked = False
                    If rd1("Rep_VentG").ToString = True Then rep_VenG.Checked = True Else rep_VenG.Checked = False
                    If rd1("Rep_Comp").ToString = True Then rep_Com.Checked = True Else rep_Com.Checked = False
                    If rd1("Rep_CCob").ToString = True Then rep_Cob.Checked = True Else rep_Cob.Checked = False
                    If rd1("Rep_CPag").ToString = True Then rep_Pag.Checked = True Else rep_Pag.Checked = False
                    If rd1("Rep_Ent").ToString = True Then rep_Ing.Checked = True Else rep_Ing.Checked = False
                    If rd1("Rep_Sal").ToString = True Then rep_Egr.Checked = True Else rep_Egr.Checked = False
                    If rd1("Rep_Inv").ToString = True Then rep_Inv.Checked = True Else rep_Inv.Checked = False
                    If rd1("Rep_Aju").ToString = True Then rep_Aju.Checked = True Else rep_Aju.Checked = False

                    'Listados
                    If rd1("List_Pre").ToString = True Then lis_Pre.Checked = True Else lis_Pre.Checked = False
                    If rd1("List_Pro").ToString = True Then lis_Pro.Checked = True Else lis_Pro.Checked = False
                    If rd1("List_Fal").ToString = True Then lis_Fal.Checked = True Else lis_Fal.Checked = False

                    'Facturación
                    If rd1("Fact_Fact").ToString = True Then fac_Fac.Checked = True Else fac_Fac.Checked = False
                    If rd1("Fact_Rep").ToString = True Then fac_Rep.Checked = True Else fac_Rep.Checked = False

                    'Administración
                    If rd1("Ad_Perm").ToString = True Then adm_Per.Checked = True Else adm_Per.Checked = False
                    If rd1("Ad_Conf").ToString = True Then adm_For.Checked = True Else adm_For.Checked = False
                    If rd1("Ad_Util").ToString = True Then adm_Uti.Checked = True Else adm_Uti.Checked = False
                    If rd1("Ad_Cort").ToString = True Then adm_Cor.Checked = True Else adm_Cor.Checked = False
                    If rd1("Ad_Ruta").ToString = True Then chkRuta.Checked = True Else chkRuta.Checked = False

                    If rd1("Ad_Cli").ToString = True Then cb_Add_Cli.Checked = True Else cb_Add_Cli.Checked = False

                    If rd1("Rep_Servicios").ToString = True Then cbserviciosrep.Checked = True Else cbserviciosrep.Checked = False

                    If rd1("Rep_CamPrecio").ToString = True Then cbCambioPrecios.Checked = True Else cbCambioPrecios.Checked = False

                    If rd1("Rep_EstResultado").ToString = True Then cbEstadoResultados.Checked = True Else cbEstadoResultados.Checked = False

                    If rd1("Rep_Auditoria").ToString = True Then cbAuditoria.Checked = True Else cbAuditoria.Checked = False

                    If rd1("EliAbono").ToString = True Then EliAbonos.Checked = True Else EliAbonos.Checked = False

                    If rd1("ReimprimirTicket").ToString = True Then cbReimprimir.Checked = True Else cbReimprimir.Checked = False

                End If
                Else
                cat_Emp.Checked = False
                cat_Cli.Checked = False
                cat_Pro.Checked = False
                cat_Mon.Checked = False

                asis_Emp.Checked = False
                asis_Hue.Checked = False
                asis_Asi.Checked = False
                asis_Rep.Checked = False

                prod_Pro.Checked = False
                prod_Ser.Checked = False
                prod_Pre.Checked = False
                prod_Prom.Checked = False
                prod_Kit.Checked = False

                com_Ped.Checked = False
                com_CPed.Checked = False
                com_Com.Checked = False
                com_CCom.Checked = False
                com_NCre.Checked = False
                com_CPag.Checked = False
                com_ACom.Checked = False
                com_APro.Checked = False

                ven_Mos.Checked = False
                ven_Tou.Checked = False
                ven_Not.Checked = False
                ven_Cot.Checked = False
                ven_Ped.Checked = False
                ven_Dev.Checked = False
                ven_Fol.Checked = False
                ven_Abo.Checked = False
                ven_Can.Checked = False
                ven_Edi.Checked = False

                ing_Emp.Checked = False

                egr_Emp.Checked = False
                egr_Nom.Checked = False
                egr_Tra.Checked = False
                egr_Gas.Checked = False

                rep_Ven.Checked = False
                rep_VenG.Checked = False
                rep_Com.Checked = False
                rep_Cob.Checked = False
                rep_Pag.Checked = False
                rep_Ing.Checked = False
                rep_Egr.Checked = False
                rep_Inv.Checked = False
                rep_Aju.Checked = False

                lis_Pre.Checked = False
                lis_Pro.Checked = False
                lis_Fal.Checked = False

                fac_Fac.Checked = False
                fac_Rep.Checked = False

                adm_Per.Checked = False
                adm_For.Checked = False
                adm_Uti.Checked = False
                adm_Cor.Checked = False
                cbserviciosrep.Checked = False
                cbCambioPrecios.Checked = False
                cbEstadoResultados.Checked = False
                cbAuditoria.Checked = False
                cb_Add_Cli.Checked = False
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Async Sub frmPermisos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cnn1.Close() : cnn1.Open()

        Dim limpiarventas As Integer = Await ValidarAsync("LimpiarV")

        If limpiarventas = 1 Then
            cbLimpiarV.Checked = True
        Else
            cbLimpiarV.Checked = False
        End If

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TomaContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = "1" Then
                    cbContraInicio.Checked = True
                Else
                    cbContraInicio.Checked = False
                End If
            End If
        End If
        rd1.Close()


        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='Modo'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = "CAJA" Then
                    optmostrador.Checked = True
                Else
                    optmostr_caja.Checked = True
                End If
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='CorteCiego'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = "1" Then
                    corte_ciego.Checked = True
                Else
                    corte_ciego.Checked = False
                End If
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='Audita'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = "1" Then
                    chkaudita.Checked = True
                Else
                    chkaudita.Checked = False
                End If
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NumPart from Formatos where Facturas='Restaurante'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = "1" Then
                    btnPermisosRestaurante.Visible = True
                Else
                    btnPermisosRestaurante.Visible = False
                End If
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select VSE from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If (rd1(0).ToString) Then
                    existencia_cero.Checked = True
                Else
                    existencia_cero.Checked = False
                End If
            End If
        End If
        rd1.Close()
        cnn1.Close()
    End Sub

    Private Sub frmPermisos_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboNombre.Focus().Equals(True)
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        contraaa = ""
        GroupBox3.Visible = False
        cboNombre.Items.Clear()
        cboNombre.Text = ""
        txtarea.Text = ""
        txtcontra.Text = ""
        txtpuesto.Text = ""
        txtingreso.Text = ""

        lblusuario.Text = ""
        txtcontraseña.Text = ""

        cat_Emp.Checked = False
        cat_Cli.Checked = False
        cat_Pro.Checked = False
        cat_Mon.Checked = False

        asis_Emp.Checked = False
        asis_Hue.Checked = False
        asis_Asi.Checked = False
        asis_Rep.Checked = False

        prod_Pro.Checked = False
        prod_Ser.Checked = False
        prod_Pre.Checked = False
        prod_Prom.Checked = False
        prod_Kit.Checked = False

        com_Ped.Checked = False
        com_CPed.Checked = False
        com_Com.Checked = False
        com_CCom.Checked = False
        com_NCre.Checked = False
        com_CPag.Checked = False
        com_ACom.Checked = False
        com_APro.Checked = False

        ven_Mos.Checked = False
        ven_Tou.Checked = False
        ven_Not.Checked = False
        ven_Cot.Checked = False
        ven_Ped.Checked = False
        ven_Dev.Checked = False
        ven_Fol.Checked = False
        ven_Abo.Checked = False
        ven_Can.Checked = False
        ven_Edi.Checked = False

        ing_Emp.Checked = False

        egr_Emp.Checked = False
        egr_Nom.Checked = False
        egr_Tra.Checked = False
        egr_Gas.Checked = False

        rep_Ven.Checked = False
        rep_VenG.Checked = False
        rep_Com.Checked = False
        rep_Cob.Checked = False
        rep_Pag.Checked = False
        rep_Ing.Checked = False
        rep_Egr.Checked = False
        rep_Inv.Checked = False
        rep_Aju.Checked = False

        lis_Pre.Checked = False
        lis_Pro.Checked = False
        lis_Fal.Checked = False

        fac_Fac.Checked = False
        fac_Rep.Checked = False

        adm_Per.Checked = False
        adm_For.Checked = False
        adm_Uti.Checked = False
        adm_Cor.Checked = False
        chkRuta.Checked = False

        cbserviciosrep.Checked = False
        cbCambioPrecios.Checked = False
        cbEstadoResultados.Checked = False
        cbAuditoria.Checked = False

        cb_Add_Cli.Checked = False

        EliAbonos.Checked = False

        cbReimprimir.Checked = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='Modo'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = "CAJA" Then
                    optmostrador.Checked = True
                Else
                    optmostr_caja.Checked = True
                End If
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='CorteCiego'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If rd1(0).ToString = "1" Then
                    corte_ciego.Checked = True
                Else
                    corte_ciego.Checked = False
                End If
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select VSE from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If (rd1(0).ToString) Then
                    existencia_cero.Checked = True
                Else
                    existencia_cero.Checked = False
                End If
            End If
        End If
        rd1.Close() : cnn1.Close()
    End Sub

    Private Sub lblcatalogos_Click(sender As System.Object, e As System.EventArgs) Handles lblcatalogos.Click
        Dim MyVal As Boolean = False
        If cat_Cli.Checked = True Then MyVal = False Else MyVal = True
        cat_Emp.Checked = MyVal
        cat_Cli.Checked = MyVal
        cat_Pro.Checked = MyVal
        cat_Mon.Checked = MyVal
        cat_Formas.Checked = MyVal
        cat_Bancos.Checked = MyVal
        cat_cuentas.Checked = MyVal
    End Sub

    Private Sub lblasistencia_Click(sender As System.Object, e As System.EventArgs) Handles lblasistencia.Click
        Dim MyVal As Boolean = False
        If asis_Emp.Checked = True Then MyVal = False Else MyVal = True
        asis_Emp.Checked = MyVal
        asis_Hue.Checked = MyVal
        asis_Asi.Checked = MyVal
        asis_Rep.Checked = MyVal
    End Sub

    Private Sub lblproductos_Click(sender As System.Object, e As System.EventArgs) Handles lblproductos.Click
        Dim MyVal As Boolean = False
        If prod_Pro.Checked = True Then MyVal = False Else MyVal = True
        prod_Pro.Checked = MyVal
        prod_Ser.Checked = MyVal
        prod_Pre.Checked = MyVal
        prod_Prom.Checked = MyVal
        prod_Kit.Checked = MyVal
    End Sub

    Private Sub lblcompras_Click(sender As System.Object, e As System.EventArgs) Handles lblcompras.Click
        Dim MyVal As Boolean = False
        If com_Ped.Checked = True Then MyVal = False Else MyVal = True
        com_Ped.Checked = MyVal
        com_CPed.Checked = MyVal
        com_Com.Checked = MyVal
        com_CCom.Checked = MyVal
        com_NCre.Checked = MyVal
        com_CPag.Checked = MyVal
        com_ACom.Checked = MyVal
        com_APro.Checked = MyVal
    End Sub

    Private Sub lblventas_Click(sender As System.Object, e As System.EventArgs) Handles lblventas.Click
        Dim MyVal As Boolean = False
        If ven_Mos.Checked = True Then MyVal = False Else MyVal = True
        ven_Mos.Checked = MyVal
        ven_Tou.Checked = MyVal
        ven_Not.Checked = MyVal
        ven_Cot.Checked = MyVal
        ven_Ped.Checked = MyVal
        ven_Dev.Checked = MyVal
        ven_Fol.Checked = MyVal
        ven_Abo.Checked = MyVal
        ven_Can.Checked = MyVal
        ven_Edi.Checked = MyVal
    End Sub

    Private Sub lblingresos_Click(sender As System.Object, e As System.EventArgs) Handles lblingresos.Click
        Dim MyVal As Boolean = False
        If ing_Emp.Checked = True Then MyVal = False Else MyVal = True
        ing_Emp.Checked = MyVal
        egr_Emp.Checked = MyVal
        egr_Nom.Checked = MyVal
        egr_Tra.Checked = MyVal
        egr_Gas.Checked = MyVal
    End Sub

    Private Sub lblegresos_Click(sender As System.Object, e As System.EventArgs)
        Dim MyVal As Boolean = False
        If egr_Emp.Checked = True Then MyVal = False Else MyVal = True
        egr_Emp.Checked = MyVal
        egr_Nom.Checked = MyVal
        egr_Tra.Checked = MyVal
        egr_Gas.Checked = MyVal
    End Sub

    Private Sub lblreportes_Click(sender As System.Object, e As System.EventArgs) Handles lblreportes.Click
        Dim MyVal As Boolean = False
        If rep_Ven.Checked = True Then MyVal = False Else MyVal = True
        rep_Ven.Checked = MyVal
        rep_VenG.Checked = MyVal
        rep_Com.Checked = MyVal
        rep_Cob.Checked = MyVal
        rep_Pag.Checked = MyVal
        rep_Ing.Checked = MyVal
        rep_Egr.Checked = MyVal
        rep_Inv.Checked = MyVal
        rep_Aju.Checked = MyVal
        cbserviciosrep.Checked = MyVal
        cbCambioPrecios.Checked = MyVal
        cbEstadoResultados.Checked = MyVal
        cbAuditoria.Checked = MyVal
    End Sub

    Private Sub lbllistados_Click(sender As System.Object, e As System.EventArgs) Handles lbllistados.Click
        Dim MyVal As Boolean = False
        If lis_Pre.Checked = True Then MyVal = False Else MyVal = True
        lis_Pre.Checked = MyVal
        lis_Pro.Checked = MyVal
        lis_Fal.Checked = MyVal
    End Sub

    Private Sub lblfactura_Click(sender As System.Object, e As System.EventArgs) Handles lblfactura.Click
        Dim MyVal As Boolean = False
        If fac_Fac.Checked = True Then MyVal = False Else MyVal = True
        fac_Fac.Checked = MyVal
        fac_Rep.Checked = MyVal
    End Sub

    Private Sub lbladmin_Click(sender As System.Object, e As System.EventArgs) Handles lbladmin.Click
        Dim MyVal As Boolean = False
        If adm_Per.Checked = True Then MyVal = False Else MyVal = True
        adm_Per.Checked = MyVal
        adm_For.Checked = MyVal
        adm_Uti.Checked = MyVal
        adm_Cor.Checked = MyVal
        chkRuta.Checked = MyVal
    End Sub

    Private Sub optmostrador_Click(sender As System.Object, e As System.EventArgs) Handles optmostrador.Click
        Dim Tipo As String = ""
        If (optmostrador.Checked) Then
            Tipo = "CAJA"
        Else
            Tipo = "MOSTRADOR"
        End If
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "update Formatos set NotasCred='" & Tipo & "' where Facturas='Modo'"
        cmd1.ExecuteNonQuery()
    End Sub

    Private Sub optmostr_caja_Click(sender As System.Object, e As System.EventArgs) Handles optmostr_caja.Click
        Dim Tipo As String = ""
        If (optmostr_caja.Checked) Then
            Tipo = "MOSTRADOR"
        Else
            Tipo = "CAJA"
        End If
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "update Formatos set NotasCred='" & Tipo & "' where Facturas='Modo'"
        cmd1.ExecuteNonQuery() : cnn1.Close()
    End Sub

    Private Sub existencia_cero_Click(sender As System.Object, e As System.EventArgs) Handles existencia_cero.Click
        If (existencia_cero.Checked) Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Ticket set VSE=1"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        Else
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Ticket set VSE=0"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        End If
    End Sub

    Private Sub corte_ciego_Click(sender As System.Object, e As System.EventArgs) Handles corte_ciego.Click
        If (corte_ciego.Checked) Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Formatos set NotasCred='1' where Facturas='CorteCiego'"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        Else
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Formatos set NotasCred='0' where Facturas='CorteCiego'"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        End If
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        If cboNombre.Text = "" Then MsgBox("Selecciona un usuario para poder asignarle permisos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If txtcontra.Text = "" Then MsgBox("Asígnale una contraseña al usuario para continuar.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : txtcontra.Focus().Equals(True) : Exit Sub
        If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas registrar los permisos de este empleado?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then


            Dim id_emp As Double = 0
            Try
                cnn1.Close() : cnn1.Open()

                Dim usu_edita As Integer = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select IdEmpleado from Usuarios where Alias='" & lblusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        usu_edita = rd1(0).ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Ad_Perm from Permisos where IdEmpleado=" & usu_edita
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Ad_Perm").ToString() = 0 Then
                            MsgBox("No cuentas con permiso para realizar la edición de permisos de usuario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd1.Close() : cnn1.Close()
                            Exit Sub
                        End If
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select IdEmpleado from Usuarios where Clave='" & txtcontra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("IdEmpleado").ToString = lblid_usu.Text Then
                        Else
                            MsgBox("Ya cuentas con un usuario registrado bajo esa contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            rd1.Close() : cnn1.Close()
                            txtcontra.SelectAll()
                            Exit Sub
                        End If
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select IdEmpleado from Usuarios where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_emp = rd1("IdEmpleado").ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Id from Permisos where IdEmpleado=" & id_emp
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'Update
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Permisos set Cat_Emp=" & IIf(cat_Emp.Checked = True, 1, 0) & ", Cat_Cli=" & IIf(cat_Cli.Checked = True, 1, 0) & ", Cat_Prov=" & IIf(cat_Pro.Checked = True, 1, 0) & ", Cat_Mone=" & IIf(cat_Mon.Checked = True, 1, 0) & ", Asis_Hora=" & IIf(asis_Emp.Checked = True, 1, 0) & ", Asis_Hue=" & IIf(asis_Hue.Checked = True, 1, 0) & ", Asis_Asis=" & IIf(asis_Asi.Checked = True, 1, 0) & ", Asis_Rep=" & IIf(asis_Rep.Checked = True, 1, 0) & ", Prod_Prod=" & IIf(prod_Pro.Checked = True, 1, 0) & ", Prod_Serv=" & IIf(prod_Ser.Checked = True, 1, 0) & ", Prod_Pre=" & IIf(prod_Pre.Checked = True, 1, 0) & ", Prod_Prom=" & IIf(prod_Prom.Checked = True, 1, 0) & ", Prod_Kits=" & IIf(prod_Kit.Checked = True, 1, 0) & ", Comp_Ped=" & IIf(com_Ped.Checked = True, 1, 0) & ", Comp_CPed=" & IIf(com_CPed.Checked = True, 1, 0) & ", Comp_Com=" & IIf(com_Com.Checked = True, 1, 0) & ", Comp_CCom=" & IIf(com_CCom.Checked = True, 1, 0) & ", Comp_NCred=" & IIf(com_NCre.Checked = True, 1, 0) & ", Comp_CtPag=" & IIf(com_CPag.Checked = True, 1, 0) & ", Comp_Abon=" & IIf(com_ACom.Checked = True, 1, 0) & ", Comp_Anti=" & IIf(com_APro.Checked = True, 1, 0) & ", Vent_Most=" & IIf(ven_Mos.Checked = True, 1, 0) & ", Vent_Touch=" & IIf(ven_Tou.Checked = True, 1, 0) & ", Vent_NVen=" & IIf(ven_Not.Checked = True, 1, 0) & ", Vent_Coti=" & IIf(ven_Cot.Checked = True, 1, 0) & ", Vent_Pedi=" & IIf(ven_Ped.Checked = True, 1, 0) & ", Vent_Devo=" & IIf(ven_Dev.Checked = True, 1, 0) & ", Vent_CFol=" & IIf(ven_Fol.Checked = True, 1, 0) & ", Vent_Abo=" & IIf(ven_Abo.Checked = True, 1, 0) & ", Vent_Canc=" & IIf(ven_Can.Checked = True, 1, 0) & ", Vent_EPrec=" & IIf(ven_Edi.Checked = True, 1, 0) & ", Ing_CEmp=" & IIf(ing_Emp.Checked = True, 1, 0) & ", Egr_PEmp=" & IIf(egr_Emp.Checked = True, 1, 0) & ", Egr_Nom=" & IIf(egr_Nom.Checked = True, 1, 0) & ", Egr_Tran=" & IIf(egr_Tra.Checked = True, 1, 0) & ", Egr_Otro=" & IIf(egr_Gas.Checked = True, 1, 0) & ", Rep_Vent=" & IIf(rep_Ven.Checked = True, 1, 0) & ", Rep_VentG=" & IIf(rep_VenG.Checked = True, 1, 0) & ", Rep_Comp=" & IIf(rep_Com.Checked = True, 1, 0) & ", Rep_CCob=" & IIf(rep_Cob.Checked = True, 1, 0) & ", Rep_CPag=" & IIf(rep_Pag.Checked = True, 1, 0) & ", Rep_Ent=" & IIf(rep_Ing.Checked = True, 1, 0) & ", Rep_Sal=" & IIf(rep_Egr.Checked = True, 1, 0) & ", Rep_Inv=" & IIf(rep_Inv.Checked = True, 1, 0) & ", Rep_Aju=" & IIf(rep_Aju.Checked = True, 1, 0) & ", List_Pre=" & IIf(lis_Pre.Checked = True, 1, 0) & ", List_Pro=" & IIf(lis_Pro.Checked = True, 1, 0) & ", List_Fal=" & IIf(lis_Fal.Checked = True, 1, 0) & ", Fact_Fact=" & IIf(fac_Fac.Checked = True, 1, 0) & ", Fact_Rep=" & IIf(fac_Rep.Checked = True, 1, 0) & ", Ad_Perm=" & IIf(adm_Per.Checked = True, 1, 0) & ", Ad_Conf=" & IIf(adm_For.Checked = True, 1, 0) & ", Ad_Util=" & IIf(adm_Uti.Checked = True, 1, 0) & ", Ad_Cort=" & IIf(adm_Cor.Checked = True, 1, 0) & ",Ad_Cli=" & IIf(cb_Add_Cli.Checked = True, 1, 0) & ",Rep_Servicios=" & IIf(cbserviciosrep.Checked = True, 1, 0) & ",Rep_CamPrecio=" & IIf(cbCambioPrecios.Checked = True, 1, 0) & ",Rep_EstResultado=" & IIf(cbEstadoResultados.Checked = True, 1, 0) & ",Rep_Auditoria=" & IIf(cbAuditoria.Checked = True, 1, 0) & ",cat_Formas=" & IIf(cat_Formas.Checked = True, 1, 0) & ",cat_Bancos=" & IIf(cat_Bancos.Checked = True, 1, 0) & ",cat_Cuentas=" & IIf(cat_cuentas.Checked = True, 1, 0) & ",EliAbono=" & IIf(EliAbonos.Checked = True, 1, 0) & ",ReimprimirTicket=" & IIf(cbReimprimir.Checked = True, 1, 0) & ",Ad_Ruta=" & IIf(chkRuta.Checked = True, 1, 0) & " where IdEmpleado=" & id_emp
                        If cmd2.ExecuteNonQuery() Then
                            MsgBox("Permisos actualizados correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                        End If

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update Usuarios set Clave='" & txtcontra.Text & "' where IdEmpleado=" & lblid_usu.Text
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                Else
                    'Insert
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into Permisos(IdEmpleado,Cat_Emp,Cat_Cli,Cat_Prov,Cat_Mone,Asis_Hora,Asis_Hue,Asis_Asis,Asis_Rep,Prod_Prod,Prod_Serv,Prod_Pre,Prod_Prom,Prod_Kits,Comp_Ped,Comp_CPed,Comp_Com,Comp_CCom,Comp_NCred,Comp_CtPag,Comp_Abon,Comp_Anti,Vent_Most,Vent_Touch,Vent_NVen,Vent_Coti,Vent_Pedi,Vent_Devo,Vent_CFol,Vent_Abo,Vent_Canc,Vent_EPrec,Ing_CEmp,Egr_PEmp,Egr_Nom,Egr_Tran,Egr_Otro,Rep_Vent,Rep_VentG,Rep_Comp,Rep_CCob,Rep_CPag,Rep_Ent,Rep_Sal,Rep_Inv,Rep_Aju,List_Pre,List_Pro,List_Fal,Fact_Fact,Fact_Rep,Ad_Perm,Ad_Conf,Ad_Util,Ad_Cort,Ad_Cli,Rep_Servicios,Rep_CamPrecio,Rep_EstResultado,Rep_Auditoria,cat_Formas,cat_Bancos,cat_Cuentas,EliAbono,ReimprimirTicket,Ad_Ruta) values(" & id_emp & "," & IIf(cat_Emp.Checked = True, 1, 0) & "," & IIf(cat_Cli.Checked = True, 1, 0) & "," & IIf(cat_Pro.Checked = True, 1, 0) & "," & IIf(cat_Mon.Checked = True, 1, 0) & "," & IIf(asis_Emp.Checked = True, 1, 0) & "," & IIf(asis_Hue.Checked = True, 1, 0) & "," & IIf(asis_Asi.Checked = True, 1, 0) & "," & IIf(asis_Rep.Checked = True, 1, 0) & "," & IIf(prod_Pro.Checked = True, 1, 0) & "," & IIf(prod_Ser.Checked = True, 1, 0) & "," & IIf(prod_Pre.Checked = True, 1, 0) & "," & IIf(prod_Prom.Checked = True, 1, 0) & "," & IIf(prod_Kit.Checked = True, 1, 0) & "," & IIf(com_Ped.Checked = True, 1, 0) & "," & IIf(com_CPed.Checked = True, 1, 0) & "," & IIf(com_Com.Checked = True, 1, 0) & "," & IIf(com_CCom.Checked = True, 1, 0) & "," & IIf(com_NCre.Checked = True, 1, 0) & "," & IIf(com_CPag.Checked = True, 1, 0) & "," & IIf(com_ACom.Checked = True, 1, 0) & "," & IIf(com_APro.Checked = True, 1, 0) & "," & IIf(ven_Mos.Checked = True, 1, 0) & "," & IIf(ven_Tou.Checked = True, 1, 0) & "," & IIf(ven_Not.Checked = True, 1, 0) & "," & IIf(ven_Cot.Checked = True, 1, 0) & "," & IIf(ven_Ped.Checked = True, 1, 0) & "," & IIf(ven_Dev.Checked = True, 1, 0) & "," & IIf(ven_Fol.Checked = True, 1, 0) & "," & IIf(ven_Abo.Checked = True, 1, 0) & "," & IIf(ven_Can.Checked = True, 1, 0) & "," & IIf(ven_Edi.Checked = True, 1, 0) & "," & IIf(ing_Emp.Checked = True, 1, 0) & "," & IIf(egr_Emp.Checked = True, 1, 0) & "," & IIf(egr_Nom.Checked = True, 1, 0) & "," & IIf(egr_Tra.Checked = True, 1, 0) & "," & IIf(egr_Gas.Checked = True, 1, 0) & "," & IIf(rep_Ven.Checked = True, 1, 0) & "," & IIf(rep_VenG.Checked = True, 1, 0) & "," & IIf(rep_Com.Checked = True, 1, 0) & "," & IIf(rep_Cob.Checked = True, 1, 0) & "," & IIf(rep_Pag.Checked = True, 1, 0) & "," & IIf(rep_Ing.Checked = True, 1, 0) & "," & IIf(rep_Egr.Checked = True, 1, 0) & "," & IIf(rep_Inv.Checked = True, 1, 0) & "," & IIf(rep_Aju.Checked = True, 1, 0) & "," & IIf(lis_Pre.Checked = True, 1, 0) & "," & IIf(lis_Pro.Checked = True, 1, 0) & "," & IIf(lis_Fal.Checked = True, 1, 0) & "," & IIf(fac_Fac.Checked = True, 1, 0) & "," & IIf(fac_Rep.Checked = True, 1, 0) & "," & IIf(adm_Per.Checked = True, 1, 0) & "," & IIf(adm_For.Checked = True, 1, 0) & "," & IIf(adm_Uti.Checked = True, 1, 0) & "," & IIf(adm_Cor.Checked = True, 1, 0) & "," & IIf(cb_Add_Cli.Checked = True, 1, 0) & "," & IIf(cbserviciosrep.Checked = True, 1, 0) & ",
                          " & IIf(cbCambioPrecios.Checked = True, 1, 0) & "," & IIf(cbEstadoResultados.Checked = True, 1, 0) & "," & IIf(cbAuditoria.Checked = True, 1, 0) & "," & IIf(cat_Formas.Checked = True, 1, 0) & "," & IIf(cat_Bancos.Checked = True, 1, 0) & "," & IIf(cat_cuentas.Checked = True, 1, 0) & "," & IIf(EliAbonos.Checked = True, 1, 0) & "," & IIf(cbReimprimir.Checked = True, 1, 0) & "," & IIf(chkRuta.Checked = True, 1, 0) & ")"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Permisos insertados correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                    End If
                    cnn2.Close()

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Usuarios SET Clave='" & txtcontra.Text & "' WHERE IdEmpleado=" & lblid_usu.Text
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
                rd1.Close() : cnn1.Close()
                If txtcontra.Text = contraaa Then
                    btnnuevo.PerformClick()
                Else
                    GroupBox3.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub chkaudita_Click(sender As System.Object, e As System.EventArgs) Handles chkaudita.Click
        If (chkaudita.Checked) Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Formatos set NotasCred='1' where Facturas='Audita'"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        Else
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Formatos set NotasCred='1' where Facturas='Audita'"
            cmd1.ExecuteNonQuery() : cnn1.Close()
        End If
    End Sub

    Private Sub Label12_MouseHover(sender As Object, e As EventArgs) Handles Label12.MouseHover
        txtcontra.PasswordChar = ""
    End Sub

    Private Sub Label12_MouseLeave(sender As Object, e As EventArgs) Handles Label12.MouseLeave
        txtcontra.PasswordChar = "*"
    End Sub

    Private Sub txtcontraseña_Click(sender As Object, e As EventArgs) Handles txtcontraseña.Click
        txtcontraseña.SelectionStart = 0
        txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
    End Sub

    Private Sub txtcontraseña_GotFocus(sender As Object, e As EventArgs) Handles txtcontraseña.GotFocus
        txtcontraseña.SelectionStart = 0
        txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcontraseña.Text <> "" Then
                Dim id_empleado As Integer = 0

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IdEmpleado,Alias from Usuarios where Clave='" & txtcontraseña.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            id_empleado = rd1("IdEmpleado").ToString()
                            lblusuario.Text = rd1("Alias").ToString()
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Ad_Perm from Permisos where IdEmpleado=" & id_empleado
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If rd1("Ad_Perm").ToString() = True Then
                                btnguardar.Focus().Equals(True)
                            Else
                                MsgBox("No cuentas con permisos suficientes para interactuar con este formulario.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                rd1.Close() : cnn1.Close() : Exit Sub
                            End If
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If
            btnguardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btneliminacat_Click(sender As Object, e As EventArgs) Handles btneliminacat.Click
        Try

            If MsgBox("¿Desea eliminar el catálogo de productos?, Una vez realizado el proceso no se puede cancelar", vbQuestion + vbYesNo) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "DELETE FROM Productos"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Catálogo de productos eliminado correctamente", vbInformation + vbOKOnly, "Control® Negocios Pro")
                    cnn1.Close()
                End If


            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btneliminainven_Click(sender As Object, e As EventArgs) Handles btneliminainven.Click
        Try

            If MsgBox("Se colocara la existencia en 0 de todos los productos, Esta seguro de la accion", vbQuestion + vbYesNo) = vbYes Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Productos SET Existencia='0'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Existencias actualizadas en 0 correctamente", vbInformation + vbOKOnly, "Control® Negocios Pro")
                    cnn1.Close()
                End If


            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbContraInicio_Click(sender As Object, e As EventArgs) Handles cbContraInicio.Click


        Dim selecicon As Integer = 0
        If (cbContraInicio.Checked) Then
            selecicon = 1
        Else
            selecicon = 0
        End If


        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TomaContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Formatos SET NotasCred=" & selecicon & ",NumPart=" & selecicon & " WHERE Facturas='TomaContra'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            Else

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO Formatos(Facturas,NotasCred,NumPart) VALUES('TomaContra','0','0')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()

            End If
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Update usuarios set P1='" & txt1.Text & "', P2='" & txt2.Text & "', P3='" & txt3.Text & "' where IdEMpleado=" & lblid_usu.Text & ""
            If cmd1.ExecuteNonQuery Then
                MsgBox("Respuestas de seguridad guardadas correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios PRO")
            End If
            cnn1.Close()
            GroupBox3.Visible = False
            btnnuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnPermisosRestaurante.Click
        frmPermisosRestaurant.Show()
        frmPermisosRestaurant.BringToFront()
    End Sub

    Private Sub cbLimpiarV_Click(sender As Object, e As EventArgs) Handles cbLimpiarV.Click
        Try
            Dim limpiarv As Integer = 0

            If (cbLimpiarV.Checked) Then
                limpiarv = 1
            Else
                limpiarv = 0
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM formatos WHERE Facturas='LimpiarV'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE formatos SET NotasCred='0',NumPart='" & limpiarv & "' WHERE Facturas='LimpiarV'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO formatos(Facturas,NotasCred,NumPart) VALUES('LimpiarV','0','" & limpiarv & "')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class