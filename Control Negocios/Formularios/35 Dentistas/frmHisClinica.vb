Public Class frmHisClinica

    Private Sub frmHisClinica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblFecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
        lblHora.Text = FormatDateTime(Date.Now, DateFormat.LongTime)
    End Sub

    Private Sub cboMedicos_DropDown(sender As Object, e As EventArgs) Handles cboMedicos.DropDown
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' AND Puesto='MEDICO' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMedicos.Items.Add(rd5(0).ToString)
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
                                FormatNumber(cantidad, 2),
                                FormatNumber(txtPrecio.Text, 2),
                                FormatNumber(total, 2))

            txtTotalP.Text = txtTotalP.Text + CDec(total)
            txtTotalP.Text = FormatNumber(txtTotalP.Text, 2)

            txtCodigo.Text = ""
            cboDescripcion.Text = ""
            txtPrecio.Text = "0.00"

        End If
    End Sub

    Private Sub cboDescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,PrecioVentaIVA FROM productos WHERE Nombre='" & cboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCodigo.Text = rd1("Codigo").ToString
                    txtPrecio.Text = rd1("PrecioVentaIVA").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnd1_Click(sender As Object, e As EventArgs) Handles btnd1.Click
        txtNotacion.Text = "18"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub btnd2_Click(sender As Object, e As EventArgs) Handles btnd2.Click
        txtNotacion.Text = "17"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd3_Click(sender As Object, e As EventArgs) Handles btnd3.Click
        txtNotacion.Text = "16"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd4_Click(sender As Object, e As EventArgs) Handles btnd4.Click
        txtNotacion.Text = "15"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd5_Click(sender As Object, e As EventArgs) Handles btnd5.Click
        txtNotacion.Text = "14"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd6_Click(sender As Object, e As EventArgs) Handles btnd6.Click
        txtNotacion.Text = "13"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd7_Click(sender As Object, e As EventArgs) Handles btnd7.Click
        txtNotacion.Text = "12"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd8_Click(sender As Object, e As EventArgs) Handles btnd8.Click
        txtNotacion.Text = "11"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub btnd9_Click(sender As Object, e As EventArgs) Handles btnd9.Click
        txtNotacion.Text = "21"
        txtdiente.Text = "incisivo Central"
    End Sub

    Private Sub btnd10_Click(sender As Object, e As EventArgs) Handles btnd10.Click
        txtNotacion.Text = "22"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd11_Click(sender As Object, e As EventArgs) Handles btnd11.Click
        txtNotacion.Text = "23"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd12_Click(sender As Object, e As EventArgs) Handles btnd12.Click
        txtNotacion.Text = "24"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd13_Click(sender As Object, e As EventArgs) Handles btnd13.Click
        txtNotacion.Text = "25"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd14_Click(sender As Object, e As EventArgs) Handles btnd14.Click
        txtNotacion.Text = "26"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd15_Click(sender As Object, e As EventArgs) Handles btnd15.Click
        txtNotacion.Text = "27"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd16_Click(sender As Object, e As EventArgs) Handles btnd16.Click
        txtNotacion.Text = "28"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub btnd17_Click(sender As Object, e As EventArgs) Handles btnd17.Click
        txtNotacion.Text = "48"
        txtdiente.Text = "Tercer Molar"
    End Sub

    Private Sub btnd18_Click(sender As Object, e As EventArgs) Handles btnd18.Click
        txtNotacion.Text = "47"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd19_Click(sender As Object, e As EventArgs) Handles btnd19.Click
        txtNotacion.Text = "46"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd20_Click(sender As Object, e As EventArgs) Handles btnd20.Click
        txtNotacion.Text = "45"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd21_Click(sender As Object, e As EventArgs) Handles btnd21.Click
        txtNotacion.Text = "44"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd22_Click(sender As Object, e As EventArgs) Handles btnd22.Click
        txtNotacion.Text = "43"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd23_Click(sender As Object, e As EventArgs) Handles btnd23.Click
        txtNotacion.Text = "42"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd24_Click(sender As Object, e As EventArgs) Handles btnd24.Click
        txtNotacion.Text = "41"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub btnd25_Click(sender As Object, e As EventArgs) Handles btnd25.Click
        txtNotacion.Text = "31"
        txtdiente.Text = "Incisivo Central"
    End Sub

    Private Sub btnd26_Click(sender As Object, e As EventArgs) Handles btnd26.Click
        txtNotacion.Text = "32"
        txtdiente.Text = "Incisivo Lateral"
    End Sub

    Private Sub btnd27_Click(sender As Object, e As EventArgs) Handles btnd27.Click
        txtNotacion.Text = "33"
        txtdiente.Text = "Colmillo"
    End Sub

    Private Sub btnd28_Click(sender As Object, e As EventArgs) Handles btnd28.Click
        txtNotacion.Text = "34"
        txtdiente.Text = "Primer Premolar"
    End Sub

    Private Sub btnd29_Click(sender As Object, e As EventArgs) Handles btnd29.Click
        txtNotacion.Text = "35"
        txtdiente.Text = "Segundo Premolar"
    End Sub

    Private Sub btnd30_Click(sender As Object, e As EventArgs) Handles btnd30.Click
        txtNotacion.Text = "36"
        txtdiente.Text = "Primer Molar"
    End Sub

    Private Sub btnd31_Click(sender As Object, e As EventArgs) Handles btnd31.Click
        txtNotacion.Text = "37"
        txtdiente.Text = "Segundo Molar"
    End Sub

    Private Sub btnd32_Click(sender As Object, e As EventArgs) Handles btnd32.Click
        txtNotacion.Text = "38"
        txtdiente.Text = "Tercer Molar"
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
        Try

            If txtdiente.Text = "" Then MsgBox("Seleccione un diente", vbInformation + vbOKOnly, titulocentral) : Exit Sub
            If cboMedicos.Text = "" Then MsgBox("", vbInformation + vbOKOnly, titulocentral) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO hisclinicadental(Fecha,Hora,FechaC,Medico,IdCliente,Paciente,Edad,Sexo,Motivo) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & lblHora.Text & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & cboMedicos.Text & "'," & txtId.Text & ",'" & txtNombre.Text & "','" & txtEdad.Text & "','" & txtSexo.Text & "','')"
            cmd1.ExecuteNonQuery()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnMotivo_Click(sender As Object, e As EventArgs) Handles btnMotivo.Click
        gbxMotivo.Visible = True
        rbMotivo.Focus.Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gbxMotivo.Visible = False
    End Sub
End Class