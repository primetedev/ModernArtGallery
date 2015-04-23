Public Class search

    Private Sub search_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDBConnection()
    End Sub

    Private Sub GetListItems()
        Try
            SetDBConnection()
            Dim ds As DataSet = GetProductsByCategory(1, GetOrderBy)
            If ds.Tables.Count = 0 Then Exit Sub
            FLPanel.Controls.Clear()
            For Each Dr As DataRow In ds.Tables(0).Rows
                FLPanel.Controls.Add(New SearchItem(New Bitmap(CStr(My.Application.Info.DirectoryPath & "\images\" & Dr("i_id") & ".jpg")), Dr("i_description"), Dr("a_nickname"), Dr("i_price")))
            Next
        Catch
        End Try
    End Sub

    Private Function GetOrderBy() As String
        Select Case LCase(cbOrder.Text)
            Case "what's new"
                Return " order by i_id desc"
            Case "price: low to high"
                Return " order by i_price"
            Case "price: high to low"
                Return " order by i_price desc"
            Case "a-z"
                Return " order by i_description"
            Case "z-a"
                Return " order by i_description desc"
            Case "artist"
                Return " order by a_nickname"
        End Select
        Return ""
    End Function

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        End
    End Sub

    Private Sub cbOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOrder.SelectedIndexChanged
        GetListItems()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = 13 Then
            Try
                SetDBConnection()
                Dim ds As DataSet = GetProductsBySearch(TextBox1.Text, GetOrderBy)
                If ds.Tables.Count = 0 Then Exit Sub
                FLPanel.Controls.Clear()
                For Each Dr As DataRow In ds.Tables(0).Rows
                    FLPanel.Controls.Add(New SearchItem(New Bitmap(CStr(My.Application.Info.DirectoryPath & "\images\" & Dr("i_id") & ".jpg")), Dr("i_description"), Dr("a_nickname"), Dr("i_price")))
                Next
            Catch ex As Exception

            End Try
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub btnSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        Dim t As New SignIn
        t.Show()
        Me.Visible = False
    End Sub

   
End Class