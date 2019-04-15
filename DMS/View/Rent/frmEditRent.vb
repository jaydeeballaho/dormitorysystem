Imports System.Windows.Forms

Public Class frmEditRent

    Public rent As RentController
    Public border As BorderController
    Private room As New RoomController
    Private addons As New AddOnsController

    Private setting As New SettingsController
    Private fees As New FeesController
    Private notif As New BillingController

    Public temp As String = ""

    Private Sub btnRoom_Click(sender As Object, e As EventArgs) Handles btnRoom.Click
        Dim obj As New frmSearchRoom
        If rbMale.Checked = True Then
            obj.gender = "Male"
        ElseIf rbFemale.Checked = True Then
            obj.gender = "Female"
        Else
            obj.gender = "Male"
        End If
        obj.rent = Me.rent
        obj.room = Me.room
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With room
                txtRoom.Text = .RoomCode
                txtCategory.Text = .RoomCategory
            End With
            nudRate.Value = rent.Rate
            If rent.Whole = room.RoomOccupants Then
                txtNoSpace.Text = "Whole Room"
            Else
                txtNoSpace.Text = "Space Only"
            End If
        End If
    End Sub

    Private Sub frmAddRent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStatus.Text = "Rent Status" & vbCrLf & vbCrLf & temp
        If temp = "On-going" Then
            lblStatus.ForeColor = Color.SeaGreen
        ElseIf temp = "Out Today" Then
            lblStatus.ForeColor = Color.DarkOrange
        ElseIf temp = "Over Due" Then
            lblStatus.ForeColor = Color.Crimson
        Else
            lblStatus.ForeColor = Color.DarkGray
        End If
        setting.SetsettingsDetails(100)
        dtpDateIn.Value = frmMain.dtServer
        nudAdvance.Value = setting.Advance
        nudDeposit.Value = setting.Deposit

        With addons
            .RentID = rent.RentID
            .ViewAddOns(gvView)
        End With
        With border
            txtFirstname.Text = .BorderFN
            txtLastName.Text = .BorderLN
            txtContact.Text = .BorderCN
            If .BorderSex = "Male" Then
                rbMale.Checked = True
            Else
                rbFemale.Checked = True
            End If
        End With
        With room
            .SetRoomDetails(rent.RoomID)
            txtRoom.Text = .RoomCode
            txtCategory.Text = .RoomCategory
        End With
        nudRate.Value = rent.Rate
        If rent.Whole = room.RoomOccupants Then
            txtNoSpace.Text = "Whole Room"
        Else
            txtNoSpace.Text = "Space Only"
        End If
        With rent
            dtpDateIn.Value = .DateIn
            dtpDateOut.Value = .DateOut
            nudSpan.Value = DateDiff(DateInterval.Month, .DateIn, .DateOut)
        End With
        fees.SetFeesDetails(rent.RentID)
        With fees
            nudAdvance.Value = .Advance
            nudDeposit.Value = .Deposit
            nudTotalAdvance.Value = .AdvanceAmount
            nudTotalDeposits.Value = .DepositAmount
        End With
    End Sub

    Private Sub nudSpan_ValueChanged(sender As Object, e As EventArgs) Handles nudSpan.ValueChanged
        dtpDateOut.Value = DateAdd(DateInterval.Month, nudSpan.Value, dtpDateIn.Value)
    End Sub

    Private Sub dtpDateIn_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateIn.ValueChanged
        dtpDateOut.Value = DateAdd(DateInterval.Month, nudSpan.Value, dtpDateIn.Value)
    End Sub

    Private Sub nudAdvance_ValueChanged(sender As Object, e As EventArgs) Handles nudAdvance.ValueChanged
        nudTotalAdvance.Value = nudRate.Value * nudAdvance.Value
    End Sub

    Private Sub nudDeposit_ValueChanged(sender As Object, e As EventArgs) Handles nudDeposit.ValueChanged
        nudTotalDeposits.Value = nudRate.Value * nudDeposit.Value
    End Sub

    Private Sub nudTotalAddOns_ValueChanged(sender As Object, e As EventArgs) Handles nudTotalAddOns.ValueChanged
        nudMonthly.Value = nudRate.Value + nudTotalAddOns.Value
    End Sub

    Private Sub nudRate_ValueChanged(sender As Object, e As EventArgs) Handles nudRate.ValueChanged
        nudMonthly.Value = nudRate.Value + nudTotalAddOns.Value
        nudTotalAdvance.Value = nudRate.Value * nudAdvance.Value
        nudTotalDeposits.Value = nudRate.Value * nudDeposit.Value
    End Sub

    Private Sub btnAddOns_Click(sender As Object, e As EventArgs) Handles btnAddOns.Click
        Dim obj As New frmAddOns
        obj.setting = Me.setting
        obj.addons = Me.addons
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With addons
                If .Type = "Free" Then
                    gvView.Rows.Add("", gvView.RowCount + 1, .Name, .Qty, _
                                "Free", _
                                .Charge, .Type, "Edit", "Delete")
                Else
                    gvView.Rows.Add("", gvView.RowCount + 1, .Name, .Qty, _
                                .Qty & " * " & "₱ " & Format(.Charge, "n2") & " = " & "₱ " & Format(.Charge * .Qty, "n2"), _
                                .Charge, .Type, "Edit", "Delete")
                End If
            End With
        End If
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 7 Then
            Dim obj As New frmAddOns
            obj.setting = Me.setting
            obj.addons = Me.addons
            obj.edit = True
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                With addons
                    gvView.Rows.RemoveAt(addons.AddonsID)
                    addons.AddonsID = 0
                    If .Type = "Free" Then
                        gvView.Rows.Add("", gvView.RowCount + 1, .Name, .Qty, _
                                    "Free", _
                                    .Charge, .Type, "Edit", "Delete")
                    Else
                        gvView.Rows.Add("", gvView.RowCount + 1, .Name, .Qty, _
                                    .Qty & " * " & "₱ " & Format(.Charge, "n2") & " = " & "₱ " & Format(.Charge * .Qty, "n2"), _
                                    .Charge, .Type, "Edit", "Delete")
                    End If
                End With
                recount()
            End If
        ElseIf e.ColumnIndex = 8 Then
            gvView.Rows.RemoveAt(addons.AddonsID)
            addons.AddonsID = 0
        End If
    End Sub
    Sub recount()
        Dim i As Integer = 1
        Dim c As Decimal = 0
        For Each r As DataGridViewRow In gvView.Rows
            r.Cells(1).Value = i
            i = i + 1
            c = c + (r.Cells(3).Value * r.Cells(5).Value)
        Next
        nudTotalAddOns.Value = c
        recolor()
        gvView.ClearSelection()
    End Sub

    Private Sub gvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvView.CellFormatting
        recolor()
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            With addons
                .AddonsID = _ht.RowIndex
                .Name = Me.gvView.Rows(_ht.RowIndex).Cells(2).Value
                .Qty = Me.gvView.Rows(_ht.RowIndex).Cells(3).Value
                .Charge = Me.gvView.Rows(_ht.RowIndex).Cells(5).Value
                .Type = Me.gvView.Rows(_ht.RowIndex).Cells(6).Value
            End With
        End If
    End Sub

    Private Sub gvView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gvView.RowsAdded
        recount()
    End Sub

    Private Sub gvView_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles gvView.RowsRemoved
        recount()
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

    Sub recolor()
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(6).Value = "Free" Then
                r.Cells(4).Style.ForeColor = Color.SeaGreen
            Else
                r.Cells(4).Style.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim b As New BillingController
        Dim advance = DateDiff(DateInterval.Month, frmMain.dtServer.Date, b.GetLastPaidBills(rent.RentID))

        If advance > 0 Then
            Dim prev As Decimal = b.GetLastPaidAdds(rent.RentID)
            Dim ch As Decimal = nudTotalAddOns.Value - prev
            If ch > 0 Then
                MessageBox.Show("We have detected that you still have " & advance.ToString & " month(s) advance payment in your account. " _
                                   & "Your recent changes in your add-ons is greater than what you have paid in advance. Expect to receive " _
                                   & "new billing for this adjustment. Your previous add-ons: " & prev.ToString & ". Your latest add-ons: " _
                                   & nudTotalAddOns.Value.ToString & ". Expect additional " & ch.ToString & " x " & advance.ToString & " month(s) to be charged in your account.", "", _
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'add bill here
                With b
                    .RentID = rent.RentID
                    Dim re As New RentController
                    re.SetRentDetails(.RentID)

                    .BillDate = frmMain.dtServer.Date
                    .Amount = advance * ch
                    .DueDate = b.GetLastPaidBills(rent.RentID)
                    .DueAmount = .Amount
                    .Status = 0
                    .Type = "add-ons"
                    .Def = ch
                    .Advance = 1
                    .Addbill()
                End With
            End If
        End If
        rentedit()
    End Sub

    Sub rentedit()
        border.EditBorder()

        rent.RoomID = room.RoomID
        rent.Rate = nudRate.Value
        rent.DateOut = dtpDateOut.Value
        rent.EditRent()

        addons.RentID = rent.RentID
        addons.DeleteAddons()
        For Each r As DataGridViewRow In gvView.Rows
            With addons
                .RentID = rent.RentID
                .Name = r.Cells(2).Value
                .Qty = r.Cells(3).Value
                .Charge = r.Cells(5).Value
                .Type = r.Cells(6).Value
                .AddAddons()
            End With
        Next

        MessageBox.Show("Rental Information successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        If MessageBox.Show("This rent will be marked as closed or void. Would you still like to continue?", "Message", _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            rent.Status = "Off"
            border.Tag = 0
            btnRoom.Enabled = False
            btnAddOns.Enabled = False
            btnExtend.Enabled = False
            btnEnd.Enabled = False
            temp = "Closed/Void"
            lblStatus.Text = "Rent Status" & vbCrLf & vbCrLf & temp
            If temp = "On-going" Or temp = "Extended" Then
                lblStatus.ForeColor = Color.SeaGreen
            ElseIf temp = "Out Today" Then
                lblStatus.ForeColor = Color.DarkOrange
            ElseIf temp = "Over Due" Then
                lblStatus.ForeColor = Color.Crimson
            Else
                lblStatus.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

    Private Sub btnExtend_Click(sender As Object, e As EventArgs) Handles btnExtend.Click
        Dim obj As New frmExtend
        obj.rent = Me
        If obj.ShowDialog = Windows.Forms.DialogResult.OK Then
            rent.Status = "On"
            btnEnd.Enabled = False
            nudSpan.Value = nudSpan.Value + obj.nudMonth.Value
            temp = "Extended"
            lblStatus.Text = "Rent Status" & vbCrLf & vbCrLf & temp
            If temp = "On-going" Or temp = "Extended" Then
                lblStatus.ForeColor = Color.SeaGreen
            ElseIf temp = "Out Today" Then
                lblStatus.ForeColor = Color.DarkOrange
            ElseIf temp = "Over Due" Then
                lblStatus.ForeColor = Color.Crimson
            Else
                lblStatus.ForeColor = Color.DarkGray
            End If
        End If
    End Sub

    Private Sub btnUpdateBorder_Click(sender As Object, e As EventArgs) Handles btnUpdateBorder.Click
        Dim obj As New frmUpdateBorderInRent
        obj.border = Me.border
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With border
                txtFirstname.Text = .BorderFN
                txtLastName.Text = .BorderLN
                txtContact.Text = .BorderCN
                If .BorderSex = "Male" Then
                    rbMale.Checked = True
                Else
                    rbFemale.Checked = True
                End If
            End With
        End If
    End Sub
End Class
