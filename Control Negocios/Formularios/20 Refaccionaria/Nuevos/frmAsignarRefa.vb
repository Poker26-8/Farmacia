Public Class frmAsignarRefa
    Private Sub frmAsignarRefa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        frmMenuPrincipal.Show()
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

    Private Sub cboMarca_DropDown(sender As Object, e As EventArgs) Handles cboMarca.DropDown
        Try
            cboMarca.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM marcas WHERE Nombre<>'' ORDER BY Nombre"
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

    Private Sub cboModelo_DropDown(sender As Object, e As EventArgs) Handles cboModelo.DropDown
        Try
            cboModelo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Modelo FROM vehiculo2 WHERE Marca='" & cboMarca.Text & "' AND Modelo<>'' ORDER BY Modelo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboModelo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboUbicaicon_DropDown(sender As Object, e As EventArgs) Handles cboUbicaicon.DropDown
        Try
            cboUbicaicon.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Ubicacion from productos WHERE Ubicacion<>'' ORDER BY Ubicacion"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboUbicaicon.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboServicio.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboServicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboServicio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtbarras.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtbarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarras.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumparte.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtnumparte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumparte.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Codigo,Nombre,CodBarra,Ubicacion FROM productos WHERE N_Serie='" & txtnumparte.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cboCodigo.Text = rd2("Codigo").ToString
                    cboNombre.Text = rd2("Nombre").ToString
                    txtbarras.Text = rd2("CodBarra").ToString
                    cboUbicaicon.Text = rd2("Ubicacion").ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()

            If cboMarca.Text <> "" And cboModelo.Text <> "" And cboAno.Text <> "" Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Servicio,Observaciones FROM refaccionaria WHERE CodigoPro='" & cboCodigo.Text & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        cboServicio.Text = rd2("Servicio").ToString
                        txtObservacion.Text = rd2("Observaciones").ToString
                    End If
                End If
                rd2.Close()
                cnn2.Close()

            End If

            txtpiezas.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtpiezas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpiezas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtpiezas.Text) Then
                cboUbicaicon.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub cboUbicaicon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUbicaicon.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboAno.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtObservacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboNombre.Text = "" Then MsgBox("Debe seleccionar el producto", vbInformation + vbOKOnly, titulorefaccionaria) : cboNombre.Focus.Equals(True) : Exit Sub

            If txtpiezas.Text > 1 Then MsgBox("La cantidad debe de ser mayor a 1", vbInformation + vbOKOnly, titulorefaccionaria) : txtpiezas.Focus.Equals(True) : Exit Sub

            grdCaptura.Rows.Add(cboCodigo.Text,
                                cboNombre.Text,
                                txtnumparte.Text,
                                cboNombre.Text,
                                cboMarca.Text,
                                cboModelo.Text,
                                cboServicio.Text,
                                txtObservacion.Text,
                                cboUbicaicon.Text,
                                txtpiezas.Text,
                                cboAno.Text
)




            btnGuardar.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        TraerDatos("NOMBRE")
    End Sub

    Public Sub TraerDatos(ByVal dato As String)
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If dato = "NOMBRE" Then
                cmd1.CommandText = "SELECT * FROM productos WHERE Nombre='" & cboNombre.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboCodigo.Text = rd1("Codigo").ToString
                    txtbarras.Text = rd1("CodBarra").ToString
                    txtnumparte.Text = rd1("N_Serie").ToString
                    cboUbicaicon.Text = rd1("Ubicacion").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM refaccionaria WHERE Nombre='" & cboNombre.Text & "' AND CodigoPro='" & cboCodigo.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtObservacion.Text = rd2("Observaciones").ToString
                        End If
                    End If
                    rd2.Close()

                End If
            End If
            rd1.Close()
            cnn1.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodigo.SelectedValueChanged
        TraerDatos2("CODIGO")
    End Sub

    Public Sub TraerDatos2(ByVal dato As String)
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If dato = "CODIGO" Then
                cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & cboCodigo.Text & "'"
            End If

            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboNombre.Text = rd1("Nombre").ToString
                    txtbarras.Text = rd1("CodBarra").ToString
                    txtnumparte.Text = rd1("N_Serie").ToString
                    cboUbicaicon.Text = rd1("Ubicacion").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If cboMarca.Text = "" Then MsgBox("Seleccione la marca") : cboMarca.Focus.Equals(True) : Exit Sub
            If cboModelo.Text = "" Then MsgBox("Seleccione el modelo") : cboModelo.Focus.Equals(True) : Exit Sub
            If cboAno.Text = "" Then MsgBox("Seleccione el año") : cboAno.Focus.Equals(True) : Exit Sub

            If grdCaptura.Rows.Count > 0 Then

                For monkey As Integer = 0 To grdCaptura.Rows.Count - 1

                    Dim codigo As String = grdCaptura.Rows(monkey).Cells(0).Value.ToString
                    Dim barras As String = grdCaptura.Rows(monkey).Cells(1).Value.ToString
                    Dim parte As String = grdCaptura.Rows(monkey).Cells(2).Value.ToString
                    Dim nombre As String = grdCaptura.Rows(monkey).Cells(3).Value.ToString
                    Dim marca As String = grdCaptura.Rows(monkey).Cells(4).Value.ToString
                    Dim modelo As String = grdCaptura.Rows(monkey).Cells(5).Value.ToString
                    Dim servicioo As String = grdCaptura.Rows(monkey).Cells(6).Value.ToString
                    Dim observacion As String = grdCaptura.Rows(monkey).Cells(7).Value.ToString
                    Dim ubicacion As String = grdCaptura.Rows(monkey).Cells(8).Value.ToString
                    Dim pieza As String = grdCaptura.Rows(monkey).Cells(9).Value.ToString
                    Dim ano As String = grdCaptura.Rows(monkey).Cells(10).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM refaccionaria WHERE Nombre='" & nombre & "' AND Marca='" & marca & "' AND Modelo='" & modelo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO refaccionaria(CodigoPro,NumParte,CodBarra,Nombre,Marca,Modelo,Observaciones,Ubicacion,Servicio,Npiezas,Ano) VALUES('" & codigo & "','" & parte & "','" & barras & "','" & nombre & "','" & marca & "','" & modelo & "','" & observacion & "','" & ubicacion & "','" & servicioo & "','" & pieza & "','" & ano & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                    cnn1.Close()

                Next
                MsgBox("Refacciones asignadas correctamente", vbInformation + vbOKOnly, titulorefaccionaria)
                grdCaptura.Rows.Clear()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnModelos_Click(sender As Object, e As EventArgs) Handles btnModelos.Click
        frmModelos.Show()
        frmModelos.BringToFront()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboMarca.Text = ""
        cboModelo.Text = ""
        cboAno.Text = ""
        cboServicio.Text = ""
        txtObservacion.Text = ""
    End Sub

    Private Sub cboAno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboAno.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboModelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim index As Integer = grdCaptura.CurrentRow.Index

        grdCaptura.Rows.Remove(grdCaptura.Rows(index))
    End Sub

    Private Sub cboAno_DropDown(sender As Object, e As EventArgs) Handles cboAno.DropDown
        Try
            cboAno.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Ano FROM refaccionaria WHERE Ano<>'' ORDER BY Ano"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboAno.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboServicio_DropDown(sender As Object, e As EventArgs) Handles cboServicio.DropDown
        Try
            cboServicio.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Servicio FROM refaccionaria WHERE Servicio<>'' ORDER BY Servicio"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboServicio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub frmAsignarRefa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMenuPrincipal.Show()
    End Sub
End Class