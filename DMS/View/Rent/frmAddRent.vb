Imports System.Windows.Forms

Public Class frmAddRent

    Public rent As RentController
    Public border As BorderController
    Public guardian As GuardianController

    Private room As New RoomController
    Private addons As New AddOnsController
    Private setting As New SettingsController
    Private fees As New FeesController
    Private notif As New BillingController

    Dim tmp As Integer = 0


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim obj As New frmAddBorder
        obj.border = Me.border
        obj.guardian = Me.guardian
        If btnNew.Text = "Edit Border" Then
            obj.edit = True
        End If
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
            btnNew.Text = "Edit Border"
        End If
    End Sub

    Private Sub btnRoom_Click(sender As Object, e As EventArgs) Handles btnRoom.Click
        If IsTextBoxEmpty(txtFirstname) = True Then
            MessageBox.Show("Please select BORDER to set your room category preference.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
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
                    tmp = room.RoomOccupants
                Else
                    txtNoSpace.Text = "Space Only"
                    tmp = 1
                End If
            End If
        End If
    End Sub

    Private Sub frmAddRent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setting.SetsettingsDetails(100)
        dtpDateIn.MinDate = DateAdd(DateInterval.Day, -7, frmMain.dtServer)
        dtpDateIn.Value = frmMain.dtServer
        nudAdvance.Value = setting.Advance
        nudDeposit.Value = setting.Deposit
    End Sub

    Private Sub nudSpan_ValueChanged(sender As Object, e As EventArgs) Handles nudSpan.ValueChanged
        dtpDateOut.Value = DateAdd(DateInterval.Month, nudSpan.Value, dtpDateIn.Value)
        nudAdvance.Maximum = nudSpan.Value
        nudDeposit.Maximum = nudSpan.Value
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
        If IsTextBoxEmpty(txtFirstname) Then
            MessageBox.Show("Border Information is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf IsTextBoxEmpty(txtRoom) Then
            MessageBox.Show("Room Information is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf btnNew.Text = "Edit Border" Then
            border.Tag = 1
            border.AddBorder()
            border.SetBorderID()
            With guardian
                .BorderID = border.BorderID
                .AddGuardian()
            End With
            rentadd()
        ElseIf btnNew.Text = "New Border" Then
            border.Tag = 1
            border.EditBorder()
            rentadd()
        End If
    End Sub

    Sub rentadd()
        rent.BorderID = border.BorderID
        rent.RoomID = room.RoomID
        rent.Rate = nudRate.Value
        rent.Whole = tmp
        rent.DateIn = dtpDateIn.Value
        rent.DateOut = dtpDateOut.Value
        rent.Status = "On"
        rent.AddRent()
        rent.SetRentID()
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

        With fees
            .RentID = rent.RentID
            .Advance = nudAdvance.Value
            .Deposit = nudDeposit.Value
            .AdvanceAmount = nudTotalAdvance.Value
            .DepositAmount = nudTotalDeposits.Value
            .AddFees()
        End With

        If nudAdvance.Value > 0 Then
            Dim pay As New CollectionController

            With pay
                .RentID = rent.RentID
                .PayDate = frmMain.dtServer.Date
                .CollectedBy = frmMain.fullname
                .Cash = nudTotalAdvance.Value + nudTotalDeposits.Value
                .Change = 0
                .AddCollection()
                .SetCollectionID()
            End With

            Dim bill As New BillingController

            For i As Integer = 1 To nudAdvance.Value

                With bill
                    .RentID = rent.RentID
                    .BillDate = DateAdd(DateInterval.Month, i, dtpDateIn.Value).ToString("yyyy-MM-dd")
                    .Amount = rent.Rate
                    .DueDate = .BillDate
                    .DueAmount = .Amount
                    .Status = 1
                    .Advance = 1
                    .Def = nudTotalAddOns.Value
                    .Addbill()
                End With

                With pay
                    .BillID = bill.GetAdvanceBillID()
                    .Amount = rent.Rate
                    .AddPayment()
                End With

                Dim re As New RentController
                re.SetRentDetails(rent.RentID)
                re.Counter = re.Counter + 1
                re.EditRentCounter()
            Next
        End If

        MessageBox.Show("New Rent and Border successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnBorder_Click(sender As Object, e As EventArgs) Handles btnBorder.Click
        Dim obj As New frmSearchBorder
        obj.Border = Me.border
        If obj.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnNew.Text = "New Border"
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
