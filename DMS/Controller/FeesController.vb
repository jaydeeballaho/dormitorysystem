Imports MySql.Data.MySqlClient

Public Class FeesController

    Inherits FeesDb

    Public Sub SetFeesDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Fees WHERE rentid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    FeesID = reader(0)
                    RentID = reader(1)
                    Advance = reader(2)
                    Deposit = reader(3)
                    AdvanceAmount = reader(4)
                    DepositAmount = reader(5)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddFees() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Fees (rentid,advance,deposit,advanceamount,depositamount) VALUES (@0,@1,@2,@3,@4);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID, Advance, Deposit, AdvanceAmount, DepositAmount)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditFees() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Fees SET rentid=@0,advance=@1,deposit=@2,advanceamount=@3,depositamount=@4 WHERE Feesid=@5;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID, Advance, Deposit, AdvanceAmount, DepositAmount, FeesID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function DeleteFees() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM Fees WHERE rentid=@0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function
End Class
