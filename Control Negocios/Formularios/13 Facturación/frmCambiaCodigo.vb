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
End Class