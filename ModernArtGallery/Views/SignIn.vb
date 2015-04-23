Imports System.Data.SqlClient

Public Class SignIn

    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click
        End
    End Sub

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Dim result As String = ""
        result = RegisterNewVisitor(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPassWord.Text)
        If result = "True" Then
            result = LoginUser(txtLoginEmail.Text, txtLoginPass.Text, False)
            If result = "True" Then
                txtLoginEmail.Text = ""
                txtLoginPass.Text = ""
                panelLoggedInTop.Visible = True
                txtLoggedIn.Text = "Welcome back " & CurrentUser.firstName & "! | Log out"
            Else
                lblLoginInfo.Text = result
                lblLoginInfo.Visible = True
            End If
        Else
            lblInfo.Text = result
            lblInfo.Visible = True
        End If
    End Sub

    Private Sub SignIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDBConnection()
    End Sub

  
    Private Sub btnSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        Dim result As String = ""
        result = LoginUser(txtLoginEmail.Text, txtLoginPass.Text, False)
        If result = "True" Then
            txtLoginEmail.Text = ""
            txtLoginPass.Text = ""
            panelLoggedInTop.Visible = True
            txtLoggedIn.Text = "Welcome back " & CurrentUser.firstName & "! | Log out"
        Else
            lblLoginInfo.Text = result
            lblLoginInfo.Visible = True
        End If
    End Sub

  
   
End Class
