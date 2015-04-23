Public Class adProduct

    Dim tmpItem As MyProduct

    Private Sub txtTitle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitle.TextChanged
        lblBigTitle.Text = txtTitle.Text
    End Sub

#Region "HTML BUTTONS"

    Private Sub btnBold_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBold.Click
        With rtxtDesc
            If .SelectionFont IsNot Nothing Then
                Dim currentFont As System.Drawing.Font = .SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                If .SelectionFont.Bold = True Then
                    newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
                Else
                    newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
                End If
                .SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
            End If
        End With
    End Sub

    Private Sub btnItalics_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnItalics.Click
        With rtxtDesc
            If .SelectionFont IsNot Nothing Then
                Dim currentFont As System.Drawing.Font = .SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                If .SelectionFont.Bold = True Then
                    newFontStyle = currentFont.Style - Drawing.FontStyle.Italic
                Else
                    newFontStyle = currentFont.Style + Drawing.FontStyle.Italic
                End If
                .SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
            End If
        End With
    End Sub

    Private Sub pcbSizes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcbSizes.Click
        cbSize.DroppedDown = Not cbSize.DroppedDown
    End Sub

    Private Sub cbSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSize.SelectedIndexChanged
        With rtxtDesc
            If .SelectionFont IsNot Nothing Then
                Dim currentFont As System.Drawing.Font = .SelectionFont
                Dim newFont As System.Drawing.Font

                newFont = New Font(currentFont.FontFamily, CInt(cbSize.Text), currentFont.Style)
                '.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFont)
                .SelectionFont = newFont 'New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFont)
            End If
        End With
    End Sub

#End Region



    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        Me.Close()
    End Sub


    Private Sub adProduct_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ModUser Is Nothing Then
            Dim t As New login
            t.Show()
            Me.Visible = False
        End If
        cbArtist.Items.AddRange(GetArtists)
        cbCategories.Items.AddRange(GetCategories)
    End Sub

    Friend Sub FillInfo(ByVal idProduct As String)
        SetDBConnection()
        tmpItem = GetProductInfo(idProduct)

        txtTitle.Text = tmpItem.desc
        txtPrice.Text = tmpItem.price
        txtDiscount.Text = tmpItem.discount
        rtxtDesc.Text = tmpItem.details
        cbArtist.Text = tmpItem.artist
        cbCategories.Text = tmpItem.category
        productIMg.Image = New Bitmap(CStr(My.Application.Info.DirectoryPath & "\images\" & idProduct & ".jpg"))
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Trim(txtTitle.Text) = "" Then
            lblError.Text = "Please fill in the title first!"
            lblError.Visible = True
            Exit Sub
        End If

        If IsNumeric(txtPrice.Text) = False Then
            lblError.Text = "Your price should contain only numbers"
            lblError.Visible = True
            Exit Sub
        End If

        If IsNumeric(txtDiscount.Text) = False Then
            lblError.Text = "Your discount should contain only numbers"
            lblError.Visible = True
            Exit Sub
        End If

        If CDbl(txtPrice.Text) < 0 Then
            lblError.Text = "The product price must be greater or equal to zero"
            lblError.Visible = True
        End If

        If CDbl(txtDiscount.Text) < 0 Then
            lblError.Text = "The product discount must be greater or equal to zero"
            lblError.Visible = True
        End If

        lblError.Visible = False

        UpdateProduct(tmpItem, txtTitle.Text, rtxtDesc.Text, txtPrice.Text, txtDiscount.Text)
    End Sub


    Private Sub cbCategories_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategories.SelectedIndexChanged
        lblAverage.Text = "Avg. Category Price : " & Format(GetAvgPriceOfCategory(cbCategories.Text), numFormat) & "€"
    End Sub

    Private Sub btnChooseImg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChooseImg.Click
        OpenFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png"
        OpenFileDialog1.RestoreDirectory = True

        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim imgPath As String = OpenFileDialog1.FileName
            Try
                Dim myFile As New IO.FileInfo(imgPath)
                Dim sizeInBytes As Long = myFile.Length
                If sizeInBytes / 1024 > 2048 Then
                    lblError.Text = "Your file size should be less than 2mb"
                    lblError.Visible = True
                    Exit Sub
                End If
                productIMg.Image = System.Drawing.Bitmap.FromFile(imgPath)
                lblError.Visible = False
            Catch
                lblError.Text = "Please choose a valid file for upload"
                lblError.Visible = True
            End Try
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim tmp As New adProductList
        tmp.Show()
        Me.Visible = False
    End Sub

    Private Sub btnProducts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProducts.Click
        btnCancel_Click(Nothing, Nothing)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ModUser Is Nothing Then
            Dim t As New login
            t.Show()
            t.BringToFront()
            System.Windows.Forms.Application.DoEvents()
            Me.Visible = False
            Timer1.Enabled = False
        End If
    End Sub
End Class