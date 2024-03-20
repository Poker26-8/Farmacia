Public Class frmPrecioH
    Private Sub frmPrecioH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtnombre.Focus.Equals(True)

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='ToleHabi'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txttole.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre,Horas,Precio FROM detallehotelprecios"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    grdPrecios.Rows.Add(rd1(0).ToString,
                   rd1(1).ToString,
                        rd1(2).ToString
                   )

                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtHoras.Focus.Equals(True)
        End If
    End Sub
    Private Sub txtHoras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHoras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtHoras.Text) Then
                txtPrecio.Focus.Equals(True)
            Else
                txtHoras.Text = ""
            txtHoras.Focus.Equals(True)
        End If
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPrecio.Text) Then

                grdPrecios.Rows.Add(txtnombre.Text, txtHoras.Text, txtPrecio.Text)

                txtnombre.Text = ""
                txtHoras.Text = ""
                txtPrecio.Text = "0.00"

                txtnombre.Focus.Equals(True)
            Else
                txtPrecio.Text = "0.00"
                txtPrecio.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='ToleHabi'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE formatos set NotasCred='" & txttole.Text & "' WHERE Facturas='ToleHabi' "
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            End If
            rd1.Close()

            For luffy As Integer = 0 To grdPrecios.Rows.Count - 1

                Dim nombre As String = grdPrecios.Rows(luffy).Cells(0).Value.ToString
                Dim HORAS As Double = grdPrecios.Rows(luffy).Cells(1).Value.ToString
                Dim PRECIO As Double = grdPrecios.Rows(luffy).Cells(2).Value.ToString

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM detallehotelprecios WHERE Horas='" & HORAS & "' AND Nombre='" & nombre & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE detallehotelprecios SET Nombre='" & nombre & "', Precio=" & PRECIO & " WHERE Horas=" & HORAS & ""
                        rd2 = cmd2.ExecuteReader
                        cnn2.Close()

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO detallehotelprecios(Nombre,Horas,Precio) VALUES('" & nombre & "'," & HORAS & "," & PRECIO & ")"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
                rd1.Close()

            Next
            cnn1.Close()
            MsgBox("Datos guardados correctamente", vbInformation + vbOKOnly, titulohotelriaa)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txttole_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttole.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnG.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub grdPrecios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPrecios.CellDoubleClick

        Dim INDEX As Double = grdPrecios.CurrentRow.Index

        txtnombre.Text = grdPrecios.Rows(INDEX).Cells(0).Value.ToString
        txtHoras.Text = grdPrecios.Rows(INDEX).Cells(1).Value.ToString
        txtPrecio.Text = grdPrecios.Rows(INDEX).Cells(2).Value.ToString

        grdPrecios.Rows.Remove(grdPrecios.CurrentRow)

    End Sub
End Class