Imports System.Data.OleDb
Imports MySql.Data

Public Class frmLiberado

    Private Sub frmLiberado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblSerie.Text = GenerateAndValidateKey2(MyNumPC)

        Dim cias As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
        Dim coma As OleDbCommand = New OleDbCommand
        Dim lect As OleDbDataReader = Nothing

        Dim cadena As String = ""

        cias.Close() : cias.Open()
        coma = cias.CreateCommand
        coma.CommandText =
            "select Renta from Server"
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

        lblfecha.Text = fecha
        My.Application.DoEvents()
    End Sub

    Public Function GenLicencia(ByVal noPc As String) As String
        'Cambiar a otro proceso que evite fugas
        Dim PC As String = noPc
        Dim letrasPC As String = ""
        Dim numerosPC As String = ""
        PC = Replace(PC, "/", "")
        For x As Integer = 1 To Len(PC)
            Dim RecortaPC As String = PC
            If IsNumeric(Mid(RecortaPC, x, 1)) Then
                numerosPC = numerosPC & Mid(RecortaPC, x, 1)
            End If
            If Not IsNumeric(Mid(RecortaPC, x, 1)) Then
                letrasPC = letrasPC & Mid(RecortaPC, x, 1)
            End If
            RecortaPC = Mid(RecortaPC, x, 500)
        Next
        Dim EntPC As Long = Convert.ToDecimal(numerosPC)
        Dim i As Byte
        Dim Numeros As String
        Dim Numeros2 As String
        Dim Letras As String
        Dim lic As String = ""
        Dim letters As String = ""
        Dim Car As String = ""
        Dim ope As Double = 0

        ope = Math.Cos(CDec(numerosPC))

        If ope > 0 Then
            PC = Strings.Left(Replace(CStr(ope), ".", "9"), 13)
        Else 'Quita los negativos
            PC = Strings.Left(Replace(CStr(Math.Abs(ope)), ".", "8"), 13)
        End If

        For i = 1 To 12
            Car = CDec(Mid(PC, i, 1)) - CDec(Mid(PC, i + 1, 1))
            Select Case Car

                Case Is = 0
                    letters = letters & "Z"
                Case Is = 1
                    letters = letters & "Y"
                Case Is = 2
                    letters = letters & "X"
                Case Is = 3
                    letters = letters & "W"
                Case Is = 4
                    letters = letters & "V"
                Case Is = 5
                    letters = letters & "a"
                Case Is = 6
                    letters = letters & "B"
                Case Is = 7
                    letters = letters & "C"
                Case Is = 8
                    letters = letters & "d"
                Case Is = 9
                    letters = letters & "E"
                Case Is = -1
                    letters = letters & "f"
                Case Is = -2
                    letters = letters & "g"
                Case Is = -3
                    letters = letters & "H"
                Case Is = -4
                    letters = letters & "i"
                Case Is = -5
                    letters = letters & "j"
                Case Is = -6
                    letters = letters & "k"
                Case Is = -7
                    letters = letters & "L"
                Case Is = -8
                    letters = letters & "M"
                Case Is = -9
                    letters = letters & "n"
                Case Else
                    letters = letters & Car
            End Select
        Next
        For i = 1 To 9 Step 2
            Numeros = Mid(PC, i, 1)
            Letras = Mid(letters, i, 1)
            Numeros2 = Mid(PC, i + 1, 1)
            lic = lic & Numeros & Letras & Numeros2 & "-"
        Next
        lic = Strings.Left(lic, lic.Length - 1)
        GenLicencia = lic

    End Function

    Private Sub frmLiberado_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If AscW(e.KeyChar) = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class