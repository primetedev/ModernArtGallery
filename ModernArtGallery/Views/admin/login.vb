Public Class login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As String = ""
        result = LoginUser(txtUsername.Text, txtPassword.Text, True)
        If result = "True" Then
            Dim adProd As New adProductList
            adProd.Show()
            System.Windows.Forms.Application.DoEvents()
            Me.Visible = False
        Else
            lblError.Text = result
            lblError.Visible = True
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Dim t As New search
        t.Show()
        System.Windows.Forms.Application.DoEvents()
        Me.Visible = False
    End Sub
End Class