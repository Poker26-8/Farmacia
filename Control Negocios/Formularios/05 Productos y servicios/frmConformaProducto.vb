Public Class frmConformaProducto

    Private Sub CodBar()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where CodBarra='" & cbodescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cbodescripcion.Text = rd1("Nombre").ToString()
                    cbocodigo.Text = rd1("Codigo").ToString()
                    cbocodigo.Tag = rd1("Grupo").ToString()
                    txtunidad.Text = rd1("UVenta").ToString()
                    txtcantidad.Focus().Equals(True)
                    Exit Sub
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocodigo_Click(sender As Object, e As System.EventArgs) Handles cbocodigo.Click
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_DropDown(sender As System.Object, e As System.EventArgs) Handles cbocodigo.DropDown
        cbocodigo.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Grupo='INSUMO' order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbocodigo.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocodigo_GotFocus(sender As Object, e As System.EventArgs) Handles cbocodigo.GotFocus
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & cbocodigo.Text & "' and Grupo='INSUMO'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbodescripcion.Text = rd1("Nombre").ToString()
                        cbocodigo.Tag = rd1("Grupo").ToString()
                        txtunidad.Text = rd1("UVenta").ToString()
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            If cbocodigo.Text <> "" Then
                txtcantidad.Focus().Equals(True)
            Else : btnguardar.Focus().Equals(True)
                CodBar()
            End If
        End If
    End Sub

    Private Sub cbocod_Click(sender As System.Object, e As System.EventArgs) Handles cbocod.Click
        cbocod.SelectionStart = 0
        cbocod.SelectionLength = Len(cbocod.Text)
    End Sub

    Private Sub cbocod_DropDown(sender As Object, e As System.EventArgs) Handles cbocod.DropDown
        Dim mycodigo As String = ""
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,Grupo from Productos where Nombre='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    mycodigo = rd1(0).ToString()
                    cbocod.Tag = rd1(1).ToString()
                End If
            End If
            rd1.Close()
            cbocod.Items.Clear()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo from Productos where Left(Codigo,6)='" & mycodigo & "' and Grupo<>'INSUMO'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbocod.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocod_GotFocus(sender As Object, e As System.EventArgs) Handles cbocod.GotFocus
        cbocod.SelectionStart = 0
        cbocod.SelectionLength = Len(cbocod.Text)
    End Sub

    Private Sub cbocod_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocod.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            grdcaptura.Rows.Clear()
            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Codigo='" & cbocod.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbonombre.Text = rd1("Nombre").ToString()
                        cbocod.Text = rd1("Codigo").ToString()
                        txtuni.Text = rd1("UVenta").ToString()
                        txtexistencia.Text = rd1("Existencia").ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from MiProd where CodigoP='" & cbocod.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1("Codigo").ToString()
                        Dim nombre As String = rd1("Descrip").ToString()
                        Dim unidad As String = rd1("UVenta").ToString()
                        Dim cantidad As Double = rd1("Cantidad").ToString()

                        grdcaptura.Rows.Add(codigo,nombre,unidad,cantidad)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cbodescripcion.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbodescripcion_DropDown(sender As System.Object, e As System.EventArgs) Handles cbodescripcion.DropDown
        cbodescripcion.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Productos where Grupo='INSUMO'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbodescripcion.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbodescripcion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbodescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cbodescripcion.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbocodigo.Text = rd1("Codigo").ToString()
                        cbocodigo.Tag = rd1("Grupo").ToString()
                        txtunidad.Text = rd1("UVenta").ToString()
                        cbocodigo.Focus().Equals(True)
                        Exit Sub
                    End If
                Else
                    rd1.Close()
                    CodBar()
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            CodBar()
            cbocodigo.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonombre_Click(sender As Object, e As System.EventArgs) Handles cbonombre.Click
        cbonombre.SelectionStart = 0
        cbonombre.SelectionLength = Len(cbonombre.Text)
    End Sub

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Productos where Grupo<>'INSUMO'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
                    rd1(0).ToString()
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_GotFocus(sender As Object, e As System.EventArgs) Handles cbonombre.GotFocus
        cbonombre.SelectionStart = 0
        cbonombre.SelectionLength = Len(cbonombre.Text)
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            grdcaptura.Rows.Clear()
            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbocod.Text = rd1("Codigo").ToString()
                        txtuni.Text = rd1("UVenta").ToString()
                        txtexistencia.Text = rd1("Existencia").ToString()
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from MiProd where CodigoP='" & cbocod.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1("Codigo").ToString()
                        Dim nombre As String = rd1("Descrip").ToString()
                        Dim unidad As String = rd1("UVenta").ToString()
                        Dim cantidad As Double = rd1("Cantidad").ToString()

                        grdcaptura.Rows.Add(codigo,nombre,unidad,cantidad)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cbocod.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnnuevo.Click
        cbocod.Items.Clear()
        cbocod.Text = ""
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtuni.Text = ""
        txtexistencia.Text = ""
        cbocodigo.Items.Clear()
        cbocodigo.Text = ""
        cbodescripcion.Items.Clear()
        cbodescripcion.Text = ""
        txtunidad.Text = ""
        txtcantidad.Text = ""
        grdcaptura.Rows.Clear()
    End Sub

    Private Sub txtcantidad_Click(sender As System.Object, e As System.EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbonombre.Text = "" Or cbocod.Text = "" Then MsgBox("Selecciona un producto para conformarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
            If cbocodigo.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub
            If cbodescripcion.Text = "" Then cbodescripcion.Focus().Equals(True) : Exit Sub
            If txtcantidad.Text = "" Or txtcantidad.Text = "0" Then txtcantidad.Focus().Equals(True) : Exit Sub

            grdcaptura.Rows.Add(cbocodigo.Text, cbodescripcion.Text, txtunidad.Text, txtcantidad.Text)
            My.Application.DoEvents()

            cbocodigo.Text = ""
            cbocodigo.Items.Clear()
            cbodescripcion.Text = ""
            cbodescripcion.Focus().Equals(True)
            txtunidad.Text = ""
            txtcantidad.Text = ""
            cbodescripcion.Focus().Equals(True)
        End If
    End Sub

    Private Sub btneliminar_Click(sender As System.Object, e As System.EventArgs) Handles btneliminar.Click
        If cbonombre.Text = "" Or cbocod.Text = "" Then MsgBox("Selecciona un producto para eliminar su conformación.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
        If MsgBox("¿Deseas eliminar esta conformcación del producto " & cbonombre.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from MiProd where CodigoP='" & cbocod.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Conformación eliminada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnnuevo.PerformClick()
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnguardar_Click(sender As System.Object, e As System.EventArgs) Handles btnguardar.Click
        If cbocod.Text = "" Or cbonombre.Text = "" Then MsgBox("Selecciona un producto para poder guardar su conformación.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub
        If grdcaptura.Rows.Count = 0 Then
            MsgBox("Necesitas agregar insumos para guaradar la conformación.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbodescripcion.Focus().Equals(True) : Exit Sub
        End If
        If MsgBox("¿Deseas guardar esta conformación de producto?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close()
                cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from MiProd where CodigoP='" & cbocod.Text & "'"
                cmd1.ExecuteNonQuery()

                For s As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(s).Cells(0).Value.ToString()
                    Dim nombre As String = grdcaptura.Rows(s).Cells(1).Value.ToString()
                    Dim unidad As String = grdcaptura.Rows(s).Cells(2).Value.ToString()
                    Dim cantidad As Double = grdcaptura.Rows(s).Cells(3).Value.ToString()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into MiProd(CodigoP,DescripP,UVentaP,CantidadP,Codigo,Descrip,UVenta,Cantidad,Grupo) values('" & cbocod.Text & "','" & cbonombre.Text & "','" & txtuni.Text & "'," & txtexistencia.Text & ",'" & codigo & "','" & nombre & "','" & unidad & "'," & cantidad & ",'INSUMO')"
                    cmd1.ExecuteNonQuery()
                Next
                MsgBox("Conformación de producto guardada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : btnnuevo.PerformClick()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try            
        End If
    End Sub

    Private Sub grdcaptura_DoubleClick(sender As System.Object, e As System.EventArgs) Handles grdcaptura.DoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index

        cbocodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
        cbodescripcion.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
        txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
        txtcantidad.Text = grdcaptura.Rows(index).Cells(3).Value.ToString

        grdcaptura.Rows.Remove(grdcaptura.Rows(index))
    End Sub

    Private Sub txtcantidad_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtcantidad.KeyUp

    End Sub
End Class