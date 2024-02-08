Imports Core.DAL.DE

Public Class frmRecargaC

    Dim companiat As String = ""

    Friend WithEvents btnCompania As System.Windows.Forms.Button
    Private Sub frmRecargaC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        companias()

    End Sub

    Public Sub companias()

        Dim companias As Integer = 0
        Dim TOTCOMPA As Integer = 0
        Dim cuantos As Integer = Math.Truncate(pCompania.Height / 50)
        Dim totalcompanias As Integer = 0
        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT DISTINCT Nombre FROM recargas ORDER BY Nombre"
        rd1 = cmd1.ExecuteReader
        Do While rd1.Read
            If rd1.HasRows Then

                Dim compania As String = rd1("Nombre").ToString

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT COUNT(Id) FROM recargas WHERE Nombre='" & compania & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        TOTCOMPA = rd2(0).ToString
                    End If
                End If
                rd2.Close()

                totalcompanias = totalcompanias + TOTCOMPA

                btnCompania = New Button
                btnCompania.Text = compania
                btnCompania.Name = "btnDepto(" & companias & ")"
                btnCompania.Left = 0
                btnCompania.Width = 120
                btnCompania.Height = 80
                ' btnCompania.ForeColor = Color.White
                If companias > cuantos And companias < ((cuantos * 2) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 1)
                    btnCompania.Top = (companias - (cuantos + 1)) * (btnCompania.Height + 1)
                    btnCompania.BackColor = Color.SkyBlue

                    '2
                ElseIf companias > (cuantos * 2) And companias < ((cuantos * 3) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 2)
                    btnCompania.Top = (companias - ((cuantos * 2) + 1)) * (btnCompania.Height + 1)
                    btnCompania.BackColor = Color.PaleTurquoise
                    '3
                ElseIf companias > (cuantos * 3) And companias < ((cuantos * 4) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 3)
                    btnCompania.Top = (companias - ((cuantos * 3) + 1)) * (btnCompania.Height + 1)
                    btnCompania.BackColor = Color.SkyBlue
                    '4
                ElseIf companias > (cuantos * 4) And companias < ((cuantos * 5) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 4)
                    btnCompania.Top = (companias - ((cuantos * 4) + 1)) * (btnCompania.Height + 1)
                    btnCompania.BackColor = Color.PaleTurquoise
                    '5
                ElseIf companias > (cuantos * 5) And companias < ((cuantos * 6) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 5)
                    btnCompania.Top = (companias - ((cuantos * 5) + 1)) * (btnCompania.Height + 1)
                    btnCompania.BackColor = Color.SkyBlue
                    '6
                ElseIf companias > (cuantos * 6) And companias < ((cuantos * 7) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 6)
                    btnCompania.Top = (companias - ((cuantos * 6) + 1)) * (btnCompania.Height + 1)
                    btnCompania.BackColor = Color.PaleTurquoise
                    '7
                ElseIf companias > (cuantos * 7) And companias < ((cuantos * 8) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 7)
                    btnCompania.Top = (companias - ((cuantos * 7) + 1)) * (btnCompania.Height + 1)
                    '8
                ElseIf companias > (cuantos * 8) And companias < ((cuantos * 9) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 8)
                    btnCompania.Top = (companias - ((cuantos * 8) + 1)) * (btnCompania.Height + 1)
                    '9
                ElseIf companias > (cuantos * 9) And companias < ((cuantos * 10) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 9)
                    btnCompania.Top = (companias - ((cuantos * 9) + 1)) * (btnCompania.Height + 1)
                    '10
                ElseIf companias > (cuantos * 10) And companias < ((cuantos * 11) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 10)
                    btnCompania.Top = (companias - ((cuantos * 10) + 1)) * (btnCompania.Height + 1)
                    '11
                ElseIf companias > (cuantos * 11) And companias < ((cuantos * 12) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 11)
                    btnCompania.Top = (companias - ((cuantos * 11) + 1)) * (btnCompania.Height + 1)
                    '12
                ElseIf companias > (cuantos * 12) And companias < ((cuantos * 13) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 12)
                    btnCompania.Top = (companias - ((cuantos * 12) + 1)) * (btnCompania.Height + 1)
                    '13
                ElseIf companias > (cuantos * 13) And companias < ((cuantos * 14) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 13)
                    btnCompania.Top = (companias - ((cuantos * 13) + 1)) * (btnCompania.Height + 1)
                    '14
                ElseIf companias > (cuantos * 14) And companias < ((cuantos * 15) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 14)
                    btnCompania.Top = (companias - ((cuantos * 14) + 1)) * (btnCompania.Height + 1)
                    '15
                ElseIf companias > (cuantos * 15) And companias < ((cuantos * 16) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 15)
                    btnCompania.Top = (companias - ((cuantos * 15) + 1)) * (btnCompania.Height + 1)
                    '16
                ElseIf companias > (cuantos * 16) And companias < ((cuantos * 17) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 16)
                    btnCompania.Top = (companias - ((cuantos * 16) + 1)) * (btnCompania.Height + 1)
                    '17
                ElseIf companias > (cuantos * 17) And companias < ((cuantos * 18) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 17)
                    btnCompania.Top = (companias - ((cuantos * 17) + 1)) * (btnCompania.Height + 1)
                    '18
                ElseIf companias > (cuantos * 18) And companias < ((cuantos * 19) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 18)
                    btnCompania.Top = (companias - ((cuantos * 18) + 1)) * (btnCompania.Height + 1)
                    '19
                ElseIf companias > (cuantos * 19) And companias < ((cuantos * 20) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 19)
                    btnCompania.Top = (companias - ((cuantos * 19) + 1)) * (btnCompania.Height + 1)
                    '20
                ElseIf companias > (cuantos * 20) And companias < ((cuantos * 21) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 20)
                    btnCompania.Top = (companias - ((cuantos * 20) + 1)) * (btnCompania.Height + 1)
                    '21
                ElseIf companias > (cuantos * 21) And companias < ((cuantos * 22) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 21)
                    btnCompania.Top = (companias - ((cuantos * 21) + 1)) * (btnCompania.Height + 1)
                    '22
                ElseIf companias > (cuantos * 22) And companias < ((cuantos * 23) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 22)
                    btnCompania.Top = (companias - ((cuantos * 22) + 1)) * (btnCompania.Height + 1)
                    '23
                ElseIf companias > (cuantos * 23) And companias < ((cuantos * 24) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 23)
                    btnCompania.Top = (companias - ((cuantos * 23) + 1)) * (btnCompania.Height + 1)
                    '24
                ElseIf companias > (cuantos * 24) And companias < ((cuantos * 25) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 24)
                    btnCompania.Top = (companias - ((cuantos * 24) + 1)) * (btnCompania.Height + 1)
                    '25
                ElseIf companias > (cuantos * 25) And companias < ((cuantos * 26) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 25)
                    btnCompania.Top = (companias - ((cuantos * 25) + 1)) * (btnCompania.Height + 1)
                    '26
                ElseIf companias > (cuantos * 26) And companias < ((cuantos * 27) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 26)
                    btnCompania.Top = (companias - ((cuantos * 26) + 1)) * (btnCompania.Height + 1)
                    '27
                ElseIf companias > (cuantos * 27) And companias < ((cuantos * 28) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 27)
                    btnCompania.Top = (companias - ((cuantos * 27) + 1)) * (btnCompania.Height + 1)
                    '28
                ElseIf companias > (cuantos * 28) And companias < ((cuantos * 29) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 28)
                    btnCompania.Top = (companias - ((cuantos * 28) + 1)) * (btnCompania.Height + 1)
                    '29
                ElseIf companias > (cuantos * 29) And companias < ((cuantos * 30) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 29)
                    btnCompania.Top = (companias - ((cuantos * 29) + 1)) * (btnCompania.Height + 1)
                    '30
                ElseIf companias > (cuantos * 30) And companias < ((cuantos * 31) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 30)
                    btnCompania.Top = (companias - ((cuantos * 30) + 1)) * (btnCompania.Height + 1)
                    '31
                ElseIf companias > (cuantos * 31) And companias < ((cuantos * 32) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 31)
                    btnCompania.Top = (companias - ((cuantos * 31) + 1)) * (btnCompania.Height + 1)
                    '32
                ElseIf companias > (cuantos * 32) And companias < ((cuantos * 33) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 32)
                    btnCompania.Top = (companias - ((cuantos * 32) + 1)) * (btnCompania.Height + 1)
                    '33
                ElseIf companias > (cuantos * 33) And companias < ((cuantos * 34) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 33)
                    btnCompania.Top = (companias - ((cuantos * 33) + 1)) * (btnCompania.Height + 1)
                    '34
                ElseIf companias > (cuantos * 34) And companias < ((cuantos * 35) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 34)
                    btnCompania.Top = (companias - ((cuantos * 34) + 1)) * (btnCompania.Height + 1)
                    '35
                ElseIf companias > (cuantos * 35) And companias < ((cuantos * 36) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 35)
                    btnCompania.Top = (companias - ((cuantos * 35) + 1)) * (btnCompania.Height + 1)
                    '36
                ElseIf companias > (cuantos * 36) And companias < ((cuantos * 37) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 36)
                    btnCompania.Top = (companias - ((cuantos * 36) + 1)) * (btnCompania.Height + 1)
                    '37
                ElseIf companias > (cuantos * 37) And companias < ((cuantos * 38) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 37)
                    btnCompania.Top = (companias - ((cuantos * 37) + 1)) * (btnCompania.Height + 1)
                    '38
                ElseIf companias > (cuantos * 38) And companias < ((cuantos * 39) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 38)
                    btnCompania.Top = (companias - ((cuantos * 38) + 1)) * (btnCompania.Height + 1)
                    '39
                ElseIf companias > (cuantos * 39) And companias < ((cuantos * 40) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 39)
                    btnCompania.Top = (companias - ((cuantos * 39) + 1)) * (btnCompania.Height + 1)
                    '40
                ElseIf companias > (cuantos * 40) And companias < ((cuantos * 41) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 40)
                    btnCompania.Top = (companias - ((cuantos * 40) + 1)) * (btnCompania.Height + 1)
                    '41
                ElseIf companias > (cuantos * 41) And companias < ((cuantos * 42) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 41)
                    btnCompania.Top = (companias - ((cuantos * 41) + 1)) * (btnCompania.Height + 1)
                    '42
                ElseIf companias > (cuantos * 42) And companias < ((cuantos * 43) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 42)
                    btnCompania.Top = (companias - ((cuantos * 42) + 1)) * (btnCompania.Height + 1)
                    '43
                ElseIf companias > (cuantos * 43) And companias < ((cuantos * 44) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 43)
                    btnCompania.Top = (companias - ((cuantos * 43) + 1)) * (btnCompania.Height + 1)
                    '44
                ElseIf companias > (cuantos * 44) And companias < ((cuantos * 45) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 44)
                    btnCompania.Top = (companias - ((cuantos * 44) + 1)) * (btnCompania.Height + 1)
                    '45
                ElseIf companias > (cuantos * 45) And companias < ((cuantos * 46) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 45)
                    btnCompania.Top = (companias - ((cuantos * 45) + 1)) * (btnCompania.Height + 1)
                    '46
                ElseIf companias > (cuantos * 46) And companias < ((cuantos * 47) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 46)
                    btnCompania.Top = (companias - ((cuantos * 46) + 1)) * (btnCompania.Height + 1)
                    '47
                ElseIf companias > (cuantos * 47) And companias < ((cuantos * 48) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 47)
                    btnCompania.Top = (companias - ((cuantos * 47) + 1)) * (btnCompania.Height + 1)
                    '48
                ElseIf companias > (cuantos * 48) And companias < ((cuantos * 49) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 48)
                    btnCompania.Top = (companias - ((cuantos * 48) + 1)) * (btnCompania.Height + 1)
                    '49
                ElseIf companias > (cuantos * 49) And companias < ((cuantos * 50) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 49)
                    btnCompania.Top = (companias - ((cuantos * 49) + 1)) * (btnCompania.Height + 1)
                    '50
                ElseIf companias > (cuantos * 50) And companias < ((cuantos * 51) + 1) Then
                    btnCompania.Left = (btnCompania.Width * 50)
                    btnCompania.Top = (companias - ((cuantos * 50) + 1)) * (btnCompania.Height + 1)
                    '51
                Else
                    btnCompania.Left = 0
                    btnCompania.Top = (companias - 1) * (btnCompania.Height + 1)
                    btnCompania.BackColor = Color.PaleTurquoise
                End If


                '   btnCompania.BackColor = pCompania.BackColor
                btnCompania.FlatStyle = FlatStyle.Popup
                btnCompania.FlatAppearance.BorderSize = 0
                AddHandler btnCompania.Click, AddressOf btnCompania_Click
                pCompania.Controls.Add(btnCompania)
                'If companias = 0 Then
                '    Grupos(departamento)
                'End If
                companias += 1

                If totalcompanias <= 5 Then
                    pCompania.AutoScroll = False
                Else
                    pCompania.AutoScroll = True
                End If
            End If
        Loop
        rd1.Close()
        cnn1.Close()
        cnn2.Close()
    End Sub

    Public Sub btnCompania_Click(sender As Object, e As EventArgs)

        Dim btnCom As Button = CType(sender, Button)

        companiat = btnCom.Text
        txtCompania.Text = companiat
    End Sub
End Class