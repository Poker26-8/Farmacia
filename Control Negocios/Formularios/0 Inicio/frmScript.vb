Imports MySql.Data
Imports System.Xml

Public Class frmScript

    Dim ruta As String
    '  Private aes As New AES()
    Private Sub frmScript_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub ejecutar_scryt_crearBase()

        Dim cnn As New MySqlClient.MySqlConnection(
                       "Server=" & txtservidor.Text & "; " &
                       "database=master; integrated security=yes")

        Dim s As String = "CREATE DATABASE " & TXTbasededatos.Text
        Dim cmd As New MySqlClient.MySqlCommand(s, cnn)

        Try

            cnn.Open()
            cmd.ExecuteNonQuery()

            ' SavetoXML(aes.Encrypt("Data Source=" & txtservidor.Text & ";Initial Catalog=" & TXTbasededatos.Text & ";Integrated Security=True", appPwdUnique, Integer.Parse("256")))
            ejecutar_scryt_crearProcedimientos_almacenados_y_tablas()
            ' Timer4.Start()
        Catch ex As Exception
        Finally
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try
    End Sub

    Public Sub SavetoXML(ByVal dbcnString)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load("ConnectionString.xml")
            Dim root As XmlElement = doc.DocumentElement
            root.Attributes.Item(0).Value = dbcnString
            Dim writer As XmlTextWriter = New XmlTextWriter("ConnectionString.xml", Nothing)
            writer.Formatting = Formatting.Indented
            doc.Save(writer)
            writer.Close()
        Catch ex As Exception
            MessageBox.Show("Es la Primera vez que estas abriendo ADA 369 Debes Ejecutar el Aplicativo como Administrador, da anticlik izquierdo y Elije *Ejecutar como Administrador*", "Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End Try

    End Sub

    Sub ejecutar_scryt_crearProcedimientos_almacenados_y_tablas()

        'ruta = Path.Combine(Directory.GetCurrentDirectory(), txtnombre_scrypt.Text & ".txt")

        'Dim fi As FileInfo = New FileInfo(ruta)
        'Dim sw As StreamWriter

        'Try
        '    If File.Exists(ruta) = False Then

        '        sw = File.CreateText(ruta)
        '        sw.WriteLine(txtCrear_procedimientos.Text)
        '        sw.Flush()
        '        sw.Close()
        '    ElseIf File.Exists(ruta) = True Then
        '        File.Delete(ruta)
        '        sw = File.CreateText(ruta)
        '        sw.WriteLine(txtCrear_procedimientos.Text)
        '        sw.Flush()
        '        sw.Close()
        '    End If
        'Catch ex As Exception

        'End Try

        'Try
        '    Dim Pross As Process = New Process

        '    Pross.StartInfo.FileName = "sqlcmd"
        '    Pross.StartInfo.Arguments = " -S " & txtservidor.Text & " -i " & txtnombre_scrypt.Text & ".txt"
        '    Pross.Start()
        '    SavetoXML_servidor(aes.Encrypt(txtservidor.Text, appPwdUnique, Integer.Parse("256")))
        '    SavetoXML_Base_de_datos(aes.Encrypt(TXTbasededatos.Text, appPwdUnique, Integer.Parse("256")))
        '    SavetoXML_Software(aes.Encrypt(txtsoftware.Text, appPwdUnique, Integer.Parse("256")))
        '    SavetoXML_Contraseña_de_Base_de_datos(aes.Encrypt(lblcontraseña.Text, appPwdUnique, Integer.Parse("256")))

        'Catch ex As Exception
        ' End Try


    End Sub
End Class