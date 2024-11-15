Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks

Public Class frmConsultaBeneficios
    Private Sub frmConsultaBeneficios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaPorcentaje()
    End Sub
    Public Sub CreaPorcentaje()
        grdcaptura.Rows.Clear()
        grdcaptura.ColumnCount = 0
        grdcaptura.ColumnCount = 10
        With grdcaptura
            With .Columns(0)
                .HeaderText = "IdCombo"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = False
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "TotalPieces"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = False
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "Descripcion"
                .Width = 300
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Tipo"
                .Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Seleccion"
                .Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .Visible = False
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "Producto Cotizado"
                .Width = 150
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "Producto con Beneficio"
                .Width = 150
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "Monto"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "min"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = False
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "max"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = False
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AplicarVenta8()
    End Sub

    Public Async Function AplicarVenta8() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/sales"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"
        Dim userxd As String = ""
        userxd = Replace(frmVentas3.cboNombre.Text, " ", ".")
        Dim porDescuento As String = ""
        Using client As New HttpClient()

            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)


            Dim combos As New List(Of Object)

            For Each row As DataGridViewRow In grdcaptura.Rows
                If Not row.IsNewRow Then
                    porDescuento = CInt(row.Cells(7).Value)


                    Dim giftItem As New Dictionary(Of String, Object) From {
            {"sku", row.Cells(6).Value.ToString()},
            {"discount", CInt(row.Cells(7).Value)},
            {"minGiftPieces", CInt(row.Cells(8).Value)},
            {"maxGiftPieces", CInt(row.Cells(9).Value)}
        }


                    Dim combo As New Dictionary(Of String, Object) From {
            {"idCombo", row.Cells(0).Value.ToString()},
            {"giftType", row.Cells(3).Value.ToString()},
            {"selection", row.Cells(4).Value.ToString()},
            {"skuPurchase", row.Cells(5).Value.ToString()},
            {"giftItemList", New Dictionary(Of String, Object) From {
                {"giftItem", New List(Of Object) From {giftItem}}
            }}
        }


                    combos.Add(combo)
                End If
            Next

            ' Crear el JSON completo
            Dim jsonData As New Dictionary(Of String, Object) From {
    {"transaction", frmVentas3.lblfolio.Text},
    {"programData", New Dictionary(Of String, Object) From {
        {"id", "529"},
        {"type", "Laboratorios exclusivos"}
    }},
    {"user", userxd},
    {"cardAuthNum", frmVentas3.lblcardaunt.Text},
    {"giftAuthNum", frmVentas3.lblgift.Text},
    {"itemList", New Dictionary(Of String, Object) From {
        {"item", New List(Of Object) From {
            New Dictionary(Of String, Object) From {
                {"sku", "7501125189111"},
                {"quantity", 1},
                {"originQuantity", 1},
                {"unitPrice", 1000}
            }
        }}
    }},
    {"giftList", New Dictionary(Of String, Object) From {
        {"combo", combos}
    }}
}

            ' Serializar el JSON a una cadena
            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented)

            ' Muestra o usa jsonString según sea necesario
            MessageBox.Show(jsonString)

            ' Crear el contenido para el POST con JSON
            Dim content As New StringContent(jsonString, Encoding.UTF8, "application/json")

            ' Realizar la solicitud POST
            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

            ' Verificar si la solicitud fue exitosa
            If response.IsSuccessStatusCode Then
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)

                Dim message As String
                Dim startPos As Integer
                Dim endPos As Integer
                Dim numventa As String

                startPos = InStr(responseData, """message"" : """) + Len("""message"" : """)
                endPos = InStr(startPos, responseData, """")
                message = Mid(responseData, startPos, endPos - startPos)

                startPos = InStr(responseData, """saleNumber"" : """) + Len("""saleNumber"" : """)
                endPos = InStr(startPos, responseData, """")
                numventa = Mid(responseData, startPos, endPos - startPos)

                If message = "Success" Then
                    MsgBox("Beneficio FANASA Aplicado Correctamente", vbInformation + vbOKOnly, "Delsscom Farmacias")
                    frmVentas3.txtdescuento1.Text = porDescuento
                    My.Application.DoEvents()
                    frmVentas3.lblgift.Text = ""
                    frmVentas3.lblgift.BackColor = Color.White
                    frmVentas3.btncancelatrans.Visible = False
                    frmVentas3.btniniciar.PerformClick()
                    Me.Close()
                End If
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class