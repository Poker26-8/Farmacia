Public Class frmBuscaVentas

    Public Vienna As String = ""

    Private Sub frmBuscaVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        optproveedor.PerformClick()
    End Sub

    Private Sub optproveedor_Click(sender As System.Object, e As System.EventArgs) Handles optproveedor.Click
        If (optproveedor.Checked) Then
            ComboBox1.Text = ""
            ComboBox1.Enabled = True
            TextBox1.Text = ""
            TextBox1.Enabled = False
            ComboBox1.Items.Clear()
            grdcaptura.Rows.Clear()
        End If
    End Sub

    Private Sub optdepto_Click(sender As System.Object, e As System.EventArgs) Handles optdepto.Click
        If (optdepto.Checked) Then
            ComboBox1.Text = ""
            ComboBox1.Enabled = True
            TextBox1.Text = ""
            TextBox1.Enabled = False
            ComboBox1.Items.Clear()
            grdcaptura.Rows.Clear()
        End If
    End Sub

    Private Sub optgrupo_Click(sender As System.Object, e As System.EventArgs) Handles optgrupo.Click
        If (optgrupo.Checked) Then
            ComboBox1.Text = ""
            ComboBox1.Enabled = True
            TextBox1.Text = ""
            TextBox1.Enabled = False
            ComboBox1.Items.Clear()
            grdcaptura.Rows.Clear()
        End If
    End Sub

    Private Sub optcoincidencias_Click(sender As System.Object, e As System.EventArgs) Handles optcoincidencias.Click
        If (optcoincidencias.Checked) Then
            ComboBox1.Text = ""
            ComboBox1.Enabled = False
            TextBox1.Text = ""
            TextBox1.Enabled = True
            ComboBox1.Items.Clear()
            grdcaptura.Rows.Clear()
        End If
    End Sub

    Private Sub ComboBox1_DropDown(sender As System.Object, e As System.EventArgs) Handles ComboBox1.DropDown
        Dim querry As String = ""
        ComboBox1.Items.Clear()
        If (optproveedor.Checked) Then
            querry = "select distinct ProvPri from Productos order by ProvPri"
        End If
        If (optdepto.Checked) Then
            querry = "select distinct Departamento from Productos order by Departamento"
        End If
        If (optgrupo.Checked) Then
            querry = "select distinct Grupo from Productos order by Grupo"
        End If
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                querry
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then ComboBox1.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        grdcaptura.Rows.Clear()
        Try
            Dim querry1 As String = ""
            Dim querry2 As String = ""
            Dim cuantas As Integer = 0

            If (optproveedor.Checked) Then
                querry1 = "select * from Productos where ProvPri='" & ComboBox1.Text & "' order by Nombre"
                querry2 = "select count(Codigo) from Productos where ProvPri='" & ComboBox1.Text & "'"
            End If
            If (optdepto.Checked) Then
                querry1 = "select * from Productos where Departamento='" & ComboBox1.Text & "' order by Nombre"
                querry2 = "select count(Codigo) from Productos where Departamento='" & ComboBox1.Text & "'"
            End If
            If (optgrupo.Checked) Then
                querry1 = "select * from Productos where Grupo='" & ComboBox1.Text & "' order by Nombre"
                querry2 = "select count(Codigo) from Productos where Grupo='" & ComboBox1.Text & "'"
            End If
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                querry2
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cuantas = rd1(0).ToString
                End If
            End If
            rd1.Close()

            ba.Value = 0
            ba.Visible = True
            ba.Maximum = cuantas

            cnn2.Close() : cnn2.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                querry1
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString
                    Dim nombre As String = rd1("Nombre").ToString
                    Dim unidad As String = rd1("UVenta").ToString
                    Dim precio_min As Double = 0, precio_ven As Double = 0
                    Dim existencia As Double = 0, multiplo As Double = rd1("Multiplo").ToString
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from Productos where Codigo='" & codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            precio_min = rd2("PreMin").ToString
                            precio_ven = rd2("PrecioVentaIVA").ToString
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select Existencia from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            existencia = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()
                    grdcaptura.Rows.Add(codigo, nombre, unidad, FormatNumber(precio_min, 2), FormatNumber(precio_ven, 2), (existencia / multiplo))
                    ba.Value = ba.Value + 1
                End If
            Loop
            cnn2.Close()
            rd1.Close() : cnn1.Close()
            ba.Value = 0
            ba.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdcaptura_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcaptura.CellClick
        Dim jiji As Integer = grdcaptura.CurrentRow.Index

        If Vienna = "Ventas1" Then
            'frmVentas1_Partes.cbocodigo.Text = grdcaptura.Rows(jiji).Cells(0).Value.ToString
            'frmVentas1_Partes.cbodesc.Text = grdcaptura.Rows(jiji).Cells(1).Value.ToString
            'frmVentas1_Partes.txtunidad.Text = grdcaptura.Rows(jiji).Cells(2).Value.ToString
            'frmVentas1_Partes.txtprecio.Text = grdcaptura.Rows(jiji).Cells(4).Value.ToString
            'frmVentas1_Partes.txtexistencia.Text = grdcaptura.Rows(jiji).Cells(5).Value.ToString
            'frmVentas1_Partes.cbocodigo.Focus().Equals(True)
            frmVentas1.cbocodigo.Text = grdcaptura.Rows(jiji).Cells(0).Value.ToString
            frmVentas1.cbodesc.Text = grdcaptura.Rows(jiji).Cells(1).Value.ToString
            frmVentas1.txtunidad.Text = grdcaptura.Rows(jiji).Cells(2).Value.ToString
            frmVentas1.txtprecio.Text = grdcaptura.Rows(jiji).Cells(4).Value.ToString
            frmVentas1.txtexistencia.Text = grdcaptura.Rows(jiji).Cells(5).Value.ToString
            frmVentas1.cbocodigo.Focus().Equals(True)
        End If
        If Vienna = "Ventas2" Then
            frmVentas2_Descuentos.cbocodigo.Text = grdcaptura.Rows(jiji).Cells(0).Value.ToString
            frmVentas2_Descuentos.cbodesc.Text = grdcaptura.Rows(jiji).Cells(1).Value.ToString
            frmVentas2_Descuentos.txtunidad.Text = grdcaptura.Rows(jiji).Cells(2).Value.ToString
            frmVentas2_Descuentos.txtprecio.Text = grdcaptura.Rows(jiji).Cells(4).Value.ToString
            frmVentas2_Descuentos.txtexistencia.Text = grdcaptura.Rows(jiji).Cells(5).Value.ToString
            frmVentas2_Descuentos.cbocodigo.Focus().Equals(True)
        End If
        'If Vienna = "Ventas3" Then
        '    frmVentas3.cbocodigo.Text = grdcaptura.Rows(jiji).Cells(0).Value.ToString
        '    frmVentas3.cbodesc.Text = grdcaptura.Rows(jiji).Cells(1).Value.ToString
        '    frmVentas3.txtunidad.Text = grdcaptura.Rows(jiji).Cells(2).Value.ToString
        '    frmVentas3.txtprecio.Text = grdcaptura.Rows(jiji).Cells(4).Value.ToString
        '    frmVentas3.txtexistencia.Text = grdcaptura.Rows(jiji).Cells(5).Value.ToString
        '    frmVentas3.cbocodigo.Focus().Equals(True)
        'End If
        Me.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            grdcaptura.Rows.Clear()
            My.Application.DoEvents()
            If TextBox1.Text = "" Then Exit Sub

            Try
                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select * from Productos where Nombre LIKE '%" & TextBox1.Text & "%'"
                rd3 = cmd3.ExecuteReader
                cnn2.Close() : cnn2.Open()
                Do While rd3.Read
                    If rd3.HasRows Then
                        Dim codigo As String = rd3("Codigo").ToString
                        Dim nombre As String = rd3("Nombre").ToString
                        Dim unidad As String = rd3("UVenta").ToString
                        Dim precio_min As Double = 0, precio_ven As Double = 0
                        Dim existencia As Double = 0, multiplo As Double = rd3("Multiplo").ToString
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from Productos where Codigo='" & codigo & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                precio_min = rd2("PreMin").ToString
                                precio_ven = rd2("PrecioVentaIVA").ToString
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Existencia from Productos where Codigo='" & Strings.Left(codigo, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                existencia = rd2(0).ToString
                            End If
                        End If
                        rd2.Close()
                        grdcaptura.Rows.Add(codigo, nombre, unidad, FormatNumber(precio_min, 2), FormatNumber(precio_ven, 2), (existencia / multiplo))
                    End If
                Loop
                rd3.Close()
                cnn3.Close()
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try
        End If
    End Sub
End Class