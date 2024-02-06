Imports System.Data.OleDb
Imports MySql.Data
Module Mod_Conexion
    Public texto As String
    Public conexion As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
    Public conexion2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
    Public fallo As Integer
    Public fallo2 As Integer
    Public ArreIeps(500, 500) As String
    Public ArreIepsBase(500, 500) As String
    Public var265(3000) As Decimal
    Public var3(3000) As Decimal
    Public var53(3000) As Decimal
    Public var5(3000) As Decimal
    Public var1600(3000) As Decimal
    Public var304(3000) As Decimal
    Public var25(3000) As Decimal
    Public var09(3000) As Decimal
    Public var08(3000) As Decimal
    Public var07(3000) As Decimal
    Public var06(3000) As Decimal
    Public var03(3000) As Decimal

    Public Bvar265 As Decimal = 0
    Public Bvar3 As Decimal = 0
    Public Bvar53 As Decimal = 0
    Public Bvar5 As Decimal = 0
    Public Bvar1600 As Decimal = 0
    Public Bvar304 As Decimal = 0
    Public Bvar25 As Decimal = 0
    Public Bvar09 As Decimal = 0
    Public Bvar08 As Decimal = 0
    Public Bvar07 As Decimal = 0
    Public Bvar06 As Decimal = 0
    Public Bvar03 As Decimal = 0
    Public sumatoriaIEPS As Decimal = 0
    Public strconjunto As String = ""

    '''''variables Parcialidades'''''''
    Public folFactParc As String = ""
    Public folFactParcID As String = ""
    Public RazonID As String = ""
    Public SeriePar As String = ""
    Public EmiIdDatos As Integer = 0
    Public CliIdDatos As Integer = 0
    Public email As String = ""
    '''''''''''''''''''''''''''''''''''

    Sub abrir()
        Try
            conexion = New MySqlClient.MySqlConnection(sTarget)
            conexion.Open()
            fallo = 0
        Catch ex As Exception
            MsgBox("Fallo en la conexion de la base de datos")
            fallo = 1
        End Try
    End Sub

    Sub abrir2()
        Try
            conexion2 = New MySqlClient.MySqlConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & My.Application.Info.DirectoryPath & "\ActuTablas\DL1.mdb'; Jet OLEDB:Database Password=jipl22;")
            conexion2.Open()
            fallo2 = 0
        Catch ex As Exception
            MsgBox("Fallo en la conexion de la base de datos de destino")
            fallo2 = 1
        End Try
    End Sub
End Module
