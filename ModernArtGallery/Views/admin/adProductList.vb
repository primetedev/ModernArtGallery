Public Class adProductList

   

    Private Sub adProductList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Try
                SetDBConnection()
                Dim ds As DataSet = GetProductsByCategory("", "")
                If ds.Tables.Count = 0 Then Exit Sub
                flPanel.Controls.Clear()
                For Each Dr As DataRow In ds.Tables(0).Rows
                    flPanel.Controls.Add(New adProductItem(New Bitmap(CStr(My.Application.Info.DirectoryPath & "\images\" & Dr("i_id") & ".jpg")), Dr("i_description"), Dr("a_nickname"), Dr("i_price"), Dr("cg_description"), Dr("i_id")))
                Next
            Catch
            End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        For Each pItem As adProductItem In flPanel.Controls
            If pItem.chk.Checked = True Then
                If pItem.lblDesc.Tag <> "" Then DeleteProduct(pItem.lblDesc.Tag)
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ModUser Is Nothing Then
            Dim t As New login
            t.Show()
            t.BringToFront()
            System.Windows.Forms.Application.DoEvents()
            Me.Visible = False
            Timer1.Enabled = False
        End If
    End Sub

   
End Class