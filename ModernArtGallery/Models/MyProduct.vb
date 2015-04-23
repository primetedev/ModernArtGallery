Public Class MyProduct

    Dim m_id As String
    Dim m_desc As String
    Dim m_price As Double
    Dim m_artist As String
    Dim m_details As String
    Dim m_discount As Double
    Dim m_dateCreated As Date
    Dim m_category As String

    Friend Sub New(ByVal id As String, ByVal desc As String, ByVal price As Double, ByVal artist As String, ByVal details As String, ByVal discount As Double, ByVal dtCreated As Date, ByVal category As String)
        m_id = id
        m_desc = desc
        m_price = Format(price, numFormat)
        m_artist = artist
        m_details = details
        m_discount = discount
        m_dateCreated = dtCreated
        m_category = category
    End Sub

    Friend Property id As String
        Get
            Return m_id
        End Get
        Set(ByVal value As String)
            m_id = value
        End Set
    End Property

    Friend Property desc As String
        Get
            Return m_desc
        End Get
        Set(ByVal value As String)
            m_desc = value
        End Set
    End Property

    Friend Property price As Double
        Get
            Return m_price
        End Get
        Set(ByVal value As Double)
            m_price = value
        End Set
    End Property

    Friend Property artist As String
        Get
            Return m_artist
        End Get
        Set(ByVal value As String)
            m_artist = value
        End Set
    End Property

    Friend Property details As String
        Get
            Return m_details
        End Get
        Set(ByVal value As String)
            m_details = value
        End Set
    End Property

    Friend Property discount As Double
        Get
            Return m_discount
        End Get
        Set(ByVal value As Double)
            m_discount = value
        End Set
    End Property

    Friend Property dateCreated As Date
        Get
            Return m_dateCreated
        End Get
        Set(ByVal value As Date)
            m_dateCreated = value
        End Set
    End Property

    Friend Property category As String
        Get
            Return m_category
        End Get
        Set(ByVal value As String)
            m_category = value
        End Set
    End Property

End Class
