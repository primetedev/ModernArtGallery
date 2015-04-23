Imports System.Data.SqlClient

Module ProductLibrary

    'This function returns a 'MyProduct' object which is filled with all
    'the information concerning a specific product we look for, by passing
    'the id of the product we are looking for as a parameter
    Friend Function GetProductInfo(ByVal pId As String) As MyProduct
        SetDBConnection()
        Dim MyAdapter As New SqlDataAdapter
        Dim MySqlCommand As New SqlCommand
        Dim Item As MyProduct

        Try
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            MySqlCommand.Connection = ConSQL
            MySqlCommand.CommandText = "select i_description, a_nickname, i_details, i_price, i_categoryID, i_discount, i_dateCreated, " & _
                "cg_description from items inner join artists on items.i_artistID = artists.a_id inner join Categories on Items.i_categoryid = Categories.cg_id where i_id = '" & pId & "'"
            MySqlCommand.CommandType = CommandType.Text
            Dim myReader As SqlClient.SqlDataReader = MySqlCommand.ExecuteReader
            If myReader.HasRows = True Then
                myReader.Read()
                Item = New MyProduct(pId, IIf(myReader.GetValue(0) Is DBNull.Value, "", myReader.GetValue(0)), IIf(myReader.GetValue(3) Is DBNull.Value, 0, myReader.GetValue(3)), _
                                     IIf(myReader.GetValue(1) Is DBNull.Value, "", myReader.GetValue(1)), IIf(myReader.GetValue(2) Is DBNull.Value, "", myReader.GetValue(2)), _
                                     IIf(myReader.GetValue(5) Is DBNull.Value, 0, myReader.GetValue(5)), IIf(myReader.GetValue(6) Is DBNull.Value, New Date(1999, 1, 1), myReader.GetValue(6)), myReader.GetValue(7))
                myReader.Close()
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            ConSQL.Close()
        End Try

        Return Item
    End Function

    Friend Function UpdateProduct(ByRef product As MyProduct, ByVal title As String, ByVal description As String, ByVal price As Double, ByVal discount As Double)
        Try
            Dim MyAdapter As New SqlDataAdapter
            Dim MySqlCommand As New SqlCommand
            'Continue with registration
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()

            MySqlCommand.Connection = ConSQL
            If product IsNot Nothing Then
                MySqlCommand.CommandText = "update Items set i_description=@i_description, i_artistID=@i_artistID, i_details=@i_details, i_price=@i_price, i_categoryID=@i_categoryID, i_discount=@i_discount where i_id = '" & product.id & "'"
            Else
                MySqlCommand.CommandText = "Insert into Items (i_description, i_artistID, i_details, i_price, i_categoryID, i_discount) VALUES (@i_description, @i_artistID, @i_details, @i_price, @i_categoryID, @i_discount)"
            End If

            MySqlCommand.CommandType = CommandType.Text
            MySqlCommand.Parameters.AddWithValue("@i_description", title)
            MySqlCommand.Parameters.AddWithValue("@i_artistID", 1)
            MySqlCommand.Parameters.AddWithValue("@i_details", description)
            MySqlCommand.Parameters.AddWithValue("@i_price", CDbl(price))
            MySqlCommand.Parameters.AddWithValue("@i_categoryID", 1)
            MySqlCommand.Parameters.AddWithValue("@i_discount", CDbl(discount))

            MySqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(Err.Description)
            Return False
        Finally
            ConSQL.Close()
        End Try
        Return True
    End Function

    Friend Function DeleteProduct(ByRef pid As String)
        Try
            Dim MyAdapter As New SqlDataAdapter
            Dim MySqlCommand As New SqlCommand
            'Continue with registration
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()

            MySqlCommand.Connection = ConSQL
            MySqlCommand.CommandText = "delete from Items where i_id = '" & pid & "'"
            MySqlCommand.CommandType = CommandType.Text
            MySqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(Err.Description)
            Return False
        Finally
            ConSQL.Close()
        End Try
        Return True
    End Function

    Friend Function GetAvgPriceOfCategory(ByVal catName As String) As Double
        Dim MyAdapter As New SqlDataAdapter
        Dim MySqlCommand As New SqlCommand
        Dim CategoryID As Integer = 0

        Try
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            MySqlCommand.Connection = ConSQL
            MySqlCommand.CommandText = "select cg_id from categories where cg_description = '" & catName & "'"
            MySqlCommand.CommandType = CommandType.Text
            Dim myReader As SqlClient.SqlDataReader = MySqlCommand.ExecuteReader
            If myReader.HasRows = True Then
                myReader.Read()
                CategoryID = IIf(myReader.GetValue(0) Is DBNull.Value, 0, myReader.GetValue(0))
                myReader.Close()
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            ConSQL.Close()
        End Try

        If CategoryID = 0 Then Return 0
        Dim avgPrice As Double = 0
        Try
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            MySqlCommand.Connection = ConSQL
            MySqlCommand.CommandText = "select sum(i_price), count(*) from items where i_categoryID = " & CategoryID
            MySqlCommand.CommandType = CommandType.Text
            Dim myReader As SqlClient.SqlDataReader = MySqlCommand.ExecuteReader
            If myReader.HasRows = True Then
                myReader.Read()
                If myReader.GetValue(1) > 0 Then avgPrice = IIf(myReader.GetValue(0) Is DBNull.Value, 0, myReader.GetValue(0)) / IIf(myReader.GetValue(1) Is DBNull.Value, 0, myReader.GetValue(1))
                myReader.Close()
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            ConSQL.Close()
        End Try

        Return avgPrice
    End Function

End Module
