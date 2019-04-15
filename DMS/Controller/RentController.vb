Imports MySql.Data.MySqlClient

Public Class RentController
    Inherits RentDb

    Public Sub SetRentID()
        Try
            Dim sql As String
            sql = "SELECT LAST_INSERT_ID();"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                RentID = Integer.Parse(cmd.ExecuteScalar)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetRentDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Rent WHERE Rentid = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    RentID = reader(0)
                    BorderID = reader(1)
                    RoomID = reader(2)
                    Whole = reader(3)
                    Rate = reader(4)
                    DateIn = reader(5)
                    DateOut = reader(6)
                    Status = reader(7)
                    Counter = reader(8)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddRent() As Boolean
        Try
            Dim bool As Boolean = False
            Counter = 1
            Dim sql As String = "INSERT INTO Rent (borderid,roomid,whole,rate,datein,dateout,status,counter) VALUES (@0,@1,@2,@3,@4,@5,@6,@7);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, BorderID, RoomID, Whole, Rate, DateIn, DateOut, Status, Counter)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditRent() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Rent SET borderid=@0,roomid=@1,rate=@2,datein=@3,dateout=@4,status=@5,whole=@6 WHERE Rentid=@7;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, BorderID, RoomID, Rate, DateIn, DateOut, Status, Whole, RentID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditRentCounter() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Rent SET counter=@0 WHERE Rentid=@1;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, Counter, RentID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub FilterRental(kw As String, gv As DataGridView, lbl As Label, status As String, start As Date, endDate As Date, filter As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            Dim s = ""
            If status = "All" Then
                s = ""
            ElseIf status = "Closed/Void" Then
                s = "Off"
            Else
                s = "On"
            End If
            sql = "select border.borderid,Rent.Rentid,firstname,lastname,roomcode,whole,(rent.rate+IFNULL(addedcharge,0)) as monthly," _
                & "datein,dateout,Rent.status,maxoccupants,now() from rent inner join border on rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
                & "left join(select addons.rentid,coalesce(sum(quantity*charge),0) as addedcharge from addons where " _
                & "type<>'Free' GROUP by addons.rentid)addons on rent.rentid=addons.rentid WHERE rent.status LIKE '%" & s & "%' and " & filter & " BETWEEN CAST('" & start.ToString("yyyy-MM-dd") & "' AS DATE) " _
                & "AND CAST('" & endDate.ToString("yyyy-MM-dd") & "' AS DATE) AND (firstname LIKE '" & kw & "%' or lastname " _
                & "LIKE '" & kw & "%' or roomcode LIKE '" & kw & "%') ORDER BY " & filter & " DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        Dim spc As String
                        Dim stat As String
                        Dim action As String
                        If reader(5) = reader(10) Then
                            spc = "Whole Room"
                        Else
                            spc = "Space Only"
                        End If
                        If status = "All" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")).Date, Date.Parse(reader("now()")).Date) = 0 Then
                                    stat = "Out Today"
                                ElseIf Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) < 0 Then
                                    stat = "Over Due"
                                ElseIf Date.Compare(Date.Parse(reader("datein")).Date, Date.Parse(reader("now()")).Date) > 0 Then
                                    stat = "Pending"
                                Else
                                    stat = "On-going"
                                End If
                            Else
                                stat = "Closed/Void"
                                action = "View Details"
                            End If
                            .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                        "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                        Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                        ElseIf status = "Closed/Void" Then
                            If reader(9) = "Off" Then
                                stat = "Closed/Void"
                                action = "View Details"
                                .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                            End If
                        ElseIf status = "Out Today" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")).Date, Date.Parse(reader("now()")).Date) = 0 Then
                                    stat = "Out Today"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        ElseIf status = "Over Due" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) < 0 Then
                                    stat = "Over Due"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        ElseIf status = "On-going" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) > 0 Then
                                    stat = "On-going"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO RECORD FOR RENTAL"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ViewFilterRental(gv As DataGridView, lbl As Label, status As String, start As Date, endDate As Date, filter As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            Dim s = ""
            If status = "All" Then
                s = ""
            ElseIf status = "Closed/Void" Then
                s = "Off"
            Else
                s = "On"
            End If
            sql = "select border.borderid,Rent.Rentid,firstname,lastname,roomcode,whole,(rent.rate+IFNULL(addedcharge,0)) as monthly," _
                & "datein,dateout,Rent.status,maxoccupants,now() from rent inner join border on rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
                & "left join(select addons.rentid,coalesce(sum(quantity*charge),0) as addedcharge from addons where " _
                & "type<>'Free' GROUP by addons.rentid)addons on rent.rentid=addons.rentid WHERE rent.status LIKE '%" & s & "%' and " & filter & " BETWEEN CAST('" & start.ToString("yyyy-MM-dd") & "' AS DATE) " _
                & "AND CAST('" & endDate.ToString("yyyy-MM-dd") & "' AS DATE) ORDER BY " & filter & " DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        Dim spc As String
                        Dim stat As String
                        Dim action As String
                        If reader(5) = reader(10) Then
                            spc = "Whole Room"
                        Else
                            spc = "Space Only"
                        End If
                        If status = "All" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")).Date, Date.Parse(reader("now()")).Date) = 0 Then
                                    stat = "Out Today"
                                ElseIf Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) < 0 Then
                                    stat = "Over Due"
                                ElseIf Date.Compare(Date.Parse(reader("datein")).Date, Date.Parse(reader("now()")).Date) > 0 Then
                                    stat = "Pending"
                                Else
                                    stat = "On-going"
                                End If
                            Else
                                stat = "Closed/Void"
                                action = "View Details"
                            End If
                            .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                        ElseIf status = "Closed/Void" Then
                            If reader(9) = "Off" Then
                                stat = "Closed/Void"
                                action = "View Details"
                                .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                            End If
                        ElseIf status = "Out Today" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")).Date, Date.Parse(reader("now()")).Date) = 0 Then
                                    stat = "Out Today"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        ElseIf status = "Over Due" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                               If Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) < 0 Then
                                    stat = "Over Due"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        ElseIf status = "On-going" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) > 0 Then
                                    stat = "On-going"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO RECORD FOR RENTAL"
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
            sql = "SELECT " & filter & " FROM rent ORDER BY " & filter & " ASC LIMIT 1;"
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
            sql = "SELECT " & filter & " FROM rent ORDER BY " & filter & " DESC LIMIT 1;"
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

    Public Sub SearchRental(kw As String, gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "select Rent.Rentid,border.borderid,firstname,lastname,roomcode,whole,(rent.rate+IFNULL(addedcharge,0)) as monthly," _
                & "datein,dateout,Rent.status,maxoccupants,now(),IFNULL(addedcharge,0) as def from rent inner join border on rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
                & "left join(select addons.rentid,coalesce(sum(quantity*charge),0) as addedcharge from addons where " _
                & "type<>'Free' GROUP by addons.rentid)addons on rent.rentid=addons.rentid WHERE rent.status = 'On' AND (firstname LIKE '" & kw & "%' or lastname " _
                & "LIKE '" & kw & "%' or roomcode LIKE '" & kw & "%') ORDER BY datein DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        Dim spc As String
                        Dim stat As String
                        Dim action As String
                        If reader(5) = reader(10) Then
                            spc = "Whole Room"
                        Else
                            spc = "Space Only"
                        End If

                        action = "Select"
                        If Date.Compare(Date.Parse(reader("dateout")).Date, Date.Parse(reader("now()")).Date) = 0 Then
                            stat = "Out Today"
                        ElseIf Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) < 0 Then
                            stat = "Over Due"
                        ElseIf Date.Compare(Date.Parse(reader("datein")), Date.Parse(reader("now()"))) > 0 Then
                            stat = "Pending"
                            action = ""
                        Else
                            stat = "On-going"
                        End If
                        .Rows.Add(reader(0), reader(1), reader(2) + " " + reader(3), reader(4), _
                                    "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                    Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action, reader(6), reader("def"))

                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO RECORD FOR RENTAL"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetMonthlyPayment(id As Integer) As Decimal
        Try
            Dim d As Decimal = 0
            Dim sql As String
            sql = "Select (rent.rate+IFNULL(addedcharge,0)) as monthly from rent inner join border on rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
               & "left join(select addons.rentid,coalesce(sum(quantity*charge),0) as addedcharge from addons where " _
               & "type<>'Free' GROUP by addons.rentid)addons on rent.rentid=addons.rentid WHERE rent.rentid = " & id & ";"
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

    Public Sub ViewOccupantsInRoom(kw As String, gv As DataGridView, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "select border.borderid,Rent.Rentid,firstname,lastname,roomcode,whole,(rent.rate+IFNULL(addedcharge,0)) as monthly," _
                & "datein,dateout,Rent.status,maxoccupants,now() from rent inner join border on rent.borderid=border.borderid inner join room on rent.roomid=room.roomid " _
                & "left join(select addons.rentid,coalesce(sum(quantity*charge),0) as addedcharge from addons where " _
                & "type<>'Free' GROUP by addons.rentid)addons on rent.rentid=addons.rentid WHERE roomcode LIKE '" & kw & "%' ORDER BY datein DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                Status = "All"
                While reader.Read()
                    i = i + 1
                    With gv
                        Dim spc As String
                        Dim stat As String
                        Dim action As String
                        If reader(5) = reader(10) Then
                            spc = "Whole Room"
                        Else
                            spc = "Space Only"
                        End If
                        If Status = "All" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")).Date, Date.Parse(reader("now()")).Date) = 0 Then
                                    stat = "Out Today"
                                ElseIf Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) < 0 Then
                                    stat = "Over Due"
                                ElseIf Date.Compare(Date.Parse(reader("datein")).Date, Date.Parse(reader("now()")).Date) > 0 Then
                                    stat = "Pending"
                                Else
                                    stat = "On-going"
                                End If
                            Else
                                stat = "Closed/Void"
                                action = "View Details"
                            End If
                            .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                        "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                        Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                        ElseIf Status = "Closed/Void" Then
                            If reader(9) = "Off" Then
                                stat = "Closed/Void"
                                action = "View Details"
                                .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                            End If
                        ElseIf Status = "Out Today" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")).Date, Date.Parse(reader("now()")).Date) = 0 Then
                                    stat = "Out Today"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        ElseIf Status = "Over Due" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) < 0 Then
                                    stat = "Over Due"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        ElseIf Status = "On-going" Then
                            If reader(9) = "On" Then
                                action = "Edit"
                                If Date.Compare(Date.Parse(reader("dateout")), Date.Parse(reader("now()"))) > 0 Then
                                    stat = "On-going"
                                    .Rows.Add(reader(0), reader(1), i, reader(2) + " " + reader(3), reader(4), spc, _
                                          "₱ " & Format(reader(6), "n2"), Date.Parse(reader(7)).ToString("yyyy-MMM-dd"), _
                                          Date.Parse(reader(8)).ToString("yyyy-MMM-dd"), stat, action)
                                End If
                            End If
                        End If
                    End With
                End While
                reader.Close()
                If gv.RowCount > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO RECORD FOR RENTAL"
                    lbl.Show()
                End If
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
