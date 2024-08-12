Imports System.Net
Imports System.IO
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data

Public Class frmProductos_Escuelas
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboNombre.Text = ""
        cboNombre.Items.Clear()
        txtconcepto.Text = ""
        dtpfecha.Value = Date.Now
        txtmonto.Text = "0.00"
        grdcaptura.Rows.Clear()
        txttotal.Text = "0.00"
        txtregistros.Text = "0"
    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Nombre from Kits where Grupo='PAGO ESCUELA' order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboNombre.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        e.KeyChar = Elimina_Especiales(e.KeyChar.ToString())
        If AscW(e.KeyChar) = Keys.Enter Then
            txtconcepto.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Dim total As Double = 0
        Dim regisros As Double = 0
        grdcaptura.Rows.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,Descrip,Fecha,CTotal from Kits where Nombre='" & cboNombre.Text & "' order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString()
                    Dim nombre As String = rd1("Descrip").ToString()
                    Dim fecha As Date = rd1("Fecha").ToString()
                    Dim monto As Double = rd1("CTotal").ToString()

                    grdcaptura.Rows.Add(codigo, nombre, Format(fecha, "yyyy-MM-dd"), FormatNumber(monto, 2))
                    total = total + monto
                    regisros += 1
                End If
            Loop
            txttotal.Text = FormatNumber(total, 2)
            txtregistros.Text = regisros
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_LostFocus(sender As Object, e As EventArgs) Handles cboNombre.LostFocus
        Dim total As Double = 0
        Dim regisros As Double = 0
        grdcaptura.Rows.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Codigo,Descrip,Fecha,CTotal from Kits where Nombre='" & cboNombre.Text & "' order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim codigo As String = rd1("Codigo").ToString()
                    Dim nombre As String = rd1("Descrip").ToString()
                    Dim fecha As Date = rd1("Fecha").ToString()
                    Dim monto As Double = rd1("CTotal").ToString()

                    grdcaptura.Rows.Add(codigo, nombre, Format(fecha, "yyyy-MM-dd"), FormatNumber(monto, 2))
                    total = total + monto
                    regisros += 1
                End If
            Loop
            txttotal.Text = FormatNumber(txttotal.Text)
            txtregistros.Text = regisros
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtconcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtconcepto.KeyPress
        e.KeyChar = Elimina_Especiales(e.KeyChar.ToString())
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpfecha.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpfecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpfecha.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmonto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnagregar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        If cboNombre.Text = "" Then MsgBox("Necesitas escribir un nombre para el tipo de concepto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If txtconcepto.Text = "" Then MsgBox("Necesitas escribir un concepto de pago.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtconcepto.Focus().Equals(True) : Exit Sub
        If CDbl(txtmonto.Text) = 0 Then MsgBox("Es necesario ingresar un monto mayor a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmonto.Focus().Equals(True) : Exit Sub

        grdcaptura.Rows.Add("", txtconcepto.Text, FormatDateTime(dtpfecha.Value, DateFormat.ShortDate), FormatNumber(txtmonto.Text, 2))

        Dim total As Double = 0
        For c9 As Integer = 0 To grdcaptura.Rows.Count - 1
            total = total + CDbl(grdcaptura.Rows(c9).Cells(3).Value.ToString())
        Next

        txttotal.Text = FormatNumber(total, 2)
        txtregistros.Text = grdcaptura.Rows.Count

        txtconcepto.Text = ""
        txtmonto.Text = "0.00"
        txtconcepto.Focus().Equals(True)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cboNombre.Text = "" Then MsgBox("Necesitas escribir un nombre para el tipo de concepto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub
        If grdcaptura.Rows.Count = 0 Then MsgBox("Es necesario agregar conceptos para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtconcepto.Focus().Equals(True) : Exit Sub
        If CDbl(txttotal.Text) = 0 Then MsgBox("No se ingresaron montos válidos para los conceptos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

        If MsgBox("¿Deseas guardar la informcaión?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        Dim codigo As String = ""

        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select MAX(Cod) from Kits"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    codigo = IIf(rd2(0).ToString() = "", "0", rd2(0).ToString())
                End If
            End If
            rd2.Close()

            Dim nuevo_codigo As Double = CDbl(codigo) + 1

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Nombre from Kits where Nombre='" & cboNombre.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cnn3.Close() : cnn3.Open()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "delete from Kits where Nombre='" & cboNombre.Text & "'"
                    cmd3.ExecuteNonQuery()

                    cnn3.Close()
                End If
            End If
            rd2.Close()

            'Inserta la información
            For R7 As Integer = 0 To grdcaptura.Rows.Count - 1
                Dim fecha As Date = grdcaptura.Rows(R7).Cells(2).Value

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "insert into Kits(Cod,Nombre,Codigo,Descrip,UVenta,Cantidad,Grupo,PPrecio,CTotal,Fecha) values('" & CStr(nuevo_codigo) & "','" & cboNombre.Text & "','','" & grdcaptura.Rows(R7).Cells(1).Value.ToString() & "','SERV',1,'PAGO ESCUELA'," & CDbl(grdcaptura.Rows(R7).Cells(3).Value.ToString()) & "," & CDbl(grdcaptura.Rows(R7).Cells(3).Value.ToString()) & ",'" & Format(fecha, "yyyy-MM-dd") & "')"
                cmd2.ExecuteNonQuery()
            Next

            MsgBox("Datos registrados correctamente.", vbInformation + vbOK, "Delsscom Control Negocios Pro")

            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtmonto_GotFocus(sender As Object, e As EventArgs) Handles txtmonto.GotFocus
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub elimina_concepto_Click(sender As Object, e As EventArgs) Handles elimina_concepto.Click
        Dim fila As Integer = grdcaptura.CurrentRow.Index

        If MsgBox("¿Deseas eliminar el concepto '" & grdcaptura.Rows(fila).Cells(1).Value.ToString() & "'?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "delete from Kits where Nombre='" & cboNombre.Text & "' and Descrip='" & grdcaptura.Rows(fila).Cells(1).Value.ToString() & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Concepto de pago eliminado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            Call cboNombre_SelectedValueChanged(cboNombre, New EventArgs())
        End If
    End Sub

    Private Sub edita_concepto_Click(sender As Object, e As EventArgs) Handles edita_concepto.Click
        Dim fila As Integer = grdcaptura.CurrentRow.Index

        boxConcepto.Visible = True
        txtnuevo_concepto.Text = grdcaptura.Rows(fila).Cells(1).Value.ToString()
        lblanterior_concepto.Text = grdcaptura.Rows(fila).Cells(1).Value.ToString()
        txtnuevo_concepto.Focus().Equals(True)
    End Sub

    Private Sub btn_concepto_Click(sender As Object, e As EventArgs) Handles btn_concepto.Click
        If txtnuevo_concepto.Text = "" Then MsgBox("El concepto de pago no puede estar vacío.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

        If MsgBox("¿Deseas actualizar el concepto de pago?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Kits set Descrip='" & txtnuevo_concepto.Text & "' where Descrip='" & lblanterior_concepto.Text & "' and Nombre='" & cboNombre.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Concepto de pago actualizado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    boxConcepto.Visible = False
                    cnn1.Close()
                    Call cboNombre_SelectedValueChanged(cboNombre, New EventArgs())
                    txtnuevo_concepto.Text = ""
                    lblanterior_concepto.Text = ""
                Else
                    MsgBox("Ocurrió un error al actualizar el concepto de pago.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub edita_fecha_Click(sender As Object, e As EventArgs) Handles edita_fecha.Click
        Dim fila As Integer = grdcaptura.CurrentRow.Index

        boxFecha.Visible = True
        txtfecha_actual.Text = FormatDateTime(grdcaptura.Rows(fila).Cells(2).Value.ToString(), DateFormat.ShortDate)
        lblnombre_fecha.Text = grdcaptura.Rows(fila).Cells(1).Value.ToString()
        dtpnuevo_fecha.Focus().Equals(True)
    End Sub

    Private Sub btn_fecha_Click(sender As Object, e As EventArgs) Handles btn_fecha.Click
        If MsgBox("¿Deseas actualizar la fecha de pago?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim fecha As Date = dtpnuevo_fecha.Value

            Try
                cnn1.Close() : cnn1.Open()

                Dim folio_v As Integer = 0

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Kits set Fecha='" & Format(fecha, "yyyy-MM-dd") & "' where Descrip='" & lblnombre_fecha.Text & "' and Nombre='" & cboNombre.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Fecha de pago actualizada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    boxFecha.Visible = False
                    cnn1.Close()
                    Call cboNombre_SelectedValueChanged(cboNombre, New EventArgs())
                    txtfecha_actual.Text = ""
                    lblnombre_fecha.Text = ""
                Else
                    MsgBox("Ocurrió un error al actualizar la fecha de pago.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub edita_monto_Click(sender As Object, e As EventArgs) Handles edita_monto.Click
        Dim fila As Integer = grdcaptura.CurrentRow.Index

        boxMonto.Visible = True
        txtmonto_actual.Text = FormatNumber(grdcaptura.Rows(fila).Cells(3).Value.ToString(), 2)
        lblnombre_monto.Text = grdcaptura.Rows(fila).Cells(1).Value.ToString()
        txtnuevo_monto.Focus().Equals(True)
    End Sub

    Private Sub btn_monto_Click(sender As Object, e As EventArgs) Handles btn_monto.Click
        If CDbl(txtnuevo_monto.Text) = 0 Then MsgBox("El monto de pago no puede ser igual a 0.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtnuevo_monto.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas actualizar el monto de pago?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim monto As Double = txtnuevo_monto.Text

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Kits set PPrecio=" & monto & ", CTotal=" & monto & " where Descrip='" & lblnombre_monto.Text & "' and Nombre='" & cboNombre.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    Cambia_Montos(txtmonto_actual.Text, monto, lblnombre_monto.Text)

                    MsgBox("Monto de pago actualizado correctamente.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                    boxMonto.Visible = False
                    cnn1.Close()
                    Call cboNombre_SelectedValueChanged(cboNombre, New EventArgs())
                    txtmonto_actual.Text = "0.00"
                    txtnuevo_monto.Text = "0.00"
                    lblnombre_monto.Text = ""
                Else
                    MsgBox("Ocurrió un error al actualizar el monto de pago.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Cambia_Montos(ByVal anterior As Double, ByVal monto As Double, ByVal concepto As String)
        Dim folio_v As Integer = 0
        Dim id_cliente As Integer = 0
        Dim id_abono As Integer = 0
        Dim saldo As Double = 0
        Dim status As String = ""

        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select Folio from VentasDetalle where Nombre='" & concepto & "'"
            rd2 = cmd2.ExecuteReader
            cnn3.Close() : cnn3.Open()

            Do While rd2.Read
                If rd2.HasRows Then
                    folio_v = rd2("Folio").ToString()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select IdCliente,Status from Ventas where Folio=" & folio_v
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            id_cliente = rd3("IdCliente").ToString()
                            status = rd3("Status").ToString()
                        End If
                    End If
                    rd3.Close()

                    If status <> "RESTA" Then
                        Continue Do
                    End If

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                    "select Id,Saldo from AbonoI where Id=(select MAX(Id) from AbonoI where IdCliente=" & id_cliente & ")"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            id_abono = rd3(0).ToString()
                            saldo = rd3(1).ToString()
                        End If
                    End If
                    rd3.Close()

                    Dim nuevo_saldo As Double = (saldo - anterior) + monto

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                    "update AbonoI set Saldo=" & nuevo_saldo & " where Id=" & id_abono
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                    "update Abonoi set Cargo=" & monto & " where IdCliente=" & id_cliente & " and NumFolio='" & folio_v & "'"
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "update Ventas set Subtotal=" & monto & ", Totales=" & monto & ", Resta=" & monto & " where Folio=" & folio_v
                    cmd3.ExecuteNonQuery()

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "update VentasDetalle set Precio=" & monto & ", Total=" & monto & ", PrecioSinIVA=" & monto & ", TotalSinIVA=" & monto & " where Folio=" & folio_v
                    cmd3.ExecuteNonQuery()
                End If
            Loop
            cnn3.Close()
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
    End Sub

    Private Sub frmProductos_Escuelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class