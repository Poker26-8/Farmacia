Public Class frmBuscaPedidos

    Private Sub optproveedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optproveedor.CheckedChanged
        If (optproveedor.Checked) Then
            grdcaptura.ColumnCount = 0
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 8
            cboprod.Enabled = True
            txtprod.Enabled = False
            boxsalidas.Enabled = False

            With grdcaptura
                'Código
                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = 70
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Nombre
                .Columns(1).HeaderText = "Nombre"
                .Columns(1).Width = 200
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                'Unidad
                .Columns(2).HeaderText = "Unidad"
                .Columns(2).Width = 60
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Precio
                .Columns(3).HeaderText = "Precio C."
                .Columns(3).Width = 90
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Existencia
                .Columns(4).HeaderText = "Existencia"
                .Columns(4).Width = 100
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Mínimo
                .Columns(5).HeaderText = "Mínimo"
                .Columns(5).Width = 100
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                '
                .Columns(6).HeaderText = ""
                .Columns(6).Width = 5

                '
                .Columns(7).HeaderText = ""
                .Columns(7).Width = 5
            End With
        End If
    End Sub

    Private Sub frmBuscaPedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        optproveedor.Checked = True
    End Sub

    Private Sub cboprod_DropDown(sender As System.Object, e As System.EventArgs) Handles cboprod.DropDown
        cboprod.Items.Clear()
        Dim query As String = ""
        If (optproveedor.Checked) Then
            query = "select distinct ProvPri from Productos order by ProvPri"
        End If
        If (optdepartamento.Checked) Then
            query = "select distinct Departamento from Productos where Departamento<>'SERVICIOS' order by Departamento"
        End If
        If (optgrupo.Checked) Then
            query = "select distinct Grupo from Productos where Grupo<>'INSUMO' and Grupo<>'SERVICIOS' order by Grupo"
        End If
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                query
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboprod.Items.Add(
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

    Private Sub optdepartamento_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optdepartamento.CheckedChanged
        If (optdepartamento.Checked) Then
            grdcaptura.ColumnCount = 0
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 8
            cboprod.Enabled = True
            txtprod.Enabled = False
            boxsalidas.Enabled = False

            With grdcaptura
                'Código
                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = 70
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Nombre
                .Columns(1).HeaderText = "Nombre"
                .Columns(1).Width = 200
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                'Unidad
                .Columns(2).HeaderText = "Unidad"
                .Columns(2).Width = 60
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Precio
                .Columns(3).HeaderText = "Precio C."
                .Columns(3).Width = 90
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Existencia
                .Columns(4).HeaderText = "Existencia"
                .Columns(4).Width = 100
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Mínimo
                .Columns(5).HeaderText = "Mínimo"
                .Columns(5).Width = 100
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                '
                .Columns(6).HeaderText = ""
                .Columns(6).Width = 5

                '
                .Columns(7).HeaderText = ""
                .Columns(7).Width = 5
            End With
        End If
    End Sub

    Private Sub optgrupo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optgrupo.CheckedChanged
        If (optgrupo.Checked) Then
            grdcaptura.ColumnCount = 0
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 8
            cboprod.Enabled = True
            txtprod.Enabled = False
            boxsalidas.Enabled = False

            With grdcaptura
                'Código
                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = 70
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Nombre
                .Columns(1).HeaderText = "Nombre"
                .Columns(1).Width = 200
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                'Unidad
                .Columns(2).HeaderText = "Unidad"
                .Columns(2).Width = 60
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Precio
                .Columns(3).HeaderText = "Precio C."
                .Columns(3).Width = 90
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Existencia
                .Columns(4).HeaderText = "Existencia"
                .Columns(4).Width = 100
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Mínimo
                .Columns(5).HeaderText = "Mínimo"
                .Columns(5).Width = 100
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                '
                .Columns(6).HeaderText = ""
                .Columns(6).Width = 5

                '
                .Columns(7).HeaderText = ""
                .Columns(7).Width = 5
            End With
        End If
    End Sub

    Private Sub optcoincide_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optcoincide.CheckedChanged
        If (optcoincide.Checked) Then
            grdcaptura.ColumnCount = 0
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 8
            cboprod.Enabled = False
            txtprod.Enabled = True
            boxsalidas.Enabled = False

            With grdcaptura
                'Código
                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = 70
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Nombre
                .Columns(1).HeaderText = "Nombre"
                .Columns(1).Width = 200
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                'Unidad
                .Columns(2).HeaderText = "Unidad"
                .Columns(2).Width = 60
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Precio
                .Columns(3).HeaderText = "Precio C."
                .Columns(3).Width = 90
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Existencia
                .Columns(4).HeaderText = "Existencia"
                .Columns(4).Width = 100
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Mínimo
                .Columns(5).HeaderText = "Mínimo"
                .Columns(5).Width = 100
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                '
                .Columns(6).HeaderText = ""
                .Columns(6).Width = 5

                '
                .Columns(7).HeaderText = ""
                .Columns(7).Width = 5
            End With
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optsalidas.CheckedChanged
        If (optsalidas.Checked) Then
            grdcaptura.ColumnCount = 0
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 8
            cboprod.Enabled = False
            txtprod.Enabled = False
            boxsalidas.Enabled = True

            With grdcaptura
                'Código
                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = 70
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Nombre
                .Columns(1).HeaderText = "Nombre"
                .Columns(1).Width = 200
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                'Unidad
                .Columns(2).HeaderText = "Unidad"
                .Columns(2).Width = 60
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Precio
                .Columns(3).HeaderText = "Precio C."
                .Columns(3).Width = 90
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Existencia
                .Columns(4).HeaderText = "Salidas"
                .Columns(4).Width = 100
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Mínimo
                .Columns(5).HeaderText = "Existencia"
                .Columns(5).Width = 100
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                '
                .Columns(6).HeaderText = "Mínimo"
                .Columns(6).Width = 90
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                '
                .Columns(7).HeaderText = ""
                .Columns(7).Width = 5
            End With
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim conteo As Integer = 0
        Dim querry1 As String = ""
        Dim querry2 As String = ""

        'Proveedor
        If (optproveedor.Checked) Then
            querry1 = "select count(Codigo) from Productos where ProvPri='" & cboprod.Text & "' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
            querry2 = "select * from Productos where ProvPri='" & cboprod.Text & "' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
        End If

        'Departamento
        If (optdepartamento.Checked) Then
            querry1 = "select count(Codigo) from Productos where Departamento='" & cboprod.Text & "' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
            querry2 = "select * from Productos where Departamento='" & cboprod.Text & "' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
        End If

        'Grupo
        If (optgrupo.Checked) Then
            querry1 = "select count(Codigo) from Productos where Grupo='" & cboprod.Text & "' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
            querry2 = "select * from Productos where Grupo='" & cboprod.Text & "' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
        End If

        'Coincidencia
        If (optcoincide.Checked) Then
            querry1 = "select count(Codigo) from Productos where Nombre like '%" & txtprod.Text & "%' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
            querry2 = "select * from Productos where Nombre like '%" & txtprod.Text & "%' and Departamento<>'SERVICIOS' and Grupo<>'INSUMO' and Grupo<>'SERVICIOS'"
        End If

        If (optproveedor.Checked) Or (optdepartamento.Checked) Or (optgrupo.Checked) Or (optcoincide.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    querry1
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        conteo = rd1(0).ToString
                        barCuenta.Value = 0
                        barCuenta.Visible = True
                        barCuenta.Maximum = conteo
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    querry2
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("UCompra").ToString
                    Dim compra As Double = rd1("PrecioCompra").ToString
                    Dim existencia As Double = rd1("Existencia").ToString
                    Dim minimo As Double = rd1("Min").ToString

                    grdcaptura.Rows.Add(
                        codigo,
                        nombre,
                        unidad,
                        FormatNumber(compra, 2),
                        existencia,
                        minimo
                        )

                    grdcaptura.Refresh()
                    barCuenta.Value += 1
                Loop
                rd1.Close()

                barCuenta.Visible = False
                barCuenta.Value = 0

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

        Dim fecha1 As Date = dtpInicia.Value
        Dim fecha2 As Date = dtpTermina.Value

        If (optsalidas.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from Rep_Salidas"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select distinct Codigo,Nombre,Unidad from VentasDetalle where Fecha between '" & Format(fecha1, "yyyy-MM-dd") & "' and '" & Format(fecha2, "yyyy-MM-dd") & "' and (Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio<>0) order by Codigo"
                rd1 = cmd1.ExecuteReader
                cnn2.Close() : cnn2.Open()
                Do While rd1.Read
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("Unidad").ToString
                    Dim cantidad As Double = 0

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select SUM(Cantidad) from VentasDetalle where Codigo='" & codigo & "' and Fecha between '" & Format(fecha1, "yyyy-MM-dd") & "' and '" & Format(fecha2, "yyyy-MM-dd") & "' and (Facturado<>'DEVOLUCION' and Facturado<>'CANCELADO' and Folio<>0)"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cantidad = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into Rep_Salidas(Codigo,Nombre,Cantidad,Unidad) values('" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "')"
                    cmd2.ExecuteNonQuery()
                Loop
                cnn2.Close()
                rd1.Close()

                Dim cuntos As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select count(Codigo) from Rep_Salidas"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuntos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                Dim precio As Double = 0
                Dim existe As Double = 0
                Dim minimo As Double = 0

                barCuenta.Value = 0
                barCuenta.Visible = True
                barCuenta.Maximum = cuntos

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Rep_Salidas order by Cantidad DESC"
                rd1 = cmd1.ExecuteReader
                cnn2.Close() : cnn2.Open()
                Do While rd1.Read
                    If rd1.HasRows Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from Productos where Codigo='" & rd1("Codigo").ToString & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                precio = rd2("PrecioCompra").ToString
                                existe = rd2("Existencia").ToString
                                minimo = rd2("Min").ToString
                            End If
                        End If
                        rd2.Close()

                        grdcaptura.Rows.Add(rd1("Codigo").ToString, rd1("Nombre").ToString, rd1("Unidad").ToString, FormatNumber(precio, 2), rd1("Cantidad").ToString, existe, minimo)
                        barCuenta.Value = barCuenta.Value + 1
                    End If
                Loop
                barCuenta.Value = 0
                barCuenta.Visible = False
                cnn2.Close()
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        If grdcaptura.Rows.Count > 0 Then
            Dim index As Integer = grdcaptura.CurrentRow.Index

            frmPedidos.txtcodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
            frmPedidos.cbonombre.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
            frmPedidos.txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
            frmPedidos.txtprecio.Text = FormatNumber(grdcaptura.Rows(index).Cells(3).Value.ToString, 2)
            frmPedidos.txtexistencia.Text = grdcaptura.Rows(index).Cells(4).Value.ToString
            frmPedidos.txtminimo.Text = grdcaptura.Rows(index).Cells(5).Value.ToString

            Me.Close()
            frmPedidos.txtcodigo.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        grdcaptura.Rows.Clear()
        boxsalidas.Enabled = False
        optproveedor.Checked = True
        barCuenta.Value = 0
        barCuenta.Visible = False
        cboprod.Text = ""
        txtprod.Text = ""
    End Sub

    Private Sub cboprod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboprod.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
End Class