Imports MySql.Data.MySqlClient

Public Class BillingDb

    Private _billid As Integer = 0
    Public Property BillID As Integer
        Set(value As Integer)
            _billid = value
        End Set
        Get
            Return _billid
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

    Private _billdate As Date
    Public Property BillDate As Date
        Set(value As Date)
            _billdate = value
        End Set
        Get
            Return _billdate
        End Get
    End Property

    Private _duedate As Date
    Public Property DueDate As Date
        Set(value As Date)
            _duedate = value
        End Set
        Get
            Return _duedate
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

    Private _def As Decimal = 0
    Public Property Def As Decimal
        Set(value As Decimal)
            _def = value
        End Set
        Get
            Return _def
        End Get
    End Property

    Private _dueamount As Decimal = 0
    Public Property DueAmount As Decimal
        Set(value As Decimal)
            _dueamount = value
        End Set
        Get
            Return _dueamount
        End Get
    End Property

    Private _status As Integer = 0
    Public Property Status As Integer
        Set(value As Integer)
            _status = value
        End Set
        Get
            Return _status
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

    Private _type As String = "rent"
    Public Property Type As String
        Set(value As String)
            _type = value
        End Set
        Get
            Return _type
        End Get
    End Property
End Class
