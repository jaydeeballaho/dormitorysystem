Public Class PaymentDb

    Private _collectionid As Integer = 0
    Public Property CollectionID As Integer
        Set(value As Integer)
            _collectionid = value
        End Set
        Get
            Return _collectionid
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

    Private _paydate As Date
    Public Property PayDate As Date
        Set(value As Date)
            _paydate = value
        End Set
        Get
            Return _paydate
        End Get
    End Property

    Private _collectedby As String = "Administrator"
    Public Property CollectedBy As String
        Set(value As String)
            _collectedby = value
        End Set
        Get
            Return _collectedby
        End Get
    End Property

    Private _cash As Decimal = 0
    Public Property Cash As Decimal
        Set(value As Decimal)
            _cash = value
        End Set
        Get
            Return _cash
        End Get
    End Property

    Private _change As Decimal = 0
    Public Property Change As Decimal
        Set(value As Decimal)
            _change = value
        End Set
        Get
            Return _change
        End Get
    End Property

    Private _billid As Integer = 0
    Public Property BillID As Integer
        Set(value As Integer)
            _billid = value
        End Set
        Get
            Return _billid
        End Get
    End Property

    Private _payid As Integer = 0
    Public Property PayID As Integer
        Set(value As Integer)
            _payid = value
        End Set
        Get
            Return _payid
        End Get
    End Property

    Private _amount As Decimal = 0
    Public Property Amount As Decimal
        Set(value As Decimal)
            _amount = value
        End Set
        Get
            Return _amount
        End Get
    End Property
End Class
