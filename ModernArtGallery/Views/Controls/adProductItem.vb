Public Class adProductItem

    Public Sub New(ByRef imageRef As Image, ByVal desc As String, ByVal artist As String, ByVal price As Double, ByVal category As String, ByVal id As String)
        InitializeComponent()
        PictureBox1.Image = imageRef
        lblDesc.Text = desc
        lblDesc.Tag = id
        lblArtist.Text = artist
        lblPrice.Text = Format(price, numFormat) & "€"
        lblCategory.Text = category
    End Sub


    Private Sub lblDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDesc.Click
        If lblDesc.Tag <> "" Then
            Dim tmp As New adProduct
            tmp.Show()
            System.Windows.Forms.Application.DoEvents()
            Me.Visible = False
            tmp.FillInfo(lblDesc.Tag)
        End If
    End Sub


End Class
