Imports Microsoft.VisualBasic.Strings
Imports System.Data.OleDb
Imports System.IO
Imports MySql.Data

Public NotInheritable Class frmPagado

    Private Sub frmPagado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Establezca el título del formulario.
        'Dim ApplicationTitle As String
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle = My.Application.Info.Title
        'Else
        '    ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If
        'Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.
        ' TODO: personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName

        txtNumPC.Text = MyNumPC
        My.Application.DoEvents()
        GenerateAndValidateKey() 'GenLicencia(txtNumPC.Text)
        txtLiberacion.Focus.Equals(True)
        My.Application.DoEvents()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Function GenLicencia(ByVal noPc As String) As String
        'Cambiar a otro proceso que evite fugas
        ' Dim PC As String = noPc
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim Licencia As String = ""
        Dim FileSerie As String

        If txtNumPC.TextLength <> 0 And txtLiberacion.TextLength <> 0 Then
            Licencia = GenerateAndValidateKey2(txtNumPC.Text) 'GenLicencia(Trim(txtNumPC.Text))

            If txtLiberacion.Text <> Licencia Then
                MsgBox("La licencia es Incorrecta.", vbInformation)
            Else
                crea_ruta(My.Computer.FileSystem.SpecialDirectories.Programs & "\DelsscomControlNegocios")
                FileSerie = My.Computer.FileSystem.SpecialDirectories.Programs & "\DelsscomControlNegocios\Lib3r4c10n.dll"
                WriteSerie(Trim(Licencia), FileSerie)
                System.IO.File.SetAttributes(My.Computer.FileSystem.SpecialDirectories.Programs & "\DelsscomControlNegocios\Lib3r4c10n.dll", FileAttributes.Hidden)

                'Actualiza la fecha de liberación
                Dim conexion As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;")
                Dim comando As OleDbCommand = New OleDbCommand
                Dim lector As OleDbDataReader = Nothing

                Dim fecha As String = ""
                Dim cadena As String = ""

                fecha = FormatDateTime(Date.Now, DateFormat.ShortDate)
                If fecha <> "" Then
                    cadena = Replace(fecha, "/", "?#$-")
                    cadena = Replace(cadena, "0", "pCjm")
                    cadena = Replace(cadena, "1", "FrDtee")
                    cadena = Replace(cadena, "2", "<pzef>")
                    cadena = Replace(cadena, "3", "_sdbEz")
                    cadena = Replace(cadena, "4", "@ddET")
                    cadena = "***" & cadena
                    cadena = Replace(cadena, "5", "-()opY")
                    cadena = Replace(cadena, "6", "TrdHJ")
                    cadena = Replace(cadena, "7", "Bno_o")
                    cadena = Replace(cadena, "8", "nRtwun")
                    cadena = cadena & "ASDWE"
                    cadena = Replace(cadena, "9", "uuIoo")
                End If

                conexion.Close() : conexion.Open()
                comando = conexion.CreateCommand
                comando.CommandText =
                    "update Server set Renta='" & cadena & "'"
                comando.ExecuteNonQuery()

                REM necesita una validación para saber sí la fecha de soporte va a ser igual o esa que sea aparte
                MsgBox("El sistema ha quedado liberado, se cerrará automáticamente para concluir configuraciones.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End
            End If
        Else
            MsgBox("Ingrese la serie de liberación.", MsgBoxStyle.Information, "Comedores Industriales")
            txtLiberacion.Focus()
        End If
    End Sub

    Private Function WriteSerie(ByVal linea As String, ByVal root_file As String) As Boolean

        Dim Datos As Stream
        Dim StrWrite As StreamWriter

        Try
            Datos = File.Open(root_file, IO.FileMode.Create, IO.FileAccess.Write)
            Datos.Seek(0, IO.SeekOrigin.Begin)
            StrWrite = New StreamWriter(Datos)
            StrWrite.WriteLine(linea)
            StrWrite.Close()
            WriteSerie = True
        Catch e As IOException
            MsgBox(e.Message)
            WriteSerie = False
        End Try
    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class
