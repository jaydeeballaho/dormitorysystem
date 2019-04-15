Imports System.Windows.Forms

Public Class frmBillings

    Private Bill As New BillingController
    Dim status = "0"
    Dim filter = "billingdate"

    Dim accname As String = ""
    Dim room As String = ""
    Dim billdate As String = ""
    Dim due As String = ""
    Dim amount As String = ""
    Dim afteramount As String = ""
    Dim by As String = ""
    Dim printed As String = ""

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Billing"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search billing" Then
            Bill.FilterBilling(txtSearch.Text, gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
        End If
    End Sub

    Private Sub frmborder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.SelectedIndex = 1
        cboDate.SelectedIndex = 0
        Bill.ViewBilling(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 9 Then
            'Delete
            If MessageBox.Show("Are you sure you want to delete this billing?", "", _
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Bill.DeleteBilling()
                Bill.ViewBilling(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
            End If
        ElseIf e.ColumnIndex = 10 Then
            'Print
            Try
                Dim frm As New frmPrint
                Dim rpt As New crptBilling

                rpt.SetParameterValue("name", accname)
                rpt.SetParameterValue("room", room)
                rpt.SetParameterValue("datebilling", billdate)
                rpt.SetParameterValue("duedate", due)
                rpt.SetParameterValue("amount", amount)
                rpt.SetParameterValue("addons", Format(Bill.Def, "n2"))

                rpt.SetParameterValue("amount2", amount)
                rpt.SetParameterValue("amountafterdue", afteramount)
                rpt.SetParameterValue("printedby", by)
                rpt.SetParameterValue("dateprinted", printed)

                With frm
                    .crv.ReportSource = rpt
                    .crv.Refresh()
                    .ShowDialog()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            Bill.SetbillDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
            accname = Me.gvView.Rows(_ht.RowIndex).Cells(3).Value.ToString()
            room = Me.gvView.Rows(_ht.RowIndex).Cells(4).Value.ToString()
            billdate = Me.gvView.Rows(_ht.RowIndex).Cells(2).Value.ToString()
            due = Me.gvView.Rows(_ht.RowIndex).Cells(5).Value.ToString()
            amount = Me.gvView.Rows(_ht.RowIndex).Cells(6).Value.ToString()
            afteramount = Me.gvView.Rows(_ht.RowIndex).Cells(7).Value.ToString()
            by = frmMain.fullname
            printed = frmMain.dtServer.Date.ToString("yyyy-MM-dd")
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        Bill.ViewBilling(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        Bill.ViewBilling(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub cboDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDate.SelectedIndexChanged
        If cboDate.Text = "Billing Date" Then
            filter = "billingdate"
        Else
            filter = "duedate"
        End If
        dtpStart.Value = Bill.GetStartDate(filter)
        dtpEnd.Value = Bill.GetEndDate(filter)
        Bill.ViewBilling(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        If cboStatus.Text = "Paid Only" Then
            status = 1
        ElseIf cboStatus.Text = "Unpaid Only" Then
            status = 0
        Else
            status = ""
        End If
        Bill.ViewBilling(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub
End Class
