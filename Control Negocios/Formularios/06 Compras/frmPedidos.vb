Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPedidos
    Dim alias_pedidos As String = ""
    Dim tipo_impre As String = ""

    Friend WithEvents pestaña As System.Windows.Forms.TabPage
    Friend WithEvents grilla As System.Windows.Forms.DataGridView

    Dim grid_activo As DataGridView

    Private Sub frmPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tab_Pedidos.TabPages.Clear()


    End Sub

    Public Sub Crea_Pestaña(ByVal nombre As String)


        Dim punto As New Point()
        Dim cuantos As Integer = tab_Pedidos.TabCount

        punto = New Point(3, 3)

        pestaña = New TabPage
        pestaña.Text = nombre
        pestaña.Name = "tab_P(" & cuantos + 1 & ")"
        pestaña.Tag = cuantos + 1
        pestaña.Enabled = True
        pestaña.BackColor = Color.White

        grilla = New DataGridView
        grilla.Width = 1155
        grilla.Height = 179
        grilla.BackgroundColor = Color.White
        grilla.GridColor = Color.White
        grilla.Anchor = AnchorStyles.Top
        grilla.Anchor = AnchorStyles.Left
        grilla.Anchor = AnchorStyles.Right
        grilla.Location = punto
        grilla.AllowDrop = True
        grilla.AllowUserToDeleteRows = False
        grilla.AllowUserToAddRows = False
        grilla.RowHeadersVisible = False

        grilla.EditMode = DataGridViewEditMode.EditProgrammatically

        grilla.ColumnCount = 5
        With grilla
            With .Columns(0)
                .HeaderText = "Código"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .ReadOnly = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "Nombre"
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .ReadOnly = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "Cantidad"
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Visible = True
                .ReadOnly = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Precio"
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .ReadOnly = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Importe"
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .ReadOnly = True
                .Resizable = DataGridViewTriState.False
            End With
        End With

        tab_Pedidos.TabPages.Add(pestaña)

        AddHandler grilla.CellDoubleClick, AddressOf grilla_CellDoubleClick


        pestaña.Controls.Add(grilla)
    End Sub

    Private Sub grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim grd_activo As DataGridView = CType(sender, DataGridView)


        Dim codigo As String = grd_activo.CurrentRow.Cells(0).Value.ToString()

        grdcaptura.Rows.Add(codigo)
    End Sub


    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Productos where Length(Codigo)<7 and Departamento <> 'SERVICIOS' order by Nombre"
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

    Private Sub cbonombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Nombre='" & cbonombre.Text & "' and Length(Codigo)<7 and Departamento<>'SERVICIOS'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1("Codigo").ToString
                    txtunidad.Text = rd1("UCompra").ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbonombre.Text = "" Then txtcodigo.Focus().Equals(True) : Exit Sub
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cbonombre.Text & "' and Length(Codigo)<7 and Departamento<>'SERVICIOS'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtcodigo.Text = rd1("Codigo").ToString
                        txtunidad.Text = rd1("UCompra").ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where CodBarra='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cbonombre.Text = rd1("Nombre").ToString
                        txtcodigo.Text = rd1("Codigo").ToString
                        txtunidad.Text = rd1("UCompra").ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            txtcodigo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcodigo_Click(sender As System.Object, e As System.EventArgs) Handles txtcodigo.Click
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_GotFocus(sender As Object, e As System.EventArgs) Handles txtcodigo.GotFocus
        txtcodigo.SelectionStart = 0
        txtcodigo.SelectionLength = Len(txtcodigo.Text)
    End Sub

    Private Sub txtcodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcodigo.Text <> "" Then
                Dim MoneValor As Double = 0

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select tipo_cambio,nombre_moneda from tb_moneda,Productos where Codigo='" & txtcodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            lblMoneda.Text = rd1("nombre_moneda").ToString()
                            lblValor.Text = rd1("tipo_cambio").ToString()
                            MoneValor = rd1("tipo_cambio").ToString()
                            If lblValor.Text = "" Then lblValor.Text = "1"
                        End If
                    Else
                        lblValor.Text = "1.00"
                    End If
                    rd1.Close()

                    If Trim(lblMoneda.Text) <> Trim(cbomoneda.Text) Then
                        MsgBox("No se puede continuar porque el tipo de moneda del pedido no coincide con el tipo de moneda del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If

                    If txtmoneda.Text = "" Then
                        MsgBox("Ingresa el valor de la moneda.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        If txtmoneda.Enabled = True Then
                            txtmoneda.Focus().Equals(True)
                        End If
                        cnn1.Close()
                        Exit Sub
                    End If

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & txtcodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cbonombre.Text = rd1("Nombre").ToString()
                            txtunidad.Text = rd1("UCompra").ToString()
                            lblValor.Text = FormatNumber(CDec(rd1("PrecioCompra").ToString()) / MoneValor, 4)
                            txtexistencia.Text = rd1("Existencia").ToString()
                            txtcantidad.Focus().Equals(True)
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If CDbl(txtcantidad.Text) = 0 Then MsgBox("Ingrese una cantidad mayor a 0 para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.SelectAll() : Exit Sub
            If Not IsNumeric(txtcantidad.Text) Then MsgBox("Ingrese una cantidad válida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcantidad.SelectAll() : Exit Sub

            UpGrid1()
        End If
    End Sub

    Private Sub UpGrid1()
        Dim nombre_p As String = ""
        Dim unidad_p As String = ""
        Dim existe_p As Double = 0
        Dim cantid_p As Double = 0
        Dim minimo_p As Double = 0
        Dim maximo_p As Double = 0
        Dim precio_p As Double = 0
        Dim importe_p As Double = 0

        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Productos where Codigo='" & txtcodigo.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    nombre_p = rd2("Nombre").ToString()
                    unidad_p = rd2("UCompra").ToString()
                    existe_p = rd2("Existencia").ToString()
                    cantid_p = txtcantidad.Text
                    minimo_p = rd2("Min").ToString()
                    maximo_p = rd2("Max").ToString()
                    precio_p = rd2("PrecioCompra").ToString()
                    importe_p = cantid_p * precio_p
                End If
            End If
            rd2.Close()
            cnn2.Close()

            grdcaptura.Rows.Add(txtcodigo.Text, nombre_p, unidad_p, existe_p, cantid_p, 0, minimo_p & vbNewLine & maximo_p, 0, FormatNumber(precio_p, 2), FormatNumber(importe_p, 2))

            LimpiaB()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub LimpiaB()
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtcodigo.Text = ""
        txtunidad.Text = ""
        txtexistencia.Text = ""
        txtcantidad.Text = ""
        cbonombre.Focus().Equals(True)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Abre formulario para seleccionar el proveedor
        frmElige_Proveedores.Show()
        frmElige_Proveedores.BringToFront()
    End Sub

    Private Sub tab_Pedidos_Selected(sender As Object, e As TabControlEventArgs) Handles tab_Pedidos.Selected
        If tab_Pedidos.TabCount = 0 Then
            Exit Sub
        End If
        Dim grdcaptura As DataGridView = CType(grilla, DataGridView)
        grid_activo = grdcaptura
        'MsgBox(tab_Pedidos.SelectedTab.Tag)
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim codigo As String = grdcaptura.CurrentRow.Cells(0).Value.ToString()

        grid_activo.Rows.Add(codigo)
    End Sub

    Private Sub btnguarda_Click(sender As Object, e As EventArgs) Handles btnguarda.Click
        frmSalidas_Pedidos.Show()
        frmSalidas_Pedidos.BringToFront()
    End Sub

    Private Sub txtcodigo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcodigo.KeyUp

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class