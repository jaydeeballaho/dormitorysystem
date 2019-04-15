Imports MySql.Data.MySqlClient

Public Class BillingController
    Inherits BillingDb

    Public Sub SetbillDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM billing WHERE billingid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    BillID = reader(0)
                    RentID = reader(1)
                    BillDate = reader(2)
                    Amount = reader(3)
                    DueDate = reader(4)
                    DueAmount = reader(5)
                    Status = reader(6)
                    Advance = reader(9)
                    Type = reader(10)
                    Def = reader(11)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function Addbill() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO billing (rentid,billingdate,amount,duedate,amountdue,status,advance,type,lastaddons) VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@8);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID, BillDate, Amount, DueDate, DueAmount, Status, Advance, Type, Def)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        End Try
    End Function

    Public Function Editbill() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE billing SET rentid=@0,billingdate=@1,amount=@2,duedate=@3,amountdue=@4,status=@5,lastaddons=@6 WHERE billingid=@7;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, RentID, BillDate, Amount, DueDate, DueAmount, Status, Def, BillID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function DeleteBilling() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM billing WHERE billingid=@0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, BillID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub ViewBilling(gv As DataGridView, lbl As Label, status As String, start As Date, endDate As Date, filter As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT billingid,billingdate,firstname,lastname,roomcode,amount,duedate,amountdue,billing.createdat,advance,billing.status,lastaddons FROM billing inner join rent on " _
                & "billing.rentid=rent.rentid inner join border on rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
                & "where billing.status LIKE '%" & status & "%' and " & filter & " BETWEEN CAST('" & start.ToString("yyyy-MM-dd") & "' AS DATE) " _
                & "AND CAST('" & endDate.ToString("yyyy-MM-dd") & "' AS DATE) ORDER BY " & filter & " DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    With gv
                        Dim dl As String = "Delete"
                        If reader(10) = 1 Then
                            dl = ""
                        End If
                        '  MsgBox(Date.Compare(Date.Parse(reader("billing.createdat")).Date, frmMain.dtServer.Date))
                        ' If Date.Compare(Date.Parse(reader(8)).Date, frmMain.dtServer.Date) <= 0 Then
                        i = i + 1
                        If frmMain.userType = "Administrator" Then
                            If reader("advance") = 1 Then
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                             Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                             "₱ " & Format(reader(7), "n2"), "Advance", dl, "Print Bill", reader("lastaddons"))
                            Else
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                               Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                               "₱ " & Format(reader(7), "n2"), "", dl, "Print Bill", reader("lastaddons"))
                            End If
                        Else
                            If reader("advance") = 1 Then
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                             Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                             "₱ " & Format(reader(7), "n2"), "Advance", "", "Print Bill", reader("lastaddons"))
                            Else
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                               Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                               "₱ " & Format(reader(7), "n2"), "", "", "Print Bill", reader("lastaddons"))
                            End If
                        End If
                        'End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO BILLINGS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub FilterBilling(kw As String, gv As DataGridView, lbl As Label, status As String, start As Date, endDate As Date, filter As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT billingid,billingdate,firstname,lastname,roomcode,amount,duedate,amountdue,billing.createdat,advance,billing.status,lastaddons FROM billing inner join rent on " _
                & "billing.rentid=rent.rentid inner join border on rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
                & "where billing.status LIKE '%" & status & "%' and " & filter & " BETWEEN CAST('" & start.ToString("yyyy-MM-dd") & "' AS DATE) " _
                & "AND CAST('" & endDate.ToString("yyyy-MM-dd") & "' AS DATE) AND (lastname LIKE '" & kw & "%' OR firstname " _
                & "LIKE '" & kw & "%' OR roomcode LIKE '" & kw & "%') ORDER BY " & filter & " DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    With gv
                        Dim dl As String = "Delete"
                        If reader(10) = 1 Then
                            dl = ""
                        End If
                        '  If Date.Compare(Date.Parse(reader("billing.createdat")).Date, frmMain.dtServer.Date) <= 0 Then
                        i = i + 1
                        If frmMain.userType = "Administrator" Then
                            If reader("advance") = 1 Then
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                             Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                             "₱ " & Format(reader(7), "n2"), "Advance", dl, "Print Bill", reader("lastaddons"))
                            Else
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                               Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                               "₱ " & Format(reader(7), "n2"), "", dl, "Print Bill", reader("lastaddons"))
                            End If
                        Else
                            If reader("advance") = 1 Then
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                             Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                             "₱ " & Format(reader(7), "n2"), "Advance", "", "Print Bill", reader("lastaddons"))
                            Else
                                .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), reader(2) + " " + reader(3), reader(4), _
                               Date.Parse(reader(6)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(5), "n2"), _
                               "₱ " & Format(reader(7), "n2"), "", "", "Print Bill", reader("lastaddons"))
                            End If
                        End If
                        'End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO BILLINGS YET"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub GenerateBilling(gv As DataGridView)
        Try
            Dim sql As String
            sql = "SELECT Rent.Rentid,(rent.rate+IFNULL(addedcharge,0)) as monthly, (IFNULL(addedcharge,0)) as def FROM rent inner join border on " _
                & "rent.borderid=border.borderid inner join room on rent.roomid=room.roomid left join" _
                & "(select addons.rentid,coalesce(sum(quantity*charge),0) as addedcharge from addons where type<>'Free' GROUP " _
                & "by addons.rentid)addons on rent.rentid=addons.rentid WHERE rent.status='On' and DATE_ADD(datein, INTERVAL counter " _
                & "MONTH) <= NOW() and rent.rentid NOT IN (Select rentid from billing where MONTH(billingdate)=Month(NOW()) and " _
                & "YEAR(billingdate)=YEAR(NOW()));"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    With gv
                        .Rows.Add(reader(0), reader(1), reader(2))
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Public Sub GenerateRentBilling(gv As DataGridView)
    '    Try
    '        Dim sql As String
    '        sql = "SELECT Rent.Rentid,rent.rate FROM rent inner join border on " _
    '            & "rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
    '            & "WHERE rent.status='On' and DATE_ADD(datein, INTERVAL counter " _
    '            & "MONTH) <= NOW() and rent.rentid NOT IN (Select rentid from billing where MONTH(billingdate)=Month(NOW()) and " _
    '            & "YEAR(billingdate)=YEAR(NOW()) and type = 'rent');"
    '        If IsConnected() = True Then
    '            Dim cmd = New MySqlCommand(sql, getServerConnection)
    '            Dim reader As MySqlDataReader = cmd.ExecuteReader()
    '            gv.Rows.Clear()
    '            While reader.Read()
    '                With gv
    '                    .Rows.Add(reader(0), reader(1))
    '                End With
    '            End While
    '            reader.Close()
    '            gv.ClearSelection()
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Public Sub GenerateAddsBilling(gv As DataGridView)
    '    Try
    '        Dim sql As String
    '        sql = "SELECT addons.addonsid,charge,rent.rentid FROM rent inner join addons on rent.rentid=addons.rentid WHERE rent.status='On' and " _
    '            & "DATE_ADD(dateusing, INTERVAL addons.counter " _
    '            & "MONTH) <= NOW() and rent.rentid NOT IN (Select rentid from billing where MONTH(billingdate)=Month(NOW()) and " _
    '            & "YEAR(billingdate)=YEAR(NOW()) and type = 'adds');"
    '        If IsConnected() = True Then
    '            Dim cmd = New MySqlCommand(sql, getServerConnection)
    '            Dim reader As MySqlDataReader = cmd.ExecuteReader()
    '            gv.Rows.Clear()
    '            While reader.Read()
    '                With gv
    '                    .Rows.Add(reader(0), reader(1), reader(2))
    '                End With
    '            End While
    '            reader.Close()
    '            gv.ClearSelection()
    '        End If
    '    Catch ex As Exception
    '        ' MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Function GetStartDate(filter As String)
        Try
            Dim d As Date = frmMain.dtServer
            Dim sql As String
            If filter = "billingdate" Then
                filter = "createdat"
            End If
            sql = "SELECT " & filter & " FROM billing ORDER BY " & filter & " ASC LIMIT 1;"
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
            sql = "SELECT " & filter & " FROM billing ORDER BY " & filter & " DESC LIMIT 1;"
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

    Public Sub ViewCollection(gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT billingid,billingdate,billing.amount,duedate,amountdue,NOW(),billing.status FROM billing " _
                & "INNER JOIN rent on billing.rentid=rent.rentid WHERE rent.rentid " _
                & "= " & RentID & " and billing.status = 0 ORDER BY billingdate DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    With gv
                        Dim paid As Decimal = 0
                        Dim due As Integer = 0
                        If Date.Compare(Date.Parse(reader(1)).Date, frmMain.dtServer.Date) <= 0 Then
                            i = i + 1
                            If Date.Compare(Date.Parse(reader(3)).Date, Date.Parse(reader(5)).Date) < 0 Then
                                due = 1
                                paid = reader(4)
                            Else
                                due = 0
                                paid = reader(2)
                            End If
                            .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(2), "n2"), _
                                    Date.Parse(reader(3)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(4), "n2"), due, paid, False)
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ViewCollectionForEdit(gv As DataGridView, idc As Integer)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT billing.billingid,billingdate,billing.amount,duedate,amountdue,billing.status,payment.amount,paymentid,paymentdate " _
                & "FROM billing INNER JOIN payment on billing.billingid=payment.billingid inner join collection on payment.collectionid = " _
                & "collection.collectionid WHERE collection.collectionid = " & idc & " and billing.status = 1 ORDER BY billingdate DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    With gv
                        Dim paid As Decimal = 0
                        Dim due As Integer = 0
                        ' If Date.Compare(Date.Parse(reader(1)).Date, frmMain.dtServer.Date) <= 0 Then
                        i = i + 1
                        If Date.Compare(Date.Parse(reader(3)).Date, Date.Parse(reader(8)).Date) < 0 Then
                            due = 1
                            paid = reader(6)
                        Else
                            due = 0
                            paid = reader(6)
                        End If
                        .Rows.Add(reader(0), i, Date.Parse(reader(1)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(2), "n2"), _
                                Date.Parse(reader(3)).ToString("yyyy-MMM-dd"), "₱ " & Format(reader(4), "n2"), due, paid, True, reader(7))
                      '  End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetLastBill(id As Integer) As String
        Try
            Dim dtString = "No Billings Yet"
            Dim sql As String
            sql = "SELECT billingdate FROM billing where rentid = " & id & " order by billingdate DESC LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    dtString = Date.Parse(reader(0)).ToString("yyyy-MMM-dd")
                End While
                reader.Close()
            End If
            Return dtString
        Catch ex As Exception
            Return "No Billings Yet"
        End Try
    End Function

    Public Function GetlastBill(id As Integer, def As Date) As Date
        Try
            Dim d As Date = def
            Dim sql As String
            sql = "SELECT billingdate FROM billing where rentid = " & id & " order by billingid DESC LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    d = reader(0)
                End While
                reader.Close()
            End If
            Return d
        Catch ex As Exception
            Return def
        End Try
    End Function

    Public Function GetAdvanceBillID()
        Try
            Dim id As Integer = 0
            Dim sql As String
            sql = "SELECT billingid FROM billing order by billingid DESC LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    id = reader(0)
                End While
                reader.Close()
            End If
            Return id
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetLastPaidBills(idd As Integer) As Date
        Try
            Dim d As Date = frmMain.dtServer
            Dim sql As String
            sql = "SELECT duedate FROM billing where rentid = " & idd & " ORDER BY billingid DESC LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    d = reader(0)
                End While
                reader.Close()
            End If
            Return d
        Catch ex As Exception
            Return frmMain.dtServer
        End Try
    End Function

    Public Function GetLastPaidAdds(idd As Integer) As Decimal
        Try
            Dim d As Decimal = 0
            Dim sql As String
            sql = "SELECT lastaddons FROM billing where rentid = " & idd & " ORDER BY billingid DESC LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    d = reader(0)
                End While
                reader.Close()
            End If
            Return d
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
