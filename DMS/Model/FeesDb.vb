Public Class FeesDb

    Private _feesid As Integer = 0
    Public Property FeesID As Integer
        Set(value As Integer)
            _feesid = value
        End Set
        Get
            Return _feesid
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

    Private _advanceamount As Decimal = 0
    Public Property AdvanceAmount As Decimal
        Set(value As Decimal)
            _advanceamount = value
        End Set
        Get
            Return _advanceamount
        End Get
    End Property

    Private _depositamount As Decimal = 0
    Public Property DepositAmount As Decimal
        Set(value As Decimal)
            _depositamount = value
        End Set
        Get
            Return _depositamount
        End Get
    End Property

End Class
