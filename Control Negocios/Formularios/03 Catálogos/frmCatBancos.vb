Public Class frmCatBancos

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Banco from Bancos ORDER BY Banco"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        cbonombre.Items.Clear()
        cbonombre.Text = ""
    End Sub

    Private Sub cbonombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If cbonombre.Text = "" Then MsgBox("Selecciona un banco del combo para eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas eliminar este registro de banco?" & vbNewLine & "Esta acción no se puede deshacer.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from Bancos where Banco='" & cbonombre.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Nombre de banco eliminado.", vbInformation + vbOKOnly, "Delsscom Control Neocios Pro")
                    btnNuevo.PerformClick()
                Else
                    MsgBox("No se encontró un banco registrado bajo ese nombre." & vbNewLine & "Corrobara que hayas seleccionado un banco existente en el catálogo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cbonombre.SelectionStart = 0
                    cbonombre.SelectionLength = Len(cbonombre.Text)
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If cbonombre.Text = "" Then MsgBox("Escribe el nombre del banco para poder guardarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbonombre.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas guardar el nombre de este banco?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim existe As Boolean = False

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Banco from Bancos where Banco='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    existe = True
                    MsgBox("Ya tienes un banco registrado con ese nombre.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    cbonombre.Focus().Equals(True)
                    Exit Sub
                Else
                    existe = False
                End If
                rd1.Close()

                If Not (existe) Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Bancos(Banco) values('" & cbonombre.Text & "')"
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("Nombre de banco registrado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        btnNuevo.PerformClick()
                    End If
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub frmCatBancos_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cbonombre.Focus().Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmCatBancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class