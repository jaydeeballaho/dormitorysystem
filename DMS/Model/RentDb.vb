Public Class RentDb

    Private _Rentid As Integer = 0
    Public Property RentID As Integer
        Set(value As Integer)
            _Rentid = value
        End Set
        Get
            Return _Rentid
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

    Private _roomid As Integer = 0
    Public Property RoomID As Integer
        Set(value As Integer)
            _roomid = value
        End Set
        Get
            Return _roomid
        End Get
    End Property

    Private _whole As Integer = 0
    Public Property Whole As Integer
        Set(value As Integer)
            _whole = value
        End Set
        Get
            Return _whole
        End Get
    End Property

    Private _rate As Decimal = 0
    Public Property Rate As Decimal
        Set(value As Decimal)
            _rate = value
        End Set
        Get
            Return _rate
        End Get
    End Property
    Private _datein As Date
    Public Property DateIn As Date
        Set(value As Date)
            _datein = value
        End Set
        Get
            Return _datein
        End Get
    End Property

    Private _dateout As Date
    Public Property DateOut As Date
        Set(value As Date)
            _dateout = value
        End Set
        Get
            Return _dateout
        End Get
    End Property
    
    Private _status As String = "On"
    Public Property Status As String
        Set(value As String)
            _status = value
        End Set
        Get
            Return _status
        End Get
    End Property

    Private _counter As Integer = 1
    Public Property Counter As Integer
        Set(value As Integer)
            _counter = value
        End Set
        Get
            Return _counter
        End Get
    End Property

End Class
