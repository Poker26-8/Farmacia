Public Class frmsubeProveedores
    Private Sub frmsubeProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function NulCad(ByVal cadena As String) As String
        If IsDBNull(cadena) Then
            NulCad = ""
        Else
            NulCad = Replace(cadena, "'", "") : Replace(cadena, "*", "")
        End If
    End Function

    Private Function NulVa(ByVal cifra As Double) As Double
        If IsDBNull(cifra) Then
            NulVa = 0
        Else
            NulVa = cifra
        End If
    End Function

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Excel_Grid_SQL(DataGridView1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Excel_Grid_SQL(ByVal tabla As DataGridView)
        Dim con As OleDb.OleDbConnection
        Dim dt As New System.Data.DataTable
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim cuadro_dialogo As New OpenFileDialog
        Dim ruta As String = ""
        Dim sheet As String = "Hoja1"

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

            'Variables para alojar los datos del archivo de excel
            Dim Nombre, compania, RFC, CURP, Calle, Colonia, CP, Delegacion, Entidad, Telefono, Facebook, Correo As String
            Dim Saldo, Credito, Dias As Double
            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For zef As Integer = 0 To DataGridView1.Rows.Count - 1

                contadorconexion += 1

                Nombre = DataGridView1.Rows(zef).Cells(0).Value.ToString()
                If Nombre = "" Then Exit For
                compania = NulCad(DataGridView1.Rows(zef).Cells(1).Value.ToString())
                RFC = NulCad(DataGridView1.Rows(zef).Cells(2).Value.ToString())
                CURP = NulCad(DataGridView1.Rows(zef).Cells(3).Value.ToString())
                Calle = NulCad(DataGridView1.Rows(zef).Cells(4).Value.ToString())
                Colonia = NulCad(DataGridView1.Rows(zef).Cells(5).Value.ToString())
                CP = NulCad(DataGridView1.Rows(zef).Cells(6).Value.ToString())
                Delegacion = NulCad(DataGridView1.Rows(zef).Cells(7).Value.ToString())
                Entidad = NulCad(DataGridView1.Rows(zef).Cells(8).Value.ToString())
                Telefono = NulCad(DataGridView1.Rows(zef).Cells(9).Value.ToString())
                Facebook = NulCad(DataGridView1.Rows(zef).Cells(10).Value.ToString())
                Correo = NulCad(DataGridView1.Rows(zef).Cells(11).Value.ToString())
                Saldo = NulVa(DataGridView1.Rows(zef).Cells(12).Value.ToString())
                Credito = NulVa(DataGridView1.Rows(zef).Cells(13).Value.ToString())
                Dias = NulVa(DataGridView1.Rows(zef).Cells(14).Value.ToString())


                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If


                If (Comprueba(Nombre)) Then

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "insert into Proveedores(NComercial,Compania,RFC,CURP,Calle,Colonia,CP,Delegacion,Entidad,Telefono,Facebook,Correo,Saldo,Credito,DiasCred,Cargado) values('" & Nombre & "','" & compania & "','" & RFC & "','" & CURP & "','" & Calle & "','" & Colonia & "','" & CP & "','" & Delegacion & "','" & Entidad & "','" & Telefono & "','" & Facebook & "','" & Correo & "'," & Saldo & "," & Credito & "," & Dias & ",0)"
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

            MsgBox(conteo & " proveedores fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Function Comprueba(ByVal nombre As String) As Boolean
        Try
            Dim valida As Boolean = True
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "SELECT * FROM Proveedores WHERE NComercial='" & nombre & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    'MsgBox("Ya cuentas con un producto registrado con el nombre " & nombre & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
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
End Class