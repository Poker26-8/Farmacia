Public Class frmMarcas
    Private Sub btnAlmacenar_Click(sender As Object, e As EventArgs) Handles btnAlmacenar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM marcas WHERE Id=" & IIf(lblId.Text = "", 0, lblId.Text)
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE marcas SET Nombre='" & txtMarca.Text & "' WHERE Id=" & lblId.Text
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Marca actualizada correctamente", vbInformation + vbInformation, titulorefaccionaria)
                        txtMarca.Text = ""
                        txtMarca.Focus.Equals(True)
                    End If
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO marcas(Nombre) VALUES('" & txtmarca.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Marca agregada correctamente", vbInformation + vbInformation, titulorefaccionaria)
                    txtmarca.Text = ""
                    txtmarca.Focus.Equals(True)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try

            If MsgBox("¿Desea continuar con el proceso?", vbInformation + vbYesNo) = vbYes Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM marcas WHERE Nombre='" & txtMarca.Text & "'"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Marca eliminada correctamente", vbInformation + vbOKOnly, titulorefaccionaria)
                    cnn2.Close()
                    txtMarca.Text = ""
                    txtMarca.Focus.Equals(True)
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtMarca_DropDown(sender As Object, e As EventArgs) Handles txtMarca.DropDown
        Try
            txtMarca.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT(Nombre) FROM marcas WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    txtMarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAlmacenar.Focus.Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtMarca_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtMarca.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM marcas WHERE Nombre='" & txtMarca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblId.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQL(DataGridView1)
        End If
    End Sub

    Private Sub Excel_Grid_SQL(ByVal tabla As DataGridView)

        Dim con As OleDb.OleDbConnection
        Dim dt As New System.Data.DataTable
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim cuadro_dialogo As New OpenFileDialog
        Dim ruta As String = ""
        Dim sheet As String = "hoja1"

        With cuadro_dialogo
            .Filter = "Archivos de cálculo(*.xls;*.xlsx)|*.xls;*.xlsx"
            .Title = "Selecciona el archivo a importar"
            .Multiselect = False
            .InitialDirectory = My.Application.Info.DirectoryPath & "\Archivos de importación"
            .ShowDialog()
        End With

        Try
            If cuadro_dialogo.FileName.ToString() <> "" Then
                ruta = cuadro_dialogo.FileName.ToString()
                con = New OleDb.OleDbConnection(
                    "Provider=Microsoft.ACE.OLEDB.12.0;" &
                    " Data Source='" & ruta & "'; " &
                    "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

                da = New OleDb.OleDbDataAdapter("select * from [" & sheet & "$]", con)

                con.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                tabla.DataSource = ds
                tabla.DataMember = "MyData"
                con.Close()
            End If

            Dim nombre As String = ""
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                nombre = NulCad(DataGridView1.Rows(zef).Cells(0).Value.ToString())

                nombre = Trim(Replace(nombre, "‘", ""))
                nombre = Trim(Replace(nombre, "'", "''"))
                nombre = Trim(Replace(nombre, "*", ""))
                nombre = Trim(Replace(nombre, "", ""))

                If (Comprueba(nombre)) Then
                    If cnn1.State = 0 Then cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO marcas(Nombre) VALUES('" & nombre & "')"
                    cmd1.ExecuteNonQuery()
                Else

                    conteo += 1
                    barsube.Value = conteo

                    Continue For
                End If
                conteo += 1
                barsube.Value = conteo
            Next
            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " productos fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function Comprueba(ByVal nombre As String) As Boolean
        Try
            Dim valida As Boolean = True

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Id FROM marcas where Nombre='" & nombre & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    valida = False
                    Exit Function
                End If
            End If
            rd2.Close()
            cnn2.Close()
            Return valida
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Function

    Private Function NulCad(ByVal cadena As String) As String
        If IsDBNull(cadena) Then
            NulCad = ""
        Else
            NulCad = Replace(cadena, "'", "") : Replace(cadena, "*", "")
        End If
    End Function

    Private Sub frmMarcas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMenuPrincipal.Show()
    End Sub

    Private Sub frmMarcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class