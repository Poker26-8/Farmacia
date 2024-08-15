Imports System.Net
Imports System.IO
Imports System.Security.Permissions
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports MySql.Data

Public Class Login

    Private Campo As String = ""
    Public soy As Integer = 0

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        End
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        'Consultas del usuario y sus permisos para dejar que entre al sistema principal
        Dim conexion As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        Dim comando As OleDbCommand = New OleDbCommand
        Dim lector As OleDbDataReader = Nothing

        If cboEmpresa.Text = "" Then MsgBox("Selecciona una empresa.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboEmpresa.Focus.Equals(True) : Exit Sub
        If txtContrasena.Text = "" Then MsgBox("Escribe tu contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtContrasena.Focus.Equals(True) : Exit Sub
        If txtUsuario.Text = "" Then txtContrasena_KeyPress(txtContrasena, New KeyPressEventArgs(Chr(Keys.Enter)))

        Try
            conexion.Close() : conexion.Open()

            comando = conexion.CreateCommand
            comando.CommandText =
                "update Server set numpc='" & MyNumPC & "'"
            comando.ExecuteNonQuery()

            comando = conexion.CreateCommand
            comando.CommandText =
                "update Server set IP='" & MyIP & "'"
            comando.ExecuteNonQuery()

            comando = conexion.CreateCommand
            comando.CommandText =
                "update Server set Servidor='" & txtRuta.Text & "'"
            comando.ExecuteNonQuery()

            If txtRuta.Text <> "" Then
                comando = conexion.CreateCommand
                comando.CommandText =
                    "update Server set Adicional=1"
                comando.ExecuteNonQuery()
            Else
                comando = conexion.CreateCommand
                comando.CommandText =
                    "update Server set Adicional=0"
                comando.ExecuteNonQuery()
            End If

            comando = conexion.CreateCommand
            comando.CommandText =
                "update Server set base='" & cboEmpresa.Text & "'"
            comando.ExecuteNonQuery()

            comando = conexion.CreateCommand
            comando.CommandText =
                "update Server set numpc='" & MyNumPC & "'"
            comando.ExecuteNonQuery()

            comando = conexion.CreateCommand
            comando.CommandText =
                "select Adicional from Server"
            lector = comando.ExecuteReader
            If lector.HasRows Then
                If lector.Read Then
                    adicional = lector(0).ToString
                End If
            End If
            lector.Close()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
        End Try

        Try
            If txtRuta.Text <> "" Then
                cnn1 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn2 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn3 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn4 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn5 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn9 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn8 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn7 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnntimer = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnntimer2 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
            Else
                cnn1 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn2 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn3 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn4 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn5 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn9 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn8 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnn7 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnntimer = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                cnntimer2 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
            End If
            varrutabase = txtRuta.Text
            empresa_activa = lblEmpresa.Text


            If txtUsuario.Text = "" Then
            Else
                frmLoad.Show()
                frmLoad.BringToFront()
                My.Application.DoEvents()
                frmLoad.cargaTodo()

                Me.Hide()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Login_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        txtContrasena.Focus().Equals(True)
    End Sub

    Private Sub Login_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        txtContrasena.Focus().Equals(True)
    End Sub

    Private Sub Login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If System.IO.Directory.Exists("C:\xampp\mysql\data") Then
        Else
            Try
                If MsgBox("Este es equipo tipo Servidor?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Process.Start(My.Application.Info.DirectoryPath & "\xampp-win32-5.6.20-0-VC11-installer.exe")
                Else
                    crea_ruta("C:\xampp\mysql\data")
                End If
            Catch ex As Exception
            End Try
        End If

        txtContrasena.Focus.Equals(True)
        servidor = ""
        base = ""
        MyNumPC = ""
        id_usu_log = 0
        zinc = 0

        Dim conexion As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        Dim comando As OleDbCommand = New OleDbCommand
        Dim lector As OleDbDataReader

        MyIP = dameIP2() ' dameIP2()
        MyNumPC = SerialNumber()

        Try
            conexion.Close() : conexion.Open()
            '"Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22"
            comando = conexion.CreateCommand
            comando.CommandText =
                "select Servidor,base from Server"
            lector = comando.ExecuteReader
            If lector.HasRows Then
                Do While lector.Read
                    servidor = lector("Servidor").ToString()
                    If servidor = "" Then
                        servidor = MyIP
                        txtRuta.Text = ""
                    Else
                        txtRuta.Text = servidor
                    End If
                    base = lector("base").ToString()
                    ' zinc = lector("Zink").ToString()
                Loop
            End If
            lector.Close()

            comando = conexion.CreateCommand
            comando.CommandText =
                "select Empresa from Empresas where Id=" & base
            lector = comando.ExecuteReader
            If lector.HasRows Then
                If lector.Read Then
                    lblEmpresa.Text = lector("Empresa").ToString()
                End If
            End If
            lector.Close()

            cboEmpresa.Text = base

            comando = conexion.CreateCommand
            comando.CommandText =
                "update Server set numpc='" & MyNumPC & "'"
            comando.ExecuteNonQuery()

            comando = conexion.CreateCommand
            comando.CommandText =
                "update Server set IP='" & MyIP & "'"
            comando.ExecuteNonQuery()

            comando = conexion.CreateCommand
            comando.CommandText =
                "select Ip from ConfiguracionesTienda where Id=1"
            lector = comando.ExecuteReader
            If lector.HasRows Then
                If lector.Read Then
                    If lector(0).ToString() <> "" Then
                        tienda_enlinea = True
                    End If
                End If
                Else
                tienda_enlinea = False
            End If
            lector.Close()


            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
        End Try


        cnn1 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnn2 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnn3 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnn4 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnn5 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnn9 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnn8 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnn7 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnntimer = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
        cnntimer2 = New MySqlClient.MySqlConnection("server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")

        'cnn1 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
        'cnn2 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
        'cnn3 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
        'cnn4 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
        'cnn5 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
        'cnn9 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
        'cnn8 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
        'cnn7 = New MySqlClient.MySqlConnection("Data source=" & servidor & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")

        My.Application.DoEvents()
        txtContrasena.Focus.Equals(True)
        Campo = ""

    End Sub

    Private Sub btnRed_Click(sender As System.Object, e As System.EventArgs) Handles btnRed.Click
        Dim bat As Button = sender

        If bat.Text = "Configurar red" Then
            Me.Size = New Size(238, 484)
            bat.Text = "Guardar ruta de red"
        ElseIf bat.Text = "Guardar ruta de red" Then

            Dim conexion As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
            Dim comando As OleDbCommand = New OleDbCommand
            Dim lector As OleDbDataReader

            Try
                conexion.Close() : conexion.Open()

                comando = conexion.CreateCommand
                comando.CommandText =
                    "update Server set Servidor='" & txtRuta.Text & "'"
                comando.ExecuteNonQuery()

                comando = conexion.CreateCommand
                comando.CommandText =
                    "update Server set numpc='" & MyNumPC & "'"
                comando.ExecuteNonQuery()

                comando = conexion.CreateCommand
                comando.CommandText =
                    "select base,Servidor,Zink from Server"
                lector = comando.ExecuteReader
                If lector.Read Then
                    base = lector(0).ToString()
                    servidor = lector(1).ToString()
                    zinc = lector(2).ToString()
                End If
                lector.Close()

                If txtRuta.Text = "" Then
                    cnn1 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn2 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn3 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn4 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn5 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn9 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn8 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn7 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer2 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")

                    'cnn1 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn2 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn3 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn4 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn5 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn9 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn8 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn7 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")

                    comando = conexion.CreateCommand
                    comando.CommandText =
                        "update Server set Adicional=0"
                    comando.ExecuteNonQuery()
                Else
                    cnn1 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn2 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn3 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn4 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn5 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn9 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn8 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn7 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer2 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")

                    'cnn1 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn2 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn3 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn4 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn5 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn9 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn8 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")
                    'cnn7 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300")

                    comando = conexion.CreateCommand
                    comando.CommandText =
                        "update Server set Adicional=1"
                    comando.ExecuteNonQuery()
                End If

                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                conexion.Close()
            End Try

            Me.Size = New Size(238, 453)
            bat.Text = "Configurar red"
        End If
    End Sub

    Private Sub txtContrasena_Click(sender As Object, e As System.EventArgs) Handles txtContrasena.Click
        txtContrasena.SelectAll()
        Campo = "CONTRA"
    End Sub

    Private Sub txtContrasena_GotFocus(sender As Object, e As System.EventArgs) Handles txtContrasena.GotFocus
        Dim sdr As TextBox = sender
        sdr.SelectAll()
        Campo = "CONTRA"
    End Sub

    Private Sub txtContrasena_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtContrasena.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtContrasena.Text = "" Then Exit Sub
            Try
                baseseleccionada = cboEmpresa.Text
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Status,Alias,IdEmpleado,Clave from Usuarios where Clave='" & txtContrasena.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Status").ToString = "1" Then
                            txtUsuario.Text = rd1("Alias").ToString
                            id_usu_log = rd1("IdEmpleado").ToString
                            ClaveUsuario = rd1("Clave").ToString
                            OK.Focus.Equals(True)
                        Else
                            MsgBox("Usuario inactivo, consulte a su administrador.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtContrasena.SelectAll()
                        End If
                    End If
                Else
                    MsgBox("No existe el usuario o se está ingresando una contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                    txtContrasena.SelectAll()
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtRuta.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub txtRuta_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtRuta.Text <> "" Then
                btnRed.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub cboEmpresa_Click(sender As Object, e As System.EventArgs) Handles cboEmpresa.Click
        Campo = "EMPRESA"
    End Sub

    Private Sub cboEmpresa_DropDown(sender As System.Object, e As System.EventArgs) Handles cboEmpresa.DropDown
        'Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        'Dim coma As OleDbCommand = New OleDbCommand
        'Dim lect As OleDbDataReader = Nothing

        'cboEmpresa.Items.Clear()

        'Try
        '    cias.Close() : cias.Open()

        '    coma = cias.CreateCommand
        '    coma.CommandText =
        '        "select Id from Empresas order by Id"
        '    lect = coma.ExecuteReader
        '    Do While lect.Read
        '        cboEmpresa.Items.Add(lect(0).ToString())
        '    Loop
        '    lect.Close()
        '    cias.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString())
        '    cias.Close()
        'End Try
    End Sub

    Public Sub cboEmpresa_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboEmpresa.SelectedValueChanged
        Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        Dim coma As OleDbCommand = New OleDbCommand
        Dim lect As OleDbDataReader = Nothing

        Dim cadena As String = ""

        Try
            baseseleccionada = cboEmpresa.Text
            cias.Close() : cias.Open()

            coma = cias.CreateCommand
            coma.CommandText =
                "update Server set base='" & cboEmpresa.Text & "'"
            coma.ExecuteNonQuery()

            coma = cias.CreateCommand
            coma.CommandText =
                "select Empresa from Empresas where Id=" & cboEmpresa.Text
            lect = coma.ExecuteReader
            If lect.HasRows Then
                If lect.Read Then
                    lblEmpresa.Text = lect(0).ToString
                End If
            End If
            lect.Close()

            coma = cias.CreateCommand
            coma.CommandText =
                "select Soporte from Server"
            lect = coma.ExecuteReader
            If lect.HasRows Then
                If lect.Read Then
                    cadena = lect(0).ToString()
                End If
            Else
                cadena = ""
            End If
            lect.Close()
            cias.Close()

            Dim fecha As String = ""

            If cadena <> "" Then
                fecha = Replace(cadena, "?#$-", "/")
                fecha = Replace(fecha, "pCjm", "0")
                fecha = Replace(fecha, "FrDtee", "1")
                fecha = Replace(fecha, "<pzef>", "2")
                fecha = Replace(fecha, "_sdbEz", "3")
                fecha = Replace(fecha, "@ddET", "4")
                fecha = Replace(fecha, "-()opY", "5")
                fecha = Replace(fecha, "TrdHJ", "6")
                fecha = Replace(fecha, "Bno_o", "7")
                fecha = Replace(fecha, "nRtwun", "8")
                fecha = Replace(fecha, "uuIoo", "9")
                fecha = Replace(fecha, "***", "")
                fecha = Replace(fecha, "ASDWE", "")

                lblsoporte.Text = DateAdd(DateInterval.Year, 1, CDate(fecha))
                My.Application.DoEvents()
                If CDate(lblsoporte.Text) > CDate(Date.Now) Then
                    lblsoporte.ForeColor = Color.LightSteelBlue
                Else
                    lblsoporte.ForeColor = Color.Red
                End If
            Else
                fecha = ""
                lblsoporte.Text = "01/01/0001"
                lblsoporte.ForeColor = Color.Red
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cias.Close()
        End Try

        txtContrasena.Focus.Equals(True)
    End Sub

    Private Sub cboEmpresa_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboEmpresa.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboEmpresa.Text = "" Then
                MsgBox("Selecciona la empresa.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboEmpresa.Focus.Equals(True) : Exit Sub
            End If

            Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
            Dim coma As OleDbCommand = New OleDbCommand
            Dim lect As OleDbDataReader = Nothing

            Dim cadena As String = ""

            Try
                cias.Close() : cias.Open()

                If IsNumeric(cboEmpresa.Text) Then
                    coma = cias.CreateCommand
                    coma.CommandText =
                        "update Server set base='" & cboEmpresa.Text & "'"
                    coma.ExecuteNonQuery()
                    coma = cias.CreateCommand
                    coma.CommandText =
                        "select Empresa from Empresas where Id=" & cboEmpresa.Text
                    lect = coma.ExecuteReader
                    If lect.HasRows Then
                        If lect.Read Then
                            lblEmpresa.Text = lect(0).ToString

                        End If
                    Else
                        MsgBox("No existe la empresa " & cboEmpresa.Text & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        cboEmpresa.SelectionStart = 0
                        cboEmpresa.SelectionLength = Len(cboEmpresa.Text)
                        cboEmpresa.Focus().Equals(True)
                        lect.Close() : cias.Close()
                        Exit Sub
                    End If
                    lect.Close()
                Else
                    MsgBox("Ingresa una empresa válida.", vbInformation + vbOKOnly, "Delsscom Control")
                    cboEmpresa.SelectionStart = 0
                    cboEmpresa.SelectionLength = Len(cboEmpresa.Text)
                    cboEmpresa.Focus().Equals(True)
                    cias.Close()
                    Exit Sub
                End If

                coma = cias.CreateCommand
                coma.CommandText =
                    "select Soporte from Server"
                lect = coma.ExecuteReader
                If lect.HasRows Then
                    If lect.Read Then
                        cadena = lect(0).ToString()
                    End If
                Else
                    cadena = ""
                End If
                lect.Close()
                cias.Close()

                Dim fecha As String = ""

                If cadena <> "" Then
                    fecha = Replace(cadena, "?#$-", "/")
                    fecha = Replace(fecha, "pCjm", "0")
                    fecha = Replace(fecha, "FrDtee", "1")
                    fecha = Replace(fecha, "<pzef>", "2")
                    fecha = Replace(fecha, "_sdbEz", "3")
                    fecha = Replace(fecha, "@ddET", "4")
                    fecha = Replace(fecha, "-()opY", "5")
                    fecha = Replace(fecha, "TrdHJ", "6")
                    fecha = Replace(fecha, "Bno_o", "7")
                    fecha = Replace(fecha, "nRtwun", "8")
                    fecha = Replace(fecha, "uuIoo", "9")
                    fecha = Replace(fecha, "***", "")
                    fecha = Replace(fecha, "ASDWE", "")

                    lblsoporte.Text = DateAdd(DateInterval.Year, 1, CDate(fecha))
                    My.Application.DoEvents()
                    If CDate(lblsoporte.Text) > CDate(Date.Now) Then
                        lblsoporte.ForeColor = Color.LightSteelBlue
                    Else
                        lblsoporte.ForeColor = Color.Red
                    End If
                Else
                    fecha = ""
                    lblsoporte.Text = "01/01/0001"
                    lblsoporte.ForeColor = Color.Red
                End If
                cias.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cias.Close()
            End Try

            baseseleccionada = cboEmpresa.Text
            My.Application.DoEvents()

            Try
                cias.Close() : cias.Open()

                coma = cias.CreateCommand
                coma.CommandText =
                    "select base,Zink from Server"
                lect = coma.ExecuteReader
                If lect.Read Then
                    base = lect(0).ToString()
                    zinc = lect(1).ToString()
                End If
                lect.Close()



                coma = cias.CreateCommand
                coma.CommandText =
                    "update Server set Servidor='" & txtRuta.Text & "'"
                coma.ExecuteNonQuery()

                If txtRuta.Text = "" Then
                    cnn1 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn2 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn3 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn4 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn5 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn9 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn7 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn8 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer2 = New MySqlClient.MySqlConnection("server=" & MyIP & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    'cnn1 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn2 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn3 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn4 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn5 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn9 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn7 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn8 = New MySqlClient.MySqlConnection("Data source=" & MyIP & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                Else
                    cnn1 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn2 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn3 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn4 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn5 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn9 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn8 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnn7 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    cnntimer2 = New MySqlClient.MySqlConnection("server=" & txtRuta.Text & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300")
                    'cnn1 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn2 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn3 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn4 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn5 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn9 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn8 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                    'cnn7 = New MySqlClient.MySqlConnection("Data source=" & txtRuta.Text & ";Integrated Security=False; initial catalog=CN1; user id=Delsscom; password=jipl22")
                End If

                If txtRuta.Text <> "" Then
                    coma = cias.CreateCommand
                    coma.CommandText =
                        "update Server set Adicional=1"
                    coma.ExecuteNonQuery()
                End If

                cias.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cias.Close()
            End Try

            txtContrasena.Focus.Equals(True)
        End If
    End Sub

    Private Sub lblEmpresa_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lblEmpresa.DoubleClick
        boxEmpresa.Visible = True
        txtempresa.Text = lblEmpresa.Text
        txtempresa.Tag = cboEmpresa.Text
    End Sub

    Private Sub boxEmpresa_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles boxEmpresa.VisibleChanged
        If boxEmpresa.Visible = False Then
            txtempresa.Text = ""
            txtempresa.Tag = ""
        End If
    End Sub

    Private Sub btnvale_Click(sender As System.Object, e As System.EventArgs) Handles btnvale.Click
        Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        Dim coma As OleDbCommand = New OleDbCommand
        Dim lect As OleDbDataReader = Nothing

        If txtempresa.Text = "" Then
            MsgBox("Escribe un nombre válido para la empresa.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtempresa.Focus.Equals(True) : Exit Sub
        End If

        Try
            cias.Close() : cias.Open()

            coma = cias.CreateCommand
            coma.CommandText =
                "update Empresas set Empresa='" & txtempresa.Text & "' where Id=" & txtempresa.Tag
            If coma.ExecuteNonQuery Then
                MsgBox("Empresa actualizada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                lblEmpresa.Text = txtempresa.Text
                boxEmpresa.Visible = False
            End If
            cias.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cias.Close()
        End Try
    End Sub

    Private Sub Login_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        txtContrasena.Focus().Equals(True)
    End Sub

    Private Sub lblsoporte_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lblsoporte.DoubleClick
        If lblsoporte.Text = "" Or cboEmpresa.Text = "" Then MsgBox("Selecciona una empresa para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboEmpresa.Focus().Equals(True) : Exit Sub
        frmSoporte.Show(Me)
        frmSoporte.dtpsoporte.Focus().Equals(True)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmTecladoLog.lblcampo.Text = Campo
        frmTecladoLog.Show()
    End Sub

    Private Sub cboEmpresa_GotFocus(sender As Object, e As System.EventArgs) Handles cboEmpresa.GotFocus
        Campo = "EMPRESA"
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        GroupBox1.Visible = True
        Dim pt As New System.Drawing.Point(5, 38)
        GroupBox1.Location = pt
        txtContraCreaBase.Focus()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        End
    End Sub

    Private Sub btnCrearBase_Click(sender As Object, e As EventArgs) Handles btnCrearBase.Click
        If txtContraCreaBase.Text <> "" Then
            If Trim(txtContraCreaBase.Text) = "jipl2211" Then
                Try
                    Process.Start(My.Application.Info.DirectoryPath & "\CreateDB_Users.bat")
                    System.Threading.Thread.Sleep(5000)
                    Dim cnnprueba As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                    Dim sinfo As String = ""
                    Dim odata As New ToolKitSQL.myssql
                    Dim sTargetprueba = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn" & cboEmpresa.Text & ";persist security info=false;connect timeout=300"
                    'Dim sTargetprueba = "Server=localhost;user id = root; password=;"
                    With odata
                        If .dbOpen(cnnprueba, sTargetprueba, sinfo) Then

                            'hismesa
                            .runSp(cnnprueba, vartablahismesas, sinfo)
                            .runSp(cnnprueba, VarKeyhismesas, sinfo)
                            .runSp(cnnprueba, varAutohismesas, sinfo)

                            'dispositivos
                            .runSp(cnnprueba, vartablatallerd, sinfo)
                            .runSp(cnnprueba, VarKeytallerd, sinfo)
                            .runSp(cnnprueba, varAutotallerd, sinfo)

                            'dispositivos
                            .runSp(cnnprueba, vartabladispositivos, sinfo)
                            .runSp(cnnprueba, VarKeydispositivos, sinfo)
                            .runSp(cnnprueba, varAutodispositivos, sinfo)

                            'accesorios
                            .runSp(cnnprueba, vartablaaccesorios, sinfo)
                            .runSp(cnnprueba, VarKeyaccesorios, sinfo)
                            .runSp(cnnprueba, varAutoaccesorios, sinfo)

                            'unidadmedsat
                            .runSp(cnnprueba, vartablaunidadmedsat, sinfo)
                            .runSp(cnnprueba, VarKeyunidadmedsat, sinfo)
                            .runSp(cnnprueba, varAutounidadmedsatt, sinfo)

                            'productosat
                            .runSp(cnnprueba, vartablaproductosat, sinfo)
                            .runSp(cnnprueba, VarKeyproductosat, sinfo)
                            .runSp(cnnprueba, varAutoproductosat, sinfo)

                            'produccioncdetalle
                            .runSp(cnnprueba, vartablaproduccioncdetalle, sinfo)
                            .runSp(cnnprueba, VarKeyproduccioncdetalle, sinfo)
                            .runSp(cnnprueba, varAutoproduccioncdetalle, sinfo)

                            'produccionc
                            .runSp(cnnprueba, vartablaproduccionc, sinfo)
                            .runSp(cnnprueba, VarKeyproduccionc, sinfo)
                            .runSp(cnnprueba, varAutoproduccionc, sinfo)

                            'movingre
                            .runSp(cnnprueba, vartablamovingre, sinfo)
                            .runSp(cnnprueba, VarKeymovingre, sinfo)
                            .runSp(cnnprueba, varAutomovingre, sinfo)

                            'precios
                            .runSp(cnnprueba, vartablaprecios, sinfo)
                            .runSp(cnnprueba, VarKeyprecios, sinfo)
                            .runSp(cnnprueba, varAutoprecios, sinfo)

                            'marcas
                            .runSp(cnnprueba, vartablamarcas, sinfo)
                            .runSp(cnnprueba, VarKeymarcas, sinfo)
                            .runSp(cnnprueba, varAutomarcas, sinfo)

                            'vehiculo2
                            .runSp(cnnprueba, vartablavehiculo2, sinfo)
                            .runSp(cnnprueba, VarKeyvehiculo2, sinfo)
                            .runSp(cnnprueba, varAutovehiuclo2, sinfo)

                            'nominas
                            .runSp(cnnprueba, vartablanominass, sinfo)
                            .runSp(cnnprueba, VarKeynominass, sinfo)
                            .runSp(cnnprueba, varAutonominass, sinfo)

                            'pedidosvendet
                            .runSp(cnnprueba, vartablapedidosvendet, sinfo)
                            .runSp(cnnprueba, VarKeypedidosvendet, sinfo)
                            .runSp(cnnprueba, varAutopedidosvendet, sinfo)

                            'comandas_t
                            .runSp(cnnprueba, vartablacomandas_t, sinfo)
                            .runSp(cnnprueba, varKeycomandas_t, sinfo)
                            .runSp(cnnprueba, varAutocomandas_t, sinfo)

                            'precios_rango
                            .runSp(cnnprueba, vartablarangoprecios, sinfo)
                            .runSp(cnnprueba, varKeypreciosrango, sinfo)
                            .runSp(cnnprueba, varAutopreciosrango, sinfo)

                            'pedidosven
                            .runSp(cnnprueba, vartablapedidosven, sinfo)
                            .runSp(cnnprueba, VarKeypedidosven, sinfo)
                            .runSp(cnnprueba, varAutopedidosven, sinfo)

                            'detallehotelprecios
                            .runSp(cnnprueba, vartabladetallehotelprecios, sinfo)
                            .runSp(cnnprueba, VarKeydetallehotelprecios, sinfo)
                            .runSp(cnnprueba, varAutodetallehotelprecios, sinfo)

                            'promos
                            .runSp(cnnprueba, vartablapromos, sinfo)
                            .runSp(cnnprueba, varKeypromos, sinfo)
                            .runSp(cnnprueba, varAutopromos, sinfo)

                            'clienteeliminado
                            .runSp(cnnprueba, vartablaclienteeliminado, sinfo)
                            .runSp(cnnprueba, varKeyclienteeliminado, sinfo)
                            .runSp(cnnprueba, varAutoclienteeliminado, sinfo)

                            'productoeliminado
                            .runSp(cnnprueba, vartablaproductoeliminado, sinfo)
                            .runSp(cnnprueba, varKeyproductoeliminado, sinfo)
                            .runSp(cnnprueba, varAutoproductoeliminado, sinfo)

                            'pedidostemporal
                            .runSp(cnnprueba, vartablapedidostemporal, sinfo)
                            .runSp(cnnprueba, varKeypedidostemporal, sinfo)
                            .runSp(cnnprueba, varAutopedidostemporal, sinfo)

                            ' pedidoeliminado
                            .runSp(cnnprueba, vartablaPedidoEliminado, sinfo)
                            .runSp(cnnprueba, varKeypedidoeliminado, sinfo)
                            .runSp(cnnprueba, varAutopedidoeliminado, sinfo)

                            'detalle_nomina
                            .runSp(cnnprueba, vartabladetallenomina, sinfo)
                            .runSp(cnnprueba, varKeydetallenomina, sinfo)
                            .runSp(cnnprueba, varAutodetallenomina, sinfo)

                            'tipoincapacidadsat
                            .runSp(cnnprueba, vartablatipoincapacidadsat, sinfo)
                            Dim dtprueba11 As New DataTable
                            If .getDt(cnnprueba, dtprueba11, "SELECT Id from tipoincapacidadsat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatipoincapacidadsat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyotipoincapacidadsat, sinfo)
                            .runSp(cnnprueba, varAutotipoincapacidadsat, sinfo)

                            'tiponomina
                            .runSp(cnnprueba, vartablatiponomina, sinfo)
                            Dim dtprueba10 As New DataTable
                            If .getDt(cnnprueba, dtprueba10, "SELECT Id from tiponomina", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatiponomina, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyotiponomina, sinfo)
                            .runSp(cnnprueba, varAutotiponomina, sinfo)


                            'otrospagos
                            .runSp(cnnprueba, vartablaotrospagos, sinfo)
                            Dim dtprueba9 As New DataTable
                            If .getDt(cnnprueba, dtprueba9, "SELECT Id from otrospagos", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaotrospagos, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyotrospagos, sinfo)
                            .runSp(cnnprueba, varAutootrospagos, sinfo)

                            'tipopercepcioncontable
                            .runSp(cnnprueba, vartablatipopercepcioncontable, sinfo)
                            Dim dtprueba8 As New DataTable
                            If .getDt(cnnprueba, dtprueba8, "SELECT Id from tipo_percepcion_contable", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatipopercepcioncontable, sinfo)
                            End If
                            .runSp(cnnprueba, varKeytipopercepcioncontable, sinfo)
                            .runSp(cnnprueba, varAutotipopercepcioncontable, sinfo)

                            'tipodeduccioncontable
                            .runSp(cnnprueba, vartablatipodeduccioncontable, sinfo)
                            Dim dtprueba7 As New DataTable
                            If .getDt(cnnprueba, dtprueba7, "SELECT Id from tipo_deduccion_contable", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatipodeduccioncontable, sinfo)
                            End If
                            .runSp(cnnprueba, varKeytipodeduccioncontable, sinfo)
                            .runSp(cnnprueba, varAutotipodeduccioncontable, sinfo)

                            'riesgopuesto
                            .runSp(cnnprueba, vartablariesgopuesto, sinfo)
                            Dim dtprueba6 As New DataTable
                            If .getDt(cnnprueba, dtprueba6, "SELECT Id from riesgo_puesto", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertariesgopuesto, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyriesgopuesto, sinfo)
                            .runSp(cnnprueba, varAutoriesgopuesto, sinfo)

                            'tipocontrato
                            .runSp(cnnprueba, vartablatipocontrato, sinfo)
                            Dim dtprueba5 As New DataTable
                            If .getDt(cnnprueba, dtprueba5, "SELECT Id from tipo_contrato", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatipocontrato, sinfo)
                            End If
                            .runSp(cnnprueba, varKeytipocontrato, sinfo)
                            .runSp(cnnprueba, varAutotipocontrato, sinfo)

                            'tipojornada
                            .runSp(cnnprueba, vartablatipojornada, sinfo)
                            Dim dtprueba4 As New DataTable
                            If .getDt(cnnprueba, dtprueba4, "SELECT Id from tipo_jornada", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatipojornada, sinfo)
                            End If
                            .runSp(cnnprueba, varKeytipojornada, sinfo)
                            .runSp(cnnprueba, varAutotipojornada, sinfo)

                            'periodicidad_pago
                            .runSp(cnnprueba, vartablaperiodicidadpago, sinfo)
                            Dim dtprueba3 As New DataTable
                            If .getDt(cnnprueba, dtprueba3, "SELECT Id from periodicidad_pago", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaperiodicidadpago, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyperiodicidadpago, sinfo)
                            .runSp(cnnprueba, varAutoperiodicidadpago, sinfo)

                            'regimencontrataciontrabajador
                            .runSp(cnnprueba, vartablaregimencontrataciontrabajador, sinfo)
                            Dim dtprueba2 As New DataTable
                            If .getDt(cnnprueba, dtprueba2, "SELECT Id from regimen_contratacion_trabajador", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaregimencontrataciontrabajador, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyregimencontrataciontrabajador, sinfo)
                            .runSp(cnnprueba, varAutoregimencontrataciontrabajador, sinfo)


                            'habitacion
                            .runSp(cnnprueba, vartablahabitacion, sinfo)
                            .runSp(cnnprueba, varKeyhabitacion, sinfo)
                            .runSp(cnnprueba, varAutohabitacion, sinfo)

                            'detallehotel
                            .runSp(cnnprueba, vartabladetallehotel, sinfo)
                            .runSp(cnnprueba, varKeydetallehotel, sinfo)
                            .runSp(cnnprueba, varAutodetallehotel, sinfo)

                            'controlserviciodet
                            .runSp(cnnprueba, vartablacontrolserviciosdet, sinfo)
                            .runSp(cnnprueba, varKeycontrolserviciodet, sinfo)
                            .runSp(cnnprueba, varAutocontrolserviciodet, sinfo)

                            'controlservicio
                            .runSp(cnnprueba, vartablacontrolservicios, sinfo)
                            .runSp(cnnprueba, varKeycontrolservicio, sinfo)
                            .runSp(cnnprueba, varAutocontrolservicio, sinfo)

                            .runSp(cnnprueba, vartablahisasigpc, sinfo)
                            .runSp(cnnprueba, varKeyhisasigpc, sinfo)
                            .runSp(cnnprueba, varAutohisasigpc, sinfo)

                            'vtaimpresion
                            .runSp(cnnprueba, vartablavtaimpresion, sinfo)
                            .runSp(cnnprueba, varKeyvtaimpresion, sinfo)
                            .runSp(cnnprueba, varAutovtaimpresion, sinfo)

                            'REP_COMANDAS
                            .runSp(cnnprueba, vartablarepcomandas, sinfo)
                            .runSp(cnnprueba, varKeyrepcomandas, sinfo)
                            .runSp(cnnprueba, varAutorepcomandas, sinfo)

                            'refaccionaria
                            .runSp(cnnprueba, vartablarefaccionaria, sinfo)
                            .runSp(cnnprueba, varKeyrefaccionaria, sinfo)
                            .runSp(cnnprueba, varAutorefaccionaria, sinfo)

                            'vehiculo
                            .runSp(cnnprueba, vartablavehiculo, sinfo)
                            .runSp(cnnprueba, varKeyvehiculo, sinfo)
                            .runSp(cnnprueba, varAutovehiculo, sinfo)

                            'comandasveh
                            .runSp(cnnprueba, vartablacomandasveh, sinfo)
                            .runSp(cnnprueba, varKeycomandasveh, sinfo)
                            .runSp(cnnprueba, varAutocomandasveh, sinfo)

                            'promociones
                            .runSp(cnnprueba, vartablapromociones, sinfo)
                            .runSp(cnnprueba, varKeypromociones, sinfo)
                            .runSp(cnnprueba, varAutopromociones, sinfo)

                            'permisosm
                            .runSp(cnnprueba, vartablapermisosm, sinfo)
                            If .getDt(cnnprueba, dtprueba9, "SELECT id from permisosm", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertapermisosm, sinfo)
                            End If
                            .runSp(cnnprueba, varKeypermisosm, sinfo)
                            .runSp(cnnprueba, varAutopermisosm, sinfo)

                            'extras
                            .runSp(cnnprueba, vartablaextras, sinfo)
                            .runSp(cnnprueba, varKeyextras, sinfo)
                            .runSp(cnnprueba, varAutoextras, sinfo)

                            'preferencia
                            .runSp(cnnprueba, vartablapreferencias, sinfo)
                            .runSp(cnnprueba, varKeyprefecia, sinfo)
                            .runSp(cnnprueba, varAutopreferencias, sinfo)

                            'AbonoE
                            .runSp(cnnprueba, vartablaabonoe, sinfo)
                            .runSp(cnnprueba, varKeyabonoe, sinfo)
                            .runSp(cnnprueba, varAutoabonoe, sinfo)

                            'AbonoI
                            .runSp(cnnprueba, vartablaabonoi, sinfo)
                            .runSp(cnnprueba, varKeyabonoi, sinfo)
                            .runSp(cnnprueba, varAutoabonoi, sinfo)

                            'Acreedores
                            .runSp(cnnprueba, vartablaAcreedores, sinfo)
                            .runSp(cnnprueba, varKeyacreedores, sinfo)
                            .runSp(cnnprueba, varAutoacreedores, sinfo)

                            'Alumnos
                            .runSp(cnnprueba, vartablalumnos, sinfo)
                            .runSp(cnnprueba, varKeyalumnos, sinfo)
                            .runSp(cnnprueba, varAutoalumnos, sinfo)

                            'AsigPC
                            .runSp(cnnprueba, vartablaasigpc, sinfo)
                            .runSp(cnnprueba, varKeyasigpc, sinfo)
                            .runSp(cnnprueba, varAutoasigpc, sinfo)

                            'Asistencia
                            .runSp(cnnprueba, vartablaasistencia, sinfo)
                            .runSp(cnnprueba, varKeyasistencia, sinfo)
                            .runSp(cnnprueba, varAutoasistencia, sinfo)

                            .runSp(cnnprueba, vartablaasistenciagym, sinfo)
                            .runSp(cnnprueba, varKeyasistenciagym, sinfo)
                            .runSp(cnnprueba, varAutoasistenciagym, sinfo)

                            'Auditoria
                            .runSp(cnnprueba, vartablaauditoria, sinfo)
                            .runSp(cnnprueba, varKeyauditoria, sinfo)
                            .runSp(cnnprueba, varAutoauditoria, sinfo)

                            'AuxCompras
                            .runSp(cnnprueba, vartablaauxcompras, sinfo)
                            .runSp(cnnprueba, varKeyauxcompras, sinfo)
                            .runSp(cnnprueba, varAutoauxcompras, sinfo)

                            'AuxComprasSeries
                            .runSp(cnnprueba, vartablaauxcomprasseries, sinfo)
                            .runSp(cnnprueba, varKeyauxcomprasseries, sinfo)
                            .runSp(cnnprueba, varAutoauxcomprasseries, sinfo)

                            'AuxPedidos
                            .runSp(cnnprueba, vartablaauxpedidos, sinfo)
                            .runSp(cnnprueba, varKeyauxpedidos, sinfo)
                            .runSp(cnnprueba, varAutoauxpedidos, sinfo)

                            'Bancos
                            .runSp(cnnprueba, vartablabancos, sinfo)
                            Dim dtprueba As New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Banco from bancos", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertabancos, sinfo)
                            End If

                            'Cardex
                            .runSp(cnnprueba, vartablacardex, sinfo)
                            .runSp(cnnprueba, varKeycardex, sinfo)
                            .runSp(cnnprueba, varAutocardex, sinfo)

                            'CargosAbonos
                            .runSp(cnnprueba, vartablacargosabonos, sinfo)

                            'CartaPorte
                            .runSp(cnnprueba, vartablacartaporte, sinfo)
                            .runSp(cnnprueba, varKeycartaporte, sinfo)
                            .runSp(cnnprueba, varAutocartaporte, sinfo)

                            'CartaPorteDet
                            .runSp(cnnprueba, vartablacartaportedet, sinfo)
                            .runSp(cnnprueba, varKeycartaportedet, sinfo)
                            .runSp(cnnprueba, varAutocartaportedet, sinfo)

                            'CartaPorteDeti
                            .runSp(cnnprueba, vartablacartaportedeti, sinfo)
                            .runSp(cnnprueba, varKeycartaportedeti, sinfo)
                            .runSp(cnnprueba, varAutocartaportedeti, sinfo)

                            'CartaPorteI
                            .runSp(cnnprueba, vartablacartaportei, sinfo)
                            .runSp(cnnprueba, varKeycartaportei, sinfo)
                            .runSp(cnnprueba, varAutocartaportei, sinfo)

                            'Clientes
                            .runSp(cnnprueba, vartablaclientes, sinfo)
                            .runSp(cnnprueba, varKeyclientes, sinfo)
                            .runSp(cnnprueba, varAutoclientes, sinfo)

                            'Comanda1
                            .runSp(cnnprueba, vartablacomandas1, sinfo)
                            .runSp(cnnprueba, varKeycomandas1, sinfo)
                            .runSp(cnnprueba, varAutocomandas1, sinfo)

                            'Comandas
                            .runSp(cnnprueba, vartablacomandas, sinfo)
                            .runSp(cnnprueba, varKeycomandas, sinfo)
                            .runSp(cnnprueba, varAutocomandas, sinfo)

                            'Compras
                            .runSp(cnnprueba, vartablacompras, sinfo)
                            .runSp(cnnprueba, varKeycompras, sinfo)
                            .runSp(cnnprueba, varAutocompras, sinfo)

                            'ComprasDet
                            .runSp(cnnprueba, vartablacomprasdet, sinfo)
                            .runSp(cnnprueba, varKeycomprasdet, sinfo)
                            .runSp(cnnprueba, varAutocomprasdet, sinfo)
                            .runSp(cnnprueba, varForKcomprasdet, sinfo)

                            'CorteCaja
                            .runSp(cnnprueba, vartablacortecaja, sinfo)
                            .runSp(cnnprueba, varKeycortecaja, sinfo)
                            .runSp(cnnprueba, varAutocortecaja, sinfo)

                            'CorteUsuario
                            .runSp(cnnprueba, vartablacorteusuario, sinfo)
                            .runSp(cnnprueba, varKeycorteusuario, sinfo)
                            .runSp(cnnprueba, varAutocorteusuario, sinfo)

                            'CotPed
                            .runSp(cnnprueba, vartablacotped, sinfo)
                            .runSp(cnnprueba, varKeycotped, sinfo)
                            .runSp(cnnprueba, varAutocotped, sinfo)

                            'CotPedDet
                            .runSp(cnnprueba, vartablaccotpeddet, sinfo)
                            .runSp(cnnprueba, varKeycotpeddet, sinfo)
                            .runSp(cnnprueba, varAutocotpeddet, sinfo)

                            'CtMedicos
                            .runSp(cnnprueba, vartablactmedicos, sinfo)
                            .runSp(cnnprueba, varKeyctmedicos, sinfo)
                            .runSp(cnnprueba, varAutoctmedicos, sinfo)

                            'CuentasBancarias
                            .runSp(cnnprueba, vartablacuentasbancarias, sinfo)
                            .runSp(cnnprueba, varKeycuentasbancarias, sinfo)
                            .runSp(cnnprueba, varAutocuentasbancarias, sinfo)

                            'DatosNegocio
                            .runSp(cnnprueba, vartabladatosnegocio, sinfo)
                            .runSp(cnnprueba, varKeydatosnegocio, sinfo)
                            .runSp(cnnprueba, varAutodatosnegocio, sinfo)

                            'DatosProsepago
                            .runSp(cnnprueba, vartabladatosprosepago, sinfo)
                            .runSp(cnnprueba, varKeydatosprosepago, sinfo)
                            .runSp(cnnprueba, varAutodatosprosepago, sinfo)

                            'detalle_factura
                            .runSp(cnnprueba, vartabladdetalle_factura, sinfo)

                            'Deudores
                            .runSp(cnnprueba, vartabladeudores, sinfo)
                            .runSp(cnnprueba, varKeydeudores, sinfo)
                            .runSp(cnnprueba, varAutodeudores, sinfo)

                            'Devoluciones
                            .runSp(cnnprueba, vartabladevoluciones, sinfo)
                            .runSp(cnnprueba, varKeydevoluciones, sinfo)
                            .runSp(cnnprueba, varAutodevoluciones, sinfo)

                            'Entregas
                            .runSp(cnnprueba, vartablaentregas, sinfo)
                            .runSp(cnnprueba, varKeyentregas, sinfo)
                            .runSp(cnnprueba, varAutoentregas, sinfo)

                            'Facturas
                            .runSp(cnnprueba, vartablafacturas, sinfo)
                            .runSp(cnnprueba, varKeyfacturas, sinfo)
                            .runSp(cnnprueba, varAutofacturas, sinfo)

                            'FechaaCobros
                            .runSp(cnnprueba, vartablafechacobros, sinfo)
                            .runSp(cnnprueba, varKeyfechacobros, sinfo)
                            .runSp(cnnprueba, varAutofechacobros, sinfo)

                            'FormaPagoSat
                            .runSp(cnnprueba, vartablaformapagosat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from formapagosat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaformapagosat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyformapagosat, sinfo)
                            .runSp(cnnprueba, varAutoformapagosat, sinfo)

                            'FormasPago
                            .runSp(cnnprueba, vartablaformaspago, sinfo)
                            .runSp(cnnprueba, varKeyformaspago, sinfo)
                            .runSp(cnnprueba, varAutoformapagos, sinfo)

                            'Formatos
                            .runSp(cnnprueba, vartablaformatos, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from formatos", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaformatos, sinfo)
                            End If

                            .runSp(cnnprueba, vartablaformatos, sinfo)
                            .runSp(cnnprueba, varKeyformatos, sinfo)
                            .runSp(cnnprueba, varAutoformatos, sinfo)

                            'Gastos
                            .runSp(cnnprueba, vartablagastos, sinfo)

                            'Grupos
                            .runSp(cnnprueba, vartablagrupos, sinfo)
                            .runSp(cnnprueba, varKeygrupos, sinfo)
                            .runSp(cnnprueba, varAutogrupos, sinfo)

                            'HeResultados
                            .runSp(cnnprueba, vartablaheresultados, sinfo)

                            'Horarios
                            .runSp(cnnprueba, vartablahorarios, sinfo)

                            'ImpuestoSat
                            .runSp(cnnprueba, vartablaimpuestosat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from impuestosat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaimpuestosat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyimpuestosat, sinfo)
                            .runSp(cnnprueba, varAutoimpuestosat, sinfo)

                            'IVA
                            .runSp(cnnprueba, vartablaiva, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from iva", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaiva, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyiva, sinfo)
                            .runSp(cnnprueba, varAutoiva, sinfo)



                            'Kits
                            .runSp(cnnprueba, vartablakits, sinfo)

                            'loginrecargas
                            .runSp(cnnprueba, vartablaloginrecargas, sinfo)
                            .runSp(cnnprueba, varKeyloginrecargas, sinfo)
                            .runSp(cnnprueba, varAutologinrecargas, sinfo)

                            .runSp(cnnprueba, vartablaliberacion, sinfo)
                            .runSp(cnnprueba, varKeyliberacion, sinfo)
                            .runSp(cnnprueba, varAutoliberacion, sinfo)

                            'LoteCaducidad
                            .runSp(cnnprueba, vartablalotecaducidad, sinfo)
                            .runSp(cnnprueba, varKeylotecaducidad, sinfo)
                            .runSp(cnnprueba, varAutolotecaducidad, sinfo)

                            .runSp(cnnprueba, vartablamembresiasgym, sinfo)
                            .runSp(cnnprueba, varKeymembresiasgym, sinfo)
                            .runSp(cnnprueba, varAutomembresiasgym, sinfo)

                            'Merma
                            .runSp(cnnprueba, vartablamerma, sinfo)
                            .runSp(cnnprueba, varKeymerma, sinfo)
                            .runSp(cnnprueba, varAutomerma, sinfo)

                            'Mesa
                            .runSp(cnnprueba, vartablamesa, sinfo)
                            .runSp(cnnprueba, varKeymesa, sinfo)
                            .runSp(cnnprueba, varAutomesa, sinfo)

                            'MesasxEmpleados
                            .runSp(cnnprueba, vartablamesasempleados, sinfo)
                            .runSp(cnnprueba, varKeymesasempleados, sinfo)
                            .runSp(cnnprueba, varAutomesasempleados, sinfo)

                            'MesesSat
                            .runSp(cnnprueba, vartablamesessat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select ID from mesessat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertamesessat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeymesessat, sinfo)
                            .runSp(cnnprueba, varAutomesessat, sinfo)

                            'MetodoPagoSat
                            .runSp(cnnprueba, vartablametodopagosat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from metodopagosat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertametodopagosat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeymetodopagosat, sinfo)
                            .runSp(cnnprueba, varAutometodopagosat, sinfo)

                            'MiProd
                            .runSp(cnnprueba, vartablamiprod, sinfo)

                            .runSp(cnnprueba, vartablamodentregas, sinfo)
                            .runSp(cnnprueba, varKeymodentregas, sinfo)
                            .runSp(cnnprueba, varAutomodentregas, sinfo)

                            .runSp(cnnprueba, vartablamodentregasdet, sinfo)
                            .runSp(cnnprueba, varKeymodentregasdet, sinfo)
                            .runSp(cnnprueba, varAutomodentregasdet, sinfo)

                            .runSp(cnnprueba, vartablamodprecios, sinfo)
                            .runSp(cnnprueba, varKeymodprecios, sinfo)
                            .runSp(cnnprueba, varAutomodprecios, sinfo)

                            .runSp(cnnprueba, vartablamonedero, sinfo)
                            .runSp(cnnprueba, varKeymonedero, sinfo)
                            .runSp(cnnprueba, varAutomonedero, sinfo)

                            .runSp(cnnprueba, vartablamovcuenta, sinfo)
                            .runSp(cnnprueba, varKeymovcuenta, sinfo)
                            .runSp(cnnprueba, varAutomovcuenta, sinfo)

                            .runSp(cnnprueba, vartablamovmonedero, sinfo)
                            .runSp(cnnprueba, varKeymovmonedero, sinfo)
                            .runSp(cnnprueba, varAutomovmonedero, sinfo)

                            .runSp(cnnprueba, vartablanomina, sinfo)
                            .runSp(cnnprueba, varKeynomina, sinfo)
                            .runSp(cnnprueba, varAutonomina, sinfo)

                            .runSp(cnnprueba, vartablanota, sinfo)
                            .runSp(cnnprueba, varKeynota, sinfo)
                            .runSp(cnnprueba, varAutonota, sinfo)

                            .runSp(cnnprueba, vartablaotrosgastos, sinfo)
                            .runSp(cnnprueba, varKeyotrosgastos, sinfo)
                            .runSp(cnnprueba, varAutootrosgastos, sinfo)

                            .runSp(cnnprueba, vartablaordentrabajo, sinfo)
                            .runSp(cnnprueba, varKeyordentrabajo, sinfo)
                            .runSp(cnnprueba, varAutoordentrabajo, sinfo)

                            .runSp(cnnprueba, vartablaparametros, sinfo)
                            .runSp(cnnprueba, varinsertaparametros, sinfo)
                            .runSp(cnnprueba, varKeyparametros, sinfo)

                            'parcialidades
                            .runSp(cnnprueba, vartablaparcialidades, sinfo)
                            .runSp(cnnprueba, varKeyparcialidades, sinfo)
                            .runSp(cnnprueba, varAutoparcialidades, sinfo)

                            'parciaqlidadesdetalle
                            .runSp(cnnprueba, vartablaparcialidadesdetalle, sinfo)
                            .runSp(cnnprueba, varKeyparcialidadesdetalle, sinfo)
                            .runSp(cnnprueba, varAutoparcialidadesdetalle, sinfo)

                            'parcialidadesdetallemulti
                            .runSp(cnnprueba, vartablaparcialidadesdetallemulti, sinfo)
                            .runSp(cnnprueba, varKeyparcialidadesdetallemulti, sinfo)
                            .runSp(cnnprueba, varAutoparcialidadesdetallemulti, sinfo)

                            'parcialidadesmulti
                            .runSp(cnnprueba, vartablaparcialidadesmulti, sinfo)
                            .runSp(cnnprueba, varKeyparcialidadesmulti, sinfo)
                            .runSp(cnnprueba, varAutoparcialidadesmulti, sinfo)

                            .runSp(cnnprueba, vartablapedidos, sinfo)
                            .runSp(cnnprueba, varKeypedidos, sinfo)
                            .runSp(cnnprueba, varAutopedidos, sinfo)

                            .runSp(cnnprueba, vartablapedidosdet, sinfo)
                            .runSp(cnnprueba, varKeypedidosdet, sinfo)
                            .runSp(cnnprueba, varAutopedidosdet, sinfo)

                            .runSp(cnnprueba, vartablapeps, sinfo)
                            .runSp(cnnprueba, varKeypeps, sinfo)
                            .runSp(cnnprueba, varAutopeps, sinfo)

                            .runSp(cnnprueba, vartablaperiodicidadsat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from periodicidadsat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaperiodicidadsat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyperiodicidadsat, sinfo)
                            .runSp(cnnprueba, varAutoperiodicidadsat, sinfo)

                            .runSp(cnnprueba, vartablapermisos, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from permisos", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertapermisos, sinfo)
                            End If
                            .runSp(cnnprueba, varKeypermisos, sinfo)
                            .runSp(cnnprueba, varAutopermisos, sinfo)

                            .runSp(cnnprueba, vartablaporteclavestcc, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from porteclavestcc", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaporteclavestcc, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyporteclavestcc, sinfo)
                            .runSp(cnnprueba, varAutoporteclavestcc, sinfo)

                            .runSp(cnnprueba, vartablaportecolonia, sinfo)
                            .runSp(cnnprueba, varKeyportecolonia, sinfo)
                            .runSp(cnnprueba, varAutoportecolonia, sinfo)

                            .runSp(cnnprueba, vartablaporteconfigautotrans, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from porteconfigautotrans", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaporteconfigautotrans, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyporteconfigautotrans, sinfo)
                            .runSp(cnnprueba, varAutoporteconfigautotrans, sinfo)

                            .runSp(cnnprueba, vartablaportedestino, sinfo)
                            .runSp(cnnprueba, varKeyportedestino, sinfo)
                            .runSp(cnnprueba, varAutoportedestino, sinfo)

                            .runSp(cnnprueba, vartablaporteestados, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from porteestados", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaporteestados, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyporteestados, sinfo)
                            .runSp(cnnprueba, varAutoporteestados, sinfo)

                            .runSp(cnnprueba, vartablaportefigura, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from portefigura", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaportefigura, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyportefigura, sinfo)
                            .runSp(cnnprueba, varAutoportefigura, sinfo)

                            .runSp(cnnprueba, vartablaportelocalidad, sinfo)
                            .runSp(cnnprueba, varKeyportelocalidad, sinfo)
                            .runSp(cnnprueba, varAutoportelocalidad, sinfo)

                            .runSp(cnnprueba, vartablaportematpeligrosos, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from portematpeligrosos", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaportematpeligrosos, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyportematpeligrosos, sinfo)
                            .runSp(cnnprueba, varAutoportematpeligrosos, sinfo)

                            'PorteMercancia
                            .runSp(cnnprueba, vartablaportemercancia, sinfo)
                            .runSp(cnnprueba, varKeyportemercancia, sinfo)
                            .runSp(cnnprueba, varAutoportemercancia, sinfo)

                            'PorteMunicipios
                            .runSp(cnnprueba, vartablaportemunicipios, sinfo)
                            .runSp(cnnprueba, varKeyportemunicipios, sinfo)
                            .runSp(cnnprueba, varAutoportemunicipios, sinfo)

                            'PorteOperador
                            .runSp(cnnprueba, vartablaporteoperador, sinfo)
                            .runSp(cnnprueba, varKeyporteoperador, sinfo)
                            .runSp(cnnprueba, varAutoporteoperador, sinfo)

                            .runSp(cnnprueba, vartablaporteorigen, sinfo)
                            .runSp(cnnprueba, varKeyporteorigen, sinfo)
                            .runSp(cnnprueba, varAutoporteorigen, sinfo)

                            .runSp(cnnprueba, vartablaportepais, sinfo)
                            .runSp(cnnprueba, varKeyportepais, sinfo)
                            .runSp(cnnprueba, varAutoportepais, sinfo)

                            .runSp(cnnprueba, vartablaporteproducto, sinfo)
                            .runSp(cnnprueba, varKeyporteproducto, sinfo)
                            .runSp(cnnprueba, varAutoporteproducto, sinfo)

                            .runSp(cnnprueba, vartablaporteproductosat, sinfo)
                            .runSp(cnnprueba, varKeyporteproductosat, sinfo)
                            .runSp(cnnprueba, varAutoporteproductosat, sinfo)

                            .runSp(cnnprueba, vartablaportepropietario, sinfo)
                            .runSp(cnnprueba, varKeyportepropietario, sinfo)
                            .runSp(cnnprueba, varAutoportepropietario, sinfo)

                            .runSp(cnnprueba, vartablaportetipocarga, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from portetipocarga", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaportetipocarga, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyportetipocarga, sinfo)
                            .runSp(cnnprueba, varAutoportetipocarga, sinfo)

                            .runSp(cnnprueba, vartablaportetipocarro, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from portetipocarro", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaportetipocarro, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyportetipocarro, sinfo)
                            .runSp(cnnprueba, varAutoportetipocarro, sinfo)

                            .runSp(cnnprueba, vartablaportetipocontenedor, sinfo)
                            .runSp(cnnprueba, varKeyportetipocontenedor, sinfo)
                            .runSp(cnnprueba, varAutoportetipocontenedor, sinfo)

                            .runSp(cnnprueba, vartablaportetipoembalaje, sinfo)
                            .runSp(cnnprueba, varKeyportetipoembalaje, sinfo)
                            .runSp(cnnprueba, varAutoportetipoembalaje, sinfo)

                            .runSp(cnnprueba, vartablaportetipopermiso, sinfo)
                            .runSp(cnnprueba, varKeyportetipopermiso, sinfo)
                            .runSp(cnnprueba, varAutoportetipopermiso, sinfo)

                            .runSp(cnnprueba, vartablaportetiporemolque, sinfo)
                            .runSp(cnnprueba, varKeyportetiporemolque, sinfo)
                            .runSp(cnnprueba, varAutoportetiporemolque, sinfo)

                            .runSp(cnnprueba, vartablaportetransporte, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from portetransporte", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaportetransporte, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyportetransporte, sinfo)
                            .runSp(cnnprueba, varAutoportetransporte, sinfo)

                            .runSp(cnnprueba, vartablaporteunidadmedemb, sinfo)
                            .runSp(cnnprueba, varKeyporteunidadmedemb, sinfo)
                            .runSp(cnnprueba, varAutoporteunidadmedemb, sinfo)

                            .runSp(cnnprueba, vartablaprocesos_prod, sinfo)
                            .runSp(cnnprueba, varKeyprocesos_prod, sinfo)
                            .runSp(cnnprueba, varAutoprocesos_prod, sinfo)

                            'Productos
                            .runSp(cnnprueba, vartablaproductos, sinfo)
                            .runSp(cnnprueba, varKeyproductos, sinfo)
                            .runSp(cnnprueba, varAutoproductos, sinfo)

                            'ProMasVen
                            .runSp(cnnprueba, vartablapromasven, sinfo)

                            'Proveedores
                            .runSp(cnnprueba, vartablaproveedores, sinfo)
                            .runSp(cnnprueba, varKeyproveedores, sinfo)
                            .runSp(cnnprueba, varAutoproveedores, sinfo)

                            'Recargas
                            .runSp(cnnprueba, vartablarecargas, sinfo)
                            .runSp(cnnprueba, varKeyrecargas, sinfo)
                            .runSp(cnnprueba, varAutorecargas, sinfo)

                            'RegFis
                            .runSp(cnnprueba, vartablaregimenfiscalsat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select ClaveRegFis from regimenfiscalsat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaregimenfiscalsat, sinfo)
                            End If

                            .runSp(cnnprueba, vartablarepfactura, sinfo)

                            .runSp(cnnprueba, vartablarepomen, sinfo)

                            .runSp(cnnprueba, vartablarepsalidas, sinfo)

                            .runSp(cnnprueba, vartablarep_antib, sinfo)
                            .runSp(cnnprueba, varKeyrep_antib, sinfo)
                            .runSp(cnnprueba, varAutorep_antib, sinfo)

                            .runSp(cnnprueba, vartablarep_salidas, sinfo)

                            .runSp(cnnprueba, vartablarutasimpresion, sinfo)
                            .runSp(cnnprueba, varKeyrutasimpresion, sinfo)
                            .runSp(cnnprueba, varAutorutasimpresion, sinfo)

                            .runSp(cnnprueba, vartablasaldosempleados, sinfo)
                            .runSp(cnnprueba, varKeysaldosempleados, sinfo)
                            .runSp(cnnprueba, varAutosaldosempleados, sinfo)

                            .runSp(cnnprueba, vartablasseries, sinfo)
                            .runSp(cnnprueba, varKeyseries, sinfo)
                            .runSp(cnnprueba, varAutoseries, sinfo)

                            .runSp(cnnprueba, vartablaservicios, sinfo)
                            .runSp(cnnprueba, varKeyservicios, sinfo)
                            .runSp(cnnprueba, varAutoservicios, sinfo)

                            .runSp(cnnprueba, vartablatalmacen, sinfo)
                            .runSp(cnnprueba, varKeytalmacen, sinfo)
                            .runSp(cnnprueba, varAutotalmacen, sinfo)

                            .runSp(cnnprueba, vartablatb_moneda, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from tb_moneda", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatb_moneda, sinfo)
                            End If
                            .runSp(cnnprueba, varKeytb_moneda, sinfo)
                            .runSp(cnnprueba, varAutotb_moneda, sinfo)

                            .runSp(cnnprueba, vartablaticket, sinfo)
                            .runSp(cnnprueba, varKeyticket, sinfo)
                            .runSp(cnnprueba, varAutoticket, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from ticket", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertaticket, sinfo)
                            End If

                            .runSp(cnnprueba, vartablatipofactorsat, sinfo)
                            .runSp(cnnprueba, varKeytipofactorsat, sinfo)
                            .runSp(cnnprueba, varAutotipofactorsat, sinfo)

                            .runSp(cnnprueba, vartablatiposcomprobantesat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from tiposcomprobantesat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatiposcomprobantesat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeytiposcomprobantesat, sinfo)
                            .runSp(cnnprueba, varAutotiposcomprobantesat, sinfo)

                            .runSp(cnnprueba, vartablatiprelacioncfdisat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from tiprelacioncfdisat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertatiprelacioncfdisat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeytiprelacioncfdisat, sinfo)
                            .runSp(cnnprueba, varAutotiprelacioncfdisat, sinfo)

                            .runSp(cnnprueba, vartablatransporte, sinfo)
                            .runSp(cnnprueba, varKeytransporte, sinfo)
                            .runSp(cnnprueba, varAutotransporte, sinfo)

                            .runSp(cnnprueba, vartablatraslados, sinfo)
                            .runSp(cnnprueba, varKeytraslados, sinfo)
                            .runSp(cnnprueba, varAutotraslados, sinfo)

                            .runSp(cnnprueba, vartablatrasladosdet, sinfo)
                            .runSp(cnnprueba, varKeytrasladosdet, sinfo)
                            .runSp(cnnprueba, varAutotrasladosdet, sinfo)

                            .runSp(cnnprueba, vartablaumtblcfds, sinfo)
                            .runSp(cnnprueba, varKeyumtblcfds, sinfo)
                            .runSp(cnnprueba, varAutoumtblcfds, sinfo)

                            .runSp(cnnprueba, vartablausocfdisat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select ClaveUsoCFDI from usocfdisat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertausocfdisat, sinfo)
                            End If

                            .runSp(cnnprueba, vartablausocomprocfdisat, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select Id from usocomprocfdisat", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertausocomprocfdisat, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyusocomprocfdisat, sinfo)
                            .runSp(cnnprueba, varAutousocomprocfdisat, sinfo)

                            .runSp(cnnprueba, vartablausuarios, sinfo)
                            dtprueba = New DataTable
                            If .getDt(cnnprueba, dtprueba, "select IdEmpleado from usuarios", sinfo) Then
                            Else
                                .runSp(cnnprueba, varinsertausuarios, sinfo)
                            End If
                            .runSp(cnnprueba, varKeyusuarios, sinfo)
                            .runSp(cnnprueba, varAutousuarios, sinfo)

                            .runSp(cnnprueba, vartablauuidrelacion, sinfo)
                            .runSp(cnnprueba, varKeyuuidrelacion, sinfo)
                            .runSp(cnnprueba, varAutouuidrelacion, sinfo)

                            .runSp(cnnprueba, vartablaventas, sinfo)
                            .runSp(cnnprueba, varKeyventas, sinfo)
                            .runSp(cnnprueba, varAutoventas, sinfo)

                            .runSp(cnnprueba, vartablaventasdetalle, sinfo)
                            .runSp(cnnprueba, varKeyventasdetalle, sinfo)
                            .runSp(cnnprueba, varAutoventasdetalle, sinfo)
                            .runSp(cnnprueba, varForKventasdetalle, sinfo)

                            MsgBox("Base Creada Correctamente")
                            cnnprueba.Close()

                            GroupBox1.Visible = False
                            txtContrasena.Text = ""

                        Else
                            MsgBox("Error al crear la base")
                            MsgBox(sinfo)

                            GroupBox1.Visible = False
                            txtContrasena.Text = ""

                        End If
                    End With

                Catch ex As Exception
                    MsgBox("El Archivo CreateDB_Users no existe hay que colocarlo en la carpeta correspondiente")
                    txtContrasena.Text = ""
                    GroupBox1.Visible = False
                End Try

            Else
                MsgBox("Contraseña incorrecta")
                txtContrasena.Text = ""
                GroupBox1.Visible = False
            End If
        Else
            txtContrasena.Text = ""
            GroupBox1.Visible = False
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If System.IO.Directory.Exists("C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\Crystal Reports 2011") Then
        Else
            If System.IO.Directory.Exists("C:\Program Files\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\Crystal Reports 2011") Then
            Else
                Process.Start(My.Application.Info.DirectoryPath & "\CR13SP30MSI32_0-10010309_RUNTIME engine for net framework.MSI")
            End If
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        If GroupBox2.Visible = True Then
            GroupBox2.Visible = False
        Else
            GroupBox2.Visible = True
        End If
    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        Try
            ComboBox2.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Usuarios where Nombre<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                ComboBox2.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        TextBox1.Focus.Equals(True)
        soy = ComboBox1.SelectedIndex + 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            If soy = 1 Then
                cmd1.CommandText = "Select P1,Clave from Usuarios where Nombre='" & ComboBox2.Text & "'"
            ElseIf soy = 2 Then
                cmd1.CommandText = "Select P2,CLave from Usuarios where Nombre='" & ComboBox2.Text & "'"
            ElseIf soy = 3 Then
                cmd1.CommandText = "Select P3,Clave from Usuarios where Nombre='" & ComboBox2.Text & "'"
            End If
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                If rd1(0).ToString = TextBox1.Text Then
                    If TextBox1.Text <> "" Then
                        MsgBox("Tu contraseña es: " & rd1(1).ToString, vbOKOnly + vbOKOnly, "Delsscom Control Negocios PRO")
                        ComboBox1.Text = ""
                        ComboBox2.Text = ""
                        TextBox1.Text = ""
                        GroupBox2.Visible = False
                    End If

                Else
                    MsgBox("Respuesta Incorrecta", vbCritical + vbOKOnly, "Delsscom Control Negocios PRO")
                    TextBox1.Focus.Equals(True)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub lblEmpresa_Click(sender As Object, e As EventArgs) Handles lblEmpresa.Click

    End Sub
End Class