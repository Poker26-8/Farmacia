Public Class frmVehiculos2
    Private Sub frmVehiculos2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboMarca_DropDown(sender As Object, e As EventArgs) Handles cboMarca.DropDown
        Try
            cboMarca.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Marca FROM transporte WHERE Marca<>'' ORDER BY marca"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboSubmarca_DropDown(sender As Object, e As EventArgs) Handles cboSubmarca.DropDown
        Try
            cboSubmarca.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Submarca FROM transporte WHERE Submarca <>'' ORDER Submarca"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboSubmarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboPlacas_DropDown(sender As Object, e As EventArgs) Handles cboPlacas.DropDown
        Try
            cboPlacas.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Placas FROM transporte WHERE Placas<> ORDER BY placas"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboPlacas.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboChofer_DropDown(sender As Object, e As EventArgs) Handles cboChofer.DropDown
        Try
            cboChofer.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Porteoperador WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboChofer.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboSeguro_DropDown(sender As Object, e As EventArgs) Handles cboSeguro.DropDown
        Try
            cboSeguro.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Seguro FROM transporte WHERE Seguro<>'' ORDER BY Seguro"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboSeguro.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboSubmarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboSubmarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSubmarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboPlacas.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboPlacas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPlacas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtModelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboArea.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboArea.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboChofer.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboChofer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboChofer.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboSeguro.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboSeguro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSeguro.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPoliza.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPoliza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPoliza.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then
            dtpVencimiento.Focus.Equals(True)
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub dtpVencimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpVencimiento.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelEmergencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelEmergencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelEmergencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelAseguradora.Focus.Equals(True)
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelAseguradora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelAseguradora.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtAgente.Focus.Equals(True)
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAgente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAgente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelAgente.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelAgente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelAgente.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMes1.Focus.Equals(True)
        End If
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cboMes1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMes1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMes2.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboMes2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMes2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCircula.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCircula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCircula.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboServicios.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboServicios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboServicios.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnServicio_Click(sender As Object, e As EventArgs) Handles btnServicio.Click

        If cboServicios.Text = "" Then
            If MsgBox("Selecciona un servicio para continuar!!!", vbOKOnly + vbOKOnly, titulocentral) = MsgBoxResult.Ok Then
                cboServicios.DroppedDown = True
                Exit Sub
            End If
        Else
            Dim ser As String = ""
            Dim fec As Date = Nothing
            Dim fech As String = ""

            ser = cboServicios.Text
            fec = dtpFechaServicio.Value
            fech = Format(fec, "yyyy-MM-dd")

            grdServicio.Rows.Add(ser, fech)
            cboServicios.Text = ""
            dtpFechaServicio.Value = Date.Now
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Deseas cerrar el formulario?", vbOKCancel + vbOKOnly, titulocentral) = MsgBoxResult.Ok Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboMarca.Text = ""
        cboSubmarca.Text = ""
        cboPlacas.Text = ""
        txtModelo.Text = ""
        cboArea.Text = ""
        cboChofer.Text = ""
        cboSeguro.Text = ""
        txtPoliza.Text = ""
        dtpVencimiento.Value = Date.Now
        txtTelEmergencia.Text = ""
        txtTelAseguradora.Text = ""
        txtAgente.Text = ""
        txtTelAgente.Text = ""
        cboMes1.Text = ""
        cboMes2.Text = ""
        cboCircula.Text = ""
        cboServicios.Text = ""
        dtpFechaServicio.Value = Date.Now
        grdServicio.Rows.Clear()
        txtTotal.Text = ""

        cargar
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Sub grdServicio_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdServicio.CellDoubleClick

        Dim index As Integer = grdServicio.CurrentRow.Index

        cboServicios.Text = grdServicio.Rows(index).Cells(0).Value.ToString
        dtpFechaServicio.Value = grdServicio.Rows(index).Cells(1).Value.ToString

        grdServicio.Rows.Remove(grdServicio.CurrentRow)
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick

    End Sub

    Public Sub cargar()

    End Sub
End Class