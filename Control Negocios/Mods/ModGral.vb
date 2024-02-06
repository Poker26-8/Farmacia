Imports System.Net.Mail
Imports System.Net
Imports MySql.Data

Module ModGral

    Public HrTiempo As String = ""
    Public HrEntrega As String = ""

    Public id_usu_log As Integer = 0
    Public ClaveUsuario As String = ""

    'Envio de correos
    Public recibe As String = ""
    Public envia As String = ""
    Public s_smtp As String = ""
    Public port As String = ""
    Public SSL As Boolean = False
    Public Aute As Boolean = False
    Public PassSend As String = ""
    Public body1, body2, body3, body4 As String

    Public mail As New MailMessage
    Public smtp As New SmtpClient

    Public PEDI As Boolean
    Public MyFolio As Double = 0

    'DatosRecarga
    Public Function DatosRecarga(ByVal valor As String) As String
        Dim respuesta As String = ""
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select Facturas, NotasCred, NumPart from Formatos where Facturas='" & valor & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    respuesta = rd5("NotasCred").ToString
                End If
            Else
                respuesta = ""
            End If
            rd5.Close() : cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
        Return respuesta
    End Function

    Public Function ObtenerNombreEquipo() As String
        Dim nombrePC As String
        nombrePC = Dns.GetHostName

        Return nombrePC
    End Function

    'ProdIEPS
    Public Function ProdsIEPS(ByVal cod As String) As Double
        If cod <> "" Then
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select IIEPS from Productos where Codigo='" & cod & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    ProdsIEPS = CDbl(rd5(0).ToString) / 100
                Else
                    ProdsIEPS = 0
                End If
            Else
                ProdsIEPS = 0
            End If
            rd5.Close() : cnn5.Close()
        Else
            ProdsIEPS = 0
        End If
    End Function

    'BorraLotes
    Public Sub BorraLotes()
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "delete from LoteCaducidad where Cantidad<=0"
            cmd5.ExecuteNonQuery()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn5.Close()
        End Try
    End Sub

    'SFormatos
    Public Function SFormatos(ByVal campo As String, ByVal valor As String)
        Dim existe As Boolean = False
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select NotasCred from Formatos where Facturas='" & campo & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    existe = True
                End If
            Else
                existe = False
            End If
            rd5.Close()

            If (existe) Then

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "update Formatos set NotasCred='" & valor & "' where Facturas='" & campo & "'"
                cmd5.ExecuteNonQuery()
            Else
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "insert into Formatos(Facturas,NotasCred,NumPart) values('" & campo & "','" & valor & "',0)"
                cmd5.ExecuteNonQuery()
            End If

            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
        Return Nothing
    End Function

    Public Function Dame_Regimen(ByVal pepito As String) As String
        Dim respuesta As String = ""
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                 "select Descripcion from RegimenFiscalSat where ClaveRegFis='" & pepito & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    respuesta = rd5(0).ToString()
                End If
            Else
                respuesta = ""
            End If
            rd5.Close() : cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString()) : cnn5.Close()
        End Try
        Return respuesta
    End Function

    Public Function Dame_ClaveReg(ByVal pipeto As String) As String
        Dim respuesta As String = ""
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                 "select ClaveRegFis from RegimenFiscalSat where Descripcion='" & pipeto & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    respuesta = rd5(0).ToString()
                End If
            Else
                respuesta = ""
            End If
            rd5.Close() : cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn5.Close()
        End Try
        Return respuesta
    End Function

    Public Function ValidaPermisos(ByVal user As String, ByVal permiso As String) As Boolean
        Dim id_usu As Integer = 0

        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                      "select IdEmpleado from Usuarios where Alias='" & user & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    id_usu = rd5(0).ToString()
                End If
            End If
            rd5.Close()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                      "select * from Permisos where IdEmpleado=" & id_usu
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    If rd5(permiso).ToString() = True Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn5.Close()
        End Try
#Disable Warning BC42353' La función no devuelve un valor
    End Function
#Enable Warning BC42353' La función no devuelve un valor

    'Promos
    Public Function Promos(ByVal codigo As String, ByVal actual As Double) As Double
        Dim FechaI As Date = Nothing, FechaF As Date = Nothing
        Dim DescPromo As Double = 0
        Dim INI As Integer = 0, FIN As Integer = 0

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Fecha_Inicial, Fecha_Final, Porcentaje_Promo, PrecioVentaIVA from Productos where Codigo='" & codigo & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    If CDbl(rd3(2).ToString) <> 0 Then
                        FechaI = rd3(0).ToString
                        FechaF = rd3(1).ToString
                        INI = DateDiff(DateInterval.Day, Date.Now, FechaI)
                        FIN = DateDiff(DateInterval.Day, Date.Now, FechaF)
                        If INI <= 0 And FIN >= 0 Then
                            DescPromo = CDbl(rd4(3).ToString) * (CDbl(rd3(2).ToString) / 100)
                            Promos = actual - DescPromo
                        Else
                            Promos = actual
                        End If
                    Else
                        Promos = actual
                    End If
                End If
            Else
                Promos = actual
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
#Disable Warning BC42353' La función no devuelve un valor
    End Function
#Enable Warning BC42353' La función no devuelve un valor

    Public Function Elimina_Especiales(ByVal texto As String) As String
        Elimina_Especiales = texto
        If texto = "*" Then Elimina_Especiales = ""
        If texto = "=" Then Elimina_Especiales = ""
        If texto = "!" Then Elimina_Especiales = ""
        If texto = "#" Then Elimina_Especiales = ""
        If texto = "$" Then Elimina_Especiales = ""
        If texto = "%" Then Elimina_Especiales = ""
        If texto = "&" Then Elimina_Especiales = ""
        If texto = "/" Then Elimina_Especiales = ""
        If texto = "(" Then Elimina_Especiales = ""
        If texto = ")" Then Elimina_Especiales = ""
        If texto = "?" Then Elimina_Especiales = ""
        If texto = "'" Then Elimina_Especiales = ""
        If texto = "¡" Then Elimina_Especiales = ""
        If texto = "¿" Then Elimina_Especiales = ""
        If texto = "." Then Elimina_Especiales = ""
        If texto = "," Then Elimina_Especiales = ""
        If texto = ":" Then Elimina_Especiales = ""
        If texto = ";" Then Elimina_Especiales = ""
        If texto = "_" Then Elimina_Especiales = ""
        If texto = "¨" Then Elimina_Especiales = ""
        If texto = "+" Then Elimina_Especiales = ""
        If texto = "[" Then Elimina_Especiales = ""
        If texto = "]" Then Elimina_Especiales = ""
        If texto = "{" Then Elimina_Especiales = ""
        If texto = "}" Then Elimina_Especiales = ""
        If texto = "´" Then Elimina_Especiales = ""

        Return Elimina_Especiales
    End Function
End Module
