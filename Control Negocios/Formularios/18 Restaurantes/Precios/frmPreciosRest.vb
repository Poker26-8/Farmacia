Public Class frmPreciosRest

    Dim ivaproducto As Double = 0
    Dim precioventaiva As Double = 0

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        Try
            cboNombre.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboNombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCodigo_DropDown(sender As Object, e As EventArgs) Handles cboCodigo.DropDown
        Try
            cboCodigo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM productos WHERE Codigo<>'' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCodigo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            TraerDato("CODIGO")
            txtPC.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_LostFocus(sender As Object, e As EventArgs) Handles cboNombre.LostFocus

        Dim iva As Double = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Codigo,IVA FROM productos WHERE Nombre='" & cboNombre.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                cboCodigo.Text = rd1("Codigo").ToString
                iva = rd1("IVA").ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        txtPCI.Text = IIf(txtPCI.Text = "", 0, txtPCI.Text) * (1 + iva)
        txtPCI.Text = FormatNumber(txtPCI.Text, 2)
    End Sub


    Public Sub TraerDato(ByVal DATO As String)
        Try
            ivaproducto = 0
            precioventaiva = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre,IVA,UVenta,PrecioCompra,PorcMin,PrecioDomicilioIVA,Porcentaje,PrecioVenta,PrecioVentaIVA FROM productos WHERE Codigo='" & cboCodigo.Text & "'"

            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboNombre.Text = rd1("Nombre").ToString
                    ivaproducto = rd1("IVA").ToString
                    txtUnidad.Text = rd1("UVenta").ToString
                    txtPC.Text = rd1("PrecioCompra").ToString
                    txtPCI.Text = IIf(txtPC.Text = "", 0, txtPC.Text) * (1 + rd1("IVA").ToString)
                    txtPCI.Text = FormatNumber(txtPCI.Text, 2)
                    txtUtiM.Text = IIf(rd1("PorcMin").ToString = "", 0, rd1("PorcMin").ToString)
                    txtPMI.Text = rd1("PrecioDomicilioIVA").ToString
                    txtUti.Text = rd1("Porcentaje").ToString
                    txtUti.Text = FormatNumber(txtUti.Text, 2)
                    txtPV.Text = rd1("PrecioVenta").ToString
                    txtPVI.Text = rd1("PrecioVentaIVA").ToString
                    precioventaiva = rd1("PrecioVentaIVA").ToString
                End If
            Else
                MsgBox("Este Código no existe!", vbInformation + vbOKOnly, titulorestaurante)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrecioCompra,MCD FROM productos WHERE Codigo='" & Strings.Left(cboCodigo.Text, 6) & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("MCD").ToString() > 0 Then txtPC.Text = rd1("PrecioCompra").ToString / rd1("MCD").ToString
                    txtPC.Text = FormatNumber(txtPC.Text, 2)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub cboCodigo_GotFocus(sender As Object, e As EventArgs) Handles cboCodigo.GotFocus
        cboCodigo.SelectionStart = 0
        cboCodigo.SelectionLength = Len(cboCodigo.Text)
    End Sub

    Private Sub txtPC_GotFocus(sender As Object, e As EventArgs) Handles txtPC.GotFocus
        cboCodigo.SelectionStart = 0
        cboCodigo.SelectionLength = Len(cboCodigo.Text)
    End Sub

    Private Sub txtPC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPC.Text) Then

                txtPCI.Text = IIf(txtPC.Text = "", 0, txtPC.Text) * (1 + ivaproducto)
                txtPC.Text = FormatNumber(txtPC.Text, 2)
                txtPCI.Text = FormatNumber(txtPCI.Text, 2)
                If CDec(IIf(txtPC.Text = "", 0, txtPC.Text)) = 0 Then
                    txtPCI.Focus.Equals(True)
                Else
                    txtPCI.Focus.Equals(True)
                End If
            End If
        End If
    End Sub

    Private Sub txtPCI_GotFocus(sender As Object, e As EventArgs) Handles txtPCI.GotFocus
        txtPCI.SelectionStart = 0
        txtPCI.SelectionLength = Len(txtPCI.Text)
    End Sub

    Private Sub txtPCI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPCI.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPCI.Text) Then
                txtPC.Text = IIf(txtPCI.Text = "", 0, txtPCI.Text) / (1 + ivaproducto)
                txtPC.Text = FormatNumber(txtPC.Text, 2)
                txtPCI.Text = FormatNumber(txtPCI.Text, 2)

                txtFacUtil.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtFacUtil_MouseHover(sender As Object, e As EventArgs) Handles txtFacUtil.MouseHover
        txtFacUtil.SelectionStart = 0
        txtFacUtil.SelectionLength = Len(txtFacUtil.Text)
    End Sub

    Private Sub txtFacUtil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFacUtil.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtFacUtil.Text) Then
                If txtFacUtil.Text > 0 Then
                    txtPVI.Text = IIf(txtPCI.Text = "", 0, txtPCI.Text) * IIf(txtFacUtil.Text = "", 0, txtFacUtil.Text)
                    txtPVI.Text = FormatNumber(txtPVI.Text, 2)
                Else
                    txtPVI.Text = precioventaiva
                    txtPVI.Text = FormatNumber(txtPVI.Text, 2)
                End If

                txtPMI.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPMI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPMI.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPMI.Text) Then
                If CDec(IIf(txtPMI.Text = "", 0, txtPMI.Text)) > 0 Then
                    txtUtiM.Text = ((((IIf(txtPMI.Text = "", "0", txtPMI.Text) / (ivaproducto + 1)) / IIf(CDec(txtPC.Text) = 0, 1, txtPC.Text)) - 1) * 100)
                    txtUtiM.Text = FormatNumber(txtUtiM.Text, 2)
                    txtPMI.Text = FormatNumber(txtPMI.Text, 2)
                End If
                txtUtiM.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtUtiM_GotFocus(sender As Object, e As EventArgs) Handles txtUtiM.GotFocus
        txtUtiM.SelectionStart = 0
        txtUtiM.SelectionLength = Len(txtUtiM.Text)
    End Sub

    Private Sub txtUtiM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUtiM.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtUtiM.Text) Then

                txtPMI.Text = (IIf(CDec(txtPC.Text) = 0, "0", txtPC.Text) * ((IIf(CDec(IIf(txtUtiM.Text = "", "0", txtUtiM.Text)) = 0, "0", txtUtiM.Text) / 100) + 1)) * (ivaproducto + 1)
                txtPMI.Text = FormatNumber(txtPMI.Text, 2)

                txtUti.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtUti_GotFocus(sender As Object, e As EventArgs) Handles txtUti.GotFocus
        txtUti.SelectionStart = 0
        txtUti.SelectionLength = Len(txtUti.Text)
    End Sub

    Private Sub txtUti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUti.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtUti.Text = FormatNumber(txtUti.Text, 2)
            If txtPC.Text <> "" Then
                txtPV.Text = FormatNumber((txtPC.Text * (txtUti.Text / 100)) + txtPC.Text, 2)
                txtPVI.Text = FormatNumber(((txtPV.Text * ivaproducto) + (txtPV.Text)), 2)
            End If
            txtPVI.Focus.Equals(True)
        End If
    End Sub
    Private Sub txtPVI_GotFocus(sender As Object, e As EventArgs) Handles txtPVI.GotFocus
        txtPVI.SelectionStart = 0
        txtPVI.SelectionLength = Len(txtPVI.Text)
    End Sub

    Private Sub txtPVI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPVI.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPVI.Text) Then
                If txtPVI.Text = "" Then txtPVI.Text = 1
                If txtPVI.Text = 0 Then txtPVI.Text = 1

                txtPorcientoProd.Text = (IIf(txtPC.Text = "", "0", txtPC.Text) / IIf(txtPVI.Text = "", "0", txtPVI.Text)) * 100
                txtPorcientoProd.Text = FormatNumber(txtPorcientoProd.Text, 2)

                If txtPVI.Text <> "" Then
                    txtPV.Text = txtPVI.Text / (ivaproducto + 1)
                    If CDec(txtPC.Text) <> 0 Then txtUti.Text = (((txtPV.Text / txtPC.Text) - 1) * 100) '%Utili
                    txtPV.Text = FormatNumber(txtPV.Text, 2)
                    txtPVI.Text = FormatNumber(txtPVI.Text, 2)
                End If
                btnGuardar.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtPV_GotFocus(sender As Object, e As EventArgs) Handles txtPV.GotFocus
        txtPV.SelectionStart = 0
        txtPV.SelectionLength = Len(txtPV.Text)
    End Sub

    Private Sub txtPV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPV.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPV.Text) Then
                If txtPV.Text <> "" Then
                    If CDec(txtPC.Text) <> 0 Then txtUti.Text = (((txtPV.Text / txtPC.Text) - 1) * 100)
                    txtPVI.Text = ((txtPV.Text * ivaproducto) + (txtPV.Text))
                    txtPVI.Text = Format(txtPVI.Text, "###,##0.00")
                    txtPV.Text = Format(txtPV.Text, "###,##0.00")
                End If

            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboCodigo.Text = ""
        cboNombre.Text = ""
        txtUnidad.Text = ""
        txtPC.Text = "0.00"
        txtUti.Text = "0.00"
        txtPV.Text = "0.00"
        txtPVI.Text = "0.00"
        txtPCI.Text = "0.00"
        txtUtiM.Text = "0.00"
        txtPMI.Text = "0.00"
        txtFacUtil.Text = "0.00"
        txtPorcientoProd.Text = "0.00"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If txtPC.Text = "" Then MsgBox("Escribe un Valor en Costo sin IVA") : txtPC.Focus.Equals(True) : Exit Sub
        If txtPCI.Text = "" Then MsgBox("Escribe un Valor en Costo con IVA") : txtPCI.Focus.Equals(True) : Exit Sub
        If txtUtiM.Text = "" Then MsgBox("Escribe un Valor en % Utilidad") : txtUtiM.Focus.Equals(True) : Exit Sub
        If txtPMI.Text = "" Then MsgBox("Escribe un Valor en Precio Minimo IVA") : txtPMI.Focus.Equals(True) : Exit Sub
        If txtUti.Text = "" Then MsgBox("Escribe un Valor en % Utilidad") : txtUti.Focus.Equals(True) : Exit Sub
        If txtPV.Text = "" Then MsgBox("Escribe un Valor en Precio Venta sin IVA") : txtPV.Focus.Equals(True) : Exit Sub
        If txtPVI.Text = "" Then MsgBox("Escribe un Valor en Precio Venta con IVA") : txtPVI.Focus.Equals(True) : Exit Sub

        If CDec(IIf(txtPVI.Text = "", "0", txtPVI.Text)) < CDec(IIf(txtPCI.Text = "", "0", txtPCI.Text)) Then MsgBox("El Precio Mínimo deberá ser menor o igual al Precio Venta con IVA!", vbInformation + vbOKOnly, titulorestaurante) : txtUtiM.Focus.Equals(True) : Exit Sub
        If MsgBox("Desea Guardar Este Precio?", vbQuestion + vbYesNo + vbDefaultButton1) = vbNo Then Exit Sub
        txtPVI.Tag = Format(txtPVI.Text, 2)
        txtPV.Tag = Format(txtPV.Text, 2)

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Codigo FROM productos WHERE Codigo='" & cboCodigo.Text & "' AND Nombre='" & cboNombre.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "update Productos SET PorcMin = '" & txtUtiM.Text & "',Porcentaje = '" & txtUti.Text & "',PrecioCompra ='" & txtPC.Text & "',PrecioVentaIVA ='" & txtPVI.Text & "',PrecioVenta ='" & txtPV.Text & "',PrecioDomicilio=" & txtPMI.Text & ",PrecioDomicilioIVA ='" & txtPMI.Text & "' WHERE  Codigo ='" & cboCodigo.Text & "' AND Nombre='" & cboNombre.Text & "'"
                    If cmd1.ExecuteNonQuery() Then
                        MsgBox("Precios actualizados correctamente", vbInformation + vbOKOnly, titulorestaurante)
                    End If
                    cnn1.Close()
                End If
            End If
            rd2.Close()
            cnn2.Close()
            btnNuevo.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub frmPreciosRest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class