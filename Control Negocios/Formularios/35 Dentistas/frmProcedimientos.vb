Public Class frmProcedimientos

    Dim PRECIO As Double = 0
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
            PRECIO = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Codigo,PrecioVentaIVA FROM productos WHERE Nombre='" & cboDescripcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCodigo.Text = rd1(0).ToString
                    PRECIO = rd1(1).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
            txtCodigo.Focus.Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboDescripcion.Text = "" Then MsgBox("Seleccione un producto", vbInformation + vbOKOnly, titulocentral) : cboDescripcion.Focus.Equals(True) : Exit Sub

            grdCaptura.Rows.Add(txtCodigo.Text,
                                cboDescripcion.Text,
                                PRECIO
)
            cboDescripcion.Text = ""
            txtCodigo.Text = ""
            PRECIO = 0
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtCodigo.Text = ""
        cboDescripcion.Text = ""
        PRECIO = 0
        grdCaptura.Rows.Clear()
    End Sub
End Class