Public Class GuardianDb

    Private _Guardianid As Integer = 0
    Public Property GuardianID As Integer
        Set(value As Integer)
            _Guardianid = value
        End Set
        Get
            Return _Guardianid
        End Get
    End Property

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
    Public Property GuardianFN
        Set(value)
            _fn = value
        End Set
        Get
            Return _fn
        End Get
    End Property
    Private _ln As String = ""
    Public Property GuardianLN As String
        Set(value As String)
            _ln = value
        End Set
        Get
            Return _ln
        End Get
    End Property
    Private _address As String = ""
    Public Property GuardianAddress As String
        Set(value As String)
            _address = value
        End Set
        Get
            Return _address
        End Get
    End Property
    Private _cn As String = ""
    Public Property GuardianCN As String
        Set(value As String)
            _cn = value
        End Set
        Get
            Return _cn
        End Get
    End Property

End Class
