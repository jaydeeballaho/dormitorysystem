Public Class AccountDb

    Private _accountid As Integer = 0
    Public Property AccountID As Integer
        Set(value As Integer)
            _accountid = value
        End Set
        Get
            Return _accountid
        End Get
    End Property
    Private _firstname As String = ""
    Public Property AccountFirstName As String
        Set(value As String)
            _firstname = value
        End Set
        Get
            Return _firstname
        End Get
    End Property
    Private _lastname As String = ""
    Public Property AccountLastName As String
        Set(value As String)
            _lastname = value
        End Set
        Get
            Return _lastname
        End Get
    End Property
    Private _username As String = "admindorm"
    Public Property AccountUserName As String
        Set(value As String)
            _username = value
        End Set
        Get
            Return _username
        End Get
    End Property
    Private _password As String = "123456"
    Public Property AccountPassword As String
        Set(value As String)
            _password = value
        End Set
        Get
            Return _password
        End Get
    End Property
    Private _role As String = "Administrator"
    Public Property AccountRole As String
        Set(value As String)
            _role = value
        End Set
        Get
            Return _role
        End Get
    End Property
    Private _status As Integer = 0
    Public Property AccountStatus As Integer
        Set(value As Integer)
            _status = value
        End Set
        Get
            Return _status
        End Get
    End Property
End Class
