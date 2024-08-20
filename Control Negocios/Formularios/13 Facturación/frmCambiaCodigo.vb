Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports MySql.Data
Public Class frmCambiaCodigo

    Public respuesta As MySqlClient.MySqlDataReader
    Public enunciado As MySqlClient.MySqlCommand
    Public bandera As Integer

    Private Sub frmCambiaCodigo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        abrir()
        bandera = 0
        Dim adaptador As New MySqlClient.MySqlDataAdapter
        Dim registro As New DataSet
        Dim consulta As String = "Select ClaveProdSat,Descripcion from ProductoSat order by Descripcion"
        Dim comand As New MySqlClient.MySqlCommand(consulta, conexion)
        Dim adaptador2 As New MySqlClient.MySqlDataAdapter
        Dim registro2 As New DataSet
        Dim consulta2 As String = "Select Codigo,Nombre,ClaveSat from Productos order by Nombre"
        Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
        comand.CommandType = CommandType.Text
        comand2.CommandType = CommandType.Text
        adaptador.SelectCommand = comand
        adaptador2.SelectCommand = comand2
        registro.Tables.Add("ProductoSat")
        registro2.Tables.Add("Productos")
        adaptador.Fill(registro.Tables("ProductoSat"))
        adaptador2.Fill(registro2.Tables("Productos"))
        DGVProd.DataSource = registro.Tables("ProductoSat")
        DGVEmpresa.DataSource = registro2.Tables("Productos")
        DGVProd.Columns(1).Width = 300
        DGVEmpresa.Columns(1).Width = 300
        conexion.Close()
    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        If Filtro(txtDesc.Text).Rows.Count > 0 Then
            DGVProd.DataSource = Filtro(txtDesc.Text)
        End If
        DGVProd.Columns(1).Width = 300
    End Sub

    Function Filtro(ByVal busqueda As String) As DataTable
        abrir()
        Dim dt As New DataTable
        Dim da As New MySqlClient.MySqlDataAdapter("select ClaveProdSat,Descripcion from ProductoSat where Descripcion like '%" & busqueda & "%' order by Descripcion", conexion)
        da.Fill(dt)
        conexion.Close()
        Return dt
    End Function

    Private Sub txtDescEmpresa_TextChanged(sender As Object, e As EventArgs) Handles txtDescEmpresa.TextChanged
        If Filtro(txtDescEmpresa.Text).Rows.Count > 0 Then
            DGVEmpresa.DataSource = Filtro2(txtDescEmpresa.Text)
        End If
        DGVEmpresa.Columns(1).Width = 300
    End Sub

    Function Filtro2(ByVal busqueda As String) As DataTable
        abrir()
        Dim dt As New DataTable
        Dim da As New MySqlClient.MySqlDataAdapter("select Codigo,Nombre,ClaveSat from Productos where Nombre like '%" & busqueda & "%' order by Nombre", conexion)
        da.Fill(dt)
        conexion.Close()
        Return dt
    End Function

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim codigosat As String = Convert.ToString(DGVProd.CurrentRow.Cells(0).Value)
        Dim coleccion As DataGridViewSelectedRowCollection = DGVEmpresa.SelectedRows
        For Each fila As DataGridViewRow In coleccion
            DGVEmpresa(2, fila.Index).Value = codigosat
            AsignarClaveSat(DGVEmpresa(0, fila.Index).Value, codigosat)
        Next
        MessageBox.Show("Los codigos de actualizaron correctamente")
    End Sub

    Sub AsignarClaveSat(ByVal busqueda As String, ByVal clave As String)
        abrir()
        Dim comandos As New MySqlClient.MySqlCommand("update Productos set ClaveSat = '" & clave & "' where Codigo = '" & busqueda & "'", conexion)
        comandos.ExecuteNonQuery()
        conexion.Close()
    End Sub

    Private Sub rbTodos_Click(sender As Object, e As EventArgs) Handles rbTodos.Click
        If rbTodos.Checked = True Then
            bandera = 0
            cboEmpresa.Text = ""
            cboEmpresa.Items.Clear()
            txtDescEmpresa.Visible = True
            cboEmpresa.Visible = False
            cboEmpresa.Text = ""
            abrir()
            Dim adaptador2 As New MySqlClient.MySqlDataAdapter
            Dim registro2 As New DataSet
            Dim consulta2 As String = "Select Codigo,Nombre,ClaveSat from Productos order by Nombre"
            Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
            comand2.CommandType = CommandType.Text
            adaptador2.SelectCommand = comand2
            registro2.Tables.Add("Productos")
            adaptador2.Fill(registro2.Tables("Productos"))
            DGVEmpresa.DataSource = registro2.Tables("Productos")
            DGVEmpresa.Columns(1).Width = 300
            conexion.Close()
        Else
        End If
    End Sub

    Private Sub rbGrupo_Click(sender As Object, e As EventArgs) Handles rbGrupo.Click
        If rbGrupo.Checked = True Then
            bandera = 2
            cboEmpresa.Text = ""
            cboEmpresa.Items.Clear()
            cboEmpresa.Visible = True
            txtDescEmpresa.Visible = False
            txtDescEmpresa.Text = ""
            abrir()
            Try
                enunciado = New MySqlClient.MySqlCommand("Select Grupo from Productos group by Grupo", conexion)
                respuesta = enunciado.ExecuteReader
                While respuesta.Read
                    cboEmpresa.Items.Add(respuesta.Item("Grupo"))
                End While
                respuesta.Close()
            Catch ex As Exception
            End Try
            conexion.Close()
            cboEmpresa.Focus()
        Else
        End If
    End Sub

    Private Sub rbDepto_Click(sender As Object, e As EventArgs) Handles rbDepto.Click
        If rbDepto.Checked = True Then
            bandera = 1
            cboEmpresa.Items.Clear()
            cboEmpresa.Text = ""
            cboEmpresa.Visible = True
            txtDescEmpresa.Visible = False
            txtDescEmpresa.Text = ""
            abrir()
            Try
                Dim consulta2 As String = "Select Departamento from Productos group by Departamento"
                enunciado = New MySqlClient.MySqlCommand(consulta2, conexion)
                respuesta = enunciado.ExecuteReader
                While respuesta.Read
                    cboEmpresa.Items.Add(respuesta.Item("Departamento"))
                End While
                respuesta.Close()
            Catch ex As Exception
            End Try
            conexion.Close()
            cboEmpresa.Focus()
        Else
        End If
    End Sub

    Private Sub cboEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles cboEmpresa.KeyDown
        If e.KeyData = Keys.F4 Then
            cboEmpresa.DropDownStyle = ComboBoxStyle.DropDown
        End If
    End Sub

    Private Sub cboEmpresa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboEmpresa.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If bandera = 1 Then
                abrir()
                Dim adaptador2 As New MySqlClient.MySqlDataAdapter
                Dim registro2 As New DataSet
                Dim consulta2 As String = "Select Codigo,Nombre,ClaveSat from Productos where Departamento = '" & cboEmpresa.Text & "' order by Nombre"
                Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
                comand2.CommandType = CommandType.Text
                adaptador2.SelectCommand = comand2
                registro2.Tables.Add("Productos")
                adaptador2.Fill(registro2.Tables("Productos"))
                DGVEmpresa.DataSource = registro2.Tables("Productos")
                DGVEmpresa.Columns(1).Width = 300
                conexion.Close()
            ElseIf bandera = 2 Then
                abrir()
                Dim adaptador2 As New MySqlClient.MySqlDataAdapter
                Dim registro2 As New DataSet
                Dim consulta2 As String = "Select Codigo,Nombre,ClaveSat from Productos where Grupo = '" & cboEmpresa.Text & "' order by Nombre"
                Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
                comand2.CommandType = CommandType.Text
                adaptador2.SelectCommand = comand2
                registro2.Tables.Add("Productos")
                adaptador2.Fill(registro2.Tables("Productos"))
                DGVEmpresa.DataSource = registro2.Tables("Productos")
                DGVEmpresa.Columns(1).Width = 300
                conexion.Close()
            End If
        End If
    End Sub

    Private Sub btnClaves_Click(sender As Object, e As EventArgs) Handles btnClaves.Click
        frmClavesSat.BringToFront()
        frmClavesSat.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If MsgBox("Estas apunto de importar tu catálogo desde un archivo de Excel, para evitar errores asegúrate de que la hoja de Excel tiene el nombre de 'Hoja1' y cerciórate de que el archivo está guardado y cerrado.", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
        '    Excel_Grid_SQL(DataGridView1)
        'End If

        Button1.Enabled = False
        My.Application.DoEvents()
        Dim cnn1 As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BaseExportar\DL1.mdb;;Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
        Dim cmd1 As OleDbCommand = New OleDbCommand
        Dim rd1 As OleDbDataReader
        Dim cuantos As Integer = 0

        Dim claveprod As String = ""
        Dim descripcion As String = ""
        Dim palabra As String = ""

        Dim conteo As Integer = 0
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "select * from ProductoSat"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                Do While rd1.Read
                    claveprod = rd1("ClaveProdSat").ToString
                    descripcion = rd1("Descripcion").ToString
                    palabra = rd1("PalabrasSimilares").ToString

                    descripcion = Trim(Replace(descripcion, "‘", ""))
                    descripcion = Trim(Replace(descripcion, "'", "''"))
                    descripcion = Trim(Replace(descripcion, "*", ""))
                    descripcion = Trim(Replace(descripcion, "", ""))
                    descripcion = descripcion.Replace("’", "")
                    My.Application.DoEvents()

                    palabra = Trim(Replace(palabra, "‘", ""))
                    palabra = Trim(Replace(palabra, "'", "''"))
                    palabra = Trim(Replace(palabra, "*", ""))
                    palabra = Trim(Replace(palabra, "", ""))
                    palabra = palabra.Replace("’", "")
                    My.Application.DoEvents()

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Insert into productosat(ClaveProdSat,Descripcion,PalabrasSimilares) values('" & claveprod & "','" & descripcion & "','" & palabra & "')"
                    If cmd2.ExecuteNonQuery Then
                        cuantos = cuantos + 1
                        txtbarras.Text = cuantos
                        My.Application.DoEvents()
                    Else
                        MsgBox("Revisa el codigo " & claveprod & " hay un error", vbCritical + vbOKOnly)
                    End If
                Loop
                cnn2.Close()
                MsgBox("Se insertaron " & cuantos & " productos")
                rd1.Close()
                cnn1.Close()
                txtbarras.Text = ""
            End If
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        My.Application.DoEvents()
        Button1.Enabled = True

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

            Dim claveprod, descripcion, palabra As String

            Dim conteo As Integer = 0

            barsube.Value = 0
            barsube.Maximum = DataGridView1.Rows.Count

            cnn1.Close() : cnn1.Open()

            Dim contadorconexion As Integer = 0

            For dx As Integer = 0 To DataGridView1.Rows.Count - 1
                contadorconexion += 1

                claveprod = NulCad(DataGridView1.Rows(dx).Cells(0).Value.ToString())
                descripcion = NulCad(DataGridView1.Rows(dx).Cells(1).Value.ToString())
                palabra = NulCad(DataGridView1.Rows(dx).Cells(2).Value.ToString())

                If contadorconexion > 499 Then
                    cnn1.Close() : cnn1.Open()
                    contadorconexion = 1
                End If

                descripcion = Trim(Replace(descripcion, "‘", ""))
                descripcion = Trim(Replace(descripcion, "'", "''"))
                descripcion = Trim(Replace(descripcion, "*", ""))
                descripcion = Trim(Replace(descripcion, "", ""))
                descripcion = descripcion.Replace("’", "")
                My.Application.DoEvents()

                palabra = Trim(Replace(palabra, "‘", ""))
                palabra = Trim(Replace(palabra, "'", "''"))
                palabra = Trim(Replace(palabra, "*", ""))
                palabra = Trim(Replace(palabra, "", ""))
                palabra = palabra.Replace("’", "")
                My.Application.DoEvents()

                If cnn1.State = 0 Then cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO productosat(ClaveProdSat,Descripcion,PalabrasSimilares) VALUES('" & claveprod & "','" & descripcion & "','" & palabra & "')"
                cmd1.ExecuteNonQuery()

                conteo += 1
                barsube.Value = conteo
            Next

            cnn1.Close()
            tabla.DataSource = Nothing
            tabla.Dispose()
            DataGridView1.Rows.Clear()
            barsube.Value = 0

            MsgBox(conteo & " productos sat fueron importados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

    End Sub

    Private Function NulCad(ByVal cadena As String) As String
        If IsDBNull(cadena) Then
            NulCad = ""
        Else
            NulCad = Replace(cadena, "'", "") : Replace(cadena, "*", "")
        End If
    End Function
End Class