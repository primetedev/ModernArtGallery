Public Class MyUser

    Dim m_FirstName As String
    Dim m_LastName As String
    Dim m_EmailAddress As String
    Dim m_Company As String
    Dim m_Phone As String
    Dim m_Address As String
    Dim m_City As String
    Dim m_PostalCode As String
    Dim m_Country As String
    Dim m_Region As String
    Dim m_Notes As String
    Dim m_AcceptMail As Boolean
    Dim m_PassWord As String


    Public Property firstName As String
        Get
            Return m_FirstName
        End Get
        Set(ByVal value As String)
            m_FirstName = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return m_LastName
        End Get
        Set(ByVal value As String)
            m_LastName = value
        End Set
    End Property

    Public Property EmailAddress As String
        Get
            Return m_EmailAddress
        End Get
        Set(ByVal value As String)
            m_EmailAddress = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return m_Company
        End Get
        Set(ByVal value As String)
            m_Company = value
        End Set
    End Property

    Public Property Phone As String
        Get
            Return m_Phone
        End Get
        Set(ByVal value As String)
            m_Phone = value
        End Set
    End Property

    Public Property Address As String
        Get
            Return m_Address
        End Get
        Set(ByVal value As String)
            m_Address = value
        End Set
    End Property

    Public Property PassWord As String
        Get
            Return m_PassWord
        End Get
        Set(ByVal value As String)
            m_PassWord = value
        End Set
    End Property

    Public Sub New(ByVal fname As String, ByVal lname As String, ByVal email As String, ByVal pass As String)
        firstName = fname
        LastName = lname
        EmailAddress = email
        PassWord = pass
    End Sub









End Class
