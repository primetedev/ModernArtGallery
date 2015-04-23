Imports System.Data.SqlClient
Module MainLibrary
    'Testing the GitHub functionality.
    'Check how sync works for GitHub
    'This is a change done from GitHub edit panel
    Dim dbConnectionStr As String = "Data Source = dorapc;Initial Catalog =MAC;User Id=sa;Password=prnewk3;"
    Friend ConSQL As SqlConnection
    Friend CurrentUser As MyUser
    Friend ModUser As MyModUser
    Friend numFormat As String = "#,##0" '"#,##0.00"


    'Create an SQL Connection with the database
    Friend Function SetDBConnection()
        Try
            If ConSQL Is Nothing Then
                ConSQL = New SqlConnection
                ConSQL.ConnectionString = dbConnectionStr
                ConSQL.Open()
                ConSQL.Close()
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    'Prevent SQL Injection
    Friend Function chkTxT(ByVal value As String)
        value = IIf(InStr(value, "'") > 0, Replace(value, "'", ""), value)
        value = IIf(InStr(value, ";") > 0, Replace(value, ";", ""), value)
        value = IIf(InStr(value, "<") > 0, Replace(value, "<", ""), value)
        value = IIf(InStr(value, ">") > 0, Replace(value, ">", ""), value)
        value = IIf(InStr(LCase(value), "delete") > 0, Replace(LCase(value), "delete", ""), value)
        value = IIf(InStr(LCase(value), "insert") > 0, Replace(LCase(value), "insert", ""), value)
        value = IIf(InStr(LCase(value), "truncate") > 0, Replace(LCase(value), "truncate", ""), value)
        value = IIf(InStr(LCase(value), "exec") > 0, Replace(LCase(value), "exec", ""), value)
        value = IIf(InStr(LCase(value), "xp_") > 0, Replace(LCase(value), "xp_", ""), value)
        value = IIf(InStr(LCase(value), "join") > 0, Replace(LCase(value), "join", ""), value)
        value = IIf(InStr(LCase(value), "union") > 0, Replace(LCase(value), "union", ""), value)
        value = IIf(InStr(LCase(value), "update") > 0, Replace(LCase(value), "update", ""), value)
        value = IIf(InStr(LCase(value), "char(") > 0, Replace(LCase(value), "char(", ""), value)
        value = IIf(InStr(LCase(value), "ascii(") > 0, Replace(LCase(value), "ascii(", ""), value)
        value = IIf(InStr(LCase(value), "cast(") > 0, Replace(LCase(value), "cast(", ""), value)
        value = IIf(InStr(value, "--") > 0, Replace(value, "--", ""), value)
        value = Trim(value)
        Return value

    End Function

    Friend Function GetCategories() As Array
        Dim myAList As New ArrayList
        Try
            Dim MySqlCommand As New SqlCommand
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            MySqlCommand.Connection = ConSQL
            MySqlCommand.CommandText = "select cg_description from categories"
            MySqlCommand.CommandType = CommandType.Text
            Dim myReader As SqlClient.SqlDataReader = MySqlCommand.ExecuteReader
            If myReader.HasRows = True Then
                Do While myReader.Read()
                    myAList.Add(myReader.GetValue(0))
                Loop
                myReader.Close()
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            ConSQL.Close()
        End Try
        Return myAList.ToArray
    End Function

    Friend Function GetArtists() As Array
        Dim myAList As New ArrayList
        Try
            Dim MySqlCommand As New SqlCommand
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            MySqlCommand.Connection = ConSQL
            MySqlCommand.CommandText = "select a_nickname from artists"
            MySqlCommand.CommandType = CommandType.Text
            Dim myReader As SqlClient.SqlDataReader = MySqlCommand.ExecuteReader
            If myReader.HasRows = True Then
                Do While myReader.Read()
                    myAList.Add(myReader.GetValue(0))
                Loop
                myReader.Close()
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            ConSQL.Close()
        End Try
        Return myAList.ToArray
    End Function

End Module
