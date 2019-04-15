Public Class AddOnsDb

    Private _Addonsid As Integer = 0
    Public Property AddonsID As Integer
        Set(value As Integer)
            _Addonsid = value
        End Set
        Get
            Return _Addonsid
        End Get
    End Property

    Private _rentid As Integer = 0
    Public Property RentID As Integer
        Set(value As Integer)
            _rentid = value
        End Set
        Get
            Return _rentid
        End Get
    End Property

    Private _name As String = ""
    Public Property Name
        Set(value)
            _name = value
        End Set
        Get
            Return _name
        End Get
    End Property
    Private _qty As Integer = 0
    Public Property Qty As Integer
        Set(value As Integer)
            _qty = value
        End Set
        Get
            Return _qty
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
    Private _type As String = "Free"
    Public Property Type As String
        Set(value As String)
            _type = value
        End Set
        Get
            Return _type
        End Get
    End Property
End Class
