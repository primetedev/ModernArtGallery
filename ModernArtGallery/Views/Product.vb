Imports System.Data.SqlClient
Public Class Product

    Private Sub Product_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tmpItem As MyProduct = GetProductInfo(11)
        lblDescription.Text = tmpItem.desc
        lblArtist.Text = "Arist: " & tmpItem.artist
        lblPrice.Text = Format(tmpItem.price - (tmpItem.price * tmpItem.discount / 100), numFormat) & "€"
        lblDetails.Text = tmpItem.details
        If tmpItem.discount > 0 Then
            lblDiscount.Visible = True
            lblDiscount.Text = "Discount: " & tmpItem.discount & "%"
        Else
            lblDiscount.Visible = False
        End If

        If Year(tmpItem.dateCreated) < 2000 Then
            lblDate.Visible = False
        Else
            lblDate.Text = "Date created: " & tmpItem.dateCreated
            lblDate.Visible = True
        End If
    End Sub

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        End
    End Sub

    
End Class