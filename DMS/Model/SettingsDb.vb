Public Class SettingsDb


    Private _settingsid As Integer = 0
    Public Property SettingsID As Integer
        Set(value As Integer)
            _settingsid = value
        End Set
        Get
            Return _settingsid
        End Get
    End Property
    Private _advance As Integer = 0
    Public Property Advance As Integer
        Set(value As Integer)
            _advance = value
        End Set
        Get
            Return _advance
        End Get
    End Property
    Private _deposit As Integer = 0
    Public Property Deposit As Integer
        Set(value As Integer)
            _deposit = value
        End Set
        Get
            Return _deposit
        End Get
    End Property
    Private _charge As Decimal = 0
    Public Property Charge As Decimal
        Set(value As Decimal)
            _charge = value
        End Set
        Get
            Return _charge
        End Get
    End Property
    Private _penbypercent As Double = 0
    Public Property PenByPercent As Double
        Set(value As Double)
            _penbypercent = value
        End Set
        Get
            Return _penbypercent
        End Get
    End Property
    Private _penbyamount As Decimal = 200
    Public Property PenByAmount As Decimal
        Set(value As Decimal)
            _penbyamount = value
        End Set
        Get
            Return _penbyamount
        End Get
    End Property
    Private _pentype As String = "Amount"
    Public Property Pentype As String
        Set(value As String)
            _pentype = value
        End Set
        Get
            Return _pentype
        End Get
    End Property
    Private _notifbilling As Integer = 10
    Public Property NotifBilling As Integer
        Set(value As Integer)
            _notifbilling = value
        End Set
        Get
            Return _notifbilling
        End Get
    End Property

End Class
