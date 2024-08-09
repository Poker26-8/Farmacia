Public Class frmHClinica
    Public namexd As String = ""
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblFecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
        lblHora.Text = FormatDateTime(Date.Now, DateFormat.LongTime)
    End Sub
    Public Sub MostrarTodo()
        Try

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmHClinica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Enabled = True
        For Each xxx As Control In Me.Controls
            xxx.Enabled = True
        Next
        Timer1.Start()
        MostrarTodo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtNotacion.Text = "18"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        txtNotacion.Text = "17"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        txtNotacion.Text = "16"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        txtNotacion.Text = "15"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        txtNotacion.Text = "14"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        txtNotacion.Text = "13"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        txtNotacion.Text = "12"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        txtNotacion.Text = "11"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        txtNotacion.Text = "21"
        txtdiente.Text = "incisivo Central"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        txtNotacion.Text = "22"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        txtNotacion.Text = "23"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        txtNotacion.Text = "24"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtNotacion.Text = "25"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txtNotacion.Text = "26"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtNotacion.Text = "27"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtNotacion.Text = "28"
        txtdiente.Text = "Tercer Molar"
    End Sub


    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        txtNotacion.Text = "48"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtNotacion.Text = "47"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        txtNotacion.Text = "46"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        txtNotacion.Text = "45"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        txtNotacion.Text = "44"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        txtNotacion.Text = "43"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        txtNotacion.Text = "42"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        txtNotacion.Text = "41"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        txtNotacion.Text = "31"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        txtNotacion.Text = "32"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        txtNotacion.Text = "33"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        txtNotacion.Text = "34"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        txtNotacion.Text = "35"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        txtNotacion.Text = "36"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        txtNotacion.Text = "37"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        txtNotacion.Text = "38"
        txtdiente.Text = "Tercer Molar"
    End Sub


    Private Sub grd_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellDoubleClick
        Dim index As Integer = grd.CurrentRow.Index
        grd.Rows.Remove(grd.Rows(index))
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        'txtid.Text = ""
        'txtNombre.Text = ""
        'txtEdad.Text = ""
        'txtSexo.Text = ""
        txtNotacion.Text = ""
        txtdiente.Text = ""
        rtSintomas.Text = ""
        rtHistorial.Text = ""
        rtHistorialMedico.Text = ""
        grd.Rows.Clear()
        txtEnfermedad.Text = ""
        rtdiagnostico.Text = ""
        grdDiagnostico.Rows.Clear()
        cbHigiene.Checked = False
        cbMalos.Checked = False
        cbPlaca.Checked = False
        cbRevision.Checked = False
        cbDeteccion.Checked = False
        cbEncias.Checked = False
        cbAccidente.Checked = False
        cbDesarrollo.Checked = False
        cbEstetica.Checked = False
        cbProxima.Checked = False
        dtpFechaProxima.Value = Date.Now
    End Sub

    Private Sub cboMedico_DropDown(sender As Object, e As EventArgs) Handles cboMedico.DropDown
        Try
            cboMedico.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Puesto='MEDICO'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMedico.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        Try
            cboDescripcion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDescripcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboDescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,PrecioVentaIVA from productos WHERE Nombre='" & cboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCodigo.Text = rd1(0).ToString
                    txtPrecio.Text = rd1(1).ToString
                End If
            End If
            cnn1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPrecio.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim cantidad As Double = 1
            Dim total As Double = 0

            total = CDec(cantidad) * CDec(txtPrecio.Text)

            grdCaptura.Rows.Add(txtNotacion.Text,
                                    txtdiente.Text,
                                    txtCodigo.Text,
                                    cboDescripcion.Text,
                                    cantidad,
                                    FormatNumber(txtPrecio.Text, 2),
                                    FormatNumber(total, 2)
                                    )

            txtTotalP.Text = txtTotalP.Text + CDec(total)
            txtTotalP.Text = FormatNumber(txtTotalP.Text, 2)

            txtCodigo.Text = ""
            cboDescripcion.Text = ""
            txtPrecio.Text = "0.00"

        End If
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim index As Integer = grdCaptura.CurrentRow.Index

        Dim tot As Double = grdCaptura.Rows(index).Cells(6).Value.ToString

        txtTotalP.Text = txtTotalP.Text - CDec(tot)

        grdCaptura.Rows.Remove(grdCaptura.Rows(index))
    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
        Dim MyOpe As Double = CDbl(IIf(txtTotalP.Text = "", "0", txtTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))
        If MyOpe < 0 Then
            txtCambio.Text = FormatNumber(-MyOpe, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
    End Sub

    Private Sub txtEfectivo_Click(sender As Object, e As EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_GotFocus(sender As Object, e As EventArgs) Handles txtEfectivo.GotFocus
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "" : Exit Sub
        If txtEfectivo.Text = "" And AscW(e.KeyChar) = 46 Then
            txtEfectivo.Text = "0.00"
            txtEfectivo.SelectionStart = 0
            txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
            txtEfectivo.Focus().Equals(True)
        End If

        If AscW(e.KeyChar) = Keys.Enter Then
            txtEfectivo.Text = FormatNumber(txtEfectivo.Text, 2)
            Dim MyOpe As Double = CDbl(IIf(txtTotalP.Text = "", "0", txtTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))
            If MyOpe < 0 Then
                txtCambio.Text = FormatNumber(-MyOpe, 2)
                txtResta.Text = "0.00"
            Else
                txtResta.Text = FormatNumber(MyOpe, 2)
                txtCambio.Text = "0.00"
            End If
            txtCambio.Text = FormatNumber(txtCambio.Text, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)
            btnPagar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click

    End Sub
End Class