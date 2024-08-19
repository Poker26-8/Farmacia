Public Class frmVentasTouchBuscar

    Private Sub cbofiltro_DropDown(sender As System.Object, e As System.EventArgs) Handles cbofiltro.DropDown
        cbofiltro.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If (optproveedor.Checked) Then
                cmd1.CommandText =
                    "select distinct ProvPri from Productos order by ProvPri"
            End If
            If (optgrupo.Checked) Then
                cmd1.CommandText =
                    "select distinct Grupo from Productos order by Grupo"
            End If
            If (optdepartamento.Checked) Then
                cmd1.CommandText =
                    "select distinct Departamento from Productos order by Departamento"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbofiltro.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofiltro_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbofiltro.SelectedValueChanged
        Dim conteo As Double = 0
        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd2 = cnn2.CreateCommand
            If (optproveedor.Checked) Then
                cmd1.CommandText =
                    "select Codigo,Nombre,UVenta,PrecioVentaIVA,Existencia from Productos where ProvPri='" & cbofiltro.Text & "'"
                cmd2.CommandText =
                    "select count(Codigo) from Productos where ProvPri='" & cbofiltro.Text & "'"
            End If
            If (optdepartamento.Checked) Then
                cmd1.CommandText =
                    "select Codigo,Nombre,UVenta,PrecioVentaIVA,Existencia from Productos where Departamento='" & cbofiltro.Text & "'"
                cmd2.CommandText =
                    "select count(Codigo) from Productos where Departamento='" & cbofiltro.Text & "'"
            End If
            If (optgrupo.Checked) Then
                cmd1.CommandText =
                    "select Codigo,Nombre,UVenta,PrecioVentaIVA,Existencia from Productos where Grupo='" & cbofiltro.Text & "'"
                cmd2.CommandText =
                    "select count(Codigo) from Productos where Grupo='" & cbofiltro.Text & "'"
            End If
            rd2 = cmd2.ExecuteReader
            rd1 = cmd1.ExecuteReader

            If rd2.HasRows Then
                If rd2.Read Then
                    conteo = rd2(0).ToString
                End If
            End If
            rd2.Close() : cnn2.Close()

            barCuenta.Value = 0
            barCuenta.Visible = True
            barCuenta.Maximum = conteo

            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("UVenta").ToString
                    Dim precio As Double = rd1("PrecioVentaIVA").ToString
                    Dim existencia As Double = rd1("Existencia").ToString

                    grdcaptura.Rows.Add(codigo, nombre, unidad, FormatNumber(precio, 2), existencia)
                    barCuenta.Value = barCuenta.Value + 1
                End If
            Loop
            rd1.Close() : cnn1.Close()
            barCuenta.Visible = False
            barCuenta.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdcaptura_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellClick
        With frmVentasTouch
            .CodigoProducto = grdcaptura.CurrentRow.Cells(0).Value.ToString
            .cantidad = 1
            .ObtenerProducto(grdcaptura.CurrentRow.Cells(0).Value.ToString)
        End With
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cbofiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofiltro.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub frmVentasTouchBuscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class