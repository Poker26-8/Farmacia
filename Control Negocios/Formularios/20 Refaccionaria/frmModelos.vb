Public Class frmModelos
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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

    Private Sub cboMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboAno.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            grdModelos.Rows.Add(cboMarca.Text, cboModelo.Text, cboAno.Text)
            grdModelos.FirstDisplayedScrollingRowIndex = grdModelos.RowCount - 1
            cboModelo.Text = ""
        End If
    End Sub

    Private Sub cboAno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboAno.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(cboAno.Text) Then
                cboModelo.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub btnAlmacenar_Click(sender As Object, e As EventArgs) Handles btnAlmacenar.Click
        Try

            If cboAno.Text = "" Then MsgBox("Seleccione el año del modelo", vbInformation + vbOKOnly, titulorefaccionaria) : cboAno.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM marcas WHERE Nombre='" & cboMarca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO marcas(Nombre) VALUES('" & cboMarca.Text & "')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM vehiculo2 WHERE Modelo='" & cboModelo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else

                For luufy As Integer = 0 To grdModelos.Rows.Count - 1
                    Dim marca As String = grdModelos.Rows(luufy).Cells(0).Value.ToString
                    Dim modelo As String = grdModelos.Rows(luufy).Cells(1).Value.ToString
                    Dim an As String = grdModelos.Rows(luufy).Cells(2).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT * FROM vehiculo2 WHERE Modelo='" & modelo & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then

                        End If
                    Else
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "INSERT INTO vehiculo2(Marca,Modelo,ano) VALUES('" & marca & "','" & modelo & "','" & an & "')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                    cnn1.Close()


                Next
                MsgBox("Datos almacenados correctamente", vbInformation + vbOKOnly, titulorefaccionaria)
                grdModelos.Rows.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdModelos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdModelos.CellDoubleClick
        Dim index As Integer = grdModelos.CurrentRow.Index

        grdModelos.Rows.Remove(grdModelos.Rows(index))
    End Sub

    Private Sub cboAno_DropDown(sender As Object, e As EventArgs) Handles cboAno.DropDown
        Try
            cboAno.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Ano FROM vehiculo2 WHERE Ano<>'' ORDER BY Ano"
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

    Private Sub frmModelos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class