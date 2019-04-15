Public Class BorderDb

    Private _borderid As Integer = 0
    Public Property BorderID As Integer
        Set(value As Integer)
            _borderid = value
        End Set
        Get
            Return _borderid
        End Get
    End Property
    Private _fn As String = ""
    Public Property BorderFN
        Set(value)
            _fn = value
        End Set
        Get
            Return _fn
        End Get
    End Property
    Private _ln As String = ""
    Public Property BorderLN As String
        Set(value As String)
            _ln = value
        End Set
        Get
            Return _ln
        End Get
    End Property
    Private _sex As String = "Male"
    Public Property BorderSex As String
        Set(value As String)
            _sex = value
        End Set
        Get
            Return _sex
        End Get
    End Property
    Private _cn As String = ""
    Public Property BorderCN As String
        Set(value As String)
            _cn = value
        End Set
        Get
            Return _cn
        End Get
    End Property
    Private _tag As Integer = 0
    Public Property Tag As Integer
        Set(value As Integer)
            _tag = value
        End Set
        Get
            Return _tag
        End Get
    End Property

End Class
