Public Class frmAsignacionRef

    Public marcaveh As String = ""
    Public placa As String = ""
    Public idvehiculo As Integer = 0
    Private Sub frmAsignacionRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtNumParte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumParte.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            txtCantidad.Focus.Equals(True)

        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim codigopro As String = ""
            Dim preciopro As Double = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If txtNumParte.Text <> "" Then
                cmd1.CommandText = "SELECT Codigo,Nombre,N_Serie,PrecioVentaIVA FROM productos  WHERE N_Serie='" & txtNumParte.Text & "'"
            End If

            If cboDescripcion.Text <> "" Then
                cmd1.CommandText = "SELECT Codigo,Nombre,N_Serie,PrecioVentaIVA FROM productos  WHERE Nombre='" & cboDescripcion.Text & "'"
            End If

            rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                    codigopro = rd1(0).ToString
                    preciopro = rd1(3).ToString

                    grdRefaccion.Rows.Add(codigopro,
                                          rd1(1).ToString,
                                          rd1(2).ToString,
                                          FormatNumber(txtCantidad.Text, 2),
                                          FormatNumber(preciopro, 2))

                End If
                End If
                rd1.Close()
            cnn1.Close()

            txtCantidad.Text = "1"
            txtNumParte.Text = ""
            cboDescripcion.Text = ""
            cboDescripcion.Focus.Equals(True)

        End If
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
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCantidad.Focus.Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdRefaccion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdRefaccion.CellDoubleClick
        Dim index As Integer = grdRefaccion.CurrentRow.Index

        grdRefaccion.Rows.Remove(grdRefaccion.CurrentRow)
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Try
            If grdRefaccion.Rows.Count > 0 Then
                For luffy As Integer = 0 To grdRefaccion.Rows.Count - 1

                    Dim codigo As String = grdRefaccion.Rows(luffy).Cells(0).Value.ToString
                    Dim nombre As String = grdRefaccion.Rows(luffy).Cells(1).Value.ToString
                    Dim parte As String = grdRefaccion.Rows(luffy).Cells(2).Value.ToString
                    Dim cantidad As String = grdRefaccion.Rows(luffy).Cells(3).Value.ToString
                    Dim PRECIO As Double = grdRefaccion.Rows(luffy).Cells(4).Value.ToString


                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO comandasveh(IdVehiculo,Vehiculo,Placa,Cliente,Codigo,Nombre,NParte,Cantidad,Precio,Fecha) VALUES(" & idvehiculo & ",'" & txtVeh.Text & "','" & placa & "','" & txtCliente.Text & "','" & codigo & "','" & nombre & "','" & parte & "'," & cantidad & ",'" & PRECIO & "','" & Format(Date.Now, "yyyy-MM-dd") & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                Next
                MsgBox("Refacciones agregadas correctamente.", vbInformation + vbOKOnly, titulorefaccionaria)
                grdRefaccion.Rows.Clear()
                frmTallerR.TVehiculo.Start()
            Else
                MsgBox("Debes de seleccionar las refacciones", vbInformation + vbOKOnly, titulorefaccionaria)
                Exit Sub
            End If
            frmTallerR.pVehiculos.Controls.Clear()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub
End Class