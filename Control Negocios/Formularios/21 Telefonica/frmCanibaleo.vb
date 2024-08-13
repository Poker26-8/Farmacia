Public Class frmCanibaleo
    Private Sub frmCanibaleo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtModelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtColor.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtColor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbocodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodescripcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbodescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            If cbodescripcion.Text = "" Then
                btnGuardar.Focus.Equals(True)
            Else
                txtcantidad.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If cbocodigo.Text <> "" And cbodescripcion.Text <> "" And txtcantidad.Text <> "" Then

                grdPiezas.Rows.Add(cbocodigo.Text, cbodescripcion.Text, txtcantidad.Text)
                cbocodigo.Focus.Equals(True)
            Else
                MsgBox("Debe ingresar los datos para la pieza", vbInformation + vbOKOnly, titulotaller)
                Exit Sub
            End If

            cbocodigo.Text = ""
            cbodescripcion.Text = ""
            txtcantidad.Text = ""
        End If
    End Sub

    Private Sub cbocodigo_DropDown(sender As Object, e As EventArgs) Handles cbocodigo.DropDown
        Try
            cbocodigo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Codigo FROM productos WHERE Codigo<>'' ORDER BY Codigo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbocodigo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtColor.Text = ""
        cbocodigo.Text = ""
        cbodescripcion.Text = ""
        txtcantidad.Text = ""
        grdPiezas.Rows.Clear()
        txtSerie.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If grdPiezas.Rows.Count > 0 Then

                For sasuke As Integer = 0 To grdPiezas.Rows.Count - 1

                    Dim codigo As String = grdPiezas.Rows(sasuke).Cells(0).Value.ToString
                    Dim descrip As String = grdPiezas.Rows(sasuke).Cells(1).Value.ToString
                    Dim canti As Double = grdPiezas.Rows(sasuke).Cells(2).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Codigo FROM productos WHERE Codigo='" & codigo & "' AND Nombre='" & descrip & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "UPDATE productos SET Existencia=Existencia + " & canti & " WHERE Codigo='" & codigo & "'"
                            cmd2.ExecuteNonQuery()
                            cnn2.Close()

                            MsgBox("El producto con el codigo " & codigo & " y nombre " & descrip & " ya esta registrado", vbInformation + vbOKOnly, titulotaller)

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO productos(Codigo,Nombre,NombreLargo,ProvPri,ProvEme,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Min,Max,Existencia,Fecha,Fecha_Inicial,Fecha_Final,id_tbMoneda) VALUES('" & codigo & "','" & descrip & "','" & descrip & "','CANIBALEO','CANIBALEO','PZA','PZA','PZA',1,1,'" & txtMarca.Text & "','" & txtModelo.Text & "',1,1," & canti & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "','1')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()

                Next
                cnn1.Close()
                MsgBox("Las piezas fueron asignadas a productos", vbInformation + vbOKOnly, titulotaller)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea salir?", vbInformation + vbYesNo, titulotaller) = vbYes Then
            Me.Close()
            frmTallerT.Show()
        End If
    End Sub
End Class