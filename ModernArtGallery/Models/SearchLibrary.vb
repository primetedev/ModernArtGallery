Imports System.Data.SqlClient

Module SearchLibrary

    Friend Function GetProductsByCategory(ByVal CatID As String, ByVal OrderBy As String) As DataSet

        Dim MyAdapter As New SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            Dim sSql As String = "select i_id, i_description, a_nickName, i_price,i_dateCreated, cg_description from items inner join artists on i_artistID = a_id inner join categories on items.i_categoryID = Categories.cg_id " & IIf(CatID <> "", " where i_categoryID = '" & CatID & "' ", "") & OrderBy
            MyAdapter.SelectCommand = New SqlClient.SqlCommand(sSql, ConSQL)
            MyAdapter.Fill(ds, "Eidh")
            ConSQL.Close()
            Return ds
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            If ConSQL.State = ConnectionState.Open Then ConSQL.Close()
        End Try

        Return ds
    End Function

    Friend Function GetProductsBySearch(ByVal val As String, ByVal OrderBy As String) As DataSet
        val = chkTxT(val)
        Dim MyAdapter As New SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Try
            If ConSQL.State = ConnectionState.Closed Then ConSQL.Open()
            Dim sSql As String = "select i_id, i_description, a_nickName, i_price,i_dateCreated, cg_description from items inner join artists on i_artistID = a_id  inner join categories on items.i_categoryID = Categories.cg_id where i_description like '%" & val & "%' or i_details like '%" & val & "%' or a_nickname like '%" & val & "%'" & OrderBy
            MyAdapter.SelectCommand = New SqlClient.SqlCommand(sSql, ConSQL)
            MyAdapter.Fill(ds, "Eidh")
            ConSQL.Close()
            Return ds
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            If ConSQL.State = ConnectionState.Open Then ConSQL.Close()
        End Try

        Return ds
    End Function

End Module
