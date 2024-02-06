Public Class frmProductoOcasionalTouch
    Public focomesasmostrar As Integer = 0
    Private Sub frmProductoOcasionalTouch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdescripcionocasional.Focus.Equals(True)
    End Sub

    Private Sub btnlimpiaroca_Click(sender As Object, e As EventArgs) Handles btnlimpiaroca.Click
        txtdescripcionocasional.Text = ""
        txtprecioocasional.Text = ""
        txtcantidadocasional.Text = ""
        txtdescripcionocasional.Focus.Equals(True)
    End Sub

    Private Sub btnsaliroca_Click(sender As Object, e As EventArgs) Handles btnsaliroca.Click
        Me.Close()
    End Sub

    Private Sub btnagregaroca_Click(sender As Object, e As EventArgs) Handles btnagregaroca.Click
        Try

            Dim total As Double = 0
            total = FormatNumber(CDec(txtcantidadocasional.Text) * CDec(txtprecioocasional.Text), 2)

            If focomesasmostrar = 1 Then

                frmVTouchR.grdCaptura.Rows.Add(lblcodigo.Text, lblcodigo.Text & vbNewLine & txtdescripcionocasional.Text,
                                                       txtcantidadocasional.Text,
                                                       txtprecioocasional.Text,
                                                       total,
                                                       1
                )

                frmVTouchR.lblTotalPagar.Text = frmVTouchR.lblTotalPagar.Text + total
                frmVTouchR.lblTotalPagar.Text = FormatNumber(frmVTouchR.lblTotalPagar.Text, 2)

            End If

            If focomesasmostrar = 0 Then
                frmVTouchR.grdCaptura.Rows.Add(lblcodigo.Text, lblcodigo.Text & vbNewLine & txtdescripcionocasional.Text,
                                                       txtcantidadocasional.Text,
                                                       txtprecioocasional.Text,
                                                       total,
                                                       1
                )

                frmVTouchR.lblTotalPagar.Text = frmVTouchR.lblTotalPagar.Text + total
                frmVTouchR.lblTotalPagar.Text = FormatNumber(frmVTouchR.lblTotalPagar.Text, 2)
            End If
            btnlimpiaroca.PerformClick()
            txtdescripcionocasional.Focus.Equals(True)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtdescripcionocasional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescripcionocasional.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtprecioocasional.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtprecioocasional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecioocasional.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcantidadocasional.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtcantidadocasional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidadocasional.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnagregaroca.Focus.Equals(True)
        End If
    End Sub
End Class