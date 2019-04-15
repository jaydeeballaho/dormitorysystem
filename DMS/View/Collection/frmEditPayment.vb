Imports System.Windows.Forms

Public Class frmEditPayment

    Public rent As RentController
    Public pay As CollectionController
    Public border As BorderController

    Private room As New RoomController
    Private fees As New FeesController
    Private bill As New BillingController

    Dim tmp As Boolean = False
    Dim idx As Integer = 0

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
        If e.ColumnIndex = 8 Then
            If tmp = False Then
                Me.gvView.Rows(idx).Cells(8).Value = True
            Else
                Me.gvView.Rows(idx).Cells(8).Value = False
            End If
            Recount()
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
        EnableButton()
    End Sub

    Sub EnableButton()
        Dim c As Decimal = nudCash.Value
        Dim t As Decimal = nudPayables.Value
        Dim x As Decimal = c - t
        If x < 0 Then
            x = 0
        End If
        nudChange.Value = x
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Save()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Sub Save()
        With pay
            .Cash = nudCash.Value
            .Change = nudChange.Value
            .EditCollection()

            For Each r As DataGridViewRow In gvView.Rows
                If r.Cells(8).Value = False Then
                    .PayID = r.Cells(9).Value
                    .DeletePayment()
                    With bill
                        .BillID = r.Cells(0).Value
                        .SetbillDetails(.BillID)
                        .Status = 0
                        .Editbill()
                    End With
                End If
            Next
        End With
        MessageBox.Show("Payment successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmEditPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With bill
            .ViewCollectionForEdit(gvView, pay.CollectionID)
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
        nudRate.Value = rent.GetMonthlyPayment(rent.RentID)
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
        With pay
            nudCash.Value = .Cash
            nudChange.Value = .Change
        End With
    End Sub
End Class
