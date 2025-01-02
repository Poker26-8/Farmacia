Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml
Imports Newtonsoft.Json.Linq
Imports Org.BouncyCastle.Math.EC

Public Class frmConsultaBeneficios
    Private Sub frmConsultaBeneficios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub ConsultaArriba()
        Try
            For xxx As Integer = 0 To grd1.Rows.Count - 1
                cnn3.Clone()
                cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "Select Nombre from Productos where CodBarra='" & grd1.Rows(xxx).Cells(0).Value.ToString & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.Read Then
                    grd1.Rows(xxx).Cells(1).Value = rd3(0).ToString
                End If
                rd3.Close()
                cnn3.Close()
            Next

        Catch ex As Exception
            cnn3.Close()
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub ConsultaAbajo()
        Try
            For xxx As Integer = 0 To grdcaptura.Rows.Count - 1
                cnn4.Clone()
                cnn4.Open()
                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "Select Nombre from Productos where CodBarra='" & grdcaptura.Rows(xxx).Cells(4).Value.ToString & "'"
                rd4 = cmd4.ExecuteReader
                If rd4.Read Then
                    grdcaptura.Rows(xxx).Cells(6).Value = rd4(0).ToString
                End If
                rd4.Close()
                cnn4.Close()
            Next

        Catch ex As Exception
            cnn4.Close()
            MessageBox.Show(ex.ToString)
        End Try
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
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "TotalPieces"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
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
                .Visible = True
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
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "max"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim voy As Integer = 0
            For xxx As Integer = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(xxx).Cells(8).Value Then
                    voy += 1
                Else

                End If
            Next
            If voy = 0 Then
                MsgBox("Selecciona un producto de los beneficios Obtenidos para continuar", vbInformation + vbOKOnly, "Delsscom Farmacias")
                Exit Sub
            Else
                If MsgBox("¿Deseas aplicar los beneficios obtenidos por parte de FANASA?", vbOKCancel, "Delsscom Farmacias") = vbCancel Then
                    Exit Sub
                End If
                AplicarVenta8()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
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
                    porDescuento = CInt(row.Cells(2).Value)
                    Dim isChecked As Boolean = Convert.ToBoolean(row.Cells(8).Value)
                    If isChecked Then
                    Else
                        Continue For
                    End If

                    Dim giftItem As New Dictionary(Of String, Object) From {
            {"sku", row.Cells(4).Value.ToString()},
            {"discount", CInt(row.Cells(2).Value)},
            {"minGiftPieces", CInt(row.Cells(7).Value)},
            {"maxGiftPieces", CInt(row.Cells(5).Value)}
        }


                    Dim combo As New Dictionary(Of String, Object) From {
            {"idCombo", row.Cells(0).Value.ToString()},
            {"giftType", row.Cells(1).Value.ToString()},
            {"selection", row.Cells(3).Value.ToString()},
            {"skuPurchase", row.Cells(4).Value.ToString()},
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
        {"item", New List(Of Object)()}
    }},
    {"giftList", New Dictionary(Of String, Object) From {
        {"combo", combos}
    }}
}

            Dim itemList As List(Of Object) = CType(jsonData("itemList")("item"), List(Of Object))

            For Each row As DataGridViewRow In grd1.Rows
                ' Verificar que no sea una fila nueva
                If Not row.IsNewRow Then
                    ' Construir el objeto del artículo desde los valores del DataGridView
                    Dim item As New Dictionary(Of String, Object) From {
            {"sku", row.Cells(0).Value.ToString()},
            {"quantity", Convert.ToInt32(row.Cells(2).Value)},
            {"originQuantity", Convert.ToInt32(row.Cells(2).Value)},
            {"unitPrice", Convert.ToDecimal(row.Cells(3).Value)}
        }
                    ' Agregar el artículo a la lista
                    itemList.Add(item)
                End If
            Next

            ' Serializar el JSON a una cadena
            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented)
            MessageBox.Show(jsonString)
            Dim content As New StringContent(jsonString, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

            If response.IsSuccessStatusCode Then
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                'MsgBox("Respuesta de la API: " & responseData)

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
                    If vienede = "Ventas1" Then
                    ElseIf vienede = "Ventas2" Then
                    ElseIf vienede = "Ventas3" Then
                        My.Application.DoEvents()
                        frmVentas3.lblFolioFanasa.Text = numventa
                        frmVentas3.lblgift.Text = ""
                        frmVentas3.lblgift.BackColor = Color.White
                        frmVentas3.btncancelatrans.Visible = False
                        frmVentas3.btniniciar.PerformClick()
                        Dim tipodescuento As String = ""
                        Dim productoApplica As String = ""
                        Dim monto As Double = 0
                        Dim montocondescuento As Double = 0
                        Dim totalpieces As Double = 0
                        For xxx As Integer = 0 To grdcaptura.Rows.Count - 1
                            Dim isChecked As Boolean = Convert.ToBoolean(grdcaptura.Rows(xxx).Cells(8).Value)
                            If isChecked Then
                            Else
                                Continue For
                            End If
                            tipodescuento = grdcaptura.Rows(xxx).Cells(1).Value.ToString
                            productoApplica = grdcaptura.Rows(xxx).Cells(4).Value.ToString
                            monto = grdcaptura.Rows(xxx).Cells(2).Value.ToString
                            totalpieces = grdcaptura.Rows(xxx).Cells(7).Value.ToString
                            If tipodescuento = "RestaPrecio" Then
                                For xxxx As Integer = 0 To frmVentas3.grdcaptura.Rows.Count - 1
                                    If frmVentas3.grdcaptura.Rows(xxxx).Cells(15).Value.ToString = productoApplica Then
                                        frmVentas3.grdcaptura.Rows(xxxx).Cells(5).Value = CDec(frmVentas3.grdcaptura.Rows(xxxx).Cells(5).Value) - CDec(monto)
                                        leyendafanasa = "*** Se obtuvo un beneficio por parte de fanasa ***"
                                        detallePesos = "Se aplico un descuento de: $ " & monto
                                        Try
                                            cnn1.Close()
                                            cnn1.Open()
                                            cmd1 = cnn1.CreateCommand
                                            cmd1.CommandText = "Insert into BeneficiosFanasa(Transaccion,Detalle,Codigo,Cantidad) values('" & numventa & "','" & detallePesos & "','" & productoApplica & "'," & totalpieces & ")"
                                            If cmd1.ExecuteNonQuery Then

                                            End If
                                            cnn1.Close()
                                        Catch ex As Exception

                                        End Try
                                        My.Application.DoEvents()
                                        'Exit For
                                    End If
                                Next
                            ElseIf tipodescuento = "Porcentaje" Then
                                For xxxx As Integer = 0 To frmVentas3.grdcaptura.Rows.Count - 1
                                    If frmVentas3.grdcaptura.Rows(xxxx).Cells(15).Value.ToString = productoApplica Then
                                        montocondescuento = CDec(frmVentas3.grdcaptura.Rows(xxxx).Cells(4).Value) / CDec(100) * CDec(monto)
                                        montocondescuento = CDec(montocondescuento * totalpieces)
                                        frmVentas3.grdcaptura.Rows(xxxx).Cells(5).Value = CDec(frmVentas3.grdcaptura.Rows(xxxx).Cells(5).Value) - CDec(montocondescuento)
                                        leyendafanasa = "*** Se obtuvo un beneficio por parte de fanasa ***"
                                        detallePorcentaje = "Se aplico un descuento de: " & monto & " %"
                                        Try
                                            cnn1.Close()
                                            cnn1.Open()
                                            cmd1 = cnn1.CreateCommand
                                            cmd1.CommandText = "Insert into BeneficiosFanasa(Transaccion,Detalle,Codigo,Cantidad) values('" & numventa & "','" & detallePorcentaje & "','" & productoApplica & "'," & totalpieces & ")"
                                            If cmd1.ExecuteNonQuery Then

                                            End If
                                            cnn1.Close()
                                        Catch ex As Exception

                                        End Try
                                        My.Application.DoEvents()

                                    End If
                                Next
                            ElseIf tipodescuento = "Pieza" Then
                                soygratis = 1
                                frmVentas3.cbodesc.Text = productoApplica
                                leyendafanasa = "*** Se obtuvo un beneficio por parte de fanasa ***"
                                detallePieza = "Se obtuvo una pieza de regalo"
                                Try
                                    cnn1.Close()
                                    cnn1.Open()
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText = "Insert into BeneficiosFanasa(Transaccion,Detalle,Codigo,Cantidad) values('" & numventa & "','" & detallePieza & "','" & productoApplica & "'," & totalpieces & ")"
                                    If cmd1.ExecuteNonQuery Then

                                    End If
                                    cnn1.Close()
                                Catch ex As Exception

                                End Try
                                My.Application.DoEvents()
                                Call frmVentas3.cbodesc_KeyPress(frmVentas3.cbodesc, New KeyPressEventArgs(ChrW(Keys.Enter)))
                            ElseIf tipodescuento = "PrecioFijo" Then
                                For xxxx As Integer = 0 To frmVentas3.grdcaptura.Rows.Count - 1
                                    If frmVentas3.grdcaptura.Rows(xxxx).Cells(15).Value.ToString = productoApplica Then
                                        frmVentas3.grdcaptura.Rows(xxxx).Cells(4).Value = CDec(monto)
                                        frmVentas3.grdcaptura.Rows(xxxx).Cells(5).Value = CDec(monto)
                                        leyendafanasa = "*** Se obtuvo un beneficio por parte de fanasa ***"
                                        detallePrecioFijo = "Se aplico un precio fijo de: $ " & monto
                                        Try
                                            cnn1.Close()
                                            cnn1.Open()
                                            cmd1 = cnn1.CreateCommand
                                            cmd1.CommandText = "Insert into BeneficiosFanasa(Transaccion,Detalle,Codigo,Cantidad) values('" & numventa & "','" & detallePrecioFijo & "','" & productoApplica & "', " & totalpieces & ")"
                                            If cmd1.ExecuteNonQuery Then

                                            End If
                                            cnn1.Close()
                                        Catch ex As Exception

                                        End Try
                                        My.Application.DoEvents()
                                        'Exit For
                                    End If
                                Next
                            End If
                        Next
                        My.Application.DoEvents()
                        Dim voy As Double = 0
                        Dim VarSumXD As Double = 0
                        For w = 0 To frmVentas3.grdcaptura.Rows.Count - 1
                            If frmVentas3.grdcaptura.Rows(w).Cells(6).Value.ToString = "" Then
                            Else
                                VarSumXD = VarSumXD + CDbl(frmVentas3.grdcaptura.Rows(w).Cells(5).Value.ToString)
                                voy = voy + CDec(frmVentas3.grdcaptura.Rows(w).Cells(3).Value)
                            End If
                            frmVentas3.txtSubTotal.Text = FormatNumber(VarSumXD, 2)
                            My.Application.DoEvents()
                        Next
                        If CDbl(frmVentas3.txtdescuento1.Text) <= 0 Then
                            frmVentas3.txtPagar.Text = CDbl(frmVentas3.txtSubTotal.Text) - CDbl(frmVentas3.txtdescuento2.Text)
                            frmVentas3.txtPagar.Text = FormatNumber(frmVentas3.txtPagar.Text, 2)
                        End If
                        My.Application.DoEvents()
                        MsgBox("Beneficio FANASA Aplicado Correctamente", vbInformation + vbOKOnly, "Delsscom Farmacias")
                        My.Application.DoEvents()
                        Call frmVentas3.txtdescuento1_TextChanged(frmVentas3.txtdescuento1, New EventArgs())
                        My.Application.DoEvents()
                        frmVentas3.txtefectivo.Focus.Equals(True)
                        My.Application.DoEvents()
                        Me.Close()
                    End If
                Else
                    MsgBox(message)
                End If
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RechazarBeneficios10()
    End Sub

    Public Async Function RechazarBeneficios10() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/gifts"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

        Using client As New HttpClient()
            ' Crear el encabezado de autenticación en Base64
            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)
            ' Crear el contenido JSON con los datos proporcionados
            Dim jsonData As String = "{
    ""transaction"": """ & frmVentas3.lblfolio.Text & """,
    ""cardAuthNum"": """ & frmVentas3.lblcardaunt.Text & """,
    ""giftAuthNum"": """ & frmVentas3.lblgift.Text & """,
    ""giftList"": {
        ""combo"": []
    }
}"

            ' Deserializar el JSON original
            Dim jsonObject As JObject = JObject.Parse(jsonData)

            ' Obtener el arreglo "combo" del JSON
            Dim comboArray As JArray = jsonObject("giftList")("combo")

            ' Llenar los datos desde el DataGridView
            For Each row As DataGridViewRow In grdcaptura.Rows
                If Not row.IsNewRow Then
                    Dim isChecked As Boolean = Convert.ToBoolean(row.Cells(8).Value)
                    If isChecked Then
                    Else
                        Continue For
                    End If
                    Dim idCombo As String = row.Cells(0).Value.ToString()
                    Dim sku As String = row.Cells(4).Value.ToString()
                    Dim minGiftPieces As Integer = CInt(row.Cells(7).Value)

                    ' Crear el objeto "combo"
                    Dim comboObject As New JObject(
            New JProperty("idCombo", idCombo),
            New JProperty("giftItemList", New JObject(
                New JProperty("giftItem", New JArray(
                    New JObject(
                        New JProperty("sku", sku),
                        New JProperty("minGiftPieces", minGiftPieces)
                    )
                ))
            ))
        )

                    ' Añadir el objeto al array "combo"
                    comboArray.Add(comboObject)
                End If
            Next

            ' Convertir el JSON actualizado a String
            Dim updatedJson As String = jsonObject.ToString(Formatting.Indented)
            MsgBox(updatedJson)
            ' Crear el contenido para el PUT con JSON
            Dim content As New StringContent(updatedJson, Encoding.UTF8, "application/json")

            ' Realizar la solicitud PUT
            Dim response As HttpResponseMessage = Await client.PutAsync(url, content)

            ' Verificar si la solicitud fue exitosa
            If response.IsSuccessStatusCode Then
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                Dim message As String
                Dim startPos As Integer
                Dim endPos As Integer
                startPos = InStr(responseData, """message"" : """) + Len("""message"" : """)
                endPos = InStr(startPos, responseData, """")
                message = Mid(responseData, startPos, endPos - startPos)
                MsgBox("Respuesta de la API: " & responseData)


                If message = "Success" Then
                    frmVentas3.lblgift.Text = ""
                    frmVentas3.lblgift.BackColor = Color.White
                    frmVentas3.btncancelatrans.Visible = False
                    frmVentas3.btniniciar.PerformClick()

                    MsgBox("Beneficio Rechazado Correctamente", vbInformation + vbOKOnly, "Delsscom Farmacias")
                    grdcaptura.Rows.Clear()
                    Me.Close()

                Else
                End If
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Private Sub grdcaptura_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdcaptura.CurrentCellDirtyStateChanged
        If grdcaptura.IsCurrentCellDirty Then
            grdcaptura.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub grdcaptura_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellValueChanged
        If e.ColumnIndex = 8 AndAlso e.RowIndex >= 0 Then
            Dim currentValue As Boolean = CBool(grdcaptura.Rows(e.RowIndex).Cells(8).Value) ' Columna del CheckBox
            Dim currentValueCol1 As String = grdcaptura.Rows(e.RowIndex).Cells(0).Value.ToString() ' Columna 1

            ' Si el CheckBox está seleccionado, deselecciona otros con la misma Columna 1
            If currentValue Then
                For Each row As DataGridViewRow In grdcaptura.Rows
                    If row.Index <> e.RowIndex AndAlso row.Cells(0).Value.ToString() = currentValueCol1 Then
                        row.Cells(8).Value = False
                    End If
                Next
            End If
        End If
    End Sub
End Class