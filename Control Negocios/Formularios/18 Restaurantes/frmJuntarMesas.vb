Public Class frmJuntarMesas
    Private Sub frmJuntarMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            grdMesas.Rows.Clear()
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Nombre_mesa FROM Mesa WHERE Nombre_mesa<>'' ORDER BY Nombre_mesa"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdMesas.Rows.Add(rd1(0).ToString)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdJuntar.Rows.Clear()
        txtmesa.Text = ""
    End Sub

    Private Sub grdMesas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdMesas.CellClick

        Dim index As Integer = grdMesas.CurrentRow.Index
        Dim nombre As String = ""
        Dim bandera As Integer = 0

        nombre = grdMesas.Rows(index).Cells(0).Value.ToString

        If txtmesa.Text = "" Then
            txtmesa.Text = nombre
            If txtmesa.Text = nombre Then
                txtmesa.Text = nombre
            Else
                txtmesa.Text = ""
            End If
        End If

        For q As Integer = 0 To grdJuntar.Rows.Count - 1
            If grdJuntar.Rows(q).Cells(0).Value = nombre Then
                'grdJuntar.Rows.Add(nombre)
                bandera = 1
            End If
        Next

        If bandera = 0 Then
            grdJuntar.Rows.Add(nombre)
        End If

    End Sub

    Private Sub grdJuntar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdJuntar.CellClick
        Dim index As Integer = grdJuntar.CurrentRow.Index
        grdJuntar.Rows.Remove(grdJuntar.CurrentRow)

        If grdJuntar.Rows.Count = 0 Then
            txtmesa.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("¿Desea juntar las mesas?, ya no se podra revirtir", vbInformation + vbYesNo, titulomensajes) = vbYes Then

                For deku As Integer = 0 To grdJuntar.Rows.Count - 1

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Mesa Set TempNom='" & txtmesa.Text & "' WHERE Nombre_mesa='" & grdJuntar.Rows(deku).Cells(0).Value.ToString & "'"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Comanda1 SET Nombre='" & txtmesa.Text & "' WHERE Nombre='" & grdJuntar.Rows(deku).Cells(0).Value.ToString & "'"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Comandas SET NMESA = '" & txtmesa.Text & "' WHERE NMESA ='" & grdJuntar.Rows(deku).Cells(0).Value.ToString & "' "
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                Next

            End If


            Dim lugar As String = ""

            btnSalir.Focus.Equals(True)
            frmMesas.btnLimpiar.PerformClick()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub
End Class