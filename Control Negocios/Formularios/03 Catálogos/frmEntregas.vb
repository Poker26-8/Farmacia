Imports System.Data.OleDb

Public Class frmEntregas

    Dim contador As Integer = 0

    Private Sub frmEntregas_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        btnNuevo.PerformClick()
        txtNombre.Text = ""
        txtId.Text = ""
    End Sub

    Private Sub frmEntregas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtNombre.Text = frmClientes.cboNombre.Text
        txtId.Text = frmClientes.txtId.Text
        rtbDomicilio.Focus.Equals(True)
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        rtbDomicilio.Text = ""
        cboConsulta.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If txtId.Text <> "" Then
            If cboConsulta.Text = "" Then 'Insert uno nuevo
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select max(Contador) from Entregas where IdCliente=" & txtId.Text
                    rd1 = cmd1.ExecuteReader

                    If rd1.HasRows Then
                        If rd1.Read Then
                            contador = IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + 1
                        Else
                            contador = 1
                        End If
                    Else
                        contador = 1
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Entregas(IdCliente,Contador,Domicilio) values(" & txtId.Text & "," & contador & ",'" & rtbDomicilio.Text & "')"
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("Domicilio agregado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            Else                          'Actualiza un existente
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Entregas set Domicilio='" & rtbDomicilio.Text & "' where IdCliente=" & txtId.Text & " and Contador=" & cboConsulta.Text
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("Domicilio actualizado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        Else
            MsgBox("Cliente no válido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        End If

        btnNuevo.PerformClick()
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            rtbDomicilio.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboConsulta_DropDown(sender As System.Object, e As System.EventArgs) Handles cboConsulta.DropDown
        cboConsulta.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Contador from Entregas where IdCliente=" & txtId.Text
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboConsulta.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboConsulta_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboConsulta.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Domicilio from Entregas where IdCliente=" & txtId.Text & " and Contador=" & cboConsulta.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    rtbDomicilio.Text = rd1("Domicilio").ToString
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        If txtNombre.Text = "" Then MsgBox("No hay ningún cliente activo para eliminar una de sus direcciones.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtNombre.Focus().Equals(True) : Exit Sub
        If txtId.Text = "" Then MsgBox("Proceso erróneo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Me.Close()
        If cboConsulta.Text = "" Then MsgBox("Selecciona un domicilio para eliminarlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboConsulta.Focus().Equals(True) : Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "delete from Entregas where Idcliente=" & txtId.Text & " and Contador=" & cboConsulta.Text
            If cmd1.ExecuteNonQuery Then
                MsgBox(
                     "Domicilio eliminado correctamente.",
                     vbInformation + vbOKOnly,
                     "Delsscom Control Negocios Pro")
                cnn1.Close()
                Me.Close()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub rtbDomicilio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles rtbDomicilio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnMigrar_Click(sender As Object, e As EventArgs) Handles btnMigrar.Click
        btnMigrar.Enabled = False
        My.Application.DoEvents()
        Dim cnn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BaseExportar\DL1.mdb;;Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
        Dim cmd1 As OleDbCommand = New OleDbCommand
        Dim rd1 As OleDbDataReader

        Dim idcliente As Integer = 0
        Dim contador As Integer = 0
        Dim domicilio As String = ""

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdCliente,Contador,Dom FROM entregas ORDER BY Id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    idcliente = rd1("IdCliente").ToString
                    contador = rd1("Contador").ToString
                    domicilio = rd1("Dom").ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO entregas(IdCliente,Contador,Domicilio) VALUES(" & idcliente & "," & contador & ",'" & domicilio & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            Loop




            MsgBox("domicilios importados correctamente", vbInformation + vbOKOnly, titulocentral)
            rd1.Close()
            cnn1.Close()
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
        My.Application.DoEvents()
        btnMigrar.Enabled = True
    End Sub
End Class