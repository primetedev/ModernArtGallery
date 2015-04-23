Public Class MyModUser : Inherits MyUser

    Dim m_isModerator As String

    Public Sub New(ByVal fname As String, ByVal lname As String, ByVal email As String, ByVal pass As String)
        MyBase.New(fname, lname, email, pass)
    End Sub

    Public Property isModerator As Boolean
        Get
            Return m_isModerator
        End Get
        Set(ByVal value As Boolean)
            m_isModerator = value
        End Set
    End Property


End Class
