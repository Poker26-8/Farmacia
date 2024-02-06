Public Class frmCambioPrecio

    Private Sub frmCambioPrecio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbo.Items.Clear()
        cbo.Text = ""
        cbo3Op.Items.Clear()
        cbo3Op.Text = ""
        optprov_m.Checked = True
    End Sub

    Private Sub frmCambioPrecio_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cbo.Focus().Equals(True)
    End Sub

    Private Sub cbo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbo.DropDown
        Try
            Dim sql As String = ""
            cbo.Items.Clear()
            If (optprove.Checked) Then
                sql = "SELECT DISTINCT ProvPri FROM Productos order by ProvPri"
            End If
            If (optdepar.Checked) Then
                sql = "SELECT DISTINCT Departamento FROM Productos order by Departamento"
            End If
            If (optgrupo.Checked) Then
                sql = "SELECT DISTINCT Grupo FROM Productos order by Grupo"
            End If

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                sql
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbo.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub optprove_Click(sender As System.Object, e As System.EventArgs) Handles optprove.Click
        If (optprove.Checked) Then
            cbo.Items.Clear()
            cbo.Text = ""
            optcompra.Checked = False
            optventa.Checked = False
            optaumento.Checked = False
            optdiminuye.Checked = False
            txtpor.Text = "0"
        End If
    End Sub

    Private Sub optdepar_Click(sender As System.Object, e As System.EventArgs) Handles optdepar.Click
        If (optdepar.Checked) Then
            cbo.Items.Clear()
            cbo.Text = ""
            optcompra.Checked = False
            optventa.Checked = False
            optaumento.Checked = False
            optdiminuye.Checked = False
            txtpor.Text = "0"
        End If
    End Sub

    Private Sub optgrupo_Click(sender As System.Object, e As System.EventArgs) Handles optgrupo.Click
        If (optgrupo.Checked) Then
            cbo.Items.Clear()
            cbo.Text = ""
            optcompra.Checked = False
            optventa.Checked = False
            optaumento.Checked = False
            optdiminuye.Checked = False
            txtpor.Text = "0"
        End If
    End Sub

    Private Sub txtpor_Click(sender As System.Object, e As System.EventArgs) Handles txtpor.Click
        txtpor.SelectionStart = 0
        txtpor.SelectionLength = Len(txtpor.Text)
    End Sub

    Private Sub txtpor_GotFocus(sender As Object, e As System.EventArgs) Handles txtpor.GotFocus
        txtpor.SelectionStart = 0
        txtpor.SelectionLength = Len(txtpor.Text)
    End Sub

    Private Sub cbo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtpor.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtpor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cbo.Text = "" Then MsgBox("Selecciona una opción de filtro para el cambio de precio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo.Focus().Equals(True) : Exit Sub
        If Not (optventa.Checked) And Not (optcompra.Checked) Then MsgBox("Selecciona el tipo de precio que deseas ajustar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
        If Not (optaumento.Checked) And Not (optdiminuye.Checked) Then MsgBox("Selecciona el tipo de movimiento para el precio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

        Try
            Dim movi As String = "", precio As String = "", subebaja As String = ""
            If (optprove.Checked) Then movi = "Proveedor"
            If (optdepar.Checked) Then movi = "Departamento"
            If (optgrupo.Checked) Then movi = "Grupo"

            If (optcompra.Checked) Then precio = "compra"
            If (optventa.Checked) Then precio = "venta"

            If (optaumento.Checked) Then subebaja = "Aumenta"
            If (optdiminuye.Checked) Then subebaja = "Disminuye"

            If MsgBox("¿Deseas continuar con el proceso y modificar todos los precios?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                Dim porcentaje As Double = CDbl(txtpor.Text) / 100

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into ModPrecios(Codigo,Nombre,Tipo,Anterior,Nuevo,Fecha,Hora,Usuario) values('" & UCase(subebaja) & "','" & cbo.Text & "','Precio de " & precio & " de " & movi & "',0," & CDbl(txtpor.Text) & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & id_usu_log & "')"
                cmd1.ExecuteNonQuery()

                If movi = "Proveedor" Then movi = "ProvPri"
                '-----[AUMENTO]
                If (optaumento.Checked) Then
                    'Aumenta el precio de compra
                    If (optcompra.Checked) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PrecioCompra=PrecioCompra + (PrecioCompra*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                    End If

                    'Aumenta los precios de venta
                    If (optventa.Checked) Then
                        'PrecioVenta
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PrecioVenta=PrecioVenta + (PrecioVenta*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PrecioVentaIVA
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PrecioVentaIVA=PrecioVentaIVA + (PrecioVentaIVA*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreMin
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMin=PreMin + (PreMin*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreMay
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMay=PreMay + (PreMay*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreMM
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMM=PreMM + (PreMM*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreEsp
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreEsp=PreEsp + (PreEsp*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                    End If
                End If

                '-----[DISMINUYE]
                If (optdiminuye.Checked) Then
                    'Disminuye el precio de compra
                    If (optcompra.Checked) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PrecioCompra=PrecioCompra - (PrecioCompra*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                    End If
                    'Disminuye los precios de compra
                    If (optventa.Checked) Then
                        'PrecioVenta
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PrecioVenta=PrecioVenta - (PrecioVenta*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PrecioVentaIVA
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PrecioVentaIVA=PrecioVentaIVA - (PrecioVentaIVA*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreMin
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMin=PreMin - (PreMin*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreMay
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMay=PreMay - (PreMay*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreMM
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreMM=PreMM - (PreMM*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                        'PreEsp
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Productos set PreEsp=PreEsp - (PreEsp*" & porcentaje & ") where " & movi & "='" & cbo.Text & "'"
                        cmd1.ExecuteNonQuery()
                    End If
                End If
                cnn1.Close()
                btnNuevo.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try        
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        optprove.Checked = False
        optdepar.Checked = False
        optgrupo.Checked = False
        cbo.Text = ""
        cbo.Items.Clear()
        optcompra.Checked = False
        optventa.Checked = False
        optaumento.Checked = False
        optdiminuye.Checked = False
        txtpor.Text = "0"
    End Sub

    Private Sub cbo3Op_DropDown(sender As System.Object, e As System.EventArgs) Handles cbo3Op.DropDown
        Dim sql As String = ""
        cbo3Op.Items.Clear()
        If (optproves.Checked) Then
            sql = "SELECT DISTINCT ProvPri FROM Productos order by ProvPri"
        End If
        If (optdepa.Checked) Then
            sql = "SELECT DISTINCT Departamento FROM Productos order by Departamento"
        End If
        If (optgroup.Checked) Then
            sql = "SELECT DISTINCT Grupo FROM Productos order by Grupo"
        End If
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                sql
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbo3Op.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbo3Op_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbo3Op.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtprecioxpeso.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtprecioxpeso_Click(sender As System.Object, e As System.EventArgs) Handles txtprecioxpeso.Click
        txtprecioxpeso.SelectionStart = 0
        txtprecioxpeso.SelectionLength = Len(txtprecioxpeso.Text)
    End Sub

    Private Sub txtprecioxpeso_GotFocus(sender As Object, e As System.EventArgs) Handles txtprecioxpeso.GotFocus
        txtprecioxpeso.SelectionStart = 0
        txtprecioxpeso.SelectionLength = Len(txtprecioxpeso.Text)
    End Sub

    Private Sub txtprecioxpeso_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecioxpeso.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button1.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        optproves.Checked = False
        optdepa.Checked = False
        optgroup.Checked = False
        cbo3Op.Text = ""
        cbo3Op.Items.Clear()
        txtprecioxpeso.Text = "0.00"
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If cbo3Op.Text = "" Then MsgBox("Selecciona una opción de filtro para el cambio de precio.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbo3Op.Focus().Equals(True) : Exit Sub

            Dim movi As String = ""
            If (optprove.Checked) Then movi = "Proveedor"
            If (optdepar.Checked) Then movi = "Departamento"
            If (optgrupo.Checked) Then movi = "Grupo"

            If MsgBox("¿Deseas continuar con el cambio de precios por peso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Productos set PrecioVentaIVA=Multiplo*Existencia*" & CDbl(txtprecioxpeso.Text) & " where " & movi & "='" & cbo3Op.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos actualizados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
                cnn1.Close()

                Button2.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try        
    End Sub

    Private Sub cbomonedero_DropDown(sender As System.Object, e As System.EventArgs) Handles cbomonedero.DropDown
        cbomonedero.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct " & IIf(optprov_m.Checked = True, "NComercial", IIf(optgrup_m.Checked = True, "Grupo", IIf(optdept_m.Checked = True, "Departamento", ""))) & " from " & IIf(optprov_m.Checked = True, "Proveedores", IIf(optdept_m.Checked = True, "Productos", IIf(optgrup_m.Checked = True, "Productos", "")))
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbomonedero.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbomonedero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbomonedero.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmonedero.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtmonedero_GotFocus(sender As Object, e As System.EventArgs) Handles txtmonedero.GotFocus
        txtmonedero.SelectionStart = 0
        txtmonedero.SelectionLength = Len(txtmonedero.Text)
    End Sub

    Private Sub txtmonedero_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonedero.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtmonedero.Text = "" Then txtmonedero.Text = "0"
            If CDbl(txtmonedero.Text) > 100 Then MsgBox("El porcentaje no puede ser mayor a 100%", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonedero.SelectionStart = 0 : txtmonedero.SelectionLength = Len(txtmonedero.Text) : Exit Sub
            btnsave_mone.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        optprov_m.Checked = True
        optdept_m.Checked = False
        optgrup_m.Checked = False
        cbomonedero.Items.Clear()
        cbomonedero.Text = ""
        txtmonedero.Text = "0"
    End Sub

    Private Sub btnsave_mone_Click(sender As System.Object, e As System.EventArgs) Handles btnsave_mone.Click
        If cbomonedero.Text = "" Then MsgBox("Selecciona una opción para actualizar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbomonedero.Focus().Equals(True) : Exit Sub
        If MsgBox("¿Deseas actualizar la bonificación en monedero para el " & IIf(optprov_m.Checked = True, "Proveedor", IIf(optdept_m.Checked = True, "Departamento", IIf(optgrup_m.Checked = True, "Grupo", ""))) & " " & cbomonedero.Text & "?", vbInformation + vbYesNo, "Delsscom Control Negocios Pro") = vbYes Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Productos set Promo_Monedero=" & txtmonedero.Text & " where " & IIf(optprov_m.Checked = True, "ProvPri", IIf(optdept_m.Checked = True, "Departamento", IIf(optgrup_m.Checked = True, "Grupo", ""))) & "='" & cbomonedero.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Porcentaje de bonificación actualizado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        Try
            ComboBox1.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT " & IIf(rbGrupo.Checked = True, "Grupo", IIf(rbdepartamento.Checked = True, "Departamento", "")) & " from " & IIf(rbdepartamento.Checked = True, "Productos", IIf(rbGrupo.Checked = True, "Productos", ""))
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    ComboBox1.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboDescuentoDia_DropDown(sender As Object, e As EventArgs) Handles cboDescuentoDia.DropDown
        Try
            cboDescuentoDia.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT " & IIf(rbGrupoDia.Checked = True, "Grupo", IIf(rbProductoDia.Checked = True, "Nombre", "")) & " from " & IIf(rbProductoDia.Checked = True, "Productos", IIf(rbGrupoDia.Checked = True, "Productos", ""))
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDescuentoDia.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnNuevoDia_Click(sender As Object, e As EventArgs) Handles btnNuevoDia.Click
        rbGrupoDia.Checked = True
        cboDescuentoDia.Text = ""
        ComboBox2.Text = ""
        txtDescuentoDia.Text = "0"
        TextBox2.Text = ""
    End Sub

    Private Sub btnGuardarDia_Click(sender As Object, e As EventArgs) Handles btnGuardarDia.Click
        Try

            If cboDescuentoDia.Text = "" Then MsgBox("Selecciona una opción de filtro para el cambio de precio.", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro") : cboDescuentoDia.Focus().Equals(True) : Exit Sub

            Dim movi As String = ""
            If (rbGrupoDia.Checked) Then movi = "Descuento por grupo"
            If (rbProductoDia.Checked) Then movi = "Descuento por producto"
            If ComboBox2.Text = "" Then MsgBox("Debes seleccionar un dia para el descuento", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro") : Exit Sub
            If txtDescuentoDia.Text = "" Then MsgBox("Debes ingresar un descuento", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro") : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If (rbGrupoDia.Checked) Then
                cmd1.CommandText = "UPDATE Productos SET Dia='" & ComboBox2.Text & "',Descu=" & txtDescuentoDia.Text & " WHERE Grupo='" & cboDescuentoDia.Text & "'"
                cmd1.ExecuteNonQuery()
                MsgBox("Descuentos aplicados correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
            End If

            If (rbProductoDia.Checked) Then
                cmd1.CommandText = "UPDATE Productos SET Dia='" & ComboBox2.Text & "', Descu=" & txtDescuentoDia.Text & " WHERE Nombre='" & cboDescuentoDia.Text & "'"
                cmd1.ExecuteNonQuery()
                MsgBox("Descuentos aplicados correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDescuentoDia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescuentoDia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            ComboBox2.Focused.Equals(True)
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtDescuentoDia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDescuentoDia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoDia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardarDia.Focus.Equals(True)
        End If
    End Sub


End Class