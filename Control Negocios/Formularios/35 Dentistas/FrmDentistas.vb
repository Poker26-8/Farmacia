Imports MySql.Data.MySqlClient

Public Class FrmDentistas
    Private Sub FrmDentistas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCliente.Focus.Equals(True)
        MostrarTodo()
        txtCliente.Focus.Equals(True)
        My.Application.DoEvents()
    End Sub

    Public Sub MostrarResultadosLike()
        Try
            grdCaptura.Rows.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select Id,Nombre,Edad,Sexo from Clientes where Nombre LIKE '%" & txtCliente.Text & "%'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                grdCaptura.Rows.Add(rd1("Id").ToString, rd1("Nombre").ToString, rd1("Edad").ToString, rd1("Sexo").ToString)
            Loop
            rd1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            cnn1.Close()
        End Try
    End Sub

    Public Sub MostrarTodo()
        Try
            grdCaptura.Rows.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select Id,Nombre,Edad,Sexo from Clientes Order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                grdCaptura.Rows.Add(rd1("Id").ToString, rd1("Nombre").ToString, rd1("Edad").ToString, rd1("Sexo").ToString)
            Loop
            rd1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        If txtCliente.Text = "" Then
            MostrarTodo()
        Else
            MostrarResultadosLike()
        End If
    End Sub

    Private Sub FrmDentistas_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtCliente.Focus.Equals(True)
    End Sub


    Private Sub grdCaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellDoubleClick
        Dim index As Integer = grdCaptura.CurrentRow.Index
        'frmHClinica.Show()
        'frmHClinica.BringToFront()

        frmHisClinica.Show()
        frmHisClinica.BringToFront()

        My.Application.DoEvents()
        'frmHClinica.txtid.Text = grdCaptura.Rows(index).Cells(0).Value.ToString
        'frmHClinica.txtNombre.Text = grdCaptura.Rows(index).Cells(1).Value.ToString
        'frmHClinica.txtEdad.Text = grdCaptura.Rows(index).Cells(2).Value.ToString
        'frmHClinica.txtSexo.Text = grdCaptura.Rows(index).Cells(3).Value.ToString

        frmHisClinica.txtId.Text = grdCaptura.Rows(index).Cells(0).Value.ToString
        frmHisClinica.txtNombre.Text = grdCaptura.Rows(index).Cells(1).Value.ToString
        frmHisClinica.txtEdad.Text = grdCaptura.Rows(index).Cells(2).Value.ToString
        frmHisClinica.txtSexo.Text = grdCaptura.Rows(index).Cells(3).Value.ToString

        txtCliente.Text = ""
        My.Application.DoEvents()
        '   frmHClinica.txtdiente.Focus.Equals(True)
        frmHisClinica.txtdiente.Focus.Equals(True)
        My.Application.DoEvents()
    End Sub
End Class