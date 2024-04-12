Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
Public Class frmConsultarRefaccion
    Private Sub frmConsultarRefaccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtener el año actual
        Dim añoActual As Integer = DateTime.Now.Year

        ' Agregar años desde 1900 hasta el año actual al ComboBox
        For i As Integer = 1900 To añoActual
            cboaño.Items.Add(i.ToString())
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    End Sub

    Private Sub cboMarca_DropDown(sender As Object, e As EventArgs) Handles cboMarca.DropDown
        Try
            cboMarca.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Marca FROM vehiculo2 WHERE Marca<>'' ORDER BY Marca"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboModelo_DropDown(sender As Object, e As EventArgs) Handles cboModelo.DropDown
        Try
            cboModelo.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Modelo FROM Vehiculo2 WHERE Marca='" & cboMarca.Text & "' AND Modelo<>'' ORDER BY Modelo"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboModelo.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub grdProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdProductos.CellClick
        Dim index As Integer = grdProductos.CurrentRow.Index

        Dim CODIGO As String = ""


        CODIGO = grdProductos.Rows(index).Cells(0).Value.ToString

        If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & CODIGO & ".jpg") Then
            PicProducto.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg\" & CODIGO & ".jpg")
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboaño.Text = ""
        cboMarca.Text = ""
        cboModelo.Text = ""
        grdProductos.Rows.Clear()
        cboaño.Focused.Equals(True)
    End Sub
End Class