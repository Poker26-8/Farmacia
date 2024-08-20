Imports System.Data.OleDb
Imports System.Runtime.Remoting.Contexts

Public Class frmSubeMonedero
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        My.Application.DoEvents()
        Dim cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\BaseExportar\DL1.mdb;;Persist Security Info=True;Jet OLEDB:Database Password=jipl22")
        Dim cmd As OleDbCommand = New OleDbCommand
        Dim rd As OleDbDataReader

        Try

            Dim FOLIO As String = ""
            Dim cliente As String = ""
            Dim saldo As Double = 0
            Dim fechaalta As Date = Nothing
            Dim barras As String = ""
            Dim porcentaje As Double = 0
            Dim actualiza As Date = Nothing
            Dim cuantos As Integer = 0
            Dim fechanueva As String = ""
            Dim fec As String = ""

            cnn.Close() : cnn.Open()
            cmd = cnn.CreateCommand
            cmd.CommandText = "SELECT COUNT(Id) FROM monedero"
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                If rd.Read Then
                    cuantos = rd(0).ToString
                End If
            End If
            rd.Close()

            barsube.Value = 0
            barsube.Maximum = cuantos

            cmd = cnn.CreateCommand
            cmd.CommandText = "SELECT Folio,NomCliente,Saldo,FechaAlta,CodigoBarras,Porcentaje,FechaAct FROM monedero ORDER BY Id"
            rd = cmd.ExecuteReader
            Do While rd.Read
                If rd.HasRows Then
                    FOLIO = rd("Folio").ToString
                    cliente = rd("NomCliente").ToString
                    saldo = IIf(rd("Saldo").ToString = "", 0, rd("Saldo").ToString)
                    fechaalta = rd("FechaAlta").ToString
                    barras = rd("CodigoBarras").ToString
                    porcentaje = rd("Porcentaje").ToString
                    actualiza = IIf(rd("FechaAct").ToString = "", Date.Now, rd("FechaAct").ToString)

                    fechanueva = Format(fechaalta, "yyyy-MM-dd")
                    fec = Format(actualiza, "yyyy-MM-dd")

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO monedero(Folio,Cliente,Saldo,Alta,Barras,Porcentaje,Actualiza) VALUES('" & FOLIO & "','" & cliente & "'," & saldo & ",'" & fechanueva & "','" & barras & "'," & porcentaje & ",'" & fec & "')"
                    cmd2.ExecuteNonQuery()

                    barsube.Value = barsube.Value + 1

                    My.Application.DoEvents()

                End If
            Loop
            rd.Close()
            cnn.Close()
            MsgBox("Se insertaron " & cuantos & " productos")
            cnn2.Close()

            barsube.Value = 0


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmSubeMonedero_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class