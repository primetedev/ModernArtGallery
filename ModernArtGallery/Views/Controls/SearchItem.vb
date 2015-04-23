Public Class SearchItem

    Public Sub New(ByRef imageRef As Image, ByVal desc As String, ByVal artist As String, ByVal price As Double)
        InitializeComponent()
        PictureBox1.Image = imageRef
        lblDesc.Text = desc
        lblArtist.Text = artist
        lblPrice.Text = Format(price, numFormat) & "€"

    End Sub

End Class
