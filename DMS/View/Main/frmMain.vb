Imports MySql.Data.MySqlClient

Public Class frmMain

    Public Shared flag As Integer = 0
    Public Shared AccountID As Integer = 0
    Public Shared fullname As String = "User Admin"
    Public Shared dtServer As Date = DateTime.Now
    Public Shared userType As String = "Administrator"

    Private account As New AccountController
    Public bill As New BillingController

    Private Sub timerMain_Tick(sender As Object, e As EventArgs) Handles timerMain.Tick
        Dim sql As String = "SELECT now();"
        Try
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                dtServer = cmd.ExecuteScalar
                tsDate.Text = MonthName(dtServer.Month) + " " + dtServer.Day.ToString() + ", " + dtServer.Year.ToString()
                tsTime.Text = dtServer.ToString("hh:mm:ss tt")
                tsUser.Text = fullname
                tsType.Text = userType
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If flag = 1 Then
            If MessageBox.Show("Are you sure you want to exit from the system?", "Message", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                account.SetAccountDetails(AccountID)
                account.AccountStatus = 0
                account.EditAccount()
            End If
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.F1 Then
        '    btnSearch.PerformClick()
        'ElseIf e.KeyCode = Keys.F2 Then
        '    '  btnRent.PerformClick()
        'ElseIf e.KeyCode = Keys.F3 Then
        '    btnBorder.PerformClick()
        'ElseIf e.KeyCode = Keys.F4 Then
        '    btnBillings.PerformClick()
        'ElseIf e.KeyCode = Keys.F5 Then
        '    btnCollections.PerformClick()
        'ElseIf e.KeyCode = Keys.F6 Then
        '    btnSettings.PerformClick()
        'ElseIf e.KeyCode = Keys.F7 Then
        '    btnReports.PerformClick()
        'ElseIf e.KeyCode = Keys.F8 Then
        '    btnAccounts.PerformClick()
        'ElseIf e.Alt And e.KeyCode = Keys.F10 Then
        '    btnLogout.PerformClick()
        'ElseIf e.Alt And e.KeyCode = Keys.F9 Then
        '    btnMyProfile.PerformClick()
        'End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Me.timerMain.Stop()
        Dim obj As New frmLogin
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If frmMain.userType = "Cashier" Then
                Dim cash As New frmAddPayment
                If cash.ShowDialog() = Windows.Forms.DialogResult.OK Then
                End If
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MessageBox.Show("This module is under construction.", "Message", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRent_Click(sender As Object, e As EventArgs) Handles btnRent.Click
        Dim obj As New frmRent
        obj.ShowDialog()
    End Sub

    Private Sub btnBorder_Click(sender As Object, e As EventArgs) Handles btnBorder.Click
        Dim obj As New frmBorder
        obj.ShowDialog()
    End Sub

    Private Sub btnBillings_Click(sender As Object, e As EventArgs) Handles btnBillings.Click
        Dim obj As New frmBillings
        obj.ShowDialog()
    End Sub

    Private Sub btnCollections_Click(sender As Object, e As EventArgs) Handles btnCollection.Click
        Dim obj As New frmCollection
        obj.ShowDialog()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim obj As New frmSettings
        obj.ShowDialog()
    End Sub

    Private Sub btnAccounts_Click(sender As Object, e As EventArgs) Handles btnAccounts.Click
        Dim obj As New frmAccount
        obj.ShowDialog()
    End Sub

    Private Sub btnRoom_Click(sender As Object, e As EventArgs) Handles btnRoom.Click
        Dim obj As New frmRoom
        obj.ShowDialog()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        MessageBox.Show("This module is under construction.", "Message", _
                         MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to log-out?", "Message", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            logout()
        End If
    End Sub

    Sub logout()
        account.SetAccountDetails(AccountID)
        account.AccountStatus = 0
        account.EditAccount()
        Me.Hide()
        Me.timerMain.Stop()
        Dim obj As New frmLogin
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If frmMain.userType = "Cashier" Then
                Dim cash As New frmAddPayment
                If cash.ShowDialog() = Windows.Forms.DialogResult.OK Then
                End If
            End If
        End If
    End Sub

    Private Sub btnMyProfile_Click(sender As Object, e As EventArgs) Handles btnMyProfile.Click
        Dim obj As New frmMyProfile
        account.SetAccountDetails(AccountID)
        obj.account = Me.account
        obj.ShowDialog()
    End Sub

    Private Sub btnViewRoom_Click(sender As Object, e As EventArgs) Handles btnViewRoom.Click
       ViewRoomStatus(flRoom, cmMain, lblRoom)
    End Sub

    Public Sub ViewRoomStatus(fl As FlowLayoutPanel, cm As ContextMenuStrip, lbl As Label)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT room.roomid,roomcode,category,maxoccupants,perbed,perroom,description,room.status,(maxoccupants-IFNULL(occupied,0)) as avail FROM Room left join(select roomid,coalesce(SUM(whole),0) as occupied from rent where status='On' GROUP by roomid)rent on room.roomid=rent.roomid ORDER BY roomcode ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                fl.Controls.Clear()
                While reader.Read()
                    i = i + 1
                    With fl
                        Dim btn As New Button
                        btn.Name = reader(1)
                        btn.Tag = reader(3) - reader(8)
                        btn.Text = "Room: " & reader(1).ToString() & vbCrLf & "Category: " & reader(2).ToString() & _
                            vbCrLf & "Status: " & reader(8).ToString() & " Available" & vbCrLf & vbCrLf & _
                            "Space: " & "₱ " & Format(reader(4), "n2") & vbCrLf & "Room: " & "₱ " & Format(reader(5), "n2")
                        btn.Size = New Size(140, 140)
                        btn.TextAlign = ContentAlignment.MiddleCenter
                        btn.ForeColor = Color.White

                        If reader(7) <> "Available" Then
                            btn.BackColor = Color.Silver
                        ElseIf reader(8) <= 0 Then
                            btn.BackColor = Color.Crimson
                        ElseIf reader(3) = reader(8) And reader(7) = "Available" Then
                            btn.BackColor = Color.SeaGreen
                        Else
                            btn.BackColor = Color.DarkOrange
                        End If
                        btn.FlatStyle = FlatStyle.Flat
                        btn.FlatAppearance.BorderSize = 0
                        btn.FlatAppearance.BorderColor = Color.White
                        btn.ContextMenuStrip = cm
                        btn.TabStop = False
                        fl.Controls.Add(btn)
                        AddHandler btn.MouseDown, AddressOf All_Buttons_Clicked

                    End With
                End While
                reader.Close()
                If fl.Controls.Count > 0 Then
                    lbl.Hide()
                Else
                    lbl.Text = "NO ROOMS YET"
                    lbl.Show()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub All_Buttons_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'some code here, can check to see which checkbox was changed, which button was clicked, by number or text
        Dim box As Button = DirectCast(sender, Button)
        If box.Tag > 0 Then
            Dim obj As New frmViewOccupantsInRoom
            obj.rm = box.Name
            obj.ShowDialog()
        Else
            MessageBox.Show("No occupant(s) yet in this room.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnViewNotif_Click(sender As Object, e As EventArgs) Handles btnViewNotif.Click
        ViewNotifications()
    End Sub

    Public Sub ViewNotifications()
        Dim notif As New Notifications
        notif.RentNotification(btnOutToday, btnOn, btnDue)
        bill.GenerateBilling(gvView)
        AddGeneratedRentBill(gvView)
        notif.BillNotification(btnNewBills, btnPaid, btnUnpaidBills)
    End Sub

    Sub AddGeneratedRentBill(gv As DataGridView)
        Dim s As New SettingsController
        s.SetsettingsDetails(100)
        For Each r As DataGridViewRow In gv.Rows
            With bill
                .RentID = r.Cells(0).Value
                Dim re As New RentController
                re.SetRentDetails(.RentID)

                .BillDate = DateAdd(DateInterval.Month, re.Counter, re.DateIn)
                .Amount = r.Cells(1).Value
                .DueDate = DateAdd(DateInterval.Day, s.NotifBilling, DateAdd(DateInterval.Month, re.Counter, re.DateIn))

                If s.Pentype = "Amount" Then
                    .DueAmount = .Amount + s.PenByAmount
                Else
                    .DueAmount = .Amount + (s.PenByPercent * .Amount)
                End If
                .Status = 0
                .Type = "rent"
                .Def = r.Cells(2).Value
                .Addbill()
                Dim rent As New RentController
                rent.SetRentDetails(.RentID)
                rent.Counter = rent.Counter + 1
                rent.EditRentCounter()
            End With
        Next
    End Sub

    Private Sub TimerBilling_Tick(sender As Object, e As EventArgs) Handles TimerBilling.Tick
        ViewNotifications()
    End Sub

    Private Sub TimerRoom_Tick(sender As Object, e As EventArgs) Handles TimerRoom.Tick
        ViewRoomStatus(flRoom, cmMain, lblRoom)
    End Sub
End Class
