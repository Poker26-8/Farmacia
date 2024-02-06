Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports MySql.Data
Public Class frmCambiaUnidad

    Public respuesta As MySqlClient.MySqlDataReader
    Public enunciado As MySqlClient.MySqlCommand
    Public bandera As Integer

    Private Sub frmCambiaUnidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bandera = 0
        abrir()
        Dim adaptador As New MySqlClient.MySqlDataAdapter
        Dim registro As New DataSet
        Dim consulta As String = "Select ClaveUnidad,NomUnidad,Descripcion from UnidadMedSat order by NomUnidad"
        Dim comand As New MySqlClient.MySqlCommand(consulta, conexion)
        Dim adaptador2 As New MySqlClient.MySqlDataAdapter
        Dim registro2 As New DataSet
        Dim consulta2 As String = "Select Codigo,Nombre,UVenta,UnidadSat from Productos order by Nombre"
        Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
        comand.CommandType = CommandType.Text
        comand2.CommandType = CommandType.Text
        adaptador.SelectCommand = comand
        adaptador2.SelectCommand = comand2
        registro.Tables.Add("UnidadMedSat")
        registro2.Tables.Add("Productos")
        adaptador.Fill(registro.Tables("UnidadMedSat"))
        adaptador2.Fill(registro2.Tables("Productos"))
        DGVUnidad.DataSource = registro.Tables("UnidadMedSat")
        DGVEmpresAs.DataSource = registro2.Tables("Productos")
        DGVUnidad.Columns(1).Width = 200
        DGVUnidad.Columns(2).Width = 1000
        DGVEmpresAs.Columns(1).Width = 200
        conexion.Close()
    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        If Filtro(txtDesc.Text).Rows.Count > 0 Then
            DGVUnidad.DataSource = Filtro(txtDesc.Text)
        End If
        DGVUnidad.Columns(1).Width = 200
        DGVUnidad.Columns(2).Width = 1000
    End Sub

    Function Filtro(ByVal busqueda As String) As DataTable
        abrir()
        Dim dt As New DataTable
        Dim da As New MySqlClient.MySqlDataAdapter("select ClaveUnidad,NomUnidad,Descripcion  from UnidadMedSat where NomUnidad like '%" & busqueda & "%' order by NomUnidad", conexion)
        da.Fill(dt)
        conexion.Close()
        Return dt
    End Function

    Private Sub txtDescEmpresa_TextChanged(sender As Object, e As EventArgs) Handles txtDescEmpresa.TextChanged
        If Filtro(txtDescEmpresa.Text).Rows.Count > 0 Then
            DGVEmpresAs.DataSource = Filtro2(txtDescEmpresa.Text)
        End If
        DGVEmpresAs.Columns(1).Width = 200
    End Sub
    Function Filtro2(ByVal busqueda As String) As DataTable
        abrir()
        Dim dt As New DataTable
        Dim da As New MySqlClient.MySqlDataAdapter("select Codigo,Nombre,UVenta,UnidadSat from Productos where Nombre like '%" & busqueda & "%' order by Nombre", conexion)
        da.Fill(dt)
        conexion.Close()
        Return dt
    End Function

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim codigosat As String = Convert.ToString(DGVUnidad.CurrentRow.Cells(0).Value)
        Dim coleccion As DataGridViewSelectedRowCollection = DGVEmpresAs.SelectedRows
        For Each fila As DataGridViewRow In coleccion
            DGVEmpresAs(3, fila.Index).Value = codigosat
            AsignarClaveSat(DGVEmpresAs(0, fila.Index).Value, codigosat)
        Next
        MessageBox.Show("Los codigos de actualizaron correctamente")
    End Sub

    Sub AsignarClaveSat(ByVal busqueda As String, ByVal clave As String)
        abrir()
        Dim comandos As New MySqlClient.MySqlCommand("update Productos set UnidadSat = '" & clave & "' where Codigo = '" & busqueda & "'", conexion)
        If comandos.ExecuteNonQuery Then

        Else

        End If
        conexion.Close()
    End Sub

    Private Sub rbTodos_Click(sender As Object, e As EventArgs) Handles rbTodos.Click
        If rbTodos.Checked = True Then
            bandera = 0
            cboEmpresa.Items.Clear()
            cboEmpresa.Text = ""
            txtDescEmpresa.Visible = True
            cboEmpresa.Visible = False
            cboEmpresa.Text = ""
            abrir()
            Dim adaptador2 As New MySqlClient.MySqlDataAdapter
            Dim registro2 As New DataSet
            Dim consulta2 As String = "Select Codigo,Nombre,UVenta,UnidadSat from Productos order by Nombre"
            Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
            comand2.CommandType = CommandType.Text
            adaptador2.SelectCommand = comand2
            registro2.Tables.Add("Productos")
            adaptador2.Fill(registro2.Tables("Productos"))
            DGVEmpresAs.DataSource = registro2.Tables("Productos")
            DGVEmpresAs.Columns(1).Width = 300
            conexion.Close()
        Else
        End If
    End Sub

    Private Sub rbGrupo_Click(sender As Object, e As EventArgs) Handles rbGrupo.Click
        If rbGrupo.Checked = True Then
            bandera = 2
            cboEmpresa.Items.Clear()
            cboEmpresa.Text = ""
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
                enunciado = New MySqlClient.MySqlCommand("Select Departamento from Productos group by Departamento", conexion)
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
                Dim consulta2 As String = "Select Codigo,Nombre,UVenta,UnidadSat from Productos where Departamento = '" & cboEmpresa.Text & "' order by Nombre"
                Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
                comand2.CommandType = CommandType.Text
                adaptador2.SelectCommand = comand2
                registro2.Tables.Add("Productos")
                adaptador2.Fill(registro2.Tables("Productos"))
                DGVEmpresAs.DataSource = registro2.Tables("Productos")
                DGVEmpresAs.Columns(1).Width = 300
                conexion.Close()
            ElseIf bandera = 2 Then
                abrir()
                Dim adaptador2 As New MySqlClient.MySqlDataAdapter
                Dim registro2 As New DataSet
                Dim consulta2 As String = "Select Codigo,Nombre,UVenta,UnidadSat from Productos where Grupo = '" & cboEmpresa.Text & "' order by Nombre"
                Dim comand2 As New MySqlClient.MySqlCommand(consulta2, conexion)
                comand2.CommandType = CommandType.Text
                adaptador2.SelectCommand = comand2
                registro2.Tables.Add("Productos")
                adaptador2.Fill(registro2.Tables("Productos"))
                DGVEmpresAs.DataSource = registro2.Tables("Productos")
                DGVEmpresAs.Columns(1).Width = 300
                conexion.Close()
            End If
        End If
    End Sub
End Class