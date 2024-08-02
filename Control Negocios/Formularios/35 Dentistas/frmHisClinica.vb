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
End Class