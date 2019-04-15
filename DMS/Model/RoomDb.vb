Public Class RoomDb

    Private _roomid As Integer = 0
    Public Property RoomID As Integer
        Set(value As Integer)
            _roomid = value
        End Set
        Get
            Return _roomid
        End Get
    End Property
    Private _roomcode As String = "0000"
    Public Property RoomCode As String
        Set(value As String)
            _roomcode = value
        End Set
        Get
            Return _roomcode
        End Get
    End Property
    Private _category As String = "Mix"
    Public Property RoomCategory As String
        Set(value As String)
            _category = value
        End Set
        Get
            Return _category
        End Get
    End Property
    Private _roomoccupants As Integer = 1
    Public Property RoomOccupants As Integer
        Set(value As Integer)
            _roomoccupants = value
        End Set
        Get
            Return _roomoccupants
        End Get
    End Property
    Private _perbed As Decimal = 0
    Public Property PerBed As Decimal
        Set(value As Decimal)
            _perbed = value
        End Set
        Get
            Return _perbed
        End Get
    End Property
    Private _perroom As Decimal = 0
    Public Property PerRoom As Decimal
        Set(value As Decimal)
            _perroom = value
        End Set
        Get
            Return _perroom
        End Get
    End Property
    Private _roomdescription As String = ""
    Public Property RoomDescription As String
        Set(value As String)
            _roomdescription = value
        End Set
        Get
            Return _roomdescription
        End Get
    End Property
    Private _roomstatus As String = "Available"
    Public Property RoomStatus As String
        Set(value As String)
            _roomstatus = value
        End Set
        Get
            Return _roomstatus
        End Get
    End Property
End Class
