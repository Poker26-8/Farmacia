Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
Imports AForge.Controls
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
        Try
            grdProductos.Rows.Clear()
            Dim unidad As String = ""
            Dim proveedor As String = ""
            Dim precio As Double = 0


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If cboModelo.Text = "" Then
                cmd1.CommandText = "SELECT * FROM refaccionaria WHERE Marca='" & cboMarca.Text & "'"
            End If

            If cboModelo.Text <> "" Then
                cmd1.CommandText = "SELECT * FROM refaccionaria WHERE Marca='" & cboMarca.Text & "' AND Modelo='" & cboModelo.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM productos WHERE Codigo='" & rd1("CodigoPro").ToString & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            unidad = rd2("UVenta").ToString
                            precio = rd2("PrecioVentaIVA").ToString
                            proveedor = rd2("ProvPri").ToString
                        End If
                    End If
                    rd2.Close()

                    grdProductos.Rows.Add(rd1("Codigopro").ToString,
                                          rd1("Nombre").ToString,
                                          unidad,
                                          precio,
                                          proveedor
)


                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

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

        If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & CODIGO & ".jpg") Then
            PicProducto.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg" & base & "\" & CODIGO & ".jpg")
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboaño.Text = ""
        cboMarca.Text = ""
        cboModelo.Text = ""
        grdProductos.Rows.Clear()
        cboaño.Focused.Equals(True)

        PicProducto.Image = Nothing
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cboaño_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboaño.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(cboaño.Text) Then
                cboMarca.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub cboMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboModelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Button3.Focus.Equals(True)
        End If
    End Sub
End Class