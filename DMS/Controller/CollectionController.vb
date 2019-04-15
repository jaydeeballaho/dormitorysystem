Imports MySql.Data.MySqlClient

Public Class CollectionController
    Inherits PaymentDb

    Public Sub SetCollectionID()
        Try
            Dim sql As String
            sql = "SELECT LAST_INSERT_ID();"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                CollectionID = Integer.Parse(cmd.ExecuteScalar)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetCollectionDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Collection WHERE Collectionid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    CollectionID = reader(0)
                    RentID = reader(1)
                    PayDate = reader(2)
                    CollectedBy = reader(3)
                    Cash = reader(4)
                    Change = reader(5)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetPaymentDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM payment WHERE paymentid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    PayID = reader(0)
                    CollectionID = reader(1)
                    BillID = reader(2)
                    Amount = reader(3)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddCollection() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO collection (rentid,paymentdate,collectedby,cash,changed) VALUES (@0,@1,@2,@3,@4);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID, PayDate, CollectedBy, Cash, Change)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function AddPayment() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO payment (collectionid,billingid,amount) VALUES (@0,@1,@2);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, CollectionID, BillID, Amount)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditCollection() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE collection rentid=@0,paymentdate=@1,collectedby=@2,cash=@3,changed=@4 WHERE collectionid=@5;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID, PayDate, CollectedBy, Cash, Change, CollectionID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function DeletePayment() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM payment WHERE paymentid=@0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, PayID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub ViewCollection(gv As DataGridView, lbl As Label, start As Date, endDate As Date, filter As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT collection.collectionid,firstname,lastname,collectedby,paymentdate,IFNULL(total,0) as paid FROM collection " _
                & "INNER JOIN rent on collection.rentid=rent.rentid INNER JOIN border on rent.borderid=border.borderid " _
                & "inner join room on rent.roomid=room.roomid LEFT JOIN(select payment.collectionid,coalesce(sum(amount),0) as total " _
                & "from payment GROUP by payment.collectionid)payment on collection.collectionid=payment.collectionid " _
                & "WHERE " & filter & " BETWEEN CAST('" & start.ToString("yyyy-MM-dd") & "' AS DATE) " _
                & "AND CAST('" & endDate.ToString("yyyy-MM-dd") & "' AS DATE) ORDER BY " & filter & " DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                Dim d As Decimal = 0
                While reader.Read()
                    With gv
                        i = i + 1
                        .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), _
                            Date.Parse(reader(4)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), "Edit")
                        d = d + reader("paid")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                    gv.Rows.Add("", "", "", "", "T O T A L", "₱ " & Format(d, "n2"), "")
                Else
                    lbl.Text = "NO COLLECTIONS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub FilterCollection(kw As String, gv As DataGridView, lbl As Label, start As Date, endDate As Date, filter As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT collection.collectionid,firstname,lastname,collectedby,paymentdate,IFNULL(total,0) as paid FROM collection " _
                & "INNER JOIN rent on collection.rentid=rent.rentid INNER JOIN border on rent.borderid=border.borderid " _
                & "inner join room on rent.roomid=room.roomid LEFT JOIN(select payment.collectionid,coalesce(sum(amount),0) as total " _
                & "from payment GROUP by payment.collectionid)payment on collection.collectionid=payment.collectionid " _
                & "WHERE " & filter & " BETWEEN CAST('" & start.ToString("yyyy-MM-dd") & "' AS DATE) " _
                & "AND CAST('" & endDate.ToString("yyyy-MM-dd") & "' AS DATE) AND (lastname LIKE '" & kw & "%' OR firstname " _
                & "LIKE '" & kw & "%') ORDER BY " & filter & " DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                Dim d As Decimal = 0
                While reader.Read()
                    With gv
                        i = i + 1
                        .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(3), _
                            Date.Parse(reader(4)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), "Edit")
                        d = d + reader("paid")
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                    gv.Rows.Add("", "", "", "", "T O T A L", "₱ " & Format(d, "n2"), "")
                Else
                    lbl.Text = "NO COLLECTIONS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetStartDate(filter As String)
        Try
            Dim d As Date = frmMain.dtServer
            Dim sql As String
            sql = "SELECT " & filter & " FROM collection ORDER BY " & filter & " ASC LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    d = reader(0)
                End While
                reader.Close()
            End If
            Return Date.Parse(frmMain.dtServer.Year.ToString() + "-" + "01" + "-" + "01")
        Catch ex As Exception
            Return Date.Parse(frmMain.dtServer.Year.ToString() + "-" + "01" + "-" + "01")
        End Try
    End Function
    Public Function GetEndDate(filter As String)
        Try
            Dim d As Date = frmMain.dtServer
            Dim sql As String
            sql = "SELECT " & filter & " FROM collection ORDER BY " & filter & " DESC LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    d = reader(0)
                End While
                reader.Close()
            End If
            Return Date.Parse(frmMain.dtServer.Year.ToString() + "-" + "12" + "-" + "31")
        Catch ex As Exception
            Return Date.Parse(frmMain.dtServer.Year.ToString() + "-" + "12" + "-" + "31")
        End Try
    End Function

End Class
