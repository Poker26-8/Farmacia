Public Class frmNuvCompras

    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim pagina As Integer = 0
    Private Sub frmNuvCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpfecha.Value = Now
        dtpcaducidad.Value = Now
        dtpfpago.Value = Now
        txtcodigo.Text = ""
        dtpFecha_P.Value = Now

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TomaContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                tomacontralog = rd1(0).ToString


                If tomacontralog = "1" Then

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Clave,Alias FROM Usuarios WHERE IdEmpleado=" & id_usu_log
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtusuario.Text = rd2(0).ToString
                            lblusuario.Text = rd2(1).ToString
                            txtusuario.PasswordChar = "*"
                            txtusuario.ForeColor = Color.Black
                        End If
                    End If
                    rd2.Close()
                End If

            End If
        End If
        rd1.Close()
        cnn1.Close()
        cnn2.Close()

        grdcaptura.Rows.Clear()
        grdcaptura.DefaultCellStyle.ForeColor = Color.Black
        PrintLine = 0
        Contador = 0
        pagina = 0
        VieneDe_Compras = ""

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from tb_moneda where nombre_moneda='PESO' or nombre_moneda='PESOS'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                txtvalor.Text = FormatNumber(rd1("tipo_cambio").ToString, 4)
                cbomoneda.Tag = rd1("id").ToString
                cbomoneda.Items.Add(rd1("nombre_moneda").ToString)
                cbomoneda.SelectedIndex = 0
            End If
        Else
            cbomoneda.Tag = "0"
        End If
        rd1.Close()
        If cnn1.State = 0 Then cnn1.Open()

        'Variables de cálculo
        Dim varTotal As Double = 0
        Dim varTotalIVA As Double = 0
        Dim varTotalIEPS As Double = 0
        Dim varConteo As Double = 0

        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT * FROM AuxCompras order by Id"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then
                cboremision.Text = rd1("Rem").ToString
                cbofactura.Text = rd1("Fac").ToString
                cbopedido.Text = rd1("Ped").ToString
                cboproveedor.Text = rd1("Proveedor").ToString

                Dim codigo As String = rd1("Codigo").ToString
                Dim nombre As String = rd1("Nombre").ToString
                Dim unidad As String = rd1("Unidad").ToString
                Dim cantidad As Double = rd1("Cantidad").ToString
                Dim precio As Double = rd1("Precio").ToString
                Dim total As Double = cantidad * precio
                Dim caducidad As String = rd1("Caducidad").ToString
                Dim lote As String = rd1("Lote").ToString
                Dim cp As Boolean = rd1("CP").ToString
                Dim existencia As Double = 0
                Dim IVA As Double = 0

                varTotalIEPS = varTotalIEPS + CDbl(total * ProdsIEPS(codigo))

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where Codigo='" & codigo & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        existencia = rd2("Existencia").ToString
                        IVA = rd2("IVA").ToString
                        If IVA > 0 Then
                            If rd1("Fac").ToString <> "" Then
                                varTotalIVA = varTotalIVA + CDbl(0.16 * ((total) + (total * ProdsIEPS(codigo))))
                            End If
                        End If
                    End If
                End If
                rd2.Close()

                grdcaptura.Rows.Add(
                    codigo,
                    nombre,
                    unidad,
                    cantidad,
                    FormatNumber(precio, 4),
                    FormatNumber(total, 2),
                    existencia,
                    caducidad,
                    lote,
                    cp
                    )

                varConteo = varConteo + cantidad
                varTotal = varTotal + total
            End If
        Loop
        rd1.Close()
        cnn1.Close()
        cnn2.Close()

        Call cboproveedor_SelectedValueChanged(cboproveedor, New EventArgs())

        If cboremision.Text <> "" And cbofactura.Text <> "" Then
            txtieps.Text = FormatNumber("0", 2)
            txtsub1.Text = FormatNumber(varTotal, 2)
            txtsub2.Text = FormatNumber(varTotal, 2)
            txtiva.Text = FormatNumber(varTotalIVA, 2)
            txtTotalC.Text = FormatNumber(varTotal + varTotalIVA, 2)
            txtapagar.Text = FormatNumber(varTotal + varTotalIVA, 2)
            txtresta.Text = FormatNumber(varTotal + varTotalIVA, 2)
        Else
            txtieps.Text = FormatNumber(varTotalIEPS, 2)
            txtsub1.Text = FormatNumber(varTotal + varTotalIEPS, 2)
            txtsub2.Text = FormatNumber(varTotal + varTotalIEPS, 2)
            txtiva.Text = FormatNumber(varTotalIVA, 2)
            txtTotalC.Text = FormatNumber(varTotal + varTotalIVA + varTotalIEPS, 2)
            txtapagar.Text = FormatNumber(varTotal + varTotalIVA + varTotalIEPS, 2)
            txtresta.Text = FormatNumber(varTotal + varTotalIVA + varTotalIEPS, 2)
        End If

        cbonombre.Focus().Equals(True)

    End Sub

    Private Sub cboproveedor_DropDown(sender As Object, e As EventArgs) Handles cboproveedor.DropDown
        Try
            cboproveedor.Items.Clear()
            btnnuevo.PerformClick()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Compania FROM proveedores WHERE Compania<>'' ORDER BY Compania"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboproveedor.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboproveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboproveedor.SelectedValueChanged
        If cboproveedor.Text <> "" Then
            txtsaldo.Text = "0.00"
            Dim dias As Integer = 0
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Proveedores WHERE Compania='" & cboproveedor.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        dias = rd1("DiasCred").ToString
                        dtpfpago.Value = DateAdd(DateInterval.Day, dias, Date.Now)
                    End If
                End If
                rd1.Close()

                Dim MySaldo As Double = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoE where Id=(select MAX(Id) from AbonoE where Proveedor='" & cboproveedor.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = FormatNumber(CDbl(IIf(rd1(0).ToString() = "", 0, rd1(0).ToString())), 2)
                        Button1.Enabled = True
                        txtpAnticipo.Enabled = True
                        lblpAnticipo.Enabled = True
                    Else
                        txtsaldo.Text = "0.00"
                        Button1.Enabled = False
                        txtpAnticipo.Enabled = False
                        lblpAnticipo.Enabled = False
                    End If
                Else
                    txtsaldo.Text = "0.00"
                    Button1.Enabled = False
                    txtpAnticipo.Enabled = False
                    lblpAnticipo.Enabled = False
                End If
                rd1.Close() : cnn1.Close()

                If MySaldo < 0 Then
                    txtsaldo.Text = FormatNumber(Math.Abs(MySaldo), 2)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cboproveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboproveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboremision.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboremision_Click(sender As Object, e As EventArgs) Handles cboremision.Click
        cboremision.SelectionStart = 0
        cboremision.SelectionLength = Len(cboremision.Text)
    End Sub

    Private Sub cboremision_DropDown(sender As Object, e As EventArgs) Handles cboremision.DropDown
        Try
            cboremision.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT NumRemision FROM Compras WHERE Proveedor='" & cboproveedor.Text & "' AND NumRemision<>''"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboremision.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
End Class