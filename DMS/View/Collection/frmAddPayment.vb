Imports System.Windows.Forms

Public Class frmAddPayment

    Private rent As New RentController
    Private border As New BorderController
    Private room As New RoomController
   
    Private fees As New FeesController
    Private bill As New BillingController

    Private pay As New CollectionController

    Dim tmp As Boolean = False
    Dim idx As Integer = 0
    Dim IsAdvance As Boolean = False

    Dim def As Decimal = 0

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim obj As New frmSearchRent
        obj.rent = Me.rent
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            def = 0
            def = obj.def
            With bill
                .RentID = rent.RentID
                .ViewCollection(gvView)
            End With

            With border
                .SetBorderDetails(rent.BorderID)
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
                nudAdvance.Value = .AdvanceAmount
                nudDeposit.Value = .DepositAmount
            End With
            btnAdvance.Show()
        End If
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub gvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvView.CellFormatting
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(6).Value = 1 Then
                '  r.DefaultCellStyle.ForeColor = Color.Crimson
                r.Cells(5).Style.ForeColor = Color.Crimson
                r.Cells(3).Style.ForeColor = Color.Black
            Else
                r.Cells(5).Style.ForeColor = Color.Black
                r.Cells(3).Style.ForeColor = Color.Crimson
                'r.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            tmp = Me.gvView.Rows(_ht.RowIndex).Cells(8).Value
            idx = _ht.RowIndex
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
        Recount()
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If IsAdvance = False Then
            If e.ColumnIndex = 8 Then
                If tmp = False Then
                    Me.gvView.Rows(idx).Cells(8).Value = True
                Else
                    Me.gvView.Rows(idx).Cells(8).Value = False
                End If
                Recount()
            End If
        End If
    End Sub

    Sub Recount()
        Dim total As Decimal = 0
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(8).Value = True Then
                total = total + r.Cells(7).Value
            End If
        Next
        nudPayables.Value = total
        nudPaid.Value = total
    End Sub

    Private Sub nudCash_ValueChanged(sender As Object, e As EventArgs) Handles nudCash.ValueChanged
        EnableButton()
    End Sub

    Sub EnableButton()
        Dim c As Decimal = nudCash.Value
        Dim t As Decimal = nudPayables.Value
        Dim x As Decimal = c - t
        If x < 0 Then
            btnPrint.Enabled = False
            btnSave.Enabled = False
            x = 0
        Else
            If t = 0 Then
                btnPrint.Enabled = False
                btnSave.Enabled = False
            Else
                btnPrint.Enabled = True
                btnSave.Enabled = True
            End If
        End If
        nudChange.Value = x
    End Sub

    Private Sub nudPayables_ValueChanged(sender As Object, e As EventArgs) Handles nudPayables.ValueChanged
        EnableButton()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Save()
        print()
        With bill
            .RentID = rent.RentID
            .ViewCollection(gvView)
        End With
        nudCash.Value = 0
        nudChange.Value = 0
        nudPaid.Value = 0
        nudPayables.Value = 0
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
        With bill
            .RentID = rent.RentID
            .ViewCollection(gvView)
        End With
        nudCash.Value = 0
        nudChange.Value = 0
        nudPaid.Value = 0
        nudPayables.Value = 0
    End Sub

    Sub Save()
        With pay
            .RentID = rent.RentID
            .PayDate = frmMain.dtServer.Date
            .CollectedBy = frmMain.fullname
            .Cash = nudCash.Value
            .Change = nudChange.Value
            .AddCollection()
            .SetCollectionID()
            If IsAdvance = True Then
                For Each r As DataGridViewRow In gvView.Rows

                    With bill
                        .RentID = rent.RentID
                        .BillDate = Date.Parse(r.Cells(2).Value)
                        .Amount = r.Cells(7).Value
                        .DueDate = .BillDate
                        .DueAmount = .Amount
                        .Status = 1
                        .Advance = 1
                        .Def = def
                        .Addbill()
                    End With

                    .BillID = bill.GetAdvanceBillID()
                    .Amount = r.Cells(7).Value
                    .AddPayment()

                    Dim re As New RentController
                    re.SetRentDetails(.RentID)
                    re.Counter = re.Counter + 1
                    re.EditRentCounter()
                Next
            Else
                For Each r As DataGridViewRow In gvView.Rows
                    If r.Cells(8).Value = True Then
                        .BillID = r.Cells(0).Value
                        .Amount = r.Cells(7).Value
                        .AddPayment()
                        With bill
                            .BillID = r.Cells(0).Value
                            .SetbillDetails(.BillID)
                            .Status = 1
                            .Editbill()
                        End With
                    End If
                Next
            End If
        End With
        MessageBox.Show("Payment successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnSave.Enabled = False
        btnPrint.Enabled = False
    End Sub

    Private Sub btnAdvance_Click(sender As Object, e As EventArgs) Handles btnAdvance.Click
        If gvView.RowCount > 0 Then
            MessageBox.Show("There are still unpaid bills in your account, kindly settle them first.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim obj As New frmAddAdvance
            obj.rent = Me.rent
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'Do logic here
                'Add Row    
                IsAdvance = True
                btnDeleteAdvance.Show()
                Dim track As Date = obj.lastBill
                For i As Integer = 1 To obj.nudMonth.Value
                    gvView.Rows.Add("", i, DateAdd(DateInterval.Month, i, track).ToString("yyyy-MMM-dd"),
                                    "₱ " & Format(nudRate.Value, "n2"), DateAdd(DateInterval.Month, i, track).ToString("yyyy-MMM-dd"),
                                    "₱ " & Format(nudRate.Value, "n2"), 0, nudRate.Value, True)
                Next
                Recount()
            End If
        End If
    End Sub

    Private Sub btnDeleteAdvance_Click(sender As Object, e As EventArgs) Handles btnDeleteAdvance.Click
        gvView.Rows.Clear()
        IsAdvance = False
        btnDeleteAdvance.Hide()
        nudPayables.Value = 0
        nudCash.Value = 0
        btnSave.Enabled = False
        btnPrint.Enabled = False
    End Sub

    Sub print()
        Try
            Dim frm As New frmPrint
            Dim rpt As New crptPayment
            Dim dt As New DataTable

            With dt.Columns
                .Add("No")
                .Add("BillingDate")
                .Add("DueAmount")
                .Add("DueDate")
                .Add("AmountAfterDue")
                .Add("PaidAmount")
            End With

            For Each r As DataGridViewRow In gvView.Rows
                dt.Rows.Add(r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, r.Cells(5).Value, r.Cells(7).Value)
            Next


            rpt.SetDataSource(dt)

            rpt.SetParameterValue("name", txtFirstname.Text + " " + txtLastName.Text)
            rpt.SetParameterValue("room", txtRoom.Text)
            rpt.SetParameterValue("span", dtpDateIn.Value.ToString("yyyy-MM-dd") & " - " & dtpDateOut.Value.ToString("yyyy-MM-dd") _
                                  & " / " & nudSpan.Value.ToString() & "Month(s)")
            rpt.SetParameterValue("amount", "₱ " & Format(nudPayables.Value, "n2"))
            rpt.SetParameterValue("cash", "₱ " & Format(nudCash.Value, "n2"))
            rpt.SetParameterValue("change", "₱ " & Format(nudChange.Value, "n2"))
            rpt.SetParameterValue("printedby", frmMain.fullname)
            rpt.SetParameterValue("dateprinted", frmMain.dtServer.Date.ToString("yyyy-MM-dd"))
            With frm
                .crv.ReportSource = rpt
                .crv.Refresh()
                .ShowDialog()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
