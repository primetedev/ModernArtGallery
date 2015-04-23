Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Module SignInLibrary

    Friend Function LoginUser(ByVal email As String, ByVal password As String, ByVal ForAdminPanel As Boolean)
        SetDBConnection()

        'Check for SQL Injection
        email = chkTxT(email)
        password = chkTxT(password)

        'Validations
        If Trim(email) = "" Then
            Return "Please fill in your email"
        End If

        If Trim(password) = "" Then
            Return "Please fill in your password"
        End If

        If EmailAddressChecker(email) = False Then
            Return "Please fill in a valid email address"
        End If


        Dim MyAdapter As New SqlDataAdapter
        Dim MySqlCommand As New SqlCommand

        'Check if user is registered
        Try
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            MySqlCommand.Connection = ConSQL
            If ForAdminPanel = True Then
                MySqlCommand.CommandText = "select u_id, u_firstname, u_lastname from users where u_emailAddress = '" & email & "' and u_password = '" & password & "'"
            Else
                MySqlCommand.CommandText = "select c_id, c_firstname, c_lastname from clients where c_emailAddress = '" & email & "' and c_password = '" & password & "'"
            End If
            MySqlCommand.CommandType = CommandType.Text
            Dim myReader As SqlClient.SqlDataReader = MySqlCommand.ExecuteReader
            If myReader.HasRows = False Then
                Return "Please check your credentials again"
            Else
                myReader.Read()
                If ForAdminPanel = True Then
                    ModUser = New MyModUser(myReader.GetValue(1), myReader.GetValue(2), email, password)
                Else
                    CurrentUser = New MyUser(myReader.GetValue(1), myReader.GetValue(2), email, password)
                End If
                myReader.Close()
                Return "True"
            End If
        Catch ex As Exception
            Return Err.Description
        Finally
            ConSQL.Close()
        End Try


    End Function

    Friend Function RegisterNewVisitor(ByVal firstName As String, ByVal lastName As String, ByVal email As String, ByVal password As String)
        Try
            'Validations
            If Trim(firstName) = "" Then
                Return "Please fill in your first name"
            End If

            If Trim(lastName) = "" Then
                Return "Please fill in your last name"
            End If

            If Trim(email) = "" Then
                Return "Please fill in your email"
            End If

            If Trim(password) = "" Then
                Return "Please fill in your password"
            End If

            If EmailAddressChecker(email) = False Then
                Return "Please fill in a valid email address"
            End If

            'Check for SQL Injection
            firstName = chkTxT(firstName)
            lastName = chkTxT(lastName)
            email = chkTxT(email)
            password = chkTxT(password)

            Dim MyAdapter As New SqlDataAdapter
            Dim MySqlCommand As New SqlCommand

            'Check if email has been registered before
            Try
                If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
                MySqlCommand.Connection = ConSQL
                MySqlCommand.CommandText = "select c_id from clients where c_emailAddress = '" & email & "'"
                MySqlCommand.CommandType = CommandType.Text
                Dim myReader As SqlClient.SqlDataReader = MySqlCommand.ExecuteReader
                If myReader.HasRows = True Then
                    Return "This email has already been registered"
                End If
            Catch ex As Exception
                Return Err.Description
            Finally
                ConSQL.Close()
            End Try




            'Continue with registration
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()

            MySqlCommand.Connection = ConSQL
            MySqlCommand.CommandText = "Insert into Clients (c_firstName, c_lastName, c_emailAddress, c_password) VALUES (@c_firstName, @c_lastName, @c_emailAddress, @c_password)"
            MySqlCommand.CommandType = CommandType.Text

            MySqlCommand.Parameters.AddWithValue("@c_firstName", firstName)
            MySqlCommand.Parameters.AddWithValue("@c_lastName", lastName)
            MySqlCommand.Parameters.AddWithValue("@c_emailAddress", email)
            MySqlCommand.Parameters.AddWithValue("@c_password", password)

            MySqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            Return Err.Description
        Finally
            ConSQL.Close()
        End Try

        Return "True"
    End Function

    Function EmailAddressChecker(ByVal emailAddress As String) As Boolean
        Dim regExPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
        If Regex.IsMatch(emailAddress, regExPattern) Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
