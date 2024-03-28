Public Class frmPreciosBarras
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmProductosS.cbPrecios.Checked = False
    End Sub

    Private Sub frmPreciosBarras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtbarras.Focus.Equals(True)

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT CodBarra1,CodBarra2,CodBarra3,PrecioVentaIVA1,PrecioVentaIVA2,PrecioVentaIVA3 FROM productos WHERE Codigo='" & txtCodigo.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtbarras.Text = rd2("CodBarra1").ToString
                    txtBarras2.Text = rd2("CodBarra2").ToString
                    txtBarras3.Text = rd2("CodBarra3").ToString
                    txtPrecio1.Text = rd2("PrecioVentaIVA1").ToString
                    txtPrecio2.Text = rd2("PrecioVentaIVA2").ToString
                    txtPrecio3.Text = rd2("PrecioVentaIVA3").ToString
                End If
            End If
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub frmPreciosBarras_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtbarras.Focus.Equals(True)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtbarras.Text = ""
        txtBarras2.Text = ""
        txtBarras3.Text = ""

        txtPrecio1.Text = "0.00"
        txtPrecio2.Text = "0.00"
        txtPrecio3.Text = "0.00"
        txtPrecio4.Text = "0.00"
        txtPrecio5.Text = "0.00"
        txtPrecio6.Text = "0.00"
        txtPrecio7.Text = "0.00"
        txtPrecio8.Text = "0.00"
        txtPrecio9.Text = "0.00"
        txtPrecio10.Text = "0.00"
    End Sub

    Private Sub txtbarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarras.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtBarras2.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtBarras2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarras2.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtBarras3.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtBarras3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarras3.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

        End If
    End Sub

    Private Sub btnGP_Click(sender As Object, e As EventArgs) Handles btnGP.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM productos WHERE Codigo='" & txtCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE productos SET CodBarra1='" & txtbarras.Text & "',CodBarra2='" & txtBarras2.Text & "',CodBarra3='" & txtBarras3.Text & "' WHERE Codigo='" & txtCodigo.Text & "' AND Nombre='" & txtNombre.Text & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE productos SET PrecioVentaIVA1=" & txtPrecio1.Text & ",PrecioVentaIVA2=" & txtPrecio2.Text & ",PrecioVentaIVA3=" & txtPrecio3.Text & " WHERE Codigo='" & txtCodigo.Text & "'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
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