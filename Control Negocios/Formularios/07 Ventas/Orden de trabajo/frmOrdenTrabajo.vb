Public Class frmOrdenTrabajo
    Private Sub cbonombre_DropDown(sender As Object, e As EventArgs) Handles cbonombre.DropDown
        Try
            cbonombre.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from OrdenTrabajo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cbonombre.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    'Private Sub cbocod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocod.KeyPress
    '    If AscW(e.KeyChar) = Keys.Enter Then
    '        Try
    '            Dim myexist As Double = 0
    '            cnn1.Close()
    '            cnn1.Open()
    '            cmd1 = cnn1.CreateCommand
    '            cmd1.CommandText = "Select * from OrdenTrabajo where Codigo='" & cbocod.Text & "'"
    '            rd1 = cmd1.ExecuteReader
    '            If rd1.Read Then
    '                cbonombre.Text = rd1("Nombre").ToString
    '                txtuni.Text = rd1("UVenta").ToString
    '                txtexistencia.Text = rd1("Existencia").ToString
    '                txtPrecio.Text = rd1("PrecioVentaIVA").ToString
    '                txttotal.Text = rd1("PrecioUnitario").ToString

    '                cnn2.Close()
    '                cnn2.Open()
    '                cmd2 = cnn2.CreateCommand
    '                cmd2.CommandText = "Select Existencia from Productos where Codigo='" & cbocod.Text & "'"
    '                rd2 = cmd2.ExecuteReader
    '                If rd2.Read Then
    '                    myexist = rd2(0).ToString

    '                    rd2.Close()
    '                    cmd2 = cnn2.CreateCommand
    '                    cmd2.CommandText = "Select * from MiProd where Codigo='" & cbocod.Text & "'"
    '                    rd2 = cmd2.ExecuteReader
    '                    Do While rd2.Read
    '                        grdcaptura.Rows.Add(rd2("CodigoP").ToString, rd2("Descrip").ToString, rd2("UVenta").ToString, rd2("Cantidad").ToString, rd2("Precio").ToString, rd2("PRecioIVA").ToString, myexist)
    '                    Loop
    '                    rd2.Close()
    '                End If
    '                cnn2.Close()
    '            End If
    '            rd1.Close()
    '            cnn1.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '            cnn1.Close()
    '        End Try
    '    End If
    'End Sub

    Private Sub cboCodigoListo_DropDown(sender As Object, e As EventArgs) Handles cboCodigoListo.DropDown
        Try
            cboCodigoListo.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Codigo from OrdenTrabajo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboCodigoListo.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCodigoListo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCodigoListo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                grdcaptura.Rows.Clear()
                Dim myexist As Double = 0
                Dim mypre As Double = 0
                Dim mytotal As Double = 0

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from OrdenTrabajo where Codigo='" & cboCodigoListo.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    Dim mycodigo As String = ""
                    cbocod.Text = rd1("Codigo").ToString
                    cbonombre.Text = rd1("Nombre").ToString
                    txtuni.Text = rd1("UVenta").ToString
                    txtexistencia.Text = "1"

                    
                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select * from MiProd where CodigoP='" & cboCodigoListo.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.Read Then
                        mycodigo = rd2("Codigo").ToString
                    End If
                    rd2.Close()
                    cnn2.Close()

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select Existencia from Productos where Codigo='" & mycodigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.Read Then
                        myexist = rd2(0).ToString

                        rd2.Close()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "Select * from MiProd where CodigoP='" & cboCodigoListo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read

                            cnn3.Close()
                            cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "Select Existencia,PrecioVentaIVA from Productos where Codigo='" & rd2("Codigo").ToString & "'"
                            rd3 = cmd3.ExecuteReader
                            If rd3.Read Then
                                myexist = rd3(0).ToString
                                mypre = rd3(1).ToString
                            End If
                            rd3.Close()
                            cnn3.Close()
                            mytotal = mypre * CDec(rd2("Cantidad").ToString)
                            grdcaptura.Rows.Add(rd2("Codigo").ToString, rd2("Descrip").ToString, rd2("UVenta").ToString, rd2("Cantidad").ToString, FormatNumber(mypre, 2), FormatNumber(mytotal, 2), myexist)
                        Loop
                        rd2.Close()
                        'txtPrecio.Text = FormatNumber(mytotal, 2)
                        'txttotal.Text = FormatNumber(mytotal, 2)
                    End If
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()
                txtexistencia.Focus.Equals(True)
                My.Application.DoEvents()
                SumaTotal()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub frmOrdenTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Turno As Integer = 0
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select MAX(Consecutivo) from OrdenTrabajo"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1(0).ToString = "" Then
                    Turno = 1
                    lblCodigo.Text = "OT" & Turno
                Else
                    Turno = rd1(0).ToString
                    Turno = Turno + CDec(1)
                    lblCodigo.Text = "OT" & Turno
                End If
            Else
                Turno = 1
                lblCodigo.Text = "OT" & Turno
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        Try
            ComboBox2.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Productos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                ComboBox2.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            ex.ToString()
        End Try
    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from Productos where Nombre='" & ComboBox2.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    cbocodigoP.Text = rd1("Codigo").ToString
                    txtunidadP.Text = rd1("UVenta").ToString
                    txtPrecioP.Text = rd1("PrecioVentaIVA").ToString
                    txtPrecio1.Text = rd1("PrecioVentaIVA2").ToString
                    txtPrecio2.Text = rd1("PreEsp").ToString
                    txtExistLocal.Text = rd1("Existencia").ToString
                    txtExistSuc.Text = rd1("Existencia").ToString
                    cbocodigoP.Focus.Equals(True)
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbocodigoP_DropDown(sender As Object, e As EventArgs) Handles cbocodigoP.DropDown
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo from Productos Order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cbocodigoP.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocodigoP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigoP.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select * from Productos where Codigo='" & cbocodigoP.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    ComboBox2.Text = rd1("Nombre").ToString
                    txtunidadP.Text = rd1("UVenta").ToString
                    txtPrecioP.Text = rd1("PrecioVentaIVA").ToString
                    txtPrecio1.Text = rd1("PrecioVentaIVA2").ToString
                    txtPrecio2.Text = rd1("PreEsp").ToString
                    txtExistLocal.Text = rd1("Existencia").ToString
                    txtExistSuc.Text = rd1("Existencia").ToString
                    txtCantidadP.Focus.Equals(True)
                End If
                rd1.Close()
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtCantidadP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadP.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCantidadP.Text = "" Then
                txtCantidadP.Focus.Equals(True)
                Exit Sub
            End If
            txtPrecioP.Focus.Equals(True)
        End If
    End Sub
    Public Sub SumaTotal()
        Dim conteo As Double = 0
        For traka As Integer = 0 To grdcaptura.Rows.Count - 1
            conteo = conteo + CDec(grdcaptura.Rows(traka).Cells(5).Value)
        Next
        txttotal.Text = CDec(FormatNumber(conteo, 2))
        txttotal.Text = FormatNumber(txttotal.Text, 2)

        txtPrecio.Text = CDec(txttotal.Text / txtexistencia.Text)
        txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)
    End Sub
    Public Sub SumaTotal2()
        Dim conteo As Double = 0
        For traka As Integer = 0 To grdcaptura.Rows.Count - 1
            conteo = conteo + CDec(grdcaptura.Rows(traka).Cells(5).Value)
        Next
        txtPrecio.Text = CDec(FormatNumber(conteo, 2))
        txtPrecio.Text = FormatNumber(txtPrecio.Text, 2)

        txttotal.Text = CDec(txtPrecio.Text * txtexistencia.Text)
        txttotal.Text = FormatNumber(txttotal.Text, 2)
    End Sub

    Private Sub txtPrecioP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioP.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                'cbocodigoP.Text = "" : cbocodigoP.Focus.Equals(True) : Exit Sub
                'txtCantidadP.Text = "" : txtCantidadP.Focus.Equals(True) : Exit Sub
                'txtCantidadP.Text = "0" : txtCantidadP.Focus.Equals(True) : Exit Sub

                Dim x As Double = 0
                x = CDec(txtCantidadP.Text)
                txttotalP.Text = FormatNumber(x * CDec(txtPrecioP.Text), 2)


                Dim varias As Integer = 0
                For chuchito As Integer = 0 To grdcaptura.Rows.Count - 1
                    varias = varias + CDec(grdcaptura.Rows(chuchito).Cells(5).Value)
                Next


                Dim myexist As Double = 0

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Existencia from Productos where Codigo='" & cbocodigoP.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    myexist = rd1(0).ToString
                    grdcaptura.Rows.Add(cbocodigoP.Text, ComboBox2.Text, txtunidadP.Text, txtCantidadP.Text, FormatNumber(txtPrecioP.Text, 2), FormatNumber(txttotalP.Text, 2), myexist)
                End If
                rd1.Close()
                cnn1.Close()

                cbocodigoP.Text = ""
                ComboBox2.Text = ""
                txtunidadP.Text = ""
                txtCantidadP.Text = "1"
                txtPrecioP.Text = "0.00"
                txttotalP.Text = "0.00"
            End If
            SumaTotal()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        Try
            Dim Turno As Integer = 0
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select MAX(Consecutivo) from OrdenTrabajo"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1(0).ToString = "" Then
                    Turno = 1
                    lblCodigo.Text = "OT" & Turno
                Else
                    Turno = rd1(0).ToString
                    Turno = Turno + CDec(1)
                    lblCodigo.Text = "OT" & Turno
                End If
            Else
                Turno = 1
                lblCodigo.Text = "OT" & Turno
            End If
            rd1.Close()
            cnn1.Close()

            cbocod.Text = ""
            cbonombre.Text = ""
            txtuni.Text = "PZA"
            txtPrecio.Text = "0.00"
            txttotal.Text = "0.00"
            txtexistencia.Text = "1"
            cbocodigoP.Text = ""
            ComboBox2.Text = ""
            txtunidadP.Text = ""
            txtPrecioP.Text = "0.00"
            txttotalP.Text = "0.00"
            txtPrecio1.Text = "0.00"
            txtPrecio2.Text = "0.00"
            txtExistLocal.Text = "0.00"
            txtExistSuc.Text = "0.00"
            cboCodigoListo.Text = ""
            grdcaptura.Rows.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try

            Dim Turno As Integer = 0
            Dim PRECIO As Double = txtPrecio.Text
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select MAX(Consecutivo) from OrdenTrabajo"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1(0).ToString = "" Then
                    Turno = 1
                    lblCodigo.Text = "OT" & Turno
                Else
                    Turno = rd1(0).ToString
                    Turno = Turno + CDec(1)
                    lblCodigo.Text = "OT" & Turno
                End If
            Else
                Turno = 1
                lblCodigo.Text = "OT" & Turno
            End If


            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo from OrdenTrabajo where Codigo='" & lblCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Update OrdenTrabajo set Nombre='" & cbonombre.Text & "',UCompra='" & txtuni.Text & "',UVenta='" & txtuni.Text & "',UMinima='" & txtuni.Text & "',Existencia=" & txtexistencia.Text & ",PrecioVentaIVA=" & PRECIO & " where Codigo='" & lblCodigo.Text & "'"
                If cmd2.ExecuteNonQuery Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Delete from MiProd where Codigo='" & lblCodigo.Text & "'"
                    If cmd2.ExecuteNonQuery Then
                    Else
                    End If
                Else
                End If
            Else
                rd1.Close()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into OrdenTrabajo(Codigo,Nombre,ProvPri,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,PrecioVentaIVA,IVA,Existencia,NombreLargo,Consecutivo,PrecioUnitario) values('" & lblCodigo.Text & "','" & cbonombre.Text & "','NA',0,'" & txtuni.Text & "','" & txtuni.Text & "','" & txtuni.Text & "',1,1,'ORDEN TRABAJO','ORDEN TRABAJO'," & PRECIO & ",0.16," & txtexistencia.Text & ",'" & cbonombre.Text & "'," & Turno & ",'" & txttotal.Text & "')"
                If cmd1.ExecuteNonQuery Then

                    For chajaro As Integer = 0 To grdcaptura.Rows.Count - 1

                        Dim PREGRID As Double = grdcaptura.Rows(chajaro).Cells(4).Value.ToString
                        Dim TOTOGRID As Double = grdcaptura.Rows(chajaro).Cells(5).Value.ToString

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Insert into MiProd(CodigoP,DescripP,UVentaP,CantidadP,Codigo,Descrip,UVenta,Cantidad,Grupo,Precio,PrecioIVA) values('" & lblCodigo.Text & "','" & cbonombre.Text & "','" & txtuni.Text & "'," & txtexistencia.Text & ",'" & grdcaptura.Rows(chajaro).Cells(0).Value & "','" & grdcaptura.Rows(chajaro).Cells(1).Value & "','" & grdcaptura.Rows(chajaro).Cells(2).Value & "'," & grdcaptura.Rows(chajaro).Cells(3).Value & ",'ORDEN TRABAJO'," & PREGRID & "," & TOTOGRID & ")"
                        If cmd1.ExecuteNonQuery Then
                        Else
                        End If
                    Next
                Else

                End If

            End If
            rd1.Close()
            cnn1.Close()
            MsgBox("Producto agregado correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            btnnuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnventa_Click(sender As Object, e As EventArgs) Handles btnventa.Click
        ordetrabajo = 1
        guardaProducto()
        enviaDescripcion()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        guardaProducto()
        enviaDetalle()
    End Sub

    Public Sub enviaDescripcion()
        If cbocod.Text = "" Then
            frmVentas1.grdcaptura.Rows.Add(lblCodigo.Text, cbonombre.Text, txtuni.Text, txtexistencia.Text, txtPrecio.Text, txttotal.Text, txtexistencia.Text, "", "", "", 0, 0, 0, "", "")
        Else
            frmVentas1.grdcaptura.Rows.Add(cboCodigoListo.Text, cbonombre.Text, txtuni.Text, txtexistencia.Text, txtPrecio.Text, txttotal.Text, txtexistencia.Text, "", "", "", 0, 0, "", "", "")
        End If


        My.Application.DoEvents()
        Dim VarSumXD As Double = 0
        Dim total_prods As Double = 0
        For w = 0 To frmVentas1.grdcaptura.Rows.Count - 1
            If frmVentas1.grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
            Else
                VarSumXD = VarSumXD + (CDbl(frmVentas1.grdcaptura.Rows(w).Cells(3).Value.ToString) * CDbl(frmVentas1.grdcaptura.Rows(w).Cells(4).Value.ToString))
                total_prods = total_prods + CDbl(frmVentas1.grdcaptura.Rows(w).Cells(3).Value.ToString)
            End If
            frmVentas1.txtSubTotal.Text = FormatNumber(VarSumXD, 2)
        Next

        If CDbl(frmVentas1.txtdescuento1.Text) <= 0 Then
            frmVentas1.txtPagar.Text = CDbl(frmVentas1.txtSubTotal.Text) - CDbl(frmVentas1.txtdescuento2.Text)
            frmVentas1.txtPagar.Text = FormatNumber(frmVentas1.txtPagar.Text, 2)
        End If
        Call frmVentas1.txtdescuento1_TextChanged(frmVentas1.txtdescuento1, New EventArgs())
        frmVentas1.txtcant_productos.Text = total_prods
        frmVentas1.txtefectivo.Focus.Equals(True)

        My.Application.DoEvents()
        Me.Close()
    End Sub

    Public Sub enviaDetalle()
        For xxx As Integer = 0 To grdcaptura.Rows.Count - 1
            Dim myexist As Double = 0
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Existencia from Productos where Codigo='" & grdcaptura.Rows(xxx).Cells(0).Value.ToString & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                myexist = rd1(0).ToString
            End If
            rd1.Close()
            cnn1.Close()

            frmVentas1.grdcaptura.Rows.Add(grdcaptura.Rows(xxx).Cells(0).Value.ToString, grdcaptura.Rows(xxx).Cells(1).Value.ToString, grdcaptura.Rows(xxx).Cells(2).Value.ToString, grdcaptura.Rows(xxx).Cells(3).Value.ToString, grdcaptura.Rows(xxx).Cells(4).Value.ToString, grdcaptura.Rows(xxx).Cells(5).Value.ToString, myexist, "", "", "", "", "", "", "", "")

            My.Application.DoEvents()
            Dim VarSumXD As Double = 0
            Dim total_prods As Double = 0
            For w = 0 To frmVentas1.grdcaptura.Rows.Count - 1
                If frmVentas1.grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
                Else
                    VarSumXD = VarSumXD + (CDbl(frmVentas1.grdcaptura.Rows(w).Cells(3).Value.ToString) * CDbl(frmVentas1.grdcaptura.Rows(w).Cells(4).Value.ToString))
                    total_prods = total_prods + CDbl(frmVentas1.grdcaptura.Rows(w).Cells(3).Value.ToString)
                End If
                frmVentas1.txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            Next

            If CDbl(frmVentas1.txtdescuento1.Text) <= 0 Then
                frmVentas1.txtPagar.Text = CDbl(frmVentas1.txtSubTotal.Text) - CDbl(frmVentas1.txtdescuento2.Text)
                frmVentas1.txtPagar.Text = FormatNumber(frmVentas1.txtPagar.Text, 2)
            End If
            Call frmVentas1.txtdescuento1_TextChanged(frmVentas1.txtdescuento1, New EventArgs())
            frmVentas1.txtcant_productos.Text = total_prods
            frmVentas1.txtefectivo.Focus.Equals(True)
            My.Application.DoEvents()

        Next
        Me.Close()
    End Sub

    Private Sub cboCodigoListo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCodigoListo.SelectedValueChanged
        'Try
        '    cboCodigoListo_KeyPress(cboCodigoListo, New KeyPressEventArgs(ChrW(Keys.Enter)))
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try
    End Sub
    Public Sub guardaProducto()
        Try

            Dim Turno As Integer = 0
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select MAX(Consecutivo) from OrdenTrabajo"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1(0).ToString = "" Then
                    Turno = 1
                    lblCodigo.Text = "OT" & Turno
                Else
                    Turno = rd1(0).ToString
                    Turno = Turno + CDec(1)
                    lblCodigo.Text = "OT" & Turno
                End If
            Else
                Turno = 1
                lblCodigo.Text = "OT" & Turno
            End If


            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo from OrdenTrabajo where Codigo='" & lblCodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Update OrdenTrabajo set Nombre='" & cbonombre.Text & "',UCompra='" & txtuni.Text & "',UVenta='" & txtuni.Text & "',UMinima='" & txtuni.Text & "',Existencia=" & txtexistencia.Text & ",PrecioVentaIVA=" & txtPrecio.Text & " where Codigo='" & lblCodigo.Text & "'"
                If cmd2.ExecuteNonQuery Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Delete from MiProd where Codigo='" & lblCodigo.Text & "'"
                    If cmd2.ExecuteNonQuery Then
                    Else
                    End If
                Else
                End If
            Else
                Dim totall As Double = txttotal.Text
                Dim precioxd As Double = txtPrecio.Text

                rd1.Close()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into OrdenTrabajo(Codigo,Nombre,ProvPri,ProvRes,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,PrecioVentaIVA,IVA,Existencia,NombreLargo,Consecutivo,PrecioUnitario) values('" & lblCodigo.Text & "','" & cbonombre.Text & "','NA',0,'" & txtuni.Text & "','" & txtuni.Text & "','" & txtuni.Text & "',1,1,'ORDEN TRABAJO','ORDEN TRABAJO'," & precioxd & ",0.16," & txtexistencia.Text & ",'" & cbonombre.Text & "'," & Turno & ",'" & totall & "')"
                If cmd1.ExecuteNonQuery Then

                    For chajaro As Integer = 0 To grdcaptura.Rows.Count - 1
                        Dim tot As Double = grdcaptura.Rows(chajaro).Cells(5).Value
                        Dim pre As Double = grdcaptura.Rows(chajaro).Cells(4).Value
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Insert into MiProd(CodigoP,DescripP,UVentaP,CantidadP,Codigo,Descrip,UVenta,Cantidad,Grupo,Precio,PrecioIVA) values('" & lblCodigo.Text & "','" & cbonombre.Text & "','" & txtuni.Text & "'," & txtexistencia.Text & ",'" & grdcaptura.Rows(chajaro).Cells(0).Value & "','" & grdcaptura.Rows(chajaro).Cells(1).Value & "','" & grdcaptura.Rows(chajaro).Cells(2).Value & "'," & grdcaptura.Rows(chajaro).Cells(3).Value & ",'ORDEN TRABAJO'," & pre & "," & tot & ")"
                        If cmd1.ExecuteNonQuery Then
                        Else
                        End If
                    Next
                Else

                End If

            End If
            rd1.Close()
            cnn1.Close()
            MsgBox("Producto agregado correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            'btnnuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim index As Integer = grdcaptura.CurrentRow.Index

        cbocodigoP.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
        ComboBox2.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
        txtunidadP.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
        txtCantidadP.Text = grdcaptura.Rows(index).Cells(3).Value.ToString
        txtPrecioP.Text = grdcaptura.Rows(index).Cells(4).Value.ToString
        txttotalP.Text = grdcaptura.Rows(index).Cells(5).Value.ToString
        ComboBox2_KeyPress(ComboBox2, New KeyPressEventArgs(ChrW(Keys.Enter)))
        grdcaptura.Rows.Remove(grdcaptura.Rows(index))
        SumaTotal()
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cbocod.Items.Clear()
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Codigo from OrdenTrabajo where Nombre='" & cbonombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    cbocod.Items.Add(rd1(0).ToString)
                Loop
                rd1.Close()
                cnn1.Close()
                cbocod.Focus.Equals(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbocod_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbocod.SelectedValueChanged
        cboCodigoListo.Text = cbocod.Text
        My.Application.DoEvents()
        cboCodigoListo_KeyPress(cboCodigoListo, New KeyPressEventArgs(ChrW(Keys.Enter)))
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbonombre.SelectedValueChanged
        cbonombre_KeyPress(cbonombre, New KeyPressEventArgs(ChrW(Keys.Enter)))
        My.Application.DoEvents()
        cbocod.Text = ""
        grdcaptura.Rows.Clear()
    End Sub

    Private Sub txtexistencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtexistencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtexistencia.Text = "" Then
                Exit Sub
            Else
                SumaTotal2()
            End If
        End If
    End Sub
End Class