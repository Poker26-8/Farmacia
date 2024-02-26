Public Class frmComprasSeries

    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim pagina As Integer = 0
    Private Sub frmComprasSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfecha.Value = Now
        dtpfpago.Value = Now
        txtcodigo.Text = ""

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

        panpago_compra.Visible = False
        txtpc_apagar.Text = "0.00"
        txtpc_anticipo.Text = "0.00"
        txtpc_efectivo.Text = "0.00"
        txtpc_tarjeta.Text = "0.00"
        txtpc_transfe.Text = "0.00"
        txtpc_otro.Text = "0.00"
        txtpc_resta.Text = "0.00"

        Pagos.pc_porpagar = 0
        Pagos.pc_anticipo = 0
        Pagos.pc_efectivo = 0
        Pagos.pc_tarjeta = 0
        Pagos.pc_transfe = 0
        Pagos.pc_otros = 0
        Pagos.pc_resta = 0

        grdcaptura.Rows.Clear()
        grdcaptura.DefaultCellStyle.ForeColor = Color.Black
        PrintLine = 0
        Contador = 0
        pagina = 0
        VieneDe_Compras = ""

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT * FROM tb_moneda WHERE nombre_moneda='PESO' or nombre_moneda='PESOS'"
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

    Public Structure Pagos
        Shared pc_porpagar As Double = 0
        Shared pc_anticipo As Double = 0
        Shared pc_efectivo As Double = 0
        Shared pc_tarjeta As Double = 0
        Shared pc_transfe As Double = 0
        Shared pc_otros As Double = 0
        Shared pc_resta As Double = 0
    End Structure

    Private Sub cboproveedor_DropDown(sender As Object, e As EventArgs) Handles cboproveedor.DropDown

        cboproveedor.Items.Clear()
        btnnuevo.PerformClick()

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Compania FROM Proveedores WHERE Compania<>'' order by Compania"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboproveedor.Items.Add(
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

    Private Sub cboproveedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboproveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboremision.Focus.Equals(True)
        End If
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
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub
End Class