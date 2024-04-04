Public Class frmDividirCuenta

    Public mesa As String = ""

    Private Sub frmDividirCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblmesa.Text = mesa

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IDC,Cantidad,Nombre FROM comandas WHERE Nmesa='" & lblmesa.Text & "' AND Comensal='1'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdmesa.Rows.Add(rd1(0).ToString,
                        rd1(1).ToString,
                                     rd1(2).ToString
)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub grdmesa_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdmesa.CellDoubleClick

        Dim index As Integer = grdmesa.CurrentRow.Index

        Dim id As Double = 0
        Dim canti As Double = 0
        Dim nombre As String = ""

        id = grdmesa.Rows(index).Cells(0).Value.ToString
        canti = grdmesa.Rows(index).Cells(1).Value.ToString
        nombre = grdmesa.Rows(index).Cells(2).Value.ToString

        grdcomensal.Rows.Add(id, canti, nombre)
        My.Application.DoEvents()

        grdmesa.Rows.Remove(grdmesa.Rows(index))
    End Sub

    Private Sub grdcomensal_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcomensal.CellDoubleClick

        Dim index As Integer = grdcomensal.CurrentRow.Index

        Dim id As Double = 0
        Dim canti As Double = 0
        Dim nombre As String = ""

        id = grdcomensal.Rows(index).Cells(0).Value.ToString
        canti = grdcomensal.Rows(index).Cells(1).Value.ToString
        nombre = grdcomensal.Rows(index).Cells(2).Value.ToString

        grdmesa.Rows.Add(id, canti, nombre)
        My.Application.DoEvents()

        grdcomensal.Rows.Remove(grdcomensal.Rows(index))
    End Sub

    Private Sub txtnuevocomensal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnuevocomensal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnguardard.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnguardard_Click(sender As Object, e As EventArgs) Handles btnguardard.Click

        If txtnuevocomensal.Text = "" Then MsgBox("Debe ingresar el comensal para dividir la cuenta", vbInformation + vbOKOnly, titulorestaurante) : txtnuevocomensal.Focus.Equals(True) : Exit Sub

        If grdcomensal.Rows.Count = 0 Then MsgBox("Debe seleccionar al menos un producto", vbInformation + vbOKOnly, titulorestaurante) : Exit Sub

        Dim newcantidad As Double = 0
        Dim newproducto As String = ""
        Dim idcomanda As Integer = 0

        For luffy As Integer = 0 To grdcomensal.Rows.Count - 1
            idcomanda = grdcomensal.Rows(luffy).Cells(0).Value.ToString
            newcantidad = grdcomensal.Rows(luffy).Cells(1).Value.ToString
            newproducto = grdcomensal.Rows(luffy).Cells(2).Value.ToString

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "UPDATE comandas SET Comensal='" & txtnuevocomensal.Text & "' WHERE Nmesa='" & lblmesa.Text & "' AND Nombre='" & newproducto & "' AND IDC=" & idcomanda & ""
            cmd2.ExecuteNonQuery()
            cnn2.Close()
        Next
        MsgBox("Productos asignados correctamente", vbInformation + vbOKOnly, titulorestaurante)
        Me.Close()
    End Sub
End Class