Public Class frmFaltantes

    Private Sub frmFaltantes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub optproveedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optproveedor.CheckedChanged
        If (optproveedor.Checked) Then
            cbofiltro.Enabled = True
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            grdcaptura.Rows.Clear()
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optdepto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optdepto.CheckedChanged
        If (optdepto.Checked) Then
            cbofiltro.Enabled = True
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            grdcaptura.Rows.Clear()
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optgrupo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optgrupo.CheckedChanged
        If (optgrupo.Checked) Then
            cbofiltro.Enabled = True
            cbofiltro.Text = ""
            cbofiltro.Items.Clear()
            grdcaptura.Rows.Clear()
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofiltro_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofiltro.DropDown
        cbofiltro.Items.Clear()
        Try
            Dim consluta As String = ""
            If (optproveedor.Checked) Then consluta = "select distinct ProvPri from Productos where Codigo = Left(Codigo,6)"
            If (optdepto.Checked) Then consluta = "select distinct Departamento from Productos where Codigo = Left(Codigo,6)"
            If (optgrupo.Checked) Then consluta = "select distinct Grupo from Productos where Codigo = Left(Codigo,6)"

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                consluta
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbofiltro.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofiltro_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbofiltro.SelectedValueChanged
        Dim consulta As String = ""
        If (optproveedor.Checked) Then consulta = "select * from Productos where ProvPri='" & cbofiltro.Text & "' and Mid(Codigo, 1, 6) order by Nombre"
        If (optdepto.Checked) Then consulta = "select * from Productos where Departamento='" & cbofiltro.Text & "' and Mid(Codigo, 1, 6) order by Nombre"
        If (optgrupo.Checked) Then consulta = "select * from Productos where Grupo='" & cbofiltro.Text & "' and Mid(Codigo, 1, 6) orddr by Nombre"

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                consulta
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString()
                    Dim barras As String = rd1("CodBarra").ToString()
                    Dim nombre As String = rd1("Nombre").ToString()
                    Dim unidad As String = rd1("UCompra").ToString()

                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub
End Class