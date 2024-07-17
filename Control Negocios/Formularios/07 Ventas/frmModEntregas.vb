Public Class frmModEntregas

    Dim folioentrega As Integer = 0
    Dim Busqueda As Boolean = False
    Private Sub frmModEntregas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        opttodas.Checked = True
        dtpini.Value = Date.Now
        dtpfini.Value = Date.Now
        'btnreporte.Focus().Equals(True)
    End Sub

    Private Sub btnreporte_Click(sender As System.Object, e As System.EventArgs) Handles btnreporte.Click
        grdcaptura.Rows.Clear()

        If (optpendientes.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText =
                    "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 order by Folio"
                Else
                    cmd1.CommandText =
                    "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 and Cliente='" & ComboBox1.Text & "' order by Folio"
                End If
                rd1 = cmd1.ExecuteReader
                cnn2.Close() : cnn2.Open()
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim folio As Integer = rd1("Folio").ToString()
                        Dim nombre As String = rd1("Cliente").ToString()
                        Dim address As String = rd1("Direccion").ToString()
                        Dim subtot As Double = rd1("Subtotal").ToString()
                        Dim iva_ve As Double = rd1("IVA").ToString()
                        Dim total As Double = rd1("Totales").ToString()
                        Dim vendidos As Double = 0
                        Dim entregados As Double = rd1("CantidadE").ToString()
                        Dim comenta As String = rd1("Comentario").ToString()
                        Dim fecha As String = rd1("FEntrega").ToString()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select SUM(Cantidad) from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                vendidos = rd2(0).ToString()
                            End If
                        End If
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select CantidadE from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.Read Then
                            entregados = rd2(0).ToString()
                        End If

                        rd2.Close()

                        If entregados < vendidos Then
                            grdcaptura.Rows.Add(folio, nombre, address, FormatNumber(subtot, 2), FormatNumber(iva_ve, 2), FormatNumber(total, 2), vendidos, entregados, fecha)
                        End If
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

        If (optrealizadas.Checked) Then
            Dim fecha1 As String = ""
            Dim fecha2 As String = ""

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd1.CommandText =
                    "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 order by Folio"
                Else
                    cmd1.CommandText =
                    "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 and Cliente='" & ComboBox1.Text & "' order by Folio"
                End If
                rd1 = cmd1.ExecuteReader

                Do While rd1.Read

                    Dim folio As Integer = rd1("Folio").ToString()
                    Dim nombre As String = rd1("Cliente").ToString()
                    Dim address As String = rd1("Direccion").ToString()
                    Dim subtot As Double = rd1("Subtotal").ToString()
                    Dim iva_ve As Double = rd1("IVA").ToString()
                    Dim total As Double = rd1("Totales").ToString()
                    Dim vendidos As Double = 0
                    Dim entregados As Double = rd1("CantidadE").ToString()
                    Dim comenta As String = rd1("Comentario").ToString()
                    Dim fecha As String = rd1("FEntrega").ToString()

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                            "select SUM(Cantidad) from VentasDetalle where Folio=" & folio
                    rd2 = cmd2.ExecuteReader

                    If rd2.Read Then
                        vendidos = rd2(0).ToString()
                    End If

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                            "select SUM(CantidadE) from VentasDetalle where Folio=" & folio
                    rd2 = cmd2.ExecuteReader
                    If rd2.Read Then
                        entregados = rd2(0).ToString()
                    End If



                    rd2.Close()

                    If entregados >= vendidos Then
                        grdcaptura.Rows.Add(folio, nombre, address, FormatNumber(subtot, 2), FormatNumber(iva_ve, 2), FormatNumber(total, 2), vendidos, entregados, fecha)
                    End If

                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                'productosventas()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub optrealizadas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optrealizadas.CheckedChanged
        If (optrealizadas.Checked) Then

            btnEntrega.Visible = False
            ComboBox1.Text = ""
            cboFolio.Text = ""
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            grdcaptura.ColumnCount = 9
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Nombre"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Direccion"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Subtotal"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "IVA"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Total"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Productos vendidos"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Productos entregados"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Fecha de entrega"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub optpendientes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optpendientes.CheckedChanged
        If (optpendientes.Checked) Then
            Label2.Visible = False
            dtpini.Visible = False
            Label3.Visible = False
            dtpfini.Visible = False
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0
            ComboBox1.Text = ""
            cboFolio.Text = ""

            btnEntrega.Visible = False

            grdcaptura.ColumnCount = 9
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Nombre"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Direccion"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Subtotal"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "IVA"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Total"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Productos vendidos"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Productos entregados"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Fecha de entrega"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub opttodas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles opttodas.CheckedChanged
        If (opttodas.Checked) Then
            Label2.Visible = False
            dtpini.Visible = False
            Label3.Visible = False
            dtpfini.Visible = False

            btnEntrega.Visible = False
            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0

            grdcaptura.ColumnCount = 9
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Nombre"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Direccion"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Subtotal"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "IVA"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Total"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Productos vendidos"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Productos entregados"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "Fecha de entrega"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

        End If
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim celda As DataGridViewCellEventArgs = e
        Dim indice As Integer = 0
        indice = grdcaptura.CurrentRow.Index
        If celda.ColumnIndex = 0 Then
            frmModEntregasDetalle.lblfolio.Text = "FOLIO: " & grdcaptura.CurrentRow.Cells(0).Value.ToString
            frmModEntregasDetalle.lblcliente.Text = grdcaptura.CurrentRow.Cells(1).Value.ToString
            frmModEntregasDetalle.txtdireccion.Text = grdcaptura.CurrentRow.Cells(2).Value.ToString
            ' frmModEntregasDetalle.lblEntrega.Text = folioentrega
            frmModEntregasDetalle.Show()
            'ElseIf celda.ColumnIndex = 8 Then
            '    'MsgBox(celda.ToString)
            '    GroupBox1.Visible = True
            '    RichTextBox1.Text = grdcaptura.Rows(indice).Cells(8).Value.ToString
            '    RichTextBox1.Focus().Equals(True)
        End If
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        If Busqueda = True Then
            Busqueda = False
        Else
            ComboBox1.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                If (rbEntrega.Checked) Then
                    cmd1.CommandText =
                        "select distinct Cliente from Ventas where Entrega=0 and Cliente<>'' order by Cliente "
                Else
                    cmd1.CommandText =
                        "select distinct Cliente from Ventas where Entrega=1 and Cliente<>'' order by Cliente "
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        ComboBox1.Items.Add(rd1(0).ToString)
                    End If
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cboFolio_DropDown(sender As Object, e As EventArgs) Handles cboFolio.DropDown
        Try
            cboFolio.Items.Clear()
            cnn5.Close() : cnn5.Open()


            If (optpendientes.Checked) Or (optrealizadas.Checked) Then
                cmd5 = cnn5.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd5.CommandText =
                        "select Folio from Ventas where Entrega=1 order by Folio"
                Else
                    cmd5.CommandText =
                        "select Folio from Ventas where Cliente='" & ComboBox1.Text & "' and Entrega=1 order by Folio"
                End If
            Else
                cmd5 = cnn5.CreateCommand
                If ComboBox1.Text = "" Then
                    cmd5.CommandText =
                        "select Folio from Ventas where Entrega=0 order by Folio"
                Else
                    cmd5.CommandText =
                        "select Folio from Ventas where Cliente='" & ComboBox1.Text & "' and Entrega=0 order by Folio"
                End If
            End If
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboFolio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub rbEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles rbEntrega.CheckedChanged
        If (rbEntrega.Checked) Then
            optpendientes.Checked = False
            optrealizadas.Checked = False
            opttodas.Checked = False

            btnEntrega.Visible = True
            ComboBox1.Text = ""
            cboFolio.Text = ""

            grdcaptura.Rows.Clear()
            grdcaptura.ColumnCount = 0

            grdcaptura.ColumnCount = 6
            With grdcaptura
                With .Columns(0)
                    .HeaderText = "Código"
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Descripcion"
                    .Width = 200
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Unidad"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Cantidad"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Precio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Total"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFolio.SelectedValueChanged
        grdcaptura.Rows.Clear()

        If (optpendientes.Checked) Or (optrealizadas.Checked) Then
            If (optpendientes.Checked) Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    If ComboBox1.Text = "" Then
                        cmd1.CommandText =
                        "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 and Folio=" & cboFolio.Text
                    Else
                        cmd1.CommandText =
                        "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 and Cliente='" & ComboBox1.Text & "' and Folio=" & cboFolio.Text & ""
                    End If
                    rd1 = cmd1.ExecuteReader
                    cnn2.Close() : cnn2.Open()
                    Do While rd1.Read
                        If rd1.HasRows Then
                            Dim folio As Integer = rd1("Folio").ToString()
                            Dim nombre As String = rd1("Cliente").ToString()
                            Dim address As String = rd1("Direccion").ToString()
                            Dim subtot As Double = rd1("Subtotal").ToString()
                            Dim iva_ve As Double = rd1("IVA").ToString()
                            Dim total As Double = rd1("Totales").ToString()
                            Dim vendidos As Double = 0
                            Dim entregados As Double = rd1("CantidadE").ToString()
                            Dim comenta As String = rd1("Comentario").ToString()
                            Dim fecha As String = rd1("FEntrega").ToString()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select SUM(Cantidad) from VentasDetalle where Folio=" & folio
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    vendidos = rd2(0).ToString()
                                End If
                            End If
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select CantidadE from VentasDetalle where Folio=" & folio
                            rd2 = cmd2.ExecuteReader
                            If rd2.Read Then
                                entregados = rd2(0).ToString()
                            End If

                            rd2.Close()

                            If entregados < vendidos Then
                                grdcaptura.Rows.Add(folio, nombre, address, FormatNumber(subtot, 2), FormatNumber(iva_ve, 2), FormatNumber(total, 2), vendidos, entregados, fecha)
                            End If
                        End If
                    Loop
                    rd1.Close()
                    cnn1.Close()
                    cnn2.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If

            If (optrealizadas.Checked) Then
                Dim fecha1 As String = ""
                Dim fecha2 As String = ""

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    If ComboBox1.Text = "" Then
                        cmd1.CommandText =
                        "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 and Folio=" & cboFolio.Text
                    Else
                        cmd1.CommandText =
                        "select Folio,Cliente,Direccion,Subtotal,IVA,Totales,CantidadE,Comentario,FEntrega from Ventas where Entrega=1 and Cliente='" & ComboBox1.Text & "' and Folio=" & cboFolio.Text
                    End If
                    rd1 = cmd1.ExecuteReader

                    Do While rd1.Read

                        Dim folio As Integer = rd1("Folio").ToString()
                        Dim nombre As String = rd1("Cliente").ToString()
                        Dim address As String = rd1("Direccion").ToString()
                        Dim subtot As Double = rd1("Subtotal").ToString()
                        Dim iva_ve As Double = rd1("IVA").ToString()
                        Dim total As Double = rd1("Totales").ToString()
                        Dim vendidos As Double = 0
                        Dim entregados As Double = rd1("CantidadE").ToString()
                        Dim comenta As String = rd1("Comentario").ToString()
                        Dim fecha As String = rd1("FEntrega").ToString()

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                                "select SUM(Cantidad) from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader

                        If rd2.Read Then
                            vendidos = rd2(0).ToString()
                        End If

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                                "select CantidadE from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.Read Then
                            entregados = rd2(0).ToString()
                        End If

                        rd2.Close()

                        If entregados >= vendidos Then
                            grdcaptura.Rows.Add(folio, nombre, address, FormatNumber(subtot, 2), FormatNumber(iva_ve, 2), FormatNumber(total, 2), vendidos, entregados, fecha)
                        End If

                    Loop
                    rd1.Close()
                    cnn1.Close()
                    cnn2.Close()

                    'productosventas()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If
        Else
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT Codigo, Nombre, Unidad, Cantidad, Precio FROM VentasDetalle WHERE Folio='" & cboFolio.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Dim codigo As String = rd1(0).ToString
                        Dim nombre As String = rd1(1).ToString
                        Dim unidad As String = rd1(2).ToString
                        Dim cantidad As Double = rd1(3).ToString
                        Dim precio As Double = rd1(4).ToString

                        Dim total As Double = CDbl(cantidad) * CDbl(precio)

                        grdcaptura.Rows.Add(codigo, nombre, unidad, cantidad, precio, total)
                    End If
                Loop
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub btnEntrega_Click(sender As Object, e As EventArgs) Handles btnEntrega.Click
        If (rbEntrega.Checked) Then
            Dim fecha As String = Format(dtpFecha.Value, "yyyy-MM-dd")
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "SELECT * FROM Ventas WHERE Entrega=0 AND Folio=" & cboFolio.Text
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "UPDATE Ventas SET Entrega=1,FEntrega='" & fecha & "' WHERE Folio=" & cboFolio.Text & ""
                    If cmd3.ExecuteNonQuery Then

                        cnn4.Close() : cnn4.Open()

                        cmd4 = cnn4.CreateCommand
                        cmd4.CommandText =
                            "select Codigo,Cantidad from VentasDetalle where Folio=" & cboFolio.Text
                        rd4 = cmd4.ExecuteReader

                        cnn1.Close() : cnn1.Open()

                        Do While rd4.Read
                            If rd4.HasRows Then
                                Dim codigo As String = rd4("Codigo").ToString()
                                Dim cantdad As Double = rd4("Cantidad").ToString()

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                    "update Productos set Cant_Ent=Cant_Ent+" & cantdad & " where Codigo='" & codigo & "'"
                                cmd1.ExecuteNonQuery()
                            End If
                        Loop
                        rd4.Close() : cnn4.Close()
                        cnn1.Close()

                        MsgBox("La nota de venta " & cboFolio.Text & " se asignó para su entrega.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    cnn3.Close()
                End If
            End If
            rd2.Close() : cnn2.Close()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked) Then
            Panel2.Visible = True
            txtNombreClave.Focus().Equals(True)
        Else
            Busqueda = False
            Panel2.Visible = False
            txtNombreClave.Text = ""
            ComboBox1.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtNombreClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            ComboBox1.Items.Clear()

            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                If (rbEntrega.Checked) Then
                    cmd2.CommandText =
                        "select distinct Nombre from Ventas where Nombre like '%" & txtNombreClave.Text & "%' and Entrega=0 order by Nombre"
                Else
                    cmd2.CommandText =
                        "select distinct Nombre from Ventas where Nombre like '%" & txtNombreClave.Text & "%' and Entrega=1 order by Nombre"
                End If
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    If rd2.HasRows Then ComboBox1.Items.Add(rd2(0).ToString())
                Loop
                rd2.Close()
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
            Busqueda = True
            Panel2.Visible = False
            CheckBox1.Checked = False
            ComboBox1.Focus().Equals(True)
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboFolio.Focus().Equals(True)
        End If
    End Sub

    Private Sub frmModEntregas_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        btnreporte.PerformClick()
    End Sub
End Class